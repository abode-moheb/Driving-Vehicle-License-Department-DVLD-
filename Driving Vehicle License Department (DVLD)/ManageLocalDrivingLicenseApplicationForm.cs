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
    public partial class ManageLocalDrivingLicenseApplicationForm : Form
    {

        DataTable dataTable;
        DataView DefaultView;

        Dictionary<int, string> ColumnsMap = new Dictionary<int, string>
        {
            {1,"[LocalDrivingLicenseApplicationID]"},
            {2,"[NationalNo]"},

            {3,"[FullName]"},
            {4,"[Status]"},           
        };

        public ManageLocalDrivingLicenseApplicationForm()
        {
            InitializeComponent();
        }

        private void ManageLocalDrivingLicenseApplicationForm_Load(object sender, EventArgs e)
        {
            LoadLocalDrivingLicenseApplication();

            txtFilterby.Visible = false;
            comboBox1.SelectedIndex = 0;
           
        }

        void LoadLocalDrivingLicenseApplication()
        {          
         
            dataTable = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationTable();
            DefaultView = dataTable.DefaultView;
            dataGridView1.DataSource = DefaultView;


            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns[0].HeaderText = "L.D.LAppID";
            dataGridView1.Columns[0].Width = 75;

            dataGridView1.Columns[1].HeaderText = "Driving Class";
            dataGridView1.Columns[1].Width = 175;

            dataGridView1.Columns[2].HeaderText = "National No";
            dataGridView1.Columns[2].Width = 75;

            dataGridView1.Columns[3].HeaderText = "Full Name";
            dataGridView1.Columns[3].Width = 175;

            dataGridView1.Columns[4].HeaderText = "Application Date";
            dataGridView1.Columns[4].Width = 150;

            dataGridView1.Columns[5].HeaderText = "Passed Test";
            dataGridView1.Columns[5].Width = 75;

            dataGridView1.Columns[6].HeaderText = "Status";
            dataGridView1.Columns[6].Width = 100;
        }

        void ApplyFillter()
        {

            if (comboBox1.SelectedIndex <= 0)
            {
                DefaultView.RowFilter = "";
                lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            string Column = ColumnsMap[comboBox1.SelectedIndex]; // column name

            // لو العمود رقمي
            if (Column == "[LocalDrivingLicenseApplicationID]")
            {
                DefaultView.RowFilter = $"Convert({Column}, 'System.String') LIKE '%{txtFilterby.Text}%'";
            }
            else
            {
                DefaultView.RowFilter = $"{Column} LIKE '%{txtFilterby.Text}%'";
            }

            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
        }
       
        private void TxtFilterby_TextChanged_1(object sender, EventArgs e)
        {
            ApplyFillter();
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int SelectedIndex = comboBox1.SelectedIndex;
            if (SelectedIndex != 0)
            {
                txtFilterby.Visible = true;
                txtFilterby.Text = string.Empty;
            }
            else
            {
                txtFilterby.Visible = false;
                txtFilterby.Text = string.Empty;
            }
        }

        private void TxtFilterby_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1) 
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form LocalDrivingLicenseApplication = new LocalDrivingLicenseApplicationForm();
            if(LocalDrivingLicenseApplication.ShowDialog() == DialogResult.OK)
            {
                LoadLocalDrivingLicenseApplication();
                string oldFilterText = txtFilterby.Text;
                txtFilterby.Text = string.Empty;
                txtFilterby.Text = oldFilterText;
            }
        }

       
        private void TsmiShowAppDetails_Click(object sender, EventArgs e)
        {

        }

        private void TsmiEditApp_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                LocalDrivingLicenseApplicationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form EditLocalDrivingLicenseApp = new LocalDrivingLicenseApplicationForm(LocalDrivingLicenseApplicationID);
            if (EditLocalDrivingLicenseApp.ShowDialog() == DialogResult.OK)
            {
                LoadLocalDrivingLicenseApplication();
                string oldFilterText = txtFilterby.Text;
                txtFilterby.Text = string.Empty;
                txtFilterby.Text = oldFilterText;
            }

        }

        private void TsmiDeleteApp_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = -1;          
            if (dataGridView1.SelectedRows.Count > 0)
            {
                LocalDrivingApplicationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);              
            }

            if (MessageBox.Show("Are You Sure ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.Delete(LocalDrivingApplicationID))
                {
                    MessageBox.Show("Recorde Deleted Successfully", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadLocalDrivingLicenseApplication();
                }
                else
                    MessageBox.Show("Recorde Deleted Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void TsmiCancelApp_Click(object sender, EventArgs e)
        {

        }

        private void TsmiSechduleVisionTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                LocalDrivingLicenseApplicationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form VisionTest = new TestsForms.TestForm(LocalDrivingLicenseApplicationID);
            VisionTest.Show();
        }
    }
}
