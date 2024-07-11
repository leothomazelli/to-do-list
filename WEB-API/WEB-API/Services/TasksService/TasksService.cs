using WEB_API.Models;

namespace WEB_API.Services.TasksService
{
    public class TasksService : ITasksService
    {
        /// <inheritdoc />
        public ServiceResponse<Tasks> Add(Tasks task)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ServiceResponse<Tasks> Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ServiceResponse<Tasks> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ServiceResponse<List<Tasks>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ServiceResponse<Tasks> Update(Tasks task)
        {
            throw new NotImplementedException();
        }
    }
}
