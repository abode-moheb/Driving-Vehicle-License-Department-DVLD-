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
    public partial class ShowInternationalDriverInfoForm : Form
    {
        public ShowInternationalDriverInfoForm(int InternationalLicenseID)
        {
            InitializeComponent();
            GetInternationalDriverInfo(InternationalLicenseID);
        }

        private void ShowInternationalDriverInfoForm_Load(object sender, EventArgs e)
        {

        }
        // FullName	InternationalLicenseID	IssuedUsingLocalLicenseID	NationalNo	Gendor	IssueDate	IsActive	DateOfBirth	DriverID	ExpirationDate	ApplicationID
        void GetInternationalDriverInfo(int InternationalLicenseID)
        {
            DataTable dataTable = new DataTable();
            dataTable = clsInternationalLicense.GetInternationalDriverInfo(InternationalLicenseID);

            lblName.Text = dataTable.Rows[0]["FullName"].ToString();
            lblInternationalLicenseID.Text = dataTable.Rows[0]["InternationalLicenseID"].ToString();
            lblLicenseID.Text = dataTable.Rows[0]["IssuedUsingLocalLicenseID"].ToString();
            lblNationalNo.Text = dataTable.Rows[0]["NationalNo"].ToString();
            lblGendor.Text = dataTable.Rows[0]["Gendor"].ToString();

            lblIssueDate.Text = dataTable.Rows[0]["IssueDate"].ToString();
            lblIsActive.Text = dataTable.Rows[0]["IsActive"].ToString();
            lblDateOfBirth.Text = dataTable.Rows[0]["DateOfBirth"].ToString();
            lblDriverID.Text = dataTable.Rows[0]["DriverID"].ToString();
            lblExpirationDate.Text = dataTable.Rows[0]["ExpirationDate"].ToString();
            lblApplicationID.Text = dataTable.Rows[0]["ApplicationID"].ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
