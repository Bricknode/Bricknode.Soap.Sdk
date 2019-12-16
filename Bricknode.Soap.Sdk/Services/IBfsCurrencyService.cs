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
        /// <returns></returns>
        Task<GetCurrencyResponse> GetCurrenciesAsync(GetCurrencyArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/458817672/GetCurrencyValues
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetCurrencyValueResponse> GetCurrencyValuesAsync(GetCurrencyValuesArgs filters);
    }
}