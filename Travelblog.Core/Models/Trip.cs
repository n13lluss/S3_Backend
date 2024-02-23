using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelblog.Core.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set;}
        public DateTime Trip_Made { get; set; }
        public int Likes { get; set; }
        public List<Country> Countries { get; set; }
        public string Trip_Type { get; set; }
        public List<Transport> Transports { get; set; }
        public Budget Budget { get; set; }
        public Duration Durations { get; set; }
        public DateTime Posted { get;}
        public bool IsPrived { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsDeleted { get; set; }
    }
}
