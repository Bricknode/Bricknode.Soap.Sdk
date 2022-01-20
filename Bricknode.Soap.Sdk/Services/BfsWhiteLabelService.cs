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

    public class BfsWhiteLabelService : BfsServiceBase, IBfsWhiteLabelService
    {
        private readonly bfsapiSoap _client;

        public BfsWhiteLabelService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/435552259/GetWhiteLabels
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetWhiteLabelResponse> GetWhiteLabelsAsync(GetWhiteLabelArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetWhiteLabelRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetWhiteLabelFields>();

            var response = await GetClient(bfsApiClientName).GetWhiteLabelsAsync(request);

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
        public async Task<CreateWhiteLabelResponse> CreateWhiteLabelsAsync(WhiteLabel[] whiteLabels, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateWhiteLabelRequest>(bfsApiClientName);

            request.Entities = whiteLabels;

            var response = await GetClient(bfsApiClientName).CreateWhiteLabelsAsync(request);

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
            UpdateWhiteLabelFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateWhiteLabelsRequest>(bfsApiClientName);

            request.Entities = updateWhiteLabels;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateWhiteLabelAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}