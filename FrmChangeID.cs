using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Time_Attendance
{
    public partial class FrmChangeID : Form
    {
        public static SqlConnection _MasterCon;
        public static SqlConnection _MasterCon2;
        SqlCommand _cmd;
        SqlDataAdapter _da;
        
        

        public FrmChangeID()
        {
            InitializeComponent();
            _MasterCon = frmMainForm._MasterCon;
            _MasterCon2 = frmMainForm._MasterCon2;
        }
        private void DBConnection()
        {

            // _MasterCon = new SqlConnection("Data Source=.; Initial Catalog= EsofWIN_Finger; user=sa; password=123456");
            try
            {
                _MasterCon = frmMainForm._MasterCon;
                //_MasterCon.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Server Connection isn't Available, check configeration!!", "connecting to server......");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {           
            _cmd = new SqlCommand("Update EMPLOYEE_CARDS set CRD_NO='" + txt_to_date.Text + "' where CRD_NO='" + txt_frm_daete.Text + "'", _MasterCon);
            try { _MasterCon.Close(); }
            catch {  }
            _MasterCon.Open();
            try
            {
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            _MasterCon.Close();


            _cmd.Connection = _MasterCon2;
            try { _MasterCon2.Close(); }
            catch { }
            
            _MasterCon2.Open();
            try
            {
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }            
            _MasterCon2.Close();


            _cmd = new SqlCommand("Update EMPLOYEE_TRANSACTIONS set TRN_CARD_NO='" + txt_to_date.Text + "' where TRN_CARD_NO='" + txt_frm_daete.Text + "'", _MasterCon);
            try { _MasterCon.Close(); }
            catch { }
            _MasterCon.Open();
            try
            {
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            _MasterCon.Close();

            MessageBox.Show("Done");
        }             
    }
}