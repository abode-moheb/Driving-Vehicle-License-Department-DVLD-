using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DVLD_BussinessLayer;

namespace Driving_Vehicle_License_Department__DVLD_
{
    public partial class ManageTestTypesForm : Form
    {
        public ManageTestTypesForm()
        {
            InitializeComponent();
        }

        private void ManageTestTypesForm_Load(object sender, EventArgs e)
        {
            LoadTestTypesTable();
        }

        void LoadTestTypesTable()
        {
            DataTable dataTable = clsManageTestTypes.LoadTestTypesTable();

            dataGridView1.DataSource = dataTable;
            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
        }

        private void TsmiEditTestType_Click(object sender, EventArgs e)
        {
            int TestID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                TestID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form UpdateTestType = new UpdateTestTypesForm(TestID);
            if(UpdateTestType.ShowDialog() == DialogResult.OK)
            {
                LoadTestTypesTable();
            }
        }
    }
}
