namespace Bricknode.Soap.Sdk.Factories;

using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using Bricknode.Soap.Sdk.Configuration;

internal class SingleBfsClientFactory : IBfsApiClientFactory
{
    private readonly Action<BfsApiConfiguration> _configureAction;
    private readonly ConcurrentDictionary<Type, object> _cacheClients;
    private BfsApiConfiguration? _configuration;
    private HttpClient? _httpClient;

    public SingleBfsClientFactory(Action<BfsApiConfiguration> configureAction)
    {
        _configureAction = configureAction;
        _cacheClients = new ConcurrentDictionary<Type, object>();
    }

    private BfsApiConfiguration Configuration
    {
        get
        {
            if (_configuration is null)
            {
                _configuration = new BfsApiConfiguration();
                _configureAction(_configuration);
            }

            return _configuration;
        }
    }

    private HttpClient HttpClient => _httpClient ??= new HttpClient();

    public ValueTask<BfsApiConfiguration> GetConfigurationAsync(string? bfsApiClientName = null)
    {
        return new ValueTask<BfsApiConfiguration>(Configuration);
    }

    public ValueTask<TClient> CreateClientAsync<TClient>(string? bfsApiClientName = null) where TClient : class
    {
        var client = (TClient)_cacheClients.GetOrAdd(
            typeof(TClient),
            _ => RestResourceClientActivator.Create<TClient>(HttpClient, Configuration));

        return new ValueTask<TClient>(client);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
        _cacheClients.Clear();
    }
}
