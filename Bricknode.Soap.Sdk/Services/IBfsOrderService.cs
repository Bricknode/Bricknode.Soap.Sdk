using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsOrderService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58261877/GetOrderTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetOrderTypeResponse> GetOrderTypesAsync(GetOrderTypeArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002923/GetTradeOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetTradeOrdersResponse> GetTradeOrdersAsync(GetTradeOrdersArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002940/CreateTradeOrders
        /// </summary>
        /// <param name="tradeOrders"></param>
        /// <returns></returns>
        Task<CreateTradeOrderResponse> CreateTradeOrdersAsync(TradeOrder[] tradeOrders);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132543/GetExternalFundBatchOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetExternalFundBatchOrdersResponse> GetExternalFundBatchOrdersAsync(GetExternalFundBatchOrdersArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132533/ExternalFundBatchOrder+Settle
        /// </summary>
        /// <param name="fundBatchOrder"></param>
        /// <returns></returns>
        Task<ExternalFundBatchOrderSettleResponse> SettleExternalFundBatchOrdersAsync(ExternalFundBatchOrderSettle fundBatchOrder);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/81100944/GetWithdrawalTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetWithdrawalTransferOrdersResponse> GetWithdrawalTransferOrdersAsync(GetWithdrawalTransferOrdersArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132539/GetWithdrawalBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetWithdrawalBatchTransferOrdersResponse> GetWithdrawalBatchTransferOrdersAsync(GetWithdrawalBatchTransferOrdersArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/81100948/GetDepositTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetDepositTransferOrdersResponse> GetDepositTransferOrdersAsync(GetDepositTransferOrdersArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132537/GetDepositBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetDepositBatchTransferOrdersResponse> GetDepositBatchTransferOrdersAsync(GetDepositBatchTransferOrdersArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002942/CreateWithdrawalCashOrder
        /// </summary>
        /// <param name="withdrawalCashOrders"></param>
        /// <returns></returns>
        Task<CreateWithdrawalCashOrderResponse> CreateWithdrawalCashOrdersAsync(WithdrawalCashOrder[] withdrawalCashOrders);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002938/CreateDepositCashOrder
        /// </summary>
        /// <param name="depositCashOrders"></param>
        /// <returns></returns>
        Task<CreateDepositCashOrderResponse> CreateDepositCashOrdersAsync(DepositCashOrder[] depositCashOrders);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/636583995/CreateDirectBankWithdrawalOrders
        /// </summary>
        /// <param name="directBankWithdrawalOrders"></param>
        /// <returns></returns>
        Task<CreateDirectBankWithdrawalOrderResponse> CreateDirectBankWithdrawalOrdersAsync(DirectBankWithdrawalOrder[] directBankWithdrawalOrders);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/636452882/CreateAutoGiroWithdrawalOrders
        /// </summary>
        /// <param name="autoGiroWithdrawalOrders"></param>
        /// <returns></returns>
        Task<CreateAutoGiroWithdrawalOrderResponse> CreateAutoGiroWithdrawalOrderAsync(AutoGiroWithdrawalOrder[] autoGiroWithdrawalOrders);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132535/DepositCashBatchOrder+BatchFill
        /// </summary>
        /// <param name="depositCashBatchOrder"></param>
        /// <returns></returns>
        Task<DepositCashBatchOrder_BatchFillResponse> BatchFillDepositCashBatchOrder(DepositCashBatchOrder_BatchFill depositCashBatchOrder);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132541/WithdrawalCashBatchOrder+Fill
        /// </summary>
        /// <param name="withdrawalCashBatchOrderFill"></param>
        /// <returns></returns>
        Task<WithdrawalCashBatchOrder_FillResponse> BatchFillDepositCashBatchOrder(WithdrawalCashBatchOrder_Fill withdrawalCashBatchOrderFill);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/79790114/GetAllocationOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetAllocationOrderResponse> GetAllocationOrdesAsync(GetAllocationOrderArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031190/CreateAllocationOrders
        /// </summary>
        /// <param name="allocationOrders"></param>
        /// <returns></returns>
        Task<CreateAllocationOrdersResponse> CreateAllocationOrdersAsync(AllocationOrder[] allocationOrders);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/95846459/GetSubscriptionOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetSubscriptionOrderResponse> GetSubscriptionOrdersAsync(GetSubscriptionOrderArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152607031/CreateSubscriptionOrders
        /// </summary>
        /// <param name="subscriptionOrders"></param>
        /// <returns></returns>
        Task<CreateSubscriptionOrderResponse> CreateSubscriptionOrdersAsync(SubscriptionOrder[] subscriptionOrders);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152657456/UpdateSubscriptionOrders
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        Task<UpdateSubscriptionOrderResponse> UpdateSubscriptionOrdersAsync(UpdateSubscriptionOrder[] accounts, UpdateSubscriptionOrderFields fieldsToUpdate);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152608540/SubscriptionOrder+Cancel
        /// </summary>
        /// <param name="subscriptionOrderNumber"></param>
        /// <returns></returns>
        Task<SubscriptionOrder_CancelResponse> CancelSubscriptionOrder(SubscriptionOrder_Cancel subscriptionOrderNumber);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152608206/SubscriptionOrder+Process
        /// </summary>
        /// <param name="subscriptionOrderProcess"></param>
        /// <returns></returns>
        Task<SubscriptionOrder_ProcessResponse> ProcessSubscriptionOrder(SubscriptionOrder_Process subscriptionOrderProcess);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/227770418/GetRecurringOrderTemplates
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetRecurringOrderTemplatesResponse> GetRecurringOrderTemplatesAsync(GetRecurringOrderTemplatesArgs filters);
    }
}