# Bricknode Migration Test Client

A tiny console app for **local verification** of the SOAP → REST migration, doubling as a
**migration example**. It runs the same read-only calls against either SDK and prints the results
side by side so you can confirm the REST drop-in behaves like the original SOAP SDK.

## Areas exercised (read-only)

- `IBfsAccountService.GetAccountsAsync`
- `IBfsAccountService.GetAccountTypesAsync`
- `IBfsCurrencyService.GetCurrenciesAsync`

## Configure credentials (never committed)

Copy the template and fill it in:

```bash
cp appsettings.example.json appsettings.json
```

`appsettings.json` (and `appsettings.local.json`) are git-ignored. Alternatively use environment
variables: `BFS_Username`, `BFS_Password`, `BFS_Identifier`, `BFS_SoapEndpoint`, `BFS_RestEndpoint`.

- `SoapEndpoint` — the SOAP `.asmx` URL.
- `RestEndpoint` — the REST API **base** address (root), not the `.asmx`.

## Run

```bash
dotnet run             # SOAP SDK (default)
dotnet run -- --rest   # REST drop-in (Bricknode.Rest.CompatSdk)
```

## What this proves about the migration

`SoapDemoRunner.cs` and `RestDemoRunner.cs` are **byte-for-byte identical except one line** — the
`extern alias` selecting the package (and which endpoint they read):

```bash
git diff --no-index SoapDemoRunner.cs RestDemoRunner.cs
```

In a real migration you reference only **one** package, so you don't even need the alias: you change
the `<PackageReference>` from `Bricknode.Soap.Sdk` to `Bricknode.Rest.CompatSdk` and your code
(`AddBfsApiClient`, `IBfs*Service`, `BfsApi.*` DTOs) stays the same. The only runtime change is
pointing `EndpointAddress` at the REST base URL instead of the `.asmx`.
