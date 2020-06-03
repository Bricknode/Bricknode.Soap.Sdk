using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsNoteService
    {
        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1122894013/GetNotes
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetNotesResponse> GetNotesAsync(GetNotesArgs filters, string bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1123221693/CreateNotes
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateNotesResponse> CreateNotesAsync(CreateNote[] notes, string bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1128497184/UpdateNotes
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateNoteResponse> UpdateNotesAsync(UpdateNote[] notes,
            UpdateNoteFields fieldsToUpdate, string bfsApiClientName = null);
    }
}