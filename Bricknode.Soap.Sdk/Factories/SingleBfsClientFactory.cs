using System;

namespace Bricknode.Soap.Sdk.Factories;

using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;

internal class SingleBfsClientFactory : IBfsApiClientFactory
{
    private readonly Action<BfsApiConfiguration> _configureAction;
    private BfsApiConfiguration? _configuration;
    private bfsapiSoapClient? _client;

    public SingleBfsClientFactory(Action<BfsApiConfiguration> configureAction)
    {
        _configureAction = configureAction;
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

    private bfsapiSoap Client => _client ??= BfsApiClientFactory.CreateSoapClient(Configuration);


    public ValueTask<BfsApiConfiguration> GetConfigurationAsync(string? bfsApiClientName = null)
    {
        return new ValueTask<BfsApiConfiguration>(Configuration);
    }

    public ValueTask<bfsapiSoap> CreateClientAsync(string? bfsApiClientName = null)
    {
        return new ValueTask<bfsapiSoap>(Client);
    }

    public void Dispose()
    {
        (_client as IDisposable)?.Dispose();
    }
}