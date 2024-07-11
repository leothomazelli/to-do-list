using WEB_API.Models;

namespace WEB_API.Services.TasksService
{
    public interface ITasksInterface
    {
        Task<ServiceResponse<List<Tasks>>> CreateTask(Tasks newTask);
        Task<ServiceResponse<List<Tasks>>> UpdateTask(Tasks editTask);
        Task<ServiceResponse<List<Tasks>>> DeleteTaskById(int id);
        Task<ServiceResponse<List<Tasks>>> GetTasks();
        Task<ServiceResponse<Tasks>> GetTaskById(int id);
    }
}
