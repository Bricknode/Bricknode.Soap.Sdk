using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsFeeManagerService : BfsServiceBase, IBfsFeeManagerService
    {
        public BfsFeeManagerService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        public async Task<GetFeeRecordResponse> GetFeeRecordsAsync(GetFeeRecordArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFeeRecordRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFeeRecordFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetFeeRecordsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<CreateFeeRecordResponse> CreateFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateFeeRecordRequest>(bfsApiClientName);

            request.Entities = feeRecordDtoArray;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateFeeRecordsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<UpdateFeeRecordResponse> UpdateFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateFeeRecordRequest>(bfsApiClientName);

            request.Entities = feeRecordDtoArray;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateFeeRecordsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<DeleteFeeRecordResponse> DeleteFeeRecordsAsync(DeleteFeeRecordArgs deleteFeeRecordArgs, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteFeeRecordRequest>(bfsApiClientName);

            request.DeleteFeeRecordArgs = deleteFeeRecordArgs;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.DeleteFeeRecordsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}