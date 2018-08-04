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
    public partial class frmUsers : Form
    {
        SqlCommand com;
        SqlDataAdapter da;
        DataTable DTMaster = new DataTable();
        DataTable DTScreen;
        int currentindex = 0;
        int EnableMode = 0;
        bool edit_mode = false;
        int User_ID = 0;
        SqlConnection con;
        public frmUsers()
        {
            InitializeComponent();
            con = frmMainForm._MasterCon;
        }

        //------------------------------------------------------
        #region "Methods"
        //---------------------------------------------------------
        bool ValidateFrom()
        {
            if (txtUserName.Text.Trim() == "")
            {
                toolTip1.SetToolTip(txtUserName, "√œŒ· √”„ «·„” Œœ„");
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() == "")
            {
                toolTip1.SetToolTip(txtPassword, "√œŒ· ﬂ·„… «·„—Ê—");
                txtPassword.Focus();
                return false;
            }
            if (txtConfirmPassword.Text.Trim() == "")
            {
                toolTip1.SetToolTip(txtConfirmPassword, "√œŒ·  √ﬂÌœ ﬂ·„… «·„—Ê—");
                txtConfirmPassword.Focus();
                return false;
            }
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                MessageBox.Show(" √ﬂœ „‰ ﬂ·„… «·„—Ê—");
                return false;
            }
            return true;
        }
        //---------------------------------------------------------
        void Enabled_Mode()
        {
            if (EnableMode == 0)//---------load
            {
               
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;                
                //btnPrint.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnCancle.Enabled = false;
                btnNew.Enabled = true;

                edit_mode = false;
                clearForm();
                txtUserName.Focus();

            }
            else if (EnableMode == 1)//-----------------new
            {
                clearForm();
                frmUsers_Load(null, null);

                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;                


                //btnPrint.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnAdd.Enabled = true;
                btnCancle.Enabled = true;
                btnNew.Enabled = false;

                edit_mode = false;
                txtUserName.Focus();
            }

            else if (EnableMode == 2)//---------------------search
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;                


                //btnPrint.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnAdd.Enabled = false;
                btnCancle.Enabled = false;
                btnNew.Enabled = true;

                edit_mode = false;
                txtUserName.Focus();

            }

            else if (EnableMode == 3)//----------------edit
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;                

                //btnPrint.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnAdd.Enabled = true;
                btnCancle.Enabled = true;
                btnNew.Enabled = false;

                edit_mode = true;
                txtUserName.Focus();

            }

            else if (EnableMode == 4)//-----------------cancle
            {
                clearForm();
                frmUsers_Load(null, null);

                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;                

                //btnPrint.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnCancle.Enabled = false;
                btnNew.Enabled = true;

                if (edit_mode == false)
                {
                    btnEdit.Enabled = false;
                }
                txtUserName.Focus();
            }
        }
        //---------------------------------------------------------
        void clearForm()
        {
            txtPassword.Text = "";
            txtConfirmPassword.Text="";
            txtUserName.Text = "";
        }
        //---------------------------------------------------------
        private void getData()
        {
            //ClearForm();
            try
            {

                for (int j = 0; j <= DTScreen.Rows.Count - 1; j++)
                {
                    if (Convert.ToInt32(DTScreen.Rows[j][0]) == User_ID)
                    {
                        currentindex = j;
                        txtUserName.Text = DTScreen.Rows[j][1].ToString();
                        txtPassword.Text = DTScreen.Rows[j][2].ToString();                        
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }
        }
        #endregion
        //------------------------------------------------------
        private void frmUsers_Load(object sender, EventArgs e)
        {
            EnableMode = 0;
            Enabled_Mode();            
            com = new SqlCommand("select * from Users", frmMainForm._MasterCon);
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            DTScreen = new DataTable();
            da.Fill(DTScreen);

            for (int i = 0; i <= DTScreen.Rows.Count - 1; i++)
            {
                grdUsers.Rows.Add();
                grdUsers.Rows[i].Cells[0].Value = DTScreen.Rows[i][0];
                grdUsers.Rows[i].Cells[1].Value = DTScreen.Rows[i][1];
            }
        }
        //------------------------------------------------------
        #region "Operations"
        private void btnNew_Click(object sender, EventArgs e)
        {
            EnableMode = 1;
            Enabled_Mode();
        }
        //----------------------------------------------------------
        private void btnCancle_Click(object sender, EventArgs e)
        {
            EnableMode = 4;
            Enabled_Mode();
        }
        //---------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (edit_mode == false)
                save();
            else
                update();
        }
        void save()
        {
            if (!ValidateFrom())
            {
                return;
            }
            if (MessageBox.Show(this, "Â·  —Ìœ Õ›Ÿ «·„” Œœ„ø", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SqlTransaction trans;
            con.Open();
            trans = con.BeginTransaction("Transaction");

            try
            {
                com.Connection = con;
                com.Transaction = trans;

                com.Parameters.Clear();
                com.CommandText = "Insert into Users values ('" + txtUserName.Text.Trim() + "','" + txtPassword.Text.Trim() + "')";
                //com.Parameters.Add("@User_Name", SqlDbType.NVarChar, 50).Value = txtUserName.Text.Trim();
                //com.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = txtPassword.Text.Trim();                
                //com.CommandType = CommandType.StoredProcedure;
                
                com.ExecuteNonQuery();
                
                MessageBox.Show(" „  «·≈÷«›Â »‰Ã«Õ");
                trans.Commit();
                btnCancle_Click(null, null);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
                trans.Rollback();
            }
        }
        //---------------------------------------------------------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            edit_mode = true;
            EnableMode = 3;
            Enabled_Mode();
        }
        void update()
        {
            if (!ValidateFrom())
            {
                return;
            }
            if (MessageBox.Show(this, "Â·  —Ìœ  ⁄œÌ· «·„” Œœ„ø", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SqlTransaction trans;
            con.Open();
            trans = con.BeginTransaction("Transaction");

            try
            {
                com.Connection = con;
                com.Transaction = trans;

                com.Parameters.Clear();
                com.CommandText = "update Users set User_Name='" + txtUserName.Text.Trim() + "' , Password='" + txtPassword.Text.Trim() + "'  where User_Id=" + User_ID.ToString();
                
                com.ExecuteNonQuery();
                
                MessageBox.Show(" „  «·≈÷«›Â »‰Ã«Õ");
                trans.Commit();
                btnCancle_Click(null, null);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
                trans.Rollback();
            }
        }
        //---------------------------------------------------------        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Â·  —Ìœ Õ–› «·„” Œœ„ø", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SqlTransaction trans;
            con.Open();
            trans = con.BeginTransaction("Transaction");

            try
            {
                com.Connection = con;
                com.Transaction = trans;

                com.Parameters.Clear();
                com.CommandText = "delete from TBL_Users where User_ID = " + User_ID;
                com.CommandType = CommandType.Text;
                
                com.ExecuteNonQuery();
                
                //------------------------------------------------------

                trans.Commit();

                //------------------------------------------
                MessageBox.Show(" „ «·Õ–› »‰Ã«Õ");
                btnCancle_Click(null, null);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
                trans.Rollback();
            }
        }
        //---------------------------------------------------------  
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------  
        private void grdUsers_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = grdUsers.CurrentCell.RowIndex;
            if (grdUsers.Rows[rowindex].Cells[0].Value != null && grdUsers.Rows[rowindex].Cells[0].Value.ToString() != "")
            {
                User_ID = Convert.ToInt32(grdUsers.Rows[rowindex].Cells[0].Value);
                getData();
            }
        }
        //--------------------------------------------------------- 
        #endregion
       
    }
}