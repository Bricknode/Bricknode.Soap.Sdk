using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsWhiteLabelService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/435552259/GetWhiteLabels
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<GetWhiteLabelResponse> GetWhiteLabelsAsync(GetWhiteLabelArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/435585030/CreateWhiteLabels
        /// </summary>
        /// <param name="whiteLabels"></param>
        /// <returns></returns>
        Task<CreateWhiteLabelResponse> CreateWhiteLabelsAsync(WhiteLabel[] whiteLabels);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/435650564/UpdateWhiteLabel
        /// </summary>
        /// <param name="updateWhiteLabels"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        Task<UpdateWhiteLabelResponse> UpdateWhiteLabelsAsync(UpdateWhiteLabel[] updateWhiteLabels, UpdateWhiteLabelFields fieldsToUpdate);
    }
}