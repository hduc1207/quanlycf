using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private BillInfoDAO() { }

        //1.Lấy danh sách món trong bill
        public int GetBillInfoId(int billId, int foodId, string size, int? parentId)
        {
            string query =
                "SELECT BillInfoId FROM BillInfo " +
                "WHERE BillId = @billId AND FoodId = @foodId AND Size = @size " +
                "AND ((ParentId IS NULL AND @parentId IS NULL) OR ParentId = @parentId)";

            object result = DataProvider.Instance.ExecuteScalar(query,
                new object[] { billId, foodId, size, (object)parentId ?? DBNull.Value });

            return (result == null || result == DBNull.Value) ? -1 : Convert.ToInt32(result);
        }

        //2.Hiện thị Bill
        public DataTable GetListBillInfoByTable(int tableId)
        {
            string query =
                "SELECT F.FoodName, BI.Size, BI.Quantity, F.Price, " +
                "(BI.Quantity * F.Price) AS TotalPrice, BI.ParentId, BI.BillInfoId " +
                "FROM BillInfo BI " +
                "JOIN Bill B ON BI.BillId = B.BillId " +
                "JOIN Food F ON BI.FoodId = F.FoodId " +
                "WHERE B.TableId = @tableId AND B.BillStatus = 0 " +
                "ORDER BY ISNULL(BI.ParentId, BI.BillInfoId), " +
                "CASE WHEN BI.ParentId IS NULL THEN 0 ELSE 1 END";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { tableId });
        }

        //3.Thêm món vào bill
        public int InsertBillInfo(int billId, int foodId, int quantity, string size, int? parentId = null)
        {
            string query =
                "INSERT INTO BillInfo(BillId, FoodId, Quantity, Size, ParentId) " +
                "VALUES(@billId, @foodId, @quantity, @size, @parentId); " +
                "SELECT SCOPE_IDENTITY();";

            object result = DataProvider.Instance.ExecuteScalar(query,
                new object[] { billId, foodId, quantity, size, (object)parentId ?? DBNull.Value });

            return (result == null || result == DBNull.Value) ? -1 : Convert.ToInt32(result);
        }

        //4.Cập nhật số lượng món
        public bool UpdateBillInfoQuantity(int billInfoId, int quantity)
        {
            if (quantity <= 0)
                return DeleteBillInfo(billInfoId);
            string query = "UPDATE BillInfo SET Quantity = @quantity WHERE BillInfoId = @id ";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { quantity, billInfoId });

            return result > 0;
        }

        //5.Xóa món khỏi bill
        public bool DeleteBillInfo(int billInfoId)
        {
            string query = "DELETE FROM BillInfo WHERE ParentId = @id1 OR BillInfoId = @id2 ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { billInfoId, billInfoId });

            return result > 0;
        }

        //6.Lấy số lượng
        public int GetQuantity(int billInfoId)
        {
            string query = "SELECT Quantity FROM BillInfo WHERE BillInfoId = @id";

            object result = DataProvider.Instance.ExecuteScalar(query,
                new object[] { billInfoId });

            return result == null ? 0 : Convert.ToInt32(result);
        }

        //7.Thêm gộp món
        public int AddFoodToBill(int billId, int foodId, int quantity, string size, int? parentId = null)
        {
            int id = GetBillInfoId(billId, foodId, size, parentId);

            if (id != -1)
            {
                int currentQuantity = GetQuantity(id);
                UpdateBillInfoQuantity(id, currentQuantity + quantity);
                return id;
            }
            else
            {
                return InsertBillInfo(billId, foodId, quantity, size, parentId);
            }
        }
    }
}

