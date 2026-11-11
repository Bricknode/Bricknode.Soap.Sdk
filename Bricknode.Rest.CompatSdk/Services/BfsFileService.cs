using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using RestApi = global::Bricknode.Rest.CompatSdk;

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

            var client = await GetClientAsync<RestApi.FileHandlingClient>(bfsApiClientName);
            var restResponse = await client.GetFileAsync(BfsJsonMapper.Map<RestApi.GetFileRequest>(request));
            var response = BfsJsonMapper.Map<GetFileResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.FileHandlingClient>(bfsApiClientName);
            var restResponse = await client.GetFileListAsync(BfsJsonMapper.Map<RestApi.GetFileListRequest>(request));
            var response = BfsJsonMapper.Map<GetFileListResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.FileHandlingClient>(bfsApiClientName);
            var restResponse = await client.CreateFileAsync(BfsJsonMapper.Map<RestApi.CreateFileRequest>(request));
            var response = BfsJsonMapper.Map<CreateFileResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.FileHandlingClient>(bfsApiClientName);
            var restResponse = await client.DeleteFileAsync(BfsJsonMapper.Map<RestApi.DeleteFileRequest>(request));
            var response = BfsJsonMapper.Map<DeleteFileResponse>(restResponse)!;

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

            var client = await GetClientAsync<RestApi.FileHandlingClient>(bfsApiClientName);
            var restResponse = await client.DeleteFilesAsync(BfsJsonMapper.Map<RestApi.DeleteFilesRequest>(request));
            var response = BfsJsonMapper.Map<DeleteFilesResponse>(restResponse)!;

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}