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

        clsManagePeople Person;
        clsLocalDrivingLicenseApplication LocalApplication;
        public LocalDrivingLicenseApplicationForm()
        {
            InitializeComponent();
            LocalApplication = new clsLocalDrivingLicenseApplication();
        }
       
        private void LocalDrivingLicenseApplicationForm_Load(object sender, EventArgs e)
        {
            ctrlFindWithFilter1.FindUseNationalNo += FindUseNatoinalNo;
            ctrlFindWithFilter1.FindUsePersonID += FindUsePersonID;

            AddOrEditPersonForm.DataBack += FindUsePersonID;

            FillingApplicationInfoForm();            
        }

        void FillingApplicationInfoForm()
        {
            lblApplicationDate.Text = DateTime.Today.ToShortDateString();
            lblApplicationFees.Text = clsLocalDrivingLicenseApplication.GetPaidFeesForLocalDrivingLicense().ToString();
            lblCreatedBy.Text = GlobalSetting.CurrentUser.UserName;

            DataTable datatable = new DataTable();

            datatable = clsLocalDrivingLicenseApplication.GetLicenseClassTable();

            cbLicenseClass.DataSource = datatable;

            cbLicenseClass.ValueMember = datatable.Columns["LicenseClassID"].ColumnName;
            cbLicenseClass.DisplayMember = datatable.Columns["ClassName"].ColumnName;

            cbLicenseClass.SelectedIndex = 2;
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
          
           
            LocalApplication.ApplicationPersonID = Person.PersonID;
            LocalApplication.ApplicationDate = DateTime.Now;
            LocalApplication.CreatedByUserID = GlobalSetting.CurrentUser.UserId;

            LocalApplication.ApplicationStatus = (int)Status;
            LocalApplication.LastStatusDate = DateTime.Now;
            LocalApplication.PaidFees = clsLocalDrivingLicenseApplication.GetPaidFeesForLocalDrivingLicense();

            LocalApplication.LicenseClassID = (int)cbLicenseClass.SelectedIndex + 1;



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
