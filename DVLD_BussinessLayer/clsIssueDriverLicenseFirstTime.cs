using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsIssueDriverLicenseFirstTime
    {

        static public int GetLicenseClassIDFromLicenseClass(string LicenseClass)
        {
            return clsIssueDriverLicenseFirstTimeData.GetLicenseClassIDFromClassName(LicenseClass);
        }

        static public int IssueNewLicenseFirstTimeAndGetLicenseID(int ApplicationID, int PersonID, int LicenseClassID, int PaidFees, string Notes)
        {                    
            int ValidityLength = clsIssueDriverLicenseFirstTimeData.GetValidityLengthForLicenseClass(LicenseClassID);
            DateTime ExpirationDate = DateTime.Today.AddYears(ValidityLength);

            bool IsActive = true;

            int IssueReason = 1;
          

            return clsIssueDriverLicenseFirstTimeData.IssueLicenseFirstTime(ApplicationID, PersonID, LicenseClassID, DateTime.Today, ExpirationDate
                , Notes, PaidFees, IsActive, IssueReason, GlobalSetting.CurrentUser.UserId);
        }

        static public bool CheckIfPersonHadLicense(int ApplicationID, int LicenseClass)
        {
            return clsIssueDriverLicenseFirstTimeData.CheckIfPersonHadLicense(ApplicationID, LicenseClass);
        }

    }
}
