using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsTaxService : BfsServiceBase
    {
        private readonly bfsapiSoap _client;

        public BfsTaxService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, IBfsApiClientFactory bfsApiClientFactory, bfsapiSoap client) : base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }
    }
}