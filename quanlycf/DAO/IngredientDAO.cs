using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DTO;
using System.Data;


namespace QuanLyQuanCafe.DAO
{
    public class IngredientDAO
    {
        private static IngredientDAO instance;

        public static IngredientDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new IngredientDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private IngredientDAO() { }

        //1. Lấy toàn bộ nguyên liệu
        public DataTable GetListIngredient()
        {
            string query = "SELECT * FROM Ingredient";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        //2. Thêm nguyên liệu mới
        public bool InsertIngredient(string name, string unit, double quantity, decimal price, double minQuantity)
        {
            string query =
                "INSERT INTO Ingredient(IngredientName, Unit, Quantity, UnitPrice, MinQuantity) " +
                "VALUES(@name, @unit, @quantity, @price, @min)";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { name, unit, quantity, price, minQuantity });

            return result > 0;
        }

        //3. Cập nhật nguyên liệu
        public bool UpdateIngredient(int IngredientId, string name, string unit, double quantity, decimal price, double minQuantity)
        {
            string query =
                "UPDATE Ingredient SET " +
                "IngredientName = @name, Unit = @unit, Quantity = @quantity, " +
                "UnitPrice = @price, MinQuantity = @min " +
                "WHERE IngredientId = @IngredientId";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { name, unit, quantity, price, minQuantity, IngredientId });

            return result > 0;
        }

        // 4. Xóa nguyên liệu
        public bool DeleteIngredient(int IngredientId)
        {
            string query = "DELETE FROM Ingredient WHERE IngredientId = @IngredientId";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { IngredientId });

            return result > 0;
        }

        // 5. Nhập kho (QUAN TRỌNG)
        public bool ImportIngredient(int IngredientId, double quantity, decimal price)
        {
            string query =
                "UPDATE Ingredient SET " +
                "Quantity = Quantity + @quantity, " +
                "UnitPrice = @price " +
                "WHERE IngredientId = @IngredientId";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { quantity, price, IngredientId });

            return result > 0;
        }

        // 6. Lấy nguyên liệu theo ID
        public IngredientDTO GetIngredientById(int IngredientId)
        {
            string query = "SELECT * FROM Ingredient WHERE IngredientId = @IngredientId";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { IngredientId });

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new IngredientDTO(row);
            }

            return null;
        }

        //7. Cảnh báo nguyên liệu sắp hết
        public DataTable GetLowIngredient()
        {
            string query = "SELECT * FROM V_CanhBaoNguyenLieu";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool IsIngredientUsed(int ingredientId)
        {
            string query = "SELECT COUNT(*) FROM Recipe WHERE IngredientId = @id";
            int count = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { ingredientId });
            return count > 0;
        }
        // 8. Hàm tự động trừ kho dựa vào ID Hóa Đơn
        public bool TruNguyenLieuTuHoaDon(int billId)
        {
            string query = @"
                UPDATE I
                SET I.Quantity = I.Quantity - TotalDeduction.TotalAmount
                FROM Ingredient I
                JOIN (
                    SELECT R.IngredientId, SUM(BI.Quantity * R.Amount) AS TotalAmount
                    FROM BillInfo BI
                    JOIN Recipe R ON BI.FoodId = R.FoodId AND BI.Size = R.Size
                    WHERE BI.BillId = @billId 
                    GROUP BY R.IngredientId
                ) AS TotalDeduction ON I.IngredientId = TotalDeduction.IngredientId";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { billId });
            return result > 0;
        }
    }
}
