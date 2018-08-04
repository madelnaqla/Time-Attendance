namespace Time_Attendance
{
    partial class FrmNowIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNowIN));
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.BtnPrintPreview = new EnhancedGlassButton.GlassButton();
            this.btnExit = new EnhancedGlassButton.GlassButton();
            this.grpMain = new Infragistics.Win.Misc.UltraGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToTime = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.rbut_OUT = new System.Windows.Forms.RadioButton();
            this.rbut_find_abs = new System.Windows.Forms.RadioButton();
            this.rbut_find_att = new System.Windows.Forms.RadioButton();
            this.rbut_find_out = new System.Windows.Forms.RadioButton();
            this.rbut_find_in = new System.Windows.Forms.RadioButton();
            this.clb_location = new System.Windows.Forms.CheckedListBox();
            this.clb_company = new System.Windows.Forms.CheckedListBox();
            this.ch1 = new System.Windows.Forms.CheckBox();
            this.clbDep = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.depBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeAttendanceDataSet = new Time_Attendance.TimeAttendanceDataSet();
            this.depTableAdapter = new Time_Attendance.TimeAttendanceDataSetTableAdapters.DepTableAdapter();
            this.TXT_TIME = new System.Windows.Forms.MaskedTextBox();
            this.txt_num = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.check_number = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.check_name = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeAttendanceDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox1.Controls.Add(this.BtnPrintPreview);
            this.ultraGroupBox1.Controls.Add(this.btnExit);
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 409);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1016, 43);
            this.ultraGroupBox1.TabIndex = 27;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // BtnPrintPreview
            // 
            this.BtnPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnPrintPreview.AnimateGlow = true;
            this.BtnPrintPreview.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BtnPrintPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BtnPrintPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BtnPrintPreview.GlowColor = System.Drawing.Color.AliceBlue;
            this.BtnPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrintPreview.Image")));
            this.BtnPrintPreview.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.BtnPrintPreview.Location = new System.Drawing.Point(619, 10);
            this.BtnPrintPreview.Name = "BtnPrintPreview";
            this.BtnPrintPreview.Size = new System.Drawing.Size(72, 24);
            this.BtnPrintPreview.TabIndex = 17;
            this.BtnPrintPreview.Text = "print";
            this.BtnPrintPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnPrintPreview.Click += new System.EventHandler(this.BtnPrintPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.AnimateGlow = true;
            this.btnExit.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnExit.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnExit.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnExit.Location = new System.Drawing.Point(697, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 24);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Close";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grpMain
            // 
            this.grpMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMain.Controls.Add(this.txt_num);
            this.grpMain.Controls.Add(this.txt_name);
            this.grpMain.Controls.Add(this.label9);
            this.grpMain.Controls.Add(this.check_number);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.check_name);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Controls.Add(this.txtToTime);
            this.grpMain.Controls.Add(this.label1);
            this.grpMain.Controls.Add(this.label4);
            this.grpMain.Controls.Add(this.dtpDateFrom);
            this.grpMain.Controls.Add(this.label6);
            this.grpMain.Controls.Add(this.dtpDateTo);
            this.grpMain.Controls.Add(this.rbut_OUT);
            this.grpMain.Controls.Add(this.rbut_find_abs);
            this.grpMain.Controls.Add(this.rbut_find_att);
            this.grpMain.Controls.Add(this.rbut_find_out);
            this.grpMain.Controls.Add(this.rbut_find_in);
            this.grpMain.Controls.Add(this.clb_location);
            this.grpMain.Controls.Add(this.clb_company);
            this.grpMain.Controls.Add(this.ch1);
            this.grpMain.Controls.Add(this.clbDep);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.label8);
            this.grpMain.Controls.Add(this.btnFind);
            this.grpMain.Location = new System.Drawing.Point(3, 4);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(1009, 181);
            this.grpMain.TabIndex = 24;
            this.grpMain.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(869, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 130;
            this.label2.Text = "Time";
            // 
            // txtToTime
            // 
            this.txtToTime.Enabled = false;
            this.txtToTime.Location = new System.Drawing.Point(913, 130);
            this.txtToTime.Mask = "00:00";
            this.txtToTime.Name = "txtToTime";
            this.txtToTime.Size = new System.Drawing.Size(34, 20);
            this.txtToTime.TabIndex = 129;
            this.txtToTime.Text = "1500";
            this.txtToTime.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(854, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 128;
            this.label1.Text = "Time To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(666, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "To";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Enabled = false;
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(503, 153);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.RightToLeftLayout = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(157, 20);
            this.dtpDateFrom.TabIndex = 124;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(431, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 126;
            this.label6.Text = "Date From";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Enabled = false;
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(693, 153);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.RightToLeftLayout = true;
            this.dtpDateTo.Size = new System.Drawing.Size(157, 20);
            this.dtpDateTo.TabIndex = 125;
            // 
            // rbut_OUT
            // 
            this.rbut_OUT.AutoSize = true;
            this.rbut_OUT.BackColor = System.Drawing.Color.Transparent;
            this.rbut_OUT.Location = new System.Drawing.Point(841, 112);
            this.rbut_OUT.Name = "rbut_OUT";
            this.rbut_OUT.Size = new System.Drawing.Size(43, 17);
            this.rbut_OUT.TabIndex = 123;
            this.rbut_OUT.Text = "Out";
            this.rbut_OUT.UseVisualStyleBackColor = false;
            this.rbut_OUT.CheckedChanged += new System.EventHandler(this.rbut_OUT_CheckedChanged);
            // 
            // rbut_find_abs
            // 
            this.rbut_find_abs.AutoSize = true;
            this.rbut_find_abs.BackColor = System.Drawing.Color.Transparent;
            this.rbut_find_abs.Location = new System.Drawing.Point(841, 88);
            this.rbut_find_abs.Name = "rbut_find_abs";
            this.rbut_find_abs.Size = new System.Drawing.Size(66, 17);
            this.rbut_find_abs.TabIndex = 122;
            this.rbut_find_abs.Text = "Absence";
            this.rbut_find_abs.UseVisualStyleBackColor = false;
            // 
            // rbut_find_att
            // 
            this.rbut_find_att.AutoSize = true;
            this.rbut_find_att.BackColor = System.Drawing.Color.Transparent;
            this.rbut_find_att.Location = new System.Drawing.Point(841, 64);
            this.rbut_find_att.Name = "rbut_find_att";
            this.rbut_find_att.Size = new System.Drawing.Size(81, 17);
            this.rbut_find_att.TabIndex = 121;
            this.rbut_find_att.Text = "Attendance";
            this.rbut_find_att.UseVisualStyleBackColor = false;
            // 
            // rbut_find_out
            // 
            this.rbut_find_out.AutoSize = true;
            this.rbut_find_out.BackColor = System.Drawing.Color.Transparent;
            this.rbut_find_out.Location = new System.Drawing.Point(841, 42);
            this.rbut_find_out.Name = "rbut_find_out";
            this.rbut_find_out.Size = new System.Drawing.Size(66, 17);
            this.rbut_find_out.TabIndex = 120;
            this.rbut_find_out.Text = "Find Out";
            this.rbut_find_out.UseVisualStyleBackColor = false;
            // 
            // rbut_find_in
            // 
            this.rbut_find_in.AutoSize = true;
            this.rbut_find_in.BackColor = System.Drawing.Color.Transparent;
            this.rbut_find_in.Checked = true;
            this.rbut_find_in.Location = new System.Drawing.Point(841, 19);
            this.rbut_find_in.Name = "rbut_find_in";
            this.rbut_find_in.Size = new System.Drawing.Size(58, 17);
            this.rbut_find_in.TabIndex = 119;
            this.rbut_find_in.TabStop = true;
            this.rbut_find_in.Text = "Find In";
            this.rbut_find_in.UseVisualStyleBackColor = false;
            // 
            // clb_location
            // 
            this.clb_location.CheckOnClick = true;
            this.clb_location.FormattingEnabled = true;
            this.clb_location.Items.AddRange(new object[] {
            "Cairo",
            "Port Said"});
            this.clb_location.Location = new System.Drawing.Point(336, 17);
            this.clb_location.Name = "clb_location";
            this.clb_location.ScrollAlwaysVisible = true;
            this.clb_location.Size = new System.Drawing.Size(166, 79);
            this.clb_location.Sorted = true;
            this.clb_location.TabIndex = 115;
            this.clb_location.ThreeDCheckBoxes = true;
            // 
            // clb_company
            // 
            this.clb_company.CheckOnClick = true;
            this.clb_company.FormattingEnabled = true;
            this.clb_company.Items.AddRange(new object[] {
            "BP",
            "EPSCO",
            "IBS",
            "Other..",
            "PhPC"});
            this.clb_company.Location = new System.Drawing.Point(76, 17);
            this.clb_company.Name = "clb_company";
            this.clb_company.ScrollAlwaysVisible = true;
            this.clb_company.Size = new System.Drawing.Size(166, 79);
            this.clb_company.Sorted = true;
            this.clb_company.TabIndex = 114;
            this.clb_company.ThreeDCheckBoxes = true;
            // 
            // ch1
            // 
            this.ch1.AutoSize = true;
            this.ch1.BackColor = System.Drawing.Color.Transparent;
            this.ch1.Location = new System.Drawing.Point(515, 20);
            this.ch1.Name = "ch1";
            this.ch1.Size = new System.Drawing.Size(15, 14);
            this.ch1.TabIndex = 113;
            this.ch1.UseVisualStyleBackColor = false;
            this.ch1.CheckedChanged += new System.EventHandler(this.ch1_CheckedChanged);
            // 
            // clbDep
            // 
            this.clbDep.CheckOnClick = true;
            this.clbDep.FormattingEnabled = true;
            this.clbDep.Location = new System.Drawing.Point(537, 17);
            this.clbDep.Name = "clbDep";
            this.clbDep.ScrollAlwaysVisible = true;
            this.clbDep.Size = new System.Drawing.Size(287, 79);
            this.clbDep.Sorted = true;
            this.clbDep.TabIndex = 112;
            this.clbDep.ThreeDCheckBoxes = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Company : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(266, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 107;
            this.label8.Text = "Location : ";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(509, 112);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 97;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Appearance = appearance7;
            this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance8;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.FontData.BoldAsString = "True";
            appearance9.FontData.Name = "Arial";
            appearance9.FontData.SizeInPoints = 10F;
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.White;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.GlassTop50;
            appearance10.BackHatchStyle = Infragistics.Win.BackHatchStyle.ForwardDiagonal;
            this.ultraGrid1.DisplayLayout.Override.RowAlternateAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid1.Location = new System.Drawing.Point(3, 191);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1009, 213);
            this.ultraGrid1.TabIndex = 10;
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
            // TXT_TIME
            // 
            this.TXT_TIME.Enabled = false;
            this.TXT_TIME.Location = new System.Drawing.Point(916, 159);
            this.TXT_TIME.Mask = "00:00";
            this.TXT_TIME.Name = "TXT_TIME";
            this.TXT_TIME.Size = new System.Drawing.Size(34, 20);
            this.TXT_TIME.TabIndex = 130;
            this.TXT_TIME.Text = "0100";
            this.TXT_TIME.ValidatingType = typeof(System.DateTime);
            // 
            // txt_num
            // 
            this.txt_num.Enabled = false;
            this.txt_num.Location = new System.Drawing.Point(175, 139);
            this.txt_num.Name = "txt_num";
            this.txt_num.Size = new System.Drawing.Size(120, 20);
            this.txt_num.TabIndex = 136;
            // 
            // txt_name
            // 
            this.txt_name.Enabled = false;
            this.txt_name.Location = new System.Drawing.Point(175, 112);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(120, 20);
            this.txt_name.TabIndex = 135;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(96, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 133;
            this.label9.Text = "By Number";
            // 
            // check_number
            // 
            this.check_number.AutoSize = true;
            this.check_number.BackColor = System.Drawing.Color.Transparent;
            this.check_number.Location = new System.Drawing.Point(78, 142);
            this.check_number.Name = "check_number";
            this.check_number.Size = new System.Drawing.Size(15, 14);
            this.check_number.TabIndex = 134;
            this.check_number.UseVisualStyleBackColor = false;
            this.check_number.CheckedChanged += new System.EventHandler(this.check_number_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(96, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 131;
            this.label3.Text = "By Name";
            // 
            // check_name
            // 
            this.check_name.AutoSize = true;
            this.check_name.BackColor = System.Drawing.Color.Transparent;
            this.check_name.Location = new System.Drawing.Point(78, 115);
            this.check_name.Name = "check_name";
            this.check_name.Size = new System.Drawing.Size(15, 14);
            this.check_name.TabIndex = 132;
            this.check_name.UseVisualStyleBackColor = false;
            this.check_name.CheckedChanged += new System.EventHandler(this.check_name_CheckedChanged);
            // 
            // FrmNowIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1016, 452);
            this.Controls.Add(this.TXT_TIME);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.ultraGrid1);
            this.Name = "FrmNowIN";
            this.Text = "Now In";
            this.Load += new System.EventHandler(this.FrmEmpTrans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeAttendanceDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraGroupBox grpMain;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private EnhancedGlassButton.GlassButton btnExit;
        private EnhancedGlassButton.GlassButton BtnPrintPreview;
        private TimeAttendanceDataSet timeAttendanceDataSet;
        private System.Windows.Forms.BindingSource depBindingSource;
        private Time_Attendance.TimeAttendanceDataSetTableAdapters.DepTableAdapter depTableAdapter;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ch1;
        private System.Windows.Forms.CheckedListBox clbDep;
        private System.Windows.Forms.CheckedListBox clb_company;
        private System.Windows.Forms.CheckedListBox clb_location;
        private System.Windows.Forms.RadioButton rbut_find_abs;
        private System.Windows.Forms.RadioButton rbut_find_att;
        private System.Windows.Forms.RadioButton rbut_find_out;
        private System.Windows.Forms.RadioButton rbut_find_in;
        private System.Windows.Forms.RadioButton rbut_OUT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.MaskedTextBox txtToTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox TXT_TIME;
        private System.Windows.Forms.TextBox txt_num;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox check_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox check_name;
    }
}