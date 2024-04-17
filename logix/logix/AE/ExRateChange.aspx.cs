using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;

namespace logix.AE
{
    public partial class ExRateChange : System.Web.UI.Page
    {
        DataAccess.Accounts.Invoice InvObj = new DataAccess.Accounts.Invoice();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
        DataAccess.FAVoucher FAObj = new DataAccess.FAVoucher();
        int jobno, vouyear, ddlinv, cou, invon;
        DataTable Dt = new DataTable();
        double currex, paex, nrate;
        DateTime updateon;
        string FADbname;

        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if(!IsPostBack)
            {
                Ctrl_List = txt_jobno.ID + "~" + ddl_inv.ID + "~" + txt_bl.ID + "~" + txt_curr.ID + "~" + txt_new.ID;
                Msg_List = "JobNo~Invoice~BLNO~Currency~New Rate";
                Dtype_List = "string~string~string~string~string";
                btn_update.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                txt_jobno.Focus();
                ddl_inv.AutoPostBack = true;
                //vouyear = Convert.ToInt32(Session["Vouyear"]);
                FADbname = Session["FADbname"].ToString();
                txt_curr.Visible = false;
                btn_back.Text = "Cancel";

                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";


                ddl_inv.Items.Add("");
                //txt_new.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Exrate')");
                if (Session["StrTranType"].ToString() == "AE")
                {
                    HeaderLabel1.InnerText = "Air Exports";
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    HeaderLabel1.InnerText = "Air Imports";
                }            
            }
          
        }

        protected void txt_jobno_TextChanged(object sender, EventArgs e)
        {
            string trantype = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            cou = 0;
            if(txt_jobno.Text !="")
            {

                ddl_inv.Items.Clear();
                jobno= Convert.ToInt32(txt_jobno.Text);
                Dt = InvObj.GetInvNoFromJobnonew(jobno, trantype, bid);
                ddl_inv.Items.Add("");
                for (int i = 0; i < Dt.Rows.Count ; i++)
                {                    
                    //ddl_inv.Items.Add(Dt.Rows[i]["invoiceno"].ToString());
                    ddl_inv.Items.Add(new ListItem(Dt.Rows[i][0].ToString(), Dt.Rows[i][2].ToString()));

                    hid_Vouyear.Value = Dt.Rows[i]["vouyear"].ToString();
                    //vouyear = Convert.ToInt32(Dt.Rows[i][1].ToString());
                    cou = 1;
                    
                }
                if(cou==1)
                {
                    ddl_inv.Enabled = true;
                    ddl_inv.Focus();
                }else
                {
                    ddl_inv.Enabled = false;
                    
                }
               btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
            }
        }

