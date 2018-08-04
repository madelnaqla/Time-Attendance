using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Time_Attendance
{
    public partial class PRINT_DIALOG : Form
    {
        public PRINT_DIALOG()
        {
            InitializeComponent();
        }

        private void PRINT_DIALOG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timeAttendanceDataSet.STATUS' table. You can move, or remove it, as needed.
            this.sTATUSTableAdapter.Connection = frmMainForm._MasterCon;
            this.sTATUSTableAdapter.Fill(this.timeAttendanceDataSet.STATUS);
            // TODO: This line of code loads data into the 'timeAttendanceDataSet.PERMITION' table. You can move, or remove it, as needed.
            this.pERMITIONTableAdapter.Connection = frmMainForm._MasterCon;
            this.pERMITIONTableAdapter.Fill(this.timeAttendanceDataSet.PERMITION);
            // TODO: This line of code loads data into the 'timeAttendanceDataSet.Dep' table. You can move, or remove it, as needed.
            this.depTableAdapter.Connection = frmMainForm._MasterCon;
            this.depTableAdapter.Fill(this.timeAttendanceDataSet.Dep);

            DataRow row = this.timeAttendanceDataSet.Dep.NewRow();
            row["DepartmentTitle"] = ""; //insert a blank row - you can even write something lile  = "Please select bellow...";
            this.timeAttendanceDataSet.Dep.Rows.InsertAt(row, 0); //insert new to to index 0 (on top=
            cmbDep.SelectedIndex = 0;


            DataRow row2 = this.timeAttendanceDataSet.STATUS.NewRow();
            row2["STATUS_NAME"] = ""; //insert a blank row - you can even write something lile  = "Please select bellow...";
            this.timeAttendanceDataSet.STATUS.Rows.InsertAt(row2, 0); //insert new to to index 0 (on top=
            cmb_status.SelectedIndex = 0;


            DataRow row3 = this.timeAttendanceDataSet.PERMITION.NewRow();
            row3["PERMIT"] = ""; //insert a blank row - you can even write something lile  = "Please select bellow...";
            this.timeAttendanceDataSet.PERMITION.Rows.InsertAt(row3, 0); //insert new to to index 0 (on top=
            cmb_permit.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(); cmd.CommandTimeout = 2000;
            cmd.Connection = frmMainForm._MasterCon;
            string FilterString = "";
            bool FilterFlag = false;
            string inFilter = "";

            if (cmbLocation.SelectedItem != null)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " LOCATION ='" + cmbLocation.SelectedItem.ToString() + "' ";
            }
            if (cmbCompany.SelectedItem != null)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " COMPANY = '" + cmbCompany.SelectedItem.ToString() + "' ";
            }
            
            if (cmbDep.SelectedValue.ToString() != "")
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + "CRD_DEPARTMENT = '" + cmbDep.SelectedValue.ToString() + "'";
            }
            
            if (cmb_permit.SelectedValue.ToString() != "")
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " PERMITION = '" + cmb_permit.SelectedValue.ToString() + "' and (VALID_TO between '" + dateTimePickerValid.Text + "' and '" + dateTimePickervalidTo.Text + "')  ";
            }

            if (cmb_status.SelectedValue.ToString() != "")
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " STATUS = '" + cmb_permit.SelectedValue.ToString() + "'";
            }

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

                FilterString += initalFilter + " IN_JOB = 1";
            }

            if (!checkBox1.Checked)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " IN_JOB = 0";
            }
            inFilter = "";
            if (!FilterFlag)
            {
                inFilter = " where ";
                FilterFlag = true;
            }
            else
                inFilter = " and ";

            FilterString += inFilter + " CRD_NAME NOT LIKE '%V' ";

            cmd.CommandText = "SELECT EMPLOYEE_CARDS.CRD_NO, EMPLOYEE_CARDS.CRD_NAME, EMPLOYEE_CARDS.CRD_STARTING_DATE, EMPLOYEE_CARDS.CRD_EXPIRY_DATE, EMPLOYEE_CARDS.CRD_JOB, EMPLOYEE_CARDS.CRD_LAST_TRANSACTION_TYPE, EMPLOYEE_CARDS.CRD_DEPARTMENT,EMPLOYEE_CARDS.LOCATION,EMPLOYEE_CARDS.COMPANY FROM EMPLOYEE_CARDS  " + FilterString + "    order by CRD_NAME";
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(cmd);
            _da.Fill(dt);

            frmReportViewer2 Viewer = new frmReportViewer2();
            EmployeeRpt2 rpt = new EmployeeRpt2();
            rpt.Database.Tables[0].SetDataSource(dt);

            Viewer.crystalReportViewer1.ReportSource = rpt;
            Viewer.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(); cmd.CommandTimeout = 2000;
            cmd.Connection = frmMainForm._MasterCon;
            string FilterString = "";
            bool FilterFlag = false;
            string inFilter = "";

            if (cmbLocation.SelectedItem != null)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " LOCATION ='" + cmbLocation.SelectedItem.ToString() + "' ";
            }
            if (cmbCompany.SelectedItem != null)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " COMPANY = '" + cmbCompany.SelectedItem.ToString() + "' ";
            }

            if (cmbDep.SelectedValue.ToString() != "")
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + "CRD_DEPARTMENT = '" + cmbDep.SelectedValue.ToString() + "'";
            }

            if (cmb_permit.SelectedValue.ToString() != "")
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " PERMITION = '" + cmb_permit.SelectedValue.ToString() + "'";
            }

            if (cmb_status.SelectedValue.ToString() != "")
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " STATUS = '" + cmb_permit.SelectedValue.ToString() + "'";
            }

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

                FilterString += initalFilter + " IN_JOB = 1";
            }

            if (!checkBox1.Checked)
            {
                string initalFilter = "";
                if (!FilterFlag)
                {
                    initalFilter = " where ";
                    FilterFlag = true;
                }
                else
                    initalFilter = " and ";

                FilterString += initalFilter + " IN_JOB = 0";
            }
            inFilter = "";
            if (!FilterFlag)
            {
                inFilter = " where ";
                FilterFlag = true;
            }
            else
                inFilter = " and ";

            FilterString += inFilter + " CRD_NAME NOT LIKE '%V' ";

            cmd.CommandText = "SELECT EMPLOYEE_CARDS.CRD_NO, EMPLOYEE_CARDS.CRD_NAME, EMPLOYEE_CARDS.CRD_STARTING_DATE, EMPLOYEE_CARDS.CRD_EXPIRY_DATE, EMPLOYEE_CARDS.CRD_JOB, EMPLOYEE_CARDS.CRD_LAST_TRANSACTION_TYPE, EMPLOYEE_CARDS.CRD_DEPARTMENT,EMPLOYEE_CARDS.LOCATION,EMPLOYEE_CARDS.COMPANY,AR_NAME,ADDRESS,NATIONAL_ID,PHONE,STATUS,PERMITION,VALID_TO,AR_JOB,AR_DEP,STATUS_DATE FROM EMPLOYEE_CARDS  " + FilterString + "    order by CRD_NAME";
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(cmd);
            _da.Fill(dt);

            frmReportViewer2 Viewer = new frmReportViewer2();
            EmployeeRptALL rpt = new EmployeeRptALL();
            rpt.Database.Tables[0].SetDataSource(dt);

            Viewer.crystalReportViewer1.ReportSource = rpt;
            Viewer.ShowDialog();
            this.Close();
        }

        private void cmb_permit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_permit.SelectedValue.ToString() != "")
            {
                dateTimePickerValid.Enabled = true;
                dateTimePickervalidTo.Enabled = true;
            }
            else
            {
                dateTimePickerValid.Enabled = false;
                dateTimePickervalidTo.Enabled = false;
            }
        }      
    }
}
