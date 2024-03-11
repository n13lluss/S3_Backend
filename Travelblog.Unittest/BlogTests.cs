using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using Travelblog.Core.Services;

namespace Travelblog.Unittest
{
    public class BlogTests
    {
        [Fact]
        public void CreateBlog_ValidBlog_ReturnsCreatedBlog()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            var inputBlog = new Blog
            {
                Name = "Test Blog",
                Description = "Test Description"
            };

            blogRepositoryMock.Setup(repo => repo.Create(It.IsAny<Blog>()))
                             .Returns((Blog createdBlog) => createdBlog);

            // Act
            var result = blogService.CreateBlog(inputBlog);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(inputBlog.Name, result.Name);
            Assert.Equal(inputBlog.Description, result.Description);
        }

        [Fact]
        public void CreateBlog_NullBlog_ThrowsArgumentNullException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => blogService.CreateBlog(null));
        }

        [Fact]
        public void CreateBlog_EmptyTitle_ThrowsArgumentException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            var invalidBlog = new Blog
            {
                Name = string.Empty,
                Description = "Test Description"
            };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => blogService.CreateBlog(invalidBlog));
        }

        [Fact]
        public void UpdateBlog_ValidBlog_ReturnsUpdatedBlog()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

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
                             .Returns(updatedBlog);

            // Act
            var result = blogService.UpdateBlog(existingBlog);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedBlog.Name, result.Name);
            Assert.Equal(updatedBlog.Description, result.Description);
        }

        [Fact]
        public void UpdateBlog_NullBlog_ThrowsArgumentNullException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => blogService.UpdateBlog(null));
        }

        [Fact]
        public void UpdateBlog_EmptyTitle_ThrowsArgumentException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            var invalidBlog = new Blog
            {
                Id = 1,
                Name = string.Empty,
                Description = "Test Description"
            };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => blogService.UpdateBlog(invalidBlog));
        }

        [Fact]
        public void GetBlogById_ValidId_ReturnsBlogWithPosts()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            var existingBlog = new Blog
            {
                Id = 1,
                Name = "Test Blog",
                Description = "Test Description"
            };

            var posts = new List<Post>
            {
                new Post { Id = 1, Name = "Post 1", Posted = DateTime.Now },
                new Post { Id = 2, Name = "Post 2", Posted = DateTime.Now.AddDays(-1) }
            };

            blogRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>()))
                             .Returns(existingBlog);

            blogPostRepositoryMock.Setup(repo => repo.GetAllBlogPosts(It.IsAny<int>()))
                                 .Returns(posts);

            // Act
            var result = blogService.GetBlogById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingBlog.Name, result.Name);
            Assert.Equal(existingBlog.Description, result.Description);
            Assert.Equal(posts.Count, result.Posts.Count);
        }

        [Fact]
        public void GetBlogById_InvalidId_ThrowsException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            // Act and Assert
            Assert.Throws<Exception>(() => blogService.GetBlogById(-1));
        }

        [Fact]
        public void GetBlogById_BlogNotFound_ThrowsException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            blogRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>()))
                             .Returns((Blog)null);

            // Act and Assert
            Assert.Throws<Exception>(() => blogService.GetBlogById(1));
        }

        [Fact]
        public void GetBlogList_ValidData_ReturnsBlogList()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            var blogs = new List<Blog>
            {
                new Blog { Id = 1, Name = "Blog 1", Description = "Description 1" },
                new Blog { Id = 2, Name = "Blog 2", Description = "Description 2" }
            };

            blogRepositoryMock.Setup(repo => repo.GetAll())
                             .Returns(blogs);

            // Act
            var result = blogService.GetBlogList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(blogs.Count, result.Count);
        }

        [Fact]
        public void GetBlogList_EmptyData_ThrowsException()
        {
            // Arrange
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var blogService = new BlogService(blogRepositoryMock.Object, blogPostRepositoryMock.Object);

            blogRepositoryMock.Setup(repo => repo.GetAll())
                             .Returns(new List<Blog>());

            // Act and Assert
            Assert.Throws<Exception>(() => blogService.GetBlogList());
        }
    }
}
