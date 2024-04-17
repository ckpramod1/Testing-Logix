using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForm
{
    public partial class ChequeRequest_Vou : System.Web.UI.Page
    {
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingExports.JobInfo obj_da_FEjob = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.JobInfo obj_da_FIjob = new DataAccess.ForwardingImports.JobInfo();
         DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string str_trantype, str_Formname;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                logobj.GetDataBase(Ccode);
                obj_da_Cheque.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                obj_da_FEjob.GetDataBase(Ccode);
                obj_da_FIjob.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               

            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "AutoGenerateLabels();", true);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (rbt_CNOP.Checked == true || rbt_CNAdmin.Checked == true || rbt_cheque.Checked == true || rbt_CN.Checked == true)
            {
                Lnk_Pending.Attributes.Add("OnClick", "if(confirm('Do you want to Print ?')){ document.getElementById('logix_CPH_hid_confirm').value = 'Y';}else{ document.getElementById('logix_CPH_hid_confirm').value = 'N';}");
            }
            
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_Header.Text = Request.QueryString["FormName"].ToString();                
            }
            //if (Session["str_ModuleName"].ToString()!=null)
            //{
            //    if (Session["str_ModuleName"].ToString() == "FC")
            //    {
            //        str_trantype = "CA";
            //    }
            //    else
            //    {
            //        str_trantype = "AC";
            //    }
            //}
            

            if (!IsPostBack)
            {             
                try
                {
                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                    if (str_trantype == "AC")
                    {
                        rbt_CNAdmin_id.Visible = true;
                        rbt_CNAdmin.Visible = true;
                        rbt_cheque.Visible = true;
                    }
                    else if (str_trantype == "CA")
                    {
                        str_trantype = "AC";
                        rbt_CNAdmin_id.Visible = true;

                        rbt_CNAdmin.Visible = true;
                        //rbt_CNOP.Enabled = false;
                        rbt_CN.Enabled = false;
                        rbt_cheque.Enabled = false;
                        notovercheque_rbt.Visible = false;
                    }
                    else
                    {
                        rbt_CNAdmin_id.Visible = false;

                        rbt_CNAdmin.Visible = false;
                        notovercheque_rbt.Visible = false;
                        rbt_cheque.Visible = false;
                    }
                    
                    Grd_Cheque.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Cheque.DataBind();
                    Fn_ClearSession();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
                }
            }
        }

        private void Fn_Getdetail()
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                DataTable dt_ok = new DataTable();
                if (rbt_CNOP.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetChequeRequest("PA", Session["StrTranType"].ToString(), int_bid, int_divisionid);
                }
                else if (rbt_CN.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetChequeRequest("CN", Session["StrTranType"].ToString(), int_bid, int_divisionid);
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetChequeRequest("AP", Session["StrTranType"].ToString(), int_bid, int_divisionid);
                }

                DataColumn dc_favour = new DataColumn("favourname", typeof(System.String));
                dc_favour.DefaultValue = string.Empty;
                dt_ok.Columns.Add(dc_favour);
                DataColumn dc_remark = new DataColumn("remark", typeof(System.String));
                dc_remark.DefaultValue = string.Empty;
                dt_ok.Columns.Add(dc_remark);
                Grd_Cheque.Visible = true;
                Grd_Cheque.PageIndex = 0;
                Grd_Cheque.DataSource = dt_ok;
                Grd_Cheque.DataBind();                                                  
                Session["grd_cheq"] = dt_ok;  
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }        
        
        private void Fn_ClearSession()
        {
            panel1.Visible = false;
            panel.Visible = true;
            Grd_Cheque.Visible = true;
            btn_update.Visible = true;
            lbl_total.Visible = true;
            txt_PAamount.Visible = true;
            txt_TDSamount.Visible = true;
            Session["Amount"] = null;
            Session["TDSAmount"] = null;
            Session["Row"] = null;
            Grd_Cheque.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Cheque.DataBind();
        }

        protected void rbt_CNOP_CheckedChanged(object sender, EventArgs e)
        {
            Fn_ClearSession();
            if (rbt_CNOP.Checked == true)
            {              
                txt_VouYear.Text = "";
            }
        }

        protected void rbt_CN_CheckedChanged(object sender, EventArgs e)
        {
            Fn_ClearSession();
            if (rbt_CN.Checked == true)
            {                
                txt_VouYear.Text = "";
            }
        }

        protected void rbt_CNAdmin_CheckedChanged(object sender, EventArgs e)
        {
            Fn_ClearSession();
            if (rbt_CNAdmin.Checked == true)
            {               
                txt_VouYear.Text = "";
            }
        }

        protected void Grd_Cheque_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {            
            Grd_Cheque.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["dt_ChequeDet"];
            Grd_Cheque.DataSource = dt;
            Grd_Cheque.DataBind();

            if (Session["Row"] != null)
            {
                List<string> Items = (List<string>)Session["Row"];
                foreach (GridViewRow row in Grd_Cheque.Rows)
                {
                    var result = Items.Find(item => item == Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString());
                    if (result != null)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("Chk_Select");
                        if (chk != null)
                        {
                            chk.Checked = true;
                        }
                    }
                }
            }
        }

        protected void Lnk_Pending_Click(object sender, EventArgs e)
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
              //  DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                DataTable dt_ok = new DataTable();

                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequest", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }

                if (rbt_CNOP.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetPendingPayment4ChqReqVouyearwise("PA", Session["StrTranType"].ToString(), int_bid, int_Empid, Convert.ToInt32(txt_VouYear.Text));
                }
                else if (rbt_CN.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetPendingPayment4ChqReqVouyearwise("CN", Session["StrTranType"].ToString(), int_bid, int_Empid, Convert.ToInt32(txt_VouYear.Text));
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetPendingPayment4ChqReqVouyearwise("AP", Session["StrTranType"].ToString(), int_bid, int_Empid, Convert.ToInt32(txt_VouYear.Text));
                }

                if (txt_VouYear.Text != "")
                {
                    if (hid_confirm.Value.ToString() == "Y")
                    {
                        if (dt_ok.Rows.Count > 0)
                        {
                            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                            Str_RptName = "rptPendingCheReqApp.rpt";
                            Session["str_sfs"] = "{TempPendingPayment4ChqReqandApp.empid}=" + int_Empid;
                            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequest", Str_Script, true);
                            Session["str_sfs"] = Str_sf;
                            Session["str_sp"] = Str_sp;
                            ViewState["dt_ChequeDet"] = dt_ok;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequest", "alertify.alert('No Pending Payment Exists to Print');", true);
                            return;
                        }
                    }
                    else if (hid_confirm.Value.ToString() == "N")
                    {
                        if (dt_ok.Rows.Count > 0)
                        {
                            panel.Visible = false;
                            Grd_Cheque.Visible = false;
                            btn_update.Visible = false;
                            lbl_total.Visible = false;
                            txt_PAamount.Visible = false;
                            txt_TDSamount.Visible = false;
                            DataRow dr;
                            dr = dt_ok.NewRow();
                            dt_ok.Rows.Add(dr);
                            dr[3] = "Total";
                            var Payment_total = dt_ok.Compute("sum(vouamt)", "");
                            var TDS_total = dt_ok.Compute("sum(tdsamt)", "");
                            dr[5] = string.Format("{0:0.00}", Payment_total);
                            dr[6] = TDS_total;

                            Grd_Payment.DataSource = dt_ok;
                            Grd_Payment.DataBind();
                            panel1.Visible = true;
                            if (Grd_Payment.Rows.Count > 0)
                            {
                                Grd_Payment.Rows[Grd_Payment.Rows.Count - 1].ForeColor = Utility.fn_Grd_GrandTotal_Color();
                                Grd_Payment.Rows[Grd_Payment.Rows.Count - 1].Font.Bold = Utility.fn_Grd_GrandTotal_Bold();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequest", "alertify.alert('No Pending Payment Exists to View');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter Vouyear')", true);
                        txt_VouYear.Text = "";
                        txt_VouYear.Focus();
                    }                    
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void lnkdetail_Click(object sender, EventArgs e)
        {
            try
            {
                pln_Grg.Show();
                LinkButton Lnk = sender as LinkButton;
                if (Lnk.Text != "Total")
                {
                    GridViewRow row = (GridViewRow)Lnk.NamingContainer;

                    txt_favouring.Text = Grd_Payment.DataKeys[row.RowIndex].Values[6].ToString();
                    if (!DBNull.Value.Equals(Grd_Payment.DataKeys[row.RowIndex].Values[1]))
                    {
                        txt_remark.Text = Grd_Payment.DataKeys[row.RowIndex].Values[1].ToString();
                    }
                    else
                    {
                        txt_remark.Text = "";
                    }
                    if (!DBNull.Value.Equals(Grd_Payment.DataKeys[row.RowIndex].Values[8]))
                    {
                        string str_mode = Grd_Payment.DataKeys[row.RowIndex].Values[8].ToString();
                        if (str_mode == "D")
                        {
                            txt_mode.Text = "DD";
                        }
                        else if (str_mode == "C")
                        {
                            txt_mode.Text = "Cheque";
                        }
                        else if (str_mode == "S")
                        {
                            txt_mode.Text = "Cash";
                        }
                        else if (str_mode == "N")
                        {
                            txt_mode.Text = "NEFT";
                        }
                        else if (str_mode == "R")
                        {
                            txt_mode.Text = "RTGS";
                        }
                        else if (str_mode == "T")
                        {
                            txt_mode.Text = "Not Over Cheque";
                        }
                        else if (str_mode == "A")
                        {
                            txt_mode.Text = "Adjustment";
                        }
                        else
                        {
                            txt_mode.Text = "Others";
                        }
                    }
                    else
                    {
                        txt_mode.Text = "";
                    }

                    popup_detail.Show();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void Grd_Payment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk_detail = (LinkButton)e.Row.FindControl("Lnk");
                if (lnk_detail.Text == "Total")
                {
                    lnk_detail.CssClass = "div_lnk";
                    lnk_detail.Font.Bold = true;
                    lnk_detail.ForeColor = Utility.fn_Grd_GrandTotal_Color();
                }
                
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                }

                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void Chkselect_Click(object sender, EventArgs e)
        {
            try
            {
                double PA_Amount = 0, TDS_Amount = 0;
                CheckBox Chk = sender as CheckBox;
                GridViewRow row = (GridViewRow)Chk.NamingContainer;
                List<string> ItemText = null;
                if (Session["Row"] != null)
                {
                    ItemText = (List<string>)Session["Row"];
                }
                else
                {
                    ItemText = new List<string>();
                }

                if (Chk.Checked == true)
                {
                    ItemText.Add(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString());
                    if (Session["Amount"] == null)
                    {
                        PA_Amount = double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[6].Text.ToString());
                        Session["Amount"] = PA_Amount;
                        txt_PAamount.Text = string.Format("{0:0.00}", PA_Amount);
                    }
                    else
                    {
                        PA_Amount = double.Parse(Session["Amount"].ToString()) + double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[6].Text.ToString());
                        Session["Amount"] = PA_Amount;
                        txt_PAamount.Text = string.Format("{0:0.00}", PA_Amount);
                    }
                    if (Session["TDSAmount"] == null)
                    {
                        TDS_Amount = double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[7].Text.ToString());
                        Session["TDSAmount"] = TDS_Amount;
                        txt_TDSamount.Text = string.Format("{0:0.00}", TDS_Amount);
                    }
                    else
                    {
                        TDS_Amount = double.Parse(Session["TDSAmount"].ToString()) + double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[7].Text.ToString());
                        Session["TDSAmount"] = TDS_Amount;
                        txt_TDSamount.Text = string.Format("{0:0.00}", TDS_Amount);
                    }
                }
                else
                {
                    PA_Amount = double.Parse(Session["Amount"].ToString()) - double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[6].Text.ToString());
                    Session["Amount"] = PA_Amount;
                    txt_PAamount.Text = string.Format("{0:0.00}", PA_Amount);

                    TDS_Amount = double.Parse(Session["TDSAmount"].ToString()) - double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[7].Text.ToString());
                    Session["TDSAmount"] = TDS_Amount;
                    txt_TDSamount.Text = string.Format("{0:0.00}", TDS_Amount);

                    var result = ItemText.Find(item => item == Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString());

                    if (result != null)
                    {
                        ItemText.Remove(result.ToString());
                    }
                }
                Session["Row"] = ItemText;
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void lnkCheque_Click(object sender, EventArgs e)
        {
            try
            {
                hid_row.Value = string.Empty;
                popup_favour.Show();
                LinkButton Lnk = sender as LinkButton;
                GridViewRow Row = (GridViewRow)Lnk.NamingContainer;
                txt_favour_cheque.Text = ((LinkButton)Grd_Cheque.Rows[Row.RowIndex].Cells[4].FindControl("custname")).Text;
                hid_row.Value = Row.RowIndex.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                if (Grd_Cheque.Visible == false)
                {
                    return;
                }

                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequest", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }

                Boolean Check = false;
                DataTable dt_Pan = new DataTable();
               // DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();

                if (Grd_Cheque.Rows.Count > 0)
                {
                    foreach (GridViewRow row in Grd_Cheque.Rows)
                    {
                        string str_favourname = "";
                        CheckBox Chk = (CheckBox)Grd_Cheque.Rows[row.RowIndex].FindControl("Chk_Select");
                        if (Chk.Checked == true)
                        {
                            Check = true;
                            DropDownList ddl = (DropDownList)Grd_Cheque.Rows[row.RowIndex].FindControl("ddl_module");
                            HiddenField favour = (HiddenField)Grd_Cheque.Rows[row.RowIndex].FindControl("hid_name");
                            HiddenField remark = (HiddenField)Grd_Cheque.Rows[row.RowIndex].FindControl("hid_remark");

                            txt_favour_cheque.Text = ((LinkButton)Grd_Cheque.Rows[row.RowIndex].Cells[4].FindControl("custname")).Text;

                            if (txt_favour_cheque.Text != "")
                            {
                                str_favourname = txt_favour_cheque.Text;

                                if (rbt_CNOP.Checked == true)
                                {
                                    obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "PA", char.Parse(ddl.SelectedValue.ToString()), txt_remark_cheque.Text, str_favourname);

                                    if (Session["StrTranType"].ToString() == "CA")
                                    {
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN-Ops" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                    else
                                    {
                                       // logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN-Ops" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1420, 2, int_bid, "CN-Ops" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                }
                                else if (rbt_CN.Checked == true)
                                {
                                    obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "CN", char.Parse(ddl.SelectedValue.ToString()), txt_remark_cheque.Text, str_favourname);
                                    if (Session["StrTranType"].ToString() == "CA")
                                    {
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                    else
                                    {
                                       // logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1420, 2, int_bid, "CN" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                }
                                else if (rbt_CNAdmin.Checked == true)
                                {
                                    obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "CN", char.Parse(ddl.SelectedValue.ToString()), txt_remark_cheque.Text, str_favourname);
                                    if (Session["StrTranType"].ToString() == "CA")
                                    {
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN-Admin" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                    else
                                    {
                                       // logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN-Admin" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1420, 2, int_bid, "CN-Admin" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                }
                            }
                            else
                            {
                                if (rbt_CNOP.Checked == true)
                                {
                                    obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "PA", char.Parse(ddl.SelectedValue.ToString()), txt_remark_cheque.Text, str_favourname);

                                    if (Session["StrTranType"].ToString() == "CA")
                                    {
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN-Ops" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                    else
                                    {
                                        //logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN-Ops" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1420, 2, int_bid, "CN-Ops" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                }
                                else if (rbt_CN.Checked == true)
                                {
                                    obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "CN", char.Parse(ddl.SelectedValue.ToString()), txt_remark_cheque.Text, str_favourname);
                                    if (Session["StrTranType"].ToString() == "CA")
                                    {
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                    else
                                    {
                                        //logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1420, 2, int_bid, "CN" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                }
                                else if (rbt_CNAdmin.Checked == true)
                                {
                                    obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "CN", char.Parse(ddl.SelectedValue.ToString()), txt_remark_cheque.Text, str_favourname);
                                    if (Session["StrTranType"].ToString() == "CA")
                                    {
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN-Admin" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                    else
                                    {
                                        //logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1421, 2, int_bid, "CN-Admin" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1420, 2, int_bid, "CN-Admin" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString() + " /U");
                                    }
                                }
                            }
                        }
                    }
                    if (Check == false)
                    {
                        if (rbt_CNOP.Checked == true)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequest", "alertify.alert('Please Select Atleast a CN Ops # for Request');", true);
                            return;
                        }
                        else if (rbt_CN.Checked == true)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequest", "alertify.alert('Please Select Atleast a CN # for Request');", true);
                            return;
                        }
                        else if (rbt_CNAdmin.Checked == true)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequest", "alertify.alert('Please Select Atleast a CN Adm # for Request');", true);
                            return;
                        }
                    }
                    else
                    {
                        FillGrid();
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequest", "alertify.alert('Detail Update');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequest", "alertify.alert('No Rows to Update');", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        
        protected void rbt_cheque_CheckedChanged(object sender, EventArgs e)
        {
            iframecost.Attributes["src"] = "../FAForms/ACNotOverCheque.aspx?Type=C";
            popup_cheque.Show();
        }
        
        protected void Grd_Payment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Payment.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)Session["grd_payment"];
            Grd_Payment.DataSource = dt;
            Grd_Payment.DataBind();           
        }

        protected void Lnk_Vouno_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton Lnk = sender as LinkButton;
                GridViewRow Row = (GridViewRow)Lnk.NamingContainer;
                string str_Type = "", str_BL = "", Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_Container = "";
                int int_jobno = 0, int_vouyear = 0, int_invno = 0, int_Loginbid = 0, int_bid = 0;

                str_Type = Grd_Cheque.DataKeys[Row.RowIndex].Values[4].ToString();
                str_BL = Grd_Cheque.DataKeys[Row.RowIndex].Values[2].ToString();
                int_jobno = Convert.ToInt32(Grd_Cheque.DataKeys[Row.RowIndex].Values[3].ToString());
                int_vouyear = Convert.ToInt32(Grd_Cheque.DataKeys[Row.RowIndex].Values[0].ToString());
                int_invno = Convert.ToInt32(Grd_Cheque.DataKeys[Row.RowIndex].Values[5].ToString());
                int_bid = Convert.ToInt32(Grd_Cheque.DataKeys[Row.RowIndex].Values[1].ToString());                                       
                
                int_Loginbid = int.Parse(Session["LoginBranchid"].ToString());
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable dt_ok = new DataTable();
                DataTable dt_oktemp = new DataTable();
                dt_ok = obj_da_Invoice.CheckHblno(str_BL, str_Type, int_Loginbid);

                if (rbt_CNOP.Checked == true)
                {
                    if (dt_ok.Rows.Count > 0)
                    {
                        if (str_Type == "FE")
                        {
                            Str_RptName = "fepa.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FIPA.rpt";
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AEPA.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AIPA.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "CHAPA.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        
                        Session["str_sfs"] = "{PAHead.trantype}='" + str_Type + "' and {PAHead.pano}=" + int_invno + " and {PAHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;                       
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                    }
                    else
                    {
                        if (str_Type == "FE")
                        {
                            Str_RptName = "FEMPA.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FIMPA.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AEMPA.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AIMPA.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "CHAPA.rpt";
                            Session["str_sp"] = "Lcurr=INR";
                        }

                        Session["str_sfs"] = "{PAHead.trantype}='" + str_Type + "' and {PAHead.pano}=" + int_invno + " and {PAHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;                        
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                    }
                }
                else if (rbt_CN.Checked == true)
                {
                    if (dt_ok.Rows.Count > 0)
                    {
                        if (str_BL.Trim().Length > 0)
                        {
                            dt_oktemp = obj_da_Invoice.GetHBLContainerDtls(str_BL, str_Type, int_Loginbid);
                            if (dt_oktemp.Rows.Count > 0)
                            {
                                var obj_Container = dt_oktemp.AsEnumerable().Select(row => row.Field<string>("containerno").ToString());
                                Str_Container = string.Join(",", obj_Container);
                            }
                        }
                        dt_oktemp = obj_da_Invoice.ShowIPHead(int_invno, "AC", "CNHead", int_vouyear, int_Loginbid);
                        int int_custid = 0;
                        if (dt_oktemp.Rows.Count > 0)
                        {
                            int_custid = int.Parse(dt_oktemp.Rows[0].ItemArray[4].ToString());
                        }
                        if (str_Type == "FE")
                        {
                            Str_RptName = "FECN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                            Session["str_sp"] = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FICN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "container=" + Str_Container;
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AECN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AICN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "AICN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                    }
                    else
                    {
                        if (str_Type == "FE")
                        {
                            //DataAccess.ForwardingExports.JobInfo obj_da_FEjob = new DataAccess.ForwardingExports.JobInfo();
                            dt_oktemp = obj_da_FEjob.GetContainerDetails(int_jobno, int_jobno.ToString(), int_Loginbid, int.Parse(Session["LoginDivisionId"].ToString()));
                        }
                        else if (str_Type == "FI")
                        {
                           // DataAccess.ForwardingImports.JobInfo obj_da_FIjob = new DataAccess.ForwardingImports.JobInfo();
                            dt_oktemp = obj_da_FIjob.BindJobDetails(int_jobno, int_jobno.ToString(), int_Loginbid, int.Parse(Session["LoginDivisionId"].ToString()));
                        }

                        if (dt_oktemp.Rows.Count > 0)
                        {
                            var obj_Container = dt_oktemp.AsEnumerable().Select(row => row.Field<string>("containerno").ToString());
                            Str_Container = string.Join(",", obj_Container);
                        }
                        dt_oktemp = obj_da_Invoice.ShowIPHead(int_invno, "AC", "CNHead", int_vouyear, int_Loginbid);
                        int int_custid = 0;
                        if (dt_oktemp.Rows.Count > 0)
                        {
                            int_custid = int.Parse(dt_oktemp.Rows[0].ItemArray[4].ToString());
                        }
                        if (str_Type == "FE")
                        {
                            Str_RptName = "FEMCN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FIMCN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AEMCN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AIMCN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;
                            Session["str_sp"] = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);                     
                    }
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    if (int_invno != 0)
                    {
                        Str_RptName = "AdmCredit.rpt";
                        Session["str_sfs"] = "{AdmCNHead.cnno}=" + int_invno + " and {AdmCNHead.vouyear}=" + int_vouyear + " and {AdmCNHead.branchid}=" + int_bid + " and {AdmCNHead.deleted}='N'";
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                    }
                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_favour_cheque_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hid_row.Value.ToString().Trim().Length > 0)
                {
                    HiddenField hid = (HiddenField)Grd_Cheque.Rows[int.Parse(hid_row.Value.ToString())].FindControl("hid_name");
                    HiddenField hid_remark = (HiddenField)Grd_Cheque.Rows[int.Parse(hid_row.Value.ToString())].FindControl("hid_remark");
                    if (hid != null)
                    {
                        hid.Value = txt_favour_cheque.Text.ToUpper();
                        hid_remark.Value = txt_remark_cheque.Text;
                        popup_favour.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_remark_cheque_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hid_row.Value.ToString().Trim().Length > 0)
                {
                    HiddenField hid = (HiddenField)Grd_Cheque.Rows[int.Parse(hid_row.Value.ToString())].FindControl("hid_name");
                    HiddenField hid_remark = (HiddenField)Grd_Cheque.Rows[int.Parse(hid_row.Value.ToString())].FindControl("hid_remark");
                    if (hid != null)
                    {
                        hid.Value = txt_favour_cheque.Text.ToUpper();
                        hid_remark.Value = txt_remark_cheque.Text;
                        txt_remark_cheque.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequest", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }
                if (txt_VouYear.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter Vouyear')", true);
                    txt_VouYear.Text = "";
                    txt_VouYear.Focus();
                }

                if (txt_VouYear.Text != "")
                {
                    if (rbt_CNOP.Checked == true)
                    {
                        Grd_Cheque.Columns[0].HeaderText = "CN Ops#";
                    }

                    if (rbt_CN.Checked == true)
                    {
                        Grd_Cheque.Columns[0].HeaderText = "CN#";
                    }

                    if (rbt_CNAdmin.Checked == true)
                    {
                        Grd_Cheque.Columns[0].HeaderText = "CN Adm#";
                    }

                    if (rbt_cheque.Checked == true)
                    {

                    }
                    FillGrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter Vouyear')", true);
                    txt_VouYear.Text = "";
                    txt_VouYear.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }  
      
        protected void FillGrid()
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
               // DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                DataTable dt_ChequeDet = new DataTable();

                if (rbt_CNOP.Checked == true)
                {
                    dt_ChequeDet = obj_da_Cheque.GetChequeRequestVouyearwise("PA", str_trantype, int_bid, int_divisionid, Convert.ToInt32(txt_VouYear.Text));
                }

                if (rbt_CN.Checked == true)
                {
                    dt_ChequeDet = obj_da_Cheque.GetChequeRequestVouyearwise("CN", str_trantype, int_bid, int_divisionid, Convert.ToInt32(txt_VouYear.Text));
                }

                if (rbt_CNAdmin.Checked == true)
                {
                    dt_ChequeDet = obj_da_Cheque.GetChequeRequestVouyearwise("AP", str_trantype, int_bid, int_divisionid, Convert.ToInt32(txt_VouYear.Text));
                }

                if (dt_ChequeDet.Rows.Count > 0)
                {
                    for (int j = 0; j < dt_ChequeDet.Rows.Count - 1; j++)
                    {
                        if (dt_ChequeDet.Rows[j]["creditdays"] != "0")
                        {
                            dt_ChequeDet.Rows[j]["duedate"] = dt_ChequeDet.Rows[j]["duedate"];
                        }
                    }
                        
                    Grd_Cheque.DataSource = dt_ChequeDet;
                    Grd_Cheque.DataBind();
                    ViewState["dt_ChequeDet"] = dt_ChequeDet;
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "')", true);
            }
        }

        protected void ddl_Sorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsort = new DataTable();

                if (rbt_CNOP.Checked == true || rbt_CN.Checked == true || rbt_CNAdmin.Checked == true)
                {
                    if (ViewState["dt_ChequeDet"] != null)
                    {
                        dtsort = ViewState["dt_ChequeDet"] as DataTable;
                    }

                    if (dtsort.Rows.Count > 0)
                    {
                        DataView dtview = new DataView(dtsort);

                        if (ddl_Sorting.SelectedValue == "Vouno")
                        {
                            dtview.Sort = "vouno DESC";
                        }
                        else if (ddl_Sorting.SelectedValue == "Cheque Date")
                        {
                            dtview.Sort = "voudate DESC";
                        }
                        else if (ddl_Sorting.SelectedValue == "Vendor")
                        {
                            dtview.Sort = "custname DESC";
                        }
                        else if (ddl_Sorting.SelectedValue == "PAAmount")
                        {
                            dtview.Sort = "vouamt DESC";
                        }

                        DataTable Sort_dt = new DataTable();
                        Sort_dt = dtview.ToTable();

                        Grd_Cheque.DataSource = Sort_dt;
                        Grd_Cheque.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequest", "alertify.alert('Please Select Any One Voucher');", true);
                    ddl_Sorting.SelectedValue = "0";
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
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
          //  DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1420, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1421, "", "", "", Session["StrTranType"].ToString());
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