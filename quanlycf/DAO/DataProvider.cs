using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace QuanLyQuanCafe.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() { }


        private string connectionStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLQUANCAFE;Integrated Security=True;TrustServerCertificate=True";

        // Select
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    AddParametersToCommand(cmd, query, parameter);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }

        // Insert, update, delete
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    AddParametersToCommand(cmd, query, parameter);
                }
                data = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = null;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    AddParametersToCommand(command, query, parameter);
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }

        /// <summary>
        /// Extracts parameter names from SQL query and adds them to SqlCommand in order
        /// </summary>
        private void AddParametersToCommand(SqlCommand command, string query, object[] parameter)
        {
            List<string> parameterNames = new List<string>();
            HashSet<string> addedParams = new HashSet<string>();

            // Extract all @paramName occurrences using regex
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"@(\w+)");
            System.Text.RegularExpressions.MatchCollection matches = regex.Matches(query);

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                string paramName = "@" + match.Groups[1].Value;
                if (!addedParams.Contains(paramName))
                {
                    parameterNames.Add(paramName);
                    addedParams.Add(paramName);
                }
            }

            // Add parameters in the order they appear in the query
            for (int i = 0; i < parameterNames.Count && i < parameter.Length; i++)
            {
                command.Parameters.AddWithValue(parameterNames[i], parameter[i]);
            }
        }
    }
}