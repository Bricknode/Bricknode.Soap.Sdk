using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsInsuranceService : BfsServiceBase, IBfsInsuranceService
    {
        private readonly bfsapiSoap _client;

        public BfsInsuranceService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        #region Covers

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942686/GetInsuranceCovers
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInsuranceCoversResponse> GetInsuranceCoversAsync(GetInsuranceCoversArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetInsuranceCoversRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceCoversFields>();

            var response = await GetClient(bfsApiClientName).GetInsuranceCoversAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region Products

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/126910487/GetInsuranceProducts
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInsuranceProductsResponse> GetInsuranceProductsAsync(GetInsuranceProductsArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetInsuranceProductsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceProductsFields>();

            var response = await GetClient(bfsApiClientName).GetInsuranceProductsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/126189659/CreateInsuranceProducts
        /// </summary>
        /// <param name="insuranceProducts"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInsuranceProductsResponse> CreateInsuranceProductsAsync(
            InsuranceProduct[] insuranceProducts, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateInsuranceProductsRequest>(bfsApiClientName);

            request.Entities = insuranceProducts;

            var response = await GetClient(bfsApiClientName).CreateInsuranceProductsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/126910479/UpdateInsuranceProducts
        /// </summary>
        /// <param name="insuranceProducts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateInsuranceProductsResponse> UpdateInsuranceProductsAsync(
            UpdateInsuranceProduct[] insuranceProducts, UpdateInsuranceProductFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateInsuranceProductsRequest>(bfsApiClientName);

            request.Entities = insuranceProducts;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateInsuranceProductsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region Policies

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/90177627/GetInsurancePolicies
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInsurancePolicyResponse> GetInsurancePoliciesAsync(GetInsurancePolicyArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetInsurancePolicyRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInsurancePolicyFields>();

            var response = await GetClient(bfsApiClientName).GetInsurancePoliciesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/90767592/CreateInsurancePolicies
        /// </summary>
        /// <param name="insurancePolicies"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInsurancePolicyResponse> CreateInsurancePoliciesAsync(
            InsurancePolicy[] insurancePolicies, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateInsurancePolicyRequest>(bfsApiClientName);

            request.Entities = insurancePolicies;

            var response = await GetClient(bfsApiClientName).CreateInsurancePolicyAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/90767926/UpdateInsurancePolicy
        /// </summary>
        /// <param name="insurancePolicies"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateInsurancePoliciesResponse> UpdateInsurancePoliciesAsync(
            UpdateInsurancePolicy[] insurancePolicies, UpdateInsurancePolicyFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateInsurancePoliciesRequest>(bfsApiClientName);

            request.Entities = insurancePolicies;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateInsurancePoliciesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion

        #region Claims

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942312/GetInsuranceClaims
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInsuranceClaimsResponse> GetInsuranceClaimsAsync(GetInsuranceClaimsArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetInsuranceClaimsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceClaimsFields>();

            var response = await GetClient(bfsApiClientName).GetInsuranceClaimsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942296/CreateInsuranceClaims
        /// </summary>
        /// <param name="insuranceClaims"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInsuranceClaimsResponse> CreateInsuranceClaimsAsync(InsuranceClaim[] insuranceClaims, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateInsuranceClaimsRequest>(bfsApiClientName);

            request.Entities = insuranceClaims;

            var response = await GetClient(bfsApiClientName).CreateInsuranceClaimsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942315/UpdateInsuranceClaims
        /// </summary>
        /// <param name="insuranceClaims"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateInsuranceClaimsResponse> UpdateInsuranceClaimsAsync(
            UpdateInsuranceClaim[] insuranceClaims, UpdateInsuranceClaimsFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateInsuranceClaimsRequest>(bfsApiClientName);

            request.Entities = insuranceClaims;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateInsuranceClaimsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion
    }
}