using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Models
{
    public class Report
    {
        public string blogCode { get; set; }
        public string blogText { get; set; }
        public string blogger { get; set; }
        public string bloggerCode { get; set; }
        public DateTime blogTime { get; set; }
        public List<Comments> comments { get; set; }
    }
}
