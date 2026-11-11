using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    using System.Collections.Generic;
    using Factories;

    public class BfsLegalEntitiesService : BfsServiceBase, IBfsLegalEntitiesService
    {
        public BfsLegalEntitiesService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
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

            var client = await GetClientAsync<RestApi.PersonsClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetPersonRequest>(request));
            var response = BfsJsonMapper.Map<GetPersonResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        public async IAsyncEnumerable<GetPersonResponse> GetLegalEntitiesInPagesAsync(GetPersonArgs filters, GetPersonFields? fields = null, int pageSize = 2000, int pageStartIndex = 0, string? bfsApiClientName = null)
        {
            GetPersonResponse response;
            bool isValidResponse;
            var pageIndex = pageStartIndex;
            var client = await GetClientAsync<RestApi.PersonsClient>(bfsApiClientName);
            var request = await GetRequestAsync<GetPersonRequest>(bfsApiClientName);

            request.Args = filters;
            request.Fields = fields ?? GetFields<GetPersonFields>();
            request.EnablePagination = true;
            request.PageSize = pageSize;

            do
            {
                request.PageIndex = pageIndex++;
                var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetPersonRequest>(request));
                response = BfsJsonMapper.Map<GetPersonResponse>(restResponse)!;
                isValidResponse = ValidateResponse(response);

                if (!isValidResponse)
                {
                    LogErrors(response.Result);
                }

                yield return response;
            } while (isValidResponse && response.Result.Length >= pageSize);
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

            var client = await GetClientAsync<RestApi.PersonsClient>(bfsApiClientName);
            var restResponse = await client.CreateAsync(BfsJsonMapper.Map<RestApi.CreatePersonRequest>(request));
            var response = BfsJsonMapper.Map<CreatePersonResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.PersonsClient>(bfsApiClientName);
            var restResponse = await client.UpdateAsync(BfsJsonMapper.Map<RestApi.UpdatePersonsRequest>(request));
            var response = BfsJsonMapper.Map<UpdatePersonsResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.HouseClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetHouseInformationRequest>(request));
            var response = BfsJsonMapper.Map<GetHouseInformationResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.DecisionMakersClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetDecisionMakerRequest>(request));
            var response = BfsJsonMapper.Map<GetDecisionMakerResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.FundCompaniesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetFundCompaniesRequest>(request));
            var response = BfsJsonMapper.Map<GetFundCompaniesResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.FundEntitiesClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetFundEntityRequest>(request));
            var response = BfsJsonMapper.Map<GetFundEntityResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}