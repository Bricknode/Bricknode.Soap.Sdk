using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsMessageService : BfsServiceBase, IBfsMessageService
    {
        public BfsMessageService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128267799/GetMessages
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetMessagesResponse> GetMessagesAsync(GetMessagesArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetMessagesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetMessagesFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetMessagesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128169594/CreateMessages
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateMessagesResponse> CreateMessagesAsync(CreateMessage[] messages, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateMessagesRequest>(bfsApiClientName);

            request.Entities = messages;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateMessagesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

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
            UpdateMessageFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateMessageRequest>(bfsApiClientName);

            request.Entities = messages;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateMessagesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}