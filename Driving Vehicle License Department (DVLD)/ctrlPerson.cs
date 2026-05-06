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
    public partial class ctrlPerson : UserControl
    {
        int _PersonCountry = 169;
        string ImagePath;
        string sourcePhoto = "";      
        string oldNationalNum = "";
        string OldImagePath = "";
     

        public string NationalNum
        {
            get { return txtNationalNum.Text; }
            set { txtNationalNum.Text = value; }
        }

        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }

        public string SecondeName
        {
            get { return txtSecondeName.Text; }
            set { txtSecondeName.Text = value; }
        }

        public string ThirdName
        {
            get { return txtThirdName.Text; }
            set { txtThirdName.Text = value; }
        }

        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dtpDateOfBirth.Value; }
            set { dtpDateOfBirth.Value = value; }
        }

        public int Gendor
        {
            get
            {
                return rbMale.Checked ? 0 : 1;
            }
            set
            {
                if (value == 0)
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
            }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public int NationalityCountryID
        {
            get { return (int)cbCountry.SelectedValue; }
            set { cbCountry.SelectedValue = value; }
        }

        public string ImageSavedPath
        {
            get { return ImagePath; }
            set
            {
                OldImagePath = ImagePath;
                ImagePath = value;

                DeleteOldImage();               
            }
        }


        public event Action OnSavedClicked;
        public event Action OnCloseClicked;

        public ctrlPerson()
        {
            InitializeComponent();
        }

        void DeleteOldImage()
        {
            if (!string.IsNullOrEmpty(OldImagePath))
            {
                clsManagePeople.DeleteOldImage(OldImagePath);
            }
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            cbCountry.DataSource = clsManagePeople.GetPeopleCountriesTable();
            cbCountry.ValueMember = "CountryID";
            cbCountry.DisplayMember = "CountryName";
            cbCountry.SelectedValue = _PersonCountry;

            if (pictureBox1.Image != null)
            {
                LinkLabelReomveImage.Visible = true;
            }
            else
            {
                LinkLabelReomveImage.Visible = false;
            }
        }

        private void TxtNationalNum_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNationalNum, null);
        }

        private void TxtNationalNum_Leave(object sender, EventArgs e)
        {
            string NationalNum = txtNationalNum.Text;
            if (string.IsNullOrEmpty(txtNationalNum.Text))
            {
                errorProvider1.SetError(txtNationalNum, "Required field");
            }

            if (clsManagePeople.CheckIfNationalNumberExist(NationalNum))
            {
                if (!(oldNationalNum == txtNationalNum.Text))
                    errorProvider1.SetError(txtNationalNum, "The National Number is already exist");
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;

            if (!Email.Contains("@"))
            {
                errorProvider1.SetError(txtEmail, "Invalid emaill format");
            }
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtEmail, null);
        }

        private void TxtFirstName_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "Required field");
            }
        }

        private void TxtSecondeName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondeName.Text))
            {
                errorProvider1.SetError(txtSecondeName, "Required field");
            }
        }

        private void TxtThirdName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtThirdName.Text))
            {
                errorProvider1.SetError(txtThirdName, "Required field");
            }
        }

        private void TxtLastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Required field");
            }
        }

        private void TxtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Required field");
            }
        }

        private void TxtAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "Required field");
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Select an Image";
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sourcePhoto = dlg.FileName;
                
                using (var imgTemp = Image.FromFile(dlg.FileName))
                {
                    pictureBox1.Image = new Bitmap(imgTemp);
                }
                LinkLabelReomveImage.Visible = true;
            }
        }

        void SavePhotoPath()
        {          
            ImageSavedPath = clsManagePeople.GetImagePath(sourcePhoto);
        }

        bool ValidateForm()
        {
            errorProvider1.Clear();
            bool IsValid = true;

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "Required Field");
                IsValid = false;
            }

            if (string.IsNullOrEmpty(txtSecondeName.Text))
            {
                errorProvider1.SetError(txtSecondeName, "Required Field");
                IsValid = false;
            }

            if (string.IsNullOrEmpty(txtThirdName.Text))
            {
                errorProvider1.SetError(txtThirdName, "Required Field");
                IsValid = false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Required Field");
                IsValid = false;
            }

            if (string.IsNullOrEmpty(txtNationalNum.Text))
            {
                errorProvider1.SetError(txtNationalNum, "Required Field");
                IsValid = false;
            }

           
            if (clsManagePeople.CheckIfNationalNumberExist(txtNationalNum.Text))
            {
                if (oldNationalNum == txtNationalNum.Text)
                    IsValid = true;
                else
                {
                    errorProvider1.SetError(txtNationalNum, "The National Number is already exist");
                    IsValid = false;
                }
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Required Field");
                IsValid = false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@gmail.com"))
                {
                    errorProvider1.SetError(txtEmail, "Invalid emaill format");
                    IsValid = false;
                }
            }
          
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "Required Field");
                IsValid = false;
            }
            return IsValid;
        }
       
        private void BtnSave_Click(object sender, EventArgs e)
        {                     
                if (sourcePhoto != "")
                    SavePhotoPath();

                if (!ValidateForm())
                {
                    return;
                }

             OnSavedClicked?.Invoke();

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {          
            OnCloseClicked?.Invoke();
        }

        void LoadPersonImage()
        {
            if (ImageSavedPath != "")
                try
                {
                    using (var imgTemp = Image.FromFile(ImageSavedPath))
                    {
                        pictureBox1.Image = new Bitmap(imgTemp);
                    }

                    LinkLabelReomveImage.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("الصورة غير متوفرة على الجهاز");
                }
        }

        public void ShowPersonData(clsManagePeople Person)
        {

            oldNationalNum = Person.NationalNum;

            NationalNum = Person.NationalNum;
            FirstName = Person.FirstName;
            SecondeName = Person.SecondName;
            ThirdName = Person.ThirdName;
            LastName = Person.LastName;
            DateOfBirth = Person.DateOfBirth;

            Gendor = Person.Gendor;

            Phone= Person.Phone;
            Email = Person.Email;

            _PersonCountry = Person.NationalityCountryID;

            Address = Person.Address;
            ImageSavedPath = Person.ImagePath;
            LoadPersonImage();
        }

        private void LinkLabelReomveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            clsManagePeople.DeleteOldImage(ImageSavedPath);

            sourcePhoto = "";
            ImagePath = "";
        }

        private void RbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pictureBox1.Image = Properties.Resources.images;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.Women_Image;
            }
        }
        
    }
}
