using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;


namespace Time_Attendance
{
    public partial class frmEmpMange : Form
    {
        SqlCommand _cmd;
        SqlDataAdapter _da;
        public DataTable _NavDt = new DataTable();
        public SqlConnection _MasterCon;
        public SqlConnection _MasterCon2;
        public int _index;
        string _ID = "";
        static string ID = "";
        public DataSet _ds;
        string _CardNo = "";
        byte[] imageData;
        static string Path = "";
        static string AccessPassword = "";
        DataRow[] dr;
        public frmEmpMange()
        {
            InitializeComponent();

            DBConnection();
        }

        private void DBConnection()
        {

            // _MasterCon = new SqlConnection("Data Source=.; Initial Catalog= EsofWIN_Finger; user=sa; password=123456");
            try
            {
                _MasterCon = frmMainForm._MasterCon;
                _MasterCon2 = frmMainForm._MasterCon2;
                //_MasterCon.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Server Connection isn't Available, check configeration!!", "connecting to server......");
            }

            StreamReader sr;

            try
            {
                if (Path == "")
                {
                    sr = new StreamReader(Application.StartupPath + @"\AccessDataBase.txt");
                    Path = sr.ReadLine();
                    //                    MessageBox.Show(Path);
                    AccessPassword = sr.ReadLine();
                    sr.Close();
                }
            }
            catch
            {
                //MessageBox.Show("HA HA HA BADA7AK M3AK (:"); //}
            }
        }

