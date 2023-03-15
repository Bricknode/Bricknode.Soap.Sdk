using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsLegalEntitiesService : BfsServiceBase, IBfsLegalEntitiesService
    {
        public BfsLegalEntitiesService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     This method is used to get legal entities from BFS (BFS calls these for Persons).
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/57639002/GetPersons
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetPersonResponse> GetLegalEntitiesAsync(GetPersonArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetPersonRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetPersonFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetPersonsAsync(request);

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
        public async Task<CreatePersonResponse> CreateLegalEntitiesAsync(Person[] legalEntities, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreatePersonRequest>(bfsApiClientName);

            request.Entities = legalEntities;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreatePersonsAsync(request);

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
            UpdatePersonFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdatePersonsRequest>(bfsApiClientName);

            request.Entities = legalEntities;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdatePersonsAsync(request);

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
        public async Task<GetHouseInformationResponse> GetHouseInformationAsync(string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetHouseInformationRequest>(bfsApiClientName);

            request.Fields = GetFields<GetHouseInformationFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetHouseInformationAsync(request);

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
        public async Task<GetDecisionMakerResponse> GetDecisionMakersAsync(GetDecisionMakerArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetDecisionMakerRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetDecisionMakerFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetDecisionMakersAsync(request);

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
        public async Task<GetFundCompaniesResponse> GetFundCompaniesAsync(GetFundCompaniesArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFundCompaniesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFundCompaniesFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetFundCompaniesAsync(request);

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
        public async Task<GetFundEntityResponse> GetFundEntitiesAsync(GetFundEntityArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFundEntityRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetFundEntityFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetFundEntityAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}