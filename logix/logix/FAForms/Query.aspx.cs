using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Diagnostics;
using AjaxControlToolkit;
namespace logix.FAForm
{
    public partial class Query : System.Web.UI.Page
    {
        DataAccess.FAMaster.ReportView FARepobj = new DataAccess.FAMaster.ReportView();
        DataAccess.FAVoucher da_obj_vou = new DataAccess.FAVoucher();
        DataAccess.FAMaster.MasterLedger ledgerobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        DataTable Dt = new DataTable();
        DataTable Dt1 = new DataTable();
        int i;
        String log, gvlname;
        DataSet dt_set = new DataSet();
        String strAmt = "0";
        String amt_type = "=";
        int intVouTypeID = 0;
        public int ledger_id;
        public String ledger_name;
        int voutypeid, Vouyear;


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FARepobj.GetDataBase(Ccode);
                da_obj_vou.GetDataBase(Ccode);
                ledgerobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);




            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                DateTime Date = FARepobj.MaxVouGetDate(Session["FADbname"].ToString());
                Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                txt_from.Text = "01/04/" + Vouyear;
                txt_to.Text = Utility.fn_ConvertDate(Date.ToString());

                FillVouTypes();
                grd_query.DataSource = new DataTable();
                grd_query.DataBind();
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
            }
        }
          

        [WebMethod]
        public static List<string> GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.FAMaster.MasterLedger da_obj_Ledger = new DataAccess.FAMaster.MasterLedger();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Ledger.GetDataBase(Ccode);
            obj_dt = da_obj_Ledger.GetLikeLedgername(prefix, 1, 1, HttpContext.Current.Session["FADbname"].ToString());
            customers = Utility.Fn_DatatableToList(obj_dt, "ledgername", "ledgerid");
            return customers;
        }


        private void FillVouTypes()
        {
            dt_set = da_obj_vou.GetAllVoucherTypes(Session["FADbname"].ToString());

            if (dt_set.Tables[1].Rows.Count > 0)
            {
                ddl_Voutype.DataTextField = "voutypename";
                ddl_Voutype.DataValueField = "voutypeid";
                ddl_Voutype.DataSource = dt_set.Tables[1];
                ddl_Voutype.DataBind();
                ddl_Voutype.SelectedIndex = 0;
            }
        }

        protected void btn_get_Click(object sender, EventArgs e)
        {
            GetDet();
        }

        private void GetDet()
        {
            if (txt_amt.Text.ToString().Length == 0)
            {
                strAmt = "0";
            }
            else
            {
                strAmt = txt_amt.Text.Trim();
            }
            if (ddl_amttype.SelectedItem.ToString() == "Equal")
            {
                amt_type = "=";
            }
            else if (ddl_amttype.SelectedItem.ToString() == "Greater")
            {
                amt_type = ">";
            }
            else if (ddl_amttype.SelectedItem.ToString() == "Less")
            {
                amt_type = "<";
            }
          
            Dt = da_obj_vou.GetFAquery(amt_type, Convert.ToDouble(strAmt), txt_nrt.Text.Trim(), int.Parse(Session["LoginBranchid"].ToString()), Session["FADbname"].ToString(), txt_cheque.Text.Trim(), txt_ledger.Text.Trim(), intVouTypeID, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString())), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString())));
          
            grd_query.DataSource = Dt;
            grd_query.DataBind();
            ViewState["Query"] = Dt;
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        protected void ddl_Voutype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewState["Query"] != null)
            {
                DataTable dt_Query = (DataTable)ViewState["Query"];

                if (dt_Query.Rows.Count > 0)
                {
                    if (Convert.ToInt32(ddl_Voutype.SelectedValue.ToString()) > 0)
                    {
                        var var_temp = dt_Query.AsEnumerable().Where(row => row["voutypeid"].ToString() == ddl_Voutype.SelectedValue.ToString());

                        if (var_temp == null || var_temp.Count() == 0)
                        {
                            grd_query.DataSource = new DataTable();
                            grd_query.DataBind();
                        }
                        else
                        {
                            grd_query.DataSource = var_temp.CopyToDataTable();
                            grd_query.DataBind();                            
                        }
                    }
                    else
                    {
                        grd_query.DataSource = dt_Query;
                        grd_query.DataBind();                        
                    }
                }
            }
            else if (ddl_Voutype.SelectedValue != "0")
            {
                intVouTypeID = Convert.ToInt32(ddl_Voutype.SelectedValue);
                GetDet();                
            }
            
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                txt_amt.Text = "";
                ddl_amttype.SelectedIndex = 0;
                txt_cheque.Text = "";
                txt_ledger.Text = "";
                txt_nrt.Text = "";
                ddl_Voutype.SelectedIndex = 0;

                DateTime Date = FARepobj.MaxVouGetDate(Session["FADbname"].ToString());
                Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                txt_from.Text = "01/04/" + Vouyear;
                txt_to.Text = Utility.fn_ConvertDate(Date.ToString());
                grd_query.DataSource = new DataTable();
                grd_query.DataBind();
                ViewState["Query"] = null;
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
            }
            else
            {
               // this.Response.End();

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

        protected void txt_nrt_TextChanged(object sender, EventArgs e)
        {
            GetDet();
        }

        protected void txt_amt_TextChanged(object sender, EventArgs e)
        {
            if (ViewState["Query"] != null)
            {
                DataTable dt_Query = (DataTable)ViewState["Query"];
                
                if (dt_Query.Rows.Count > 0)
                {
                    if (txt_amt.Text.ToString().Length > 0)
                    {
                        if (ddl_amttype.SelectedItem.Text == "Equal")
                        {
                            var var_temp = dt_Query.AsEnumerable().Where(row => Convert.ToDouble(row["ledgeramount"]) == Convert.ToDouble(txt_amt.Text.ToString()));
                            if (var_temp == null || var_temp.Count() == 0)
                            {
                                dt_Query = new DataTable();
                            }
                            else
                            {
                                dt_Query = var_temp.CopyToDataTable();
                            }
                        }
                        else if (ddl_amttype.SelectedItem.Text == "Greater")
                        {
                            var var_temp = dt_Query.AsEnumerable().Where(row => Convert.ToDouble(row["ledgeramount"]) > Convert.ToDouble(txt_amt.Text.ToString()));
                            if (var_temp == null || var_temp.Count() == 0)
                            {
                                dt_Query = new DataTable();
                            }
                            else
                            {
                                dt_Query = var_temp.CopyToDataTable();
                            }
                        }
                        else if (ddl_amttype.SelectedItem.Text == "Less")
                        {
                            var var_temp = dt_Query.AsEnumerable().Where(row => Convert.ToDouble(row["ledgeramount"]) < Convert.ToDouble(txt_amt.Text.ToString()));
                            if (var_temp == null || var_temp.Count() == 0)
                            {
                                dt_Query = new DataTable();
                            }
                            else
                            {
                                dt_Query = var_temp.CopyToDataTable();
                            }
                        }
                    }

                    grd_query.DataSource = dt_Query;
                    grd_query.DataBind();                    
                }
            }
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txt_ledger_TextChanged(object sender, EventArgs e)
        {
            if (txt_ledger.Text != "")
            {
                if (hid_LedgerId.Value != "")
                {
                    string str_ledgername;
                    string[] str_temp = txt_ledger.Text.Split(',');
                    if (str_temp.Length > 0)
                    {
                        str_ledgername = str_temp[0].ToString();
                    }
                    else
                    {
                        str_ledgername = txt_ledger.Text;
                    }

                    txt_ledger.Text = str_ledgername;
                    GetDet();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(txt_ledger, typeof(TextBox), "alert", "alertify.alert('Please Enter the Valid LedgerName');", true);
                    txt_ledger.Text = "";
                    txt_ledger.Focus();
                }
            }
        }                

        protected void grd_query_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {               
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_query, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_query_SelectedIndexChanged(object sender, EventArgs e)
        {
            voutypeid = int.Parse(grd_query.SelectedDataKey.Values[0].ToString());
           
            pln_Grd.Show();
            string Str_VoucherName = Fn_GetVoucherName(voutypeid);
            List<string> Lst_Voucher = new List<string> { "Invoice", "Credit Note - Operations", "OSSI", "OSPI", "Debit Note - Others", "Credit Note - Others", "Proforma Invoices", "Extentions", "FinalBills", "OSDNCNJV" };
            List<string> Lst_Receipt = new List<string> { "Bank Receipt", "Cash Receipt", "Bank Payment", "Cash Payment", "BDJV", "BPJV", "BRG" };
            List<string> Lst_Admin = new List<string> { "Admin Sales Invoice", "Admin Purchase Invoice" };
            int Result = 0;

            if (Str_VoucherName == "Bank Receipt")
            {
                gvlname = "Bank Receipt";
            }
            else if (Str_VoucherName == "Cash Receipt")
            {
                Str_VoucherName = "Cash Receipt";
            }
            else if (Str_VoucherName == "Bank Payment")
            {
                gvlname = "Bank Payment";
            }
            else if (Str_VoucherName == "Cash Payment")
            {
                gvlname = "Cash Payment";
            }
            else if (Str_VoucherName == "BDJV")
            {
                gvlname = "BDJV";
            }
            else if (Str_VoucherName == "BPJV")
            {
                gvlname = "BPJV";
            }
            else if (Str_VoucherName == "Receipt - Petty Cash")
            {
                gvlname = "Receipt - Petty Cash";
            }
            else if (Str_VoucherName == "Remittance-Receipt")
            {
                gvlname = "Remittance-Receipt";
            }
            else if (Str_VoucherName == "Remittance-Payment")
            {
                gvlname = "Remittance-Payment";
            }
            else if (Str_VoucherName == "BRG")
            {
                gvlname = "BRG";
            }

            iframeQuery.Attributes["src"] = "";
            Result = Lst_Voucher.Where(row => row == Str_VoucherName).Count();
            if (Result > 0)
            {
                if (voutypeid == 5 || voutypeid == 6)
                {
                    iframeQuery.Attributes["src"] = "../Accounts/OSVouchers.aspx?FAvouTYPE=" + voutypeid + "&vouno=" + grd_query.SelectedRow.Cells[2].Text;
                }
                else
                {
                    iframeQuery.Attributes["src"] = "../Accounts/ApprovedLV.aspx?FAvouTYPE=" + voutypeid + "&vouno=" + grd_query.SelectedRow.Cells[2].Text;
                }
            }

            Result = Lst_Receipt.Where(row => row == Str_VoucherName).Count();
            if (Result > 0)
            {
                //iframeQuery.Attributes["src"] = "../FAForms/Receipt.aspx?QueryVoucherName=" + Str_VoucherName + "&QueryVoucherNo=" + grd_query.SelectedRow.Cells[2].Text;
                if ( int.Parse(Session["Loginbranchid"].ToString()) != 2)
                {
                    

                    string FrmName = "LedgerView_Voucher";
                    iframeQuery.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + grd_query.SelectedRow.Cells[2].Text + "&PBranch_ID=" + int.Parse(Session["Loginbranchid"].ToString()) + "&LView_Flag=" + false;
                    

                }
                else
                {
                    //string url = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + true;
                    //string fullURL = "window.open('" + url + "', '_blank' );";
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                    //Response.Redirect(url);

                    string FrmName = "LedgerView_Voucher";
                    iframeQuery.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + grd_query.SelectedRow.Cells[2].Text + "&PBranch_ID=" + int.Parse(Session["Loginbranchid"].ToString()) + "&LView_Flag=" + true;
                    
                }
                return;
            }

            Result = Lst_Admin.Where(row => row == Str_VoucherName).Count();
            if (Result > 0)
            {
                //iframeQuery.Attributes["src"] = "../FAForms/PAAdmin.aspx?QueryVoucherName=" + Str_VoucherName + "&QueryVoucherNo=" + grd_query.SelectedRow.Cells[2].Text;
                iframeQuery.Attributes["src"] = "../FAForms/ApprovedAdminDCNvouchers.aspx?type=" + Str_VoucherName + "&VNo=" + grd_query.SelectedRow.Cells[2].Text + "&PBranch_ID=" + int.Parse(Session["Loginbranchid"].ToString());
                //return;
            }

            if (Str_VoucherName == "Contra")
            {
                iframeQuery.Attributes["src"] = "../FAForms/Contra.aspx?QueryVoucherName=" + Str_VoucherName + "&QueryVoucherNo=" + grd_query.SelectedRow.Cells[2].Text;
            }

            else if (Str_VoucherName == "Journal")
            {
                //iframeQuery.Attributes["src"] = "../FAForms/Journal.aspx?QueryVoucherName=" + Str_VoucherName + "&QueryVoucherNo=" + grd_query.SelectedRow.Cells[2].Text;
            }

            else if (Str_VoucherName == "Adjustment DCN")
            {
                iframeQuery.Attributes["src"] = "../FAForms/AdjustmenrtDNCN.aspx?QueryVoucherName=" + Str_VoucherName + "&QueryVoucherNo=" + grd_query.SelectedRow.Cells[2].Text+"&VoucherName=CN";
            }
            pln_Grd.Show();
        }

        protected void txt_cheque_TextChanged(object sender, EventArgs e)
        {           
            if (txt_amt.Text.Trim() == "" && txt_nrt.Text.Trim() == "" && txt_cheque.Text.Trim() == "" && txt_ledger.Text.Trim() == "")
            {

            }
            else
            {
                GetDet();
            }
        }

        protected void ddl_amttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_amt.Text != "")
            {
                GetDet();
            } 
        }

        private string Fn_GetVoucherName(int int_Voucherid)
        {
            string str_VoutypeName = "";
            if (int_Voucherid == 1)
            {
                str_VoutypeName = "Invoice";
            }
            else if (int_Voucherid == 2)
            {
                str_VoutypeName = "Credit Note - Operations";
            }
            else if (int_Voucherid == 3)
            {
                str_VoutypeName = "Admin Purchase Invoice";
            }
            else if (int_Voucherid == 4)
            {
                str_VoutypeName = "Admin Sales Invoice";
            }
            else if (int_Voucherid == 5)
            {
                str_VoutypeName = "OSSI";
            }
            else if (int_Voucherid == 6)
            {
                str_VoutypeName = "OSPI";
            }
            else if (int_Voucherid == 7)
            {
                str_VoutypeName = "Debit Note - Others";
            }
            else if (int_Voucherid == 8)
            {
                str_VoutypeName = "Credit Note - Others";
            }
            else if (int_Voucherid == 9)
            {
                str_VoutypeName = "Bank Receipt";
            }
            else if (int_Voucherid == 10)
            {
                str_VoutypeName = "Cash Receipt";
            }
            else if (int_Voucherid == 11)
            {
                str_VoutypeName = "Bank Payment";
            }
            else if (int_Voucherid == 12)
            {
                str_VoutypeName = "Cash Payment";
            }
            else if (int_Voucherid == 13)
            {
                str_VoutypeName = "Journal";
            }
            else if (int_Voucherid == 14)
            {
                str_VoutypeName = "Contra";
            }
            else if (int_Voucherid == 15)
            {
                str_VoutypeName = "Receipt - Petty Cash";
            }
            else if (int_Voucherid == 35)
            {
                str_VoutypeName = "Manual Invoices";
            }
            else if (int_Voucherid == 36)
            {
                str_VoutypeName = "Manual PaymentAdvises";
            }
            else if (int_Voucherid == 37)
            {
                str_VoutypeName = "Manual OSDN";
            }
            else if (int_Voucherid == 38)
            {
                str_VoutypeName = "Manual OSCN";
            }
            else if (int_Voucherid == 39)
            {
                str_VoutypeName = "Manual Debit Note - Others";
            }
            else if (int_Voucherid == 40)
            {
                str_VoutypeName = "Manual Credit Note - Others";
            }
            else if (int_Voucherid == 41)
            {
                str_VoutypeName = "Manual Bank Receipt";
            }
            else if (int_Voucherid == 42)
            {
                str_VoutypeName = "Manual Cash Receipt";
            }
            else if (int_Voucherid == 43)
            {
                str_VoutypeName = "Manual Bank Payment";
            }
            else if (int_Voucherid == 44)
            {
                str_VoutypeName = "Manual Cash Payment";
            }
            else if (int_Voucherid == 45)
            {
                str_VoutypeName = "Manual Contra";
            }
            else if (int_Voucherid == 101)
            {
                str_VoutypeName = "OSDNCNJV";
            }
            else if (int_Voucherid == 1102)
            {
                str_VoutypeName = "BDJV";
            }
            else if (int_Voucherid == 103)
            {
                str_VoutypeName = "BPJV";
            }
            else if (int_Voucherid == 104)
            {
                str_VoutypeName = "BRRJV";
            }
            else if (int_Voucherid == 105)
            {
                str_VoutypeName = "BPRJV";
            }
            else if (int_Voucherid == 16)
            {
                str_VoutypeName = "Remittance-Receipt";
            }
            else if (int_Voucherid == 17)
            {
                str_VoutypeName = "Remittance-Payment";
            }
            else if (int_Voucherid == 19)
            {
                str_VoutypeName = "Adjustment DCN";
            }
            else if (int_Voucherid == 106)
            {
                str_VoutypeName = "BRG";
            }
            return str_VoutypeName;
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
           // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1119, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1231, "", "", "", Session["StrTranType"].ToString());
            }



            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_query_PreRender(object sender, EventArgs e)
        {
            if (grd_query.Rows.Count > 0)
            {
                grd_query.UseAccessibleHeader = true;
                grd_query.HeaderRow.TableSection = TableRowSection.TableHeader;
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