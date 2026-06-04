extern alias soapSdk;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using soapSdk::Bricknode.Soap.Sdk.Configuration;
using soapSdk::Bricknode.Soap.Sdk.Extensions;
using soapSdk::Bricknode.Soap.Sdk.Services;
using soapSdk::BfsApi;

namespace Bricknode.MigrationTestClient;

// ─────────────────────────────────────────────────────────────────────────────
// This file is IDENTICAL to RestDemoRunner.cs except:
//   • line 1: `extern alias soapSdk;`  (vs `restSdk`)
//   • it reads SoapEndpoint            (vs RestEndpoint)
// Everything else — DI setup, service interfaces, DTOs, calls — is the same.
// That is the entire migration: change the NuGet package, keep your code.
// ─────────────────────────────────────────────────────────────────────────────
internal sealed class SoapDemoRunner : IDemoRunner
{
    public string Name => "SOAP";

    public async Task RunAsync(AppConfig config)
    {
        Output.Header(Name);

        var services = new ServiceCollection();
        services.AddLogging(builder => builder.AddSimpleConsole(o => o.SingleLine = true));
        services.AddBfsApiClient(cfg =>
        {
            cfg.Credentials = new Credentials { UserName = config.Username, Password = config.Password };
            cfg.Identifier = config.Identifier;
            cfg.EndpointAddress = config.SoapEndpoint;
        });

        await using var provider = services.BuildServiceProvider();

        await ShowAccounts(provider);
        await ShowAccountTypes(provider);
        await ShowCurrencies(provider);
    }

    private static async Task ShowAccounts(IServiceProvider provider)
    {
        try
        {
            var accounts = provider.GetRequiredService<IBfsAccountService>();
            var response = await accounts.GetAccountsAsync(new GetAccountsArgs());
            Output.Area("Accounts.GetAccounts", response.Message, response.Result?.Length ?? 0,
                response.Result?.Select(a => a.AccountNo));
        }
        catch (Exception ex) { Output.Error("Accounts.GetAccounts", ex); }
    }

    private static async Task ShowAccountTypes(IServiceProvider provider)
    {
        try
        {
            var accounts = provider.GetRequiredService<IBfsAccountService>();
            var response = await accounts.GetAccountTypesAsync(new GetAccountTypeArgs());
            Output.Area("Accounts.GetAccountTypes", response.Message, response.Result?.Length ?? 0,
                response.Result?.Select(t => t.Key));
        }
        catch (Exception ex) { Output.Error("Accounts.GetAccountTypes", ex); }
    }

    private static async Task ShowCurrencies(IServiceProvider provider)
    {
        try
        {
            var currencies = provider.GetRequiredService<IBfsCurrencyService>();
            var response = await currencies.GetCurrenciesAsync(new GetCurrencyArgs());
            Output.Area("Currencies.GetCurrencies", response.Message, response.Result?.Length ?? 0);
        }
        catch (Exception ex) { Output.Error("Currencies.GetCurrencies", ex); }
    }
}
