using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsLicenseInfo
    {
        static public clsLicenseInfoDTO GetLicenseDriverData(int LocalDrivingLicenseApplicationID)
        {
            clsLicenseInfoDTO licenseInfoDTO = new clsLicenseInfoDTO();

            DataTable dataTable = new DataTable();
            dataTable = clsLicenseInfoData.GetLicenseDriverData(LocalDrivingLicenseApplicationID);

            licenseInfoDTO.ClassName = dataTable.Rows[0]["ClassName"].ToString();
            licenseInfoDTO.FullName = dataTable.Rows[0]["FullName"].ToString();
            licenseInfoDTO.LicenseID = Convert.ToInt32(dataTable.Rows[0]["LicenseID"]);

            licenseInfoDTO.NationalNo = dataTable.Rows[0]["NationalNo"].ToString();
            licenseInfoDTO.Gendor = dataTable.Rows[0]["Gendor"].ToString();
            licenseInfoDTO.IssueReason = dataTable.Rows[0]["IssueReason"].ToString();

            licenseInfoDTO.IsActive = dataTable.Rows[0]["IsActive"].ToString();
            licenseInfoDTO.Notes = dataTable.Rows[0]["Notes"].ToString();
            licenseInfoDTO.IssueDate = Convert.ToDateTime(dataTable.Rows[0]["IssueDate"]);

            licenseInfoDTO.DateOfBirth = Convert.ToDateTime(dataTable.Rows[0]["DateOfBirth"]);
            licenseInfoDTO.DriverID = Convert.ToInt32(dataTable.Rows[0]["DriverID"]);
            licenseInfoDTO.ExpirationDate = Convert.ToDateTime(dataTable.Rows[0]["ExpirationDate"]);

            licenseInfoDTO.IsDetained = dataTable.Rows[0]["IsDetained"].ToString();
            licenseInfoDTO.ImagePath = dataTable.Rows[0]["ImagePath"].ToString();

            return licenseInfoDTO;
        }

    }
}
