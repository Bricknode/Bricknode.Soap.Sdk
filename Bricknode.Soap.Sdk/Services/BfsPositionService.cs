using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsPositionService : BfsServiceBase, IBfsPositionService
    {
        private readonly bfsapiSoap _client;

        public BfsPositionService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002925/GetPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetPositionResponse> GetPositionsAsync(GetPositionArgs filters)
        {
            var request = GetRequest<GetPositionRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetPositionFields>();

            var response = await _client.GetPositionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031196/GetHistoricPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetHistoricPositionResponse> GetHistoricPositionsAsync(GetHistoricPositionArgs filters)
        {
            var request = GetRequest<GetHistoricPositionRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetHistoricPositionFields>();

            var response = await _client.GetHistoricPositionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/437157974/GetHoldingsOverTime
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetHoldingsOverTimeResponse> GetHoldingsOverTimeAsync(GetHoldingsOverTimeArgs filters)
        {
            var request = GetRequest<GetHoldingsOverTimeRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetHoldingsOverTimeResponseFields>();

            var response = await _client.GetHoldingsOverTimeAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}