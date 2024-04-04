using Moq;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using Travelblog.Core.Services;

namespace Travelblog.Unittest
{
    public class PostTests
    {
        [Fact]
        public async Task CreatePost_ValidPost_ReturnsCreatedPost()
        {
            // Arrange
            var postRepositoryMock = new Mock<IPostRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var postService = new PostService(postRepositoryMock.Object, blogPostRepositoryMock.Object);

            var blogId = 1;
            var inputPost = new Post
            {
                Name = "Test Post",
                Description = "Test Content"
            };

            // Configure the mock to return the input post when CreatePostAsync is called
            postRepositoryMock.Setup(repo => repo.CreatePostAsync(It.IsAny<Post>(), It.IsAny<int>()))
                             .Returns((Post createdPost, int id) => createdPost);

            // Act
            var result = await postService.CreatePostAsync(inputPost, blogId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(inputPost.Name, result.Name);
            Assert.Equal(inputPost.Description, result.Description);
        }





        [Fact]
        public void CreatePost_InvalidPost_ThrowsException()
        {
            // Arrange
            var postRepositoryMock = new Mock<IPostRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            var postService = new PostService(postRepositoryMock.Object, blogPostRepositoryMock.Object);

            var blogId = 1;
            var invalidPost = new Post
            {
                // Missing required properties
            };

            // Act and Assert
            Assert.ThrowsAsync<Exception>(() => postService.CreatePostAsync(invalidPost, blogId));
        }
    }
}
