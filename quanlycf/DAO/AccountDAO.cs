using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }

        // 1. Login
        public bool Login(string userName, string passWord)
        {
            
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        // 2. Lấy Account kèm theo FullName từ bảng Employee
        public AccountDTO GetAccountByUserName(string userName)
        {
            string query = "SELECT a.*, e.FullName FROM Account a LEFT JOIN Employee e ON a.UserName = e.UserName WHERE a.UserName = @userName";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });

            foreach (DataRow row in data.Rows)
            {
                return new AccountDTO(row);
            }
            return null;
        }

        // 3.  Thêm Account dùng Procedure
        public bool InsertAccount(string userName, string displayName, int type, string fullName, string phone)
        {
            // Gọi Procedure USP_InsertEmployeeWithAccount
            string query = "USP_InsertEmployeeWithAccount @userName , @displayName , @type , @fullName , @phone";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, type, fullName, phone });

            return result > 0;
        }

        // 4. Update thông tin tài khoản 
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            string query = "USP_UpdateAccount @userName , @displayName , @password , @newPassword";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }

        // 5. Reset mật khẩu 
        public bool ResetPassword(string userName)
        {
            string query = "UPDATE Account SET PassWord = N'1' WHERE UserName = @userName";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName });

            return result > 0;
        }

        // 6. Xóa tài khoản 
        public bool DeleteAccount(string userName)
        {
            string query = "UPDATE Account SET AccountStatus = 0 WHERE UserName = @userName";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName });

            return result > 0;
        }
        public List<AccountDTO> GetListAccount()
        {
            List<AccountDTO> list = new List<AccountDTO>();
            string query = "SELECT a.*, e.FullName FROM dbo.Account a LEFT JOIN dbo.Employee e ON a.UserName = e.UserName WHERE a.AccountStatus = 1 OR a.AccountStatus IS NULL";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                list.Add(account);
            }
            return list;
        }
        public bool AdminUpdateAccount(string userName, string displayName, int type)
        {
            string query = "UPDATE dbo.Account SET DisplayName = @displayName , AccountType = @type WHERE UserName = @userName";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { displayName, type, userName });
            return result > 0;
        }
    }
}