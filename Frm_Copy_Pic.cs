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
    public partial class Frm_Copy_Pic : Form
    {
        public static SqlConnection _MasterCon;
        SqlCommand _cmd;
        SqlDataAdapter _da;
        
        

        public Frm_Copy_Pic()
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
            StreamReader sr = new StreamReader(Application.StartupPath + @"\Server.txt");
            string ServerName = txt_Server.Text;
            sr.ReadLine();
            string UserName = sr.ReadLine();
            string Password = sr.ReadLine();
            sr.Close();
            
            SqlConnection PSCon = new SqlConnection("Data Source=" + ServerName + ";Initial Catalog=TimeAttendance;User ID=" + UserName + ";Password=" + "123456");

            //DEPARTMENT
            
            SqlCommand com = new SqlCommand("SELECT * FROM Dep", PSCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter PSDataAdapter = new SqlDataAdapter(com);
            DataTable PSTable = new DataTable();
            PSDataAdapter.Fill(PSTable);

            com = new SqlCommand("SELECT * FROM Dep", _MasterCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            /*
            if (dt.Rows.Count > 0)
            {
                SqlDataAdapter LocalDataAdapter = sda;
                var LocalUsersTable = dt;
                //DbLocal.ExecuteQuery("SELECT * FROM users", ref LocalDataAdapter);


                LocalUsersTable.Merge(PSTable);
                LocalUsersTable.AcceptChanges();
                LocalDataAdapter.Update(LocalUsersTable);
            }
             */
            //USERS
            com = new SqlCommand("SELECT * FROM EMPLOYEE_CARDS", PSCon);
            com.CommandType = CommandType.Text;
            com.CommandTimeout = 2000;
            PSDataAdapter = new SqlDataAdapter(com);
            PSTable = new DataTable();
            PSDataAdapter.Fill(PSTable);

            com = new SqlCommand("SELECT * FROM EMPLOYEE_CARDS", _MasterCon);
            com.CommandTimeout = 2000;
            com.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(com);
            dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //SqlDataAdapter LocalDataAdapter = sda;
                //var LocalUsersTable = dt;

                //PSTable.Merge(dt);
                //PSTable.AcceptChanges();
                ////PSCon.Open();
                _cmd = new SqlCommand();
                _cmd.Connection = PSCon;
                _cmd.CommandText = "delete from EMPLOYEE_CARDS";
                _cmd.CommandTimeout = 2000;
                _cmd.CommandType = CommandType.Text;
                PSCon.Open();
                _cmd.ExecuteNonQuery();
                PSCon.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _cmd = new SqlCommand("[sp_InsertESW_CARDS]", PSCon);
                    _cmd.CommandTimeout = 2000;
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("@CRD_NO", SqlDbType.VarChar).Value = dt.Rows[i][0].ToString();
                    _cmd.Parameters.Add("@CRD_NAME", SqlDbType.VarChar).Value = dt.Rows[i][1].ToString();
                    if (dt.Rows[i][2].ToString() != "" && dt.Rows[i][2].ToString() != null)
                    {
                        _cmd.Parameters.Add("@CRD_STARTING_DATE", SqlDbType.DateTime).Value = DateTime.Parse(dt.Rows[i][2].ToString());
                    }
                    if (dt.Rows[i][3].ToString() != "" && dt.Rows[i][3].ToString() != null)
                    {
                        _cmd.Parameters.Add("@CRD_EXPIRY_DATE", SqlDbType.DateTime).Value = DateTime.Parse(dt.Rows[i][3].ToString());
                    }
                    _cmd.Parameters.Add("@CRD_JOB", SqlDbType.VarChar).Value = dt.Rows[i][4].ToString();
                    //_cmd.Parameters.Add("@CRD_LAST_TRANSACTION_TYPE", SqlDbType.DateTime).Value = dt.Rows[i][5].ToString();
                    _cmd.Parameters.Add("@CRD_DEPARTMENT", SqlDbType.NVarChar).Value = dt.Rows[i][6].ToString();
                    if (dt.Rows[i][7].ToString() != "" && dt.Rows[i][7].ToString() != null)
                    {
                        _cmd.Parameters.Add("@PhotoBytes", SqlDbType.Image).Value = (byte[])(dt.Rows[i][7]);
                    }
                    _cmd.Parameters.Add("@COMPANY", SqlDbType.NVarChar).Value = dt.Rows[i][8].ToString();
                    _cmd.Parameters.Add("@LOCATION", SqlDbType.NVarChar).Value = dt.Rows[i][9].ToString();
                    _cmd.Parameters.Add("@IN_JOB", SqlDbType.NVarChar).Value = dt.Rows[i][10].ToString();                                                          
                     PSCon.Open();
                    try
                    {
                        _cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    PSCon.Close();                
                }
                //PSDataAdapter.Update(PSTable);
                //PSCon.Close();
                /*
                LocalUsersTable.Merge(PSTable);
                LocalUsersTable.AcceptChanges();
                LocalDataAdapter.Update(LocalUsersTable);*/
            }
        }     
       
    }
}