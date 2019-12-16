using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsWhiteLabelService : BfsServiceBase, IBfsWhiteLabelService
    {
        private readonly bfsapiSoap _client;

        public BfsWhiteLabelService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client) : base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/435552259/GetWhiteLabels
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetWhiteLabelResponse> GetWhiteLabelsAsync(GetWhiteLabelArgs filters)
        {
            var request = GetRequest<GetWhiteLabelRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetWhiteLabelFields>();

            var response = await _client.GetWhiteLabelsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/435585030/CreateWhiteLabels
        /// </summary>
        /// <param name="whiteLabels"></param>
        /// <returns></returns>
        public async Task<CreateWhiteLabelResponse> CreateWhiteLabelsAsync(WhiteLabel[] whiteLabels)
        {
            var request = GetRequest<CreateWhiteLabelRequest>();

            request.Entities = whiteLabels;

            var response = await _client.CreateWhiteLabelsAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/435650564/UpdateWhiteLabel
        /// </summary>
        /// <param name="updateWhiteLabels"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdateWhiteLabelResponse> UpdateWhiteLabelsAsync(UpdateWhiteLabel[] updateWhiteLabels,
            UpdateWhiteLabelFields fieldsToUpdate)
        {
            var request = GetRequest<UpdateWhiteLabelsRequest>();

            request.Entities = updateWhiteLabels;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdateWhiteLabelAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }
    }
}