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
    public partial class ShowPersonDetailsForm : Form
    {        
        public ShowPersonDetailsForm(int PersonID)
        {
            InitializeComponent();
            FindPersonData(PersonID);
        }

        private void ShowPersonDetailsForm_Load(object sender, EventArgs e)
        {
            ctrlShowPersonDetails1.CloseForm += CloseForm;
        }
       
        void FindPersonData(int PersonID)
        {
            clsManagePeople PersonData = clsManagePeople.FindPerson(PersonID);
            if (PersonData != null)
            {
                ctrlShowPersonDetails1.ShowPersonData(PersonData);
            }
            else
                MessageBox.Show("Person not found");
        }

        void CloseForm() {

            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
