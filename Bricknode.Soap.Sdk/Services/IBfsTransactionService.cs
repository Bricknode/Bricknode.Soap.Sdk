using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsTransactionService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58916910/GetBusinessTransactions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetBusinessTransactionsResponse> GetBusinessTransactionsAsync(GetBusinessTransactionArgs filters, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58916915/GetBusinessTransactionTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetBusinessTransactionTypeResponse> GetBusinessTransactionTypesAsync(GetBusinessTransactionTypeArgs filters, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031192/CreateBusinessTransaction
        /// </summary>
        /// <param name="superTransactions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateBusinessTransactionResponse> CreateBusinessTransactionsAsync(SuperTransaction[] superTransactions, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/393904155/CorrectBusinessTransactions
        /// </summary>
        /// <param name="correctionBusinessTransactions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CorrectBusinessTransactionsResponse> CorrectBusinessTransactionsAsync(
            CorrectionBusinessTransaction[] correctionBusinessTransactions, string bfsApiClientName = null);
    }
}