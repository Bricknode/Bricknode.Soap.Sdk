using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsAssetService : BfsServiceBase, IBfsAssetService
    {
        public BfsAssetService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        #region ExecutionInterface

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/80511103/CreateManualExecutionInterface
        /// </summary>
        /// <param name="executionInterfaces"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateManualExecutionInterfaceResponse> CreateManualExecutionInterfaceAsync(
            ManualExecutionInterfaceOld[] executionInterfaces, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateManualExecutionInterfaceRequest>(bfsApiClientName);

            request.Entities = executionInterfaces;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateManualExecutionInterfaceAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion

        #region TradingVenues

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/83132616/GetTradingVenues
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTradingVenueResponse> GetTradingVenuesAsync(GetTradingVenueArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetTradingVenueRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTradingVenueFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetTradingVenuesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1457979715/CreateTradingVenue
        /// </summary>
        /// <param name="createTradingVenues"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateTradingVenuesResponse> CreateTradingVenuesAsync(CreateTradingVenue[] createTradingVenues, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateTradingVenuesRequest>(bfsApiClientName);

            request.Entities = createTradingVenues;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateTradingVenuesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion

        #region Cash

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031184/GetCash
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetCashResponse> GetCashAsync(GetCashArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetCashRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCashFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetCashAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        #endregion

        #region Financial Instruments

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/58261553/GetInstruments
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInstrumentsResponse> GetInstrumentsAsync(GetInstrumentsArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetInstrumentsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInstrumentsFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetInstrumentsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }


        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/3108241446/GetInstrumentsByName
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInstrumentsByNameResponse> GetInstrumentsByNameAsync(GetInstrumentsByNameArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetInstrumentsByNameRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInstrumentsFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetInstrumentsByNameAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }


        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/56328268/CreateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInstrumentResponse> CreateInstrumentsAsync(Instrument[] instruments, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateInstrumentRequest>(bfsApiClientName);

            request.Entities = instruments;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateInstrumentsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/415989763/UpdateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateInstrumentResponse> UpdateInstrumetnsAsync(UpdateInstrument[] instruments,
            UpdateInstrumentFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateInstrumentsRequest>(bfsApiClientName);

            request.Entities = instruments;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateInstrumentsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion

        #region AssetAccountTypeLimitation

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152539916/GetAssetAccountTypeLimitations
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAssetAccountTypeLimitationResponse> GetAssetAccountTypeLimitationsAsync(
            GetAssetAccountTypeLimitationArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAssetAccountTypeLimitationRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAssetAccountTypeLimitationFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetAssetAccountTypeLimitationsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152540274/CreateAssetAccountTypeLimitations
        /// </summary>
        /// <param name="assetAccountTypeLimitations"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAssetAccountTypeLimitationResponse> CreateAssetAccountTypeLimitationAsync(
            AssetAccountTypeLimitation[] assetAccountTypeLimitations, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateAssetAccountTypeLimitationRequest>(bfsApiClientName);

            request.Entities = assetAccountTypeLimitations;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateAssetAccountTypeLimitationsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion
    }
}