        private void Navigator()
        {
            _cmd = new SqlCommand("SELECT     EMPLOYEE_CARDS.CRD_NO, EMPLOYEE_CARDS.CRD_NAME,AR_NAME, EMPLOYEE_CARDS.CRD_STARTING_DATE, EMPLOYEE_CARDS.CRD_EXPIRY_DATE, EMPLOYEE_CARDS.CRD_JOB,AR_JOB, EMPLOYEE_CARDS.CRD_LAST_TRANSACTION_TYPE,EMPLOYEE_CARDS.CRD_DEPARTMENT,AR_DEP,EMPLOYEE_CARDS.PhotoBytes,LOCATION,COMPANY,IN_JOB,ADDRESS,NATIONAL_ID,PHONE,STATUS,PERMITION,VALID_TO,STATUS_DATE FROM EMPLOYEE_CARDS ", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            _NavDt.Reset();
            _da.Fill(_NavDt);
            _index = _NavDt.Rows.Count;

            lblNavNo.Text = Convert.ToString(_NavDt.Rows.Count + 1);
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            if (_NavDt.Rows.Count == 0)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
        }

        private void frmEmpMange_Load(object sender, EventArgs e)
        {

            this.pERMITIONTableAdapter.Connection = frmMainForm._MasterCon;
            this.pERMITIONTableAdapter.Fill(this.timeAttendanceDataSet.PERMITION);

            this.sTATUSTableAdapter.Connection = frmMainForm._MasterCon;
            this.sTATUSTableAdapter.Fill(this.timeAttendanceDataSet.STATUS);

            this.depTableAdapter.Connection = frmMainForm._MasterCon;
            this.depTableAdapter.Fill(this.timeAttendanceDataSet.Dep);

            grpMain.Enabled = false;
            grpMain.Enabled = false;
            Navigator();
            fillgrid();
            if (frmMainForm._ConfigPlace != "cairo")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
            //DBConnection();
        }

        private void fillgrid()
        {
            _ds = new DataSet();
            if (frmMainForm._ConfigPlace == "cairo")
            {
                _cmd = new SqlCommand("SELECT    EMPLOYEE_CARDS.CRD_NO AS [Employee No.], EMPLOYEE_CARDS.CRD_NAME AS [Name],AR_NAME, EMPLOYEE_CARDS.CRD_STARTING_DATE AS [Starting Date], EMPLOYEE_CARDS.CRD_JOB AS [Job],AR_JOB,EMPLOYEE_CARDS.CRD_DEPARTMENT As [Department],AR_DEP,EMPLOYEE_CARDS.PhotoBytes,LOCATION,COMPANY,IN_JOB,ADDRESS,NATIONAL_ID,PHONE,STATUS,PERMITION,VALID_TO,STATUS_DATE  FROM EMPLOYEE_CARDS order by [Name]", frmMainForm._MasterCon);
            }
            else
            {
                _cmd = new SqlCommand("SELECT    EMPLOYEE_CARDS.CRD_NO AS [Employee No.], EMPLOYEE_CARDS.CRD_NAME AS [Name],AR_NAME, EMPLOYEE_CARDS.CRD_STARTING_DATE AS [Starting Date], EMPLOYEE_CARDS.CRD_JOB AS [Job],AR_JOB,EMPLOYEE_CARDS.CRD_DEPARTMENT As [Department],AR_DEP,EMPLOYEE_CARDS.PhotoBytes,LOCATION,COMPANY,IN_JOB,ADDRESS,NATIONAL_ID,PHONE,STATUS,PERMITION,VALID_TO,STATUS_DATE  FROM EMPLOYEE_CARDS where LOCATION='Port Said' order by [Name]", frmMainForm._MasterCon);
            }
            _da = new SqlDataAdapter(_cmd);
            _ds.Reset();
            _da.Fill(_ds);
            GrdEmployees.DataSource = _ds;

        }

        public void ClearControls()
        {
            err1.Clear();
            _ID = "";
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (_CardNo.ToString() == string.Empty)
        //    {
        //        MessageBox.Show("Plese Select Employee");
        //        return;
        //    }          
        //}


        //private void btnFirst_Click(object sender, EventArgs e)
        //{
        //    _index = 0;
        //    Display(_index);
        //    btnFirst.Enabled = false;
        //    btnPrevious.Enabled = false;
        //    if (_NavDt.Rows.Count > 1)
        //    {
        //        btnNext.Enabled = true;
        //        btnLast.Enabled = true;
        //    }
        //}

        //public void btnPrevious_Click(object sender, EventArgs e)
        //{
        //    _index -= 1;
        //    Display(_index);
        //    if (_index < _NavDt.Rows.Count - 1)
        //    {
        //        btnNext.Enabled = true;
        //        btnLast.Enabled = true;
        //    }
        //    else
        //    {
        //        btnNext.Enabled = false;
        //        btnLast.Enabled = false;
        //    }
        //    if (_index == 0)
        //    {
        //        btnPrevious.Enabled = false;
        //        btnFirst.Enabled = false;
        //    }
        //}

        //private void btnNext_Click(object sender, EventArgs e)
        //{
        //    _index += 1;
        //    Display(_index);
        //    btnPrevious.Enabled = true;
        //    btnFirst.Enabled = true;
        //    if (_index == _NavDt.Rows.Count - 1)
        //    {
        //        btnNext.Enabled = false;
        //        btnLast.Enabled = false;
        //    }
        //}

        //private void btnLast_Click(object sender, EventArgs e)
        //{
        //    _index = _NavDt.Rows.Count - 1;
        //    Display(_index);
        //    btnLast.Enabled = false;
        //    btnNext.Enabled = false;
        //    if (_NavDt.Rows.Count > 1)
        //    {
        //        btnPrevious.Enabled = true;
        //        btnFirst.Enabled = true;
        //    }
        //}

        //public void Display(int index)
        //{
        //    txtCardNo.Text = _NavDt.Rows[index]["CRD_NO"].ToString();            
        //    txtemployeename.Text = _NavDt.Rows[index]["CRD_NAME"].ToString();
        //    dtpStartDate.Value = Convert.ToDateTime(_NavDt.Rows[index]["CRD_STARTING_DATE"].ToString());
        //    dtpExpiryDate.Value = Convert.ToDateTime(_NavDt.Rows[index]["CRD_EXPIRY_DATE"].ToString());            
        //    txtJob.Text= _NavDt.Rows[index]["CRD_JOB"].ToString();                                                
        //}

        //private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        //{
        //    GrdEmployees.DisplayLayout.Bands[0].Columns["CRD_NO"].Hidden = false ;
        //    GrdEmployees.DisplayLayout.Bands[0].Columns["CRD_NAME"].Hidden = false ;                                   
        //    GrdEmployees.DisplayLayout.Bands[0].Columns["CRD_LAST_TRANSACTION_TYPE"].Hidden = true;         


        //    e.Layout.Bands[0].Columns["CRD_NO"].Header.Caption = "Employees_Employee_Code";
        //    e.Layout.Bands[0].Columns["CRD_NAME"].Header.Caption = "Employees_Employee_Name";

        //    e.Layout.Bands[0].Columns["CRD_STARTING_DATE"].Header.Caption = "Start Date";
        //    e.Layout.Bands[0].Columns["CRD_EXPIRY_DATE"].Header.Caption = "Expire Date";

        //    e.Layout.Bands[0].Columns["CRD_JOB"].Header.Caption = "JOB";            
        //}

        //private void ultraGrid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        //{
        //    if (e.Row.Index != -1)
        //    {
        //        ID = GrdEmployees.Rows[e.Row.Index].Cells["ID"].Value.ToString();
        //        _CardNo  = GrdEmployees.Rows[e.Row.Index].Cells["CRD_NO"].Value.ToString();
        //        int index = GetIDIndex(_CardNo.Trim(), "CRD_NO", _NavDt);
        //        if (index > -1)
        //        {
        //            _index = index + 1;
        //            btnPrevious_Click(null, null);
        //        }
        //    }

        //}
        //public static int GetIDIndex(string id, string colName, DataTable NavDt)
        //{
        //    for (int i = 0; i < NavDt.Rows.Count; i++)
        //    {
        //        if (id == NavDt.Rows[i][colName].ToString().Trim())
        //            return i;
        //    }
        //    return -1;
        //}        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            PRINT_DIALOG PD = new PRINT_DIALOG();
            PD.ShowDialog();
            //SqlCommand cmd = new SqlCommand(); cmd.CommandTimeout = 2000;
            //cmd.Connection = frmMainForm._MasterCon;
            //cmd.CommandText = "SELECT     EMPLOYEE_CARDS.ID, EMPLOYEE_CARDS.CRD_NO, EMPLOYEE_CARDS.CRD_NAME, EMPLOYEE_CARDS.CRD_STARTING_DATE, EMPLOYEE_CARDS.CRD_EXPIRY_DATE, EMPLOYEE_CARDS.CRD_JOB, EMPLOYEE_CARDS.CRD_LAST_TRANSACTION_TYPE, EMPLOYEE_CARDS.CRD_DEPARTMENT FROM EMPLOYEE_CARDS  order by CRD_NAME";
            //DataTable dt = new DataTable();
            //_da = new SqlDataAdapter(cmd);
            //_da.Fill(dt);

            //frmReportViewer2 Viewer = new frmReportViewer2();
            //EmployeeRpt rpt = new EmployeeRpt();
            //rpt.Database.Tables[0].SetDataSource(dt);

            //Viewer.crystalReportViewer1.ReportSource = rpt;
            //Viewer.ShowDialog();
        }

        private void GrdEmployees_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.Index != -1)
            {
                ID = GrdEmployees.Rows[e.Row.Index].Cells["Employee No."].Value.ToString(); ;
                _CardNo = GrdEmployees.Rows[e.Row.Index].Cells["Employee No."].Value.ToString();


                int index = GetIDIndex(_CardNo.Trim(), "CRD_NO", _NavDt);
                try
                {
                    //Get image data from gridview column.
                    imageData = (byte[])GrdEmployees.Rows[e.Row.Index].Cells["PhotoBytes"].Value;

                    //Initialize image variable
                    Image newImage;
                    //Read image data into a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms.Write(imageData, 0, imageData.Length);

                        //Set image variable value using memory stream.
                        newImage = Image.FromStream(ms, true);
                    }

                    //set picture
                    pictureBox1.Image = newImage;
                }
                catch (Exception ex)
                {
                    pictureBox1.Image = null;
                    //MessageBox.Show(ex.ToString());
                }

