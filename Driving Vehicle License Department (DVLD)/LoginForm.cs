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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        bool ValidateForm()
        {
            bool IsValidate;
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "This Field is reqiured");
                IsValidate = false;
            }

            else
            {
                errorProvider1.SetError(txtUserName, "");
                IsValidate = true;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "This Field is reqiured");
                IsValidate = false;
            }

            else
            {
                errorProvider1.SetError(txtPassword, "");
                IsValidate = true;
            }

            return IsValidate;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            bool IsAccountActive = false;
            if (clsManageUsers.Login(txtUserName.Text, txtPassword.Text, ref IsAccountActive))
            {
                if (IsAccountActive)
                {
                    if (rbRememberMe.Checked)
                        clsManageUsers.SaveLastAccountLogin(txtUserName.Text,txtPassword.Text);

                    Form MainPage = new MainPageForm();
                    MainPage.Show();
                }
                else
                {
                    MessageBox.Show("Your account is denied", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid UserName/Passowrd", "Uncorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void GetLastAccountLogin()
        {
            string UserName = "";
            string Password = "";

            if (clsManageUsers.GetlastAccountLogin(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            GetLastAccountLogin();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!rbRememberMe.Checked)
            {
                clsManageUsers.ClearlastLoginFile();
            }
        }
    }
}
