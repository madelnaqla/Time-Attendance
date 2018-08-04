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
    public partial class FrmStatus : Form
    {
        SqlConnection con;
        SqlCommand _cmd;
        SqlDataAdapter _da;
        public DataTable _NavDt = new DataTable();
        DataTable DTfillGrid = new DataTable();
        public int _index;
        string _ID = "";
        DataSet _ds;
        string _str = "";
        DataRow[] dr;

        public FrmStatus()
        {
            InitializeComponent();
            UpdateUI();
        }
        private void UpdateUI()
        {           
        }

        private void Navigator()
        {
            _cmd = new SqlCommand("SELECT * FROM STATUS", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            _NavDt.Reset();
            _da.Fill(_NavDt);
            _index = _NavDt.Rows.Count;
            lblNavNo.Text = Convert.ToString(_NavDt.Rows.Count + 1);
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            if (_NavDt.Rows.Count == 0)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
        }

     

        private void FrmDepartments_Load(object sender, EventArgs e)
        {
            
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            Btn_Insert.Enabled = false;
            grpMain.Enabled = false;
            Btncancel.Enabled = false;
            Navigator();          
            fillgrid();
            //frmMainForm.SetPermissions(frmMainForm._ST_UserID, "Contract Prices", btnNew, btnAdd, btnUpdate, btnDelete, new Button(), grpNav, ultraGrid1);
        }       

        private void fillgrid()
        {
            //-------------------------
            _ds = new DataSet();
            _cmd = new SqlCommand("SELECT * FROM STATUS ORDER BY STATUS_NAME", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            _ds.Reset();
            _da.Fill(_ds);
            GrdDepartments.DataSource = _ds;
        }

        public void ClearControls()
        {
            err1.Clear();
            _ID = "";          
            txtStatus.Text = "";          
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //dr = dt.Select("ScreenID = 3");
            //if (dr[0]["IfInsert"].ToString() == "True")
            //{
                grpMain.Enabled = true;
                btnNew.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                Btncancel.Enabled = true;
                Btn_Insert.Enabled = true;
                Btn_Insert.Text = "Insert";
                ClearControls();
                grpMain.Enabled = true;
                Navigator();              

            //}
            //else
            //{
            //    MessageBox.Show("Message_Insert_No_Permission");
            //}

        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                err1.Clear();                
                if (txtStatus.Text == "")
                {
                    err1.SetError(txtStatus, "You must Supply STATUS Title");
                    txtStatus.Focus();
                    return;
                }

                if (_ID.Trim().Length > 0 && ((Button)sender).Text == "Insert")
                {
                    MessageBox.Show("You can not insert but you can update because this record is already saved", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (_ID.Trim() == "" && ((Button)sender).Text == "Update")
                {
                    MessageBox.Show("You cant update because this record not added before", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (((Button)sender).Text == "Insert")
                {
                    _cmd = new SqlCommand("usp_InsertTblSTATUS", frmMainForm._MasterCon);
                    _cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    _cmd = new SqlCommand("usp_UpdateTblSTATUS", frmMainForm._MasterCon);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@STATUS_NAME_OLD", SqlDbType.NVarChar).Value = _ID;
                }


                _cmd.Parameters.Add("@STATUS_NAME", SqlDbType.NVarChar).Value = txtStatus.Text.Trim();
                frmMainForm._MasterCon.Open();
                _cmd.ExecuteNonQuery();
                frmMainForm._MasterCon.Close();
                fillgrid();                
                if (((Button)sender).Text == "Btn_Insert")
                {
                    Navigator();
                    MessageBox.Show("Data Saved Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls();
                }
                else
                {
                    _cmd = new SqlCommand("select * from STATUS", frmMainForm._MasterCon);
                    _da = new SqlDataAdapter(_cmd);
                    _NavDt.Reset();
                    _da.Fill(_NavDt);
                    MessageBox.Show("Data Updated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                Btn_Insert.Enabled = false;
                Btncancel.Enabled = false;
                btnNew.Enabled = true;
                grpMain.Enabled = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            //  frmMainForm.SetPermissions(frmMainForm._ST_UserID, "Contract Prices", btnNew, btnAdd, btnUpdate, btnDelete, new Button(), grpNav, ultraGrid1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            grpMain.Enabled = true;
            Btn_Insert.Text = "Update";
            btnNew.Enabled = false;
            Btn_Insert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            Btncancel.Enabled = true;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            _index = 0;
            Display(_index);
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            if (_NavDt.Rows.Count > 1)
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
        }

        public void btnPrevious_Click(object sender, EventArgs e)
        {
            _index -= 1;
            Display(_index);
            if (_index < _NavDt.Rows.Count - 1)
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            if (_index == 0)
            {
                btnPrevious.Enabled = false;
                btnFirst.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _index += 1;
            Display(_index);
            btnPrevious.Enabled = true;
            btnFirst.Enabled = true;
            if (_index == _NavDt.Rows.Count - 1)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _index = _NavDt.Rows.Count - 1;
            Display(_index);
            btnLast.Enabled = false;
            btnNext.Enabled = false;
            if (_NavDt.Rows.Count > 1)
            {
                btnPrevious.Enabled = true;
                btnFirst.Enabled = true;
            }
        }

        public void Display(int index)
        {
            ClearControls();
            _ID = _NavDt.Rows[index]["STATUS_NAME"].ToString();
            txtStatus.Text = _NavDt.Rows[index]["STATUS_NAME"].ToString();            
            lblNavNo.Text = Convert.ToString(_index + 1) + " of " + _NavDt.Rows.Count.ToString();
            btnNew.Enabled = true;
            Btn_Insert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            Btncancel.Enabled = false;

            //frmMainForm.SetPermissions(frmMainForm._ST_UserID, "Contract Prices", btnNew, btnAdd, btnUpdate, btnDelete, new Button(), grpNav, ultraGrid1);
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            Btn_Insert.Enabled = false;
            Btncancel.Enabled = false;
            btnNew.Enabled = true;
            grpMain.Enabled = false;

            // frmMainForm.SetPermissions(frmMainForm._ST_UserID, "Contract Prices", btnNew, btnAdd, btnUpdate, btnDelete, new Button(), grpNav, ultraGrid1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                DialogResult dg = MessageBox.Show("Confirm To Delete STATUS", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.No)
                    return;
                _cmd = new SqlCommand();
                _cmd.Connection = frmMainForm._MasterCon;
                _cmd.CommandText = "usp_DeleteTblSTATUS";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Add("@STATUS_NAME", SqlDbType.NVarChar).Value = _ID;
                frmMainForm._MasterCon.Open();
                _cmd.ExecuteNonQuery();
                frmMainForm._MasterCon.Close();
                MessageBox.Show("Message_Delete_Ok");
                fillgrid();
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                Btn_Insert.Enabled = false;
                Btncancel.Enabled = false;
                btnNew.Enabled = true;
                grpMain.Enabled = false;
                ClearControls();
                Navigator();

                // frmMainForm.SetPermissions(frmMainForm._ST_UserID, "Contract Prices", btnNew, btnAdd, btnUpdate, btnDelete, new Button(), grpNav, ultraGrid1);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void GrdDepartments_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //GrdDepartments.DisplayLayout.Bands[0].Columns["DepartmentTitle"].Hidden = true;                       
            GrdDepartments.DisplayLayout.Bands[0].Columns["STATUS_NAME"].Header.Caption = "STATUS";            
        }

        private void GrdDepartments_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.Index < 0)
                return;
            _ID = GrdDepartments.Rows[e.Row.Index].Cells["STATUS_NAME"].Value.ToString();
            int index = frmMainForm.GetIDIndex(_ID.Trim(), "STATUS_NAME", _NavDt);
            if (index > -1)
            {
                _index = index + 1;
                btnPrevious_Click(null, null);
            }
        }

        private void FrmDepartments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (Btncancel.Enabled == true)
                    Btncancel_Click(null, null);
            }
        }      
    }
}