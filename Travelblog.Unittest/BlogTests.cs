using Moq;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using Travelblog.Core.Services;

namespace Travelblog.Unittest
{
    public class BlogTests
    {
        [Fact]
        public async Task CreateBlog_ValidBlog_ReturnsCreatedBlog()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            var inputBlog = new Blog
            {
                Name = "Test Blog",
                Description = "Test Description"
            };

            var expectedBlog = new Blog
            {
                // Set properties of the expected blog based on what you expect the service to return
                Name = inputBlog.Name,
                Description = inputBlog.Description
                // Add more properties as needed
            };

            // Setup mock to return the expected blog when Create method is called
            blogRepositoryMock.Setup(repo => repo.Create(It.IsAny<Blog>()))
                             .ReturnsAsync(expectedBlog);

            // Act
            var result = await blogService.CreateBlog(inputBlog);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBlog.Name, result.Name);
            Assert.Equal(expectedBlog.Description, result.Description);
        }


        [Fact]
        public void CreateBlog_NullBlog_ThrowsArgumentNullException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => blogService.CreateBlog(null));
        }

        [Fact]
        public void CreateBlog_EmptyTitle_ThrowsArgumentException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            var invalidBlog = new Blog
            {
                Name = string.Empty,
                Description = "Test Description"
            };

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => blogService.CreateBlog(invalidBlog));
        }

        [Fact]
        public async Task UpdateBlog_ValidBlog_ReturnsUpdatedBlog()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            var existingBlog = new Blog
            {
                Id = 1,
                Name = "Existing Blog",
                Description = "Test Description"
            };

            var updatedBlog = new Blog
            {
                Id = 1,
                Name = "Updated Blog",
                Description = "Updated Description"
            };

            blogRepositoryMock.Setup(repo => repo.Update(It.IsAny<Blog>()))
                             .ReturnsAsync(updatedBlog);

            // Act
            var result = await blogService.UpdateBlog(existingBlog);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedBlog.Name, result.Name);
            Assert.Equal(updatedBlog.Description, result.Description);
        }

        [Fact]
        public async Task UpdateBlog_NullBlog_ThrowsArgumentNullException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => blogService.UpdateBlog(null));
        }

        [Fact]
        public async Task UpdateBlog_EmptyTitle_ThrowsArgumentException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            var invalidBlog = new Blog
            {
                Id = 1,
                Name = string.Empty,
                Description = "Test Description"
            };

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => blogService.UpdateBlog(invalidBlog));
        }

        [Fact]
        public async Task GetBlogWithPosts_ValidId_ReturnsBlogWithPosts()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            var existingBlog = new Blog
            {
                Id = 1,
                Name = "Test Blog",
                Description = "Test Description"
            };

            var posts = new List<Post>
            {
                new() { Id = 1, Name = "Post 1", Posted = DateTime.Now },
                new() { Id = 2, Name = "Post 2", Posted = DateTime.Now.AddDays(-1) }
            };

            blogRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>()))
                             .ReturnsAsync(existingBlog);

            // Act
            var result = await blogService.GetBlogById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingBlog.Name, result.Name);
            Assert.Equal(existingBlog.Description, result.Description);
        }




        [Fact]
        public async Task GetBlogById_InvalidId_ThrowsException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => blogService.GetBlogById(-1));
        }

        [Fact]
        public async Task GetBlogById_BlogNotFound_ThrowsException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            blogRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>()))
                             .ReturnsAsync((Blog)null);

            // Act and Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => blogService.GetBlogById(1));
            Assert.Equal("Unable to get Blog", exception.Message);
        }


        [Fact]
        public async Task GetBlogList_ValidData_ReturnsBlogList()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            var blogs = new List<Blog>
                {
                    new() { Id = 1, Name = "Blog 1", Description = "Description 1" },
                    new() { Id = 2, Name = "Blog 2", Description = "Description 2" }
                };

            blogRepositoryMock.Setup(repo => repo.GetAll())
                             .ReturnsAsync(blogs);

            // Act
            var result = await blogService.GetBlogList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(blogs.Count, result.Count);
        }

        [Fact]
        public async Task GetBlogList_EmptyData_ThrowsException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var bloglikeRepositoryMock = new Mock<IBlogLikeRepository>();
            var blogcountryRepositoryMock = new Mock<IBlogCountryRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, bloglikeRepositoryMock.Object, blogcountryRepositoryMock.Object, userRepositoryMock.Object);

            blogRepositoryMock.Setup(repo => repo.GetAll())
                             .ReturnsAsync([]);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => blogService.GetBlogList());
        }
    }
}
