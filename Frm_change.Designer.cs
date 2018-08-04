namespace Time_Attendance
{
    partial class Frm_change
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
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.PnlDeviceSetting = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txt_to_date = new System.Windows.Forms.TextBox();
            this.rad_butt_dec = new System.Windows.Forms.RadioButton();
            this.rad_butt_inc = new System.Windows.Forms.RadioButton();
            this.btnAdd = new EnhancedGlassButton.GlassButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_frm_daete = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.PnlDeviceSetting.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 180);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(489, 43);
            this.ultraGroupBox1.TabIndex = 2;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // PnlDeviceSetting
            // 
            this.PnlDeviceSetting.BackColor = System.Drawing.Color.SteelBlue;
            this.PnlDeviceSetting.Controls.Add(this.groupBox6);
            this.PnlDeviceSetting.Location = new System.Drawing.Point(0, 0);
            this.PnlDeviceSetting.Name = "PnlDeviceSetting";
            this.PnlDeviceSetting.Size = new System.Drawing.Size(489, 178);
            this.PnlDeviceSetting.TabIndex = 76;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txt_to_date);
            this.groupBox6.Controls.Add(this.rad_butt_dec);
            this.groupBox6.Controls.Add(this.rad_butt_inc);
            this.groupBox6.Controls.Add(this.btnAdd);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.txt_frm_daete);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox6.Location = new System.Drawing.Point(14, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(456, 153);
            this.groupBox6.TabIndex = 80;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Daylight";
            // 
            // txt_to_date
            // 
            this.txt_to_date.Location = new System.Drawing.Point(219, 63);
            this.txt_to_date.Name = "txt_to_date";
            this.txt_to_date.Size = new System.Drawing.Size(151, 20);
            this.txt_to_date.TabIndex = 28;
            // 
            // rad_butt_dec
            // 
            this.rad_butt_dec.AutoSize = true;
            this.rad_butt_dec.Location = new System.Drawing.Point(294, 89);
            this.rad_butt_dec.Name = "rad_butt_dec";
            this.rad_butt_dec.Size = new System.Drawing.Size(78, 17);
            this.rad_butt_dec.TabIndex = 27;
            this.rad_butt_dec.TabStop = true;
            this.rad_butt_dec.Text = "Decrease";
            this.rad_butt_dec.UseVisualStyleBackColor = true;
            // 
            // rad_butt_inc
            // 
            this.rad_butt_inc.AutoSize = true;
            this.rad_butt_inc.Location = new System.Drawing.Point(137, 89);
            this.rad_butt_inc.Name = "rad_butt_inc";
            this.rad_butt_inc.Size = new System.Drawing.Size(75, 17);
            this.rad_butt_inc.TabIndex = 26;
            this.rad_butt_inc.TabStop = true;
            this.rad_butt_inc.Text = "Increase";
            this.rad_butt_inc.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.AnimateGlow = true;
            this.btnAdd.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAdd.GlowColor = System.Drawing.Color.AliceBlue;
            this.btnAdd.InnerBorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnAdd.Location = new System.Drawing.Point(203, 117);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 24);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Change";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date";
            // 
            // txt_frm_daete
            // 
            this.txt_frm_daete.Location = new System.Drawing.Point(219, 22);
            this.txt_frm_daete.Name = "txt_frm_daete";
            this.txt_frm_daete.Size = new System.Drawing.Size(151, 20);
            this.txt_frm_daete.TabIndex = 0;
            // 
            // Frm_change
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(489, 223);
            this.Controls.Add(this.PnlDeviceSetting);
            this.Controls.Add(this.ultraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_change";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daylight";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.PnlDeviceSetting.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.Panel PnlDeviceSetting;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private EnhancedGlassButton.GlassButton btnAdd;
        private System.Windows.Forms.RadioButton rad_butt_dec;
        private System.Windows.Forms.RadioButton rad_butt_inc;
        private System.Windows.Forms.TextBox txt_frm_daete;
        private System.Windows.Forms.TextBox txt_to_date;
    }
}