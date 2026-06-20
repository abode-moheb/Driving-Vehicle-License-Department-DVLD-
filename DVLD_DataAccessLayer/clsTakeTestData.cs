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
    public class clsTakeTestData
    {
        static public DataTable GetTestAppointmentData(int TestAppointmentID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName, 
                         TestTypes.TestTypeFees,
                             (SELECT        CASE WHEN COUNT(*) > 0 THEN COUNT(*) ELSE 0 END AS Expr1
                               FROM            Tests INNER JOIN
                                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                               WHERE        (TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AND (TestAppointments.TestTypeID = TestTypes.TestTypeID)) AS TrialCount, 
                         TestAppointments_1.AppointmentDate
                         FROM            LocalDrivingLicenseApplications INNER JOIN
                         LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                         People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                         TestAppointments AS TestAppointments_1 ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments_1.LocalDrivingLicenseApplicationID INNER JOIN
                         TestTypes ON TestAppointments_1.TestTypeID = TestTypes.TestTypeID
                         WHERE        (TestAppointmentID = @TestAppointmentID) AND (TestTypes.TestTypeID = @TestTypeID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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

        static public bool SaveNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                            VALUES        (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "")
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        static public bool LockTestAppointment(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"update TestAppointments set IsLocked = 1 where TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
