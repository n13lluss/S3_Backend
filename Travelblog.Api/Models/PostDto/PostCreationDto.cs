namespace Travelblog.Api.Models.PostDto
{
    public class PostCreationDto
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
