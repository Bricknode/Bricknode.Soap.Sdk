using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsTrsService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/157581337/GetTRSCountries
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetTRSCountriesResponse> GetTrsCountriesAsync(GetTRSCountriesArgs filters, string? bfsApiClientName = null);
    }
}