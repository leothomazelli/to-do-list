using WEB_API.Models;
using WEB_API.Repository;

namespace WEB_API.Services.UserService
{
    public class UserService : IUserService
    {
        #region Properties

        /// <summary>
        /// Repository object created to access the User registers on database using EntityFramework.
        /// </summary>
        private readonly IRepository<User> _repository;

        #endregion Properties

        #region Public methods

        /// <summary>
        /// User constructor created to initialize the "_repository" using Dependency Injection.
        /// </summary>
        /// <param name="repository">IRepository<User> object used to initialize the internal variable using Dependency Injection.</param>
        public UserService(IRepository<User> repository)
        {
           _repository = repository;
        }

        /// <inheritdoc />
        public ServiceResponse<User> Add(User user)
        {
            var response = new ServiceResponse<User>
            {
                data = user
            };

            try
            {
                if (user == null)
                {
                    throw new Exception("Informe os dados do usuário.");
                }

                _repository.Add(user);
                response.message = "Usuário cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        /// <inheritdoc />
        public ServiceResponse<User> Update(User user)
        {
            var response = new ServiceResponse<User> 
            { 
                data = user 
            };

            try
            {
                if (user == null)
                {
                    throw new Exception("Informe os dados do usuário.");
                }

                _repository.Update(user);
                response.message = "Usuário editado com sucesso.";
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        /// <inheritdoc />
        public ServiceResponse<User> Delete(int id)
        {
            var response = new ServiceResponse<User>();

            try
            {
                response.data = _repository.GetById(id);

                if (response.data == null)
                {
                    throw new Exception("Usuário não foi encontrado.");
                }

                _repository.Remove(response.data);
                response.message = "Usuário removido com sucesso.";
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        /// <inheritdoc />
        public ServiceResponse<IList<User>> GetAll()
        {
            var response = new ServiceResponse<IList<User>>();

            try
            {
                response.data = _repository.GetAll().ToList();
                response.message = "Todos os usários encontrados foram retornados com sucesso.";
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        /// <inheritdoc />
        public ServiceResponse<User> GetUserById(int id)
        {
            var response = new ServiceResponse<User>();

            try
            {
                response.data = _repository.GetById(id);
                response.message = "Usuário localizado com sucesso.";

                if (response.data == null)
                {
                    throw new Exception("Usuário não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        /// <inheritdoc />
        public ServiceResponse<User> Login(string userName, string password)
        {
            var response = new ServiceResponse<User>();
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ServiceResponse<User> Logout()
        {
            throw new NotImplementedException();
        }

        #endregion Public methods
    }
}
