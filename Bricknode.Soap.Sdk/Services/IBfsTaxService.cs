using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsTaxService
    {
        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1408499748/GetTaxWithholdingAgreements
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetTaxWithholdingAgreementResponse> GetTaxWithholdingAgreementsAsync(GetTaxWithholdingAgreementArgs filters, string bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1408237662/CreateTaxWithholdingAgreements
        /// </summary>
        /// <param name="taxWithholdingAgreements"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateTaxWithholdingAgreementResponse> CreateTaxWithholdingAgreementsAsync(TaxWithholdingAgreement[] taxWithholdingAgreements, string bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1409777757/UpdateTaxWithholdingAgreements
        /// </summary>
        /// <param name="taxWithholdingAgreements"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateTaxWithholdingAgreementResponse> UpdateTaxWithholdingAgreementsAsync(UpdateTaxWithholdingAgreement[] taxWithholdingAgreements,
            UpdateTaxWithholdingAgreementFields fieldsToUpdate, string bfsApiClientName = null);
    }
}