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
    public partial class FrmAllEmpTrans : Form
    {
        #region DataFileds
        SqlCommand _cmd;
        string FilterString = "";
        string FilterString2 ="";
        bool FilterFlag = false;
        SqlDataAdapter _da,temp;
        public static string Str;
        public static string Str2;
        public static string Str3;
        public static string Process; 
            
        public static DataTable _Dt = new DataTable();             
        #endregion

        public FrmAllEmpTrans()
        {
            InitializeComponent();            
        }

        private void FrmAllEmpTrans_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeAttendanceDataSet.Dep' table. You can move, or remove it, as needed.
            this.depTableAdapter.Connection = frmMainForm._MasterCon;
            this.depTableAdapter.Fill(this.timeAttendanceDataSet.Dep);
            cmbDep.Text = "";
            _cmd = new SqlCommand("select * from EMPLOYEE_CARDS Order by CRD_NAME", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            DataTable dtEmployees = new DataTable();
            _da.Fill(dtEmployees);
            cmbEmployee.DataSource = dtEmployees;
            cmbEmployee.DisplayMember = "CRD_NAME";
            cmbEmployee.ValueMember = "CRD_NAME";
            cmbEmployee.Text = "";
            //////////////////////
            //RunFilter();
            //////////////////////
        }       
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                cmbEmployee.Enabled = true;
                clbEmp.Enabled = false;              
            }
            else
            {
                cmbEmployee.Enabled = false;
                cmbEmployee.SelectedItem = null;
                clbEmp.Enabled = true;
                //RunFilter();
            }

        }
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

        private void DepCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DepCheckBox.Checked)
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
                }
                cmbDep.Enabled = true;
                cmbDep_SelectedIndexChanged(null, null);
                //RunFilter();                
            }
            else
            {
                cmbDep.Enabled = false;
                //cmbDep.SelectedItem = null;
                //RunFilter();
            }
        }
        public string[] RunFilter()
        {
            TransDate[] daylist = new TransDate[370];
            FilterString = "";

            FilterString2 = "";
            //string filter = "";

            FilterFlag = false; 

            if (DateCheckbox.Checked)
            {
                try
                {
                    /*if (dtpDateFrom.Value == dtpDateTo.Value)
                    {
                        FilterString += " where DATE >= '" + dtpDateFrom.Value.ToString("yyyy/MM/dd")+"' and DATE <= '" + dtpDateFrom.Value.ToString("yyyy/MM/dd") + "'";
                    }
                    else
                    {*/
                    FilterString += " where dbo.DateTimeRemoveTime(DATE) >= '" + dtpDateFrom.Value.ToString("yyyy/MM/dd") + "' and dbo.DateTimeRemoveTime(DATE) <='" + dtpDateTo.Value.ToString("yyyy/MM/dd") + "'";
                    //}
                }
                catch
                {
                    MessageBox.Show("Please Validate your entered Date !", "Error");
                }
                FilterFlag = true;
            }
            FilterString2 = FilterString;
            if (!cbVisitor.Checked)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " [Employee Name] NOT LIKE '%V' ";
                FilterString2 += initalFilter + " [NAME] NOT LIKE '%V' ";

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
                        FilterString += initalFilter + " convert(Datetime,[Time]) >= '" + txtfromTime.Text + "' and convert(Datetime,[Time]) <='" + txtToTime.Text + "' ";
                        FilterString2 += initalFilter + " convert(Datetime,[Time]) >= '" + txtfromTime.Text + "' and convert(Datetime,[Time]) <='" + txtToTime.Text + "' ";
                    }
                    else if (txtfromTime.Text != "00:00")
                    {
                        FilterString += initalFilter + " convert(Datetime,[Time]) >= '" + txtfromTime.Text + "' ";
                        FilterString2 += initalFilter + " convert(Datetime,[Time]) >= '" + txtfromTime.Text + "' ";
                    }
                    else if (txtToTime.Text != "00:00")
                    {
                        FilterString += initalFilter + " convert(Datetime,[Time]) <='" + txtToTime.Text + "' ";
                        FilterString2 += initalFilter + " convert(Datetime,[Time]) <='" + txtToTime.Text + "' ";
                    }

                }
                catch
                {
                    //MessageBox.Show("Please Validate your entered Date !", "Error");
                }
                FilterFlag = true;
            }

            /////////////////////////////////////////////////////
            if (checkBox2.Checked)
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
                    FilterString += initalFilter + "[Employee Name] = '" + cmbEmployee.SelectedValue.ToString() + "'";
                    FilterString2 += initalFilter + "[NAME] = '" + cmbEmployee.SelectedValue.ToString() + "'";
                }
                catch { }
            }

            if (DepCheckBox.Checked && !checkBox2.Checked && clbEmp.CheckedItems.Count>0)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ( ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ( ";
                try
                {
                    for (int v = 0; v < clbEmp.CheckedItems.Count; v++)
                    {
                        if (v != 0)
                        { FilterString += " or "; }
                        if (v == 0)
                        {
                            FilterString += initalFilter; 
                        }

                        FilterString +=  "[Employee Name] = '" + clbEmp.CheckedItems[v].ToString() + "' ";
                        FilterString2 += "[NAME] = '" + clbEmp.CheckedItems[v].ToString() + "' ";

                    }
                    FilterString += " ) ";
                }
                catch { }
            }
            else if (DepCheckBox.Checked)
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
                    FilterString += initalFilter + "[Department] = '" + cmbDep.SelectedValue.ToString() + "'";
                    FilterString2 += initalFilter + "[Department] = '" + cmbDep.SelectedValue.ToString() + "'";
                }
                catch { }
            }


            if (radioButtonIn.Checked)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + "Place = 'In'";
            }
            else if (radioButtonOut.Checked)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + "Place = 'Out'";
            }
            
            if (cmbLocation.SelectedIndex>0)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + "LOCATION ='"+cmbLocation.SelectedItem.ToString()+"'";
                FilterString2 += initalFilter + "LOCATION ='" + cmbLocation.SelectedItem.ToString() + "'";
            }

            if (cmbCompany.SelectedIndex>0)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + "COMPANY = '"+cmbCompany.SelectedItem.ToString()+"'";
                FilterString2 += initalFilter + "COMPANY = '" + cmbCompany.SelectedItem.ToString() + "'";
            }

            if (check_name.Checked)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + "  ( [Employee Name]='" + txt_name.Text + "' )";
            }

            if (check_number.Checked)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + "  ([Card Number] ='" + txt_num.Text + "' )";
            }

            ////////////////////////////////////////////////
            
            //////////////////////////////
            //FilterFlag = false;
            //////////////////////
            string[]xx=new string[2];
            xx[0]=FilterString ;
            xx[1]=FilterString2;
            return xx;                
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

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void radioButtonIn_CheckedChanged(object sender, EventArgs e)
        {
            //RunFilter();
        }

        private void radioButtonOut_CheckedChanged(object sender, EventArgs e)
        {
            //RunFilter();
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
                sort = "Order by [Employee Name],[Transaction Date],Time";
            }
            if (radioButton2.Checked)
            {
                sort = "Order by [Card Number],[Transaction Date],Time";
            }
            if (radioButton3.Checked)
            {
                sort = "Order by [Transaction Date],Time";
            }
            if (radioButton4.Checked)
            {
                sort = "Order by Department,[Card Number],[Transaction Date],Time";
            }

            _cmd = new SqlCommand(Str + sort , frmMainForm._MasterCon);
            //Str = "select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department from VTransactions " + FilterString;
            _da = new SqlDataAdapter(_cmd);
            _Dt = new DataTable();
            _Dt.Reset();

            _da.Fill(_Dt);

            //////////////////////////////////////////////////////
            EmpAllTransRpt EmpTransRpt = new EmpAllTransRpt();
            //EmpTransRptAr EmpTransRptAr = new EmpTransRptAr();

            /////////////////////////////////////////////////////////////////////
            frmReportViewer2 Viewer = new frmReportViewer2();
            
            if (_Dt.Rows.Count == 0)
            {
                MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //////////////////////////////////////////////////////
            
            EmpTransRpt.Database.Tables["VTransactions"].SetDataSource(_Dt);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
            Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;          
            Viewer.ShowDialog();
            //////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string[]xx= RunFilter();
            string FilterString=xx[0];
            string FilterString2 = xx[1];
            try
            {
                if (frmMainForm._ConfigPlace == "cairo")
                {
                    _cmd = new SqlCommand("select TRN_SEQ_NO,[Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department,Location,Company,TRN_MACHINE from V_Transaction2 as VTransactions " + FilterString + " order by [Transaction Date],[Employee Name]", frmMainForm._MasterCon);
                    Str = "select TRN_SEQ_NO,[Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department,Location,Company from V_Transaction2 as VTransactions" + FilterString;
                    Str2 = "Select * from VAllTrans " + FilterString;
                    Str3 = "Select * from V_REAL_TIME " + FilterString2;
                }
                else
                {
                    string command = " where ";
                    for (int c = 0; c < frmMainForm._Machin.Length; c++)
                    {
                        if (frmMainForm._Machin[c] != null)
                        {
                            if (c != 0)
                            { command += " or "; }
                            command += " TRN_MACHINE= '" + frmMainForm._Machin[c] + "' ";
                        }
                    }
                    _cmd = new SqlCommand("select * from (select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department,Location,Company,TRN_MACHINE from V_Transaction2 as VTransactions" + FilterString + " ) as teet " + command + " order by [Transaction Date],[Employee Name]", frmMainForm._MasterCon);
                    Str = "select * from (select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department,Location,Company,TRN_MACHINE from V_Transaction2 as VTransactions" + FilterString + " ) as [s] " + command;
                    Str2 = "Select * from (Select * from VAllTrans " + FilterString + " ) as [s] " + command;
                    Str3 = "Select * from (Select * from V_REAL_TIME " + FilterString2 + " ) as [s] " + command;
                }
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
            bool searchFlag = false;

            ultraGrid1.DataSource = _Dt;
            //ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Add(ultraGrid1.DisplayLayout.Bands[0].Columns["Transaction Date"], false);            
            Process="pro";
        }

        private void ch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            string sort="";
            if (radioButton1.Checked)
            {
                sort = "Order by [Employee Name],[Transaction Date]";
            }
            if (radioButton2.Checked)
            {
                sort = "Order by [Card Number],[Transaction Date]";
            }
            if (radioButton3.Checked)
            {
                sort = "Order by [Transaction Date]";
            }
            if (radioButton4.Checked)
            {
                sort = "Order by Department,[Card Number],[Transaction Date]";
            }

            _cmd = new SqlCommand(Str2 + sort, frmMainForm._MasterCon);
            //Str = "select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department from VTransactions " + FilterString;
            _cmd.CommandTimeout = 2000;
            _da = new SqlDataAdapter(_cmd);
            _Dt = new DataTable();
            _Dt.Reset();

            _da.Fill(_Dt);

            //////////////////////////////////////////////////////
            AllTransRpt EmpTransRpt = new AllTransRpt();
            //EmpTransRptAr EmpTransRptAr = new EmpTransRptAr();

            /////////////////////////////////////////////////////////////////////
            frmReportViewer2 Viewer = new frmReportViewer2();

            if (_Dt.Rows.Count == 0)
            {
                MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //////////////////////////////////////////////////////

            EmpTransRpt.Database.Tables["VAllTrans"].SetDataSource(_Dt);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
            Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
            Viewer.ShowDialog();
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            //string sort = "";
            //if (radioButton1.Checked)
            //{
            //    sort = "Order by [NAME],[Date]";
            //}
            //if (radioButton2.Checked)
            //{
            //    sort = "Order by [Card Number],[Transaction Date]";
            //}
            //if (radioButton3.Checked)
            //{
            //    sort = "Order by [Transaction Date]";
            //}
            //if (radioButton4.Checked)
            //{
            //    sort = "Order by Department,[Card Number],[Transaction Date]";
            //}

            _cmd = new SqlCommand();
            _cmd.Connection = frmMainForm._MasterCon;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "GET_REAL_TIME";
            _cmd.CommandTimeout = 2000;

            //_cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = "'"+dtpDateFrom.Value.ToString("yyyy/MM/dd")+"'";
            //_cmd.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = "'" + dtpDateTo.Value.ToString("yyyy/MM/dd")+"'";
            //_cmd.Parameters.Add("@DEP", SqlDbType.VarChar).Value = "'" + cmbDep.SelectedValue.ToString()+"'";
            //_cmd.Parameters.Add("@CARD", SqlDbType.VarChar).Value = "'" + cmbEmployee.SelectedValue.ToString()+"'";
            //_cmd.Parameters.Add("@LOC", SqlDbType.VarChar).Value = "'Cairo'";
            //_cmd.Parameters.Add("@COM", SqlDbType.VarChar).Value = "'PhPC'";

            _cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = dtpDateFrom.Value.ToString("yyyy/MM/dd");
            _cmd.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = dtpDateTo.Value.ToString("yyyy/MM/dd");
            _cmd.Parameters.Add("@DEP", SqlDbType.VarChar).Value = cmbDep.SelectedValue.ToString();
            _cmd.Parameters.Add("@CARD", SqlDbType.VarChar).Value = cmbEmployee.SelectedValue.ToString();
            _cmd.Parameters.Add("@LOC", SqlDbType.VarChar).Value = "Cairo";
            _cmd.Parameters.Add("@COM", SqlDbType.VarChar).Value = "PhPC";

            //Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
            _da = new SqlDataAdapter(_cmd);
            _Dt = new DataTable();
            _Dt.Reset();
            _da.Fill(_Dt);

            /*_cmd = new SqlCommand(Str3 + sort, frmMainForm._MasterCon);
            //Str = "select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department from VTransactions " + FilterString;
            _cmd.CommandTimeout = 2000;
            _da = new SqlDataAdapter(_cmd);
            _Dt = new DataTable();
            _Dt.Reset();

            _da.Fill(_Dt);
            */
            //////////////////////////////////////////////////////
            EmpTrans_REAL_Rpt EmpTransRpt = new EmpTrans_REAL_Rpt();
            //EmpTransRptAr EmpTransRptAr = new EmpTransRptAr();

            /////////////////////////////////////////////////////////////////////
            frmReportViewer2 Viewer = new frmReportViewer2();

            if (_Dt.Rows.Count == 0)
            {
                MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //////////////////////////////////////////////////////

            EmpTransRpt.Database.Tables["GET_REAL_TIME"].SetDataSource(_Dt);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
            EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
            Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
            Viewer.ShowDialog();
            //////////////////////////////////////////////////////
            //////////////////////////////////////////////////////
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] xx = RunFilter();
            string FilterString = xx[0];
            string FilterString2 = xx[1];
            try
            {
                if (frmMainForm._ConfigPlace == "cairo")
                {
                    _cmd = new SqlCommand("select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department,Location,Company,TRN_MACHINE from V_Transaction3 as VTransactions " + FilterString + " order by [Transaction Date],[Employee Name]", frmMainForm._MasterCon);
                    Str = "select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department,Location,Company from V_Transaction3 as VTransactions" + FilterString;
                    Str2 = "Select * from VAllTrans " + FilterString;
                    Str3 = "Select * from V_REAL_TIME " + FilterString2;
                }
                else
                {
                    string command = " where ";
                    for (int c = 0; c < frmMainForm._Machin.Length; c++)
                    {
                        if (frmMainForm._Machin[c] != null)
                        {
                            if (c != 0)
                            { command += " or "; }
                            command += " TRN_MACHINE= '" + frmMainForm._Machin[c] + "' ";
                        }
                    }
                    _cmd = new SqlCommand("select * from (select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department,Location,Company,TRN_MACHINE from V_Transaction3 as VTransactions" + FilterString + " ) as teet " + command + " order by [Transaction Date],[Employee Name]", frmMainForm._MasterCon);
                    Str = "select * from (select [Employee Name] ,[Card Number],[Transaction Date],Time,Place,Job,Department,Location,Company,TRN_MACHINE from V_Transaction3 as VTransactions" + FilterString + " ) as [s] " + command;
                    Str2 = "Select * from (Select * from VAllTrans " + FilterString + " ) as [s] " + command;
                    Str3 = "Select * from (Select * from V_REAL_TIME " + FilterString2 + " ) as [s] " + command;
                }
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
            bool searchFlag = false;

            ultraGrid1.DataSource = _Dt;
            //ultraGrid1.DisplayLayout.Bands[0].SortedColumns.Add(ultraGrid1.DisplayLayout.Bands[0].Columns["Transaction Date"], false);            
            Process = "pro";
            Process = "all";
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

        private void button2_Click(object sender, EventArgs e)
        {
            ADD_LOG PD = new ADD_LOG();
            PD.ShowDialog();
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {

            if (ultraGrid1.Rows.Count > 0)
            {

                if (ultraGrid1.ActiveRow.Cells[0].Text != null && ultraGrid1.ActiveRow.Cells[0].Text != "")
                {
                    DialogResult dialog_reault =MessageBox.Show("Are you sure you want to delete this log?", "confirm", MessageBoxButtons.OKCancel);
                    if (dialog_reault == DialogResult.OK)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = frmMainForm._MasterCon;
                        cmd.CommandTimeout = 2000;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM dbo.EMPLOYEE_TRANSACTIONS WHERE TRN_SEQ_NO=" + ultraGrid1.ActiveRow.Cells[0].Text;
                        frmMainForm._MasterCon.Open();
                        cmd.ExecuteNonQuery();
                        frmMainForm._MasterCon.Close();
                        MessageBox.Show("Log Deleted");
                        btnFind_Click(null, null);
                    }
                }
            }
        }
    
    }  
}