using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsTransferReceiverService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/60031203/GetTransferReceiver
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetTransferReceiversResponse> GetTransferReceiversAsync(GetTransferReceiversArgs filters, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/175177771/CreateTransferReceivers
        /// </summary>
        /// <param name="transferReceivers"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateTransferReceiversResponse> CreateTransferReceiversAsync(TransferReceiver[] transferReceivers, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/175800361/UpdateTransferReceivers
        /// </summary>
        /// <param name="updateTransferReceivers"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateTransferReceiversResponse> UpdateTransferReceiversAsync(UpdateTransferReceiver[] updateTransferReceivers, UpdateTransferReceiverFields fieldsToUpdate, string? bfsApiClientName = null);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/175800361/UpdateTransferReceiverStates
        /// </summary>
        /// <param name="updateTransferReceiverStates"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateTransferReceiverStatesResponse> UpdateTransferReceiverStatesAsync(UpdateTransferReceiverState[] updateTransferReceiverStates, UpdateTransferReceiverStatesFields fieldsToUpdate, string? bfsApiClientName = null);
    }
}