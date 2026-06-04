using Bricknode.MigrationTestClient;
using Microsoft.Extensions.Configuration;

// Local verification tool + migration example.
//   dotnet run            -> exercises the original SOAP SDK
//   dotnet run -- --rest  -> exercises the REST drop-in (Bricknode.Rest.CompatSdk)
// The two runners are identical except which package (extern alias) they use — that IS the migration.

if (args.Any(a => a is "-h" or "--help"))
{
    PrintUsage();
    return 0;
}

var useRest = args.Any(a => string.Equals(a, "--rest", StringComparison.OrdinalIgnoreCase));

var config = LoadConfig();
if (!config.HasCredentials)
{
    Console.Error.WriteLine(
        "No credentials found. Copy appsettings.example.json to appsettings.json and fill it in, " +
        "or set BFS_Username / BFS_Password / BFS_Identifier environment variables.");
    PrintUsage();
    return 1;
}

IDemoRunner runner = useRest ? new RestDemoRunner() : new SoapDemoRunner();

var endpoint = useRest ? config.RestEndpoint : config.SoapEndpoint;
if (string.IsNullOrWhiteSpace(endpoint))
{
    Console.Error.WriteLine($"No endpoint configured for the {runner.Name} client " +
                            $"(set {(useRest ? "RestEndpoint" : "SoapEndpoint")}).");
    return 1;
}

try
{
    await runner.RunAsync(config);
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Fatal: {ex.GetType().Name}: {ex.Message}");
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

static void PrintUsage()
{
    Console.WriteLine();
    Console.WriteLine("Usage:");
    Console.WriteLine("  dotnet run             Run the demo against the SOAP SDK (default).");
    Console.WriteLine("  dotnet run -- --rest   Run the SAME demo against the REST compat SDK.");
    Console.WriteLine();
    Console.WriteLine("Credentials: appsettings.json (git-ignored) or BFS_* environment variables.");
}
