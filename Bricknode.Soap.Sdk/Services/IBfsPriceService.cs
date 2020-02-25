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
        /// <returns></returns>
        Task<GetHistoricPricesResponse> GetHistoricPricesAsync(GetHistoricPricesArgs filters);


        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58261735/SetHistoricPrices
        /// </summary>
        /// <param name="priceDateEntries"></param>
        /// <param name="clearAllPreviousData"></param>
        /// <param name="clearPreviousDataByRange"></param>
        /// <param name="updateCurrentPriceFromLastPrice"></param>
        /// <param name="clearAllsubsequentData"></param>
        /// <returns></returns>
        Task<SetHistoricPricesResponse> SetHistoricPricesAsync(PriceDateEntry[] priceDateEntries,
            bool clearAllPreviousData,
            bool clearPreviousDataByRange,
            bool updateCurrentPriceFromLastPrice,
            bool clearAllsubsequentData);
    }
}