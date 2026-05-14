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
    public partial class ShowUserDetailsForm : Form
    {
        public ShowUserDetailsForm(int UserID)
        {
            InitializeComponent();
            FindUserDataAndShow(UserID);
        }

        private void ShowUserDetailsForm_Load(object sender, EventArgs e)
        {

        }

        void FindUserDataAndShow(int UserID)
        {
            clsManageUsers User = clsManageUsers.Find(UserID);

            clsManagePeople Person = clsManagePeople.FindPerson(User.PersonId);

            if (User != null)
            {
                ctrlShowPersonDetails1.ShowPersonData(Person);
                
                lblUserID.Text = User.UserId.ToString();
                lblUserName.Text = User.UserName;
                lblIsActive.Text = (User.IsActive ? "Yes" : "No");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
