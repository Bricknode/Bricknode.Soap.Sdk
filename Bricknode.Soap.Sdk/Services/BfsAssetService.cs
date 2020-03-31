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

    public class BfsAssetService : BfsServiceBase, IBfsAssetService
    {
        private readonly bfsapiSoap _client;

        public BfsAssetService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        #region ExecutionInterface

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/80511103/CreateManualExecutionInterface
        /// </summary>
        /// <param name="executionInterfaces"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateManualExecutionInterfaceResponse> CreateManualExecutionInterfaceAsync(
            ManualExecutionInterface[] executionInterfaces, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateManualExecutionInterfaceRequest>(bfsApiClientName);

            request.Entities = executionInterfaces;

            var response = await GetClient(bfsApiClientName).CreateManualExecutionInterfaceAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

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
        public async Task<GetTradingVenueResponse> GetTradingVenuesAsync(GetTradingVenueArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetTradingVenueRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTradingVenueFields>();

            var response = await GetClient(bfsApiClientName).GetTradingVenuesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

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
        public async Task<GetCashResponse> GetCashAsync(GetCashArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetCashRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetCashFields>();

            var response = await GetClient(bfsApiClientName).GetCashAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

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
        public async Task<GetInstrumentsResponse> GetInstrumentsAsync(GetInstrumentsArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetInstrumentsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInstrumentsFields>();

            var response = await GetClient(bfsApiClientName).GetInstrumentsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/56328268/CreateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInstrumentResponse> CreateInstrumentsAsync(Instrument[] instruments, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateInstrumentRequest>(bfsApiClientName);

            request.Entities = instruments;

            var response = await GetClient(bfsApiClientName).CreateInstrumentsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

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
            UpdateInstrumentFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateInstrumentsRequest>(bfsApiClientName);

            request.Entities = instruments;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateInstrumentsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

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
            GetAssetAccountTypeLimitationArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetAssetAccountTypeLimitationRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAssetAccountTypeLimitationFields>();

            var response = await GetClient(bfsApiClientName).GetAssetAccountTypeLimitationsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152540274/CreateAssetAccountTypeLimitations
        /// </summary>
        /// <param name="assetAccountTypeLimitations"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAssetAccountTypeLimitationResponse> CreateAssetAccountTypeLimitationAsync(
            AssetAccountTypeLimitation[] assetAccountTypeLimitations, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateAssetAccountTypeLimitationRequest>(bfsApiClientName);

            request.Entities = assetAccountTypeLimitations;

            var response = await GetClient(bfsApiClientName).CreateAssetAccountTypeLimitationsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion
    }
}