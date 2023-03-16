namespace Bricknode.Soap.Sdk.Factories;

using System;
using System.Collections.Concurrent;
using System.ServiceModel;
using System.Threading.Tasks;
using BfsApi;
using Configuration;
using Helpers;

public class BfsApiClientFactory : IBfsApiClientFactory
{
    private readonly IBfsApiConfigurationProvider _configurationProvider;
    private readonly ConcurrentDictionary<string, BfsApiConfiguration> _cacheConfigurations;
    private readonly ConcurrentDictionary<string, bfsapiSoapClient> _cacheClients;

    public BfsApiClientFactory(IBfsApiConfigurationProvider configurationProvider)
    {
        _configurationProvider = configurationProvider;
        _cacheConfigurations = new ConcurrentDictionary<string, BfsApiConfiguration>(StringComparer.OrdinalIgnoreCase);
        _cacheClients = new ConcurrentDictionary<string, bfsapiSoapClient>(StringComparer.OrdinalIgnoreCase);
    }

    public async ValueTask<BfsApiConfiguration> GetConfigurationAsync(string? bfsApiClientName = null)
    {
        bfsApiClientName ??= string.Empty;

        if (!_cacheConfigurations.TryGetValue(bfsApiClientName, out var configuration))
        {
            configuration = await _configurationProvider.GetConfigurationAsync(bfsApiClientName);
            _cacheConfigurations.TryAdd(bfsApiClientName, configuration);
        }

        return configuration;
    }

    public async ValueTask<bfsapiSoap> CreateClientAsync(string? bfsApiClientName = null)
    {
        bfsApiClientName ??= string.Empty;

        if (!_cacheClients.TryGetValue(bfsApiClientName, out var client))
        {
            var configuration = await GetConfigurationAsync(bfsApiClientName);
            client = CreateSoapClient(configuration);
            _cacheClients.TryAdd(bfsApiClientName, client);
        }

        return client;
    }

    internal static bfsapiSoapClient CreateSoapClient(BfsApiConfiguration bfsApiConfiguration)
        => new(BfsBinding.GetBfsBinding(), new EndpointAddress(bfsApiConfiguration.EndpointAddress));

    public void Dispose()
    {
        foreach (var client in _cacheClients.Values)
        {
            DisposeClientSafely(client);
        }

        _cacheClients.Clear();
    }

    private void DisposeClientSafely(bfsapiSoapClient client)
    {
        try
        {
            if (client.State != CommunicationState.Faulted)
            {
                client.Close();
            }
        }
        finally
        {
            if (client.State != CommunicationState.Closed)
            {
                client.Abort();
            }
        }
    }
}