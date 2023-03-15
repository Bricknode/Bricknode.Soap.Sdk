using System;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsReservationService : BfsServiceBase, IBfsReservationService
    {
        public BfsReservationService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1750007934/GetReservations
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetReservationResponse> GetReservationsAsync(GetReservationArgs filters,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetReservationRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetReservationFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetReservationsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1747353889/CreateReservations
        /// </summary>
        /// <param name="reservations"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateReservationResponse> CreateReservationAsync(Reservation[] reservations,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateReservationRequest>(bfsApiClientName);

            request.Entities = reservations;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateReservationsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1749385447/DeleteReservations
        /// </summary>
        /// <param name="reservationIds"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<string> DeleteReservationsAsync(Guid[] reservationIds, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteReservationRequest>(bfsApiClientName);

            request.BrickIds = reservationIds;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.DeleteReservationsAsync(request);

            if (ValidateResponse(response)) return response.Message;

            LogErrors(response.Message);

            return response.Message;
        }
    }
}