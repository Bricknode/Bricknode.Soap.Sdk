using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsBankIdService : BfsServiceBase, IBfsBankIdService
    {
        private readonly bfsapiSoap _client;

        public BfsBankIdService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client) :
            base(bfsApiConfiguration, logger)
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
        /// <returns></returns>
        public async Task<BankIdAuthenticateResponse> InitiateBankIdAuthenticationAsync(string ssn,
            BankIdType bankIdType,
            Domain domain, bool authenticatePerson = false)
        {
            var request = GetRequest<BankIdAuthenticateRequest>();

            request.Domain = domain;
            request.AuthenticatePerson = authenticatePerson;
            request.BankIdType = bankIdType;
            request.PersonalNumber = ssn.Replace("-", "");

            var response = await _client.BankIdAuthenticationAsync(request);

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
        /// <returns></returns>
        public async Task<BankIdSignResponse> InitiateBankIdSignature(BankIdType bankIdType, Domain domain, string ssn,
            string signingText, bool authenticatePerson = false)
        {
            var request = GetRequest<BankIdSignRequest>();

            request.Domain = domain;
            request.AuthenticatePerson = authenticatePerson;
            request.BankIdType = bankIdType;
            request.PersonalNumber = ssn.Replace("-", "");
            request.SigningText = signingText;

            var response = await _client.BankIdSignAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/53674418/GetBankIdStatus
        /// </summary>
        /// <param name="orderReference"></param>
        /// <param name="bankIdType"></param>
        /// <returns></returns>
        public async Task<GetBankIdStatusResponse> GetBankIdStatus(string orderReference, BankIdType bankIdType)
        {
            var request = GetRequest<GetBankIdStatusRequest>();

            request.BankIdType = bankIdType;
            request.OrderReference = orderReference;

            var response = await _client.GetBankIdStatusAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}