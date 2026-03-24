using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillDTO
    {
        public int BillId { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int TableId { get; set; }
        public int BillStatus { get; set; }
        public int Discount { get; set; }
        public decimal TotalPrice { get; set; }

        public BillDTO() { }

        public BillDTO(DataRow row)
        {
            BillId = (int)row["BillId"];
            DateCheckIn = (DateTime)row["DateCheckIn"];
            DateCheckOut = row["DateCheckOut"] == DBNull.Value ? null : (DateTime?)row["DateCheckOut"];
            TableId = (int)row["TableId"];
            BillStatus = (int)row["BillStatus"];
            Discount = (int)row["Discount"];
            TotalPrice = (decimal)row["TotalPrice"];
        }
    }

}
