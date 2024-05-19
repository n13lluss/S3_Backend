using Travelblog.Core.Models;

namespace Travelblog.Api.Models.BlogDto
{
    public class BlogSlimDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string User_Name { get; set; } = string.Empty;
        public string Creator_Id { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateTime Posted_On { get; set; }
        public List<Country> Countries { get; set; }
        public int likes { get; set; }
        public bool liked { get; set; }
    }
}
