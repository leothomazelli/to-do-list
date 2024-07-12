using Microsoft.AspNetCore.Mvc;
using WEB_API.Models;
using WEB_API.Services.TasksService;

namespace WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _service;

        public TasksController(ITasksService tasksService)
        {
            _service = tasksService;
        }

        [HttpPost]
        [Route("Add")]
        public ServiceResponse<Tasks> Add(Tasks task)
        {
            return _service.Add(task);
        }

        [HttpPut]
        [Route("Update")]
        public ServiceResponse<Tasks> Update(Tasks task) 
        { 
            return _service.Update(task);
        }

        [HttpDelete]
        [Route("Delete")]
        public ServiceResponse<Tasks> Delete(int id) 
        { 
            return _service.Delete(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public ServiceResponse<IList<Tasks>> GetAll() 
        { 
            return _service.GetAll();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ServiceResponse<Tasks> GetTaskById(int id)
        {
            return _service.GetTaskById(id);
        }
    }
}