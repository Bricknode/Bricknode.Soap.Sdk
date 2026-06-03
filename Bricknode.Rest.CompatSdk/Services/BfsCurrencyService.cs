using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    /// <summary>
    /// REST-backed drop-in replacement for the SOAP <c>BfsCurrencyService</c>.
    /// Public surface is identical; internally it maps the SOAP-shaped <c>BfsApi.*</c> DTOs to the
    /// generated REST records (<see cref="BfsJsonMapper"/>) and calls the REST resource clients.
    /// </summary>
    public class BfsCurrencyService : BfsServiceBase, IBfsCurrencyService
    {
        public BfsCurrencyService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/56328392/GetCurrencies
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetCurrencyResponse> GetCurrenciesAsync(GetCurrencyArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetCurrencyRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCurrencyFields>();

            var client = await GetClientAsync<RestApi.CurrenciesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetCurrencyRequest>(request));
            var response = BfsJsonMapper.Map<GetCurrencyResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/458817672/GetCurrencyValues
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetCurrencyValueResponse> GetCurrencyValuesAsync(GetCurrencyValuesArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetCurrencyValueRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCurrencyValuesFields>();

            var client = await GetClientAsync<RestApi.CurrenciesClient>(bfsApiClientName);
            var restResponse = await client.SearchValuesAsync(BfsJsonMapper.Map<RestApi.GetCurrencyValueRequest>(request));
            var response = BfsJsonMapper.Map<GetCurrencyValueResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}