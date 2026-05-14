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
    public partial class AddOrEditUserForm : Form
    {
        enum _enMode {enAddNew,enUpdate }
        _enMode Mode;

        clsManagePeople Person;
        clsManageUsers User;
        bool allowTabChange = false;

        static public event Action OnSavedClicked;

        public AddOrEditUserForm()
        {
            InitializeComponent();
            User = new clsManageUsers();
            Mode = _enMode.enAddNew;
        }

        public AddOrEditUserForm(int UserID)
        {
            InitializeComponent();
            lblHeader.Text = "Update User";
            FindUserAndShowDetails(UserID);
            Mode = _enMode.enUpdate;
        }
        private void AddOrEditUserForm_Load(object sender, EventArgs e)
        {
            ctrlFindWithFilter1.FindUseNationalNo += FindUseNatoinalNo;
            ctrlFindWithFilter1.FindUsePersonID += FindUsePersonID;

            AddOrEditPersonForm.DataBack += FindUsePersonID;
        }

        void FindUseNatoinalNo(string NationalNo)
        {
            Person = clsManagePeople.FindPerson(NationalNo);
            if (Person != null)
            {
                ctrlShowPersonDetails1.ShowPersonData(Person);
                btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("cant find Person with this national number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        void FindUsePersonID(int PersonID)
        {
            ctrlFindWithFilter1.txtFillter = PersonID.ToString();
            ctrlFindWithFilter1.ComboBox = 1;

            Person = clsManagePeople.FindPerson(PersonID);
            if (Person != null)
            {
                 ctrlShowPersonDetails1.ShowPersonData(Person);
                 btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("cant find Person with this Person Id", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
      
        private void CtrlFindWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void CtrlShowPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (Mode == _enMode.enAddNew)
            {

                if (Person != null)
                {
                    if (!clsManageUsers.CheckIfPersonIsUser(Person.PersonID))
                    {
                        allowTabChange = true;
                        tabControl1.SelectedIndex = 1;
                        allowTabChange = false;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("The person is already user in system", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                allowTabChange = true;
                tabControl1.SelectedIndex = 1;
            }
        }

        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password confirmmation does not match password");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!allowTabChange)
                e.Cancel = true;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                errorProvider1.SetError(txtPassword, "Password must have large than 6 letters");                
            }
            else
                errorProvider1.SetError(txtPassword, "");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "the field is required");
                return;
            }
           
            if (txtPassword.Text != txtConfirmPassword.Text)
                return;

            User.UserName = txtUserName.Text;
            User.PersonId = Person.PersonID;
            User.Password = txtPassword.Text;
            User.IsActive = cbIsActive.Checked;


                if (User.Save())
                {
                    MessageBox.Show("User Save Sucessfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtUserID.Text = User.UserId.ToString();
                    lblHeader.Text = "Update User";

                    OnSavedClicked?.Invoke();
                }
                else
                {
                    MessageBox.Show("User Save failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }          
        }

        void FindUserAndShowDetails(int UserID)
        {
            User = clsManageUsers.Find(UserID);
            
            if(User != null)
            {
                FindUsePersonID(User.PersonId);
                ctrlFindWithFilter1.Enabled = false;

                txtUserID.Text = User.UserId.ToString();
                txtUserName.Text = User.UserName;
                txtPassword.Text = User.Password;
                txtConfirmPassword.Text = User.Password;
                cbIsActive.Checked = User.IsActive;
            }
            else
            {
                MessageBox.Show("cant find User with this users Id", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
