using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsInstructionService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132947/GetFundInstructions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetFundInstructionResponse> GetFundInstructionsAsync(GetFundInstructionArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/147881428/GetFundInstructionStatusLogs
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetFundInstructionStatusLogResponse> GetFundInstructionStatusLogsAsync(GetFundInstructionStatusLogArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/147881601/GetFundInstructionExecutions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetFundInstructionExecutionResponse> GetFundInstructionExecutionsAsync(GetFundInstructionExecutionArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132952/FundInstructions+Settle
        /// </summary>
        /// <param name="fundInstruction"></param>
        /// <returns></returns>
        Task<FundInstructions_SettleResponse> SettleFundInstructionAsync(FundInstructions_Settle fundInstruction);
    }
}