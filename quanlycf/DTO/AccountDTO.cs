using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class AccountDTO
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        public string FullName { get; set; }
        public AccountDTO() { }

        public AccountDTO(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Password = row["PassWord"].ToString();
            this.Type = Convert.ToInt32(row["AccountType"]);
            this.CreateDate = Convert.ToDateTime(row["CreatedDate"]);
            this.Status = Convert.ToInt32(row["AccountStatus"]) == 1;
            this.FullName = row["FullName"].ToString();
        }
    }
}