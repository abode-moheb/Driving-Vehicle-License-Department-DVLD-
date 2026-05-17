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
    public partial class UpdateApplicationTypeForm : Form
    {
        clsManageApplicationsTypes Application;
        public UpdateApplicationTypeForm(int ApplicationID)
        {
            InitializeComponent();
            FindApplicationDetailsAndShow(ApplicationID);
        }

        private void UpdateApplicationTypeForm_Load(object sender, EventArgs e)
        {

        }

        void FindApplicationDetailsAndShow(int ApplicationID)
        {
            Application = clsManageApplicationsTypes.FindApplication(ApplicationID);

            if(Application != null)
            {
                lblApplicationId.Text = Application.ApplicationID.ToString();
                txtApplicationTitle.Text = Application.ApplicationTitle;
                txtApplicationFees.Text = Application.ApplicationFees.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(lblApplicationId.Text) || string.IsNullOrWhiteSpace(txtApplicationTitle.Text) || string.IsNullOrWhiteSpace(txtApplicationFees.Text))
            {
                MessageBox.Show("All Field is reqiured", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;              
            }

            Application.ApplicationTitle = txtApplicationTitle.Text;
            Application.ApplicationFees = Convert.ToInt32(txtApplicationFees.Text);

            if (Application.Save())
            {
                MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Save failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtApplicationFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
