namespace Travelblog.Api.Models.BlogDto
{
    public class BlogCreationDto
    {
        public string Username { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
