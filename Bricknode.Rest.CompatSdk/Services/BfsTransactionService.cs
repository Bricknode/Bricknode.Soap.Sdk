using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class BfsTransactionService : BfsServiceBase, IBfsTransactionService
    {
        public BfsTransactionService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
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

            var client = await GetClientAsync<RestApi.BusinessTransactionsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetBusinessTransactionsRequest>(request));
            var response = BfsJsonMapper.Map<GetBusinessTransactionsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        public async IAsyncEnumerable<GetBusinessTransactionsResponse> GetBusinessTransactionsInPagesAsync(
            GetBusinessTransactionArgs filters, int pageSize = 2000, int pageStartIndex = 0,  string? bfsApiClientName = null)
        {
            GetBusinessTransactionsResponse response;
            bool isValidResponse;
            var pageIndex = pageStartIndex;
            var client = await GetClientAsync<RestApi.BusinessTransactionsClient>(bfsApiClientName);
            var request = await GetRequestAsync<GetBusinessTransactionsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetBusinessTransactionFields>();
            request.EnablePagination = true;
            request.PageSize = pageSize;
            do
            {
                request.PageIndex = pageIndex++;
                var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetBusinessTransactionsRequest>(request));
                response = BfsJsonMapper.Map<GetBusinessTransactionsResponse>(restResponse)!;
                isValidResponse = ValidateResponse(response);
                if (isValidResponse)
                {
                    LogErrors(response.Result);
                }

                yield return response;
            } while (isValidResponse && response.Result.Length >= pageSize);
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

            var client = await GetClientAsync<RestApi.BusinessTransactionTypesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetBusinessTransactionTypeRequest>(request));
            var response = BfsJsonMapper.Map<GetBusinessTransactionTypeResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.BusinessTransactionsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateBusinessTransactionRequest>(request));
            var response = BfsJsonMapper.Map<CreateBusinessTransactionResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.BusinessTransactionsClient>(bfsApiClientName);
            var restResponse = await client.CorrectAsync(BfsJsonMapper.Map<RestApi.CorrectBusinessTransactionRequest>(request));
            var response = BfsJsonMapper.Map<CorrectBusinessTransactionsResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.BusinessTransactionsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateBusinessTransactionsRequest>(request));
            var response = BfsJsonMapper.Map<UpdateBusinessTransactionsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/3462824085/UpdateSuperTransactions
        /// </summary>
        /// <param name="superTransactions"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateSuperTransactionsResponse> UpdateSuperTransactionsAsync(UpdateSuperTransaction[] superTransactions,
            UpdateSuperTransactionFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateSuperTransactionsRequest>(bfsApiClientName);

            request.Entities = superTransactions;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync<RestApi.SuperTransactionsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateSuperTransactionsRequest>(request));
            var response = BfsJsonMapper.Map<UpdateSuperTransactionsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }


        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/3462758502/GetSuperTransactions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetSuperTransactionsResponse> GetSuperTransactionsAsync(
            GetSuperTransactionArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetSuperTransactionsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetSuperTransactionFields>();

            var client = await GetClientAsync<RestApi.SuperTransactionsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetSuperTransactionsRequest>(request));
            var response = BfsJsonMapper.Map<GetSuperTransactionsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        public async IAsyncEnumerable<GetSuperTransactionsResponse> GetSuperTransactionsInPagesAsync(
            GetSuperTransactionArgs filters, int pageSize = 2000, int pageStartIndex = 0, string? bfsApiClientName = null)
        {
            GetSuperTransactionsResponse response;
            bool isValidResponse;
            var pageIndex = pageStartIndex;
            var client = await GetClientAsync<RestApi.SuperTransactionsClient>(bfsApiClientName);
            var request = await GetRequestAsync<GetSuperTransactionsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetSuperTransactionFields>();
            request.EnablePagination = true;
            request.PageSize = pageSize;
            do
            {
                request.PageIndex = pageIndex++;
                var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetSuperTransactionsRequest>(request));
                response = BfsJsonMapper.Map<GetSuperTransactionsResponse>(restResponse)!;
                isValidResponse = ValidateResponse(response);
                if (isValidResponse)
                {
                    LogErrors(response.Result);
                }

                yield return response;
            } while (isValidResponse && response.Result.Length >= pageSize);
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/4242931723/GetRelatedFifoLots
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetRelatedFifoLotsResponse> GetRelatedFifoLots(GetRelatedFifoLotsArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetRelatedFifoLotsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetRelatedFifoLotsFields>();
            var client = await GetClientAsync<RestApi.RelatedFifoLotsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetRelatedFifoLotsRequest>(request));
            var response = BfsJsonMapper.Map<GetRelatedFifoLotsResponse>(restResponse)!;
            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);
            return response;

        }
    }
}