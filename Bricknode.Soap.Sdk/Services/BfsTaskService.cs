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

    public class BfsTaskService : BfsServiceBase, IBfsTaskService
    {
        public BfsTaskService(IOptions<BfsApiConfiguration> bfsApiConfiguration, ILogger logger, bfsapiSoap client, IBfsApiClientFactory bfsApiClientFactory) :
            base(bfsApiConfiguration, logger, bfsApiClientFactory, client)
        {
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1123123229/GetTasks
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTasksResponse> GetTasksAsync(GetTasksArgs filters, string bfsApiClientName = null)
        {
            var request = GetRequest<GetTasksRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTasksFields>();

            var response = await GetClient(bfsApiClientName).GetTasksAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Result);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1122664558/CreateTasks
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<CreateTasksResponse> CreateTasksAsync(CreateTask[] tasks, string bfsApiClientName = null)
        {
            var request = GetRequest<CreateTasksRequest>(bfsApiClientName);

            request.Entities = tasks;

            var response = await GetClient(bfsApiClientName).CreateTasksAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1122959430/UpdateTasks
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<UpdateTaskResponse> UpdateTasksAsync(UpdateTask[] tasks,
            UpdateTaskFields fieldsToUpdate, string bfsApiClientName = null)
        {
            var request = GetRequest<UpdateTaskRequest>(bfsApiClientName);

            request.Entities = tasks;

            request.Fields = fieldsToUpdate;

            var response = await GetClient(bfsApiClientName).UpdateTasksAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}