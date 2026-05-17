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
    public partial class ManageApplicationTypeForm : Form
    {
        public ManageApplicationTypeForm()
        {
            InitializeComponent();
        }

        private void ManageApplicationTypeForm_Load(object sender, EventArgs e)
        {
            LoadApplicationTypesTable();
        }

        void LoadApplicationTypesTable()
        {
            DataTable dataTable = new DataTable();
            dataTable = clsManageApplicationsTypes.GetApplicationsTypesTable();

            dataGridView1.DataSource = dataTable;
            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns["ID"].Width = 100;
            dataGridView1.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Fees"].Width = 100;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TsmiEditApplicationType_Click(object sender, EventArgs e)
        {
            int ApplicationID = -1;

            if (dataGridView1.SelectedRows.Count > 0)
                 ApplicationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form UpdateApplicationType = new UpdateApplicationTypeForm(ApplicationID);
            if(UpdateApplicationType.ShowDialog() == DialogResult.OK)
            {
                LoadApplicationTypesTable();
            }
        }
    }
}
