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
    public partial class ManagePeopleForm : Form
    {
        DataTable PeopleTable;
        DataView DefaultView;

        public ManagePeopleForm()
        {
            InitializeComponent();
        }

        private void ManagePeopleForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = 0;
            txtFilterby.Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;          
            LoadPeople();
            comboBox1.SelectedIndex = 0;
            ctrlShowPersonDetails.LoadPeople += LoadPeople;

        }

        void LoadPeople()
        {  
            PeopleTable = clsManagePeople.GetPeopleTable();
            DefaultView = PeopleTable.DefaultView;
            dataGridView1.DataSource = DefaultView;
         
            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
        }

        void LoadPeopleWithFilter(string column, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                DefaultView.RowFilter = "";
                lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            // لو العمود رقمي
            if (column == "[Person ID]")
            {
                DefaultView.RowFilter = $"Convert({column}, 'System.String') LIKE '%{value}%'";
            }
            else
            {
                DefaultView.RowFilter = $"{column} LIKE '%{value}%'";
            }

            lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
        }

        private void TxtFilterby_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                return;

            int selected = comboBox1.SelectedIndex;

            switch (selected)
            {
                case 0: // none
                    LoadPeopleWithFilter("", txtFilterby.Text);
                    break;

                case 1: // Person id
                    LoadPeopleWithFilter("[Person ID]", txtFilterby.Text);
                    break;

                case 2: // National num
                    LoadPeopleWithFilter("[National No]", txtFilterby.Text);
                    break;

                case 3: // First name
                    LoadPeopleWithFilter("[First name]", txtFilterby.Text);
                    break;

                case 4: // Seconde name
                    LoadPeopleWithFilter("[Seconde name]", txtFilterby.Text);
                    break;

                case 5: // Third name
                    LoadPeopleWithFilter("[Third name]", txtFilterby.Text);
                    break;

                case 6: // Last name
                    LoadPeopleWithFilter("[Last name]", txtFilterby.Text);
                    break;

                case 7: // Nationality
                    LoadPeopleWithFilter("[Nationality]", txtFilterby.Text);
                    break;

                case 8: // Gendor
                    LoadPeopleWithFilter("[Gendor]", txtFilterby.Text);
                    break;

                case 9: // Phone
                    LoadPeopleWithFilter("[Phone]", txtFilterby.Text);
                    break;

                case 10: // Email
                    LoadPeopleWithFilter("[Email]", txtFilterby.Text);
                    break;
            }
           
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void TxtFilterby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 9) // Person ID or Phone
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form AddOrEditForm = new AddOrEditPersonForm();
            AddOrEditForm.Show();
            LoadPeople();
        }

        private void TsmiShowDetails_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                PersonID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form ShowPersonDetails = new ShowPersonDetailsForm(PersonID);
            ShowPersonDetails.Show();
        }

        private void TsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            Form AddOrEditForm = new AddOrEditPersonForm();
            AddOrEditForm.Show();
            LoadPeople();
        }

        private void TsmiEdit_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                PersonID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            
            Form AddOrEditForm = new AddOrEditPersonForm(PersonID);
            if (AddOrEditForm.ShowDialog() == DialogResult.OK)
            {                
                LoadPeople();
            }
        }

        private void TsmiDelete_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                PersonID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            if(MessageBox.Show("Are you Sure","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsManagePeople.DeletePerson(PersonID))
                {
                    MessageBox.Show("Recorde Deleted Successfully", "Done",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadPeople();
                }
                else
                    MessageBox.Show("Recorde Deleted failed because has constraint", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void TsmiSendMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature not added yet", "Message");
        }

        private void TsmiPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature not added yet", "Message");
        }

       
    }
}
