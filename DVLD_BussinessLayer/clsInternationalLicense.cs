using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { set; get;}
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }       
        public DateTime ExpirationDate { set; get; }
        public int IsActive { set; get; }
        public int CreatedByUserID { set; get; }

        // for ApplicationTable
        public int PersonID { set; get; }
        public int PaidFees { set; get; }               

        static public int GetFeesForInternationalLicense()
        {
            return clsInternationalLicenseData.GetFeesForInternationalLicense();
        }

        static public int GetPersonIDFromDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetPersonIDFromDriverID(DriverID);
        }

        static public bool CheckIfInternationalLicesneIsExsist(int LicenseID)
        {
            return clsInternationalLicenseData.CheckIfInternationalLicesneIsExsist(LicenseID);
        }

        public bool Issue()
        {
            DateTime ApplicationDate = DateTime.Today;
            int ApplicationType = 6;
            int ApplicationStatus = 3;
            DateTime LastStatuDate = DateTime.Today;
            int AppID = 0;
            InternationalLicenseID = clsInternationalLicenseData.Issue(ref AppID, this.PersonID,this.PaidFees, ApplicationDate, ApplicationType, ApplicationStatus, LastStatuDate, 
                this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate,
                this.IsActive, this.CreatedByUserID);

            if (InternationalLicenseID != -1)
                this.ApplicationID = AppID;

            return InternationalLicenseID != -1;
        }

        // ShowInternationalLicneseForm 
        static public DataTable GetInternationalDriverInfo(int InternationalLicenseID)
        {
            return clsInternationalLicenseData.GetInternationalDriverInfo(InternationalLicenseID);
        }
    }
}
