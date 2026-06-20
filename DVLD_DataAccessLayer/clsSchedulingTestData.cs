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
    public class clsSchedulingTestData
    {
        static public DataTable GetSchedulingTestFormInfo(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                                       SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.FirstName + ' ' + People.SecondName + ' ' +
                  ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName, TestTypes.TestTypeFees,
                    (
                        SELECT
                            CASE
                                WHEN COUNT(*) > 0 THEN COUNT(*)
                                ELSE 0
                            END
                        FROM Tests
                        INNER JOIN TestAppointments
                            ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                        WHERE TestAppointments.LocalDrivingLicenseApplicationID =
                              LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                        AND TestAppointments.TestTypeID = TestTypes.TestTypeID
                    ) AS TrialCount
                
                FROM LocalDrivingLicenseApplications
                INNER JOIN LicenseClasses
                    ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                INNER JOIN Applications
                    ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                INNER JOIN People
                    ON Applications.ApplicantPersonID = People.PersonID
                CROSS JOIN TestTypes
                
                WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
                      @LocalDrivingLicenseApplicationID
                AND TestTypes.TestTypeID = @TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows) { 

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

        static public bool IsRetakeTest(int _LocalDrivingLicenseApp, int _TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        TestAppointments.TestTypeID AS TestType, TestAppointments.LocalDrivingLicenseApplicationID, Tests.TestResult
                         FROM            Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID INNER JOIN
                         TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID
						 where (TestAppointments.TestTypeID = @TestTypeID) And (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApp) And (Tests.TestResult = 0)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", _TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApp", _LocalDrivingLicenseApp);
           
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

        public static int AddNewAppointmentAndGetID(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApp, DateTime AppointmentDate, int PaidFees,
                int CreatedByUserID, int isLocked)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                            VALUES        (@TestTypeID , @LocalDrivingLicenseApplicationID , @AppointmentDate , @PaidFees , @CreatedByUserID , @isLocked )" +
                            "Select SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
           
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApp);

            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@isLocked", isLocked);

            int InsertedID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int id))
                {
                    InsertedID = id;
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
            return InsertedID;
        }

        static public bool Find(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApp, ref DateTime AppointmentDate, ref int PaidFees, ref int CreatedByUserID, ref int IsLocked)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from testAppointments where TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    LocalDrivingLicenseApp = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);

                    PaidFees = Convert.ToInt32(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsLocked = Convert.ToInt32(reader["IsLocked"]);
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

        static public bool UpdateTestAppointment(int TestAppointmentID, DateTime AppointmentDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "update TestAppointments set AppointmentDate = @AppointmentDate Where TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
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
