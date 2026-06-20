using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BussinessLayer
{
    public class clsScheulingTest
    {
        enum enMode { enAddNew, enUpdate};
        enMode _Mode;

        public int TestAppointmentID { set; get; }
        public int TestTypeID { set; get; }
        public int LocalDrivingLicenseApp { set; get; }
        public DateTime AppointmentDate { set; get; }
        public int PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public int isLocked { set; get; }

        public clsScheulingTest()
        {
            _Mode = enMode.enAddNew;
        }

        clsScheulingTest(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApp, DateTime AppointmentDate, int PaidFees, int CreatedByUserID, int IsLocked)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApp = LocalDrivingLicenseApp;

            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.isLocked = IsLocked;

            _Mode = enMode.enUpdate;
        }

        static public DataTable GetSchedulingTestFormInfo(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsSchedulingTestData.GetSchedulingTestFormInfo(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        static public bool IsRetakeTest(int _LocalDrivingLicenseApp, int _TestTypeID)
        {
            return clsSchedulingTestData.IsRetakeTest(_LocalDrivingLicenseApp, _TestTypeID);
        }

        static public clsScheulingTest Find(int TestAppointmentID)
        {            
            int TestTypeID = 0;
            int LocalDrivingLicenseApp = 0;
            DateTime AppointmentDate = DateTime.Today;
            int PaidFees = 0;
            int CreatedByUserID = 0;
            int IsLocked = 0;

            if (clsSchedulingTestData.Find(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApp, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked))
            {
                return new clsScheulingTest(TestAppointmentID, TestTypeID, LocalDrivingLicenseApp, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
            }

            else
                return null;
        }

        bool _AddNewAppointmentAndGetID()
        {
            TestAppointmentID = clsSchedulingTestData.AddNewAppointmentAndGetID(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApp, this.AppointmentDate, this.PaidFees,
                this.CreatedByUserID, this.isLocked);

            return (TestAppointmentID != -1);
        }

        bool _UpdateTestAppointment()
        {
            return clsSchedulingTestData.UpdateTestAppointment(TestAppointmentID, AppointmentDate);
        }

        public bool Save()
        {
            switch (_Mode)  
            {
                case enMode.enAddNew:
                    if (_AddNewAppointmentAndGetID())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    return _UpdateTestAppointment();    
            }
            return false;
        }
    }
}
