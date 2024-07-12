using FluentAssertions;
using Moq;
using WEB_API.Models;
using WEB_API.Repository;
using WEB_API.Services.UserService;

namespace WEB_API_Tests.Services
{
    public class UserServiceTest
    {
        private readonly UserService _service;
        private readonly Mock<IRepository<User>> _repository;
        private readonly IList<User> _usersMock;

        public UserServiceTest()
        {
            _repository = new Mock<IRepository<User>>();
            _service = new UserService(_repository.Object);
            _usersMock = new List<User>
            {
                new()
                {
                    Id = 1,
                    UserName = "Leonadro Thomazelli Ferreira",
                    Password = "LeoThomaz",
                    Email = "leonardo@gmail.com"
                },
                new()
                {
                    Id = 2,
                    UserName = "Geraldo das Neves Ferreira",
                    Password = "GeraNeves",
                    Email = "geraldo@gmail.com"
                },
            };
        }

        [Fact]
        public void UserService_Add_ShouldThrowAnExceptionAndNotCallRepository_WhenUserProvidedIsEmpty()
        {
            // Arrange
            User userMock = null;
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Informe os dados do usuário.",
                success = false
            };

            // Act
            var result = _service.Add(userMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Add(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public void UserService_Add_ShouldCallRepository_WhenUserProvidedIsValid()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário cadastrado com sucesso.",
                success = true
            };
            _repository.Setup(_ => _.Add(It.IsAny<User>()));

            // Act
            var result = _service.Add(userMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Add(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void UserService_Update_ShouldThrowAnExceptionAndNotCallRepository_WhenUserProvidedIsEmpty()
        {
            // Arrange
            User userMock = null;
            var responseMock = new ServiceResponse<User>
            {
                message = "Informe os dados do usuário.",
                success = false
            };

            // Act
            var result = _service.Update(userMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Update(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public void UserService_Update_ShoulCallRepository_WhenUserProvidedIsValid()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário editado com sucesso.",
                success = true
            };
            _repository.Setup(_ => _.Update(It.IsAny<User>()));

            // Act
            var result = _service.Update(userMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void UserService_Delete_ShouldThrowAnExceptionAndNotCallRepository_WhenIdProvidedIsNotValid()
        {
            // Arrange
            User userMock = null;
            var idMock = 0;
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário não foi encontrado.",
                success = false
            };

            // Act
            var result = _service.Delete(idMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Remove(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public void UserService_Delete_ShouldCallRepository_WhenIdProvidedIsValid()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário removido com sucesso.",
                success = true
            };
            _repository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(userMock);

            // Act
            var result = _service.Delete(userMock.Id);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.Remove(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void UserService_GetAll_ShouldThrowAnException_WhenMethodIsCalled()
        {
            // Arrange
            var responseMock = new ServiceResponse<IList<User>>
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
        public void UserService_GetAll_ShouldCallRepository_WhenMethodIsCalled()
        {
            // Arrange
            var userMock = _usersMock;
            var responseMock = new ServiceResponse<IList<User>>
            {
                data = userMock,
                message = "Todos os usários encontrados foram retornados com sucesso.",
                success = true
            };
            _repository.Setup(_ => _.GetAll()).Returns(userMock);

            // Act
            var result = _service.GetAll();

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.GetAll(), Times.Once());
        }

        [Fact]
        public void UserService_GetUserById_ShouldThrowAnException_WhenIdProvidedIsNotValid()
        {
            // Arrange
            User userMock = null;
            var idMock = 0;
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário não foi encontrado.",
                success = false
            };

            // Act
            var result = _service.GetUserById(idMock);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.GetById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void UserService_GetUserById_ShouldCallRepository_WhenMethodIsCalled()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário localizado com sucesso.",
                success = true
            };
            _repository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(userMock);

            // Act
            var result = _service.GetUserById(userMock.Id);

            // Assert
            responseMock.Should().BeEquivalentTo(result);
            _repository.Verify(_ => _.GetById(userMock.Id), Times.Once());
        }
    }
}
