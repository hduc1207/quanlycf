using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfoDTO
    {
        public int BillInfoId { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public int? ParentId { get; set; }

        public BillInfoDTO() { }

        public BillInfoDTO(DataRow row)
        {
            BillInfoId = (int)row["BillInfoId"];
            BillId = (int)row["BillId"];
            FoodId = (int)row["FoodId"];
            Quantity = (int)row["Quantity"];
            ParentId = row["ParentId"] == DBNull.Value ? null : (int?)row["ParentId"];
        }
    }
}

