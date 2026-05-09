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
    public class clsManageUsersData
    {

        static public DataTable GetAllUsers()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                string query = @"SELECT 
                        UserID As [User ID],
                        Users.PersonID As [Person ID],
                        CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) AS [Full Name],
                        UserName,
                        IsActive As [Is Active]
                    FROM Users
                    INNER JOIN People ON Users.PersonID = People.PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
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

    }
}
