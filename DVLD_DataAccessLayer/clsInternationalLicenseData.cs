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
    public class clsInternationalLicenseData
    {
        static public DataTable GetApplicationData(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        Applications.ApplicationID, Applications.ApplicationDate, Licenses.IssueDate, LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, Licenses.ExpirationDate
                         FROM            Applications INNER JOIN
                         Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
                         ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID INNER JOIN
                         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
						 Where (Licenses.LicenseID = @LicenseID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        static public int GetFeesForInternationalLicense()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select ApplicationTypes.ApplicationFees from ApplicationTypes where ApplicationTypes.ApplicationTypeID = 6";
            SqlCommand command = new SqlCommand(query, connection);

            int Fees = 0;
            try
            {
                connection.Open();
                Fees = Convert.ToInt32(command.ExecuteScalar());
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
            return Fees;
        }

        static public int GetPersonIDFromDriverID(int DriverID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select Drivers.PersonID from Drivers where DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            int PersonID = -1;
            try
            {
                connection.Open();
                PersonID = Convert.ToInt32(command.ExecuteScalar());
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
            return PersonID;
        }

        static public bool CheckIfInternationalLicesneIsExsist(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Select Case
                            When EXISTS (select 1 from InternationalLicenses where IssuedUsingLocalLicenseID = @LicenseID)
                            THEN 1
                            Else 0
                            END";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                return Convert.ToBoolean(command.ExecuteScalar());
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

        static public int AddNewApplicationforInternationalLicense(SqlConnection connection , SqlTransaction transaction, int PersonID, DateTime ApplicationDate, int ApplicationType, int ApplicationStatus, DateTime LastStatuDate, int PaidFees, int CreatedByUserID)
        {            
            string query = @"INSERT INTO Applications
                         (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                          VALUES        (@PersonID ,@ApplicationDate ,@ApplicationType ,@ApplicationStatus ,@LastStatuDate ,@PaidFees, @CreatedByUserID)" +
                         "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationType", ApplicationType);

            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatuDate", LastStatuDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            object Result = command.ExecuteScalar();
            return Convert.ToInt32(Result);

        }

        static public int IssueInternationalLicense(SqlConnection connection, SqlTransaction transaction, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
                int IsActive, int CreatedByUserID)
        {           
            string query = @"INSERT INTO InternationalLicenses
                         (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                         VALUES        (@ApplicationID ,@DriverID ,@IssuedUsingLocalLicenseID ,@IssueDate ,@ExpirationDate ,@IsActive ,@CreatedByUserID);" +
                         "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection, transaction);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            object Result = command.ExecuteScalar();
            return Convert.ToInt32(Result);
        }

        static public int Issue(ref int ApplicationID, int PersonID, int PaidFees , DateTime ApplicationDate, int ApplicationType, int ApplicationStatus, DateTime LastStatuDate, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
                int IsActive, int CreatedByUserID)
        {
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    ApplicationID = AddNewApplicationforInternationalLicense(connection, transaction, PersonID, ApplicationDate, ApplicationType, ApplicationStatus, LastStatuDate, PaidFees, CreatedByUserID);
                    if (ApplicationID == -1)
                    {
                        transaction.Rollback();
                        return -1;
                    }

                    int InternationalLicenseID = IssueInternationalLicense(connection, transaction, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,
                             IsActive, CreatedByUserID);
                    if (InternationalLicenseID == -1)
                    {
                        transaction.Rollback();
                        return -1;
                    }

                    transaction.Commit();
                    return InternationalLicenseID;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }

            }
        }


        // ShowInternationalLicneseForm 
        static public DataTable GetInternationalDriverInfo(int InternationalLicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        CONCAT (People.FirstName, ' ' , People.SecondName, ' ' , People.ThirdName, ' ' , People.LastName) As FullName, InternationalLicenses.InternationalLicenseID, InternationalLicenses.IssuedUsingLocalLicenseID, People.NationalNo, Case 
                            When People.Gendor = 0 Then 'Male'
                            When People.Gendor = 1 Then 'Female'
                            END As Gendor,
                         InternationalLicenses.IssueDate, InternationalLicenses.IsActive, People.DateOfBirth, InternationalLicenses.DriverID, InternationalLicenses.ExpirationDate, Applications.ApplicationID
                            FROM            People INNER JOIN
                         Applications ON People.PersonID = Applications.ApplicantPersonID INNER JOIN
                         InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID
						 where InternationalLicenses.InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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

    }
}
