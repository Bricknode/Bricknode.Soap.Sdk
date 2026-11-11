using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsCustomFieldService : BfsServiceBase, IBfsCustomFieldService
    {
        public BfsCustomFieldService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        public async Task<DeleteCustomFieldResponse> DeleteCustomFieldsAsync(DeleteCustomFieldDto[] deleteCustomFieldDtoArray, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteCustomFieldRequest>(bfsApiClientName);

            request.Entities = deleteCustomFieldDtoArray;

            var client = await GetClientAsync<RestApi.CustomFieldsClient>(bfsApiClientName);
            var restResponse = await client.DeleteAsync(BfsJsonMapper.Map<RestApi.DeleteCustomFieldRequest>(request));
            var response = BfsJsonMapper.Map<DeleteCustomFieldResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<UpdateCustomFieldResponse> UpdateCustomFieldsAsync(UpdateCustomFieldDto[] updateCustomFieldDtoArray, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateCustomFieldRequest>(bfsApiClientName);

            request.Entities = updateCustomFieldDtoArray;

            var client = await GetClientAsync<RestApi.CustomFieldsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateCustomFieldRequest>(request));
            var response = BfsJsonMapper.Map<UpdateCustomFieldResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<CreateCustomFieldResponse> CreateCustomFieldsAsync(CreateCustomFieldDto[] createCustomFieldDtoArray, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateCustomFieldRequest>(bfsApiClientName);

            request.Entities = createCustomFieldDtoArray;

            var client = await GetClientAsync<RestApi.CustomFieldsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateCustomFieldRequest>(request));
            var response = BfsJsonMapper.Map<CreateCustomFieldResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}