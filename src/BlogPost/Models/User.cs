
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient; 

namespace BlogPost.Models
{
      

    public class User
    {
        public string name { get; set; }
        public string userCode { get; set; }
        public string flag { get; set; }
        public DataSet userGetSet(User user)
        {
        

            DataSet ds = SqlHelper.ExecuteDataset(new SqlConnection("Data Source=.;Initial Catalog=blogPost;Integrated Security=False;Connection Timeout=60; User ID=sa;Password=12345678"),
             CommandType.StoredProcedure, "[userInfo]",
             new SqlParameter("name", user.name),
             new SqlParameter("Flag", user.flag)
             );

            return ds;
        }


    }
}
