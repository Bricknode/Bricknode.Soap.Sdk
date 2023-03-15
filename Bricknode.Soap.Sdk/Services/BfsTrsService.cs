using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsTrsService : BfsServiceBase, IBfsTrsService
    {
        public BfsTrsService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetTRSCountriesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}