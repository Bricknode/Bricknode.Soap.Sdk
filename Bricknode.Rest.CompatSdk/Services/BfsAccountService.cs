using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using System.Collections.Generic;
    using Factories;

    /// <summary>
    /// REST-backed drop-in replacement for the SOAP <c>BfsAccountService</c>.
    /// Public surface is identical; internally it maps the SOAP-shaped <c>BfsApi.*</c> DTOs to the
    /// generated REST records (<see cref="BfsJsonMapper"/>) and calls the REST resource clients.
    /// </summary>
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
        public async Task<GetAccountsResponse> GetAccountsAsync(GetAccountsArgs filters, string? bfsApiClientName = null)
        {
            var fields = GetFields<GetAccountFields>();
            return await GetAccountsAsync(filters, fields, bfsApiClientName);
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002947/GetAccounts
        /// </summary>
        public async Task<GetAccountsResponse> GetAccountsAsync(GetAccountsArgs filters, GetAccountFields fields, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAccountsRequest>(bfsApiClientName);

            request.Args = filters;
            request.Fields = fields;

            var client = await GetClientAsync<RestApi.AccountsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetAccountsRequest>(request));
            var response = BfsJsonMapper.Map<GetAccountsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        public async IAsyncEnumerable<GetAccountsResponse> GetAccountsInPagesAsync(GetAccountsArgs filters, GetAccountFields? fields = null, int pageSize = 2000, int pageStartIndex = 0, string? bfsApiClientName = null)
        {
            GetAccountsResponse response;
            bool isValidResponse;
            var pageIndex = pageStartIndex;
            var client = await GetClientAsync<RestApi.AccountsClient>(bfsApiClientName);
            var request = await GetRequestAsync<GetAccountsRequest>(bfsApiClientName);

            request.Args = filters;
            request.Fields = fields ?? GetFields<GetAccountFields>();
            request.EnablePagination = true;
            request.PageSize = pageSize;

            do
            {
                request.PageIndex = pageIndex++;
                var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetAccountsRequest>(request));
                response = BfsJsonMapper.Map<GetAccountsResponse>(restResponse)!;
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
        public async Task<CreateAccountResponse> CreateAccountsAsync(Account[] accounts, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateAccountRequest>(bfsApiClientName);

            request.Entities = accounts;

            var client = await GetClientAsync<RestApi.AccountsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateAccountRequest>(request));
            var response = BfsJsonMapper.Map<CreateAccountResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916926/UpdateAccounts
        /// </summary>
        public async Task<UpdateAccountsResponse> UpdateAccountsAsync(UpdateAccount[] accounts,
            UpdateAccountFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateAccountsRequest>(bfsApiClientName);

            request.Entities = accounts;
            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync<RestApi.AccountsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateAccountsRequest>(request));
            var response = BfsJsonMapper.Map<UpdateAccountsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916901/GetAccountTypes
        /// </summary>
        public async Task<GetAccountTypeResponse> GetAccountTypesAsync(GetAccountTypeArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAccountTypeRequest>(bfsApiClientName);

            request.Args = filters;
            request.Fields = GetFields<GetAccountTypeFields>();

            var client = await GetClientAsync<RestApi.AccountTypesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetAccountTypeRequest>(request));
            var response = BfsJsonMapper.Map<GetAccountTypeResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}
