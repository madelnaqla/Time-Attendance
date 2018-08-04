namespace Time_Attendance
{
    partial class ADD_LOG
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
            this.depBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeAttendanceDataSet = new Time_Attendance.TimeAttendanceDataSet();
            this.depTableAdapter = new Time_Attendance.TimeAttendanceDataSetTableAdapters.DepTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.pERMITIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmb_machine = new System.Windows.Forms.ComboBox();
            this.sTATUSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pERMITIONTableAdapter = new Time_Attendance.TimeAttendanceDataSetTableAdapters.PERMITIONTableAdapter();
            this.sTATUSTableAdapter = new Time_Attendance.TimeAttendanceDataSetTableAdapters.STATUSTableAdapter();
            this.dateTimePickerValid = new System.Windows.Forms.DateTimePicker();
            this.TXT_EMP_NO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfromTime = new System.Windows.Forms.MaskedTextBox();
            this.radioButtonIn = new System.Windows.Forms.RadioButton();
            this.radioButtonOut = new System.Windows.Forms.RadioButton();
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
            this.label3.Location = new System.Drawing.Point(58, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(41, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Machine :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Employee No : ";
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
            // depTableAdapter
            // 
            this.depTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 107;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pERMITIONBindingSource
            // 
            this.pERMITIONBindingSource.DataMember = "PERMITION";
            this.pERMITIONBindingSource.DataSource = this.timeAttendanceDataSet;
            // 
            // cmb_machine
            // 
            this.cmb_machine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_machine.FormattingEnabled = true;
            this.cmb_machine.Items.AddRange(new object[] {
            "in",
            "out",
            "new in",
            "new out",
            "main in",
            "main out",
            "process in",
            "process out",
            "",
            ""});
            this.cmb_machine.Location = new System.Drawing.Point(108, 104);
            this.cmb_machine.Name = "cmb_machine";
            this.cmb_machine.Size = new System.Drawing.Size(162, 21);
            this.cmb_machine.TabIndex = 111;
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
            this.dateTimePickerValid.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerValid.Location = new System.Drawing.Point(108, 49);
            this.dateTimePickerValid.Name = "dateTimePickerValid";
            this.dateTimePickerValid.Size = new System.Drawing.Size(162, 20);
            this.dateTimePickerValid.TabIndex = 115;
            // 
            // TXT_EMP_NO
            // 
            this.TXT_EMP_NO.Location = new System.Drawing.Point(108, 17);
            this.TXT_EMP_NO.Name = "TXT_EMP_NO";
            this.TXT_EMP_NO.Size = new System.Drawing.Size(162, 20);
            this.TXT_EMP_NO.TabIndex = 118;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(57, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "Time : ";
            // 
            // txtfromTime
            // 
            this.txtfromTime.Location = new System.Drawing.Point(108, 77);
            this.txtfromTime.Mask = "00:00";
            this.txtfromTime.Name = "txtfromTime";
            this.txtfromTime.Size = new System.Drawing.Size(34, 20);
            this.txtfromTime.TabIndex = 120;
            this.txtfromTime.Text = "0000";
            this.txtfromTime.ValidatingType = typeof(System.DateTime);
            // 
            // radioButtonIn
            // 
            this.radioButtonIn.AutoSize = true;
            this.radioButtonIn.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIn.Checked = true;
            this.radioButtonIn.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.radioButtonIn.Location = new System.Drawing.Point(108, 131);
            this.radioButtonIn.Name = "radioButtonIn";
            this.radioButtonIn.Size = new System.Drawing.Size(37, 17);
            this.radioButtonIn.TabIndex = 121;
            this.radioButtonIn.TabStop = true;
            this.radioButtonIn.Text = "In";
            this.radioButtonIn.UseVisualStyleBackColor = false;
            // 
            // radioButtonOut
            // 
            this.radioButtonOut.AutoSize = true;
            this.radioButtonOut.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonOut.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.radioButtonOut.Location = new System.Drawing.Point(160, 131);
            this.radioButtonOut.Name = "radioButtonOut";
            this.radioButtonOut.Size = new System.Drawing.Size(45, 17);
            this.radioButtonOut.TabIndex = 122;
            this.radioButtonOut.Text = "Out";
            this.radioButtonOut.UseVisualStyleBackColor = false;
            // 
            // ADD_LOG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 189);
            this.Controls.Add(this.radioButtonIn);
            this.Controls.Add(this.radioButtonOut);
            this.Controls.Add(this.txtfromTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXT_EMP_NO);
            this.Controls.Add(this.dateTimePickerValid);
            this.Controls.Add(this.cmb_machine);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ADD_LOG";
            this.Text = "Add Log";
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
        private TimeAttendanceDataSet timeAttendanceDataSet;
        private System.Windows.Forms.BindingSource depBindingSource;
        private Time_Attendance.TimeAttendanceDataSetTableAdapters.DepTableAdapter depTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_machine;
        private System.Windows.Forms.BindingSource pERMITIONBindingSource;
        private Time_Attendance.TimeAttendanceDataSetTableAdapters.PERMITIONTableAdapter pERMITIONTableAdapter;
        private System.Windows.Forms.BindingSource sTATUSBindingSource;
        private Time_Attendance.TimeAttendanceDataSetTableAdapters.STATUSTableAdapter sTATUSTableAdapter;
        private System.Windows.Forms.DateTimePicker dateTimePickerValid;
        private System.Windows.Forms.TextBox TXT_EMP_NO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtfromTime;
        private System.Windows.Forms.RadioButton radioButtonIn;
        private System.Windows.Forms.RadioButton radioButtonOut;
    }
}