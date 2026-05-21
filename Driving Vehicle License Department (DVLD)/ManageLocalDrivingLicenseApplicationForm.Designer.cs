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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilterby = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordeNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSendMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.tsmiShowDetails,
            this.tsmiAddNewPerson,
            this.tsmiEdit,
            this.tsmiDelete,
            this.tsmiSendMessage,
            this.tsmiPhoneCall});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 232);
            // 
            // tsmiShowDetails
            // 
            this.tsmiShowDetails.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.PersonDetails_32;
            this.tsmiShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowDetails.Name = "tsmiShowDetails";
            this.tsmiShowDetails.Size = new System.Drawing.Size(176, 38);
            this.tsmiShowDetails.Text = "Show Details";
            // 
            // tsmiAddNewPerson
            // 
            this.tsmiAddNewPerson.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.AddPerson_32;
            this.tsmiAddNewPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiAddNewPerson.Name = "tsmiAddNewPerson";
            this.tsmiAddNewPerson.Size = new System.Drawing.Size(176, 38);
            this.tsmiAddNewPerson.Text = "Add new person";
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.edit_32;
            this.tsmiEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(176, 38);
            this.tsmiEdit.Text = "Edit";
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.Delete_32;
            this.tsmiDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(176, 38);
            this.tsmiDelete.Text = "Delete";
            // 
            // tsmiSendMessage
            // 
            this.tsmiSendMessage.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.send_email_32;
            this.tsmiSendMessage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSendMessage.Name = "tsmiSendMessage";
            this.tsmiSendMessage.Size = new System.Drawing.Size(176, 38);
            this.tsmiSendMessage.Text = "Send message";
            // 
            // tsmiPhoneCall
            // 
            this.tsmiPhoneCall.Image = global::Driving_Vehicle_License_Department__DVLD_.Properties.Resources.call_32;
            this.tsmiPhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiPhoneCall.Name = "tsmiPhoneCall";
            this.tsmiPhoneCall.Size = new System.Drawing.Size(176, 38);
            this.tsmiPhoneCall.Text = "Phone Call";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
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
        private System.Windows.Forms.ToolStripMenuItem tsmiPhoneCall;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSendMessage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}