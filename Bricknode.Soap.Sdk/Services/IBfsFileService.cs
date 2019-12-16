using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsFileService
    {
        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/63701155/GetFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        Task<GetFileResponse> GetFileAsync(FileInfoGeneral fileInfo);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/63701150/GetFileList
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        Task<GetFileListResponse> GetFileListAsync(GetFileInfoArgs fileInfo);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/63701159/CreateFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        Task<CreateFileResponse> CreateFileAsync(FileInfoUpload fileInfo);

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/63701165/DeleteFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        Task<DeleteFileResponse> DeleteFileAsync(FileInfoGeneral fileInfo);
    }
}