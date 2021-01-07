using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
namespace BlogPost.Models
{
    public class BlogManage
    {
        public string userCode { get; set; }
        public string blogText { get; set; }
        public string commentText { get; set; }
        public string blogCode { get; set; }
        public string likeDeslikeCode { get; set; }
        public string likeDeslike { get; set; }
        public string commentCode { get; set; }
        public string Flag { get; set; }

        public DataSet blogGetSet(BlogManage blog)
        {


            DataSet ds = SqlHelper.ExecuteDataset(new SqlConnection("Data Source=.;Initial Catalog=blogPost;Integrated Security=False;Connection Timeout=60; User ID=sa;Password=12345678"),
             CommandType.StoredProcedure, "[blogManage]",
             new SqlParameter("userCode", blog.userCode),
             new SqlParameter("blogText", blog.blogText),
             new SqlParameter("blogCode", blog.blogCode),
             new SqlParameter("commentText", blog.commentText),
             new SqlParameter("likeDeslikeCode", blog.likeDeslikeCode),
             new SqlParameter("likeDeslike", blog.likeDeslike),
             new SqlParameter("commentCode", blog.commentCode),
             new SqlParameter("Flag", blog.Flag)
             );

            return ds;
        }

    }
}
