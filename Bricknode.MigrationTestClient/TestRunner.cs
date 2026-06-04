using BfsApi;
using Bricknode.Soap.Sdk.Services;

namespace Bricknode.MigrationTestClient;

/// <summary>
/// The verification cases, written exactly as a consumer of the SDK writes them: services are
/// constructor-injected, DTOs come from <c>BfsApi</c>. This file compiles unchanged against both
/// the SOAP package and the REST drop-in — the only thing that changes is the package reference.
/// </summary>
internal sealed class TestRunner
{
    private readonly IBfsAccountService _accounts;
    private readonly IBfsCurrencyService _currencies;

    public TestRunner(IBfsAccountService accounts, IBfsCurrencyService currencies)
    {
        _accounts = accounts;
        _currencies = currencies;
    }

    public async Task RunAsync()
    {
        await GetAccounts();
        await GetAccountTypes();
        await GetCurrencies();
    }

    private async Task GetAccounts()
    {
        var response = await _accounts.GetAccountsAsync(new GetAccountsArgs());

        Print("GetAccounts", response.Message, response.Result?.Length ?? 0,
            response.Result?.Take(5).Select(a => a.AccountNo));
    }

    private async Task GetAccountTypes()
    {
        var response = await _accounts.GetAccountTypesAsync(new GetAccountTypeArgs());

        Print("GetAccountTypes", response.Message, response.Result?.Length ?? 0,
            response.Result?.Take(5).Select(t => t.Key));
    }

    private async Task GetCurrencies()
    {
        var response = await _currencies.GetCurrenciesAsync(new GetCurrencyArgs());

        Print("GetCurrencies", response.Message, response.Result?.Length ?? 0,
            response.Result?.Take(5).Select(c => c.Code));
    }

    private static void Print(string title, string? message, int count, IEnumerable<string>? sample)
    {
        var ok = message == "OK";
        Console.WriteLine();
        Console.WriteLine($"[{(ok ? "OK" : "FAIL")}] {title}");
        Console.WriteLine($"      message : {message}");
        Console.WriteLine($"      results : {count}");

        var items = sample?.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        if (items is { Count: > 0 })
            Console.WriteLine($"      sample  : {string.Join(", ", items)}");
    }
}
