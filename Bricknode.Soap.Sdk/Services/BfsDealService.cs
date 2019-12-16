using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsDealService : BfsServiceBase, IBfsDealService
    {
        private readonly bfsapiSoap _client;

        public BfsDealService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client) :
            base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/163381390/GetDeals
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetDealsResponse> GetDealsAsync(GetDealsArgs filters)
        {
            var request = GetRequest<GetDealsRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetDealsFields>();

            var response = await _client.GetDealsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}