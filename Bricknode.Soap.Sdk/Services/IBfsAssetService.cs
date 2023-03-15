using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsAssetService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58261553/GetInstruments
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetInstrumentsResponse> GetInstrumentsAsync(GetInstrumentsArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/56328268/CreateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateInstrumentResponse> CreateInstrumentsAsync(Instrument[] instruments, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/415989763/UpdateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateInstrumentResponse> UpdateInstrumetnsAsync(UpdateInstrument[] instruments, UpdateInstrumentFields fieldsToUpdate, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/80511103/CreateManualExecutionInterface
        /// </summary>
        /// <param name="executionInterfaces"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateManualExecutionInterfaceResponse> CreateManualExecutionInterfaceAsync(ManualExecutionInterfaceOld[] executionInterfaces, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132616/GetTradingVenues
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetTradingVenueResponse> GetTradingVenuesAsync(GetTradingVenueArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/1457979715/CreateTradingVenue
        /// </summary>
        /// <param name="createTradingVenues"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateTradingVenuesResponse> CreateTradingVenuesAsync(CreateTradingVenue[] createTradingVenues, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031184/GetCash
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetCashResponse> GetCashAsync(GetCashArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152539916/GetAssetAccountTypeLimitations
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetAssetAccountTypeLimitationResponse> GetAssetAccountTypeLimitationsAsync(GetAssetAccountTypeLimitationArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152540274/CreateAssetAccountTypeLimitations
        /// </summary>
        /// <param name="assetAccountTypeLimitations"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateAssetAccountTypeLimitationResponse> CreateAssetAccountTypeLimitationAsync(AssetAccountTypeLimitation[] assetAccountTypeLimitations, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/3108241446/GetInstrumentsByName
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetInstrumentsByNameResponse> GetInstrumentsByNameAsync(GetInstrumentsByNameArgs filters, string? bfsApiClientName = null);
    }
}