using WEB_API.Models;

namespace WEB_API.Services.TasksService
{
    public class ITasksService : ITasksInterface
    {
        public Task<List<TasksModel>> CreateTask(TasksModel newTask)
        {
            throw new NotImplementedException();
        }
        public Task<List<TasksModel>> UpdateTask(TasksModel editTask)
        {
            throw new NotImplementedException();
        }

        public Task<List<TasksModel>> DeleteTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TasksModel>> GetTasks()
        {
            throw new NotImplementedException();
        }

        public Task<TasksModel> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
