using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsCountryService : BfsServiceBase, IBfsCountryService
    {
        private readonly bfsapiSoap _client;

        public BfsCountryService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            IBfsApiClientFactory bfsApiClientFactory, bfsapiSoap client) : base(bfsApiConfiguration, logger,
            bfsApiClientFactory, client)
        {
            _client = client;
        }

        public async Task<GetCountryResponse> GetCountries(GetCountryArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetCountryRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCountryFields>();

            var response = await GetClient(bfsApiClientName).GetCountriesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}