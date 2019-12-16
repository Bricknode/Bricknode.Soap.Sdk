using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsBusinessEventService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/171573292/GetBusinessEvents
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetBusinessEventResponse> GetBusinessEventsAsync(GetBusinessEventArgs filters);
    }
}