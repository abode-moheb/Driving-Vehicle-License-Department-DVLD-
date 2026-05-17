using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class GlobalSetting
    {       
        static public clsManageUsers CurrentUser { get; set; } = null;
     
        static public bool IsUserLoggedIn()
        {
            return CurrentUser != null;
        }
        
        static public void Logout()
        {
            CurrentUser = null;
        }

    }
}
