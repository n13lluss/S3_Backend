using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Travelblog.Api.Controllers;
using Travelblog.Api.Models.BlogDto;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travelblog.Tests.ApiTests
{
    public class BlogControllerTests
    {
        private readonly Mock<IBlogService> _mockBlogService;
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<ICountryService> _mockCountryService;
        private readonly Mock<IHubContext<BlogHub>> _mockHubContext;
        private readonly BlogController _controller;

        public BlogControllerTests()
        {
            _mockBlogService = new Mock<IBlogService>();
            _mockUserService = new Mock<IUserService>();
            _mockCountryService = new Mock<ICountryService>();
            _mockHubContext = new Mock<IHubContext<BlogHub>>();

            // Mocking Clients for HubContext
            var mockClients = new Mock<IHubClients>();
            var mockClientProxy = new Mock<IClientProxy>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);
            _mockHubContext.Setup(hub => hub.Clients).Returns(mockClients.Object);

            // Setup SendAsync with exact method signature to avoid optional arguments issue
            mockClientProxy.Setup(clientProxy => clientProxy.SendCoreAsync(
                It.IsAny<string>(),
                It.IsAny<object[]>(),
                default)).Returns(Task.CompletedTask);

            _controller = new BlogController(_mockBlogService.Object, _mockUserService.Object, _mockCountryService.Object, _mockHubContext.Object);
        }

        // GET api/blog (Good Flow)
        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfBlogs()
        {
            // Arrange
            var blogs = new List<Blog>
            {
                new Blog { Id = 1, User_Id = 1, Name = "Blog 1", Description = "Description 1", StartDate = DateTime.UtcNow },
                new Blog { Id = 2, User_Id = 1, Name = "Blog 2", Description = "Description 2", StartDate = DateTime.UtcNow }
            };

            _mockBlogService.Setup(s => s.GetBlogList()).ReturnsAsync(blogs);
            _mockUserService.Setup(s => s.GetById(It.IsAny<int>())).Returns((int id) => new User { UserName = $"user{id}" });

            // Act
            var result = await _controller.Get(null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<BlogSlimDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        // GET api/blog (Bad Flow)
        [Fact]
        public async Task Get_ReturnsOkResult_WithEmptyList_WhenNoBlogsAvailable()
        {
            // Arrange
            _mockBlogService.Setup(s => s.GetBlogList()).ReturnsAsync(new List<Blog>());

            // Act
            var result = await _controller.Get(null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<BlogSlimDTO>>(okResult.Value);
            Assert.Empty(returnValue);
        }

        // GET api/blog/{id} (Good Flow)
        [Fact]
        public async Task Get_WithId_ReturnsOkResult_WithBlog()
        {
            // Arrange
            int blogId = 1;
            var blog = new Blog
            {
                Id = blogId,
                User_Id = 1,
                Name = "Blog 1",
                Description = "Description 1",
                StartDate = DateTime.UtcNow,
                Likes = 10,
                Posts = new List<Post>(),
                Followers = new List<User>(),
                IsDeleted = false,
                IsPrive = false,
                IsSuspended = false,
                Countries = new List<Country>()
            };

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync(blog);
            _mockUserService.Setup(s => s.GetNameById(blog.User_Id)).Returns("user1");
            _mockUserService.Setup(s => s.GetById(blog.User_Id)).Returns(new User { Id = 1, UserName = "user1", IdString = "1" });

            // Act
            var result = await _controller.Get(blogId, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<BlogViewDto>(okResult.Value);
            Assert.Equal(blogId, returnValue.Id);
        }

        // GET api/blog/{id} (Bad Flow)
        [Fact]
        public async Task Get_WithId_ReturnsNotFound_WhenBlogDoesNotExist()
        {
            // Arrange
            int blogId = 1;
            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync((Blog)null);

            // Act
            var result = await _controller.Get(blogId, null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // POST api/blog (Good Flow)
        [Fact]
        public async Task Create_ReturnsCreatedAtActionResult_WithNewBlog()
        {
            // Arrange
            var blogCreationDto = new BlogCreationDto { Username = "user1", Name = "Blog 1", Description = "Description 1" };
            var blog = new Blog { Id = 1, User_Id = 1, Name = "Blog 1", Description = "Description 1", StartDate = DateTime.UtcNow };

            _mockUserService.Setup(s => s.GetUserByName(blogCreationDto.Username)).Returns(new User { Id = 1 });
            _mockBlogService.Setup(s => s.CreateBlog(It.IsAny<Blog>())).ReturnsAsync(blog);

            // Act
            var result = await _controller.Create(blogCreationDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Blog>(createdAtActionResult.Value);
            Assert.Equal(blog.Id, returnValue.Id);
        }

        // POST api/blog (Bad Flow)
        [Fact]
        public async Task Create_ReturnsBadRequest_WhenCreatedBlogIsNull()
        {
            // Arrange
            BlogCreationDto createdBlog = null;

            // Act
            var result = await _controller.Create(createdBlog);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid input", badRequestResult.Value);
        }

        // PUT api/blog/{id} (Good Flow)
        [Fact]
        public async Task Put_ReturnsNoContent_WhenBlogIsUpdated()
        {
            // Arrange
            int blogId = 1;
            var updateBlogDto = new UpdateBlogDto
            {
                Name = "Updated Blog",
                Description = "Updated Description",
                IsSuspended = false,
                IsDeleted = false,
                IsPrive = false,
                Trip_Id = 1,
                Countries = new List<int> { 1, 2 }
            };

            var blog = new Blog { Id = blogId, Name = "Original Blog", Description = "Original Description", IsSuspended = false, IsDeleted = false, IsPrive = false, Countries = new List<Country>() };

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync(blog);
            _mockCountryService.Setup(s => s.GetCountryById(It.IsAny<int>())).ReturnsAsync(new Country());

            // Act
            var result = await _controller.Put(blogId, updateBlogDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        // PUT api/blog/{id} (Bad Flow)
        [Fact]
        public async Task Put_ReturnsNotFound_WhenBlogDoesNotExist()
        {
            // Arrange
            int blogId = 1;
            var updateBlogDto = new UpdateBlogDto { Name = "Updated Blog", Description = "Updated Description" };

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync((Blog)null);

            // Act
            var result = await _controller.Put(blogId, updateBlogDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // POST api/blog/{id}/like (Good Flow)
        [Fact]
        public async Task Like_ReturnsNoContent_WhenBlogIsLiked()
        {
            // Arrange
            int blogId = 1;
            var blog = new Blog { Id = blogId };
            var user = new User { Id = 1, UserName = "user1" };

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync(blog);
            _mockUserService.Setup(s => s.GetUserById(It.IsAny<string>())).Returns(user);

            var mockClientProxy = new Mock<IClientProxy>();
            mockClientProxy.Setup(clientProxy => clientProxy.SendCoreAsync(
                "ReceiveBlogUpdate",
                It.Is<object[]>(o => o.Length == 1 && (string)o[0] == "A blog has been liked."),
                default)).Returns(Task.CompletedTask);

            var mockClients = new Mock<IHubClients>();
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);
            _mockHubContext.Setup(hub => hub.Clients).Returns(mockClients.Object);

            // Act
            var result = await _controller.Like(blogId, "1");

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


        // POST api/blog/{id}/like (Bad Flow)
        [Fact]
        public async Task Like_ReturnsNotFound_WhenBlogDoesNotExist()
        {
            // Arrange
            int blogId = 1;

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync((Blog)null);

            // Act
            var result = await _controller.Like(blogId, "1");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // POST api/blog/{id}/follow (Good Flow)
        [Fact]
        public async Task Follow_ReturnsNoContent_WhenUserFollowsBlog()
        {
            // Arrange
            int blogId = 1;
            var blog = new Blog { Id = blogId };

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync(blog);

            // Act
            var result = await _controller.Follow(blogId, "1");

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        // POST api/blog/{id}/follow (Bad Flow)
        [Fact]
        public async Task Follow_ReturnsNotFound_WhenBlogDoesNotExist()
        {
            // Arrange
            int blogId = 1;

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync((Blog)null);

            // Act
            var result = await _controller.Follow(blogId, "1");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // POST api/blog/{id}/country (Good Flow)
        [Fact]
        public async Task AddCountry_ReturnsNoContent_WhenCountriesAreAdded()
        {
            // Arrange
            int blogId = 1;
            var blog = new Blog { Id = blogId };
            var countries = new List<Country> { new Country { Id = 1 }, new Country { Id = 2 } };

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync(blog);
            _mockBlogService.Setup(s => s.AddCountries(blog, countries)).ReturnsAsync(blog);

            // Act
            var result = await _controller.AddCountry(blogId, countries);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        // POST api/blog/{id}/country (Bad Flow)
        [Fact]
        public async Task AddCountry_ReturnsNotFound_WhenBlogDoesNotExist()
        {
            // Arrange
            int blogId = 1;
            var countries = new List<Country> { new Country { Id = 1 }, new Country { Id = 2 } };

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync((Blog)null);

            // Act
            var result = await _controller.AddCountry(blogId, countries);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // DELETE api/blog/{id} (Good Flow)
        [Fact]
        public async Task Delete_ReturnsNoContent_WhenBlogIsDeleted()
        {
            // Arrange
            int blogId = 1;
            var blog = new Blog { Id = blogId, IsDeleted = false };

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync(blog);

            // Act
            var result = await _controller.Delete(blogId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        // DELETE api/blog/{id} (Bad Flow)
        [Fact]
        public async Task Delete_ReturnsNotFound_WhenBlogDoesNotExist()
        {
            // Arrange
            int blogId = 1;

            _mockBlogService.Setup(s => s.GetBlogById(blogId)).ReturnsAsync((Blog)null);

            // Act
            var result = await _controller.Delete(blogId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
