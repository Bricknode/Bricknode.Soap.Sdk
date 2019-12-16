using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsLegalEntitiesService : BfsServiceBase, IBfsLegalEntitiesService
    {
        private readonly bfsapiSoap _client;

        public BfsLegalEntitiesService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client) : base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        /// <summary>
        ///     This method is used to get legal entities from BFS (BFS calls these for Persons).
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/57639002/GetPersons
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetPersonResponse> GetLegalEntitiesAsync(GetPersonArgs filters)
        {
            var request = GetRequest<GetPersonRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetPersonFields>();

            var response = await _client.GetPersonsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/57639004/CreatePersons
        /// </summary>
        /// <param name="legalEntities"></param>
        /// <returns></returns>
        public async Task<CreatePersonResponse> CreateLegalEntitiesAsync(Person[] legalEntities)
        {
            var request = GetRequest<CreatePersonRequest>();

            request.Entities = legalEntities;

            var response = await _client.CreatePersonsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/62193734/UpdatePersons
        /// </summary>
        /// <param name="legalEntities"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdatePersonsResponse> UpdateLegalEntitiesAsync(UpdatePerson[] legalEntities,
            UpdatePersonFields fieldsToUpdate)
        {
            var request = GetRequest<UpdatePersonsRequest>();

            request.Entities = legalEntities;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdatePersonsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     Get information about the house entity.
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/123666446/GetHouseInformation
        /// </summary>
        /// <returns></returns>
        public async Task<GetHouseInformationResponse> GetHouseInformationAsync()
        {
            var request = GetRequest<GetHouseInformationRequest>();

            request.Fields = GetFields<GetHouseInformationFields>();

            var response = await _client.GetHouseInformationAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/182911013/GetDecisionMakers
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetDecisionMakerResponse> GetDecisionMakersAsync(GetDecisionMakerArgs filters)
        {
            var request = GetRequest<GetDecisionMakerRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetDecisionMakerFields>();

            var response = await _client.GetDecisionMakersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/86507555/GetFundCompanies
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetFundCompaniesResponse> GetFundCompaniesAsync(GetFundCompaniesArgs filters)
        {
            var request = GetRequest<GetFundCompaniesRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetFundCompaniesFields>();

            var response = await _client.GetFundCompaniesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/86507559/GetFundEntity
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetFundEntityResponse> GetFundEntitiesAsync(GetFundEntityArgs filters)
        {
            var request = GetRequest<GetFundEntityRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetFundEntityFields>();

            var response = await _client.GetFundEntityAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}