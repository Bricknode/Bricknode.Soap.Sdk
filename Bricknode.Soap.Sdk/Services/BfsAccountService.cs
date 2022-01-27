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

    public class BfsAccountService : BfsServiceBase, IBfsAccountService
    {
        private readonly bfsapiSoap _client;

        public BfsAccountService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002947/GetAccounts
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAccountsResponse> GetAccountsAsync(GetAccountsArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetAccountsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAccountFields>();

            var response = await GetClient(bfsApiClientName).GetAccountsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52003249/CreateAccounts
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAccountResponse> CreateAccountsAsync(Account[] accounts, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateAccountRequest>(bfsApiClientName);

            request.Entities = accounts;

            var response = await GetClient(bfsApiClientName).CreateAccountsAsync(request);

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
            UpdateAccountFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateAccountsRequest>(bfsApiClientName);

            request.Entities = accounts;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateAccountsAsync(request);

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
        public async Task<GetAccountTypeResponse> GetAccountTypesAsync(GetAccountTypeArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetAccountTypeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAccountTypeFields>();

            var response = await GetClient(bfsApiClientName).GetAccountTypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}