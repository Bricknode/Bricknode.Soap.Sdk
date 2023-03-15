using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsTransactionService : BfsServiceBase, IBfsTransactionService
    {
        public BfsTransactionService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916910/GetBusinessTransactions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetBusinessTransactionsResponse> GetBusinessTransactionsAsync(
            GetBusinessTransactionArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetBusinessTransactionsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetBusinessTransactionFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetBusinessTransactionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916915/GetBusinessTransactionTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetBusinessTransactionTypeResponse> GetBusinessTransactionTypesAsync(
            GetBusinessTransactionTypeArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetBusinessTransactionTypeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetBusinessTransactionTypeFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetBusinessTransactionTypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031192/CreateBusinessTransaction
        /// </summary>
        /// <param name="superTransactions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateBusinessTransactionResponse> CreateBusinessTransactionsAsync(
            SuperTransaction[] superTransactions, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateBusinessTransactionRequest>(bfsApiClientName);

            request.Entities = superTransactions;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateBusinessTransactionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/393904155/CorrectBusinessTransactions
        /// </summary>
        /// <param name="correctionBusinessTransactions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CorrectBusinessTransactionsResponse> CorrectBusinessTransactionsAsync(
            CorrectionBusinessTransaction[] correctionBusinessTransactions, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CorrectBusinessTransactionRequest>(bfsApiClientName);

            request.Entities = correctionBusinessTransactions;

            request.Fields = GetFields<CorrectionBusinessTransactionFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CorrectBusinessTransactionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/2937782287/UpdateBusinessTransactions
        /// </summary>
        /// <param name="businessTransactions"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateBusinessTransactionsResponse> UpdateBusinessTransactionsAsync(UpdateBusinessTransaction[] businessTransactions, 
            UpdateBusinessTransactionFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateBusinessTransactionsRequest> (bfsApiClientName);

            request.Entities = businessTransactions;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateBusinessTransactionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}