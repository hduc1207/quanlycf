using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class TableFoodDTO
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public string TableStatus { get; set; }

        public TableFoodDTO() { }

        public TableFoodDTO(DataRow row)
        {
            this.TableID = (int)row["TableId"];
            this.TableName = row["TableName"].ToString();
            this.TableStatus = row["TableStatus"].ToString();
        }
    }
}
