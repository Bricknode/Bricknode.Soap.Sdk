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
    /// REST-backed drop-in replacement for the SOAP <c>BfsDealService</c>.
    /// Public surface is identical; internally it maps the SOAP-shaped <c>BfsApi.*</c> DTOs to the
    /// generated REST records (<see cref="BfsJsonMapper"/>) and calls the REST resource clients.
    /// </summary>
    public class BfsDealService : BfsServiceBase, IBfsDealService
    {
        public BfsDealService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/163381390/GetDeals
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetDealsResponse> GetDealsAsync(GetDealsArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetDealsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetDealsFields>();

            var client = await GetClientAsync<RestApi.DealsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetDealsRequest>(request));
            var response = BfsJsonMapper.Map<GetDealsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}