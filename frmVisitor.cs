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
    public partial class frmVisitor : Form
    {
        public static SqlConnection _MasterCon;
        SqlCommand _cmd;
        SqlDataAdapter _da;

        public frmVisitor()
        {
            InitializeComponent();
            _MasterCon = frmMainForm._MasterCon;
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            rptVisitorCard card = new rptVisitorCard ();            

            frmReportViewer2 viewreport = new frmReportViewer2();
            DataTable dt = new DataTable();
            string floor;
            try
            {
                _cmd = new SqlCommand("select * from EMPLOYEE_CARDS where CRD_NO='" + txtCardNo.Text + "'", frmMainForm._MasterCon);
                _da = new SqlDataAdapter(_cmd);
                _da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            frmEmpMange r = new frmEmpMange();
            byte[] imageData;

            if (radioButton1.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath+ @"\Visitor1.jpg");
                floor = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Visitor2.jpg");
                floor = radioButton2.Text;
            }
            else if(radioButton3.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Visitor3.jpg");
                floor = radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Visitor4.jpg");
                floor = radioButton4.Text;
            }
            else if (radioButton5.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Visitor5.jpg");
                floor = radioButton5.Text;
            }
            else if (radioButton6.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Visitor6.jpg");
                floor = radioButton6.Text;
            }
            else if(radioButton7.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Visitor7.jpg");
                floor = radioButton7.Text;
            }
            else if (radioButton8.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Visitor8.jpg");
                floor = radioButton8.Text;
            }
            else if (radioButton9.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Visitor9.jpg");
                floor = radioButton9.Text;
            }
            else //if (radioButton10.Checked)
            {
                imageData = r.ReadFile(Application.StartupPath + @"\Blank_Visitor.jpg");
                floor = "";
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no member");
                return;
            }           


            dt.Rows[0]["PhotoBytes"] = imageData;
            card.Database.Tables["EMPLOYEE_CARDS"].SetDataSource(dt);
            
            card.SetParameterValue(card.Parameter_Num.ParameterFieldName, txtCardNo.Text);

            card.SetParameterValue(card.Parameter_Floor.ParameterFieldName, floor);
            if (checkBox1.Checked)
            {
                card.SetParameterValue(card.Parameter_Visitor.ParameterFieldName, txtCompanyName.Text);

            }
            else
            {
                card.SetParameterValue(card.Parameter_Visitor.ParameterFieldName, "Visitor");
            }
            viewreport.crystalReportViewer1.ReportSource = card;

            viewreport.ShowDialog();

        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            
            
            _cmd = new SqlCommand("select PHOTO from T_IMAGE", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            DataTable dt2 = new DataTable();
            _da.Fill(dt2);
            frmEmpMange r = new frmEmpMange();
            byte[] imageData;

            imageData = r.ReadFile(Application.StartupPath + @"\back.BMP");
               dt2.Rows[0]["PHOTO"] = imageData;                            

            if (!checkBox2.Checked)
            {
                rptCardBack card = new rptCardBack();
                frmReportViewer2 viewreport = new frmReportViewer2();
                card.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                viewreport.crystalReportViewer1.ReportSource = card;
                viewreport.ShowDialog();
            }
            else
            {
                rptCardBack_PS card = new rptCardBack_PS();
                frmReportViewer2 viewreport = new frmReportViewer2();
                card.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                viewreport.crystalReportViewer1.ReportSource = card;
                viewreport.ShowDialog();
            
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCompanyName.Enabled = (checkBox1.Checked) ? true : false;
        }

    }
}