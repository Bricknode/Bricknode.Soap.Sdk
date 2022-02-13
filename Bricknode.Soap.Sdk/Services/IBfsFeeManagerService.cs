using BfsApi;
using System.Threading.Tasks;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsFeeManagerService
    {
        Task<GetFeeRecordResponse> GetFeeRecordsAsync(GetFeeRecordArgs filters, string bfsApiClientName = null);

        Task<CreateFeeRecordResponse> CreateFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray, 
            string bfsApiClientName = null);

        Task<UpdateFeeRecordResponse> UpdateFeeRecordsAsync(FeeRecordDto[] feeInstructionDtoArray, 
            string bfsApiClientName = null);

        Task<DeleteFeeRecordResponse> DeleteFeeRecordsAsync(DeleteFeeRecordArgs deleteFeeRecordArgs,
            string bfsApiClientName = null);

        Task<GetFeeInstructionResponse> GetFeeInstructionsAsync(GetFeeInstructionArgs filters,
            string bfsApiClientName = null);

        Task<CreateFeeInstructionResponse> CreateFeeInstructionsAsync(
            FeeInstructionDto[] feeInstructionDtoArray,
            string bfsApiClientName = null);

        Task<UpdateFeeInstructionResponse> UpdateFeeInstructionsAsync(
            FeeInstructionDto[] feeInstructionDtoArray,
            string bfsApiClientName = null);
    }
}