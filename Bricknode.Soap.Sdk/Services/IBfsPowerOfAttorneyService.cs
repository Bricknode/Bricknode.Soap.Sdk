using System;
using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsPowerOfAttorneyService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/148248270/GetPOAS
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetPOAResponse> GetPowerOfAttorneys(GetPOAArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031200/GetPOATypes
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetPOATypeResponse> GetPowerOfAttorneyTypesAsync(GetPOATypeArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/93552801/CreatePOAs
        /// </summary>
        /// <param name="powerOfAttorneys"></param>
        /// <returns></returns>
        Task<CreatePOAResponse> CreatePowerOfAttorneysAsync(POA[] powerOfAttorneys);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/446464135/DeletePOAs
        /// </summary>
        /// <param name="powerOfAttorneyIds"></param>
        /// <returns></returns>
        Task<string> DeletePowerOfAttorneysAsync(Guid[] powerOfAttorneyIds);
    }
}