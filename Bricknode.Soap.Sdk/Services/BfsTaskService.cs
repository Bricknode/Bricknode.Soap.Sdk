using System.Threading.Tasks;
using BfsApi;
using Bricknode.Soap.Sdk.Services.Bases;
using Microsoft.Extensions.Logging;

namespace Bricknode.Soap.Sdk.Services
{
    using Factories;

    public class BfsTaskService : BfsServiceBase, IBfsTaskService
    {
        public BfsTaskService(IBfsApiClientFactory bfsApiClientFactory, ILogger logger)
            : base(bfsApiClientFactory, logger)
        {
            // no operation
        }

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1123123229/GetTasks
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        public async Task<GetTasksResponse> GetTasksAsync(GetTasksArgs filters, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<GetTasksRequest>(bfsApiClientName);

            request.Args = filters;

            request.Fields = GetFields<GetTasksFields>();

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.GetTasksAsync(request);

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
        public async Task<CreateTasksResponse> CreateTasksAsync(CreateTask[] tasks, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<CreateTasksRequest>(bfsApiClientName);

            request.Entities = tasks;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.CreateTasksAsync(request);

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
            UpdateTaskFields fieldsToUpdate, string? bfsApiClientName = null)
        {
            var request = await GetRequestAsync<UpdateTaskRequest>(bfsApiClientName);

            request.Entities = tasks;

            request.Fields = fieldsToUpdate;

            var client = await GetClientAsync(bfsApiClientName);
            var response = await client.UpdateTasksAsync(request);

            if (ValidateResponse(response)) return response;

            LogErrors(response.Entities);

            return response;
        }
    }
}