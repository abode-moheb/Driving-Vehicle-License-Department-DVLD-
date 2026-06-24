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
    public class clsIssueDriverLicenseFirstTimeData
    {

        static public int AddDriver(SqlConnection connection, SqlTransaction transaction, int ApplicantPersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            string query = @"IF NOT EXISTS (
                            SELECT DriverID 
                            FROM Drivers 
                            WHERE PersonID = @ApplicantPersonID
                        )
                        BEGIN
                            INSERT INTO Drivers 
                            (
                                PersonID, 
                                CreatedByUserID, 
                                CreatedDate
                            )
                            VALUES
                            (
                                @ApplicantPersonID, 
                                @CreatedByUserID, 
                                @CreatedDate
                            );
                        
                            SELECT SCOPE_IDENTITY() AS DriverID;
                        END
                        ELSE
                        BEGIN
                            SELECT DriverID 
                            FROM Drivers 
                            WHERE PersonID = @ApplicantPersonID;
                        END";


              SqlCommand command = new SqlCommand(query, connection, transaction);
              
              command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
              command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
              command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
              
              
              object Result = command.ExecuteScalar();
              
              return Convert.ToInt32(Result);
        }

        static public int AddLicense(SqlConnection connection, SqlTransaction transaction, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
                                    string Notes, int AppFees, bool IsActive, int IssueReason, int CreatedByUserID) {

            string query = @"INSERT INTO Licenses
                            (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                             Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)

                            VALUES
                            (@ApplicationID, @DriverID, @LicenseClass, @IssueDate,
                             @ExpirationDate, @Notes, @AppFees, @IsActive,
                             @IssueReason, @CreatedByUserID);

                            SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection, transaction);


            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes != "")
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            command.Parameters.AddWithValue("@AppFees", AppFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            return Convert.ToInt32(command.ExecuteScalar());

        }

        static public int IssueLicenseFirstTime(int ApplicationID, int ApplicantPersonID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
                                    string Notes, int AppFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {

                    int DriverID = AddDriver(connection, transaction, ApplicantPersonID, CreatedByUserID, DateTime.Now);

                    int LicenseID = AddLicense(connection, transaction, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, AppFees, IsActive, IssueReason, CreatedByUserID);

                    transaction.Commit();

                    return LicenseID;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }

            }

        }

        static public int GetValidityLengthForLicenseClass(int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select LicenseClasses.DefaultValidityLength from LicenseClasses where LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
           
            int ExpirationDate = -1;
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int value))
                {
                    ExpirationDate = value;
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
            return ExpirationDate;
        }
        
        static public int GetLicenseClassIDFromClassName(string LicenseClass)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select LicenseClasses.LicenseClassID from LicenseClasses where LicenseClasses.ClassName = @LicenseClass";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            int LicenseClassID = -1;
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int value))
                {
                    LicenseClassID = value;
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
            return LicenseClassID;
        }

        static public bool CheckIfPersonHadLicense(int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select 1 from Licenses where (Licenses.ApplicationID = @ApplicationID) And (Licenses.LicenseClass = @LicenseClassID) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
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

    }
}

