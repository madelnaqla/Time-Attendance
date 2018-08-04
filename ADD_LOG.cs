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
    public partial class ADD_LOG : Form
    {
        public ADD_LOG()
        {
            InitializeComponent();
        }

        private void PRINT_DIALOG_Load(object sender, EventArgs e)
        {          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (TXT_EMP_NO.Text.Trim() != null && TXT_EMP_NO.Text.Trim() != "")
            {
                SqlCommand CMD = new SqlCommand();

                CMD.CommandText = "SELECT * FROM dbo.EMPLOYEE_CARDS WHERE CRD_NO ='" + TXT_EMP_NO.Text + "'";
                CMD.CommandTimeout = 2000;
                CMD.CommandType = CommandType.Text;
                CMD.Connection = frmMainForm._MasterCon;
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = CMD;
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                if (DT.Rows.Count == 0)               
                {                    
                    MessageBox.Show("No Employee has this number.");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Enter Employee Number.");
                return;
            }
            if (cmb_machine.SelectedItem == null)
            {
                MessageBox.Show("Enter Machine.");
                return;
            }
            string year = "", month = "", day = "", hour = "", minutes = "", seconds = "00";
            year = dateTimePickerValid.Value.Year.ToString();
            month = dateTimePickerValid.Value.Month.ToString();
            day = dateTimePickerValid.Value.Day.ToString();
            
            string[] time = txtfromTime.Text.Split(':');

            hour = time[0];
            minutes = time[1];
            
            DeviceSetting dv=new DeviceSetting();
            DateTime transDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            DateTime transTime = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minutes), int.Parse(seconds));

            if (radioButtonIn.Checked)
            {
                dv.savetimeattendance(TXT_EMP_NO.Text, transDate, transTime, false, 0, "In", cmb_machine.SelectedItem.ToString());
                MessageBox.Show("Data Saved.");
            }
            else
            {
                dv.savetimeattendance(TXT_EMP_NO.Text, transDate, transTime, false, 0, "Out", cmb_machine.SelectedItem.ToString());
                MessageBox.Show("Data Saved.");
            }
        }
    }
}
