using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsInsuranceService : BfsServiceBase, IBfsInsuranceService
    {
        private readonly bfsapiSoap _client;

        public BfsInsuranceService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client)
            : base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        #region Covers

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942686/GetInsuranceCovers
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetInsuranceCoversResponse> GetInsuranceCoversAsync(GetInsuranceCoversArgs filters)
        {
            var request = GetRequest<GetInsuranceCoversRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceCoversFields>();

            var response = await _client.GetInsuranceCoversAsync(request);

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
        /// <returns></returns>
        public async Task<GetInsuranceProductsResponse> GetInsuranceProductsAsync(GetInsuranceProductsArgs filters)
        {
            var request = GetRequest<GetInsuranceProductsRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceProductsFields>();

            var response = await _client.GetInsuranceProductsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/126189659/CreateInsuranceProducts
        /// </summary>
        /// <param name="insuranceProducts"></param>
        /// <returns></returns>
        public async Task<CreateInsuranceProductsResponse> CreateInsuranceProductsAsync(
            InsuranceProduct[] insuranceProducts)
        {
            var request = GetRequest<CreateInsuranceProductsRequest>();

            request.Entities = insuranceProducts;

            var response = await _client.CreateInsuranceProductsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/126910479/UpdateInsuranceProducts
        /// </summary>
        /// <param name="insuranceProducts"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdateInsuranceProductsResponse> UpdateInsuranceProductsAsync(
            UpdateInsuranceProduct[] insuranceProducts, UpdateInsuranceProductFields fieldsToUpdate)
        {
            var request = GetRequest<UpdateInsuranceProductsRequest>();

            request.Entities = insuranceProducts;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdateInsuranceProductsAsync(request);

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
        /// <returns></returns>
        public async Task<GetInsurancePolicyResponse> GetInsurancePoliciesAsync(GetInsurancePolicyArgs filters)
        {
            var request = GetRequest<GetInsurancePolicyRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetInsurancePolicyFields>();

            var response = await _client.GetInsurancePoliciesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/90767592/CreateInsurancePolicies
        /// </summary>
        /// <param name="insurancePolicies"></param>
        /// <returns></returns>
        public async Task<CreateInsurancePolicyResponse> CreateInsurancePoliciesAsync(
            InsurancePolicy[] insurancePolicies)
        {
            var request = GetRequest<CreateInsurancePolicyRequest>();

            request.Entities = insurancePolicies;

            var response = await _client.CreateInsurancePolicyAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/90767926/UpdateInsurancePolicy
        /// </summary>
        /// <param name="insurancePolicies"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdateInsurancePoliciesResponse> UpdateInsurancePoliciesAsync(
            UpdateInsurancePolicy[] insurancePolicies, UpdateInsurancePolicyFields fieldsToUpdate)
        {
            var request = GetRequest<UpdateInsurancePoliciesRequest>();

            request.Entities = insurancePolicies;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdateInsurancePoliciesAsync(request);

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
        /// <returns></returns>
        public async Task<GetInsuranceClaimsResponse> GetInsuranceClaimsAsync(GetInsuranceClaimsArgs filters)
        {
            var request = GetRequest<GetInsuranceClaimsRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceClaimsFields>();

            var response = await _client.GetInsuranceClaimsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942296/CreateInsuranceClaims
        /// </summary>
        /// <param name="insuranceClaims"></param>
        /// <returns></returns>
        public async Task<CreateInsuranceClaimsResponse> CreateInsuranceClaimsAsync(InsuranceClaim[] insuranceClaims)
        {
            var request = GetRequest<CreateInsuranceClaimsRequest>();

            request.Entities = insuranceClaims;

            var response = await _client.CreateInsuranceClaimsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942315/UpdateInsuranceClaims
        /// </summary>
        /// <param name="insuranceClaims"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdateInsuranceClaimsResponse> UpdateInsuranceClaimsAsync(
            UpdateInsuranceClaim[] insuranceClaims, UpdateInsuranceClaimsFields fieldsToUpdate)
        {
            var request = GetRequest<UpdateInsuranceClaimsRequest>();

            request.Entities = insuranceClaims;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdateInsuranceClaimsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        #endregion
    }
}