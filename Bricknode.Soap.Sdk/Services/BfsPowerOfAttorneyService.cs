using System;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsPowerOfAttorneyService : BfsServiceBase, IBfsPowerOfAttorneyService
    {
        public BfsPowerOfAttorneyService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/148248270/GetPOAS
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetPOAResponse> GetPowerOfAttorneys(GetPOAArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetPOARequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetPOAFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetPOASAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031200/GetPOATypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetPOATypeResponse> GetPowerOfAttorneyTypesAsync(GetPOATypeArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetPOATypeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetPOATypeFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetPOATypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/93552801/CreatePOAs
        /// </summary>
        /// <param name="powerOfAttorneys"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreatePOAResponse> CreatePowerOfAttorneysAsync(POA[] powerOfAttorneys, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreatePOARequest>(bfsApiClientName);

            request.Entities = powerOfAttorneys;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreatePOAsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/446464135/DeletePOAs
        /// </summary>
        /// <param name="powerOfAttorneyIds"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<string> DeletePowerOfAttorneysAsync(Guid[] powerOfAttorneyIds, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeletePoaRequest>(bfsApiClientName);

            request.BrickIds = powerOfAttorneyIds;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.DeletePOAsAsync(request);

            if (ValidateResponse(response)) return response.Message;

            LogErrors(response.Message);

            return response.Message;
        }
    }
}