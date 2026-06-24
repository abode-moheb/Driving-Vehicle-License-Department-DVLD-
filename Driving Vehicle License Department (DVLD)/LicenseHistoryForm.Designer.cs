namespace Driving_Vehicle_License_Department__DVLD_
{
    partial class LicenseHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLocal = new System.Windows.Forms.TabPage();
            this.tabPageInternational = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.DataViewLocal = new System.Windows.Forms.DataGridView();
            this.lblLocalRecordeNumbers = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsInternationalNum = new System.Windows.Forms.Label();
            this.DataViewInternational = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlFindWithFilter1 = new Driving_Vehicle_License_Department__DVLD_.ctrlFindWithFilter();
            this.ctrlShowPersonDetails1 = new Driving_Vehicle_License_Department__DVLD_.ctrlShowPersonDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageLocal.SuspendLayout();
            this.tabPageInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewInternational)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(402, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 42);
            this.label1.TabIndex = 23;
            this.label1.Text = "License History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(12, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 241);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 433);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1044, 223);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver License";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(930, 662);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 33);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLocal);
            this.tabControl1.Controls.Add(this.tabPageInternational);
            this.tabControl1.Location = new System.Drawing.Point(15, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1017, 191);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLocal
            // 
            this.tabPageLocal.Controls.Add(this.lblLocalRecordeNumbers);
            this.tabPageLocal.Controls.Add(this.DataViewLocal);
            this.tabPageLocal.Controls.Add(this.label2);
            this.tabPageLocal.Controls.Add(this.label3);
            this.tabPageLocal.Location = new System.Drawing.Point(4, 22);
            this.tabPageLocal.Name = "tabPageLocal";
            this.tabPageLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLocal.Size = new System.Drawing.Size(1009, 165);
            this.tabPageLocal.TabIndex = 0;
            this.tabPageLocal.Text = "Local";
            this.tabPageLocal.UseVisualStyleBackColor = true;
            // 
            // tabPageInternational
            // 
            this.tabPageInternational.Controls.Add(this.lblRecordsInternationalNum);
            this.tabPageInternational.Controls.Add(this.DataViewInternational);
            this.tabPageInternational.Controls.Add(this.label5);
            this.tabPageInternational.Controls.Add(this.label6);
            this.tabPageInternational.Location = new System.Drawing.Point(4, 22);
            this.tabPageInternational.Name = "tabPageInternational";
            this.tabPageInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInternational.Size = new System.Drawing.Size(1009, 165);
            this.tabPageInternational.TabIndex = 1;
            this.tabPageInternational.Text = "International";
            this.tabPageInternational.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Local License History:";
            // 
            // DataViewLocal
            // 
            this.DataViewLocal.AllowUserToAddRows = false;
            this.DataViewLocal.AllowUserToDeleteRows = false;
            this.DataViewLocal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataViewLocal.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataViewLocal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataViewLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataViewLocal.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataViewLocal.Location = new System.Drawing.Point(12, 29);
            this.DataViewLocal.Name = "DataViewLocal";
            this.DataViewLocal.ReadOnly = true;
            this.DataViewLocal.Size = new System.Drawing.Size(980, 112);
            this.DataViewLocal.TabIndex = 2;
            // 
            // lblLocalRecordeNumbers
            // 
            this.lblLocalRecordeNumbers.AutoSize = true;
            this.lblLocalRecordeNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalRecordeNumbers.Location = new System.Drawing.Point(110, 144);
            this.lblLocalRecordeNumbers.Name = "lblLocalRecordeNumbers";
            this.lblLocalRecordeNumbers.Size = new System.Drawing.Size(0, 16);
            this.lblLocalRecordeNumbers.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Recorde : ";
            // 
            // lblRecordsInternationalNum
            // 
            this.lblRecordsInternationalNum.AutoSize = true;
            this.lblRecordsInternationalNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsInternationalNum.Location = new System.Drawing.Point(114, 143);
            this.lblRecordsInternationalNum.Name = "lblRecordsInternationalNum";
            this.lblRecordsInternationalNum.Size = new System.Drawing.Size(0, 16);
            this.lblRecordsInternationalNum.TabIndex = 11;
            // 
            // DataViewInternational
            // 
            this.DataViewInternational.AllowUserToAddRows = false;
            this.DataViewInternational.AllowUserToDeleteRows = false;
            this.DataViewInternational.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataViewInternational.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataViewInternational.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataViewInternational.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataViewInternational.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataViewInternational.Location = new System.Drawing.Point(16, 28);
            this.DataViewInternational.Name = "DataViewInternational";
            this.DataViewInternational.ReadOnly = true;
            this.DataViewInternational.Size = new System.Drawing.Size(980, 112);
            this.DataViewInternational.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "International License History:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "# Recorde : ";
            // 
            // ctrlFindWithFilter1
            // 
            this.ctrlFindWithFilter1.ComboBox = 0;
            this.ctrlFindWithFilter1.Enabled = false;
            this.ctrlFindWithFilter1.Location = new System.Drawing.Point(212, 71);
            this.ctrlFindWithFilter1.Name = "ctrlFindWithFilter1";
            this.ctrlFindWithFilter1.Size = new System.Drawing.Size(844, 66);
            this.ctrlFindWithFilter1.TabIndex = 26;
            this.ctrlFindWithFilter1.txtFillter = "";
            // 
            // ctrlShowPersonDetails1
            // 
            this.ctrlShowPersonDetails1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlShowPersonDetails1.Location = new System.Drawing.Point(216, 146);
            this.ctrlShowPersonDetails1.Name = "ctrlShowPersonDetails1";
            this.ctrlShowPersonDetails1.PersonID = -1;
            this.ctrlShowPersonDetails1.Size = new System.Drawing.Size(840, 271);
            this.ctrlShowPersonDetails1.TabIndex = 25;
            // 
            // LicenseHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 706);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlFindWithFilter1);
            this.Controls.Add(this.ctrlShowPersonDetails1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "LicenseHistoryForm";
            this.Text = "License History";
            this.Load += new System.EventHandler(this.LicenseHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLocal.ResumeLayout(false);
            this.tabPageLocal.PerformLayout();
            this.tabPageInternational.ResumeLayout(false);
            this.tabPageInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewInternational)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ctrlShowPersonDetails ctrlShowPersonDetails1;
        private ctrlFindWithFilter ctrlFindWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageInternational;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView DataViewLocal;
        private System.Windows.Forms.Label lblLocalRecordeNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsInternationalNum;
        private System.Windows.Forms.DataGridView DataViewInternational;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}