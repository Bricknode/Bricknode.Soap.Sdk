using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsBankIdService : BfsServiceBase, IBfsBankIdService
    {
        public BfsBankIdService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
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
        public async Task<BankIdAuthenticateResponse> InitiateBankIdAuthenticationAsync(BankIdType bankIdType,
            Domain domain, bool authenticatePerson = false, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<BankIdAuthenticateRequest>(bfsApiClientName);
            request.Domain = domain;
            request.AuthenticatePerson = authenticatePerson;
            request.BankIdType = bankIdType;

            var client = await GetClientAsync<RestApi.AuthenticationsClient>(bfsApiClientName);
            var restResponse = await client.BankIdAuthenticationAsync(BfsJsonMapper.Map<RestApi.BankIdAuthenticateRequest>(request));
            var response = BfsJsonMapper.Map<BankIdAuthenticateResponse>(restResponse)!;

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
        public async Task<BankIdSignResponse> InitiateBankIdSignature(BankIdType bankIdType, Domain domain,
            string signingText, bool authenticatePerson = false, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<BankIdSignRequest>(bfsApiClientName);

            request.Domain = domain;
            request.AuthenticatePerson = authenticatePerson;
            request.BankIdType = bankIdType;
            request.SigningText = signingText;

            var client = await GetClientAsync<RestApi.AuthenticationsClient>(bfsApiClientName);
            var restResponse = await client.BankIdSignAsync(BfsJsonMapper.Map<RestApi.BankIdSignRequest>(request));
            var response = BfsJsonMapper.Map<BankIdSignResponse>(restResponse)!;

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
        public async Task<GetBankIdStatusResponse> GetBankIdStatus(string orderReference, BankIdType bankIdType, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetBankIdStatusRequest>(bfsApiClientName);

            request.BankIdType = bankIdType;
            request.OrderReference = orderReference;

            var client = await GetClientAsync<RestApi.AuthenticationsClient>(bfsApiClientName);
            var restResponse = await client.GetBankIdStatusAsync(BfsJsonMapper.Map<RestApi.GetBankIdStatusRequest>(request));
            var response = BfsJsonMapper.Map<GetBankIdStatusResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}