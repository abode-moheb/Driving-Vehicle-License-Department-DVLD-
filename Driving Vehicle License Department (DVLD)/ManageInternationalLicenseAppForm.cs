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
    public partial class ManageInternationalLicenseAppForm : Form
    {
        DataTable InternationalLicenseTable;
        DataView FilterView;

        int PersonID = -1;

        Dictionary<int, string> ColumnsMap = new Dictionary<int, string>
        {
            {1,"[int License ID]" },
            {2,"[Application ID]"},
            {3,"[Driver ID]" },
            {4,"[L.License ID]"},
            {5,"[Is Active]" },
            
        };


        public ManageInternationalLicenseAppForm()
        {
            InitializeComponent();
            GetAllInternationalLicense();
        }

        private void ManageInternationalLicenseApp_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            IsActiveComboBox.Visible = false;
        }

        void GetAllInternationalLicense()
        {
            InternationalLicenseTable = new DataTable();
            InternationalLicenseTable = clsManageInternationalLicenseApp.GetAllInternationalLicense();

            FilterView = InternationalLicenseTable.DefaultView;

            dataGridView1.DataSource = FilterView;
            lblNumberOfRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        void ApplyFillter()
        {
            
            if (comboBox1.SelectedIndex <= 0)
            {
                FilterView.RowFilter = "";
                lblNumberOfRecords.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            string Column = ColumnsMap[comboBox1.SelectedIndex]; // column name

            if (Column == "[Is Active]")
            {
                int index = IsActiveComboBox.SelectedIndex;

                if (index == 0)
                    FilterView.RowFilter = "";
                else if (index == 1)
                    FilterView.RowFilter = $"{Column} = {1}"; // Active only
                else
                {
                    FilterView.RowFilter = $"{Column} = {0}"; // not Active only
                }

            }

            else
                FilterView.RowFilter = $"Convert({Column}, 'System.String') LIKE '%{txtFilterby.Text}%'";

            lblNumberOfRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void TxtFilterby_TextChanged(object sender, EventArgs e)
        {
            ApplyFillter();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            // IsActive
            if (index == 5)
            {
                txtFilterby.Visible = false;
                IsActiveComboBox.Visible = true;
                IsActiveComboBox.SelectedIndex = 0;
            }

            // None
            else if (index == 0)
            {
                txtFilterby.Visible = false;
                IsActiveComboBox.Visible = false;
                txtFilterby.Text = "";
                IsActiveComboBox.SelectedIndex = 0;
            }
            // باقي الأعمدة
            else
            {
                txtFilterby.Visible = true;
                IsActiveComboBox.Visible = false;
                txtFilterby.Text = "";
                IsActiveComboBox.SelectedIndex = 0;
            }
        }

        private void TxtFilterby_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void IsActiveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFillter();
        }

        private void TsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            int DriverID = -1;
            DriverID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);

            PersonID = clsInternationalLicense.GetPersonIDFromDriverID(DriverID);
            Form ShowPersonDetails = new ShowPersonDetailsForm(PersonID);
            ShowPersonDetails.Show();
        }

        private void TsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = -1;
            InternationalLicenseID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form ShowLicenseDetails = new ShowInternationalDriverInfoForm(InternationalLicenseID);
            ShowLicenseDetails.Show();

        }
        private void TsmiShowLicenseHistory_Click(object sender, EventArgs e)
        {
            int DriverID = -1;
            DriverID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);

            PersonID = clsInternationalLicense.GetPersonIDFromDriverID(DriverID);
            Form ShowLicenseHistory = new LicenseHistoryForm(PersonID);
            ShowLicenseHistory.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
