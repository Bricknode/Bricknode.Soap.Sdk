﻿using System.Collections.Generic;
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
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002947/GetAccounts
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="fields"></param>
        /// <param name="pageSize">Size of each page, supported range is 1 to 5000. The default size is 2000.</param>
        /// <param name="pageStartIndex">Index of the start page. Can be used to skip specific number of pages in enumeration.</param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        IAsyncEnumerable<GetAccountsResponse> GetAccountsInPagesAsync(GetAccountsArgs filters, GetAccountFields? fields = null, int pageSize = 2000, int pageStartIndex = 0, string? bfsApiClientName = null);

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