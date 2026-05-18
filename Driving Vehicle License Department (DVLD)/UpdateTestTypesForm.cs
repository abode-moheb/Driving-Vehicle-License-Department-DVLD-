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
    public partial class UpdateTestTypesForm : Form
    {
        clsManageTestTypes TestType;
        public UpdateTestTypesForm(int TestID)
        {
            InitializeComponent();
            FindTestTypeAndShow(TestID);
        }

        private void UpdateTestTypesForm_Load(object sender, EventArgs e)
        {

        }

        void FindTestTypeAndShow(int TestID)
        {
            TestType = clsManageTestTypes.FindTest(TestID);
            if(TestType != null)
            {
                lblTestId.Text = TestType.TestID.ToString();

                txtTestitle.Text = TestType.TestTitle;
                txtTestDescription.Text = TestType.TestDescription;
                txtTestFees.Text = TestType.TestFees.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestitle.Text) || string.IsNullOrWhiteSpace(txtTestDescription.Text) || string.IsNullOrWhiteSpace(txtTestFees.Text))
            {
                MessageBox.Show("All Field is reqiured", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TestType.TestTitle = txtTestitle.Text;
            TestType.TestDescription = txtTestDescription.Text;
            TestType.TestFees = Convert.ToInt32(txtTestFees.Text);

            if (TestType.Save())
            {
                MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;               
            }
            else
            {
                MessageBox.Show("Save failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtTestFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
