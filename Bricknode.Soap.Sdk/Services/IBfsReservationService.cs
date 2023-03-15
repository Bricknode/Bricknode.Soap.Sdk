using System;
using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsReservationService
    {
        Task<GetReservationResponse> GetReservationsAsync(GetReservationArgs filters, string? bfsApiClientName = null);

        Task<CreateReservationResponse> CreateReservationAsync(Reservation[] reservations,
            string? bfsApiClientName = null);

        Task<string> DeleteReservationsAsync(Guid[] reservationIds, string? bfsApiClientName = null);
    }
}