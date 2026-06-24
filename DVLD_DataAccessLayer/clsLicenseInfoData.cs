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
    public class clsLicenseInfoData
    {

        static public DataTable GetLicenseDriverData(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DECLARE @LicenseID INT;
                            select @LicenseID = Licenses.LicenseID from Licenses where Licenses.ApplicationID =
                            (select LocalDrivingLicenseApplications.ApplicationID from LocalDrivingLicenseApplications where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                            
                            
                            SELECT        LicenseClasses.ClassName, CONCAT (People.FirstName , ' ' , People.SecondName , ' ' , People.ThirdName , ' ' , People.LastName) AS FullName, People.ImagePath , Licenses.LicenseID, People.NationalNo, Case 
                            When People.Gendor = 0 Then 'Male'
                            When People.Gendor = 1 Then 'Female'
                            Else 'Unkown'
                            End As Gendor,
                            Case 
                            when Licenses.IssueReason = 1 Then 'FirstTime'
                            when Licenses.IssueReason = 2 Then 'ReNew'
                            Else 'Unkown'
                            End As IssueReason,
                            Case
                            When Licenses.IsActive = 0 Then 'No'
                            When Licenses.IsActive = 1 Then 'Yes'
                            Else 'Unkown'
                            End As IsActive,
                            Licenses.Notes, Licenses.IssueDate, People.DateOfBirth, Drivers.DriverID, Licenses.ExpirationDate,
                            Case
                            When EXISTS (SELECT 1 FROM DetainedLicenses WHERE LicenseID = 25)
                            Then 'Yes'
                            Else 'No'
                            END AS IsDetained
                            FROM            Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                                                     People ON Drivers.PersonID = People.PersonID INNER JOIN 
                            						 LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            WHERE        (Licenses.LicenseID = @LicenseID)";
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
            connection.Close();
            return dataTable;
        }

    }
}
