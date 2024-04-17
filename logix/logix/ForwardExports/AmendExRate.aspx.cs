using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.ForwardExports
{
    public partial class AmendExRate : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string trantype;
        int branchID, employeeID;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ctrl_List;
            string Msg_List;
            string Dtype_List;
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Cancel);
            txt_Curr.Visible = false;
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}
            employeeID = Convert.ToInt32(Session["LoginEmpId"]);
            branchID = Convert.ToInt32(Session["LoginBranchid"]);
            //trantype = Session["StrTranType"].ToString();
            if (!IsPostBack)
            {
                try
                {
                    ddl_inv.Visible = true;

                    //  lbl_header.Text = Request.QueryString["type"].ToString();

                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        lbl_header.Text = Request.QueryString["type"].ToString();
                    }
                    Ctrl_List = txt_job.ID + "~" + txt_Bl.ID + "~" + txt_ExRate.ID;
                    Msg_List = "JOB Number~BL Number~ExRate Amount";
                    Dtype_List = "String~String~String";
                    btn_Update.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "');");
                    btn_Cancel.Text = "Cancel";
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel2.Attributes["class"] = "btn ico-cancel";
                    if (Session["StrTranType"] != null)
                    {

                        if (Session["StrTranType"].ToString() == "FI")
                        {
                            Headerlabel.InnerText = "OceanImports";

                        }
                        else if (Session["StrTranType"].ToString() == "CH")
                        {
                            Headerlabel.InnerText = "Custom House Agent";
                        }
                        else if (Session["StrTranType"].ToString() == "FE")
                        {
                            Headerlabel.InnerText = "OceanExports";
                        }
                    }
                    headername.InnerText = lbl_header.Text;

                    if (Request.QueryString.ToString().Contains("INjobno"))
                    {
                        txt_job.Text = Request.QueryString["INjobno"].ToString();
                        txt_job_TextChanged(sender, e);
                        if (Request.QueryString["invou"].ToString() == "5")
                        {
                            ddl_inv.SelectedItem.Value = "OSSI" + Request.QueryString["refno"].ToString();
                        }
                        else if (Request.QueryString["invou"].ToString() == "6")
                        {
                            ddl_inv.SelectedItem.Value = "OSPI" + Request.QueryString["refno"].ToString();
                        }
                        else if (Request.QueryString["invou"].ToString() == "1")
                        {

                            ddl_inv.SelectedItem.Value = "INV" + Request.QueryString["refno"].ToString();
                        }
                        else if (Request.QueryString["invou"].ToString() == "2")
                        {

                            ddl_inv.SelectedItem.Value = "PRO" + Request.QueryString["refno"].ToString();
                        }
                        ddl_inv.SelectedItem.Text = Request.QueryString["refno"].ToString();
                        ddl_inv.Enabled = false;
                        ddl_inv_SelectedIndexChanged(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }
        }
        protected void txt_job_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_inv.Visible = true;
                int co = 0;
                int i;
                trantype = Session["StrTranType"].ToString();
                DataTable obj_Dt = new DataTable();
                DataAccess.Accounts.Invoice obj_da_InvObj = new DataAccess.Accounts.Invoice();
                obj_Dt = obj_da_InvObj.GetInvNoFromJobnonew(Convert.ToInt32(txt_job.Text), trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                for (i = ddl_inv.Items.Count - 1; i > 0; i--)
                {
                    ddl_inv.Items.RemoveAt(i);
                }
              
                if (obj_Dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_Dt.Rows.Count - 1; i++)
                    {
                        ddl_inv.Items.Add(new ListItem(obj_Dt.Rows[i][0].ToString(), obj_Dt.Rows[i][2].ToString()));
                        hid_Vouyear.Value = obj_Dt.Rows[i][1].ToString();
                        co = 1;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "alert", "alertify.alert('There is no proforma Invoice/CN-ops')", true);
                    txt_job.Text = "";
                    txt_job.Focus();
                    return;
                }

                if (co == 1)
                {
                    ddl_inv.Enabled = true;
                    co = 0;
                }
                else
                {
                    ddl_inv.Enabled = false;
                }
                btn_Cancel.Text = "Cancel";
                btn_Cancel.ToolTip = "Cancel";
                btn_cancel2.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txt_job.Text = "";
                txt_job.Focus();
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
            }

        }

        protected void ddl_inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_inv.SelectedItem.Text == "ALL ")
                {
                    ddl_inv.Visible = false;
                    return;
                }
                else
                {
                    ddl_inv.Visible = true;
                    int i;
                    DataTable obj_Dt = new DataTable();
                    DataAccess.Accounts.Invoice obj_da_InvObj = new DataAccess.Accounts.Invoice();
                    txt_Bl.Text = obj_da_InvObj.GetBLNoFromInvNoOSCNDN(Convert.ToInt32(txt_job.Text), Convert.ToInt32(ddl_inv.SelectedItem.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_inv.SelectedItem.Value);
                    obj_Dt = obj_da_InvObj.GetCurrFromInvNonewOSCNDN(Convert.ToInt32(txt_job.Text), Convert.ToInt32(ddl_inv.SelectedItem.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_inv.SelectedItem.Value);
                    string data = ddl_inv.SelectedItem.Value.Substring(0, 3).ToString();
                    for (i = ddl_curr.Items.Count - 1; i > 0; i--)
                    {
                        ddl_curr.Items.RemoveAt(i);
                    }
                    if (obj_Dt.Rows.Count > 0)
                    {
                        for (i = 0; i <= obj_Dt.Rows.Count - 1; i++)
                        {
                            ddl_curr.Items.Add(obj_Dt.Rows[i][0].ToString());
                        }
                    }
                    else
                    {
                        // ddl_curr.Visible = false;

                        ddl_curr.Items.Add(txt_Curr.Text.ToUpper());
                        if (txt_Curr.Text == "")
                        {
                            ddl_curr.SelectedValue = "0";
                        }
                        else
                        {
                            ddl_curr.SelectedValue = txt_Curr.Text.ToUpper();
                        }
                        //ddl_curr.Visible = true;
                        //txt_Curr.Visible = true;
                    }
                    btn_Cancel.Text = "Cancel";
                    btn_Cancel.ToolTip = "Cancel";
                    btn_cancel2.Attributes["class"] = "btn ico-cancel";
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void CollectDetails()
        {
            try
            {
                DataAccess.LogDetails obj_da_logobj = new DataAccess.LogDetails();
                DataAccess.Accounts.Invoice obj_da_InvObj = new DataAccess.Accounts.Invoice();
                hid_currex.Value = obj_da_InvObj.GetExRate(ddl_curr.SelectedItem.Text, obj_da_logobj.GetDate(), "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                hid_paex.Value = Convert.ToString(obj_da_InvObj.GetCheckInvExrate(Convert.ToInt32(txt_job.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_curr.SelectedItem.Text));
                hid_Updateon.Value = logix.Utility.fn_ConvertDate(Convert.ToString(obj_da_logobj.GetDate()));
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void txtclear()
        {
            int i;
            txt_job.Text = "";
            txt_Bl.Text = "";
            txt_ExRate.Text = "";
            ddl_curr.Visible = true;
            for (i = ddl_inv.Items.Count - 1; i > 0; i--)
            {
                ddl_inv.Items.RemoveAt(i);
            }
            for (i = ddl_curr.Items.Count - 1; i > 0; i--)
            {
                ddl_curr.Items.RemoveAt(i);
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (btn_Cancel.ToolTip == "Cancel")
            {
                ddl_inv.Visible = true;
                txtclear();
                btn_Cancel.Text = "Back";
                btn_Cancel.ToolTip = "Back";
                btn_cancel2.Attributes["class"] = "btn ico-back";
            }
            else
            {
                //  this.Response.End();

                if (Session["StrTranType"].ToString() == "FE")
                {
                    // headerlable1.InnerText = "OceanExports";
                    Response.Redirect("../Home/OEOpsAndDocs.aspx");

                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                }
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Accounts.Invoice obj_da_InvObj = new DataAccess.Accounts.Invoice();
                DataAccess.LogDetails obj_da_logobj = new DataAccess.LogDetails();
                DataAccess.Masters.MasterCharges obj_da_chargeobj = new DataAccess.Masters.MasterCharges();
                if (ddl_curr.SelectedItem.Text != "Select curr")
                {
                    if (txt_Curr.Text != "")
                    {
                        ddl_curr.Items.Add(txt_Curr.Text);
                        ddl_curr.SelectedValue = txt_Curr.Text;
                    }
                    if (ddl_inv.SelectedItem.Text.ToUpper() == ("All").ToUpper())
                    {

                        ddl_inv.SelectedItem.Text = "0";
                        CollectDetails();
                        if (txt_job.Text != "" & ddl_inv.SelectedItem.Text != "" & ddl_curr.SelectedItem.Text != "" & txt_ExRate.Text != "")
                        {
                            obj_da_InvObj.UpdateExRateFromJobNoOSCNDN(Convert.ToInt32(ddl_inv.SelectedItem.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text), ddl_curr.SelectedItem.Text, Convert.ToDouble(txt_ExRate.Text), Session["StrTranType"].ToString(), Convert.ToInt32(hid_Vouyear.Value), ddl_inv.SelectedItem.Value);
                            obj_da_InvObj.InsAmendExRateDetable(Convert.ToInt32(ddl_inv.SelectedItem.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text), ddl_curr.SelectedItem.Text, Convert.ToDouble(txt_ExRate.Text), Session["StrTranType"].ToString(), Convert.ToInt32(hid_Vouyear.Value), Convert.ToDouble(hid_currex.Value), Convert.ToDouble(hid_paex.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToDateTime(hid_Updateon.Value));
                            //' send()
                            ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "alert", "alertify.alert('Ex.Rate Changed to " + txt_ExRate.Text + "')", true);
                            //obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginUserName"].ToString()), 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + "All" + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                            if (Session["StrTranType"] != null)
                            {
                                if (Session["StrTranType"].ToString() == "FE")
                                {
                                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 371, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + "All" + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                                }
                                else if (Session["StrTranType"].ToString() == "FI")
                                {
                                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 372, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + "All" + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                                }
                                else if (Session["StrTranType"].ToString() == "CH")
                                {
                                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 375, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + "All" + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                                }
                                else
                                {
                                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginUserName"].ToString()), 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + "All" + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                                }
                            }
                            txtclear();
                            txt_job.Focus();
                        }
                    }
                    else
                    {
                        CollectDetails();
                        if (txt_job.Text != "" & ddl_inv.SelectedItem.Text != "" & ddl_curr.SelectedItem.Text != "" & txt_ExRate.Text != "")
                        {
                            obj_da_InvObj.UpdateExRateFromJobNoOSCNDN(Convert.ToInt32(ddl_inv.SelectedItem.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text), ddl_curr.SelectedItem.Text, Convert.ToDouble(txt_ExRate.Text), Session["StrTranType"].ToString(), Convert.ToInt32(hid_Vouyear.Value), ddl_inv.SelectedItem.Value);
                            obj_da_InvObj.InsAmendExRateDetable(Convert.ToInt32(ddl_inv.SelectedItem.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_job.Text), ddl_curr.SelectedItem.Text, Convert.ToDouble(txt_ExRate.Text), Session["StrTranType"].ToString(), Convert.ToInt32(hid_Vouyear.Value), Convert.ToDouble(hid_currex.Value), Convert.ToDouble(hid_paex.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToDateTime(logix.Utility.fn_ConvertDate(hid_Updateon.Value)));
                            //obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginUserName"].ToString()), 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                            if (Session["StrTranType"] != null)
                            {
                                if (Session["StrTranType"].ToString() == "FE")
                                {

                                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 371, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                                }
                                else if (Session["StrTranType"].ToString() == "FI")
                                {
                                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 372, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                                }
                                else if (Session["StrTranType"].ToString() == "CH")
                                {
                                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 375, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                                }
                                else
                                {
                                    obj_da_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginUserName"].ToString()), 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_job.Text + "/" + ddl_inv.SelectedItem.Text + "/" + ddl_curr.SelectedItem.Text + "/" + txt_ExRate.Text);
                                }
                            }

                            //' send()
                            ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "alert", "alertify.alert('Ex.Rate Changed to " + txt_ExRate.Text + "')", true);
                            txtclear();
                            txt_job.Focus();
                        }
                    }
                    //}
                }
                btn_Cancel.Text = "Cancel";
                btn_Cancel.ToolTip = "Cancel";
                btn_cancel2.Attributes["class"] = "btn ico-cancel";
                
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txt_Curr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCharges obj_da_chargeobj = new DataAccess.Masters.MasterCharges();
                txt_Curr.Visible = true;
                txt_Curr.Text = txt_Curr.Text.ToUpper();
                if (obj_da_chargeobj.GetCurrID(txt_Curr.Text) != 0)
                {
                    ddl_curr.Items.Add(txt_Curr.Text);
                    ddl_curr.SelectedValue = txt_Curr.Text;
                    ddl_curr.Visible = true;
                    txt_Curr.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "alert", "alertify.alert('Select Correct Currency')", true);
                    txt_Curr.Visible = true;
                    txt_Curr.Focus();
                    ddl_curr.Visible = false;
                }
                btn_Cancel.Text = "Cancel";
                btn_Cancel.ToolTip = "Cancel";
                btn_cancel2.Attributes["class"] = "btn ico-cancel";
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

            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 371, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 372, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 375, "job", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
                }
            }

            if (txt_job.Text != "")
            {
                JobInput.Text = txt_job.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
    }
}