using WEB_API.Models;

namespace WEB_API.Services.TasksService
{
    public interface ITasksInterface
    {
        Task<List<TasksModel>> CreateTask(TasksModel newTask);
        Task<List<TasksModel>> UpdateTask(TasksModel editTask);
        Task<List<TasksModel>> DeleteTaskById(int id);
        Task<List<TasksModel>> GetTasks();
        Task<TasksModel> GetTaskById(int id);
    }
}
