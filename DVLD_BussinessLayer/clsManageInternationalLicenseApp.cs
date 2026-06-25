using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsManageInternationalLicenseApp
    {
        static public DataTable GetAllInternationalLicense()
        {
            return clsManageInternationalLicenseAppData.GetAllInternationalLicense();
        }
    }
}
