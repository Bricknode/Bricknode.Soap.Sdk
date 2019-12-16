﻿using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsAssetService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/58261553/GetInstruments
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetInstrumentsResponse> GetInstrumentsAsync(GetInstrumentsArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/56328268/CreateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <returns></returns>
        Task<CreateInstrumentResponse> CreateInstrumentsAsync(Instrument[] instruments);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/415989763/UpdateInstruments
        /// </summary>
        /// <param name="instruments"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        Task<UpdateInstrumentResponse> UpdateInstrumetnsAsync(UpdateInstrument[] instruments, UpdateInstrumentFields fieldsToUpdate);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/80511103/CreateManualExecutionInterface
        /// </summary>
        /// <param name="executionInterfaces"></param>
        /// <returns></returns>
        Task<CreateManualExecutionInterfaceResponse> CreateManualExecutionInterfaceAsync(ManualExecutionInterface[] executionInterfaces);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/83132616/GetTradingVenues
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetTradingVenueResponse> GetTradingVenuesAsync(GetTradingVenueArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031184/GetCash
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetCashResponse> GetCashAsync(GetCashArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152539916/GetAssetAccountTypeLimitations
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetAssetAccountTypeLimitationResponse> GetAssetAccountTypeLimitationsAsync(GetAssetAccountTypeLimitationArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/152540274/CreateAssetAccountTypeLimitations
        /// </summary>
        /// <param name="assetAccountTypeLimitations"></param>
        /// <returns></returns>
        Task<CreateAssetAccountTypeLimitationResponse> CreateAssetAccountTypeLimitationAsync(AssetAccountTypeLimitation[] assetAccountTypeLimitations);
    }
}