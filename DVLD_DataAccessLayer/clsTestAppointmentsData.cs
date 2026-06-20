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
    public class clsTestAppointmentsData
    {

        static public DataTable GetDrivingLicenseAppInfo(int ID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName,
                                 (
                                    SELECT COUNT(*)
                            
                                    FROM dbo.Tests
                            
                                    INNER JOIN dbo.TestAppointments
                                        ON dbo.Tests.TestAppointmentID =
                                           dbo.TestAppointments.TestAppointmentID
                            
                                    WHERE
                                        dbo.TestAppointments.LocalDrivingLicenseApplicationID =
                                        dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                            
                                        AND dbo.Tests.TestResult = 1
                            
                                ) AS PassedTestCount
                            
                            FROM            LocalDrivingLicenseApplications INNER JOIN
                                                     LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                            where LocalDrivingLicenseApplicationID = @ID
                            
                            ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

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

        static public DataTable GetAppBasicInfo(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        Applications.ApplicationID, ApplicantPersonID, People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName, 
                         CASE WHEN Applications.ApplicationStatus = 1 THEN 'New' WHEN Applications.ApplicationStatus = 2 THEN 'Canceled' WHEN Applications.ApplicationStatus = 3 THEN 'Complete' ELSE 'Unkown' END AS ApplicationStatus, 
                         Applications.PaidFees, ApplicationTypes.ApplicationTypeTitle, Applications.ApplicationDate, Applications.LastStatusDate, Users.UserName
                         FROM            Applications INNER JOIN
                         ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID INNER JOIN
                         People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                         Users ON Applications.CreatedByUserID = Users.UserID INNER JOIN
                         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
						  where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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

        static public DataTable GetApplicationAppointments(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select TestAppointmentID,AppointmentDate,PaidFees,IsLocked from TestAppointments
                            where TestTypeID = @TestTypeID And LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        static public bool CheckIfHadActiveAppoientment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from TestAppointments where (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) And (IsLocked = 0) And (TestTypeID = @TestTypeID)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
           
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    return true;
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

        static public bool CheckIfTestPassed(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"IF EXISTS
                            (
                                SELECT 1
                                FROM Tests
                                WHERE TestResult = 1
                                AND TestAppointmentID IN
                                (
                                    SELECT TestAppointmentID
                                    FROM TestAppointments
                                    WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                    AND TestTypeID = @TestTypeID
                                )
                            )
                                SELECT 1
                            ELSE
                                SELECT 0";
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            bool PassedBefore = false;
            try
            {
                connection.Open();
                
                object result = command.ExecuteScalar();
                PassedBefore = ((int)result == 1);
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
            return PassedBefore;
        }

    }
}
