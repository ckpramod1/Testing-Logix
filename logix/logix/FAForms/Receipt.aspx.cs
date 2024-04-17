using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForm
{
    public partial class Receipt : System.Web.UI.Page
    {
        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();

        public static string Str_Type = "";
        public static char Mode;
        public static int int_bid = 0, int_Rid = 0, int_Pid = 0;
        public static Boolean Flag = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                if (Request.QueryString.ToString().Contains("QueryVoucherName"))
                {
                    txt_Voucher.Text = Request.QueryString["QueryVoucherNo"].ToString();
                    lbl_Header.Text = Request.QueryString["QueryVoucherName"].ToString();

                    if (lbl_Header.Text == "Bank Receipt")
                    {
                        Str_Type = "R";
                        Mode = 'B';
                        lbl_To.Text = "From";
                    }
                    else if (lbl_Header.Text == "BRG")
                    {
                        Str_Type = "R";
                        Mode = 'M';
                        lbl_To.Text = "From";
                    }
                    else if (lbl_Header.Text == "Receipt - Petty Cash")
                    {
                        Str_Type = "R";
                        Mode = 'P';
                        lbl_To.Text = "From";
                    }
                    else if (lbl_Header.Text == "Bank Deposit JV" || lbl_Header.Text == "BDJV")
                    {
                        Str_Type = "BD";
                        Mode = 'B';
                        lbl_To.Text = "From";
                    }
                    else if (lbl_Header.Text == "Bank Payment JV" || lbl_Header.Text == "BPJV")
                    {
                        Str_Type = "BP";
                        Mode = 'B';
                        lbl_To.Text = "To";
                    }
                    else if (lbl_Header.Text == "Cash Receipt")
                    {
                        Str_Type = "R";
                        Mode = 'C';
                        lbl_To.Text = "From";
                    }
                    else if (lbl_Header.Text == "Bank Payment")
                    {
                        Str_Type = "P";
                        Mode = 'B';
                        lbl_To.Text = "To";
                    }
                    else if (lbl_Header.Text == "Cash Payment")
                    {
                        Str_Type = "P";
                        Mode = 'C';
                        lbl_To.Text = "To";
                    }
                    else if (lbl_Header.Text == "Remittance-Receipt")
                    {
                        Str_Type = "RR";
                        Mode = 'B';
                        lbl_To.Text = "From";
                        lbl_Cheque.Text = "Bank Ref #";
                    }
                    else if (lbl_Header.Text == "Remittance-Payment")
                    {
                        Str_Type = "RP";
                        Mode = 'B';
                        lbl_To.Text = "To";
                        lbl_Cheque.Text = "Bank Ref #";
                    }

                    txt_Voucher_TextChanged(sender, e);
                }
            }
        }

        protected void txt_Voucher_TextChanged(object sender, EventArgs e)
        {

            if (txt_Voucher.Text.TrimEnd().Length > 0)
            {
                if (int_Pid == 0)
                {
                    int_bid = int.Parse(Session["LoginBranchid"].ToString());
                }
                else
                {
                    int_bid = int_Pid;
                }
                Fn_GetDetail();
            }
        }

        private void Fn_GetDetail()
        {
            int int_divisionid, int_Corporateid, int_Year, int_voutypeid, Vou_Id;
            string Str_DBName = Session["FADbname"].ToString();
            int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            int_Year = int.Parse(Session["LogYear"].ToString());
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            int_Corporateid = obj_da_Employee.GetBranchId(int_divisionid, "CORPORATE");
            int_voutypeid = obj_da_FAVoucher.Selvoutypeid(lbl_Header.Text, Str_DBName);
            DataTable obj_dt = new DataTable();

            if (lbl_Header.Text == "Bank Payment" && int_Pid == 0)
            {
                obj_dt = obj_da_FAVoucher.SelFAVoucher4Corp(int.Parse(txt_Voucher.Text), int_bid, int_divisionid, int_voutypeid, int_Year, Str_DBName);
            }
            else if (lbl_Header.Text == "Bank Payment" && int_Pid != 0)
            {
                obj_dt = obj_da_FAVoucher.SelFAVoucher4BP(int.Parse(txt_Voucher.Text), int_Corporateid, int_divisionid, int_voutypeid, int_Year, Str_DBName, int_bid);
            }
            else if (lbl_Header.Text == "BDJV" && int_Pid != 0)
            {
                obj_dt = obj_da_FAVoucher.SelFAVoucher4BP(int.Parse(txt_Voucher.Text), int_Corporateid, int_divisionid, int_voutypeid, int_Year, Str_DBName, int_bid);
            }
            else if (Flag == false && int_Pid == 0)
            {
                obj_dt = obj_da_FAVoucher.SelFAVoucher(int.Parse(txt_Voucher.Text), int_bid, int_divisionid, int_voutypeid, int_Year, Str_DBName);
            }
            else if (lbl_Header.Text == "BDJV")
            {
                obj_dt = obj_da_FAVoucher.SelFAVoucher(int.Parse(txt_Voucher.Text), int_Corporateid, int_divisionid, int_voutypeid, int_Year, Str_DBName);
            }
            else
            {
                obj_dt = obj_da_FAVoucher.SelFAVoucher4BP(int.Parse(txt_Voucher.Text), int_Corporateid, int_divisionid, int_voutypeid, int_Year, Str_DBName, int_bid);
            }
            if (obj_dt.Rows.Count > 0)
            {
                txt_AgainstReference.Text = obj_dt.Rows[0]["narration"].ToString();

                DataRow dr = obj_dt.NewRow();
                dr["ledgername"] = "Total";
                dr["ledgeramount"] = obj_dt.Compute("sum(ledgeramount)", "ledgertype='Dr'");
                dr["ledgeramount"] = obj_dt.Compute("sum(ledgeramount)", "ledgertype='Cr'");
                obj_dt.Rows.Add(dr);
                Grd_Receipt.DataSource = obj_dt;
                Grd_Receipt.DataBind();

                Vou_Id = obj_da_FAVoucher.GetVouId(Convert.ToInt32(txt_Voucher.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), int_voutypeid, Session["FADbname"].ToString());
                hid_vou.Value = Vou_Id.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "FA", "alertify.alert('Please Enter the valid Voucher #');", true);
                Fn_Clear();
                return;
            }
            DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();

            obj_dt = new DataTable();
            if (Str_Type == "R")
            {
                int_Rid = obj_da_Receipt.GetRecrid(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_dt = obj_da_Receipt.GetRecptHead(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_DtInvoice = obj_da_Receipt.GetRAInvoiceToShow(int_Rid, Mode);
                obj_DtCharge = obj_da_Receipt.GetRecptCust(int_Rid);
                obj_DtCT = obj_da_Receipt.GetRecptChrg(int_Rid);
            }
            else if (Str_Type == "P")
            {
                int_Rid = obj_da_Payment.GetPaymentid(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_dt = obj_da_Payment.GetPaymentHead(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_DtInvoice = obj_da_Receipt.GetRAInvoiceToShow(int_Rid, Mode);
                obj_DtCharge = obj_da_Payment.GetPaymentCust(int_Rid);
                obj_DtCT = obj_da_Payment.GetPaymentChrg(int_Rid);
            }
            else if (Str_Type == "BD")
            {
                int_Rid = obj_da_Receipt.GetRecridBD(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_dt = obj_da_Receipt.GetRecptHeadBD(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
            }
            else if (Str_Type == "BP")
            {
                int_Rid = obj_da_Payment.GetPaymentid(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_dt = obj_da_Payment.GetPaymentHead(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_DtInvoice = obj_da_Receipt.GetRAInvoiceToShow(int_Rid, Mode);
                obj_DtCharge = obj_da_Payment.GetPaymentCust(int_Rid);
                obj_DtCT = obj_da_Payment.GetPaymentChrg(int_Rid);
            }
            else if (Str_Type == "RR")
            {
                int_Rid = obj_da_Receipt.GetOSRecrid(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_dt = obj_da_Receipt.GetOSRecptHead(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
            }
            else if (Str_Type == "RP")
            {
                int_Rid = obj_da_Payment.GetOSPaymentid(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
                obj_dt = obj_da_Payment.GetOSPaymentHead(int.Parse(txt_Voucher.Text), int_bid, Mode, int_Year);
            }
            if (obj_dt.Rows.Count > 0)
            {
                DateTime Voucherate = DateTime.Parse(obj_dt.Rows[0][2].ToString());
                txt_Date.Text = obj_dt.Rows[0]["fdate"].ToString() + " / " + Voucherate.DayOfWeek;
                if (Mode == 'B' || Mode == 'M')
                {
                    txt_Cheque.Text = obj_dt.Rows[0][10].ToString();
                    txt_Bank.Text = obj_da_Receipt.GetBankName(int.Parse(obj_dt.Rows[0][8].ToString()));
                    txt_Branch.Text = obj_dt.Rows[0][9].ToString();
                    txt_ChequeDate.Text = string.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0][11]);

                    if (!DBNull.Value.Equals(obj_dt.Rows[0]["clearedon"]))
                    {
                        txt_ClearedDate.Text = string.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["clearedon"]);
                    }
                    else
                    {
                        txt_ClearedDate.Text = "";
                    }
                }
                txt_To.Text = obj_dt.Rows[0][6].ToString();
                txt_Narration.Text = obj_dt.Rows[0][12].ToString();
            }
        }
        private DataTable obj_DtInvoice
        {
            set { ViewState.Add("Add_DtInvoice", value); }
            get { return (DataTable)ViewState["Add_DtInvoice"]; }
        }
        private DataTable obj_DtCharge
        {
            set { ViewState.Add("Add_DtCharge", value); }
            get { return (DataTable)ViewState["Add_DtCharge"]; }
        }
        private DataTable obj_DtCT
        {
            set { ViewState.Add("Add_DtCT", value); }
            get { return (DataTable)ViewState["Add_DtCT"]; }
        }

        protected void btn_Previous_Click(object sender, EventArgs e)
        {
            if (txt_Voucher.Text.TrimEnd().Length > 0)
            {
                txt_Voucher.Text = (int.Parse(txt_Voucher.Text) - 1).ToString();
                txt_Voucher_TextChanged(sender, e);
            }
        }

        protected void btn_Next_Click(object sender, EventArgs e)
        {
            if (txt_Voucher.Text.TrimEnd().Length > 0)
            {
                txt_Voucher.Text = (int.Parse(txt_Voucher.Text) + 1).ToString();
                txt_Voucher_TextChanged(sender, e);
            }
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = ""; Session["str_sp"] = ""; Session["str_sfs1"] = ""; Session["str_sp1"] = "";

            obj_da_FAVoucher.SelFAAllVoucher(Convert.ToInt32(hid_vou.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());

            if (Str_Type == "R")
            {
                if (txt_Voucher.Text.TrimEnd().Length > 0)
                {
                    if (Mode == 'C')
                    {
                        Str_RptName = "ReceiptCash.rpt";
                    }
                    else
                    {
                        Str_RptName = "ReceiptBank.rpt";
                    }

                    Session["str_sfs"] = "{ReceiptHead.receiptid}=" + int_Rid + " and {ReceiptAgainstInvoice.rptype}='R'"; ;
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "FA", Str_Script, true);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, int_bid, Mode + " / " + txt_Voucher.Text);
                }
                else
                {
                    if (Mode.ToString().Length > 0)
                    {
                        if (Mode == 'C')
                        {
                            Str_RptName = "ReceiptCashReg.rpt";
                            Session["str_sfs"] = "{ReceiptHead.mode}='C' and {ReceiptHead.branchid}=" + int_bid + " and {ReceiptHead.vouyear}=" + Session["LogYear"].ToString();
                            Session["str_sp"] = "title=Cash Receipts~branch=";
                        }
                        else
                        {
                            Str_RptName = "ReceiptBankReg.rpt";
                            Session["str_sfs"] = "{ReceiptHead.mode}='B' and {ReceiptHead.branchid}=" + int_bid + " and {ReceiptHead.vouyear}=" + Session["LogYear"].ToString();
                            Session["str_sp"] = "title=Bank Receipts~branch=";
                        }
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "FA", Str_Script, true);
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, int_bid, Mode + " / All ReceiptNo.");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "FA", "alertify.alert('Select Mode');", true);
                    }
                }
            }
            else if (Str_Type == "P")
            {
                if (txt_Voucher.Text.TrimEnd().Length > 0)
                {
                    if (obj_DtInvoice.Rows.Count == 0)
                    {
                        if (obj_DtCT.Rows.Count > 0)
                        {
                            Str_RptName = "PaymentCashCash.rpt";
                            Session["str_sfs"] = "{PaymentHead.receiptid}=" + int_Rid;
                        }
                        else if (obj_DtCharge.Rows.Count > 0)
                        {
                            Str_RptName = "PaymentCashCashcustomer.rpt";
                            Session["str_sfs"] = "{PaymentHead.receiptid}=" + int_Rid;
                        }
                        else
                        {
                            Str_RptName = "PaymentCash.rpt";
                            Session["str_sfs"] = "{PaymentHead.receiptid}=" + int_Rid + " and {ReceiptPayment.rptype}='P'";
                        }
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "FA", Str_Script, true);
                    }
                    else
                    {
                        Str_RptName = "PaymentCash.rpt";
                        Session["str_sfs"] = "{PaymentHead.receiptid}=" + int_Rid + " and {ReceiptPayment.rptype}='P'";
                        Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "FA", Str_Script, true);
                    }
                }
                if (Mode.ToString().Length > 0)
                {
                    if (Mode == 'C')
                    {
                        Str_RptName = "PaymentCashReg.rpt";
                        Session["str_sfs"] = "{PaymentHead.mode}='C' and {PaymentHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString();
                        Session["str_sp"] = "title=Cash Receipts~branch=";
                    }
                    else
                    {
                        Str_RptName = "PaymentBankReg.rpt";
                        Session["str_sfs"] = "{PaymentHead.mode}='B' and {PaymentHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PaymentHead.vouyear}=" + Session["LogYear"].ToString();
                        Session["str_sp"] = "title=Bank Receipts~branch=";
                    }
                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "FA", Str_Script, true);
                    obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 268, 3, int_bid, Mode + " / All ReceiptNo.");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "FA", "alertify.alert('Select Mode');", true);
                }
            }
            else if (Str_Type == "BD")
            {
                Str_RptName = "rptJV.rpt";
                Session["str_sfs"] = " {Tempvoucher.vouid}=" + hid_vou.Value + "And {Tempvoucher.empid} = " + Session["LoginEmpId"].ToString();
                Session["str_sp"] = "Title=Bank Deposit JV~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2) + "~appby=" + "";

                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);

            }
            else if (Str_Type == "BP")
            {
                Str_RptName = "rptJV.rpt";
                Session["str_sfs"] = " {Tempvoucher.vouid}=" + hid_vou.Value + "And {Tempvoucher.empid} = " + Session["LoginEmpId"].ToString();
                Session["str_sp"] = "Title=Bank Payment JV~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2) + "~appby=" + "";

                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);

            }
        }

        private void Fn_Clear()
        {
            txt_AgainstReference.Text = "";
            txt_Bank.Text = "";
            txt_Branch.Text = "";
            txt_Cheque.Text = "";
            txt_ChequeDate.Text = "";
            txt_ClearedDate.Text = "";
            txt_Date.Text = "";
            txt_Narration.Text = "";
            txt_To.Text = "";
            txt_Voucher.Text = "";
            Grd_Receipt.DataSource = new DataTable();
            Grd_Receipt.DataBind();

            btn_Cancel.ToolTip = "Back";
            btn_Cancel1.Attributes["class"] = "btn btn-back1";
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (btn_Cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
            }
            else
            {
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

    }
}