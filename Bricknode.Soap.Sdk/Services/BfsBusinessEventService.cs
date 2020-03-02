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

    public class BfsBusinessEventService : BfsServiceBase, IBfsBusinessEventService
    {
        private readonly bfsapiSoap _client;

        public BfsBusinessEventService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/171573292/GetBusinessEvents
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetBusinessEventResponse> GetBusinessEventsAsync(GetBusinessEventArgs filters)
        {
            var request = GetRequest<GetBusinessEventRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetBusinessEventFields>();

            var response = await _client.GetBusinessEventsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}