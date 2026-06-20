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

namespace Driving_Vehicle_License_Department__DVLD_.TestsForms
{
    public partial class SchedulingTestForm : Form
    {
        int _TestTypeID;
        int _LocalDrivingLicenseApplicationID;

        clsScheulingTest TestAppointments;
        public SchedulingTestForm(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            InitializeComponent();
            TestAppointments = new clsScheulingTest();
            _TestTypeID = TestTypeID;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            LoadSchedulingTestFormInfo(LocalDrivingLicenseApplicationID, _TestTypeID);
        }

        public SchedulingTestForm(int TestAppointmentID)
        {
            InitializeComponent();
            lblHeader.Text = "Edit Scheduling Test";           
            FindTestAppointment(TestAppointmentID);
        }

        void FindTestAppointment(int TestAppointmentID)
        {
            TestAppointments = clsScheulingTest.Find(TestAppointmentID);
            if(TestAppointments != null)
            {
                dtpTestDate.Value = TestAppointments.AppointmentDate;
                LoadSchedulingTestFormInfo(TestAppointments.LocalDrivingLicenseApp, TestAppointments.TestTypeID);
            }
        }

        private void SchedulingTestForm_Load(object sender, EventArgs e)
        {
            if (_TestTypeID == 1)
            {
                pictureBox1.Image = Properties.Resources.Vision_512;
                groupBox1.Text = "Vision Test";
            }

            if (_TestTypeID == 2)
            {
                pictureBox1.Image = Properties.Resources.Written_Test_512;
                groupBox1.Text = "Written Test";
            }

            if(_TestTypeID == 3)
            {
                pictureBox1.Image = Properties.Resources.driving_test_512;
                groupBox1.Text = "Street Test";
            }

            lblRetakeAppFees.Text = "0";
            lblTotalFees.Text = (Convert.ToInt32(lblFees.Text) + Convert.ToInt32(lblRetakeAppFees.Text)).ToString();
            lblRetakeTestAppID.Text = "N/A";
            dtpTestDate.MinDate = DateTime.Today;

            if (IsRetakeTest())
            {
                lblHeader.Text = "Schedule Retake Test";
                lblRetakeAppFees.Text = "5";
                lblTotalFees.Text = (Convert.ToInt32(lblFees.Text) + Convert.ToInt32(lblRetakeAppFees.Text)).ToString();
            }
        }

        void LoadSchedulingTestFormInfo(int LocalDrivingLicenseApplicationID, int _TestTypeID)
        {
            DataTable dataTable = new DataTable();
            dataTable = clsScheulingTest.GetSchedulingTestFormInfo(LocalDrivingLicenseApplicationID, _TestTypeID);

            lblLocalAppID.Text = dataTable.Rows[0]["LocalDrivingLicenseApplicationID"].ToString();
            lblDrivingClass.Text = dataTable.Rows[0]["ClassName"].ToString();
            lblName.Text = dataTable.Rows[0]["FullName"].ToString();
            lblTrial.Text = dataTable.Rows[0]["TrialCount"].ToString();

            int Fees = Convert.ToInt32(dataTable.Rows[0]["TestTypeFees"]);
            lblFees.Text = Fees.ToString();
        }

        bool IsRetakeTest()
        {
            return clsScheulingTest.IsRetakeTest(_LocalDrivingLicenseApplicationID,_TestTypeID);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TestAppointments.TestTypeID = _TestTypeID;
            TestAppointments.LocalDrivingLicenseApp = _LocalDrivingLicenseApplicationID;
            TestAppointments.AppointmentDate = dtpTestDate.Value;
            TestAppointments.PaidFees = Convert.ToInt32(lblTotalFees.Text);
            TestAppointments.CreatedByUserID = GlobalSetting.CurrentUser.UserId;
            TestAppointments.isLocked = 0;

            if (TestAppointments.Save())
            {
                MessageBox.Show("Recorde Save Successfully","Done",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
