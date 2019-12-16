﻿using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsPositionService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002925/GetPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetPositionResponse> GetPositionsAsync(GetPositionArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031196/GetHistoricPositions
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetHistoricPositionResponse> GetHistoricPositionsAsync(GetHistoricPositionArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/437157974/GetHoldingsOverTime
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetHoldingsOverTimeResponse> GetHoldingsOverTimeAsync(GetHoldingsOverTimeArgs filters);
    }
}