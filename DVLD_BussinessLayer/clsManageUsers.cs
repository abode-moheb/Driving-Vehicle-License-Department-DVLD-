using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsManageUsers
    {
        enum enMode { enAddNew, enUpdate };
        enMode _Mode;

        public clsManageUsers()
        {
            _Mode = enMode.enAddNew;
        }

        clsManageUsers(int UserID, int PersonID, string UserName, string Password , bool IsActive)
        {
            this.UserId = UserID;
            this.PersonId = PersonID;           
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            _Mode = enMode.enUpdate;
        }

        public int UserId { set; get; }
        public int PersonId { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        static public DataTable GetAllUsers()
        {
            return clsManageUsersData.GetAllUsers();
        }

        static public bool CheckIfPersonIsUser(int PersonID)
        {
            return clsManageUsersData.CheckIfPersonIsUser(PersonID);
        }

        bool UpdateUser()
        {
            return clsManageUsersData.UpdateUser(this.UserId, this.UserName, this.Password, this.IsActive);
        }

        bool _AddNewUserAndGetID()
        {
            this.UserId = clsManageUsersData.AddNewUserAndGetID(PersonId, UserName, Password, IsActive);

            return (UserId != -1);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewUserAndGetID())
                    {
                        return true;
                        _Mode = enMode.enUpdate;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    return UpdateUser();                   

            }
            return false;
        }

        static public clsManageUsers Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsManageUsersData.Find(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsManageUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            else
                return null;
        }

        static public bool DeleteUser(int UserID)
        {
            return clsManageUsersData.DeleteUser(UserID);
        }

        static public bool Login(string UserName,string Password, ref bool IsAccountActive)
        {
            int UserID = -1;
            int PersonID = -1;          

            if (clsManageUsersData.Login(UserName, Password, ref UserID, ref PersonID, ref IsAccountActive))
            {              
                if (IsAccountActive)
                {
                    GlobalSetting.CurrentUser = new clsManageUsers();

                    GlobalSetting.CurrentUser.UserId = UserID;              
                    GlobalSetting.CurrentUser.IsActive = IsAccountActive;                  
                }
                return true;
            }
            return false;
        }

        static public void SaveLastAccountLogin(string UserName, string Password)
        {
            clsManageUsersData.SaveLastAccountLogin(UserName, Password);
        }

        static public bool GetlastAccountLogin(ref string UserName, ref string Password)
        {
            return clsManageUsersData.GetlastAccountLogin(ref UserName, ref Password);
        }

        static public void ClearlastLoginFile()
        {
            clsManageUsersData.ClearlastLoginFile();
        }
    }
}
