# Bricknode Migration Test Client

A small console app for **local verification** of the SOAP → REST migration, written exactly the
way an SDK consumer writes code: `IBfsAccountService` is constructor-injected via DI, DTOs come
from `BfsApi`. The same code runs against either package — the only thing that changes is the
package reference.

## Run

```bash
dotnet run                    # original SOAP SDK (Bricknode.Soap.Sdk)
dotnet run -p:UseRest=true    # REST drop-in     (Bricknode.Rest.CompatSdk)
```

The switch swaps the `<ProjectReference>` in the csproj. In a real application that is the
`<PackageReference>` you change — `Program.cs` and `TestRunner.cs` are untouched. That is the
whole migration.

The only runtime difference: `EndpointAddress` must point at the REST base URL instead of the
SOAP `.asmx` (this client reads `SoapEndpoint`/`RestEndpoint` from config accordingly).

## Configure credentials (never committed)

Copy the template and fill it in:

```bash
cp appsettings.example.json appsettings.json
```

`appsettings.json` and `appsettings.local.json` are git-ignored. Alternatively use environment
variables: `BFS_Username`, `BFS_Password`, `BFS_Identifier`, `BFS_SoapEndpoint`, `BFS_RestEndpoint`.

## What it runs

One read-only case in `TestRunner.cs`: `IBfsAccountService.GetAccountsAsync` — prints the response
message, result count and a small sample, so you can compare SOAP vs REST output side by side.
