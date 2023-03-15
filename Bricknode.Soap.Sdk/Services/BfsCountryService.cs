using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsCountryService : BfsServiceBase, IBfsCountryService
    {
        public BfsCountryService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        public async Task<GetCountryResponse> GetCountries(GetCountryArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetCountryRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCountryFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetCountriesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}