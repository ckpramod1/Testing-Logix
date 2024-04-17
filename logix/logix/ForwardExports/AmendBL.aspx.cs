using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess.HR;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;

namespace logix.ForwardExports
{
    public partial class AmendBL : System.Web.UI.Page
    {
        DataAccess.ForwardingExports.AmendBL Amendobj = new DataAccess.ForwardingExports.AmendBL();
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();      
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
       // DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataTable dt_ok_b1 = new DataTable();
        
        int int_divisionid;
        int int_branchid;
        int int_empid;
        string str_TranType;
        string str_oldblno;
        string str_newblno;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);



           string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Amendobj.GetDataBase(Ccode);
                DAdvise.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}

            if (!IsPostBack == true)
                {
                  try
                  { 
                   //Session["LoginDivisionId"] = 1;
                    //Session["LoginBranchid"] = 1;

                    //Session["StrTranType"] = "FE";
                    int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    txt_Job.Attributes.Add("onkeypress", "return numerical()");
                    clearAll();
                    string str_CtrlLists, str_MsgLists, str_DataType;
                    str_CtrlLists = "txt_Job~txt_AmedBl";
                    str_MsgLists = "Job #~Amend BL #";
                    str_DataType = "String~String";
                    btn_Amendbl.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");
                 //   ddl_BL.Items.Add("");
                    
                    btn_Amendbl.Enabled = false;
                    btn_Amendbl.ForeColor = System.Drawing.Color.Gray;
                   /*
                   
                    Session["LoginDivisionId"] = 1;
                    Session["LoginBranchid"] = 1;
                    int_divisionid = Convert.ToInt32(this.Session["LoginDivisionId"].ToString());
                    int_branchid = Convert.ToInt32(this.Session["LoginBranchid"].ToString());    
                   txt_Job.Attributes.Add("onkeypress", "return numerical()");       
                   // txt_Job.Attributes.Add("onkeypress", "return numerical()");
                    clearAll();
                    string str_CtrlLists, str_MsgLists, str_DataType;
                    str_CtrlLists = "txt_Job~ddl_BL~txt_AmedBl";
                    str_MsgLists = "Job#~BL#~Amend BL #";
                    str_DataType = "String~DropDown~String";          

                    btn_Amendbl.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");
                */

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
                    if (Request.QueryString.ToString().Contains("jobno"))
                    {
                        txt_Job.Text= Request.QueryString["jobno"].ToString();
                        txt_Job_TextChanged(sender, e);
                        ddl_BL.Enabled = false;
                    }
                  }
                  catch (Exception ex)
                  {
                      string message = ex.Message.ToString();
                      ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                  }

                 }
               else if (Page.IsPostBack)
               {
                   WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                   int indx = wcICausedPostBack.TabIndex;
                   var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                              where control.TabIndex > indx
                              select control;
                   ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
               }

            }

        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;

        }

        protected void txt_Job_TextChanged(object sender, EventArgs e)
        {

          try
          { 
            // Session["LoginBranchid"] = 1;
           // Session["StrTranType"] = "FE";

              btn_Amendbl.Enabled = true;
              btn_Amendbl.ForeColor = System.Drawing.Color.White;
            // int int_txtjob = Convert.ToInt32(this.Session["txt_Job"].ToString());
            ddl_BL.Items.Clear();
            int_branchid = Convert.ToInt32(this.Session["LoginBranchid"].ToString());
            DataTable dt_ok_bl = new DataTable();

            if (txt_Job.Text != "")
            {
                str_TranType = this.Session["StrTranType"].ToString();

                dt_ok_bl = DAdvise.FillBLNo(Convert.ToInt32(txt_Job.Text), str_TranType, int_branchid);
                if (dt_ok_bl.Rows.Count > 0)
                {
                    if (ddl_BL.SelectedIndex != 0)
                    {
                        for (int i = 0; i < dt_ok_bl.Rows.Count; i++)
                        {
                            if (str_TranType == "FE" || str_TranType == "FI")
                            {
                                ddl_BL.Items.Add(dt_ok_bl.Rows[i]["blno"].ToString());
                            }
                            else if (str_TranType == "AE" || str_TranType == "AI")
                            {
                                ddl_BL.Items.Add(dt_ok_bl.Rows[i]["hawblno"].ToString());
                            }
                        }
                    }
                    else
                    {
                        ddl_BL.Items.Clear();
                       // ddl_BL.Items.Add("");
                    }
                }
                else
                {
                  
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('JOB Number Not Availabe');", true);
                    txt_Job.Text = "";
                    txt_Job.Focus();
                    ddl_BL.Items.Clear();
                  //  ddl_BL.Items.Add("");
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('JOB Number is Empty');", true);              
                txt_Job.Focus();
              
            }
            
          }
          catch (Exception ex)
          {
              string message = ex.Message.ToString();
              ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
              txt_Job.Text = "";
              txt_Job.Focus();
             // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
          }
           btn_back.Text = "Cancel";
          btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"]= "btn ico-cancel";


        }
           

      public void clearAll()
        {
            txt_AmedBl.Text = "";
            txt_Job.Text = "";
            ddl_BL.Items.Clear();
            
          
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {

            // if (btn_back.ToolTip == "Back")
            //{
            //     //ScriptManager.RegisterStartupScript(btn_back, typeof(Button), "myalert", "alertify.alert('Do u want to close the window');", true);

            //     //Response.Redirect("~/MainPage/OceanExports.aspx");
              
            //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);//this will close the page on button click
            //     //this.Response.End();
            //     //btn_Amendbl.Enabled = false;
            //     //btn_Amendbl.ForeColor = System.Drawing.Color.Gray;
            //    if (Session["StrTranType"].ToString() == "FE")
            //    {
            //      Response.Redirect("../Home/OEOpsAndDocs.aspx");
            //    }
            //    else if (Session["StrTranType"].ToString() == "FI")
            //    {
            //        Response.Redirect("../Home/OEOpsAndDocs.aspx");
            //    }
            //    else if (Session["StrTranType"].ToString() == "AE")
            //    {
            //        Response.Redirect("../Home/OEOpsAndDocs.aspx");
            //    }
            //    else if (Session["StrTranType"].ToString() == "AI")
            //    {
            //        Response.Redirect("../Home/OEOpsAndDocs.aspx");
            //    }

            // }

            //else
           
            // {
                  txt_AmedBl.Text = "";
                  txt_Job.Text = "";
                  ddl_BL.Items.Clear();
                 // ddl_BL.Items.Add("");
                   btn_back.Text = "Back";
                  btn_back.ToolTip = "Back";
                  btn_back1.Attributes["class"] = "btn ico-back";
                  btn_Amendbl.Enabled = false;
                  btn_Amendbl.ForeColor = System.Drawing.Color.Gray;
             //}
       
           
           // String strScript = "window.close();";

            //ScriptManager.RegisterStartupScript(this, typeof(String), "WINDOW CLOSED", strScript, true);
           
               //String display = "Your dispaly";

              // ScriptManager.RegisterStartupScript(btn_back, typeof(Button), "myalert", "alertify.alert('Do u want to close the window');", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alertify.alert('" + display + "');", true);//this will dispaly the alert box


               //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);//this will close the page on button click
                           
        }

        protected void btn_Amendbl_Click(object sender, EventArgs e)
        {

            try
            {
               
                int_divisionid = Convert.ToInt32(this.Session["LoginDivisionId"].ToString());
                int_branchid = Convert.ToInt32(this.Session["LoginBranchid"].ToString());
                int_empid = Convert.ToInt32(this.Session["LoginEmpId"].ToString());
                str_TranType = this.Session["StrTranType"].ToString();
                DataTable dt_ok_bl = new DataTable();
                DataTable dt_ok_mbl = new DataTable();
                DataTable dt_ok_updbl = new DataTable();
                btn_Amendbl.Enabled = true;
                btn_Amendbl.ForeColor = System.Drawing.Color.White;
                if (txt_Job.Text != "")
                {
                    str_oldblno = ddl_BL.SelectedItem.Text.ToString().ToUpper();
                    str_newblno = txt_AmedBl.Text.Trim().ToUpper();
                }

                if (ddl_BL.SelectedItem.Text != "")
                {
                    if (txt_AmedBl.Text != "")
                    {

                        dt_ok_bl = Amendobj.GetBLno(str_TranType, str_newblno, int_branchid, int_divisionid);
                        for (int i = 0; i < dt_ok_bl.Rows.Count; i++)
                        {
                            if (str_newblno == dt_ok_bl.Rows[i][0].ToString())
                            {
                                ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('BLno #:" + str_newblno + " Already Exist');", true);
                                txt_Job.Focus();
                                return;

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('BLno Changed to " + str_newblno + "');", true);
                                txt_Job.Focus();
                            }
                        }

                        dt_ok_mbl = Amendobj.GetMBLno(str_TranType, str_newblno, int_branchid, int_divisionid);
                        for (int i = 0; i < dt_ok_mbl.Rows.Count; i++)
                        {
                            if (str_newblno == dt_ok_mbl.Rows[i][0].ToString())
                            {
                                ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('BLno #:" + str_newblno + " Already Exist');", true);
                                txt_Job.Focus();
                                return;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('BLno Changed to " + str_newblno + "');", true);
                                txt_Job.Focus();
                            }
                        }

                        Amendobj.UpdAmendBL(str_oldblno, str_newblno, str_TranType, int_branchid, int_divisionid);
                        if (ddl_BL.SelectedItem.Text != txt_AmedBl.Text)
                        {
                            ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('BLno Changed to " + str_newblno + "');", true);
                            txt_Job.Focus();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('BLno Already Exist');", true);
                            txt_Job.Focus();
                        }
                        switch (str_TranType)
                        {
                            case "FE":
                                Logobj.InsLogDetail(int_empid, 93, 1, int_branchid, str_oldblno + "/" + str_newblno);
                                break;

                            case "FI":
                                Logobj.InsLogDetail(int_empid, 94, 2, int_branchid, str_oldblno + "/" + str_newblno);
                                break;

                            case "AE":
                                Logobj.InsLogDetail(int_empid, 95, 1, int_branchid, str_oldblno + "/" + str_newblno);
                                break;

                            case "AI":
                                Logobj.InsLogDetail(int_empid, 96, 2, int_branchid, str_oldblno + "/" + str_newblno);
                                break;

                            default:
                                ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('Wrong TranType');", true);

                                break;
                        }
                        ScriptManager.RegisterStartupScript(btn_Amendbl, typeof(Button), "DataFound", "alertify.alert('BLno Changed to "+str_newblno+"');", true);
                        clearAll();
                    }
                    else
                    {
                        txt_AmedBl.Focus();
                    }
                }
               // ddl_BL.Items.Add("");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void logdetails_Click(object sender, EventArgs e)
        {
            try
            {
                loadgridlog();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            if (Session["StrTranType"]!=null)
            {
                if(Session["StrTranType"].ToString()=="FE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 93, "job", txt_Job.Text, txt_Job.Text, Session["StrTranType"].ToString());
                }

                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 94, "job", txt_Job.Text, txt_Job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 95, "job", txt_Job.Text, txt_Job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 96, "job", txt_Job.Text, txt_Job.Text, Session["StrTranType"].ToString());
                }
            }
              

          




            //if (txt_book.Text != "")
            //{
            //    JobInput.Text = txt_book.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
           
    }

}  

              
        
   