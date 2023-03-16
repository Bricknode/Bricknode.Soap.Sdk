using System;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

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

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UsernamePasswordAuthenticationAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(Guid personId, string password, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<ResetPasswordRequest>(bfsApiClientName);
            request.PersonId = personId;
            request.NewPassword = password;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.ResetPasswordAsync(request);
            if (!ValidateResponse(response))
            {
                LogErrors(response.Message);
            }

            return response;
        }
    }
}
