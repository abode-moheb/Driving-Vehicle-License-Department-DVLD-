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
    public partial class TestAppointmentsForm : Form
    {        
        int _LocalDrivingLicenseApplicationID;
        int _TestTypeID;
        public TestAppointmentsForm(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            InitializeComponent();
            LoadTestFormData(_LocalDrivingLicenseApplicationID);
            LoadApplicationAppointments(_LocalDrivingLicenseApplicationID, _TestTypeID);
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            if (_TestTypeID == 1)
            {
                pictureBox1.Image = Properties.Resources.Vision_512;
                lblHeader.Text = "Vision Test Appointments";
                this.Text = "Vision Test Form";
            }

            if (_TestTypeID == 2)
            {
                pictureBox1.Image = Properties.Resources.Written_Test_512;
                lblHeader.Text = "Written Test Appointments";
                this.Text = "Written Test Form";
            }

            if(_TestTypeID == 3)
            {
                pictureBox1.Image = Properties.Resources.driving_test_512;
                lblHeader.Text = "Street Test Appointments";
                this.Text = "Street Test Form";
            }

        }
        
        void LoadTestFormData(int _LocalDrivingLicenseApplicationID)
        {

            clsTestAppointemtsDTO TestAppointemtsDTO = clsTestAppointments.LoadTestFormData(_LocalDrivingLicenseApplicationID);            
            ctrlDrivingLicenseApplicationInfo1.ShowData(TestAppointemtsDTO);            
          
        }

        void LoadApplicationAppointments(int _LocalDrivingLicenseApplicationID, int TestType)
        {
            DataTable dataTable = new DataTable();
            dataTable = clsTestAppointments.GetApplicationAppointments(_LocalDrivingLicenseApplicationID, TestType);

            dataGridView1.DataSource = dataTable;
            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void BtnAddAppointments_Click(object sender, EventArgs e)
        {
            if (clsTestAppointments.CheckIfHadActiveAppoientment(_LocalDrivingLicenseApplicationID, _TestTypeID))
                MessageBox.Show("Person already have an active appointment for this test , you cant add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if(clsTestAppointments.CheckIfTestPassed(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                MessageBox.Show("The Person is Passed the Current Test", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Form SchedulingTest = new TestsForms.SchedulingTestForm(_LocalDrivingLicenseApplicationID, _TestTypeID);
                if (SchedulingTest.ShowDialog() == DialogResult.OK)
                {
                    LoadApplicationAppointments(_LocalDrivingLicenseApplicationID, _TestTypeID);
                }
            }
        }

        private void TsmiEditTestAppointemt_Click(object sender, EventArgs e)
        {
            int TestAppointemntID = -1;
            if (dataGridView1.Rows.Count > 0)
                TestAppointemntID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            bool isLocked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[3].Value);
            if (isLocked)
                return;

            Form EditSchedulingTest = new TestsForms.SchedulingTestForm(TestAppointemntID);
            if (EditSchedulingTest.ShowDialog() == DialogResult.OK)
            {
                LoadApplicationAppointments(_LocalDrivingLicenseApplicationID, _TestTypeID);
            }
        }

        private void TsmiTakeTest_Click(object sender, EventArgs e)
        {
            int TestAppointemntID = -1;
            if (dataGridView1.Rows.Count > 0)
                TestAppointemntID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            bool isLocked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[3].Value);
            if (isLocked)
                return;

            Form TakeTest = new TakeTestForm(TestAppointemntID, _LocalDrivingLicenseApplicationID, _TestTypeID);
            if (TakeTest.ShowDialog() == DialogResult.OK)
            {
                LoadApplicationAppointments(_LocalDrivingLicenseApplicationID, _TestTypeID);
                LoadTestFormData(_LocalDrivingLicenseApplicationID);
            }
        }

        private void TestAppointmentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
