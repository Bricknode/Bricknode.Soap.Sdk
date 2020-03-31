using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsTrsService : BfsServiceBase, IBfsTrsService
    {
        private readonly bfsapiSoap _client;

        public BfsTrsService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/157581337/GetTRSCountries
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTRSCountriesResponse> GetTrsCountriesAsync(GetTRSCountriesArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetTRSCountriesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTRSCountriesFields>();

            var response = await GetClient(bfsApiClientName).GetTRSCountriesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}