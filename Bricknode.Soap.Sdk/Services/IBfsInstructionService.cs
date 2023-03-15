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
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetFundInstructionResponse> GetFundInstructionsAsync(GetFundInstructionArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/147881428/GetFundInstructionStatusLogs
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetFundInstructionStatusLogResponse> GetFundInstructionStatusLogsAsync(GetFundInstructionStatusLogArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/147881601/GetFundInstructionExecutions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetFundInstructionExecutionResponse> GetFundInstructionExecutionsAsync(GetFundInstructionExecutionArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132952/FundInstructions+Settle
        /// </summary>
        /// <param name="fundInstruction"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<FundInstructions_SettleResponse> SettleFundInstructionAsync(FundInstructions_Settle fundInstruction, string? bfsApiClientName = null);
    }
}