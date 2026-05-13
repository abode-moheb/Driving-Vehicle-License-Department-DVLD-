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
    public partial class AddOrEditPersonForm : Form
    {
        clsManagePeople PersonData;     
        public AddOrEditPersonForm()
        {
            InitializeComponent();
            PersonData = new clsManagePeople();
        }

        public AddOrEditPersonForm(int PersonID)
        {
            InitializeComponent();          
            lblHeader.Text = "Edit Person";
            FindAndShowPersonData(PersonID);           
        }

        // delegate returnType DelegateName(parameters);
        public delegate void DataSendBack(int PersonID);

        // declare an Event using delegate
        static public event DataSendBack DataBack;


        private void AddOrEditPersonForm_Load(object sender, EventArgs e)
        {
            ctrlPerson1.OnSavedClicked += Save;
            ctrlPerson1.OnCloseClicked += CloseForm;         
        }

        public void GetPersonData()
        {          
            PersonData.NationalNum = ctrlPerson1.NationalNum;
            PersonData.FirstName = ctrlPerson1.FirstName;
            PersonData.SecondName = ctrlPerson1.SecondeName;
            PersonData.ThirdName = ctrlPerson1.ThirdName;

            PersonData.LastName = ctrlPerson1.LastName;
            PersonData.DateOfBirth = ctrlPerson1.DateOfBirth;

            PersonData.Gendor = ctrlPerson1.Gendor;


            PersonData.Address = ctrlPerson1.Address;
            PersonData.Phone = ctrlPerson1.Phone;
            PersonData.Email = ctrlPerson1.Email;

            PersonData.NationalityCountryID = ctrlPerson1.NationalityCountryID;
            PersonData.ImagePath = ctrlPerson1.ImageSavedPath;
          
        }

        private void Save()
        {          
                GetPersonData();
                if (PersonData.Save())
                {
                    MessageBox.Show("Recorde Save Successfully","Done",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    lblPersonID.Text = PersonData.PersonID.ToString();

                    DataBack?.Invoke(PersonData.PersonID);
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Recorde Save failed","failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
        }
      
        void FindAndShowPersonData(int PersonID)
        {
            PersonData = clsManagePeople.FindPerson(PersonID);
            if (PersonData != null)
            {
                lblPersonID.Text = PersonData.PersonID.ToString();                
                ctrlPerson1.ShowPersonData(PersonData);
               
            }
            else
                MessageBox.Show("Person not found","failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void CloseForm()
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
