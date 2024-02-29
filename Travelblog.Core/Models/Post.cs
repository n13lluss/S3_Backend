namespace Travelblog.Core.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Likes { get; set; }
        public List<Reaction> Reactions { get; set; } = [];
        public List<Country> Countries { get; set; } = [];
        public List<Tag> Tags { get; set; } = [];
        public DateTime Posted {  get; set; }
        public bool IsPrive { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsDeleted { get; set; }
    }
}
