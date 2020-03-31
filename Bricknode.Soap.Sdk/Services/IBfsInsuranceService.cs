using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsInsuranceService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/126910487/GetInsuranceProducts
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetInsuranceProductsResponse> GetInsuranceProductsAsync(GetInsuranceProductsArgs filters, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/126189659/CreateInsuranceProducts
        /// </summary>
        /// <param name="insuranceProducts"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateInsuranceProductsResponse> CreateInsuranceProductsAsync(InsuranceProduct[] insuranceProducts, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/126910479/UpdateInsuranceProducts
        /// </summary>
        /// <param name="insuranceProducts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateInsuranceProductsResponse> UpdateInsuranceProductsAsync(UpdateInsuranceProduct[] insuranceProducts, UpdateInsuranceProductFields fieldsToUpdate, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/90177627/GetInsurancePolicies
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetInsurancePolicyResponse> GetInsurancePoliciesAsync(GetInsurancePolicyArgs filters, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/90767592/CreateInsurancePolicies
        /// </summary>
        /// <param name="insurancePolicies"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateInsurancePolicyResponse> CreateInsurancePoliciesAsync(InsurancePolicy[] insurancePolicies, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/90767926/UpdateInsurancePolicy
        /// </summary>
        /// <param name="insurancePolicies"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateInsurancePoliciesResponse> UpdateInsurancePoliciesAsync(UpdateInsurancePolicy[] insurancePolicies, UpdateInsurancePolicyFields fieldsToUpdate, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/128942686/GetInsuranceCovers
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetInsuranceCoversResponse> GetInsuranceCoversAsync(GetInsuranceCoversArgs filters, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/128942312/GetInsuranceClaims
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetInsuranceClaimsResponse> GetInsuranceClaimsAsync(GetInsuranceClaimsArgs filters, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/128942296/CreateInsuranceClaims
        /// </summary>
        /// <param name="insuranceClaims"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateInsuranceClaimsResponse> CreateInsuranceClaimsAsync(InsuranceClaim[] insuranceClaims, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/128942315/UpdateInsuranceClaims
        /// </summary>
        /// <param name="insuranceClaims"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateInsuranceClaimsResponse> UpdateInsuranceClaimsAsync(UpdateInsuranceClaim[] insuranceClaims, UpdateInsuranceClaimsFields fieldsToUpdate, string bfsApiClientName = null);
    }
}