using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsPositionService : BfsServiceBase, IBfsPositionService
    {
        public BfsPositionService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002925/GetPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetPositionResponse> GetPositionsAsync(GetPositionArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetPositionRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetPositionFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetPositionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031196/GetHistoricPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetHistoricPositionResponse> GetHistoricPositionsAsync(GetHistoricPositionArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetHistoricPositionRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetHistoricPositionFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetHistoricPositionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/437157974/GetHoldingsOverTime
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetHoldingsOverTimeResponse> GetHoldingsOverTimeAsync(GetHoldingsOverTimeArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetHoldingsOverTimeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetHoldingsOverTimeResponseFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetHoldingsOverTimeAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}