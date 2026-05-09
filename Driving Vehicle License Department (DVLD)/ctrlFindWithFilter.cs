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
    public partial class ctrlFindWithFilter : UserControl
    {
        public ctrlFindWithFilter()
        {
            InitializeComponent();            
        }

        public event Action<string> FindUseNationalNo;
        public event Action<int> FindUsePersonID;

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            switch (index)
            {
                case 0:
                    FindUseNationalNo?.Invoke(txtFillterBox.Text);
                    break;

                case 1:
                    int.TryParse((txtFillterBox.Text), out int PersonID);
                    FindUsePersonID?.Invoke(PersonID);
                    break;

                default:
                    break;
            }
        }

        private void TxtFillterBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }           
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFillterBox.Text = "";
        }

        private void CtrlFindWithFilter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