                if (index > -1)
                {
                    _index = index + 1;
                    btnPrevious_Click(null, null);
                }
                cmbDep_SelectedIndexChanged(null, null);
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
        private void btnFirst_Click(object sender, EventArgs e)
        {
            _index = 0;
            Display(_index);
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            if (_NavDt.Rows.Count > 1)
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
        }

        public void btnPrevious_Click(object sender, EventArgs e)
        {
            _index -= 1;
            Display(_index);
            if (_index < _NavDt.Rows.Count - 1)
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            if (_index == 0)
            {
                btnPrevious.Enabled = false;
                btnFirst.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _index += 1;
            Display(_index);
            btnPrevious.Enabled = true;
            btnFirst.Enabled = true;
            if (_index == _NavDt.Rows.Count - 1)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _index = _NavDt.Rows.Count - 1;
            Display(_index);
            btnLast.Enabled = false;
            btnNext.Enabled = false;
            if (_NavDt.Rows.Count > 1)
            {
                btnPrevious.Enabled = true;
                btnFirst.Enabled = true;
            }
        }
        public void Display(int index)
        {
            textBox1.Text = "";
            txtCardNo.Text = _NavDt.Rows[index]["CRD_NO"].ToString();
            txtemployeename.Text = _NavDt.Rows[index]["CRD_NAME"].ToString();
            txt_ar_name.Text = _NavDt.Rows[index]["AR_NAME"].ToString();
            txt_address.Text = _NavDt.Rows[index]["ADDRESS"].ToString();
            txt_ar_dep.Text = _NavDt.Rows[index]["AR_DEP"].ToString();
            txt_ar_job.Text = _NavDt.Rows[index]["AR_JOB"].ToString();
            txt_phone.Text = _NavDt.Rows[index]["PHONE"].ToString();
            txt_national_id.Text = _NavDt.Rows[index]["NATIONAL_ID"].ToString();
            dtpStartDate.Value = Convert.ToDateTime(_NavDt.Rows[index]["CRD_STARTING_DATE"].ToString());
            if (_NavDt.Rows[index]["VALID_TO"].ToString() != "")
            {
                dateTimePickerValid.Value = Convert.ToDateTime(_NavDt.Rows[index]["VALID_TO"].ToString());
                dateTimePickerValid.Format = DateTimePickerFormat.Short;
            }
            else
            {
                this.dateTimePickerValid.Format = DateTimePickerFormat.Custom;
                this.dateTimePickerValid.CustomFormat = " ";

            }
            if (_NavDt.Rows[index]["STATUS_DATE"].ToString() != "")
            {
                DTP_STATUS_DATE.Value = Convert.ToDateTime(_NavDt.Rows[index]["STATUS_DATE"].ToString());
                DTP_STATUS_DATE.Format = DateTimePickerFormat.Short;
            }
            else
            {
                this.DTP_STATUS_DATE.Format = DateTimePickerFormat.Custom;
                this.DTP_STATUS_DATE.CustomFormat = " ";
            }
            txtJob.Text = _NavDt.Rows[index]["CRD_JOB"].ToString();
            try
            {
                cmbDep.Text = _NavDt.Rows[index]["CRD_DEPARTMENT"].ToString();
            }
            catch
            {
                cmbDep.Text = "";
            }
            try
            {
                cmb_status.Text = _NavDt.Rows[index]["STATUS"].ToString();
            }
            catch
            {
                cmb_status.Text = "";
            }
            try
            {
                cmb_permit.Text = _NavDt.Rows[index]["PERMITION"].ToString();
            }
            catch
            {
                cmb_permit.Text = "";
            }
            try
            {
                cmbLocation.SelectedItem = _NavDt.Rows[index]["LOCATION"].ToString();
            }
            catch
            {
                cmbLocation.Text = "";
            }
            if (_NavDt.Rows[index]["CRD_DEPARTMENT"].ToString() == "Support Service")
            {
                textBox1.Text = _NavDt.Rows[index]["COMPANY"].ToString();
            }
            else
            {
                if
                (
                _NavDt.Rows[index]["COMPANY"].ToString() == cmbCompany.Items[0].ToString() ||
                _NavDt.Rows[index]["COMPANY"].ToString() == cmbCompany.Items[1].ToString() ||
                _NavDt.Rows[index]["COMPANY"].ToString() == cmbCompany.Items[2].ToString() ||
                _NavDt.Rows[index]["COMPANY"].ToString() == cmbCompany.Items[3].ToString()
                )
                {
                    try
                    {
                        cmbCompany.SelectedItem = _NavDt.Rows[index]["COMPANY"].ToString();
                    }
                    catch
                    {
                        cmbCompany.Text = "";
                    }
                }
                else
                {
                    cmbCompany.SelectedItem = "Other..";
                    textBox1.Text = _NavDt.Rows[index]["COMPANY"].ToString();
                }
            }
            if (_NavDt.Rows[index]["IN_JOB"].ToString() == "1")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (frmMainForm._ConfigPlace == "cairo")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                Btncancel.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            grpMain.Enabled = true;
            //btnAdd.Text = "Update";         
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            Btncancel.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _cmd = new SqlCommand("[sp_UpdateESW_CARDS]", _MasterCon);
                //_cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Add("@CRD_NO", SqlDbType.VarChar).Value = txtCardNo.Text.Trim();
                _cmd.Parameters.Add("@CRD_NAME", SqlDbType.VarChar).Value = txtemployeename.Text.Trim();
                //_cmd.Parameters.Add("@CRD_STARTING_DATE", SqlDbType.DateTime).Value = dtpStartDate.Value.ToShortDateString();
                _cmd.Parameters.Add("@CRD_JOB", SqlDbType.VarChar).Value = txtJob.Text.Trim();

                _cmd.Parameters.Add("@AR_NAME", SqlDbType.VarChar).Value = txt_ar_name.Text.Trim();
                _cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = txt_address.Text.Trim();
                _cmd.Parameters.Add("@AR_DEP", SqlDbType.VarChar).Value = txt_ar_dep.Text.Trim();
                _cmd.Parameters.Add("@AR_JOB", SqlDbType.VarChar).Value = txt_ar_job.Text.Trim();
                _cmd.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = txt_phone.Text.Trim();
                _cmd.Parameters.Add("@NATIONAL_ID", SqlDbType.VarChar).Value = txt_national_id.Text.Trim();

                if (dateTimePickerValid.Format == DateTimePickerFormat.Short)
                { _cmd.Parameters.Add("@VALID_TO", SqlDbType.VarChar).Value = dateTimePickerValid.Value.ToShortDateString(); }
                if (DTP_STATUS_DATE.Format == DateTimePickerFormat.Short)
                { _cmd.Parameters.Add("@STATUS_DATE", SqlDbType.VarChar).Value = DTP_STATUS_DATE.Value.ToShortDateString(); }

                try
                {
                    _cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 50).Value = cmb_status.Text.ToString();
                }
                catch { }
                try
                {
                    _cmd.Parameters.Add("@PERMITION", SqlDbType.VarChar, 50).Value = cmb_permit.Text.ToString();
                }
                catch { }

                try
                {
                    _cmd.Parameters.Add("@CRD_DEPARTMENT", SqlDbType.VarChar, 50).Value = cmbDep.Text.ToString();
                }
                catch
                { }
                _cmd.Parameters.Add("@PhotoBytes", SqlDbType.Image).Value = (object)imageData;
                _cmd.Parameters.Add("@LOCATION", SqlDbType.NVarChar, 50).Value = cmbLocation.SelectedItem;//.ToString();
                if (cmbDep.Text == "Support Service" || cmbCompany.SelectedItem.ToString() == "Other..")
                {
                    _cmd.Parameters.Add("@COMPANY", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                }
                else
                {
                    _cmd.Parameters.Add("@COMPANY", SqlDbType.NVarChar, 50).Value = cmbCompany.SelectedItem.ToString();
                }
                if (checkBox1.Checked)
                {
                    _cmd.Parameters.Add("@IN_JOB", SqlDbType.Int).Value = 1;
                }
                else
                {
                    _cmd.Parameters.Add("@IN_JOB", SqlDbType.Int).Value = 0;
                }
                _MasterCon.Open();
                _cmd.ExecuteNonQuery();
                _MasterCon.Close();

                _cmd.Connection = _MasterCon2;
                _MasterCon2.Open();
                _cmd.ExecuteNonQuery();
                _MasterCon2.Close();

                try
                {
                    Navigator();
                    fillgrid();
                    ClearControls();
                    grpMain.Enabled = false;
                    /*
                    StreamReader _sr = new StreamReader("AccessDataBase.txt");
                    string _Path = _sr.ReadLine();
                    string AccessPassword = _sr.ReadLine();
                    _sr.Close();*/
                    //string[] x = txtemployeename.Text.Split(' ');
                    OleDbConnection AccessCon = new OleDbConnection();
                    //MessageBox.Show(Path);
                    //AccessCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Path +";Persist Security Info=True;";
                    AccessCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Path + ";Jet OLEDB:Database Password=" + AccessPassword + ";Persist Security Info=True;";

                    OleDbCommand oleCmd = new OleDbCommand();
                    oleCmd.Connection = AccessCon;
                    oleCmd.CommandText = "Update personne set Titre='" + txtJob.Text + "' where NumCarte='" + txtCardNo.Text + "' ";
                    //OleDbDataAdapter oda = new OleDbDataAdapter();
                    //oda.SelectCommand = oleCmd;
                    //DataTable dt = new DataTable();
                    //oda.Fill(dt);
                    AccessCon.Open();
                    oleCmd.ExecuteNonQuery();
                    AccessCon.Close();
                    MessageBox.Show("Done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GrdEmployees_InitializeLayout_1(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //GrdEmployees.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;

            GrdEmployees.DisplayLayout.Bands[0].Columns["Employee No."].Hidden = false;
            GrdEmployees.DisplayLayout.Bands[0].Columns["Name"].Hidden = false;
            GrdEmployees.DisplayLayout.Bands[0].Columns["PhotoBytes"].Hidden = false;
            //GrdEmployees.DisplayLayout.Bands[0].Columns["PhotoBytes"].DataType=typeof(Image);
            GrdEmployees.DisplayLayout.Bands[0].Columns["PhotoBytes"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
            //GrdEmployees.DisplayLayout.Override.MinRowHeight=100;


            e.Layout.Bands[0].Columns["Employee No."].Header.Caption = "Employees_Employee_Code";
            e.Layout.Bands[0].Columns["Name"].Header.Caption = "Employees_Employee_Name";

            e.Layout.Bands[0].Columns["Starting Date"].Header.Caption = "Start Date";
            //e.Layout.Bands[0].Columns["CRD_EXPIRY_DATE"].Header.Caption = "Expire Date";

            e.Layout.Bands[0].Columns["Job"].Header.Caption = "JOB";
            e.Layout.Bands[0].Columns["Department"].Header.Caption = "DEPARTMENT";

        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            //Ask user to select file.
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();

            if (dlgRes != DialogResult.Cancel)
            {
                //Set image in picture box
                pictureBox1.ImageLocation = dlg.FileName;
                imageData = ReadFile(dlg.FileName);
                //Provide file path in txtImagePath text box.
                //txtImagePath.Text = dlg.FileName;
            }

        }

        //Open file in to a filestream and read data in a byte array.
        public byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            rptCard card = new rptCard();
            rptWorkersCard card2 = new rptWorkersCard();
            frmReportViewer2 viewreport = new frmReportViewer2();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                _cmd = new SqlCommand("select * from EMPLOYEE_CARDS where CRD_NO='" + ID + "'", frmMainForm._MasterCon);
                _da = new SqlDataAdapter(_cmd);
                _da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            _cmd = new SqlCommand("select PHOTO from T_IMAGE", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            _da.Fill(dt2);
            byte[] _imageData;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no member");
                return;
            }

            if (cmbDep.Text == "Support Service")
            {
                card.Database.Tables["EMPLOYEE_CARDS"].SetDataSource(dt);
                _imageData = ReadFile(Application.StartupPath + @"\worker_card_new.bmp");
                dt2.Rows[0]["PHOTO"] = _imageData;
                card.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                card.SetParameterValue(card.Parameter_Location.ParameterFieldName, cmbLocation.SelectedItem.ToString());
                //if (cmbCompany.SelectedItem.ToString() == "Other..")
                //{
                //    card2.SetParameterValue(card2.Parameter_Company.ParameterFieldName, textBox1.Text);
                //}
                //else
                //{
                card.SetParameterValue(card.Parameter_Company.ParameterFieldName, textBox1.Text);
                //}
                viewreport.crystalReportViewer1.ReportSource = card;
            }
            else
            {

                card.Database.Tables["EMPLOYEE_CARDS"].SetDataSource(dt);
                if (cmbCompany.SelectedItem.ToString() == "IBS" || cmbCompany.SelectedItem.ToString() == "EPSCO")
                {
                    _imageData = ReadFile(Application.StartupPath + @"\worker_card.bmp");
                    card.DataDefinition.FormulaFields["phpc"].Text = "";
                    card.DataDefinition.FormulaFields["«·‘—ﬂ…_«·›—⁄Ê‰Ì…_··» —Ê·"].Text = "";
                    
                }
                else if (cmbCompany.SelectedItem.ToString() == "Other..")
                {

                    _imageData = ReadFile(Application.StartupPath + @"\worker_card.bmp");
                    card.DataDefinition.FormulaFields["phpc"].Text = "";
                    card.DataDefinition.FormulaFields["«·‘—ﬂ…_«·›—⁄Ê‰Ì…_··» —Ê·"].Text = "";
                }
                else
                {
                    _imageData = ReadFile(Application.StartupPath + @"\card.bmp");
                }

                dt2.Rows[0]["PHOTO"] = _imageData;
                card.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                card.SetParameterValue(card2.Parameter_Location.ParameterFieldName, cmbLocation.SelectedItem.ToString());
                if (cmbCompany.SelectedItem.ToString() == "Other..")
                {                    
                    
                    card.SetParameterValue(card2.Parameter_Company.ParameterFieldName, textBox1.Text);
                }
                else
                {
                    card.SetParameterValue(card.Parameter_Company.ParameterFieldName, cmbCompany.SelectedItem.ToString());
                }
                viewreport.crystalReportViewer1.ReportSource = card;
            }
            viewreport.ShowDialog();
            //card.PrintOptions.PrinterName = _cardPrinter;
            //card.PrintToPrinter(1, true, 1, 1);
        }
        private void glassButton3_Click(object sender, EventArgs e)
        {
            rptCardBack card = new rptCardBack();
            rptCardBack_PS card2 = new rptCardBack_PS();
            frmReportViewer2 viewreport = new frmReportViewer2();
            _cmd = new SqlCommand("select PHOTO from T_IMAGE", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            DataTable dt2 = new DataTable();
            _da.Fill(dt2);

            byte[] _imageData;
            if (cmbDep.Text == "Support Service" || cmbCompany.SelectedItem.ToString() == "EPSCO")
            {
                _imageData = ReadFile(Application.StartupPath + @"\worker_back_new.bmp");
                dt2.Rows[0]["PHOTO"] = _imageData;            
            }
            else
            {
                if (cmbCompany.SelectedItem.ToString() == "IBS")
                {
                    _imageData = ReadFile(Application.StartupPath + @"\worker_back_new.bmp");
                    dt2.Rows[0]["PHOTO"] = _imageData;
                }
                else
                {
            _imageData = ReadFile(Application.StartupPath + @"\back.bmp");
            dt2.Rows[0]["PHOTO"] = _imageData;
            }                                
        }
            if (cmbLocation.SelectedItem.ToString() == "Cairo")
            {
                card.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                viewreport.crystalReportViewer1.ReportSource = card;
            }
            else if (cmbLocation.SelectedItem.ToString() == "Port Said")
            {
                card2.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                viewreport.crystalReportViewer1.ReportSource = card2;
            }
            viewreport.ShowDialog();
        }

        private void cmbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDep.SelectedValue.ToString() != "")
                {
                    txt_ar_dep.Text = cmbDep.SelectedValue.ToString();
                }
                else
                { txt_ar_dep.Text = cmbDep.SelectedValue.ToString(); }
            }
            catch { }
            try
            {
                if (cmbDep.SelectedValue.ToString() == "Support Service")
                {
                    cmbCompany.Enabled = false;
                    textBox1.Enabled = true;
                }
                else
                {
                    cmbCompany.Enabled = true;
                    textBox1.Enabled = false;
                }
            }
            catch { }
        }

        //private void frmEmpMange_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    if (frmMainForm._ConfigPlace == "cairo")
        //    {
        //        StreamWriter file = new StreamWriter(@"D:\Back Up Logs\Users\Users.txt");

        //        for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
        //        {
        //            for (int c = 0; c < _ds.Tables[0].Columns.Count; c++)
        //            {
        //                if (c + 1 == _ds.Tables[0].Columns.Count)
        //                {
        //                    file.WriteLine(_ds.Tables[0].Rows[i][c].ToString());
        //                }
        //                else
        //                {
        //                    if (c == 6)
        //                    {
        //                        try
        //                        {
        //                            file.Write(BitConverter.ToInt32((byte[])_ds.Tables[0].Rows[i][c], 0));
        //                            //file.Write(System.Text.ASCIIEncoding.ASCII.GetString((byte[])_ds.Tables[0].Rows[i][c]));
        //                        }
        //                        catch { file.Write(""); }
        //                    }
        //                    else
        //                    { file.Write(_ds.Tables[0].Rows[i][c].ToString()); }

        //                    file.Write(",");
        //                }
        //            }
        //        }
        //        file.Close();

        //        _cmd = new SqlCommand("SELECT * FROM Dep", frmMainForm._MasterCon);
        //        _da = new SqlDataAdapter(_cmd);
        //        DataTable DT = new DataTable();
        //        _da.Fill(DT);

        //        StreamWriter file2 = new StreamWriter(@"D:\Back Up Logs\Users\DEP.txt");

        //        for (int T = 0; T < DT.Rows.Count; T++)
        //        {
        //            for (int c = 0; c < DT.Columns.Count; c++)
        //            {
        //                if (c + 1 == DT.Columns.Count)
        //                {
        //                    file2.WriteLine(DT.Rows[T][c]);
        //                }
        //                else
        //                {
        //                    file2.Write(DT.Rows[T][c]);
        //                    file2.Write(",");
        //                }
        //            }
        //        }
        //        file2.Close();
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
            DialogResult dlgRes = dlg.ShowDialog();

            if (dlgRes != DialogResult.Cancel)
            {
                txtFileLocaT.Text = dlg.FileName;
            }
            //DialogResult res = folderBrowserDialog1.ShowDialog();
            //if (res == DialogResult.OK)
            //    txtFileLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void glassButton4_Click(object sender, EventArgs e)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFileLocaT.Text + //@"\New Serial Phpc.xlsx" +
                                         ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\";";

            var output = new DataSet();
            //string xx = x;

            System.Data.DataTable DT = new System.Data.DataTable();

            using (var conn = new OleDbConnection(strConn))
            {
                conn.Open();

                var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                var cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter xlAdapter = new OleDbDataAdapter(cmd);
                xlAdapter.Fill(DT);
            }




            //string[] x = txtemployeename.Text.Split(' ');
            OleDbConnection AccessCon = new OleDbConnection();
            AccessCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Path + ";Jet OLEDB:Database Password=" + AccessPassword + ";Persist Security Info=True;";
            OleDbCommand oleCmd = new OleDbCommand();
            oleCmd.Connection = AccessCon;

            for (int i = 2; i < DT.Rows.Count; i++)
            {
                //UPDATE IN SQL DATABASE
                _cmd = new SqlCommand("UPDATE EMPLOYEE_CARDS SET CRD_NO='" + DT.Rows[i][1].ToString() + "' where CRD_NO='" + DT.Rows[i][0].ToString() + "'", _MasterCon);
                _cmd.CommandType = CommandType.Text;
                _MasterCon.Open();
                _cmd.ExecuteNonQuery();
                _MasterCon.Close();

                _cmd.Connection = _MasterCon2;
                _MasterCon2.Open();
                _cmd.ExecuteNonQuery();
                _MasterCon2.Close();


                _cmd = new SqlCommand("UPDATE EMPLOYEE_TRANSACTIONS SET TRN_CARD_NO='" + DT.Rows[i][1].ToString() + "' where TRN_CARD_NO='" + DT.Rows[i][0].ToString() + "'", _MasterCon);
                _cmd.CommandType = CommandType.Text;
                _MasterCon.Open();
                _cmd.ExecuteNonQuery();
                _MasterCon.Close();



                //UPDATE IN ACCESS DATABASE
                oleCmd.CommandText = "Update personne set NumCarte='" + DT.Rows[i][1].ToString() + "' where NumCarte='" + DT.Rows[i][0].ToString() + "' ";
                AccessCon.Open();
                oleCmd.ExecuteNonQuery();
                AccessCon.Close();
            }
            MessageBox.Show("Done.");
        }

