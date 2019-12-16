using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsTransferReceiverService : BfsServiceBase, IBfsTransferReceiverService
    {
        private readonly bfsapiSoap _client;

        public BfsTransferReceiverService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client) : base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/60031203/GetTransferReceiver
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<GetTransferReceiversResponse> GetTransferReceiversAsync(GetTransferReceiversArgs filters)
        {
            var request = GetRequest<GetTransferReceiversRequest>();

            request.Args = filters;

            request.Fields = GetFields<GetTransferReceiverFields>();

            var response = await _client.GetTransferReceiversAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/175177771/CreateTransferReceivers
        /// </summary>
        /// <param name="transferReceivers"></param>
        /// <returns></returns>
        public async Task<CreateTransferReceiversResponse> CreateTransferReceiversAsync(
            TransferReceiver[] transferReceivers)
        {
            var request = GetRequest<CreateTransferReceiversRequest>();

            request.Entities = transferReceivers;

            var response = await _client.CreateTransferReceiversAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/175800361/UpdateTransferReceivers
        /// </summary>
        /// <param name="updateTransferReceivers"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <returns></returns>
        public async Task<UpdateTransferReceiversResponse> UpdateTransferReceiversAsync(
            UpdateTransferReceiver[] updateTransferReceivers, UpdateTransferReceiverFields fieldsToUpdate)
        {
            var request = GetRequest<UpdateTransferReceiversRequest>();

            request.Entities = updateTransferReceivers;

            request.Fields = fieldsToUpdate;

            var response = await _client.UpdateTransferReceiversAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities.ToArray<EntityBase>());

            return response;
        }
    }
}