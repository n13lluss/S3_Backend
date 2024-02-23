using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelblog.Core.Models
{
    public class Preference
    {
        public int Id { get; set; }
        public string Theme { get; set; } = string.Empty;
    }
}
