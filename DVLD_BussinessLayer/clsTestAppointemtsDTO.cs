using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsTestAppointemtsDTO
    {
        public int DrivingLicenseAppID { set; get; }
        public string LicenseClass { set; get; }
        public int PassedTests { set; get; }
        public int ApplicationID { set; get; }
        public string AppStatus { set; get; }
        public int AppFees { set; get; }
        public string AppType { set; get; }
        public string Applicant { set; get; }
        public DateTime AppDate { set; get; }
        public DateTime StatusDate { set; get; }
        public string CreatedBy { set; get; }

    }
}
