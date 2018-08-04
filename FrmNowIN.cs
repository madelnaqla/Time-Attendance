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
    public partial class FrmNowIN : Form
    {
        #region DataFileds
        SqlCommand _cmd;
        string FilterString = "";
        bool FilterFlag = false;
        SqlDataAdapter _da, temp;
        public static string Str;
        public static string Str2;
        public static string IN_OUT;
        public static DataTable _Dt = new DataTable();
        #endregion

        public FrmNowIN()
        {
            InitializeComponent();
        }

        private void FrmEmpTrans_Load(object sender, EventArgs e)
        {
            _cmd = new SqlCommand("SELECT DepartmentTitle FROM dbo.Dep Order by DepartmentTitle", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            DataTable dtDep = new DataTable();
            _da.Fill(dtDep);
            clbDep.Items.Clear();
            for (int i = 0; i < dtDep.Rows.Count; i++)
            {
                clbDep.Items.Add(dtDep.Rows[i]["DepartmentTitle"].ToString());
            }

        }
        public string RunFilter()
        {
            TransDate[] daylist = new TransDate[370];
            FilterString = "";
            FilterFlag = true;
            _cmd = new SqlCommand();
            _cmd.Connection = frmMainForm._MasterCon;
            _cmd.CommandTimeout = 2000;

            if (clbDep.CheckedItems.Count > 0 && clbDep.CheckedItems.Count < clbDep.Items.Count)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where (";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and (";
                try
                {
                    for (int v = 0; v < clbDep.CheckedItems.Count; v++)
                    {
                        if (v != 0)
                        { FilterString += " or "; }
                        if (v == 0)
                        {
                            FilterString += initalFilter;
                        }

                        FilterString += " [CRD_DEPARTMENT]= '" + clbDep.CheckedItems[v].ToString() + "' ";

                    }
                    FilterString += " )";
                }
                catch { }
            }

            if (clb_company.CheckedItems.Count > 0 && clb_company.CheckedItems.Count < clb_company.Items.Count)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where (";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and (";
                try
                {
                    for (int v = 0; v < clb_company.CheckedItems.Count; v++)
                    {
                        if (v != 0)
                        { FilterString += " or "; }
                        if (v == 0)
                        {
                            FilterString += initalFilter;
                        }

                        FilterString += " [COMPANY]= '" + clb_company.CheckedItems[v].ToString() + "' ";

                    }
                    FilterString += " )";
                }
                catch { }
            }

            if (clb_location.CheckedItems.Count > 0 && clb_location.CheckedItems.Count < clb_location.Items.Count)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where (";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and (";
                try
                {
                    for (int v = 0; v < clb_location.CheckedItems.Count; v++)
                    {
                        if (v != 0)
                        { FilterString += " or "; }
                        if (v == 0)
                        {
                            FilterString += initalFilter;
                        }

                        FilterString += " [LOCATION]= '" + clb_location.CheckedItems[v].ToString() + "' ";

                    }
                    FilterString += " )";
                }
                catch { }
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
                
                FilterString += initalFilter + "  ( CRD_NAME like='" + txt_name.Text + "' )";                
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

                if (rbut_find_in.Checked || rbut_find_out.Checked || rbut_find_att.Checked || rbut_find_abs.Checked)
                {
                    FilterString += initalFilter + "  ( CRD_NO='" + txt_num.Text + "' )";
                }
                else                   
                {
                    FilterString += initalFilter + "  ( CRD_NO='" + txt_num.Text + "' )";
                }
                //FilterString += initalFilter + "  ( TRN_CARD_NO='" + txt_num.Text + "' )";                
            }

            return FilterString;
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {

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

        private void txtfromTime_TextChanged(object sender, EventArgs e)
        {

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
            string sort = "";

            /*if (radioButton1.Checked)
            {
                if (rbut_find_in.Checked || rbut_find_out.Checked)
                {
                    sort = " ) Order by [CRD_NAME],[ENT_TIME]";
                }
                else
                {
                    sort = " ) Order by [CRD_NAME],[TRN_TIME]";
                }
            }
            if (radioButton2.Checked)
            {
                if (rbut_find_in.Checked || rbut_find_out.Checked||rbut_find_att.Checked||rbut_find_abs.Checked)
                {
                    sort = " ) Order by [CRD_NO]";
                }
                else
                {
                    sort = " ) Order by [TRN_CARD_NO]";
                }                
            }
            if (radioButton3.Checked)
            {
                if (rbut_find_in.Checked || rbut_find_out.Checked)
                {
                    sort = " ) Order by [ENT_TIME]";
                }
                else
                {
                    sort = " ) Order by [TRN_TIME]";
                }
            }
            if (radioButton4.Checked)
            {
                if (rbut_find_in.Checked || rbut_find_out.Checked || rbut_find_att.Checked || rbut_find_abs.Checked)
                {
                    sort = " ) Order by [CRD_DEPARTMENT], [CRD_NO]";
                }
                else
                {
                    sort = " ) Order by [CRD_DEPARTMENT],[TRN_CARD_NO]";
                }                                
            }*/

            if (rbut_find_in.Checked || rbut_find_out.Checked)
            {
                _cmd = new SqlCommand(Str, frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                _da = new SqlDataAdapter(_cmd);
                _Dt = new DataTable();
                _Dt.Reset();
                _da.Fill(_Dt);

                frmReportViewer2 Viewer = new frmReportViewer2();

                if (_Dt.Rows.Count == 0)
                {
                    MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                In_COM_Rpt EmpTransRpt = new In_COM_Rpt();
                EmpTransRpt.Database.Tables[0].SetDataSource(_Dt);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, DateTime.Now.ToString("dd/MM/yyyy"));
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_IN_OUT.ParameterFieldName, IN_OUT);
                Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
                Viewer.ShowDialog();
            }
            else if (rbut_find_abs.Checked)
            {
                _cmd = new SqlCommand(Str, frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                _da = new SqlDataAdapter(_cmd);
                _Dt = new DataTable();
                _Dt.Reset();
                _da.Fill(_Dt);

                frmReportViewer2 Viewer = new frmReportViewer2();

                if (_Dt.Rows.Count == 0)
                {
                    MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                Absence_Rpt EmpTransRpt = new Absence_Rpt();
                EmpTransRpt.Database.Tables[0].SetDataSource(_Dt);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, DateTime.Now.ToString("dd/MM/yyyy"));
                Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
                Viewer.ShowDialog();
            }
            else if (rbut_find_att.Checked)
            {
                _cmd = new SqlCommand(Str, frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                _da = new SqlDataAdapter(_cmd);
                _Dt = new DataTable();
                _Dt.Reset();
                _da.Fill(_Dt);
                frmReportViewer2 Viewer = new frmReportViewer2();
                if (_Dt.Rows.Count == 0)
                {
                    MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Attendance_Rpt EmpTransRpt = new Attendance_Rpt();
                EmpTransRpt.Database.Tables[0].SetDataSource(_Dt);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, DateTime.Now.ToString("dd/MM/yyyy"));
                Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
                Viewer.ShowDialog();
            }
            else if (rbut_OUT.Checked)
            {
                _cmd = new SqlCommand(Str, frmMainForm._MasterCon);
                _cmd.CommandTimeout = 2000;
                _da = new SqlDataAdapter(_cmd);
                _Dt = new DataTable();
                _Dt.Reset();
                _da.Fill(_Dt);
                frmReportViewer2 Viewer = new frmReportViewer2();
                if (_Dt.Rows.Count == 0)
                {
                    MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                EmpOutRpt EmpTransRpt = new EmpOutRpt();
                EmpTransRpt.Database.Tables[0].SetDataSource(_Dt);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_DATE1.ParameterFieldName, dtpDateFrom.Value.ToString("dd/MM/yyyy"));
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_DATE2.ParameterFieldName, dtpDateTo.Value.ToString("dd/MM/yyyy"));
                Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
                Viewer.ShowDialog();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (rbut_find_in.Checked)
            {
                string FilterString = RunFilter();
                try
                {
                    _cmd.CommandText = "SELECT  "
                                        + "CRD.CRD_NO, "
                                        + "CRD.CRD_NAME,CRD.CRD_JOB, "
                                        + "CRD.CRD_DEPARTMENT,CRD.COMPANY,CRD.LOCATION,"
                                        + "TRAN_IN.TRN_TIME AS [ENT_TIME],"
                                        + "TRA.TRN_MACHINE, "
                                        + "TRA.TRN_PLACE "
                                        + " FROM  "
                                        + " ( "
                                        + "		SELECT * "
                                        + "		FROM "
                                        + "			( "
                                        + "				SELECT"
                                        + "					  TRN_CARD_NO,	  	  "
                                        + "					  MAX(TRN_TIME) AS TRN_TIME	  "
                        //+"					  "
                                        + "				FROM  EMPLOYEE_TRANSACTIONS "
                                        + "				WHERE TRN_TIME >= DATEADD(DAY,-1,GETDATE())  "
                                        + "				GROUP BY TRN_CARD_NO "
                                        + "			) AS MAX_IN "
                        //+"		WHERE TRN_PLACE='In' "
                                        + "	)AS TRAN_IN, EMPLOYEE_TRANSACTIONS as TRA,dbo.EMPLOYEE_CARDS CRD "
                                        + " WHERE TRA.TRN_CARD_NO=TRAN_IN.TRN_CARD_NO AND "
                                        + "	  TRA.TRN_TIME=TRAN_IN.TRN_TIME AND "
                                        + "	  CRD.IN_JOB=1 AND "
                        //+"	  TRA.TRN_PLACE=TRAN_IN.TRN_PLACE AND "
                                        + "	  CRD.CRD_NO=TRAN_IN.TRN_CARD_NO  AND TRA.TRN_PLACE='In'   "
                                        + FilterString
                                        + "  ORDER BY CRD.CRD_DEPARTMENT,TRAN_IN.TRN_CARD_NO,TRAN_IN.TRN_TIME ";

                    Str = _cmd.CommandText;
                    _cmd.CommandTimeout = 2000;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);
                    ultraGrid1.DataSource = _Dt;
                    IN_OUT = "In";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Please Validate your entered Date ! : " + ex.Message, "Error");
                }
                ultraGrid1.DataSource = _Dt;
            }
            else if (rbut_find_out.Checked)
            {
                string FilterString = RunFilter();
                try
                {
                    _cmd.CommandText = "SELECT  CRD.CRD_NO, CRD.CRD_NAME,CRD.CRD_JOB, CRD.CRD_DEPARTMENT,CRD.COMPANY,CRD.LOCATION,TRAN_OUT.TRN_TIME AS [ENT_TIME],TRA.TRN_MACHINE, TRA.TRN_PLACE FROM  ( SELECT * FROM ( SELECT TRN_CARD_NO,	  	  MAX(TRN_TIME) AS TRN_TIME	  FROM  EMPLOYEE_TRANSACTIONS GROUP BY TRN_CARD_NO ) AS MAX_OUT )AS TRAN_OUT, EMPLOYEE_TRANSACTIONS as TRA,dbo.EMPLOYEE_CARDS CRD WHERE TRA.TRN_CARD_NO=TRAN_OUT.TRN_CARD_NO AND TRA.TRN_TIME=TRAN_OUT.TRN_TIME AND CRD.CRD_NO=TRAN_OUT.TRN_CARD_NO  AND TRA.TRN_PLACE='Out' AND CRD.IN_JOB=1 " + FilterString + "  ORDER BY CRD.CRD_DEPARTMENT,TRAN_OUT.TRN_CARD_NO ,TRAN_OUT.TRN_TIME;";

                    Str = _cmd.CommandText;
                    _cmd.CommandTimeout = 2000;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);
                    ultraGrid1.DataSource = _Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Please Validate your entered Date ! : " + ex.Message, "Error");
                }
                ultraGrid1.DataSource = _Dt;
                IN_OUT = "Out Of";
            }
            else if (rbut_find_att.Checked)
            {
                string FilterString = RunFilter();
                try
                {
                    _cmd.CommandText = "SELECT    TRA.TRN_TIME, CRD.CRD_NO, CRD.CRD_NAME, CRD.CRD_JOB,CRD.CRD_DEPARTMENT, CRD.COMPANY, CRD.LOCATION  FROM         (SELECT     max( TRN_TIME) AS TRN_TIME,  TRN_CARD_NO    FROM         EMPLOYEE_TRANSACTIONS WHERE     (CONVERT(CHAR(10), TRN_TIME,101) = CONVERT(char(10), GETDATE(), 101)) group by TRN_CARD_NO) AS TRA RIGHT OUTER JOIN EMPLOYEE_CARDS AS CRD ON CRD.CRD_NO = TRA.TRN_CARD_NO WHERE     (TRA.TRN_TIME IS NOT NULL) " + FilterString + " AND CRD.CRD_DEPARTMENT<>'VISITORS' AND CRD.IN_JOB=1    ORDER BY CRD.CRD_DEPARTMENT,TRA.TRN_CARD_NO,TRA.TRN_TIME ;";

                    Str = _cmd.CommandText;
                    _cmd.CommandTimeout = 2000;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);
                    ultraGrid1.DataSource = _Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Please Validate your entered Date ! : " + ex.Message, "Error");
                }
                ultraGrid1.DataSource = _Dt;               
            }
            else if (rbut_find_abs.Checked)
            {
                string FilterString = RunFilter();
                try
                {
                    _cmd.CommandText = "SELECT TRA.TRN_TIME,CRD.CRD_NO, CRD.CRD_NAME, CRD.CRD_JOB,CRD.CRD_DEPARTMENT, CRD.COMPANY, CRD.LOCATION  FROM         (SELECT      max(TRN_TIME) AS TRN_TIME, TRN_CARD_NO  FROM         EMPLOYEE_TRANSACTIONS WHERE     (CONVERT(CHAR(10), TRN_TIME,101) = CONVERT(char(10), GETDATE(), 101)) group by TRN_CARD_NO) AS TRA RIGHT OUTER JOIN EMPLOYEE_CARDS AS CRD ON CRD.CRD_NO = TRA.TRN_CARD_NO WHERE     (TRA.TRN_TIME IS NULL) " + FilterString + "   AND CRD.CRD_DEPARTMENT<>'VISITORS' AND CRD.IN_JOB=1  ORDER BY CRD.CRD_DEPARTMENT,TRA.TRN_CARD_NO,TRA.TRN_TIME ;";

                    Str = _cmd.CommandText;
                    _cmd.CommandTimeout = 2000;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);
                    ultraGrid1.DataSource = _Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Please Validate your entered Date ! : " + ex.Message, "Error");
                }
                ultraGrid1.DataSource = _Dt;
            }
            else if (rbut_OUT.Checked)
            {
                string FilterString = RunFilter();
                try
                {
                    _cmd.CommandText =
                        "SELECT MIN (TRN_TIME)TRN_TIME,MIN(Out)Out,TRN_CARD_NO,CRD_NAME,CRD_JOB,CRD_DEPARTMENT,COMPANY,LOCATION,dbo.TimeOnly5Ch(FIRST_IN_DATE) FIRST_IN,dbo.TimeOnly5Ch(FIRST_IN_DATE-MIN(TRN_TIME)) DIFF FROM " +
                        " (select TRN_TIME,dbo.TimeOnly5Ch(TRN_TIME) Out,TRN_CARD_NO,CRD_NAME,CRD_JOB,CRD_DEPARTMENT,COMPANY,LOCATION," +
                    " dbo.F_GET_FIRST_IN_AFTER(TRN_CARD_NO,TRN_TIME,dbo.DateTimeRemoveTime(TRN_TIME)+' 23:59:59') FIRST_IN_DATE" +
                        //",dbo.TimeOnly5Ch(dbo.F_GET_FIRST_IN_AFTER(TRN_CARD_NO,TRN_TIME,dbo.DateTimeRemoveTime(TRN_TIME)+' 23:59:59')-TRN_TIME) DIFF"+
                    " from dbo.EMPLOYEE_TRANSACTIONS, dbo.EMPLOYEE_CARDS where EMPLOYEE_CARDS.CRD_NO=EMPLOYEE_TRANSACTIONS.TRN_CARD_NO AND(TRN_TIME BETWEEN  '" +
                    dtpDateFrom.Value.ToShortDateString() + " 00:00:00' AND '" + dtpDateTo.Value.ToShortDateString() + " 23:59:59' ) AND TRN_PLACE='Out' AND " +
                    " dbo.TimeOnly5Ch(TRN_TIME)<'" + txtToTime.Text + "' AND " +
                    //"dbo.TimeOnly5Ch(dbo.F_GET_FIRST_IN_AFTER(TRN_CARD_NO,TRN_TIME,dbo.DateTimeRemoveTime(TRN_TIME)+' 23:59:59')-TRN_TIME)>='" + TXT_TIME.Text + "' AND " +
                    " IN_JOB=1" + FilterString + ") AS XX WHERE dbo.TimeOnly5Ch(FIRST_IN_DATE-TRN_TIME)>='" + TXT_TIME.Text + "'"+
                    " GROUP BY TRN_CARD_NO,CRD_NAME,CRD_JOB,CRD_DEPARTMENT,COMPANY,LOCATION,FIRST_IN_DATE ORDER BY CRD_DEPARTMENT,TRN_CARD_NO,TRN_TIME";

                    Str = _cmd.CommandText;
                    _cmd.CommandTimeout = 2000;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);
                    ultraGrid1.DataSource = _Dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Please Validate your entered Date ! : " + ex.Message, "Error");
                }
                ultraGrid1.DataSource = _Dt;
            }
        }
        private void ch1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbDep.Items.Count; i++)
            {
                clbDep.SetItemChecked(i, (ch1.Checked) ? true : false);
            }
        }

        private void rbut_OUT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbut_OUT.Checked)
            {
                dtpDateFrom.Enabled = true;
                dtpDateTo.Enabled = true;
                txtToTime.Enabled = true;
                TXT_TIME.Enabled = true;
            }
            else
            {
                dtpDateFrom.Enabled = false;
                dtpDateTo.Enabled = false;
                txtToTime.Enabled = false;
                TXT_TIME.Enabled = false;
            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {

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

    }
}