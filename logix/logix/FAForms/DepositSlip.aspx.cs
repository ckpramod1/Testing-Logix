using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Services.Description;
namespace logix.FAForm
{
    public partial class DepositSlip : System.Web.UI.Page
    {
        DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Payment Obj_da_Payment = new DataAccess.Accounts.Payment();
        DataAccess.FAVoucher obj_da_FA_Voucher = new DataAccess.FAVoucher();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.FAMaster.MasterLedger Obj_Ledger = new DataAccess.FAMaster.MasterLedger();

        DataAccess.FAMaster.MasterLedger ledobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Payment pymtobj = new DataAccess.Accounts.Payment();
        DataAccess.FAVoucher faobj = new DataAccess.FAVoucher();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();

        DataTable dt_SlipDet = new DataTable();
        DataTable dt_AllData = new DataTable();
        double Total = 0.00;
        string Type, Curr_Date, DB_Name, str_cmbtype;
        int Branch_ID, VouYear, Division_ID, Emp_ID;

        int i, ledgerid;
        DataTable dt = new DataTable();
        DataTable dtrec = new DataTable();
        DataTable dtpay = new DataTable();
        DataTable Dt1 = new DataTable();

        string receipt, type, curtype, strantype;
        double dbl_P, dbl_R, dbl_X, dbl_Y, dbl_O, dbl_O_CR, dbl_O_DR, dbl_A, dbl_B, dbl_BPR, dbl_BRR, credit, debit;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_Receipt.GetDataBase(Ccode);
                Obj_da_Payment.GetDataBase(Ccode);
                obj_da_FA_Voucher.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                Obj_Ledger.GetDataBase(Ccode);
                ledobj.GetDataBase(Ccode);
                recobj.GetDataBase(Ccode);
                pymtobj.GetDataBase(Ccode);
                faobj.GetDataBase(Ccode);


                logobj.GetDataBase(Ccode);
               

            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_Header.Text = Request.QueryString["FormName"].ToString();
                
            }
            lbl_head.InnerText = lbl_Header.Text;
            hid_StrDate.Value = "";

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                ViewState["NullSlipDetails"] = null;
                ViewState["Save_SlipDetails"] = null;
                ViewState["Deposit_SlipDet"] = null;
                ViewState["Deposit_Clearance"] = null;

                Session["Amount"] = null;
                Session["BRSBank"] = null;
                Grd_DepositSlip.DataSource = new DataTable();
                Grd_DepositSlip.DataBind();

