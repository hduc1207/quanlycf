using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System;

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

        // 1. Lấy danh sách - SỬA
        public List<AccountDTO> GetListAccount(bool isCurrentLoginAdmin)
        {
            return AccountDAO.Instance.GetListAccount(isCurrentLoginAdmin);
        }

        // 2. Thêm mới
        public bool InsertAccount(string userName, string displayName, int type, string fullName, string phone)
        {
            return AccountDAO.Instance.InsertAccount(userName, displayName, type, fullName, phone);
        }

        // 3. Sửa thông tin (Bởi Admin)
        public bool AdminUpdateAccount(string userName, string displayName, int type)
        {
            return AccountDAO.Instance.AdminUpdateAccount(userName, displayName, type);
        }

        // 4. Xóa
        public bool DeleteAccount(string userName)
        {
            return AccountDAO.Instance.DeleteAccount(userName);
        }

        // 5. Cập nhật tài khoản cá nhân
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass, string fullName, string phone, string email, DateTime? birthDate)
        {
            return AccountDAO.Instance.UpdateAccount(userName, displayName, pass, newPass, fullName, phone, email, birthDate);
        }
        // 6. Đăng nhập
        public bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        // 7. Lấy tài khoản theo tên đăng nhập
        public AccountDTO GetAccountByUserName(string userName, bool isCurrentLoginAdmin = true)
        {
            return AccountDAO.Instance.GetAccountByUserName(userName, isCurrentLoginAdmin);
        }
    }
}