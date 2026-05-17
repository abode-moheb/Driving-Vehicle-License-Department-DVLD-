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
            connection.Close();
            return dataTable;
        }

        public static bool CheckIfPersonIsUser(int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT 1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            bool IsFound = false;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
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

            return IsFound;
        }

        public static int AddNewUserAndGetID(int PersonID, string UserName,string Password,bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Insert into Users (PersonID,UserName,Password,IsActive) Values (@PersonID,@UserName,@Password,@IsActive);" +
                            "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            int InsertedID = -1;
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int id))
                {
                    InsertedID = id;
                }
            }
            catch(Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
            connection.Close();


            return InsertedID;
        }

        public static bool Find(int UserID, ref int PersonID, ref string UserName, ref string Password , ref bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from Users Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

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

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update Users set  UserName = @UserName,
                                               Password = @Password,
                                               IsActive = @IsActive                                           
                                               Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            command.Parameters.AddWithValue("@IsActive", IsActive);                        
           
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

        public static bool DeleteUser(int UserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete from Users Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            int RowsAffected = -1;
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

        static public bool Login(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from Users where UserName = @UserName And Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    UserID = Convert.ToInt32(reader["UserID"]);
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
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

        static public void SaveLastAccountLogin(string UserName, string Password)
        {

            string filePath = "LastLogin.txt";
            try
            {              
                string dataToWrite = $"{UserName}#{Password}";                
                File.WriteAllText(filePath, dataToWrite);
                
            }
            catch (Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
        }

        static public bool GetlastAccountLogin(ref string UserName, ref string Password)
        {
            string filePath = "LastLogin.txt";

            try
            {               
                if (!File.Exists(filePath))
                {
                    return false;
                }
               
                string fileContent = File.ReadAllText(filePath).Trim();

                if (string.IsNullOrEmpty(fileContent))
                {
                    return false;
                }
               
                string[] data = fileContent.Split('#');
              
                if (data.Length == 2)
                {
                    UserName = data[0];
                    Password = data[1];
                    return true; 
                }
            }
            catch (Exception ex)
            {               
                Console.WriteLine("حدث خطأ أثناء قراءة البيانات: " + ex.Message);
            }
            
            return false;
        }

        static public void ClearlastLoginFile()
        {
            string filePath = "LastLogin.txt";

            try
            {                
                if (File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("حدث خطأ أثناء مسح محتوى الملف: " + ex.Message);
            }
        }
    }
}
