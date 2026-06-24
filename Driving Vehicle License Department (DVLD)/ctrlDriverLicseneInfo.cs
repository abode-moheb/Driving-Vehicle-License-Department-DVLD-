using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BussinessLayer;

namespace Driving_Vehicle_License_Department__DVLD_
{
    public partial class ctrlDriverLicseneInfo : UserControl
    {
        public ctrlDriverLicseneInfo()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void ShowData(clsLicenseInfoDTO licenseInfoDTO)
        {
            lblLicenseClassName.Text = licenseInfoDTO.ClassName;
            lblName.Text = licenseInfoDTO.FullName;
            lblLicenseID.Text = licenseInfoDTO.LicenseID.ToString();

            lblNationalNo.Text = licenseInfoDTO.NationalNo;
            lblGendor.Text = licenseInfoDTO.Gendor;
            lblIssueDate.Text = licenseInfoDTO.IssueDate.ToShortDateString(); ;

            lblIssueReason.Text = licenseInfoDTO.IssueReason;          
            lblIsActive.Text = licenseInfoDTO.IsActive;

            lblDateOfBirth.Text = licenseInfoDTO.DateOfBirth.ToShortDateString();
            lblDriverID.Text = licenseInfoDTO.DriverID.ToString();
            lblExpirationDate.Text = licenseInfoDTO.ExpirationDate.ToShortDateString();

            lblIsDetained.Text = licenseInfoDTO.IsDetained;

            if (licenseInfoDTO.ImagePath != "")
                PictureBoxPersonImage.Load(licenseInfoDTO.ImagePath);

            if (licenseInfoDTO.Notes != "")
                lblNotes.Text = licenseInfoDTO.Notes;
            else
                lblNotes.Text = "No Notes";
        }
    }
}
