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

    public class BfsMessagesService : BfsServiceBase, IBfsMessagesService
    {
        public BfsMessagesService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128267799/GetMessages
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetMessagesResponse> GetMessagesAsync(GetMessagesArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetMessagesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetMessagesFields>();

            var response = await GetClient(bfsApiClientName).GetMessagesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128169594/CreateMessages
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateMessagesResponse> CreateMessagesAsync(CreateMessage[] messages, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateMessagesRequest>(bfsApiClientName);

            request.Entities = messages;

            var response = await GetClient(bfsApiClientName).CreateMessagesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128726532/UpdateMessages
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateMessageResponse> UpdateMessagesAsync(UpdateMessage[] messages,
            UpdateMessageFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateMessageRequest>(bfsApiClientName);

            request.Entities = messages;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateMessagesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }
    }
}