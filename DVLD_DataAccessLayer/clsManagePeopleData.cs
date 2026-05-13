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
    public class clsManagePeopleData
    {
        static public DataTable GetPeopleTables()
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select PersonID As [Person ID], NationalNo As [National No], FirstName As [First name] , SecondName As [Seconde name] , ThirdName 
                            As [Third name] , LastName As [last name], 
                            
                            case 
                            when Gendor = 0 then 'Male'
                            when Gendor = 1 then 'Female'
                            Else 'unknown'
                            END AS Gendor,
                            
                            DateOfBirth AS [Date of birth] , 
                            Countries.CountryName As [Nationality] ,Phone, Email
                            
                            from People inner join Countries on 
                            People.NationalityCountryID = Countries.CountryID
                            ";

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

        static public DataTable GetPeopleCountriesTable()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * from Countries";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dataTable.Load(reader);
            }
            catch(Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
            connection.Close();
            return dataTable;
        }

        static public DataTable GetPeopleTableWithCountryFilter(int SelectedCountryIndex)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select PersonID As [Person ID], NationalNo As [National No], FirstName As [First name] , SecondName As [Seconde name] , ThirdName 
                            As [Third name] , LastName As [last name], 
                            
                            case 
                            when Gendor = 0 then 'Male'
                            when Gendor = 1 then 'Female'
                            Else 'unknown'
                            END AS Gendor,
                            
                            DateOfBirth AS [Date of birth] , 
                            Countries.CountryName As [Nationality] ,Phone, Email
                            
                            from People inner join Countries on 
                            People.NationalityCountryID = Countries.CountryID
                            Where CountryID = @CountryIndex
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryIndex", SelectedCountryIndex);

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

        static public bool CheckIfNationalNumberExist(string NationalNum)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select PersonID from People where NationalNo = @NationalNum";
            

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNum", NationalNum);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = (int)command.ExecuteScalar();                
            }
            catch (Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
            connection.Close();
            return (RowsAffected > 0);
        }

        static public int SavePersonDataAndGetID(string FirstName, string SecondName, string ThirdName, string LastName, string NationalNum, DateTime DateOfBirth, int Gendor,
           string Phone, string Email, int CountryIndex, string Address, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO People 
                    (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                    VALUES 
                    (@NationalNum, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @CountryIndex, @ImagePath);
                    SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNum", NationalNum);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@CountryIndex", CountryIndex);

            if (!string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

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

        static public bool FindPerson(int PersonID,ref string NationalNum,ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName,
            ref DateTime DateOfBirth, ref int Gendor, ref int NationalityCountryID, ref string Email, ref string Phone, ref string Address, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from People Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NationalNum = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";

                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];

                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";

                    return true;
                }
            }
            catch(Exception ex)
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

        static public bool FindPersonUsingNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
           ref DateTime DateOfBirth, ref int Gendor, ref int NationalityCountryID, ref string Email, ref string Phone, ref string Address, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from People Where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";

                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];

                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";

                    return true;
                }
            }
            catch (Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
            connection.Close();
            return false;

        }

        static public bool UpdatePerson(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor,
           string Phone, string Email, int NationalityCountryID, string Address, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update People set NationalNo = @NationalNo,
                                               FirstName = @FirstName,
                                               SecondName = @SecondName,
                                               ThirdName = @ThirdName,
                                               LastName = @LastName,
                                               DateOfBirth = @DateOfBirth,
                                               Gendor = @Gendor,
                                               Phone = @Phone,
                                               Email = @Email,
                                               NationalityCountryID = @NationalityCountryID,
                                               Address = @Address,
                                               ImagePath = @ImagePath
                                               Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if (!string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

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

        static public bool DeletePerson(int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Delete from People where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        static public string GetCountryNameByCountryID(int CountryID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select CountryName from Countries where CountryID = @CountryID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            string CountryName = "";
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    CountryName = reader["CountryName"].ToString();
                }
            }
            catch (Exception ex)
            {
                string log = $"\n[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
            return CountryName;
        }

    }
}
