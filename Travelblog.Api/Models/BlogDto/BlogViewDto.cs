using Travelblog.Core.Models;

namespace Travelblog.Api.Models.BlogDto
{
    public class BlogViewDto
    {
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Likes { get; set; } = 0;
        public List<Post> Posts { get; set; } = [];
        public DateTime StartDate { get; set; }
        public bool IsPrive { get; set; } = false;
        public bool IsSuspended { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public int Followers { get; set; } = 0;
        public int Trip_Id { get; set; } = 0;
        public List<Country> Countries { get; set; } = new List<Country>();
    }
}
