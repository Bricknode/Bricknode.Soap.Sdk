using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsBankIdService : BfsServiceBase, IBfsBankIdService
    {
        private readonly bfsapiSoap _client;

        public BfsBankIdService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/53674414/BankIdAuthentication
        /// </summary>
        /// <param name="ssn"></param>
        /// <param name="bankIdType"></param>
        /// <param name="domain"></param>
        /// <param name="authenticatePerson"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<BankIdAuthenticateResponse> InitiateBankIdAuthenticationAsync(string ssn,
            BankIdType bankIdType,
            Domain domain, bool authenticatePerson = false, string bfsApiClientName = null)
        {
            var request = GetRequest<BankIdAuthenticateRequest>(bfsApiClientName);

            request.Domain = domain;
            request.AuthenticatePerson = authenticatePerson;
            request.BankIdType = bankIdType;
            request.PersonalNumber = ssn.Replace("-", "");

            var response = await GetClient(bfsApiClientName).BankIdAuthenticationAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/101023757/BankIdSign
        /// </summary>
        /// <param name="bankIdType"></param>
        /// <param name="domain"></param>
        /// <param name="ssn"></param>
        /// <param name="signingText"></param>
        /// <param name="authenticatePerson"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<BankIdSignResponse> InitiateBankIdSignature(BankIdType bankIdType, Domain domain, string ssn,
            string signingText, bool authenticatePerson = false, string bfsApiClientName = null)
        {
            var request = GetRequest<BankIdSignRequest>(bfsApiClientName);

            request.Domain = domain;
            request.AuthenticatePerson = authenticatePerson;
            request.BankIdType = bankIdType;
            request.PersonalNumber = ssn.Replace("-", "");
            request.SigningText = signingText;

            var response = await GetClient(bfsApiClientName).BankIdSignAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/53674418/GetBankIdStatus
        /// </summary>
        /// <param name="orderReference"></param>
        /// <param name="bankIdType"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetBankIdStatusResponse> GetBankIdStatus(string orderReference, BankIdType bankIdType, string bfsApiClientName = null)
        {
            var request = GetRequest<GetBankIdStatusRequest>(bfsApiClientName);

            request.BankIdType = bankIdType;
            request.OrderReference = orderReference;

            var response = await GetClient(bfsApiClientName).GetBankIdStatusAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}