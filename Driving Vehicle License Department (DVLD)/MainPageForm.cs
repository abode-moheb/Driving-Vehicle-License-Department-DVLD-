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
    public partial class MainPageForm : Form
    {
        public MainPageForm()
        {
            InitializeComponent();
        }

        private void PepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form PeopleForm = new ManagePeopleForm();
            PeopleForm.Show();
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form UsersForm = new ManageUsersForm();
            UsersForm.Show();
        }

        private void MainPageForm_Load(object sender, EventArgs e)
        {           

        }

        private void TsmiCurrentUser_Click(object sender, EventArgs e)
        {
            Form ShowUserDetails = new ShowUserDetailsForm(GlobalSetting.CurrentUser.UserId);
            ShowUserDetails.Show();
        }

        private void TsmiChangePassword_Click(object sender, EventArgs e)
        {
            Form ChangePassword = new ChangeUserPasswordForm(GlobalSetting.CurrentUser.UserId);
            ChangePassword.Show();

        }

        private void TsmiSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalSetting.Logout();
        }

        private void TsmiManageApplicationTypes_Click(object sender, EventArgs e)
        {
            Form ManageApplicationType = new ManageApplicationTypeForm();
            ManageApplicationType.Show();
        }

        private void TsmiManageTestTypes_Click(object sender, EventArgs e)
        {
            Form ManageTestTypes = new ManageTestTypesForm();
            ManageTestTypes.Show();

        }

        private void TsmiLocalLicense_Click(object sender, EventArgs e)
        {
            Form LocalDrivingLicenseApplication = new LocalDrivingLicenseApplicationForm();
            LocalDrivingLicenseApplication.Show();
        }

        private void TsmiLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            Form ManageLocalDrivingLicenseApplication = new ManageLocalDrivingLicenseApplicationForm();
            ManageLocalDrivingLicenseApplication.Show();
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ListDrivers = new ListDriversForm();
            ListDrivers.Show();
        }
    }
}
