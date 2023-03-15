using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsDealService : BfsServiceBase, IBfsDealService
    {
        public BfsDealService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetDealsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}