using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PasswordEncrypt
{
    public partial class Form1 : Form
    {
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        public Form1()
        {
            InitializeComponent();
        }

        private string PasswordDecrypt(string Str_userPWD, string Str_Empid)
        {
            string Str_password = null;
            Str_password = Logobj.Decrypt(Str_userPWD, Str_Empid);
            return Str_password;
        }

        private void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            txt_Password.Text = "";
            if (txt_Empcode.Text.Trim().Length > 0)
            {
                DataTable dt = new DataTable();
                dt = HREmpobj.selEmpDetailsWOROL(txt_Empcode.Text);
                if (dt.Rows.Count > 0)
                {
                    txt_Password.Text = PasswordDecrypt(dt.Rows[0]["pwd"].ToString(), dt.Rows[0]["empid"].ToString());
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (isShuttingDown)
            //{
            //    if (MessageBox.Show(this, "The application is still running, are you sure you want to exit?",
            //    "Confirm Closing by Windows Shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        e.Cancel = false;
            //    }
            //    else
            //        e.Cancel = true;
            //}
        }
        private const int WM_QUERYENDSESSION = 0x0011;
        private bool isShuttingDown = false;
        /*This is the method (WndProc) which receive Windows Messages we are overriding it to make it works as we want*/
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                isShuttingDown = true;
            }
            base.WndProc(ref m);
        }
    }
}