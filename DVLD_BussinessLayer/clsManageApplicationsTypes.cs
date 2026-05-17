using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsManageApplicationsTypes
    {

        clsManageApplicationsTypes(int ApplicationID, string ApplicationTitle, int ApplicationFees)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationTitle = ApplicationTitle;
            this.ApplicationFees = ApplicationFees;
        }

        public int ApplicationID { set; get; }       
        public string ApplicationTitle { set; get; }
        public int ApplicationFees { set; get; }

        static public DataTable GetApplicationsTypesTable()
        {
            return clsManageApplicationsTypesData.GetApplicationsTypesTable();
        }

        static public clsManageApplicationsTypes FindApplication(int ApplicationID)
        {
            string ApplicationTitle = "";
            int ApplicationFees = 0;

            if (clsManageApplicationsTypesData.FindApplication(ApplicationID, ref ApplicationTitle, ref ApplicationFees))
            {
                return new clsManageApplicationsTypes(ApplicationID, ApplicationTitle, ApplicationFees);
            }
            else
                return null;
        }

        bool UpdateApplicationType()
        {
            return clsManageApplicationsTypesData.UpdateApplicationType(this.ApplicationID, this.ApplicationTitle, this.ApplicationFees);
        }

        public bool Save()
        {
            return UpdateApplicationType();
        }

    }
}
