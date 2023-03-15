using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsTaskService
    {
        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1123123229/GetTasks
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<GetTasksResponse> GetTasksAsync(GetTasksArgs filters, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1122664558/CreateTasks
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<CreateTasksResponse> CreateTasksAsync(CreateTask[] tasks, string? bfsApiClientName = null);

        /// <summary>
        ///     https://bricknode.atlassian.net/wiki/spaces/API/pages/1122959430/UpdateTasks
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="fieldsToUpdate"></param>
        /// <param name="bfsApiClientName"></param>
        /// <returns></returns>
        Task<UpdateTaskResponse> UpdateTasksAsync(UpdateTask[] tasks,
            UpdateTaskFields fieldsToUpdate, string? bfsApiClientName = null);
    }
}