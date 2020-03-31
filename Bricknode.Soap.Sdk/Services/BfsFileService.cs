using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Configuration;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsFileService : BfsServiceBase, IBfsFileService
    {
        private readonly bfsapiSoap _client;

        public BfsFileService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
            _client = client;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/63701155/GetFile
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetFileResponse> GetFileAsync(FileInfoGeneral fileInfo, string bfsApiClientName = null)
        {
            var request = GetRequest<GetFileRequest>(bfsApiClientName);

            request.FileInfoGet = fileInfo;

            var response = await GetClient(bfsApiClientName).GetFileAsync(request);

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
        public async Task<GetFileListResponse> GetFileListAsync(GetFileInfoArgs fileInfo, string bfsApiClientName = null)
        {
            var request = GetRequest<GetFileListRequest>(bfsApiClientName);

            request.Args = fileInfo;

            request.Fields = GetFields<GetFileInfoFields>();

            var response = await GetClient(bfsApiClientName).GetFileListAsync(request);

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
        public async Task<CreateFileResponse> CreateFileAsync(FileInfoUpload fileInfo, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateFileRequest>(bfsApiClientName);

            request.FileInfoUpload = fileInfo;

            var response = await GetClient(bfsApiClientName).CreateFileAsync(request);

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
        public async Task<DeleteFileResponse> DeleteFileAsync(FileInfoGeneral fileInfo, string bfsApiClientName = null)
        {
            var request = GetRequest<DeleteFileRequest>(bfsApiClientName);

            request.FileInfoDelete = fileInfo;

            var response = await GetClient(bfsApiClientName).DeleteFileAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Message);

            return response;
        }
    }
}