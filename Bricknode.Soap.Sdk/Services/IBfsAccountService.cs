using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsAccountService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002947/GetAccounts
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetAccountsResponse> GetAccountsAsync(GetAccountsArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002947/GetAccounts
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="fields"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetAccountsResponse> GetAccountsAsync(GetAccountsArgs filters, GetAccountFields fields, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52003249/CreateAccounts
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateAccountResponse> CreateAccountsAsync(Account[] accounts, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58916926/UpdateAccounts
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateAccountsResponse> UpdateAccountsAsync(UpdateAccount[] accounts, UpdateAccountFields fieldsToUpdate, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58916901/GetAccountTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetAccountTypeResponse> GetAccountTypesAsync(GetAccountTypeArgs filters, string? bfsApiClientName = null);
    }
}