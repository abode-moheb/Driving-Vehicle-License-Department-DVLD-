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
    public partial class LocalDrivingLicenseApplicationForm : Form
    {
        enum enStatus { enNew = 1, enCancelled , enComplete}
        enStatus Status = enStatus.enNew;

        enum enMode { enAddnew, enUpdate };
        enMode _FormMode = enMode.enAddnew;

        clsManagePeople Person;
        clsLocalDrivingLicenseApplication LocalApplication;
        public LocalDrivingLicenseApplicationForm()
        {
            _FormMode = enMode.enAddnew;
            InitializeComponent();
            LocalApplication = new clsLocalDrivingLicenseApplication();            
        }

        public LocalDrivingLicenseApplicationForm(int LocalDrivingLicenseAppID)
        {
            _FormMode = enMode.enUpdate;
            InitializeComponent();
            lblHeader.Text = "Update Local Driving License Application";
            LocalApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseAppID);

            ShowLocalDrivingLicenseAppData();
        }
       
        void ShowLocalDrivingLicenseAppData()
        {           
            FindUsePersonID(LocalApplication.ApplicationPersonID);
            lblApplicationID.Text = LocalApplication.ApplicationID.ToString();
            lblApplicationDate.Text = LocalApplication.ApplicationDate.ToShortDateString();

            GetComboBoxLicenseClass();
            cbLicenseClass.SelectedIndex = (LocalApplication.LicenseClassID - 1);
            lblApplicationFees.Text = LocalApplication.PaidFees.ToString();

            lblCreatedBy.Text = clsManageUsers.GetUserNameByUserId(LocalApplication.CreatedByUserID);
        }

        private void LocalDrivingLicenseApplicationForm_Load(object sender, EventArgs e)
        {
            ctrlFindWithFilter1.FindUseNationalNo += FindUseNatoinalNo;
            ctrlFindWithFilter1.FindUsePersonID += FindUsePersonID;

            AddOrEditPersonForm.DataBack += FindUsePersonID;


            if (_FormMode == enMode.enAddnew)
            {
                FillingApplicationInfoForm();               
            }
            else
            {
                ctrlFindWithFilter1.Enabled = false;
                ctrlShowPersonDetails1.Enabled = false;
            }
        }

        void FillingApplicationInfoForm()
        {
            lblApplicationDate.Text = DateTime.Today.ToShortDateString();
            lblApplicationFees.Text = clsLocalDrivingLicenseApplication.GetPaidFeesForLocalDrivingLicense().ToString();
            lblCreatedBy.Text = GlobalSetting.CurrentUser.UserName;

            GetComboBoxLicenseClass();
            cbLicenseClass.SelectedIndex = 2;
        }

        void GetComboBoxLicenseClass()
        {
            DataTable datatable = new DataTable();

            datatable = clsLocalDrivingLicenseApplication.GetLicenseClassTable();

            cbLicenseClass.DataSource = datatable;

            cbLicenseClass.ValueMember = datatable.Columns["LicenseClassID"].ColumnName;
            cbLicenseClass.DisplayMember = datatable.Columns["ClassName"].ColumnName;
        }

        void FindUseNatoinalNo(string NationalNo)
        {
            Person = clsManagePeople.FindPerson(NationalNo);
            if (Person != null)
            {
                ctrlShowPersonDetails1.ShowPersonData(Person);
                btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("cant find Person with this national number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void FindUsePersonID(int PersonID)
        {
         
            ctrlFindWithFilter1.txtFillter = PersonID.ToString();
            ctrlFindWithFilter1.ComboBox = 1;

            Person = clsManagePeople.FindPerson(PersonID);
            if (Person != null)
            {
                ctrlShowPersonDetails1.ShowPersonData(Person);
                btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("cant find Person with this Person Id", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (Person != null)
            {
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("You should choose Person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        bool CheckIfApplicationIsExist()
        {
            int LicsenseClassIndex = (int)cbLicenseClass.SelectedIndex + 1;

            int ApplicationID = -1;

            if (clsLocalDrivingLicenseApplication.CheckIfApplicationIsExist(Person.PersonID, LicsenseClassIndex, ref ApplicationID))
            {
                MessageBox.Show("Choose another license class , the selected person is already have an active application for the selected class with id = " +
                    ApplicationID.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; ;
            }

            return false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Person == null)
                return;

            if (CheckIfApplicationIsExist())
                return;

            if (_FormMode == enMode.enAddnew)
            {
                LocalApplication.ApplicationPersonID = Person.PersonID;
                LocalApplication.ApplicationDate = DateTime.Now;
                LocalApplication.CreatedByUserID = GlobalSetting.CurrentUser.UserId;

                LocalApplication.ApplicationStatus = (int)Status;
                LocalApplication.LastStatusDate = DateTime.Now;
                LocalApplication.PaidFees = clsLocalDrivingLicenseApplication.GetPaidFeesForLocalDrivingLicense();
                LocalApplication.LicenseClassID = (int)cbLicenseClass.SelectedIndex + 1;
            }

            else
            {
                LocalApplication.LicenseClassID = (int)cbLicenseClass.SelectedIndex + 1;
            }

            if (LocalApplication.Save())
            {
                lblApplicationID.Text = LocalApplication.ApplicationID.ToString();
                lblHeader.Text = "Update Local Driving License Application";
                MessageBox.Show("Saved Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                               
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
