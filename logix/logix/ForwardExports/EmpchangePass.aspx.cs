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

namespace logix.ForwardExports
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


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);
           

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            //if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            //}
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}

            if (IsPostBack != true)
            {
                try
                {
                    // strCtrlLst = txt_NewPassword.ID;
                    //strMsgLst = "Password";
                    //strDtypeLst = "Password";

                    if (Request.QueryString.ToString().Contains("profile"))
                    {
                        crumbsid.Attributes["class"] = "crumbs1";


                    }
                    if (Session["LoginUserName"] != null)
                    {
                        string str_CtrlLists, str_MsgLists, str_DataType;
                        str_CtrlLists = "txt_EmpName~txt_Division~txt_Branch~txt_Department~txt_Desgination~txt_OldPassword~txt_NewPassword~txt_ConfirmPassword";
                        str_MsgLists = "EmpName~Division~Branch~Department~Designation~OldPassword~NewPassword~ConfirmPassword";
                        str_DataType = "String~String~String~String~String~String~String~String";
                        btn_confirm.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");
                        // btn_confirm.Attributes.Add("OnClick", "return IsValid('" + strCtrlLst + "','" + strMsgLst + "','" + strDtypeLst + "');");
                        if (Session["LoginDivisionName"] != null)
                        {
                            txt_Division.Text = Session["LoginDivisionName"].ToString();
                        }
                        //if (Session["LoginBranchName"]!=null)
                        //{
                        //    txt_Branch.Text = Session["LoginBranchName"].ToString();
                        //}

                        dt_Dtemp = da_obj_HRMObj.selEmpDetails(Session["LoginUserName"].ToString(), "OFF");
                        // dt_Dtemp = da_obj_HRMObj.selEmployDetails(Session["LoginUserName"].ToString(),"OFF");
                        if (dt_Dtemp.Rows.Count > 0)
                        {

                            txt_EmpName.Text = dt_Dtemp.Rows[0][12].ToString();
                            txt_Department.Text = dt_Dtemp.Rows[0][8].ToString();
                            txt_Desgination.Text = dt_Dtemp.Rows[0][3].ToString();
                            txt_Branch.Text = dt_Dtemp.Rows[0][2].ToString();
                            str_pwd = dt_Dtemp.Rows[0][11].ToString();

                            // str_pwd = da_obj_Logobj.Decrypt(str_pwd, dt_Dtemp.Rows[0]["empid"].ToString());
                        }
                        txt_EmpName.ReadOnly = true;
                        txt_Division.ReadOnly = true;
                        txt_Branch.ReadOnly = true;
                        txt_Department.ReadOnly = true;
                        txt_Desgination.ReadOnly = true;
                        txt_OldPassword.Focus();
                        //btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                    /* if (Session["StrTranType"] != null)
                     {
                         if (Session["StrTranType"].ToString() == "FE")
                         {
                             headerlable1.InnerText = "OceanExports";
                         }
                         else if (Session["StrTranType"].ToString() == "FI")
                         {
                             headerlable1.InnerText = "OceanImports";
                         }
                         else if (Session["StrTranType"].ToString() == "AE")
                         {
                             headerlable1.InnerText = "AirExports";
                         }
                         else if (Session["StrTranType"].ToString() == "AI")
                         {
                             headerlable1.InnerText = "AirImports";
                         }
                         else if (Session["StrTranType"].ToString() == "CH")
                         {
                             headerlable1.InnerText = "Custom House Agent";
                         }
                         else if (Session["StrTranType"].ToString() == "BT")
                         {
                             headerlable1.InnerText = "Bonded Trucking";
                         }
                         else if (Session["StrTranType"].ToString() == "AC")
                         {
                             headerlable1.InnerText = "Operating Accounts";
                         }
                     }*/
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
        }


        protected void btn_confirm_Click1(object sender, EventArgs e)
        {
            try
            {
                DataAccess.HR.Employee da_obj_HRMObj = new DataAccess.HR.Employee();
                DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
                dt_Dtemp = da_obj_HRMObj.selEmpDetails(Session["LoginUserName"].ToString(), "OFF");
                str_pwd = da_obj_Logobj.Decrypt(dt_Dtemp.Rows[0][11].ToString(), dt_Dtemp.Rows[0]["empid"].ToString());
                string str_Empid = dt_Dtemp.Rows[0]["empid"].ToString();
                //string str_trantype = Session["StrTranType"].ToString();



                string strIPAddress = null;
                //strIPAddress = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList(1).ToString()

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
                            //  da_obj_HRMObj.ChangeEmpPasswd(da_obj_Logobj.Encrypt(txt_NewPassword.Text, str_Empid), Session["LoginUserName"].ToString(), da_obj_Logobj.GetDate());
                            //da_obj_HRMObj.ChangeEmpPasswd(da_obj_Logobj.Encrypt(txt_NewPassword.Text,str_Empid),Session["LoginUserName"].ToString(),da_obj_Logobj.GetDate());
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "DataFound", "alertify.alert('New & Confirm Password does not Match')", true);
                            txt_NewPassword.Text = "";
                            txt_ConfirmPassword.Text = "";
                            txt_NewPassword.Focus();
                            return;
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
                            crumbsid.Attributes["class"] = "crumbs1";
                            Session["Login"] = null;
                           ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
                            //Response.Redirect("FormMain.aspx");
                          //  Response.Redirect("Login.Aspx");
                           //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('"+ Session["Site"].ToString() + "/login.aspx','_top');", true);
                        }
                        else
                        {
                            crumbsid.Attributes["class"] = "crumbs1";
                            Session["Login"] = null;
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
                            //Response.Redirect("FormMain.aspx");
                         //   Response.Redirect("Login.Aspx");
                          // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('"+ Session["Site"].ToString() + "/login.aspx','_top');", true);
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
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void btn_cancel_Click1(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
                string dt = Session["LoginUserName"].ToString();
                dt = "";
                txt_ConfirmPassword.Text = "";
                txt_NewPassword.Text = "";
                txt_OldPassword.Text = "";
                //btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                // this.Response.End();

                if (btn_cancel.ToolTip == "Cancel")
                {
                    if (Request.QueryString.ToString().Contains("profile"))
                    {

                    }
                    DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
                    string dt = Session["LoginUserName"].ToString();
                    dt = "";
                    txt_ConfirmPassword.Text = "";
                    txt_NewPassword.Text = "";
                    txt_OldPassword.Text = "";
                    //btn_cancel.Text = "Back";
                    btn_cancel.ToolTip = "Back";
                    btn_cancel1.Attributes["class"] = "btn ico-back";
                }
                else
                {
                    Response.Redirect("../Home/Profile.aspx");
                }

            }
        }

        protected void txt_EmpName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_NewPassword_TextChanged(object sender, EventArgs e)
        {

            //if(IsValidpass(txt_NewPassword.Text))
            //{
            //    //if (txt_NewPassword.Text.Length > 6 && txt_NewPassword.Text.Length < 10)
            //    //{

            //    //}
            //    txt_ConfirmPassword.Focus();
            //}
            //else
            //{
            //    txt_NewPassword.Text = "";
            //    txt_ConfirmPassword.Text = "";
            //    txt_NewPassword.Focus();
            //    ScriptManager.RegisterStartupScript(txt_NewPassword, typeof(TextBox), "DataFound", "alertify.alert('Password must contain: Atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 Number')", true);
            //    return;
            //}
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