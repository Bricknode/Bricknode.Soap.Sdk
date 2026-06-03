using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    /// <summary>
    /// REST-backed drop-in replacement for the SOAP <c>BfsTrsService</c>.
    /// Public surface is identical; internally it maps the SOAP-shaped <c>BfsApi.*</c> DTOs to the
    /// generated REST records (<see cref="BfsJsonMapper"/>) and calls the REST resource clients.
    /// </summary>
    public class BfsTrsService : BfsServiceBase, IBfsTrsService
    {
        public BfsTrsService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/157581337/GetTRSCountries
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTRSCountriesResponse> GetTrsCountriesAsync(GetTRSCountriesArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetTRSCountriesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTRSCountriesFields>();

            var client = await GetClientAsync<RestApi.TRSCountriesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetTRSCountriesRequest>(request));
            var response = BfsJsonMapper.Map<GetTRSCountriesResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}