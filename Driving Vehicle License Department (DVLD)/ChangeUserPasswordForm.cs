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
    public partial class ChangeUserPasswordForm : Form
    {

        clsManageUsers User;
        public ChangeUserPasswordForm(int UserID)
        {
            InitializeComponent();           
            FindUserDataAndShow(UserID);
        }
      
        private void ChangeUserPasswordForm_Load(object sender, EventArgs e)
        {

        }

        void FindPersonDataAndShow(int PersonID)
        {
            clsManagePeople Person = clsManagePeople.FindPerson(PersonID);
            if (Person != null)
            {
                ctrlShowPersonDetails1.ShowPersonData(Person);              
            }
            else
            {
                MessageBox.Show("cant find Person with this Person Id", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void FindUserDataAndShow(int UserID)
        {
            User = clsManageUsers.Find(UserID);

            if(User != null)
            {
                FindPersonDataAndShow(User.PersonId);

                lblUserID.Text = User.UserId.ToString();
                lblUserName.Text = User.UserName;
                lblIsActive.Text = (User.IsActive ? "Yes" : "No");
            }
        }

        private void TxtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtCurrentPassword.Text != User.Password)
            {
                errorProvider1.SetError(txtCurrentPassword, "Password not match the currect password");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void TxtNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Length < 6)
            {
                errorProvider1.SetError(txtNewPassword, "Password must have large than 6 letters");
            }
            else
                errorProvider1.SetError(txtNewPassword, "");
        }

        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password confirmmation does not match password");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool HasErrors()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (errorProvider1.GetError(ctrl) != "")
                {
                    return true;
                }
            }

            return false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (HasErrors())
                return;

            if (User != null)
            {
                User.Password = txtNewPassword.Text;
                if (User.Save())
                {
                    MessageBox.Show("User Save Sucessfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                    
                }
                else
                {
                    MessageBox.Show("User Save failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


      
    }
}
