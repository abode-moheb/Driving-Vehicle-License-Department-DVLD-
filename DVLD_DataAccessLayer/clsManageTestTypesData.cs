using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DVLD_DataAccessLayer
{
     public class clsManageTestTypesData
    {

        static public DataTable LoadTestTypesTable()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select TestTypeID As [ID], TestTypeTitle As [Title] , TestTypeDescription As [Description] 
                            , TestTypeFees AS[Fees] from TestTypes";

            SqlCommand command = new SqlCommand(query, connection);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
            return dataTable;
        }

        public static bool FindTest(int TestID, ref string TestTitle, ref string TestDescription, ref int TestFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from TestTypes Where TestTypeID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TestTitle = (string)reader["TestTypeTitle"];
                    TestDescription = (string)reader["TestTypeDescription"];
                    TestFees = Convert.ToInt32(reader["TestTypeFees"]);
                    return true;
                }
            }
            catch (Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
            return false;

        }

        public static bool _UpdateTestTypes(int TestID, string TestTitle, string TestDescription, int TestFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update TestTypes set TestTypeTitle = @TestTitle,
                            TestTypeDescription = @TestDescription,
                            TestTypeFees = @TestFees 
                            Where TestTypeID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestTitle", TestTitle);
            command.Parameters.AddWithValue("@TestDescription", TestDescription);
            command.Parameters.AddWithValue("@TestFees", TestFees);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
            return (RowsAffected > 0);
        }       

     }
}
