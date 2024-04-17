using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForm
{
    public partial class FAReceipt : System.Web.UI.Page
    {
        int PBranch_ID;
        int rid;
        int LogIn_BrID;
        string rptype;
        string mode;
        string temp_formname;
        string gblvname;
        string vname;
        int voutypeid;
        DateTime voudate;
        int bankid;
        DateTime chqdate;
        double totcramt;
        double totdramt;
        bool LView_Flag = false;
        bool flag;

        public static string Str_Type = "";
        public static char Mode;
        public static int int_bid = 0, int_Rid = 0, int_Pid = 0;
        public static Boolean Flag = false;
        DataTable dttable = new DataTable();
        DataAccess.Accounts.Recipts Bank_Obj = new DataAccess.Accounts.Recipts();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            try
            {
                if (IsPostBack != true)
                {
                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lbl_header.Text = Request.QueryString["FormName"].ToString();
                        temp_formname = lbl_header.Text.ToString();
                    }

                    hf_LogBr_ID.Value = Session["LoginBranchid"].ToString();

                    // From Query Form

                    if (Request.QueryString.ToString().Contains("QueryVoucherName"))
                    {
                        txt_vchr.Text = Request.QueryString["QueryVoucherNo"].ToString();
                        lbl_header.Text = Request.QueryString["QueryVoucherName"].ToString();

                        if (lbl_header.Text == "Bank Receipt")
                        {
                            Str_Type = "R";
                            Mode = 'B';
                        }
                        else if (lbl_header.Text == "BRG")
                        {
                            Str_Type = "R";
                            Mode = 'M';
                        }
                        else if (lbl_header.Text == "Receipt - Petty Cash")
                        {
                            Str_Type = "R";
                            Mode = 'P';
                        }
                        else if (lbl_header.Text == "Bank Deposit JV" || lbl_header.Text == "BDJV")
                        {
                            Str_Type = "BD";
                            Mode = 'B';
                        }
                        else if (lbl_header.Text == "Bank Payment JV" || lbl_header.Text == "BPJV")
                        {
                            Str_Type = "BP";
                            Mode = 'B';
                        }
                        else if (lbl_header.Text == "Cash Receipt")
                        {
                            Str_Type = "R";
                            Mode = 'C';
                        }
                        else if (lbl_header.Text == "Bank Payment")
                        {
                            Str_Type = "P";
                            Mode = 'B';
                        }
                        else if (lbl_header.Text == "Cash Payment")
                        {
                            Str_Type = "P";
                            Mode = 'C';
                        }
                        else if (lbl_header.Text == "Remittance-Receipt")
                        {
                            Str_Type = "RR";
                            Mode = 'B';
                        }
                        else if (lbl_header.Text == "Remittance-Payment")
                        {
                            Str_Type = "RP";
                            Mode = 'B';
                        }
                        txt_vchr_TextChanged(sender, e);
                        return;
                    }

                    if (lbl_header.Text == "BDJV")
                    {
                        lbl_header.Text = "Bank Deposit JV";
                    }
                    else if (lbl_header.Text == "BPJV")
                    {
                        lbl_header.Text = "Bank Payment JV";
                    }

                    if (temp_formname == "Bank Receipt")
                    {
                        lbl_to.Text = "From";
                    }
                    else if (temp_formname == "Receipt - Petty Cash")
                    {
                        lbl_to.Text = "From";
                    }
                    else if (temp_formname == "Bank Deposit JV" || temp_formname == "BDJV")
                    {
                        lbl_to.Text = "From";
                    }
                    else if (temp_formname == "Bank Payment JV" || temp_formname == "BPJV")
                    {

                    }
                    else if (temp_formname == "Cash Receipt")
                    {
                        lbl_to.Text = "From";
                    }

                    if (Request.QueryString.ToString().Contains("Vno"))
                    {
                        if (Convert.ToInt32(Request.QueryString["PBranch_ID"].ToString()) == 0)
                        {
                            hf_LogBr_ID.Value = Session["LoginBranchid"].ToString();
                        }
                        else
                        {
                            hf_LogBr_ID.Value = Request.QueryString["PBranch_ID"].ToString();
                        }

                        hf_gblvname.Value = Request.QueryString["FormName"].ToString();
                        txt_vchr.Text = Request.QueryString["Vno"].ToString();

                        if (Request.QueryString.ToString().Contains("flag"))
                        {
                            hf_flag.Value = (Request.QueryString["flag"].ToString());
                            hf_vid.Value = (Request.QueryString["vid"].ToString());
                            hidfdate.Value = (Request.QueryString["fdate"].ToString());
                            hidtdate.Value = (Request.QueryString["tdate"].ToString());
                            hidvoutype.Value = (Request.QueryString["type"].ToString());
                        }
                        filldetails();
                    }
                }
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        private void GetFormTypeMode()
        {
            temp_formname = lbl_header.Text.ToString();
            if (temp_formname == "Bank Receipt")
            {
                rptype = "R";
                mode = "B";

            }
            else if (temp_formname == "Receipt - Petty Cash")
            {
                rptype = "R";
                mode = "P";

            }
            else if (temp_formname == "Bank Deposit JV" || temp_formname == "BDJV")
            {
                rptype = "BD";
                mode = "B";

            }
            else if (temp_formname == "Bank Payment JV" || temp_formname == "BPJV")
            {
                rptype = "BP";
                mode = "B";

            }
            else if (temp_formname == "Cash Receipt")
            {
                rptype = "R";
                mode = "C";


            }
            else if (temp_formname == "Bank Payment")
            {
                rptype = "P";
                mode = "B";

            }
            else if (temp_formname == "Cash Payment")
            {
                rptype = "P";
                mode = "C";

            }
            else if (temp_formname == "Remittance-Receipt")
            {
                rptype = "RR";
                mode = "B";

            }
            else if (temp_formname == "Remittance-Payment")
            {
                rptype = "RP";
                mode = "B";

            }
        }
        public void txtClear()
        {
            DataAccess.LogDetails obj_Log = new DataAccess.LogDetails();
            txt_narration.Text = "";
            txt_date.Text = "";
            txt_to.Text = "";
            txt_chqdd.Text = "";
            txt_bank.Text = "";
            txt_branch.Text = "";
            txt_agnstref.Text = "";
            hf_chqdate.Value = Utility.fn_ConvertDate(obj_Log.GetDate().ToShortDateString());
            grd_receipt.DataSource = null;
            grd_receipt.DataBind();
            txt_chqdate.Text = "";
            txt_clrddate.Text = "";

            ViewState["dt_info"] = null;
            ViewState["dt_invc"] = null;
            ViewState["dt_Custchrg"] = null;
            ViewState["dtCT"] = null;
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                txtClear();
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                txt_vchr.Text = "";
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

            if (hf_flag.Value != "")
            {
                flag = Convert.ToBoolean(hf_flag.Value.ToString());
                if (flag == true)
                {
                    Boolean fg;
                    fg = true;
                    Response.Redirect("../FAForms/Statistics.aspx?flagvou=" + fg + "&vid=" + hf_vid.Value + "&fdate=" + hidfdate.Value + "&tdate=" + hidtdate.Value + "&vtype=" + hidvoutype.Value);
                    this.Response.End();
                }
            }

            if (Request.QueryString.ToString().Contains("Str_Name"))
            {
                if (Request.QueryString["Str_Name"] == "DayBook_FAReceipt")
                {
                    string fromDate = Request.QueryString["FromDate"];
                    string toDate = Request.QueryString["ToDate"];
                    string RefNo = Request.QueryString["RefNo"];
                    string Amount = Request.QueryString["Amount"];
                    string ddl_VouType = Request.QueryString["ddl_VouType"];
                    string ddl_AmtType = Request.QueryString["ddl_AmtType"];
                    string FrmName = "DayBook";
                    Response.Redirect("../FAForms/DayBook.aspx?Str_Name=" + FrmName + "&From=" + fromDate + "&To=" + toDate + "&VoucherNo=" + RefNo + "&Amount=" + Amount + "&ddl_VouType=" + ddl_VouType + "&ddl_AmtType=" + ddl_AmtType, false);
                    this.Response.End();
                }
            }
        }

        public void filldetails()
        {
            try
            {
                GetFormTypeMode();
                gblvname = hf_gblvname.Value.ToString();
                temp_formname = lbl_header.Text.ToString();

                DataAccess.FAVoucher obj_FA = new DataAccess.FAVoucher();
                DataAccess.HR.Employee obj_HREmp = new DataAccess.HR.Employee();
                DataAccess.Accounts.Recipts obj_rec = new DataAccess.Accounts.Recipts();
                DataAccess.Accounts.Payment obj_payment = new DataAccess.Accounts.Payment();

                DataTable dt_FA = new DataTable();
                DataTable dt_info = new DataTable();
                DataTable dt_invc = new DataTable();
                DataTable dt_Custchrg = new DataTable();
                DataTable dtCT = new DataTable();
                int logcorid, Vou_Id;

                PBranch_ID = Convert.ToInt32(hf_LogBr_ID.Value.ToString());
                voutypeid = obj_FA.Selvoutypeid(gblvname, Session["FADbname"].ToString());
                Vou_Id = obj_FA.GetVouId(Convert.ToInt32(txt_vchr.Text), PBranch_ID, voutypeid, Session["FADbname"].ToString());   //Convert.ToInt32(Session["LoginBranchid"].ToString())
                hid_vou.Value = Vou_Id.ToString();
                LogIn_BrID = PBranch_ID;

                if (temp_formname == "Bank Payment" && PBranch_ID == 0)
                {
                    dt_FA = obj_FA.SelFAVoucher4Corp(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToInt32(Session["LoginDivisionId"]), voutypeid, Convert.ToInt32(Session["LogYear"]), Session["FADbname"].ToString());
                }
                else if (temp_formname == "Bank Payment" && PBranch_ID != 0)
                {
                    logcorid = obj_HREmp.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), "CORPORATE");
                    dt_FA = obj_FA.SelFAVoucher4BP(Convert.ToInt32(txt_vchr.Text), logcorid, Convert.ToInt32(Session["LoginDivisionId"]), voutypeid, Convert.ToInt32(Session["LogYear"]), Session["FADbname"].ToString(), LogIn_BrID);
                }
                else if (PBranch_ID != 0 && temp_formname == "BDJV")
                {
                    logcorid = obj_HREmp.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), "CORPORATE");
                    dt_FA = obj_FA.SelFAVoucher4BP(Convert.ToInt32(txt_vchr.Text), logcorid, Convert.ToInt32(Session["LoginDivisionId"]), voutypeid, Convert.ToInt32(Session["LogYear"]), Session["FADbname"].ToString(), LogIn_BrID);
                }
                else if (PBranch_ID == 0 || LView_Flag == false)
                {
                    dt_FA = obj_FA.SelFAVoucher(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToInt32(Session["LoginDivisionId"]), voutypeid, Convert.ToInt32(Session["LogYear"]), Session["FADbname"].ToString());
                }
                else if (temp_formname == "BPJV")
                {
                    dt_FA = obj_FA.SelFAVoucher(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToInt32(Session["LoginDivisionId"]), voutypeid, Convert.ToInt32(Session["LogYear"]), Session["FADbname"].ToString());
                }
                else
                {
                    logcorid = obj_HREmp.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), "CORPORATE");
                    dt_FA = obj_FA.SelFAVoucher4BP(Convert.ToInt32(txt_vchr.Text), logcorid, Convert.ToInt32(Session["LoginDivisionId"]), voutypeid, Convert.ToInt32(Session["LogYear"]), Session["FADbname"].ToString(), LogIn_BrID);
                }

                if (dt_FA.Rows.Count > 0)
                {
                    if (grd_receipt.Rows.Count > 0)
                    {
                        grd_receipt.DataSource = null;
                        grd_receipt.DataBind();
                    }

                    DataRow dr_temp = dt_FA.NewRow();
                    dr_temp["ledgername"] = "Total";
                    dr_temp["ledgeramount"] = dt_FA.Compute("sum(ledgeramount)", "ledgertype='Dr'");
                    dr_temp["ledgeramount"] = dt_FA.Compute("sum(ledgeramount)", "ledgertype='Cr'");
                    dt_FA.Rows.Add(dr_temp);
                    grd_receipt.DataSource = dt_FA;
                    grd_receipt.DataBind();
                    if (dt_FA.Rows[0]["Narration"].ToString() != "")
                    {
                        txt_agnstref.Text = dt_FA.Rows[0]["Narration"].ToString();
                    }
                    else
                    {
                        txt_agnstref.Text = "";
                    }

                    grd_receipt.Rows[grd_receipt.Rows.Count - 1].Font.Bold = true;
                    grd_receipt.Rows[grd_receipt.Rows.Count - 1].HorizontalAlign = HorizontalAlign.Right;
                    grd_receipt.Rows[grd_receipt.Rows.Count - 1].ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(grd_receipt, typeof(GridView), "Valid", "alertify.alert('Please Enter the valid Voucher #');", true);
                    txtClear();
                    txt_vchr.Focus();
                    return;
                }

                if (rptype == "R")
                {
                    rid = obj_rec.GetRecrid(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    hid_rid.Value = rid.ToString();
                    dt_info = obj_rec.GetRecptHead(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    dt_invc = obj_rec.GetRAInvoiceToShow(rid, Convert.ToChar(rptype));
                    dt_Custchrg = obj_rec.GetRecptCust(rid);
                    dtCT = obj_rec.GetRecptChrg(rid);

                    ViewState["dt_info"] = dt_info;
                    ViewState["dt_invc"] = dt_invc;
                    ViewState["dt_Custchrg"] = dt_Custchrg;
                    ViewState["dtCT"] = dtCT;
                }
                else if (rptype == "P")
                {
                    rid = obj_payment.GetPaymentid(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    hid_rid.Value = rid.ToString();
                    dt_info = obj_payment.GetPaymentHead(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    dt_invc = obj_rec.GetRAInvoiceToShow(rid, Convert.ToChar(rptype));
                    dt_Custchrg = obj_payment.GetPaymentCust(rid);
                    dtCT = obj_payment.GetPaymentChrg(rid);

                    ViewState["dt_info"] = dt_info;
                    ViewState["dt_invc"] = dt_invc;
                    ViewState["dt_Custchrg"] = dt_Custchrg;
                    ViewState["dtCT"] = dtCT;
                }
                else if (rptype == "BD")
                {
                    rid = obj_rec.GetRecridBD(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    hid_rid.Value = rid.ToString();
                    dt_info = obj_rec.GetRecptHeadBD(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));

                    ViewState["dt_info"] = dt_info;
                }
                else if (rptype == "BP")
                {
                    rid = obj_payment.GetPaymentid(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    hid_rid.Value = rid.ToString();
                    dt_info = obj_payment.GetPaymentHead(Convert.ToInt32(txt_vchr.Text), LogIn_BrID, Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    //dt_invc = obj_rec.GetRAInvoiceToShow(rid, Convert.ToChar(rptype));
                    dt_Custchrg = obj_payment.GetPaymentCust(rid);
                    dtCT = obj_payment.GetPaymentChrg(rid);

                    ViewState["dt_info"] = dt_info;
                    ViewState["dt_Custchrg"] = dt_Custchrg;
                    ViewState["dtCT"] = dtCT;
                }
                else if (rptype == "RR")
                {
                    int log_corid;
                    log_corid = obj_HREmp.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), "CORPORATE");
                    rid = obj_rec.GetOSRecrid(Convert.ToInt32(txt_vchr.Text), Convert.ToInt32(hf_LogBr_ID.Value), Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    hid_rid.Value = rid.ToString();
                    dt_info = obj_rec.GetOSRecptHead(Convert.ToInt32(txt_vchr.Text), Convert.ToInt32(hf_LogBr_ID.Value), Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));

                    ViewState["dt_info"] = dt_info;
                }
                else if (rptype == "RP")
                {
                    int log_corid;
                    log_corid = obj_HREmp.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), "CORPORATE");
                    rid = obj_payment.GetOSPaymentid(Convert.ToInt32(txt_vchr.Text), Convert.ToInt32(hf_LogBr_ID.Value), Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));
                    hid_rid.Value = rid.ToString();
                    dt_info = obj_payment.GetOSPaymentHead(Convert.ToInt32(txt_vchr.Text), Convert.ToInt32(hf_LogBr_ID.Value), Convert.ToChar(mode), Convert.ToInt32(Session["LogYear"]));

                    ViewState["dt_info"] = dt_info;
                }

                if (dt_info.Rows.Count > 0)
                {
                    voudate = Convert.ToDateTime(dt_info.Rows[0][2].ToString());
                    txt_date.Text = dt_info.Rows[0]["fdate"].ToString() + "/" + voudate.DayOfWeek;

                    if (mode == "B")
                    {
                        txt_chqdd.Text = dt_info.Rows[0][10].ToString();
                        bankid = Convert.ToInt32(dt_info.Rows[0][8].ToString());
                        txt_bank.Text = obj_rec.GetBankName(bankid);
                        txt_branch.Text = dt_info.Rows[0][9].ToString();
                        chqdate = Convert.ToDateTime(dt_info.Rows[0][11].ToString());
                        txt_chqdate.Text = string.Format("{0:dd/MM/yyyy}", chqdate);

                        if (dt_info.Rows[0]["clearedon"].ToString() != null && dt_info.Rows[0]["clearedon"].ToString().Trim().Length > 0)
                        {
                            chqdate = Convert.ToDateTime(dt_info.Rows[0]["clearedon"].ToString());
                            txt_clrddate.Text = string.Format("{0:dd/MM/yyyy}", chqdate);
                        }
                        else
                        {
                            txt_clrddate.Text = "";
                        }
                    }
                    txt_to.Text = dt_info.Rows[0][6].ToString();
                    txt_narration.Text = dt_info.Rows[0][12].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grd_receipt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grd_receipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (grd_receipt.DataKeys[e.Row.RowIndex].Values["ledgertype"].ToString() == "Cr")
                {
                    e.Row.Cells[1].Text = "";
                    e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                }
                else if (grd_receipt.DataKeys[e.Row.RowIndex].Values["ledgertype"].ToString() == "Dr")
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                    e.Row.Cells[2].Text = "";
                }
            }
        }

        protected void txt_vchr_TextChanged(object sender, EventArgs e)
        {
            if (PBranch_ID == 0)
            {
                LogIn_BrID = Convert.ToInt32(Session["LoginBranchid"]);
            }
            else
            {
                LogIn_BrID = PBranch_ID;
            }

            if (txt_vchr.Text != "")
            {
                filldetails();
            }
        }

        protected void btn_Previous_Click(object sender, EventArgs e)
        {
            if (txt_vchr.Text != "")
            {
                txt_vchr.Text = (Convert.ToInt32(txt_vchr.Text) - 1).ToString();
                filldetails();
            }
        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_vchr.Text != "")
                {
                    txt_vchr.Text = (Convert.ToInt32(txt_vchr.Text) + 1).ToString();
                    filldetails();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        //protected void btn_view_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
        //        Session["str_sfs"] = ""; Session["str_sp"] = "";

        //        DataAccess.FAVoucher Obj_FAVoucher = new DataAccess.FAVoucher();
        //        DataAccess.LogDetails Obj_LogDet = new DataAccess.LogDetails();
        //        Obj_FAVoucher.SelFAAllVoucher(Convert.ToInt32(hid_vou.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());
        //        GetFormTypeMode();


        //        if (Request.QueryString.ToString().Contains("Vno"))
        //        {
        //            if (Convert.ToInt32(Request.QueryString["PBranch_ID"].ToString()) == 0)
        //            {
        //                hf_LogBr_ID.Value = Session["LoginBranchid"].ToString();
        //            }
        //            else
        //            {
        //                hf_LogBr_ID.Value = Request.QueryString["PBranch_ID"].ToString();
        //            }
        //        }
        //        if (rptype == "R")
        //        {


        //            if (NewaspxRpt.Value == "Y")
        //            {
        //                if (txt_vchr.Text != "")
        //                {
        //                    string str_Script = "";
        //                    if (txt_vchr.Text.Trim() != "")
        //                    {
        //                        str_Script = "window.open('../Reportasp/ReceiptFARpt.aspx?ReceiptId=" + hid_rid.Value + "&vouyear=" + Session["LogYear"].ToString() + "&Mode=" + mode + "','','');";
        //                    }
        //                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Receipt", str_Script, true);
        //                    Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + "/" + txt_vchr.Text);
        //                }
        //            }
        //            else
        //            {
        //                if (txt_vchr.Text != "")
        //                {
        //                    if (mode == "C")
        //                    {
        //                        Str_RptName = "ReceiptCash.rpt";
        //                        Session["str_sfs"] = "{ReceiptHead.receiptid}=" + hid_rid.Value + " and {ReceiptAgainstInvoice.rptype}='R'";
        //                    }
        //                    else if (mode == "P")
        //                    {
        //                        Str_RptName = "ReceiptPettyCash.rpt";
        //                        Session["str_sfs"] = "{ReceiptHead.receiptid}=" + hid_rid.Value;
        //                    }
        //                    else
        //                    {
        //                        Str_RptName = "ReceiptBank.rpt";
        //                        Session["str_sfs"] = "{ReceiptHead.receiptid}=" + hid_rid.Value + " and {ReceiptAgainstInvoice.rptype}='R'";
        //                    }

        //                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
        //                    Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + "/" + txt_vchr.Text);
        //                }
        //                else
        //                {
        //                    if (mode != "")
        //                    {
        //                        if (mode == "C")
        //                        {
        //                            Str_RptName = "ReceiptCashReg.rpt";
        //                            Session["str_sfs"] = "{ReceiptHead.mode}='C' and {ReceiptHead.branchid}=" + hf_LogBr_ID.Value + " and {ReceiptHead.vouyear}=" + Session["LogYear"].ToString();
        //                            Session["str_sp"] = "title=Cash Receipts~branch=";
        //                        }
        //                        else
        //                        {
        //                            Str_RptName = "ReceiptBankReg.rpt";
        //                            Session["str_sfs"] = "{ReceiptHead.mode}='B' and {ReceiptHead.branchid}=" + hf_LogBr_ID.Value + " and {ReceiptHead.vouyear}=" + Session["LogYear"].ToString();
        //                            Session["str_sp"] = "title=Bank Receipts~branch=";
        //                        }

        //                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
        //                        Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
        //                    }
        //                    else
        //                    {
        //                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Mode')", true);
        //                    }
        //                }

        //            }

        //        }
        //        else if (rptype == "P")
        //        {
        //            if (txt_vchr.Text != "")
        //            {
        //                DataTable dt_info = ViewState["dt_info"] as DataTable;
        //                DataTable dt_invc = ViewState["dt_invc"] as DataTable;
        //                DataTable dt_Custchrg = ViewState["dt_Custchrg"] as DataTable;
        //                DataTable dtCT = ViewState["dtCT"] as DataTable;

        //                if (dt_invc.Rows.Count == 0)
        //                {
        //                    if (dtCT.Rows.Count > 0)
        //                    {
        //                        Str_RptName = "PaymentCashCash.rpt";
        //                        Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value;
        //                    }
        //                    else if (dt_Custchrg.Rows.Count > 0)
        //                    {
        //                        Str_RptName = "PaymentCashCashcustomer.rpt";
        //                        Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value;
        //                    }
        //                    else
        //                    {
        //                        Str_RptName = "PaymentCash.rpt";
        //                        Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value + " and {ReceiptPayment.rptype}='P'";
        //                    }
        //                }
        //                else
        //                {
        //                    Str_RptName = "PaymentCash.rpt";
        //                    Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value + " and {ReceiptPayment.rptype}='P'";
        //                }
        //                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
        //            }
        //            else
        //            {
        //                if (mode != "")
        //                {
        //                    if (mode == "C")
        //                    {
        //                        Str_RptName = "PaymentCashReg.rpt";
        //                        Session["str_sfs"] = "{PaymentHead.mode}='C' and {PaymentHead.branchid}=" + hf_LogBr_ID.Value + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString();
        //                        Session["str_sp"] = "title=Cash Payment";
        //                    }
        //                    else
        //                    {
        //                        Str_RptName = "PaymentBankReg.rpt";
        //                        Session["str_sfs"] = "{PaymentHead.mode}='B' and {PaymentHead.branchid}=" + hf_LogBr_ID.Value + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString();
        //                        Session["str_sp"] = "title=Bank Payment";
        //                    }

        //                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
        //                    Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Mode')", true);
        //                }
        //            }
        //        }
        //        else if (rptype == "BD")
        //        {
        //            Str_RptName = "rptJV.rpt";
        //            Session["str_sfs"] = " {Tempvoucher.vouid}=" + hid_vou.Value + "And {Tempvoucher.empid} = " + Session["LoginEmpId"].ToString();
        //            Session["str_sp"] = "Title=Bank Deposit JV~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2) + "~appby=" + "";

        //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
        //            Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
        //        }
        //        else if (rptype == "BP")
        //        {
                    
        //            dttable = Bank_Obj.GetRAInvoiceToShow(Convert.ToInt32(hid_rid.Value), 'P');
        //            if (dttable.Rows.Count == 0)
        //            {
        //                Str_RptName = "PaymentBank42and3Charge.rpt";
        //            }
        //            else
        //            {
        //                Str_RptName = "PaymentBank.rpt";
        //            }

        //            Session["LoginBranchid"] = hf_LogBr_ID.Value;
        //            //Str_RptName = "PaymentBank.rpt";
                    
        //            //Str_RptName = "PaymentBank4dirpay.rpt";
        //            Session["str_sfs"] = "{PaymentHead.mode}='B' and {PaymentHead.branchid}=" + hf_LogBr_ID.Value + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString() + "and {PaymentHead.paymentid}=" + hid_rid.Value; 
        //            //Str_RptName = "rptJV.rpt";
        //            //Session["str_sfs"] = " {Tempvoucher.vouid}=" + hid_vou.Value + "And {Tempvoucher.empid} = " + Session["LoginEmpId"].ToString();
        //            //Session["str_sp"] = "Title=Bank Payment JV~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2) + "~appby=" + "";

        //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
        //            Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
        //        }

        //        else if (rptype == "RP")
        //        {
        //            if (txt_vchr.Text != "")
        //            {
        //                DataTable dt_info = ViewState["dt_info"] as DataTable;
        //                int rid = Convert.ToInt32(dt_info.Rows[0][0].ToString());
        //                Str_RptName = "PaymentBank4OS.rpt";
        //                Session["str_sfs"] = "{ACOSPaymentHead.paymentid}=" + rid + " and {ACOSReceiptPayment.rptype}='P'";
        //                //Session["str_sp"] = "Title=Remittance Payment";
        //                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

        //                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
        //                Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
        //            }
        //        }
        //        else if (rptype == "RR")
        //        {
        //            if (txt_vchr.Text != "")
        //            {
        //                DataTable dt_info = ViewState["dt_info"] as DataTable;
        //                int rid = Convert.ToInt32(dt_info.Rows[0][0].ToString());
        //                Str_RptName = "ReceiptBank4OS.rpt";
        //                Session["str_sfs"] = "{ACOSReceiptHead.receiptid}=" + rid + " and {ACOSReceiptPayment.rptype}='R'";
        //                //Session["str_sp"] = "Title=Remittance Payment";
        //                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

        //                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
        //                Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
        //    }
        //}

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                string txt_recpdate = HttpContext.Current.Session["Vouyear"].ToString();
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                Session["str_sfs"] = ""; Session["str_sp"] = "";

                DataAccess.FAVoucher Obj_FAVoucher = new DataAccess.FAVoucher();
                DataAccess.LogDetails Obj_LogDet = new DataAccess.LogDetails();
                Obj_FAVoucher.SelFAAllVoucher(Convert.ToInt32(hid_vou.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());
                GetFormTypeMode();


                if (Request.QueryString.ToString().Contains("Vno"))
                {
                    if (Convert.ToInt32(Request.QueryString["PBranch_ID"].ToString()) == 0)
                    {
                        hf_LogBr_ID.Value = Session["LoginBranchid"].ToString();
                    }
                    else
                    {
                        hf_LogBr_ID.Value = Request.QueryString["PBranch_ID"].ToString();
                    }
                }
                if (rptype == "R")
                {


                    if (NewaspxRpt.Value == "Y")
                    {
                        if (txt_vchr.Text != "")
                        {
                            string str_Script = "";
                            if (txt_vchr.Text.Trim() != "")
                            {
                                str_Script = "window.open('../Reportasp/ReceiptFARpt.aspx?ReceiptId=" + hid_rid.Value + "&vouyear=" + Session["LogYear"].ToString() + "&Mode=" + mode + "','','');";
                            }
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Receipt", str_Script, true);
                            Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + "/" + txt_vchr.Text);
                        }
                    }
                    else
                    {
                        if (txt_vchr.Text != "")
                        {
                            if (mode == "C")
                            {
                                Str_RptName = "ReceiptCash.rpt";
                                Session["str_sfs"] = "{ReceiptHead.receiptid}=" + hid_rid.Value + " and {ReceiptAgainstInvoice.rptype}='R'";
                            }
                            else if (mode == "P")
                            {
                                Str_RptName = "ReceiptPettyCash.rpt";
                                Session["str_sfs"] = "{ReceiptHead.receiptid}=" + hid_rid.Value;
                            }
                            else
                            {
                                Str_RptName = "ReceiptBank.rpt";
                                Session["str_sfs"] = "{ReceiptHead.receiptid}=" + hid_rid.Value + " and {ReceiptAgainstInvoice.rptype}='R'";
                            }

                            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                            Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + "/" + txt_vchr.Text);
                        }
                        else
                        {
                            if (mode != "")
                            {
                                if (mode == "C")
                                {
                                    Str_RptName = "ReceiptCashReg.rpt";
                                    Session["str_sfs"] = "{ReceiptHead.mode}='C' and {ReceiptHead.branchid}=" + hf_LogBr_ID.Value + " and {ReceiptHead.vouyear}=" + Session["LogYear"].ToString();
                                    Session["str_sp"] = "title=Cash Receipts~branch=";
                                }
                                else
                                {
                                    Str_RptName = "ReceiptBankReg.rpt";
                                    Session["str_sfs"] = "{ReceiptHead.mode}='B' and {ReceiptHead.branchid}=" + hf_LogBr_ID.Value + " and {ReceiptHead.vouyear}=" + Session["LogYear"].ToString();
                                    Session["str_sp"] = "title=Bank Receipts~branch=";
                                }

                                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                                Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Mode')", true);
                            }
                        }

                    }

                }
                //else if (rptype == "P")
                //{
                //    if (txt_vchr.Text != "")
                //    {
                //        DataTable dt_info = ViewState["dt_info"] as DataTable;
                //        DataTable dt_invc = ViewState["dt_invc"] as DataTable;
                //        DataTable dt_Custchrg = ViewState["dt_Custchrg"] as DataTable;
                //        DataTable dtCT = ViewState["dtCT"] as DataTable;

                //        if (dt_invc.Rows.Count == 0)
                //        {
                //            if (dtCT.Rows.Count > 0)
                //            {
                //                Str_RptName = "PaymentCashCash.rpt";
                //                Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value;
                //            }
                //            else if (dt_Custchrg.Rows.Count > 0)
                //            {
                //                Str_RptName = "PaymentCashCashcustomer.rpt";
                //                Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value;
                //            }
                //            else
                //            {
                //                Str_RptName = "PaymentCash.rpt";
                //                Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value + " and {ReceiptPayment.rptype}='P'";
                //            }
                //        }
                //        else
                //        {
                //            Str_RptName = "PaymentCash.rpt";
                //            Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value + " and {ReceiptPayment.rptype}='P'";
                //        }
                //        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                //    }
                //    else
                //    {
                //        if (mode != "")
                //        {
                //            if (mode == "C")
                //            {
                //                Str_RptName = "PaymentCashReg.rpt";
                //                Session["str_sfs"] = "{PaymentHead.mode}='C' and {PaymentHead.branchid}=" + hf_LogBr_ID.Value + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString();
                //                Session["str_sp"] = "title=Cash Payment";
                //            }
                //            else
                //            {
                //                Str_RptName = "PaymentBankReg.rpt";
                //                Session["str_sfs"] = "{PaymentHead.mode}='B' and {PaymentHead.branchid}=" + hf_LogBr_ID.Value + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString();
                //                Session["str_sp"] = "title=Bank Payment";
                //            }

                //            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                //            Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
                //        }
                //        else
                //        {
                //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Mode')", true);
                //        }
                //    }
                //}

