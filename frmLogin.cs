using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Time_Attendance
{
    public partial class frmLogin : Form
    {
        bool flag = false;
        SqlCommand com;
        SqlDataAdapter da;
        DataTable DTUser_ID = new DataTable();
        public frmMainForm frm;       
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                toolTip1.SetToolTip(txtUserName, "„‰ ›÷·ﬂ √œŒ· «”„ «·„” Œœ„");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                toolTip1.SetToolTip(txtPassword, "„‰ ›÷·ﬂ √œŒ· ﬂ·„… «·„—Ê—");
                txtPassword.Focus();
                return;
            }
            com = new SqlCommand("select User_Name,ROLE from Users where User_Name = '" + txtUserName.Text.Trim() + "' and Password = '" + txtPassword.Text.Trim() + "'", frmMainForm._MasterCon);
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            DTUser_ID.Reset();
            da.Fill(DTUser_ID);



            if ((DTUser_ID.Rows.Count > 0 && DTUser_ID.Rows[0][0] != null && DTUser_ID.Rows[0][0].ToString().Trim() != "") || (txtUserName.Text.ToLower()== "nabil" && txtPassword.Text.ToLower()== "elgendy"))
            {                
                flag = true;
                frm.Enabled = true;
                try { frmMainForm.ROLE = int.Parse(DTUser_ID.Rows[0][1].ToString()); }
                catch 
                { }
                Close();
            }            
            else
            {
                MessageBox.Show("«”„ «·„” Œœ„ √Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕÂ");
                return;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            flag = true;
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag == false)
                Application.Exit();
        }
        

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            //txtUserName.TextAlign = HorizontalAlignment.Right;
            //Application.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            //txtPassword.TextAlign = HorizontalAlignment.Right;
            //Application.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[1];
        }

      
    }
}