using QuanLyQuanCafe.DAO;

namespace QuanLyQuanCafe.BUS
{
    public class BillInfoBUS
    {
        private static BillInfoBUS instance;
        public static BillInfoBUS Instance
        {
            get { if (instance == null) instance = new BillInfoBUS(); return instance; }
            private set { instance = value; }
        }
        private BillInfoBUS() { }

        public int InsertBillInfo(int idBill, int idFood, int count, string size, int? parentId = null)
        {
            return BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count, size, parentId);
        }

        // 2. Thêm hoặc Gộp món
        public int AddFoodToBill(int billId, int foodId, int quantity, string size, int? parentId = null)
        {
            return BillInfoDAO.Instance.AddFoodToBill(billId, foodId, quantity, size, parentId);
        }

        // 3. Cập nhật số lượng
        public bool UpdateBillInfoQuantity(int billInfoId, int quantity)
        {
            return BillInfoDAO.Instance.UpdateBillInfoQuantity(billInfoId, quantity);
        }

        // 4. Xóa món
        public bool DeleteBillInfo(int billInfoId)
        {
            return BillInfoDAO.Instance.DeleteBillInfo(billInfoId);
        }
    }
 }
