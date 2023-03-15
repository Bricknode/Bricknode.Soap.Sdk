using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsDealService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/163381390/GetDeals
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetDealsResponse> GetDealsAsync(GetDealsArgs filters, string? bfsApiClientName = null);
    }
}