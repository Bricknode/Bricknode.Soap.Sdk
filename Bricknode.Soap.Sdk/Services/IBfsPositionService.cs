using System.Collections.Generic;
using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsPositionService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002925/GetPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetPositionResponse> GetPositionsAsync(GetPositionArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002925/GetPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <param name="pageSize">Size of each page, supported range is 1 to 5000. The default size is 2000.</param>
        /// <param name="pageStartIndex">Index of the start page. Can be used to skip specific number of pages in enumeration.</param>
        /// <returns></returns>
        IAsyncEnumerable<GetPositionResponse> GetPositionsInPagesAsync(GetPositionArgs filters, int pageSize = 2000,
            int pageStartIndex = 0, string? bfsApiClientName = null);
        
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031196/GetHistoricPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetHistoricPositionResponse> GetHistoricPositionsAsync(GetHistoricPositionArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/437157974/GetHoldingsOverTime
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetHoldingsOverTimeResponse> GetHoldingsOverTimeAsync(GetHoldingsOverTimeArgs filters, string? bfsApiClientName = null);
    }
}