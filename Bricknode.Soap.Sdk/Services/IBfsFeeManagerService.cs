using BfsApi;
using System.Threading.Tasks;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsFeeManagerService
    {
        Task<GetFeeRecordResponse> GetFeeRecordsAsync(GetFeeRecordArgs filters, string bfsApiClientName = null);

        Task<CreateFeeRecordResponse> CreateFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray, 
            string bfsApiClientName = null);

        Task<UpdateFeeRecordResponse> UpdateFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray, 
            string bfsApiClientName = null);

        Task<DeleteFeeRecordResponse> DeleteFeeRecordsAsync(FeeRecordDto[] feeRecordDtoArray,
            string bfsApiClientName = null);
    }
}