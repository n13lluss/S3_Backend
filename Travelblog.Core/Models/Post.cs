namespace Travelblog.Core.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int Likes { get; set; } = 0;
        public List<Reaction> Reactions { get; set; } = [];
        public List<Country> Countries { get; set; } = [];
        public List<Tag> Tags { get; set; } = [];
        public DateTime Posted {  get; set; } = DateTime.Now;
        public bool IsPrive { get; set; } = false;
        public bool IsSuspended { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public int TripId { get; set; } = 0;
    }
}
