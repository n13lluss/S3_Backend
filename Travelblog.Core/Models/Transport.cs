using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelblog.Core.Models
{
    public class Transport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Start_Location { get; set; }
        public string End_Location { get; set; }
    }
}
