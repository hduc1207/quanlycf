using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

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
        public bool Login(string userName, string passWord)
        {
            string hashedPassword = SecurityHelper.HashPassword(passWord);
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashedPassword });

            return result.Rows.Count > 0;
        }

        // 2. Lấy Account kèm theo FullName từ bảng Employee
        public AccountDTO GetAccountByUserName(string userName, bool isCurrentLoginAdmin = true)
        {
            string query = "SELECT a.*, e.FullName FROM Account a LEFT JOIN Employee e ON a.UserName = e.UserName WHERE a.UserName = @userName";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });

            foreach (DataRow row in data.Rows)
            {
                return new AccountDTO(row, isCurrentLoginAdmin);
            }
            return null;
        }

        // 3. Thêm Account dùng Procedure
        public bool InsertAccount(string userName, string displayName, int type, string fullName, string phone)
        {
            // Mã hoá Dữ liệu nhạy cảm trước khi lưu
            string encryptedDisplayName = SecurityHelper.Encrypt(displayName);
            string encryptedFullName = SecurityHelper.Encrypt(fullName);
            string encryptedPhone = SecurityHelper.Encrypt(phone);
            string query = "USP_InsertEmployeeWithAccount @userName , @displayName , @type , @fullName , @phone";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, type, encryptedFullName, encryptedPhone });

            return result > 0;
        }

        // 4. Update thông tin tài khoản 
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass, string fullName, string phone, string email, DateTime? birthDate)
        {
            string encryptedFullName = string.IsNullOrEmpty(fullName) ? null : SecurityHelper.Encrypt(fullName);
            string encryptedPhone = string.IsNullOrEmpty(phone) ? null : SecurityHelper.Encrypt(phone);
            string encryptedEmail = string.IsNullOrEmpty(email) ? null : SecurityHelper.Encrypt(email);
            string hashedOldPass = string.IsNullOrEmpty(pass) ? "" : SecurityHelper.HashPassword(pass);
            string hashedNewPass = string.IsNullOrEmpty(newPass) ? "" : SecurityHelper.HashPassword(newPass);

            string query = "USP_UpdateAccount @userName , @displayName , @password , @newPassword , @fullName , @phone , @email , @birthDate";
            object objFullName = string.IsNullOrEmpty(encryptedFullName) ? (object)DBNull.Value : encryptedFullName;
            object objPhone = string.IsNullOrEmpty(encryptedPhone) ? (object)DBNull.Value : encryptedPhone;
            object objEmail = string.IsNullOrEmpty(encryptedEmail) ? (object)DBNull.Value : encryptedEmail;
            object objBirthDate = birthDate.HasValue ? (object)birthDate.Value : DBNull.Value;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {
        userName, displayName, hashedOldPass, hashedNewPass, objFullName, objPhone, objEmail, objBirthDate
    });

            return result > 0;
        }

        // 5. Reset mật khẩu 
        public bool ResetPassword(string userName, string newPassword)
        {
            string hashedPassword = SecurityHelper.HashPassword(newPassword);
            string query = "UPDATE Account SET PassWord = @pass WHERE UserName = @userName";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { hashedPassword, userName });

            return result > 0;
        }

        // 6. Xóa tài khoản 
        public bool DeleteAccount(string userName)
        {
            string query = "UPDATE Account SET AccountStatus = 0 WHERE UserName = @userName";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName });

            return result > 0;
        }

        // Thêm tham số isCurrentLoginAdmin để quyết định quyền giải mã
        public List<AccountDTO> GetListAccount(bool isCurrentLoginAdmin)
        {
            List<AccountDTO> list = new List<AccountDTO>();
            string query = "SELECT a.*, e.FullName FROM dbo.Account a LEFT JOIN dbo.Employee e ON a.UserName = e.UserName WHERE a.AccountStatus = 1 OR a.AccountStatus IS NULL";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item, isCurrentLoginAdmin);
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

        public string GetEmailByUserName(string userName)
        {
            string query = "SELECT Email FROM dbo.Employee WHERE UserName = @userName";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });

            if (data.Rows.Count > 0 && data.Rows[0]["Email"] != DBNull.Value)
            {
                string encryptedEmail = data.Rows[0]["Email"].ToString();
                return SecurityHelper.Decrypt(encryptedEmail);
            }

            return "";
        }
    }
}