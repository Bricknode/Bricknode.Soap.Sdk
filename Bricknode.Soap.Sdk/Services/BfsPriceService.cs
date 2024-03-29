﻿using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetHistoricPricesAsync(request);

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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.SetHistoricPricesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}