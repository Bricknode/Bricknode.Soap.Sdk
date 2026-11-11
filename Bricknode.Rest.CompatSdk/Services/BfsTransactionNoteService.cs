using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Factories;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace Bricknode.Soap.Sdk.Services
{
    /// <summary>
    /// REST-backed drop-in replacement for the SOAP <c>BfsTransactionNoteService</c>.
    /// Public surface is identical; internally it maps the SOAP-shaped <c>BfsApi.*</c> DTOs to the
    /// generated REST records (<see cref="BfsJsonMapper"/>) and calls the REST resource clients.
    /// </summary>
    public class BfsTransactionNoteService : BfsServiceBase, IBfsTransactionNoteService
    {
        public BfsTransactionNoteService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
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

            var client = await GetClientAsync<RestApi.TransactionNoteClient>(bfsApiClientName);
            var restResponse = await client.SearchAsync(BfsJsonMapper.Map<RestApi.GetTransactionNoteRequest>(request));
            var response = BfsJsonMapper.Map<GetTransactionNoteResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }
    }
}