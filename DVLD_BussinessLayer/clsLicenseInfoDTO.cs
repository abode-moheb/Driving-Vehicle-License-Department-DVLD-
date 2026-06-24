using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsLicenseInfoDTO
    {

        public string ClassName { set; get; }
        public string FullName { set; get; }
        public string ImagePath { set; get; }
        public int LicenseID { set; get; }
        public string NationalNo { set; get; }
        public string Gendor { set; get; }
        public string IssueReason { set; get; }
        public string IsActive { set; get; }
        public string Notes { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime DateOfBirth { set; get; }
        public int DriverID { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string IsDetained { set; get; }


    }
}
