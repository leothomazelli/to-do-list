using Moq;
using WEB_API.Controllers;
using WEB_API.Models;
using WEB_API.Services.UserService;

namespace WEB_API_Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly UserController _controller;
        private readonly Mock<IUserService> _service;
        private IList<User> _usersMock;

        public UserControllerTest()
        {
            _service = new Mock<IUserService>();
            _controller = new UserController(_service.Object);

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
        public void UserController_Add_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário criado com sucesso.",
                success = true
            };
            _service.Setup(_ => _.Add(It.IsAny<User>())).Returns(responseMock);

            // Act
            var result = _controller.Add(userMock);

            // Assert
            _service.Verify(_ => _.Add(userMock));
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void UserController_Update_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário atualizado com sucesso.",
                success = true
            };
            _service.Setup(_ => _.Update(It.IsAny<User>())).Returns(responseMock);

            // Act
            var result = _controller.Update(userMock);

            // Assert
            _service.Verify(_ => _.Update(userMock));
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void UserController_Delete_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário removido com sucesso.",
                success = true
            };
            _service.Setup(_ => _.Delete(It.IsAny<int>())).Returns(responseMock);

            // Act
            var result = _controller.Delete(userMock.Id);

            // Assert
            _service.Verify(_ => _.Delete(userMock.Id));
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void UserController_GetAll_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var responseMock = new ServiceResponse<IList<User>>
            {
                data = _usersMock,
                message = "Todos os usuários encontrados foram retornados com sucesso.",
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
        public void UserController_GetUserById_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Usuário localizado com sucesso.",
                success = true
            };
            _service.Setup(_ => _.GetUserById(It.IsAny<int>())).Returns(responseMock);

            // Act
            var result = _controller.GetUserById(userMock.Id);

            // Assert
            _service.Verify(_ => _.GetUserById(It.IsAny<int>()));
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void UserController_Login_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Login realizado com sucesso.",
                success = true
            };
            _service.Setup(_ => _.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(responseMock);

            // Act
            var result = _controller.Login(userMock.UserName, userMock.Password);

            // Assert
            _service.Verify(_ => _.Login(It.IsAny<string>(), It.IsAny<string>()));
            Assert.Equal(responseMock, result);
        }

        [Fact]
        public void UserController_Logout_ShouldExecuteService_WhenMethodIsCalled()
        {
            // Arrange
            var userMock = _usersMock[0];
            var responseMock = new ServiceResponse<User>
            {
                data = userMock,
                message = "Logout realizado com sucesso.",
                success = true
            };
            _service.Setup(_ => _.Logout()).Returns(responseMock);

            // Act
            var result = _controller.Logout();

            // Assert
            _service.Verify(_ => _.Logout());
            Assert.Equal(responseMock, result);
        }
    }
}
