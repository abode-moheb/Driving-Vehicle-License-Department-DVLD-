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
    public partial class TakeTestForm : Form
    {

        int _TestAppointmentID;
        int _TestTypeID;
        public TakeTestForm(int TestAppointmentID, int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
            GetTestAppointmentData(_TestAppointmentID, _TestTypeID);
            
        }

        void GetTestAppointmentData(int TestAppointmentID , int TestTypeID)
        {           
            DataTable dataTable = new DataTable();
            dataTable = clsTakeTest.GetTestAppointmentData(TestAppointmentID, TestTypeID);

            lblLocalAppID.Text = dataTable.Rows[0]["LocalDrivingLicenseApplicationID"].ToString();
            lblDrivingClass.Text = dataTable.Rows[0]["ClassName"].ToString();
            lblName.Text = dataTable.Rows[0]["FullName"].ToString();
            lblTrial.Text = dataTable.Rows[0]["TrialCount"].ToString();
            dtpTestDate.Value = Convert.ToDateTime(dataTable.Rows[0]["AppointmentDate"]);

            int Fees = Convert.ToInt32(dataTable.Rows[0]["TestTypeFees"]);
            lblFees.Text = Fees.ToString();
        }

        private void TakeTestForm_Load(object sender, EventArgs e)
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
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool TestResult = rbPass.Checked ? true : false;
            string Notes = txtNote.Text;

            if(clsTakeTest.SaveNewTest(_TestAppointmentID, TestResult, Notes, GlobalSetting.CurrentUser.UserId))
            {
                clsTakeTest.LockTestAppointment(_TestAppointmentID);
                MessageBox.Show("Recorde Saved Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.OK;
            }
        }

       
    }
}
