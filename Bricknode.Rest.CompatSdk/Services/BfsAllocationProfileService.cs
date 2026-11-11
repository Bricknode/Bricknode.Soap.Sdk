using System;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

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

            var client = await GetClientAsync<RestApi.AllocationsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetAllocationProfileRequest>(request));
            var response = BfsJsonMapper.Map<GetAllocationProfileResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.AllocationsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateAllocationProfileRequest>(request));
            var response = BfsJsonMapper.Map<CreateAllocationProfileResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.AllocationsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateAllocationProfileRequest>(request));
            var response = BfsJsonMapper.Map<UpdateAllocationProfileResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.AllocationsClient>(bfsApiClientName);
            var restResponse = await client.DeleteAsync(BfsJsonMapper.Map<RestApi.DeleteAllocationProfileRequest>(request));
            var response = BfsJsonMapper.Map<APIDeleteResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}