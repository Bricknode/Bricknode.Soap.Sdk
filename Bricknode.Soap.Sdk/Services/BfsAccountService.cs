using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsAccountService : BfsServiceBase, IBfsAccountService
    {
        private readonly bfsapiSoap _client;

        public BfsAccountService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client) :
            base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002947/GetAccounts
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetAccountsResponse> GetAccountsAsync(GetAccountsArgs filters)
        {
            var request = GetRequest<GetAccountsRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetAccountFields>();

            var response = await _client.GetAccountsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52003249/CreateAccounts
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public async Task<CreateAccountResponse> CreateAccountsAsync(Account[] accounts)
        {
            var request = GetRequest<CreateAccountRequest>();

            request.Entities = accounts;

            var response = await _client.CreateAccountsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916926/UpdateAccounts
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdateAccountsResponse> UpdateAccountsAsync(UpdateAccount[] accounts,
            UpdateAccountFields fieldsToUpdate)
        {
            var request = GetRequest<UpdateAccountsRequest>();

            request.Entities = accounts;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdateAccountsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58916901/GetAccountTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetAccountTypeResponse> GetAccountTypesAsync(GetAccountTypeArgs filters)
        {
            var request = GetRequest<GetAccountTypeRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetAccountTypeFields>();

            var response = await _client.GetAccountTypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}