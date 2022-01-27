using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
   
    public class BfsTaxService : BfsServiceBase, IBfsTaxService
    {
        private readonly bfsapiSoap _client;

        public BfsTaxService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, IBfsApiClientFactory bfsApiClientFactory, bfsapiSoap client) : base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }


        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1408499748/GetTaxWithholdingAgreements
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTaxWithholdingAgreementResponse> GetTaxWithholdingAgreementsAsync(GetTaxWithholdingAgreementArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetTaxWithholdingAgreementRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTaxWithholdingAgreementFields>();

            var response = await GetClient(bfsApiClientName).GetTaxWithholdingAgreementsAsync(request);

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
        public async Task<CreateTaxWithholdingAgreementResponse> CreateTaxWithholdingAgreementsAsync(TaxWithholdingAgreement[] taxWithholdingAgreements, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateTaxWithholdingAgreementsRequest>(bfsApiClientName);

            request.Entities = taxWithholdingAgreements;

            var response = await GetClient(bfsApiClientName).CreateTaxWithholdingAgreementsAsync(request);

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
            UpdateTaxWithholdingAgreementFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateTaxWithholdingAgreementsRequest>(bfsApiClientName);

            request.Entities = taxWithholdingAgreements;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateTaxWithholdingAgreementsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}