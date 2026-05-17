namespace Driving_Vehicle_License_Department__DVLD_
{
    partial class MainPageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDrivingLicenceServices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDetainLicence = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageApplicationTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.pepoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCurrentUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.pepoleToolStripMenuItem,
            this.drivesToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(1924, 78);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDrivingLicenceServices,
            this.tsmiManageApplications,
            this.tsmiDetainLicence,
            this.tsmiManageApplicationTypes,
            this.tsmiManageTestTypes});
            this.applicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationToolStripMenuItem.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Applications_64;
            this.applicationToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(234, 68);
            this.applicationToolStripMenuItem.Text = "Applications";
            // 
            // tsmiDrivingLicenceServices
            // 
            this.tsmiDrivingLicenceServices.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.tsmiDrivingLicenceServices.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Driver_License_48;
            this.tsmiDrivingLicenceServices.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDrivingLicenceServices.Name = "tsmiDrivingLicenceServices";
            this.tsmiDrivingLicenceServices.Size = new System.Drawing.Size(421, 70);
            this.tsmiDrivingLicenceServices.Text = "Driving Licence Services";
            // 
            // tsmiManageApplications
            // 
            this.tsmiManageApplications.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.tsmiManageApplications.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Manage_Applications_64;
            this.tsmiManageApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiManageApplications.Name = "tsmiManageApplications";
            this.tsmiManageApplications.Size = new System.Drawing.Size(421, 70);
            this.tsmiManageApplications.Text = "Manage Applications";
            // 
            // tsmiDetainLicence
            // 
            this.tsmiDetainLicence.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.tsmiDetainLicence.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Detain_64;
            this.tsmiDetainLicence.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDetainLicence.Name = "tsmiDetainLicence";
            this.tsmiDetainLicence.Size = new System.Drawing.Size(421, 70);
            this.tsmiDetainLicence.Text = "Detain Licence";
            // 
            // tsmiManageApplicationTypes
            // 
            this.tsmiManageApplicationTypes.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.tsmiManageApplicationTypes.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Application_Types_64;
            this.tsmiManageApplicationTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiManageApplicationTypes.Name = "tsmiManageApplicationTypes";
            this.tsmiManageApplicationTypes.Size = new System.Drawing.Size(421, 70);
            this.tsmiManageApplicationTypes.Text = "Manage Application Types";
            this.tsmiManageApplicationTypes.Click += new System.EventHandler(this.TsmiManageApplicationTypes_Click);
            // 
            // tsmiManageTestTypes
            // 
            this.tsmiManageTestTypes.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.tsmiManageTestTypes.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Test_Type_64;
            this.tsmiManageTestTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiManageTestTypes.Name = "tsmiManageTestTypes";
            this.tsmiManageTestTypes.Size = new System.Drawing.Size(421, 70);
            this.tsmiManageTestTypes.Text = "ManageTestTypes";
            // 
            // pepoleToolStripMenuItem
            // 
            this.pepoleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pepoleToolStripMenuItem.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.People_64;
            this.pepoleToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pepoleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pepoleToolStripMenuItem.Name = "pepoleToolStripMenuItem";
            this.pepoleToolStripMenuItem.Size = new System.Drawing.Size(168, 68);
            this.pepoleToolStripMenuItem.Text = "People";
            this.pepoleToolStripMenuItem.Click += new System.EventHandler(this.PepoleToolStripMenuItem_Click);
            // 
            // drivesToolStripMenuItem
            // 
            this.drivesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drivesToolStripMenuItem.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Drivers_64;
            this.drivesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.drivesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.drivesToolStripMenuItem.Name = "drivesToolStripMenuItem";
            this.drivesToolStripMenuItem.Size = new System.Drawing.Size(173, 68);
            this.drivesToolStripMenuItem.Text = "Drivers";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersToolStripMenuItem.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Users_2_64;
            this.usersToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(153, 68);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCurrentUser,
            this.tsmiChangePassword,
            this.tsmiSignOut});
            this.accountSettingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountSettingsToolStripMenuItem.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.account_settings_64;
            this.accountSettingsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accountSettingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(285, 68);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // tsmiCurrentUser
            // 
            this.tsmiCurrentUser.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiCurrentUser.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.PersonDetails_32;
            this.tsmiCurrentUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiCurrentUser.Name = "tsmiCurrentUser";
            this.tsmiCurrentUser.Size = new System.Drawing.Size(292, 38);
            this.tsmiCurrentUser.Text = "Current User";
            this.tsmiCurrentUser.Click += new System.EventHandler(this.TsmiCurrentUser_Click);
            // 
            // tsmiChangePassword
            // 
            this.tsmiChangePassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiChangePassword.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Password_32;
            this.tsmiChangePassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiChangePassword.Name = "tsmiChangePassword";
            this.tsmiChangePassword.Size = new System.Drawing.Size(292, 38);
            this.tsmiChangePassword.Text = "Change Password";
            this.tsmiChangePassword.Click += new System.EventHandler(this.TsmiChangePassword_Click);
            // 
            // tsmiSignOut
            // 
            this.tsmiSignOut.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiSignOut.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.sign_out_32__2;
            this.tsmiSignOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSignOut.Name = "tsmiSignOut";
            this.tsmiSignOut.Size = new System.Drawing.Size(292, 38);
            this.tsmiSignOut.Text = "Sign Out ";
            this.tsmiSignOut.Click += new System.EventHandler(this.TsmiSignOut_Click);
            // 
            // MainPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPageForm";
            this.Text = "Main page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pepoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsmiSignOut;
        private System.Windows.Forms.ToolStripMenuItem tsmiDrivingLicenceServices;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetainLicence;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageTestTypes;
    }
}

