using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_Vehicle_License_Department__DVLD_
{
    public partial class ctrlShowPersonDetails : UserControl
    {

        string _ImagePath = "";

        public event Action CloseForm;
        static public event Action LoadPeople;

        public int PersonID
        {
            set { lblPersonID.Text = value.ToString(); }
            get { return Convert.ToInt32(lblPersonID.Text); }
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

        void LoadPersonImage()
        {
            if (_ImagePath != "")
                try
                {
                    pictureBox1.Load(_ImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("الصورة غير متوفرة على الجهاز");
                }
        }

        private void CtrlShowPersonDetails_Load(object sender, EventArgs e)
        {
            lblName.ForeColor = Color.Red;
            LoadPersonImage();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form AddOrEditForm = new AddOrEditPersonForm(PersonID);
            CloseForm?.Invoke();
           
            if (AddOrEditForm.ShowDialog() == DialogResult.OK)
            {
                LoadPeople?.Invoke();
            }
        }
    }
}
