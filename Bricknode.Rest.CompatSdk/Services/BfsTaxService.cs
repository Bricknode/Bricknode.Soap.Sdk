using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsTaxService : BfsServiceBase, IBfsTaxService
    {
        public BfsTaxService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }


        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1408499748/GetTaxWithholdingAgreements
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTaxWithholdingAgreementResponse> GetTaxWithholdingAgreementsAsync(GetTaxWithholdingAgreementArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetTaxWithholdingAgreementRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTaxWithholdingAgreementFields>();

            var client = await GetClientAsync<RestApi.TaxWithholdingAgreementClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetTaxWithholdingAgreementRequest>(request));
            var response = BfsJsonMapper.Map<GetTaxWithholdingAgreementResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1408237662/CreateTaxWithholdingAgreements
        /// </summary>
        /// <param name="taxWithholdingAgreements"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateTaxWithholdingAgreementResponse> CreateTaxWithholdingAgreementsAsync(TaxWithholdingAgreement[] taxWithholdingAgreements, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateTaxWithholdingAgreementsRequest>(bfsApiClientName);

            request.Entities = taxWithholdingAgreements;

            var client = await GetClientAsync<RestApi.TaxWithholdingAgreementClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreateTaxWithholdingAgreementsRequest>(request));
            var response = BfsJsonMapper.Map<CreateTaxWithholdingAgreementResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }


        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1409777757/UpdateTaxWithholdingAgreements
        /// </summary>
        /// <param name="taxWithholdingAgreements"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateTaxWithholdingAgreementResponse> UpdateTaxWithholdingAgreementsAsync(UpdateTaxWithholdingAgreement[] taxWithholdingAgreements,
            UpdateTaxWithholdingAgreementFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateTaxWithholdingAgreementsRequest>(bfsApiClientName);

            request.Entities = taxWithholdingAgreements;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync<RestApi.TaxWithholdingAgreementClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdateTaxWithholdingAgreementsRequest>(request));
            var response = BfsJsonMapper.Map<UpdateTaxWithholdingAgreementResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}