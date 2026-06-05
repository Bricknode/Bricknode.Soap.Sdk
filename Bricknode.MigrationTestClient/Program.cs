using BfsApi;
using Bricknode.MigrationTestClient;
using Bricknode.Soap.Sdk.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Local verification tool + migration example.
//   dotnet run                  -> original SOAP SDK
//   dotnet run -p:UseRest=true  -> REST drop-in (Bricknode.Rest.CompatSdk)
// All code below is ordinary SDK consumer code; only the package reference changes.


var config = LoadConfig();
if (!config.HasCredentials)
{
    Console.Error.WriteLine(
        "No credentials found. Copy appsettings.example.json to appsettings.json and fill it in, " +
        "or set BFS_Username / BFS_Password / BFS_Identifier environment variables.");
    return 1;
}

#if USE_REST
const string sdk = "REST (Bricknode.Rest.CompatSdk)";
var endpoint = config.RestEndpoint;
#else
const string sdk = "SOAP (Bricknode.Soap.Sdk)";
var endpoint = config.SoapEndpoint;
#endif

if (string.IsNullOrWhiteSpace(endpoint))
{
    Console.Error.WriteLine($"No endpoint configured for {sdk}.");
    return 1;
}

Console.WriteLine($"Bricknode migration test client — {sdk}");
Console.WriteLine($"Endpoint: {endpoint}");

var services = new ServiceCollection();
services.AddLogging(builder => builder.AddSimpleConsole(o => o.SingleLine = true));
services.AddBfsApiClient(cfg =>
{
    cfg.Credentials = new Credentials { UserName = config.Username, Password = config.Password };
    cfg.Identifier = config.Identifier;
    cfg.EndpointAddress = endpoint;
});
services.AddTransient<TestRunner>();

await using var provider = services.BuildServiceProvider();

try
{
    await provider.GetRequiredService<TestRunner>().RunAsync();
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Failed: {ex.GetType().Name}: {ex.Message}");
    for (var inner = ex.InnerException; inner is not null; inner = inner.InnerException)
        Console.Error.WriteLine($"  inner: {inner.GetType().Name}: {inner.Message}");
    return 1;
}

static AppConfig LoadConfig()
{
    var root = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .AddJsonFile("appsettings.local.json", optional: true)
        .AddEnvironmentVariables("BFS_")
        .Build();

    return root.Get<AppConfig>() ?? new AppConfig();
}
