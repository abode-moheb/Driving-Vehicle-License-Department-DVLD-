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
    public class clsListDriversData
    {
        static public DataTable GetDriversList()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        Drivers.DriverID As [Driver ID], Drivers.PersonID As [Person ID], People.NationalNo As [National No], dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS [Full Name], 
                         Drivers.CreatedDate As [Created Date],
                             (SELECT        COUNT(LicenseID)
                               FROM            dbo.Licenses
                               WHERE        (IsActive = 1) AND (DriverID = dbo.Drivers.DriverID)) AS [Active Licenses]
                          FROM            dbo.Drivers INNER JOIN
                         dbo.People ON dbo.Drivers.PersonID = dbo.People.PersonID";
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
