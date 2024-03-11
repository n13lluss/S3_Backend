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
    public class PostTests
    {
        [Fact]
        public void CreatePost_ValidPost_ReturnsCreatedPost()
        {
            // Arrange
            var postRepositoryMock = new Mock<IPostRepository>();
            var blogServiceMock = new Mock<IBlogService>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var postService = new PostService(postRepositoryMock.Object, blogServiceMock.Object, blogPostRepositoryMock.Object);

            var blogId = 1;
            var inputPost = new Post
            {
                Name = "Test Post",
                Description = "Test Content"
                // Add other properties as needed
            };

            postRepositoryMock.Setup(repo => repo.CreatePost(It.IsAny<Post>()))
                             .Returns((Post createdPost) => createdPost);

            blogPostRepositoryMock.Setup(repo => repo.CreateBlogPost(It.IsAny<int>(), It.IsAny<int>()));

            // Act
            var result = postService.CreatePost(inputPost, blogId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(inputPost.Name, result.Name);
            Assert.Equal(inputPost.Description, result.Description);
            // Add more assertions based on your Post model
        }

        [Fact]
        public void CreatePost_InvalidPost_ThrowsException()
        {
            // Arrange
            var postRepositoryMock = new Mock<IPostRepository>();
            var blogServiceMock = new Mock<IBlogService>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var postService = new PostService(postRepositoryMock.Object, blogServiceMock.Object, blogPostRepositoryMock.Object);

            var blogId = 1;
            var invalidPost = new Post
            {
                // Missing required properties
            };

            // Act and Assert
            Assert.Throws<Exception>(() => postService.CreatePost(invalidPost, blogId));
        }
    }
}
