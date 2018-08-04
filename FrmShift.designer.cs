namespace Time_Attendance
{
    partial class FrmShifts
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.err1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpMain = new Infragistics.Win.Misc.UltraGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblNavNo = new EnhancedGlassButton.GlassButton();
            this.grpNav = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnLast = new EnhancedGlassButton.GlassButton();
            this.btnNext = new EnhancedGlassButton.GlassButton();
            this.btnPrevious = new EnhancedGlassButton.GlassButton();
            this.btnFirst = new EnhancedGlassButton.GlassButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.BtnPrintPreview = new EnhancedGlassButton.GlassButton();
            this.Btncancel = new EnhancedGlassButton.GlassButton();
            this.btnDelete = new EnhancedGlassButton.GlassButton();
            this.btnUpdate = new EnhancedGlassButton.GlassButton();
            this.Btn_Insert = new EnhancedGlassButton.GlassButton();
            this.btnExit = new EnhancedGlassButton.GlassButton();
            this.btnNew = new EnhancedGlassButton.GlassButton();
            this.GrdDepartments = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfromTime = new System.Windows.Forms.MaskedTextBox();
            this.txtToTime = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.err1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpNav)).BeginInit();
            this.grpNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // err1
            // 
            this.err1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.err1.ContainerControl = this;
            // 
            // grpMain
            // 
            this.grpMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMain.Controls.Add(this.label4);
            this.grpMain.Controls.Add(this.cmbEmployee);
            this.grpMain.Controls.Add(this.txtToTime);
            this.grpMain.Controls.Add(this.txtfromTime);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Location = new System.Drawing.Point(4, 38);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(1007, 98);
            this.grpMain.TabIndex = 9;
            this.grpMain.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(129, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Employee";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(201, 28);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(221, 21);
            this.cmbEmployee.TabIndex = 41;
            // 
            // lblNavNo
            // 
            this.lblNavNo.BackColor = System.Drawing.Color.Azure;
            this.lblNavNo.Enabled = false;
            this.lblNavNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNavNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNavNo.GlowColor = System.Drawing.Color.AliceBlue;
            this.lblNavNo.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.lblNavNo.Location = new System.Drawing.Point(432, 4);
            this.lblNavNo.Name = "lblNavNo";
            this.lblNavNo.Size = new System.Drawing.Size(143, 23);
            this.lblNavNo.TabIndex = 4;
            this.lblNavNo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // grpNav
            // 
            this.grpNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.grpNav.Appearance = appearance1;
            this.grpNav.Controls.Add(this.lblNavNo);
            this.grpNav.Controls.Add(this.btnLast);
            this.grpNav.Controls.Add(this.btnNext);
            this.grpNav.Controls.Add(this.btnPrevious);
            this.grpNav.Controls.Add(this.btnFirst);
            this.grpNav.Location = new System.Drawing.Point(4, 3);
            this.grpNav.Name = "grpNav";
            this.grpNav.Size = new System.Drawing.Size(1007, 31);
            this.grpNav.TabIndex = 11;
            this.grpNav.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Azure;
            this.btnLast.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLast.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnLast.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnLast.Location = new System.Drawing.Point(605, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 23);
            this.btnLast.TabIndex = 17;
            this.btnLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLast.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Azure;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNext.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnNext.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnNext.Location = new System.Drawing.Point(575, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Azure;
            this.btnPrevious.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPrevious.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnPrevious.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnPrevious.Location = new System.Drawing.Point(402, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 23);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Azure;
            this.btnFirst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnFirst.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnFirst.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnFirst.Location = new System.Drawing.Point(372, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 23);
            this.btnFirst.TabIndex = 14;
            this.btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.BtnPrintPreview);
            this.ultraGroupBox1.Controls.Add(this.Btncancel);
            this.ultraGroupBox1.Controls.Add(this.btnDelete);
            this.ultraGroupBox1.Controls.Add(this.btnUpdate);
            this.ultraGroupBox1.Controls.Add(this.Btn_Insert);
            this.ultraGroupBox1.Controls.Add(this.btnExit);
            this.ultraGroupBox1.Controls.Add(this.btnNew);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 447);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1016, 43);
            this.ultraGroupBox1.TabIndex = 10;
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
            this.BtnPrintPreview.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.BtnPrintPreview.Location = new System.Drawing.Point(628, 9);
            this.BtnPrintPreview.Name = "BtnPrintPreview";
            this.BtnPrintPreview.Size = new System.Drawing.Size(72, 24);
            this.BtnPrintPreview.TabIndex = 13;
            this.BtnPrintPreview.Text = "print";
            this.BtnPrintPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // Btncancel
            // 
            this.Btncancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btncancel.AnimateGlow = true;
            this.Btncancel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Btncancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btncancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Btncancel.GlowColor = System.Drawing.Color.AliceBlue;
            this.Btncancel.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.Btncancel.Location = new System.Drawing.Point(550, 9);
            this.Btncancel.Name = "Btncancel";
            this.Btncancel.Size = new System.Drawing.Size(72, 24);
            this.Btncancel.TabIndex = 11;
            this.Btncancel.Text = "Cancel";
            this.Btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btncancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btncancel.Click += new System.EventHandler(this.Btncancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.AnimateGlow = true;
            this.btnDelete.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDelete.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnDelete.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnDelete.Location = new System.Drawing.Point(472, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 24);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.AnimateGlow = true;
            this.btnUpdate.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdate.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnUpdate.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdate.Location = new System.Drawing.Point(394, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 24);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Btn_Insert
            // 
            this.Btn_Insert.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Insert.AnimateGlow = true;
            this.Btn_Insert.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Btn_Insert.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Insert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Btn_Insert.GlowColor = System.Drawing.Color.AliceBlue;
            this.Btn_Insert.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.Btn_Insert.Location = new System.Drawing.Point(316, 9);
            this.Btn_Insert.Name = "Btn_Insert";
            this.Btn_Insert.Size = new System.Drawing.Size(72, 24);
            this.Btn_Insert.TabIndex = 8;
            this.Btn_Insert.Text = "Insert";
            this.Btn_Insert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Insert.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Insert.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnExit.Location = new System.Drawing.Point(706, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 24);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Close";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNew.AnimateGlow = true;
            this.btnNew.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNew.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnNew.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnNew.Location = new System.Drawing.Point(238, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(72, 24);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // GrdDepartments
            // 
            this.GrdDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.White;
            this.GrdDepartments.DisplayLayout.Appearance = appearance2;
            this.GrdDepartments.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.GrdDepartments.DisplayLayout.MaxColScrollRegions = 1;
            this.GrdDepartments.DisplayLayout.MaxRowScrollRegions = 1;
            this.GrdDepartments.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.GrdDepartments.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.GrdDepartments.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.GrdDepartments.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.GrdDepartments.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.GrdDepartments.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.GrdDepartments.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden;
            this.GrdDepartments.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden;
            this.GrdDepartments.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.Name = "Arial";
            appearance4.FontData.SizeInPoints = 10F;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.GrdDepartments.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.GrdDepartments.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BackColor2 = System.Drawing.Color.White;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.GlassTop20;
            appearance5.BackHatchStyle = Infragistics.Win.BackHatchStyle.ForwardDiagonal;
            this.GrdDepartments.DisplayLayout.Override.RowAlternateAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.GrdDepartments.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.GrdDepartments.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.GrdDepartments.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.GrdDepartments.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.GrdDepartments.Location = new System.Drawing.Point(2, 142);
            this.GrdDepartments.Name = "GrdDepartments";
            this.GrdDepartments.Size = new System.Drawing.Size(1008, 311);
            this.GrdDepartments.TabIndex = 6;
            this.GrdDepartments.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.GrdDepartments_InitializeLayout);
            this.GrdDepartments.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.GrdDepartments_DoubleClickRow);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(460, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Shif Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(640, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Shif End";
            // 
            // txtfromTime
            // 
            this.txtfromTime.Location = new System.Drawing.Point(526, 28);
            this.txtfromTime.Name = "txtfromTime";
            this.txtfromTime.Size = new System.Drawing.Size(34, 20);
            this.txtfromTime.TabIndex = 39;
            this.txtfromTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtToTime
            // 
            this.txtToTime.Location = new System.Drawing.Point(697, 28);
            this.txtToTime.Name = "txtToTime";
            this.txtToTime.Size = new System.Drawing.Size(34, 20);
            this.txtToTime.TabIndex = 40;
            this.txtToTime.ValidatingType = typeof(System.DateTime);
            // 
            // FrmShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1016, 490);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.grpNav);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.GrdDepartments);
            this.KeyPreview = true;
            this.Name = "FrmShifts";
            this.Text = "Shifts";
            this.Load += new System.EventHandler(this.FrmShift_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDepartments_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.err1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpNav)).EndInit();
            this.grpNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdDepartments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider err1;
        private Infragistics.Win.Misc.UltraGroupBox grpMain;
        private Infragistics.Win.Misc.UltraGroupBox grpNav;
        private EnhancedGlassButton.GlassButton lblNavNo;
        private EnhancedGlassButton.GlassButton btnLast;
        private EnhancedGlassButton.GlassButton btnNext;
        private EnhancedGlassButton.GlassButton btnPrevious;
        private EnhancedGlassButton.GlassButton btnFirst;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private EnhancedGlassButton.GlassButton Btncancel;
        private EnhancedGlassButton.GlassButton btnDelete;
        private EnhancedGlassButton.GlassButton btnUpdate;
        private EnhancedGlassButton.GlassButton Btn_Insert;
        private EnhancedGlassButton.GlassButton btnExit;
        private EnhancedGlassButton.GlassButton btnNew;
        private Infragistics.Win.UltraWinGrid.UltraGrid GrdDepartments;
        private EnhancedGlassButton.GlassButton BtnPrintPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.MaskedTextBox txtToTime;
        private System.Windows.Forms.MaskedTextBox txtfromTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

    }
}