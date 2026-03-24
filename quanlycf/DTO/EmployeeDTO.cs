using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EmployeeDTO() { }

        public EmployeeDTO(DataRow row)
        {
            this.EmployeeId = (int)row["EmployeeId"];
            this.FullName = row["FullName"].ToString();

            var birthDateTemp = row["BirthDate"];
            if (birthDateTemp != DBNull.Value)
                this.BirthDate = (DateTime)birthDateTemp;

            this.PhoneNumber = row["PhoneNumber"].ToString();
            this.Address = row["Address"].ToString();
            this.StartDate = (DateTime)row["StartDate"];
            this.UserName = row["UserName"].ToString();
        }
    }
}