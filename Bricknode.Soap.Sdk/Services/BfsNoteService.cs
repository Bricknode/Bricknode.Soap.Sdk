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

    public class BfsNoteService : BfsServiceBase, IBfsNoteService
    {
        public BfsNoteService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {

        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1122894013/GetNotes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetNotesResponse> GetNotesAsync(GetNotesArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetNotesRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetNotesFields>();

            var response = await GetClient(bfsApiClientName).GetNotesAsync(request);

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
        public async Task<CreateNotesResponse> CreateNotesAsync(CreateNote[] notes, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateNotesRequest>(bfsApiClientName);

            request.Entities = notes;

            var response = await GetClient(bfsApiClientName).CreateNotesAsync(request);

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
            UpdateNoteFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateNoteRequest>(bfsApiClientName);

            request.Entities = notes;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateNotesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}