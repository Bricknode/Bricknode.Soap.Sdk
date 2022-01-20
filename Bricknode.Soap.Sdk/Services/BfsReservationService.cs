using System;
using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsReservationService : BfsServiceBase, IBfsReservationService
    {
        public BfsReservationService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1750007934/GetReservations
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetReservationResponse> GetReservationsAsync(GetReservationArgs filters,
            string bfsApiClientName = null)
        {
            var request = GetRequest<GetReservationRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetReservationFields>();

            var response = await GetClient(bfsApiClientName).GetReservationsAsync(request);

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
            string bfsApiClientName = null)
        {
            var request = GetRequest<CreateReservationRequest>(bfsApiClientName);

            request.Entities = reservations;

            var response = await GetClient(bfsApiClientName).CreateReservationsAsync(request);

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
        public async Task<string> DeleteReservationsAsync(Guid[] reservationIds, string bfsApiClientName = null)
        {
            var request = GetRequest<DeleteReservationRequest>(bfsApiClientName);

            request.BrickIds = reservationIds;

            var response = await GetClient(bfsApiClientName).DeleteReservationsAsync(request);

            if (ValidateResponse(response)) return response.Message;

            LogErrors(response.Message);

            return response.Message;
        }
    }
}