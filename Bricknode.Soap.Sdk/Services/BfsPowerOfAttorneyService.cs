using System;
using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsPowerOfAttorneyService : BfsServiceBase, IBfsPowerOfAttorneyService
    {
        private readonly bfsapiSoap _client;

        public BfsPowerOfAttorneyService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/148248270/GetPOAS
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetPOAResponse> GetPowerOfAttorneys(GetPOAArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetPOARequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetPOAFields>();

            var response = await GetClient(bfsApiClientName).GetPOASAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031200/GetPOATypes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetPOATypeResponse> GetPowerOfAttorneyTypesAsync(GetPOATypeArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetPOATypeRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetPOATypeFields>();

            var response = await GetClient(bfsApiClientName).GetPOATypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/93552801/CreatePOAs
        /// </summary>
        /// <param name="powerOfAttorneys"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreatePOAResponse> CreatePowerOfAttorneysAsync(POA[] powerOfAttorneys, string bfsApiClientName = null)
        {
            var request = GetRequest<CreatePOARequest>(bfsApiClientName);

            request.Entities = powerOfAttorneys;

            var response = await GetClient(bfsApiClientName).CreatePOAsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/446464135/DeletePOAs
        /// </summary>
        /// <param name="powerOfAttorneyIds"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<string> DeletePowerOfAttorneysAsync(Guid[] powerOfAttorneyIds, string bfsApiClientName = null)
        {
            var request = GetRequest<DeletePoaRequest>(bfsApiClientName);

            request.BrickIds = powerOfAttorneyIds;

            var response = await GetClient(bfsApiClientName).DeletePOAsAsync(request);

            if (ValidateResponse(response)) return response.Message;

            LogErrors(response.Message);

            return response.Message;
        }
    }
}