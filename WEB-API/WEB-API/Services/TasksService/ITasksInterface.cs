using WEB_API.Models;

namespace WEB_API.Services.TasksService
{
    public interface ITasksInterface
    {
        Task<ServiceResponseModel<List<TasksModel>>> CreateTask(TasksModel newTask);
        Task<ServiceResponseModel<List<TasksModel>>> UpdateTask(TasksModel editTask);
        Task<ServiceResponseModel<List<TasksModel>>> DeleteTaskById(int id);
        Task<ServiceResponseModel<List<TasksModel>>> GetTasks();
        Task<ServiceResponseModel<TasksModel>> GetTaskById(int id);
    }
}
