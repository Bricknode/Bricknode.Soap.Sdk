using System;
using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsOrderService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/79790114/GetAllocationOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetAllocationOrderResponse> GetAllocationOrdersAsync(GetAllocationOrderArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031190/CreateSwitchOrders
        /// </summary>
        /// <param name="switchOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateSwitchOrdersResponse> CreateSwitchOrdersAsync(SwitchOrder[] switchOrders, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2352971801/GetFundBatchOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetFundBatchOrdersResponse> GetFundBatchOrdersAsync(GetFundBatchOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58261877/GetOrderTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetOrderTypeResponse> GetOrderTypesAsync(GetOrderTypeArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002923/GetTradeOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetTradeOrdersResponse> GetTradeOrdersAsync(GetTradeOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002940/CreateTradeOrders
        /// </summary>
        /// <param name="tradeOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateTradeOrderResponse> CreateTradeOrdersAsync(TradeOrder[] tradeOrders, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132543/GetExternalFundBatchOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetExternalFundBatchOrdersResponse> GetExternalFundBatchOrdersAsync(GetExternalFundBatchOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/3749871617/GetTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetTransferOrdersResponse> GetTransferOrdersAsync(GetTransferOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/81100944/GetWithdrawalTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetWithdrawalTransferOrdersResponse> GetWithdrawalTransferOrdersAsync(GetWithdrawalTransferOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132539/GetWithdrawalBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetWithdrawalBatchTransferOrdersResponse> GetWithdrawalBatchTransferOrdersAsync(GetWithdrawalBatchTransferOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/81100948/GetDepositTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetDepositTransferOrdersResponse> GetDepositTransferOrdersAsync(GetDepositTransferOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132537/GetDepositBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetDepositBatchTransferOrdersResponse> GetDepositBatchTransferOrdersAsync(GetDepositBatchTransferOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002942/CreateWithdrawalCashOrder
        /// </summary>
        /// <param name="withdrawalCashOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateWithdrawalCashOrderResponse> CreateWithdrawalCashOrdersAsync(WithdrawalCashOrder[] withdrawalCashOrders, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002938/CreateDepositCashOrder
        /// </summary>
        /// <param name="depositCashOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateDepositCashOrderResponse> CreateDepositCashOrdersAsync(DepositCashOrder[] depositCashOrders, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/636583995/CreateDirectBankWithdrawalOrders
        /// </summary>
        /// <param name="directBankWithdrawalOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateDirectBankWithdrawalOrderResponse> CreateDirectBankWithdrawalOrdersAsync(DirectBankWithdrawalOrder[] directBankWithdrawalOrders, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/3760062478/UpdateTransferOrderStates
        /// </summary>
        /// <param name="updateTransferOrderStates"></param>
        /// <param name="updateTransferOrderStatesFields"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateTransferOrderStatesResponse> UpdateTransferOrderStatesAsync(UpdateTransferOrderState[] updateTransferOrderStates, UpdateTransferOrderStatesFields updateTransferOrderStatesFields, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/636452882/CreateAutoGiroWithdrawalOrders
        /// </summary>
        /// <param name="autoGiroWithdrawalOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateAutoGiroWithdrawalOrderResponse> CreateAutoGiroWithdrawalOrderAsync(AutoGiroWithdrawalOrder[] autoGiroWithdrawalOrders, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132541/WithdrawalCashBatchOrder+Fill
        /// </summary>
        /// <param name="withdrawalCashBatchOrderFill"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<WithdrawalCashBatchOrder_FillResponse> BatchFillDepositCashBatchOrder(WithdrawalCashBatchOrder_Fill withdrawalCashBatchOrderFill, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/79790114/GetAllocationOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        [Obsolete("This method has been replaced by another method with slightly different name GetAllocationOrde(r)sAsync.")]
        Task<GetAllocationOrderResponse> GetAllocationOrdesAsync(GetAllocationOrderArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/95846459/GetSubscriptionOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetSubscriptionOrderResponse> GetSubscriptionOrdersAsync(GetSubscriptionOrderArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152607031/CreateSubscriptionOrders
        /// </summary>
        /// <param name="subscriptionOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateSubscriptionOrderResponse> CreateSubscriptionOrdersAsync(SubscriptionOrder[] subscriptionOrders, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152657456/UpdateSubscriptionOrders
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateSubscriptionOrderResponse> UpdateSubscriptionOrdersAsync(UpdateSubscriptionOrder[] accounts, UpdateSubscriptionOrderFields fieldsToUpdate, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152608540/SubscriptionOrder+Cancel
        /// </summary>
        /// <param name="subscriptionOrderNumber"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<SubscriptionOrder_CancelResponse> CancelSubscriptionOrder(SubscriptionOrder_Cancel subscriptionOrderNumber, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152608206/SubscriptionOrder+Process
        /// </summary>
        /// <param name="subscriptionOrderProcess"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<SubscriptionOrder_ProcessResponse> ProcessSubscriptionOrder(SubscriptionOrder_Process subscriptionOrderProcess, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/227770418/GetRecurringOrderTemplates
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetRecurringOrderTemplatesResponse> GetRecurringOrderTemplatesAsync(GetRecurringOrderTemplatesArgs filters, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/958922769/CreateRecurringOrderTemplatesAutogiro
        /// </summary>
        /// <param name="recurringOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateRecurringOrderTemplateAutoGiroResponse> CreateRecurringOrderTemplatesAutogiroAsync(
            RecurringOrderTemplateAutoGiro[] recurringOrders, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/958398610/UpdateRecurringOrderTemplateAutoGiro
        /// </summary>
        /// <param name="recurringOrders"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateRecurringOrderTemplateAutoGiroResponse> UpdateRecurringOrderTemplatesAutoGiroAsync(
            UpdateRecurringOrderTemplateAutoGiro[] recurringOrders,
            UpdateRecurringOrderTemplateAutoGiroFields fieldsToUpdate, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1183744113/CurrencyExchangeOrder+Cancel
        /// </summary>
        /// <param name="currencyExchangeOrders"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CurrencyExchangeOrder_CancelResponse> CancelCurrencyExchangeOrder(
            CurrencyExchangeOrder_Cancel currencyExchangeOrderNumber, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1184038966/GetCurrencyExchangeOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetCurrencyExchangeOrderResponse> GetCurrencyExchangeOrderAsync(
            GetCurrencyExchangeOrderArgs filters, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1184399365/CreateCurrencyExchangeOrders
        /// </summary>
        /// <param name="currencyExchangeOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateCurrencyExchangeOrderResponse> CreateCurrencyExchangeOrdersAsync(CurrencyExchangeOrder[] currencyExchangeOrders, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1757708308/GetInternalCashTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetInternalCashTransferOrderResponse> GetInternalCashTransferOrdersAsync(
            GetInternalCashTransferOrderArgs filters, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1755546006/CreateInternalCashTransferOrders
        /// </summary>
        /// <param name="internalCashTransferOrder"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateInternalCashTransferOrderResponse> CreateInternalCashTransferOrdersAsync(
            InternalCashTransferOrder[] internalCashTransferOrder, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1755513097/GetInternalInstrumentTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetInternalInstrumentTransferOrderResponse> GetInternalInstrumentTransferOrdersAsync(
            GetInternalInstrumentTransferOrderArgs filters, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1758461975/CreateInternalInstrumentTransferOrders
        /// </summary>
        /// <param name="internalInstrumentTransferOrder"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateInternalInstrumentTransferOrderResponse> CreateInternalInstrumentTransferOrdersAsync(
            InternalInstrumentTransferOrder[] internalInstrumentTransferOrder, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1757839430/ExecuteInternalTransferOrders
        /// </summary>
        /// <param name="internalTransferOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<string> ExecuteInternalTransferOrdersAsync(ExecuteInternalTransferOrder[] internalTransferOrders,
            string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1758265382/DeleteInternalTransferOrders
        /// </summary>
        /// <param name="internalTransferOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<string> DeleteInternalTransferOrdersAsync(DeleteInternalTransferOrder[] internalTransferOrders,
            string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1930133509/CancelTradeOrders
        /// </summary>
        /// <param name="tradeOrderIds"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CancelTradeOrderResponse> CancelTradeOrdersAsync(Guid[] tradeOrderIds,
            string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1951499222/GetAutoGiroOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetAutoGiroOrdersResponse> GetAutoGiroOrdersAsync(GetAutoGiroOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2183299109/CreateAutoGiroDepositOrders
        /// </summary>
        /// <param name="autoGiroDepositOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateAutoGiroDepositOrderResponse> CreateAutoGiroDepositOrdersAsync(
            AutoGiroDepositOrder[] autoGiroDepositOrders, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2507440145/CreateTradeBuyOrdersFromAutogiro
        /// </summary>
        /// <param name="tradeBuyOrdersFromAutogiro"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateTradeBuyOrdersFromAutogiroResponse> CreateTradeBuyOrdersFromAutogiroAsync(TradeBuyOrderFromAutogiro[] tradeBuyOrdersFromAutogiro, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/3948150878/GetAvtaleGiroOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetAvtaleGiroOrdersResponse> GetAvtaleGiroOrdersAsync(GetAvtaleGiroOrdersArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2714271827/ExecuteOrders
        /// </summary>
        /// <param name="orderExecutions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<ExecuteOrderResponse> ExecuteOrdersAsync(OrderExecuteBase[] orderExecutions, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2714304848/SettleOrders
        /// </summary>
        /// <param name="orderSettlements"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<SettleOrderResponse> SettleOrdersAsync(OrderSettleBase[] orderSettlements, string? bfsApiClientName = null);

        Task<CreateFundBatchOrdersResponse> CreateFundBatchOrdersAsync(CreateFundBatchOrdersBase createFundBatchOrdersBase, string? bfsApiClientName = null);
    }
}