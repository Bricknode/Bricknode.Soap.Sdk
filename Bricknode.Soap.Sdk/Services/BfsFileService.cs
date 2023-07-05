using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsFileService : BfsServiceBase, IBfsFileService
    {
        public BfsFileService(IBfsApiClientFactory bfsApiClientFactory, ILogger<BfsService>? logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701155/GetFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFileResponse> GetFileAsync(FileInfoGeneral fileInfo, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFileRequest>(bfsApiClientName);

            request.FileInfoGet = fileInfo;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetFileAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701150/GetFileList
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFileListResponse> GetFileListAsync(GetFileInfoArgs fileInfo, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetFileListRequest>(bfsApiClientName);

            request.Args = fileInfo;

            request.Fields = GetFields<GetFileInfoFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetFileListAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701159/CreateFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateFileResponse> CreateFileAsync(FileInfoUpload fileInfo, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateFileRequest>(bfsApiClientName);

            request.FileInfoUpload = fileInfo;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateFileAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701165/DeleteFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<DeleteFileResponse> DeleteFileAsync(FileInfoGeneral fileInfo, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteFileRequest>(bfsApiClientName);

            request.FileInfoDelete = fileInfo;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.DeleteFileAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        /// https://bricknode.atlassian.net/wiki/spaces/API/pages/3353083905/DeleteFiles
        /// </summary>
        /// <param name="fileInfos"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<DeleteFilesResponse> DeleteFilesAsync(FileInfoGeneral[] fileInfos,
            string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<DeleteFilesRequest>(bfsApiClientName);

            request.FileInfoDeletes = fileInfos;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.DeleteFilesAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}