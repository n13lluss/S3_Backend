using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelblog.Core.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public int Likes { get; set; }
        public List<Post> Posts { get; set; } = [];
        public DateTime StartDate { get; set; }
        public bool IsPrive { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsDeleted { get; set; }
        public List<User> Followers { get; set; } = [];
        public int Trip_Id { get; set; }
        public List<Country> Countries { get; set; }
    }
}
