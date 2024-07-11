using WEB_API.Models;
using WEB_API.Repository;

namespace WEB_API.Services.TasksService
{
    public class TasksService : ITasksService
    {
        #region Properties

        /// <summary>
        /// Repository object created to access the Task registers on database using EntityFramework.
        /// </summary>
        private readonly IRepository<Tasks> _repository;

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Tasks constructor created to initialize the "_repository" using Dependency Injection.
        /// </summary>
        /// <param name="repository">IRepository<Tasks> object used to initialize the internal variable using Dependency Injection.</param>
        public TasksService(IRepository<Tasks> repository)
        {
            _repository = repository;
        }


        /// <inheritdoc />
        public ServiceResponse<Tasks> Add(Tasks tasks)
        {
            var response = new ServiceResponse<Tasks>
            {
                data = tasks
            };

            try
            {
                if (tasks == null)
                {
                    throw new Exception("Informe os dados da task.");
                }

                _repository.Add(tasks);
                response.message = "Task cadastrada com sucesso.";
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        /// <inheritdoc />
        public ServiceResponse<Tasks> Update(Tasks tasks)
        {
            var response = new ServiceResponse<Tasks>
            {
                data = tasks
            };

            try
            {
                if (tasks == null)
                {
                    throw new Exception("Informe os dados da task.");
                }

                _repository.Update(tasks);
                response.message = "Task editada com sucesso.";
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        /// <inheritdoc />
        public ServiceResponse<Tasks> Delete(int id)
        {
            var response = new ServiceResponse<Tasks>();

            try
            {
                response.data = _repository.GetById(id);

                if (response.data == null)
                {
                    throw new Exception("Task não foi encontrado.");
                }

                _repository.Remove(response.data);
                response.message = "Task removido com sucesso.";
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        /// <inheritdoc />
        public ServiceResponse<IList<Tasks>> GetAll()
        {
            var response = new ServiceResponse<IList<Tasks>>();

            try
            {
                response.data = _repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        public ServiceResponse<Tasks> GetTaskById(int id)
        {
            var response = new ServiceResponse<Tasks>();

            try
            {
                response.data = _repository.GetById(id);
                response.message = "Task localizada com sucesso.";

                if (response.data == null)
                {
                    throw new Exception("Task não foi encontrada.");
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        #endregion Public methods
    }
}
