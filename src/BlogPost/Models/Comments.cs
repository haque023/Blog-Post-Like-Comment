using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Models
{
    public class Comments
    {
        public string blogCode { get; set; }
        public string commentCode { get; set; }
        public string commenterCode { get; set; }
        public string commentText { get; set; }
        public string commenterName { get; set; }
        public string like { get; set; }
        public string dislike { get; set; }
        public DateTime commentTime { get; set; }
        public string myStatus { get; set; }
    }
}
