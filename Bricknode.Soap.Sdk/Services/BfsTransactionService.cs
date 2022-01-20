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

    public class BfsTransactionService : BfsServiceBase, IBfsTransactionService
    {
        private readonly bfsapiSoap _client;

        public BfsTransactionService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916910/GetBusinessTransactions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetBusinessTransactionsResponse> GetBusinessTransactionsAsync(
            GetBusinessTransactionArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetBusinessTransactionsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetBusinessTransactionFields>();

            var response = await GetClient(bfsApiClientName).GetBusinessTransactionsAsync(request);

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
            GetBusinessTransactionTypeArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetBusinessTransactionTypeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetBusinessTransactionTypeFields>();

            var response = await GetClient(bfsApiClientName).GetBusinessTransactionTypesAsync(request);

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
            SuperTransaction[] superTransactions, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateBusinessTransactionRequest>(bfsApiClientName);

            request.Entities = superTransactions;

            var response = await GetClient(bfsApiClientName).CreateBusinessTransactionsAsync(request);

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
            CorrectionBusinessTransaction[] correctionBusinessTransactions, string bfsApiClientName = null)
        {
            var request = GetRequest<CorrectBusinessTransactionRequest>(bfsApiClientName);

            request.Entities = correctionBusinessTransactions;

            var response = await GetClient(bfsApiClientName).CorrectBusinessTransactionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}