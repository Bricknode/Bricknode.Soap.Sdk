using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsAuthenticationService : BfsServiceBase, IBfsAuthenticationService
    {
        private readonly bfsapiSoap _client;

        public BfsAuthenticationService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031208/UsernamePasswordAuthentication
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UsernamePasswordAuthenticateResponse> UsernamePasswordAuthenticationAsync(Domain domain,
            string username, string password, string bfsApiClientName = null)
        {
            var request = GetRequest<UsernamePasswordAuthenticateRequest>(bfsApiClientName);

            request.Domain = domain;
            request.Username = username;
            request.Password = password;

            var response = await GetClient(bfsApiClientName).UsernamePasswordAuthenticationAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}