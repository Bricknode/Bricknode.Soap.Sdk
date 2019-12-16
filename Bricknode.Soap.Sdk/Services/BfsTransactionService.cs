using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsTransactionService : BfsServiceBase, IBfsTransactionService
    {
        private readonly bfsapiSoap _client;

        public BfsTransactionService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client) : base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916910/GetBusinessTransactions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetBusinessTransactionsResponse> GetBusinessTransactionsAsync(
            GetBusinessTransactionArgs filters)
        {
            var request = GetRequest<GetBusinessTransactionsRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetBusinessTransactionFields>();

            var response = await _client.GetBusinessTransactionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916915/GetBusinessTransactionTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetBusinessTransactionTypeResponse> GetBusinessTransactionTypesAsync(
            GetBusinessTransactionTypeArgs filters)
        {
            var request = GetRequest<GetBusinessTransactionTypeRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetBusinessTransactionTypeFields>();

            var response = await _client.GetBusinessTransactionTypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031192/CreateBusinessTransaction
        /// </summary>
        /// <param name="superTransactions"></param>
        /// <returns></returns>
        public async Task<CreateBusinessTransactionResponse> CreateBusinessTransactionsAsync(
            SuperTransaction[] superTransactions)
        {
            var request = GetRequest<CreateBusinessTransactionRequest>();

            request.Entities = superTransactions;

            var response = await _client.CreateBusinessTransactionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/393904155/CorrectBusinessTransactions
        /// </summary>
        /// <param name="correctionBusinessTransactions"></param>
        /// <returns></returns>
        public async Task<CorrectBusinessTransactionsResponse> CorrectBusinessTransactionsAsync(
            CorrectionBusinessTransaction[] correctionBusinessTransactions)
        {
            var request = GetRequest<CorrectBusinessTransactionRequest>();

            request.Entities = correctionBusinessTransactions;

            var response = await _client.CorrectBusinessTransactionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }
    }
}