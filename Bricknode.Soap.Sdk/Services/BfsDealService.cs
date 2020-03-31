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

    public class BfsDealService : BfsServiceBase, IBfsDealService
    {
        private readonly bfsapiSoap _client;

        public BfsDealService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/163381390/GetDeals
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetDealsResponse> GetDealsAsync(GetDealsArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetDealsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetDealsFields>();

            var response = await GetClient(bfsApiClientName).GetDealsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}