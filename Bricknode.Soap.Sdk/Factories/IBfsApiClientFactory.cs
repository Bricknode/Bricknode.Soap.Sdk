namespace Bricknode.Soap.Sdk.Factories;

using System;
using System.Threading.Tasks;
using BfsApi;
using Configuration;

public interface IBfsApiClientFactory : IDisposable
{
    ValueTask<BfsApiConfiguration> GetConfigurationAsync(string? bfsApiClientName = null);

    ValueTask<bfsapiSoap> CreateClientAsync(string? bfsApiClientName = null);
}