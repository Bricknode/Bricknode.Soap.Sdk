namespace Bricknode.MigrationTestClient;

/// <summary>
/// Credentials + endpoints for the demo run. Bound from appsettings.json / appsettings.local.json
/// / environment variables (prefix BFS_). Never commit real values — see appsettings.example.json.
/// </summary>
internal sealed class AppConfig
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Identifier { get; set; } = "";

    /// <summary>SOAP endpoint, e.g. https://your-instance.bricknode.com/api/BFSApi.asmx</summary>
    public string SoapEndpoint { get; set; } = "";

    /// <summary>REST API base address, e.g. https://your-instance.bricknode.com/</summary>
    public string RestEndpoint { get; set; } = "";

    public bool HasCredentials =>
        !string.IsNullOrWhiteSpace(Username) &&
        !string.IsNullOrWhiteSpace(Password) &&
        !string.IsNullOrWhiteSpace(Identifier);
}
