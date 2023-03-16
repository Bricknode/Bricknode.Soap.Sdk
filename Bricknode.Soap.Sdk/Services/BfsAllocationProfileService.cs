using System;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsAllocationProfileService : BfsServiceBase, IBfsAllocationProfileService
    {
        public BfsAllocationProfileService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002949/GetAllocationProfiles
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAllocationProfileResponse> GetAllocationProfilesAsync(GetAllocationProfileArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetAllocationProfileRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAllocationProfileFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetAllocationProfilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002936/CreateAllocationProfiles
        /// </summary>
        /// <param name="allocationProfiles"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAllocationProfileResponse> CreateAllocationProfilesAsync(
            AllocationProfile[] allocationProfiles, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateAllocationProfileRequest>(bfsApiClientName);

            request.Entities = allocationProfiles;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateAllocationProfilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002921/UpdateAllocationProfiles
        /// </summary>
        /// <param name="allocationProfiles"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateAllocationProfileResponse> UpdateAllocationProfilesAsync(
            AllocationProfile[] allocationProfiles, UpdateAllocationProfileFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateAllocationProfileRequest>(bfsApiClientName);

            request.Entities = allocationProfiles;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateAllocationProfilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002945/DeleteAllocationProfiles
        /// </summary>
        /// <param name="allocationProfileBrickIds"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<APIDeleteResponse> DeleteAllocationProfilesAsync(Guid[] allocationProfileBrickIds, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteAllocationProfileRequest>(bfsApiClientName);

            request.BrickIds = allocationProfileBrickIds;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.DeleteAllocationProfilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}