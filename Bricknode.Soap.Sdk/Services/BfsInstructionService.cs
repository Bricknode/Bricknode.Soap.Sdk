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

    public class BfsInstructionService : BfsServiceBase, IBfsInstructionService
    {
        private readonly bfsapiSoap _client;

        public BfsInstructionService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        #region Fund Instructions

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132947/GetFundInstructions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetFundInstructionResponse> GetFundInstructionsAsync(GetFundInstructionArgs filters)
        {
            var request = GetRequest<GetFundInstructionRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetFundInstructionFields>();

            var response = await _client.GetFundInstructionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/147881428/GetFundInstructionStatusLogs
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetFundInstructionStatusLogResponse> GetFundInstructionStatusLogsAsync(
            GetFundInstructionStatusLogArgs filters)
        {
            var request = GetRequest<GetFundInstructionStatusLogRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetFundInstructionStatusLogFields>();

            var response = await _client.GetFundInstructionStatusLogsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/147881601/GetFundInstructionExecutions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetFundInstructionExecutionResponse> GetFundInstructionExecutionsAsync(
            GetFundInstructionExecutionArgs filters)
        {
            var request = GetRequest<GetFundInstructionExecutionRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetFundInstructionExecutionFields>();

            var response = await _client.GetFundInstructionExecutionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132952/FundInstructions+Settle
        /// </summary>
        /// <param name="fundInstruction"></param>
        /// <returns></returns>
        public async Task<FundInstructions_SettleResponse> SettleFundInstructionAsync(
            FundInstructions_Settle fundInstruction)
        {
            var request = GetRequest<FundInstructions_SettleRequest>();

            request.ActionTriggerDataEntity = fundInstruction;

            var response = await _client.FundInstruction_SettleAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion
    }
}