using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsPriceService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/149133779/GetHistoricPrices
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetHistoricPricesResponse> GetHistoricPricesAsync(GetHistoricPricesArgs filters, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58261735/SetHistoricPrices
        /// </summary>
        /// <param name="priceDateEntries"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<SetHistoricPricesResponse> SetHistoricPricesAsync(PriceDateEntry[] priceDateEntries, string bfsApiClientName = null);
    }
}