        private void glassButton6_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Application.StartupPath + @"\AccessDataBase.txt");
            string Path = sr.ReadLine();
            string AccessPassword = sr.ReadLine();
            sr.Close();
            //string[] x = txtemployeename.Text.Split(' ');
            OleDbConnection AccessCon = new OleDbConnection();
            AccessCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Path + ";Jet OLEDB:Database Password=" + AccessPassword + ";Persist Security Info=True;";
            OleDbCommand oleCmd = new OleDbCommand();
            oleCmd.Connection = AccessCon;

            oleCmd.CommandText = "select Nom_groupe from groupe";
            OleDbDataAdapter ODBA = new OleDbDataAdapter();
            ODBA.SelectCommand = oleCmd;
            DataTable GDT = new DataTable();
            ODBA.Fill(GDT);
            for (int x = 0; x < GDT.Rows.Count; x++)
            {
                oleCmd = new OleDbCommand();
                oleCmd.Connection = AccessCon;
                oleCmd.CommandText = "select NumCarte from personne";
                ODBA = new OleDbDataAdapter();
                ODBA.SelectCommand = oleCmd;
                DataTable dt = new DataTable();
                ODBA.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    oleCmd = new OleDbCommand();
                    oleCmd.Connection = AccessCon;
                    oleCmd.CommandText = "insert into groupepersonne (NumCarte,Nom_groupe) values ('" + dt.Rows[i][0].ToString() + "','" + GDT.Rows[x][0].ToString() + "')";
                    AccessCon.Open();
                    try
                    {
                        oleCmd.ExecuteNonQuery();
                    }
                    catch (Exception EX)
                    {
                        if (!EX.Message.Contains("because they would create duplicate values in the index"))
                        {
                            MessageBox.Show(EX.Message.ToString());
                        }
                    }
                    AccessCon.Close();
                }
            }
            MessageBox.Show("Done.");
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCompany.SelectedItem.ToString() == "Other..")
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void glassButton7_Click(object sender, EventArgs e)
        {
            if (txtCardNo.Text != null && txtCardNo.Text != "")
            {
                DialogResult dialog_reault =
                MessageBox.Show("Are you sure you want to delete this log?", "confirm", MessageBoxButtons.OKCancel);
                if (dialog_reault == DialogResult.OK)
                {
                    _cmd = new SqlCommand("DELETE FROM EMPLOYEE_CARDS WHERE CRD_NO='" + txtCardNo.Text + "'       DELETE FROM EMPLOYEE_TRANSACTIONS  WHERE TRN_CARD_NO='" + txtCardNo.Text + "'", _MasterCon);
                    _cmd.CommandType = CommandType.Text;
                    _MasterCon.Open();
                    _cmd.ExecuteNonQuery();
                    _MasterCon.Close();

                    _cmd.Connection = _MasterCon2;
                    _cmd.CommandText = "DELETE FROM EMPLOYEE_CARDS WHERE CRD_NO='" + txtCardNo.Text + "'       DELETE FROM EMPLOYEE_TRANSACTIONS_MONITOR WHERE TRN_CARD_NO='" + txtCardNo.Text + "'";
                    _MasterCon2.Open();
                    
                    _cmd.ExecuteNonQuery();
                    _MasterCon2.Close();

                    Navigator();
                    fillgrid();
                    ClearControls();
                    grpMain.Enabled = false;
                    MessageBox.Show("DONE..");
                }
            }
        }

        private void glassButton8_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
            DialogResult dlgRes = dlg.ShowDialog();

            if (dlgRes != DialogResult.Cancel)
            {
                TXT_PATH.Text = dlg.FileName;
            }
        }

        private void glassButton9_Click(object sender, EventArgs e)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TXT_PATH.Text + //@"\New Serial Phpc.xlsx" +
                                         ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\";";

            var output = new DataSet();
            //string xx = x;

            System.Data.DataTable DT = new System.Data.DataTable();

            using (var conn = new OleDbConnection(strConn))
            {
                conn.Open();

                var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                var cmd = new OleDbCommand("SELECT * FROM [EMPLOYEE_CARDS$]", conn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter xlAdapter = new OleDbDataAdapter(cmd);
                xlAdapter.Fill(DT);
            }

            for (int i = 1; i < DT.Rows.Count; i++)
            {
                //UPDATE IN SQL DATABASE
                if (DT.Rows[i][0].ToString() != "")
                {
                    string command =
                       "UPDATE EMPLOYEE_CARDS SET "
                        // + " ,CRD_NAME ='" + DT.Rows[i][0].ToString() + "' "
                        // + " ,CRD_JOB ='" + DT.Rows[i][0].ToString() + "' "
                        // + " ,CRD_DEPARTMENT ='" + DT.Rows[i][0].ToString() + "' "
                        // + " ,COMPANY ='" + DT.Rows[i][0].ToString() + "' "
                        // + " ,LOCATION ='" + DT.Rows[i][0].ToString() + "' "
                        // + " ,IN_JOB =" + DT.Rows[i][0].ToString() + " "
                       + " AR_NAME ='" + DT.Rows[i][7].ToString() + "' "
                       + " ,ADDRESS ='" + DT.Rows[i][8].ToString() + "' "
                       + " ,NATIONAL_ID ='" + DT.Rows[i][9].ToString() + "' "
                       + " ,PHONE ='" + DT.Rows[i][10].ToString() + "' "
                       + " ,STATUS ='" + DT.Rows[i][11].ToString() + "' "
                       + " ,PERMITION ='" + DT.Rows[i][12].ToString() + "' ";
                    if (DT.Rows[i][13].ToString() != "")
                    {
                        command += " , VALID_TO ='" + DateTime.ParseExact(DT.Rows[i][13].ToString(), "dd/MM/yyyy", null).ToString("MM/dd/yyyy") + "' ";
                    }

                    command +=
                      " ,AR_JOB ='" + DT.Rows[i][14].ToString() + "' "
                    + " ,AR_DEP ='" + DT.Rows[i][15].ToString() + "' ";

                    if (DT.Rows[i][16].ToString() != "")
                    {
                        command += " , STATUS_DATE ='" + DateTime.ParseExact(DT.Rows[i][16].ToString(), "dd/MM/yyyy", null) + "' ";
                    }
                    command += " where CRD_NO='" + DT.Rows[i][0].ToString() + "'";

                    _cmd = new SqlCommand(command, _MasterCon);
                    _cmd.CommandType = CommandType.Text;
                    _MasterCon.Open();
                    _cmd.ExecuteNonQuery();
                    _MasterCon.Close();

                    _cmd.Connection = _MasterCon2;
                    _MasterCon2.Open();
                    _cmd.ExecuteNonQuery();
                    _MasterCon2.Close();
                }
            }
            MessageBox.Show("Done.");
        }

        private void DTP_STATUS_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.DTP_STATUS_DATE.Format = DateTimePickerFormat.Short;
        }

        private void dateTimePickerValid_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePickerValid.Format = DateTimePickerFormat.Short;
        }

        private void glassButton11_Click(object sender, EventArgs e)
        {
            rptCard_old card = new rptCard_old();
            rptWorkersCard card2 = new rptWorkersCard();
            frmReportViewer2 viewreport = new frmReportViewer2();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                _cmd = new SqlCommand("select * from EMPLOYEE_CARDS where CRD_NO='" + ID + "'", frmMainForm._MasterCon);
                _da = new SqlDataAdapter(_cmd);
                _da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            _cmd = new SqlCommand("select PHOTO from T_IMAGE", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            _da.Fill(dt2);
            byte[] _imageData;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no member");
                return;
            }

            if (cmbDep.Text == "Support Service")
            {
                card2.Database.Tables["EMPLOYEE_CARDS"].SetDataSource(dt);
                _imageData = ReadFile(Application.StartupPath + @"\worker_card.bmp");
                dt2.Rows[0]["PHOTO"] = _imageData;
                card2.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                card2.SetParameterValue(card2.Parameter_Location.ParameterFieldName, cmbLocation.SelectedItem.ToString());
                //if (cmbCompany.SelectedItem.ToString() == "Other..")
                //{
                //    card2.SetParameterValue(card2.Parameter_Company.ParameterFieldName, textBox1.Text);
                //}
                //else
                //{
                card2.SetParameterValue(card2.Parameter_Company.ParameterFieldName, textBox1.Text);
                //}
                viewreport.crystalReportViewer1.ReportSource = card2;
            }
            else
            {

                card.Database.Tables["EMPLOYEE_CARDS"].SetDataSource(dt);
                if (cmbCompany.SelectedItem.ToString() == "IBS" || cmbCompany.SelectedItem.ToString() == "EPSCO")
                {
                    _imageData = ReadFile(Application.StartupPath + @"\worker_card.bmp");
                }
                else
                {
                    _imageData = ReadFile(Application.StartupPath + @"\card_old.bmp");
                }

                dt2.Rows[0]["PHOTO"] = _imageData;
                card.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                card.SetParameterValue(card2.Parameter_Location.ParameterFieldName, cmbLocation.SelectedItem.ToString());
                if (cmbCompany.SelectedItem.ToString() == "Other..")
                {
                    card.SetParameterValue(card2.Parameter_Company.ParameterFieldName, textBox1.Text);
                }
                else
                {
                    card.SetParameterValue(card.Parameter_Company.ParameterFieldName, cmbCompany.SelectedItem.ToString());
                }
                viewreport.crystalReportViewer1.ReportSource = card;
            }
            viewreport.ShowDialog();
            //card.PrintOptions.PrinterName = _cardPrinter;
            //card.PrintToPrinter(1, true, 1, 1);
        }
        private void glassButton10_Click(object sender, EventArgs e)
        {
            rptCardBack_old card = new rptCardBack_old();
            rptCardBack_PS_old card2 = new rptCardBack_PS_old();
            frmReportViewer2 viewreport = new frmReportViewer2();
            _cmd = new SqlCommand("select PHOTO from T_IMAGE", frmMainForm._MasterCon);
            _da = new SqlDataAdapter(_cmd);
            DataTable dt2 = new DataTable();
            _da.Fill(dt2);

            byte[] _imageData;
            if (cmbDep.Text == "Support Service" || cmbCompany.SelectedItem.ToString() == "EPSCO")
            {
                _imageData = ReadFile(Application.StartupPath + @"\worker_back.bmp");
                dt2.Rows[0]["PHOTO"] = _imageData;
            }
            else
            {
                if (cmbCompany.SelectedItem.ToString() == "IBS")
                {
                    _imageData = ReadFile(Application.StartupPath + @"\worker_back.bmp");
                    dt2.Rows[0]["PHOTO"] = _imageData;
                }
                else
                {
                    _imageData = ReadFile(Application.StartupPath + @"\back_old.bmp");
                    dt2.Rows[0]["PHOTO"] = _imageData;
                }
            }
            if (cmbLocation.SelectedItem.ToString() == "Cairo")
            {
                card.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                viewreport.crystalReportViewer1.ReportSource = card;
            }
            else if (cmbLocation.SelectedItem.ToString() == "Port Said")
            {
                card2.Database.Tables["T_IMAGE"].SetDataSource(dt2);
                viewreport.crystalReportViewer1.ReportSource = card2;
            }
            viewreport.ShowDialog();
        }

    }
}