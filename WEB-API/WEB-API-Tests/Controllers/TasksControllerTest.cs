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
                    Title = "Mercado",
                    Summary = "Ir ao mercado fazer a compra do mês.",
                    Status = WEB_API.Enums.StatusEnum.Doing,
                    CreatedAt = DateTime.Now.ToLocalTime(),
                    DueDate = DateTime.Today.ToLocalTime(),
                    UserId = 1
                },
                new()
                {
                    Id = 2,
                    Title = "Buscar Jake",
                    Summary = "Não esquecer de buscar o Jake no futebol.",
                    Status = WEB_API.Enums.StatusEnum.Done,
                    CreatedAt = DateTime.Now.ToLocalTime(),
                    DueDate = DateTime.Today.ToLocalTime(), 
                    UserId = 1
                },
            };
        }

        [Fact]
        public void TasksController_Add_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var tasksMock = _tasksMock[0];
            var responseMock = new ServiceResponse<Tasks>
            {
                data = tasksMock,
                message = "Task criada com sucesso.",
                success = true
            };
            _service.Setup(_ => _.Add(It.IsAny<Tasks>())).Returns(responseMock);

            // Act
            var result = _controller.Add(tasksMock);

            // Assert
            _service.Verify(_ => _.Add(tasksMock));
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void TasksController_Update_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var tasksMock = _tasksMock[0];
            var responseMock = new ServiceResponse<Tasks>
            {
                data = tasksMock,
                message = "Task atualizada com sucesso.",
                success = true
            };
            _service.Setup(_ => _.Update(It.IsAny<Tasks>())).Returns(responseMock);

            // Act
            var result = _controller.Update(tasksMock);

            // Assert
            _service.Verify(_ => _.Update(tasksMock));
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void TasksController_Delete_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var tasksMock = _tasksMock[0];
            var responseMock = new ServiceResponse<Tasks>
            {
                data = tasksMock,
                message = "Task removida com sucesso.",
                success = true
            };
            _service.Setup(_ => _.Delete(It.IsAny<int>())).Returns(responseMock);

            // Act
            var result = _controller.Delete(tasksMock.Id);

            // Assert
            _service.Verify(_ => _.Delete(tasksMock.Id));
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void TasksController_GetAll_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var tasksMock = _tasksMock;
            var responseMock = new ServiceResponse<IList<Tasks>>
            {
                data = tasksMock,
                message = "Todas as tasks encontradas foram retornadas com sucesso.",
                success = true
            };
            _service.Setup(_ => _.GetAll()).Returns(responseMock);

            // Act
            var result = _controller.GetAll();

            // Assert
            _service.Verify(_ => _.GetAll());
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void TasksController_GetTaskById_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var tasksMock = _tasksMock[1];
            var responseMock = new ServiceResponse<Tasks>
            {
                data = tasksMock,
                message = "Task localizada com sucesso.",
                success = true
            };
            _service.Setup(_ => _.GetTaskById(It.IsAny<int>())).Returns(responseMock);

            // Act
            var result = _controller.GetTaskById(tasksMock.Id);

            // Assert
            _service.Verify(_ => _.GetTaskById(It.IsAny<int>()));
            Assert.Equal(responseMock, result);
        }
    }
}
