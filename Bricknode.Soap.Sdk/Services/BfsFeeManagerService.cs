using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsFeeManagerService : BfsServiceBase, IBfsFeeManagerService
    {
        private readonly bfsapiSoap _client;

        public BfsFeeManagerService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        #region FeeRecords
        public async Task<GetFeeRecordResponse> GetFeeRecordsAsync(GetFeeRecordArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetFeeRecordRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFeeRecordFields>();

            var response = await GetClient(bfsApiClientName).GetFeeRecordsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<CreateFeeRecordResponse> CreateFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray,
            string bfsApiClientName = null)
        {
            var request = GetRequest<CreateFeeRecordRequest>(bfsApiClientName);

            request.Entities = feeRecordDtoArray;

            var response = await GetClient(bfsApiClientName).CreateFeeRecordsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<UpdateFeeRecordResponse> UpdateFeeRecordsAsync(FeeRecordDto[] feeInstructionDtoArray,
            string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateFeeRecordRequest>(bfsApiClientName);

            request.Entities = feeInstructionDtoArray;

            var response = await GetClient(bfsApiClientName).UpdateFeeRecordsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<DeleteFeeRecordResponse> DeleteFeeRecordsAsync(DeleteFeeRecordArgs deleteFeeRecordArgs, string bfsApiClientName = null)
        {
            var request = GetRequest<DeleteFeeRecordRequest>(bfsApiClientName);

            request.DeleteFeeRecordArgs = deleteFeeRecordArgs;

            var response = await GetClient(bfsApiClientName).DeleteFeeRecordsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion

        #region FeeInstructions

        public async Task<GetFeeInstructionResponse> GetFeeInstructionsAsync(GetFeeInstructionArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetFeeInstructionRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFeeInstructionFields>();

            var response = await GetClient(bfsApiClientName).GetFeeInstructionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<CreateFeeInstructionResponse> CreateFeeInstructionsAsync(FeeInstructionDto[] feeInstructionDtoArray,
            string bfsApiClientName = null)
        {
            var request = GetRequest<CreateFeeInstructionRequest>(bfsApiClientName);

            request.Entities = feeInstructionDtoArray;

            var response = await GetClient(bfsApiClientName).CreateFeeInstructionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<UpdateFeeInstructionResponse> UpdateFeeInstructionsAsync(FeeInstructionDto[] feeInstructionDtoArray,
            string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateFeeInstructionRequest>(bfsApiClientName);

            request.Entities = feeInstructionDtoArray;

            var response = await GetClient(bfsApiClientName).UpdateFeeInstructionsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion
    }
}