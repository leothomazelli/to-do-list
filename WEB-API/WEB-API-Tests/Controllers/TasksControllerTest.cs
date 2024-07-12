using Moq;
using WEB_API.Controllers;
using WEB_API.Models;
using WEB_API.Services.TasksService;

namespace WEB_API_Tests.Controllers
{
    public class TasksControllerTest
    {
        private readonly TasksController _controller;
        private readonly Mock<ITasksService> _service;
        private IList<Tasks> _tasksMock;

        public TasksControllerTest()
        {
            _service = new Mock<ITasksService>();
            _controller = new TasksController(_service.Object);

            _tasksMock = new List<Tasks>
            {
                new()
                {
                    Id = 1,
                },
                new()
                {
                    Id = 2,
                },
            };
        }

        [Fact]
        public void TasksController_Method_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
