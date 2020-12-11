using System.Linq;
using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsTransactionNoteService : BfsServiceBase, IBfsTransactionNoteService
    {
        public BfsTransactionNoteService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger,
            bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1759772715/GetTransactionNotes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTransactionNoteResponse> GetTransactionNotesAsync(GetTransactionNoteArgs filters,
            string bfsApiClientName = null)
        {
            var request = GetRequest<GetTransactionNoteRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTransactionNoteFields>();

            var response = await GetClient(bfsApiClientName).GetTransactionNotesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result.ToArray<EntityBase>());

            return response;
        }
    }
}