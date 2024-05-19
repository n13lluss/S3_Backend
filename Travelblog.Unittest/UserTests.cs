using Moq;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using Travelblog.Core.Services;

namespace Travelblog.Tests
{
    public class UserTests
    {
        [Fact]
        public void CheckUser_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var validUsernameEmail = "testuser@example.com";
            var validPassword = "password123";

            var user = new User
            {
                Id = 1,
                UserName = "TestUser",
                Email = "testuser@example.com",
                Password = "password123"
            };

            userRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<string>()))
                             .Returns(user);

            // Act
            var result = userService.CheckUser(validUsernameEmail, validPassword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckUser_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var invalidUsernameEmail = "nonexistentuser@example.com";
            var invalidPassword = "wrongpassword";

            userRepositoryMock.Setup(repo => repo.GetByEmail(It.IsAny<string>()));

            // Act
            var result = userService.CheckUser(invalidUsernameEmail, invalidPassword);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckUser_ValidUsernameCredentials_ReturnsTrue()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var validUsername = "TestUser";
            var validPassword = "password123";

            var user = new User
            {
                Id = 1,
                UserName = "TestUser",
                Email = "testuser@example.com",
                Password = "password123"
            };

            userRepositoryMock.Setup(repo => repo.GetByUserName(It.IsAny<string>()))
                             .Returns(user);

            // Act
            var result = userService.CheckUser(validUsername, validPassword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckUser_InvalidUsernameCredentials_ReturnsFalse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var invalidUsername = "NonExistentUser";
            var invalidPassword = "wrongpassword";

            userRepositoryMock.Setup(repo => repo.GetByUserName(It.IsAny<string>()));

            // Act
            var result = userService.CheckUser(invalidUsername, invalidPassword);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void GetById_ValidUserId_ReturnsUser()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var userId = 1;

            var user = new User
            {
                Id = userId,
                UserName = "TestUser"
            };

            userRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>()))
                             .Returns(user);

            // Act
            var result = userService.GetById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal("TestUser", result.UserName);
        }

        [Fact]
        public void GetNameById_ValidUserId_ReturnsUserName()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var userId = 1;

            var user = new User
            {
                Id = userId,
                UserName = "TestUser"
            };

            userRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>()))
                             .Returns(user);

            // Act
            var result = userService.GetNameById(userId);

            // Assert
            Assert.Equal("TestUser", result);
        }
    }
}
