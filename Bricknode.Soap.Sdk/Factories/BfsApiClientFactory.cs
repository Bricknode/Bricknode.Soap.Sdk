namespace Bricknode.Soap.Sdk.Factories;

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using BfsApi;
using Configuration;
using Helpers;

public class BfsApiClientFactory : IBfsApiClientFactory
{
    private readonly IBfsApiConfigurationProvider _configurationProvider;
    private readonly Dictionary<string, BfsApiConfiguration> _cacheConfigurations;
    private readonly Dictionary<string, bfsapiSoapClient> _cacheClients;

    public BfsApiClientFactory(IBfsApiConfigurationProvider configurationProvider)
    {
        _configurationProvider = configurationProvider;
        _cacheConfigurations = new Dictionary<string, BfsApiConfiguration>(StringComparer.OrdinalIgnoreCase);
        _cacheClients = new Dictionary<string, bfsapiSoapClient>(StringComparer.OrdinalIgnoreCase);
    }

    public async ValueTask<BfsApiConfiguration> GetConfigurationAsync(string? bfsApiClientName = null)
    {
        bfsApiClientName ??= string.Empty;

        if (!_cacheConfigurations.TryGetValue(bfsApiClientName, out var configuration))
        {
            configuration = await _configurationProvider.GetConfigurationAsync(bfsApiClientName);
            _cacheConfigurations[bfsApiClientName] = configuration;
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
            _cacheClients[bfsApiClientName] = client;
        }

        return client;
    }

    internal static bfsapiSoapClient CreateSoapClient(BfsApiConfiguration bfsApiConfiguration)
        => new(BfsBinding.GetBfsBinding(), new EndpointAddress(bfsApiConfiguration.EndpointAddress));

    public void Dispose()
    {
        foreach (var client in _cacheClients.Values)
        {
            ((IDisposable)client).Dispose();
        }

        _cacheClients.Clear();
    }
}