namespace Kortakerfi
{
    partial class RecordPayment
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
            this.txtbox_passesRemaining = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lbl_dueDate = new System.Windows.Forms.Label();
            this.cb_membershipType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_recordPayment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbox_passesRemaining
            // 
            this.txtbox_passesRemaining.Enabled = false;
            this.txtbox_passesRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_passesRemaining.Location = new System.Drawing.Point(200, 129);
            this.txtbox_passesRemaining.Name = "txtbox_passesRemaining";
            this.txtbox_passesRemaining.Size = new System.Drawing.Size(227, 26);
            this.txtbox_passesRemaining.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Passes Remaining";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(200, 83);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(227, 26);
            this.dateTimePicker.TabIndex = 32;
            // 
            // lbl_dueDate
            // 
            this.lbl_dueDate.AutoSize = true;
            this.lbl_dueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dueDate.Location = new System.Drawing.Point(30, 88);
            this.lbl_dueDate.Name = "lbl_dueDate";
            this.lbl_dueDate.Size = new System.Drawing.Size(78, 20);
            this.lbl_dueDate.TabIndex = 31;
            this.lbl_dueDate.Text = "Due Date";
            // 
            // cb_membershipType
            // 
            this.cb_membershipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_membershipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_membershipType.FormattingEnabled = true;
            this.cb_membershipType.Items.AddRange(new object[] {
            "10 Time Card",
            "1 Month",
            "3 Months",
            "6 Months",
            "1 Year"});
            this.cb_membershipType.Location = new System.Drawing.Point(200, 34);
            this.cb_membershipType.Name = "cb_membershipType";
            this.cb_membershipType.Size = new System.Drawing.Size(227, 28);
            this.cb_membershipType.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Membership Type";
            // 
            // btn_recordPayment
            // 
            this.btn_recordPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_recordPayment.Location = new System.Drawing.Point(262, 174);
            this.btn_recordPayment.Name = "btn_recordPayment";
            this.btn_recordPayment.Size = new System.Drawing.Size(165, 31);
            this.btn_recordPayment.TabIndex = 35;
            this.btn_recordPayment.Text = "Record Payment";
            this.btn_recordPayment.UseVisualStyleBackColor = true;
            // 
            // RecordPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 235);
            this.Controls.Add(this.btn_recordPayment);
            this.Controls.Add(this.txtbox_passesRemaining);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.lbl_dueDate);
            this.Controls.Add(this.cb_membershipType);
            this.Controls.Add(this.label5);
            this.Name = "RecordPayment";
            this.Text = "Record Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_passesRemaining;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lbl_dueDate;
        private System.Windows.Forms.ComboBox cb_membershipType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_recordPayment;
    }
}