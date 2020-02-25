using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsPriceService : BfsServiceBase, IBfsPriceService
    {
        private readonly bfsapiSoap _client;

        public BfsPriceService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client) :
            base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/149133779/GetHistoricPrices
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetHistoricPricesResponse> GetHistoricPricesAsync(GetHistoricPricesArgs filters)
        {
            var request = GetRequest<GetHistoricPricesRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetHistoricPricesFields>();

            var response = await _client.GetHistoricPricesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

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
        /// <returns></returns>
        public async Task<SetHistoricPricesResponse> SetHistoricPricesAsync(PriceDateEntry[] priceDateEntries,
            bool clearAllPreviousData = false,
            bool clearPreviousDataByRange = false,
            bool updateCurrentPriceFromLastPrice = false,
            bool clearAllsubsequentData = false)
        {
            var request = GetRequest<SetHistoricPricesRequest>();

            request.PriceDateEntries = priceDateEntries;
            request.ClearAllPreviousData = clearAllPreviousData;
            request.ClearPreviousDataByRange = clearPreviousDataByRange;
            request.UpdateCurrentPriceFromLastPrice = updateCurrentPriceFromLastPrice;
            request.ClearAllsubsequentData = clearAllsubsequentData;

            var response = await _client.SetHistoricPricesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}