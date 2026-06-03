using System;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    /// <summary>
    /// REST-backed drop-in replacement for the SOAP <c>BfsAuthenticationService</c>.
    /// Public surface is identical; internally it maps the SOAP-shaped <c>BfsApi.*</c> DTOs to the
    /// generated REST records (<see cref="BfsJsonMapper"/>) and calls the REST resource clients.
    /// </summary>
    public class BfsAuthenticationService : BfsServiceBase, IBfsAuthenticationService
    {
        public BfsAuthenticationService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
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
            string username, string password, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UsernamePasswordAuthenticateRequest>(bfsApiClientName);

            request.Domain = domain;
            request.Username = username;
            request.Password = password;

            var client = await GetClientAsync<RestApi.AuthenticationsClient>(bfsApiClientName);
            var restResponse = await client.UsernamePasswordAuthenticationAsync(BfsJsonMapper.Map<RestApi.UsernamePasswordAuthenticateRequest>(request));
            var response = BfsJsonMapper.Map<UsernamePasswordAuthenticateResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(Guid personId, string password, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<ResetPasswordRequest>(bfsApiClientName);
            request.PersonId = personId;
            request.NewPassword = password;

            var client = await GetClientAsync<RestApi.AuthenticationsClient>(bfsApiClientName);
            var restResponse = await client.ResetPasswordAsync(BfsJsonMapper.Map<RestApi.ResetPasswordRequest>(request));
            var response = BfsJsonMapper.Map<ResetPasswordResponse>(restResponse)!;
            if (!ValidateResponse(response))
            {
                LogErrors(response.Message);
            }

            return response;
        }
    }
}
