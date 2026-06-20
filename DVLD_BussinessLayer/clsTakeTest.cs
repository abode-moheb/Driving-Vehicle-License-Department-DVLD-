using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsTakeTest
    {
        static public DataTable GetTestAppointmentData(int TestAppointmentID, int TestTypeID)
        {
            return clsTakeTestData.GetTestAppointmentData(TestAppointmentID, TestTypeID);
        }

        static public bool SaveNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            return clsTakeTestData.SaveNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        static public bool LockTestAppointment(int TestAppointmentID)
        {
            return clsTakeTestData.LockTestAppointment(TestAppointmentID);
        }

    }
}
