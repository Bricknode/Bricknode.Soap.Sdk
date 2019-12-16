using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsLegalEntitiesService
    {
        Task<GetPersonResponse> GetLegalEntitiesAsync(GetPersonArgs filters);
        Task<CreatePersonResponse> CreateLegalEntitiesAsync(Person[] legalEntities);
        Task<UpdatePersonsResponse> UpdateLegalEntitiesAsync(UpdatePerson[] legalEntities, UpdatePersonFields fieldsToUpdate);
        Task<GetHouseInformationResponse> GetHouseInformationAsync();
        Task<GetDecisionMakerResponse> GetDecisionMakersAsync(GetDecisionMakerArgs filters);
        Task<GetFundCompaniesResponse> GetFundCompaniesAsync(GetFundCompaniesArgs filters);
        Task<GetFundEntityResponse> GetFundEntitiesAsync(GetFundEntityArgs filters);
    }
}