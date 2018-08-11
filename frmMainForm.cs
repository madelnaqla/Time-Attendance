using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using Infragistics.Win.Misc;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.IO;


namespace Time_Attendance
{
    public partial class frmMainForm : Form
    {
        public static SqlConnection _MasterCon;
        public static SqlConnection _MasterCon2;
        public static string ServerName;
        public static string _ConfigPlace;
        public static string[] _Machin;
        public static int ROLE=1;

        public frmMainForm()
        {
            InitializeComponent();
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + @"\Server.txt");
                ServerName = sr.ReadLine();
                string UserName = sr.ReadLine();
                string Password = sr.ReadLine();
                sr.Close();
                _MasterCon = new SqlConnection("Data Source=" + ServerName + ";Initial Catalog=TimeAttendance;User ID=" + UserName + ";Password=" + Password);
                //_MasterCon2 = new SqlConnection("Data Source=" + ServerName + ";Initial Catalog=TimeAttendance_MONITOR;User ID=" + UserName + ";Password=" + Password);
                _MasterCon2 = new SqlConnection("Data Source=" + ServerName + ";Initial Catalog=TimeAttendance;User ID=" + UserName + ";Password=" + Password);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Close();
            }
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + @"\configuration.txt");
                _ConfigPlace = sr.ReadLine();
                _Machin = new string[8];
                string m = sr.ReadLine();
                int x = 0;
                while (m != null)
                {
                    _Machin[x] = m;
                    m = sr.ReadLine();
                    x++;
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Close();
            }
        }

        private bool CheckFormOpen(Form f)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (f.Text == childForm.Text)
                {
                    childForm.Activate();
                    return true;
                }
            }
            return false;
        }


        private void frmMainForm_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.frm = this;
            frm.ShowDialog();
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + @"\LastUpdate.txt");
                lblLastUpdate.Text = sr.ReadLine();
                sr.Close();
            }
            catch
            {
                lblLastUpdate.Text = "";
            }

            SqlCommand com = new SqlCommand("SELECT convert(char(10),MAX(TRN_TIME),103) AS Date , convert(char(19),MAX(TRN_TIME),8) AS Time FROM EMPLOYEE_TRANSACTIONS", _MasterCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                lblMaxUpdate.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
            }
            else
            {
                lblMaxUpdate.Text = "";
            }

        }
        public static int GetIDIndex(string id, string colName, DataTable NavDt)
        {
            for (int i = 0; i < NavDt.Rows.Count; i++)
            {
                if (id == NavDt.Rows[i][colName].ToString().Trim())
                    return i;
            }
            return -1;
        }
        private void ultraToolbarsManager1_ToolClick_1(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (ROLE == 1)
            {
                switch (e.Tool.Key)
                {
                    case "Exit Application":
                        Application.Exit();
                        break;
                    case "CARDS":
                        frmEmpMange rr = new frmEmpMange();
                        if (!CheckFormOpen(rr))
                        {
                            rr.MdiParent = this;
                            rr.Text = "Employee";
                            rr.Show();
                        }
                        break;
                    case "LoadTransation":
                        DeviceSetting rr2 = new DeviceSetting();
                        rr2.MdiParent = this;
                        rr2.Text = "Load Transations";
                        //rr2.ShowDialog();
                        rr2.Show();
                        break;
                    case "Transaction":
                        //if (frmMainForm._ConfigPlace == "cairo")
                        //{
                        FrmEmpTrans rr3 = new FrmEmpTrans();
                        if (!CheckFormOpen(rr3))
                        {
                            rr3.MdiParent = this;
                            rr3.Text = "Transations";
                            rr3.Show();
                        }
                        //}                    
                        break;
                    case "AllTransaction":
                        FrmAllEmpTrans rr4 = new FrmAllEmpTrans();
                        if (!CheckFormOpen(rr4))
                        {
                            rr4.MdiParent = this;
                            rr4.Text = "All Transations";
                            rr4.Show();
                        }
                        break;
                    case "Users":
                        frmUsers rr5 = new frmUsers();
                        if (!CheckFormOpen(rr5))
                        {
                            rr5.MdiParent = this;
                            rr5.Text = "Users";
                            rr5.Show();
                        }
                        break;
                    case "Department":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmDepartments rr6 = new FrmDepartments();
                            if (!CheckFormOpen(rr6))
                            {
                                rr6.MdiParent = this;
                                rr6.Text = "Department";
                                rr6.Show();
                            }
                        }
                        break;
                    case "VisitorCard":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            frmVisitor rr7 = new frmVisitor();
                            //rr2.MdiParent = this;
                            rr7.Text = "Print Visitor Cards";
                            rr7.ShowDialog();
                        }
                        break;

                    case "Shift":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmShifts rr8 = new FrmShifts();
                            if (!CheckFormOpen(rr8))
                            {
                                rr8.MdiParent = this;
                                rr8.Text = "Shifts";
                                rr8.Show();
                            }
                        }
                        break;
                    case "ChangeID":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmChangeID rr9 = new FrmChangeID();
                            //rr8.MdiParent = this;
                            rr9.Text = "Change ID";
                            rr9.ShowDialog();
                        }
                        break;
                    case "NOW_IN":
                        //if (frmMainForm._ConfigPlace == "cairo")
                        //{
                        FrmNowIN rr10 = new FrmNowIN();
                        if (!CheckFormOpen(rr10))
                        {
                            rr10.MdiParent = this;
                            rr10.Text = "In Company";
                            rr10.Show();
                        }
                        //}
                        break;
                    case "DELAY":
                        //    if (frmMainForm._ConfigPlace == "cairo")
                        //    {
                        Frm_Delay rr11 = new Frm_Delay();
                        if (!CheckFormOpen(rr11))
                        {
                            rr11.MdiParent = this;
                            rr11.Text = "Delays";
                            rr11.Show();
                        }
                        //    }
                        break;
                    case "daylight":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            Frm_change rr12 = new Frm_change();
                            if (!CheckFormOpen(rr12))
                            {
                                //rr12.MdiParent = this;
                                rr12.Text = "Daylight";
                                rr12.ShowDialog();
                            }
                        }
                        break;
                    case "SEND DATA":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            Frm_Copy_Pic rr100 = new Frm_Copy_Pic();
                            if (!CheckFormOpen(rr100))
                            {
                                //rr100.MdiParent = this;
                                rr100.Text = "SEND";
                                rr100.ShowDialog();
                            }
                        }
                        break;
                    case "PERMIT":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmPermit rr101 = new FrmPermit();
                            if (!CheckFormOpen(rr101))
                            {
                                rr101.MdiParent = this;
                                rr101.Text = "Permit";
                                rr101.Show();
                            }
                        }
                        break;
                    case "STATUS":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmStatus rr102 = new FrmStatus();
                            if (!CheckFormOpen(rr102))
                            {
                                rr102.MdiParent = this;
                                rr102.Text = "Status";
                                rr102.Show();
                            }
                        }
                        break;
                }
            }
            else if(ROLE==2) 
            {
                switch (e.Tool.Key)
                {
                    case "Exit Application":
                        Application.Exit();
                        break;
                    case "CARDS":
                        frmEmpMange rr = new frmEmpMange();
                        if (!CheckFormOpen(rr))
                        {
                            rr.MdiParent = this;
                            rr.Text = "Employee";
                            rr.Show();
                        }
                        break;                                                            
                    case "Department":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmDepartments rr6 = new FrmDepartments();
                            if (!CheckFormOpen(rr6))
                            {
                                rr6.MdiParent = this;
                                rr6.Text = "Department";
                                rr6.Show();
                            }
                        }
                        break;                    
                    case "Shift":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmShifts rr8 = new FrmShifts();
                            if (!CheckFormOpen(rr8))
                            {
                                rr8.MdiParent = this;
                                rr8.Text = "Shifts";
                                rr8.Show();
                            }
                        }
                        break;                                        
                    case "PERMIT":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmPermit rr101 = new FrmPermit();
                            if (!CheckFormOpen(rr101))
                            {
                                rr101.MdiParent = this;
                                rr101.Text = "Permit";
                                rr101.Show();
                            }
                        }
                        break;
                    case "STATUS":
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            FrmStatus rr102 = new FrmStatus();
                            if (!CheckFormOpen(rr102))
                            {
                                rr102.MdiParent = this;
                                rr102.Text = "Status";
                                rr102.Show();
                            }
                        }
                        break;
                }
            }
        }
    }
}
