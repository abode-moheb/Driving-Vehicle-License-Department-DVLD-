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
    public partial class AddNewInternationalLicenseForm : Form
    {
        clsLicenseInfoDTO licenseInfoDTO;
        int PaidFees = 0;
        int InternationalLicenseID;
        public AddNewInternationalLicenseForm()
        {
            InitializeComponent();
        }
        private void AddNewInternationalLicenseForm_Load(object sender, EventArgs e)
        {
            btnIssue.Enabled = false;
            linkLabelShowLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = false;
        }

        private void BtnSearchLicense_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtLicenseID.Text, out int LicenseID))
            {
                if (clsLicenseInfo.CheckIfLocalLicenseExist(LicenseID))
                {

                    licenseInfoDTO = clsLicenseInfo.GetLicenseDriverDataUsingLicenseID(LicenseID);                   
                    ctrlDriverLicseneInfo1.ShowData(licenseInfoDTO);
                    
                    LoadApplicationInfo(LicenseID);
                    linkLabelShowLicenseHistory.Enabled = true;
                    btnIssue.Enabled = true;
                }
                else
                    MessageBox.Show("License with license id = " + LicenseID.ToString() + " is not exsist", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Enter Valid Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void LoadApplicationInfo(int LicenseID)
        {
            lblApplicationID.Text = "[???]";
            lblInternationalLicenseID.Text = "[???]";
            lblApplicationDate.Text = DateTime.Today.ToShortDateString();
            lblIssueDate.Text = DateTime.Today.ToShortDateString();

            lblLocalLicenseID.Text = LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Today.AddYears(5).ToShortDateString();
            lblCreatedBy.Text = GlobalSetting.CurrentUser.UserName;
            PaidFees = clsInternationalLicense.GetFeesForInternationalLicense();
            lblFees.Text = PaidFees.ToString();

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (licenseInfoDTO.NationalNo != "")
            {
                Form ShowLicenseHistory = new LicenseHistoryForm(licenseInfoDTO.NationalNo);
                ShowLicenseHistory.Show();
            }
            else
            {
                MessageBox.Show("Enter License ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {
            if (!clsInternationalLicense.CheckIfInternationalLicesneIsExsist(licenseInfoDTO.LicenseID))
            {
                clsInternationalLicense InternationalLicense = new clsInternationalLicense();               
                InternationalLicense.DriverID = licenseInfoDTO.DriverID;
                InternationalLicense.IssuedUsingLocalLicenseID = licenseInfoDTO.LicenseID;
                InternationalLicense.IssueDate = DateTime.Today;
                InternationalLicense.ExpirationDate = (DateTime.Today.AddYears(5));
                InternationalLicense.IsActive = 1;
                InternationalLicense.CreatedByUserID = GlobalSetting.CurrentUser.UserId;
                // Data for ApplicationTable
                InternationalLicense.PersonID = clsInternationalLicense.GetPersonIDFromDriverID(InternationalLicense.DriverID);
                InternationalLicense.PaidFees = PaidFees;

                if (InternationalLicense.Issue())
                {
                    if (licenseInfoDTO.IsActive == "Yes" && licenseInfoDTO.ExpirationDate >= DateTime.Today)
                    {
                        InternationalLicenseID = InternationalLicense.InternationalLicenseID;
                        MessageBox.Show("International License Issued Successfully with License Id = " + InternationalLicenseID, "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        lblInternationalLicenseID.Text = InternationalLicenseID.ToString();
                        lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                        linkLabelShowLicenseInfo.Enabled = true;
                    }
                    else
                        MessageBox.Show("License is not active or ExpirationDate End", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    MessageBox.Show("Failed To Issue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("License is already International", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form ShowLicenseInfo = new ShowInternationalDriverInfoForm(InternationalLicenseID);
            ShowLicenseInfo.Show();
        }
    }
}
