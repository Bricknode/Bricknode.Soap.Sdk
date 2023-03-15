using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsTransactionNoteService : BfsServiceBase, IBfsTransactionNoteService
    {
        public BfsTransactionNoteService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1759772715/GetTransactionNotes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTransactionNoteResponse> GetTransactionNotesAsync(GetTransactionNoteArgs filters,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetTransactionNoteRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTransactionNoteFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetTransactionNotesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}