using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class WasteLogDAO
    {
        private static WasteLogDAO instance;

        public static WasteLogDAO Instance
        {
            get { if (instance == null) instance = new WasteLogDAO(); return instance; }
            private set { instance = value; }
        }

        private WasteLogDAO() { }

        // 1. LẤY DANH SÁCH THẤT THOÁT ĐỔ LÊN BẢNG
        public DataTable GetListWasteLog()
        {
            string query = "SELECT * FROM dbo.WasteLog ORDER BY CreatedAt DESC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 2. THÊM THẤT THOÁT
        public bool InsertWaste(string foodName, int quantity, float lossValue, string reason, string staffName)
        {
            string query = string.Format("INSERT INTO dbo.WasteLog (FoodName, Quantity, LossValue, Reason, StaffName) VALUES ( N'{0}', {1}, {2}, N'{3}', N'{4}' )", foodName, quantity, lossValue, reason, staffName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // 3. SỬA THÔNG TIN
        public bool UpdateWaste(int id, string foodName, int quantity, float lossValue, string reason, string staffName)
        {
            string query = string.Format("UPDATE dbo.WasteLog SET FoodName = N'{0}', Quantity = {1}, LossValue = {2}, Reason = N'{3}', StaffName = N'{4}' WHERE ID = {5}", foodName, quantity, lossValue, reason, staffName, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // 4. XÓA DÒNG LỖI
        public bool DeleteWaste(int id)
        {
            string query = "DELETE dbo.WasteLog WHERE ID = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}