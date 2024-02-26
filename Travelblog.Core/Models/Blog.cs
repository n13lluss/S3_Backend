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
        public int Likes { get; set; } = 0;
        public List<Post> Posts { get; set; } = [];
        public DateTime StartDate { get; set; }
        public bool IsPrive { get; set; } = false;
        public bool IsSuspended { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public List<User> Followers { get; set; } = [];
        public int Trip_Id { get; set; } = 0;
        public List<Country> Countries { get; set; } = new List<Country>();
    }
}
