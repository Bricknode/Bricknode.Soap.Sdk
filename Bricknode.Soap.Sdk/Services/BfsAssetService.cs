using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsAssetService : BfsServiceBase, IBfsAssetService
    {
        private readonly bfsapiSoap _client;

        public BfsAssetService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client) :
            base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        #region ExecutionInterface

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/80511103/CreateManualExecutionInterface
        /// </summary>
        /// <param name="executionInterfaces"></param>
        /// <returns></returns>
        public async Task<CreateManualExecutionInterfaceResponse> CreateManualExecutionInterfaceAsync(
            ManualExecutionInterface[] executionInterfaces)
        {
            var request = GetRequest<CreateManualExecutionInterfaceRequest>();

            request.Entities = executionInterfaces;

            var response = await _client.CreateManualExecutionInterfaceAsync(request);

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
        /// <returns></returns>
        public async Task<GetTradingVenueResponse> GetTradingVenuesAsync(GetTradingVenueArgs filters)
        {
            var request = GetRequest<GetTradingVenueRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetTradingVenueFields>();

            var response = await _client.GetTradingVenuesAsync(request);

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
        /// <returns></returns>
        public async Task<GetCashResponse> GetCashAsync(GetCashArgs filters)
        {
            var request = GetRequest<GetCashRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetCashFields>();

            var response = await _client.GetCashAsync(request);

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
        /// <returns></returns>
        public async Task<GetInstrumentsResponse> GetInstrumentsAsync(GetInstrumentsArgs filters)
        {
            var request = GetRequest<GetInstrumentsRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetInstrumentsFields>();

            var response = await _client.GetInstrumentsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/56328268/CreateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <returns></returns>
        public async Task<CreateInstrumentResponse> CreateInstrumentsAsync(Instrument[] instruments)
        {
            var request = GetRequest<CreateInstrumentRequest>();

            request.Entities = instruments;

            var response = await _client.CreateInstrumentsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/415989763/UpdateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdateInstrumentResponse> UpdateInstrumetnsAsync(UpdateInstrument[] instruments,
            UpdateInstrumentFields fieldsToUpdate)
        {
            var request = GetRequest<UpdateInstrumentsRequest>();

            request.Entities = instruments;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdateInstrumentsAsync(request);

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
        /// <returns></returns>
        public async Task<GetAssetAccountTypeLimitationResponse> GetAssetAccountTypeLimitationsAsync(
            GetAssetAccountTypeLimitationArgs filters)
        {
            var request = GetRequest<GetAssetAccountTypeLimitationRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetAssetAccountTypeLimitationFields>();

            var response = await _client.GetAssetAccountTypeLimitationsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/152540274/CreateAssetAccountTypeLimitations
        /// </summary>
        /// <param name="assetAccountTypeLimitations"></param>
        /// <returns></returns>
        public async Task<CreateAssetAccountTypeLimitationResponse> CreateAssetAccountTypeLimitationAsync(
            AssetAccountTypeLimitation[] assetAccountTypeLimitations)
        {
            var request = GetRequest<CreateAssetAccountTypeLimitationRequest>();

            request.Entities = assetAccountTypeLimitations;

            var response = await _client.CreateAssetAccountTypeLimitationsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion
    }
}