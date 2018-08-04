using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
namespace Time_Attendance
{
    public partial class FrmEmpTrans : Form
    {
        #region DataFileds
        SqlCommand _cmd;
        string FilterString = "";
        static string FilterString2 = "";
        bool FilterFlag = false;
        bool FilterFlag2 = false;
        SqlDataAdapter _da, temp;
        public static string Str;
        public static string Str2;
        public static string Str3;

        public static DataTable _Dt = new DataTable();
        #endregion

        public FrmEmpTrans()
        {
            InitializeComponent();
        }

        private void FrmEmpTrans_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeAttendanceDataSet.Dep' table. You can move, or remove it, as needed.
            this.depTableAdapter.Connection = frmMainForm._MasterCon;
            this.depTableAdapter.Fill(this.timeAttendanceDataSet.Dep);
            _cmd = new SqlCommand("select * from EMPLOYEE_CARDS Order by CRD_NAME", frmMainForm._MasterCon);
            cmbDep.Text = "";
            _da = new SqlDataAdapter(_cmd);
            DataTable dtEmployees = new DataTable();
            _da.Fill(dtEmployees);
            cmbEmployee.DataSource = dtEmployees;
            cmbEmployee.DisplayMember = "CRD_NAME";
            cmbEmployee.ValueMember = "CRD_NAME";
            cmbEmployee.Text = "";
            _cmd = new SqlCommand("SELECT DepartmentTitle FROM dbo.Dep Order by DepartmentTitle", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            DataTable dtDep = new DataTable();
            _da.Fill(dtDep);
            cmbEmployee.DataSource = dtDep;
            //cmbEmployee.DisplayMember = "CRD_NAME";
            //cmbEmployee.ValueMember = "CRD_NAME";
            //cmbEmployee.Text = "";
            clbDep.Items.Clear();
            for (int i = 0; i < dtDep.Rows.Count; i++)
            {
                clbDep.Items.Add(dtDep.Rows[i]["DepartmentTitle"].ToString());
            }
            //////////////////////
            //RunFilter();
            //////////////////////
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + @"\Delay.txt");
                maskedTextBox1.Text = sr.ReadLine();
                maskedTextBox2.Text = sr.ReadLine();
                maskedTextBox3.Text = sr.ReadLine();
                maskedTextBox4.Text = sr.ReadLine();
                maskedTextBox5.Text = sr.ReadLine();
                maskedTextBox6.Text = sr.ReadLine();
                sr.Close();
            }
            catch
            {
            }
        }
        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox2.Checked)
        //    {
        //        cmbEmployee.Enabled = true;
        //        cmbEmployee_SelectedIndexChanged(null, null);
        //    }
        //    else
        //    {
        //        cmbEmployee.Enabled = false;
        //        cmbEmployee.SelectedItem = null;
        //        //RunFilter();
        //    }

        //}
        private void DateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (DateCheckbox.Checked)
            {
                dtpDateFrom.Enabled = true;
                dtpDateTo.Enabled = true;
                //RunFilter();
            }
            else
            {
                dtpDateFrom.Enabled = false;
                dtpDateTo.Enabled = false;
                //RunFilter();
            }
        }
        private void TimecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TimecheckBox.Checked)
            {
                txtfromTime.Enabled = true;
                txtToTime.Enabled = true;
                //RunFilter();
            }
            else
            {
                txtfromTime.Enabled = false;
                txtToTime.Enabled = false;
                //RunFilter();
            }
        }

        //private void DepCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (DepCheckBox.Checked)
        //    {
        //        if (cmbDep.SelectedValue != null)
        //        {
        //            _cmd = new SqlCommand("select * from EMPLOYEE_CARDS where CRD_DEPARTMENT='" + cmbDep.SelectedValue.ToString() + "' Order by CRD_NAME", frmMainForm._MasterCon);
        //            _da = new SqlDataAdapter(_cmd);
        //            DataTable dtEmployees = new DataTable();
        //            _da.Fill(dtEmployees);
        //            cmbEmployee.DataSource = dtEmployees;
        //            cmbEmployee.DisplayMember = "CRD_NAME";
        //            cmbEmployee.ValueMember = "CRD_NAME";
        //            cmbEmployee.Text = "";                    
        //        }
        //        cmbDep.Enabled = true;
        //        cmbDep_SelectedIndexChanged(null, null);
        //        //RunFilter();
        //    }
        //    else
        //    {
        //        cmbDep.Enabled = false;
        //        //cmbDep.SelectedItem = null;
        //        //RunFilter();
        //    }
        //}
        public void RunFilter()
        {
            TransDate[] daylist = new TransDate[370];
            FilterString = "";
            FilterString2 = "";
            FilterFlag = false;
            FilterFlag2 = false;
            _cmd = new SqlCommand();
            _cmd.Connection = frmMainForm._MasterCon;
            _cmd.CommandTimeout = 2000;

            if (DateCheckbox.Checked)
            {

                try
                {
                    FilterString += " where ( DATE >= '" + dtpDateFrom.Value.ToString("yyyy/MM/dd") + "' and DATE <='" + dtpDateTo.Value.ToString("yyyy/MM/dd") + "' )";
                }
                catch
                {
                    MessageBox.Show("Please Validate your entered Date !", "Error");
                }
                FilterFlag = true;
            }
            else
            {
                //FilterFlag = false;
            }


            //if (DepCheckBox.Checked && !checkBox2.Checked && clbEmp.CheckedItems.Count > 0)

            if (clbDep.CheckedItems.Count > 0 && clbDep.CheckedItems.Count < clbDep.Items.Count)
            {
                string initalFilter = "";
                string initalFilter2 = "";
                
                if (!FilterFlag)
                {
                    initalFilter = " where (";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and (";
                
                if (!FilterFlag2)
                {
                    initalFilter2 = " where (";
                    FilterFlag2 = true;
                }
                else
                    initalFilter2 = " and (";
                try
                {
                    for (int v = 0; v < clbDep.CheckedItems.Count; v++)
                    {
                        if (v != 0)
                        { FilterString += " or "; FilterString2 += " or "; }
                        if (v == 0)
                        {
                            FilterString += initalFilter;
                            FilterString2 += initalFilter2;

                        }

                        FilterString += " [Department]= '" + clbDep.CheckedItems[v].ToString() + "' ";
                        FilterString2 += " [CRD_DEPARTMENT]= '" + clbDep.CheckedItems[v].ToString() + "' ";

                    }
                    FilterString += " )";
                    FilterString2 += " )";
                }
                catch { }
            }


            if (clbEmp.CheckedItems.Count > 0)
            {
                string initalFilter = "";
                string initalFilter2 = "";
                if (!FilterFlag)
                {
                    initalFilter = " where (";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and (";
                if (!FilterFlag2)
                {
                    initalFilter2 = " where (";
                    FilterFlag2 = true;
                }
                else
                    initalFilter2 = " and (";
                try
                {
                    for (int v = 0; v < clbEmp.CheckedItems.Count; v++)
                    {
                        if (v != 0)
                        { FilterString += " or "; FilterString2 += " or "; }
                        if (v == 0)
                        {
                            FilterString += initalFilter;
                            FilterString2 += initalFilter2;
                        }
                        string NAME = clbEmp.CheckedItems[v].ToString();
                        NAME = NAME.Replace("'", "''");
                        FilterString += "[NAME] = '" + NAME + "' ";
                        FilterString2 += "[CRD_NAME] = '" + NAME + "' ";
                    }
                    FilterString += " )";
                    FilterString2 += " )";
                }
                catch { }
            }

            //else if (DepCheckBox.Checked)
            //{
            //    string initalFilter = "";
            //    if (!FilterFlag)
            //    {
            //        initalFilter = " where ";
            //        FilterFlag = true;
            //    }
            //    else
            //        initalFilter = " and ";
            //    try
            //    {
            //        FilterString += initalFilter + "[Department] = '" + cmbDep.SelectedValue.ToString() + "'";
            //    }
            //    catch { }
            //}


            if (cmbLocation.SelectedIndex > 0)
            {
                string initalFilter = "";
                string initalFilter2 = "";
                
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                if (!FilterFlag2)
                {
                    initalFilter2 = " where ";
                    FilterFlag2 = true;
                }
                else
                    initalFilter2 = " and ";

                FilterString += initalFilter + " LOCATION ='" + cmbLocation.SelectedItem.ToString() + "'";
                FilterString2 += initalFilter2 + " LOCATION ='" + cmbLocation.SelectedItem.ToString() + "'";
            }


            if (clb_company.CheckedItems.Count > 0 && clb_company.CheckedItems.Count < clb_company.Items.Count)
            {
                string initalFilter = "";                
                string initalFilter2 = "";

                if (!FilterFlag)
                {
                    initalFilter = " where (";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and (";

                if (!FilterFlag2)
                {
                    initalFilter2 = " where (";
                    FilterFlag2 = true;
                }
                else
                    initalFilter2 = " and (";

                try
                {
                    for (int v = 0; v < clb_company.CheckedItems.Count; v++)
                    {
                        if (v != 0)
                        { FilterString += " or "; FilterString2 += " or "; }
                        if (v == 0)
                        {
                            FilterString += initalFilter;
                            FilterString2 += initalFilter2;
                        }

                        FilterString += " [COMPANY]= '" + clb_company.CheckedItems[v].ToString() + "' ";
                        FilterString2 += " [COMPANY]= '" + clb_company.CheckedItems[v].ToString() + "' ";
                    }
                    FilterString += " )";
                    FilterString2 += " )";
                }
                catch { }
            }
            /*
            if (cmbCompany.SelectedIndex > 0)
            {
                string initalFilter = "";
                string initalFilter2 = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";
                if (!FilterFlag2)
                {
                    initalFilter2 = " where ";
                    FilterFlag2 = true;
                }
                else
                    initalFilter2 = " and ";

                FilterString += initalFilter + "COMPANY = '" + cmbCompany.SelectedItem.ToString() + "'";
                FilterString2 += initalFilter2 + "COMPANY = '" + cmbCompany.SelectedItem.ToString() + "'";
            }
            */




            if (!cbVisitor.Checked)
            {
                string initalFilter = "";
                string initalFilter2 = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";
                if (!FilterFlag2)
                {
                    initalFilter2 = " where ";
                    FilterFlag2 = true;
                }
                else
                    initalFilter2 = " and ";

                FilterString += initalFilter + " NAME NOT LIKE '%V' ";
                FilterString2 += initalFilter2 + " CRD_NAME NOT LIKE '%V' ";
            }

            if (TimecheckBox.Checked)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";
                try
                {
                    if (txtfromTime.Text != "00:00" && txtToTime.Text != "00:00")
                    {
                        FilterString += initalFilter + " convert(Datetime,[Enter Time]) >='" + txtfromTime.Text + "' and convert(Datetime,[Exit Time]) <='" + txtToTime.Text + "' ";
                    }
                    else if (txtfromTime.Text != "00:00")
                    {
                        FilterString += initalFilter + " convert(Datetime,[Enter Time]) >='" + txtfromTime.Text + "' ";
                    }
                    else if (txtToTime.Text != "00:00")
                    {
                        FilterString += initalFilter + " convert(Datetime,[Exit Time]) <='" + txtToTime.Text + "' ";
                    }
                }
                catch
                {
                    //MessageBox.Show("Please Validate your entered Date !", "Error");
                }
                //FilterFlag = false;
            }
            if (check_name.Checked)
            {
                string initalFilter = "";
                string initalFilter2 = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";
                if (!FilterFlag2)
                {
                    initalFilter2 = " where ";
                    FilterFlag2 = true;
                }
                else
                    initalFilter2 = " and ";

                FilterString += initalFilter + "  ( NAME like='" + txt_name.Text + "' )";
                FilterString2 += initalFilter2 + "  ( CRD_NAME like='" + txt_name.Text + "' )";
            }

            if (check_number.Checked)
            {
                string initalFilter = "";
                string initalFilter2 = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";
                if (!FilterFlag2)
                {
                    initalFilter2 = " where ";
                    FilterFlag2 = true;
                }
                else
                    initalFilter2 = " and ";

                FilterString += initalFilter + "  ( CARD='" + txt_num.Text + "' )";
                FilterString2 += initalFilter2 + "  ( CRD_NO='" + txt_num.Text + "' )";
            }
            /////////////////////////////////////////////////////
            //if (checkBox2.Checked)
            //{
            //    string initalFilter = "";
            //    if (!FilterFlag)
            //    {
            //        initalFilter = " where ";
            //        FilterFlag = true;
            //    }
            //    else
            //        initalFilter = " and ";
            //    try
            //    {
            //        FilterString += initalFilter + " NAME = '" + cmbEmployee.SelectedValue.ToString() + "' ";
            //    }
            //    catch { }
            //}
            ////////////////////////////////////////////////

            //////////////////////////////
            //FilterFlag = false;
            //////////////////////


            try
            {
                //if (frmMainForm._ConfigPlace == "cairo")
                //{
                if (checkBoxSHIFT.Checked)
                {
                    Str3 = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] into xx from VSHIFT_FINAL " + FilterString;

                    _cmd = new SqlCommand("drop table xx", frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    frmMainForm._MasterCon.Open();
                    try
                    {
                        _cmd.ExecuteNonQuery();
                    }
                    catch { }
                    frmMainForm._MasterCon.Close();

                    _cmd = new SqlCommand(Str3, frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    frmMainForm._MasterCon.Open();
                    _cmd.ExecuteNonQuery();
                    frmMainForm._MasterCon.Close();
                    if (checkBox_error.Checked)
                    {
                        _cmd.CommandText = "select * from (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date ,[Exit Time],[WORK HOURS],[Location],[Company] from xx as VSHIFT_FINAL " + FilterString + ") as VSHIFT_FINAL where [Enter Time] IS NULL  OR [Exit Time] IS NULL   order by [DATE],[name] ";
                        Str = "SELECT * FROM (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] from xx as VSHIFT_FINAL " + FilterString + " ) AS VSHIFT_FINAL WHERE [Enter Time] IS NULL  OR [Exit Time] IS NULL  ";
                        Str2 = "SELECT * FROM (Select * from xx as VSHIFT_FINAL " + FilterString + ") AS VSHIFT_FINAL WHERE [Enter Time] IS NULL  OR [Exit Time] IS NULL    ";
                    }
                    else
                    {
                        _cmd.CommandText = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date ,[Exit Time],[WORK HOURS],[Location],[Company] from xx as VSHIFT_FINAL " + FilterString + " order by [DATE],[name] ";
                        Str = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] from xx as VSHIFT_FINAL " + FilterString;
                        Str2 = "Select * from xx as VSHIFT_FINAL " + FilterString;                                    
                    }
                    
                    //Str3 = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] into xx from VSHIFT_FINAL " + FilterString;
                    

                    /*_cmd.CommandText = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date ,[Exit Time],[WORK HOURS],[Location],[Company] from VSHIFT_FINAL " + FilterString + " order by [DATE],[name] ";
                    Str = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] from VSHIFT_FINAL " + FilterString;
                    Str2 = "Select * from VSHIFT_FINAL " + FilterString;
                    Str3 = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] into xx from VSHIFT_FINAL " + FilterString;
                     * */

                }
                else
                {
                    Str3 = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  into xx from VTransaction_IN_OUT_FINAL " + FilterString;

                    _cmd = new SqlCommand("drop table xx", frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    frmMainForm._MasterCon.Open();
                    try
                    {
                        _cmd.ExecuteNonQuery();
                    }
                    catch { }
                    frmMainForm._MasterCon.Close();

                    _cmd = new SqlCommand(Str3, frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    frmMainForm._MasterCon.Open();
                    _cmd.ExecuteNonQuery();
                    frmMainForm._MasterCon.Close();
                    if (checkBox_error.Checked)
                    {
                        _cmd.CommandText = "SELECT * FROM (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  from xx as VTransaction_IN_OUT_FINAL " + FilterString + ")  AS VTransaction_IN_OUT_FINAL  WHERE [Enter Time] IS NULL  OR [Exit Time] IS NULL    order by [DATE],[name] ";
                        Str = " SELECT * FROM (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  from xx as VTransaction_IN_OUT_FINAL " + FilterString + ")  AS VTransaction_IN_OUT_FINAL  WHERE [Enter Time] IS NULL  OR [Exit Time] IS NULL    ";
                        Str2 = " SELECT * FROM (Select * from  xx as VTransaction_IN_OUT_FINAL " + FilterString + ")  AS VTransaction_IN_OUT_FINAL  WHERE [ENT DATE] IS NULL OR [Enter Time] IS NULL ";
                    }
                    else
                    {
                        _cmd.CommandText = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  from xx as VTransaction_IN_OUT_FINAL " + FilterString + " order by [DATE],[name] ";
                        Str = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  from xx as VTransaction_IN_OUT_FINAL " + FilterString;
                        Str2 = "Select * from  xx as VTransaction_IN_OUT_FINAL " + FilterString;
                    }
                    
                    /*_cmd.CommandText = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  from VTransaction_IN_OUT_FINAL " + FilterString + " order by [DATE],[name] ";
                    Str = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  from VTransaction_IN_OUT_FINAL " + FilterString;
                    Str2 = "Select * from VTransaction_IN_OUT_FINAL " + FilterString;
                    Str3 = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  into xx from VTransaction_IN_OUT_FINAL " + FilterString;*/
                }
                //}
                //else
                //{
                //string command = " where ";
                /*for (int c = 0; c < frmMainForm._Machin.Length; c++)
                {
                    if (frmMainForm._Machin[c] != null)
                    {
                        if (c != 0)
                        { command += " or "; }
                        command += " TRN_MACHINE= '" + frmMainForm._Machin[c] + "' ";
                    }
                }*/
                /*if (checkBoxSHIFT.Checked)
                {
                    _cmd.CommandText = "select * from (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] from VSHIFT_FINAL " + FilterString + "  ) as teet  order by [DATE],[Name]";
                    Str = "select * from (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] from VSHIFT_FINAL " + FilterString + " ) as [s] " ;
                    Str2 = "Select * from (Select * from VSHIFT_FINAL " + FilterString + " ) as [s] " ;
                }
                else
                {
                    _cmd.CommandText = "select * from (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date ,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE   from VTransaction_IN_OUT_FINAL " + FilterString + "  ) as teet  order by [DATE],[Name]";
                    Str = "select * from (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company], IN_MACHINE, OUT_MACHINE  from VTransaction_IN_OUT_FINAL " + FilterString + " ) as [s] ";
                    Str2 = "Select * from (Select * from VTransaction_IN_OUT_FINAL " + FilterString + " ) as [s] " ;
                }*/
                //}
                _cmd.CommandTimeout = 2000;
                _da = new SqlDataAdapter(_cmd);
                _Dt = new DataTable();
                _Dt.Reset();

                _da.Fill(_Dt);


                ////////////////////////////////////////////////////////////////////////////////////
                ultraGrid1.DataSource = _Dt;
                ////////////////////////////////////////////////////////////////////////////////////
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Please Validate your entered Date ! : " + ex.Message, "Error");
            }

            //try
            //{
            //    //_cmd = new SqlCommand("select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS],[Location],[Company] from VTransaction_IN_OUT_FINAL " + FilterString + " order by [date],[name] ", frmMainForm._MasterCon);
            //    //_cmd.CommandTimeout = 2000;
            //    _cmd.CommandText = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS],[Location],[Company] from VTransaction_IN_OUT_FINAL " + FilterString + " order by [date],[name] ";
            //    //if(x==0)
            //    Str ="select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS],[Location],[Company] from VTransaction_IN_OUT_FINAL " + FilterString;
            //    _da = new SqlDataAdapter(_cmd);
            //    //Str = _da.SelectCommand.CommandText;
            //    _Dt = new DataTable();
            //    _Dt.Reset();

            //    _da.Fill(_Dt);                
            //    ////////////////////////////////////////////////////////////////////////////////////
            //    ultraGrid1.DataSource = _Dt;
            //    ////////////////////////////////////////////////////////////////////////////////////
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("Error Please Validate your entered Date ! : " + ex.Message, "Error");
            //}
            bool searchFlag = false;
            ultraGrid1.DataSource = _Dt;
            //ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Add(ultraGrid1.DisplayLayout.Bands[0].Columns["Date"], false);
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void cmbAtten_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void ChkViewAlldays_CheckedChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void clbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbEmp.Items.Clear();
            string command = "select * from EMPLOYEE_CARDS ";
            if (clbDep.CheckedItems.Count > 0)
            {
                command += " where ";
                for (int y = 0; y < clbDep.CheckedItems.Count; y++)
                {
                    if (y != 0)
                    {
                        command += " or  CRD_DEPARTMENT='" + clbDep.CheckedItems[y].ToString() + "' ";
                    }
                    else
                    {
                        command += " CRD_DEPARTMENT='" + clbDep.CheckedItems[y].ToString() + "' ";
                    }
                }
            }
            _cmd = new SqlCommand(command + " Order by CRD_NAME", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            DataTable dtEmployees = new DataTable();
            _da.Fill(dtEmployees);
            cmbEmployee.DataSource = dtEmployees;
            cmbEmployee.DisplayMember = "CRD_NAME";
            cmbEmployee.ValueMember = "CRD_NAME";
            cmbEmployee.Text = "";
            clbEmp.Items.Clear();
            for (int i = 0; i < dtEmployees.Rows.Count; i++)
            {
                clbEmp.Items.Add(dtEmployees.Rows[i]["CRD_NAME"].ToString());
            }
        }

        private void cmbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDep.SelectedValue != null)
            {
                _cmd = new SqlCommand("select * from EMPLOYEE_CARDS where CRD_DEPARTMENT='" + cmbDep.SelectedValue.ToString() + "' Order by CRD_NAME", frmMainForm._MasterCon);
                _da = new SqlDataAdapter(_cmd);
                DataTable dtEmployees = new DataTable();
                _da.Fill(dtEmployees);
                cmbEmployee.DataSource = dtEmployees;
                cmbEmployee.DisplayMember = "CRD_NAME";
                cmbEmployee.ValueMember = "CRD_NAME";
                cmbEmployee.Text = "";
                clbEmp.Items.Clear();
                for (int i = 0; i < dtEmployees.Rows.Count; i++)
                {
                    clbEmp.Items.Add(dtEmployees.Rows[i]["CRD_NAME"].ToString());
                }
                //RunFilter();
            }
        }

        private void txtfromTime_TextChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void txtToTime_TextChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();

            string sort = "";

            if (radioButton1.Checked)
            {
                sort = "Order by [NAME],DATE,[Enter Time]";
            }
            if (radioButton2.Checked)
            {
                sort = "Order by [CARD],DATE,[Enter Time]";
            }
            if (radioButton3.Checked)
            {
                sort = "Order by DATE,[Enter Time]";
            }
            if (radioButton4.Checked)
            {
                sort = "Order by Department,[CARD],DATE,[Enter Time]";
            }


            _cmd = new SqlCommand(Str + sort, frmMainForm._MasterCon);
            _cmd.CommandTimeout = 2000;
            //Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
            _da = new SqlDataAdapter(_cmd);
            _Dt = new DataTable();
            _Dt.Reset();
            _da.Fill(_Dt);

            //////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////

            frmReportViewer2 Viewer = new frmReportViewer2();

            if (_Dt.Rows.Count == 0)
            {
                MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


            if (checkBoxSHIFT.Checked)
            {
                EmpShiftTransRpt EmpSHIFTTransRpt = new EmpShiftTransRpt();
                EmpSHIFTTransRpt.Database.Tables["VSHIFT_FINAL"].SetDataSource(_Dt);
                EmpSHIFTTransRpt.SetParameterValue(EmpSHIFTTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                EmpSHIFTTransRpt.SetParameterValue(EmpSHIFTTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
                Viewer.crystalReportViewer1.ReportSource = EmpSHIFTTransRpt;
            }
            else
            {
                EmpTransRpt EmpTransRpt = new EmpTransRpt();
                EmpTransRpt.Database.Tables["VTransaction_IN_OUT_FINAL"].SetDataSource(_Dt);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_ca_start.ParameterFieldName, maskedTextBox1.Text);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_ca_end.ParameterFieldName, maskedTextBox2.Text);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_ps_start.ParameterFieldName, maskedTextBox3.Text);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_ps_end.ParameterFieldName, maskedTextBox4.Text);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_service_start.ParameterFieldName, maskedTextBox5.Text);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_service_end.ParameterFieldName, maskedTextBox6.Text);
                Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
            }
            Viewer.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void ch1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbDep.Items.Count; i++)
            {
                clbDep.SetItemChecked(i, (ch1.Checked) ? true : false);
            }
            clbDep_SelectedIndexChanged(null, null);
        }

        private void ch2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbEmp.Items.Count; i++)
            {
                clbEmp.SetItemChecked(i, (ch2.Checked) ? true : false);
            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            _cmd = new SqlCommand();
            _cmd.Connection = frmMainForm._MasterCon;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "GET_NUM_HOURS";
            _cmd.CommandTimeout = 2000;
            _cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = dtpDateFrom.Value.ToString("yyyy/MM/dd");
            _cmd.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = dtpDateTo.Value.ToString("yyyy/MM/dd");
            //Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
            _da = new SqlDataAdapter(_cmd);
            _Dt = new DataTable();
            _Dt.Reset();
            _da.Fill(_Dt);

            //////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////

            frmReportViewer2 Viewer = new frmReportViewer2();

            //if (_Dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    return;
            //}
            SummaryRpt Rpt = new SummaryRpt();
            Rpt.Database.Tables["GET_NUM_HOURS;1"].SetDataSource(_Dt);
            Rpt.SetParameterValue(Rpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
            Rpt.SetParameterValue(Rpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
            Rpt.SetParameterValue(Rpt.Parameter_FROMDATE.ParameterFieldName, dtpDateFrom.Value.ToString("yyyy/MM/dd"));
            Rpt.SetParameterValue(Rpt.Parameter_TODATE.ParameterFieldName, dtpDateFrom.Value.ToString("yyyy/MM/dd"));
            Viewer.crystalReportViewer1.ReportSource = Rpt;
            Viewer.ShowDialog();
        }

        private void check_name_CheckedChanged(object sender, EventArgs e)
        {
            if (check_name.Checked)
            {
                txt_name.Enabled = true;
            }
            else
            {
                txt_name.Enabled = false;
            }
        }

        private void check_number_CheckedChanged(object sender, EventArgs e)
        {
            if (check_number.Checked)
            {
                txt_num.Enabled = true;
            }
            else
            {
                txt_num.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter(Application.StartupPath + @"\Delay.txt");
            file.WriteLine(maskedTextBox1.Text);
            file.WriteLine(maskedTextBox2.Text);
            file.WriteLine(maskedTextBox3.Text);
            file.WriteLine(maskedTextBox4.Text);
            file.WriteLine(maskedTextBox5.Text);
            file.WriteLine(maskedTextBox6.Text);
            file.Close();
            MessageBox.Show("Done.");
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();

            string sort = "";

            if (radioButton1.Checked)
            {
                sort = "Order by [NAME],DATE,[Enter Time]";
            }
            if (radioButton2.Checked)
            {
                sort = "Order by [CARD],DATE,[Enter Time]";
            }
            if (radioButton3.Checked)
            {
                sort = "Order by DATE,[Enter Time]";
            }
            if (radioButton4.Checked)
            {
                sort = "Order by Department,[CARD],DATE,[Enter Time]";
            }


            _cmd = new SqlCommand(Str + sort, frmMainForm._MasterCon);
            _cmd.CommandTimeout = 2000;
            //Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
            _da = new SqlDataAdapter(_cmd);
            _Dt = new DataTable();
            _Dt.Reset();
            _da.Fill(_Dt);

            //////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////

            frmReportViewer2 Viewer = new frmReportViewer2();

            if (_Dt.Rows.Count == 0)
            {
                MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


            /*if (checkBoxSHIFT.Checked)
            {
                EmpShiftTransRpt EmpSHIFTTransRpt = new EmpShiftTransRpt();
                EmpSHIFTTransRpt.Database.Tables["VSHIFT_FINAL"].SetDataSource(_Dt);
                EmpSHIFTTransRpt.SetParameterValue(EmpSHIFTTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                EmpSHIFTTransRpt.SetParameterValue(EmpSHIFTTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
                Viewer.crystalReportViewer1.ReportSource = EmpSHIFTTransRpt;
            }
            else
            {*/
            EmpTransRptWithG EmpTransRpt = new EmpTransRptWithG();
            EmpTransRpt.Database.Tables["VTransaction_IN_OUT_FINAL"].SetDataSource(_Dt);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_ca_start.ParameterFieldName, maskedTextBox1.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_ca_end.ParameterFieldName, maskedTextBox2.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_ps_start.ParameterFieldName, maskedTextBox3.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_ps_end.ParameterFieldName, maskedTextBox4.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_service_start.ParameterFieldName, maskedTextBox5.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_service_end.ParameterFieldName, maskedTextBox6.Text);
            Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
            //}
            Viewer.ShowDialog();
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            if (TXT_PATH.Text != "")
            {
                string sort = "";

                if (radioButton1.Checked)
                {
                    sort = "Order by [NAME],DATE,[Enter Time]";
                }
                if (radioButton2.Checked)
                {
                    sort = "Order by [CARD],DATE,[Enter Time]";
                }
                if (radioButton3.Checked)
                {
                    sort = "Order by DATE,[Enter Time]";
                }
                if (radioButton4.Checked)
                {
                    sort = "Order by Department,[CARD],DATE,[Enter Time]";
                }

                _cmd = new SqlCommand("drop table xx", frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                frmMainForm._MasterCon.Open();
                try
                {
                    _cmd.ExecuteNonQuery();
                }
                catch { }
                frmMainForm._MasterCon.Close();

                _cmd = new SqlCommand(Str3, frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                frmMainForm._MasterCon.Open();
                _cmd.ExecuteNonQuery();
                frmMainForm._MasterCon.Close();

                if (!FilterFlag)
                {
                    FilterString2 += " where ";
                    FilterFlag2 = true;
                }
                else
                    FilterString2 += " and ";

                FilterString2 += " IN_JOB=1";
                _cmd = new SqlCommand("select CRD_NO,CRD_NAME from EMPLOYEE_CARDS " + FilterString2, frmMainForm._MasterCon);


                _cmd.CommandTimeout = 2000;
                _da = new SqlDataAdapter(_cmd);
                DataTable Dt = new DataTable();
                Dt.Reset();
                _da.Fill(Dt);
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    //string initalFilter = "";
                    string qu = "";
                    if (checkBoxSHIFT.Checked)
                    {
                        qu = "select * from xx as VSHIFT_FINAL ";
                    }
                    else
                    {
                        qu = "select * from xx as VTransaction_IN_OUT_FINAL";
                    }
                    /*if (!FilterFlag)
                    {
                        initalFilter = " where ";
                        FilterFlag = true;
                    }
                    else
                        initalFilter = " and ";
                    */
                    qu += " where [CARD]= '" + Dt.Rows[i][0].ToString() + "'   " + sort;
                    _cmd = new SqlCommand(qu, frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);
                    frmReportViewer2 Viewer = new frmReportViewer2();

                    ReportDocument Crystal_report = new ReportDocument();

                    try
                    {
                        Crystal_report.Load(@"EmpTransRpt.rpt");
                    }
                    catch
                    {
                        Crystal_report.Load(@"EmpTransRpt2.rpt");
                    }
                    //Crystal_report.Load(@"EmpTransRpt.rpt");


                    if (checkBoxSHIFT.Checked)
                    {
                        Crystal_report.SetDataSource(_Dt);

                        Crystal_report.SetParameterValue(0, dtpDateFrom.Text);
                        Crystal_report.SetParameterValue(1, dtpDateTo.Text);
                        Viewer.crystalReportViewer1.ReportSource = Crystal_report;
                        Viewer.crystalReportViewer1.Refresh();
                        Crystal_report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, TXT_PATH.Text + @"\" + Dt.Rows[i][1].ToString() + ".pdf");
                        Crystal_report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, TXT_PATH.Text + @"\" + Dt.Rows[i][1].ToString() + ".xls");
                    }
                    else
                    {
                        Crystal_report.SetDataSource(_Dt);
                        Crystal_report.SetParameterValue(0, dtpDateFrom.Text);
                        Crystal_report.SetParameterValue(1, dtpDateTo.Text);
                        Crystal_report.SetParameterValue(2, maskedTextBox1.Text);
                        Crystal_report.SetParameterValue(3, maskedTextBox2.Text);
                        Crystal_report.SetParameterValue(4, maskedTextBox3.Text);
                        Crystal_report.SetParameterValue(5, maskedTextBox4.Text);
                        Crystal_report.SetParameterValue(6, maskedTextBox5.Text);
                        Crystal_report.SetParameterValue(7, maskedTextBox6.Text);
                        Viewer.crystalReportViewer1.ReportSource = Crystal_report;
                        Viewer.crystalReportViewer1.Refresh();
                        Crystal_report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, TXT_PATH.Text + @"\" + Dt.Rows[i][1].ToString() + ".pdf");
                        Crystal_report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, TXT_PATH.Text + @"\" + Dt.Rows[i][1].ToString() + ".xls");
                    }
                    Crystal_report.Dispose();
                    Crystal_report.Close();
                }
                _cmd = new SqlCommand("drop table xx ", frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                frmMainForm._MasterCon.Open();
                try
                {
                    _cmd.ExecuteNonQuery();
                }
                catch { }
                frmMainForm._MasterCon.Close();
                MessageBox.Show("Files Created.");
            }
        }
        private void glassButton4_Click(object sender, EventArgs e)
        {
            if (TXT_PATH.Text != "")
            {
                string sort = "";

                if (radioButton1.Checked)
                {
                    sort = "Order by [NAME],DATE,[Enter Time]";
                }
                if (radioButton2.Checked)
                {
                    sort = "Order by [CARD],DATE,[Enter Time]";
                }
                if (radioButton3.Checked)
                {
                    sort = "Order by DATE,[Enter Time]";
                }
                if (radioButton4.Checked)
                {
                    sort = "Order by Department,[CARD],DATE,[Enter Time]";
                }

                _cmd = new SqlCommand("drop table xx", frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                frmMainForm._MasterCon.Open();
                try
                {
                    _cmd.ExecuteNonQuery();
                }
                catch { }
                frmMainForm._MasterCon.Close();

                _cmd = new SqlCommand(Str3, frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                frmMainForm._MasterCon.Open();
                _cmd.ExecuteNonQuery();
                frmMainForm._MasterCon.Close();

                if (!FilterFlag)
                {
                    FilterString2 += " where ";
                    FilterFlag2 = true;
                }
                else
                    FilterString2 += " and ";

                FilterString2 += " IN_JOB=1";
                _cmd = new SqlCommand("select distinct CRD_DEPARTMENT from EMPLOYEE_CARDS " + FilterString2, frmMainForm._MasterCon);


                _cmd.CommandTimeout = 2000;
                _da = new SqlDataAdapter(_cmd);
                DataTable Dt = new DataTable();
                Dt.Reset();
                _da.Fill(Dt);
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    //string initalFilter = "";
                    string qu = "";
                    if (checkBoxSHIFT.Checked)
                    {
                        qu = "select * from xx as VSHIFT_FINAL ";
                    }
                    else
                    {
                        qu = "select * from xx as VTransaction_IN_OUT_FINAL ";
                    }
                    /*if (!FilterFlag)
                    {
                        initalFilter = " where ";
                        FilterFlag = true;
                    }
                    else
                        initalFilter = " and ";
                    */
                    qu += " where [Department]= '" + Dt.Rows[i][0].ToString() + "' " + sort;
                    _cmd = new SqlCommand(qu, frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);
                    frmReportViewer2 Viewer = new frmReportViewer2();

                    ReportDocument Crystal_report = new ReportDocument();

                    try
                    {
                        Crystal_report.Load(@"EmpTransRpt.rpt");
                    }
                    catch
                    {
                        Crystal_report.Load(@"EmpTransRpt2.rpt");
                    }
                    //Crystal_report.Load(@"EmpTransRpt.rpt");


                    if (checkBoxSHIFT.Checked)
                    {
                        Crystal_report.SetDataSource(_Dt);

                        Crystal_report.SetParameterValue(0, dtpDateFrom.Text);
                        Crystal_report.SetParameterValue(1, dtpDateTo.Text);
                        Viewer.crystalReportViewer1.ReportSource = Crystal_report;
                        Viewer.crystalReportViewer1.Refresh();
                        Crystal_report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, TXT_PATH.Text+@"\" + Dt.Rows[i][0].ToString() + ".pdf");
                        Crystal_report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, TXT_PATH.Text + @"\" + Dt.Rows[i][0].ToString() + ".xls");
                    }
                    else
                    {
                        Crystal_report.SetDataSource(_Dt);
                        Crystal_report.SetParameterValue(0, dtpDateFrom.Text);
                        Crystal_report.SetParameterValue(1, dtpDateTo.Text);
                        Crystal_report.SetParameterValue(2, maskedTextBox1.Text);
                        Crystal_report.SetParameterValue(3, maskedTextBox2.Text);
                        Crystal_report.SetParameterValue(4, maskedTextBox3.Text);
                        Crystal_report.SetParameterValue(5, maskedTextBox4.Text);
                        Crystal_report.SetParameterValue(6, maskedTextBox5.Text);
                        Crystal_report.SetParameterValue(7, maskedTextBox6.Text);
                        Viewer.crystalReportViewer1.ReportSource = Crystal_report;
                        Viewer.crystalReportViewer1.Refresh();
                        Crystal_report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, TXT_PATH.Text + @"\" + Dt.Rows[i][0].ToString() + ".pdf");
                        Crystal_report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, TXT_PATH.Text + @"\" + Dt.Rows[i][0].ToString() + ".xls");
                    }
                    Crystal_report.Dispose();
                    Crystal_report.Close();
                }
                _cmd = new SqlCommand("drop table xx ", frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                frmMainForm._MasterCon.Open();
                try
                {
                    _cmd.ExecuteNonQuery();
                }
                catch { }
                frmMainForm._MasterCon.Close();
                MessageBox.Show("Files Created.");
            }
        }   

        private void glassButton5_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
                TXT_PATH.Text = folderBrowserDialog1.SelectedPath;
        }
    }
    public class TransDate
    {
        private int transday;
        private int transmonth;
        private int transyear;
        DateTime TransDateValue;
        public TransDate(int tday,int tmonth,int tyear)
        {
            transday = tday;
            transmonth = tmonth;
            transyear = tyear;
        }
        public TransDate()
        {
            transday = 1;
            transmonth = 1;
            transyear = 1987;
        }
        public TransDate(DateTime transDate)
        {
            TransDateValue = transDate;
        }       
        public DateTime returnValue()
        {
            try
            {
                return DateTime.Parse(transday.ToString() + "/" + transmonth.ToString() + "/" + transyear.ToString());
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public DateTime returnDate()
        {
            try
            {
                return TransDateValue;
            }
            catch
            {
                return DateTime.Now;
            }
        }

    }
}