using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagement.API.Controllers;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.UserDetails.Command;
using ProjectManagement.Application.UseCases.UserDetails.Query;
using Xunit;

namespace ProjectManagement.UnitTests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new UserController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetUserById_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var userDto = new UserDto { Id = userId, Name = "Test User", Email = "test@example.com" };
            var response = ResponseDto<UserDto>.SuccessResponse(userDto);
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.GetUserById(userId);

            // Assert
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task GetUserByUserName_ReturnsUser()
        {
            // Arrange
            var username = "testuser";
            var userDto = new UserDto { Id = 1, Name = "Test User", Email = "test@example.com" };
            var response = ResponseDto<UserDto>.SuccessResponse(userDto);
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByUserNameQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.GetUserByUserName(username);

            // Assert
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task GetUserByEmail_ReturnsUser()
        {
            // Arrange
            var email = "test@example.com";
            var userDto = new UserDto { Id = 1, Name = "Test User", Email = email };
            var response = ResponseDto<UserDto>.SuccessResponse(userDto);
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByEmailQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.GetUserByEmail(email);

            // Assert
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task CreateUser_ReturnsCreatedUser()
        {
            // Arrange
            var command = new CreateUserCommand("Test User", "test@example.com", "password");
            var userDto = new UserDto { Id = 1, Name = "Test User", Email = "test@example.com" };
            var response = ResponseDto<UserDto>.SuccessResponse(userDto);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.CreateUser(command);

            // Assert
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task UpdateUser_ReturnsUpdatedUser()
        {
            // Arrange
            var userId = 1;
            var command = new UpdateUserCommand(userId, "Updated User", "updated@example.com", "passwordHash");
            var userDto = new UserDto { Id = userId, Name = "Updated User", Email = "updated@example.com" };
            var response = ResponseDto<UserDto>.SuccessResponse(userDto);
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.UpdateUser(userId, command);

            // Assert
            Assert.Equal(response, result);
        }

        [Fact]
        public async Task UpdateUser_ReturnsError_WhenIdMismatch()
        {
            // Arrange
            var userId = 1;
            var command = new UpdateUserCommand(2, "Updated User", "updated@example.com", "passwordHash");

            // Act
            var result = await _controller.UpdateUser(userId, command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("User ID mismatch", result.Message);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task DeleteUser_ReturnsDeletedUser()
        {
            // Arrange
            var userId = 1;
            var userDto = new UserDto { Id = userId, Name = "Deleted User", Email = "deleted@example.com" };
            var response = ResponseDto<UserDto>.SuccessResponse(userDto);
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteUserCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(response);

            // Act
            var result = await _controller.DeleteUser(userId);

            // Assert
            Assert.Equal(response, result);
        }
    }
}
