using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsBankIdService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/53674414/BankIdAuthentication
        /// </summary>
        /// <param name="ssn"></param>
        /// <param name="bankIdType"></param>
        /// <param name="domain"></param>
        /// <param name="authenticatePerson"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<BankIdAuthenticateResponse> InitiateBankIdAuthenticationAsync(string ssn, BankIdType bankIdType,
            Domain domain, bool authenticatePerson = false, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/101023757/BankIdSign
        /// </summary>
        /// <param name="bankIdType"></param>
        /// <param name="domain"></param>
        /// <param name="ssn"></param>
        /// <param name="signingText"></param>
        /// <param name="authenticatePerson"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<BankIdSignResponse> InitiateBankIdSignature(BankIdType bankIdType, Domain domain, string ssn,
            string signingText, bool authenticatePerson = false, string bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/53674418/GetBankIdStatus
        /// </summary>
        /// <param name="orderReference"></param>
        /// <param name="bankIdType"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetBankIdStatusResponse> GetBankIdStatus(string orderReference, BankIdType bankIdType, string bfsApiClientName = null);
    }
}