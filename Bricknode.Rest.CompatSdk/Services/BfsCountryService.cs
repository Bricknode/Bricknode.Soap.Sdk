using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    /// <summary>
    /// REST-backed drop-in replacement for the SOAP <c>BfsCountryService</c>.
    /// Public surface is identical; internally it maps the SOAP-shaped <c>BfsApi.*</c> DTOs to the
    /// generated REST records (<see cref="BfsJsonMapper"/>) and calls the REST resource clients.
    /// </summary>
    public class BfsCountryService : BfsServiceBase, IBfsCountryService
    {
        public BfsCountryService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        public async Task<GetCountryResponse> GetCountries(GetCountryArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetCountryRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCountryFields>();

            var client = await GetClientAsync<RestApi.CountriesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetCountryRequest>(request));
            var response = BfsJsonMapper.Map<GetCountryResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}