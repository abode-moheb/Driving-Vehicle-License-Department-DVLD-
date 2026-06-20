using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsTestAppointments
    {      
        static void GetDrivingLicenseAppInfo(int LocalDrivingLicenseApplicationID, clsTestAppointemtsDTO testAppointemtsDTO)
        {
            DataTable dataTable = new DataTable();

            dataTable = clsTestAppointmentsData.GetDrivingLicenseAppInfo(LocalDrivingLicenseApplicationID);

            if (dataTable.Rows.Count == 0)
                return;
           
            testAppointemtsDTO.DrivingLicenseAppID = Convert.ToInt32(dataTable.Rows[0]["LocalDrivingLicenseApplicationID"]);
            testAppointemtsDTO.LicenseClass = dataTable.Rows[0]["ClassName"].ToString();
            testAppointemtsDTO.PassedTests = Convert.ToInt32(dataTable.Rows[0]["PassedTestCount"]);
           
        }

        static void GetAppBasicInfo(int LocalDrivingLicenseApplicationID, clsTestAppointemtsDTO testAppointemtsDTO)
        {
            DataTable dataTable = new DataTable();

            dataTable = clsTestAppointmentsData.GetAppBasicInfo(LocalDrivingLicenseApplicationID);

            if (dataTable.Rows.Count == 0)
                return;

            testAppointemtsDTO.ApplicationID = Convert.ToInt32(dataTable.Rows[0]["ApplicationID"]);
            testAppointemtsDTO.ApplicantPersonID = Convert.ToInt32(dataTable.Rows[0]["ApplicantPersonID"]);
            testAppointemtsDTO.AppStatus = dataTable.Rows[0]["ApplicationStatus"].ToString(); ;
            testAppointemtsDTO.AppFees = Convert.ToInt32(dataTable.Rows[0]["PaidFees"]);

            testAppointemtsDTO.AppType = dataTable.Rows[0]["ApplicationTypeTitle"].ToString();
            testAppointemtsDTO.Applicant = dataTable.Rows[0]["FullName"].ToString();
            testAppointemtsDTO.AppDate = Convert.ToDateTime(dataTable.Rows[0]["ApplicationDate"]);

            testAppointemtsDTO.StatusDate = Convert.ToDateTime(dataTable.Rows[0]["LastStatusDate"]);
            testAppointemtsDTO.CreatedBy = dataTable.Rows[0]["UserName"].ToString();
           
        }

        static public clsTestAppointemtsDTO LoadTestFormData(int LocalDrivingLicenseApplicationID)
        {

            clsTestAppointemtsDTO testAppointemtsDTO = new clsTestAppointemtsDTO();

            GetDrivingLicenseAppInfo(LocalDrivingLicenseApplicationID, testAppointemtsDTO);
            GetAppBasicInfo(LocalDrivingLicenseApplicationID, testAppointemtsDTO);

            return testAppointemtsDTO;
        }

        static public DataTable GetApplicationAppointments(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationAppointments(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        static public bool CheckIfHadActiveAppoientment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentsData.CheckIfHadActiveAppoientment(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        static public bool CheckIfTestPassed(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentsData.CheckIfTestPassed(LocalDrivingLicenseApplicationID, TestTypeID);
        }

    }
}
