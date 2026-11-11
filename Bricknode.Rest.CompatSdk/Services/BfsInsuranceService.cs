using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsInsuranceService : BfsServiceBase, IBfsInsuranceService
    {
        public BfsInsuranceService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        #region Covers

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942686/GetInsuranceCovers
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetInsuranceCoversResponse> GetInsuranceCoversAsync(GetInsuranceCoversArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetInsuranceCoversRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceCoversFields>();

            var client = await GetClientAsync<RestApi.InsuranceCoversClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetInsuranceCoversRequest>(request));
            var response = BfsJsonMapper.Map<GetInsuranceCoversResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

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
        public async Task<GetInsuranceProductsResponse> GetInsuranceProductsAsync(GetInsuranceProductsArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetInsuranceProductsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceProductsFields>();

            var client = await GetClientAsync<RestApi.InsuranceProductsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetInsuranceProductsRequest>(request));
            var response = BfsJsonMapper.Map<GetInsuranceProductsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/126189659/CreateInsuranceProducts
        /// </summary>
        /// <param name="insuranceProducts"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInsuranceProductsResponse> CreateInsuranceProductsAsync(
            InsuranceProduct[] insuranceProducts, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateInsuranceProductsRequest>(bfsApiClientName);

            request.Entities = insuranceProducts;

            var client = await GetClientAsync<RestApi.InsuranceProductsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateInsuranceProductsRequest>(request));
            var response = BfsJsonMapper.Map<CreateInsuranceProductsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
            UpdateInsuranceProduct[] insuranceProducts, UpdateInsuranceProductFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateInsuranceProductsRequest>(bfsApiClientName);

            request.Entities = insuranceProducts;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync<RestApi.InsuranceProductsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateInsuranceProductsRequest>(request));
            var response = BfsJsonMapper.Map<UpdateInsuranceProductsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
        public async Task<GetInsurancePolicyResponse> GetInsurancePoliciesAsync(GetInsurancePolicyArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetInsurancePolicyRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInsurancePolicyFields>();

            var client = await GetClientAsync<RestApi.InsurancePolicyClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetInsurancePolicyRequest>(request));
            var response = BfsJsonMapper.Map<GetInsurancePolicyResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/90767592/CreateInsurancePolicies
        /// </summary>
        /// <param name="insurancePolicies"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInsurancePolicyResponse> CreateInsurancePoliciesAsync(
            InsurancePolicy[] insurancePolicies, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateInsurancePolicyRequest>(bfsApiClientName);

            request.Entities = insurancePolicies;

            var client = await GetClientAsync<RestApi.InsurancePolicyClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateInsurancePolicyRequest>(request));
            var response = BfsJsonMapper.Map<CreateInsurancePolicyResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
            UpdateInsurancePolicy[] insurancePolicies, UpdateInsurancePolicyFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateInsurancePoliciesRequest>(bfsApiClientName);

            request.Entities = insurancePolicies;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync<RestApi.InsurancePolicyClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateInsurancePoliciesRequest>(request));
            var response = BfsJsonMapper.Map<UpdateInsurancePoliciesResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
        public async Task<GetInsuranceClaimsResponse> GetInsuranceClaimsAsync(GetInsuranceClaimsArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetInsuranceClaimsRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetInsuranceClaimsFields>();

            var client = await GetClientAsync<RestApi.InsuranceClaimsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetInsuranceClaimsRequest>(request));
            var response = BfsJsonMapper.Map<GetInsuranceClaimsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/128942296/CreateInsuranceClaims
        /// </summary>
        /// <param name="insuranceClaims"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateInsuranceClaimsResponse> CreateInsuranceClaimsAsync(InsuranceClaim[] insuranceClaims, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateInsuranceClaimsRequest>(bfsApiClientName);

            request.Entities = insuranceClaims;

            var client = await GetClientAsync<RestApi.InsuranceClaimsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateInsuranceClaimsRequest>(request));
            var response = BfsJsonMapper.Map<CreateInsuranceClaimsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
            UpdateInsuranceClaim[] insuranceClaims, UpdateInsuranceClaimsFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateInsuranceClaimsRequest>(bfsApiClientName);

            request.Entities = insuranceClaims;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync<RestApi.InsuranceClaimsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateInsuranceClaimsRequest>(request));
            var response = BfsJsonMapper.Map<UpdateInsuranceClaimsResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        #endregion
    }
}