using Microsoft.AspNetCore.Mvc;
using WEB_API.Models;
using WEB_API.Services.UserService;

namespace WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpPost]
        [Route("Add")]
        public ServiceResponse<User> Add(User user)
        {
            return _service.Add(user);
        }

        [HttpPut]
        [Route("Update")]
        public ServiceResponse<User> Update(User user)
        {
            return _service.Update(user);
        }

        [HttpDelete]
        [Route("Delete")]
        public ServiceResponse<User> Delete(int id)
        {
            return _service.Delete(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public ServiceResponse<IList<User>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ServiceResponse<User> GetUserById(int id)
        {
            return _service.GetUserById(id);
        }

        [HttpPost]
        [Route("Login")]
        public ServiceResponse<User> Login(User user) 
        {
            return _service.Login(user);
        }

        [HttpPost]
        [Route("Logout")]
        public ServiceResponse<User> Logout()
        {
            return _service.Logout();
        }
    }
}
