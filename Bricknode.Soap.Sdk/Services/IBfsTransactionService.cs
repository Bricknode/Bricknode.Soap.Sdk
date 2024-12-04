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
        Task<GetBusinessTransactionsResponse> GetBusinessTransactionsAsync(GetBusinessTransactionArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58916915/GetBusinessTransactionTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetBusinessTransactionTypeResponse> GetBusinessTransactionTypesAsync(GetBusinessTransactionTypeArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031192/CreateBusinessTransaction
        /// </summary>
        /// <param name="superTransactions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateBusinessTransactionResponse> CreateBusinessTransactionsAsync(SuperTransaction[] superTransactions, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/393904155/CorrectBusinessTransactions
        /// </summary>
        /// <param name="correctionBusinessTransactions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CorrectBusinessTransactionsResponse> CorrectBusinessTransactionsAsync(
            CorrectionBusinessTransaction[] correctionBusinessTransactions, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2937782287/UpdateBusinessTransactions
        /// </summary>
        /// <param name="businessTransactions"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateBusinessTransactionsResponse> UpdateBusinessTransactionsAsync(UpdateBusinessTransaction[] businessTransactions,
            UpdateBusinessTransactionFields fieldsToUpdate, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/3462824085/UpdateSuperTransactions
        /// </summary>
        /// <param name="superTransactions"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateSuperTransactionsResponse> UpdateSuperTransactionsAsync(UpdateSuperTransaction[] superTransactions,
            UpdateSuperTransactionFields fieldsToUpdate, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/3462758502/GetSuperTransactions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetSuperTransactionsResponse> GetSuperTransactionsAsync(
            GetSuperTransactionArgs filters, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/4242931723/GetRelatedFifoLots
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetRelatedFifoLotsResponse> GetRelatedFifoLots(GetRelatedFifoLotsArgs filters, string? bfsApiClientName = null);
    }
}