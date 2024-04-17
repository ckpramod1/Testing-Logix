using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Services;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace logix.FAForm
{
    public partial class PaymentFA_BackDated : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer Cust_Obj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Recipts Bank_Obj = new DataAccess.Accounts.Recipts();
        DataAccess.FAMaster.ReceiptNewBackDate obj_recepay = new DataAccess.FAMaster.ReceiptNewBackDate();
        DataAccess.Accounts.Payment Payment_Obj = new DataAccess.Accounts.Payment();
        DataAccess.Masters.MasterCharges Charge_Obj = new DataAccess.Masters.MasterCharges();
        DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
        DataAccess.LogDetails Log_Obj = new DataAccess.LogDetails();
        DataAccess.Accounts.NotOverCheque NotOverChq_Obj = new DataAccess.Accounts.NotOverCheque();
        DataAccess.Masters.MasterChequeReq_App ChqObj = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Masters.MasterBranch Master_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.Approval Approve_Obj = new DataAccess.Accounts.Approval();
        DataAccess.FAMaster.MasterLedger Ledger_Obj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.FAVoucher FAObj = new DataAccess.FAVoucher();
        DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        string val, dispyear = "", dy1 = "", IE = "", RowVouType, custRcharname, str_mode, mode, RPtype, branchpay, FADbname, vtype = "";
        int BranchId, custid, Cheq_Year, rid, dy, rw, recno, GrdChrgid, chkledgerid, selectedRowIndex, selectedColumnIndex;
        int GroupId, SubGroupId, cust_index, did, bid, ccid, IntCustId, EmpId, logcorid;
        char ACPayee, Setteled;
        double PartyAmt, total, inc = 0, exp = 0, Total = 0, camt;
        DateTime Recdate, currdate;
        int backdate, curmonth;
        DataTable dtTable = new DataTable();
        bool bolCust = false;
        bool blnerr = false;
        DateTime lastDay;
        string NEFT;
        string slipno;
        int Slip_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Cust_Obj.GetDataBase(Ccode);
                Bank_Obj.GetDataBase(Ccode);
                obj_recepay.GetDataBase(Ccode);
                Payment_Obj.GetDataBase(Ccode);
                Charge_Obj.GetDataBase(Ccode);
                Emp_Obj.GetDataBase(Ccode);
                Log_Obj.GetDataBase(Ccode);
                NotOverChq_Obj.GetDataBase(Ccode);
                ChqObj.GetDataBase(Ccode);


                Master_Branch.GetDataBase(Ccode);
                Approve_Obj.GetDataBase(Ccode);
                Ledger_Obj.GetDataBase(Ccode);
                FAObj.GetDataBase(Ccode);
                objrv.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);


            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Grid_Cheque);

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_head.Text = Request.QueryString["FormName"].ToString();
                lbl_head1.InnerText = lbl_head.Text;
            }

            FADbname = Session["FADbname"].ToString();
            bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            EmpId = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());

            if (lbl_head.Text == "FY End Back Dated Payments")
            {
                Session["Rtype"] = "P";
                Session["rptype"] = Session["Rtype"];
            }
            else if (lbl_head.Text == "FY End Back Dated Receipts")
            {
                Session["Rtype"] = "R";
                Session["rptype"] = Session["Rtype"];
            }

            if (Session["Loginyear"].ToString() == (Convert.ToInt32(Session["Vouyear"].ToString()) + 1).ToString())
            {
                save_id.Visible = true;
                btn_save.Visible = true;
            }
            else
            {
                //save_id.Visible=false;
                //btn_save.Visible = false;
            }

            if (!IsPostBack)
            {
                 txt_amt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                 txt_dedu_amt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");


                lbnl_logyear.Text = Session["LYEAR"].ToString();
                btn_delete.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');";
                if (Session["StrTranType"].ToString() == "AC")
                {
                    branchpay = "B";
                    lnk_cheque.Attributes["class"] = "lbl_cheq2";
                }

                if (lbl_head.Text == "FY End Back Dated Payments")
                {
                    lbl_head1.InnerText = lbl_head.Text;
                    lbl_title.Text = "PAYMENT  VOUCHER";
                    lnk_cheque.Visible = true;
                    lnk_amount.Visible = true;
                    //txt_recieve.Attributes.Add("placeholder", "Payment To");
                    txt_recieve.ToolTip = "Payment To";
                    //txt_recp.Attributes.Add("placeholder", "Payment #");
                    txt_recieve.ToolTip = "Payment #";
                    ddl_branch.Visible = true;
                    //txt_deduction.Attributes.Add("placeholder", "Charges");
                    txt_deduction.ToolTip = "Charges";
                    //txt_dedu_amt.Attributes.Add("placeholder", "Amount");


                    lbl_recieve.Text = "Payment To";
                    lbl_recp.Text = "Payment #";
                    lbl_deduction.Text = "Charges";
                    lbl_dedu_amt.Text = "Amount";


                    txt_deduction.Enabled = false;
                    txt_dedu_amt.Enabled = false;
                    btn_delete.Enabled = false;
                    Grid_detail.Columns[4].HeaderText = "Pymt-Amt";
                    Grid_Account.Columns[1].HeaderText = "Account Details";
                    txt_depositbank.Visible = false;
                    lbl_depositbank.Visible = false;
                }
                else if (lbl_head.Text == "FY End Back Dated Receipts")
                {
                    lbl_head1.InnerText = lbl_head.Text;
                    lbl_title.Text = "RECEIPT  VOUCHER";
                    lnk_cheque.Visible = false;
                    lnk_amount.Visible = false;
                    //txt_recieve.Attributes.Add("placeholder", "Received From");
                    txt_recieve.ToolTip = "Received From";
                    ddl_branch.Visible = false;
                    lbl_branch.Visible = false;
                    //txt_deduction.Attributes.Add("placeholder", "Deduction");

                    lbl_recieve.Text = "Received From";
                    lbl_deduction.Text = "Deduction";
                  

                    txt_deduction.ToolTip = "Deduction";
                    lbl_amountinword.Visible = true;
                    btn_delete.ForeColor = System.Drawing.Color.Gray;
                    Chk_Account.Visible = false;
                    Chk_Account.Enabled = false;
                    divPayment.Visible = false;
                    txt_depositbank.Visible = true;
                    lbl_depositbank.Visible = true;
                }

                Grid_Account.DataSource = Utility.Fn_GetEmptyDataTable();
                Grid_Account.DataBind();
                Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
                Grid_detail.DataBind();
                btn_back.ToolTip = "Cancel";
                backdate = Convert.ToInt32(HttpContext.Current.Session["Vouyear"])-1;

                txt_recpdate.Text = backdate.ToString();
                //txt_cheqdate.Text = Utility.fn_ConvertDate(Log_Obj.GetDate().ToShortDateString());
                txt_cheqdate.Enabled = false;
                txt_disable(false);
                //txt_date.Text = (Log_Obj.GetDate().ToShortDateString());
                //curmonth = 180;
                //txt_date.Text = string.Format(Convert.ToDateTime(2016,3,31),"{dd/MM}/yyyy");
                int getDateMonthNow = DateTime.Now.Month;
                int getDateYearNow = DateTime.Now.Year;
                //if (Session["LoginDivisionId"].ToString() == "1" || Session["LoginDivisionId"].ToString() == "3")
                //{
                //    getDateYearNow = getDateYearNow - 1;
                //    lastDay = new DateTime(getDateYearNow, 12, 31);
                //}
                //else
                //{

                //}

                if (getDateMonthNow < 4)
                {
                    getDateYearNow = getDateYearNow - 1;
                }
                else
                {
                    getDateYearNow = DateTime.Now.Year;
                }
                lastDay = new DateTime(getDateYearNow, 4, 1).AddDays(-1);


                txt_date.Text = lastDay.ToString();
                txt_date.Text = Utility.fn_ConvertDate(txt_date.Text);
                txt_cheqdate.Text = txt_date.Text;
                int Vouyear = Convert.ToInt32(txt_recpdate.Text);
                //currdate = Log_Obj.GetDate();
                txt_recp.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

                if (Session["StrTranType"].ToString() == "CO")
                {
                    dtTable = Emp_Obj.selBranchList(Session["LoginDivisionName"].ToString());
                    if (dtTable.Rows.Count > 0)
                    {
                        ddl_branch.Items.Add("Branch");
                        for (int i = 0; i <= dtTable.Rows.Count - 1; i++)
                        {
                            ddl_branch.Items.Add(dtTable.Rows[i]["branchname"].ToString());
                        }
                    }
                    ddl_branch.Enabled = true;
                    string Branch1 = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
                    ddl_branch.SelectedItem.Text = Branch1;
                }
                else
                {
                    string Branch = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
                    ddl_branch.Items.Add(Branch);
                    ddl_branch.Enabled = false;
                    //lnk_amount.Enabled = false;
                    //lnk_cheque.Enabled = false;
                }

                Btn_disable(false);
                txt_total.Enabled = false;

                if (branchpay == "B")
                {
                    //ddl_mode.Items.Add("");
                    ddl_mode.Items.Add("Cash");

                    Chk_accountpayee.Visible = false;
                    lnk_amount.Visible = false;
                    lnk_cheque.Visible = false;
                }
                else
                {
                    //ddl_mode.Items.Add("");
                    ddl_mode.Items.Add("Cash");
                    ddl_mode.Items.Add("Cheque/DD");
                    ddl_mode.Items.Add("NEFT/RTGS");
                }

                if (lbl_head.Text == "FY End Back Dated Receipts" && Session["StrTranType"].ToString() == "CO")
                {
                    //ddl_mode.Items.Add("");
                    ddl_mode.Items.Add("Petty Cash");
                }
                else if (lbl_head.Text == "FY End Back Dated Receipts" && Session["StrTranType"].ToString() == "AC")
                {
                    //ddl_mode.Items.Add("");
                    ddl_mode.Items.Add("Cheque/DD");
                    ddl_mode.Items.Add("NEFT/RTGS");
                    ddl_mode.Items.Add("Petty Cash");
                }



                txt_fvr.Visible = false;
                lbl_fvr.Visible = false;
                txt_refno.Visible = false;
                lbl_refno.Visible = false;
                divPayment.Visible = false;
                btn_cust_add.Enabled = false;
                btn_deduct_add.Enabled = false;
                btn_short_add.Enabled = false;
                logcorid = Emp_Obj.GetBranchId(did, "CORPORATE");
            }
        }

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
          
            DataTable dt = new DataTable();
            dt = customerobj.GetLikeCustomer(prefix);
            List_Result = Utility.Fn_TableToList(dt, "customer", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCheque(string prefix)
        {
            List<string> List_Result = new List<string>();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataAccess.Accounts.NotOverCheque objnoc = new DataAccess.Accounts.NotOverCheque();
            DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objnoc.GetDataBase(Ccode);
            hrempobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            int Branchid = hrempobj.GetBranchId(did, "branchname");
            dt = objnoc.GetNotOverChequelikeCheque(prefix, Branchid);
            List_Result = Utility.Fn_TableToList(prefix, dt, "ChequeNo");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetBank(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Accounts.Recipts bankobj = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            bankobj.GetDataBase(Ccode);
           
            DataTable dtBank_Det = new DataTable();
            string rtypeval = HttpContext.Current.Session["Rtype"].ToString();

            if (rtypeval == "P")
            {
                dtBank_Det = bankobj.GetLikeBankName(prefix, "O");
            }
            else
            {
                dtBank_Det = bankobj.GetLikeBankName(prefix);
            }
            List_Result = Utility.Fn_TableToList(dtBank_Det, "bankname", "bankid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCust(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
            DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            Emp_Obj.GetDataBase(Ccode);
            recobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string rtypeval = HttpContext.Current.Session["Rtype"].ToString();
            string BranchName = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
            int Div_Id = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int BranchId = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int logcorid = Emp_Obj.GetBranchId(Div_Id, "CORPORATE");

            if (rtypeval == "R")
            {
                if (logcorid == BranchId)
                {
                    dt = recobj.GetLikeReceiptCustomer4Corp(prefix);
                }
                else if (BranchId == 5)
                {
                    dt = recobj.GetLikeReceiptCustomer4Mum(prefix);
                }
                else
                {
                    dt = recobj.GetLikeReceiptCustomer(prefix);
                }
            }
            else
            {
                int Sel_branchid = Emp_Obj.GetBranchId(Div_Id, BranchName);
                if (logcorid == Sel_branchid)
                {
                    dt = customerobj.GetLikeIndianCustomer4Corp(prefix);
                }
                else
                {
                    dt = customerobj.GetLikeIndianCustomer(prefix);
                }
            }
            List_Result = Utility.Fn_DatatableToList_int16Display(dt, "customer", "customerid", "customername");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetDeduction(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
            DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            chrgobj.GetDataBase(Ccode);
            Emp_Obj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string rtypeval = HttpContext.Current.Session["Rtype"].ToString();
            string BranchName = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
            int Div_Id = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int BranchId = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int logcorid = Emp_Obj.GetBranchId(Div_Id, "CORPORATE");

            if (rtypeval == "P")
            {
                dt = chrgobj.GetLikeChargesWOType4pay(prefix);
            }
            else
            {
                if (logcorid == BranchId)
                {
                    dt = chrgobj.GetLikeCharges4Corp(prefix);
                }
                else
                {
                    dt = chrgobj.GetLikeCharges(prefix);
                }
            }

            List_Result = Utility.Fn_TableToList(dt, "chargename", "chargeid");
            return List_Result;
        }

        private void txt_disable(Boolean Check)
        {
            txt_cheque.Enabled = Check;
            txt_bank.Enabled = Check;
            txt_branch1.Enabled = Check;
            txt_cheqdate.Enabled = Check;
        }

        private void Btn_disable(Boolean Check)
        {
            btn_cust_add.Enabled = Check;
            btn_deduct_add.Enabled = Check;
            btn_short_add.Enabled = Check;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_cust = new DataTable();
                DataTable dt_charge = new DataTable();
                int Vouyear = Convert.ToInt32(txt_recpdate.Text);

                mode_set();

                if (blnerr == true)
                {
                    return;
                }

                if (Session["rptype"].ToString() == "R")
                {
                    if (txt_amt.Text == "" || txt_amt.Text == null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt Amount Cannot be Empty')", true);
                        txt_amt.Focus();
                        return;
                    }
                }
                if (Session["rptype"].ToString() == "P")
                {
                    if (txt_amt.Text == "" || txt_amt.Text == null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Payment Amount Cannot be Empty')", true);
                        txt_amt.Focus();
                        return;
                    }
                }

                double Payment_Amount = Convert.ToDouble(txt_amt.Text);
                double Total_Amount = Convert.ToDouble(txt_total.Text);

                if (btn_save.ToolTip == "Save")
                {
                    if (Payment_Amount != Total_Amount)
                    {
                        if (Session["rptype"].ToString() == "R")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt Amount does not Match with Total Amount')", true);
                            blnerr = true;
                            return;
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Payment Amount does not Match with Total Amount')", true);
                            blnerr = true;
                            return;
                        }
                    }

                    if (Grid_Account.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Fill Customer / Tax Charges Details')", true);
                        blnerr = true;
                        return;
                    }

                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                        {
                            custid = Convert.ToInt32(Grid_Account.Rows[i].Cells[3].Text);
                            custRcharname = Grid_Account.Rows[i].Cells[1].Text;
                            dt_cust = Payment_Obj.Getcustamt(custid, bid, str_mode, Vouyear);

                            if (Session["rptype"].ToString() == "P" && str_mode == "C")
                            {
                                camt = Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                                if (dt_cust.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dt_cust.Rows.Count - 1; j++)
                                    {
                                        camt = Convert.ToDouble(camt + dt_cust.Rows[j]["amount"].ToString());
                                    }
                                }
                                //if (camt >= 10000)
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You can not make more than 10,000 to " + custRcharname + " in a day');", true);
                                //    blnerr = true;
                                //    return;
                                //}
                            }
                        }
                    }

                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Charge")
                        {
                            custid = Convert.ToInt32(Grid_Account.Rows[i].Cells[3].Text);
                            custRcharname = Grid_Account.Rows[i].Cells[1].Text;
                            dt_cust = Payment_Obj.Getchargeamt(custid, bid, str_mode, Vouyear);
                            if (Session["rptype"].ToString() == "P" && str_mode == "C")
                            {
                                camt = Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                                if (dt_cust.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dt_cust.Rows.Count - 1; j++)
                                    {
                                        camt = Convert.ToDouble(camt + dt_cust.Rows[j]["amount"].ToString());
                                    }
                                }
                                //if (camt >= 10000)
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You can not make more than 10,000 to " + custRcharname + " in a day');", true);
                                //    blnerr = true;
                                //    return;
                                //}
                            }
                        }
                    }

                    double GrdTotAmnt = 0, IncTotAmnt = 0, ExpTotAmnt = 0, CustAmnt = 0;
                    string IE;

                    for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                    {
                        IE = Grid_detail.Rows[i].Cells[5].Text.Trim();
                        TextBox Rec_Amount = (TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount");
                        if (Rec_Amount.Text == "")
                        {
                            Rec_Amount.Text = "0.00";
                        }

                        if (Session["rptype"].ToString() == "R")
                        {
                            if (IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "O" || IE == "B" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "OB")
                            {
                                IncTotAmnt = Convert.ToDouble(IncTotAmnt + Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim()));
                            }
                            else if (IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS")
                            {
                                ExpTotAmnt = Convert.ToDouble(ExpTotAmnt + Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim()));
                            }
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            if (IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "B" || IE == "B" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "OB")
                            {
                                IncTotAmnt = Convert.ToDouble(IncTotAmnt + Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim()));
                            }
                            else if (IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "O" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS")
                            {
                                ExpTotAmnt = Convert.ToDouble(ExpTotAmnt + Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim()));
                            }
                        }
                        if (Session["rptype"].ToString() == "R")
                        {
                            if (IE == "J")
                            {
                                if (Grid_detail.Rows[i].Cells[9].Text == "Dr")
                                {
                                    IncTotAmnt = Convert.ToDouble(IncTotAmnt + Convert.ToDouble(Rec_Amount.Text));
                                }
                                else if (Grid_detail.Rows[i].Cells[9].Text == "Cr")
                                {
                                    ExpTotAmnt = Convert.ToDouble(ExpTotAmnt + Convert.ToDouble(Rec_Amount.Text));
                                }
                            }
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            if (IE == "J")
                            {
                                if (Grid_detail.Rows[i].Cells[9].Text == "Dr")
                                {
                                    IncTotAmnt = Convert.ToDouble(IncTotAmnt + Convert.ToDouble(Rec_Amount.Text));
                                }
                                else if (Grid_detail.Rows[i].Cells[9].Text == "Cr")
                                {
                                    ExpTotAmnt = Convert.ToDouble(ExpTotAmnt + Convert.ToDouble(Rec_Amount.Text));
                                }
                            }
                        }
                    }

                    if (Session["rptype"].ToString() == "R")
                    {
                        GrdTotAmnt = IncTotAmnt - ExpTotAmnt;
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        GrdTotAmnt = ExpTotAmnt - IncTotAmnt;
                    }

                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                        {
                            CustAmnt = CustAmnt + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                        }
                    }

                    ViewState["CustAmnt"] = CustAmnt;
                    ViewState["GrdTotAmnt"] = GrdTotAmnt;

                    if (Session["rptype"].ToString() == "P" && str_mode == "C")
                    {
                        if (txt_refno.Text == "")
                        {
                            this.popup_ref.Show();
                            return;
                        }
                    }

                    btn_ref_no_Click(sender, e);

                    if (blnerr == true)
                    {
                        return;
                    }
                }
                btn_view.Focus();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            double Total = 0;
            DataTable dt_ok = new DataTable();
            dt_ok.Columns.Add("branchHide");
            dt_ok.Columns.Add("branch");
            dt_ok.Columns.Add("invoiceno");
            dt_ok.Columns.Add("iamount");
            dt_ok.Columns.Add("ramount");
            dt_ok.Columns.Add("voutype");
            dt_ok.Columns.Add("vouno");
            dt_ok.Columns.Add("tds");
            dt_ok.Columns.Add("ravouyear");
            dt_ok.Columns.Add("ltype");
            dt_ok.Columns.Add("Cust_Id");
            DataRow dr;

            DataTable dt_oktemp = new DataTable();
            dt_oktemp.Columns.Add("type");
            dt_oktemp.Columns.Add("customerortax");
            dt_oktemp.Columns.Add("amount");
            dt_oktemp.Columns.Add("cid");
            DataRow dr_detail;

            foreach (GridViewRow row in Grid_Amount.Rows)
            {
                CheckBox Chk = (CheckBox)row.FindControl("Chk_select");
                if (Chk.Checked == true)
                {
                    dr = dt_ok.NewRow();
                    dr_detail = dt_oktemp.NewRow();
                    dr[0] = Grid_Amount.Rows[row.RowIndex].Cells[0].Text;
                    dr[1] = Grid_Amount.Rows[row.RowIndex].Cells[1].Text;
                    dr[2] = Grid_Amount.Rows[row.RowIndex].Cells[3].Text;
                    dr[3] = Grid_Amount.Rows[row.RowIndex].Cells[7].Text;
                    dr[4] = Grid_Amount.Rows[row.RowIndex].Cells[7].Text;
                    dr[5] = Grid_Amount.Rows[row.RowIndex].Cells[13].Text;
                    dr[6] = Grid_Amount.Rows[row.RowIndex].Cells[9].Text;
                    dr[7] = Grid_Amount.Rows[row.RowIndex].Cells[10].Text;
                    dr[8] = Grid_Amount.Rows[row.RowIndex].Cells[11].Text;
                    dr[9] = "";
                    dr[10] = Grid_Amount.Rows[row.RowIndex].Cells[12].Text;
                    dt_ok.Rows.Add(dr);

                    if ((Grid_Amount.Rows[row.RowIndex].Cells[6].Text) != null)
                    {
                        txt_narration.Text = txt_narration.Text.Replace(System.Environment.NewLine, "") + Grid_Amount.Rows[row.RowIndex].Cells[15].Text.Replace(System.Environment.NewLine, "");
                    }

                    dr_detail[0] = "Customer";
                    dr_detail[1] = Grid_Amount.Rows[row.RowIndex].Cells[5].Text;
                    dr_detail[2] = Grid_Amount.Rows[row.RowIndex].Cells[7].Text;
                    dr_detail[3] = Grid_Amount.Rows[row.RowIndex].Cells[12].Text;
                    dt_oktemp.Rows.Add(dr_detail);

                    hid_customerid.Value = Grid_Amount.Rows[row.RowIndex].Cells[12].Text;
                    hid_VouAmt.Value = Grid_Amount.Rows[row.RowIndex].Cells[7].Text;
                    txt_recieve.Text = Grid_Amount.Rows[row.RowIndex].Cells[5].Text;
                    txt_fvr.Text = Grid_Amount.Rows[row.RowIndex].Cells[5].Text.ToString();
                    Total = Total + Convert.ToDouble(Grid_Amount.Rows[row.RowIndex].Cells[7].Text);
                    Chk_Account.Checked = true;
                }
            }

            Grid_detail.DataSource = dt_ok;
            Grid_detail.DataBind();
            ViewState["btn_ok_Grid_detail"] = dt_ok;
            Grid_Account.DataSource = dt_oktemp;
            Grid_Account.DataBind();
            ViewState["btn_ok_Grid_Account"] = dt_oktemp;
            txt_amt.Text = string.Format("{0:0.00}", Total);
            txt_total.Text = txt_amt.Text;
            txt_deduction.Enabled = true;
            txt_dedu_amt.Enabled = true;
        }

        protected void btn_Alert_Yes_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void btn_Alert_No_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtrefno = new DataTable();
                int bankid = 0, intcustid = 0;

                if (Session["rptype"].ToString() == "P")
                {
                    if (str_mode == "B")
                    {
                        if (Chk_Account.Checked == true)
                        {
                            ACPayee = 'C';
                        }
                        else
                        {
                            ACPayee = 'U';
                        }
                    }

                    if (str_mode == "C")
                    {
                        BranchId = Emp_Obj.GetBranchId(did, ddl_branch.Text);
                        dtrefno = Payment_Obj.GetCashRefNO(txt_refno.Text, BranchId);
                        if (dtrefno.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Reference No. Already Exists');", true);
                            txt_refno.Focus();
                            blnerr = true;
                            return;
                        }
                    }
                }

                if (str_mode == "B")
                {
                    if (txt_cheque.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Cheque # cannot be blank');", true);
                        txt_cheque.Focus();
                        blnerr = true;
                        return;
                    }
                    if (Session["rptype"].ToString() == "R")
                    {
                        if (txt_depositbank.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Deposit Bank Name cannot be blank');", true);
                            txt_depositbank.Focus();
                            blnerr = true;
                            return;
                        }
                    }
                    if (txt_bank.Text != "")
                    {
                        bankid = Bank_Obj.GetBankid(txt_bank.Text);
                        if (bankid == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Bank Name Not Available');", true);
                            txt_bank.Text = "";
                            txt_bank.Focus();
                            blnerr = true;
                            return;
                        }
                        else
                        {
                            Boolean Chqno = false;
                            Chqno = Bank_Obj.CheckChequeNo(txt_cheque.Text, bankid, Convert.ToChar(Session["rptype"]));
                            if (Chqno == true)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Cheque # already Exist');", true);
                                txt_cheque.Focus();
                                blnerr = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Bank Name cannot be blank');", true);
                        txt_bank.Focus();
                        blnerr = true;
                        return;
                    }
                    if (txt_branch1.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Bank Branch cannot be blank');", true);
                        txt_branch1.Focus();
                        blnerr = true;
                        return;
                    }
                }
                if (txt_recieve.Text != "")
                {
                    intcustid = Cust_Obj.GetCustomerid(txt_recieve.Text);
                    if (intcustid == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Received From Customer Name Not Available');", true);
                        txt_recieve.Focus();
                        blnerr = true;
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Received From cannot be blank');", true);
                    txt_recieve.Focus();
                    blnerr = true;
                    return;
                }
                if (txt_amt.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Amount cannot be blank');", true);
                    txt_amt.Focus();
                    blnerr = true;
                    return;
                }

                if (Session["rptype"].ToString() == "P")
                {
                    if (str_mode == "C")
                    {
                        double amt = Convert.ToDouble(txt_amt.Text);
                        //if (amt >= 10000)
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Amount Should Not Exceed Rs.9,999');", true);
                        //    txt_amt.Focus();
                        //    blnerr = true;
                        //    return;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void btn_ref_yes_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter Cash Referance No.');", true);
                txt_refno.Focus();
                blnerr = true;
                return;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void btn_ref_no_Click(object sender, EventArgs e)
        {
            try
            {
                string str_CustAmnt = "", str_GrdTotAmnt = "";
                double CustAmnt = (double)ViewState["CustAmnt"];
                str_CustAmnt = string.Format("{0:#,##0.00}", CustAmnt);
                double GrdTotAmnt = (double)ViewState["GrdTotAmnt"];
                str_GrdTotAmnt = string.Format("{0:#,##0.00}", GrdTotAmnt);

                //double CustAmnt = (double)ViewState["CustAmnt"];
                //double GrdTotAmnt = (double)ViewState["GrdTotAmnt"];
                int Vouyear = Convert.ToInt32(txt_recpdate.Text);

                mode_set();

                if (blnerr == true)
                {
                    return;
                }

                if (Session["rptype"].ToString() == "P" && str_mode == "C" && Grid_detail.Rows.Count == 0) { }
                else if (Session["rptype"].ToString() == "P" && str_mode == "B" && Grid_detail.Rows.Count == 0) { }
                else if (Session["rptype"].ToString() == "R" && str_mode == "P") { }
                else if (txt_refno.Text == "")
                {
                    //if (CustAmnt != GrdTotAmnt)
                    if (str_CustAmnt != str_GrdTotAmnt)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                        blnerr = true;
                        return;
                    }
                    else if (GrdTotAmnt > 0)
                    {
                        //if (CustAmnt != GrdTotAmnt)
                        if (str_CustAmnt != str_GrdTotAmnt)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                            blnerr = true;
                            return;
                        }
                    }
                }

                if (Session["rptype"].ToString() == "P")
                {
                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Charge")
                        {
                            GrdChrgid = Charge_Obj.GetChargeid(Grid_Account.Rows[i].Cells[1].Text);
                            chkledgerid = Ledger_Obj.ChkLedgeridfrmLedHead(GrdChrgid, "A", FADbname);
                            if (chkledgerid == 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' LedgerName " + Grid_Account.Rows[i].Cells[1].Text + " Not Found in Financial. You are not able to raise Payment.Contact Your  Finanace Head');", true);
                                blnerr = true;
                                return;
                            }
                        }
                    }
                }

                btn_Alert_No_Click(sender, e);

                if (blnerr == true)
                {
                    return;
                }

                double DblExShort = 0;
                if (Grid_Account.Rows.Count > 0)
                {
                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Excess / Short")
                        {
                            DblExShort = DblExShort + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                        }
                    }

                    if (DblExShort > 100)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Excess / Short should not Greater than 100 Rs.')", true);
                        blnerr = true;
                        return;
                    }
                    else if (DblExShort < -100)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Excess / Short should not Less than -100 Rs.')", true);
                        blnerr = true;
                        return;
                    }
                }

                int intBnkLedgID = FAObj.Selledgeridforops(FADbname, txt_bank.Text, 'O');
                string str_ledger = "";
                string vis = "N";
                if (intBnkLedgID == 0 && Session["rptype"].ToString() == "P" && mode == "C")
                {

                    if (bid == 4)
                    {
                        if (chk_hyde.Checked == true)
                        {
                            str_ledger = "PETTY CASH - " + Master_Branch.GetShortName(bid);
                            vis = "N";
                        }
                        else if (chk_visak.Checked == true)
                        {
                            str_ledger = "PETTY CASH - AXL - VIZ";
                            vis = "Y";
                        }

                    }
                    else
                    {
                        str_ledger = "PETTY CASH - " + Master_Branch.GetShortName(bid);
                    }

                    intBnkLedgID = FAObj.Selledgeridforops(FADbname, str_ledger, 'O');
                }


                //if (intBnkLedgID == 0 && Session["rptype"].ToString() == "P" && mode == "C")
                //{
                //    string str_ledger;
                //    str_ledger = "PETTYCASH-" + Master_Branch.GetShortName(bid);
                //    intBnkLedgID = FAObj.Selledgeridforops(FADbname, str_ledger, 'O');
                //}

                if (Session["rptype"].ToString() == "P")
                {
                    Boolean Bln_ChkMinMaxAmt = false;
                    Bln_ChkMinMaxAmt = Payment_Obj.CheckMedgerMaxMinAmt4Pmt(intBnkLedgID, did, Convert.ToDouble(txt_amt.Text), FADbname);
                    if (Bln_ChkMinMaxAmt == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Closing Balance has Crossed the maximum limit. You can not able to Issue the Payment');", true);
                        blnerr = true;
                        return;
                    }
                }

                DateTime Cur_Date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                int bankid = Bank_Obj.GetBankid(txt_bank.Text);

                DateTime Chq_Date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_cheqdate.Text));
                int rfCustId = 0;
                //if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                //{
                //    DataTable dtId = (DataTable)ViewState["CurrentData"];
                //    rfCustId = Convert.ToInt32(dtId.Rows[0]["cid"].ToString());
                //    rfCustId = Convert.ToInt32(hid_custid.Value);
                //}
                //if ((hid_customerid.Value != null) && ((hid_customerid.Value.Length) > 0))
                //{
                //    rfCustId = Convert.ToInt32(hid_customerid.Value);
                //}

                if (Hid_Receivedfrom.Value != "")
                {
                    rfCustId = Convert.ToInt32(Hid_Receivedfrom.Value);
                }

                int Payment_Id;

                if (Session["rptype"].ToString() == "R")
                {
                    recno = obj_recepay.GetCRBRNo4BackDated(bid, str_mode, Cur_Date);
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    bid = Emp_Obj.GetBranchId(did, ddl_branch.Text);
                    recno = obj_recepay.GetCPBPNo4BackDated(bid, str_mode, Cur_Date);
                }
                if (str_mode == "C")
                {
                    if (Session["rptype"].ToString() == "R")
                    {
                        obj_recepay.InsRecptHeadCashBackDate(recno, Cur_Date, Convert.ToChar(mode), bid, Vouyear, rfCustId, Convert.ToDouble(txt_amt.Text), txt_narration.Text, EmpId);
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        obj_recepay.InsPaymentHeadCashBackDate(recno, Cur_Date, Convert.ToChar(mode), bid, Vouyear, rfCustId, Convert.ToDouble(txt_amt.Text), txt_narration.Text, EmpId);
                        if (txt_refno.Text != "")
                        {
                            Payment_Obj.InsPaymentHeadcash4RefNo(recno, Convert.ToChar(mode), bid, Vouyear, txt_refno.Text);
                        }
                    }
                }
                else if (str_mode == "P")
                {
                    if (Session["rptype"].ToString() == "R")
                    {
                        obj_recepay.InsRecptHeadCashBackDate(recno, Cur_Date, Convert.ToChar(mode), bid, Vouyear, rfCustId, Convert.ToDouble(txt_amt.Text), txt_narration.Text, EmpId);
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        obj_recepay.InsPaymentHeadCashBackDate(recno, Cur_Date, Convert.ToChar(mode), bid, Vouyear, rfCustId, Convert.ToDouble(txt_amt.Text), txt_narration.Text, EmpId);
                        if (txt_refno.Text != "")
                        {
                            Payment_Obj.InsPaymentHeadcash4RefNo(recno, Convert.ToChar(mode), bid, Vouyear, txt_refno.Text);
                        }
                    }
                }
                else if (str_mode == "B")
                {
                    if (ddl_mode.SelectedItem.Text == "NEFT/RTGS")
                    {
                        NEFT = "Y";
                    }
                    else
                    {
                        NEFT = "N";
                    }
                    if (Session["rptype"].ToString() == "R")
                    {
                        Bank_Obj.InsRecptHeadBanknew(recno, Cur_Date, Convert.ToChar(mode), bid, Vouyear, rfCustId, Convert.ToDouble(txt_amt.Text), bankid, txt_branch1.Text, txt_cheque.Text, Chq_Date, txt_narration.Text, EmpId, NEFT);
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        if (txt_fvr.Text == "")
                        {
                            txt_fvr.Text = txt_recieve.Text;
                        }
                        Payment_Obj.InsPaymentHeadBanknew(recno, Cur_Date, Convert.ToChar(mode), bid, Vouyear, rfCustId, Convert.ToDouble(txt_amt.Text), bankid, txt_branch1.Text.ToString(), txt_cheque.Text.ToString(), Chq_Date, txt_narration.Text.ToString(), EmpId, Convert.ToChar(ACPayee), txt_fvr.Text.ToString(), NEFT);
                        Payment_Id = Payment_Obj.GetPaymentid(recno, bid, Convert.ToChar(mode), Vouyear);

                        if (chkDirectPay.Checked == true)
                        {
                            Payment_Obj.upddirpay(Payment_Id, "Y");
                            for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                            {
                                chkledgerid = 0;
                                int CId = Convert.ToInt32(Grid_Account.Rows[i].Cells[3].Text);

                                if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                                {
                                    chkledgerid = Ledger_Obj.ChkLedgeridfrmLedHead(CId, "C", FADbname);
                                    if (chkledgerid == 0)
                                    {
                                        SubGroupId = 40;
                                        GroupId = 13;
                                        chkledgerid = Ledger_Obj.InsLedgerHeadfromTally(Cust_Obj.GetCustomername(CId), SubGroupId, GroupId, 'G', CId, 'C', FADbname);
                                    }
                                    chkledgerid = Ledger_Obj.ChkLedgeridfrmLedHead(CId, "C", FADbname);
                                }
                                else if (Grid_Account.Rows[i].Cells[0].Text == "Charge")
                                {
                                    chkledgerid = Ledger_Obj.ChkLedgeridfrmLedHead(CId, "A", FADbname);
                                }
                                Approve_Obj.InsLedgerOPBreakup4DirPay(chkledgerid, Cur_Date, Vouyear, bid, Payment_Id, 'P', Vouyear, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text), CId);
                            }
                        }
                        else
                        {
                            Payment_Obj.upddirpay(Payment_Id, "N");
                        }
                    }
                }

                if (hid_cheque.Value != "")
                {
                    BranchId = Emp_Obj.GetBranchId(did, ddl_branch.Text);
                    NotOverChq_Obj.UpdateNotOverChequeAccounted(BranchId, Convert.ToInt32(hid_cheque.Value));
                }
                txt_recp.Text = recno.ToString();

                if (Session["rptype"].ToString() == "P" && str_mode == "C" && Grid_detail.Rows.Count == 0)
                {
                    SaveAllGrdDetails4PayCash();
                }
                else if (Session["rptype"].ToString() == "R" && str_mode == "P")
                {
                    SaveAllGrdDetails4PayCash();
                }
                else
                {
                    SaveAllGrdDetails();
                }


                // Update for Trigger 
                Bank_Obj.UpdRecptPymt4trigger(Convert.ToInt32(txt_recp.Text), bid, Vouyear, EmpId, Session["rptype"].ToString(), str_mode);


                string retransfer = "N";

                if (Session["rptype"].ToString() == "R")
                {
                    string BranchName;
                    BranchName = Master_Branch.Getbranchname(bid);
                    if (str_mode != "FC")
                    {
                        if (BranchName == "CORPORATE")
                        {
                            //Log_Obj.InsLogDetail(EmpId, 1186, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                            Log_Obj.InsLogDetail(EmpId, 1320, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                        }
                        else
                        {
                            //Log_Obj.InsLogDetail(EmpId, 1142, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                            Log_Obj.InsLogDetail(EmpId, 1323, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                        }
                    }
                    else
                    {
                        if (BranchName == "CORPORATE")
                        {
                            Log_Obj.InsLogDetail(EmpId, 1187, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                        }
                        else
                        {
                            Log_Obj.InsLogDetail(EmpId, 1147, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                        }
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt Details Saved')", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt # :" + txt_recp.Text.ToString() + "')", true);

                    //raj

                   

                    if (str_mode == "C")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Receipt", recno, recno, "", "", bid,"",0,0,"",1);

                        /******************************* For Re-Transfer *******************************/
                        //DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();

                        double dbtot = 0.00, crtot = 0.00, jdbtot = 0.00, jcrtot = 0.00;

                        ds = objrv.GetRecPymtVoucherMail(recno, "CR", bid, Vouyear, Session["FADbname"].ToString());
                        dt = ds.Tables[2];
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            dt1 = ds.Tables[3];
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dbtot = Convert.ToDouble(dt.Compute("SUM(Debit)", string.Empty));
                            crtot = Convert.ToDouble(dt.Compute("SUM(Credit)", string.Empty));
                        }
                        if (dt1.Rows.Count > 0)
                        {
                            jdbtot = Convert.ToDouble(dt1.Compute("SUM(Debit)", string.Empty));
                            jcrtot = Convert.ToDouble(dt1.Compute("SUM(Credit)", string.Empty));
                        }

                        if (dbtot != crtot || jdbtot != jcrtot)
                        {
                            retransfer = "Y";
                        }
                        if (retransfer == "Y")
                        {
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Receipt", recno, recno, "", "", bid,"",0,0,"",1);
                        }
                        /**********************************************************************************/

                    }
                    else if (str_mode == "B")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Receipt", recno, recno, "", "", bid,"",0,0,"",1);
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer_Slip("Bank Deposit - Transfer To CO", hid_depositslipino.Value, 0, "", "");

                        /******************************* For Re-Transfer *******************************/

                      //  DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();

                        double dbtot = 0.00, crtot = 0.00, jdbtot = 0.00, jcrtot = 0.00;

                        ds = objrv.GetRecPymtVoucherMail(recno, "BR", bid, Vouyear, Session["FADbname"].ToString());
                        dt = ds.Tables[2];
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            dt1 = ds.Tables[3];
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dbtot = Convert.ToDouble(dt.Compute("SUM(Debit)", string.Empty));
                            crtot = Convert.ToDouble(dt.Compute("SUM(Credit)", string.Empty));
                        }
                        if (dt1.Rows.Count > 0)
                        {
                            jdbtot = Convert.ToDouble(dt1.Compute("SUM(Debit)", string.Empty));
                            jcrtot = Convert.ToDouble(dt1.Compute("SUM(Credit)", string.Empty));
                        }

                        if (dbtot != crtot || jdbtot != jcrtot)
                        {
                            retransfer = "Y";
                        }
                        if (retransfer == "Y")
                        {
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Receipt", recno, recno, "", "", bid,"",0,0,"",1);
                        }

                        /*******************************************************************************/

                    }
                    else if (str_mode == "P")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Receipt - Petty Cash", recno, recno, "", "", bid,"",0,0,"",1);
                    }

                }

                /* --------------- TallyEDIFA Pending--------------------*/

                else if (Session["rptype"].ToString() == "P")
                {
                    if (branchpay == "B")
                    {
                        //Log_Obj.InsLogDetail(EmpId, 1143, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                        Log_Obj.InsLogDetail(EmpId, 1324, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                    }
                    else
                    {
                        //Log_Obj.InsLogDetail(EmpId, 1178, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                        Log_Obj.InsLogDetail(EmpId, 1321, 1, BranchId, mode + "/S" + txt_recp.Text.ToString());
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Payment Details Saved')", true);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Payment # :" + txt_recp.Text.ToString() + "')", true);

                    //raj
                    if (str_mode == "C")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Payment", recno, recno, "", "", bid, "", 0, 0, "",1);

                        /******************************* For Re-Transfer *******************************/

                       // DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();

                        double dbtot = 0.00, crtot = 0.00, jdbtot = 0.00, jcrtot = 0.00;

                        ds = objrv.GetRecPymtVoucherMail(recno, "CP", bid, Vouyear, Session["FADbname"].ToString());
                        dt = ds.Tables[2];
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            dt1 = ds.Tables[3];
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dbtot = Convert.ToDouble(dt.Compute("SUM(Debit)", string.Empty));
                            crtot = Convert.ToDouble(dt.Compute("SUM(Credit)", string.Empty));
                        }
                        if (dt1.Rows.Count > 0)
                        {
                            jdbtot = Convert.ToDouble(dt1.Compute("SUM(Debit)", string.Empty));
                            jcrtot = Convert.ToDouble(dt1.Compute("SUM(Credit)", string.Empty));
                        }

                        if (dbtot != crtot || jdbtot != jcrtot)
                        {
                            retransfer = "Y";
                        }
                        if (retransfer == "Y")
                        {
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Payment", recno, recno, "", "", bid,"",0,0,"",1);
                        }

                        /*******************************************************************************/
                    }
                    else if (str_mode == "B")
                    {
                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Payment", recno, recno, "", "", bid, "", 0, 0, "",1);

                        /******************************* For Re-Transfer *******************************/

                       // DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();

                        double dbtot = 0.00, crtot = 0.00, jdbtot = 0.00, jcrtot = 0.00;

                        ds = objrv.GetRecPymtVoucherMail(recno, "BP", bid, Vouyear, Session["FADbname"].ToString());
                        dt = ds.Tables[2];
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            dt1 = ds.Tables[3];
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dbtot = Convert.ToDouble(dt.Compute("SUM(Debit)", string.Empty));
                            crtot = Convert.ToDouble(dt.Compute("SUM(Credit)", string.Empty));
                        }
                        if (dt1.Rows.Count > 0)
                        {
                            jdbtot = Convert.ToDouble(dt1.Compute("SUM(Debit)", string.Empty));
                            jcrtot = Convert.ToDouble(dt1.Compute("SUM(Credit)", string.Empty));
                        }

                        if (dbtot != crtot || jdbtot != jcrtot)
                        {
                            retransfer = "Y";
                        }
                        if (retransfer == "Y")
                        {

                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Payment", recno, recno, "", "", bid,"",0,0,"",1);
                        }

                        /*******************************************************************************/


                    }
                }

                /* --------------- TallyEDIFA Pending--------------------*/

                btn_save.Enabled = false;
                btn_save.ForeColor = System.Drawing.Color.Gray;
                CTEnable();
                btn_view.Focus();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Session["str_sp"] = ""; Session["str_sp"] = "";
            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
            string BranchName = Master_Branch.Getbranchname(bid);
            int Vouyear = Convert.ToInt32(txt_recpdate.Text);
            recno = Convert.ToInt32(txt_recp.Text);

            mode_set();
            if (blnerr == true)
            {
                return;
            }

            //if (Session["rptype"].ToString() == "R")
            //{
            //    rid = Bank_Obj.GetRecrid(recno, bid, Convert.ToChar(mode), Vouyear);
            //}
            //else if (Session["rptype"].ToString() == "P")
            //{
            //    rid = Payment_Obj.GetPaymentid(recno, bid, Convert.ToChar(mode), Vouyear);
            //}

            rid = Convert.ToInt32(Hid_Rid.Value);

            if (Session["rptype"].ToString() == "R")
            {


                if (NewaspxRpt.Value == "Y")
                {
                    if (txt_recp.Text != "")
                    {
                        if (txt_recp.Text.Trim() != "")
                        {
                            str_Script = "window.open('../Reportasp/ReceiptFARpt.aspx?ReceiptId=" + rid + "&vouyear=" + txt_recpdate.Text + "&Mode=" + mode + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Receipt", str_Script, true);

                        if (str_mode != "FC")
                        {
                            if (BranchName == "CORPORATE")
                            {
                                //Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1186, 3, bid, str_mode + " /V " + txt_recp.Text);
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1320, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                            else
                            {
                                //Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1142, 3, bid, str_mode + " /V " + txt_recp.Text);
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1323, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                        }
                        else
                        {
                            if (BranchName == "CORPORATE")
                            {
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1187, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                            else
                            {
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1147, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                        }
                    }
                }
                else
                {
                    if (txt_recp.Text != "")
                    {
                        if (str_mode == "C")
                        {
                            str_RptName = "ReceiptCash.rpt";
                            Session["str_sfs"] = "{ReceiptHead.receiptid}=" + rid + " and {ReceiptAgainstInvoice.rptype}='R'";
                        }
                        else if (str_mode == "P")
                        {
                            str_RptName = "ReceiptPettyCash.rpt";
                            Session["str_sfs"] = "{ReceiptHead.receiptid}=" + rid;
                        }
                        else
                        {
                            str_RptName = "ReceiptBank.rpt";
                            Session["str_sfs"] = "{ReceiptHead.receiptid}=" + rid + " and {ReceiptAgainstInvoice.rptype}='R'";
                        }

                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Reciepts", str_Script, true);

                        if (str_mode != "FC")
                        {
                            if (BranchName == "CORPORATE")
                            {
                               // Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1186, 3, bid, str_mode + " /V " + txt_recp.Text);
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1320, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                            else
                            {
                               // Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1142, 3, bid, str_mode + " /V " + txt_recp.Text);
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1323, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                        }
                        else
                        {
                            if (BranchName == "CORPORATE")
                            {
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1187, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                            else
                            {
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1147, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                        }
                    }
                    else
                    {
                        if (ddl_mode.Text != "")
                        {
                            if (str_mode == "C")
                            {
                                str_RptName = "ReceiptCashReg.rpt";
                                Session["str_sfs"] = "{ReceiptHead.mode}='C' and {ReceiptHead.branchid}=" + bid + " and {ReceiptHead.vouyear}=" + Vouyear;
                                Session["str_sp"] = "title=Cash Receipts~branch=";
                            }
                            else if (str_mode == "P")
                            {
                                str_RptName = "ReceiptCashReg.rpt";
                                Session["str_sfs"] = "{ReceiptHead.mode}='P' and {ReceiptHead.branchid}=" + bid + " and {ReceiptHead.vouyear}=" + Vouyear;
                                Session["str_sp"] = "title=Petty Cash Receipts~branch=";
                            }
                            else
                            {
                                str_RptName = "ReceiptBankReg.rpt";
                                Session["str_sfs"] = "{ReceiptHead.mode}='B' and {ReceiptHead.branchid}=" + bid + " and {ReceiptHead.vouyear}=" + Vouyear;
                                Session["str_sp"] = "title=Bank Receipts~branch=";
                            }

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                            if (BranchName == "CORPORATE")
                            {
                                //Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1186, 3, bid, str_mode + " / V / All ReceiptNo. ");
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1320, 3, bid, str_mode + " / V / All ReceiptNo. ");
                            }
                            else
                            {
                                //Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1142, 3, bid, str_mode + " / V / All ReceiptNo. ");
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1323, 3, bid, str_mode + " /V " + txt_recp.Text);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Mode')", true);
                            blnerr = true;
                            return;
                        }
                    }

                }

            }
            else if (Session["rptype"].ToString() == "P")
            {
                RPtype = Session["rptype"].ToString();
                DataTable dt_GrdDet = new DataTable();
                dt_GrdDet = Bank_Obj.GetRAInvoiceToShow(rid, Convert.ToChar(RPtype));


                if (NewPayRpt.Value == "Y")
                {
                    if (txt_recp.Text != "")
                    {
                        if (txt_recp.Text.Trim() != "")
                        {
                            str_Script = "window.open('../Reportasp/PaymentFARpt.aspx?ReceiptId=" + rid + "&vouyear=" + txt_recpdate.Text + "&Mode=" + mode + "&Type=" + Session["rptype"].ToString() + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Receipt", str_Script, true);
                        if (branchpay == "B")
                        {
                            //Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1143, 3, bid, str_mode + " /V " + txt_recp.Text);
                            Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1324, 3, bid, str_mode + " /V " + txt_recp.Text);
                        }
                        else
                        {
                           // Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1178, 3, bid, str_mode + " /V " + txt_recp.Text);
                            Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1321, 3, bid, str_mode + " /V " + txt_recp.Text);
                        }

                    }
                }
                else
                {
                    if (txt_recp.Text != "")
                    {
                        if (str_mode == "C")
                        {
                            if (Grid_detail.Rows.Count == 0 || dt_GrdDet.Rows.Count == 0)
                            {
                                if (Grid_Account.Rows[0].Cells[0].Text == "Charge")
                                {
                                    str_RptName = "PaymentCashCash.rpt";
                                    Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid;
                                }
                                else if (Grid_Account.Rows[0].Cells[0].Text == "Customer")
                                {
                                    str_RptName = "PaymentCashCashcustomer.rpt";
                                    Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid;
                                }
                                else
                                {
                                    str_RptName = "PaymentCash.rpt";
                                    Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid + " and {ReceiptPayment.rptype}='P'";
                                }
                            }
                            else
                            {
                                str_RptName = "PaymentCash.rpt";
                                Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid + " and {ReceiptPayment.rptype}='P'";
                            }
                        }
                        else
                        {
                            if (did == 1)
                            {
                                if (Grid_Account.Rows[0].Cells[0].Text == "Charge")
                                {
                                    str_RptName = "PaymentBankCharge.rpt";
                                    Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid;
                                }
                                else
                                {
                                    if (chkDirectPay.Checked == false)
                                    {
                                        str_RptName = "PaymentBank.rpt";
                                        Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid + " and {ReceiptPayment.rptype}='P'";
                                    }
                                    else
                                    {
                                        str_RptName = "PaymentBank4dirpay.rpt";
                                        Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid;
                                    }
                                }
                            }
                            else
                            {
                                if (Grid_Account.Rows[0].Cells[0].Text == "Charge")
                                {
                                    str_RptName = "PaymentBank42and3Charge.rpt";
                                    Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid;
                                }
                                else
                                {
                                    if (chkDirectPay.Checked == false)
                                    {
                                        str_RptName = "PaymentBank42and3.rpt";
                                        Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid + " and {ReceiptPayment.rptype}='P'";
                                    }
                                    else
                                    {
                                        str_RptName = "PaymentBank4dirpay.rpt";
                                        Session["str_sfs"] = "{PaymentHead.paymentid}=" + rid;
                                    }
                                }
                            }
                        }

                        if (branchpay == "B")
                        {
                            //Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1143, 3, bid, str_mode + " /V " + txt_recp.Text);
                            Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1324, 3, bid, str_mode + " /V " + txt_recp.Text);
                        }
                        else
                        {
                           // Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1178, 3, bid, str_mode + " /V " + txt_recp.Text);
                            Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1321, 3, bid, str_mode + " /V " + txt_recp.Text);
                        }

                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Reciepts", str_Script, true);
                        //Session["str_sfs"] = str_sf;
                        //Session["str_sp"] = str_sp;
                    }
                    else
                    {
                        if (ddl_mode.Text != "")
                        {
                            if (str_mode == "C")
                            {
                                str_RptName = "PaymentCashReg.rpt";
                                Session["str_sfs"] = "{PaymentHead.mode}='C' and {PaymentHead.branchid}=" + bid + " and {PaymentHead.vouyear}=" + Vouyear;
                                Session["str_sp"] = "title=Cash Payment";
                            }
                            else
                            {
                                str_RptName = "PaymentBankReg.rpt";
                                Session["str_sfs"] = "{PaymentHead.mode}='B' and {PaymentHead.branchid}=" + bid + " and {PaymentHead.vouyear}=" + Vouyear;
                                Session["str_sp"] = "title=Bank Payment";
                            }

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Reciepts", str_Script, true);
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;

                            if (branchpay == "B")
                            {
                               // Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1143, 3, bid, str_mode + " / V / All ReceiptNo. ");
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1324, 3, bid, str_mode + " / V / All ReceiptNo. ");
                            }
                            else
                            {
                               // Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1178, 3, bid, str_mode + " / V / All ReceiptNo. ");
                                Log_Obj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1321, 3, bid, str_mode + " / V / All ReceiptNo. ");
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Mode')", true);
                            blnerr = true;
                            return;
                        }
                    }
                }
            }

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            del_Rows();
            string BranchName = Master_Branch.Getbranchname(bid);
            if (Session["rpType"].ToString() == "R")
            {
                if (str_mode != "PC")
                {
                    if (BranchName == "CORPORATE")
                    {
                        //Log_Obj.InsLogDetail(EmpId, 1186, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                        Log_Obj.InsLogDetail(EmpId, 1320, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                    }
                    else
                    {
                       // Log_Obj.InsLogDetail(EmpId, 1142, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                        Log_Obj.InsLogDetail(EmpId, 1323, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                    }
                }
                else
                {
                    if (BranchName == "CORPORATE")
                    {
                        Log_Obj.InsLogDetail(EmpId, 1187, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                    }
                    else
                    {
                        Log_Obj.InsLogDetail(EmpId, 1147, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                    }
                }
            }
            else
            {
                if (str_mode == "B")
                {
                   // Log_Obj.InsLogDetail(EmpId, 1143, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                    Log_Obj.InsLogDetail(EmpId, 1324, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                }
                else
                {
                    //Log_Obj.InsLogDetail(EmpId, 1178, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                    Log_Obj.InsLogDetail(EmpId, 1321, 4, BranchId, mode + "/D" + txt_recp.Text.ToString());
                }
            }
        }

        protected void del_Rows()
        {
            DataTable dtDelete = new DataTable();
            dtDelete = (DataTable)ViewState["CurrentData"];
            int index = Grid_Account.SelectedRow.RowIndex;

            if (Grid_Account.Rows[index].Cells[0].Text == "Customer")
            {
                if (txt_recp.Text != "" && rid != 0)
                {
                    ccid = Convert.ToInt32(Grid_detail.Rows[index].Cells[3].Text);
                    if (Session["rpType"].ToString() == "R")
                    {
                        Bank_Obj.DelCustChrgs(rid, ccid, "Cu");
                    }
                    else if (Session["rpType"].ToString() == "P")
                    {
                        Payment_Obj.DelCustChrgsPymt(rid);
                    }
                }
                if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                {
                    if (dtDelete.Rows.Count > 0)
                    {
                        if (index < dtDelete.Rows.Count)
                        {
                            dtDelete.Rows.Remove(dtDelete.Rows[index]);
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Deleted Successfully...');", true);
                            lbl_amountinword.Enabled = false;
                            for (int i = 0; i < Grid_Account.Rows.Count - 1; i++)
                            {
                                Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                            }
                            txt_total.Text = string.Format("{0:0.00}", Total);
                        }
                    }
                }
            }

            if (Grid_Account.Rows[index].Cells[0].Text == "Charge")
            {
                if (txt_recp.Text != "" && rid != 0)
                {
                    ccid = Convert.ToInt32(Grid_detail.Rows[index].Cells[3].Text);
                    if (Session["rpType"].ToString() == "R")
                    {
                        Bank_Obj.DelCustChrgs(rid, ccid, "Ch");
                    }
                    else if (Session["rpType"].ToString() == "P")
                    {
                        Payment_Obj.DelCustChrgsPymt(rid);
                    }
                }
                if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                {
                    if (index < dtDelete.Rows.Count)
                    {
                        dtDelete.Rows.Remove(dtDelete.Rows[index]);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Deleted Successfully...');", true);
                        lbl_amountinword.Enabled = false;
                        for (int i = 0; i < Grid_Account.Rows.Count - 1; i++)
                        {
                            Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                        }
                        txt_total.Text = string.Format("{0:0.00}", Total);
                    }
                }
            }

            if (Grid_Account.Rows[index].Cells[0].Text == "Excess / Short")
            {
                if (txt_recp.Text != "" && rid != 0)
                {
                    ccid = Convert.ToInt32(Grid_detail.Rows[index].Cells[3].Text);
                    if (Session["rpType"].ToString() == "R")
                    {
                        Bank_Obj.DelCustChrgs(rid, ccid, "Ch");
                    }
                    else if (Session["rpType"].ToString() == "P")
                    {
                        Payment_Obj.DelCustChrgsPymt(rid);
                    }
                }

                if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                {
                    if (index < dtDelete.Rows.Count)
                    {
                        dtDelete.Rows.Remove(dtDelete.Rows[index]);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Details Deleted Successfully...');", true);
                        lbl_amountinword.Enabled = false;
                        for (int i = 0; i < Grid_Account.Rows.Count - 1; i++)
                        {
                            Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                        }
                        txt_total.Text = string.Format("{0:0.00}", Total);
                    }
                }
            }

            if (dtDelete.Rows.Count > 0)
            {
                Grid_Account.DataSource = dtDelete;
                Grid_Account.DataBind();
                ViewState["CurrentData"] = dtDelete;
            }

            if (dtDelete.Rows.Count == 0)
            {
                Grid_Account.DataSource = Utility.Fn_GetEmptyDataTable();
                Grid_Account.DataBind();
                txt_total.Text = "";
                txt_amt.Text = "";
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                clear();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btn_cust_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cust.Text != "")
                {
                    for (int k = 0; k <= Grid_detail.Rows.Count - 1; k++)
                    {
                        if (Grid_detail.Rows[k].Cells[5].Text == "O")
                        {

                        }
                    }
                }

                if (txt_cust.Text != "")
                {
                    Boolean custexist = false;
                    int custid = Convert.ToInt32(hid_custid.Value);
                    for (int i = 0; i < Grid_Account.Rows.Count - 1; i++)
                    {
                        if (custid == Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text))
                        {
                            custexist = true;
                            return;
                        }
                    }
                    if (custexist == false)
                    {
                        int Custid = Cust_Obj.GetCustomerid(txt_cust.Text);
                        if (Custid != 0)
                        {
                            DataRow Dr;
                            DataTable dt = new DataTable();

                            if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                            {
                                dt = (DataTable)ViewState["CurrentData"];
                                Dr = dt.NewRow();
                                dt.Rows.Add(Dr);
                                Dr[0] = "Customer";
                                Dr[1] = txt_cust.Text;
                                Dr[2] = txt_cust_amt.Text;
                                Dr[3] = hid_custid.Value.ToString();
                            }
                            else
                            {
                                dt.Columns.Add("Type");
                                dt.Columns.Add("Customerortax");
                                dt.Columns.Add("Amount");
                                dt.Columns.Add("cid");
                                Dr = dt.NewRow();
                                dt.Rows.Add(Dr);
                                Dr[0] = "Customer";
                                Dr[1] = txt_cust.Text;
                                Dr[2] = txt_cust_amt.Text;
                                Dr[3] = hid_custid.Value.ToString();
                            }

                            Grid_Account.DataSource = dt;
                            Grid_Account.DataBind();
                            ViewState["CurrentData"] = dt;

                            for (int i = 0; i < Grid_Account.Rows.Count; i++)
                            {
                                Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                            }
                            txt_total.Text = string.Format("{0:0.00}", Total);

                            if (Session["rptype"].ToString() == "R")
                            {
                                lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                            }

                            txt_cust.Text = "";
                            txt_cust_amt.Text = "";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Check Customer Name');", true);
                            blnerr = true;
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Customer Already Exist');", true);
                        blnerr = true;
                        return;
                    }
                }
                else if (txt_cust_amt.Text != "")
                {
                    double dblrecamt = 0.0;
                    dblrecamt = Convert.ToDouble(txt_cust_amt.Text);
                    //int index = selectedRowIndex;
                    //Grid_Account.Rows[index].Cells[2].Text = dblrecamt.ToString();

                    //for (int r = 0; r <= Grid_Account.Rows.Count - 1;r++ )
                    //{
                    //    if (Grid_Account.Rows[r].Cells[3].Text == hid_custid.Value)
                    //    {
                    //        Grid_Account.Rows[r].Cells[2].Text = dblrecamt.ToString();
                    //    }
                    //}                        

                    txt_total.Text = "";
                    double totalamt = 0.0;
                    for (int i = 0; i < Grid_Account.Rows.Count; i++)
                    {
                        totalamt = totalamt + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                    }
                    txt_total.Text = string.Format("{0:0.00}", totalamt);
                    txt_cust_amt.Enabled = false;
                    btn_cust_add.Enabled = false;
                    txt_cust_amt.Text = "";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void btn_deduct_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_deduction.Text != "" && txt_dedu_amt.Text != "")
                {
                    ccid = Charge_Obj.GetChargeid(txt_deduction.Text);
                    if (ccid != 0)
                    {
                        if (lbl_head.Text == "Payments")
                        {
                            for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                            {
                                if (Grid_detail.Rows[i].Cells[1].Text == txt_dedu_amt.Text)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alet('Charge Already exists')", true);
                                    blnerr = true;
                                    return;
                                }
                            }
                        }

                        DataRow Dr;
                        DataTable dt_dedu = new DataTable();
                        int Count = 0;

                        if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                        {
                            dt_dedu = (DataTable)ViewState["CurrentData"];
                            Count = dt_dedu.Rows.Count;
                        }

                        if (Count == 0)
                        {
                            dt_dedu.Columns.Add("Type");
                            dt_dedu.Columns.Add("Customerortax");
                            dt_dedu.Columns.Add("Amount");
                            dt_dedu.Columns.Add("cid");
                            Dr = dt_dedu.NewRow();
                            dt_dedu.Rows.Add(Dr);
                            Dr[0] = "Charge";
                            Dr[1] = txt_deduction.Text;

                            if (lbl_head.Text == "FY End Back Dated Payments")
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            else
                            {


                                //if ((txt_deduction.Text == "BANK CHARGES") || (txt_deduction.Text == "BANK INTEREST"))
                                //{
                                //    Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                //    txt_dedu_amt.Text = Dr[2].ToString();
                                //}
                                //else
                                //{
                                //    Dr[2] = string.Format("{0:-0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                //    txt_dedu_amt.Text = Dr[2].ToString();
                                //}


                                if(ddl_mode.Text == "Petty Cash")
                                {
                                    Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                    txt_dedu_amt.Text = Dr[2].ToString();
                                }
                                else
                                {
                                    if ((txt_deduction.Text == "BANK CHARGES") || (txt_deduction.Text == "BANK INTEREST"))
                                    {
                                        Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                        txt_dedu_amt.Text = Dr[2].ToString();
                                    }
                                    else
                                    {
                                        Dr[2] = string.Format("{0:-0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                        txt_dedu_amt.Text = Dr[2].ToString();
                                    }
                                }
                            }
                            Dr[3] = ccid;
                        }
                        else
                        {
                            Dr = dt_dedu.NewRow();
                            dt_dedu.Rows.Add(Dr);
                            Dr[0] = "Charge";
                            Dr[1] = txt_deduction.Text;
                            if (lbl_head.Text == "FY End Back Dated Payments")
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            else
                            {
                                //if ((txt_deduction.Text == "BANK CHARGES") || (txt_deduction.Text == "BANK INTEREST"))
                                //{
                                //    Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                //    txt_dedu_amt.Text = Dr[2].ToString();
                                //}
                                //else
                                //{
                                //    Dr[2] = string.Format("{0:-0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                //    txt_dedu_amt.Text = Dr[2].ToString();
                                //}



                                if (ddl_mode.Text == "Petty Cash")
                                {
                                    Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                    txt_dedu_amt.Text = Dr[2].ToString();
                                }
                                else
                                {
                                    if ((txt_deduction.Text == "BANK CHARGES") || (txt_deduction.Text == "BANK INTEREST"))
                                    {
                                        Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                        txt_dedu_amt.Text = Dr[2].ToString();
                                    }
                                    else
                                    {
                                        Dr[2] = string.Format("{0:-0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                        txt_dedu_amt.Text = Dr[2].ToString();
                                    }
                                }
                            }
                            Dr[3] = ccid;
                        }

                        Grid_Account.DataSource = dt_dedu;
                        Grid_Account.DataBind();
                        ViewState["CurrentData"] = dt_dedu;

                        txt_deduction.Text = "";
                        txt_dedu_amt.Text = "";
                        txt_excess_amt.Focus();

                        double Total = 0;
                        for (int i = 0; i < Grid_Account.Rows.Count; i++)
                        {
                            Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                        }
                        txt_total.Text = string.Format("{0:0.00}", Total);

                        if (Session["rptype"].ToString() == "R")
                        {
                            lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Check Charge Name');", true);
                        blnerr = true;
                        return;
                    }
                }
                else
                {
                    //txt_excess_amt.Focus();                
                    if (txt_deduction.Text != "")
                    {
                        if (txt_dedu_amt.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Enter the Tax deduction amount');", true);
                            txt_dedu_amt.Focus();
                            blnerr = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void btn_short_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_excess_amt.Text.Trim().Length > 0)
                {
                    DataTable dt_excess = new DataTable();
                    DataRow Dr = dt_excess.NewRow();
                    int Count = 0;

                    if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                    {
                        dt_excess = (DataTable)ViewState["CurrentData"];
                        Count = dt_excess.Rows.Count;
                    }

                    if (Count == 0)
                    {
                        Dr = dt_excess.NewRow();
                        dt_excess.Rows.Add(Dr);
                        dt_excess.Columns.Add("Type");
                        dt_excess.Columns.Add("Customerortax");
                        dt_excess.Columns.Add("Amount");
                        dt_excess.Columns.Add("cid");
                        Dr[0] = "Excess / Short";
                        Dr[1] = "";
                        for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                        {
                            if (lbl_head.Text == "FY End Back Dated Payments")
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                            }
                            else
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                                txt_excess_amt.Text = Dr[2].ToString();
                            }
                        }
                    }
                    else
                    {
                        Dr = dt_excess.NewRow();
                        dt_excess.Rows.Add(Dr);
                        Dr[0] = "Excess / Short";
                        Dr[1] = "";
                        for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                        {
                            if (lbl_head.Text == "FY End Back Dated Payments")
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                            }
                            else
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                                txt_excess_amt.Text = Dr[2].ToString();
                            }
                        }
                    }

                    Grid_Account.DataSource = dt_excess;
                    Grid_Account.DataBind();
                    ViewState["CurrentData"] = dt_excess;

                    txt_excess_amt.Text = "";
                    double Total = 0;
                    for (int i = 0; i < Grid_Account.Rows.Count; i++)
                    {
                        Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                    }

                    txt_total.Text = string.Format("{0:0.00}", Total);
                    if (Session["rptype"].ToString() == "R")
                    {
                        lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                    }
                    txt_excess_amt.Text = "";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void ddl_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_mode.SelectedItem.Text != "")
            {
                if (Session["rptype"].ToString() == "R")
                {
                    btn_deduct_add.Enabled = true;
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    btn_deduct_add.Enabled = false;
                    if (ddl_branch.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Branch cannot be blank')", true);
                        ddl_branch.Focus();
                        blnerr = true;
                        return;
                    }
                }

                if (ddl_mode.Text == "Cash" || ddl_mode.Text == "Petty Cash")
                {
                    if (ddl_mode.Text == "Cash")
                    {
                        mode = "C";
                        if (Session["rptype"] == "P" && Convert.ToInt32(Session["LoginBranchId"]) == 4)
                        {
                            Hydvis.Visible = true;

                        }
                        else
                        {
                            Hydvis.Visible = false;
                        }
                        str_mode = mode.ToString();
                    }
                    else
                    {
                        mode = "P";
                        str_mode = mode.ToString();
                    }
                    txt_cheque.Text = "";
                    txt_cheque.Enabled = false;
                    txt_bank.Text = "";
                    txt_bank.Enabled = false;
                    txt_branch1.Text = "";
                    txt_branch1.Enabled = false;
                    txt_cheqdate.Enabled = false;
                    lnk_cheque.Enabled = false;
                    CTDisable();

                    if (Session["rptype"].ToString() == "P")
                    {
                        txt_deduction.Enabled = true;
                        txt_dedu_amt.Enabled = true;
                        txt_refno.Visible = true;
                        txt_fvr.Visible = false;
                        lbl_fvr.Visible = false;
                        Chk_Account.Enabled = false;
                        divPayment.Visible = false;
                    }
                }
                else
                {
                    if (ddl_mode.Text == "Cheque/DD")
                    {
                        mode = "B";
                    }
                    if (Session["rpType"].ToString() == "P")
                    {
                        txt_branch1.Text = "CHENNAI";
                    }

                    txt_cheque.ReadOnly = false;
                    txt_bank.ReadOnly = false;
                    txt_branch1.ReadOnly = false;
                    txt_cheqdate.Enabled = true;
                    lnk_cheque.Enabled = true;
                    CTEnable();

                    if (Session["rptype"].ToString() == "P")
                    {
                        txt_deduction.Enabled = true;
                        txt_dedu_amt.Enabled = true;
                        txt_fvr.Visible = true;
                        txt_refno.Visible = false;
                        lbl_refno.Visible = false;
                        Chk_Account.Enabled = true;
                    }

                    if (lbl_title.Text == "PAYMENT  VOUCHER")
                    {
                        divPayment.Visible = true;
                    }

                    txt_dedu_amt.Enabled = true;
                    txt_deduction.Enabled = true;
                }
                if (ddl_mode.SelectedItem.Text == "NEFT/RTGS" && Session["rptype"].ToString() == "R")
                {
                    int amt = 0;
                    int countneft = 0;
                    countneft = Bank_Obj.sp_receiptheadneft(Convert.ToInt32(Session["LoginBranchid"].ToString()), "B", "Y");
                    countneft = countneft + 1;
                    txt_cheque.Text = "NEFT" + Convert.ToInt32(countneft).ToString();
                }
                if (ddl_mode.SelectedItem.Text == "NEFT/RTGS" && Session["rptype"].ToString() == "P")
                {
                    int amt = 0;
                    int countneft = 0;
                    countneft = Bank_Obj.sp_paymentheadneft(Convert.ToInt32(Session["LoginBranchid"].ToString()), "B", "Y");
                    countneft = countneft + 1;
                    txt_cheque.Text = "NEFT" + Convert.ToInt32(countneft).ToString();
                }
                btn_short_add.Enabled = true;
                btn_cust_add.Enabled = true;
                btn_deduct_add.Enabled = true;
                btn_back.ToolTip = "Cancel";
            }
        }


        private void ddl_mode_change()
        {
            try
            {
                DataTable DtTemp = new DataTable();
                int Vouyear = Convert.ToInt32(txt_recpdate.Text);
                int RowsCount = 0;

                mode_set();

                if (blnerr == true)
                {
                    return;
                }

                if (txt_recp.Text != "")
                {
                    recno = Convert.ToInt32(txt_recp.Text);
                    if (Session["rptype"].ToString() == "R")
                    {
                        rid = Bank_Obj.GetRecrid(recno, bid, Convert.ToChar(mode), Vouyear);
                        DtTemp = Bank_Obj.GetRecptHead(recno, bid, Convert.ToChar(mode), Vouyear);
                        DataTable dtdeposit = new DataTable();
                        // dtdeposit = Bank_Obj.GetSlipDetailsFA("", bid, str_mode);
                        if (DtTemp.Rows.Count > 0)
                        {
                            // int bankid = Convert.ToInt32(DtTemp.Rows[0]["bank"].ToString());
                            txt_depositbank.Text = DtTemp.Rows[0]["depositbank"].ToString();
                        }
                        Hid_Rid.Value = rid.ToString();
                    }
                    else
                    {
                        BranchId = Emp_Obj.GetBranchId(did, ddl_branch.SelectedItem.Text);
                        rid = Payment_Obj.GetPaymentid(recno, BranchId, Convert.ToChar(mode), Vouyear);
                        DtTemp = Payment_Obj.GetPaymentHead(recno, BranchId, Convert.ToChar(mode), Vouyear);
                        Hid_Rid.Value = rid.ToString();
                        if (DtTemp.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(DtTemp.Rows[0]["vis"].ToString()))
                            {
                                string vis = "";
                                vis = DtTemp.Rows[0]["vis"].ToString();

                                if (bid == 4)
                                {
                                    if (vis == "Y")
                                    {
                                        chk_visak.Checked = true;
                                        chk_visak.Enabled = false;
                                        chk_hyde.Enabled = false;
                                    }
                                    else if (vis == "N")
                                    {
                                        chk_hyde.Checked = true;
                                        chk_hyde.Enabled = false;
                                        chk_visak.Enabled = false;
                                    }
                                }
                            }
                        }
                    }

                    if (DtTemp.Rows.Count == 0)
                    {
                        if (Session["rptype"].ToString() == "R")
                        {
                            ScriptManager.RegisterStartupScript(ddl_mode, typeof(DropDownList), "Receipts", "alertify.alert('Invalid Receipt #');", true);
                            return;
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            ScriptManager.RegisterStartupScript(ddl_mode, typeof(DropDownList), "Payments", "alertify.alert('Invalid Payment #');", true);
                            return;
                        }
                    }

                    txt_recp.Text = DtTemp.Rows[0][1].ToString();
                    txt_date.Text = Utility.fn_ConvertDate(DtTemp.Rows[0][2].ToString());
                    string Mode = DtTemp.Rows[0][3].ToString();
                    ddl_mode.Enabled = false;
                    btn_delete.Enabled = false;

                    if (str_mode == "C")
                    {
                        CTDisable();
                        txt_refno.Text = DtTemp.Rows[0][20].ToString();
                    }
                    else if (str_mode == "B")
                    {
                        txt_cheque.Text = DtTemp.Rows[0][10].ToString();
                        int BankId = Convert.ToInt32(DtTemp.Rows[0][8].ToString());
                        txt_bank.Text = Bank_Obj.GetBankName(BankId);
                        txt_branch1.Text = DtTemp.Rows[0][9].ToString();
                        //txt_cheqdate.Text = Utility.fn_ConvertDate(DtTemp.Rows[0][11].ToString());
                        txt_cheqdate.Text = txt_date.Text;
                        CTEnable();
                        if (Session["rptype"].ToString() == "P")
                        {
                            if (DtTemp.Rows[0][14].ToString() == "C")
                            {
                                Chk_Account.Checked = true;
                            }

                            if (DtTemp.Rows[0][15].ToString() != "")
                            {
                                int ApprovBy = Convert.ToInt32(DtTemp.Rows[0][15].ToString());
                            }

                            if (DtTemp.Rows[0]["dirpay"].ToString() == "Y")
                            {
                                chkDirectPay.Checked = true;
                            }
                            else
                            {
                                chkDirectPay.Checked = false;
                            }
                        }
                    }

                    txt_recieve.Text = DtTemp.Rows[0][6].ToString();
                    txt_fvr.Text = DtTemp.Rows[0]["customername"].ToString();

                    if (txt_recieve.Text == "")
                    {
                        txt_recieve.Text = txt_fvr.Text;
                    }

                    txt_amt.Text = string.Format("{0:0.00}", DtTemp.Rows[0][7].ToString());
                    txt_narration.Text = DtTemp.Rows[0][12].ToString();

                    DataTable dt_Customer = new DataTable();
                    DataTable dt_Cust_Pay = new DataTable();

                    if (Session["rptype"].ToString() == "R")
                    {
                        dt_Customer = Bank_Obj.GetRecptCust(rid);
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        dt_Customer = Payment_Obj.GetPaymentCust(rid);
                    }

                    RowsCount = dt_Cust_Pay.Rows.Count;

                    if (dt_Customer.Rows.Count > 0)
                    {
                        if (RowsCount == 0)
                        {
                            dt_Cust_Pay.Columns.Add("Type", typeof(string));
                            dt_Cust_Pay.Columns.Add("Customerortax", typeof(string));
                            dt_Cust_Pay.Columns.Add("Amount", typeof(string));
                            dt_Cust_Pay.Columns.Add("cid", typeof(string));
                        }

                        for (int i = 0; i <= dt_Customer.Rows.Count - 1; i++)
                        {
                            DataRow dtrow = dt_Cust_Pay.NewRow();
                            dtrow["Type"] = "Customer";
                            dtrow["Customerortax"] = dt_Customer.Rows[i][0].ToString();
                            dtrow["Amount"] = dt_Customer.Rows[i][1].ToString();
                            dtrow["cid"] = "";
                            dt_Cust_Pay.Rows.Add(dtrow);

                            ViewState["CurrentData"] = dt_Cust_Pay;
                        }
                    }

                    DataTable dt_Charge = new DataTable();
                    DataTable dt_Charge_Pay = new DataTable();

                    if (Session["rptype"].ToString() == "R")
                    {
                        dt_Charge = Bank_Obj.GetRecptChrg(rid);
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        dt_Charge = Payment_Obj.GetPaymentChrg(rid);
                    }

                    if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                    {
                        dt_Charge_Pay = (DataTable)ViewState["CurrentData"];
                        RowsCount = dt_Charge_Pay.Rows.Count;
                    }

                    if (dt_Charge.Rows.Count > 0)
                    {
                        if (RowsCount == 0)
                        {
                            if (dt_Charge_Pay.Rows.Count == 0)
                            {
                                dt_Charge_Pay.Columns.Add("Type", typeof(string));
                                dt_Charge_Pay.Columns.Add("Customerortax", typeof(string));
                                dt_Charge_Pay.Columns.Add("Amount", typeof(string));
                                dt_Charge_Pay.Columns.Add("cid", typeof(string));
                            }
                        }

                        for (int i = 0; i <= dt_Charge.Rows.Count - 1; i++)
                        {
                            DataRow dtrow = dt_Charge_Pay.NewRow();
                            dtrow["Type"] = "Charge";
                            dtrow["Customerortax"] = dt_Charge.Rows[i][0].ToString();
                            dtrow["Amount"] = dt_Charge.Rows[i][1].ToString();
                            dtrow["cid"] = "";
                            dt_Charge_Pay.Rows.Add(dtrow);

                            ViewState["CurrentData"] = dt_Charge_Pay;
                        }
                    }

                    DataTable dt_Excess = new DataTable();
                    DataTable dt_Excess_Pay = new DataTable();

                    if (Session["rptype"].ToString() == "R")
                    {
                        dt_Excess = Bank_Obj.GetES(rid);
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        dt_Excess = Payment_Obj.GetPaymentES(rid);
                    }

                    if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
                    {
                        dt_Excess_Pay = (DataTable)ViewState["CurrentData"];
                        RowsCount = dt_Excess_Pay.Rows.Count;
                    }

                    if (dt_Excess.Rows.Count > 0)
                    {
                        if (RowsCount == 0)
                        {
                            if (dt_Excess_Pay.Rows.Count == 0)
                            {
                                dt_Excess_Pay.Columns.Add("Type", typeof(string));
                                dt_Excess_Pay.Columns.Add("Customerortax", typeof(string));
                                dt_Excess_Pay.Columns.Add("Amount", typeof(string));
                                dt_Excess_Pay.Columns.Add("cid", typeof(string));
                            }
                        }
                        for (int i = 0; i <= dt_Excess.Rows.Count - 1; i++)
                        {
                            DataRow dtrow = dt_Excess_Pay.NewRow();
                            dtrow["Type"] = "Excess / Short";
                            dtrow["Customerortax"] = "";
                            dtrow["Amount"] = dt_Excess.Rows[i][0].ToString();
                            dtrow["cid"] = "";
                            dt_Excess_Pay.Rows.Add(dtrow);

                            ViewState["CurrentData"] = dt_Excess_Pay;
                        }
                    }

                    DataTable dt_Fnl_Grid = new DataTable();
                    dt_Fnl_Grid = (DataTable)ViewState["CurrentData"];

                    if (dt_Fnl_Grid.Rows.Count > 0)
                    {
                        Grid_Account.DataSource = dt_Fnl_Grid;
                        Grid_Account.DataBind();
                    }

                    if (Grid_Account.Rows.Count > 0)
                    {
                        Total = 0;
                        for (int i = 0; i < Grid_Account.Rows.Count; i++)
                        {
                            Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                        }
                        txt_total.Text = string.Format("{0:0.00}", Total);
                    }

                    if (Session["rptype"].ToString() == "R")
                    {
                        lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                    }

                    DataTable dtInvoive = new DataTable();
                    DataTable dtGrid_det = new DataTable();

                    if (rid != 0)
                    {
                        RPtype = Session["rptype"].ToString();
                        dtInvoive = Bank_Obj.GetRAInvoiceToShow(rid, Convert.ToChar(RPtype));
                        if (dtInvoive.Rows.Count > 0)
                        {
                            Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
                            Grid_detail.DataBind();
                            dtGrid_det = new DataTable();
                            dtGrid_det.Columns.Add("branchHide", typeof(string));
                            dtGrid_det.Columns.Add("branch", typeof(string));
                            dtGrid_det.Columns.Add("invoiceno", typeof(string));
                            dtGrid_det.Columns.Add("iamount", typeof(string));
                            dtGrid_det.Columns.Add("ramount", typeof(string));
                            dtGrid_det.Columns.Add("voutype", typeof(string));
                            dtGrid_det.Columns.Add("vouno", typeof(string));
                            dtGrid_det.Columns.Add("tds", typeof(string));
                            dtGrid_det.Columns.Add("ravouyear", typeof(string));
                            dtGrid_det.Columns.Add("ltype", typeof(string));
                            dtGrid_det.Columns.Add("Cust_Id", typeof(string));

                            dtGrid_det.Columns.Add("vendorrefno", typeof(string));
                            dtGrid_det.Columns.Add("vendorrefdate", typeof(string));
                            dtGrid_det.Columns.Add("jlid", typeof(string));

                            for (int i = 0; i <= dtInvoive.Rows.Count - 1; i++)
                            {
                                DataRow dtrow = dtGrid_det.NewRow();
                                dtrow["branchHide"] = dtInvoive.Rows[i][0].ToString();
                                dtrow["branch"] = dtInvoive.Rows[i][1].ToString();
                                if (dtInvoive.Rows[i][2].ToString() != "0")
                                {
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "I") dtrow["invoiceno"] = "INV - " + dtInvoive.Rows[i][2].ToString();
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "D") dtrow["invoiceno"] = "OSDN - " + dtInvoive.Rows[i][2].ToString();
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "V") dtrow["invoiceno"] = "DN - " + dtInvoive.Rows[i][2].ToString();
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "X") dtrow["invoiceno"] = "ADN - " + dtInvoive.Rows[i][2].ToString();
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "P") dtrow["invoiceno"] = "CNOps - " + dtInvoive.Rows[i][2].ToString();
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "C") dtrow["invoiceno"] = "OSCN - " + dtInvoive.Rows[i][2].ToString();
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "E") dtrow["invoiceno"] = "CN - " + dtInvoive.Rows[i][2].ToString();
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "S") dtrow["invoiceno"] = "ACN - " + dtInvoive.Rows[i][2].ToString();
                                    if (dtInvoive.Rows[i][5].ToString().Trim() == "B") dtrow["invoiceno"] = "BOS - " + dtInvoive.Rows[i][2].ToString();
                                }
                                else
                                {
                                    if (dtInvoive.Rows[i]["voutype"].ToString() == "J")
                                    {
                                        dtrow["invoiceno"] = "J - " + dtInvoive.Rows[i]["jrefno"].ToString();
                                    }
                                    else
                                    {
                                        dtrow["invoiceno"] = "On Account";
                                    }
                                }
                                dtrow["iamount"] = dtInvoive.Rows[i][3].ToString();
                                dtrow["ramount"] = dtInvoive.Rows[i][4].ToString();
                                dtrow["Cust_Id"] = "";
                                dtrow["vendorrefno"] = dtInvoive.Rows[i]["vendorrefno"].ToString();
                                dtrow["vendorrefdate"] = dtInvoive.Rows[i]["vendorrefdate"].ToString();
                                dtrow["jlid"] = "";
                                dtGrid_det.Rows.Add(dtrow);
                                Grid_detail.DataSource = dtGrid_det;
                                Grid_detail.DataBind();
                            }
                        }
                    }

                    btn_back.ToolTip = "Cancel";
                    if (txt_recp.Text != "")
                    {
                        save_id.Visible = false;
                        btn_save.Visible = false;
                        btn_save.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                else if (Session["rptype"].ToString() == "R")
                {
                    ScriptManager.RegisterStartupScript(ddl_mode, typeof(DropDownList), "Receipts", "alertify.alert('Invalid Receipt #');", true);
                    return;
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    ScriptManager.RegisterStartupScript(ddl_mode, typeof(DropDownList), "Payments", "alertify.alert('Invalid Payment #');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void ddl_mode_TextChanged(object sender, EventArgs e)
        {
            if (txt_recp.Text != "")
            {
                ddl_mode_change();
            }
        }

        private void mode_set()
        {
            if (ddl_mode.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Mode');", true);
                ddl_mode.Focus();
                blnerr = true;
                return;
            }

            if (ddl_mode.Text == "Cash" || ddl_mode.Text == "Petty Cash")
            {
                if (ddl_mode.Text == "Cash")
                {
                    mode = "C";
                    str_mode = mode.ToString();
                }
                else if (ddl_mode.Text == "Petty Cash")
                {
                    mode = "P";
                    str_mode = mode.ToString();
                }
            }
            else
            {
                if (ddl_mode.Text == "Cheque/DD" || ddl_mode.Text == "NEFT/RTGS")
                {
                    mode = "B";
                    str_mode = mode.ToString();
                }
            }

            if (ddl_branch.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert(Branch cannot be blank)", true);
                ddl_branch.Focus();
                blnerr = true;
                return;
            }
        }

        private void CTEnable()
        {
            txt_cheqdate.Enabled = true;
            txt_cheque.Enabled = true;
            txt_bank.Enabled = true;
            txt_branch1.Enabled = true;
        }

        private void CTDisable()
        {
            txt_cheqdate.Enabled = false;
            txt_cheque.Enabled = false;
            txt_bank.Enabled = false;
            txt_branch1.Enabled = false;
        }

        protected void lnk_cheque_Click(object sender, EventArgs e)
        {
            LoadCheque();
        }

        protected void Grid_Cheque_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_Cheque, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grid_Cheque_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grid_Cheque.Rows.Count > 0)
                {
                    int index;
                    DataTable dtcheque = new DataTable();
                    index = Grid_Cheque.SelectedRow.RowIndex;
                    int cheq_no = Convert.ToInt32(Grid_Cheque.Rows[index].Cells[4].Text);
                    hid_cheque.Value = Grid_Cheque.Rows[index].Cells[4].Text;
                    BranchId = Emp_Obj.GetBranchId(did, ddl_branch.SelectedItem.Text);
                    dtcheque = NotOverChq_Obj.SelNotOverCheque(cheq_no, BranchId);

                    if (dtcheque.Rows.Count > 0)
                    {
                        txt_cheque.Text = dtcheque.Rows[0]["chequeno"].ToString();
                        txt_bank.Text = dtcheque.Rows[0]["BankName"].ToString();
                        txt_branch1.Text = dtcheque.Rows[0]["bbranch"].ToString();
                        //txt_cheqdate.Text = Utility.fn_ConvertDate(dtcheque.Rows[0]["chqdate"].ToString());
                        txt_cheqdate.Text = txt_date.Text;
                        txt_recieve.Text = dtcheque.Rows[0]["Customername"].ToString();
                        txt_amt.Text = string.Format("{0:0.00}", dtcheque.Rows[0]["amount"]);
                        txt_fvr.Text = dtcheque.Rows[0]["fvrname"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void Grid_Cheque_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_Cheque.PageIndex = e.NewPageIndex;
            LoadCheque();
        }

        protected void Grid_Cheque_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "Select")
                {
                    foreach (GridViewRow r in Grid_Cheque.Rows)
                    {
                        if (r.RowType == DataControlRowType.DataRow)
                        {
                            for (int ColumnIndex = 0; ColumnIndex < r.Cells.Count; ColumnIndex++)
                            {
                                r.Cells[ColumnIndex].Attributes["style"] += "background-color:White;";
                            }
                        }
                    }
                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    SelectGridCheque(selectedRowIndex);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        public void SelectGridCheque(int selectedRowIndex)
        {
            int index = selectedRowIndex;
            DataTable dtcheque = new DataTable();
            hid_cheque.Value = Grid_Cheque.Rows[index].Cells[4].Text;
            BranchId = Emp_Obj.GetBranchId(did, ddl_branch.SelectedItem.Text);
            dtcheque = NotOverChq_Obj.SelNotOverCheque(Convert.ToInt32(hid_cheque.Value), BranchId);

            if (dtcheque.Rows.Count > 0)
            {
                txt_cheque.Text = dtcheque.Rows[0]["chequeno"].ToString();
                txt_bank.Text = dtcheque.Rows[0]["BankName"].ToString();
                txt_branch1.Text = dtcheque.Rows[0]["bbranch"].ToString();
                //txt_cheqdate.Text = Utility.fn_ConvertDate(dtcheque.Rows[0]["chqdate"].ToString());
                txt_cheqdate.Text = txt_date.Text;
                txt_recieve.Text = dtcheque.Rows[0]["Customername"].ToString();
                txt_amt.Text = string.Format("{0:0.00}", dtcheque.Rows[0]["amount"]);
                txt_fvr.Text = dtcheque.Rows[0]["fvrname"].ToString();
            }
        }

        protected void LoadCheque()
        {
            try
            {
                if (ddl_branch.SelectedItem.ToString() != "Branch")
                {
                    DataTable dt = new DataTable();
                    BranchId = Emp_Obj.GetBranchId(did, ddl_branch.SelectedItem.Text);
                    dt = Bank_Obj.Getnotovercheque4payment(BranchId);
                    if (dt.Rows.Count > 0)
                    {
                        ViewState["ChequeDet"] = dt;
                        Grid_Cheque.DataSource = dt;
                        Grid_Cheque.DataBind();
                        POPUP1.Visible = true;
                        this.programmaticModalPopup.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cheque, typeof(LinkButton), "Payment", "alertify.alert('No Records Found');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(lnk_cheque, typeof(LinkButton), "Payment", "alertify.alert('Please Select the Branch Name');", true);
                    blnerr = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void Grid_detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_detail.PageIndex = e.NewPageIndex;
            DataTable dtPage = new DataTable();
            dtPage = (DataTable)ViewState["dtPayment"];

            Grid_detail.DataSource = dtPage;
            Grid_detail.DataBind();
        }

        protected void txt_cheque_TextChanged(object sender, EventArgs e)
        {
            int Branch_Id = Emp_Obj.GetBranchId(did, ddl_branch.SelectedItem.ToString());
            DataTable dtCheque = new DataTable();

            try
            {
                dtCheque = NotOverChq_Obj.SelNotOverCheque4ChequeNo(txt_cheque.Text, did);
                if (dtCheque.Rows.Count > 0)
                {
                    txt_bank.Text = dtCheque.Rows[0]["BankName"].ToString();
                    txt_cheque.Text = dtCheque.Rows[0]["chequeno"].ToString();
                    txt_cheqdate.Text = Utility.fn_ConvertDate(Convert.ToDateTime(dtCheque.Rows[0]["chqdate"].ToString()).ToShortDateString());
                    txt_branch1.Text = dtCheque.Rows[0]["bbranch"].ToString();
                    txt_recieve.Text = dtCheque.Rows[0]["Customername"].ToString();
                    hid_customerid.Value = dtCheque.Rows[0]["customerid"].ToString();
                    txt_amt.Text = string.Format("{0:0.00}", dtCheque.Rows[0]["amount"]);
                    txt_fvr.Text = dtCheque.Rows[0]["fvrname"].ToString();
                    hid_cheque.Value = dtCheque.Rows[0]["nono"].ToString();
                }
                txt_bank.Focus();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void Grid_Amount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_Amount, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grid_Amount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ModalPopup_amount.Show();
        }

        protected void Grid_Amount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_Amount.PageIndex = e.NewPageIndex;
            DataTable dtPage = new DataTable();
            dtPage = ViewState["Grid_Amount"] as DataTable;

            Grid_Amount.DataSource = dtPage;
            Grid_Amount.DataBind();
        }

        protected void lnk_amount_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_head.Text == "FY End Back Dated Payments")
                {
                    int Div_Id = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                    if (ddl_branch.SelectedItem.ToString() != "Branch")
                    {
                        BranchId = Emp_Obj.GetBranchId(Div_Id, ddl_branch.SelectedItem.Text);
                        DataTable dtp = new DataTable();
                        dtp = Payment_Obj.GetChqCOApprovedList(BranchId);
                        if (dtp.Rows.Count > 0)
                        {
                            Grid_Amount.DataSource = dtp;
                            Grid_Amount.DataBind();
                            Panel2.Visible = true;
                            this.ModalPopup_amount.Show();
                            txt_cust.Enabled = false;
                            txt_cust_amt.Enabled = false;
                            btn_cust_add.Enabled = false;
                            ViewState["Grid_Amount"] = dtp;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(lnk_amount, typeof(LinkButton), "Payment", "alertify.alert('Data is not available');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_amount, typeof(LinkButton), "Payment", "alertify.alert('Please Select the Branch Name');", true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        private void cust()
        {
            DataTable dtINV = new DataTable();
            DataTable dtj = new DataTable();
            int Customer_Id, a = 0, b = 0;
            bool custexist = false;

            if (txt_cust.Text != "")
            {
                if (Grid_detail.Rows.Count > 0)
                {
                    Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
                    //\-\*'nghb mttnk,jhujhujhujhujhujhujhujhujhujhujhu\h ,k               
                }
                if (hid_custid.Value != "")
                {
                    DataTable dttemp3 = new DataTable();
                    Customer_Id = Convert.ToInt32(hid_custid.Value);
                    dtINV = Bank_Obj.GetInvRecptDtlslv(Customer_Id, did);
                    if (Customer_Id == 965 && ddl_branch.SelectedItem.Text == "HYDERABAD")
                    {
                        Hydvis.Visible = true;

                    }
                    else
                    {
                        Hydvis.Visible = false;

                    }
                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dttemp3 = (DataTable)ViewState["dtPayment"];
                        a = dttemp3.Rows.Count;
                    }

                    if (dtINV.Rows.Count > 0)
                    {
                        if (a == 0)
                        {
                            dttemp3.Columns.Add("branchHide", typeof(string));
                            dttemp3.Columns.Add("branch", typeof(string));
                            dttemp3.Columns.Add("invoiceno", typeof(string));
                            dttemp3.Columns.Add("iamount", typeof(string));
                            dttemp3.Columns.Add("ramount", typeof(string));
                            dttemp3.Columns.Add("voutype", typeof(string));
                            dttemp3.Columns.Add("vouno", typeof(string));
                            dttemp3.Columns.Add("tds", typeof(string));
                            dttemp3.Columns.Add("ravouyear", typeof(string));
                            dttemp3.Columns.Add("ltype", typeof(string));
                            dttemp3.Columns.Add("Cust_Id", typeof(string));
                            dttemp3.Columns.Add("vendorrefno", typeof(string));
                            dttemp3.Columns.Add("vendorrefdate", typeof(string));
                            dttemp3.Columns.Add("jlid", typeof(string));
                        }

                        for (int i = 0; i < dtINV.Rows.Count; i++)
                        {
                            DataRow dtrow = dttemp3.NewRow();
                            dtrow["branchHide"] = dtINV.Rows[i][0].ToString();
                            dtrow["branch"] = dtINV.Rows[i][1].ToString();

                            if (dtINV.Rows[i][5].ToString().Trim() == "I")
                            {
                                dtrow["invoiceno"] = "SI - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "D")
                            {
                                dtrow["invoiceno"] = "OSSI - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "V")
                            {
                                dtrow["invoiceno"] = "DN - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString() == "X")
                            {
                                dtrow["invoiceno"] = "ADN - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "P")
                            {
                                dtrow["invoiceno"] = "PI - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "C")
                            {
                                dtrow["invoiceno"] = "OSPI - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "E")
                            {
                                dtrow["invoiceno"] = "CN - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "S")
                            {
                                dtrow["invoiceno"] = "ACN - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "B")
                            {
                                dtrow["invoiceno"] = "BOS - " + dtINV.Rows[i][2].ToString();
                            }

                            else if (dtINV.Rows[i][5].ToString().Trim() == "F") // Vino [05-03-2024]
                            {
                                dtrow["invoiceno"] = "SI OC - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "G")
                            {
                                dtrow["invoiceno"] = "PI OC - " + dtINV.Rows[i][2].ToString();
                            }
                            else if (dtINV.Rows[i][5].ToString().Trim() == "H")
                            {
                                dtrow["invoiceno"] = "BS OC - " + dtINV.Rows[i][2].ToString();
                            }

                            dtrow["iamount"] = dtINV.Rows[i][3].ToString();
                            dtrow["ramount"] = dtINV.Rows[i][4].ToString();
                            dtrow["voutype"] = dtINV.Rows[i][5].ToString();
                            dtrow["vouno"] = dtINV.Rows[i][2].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtINV.Rows[i][6].ToString();
                            dtrow["ltype"] = "";
                            dtrow["Cust_Id"] = Customer_Id;
                            dtrow["vendorrefno"] = dtINV.Rows[i]["vendorrefno"].ToString();
                            dtrow["vendorrefdate"] = dtINV.Rows[i]["vendorrefdate"].ToString();
                            dtrow["jlid"] = "";
                            dttemp3.Rows.Add(dtrow);
                        }
                        Grid_detail.DataSource = dttemp3;
                        Grid_detail.DataBind();
                        ViewState["dtPayment"] = dttemp3;
                    }

                    GetYear();
                    dtj = Bank_Obj.GetRecPaymCalcjnrl(Customer_Id, did, "R", "FA" + dispyear);
                    DataTable dttemp2 = new DataTable();

                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dttemp2 = (DataTable)ViewState["dtPayment"];
                        b = dttemp2.Rows.Count;
                    }

                    if (dtj.Rows.Count > 0)
                    {
                        if (b == 0)
                        {
                            dttemp2.Columns.Add("branchHide", typeof(string));
                            dttemp2.Columns.Add("branch", typeof(string));
                            dttemp2.Columns.Add("invoiceno", typeof(string));
                            dttemp2.Columns.Add("iamount", typeof(string));
                            dttemp2.Columns.Add("ramount", typeof(string));
                            dttemp2.Columns.Add("voutype", typeof(string));
                            dttemp2.Columns.Add("vouno", typeof(string));
                            dttemp2.Columns.Add("tds", typeof(string));
                            dttemp2.Columns.Add("ravouyear", typeof(string));
                            dttemp2.Columns.Add("ltype", typeof(string));
                            dttemp2.Columns.Add("Cust_Id", typeof(string));
                            dttemp2.Columns.Add("vendorrefno", typeof(string));
                            dttemp2.Columns.Add("vendorrefdate", typeof(string));
                            dttemp2.Columns.Add("jlid", typeof(string));
                        }

                        for (int i = 0; i < dtj.Rows.Count; i++)
                        {
                            DataRow dtrow = dttemp2.NewRow();
                            dtrow["branchHide"] = dtj.Rows[i][0].ToString();
                            dtrow["branch"] = dtj.Rows[i][1].ToString();
                            if (dtj.Rows[i][5].ToString() == "J")
                            {
                                dtrow["invoiceno"] = "J - " + dtj.Rows[i][2].ToString();
                            }
                            else
                            {
                                dtrow["invoiceno"] = "SI - " + dtj.Rows[i][2].ToString();
                            }

                            dtrow["iamount"] = dtj.Rows[i][3].ToString();
                            dtrow["ramount"] = dtj.Rows[i][4].ToString();
                            dtrow["voutype"] = dtj.Rows[i][5].ToString();
                            dtrow["vouno"] = dtj.Rows[i][2].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtj.Rows[i][6].ToString();
                            if (dtj.Rows[i][5].ToString() == "J")
                            {
                                dtrow["ltype"] = dtj.Rows[i][7].ToString();
                            }
                            dtrow["Cust_Id"] = Customer_Id;
                            dttemp2.Rows.Add(dtrow);
                        }
                        Grid_detail.DataSource = dttemp2;
                        Grid_detail.DataBind();
                        ViewState["dtPayment"] = dttemp2;
                    }

                    // Opening Balance Format
                    OBBreakUp();
                    OBBreakUp4rectpmt();


                    if (Session["rptype"].ToString() == "R")
                    {
                        all();
                        //Invoices();
                        //DN();
                        //AdminDN();
                        ////  OSDN();
                        //PA();
                        //CN();
                        //AdminCN();
                        ////  OSCN();
                        //Journal();
                        //BOS();
                        ////From OB Breakup
                        //OBBreakUp();
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        all();
                        //PA();
                        //CN();
                        //AdminCN();
                        //// OSCN();
                        //Invoices();
                        //DN();
                        //AdminDN();
                        ////OSDN();
                        //Journal();
                        //BOS();
                        ////From OB Breakup
                        //OBBreakUp();
                    }
                }

                if (Session["rptype"].ToString() == "R" || Session["rptype"].ToString() == "P")
                {
                    DataTable dt = new DataTable();
                    int c = 0;
                    Customer_Id = Convert.ToInt32(hid_custid.Value);

                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dt = (DataTable)ViewState["dtPayment"];
                        c = dt.Rows.Count;

                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = dt.Rows[i];
                            if (dr["invoiceno"].ToString() == "On Account")
                            {
                                dr.Delete();
                            }
                        }
                    }
                    if (c == 0)
                    {
                        dt.Columns.Add("branchHide", typeof(string));
                        dt.Columns.Add("branch", typeof(string));
                        dt.Columns.Add("invoiceno", typeof(string));
                        dt.Columns.Add("iamount", typeof(string));
                        dt.Columns.Add("ramount", typeof(string));
                        dt.Columns.Add("voutype", typeof(string));
                        dt.Columns.Add("vouno", typeof(string));
                        dt.Columns.Add("tds", typeof(string));
                        dt.Columns.Add("ravouyear", typeof(string));
                        dt.Columns.Add("ltype", typeof(string));
                        dt.Columns.Add("Cust_Id", typeof(string));
                        dt.Columns.Add("vendorrefno", typeof(string));
                        dt.Columns.Add("vendorrefdate", typeof(string));
                        dt.Columns.Add("jlid", typeof(string));
                    }

                    DataRow dtrow = dt.NewRow();

                    dtrow["branchHide"] = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    dtrow["branch"] = Session["LoginBranchName"].ToString();
                    dtrow["invoiceno"] = "On Account";
                    dtrow["iamount"] = "";
                    dtrow["ramount"] = "0.00";
                    dtrow["voutype"] = "O";
                    dtrow["ravouyear"] = txt_recpdate.Text;
                    dtrow["Cust_Id"] = Customer_Id;
                    dtrow["vendorrefno"] = "";
                    dtrow["vendorrefdate"] = "";
                    dtrow["jlid"] = "";
                    dt.Rows.Add(dtrow);

                    ViewState["dtPayment"] = dt;
                    Grid_detail.DataSource = dt;
                    Grid_detail.DataBind();
                    if (Grid_detail.Rows.Count > 0)
                    {
                        for (int i = 0; i < Grid_detail.Rows.Count; i++)
                        {
                            if (Grid_detail.Rows[i].Cells[2].Text == "On Account")
                            {
                                Grid_detail.Rows[i].Cells[14].Visible = false;
                            }
                            else
                            {
                                Grid_detail.Rows[i].Cells[14].Visible = true;
                            }
                        }
                    }
                }
                if (Grid_detail.Rows.Count > 0)
                {
                    foreach (GridViewRow row1 in Grid_detail.Rows)
                    {
                        CheckBox chk = ((CheckBox)Grid_detail.Rows[row1.RowIndex].FindControl("Chkrecpfc"));
                        TextBox txt = ((TextBox)Grid_detail.Rows[row1.RowIndex].FindControl("txt_receiptamount"));

                        if (chk.Checked == false && txt.Text != "0.00")
                        {
                            if (txt.Text != "0.0000")           //NewOne //24/05/2022
                            {
                                Grid_detail.Rows[row1.RowIndex].Cells[15].Enabled = false;
                                chk.Checked = true;
                            }

                        }
                        else if (chk.Checked == false)
                        {
                            Grid_detail.Rows[row1.RowIndex].Cells[15].Enabled = true;
                            chk.Checked = false;
                        }
                    }
                }

                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back.Attributes["class"] = "btn ico-cancel";
            }
        }
        private void all()
        {
            try
            {
                int Custid, b = 0;
                DataTable dtInvoice1 = new DataTable();

                if (hid_custid.Value != "")
                {
                    Custid = Convert.ToInt32(hid_custid.Value);
                    dtInvoice1 = Bank_Obj.GetlvRecptDtls1(Custid, did);
                    DataTable dttemp = new DataTable();
                    DataRow dtrow;

                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dttemp = (DataTable)ViewState["dtPayment"];
                        b = dttemp.Rows.Count;
                    }

                    if (dtInvoice1.Rows.Count > 0)
                    {
                        if (b == 0)
                        {
                            dttemp.Columns.Add("branchHide", typeof(string));
                            dttemp.Columns.Add("branch", typeof(string));
                            dttemp.Columns.Add("invoiceno", typeof(string));
                            dttemp.Columns.Add("iamount", typeof(string));
                            dttemp.Columns.Add("ramount", typeof(string));
                            dttemp.Columns.Add("voutype", typeof(string));
                            dttemp.Columns.Add("vouno", typeof(string));
                            dttemp.Columns.Add("tds", typeof(string));
                            dttemp.Columns.Add("ravouyear", typeof(string));
                            dttemp.Columns.Add("ltype", typeof(string));
                            dttemp.Columns.Add("Cust_Id", typeof(string));
                            dttemp.Columns.Add("vendorrefno", typeof(string));
                            dttemp.Columns.Add("vendorrefdate", typeof(string));
                            dttemp.Columns.Add("jlid", typeof(string));
                        }
                        for (int i = 0; i < dtInvoice1.Rows.Count; i++)
                        {
                            dtrow = dttemp.NewRow();
                            dtrow["branchHide"] = dtInvoice1.Rows[i][0].ToString();
                            dtrow["branch"] = dtInvoice1.Rows[i][1].ToString();
                            
                            if (dtInvoice1.Rows[i][5].ToString() == "I")
                            {
                                dtrow["invoiceno"] = "SI - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            else if (dtInvoice1.Rows[i][5].ToString() == "P")
                            {
                                dtrow["invoiceno"] = "CN-Ops - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            else if (dtInvoice1.Rows[i][5].ToString() == "S")
                            {
                                dtrow["invoiceno"] = "ADN - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            else if (dtInvoice1.Rows[i][5].ToString() == "X")
                            {
                                dtrow["invoiceno"] = "ACN - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            else if (dtInvoice1.Rows[i][5].ToString() == "D")
                            {
                                dtrow["invoiceno"] = "OSSI - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            else if (dtInvoice1.Rows[i][5].ToString() == "C")
                            {
                                dtrow["invoiceno"] = "OSPI - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            else if (dtInvoice1.Rows[i][5].ToString() == "V")
                            {
                                dtrow["invoiceno"] = "DN - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            else if (dtInvoice1.Rows[i][5].ToString() == "E")
                            {
                                dtrow["invoiceno"] = "CN - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            else if (dtInvoice1.Rows[i][5].ToString() == "B")
                            {
                                dtrow["invoiceno"] = "BOS - " + dtInvoice1.Rows[i][2].ToString();
                            }

                            if (dtInvoice1.Rows[i][5].ToString() == "F") // Vino [05-03-2024]
                            {
                                dtrow["invoiceno"] = "SI OC - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            if (dtInvoice1.Rows[i][5].ToString() == "G")
                            {
                                dtrow["invoiceno"] = "PI OC - " + dtInvoice1.Rows[i][2].ToString();
                            }
                            if (dtInvoice1.Rows[i][5].ToString() == "H")
                            {
                                dtrow["invoiceno"] = "BS OC - " + dtInvoice1.Rows[i][2].ToString();
                            }

                            dtrow["iamount"] = dtInvoice1.Rows[i][3].ToString();
                            dtrow["ramount"] = dtInvoice1.Rows[i][4].ToString();
                            dtrow["voutype"] = dtInvoice1.Rows[i][5].ToString();
                            dtrow["vouno"] = dtInvoice1.Rows[i][2].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtInvoice1.Rows[i][6].ToString();
                            dtrow["ltype"] = "";
                            dtrow["Cust_Id"] = Custid;
                            dtrow["vendorrefno"] = dtInvoice1.Rows[i]["vendorrefno"].ToString();
                            dtrow["vendorrefdate"] = dtInvoice1.Rows[i]["vendorrefdate"].ToString();
                            dtrow["jlid"] = "";
                            dttemp.Rows.Add(dtrow);
                        }

                        Grid_detail.DataSource = dttemp;
                        Grid_detail.DataBind();
                        ViewState["dtPayment"] = dttemp;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void Txt_pan_TextChanged(object sender, EventArgs e)
        {
            //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable dt1 = new DataTable();
            try
            {
                DataTable dtINV = new DataTable();
                DataTable dtj = new DataTable();
                int Customer_Id, a = 0, b = 0;
                bool custexist = false;

                //if (custexist == false)
                //{
                //    Customer_VoucherAmount(Session["RpType"].ToString(), Convert.ToInt32(hid_custid.Value));
                //}               
                if (Txt_pan.Text != "")
                {

                    dt1 = customerobj.GetLikeCustomerpan(Txt_pan.Text);
                    if (dt1.Rows.Count > 0)
                    {
                        txt_cust.Text = dt1.Rows[0]["customername"].ToString();
                        //hid_custid.Value= dt.Rows[0]["customerid"].ToString();
                    }
                }

                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        hid_custid.Value = dt1.Rows[i]["customerid"].ToString();
                        cust();
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
            txt_cust_amt.Focus();
        }


        protected void txt_cust_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtINV = new DataTable();
                DataTable dtj = new DataTable();
                int Customer_Id, a = 0, b = 0;
                bool custexist = false;

                DataTable dtpan = new DataTable();
                string[] strcust = txt_cust.Text.Split(',');



                dtpan = Cust_Obj.GetLikeCustomer(strcust[0].Trim());
                if (dtpan.Rows.Count > 0)
                {
                    if (dtpan.Rows[0]["pano"].ToString() != "")
                    {
                        Txt_pan.Text = dtpan.Rows[0]["pano"].ToString();
                        Txt_pan_TextChanged(sender, e);
                    }
                    else
                    {
                        cust();
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }


        //protected void txt_cust_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable dtINV = new DataTable();
        //        DataTable dtj = new DataTable();
        //        int Customer_Id, a = 0, b = 0;
        //        bool custexist = false;

        //        //if (custexist == false)
        //        //{
        //        //    Customer_VoucherAmount(Session["RpType"].ToString(), Convert.ToInt32(hid_custid.Value));
        //        //}               

        //        if (txt_cust.Text != "")
        //        {
        //            if (Grid_detail.Rows.Count > 0)
        //            {
        //                Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
        //                Grid_detail.DataBind();
        //            }
        //            if (hid_custid.Value != "")
        //            {
        //                DataTable dttemp3 = new DataTable();
        //                Customer_Id = Convert.ToInt32(hid_custid.Value);
        //                dtINV = Bank_Obj.GetInvRecptDtls(Customer_Id, did);

        //                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
        //                {
        //                    dttemp3 = (DataTable)ViewState["dtPayment"];
        //                    a = dttemp3.Rows.Count;
        //                }

        //                if (dtINV.Rows.Count > 0)
        //                {
        //                    if (a == 0)
        //                    {
        //                        dttemp3.Columns.Add("branchHide", typeof(string));
        //                        dttemp3.Columns.Add("branch", typeof(string));
        //                        dttemp3.Columns.Add("invoiceno", typeof(string));
        //                        dttemp3.Columns.Add("iamount", typeof(string));
        //                        dttemp3.Columns.Add("ramount", typeof(string));
        //                        dttemp3.Columns.Add("voutype", typeof(string));
        //                        dttemp3.Columns.Add("vouno", typeof(string));
        //                        dttemp3.Columns.Add("tds", typeof(string));
        //                        dttemp3.Columns.Add("ravouyear", typeof(string));
        //                        dttemp3.Columns.Add("ltype", typeof(string));
        //                        dttemp3.Columns.Add("Cust_Id", typeof(string));
        //                        dttemp3.Columns.Add("vendorrefno", typeof(string));
        //                        dttemp3.Columns.Add("vendorrefdate", typeof(string));
        //                        dttemp3.Columns.Add("jlid", typeof(string));
        //                    }

        //                    for (int i = 0; i < dtINV.Rows.Count; i++)
        //                    {
        //                        DataRow dtrow = dttemp3.NewRow();
        //                        dtrow["branchHide"] = dtINV.Rows[i][0].ToString();
        //                        dtrow["branch"] = dtINV.Rows[i][1].ToString();

        //                        if (dtINV.Rows[i][5].ToString().Trim() == "I")
        //                        {
        //                            dtrow["invoiceno"] = "Inv - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        else if (dtINV.Rows[i][5].ToString().Trim() == "D")
        //                        {
        //                            dtrow["invoiceno"] = "OSDN - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        else if (dtINV.Rows[i][5].ToString().Trim() == "V")
        //                        {
        //                            dtrow["invoiceno"] = "DN - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        else if (dtINV.Rows[i][5].ToString() == "X")
        //                        {
        //                            dtrow["invoiceno"] = "ADN - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        else if (dtINV.Rows[i][5].ToString().Trim() == "P")
        //                        {
        //                            dtrow["invoiceno"] = "CNOps - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        else if (dtINV.Rows[i][5].ToString().Trim() == "C")
        //                        {
        //                            dtrow["invoiceno"] = "OSCN - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        else if (dtINV.Rows[i][5].ToString().Trim() == "E")
        //                        {
        //                            dtrow["invoiceno"] = "CN - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        else if (dtINV.Rows[i][5].ToString().Trim() == "S")
        //                        {
        //                            dtrow["invoiceno"] = "ACN - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        else if (dtINV.Rows[i][5].ToString().Trim() == "B")
        //                        {
        //                            dtrow["invoiceno"] = "BOS - " + dtINV.Rows[i][2].ToString();
        //                        }
        //                        dtrow["iamount"] = dtINV.Rows[i][3].ToString();
        //                        dtrow["ramount"] = dtINV.Rows[i][4].ToString();
        //                        dtrow["voutype"] = dtINV.Rows[i][5].ToString();
        //                        dtrow["vouno"] = dtINV.Rows[i][2].ToString();
        //                        dtrow["tds"] = "";
        //                        dtrow["ravouyear"] = dtINV.Rows[i][6].ToString();
        //                        dtrow["ltype"] = "";
        //                        dtrow["Cust_Id"] = Customer_Id;
        //                        dtrow["vendorrefno"] = dtINV.Rows[i]["vendorrefno"].ToString();
        //                        dtrow["vendorrefdate"] = dtINV.Rows[i]["vendorrefdate"].ToString();
        //                        dtrow["jlid"] = "";
        //                        dttemp3.Rows.Add(dtrow);
        //                    }
        //                    Grid_detail.DataSource = dttemp3;
        //                    Grid_detail.DataBind();
        //                    ViewState["dtPayment"] = dttemp3;
        //                }

        //                GetYear();
        //                dtj = Bank_Obj.GetRecPaymCalcjnrl(Customer_Id, did, "R", "FA" + dispyear);
        //                DataTable dttemp2 = new DataTable();

        //                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
        //                {
        //                    dttemp2 = (DataTable)ViewState["dtPayment"];
        //                    b = dttemp2.Rows.Count;
        //                }

        //                if (dtj.Rows.Count > 0)
        //                {
        //                    if (b == 0)
        //                    {
        //                        dttemp2.Columns.Add("branchHide", typeof(string));
        //                        dttemp2.Columns.Add("branch", typeof(string));
        //                        dttemp2.Columns.Add("invoiceno", typeof(string));
        //                        dttemp2.Columns.Add("iamount", typeof(string));
        //                        dttemp2.Columns.Add("ramount", typeof(string));
        //                        dttemp2.Columns.Add("voutype", typeof(string));
        //                        dttemp2.Columns.Add("vouno", typeof(string));
        //                        dttemp2.Columns.Add("tds", typeof(string));
        //                        dttemp2.Columns.Add("ravouyear", typeof(string));
        //                        dttemp2.Columns.Add("ltype", typeof(string));
        //                        dttemp2.Columns.Add("Cust_Id", typeof(string));

        //                        dttemp2.Columns.Add("vendorrefno", typeof(string));
        //                        dttemp2.Columns.Add("vendorrefdate", typeof(string));
        //                        dttemp2.Columns.Add("jlid", typeof(string));
        //                    }

        //                    for (int i = 0; i < dtj.Rows.Count; i++)
        //                    {
        //                        DataRow dtrow = dttemp2.NewRow();
        //                        dtrow["branchHide"] = dtj.Rows[i][0].ToString();
        //                        dtrow["branch"] = dtj.Rows[i][1].ToString();
        //                        dtrow["invoiceno"] = "Inv - " + dtj.Rows[i][2].ToString();
        //                        dtrow["iamount"] = dtj.Rows[i][3].ToString();
        //                        dtrow["ramount"] = dtj.Rows[i][4].ToString();
        //                        dtrow["voutype"] = dtj.Rows[i][5].ToString();
        //                        dtrow["vouno"] = dtj.Rows[i][2].ToString();
        //                        dtrow["tds"] = "";
        //                        dtrow["ravouyear"] = dtj.Rows[i][6].ToString();
        //                        if (dtj.Rows[i][5].ToString() == "J")
        //                        {
        //                            dtrow["ltype"] = dtj.Rows[i][7].ToString();
        //                        }
        //                        dtrow["Cust_Id"] = Customer_Id;
        //                        dttemp2.Rows.Add(dtrow);
        //                    }
        //                    Grid_detail.DataSource = dttemp2;
        //                    Grid_detail.DataBind();
        //                    ViewState["dtPayment"] = dttemp2;
        //                }
        //                // Opening Balance Format
        //                OBBreakUp4rectpmt();


        //                if (Session["rptype"].ToString() == "R")
        //                {
        //                    Invoices();
        //                    DN();
        //                    AdminDN();
        //                    OSDN();
        //                    PA();
        //                    CN();
        //                    AdminCN();
        //                    OSCN();
        //                    Journal();
        //                    BOS();
        //                    //From OB Breakup
        //                    OBBreakUp();
        //                }
        //                else if (Session["rptype"].ToString() == "P")
        //                {
        //                    PA();
        //                    CN();
        //                    AdminCN();
        //                    OSCN();
        //                    Invoices();
        //                    DN();
        //                    AdminDN();
        //                    OSDN();
        //                    Journal();
        //                    BOS();
        //                    //From OB Breakup
        //                    OBBreakUp();
        //                }
        //            }

        //            if (Session["rptype"].ToString() == "R" || Session["rptype"].ToString() == "P")
        //            {
        //                DataTable dt = new DataTable();
        //                int c = 0;
        //                Customer_Id = Convert.ToInt32(hid_custid.Value);

        //                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
        //                {
        //                    dt = (DataTable)ViewState["dtPayment"];
        //                    c = dt.Rows.Count;

        //                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
        //                    {
        //                        DataRow dr = dt.Rows[i];
        //                        if (dr["invoiceno"].ToString() == "On Account")
        //                        {
        //                            dr.Delete();
        //                        }
        //                    }
        //                }
        //                if (c == 0)
        //                {
        //                    dt.Columns.Add("branchHide", typeof(string));
        //                    dt.Columns.Add("branch", typeof(string));
        //                    dt.Columns.Add("invoiceno", typeof(string));
        //                    dt.Columns.Add("iamount", typeof(string));
        //                    dt.Columns.Add("ramount", typeof(string));
        //                    dt.Columns.Add("voutype", typeof(string));
        //                    dt.Columns.Add("vouno", typeof(string));
        //                    dt.Columns.Add("tds", typeof(string));
        //                    dt.Columns.Add("ravouyear", typeof(string));
        //                    dt.Columns.Add("ltype", typeof(string));
        //                    dt.Columns.Add("Cust_Id", typeof(string));
        //                    dt.Columns.Add("vendorrefno", typeof(string));
        //                    dt.Columns.Add("vendorrefdate", typeof(string));
        //                    dt.Columns.Add("jlid", typeof(string));
        //                }

        //                DataRow dtrow = dt.NewRow();
        //                dtrow["invoiceno"] = "On Account";
        //                dtrow["iamount"] = "";
        //                dtrow["ramount"] = "0.00";
        //                dtrow["voutype"] = "O";
        //                dtrow["ravouyear"] = txt_recpdate.Text;
        //                dtrow["Cust_Id"] = Customer_Id;
        //                dtrow["vendorrefno"] = "";
        //                dtrow["vendorrefdate"] = "";
        //                dtrow["jlid"] = "";
        //                dt.Rows.Add(dtrow);

        //                ViewState["dtPayment"] = dt;
        //                Grid_detail.DataSource = dt;
        //                Grid_detail.DataBind();
        //                if (Grid_detail.Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < Grid_detail.Rows.Count; i++)
        //                    {
        //                        if (Grid_detail.Rows[i].Cells[2].Text == "On Account")
        //                        {
        //                            Grid_detail.Rows[i].Cells[14].Visible = false;
        //                        }
        //                        else
        //                        {
        //                            Grid_detail.Rows[i].Cells[14].Visible = true;
        //                        }
        //                    }
        //                }
        //            }
        //            btn_back.ToolTip = "Cancel";
        //            btn_back.Attributes["class"] = "btn ico-cancel";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
        //        return;
        //    }
        //    txt_cust_amt.Focus();
        //}


        private void GetYear()
        {
            dispyear = txt_recpdate.Text;
            //dispyear = HttpContext.Current.Session["Vouyear"].ToString();
            dispyear = dispyear.Substring(2, 2);
            int disp = Convert.ToInt32(dispyear);
            dy = disp + 1;
            if (dy < 10)
            {
                dy1 = dy1 + "0" + dy.ToString();
            }
            else
            {
                dy1 = dy.ToString();
            }
            dispyear = dispyear + dy1;
        }

        private void Invoices()
        {
            try
            {
                int Custid, b = 0;
                DataTable dtInvoice1 = new DataTable();

                if (hid_custid.Value != "")
                {
                    Custid = Convert.ToInt32(hid_custid.Value);
                    dtInvoice1 = Bank_Obj.GetInvRecptDtls1(Custid, did);
                    DataTable dttemp = new DataTable();
                    DataRow dtrow;

                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dttemp = (DataTable)ViewState["dtPayment"];
                        b = dttemp.Rows.Count;
                    }

                    if (dtInvoice1.Rows.Count > 0)
                    {
                        if (b == 0)
                        {
                            dttemp.Columns.Add("branchHide", typeof(string));
                            dttemp.Columns.Add("branch", typeof(string));
                            dttemp.Columns.Add("invoiceno", typeof(string));
                            dttemp.Columns.Add("iamount", typeof(string));
                            dttemp.Columns.Add("ramount", typeof(string));
                            dttemp.Columns.Add("voutype", typeof(string));
                            dttemp.Columns.Add("vouno", typeof(string));
                            dttemp.Columns.Add("tds", typeof(string));
                            dttemp.Columns.Add("ravouyear", typeof(string));
                            dttemp.Columns.Add("ltype", typeof(string));
                            dttemp.Columns.Add("Cust_Id", typeof(string));
                            dttemp.Columns.Add("vendorrefno", typeof(string));
                            dttemp.Columns.Add("vendorrefdate", typeof(string));
                            dttemp.Columns.Add("jlid", typeof(string));
                        }
                        for (int i = 0; i < dtInvoice1.Rows.Count; i++)
                        {
                            dtrow = dttemp.NewRow();
                            dtrow["branchHide"] = dtInvoice1.Rows[i][0].ToString();
                            dtrow["branch"] = dtInvoice1.Rows[i][1].ToString();
                            dtrow["invoiceno"] = "INV - " + dtInvoice1.Rows[i][2].ToString();
                            dtrow["iamount"] = dtInvoice1.Rows[i][3].ToString();
                            dtrow["ramount"] = dtInvoice1.Rows[i][4].ToString();
                            dtrow["voutype"] = dtInvoice1.Rows[i][5].ToString();
                            dtrow["vouno"] = dtInvoice1.Rows[i][2].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtInvoice1.Rows[i][6].ToString();
                            dtrow["ltype"] = "";
                            dtrow["Cust_Id"] = Custid;
                            dtrow["vendorrefno"] = "";
                            dtrow["vendorrefdate"] = "";
                            dtrow["jlid"] = "";
                            dttemp.Rows.Add(dtrow);
                        }

                        Grid_detail.DataSource = dttemp;
                        Grid_detail.DataBind();
                        ViewState["dtPayment"] = dttemp;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        private void DN()
        {
            try
            {
                int Custid, b = 0;
                DataTable dtInvoice2 = new DataTable();
                if (hid_custid.Value != "")
                {
                    Custid = Convert.ToInt32(hid_custid.Value);
                    dtInvoice2 = Bank_Obj.GetDN(Custid, did);
                    DataTable dttemp = new DataTable();

                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dttemp = (DataTable)ViewState["dtPayment"];
                        b = dttemp.Rows.Count;
                    }

                    if (dtInvoice2.Rows.Count > 0)
                    {
                        if (b == 0)
                        {
                            dttemp.Columns.Add("branchHide", typeof(string));
                            dttemp.Columns.Add("branch", typeof(string));
                            dttemp.Columns.Add("invoiceno", typeof(string));
                            dttemp.Columns.Add("iamount", typeof(string));
                            dttemp.Columns.Add("ramount", typeof(string));
                            dttemp.Columns.Add("voutype", typeof(string));
                            dttemp.Columns.Add("vouno", typeof(string));
                            dttemp.Columns.Add("tds", typeof(string));
                            dttemp.Columns.Add("ravouyear", typeof(string));
                            dttemp.Columns.Add("ltype", typeof(string));
                            dttemp.Columns.Add("Cust_Id", typeof(string));
                            dttemp.Columns.Add("vendorrefno", typeof(string));
                            dttemp.Columns.Add("vendorrefdate", typeof(string));
                            dttemp.Columns.Add("jlid", typeof(string));
                        }

                        for (int i = 0; i < dtInvoice2.Rows.Count; i++)
                        {
                            DataRow dtrow = dttemp.NewRow();
                            dtrow["branchHide"] = dtInvoice2.Rows[i][0].ToString();
                            dtrow["branch"] = dtInvoice2.Rows[i][1].ToString();
                            dtrow["invoiceno"] = "DN - " + dtInvoice2.Rows[i][2].ToString();
                            dtrow["iamount"] = dtInvoice2.Rows[i][3].ToString();
                            dtrow["ramount"] = dtInvoice2.Rows[i][4].ToString();
                            dtrow["voutype"] = dtInvoice2.Rows[i][5].ToString();
                            dtrow["vouno"] = dtInvoice2.Rows[i][2].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtInvoice2.Rows[i][6].ToString();
                            dtrow["ltype"] = "";
                            dtrow["Cust_Id"] = Custid;
                            dtrow["vendorrefno"] = "";
                            dtrow["vendorrefdate"] = "";
                            dtrow["jlid"] = "";
                            dttemp.Rows.Add(dtrow);
                        }
                        double c = 0, a = 0;
                        for (int i = 0; i < (dttemp.Rows.Count); i++)
                        {
                            a = Convert.ToDouble(dttemp.Rows[i][4].ToString());
                            c = c + a;
                        }
                        Grid_detail.DataSource = dttemp;
                        Grid_detail.DataBind();
                        ViewState["dtPayment"] = dttemp;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        private void AdminDN()
        {
            try
            {
                int Custid, b = 0;
                DataTable dtAdminDebit = new DataTable();

                if (hid_custid.Value != "")
                {
                    Custid = Convert.ToInt32(hid_custid.Value);
                    dtAdminDebit = Bank_Obj.GetAdminDN(Custid, did);
                    DataTable dttempAdmin = new DataTable();

                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dttempAdmin = (DataTable)ViewState["dtPayment"];
                        b = dttempAdmin.Rows.Count;
                    }

                    if (dtAdminDebit.Rows.Count > 0)
                    {
                        if (b == 0)
                        {
                            dttempAdmin.Columns.Add("branchHide", typeof(string));
                            dttempAdmin.Columns.Add("branch", typeof(string));
                            dttempAdmin.Columns.Add("invoiceno", typeof(string));
                            dttempAdmin.Columns.Add("iamount", typeof(string));
                            dttempAdmin.Columns.Add("ramount", typeof(string));
                            dttempAdmin.Columns.Add("voutype", typeof(string));
                            dttempAdmin.Columns.Add("vouno", typeof(string));
                            dttempAdmin.Columns.Add("tds", typeof(string));
                            dttempAdmin.Columns.Add("ravouyear", typeof(string));
                            dttempAdmin.Columns.Add("ltype", typeof(string));
                            dttempAdmin.Columns.Add("Cust_Id", typeof(string));
                            dttempAdmin.Columns.Add("vendorrefno", typeof(string));
                            dttempAdmin.Columns.Add("vendorrefdate", typeof(string));
                            dttempAdmin.Columns.Add("jlid", typeof(string));
                        }
                        for (int i = 0; i < dtAdminDebit.Rows.Count; i++)
                        {
                            DataRow dtrow = dttempAdmin.NewRow();
                            dtrow["branchHide"] = dtAdminDebit.Rows[i][0].ToString();
                            dtrow["branch"] = dtAdminDebit.Rows[i][1].ToString();
                            dtrow["invoiceno"] = "ADN - " + dtAdminDebit.Rows[i][2].ToString();
                            dtrow["iamount"] = dtAdminDebit.Rows[i][3].ToString();
                            dtrow["ramount"] = dtAdminDebit.Rows[i][4].ToString();
                            dtrow["voutype"] = dtAdminDebit.Rows[i][5].ToString();
                            dtrow["vouno"] = dtAdminDebit.Rows[i][2].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtAdminDebit.Rows[i][6].ToString();
                            dtrow["ltype"] = "";
                            dtrow["Cust_Id"] = Custid;
                            dtrow["vendorrefno"] = "";
                            dtrow["vendorrefdate"] = "";
                            dtrow["jlid"] = "";
                            dttempAdmin.Rows.Add(dtrow);
                        }
                        Grid_detail.DataSource = dttempAdmin;
                        Grid_detail.DataBind();
                        ViewState["dtPayment"] = dttempAdmin;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        private void OSDN()
        {
            try
            {
                int Custid, b = 0;
                DataTable dtOverseas = new DataTable();

                if (hid_custid.Value != "")
                {
                    Custid = Convert.ToInt32(hid_custid.Value);
                    dtOverseas = Bank_Obj.GetOSDN(Custid, did);
                    DataTable dttempOSDN = new DataTable();

                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dttempOSDN = (DataTable)ViewState["dtPayment"];
                        b = dttempOSDN.Rows.Count;
                    }

                    if (dtOverseas.Rows.Count > 0)
                    {
                        if (b == 0)
                        {
                            dttempOSDN.Columns.Add("branchHide", typeof(string));
                            dttempOSDN.Columns.Add("branch", typeof(string));
                            dttempOSDN.Columns.Add("invoiceno", typeof(string));
                            dttempOSDN.Columns.Add("iamount", typeof(string));
                            dttempOSDN.Columns.Add("ramount", typeof(string));
                            dttempOSDN.Columns.Add("voutype", typeof(string));
                            dttempOSDN.Columns.Add("vouno", typeof(string));
                            dttempOSDN.Columns.Add("tds", typeof(string));
                            dttempOSDN.Columns.Add("ravouyear", typeof(string));
                            dttempOSDN.Columns.Add("ltype", typeof(string));
                            dttempOSDN.Columns.Add("Cust_Id", typeof(string));
                            dttempOSDN.Columns.Add("vendorrefno", typeof(string));
                            dttempOSDN.Columns.Add("vendorrefdate", typeof(string));
                            dttempOSDN.Columns.Add("jlid", typeof(string));
                        }
                        for (int i = 0; i < dtOverseas.Rows.Count; i++)
                        {
                            DataRow dtrow = dttempOSDN.NewRow();
                            dtrow["branchHide"] = dtOverseas.Rows[i][0].ToString();
                            dtrow["branch"] = dtOverseas.Rows[i][1].ToString();
                            dtrow["invoiceno"] = "OSDN - " + dtOverseas.Rows[i][2].ToString();
                            dtrow["iamount"] = dtOverseas.Rows[i][3].ToString();
                            dtrow["ramount"] = dtOverseas.Rows[i][4].ToString();
                            dtrow["voutype"] = dtOverseas.Rows[i][5].ToString();
                            dtrow["vouno"] = dtOverseas.Rows[i][2].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtOverseas.Rows[i][6].ToString();
                            dtrow["ltype"] = "";
                            dtrow["Cust_Id"] = Custid;
                            dtrow["vendorrefno"] = "";
                            dtrow["vendorrefdate"] = "";
                            dtrow["jlid"] = "";
                            dttempOSDN.Rows.Add(dtrow);
                        }
                        Grid_detail.DataSource = dttempOSDN;
                        Grid_detail.DataBind();
                        ViewState["dtPayment"] = dttempOSDN;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        private void PA()
        {
            int Custid, b = 0;
            DataTable dtPA = new DataTable();

            if (hid_custid.Value != "")
            {
                Custid = Convert.ToInt32(hid_custid.Value);
                dtPA = Payment_Obj.GetPAPaymentDtls1(Custid, did);
                DataTable dttempCNOps = new DataTable();

                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                {
                    dttempCNOps = (DataTable)ViewState["dtPayment"];
                    b = dttempCNOps.Rows.Count;
                }

                if (dtPA.Rows.Count > 0)
                {
                    if (b == 0)
                    {
                        dttempCNOps.Columns.Add("branchHide", typeof(string));
                        dttempCNOps.Columns.Add("branch", typeof(string));
                        dttempCNOps.Columns.Add("invoiceno", typeof(string));
                        dttempCNOps.Columns.Add("iamount", typeof(string));
                        dttempCNOps.Columns.Add("ramount", typeof(string));
                        dttempCNOps.Columns.Add("voutype", typeof(string));
                        dttempCNOps.Columns.Add("vouno", typeof(string));
                        dttempCNOps.Columns.Add("tds", typeof(string));
                        dttempCNOps.Columns.Add("ravouyear", typeof(string));
                        dttempCNOps.Columns.Add("ltype", typeof(string));
                        dttempCNOps.Columns.Add("Cust_Id", typeof(string));
                        dttempCNOps.Columns.Add("vendorrefno", typeof(string));
                        dttempCNOps.Columns.Add("vendorrefdate", typeof(string));
                        dttempCNOps.Columns.Add("jlid", typeof(string));
                    }

                    for (int i = 0; i < dtPA.Rows.Count; i++)
                    {
                        DataRow dtrow = dttempCNOps.NewRow();
                        dtrow["branchHide"] = dtPA.Rows[i][0].ToString();
                        dtrow["branch"] = dtPA.Rows[i][1].ToString();
                        dtrow["invoiceno"] = "CNOps - " + dtPA.Rows[i][2].ToString();
                        dtrow["iamount"] = dtPA.Rows[i][3].ToString();
                        dtrow["ramount"] = dtPA.Rows[i][4].ToString();
                        dtrow["voutype"] = dtPA.Rows[i][5].ToString();
                        dtrow["vouno"] = dtPA.Rows[i][2].ToString();
                        dtrow["tds"] = dtPA.Rows[i][6].ToString();
                        dtrow["ravouyear"] = dtPA.Rows[i][7].ToString();
                        dtrow["ltype"] = "";
                        dtrow["Cust_Id"] = Custid;

                        dtrow["vendorrefno"] = dtPA.Rows[i]["vendorrefno"].ToString();
                        dtrow["vendorrefdate"] = dtPA.Rows[i]["vendorrefdate"].ToString();
                        dtrow["jlid"] = "";
                        dttempCNOps.Rows.Add(dtrow);
                    }
                    Grid_detail.DataSource = dttempCNOps;
                    Grid_detail.DataBind();
                    ViewState["dtPayment"] = dttempCNOps;
                }
            }
        }

        private void CN()
        {
            int Custid, b = 0;
            DataTable dtCreditNote = new DataTable();

            if (hid_custid.Value != "")
            {
                Custid = Convert.ToInt32(hid_custid.Value);
                dtCreditNote = Payment_Obj.GetCN(Custid, did);
                DataTable dttempCN = new DataTable();

                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                {
                    dttempCN = (DataTable)ViewState["dtPayment"];
                    b = dttempCN.Rows.Count;
                }

                if (dtCreditNote.Rows.Count > 0)
                {
                    if (b == 0)
                    {
                        dttempCN.Columns.Add("branchHide", typeof(string));
                        dttempCN.Columns.Add("branch", typeof(string));
                        dttempCN.Columns.Add("invoiceno", typeof(string));
                        dttempCN.Columns.Add("iamount", typeof(string));
                        dttempCN.Columns.Add("ramount", typeof(string));
                        dttempCN.Columns.Add("voutype", typeof(string));
                        dttempCN.Columns.Add("vouno", typeof(string));
                        dttempCN.Columns.Add("tds", typeof(string));
                        dttempCN.Columns.Add("ravouyear", typeof(string));
                        dttempCN.Columns.Add("ltype", typeof(string));
                        dttempCN.Columns.Add("Cust_Id", typeof(string));
                        dttempCN.Columns.Add("vendorrefno", typeof(string));
                        dttempCN.Columns.Add("vendorrefdate", typeof(string));
                        dttempCN.Columns.Add("jlid", typeof(string));
                    }

                    for (int i = 0; i < dtCreditNote.Rows.Count; i++)
                    {
                        DataRow dtrow = dttempCN.NewRow();
                        dtrow["branchHide"] = dtCreditNote.Rows[i][0].ToString();
                        dtrow["branch"] = dtCreditNote.Rows[i][1].ToString();
                        dtrow["invoiceno"] = "CN - " + dtCreditNote.Rows[i][2].ToString();
                        dtrow["iamount"] = dtCreditNote.Rows[i][3].ToString();
                        dtrow["ramount"] = dtCreditNote.Rows[i][4].ToString();
                        dtrow["voutype"] = dtCreditNote.Rows[i][5].ToString();
                        dtrow["vouno"] = dtCreditNote.Rows[i][2].ToString();
                        dtrow["tds"] = dtCreditNote.Rows[i][6].ToString();
                        dtrow["ravouyear"] = dtCreditNote.Rows[i][7].ToString();
                        dtrow["ltype"] = "";
                        dtrow["Cust_Id"] = Custid;

                        dtrow["vendorrefno"] = dtCreditNote.Rows[i]["vendorrefno"].ToString();
                        dtrow["vendorrefdate"] = dtCreditNote.Rows[i]["vendorrefdate"].ToString();
                        dtrow["jlid"] = "";
                        dttempCN.Rows.Add(dtrow);
                    }
                    Grid_detail.DataSource = dttempCN;
                    Grid_detail.DataBind();
                    ViewState["dtPayment"] = dttempCN;
                }
            }
        }

        private void AdminCN()
        {
            int Custid, b = 0;
            DataTable dtAdminCredit = new DataTable();

            if (hid_custid.Value != "")
            {
                Custid = Convert.ToInt32(hid_custid.Value);
                dtAdminCredit = Payment_Obj.GetAdminCN(Custid, did);
                DataTable dttempACN = new DataTable();

                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                {
                    dttempACN = (DataTable)ViewState["dtPayment"];
                    b = dttempACN.Rows.Count;
                }

                if (dtAdminCredit.Rows.Count > 0)
                {
                    if (b == 0)
                    {
                        dttempACN.Columns.Add("branchHide", typeof(string));
                        dttempACN.Columns.Add("branch", typeof(string));
                        dttempACN.Columns.Add("invoiceno", typeof(string));
                        dttempACN.Columns.Add("iamount", typeof(string));
                        dttempACN.Columns.Add("ramount", typeof(string));
                        dttempACN.Columns.Add("voutype", typeof(string));
                        dttempACN.Columns.Add("vouno", typeof(string));
                        dttempACN.Columns.Add("tds", typeof(string));
                        dttempACN.Columns.Add("ravouyear", typeof(string));
                        dttempACN.Columns.Add("ltype", typeof(string));
                        dttempACN.Columns.Add("Cust_Id", typeof(string));
                        dttempACN.Columns.Add("vendorrefno", typeof(string));
                        dttempACN.Columns.Add("vendorrefdate", typeof(string));
                        dttempACN.Columns.Add("jlid", typeof(string));
                    }
                    for (int i = 0; i < dtAdminCredit.Rows.Count; i++)
                    {
                        DataRow dtrow = dttempACN.NewRow();
                        dtrow["branchHide"] = dtAdminCredit.Rows[i][0].ToString();
                        dtrow["branch"] = dtAdminCredit.Rows[i][1].ToString();
                        dtrow["invoiceno"] = "ACN - " + dtAdminCredit.Rows[i][2].ToString();
                        dtrow["iamount"] = dtAdminCredit.Rows[i][3].ToString();
                        dtrow["ramount"] = dtAdminCredit.Rows[i][4].ToString();
                        dtrow["voutype"] = dtAdminCredit.Rows[i][5].ToString();
                        dtrow["vouno"] = dtAdminCredit.Rows[i][2].ToString();
                        dtrow["tds"] = dtAdminCredit.Rows[i][6].ToString();
                        dtrow["ravouyear"] = dtAdminCredit.Rows[i][7].ToString();
                        dtrow["ltype"] = "";
                        dtrow["Cust_Id"] = Custid;

                        dtrow["vendorrefno"] = dtAdminCredit.Rows[i]["vendorrefno"].ToString();
                        dtrow["vendorrefdate"] = dtAdminCredit.Rows[i]["vendorrefdate"].ToString();
                        dtrow["jlid"] = "";
                        dttempACN.Rows.Add(dtrow);
                    }
                    Grid_detail.DataSource = dttempACN;
                    Grid_detail.DataBind();
                    ViewState["dtPayment"] = dttempACN;
                }
            }
        }

        private void OSCN()
        {
            int Custid, b = 0;
            DataTable dtOverseasCredit = new DataTable();

            if (hid_custid.Value != "")
            {
                Custid = Convert.ToInt32(hid_custid.Value);
                dtOverseasCredit = Payment_Obj.GetOSCN(Custid, did);
                DataTable dttempOSCN = new DataTable();

                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                {
                    dttempOSCN = (DataTable)ViewState["dtPayment"];
                    b = dttempOSCN.Rows.Count;
                }

                if (dtOverseasCredit.Rows.Count > 0)
                {
                    if (b == 0)
                    {
                        dttempOSCN.Columns.Add("branchHide", typeof(string));
                        dttempOSCN.Columns.Add("branch", typeof(string));
                        dttempOSCN.Columns.Add("invoiceno", typeof(string));
                        dttempOSCN.Columns.Add("iamount", typeof(string));
                        dttempOSCN.Columns.Add("ramount", typeof(string));
                        dttempOSCN.Columns.Add("voutype", typeof(string));
                        dttempOSCN.Columns.Add("vouno", typeof(string));
                        dttempOSCN.Columns.Add("tds", typeof(string));
                        dttempOSCN.Columns.Add("ravouyear", typeof(string));
                        dttempOSCN.Columns.Add("ltype", typeof(string));
                        dttempOSCN.Columns.Add("Cust_Id", typeof(string));
                        dttempOSCN.Columns.Add("vendorrefno", typeof(string));
                        dttempOSCN.Columns.Add("vendorrefdate", typeof(string));
                        dttempOSCN.Columns.Add("jlid", typeof(string));
                    }
                    for (int i = 0; i < dtOverseasCredit.Rows.Count; i++)
                    {
                        DataRow dtrow = dttempOSCN.NewRow();
                        dtrow["branchHide"] = dtOverseasCredit.Rows[i][0].ToString();
                        dtrow["branch"] = dtOverseasCredit.Rows[i][1].ToString();
                        dtrow["invoiceno"] = "OSDN - " + dtOverseasCredit.Rows[i][2].ToString();
                        dtrow["iamount"] = dtOverseasCredit.Rows[i][3].ToString();
                        dtrow["ramount"] = dtOverseasCredit.Rows[i][4].ToString();
                        dtrow["voutype"] = dtOverseasCredit.Rows[i][5].ToString();
                        dtrow["vouno"] = dtOverseasCredit.Rows[i][2].ToString();
                        dtrow["tds"] = "";
                        dtrow["ravouyear"] = dtOverseasCredit.Rows[i][6].ToString();
                        dtrow["ltype"] = "";
                        dtrow["Cust_Id"] = Custid;

                        dtrow["vendorrefno"] = dtOverseasCredit.Rows[i]["vendorrefno"].ToString();
                        dtrow["vendorrefdate"] = dtOverseasCredit.Rows[i]["vendorrefdate"].ToString();
                        dtrow["jlid"] = "";
                        dttempOSCN.Rows.Add(dtrow);
                    }
                    Grid_detail.DataSource = dttempOSCN;
                    Grid_detail.DataBind();
                    ViewState["dtPayment"] = dttempOSCN;
                }
            }
        }

        private void Journal()
        {
            GetYear();
            int Custid, b = 0;
            DataTable dtJournal = new DataTable();

            if (hid_custid.Value != "")
            {
                Custid = Convert.ToInt32(hid_custid.Value);
                dtJournal = Bank_Obj.GetjnrlRecptDtls(Custid, did, "FA" + dispyear);
                DataTable dttempJ = new DataTable();

                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                {
                    dttempJ = (DataTable)ViewState["dtPayment"];
                    b = dttempJ.Rows.Count;
                }

                if (dtJournal.Rows.Count > 0)
                {
                    if (b == 0)
                    {
                        dttempJ.Columns.Add("branchHide", typeof(string));
                        dttempJ.Columns.Add("branch", typeof(string));
                        dttempJ.Columns.Add("invoiceno", typeof(string));
                        dttempJ.Columns.Add("iamount", typeof(string));
                        dttempJ.Columns.Add("ramount", typeof(string));
                        dttempJ.Columns.Add("voutype", typeof(string));
                        dttempJ.Columns.Add("vouno", typeof(string));
                        dttempJ.Columns.Add("tds", typeof(string));
                        dttempJ.Columns.Add("ravouyear", typeof(string));
                        dttempJ.Columns.Add("ltype", typeof(string));
                        dttempJ.Columns.Add("Cust_Id", typeof(string));
                        dttempJ.Columns.Add("vendorrefno", typeof(string));
                        dttempJ.Columns.Add("vendorrefdate", typeof(string));
                        dttempJ.Columns.Add("jlid", typeof(string));
                    }

                    for (int i = 0; i < dtJournal.Rows.Count; i++)
                    {
                        DataRow dtrow = dttempJ.NewRow();
                        dtrow["branchHide"] = dtJournal.Rows[i][0].ToString();
                        dtrow["branch"] = dtJournal.Rows[i][1].ToString();
                        dtrow["invoiceno"] = "J - " + dtJournal.Rows[i][2].ToString();
                        dtrow["iamount"] = dtJournal.Rows[i][3].ToString();
                        dtrow["ramount"] = dtJournal.Rows[i][4].ToString();
                        dtrow["voutype"] = dtJournal.Rows[i][5].ToString();
                        dtrow["vouno"] = dtJournal.Rows[i][2].ToString();
                        dtrow["tds"] = "";
                        dtrow["ravouyear"] = dtJournal.Rows[i][6].ToString();
                        dtrow["ltype"] = dtJournal.Rows[i][7].ToString();
                        dtrow["Cust_Id"] = Custid;
                        dtrow["vendorrefno"] = "";
                        dtrow["vendorrefdate"] = "";
                        dtrow["jlid"] = dtJournal.Rows[i][8].ToString();
                        dttempJ.Rows.Add(dtrow);
                    }
                    Grid_detail.DataSource = dttempJ;
                    Grid_detail.DataBind();
                    ViewState["dtPayment"] = dttempJ;
                }
            }
        }

        private void BindGrid(int rowcount, string txttype, string cust, string amt, int cid)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Customerortax", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("cid", typeof(String)));

            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];

                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                        dr[1] = dt.Rows[0][1].ToString();
                        dr[2] = dt.Rows[0][2].ToString();
                        dr[3] = dt.Rows[0][3].ToString();
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = txttype;
                dr[1] = cust;
                dr[2] = amt;
                dr[3] = cid;
                dt.Rows.Add(dr);
            }
            if (dt.Rows.Count > 0)
            {
                Grid_Account.DataSource = dt;
                Grid_Account.DataBind();
            }
            else
            {
                Grid_Account.DataSource = dt;
                Grid_Account.DataBind();
            }
            ViewState["CurrentData"] = dt;
        }

        private void BindGrid1(int rowcount, string txttype, string amt)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Customerortax", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("cid", typeof(String)));

            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];

                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                        dr[1] = dt.Rows[0][1].ToString();
                        dr[2] = dt.Rows[0][2].ToString();
                        dr[3] = dt.Rows[0][3].ToString();
                    }
                }
                dr = dt.NewRow();
                dr[0] = txttype;
                dr[1] = "";
                dr[2] = amt;
                dr[3] = "";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = txttype;
                dr[1] = "";
                dr[2] = amt;
                dr[3] = "";
                dt.Rows.Add(dr);
            }

            if (dt.Rows.Count > 0)
            {
                Grid_Account.DataSource = dt;
                Grid_Account.DataBind();
            }
            else
            {
                Grid_Account.DataSource = dt;
                Grid_Account.DataBind();
            }
            ViewState["CurrentData"] = dt;
        }

        private void clear()
        {
            ddl_branch.SelectedIndex = -1;
            txt_recp.Text = "";
            ddl_mode.SelectedValue = "0";
            txt_recieve.Text = "";
            txt_amt.Text = "";
            txt_cheque.Text = "";
            txt_bank.Text = "";
            txt_branch1.Text = "";
            txt_narration.Text = "";
            txt_cust.Text = "";
            txt_cust_amt.Text = "";
            txt_deduction.Text = "";
            txt_dedu_amt.Text = "";
            txt_excess_amt.Text = "";
            txt_fvr.Text = "";
            txt_cust_amt.Enabled = true;
            txt_depositbank.Text = "";
            backdate = Convert.ToInt32(HttpContext.Current.Session["Vouyear"]);

            txt_recpdate.Text = backdate.ToString();
            if (Hydvis.Visible == true)
            {
                Hydvis.Visible = false;
            }
            int getDateMonthNow = DateTime.Now.Month;
            int getDateYearNow = DateTime.Now.Year;
            //if (Session["LoginDivisionId"].ToString() == "1" || Session["LoginDivisionId"].ToString() == "3")
            //{
            //    getDateYearNow = getDateYearNow - 1;
            //    lastDay = new DateTime(getDateYearNow, 12, 31);
            //}
            //else
            //{

            //}
            if (getDateMonthNow < 4)
            {
                getDateYearNow = getDateYearNow - 1;
            }
            else
            {
                getDateYearNow = DateTime.Now.Year;
            }
            lastDay = new DateTime(getDateYearNow, 4, 1).AddDays(-1);
            txt_date.Text = lastDay.ToString();
            txt_date.Text = Utility.fn_ConvertDate(txt_date.Text);
            txt_cheqdate.Text = txt_date.Text;

            if (Chk_Account.Checked == true)
            {
                Chk_Account.Checked = false;
            }

            if (txt_recp.Text != "")
            {
                btn_cust_add.Enabled = true;
                btn_deduct_add.Enabled = false;
                btn_short_add.Enabled = false;
                txt_cust.Enabled = true;
                txt_cust_amt.Enabled = true;
                divPayment.Visible = false;
                txt_cheqdate.Enabled = false;
                txt_bank.Enabled = false;
                txt_branch1.Enabled = false;
                btn_delete.Enabled = false;
            }

            txt_refno.Text = "";
            txt_total.Text = "";
            lbl_amountinword.Visible = false;
            Grid_Account.DataSource = Utility.Fn_GetEmptyDataTable();
            Grid_Account.DataBind();
            Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
            Grid_detail.DataBind();
            btn_back.ToolTip = "Back";
            save_id.Visible = true;
            btn_save.Visible = true;
            btn_save.Enabled = true;
            ddl_mode.Enabled = true;
            txt_fvr.Visible = false;
            lbl_fvr.Visible = false;
            txt_refno.Visible = false;
            lbl_refno.Visible = false;
            btn_cust_add.Enabled = true;

            btn_save.ForeColor = System.Drawing.Color.White;

            if (Session["StrTranType"].ToString() == "AC")
            {
                branchpay = "B";
            }

            if (branchpay == "B")
            {
                //Chk_accountpayee.Visible = false;
                //lnk_amount.Enabled = false;
            }
            else
            {

            }

            //if (lbl_head.Text == "FY End Back Dated Receipts" && Session["StrTranType"].ToString() == "CO")
            //{
            //    //ddl_mode.Items.Add("");
            //    ddl_mode.Items.Add("Petty Cash");
            //}
            //else if (lbl_head.Text == "FY End Back Dated Receipts" && Session["StrTranType"].ToString() == "AC")
            //{
            //    //ddl_mode.Items.Add("");
            //    ddl_mode.Items.Add("Cheque/DD");
            //    ddl_mode.Items.Add("Petty Cash");
            //}

            ViewState["btn_ok_Grid_detail"] = null;
            ViewState["btn_ok_Grid_Account"] = null;
            ViewState["CurrentData"] = null;
            ViewState["dtPayment"] = null;
        }

        private void SaveAllGrdDetails4PayCash()
        {
            try
            {
                mode_set();
                int Vouyear = Convert.ToInt32(txt_recpdate.Text);

                if (blnerr == true)
                {
                    return;
                }

                recno = Convert.ToInt32(txt_recp.Text);
                int rid = 0;
                int Grdcashcustid;

                if (Session["rptype"].ToString() == "R")
                {
                    rid = Bank_Obj.GetRecrid(recno, bid, Convert.ToChar(mode), Vouyear);
                    Hid_Rid.Value = rid.ToString();
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    rid = Payment_Obj.GetPaymentid(recno, bid, Convert.ToChar(mode), Vouyear);
                    Hid_Rid.Value = rid.ToString();
                }

                for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                {
                    if (Grid_Account.Rows[i].Cells[0].Text == "Charge")
                    {
                        GrdChrgid = Charge_Obj.GetChargeid(Grid_Account.Rows[i].Cells[1].Text);
                        if (Session["rptype"].ToString() == "R")
                        {
                            Bank_Obj.InsReciptChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            Payment_Obj.InsPaymentChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                    }
                    else if (Grid_Account.Rows[i].Cells[0].Text == "EXCESS / SHORT")
                    {
                        if (Session["rptype"].ToString() == "R")
                        {
                            Bank_Obj.InsReciptChargeDetail(rid, 0, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            Payment_Obj.InsPaymentChargeDetail(rid, 0, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                    }
                }
                if (txt_refno.Text != "")
                {

                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                        {
                            Grdcashcustid = Convert.ToInt32(Grid_Account.Rows[i].Cells[3].Text);
                            if (Session["rptype"].ToString() == "P")
                            {
                                Payment_Obj.InsPaymentCustomerDetail(rid, Grdcashcustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                            }
                        }
                    }
                }
                else if (str_mode == "P")
                {
                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                        {
                            Grdcashcustid = Convert.ToInt32(Grid_Account.Rows[i].Cells[3].Text);
                            if (Session["rptype"].ToString() == "R")
                            {
                                Bank_Obj.InsReciptCustomerDetail(rid, Grdcashcustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                            }
                        }
                    }
                }
                else if (txt_refno.Text == "" && Session["rptype"].ToString() == "P" && str_mode == "C" && Grid_detail.Rows.Count == 0)
                {
                    for (int i = 0; i < Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                        {
                            Grdcashcustid = Convert.ToInt32(Grid_Account.Rows[i].Cells[3].Text);
                            if (Session["rptype"].ToString() == "P")
                            {
                                Payment_Obj.InsPaymentCustomerDetail(rid, Grdcashcustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        private void SaveAllGrdDetails()
        {
            try
            {
                int gbid = 0, cVal = 0, RAvouyear = 0, invno = 0, GrdCustid, GrdChrgid;
                double ramt = 0, vouamt = 0;
                string jltype = "", jrefno = "";
                int Vouyear = Convert.ToInt32(txt_recpdate.Text);
                //bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());

                mode_set();
                if (blnerr == true)
                {
                    return;
                }
                recno = Convert.ToInt32(txt_recp.Text);

                if (Session["rptype"].ToString() == "R")
                {
                    rid = Bank_Obj.GetRecrid(recno, bid, Convert.ToChar(mode), Vouyear);
                    slipno = Master_Branch.Getbranchname(bid).Substring(0, 3) + "/" + rid;
                    hid_depositslipino.Value = slipno.ToString();
                    Slip_ID = Bank_Obj.InsDepositSlip(slipno, Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), Convert.ToInt32(hid_bankdepositid.Value), txt_narration.Text, bid);
                    Hid_Rid.Value = rid.ToString();
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    rid = Payment_Obj.GetPaymentid(recno, bid, Convert.ToChar(mode), Vouyear);
                    //slipno = Master_Branch.Getbranchname(bid).Substring(0, 3) + "/" + rid;
                    //hid_depositslipino.Value = slipno.ToString();
                    //Slip_ID = Bank_Obj.InsDepositSlip(slipno, Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), Convert.ToInt32(hid_bankdepositid.Value), txt_narration.Text, bid);
                    Hid_Rid.Value = rid.ToString();
                }

                if (Session["rptype"].ToString() == "R")
                {
                    cVal = Convert.ToInt32(Grid_detail.Rows.Count);
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    cVal = Convert.ToInt32(Grid_detail.Rows.Count);
                }
                for (int i = 0; i < cVal; i++)
                {
                    TextBox reciept = (TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount");

                    if (reciept.Text == "")
                    {
                        reciept.Text = "0.00";
                    }
                    vtype = Grid_detail.Rows[i].Cells[5].Text.Trim();
                    ramt = Convert.ToDouble(reciept.Text);
                    if (ramt > 0 && vtype!="O") 
                    {
                        gbid = Convert.ToInt32(Grid_detail.Rows[i].Cells[0].Text);
                    
                        if (vtype == "J")
                        {
                            jrefno = Grid_detail.Rows[i].Cells[6].Text;
                        }
                        else
                        {
                            invno = Convert.ToInt32(Grid_detail.Rows[i].Cells[6].Text);
                        }

                        vouamt = Convert.ToDouble(Grid_detail.Rows[i].Cells[3].Text);
                        RAvouyear = Convert.ToInt32(Grid_detail.Rows[i].Cells[8].Text);
                        if (vouamt > ramt)
                        {
                            Setteled = 'N';
                        }
                        else
                        {
                            Setteled = 'Y';
                        }

                        char rtype = Convert.ToChar(Session["rptype"].ToString());
                        char vouchtype = Convert.ToChar(vtype);
                        if (vtype == "J")
                        {
                            jltype = Grid_detail.Rows[i].Cells[9].Text;
                            obj_recepay.InsRecptAginstInvjBackDated(rid, rtype, 0, vouchtype, gbid, vouamt, ramt, Setteled, RAvouyear, jrefno, jltype, Vouyear);
                            // Bank_Obj.InsRecptAginstInvj(rid, rtype, 0, vouchtype, gbid, vouamt, ramt, Setteled, RAvouyear, jrefno, jltype);
                        }
                        else
                        {
                            obj_recepay.InsRecptAginstInvBackDated(rid, rtype, invno, vouchtype, gbid, vouamt, ramt, Setteled, RAvouyear, Vouyear);
                        }

                        try
                        {
                            if (vtype == "J")
                            {
                                jltype = Grid_detail.Rows[i].Cells[9].Text;
                                Approve_Obj.UpdJnlDtls2FARP(IntCustId, vouchtype, RAvouyear, gbid, rid, rtype, Vouyear, ramt, "", 0.0, jrefno, jltype);
                            }
                            else
                            {
                                if (RAvouyear > 2011)
                                {
                                    Approve_Obj.UpdLedgerOPBreakup(invno, vouchtype, RAvouyear, gbid, rid, rtype, Vouyear, ramt, "", 0.0, "", "");
                                }
                                else
                                {
                                    chkledgerid = 0;
                                    chkledgerid = Ledger_Obj.ChkLedgeridfrmLedHead(IntCustId, "C", FADbname);
                                    if (chkledgerid == 0)
                                    {
                                        GetCustomerGroupId();
                                    }
                                    chkledgerid = Ledger_Obj.ChkLedgeridfrmLedHead(IntCustId, "C", FADbname);
                                    Approve_Obj.UpdLedgerOPBreakup4oldvou(chkledgerid, invno, vouchtype, RAvouyear, gbid, vouamt, "", 0, rid, rtype, Vouyear, ramt, "", 0.0, "", "", IntCustId);

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                           // Utility.SendMail(Session["usermailid"].ToString(), "", "", "Nambi", "FA RECEIPT PMT TRAN DTLS - ERROR VOU # " + invno.ToString() + " TRANID " + rid, ex.ToString());
                            return;
                        }

                        if (Session["rptype"].ToString() == "P")
                        {
                            if (vtype == "P" || vtype == "E")
                            {
                                ChqObj.UpdChequeApproval4Rcpt(invno, vouchtype, Vouyear, gbid, Convert.ToInt32(Session["LoginEmpId"]));
                            }
                        }
                    }
                }
                //Ruban
                if (Session["rptype"].ToString() == "R")
                {
                    if (str_mode == "C" || str_mode == "B")
                    {
                        Bank_Obj.UpdSlipDetails(Convert.ToInt32(Slip_ID), rid, bid, str_mode);
                    }
                }

                //old

                for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                {
                    if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                    {
                        GrdCustid = Convert.ToInt32(Grid_Account.Rows[i].Cells[3].Text);
                        if (Session["rptype"].ToString() == "R")
                        {
                            Bank_Obj.InsReciptCustomerDetail(rid, GrdCustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            Payment_Obj.InsPaymentCustomerDetail(rid, GrdCustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                    }
                    else if (Grid_Account.Rows[i].Cells[0].Text == "Charge")
                    {
                        GrdChrgid = Charge_Obj.GetChargeid(Grid_Account.Rows[i].Cells[1].Text);
                        if (Session["rptype"].ToString() == "R")
                        {
                            Bank_Obj.InsReciptChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            Payment_Obj.InsPaymentChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                    }
                    else if (Grid_Account.Rows[i].Cells[0].Text == "Excess / Short")
                    {
                        if (Session["rptype"].ToString() == "R")
                        {
                            Bank_Obj.InsReciptChargeDetail(rid, 0, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            Payment_Obj.InsPaymentChargeDetail(rid, 0, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                    }
                }
                if (Session["rptype"].ToString() == "R" || Session["rptype"].ToString() == "P")
                {
                    // For On Account
                    for (int i = 0; i < Grid_detail.Rows.Count; i++)
                    {
                        if (Grid_detail.Rows[i].Cells[2].Text == "On Account")
                        {
                            if (Grid_Account.Rows[0].Cells[0].Text == "Charge" && (Grid_Account.Rows[0].Cells[0].Text == "BANK CHARGES" || Grid_Account.Rows[0].Cells[0].Text == "BANK INTEREST") && ddl_branch.SelectedItem.ToString() == "CORPORATE")
                            {
                                ramt = Convert.ToDouble(Grid_Account.Rows[0].Cells[2].Text);
                            }
                            else
                            {
                                //ramt = Convert.ToDouble(Grid_detail.Rows[i].Cells[4].Text);
                                TextBox Rec_Amount = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (Rec_Amount.Text == "")
                                {
                                    Rec_Amount.Text = "0.00";
                                }
                                ramt = Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim());
                            }
                            if (ramt > 0)
                            {
                                char rtype = Convert.ToChar(Session["rptype"].ToString());
                                //IntCustId = Cust_Obj.GetCustomerid(txt_recieve.Text);
                                Bank_Obj.InsRecptAginstInv(rid, rtype, 0, 'O', bid, 0, ramt, 'Y', Vouyear);
                                chkledgerid = 0;
                                chkledgerid = Ledger_Obj.ChkLedgeridfrmLedHead(Convert.ToInt32(Hid_Receivedfrom.Value), "C", FADbname);
                                if (chkledgerid == 0)
                                {
                                    SubGroupId = 40;
                                    GroupId = 13;
                                    chkledgerid = Ledger_Obj.InsLedgerHeadfromTally(Cust_Obj.GetCustomername(Convert.ToInt32(Hid_Receivedfrom.Value)), SubGroupId, GroupId, 'G', Convert.ToInt32(Hid_Receivedfrom.Value), 'C', FADbname);
                                }
                                chkledgerid = Ledger_Obj.ChkLedgeridfrmLedHead(Convert.ToInt32(hid_custid.Value), "C", FADbname);
                                Approve_Obj.InsLedgerOPBreakup4OAC(chkledgerid, Vouyear, bid, rid, rtype, Vouyear, ramt, Convert.ToInt32(hid_custid.Value));
                            }
                        }

                    }
                }
              
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void txt_recieve_TextChanged(object sender, EventArgs e)
        {
            txt_amt.Focus();
        }

        protected void Grid_Account_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_Account_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "Select")
                {
                    foreach (GridViewRow Row in Grid_Account.Rows)
                    {
                        if (Row.RowType == DataControlRowType.DataRow)
                        {
                            for (int ColumnIndex = 0; ColumnIndex < Row.Cells.Count; ColumnIndex++)
                            {
                                Row.Cells[ColumnIndex].Attributes["style"] += "background-color:White;";
                            }
                        }
                    }
                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    Grid_Account.Rows[selectedRowIndex].Cells[selectedColumnIndex].Attributes["style"] += "background-color:Red;";

                    ViewState["Col_index"] = selectedColumnIndex;
                    ViewState["Row_Index"] = selectedRowIndex;
                    selectgridaccount(selectedRowIndex);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        public void selectgridaccount(int selectedRowIndex)
        {
            if (Session["rptype"].ToString() == "P")
            {
                if (Grid_Account.Rows.Count > 0)
                {
                    int Row_index = (int)ViewState["Row_Index"];
                    int Col_Index = (int)ViewState["Col_index"];

                    if (Col_Index == 2)
                    {
                        btn_cust_add.Enabled = true;
                        txt_cust_amt.Enabled = true;
                        txt_cust_amt.Text = Grid_Account.Rows[Row_index].Cells[2].Text;
                    }
                    else
                    {
                        btn_cust_add.Enabled = false;
                        txt_cust_amt.Enabled = false;
                        txt_cust_amt.Text = "";
                    }
                }
                if (txt_recp.Text == "")
                {
                    btn_delete.Enabled = true;
                }
                ViewState["Row_Index"] = "";
                ViewState["Col_index"] = "";
            }
        }

        protected void Grid_detail_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Grid_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) != 0)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    if (i == 14)
                    {

                    }
                    else
                    {
                        e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    }
                    Control c = e.Row.Cells[19].Controls[0];
                    this.SetFocus(c);
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_detail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txt_receiptamount_TextChanged(object sender, EventArgs e)
        {
            string IE = "";
            double inc = 0, exp = 0;
            double GrdAmnt;
            int RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            TextBox TxtAmount = ((TextBox)Grid_detail.Rows[RowIndex].FindControl("txt_receiptamount"));
            int GridCustID = Convert.ToInt32(Grid_detail.Rows[RowIndex].Cells[10].Text);

            //for (int g = 0; g <= Grid_detail.Rows.Count - 1; g++)
            //{
            //    if (GridCustID == Convert.ToInt32(Grid_detail.Rows[g].Cells[10].Text))
            //    {
            //        TextBox Txt_Amount = ((TextBox)Grid_detail.Rows[g].FindControl("txt_receiptamount"));
            //        rece_amnt = rece_amnt + Convert.ToDouble(Txt_Amount.Text);
            //    }
            //}

            //for (int g = 0; g <= Grid_Account.Rows.Count - 1; g++)
            //{
            //    if (GridCustID == Convert.ToInt32(Grid_Account.Rows[g].Cells[3].Text))
            //    {
            //        Grid_Account.Rows[g].Cells[2].Text = rece_amnt.ToString();
            //    }
            //}

            if (TxtAmount.Text == "")
            {
                TxtAmount.Text = "0.00";
            }

            if (Grid_detail.Rows[RowIndex].Cells[3].Text.ToString() != null)
            {
                if (double.TryParse(Grid_detail.Rows[RowIndex].Cells[3].Text.ToString(), out GrdAmnt))
                {
                    if (Convert.ToDouble(Grid_detail.Rows[RowIndex].Cells[3].Text.ToString()) < Convert.ToDouble(TxtAmount.Text))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt/Payment Amount Must be Less Than or Equal to Voucher Amount')", true);
                        TxtAmount.Text = "0.00";
                        return;
                    }
                }
            }

            if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
            {
                DataTable dtNew = new DataTable();
                dtNew = (DataTable)ViewState["dtPayment"];

                if (dtNew.Rows.Count > 0)
                {
                    for (int j = 0; j <= dtNew.Rows.Count - 1; j++)
                    {
                        TextBox txt_Receipt = (TextBox)Grid_detail.Rows[j].FindControl("txt_receiptamount");
                        if (txt_Receipt.Text != "")
                        {
                            dtNew.Rows[j]["ramount"] = txt_Receipt.Text;
                        }
                    }
                }
                ViewState["dtPayment"] = dtNew;
            }

            if (Session["rptype"].ToString() == "P")
            {
                foreach (GridViewRow Row in Grid_detail.Rows)
                {
                    RowVouType = Row.Cells[5].Text;
                }

                for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                {
                    IE = Grid_detail.Rows[i].Cells[5].Text.Trim();

                    if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "B" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "OB") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                    {
                        TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                        if (txt.Text == "")
                        {
                            txt.Text = "0.00";
                        }
                        inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "O" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                    {
                        TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                        if (txt.Text == "")
                        {
                            txt.Text = "0.00";
                        }
                        exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    }

                    // For Journal
                    if (Session["rptype"].ToString() == "R")
                    {
                        if (IE == "J")
                        {
                            if ((Grid_detail.Rows[i].Cells[9].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                            {
                                TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                            }
                            if ((Grid_detail.Rows[i].Cells[9].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                            {
                                TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                            }
                        }
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        if (IE == "J")
                        {
                            if ((Grid_detail.Rows[i].Cells[9].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                            {
                                TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                            }
                            else if ((Grid_detail.Rows[i].Cells[9].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                            {
                                TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                            }
                        }
                    }
                }
                txt_cust_amt.Text = (exp - inc).ToString("#0.00");
            }
            else if (Session["rptype"].ToString() == "R")
            {
                foreach (GridViewRow Row in Grid_detail.Rows)
                {
                    RowVouType = Row.Cells[5].Text;
                }

                for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                {
                    IE = Grid_detail.Rows[i].Cells[5].Text.Trim();

                    if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "O" || IE == "B" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "OB") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                    {
                        TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                        if (txt.Text == "")
                        {
                            txt.Text = "0.00";
                        }
                        inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                    {
                        TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                        if (txt.Text == "")
                        {
                            txt.Text = "0.00";
                        }
                        exp = Convert.ToDouble(exp) + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    }

                    if (IE == "J")
                    {
                        if ((Grid_detail.Rows[i].Cells[9].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                        {
                            TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                            if (txt.Text == "")
                            {
                                txt.Text = "0.00";
                            }
                            inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                        }
                        if ((Grid_detail.Rows[i].Cells[9].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                        {
                            TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                            if (txt.Text == "")
                            {
                                txt.Text = "0.00";
                            }
                            exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                        }
                    }
                }
                txt_cust_amt.Text = (inc - exp).ToString("#0.00");
            }
            for (int j = 0; j <= Grid_Account.Rows.Count - 1; j++)
            {
                if (Grid_Account.Rows[j].Cells[0].Text == "Customer")
                {
                    if (GridCustID == Convert.ToInt32(Grid_Account.Rows[j].Cells[3].Text))
                    {
                        Grid_Account.Rows[j].Cells[2].Text = txt_cust_amt.Text.ToString();
                    }
                }
            }

            if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
            {
                DataTable dt_GridAccount = new DataTable();
                dt_GridAccount = (DataTable)ViewState["CurrentData"];

                if (dt_GridAccount.Rows.Count > 0)
                {
                    for (int a = 0; a <= dt_GridAccount.Rows.Count - 1; a++)
                    {
                        if (Grid_Account.Rows[a].Cells[2].Text != "")
                        {
                            dt_GridAccount.Rows[a]["amount"] = Grid_Account.Rows[a].Cells[2].Text;
                        }
                    }
                    ViewState["CurrentData"] = dt_GridAccount;
                }
            }

            double Total_Amount = 0.0;
            for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
            {
                Total_Amount = Total_Amount + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
            }
            txt_total.Text = string.Format("{0:0.00}", Total_Amount);

            if (Grid_detail.Rows.Count > 0)
            {
                if (RowIndex != Grid_detail.Rows.Count - 1)
                {
                    TextBox chk = (TextBox)Grid_detail.Rows[RowIndex + 1].Cells[5].FindControl("txt_receiptamount");
                    chk.Focus();
                }

            }
        }

        protected void Grid_detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            double GrdAmnt;
            int RowIndex = Grid_detail.SelectedRow.RowIndex;
            double TotValue = Convert.ToDouble(Grid_detail.Rows[RowIndex].Cells[4].Text.ToString());
            if (Grid_detail.Rows[RowIndex].Cells[4].Text != null)
            {
                if (double.TryParse(Grid_detail.Rows[RowIndex].Cells[4].Text.ToString(), out GrdAmnt))
                {
                    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[RowIndex].FindControl("txt_receiptamount"));

                    if (TxtAmount.Text == "")
                    {
                        TxtAmount.Text = "0.00";
                    }

                    if (Convert.ToDouble(TxtAmount) < Convert.ToDouble(TxtAmount))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt/Payment Amount Must be Less Than or Equal to Voucher Amount')", true);
                        Grid_detail.Rows[RowIndex].Cells[4].Text = "0.00";
                    }
                }
            }
        }

        protected void Grid_Account_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[4].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                // Add events to each editable cell
                for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    // Add the column index as the event argument parameter
                    string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                    // Add this javascript to the onclick Attribute of the cell
                    e.Row.Cells[columnIndex].Attributes["onclick"] = js;
                    // Add a cursor style to the cells
                    e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                }
            }
        }

        protected void GetCustomerGroupId()
        {
            if (vtype == "I")
            {
                SubGroupId = 40;
                GroupId = 13;
            }
            else if (vtype == "V")
            {
                if (Cust_Obj.GetCustomerType(IntCustId) == "P")
                {
                    SubGroupId = 65;
                    GroupId = 13;
                }
                else
                {
                    SubGroupId = 40;
                    GroupId = 13;
                }
            }
            else if (vtype == "E")
            {
                if (Cust_Obj.GetCustomerType(IntCustId) == "P")
                {
                    SubGroupId = 44;
                    GroupId = 12;
                }
                else
                {
                    SubGroupId = 67;
                    GroupId = 12;
                }
            }
            else if (vtype == "P")
            {
                SubGroupId = 67;
                GroupId = 12;
            }
            else if (vtype == "S")
            {
                SubGroupId = 41;
                GroupId = 12;
            }
            else if (vtype == "X")
            {
                SubGroupId = 40;
                GroupId = 13;
            }
            else if (vtype == "C")
            {
                SubGroupId = 44;
                GroupId = 12;
            }
            else if (vtype == "D")
            {
                SubGroupId = 65;
                GroupId = 13;
            }
            chkledgerid = Ledger_Obj.InsLedgerHeadfromTally(Cust_Obj.GetCustomername(IntCustId), SubGroupId, GroupId, 'G', IntCustId, 'C', FADbname);
        }

        protected void txt_deduction_TextChanged(object sender, EventArgs e)
        {
            txt_dedu_amt.Focus();
        }

        protected void Grid_Account_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void txt_recp_TextChanged(object sender, EventArgs e)
        {
            ddl_mode_SelectedIndexChanged(sender, e);
            ddl_mode_TextChanged(sender, e);
        }
        protected void chk_visak_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_visak.Checked == true)
            {
                chk_hyde.Enabled = false;
            }
            else
            {
                chk_hyde.Enabled = true;
            }

        }

        protected void chk_hyde_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_hyde.Checked == true)
            {
                chk_visak.Enabled = false;
            }
            else
            {
                chk_visak.Enabled = true;
            }

        }
        //Ruban to change

        protected void Chkrecpfc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double PA_Amount = 0, TDS_Amount = 0;
                CheckBox Chk1 = sender as CheckBox;
                GridViewRow row1 = (GridViewRow)Chk1.NamingContainer;
                List<string> ItemText = null;
                Boolean Check = false;


                if (row1.RowIndex != 0)
                {
                    int rowindex = 0;
                    double amt = 0.0;
                    Session["chkrpt"] = "false";
                    Check = false;
                    if (Session["chkrpt"].ToString() == "false")
                    {
                        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row1.RowIndex].FindControl("txt_receiptamount"));
                        TxtAmount.Text = amt.ToString();
                        TxtAmount.Focus();
                        rowindex = row1.RowIndex;
                        calculation(rowindex);
                        Grid_detail.Rows[row1.RowIndex].BackColor = System.Drawing.Color.Empty;
                        //if (Grid_detail.Rows[row1.RowIndex].Cells[2].Text != "On Account")
                        //{
                        //    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row1.RowIndex].FindControl("txt_receiptamount"));
                        //    TxtAmount.Text = amt.ToString();
                        //    TxtAmount.Focus();
                        //    rowindex = row1.RowIndex;
                        //    calculation(rowindex);
                        //    Grid_detail.Rows[row1.RowIndex].BackColor = System.Drawing.Color.Empty;
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CheckBox OnAccount", "alertify.alert('Kindly Enter the On Account Amount in TextBox');", true);
                        //    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row1.RowIndex].FindControl("txt_receiptamount"));
                        //    TxtAmount.Focus();
                        //    return;
                        //}
                    }
                }



                foreach (GridViewRow row in Grid_detail.Rows)
                {
                    CheckBox Chk = (CheckBox)Grid_detail.Rows[row.RowIndex].FindControl("Chkrecpfc");


                    if (Chk.Checked == true)
                    {
                        Check = true;
                        //ItemText.Add(Grid_detail.DataKeys[row.RowIndex].Values[5].ToString());

                        Session["chkrpt"] = "true";
                        string schstr = "", mchstr = "";
                        string[] strary;
                        int count = 0;
                        int rowindex = 0;
                        double amt = 0.0;


                        if (Session["rptype"] == "R")
                        {
                            if (Session["chkrpt"] != null)
                            {
                                if (Session["chkrpt"].ToString() == "true")
                                {
                                    amt = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[3].Text);
                                    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                    TxtAmount.Text = amt.ToString();
                                    rowindex = row.RowIndex;
                                    calculation(rowindex);
                                    TxtAmount.Focus();
                                    //if (Grid_detail.Rows[row.RowIndex].Cells[2].Text != "On Account")
                                    //{
                                    //    amt = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[3].Text);
                                    //    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                    //    TxtAmount.Text = amt.ToString();
                                    //    rowindex = row.RowIndex;
                                    //    calculation(rowindex);
                                    //    TxtAmount.Focus();
                                    //}
                                    //else
                                    //{
                                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CheckBox OnAccount", "alertify.alert('Kindly Enter the On Account Amount in TextBox');", true);
                                    //    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                    //    TxtAmount.Focus();
                                    //    return;
                                    //}


                                }
                            }

                            Grid_detail.Rows[row.RowIndex].BackColor = System.Drawing.Color.Gray;
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            if (Session["chkrpt"] != null)
                            {

                                if (Session["chkrpt"].ToString() == "true")
                                {
                                    amt = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[3].Text);
                                    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                    TxtAmount.Text = amt.ToString();
                                    rowindex = row.RowIndex;
                                    calculation(rowindex);
                                    TxtAmount.Focus();
                                    //if (Grid_detail.Rows[row.RowIndex].Cells[2].Text != "On Account")
                                    //{
                                    //    amt = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[3].Text);
                                    //    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                    //    TxtAmount.Text = amt.ToString();

                                    //    rowindex = row.RowIndex;
                                    //    calculation(rowindex);
                                    //    TxtAmount.Focus();
                                    //}
                                    //else
                                    //{
                                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CheckBox OnAccount", "alertify.alert('Kindly Enter the On Account Amount in TextBox');", true);
                                    //    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                    //    TxtAmount.Focus();
                                    //    return;
                                    //}

                                }
                            }

                            Grid_detail.Rows[row.RowIndex].BackColor = System.Drawing.Color.Cyan;
                        }


                        if (Session["rptype"] == "R")
                        {
                            if (count == Grid_detail.Rows.Count - 1)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Voucher # does not Exists');", true);
                                return;
                            }
                        }
                        else
                        {
                            if (count == Grid_detail.Rows.Count)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Voucher # does not Exists');", true);
                                return;
                            }
                        }
                        if (row.RowIndex != 0)
                        {
                            TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                            TxtAmount.Focus();
                        }



                    }
                    //else
                    //{
                    //    double amt = 0.0;
                    //    Session["chkrpt"] = "false";
                    //    Check = false;

                    //    if (Session["chkrpt"].ToString() == "false")
                    //    {

                    //        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                    //        TxtAmount.Text = amt.ToString();
                    //        TxtAmount.Focus();
                    //        calculation(row.RowIndex);
                    //        Grid_detail.Rows[row.RowIndex].BackColor = System.Drawing.Color.Empty;
                    //    }
                    //}
                    if (Grid_detail.Rows.Count > 0)
                    {

                        GridViewRow row2 = (sender as CheckBox).Parent.Parent as GridViewRow;

                        int index = row2.RowIndex;
                        if (index != Grid_detail.Rows.Count - 1)
                        {
                            CheckBox chk = (CheckBox)Grid_detail.Rows[index + 1].Cells[5].FindControl("Chkrecpfc");
                            chk.Focus();
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        protected void txtsch_TextChanged(object sender, EventArgs e)
        {
            string schstr = "", mchstr = "";
            string[] strary;
            int count = 0;
            int rowindex = 0;
            double amt = 0.0;
            if (Grid_detail.Rows.Count > 0 && txtsch.Text != "")
            {
                if (txtsch.Text != "" && (cmbvoutype.Text != "" && cmbvoutype.Text != "Vou Type"))
                {
                    schstr = cmbvoutype.Text.Trim() + " - " + txtsch.Text.Trim();
                }
                else if (txtsch.Text != "" && cmbvoutype.Text == "Vou Type")
                {
                    schstr = txtsch.Text.Trim();
                }

                if (Session["rptype"] == "R")
                {
                    for (int i = 0; i <= Grid_detail.Rows.Count - 2; i++)
                    {
                        if (txtsch.Text != "" && cmbvoutype.Text != "" && cmbvoutype.Text != "Vou Type")
                        {
                            mchstr = Grid_detail.Rows[i].Cells[2].Text;
                        }
                        else if (txtsch.Text != "")
                        {
                            mchstr = Grid_detail.Rows[i].Cells[2].Text;
                            strary = mchstr.Split('-');
                            mchstr = strary[1].Remove(0, 1);
                        }
                        if (schstr == mchstr)
                        {
                            rowindex = i;

                            if (cmbvoutype.Text != "" && cmbvoutype.Text != "Vou Type")
                            {

                                if (Session["chkrpt"] != null)
                                {
                                    if (Session["chkrpt"].ToString() == "true")
                                    {
                                        amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[3].Text);
                                        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[rowindex].FindControl("txt_receiptamount"));
                                        TxtAmount.Text = amt.ToString();
                                        TxtAmount.Focus();
                                        calculation(rowindex);

                                    }
                                }
                            }
                            Grid_detail.Rows[i].BackColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            Grid_detail.Rows[i].BackColor = System.Drawing.Color.Empty;
                            count = count + 1;
                        }
                    }
                }

                else if (Session["rptype"] == "P")
                {
                    for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                    {
                        if (txtsch.Text != "" && cmbvoutype.Text != "" && cmbvoutype.Text != "Vou Type")
                        {
                            mchstr = Grid_detail.Rows[i].Cells[2].Text;
                        }
                        else if (txtsch.Text != "")
                        {
                            mchstr = Grid_detail.Rows[i].Cells[2].Text;
                            strary = mchstr.Split('-');
                            mchstr = strary[1].Remove(0, 1);
                        }
                        if (schstr == mchstr)
                        {
                            rowindex = i;



                            if (cmbvoutype.Text != "" && cmbvoutype.Text != "Vou Type")
                            {

                                if (Session["chkrpt"] != null)
                                {
                                    if (Session["chkrpt"].ToString() == "true")
                                    {
                                        amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[3].Text);
                                        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[rowindex].FindControl("txt_receiptamount"));
                                        TxtAmount.Text = amt.ToString();
                                        TxtAmount.Focus();
                                        calculation(rowindex);

                                    }
                                }
                            }

                            Grid_detail.Rows[i].BackColor = System.Drawing.Color.Cyan;
                        }
                        else
                        {
                            Grid_detail.Rows[i].BackColor = System.Drawing.Color.Empty;
                            count = count + 1;
                        }
                    }
                }



                if (Session["rptype"] == "R")
                {
                    if (count == Grid_detail.Rows.Count - 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Voucher # does not Exists');", true);
                        return;
                    }
                }
                else
                {
                    if (count == Grid_detail.Rows.Count)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Voucher # does not Exists');", true);
                        return;
                    }
                }
                if (rowindex != 0)
                {
                    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[rowindex].FindControl("txt_receiptamount"));
                    TxtAmount.Focus();
                }

            }

            else
            {

            }
        }

        protected void cmbvoutype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsch_TextChanged(sender, e);
        }

        public void calculation(int rowindex)
        {


            string IE = "";
            double inc = 0, exp = 0;
            double GrdAmnt;
            int GridCustID = 0;
            int RowIndex = rowindex;//((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            TextBox TxtAmount = ((TextBox)Grid_detail.Rows[RowIndex].FindControl("txt_receiptamount"));
            if (Grid_detail.Rows[RowIndex].Cells[10].Text != "")
            {
                GridCustID = Convert.ToInt32(Grid_detail.Rows[RowIndex].Cells[10].Text);
            }


            if (TxtAmount.Text == "")
            {
                TxtAmount.Text = "0.00";
            }

            if (Grid_detail.Rows[RowIndex].Cells[3].Text.ToString() != null)
            {
                if (double.TryParse(Grid_detail.Rows[RowIndex].Cells[3].Text.ToString(), out GrdAmnt))
                {
                    if (Convert.ToDouble(Grid_detail.Rows[RowIndex].Cells[3].Text.ToString()) < Convert.ToDouble(TxtAmount.Text.TrimStart().TrimEnd().Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt/Payment Amount Must be Less Than or Equal to Voucher Amount')", true);
                        TxtAmount.Text = "0.00";
                        return;
                    }
                }
            }

            if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
            {
                DataTable dtNew = new DataTable();
                dtNew = (DataTable)ViewState["dtPayment"];

                if (dtNew.Rows.Count > 0)
                {
                    for (int j = 0; j <= dtNew.Rows.Count - 1; j++)
                    {
                        TextBox txt_Receipt = (TextBox)Grid_detail.Rows[j].FindControl("txt_receiptamount");
                        if (txt_Receipt.Text != "")
                        {
                            dtNew.Rows[j]["ramount"] = txt_Receipt.Text.TrimStart().TrimEnd().Trim();

                        }
                    }
                }
                ViewState["dtPayment"] = dtNew;
            }


            if (Session["rptype"].ToString() == "P")
            {
                foreach (GridViewRow Row in Grid_detail.Rows)
                {
                    RowVouType = Row.Cells[5].Text.Trim();
                }

                for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                {
                    IE = Grid_detail.Rows[i].Cells[5].Text.Trim();

                    if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "B" || IE == "OB") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                    {
                        TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                        if (txt.Text == "")
                        {
                            txt.Text = "0.00";
                        }
                        inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "O" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                    {
                        TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                        if (txt.Text == "")
                        {
                            txt.Text = "0.00";
                        }
                        exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    }

                    // For Journal
                    if (Session["rptype"].ToString() == "R")
                    {
                        if (IE == "J")
                        {
                            if ((Grid_detail.Rows[i].Cells[9].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                            {
                                TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                            }
                            if ((Grid_detail.Rows[i].Cells[9].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                            {
                                TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                            }
                        }
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        if (IE == "J")
                        {
                            if ((Grid_detail.Rows[i].Cells[9].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                            {
                                TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                            }
                            else if ((Grid_detail.Rows[i].Cells[9].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                            {
                                TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                            }
                        }
                    }
                }
                txt_cust_amt.Text = (exp - inc).ToString("#0.00");
            }
            else if (Session["rptype"].ToString() == "R")
            {
                foreach (GridViewRow Row in Grid_detail.Rows)
                {
                    RowVouType = Row.Cells[5].Text.Trim();
                }

                for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                {
                    IE = Grid_detail.Rows[i].Cells[5].Text.Trim();

                    if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "O" || IE == "OI" || IE == "OD" || IE == "B" || IE == "OB" || IE == "OV" || IE == "OX") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                    {
                        TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                        if (txt.Text == "")
                        {
                            txt.Text = "0.00";
                        }
                        inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                    {
                        TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                        if (txt.Text == "")
                        {
                            txt.Text = "0.00";
                        }
                        exp = Convert.ToDouble(exp) + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    }

                    if (IE == "J")
                    {
                        if ((Grid_detail.Rows[i].Cells[9].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                        {
                            TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                            if (txt.Text == "")
                            {
                                txt.Text = "0.00";
                            }
                            inc = inc + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                        }
                        if ((Grid_detail.Rows[i].Cells[9].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text)))
                        {
                            TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                            if (txt.Text == "")
                            {
                                txt.Text = "0.00";
                            }
                            exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                        }
                    }
                }
                txt_cust_amt.Text = (inc - exp).ToString("#0.00");
            }

            for (int j = 0; j <= Grid_Account.Rows.Count - 1; j++)
            {
                if (Grid_Account.Rows[j].Cells[0].Text == "Customer")
                {
                    if (Grid_Account.Rows[j].Cells[3].Text != "")
                    {
                        if (GridCustID == Convert.ToInt32(Grid_Account.Rows[j].Cells[3].Text))
                        {
                            Grid_Account.Rows[j].Cells[2].Text = txt_cust_amt.Text.ToString();
                        }
                    }
                }
            }

            if (ViewState["CurrentData"] != null && !ViewState["CurrentData"].Equals("-1"))
            {
                DataTable dt_GridAccount = new DataTable();
                dt_GridAccount = (DataTable)ViewState["CurrentData"];

                if (dt_GridAccount.Rows.Count > 0)
                {
                    for (int a = 0; a <= dt_GridAccount.Rows.Count - 1; a++)
                    {
                        if (Grid_Account.Rows[a].Cells[2].Text != "")
                        {
                            dt_GridAccount.Rows[a]["amount"] = Grid_Account.Rows[a].Cells[2].Text;
                        }
                    }
                    ViewState["CurrentData"] = dt_GridAccount;
                }
            }

            double Total_Amount = 0.0;
            for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
            {
                Total_Amount = Total_Amount + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
            }
            txt_total.Text = string.Format("{0:0.00}", Total_Amount);

        }

        protected void chkrpt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkrpt.Checked == true)
            {
                Session["chkrpt"] = "true";
            }
            else
            {
                Session["chkrpt"] = "false";
            }
        }
        //Ruban add for BOS
        private void BOS()
        {
            try
            {
                int Custid, b = 0;
                DataTable dtInvoice1 = new DataTable();

                if (hid_custid.Value != "")
                {
                    Custid = Convert.ToInt32(hid_custid.Value);
                    dtInvoice1 = Bank_Obj.GetInvRecptDtls1BOS(Custid, did);
                    DataTable dttemp = new DataTable();
                    DataRow dtrow;

                    if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                    {
                        dttemp = (DataTable)ViewState["dtPayment"];
                        b = dttemp.Rows.Count;
                    }

                    if (dtInvoice1.Rows.Count > 0)
                    {
                        if (b == 0)
                        {
                            dttemp.Columns.Add("branchHide", typeof(string));
                            dttemp.Columns.Add("branch", typeof(string));
                            dttemp.Columns.Add("invoiceno", typeof(string));
                            dttemp.Columns.Add("iamount", typeof(string));
                            dttemp.Columns.Add("ramount", typeof(string));
                            dttemp.Columns.Add("voutype", typeof(string));
                            dttemp.Columns.Add("vouno", typeof(string));
                            dttemp.Columns.Add("tds", typeof(string));
                            dttemp.Columns.Add("ravouyear", typeof(string));
                            dttemp.Columns.Add("ltype", typeof(string));
                            dttemp.Columns.Add("Cust_Id", typeof(string));
                            dttemp.Columns.Add("vendorrefno", typeof(string));
                            dttemp.Columns.Add("vendorrefdate", typeof(string));
                            dttemp.Columns.Add("jlid", typeof(string));
                        }
                        for (int i = 0; i < dtInvoice1.Rows.Count; i++)
                        {
                            dtrow = dttemp.NewRow();
                            dtrow["branchHide"] = dtInvoice1.Rows[i][0].ToString();
                            dtrow["branch"] = dtInvoice1.Rows[i][1].ToString();
                            dtrow["invoiceno"] = "BOS - " + dtInvoice1.Rows[i][2].ToString();
                            dtrow["iamount"] = dtInvoice1.Rows[i][3].ToString();
                            dtrow["ramount"] = dtInvoice1.Rows[i][4].ToString();
                            dtrow["voutype"] = dtInvoice1.Rows[i][5].ToString();
                            dtrow["vouno"] = dtInvoice1.Rows[i][2].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtInvoice1.Rows[i][6].ToString();
                            dtrow["ltype"] = "";
                            dtrow["Cust_Id"] = Custid;
                            dtrow["vendorrefno"] = "";
                            dtrow["vendorrefdate"] = "";
                            dtrow["jlid"] = "";
                            dttemp.Rows.Add(dtrow);
                        }

                        Grid_detail.DataSource = dttemp;
                        Grid_detail.DataBind();
                        ViewState["dtPayment"] = dttemp;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }
        private void Grid_detail_CellContentClick(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > 0)
            {
                int rowindex = e.Row.RowIndex;
                GridViewRow row = this.Grid_detail.Rows[rowindex];
            }

        }
        //New
        private void OBBreakUp4rectpmt()
        {
            DataTable dtINV = new DataTable();
            int Customer_Id, a = 0;
            if (hid_custid.Value != "")
            {

                Customer_Id = Convert.ToInt32(hid_custid.Value);
                dtINV = Bank_Obj.RecPaymCalc4OBBreakup(Customer_Id, did);
                DataTable dttemp3 = new DataTable();
                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                {
                    dttemp3 = (DataTable)ViewState["dtPayment"];
                    a = dttemp3.Rows.Count;
                }

                if (dtINV.Rows.Count > 0)
                {
                    if (a == 0)
                    {
                        dttemp3.Columns.Add("branchHide", typeof(string));
                        dttemp3.Columns.Add("branch", typeof(string));
                        dttemp3.Columns.Add("invoiceno", typeof(string));
                        dttemp3.Columns.Add("iamount", typeof(string));
                        dttemp3.Columns.Add("ramount", typeof(string));
                        dttemp3.Columns.Add("voutype", typeof(string));
                        dttemp3.Columns.Add("vouno", typeof(string));
                        dttemp3.Columns.Add("tds", typeof(string));
                        dttemp3.Columns.Add("ravouyear", typeof(string));
                        dttemp3.Columns.Add("ltype", typeof(string));
                        dttemp3.Columns.Add("Cust_Id", typeof(string));
                        dttemp3.Columns.Add("vendorrefno", typeof(string));
                        dttemp3.Columns.Add("vendorrefdate", typeof(string));
                        dttemp3.Columns.Add("jlid", typeof(string));
                    }

                    for (int i = 0; i < dtINV.Rows.Count; i++)
                    {
                        DataRow dtrow = dttemp3.NewRow();
                        dtrow["branchHide"] = dtINV.Rows[i][0].ToString();
                        dtrow["branch"] = dtINV.Rows[i][1].ToString();

                        if (dtINV.Rows[i][5].ToString() == "OI")
                        {
                            dtrow["invoiceno"] = "OB Inv - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OD")
                        {
                            dtrow["invoiceno"] = "OB OSDN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OV")
                        {
                            dtrow["invoiceno"] = "OB DN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OX")
                        {
                            dtrow["invoiceno"] = "OB ADN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OP")
                        {
                            dtrow["invoiceno"] = "OB CNOps - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OC")
                        {
                            dtrow["invoiceno"] = "OB OSCN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OE")
                        {
                            dtrow["invoiceno"] = "OB CN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OS")
                        {
                            dtrow["invoiceno"] = "OB ACN - " + dtINV.Rows[i][2].ToString();
                        }
                        dtrow["iamount"] = dtINV.Rows[i][3].ToString();
                        dtrow["ramount"] = dtINV.Rows[i][4].ToString();
                        dtrow["voutype"] = dtINV.Rows[i][5].ToString();
                        dtrow["vouno"] = dtINV.Rows[i][2].ToString();
                        dtrow["tds"] = "";
                        dtrow["ravouyear"] = dtINV.Rows[i][6].ToString();
                        dtrow["ltype"] = "";
                        dtrow["Cust_Id"] = Customer_Id;

                        dtrow["vendorrefno"] = "";
                        dtrow["vendorrefdate"] = "";
                        dtrow["jlid"] = "";
                        dttemp3.Rows.Add(dtrow);
                    }
                    Grid_detail.DataSource = dttemp3;
                    Grid_detail.DataBind();
                    ViewState["dtPayment"] = dttemp3;
                }
            }
        }

        private void OBBreakUp()
        {
            DataTable dtINV = new DataTable();
            int Customer_Id, a = 0;
            if (hid_custid.Value != "")
            {

                Customer_Id = Convert.ToInt32(hid_custid.Value);
                dtINV = Bank_Obj.GetOBRecptDtls(Customer_Id, did);
                DataTable dttemp3 = new DataTable();
                if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                {
                    dttemp3 = (DataTable)ViewState["dtPayment"];
                    a = dttemp3.Rows.Count;
                }

                if (dtINV.Rows.Count > 0)
                {
                    if (a == 0)
                    {
                        dttemp3.Columns.Add("branchHide", typeof(string));
                        dttemp3.Columns.Add("branch", typeof(string));
                        dttemp3.Columns.Add("invoiceno", typeof(string));
                        dttemp3.Columns.Add("iamount", typeof(string));
                        dttemp3.Columns.Add("ramount", typeof(string));
                        dttemp3.Columns.Add("voutype", typeof(string));
                        dttemp3.Columns.Add("vouno", typeof(string));
                        dttemp3.Columns.Add("tds", typeof(string));
                        dttemp3.Columns.Add("ravouyear", typeof(string));
                        dttemp3.Columns.Add("ltype", typeof(string));
                        dttemp3.Columns.Add("Cust_Id", typeof(string));
                        dttemp3.Columns.Add("vendorrefno", typeof(string));
                        dttemp3.Columns.Add("vendorrefdate", typeof(string));
                        dttemp3.Columns.Add("jlid", typeof(string));
                    }


                    for (int i = 0; i < dtINV.Rows.Count; i++)
                    {
                        DataRow dtrow = dttemp3.NewRow();
                        dtrow["branchHide"] = dtINV.Rows[i][0].ToString();
                        dtrow["branch"] = dtINV.Rows[i][1].ToString();

                        if (dtINV.Rows[i][5].ToString() == "OI")
                        {
                            dtrow["invoiceno"] = "OB Inv - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OD")
                        {
                            dtrow["invoiceno"] = "OB OSDN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OV")
                        {
                            dtrow["invoiceno"] = "OB DN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OX")
                        {
                            dtrow["invoiceno"] = "OB ADN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OP")
                        {
                            dtrow["invoiceno"] = "OB CNOps - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OC")
                        {
                            dtrow["invoiceno"] = "OB OSCN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OE")
                        {
                            dtrow["invoiceno"] = "OB CN - " + dtINV.Rows[i][2].ToString();
                        }
                        else if (dtINV.Rows[i][5].ToString() == "OS")
                        {
                            dtrow["invoiceno"] = "OB ACN - " + dtINV.Rows[i][2].ToString();
                        }
                        dtrow["iamount"] = dtINV.Rows[i][3].ToString();
                        dtrow["ramount"] = dtINV.Rows[i][4].ToString();
                        dtrow["voutype"] = dtINV.Rows[i][5].ToString();
                        dtrow["vouno"] = dtINV.Rows[i][2].ToString();
                        dtrow["tds"] = "";
                        dtrow["ravouyear"] = dtINV.Rows[i][6].ToString();
                        dtrow["ltype"] = "";
                        dtrow["Cust_Id"] = Customer_Id;
                        dtrow["vendorrefno"] = dtINV.Rows[i][8].ToString();
                        dtrow["vendorrefdate"] = "";
                        dtrow["jlid"] = "";
                        dttemp3.Rows.Add(dtrow);
                    }
                    Grid_detail.DataSource = dttemp3;
                    Grid_detail.DataBind();
                    ViewState["dtPayment"] = dttemp3;
                }
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
            Panel4.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            if (Session["rptype"].ToString() == "R")
            {
                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1323, "", "", "", Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1320, "", "", "", Session["StrTranType"].ToString());
                }
            }
            else if (Session["rptype"].ToString() == "P")
            {
                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1324, "", "", "", Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1321, "", "", "", Session["StrTranType"].ToString());
                }

            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void Grid_detail_PreRender(object sender, EventArgs e)
        {
            if (Grid_detail.Rows.Count > 0)
            {
                Grid_detail.UseAccessibleHeader = true;
                Grid_detail.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_Account_PreRender(object sender, EventArgs e)
        {
            if (Grid_Account.Rows.Count > 0)
            {
                Grid_Account.UseAccessibleHeader = true;
                Grid_Account.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}


