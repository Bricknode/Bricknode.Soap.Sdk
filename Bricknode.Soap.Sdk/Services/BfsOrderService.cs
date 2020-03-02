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
        private readonly bfsapiSoap _client;

        public BfsOrderService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58261877/GetOrderTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetOrderTypeResponse> GetOrderTypesAsync(GetOrderTypeArgs filters)
        {
            var request = GetRequest<GetOrderTypeRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetOrderTypeFields>();

            var response = await _client.GetOrderTypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        #region RecurringOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/227770418/GetRecurringOrderTemplates
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetRecurringOrderTemplatesResponse> GetRecurringOrderTemplatesAsync(
            GetRecurringOrderTemplatesArgs filters)
        {
            var request = GetRequest<GetRecurringOrderTemplatesRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetRecurringOrderTemplatesFields>();

            var response = await _client.GetRecurringOrderTemplatesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region TradeOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002923/GetTradeOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetTradeOrdersResponse> GetTradeOrdersAsync(GetTradeOrdersArgs filters)
        {
            var request = GetRequest<GetTradeOrdersRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetTradeOrderFields>();

            var response = await _client.GetTradeOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002940/CreateTradeOrders
        /// </summary>
        /// <param name="tradeOrders"></param>
        /// <returns></returns>
        public async Task<CreateTradeOrderResponse> CreateTradeOrdersAsync(TradeOrder[] tradeOrders)
        {
            var request = GetRequest<CreateTradeOrderRequest>();

            request.Entities = tradeOrders;

            var response = await _client.CreateTradeOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132543/GetExternalFundBatchOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetExternalFundBatchOrdersResponse> GetExternalFundBatchOrdersAsync(
            GetExternalFundBatchOrdersArgs filters)
        {
            var request = GetRequest<GetExternalFundBatchOrdersRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetExternalFundBatchOrderFields>();

            var response = await _client.GetExternalFundBatchOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132533/ExternalFundBatchOrder+Settle
        /// </summary>
        /// <param name="fundBatchOrder"></param>
        /// <returns></returns>
        public async Task<ExternalFundBatchOrderSettleResponse> SettleExternalFundBatchOrdersAsync(
            ExternalFundBatchOrderSettle fundBatchOrder)
        {
            var request = GetRequest<ExternalFundBatchOrderSettleRequest>();

            request.WorkflowTriggerDataEntity = fundBatchOrder;

            var response = await _client.ExternalFundBatchOrder_SettleAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion

        #region TransferOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/81100944/GetWithdrawalTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetWithdrawalTransferOrdersResponse> GetWithdrawalTransferOrdersAsync(
            GetWithdrawalTransferOrdersArgs filters)
        {
            var request = GetRequest<GetWithdrawalTransferOrdersRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetWithdrawalTransferOrdersFields>();

            var response = await _client.GetWithdrawalTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132539/GetWithdrawalBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetWithdrawalBatchTransferOrdersResponse> GetWithdrawalBatchTransferOrdersAsync(
            GetWithdrawalBatchTransferOrdersArgs filters)
        {
            var request = GetRequest<GetWithdrawalBatchTransferOrdersRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetWithdrawalBatchTransferOrdersFields>();

            var response = await _client.GetWithdrawalBatchTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/81100948/GetDepositTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetDepositTransferOrdersResponse> GetDepositTransferOrdersAsync(
            GetDepositTransferOrdersArgs filters)
        {
            var request = GetRequest<GetDepositTransferOrdersRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetDepositTransferOrdersFields>();

            var response = await _client.GetDepositTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132537/GetDepositBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetDepositBatchTransferOrdersResponse> GetDepositBatchTransferOrdersAsync(
            GetDepositBatchTransferOrdersArgs filters)
        {
            var request = GetRequest<GetDepositBatchTransferOrdersRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetDepositBatchTransferOrdersFields>();

            var response = await _client.GetDepositBatchTransferOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002942/CreateWithdrawalCashOrder
        /// </summary>
        /// <param name="withdrawalCashOrders"></param>
        /// <returns></returns>
        public async Task<CreateWithdrawalCashOrderResponse> CreateWithdrawalCashOrdersAsync(
            WithdrawalCashOrder[] withdrawalCashOrders)
        {
            var request = GetRequest<CreateWithdrawalCashOrderRequest>();

            request.Entities = withdrawalCashOrders;

            var response = await _client.CreateWithdrawalCashOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002938/CreateDepositCashOrder
        /// </summary>
        /// <param name="depositCashOrders"></param>
        /// <returns></returns>
        public async Task<CreateDepositCashOrderResponse> CreateDepositCashOrdersAsync(
            DepositCashOrder[] depositCashOrders)
        {
            var request = GetRequest<CreateDepositCashOrderRequest>();

            request.Entities = depositCashOrders;

            var response = await _client.CreateDepositCashOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/636583995/CreateDirectBankWithdrawalOrders
        /// </summary>
        /// <param name="directBankWithdrawalOrders"></param>
        /// <returns></returns>
        public async Task<CreateDirectBankWithdrawalOrderResponse> CreateDirectBankWithdrawalOrdersAsync(
            DirectBankWithdrawalOrder[] directBankWithdrawalOrders)
        {
            var request = GetRequest<CreateDirectBankWithdrawalOrderRequest>();

            request.Entities = directBankWithdrawalOrders;

            var response = await _client.CreateDirectBankWithdrawalOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/636452882/CreateAutoGiroWithdrawalOrders
        /// </summary>
        /// <param name="autoGiroWithdrawalOrders"></param>
        /// <returns></returns>
        public async Task<CreateAutoGiroWithdrawalOrderResponse> CreateAutoGiroWithdrawalOrderAsync(
            AutoGiroWithdrawalOrder[] autoGiroWithdrawalOrders)
        {
            var request = GetRequest<CreateAutoGiroWithdrawalOrderRequest>();

            request.Entities = autoGiroWithdrawalOrders;

            var response = await _client.CreateAutoGiroWithdrawalOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region TransferOrders Transitions

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132535/DepositCashBatchOrder+BatchFill
        /// </summary>
        /// <param name="depositCashBatchOrder"></param>
        /// <returns></returns>
        public async Task<DepositCashBatchOrder_BatchFillResponse> BatchFillDepositCashBatchOrder(
            DepositCashBatchOrder_BatchFill depositCashBatchOrder)
        {
            var request = GetRequest<DepositCashBatchOrder_BatchFillRequest>();

            request.WorkflowTriggerDataEntity = depositCashBatchOrder;

            var response = await _client.DepositCashBatchOrder_BatchFillAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132541/WithdrawalCashBatchOrder+Fill
        /// </summary>
        /// <param name="withdrawalCashBatchOrderFill"></param>
        /// <returns></returns>
        public async Task<WithdrawalCashBatchOrder_FillResponse> BatchFillDepositCashBatchOrder(
            WithdrawalCashBatchOrder_Fill withdrawalCashBatchOrderFill)
        {
            var request = GetRequest<WithdrawalCashBatchOrder_FillRequest>();

            request.WorkflowTriggerDataEntity = withdrawalCashBatchOrderFill;

            var response = await _client.WithdrawalCashBatchOrder_FillAsync(request);

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
        /// <returns></returns>
        public async Task<GetAllocationOrderResponse> GetAllocationOrdesAsync(GetAllocationOrderArgs filters)
        {
            var request = GetRequest<GetAllocationOrderRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetAllocationOrderFields>();

            var response = await _client.GetAllocationOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031190/CreateAllocationOrders
        /// </summary>
        /// <param name="allocationOrders"></param>
        /// <returns></returns>
        public async Task<CreateAllocationOrdersResponse> CreateAllocationOrdersAsync(
            AllocationOrder[] allocationOrders)
        {
            var request = GetRequest<CreateAllocationOrdersRequest>();

            request.Entities = allocationOrders;

            var response = await _client.CreateAllocationOrdersAsync(request);

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
        /// <returns></returns>
        public async Task<GetSubscriptionOrderResponse> GetSubscriptionOrdersAsync(GetSubscriptionOrderArgs filters)
        {
            var request = GetRequest<GetSubscriptionOrderRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetSubscriptionOrderFields>();

            var response = await _client.GetSubscriptionOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152607031/CreateSubscriptionOrders
        /// </summary>
        /// <param name="subscriptionOrders"></param>
        /// <returns></returns>
        public async Task<CreateSubscriptionOrderResponse> CreateSubscriptionOrdersAsync(
            SubscriptionOrder[] subscriptionOrders)
        {
            var request = GetRequest<CreateSubscriptionOrderRequest>();

            request.Entities = subscriptionOrders;

            var response = await _client.CreateSubscriptionOrdersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152657456/UpdateSubscriptionOrders
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdateSubscriptionOrderResponse> UpdateSubscriptionOrdersAsync(
            UpdateSubscriptionOrder[] accounts, UpdateSubscriptionOrderFields fieldsToUpdate)
        {
            var request = GetRequest<UpdateSubscriptionOrderRequest>();

            request.Entities = accounts;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdateSubscriptionOrdersAsync(request);

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
        /// <returns></returns>
        public async Task<SubscriptionOrder_CancelResponse> CancelSubscriptionOrder(
            SubscriptionOrder_Cancel subscriptionOrderNumber)
        {
            var request = GetRequest<SubscriptionOrder_CancelRequest>();

            request.WorkflowTriggerDataEntity = subscriptionOrderNumber;

            var response = await _client.SubscriptionOrder_CancelAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152608206/SubscriptionOrder+Process
        /// </summary>
        /// <param name="subscriptionOrderProcess"></param>
        /// <returns></returns>
        public async Task<SubscriptionOrder_ProcessResponse> ProcessSubscriptionOrder(
            SubscriptionOrder_Process subscriptionOrderProcess)
        {
            var request = GetRequest<SubscriptionOrder_ProcessRequest>();

            request.WorkflowTriggerDataEntity = subscriptionOrderProcess;

            var response = await _client.SubscriptionOrder_ProcessAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion
    }
}