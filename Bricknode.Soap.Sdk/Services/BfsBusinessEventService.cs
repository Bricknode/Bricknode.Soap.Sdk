using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsBusinessEventService : BfsServiceBase, IBfsBusinessEventService
    {
        public BfsBusinessEventService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/171573292/GetBusinessEvents
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetBusinessEventResponse> GetBusinessEventsAsync(GetBusinessEventArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetBusinessEventRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetBusinessEventFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetBusinessEventsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}