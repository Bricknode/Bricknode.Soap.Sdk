using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsMessageService
    {
        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128267799/GetMessages
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetMessagesResponse> GetMessagesAsync(GetMessagesArgs filters, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128169594/CreateMessages
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateMessagesResponse> CreateMessagesAsync(CreateMessage[] messages, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128726532/UpdateMessages
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateMessageResponse> UpdateMessagesAsync(UpdateMessage[] messages,
            UpdateMessageFields fieldsToUpdate, string? bfsApiClientName = null);
    }
}