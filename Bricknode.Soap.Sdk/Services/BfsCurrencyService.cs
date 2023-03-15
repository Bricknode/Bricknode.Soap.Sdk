using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsCurrencyService : BfsServiceBase, IBfsCurrencyService
    {
        public BfsCurrencyService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetCurrenciesAsync(request);

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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetCurrencyValuesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}