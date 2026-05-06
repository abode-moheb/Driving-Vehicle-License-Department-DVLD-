namespace Driving_Vehicle_License_Department__DVLD_
{
    partial class AddOrEditPersonForm
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
            this.ctrlPerson1 = new Driving_Vehicle_License_Department__DVLD_.ctrlPerson();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlPerson1
            // 
            this.ctrlPerson1.Location = new System.Drawing.Point(-12, 100);
            this.ctrlPerson1.Name = "ctrlPerson1";
            this.ctrlPerson1.Size = new System.Drawing.Size(828, 362);
            this.ctrlPerson1.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(298, 31);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(217, 31);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Add New Person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "PersonID :";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(168, 100);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(34, 16);
            this.lblPersonID.TabIndex = 3;
            this.lblPersonID.Text = "N/A";
            // 
            // AddOrEditPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 470);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.ctrlPerson1);
            this.Name = "AddOrEditPersonForm";
            this.Text = "AddOrEditPersonForm";
            this.Load += new System.EventHandler(this.AddOrEditPersonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPerson ctrlPerson1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPersonID;
    }
}