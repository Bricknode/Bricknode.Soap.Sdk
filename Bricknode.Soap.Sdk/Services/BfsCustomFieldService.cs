using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsCustomFieldService : BfsServiceBase, IBfsCustomFieldService
    {
        private readonly bfsapiSoap _client;

        public BfsCustomFieldService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        public async Task<DeleteCustomFieldResponse> DeleteCustomFieldsAsync(DeleteCustomFieldDto[] deleteCustomFieldDtoArray, string bfsApiClientName = null)
        {
            var request = GetRequest<DeleteCustomFieldRequest>(bfsApiClientName);

            request.Entities = deleteCustomFieldDtoArray;

            var response = await GetClient(bfsApiClientName).DeleteCustomFieldsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<UpdateCustomFieldResponse> UpdateCustomFieldsAsync(UpdateCustomFieldDto[] updateCustomFieldDtoArray, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateCustomFieldRequest>(bfsApiClientName);

            request.Entities = updateCustomFieldDtoArray;

            var response = await GetClient(bfsApiClientName).UpdateCustomFieldsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<CreateCustomFieldResponse> CreateCustomFieldsAsync(CreateCustomFieldDto[] createCustomFieldDtoArray, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateCustomFieldRequest>(bfsApiClientName);

            request.Entities = createCustomFieldDtoArray;

            var response = await GetClient(bfsApiClientName).CreateCustomFieldsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}