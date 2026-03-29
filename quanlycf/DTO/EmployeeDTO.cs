using QuanLyQuanCafe.Utils;
using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public EmployeeDTO() { }

        public EmployeeDTO(DataRow row, bool isDecrypted = true)
        {
            this.EmployeeId = (int)row["EmployeeId"];
            string rawFullName = row["FullName"].ToString();
            string rawPhone = row["PhoneNumber"] != DBNull.Value ? row["PhoneNumber"].ToString() : "";
            string rawAddress = row["Address"] != DBNull.Value ? row["Address"].ToString() : "";
            string rawEmail = row["Email"] != DBNull.Value ? row["Email"].ToString() : "";

            // 2. Giải mã bằng SecurityHelper
            if (isDecrypted)
            {
                this.FullName = SecurityHelper.Decrypt(rawFullName);
                this.PhoneNumber = SecurityHelper.Decrypt(rawPhone);
                this.Address = SecurityHelper.Decrypt(rawAddress);
                this.Email = string.IsNullOrEmpty(rawEmail) ? "" : SecurityHelper.Decrypt(rawEmail);
            }
            else
            {
                this.FullName = "***";
                this.PhoneNumber = "***";
                this.Address = "***";
                this.Email = "***";
            }
            var birthDateTemp = row["BirthDate"];
            if (birthDateTemp != DBNull.Value)
                this.BirthDate = (DateTime)birthDateTemp;

            this.StartDate = (DateTime)row["StartDate"];
            this.UserName = row["UserName"].ToString();
        }
    }
}