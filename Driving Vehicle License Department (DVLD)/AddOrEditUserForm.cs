using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_Vehicle_License_Department__DVLD_
{
    public partial class AddOrEditUserForm : Form
    {
        public AddOrEditUserForm()
        {
            InitializeComponent();           
        }

        private void AddOrEditUserForm_Load(object sender, EventArgs e)
        {
            ctrlFindWithFilter1.FindUseNationalNo += FindUseNatoinalNo;
            ctrlFindWithFilter1.FindUsePersonID += FindUsePersonID;
        }

        void FindUseNatoinalNo(string NationalNo)
        {
            MessageBox.Show(NationalNo);
        }

        void FindUsePersonID(int PersonID)
        {
            MessageBox.Show(PersonID.ToString());
        }
       

      
    }
}
