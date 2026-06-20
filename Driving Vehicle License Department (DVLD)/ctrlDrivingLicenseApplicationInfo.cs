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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        int _ApplicantPersonID = -1;
        public int DrivingLicenseAppID
        {
            set { lblDrivingLicenseAppID.Text = value.ToString(); }           
        }
        public string LicenseClass
        {
            set { lblAppliedForLicense.Text = value; }
            get { return lblAppliedForLicense.Text; }
        }
        public int PassedTests
        {
            set { lblPassedTests.Text = value.ToString() + "/" + "3"; }
        }
        public int ApplicationID
        {
            set { lblAppID.Text = value.ToString(); }
            get { return Convert.ToInt32(lblAppID.Text); }
        }

        public int ApplicantPersonID
        {
            set { _ApplicantPersonID = value; }
            get { return _ApplicantPersonID; }
        }
        public string AppStatus
        {
            set { lblStatus.Text = value; }
        }
        public int AppFees
        {
            set { lblFees.Text = value.ToString(); }
            get { return Convert.ToInt32(lblFees.Text); }
        }
        public string AppType
        {
            set { lblType.Text = value; }
        }
        public string Applicant
        {
            set { lblApplicant.Text = value; }
        }
        public DateTime AppDate
        {
            set { lblDate.Text = value.ToShortDateString(); }
        }
        public DateTime StatusDate
        {
            set { lblStatusDate.Text = value.ToShortDateString(); }
        }
        public string CreatedBy
        {
            set { lblCreatedBy.Text = value; }
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CtrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        public void ShowData(clsTestAppointemtsDTO testAppointemtsDTO)
        {
            DrivingLicenseAppID = testAppointemtsDTO.DrivingLicenseAppID;
            LicenseClass = testAppointemtsDTO.LicenseClass;
            PassedTests = testAppointemtsDTO.PassedTests;

            ApplicationID = testAppointemtsDTO.ApplicationID;
            ApplicantPersonID = testAppointemtsDTO.ApplicantPersonID;
            AppStatus = testAppointemtsDTO.AppStatus;
            AppFees = testAppointemtsDTO.AppFees;

            AppType = testAppointemtsDTO.AppType;
            Applicant = testAppointemtsDTO.Applicant;
            AppDate = testAppointemtsDTO.AppDate;

            StatusDate = testAppointemtsDTO.StatusDate;
            CreatedBy = testAppointemtsDTO.CreatedBy;
        }

        private void LinkLabelViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form ShowPersonDetails = new ShowPersonDetailsForm(_ApplicantPersonID);
            ShowPersonDetails.Show();
             
        }
    }
}
