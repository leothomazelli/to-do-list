using WEB_API.Models;

namespace WEB_API.Services.TasksService
{
    public class ITasksService : ITasksInterface
    {
        public async Task<ServiceResponse<List<Tasks>>> CreateTask(Tasks newTask)
        {
            ServiceResponse<List<Tasks>> serviceResponse = new ServiceResponse<List<Tasks>>();
            try
            {
                if (newTask == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Informe os dados.";
                    serviceResponse.success = false;
                    return serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.data = null;
                serviceResponse.message = ex.Message;
                serviceResponse.success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Tasks>>> UpdateTask(Tasks editTask)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Tasks>>> DeleteTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Tasks>>> GetTasks()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Tasks>> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
