using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

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

            var client = await GetClientAsync<RestApi.FeeRecordsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetFeeRecordRequest>(request));
            var response = BfsJsonMapper.Map<GetFeeRecordResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<CreateFeeRecordResponse> CreateFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateFeeRecordRequest>(bfsApiClientName);

            request.Entities = feeRecordDtoArray;

            var client = await GetClientAsync<RestApi.FeeRecordsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateFeeRecordRequest>(request));
            var response = BfsJsonMapper.Map<CreateFeeRecordResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<UpdateFeeRecordResponse> UpdateFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateFeeRecordRequest>(bfsApiClientName);

            request.Entities = feeRecordDtoArray;

            var client = await GetClientAsync<RestApi.FeeRecordsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateFeeRecordRequest>(request));
            var response = BfsJsonMapper.Map<UpdateFeeRecordResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        public async Task<DeleteFeeRecordResponse> DeleteFeeRecordsAsync(DeleteFeeRecordArgs deleteFeeRecordArgs, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteFeeRecordRequest>(bfsApiClientName);

            request.DeleteFeeRecordArgs = deleteFeeRecordArgs;

            var client = await GetClientAsync<RestApi.FeeRecordsClient>(bfsApiClientName);
            var restResponse = await client.DeleteAsync(BfsJsonMapper.Map<RestApi.DeleteFeeRecordRequest>(request));
            var response = BfsJsonMapper.Map<DeleteFeeRecordResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}