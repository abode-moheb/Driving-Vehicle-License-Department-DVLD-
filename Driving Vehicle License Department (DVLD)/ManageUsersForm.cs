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
    public partial class ManageUsersForm : Form
    {
        DataTable UsersTable;
        DataView DefaultView;
        
        Dictionary<int, string> ColumnsMap = new Dictionary<int, string>()
        {
            {1, "[User ID]"},
            {2, "[Person ID]"},
            {3, "[Full Name]"},
            {4, "[UserName]"},
            {5, "[Is Active]"}
        };

        public ManageUsersForm()
        {
            InitializeComponent();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            txtFilterby.Visible = false;
            IsActiveComboBox.Visible = false;

            LoadUsers();
            comboBox1.SelectedIndex = 0;
            AddOrEditUserForm.OnSavedClicked += LoadUsers;           
        }

        void LoadUsers()
        {
            UsersTable = clsManageUsers.GetAllUsers();
            DefaultView = UsersTable.DefaultView;

            dataGridView1.DataSource = DefaultView;
            lblNumberOfRecords.Text = dataGridView1.Rows.Count.ToString();
        }
      
        void ApplyFilter()
        {
            // لا يوجد اختيار
            if (comboBox1.SelectedIndex <= 0)
            {
                DefaultView.RowFilter = "";
                lblRecordeNumber.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            string column = ColumnsMap[comboBox1.SelectedIndex]; // Column name
           
            if (column == "[Is Active]")
            {
                int index = IsActiveComboBox.SelectedIndex;
            
                if (index == 0)
                    DefaultView.RowFilter = "";
                else if(index == 1)
                    DefaultView.RowFilter = $"{column} = {1}"; // Active only
                else
                {
                    DefaultView.RowFilter = $"{column} = {0}"; // not Active only
                }
                
            }

            
            else if (column == "[User ID]" || column == "[Person ID]")
            {
                DefaultView.RowFilter = $"Convert({column}, 'System.String') LIKE '%{txtFilterby.Text}%'";
            }

            else
            {
                DefaultView.RowFilter = $"{column} LIKE '%{txtFilterby.Text}%'";
            }

            lblNumberOfRecords.Text = DefaultView.Count.ToString();          
        }

        private void TxtFilterby_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
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
            }
            // باقي الأعمدة
            else
            {
                txtFilterby.Visible = true;
                IsActiveComboBox.Visible = false;
                txtFilterby.Text = "";
            }
           
        }

        private void IsActiveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void TxtFilterby_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form AddOrEditUser = new AddOrEditUserForm();
            AddOrEditUser.ShowDialog();
        }

        private void ShowDetailstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                UserID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form ShowUserDetails = new ShowUserDetailsForm(UserID);
            ShowUserDetails.Show();          
        }

        private void AddNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AddOrEditUser = new AddOrEditUserForm();
            AddOrEditUser.ShowDialog();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                UserID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form AddOrEditUser = new AddOrEditUserForm(UserID);
            AddOrEditUser.Show();            
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                UserID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            if(MessageBox.Show("Are you sure you want delete this recorde ? ", "Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                if (clsManageUsers.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("User Deleted failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                UserID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            Form ChangePassword = new ChangeUserPasswordForm(UserID);
            ChangePassword.Show();                  
        }

        private void SendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature not added yet", "Message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void PhoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature not added yet", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
