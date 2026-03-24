using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Data;

namespace QuanLyQuanCafe.BUS
{
    public class IngredientBUS
    {
        private static IngredientBUS instance;

        public static IngredientBUS Instance
        {
            get { if (instance == null) instance = new IngredientBUS(); return instance; }
            private set { instance = value; }
        }

        private IngredientBUS() { }

        // 1. Lấy toàn bộ nguyên liệu
        public DataTable GetListIngredient()
        {
            return IngredientDAO.Instance.GetListIngredient();
        }

        // 2. Thêm nguyên liệu
        public bool InsertIngredient(string name, string unit, double quantity, decimal price, double minQuantity)
        {
            return IngredientDAO.Instance.InsertIngredient(name, unit, quantity, price, minQuantity);
        }

        // 3. Sửa nguyên liệu
        public bool UpdateIngredient(int id, string name, string unit, double quantity, decimal price, double minQuantity)
        {
            return IngredientDAO.Instance.UpdateIngredient(id, name, unit, quantity, price, minQuantity);
        }

        // 4. Xóa nguyên liệu
        public bool DeleteIngredient(int id)
        {
            return IngredientDAO.Instance.DeleteIngredient(id);
        }

        // 5. Nhập kho thêm số lượng
        public bool ImportIngredient(int id, double quantity, decimal price)
        {
            return IngredientDAO.Instance.ImportIngredient(id, quantity, price);
        }

        // 6. Lấy nguyên liệu theo ID
        public IngredientDTO GetIngredientById(int id)
        {
            return IngredientDAO.Instance.GetIngredientById(id);
        }

        // 7. Lấy danh sách nguyên liệu sắp hết
        public DataTable GetLowIngredient()
        {
            return IngredientDAO.Instance.GetLowIngredient();
        }

        // 8. Kiểm tra nguyên liệu đã được dùng chưa
        public bool IsIngredientUsed(int id)
        {
            return IngredientDAO.Instance.IsIngredientUsed(id);
        }
        // 9. Trừ nguyên liệu khi thanh toán hóa đơn
        public bool TruNguyenLieuTuHoaDon(int billId)
        {
            return QuanLyQuanCafe.DAO.IngredientDAO.Instance.TruNguyenLieuTuHoaDon(billId);
        }
    }
}