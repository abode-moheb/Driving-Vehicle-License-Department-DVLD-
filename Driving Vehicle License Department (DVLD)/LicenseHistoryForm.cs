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
    public partial class LicenseHistoryForm : Form
    {
        clsManagePeople Person;
        public LicenseHistoryForm(string NationalNo)
        {
            InitializeComponent();           
            LoadPersonData(NationalNo);
            GetPersonLocalLicense();
            GetPersonInternationalLicense();
        }

        private void LicenseHistoryForm_Load(object sender, EventArgs e)
        {
            ctrlFindWithFilter1.txtFillter = Person.PersonID.ToString();
            ctrlFindWithFilter1.ComboBox = 1;
        }

        void LoadPersonData(string NationalNo)
        {
            Person = clsManagePeople.FindPerson(NationalNo);           
            ctrlShowPersonDetails1.ShowPersonData(Person);          
        }

        void GetPersonLocalLicense()
        {
            DataTable dataTable = new DataTable();
            dataTable = clsLicenseHistory.GetPersonLocalLicense(Person.PersonID);

            DataViewLocal.DataSource = dataTable;
            lblLocalRecordeNumbers.Text = DataViewLocal.Rows.Count.ToString();
        }

        void GetPersonInternationalLicense()
        {
            DataTable dataTable = new DataTable();
            dataTable = clsLicenseHistory.GetPersonInternationalLicense(Person.PersonID);

            DataViewInternational.DataSource = dataTable;
            lblRecordsInternationalNum.Text = DataViewInternational.Rows.Count.ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
