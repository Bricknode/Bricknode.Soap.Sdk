using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.DeleteCustomFieldsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<UpdateCustomFieldResponse> UpdateCustomFieldsAsync(UpdateCustomFieldDto[] updateCustomFieldDtoArray, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateCustomFieldRequest>(bfsApiClientName);

            request.Entities = updateCustomFieldDtoArray;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateCustomFieldsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<CreateCustomFieldResponse> CreateCustomFieldsAsync(CreateCustomFieldDto[] createCustomFieldDtoArray, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateCustomFieldRequest>(bfsApiClientName);

            request.Entities = createCustomFieldDtoArray;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateCustomFieldsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}