# Bricknode Migration Test Client

A small console app for **local verification** of the SOAP → REST migration, written exactly the
way an SDK consumer writes code: services (`IBfsAccountService`, `IBfsCurrencyService`) are
constructor-injected via DI, DTOs come from `BfsApi`. The same code runs against either package —
the only thing that changes is the package reference.

## Run

```bash
dotnet run                    # original SOAP SDK (Bricknode.Soap.Sdk)
dotnet run -p:UseRest=true    # REST drop-in     (Bricknode.Rest.CompatSdk)
```

The switch swaps the `<ProjectReference>` in the csproj. In a real application that is the
`<PackageReference>` you change — `Program.cs` and `TestRunner.cs` are untouched. That is the
whole migration.

> **Note:** the flavor is baked in at **build** time — don't combine the switch with `--no-build`,
> or you'll run whichever flavor was built last.

## Known differences when migrating

- `EndpointAddress` must point at the REST base URL instead of the SOAP `.asmx`
  (this client reads `SoapEndpoint`/`RestEndpoint` from config accordingly).
- **Dates:** none — `DateTime` values (UTC `Kind=Utc`, unset dates as `DateTime.MinValue`) are
  identical to what the SOAP SDK produces, guaranteed by `SoapRestWireParityTests` which runs the
  same server data through the real `XmlSerializer` and the REST pipeline and requires
  byte-identical results.

## Configure credentials (never committed)

Copy the template and fill it in:

```bash
cp appsettings.example.json appsettings.json
```

`appsettings.json` and `appsettings.local.json` are git-ignored. Alternatively use environment
variables: `BFS_Username`, `BFS_Password`, `BFS_Identifier`, `BFS_SoapEndpoint`, `BFS_RestEndpoint`.

## What it runs

Four read-only cases in `TestRunner.cs`, each printing the response message, result count and a
small sample so you can compare SOAP vs REST output side by side:

- `IBfsAccountService.GetAccountsAsync`
- `IBfsAccountService.GetAccountTypesAsync`
- `IBfsCurrencyService.GetCurrenciesAsync`
- `IBfsAccountService.GetAccountsAsync` with a `CreatedDateFrom` filter — prints the date sent and
  the dates received (value + `Kind`), proving the server applies the date and both SDKs see
  identical values in both directions.
