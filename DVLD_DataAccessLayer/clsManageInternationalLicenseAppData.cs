using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsManageInternationalLicenseAppData
    {
        static public DataTable GetAllInternationalLicense()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        InternationalLicenseID AS [int License ID], ApplicationID As [Application ID], DriverID As [Driver ID], IssuedUsingLocalLicenseID AS [L.License ID], 
                            IssueDate AS [Issue Date], ExpirationDate AS [Expiration Date], IsActive As [Is Active]
                            FROM            InternationalLicenses";
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
            connection.Close();
            return dataTable;
        }

    }
}
