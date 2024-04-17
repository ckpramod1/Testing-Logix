using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Text;
using System.IO;
using System.Xml;
using System.Web.UI.HtmlControls;
using ClosedXML.Excel;

namespace logix.FAForm
{
    public partial class ChequeRequestApprovalNew : System.Web.UI.Page
    {
        string Str_trantype = null;
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterPort portObj = new DataAccess.Masters.MasterPort();
        DataAccess.HR.Employee HREmpObj = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
        int NPortID;
        string load;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_export1);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://Demo.ifreight.in/','_top');", true);
            }

            if (!IsPostBack)
            {
                try
                {
                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                    Str_trantype = Session["StrTranType"].ToString();
                    Session["StrTranTypeCA"] = Session["StrTranType"].ToString();

                    if (Session["StrTranTypeCA"].ToString() == "CO")
                    {
                        Session["StrTranTypeCA"] = "CA";                       
                        Str_trantype = Session["StrTranTypeCA"].ToString();
                    }
                    else if (Session["StrTranTypeCA"].ToString() == "AC")
                    {
                        //abelid.InnerText = "Operating Accounts";
                    }
                    Fn_LodaBranchDivision();
                    ddl_company.Enabled = false;
                    ddl_company.SelectedItem.Text = Session["LoginDivisionName"].ToString();
                    if (Str_trantype == "CA")
                    {
                        lbl_total.Text = "Total Amount";
                        lbl_tds.Text = "TDS";
                        rbt_CNAdmin.Visible = true;

                    }

                    else
                    {
                        ddl_branch.Enabled = false;
                        ddl_branch.SelectedItem.Text = Session["LoginBranchName"].ToString();
                        lbl_total.Text = "Total Amount";
                        lbl_tds.Text = "Please check whether TDS has applied or not.";
                        rbt_CNAdmin.Visible = false;

                    }
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    txt_approve.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                    Lnk_Pending.Attributes.Add("OnClick", "if(confirm('Do you want to Print ?')){ document.getElementById('logix_CPH_hid_confirm').value = 'Y';}else{ document.getElementById('logix_CPH_hid_confirm').value = 'N';}");
                    Grd_Cheque.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Cheque.DataBind();
                    Fn_ClearSession();
                    if (Request.QueryString.ToString().Contains("cheque"))
                    {
                        hidpageload.Value = "page_load";
                        if (Session["credit"] != null)
                        {
                            popup_cheque.Hide();
                            if (Session["credit"].ToString() == "creditop")
                            {

                                rbt_CNOP.Checked = true;
                                rbt_CNOP_CheckedChanged(sender, e);
                            }
                            else if (Session["credit"].ToString() == "credit")
                            {

                                rbt_CN.Checked = true;
                                rbt_CN_CheckedChanged(sender, e);
                            }
                            else if (Session["credit"].ToString() == "creditCNAdmin")
                            {

                                rbt_CNAdmin.Checked = true;
                                rbt_CNAdmin_CheckedChanged(sender, e);
                            }
                            lnkjob_Click(sender, e);
                        }
                    }

                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        string product = Request.QueryString["type"].ToString();

                        if (product == "CnOps")
                        {
                            rbt_CNOP.Checked = true;
                            rbt_CNOP_CheckedChanged(sender, e);
                        }
                        else if (product == "CN")
                        {
                            rbt_CN.Checked = true;
                            rbt_CN_CheckedChanged(sender, e);
                        }
                        else if (product == "CN Admin")
                        {

                            rbt_CNAdmin.Checked = true;
                            rbt_CNAdmin_CheckedChanged(sender, e);
                        }
                    }

                }
                catch (Exception ex)
                {
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
                }
            }
        }

        //[WebMethod]
        //public static void GetVouNo(int Prefix)
        //{
        //    DataTable dtVouno = new DataTable();
        //    DataTable Newdt = new DataTable();

        //    if (Prefix > 0)
        //    {
        //        dtVouno = HttpContext.Current.Session["Grd_Cheque"] as DataTable;
        //        DataView dtView = dtVouno.DefaultView;
        //        dtView.RowFilter = "vouno like '" + Prefix + "%'";
        //        dtVouno = dtView.ToTable();
        //        HttpContext.Current.Session["dt_Grd_Cheque"] = dtVouno;


                //    HttpContext.Current.Session["Grd_Cheque"] = null;
                //}
                //else if (HttpContext.Current.Session["Grd_Cheque"] != null)
                //{
                //    dtVouno = HttpContext.Current.Session["Grd_Cheque"] as DataTable;
                //var Shipping = dtVouno.AsEnumerable().Where(row => row["vouno"].Equals(Prefix));//row.Field<string>("vouno").StartsWith(Prefix.ToUpper())).ToList();
                //var Shipping = dtVouno.AsEnumerable().Where(row => row.Field<Int32>("vouno").Equals(Prefix));
                //dtVouno = Shipping.CopyToDataTable();
                //if (Shipping.Count
                //{
                //    dtVouno = Shipping.CopyToDataTable();
                //}
                //else
                //{
                //    dtVouno = new DataTable();
                //}
        //    }
        //}

        //protected void btn_search_Click(object sender, EventArgs e)
        //{
        //    DataTable obj_dtEmp = new DataTable();
        //    if (Session["dttt"] != null)
        //    {
        //        obj_dtEmp = (DataTable)Session["dttt"];
        //        Grd_Cheque.DataSource = obj_dtEmp;
        //        Grd_Cheque.DataBind();
        //    }

        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
        //}

        private void Fn_LodaBranchDivision()
        {
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            obj_dt = obj_da_Emp.GetDivision();
            ddl_company.DataSource = obj_dt;
            ddl_company.DataTextField = "divisionname";
            ddl_company.DataBind();
            DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            obj_dt = obj_da_Port.GetAllBranchNameforPortName();
            ddl_branch.Items.Add("ALL");
            ddl_branch.DataSource = obj_dt;
            ddl_branch.DataTextField = "portname";
            ddl_branch.DataBind();

        }
        private void Fn_Getdetail()
        {
            try
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());

                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                int intBranchID = HREmpObj.GetBranchId(int_divisionid, (ddl_branch.Text));
                DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                DataTable obj_dt = new DataTable();
                string transtype = Session["StrTranTypeCA"].ToString();
                if (ddl_branch.SelectedItem.Text == "ALL")
                {
                    if (rbt_CNOP.Checked == true)
                    {
                        obj_dt = obj_da_Cheque.GetChequeApprovalNewVou("PA", transtype, int_divisionid, 0);
                    }
                    else if (rbt_CN.Checked == true)
                    {
                        obj_dt = obj_da_Cheque.GetChequeApprovalNewVou("CN", transtype, int_divisionid, 0);
                    }
                    else if (rbt_CNAdmin.Checked == true)
                    {
                        obj_dt = obj_da_Cheque.GetChequeApprovalNewVou("AP", transtype, int_divisionid, 0);
                    }
                }
                else
                {
                    if (rbt_CNOP.Checked == true)
                    {
                        obj_dt = obj_da_Cheque.GetChequeApprovalNewVou("PA", transtype, int_divisionid, intBranchID);
                    }
                    else if (rbt_CN.Checked == true)
                    {
                        obj_dt = obj_da_Cheque.GetChequeApprovalNewVou("CN", transtype, int_divisionid, intBranchID);
                    }
                    else if (rbt_CNAdmin.Checked == true)
                    {
                        obj_dt = obj_da_Cheque.GetChequeApprovalNewVou("AP", transtype, int_divisionid, intBranchID);
                    }
                }
                DataColumn dc_branch = new DataColumn("branch", typeof(System.String));
                dc_branch.DefaultValue = string.Empty;
                obj_dt.Columns.Add(dc_branch);
                DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
               
                foreach (DataRow dr in obj_dt.Rows)
                {
                    dr["chqreqon"] = Utility.fn_ConvertDate(dr["chqreqon"].ToString());
                    dr["branch"] = obj_da_Branch.GetShortName(int.Parse(dr["bid"].ToString()));
                    dr["pmtRemarks"] = DBNull.Value.Equals(dr["pmtRemarks"]) ? "" : dr["pmtRemarks"];
                    dr["favourname"] = DBNull.Value.Equals(dr["favourname"]) ? "" : dr["favourname"];
                    dr["pmtmode"] = DBNull.Value.Equals(dr["pmtmode"]) ? "" : dr["pmtmode"];
                    if (dr["pmtmode"].ToString().Trim().Length > 0)
                    {
                        if (dr["pmtmode"].ToString() == "D")
                        {
                            dr["pmtmode"] = "DD";
                        }
                        else if (dr["pmtmode"].ToString() == "C")
                        {
                            dr["pmtmode"] = "Cheque";
                        }
                        else if (dr["pmtmode"].ToString() == "S")
                        {
                            dr["pmtmode"] = "Cash";
                        }
                        else if (dr["pmtmode"].ToString() == "N")
                        {
                            dr["pmtmode"] = "NEFT";
                        }
                        else if (dr["pmtmode"].ToString() == "R")
                        {
                            dr["pmtmode"] = "RTGS";
                        }
                        else if (dr["pmtmode"].ToString() == "A")
                        {
                            dr["pmtmode"] = "Adjust";
                        }
                        else if (dr["pmtmode"].ToString() == "T")
                        {
                            dr["pmtmode"] = "Not Over";
                        }
                    }
                }

                Grd_Cheque.DataSource = obj_dt;
                Grd_Cheque.DataBind();
                Session["Grd_Cheque"] = obj_dt;

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void rbt_CNOP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_ClearSession();
                if (rbt_CNOP.Checked == true)
                {
                    Grd_Cheque.HeaderRow.Cells[1].Text = "CNOps#";
                    Str_trantype = Session["StrTranTypeCA"].ToString();
                    Fn_Getdetail();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void rbt_CN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_ClearSession();
                if (rbt_CN.Checked == true)
                {
                    Grd_Cheque.HeaderRow.Cells[1].Text = "CN#";
                    Str_trantype = Session["StrTranTypeCA"].ToString();
                    Fn_Getdetail();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void rbt_CNAdmin_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_ClearSession();
                Str_trantype = Session["StrTranTypeCA"].ToString();

                if (rbt_CNAdmin.Checked == true)
                {
                    Grd_Cheque.HeaderRow.Cells[1].Text = "CNAdm#";                   
                    Fn_Getdetail();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void Grd_Cheque_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Grd_Cheque.PageIndex = e.NewPageIndex;
            ////Fn_Getdetail();
            //Grd_Cheque.DataSource = (DataTable)ViewState["Grd_Cheque"];
            //Grd_Cheque.DataBind();
            //if (Session["Row"] != null)
            //{
            //    List<string> Items = (List<string>)Session["Row"];
            //    foreach (GridViewRow row in Grd_Cheque.Rows)
            //    {
            //        var result = Items.Find(item => item == Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString());
            //        if (result != null)
            //        {
            //            CheckBox chk = (CheckBox)row.FindControl("Chk_Select");
            //            if (chk != null)
            //            {
            //                chk.Checked = true;
            //            }
            //        }
            //    }
            //}
        }

        protected void Grd_Payment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_Payment.PageIndex = e.NewPageIndex;

                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                DataTable obj_dt = new DataTable();
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (rbt_CNOP.Checked == true)
                {
                    obj_dt = obj_da_Cheque.GetPendingPayment4ChqApp("PA", Session["StrTranTypeCA"].ToString(), int_bid, int_divisionid, int_Empid);
                }
                else if (rbt_CN.Checked == true)
                {
                    obj_dt = obj_da_Cheque.GetPendingPayment4ChqApp("CN", Session["StrTranTypeCA"].ToString(), int_bid, int_divisionid, int_Empid);
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    obj_dt = obj_da_Cheque.GetPendingPayment4ChqApp("AP", Session["StrTranTypeCA"].ToString(), int_bid, int_divisionid, int_Empid);
                }
                if (hid_confirm.Value.ToString() == "Y")
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                        Str_RptName = "rptPendingCheReqApp.rpt";
                        Str_sf = "{TempPendingPayment4ChqReqandApp.empid}=" + int_Empid;
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('No Pending Payment Exists to Print');", true);
                        return;
                    }
                }
                else if (hid_confirm.Value.ToString() == "N")
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        pln_Grg.Show();
                        Grd_Payment.DataSource = obj_dt;
                        Grd_Payment.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('No Pending Payment Exists to View');", true);
                        return;
                    }
                }
                //if (Session["Row"] != null)
                //{
                //    List<string> Items = (List<string>)Session["Row"];
                //    foreach (GridViewRow row in Grd_Cheque.Rows)
                //    {
                //        var result = Items.Find(item => item == Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString());
                //        if (result != null)
                //        {
                //            CheckBox chk = (CheckBox)row.FindControl("Chk_Select");
                //            if (chk != null)
                //            {
                //                chk.Checked = true;
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_ClearSession()
        {
            try
            {
                //Session["Amount"] = null;
                //Session["TDSAmount"] = null;
                Session["Row"] = null;
                hid_Amount.Value = "";
                //hid_Row.Value = "";
                hid_TDSAmount.Value = "";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void Chkselect_Click(object sender, EventArgs e)
        {
            try
            {
                double PA_Amount = 0, TDS_Amount = 0;
                CheckBox Chk = sender as CheckBox;
                GridViewRow row = (GridViewRow)Chk.NamingContainer;
                //int index = row.RowIndex;
                //CheckBox chk = (CheckBox)Grd_Cheque.Rows[index].FindControl("Chk_Select");
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
                    if (hid_Amount.Value == "")
                    {
                        PA_Amount = double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[9].Text.ToString());
                        hid_Amount.Value = PA_Amount.ToString();
                        txt_PAamount.Text = string.Format("{0:0.00}", PA_Amount);

                    }
                    else
                    {
                        PA_Amount = double.Parse(hid_Amount.Value) + double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[9].Text.ToString());
                        //Session["Amount"] = PA_Amount;
                        hid_Amount.Value = PA_Amount.ToString();
                        txt_PAamount.Text = string.Format("{0:0.00}", PA_Amount);

                    }
                    if (hid_TDSAmount.Value == "")
                    {
                        TDS_Amount = double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[10].Text.ToString());
                        //Session["TDSAmount"] = TDS_Amount;
                        hid_TDSAmount.Value = TDS_Amount.ToString();
                        txt_TDSamount.Text = string.Format("{0:0.00}", TDS_Amount);
                    }
                    else
                    {
                        TDS_Amount = double.Parse(hid_TDSAmount.Value) + double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[10].Text.ToString()); ;
                        //Session["TDSAmount"] = TDS_Amount;
                        hid_TDSAmount.Value = TDS_Amount.ToString();
                        txt_TDSamount.Text = string.Format("{0:0.00}", TDS_Amount);
                    }
                }
                else
                {
                    PA_Amount = double.Parse(hid_Amount.Value) - double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[9].Text.ToString());
                    hid_Amount.Value = PA_Amount.ToString();
                    txt_PAamount.Text = string.Format("{0:0.00}", PA_Amount);

                    TDS_Amount = double.Parse(hid_TDSAmount.Value) - double.Parse(Grd_Cheque.Rows[row.RowIndex].Cells[10].Text.ToString());
                    //Session["TDSAmount"] = TDS_Amount;
                    hid_TDSAmount.Value = TDS_Amount.ToString();
                    txt_TDSamount.Text = string.Format("{0:0.00}", TDS_Amount);

                    var result = ItemText.Find(item => item == Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString());

                    if (result != null)
                    {
                        ItemText.Remove(result.ToString());
                    }
                }
                Session["Row"] = ItemText;
                Chk.Focus();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }
        protected void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_Trantype = "";
                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                Str_Trantype = Session["StrTranTypeCA"].ToString();
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (int_bid == 40 || int_bid == 82 || int_bid == 66)
                {
                    int_bid = 0;
                }
                if (rbt_CNOP.Checked == true)
                {

                    Str_RptName = "rptChqreqApp4PA.rpt";
                    
                    if (int_bid == 0)
                    {
                        Str_sf = "{ACPmtTDSDetails.voutype}=\"P\" and {ACPAHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid;
                    }
                    else
                    {
                        Str_sf = "{ACPmtTDSDetails.voutype}=\"P\" and {ACPAHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid + " and {ACPAHead.BranchID}=" + int_bid;
                    }
                    if (Str_Trantype != "CA")
                    {
                        Str_sf = Str_sf + " and not isnull({ACPAHead.chqreqby}) and isnull({ACPAHead.baappby})";
                    }
                    else
                    {                  
                        Str_sf = Str_sf + " and not isnull({ACPAHead.chqreqby}) and not isnull({ACPAHead.baappby}) and not isnull({ACPAHead.chqreqappby})"; 
                    }
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", Str_Script, true);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 3, Convert.ToInt32(Session["LoginBranchid"]), "CN-Ops/Trantype : " + Str_Trantype + "/AppPrint");
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (rbt_CN.Checked == true)
                {
                    Str_RptName = "rptChqreqApp4CN.rpt";
                    if (int_bid == 0)
                    {
                        Str_sf = "{ACPmtTDSDetails.voutype}=\"E\" and {ACCNHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid;
                    }
                    else
                    {
                        Str_sf = "{ACPmtTDSDetails.voutype}=\"E\" and {ACCNHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid + " and {ACCNHead.BranchID}=" + int_bid;
                    }
                    if (Str_Trantype != "CA")
                    {
                        Str_sf = Str_sf + " and not isnull({ACCNHead.chqreqby}) and isnull({ACCNHead.baappby})";
                    }
                    else
                    {
                        Str_sf = Str_sf + " and not isnull({ACCNHead.chqreqby}) and not isnull({ACCNHead.baappby}) and isnull({ACCNHead.chqreqappby})";
                    }
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", Str_Script, true);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 3, Convert.ToInt32(Session["LoginBranchid"]), "CN/Trantype : " + Str_Trantype + "/AppPrint");
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    Str_RptName = "rptPendingCheReqApp.rpt";
                    if (int_bid == 0)
                    {
                        Str_sf = "{ACPmtTDSDetails.voutype}=\"S\" and {ACAdminCNHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid;
                    }
                    else
                    {
                        Str_sf = "{ACPmtTDSDetails.voutype}=\"S\" and {ACAdminCNHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid + " and {ACAdminCNHead.BranchID}=" + int_bid;
                    }
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", Str_Script, true);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 3, Convert.ToInt32(Session["LoginBranchid"]), "CN-Admin/Trantype : " + Str_Trantype + "/AppPrint");
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void btn_approve_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtdate = DateTime.Parse(Utility.fn_ConvertDate(txt_approve.Text));
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_Trantype = "";
                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                Str_Trantype = Session["StrTranTypeCA"].ToString();
                int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (rbt_CNOP.Checked == true)
                {

                    Str_RptName = "rptChqreqApp4PA.rpt";
                    if (int_bid == 0)
                    {
                        //Str_sf = "{ACPmtTDSDetails.voutype}=\"P\" and {ACPAHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid;
                        Session["str_sfs"] = "{ACPmtTDSDetails.voutype}='P' and {ACPAHead.deleted}='N' and {MasterBranch.divisionid}=" + int_divisionid;
                    }
                    else
                    {
                        //tr_sf = "{ACPmtTDSDetails.voutype}=\"P\" and {ACPAHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid + " and {ACPAHead.BranchID}=" + int_bid;
                        Session["str_sfs"] = "{ACPmtTDSDetails.voutype}='P' and {ACPAHead.deleted}='N' and {MasterBranch.divisionid}=" + int_divisionid + " and {ACPAHead.BranchID}=" + int_bid;
                    }
                    if (Str_Trantype != "CA")
                    {
                        //Str_sf = Str_sf + " and  year({ACPAHead.baappon})=" + dtdate.Year + " and month({ACPAHead.baappon})=" + dtdate.Month + " and day({ACPAHead.baappon})=" + dtdate.Day;
                        Session["str_sfs"] = Session["str_sfs"].ToString() + " and  year({ACPAHead.baappon})=" + dtdate.Year + " and month({ACPAHead.baappon})=" + dtdate.Month + " and day({ACPAHead.baappon})=" + dtdate.Day;
                    }
                    else
                    {
                        //Str_sf = Str_sf + " and year({ACPAHead.chqreqappon})=" + dtdate.Year + " and month({ACPAHead.chqreqappon})=" + dtdate.Month + " and day({ACPAHead.chqreqappon})=" + dtdate.Day;
                        Session["str_sfs"] = Session["str_sfs"].ToString() + " and year({ACPAHead.chqreqappon})=" + dtdate.Year + " and month({ACPAHead.chqreqappon})=" + dtdate.Month + " and day({ACPAHead.chqreqappon})=" + dtdate.Day;
                    }
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", Str_Script, true);
                    //Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                    obj_da_Log.InsLogDetail(empid, 1065, 3, int_bid, "CN-Ops/Trantype : " + Str_Trantype + "/AppPrint");
                }
                else if (rbt_CN.Checked == true)
                {
                    Str_RptName = "rptChqreqApp4CN.rpt";
                    if (int_bid == 0)
                    {
                        //Str_sf = "{ACPmtTDSDetails.voutype}=\"E\" and {ACCNHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid;
                        Session["str_sfs"] = "{ACPmtTDSDetails.voutype}='E' and {ACCNHead.deleted}='N' and {MasterBranch.divisionid}=" + int_divisionid;
                    }
                    else
                    {
                        //Str_sf = "{ACPmtTDSDetails.voutype}=\"E\" and {ACCNHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid + " and {ACCNHead.BranchID}=" + int_bid;
                        Session["str_sfs"] = "{ACPmtTDSDetails.voutype}='E' and {ACCNHead.deleted}='N' and {MasterBranch.divisionid}=" + int_divisionid + " and {ACCNHead.BranchID}=" + int_bid;
                    }
                    if (Str_Trantype != "CA")
                    {
                        //Str_sf = Str_sf + " and  year({ACCNHead.baappon})=" + dtdate.Year + " and month({ACCNHead.baappon})=" + dtdate.Month + " and day({ACCNHead.baappon})=" + dtdate.Day;
                        Session["str_sfs"] = Session["str_sfs"].ToString() + " and  year({ACCNHead.baappon})=" + dtdate.Year + " and month({ACCNHead.baappon})=" + dtdate.Month + " and day({ACCNHead.baappon})=" + dtdate.Day;
                    }
                    else
                    {
                        //Str_sf = Str_sf + " and year({ACCNHead.chqreqappon})=" + dtdate.Year + " and month({ACCNHead.chqreqappon})=" + dtdate.Month + " and day({ACCNHead.chqreqappon})=" + dtdate.Day;
                        Session["str_sfs"] = Session["str_sfs"].ToString() + " and year({ACCNHead.chqreqappon})=" + dtdate.Year + " and month({ACCNHead.chqreqappon})=" + dtdate.Month + " and day({ACCNHead.chqreqappon})=" + dtdate.Day;
                    }
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", Str_Script, true);
                    //Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                    obj_da_Log.InsLogDetail(empid, 1065, 3, int_bid, "CN/Trantype : " + Str_Trantype + "/AppPrint");
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    Str_RptName = "rptPendingCheReqApp.rpt";
                    if (int_bid == 0)
                    {
                        //Str_sf = "{ACPmtTDSDetails.voutype}=\"S\" and {ACAdminCNHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid;
                        Session["str_sfs"] = "{ACPmtTDSDetails.voutype}='S' and {ACAdminCNHead.deleted}='N' and {MasterBranch.divisionid}=" + int_divisionid;
                    }
                    else
                    {
                        //Str_sf = "{ACPmtTDSDetails.voutype}=\"S\" and {ACAdminCNHead.deleted}=\"N\" and {MasterBranch.divisionid}=" + int_divisionid + " and {ACAdminCNHead.BranchID}=" + int_bid;
                        Session["str_sfs"] = "{ACPmtTDSDetails.voutype}='S' and {ACAdminCNHead.deleted}='N' and {MasterBranch.divisionid}=" + int_divisionid + " and {ACAdminCNHead.BranchID}=" + int_bid;
                    }
                    //Str_sf = Str_sf + " and year({ACAdminCNHead.chqreqappon})=" + dtdate.Year + " and month({ACAdminCNHead.chqreqappon})=" + dtdate.Month + " and day({ACAdminCNHead.chqreqappon})=" + dtdate.Day;
                    Session["str_sfs"] = Session["str_sfs"].ToString() + " and year({ACAdminCNHead.chqreqappon})=" + dtdate.Year + " and month({ACAdminCNHead.chqreqappon})=" + dtdate.Month + " and day({ACAdminCNHead.chqreqappon})=" + dtdate.Day;
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", Str_Script, true);
                    //Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                    obj_da_Log.InsLogDetail(empid, 1065, 3, int_bid, "CN-Admin/Trantype : " + Str_Trantype + "/AppPrint");
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void Lnk_Pending_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                DataTable obj_dt = new DataTable();
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (rbt_CNOP.Checked == true)
                {
                    obj_dt = obj_da_Cheque.GetPendingPayment4ChqApp("PA", Session["StrTranTypeCA"].ToString(), int_bid, int_divisionid, int_Empid);
                }
                else if (rbt_CN.Checked == true)
                {
                    obj_dt = obj_da_Cheque.GetPendingPayment4ChqApp("CN", Session["StrTranTypeCA"].ToString(), int_bid, int_divisionid, int_Empid);
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    obj_dt = obj_da_Cheque.GetPendingPayment4ChqApp("AP", Session["StrTranTypeCA"].ToString(), int_bid, int_divisionid, int_Empid);
                }
                if (hid_confirm.Value.ToString() == "Y")
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                        Str_RptName = "rptPendingCheReqApp.rpt";
                        Str_sf = "{TempPendingPayment4ChqReqandApp.empid}=" + int_Empid;
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('No Pending Payment Exists to Print');", true);
                        return;
                    }
                }
                else if (hid_confirm.Value.ToString() == "N")
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        pln_Grg.Show();
                        Grd_Payment.DataSource = obj_dt;
                        Grd_Payment.DataBind();

                        ViewState["obj_dt"] = obj_dt;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('No Pending Payment Exists to View');", true);
                        return;
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
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void Grd_Cheque_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str_Type = "", str_BL = "", Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_Container = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                int int_jobno = 0, int_vouyear = 0, int_invno = 0, int_Loginbid = 0, int_bid = 0;
                str_Type = Grd_Cheque.SelectedDataKey[3].ToString();
                str_BL = Grd_Cheque.SelectedDataKey[2].ToString();
                int_jobno = int.Parse(Grd_Cheque.SelectedDataKey[4].ToString());
                int_vouyear = int.Parse(Grd_Cheque.SelectedDataKey[0].ToString());
                int_invno = int.Parse(Grd_Cheque.SelectedDataKey[6].ToString());
                int_bid = int.Parse(Grd_Cheque.SelectedDataKey[1].ToString());
                int_Loginbid = int.Parse(Session["LoginBranchid"].ToString());
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                obj_dt = obj_da_Invoice.CheckHblno(str_BL, str_Type, int_Loginbid);
                if (rbt_CNOP.Checked == true)
                {
                    if (obj_dt.Rows.Count > 0)
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
                        Str_sf = "{PAHead.trantype}=\"" + str_Type + "\" and {PAHead.pano}=" + int_invno + " and {PAHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
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
                        Str_sf = "{PAHead.trantype}=\"" + str_Type + "\" and {PAHead.pano}=" + int_invno + " and {PAHead.branchid}=" + int_Loginbid + " and {PAHead.vouyear}=" + int_vouyear;
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                }
                else if (rbt_CN.Checked == true)
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        if (str_BL.Trim().Length > 0)
                        {
                            obj_dttemp = obj_da_Invoice.GetHBLContainerDtls(str_BL, str_Type, int_Loginbid);
                            if (obj_dttemp.Rows.Count > 0)
                            {
                                var obj_Container = obj_dttemp.AsEnumerable().Select(row => row.Field<string>("containerno").ToString());
                                Str_Container = string.Join(",", obj_Container);
                            }
                        }
                        obj_dttemp = obj_da_Invoice.ShowIPHead(int_invno, "AC", "CNHead", int_vouyear, int_Loginbid);
                        int int_custid = 0;
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            int_custid = int.Parse(obj_dttemp.Rows[0].ItemArray[4].ToString());
                        }
                        if (str_Type == "FE")
                        {
                            Str_RptName = "FECN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                            Str_sp = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FICN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "container=" + Str_Container;
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AECN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AICN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "AICN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                    else
                    {
                        if (str_Type == "FE")
                        {
                            DataAccess.ForwardingExports.JobInfo obj_da_FEjob = new DataAccess.ForwardingExports.JobInfo();
                            obj_dttemp = obj_da_FEjob.GetContainerDetails(int_jobno, int_jobno.ToString(), int_Loginbid, int.Parse(Session["LoginDivisionId"].ToString()));
                        }
                        else if (str_Type == "FI")
                        {
                            DataAccess.ForwardingImports.JobInfo obj_da_FIjob = new DataAccess.ForwardingImports.JobInfo();
                            obj_dttemp = obj_da_FIjob.BindJobDetails(int_jobno, int_jobno.ToString(), int_Loginbid, int.Parse(Session["LoginDivisionId"].ToString()));
                        }

                        if (obj_dttemp.Rows.Count > 0)
                        {
                            var obj_Container = obj_dttemp.AsEnumerable().Select(row => row.Field<string>("containerno").ToString());
                            Str_Container = string.Join(",", obj_Container);
                        }
                        obj_dttemp = obj_da_Invoice.ShowIPHead(int_invno, "AC", "CNHead", int_vouyear, int_Loginbid);
                        int int_custid = 0;
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            int_custid = int.Parse(obj_dttemp.Rows[0].ItemArray[4].ToString());
                        }
                        if (str_Type == "FE")
                        {
                            Str_RptName = "FEMCN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (str_Type == "FI")
                        {
                            Str_RptName = "FIMCN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "container=" + Str_Container;
                        }
                        else if (str_Type == "AE")
                        {
                            Str_RptName = "AEMCN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "AI")
                        {
                            Str_RptName = "AIMCN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        else if (str_Type == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Str_sf = "{CNHead.trantype}=\"" + str_Type + "\" and {CNHead.cnno}=" + int_invno + " and {CNHead.branchid}=" + int_Loginbid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + int_Loginbid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_sp = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                        Session["str_sfs"] = Str_sf;
                        Session["str_sp"] = Str_sp;
                    }
                }
                else if (rbt_CNAdmin.Checked == true)
                {
                    Str_RptName = "AdmCredit.rpt";
                    Str_sf = "{AdmCNHead.cnno}=" + int_invno + " and {AdmCNHead.vouyear}=" + int_vouyear + " and {AdmCNHead.branchid}=" + int_bid + " and {AdmCNHead.deleted}=\"N\"";
                    Str_sp = "Lcurr=INR";
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Grd_Cheque, typeof(GridView), "ChequeRequest", Str_Script, true);
                }
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
                popup_favour.Show();
                LinkButton Lnk = sender as LinkButton;
                GridViewRow row = (GridViewRow)Lnk.NamingContainer;
                txt_favour_cheque.Text = Lnk.Text;
                txt_remark_cheque.Text = Grd_Cheque.DataKeys[row.RowIndex].Values[7].ToString();
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
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                string str_trantype = Session["StrTranTypeCA"].ToString();
                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }
                Boolean Check = false;
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                foreach (GridViewRow row in Grd_Cheque.Rows)
                {
                    //string str_trantype = "";
                    CheckBox Chk = (CheckBox)Grd_Cheque.Rows[row.RowIndex].FindControl("Chk_Select");
                    if (Chk.Checked == true)
                    {

                        int int_Vouno = int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[6].ToString());
                        int int_Vyear = int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString());
                        int int_Branchid = int.Parse(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString());
                        int empid = employeeobj.GetNEmpid(Grd_Cheque.DataKeys[row.RowIndex].Values[5].ToString());
                        str_trantype = Grd_Cheque.DataKeys[row.RowIndex].Values[3].ToString();
                        if (int_Empid == empid)
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequestApproval", "alertify.alert('You Have No Rights To Approve The Payment Request Given By You For Voucher #" + int_Vouno + "  ');", true);
                            continue;
                        }
                        if (Session["StrTranTypeCA"].ToString() != "CA")
                        {
                            Check = true;
                            if (rbt_CNOP.Checked == true)
                            {
                                if (Grd_Cheque.Rows[row.RowIndex].Cells[11].Text.ToString() == "Cash")
                                {
                                    obj_da_Cheque.UpdChequeApproval4BrHeadNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "PA");
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN-Ops/Trantype : " + str_trantype);
                                    //  logobj.InsLogDetail(Login.logempid, 1065, 2, Login.branchid, "Vouno : " & grd.Rows(i).Cells("grdvouno").Value & "/CN-Ops/Trantype : " & grd.Rows(i).Cells("grdtrantype").Value)
                                }
                                else
                                {
                                    obj_dt = obj_da_Cheque.GetVendorPanno4Cust(int_Vouno, int_Vyear, "PA", int_Branchid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        if (obj_dt.Rows[0]["panno"].ToString().Trim().Length < 10)
                                        {
                                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequestApproval", "alertify.alert('PAN number not available for this Vendor \"" + obj_dt.Rows[0]["customername"].ToString() + "\" . PAN number is mandatory to make the Payment');", true);
                                            Check = false;
                                            continue;
                                        }
                                        else
                                        {
                                            obj_da_Cheque.UpdChequeApproval4BrHeadNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "PA");
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN-Ops/Trantype : " + str_trantype);
                                        }
                                    }
                                    else
                                    {

                                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequestApproval", "alertify.alert('PAN number not available for this Vendor. PAN number is mandatory to make the Payment.');", true);
                                        Check = false;
                                        continue;
                                    }
                                }
                            }
                            else if (rbt_CN.Checked == true)
                            {
                                if (Grd_Cheque.Rows[row.RowIndex].Cells[11].Text.ToString() == "Cash")
                                {
                                    obj_da_Cheque.UpdChequeApproval4BrHeadNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "CN");
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN/Trantype : " + str_trantype);

                                }
                                else
                                {
                                    obj_dt = obj_da_Cheque.GetVendorPanno4Cust(int_Vouno, int_Vyear, "CN", int_Branchid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        if (obj_dt.Rows[0]["panno"].ToString().Trim().Length < 10)
                                        {
                                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequestApproval", "alertify.alert('PAN number not available for this Vendor \"" + obj_dt.Rows[0]["customername"].ToString() + "\" . PAN number is mandatory to make the Payment');", true);
                                            Check = false;
                                            continue;
                                        }
                                        else
                                        {
                                            obj_da_Cheque.UpdChequeApproval4BrHeadNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "CN");
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN/Trantype : " + str_trantype);
                                        }
                                    }
                                    else
                                    {

                                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequestApproval", "alertify.alert('PAN number not available for this Vendor. PAN number is mandatory to make the Payment.');", true);
                                        Check = false;
                                        continue;
                                    }
                                }
                            }
                            else if (rbt_CNAdmin.Checked == true)
                            {
                                if (Grd_Cheque.Rows[row.RowIndex].Cells[11].Text.ToString() == "Cash")
                                {
                                    obj_da_Cheque.UpdChequeApproval4BrHeadNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "AP");
                                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN-Admin/Trantype : " + str_trantype);
                                }
                                else
                                {
                                    obj_dt = obj_da_Cheque.GetVendorPanno4Cust(int_Vouno, int_Vyear, "AP", int_Branchid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        if (obj_dt.Rows[0]["panno"].ToString().Trim().Length < 10)
                                        {
                                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequestApproval", "alertify.alert('PAN number not available for this Vendor \"" + obj_dt.Rows[0]["customername"].ToString() + "\" . PAN number is mandatory to make the Payment');", true);
                                            Check = false;
                                            continue;
                                        }
                                        else
                                        {
                                            obj_da_Cheque.UpdChequeApproval4BrHeadNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "AP");
                                            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN-Admin/Trantype : " + str_trantype);
                                        }
                                    }
                                    else
                                    {

                                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequestApproval", "alertify.alert('PAN number not available for this Vendor. PAN number is mandatory to make the Payment.');", true);
                                        Check = false;
                                        continue;
                                    }
                                }
                            }
                        }
                        else if (Session["StrTranTypeCA"].ToString() == "CA")
                        {
                            Check = true;
                            if (rbt_CNOP.Checked == true)
                            {
                                obj_da_Cheque.UpdChequeApproval4CoNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "PA");
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN-Admin/Trantype : " + str_trantype);
                            }
                            else if (rbt_CN.Checked == true)
                            {
                                obj_da_Cheque.UpdChequeApproval4CoNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "CN");
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN-Admin/Trantype : " + str_trantype);
                            }
                            else if (rbt_CNAdmin.Checked == true)
                            {
                                obj_da_Cheque.UpdChequeApproval4CoNewVou(int_Vouno, int_Vyear, str_trantype, int_Branchid, int_Empid, "AP");
                                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1065, 2, Convert.ToInt32(Session["LoginBranchid"]), "Vouno : " + int_Vouno + "/CN-Admin/Trantype : " + str_trantype);
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
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "ChequeRequest", "alertify.alert('Detail Update');", true);
                    Fn_Getdetail();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void lnkjob_Click(object sender, EventArgs e)
        {
            try
            {
                if (hidpageload.Value != "page_load")
                {
                    LinkButton Lnk = sender as LinkButton;
                    GridViewRow row = (GridViewRow)Lnk.NamingContainer;
                    iframecost.Attributes["src"] = "../FAForms/JobSee.aspx?Jobno=" + Lnk.Text + "&TranType=" + Grd_Cheque.DataKeys[row.RowIndex].Values[3].ToString() + "&BranchId=" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString();
                    if (rbt_CNOP.Checked == true)
                    {
                        Session["credit"] = "creditop";
                    }
                    else if (rbt_CN.Checked == true)
                    {
                        Session["credit"] = "credit";
                    }
                    else if (rbt_CNAdmin.Checked == true)
                    {
                        Session["credit"] = "creditCNAdmin";
                    }
                    Session["Job"] = Lnk.Text;
                    Session["tran"] = Grd_Cheque.DataKeys[row.RowIndex].Values[3].ToString();
                    Session["Bid"] = Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString();
                    popup_cheque.Show();
                }
                else
                {
                    if (Session["credit"] != null)
                    {
                        Server.ClearError();
                        Response.Redirect("../FAForms/JobSee.aspx?Jobno=" + Session["Job"].ToString() + "&TranType=" + Session["tran"].ToString(), false);
                        popup_cheque.Hide();
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        LinkButton Lnk = sender as LinkButton;
                        GridViewRow row = (GridViewRow)Lnk.NamingContainer;
                        iframecost.Attributes["src"] = "../FAForms/JobSee.aspx?Jobno=" + Lnk.Text + "&TranType=" + Grd_Cheque.DataKeys[row.RowIndex].Values[3].ToString() + "&BranchId=" + Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString();
                        if (rbt_CNOP.Checked == true)
                        {
                            Session["credit"] = "creditop";
                        }
                        else if (rbt_CN.Checked == true)
                        {
                            Session["credit"] = "credit";
                        }
                        else if (rbt_CNAdmin.Checked == true)
                        {
                            Session["credit"] = "creditCNAdmin";
                        }
                        Session["Job"] = Lnk.Text;
                        Session["tran"] = Grd_Cheque.DataKeys[row.RowIndex].Values[3].ToString();
                        Session["Bid"] = Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString();
                        popup_cheque.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void Grd_Cheque_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {                   
                    Label lblCustomer2 = (Label)e.Row.FindControl("custname");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[6].Attributes.Add("title", tooltip2);

                    Label lblCustomer1 = (Label)e.Row.FindControl("approvedby");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[8].Attributes.Add("title", tooltip1);
                    
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        if (e.Row.Cells[i].Text == "&nbsp;")
                        {
                            e.Row.Cells[i].Text = "";
                        }
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }

                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");                  
                    e.Row.Attributes["style"] = "cursor:pointer";
                }               
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Payment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Label lblCustomer = (Label)e.Row.FindControl("chqreqon");
                    //string tooltip = lblCustomer.Text;
                    //e.Row.Cells[5].Attributes.Add("title", tooltip);

                    Label lblCustomer1 = (Label)e.Row.FindControl("chqreqon");
                    string tooltip1 = lblCustomer1.Text;
                    e.Row.Cells[6].Attributes.Add("title", tooltip1);

                    Label lblCustomer2 = (Label)e.Row.FindControl("brappon");
                    string tooltip2 = lblCustomer2.Text;
                    e.Row.Cells[7].Attributes.Add("title", tooltip2);

                    Label lblCustomer3 = (Label)e.Row.FindControl("coappon");
                    string tooltip3 = lblCustomer3.Text;
                    e.Row.Cells[8].Attributes.Add("title", tooltip3);

                    Label lblCustomer4 = (Label)e.Row.FindControl("shipper");
                    string tooltip4 = lblCustomer3.Text;
                    e.Row.Cells[5].Attributes.Add("title", tooltip3);
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        if (e.Row.Cells[i].Text == "&nbsp;")
                        {
                            e.Row.Cells[i].Text = "";
                        }
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }



                    //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Cheque, "Select$" + e.Row.RowIndex);
                    //e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int intBranchID;
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                if (ddl_branch.Text == "ALL" || ddl_branch.SelectedIndex == -1)
                {
                    intBranchID = 0;
                    Fn_Getdetail();
                }
                else
                {
                    NPortID = portObj.GetNPortid(ddl_branch.SelectedItem.ToString());
                    intBranchID = HREmpObj.GetBranchId(int_divisionid, (ddl_branch.Text));
                    Fn_Getdetail();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_decline_Click(object sender, EventArgs e)
        {
            try
            {
                int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                string str_trantype = Session["StrTranTypeCA"].ToString();
                int count = 0, chq = 0, vouyear, bid, Vouno;

                if (rbt_CNOP.Checked == false && rbt_CN.Checked == false && rbt_CNAdmin.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Please Select Any One Voucher');", true);
                    return;
                }

                if (Grd_Cheque.Rows.Count > 0)
                {
                    foreach (GridViewRow row in Grd_Cheque.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_Select");
                        if (Chk.Checked == true)
                        {
                            count = 1;
                            Vouno = Convert.ToInt32(Grd_Cheque.DataKeys[row.RowIndex].Values[6].ToString());
                            vouyear = Convert.ToInt32(Grd_Cheque.DataKeys[row.RowIndex].Values[0].ToString());
                            bid = Convert.ToInt32(Grd_Cheque.DataKeys[row.RowIndex].Values[1].ToString());
                            //str_trantype = Grd_Cheque.DataKeys[row.RowIndex].Values[3].ToString();
                            if (rbt_CNOP.Checked == true)
                            {
                                chq = obj_da_Cheque.ChecqueRequestDecline(Vouno, vouyear, str_trantype, bid, "PA");
                            }
                            else if (rbt_CN.Checked == true)
                            {
                                chq = obj_da_Cheque.ChecqueRequestDecline(Vouno, vouyear, str_trantype, bid, "CN");
                            }
                            else if (rbt_CNAdmin.Checked == true)
                            {
                                chq = obj_da_Cheque.ChecqueRequestDecline(Vouno, vouyear, str_trantype, bid, "AP");
                            }
                        }
                    }
                }

                if (count > 0)
                {
                    if (chq == 1)
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Cheque Request Cannot Be Declined After Approval');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Cheque Request Declined Successfully');", true);
                    }
                }
                if (count == 0)
                {
                    if (rbt_CNOP.Checked == true)
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Please Select Atleast a PA # to Approve');", true);
                    }
                    else if (rbt_CN.Checked == true)
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Please Select Atleast a CN # to Approve');", true);
                    }
                    else if (rbt_CNAdmin.Checked == true)
                    {
                        ScriptManager.RegisterStartupScript(Lnk_Pending, typeof(LinkButton), "ChequeRequestApproval", "alertify.alert('Please Select Atleast a CN - Admin # to Approve');", true);
                    }
                }
                else
                {
                    Fn_Getdetail();
                    txt_PAamount.Text = "";
                    txt_TDSamount.Text = "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        protected void ddl_Sorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsort = new DataTable();

                if (rbt_CNOP.Checked == true || rbt_CN.Checked == true || rbt_CNAdmin.Checked == true)
                {
                    if (Session["Grd_Cheque"] != null)
                    {
                        dtsort = Session["Grd_Cheque"] as DataTable;
                    }
                    DataView dtview = new DataView(dtsort);

                    if (ddl_Sorting.SelectedValue == "Vouno")
                    {
                        dtview.Sort = "vouno DESC";
                    }
                    else if (ddl_Sorting.SelectedValue == "VouDate")
                    {
                        dtview.Sort = "chqreqon DESC";
                    }
                    else if (ddl_Sorting.SelectedValue == "Vendor")
                    {
                        dtview.Sort = "custname DESC";
                    }
                    else if (ddl_Sorting.SelectedValue == "PAAmount")
                    {
                        dtview.Sort = "paamt DESC";
                    }

                    DataTable Sort_dt = new DataTable();
                    Sort_dt = dtview.ToTable();

                    Grd_Cheque.DataSource = Sort_dt;
                    Grd_Cheque.DataBind();
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

        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        protected void btn_export_Click(object sender, EventArgs e)
        {
            DataTable dt_check = new DataTable("Excel");
            if(Grd_Payment.Rows.Count>0)
            {

                if (ViewState["obj_dt"] != null)
                {
                    Gridtemp.Visible = true;
                    Gridtemp.DataSource = ViewState["obj_dt"] as DataTable;
                    Gridtemp.DataBind();
                    foreach (TableCell cell in Gridtemp.HeaderRow.Cells)
                    {
                        dt_check.Columns.Add(cell.Text);
                    }
                    foreach (GridViewRow row in Gridtemp.Rows)
                    {
                        dt_check.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i == 2)
                            {
                                LinkButton link_custname = row.Cells[i].FindControl("link_custname") as LinkButton;
                                row.Cells[i].Text = link_custname.Text;
                            }
                            if (i == 5)
                            {
                                Label lbl_shipper = row.Cells[i].FindControl("lbl_shipper") as Label;
                                row.Cells[i].Text = lbl_shipper.Text;
                            }
                            if (i == 6)
                            {
                                Label lbl_chqreqon = row.Cells[i].FindControl("lbl_chqreqon") as Label;
                                row.Cells[i].Text = lbl_chqreqon.Text;
                            }
                            if (i == 7)
                            {
                                Label lbl_brappon = row.Cells[i].FindControl("lbl_brappon") as Label;
                                row.Cells[i].Text = lbl_brappon.Text;
                            }
                            if (i == 8)
                            {
                                Label lbl_coappon = row.Cells[i].FindControl("lbl_coappon") as Label;
                                row.Cells[i].Text = lbl_coappon.Text;
                            }
                            dt_check.Rows[dt_check.Rows.Count - 1][i] = row.Cells[i].Text.Replace("&amp;", "&").Replace("&nbsp;", "");
                        }
                    }

                    //dt_check.Columns.Remove("bid");
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Chequerequest.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Gridtemp.Visible = false;
                        Response.End();
                    }
                }
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                rbt_CNOP.Checked = false;
                rbt_CNAdmin.Checked = false;
                rbt_CN.Checked = false;
                Grd_Cheque.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Cheque.DataBind();
                txt_approve.Text = "";
                txt_TDSamount.Text = "";
                txt_PAamount.Text = "";

                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";



            }
            else
            {
               // Response.Redirect("../Home/Branch_home.aspx");
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

       

        protected void btn_export1_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                if (Grd_Cheque.Rows.Count > 0)
                {
                    Grd_Cheque.Columns[12].Visible = false;
                    Response.Clear();
                    Response.AddHeader("content-disposition", "attachment;filename=ChequeRequestApproval.xls");
                    Response.Charset = "";
                    //Response.ContentType = "application/vnd.ms-excel";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    int cnt = Grd_Cheque.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>Cheque Request Approval</B></font></td></tr>");
                    SB.Append("</table>");
                    Grd_Cheque.GridLines = GridLines.Both;
                    Grd_Cheque.HeaderStyle.Font.Bold = true;
                    Grd_Cheque.RenderControl(HtmlTextWriter);
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1065, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1065, "", "", "", Session["StrTranType"].ToString());
            }

            

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void Grd_Cheque_PreRender(object sender, EventArgs e)
        {
            if (Grd_Cheque.Rows.Count > 0)
            {
                Grd_Cheque.UseAccessibleHeader = true;
                Grd_Cheque.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_Payment_PreRender(object sender, EventArgs e)
        {
            if (Grd_Payment.Rows.Count > 0)
            {
                Grd_Payment.UseAccessibleHeader = true;
                Grd_Payment.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Gridtemp_PreRender(object sender, EventArgs e)
        {
            if (Gridtemp.Rows.Count > 0)
            {
                Gridtemp.UseAccessibleHeader = true;
                Gridtemp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridViewlog_PreRender(object sender, EventArgs e)
        {
            if (GridViewlog.Rows.Count > 0)
            {
                GridViewlog.UseAccessibleHeader = true;
                GridViewlog.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        
    }
}