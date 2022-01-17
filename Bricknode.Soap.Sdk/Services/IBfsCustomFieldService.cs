using BfsApi;
using System.Threading.Tasks;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsCustomFieldService
    {
        Task<DeleteCustomFieldResponse> DeleteCustomFieldsAsync(DeleteCustomFieldDto[] deleteCustomFieldDtoArray, 
            string bfsApiClientName = null);

        Task<UpdateCustomFieldResponse> UpdateCustomFieldsAsync(
            UpdateCustomFieldDto[] updateCustomFieldDtoArray, string bfsApiClientName = null);

        Task<CreateCustomFieldResponse> CreateCustomFieldsAsync(
            CreateCustomFieldDto[] createCustomFieldDtoArray, string bfsApiClientName = null);
    }
}