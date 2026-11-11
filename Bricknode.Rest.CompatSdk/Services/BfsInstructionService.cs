using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsInstructionService : BfsServiceBase, IBfsInstructionService
    {
        public BfsInstructionService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        #region Fund Instructions

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132947/GetFundInstructions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFundInstructionResponse> GetFundInstructionsAsync(GetFundInstructionArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFundInstructionRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFundInstructionFields>();

            var client = await GetClientAsync<RestApi.FundInstructionsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetFundInstructionRequest>(request));
            var response = BfsJsonMapper.Map<GetFundInstructionResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/147881428/GetFundInstructionStatusLogs
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFundInstructionStatusLogResponse> GetFundInstructionStatusLogsAsync(
            GetFundInstructionStatusLogArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFundInstructionStatusLogRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFundInstructionStatusLogFields>();

            var client = await GetClientAsync<RestApi.FundInstructionsClient>(bfsApiClientName);
            var restResponse = await client.GetStatusLogsAsync(BfsJsonMapper.Map<RestApi.GetFundInstructionStatusLogRequest>(request));
            var response = BfsJsonMapper.Map<GetFundInstructionStatusLogResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/147881601/GetFundInstructionExecutions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFundInstructionExecutionResponse> GetFundInstructionExecutionsAsync(
            GetFundInstructionExecutionArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFundInstructionExecutionRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFundInstructionExecutionFields>();

            var client = await GetClientAsync<RestApi.FundInstructionsClient>(bfsApiClientName);
            var restResponse = await client.GetExecutionsAsync(BfsJsonMapper.Map<RestApi.GetFundInstructionExecutionRequest>(request));
            var response = BfsJsonMapper.Map<GetFundInstructionExecutionResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132952/FundInstructions+Settle
        /// </summary>
        /// <param name="fundInstruction"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<FundInstructions_SettleResponse> SettleFundInstructionAsync(
            FundInstructions_Settle fundInstruction, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<FundInstructions_SettleRequest>(bfsApiClientName);

            request.ActionTriggerDataEntity = fundInstruction;

            var client = await GetClientAsync<RestApi.ActionsClient>(bfsApiClientName);
            var restResponse = await client.SettleFundInstructionAsync(BfsJsonMapper.Map<RestApi.FundInstructions_SettleRequest>(request));
            var response = BfsJsonMapper.Map<FundInstructions_SettleResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion
    }
}