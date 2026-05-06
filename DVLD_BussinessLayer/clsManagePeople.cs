
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;
using System.IO;

namespace DVLD_BussinessLayer
{
    public class clsManagePeople
    {
        enum enMode  {enAddNew,enUpdate};
        enMode Mode = enMode.enAddNew;

        public int PersonID { set; get; }
        public string NationalNum { set; get; }

        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }

        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string Email { set; get; }

        public int Gendor { set; get; }
        public int NationalityCountryID { set; get; }

        public string Phone { set; get; }
        public string Address { set; get; }
        public string ImagePath { set; get; }


        public clsManagePeople()
        {
            Mode = enMode.enAddNew;
        }

        public clsManagePeople(int PersonID, string NationalNum,string FirstName,string SecondName,string ThirdName,string LastName,DateTime DateOfBirth, int Gendor , string Email, string Phone
            ,string Address, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNum = NationalNum;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.enUpdate;
        }

        static public DataTable GetPeopleTable()
        {
            return clsManagePeopleData.GetPeopleTables();
        }      

        static public DataTable GetPeopleCountriesTable()
        {
            return clsManagePeopleData.GetPeopleCountriesTable();
        }

        static public DataTable GetPeopleTableWithCountryFilter(int SelectedCountryIndex)
        {
            return clsManagePeopleData.GetPeopleTableWithCountryFilter(SelectedCountryIndex);
        }

        static public bool CheckIfNationalNumberExist(string NationalNum){

            return clsManagePeopleData.CheckIfNationalNumberExist(NationalNum);

        }

        static public clsManagePeople FindPerson(int PersonID)
        {
            string NationalNum = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Today;
            int Gendor = -1;
            int NationalityCountryID = -1;
            string Email = "";
            string Phone = "";
            string Address = "";
            string ImagePath = "";

            if (clsManagePeopleData.FindPerson(PersonID, ref NationalNum, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref NationalityCountryID, ref Email, ref Phone, ref Address, ref ImagePath))
                return new clsManagePeople(PersonID, NationalNum, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Email, Phone
            , Address, NationalityCountryID, ImagePath);

            else
                return null;
        }

        bool _SavePersonDataAndGetID()
        {
            this.PersonID = clsManagePeopleData.SavePersonDataAndGetID(FirstName, SecondName, ThirdName, LastName, NationalNum, DateOfBirth, Gendor,
            Phone, Email, NationalityCountryID, Address, ImagePath);

            return (this.PersonID != -1);
        }

        bool _UpdatePerson()
        {
            return clsManagePeopleData.UpdatePerson(PersonID,NationalNum, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor,
            Phone, Email, NationalityCountryID, Address, ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.enAddNew:
                    if (_SavePersonDataAndGetID())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;
                case enMode.enUpdate:
                    return _UpdatePerson();                    
            }
            return false;
        }

        static public bool DeletePerson(int PersonID)
        {
            return clsManagePeopleData.DeletePerson(PersonID);
        }

        static public string GetCountryNameByCountryID(int CountryID)
        {
            return clsManagePeopleData.GetCountryNameByCountryID(CountryID);
        }

        static public string GetImagePath(string SourcePhoto)
        {
            string folderPath = @"C:\DVLD_Person_Images";


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            string fileExtension = Path.GetExtension(SourcePhoto);
            string newFileName = Guid.NewGuid().ToString() + fileExtension;

            string destinationPath = Path.Combine(folderPath, newFileName);


            File.Copy(SourcePhoto, destinationPath, true);

            return destinationPath;
        }

        static public void DeleteOldImage(string ImagePath)
        {
            try
            {
                if (File.Exists(ImagePath))
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    File.Delete(ImagePath);
                }
            }
            catch (Exception ex)
            {
                string log = $"[{DateTime.Now}] {ex}\n";
                File.AppendAllText("log.txt", log);
            }
        }
    }
}
