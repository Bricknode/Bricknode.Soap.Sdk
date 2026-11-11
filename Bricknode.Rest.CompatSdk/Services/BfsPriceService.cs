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
    /// REST-backed drop-in replacement for the SOAP <c>BfsPriceService</c>.
    /// Public surface is identical; internally it maps the SOAP-shaped <c>BfsApi.*</c> DTOs to the
    /// generated REST records (<see cref="BfsJsonMapper"/>) and calls the REST resource clients.
    /// </summary>
    public class BfsPriceService : BfsServiceBase, IBfsPriceService
    {
        public BfsPriceService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/149133779/GetHistoricPrices
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetHistoricPricesResponse> GetHistoricPricesAsync(GetHistoricPricesArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetHistoricPricesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetHistoricPricesFields>();

            var client = await GetClientAsync<RestApi.PricesClient>(bfsApiClientName);
            var restResponse = await client.GetHistoricAsync(BfsJsonMapper.Map<RestApi.GetHistoricPricesRequest>(request));
            var response = BfsJsonMapper.Map<GetHistoricPricesResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58261735/SetHistoricPrices
        /// </summary>
        /// <param name="priceDateEntries"></param>
        /// <param name="clearAllPreviousData"></param>
        /// <param name="clearPreviousDataByRange"></param>
        /// <param name="updateCurrentPriceFromLastPrice"></param>
        /// <param name="clearAllsubsequentData"></param>
        /// /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<SetHistoricPricesResponse> SetHistoricPricesAsync(PriceDateEntry[] priceDateEntries,
            bool clearAllPreviousData = false,
            bool clearPreviousDataByRange = false,
            bool updateCurrentPriceFromLastPrice = false,
            bool clearAllsubsequentData = false,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<SetHistoricPricesRequest>(bfsApiClientName);

            request.PriceDateEntries = priceDateEntries;
            request.ClearAllPreviousData = clearAllPreviousData;
            request.ClearPreviousDataByRange = clearPreviousDataByRange;
            request.UpdateCurrentPriceFromLastPrice = updateCurrentPriceFromLastPrice;
            request.ClearAllsubsequentData = clearAllsubsequentData;

            var client = await GetClientAsync<RestApi.HistoricPricesClient>(bfsApiClientName);
            var restResponse = await client.SetAsync(BfsJsonMapper.Map<RestApi.SetHistoricPricesRequest>(request));
            var response = BfsJsonMapper.Map<SetHistoricPricesResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}