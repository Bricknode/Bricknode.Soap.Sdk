using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsWhiteLabelService : BfsServiceBase, IBfsWhiteLabelService
    {
        public BfsWhiteLabelService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/435552259/GetWhiteLabels
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetWhiteLabelResponse> GetWhiteLabelsAsync(GetWhiteLabelArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetWhiteLabelRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetWhiteLabelFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetWhiteLabelsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/435585030/CreateWhiteLabels
        /// </summary>
        /// <param name="whiteLabels"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateWhiteLabelResponse> CreateWhiteLabelsAsync(WhiteLabel[] whiteLabels, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateWhiteLabelRequest>(bfsApiClientName);

            request.Entities = whiteLabels;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateWhiteLabelsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/435650564/UpdateWhiteLabel
        /// </summary>
        /// <param name="updateWhiteLabels"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateWhiteLabelResponse> UpdateWhiteLabelsAsync(UpdateWhiteLabel[] updateWhiteLabels,
            UpdateWhiteLabelFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateWhiteLabelsRequest>(bfsApiClientName);

            request.Entities = updateWhiteLabels;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateWhiteLabelAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}