using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DTO;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private BillDAO() { }

        //1. Lấy bill chưa thanh toán theo bàn
        public int GetUnCheckBillByTableId(int tableId)
        {
            string query = "SELECT * FROM Bill WHERE TableId = @tableId AND BillStatus = 0";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                        new object[] { tableId });

            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["BillId"]);
            }

            return -1;
        }
        //2. Tạo bill khi khách vào bàn
        public void InsertBill(int id)
        {
            string query = "INSERT INTO Bill (TableID, DateCheckIn, BillStatus) VALUES ( @tableId , GETDATE() , 0 )";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }

        //3. Thanh toán bill
        public void CheckOut(int billId, int discount)
        {
            string query = "EXEC USP_CheckOut @BillId , @Discount";

            DataProvider.Instance.ExecuteNonQuery(query,
                    new object[] { billId, discount });
        }


        //4. Lấy danh sách bill theo ngày
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            string query =
                "SELECT * FROM Bill " +
                "WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut " +
                "AND BillStatus = 1";

            return DataProvider.Instance.ExecuteQuery(query,
                    new object[] { checkIn, checkOut });
        }
        //5. Lấy id bill mới nhất
        public int GetMaxBillId()
        {
            string query = "SELECT MAX(BillId) FROM Bill";

            object result = DataProvider.Instance.ExecuteScalar(query);

            return result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        //6. Doanh thu 
        public DataTable GetDoanhThuByDate(DateTime fromDate, DateTime toDate)
        {
            string query = "SELECT * FROM V_DoanhThu WHERE Ngay BETWEEN @fromDate AND @toDate";

            return DataProvider.Instance.ExecuteQuery(query,
                    new object[] { fromDate, toDate });
        }
        // Hàm thanh toán hóa đơn
        public void CheckOut(int idBill)
        {
            string query = "UPDATE Bill SET BillStatus = 1 , DateCheckOut = GETDATE() WHERE BillId = @idBill ";

            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBill });
        }

    }
}

