using System;
using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsAllocationProfileService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002949/GetAllocationProfiles
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetAllocationProfileResponse> GetAllocationProfilesAsync(GetAllocationProfileArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002936/CreateAllocationProfiles
        /// </summary>
        /// <param name="allocationProfiles"></param>
        /// <returns></returns>
        Task<CreateAllocationProfileResponse> CreateAllocationProfilesAsync(AllocationProfile[] allocationProfiles);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002921/UpdateAllocationProfiles
        /// </summary>
        /// <param name="allocationProfiles"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        Task<UpdateAllocationProfileResponse> UpdateAllocationProfilesAsync(AllocationProfile[] allocationProfiles, UpdateAllocationProfileFields fieldsToUpdate);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/52002945/DeleteAllocationProfiles
        /// </summary>
        /// <param name="allocationProfileBrickIds"></param>
        /// <returns></returns>
        Task<APIDeleteResponse> DeleteAllocationProfilesAsync(Guid[] allocationProfileBrickIds);
    }
}