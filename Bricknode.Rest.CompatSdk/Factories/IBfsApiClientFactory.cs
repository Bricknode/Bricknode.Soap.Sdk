namespace Bricknode.Soap.Sdk.Factories;

using System;
using System.Threading.Tasks;
using Configuration;

public interface IBfsApiClientFactory : IDisposable
{
    ValueTask<BfsApiConfiguration> GetConfigurationAsync(string? bfsApiClientName = null);

    /// <summary>
    /// Creates (and caches) a generated REST resource client of type <typeparamref name="TClient"/>
    /// configured with the base address from the matching <see cref="BfsApiConfiguration"/>.
    /// </summary>
    ValueTask<TClient> CreateClientAsync<TClient>(string? bfsApiClientName = null) where TClient : class;
}
