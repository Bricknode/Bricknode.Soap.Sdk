using System;
using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsAllocationProfileService : BfsServiceBase, IBfsAllocationProfileService
    {
        private readonly bfsapiSoap _client;

        public BfsAllocationProfileService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002949/GetAllocationProfiles
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetAllocationProfileResponse> GetAllocationProfilesAsync(GetAllocationProfileArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetAllocationProfileRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetAllocationProfileFields>();

            var response = await GetClient(bfsApiClientName).GetAllocationProfilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002936/CreateAllocationProfiles
        /// </summary>
        /// <param name="allocationProfiles"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateAllocationProfileResponse> CreateAllocationProfilesAsync(
            AllocationProfile[] allocationProfiles, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateAllocationProfileRequest>(bfsApiClientName);

            request.Entities = allocationProfiles;

            var response = await GetClient(bfsApiClientName).CreateAllocationProfilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

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
            AllocationProfile[] allocationProfiles, UpdateAllocationProfileFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateAllocationProfileRequest>(bfsApiClientName);

            request.Entities = allocationProfiles;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateAllocationProfilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/52002945/DeleteAllocationProfiles
        /// </summary>
        /// <param name="allocationProfileBrickIds"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<APIDeleteResponse> DeleteAllocationProfilesAsync(Guid[] allocationProfileBrickIds, string bfsApiClientName = null)
        {
            var request = GetRequest<DeleteAllocationProfileRequest>(bfsApiClientName);

            request.BrickIds = allocationProfileBrickIds;

            var response = await GetClient(bfsApiClientName).DeleteAllocationProfilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}