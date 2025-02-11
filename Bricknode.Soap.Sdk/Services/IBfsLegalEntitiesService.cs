using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    using System.Collections.Generic;

    public interface IBfsLegalEntitiesService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/57639002/GetPersons
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetPersonResponse> GetLegalEntitiesAsync(GetPersonArgs filters, string? bfsApiClientName = null);
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/57639002/GetPersons
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="fields"></param>
        /// <param name="pageSize">Size of each page, supported range is 1 to 5000. The default size is 2000.</param>
        /// <param name="pageStartIndex">Index of the start page. Can be used to skip specific number of pages in enumeration.</param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        IAsyncEnumerable<GetPersonResponse> GetLegalEntitiesInPagesAsync(GetPersonArgs filters, GetPersonFields? fields = null, int pageSize = 2000, int pageStartIndex = 0, string? bfsApiClientName = null);
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/57639004/CreatePersons
        /// </summary>
        /// <param name="legalEntities"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreatePersonResponse> CreateLegalEntitiesAsync(Person[] legalEntities, string? bfsApiClientName = null);
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/62193734/UpdatePersons
        /// </summary>
        /// <param name="legalEntities"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdatePersonsResponse> UpdateLegalEntitiesAsync(UpdatePerson[] legalEntities, UpdatePersonFields fieldsToUpdate, string? bfsApiClientName = null);
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/123666446/GetHouseInformation
        /// </summary>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetHouseInformationResponse> GetHouseInformationAsync(string? bfsApiClientName = null);
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/182911013/GetDecisionMakers
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetDecisionMakerResponse> GetDecisionMakersAsync(GetDecisionMakerArgs filters, string? bfsApiClientName = null);
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/86507555/GetFundCompanies
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetFundCompaniesResponse> GetFundCompaniesAsync(GetFundCompaniesArgs filters, string? bfsApiClientName = null);
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/86507559/GetFundEntity
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetFundEntityResponse> GetFundEntitiesAsync(GetFundEntityArgs filters, string? bfsApiClientName = null);
    }
}