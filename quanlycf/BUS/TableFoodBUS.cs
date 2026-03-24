using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyQuanCafe.BUS
{
    public class TableFoodBUS
    {
        private static TableFoodBUS instance;
        public static TableFoodBUS Instance
        {
            get { if (instance == null) instance = new TableFoodBUS(); return instance; }
            private set { instance = value; }
        }
        private TableFoodBUS() { }

        // Gọi xuống DAO để lấy danh sách bàn
        public List<TableFoodDTO> GetListTable()
        {
            return TableFoodDAO.Instance.GetListTable();
        }
        // Thêm bàn mới
        public bool InsertTable(string name)
        {
            return QuanLyQuanCafe.DAO.TableFoodDAO.Instance.InsertTable(name);
        }

        // Sửa tên bàn
        public bool UpdateTable(int id, string name)
        {
            return QuanLyQuanCafe.DAO.TableFoodDAO.Instance.UpdateTable(id, name);
        }

        // Xóa bàn
        public bool DeleteTable(int id)
        {
            return QuanLyQuanCafe.DAO.TableFoodDAO.Instance.DeleteTable(id);
        }
    }
}