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
        /// <returns></returns>
        Task<GetTransferReceiversResponse> GetTransferReceiversAsync(GetTransferReceiversArgs filters);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/175177771/CreateTransferReceivers
        /// </summary>
        /// <param name="transferReceivers"></param>
        /// <returns></returns>
        Task<CreateTransferReceiversResponse> CreateTransferReceiversAsync(TransferReceiver[] transferReceivers);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/175800361/UpdateTransferReceivers
        /// </summary>
        /// <param name="updateTransferReceivers"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        Task<UpdateTransferReceiversResponse> UpdateTransferReceiversAsync(UpdateTransferReceiver[] updateTransferReceivers, UpdateTransferReceiverFields fieldsToUpdate);
    }
}