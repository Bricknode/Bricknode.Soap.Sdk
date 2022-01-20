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

    public class BfsWebhookService : BfsServiceBase, IBfsWebhookService
    {
        private readonly bfsapiSoap _client;

        public BfsWebhookService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711472878/GetAvailableWebhookEvents
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAvailableWebhookEventResponse> GetAvailableWebhookEventsAsync(GetAvailableWebhookEventArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetAvailableWebhookEventRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAvailableWebhookEventFields>();

            var response = await GetClient(bfsApiClientName).GetAvailableWebhookEventsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711833274/GetFailedWebhooks
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFailedWebhookResponse> GetFailedWebhooksAsync(GetFailedWebhookArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetFailedWebhookRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFailedWebhookFields>();

            var response = await GetClient(bfsApiClientName).GetFailedWebhooksAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711833289/GetWebhookSubscriptions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetWebhookSubscriptionResponse> GetWebhookSubscriptionsAsync(GetWebhookSubscriptionArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetWebhookSubscriptionRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetWebhookSubscriptionFields>();

            var response = await GetClient(bfsApiClientName).GetWebhookSubscriptionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1708360352/DeleteWebhookSubscriptions
        /// </summary>
        /// <param name="webhookSubscriptions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<DeleteWebhookSubscriptionResponse> DeleteWebhookSubscriptionsAsync(DeleteWebhookSubscription[] webhookSubscriptions, string bfsApiClientName = null)
        {
            var request = GetRequest<DeleteWebhookSubscriptionRequest>(bfsApiClientName);

            request.Entities = webhookSubscriptions;

            var response = await GetClient(bfsApiClientName).DeleteWebhookSubscriptionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;  
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711472815/CreateWebhookSubscriptions
        /// </summary>
        /// <param name="webhookSubscriptions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateWebhookSubscriptionResponse> CreateWebhookSubscriptionsAsync(CreateWebhookSubscription[] webhookSubscriptions, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateWebhookSubscriptionRequest>(bfsApiClientName);

            request.Entities = webhookSubscriptions;

            var response = await GetClient(bfsApiClientName).CreateWebhookSubscriptionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}