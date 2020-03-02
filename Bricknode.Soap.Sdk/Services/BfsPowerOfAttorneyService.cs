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
        /// <returns></returns>
        public async Task<GetPOAResponse> GetPowerOfAttorneys(GetPOAArgs filters)
        {
            var request = GetRequest<GetPOARequest>();

            request.Args = filters;

            request.Fields = GetFields<GetPOAFields>();

            var response = await _client.GetPOASAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031200/GetPOATypes
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetPOATypeResponse> GetPowerOfAttorneyTypesAsync(GetPOATypeArgs filters)
        {
            var request = GetRequest<GetPOATypeRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetPOATypeFields>();

            var response = await _client.GetPOATypesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/93552801/CreatePOAs
        /// </summary>
        /// <param name="powerOfAttorneys"></param>
        /// <returns></returns>
        public async Task<CreatePOAResponse> CreatePowerOfAttorneysAsync(POA[] powerOfAttorneys)
        {
            var request = GetRequest<CreatePOARequest>();

            request.Entities = powerOfAttorneys;

            var response = await _client.CreatePOAsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/446464135/DeletePOAs
        /// </summary>
        /// <param name="powerOfAttorneyIds"></param>
        /// <returns></returns>
        public async Task<string> DeletePowerOfAttorneysAsync(Guid[] powerOfAttorneyIds)
        {
            var request = GetRequest<DeletePoaRequest>();

            request.BrickIds = powerOfAttorneyIds;

            var response = await _client.DeletePOAsAsync(request);

            if (ValidateResponse(response)) return response.Message;

            LogErrors(response.Message);

            return response.Message;
        }
    }
}