                if (lbl_Header.Text == "Cheque Clearance")
                {
                    Fn_LoadBankLedger();
                    div_deposit.Attributes.Add("class", "gridpnl");
                    txt_chequedate.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToString());
                }
                else if (lbl_Header.Text == "Deposit Slip")
                {
                    txt_depositedate.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToString());
                    div_deposit.Attributes.Add("class", "gridpnl");
                }
            }
            if (lbl_Header.Text == "Deposit Slip")
            {
                drp_Sorting.Visible = false;
                ddl_receipt.Visible = false;
                ddl_bank.Visible = false;
                txt_cheque.Visible = false;
                txt_slip_cheque.Visible = false;
                txt_chequedate.Visible = false;
                HeadingDeposit.Visible = false;
                btn_Get.Visible = false;
                Chk_Date.Visible = false;
                lbl_Book.Visible = false;
                txt_Book.Visible = false;
                lbl_Bank1.Visible = false;
                txt_BRSBank.Visible = false;
                lblourbook.Visible = false;
                lblperbank.Visible = false;
                creditbank.Visible = false;
                Branch_ID = Convert.ToInt32(Session["LoginBranchid"].ToString());
                Equal.Visible = false;
                hid_StrDate.Value = txt_depositedate.Text.ToString();
                txt_slip.Focus();
            }
            else if (lbl_Header.Text == "Cheque Clearance")
            {
                div_chequeclear.Visible = true;
                div_chkusd.Visible = true;
                drp_Sorting.Visible = true;
                txt_slip.Visible = false;
                lbl_slip.Visible = false;

                txt_bank.Visible = false;
                lbl_bank.Visible = false;

                txt_depositedate.Visible = false;
                lbl_depositedate.Visible = false;

                ddl_type.Visible = false;
                lbl_type.Visible = false;

                Hid_LoginBranchID.Value = Session["LoginBranchid"].ToString();
                Branch_ID = Convert.ToInt32(Session["LoginDivisionid"].ToString());
                hid_StrDate.Value = txt_chequedate.Text.ToString();
            }

            Division_ID = Convert.ToInt32(Session["LoginDivisionid"].ToString());
            DB_Name = Session["FADbname"].ToString();
            VouYear = Convert.ToInt32(Session["LogYear"].ToString());
            Emp_ID = Convert.ToInt32(Session["LoginEmpId"].ToString());

            lbl_ChequeDeposit.Visible = false;
            txtreceipt.Visible = false;
            lblreceipt.Visible = false;
            lbl_Balance.Visible = false;
            txtbrstotal.Visible = false;
            lblbrstotal.Visible = false;
            lbl_ChequeIssued.Visible = false;
            txtpayment.Visible = false;
            lbl_IssuedBalance.Visible = false;
            txttotal1.Visible = false;
            lbl_total1.Visible = false;
            lbl_CreditBank.Visible = false;
            txtCBNB.Visible = false;
            lbl_CreditBankBalance.Visible = false;
            txtTotal2_chq.Visible = false;
            lbl_Total2.Visible = false;
            lbl_Debit.Visible = false;
            txtDBNB.Visible = false;


            if (Request.QueryString.ToString().Contains("type"))
            {
                string p = Request.QueryString["type"].ToString();
                if (p == "Payments")
                {
                    ddl_receipt.SelectedValue = "P";
                }
                else if (p == "Receipts")
                {
                    ddl_receipt.SelectedValue = "R";
                }
                string product = Request.QueryString["type"].ToString();
                if (product == "Receipts" || product == "Payments")
                {
                    ddl_receipt_SelectedIndexChanged(sender, e);
                    return;
                }
            }

          
        }

        [WebMethod]
        public static List<string> GetSlipNo(string prefix)
        {
            DataAccess.Accounts.Recipts Receipt_Obj = new DataAccess.Accounts.Recipts();
            DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Receipt_Obj.GetDataBase(Ccode);
            Emp_Obj.GetDataBase(Ccode);
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();

            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            string BranchName = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
            int Branchid = Emp_Obj.GetBranchId(did, BranchName);

            dt = Receipt_Obj.GetLikeSlipno(prefix, Branchid);
            List_Result = Utility.Fn_TableToList(dt, "slipno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetBank(string prefix, string ChkType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Recipts da_obj_Receipt = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Receipt.GetDataBase(Ccode);

            if (ChkType == "P")
            {
                obj_dt = da_obj_Receipt.GetLikeBankName(prefix.ToUpper(), "O");
                List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "bankname", "bankid");
            }
            else
            {
                obj_dt = da_obj_Receipt.GetLikeBankName(prefix.ToUpper());
                List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "bankname", "bankid");
            }
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetChequeSlip(string prefix, string Type)
        {
            int int_bid = int.Parse(HttpContext.Current.Session["LoginDivisionid"].ToString());
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Recipts da_obj_Receipt = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Receipt.GetDataBase(Ccode);
            obj_dt = da_obj_Receipt.GetRecptPymtContraLikeChqno(int_bid, prefix.ToUpper(), char.Parse(Type), HttpContext.Current.Session["FADbname"].ToString());
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "chequeno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetSlipNo_Cheque(string prefix, string Type)
        {
            int int_bid = int.Parse(HttpContext.Current.Session["LoginDivisionid"].ToString());
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Recipts da_obj_Receipt = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Receipt.GetDataBase(Ccode);
            obj_dt = da_obj_Receipt.GetRecptPymtContraLikeChqno(int_bid, prefix.ToUpper(), 'S', HttpContext.Current.Session["FADbname"].ToString());
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "chequeno");
            return List_Result;
        }

        private void Fn_LoadBankLedger()
        {
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_Ledger.GetDataBase(Ccode);
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Ledger.GetBankLedger(Session["FADbname"].ToString());

            ddl_bank.Items.Insert(0, new ListItem("ALL", string.Empty));
            ddl_bank.DataSource = obj_dt;
            ddl_bank.DataTextField = "LedgerName";
            ddl_bank.DataValueField = "ledgerid";
            ddl_bank.DataBind();
        }

        protected void txt_slip_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ViewState["NullSlipDetails"] = null;
                ViewState["Save_SlipDetails"] = null;
                ViewState["Deposit_SlipDet"] = null;
                ViewState["Deposit_Clearance"] = null;

                Session["Amount"] = null;
                Session["BRSBank"] = null;
                Fn_GetNotNullslipDetails();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void Fn_GetNotNullslipDetails()
        {
            txt_slip.Text = txt_slip.Text.ToUpper();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Receipt.GetSlipDetailsFA(txt_slip.Text, Branch_ID, ddl_type.SelectedValue.ToString());

            obj_dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Slip #"),
                new DataColumn("ClearedOn"),
                new DataColumn("shortname"),
                new DataColumn("ID"),               
            });


            if (obj_dt.Rows.Count > 0)
            {
                hid_slipid.Value = obj_dt.Rows[0]["slipid"].ToString();
                hid_bankid.Value = obj_dt.Rows[0]["slipbank"].ToString();
                txt_depositedate.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["Slipdate"].ToString());
                hid_StrDate.Value = txt_depositedate.Text;
                txt_bank.Text = obj_da_Receipt.GetBankName(Convert.ToInt32(hid_bankid.Value.ToString()));
                txt_remark.Text = obj_dt.Rows[0]["remarks"].ToString();
                string Mode_Type = obj_dt.Rows[0]["mode"].ToString();

                if (Mode_Type == "B")
                {
                    ddl_type.SelectedValue = "B";
                }
                else if (Mode_Type == "C")
                {
                    ddl_type.SelectedValue = "C";
                }

                ViewState["ddl_type"] = ddl_type.SelectedItem.Text;
                Grd_DepositSlip.DataSource = obj_dt;
                Grd_DepositSlip.DataBind();
                ViewState["NullSlipDetails"] = obj_dt;
                Total = 0;
                foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                {
                    CheckBox Chk = (CheckBox)Row.FindControl("Chk_Select");
                    Chk.Checked = true;
                    Total = Total + Convert.ToDouble(Row.Cells[4].Text);
                }

                Session["Amount"] = Total;
                txt_total.Text = string.Format("{0:#,##0.00}", Total);
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";
                txt_bank.Enabled = false;
                txt_remark.Enabled = false;
                ddl_type.Enabled = false;

                Fn_GetNullSlipDetails();
            }
            else
            {
                string User_Branch;
                User_Branch = obj_da_Receipt.SlipNoExist(txt_slip.Text);
                if (User_Branch != "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('This Slip # Already Used in " + User_Branch + "')", true);
                    txt_slip.Text = "";
                    txt_slip.Focus();
                    return;
                }
                else
                {
                    Reset();
                    txt_bank.Focus();
                }
            }
        }

        protected void Fn_GetNullSlipDetails()
        {
            DataTable dt = new DataTable();
            int a = 0;

            if (ViewState["ddl_type"] != null)
            {
                Type = ViewState["ddl_type"].ToString();
            }

            dt_SlipDet = obj_da_Receipt.GetSlipDetailsFA("", Branch_ID, Type);

            if (ViewState["NullSlipDetails"] != null && !ViewState["NullSlipDetails"].Equals("-1"))
            {
                ViewState["Save_SlipDetails"] = ViewState["NullSlipDetails"];
                ViewState["Save_SlipDetails"] = dt;
                dt_AllData = (DataTable)ViewState["NullSlipDetails"];
                a = dt_AllData.Rows.Count;
            }

            if (dt_SlipDet.Rows.Count > 0)
            {
                if (a == 0)
                {
                    dt_AllData.Columns.Add("chequeno");
                    dt_AllData.Columns.Add("chequedate");
                    dt_AllData.Columns.Add("bank");
                    dt_AllData.Columns.Add("customername");
                    dt_AllData.Columns.Add("Amount");
                    dt_AllData.Columns.Add("Slip #");
                    dt_AllData.Columns.Add("ClearedOn");
                    dt_AllData.Columns.Add("shortname");
                    dt_AllData.Columns.Add("ID");
                    dt_AllData.Columns.Add("slipid");
                }

                for (int i = 0; i <= dt_SlipDet.Rows.Count - 1; i++)
                {
                    DataRow dtrow = dt_AllData.NewRow();
                    dtrow["chequeno"] = dt_SlipDet.Rows[i]["chequeno"].ToString();
                    dtrow["chequedate"] = dt_SlipDet.Rows[i]["chequedate"].ToString();
                    dtrow["bank"] = dt_SlipDet.Rows[i]["bank"].ToString();
                    dtrow["customername"] = dt_SlipDet.Rows[i]["customername"].ToString();
                    dtrow["Amount"] = dt_SlipDet.Rows[i]["amount"].ToString();
                    dtrow["ID"] = dt_SlipDet.Rows[i]["receiptid"].ToString();
                    if (!string.IsNullOrEmpty(dt_SlipDet.Rows[i]["slipid"].ToString()))
                    {
                        dtrow["slipid"] = Convert.ToInt32(dt_SlipDet.Rows[i]["slipid"].ToString());
                    }
                    else
                    {
                        dtrow["slipid"] = 0;
                    }
                   
                    dt_AllData.Rows.Add(dtrow);
                }

                Grd_DepositSlip.DataSource = dt_AllData;
                Grd_DepositSlip.DataBind();
                ViewState["NullSlipDetails"] = dt_AllData;

                if (ViewState["NullSlipDetails"] != null && !ViewState["NullSlipDetails"].Equals("-1"))
                {
                   // dt_AllData = (DataTable)ViewState["Deposit_SlipDet"];

                    dt_AllData = (DataTable)ViewState["NullSlipDetails"];
                    foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                    {
                        int Index = Row.RowIndex;
                        CheckBox Chk = (CheckBox)Row.FindControl("Chk_Select");
                        if (dt_AllData.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dt_AllData.Rows[Index]["slipid"].ToString()) && dt_AllData.Rows[Index]["slipid"].ToString()!="0")
                            {
                                Chk.Checked = true;
                            }
                        }
                    }
                }
               // ViewState["NullSlipDetails"] = null;
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            //else
            //{
            //    Grd_DepositSlip.DataSource = new DataTable();
            //    Grd_DepositSlip.DataBind();
            //}
        }

        protected void Chk_Select_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBox Chk = sender as CheckBox;
                GridViewRow Row = (GridViewRow)Chk.NamingContainer;
                CheckBox chkAmount = ((CheckBox)Grd_DepositSlip.Rows[Row.RowIndex].FindControl("Chk_Select"));
                if (Chk.Checked == true)
                {
                    if (Session["Amount"] == null)
                    {
                        Total = double.Parse(Grd_DepositSlip.Rows[Row.RowIndex].Cells[4].Text.ToString());
                        Session["Amount"] = Total;
                        txt_total.Text = string.Format("{0:#,##0.00}", Total);

                        if (Session["BRSBank"] != "" || Session["BRSBank"] == "")
                        {
                            txt_BRSBank.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(Session["BRSBank"]) + Convert.ToDouble(txt_total.Text)));
                        }
                    }
                    else
                    {
                        Total = double.Parse(Session["Amount"].ToString()) + double.Parse(Grd_DepositSlip.Rows[Row.RowIndex].Cells[4].Text.ToString());
                        Session["Amount"] = Total;
                        txt_total.Text = string.Format("{0:#,##0.00}", Total);

                        if (Session["BRSBank"] != "" || Session["BRSBank"] == "")
                        {
                            txt_BRSBank.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(Session["BRSBank"]) + Convert.ToDouble(txt_total.Text)));
                        }
                    }
                }
                else
                {
                    if (Session["Amount"] == null)
                    {
                        Total = double.Parse(Grd_DepositSlip.Rows[Row.RowIndex].Cells[4].Text.ToString());
                        //Session["Amount"] = Total;
                        Total = Convert.ToDouble(txt_total.Text) - Total;
                        txt_total.Text = string.Format("{0:#,##0.00}", Total);
                        Session["Amount"] = txt_total.Text;
                        if (Session["BRSBank"] != "" || Session["BRSBank"] == "")
                        {
                            txt_BRSBank.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(Session["BRSBank"]) + Convert.ToDouble(txt_total.Text)));
                        }

                    }else
                    {
                        Total = double.Parse(Session["Amount"].ToString()) - double.Parse(Grd_DepositSlip.Rows[Row.RowIndex].Cells[4].Text.ToString());
                        Session["Amount"] = Total;
                        txt_total.Text = string.Format("{0:#,##0.00}", Total);

                        if (Session["BRSBank"] != "" || Session["BRSBank"] == "")
                        {
                            txt_BRSBank.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(Session["BRSBank"]) + Convert.ToDouble(txt_total.Text)));
                        }
                    }
                    
                }
                chkAmount.Focus();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void TallyBRSAmount(bool Checked, double amt)
        {
            if (ddl_receipt.SelectedItem.Text == "Receipts" || ddl_receipt.SelectedItem.Text == "Overseas Receipt" || ddl_receipt.SelectedItem.Text == "Manual Bank Receipt" || ddl_receipt.SelectedItem.Text == "Bank Receipt Reverse")
            {
                txtreceipt.Text = (Convert.ToDouble(txt_total.Text) - amt).ToString();
            }
            else if (ddl_receipt.SelectedItem.Text == "Payments" || ddl_receipt.SelectedItem.Text == "Overseas Payment" || ddl_receipt.SelectedItem.Text == "Manual Bank Payment" || ddl_receipt.SelectedItem.Text == "Bank Payment Reverse")
            {
                txtpayment.Text = (Convert.ToDouble(txt_total.Text) - amt).ToString();
            }

            if (lblourbook.Text == "Cr")
            {
                txt_Book.Text = "-" + txt_Book.Text;
            }
            CalAmount();
        }

        public void CalAmount_brs()
        {
            if (txttotal1.Text == "")
            {
                txttotal1.Text = "0.00";
            }

            if (txtCBNB_brs.Text.ToString().Length > 0)
            {
                if (curtype == "USD")
                {
                    txttotal2.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(txttotal1.Text) + Convert.ToDouble(txtCBNB_brs.Text)));
                }
                else
                {
                    txttotal2.Text = string.Format("{0:#,#0.00}", (Convert.ToDouble(txttotal1.Text) + Convert.ToDouble(txtCBNB_brs.Text)));
                }

            }
            else
            {
                if (curtype == "USD")
                {
                    txttotal2.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(txttotal1.Text)));
                }
                else
                {
                    txttotal2.Text = string.Format("{0:#,#0.00}", (Convert.ToDouble(txttotal1.Text)));
                }

            }


            if (txtDBNB_brs.Text.ToString().Length > 0)
            {
                if (curtype == "USD")
                {
                    txtbank.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(txttotal2.Text) - Convert.ToDouble(txtDBNB_brs.Text)));
                }
                else
                {
                    txtbank.Text = string.Format("{0:#,#0.00}", (Convert.ToDouble(txttotal2.Text) - Convert.ToDouble(txtDBNB_brs.Text)));
                }

            }
            else
            {
                if (curtype == "USD")
                {
                    txtbank.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(txttotal2.Text)));
                }
                else
                {
                    txtbank.Text = string.Format("{0:#,#0.00}", (Convert.ToDouble(txttotal2.Text)));
                }

            }
        }

        protected void txtCBNB_TextChanged(object sender, EventArgs e)
        {
            CalAmount();
        }

        protected void txtDBNB_TextChanged(object sender, EventArgs e)
        {
            CalAmount();
        }

        protected void CalAmount()
        {
            txtbrstotal.Text = (Convert.ToDouble(txt_Book.Text) - Convert.ToDouble(txtreceipt.Text)).ToString();
            txttotal1.Text = (Convert.ToDouble(txtbrstotal.Text) + Convert.ToDouble(txtpayment.Text)).ToString();

            if (txtCBNB.Text.ToString().Length > 0)
            {
                txtTotal2_chq.Text = (Convert.ToDouble(txttotal1.Text) + Convert.ToDouble(txtCBNB.Text)).ToString();
            }
            else
            {
                txtTotal2_chq.Text = txttotal1.Text;
            }

            if (txtDBNB.Text.ToString().Length > 0)
            {
                txt_BRSBank.Text = (Convert.ToDouble(txtTotal2_chq.Text) + Convert.ToDouble(txtDBNB.Text)).ToString();
            }
            else
            {
                txt_BRSBank.Text = txttotal1.Text;
            }

            if (Convert.ToDouble(txt_Book.Text) < 0)
            {
                lblourbook.Text = "Cr";
                txt_Book.Text = txt_Book.Text.Remove(0, 1);
            }
            else
            {
                lblourbook.Text = "Dr";
            }

            if (Convert.ToDouble(txtbrstotal.Text) < 0)
            {
                lblourbook.Text = "Cr";
                txtbrstotal.Text = txtbrstotal.Text.Remove(0, 1);
            }
            else
            {
                lblourbook.Text = "Dr";
            }

            if (Convert.ToDouble(txttotal1.Text) < 0)
            {
                lbl_total1.Text = "Cr";
                txttotal1.Text = txttotal1.Text.Remove(0, 1);
            }
            else
            {
                lbl_total1.Text = "Dr";
            }

            if (Convert.ToDouble(txtTotal2_chq.Text) < 0)
            {
                lbl_Total2.Text = "Cr";
                txtTotal2_chq.Text = txtTotal2_chq.Text.Remove(0, 1);
            }
            else
            {
                lbl_Total2.Text = "Dr";
            }

            if (Convert.ToDouble(txt_BRSBank.Text) < 0)
            {
                lblperbank.Text = "Cr";
                txt_BRSBank.Text = txt_BRSBank.Text.Remove(0, 1);
            }
            else
            {
                lblperbank.Text = "Dr";
            }
            txt_BRSBank.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(txt_BRSBank.Text)));
            Session["BRSBank"] = txt_BRSBank.Text;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                txt_slip.Text = txt_slip.Text.ToUpper();
                DataTable dt_Save = new DataTable();
                //-----------Priliminary Needs For DepositSlip-------------------

                if (lbl_Header.Text == "Deposit Slip")
                {
                    if (txt_slip.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter Slip #')", true);
                        txt_slip.Focus();
                        return;
                    }
                    if (txt_bank.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter Bank Name')", true);
                        txt_bank.Focus();
                        return;
                    }
                    if (hid_bankid.Value == "0" || hid_bankid.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Bank Name')", true);
                        return;
                    }
                    if (ddl_type.Text == "Type")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Type')", true);
                        ddl_type.Focus();
                        return;
                    }

                    DateTime Date1, Date2;
                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToString());
                    Date1 = Convert.ToDateTime(Utility.fn_ConvertDate(txt_depositedate.Text));
                    Date2 = Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value));

                    if (Date1 > Date2)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Deposit Date Should not Exceed Today')", true);
                        return;
                    }
                }

                //--------------Priliminary Needs For Cheque Clearance-------------------

                if (lbl_Header.Text == "Cheque Clearance")
                {
                    DateTime ClearedDate;
                    if (txt_chequedate.Text != "")
                    {
                        hid_StrDate.Value = txt_chequedate.Text;
                    }
                    ClearedDate = Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value));
                    String Bankname = ddl_bank.SelectedItem.Text;
                    DataTable dt = new DataTable();
                    dt = Obj_Ledger.CheckBRSDate(Bankname, ClearedDate);
                    if (dt.Rows.Count > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Already BRS Confirmed.');", true);
                        //txt_chequedate.Focus();
                        return;
                    }
                    
                    
                    if (ddl_receipt.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Receipt / Payment')", true);
                        ddl_receipt.Focus();
                        return;
                    }
                }

                //----------------checking atlest a row is selected----------------------

                int flag = 0, Select_Count = 0, Slip_ID = 0;

                foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                {
                    int Index = Row.RowIndex;
                    CheckBox Chk = (CheckBox)Row.FindControl("Chk_Select");

                    if (Chk.Checked == true)
                    {
                        flag = 1;
                        Select_Count = Select_Count + 1;
                        if (lbl_Header.Text == "Deposit Slip")
                        {
                            if (Select_Count > 10)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Should not select more than 10 rows')", true);
                                return;
                            }
                        }
                    }
                }

                if (flag == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Details')", true);
                    return;
                }

                //---------------------Inserting Data & Retriving SlipID from FA.dbo.DepositSlip------------------------------------------------

                DataTable dt_New = new DataTable();

                if (lbl_Header.Text == "Deposit Slip")
                {
                    dt_New = ViewState["NullSlipDetails"] as DataTable;

                    if (ViewState["Save_SlipDetails"] != null && !ViewState["Save_SlipDetails"].Equals(-1))
                    {
                        dt_Save = ViewState["Save_SlipDetails"] as DataTable;
                    }
                }
                else
                {
                    if (ddl_bank.SelectedValue == "0" || ddl_bank.SelectedValue == "")
                    {
                        if (ViewState["Deposit_Clearance"] != null && !ViewState["Deposit_Clearance"].Equals(-1))
                        {
                            dt_New = ViewState["Deposit_Clearance"] as DataTable;
                        }
                    }

                    if (ViewState["Deposit_SlipDet"] != null && !ViewState["Deposit_SlipDet"].Equals(-1))
                    {
                        dt_New = ViewState["Deposit_SlipDet"] as DataTable;
                    }
                }

                if (lbl_Header.Text == "Deposit Slip")
                {
                    if (btn_save.ToolTip == "Save")
                    {
                        DateTime temp1, temp2;
                        temp1 = Convert.ToDateTime(Utility.fn_ConvertDate(txt_depositedate.Text));

                        for (int i = 0; i <= Grd_DepositSlip.Rows.Count - 1; i++)
                        {
                            CheckBox chk = (CheckBox)Grd_DepositSlip.Rows[i].FindControl("Chk_Select");

                            if (chk.Checked == true)
                            {
                                if (Grd_DepositSlip.Rows.Count > 0)
                                {
                                    hid_RecDate.Value =Utility.fn_ConvertDate( Grd_DepositSlip.Rows[i].Cells[0].Text);
                                    temp2 = Convert.ToDateTime(hid_RecDate.Value);
                                    if (temp1 < temp2)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Deposit Date must be greater than Receipt Date')", true);
                                        return;
                                    }
                                }
                            }
                        }

                        Slip_ID = obj_da_Receipt.InsDepositSlip(txt_slip.Text, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), Convert.ToInt32(hid_bankid.Value), txt_remark.Text, Branch_ID);
                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You Cannot Amend the Deposit Slip. Please try New Deposit Slip.')", true);
                        return;
                    }
                }


                if (lbl_Header.Text == "Cheque Clearance")
                {
                    if (btn_save.ToolTip == "Save")
                    {
                        DateTime ClearedDate;
                        ClearedDate = Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value));

                        for (int i = 0; i <= Grd_DepositSlip.Rows.Count - 1; i++)
                        {
                            CheckBox chk = (CheckBox)Grd_DepositSlip.Rows[i].FindControl("Chk_Select");

                            if (chk.Checked == true)
                            {
                                DateTime ChequeDate = Convert.ToDateTime(Utility.fn_ConvertDate(Grd_DepositSlip.Rows[i].Cells[0].Text));

                                if (ClearedDate > ChequeDate.AddDays(90))
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Cleared on Date must be Less than or equal 90 days of Cheque Date')", true);
                                    return;
                                }

                                if (ClearedDate < ChequeDate.AddDays(-90))
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Cleared on Date must Within 90 days of Cheque issued on Date')", true);
                                    return;
                                }
                            }
                        }
                    }
                }


                //---------------------Updating Details to the selected cheque #------------------

                int RPid = 0;

                for (int i = 0; i <= dt_New.Rows.Count - 1; i++)
                {
                    RPid = Convert.ToInt32(dt_New.Rows[i]["ID"].ToString());
                    CheckBox chk = (CheckBox)Grd_DepositSlip.Rows[i].FindControl("Chk_Select");

                    if (lbl_Header.Text == "Deposit Slip")
                    {
                        Type = ddl_type.SelectedValue.ToString();
                    }
                    else
                    {
                        Type = ddl_receipt.SelectedValue.ToString();
                    }


                    //    If BtnSave.Text = "&Save" Then

                    //Dim  As DateTime
                    //tmpdate1 = DateDpst.Value
                    //For i = 0 To Grd.Rows.Count - 1
                    //If Grd.Rows(i).Cells("selc").Value = True Then



                    //If tmpdate1 > DateAdd(DateInterval.Day, 90, CDate(ConvertDate(Grd.Rows(i).Cells("chqdate").Value))) Then
                    //    MsgBox("Cleared on  date must be Less than or equal 90 days of Cheque date ")
                    //    Exit Sub
                    //End If


                    //If tmpdate1 < DateAdd(DateInterval.Day, -90, CDate(ConvertDate(Grd.Rows(i).Cells("chqdate").Value))) Then
                    //    MsgBox("Cleared on  date must Within 90 days of Cheque issued on Date ")
                    //    Exit Sub
                    //End If
                    //End If
                    //Next

                    //End If





                    if (chk.Checked == true)
                    {
                        if (Type == "B" || Type == "C")
                        {
                            obj_da_Receipt.UpdSlipDetails(Slip_ID, RPid, Branch_ID, Type);
                        }
                        else if (Type == "R")
                        {
                            obj_da_Receipt.UpdRecptClearanceDetails('T', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid);
                        }
                        else if (Type == "P")
                        {
                            Obj_da_Payment.UpdPymtClearanceDetails('T', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid);
                        }
                        else if (Type == "O" || Type == "Z" || Type == "S" || Type == "BPR" || Type == "BRR")
                        {
                            obj_da_FA_Voucher.UpdContraClearanceDetails('T', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid, DB_Name);
                        }
                        else if (Type == "X")
                        {
                            obj_da_Receipt.UpdOSRecptClearanceDetails('T', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid);
                        }
                        else if (Type == "Y")
                        {
                            Obj_da_Payment.UpdOSPymtClearanceDetails('T', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid);
                        }
                    }
                    else
                    {
                        if (Type == "B" || Type == "C")
                        {
                            obj_da_Receipt.UpdSlipDetails(0, RPid, Branch_ID, Type);
                        }
                        else if (Type == "R")
                        {
                            obj_da_Receipt.UpdRecptClearanceDetails('F', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid);
                        }
                        else if (Type == "P")
                        {
                            Obj_da_Payment.UpdPymtClearanceDetails('F', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid);
                        }
                        else if (Type == "O" || Type == "Z" || Type == "S" || Type == "BPR" || Type == "BRR")
                        {
                            obj_da_FA_Voucher.UpdContraClearanceDetails('F', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid, DB_Name);
                        }
                        else if (Type == "X")
                        {
                            obj_da_Receipt.UpdOSRecptClearanceDetails('F', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid);
                        }
                        else if (Type == "Y")
                        {
                            Obj_da_Payment.UpdOSPymtClearanceDetails('F', Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), RPid);
                        }
                    }

                    if (Session["str_ModuleName"] == "FA")
                    {
                        obj_da_Log.InsLogDetail(Emp_ID, 1103, 1, Branch_ID, "Mode #: " + ddl_receipt.SelectedItem.Text.ToString() + "/Cleared Date: " + hid_StrDate.Value + "ID : " + RPid.ToString() + " Type : " + Type.ToString() + " : " + chk.Checked + "/S");
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(Emp_ID, 1223, 1, Branch_ID, "Mode #: " + ddl_receipt.SelectedItem.Text.ToString() + "/Cleared Date: " + hid_StrDate.Value + "ID : " + RPid.ToString() + " Type : " + Type.ToString() + " : " + chk.Checked + "/S"); ;
                    }
                }

                if (lbl_Header.Text == "Deposit Slip")
                {
                    if (btn_save.ToolTip == "Save")
                    {
                        // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Deposit - Transfer To CO", Convert.ToInt32(txt_slip.Text), 0, "", "");
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer_Slip("Bank Deposit - Transfer To CO", txt_slip.Text, 0, "", "");
                    }

                    if (Session["str_ModuleName"].ToString() == "FA")
                    {
                        obj_da_Log.InsLogDetail(Emp_ID, 1145, 1, Branch_ID, "Slip #: " + txt_slip.Text + " /Type : " + ddl_type.SelectedItem.ToString());
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(Emp_ID, 1192, 1, Branch_ID, "Slip #: " + txt_slip.Text + " /Type : " + ddl_type.SelectedItem.ToString());
                    }
                }
                else
                {
                    if (Session["str_ModuleName"].ToString() == "FA")
                    {
                        obj_da_Log.InsLogDetail(Emp_ID, 1103, 1, Branch_ID, "Mode #: " + ddl_type.SelectedItem.ToString() + "/Cleared Date: " + hid_StrDate.Value);
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(Emp_ID, 1223, 1, Branch_ID, "Mode #: " + ddl_type.SelectedItem.ToString() + "/Cleared Date: " + hid_StrDate.Value);
                    }
                }

                if (btn_save.ToolTip == "Save")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Saved')", true);
                }
                else if (btn_save.ToolTip == "Update")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Updated')", true);
                }
                Reset();
                Reset4slip();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void Reset4slip()
        {
            txt_slip.Text = "";
            txt_slip.Enabled = true;
        }

        protected void Reset()
        {
            chkc.Checked = false;
            grdContra.DataSource = Utility.Fn_GetEmptyDataTable();
            grdContra.DataBind();
            grdPayment.DataSource = Utility.Fn_GetEmptyDataTable();
            grdPayment.DataBind();
            GrdReceipt.DataSource = Utility.Fn_GetEmptyDataTable();
            GrdReceipt.DataBind();
            txtreceipt_brs.Text = "0.00";
            txt_Receipt.Text = "0.00";
            txttotal.Text = "0.00";
            txtpayment_brs.Text = "0.00";
            txtCBNB_brs.Text = "0.00";
            txt_contraDB.Text = "0.00";
            txttotal_balance.Text = "0.00";
            txttotal2.Text = "0.00";
            txtDBNB_brs.Text = "0.00";
            txtbank.Text = "0.00";

            txt_bank.Text = "";
            txt_bank.Enabled = true;
            ddl_type.Enabled = true;
            txt_remark.Text = "";
            txt_remark.Enabled = true;
            txt_total.Text = "0.00";
            txt_BRSBank.Text = "0.00";
            ddl_type.SelectedIndex = 0;
            Grd_DepositSlip.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_DepositSlip.DataBind();
            txt_Book.Text = "";
            txt_Book.Text = "0.00";
            txt_slip_cheque.Text = "";
            txt_cheque.Text = "";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            txt_slip.Focus();
            txt_cheque.Text = "";

            ViewState["NullSlipDetails"] = null;
            ViewState["Save_SlipDetails"] = null;
            ViewState["Deposit_SlipDet"] = null;
            ViewState["Deposit_Clearance"] = null;

            Session["Amount"] = null;
            Session["BRSBank"] = null;

            ddl_receipt.SelectedIndex = -1;
            ddl_bank.Items.Clear();
            Fn_LoadBankLedger();
            drp_Sorting.SelectedValue = "0";

            if (lbl_Header.Text == "Deposit Slip")
            {
                txt_depositedate.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToString());
            }
            else
            {
                txt_chequedate.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToString());
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            string str_RptName = "", str_sf = "", str_sp = "", str_Script = "";
            Session["str_sp"] = ""; Session["str_sfs"] = "";

            if (lbl_Header.Text == "Deposit Slip")
            {
                if (ddl_type.SelectedValue != "")
                {
                    //Session["str_sp"] = "Deposit Date=" + hid_StrDate.Value;
                    DateTime clearedon = new DateTime();
                    //clearedon = Convert.ToDateTime(hid_StrDate.Value);

                    clearedon = Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value.ToString()));

                    if (ddl_type.SelectedItem.Text == "Bank")
                    {
                        str_RptName = "DepositDetails.rpt";
                        Session["str_sfs"] = "{DepositSlip.slipdate}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {DepositSlip.branchid}=" + Branch_ID + " and {ReceiptHead.mode}='B' ";
                    }
                    else if (ddl_type.SelectedItem.Text == "Cash")
                    {
                        str_RptName = "DepositDetailsCash.rpt";
                        Session["str_sfs"] = "{DepositSlip.slipdate}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {DepositSlip.branchid}=" + Branch_ID + " and {ReceiptHead.mode}='C' ";
                    }
                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Type Can Not Be Empty')", true);
                    ddl_type.Focus();
                    return;
                }
            }
            else if (lbl_Header.Text == "Cheque Clearance")
            {
                DataAccess.FAMaster.ReportView Obj_Rpt = new DataAccess.FAMaster.ReportView();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                Obj_Rpt.GetDataBase(Ccode);

                if (ddl_receipt.SelectedValue != "")
                {
                    Session["str_sp"] = "CleardDate=" + hid_StrDate.Value;
                    DateTime clearedon;
                    clearedon = Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value.ToString()));
                    if (ddl_receipt.SelectedItem.Text == "ALL")
                    {
                        if (Grd_DepositSlip.Rows.Count > 0)
                        {
                            Obj_Rpt.DelTempFAChequeClearance(Emp_ID, DB_Name);
                            for (int i = 0; i <= Grd_DepositSlip.Rows.Count - 1; i++)
                            {
                                if (Grd_DepositSlip.Rows[i].Visible == true)
                                {
                                    bool value = false;
                                    foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                                    {
                                        CheckBox Chk = (CheckBox)Row.FindControl("Chk_Select");
                                        if (Chk.Checked == true)
                                        {
                                            value = Chk.Checked;
                                        }
                                        else
                                        {
                                            value = Chk.Checked;
                                        }
                                    }

                                    //Obj_Rpt.InsTempchequeClearance(Emp_ID, DB_Name, Branch_ID, Grd_DepositSlip.Rows[i].Cells[0].Text, Grd_DepositSlip.Rows[i].Cells[1].Text, Grd_DepositSlip.Rows[i].Cells[2].Text, Grd_DepositSlip.Rows[i].Cells[3].Text, Grd_DepositSlip.Rows[i].Cells[4].Text, Grd_DepositSlip.Rows[i].Cells[5].Text, Grd_DepositSlip.Rows[i].Cells[6].Text, Grd_DepositSlip.Rows[i].Cells[7].Text, Grd_DepositSlip.Rows[i].Cells[8].Text, Grd_DepositSlip.Rows[i].Cells[9].Text, Grd_DepositSlip.Rows[i].Cells[10].Text);
                                    Obj_Rpt.InsTempchequeClearance(Emp_ID, DB_Name, Convert.ToInt32(Hid_LoginBranchID.Value), Grd_DepositSlip.Rows[i].Cells[0].Text, Grd_DepositSlip.Rows[i].Cells[1].Text, Grd_DepositSlip.Rows[i].Cells[2].Text, Grd_DepositSlip.Rows[i].Cells[3].Text, Grd_DepositSlip.Rows[i].Cells[4].Text, value.ToString(), Grd_DepositSlip.Rows[i].Cells[9].Text, Grd_DepositSlip.Rows[i].Cells[6].Text, Grd_DepositSlip.Rows[i].Cells[7].Text, Grd_DepositSlip.Rows[i].Cells[8].Text, ddl_receipt.SelectedItem.Text);
                                }
                            }
                        }
                        str_RptName = "rptCCALL.rpt";
                        Session["str_sfs"] = "{tmpchqclearance.empid}=" + Emp_ID;
                    }
                    else if (ddl_receipt.SelectedItem.Text == "Receipts")
                    {
                        str_RptName = "rptCCReceipt.rpt";

                        Session["str_sfs"] = "{ACReceiptHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.divisionid}=" + Branch_ID + " and {MasterBank.BankName}='" + ddl_bank.SelectedItem.Text + "'";

                    }
                    else if (ddl_receipt.SelectedItem.Text == "Payments")
                    {
                        str_RptName = "rptCCPayment.rpt";
                        Session["str_sfs"] = "{ACPaymentHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.divisionid}=" + Branch_ID + " and {MasterBank.BankName}='" + ddl_bank.SelectedItem.Text + "'";
                    }
                    else if (ddl_receipt.SelectedItem.Text == "Contra")
                    {
                        str_RptName = "rptCCContra.rpt";
                        Session["str_sfs"] = "{MasterVoucherHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.branchid}=" + Convert.ToInt32(Hid_LoginBranchID.Value) + " and {VoucherDetails.ledgertype}='Cr'  and {MasterVoucherHead.voutype}=14";
                    }
                    else if (ddl_receipt.SelectedItem.Text == "Overseas Receipt")
                    {
                        str_RptName = "rptCCOSReceipt.rpt";
                        Session["str_sfs"] = "{ACOSReceiptHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.divisionid}=" + Branch_ID + " and {MasterBank.BankName}='" + ddl_bank.SelectedItem.Text + "'";
                    }
                    else if (ddl_receipt.SelectedItem.Text == "Overseas Payment")
                    {
                        str_RptName = "rptCCOSPayment.rpt";
                        Session["str_sfs"] = "{ACOSPaymentHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.divisionid}=" + Branch_ID + " and {MasterBank.BankName}='" + ddl_bank.SelectedItem.Text + "'";
                    }
                    else if (ddl_receipt.SelectedItem.Text == "Bank Receipt Reverse")
                    {
                        str_RptName = "rptCCContra.rpt";
                        Session["str_sfs"] = "{MasterVoucherHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.branchid}=" + Convert.ToInt32(Hid_LoginBranchID.Value) + " and {VoucherDetails.ledgertype}='Cr'  and {MasterVoucherHead.voutype}=104";
                    }
                    else if (ddl_receipt.SelectedItem.Text == "Bank Payment Reverse")
                    {
                        str_RptName = "rptCCContra.rpt";
                        Session["str_sfs"] = "{MasterVoucherHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.branchid}=" + Convert.ToInt32(Hid_LoginBranchID.Value) + " and {VoucherDetails.ledgertype}='Cr'  and {MasterVoucherHead.voutype}=105";
                    }
                    else if (ddl_receipt.SelectedItem.Text == "Manual Bank Payment")
                    {
                        str_RptName = "rptCCContra.rpt";
                        Session["str_sfs"] = "{MasterVoucherHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.branchid}=" + Convert.ToInt32(Hid_LoginBranchID.Value) + " and {VoucherDetails.ledgertype}='Cr'  and {MasterVoucherHead.voutype}=43";
                    }
                    else if (ddl_receipt.SelectedItem.Text == "Manual Bank Receipt")
                    {
                        str_RptName = "rptCCContra.rpt";
                        Session["str_sfs"] = "{MasterVoucherHead.clearedon}=Date(" + clearedon.Year.ToString() + "," + clearedon.Month.ToString() + "," + clearedon.Day.ToString() + ") and {Masterbranch.branchid}=" + Convert.ToInt32(Hid_LoginBranchID.Value) + " and {VoucherDetails.ledgertype}='Cr'  and {MasterVoucherHead.voutype}=41";
                    }
                    else
                    {
                        return;
                    }
                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                    if (Session["str_ModuleName"] == "FA")
                    {
                        obj_da_Log.InsLogDetail(Emp_ID, 1103, 1, Branch_ID, "Mode #: " + ddl_receipt.SelectedItem.Text + "/Cleared Date: " + hid_StrDate.Value + "/V");
                    }
                    else
                    {
                        obj_da_Log.InsLogDetail(Emp_ID, 1223, 1, Branch_ID, "Mode #: " + ddl_receipt.SelectedItem.Text + "/Cleared Date: " + hid_StrDate.Value + "/V");
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Type Can Not Be Empty')", true);
                    ddl_receipt.Focus();
                    return;
                }
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Reset();
                Reset4slip();

            }
            else if (btn_cancel.ToolTip == "Back")
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

        protected void Fn_GetNullRPClearanceDetails()
        {
            DataTable dt_ReceiptClearance = new DataTable();
            DateTime Str_Date = Convert.ToDateTime("3/1/1995");

            //if (ddl_receipt.SelectedValue != "" || ddl_receipt.SelectedValue != "0")
            //{
            //    Type = ddl_receipt.SelectedValue.ToString();
            //}

            if (Type == "R")
            {
                dt_ReceiptClearance = obj_da_Receipt.GetRecptClearanceDetails(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "P")
            {
                dt_ReceiptClearance = Obj_da_Payment.GetPymtClearanceDetails(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "O")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetContraClearanceDetails(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, Chk_Date.Text);
            }
            else if (Type == "X")
            {
                dt_ReceiptClearance = obj_da_Receipt.GetOSRecptClearanceDetails(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "Y")
            {
                dt_ReceiptClearance = Obj_da_Payment.GetOSPymtClearanceDetails(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "Z")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetManRPClearanceDtls(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, "R", Chk_Date.Text);
            }
            else if (Type == "S")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetManRPClearanceDtls(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, "P", Chk_Date.Text);
            }
            else if (Type == "BRR")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetRecRevClearanceDetails(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, Chk_Date.Text);
            }
            else if (Type == "BPR")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetPayRevClearanceDetails(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, Chk_Date.Text);
            }

            //if (Type != "" || Type != "ALL")
            //{
            //    ViewState["Deposit_Clearance"] = null;
            //}

            DataTable dt_Clearance = new DataTable();
            int a = 0;

            //if (ViewState["Deposit_Clearance"] != null && !ViewState["Deposit_Clearance"].Equals("-1"))
            //{
            //    dt_Clearance = (DataTable)ViewState["Deposit_Clearance"];
            //    a = dt_Clearance.Rows.Count;
            //}

            if (dt_ReceiptClearance.Rows.Count > 0)
            {
                if (a == 0)
                {
                    dt_Clearance.Columns.Add("chequeno");
                    dt_Clearance.Columns.Add("chequedate");
                    dt_Clearance.Columns.Add("bank");
                    dt_Clearance.Columns.Add("customername");
                    dt_Clearance.Columns.Add("Amount");
                    dt_Clearance.Columns.Add("Slip #");
                    dt_Clearance.Columns.Add("ClearedOn");
                    dt_Clearance.Columns.Add("shortname");
                    dt_Clearance.Columns.Add("ID");
                }

                for (int i = 0; i <= dt_ReceiptClearance.Rows.Count - 1; i++)
                {
                    DataRow dtrow = dt_Clearance.NewRow();
                    dtrow["chequeno"] = dt_ReceiptClearance.Rows[i]["chequeno"].ToString();
                    dtrow["chequedate"] = dt_ReceiptClearance.Rows[i]["chequedate"].ToString();
                    dtrow["customername"] = dt_ReceiptClearance.Rows[i]["customername"].ToString();
                    dtrow["Amount"] = dt_ReceiptClearance.Rows[i]["amount"].ToString();
                    dtrow["bank"] = dt_ReceiptClearance.Rows[i]["bank"].ToString();

                    if (Type == "R")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["receiptid"].ToString();
                        dtrow["Slip #"] = dt_ReceiptClearance.Rows[i]["slipno"].ToString();
                    }
                    else if (Type == "P")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["paymentid"].ToString();
                    }
                    else if (Type == "X")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["Receiptid"].ToString();
                    }
                    else if (Type == "Y")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["paymentid"].ToString();
                    }
                    else if (Type == "O" || Type == "Z" || Type == "S" || Type == "BRR" | Type == "BPR")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["vouid"].ToString();
                    }


                    dtrow["ClearedOn"] = dt_ReceiptClearance.Rows[i]["ClearedOn"].ToString();
                    dtrow["shortname"] = dt_ReceiptClearance.Rows[i]["shortname"].ToString();

                    dt_Clearance.Rows.Add(dtrow);
                }
                Grd_DepositSlip.DataSource = dt_Clearance;
                Grd_DepositSlip.DataBind();
                ViewState["Deposit_Clearance"] = dt_Clearance;
                ViewState["ddl_type"] = Type;

                //foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                //{
                //    CheckBox Chk = (CheckBox)Row.FindControl("Chk_Select");
                //    Chk.Checked = true;
                //    //Total = Total + Convert.ToDouble(Row.Cells[4].Text);
                //    if (Row.Cells[4].Text != "")
                //    {
                //        Total = Total + Convert.ToDouble(Row.Cells[4].Text);
                //    }    
                //    Session["Amount"] = Total;
                //}
                //txt_total.Text = Total.ToString();      
            }
            else
            {
                //Grd_DepositSlip.DataSource = new DataTable();
                //Grd_DepositSlip.DataBind();
            }
        }

        protected void Fn_GetNotNullRPClearanceDetails()
        {
            DataTable dt_ReceiptClearance = new DataTable();
            DateTime Str_Date = Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value));

            if (ddl_receipt.SelectedValue != "" || ddl_receipt.SelectedValue != "0")
            {
                Type = ddl_receipt.SelectedValue.ToString();
            }



            if (Type == "R")
            {
                dt_ReceiptClearance = obj_da_Receipt.GetRecptClearanceDetails(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "P")
            {
                dt_ReceiptClearance = Obj_da_Payment.GetPymtClearanceDetails(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "O")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetContraClearanceDetails(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, Chk_Date.Text);
            }
            else if (Type == "X")
            {
                dt_ReceiptClearance = obj_da_Receipt.GetOSRecptClearanceDetails(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "Y")
            {
                dt_ReceiptClearance = Obj_da_Payment.GetOSPymtClearanceDetails(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "Z")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetManRPClearanceDtls(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, "R", Chk_Date.Text);
            }
            else if (Type == "S")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetManRPClearanceDtls(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, "P", Chk_Date.Text);
            }
            else if (Type == "BRR")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetRecRevClearanceDetails(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, Chk_Date.Text);
            }
            else if (Type == "BPR")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetPayRevClearanceDetails(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, Chk_Date.Text);
            }

            //if (Type != "" || Type != "ALL")
            //{
            //    ViewState["Deposit_Clearance"] = null;
            //}

            DataTable dt_Clearance = new DataTable();
            int a = 0;

            //if (ViewState["Deposit_Clearance"] != null && !ViewState["Deposit_Clearance"].Equals("-1"))
            //{
            //    dt_Clearance = (DataTable)ViewState["Deposit_Clearance"];
            //    a = dt_Clearance.Rows.Count;
            //}

            if (dt_ReceiptClearance.Rows.Count > 0)
            {
                if (a == 0)
                {
                    dt_Clearance.Columns.Add("chequeno");
                    dt_Clearance.Columns.Add("chequedate");
                    dt_Clearance.Columns.Add("bank");
                    dt_Clearance.Columns.Add("customername");
                    dt_Clearance.Columns.Add("Amount");
                    dt_Clearance.Columns.Add("Slip #");
                    dt_Clearance.Columns.Add("ClearedOn");
                    dt_Clearance.Columns.Add("shortname");
                    dt_Clearance.Columns.Add("ID");
                }

                for (int i = 0; i <= dt_ReceiptClearance.Rows.Count - 1; i++)
                {
                    DataRow dtrow = dt_Clearance.NewRow();
                    dtrow["chequeno"] = dt_ReceiptClearance.Rows[i]["chequeno"].ToString();
                    dtrow["chequedate"] = dt_ReceiptClearance.Rows[i]["chequedate"].ToString();
                    dtrow["customername"] = dt_ReceiptClearance.Rows[i]["customername"].ToString();
                    dtrow["Amount"] = dt_ReceiptClearance.Rows[i]["amount"].ToString();
                    dtrow["bank"] = dt_ReceiptClearance.Rows[i]["bank"].ToString();
                    dtrow["ClearedOn"] = dt_ReceiptClearance.Rows[i]["ClearedOn"].ToString();
                    dtrow["Slip #"] = "";

                    if (Type == "R")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["receiptid"].ToString();
                        dtrow["Slip #"] = dt_ReceiptClearance.Rows[i]["slipno"].ToString();
                    }
                    if (Type == "P")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["paymentid"].ToString();
                    }
                    if (Type == "X")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["Receiptid"].ToString();
                    }
                    if (Type == "Y")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["paymentid"].ToString();
                    }
                    if (Type == "O" || Type == "Z" || Type == "S" || Type == "BRR" || Type == "BPR")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["vouid"].ToString();
                    }

                    dtrow["shortname"] = dt_ReceiptClearance.Rows[i]["shortname"].ToString();
                    dt_Clearance.Rows.Add(dtrow);
                }

                Grd_DepositSlip.DataSource = dt_Clearance;
                Grd_DepositSlip.DataBind();
                ViewState["Deposit_Clearance"] = dt_Clearance;
                ViewState["ddl_type"] = Type;
                Total = 0;
                foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                {
                    CheckBox Chk = (CheckBox)Row.FindControl("Chk_Select");

                    if (Row.Cells[7].Text != "")
                    {
                        Chk.Checked = true;
                    }

                    if (Row.Cells[4].Text != "")
                    {
                        if (Chk.Checked == true)
                        {
                            Total = Total + Convert.ToDouble(Row.Cells[4].Text);
                        }
                    }
                }
                Session["Amount"] = Total;
                txt_total.Text = string.Format("{0:#,##0.00}", Total); //Total.ToString();
            }
        }

        protected void Fn_GetNotNullRPClearanceDetails4Bank()
        {
            DataTable dt_ReceiptClearance = new DataTable();
            DateTime Str_Date = Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value));

            if (Type == "R")
            {
                dt_ReceiptClearance = obj_da_Receipt.GetRecptClearanceDetails4Bank(Branch_ID, Str_Date, ddl_bank.SelectedItem.ToString(), Chk_Date.Text);
            }
            else if (Type == "P")
            {
                dt_ReceiptClearance = Obj_da_Payment.GetPymtClearanceDetails4Bank(Branch_ID, Str_Date, ddl_bank.SelectedItem.ToString(), Chk_Date.Text);
            }
            else if (Type == "O")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetContraClearanceDetails(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, Chk_Date.Text);
            }
            else if (Type == "X")
            {
                dt_ReceiptClearance = obj_da_Receipt.GetOSRecptClearanceDetails4Bank(Branch_ID, Str_Date, Chk_Date.Text);
            }
            else if (Type == "Y")
            {
                dt_ReceiptClearance = Obj_da_Payment.GetOSPymtClearanceDetails4Bank(Branch_ID, Str_Date, Chk_Date.Text);
            }

            DataTable dt_Clearance = new DataTable();
            int a = 0;

            if (ViewState["Deposit_SlipDet"] != null && !ViewState["Deposit_SlipDet"].Equals("-1"))
            {
                dt_Clearance = (DataTable)ViewState["Deposit_SlipDet"];
                a = dt_Clearance.Rows.Count;
            }

            if (dt_ReceiptClearance.Rows.Count > 0)
            {
                if (a == 0)
                {
                    dt_Clearance.Columns.Add("chequeno");
                    dt_Clearance.Columns.Add("chequedate");
                    dt_Clearance.Columns.Add("bank");
                    dt_Clearance.Columns.Add("customername");
                    dt_Clearance.Columns.Add("Amount");
                    dt_Clearance.Columns.Add("Slip #");
                    dt_Clearance.Columns.Add("ClearedOn");
                    dt_Clearance.Columns.Add("shortname");
                    dt_Clearance.Columns.Add("ID");
                }

                for (int i = 0; i <= dt_ReceiptClearance.Rows.Count - 1; i++)
                {
                    DataRow dtrow = dt_Clearance.NewRow();
                    dtrow["chequeno"] = dt_ReceiptClearance.Rows[i]["chequeno"].ToString();
                    dtrow["chequedate"] = dt_ReceiptClearance.Rows[i]["chequedate"].ToString();
                    dtrow["customername"] = dt_ReceiptClearance.Rows[i]["customername"].ToString();
                    dtrow["Amount"] = dt_ReceiptClearance.Rows[i]["amount"].ToString();
                    dtrow["bank"] = dt_ReceiptClearance.Rows[i]["bank"].ToString();
                    dtrow["ClearedOn"] = dt_ReceiptClearance.Rows[i]["ClearedOn"].ToString();
                    dtrow["Slip #"] = "";

                    if (Type == "R")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["receiptid"].ToString();
                        dtrow["Slip #"] = dt_ReceiptClearance.Rows[i]["slipno"].ToString();
                    }
                    else if (Type == "P")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["paymentid"].ToString();
                    }
                    else if (Type == "X")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["receiptid"].ToString();
                    }
                    else if (Type == "Y")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["paymentid"].ToString();
                    }
                    else if (Type == "O")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["vouid"].ToString();
                    }

                    dtrow["shortname"] = dt_ReceiptClearance.Rows[i]["shortname"].ToString();
                    dt_Clearance.Rows.Add(dtrow);
                }

                Grd_DepositSlip.DataSource = dt_Clearance;
                Grd_DepositSlip.DataBind();
                ViewState["Deposit_SlipDet"] = dt_Clearance;
                ViewState["ddl_type"] = Type;
                Total = 0;
                foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                {
                    CheckBox Chk = (CheckBox)Row.FindControl("Chk_Select");

                    if (Row.Cells[7].Text.Replace("&nbsp;", "") != "")
                    {
                        Chk.Checked = true;
                    }

                    if (Row.Cells[4].Text != "")
                    {
                        if (Chk.Checked == true)
                        {
                            Total = Total + Convert.ToDouble(Row.Cells[4].Text);
                        }
                    }
                }
                Session["Amount"] = Total;
                txt_total.Text = string.Format("{0:#,##0.00}", Total); //Total.ToString();
            }
            else
            {
                //Grd_DepositSlip.DataSource = new DataTable();
                //Grd_DepositSlip.DataBind();
            }
        }

        protected void Fn_GetNullRPClearanceDetails4bank()
        {
            DataTable dt_ReceiptClearance = new DataTable();
            DateTime Str_Date = Convert.ToDateTime("3/1/1995");

            //if (ddl_receipt.SelectedValue != "" || ddl_receipt.SelectedValue != "0")
            //{
            //    Type = ddl_receipt.SelectedValue.ToString();
            //}

            if (Type == "R")
            {
                dt_ReceiptClearance = obj_da_Receipt.GetRecptClearanceDetails4Bank(Branch_ID, Str_Date, ddl_bank.SelectedItem.ToString(), Chk_Date.Text);
            }
            else if (Type == "P")
            {
                dt_ReceiptClearance = Obj_da_Payment.GetPymtClearanceDetails4Bank(Branch_ID, Str_Date, ddl_bank.SelectedItem.ToString(), Chk_Date.Text);
            }
            else if (Type == "O")
            {
                dt_ReceiptClearance = obj_da_FA_Voucher.GetContraClearanceDetails(Convert.ToInt32(Hid_LoginBranchID.Value), DB_Name, Str_Date, Chk_Date.Text);
            }
            else if (Type == "X")
            {
                dt_ReceiptClearance = obj_da_Receipt.GetOSRecptClearanceDetails4Bank(Branch_ID, Str_Date, ddl_bank.SelectedItem.ToString());
            }
            else if (Type == "Y")
            {
                dt_ReceiptClearance = Obj_da_Payment.GetOSPymtClearanceDetails4Bank(Branch_ID, Str_Date, ddl_bank.SelectedItem.ToString());
            }

            DataTable dt_Clearance = new DataTable();
            int a = 0;

            if (ViewState["Deposit_SlipDet"] != null && !ViewState["Deposit_SlipDet"].Equals("-1"))
            {
                dt_Clearance = (DataTable)ViewState["Deposit_SlipDet"];
                a = dt_Clearance.Rows.Count;
            }

            if (dt_ReceiptClearance.Rows.Count > 0)
            {
                if (a == 0)
                {
                    dt_Clearance.Columns.Add("chequeno");
                    dt_Clearance.Columns.Add("chequedate");
                    dt_Clearance.Columns.Add("bank");
                    dt_Clearance.Columns.Add("customername");
                    dt_Clearance.Columns.Add("Amount");
                    dt_Clearance.Columns.Add("Slip #");
                    dt_Clearance.Columns.Add("ClearedOn");
                    dt_Clearance.Columns.Add("shortname");
                    dt_Clearance.Columns.Add("ID");
                }

                for (int i = 0; i <= dt_ReceiptClearance.Rows.Count - 1; i++)
                {
                    DataRow dtrow = dt_Clearance.NewRow();
                    dtrow["chequeno"] = dt_ReceiptClearance.Rows[i]["chequeno"].ToString();
                    dtrow["chequedate"] = dt_ReceiptClearance.Rows[i]["chequedate"].ToString();
                    dtrow["customername"] = dt_ReceiptClearance.Rows[i]["customername"].ToString();
                    dtrow["Amount"] = dt_ReceiptClearance.Rows[i]["amount"].ToString();
                    dtrow["bank"] = dt_ReceiptClearance.Rows[i]["bank"].ToString();
                    dtrow["ClearedOn"] = dt_ReceiptClearance.Rows[i]["ClearedOn"].ToString();
                    dtrow["Slip #"] = "";

                    if (Type == "R")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["receiptid"].ToString();
                        dtrow["Slip #"] = dt_ReceiptClearance.Rows[i]["slipno"].ToString();
                    }
                    if (Type == "P")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["paymentid"].ToString();
                    }
                    if (Type == "X")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["receiptid"].ToString();
                    }
                    if (Type == "Y")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["paymentid"].ToString();
                    }
                    if (Type == "O")
                    {
                        dtrow["ID"] = dt_ReceiptClearance.Rows[i]["vouid"].ToString();
                    }

                    dtrow["shortname"] = dt_ReceiptClearance.Rows[i]["shortname"].ToString();
                    dt_Clearance.Rows.Add(dtrow);
                }

                Grd_DepositSlip.DataSource = dt_Clearance;
                Grd_DepositSlip.DataBind();
                ViewState["Deposit_SlipDet"] = dt_Clearance;
                ViewState["ddl_type"] = Type;
                Total = 0;
                foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                {
                    CheckBox Chk = (CheckBox)Row.FindControl("Chk_Select");

                    if (Row.Cells[7].Text.Replace("&nbsp;", "") != "")
                    {
                        Chk.Checked = true;
                    }

                    if (Row.Cells[4].Text != "")
                    {
                        if (Chk.Checked == true)
                        {
                            Total = Total + Convert.ToDouble(Row.Cells[4].Text);
                        }
                    }
                }
                Session["Amount"] = Total;
                txt_total.Text = string.Format("{0:#,##0.00}", Total); //Total.ToString();
            }
            else
            {
                //Grd_DepositSlip.DataSource = new DataTable();
                //Grd_DepositSlip.DataBind();
            }
        }

        protected void Fn_BRS_OurBook()
        {
            int LedgerID;
            DataSet ds;
            DataTable Dt_Rec = new DataTable();
            double debit = 0, credit = 0, dbl_P = 0, dbl_R = 0, dbl_X = 0, dbl_Y = 0, dbl_O = 0, dbl_O_CR = 0, dbl_O_DR = 0, dbl_A = 0, dbl_B = 0, dbl_BPR = 0, dbl_BRR = 0;

            LedgerID = Convert.ToInt32(ddl_bank.SelectedValue);
            ds = Obj_Ledger.GetCrandDBfromLedger(Convert.ToInt32(Hid_LoginBranchID.Value), Division_ID, DB_Name, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), LedgerID, "INR");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["debit"].ToString().Length == 0)
                {
                    debit = 0;
                }
                else
                {
                    debit = Convert.ToDouble(string.Format("{0:#,##0.00}", ds.Tables[0].Rows[0]["debit"]));
                }
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["credit"].ToString().Length == 0)
                {
                    credit = 0;
                }
                else
                {
                    credit = Convert.ToDouble(string.Format("{0:#,##0.00}", ds.Tables[1].Rows[0]["credit"]));
                }
            }

            txt_Book.Text = string.Format("{0:#,##0.00}", (debit - credit));

            Dt_Rec = Obj_Ledger.GetreceiptamountfromHead(Division_ID, VouYear, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), ddl_bank.SelectedItem.ToString());

            if (Dt_Rec.Rows.Count > 0)
            {
                if (Dt_Rec.Rows[0]["ramount"].ToString().Length > 0)
                {
                    dbl_R = Convert.ToDouble(Dt_Rec.Rows[0]["ramount"].ToString());
                }

                DataTable dt1 = new DataTable();
                dt1 = obj_da_Receipt.GetTOTOSRecptClearanceDetails4BRS(Division_ID, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), ddl_bank.SelectedItem.ToString(), "USD");
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["amount"].ToString().Length > 0)
                    {
                        dbl_X = Convert.ToDouble(dt1.Rows[0]["amount"].ToString());
                    }
                }

                dt1 = obj_da_FA_Voucher.GetManRPClearanceDBTtoal(Division_ID, DB_Name, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), LedgerID, "R");
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["Total"].ToString().Length == 0)
                    {
                        dbl_A = 0;
                    }
                    else
                    {
                        dbl_A = Convert.ToDouble(dt1.Rows[0]["Total"].ToString());
                    }
                }

                dt1 = obj_da_FA_Voucher.GetContraClearanceDBTtoal(Division_ID, DB_Name, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), LedgerID, "BRR");

                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["Total"].ToString().Length == 0)
                    {
                        dbl_BRR = 0;
                    }
                    else
                    {
                        dbl_BRR = Convert.ToDouble(dt1.Rows[0]["Total"].ToString());
                    }
                }

                dt1 = obj_da_FA_Voucher.GetContraClearanceDBTtoal(Division_ID, DB_Name, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), LedgerID, "Contra");

                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["Total"].ToString().Length == 0)
                    {
                        dbl_O_DR = 0;
                    }
                    else
                    {
                        dbl_O_DR = Convert.ToDouble(dt1.Rows[0]["Total"].ToString());
                    }
                }

                txtreceipt.Text = (dbl_R + dbl_X + dbl_A + dbl_BRR + dbl_O_DR).ToString();

                dt1 = Obj_Ledger.GetPaymentamountfromHead(Division_ID, VouYear, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), ddl_bank.SelectedItem.ToString());
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["pamount"].ToString().Length == 0)
                    {
                        dbl_P = 0;
                    }
                    else
                    {
                        dbl_P = Convert.ToDouble(dt1.Rows[0]["pamount"].ToString());
                    }
                }

                dt1 = Obj_da_Payment.GetTOTOSPymtClearanceDetails4BRS(Division_ID, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), ddl_bank.SelectedItem.ToString(), "USD");
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["amount"].ToString().Length == 0)
                    {
                        dbl_Y = 0;
                    }
                    else
                    {
                        dbl_Y = Convert.ToDouble(dt1.Rows[0]["amount"].ToString());
                    }
                }

                dt1 = obj_da_FA_Voucher.GetManRPClearanceDBTtoal(Division_ID, DB_Name, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), LedgerID, "P");
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["Total"].ToString().Length == 0)
                    {
                        dbl_B = 0;
                    }
                    else
                    {
                        dbl_B = Convert.ToDouble(dt1.Rows[0]["Total"].ToString());
                    }
                }

                dt1 = obj_da_FA_Voucher.GetContraClearanceTtoal(Division_ID, DB_Name, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), LedgerID, "BPR");
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["Total"].ToString().Length == 0)
                    {
                        dbl_BPR = 0;
                    }
                    else
                    {
                        dbl_BPR = Convert.ToDouble(dt1.Rows[0]["Total"].ToString());
                    }
                }

                dt1 = obj_da_FA_Voucher.GetContraClearanceTtoal(Division_ID, DB_Name, Convert.ToDateTime(Utility.fn_ConvertDate(hid_StrDate.Value)), LedgerID, "Contra");
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["Total"].ToString().Length == 0)
                    {
                        dbl_O_CR = 0;
                    }
                    else
                    {
                        dbl_O_CR = Convert.ToDouble(dt1.Rows[0]["Total"].ToString());
                    }
                }

                txtpayment.Text = (dbl_P + dbl_Y + dbl_B + dbl_BPR + dbl_O_CR).ToString();

                CalAmount();
            }
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            if (txt_total.Text == "")
            {
                txt_total.Text = "0.00";
            }

            if (ddl_type.SelectedValue != "")
            {
                GetDetails(ddl_type.SelectedItem.ToString());
            }
        }

        protected void GetPayRecType(string Str_Type)
        {
            str_cmbtype = Str_Type;

            if (Str_Type == "Cash")
            {
                Type = "C";
            }
            else if (Str_Type == "Bank")
            {
                Type = "B";
            }
            else if (Str_Type == "Receipts")
            {
                Type = "R";
            }
            else if (Str_Type == "Payments")
            {
                Type = "P";
            }
            else if (Str_Type == "Contra")
            {
                Type = "O";
            }
            else if (Str_Type == "Overseas Receipt")
            {
                Type = "X";
            }
            else if (Str_Type == "Overseas Payment")
            {
                Type = "Y";
            }
            else if (Str_Type == "Manual Bank Receipt")
            {
                Type = "Z";
            }
            else if (Str_Type == "Manual Bank Payment")
            {
                Type = "S";
            }
        }

        protected void GetDetails(string Str_Type)
        {
            try
            {
                str_cmbtype = Str_Type;

                if (Str_Type == "Cash")
                {
                    Type = "C";
                    Fn_GetNullSlipDetails();
                }
                else if (Str_Type == "Bank")
                {
                    Type = "B";
                    Fn_GetNullSlipDetails();
                }
                else if (Str_Type == "Receipts")
                {
                    Type = "R";
                    Fn_GetNullRPClearanceDetails();
                    txt_slip_cheque.Enabled = true;
                }
                else if (Str_Type == "Payments")
                {
                    Type = "P";
                    Fn_GetNullRPClearanceDetails();
                }
                else if (Str_Type == "Contra")
                {
                    Type = "O";
                    Fn_GetNullRPClearanceDetails();
                }
                else if (Str_Type == "Overseas Receipt")
                {
                    Type = "X";
                    Fn_GetNullRPClearanceDetails();
                }
                else if (Str_Type == "Overseas Payment")
                {
                    Type = "Y";
                    Fn_GetNullRPClearanceDetails();
                }
                else if (Str_Type == "Manual Bank Receipt")
                {
                    Type = "Z";
                    Fn_GetNullRPClearanceDetails();
                }
                else if (Str_Type == "Manual Bank Payment")
                {
                    Type = "S";
                    Fn_GetNullRPClearanceDetails();
                }
                else if (Str_Type == "Bank Receipt Reverse")
                {
                    Type = "BRR";
                    Fn_GetNullRPClearanceDetails();
                }
                else if (Str_Type == "Bank Payment Reverse")
                {
                    Type = "BPR";
                    Fn_GetNullRPClearanceDetails();
                }
                else
                {
                    Grd_DepositSlip.DataSource = new DataTable();
                    Grd_DepositSlip.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void Chk_Date_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Date.Checked == true)
            {
                Equal.Visible = false;
                Chk_Date.Text = "=";
            }
            else
            {
                Equal.Visible = false;
                Chk_Date.Text = ">";
            }
        }

        protected void ddl_receipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                grdContra.DataSource = Utility.Fn_GetEmptyDataTable();
                grdContra.DataBind();
                grdPayment.DataSource = Utility.Fn_GetEmptyDataTable();
                grdPayment.DataBind();
                GrdReceipt.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdReceipt.DataBind();
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

                if (lbl_Header.Text == "Cheque Clearance")
                {
                    ddl_bank.SelectedIndex = 0;
                }

                ViewState["Deposit_Clearance"] = null;

                //Raja
                txt_Book.Text = "0.00";
                txt_BRSBank.Text = "0.00";
                //RAJ
                txtreceipt_brs.Text = "0.00";
                txt_Receipt.Text = "0.00";
                txttotal.Text = "0.00";
                txtpayment_brs.Text = "0.00";
                txtCBNB_brs.Text = "0.00";
                txt_contraDB.Text = "0.00";
                txttotal_balance.Text = "0.00";
                txttotal2.Text = "0.00";
                txtDBNB_brs.Text = "0.00";
                txtbank.Text = "0.00";
                // Raja hide
                //if (txt_Book.Text == "")
                //{
                //    txt_Book.Text = "0.00";
                //}
                //if (txt_BRSBank.Text == "")
                //{
                //    txt_BRSBank.Text = "0.00";
                //}

                txt_slip_cheque.Enabled = false;
                txt_cheque.Enabled = true;
                btn_save.Enabled = true;
                txt_cheque.Text = "";
                txt_slip.Text = "";
                txt_slip_cheque.Text = "";

                if (txt_total.Text == "")
                {
                    txt_total.Text = "0.00";
                }

                if (ddl_receipt.SelectedItem.Text == "ALL")
                {
                    string text, value;
                    var items = ddl_receipt.Items;
                    foreach (var item in items.Cast<ListItem>().Where(Item => Item.Value != ""))
                    {
                        text = item.Text;
                        value = item.Value;
                        //GetPayRecType(text.ToString());      
                        GetDetails(text.ToString());
                        txt_cheque.Enabled = false;
                        txt_slip_cheque.Enabled = false;
                        btn_save.Enabled = false;
                    }
                }
                else
                {
                    GetDetails(ddl_receipt.SelectedItem.Text.ToString());
                    if (ddl_bank.SelectedIndex != 0)
                    {
                        fn_brs();
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void ddl_bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                ViewState["Deposit_SlipDet"] = null;
                Grd_DepositSlip.DataSource = new DataTable();
                Grd_DepositSlip.DataBind();
                grdContra.DataSource = Utility.Fn_GetEmptyDataTable();
                grdContra.DataBind();
                grdPayment.DataSource = Utility.Fn_GetEmptyDataTable();
                grdPayment.DataBind();
                GrdReceipt.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdReceipt.DataBind();

                if (hid_bankid.Value == ddl_bank.SelectedValue)
                {
                    ViewState["Deposit_SlipDet"] = null;
                }

                ViewState["Deposit_Clearance"] = null;

                if (txt_total.Text == "")
                {
                    txt_total.Text = "0.00";
                }
                //Raja
                txt_Book.Text = "0.00";
                txt_BRSBank.Text = "0.00";

                Chk_Date_CheckedChanged(sender, e);

                if (ddl_bank.SelectedValue == "0" || ddl_bank.SelectedValue == "")
                {
                    if (ddl_receipt.SelectedItem.Text == "ALL")
                    {
                        var items = ddl_receipt.Items;
                        foreach (var item in items.Cast<ListItem>().Where(Item => Item.Value != ""))
                        {
                            string text = item.Text;
                            string value = item.Value;

                            GetPayRecType(text.ToString());
                            Fn_GetNotNullRPClearanceDetails();

                            if (Chk_Date.Text != "=")
                            {
                                Fn_GetNullRPClearanceDetails();
                            }

                            if (txt_Book.Text == "")
                            {
                                txt_Book.Text = "0.00";
                            }
                            if (txt_BRSBank.Text == "")
                            {
                                txt_BRSBank.Text = "0.00";
                            }
                        }
                    }
                    else
                    {
                        Fn_GetNotNullRPClearanceDetails();
                        if (Chk_Date.Text != "=")
                        {
                            Fn_GetNullRPClearanceDetails();
                        }
                    }
                }
                else
                {
                    hid_bankid.Value = ddl_bank.SelectedValue;
                    if (ddl_receipt.SelectedItem.Text == "ALL")
                    {
                        var items = ddl_receipt.Items;
                        foreach (var item in items.Cast<ListItem>().Where(Item => Item.Value != ""))
                        {
                            string text = item.Text;
                            string value = item.Value;

                            GetPayRecType(text.ToString());
                            Fn_GetNotNullRPClearanceDetails4Bank();
                            Fn_GetNullRPClearanceDetails4bank();
                        }
                    }
                    else
                    {
                        //----Karthika_K
                        ViewState["Deposit_SlipDet"] = null;

                        if (ddl_receipt.SelectedValue != "" || ddl_receipt.SelectedValue != "0")
                        {
                            Type = ddl_receipt.SelectedValue.ToString();
                        }

                        Fn_GetNotNullRPClearanceDetails4Bank();
                        Fn_GetNullRPClearanceDetails4bank();
                        Fn_BRS_OurBook();
                    }
                }

                if (Grd_DepositSlip.Rows.Count == 0)
                {
                    Grd_DepositSlip.DataSource = new DataTable();
                    Grd_DepositSlip.DataBind();
                }
                if (ddl_bank.SelectedIndex != 0)
                {
                    fn_brs();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void fn_brs()
        {
            if (ddl_bank.SelectedValue != "0" || ddl_bank.SelectedValue != "")
            {
                if (hid_bankid.Value != "" && hid_bankid.Value != "0")
                {
                    DataSet ds;


                    if (chkc.Checked == true)
                    {
                        curtype = "USD";
                    }
                    else
                    {
                        curtype = "INR";
                    }

                    ledgerid = Convert.ToInt32(ddl_bank.SelectedValue.ToString());

                    ds = ledobj.GetCrandDBfromLedger(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ledgerid, curtype);
                    debit = 0;
                    grdContra.DataSource = null;
                    grdContra.DataBind();

                    GrdReceipt.DataSource = null;
                    GrdReceipt.DataBind();
                    grdPayment.DataSource = null;
                    grdPayment.DataBind();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["debit"].ToString().Length == 0)
                        {
                            debit = 0;
                        }
                        else
                        {
                            debit = Convert.ToDouble(ds.Tables[0].Rows[0]["debit"]);
                        }
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows[0]["credit"].ToString().Length == 0)
                        {
                            credit = 0;
                        }
                        else
                        {
                            credit = Convert.ToDouble(ds.Tables[1].Rows[0]["credit"]);
                        }
                    }

                    if (debit > 0 || credit > 0)
                    {
                        txtbook.Text = string.Format("{0:#,##0.00}", (debit - credit));
                    }
                    else
                    {
                        txtbook.Text = "0.00";
                    }

                    lbl_balance_chq.Focus();
                    dbl_R = 0;
                    dbl_P = 0;
                    dbl_X = 0;
                    dbl_Y = 0;
                    dbl_O = 0;
                    dbl_O_CR = 0;
                    dbl_O_DR = 0;
                    dbl_A = 0;
                    dbl_B = 0;
                    dbl_BPR = 0;
                    dbl_BRR = 0;

                    type = "P";//Payment
                    GetNullRPClearanceDetails();

                    type = "R"; //'Receipt;
                    GetNullRPClearanceDetails();
                    type = "X"; //OS Receipt;
                    GetNullRPClearanceDetails();
                    type = "Y"; //OS Payment;
                    GetNullRPClearanceDetails();
                    type = "O"; //Contra;
                    GetNullRPClearanceDetails();
                    type = "A"; //Manual Receip;
                    GetNullRPClearanceDetails();
                    type = "B"; // Manual Payment;
                    GetNullRPClearanceDetails();
                    type = "BRR";
                    GetNullRPClearanceDetails();
                    type = "BPR";
                    GetNullRPClearanceDetails();

                    GrdReceipt.DataSource = dtrec;
                    GrdReceipt.DataBind();

                    grdPayment.DataSource = dtpay;
                    grdPayment.DataBind();
                    if (curtype == "USD")
                    {
                        txtreceipt_brs.Text = string.Format("{0:#,##0.00}", (dbl_R + dbl_X + dbl_A + dbl_BRR + dbl_O_DR));
                        txtpayment_brs.Text = string.Format("{0:#,##0.00}", (dbl_P + dbl_Y + dbl_B + dbl_BPR + dbl_O_CR));
                        txttotal.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(txtbook.Text) - Convert.ToDouble(txtreceipt_brs.Text)));
                        txttotal_balance.Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtpayment_brs.Text)));

                    }
                    else
                    {
                        txtreceipt_brs.Text = string.Format("{0:#,#0.00}", (dbl_R + dbl_X + dbl_A + dbl_BRR + dbl_O_DR));
                        txtpayment_brs.Text = string.Format("{0:#,#0.00}", (dbl_P + dbl_Y + dbl_B + dbl_BPR + dbl_O_CR));
                        txttotal.Text = string.Format("{0:#,#0.00}", (Convert.ToDouble(txtbook.Text) - Convert.ToDouble(txtreceipt_brs.Text)));
                        txttotal_balance.Text = string.Format("{0:#,#0.00}", (Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtpayment_brs.Text)));

                    }
                    CalAmount_brs();

                    if (Convert.ToDouble(txt_Book.Text) < 0)
                    {
                        lblourbook.Text = "Cr";
                        txt_Book.Text = txt_Book.Text.Remove(0, 1);
                    }
                    else
                    {
                        lblourbook.Text = "Dr";
                    }

                    if (Convert.ToDouble(txttotal.Text) < 0)
                    {
                        lbltolcr.Text = "Cr";
                        txttotal.Text = txttotal.Text.Remove(0, 1);
                    }
                    else
                    {
                        lbltolcr.Text = "Dr";
                    }

                    if (Convert.ToDouble(txttotal_balance.Text) < 0)
                    {
                        Lbl3.Text = "Cr";
                        txttotal_balance.Text = txttotal_balance.Text.Remove(0, 1);
                    }
                    else
                    {
                        Lbl3.Text = "Dr";
                    }

                    if (Convert.ToDouble(txttotal2.Text) < 0)
                    {
                        lbl5.Text = "Cr";
                        txttotal2.Text = txttotal2.Text.Remove(0, 1);
                    }
                    else
                    {
                        lbl5.Text = "Dr";
                    }

                    if (Convert.ToDouble(txtbank.Text) < 0)
                    {
                        lblperbank.Text = "Cr";
                        txtbank.Text = txtbank.Text.Remove(0, 1);
                    }
                    else
                    {
                        lblperbank.Text = "Dr";
                    }

                    Lbl3.Text = lbltolcr.Text;
                    lbl5.Text = lblperbank.Text;

                    if (txtreceipt_brs.Text == "")
                    {
                        txtreceipt_brs.Text = "0.00";
                    }
                    if (txtpayment_brs.Text == "")
                    {
                        txtpayment_brs.Text = "0.00";
                    }
                    if (txt_Book.Text == "")
                    {
                        txt_Book.Text = "0.00";
                    }
                    if (txtDBNB_brs.Text == "")
                    {
                        txtDBNB_brs.Text = "0.00";
                    }
                    if (txtCBNB_brs.Text == "")
                    {
                        txtCBNB_brs.Text = "0.00";
                    }
                }
            }
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                Total = 0.00;

                if (ddl_receipt.SelectedValue == "0")
                {
                    var items = ddl_receipt.Items;

                    foreach (var item in items.Cast<ListItem>().Where(Item => Item.Value != ""))
                    {
                        string text = item.Text;
                        string value = item.Value;

                        GetPayRecType(text.ToString());
                        Fn_GetNotNullRPClearanceDetails();

                        if (Chk_Date.Text != "=")
                        {
                            Fn_GetNullRPClearanceDetails();
                        }
                    }
                }
                else
                {
                    Fn_GetNotNullRPClearanceDetails();
                    if (Chk_Date.Text != "=")
                    {
                        Fn_GetNullRPClearanceDetails();
                    }
                }

                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    obj_da_Log.InsLogDetail(Emp_ID, 1103, 1, Branch_ID, "Mode #: " + ddl_receipt.SelectedItem.Text.ToString() + "/Cleared Date: " + hid_StrDate.Value + "/Get");
                }
                else
                {
                    obj_da_Log.InsLogDetail(Emp_ID, 1223, 1, Branch_ID, "Mode #: " + ddl_receipt.SelectedItem.Text.ToString() + "/Cleared Date: " + hid_StrDate.Value + "/Get");
                }

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_cheque_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (ViewState["ddl_type"] != null)
                {
                    Type = ViewState["ddl_type"].ToString();
                }

                if (txt_cheque.Text != "")
                {
                    if (Type == "R")
                    {
                        dt = obj_da_Receipt.GetRecptClearance4chq(Branch_ID, txt_cheque.Text.ToString(), "C");
                    }
                    else if (Type == "P")
                    {
                        dt = Obj_da_Payment.GetPymtClearance4Chq(Branch_ID, txt_cheque.Text);
                    }
                    else if (Type == "O")
                    {
                        dt = obj_da_FA_Voucher.GetContraClearance4Chq(Branch_ID, DB_Name, txt_cheque.Text);
                    }

                    DataTable dt_Clearance = new DataTable();
                    int a = 0;

                    //if (ViewState["Deposit_Clearance"] != null && !ViewState["Deposit_Clearance"].Equals("-1"))
                    //{
                    //    dt_Clearance = (DataTable)ViewState["Deposit_Clearance"];
                    //    a = dt_Clearance.Rows.Count;
                    //}

                    if (dt.Rows.Count > 0)
                    {
                        //if (a == 0)
                        //{
                        dt_Clearance.Columns.Add("chequeno");
                        dt_Clearance.Columns.Add("chequedate");
                        dt_Clearance.Columns.Add("bank");
                        dt_Clearance.Columns.Add("customername");
                        dt_Clearance.Columns.Add("Amount");
                        dt_Clearance.Columns.Add("Slip #");
                        dt_Clearance.Columns.Add("ClearedOn");
                        dt_Clearance.Columns.Add("shortname");
                        dt_Clearance.Columns.Add("ID");
                        //}

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            DataRow dtrow = dt_Clearance.NewRow();
                            dtrow["chequeno"] = dt.Rows[i]["chequeno"].ToString();
                            dtrow["chequedate"] = dt.Rows[i]["chequedate"].ToString();
                            dtrow["customername"] = dt.Rows[i]["customername"].ToString();
                            dtrow["Amount"] = dt.Rows[i]["amount"].ToString();
                            dtrow["bank"] = dt.Rows[i]["bank"].ToString();
                            dtrow["shortname"] = dt.Rows[i]["shortname"].ToString();
                            dtrow["Slip #"] = "";
                            dtrow["ClearedOn"] = dt.Rows[i]["clearedon"].ToString();

                            if (Type == "R")
                            {
                                dtrow["ID"] = dt.Rows[i]["receiptid"].ToString();
                            }
                            else if (Type == "P")
                            {
                                dtrow["ID"] = dt.Rows[i]["paymentid"].ToString();
                            }
                            else if (Type == "O")
                            {
                                dtrow["ID"] = dt.Rows[i]["vouid"].ToString();
                            }
                            dt_Clearance.Rows.Add(dtrow);
                        }
                        txt_chequedate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[0]["clearedon"].ToString()).ToShortDateString());
                        Grd_DepositSlip.DataSource = dt_Clearance;
                        Grd_DepositSlip.DataBind();
                        ViewState["Deposit_Clearance"] = dt_Clearance;
                        ViewState["ddl_type"] = Type;
                        Total = 0;
                        foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                        {
                            if (Grd_DepositSlip.Rows[Row.RowIndex].Cells[7].Text != "")
                            {
                                if (Grd_DepositSlip.Rows[Row.RowIndex].Cells[1].Text == txt_cheque.Text)
                                {
                                    CheckBox Chk = (CheckBox)Grd_DepositSlip.Rows[Row.RowIndex].FindControl("Chk_Select");
                                    Chk.Checked = true;
                                }

                                if (Grd_DepositSlip.Rows[Row.RowIndex].Cells[4].Text != "")
                                {
                                    Total = Total + Convert.ToDouble(Grd_DepositSlip.Rows[Row.RowIndex].Cells[4].Text);
                                }

                                if (Session["Amount"] != null)
                                {
                                    Total = Total + Convert.ToDouble(Session["Amount"].ToString());
                                }
                            }
                            else
                            {
                                CheckBox Chk = (CheckBox)Grd_DepositSlip.Rows[Row.RowIndex].FindControl("Chk_Select");
                                Chk.Checked = false;
                            }
                        }

                        txt_total.Text = string.Format("{0:#,##0.00}", Total); //Total.ToString("{0:#,##0.00}");
                       // Session["Amount"] = txt_total.Text;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Cheque #')", true);
                        txt_cheque.Text = "";
                        txt_cheque.Focus();
                        //Grd_DepositSlip.DataSource = Utility.Fn_GetEmptyDataTable();
                        //Grd_DepositSlip.DataBind();
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

        protected void txt_slip_cheque_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                if (ViewState["ddl_type"] != null)
                {
                    Type = ViewState["ddl_type"].ToString();
                }

                if (txt_slip_cheque.Text != "")
                {
                    if (Type == "R")
                    {
                        dt = obj_da_Receipt.GetRecptClearance4chq(Branch_ID, txt_slip_cheque.Text.ToString(), "S");
                    }

                    DataTable dt_Clearance = new DataTable();
                    int a = 0;

                    if (dt.Rows.Count > 0)
                    {
                        if (a == 0)
                        {
                            dt_Clearance.Columns.Add("chequeno");
                            dt_Clearance.Columns.Add("chequedate");
                            dt_Clearance.Columns.Add("bank");
                            dt_Clearance.Columns.Add("customername");
                            dt_Clearance.Columns.Add("Amount");
                            dt_Clearance.Columns.Add("Slip #");
                            dt_Clearance.Columns.Add("ClearedOn");
                            dt_Clearance.Columns.Add("shortname");
                            dt_Clearance.Columns.Add("ID");
                        }

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            DataRow dtrow = dt_Clearance.NewRow();
                            dtrow["chequeno"] = dt.Rows[i]["chequeno"].ToString();
                            dtrow["chequedate"] = dt.Rows[i]["chequedate"].ToString();
                            dtrow["customername"] = dt.Rows[i]["customername"].ToString();
                            dtrow["Amount"] = dt.Rows[i]["amount"].ToString();
                            dtrow["bank"] = dt.Rows[i]["bank"].ToString();
                            dtrow["shortname"] = dt.Rows[i]["shortname"].ToString();
                            dtrow["Slip #"] = "";
                            dtrow["ClearedOn"] = dt.Rows[i]["clearedon"].ToString();

                            if (Type == "R")
                            {
                                dtrow["ID"] = dt.Rows[i]["receiptid"].ToString();
                            }
                            else if (Type == "P")
                            {
                                dtrow["ID"] = dt.Rows[i]["paymentid"].ToString();
                            }
                            else if (Type == "O")
                            {
                                dtrow["ID"] = dt.Rows[i]["vouid"].ToString();
                            }

                            dt_Clearance.Rows.Add(dtrow);
                        }

                        Grd_DepositSlip.DataSource = dt_Clearance;
                        Grd_DepositSlip.DataBind();
                        ViewState["Deposit_Clearance"] = dt_Clearance;
                        ViewState["ddl_type"] = Type;
                        Total = 0;
                        foreach (GridViewRow Row in Grd_DepositSlip.Rows)
                        {
                            if (Grd_DepositSlip.Rows[Row.RowIndex].Cells[7].Text != "")
                            {
                                txt_chequedate.Text = Utility.fn_ConvertDate(Grd_DepositSlip.Rows[Row.RowIndex].Cells[7].Text);
                                CheckBox Chk = (CheckBox)Grd_DepositSlip.Rows[Row.RowIndex].FindControl("Chk_Select");
                                Chk.Checked = true;


                                if (Grd_DepositSlip.Rows[Row.RowIndex].Cells[4].Text != "")
                                {
                                    Total = Total + Convert.ToDouble(Grd_DepositSlip.Rows[Row.RowIndex].Cells[4].Text);
                                }

                                if (Session["Amount"] != null)
                                {
                                    Total = Total + Convert.ToDouble(Session["Amount"].ToString());
                                }
                            }
                            else
                            {
                                txt_chequedate.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToString());
                                CheckBox Chk = (CheckBox)Grd_DepositSlip.Rows[Row.RowIndex].FindControl("Chk_Select");
                                Chk.Checked = false;
                            }
                        }

                        txt_total.Text = string.Format("{0:#,##0.00}", Total); //Total.ToString("{0:#,##0.00}");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Slip #')", true);
                        txt_slip_cheque.Focus();
                        Grd_DepositSlip.DataSource = Utility.Fn_GetEmptyDataTable();
                        Grd_DepositSlip.DataBind();
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

        protected void Grd_DepositSlip_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }
        }


        protected void drp_Sorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_sorting = new DataTable();

                if (ViewState["Deposit_Clearance"] != null)
                {
                    dt_sorting = ViewState["Deposit_Clearance"] as DataTable;
                }

                if (dt_sorting.Rows.Count > 0)
                {
                    DataView dv_sorting = dt_sorting.DefaultView;

                    if (drp_Sorting.SelectedValue == "Cheque #")
                    {
                        dv_sorting.Sort = "chequeno DESC";
                    }
                    else if (drp_Sorting.SelectedValue == "Bank")
                    {
                        dv_sorting.Sort = "bank DESC";
                    }
                    else if (drp_Sorting.SelectedValue == "Cheque Date")
                    {
                        dv_sorting.Sort = "chequedate DESC";
                    }
                    else if (drp_Sorting.SelectedValue == "Slip #")
                    {
                        dv_sorting.Sort = "Slip # DESC";
                    }
                    else if (drp_Sorting.SelectedValue == "Branch")
                    {
                        dv_sorting.Sort = "shortname DESC";
                    }

                    DataTable dt_chequeCleared = new DataTable();
                    dt_chequeCleared = dv_sorting.ToTable();

                    Grd_DepositSlip.DataSource = dt_chequeCleared;
                    Grd_DepositSlip.DataBind();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void GetNullRPClearanceDetails()
        {
            if (type == "R" || type == "P")
            {
                Dt1 = pymtobj.Getchequedetails(type, Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ddl_bank.SelectedItem.Text);
            }
            else if (type == "X")
            {
                Dt1 = recobj.GetOSRecptClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ddl_bank.SelectedItem.Text, curtype);
            }
            else if (type == "Y")
            {
                Dt1 = pymtobj.GetOSPymtClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ddl_bank.SelectedItem.Text, curtype);
            }
            else if (type == "A")
            {
                Dt1 = faobj.GetManRPClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ledgerid, "R", curtype);
            }
            else if (type == "B")
            {
                Dt1 = faobj.GetManRPClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ledgerid, "P", curtype);
            }
            else if (type == "O")
            {
                Dt1 = faobj.GetContraClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ledgerid, "Contra", curtype);
            }
            else if (type == "BRR")
            {
                Dt1 = faobj.GetContraClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ledgerid, "BRR", curtype);
            }
            else if (type == "BPR")
            {
                Dt1 = faobj.GetContraClearanceDetails4BRS(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_chequedate.Text)), ledgerid, "BPR", curtype);
            }

            if (Dt1.Rows.Count > 0)
            {
                if (dtrec.Columns.Count == 0)
                {
                    dtrec.Columns.Add("chequedate");
                    dtrec.Columns.Add("Chequeno");
                    dtrec.Columns.Add("bank");
                    dtrec.Columns.Add("customername");
                    dtrec.Columns.Add("amount");
                    dtrec.Columns.Add("branch");
                    dtrec.Columns.Add("Rid");
                }

                if (dtpay.Columns.Count == 0)
                {

                    dtpay.Columns.Add("chequedate");
                    dtpay.Columns.Add("Chequeno");
                    dtpay.Columns.Add("bank");
                    dtpay.Columns.Add("customername");
                    dtpay.Columns.Add("amount");
                    dtpay.Columns.Add("branch");
                    dtpay.Columns.Add("Rid");
                }

                if (type == "R" || type == "A" || type == "BRR")
                {
                    int b = 0;
                    int r = 0;
                    b = dtrec.Rows.Count;
                    for (i = b; i <= b + Dt1.Rows.Count - 1; i++)
                    {
                        dtrec.Rows.Add();
                        dtrec.Rows[i][0] = Dt1.Rows[r]["chequedate"].ToString();
                        dtrec.Rows[i][1] = Dt1.Rows[r]["chequeno"].ToString();
                        dtrec.Rows[i][2] = Dt1.Rows[r]["bank"].ToString();
                        dtrec.Rows[i][3] = Dt1.Rows[r]["customername"].ToString();
                        dtrec.Rows[i][4] = Dt1.Rows[r]["amount"].ToString();
                        dtrec.Rows[i][6] = Dt1.Rows[r]["id"].ToString();

                        if (type == "R")
                        {
                            dbl_R = dbl_R + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        }
                        else if (type == "A")
                        {
                            dbl_A = dbl_A + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        }
                        else if (type == "BRR")
                        {
                            dbl_BRR = dbl_BRR + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        }
                        //  GrdReceipt.Rows(i).Cells("shortname1").Value = Dt1.Rows[r]["shortname"].ToString();
                        r = r + 1;
                    }
                    dtrec.Rows.Add();
                    if (type == "R")
                    {
                        dtrec.Rows[dtrec.Rows.Count - 1][3] = "Receipt Total";
                        dtrec.Rows[dtrec.Rows.Count - 1][4] = string.Format("{0:0.00}", dbl_R);
                        //String.Format(dbl_R, "{0:0.00}");
                    }
                    else if (type == "A")
                    {
                        dtrec.Rows[dtrec.Rows.Count - 1][3] = "Manual Receipt Total";
                        dtrec.Rows[dtrec.Rows.Count - 1][4] = string.Format("{0:0.00}", dbl_A);
                    }
                    else if (type == "BRR")
                    {
                        dtrec.Rows[dtrec.Rows.Count - 1][3] = "BRR Total";
                        dtrec.Rows[dtrec.Rows.Count - 1][4] = string.Format("{0:0.00}", dbl_BRR);
                    }
                    dtrec.Rows.Add();
                    ViewState["Receipt"] = dtrec;
                    //GrdReceipt.Rows.Add();
                }
                else if (type == "X")
                {
                    int b = 0;
                    int r = 0;
                    dtrec.Rows.Add();
                    b = dtrec.Rows.Count;
                    for (i = b; i <= b + Dt1.Rows.Count - 1; i++)
                    {
                        dtrec.Rows.Add();
                        dtrec.Rows[i][0] = Dt1.Rows[r]["chequedate"].ToString();
                        dtrec.Rows[i][1] = Dt1.Rows[r]["chequeno"].ToString();
                        dtrec.Rows[i][2] = Dt1.Rows[r]["bank"].ToString();
                        dtrec.Rows[i][3] = Dt1.Rows[r]["customername"].ToString();
                        dtrec.Rows[i][4] = Dt1.Rows[r]["amount"].ToString();
                        dtrec.Rows[i][6] = Dt1.Rows[r]["id"].ToString();
                        dtrec.Rows[i][5] = Dt1.Rows[r]["shortname"].ToString();

                        dbl_X = dbl_X + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        r = r + 1;
                    }
                    dtrec.Rows.Add();
                    dtrec.Rows[dtrec.Rows.Count - 1][3] = "OS Receipt Total";
                    dtrec.Rows[dtrec.Rows.Count - 1][4] = string.Format("{0:0.00}", dbl_X);
                    dtrec.Rows.Add();
                }
                else if (type == "P" || type == "B" || type == "BPR")
                {
                    int b = 0, r_count, r = 0;
                    b = dtpay.Rows.Count;

                    for (i = b; i <= b + Dt1.Rows.Count - 1; i++)
                    {
                        if (Math.Abs(Convert.ToDouble(Dt1.Rows[r]["amount"].ToString())) > 0)
                        {
                            r_count = dtpay.Rows.Count;
                            dtpay.Rows.Add();
                            dtpay.Rows[r_count][0] = Dt1.Rows[r]["chequedate"].ToString();
                            dtpay.Rows[r_count][1] = Dt1.Rows[r]["chequeno"].ToString();
                            dtpay.Rows[r_count][2] = Dt1.Rows[r]["bank"].ToString();
                            dtpay.Rows[r_count][3] = Dt1.Rows[r]["customername"].ToString();
                            dtpay.Rows[r_count][4] = Dt1.Rows[r]["amount"].ToString();
                            dtpay.Rows[r_count][6] = Dt1.Rows[r]["id"].ToString();

                            if (type == "P")
                            {
                                dbl_P = dbl_P + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                            }
                            else if (type == "B")
                            {
                                dbl_B = dbl_B + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                            }
                            else if (type == "BPR")
                            {
                                dbl_BPR = dbl_BPR + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                            }
                            dtpay.Rows[r_count][5] = Dt1.Rows[r]["shortname"].ToString();
                        }
                        r = r + 1;
                    }
                    dtpay.Rows.Add();

                    if (type == "P")
                    {
                        dtpay.Rows[dtpay.Rows.Count - 1][3] = "Payment Total";
                        dtpay.Rows[dtpay.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_P);
                    }
                    else if (type == "B")
                    {
                        dtpay.Rows[dtpay.Rows.Count - 1][3] = "Manual Payment Total";
                        dtpay.Rows[dtpay.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_B);
                    }
                    else if (type == "BPR")
                    {
                        dtpay.Rows[dtpay.Rows.Count - 1][3] = "BPR Total";
                        dtpay.Rows[dtpay.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_BPR);
                    }
                    dtpay.Rows.Add();
                    ViewState["Payment"] = dtpay;
                }
                else if (type == "Y")
                {
                    int b = 0;
                    int r = 0;
                    dtpay.Rows.Add();
                    b = dtpay.Rows.Count;
                    for (i = b; i <= b + Dt1.Rows.Count - 1; i++)
                    {
                        dtpay.Rows.Add();
                        dtpay.Rows[i][0] = Dt1.Rows[r]["chequedate"].ToString();
                        dtpay.Rows[i][1] = Dt1.Rows[r]["chequeno"].ToString();
                        dtpay.Rows[i][2] = Dt1.Rows[r]["bank"].ToString();
                        dtpay.Rows[i][3] = Dt1.Rows[r]["customername"].ToString();
                        dtpay.Rows[i][4] = Dt1.Rows[r]["amount"].ToString();
                        dtpay.Rows[i][6] = Dt1.Rows[r]["paymentid"].ToString();
                        dtpay.Rows[i][5] = Dt1.Rows[r]["Shortname"].ToString();

                        dbl_Y = dbl_Y + Convert.ToDouble(Dt1.Rows[r]["amount"].ToString());
                        r = r + 1;
                    }
                    dtpay.Rows.Add();
                    dtpay.Rows[dtpay.Rows.Count - 1][3] = "OS Payment Total";
                    dtpay.Rows[dtpay.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_Y);
                    dtpay.Rows.Add();
                }
                else if (type == "O")
                {
                    int b = 0;
                    int r = 0;
                    DataTable dtcontra = new DataTable();
                    dtcontra.Columns.Add("chequedate");
                    dtcontra.Columns.Add("chequeno");
                    dtcontra.Columns.Add("bank");
                    dtcontra.Columns.Add("customername");
                    dtcontra.Columns.Add("amount");
                    dtcontra.Columns.Add("branch");
                    dtcontra.Columns.Add("RID");
                    b = dtcontra.Rows.Count;
                    for (i = 0; i <= Dt1.Rows.Count - 1; i++)
                    {
                        if (Math.Abs(Convert.ToDouble(Dt1.Rows[i]["amount"].ToString())) > 0)
                        {
                            dtcontra.Rows.Add();
                            dtcontra.Rows[r][0] = Dt1.Rows[i]["chequedate"].ToString();
                            dtcontra.Rows[r][1] = Dt1.Rows[i]["chequeno"].ToString();
                            dtcontra.Rows[r][2] = Dt1.Rows[i]["bank"].ToString();
                            dtcontra.Rows[r][3] = Dt1.Rows[i]["customername"].ToString();
                            dtcontra.Rows[r][4] = Dt1.Rows[i]["amount"].ToString();
                            dtcontra.Rows[r][6] = Dt1.Rows[i]["id"].ToString();
                            dtcontra.Rows[r][5] = Dt1.Rows[i]["Shortname"].ToString();
                            if (Dt1.Rows[i]["LedgerType"].ToString() == "Cr")
                            {
                                dbl_O_CR = dbl_O_CR + Convert.ToDouble(Dt1.Rows[i]["amount"].ToString());
                            }
                            else
                            {
                                dbl_O_DR = dbl_O_DR + Convert.ToDouble(Dt1.Rows[i]["amount"].ToString());
                            }
                            dbl_O = dbl_O + Convert.ToDouble(Dt1.Rows[i]["amount"].ToString());
                            r = r + 1;
                        }
                    }
                    dtcontra.Rows.Add();
                    dtcontra.Rows[dtcontra.Rows.Count - 1][2] = "Contra Total";
                    dtcontra.Rows[dtcontra.Rows.Count - 1][4] = String.Format("{0:0.00}", dbl_O);
                    dtcontra.Rows.Add();
                    grdContra.DataSource = dtcontra;
                    grdContra.DataBind();
                    //grdContra.Rows(grdContra.Rows.Count - 1).Cells(2).Value = "Total"
                    //grdContra.Rows(grdContra.Rows.Count - 1).Cells(4).Value = Format(Convert.ToDouble(txt_ContraCR.Text) + Convert.ToDouble(txt_contraDB.Text), "{0:0.00}")
                }
            }
        }

        protected void grdPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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

                for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void GrdReceipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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

                for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void grdContra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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

                for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void lnk_chqdeposit_Click(object sender, EventArgs e)
        {
            if (GrdReceipt.Rows.Count > 0)
            {
                this.popup_Deposit.Show();
                GrdReceipt.Visible = true;
                grdContra.Visible = false;
                grdPayment.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", "alertify.alert('Cheque Deposited Details does not Exists');", true);
            }
        }

        protected void lnk_contra_Click(object sender, EventArgs e)
        {
            if (grdContra.Rows.Count > 0)
            {
                this.popup_Deposit.Show();
                GrdReceipt.Visible = false;
                grdContra.Visible = true;
                grdPayment.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", "alertify.alert('Cheque Issued Details does not Exists');", true);
            }
        }

        protected void lnk_chqissue_Click(object sender, EventArgs e)
        {
            if (grdPayment.Rows.Count > 0)
            {
                this.popup_Deposit.Show();
                GrdReceipt.Visible = false;
                grdContra.Visible = false;
                grdPayment.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Invoice", "alertify.alert('Contra Details does not Exists');", true);
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
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Logobj.GetDataBase(Ccode);
            lbl_no.InnerText = lbl_Header.Text;
            if (lbl_Header.Text == "Deposit Slip")
            {
                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1145, "", "", "", Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1192, "", "", "", Session["StrTranType"].ToString());
                }
            }

            else
            {
                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1103, "", "", "", Session["StrTranType"].ToString());

                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1223, "", "", "", Session["StrTranType"].ToString());

                }
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