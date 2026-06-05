using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;
    using System.Collections.Generic;

    public class BfsPositionService : BfsServiceBase, IBfsPositionService
    {
        public BfsPositionService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
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

            var client = await GetClientAsync<RestApi.PositionsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetPositionRequest>(request));
            var response = BfsJsonMapper.Map<GetPositionResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        public async IAsyncEnumerable<GetPositionResponse> GetPositionsInPagesAsync(GetPositionArgs filters, int pageSize = 2000, int pageStartIndex = 0, string? bfsApiClientName = null)
        {
            GetPositionResponse response;
            bool isValidResponse;
            var pageIndex = pageStartIndex;
            var client = await GetClientAsync<RestApi.PositionsClient>(bfsApiClientName);
            var request = await GetRequestAsync<GetPositionRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetPositionFields>();
            request.EnablePagination = true;
            request.PageSize = pageSize;
            do
            {
                request.PageIndex = pageIndex++;
                var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetPositionRequest>(request));
                response = BfsJsonMapper.Map<GetPositionResponse>(restResponse)!;
                isValidResponse = ValidateResponse(response);
                if (isValidResponse)
                {
                    LogErrors(response.Message);
                }

                yield return response;
            } while (isValidResponse && response.Result.Length >= pageSize);
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

            var client = await GetClientAsync<RestApi.PositionsClient>(bfsApiClientName);
            var restResponse = await client.SearchHistoricAsync(BfsJsonMapper.Map<RestApi.GetHistoricPositionRequest>(request));
            var response = BfsJsonMapper.Map<GetHistoricPositionResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.HoldingsOverTimeClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetHoldingsOverTimeRequest>(request));
            var response = BfsJsonMapper.Map<GetHoldingsOverTimeResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}