//keerthi

                else if (rptype == "P")
                {

                    if (txt_vchr.Text != "")
                    {


                        DataTable dt_info = ViewState["dt_info"] as DataTable;
                        DataTable dt_invc = ViewState["dt_invc"] as DataTable;
                        DataTable dt_Custchrg = ViewState["dt_Custchrg"] as DataTable;
                        DataTable dtCT = ViewState["dtCT"] as DataTable;

                        if (dt_invc.Rows.Count == 0)
                        {
                            if (dtCT.Rows.Count > 0)
                            {
                                Str_RptName = "PaymentCashCash.rpt";
                                Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value;
                            }
                            else if (dt_Custchrg.Rows.Count > 0)
                            {
                                Str_RptName = "PaymentCashCashcustomer.rpt";
                                Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value;
                            }
                            else
                            {
                                Str_RptName = "PaymentCash.rpt";
                                Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value + " and {ReceiptPayment.rptype}='P'";
                            }
                        }
                        else
                        {
                            Str_RptName = "PaymentCash.rpt";
                            Session["str_sfs"] = "{PaymentHead.paymentid}=" + hid_rid.Value + " and {ReceiptPayment.rptype}='P'";
                        }
                        // Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        // Str_Script = "window.open('../Reportasp/PaymentFARpt.aspx?ReceiptId=" + rid + "&vouyear=" + txt_recpdate + "&Mode=" + mode + "&Type=" + Session["rptype"].ToString() + "','','');";
                        Str_Script = "window.open('../Reportasp/PaymentFARpt.aspx?ReceiptId=" + hid_rid.Value + "&vouyear=" + Session["LogYear"].ToString() + "&Mode=" + mode + "&Type=" + 'P' + "','','');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    }
                    else
                    {
                        if (mode != "")
                        {
                            if (mode == "C")
                            {
                                Str_RptName = "PaymentCashReg.rpt";
                                Session["str_sfs"] = "{PaymentHead.mode}='C' and {PaymentHead.branchid}=" + hf_LogBr_ID.Value + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString();
                                Session["str_sp"] = "title=Cash Payment";
                            }
                            else
                            {
                                Str_RptName = "PaymentBankReg.rpt";
                                Session["str_sfs"] = "{PaymentHead.mode}='B' and {PaymentHead.branchid}=" + hf_LogBr_ID.Value + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString();
                                Session["str_sp"] = "title=Bank Payment";
                            }
                            // Str_Script = "window.open('../Reportasp/PaymentFARpt.aspx?ReceiptId=" + rid + "&vouyear=" + txt_recpdate + "&Mode=" + mode + "&Type=" + Session["rptype"].ToString() + "','','');";
                            // Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                            Str_Script = "window.open('../Reportasp/PaymentFARpt.aspx?ReceiptId=" + hid_rid.Value + "&vouyear=" + Session["LogYear"].ToString() + "&Mode=" + mode + "&Type=" + 'P' + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                            Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Mode')", true);
                        }
                    }
                }

                else if (rptype == "BD")
                {
                    Str_RptName = "rptJV.rpt";
                    Session["str_sfs"] = " {Tempvoucher.vouid}=" + hid_vou.Value + "And {Tempvoucher.empid} = " + Session["LoginEmpId"].ToString();
                    Session["str_sp"] = "Title=Bank Deposit JV~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2) + "~appby=" + "";

                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
                }
                else if (rptype == "BP")
                {

                    dttable = Bank_Obj.GetRAInvoiceToShow(Convert.ToInt32(hid_rid.Value), 'P');
                    if (dttable.Rows.Count == 0)
                    {
                        Str_RptName = "PaymentBank42and3Charge.rpt";
                    }
                    else
                    {
                        Str_RptName = "PaymentBank.rpt";
                    }

                    Session["LoginBranchid"] = hf_LogBr_ID.Value;
                    //Str_RptName = "PaymentBank.rpt";

                    //Str_RptName = "PaymentBank4dirpay.rpt";
                    Session["str_sfs"] = "{PaymentHead.mode}='B' and {PaymentHead.branchid}=" + hf_LogBr_ID.Value + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString() + "and {PaymentHead.paymentid}=" + hid_rid.Value;
                    //Str_RptName = "rptJV.rpt";
                    //Session["str_sfs"] = " {Tempvoucher.vouid}=" + hid_vou.Value + "And {Tempvoucher.empid} = " + Session["LoginEmpId"].ToString();
                    //Session["str_sp"] = "Title=Bank Payment JV~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2) + "~appby=" + "";

                    // Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    Str_Script = "window.open('../Reportasp/PaymentFARpt.aspx?ReceiptId=" + hid_rid.Value + "&vouyear=" + Session["LogYear"].ToString() + "&Mode=" + mode + "&Type=" + 'P' + "','','');";


                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                    //Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
                }

                else if (rptype == "RP")
                {
                    if (txt_vchr.Text != "")
                    {
                        DataTable dt_info = ViewState["dt_info"] as DataTable;
                        int rid = Convert.ToInt32(dt_info.Rows[0][0].ToString());
                        Str_RptName = "PaymentBank4OS.rpt";
                        Session["str_sfs"] = "{ACOSPaymentHead.paymentid}=" + rid + " and {ACOSReceiptPayment.rptype}='P'";
                        //Session["str_sp"] = "Title=Remittance Payment";
                        //Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        Str_Script = "window.open('../Reportasp/RemittanceReceiptFA.aspx?ReceiptId=" + hid_rid.Value + "&vouyear=" + Session["LogYear"].ToString() + "&Mode=" + mode + "&Type=" + 'P' + "','','');";

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                        Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
                    }
                }
                else if (rptype == "RR")
                {
                    if (txt_vchr.Text != "")
                    {
                        DataTable dt_info = ViewState["dt_info"] as DataTable;
                        int rid = Convert.ToInt32(dt_info.Rows[0][0].ToString());
                        Str_RptName = "ReceiptBank4OS.rpt";
                        Session["str_sfs"] = "{ACOSReceiptHead.receiptid}=" + rid + " and {ACOSReceiptPayment.rptype}='R'";
                        //Session["str_sp"] = "Title=Remittance Payment";
                        //Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        Str_Script = "window.open('../Reportasp/RemittanceReceiptFA.aspx?ReceiptId=" + hid_rid.Value + "&vouyear=" + Session["LogYear"].ToString() + "&Mode=" + mode + "&Type=" + 'R' + "','','');";

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);
                        Obj_LogDet.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, Convert.ToInt32(hf_LogBr_ID.Value), mode + " / All ReceiptNo.");
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
}

          
       