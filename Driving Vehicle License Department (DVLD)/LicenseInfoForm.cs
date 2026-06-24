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
    public partial class LicenseInfoForm : Form
    {
        public LicenseInfoForm(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();           
            GetLicenseDriverData(LocalDrivingLicenseApplicationID);
        }

        private void LicenseInfoForm_Load(object sender, EventArgs e)
        {
           
        }

        void GetLicenseDriverData(int LocalDrivingLicenseApplicationID)
        {
            clsLicenseInfoDTO licenseInfoDTO = new clsLicenseInfoDTO();

            licenseInfoDTO = clsLicenseInfo.GetLicenseDriverData(LocalDrivingLicenseApplicationID);

            ctrlDriverLicseneInfo1.ShowData(licenseInfoDTO);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
