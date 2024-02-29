using Travelblog.Core.Models;

namespace Travelblog.Api.Models.BlogDto
{
    public class UpdateBlogDto
    {
        public string Name { get; set; }
        public bool IsPrive { get; set; } = false;
        public bool IsSuspended { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public int Trip_Id { get; set; } = 0;
    }
}
