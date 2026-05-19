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
        
        public int ApplicationID { set; get;}
        public int ApplicationPersonID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationType { get; } = 1;
        public int ApplicationStatus { set; get; } 
        public DateTime LastStatusDate { set; get; }
        public int PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public int LicenseClassID { set; get; }

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
                    //return _UpdateLocalApplication();
                    return false;
            }
            return false;
        }
        static public bool CheckIfApplicationIsExist(int PersonID, int LicsenseClassIndex, ref int ApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.CheckIfApplicationIsExist(PersonID,LicsenseClassIndex, ref ApplicationID);
        }
    }
}
