using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsWebhookService : BfsServiceBase, IBfsWebhookService
    {
        public BfsWebhookService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711472878/GetAvailableWebhookEvents
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAvailableWebhookEventResponse> GetAvailableWebhookEventsAsync(GetAvailableWebhookEventArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAvailableWebhookEventRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAvailableWebhookEventFields>();

            var client = await GetClientAsync<RestApi.WebhookSubscriptionsClient>(bfsApiClientName);
            var restResponse = await client.GetEventsAsync(BfsJsonMapper.Map<RestApi.GetAvailableWebhookEventRequest>(request));
            var response = BfsJsonMapper.Map<GetAvailableWebhookEventResponse>(restResponse)!;

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
        public async Task<GetFailedWebhookResponse> GetFailedWebhooksAsync(GetFailedWebhookArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFailedWebhookRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFailedWebhookFields>();

            var client = await GetClientAsync<RestApi.WebhookSubscriptionsClient>(bfsApiClientName);
            var restResponse = await client.GetFailedAsync(BfsJsonMapper.Map<RestApi.GetFailedWebhookRequest>(request));
            var response = BfsJsonMapper.Map<GetFailedWebhookResponse>(restResponse)!;

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
        public async Task<GetWebhookSubscriptionResponse> GetWebhookSubscriptionsAsync(GetWebhookSubscriptionArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetWebhookSubscriptionRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetWebhookSubscriptionFields>();

            var client = await GetClientAsync<RestApi.WebhookSubscriptionsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetWebhookSubscriptionRequest>(request));
            var response = BfsJsonMapper.Map<GetWebhookSubscriptionResponse>(restResponse)!;

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
        public async Task<DeleteWebhookSubscriptionResponse> DeleteWebhookSubscriptionsAsync(DeleteWebhookSubscription[] webhookSubscriptions, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteWebhookSubscriptionRequest>(bfsApiClientName);

            request.Entities = webhookSubscriptions;

            var client = await GetClientAsync<RestApi.WebhookSubscriptionsClient>(bfsApiClientName);
            var restResponse = await client.DeleteAsync(BfsJsonMapper.Map<RestApi.DeleteWebhookSubscriptionRequest>(request));
            var response = BfsJsonMapper.Map<DeleteWebhookSubscriptionResponse>(restResponse)!;

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
        public async Task<CreateWebhookSubscriptionResponse> CreateWebhookSubscriptionsAsync(CreateWebhookSubscription[] webhookSubscriptions, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateWebhookSubscriptionRequest>(bfsApiClientName);

            request.Entities = webhookSubscriptions;

            var client = await GetClientAsync<RestApi.WebhookSubscriptionsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateWebhookSubscriptionRequest>(request));
            var response = BfsJsonMapper.Map<CreateWebhookSubscriptionResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}