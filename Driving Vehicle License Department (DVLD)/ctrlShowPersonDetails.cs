using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BussinessLayer;

namespace Driving_Vehicle_License_Department__DVLD_
{
    public partial class ctrlShowPersonDetails : UserControl
    {

        string _ImagePath = "";

        public event Action CloseForm;
        static public event Action LoadPeople;

        private int _PersonID = -1;
        public int PersonID
        {
            get
            {
                return _PersonID;
            }

            set
            {
                _PersonID = value;
                lblPersonID.Text = value.ToString();
            }
        }

        public string NationalNum
        {
            set { lblNationalNo.Text = value; }
        }

        public string Name
        {
            set { lblName.Text = value; }
        }

        public string DateOfBirth
        {
            set { lblDateOfBirth.Text = value; }
        }

        public int Gendor
        {
            set
            {
                if (value == 0)
                    lblGendor.Text = "Male";
                else
                    lblGendor.Text = "Female";
            }
        }

        public string Address
        {
            set { lblAddress.Text = value; }
        }

        public string Phone
        {
            set { lblPhone.Text = value; }
        }

        public string Email
        {
            set { lblEmail.Text = value; }
        }

        public string NationalityCountry
        {
            set { lblCountry.Text = value; }
        }

        public string ImageSavedPath
        {
            set { _ImagePath = value; }
        }

        public ctrlShowPersonDetails()
        {
            InitializeComponent();
        }

        void ClearImage()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        void LoadPersonImage()
        {
            if (!string.IsNullOrWhiteSpace(_ImagePath))
            {
                try
                {
                    pictureBox1.Load(_ImagePath);
                }
                catch
                {
                    MessageBox.Show("الصورة غير متوفرة على هذا الجهاز");
                    ClearImage();
                }
            }
            else
            {
                ClearImage();
            }
        }

        private void CtrlShowPersonDetails_Load(object sender, EventArgs e)
        {           
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PersonID > -1)
            {
                Form AddOrEditForm = new AddOrEditPersonForm(PersonID);
                CloseForm?.Invoke();

                if (AddOrEditForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPeople?.Invoke();
                }
            }
        }

        public void ShowPersonData(clsManagePeople PersonData)
        {
            this.PersonID = PersonData.PersonID;

            this.NationalNum = PersonData.NationalNum;
            this.Name = PersonData.FirstName + " " + PersonData.SecondName + " " + PersonData.ThirdName + " " + PersonData.LastName;
            this.DateOfBirth = PersonData.DateOfBirth.ToShortDateString();

            this.Email = PersonData.Email;
            this.Phone = PersonData.Phone;
            this.Gendor = PersonData.Gendor;

            this.Address = PersonData.Address;
            this.ImageSavedPath = PersonData.ImagePath;
            this.NationalityCountry = clsManagePeople.GetCountryNameByCountryID(PersonData.NationalityCountryID);
            LoadPersonImage();
        }
       
    }
}
