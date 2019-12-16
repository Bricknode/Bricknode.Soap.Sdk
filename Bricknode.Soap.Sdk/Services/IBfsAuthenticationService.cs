using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsAuthenticationService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031208/UsernamePasswordAuthentication
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UsernamePasswordAuthenticateResponse> UsernamePasswordAuthenticationAsync(Domain domain,
            string username, string password);
    }
}