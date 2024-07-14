using FluentAssertions;
using Moq;
using WEB_API.Models;
using WEB_API.Repository;
using WEB_API.Services.TasksService;

namespace WEB_API_Tests.Services
{
    public class TasksServiceTest
    {
        private readonly TasksService _service;
        private readonly Mock<IRepository<Tasks>> _repository;
        private readonly IList<Tasks> _tasksMock;

        public TasksServiceTest() 
        {
            _repository = new Mock<IRepository<Tasks>>();
            _service = new TasksService(_repository.Object);
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
        public void TasksService_Add_ShouldThrowAnExceptionAndNotCallRepository_WhenTaskProvidedIsEmpty()
        {
            // Arrange
            Tasks taskMock = null;
            var responseMock = new ServiceResponse<Tasks>
            {
                message = "Informe os dados da task.",
                success = false
            };

            // Act
            var result = _service.Add(taskMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Add(It.IsAny<Tasks>()), Times.Never);
        }

        [Fact]
        public void TasksService_Add_ShouldCallRepository_WhenTaskProvidedIsValid()
        {
            // Arrange
            var taskMock = _tasksMock[0];
            var responseMock = new ServiceResponse<Tasks>
            {
                data = taskMock,
                message = "Task cadastrada com sucesso.",
                success = true
            };

            _repository.Setup(_ => _.Add(It.IsAny<Tasks>()));

            // Act
            var result = _service.Add(taskMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Add(It.IsAny<Tasks>()), Times.Once);
        }

        [Fact]
        public void TasksService_Update_ShouldThrowAnExceptionAndNotCallRepository_WhenTaskProvidedIsEmpty()
        {
            // Arrange
            Tasks taskMock = null;
            var responseMock = new ServiceResponse<Tasks>
            {
                message = "Informe os dados da task.",
                success = false
            };

            // Act
            var result = _service.Update(taskMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Update(It.IsAny<Tasks>()), Times.Never);
        }

        [Fact]
        public void TasksService_Update_ShouldCallRepository_WhenTaskProvidedIsValid()
        {
            // Arrange
            var taskMock = _tasksMock[0];
            var responseMock = new ServiceResponse<Tasks>
            {
                data = taskMock,
                message = "Task editada com sucesso.",
                success = true
            };

            _repository.Setup(_ => _.Update(It.IsAny<Tasks>()));

            // Act
            var result = _service.Update(taskMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Update(It.IsAny<Tasks>()), Times.Once);
        }

        [Fact]
        public void TasksService_Delete_ShouldThrowAnExceptionAndNotCallRepository_WhenIdProvidedIsNotValid()
        {
            // Arrange
            Tasks taskMock = null;
            var idMock = 0;
            var responseMock = new ServiceResponse<Tasks>
            {
                data = taskMock,
                message = "Task não foi encontrada.",
                success = false
            };
            _repository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(taskMock);

            // Act
            var result = _service.Delete(idMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Remove(It.IsAny<Tasks>()), Times.Never());
        }

        [Fact]
        public void TasksService_Delete_ShouldCallRepository_WhenIdProvidedIsValid()
        {
            // Arrange
            var taskMock = _tasksMock[0];
            var responseMock = new ServiceResponse<Tasks>
            {
                data = taskMock,
                message = "Task removida com sucesso.",
                success = true
            };
            _repository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(taskMock);

            // Act
            var result = _service.Delete(taskMock.Id);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Remove(It.IsAny<Tasks>()), Times.Once());
        }

        [Fact]
        public void TasksService_GetAll_ShouldThrowAnException_WhenMethodIsCalled()
        {
            // Arrange
            var responseMock = new ServiceResponse<IList<Tasks>>
            {
                message = "Error",
                success = false
            };
            _repository.Setup(_ => _.GetAll()).Throws(new Exception("Error"));

            // Act
            var result = _service.GetAll();

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.GetAll(), Times.Once());
        }

        [Fact]
        public void TasksService_GetAll_ShouldCallRepository_WhenMethodIsCalled()
        {
            // Arrange
            var taskMock = _tasksMock;
            var responseMock = new ServiceResponse<IList<Tasks>>
            {
                data = taskMock,
                message = "Todos os dados foram retornados.",
                success = true
            };
            _repository.Setup(_ => _.GetAll()).Returns(taskMock);

            // Act
            var result = _service.GetAll();

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.GetAll(), Times.Once());
        }

        [Fact]
        public void TasksService_GetTaskById_ShouldThrowAnException_WhenIdProvidedIsNotValid()
        {
            // Arrange
            Tasks taskMock = null;
            var idMock = 0;
            var responseMock = new ServiceResponse<Tasks>
            {
                data = taskMock,
                message = "Task não foi encontrada.",
                success = false
            };

            // Act
            var result = _service.GetTaskById(idMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.GetById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void TasksService_GetTaskById_ShouldCallRepository_WhenMethodIsCalled()
        {
            // Arrange
            var taskMock = _tasksMock[0];
            var responseMock = new ServiceResponse<Tasks>
            {
                data = taskMock,
                message = "Task localizada com sucesso.",
                success = true
            };
            _repository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(taskMock);

            // Act
            var result = _service.GetTaskById(taskMock.Id);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.GetById(taskMock.Id), Times.Once());
        }
    }
}
