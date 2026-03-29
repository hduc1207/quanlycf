using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class EmployeeDAO
    {
        //1. Lấy danh sách nhân viên
        public List<EmployeeDTO> GetListEmployee()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            string query = "SELECT * FROM Employee";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO employee = new EmployeeDTO(item);
                list.Add(employee);
            }
            return list;
        }

        //2. Thêm nhân viên
        public bool InsertEmployee(string userName, string displayName, int type, string fullName, string phone)
        {
            string query = "USP_InsertEmployeeWithAccount @userName , @displayName , @type , @fullName , @phone";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, type, fullName, phone });

            return result > 0;
        }
        //3. Sửa nhân viên
        public bool UpdateEmployee(int id, string fullName, string phone, string address, string email, DateTime birthDate)
        {
            string query = string.Format("UPDATE Employee SET FullName = N'{0}', PhoneNumber = '{1}', Address = N'{2}', BirthDate = '{3}', Email = N'{4}' WHERE EmployeeId = {5}", fullName, phone, address, birthDate, email, id);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        //4. Xóa nhân viên
        public bool DeleteEmployee(int id)
        {
            string query = "DELETE Employee WHERE EmployeeId = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //5. Tìm kiếm nhân viên
        public List<EmployeeDTO> SearchEmployeeByName(string name)
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            string query = "SELECT * FROM Employee";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO employee = new EmployeeDTO(item, true);
                list.Add(employee);
            }
            return list;
        }
        //6. Lấy nhân viên theo username
        public EmployeeDTO GetEmployeeByUserName(string userName)
        {
            string query = "SELECT * FROM Employee WHERE UserName = '" + userName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new EmployeeDTO(item);
            }
            return null;
        }
    }
}
