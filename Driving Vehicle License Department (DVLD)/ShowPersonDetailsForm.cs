using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BussinessLayer;

namespace Driving_Vehicle_License_Department__DVLD_
{
    public partial class ShowPersonDetailsForm : Form
    {        
        public ShowPersonDetailsForm(int PersonID)
        {
            InitializeComponent();
            FindPersonData(PersonID);
        }

        private void ShowPersonDetailsForm_Load(object sender, EventArgs e)
        {
            ctrlShowPersonDetails1.CloseForm += CloseForm;
        }

        void ShowPersonData(clsManagePeople PersonData)
        {
            ctrlShowPersonDetails1.PersonID = PersonData.PersonID;

            ctrlShowPersonDetails1.NationalNum = PersonData.NationalNum;
            ctrlShowPersonDetails1.Name = PersonData.FirstName + " " + PersonData.SecondName + " " + PersonData.ThirdName + " " + PersonData.LastName;
            ctrlShowPersonDetails1.DateOfBirth = PersonData.DateOfBirth.ToShortDateString();

            ctrlShowPersonDetails1.Email = PersonData.Email;
            ctrlShowPersonDetails1.Phone = PersonData.Phone;
            ctrlShowPersonDetails1.Gendor = PersonData.Gendor;

            ctrlShowPersonDetails1.Address = PersonData.Address;
            ctrlShowPersonDetails1.ImageSavedPath = PersonData.ImagePath;
            ctrlShowPersonDetails1.NationalityCountry = clsManagePeople.GetCountryNameByCountryID(PersonData.NationalityCountryID);

        }

        void FindPersonData(int PersonID)
        {
            clsManagePeople PersonData = clsManagePeople.FindPerson(PersonID);
            if (PersonData != null)
            {               
                ShowPersonData(PersonData);
            }
            else
                MessageBox.Show("Person not found");
        }

        void CloseForm() {

            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
