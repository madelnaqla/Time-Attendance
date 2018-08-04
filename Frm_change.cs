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
    public partial class Frm_change : Form
    {
        public static SqlConnection _MasterCon;
        SqlCommand _cmd;
        SqlDataAdapter _da;
        
        

        public Frm_change()
        {
            InitializeComponent();
            _MasterCon = frmMainForm._MasterCon;
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
            DateTime date_from;
            DateTime date_to;
            if (DateTime.TryParse(txt_frm_daete.Text, out date_from) && DateTime.TryParse(txt_to_date.Text, out date_to))
            {
                if (rad_butt_inc.Checked)
                {
                    _cmd = new SqlCommand("update dbo.EMPLOYEE_TRANSACTIONS SET TRN_TIME=TRN_TIME+('01:00:00') WHERE TRN_TIME BETWEEN '" + txt_frm_daete.Text + "' AND '" + txt_to_date.Text + "'", _MasterCon);
                    _MasterCon.Open();
                    _cmd.ExecuteNonQuery();
                    _MasterCon.Close();
                    MessageBox.Show("Done");
                }
                else if (rad_butt_dec.Checked)
                {
                    _cmd = new SqlCommand("update dbo.EMPLOYEE_TRANSACTIONS SET TRN_TIME=TRN_TIME-('01:00:00') WHERE TRN_TIME BETWEEN '" + txt_frm_daete.Text + "' AND '" + txt_to_date.Text + "'", _MasterCon);
                    _MasterCon.Open();
                    _cmd.ExecuteNonQuery();
                    _MasterCon.Close();
                    MessageBox.Show("Done");
                }                
            }
            else
            {
                MessageBox.Show("Wrong Date");
            }
        }         
    }
}