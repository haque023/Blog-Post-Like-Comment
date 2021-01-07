using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text.Json;

namespace BlogPost.Models
{
    public class Utils
    {
        public static ArrayList getJsonOfDatasetFull(DataSet ds)
        {
            ArrayList root = new ArrayList();
            List<Dictionary<string, object>> table;
            Dictionary<string, object> data;
            ArrayList tableData = new ArrayList();

            foreach (DataTable dt in ds.Tables)
            {
                table = new List<Dictionary<string, object>>();
                foreach (DataRow dr in dt.Rows)
                {
                    data = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        data.Add(col.ColumnName, dr[col]);
                    }
                    table.Add(data);
                }
                root.Add(table);
            }

            
            return root;
        }
    }
}
