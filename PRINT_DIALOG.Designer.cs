namespace Time_Attendance
{
    partial class PRINT_DIALOG
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.cmbDep = new System.Windows.Forms.ComboBox();
            this.depBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeAttendanceDataSet = new Time_Attendance.TimeAttendanceDataSet();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.depTableAdapter = new Time_Attendance.TimeAttendanceDataSetTableAdapters.DepTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmb_permit = new System.Windows.Forms.ComboBox();
            this.pERMITIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.sTATUSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pERMITIONTableAdapter = new Time_Attendance.TimeAttendanceDataSetTableAdapters.PERMITIONTableAdapter();
            this.sTATUSTableAdapter = new Time_Attendance.TimeAttendanceDataSetTableAdapters.STATUSTableAdapter();
            this.dateTimePickerValid = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePickervalidTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.depBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeAttendanceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERMITIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTATUSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(33, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Company : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Department :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(38, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Location : ";
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Items.AddRange(new object[] {
            "Cairo",
            "Taurt",
            "Port Said"});
            this.cmbLocation.Location = new System.Drawing.Point(108, 15);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(162, 21);
            this.cmbLocation.TabIndex = 105;
            // 
            // cmbDep
            // 
            this.cmbDep.DataSource = this.depBindingSource;
            this.cmbDep.DisplayMember = "DepartmentTitle";
            this.cmbDep.FormattingEnabled = true;
            this.cmbDep.Location = new System.Drawing.Point(108, 77);
            this.cmbDep.Name = "cmbDep";
            this.cmbDep.Size = new System.Drawing.Size(162, 21);
            this.cmbDep.TabIndex = 103;
            this.cmbDep.ValueMember = "DepartmentTitle";
            // 
            // depBindingSource
            // 
            this.depBindingSource.DataMember = "Dep";
            this.depBindingSource.DataSource = this.timeAttendanceDataSet;
            // 
            // timeAttendanceDataSet
            // 
            this.timeAttendanceDataSet.DataSetName = "TimeAttendanceDataSet";
            this.timeAttendanceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbCompany
            // 
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Items.AddRange(new object[] {
            "PhPC",
            "BP",
            "IBS",
            "EPSCO"});
            this.cmbCompany.Location = new System.Drawing.Point(108, 46);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(162, 21);
            this.cmbCompany.TabIndex = 106;
            // 
            // depTableAdapter
            // 
            this.depTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 107;
            this.button1.Text = "PRINT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox1.Location = new System.Drawing.Point(108, 234);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 108;
            this.checkBox1.Text = "In Job";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 109;
            this.button2.Text = "PRINT ALL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmb_permit
            // 
            this.cmb_permit.DataSource = this.pERMITIONBindingSource;
            this.cmb_permit.DisplayMember = "PERMIT";
            this.cmb_permit.FormattingEnabled = true;
            this.cmb_permit.Location = new System.Drawing.Point(108, 109);
            this.cmb_permit.Name = "cmb_permit";
            this.cmb_permit.Size = new System.Drawing.Size(162, 21);
            this.cmb_permit.TabIndex = 110;
            this.cmb_permit.ValueMember = "PERMIT";
            this.cmb_permit.SelectedIndexChanged += new System.EventHandler(this.cmb_permit_SelectedIndexChanged);
            // 
            // pERMITIONBindingSource
            // 
            this.pERMITIONBindingSource.DataMember = "PERMITION";
            this.pERMITIONBindingSource.DataSource = this.timeAttendanceDataSet;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(57, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 113;
            this.label9.Text = "Permit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(58, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 112;
            this.label7.Text = "Status";
            // 
            // cmb_status
            // 
            this.cmb_status.DataSource = this.sTATUSBindingSource;
            this.cmb_status.DisplayMember = "STATUS_NAME";
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Location = new System.Drawing.Point(108, 199);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(162, 21);
            this.cmb_status.TabIndex = 111;
            this.cmb_status.ValueMember = "STATUS_NAME";
            // 
            // sTATUSBindingSource
            // 
            this.sTATUSBindingSource.DataMember = "STATUS";
            this.sTATUSBindingSource.DataSource = this.timeAttendanceDataSet;
            // 
            // pERMITIONTableAdapter
            // 
            this.pERMITIONTableAdapter.ClearBeforeFill = true;
            // 
            // sTATUSTableAdapter
            // 
            this.sTATUSTableAdapter.ClearBeforeFill = true;
            // 
            // dateTimePickerValid
            // 
            this.dateTimePickerValid.Enabled = false;
            this.dateTimePickerValid.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerValid.Location = new System.Drawing.Point(108, 138);
            this.dateTimePickerValid.Name = "dateTimePickerValid";
            this.dateTimePickerValid.Size = new System.Drawing.Size(162, 20);
            this.dateTimePickerValid.TabIndex = 115;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(16, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 114;
            this.label13.Text = "Valid Between";
            // 
            // dateTimePickervalidTo
            // 
            this.dateTimePickervalidTo.Enabled = false;
            this.dateTimePickervalidTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickervalidTo.Location = new System.Drawing.Point(108, 169);
            this.dateTimePickervalidTo.Name = "dateTimePickervalidTo";
            this.dateTimePickervalidTo.Size = new System.Drawing.Size(162, 20);
            this.dateTimePickervalidTo.TabIndex = 117;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(74, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 116;
            this.label4.Text = "and";
            // 
            // PRINT_DIALOG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 296);
            this.Controls.Add(this.dateTimePickervalidTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerValid);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_status);
            this.Controls.Add(this.cmb_permit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.cmbDep);
            this.Controls.Add(this.cmbCompany);
            this.Name = "PRINT_DIALOG";
            this.Text = "PRINT_DIALOG";
            this.Load += new System.EventHandler(this.PRINT_DIALOG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.depBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeAttendanceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERMITIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTATUSBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.ComboBox cmbDep;
        private System.Windows.Forms.ComboBox cmbCompany;
        private TimeAttendanceDataSet timeAttendanceDataSet;
        private System.Windows.Forms.BindingSource depBindingSource;
        private Time_Attendance.TimeAttendanceDataSetTableAdapters.DepTableAdapter depTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmb_permit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.BindingSource pERMITIONBindingSource;
        private Time_Attendance.TimeAttendanceDataSetTableAdapters.PERMITIONTableAdapter pERMITIONTableAdapter;
        private System.Windows.Forms.BindingSource sTATUSBindingSource;
        private Time_Attendance.TimeAttendanceDataSetTableAdapters.STATUSTableAdapter sTATUSTableAdapter;
        private System.Windows.Forms.DateTimePicker dateTimePickerValid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePickervalidTo;
        private System.Windows.Forms.Label label4;
    }
}