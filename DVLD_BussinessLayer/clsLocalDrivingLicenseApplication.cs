using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsLocalDrivingLicenseApplication
    {
        enum enMode { enAddnew,enUpdate};
        enMode _Mode = enMode.enAddnew;
        
        public int LocalDrivingLicenseAppID { set; get; }
        public int ApplicationID { set; get;}
        public int ApplicationPersonID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationType { get; } = 1;
        public int ApplicationStatus { set; get; } 
        public DateTime LastStatusDate { set; get; }
        public int PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public int LicenseClassID { set; get; }

        public clsLocalDrivingLicenseApplication()
        {

        }

        clsLocalDrivingLicenseApplication(int LocalDrivingLicenseAppID, int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate, int ApplicationType, int ApplicationStatus
            ,DateTime LastStatusDate, int PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            this.LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationType = ApplicationType;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;

            _Mode = enMode.enUpdate;
        }

        static public DataTable GetLicenseClassTable()
        {
            return clsLocalDrivingLicenseApplicationData.GetLicenseClassTable();
        }

        bool _AddNewApplicationAndGetID()
        {
            this.ApplicationID = clsLocalDrivingLicenseApplicationData._AddNewApplicationAndGetID(this.ApplicationPersonID, this.ApplicationDate,
                this.ApplicationType, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return ApplicationID != -1;
        }

        bool _AddLocalDrivingLicenseApplications()
        {
            int LocalDrivingLicenseApplicationsID = clsLocalDrivingLicenseApplicationData._AddLocalDrivingLicenseApplications(this.ApplicationID,this.LicenseClassID);

            return LocalDrivingLicenseApplicationsID != -1;
        }

        static public int GetPaidFeesForLocalDrivingLicense()
        {
            return clsLocalDrivingLicenseApplicationData.GetPaidFeesForLocalDrivingLicense();
        }

        bool _UpdateLocalApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalApplication(this.LocalDrivingLicenseAppID, this.LicenseClassID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddnew:
                    if (_AddNewApplicationAndGetID())
                    {
                        if (_AddLocalDrivingLicenseApplications()){
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                    }
                    return false;
                case enMode.enUpdate:
                    return _UpdateLocalApplication();                    
            }
            return false;
        }

        static public bool CheckIfApplicationIsExist(int PersonID, int LicsenseClassIndex, ref int ApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.CheckIfApplicationIsExist(PersonID,LicsenseClassIndex, ref ApplicationID);
        }

        static public clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseAppID)
        {
            int ApplicationID = -1;
            int ApplicationPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationType = -1;
            int ApplicationStatus = -1;
            DateTime LastStatusDate = DateTime.Now;
            int PaidFees = -1;
            int CreatedByUserID = -1;
            int LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationData.Find(LocalDrivingLicenseAppID, ref ApplicationID, ref ApplicationPersonID, ref ApplicationDate, ref ApplicationType,
                ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID, ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseAppID, ApplicationID, ApplicationPersonID, ApplicationDate, ApplicationType,
                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        static public bool Delete(int localDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            ApplicationID = clsLocalDrivingLicenseApplicationData.GetApplicationIDFromLocalDrivingLicenseApp(localDrivingLicenseApplicationID);

            return clsLocalDrivingLicenseApplicationData.DeleteRecords(localDrivingLicenseApplicationID, ApplicationID);
        }

        // Manage Local dirving Application Form

        static public DataTable GetLocalDrivingLicenseApplicationTable()
        {
            return clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationTable();
        }
    }
}
