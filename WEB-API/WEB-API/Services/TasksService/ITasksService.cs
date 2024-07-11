using WEB_API.Models;

namespace WEB_API.Services.TasksService
{
    public class ITasksService : ITasksInterface
    {
        public async Task<ServiceResponseModel<List<TasksModel>>> CreateTask(TasksModel newTask)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponseModel<List<TasksModel>>> UpdateTask(TasksModel editTask)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel<List<TasksModel>>> DeleteTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel<List<TasksModel>>> GetTasks()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel<TasksModel>> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
