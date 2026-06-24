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
    public partial class ShowApplicationDetailsForm : Form
    {
        public ShowApplicationDetailsForm(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            GetApplicationDetails(LocalDrivingLicenseApplicationID);
        }

        private void ShowApplicationDetailsForm_Load(object sender, EventArgs e)
        {

        }

        void GetApplicationDetails(int LocalDrivingLicenseApplicationID)
        {
            clsTestAppointemtsDTO TestAppointemtsDTO = clsTestAppointments.LoadTestFormData(LocalDrivingLicenseApplicationID);
            ctrlDrivingLicenseApplicationInfo1.ShowData(TestAppointemtsDTO);

            ctrlDrivingLicenseApplicationInfo1.ShowData(TestAppointemtsDTO);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
