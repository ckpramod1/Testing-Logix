﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using DataAccess.Accounts;

namespace logix.Accounts
{
    public partial class PaymentRequest : System.Web.UI.Page
    {
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingExports.JobInfo obj_da_FEjob = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.JobInfo obj_da_FIjob = new DataAccess.ForwardingImports.JobInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);

            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                logobj.GetDataBase(Ccode);
                branchobj.GetDataBase(Ccode);
                obj_da_Cheque.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                obj_da_FEjob.GetDataBase(Ccode);
                obj_da_FIjob.GetDataBase(Ccode);
               


            }
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (rbt_CNOP.Checked == true || rbt_CNAdmin.Checked == true || rbt_cheque.Checked == true || rbt_CN.Checked == true)
            {
                Lnk_Pending.Attributes.Add("OnClick", "if(confirm('Do you want to Print ?')){ document.getElementById('logix_CPH_hid_confirm').value = 'Y';}else{ document.getElementById('logix_CPH_hid_confirm').value = 'N';}");
            }

            if (!IsPostBack)
            {
                Session["dt1"] = null;
                
                if (Session["StrTranType"].ToString() == "FE")
                {
                    menulbl.Visible = true;
                    lblHead.InnerText = "Ocean Exports";
                    HeaderID.InnerText = "Accounts";
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    menulbl.Visible = true;
                    lblHead.InnerText = "Ocean Imports";
                    HeaderID.InnerText = "Accounts";
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    menulbl.Visible = true;
                    lblHead.InnerText = "Air Exports";
                    HeaderID.InnerText = "Accounts";
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    menulbl.Visible = true;
                    lblHead.InnerText = "Air Imports";
                    HeaderID.InnerText = "Accounts";
                }
                else if (Session["StrTranType"].ToString() == "CO")
                {
                    lblHead.InnerText = "Accounts and Finanace";
                    HeaderID.InnerText = "Voucher";
                }
                else if (Session["StrTranType"].ToString() == "AC")
                {
                    lblHead.InnerText = "Operating Accounts";
                    HeaderID.InnerText = "Voucher";
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    lblHead.InnerText = "Custom Home Agent";
                    HeaderID.InnerText = "Accounts";

                }
                Btn_cancel.Visible = false;
                btn_cancel2.Visible = false;
                if (Request.QueryString.ToString().Contains("type"))
                {
                    string product = Request.QueryString["type"].ToString();
                    if (product == "CN")
                    {
                        rbt_CN.Checked = true;
                        rbt_CN_CheckedChanged(sender, e);
                        Btn_cancel.Visible = true;
                        btn_cancel2.Visible = true;
                       
                    }
                    else if (product == "CnOps")
                    {
                        rbt_CNOP.Checked = true;
                        rbt_CNOP_CheckedChanged(sender, e);
                        Btn_cancel.Visible = true;
                        btn_cancel2.Visible = true;
                    }

                }

                try
                {

                    string Str_trantype = Session["StrTranType"].ToString();
                    if (Str_trantype == "AC")
                    {
                        rbt_CNAdmin.Visible = true;
                        rbt_cheque.Visible = true;
                    }
                    else if (Str_trantype == "CA")
                    {
                        Str_trantype = "AC";
                        rbt_CNAdmin.Visible = true;
                        rbt_CNOP.Enabled = false;
                        rbt_CN.Enabled = false;
                        rbt_cheque.Enabled = false;
                    }
                    else
                    {
                        rbt_CNAdmin.Visible = false;
                        rbt_cheque.Visible = false;
                    }
                    
                    Grd_Cheque.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Cheque.DataBind();
                    Fn_ClearSession();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
              
            }
            headerid1.InnerText = lbl_Header.Text;
        }

        [WebMethod]
        public static List<string> ApprovedBy_Name(string prefix)
        {
            List<string> customername = new List<string>();
            DataTable obj_dt = new DataTable();

            obj_dt = (DataTable)HttpContext.Current.Session["dt1"];
            DataView dv_Filter = new DataView(obj_dt);
            dv_Filter.RowFilter = "custname like '" + prefix + "%'";

            obj_dt = dv_Filter.ToTable();

            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    if (obj_dt.Rows[i][0].ToString() != "")
                    {
                        customername = Utility.Fn_DatatableToList_Text(obj_dt, "custname");
                    }
                }
            }

            return customername;
        }



        [WebMethod]
        public static List<string> Vouno(string prefix)
        {
            List<string> Vouno = new List<string>();
            DataTable obj_dt = new DataTable();

            obj_dt = (DataTable)HttpContext.Current.Session["dt1"];
            DataView dv_Filter = new DataView(obj_dt);

            //dataView.RowFilter = "Convert([Some Column], System.String) LIKE '12%'"; 

            dv_Filter.RowFilter = "Convert([vouno], System.String) like '" + prefix + "%'";

            obj_dt = dv_Filter.ToTable();

            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    if (obj_dt.Rows[i][1].ToString() != "")
                    {
                        Vouno = Utility.Fn_DatatableToList_Text(obj_dt, "vouno");

                        //int vouno = Convert.ToInt32(obj_dt.Rows[i][0].ToString());
                        //Vouno = Utility.Fn_InttableToList(obj_dt, vouno);
                    }
                }
            }

            return Vouno;
        }


        [WebMethod]
        public static void GetVouno(string Prefix)
        {

            //DataTable obj_dtEmp = new DataTable();
            //DataTable dt1 = new DataTable();
            //DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();
            //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
            //if (Prefix.Length > 0)
            //{
            //    if (HttpContext.Current.Session["dt1"]!=null)
            //    {
            //        obj_dtEmp = HttpContext.Current.Session["dt1"] as DataTable;
            //        if (obj_dtEmp.Rows.Count > 0)
            //        {
            //            DataView data1 = obj_dtEmp.DefaultView;
                  
            //        data1.RowFilter = "Convert([vouno], System.String) LIKE '" + Prefix.ToString() + "%'";
            //        obj_dtEmp = data1.ToTable();
            //        HttpContext.Current.Session["dttt"] = obj_dtEmp;
            //        }
            //    }
                
            //}

            DataTable obj_dtEmp = new DataTable();
            DataTable dt1 = new DataTable();
            //DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();
            //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
            if (Prefix.Length > 0)
            {
                obj_dtEmp = HttpContext.Current.Session["dt1"] as DataTable;
                DataView data1 = obj_dtEmp.DefaultView;
                data1.RowFilter = "Convert([vouno], System.String) LIKE '" + Prefix.ToString() + "%'";
                obj_dtEmp = data1.ToTable();
                HttpContext.Current.Session["dttt"] = obj_dtEmp;
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
                Grd_Cheque.DataSource = dt_ok;
                Grd_Cheque.DataBind();
                ViewState["grd_cheq"] = dt_ok;
               Session["dt1"] = dt_ok;
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
            btn_update_id.Visible = true;
            btn_update.Visible = true;
            lbl_total.Visible = true;
            txt_PAamount.Visible = true;
            txt_TDSamount.Visible = true;
            Session["Amount"] = null;
            Session["TDSAmount"] = null;
            Session["Row"] = null;
            Session["dt1"] = null;
            drp_SortedBy.SelectedValue = "0";
        }
        protected void rbt_CNOP_CheckedChanged(object sender, EventArgs e)
        {
            Fn_ClearSession();
            if (rbt_CNOP.Checked == true)
            {
                Fn_Getdetail();
            }
        }
        protected void rbt_CN_CheckedChanged(object sender, EventArgs e)
        {
            Fn_ClearSession();
            if (rbt_CN.Checked == true)
            {
                Fn_Getdetail();
            }
        }
        protected void rbt_CNAdmin_CheckedChanged(object sender, EventArgs e)
        {
            Fn_ClearSession();
            if (rbt_CNAdmin.Checked == true)
            {
                Fn_Getdetail();
            }
        }
        protected void Grd_Cheque_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Cheque.PageIndex = e.NewPageIndex;
            //Fn_Getdetail();
            DataTable dt = (DataTable)ViewState["grd_cheq"];
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
                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "PaymentRequest", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                DataTable dt_ok = new DataTable();
                if (rbt_CNOP.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetPendingPayment4ChqReq("PA", Session["StrTranType"].ToString(), int_bid, int_Empid);
                }
                else if (rbt_CN.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetPendingPayment4ChqReq("CN", Session["StrTranType"].ToString(), int_bid, int_Empid);
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    dt_ok = obj_da_Cheque.GetPendingPayment4ChqReq("AP", Session["StrTranType"].ToString(), int_bid, int_Empid);
                }
                //Lnk_Pending.Attributes.Add("OnClick", "if(confirm('Do you want to Print ?')){ document.getElementById('logix_CPH_hid_confirm').value = 'Y';}else{ document.getElementById('logix_CPH_hid_confirm').value = 'N';}");
                if (hid_confirm.Value.ToString() == "Y")
                {
                    if (dt_ok.Rows.Count > 0)
                    {
                        string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                        Str_RptName = "rptPendingCheReqApp.rpt";
                        Str_sf = "{TempPendingPayment4ChqReqandApp.empid}=" + int_Empid;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "PaymentRequest", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                        ViewState["grd_payment"] = dt_ok;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "PaymentRequest", "alertify.alert('No Pending Payment Exists to Print');", true);
                        return;
                    }
                }
                else if (hid_confirm.Value.ToString() == "N")
                {
                    if (dt_ok.Rows.Count > 0)
                    {
                        //pln_Grg.Show();
                        panel.Visible = false;
                        Grd_Cheque.Visible = false;
                        btn_update_id.Visible= false;
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
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "PaymentRequest", "alertify.alert('No Pending Payment Exists to View');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void lnkdetail_Click(object sender, EventArgs e)
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

            }
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
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
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnkCheque_Click(object sender, EventArgs e)
        {
            hid_row.Value = string.Empty;
            popup_favour.Show();
            LinkButton Lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;
            //txt_favour_cheque.Text = Grd_Cheque.Rows[row.RowIndex].Cells[4].Text.ToString();
            //Label custname = (Label)Grd_Cheque.Rows[row.RowIndex].FindControl("favourname");
            string custname = ((Label)Grd_Cheque.Rows[row.RowIndex].Cells[4].FindControl("custname")).Text;
            txt_favour_cheque.Text = custname.ToString();
            hid_row.Value = row.RowIndex.ToString();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grd_Cheque.Visible == false)
                {
                    return;
                }
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "PaymentRequest", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }
                Boolean Check = false;
                DataTable dt_Pan = new DataTable();
                //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
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
                        //string fv = favour.Value;
                        if (favour.Value.ToString().Trim().Length > 0)
                        {
                            str_favourname = favour.Value.ToString();
                        }
                        else
                        {
                            Label custname = (Label)Grd_Cheque.Rows[row.RowIndex].FindControl("custname");
                            str_favourname = custname.Text;
                        }

                        if (rbt_CNOP.Checked == true)
                        {
                            obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "PA", char.Parse(ddl.SelectedValue.ToString()), remark.Value.ToString(), str_favourname);
                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 992, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "FI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 993, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AE":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 994, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 995, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "CH":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 996, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AC":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 997, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "MI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1072, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                            }
                        }
                        else if (rbt_CN.Checked == true)
                        {
                            obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "CN", char.Parse(ddl.SelectedValue.ToString()), remark.Value.ToString(), str_favourname);
                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 992, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "FI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 993, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AE":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 994, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 995, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "CH":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 996, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AC":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 997, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "MI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1072, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                            }
                        }
                        else if (rbt_CNAdmin.Checked == true)
                        {
                            dt_Pan = obj_da_Cheque.GetVendorPanno4Cust(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), "AP", int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()));
                            if (dt_Pan.Rows.Count > 0)
                            {
                                if (dt_Pan.Rows[0]["panno"].ToString().Length < 10)
                                {
                                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "PaymentRequest", "alertify.alert('PAN number Not available for this Vendor " + dt_Pan.Rows[0]["customername"] + " . PAN number is mandatory to make the Payment.');", true);
                                    return;
                                }
                                else
                                {
                                    obj_da_Cheque.UpdChequeRequest(int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()), Grd_Cheque.DataKeys[row.RowIndex].Values[4].ToString(), int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), int_Empid, "AP", char.Parse(ddl.SelectedValue.ToString()), remark.Value.ToString(), str_favourname);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "PaymentRequest", "alertify.alert('PAN number Not available for this Vendor. PAN number is mandatory to make the Payment.');", true);
                                return;
                            }
                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 992, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "FI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 993, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AE":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 994, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 995, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "CH":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 996, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "AC":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 997, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                                case "MI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1072, 2, int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString()), "Vou # :" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString()) + "/Vouyear" + int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString()) + "/Voutype: PA/ U");
                                    break;
                            }
                        }
                    }

                }

                if (Check == false)
                {
                    if (rbt_CNOP.Checked == true)
                    {
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "PaymentRequest", "alertify.alert('Please Select Atleast a CN Ops # for Request');", true);
                        return;
                    }
                    else if (rbt_CN.Checked == true)
                    {
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "PaymentRequest", "alertify.alert('Please Select Atleast a CN # for Request');", true);
                        return;
                    }
                    else if (rbt_CNAdmin.Checked == true)
                    {
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "PaymentRequest", "alertify.alert('Please Select Atleast a CN Adm # for Request');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "PaymentRequest", "alertify.alert('Detail Update');", true);
                    Fn_Getdetail();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        
        protected void rbt_cheque_CheckedChanged(object sender, EventArgs e)
        {

            iframecost.Attributes["src"] = "../Accounts/ACNotOverCheque.aspx?Type=C";
            popup_cheque.Show();

        }
        protected void Grd_Cheque_DataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                 

                    Label lblCustomer = (Label)e.Row.FindControl("custname");
                    string tooltip = lblCustomer.Text;
                    e.Row.Cells[3].Attributes.Add("title", tooltip);


                  
                }
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Payment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Payment.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["grd_payment"];
            Grd_Payment.DataSource = dt;
            Grd_Payment.DataBind();
        }

        protected void Lnk_Vouno_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton Lnk = sender as LinkButton;
                GridViewRow rws = (GridViewRow)Lnk.NamingContainer;
                
                string str_Type = "", str_BL = "", Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_Container = "";
                int int_jobno = 0, int_vouyear = 0, int_invno = 0, int_Loginbid = 0, int_bid = 0;
                str_Type = Grd_Cheque.Rows[rws.RowIndex].Cells[16].Text;  //Grd_Cheque.SelectedDataKey[4].ToString();
                str_BL = Grd_Cheque.Rows[rws.RowIndex].Cells[14].Text;  //Grd_Cheque.SelectedDataKey[2].ToString();
                int_jobno = Convert.ToInt32(Grd_Cheque.Rows[rws.RowIndex].Cells[15].Text); //int.Parse(Grd_Cheque.SelectedDataKey[3].ToString());
                int_vouyear = Convert.ToInt32(Grd_Cheque.Rows[rws.RowIndex].Cells[12].Text); //int.Parse(Grd_Cheque.SelectedDataKey[0].ToString());
                int_invno = Convert.ToInt32(((LinkButton)Grd_Cheque.Rows[rws.RowIndex].Cells[0].FindControl("Lnk_Vouno")).Text); //int.Parse(Grd_Cheque.SelectedDataKey[5].ToString());
                int_bid = Convert.ToInt32(Grd_Cheque.Rows[rws.RowIndex].Cells[13].Text); //int.Parse(Grd_Cheque.SelectedDataKey[1].ToString());
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
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FIPA.rpt";
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AEPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AIPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "CHAPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        //Session["str_sfs"] = Str_sf;
                        Session["str_sfs"] = "{PAHead.trantype}='" + str_Type + "' and {PAHead.pano}=" + int_invno + " and {PAHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;
                        //Str_sf = "{PAHead.trantype}=\"" + str_Type + "\" and {PAHead.pano}=" + int_invno + " and {PAHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "PaymentRequest", Str_Script, true);
                    }
                    else
                    {
                        if (str_Type == "FE")
                        {
                            Str_RptName = "FEMPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FIMPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AEMPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AIMPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "CHAPA.rpt";
                            Str_sp = "Lcurr=INR";
                        }
                        Session["str_sfs"] = "{PAHead.trantype}='" + str_Type + "' and {PAHead.pano}=" + int_invno + " and {PAHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;
                        //Str_sf = "{PAHead.trantype}=\"" + str_Type + "\" and {PAHead.pano}=" + int_invno + " and {PAHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "PaymentRequest", Str_Script, true);
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
                            //Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                            Str_sp = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FICN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            //Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "container=" + Str_Container;
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AECN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            //Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AICN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            //Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "AICN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            //Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "PaymentRequest", Str_Script, true);
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
                            //DataAccess.ForwardingImports.JobInfo obj_da_FIjob = new DataAccess.ForwardingImports.JobInfo();
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
                            Str_sp = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FIMCN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AEMCN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AIMCN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Session["str_sfs"] = "{CNHead.trantype}='" + str_Type + "' and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "PaymentRequest", Str_Script, true);
                    //   Session["str_sfs"] = Str_sf;
                    }
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    if (int_invno != 0)
                    {
                        Str_RptName = "AdmCredit.rpt";
                        Session["str_sfs"] = "{AdmCNHead.cnno}=" + int_invno + " and {AdmCNHead.vouyear}=" + int_vouyear + " and {AdmCNHead.branchid}=" + int_bid + " and {AdmCNHead.deleted}='N'";
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "PaymentRequest", Str_Script, true);
                    }
                }
                Session["str_sp"] = Str_sp;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
                        //txt_favour_cheque.Text = "";
                        //txt_remark_cheque.Text = "";
                        //hid_row.Value = string.Empty;
                        popup_favour.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
                        //txt_favour_cheque.Text = "";
                        txt_remark_cheque.Text = "";
                        //hid_row.Value = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Cheque_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (Grd_Cheque.Rows.Count > 0)
                {
                    Grd_Cheque.UseAccessibleHeader = true;
                    Grd_Cheque.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Cheque_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string sortingDirection = string.Empty;
                if (dir == SortDirection.Ascending)
                {
                    dir = SortDirection.Descending;
                    sortingDirection = "Desc";
                }
                else
                {
                    dir = SortDirection.Ascending;
                    sortingDirection = "Asc";
                }

                //  DataView sortedView = (DataView)ViewState["dirState1"];
                DataTable dsortview = (DataTable)ViewState["grd_cheq"];
                DataView sortedView = new DataView();
                sortedView = dsortview.DefaultView;
                sortedView.Sort = e.SortExpression + " " + sortingDirection;
                Grd_Cheque.DataSource = sortedView;
                Grd_Cheque.DataBind();
                ViewState["grd_cheq"] = sortedView;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public SortDirection dir
        {

            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                    //DataTable dstate = (DataTable)ViewState["dirState"];
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataTable obj_dtEmp = new DataTable();
            if (Session["dttt"] != null)
            {
                obj_dtEmp = (DataTable)Session["dttt"];

                //DataView data1 = obj_dtEmp.DefaultView;
                //data1.RowFilter = "divsname  Like'" + cmbbranch.SelectedValue.Substring(0, 1) + "%'";
                //dt1 = data1.ToTable();
                if (txt_search.Text != "")
                {
                    Grd_Cheque.DataSource = obj_dtEmp;
                    Grd_Cheque.DataBind();
                    Session["dttt"] = null;
                  
                }
                else
                {
                    Fn_Getdetail();
                }
            }
            else
            {
                Fn_Getdetail();
            }
           

        }

        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            if(Btn_cancel.ToolTip=="Cancel")
            {
                Grd_Payment.DataSource = new DataTable();
                Grd_Payment.DataBind();
                Grd_Cheque.DataSource = new DataTable();
                Grd_Cheque.DataBind();
             Btn_cancel.Text = "Back";
                Btn_cancel.ToolTip = "Back";
                btn_cancel2.Attributes["class"] = "btn ico-back";
            }
            else
            {
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "AC&FINhome")
                    {
                        Response.Redirect("../Home/CorpAccNFinance.aspx");
                    }
                    else if (Session["home"].ToString() == "CredConthome")
                    {
                        Response.Redirect("../Home/CorpCreditControl.aspx");
                    }
                    else if (Session["home"].ToString() == "Budgethome")
                    {
                        Response.Redirect("../Home/CorpBudgetHome.aspx");
                    }
                    else
                    {
                        this.Response.End();
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }

        protected void txt_Filterby_TextChanged(object sender, EventArgs e)
        {
             string Favour_Name;
            try
            {
                DataTable Obj_dt = new DataTable();
                Obj_dt = (DataTable)HttpContext.Current.Session["dt1"] ;

                DataView dt_view = new DataView(Obj_dt);
                dt_view.RowFilter = "custname like '" + txt_Filterby.Text + "%'";
                Obj_dt = dt_view.ToTable();

                if (Obj_dt.Rows.Count > 0)
                {
                    Favour_Name = Obj_dt.Rows[0]["custname"].ToString();
                    txt_Filterby.Text = Favour_Name;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Name');", true);
                }

                GridFilter();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void GridFilter()
        {
            string filter_field = "";

            try
            {
                if (txt_Filterby.Text != "")
                {
                    filter_field = "custname like '" + txt_Filterby.Text + "'";
                }

                DataTable dt_ApprovedDet = new DataTable();
                dt_ApprovedDet = Session["dt1"] as DataTable;
                DataView dt_GridDetails = new DataView(dt_ApprovedDet);

                if (filter_field != "")
                {
                    dt_GridDetails.RowFilter = filter_field;
                }

                DataTable chequedet = new DataTable();
                chequedet = dt_GridDetails.ToTable();

                Grd_Cheque.DataSource = chequedet;
                Grd_Cheque.DataBind();

                Session["dt1"] = chequedet;
            }
            catch (Exception ex)
            {
                string Error = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + Error + "')", true);
            }
        }

        protected void drp_SortedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsort = new DataTable();

                if (rbt_CNOP.Checked == true || rbt_CN.Checked == true || rbt_CNAdmin.Checked == true)
                {
                    if (Session["dt1"] != null)
                    {
                        dtsort = Session["dt1"] as DataTable;
                    }
                    DataView dtview = new DataView(dtsort);

                    if (drp_SortedBy.SelectedValue == "Vouno")
                    {
                        dtview.Sort = "vouno DESC";
                    }
                    else if (drp_SortedBy.SelectedValue == "VouDate")
                    {
                        dtview.Sort = "voudate DESC";
                    }
                    else if (drp_SortedBy.SelectedValue == "Vendor")
                    {
                        dtview.Sort = "custname DESC";
                    }
                    else if (drp_SortedBy.SelectedValue == "PAAmount")
                    {
                        dtview.Sort = "vouamt DESC";
                    }

                    DataTable Sort_dt = new DataTable();
                    Sort_dt = dtview.ToTable();

                    Grd_Cheque.DataSource = Sort_dt;
                    Grd_Cheque.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "PaymentRequest", "alertify.alert('Please Select Any One Voucher');", true);
                    drp_SortedBy.SelectedValue = "0";
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        
    }
}