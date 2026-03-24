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

        //Thêm bàn
        public bool InsertTable(string tableName)
        {
            string query = "INSERT INTO TableFood(TableName) VALUES (@tableName)";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tableName });
            return result > 0;
        }
        //Update bàn
        public bool UpdateTable(int tableId, string tableName)
        {
            string query = "UPDATE TableFood SET TableName = @tableName WHERE TableId = @tableId";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tableId, tableName });
            return result > 0;
        }
        //Xóa bàn
        public bool DeleteTable(int tableId)
        {
            string query = "DELETE FROM TableFood WHERE TableId = @tableId";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tableId });
            return result > 0;
        }
    }
}
