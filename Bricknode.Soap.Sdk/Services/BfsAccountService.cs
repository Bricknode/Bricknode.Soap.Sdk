using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using System.Collections.Generic;
    using Factories;

    public class BfsAccountService : BfsServiceBase, IBfsAccountService
    {
        public BfsAccountService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002947/GetAccounts
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAccountsResponse> GetAccountsAsync(GetAccountsArgs filters, string? bfsApiClientName = null)
        {
            var fields = GetFields<GetAccountFields>();
            return await GetAccountsAsync(filters, fields, bfsApiClientName);
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002947/GetAccounts
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="fields"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAccountsResponse> GetAccountsAsync(GetAccountsArgs filters, GetAccountFields fields, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAccountsRequest>(bfsApiClientName);

            request.Args = filters;
            request.Fields = fields;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetAccountsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        public async IAsyncEnumerable<GetAccountsResponse> GetAccountsInPagesAsync(GetAccountsArgs filters, GetAccountFields? fields = null, int pageSize = 2000, string? bfsApiClientName = null)
        {
            GetAccountsResponse response;
            bool isValidResponse;
            var pageIndex = 0;
            var client = await GetClientAsync(bfsApiClientName);
            var request = await GetRequestAsync<GetAccountsRequest>(bfsApiClientName);

            request.Args = filters;
            request.Fields = fields ?? GetFields<GetAccountFields>();
            request.EnablePagination = true;
            request.PageSize = pageSize;

            do
            {
                request.PageIndex = pageIndex++;
                response = await client.GetAccountsAsync(request);
                isValidResponse = ValidateResponse(response);

                if (!isValidResponse)
                {
                    LogErrors(response.Result);
                }

                yield return response;

            } while (isValidResponse && response.Result.Length >= pageSize);
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52003249/CreateAccounts
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAccountResponse> CreateAccountsAsync(Account[] accounts, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateAccountRequest>(bfsApiClientName);

            request.Entities = accounts;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateAccountsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916926/UpdateAccounts
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateAccountsResponse> UpdateAccountsAsync(UpdateAccount[] accounts,
            UpdateAccountFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateAccountsRequest>(bfsApiClientName);

            request.Entities = accounts;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateAccountsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916901/GetAccountTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAccountTypeResponse> GetAccountTypesAsync(GetAccountTypeArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAccountTypeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAccountTypeFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetAccountTypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}