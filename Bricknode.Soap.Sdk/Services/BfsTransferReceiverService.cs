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

    public class BfsTransferReceiverService : BfsServiceBase, IBfsTransferReceiverService
    {
        private readonly bfsapiSoap _client;

        public BfsTransferReceiverService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031203/GetTransferReceiver
        ///     Use BfsLookups.TransferReceiverTypeKey to get the options for the TransferReceiverTypeKeys property
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTransferReceiversResponse> GetTransferReceiversAsync(GetTransferReceiversArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetTransferReceiversRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTransferReceiverFields>();

            var response = await GetClient(bfsApiClientName).GetTransferReceiversAsync(request);

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
            TransferReceiver[] transferReceivers, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateTransferReceiversRequest>(bfsApiClientName);

            request.Entities = transferReceivers;

            var response = await GetClient(bfsApiClientName).CreateTransferReceiversAsync(request);

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
            UpdateTransferReceiver[] updateTransferReceivers, UpdateTransferReceiverFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateTransferReceiversRequest>(bfsApiClientName);

            request.Entities = updateTransferReceivers;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateTransferReceiversAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}