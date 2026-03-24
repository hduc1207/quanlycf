using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Collections.Generic;

namespace QuanLyQuanCafe.BUS
{
    public class AccountBUS
    {
        private static AccountBUS instance;
        public static AccountBUS Instance
        {
            get { if (instance == null) instance = new AccountBUS(); return instance; }
            private set { instance = value; }
        }
        private AccountBUS() { }

        // 1. Lấy danh sách
        public List<AccountDTO> GetListAccount()
        {
            return AccountDAO.Instance.GetListAccount();
        }

        // 2. Thêm mới (Đủ 5 tham số để chiều lòng cái Procedure của bạn)
        public bool InsertAccount(string userName, string displayName, int type, string fullName, string phone)
        {
            return AccountDAO.Instance.InsertAccount(userName, displayName, type, fullName, phone);
        }

        // 3. Sửa thông tin (Gọi đúng hàm AdminUpdateAccount)
        public bool AdminUpdateAccount(string userName, string displayName, int type)
        {
            return AccountDAO.Instance.AdminUpdateAccount(userName, displayName, type);
        }

        // 4. Xóa
        public bool DeleteAccount(string userName)
        {
            return AccountDAO.Instance.DeleteAccount(userName);
        }
    }
}