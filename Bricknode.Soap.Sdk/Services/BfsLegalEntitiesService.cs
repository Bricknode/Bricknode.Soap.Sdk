using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsLegalEntitiesService : BfsServiceBase, IBfsLegalEntitiesService
    {
        private readonly bfsapiSoap _client;

        public BfsLegalEntitiesService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     This method is used to get legal entities from BFS (BFS calls these for Persons).
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/57639002/GetPersons
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetPersonResponse> GetLegalEntitiesAsync(GetPersonArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetPersonRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetPersonFields>();

            var response = await GetClient(bfsApiClientName).GetPersonsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/57639004/CreatePersons
        /// </summary>
        /// <param name="legalEntities"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreatePersonResponse> CreateLegalEntitiesAsync(Person[] legalEntities, string bfsApiClientName = null)
        {
            var request = GetRequest<CreatePersonRequest>(bfsApiClientName);

            request.Entities = legalEntities;

            var response = await GetClient(bfsApiClientName).CreatePersonsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/62193734/UpdatePersons
        /// </summary>
        /// <param name="legalEntities"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdatePersonsResponse> UpdateLegalEntitiesAsync(UpdatePerson[] legalEntities,
            UpdatePersonFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdatePersonsRequest>(bfsApiClientName);

            request.Entities = legalEntities;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdatePersonsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     Get information about the house entity.
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/123666446/GetHouseInformation
        /// </summary>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetHouseInformationResponse> GetHouseInformationAsync(string bfsApiClientName = null)
        {
            var request = GetRequest<GetHouseInformationRequest>(bfsApiClientName);

            request.Fields = GetFields<GetHouseInformationFields>();

            var response = await GetClient(bfsApiClientName).GetHouseInformationAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/182911013/GetDecisionMakers
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetDecisionMakerResponse> GetDecisionMakersAsync(GetDecisionMakerArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetDecisionMakerRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetDecisionMakerFields>();

            var response = await GetClient(bfsApiClientName).GetDecisionMakersAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/86507555/GetFundCompanies
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFundCompaniesResponse> GetFundCompaniesAsync(GetFundCompaniesArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetFundCompaniesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFundCompaniesFields>();

            var response = await GetClient(bfsApiClientName).GetFundCompaniesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/86507559/GetFundEntity
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFundEntityResponse> GetFundEntitiesAsync(GetFundEntityArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetFundEntityRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFundEntityFields>();

            var response = await GetClient(bfsApiClientName).GetFundEntityAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}