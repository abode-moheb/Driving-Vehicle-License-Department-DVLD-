namespace Driving_Vehicle_License_Department__DVLD_
{
    partial class ManageLocalDrivingLicenseApplicationForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilterby = new System.Windows.Forms.TextBox();
            this.lblRecordeNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowAppDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSechduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSechduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSechduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSechduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterby
            // 
            this.txtFilterby.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterby.Location = new System.Drawing.Point(302, 251);
            this.txtFilterby.Name = "txtFilterby";
            this.txtFilterby.Size = new System.Drawing.Size(196, 22);
            this.txtFilterby.TabIndex = 31;
            this.txtFilterby.TextChanged += new System.EventHandler(this.TxtFilterby_TextChanged_1);
            this.txtFilterby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFilterby_KeyPress_1);
            // 
            // lblRecordeNumber
            // 
            this.lblRecordeNumber.AutoSize = true;
            this.lblRecordeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordeNumber.Location = new System.Drawing.Point(111, 658);
            this.lblRecordeNumber.Name = "lblRecordeNumber";
            this.lblRecordeNumber.Size = new System.Drawing.Size(0, 20);
            this.lblRecordeNumber.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 658);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "# Recorde : ";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "L.D.LAppID",
            "National No.",
            "Full Name",
            "Status"});
            this.comboBox1.Location = new System.Drawing.Point(94, 251);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 24);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Filter By :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowAppDetails,
            this.toolStripSeparator1,
            this.tsmiEditApp,
            this.tsmiDeleteApp,
            this.tsmiCancelApp,
            this.toolStripSeparator5,
            this.tsmiSechduleTests,
            this.toolStripSeparator2,
            this.tsmiIssueDrivingLicense,
            this.toolStripSeparator3,
            this.tsmiShowLicense,
            this.toolStripSeparator4,
            this.tsmiShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(259, 360);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // tsmiShowAppDetails
            // 
            this.tsmiShowAppDetails.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.PersonDetails_32;
            this.tsmiShowAppDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowAppDetails.Name = "tsmiShowAppDetails";
            this.tsmiShowAppDetails.Size = new System.Drawing.Size(258, 38);
            this.tsmiShowAppDetails.Text = "Show Application Details";
            this.tsmiShowAppDetails.Click += new System.EventHandler(this.TsmiShowAppDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(255, 6);
            // 
            // tsmiEditApp
            // 
            this.tsmiEditApp.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.edit_32;
            this.tsmiEditApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiEditApp.Name = "tsmiEditApp";
            this.tsmiEditApp.Size = new System.Drawing.Size(258, 38);
            this.tsmiEditApp.Text = "Edit Application";
            this.tsmiEditApp.Click += new System.EventHandler(this.TsmiEditApp_Click);
            // 
            // tsmiDeleteApp
            // 
            this.tsmiDeleteApp.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Delete_32_2;
            this.tsmiDeleteApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDeleteApp.Name = "tsmiDeleteApp";
            this.tsmiDeleteApp.Size = new System.Drawing.Size(258, 38);
            this.tsmiDeleteApp.Text = "Delete Application";
            this.tsmiDeleteApp.Click += new System.EventHandler(this.TsmiDeleteApp_Click);
            // 
            // tsmiCancelApp
            // 
            this.tsmiCancelApp.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Delete_32;
            this.tsmiCancelApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiCancelApp.Name = "tsmiCancelApp";
            this.tsmiCancelApp.Size = new System.Drawing.Size(258, 38);
            this.tsmiCancelApp.Text = "Cancel Application";
            this.tsmiCancelApp.Click += new System.EventHandler(this.TsmiCancelApp_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(255, 6);
            // 
            // tsmiSechduleTests
            // 
            this.tsmiSechduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSechduleVisionTest,
            this.tsmiSechduleWrittenTest,
            this.tsmiSechduleStreetTest});
            this.tsmiSechduleTests.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.TestType_32;
            this.tsmiSechduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSechduleTests.Name = "tsmiSechduleTests";
            this.tsmiSechduleTests.Size = new System.Drawing.Size(258, 38);
            this.tsmiSechduleTests.Text = "Sechdule Tests";
            // 
            // tsmiSechduleVisionTest
            // 
            this.tsmiSechduleVisionTest.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Vision_Test_32;
            this.tsmiSechduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSechduleVisionTest.Name = "tsmiSechduleVisionTest";
            this.tsmiSechduleVisionTest.Size = new System.Drawing.Size(203, 38);
            this.tsmiSechduleVisionTest.Text = "Sechdule Vision Test";
            this.tsmiSechduleVisionTest.Click += new System.EventHandler(this.TsmiSechduleVisionTest_Click);
            // 
            // tsmiSechduleWrittenTest
            // 
            this.tsmiSechduleWrittenTest.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Written_Test_32;
            this.tsmiSechduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSechduleWrittenTest.Name = "tsmiSechduleWrittenTest";
            this.tsmiSechduleWrittenTest.Size = new System.Drawing.Size(203, 38);
            this.tsmiSechduleWrittenTest.Text = "Sechdule Written Test";
            this.tsmiSechduleWrittenTest.Click += new System.EventHandler(this.TsmiSechduleWrittenTest_Click);
            // 
            // tsmiSechduleStreetTest
            // 
            this.tsmiSechduleStreetTest.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Street_Test_32;
            this.tsmiSechduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSechduleStreetTest.Name = "tsmiSechduleStreetTest";
            this.tsmiSechduleStreetTest.Size = new System.Drawing.Size(203, 38);
            this.tsmiSechduleStreetTest.Text = "Sechdule Street Test";
            this.tsmiSechduleStreetTest.Click += new System.EventHandler(this.TsmiSechduleStreetTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(255, 6);
            // 
            // tsmiIssueDrivingLicense
            // 
            this.tsmiIssueDrivingLicense.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.IssueDrivingLicense_32;
            this.tsmiIssueDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiIssueDrivingLicense.Name = "tsmiIssueDrivingLicense";
            this.tsmiIssueDrivingLicense.Size = new System.Drawing.Size(258, 38);
            this.tsmiIssueDrivingLicense.Text = "Issue Driving License(First Time)";
            this.tsmiIssueDrivingLicense.Click += new System.EventHandler(this.TsmiIssueDrivingLicense_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(255, 6);
            // 
            // tsmiShowLicense
            // 
            this.tsmiShowLicense.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.LocalDriving_License;
            this.tsmiShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowLicense.Name = "tsmiShowLicense";
            this.tsmiShowLicense.Size = new System.Drawing.Size(258, 38);
            this.tsmiShowLicense.Text = "Show License";
            this.tsmiShowLicense.Click += new System.EventHandler(this.TsmiShowLicense_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(255, 6);
            // 
            // tsmiShowPersonLicenseHistory
            // 
            this.tsmiShowPersonLicenseHistory.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.PersonLicenseHistory_32;
            this.tsmiShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(258, 38);
            this.tsmiShowPersonLicenseHistory.Text = "Person License History";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(14, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1460, 361);
            this.dataGridView1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(476, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(567, 42);
            this.label1.TabIndex = 23;
            this.label1.Text = "Local Driving License Application";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(824, 87);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 59);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(578, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1348, 652);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 33);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.New_Application_64;
            this.btnAdd.Location = new System.Drawing.Point(1368, 201);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 71);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // ManageLocalDrivingLicenseApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 698);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFilterby);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblRecordeNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "ManageLocalDrivingLicenseApplicationForm";
            this.Text = "Manage Local Driving License Application";
            this.Load += new System.EventHandler(this.ManageLocalDrivingLicenseApplicationForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFilterby;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblRecordeNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleTests;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteApp;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditApp;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowAppDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelApp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem tsmiIssueDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleStreetTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}