using QuanLyQuanCafe.DAO;
using System;
using System.Data;

namespace QuanLyQuanCafe.BUS
{
    public class BillBUS
    {
        private static BillBUS instance;
        public static BillBUS Instance
        {
            get { if (instance == null) instance = new BillBUS(); return instance; }
            private set { instance = value; }
        }
        private BillBUS() { }

        // Lấy ID của Hóa đơn chưa thanh toán theo ID Bàn
        public int GetUncheckBillByTableID(int id)
        {
            return BillDAO.Instance.GetUnCheckBillByTableId(id);
        }

        // 2. Tạo hóa đơn mới cho Bàn
        public void InsertBill(int id)
        {
            BillDAO.Instance.InsertBill(id);
        }

        // 3. Lấy ID của hóa đơn vừa mới được tạo lớn nhất
        public int GetMaxIDBill()
        {
            return BillDAO.Instance.GetMaxBillId();
        }

        // 4. Thanh toán hóa đơn
        public void CheckOut(int idBill)
        {
            BillDAO.Instance.CheckOut(idBill);
        }

        // 5. Thanh toán hóa đơn
        public void CheckOut(int billId, int discount)
        {
            BillDAO.Instance.CheckOut(billId, discount);
        }

        // 6. Lấy danh sách Bill theo ngày
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return QuanLyQuanCafe.DAO.BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        // 7. Xem Doanh thu
        public DataTable GetDoanhThuByDate(DateTime fromDate, DateTime toDate)
        {
            return BillDAO.Instance.GetDoanhThuByDate(fromDate, toDate);
        }
        public DataTable GetDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            return BillDAO.Instance.GetDoanhThuTheoNgay(tuNgay, denNgay);
        }

        public DataTable GetMonBanChay(DateTime tuNgay, DateTime denNgay)
        {
            return BillDAO.Instance.GetMonBanChay(tuNgay, denNgay);
        }

    }
}