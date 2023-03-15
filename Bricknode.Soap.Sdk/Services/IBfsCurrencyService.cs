using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsCurrencyService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/56328392/GetCurrencies
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetCurrencyResponse> GetCurrenciesAsync(GetCurrencyArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/458817672/GetCurrencyValues
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetCurrencyValueResponse> GetCurrencyValuesAsync(GetCurrencyValuesArgs filters, string? bfsApiClientName = null);
    }
}