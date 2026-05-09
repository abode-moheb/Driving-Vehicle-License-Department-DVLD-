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
    public partial class MainPageForm : Form
    {
        public MainPageForm()
        {
            InitializeComponent();
        }

        private void PepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form PeopleForm = new ManagePeopleForm();
            PeopleForm.Show();
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form UsersForm = new ManageUsersForm();
            UsersForm.Show();
        }
    }
}
