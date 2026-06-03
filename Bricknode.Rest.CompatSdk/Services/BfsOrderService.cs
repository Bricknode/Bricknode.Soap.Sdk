using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsOrderService : BfsServiceBase, IBfsOrderService
    {

        public BfsOrderService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58261877/GetOrderTypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetOrderTypeResponse> GetOrderTypesAsync(GetOrderTypeArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetOrderTypeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetOrderTypeFields>();

            var client = await GetClientAsync<RestApi.OrderTypesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetOrderTypeRequest>(request));
            var response = BfsJsonMapper.Map<GetOrderTypeResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

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
            GetRecurringOrderTemplatesArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetRecurringOrderTemplatesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetRecurringOrderTemplatesFields>();

            var client = await GetClientAsync<RestApi.RecurringOrderTemplatesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetRecurringOrderTemplatesRequest>(request));
            var response = BfsJsonMapper.Map<GetRecurringOrderTemplatesResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/958922769/CreateRecurringOrderTemplatesAutogiro
        /// </summary>
        /// <param name="recurringOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateRecurringOrderTemplateAutoGiroResponse> CreateRecurringOrderTemplatesAutogiroAsync(RecurringOrderTemplateAutoGiro[] recurringOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateRecurringOrderTemplateAutoGiroRequest>(bfsApiClientName);

            request.Entities = recurringOrders;

            var client = await GetClientAsync<RestApi.RecurringOrderTemplatesClient>(bfsApiClientName);
            var restResponse = await client.CreateAutoGiroAsync(BfsJsonMapper.Map<RestApi.CreateRecurringOrderTemplateAutoGiroRequest>(request));
            var response = BfsJsonMapper.Map<CreateRecurringOrderTemplateAutoGiroResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
            UpdateRecurringOrderTemplateAutoGiroFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateRecurringOrderTemplateAutoGiroRequest>(bfsApiClientName);

            request.Entities = recurringOrders;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync<RestApi.RecurringOrderTemplatesClient>(bfsApiClientName);
            var restResponse = await client.UpdateAutoGiroAsync(BfsJsonMapper.Map<RestApi.UpdateRecurringOrderTemplateAutoGiroRequest>(request));
            var response = BfsJsonMapper.Map<UpdateRecurringOrderTemplateAutoGiroResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion

        #region TradeOrders

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2352971801/GetFundBatchOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFundBatchOrdersResponse> GetFundBatchOrdersAsync(
            GetFundBatchOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFundBatchOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFundBatchOrderFields>();

            var client = await GetClientAsync<RestApi.FundBatchOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetFundBatchOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetFundBatchOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002923/GetTradeOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTradeOrdersResponse> GetTradeOrdersAsync(GetTradeOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetTradeOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTradeOrderFields>();

            var client = await GetClientAsync<RestApi.TradeOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetTradeOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetTradeOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002940/CreateTradeOrders
        /// </summary>
        /// <param name="tradeOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateTradeOrderResponse> CreateTradeOrdersAsync(TradeOrder[] tradeOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateTradeOrderRequest>(bfsApiClientName);

            request.Entities = tradeOrders;

            var client = await GetClientAsync<RestApi.TradeOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateTradeOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateTradeOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132543/GetExternalFundBatchOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetExternalFundBatchOrdersResponse> GetExternalFundBatchOrdersAsync(
            GetExternalFundBatchOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetExternalFundBatchOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetExternalFundBatchOrderFields>();

            var client = await GetClientAsync<RestApi.FundBatchOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchExternalAsync(BfsJsonMapper.Map<RestApi.GetExternalFundBatchOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetExternalFundBatchOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1930133509/CancelTradeOrders
        /// </summary>
        /// <param name="tradeOrderIds"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CancelTradeOrderResponse> CancelTradeOrdersAsync(Guid[] tradeOrderIds,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CancelTradeOrderRequest>(bfsApiClientName);

            var listOfCancelTradeOrder = new List<CancelTradeOrder>();

            foreach (var tradeOrderId in tradeOrderIds)
            {
                listOfCancelTradeOrder.Add(new CancelTradeOrder
                {
                    OrderId = tradeOrderId
                });
            }

            request.Entities = listOfCancelTradeOrder.ToArray();

            var client = await GetClientAsync<RestApi.TradeOrdersClient>(bfsApiClientName);
            var restResponse = await client.CancelAsync(BfsJsonMapper.Map<RestApi.CancelTradeOrderRequest>(request));
            var response = BfsJsonMapper.Map<CancelTradeOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1930133509/CancelTradeOrders
        /// </summary>
        public async Task<CancelTradeOrderResponse> CancelTradeOrdersAsync(CancelTradeOrder[] orders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CancelTradeOrderRequest>(bfsApiClientName);

            request.Entities = orders;

            var client = await GetClientAsync<RestApi.TradeOrdersClient>(bfsApiClientName);
            var restResponse = await client.CancelAsync(BfsJsonMapper.Map<RestApi.CancelTradeOrderRequest>(request));
            var response = BfsJsonMapper.Map<CancelTradeOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2507440145/CreateTradeBuyOrdersFromAutogiro
        /// </summary>
        /// <param name="tradeBuyOrdersFromAutogiro"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateTradeBuyOrdersFromAutogiroResponse> CreateTradeBuyOrdersFromAutogiroAsync(TradeBuyOrderFromAutogiro[] tradeBuyOrdersFromAutogiro, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateTradeBuyOrdersFromAutogiroRequest>(bfsApiClientName);

            request.Entities = tradeBuyOrdersFromAutogiro;

            var client = await GetClientAsync<RestApi.TradeOrdersFromDepositsClient>(bfsApiClientName);
            var restResponse = await client.CreateFromAutogiroAsync(BfsJsonMapper.Map<RestApi.CreateTradeBuyOrdersFromAutogiroRequest>(request));
            var response = BfsJsonMapper.Map<CreateTradeBuyOrdersFromAutogiroResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2801500161/CreateFundBatchOrders
        /// </summary>
        /// <param name="createFundBatchOrdersBase"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateFundBatchOrdersResponse> CreateFundBatchOrdersAsync(CreateFundBatchOrdersBase createFundBatchOrdersBase, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateFundBatchOrdersRequest>(bfsApiClientName);

            request.Entity = createFundBatchOrdersBase;

            var client = await GetClientAsync<RestApi.FundBatchOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateFundBatchOrdersRequest>(request));
            var response = BfsJsonMapper.Map<CreateFundBatchOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
        public async Task<GetAutoGiroOrdersResponse> GetAutoGiroOrdersAsync(GetAutoGiroOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAutoGiroOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAutoGiroOrdersFields>();

            var client = await GetClientAsync<RestApi.AutogiroOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetAutoGiroOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetAutoGiroOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/636452882/CreateAutoGiroWithdrawalOrders
        /// </summary>
        /// <param name="autoGiroWithdrawalOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAutoGiroWithdrawalOrderResponse> CreateAutoGiroWithdrawalOrderAsync(
            AutoGiroWithdrawalOrder[] autoGiroWithdrawalOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateAutoGiroWithdrawalOrderRequest>(bfsApiClientName);

            request.Entities = autoGiroWithdrawalOrders;

            var client = await GetClientAsync<RestApi.AutoGiroWithdrawalOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateAutoGiroWithdrawalOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateAutoGiroWithdrawalOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2183299109/CreateAutoGiroDepositOrders
        /// </summary>
        /// <param name="autoGiroDepositOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAutoGiroDepositOrderResponse> CreateAutoGiroDepositOrdersAsync(
            AutoGiroDepositOrder[] autoGiroDepositOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateAutoGiroDepositOrderRequest>(bfsApiClientName);

            request.Entities = autoGiroDepositOrders;

            var client = await GetClientAsync<RestApi.AutoGiroDepositOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateAutoGiroDepositOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateAutoGiroDepositOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/3744595969/CancelAutoGiroOrders
        /// </summary>
        public async Task<CancelAutoGiroOrderResponse> CancelAutoGiroOrdersAsync(Guid[] orderIds, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CancelAutoGiroOrderRequest>(bfsApiClientName);

            var listOfCancelOrders = new List<CancelAutoGiroOrder>();

            foreach (var orderId in orderIds)
            {
                listOfCancelOrders.Add(new CancelAutoGiroOrder
                {
                    OrderId = orderId
                });
            }

            request.Entities = listOfCancelOrders.ToArray();

            var client = await GetClientAsync<RestApi.AutogiroOrdersClient>(bfsApiClientName);
            var restResponse = await client.CancelAsync(BfsJsonMapper.Map<RestApi.CancelAutoGiroOrderRequest>(request));
            var response = BfsJsonMapper.Map<CancelAutoGiroOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/3744595969/CancelAutoGiroOrders
        /// </summary>
        public async Task<CancelAutoGiroOrderResponse> CancelAutoGiroOrdersAsync(CancelAutoGiroOrder[] orders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CancelAutoGiroOrderRequest>(bfsApiClientName);

            request.Entities = orders;

            var client = await GetClientAsync<RestApi.AutogiroOrdersClient>(bfsApiClientName);
            var restResponse = await client.CancelAsync(BfsJsonMapper.Map<RestApi.CancelAutoGiroOrderRequest>(request));
            var response = BfsJsonMapper.Map<CancelAutoGiroOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion

        #region AvtaleGiro

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/3948150878/GetAvtaleGiroOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAvtaleGiroOrdersResponse> GetAvtaleGiroOrdersAsync(GetAvtaleGiroOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAvtaleGiroOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAvtaleGiroOrdersFields>();

            var client = await GetClientAsync<RestApi.AvtalegiroOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetAvtaleGiroOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetAvtaleGiroOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        #endregion

        #region TransferOrders

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/3749871617/GetTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTransferOrdersResponse> GetTransferOrdersAsync(
            GetTransferOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTransferOrdersFields>();

            var client = await GetClientAsync<RestApi.TransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetTransferOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetTransferOrdersResponse>(restResponse)!;

            if (ValidateResponse(response))
                return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/81100944/GetWithdrawalTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetWithdrawalTransferOrdersResponse> GetWithdrawalTransferOrdersAsync(
            GetWithdrawalTransferOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetWithdrawalTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetWithdrawalTransferOrdersFields>();

            var client = await GetClientAsync<RestApi.WithdrawalTransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetWithdrawalTransferOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetWithdrawalTransferOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132539/GetWithdrawalBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetWithdrawalBatchTransferOrdersResponse> GetWithdrawalBatchTransferOrdersAsync(
            GetWithdrawalBatchTransferOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetWithdrawalBatchTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetWithdrawalBatchTransferOrdersFields>();

            var client = await GetClientAsync<RestApi.WithdrawalTransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchBatchAsync(BfsJsonMapper.Map<RestApi.GetWithdrawalBatchTransferOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetWithdrawalBatchTransferOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/81100948/GetDepositTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetDepositTransferOrdersResponse> GetDepositTransferOrdersAsync(
            GetDepositTransferOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetDepositTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetDepositTransferOrdersFields>();

            var client = await GetClientAsync<RestApi.DepositTransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetDepositTransferOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetDepositTransferOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132537/GetDepositBatchTransferOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetDepositBatchTransferOrdersResponse> GetDepositBatchTransferOrdersAsync(
            GetDepositBatchTransferOrdersArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetDepositBatchTransferOrdersRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetDepositBatchTransferOrdersFields>();

            var client = await GetClientAsync<RestApi.DepositTransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchBatchAsync(BfsJsonMapper.Map<RestApi.GetDepositBatchTransferOrdersRequest>(request));
            var response = BfsJsonMapper.Map<GetDepositBatchTransferOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002942/CreateWithdrawalCashOrder
        /// </summary>
        /// <param name="withdrawalCashOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateWithdrawalCashOrderResponse> CreateWithdrawalCashOrdersAsync(
            WithdrawalCashOrder[] withdrawalCashOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateWithdrawalCashOrderRequest>(bfsApiClientName);

            request.Entities = withdrawalCashOrders;

            var client = await GetClientAsync<RestApi.WithdrawalCashOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateWithdrawalCashOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateWithdrawalCashOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002938/CreateDepositCashOrder
        /// </summary>
        /// <param name="depositCashOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateDepositCashOrderResponse> CreateDepositCashOrdersAsync(
            DepositCashOrder[] depositCashOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateDepositCashOrderRequest>(bfsApiClientName);

            request.Entities = depositCashOrders;

            var client = await GetClientAsync<RestApi.DepositCashOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateDepositCashOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateDepositCashOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/636583995/CreateDirectBankWithdrawalOrders
        /// </summary>
        /// <param name="directBankWithdrawalOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateDirectBankWithdrawalOrderResponse> CreateDirectBankWithdrawalOrdersAsync(
            DirectBankWithdrawalOrder[] directBankWithdrawalOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateDirectBankWithdrawalOrderRequest>(bfsApiClientName);

            request.Entities = directBankWithdrawalOrders;

            var client = await GetClientAsync<RestApi.DirectBankWithdrawalClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateDirectBankWithdrawalOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateDirectBankWithdrawalOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/3760062478/UpdateTransferOrderStates
        /// </summary>
        /// <param name="updateTransferOrderStates"></param>
        /// <param name="updateTransferOrderStatesFields"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateTransferOrderStatesResponse> UpdateTransferOrderStatesAsync(UpdateTransferOrderState[] updateTransferOrderStates, UpdateTransferOrderStatesFields updateTransferOrderStatesFields, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateTransferOrderStatesRequest>(bfsApiClientName);

            request.Entities = updateTransferOrderStates;
            request.Fields = updateTransferOrderStatesFields;

            var client = await GetClientAsync<RestApi.TransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.UpdateStatesAsync(BfsJsonMapper.Map<RestApi.UpdateTransferOrderStatesRequest>(request));
            var response = BfsJsonMapper.Map<UpdateTransferOrderStatesResponse>(restResponse)!;

            if (ValidateResponse(response))
                return response;

            LogErrors(response.Entities);

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
            GetCurrencyExchangeOrderArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetCurrencyExchangeOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCurrencyExchangeOrderFields>();

            var client = await GetClientAsync<RestApi.CurrencyExchangeOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetCurrencyExchangeOrderRequest>(request));
            var response = BfsJsonMapper.Map<GetCurrencyExchangeOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }


        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1184399365/CreateCurrencyExchangeOrders
        /// </summary>
        /// <param name="currencyExchangeOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateCurrencyExchangeOrderResponse> CreateCurrencyExchangeOrdersAsync(CurrencyExchangeOrder[] currencyExchangeOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateCurrencyExchangeOrderRequest>(bfsApiClientName);

            request.Entities = currencyExchangeOrders;

            var client = await GetClientAsync<RestApi.CurrencyExchangeOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateCurrencyExchangeOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateCurrencyExchangeOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
            CurrencyExchangeOrder_Cancel currencyExchangeOrderNumber, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CurrencyExchangeOrder_CancelRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = currencyExchangeOrderNumber;

            var client = await GetClientAsync<RestApi.CurrencyExchangeOrdersClient>(bfsApiClientName);
            var restResponse = await client.CancelAsync(BfsJsonMapper.Map<RestApi.CurrencyExchangeOrder_CancelRequest>(request));
            var response = BfsJsonMapper.Map<CurrencyExchangeOrder_CancelResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        #endregion

        #region TransferOrders Transitions

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132541/WithdrawalCashBatchOrder+Fill
        /// </summary>
        /// <param name="withdrawalCashBatchOrderFill"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<WithdrawalCashBatchOrder_FillResponse> BatchFillDepositCashBatchOrder(
            WithdrawalCashBatchOrder_Fill withdrawalCashBatchOrderFill, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<WithdrawalCashBatchOrder_FillRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = withdrawalCashBatchOrderFill;

            var client = await GetClientAsync<RestApi.WithdrawalCashOrdersClient>(bfsApiClientName);
            var restResponse = await client.BatchFillAsync(BfsJsonMapper.Map<RestApi.WithdrawalCashBatchOrder_FillRequest>(request));
            var response = BfsJsonMapper.Map<WithdrawalCashBatchOrder_FillResponse>(restResponse)!;

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
        public async Task<GetAllocationOrderResponse> GetAllocationOrdersAsync(GetAllocationOrderArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAllocationOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAllocationOrderFields>();

            var client = await GetClientAsync<RestApi.AllocationOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetAllocationOrderRequest>(request));
            var response = BfsJsonMapper.Map<GetAllocationOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/79790114/GetAllocationOrders
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        [Obsolete("This method has been replaced by another method with slightly different name GetAllocationOrde(r)sAsync.")]
        public async Task<GetAllocationOrderResponse> GetAllocationOrdesAsync(GetAllocationOrderArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAllocationOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAllocationOrderFields>();

            var client = await GetClientAsync<RestApi.AllocationOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetAllocationOrderRequest>(request));
            var response = BfsJsonMapper.Map<GetAllocationOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031190/CreateSwitchOrders
        /// </summary>
        /// <param name="switchOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateSwitchOrdersResponse> CreateSwitchOrdersAsync(
            SwitchOrder[] switchOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateSwitchOrdersRequest>(bfsApiClientName);

            request.Entities = switchOrders;

            var client = await GetClientAsync<RestApi.AllocationOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateSwitchAsync(BfsJsonMapper.Map<RestApi.CreateSwitchOrdersRequest>(request));
            var response = BfsJsonMapper.Map<CreateSwitchOrdersResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
        public async Task<GetSubscriptionOrderResponse> GetSubscriptionOrdersAsync(GetSubscriptionOrderArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetSubscriptionOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetSubscriptionOrderFields>();

            var client = await GetClientAsync<RestApi.SubscriptionOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetSubscriptionOrderRequest>(request));
            var response = BfsJsonMapper.Map<GetSubscriptionOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152607031/CreateSubscriptionOrders
        /// </summary>
        /// <param name="subscriptionOrders"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateSubscriptionOrderResponse> CreateSubscriptionOrdersAsync(
            SubscriptionOrder[] subscriptionOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateSubscriptionOrderRequest>(bfsApiClientName);

            request.Entities = subscriptionOrders;

            var client = await GetClientAsync<RestApi.SubscriptionOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateSubscriptionOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateSubscriptionOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
            UpdateSubscriptionOrder[] accounts, UpdateSubscriptionOrderFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateSubscriptionOrderRequest>(bfsApiClientName);

            request.Entities = accounts;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync<RestApi.SubscriptionOrdersClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateSubscriptionOrderRequest>(request));
            var response = BfsJsonMapper.Map<UpdateSubscriptionOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
            SubscriptionOrder_Cancel subscriptionOrderNumber, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<SubscriptionOrder_CancelRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = subscriptionOrderNumber;

            var client = await GetClientAsync<RestApi.SubscriptionOrdersClient>(bfsApiClientName);
            var restResponse = await client.CancelAsync(BfsJsonMapper.Map<RestApi.SubscriptionOrder_CancelRequest>(request));
            var response = BfsJsonMapper.Map<SubscriptionOrder_CancelResponse>(restResponse)!;

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
            SubscriptionOrder_Process subscriptionOrderProcess, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<SubscriptionOrder_ProcessRequest>(bfsApiClientName);

            request.WorkflowTriggerDataEntity = subscriptionOrderProcess;

            var client = await GetClientAsync<RestApi.SubscriptionOrdersClient>(bfsApiClientName);
            var restResponse = await client.ProcessAsync(BfsJsonMapper.Map<RestApi.SubscriptionOrder_ProcessRequest>(request));
            var response = BfsJsonMapper.Map<SubscriptionOrder_ProcessResponse>(restResponse)!;

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
        public async Task<GetInternalCashTransferOrderResponse> GetInternalCashTransferOrdersAsync(GetInternalCashTransferOrderArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetInternalCashTransferOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInternalCashTransferOrderFields>();

            var client = await GetClientAsync<RestApi.InternalCashTransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetInternalCashTransferOrderRequest>(request));
            var response = BfsJsonMapper.Map<GetInternalCashTransferOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1755546006/CreateInternalCashTransferOrders
        /// </summary>
        /// <param name="internalCashTransferOrder"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInternalCashTransferOrderResponse> CreateInternalCashTransferOrdersAsync(InternalCashTransferOrder[] internalCashTransferOrder, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateInternalCashTransferOrderRequest>(bfsApiClientName);

            request.Entities = internalCashTransferOrder;

            var client = await GetClientAsync<RestApi.InternalCashTransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateInternalCashTransferOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateInternalCashTransferOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
        public async Task<GetInternalInstrumentTransferOrderResponse> GetInternalInstrumentTransferOrdersAsync(GetInternalInstrumentTransferOrderArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetInternalInstrumentTransferOrderRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInternalInstrumentTransferOrderFields>();

            var client = await GetClientAsync<RestApi.InternalInstrumentTransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetInternalInstrumentTransferOrderRequest>(request));
            var response = BfsJsonMapper.Map<GetInternalInstrumentTransferOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1758461975/CreateInternalInstrumentTransferOrders
        /// </summary>
        /// <param name="internalInstrumentTransferOrder"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInternalInstrumentTransferOrderResponse> CreateInternalInstrumentTransferOrdersAsync(InternalInstrumentTransferOrder[] internalInstrumentTransferOrder, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateInternalInstrumentTransferOrderRequest>(bfsApiClientName);

            request.Entities = internalInstrumentTransferOrder;

            var client = await GetClientAsync<RestApi.InternalInstrumentTransferOrdersClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateInternalInstrumentTransferOrderRequest>(request));
            var response = BfsJsonMapper.Map<CreateInternalInstrumentTransferOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
        public async Task<string> ExecuteInternalTransferOrdersAsync(ExecuteInternalTransferOrder[] internalTransferOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<ExecuteInternalTransferOrderRequest>(bfsApiClientName);

            request.Entities = internalTransferOrders;

            var client = await GetClientAsync<RestApi.InternalTransferOrdersCommonClient>(bfsApiClientName);
            var restResponse = await client.ExecuteAsync(BfsJsonMapper.Map<RestApi.ExecuteInternalTransferOrderRequest>(request));
            var response = BfsJsonMapper.Map<ExecuteInternalTransferOrderResponse>(restResponse)!;

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
        public async Task<string> DeleteInternalTransferOrdersAsync(DeleteInternalTransferOrder[] internalTransferOrders, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteInternalTransferOrderRequest>(bfsApiClientName);

            request.Entities = internalTransferOrders;

            var client = await GetClientAsync<RestApi.InternalTransferOrdersCommonClient>(bfsApiClientName);
            var restResponse = await client.DeleteAsync(BfsJsonMapper.Map<RestApi.DeleteInternalTransferOrderRequest>(request));
            var response = BfsJsonMapper.Map<DeleteInternalTransferOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response.Message;

            LogErrors(response.Message);

            return response.Message;
        }
        #endregion

        #region OrderActions

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2714271827/ExecuteOrders
        /// </summary>
        /// <param name="orderExecutions"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<ExecuteOrderResponse> ExecuteOrdersAsync(OrderExecuteBase[] orderExecutions, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<ExecuteOrderRequest>(bfsApiClientName);

            request.Entities = orderExecutions;

            var client = await GetClientAsync<RestApi.TradeOrdersClient>(bfsApiClientName);
            var restResponse = await client.ExecuteAsync(BfsJsonMapper.Map<RestApi.ExecuteOrderRequest>(request));
            var response = BfsJsonMapper.Map<ExecuteOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/2714304848/SettleOrders
        /// </summary>
        /// <param name="orderSettlements"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<SettleOrderResponse> SettleOrdersAsync(OrderSettleBase[] orderSettlements, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<SettleOrderRequest>(bfsApiClientName);

            request.Entities = orderSettlements;

            var client = await GetClientAsync<RestApi.TradeOrdersClient>(bfsApiClientName);
            var restResponse = await client.SettleAsync(BfsJsonMapper.Map<RestApi.SettleOrderRequest>(request));
            var response = BfsJsonMapper.Map<SettleOrderResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion
    }
}
