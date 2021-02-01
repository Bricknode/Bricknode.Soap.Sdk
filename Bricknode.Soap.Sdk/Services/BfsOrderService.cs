using System;
using System.Collections.Generic;
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

    public class BfsOrderService : BfsServiceBase, IBfsOrderService
    {

        public BfsOrderService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58261877/GetOrderTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetOrderTypeResponse> GetOrderTypesAsync(GetOrderTypeArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetOrderTypeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetOrderTypeFields>();

            var response = await GetClient(bfsApiClientName).GetOrderTypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        #region RecurringOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/227770418/GetRecurringOrderTemplates
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetRecurringOrderTemplatesResponse> GetRecurringOrderTemplatesAsync(
            GetRecurringOrderTemplatesArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetRecurringOrderTemplatesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetRecurringOrderTemplatesFields>();

            var response = await GetClient(bfsApiClientName).GetRecurringOrderTemplatesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/958922769/CreateRecurringOrderTemplatesAutogiro
        /// </summary>
        /// <param name="recurringOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateRecurringOrderTemplateAutoGiroResponse> CreateRecurringOrderTemplatesAutogiroAsync(RecurringOrderTemplateAutoGiro[] recurringOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateRecurringOrderTemplateAutoGiroRequest>(bfsApiClientName);

            request.Entities = recurringOrders;

            var response = await GetClient(bfsApiClientName).CreateRecurringOrderTemplatesAutogiroAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/958398610/UpdateRecurringOrderTemplateAutoGiro
        /// </summary>
        /// <param name="recurringOrders"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateRecurringOrderTemplateAutoGiroResponse> UpdateRecurringOrderTemplatesAutoGiroAsync(UpdateRecurringOrderTemplateAutoGiro[] recurringOrders,
            UpdateRecurringOrderTemplateAutoGiroFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateRecurringOrderTemplateAutoGiroRequest>(bfsApiClientName);

            request.Entities = recurringOrders;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateRecurringOrderTemplateAutoGiroAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region TradeOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002923/GetTradeOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTradeOrdersResponse> GetTradeOrdersAsync(GetTradeOrdersArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetTradeOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTradeOrderFields>();

            var response = await GetClient(bfsApiClientName).GetTradeOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002940/CreateTradeOrders
        /// </summary>
        /// <param name="tradeOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateTradeOrderResponse> CreateTradeOrdersAsync(TradeOrder[] tradeOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateTradeOrderRequest>(bfsApiClientName);

            request.Entities = tradeOrders;

            var response = await GetClient(bfsApiClientName).CreateTradeOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132543/GetExternalFundBatchOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetExternalFundBatchOrdersResponse> GetExternalFundBatchOrdersAsync(
            GetExternalFundBatchOrdersArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetExternalFundBatchOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetExternalFundBatchOrderFields>();

            var response = await GetClient(bfsApiClientName).GetExternalFundBatchOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132533/ExternalFundBatchOrder+Settle
        /// </summary>
        /// <param name="fundBatchOrder"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<ExternalFundBatchOrderSettleResponse> SettleExternalFundBatchOrdersAsync(
            ExternalFundBatchOrderSettle fundBatchOrder, string bfsApiClientName = null)
        {
            var request = GetRequest<ExternalFundBatchOrderSettleRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = fundBatchOrder;

            var response = await GetClient(bfsApiClientName).ExternalFundBatchOrder_SettleAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1930133509/CancelTradeOrders
        /// </summary>
        /// <param name="tradeOrderIds"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CancelTradeOrderResponse> CancelTradeOrdersAsync(Guid[] tradeOrderIds,
            string bfsApiClientName = null)
        {
            var request = GetRequest<CancelTradeOrderRequest>(bfsApiClientName);

            var listOfCancelTradeOrder = new List<CancelTradeOrder>();

            foreach (var tradeOrderId in tradeOrderIds)
            {
                listOfCancelTradeOrder.Add(new CancelTradeOrder
                {
                    OrderId = tradeOrderId
                });
            }

            request.Entities = listOfCancelTradeOrder.ToArray();

            var response = await GetClient(bfsApiClientName).CancelTradeOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion

        #region AutogiroOrders

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1951499222/GetAutoGiroOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAutoGiroOrdersResponse> GetAutoGiroOrdersAsync(GetAutoGiroOrdersArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetAutoGiroOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAutoGiroOrdersFields>();

            var response = await GetClient(bfsApiClientName).GetAutoGiroOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region TransferOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/81100944/GetWithdrawalTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetWithdrawalTransferOrdersResponse> GetWithdrawalTransferOrdersAsync(
            GetWithdrawalTransferOrdersArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetWithdrawalTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetWithdrawalTransferOrdersFields>();

            var response = await GetClient(bfsApiClientName).GetWithdrawalTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132539/GetWithdrawalBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetWithdrawalBatchTransferOrdersResponse> GetWithdrawalBatchTransferOrdersAsync(
            GetWithdrawalBatchTransferOrdersArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetWithdrawalBatchTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetWithdrawalBatchTransferOrdersFields>();

            var response = await GetClient(bfsApiClientName).GetWithdrawalBatchTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/81100948/GetDepositTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetDepositTransferOrdersResponse> GetDepositTransferOrdersAsync(
            GetDepositTransferOrdersArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetDepositTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetDepositTransferOrdersFields>();

            var response = await GetClient(bfsApiClientName).GetDepositTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132537/GetDepositBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetDepositBatchTransferOrdersResponse> GetDepositBatchTransferOrdersAsync(
            GetDepositBatchTransferOrdersArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetDepositBatchTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetDepositBatchTransferOrdersFields>();

            var response = await GetClient(bfsApiClientName).GetDepositBatchTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002942/CreateWithdrawalCashOrder
        /// </summary>
        /// <param name="withdrawalCashOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateWithdrawalCashOrderResponse> CreateWithdrawalCashOrdersAsync(
            WithdrawalCashOrder[] withdrawalCashOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateWithdrawalCashOrderRequest>(bfsApiClientName);

            request.Entities = withdrawalCashOrders;

            var response = await GetClient(bfsApiClientName).CreateWithdrawalCashOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002938/CreateDepositCashOrder
        /// </summary>
        /// <param name="depositCashOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateDepositCashOrderResponse> CreateDepositCashOrdersAsync(
            DepositCashOrder[] depositCashOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateDepositCashOrderRequest>(bfsApiClientName);

            request.Entities = depositCashOrders;

            var response = await GetClient(bfsApiClientName).CreateDepositCashOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/636583995/CreateDirectBankWithdrawalOrders
        /// </summary>
        /// <param name="directBankWithdrawalOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateDirectBankWithdrawalOrderResponse> CreateDirectBankWithdrawalOrdersAsync(
            DirectBankWithdrawalOrder[] directBankWithdrawalOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateDirectBankWithdrawalOrderRequest>(bfsApiClientName);

            request.Entities = directBankWithdrawalOrders;

            var response = await GetClient(bfsApiClientName).CreateDirectBankWithdrawalOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/636452882/CreateAutoGiroWithdrawalOrders
        /// </summary>
        /// <param name="autoGiroWithdrawalOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAutoGiroWithdrawalOrderResponse> CreateAutoGiroWithdrawalOrderAsync(
            AutoGiroWithdrawalOrder[] autoGiroWithdrawalOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateAutoGiroWithdrawalOrderRequest>(bfsApiClientName);

            request.Entities = autoGiroWithdrawalOrders;

            var response = await GetClient(bfsApiClientName).CreateAutoGiroWithdrawalOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region CurrencyExchangeOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1184038966/GetCurrencyExchangeOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetCurrencyExchangeOrderResponse> GetCurrencyExchangeOrderAsync(
            GetCurrencyExchangeOrderArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetCurrencyExchangeOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCurrencyExchangeOrderFields>();

            var response = await GetClient(bfsApiClientName).GetCurrencyExchangeOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }


        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1184399365/CreateCurrencyExchangeOrders
        /// </summary>
        /// <param name="currencyExchangeOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateCurrencyExchangeOrderResponse> CreateCurrencyExchangeOrdersAsync(CurrencyExchangeOrder[] currencyExchangeOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateCurrencyExchangeOrderRequest>(bfsApiClientName);

            request.Entities = currencyExchangeOrders;

            var response = await GetClient(bfsApiClientName).CreateCurrencyExchangeOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }
        
        #endregion
        
        #region CurrencyExchangeOrders Transitions

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1183744113/CurrencyExchangeOrder+Cancel
        /// </summary>
        /// <param name="currencyExchangeOrders"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CurrencyExchangeOrder_CancelResponse> CancelCurrencyExchangeOrder(
            CurrencyExchangeOrder_Cancel currencyExchangeOrderNumber, string bfsApiClientName = null)
        {
            var request = GetRequest<CurrencyExchangeOrder_CancelRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = currencyExchangeOrderNumber;

            var response = await GetClient(bfsApiClientName).CurrencyExchangeOrder_CancelAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion

        #region TransferOrders Transitions

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132535/DepositCashBatchOrder+BatchFill
        /// </summary>
        /// <param name="depositCashBatchOrder"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<DepositCashBatchOrder_BatchFillResponse> BatchFillDepositCashBatchOrder(
            DepositCashBatchOrder_BatchFill depositCashBatchOrder, string bfsApiClientName = null)
        {
            var request = GetRequest<DepositCashBatchOrder_BatchFillRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = depositCashBatchOrder;

            var response = await GetClient(bfsApiClientName).DepositCashBatchOrder_BatchFillAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132541/WithdrawalCashBatchOrder+Fill
        /// </summary>
        /// <param name="withdrawalCashBatchOrderFill"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<WithdrawalCashBatchOrder_FillResponse> BatchFillDepositCashBatchOrder(
            WithdrawalCashBatchOrder_Fill withdrawalCashBatchOrderFill, string bfsApiClientName = null)
        {
            var request = GetRequest<WithdrawalCashBatchOrder_FillRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = withdrawalCashBatchOrderFill;

            var response = await GetClient(bfsApiClientName).WithdrawalCashBatchOrder_FillAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion

        #region AllocationOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/79790114/GetAllocationOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAllocationOrderResponse> GetAllocationOrdesAsync(GetAllocationOrderArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetAllocationOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAllocationOrderFields>();

            var response = await GetClient(bfsApiClientName).GetAllocationOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031190/CreateAllocationOrders
        /// </summary>
        /// <param name="allocationOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAllocationOrdersResponse> CreateAllocationOrdersAsync(
            AllocationOrder[] allocationOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateAllocationOrdersRequest>(bfsApiClientName);

            request.Entities = allocationOrders;

            var response = await GetClient(bfsApiClientName).CreateAllocationOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region SubscriptionOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/95846459/GetSubscriptionOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetSubscriptionOrderResponse> GetSubscriptionOrdersAsync(GetSubscriptionOrderArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetSubscriptionOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetSubscriptionOrderFields>();

            var response = await GetClient(bfsApiClientName).GetSubscriptionOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152607031/CreateSubscriptionOrders
        /// </summary>
        /// <param name="subscriptionOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateSubscriptionOrderResponse> CreateSubscriptionOrdersAsync(
            SubscriptionOrder[] subscriptionOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateSubscriptionOrderRequest>(bfsApiClientName);

            request.Entities = subscriptionOrders;

            var response = await GetClient(bfsApiClientName).CreateSubscriptionOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152657456/UpdateSubscriptionOrders
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateSubscriptionOrderResponse> UpdateSubscriptionOrdersAsync(
            UpdateSubscriptionOrder[] accounts, UpdateSubscriptionOrderFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateSubscriptionOrderRequest>(bfsApiClientName);

            request.Entities = accounts;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateSubscriptionOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region SubscriptionOrder Transitions

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152608540/SubscriptionOrder+Cancel
        /// </summary>
        /// <param name="subscriptionOrderNumber"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<SubscriptionOrder_CancelResponse> CancelSubscriptionOrder(
            SubscriptionOrder_Cancel subscriptionOrderNumber, string bfsApiClientName = null)
        {
            var request = GetRequest<SubscriptionOrder_CancelRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = subscriptionOrderNumber;

            var response = await GetClient(bfsApiClientName).SubscriptionOrder_CancelAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152608206/SubscriptionOrder+Process
        /// </summary>
        /// <param name="subscriptionOrderProcess"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<SubscriptionOrder_ProcessResponse> ProcessSubscriptionOrder(
            SubscriptionOrder_Process subscriptionOrderProcess, string bfsApiClientName = null)
        {
            var request = GetRequest<SubscriptionOrder_ProcessRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = subscriptionOrderProcess;

            var response = await GetClient(bfsApiClientName).SubscriptionOrder_ProcessAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion

        #region InternalCashTransferOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1757708308/GetInternalCashTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInternalCashTransferOrderResponse> GetInternalCashTransferOrdersAsync(GetInternalCashTransferOrderArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetInternalCashTransferOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInternalCashTransferOrderFields>();

            var response = await GetClient(bfsApiClientName).GetInternalCashTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1755546006/CreateInternalCashTransferOrders
        /// </summary>
        /// <param name="internalCashTransferOrder"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInternalCashTransferOrderResponse> CreateInternalCashTransferOrdersAsync(InternalCashTransferOrder[] internalCashTransferOrder, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateInternalCashTransferOrderRequest>(bfsApiClientName);

            request.Entities = internalCashTransferOrder;

            var response = await GetClient(bfsApiClientName).CreateInternalCashTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }
        #endregion

        #region InternalInstrumentTransferOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1755513097/GetInternalInstrumentTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInternalInstrumentTransferOrderResponse> GetInternalInstrumentTransferOrdersAsync(GetInternalInstrumentTransferOrderArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetInternalInstrumentTransferOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInternalInstrumentTransferOrderFields>();

            var response = await GetClient(bfsApiClientName).GetInternalInstrumentTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1758461975/CreateInternalInstrumentTransferOrders
        /// </summary>
        /// <param name="internalInstrumentTransferOrder"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInternalInstrumentTransferOrderResponse> CreateInternalInstrumentTransferOrdersAsync(InternalInstrumentTransferOrder[] internalInstrumentTransferOrder, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateInternalInstrumentTransferOrderRequest>(bfsApiClientName);

            request.Entities = internalInstrumentTransferOrder;

            var response = await GetClient(bfsApiClientName).CreateInternalInstrumentTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }
        #endregion

        #region InternalTransferOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1757839430/ExecuteInternalTransferOrders
        /// </summary>
        /// <param name="internalTransferOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<string> ExecuteInternalTransferOrdersAsync(ExecuteInternalTransferOrder[] internalTransferOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<ExecuteInternalTransferOrderRequest>(bfsApiClientName);

            request.Entities = internalTransferOrders;

            var response = await GetClient(bfsApiClientName).ExecuteInternalTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response.Message;

            LogErrors(response.Message);

            return response.Message;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1758265382/DeleteInternalTransferOrders
        /// </summary>
        /// <param name="internalTransferOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<string> DeleteInternalTransferOrdersAsync(DeleteInternalTransferOrder[] internalTransferOrders, string bfsApiClientName = null)
        {
            var request = GetRequest<DeleteInternalTransferOrderRequest>(bfsApiClientName);

            request.Entities = internalTransferOrders;

            var response = await GetClient(bfsApiClientName).DeleteInternalTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response.Message;

            LogErrors(response.Message);

            return response.Message;
        }
        #endregion
    }
}