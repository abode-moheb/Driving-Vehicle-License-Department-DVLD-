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
    public partial class ListDriversForm : Form
    {
        DataTable DriverTable;
        DataView DefaultView;

        Dictionary<int, string> ColumnsMap = new Dictionary<int, string>
        {
            {1,"[Driver ID]"},
            {2,"[Person ID]"},
            {3,"[National No]"},
        
            {4,"[Full Name]"},
            {5,"[Active Licenses]"},        
        };

        public ListDriversForm()
        {
            InitializeComponent();
        }

        private void ListDriversForm_Load(object sender, EventArgs e)
        {
            GetDriversList();
            txtFilterby.Visible = false;
            comboBox1.SelectedIndex = 0;
        }

        void GetDriversList()
        {           
            DriverTable = clsListDrivers.GetDriversList();
            DefaultView = DriverTable.DefaultView;

            dataGridView1.DataSource = DefaultView;
            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
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
            if (Column == "[Person ID]" || Column == "[Driver ID]" || Column == "[Active Licenses]")
            {
                DefaultView.RowFilter = $"Convert({Column}, 'System.String') LIKE '%{txtFilterby.Text}%'";
            }
            else
            {
                DefaultView.RowFilter = $"{Column} LIKE '%{txtFilterby.Text}%'";
            }

            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
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

        private void TxtFilterby_TextChanged(object sender, EventArgs e)
        {
            ApplyFillter();
        }

        private void TxtFilterby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 5) // Person ID or Phone
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
