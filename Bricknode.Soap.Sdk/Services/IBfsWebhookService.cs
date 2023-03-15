using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsWebhookService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711472878/GetAvailableWebhookEvents
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetAvailableWebhookEventResponse> GetAvailableWebhookEventsAsync(GetAvailableWebhookEventArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711833274/GetFailedWebhooks
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetFailedWebhookResponse> GetFailedWebhooksAsync(GetFailedWebhookArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711833289/GetWebhookSubscriptions
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetWebhookSubscriptionResponse> GetWebhookSubscriptionsAsync(GetWebhookSubscriptionArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1708360352/DeleteWebhookSubscriptions
        /// </summary>
        /// <param name="webhookSubscriptions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<DeleteWebhookSubscriptionResponse> DeleteWebhookSubscriptionsAsync(DeleteWebhookSubscription[] webhookSubscriptions, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1711472815/CreateWebhookSubscriptions
        /// </summary>
        /// <param name="webhookSubscriptions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateWebhookSubscriptionResponse> CreateWebhookSubscriptionsAsync(CreateWebhookSubscription[] webhookSubscriptions, string? bfsApiClientName = null);
    }
}