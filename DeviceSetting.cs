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
    public partial class DeviceSetting : Form
    {
        #region Public var
        public static SqlConnection _MasterCon;
        public static SqlConnection _MasterCon2;
        SqlCommand _cmd;
        public bool clear = false;
        public bool syncFlag = false;
        string _enroll = string.Empty;
        public string[] _psMachin;
        #endregion

        public DeviceSetting()
        {
            InitializeComponent();
            _MasterCon = frmMainForm._MasterCon;
            _MasterCon2 = frmMainForm._MasterCon2;
        }

        private void DeviceSetting_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Application.StartupPath + @"\Log.txt");
            string Path = sr.ReadLine();
            txt_File_Location_1.Text = Path;
            txt_bkup_folder_1.Text = sr.ReadLine();
            txt_file_location_2.Text = sr.ReadLine();
            txt_bkup_folder_2.Text = sr.ReadLine();
            if (frmMainForm._ConfigPlace == "cairo")
            {
                //txt_bkup_folder_1.Text = sr.ReadLine();    
            }
            else
            {
                //bkup1.Visible = false;
                //txt_bkup_folder_1.Visible = false;
                //button2.Visible = false;                
                folder2.Text = "PS Folder";
                bkup1.Text = "Backup PS to Cairo";
                folder1.Text = "Cairo Folder";
                bkup2.Text = "Backup Cairo to PS";
            }
            sr.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter(Application.StartupPath + @"\Log.txt");
            file.WriteLine(txt_File_Location_1.Text);
            file.WriteLine(txt_bkup_folder_1.Text);
            file.WriteLine(txt_file_location_2.Text);
            file.WriteLine(txt_bkup_folder_2.Text);
            file.Close();
            MessageBox.Show("Done.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_File_Location_1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_bkup_folder_1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_file_location_2.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txt_bkup_folder_2.Text = folderBrowserDialog1.SelectedPath;
        }
        private void btnLoadTrans_Click(object sender, EventArgs e)
        {
            //LOAD USERS
            //progress bar
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            label1.Text = "Load Users";
            label1.Visible = true;
            //progress bar//
            StreamReader sr = new StreamReader(Application.StartupPath + @"\AccessDataBase.txt");
            string Path = sr.ReadLine();
            string AccessPassword = sr.ReadLine();
            sr.Close();

            OleDbConnection AccessCon = new OleDbConnection();
            //AccessCon.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Path + ";OLEDB:Database Password=" + AccessPassword + ";Persist Security Info=True;";
            AccessCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Path + ";Jet OLEDB:Database Password=" + AccessPassword + ";Persist Security Info=True;";
            OleDbCommand oleCmd = new OleDbCommand();
            oleCmd.Connection = AccessCon;
            oleCmd.CommandText = "Select * from personne";
            //where condiontion ??
            OleDbDataAdapter oda = new OleDbDataAdapter();
            oda.SelectCommand = oleCmd;
            DataTable dt = new DataTable();
            oda.Fill(dt);
            //progress bar
            progressBar1.Maximum = dt.Rows.Count;
            //progress bar//


            //_cmd = new SqlCommand("", _MasterCon);
            //_cmd.CommandType = CommandType.Text;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _cmd = new SqlCommand("[sp_InsertESW_CARDS]", _MasterCon);

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Add("@CRD_NO", SqlDbType.VarChar).Value = dt.Rows[i]["NumCarte"].ToString();
                _cmd.Parameters.Add("@CRD_NAME", SqlDbType.VarChar).Value = dt.Rows[i]["Prenom"].ToString() + " " + dt.Rows[i]["Nom"].ToString();
                _cmd.Parameters.Add("@CRD_JOB", SqlDbType.VarChar).Value = dt.Rows[i]["Titre"].ToString();
                _cmd.Parameters.Add("@CRD_STARTING_DATE", SqlDbType.DateTime).Value = dt.Rows[i]["DateEnrol"].ToString();
                _cmd.Parameters.Add("@LOCATION", SqlDbType.NVarChar).Value = dt.Rows[i]["Pays"].ToString();
                _MasterCon.Open();
                try
                {
                    _cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                _MasterCon.Close();

                _cmd.Connection = _MasterCon2;
                _MasterCon2.Open();
                try
                {
                    _cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                _MasterCon2.Close();


                //_cmd.CommandText += "        INSERT INTO [dbo].[EMPLOYEE_CARDS] ([CRD_NO],[CRD_NAME],[CRD_JOB],[CRD_STARTING_DATE],[LOCATION],[CRD_EXPIRY_DATE],[CRD_LAST_TRANSACTION_TYPE],[COMPANY]) VALUES ( ";
                //_cmd.CommandText += dt.Rows[i]["NumCarte"].ToString() + " , ";
                //_cmd.CommandText += dt.Rows[i]["Prenom"].ToString() + " " + dt.Rows[i]["Nom"].ToString() + " ,";
                //_cmd.CommandText += dt.Rows[i]["Titre"].ToString() + " , ";
                //_cmd.CommandText += dt.Rows[i]["DateEnrol"].ToString() + " , ";
                //_cmd.CommandText += dt.Rows[i]["Pays"].ToString() + " , null , null ,null )";
                progressBar1.Value += 1;
            }
            //try
            //{
            //    _cmd.ExecuteNonQuery();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //_MasterCon.Close();

            //progress bar
            progressBar2.Visible = true;
            label4.Visible = true;
            //progress bar//            

            //load Logs
            //Building DataBase Connection                                 

            StreamReader SR;
            string Date = "", Time = "", year = "", month = "", day = "", hour = "", minutes = "", seconds = "";
            string enrollno = "", verifymode = "", inoutmode = "", TraCase = "";
            string S;
            for (int c = 0; c < frmMainForm._Machin.Length; c++)
            {
                if (frmMainForm._Machin[c] != null)
                {
                    string[] g;
                    try
                    {
                        //read from local folder                 
                        //==========================================                        
                        SR = File.OpenText(txt_File_Location_1.Text + @"\" + frmMainForm._Machin[c] + ".log");
                        g = File.ReadAllLines(txt_File_Location_1.Text + @"\" + frmMainForm._Machin[c] + ".log");
                        //progress bar                         
                        progressBar2.Value = 0;
                        progressBar2.Maximum = g.Length;
                        label4.Text += "  " + frmMainForm._Machin[c];
                        label4.Visible = true;
                        //progress bar//                        
                        S = SR.ReadLine();
                        while (S != null)
                        {
                            string[] Record = S.Split(',');
                            if (Record[1].ToString() == "IDENT_IN" || Record[1].ToString() == "IDENT")
                            {
                                enrollno = Record[4];
                            }
                            else
                            {
                                enrollno = Record[3];
                            }

                            TraCase = Record[2];

                            string[] datetime = Record[0].Split(' ');
                            Date = datetime[0];
                            Time = datetime[1];

                            string[] date = Date.Split('/');
                            year = "20" + date[2];
                            month = date[1];
                            day = date[0];

                            string[] time = Time.Split(':');
                            hour = time[0];
                            minutes = time[1];
                            seconds = time[2];

                            verifymode = "0";

                            decimal x = ((decimal.Parse(c.ToString()) + 2) / 2);
                            if (x == ((c + 2) / 2))
                            { inoutmode = "In"; }
                            else
                            { inoutmode = "Out"; }

                            DateTime transDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                            DateTime transTime = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minutes), int.Parse(seconds));
                            if (TraCase == "OK")
                            {
                                savetimeattendance(enrollno, transDate, transTime, false, int.Parse(verifymode), inoutmode, frmMainForm._Machin[c]);
                                S = SR.ReadLine();
                            }
                            else
                            {
                                S = SR.ReadLine();
                            }
                            //progress bar 
                            progressBar2.Value += 1;
                            //progress bar//
                        }
                        //progress bar
                        progressBar3.Visible = true;
                        progressBar3.Maximum = 5;
                        progressBar3.Value = 0;
                        label5.Visible = true;
                        //progress bar//                        
                        SR.Close();
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            File.Copy(txt_File_Location_1.Text + @"\" + frmMainForm._Machin[c] + ".log", @"D:\Back Up Logs\" + frmMainForm._Machin[c] + " " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".log", true);
                            if (c > 3)
                            {
                                StreamReader srr = File.OpenText(txt_File_Location_1.Text + @"\" + frmMainForm._Machin[c] + ".log");
                                string body = srr.ReadToEnd();
                                srr.Close();
                                File.AppendAllText(txt_bkup_folder_1.Text + @"\" + frmMainForm._Machin[c] + ".log", body);
                            }
                            //progress bar
                            progressBar3.Value += 1;
                            //progress bar//                         
                            //progress bar
                            progressBar3.Value += 1;
                            //progress bar//
                        }
                        else
                        {
                            File.Copy(txt_File_Location_1.Text + @"\" + frmMainForm._Machin[c] + ".log", @"D:\Back Up Logs\" + frmMainForm._Machin[c] + " " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".log", true);
                            StreamReader srr = File.OpenText(txt_File_Location_1.Text + @"\" + frmMainForm._Machin[c] + ".log");
                            string body = srr.ReadToEnd();
                            srr.Close();
                            File.AppendAllText(txt_bkup_folder_1.Text + @"\" + frmMainForm._Machin[c] + ".log", body);
                            //progress bar
                            progressBar3.Value += 2;
                            //progress bar//                                    
                        }
                        File.Delete(txt_File_Location_1.Text + @"\" + frmMainForm._Machin[c] + ".log");
                        //====================================================                                                
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.ToString().Contains("Could not find "))
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    try
                    {
                        //====================================================                                                
                        File.Copy(txt_file_location_2.Text + @"\" + frmMainForm._Machin[c] + ".log", txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log", true);

                        MessageBox.Show(txt_file_location_2.Text + @"\" + frmMainForm._Machin[c] + ".log");
                        SR = File.OpenText(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log");
                        g = File.ReadAllLines(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log");
                        //progress bar                         
                        progressBar2.Value = 0;
                        progressBar2.Maximum = g.Length;
                        label4.Text += "  " + frmMainForm._Machin[c];
                        label4.Visible = true;
                        //progress bar//                        
                        S = SR.ReadLine();
                        while (S != null)
                        {
                            string[] Record = S.Split(',');
                            if (Record[1].ToString() == "IDENT_IN" || Record[1].ToString() == "IDENT")
                            {
                                enrollno = Record[4];
                            }
                            else
                            {
                                enrollno = Record[3];
                            }

                            TraCase = Record[2];

                            string[] datetime = Record[0].Split(' ');
                            Date = datetime[0];
                            Time = datetime[1];

                            string[] date = Date.Split('/');
                            year = "20" + date[2];
                            month = date[1];
                            day = date[0];

                            string[] time = Time.Split(':');
                            hour = time[0];
                            minutes = time[1];
                            seconds = time[2];

                            verifymode = "0";

                            decimal x = ((decimal.Parse(c.ToString()) + 2) / 2);
                            if (x == ((c + 2) / 2))
                            { inoutmode = "In"; }
                            else
                            { inoutmode = "Out"; }

                            DateTime transDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                            DateTime transTime = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minutes), int.Parse(seconds));
                            if (TraCase == "OK")
                            {
                                savetimeattendance(enrollno, transDate, transTime, false, int.Parse(verifymode), inoutmode, frmMainForm._Machin[c]);
                                S = SR.ReadLine();
                            }
                            else
                            {
                                S = SR.ReadLine();
                            }
                            //progress bar 
                            progressBar2.Value += 1;
                            //progress bar//
                        }
                        //progress bar
                        progressBar3.Visible = true;
                        progressBar3.Maximum = 5;
                        progressBar3.Value = 0;
                        label5.Visible = true;
                        //progress bar//                  
                        SR.Close();
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            File.Copy(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log", @"D:\Back Up Logs\" + frmMainForm._Machin[c] + " " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".log", true);
                            if (c > 3)
                            {
                                StreamReader srr = File.OpenText(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log");
                                string body = srr.ReadToEnd();
                                srr.Close();
                                File.AppendAllText(txt_bkup_folder_1.Text + @"\" + frmMainForm._Machin[c] + ".log", body);
                            }
                            //progress bar
                            progressBar3.Value += 1;
                            //progress bar//                            
                        }
                        else
                        {
                            File.Copy(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log", @"D:\Back Up Logs\" + frmMainForm._Machin[c] + " " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".log", true);
                            StreamReader srr = File.OpenText(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log");
                            string body = srr.ReadToEnd();
                            srr.Close();
                            File.AppendAllText(txt_bkup_folder_1.Text + @"\" + frmMainForm._Machin[c] + ".log", body);
                            //progress bar
                            progressBar3.Value += 1;
                            //progress bar//                            
                        }
                        File.Delete(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log");
                        File.Delete(txt_file_location_2.Text + @"\" + frmMainForm._Machin[c] + ".log");
                        //====================================================
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.ToString().Contains("Could not find "))
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    //====================================================                        
                    try
                    {
                        File.Copy(txt_bkup_folder_2.Text + @"\" + frmMainForm._Machin[c] + ".log", txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log", true);
                        SR = File.OpenText(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log");
                        g = File.ReadAllLines(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log");
                        //progress bar                         
                        progressBar2.Value = 0;
                        progressBar2.Maximum = g.Length;
                        label4.Text += "  " + frmMainForm._Machin[c];
                        label4.Visible = true;
                        //progress bar//                        
                        S = SR.ReadLine();
                        while (S != null)
                        {
                            string[] Record = S.Split(',');
                            if (Record[1].ToString() == "IDENT_IN" || Record[1].ToString() == "IDENT")
                            {
                                enrollno = Record[4];
                            }
                            else
                            {
                                enrollno = Record[3];
                            }

                            TraCase = Record[2];

                            string[] datetime = Record[0].Split(' ');
                            Date = datetime[0];
                            Time = datetime[1];

                            string[] date = Date.Split('/');
                            year = "20" + date[2];
                            month = date[1];
                            day = date[0];

                            string[] time = Time.Split(':');
                            hour = time[0];
                            minutes = time[1];
                            seconds = time[2];

                            verifymode = "0";

                            decimal x = ((decimal.Parse(c.ToString()) + 2) / 2);
                            if (x == ((c + 2) / 2))
                            { inoutmode = "In"; }
                            else
                            { inoutmode = "Out"; }

                            DateTime transDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                            DateTime transTime = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minutes), int.Parse(seconds));
                            if (TraCase == "OK")
                            {
                                savetimeattendance(enrollno, transDate, transTime, false, int.Parse(verifymode), inoutmode, frmMainForm._Machin[c]);
                                S = SR.ReadLine();
                            }
                            else
                            {
                                S = SR.ReadLine();
                            }
                            //progress bar 
                            progressBar2.Value += 1;
                            //progress bar//
                        }
                        //progress bar
                        progressBar3.Visible = true;
                        progressBar3.Maximum = 5;
                        progressBar3.Value = 0;
                        label5.Visible = true;
                        //progress bar//                  
                        SR.Close();
                        if (frmMainForm._ConfigPlace == "cairo")
                        {
                            File.Copy(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log", @"D:\Back Up Logs\" + frmMainForm._Machin[c] + " " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".log", true);
                            //progress bar
                            progressBar3.Value += 1;
                            //progress bar//                            
                        }
                        else
                        {
                            File.Copy(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log", @"D:\Back Up Logs\" + frmMainForm._Machin[c] + " " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".log", true);
                            //progress bar
                            progressBar3.Value += 1;
                            //progress bar//                                                               
                        }

                        File.Delete(txt_bkup_folder_1.Text + @"\temp\" + frmMainForm._Machin[c] + ".log");
                        File.Delete(txt_bkup_folder_2.Text + @"\" + frmMainForm._Machin[c] + ".log");
                        //====================================================                        
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.ToString().Contains("Could not find "))
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
            }
            ///////////////////
            Last_Update();
            progressBar3.Value += 1;
            MessageBox.Show("data saved Successfully");
            //progress bar
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            progressBar3.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            //progress bar//
        }

        #region Public Method

        public void savetimeattendance(string cardno, DateTime TransactionDate, DateTime TransactionTime, bool temp, int verifymode, string InOutMode, string Machine)
        {
            try
            {
                //Insert Record                
                _cmd = new SqlCommand("Sp_InsertESW_TRANSACTIONS", _MasterCon);
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Add("@TRN_Time", SqlDbType.DateTime).Value = TransactionTime;
                _cmd.Parameters.Add("@TRN_CARD_NO", SqlDbType.VarChar).Value = cardno;
                _cmd.Parameters.Add("@TRN_PLACE", SqlDbType.NVarChar).Value = InOutMode;
                _cmd.Parameters.Add("@TRN_MACHINE", SqlDbType.NVarChar).Value = Machine;
                _MasterCon.Open();
                _cmd.ExecuteNonQuery();
                _MasterCon.Close();
                //==========               
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint") || ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    _MasterCon.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message);
                    _MasterCon.Close();
                }
            }
        }

        private void Last_Update()
        {
            frmMainForm fr = new frmMainForm();
            try
            {
                StreamWriter file = new StreamWriter(Application.StartupPath + @"\LastUpdate.txt");
                file.Write(DateTime.Now.ToString());
                file.Close();
                fr.lblLastUpdate.Text = DateTime.Now.ToString();
            }
            catch
            {
                fr.lblLastUpdate.Text = "";
            }

            SqlCommand com = new SqlCommand("SELECT convert(char(10),MAX(TRN_TIME),103) AS Date , convert(char(19),MAX(TRN_TIME),8) AS Time FROM EMPLOYEE_TRANSACTIONS", _MasterCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt3 = new DataTable();
            sda.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {

                fr.lblMaxUpdate.Text = dt3.Rows[0][0].ToString() + " " + dt3.Rows[0][1].ToString();
            }
            else
            {
                fr.lblMaxUpdate.Text = "";
            }
        }

        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files (*.xls)|*.xls*";
            DialogResult dlgRes = dlg.ShowDialog();

            if (dlgRes != DialogResult.Cancel)
            {
                txt_manual_file.Text = dlg.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_manual_file.Text + //@"\New Serial Phpc.xlsx" +
                                         ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\";";

            var output = new DataSet();
            //string xx = x;

            System.Data.DataTable DT2 = new System.Data.DataTable();

            using (var conn = new OleDbConnection(strConn))
            {
                conn.Open();

                var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


                //                var cmd = new OleDbCommand("SELECT * FROM [ PHPC PS$]", conn);
                var cmd = new OleDbCommand("SELECT * FROM [" + dt.Rows[0]["TABLE_NAME"].ToString().Trim() + "]", conn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter xlAdapter = new OleDbDataAdapter(cmd);
                xlAdapter.Fill(DT2);
                conn.Close();
                for (int i = 0; i < DT2.Rows.Count; i++)
                {
                    int x;
                    if (DT2.Rows[i][2].ToString() != null && int.TryParse(DT2.Rows[i][2].ToString(), out x) == true)
                    {
                        if (DT2.Rows[i][4].ToString() != null && DT2.Rows[i][5].ToString() != null && DT2.Rows[i][4].ToString() != "" && DT2.Rows[i][5].ToString() != "")
                        {
                            try
                            {
                                //Insert Record                
                                _cmd = new SqlCommand("Sp_InsertESW_MANUAL_TRANSACTIONS", _MasterCon);
                                _cmd.CommandType = CommandType.StoredProcedure;

                                //string[] date = DateTime.Parse(DT2.Rows[i][4].ToString()).ToString("dd/MM/yyyy").Split('/');
                                string[] date = DT2.Rows[i][4].ToString().Split('/');
                                string[] time = DT2.Rows[i][5].ToString().Split(':');

                                DateTime dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
                                _cmd.Parameters.Add("@TRN_Time", SqlDbType.DateTime).Value = dd;
                                _cmd.Parameters.Add("@TRN_CARD_NO", SqlDbType.VarChar).Value = DT2.Rows[i][2].ToString();
                                _cmd.Parameters.Add("@TRN_PLACE", SqlDbType.NVarChar).Value = "In";
                                _cmd.Parameters.Add("@TRN_MACHINE", SqlDbType.NVarChar).Value = (txt_mac.Text + " in").Trim();
                                _MasterCon.Open();
                                _cmd.ExecuteNonQuery();
                                _MasterCon.Close();
                                //==========               
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Violation of PRIMARY KEY constraint") || ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                                {
                                    _MasterCon.Close();
                                }
                                else
                                {
                                    MessageBox.Show(ex.Message);
                                    _MasterCon.Close();
                                }
                            }
                        }

                        if (DT2.Rows[i][6].ToString() != null && DT2.Rows[i][7].ToString() != null && DT2.Rows[i][6].ToString() != "" && DT2.Rows[i][7].ToString() != "")
                        {
                            try
                            {
                                //Insert Record                
                                _cmd = new SqlCommand("Sp_InsertESW_MANUAL_TRANSACTIONS", _MasterCon);
                                _cmd.CommandType = CommandType.StoredProcedure;
                                //string[] date = DateTime.Parse(DT2.Rows[i][6].ToString()).ToString("dd/MM/yyyy").Split('/');
                                string[] date = DT2.Rows[i][6].ToString().Split('/');
                                string[] time = DT2.Rows[i][7].ToString().Split(':');
                                //string[] date2 = DT2.Rows[i][4].ToString().Split('/');
                                //string[] time2 = DT2.Rows[i][5].ToString().Split(':');
                                DateTime dd;
                                //if (int.Parse(time2[0]) > 16)

                                //{ 
                                dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
                                //}
                                //else
                                //{ dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0); }
                                _cmd.Parameters.Add("@TRN_Time", SqlDbType.DateTime).Value = dd;
                                _cmd.Parameters.Add("@TRN_CARD_NO", SqlDbType.VarChar).Value = DT2.Rows[i][2].ToString();
                                _cmd.Parameters.Add("@TRN_PLACE", SqlDbType.NVarChar).Value = "Out";
                                _cmd.Parameters.Add("@TRN_MACHINE", SqlDbType.NVarChar).Value = (txt_mac.Text + " out").Trim();
                                _MasterCon.Open();
                                _cmd.ExecuteNonQuery();
                                _MasterCon.Close();
                                //==========               
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Violation of PRIMARY KEY constraint") || ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                                {
                                    _MasterCon.Close();
                                }
                                else
                                {
                                    MessageBox.Show(ex.Message);
                                    _MasterCon.Close();
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Done");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_manual_file.Text + //@"\New Serial Phpc.xlsx" +
                                          ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\";";

            var output = new DataSet();
            //string xx = x;

            System.Data.DataTable DT2 = new System.Data.DataTable();

            using (var conn = new OleDbConnection(strConn))
            {
                conn.Open();

                var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


                //                var cmd = new OleDbCommand("SELECT * FROM [ PHPC PS$]", conn);
                var cmd = new OleDbCommand("SELECT * FROM [" + dt.Rows[0]["TABLE_NAME"].ToString().Trim() + "]", conn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter xlAdapter = new OleDbDataAdapter(cmd);
                xlAdapter.Fill(DT2);
                conn.Close();
                for (int i = 0; i < DT2.Rows.Count; i++)
                {
                    int x;
                    if (DT2.Rows[i][2].ToString() != null && int.TryParse(DT2.Rows[i][2].ToString(), out x) == true)
                    {
                        if (DT2.Rows[i][4].ToString() != null && DT2.Rows[i][5].ToString() != null && DT2.Rows[i][4].ToString() != "" && DT2.Rows[i][5].ToString() != "")
                        {
                            try
                            {
                                //Insert Record                
                                _cmd = new SqlCommand();
                                _cmd.Connection = _MasterCon;
                                _cmd.CommandType = CommandType.Text;
                                string[] date = DT2.Rows[i][4].ToString().Split('/');
                                string[] time = DateTime.Parse(DT2.Rows[i][5].ToString()).ToString("hh:mm").Split(':');
                                DateTime dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
                                _cmd.CommandText = "DELETE FROM EMPLOYEE_TRANSACTIONS WHERE TRN_CARD_NO='" + DT2.Rows[i][2].ToString() + "' AND TRN_Time='" + dd + "' AND TRN_PLACE='In' AND TRN_MACHINE = '" + (txt_mac.Text + " in").Trim() + "'";

                                _MasterCon.Open();
                                _cmd.ExecuteNonQuery();
                                _MasterCon.Close();
                                //==========               
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                _MasterCon.Close();
                            }
                        }

                        if (DT2.Rows[i][6].ToString() != null && DT2.Rows[i][7].ToString() != null && DT2.Rows[i][6].ToString() != "" && DT2.Rows[i][7].ToString() != "")
                        {
                            try
                            {
                                //Insert Record                
                                _cmd = new SqlCommand();
                                _cmd.Connection = _MasterCon;
                                _cmd.CommandType = CommandType.Text;
                                string[] date = DT2.Rows[i][6].ToString().Split('/');
                                string[] time = DateTime.Parse(DT2.Rows[i][7].ToString()).ToString("hh:mm").Split(':');

                                DateTime dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
                                _cmd.CommandText = "DELETE FROM EMPLOYEE_TRANSACTIONS WHERE TRN_CARD_NO='" + DT2.Rows[i][2].ToString() + "' AND TRN_Time='" + dd + "' AND TRN_PLACE='In' AND TRN_MACHINE = '" + (txt_mac.Text + " in").Trim() + "'";
                                _MasterCon.Open();
                                _cmd.ExecuteNonQuery();
                                _MasterCon.Close();
                                //==========               
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                _MasterCon.Close();
                            }
                        }
                    }
                }
                MessageBox.Show("Done");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {            
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_manual_file.Text + //@"\New Serial Phpc.xlsx" +
                                         ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\";";

            var output = new DataSet();
            //string xx = x;

            System.Data.DataTable DT2 = new System.Data.DataTable();

            using (var conn = new OleDbConnection(strConn))
            {
                conn.Open();

                var dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


                //                var cmd = new OleDbCommand("SELECT * FROM [ PHPC PS$]", conn);
                var cmd = new OleDbCommand("SELECT * FROM [" + dt.Rows[0]["TABLE_NAME"].ToString().Trim() + "]", conn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter xlAdapter = new OleDbDataAdapter(cmd);
                xlAdapter.Fill(DT2);
                conn.Close();
         //       MessageBox.Show(DT2.Rows.Count.ToString());
                for (int i = 4; i < DT2.Rows.Count; i++)
                {
                    int x;           
                    if (DT2.Rows[i][0].ToString() != null && int.TryParse(DT2.Rows[i][0].ToString(), out x) == true)
                    {
                        for (int z = 0; z <= 62; z++)
                        {
                            if (DT2.Rows[1][z + 2].ToString() != null && DT2.Rows[1][z + 2].ToString() != "")
                            {
                                if (DT2.Rows[i][z + 2].ToString() != null && DT2.Rows[i][z + 2].ToString() != "" && DT2.Rows[i][z + 2].ToString() != "v")
                                {
                                    try
                                    {
                                        //Insert Record                
                                        _cmd = new SqlCommand("Sp_InsertESW_MANUAL_TRANSACTIONS", _MasterCon);
                                        _cmd.CommandType = CommandType.StoredProcedure;

                                        //string[] date = DateTime.Parse(DT2.Rows[i][4].ToString()).ToString("dd/MM/yyyy").Split('/');
                                        string[] date = DT2.Rows[1][z + 2].ToString().Split('/');
                                        string[] time = DT2.Rows[i][z + 2].ToString().Split(':');

                                        DateTime dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
                                        _cmd.Parameters.Add("@TRN_Time", SqlDbType.DateTime).Value = dd;
                                        _cmd.Parameters.Add("@TRN_CARD_NO", SqlDbType.VarChar).Value = DT2.Rows[i][0].ToString();
                                        _cmd.Parameters.Add("@TRN_PLACE", SqlDbType.NVarChar).Value = "In";
                                        _cmd.Parameters.Add("@TRN_MACHINE", SqlDbType.NVarChar).Value = (txt_mac.Text + " in").Trim();
                                        _MasterCon.Open();
                                        _cmd.ExecuteNonQuery();
                                        _MasterCon.Close();
                                        //==========               
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex.Message.Contains("Violation of PRIMARY KEY constraint") || ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                                        {
                                            _MasterCon.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show(ex.Message);
                                            _MasterCon.Close();
                                        }
                                    }
                                }
                                // insert out
                                if (DT2.Rows[i][z + 3].ToString() != null && DT2.Rows[i][z + 3].ToString() != "" && DT2.Rows[i][z + 3].ToString() != "v")
                                {
                             /*       string[] date2 = DT2.Rows[1][z + 2].ToString().Split('/');
                                    string[] time2 = DT2.Rows[i][z + 3].ToString().Split(':');

                                    DateTime dd2 = new DateTime(int.Parse(date2[2]), int.Parse(date2[1]), int.Parse(date2[0]), int.Parse(time2[0]), int.Parse(time2[1]), 0);
                                    MessageBox.Show(dd2.ToString()+"--"+
                                    DT2.Rows[i][0].ToString()+"--"+"Out"+"--"+(txt_mac.Text + " out").Trim());*/
                                    try
                                    {
                                        //Insert Record                
                                        _cmd = new SqlCommand("Sp_InsertESW_MANUAL_TRANSACTIONS", _MasterCon);
                                        _cmd.CommandType = CommandType.StoredProcedure;

                                        //string[] date = DateTime.Parse(DT2.Rows[i][4].ToString()).ToString("dd/MM/yyyy").Split('/');
                                        string[] date = DT2.Rows[1][z + 2].ToString().Split('/');
                                        string[] time = DT2.Rows[i][z + 3].ToString().Split(':');

                                        DateTime dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
                                        _cmd.Parameters.Add("@TRN_Time", SqlDbType.DateTime).Value = dd;
                                        _cmd.Parameters.Add("@TRN_CARD_NO", SqlDbType.VarChar).Value = DT2.Rows[i][0].ToString();
                                        _cmd.Parameters.Add("@TRN_PLACE", SqlDbType.NVarChar).Value = "Out";
                                        _cmd.Parameters.Add("@TRN_MACHINE", SqlDbType.NVarChar).Value = (txt_mac.Text + " out").Trim();
                                        _MasterCon.Open();
                                        _cmd.ExecuteNonQuery();                                        
                                        _MasterCon.Close();
                                        //==========               
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex.Message.Contains("Violation of PRIMARY KEY constraint") || ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                                        {
                                            _MasterCon.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show(ex.Message);
                                            _MasterCon.Close();
                                        }                                        
                                    }
                                }

                            }
                            z += 1;
                        }
                            /*
                        if (DT2.Rows[i][4].ToString() != null && DT2.Rows[i][5].ToString() != null && DT2.Rows[i][4].ToString() != "" && DT2.Rows[i][5].ToString() != "")
                        {
                            try
                            {
                                //Insert Record                
                                _cmd = new SqlCommand("Sp_InsertESW_MANUAL_TRANSACTIONS", _MasterCon);
                                _cmd.CommandType = CommandType.StoredProcedure;

                                //string[] date = DateTime.Parse(DT2.Rows[i][4].ToString()).ToString("dd/MM/yyyy").Split('/');
                                string[] date = DT2.Rows[i][4].ToString().Split('/');
                                string[] time = DT2.Rows[i][5].ToString().Split(':');

                                DateTime dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
                                _cmd.Parameters.Add("@TRN_Time", SqlDbType.DateTime).Value = dd;
                                _cmd.Parameters.Add("@TRN_CARD_NO", SqlDbType.VarChar).Value = DT2.Rows[i][2].ToString();
                                _cmd.Parameters.Add("@TRN_PLACE", SqlDbType.NVarChar).Value = "In";
                                _cmd.Parameters.Add("@TRN_MACHINE", SqlDbType.NVarChar).Value = (txt_mac.Text + " in").Trim();
                                _MasterCon.Open();
                                _cmd.ExecuteNonQuery();
                                _MasterCon.Close();
                                //==========               
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Violation of PRIMARY KEY constraint") || ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                                {
                                    _MasterCon.Close();
                                }
                                else
                                {
                                    MessageBox.Show(ex.Message);
                                    _MasterCon.Close();
                                }
                            }
                        }

                        if (DT2.Rows[i][6].ToString() != null && DT2.Rows[i][7].ToString() != null && DT2.Rows[i][6].ToString() != "" && DT2.Rows[i][7].ToString() != "")
                        {
                            try
                            {
                                //Insert Record                
                                _cmd = new SqlCommand("Sp_InsertESW_MANUAL_TRANSACTIONS", _MasterCon);
                                _cmd.CommandType = CommandType.StoredProcedure;
                                //string[] date = DateTime.Parse(DT2.Rows[i][6].ToString()).ToString("dd/MM/yyyy").Split('/');
                                string[] date = DT2.Rows[i][6].ToString().Split('/');
                                string[] time = DT2.Rows[i][7].ToString().Split(':');
                                //string[] date2 = DT2.Rows[i][4].ToString().Split('/');
                                //string[] time2 = DT2.Rows[i][5].ToString().Split(':');
                                DateTime dd;
                                //if (int.Parse(time2[0]) > 16)

                                //{ 
                                dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
                                //}
                                //else
                                //{ dd = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0); }
                                _cmd.Parameters.Add("@TRN_Time", SqlDbType.DateTime).Value = dd;
                                _cmd.Parameters.Add("@TRN_CARD_NO", SqlDbType.VarChar).Value = DT2.Rows[i][2].ToString();
                                _cmd.Parameters.Add("@TRN_PLACE", SqlDbType.NVarChar).Value = "Out";
                                _cmd.Parameters.Add("@TRN_MACHINE", SqlDbType.NVarChar).Value = (txt_mac.Text + " out").Trim();
                                _MasterCon.Open();
                                _cmd.ExecuteNonQuery();
                                _MasterCon.Close();
                                //==========               
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Violation of PRIMARY KEY constraint") || ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                                {
                                    _MasterCon.Close();
                                }
                                else
                                {
                                    MessageBox.Show(ex.Message);
                                    _MasterCon.Close();
                                }
                            }
                        }*/
                    }
                }
                MessageBox.Show("Done");
            }
        }
    }
}