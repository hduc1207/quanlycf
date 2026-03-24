using QuanLyQuanCafe.DAO;
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

        // Hàm xử lý logic đăng nhập
        public bool Login(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                return false;
            }
            return AccountDAO.Instance.Login(userName, passWord);
        }
    }
}