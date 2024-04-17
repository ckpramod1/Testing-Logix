using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace logix
{
    public partial class ForgotPwd : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt_ok = new DataTable();
            DataAccess.userlogin login = new DataAccess.userlogin();
            dt = login.SelGetMail4pwd(TextBox1.Text);
            //  if (txtTempPwd.Text.ToString() == login.Decrypt(dt_ok.Rows[0][11].ToString(), dt_ok.Rows[0]["empid"].ToString()))
            if (dt.Rows.Count > 0)
            {
                hdn_pwd.Value = login.Decrypt(dt.Rows[0][11].ToString(), dt.Rows[0]["empid"].ToString());
            }
            try
            {

                //DataAccess.LoginForm login = new DataAccess.LoginForm();
                dt_ok = login.SelGetMail4pwd(TextBox1.Text);
                if (dt_ok.Rows.Count > 0)
                {
                    MailMessage Msg = new MailMessage();

                    Msg.From = new MailAddress("bharathimsc.28@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add(TextBox1.Text);
                    Msg.Subject = "Your Password Details";
                    Msg.Body = "Hi, Please check your Login Detailss....Your Username: " + dt_ok.Rows[0]["empcode"] + "....Your Password: " + hdn_pwd.Value + "....";
                    Msg.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = true;
                     NetworkCredential NetworkCred = new NetworkCredential("bharathimsc.28@gmail.com", "november2891");
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    //smtp.Credentials = new System.Net.NetworkCredential("bharathimsc.28@gmail.com", "2002281191");
                    // smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;   
                    smtp.Send(Msg);
                    ScriptManager.RegisterStartupScript(Button1, typeof(Button), "UserName", "alertify.alert('Your Password Details Sent to your mail');", true);
                    //TextBox1.Text = "";         
                }
                else
                {

                    ScriptManager.RegisterStartupScript(Button1, typeof(Button), "UserName", "alertify.alert('The Email you entered not exists.');", true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}