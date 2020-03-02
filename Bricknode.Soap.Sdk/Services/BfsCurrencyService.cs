using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsCurrencyService : BfsServiceBase, IBfsCurrencyService
    {
        private readonly bfsapiSoap _client;

        public BfsCurrencyService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/56328392/GetCurrencies
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetCurrencyResponse> GetCurrenciesAsync(GetCurrencyArgs filters)
        {
            var request = GetRequest<GetCurrencyRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetCurrencyFields>();

            var response = await _client.GetCurrenciesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/458817672/GetCurrencyValues
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetCurrencyValueResponse> GetCurrencyValuesAsync(GetCurrencyValuesArgs filters)
        {
            var request = GetRequest<GetCurrencyValueRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetCurrencyValuesFields>();

            var response = await _client.GetCurrencyValuesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}