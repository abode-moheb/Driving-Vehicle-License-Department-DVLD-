using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsLicenseHistory
    {
        static public DataTable GetPersonLocalLicense(int PersonID)
        {
            return clsLicenseHistoryData.GetPersonLocalLicense(PersonID);
        }

        static public DataTable GetPersonInternationalLicense(int PersonID)
        {
            return clsLicenseHistoryData.GetPersonInternationalLicense(PersonID);
        }
    }
}
