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
    public class clsLocalDrivingLicenseApplicationData
    {
        static public DataTable GetLicenseClassTable()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select LicenseClassID, ClassName  from LicenseClasses";

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

            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        static public int _AddNewApplicationAndGetID(int ApplicationPersonID, DateTime ApplicationDate,
                int ApplicationType, int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"insert into Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate,
                            PaidFees, CreatedByUserID) 

                            VALUES(@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate,
                            @PaidFees, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);            
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationType);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int InsertedID = -1;
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if(int.TryParse(Result.ToString(), out int id))
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

        static public int _AddLocalDrivingLicenseApplications(int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"insert into LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) VALUES (@ApplicationID, @LicenseClassID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            
            int InsertedID = -1;
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if (int.TryParse(Result.ToString(), out int id))
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

        static public int GetPaidFeesForLocalDrivingLicense()
        {           
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select ApplicationFees from ApplicationTypes where ApplicationTypeID = 1";                            

            SqlCommand command = new SqlCommand(query, connection);
          
            int FaidFees = -1;
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if (Result != null && Result != DBNull.Value)
                {
                    FaidFees = Convert.ToInt32(Result);
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
            return FaidFees;
        }

        static public bool CheckIfApplicationIsExist(int PersonID, int LicsenseClassIndex, ref int ApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT        Applications.ApplicationID
                            FROM            Applications INNER JOIN
                                                     LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE        (Applications.ApplicantPersonID = @PersonID) AND (LocalDrivingLicenseApplications.LicenseClassID = @LicsenseClassIndex)
							AND (ApplicationStatus != 2)";
                            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicsenseClassIndex", LicsenseClassIndex);
            
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();
                if (Result != null && Result != DBNull.Value)
                {
                    ApplicationID = Convert.ToInt32(Result);
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

        // Manage Local dirving Application Form

        static public DataTable GetLocalDrivingLicenseApplicationTable()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT        LocalDrivingLicenseApplications_View.*
                                FROM LocalDrivingLicenseApplications_View";

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

            finally
            {
                connection.Close();
            }
            return dataTable;
        }

    }
}
