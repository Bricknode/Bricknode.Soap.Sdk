using BfsApi;
using System.Threading.Tasks;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsCustomFieldService
    {
        Task<DeleteCustomFieldResponse> DeleteCustomFieldsAsync(DeleteCustomField[] deleteCustomFieldArray, string bfsApiClientName = null);
    }
}