namespace Travelblog.Api.Models.BlogDto
{
    public class BlogCreationDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
