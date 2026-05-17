using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsManageApplicationsTypesData
    {

        static public DataTable GetApplicationsTypesTable()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select  ApplicationTypeID As [ID], ApplicationTypeTitle As [Title], ApplicationFees As [Fees] from ApplicationTypes";

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

            finally
            {
                connection.Close();
            }
            return dataTable;

        }

        static public bool FindApplication(int ApplicationID, ref string ApplicationTitle, ref int ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select ApplicationTypeID As [ID], ApplicationTypeTitle As [Title], ApplicationFees As [Fees] from ApplicationTypes where ApplicationTypeID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ApplicationTitle = (string)reader["Title"];
                    ApplicationFees = Convert.ToInt32(reader["Fees"]);
                    return true;
                }
            }
            catch (Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }

            finally
            {
                connection.Close();
            }
            return false;

        }

        static public bool UpdateApplicationType(int ApplicationID, string ApplicationTitle, int ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"update ApplicationTypes 
                            set ApplicationTypeTitle = @ApplicationTitle,
                            ApplicationFees = @ApplicationFees 
                            Where ApplicationTypeID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationTitle", ApplicationTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

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

            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }

    }
}
