using BfsApi;
using Bricknode.Soap.Sdk.Services;

namespace Bricknode.MigrationTestClient;

/// <summary>
/// The verification case, written exactly as a consumer of the SDK writes it: the service is
/// constructor-injected, DTOs come from <c>BfsApi</c>. This file compiles unchanged against both
/// the SOAP package and the REST drop-in — the only thing that changes is the package reference.
/// </summary>
internal sealed class TestRunner
{
    private readonly IBfsAccountService _accounts;

    public TestRunner(IBfsAccountService accounts)
    {
        _accounts = accounts;
    }

    public async Task RunAsync()
    {
        var response = await _accounts.GetAccountsAsync(new GetAccountsArgs());

        var ok = response.Message == "OK";
        Console.WriteLine();
        Console.WriteLine($"[{(ok ? "OK" : "FAIL")}] GetAccounts");
        Console.WriteLine($"      message : {response.Message}");
        Console.WriteLine($"      results : {response.Result?.Length ?? 0}");

        if (response.Result is { Length: > 0 })
            Console.WriteLine($"      sample  : {string.Join(", ", response.Result.Take(5).Select(a => a.AccountNo))}");
    }
}
