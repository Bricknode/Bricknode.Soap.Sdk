using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsCountryService
    {
        Task<GetCountryResponse> GetCountries(GetCountryArgs filters, string? bfsApiClientName = null);
    }
}