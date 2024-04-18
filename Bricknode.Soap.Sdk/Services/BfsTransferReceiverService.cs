using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsTransferReceiverService : BfsServiceBase, IBfsTransferReceiverService
    {
        public BfsTransferReceiverService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031203/GetTransferReceiver
        ///     Use BfsLookups.TransferReceiverTypeKey to get the options for the TransferReceiverTypeKeys property
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTransferReceiversResponse> GetTransferReceiversAsync(GetTransferReceiversArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetTransferReceiversRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTransferReceiverFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetTransferReceiversAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/175177771/CreateTransferReceivers
        /// </summary>
        /// <param name="transferReceivers"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateTransferReceiversResponse> CreateTransferReceiversAsync(
            TransferReceiver[] transferReceivers, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateTransferReceiversRequest>(bfsApiClientName);

            request.Entities = transferReceivers;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateTransferReceiversAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/175800361/UpdateTransferReceivers
        /// </summary>
        /// <param name="updateTransferReceivers"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateTransferReceiversResponse> UpdateTransferReceiversAsync(
            UpdateTransferReceiver[] updateTransferReceivers, UpdateTransferReceiverFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateTransferReceiversRequest>(bfsApiClientName);

            request.Entities = updateTransferReceivers;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateTransferReceiversAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/175800361/UpdateTransferReceiverStates
        /// </summary>
        /// <param name="updateTransferReceiverStates"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateTransferReceiverStatesResponse> UpdateTransferReceiverStatesAsync(
            UpdateTransferReceiverState[] updateTransferReceiverStates, UpdateTransferReceiverStatesFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateTransferReceiverStatesRequest>(bfsApiClientName);

            request.Entities = updateTransferReceiverStates;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateTransferReceiverStatesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}