        protected void ddl_inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trantype = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            txt_bl.Text = "";
            ddl_curr.Items.Clear();
            txt_curr.Text = "";
            if (txt_jobno.Text != "" || ddl_inv.SelectedItem.Text != "")
            {
                jobno = Convert.ToInt32(txt_jobno.Text);
                ddlinv = Convert.ToInt32(ddl_inv.SelectedItem.Text);
                string ad=ddl_inv.SelectedValue;
                //txt_bl.Text = InvObj.GetBLNoFromInvNo(jobno, ddlinv, trantype, bid);
                txt_bl.Text = InvObj.GetBLNoFromInvNoOSCNDN(jobno, ddlinv, trantype, bid, ddl_inv.SelectedItem.Value);
               // Dt = InvObj.GetCurrFromInvNo(jobno, ddlinv, trantype, bid);
                Dt = InvObj.GetCurrFromInvNonewOSCNDN(jobno, ddlinv, trantype, bid, ddl_inv.SelectedItem.Value);
                //txt_curr.Focus();
                txt_bl.Focus();
             
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {  
                        ddl_curr.Items.Add(Dt.Rows[i]["curr"].ToString());
                    }
                }
                else
                {
                    //ddl_curr.Visible = false;
                    //ddl_curr.Items.Add(ddl_curr.SelectedItem.Text.ToUpper());
                    //ddl_curr.SelectedValue = ddl_curr.SelectedItem.Text.ToUpper();
                    //txt_curr.Visible = true;
                    ddl_curr.Items.Add("");
                }
                
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip=="Cancel")
            {
              textclear();
                btn_back.Text="Back";

              btn_back.ToolTip = "Back";
              btn_back1.Attributes["class"] = "btn ico-back";

            }
            else
            {
               // this.Response.End();
                if (Session["StrTranType"].ToString() == "AE")
                {
                    // headerlable1.InnerText = "OceanExports";
                    Response.Redirect("../Home/OEOpsAndDocs.aspx");

                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                }

            }
        }

        private void textclear()
        {
            
            txt_jobno.Text = "";
            ddl_inv.Items.Clear();
            ddl_inv.Items.Add("");
            txt_bl.Text = "";
            ddl_curr.Items.Clear();
            ddl_curr.Items.Add("");
            txt_curr.Visible = false;
            ddl_curr.Visible = true;
            txt_new.Text = "";
            
        }

        private void CollectDetails()
        {
            string trantype = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            DateTime dtlog = logobj.GetDate();
            jobno= Convert.ToInt32(txt_jobno.Text);
            currex = Convert.ToDouble(InvObj.GetExRate(ddl_curr.SelectedItem.Text, dtlog, "R",Convert.ToInt32(Session["LoginDivisionId"])));
            //paex = Convert.ToDouble(InvObj.GetCheckInvExrate(jobno, trantype, bid, ddl_curr.SelectedItem.Text));
            hid_paex.Value = Convert.ToString(InvObj.GetCheckInvExrate(jobno, trantype, bid, ddl_curr.SelectedItem.Text));
            updateon = logobj.GetDate();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string FADbname = HttpContext.Current.Session["FADbname"].ToString();
            string trantype = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            //int username = Convert.ToInt32(Session["LoginUserName"].ToString());


            if (ddl_curr.SelectedItem.Text != "")
            {
                
                    if (ddl_inv.SelectedItem.Text.ToUpper() == ("All").ToUpper())
                    {
                        for (int i = 0; i < ddl_inv.Items.Count; i++)
                        {
                            ddl_inv.SelectedIndex = i;
                            invon = Convert.ToInt32(ddl_inv.SelectedItem.Text);
                            if (FAObj.CheckFAExists4Voucher(ddlinv, vouyear, bid, 1, FADbname) != 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "logix", "alertify.alert('Voucher # " + ddl_inv.SelectedItem.Text + " Already transferred to FA. You cannot amend the Ex.Rate');", true);
                            }
                        }
                        ddl_inv.SelectedItem.Text = "0";
                        CollectDetails();

                        if (txt_jobno.Text != "" && ddl_inv.SelectedItem.Text != "" && ddl_curr.SelectedItem.Text != "" && txt_new.Text != "")
                        {
                            invon = Convert.ToInt32(ddl_inv.SelectedItem.Text);
                            nrate = Convert.ToDouble(txt_new.Text);
                            InvObj.UpdateExRateFromJobNoOSCNDN(invon, bid, jobno, ddl_curr.SelectedItem.Text, nrate, trantype, Convert.ToInt32(hid_Vouyear.Value), ddl_inv.SelectedItem.Value);
                            InvObj.InsAmendExRateDetable(invon, bid, jobno, ddl_curr.SelectedItem.Text, nrate, trantype, vouyear, currex, Convert.ToInt32(hid_paex.Value), empid, updateon);

                            if (trantype=="AE")
                            {
                                logobj.InsLogDetail(empid, 373, 1, bid, txt_jobno.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_new.Text);
                            
                            }
                            else
                            {
                                logobj.InsLogDetail(empid, 374, 1, bid, txt_jobno.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_new.Text);
                            
                            }
                            
                            
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "logix", "alertify.alert('Ex.Rate Changed');", true);

                            textclear();
                            txt_jobno.Focus();
                        }
                    }
                    else
                    {
                        CollectDetails();
                        invon = Convert.ToInt32(ddl_inv.SelectedItem.Text);
                        if (FAObj.CheckFAExists4Voucher(invon, Convert.ToInt32(hid_Vouyear.Value), bid, 1, FADbname) != 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "logix", "alertify.alert('Voucher # " + ddl_inv.SelectedItem.Text + " Already transferred to FA. You cannot amend the Ex.Rate');", true);
                        }
                        if (txt_jobno.Text != "" && ddl_inv.SelectedItem.Text != "" && ddl_curr.SelectedItem.Text != "" && txt_new.Text != "")
                        {
                            invon = Convert.ToInt32(ddl_inv.SelectedItem.Text);
                            nrate = Convert.ToDouble(txt_new.Text);

                            InvObj.UpdateExRateFromJobNoOSCNDN(invon, bid, jobno, ddl_curr.SelectedItem.Text, nrate, trantype, Convert.ToInt32(hid_Vouyear.Value), ddl_inv.SelectedItem.Value);
                            InvObj.InsAmendExRateDetable(invon, bid, jobno, ddl_curr.SelectedItem.Text, nrate, trantype, Convert.ToInt32(hid_Vouyear.Value), currex, Convert.ToInt32(hid_paex.Value), empid, updateon);
                            if (trantype == "AE")
                            {

                                logobj.InsLogDetail(empid, 373, 1, bid, txt_jobno.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_new.Text);
                            }
                            else
                            {
                                logobj.InsLogDetail(empid, 374, 1, bid, txt_jobno.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_new.Text);
                            }

                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "logix", "alertify.alert('Ex.Rate Changed');", true);

                            textclear();
                            txt_jobno.Focus();
                        }
                    }
            }

        }

        protected void txt_curr_TextChanged(object sender, EventArgs e)
        {
            txt_curr.Visible = true;
            if (ddl_curr.SelectedItem.Text != "")
            {
               
                if (chargeobj.GetCurrID(ddl_curr.SelectedItem.Text) != 0)
                {
                    ddl_curr.Items.Add(ddl_curr.SelectedItem.Text);
                    ddl_curr.SelectedValue = ddl_curr.SelectedItem.Text;
                    ddl_curr.Visible = true;
                    txt_curr.Visible = false;
                    txt_new.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "logix", "alertify.alert('select correct currency');", true);
                    txt_curr.Visible = true;
                    ddl_curr.SelectedItem.Text = "";
                    txt_curr.Focus();
                    ddl_curr.Visible = false;
                }
                
            }
        }
        
    }
}