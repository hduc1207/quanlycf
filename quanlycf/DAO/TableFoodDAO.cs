using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableFoodDAO
    {
        private static TableFoodDAO instance;
        public static TableFoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TableFoodDAO();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private TableFoodDAO() { }

        //Lấy danh sách table
        public List<TableFoodDTO> GetListTable()
        {
            List<TableFoodDTO> list = new List<TableFoodDTO>();
            string query = "SELECT * FROM TableFood";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                TableFoodDTO table = new TableFoodDTO(row);
                list.Add(table);
            }
            return list;
        }

        // Hàm Thêm
        public bool InsertTable(string name)
        {
            // Sửa cột name thành TableName, status thành TableStatus (Hoặc tên đúng trong SQL của bạn)
            string query = "INSERT dbo.TableFood ( TableName, TableStatus ) VALUES ( @name , N'Trống' )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name });
            return result > 0;
        }

        // Hàm Sửa
        public bool UpdateTable(int id, string name)
        {
            // Sửa cột name thành TableName, id thành TableId
            string query = "UPDATE dbo.TableFood SET TableName = @name WHERE TableId = @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, id });
            return result > 0;
        }

        // Hàm Xóa
        public bool DeleteTable(int id)
        {
            // Sửa cột id thành TableId
            string query = "DELETE dbo.TableFood WHERE TableId = @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }
        public bool SwitchTable(int idOldTable, int idNewTable)
        {
            string query1 = "UPDATE Bill SET TableId = @idNew WHERE TableId = @idOld AND BillStatus = 0";
            DataProvider.Instance.ExecuteNonQuery(query1, new object[] { idNewTable, idOldTable });
            string query2 = "UPDATE TableFood SET TableStatus = N'Trống' WHERE TableId = @idOld";
            DataProvider.Instance.ExecuteNonQuery(query2, new object[] { idOldTable });
            string query3 = "UPDATE TableFood SET TableStatus = N'Có người' WHERE TableId = @idNew";
            DataProvider.Instance.ExecuteNonQuery(query3, new object[] { idNewTable });

            return true;
        }
    }
}

