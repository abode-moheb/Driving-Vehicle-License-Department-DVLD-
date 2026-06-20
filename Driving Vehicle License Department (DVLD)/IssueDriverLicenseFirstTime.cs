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
    public partial class IssueDriverLicenseFirstTime : Form
    {
       
        public IssueDriverLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            LoadTestFormData(LocalDrivingLicenseApplicationID);
        }

        private void IssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {

        }

        void LoadTestFormData(int _LocalDrivingLicenseApplicationID)
        {

            clsTestAppointemtsDTO TestAppointemtsDTO = clsTestAppointments.LoadTestFormData(_LocalDrivingLicenseApplicationID);
            ctrlDrivingLicenseApplicationInfo1.ShowData(TestAppointemtsDTO);

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int ApplicationID = ctrlDrivingLicenseApplicationInfo1.ApplicationID;           
            int PaidFees = ctrlDrivingLicenseApplicationInfo1.AppFees;
            int PersonID = ctrlDrivingLicenseApplicationInfo1.ApplicantPersonID;
            int LicenseClassID = clsIssueDriverLicenseFirstTime.GetLicenseClassIDFromLicenseClass(ctrlDrivingLicenseApplicationInfo1.LicenseClass);

            if (clsIssueDriverLicenseFirstTime.CheckIfPersonHadLicense(ApplicationID, LicenseClassID))
            {
                MessageBox.Show("The person already have License", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int InsertedLicenseID = clsIssueDriverLicenseFirstTime.IssueNewLicenseFirstTimeAndGetLicenseID(ApplicationID, PersonID, LicenseClassID, PaidFees, txtNotes.Text);
                if (InsertedLicenseID != -1)
                {
                    MessageBox.Show("License Issued Successfully with license ID = " + InsertedLicenseID, "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("License Issued Failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
