using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsNoteService : BfsServiceBase, IBfsNoteService
    {
        public BfsNoteService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1122894013/GetNotes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetNotesResponse> GetNotesAsync(GetNotesArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetNotesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetNotesFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetNotesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1123221693/CreateNotes
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateNotesResponse> CreateNotesAsync(CreateNote[] notes, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateNotesRequest>(bfsApiClientName);

            request.Entities = notes;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateNotesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128497184/UpdateNotes
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateNoteResponse> UpdateNotesAsync(UpdateNote[] notes,
            UpdateNoteFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateNoteRequest>(bfsApiClientName);

            request.Entities = notes;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateNotesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}