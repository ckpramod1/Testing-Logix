using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Runtime.Remoting;

namespace logix.FAForm
{
    public partial class EmpchangePass : System.Web.UI.Page
    {
        DataTable dt_Dtemp = new DataTable();
        string str_pwd;
        //string strCtrlLst;
        //string strMsgLst;
        //string strDtypeLst;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.HR.Employee da_obj_HRMObj = new DataAccess.HR.Employee();
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                da_obj_HRMObj.GetDataBase(Ccode);
                da_obj_Logobj.GetDataBase(Ccode);
             

            }

            if (IsPostBack != true)
            {
                try
                {
                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                    if (Session["LoginUserName"] != null)
                    {
                        string str_CtrlLists, str_MsgLists, str_DataType;
                        str_CtrlLists = "txt_EmpName~txt_Division~txt_Branch~txt_Department~txt_Desgination~txt_OldPassword~txt_NewPassword~txt_ConfirmPassword";
                        str_MsgLists = "EmpName~Division~Branch~Department~Designation~OldPassword~NewPassword~ConfirmPassword";
                        str_DataType = "String~String~String~String~String~String~String~String";
                        btn_confirm.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");
                        // btn_confirm.Attributes.Add("OnClick", "return IsValid('" + strCtrlLst + "','" + strMsgLst + "','" + strDtypeLst + "');");
                        txt_Division.Text = Session["LoginDivisionName"].ToString();
                        txt_Branch.Text = Session["LoginBranchName"].ToString();
                        dt_Dtemp = da_obj_HRMObj.selEmpDetails(Session["LoginUserName"].ToString(), "OFF");
                        // dt_Dtemp = da_obj_HRMObj.selEmployDetails(Session["LoginUserName"].ToString(),"OFF");
                        if (dt_Dtemp.Rows.Count > 0)
                        {
                            txt_EmpName.Text = dt_Dtemp.Rows[0][12].ToString();
                            txt_Department.Text = dt_Dtemp.Rows[0][8].ToString();
                            txt_Desgination.Text = dt_Dtemp.Rows[0][3].ToString();
                            str_pwd = dt_Dtemp.Rows[0][11].ToString();
                        }
                        txt_EmpName.ReadOnly = true;
                        txt_Division.ReadOnly = true;
                        txt_Branch.ReadOnly = true;
                        txt_Department.ReadOnly = true;
                        txt_Desgination.ReadOnly = true;
                        txt_OldPassword.Focus();
                       btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }

                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lbl_Header.Text = Request.QueryString["FormName"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
                }
            }
        }

        protected void btn_confirm_Click1(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.HR.Employee da_obj_HRMObj = new DataAccess.HR.Employee();
                //DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
                dt_Dtemp = da_obj_HRMObj.selEmpDetails(Session["LoginUserName"].ToString(), "OFF");
                str_pwd = da_obj_Logobj.Decrypt(dt_Dtemp.Rows[0][11].ToString(), dt_Dtemp.Rows[0]["empid"].ToString());
                string str_Empid = dt_Dtemp.Rows[0]["empid"].ToString();

                string strIPAddress = null;

                int length = 0;
                length = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList.Length;
                strIPAddress = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[length - 1].ToString();

                // string  pwd = Login.PasswordEncrypt(txtnewpass.Text, Login.Username);
                string pwd = da_obj_Logobj.Encrypt(txt_NewPassword.Text, str_Empid);

                if (txt_OldPassword.Text != "" && txt_NewPassword.Text != "" && txt_ConfirmPassword.Text != "")
                {
                    if (IsValidpass(txt_NewPassword.Text))
                    {

                    }
                    else
                    {
                        txt_NewPassword.Text = "";
                        txt_ConfirmPassword.Text = "";
                        txt_NewPassword.Focus();
                        ScriptManager.RegisterStartupScript(txt_NewPassword, typeof(TextBox), "DataFound", "alertify.alert('Password must contain: Atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 Number and also need minimum 6-10 characters ')", true);
                        return;
                    }
                    if (txt_OldPassword.Text == str_pwd)
                    {
                        if (txt_NewPassword.Text == txt_ConfirmPassword.Text)
                        {
                            da_obj_HRMObj.ChangeEmpPasswd(pwd, Session["LoginUserName"].ToString(), da_obj_Logobj.GetDate(), strIPAddress);
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "DataFound", "alertify.alert('New & Confirm Password does not Match')", true);
                            txt_NewPassword.Text = "";
                            txt_ConfirmPassword.Text = "";
                            txt_NewPassword.Focus();
                        }
                        if (Session["StrTranType"] != null)
                        {
                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpid"].ToString()), 164, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), "PwdChange");
                                    break;
                                case "FI":
                                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpid"].ToString()), 165, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), "PwdChange");
                                    break;
                                case "AE":
                                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpid"].ToString()), 166, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), "PwdChange");
                                    break;
                                case "AI":
                                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpid"].ToString()), 167, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), "PwdChange");
                                    break;
                                case "CH":
                                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpid"].ToString()), 168, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), "PwdChange");
                                    break;
                                case "AC":
                                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpid"].ToString()), 163, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), "PwdChange");
                                    break;
                            }
                        }

                        ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "DataFound", "alertify.alert('Password Changed')", true);

                        if (Session["Login"] != null)
                        {
                            Session["Login"] = null;
                            Response.Redirect("Login.Aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "DataFound", "alertify.alert('Old Password Does not Match')", true);
                        txt_NewPassword.Text = "";
                        txt_OldPassword.Text = "";
                        txt_ConfirmPassword.Text = "";
                        txt_OldPassword.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }                       

        protected void btn_cancel_Click1(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                //DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
                string dt = Session["LoginUserName"].ToString();
                dt = "";
                txt_ConfirmPassword.Text = "";
                txt_NewPassword.Text = "";
                txt_OldPassword.Text = "";
                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else             
            {
                //this.Response.End();

                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "BR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");

                    }
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }

                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FAFC")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
                
            }
        }

        protected void txt_EmpName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_NewPassword_TextChanged(object sender, EventArgs e)
        {
           
        }


        private bool IsValidpass(string pass)
        {
            //Regex To validate Email Address
            //Regex regex = new Regex("^.*(?=.{6,10})(?=.*[a-zA-Z])[a-zA-Z0-9]+$");
            //var regEx = new Regex(@"^(?=(.*\d))(?=.*[a-z])(?=.*[A-Z])(?!\d).{6,10}$");//
            //"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"
            //^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$//(?=.*?[#?!@$%^&*-])
            var regEx = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,10}$");
            Match match = regEx.Match(pass);
            if (match.Success)
                return true;
            else
                return false;
        }
       
    }
}