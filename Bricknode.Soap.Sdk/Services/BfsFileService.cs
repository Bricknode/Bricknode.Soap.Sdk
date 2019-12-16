using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    public class BfsFileService : BfsServiceBase, IBfsFileService
    {
        private readonly bfsapiSoap _client;

        public BfsFileService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client) :
            base(bfsApiConfiguration, logger)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701155/GetFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public async Task<GetFileResponse> GetFileAsync(FileInfoGeneral fileInfo)
        {
            var request = GetRequest<GetFileRequest>();

            request.FileInfoGet = fileInfo;

            var response = await _client.GetFileAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701150/GetFileList
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public async Task<GetFileListResponse> GetFileListAsync(GetFileInfoArgs fileInfo)
        {
            var request = GetRequest<GetFileListRequest>();

            request.Args = fileInfo;

            request.Fields = GetFields<GetFileInfoFields>();

            var response = await _client.GetFileListAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701159/CreateFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public async Task<CreateFileResponse> CreateFileAsync(FileInfoUpload fileInfo)
        {
            var request = GetRequest<CreateFileRequest>();

            request.FileInfoUpload = fileInfo;

            var response = await _client.CreateFileAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701165/DeleteFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public async Task<DeleteFileResponse> DeleteFileAsync(FileInfoGeneral fileInfo)
        {
            var request = GetRequest<DeleteFileRequest>();

            request.FileInfoDelete = fileInfo;

            var response = await _client.DeleteFileAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}