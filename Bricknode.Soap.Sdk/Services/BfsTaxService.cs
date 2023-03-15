using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsTaxService : BfsServiceBase, IBfsTaxService
    {
        public BfsTaxService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetTaxWithholdingAgreementsAsync(request);

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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateTaxWithholdingAgreementsAsync(request);

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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateTaxWithholdingAgreementsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}