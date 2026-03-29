using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.Utils; // THÊM DÒNG NÀY ĐỂ GỌI MÃ HOÁ

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

        // Thêm tham số isCurrentLoginAdmin
        public AccountDTO(DataRow row, bool isCurrentLoginAdmin = false)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Password = row["PassWord"].ToString();
            this.Type = Convert.ToInt32(row["AccountType"]);
            if (row["CreatedDate"] != DBNull.Value)
                this.CreateDate = Convert.ToDateTime(row["CreatedDate"]);

            this.Status = Convert.ToInt32(row["AccountStatus"]) == 1;
            string rawFullName = row["FullName"].ToString();
            string rawDisplayName = row["DisplayName"].ToString();
            if (isCurrentLoginAdmin || this.Type == 1)
            {
                this.DisplayName = SecurityHelper.Decrypt(rawDisplayName);
                this.FullName = SecurityHelper.Decrypt(rawFullName);
            }
            else
            {
                this.DisplayName = "*** Dữ liệu bảo mật ***";
                this.FullName = "*** Dữ liệu bảo mật ***";
            }
        }
    }
}