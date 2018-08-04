using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Time_Attendance
{
    public partial class Frm_Delay : Form
    {
        #region DataFileds
        SqlCommand _cmd;
        string FilterString = "";
        string FilterString2 = "";
        bool FilterFlag = false;
        SqlDataAdapter _da,temp;
        public static string Str;
        public static string Str2;     
        public static DataTable _Dt = new DataTable();        
        #endregion

        public Frm_Delay()
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
            //////////////////////
            //RunFilter();
            //////////////////////
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
            FilterFlag = false;
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

                        FilterString += " [Department]= '" + clbDep.CheckedItems[v].ToString() + "' ";

                    }
                    FilterString += " )";
                }
                catch { }
            }


            if (clbEmp.CheckedItems.Count > 0)
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
                    for (int v = 0; v < clbEmp.CheckedItems.Count; v++)
                    {
                        if (v != 0)
                        { FilterString += " or "; }
                        if (v == 0)
                        {
                            FilterString += initalFilter;
                        }
                        string NAME = clbEmp.CheckedItems[v].ToString();
                        NAME = NAME.Replace("'", "''");
                        FilterString += "[NAME] = '" + NAME + "' ";
                    }
                    FilterString += " )";
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


            //if (cmbLocation.SelectedIndex > 0)
            //{
            //    string initalFilter = "";
            //    if (!FilterFlag)
            //    {
            //        initalFilter = " where ";
            //        FilterFlag = true;
            //    }
            //    else
            //        initalFilter = " and ";

            //    FilterString += initalFilter + "LOCATION ='" + cmbLocation.SelectedItem.ToString() + "'";
            //}
            //if (cmbCompany.SelectedIndex > 0)
            //{
            //    string initalFilter = "";
            //    if (!FilterFlag)
            //    {
            //        initalFilter = " where ";
            //        FilterFlag = true;
            //    }
            //    else
            //        initalFilter = " and ";

            //    FilterString += initalFilter + "COMPANY = '" + cmbCompany.SelectedItem.ToString() + "'";
            //}

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

                FilterString += initalFilter + " NAME NOT LIKE '%V' ";
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


            
                /*string initalFilter2 = "";
                if (!FilterFlag)
                {
                    initalFilter2 = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter2 = " and ";

                FilterString += initalFilter2 + "  [Enter Time] >'08:15'  ";
            */



            try
            {
                if (frmMainForm._ConfigPlace == "cairo")
                {
                    if (checkBoxSHIFT.Checked)
                    {
                        /*_cmd.CommandText = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date ,[Exit Time],[WORK HOURS],[Location],[Company] from VSHIFT_FINAL " + FilterString + " order by [DATE],[name] ";
                        Str = "select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] from VSHIFT_FINAL " + FilterString;
                        Str2 = "Select * from VSHIFT_FINAL " + FilterString;
                        */
                    }
                    else
                    {
                        //WHERE [Enter Time] >'08:15
                        if (checkBox1.Checked)
                        {
                            string initalFilter = "";
                            if (!FilterFlag)
                            {
                                initalFilter = " where ";
                                FilterFlag = true;
                            }
                            else
                                initalFilter = " and ";

                            FilterString += initalFilter + " (DATENAME(DW, DATE) NOT IN ('Saturday', 'Friday'))  ";                            
                                
                            _cmd.CommandText = "SELECT dbo.TimeArrange(SUM(CONVERT(INT,SUBSTRING([Enter Time],1,2))-8),SUM(CONVERT(INT,SUBSTRING([Enter Time],4,5))-15))FROM dbo.VTransaction_IN_OUT_FINAL " + FilterString;// +" order by [DATE],[name] ";
                            Str = "SELECT dbo.TimeArrange(SUM(CONVERT(INT,SUBSTRING([Enter Time],1,2))-8),SUM(CONVERT(INT,SUBSTRING([Enter Time],4,5))-15))FROM dbo.VTransaction_IN_OUT_FINAL " + FilterString;
                            Str2 = "SELECT dbo.TimeArrange(SUM(CONVERT(INT,SUBSTRING([Enter Time],1,2))-8),SUM(CONVERT(INT,SUBSTRING([Enter Time],4,5))-15))FROM dbo.VTransaction_IN_OUT_FINAL " + FilterString;
                        }
                        else
                        {
                            //SELECT *,dbo.TimeArrange(CONVERT(INT,SUBSTRING([Enter Time],1,2))-8,CONVERT(INT,SUBSTRING([Enter Time],4,5))-15)FROM dbo.VTransaction_IN_OUT_FINAL
                            _cmd.CommandText =
                          "SELECT [ENT DATE], CARD, NAME, [Enter Time],COMPANY, LOCATION, JOB, IN_MACHINE,  "//  DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, IN_MACHINE, "
                        + "DELAY  "//"OUT_MACHINE, DELAY, CONVERT(INT, SUBSTRING(DELAY, 1, CHARINDEX(':', DELAY) - 1)) AS HOU, CONVERT(INT, SUBSTRING(DELAY, CHARINDEX(':', DELAY) + 1, "
                        //+ "LEN(DELAY))) AS MIN "
                        + "FROM         (SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, "
                        + "IN_MACHINE, OUT_MACHINE, CASE WHEN CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) < " + maskedTextBox1.Text.Substring(3, 2) + " AND CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) "
                        + "> " + maskedTextBox1.Text.Substring(0, 2) + " THEN dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + (int.Parse(maskedTextBox1.Text.Substring(0, 2)) + 1).ToString() + ", 60 - (" + maskedTextBox1.Text.Substring(3, 2) + " - CONVERT(INT, SUBSTRING([Enter Time], 4, 5)))) "
                        + "ELSE dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + maskedTextBox1.Text.Substring(0, 2) + ", CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) - " + maskedTextBox1.Text.Substring(3, 2) + ") END AS DELAY FROM   "
                        + "dbo.VTransaction_IN_OUT_FINAL WHERE     ([Enter Time] > '" + maskedTextBox1.Text + "') AND (DATENAME(DW, DATE) NOT IN ('Saturday', 'Friday'))) AS V_DELAY " 
                        + FilterString;// +" order by [DATE],[name] ";
                            Str =
                          "SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, IN_MACHINE, "
                        + "OUT_MACHINE, DELAY, CONVERT(INT, SUBSTRING(DELAY, 1, CHARINDEX(':', DELAY) - 1)) AS HOU, CONVERT(INT, SUBSTRING(DELAY, CHARINDEX(':', DELAY) + 1, "
                        + "LEN(DELAY))) AS MIN "
                        + "FROM         (SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, "
                        + "IN_MACHINE, OUT_MACHINE, CASE WHEN CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) < " + maskedTextBox1.Text.Substring(3, 2) + " AND CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) "
                        + "> " + maskedTextBox1.Text.Substring(0, 2) + " THEN dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + (int.Parse(maskedTextBox1.Text.Substring(0, 2)) + 1).ToString() + ", 60 - (" + maskedTextBox1.Text.Substring(3, 2) + " - CONVERT(INT, SUBSTRING([Enter Time], 4, 5)))) "
                        + "ELSE dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + maskedTextBox1.Text.Substring(0, 2) + ", CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) - " + maskedTextBox1.Text.Substring(3, 2) + ") END AS DELAY FROM   "
                        + "dbo.VTransaction_IN_OUT_FINAL WHERE     ([Enter Time] > '" + maskedTextBox1.Text + "') AND (DATENAME(DW, DATE) NOT IN ('Saturday', 'Friday'))) AS V_DELAY " 
                        + FilterString;
                            Str2 =
                          "SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, IN_MACHINE, "
                        + "OUT_MACHINE, DELAY, CONVERT(INT, SUBSTRING(DELAY, 1, CHARINDEX(':', DELAY) - 1)) AS HOU, CONVERT(INT, SUBSTRING(DELAY, CHARINDEX(':', DELAY) + 1, "
                        + "LEN(DELAY))) AS MIN "
                        + "FROM         (SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, "
                        + "IN_MACHINE, OUT_MACHINE, CASE WHEN CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) < " + maskedTextBox1.Text.Substring(3, 2) + " AND CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) "
                        + "> " + maskedTextBox1.Text.Substring(0, 2) + " THEN dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + (int.Parse(maskedTextBox1.Text.Substring(0, 2)) + 1).ToString() + ", 60 - (" + maskedTextBox1.Text.Substring(3, 2) + " - CONVERT(INT, SUBSTRING([Enter Time], 4, 5)))) "
                        + "ELSE dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + maskedTextBox1.Text.Substring(0, 2) + ", CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) - " + maskedTextBox1.Text.Substring(3, 2) + ") END AS DELAY FROM   "
                        + "dbo.VTransaction_IN_OUT_FINAL WHERE     ([Enter Time] > '" + maskedTextBox1.Text + "') AND (DATENAME(DW, DATE) NOT IN ('Saturday', 'Friday'))) AS V_DELAY " 
                        + FilterString;
                        }
                    }
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
                    if (checkBoxSHIFT.Checked)
                    {
                        /*_cmd.CommandText = "select * from (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] from VSHIFT_FINAL " + FilterString + "  ) as teet " + command + " order by [DATE],[Name]";
                        Str = "select * from (select CARD,NAME,JOB,Department,DATE,[ENT DATE],[Enter Time],ext_date,[Exit Time],[WORK HOURS],[Location],[Company] from VSHIFT_FINAL " + FilterString + " ) as [s] " + command;
                        Str2 = "Select * from (Select * from VSHIFT_FINAL " + FilterString + " ) as [s] " + command;
                         */
                    }
                    else
                    {
                        if (checkBox1.Checked)
                        {
                            string initalFilter = "";
                            if (!FilterFlag)
                            {
                                initalFilter = " where ";
                                FilterFlag = true;
                            }
                            else
                                initalFilter = " and ";

                            FilterString += initalFilter + " (DATENAME(DW, DATE) NOT IN ('Saturday', 'Friday'))  ";

                            _cmd.CommandText = "SELECT dbo.TimeArrange(SUM(CONVERT(INT,SUBSTRING([Enter Time],1,2))-8),SUM(CONVERT(INT,SUBSTRING([Enter Time],4,5))-15))FROM dbo.VTransaction_IN_OUT_FINAL   " + FilterString + "  ) as teet " + command ;
                            Str = "SELECT dbo.TimeArrange(SUM(CONVERT(INT,SUBSTRING([Enter Time],1,2))-8),SUM(CONVERT(INT,SUBSTRING([Enter Time],4,5))-15))FROM dbo.VTransaction_IN_OUT_FINAL  " + FilterString + " ) as [s] " + command;
                            Str2 = "SELECT dbo.TimeArrange(SUM(CONVERT(INT,SUBSTRING([Enter Time],1,2))-8),SUM(CONVERT(INT,SUBSTRING([Enter Time],4,5))-15))FROM dbo.VTransaction_IN_OUT_FINAL  " + FilterString + " ) as [s] " + command;
                        }
                        else
                        {
                            //SELECT *,dbo.TimeArrange(CONVERT(INT,SUBSTRING([Enter Time],1,2))-8,CONVERT(INT,SUBSTRING([Enter Time],4,5))-15)FROM dbo.VTransaction_IN_OUT_FINAL
                            _cmd.CommandText = 
                         "SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, IN_MACHINE, " 
                        +"OUT_MACHINE, DELAY, CONVERT(INT, SUBSTRING(DELAY, 1, CHARINDEX(':', DELAY) - 1)) AS HOU, CONVERT(INT, SUBSTRING(DELAY, CHARINDEX(':', DELAY) + 1, "
                        +"LEN(DELAY))) AS MIN "
                        +"FROM         (SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, "
                        +"IN_MACHINE, OUT_MACHINE, CASE WHEN CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) < "+maskedTextBox1.Text.Substring(3,2)+" AND CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) "
                        + "> " + maskedTextBox1.Text.Substring(0, 2) + " THEN dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + (int.Parse(maskedTextBox1.Text.Substring(0, 2)) + 1).ToString() + ", 60 - (" + maskedTextBox1.Text.Substring(3, 2)+ " - CONVERT(INT, SUBSTRING([Enter Time], 4, 5)))) "
                        + "ELSE dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + maskedTextBox1.Text.Substring(0, 2) + ", CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) - " + maskedTextBox1.Text.Substring(3, 2) + ") END AS DELAY FROM   "
                        + "dbo.VTransaction_IN_OUT_FINAL WHERE     ([Enter Time] > '" + maskedTextBox1.Text+ "')) AS V_DELAY " 
                        + FilterString + "  ) as teet " + command + " order by [DATE],[Name]";
                            Str = 
                         "SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, IN_MACHINE, " 
                        +"OUT_MACHINE, DELAY, CONVERT(INT, SUBSTRING(DELAY, 1, CHARINDEX(':', DELAY) - 1)) AS HOU, CONVERT(INT, SUBSTRING(DELAY, CHARINDEX(':', DELAY) + 1, "
                        +"LEN(DELAY))) AS MIN "
                        +"FROM         (SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, "
                        +"IN_MACHINE, OUT_MACHINE, CASE WHEN CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) < "+maskedTextBox1.Text.Substring(3,2)+" AND CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) "
                        + "> " + maskedTextBox1.Text.Substring(0, 2) + " THEN dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + (int.Parse(maskedTextBox1.Text.Substring(0, 2)) + 1).ToString() + ", 60 - (" + maskedTextBox1.Text.Substring(3, 2)+ " - CONVERT(INT, SUBSTRING([Enter Time], 4, 5)))) "
                        + "ELSE dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + maskedTextBox1.Text.Substring(0, 2) + ", CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) - " + maskedTextBox1.Text.Substring(3, 2) + ") END AS DELAY FROM   "
                        + "dbo.VTransaction_IN_OUT_FINAL WHERE     ([Enter Time] > '" + maskedTextBox1.Text+ "')) AS V_DELAY " 
                        + FilterString + " ) as [s] " + command;
                            Str2 =
                          "SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, IN_MACHINE, "
                        + "OUT_MACHINE, DELAY, CONVERT(INT, SUBSTRING(DELAY, 1, CHARINDEX(':', DELAY) - 1)) AS HOU, CONVERT(INT, SUBSTRING(DELAY, CHARINDEX(':', DELAY) + 1, "
                        + "LEN(DELAY))) AS MIN "
                        + "FROM         (SELECT     DATEV, DATE, [ENT DATE], CARD, NAME, Expr1, [Enter Time], [Exit Time], [WORK HOURS], Department, YMD, COMPANY, LOCATION, JOB, ext_date, "
                        + "IN_MACHINE, OUT_MACHINE, CASE WHEN CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) < " + maskedTextBox1.Text.Substring(3, 2) + " AND CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) "
                        + "> " + maskedTextBox1.Text.Substring(0, 2) + " THEN dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + (int.Parse(maskedTextBox1.Text.Substring(0, 2)) + 1).ToString() + ", 60 - (" + maskedTextBox1.Text.Substring(3, 2) + " - CONVERT(INT, SUBSTRING([Enter Time], 4, 5)))) "
                        + "ELSE dbo.TimeArrange(CONVERT(INT, SUBSTRING([Enter Time], 1, 2)) - " + maskedTextBox1.Text.Substring(0, 2) + ", CONVERT(INT, SUBSTRING([Enter Time], 4, 5)) - " + maskedTextBox1.Text.Substring(3, 2) + ") END AS DELAY FROM   "
                        + "dbo.VTransaction_IN_OUT_FINAL WHERE     ([Enter Time] > '" + maskedTextBox1.Text + "')) AS V_DELAY  " 
                        + FilterString + " ) as [s] " + command;
                        }
                    }
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
            _cmd = new SqlCommand(command+" Order by CRD_NAME", frmMainForm._MasterCon);
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


            if (checkBox1.Checked)
            {
                FilterString = "";
                FilterString2 = "";
                FilterFlag = true;
                if (DateCheckbox.Checked)
                {

                    try
                    {
                        FilterString += " AND ( DATE >= '" + dtpDateFrom.Value.ToString("yyyy/MM/dd") + "' and DATE <='" + dtpDateTo.Value.ToString("yyyy/MM/dd") + "' )";
                        //FilterString2 += " AND ( DATE >= '" + dtpDateFrom.Value.ToString("yyyy/MM/dd") + "' and DATE <='" + dtpDateTo.Value.ToString("yyyy/MM/dd") + "' )";
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

                //if (cmbLocation.SelectedIndex > 0)
                //{
                //    string initalFilter = "";
                //    if (!FilterFlag)
                //    {
                //        initalFilter = " where ";
                //        FilterFlag = true;
                //    }
                //    else
                //        initalFilter = " and ";

                //    FilterString += initalFilter + "LOCATION ='" + cmbLocation.SelectedItem.ToString() + "'";
                //    FilterString2 += initalFilter + "LOCATION ='" + cmbLocation.SelectedItem.ToString() + "'";
                //}
                //if (cmbCompany.SelectedIndex > 0)
                //{
                //    string initalFilter = "";
                //    if (!FilterFlag)
                //    {
                //        initalFilter = " where ";
                //        FilterFlag = true;
                //    }
                //    else
                //        initalFilter = " and ";

                //    FilterString += initalFilter + "COMPANY = '" + cmbCompany.SelectedItem.ToString() + "'";
                //    FilterString2 += initalFilter + "COMPANY = '" + cmbCompany.SelectedItem.ToString() + "'";
                //}
                DataTable _Dt2 = new DataTable();

                if (checkBox2.Checked)
                {
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

                                FilterString += " [Department]= '" + clbDep.CheckedItems[v].ToString() + "' ";

                            }
                            FilterString += " )";
                        }
                        catch { }
                    }


                    _cmd = new SqlCommand("SELECT DATE, [ENT DATE], LOCATION, COMPANY,department, COUNT(*) AS COU FROM VTransaction_IN_OUT_FINAL WHERE ([Enter Time] > '08:15')  " + FilterString + "   GROUP BY DATE, [ENT DATE], LOCATION, COMPANY,department  ORDER BY DATE  ", frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    //Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);

                    _cmd = new SqlCommand("SELECT COUNT(*) AS EMP_COU, LOCATION, COMPANY ,CRD_DEPARTMENT FROM EMPLOYEE_CARDS WHERE (IN_JOB = 1) AND (CRD_NAME NOT LIKE '%V')  " + FilterString2 + "  GROUP BY LOCATION, COMPANY,CRD_DEPARTMENT", frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    //Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
                    _da = new SqlDataAdapter(_cmd);                
                    _Dt2.Reset();
                    _da.Fill(_Dt2);
                }
                else
                {
                    _cmd = new SqlCommand("SELECT DATE, [ENT DATE], LOCATION, COMPANY, COUNT(*) AS COU FROM VTransaction_IN_OUT_FINAL WHERE ([Enter Time] > '08:15')  " + FilterString + "   GROUP BY DATE, [ENT DATE], LOCATION, COMPANY ORDER BY DATE  ", frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    //Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
                    _da = new SqlDataAdapter(_cmd);
                    _Dt = new DataTable();
                    _Dt.Reset();
                    _da.Fill(_Dt);

                    _cmd = new SqlCommand("SELECT COUNT(*) AS EMP_COU, LOCATION, COMPANY FROM EMPLOYEE_CARDS WHERE (IN_JOB = 1) AND (CRD_NAME NOT LIKE '%V')  " + FilterString2 + "  GROUP BY LOCATION, COMPANY", frmMainForm._MasterCon);
                    _cmd.CommandTimeout = 2000;
                    //Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
                    _da = new SqlDataAdapter(_cmd);
                    
                    _Dt2.Reset();
                    _da.Fill(_Dt2);
                }
                //////////////////////////////////////////////////////


                /////////////////////////////////////////////////////////////////////

                frmReportViewer2 Viewer = new frmReportViewer2();

                //if (_Dt.Rows.Count == 0)
                //{
                //    MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    return;
                //}
                                
                if (checkBox2.Checked)
                {
                    Delay_SummaryRpt EmpTransRpt = new Delay_SummaryRpt();
                    EmpTransRpt.Database.Tables[0].SetDataSource(_Dt2);
                    EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                    EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);

                    EmpTransRpt.Database.Tables[1].SetDataSource(_Dt);
                    EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                    EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
                    Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;


                    Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
                }
                else
                {
                    no_Delay_SummaryRpt EmpTransRpt = new no_Delay_SummaryRpt();
                    EmpTransRpt.Database.Tables[0].SetDataSource(_Dt2);
                    EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                    EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);

                    EmpTransRpt.Database.Tables[1].SetDataSource(_Dt);
                    EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                    EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
                    Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;


                    Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
                }
                

                      
                Viewer.ShowDialog();

            }
            else
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


                /* if (checkBoxSHIFT.Checked)
                 {
                     EmpShiftTransRpt EmpSHIFTTransRpt = new EmpShiftTransRpt();
                     EmpSHIFTTransRpt.Database.Tables["VSHIFT_FINAL"].SetDataSource(_Dt);
                     EmpSHIFTTransRpt.SetParameterValue(EmpSHIFTTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                     EmpSHIFTTransRpt.SetParameterValue(EmpSHIFTTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
                     Viewer.crystalReportViewer1.ReportSource = EmpSHIFTTransRpt;
                 }
                 else
                 {*/
                Emp_Delay_Rpt EmpTransRpt = new Emp_Delay_Rpt();
                EmpTransRpt.Database.Tables["V_DELAY"].SetDataSource(_Dt);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
                EmpTransRpt.SetParameterValue(EmpTransRpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
                Viewer.crystalReportViewer1.ReportSource = EmpTransRpt;
                //}                      
                Viewer.ShowDialog();
            }
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
            //_cmd = new SqlCommand();
            //_cmd.Connection = frmMainForm._MasterCon;
            //_cmd.CommandType = CommandType.StoredProcedure;
            //_cmd.CommandText = "GET_NUM_HOURS";
            //_cmd.CommandTimeout = 2000;
            //_cmd.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = dtpDateFrom.Value.ToString("yyyy/MM/dd");
            //_cmd.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = dtpDateTo.Value.ToString("yyyy/MM/dd");
            ////Str = "select CARD,NAME,JOB,Department,DATE,[Enter Time],[Exit Time],[WORK HOURS] from VTransaction_IN_OUT_FINAL " + FilterString;
            //_da = new SqlDataAdapter(_cmd);
            //_Dt = new DataTable();
            //_Dt.Reset();
            //_da.Fill(_Dt);

            //////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////

            frmReportViewer2 Viewer = new frmReportViewer2();

            //if (_Dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("Message_No_Records", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    return;
            //}
            SummaryRpt Rpt = new SummaryRpt();
            //Rpt.Database.Tables["GET_NUM_HOURS"].SetDataSource(_Dt);            
            Rpt.SetParameterValue(Rpt.Parameter_From.ParameterFieldName, dtpDateFrom.Text);
            Rpt.SetParameterValue(Rpt.Parameter_To.ParameterFieldName, dtpDateTo.Text);
            Rpt.SetParameterValue(Rpt.Parameter_FROMDATE.ParameterFieldName, dtpDateFrom.Value.ToString("yyyy/MM/dd"));
            Rpt.SetParameterValue(Rpt.Parameter_TODATE.ParameterFieldName, dtpDateFrom.Value.ToString("yyyy/MM/dd"));
            Viewer.crystalReportViewer1.ReportSource = Rpt;
            Viewer.ShowDialog();
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
             
    }
    public class TransDate2
    {
        private int transday;
        private int transmonth;
        private int transyear;
        DateTime TransDateValue;
        public TransDate2(int tday,int tmonth,int tyear)
        {
            transday = tday;
            transmonth = tmonth;
            transyear = tyear;
        }
        public TransDate2()
        {
            transday = 1;
            transmonth = 1;
            transyear = 1987;
        }
        public TransDate2(DateTime transDate)
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