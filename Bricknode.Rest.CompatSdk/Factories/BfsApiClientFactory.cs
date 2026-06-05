namespace Bricknode.Soap.Sdk.Factories;

using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using Configuration;

public class BfsApiClientFactory : IBfsApiClientFactory
{
    private readonly IBfsApiConfigurationProvider _configurationProvider;
    private readonly ConcurrentDictionary<string, BfsApiConfiguration> _cacheConfigurations;
    private readonly ConcurrentDictionary<string, HttpClient> _cacheHttpClients;
    private readonly ConcurrentDictionary<(string Name, Type ClientType), object> _cacheClients;

    public BfsApiClientFactory(IBfsApiConfigurationProvider configurationProvider)
    {
        _configurationProvider = configurationProvider;
        _cacheConfigurations = new ConcurrentDictionary<string, BfsApiConfiguration>(StringComparer.OrdinalIgnoreCase);
        _cacheHttpClients = new ConcurrentDictionary<string, HttpClient>(StringComparer.OrdinalIgnoreCase);
        _cacheClients = new ConcurrentDictionary<(string, Type), object>();
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

    public async ValueTask<TClient> CreateClientAsync<TClient>(string? bfsApiClientName = null) where TClient : class
    {
        bfsApiClientName ??= string.Empty;

        var key = (bfsApiClientName, typeof(TClient));
        if (_cacheClients.TryGetValue(key, out var cached))
            return (TClient)cached;

        var configuration = await GetConfigurationAsync(bfsApiClientName);
        var httpClient = _cacheHttpClients.GetOrAdd(bfsApiClientName, static _ => new HttpClient());
        var client = RestResourceClientActivator.Create<TClient>(httpClient, configuration);
        _cacheClients.TryAdd(key, client);

        return client;
    }

    public void Dispose()
    {
        foreach (var httpClient in _cacheHttpClients.Values)
            httpClient.Dispose();

        _cacheHttpClients.Clear();
        _cacheClients.Clear();
    }
}
