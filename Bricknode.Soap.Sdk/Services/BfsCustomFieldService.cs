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

        public async Task<DeleteCustomFieldResponse> DeleteCustomFieldsAsync(DeleteCustomField[] deleteCustomFieldArray, string bfsApiClientName = null)
        {
            var request = GetRequest<DeleteCustomFieldRequest>(bfsApiClientName);

            request.Entities = deleteCustomFieldArray;

            var response = await GetClient(bfsApiClientName).DeleteCustomFieldAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}