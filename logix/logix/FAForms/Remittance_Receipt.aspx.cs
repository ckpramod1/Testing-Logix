using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Data.OleDb;
using ClosedXML.Excel;


namespace logix.FAForms
{
    public partial class Remittance_Receipt : System.Web.UI.Page
    {
        DataTable dataNewTable = new DataTable();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCustomer cusobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Recipts bankobj = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Recipts recinvobj = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Recipts recupdobj = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Recipts recgenobj = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Payment pymtobj = new DataAccess.Accounts.Payment();
        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.NotOverCheque objnoc = new DataAccess.Accounts.NotOverCheque();
        DataAccess.Masters.MasterChequeReq_App ChqObj = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Masters.MasterBranch BranObj = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.FAMaster.MasterLedger Ldrobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.FAMaster.MasterLedger lobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.FAVoucher FAObj = new DataAccess.FAVoucher();
        DataAccess.Accounts.Recipts Bank_Obj = new DataAccess.Accounts.Recipts();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        string rptype, amt, val, dispyear = "", dy1 = "", IE = "", rowVouType, custRcharname, str_mode, RowVouType;
        string branchpay, customername, cutype, setteled, vtype, submenuname, amt1, Rs, Ps, vtens, Rtens, sf, par;
        int branchid, custid, cheqdate, next = 1;
        int rid, dy, rw, rfcustid, recno, s, tens, Gtens;
        int grd_nono, chkledgerid, cust_index, ledgerid;
        char RPtype, ACPayee, mode;
        double PartyAmt, total, inc = 0, exp = 0, Total = 0, camt, expTotamt, incTotamt, grdTotamt, CustAmt, sumiamount, tdsamt, tdsamount, GrdAmt, amtTDS, amtPay, exr;
        DateTime Recdate, chqdate, currdate;
        int GrdChrgid, intctcustid, intchargeid, intupcustid, intupchargeid, divisionid, i, bankid, iamt, invno, index, ccid;
        string FADbname = "1516";
        Boolean getfromnoc, Bln_ChkMinMaxAmt;
        int did = 0;
        string exrate = "";
        string ledgername;
        DateTime dtDate;
        double grdinramt = 0;
        double totinramount = 0;
        double glamt = 0;
        double Es;
        double chrgamt = 0;
        double tfcamount;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        Boolean bolCust = false;
        int intBnkLedgID;
        int subgroupid;
        int groupid;
        int rfCustid;
        bool custexist = false;
        int rowIndex;
        //char ACPayee;
        int rowCount;
        int intcustid;
        DateTime dTTime;
        DateTime lastDay;
        string fcAmount;
        Boolean blner = false;
        DataTable dtTable = new DataTable();
        DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();


        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                INVOICEobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                cusobj.GetDataBase(Ccode);
                bankobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                recobj.GetDataBase(Ccode);
                recinvobj.GetDataBase(Ccode);
                recupdobj.GetDataBase(Ccode);
                recgenobj.GetDataBase(Ccode);


                pymtobj.GetDataBase(Ccode);
                chrgobj.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                objnoc.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                ChqObj.GetDataBase(Ccode);
                BranObj.GetDataBase(Ccode);
                Ldrobj.GetDataBase(Ccode);
                lobj.GetDataBase(Ccode);


                FAObj.GetDataBase(Ccode);
                Emp_Obj.GetDataBase(Ccode);
                Bank_Obj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
              

            }



            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnexcel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Session["Loginyear"].ToString() == Session["Vouyear"].ToString())
            {

            }
            else
            {
                btn_save1.Visible = false;
                btn_save.Visible = false;
            }
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            if (!IsPostBack)
            {
                txt_recp.Focus();
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                //lbl_head.Text = Request.QueryString["type"].ToString();

                if (Request.QueryString.ToString().Contains("FormName") || Request.QueryString.ToString().Contains("type"))
                {
                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lbl_head.Text = Request.QueryString["FormName"].ToString();
                        lbl_headr.Text = lbl_head.Text;
                    }
                    else if (Request.QueryString.ToString().Contains("type"))
                    {
                        lbl_head.Text = Request.QueryString["type"].ToString();
                    }

                }

                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_ok);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);

                if (lbl_head.Text == "Remittance - Payment")
                {
                    lbl_head.Text = "Remittance - Payment";
                }
                else
                {
                    lbl_head.Text = "Remittance - Receipt";
                    //HeaderLabel1.InnerText = "Remittance - Receipt";
                    //txt_recieve.ToolTip = "Receive";
                    //txt_recieve.Attributes.Add("placeholder", "Receive");
                }
                if (lbl_head.Text == "Remittance - Payment")
                {
                    lbl_title.Text = "R E M I T T A N C E-P A Y M E N T";
                    ViewState["rptype"] = null;
                    ViewState["extype"] = null;
                    ViewState["rptype"] = "P";
                    ViewState["extype"] = "R";
                    Session["rptype"] = "P";
                    // lnk_cheque.Visible = true;
                    // lnk_amount.Visible = true;
                    txt_recieve.Attributes.Add("placeholder", "Payment To");
                    txt_recieve.ToolTip = "Payment To";
                    txt_recp.Attributes.Add("placeholder", "Payment #");
                    txt_recp.ToolTip = "Payment #";
                    //ddl_branch.Items.Clear();
                    ddl_branch.Visible = true;
                    //ddl_branch.Items.Add("CORPORATE");
                    //ddl_branch.Visible = false;
                    txt_deduction.Attributes.Add("placeholder", "Charges");
                    txt_deduction.ToolTip = "Charges";
                    txt_deduction.Enabled = true;
                    txt_dedu_amt.Enabled = true;
                    //txt_refno.Visible = true;
                    //  btn_delete.Enabled = false;
                    Grid_detail.Columns[4].HeaderText = "Pymt-Amt";
                    branchpay = "B";

                }
                else
                {
                    ViewState["rptype"] = "R";
                    ViewState["extype"] = "R";
                    Session["rptype"] = "R";
                }

                txt_branch1.Text = "";//""TUTICORIN";
                txt_branch1.Enabled = true;
                cheqdate = Convert.ToInt32(HttpContext.Current.Session["Vouyear"].ToString());
                hid_year.Value = cheqdate.ToString();
                txt_recpdate.Text = cheqdate.ToString();
                txt_cheqdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                // dtDate = Convert.ToDateTime(txt_cheqdate.Text.ToString());
                // txt_cheqdate.Enabled = false;
                // txt_disable(false);
                //txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                int getDateMonthNow = DateTime.Now.Month;
                int getDateYearNow = DateTime.Now.Year;

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
                txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());

                ////string Branch = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
                //if (Session["StrTranType"].ToString() == "CO")
                //{
                //    dtTable = Emp_Obj.selBranchList(Session["LoginDivisionName"].ToString());
                //    if (dtTable.Rows.Count > 0)
                //    {
                //        ddl_branch.Items.Add("Branch");
                //        for (int i = 0; i <= dtTable.Rows.Count - 1; i++)
                //        {
                //            ddl_branch.Items.Add(dtTable.Rows[i]["branchname"].ToString());
                //        }
                //    }
                //    ddl_branch.Enabled = true;
                //}
                //else
                //{
                string Branch = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
                ddl_branch.Items.Add(Branch);
                ddl_branch.Enabled = false;
                ////lnk_amount.Enabled = false;
                ////lnk_cheque.Enabled = false;
                //}

                //ddl_branch.Items.Add("CORPORATE");
                //ddl_branch.Enabled = false;
                //  ddl_branch.Visible = false;
                //btn_cust_add.Attributes.Add("OnClick", "return IsDoubleCheck('txt_cust_amt');");
                //btn_deduct_add.Attributes.Add("OnClick", "return IsDoubleCheck('txt_dedu_amt');");
                //btn_short_add.Attributes.Add("OnClick", "return IsDoubleCheck('txt_excess_amt');");
                //  Btn_disable(false);
                txt_total.Enabled = false;
                txt_total1.Enabled = false;
                if (lbl_head.Text == "Remittance - Payment")
                {
                    //ddl_branch.Items.Clear();
                    ddl_branch.Visible = true;
                    //ddl_branch.Items.Add("CORPORATE");
                    ddl_mode.Items.Clear();
                    //ddl_mode.Items.Add("MODE");
                    //ddl_mode.Items.Add("Cash");
                    ddl_mode.Items.Add("Cheque/DD");
                    // ddl_mode.Items.Add("Petty Cash");
                    ddl_mode.SelectedValue = "Cheque/DD";
                    Grid_detail.Columns[7].HeaderText = "Pymt-Fc";
                    Grid_detail.Columns[8].HeaderText = "Pymt-FcAmt(Loc)";
                    Grid_detail.Columns[1].HeaderText = "Account Details";

                    txt_deduction.Attributes.Add("placeholder", "Charges");

                }
                else
                {
                    ddl_mode.Items.Clear();
                    //  ddl_mode.Items.Add("MODE");
                    //  ddl_mode.Items.Add("Cash");
                    ddl_mode.Items.Add("Cheque/DD");
                    // ddl_mode.Items.Add("Petty Cash");
                    ddl_mode.SelectedValue = "Cheque/DD";
                    lbl_amountinword.Visible = true;
                    txt_deduction.Attributes.Add("placeholder", "Deduction");
                    Grid_detail.Columns[7].HeaderText = "Recpt-Fc";
                    Grid_detail.Columns[8].HeaderText = "Recpt-FcAmt(Loc)";

                }
                txt_recieve.Focus();
                Grid_Account.DataSource = Utility.Fn_GetEmptyDataTable();
                Grid_Account.DataBind();
                btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
                Grid_detail.DataBind();
            }

            else
            {
                Ctrl_List = txt_recieve.ID + "~" + txt_recpdate.ID + "~" + txt_curr.ID + "~" + txt_rcvamt.ID + "~" + txt_exrate.ID + "~" + txt_amtrs.ID + "~" + txt_cheque.ID + "~" + txt_bank.ID + "~" + txt_branch1.ID + "~" + txt_cheqdate.ID + "~" + txt_narration.ID;
                Msg_List = "RECIEVE~RECEIPTYEAR~CURRENCY~RECEIVE AMOUNT~EXRATE~AMOUNT.RS~CHEQUE/DD~BANK~BRANCH~CHEQUE DATE~NARRATION";
                Dtype_List = "string~string~string~string~string~string~string~string~string~string~string";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
            }



        }

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            //   DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.FAMaster.MasterLedger Ldrobj = new DataAccess.FAMaster.MasterLedger();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Ldrobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            string dBNAME = HttpContext.Current.Session["FADbname"].ToString();
            dt = Ldrobj.GetLikeLedgernameLedger(prefix, did, bid, dBNAME);

            List_Result = Utility.Fn_DatatableToList_int16Display(dt, "LNandPort", "ledgerid", "ledgername");
            // dt = customerobj.GetLikeCustomer4Inbound(prefix, "P");
            //List_Result = Utility.Fn_TableToList(dt, "customer", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> Getledger(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.FAMaster.MasterLedger Ldrobj = new DataAccess.FAMaster.MasterLedger();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Ldrobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            string dBNAME = HttpContext.Current.Session["FADbname"].ToString();
            dt = Ldrobj.GetLikeLedgernameLedger(prefix, did, bid, dBNAME);
            List_Result = Utility.Fn_DatatableToList_int16Display(dt, "LNandPort", "ledgerid", "ledgername");
            return List_Result;
        }


        [WebMethod]
        public static List<string> GetCurrency(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterExRate obj_curr = new DataAccess.Masters.MasterExRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_curr.GetDataBase(Ccode);
            DataTable dt_curr = new DataTable();
            dt_curr = obj_curr.GetLikeCurrency(prefix);
            List_Result = Utility.Fn_TableToList(dt_curr, "currency", "currency");

            return List_Result;
        }


        //[WebMethod]
        //public static List<string> Getledger(string prefix)
        //{
        //    List<string> List_Result = new List<string>();
        //    DataAccess.FAMaster.MasterLedger Ldrobj = new DataAccess.FAMaster.MasterLedger();
        //    DataTable dt = new DataTable();
        //    int did=Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
        //    int bid=Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
        //    string dBNAME=HttpContext.Current.Session["FADbname"].ToString();
        //    dt = Ldrobj.GetLikeLedgernameLedger(prefix,did,bid,dBNAME);
        //    List_Result = Utility.Fn_TableToList(dt, "LNandPort", "customerid");
        //    return List_Result;
        //}

        //[WebMethod]
        //public static List<string> GetCheque(string prefix)
        //{
        //    List<string> List_Result = new List<string>();
        //    int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
        //    DataAccess.Accounts.NotOverCheque objnoc = new DataAccess.Accounts.NotOverCheque();
        //    DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        //    DataTable dt = new DataTable();
        //    int Branchid = hrempobj.GetBranchId(did, "branchname");
        //    dt = objnoc.GetNotOverChequelikeCheque(prefix, Branchid);
        //    List_Result = Utility.Fn_TableToList(prefix, dt, "ChequeNo");
        //    return List_Result;
        //}

        [WebMethod]
        public static List<string> GetBank(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Accounts.Recipts bankobj = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            bankobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string rtypeval = HttpContext.Current.Session["rptype"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            if (rtypeval == "P")
            {
                dt = bankobj.GetLikeBankNamefromBranch(prefix.ToUpper(), bid);
            }
            else
            {
                dt = bankobj.GetLikeBankNamefromBranch(prefix.ToUpper(), bid);
            }
            List_Result = Utility.Fn_TableToList(dt, "bankname", "bankid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCust(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            recobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string rtypeval = HttpContext.Current.Session["rptype"].ToString();
            if (rtypeval == "R")
            {
                dt = recobj.GetLikeReceiptCustomer(prefix);
            }
            else
            {
                dt = customerobj.GetLikeIndianCustomer(prefix);
            }
            List_Result = Utility.Fn_DatatableToList_int16Display(dt, "customer", "customerid", "customername");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetDeduction(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            chrgobj.GetDataBase(Ccode);
           
            DataTable dt = new DataTable();
            string rtypeval = HttpContext.Current.Session["rptype"].ToString();
            if (rtypeval == "R")
            {
                dt = chrgobj.GetLikeCashPaymentCharges(prefix);
            }
            else
            {
                dt = chrgobj.GetLikeCashPaymentCharges(prefix);
            }
            List_Result = Utility.Fn_TableToList(dt, "chargename", "chargeid");
            return List_Result;
        }

        protected void CheckData()
        {
            //if (rptype == "P")
            //{
            //    if (ddl_branch.Text == "")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Branch cannot be blank');", true);
            //        next = 0;
            //        return;
            //    }
            //    if (ddl_mode.Text == "MODE")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Mode');", true);
            //        next = 0;
            //        return;
            //    }
            //    if (str_mode == "B")
            //    {
            //        if (Chk_accountpay.Checked == false)
            //        {
            //            this.PopUpService.Show();
            //        }
            //    }
            //}
            if (Session["rptype"] == "P")
            {
                if (ddl_branch.SelectedIndex == -1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Branch cannot be blank');", true);

                    blner = true;
                    return;

                }

                ACPayee = Convert.ToChar("C");
            }

            if (ddl_mode.SelectedIndex == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Mode  cannot be blank');", true);

                blner = true;
                return;
            }

            if (txt_curr.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Currency  cannot be blank');", true);

                blner = true;
                txt_curr.Focus();
                return;
            }

            if (txt_rcvamt.Text == "")
            {
                if (Session["rptype"] == "P")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Received Amount cannot be blank');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Payment Amount cannot be blank');", true);
                }
                blner = true;
                txt_rcvamt.Focus();
                return;

            }

            if (str_mode == "B")
            {
                if (txt_cheque.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bank Ref # cannot be blank');", true);

                    blner = true;
                    txt_cheque.Focus();
                    return;
                }


                if (txt_bank.Text.Trim() != "")
                {
                    bankid = bankobj.GetBankid(txt_bank.Text.Trim());
                    if (bankid == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bank Name Not Available');", true);

                        blner = true;
                        txt_bank.Focus();
                        return;
                    }
                    else
                    {
                        Boolean ChqnoExistance = false;
                        ChqnoExistance = recobj.CheckOSChequeNo(txt_cheque.Text.ToUpper(), bankid, Convert.ToChar(Session["rptype"]));

                        if (ChqnoExistance == true)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bank Ref # already Exist');", true);

                            blner = true;
                            txt_cheque.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bank Name cannot be blank ');", true);

                    blner = true;
                }
                if (txt_branch1.Text.Trim() == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bank Branch cannot be blank');", true);

                    blner = true;
                    txt_cheque.Focus();
                    return;
                }
            }

            if (txt_recieve.Text != "")
            {
                intcustid = Convert.ToInt32(hid_cust.Value);
                if (intcustid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer Name Not Available');", true);

                    blner = true;
                    txt_recieve.Focus();
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer Name Canot Blank');", true);
                blner = true;
                txt_recieve.Focus();

            }


            if (txt_amtrs.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount cannot be blank');", true);
                blner = true;
                txt_amtrs.Focus();
            }

        }

        private void txt_disable(Boolean Check)
        {
            //txt_cheque.Enabled = Check;
            //txt_bank.Enabled = Check;
            //txt_branch1.Enabled = Check;
            //txt_cheqdate.Enabled = Check;
        }

        private void Btn_disable(Boolean Check)
        {
            //btn_cust_add.Enabled = Check;
            //btn_deduct_add.Enabled = Check;
            //btn_short_add.Enabled = Check;
        }

        protected void ddl_mode_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (ddl_mode.Text != "")
            {
                if (ddl_mode.Text == "Cash" || ddl_mode.Text == "Petty Cash")
                {
                    if (ddl_mode.Text == "Cash")
                    {
                        mode = 'C';
                        str_mode = mode.ToString();
                    }
                    else
                    {
                        mode = 'P';
                        str_mode = mode.ToString();
                    }
                    txt_cheqdate.Enabled = false;
                    btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    txt_cheque.Text = "";
                    txt_branch1.Text = "";
                    txt_bank.Text = "";
                    txt_cheque.Enabled = false;
                    txt_bank.Enabled = false;
                    txt_branch1.Enabled = false;
                    //lnk_cheque.Enabled = false;
                    Btn_disable(true);
                    txt_deduction.Enabled = true;
                    txt_dedu_amt.Enabled = true;

                }
                else
                {
                    if (ddl_mode.Text == "Cheque/DD") mode = 'B';
                    str_mode = mode.ToString();
                    txt_cheqdate.Enabled = true;
                    btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    txt_cheque.Enabled = true;
                    txt_bank.Enabled = true;
                    txt_branch1.Enabled = true;
                    Btn_disable(true);
                }

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
            if (ddl_mode.SelectedItem.Text == "MODE")
            {
                ScriptManager.RegisterClientScriptBlock(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Mode');", true);
                next = 0;
                return;
            }
            //mode=EmptyControlCollection;
            if (ddl_mode.SelectedItem.Text == "Cash")
            {
                mode = 'C';
                str_mode = mode.ToString();
            }
            else if (ddl_mode.SelectedItem.Text == "Petty Cash")
            {
                mode = 'P';
                str_mode = mode.ToString();
            }
            else if (ddl_mode.SelectedItem.Text == "Cheque/DD")
            {
                mode = 'B';
                str_mode = mode.ToString();
            }
        }

        private void GetDetails(DataTable dtnew)
        {
            double famt;
            double amt1;
            DataTable dtCuschrg = new DataTable();
            DataTable tempdt = new DataTable();
            DataTable dtCT = new DataTable();
            DataTable dtINV = new DataTable();
            DataTable dtex = new DataTable();

            if (dtnew.Rows.Count > 0)
            {
                txt_recp.Text = dtnew.Rows[0][1].ToString();
                txt_date.Text = Utility.fn_ConvertDate(dtnew.Rows[0][2].ToString());
                string Mode = dtnew.Rows[0][3].ToString();
                ddl_mode.Enabled = false;
                if (Mode == "C")
                {
                    ddl_mode.SelectedValue = "Cash";
                    CTDisable();
                }
                else if (Mode == "B")
                {
                    ddl_mode.SelectedValue = "Cheque/DD";
                    txt_cheque.Text = dtnew.Rows[0][10].ToString();
                    int bankid = Convert.ToInt32(dtnew.Rows[0]["bank"].ToString());
                    // hid_bank.Value = bankid.ToString();
                    txt_bank.Text = recobj.GetBankName(bankid);
                    txt_branch1.Text = dtnew.Rows[0][9].ToString();
                    txt_cheqdate.Text = Utility.fn_ConvertDate(dtnew.Rows[0]["chequedate"].ToString());
                    CTEnable();
                    if (rptype == "P")
                    {
                        if (dtnew.Rows[0][14].ToString() == "C")
                        {
                            Chk_accountpay.Checked = true;
                        }



                        if (System.DBNull.Value == dtnew.Rows[0]["refno"] == false && dtnew.Rows[0]["refno"].ToString() != "")
                        {
                            txt_refno.Visible = true;
                            txt_refno.Text = dtnew.Rows[0]["refno"].ToString();
                        }
                        else
                        {
                            txt_refno.Visible = false;
                        }

                        int ApprovBy;
                        if (dtnew.Rows[0]["approvedby"].ToString() != "")
                        {
                            ApprovBy = Convert.ToInt32(dtnew.Rows[0]["approvedby"].ToString());
                        }
                        else
                        {
                            ApprovBy = 0;
                        }
                    }
                }

                txt_recieve.Text = dtnew.Rows[0][6].ToString();

                if (rptype == "R")
                {
                    famt = Convert.ToDouble(dtnew.Rows[0]["receiptfamount"].ToString());
                    txt_rcvamt.Text = famt.ToString("#,0.00");
                    txt_curr.Text = dtnew.Rows[0]["curr"].ToString();
                    exr = Convert.ToDouble(dtnew.Rows[0]["exrate"].ToString());
                    txt_exrate.Text = exr.ToString("#,0.00");
                }
                else
                {
                    txt_curr.Text = dtnew.Rows[0][19].ToString();
                    famt = Convert.ToDouble(dtnew.Rows[0][18].ToString());
                    txt_rcvamt.Text = famt.ToString("#,0.00");
                    exr = Convert.ToDouble(dtnew.Rows[0][20].ToString());
                    txt_exrate.Text = exr.ToString("#,0.00");
                }

                txt_fvr.Text = dtnew.Rows[0]["customername"].ToString();

                if (txt_recieve.Text == "")
                {
                    txt_recieve.Text = txt_fvr.Text;
                }

                amt1 = Convert.ToDouble(dtnew.Rows[0][7].ToString());
                txt_amtrs.Text = amt1.ToString("#,0.00");
                txt_narration.Text = dtnew.Rows[0][12].ToString();

                if (rptype == "R")
                {
                    // dtCuschrg = recgenobj.GetOSRecptCust(rid);GetOSRecptCust
                    dtCuschrg = recgenobj.GetOSRecptCust(rid);
                }
                else if (rptype == "P")
                {
                    dtCuschrg = pymtobj.GetOSPaymentCust(rid);
                }
                DataRow dtrow = tempdt.NewRow();
                if (dtCuschrg.Rows.Count > 0)
                {
                    tempdt.Columns.Add("Type");
                    tempdt.Columns.Add("Customerortax");
                    tempdt.Columns.Add("fc");
                    tempdt.Columns.Add("amount");
                    tempdt.Columns.Add("cid");

                    for (int j = 0; j <= dtCuschrg.Rows.Count - 1; j++)
                    {
                        dtrow = tempdt.NewRow();
                        tempdt.Rows.Add(dtrow);
                        dtrow["Type"] = "Customer";
                        dtrow["Customerortax"] = dtCuschrg.Rows[j]["cc"].ToString();
                        dtrow["fc"] = dtCuschrg.Rows[j]["fcamt"].ToString();
                        dtrow["amount"] = dtCuschrg.Rows[j]["amount"].ToString();
                        dtrow["cid"] = dtCuschrg.Rows[j]["customer"].ToString();
                    }
                }

                int r = 0;
                int c = 0;
                if (rptype == "R")
                {
                    dtCT = recobj.GetOSRecptChrg(rid);
                }
                else if (rptype == "P")
                {
                    dtCT = pymtobj.GetOSPaymentChrg(rid);
                }

                if (dtCT.Rows.Count > 0)
                {
                    if (tempdt.Rows.Count == 0)
                    {
                        tempdt = new DataTable();
                        tempdt.Columns.Add("Type");
                        tempdt.Columns.Add("Customerortax");
                        tempdt.Columns.Add("fc");
                        tempdt.Columns.Add("amount");
                        tempdt.Columns.Add("cid");
                    }

                    dtrow = tempdt.NewRow();
                    for (int j = 0; j <= dtCT.Rows.Count - 1; j++)
                    {
                        dtrow = tempdt.NewRow();
                        tempdt.Rows.Add(dtrow);
                        dtrow["Type"] = "Charges";
                        dtrow["Customerortax"] = dtCT.Rows[j][0].ToString();
                        dtrow["fc"] = dtCT.Rows[j][2].ToString();
                        dtrow["amount"] = dtCT.Rows[j][1].ToString();
                        dtrow["cid"] = dtCT.Rows[j]["chargeid"].ToString();
                    }
                }

                if (rptype == "R")
                {
                    dtex = recobj.GetOSES(rid);
                }
                else if (rptype == "P")
                {
                    dtex = pymtobj.GetOSPaymentES(rid);
                }

                if (dtex.Rows.Count > 0)
                {
                    if (tempdt.Rows.Count == 0)
                    {
                        tempdt = new DataTable();
                        tempdt.Columns.Add("Type");
                        tempdt.Columns.Add("Customerortax");
                        tempdt.Columns.Add("fc");
                        tempdt.Columns.Add("amount");
                        tempdt.Columns.Add("cid");
                    }

                    dtrow = tempdt.NewRow();
                    for (int i = 0; i <= dtex.Rows.Count - 1; i++)
                    {
                        dtrow = tempdt.NewRow();
                        tempdt.Rows.Add(dtrow);
                        //int value =Convert.ToInt32 (tempdt.Rows[r][0]);
                        //double x = Convert.ToDouble(value.ToString());
                        if (Convert.ToDouble(dtex.Rows[r][0]) > 0)
                        {
                            dtrow["Type"] = "Ex.Rate Gain";
                        }
                        else
                        {
                            dtrow["Type"] = "Ex.Rate Loss";
                        }
                        dtrow["Customerortax"] = "";
                        dtrow["fc"] = "";
                        dtrow["amount"] = dtex.Rows[r][0].ToString();
                        dtrow["cid"] = "";
                        r = r + 1;
                    }
                }

                Grid_Account.DataSource = tempdt;
                Grid_Account.DataBind();
                ViewState["CurrentData"] = tempdt;
                if (Grid_Account.Rows.Count > 0)
                {
                    Total = 0;
                    for (int i = 0; i < Grid_Account.Rows.Count; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[2].Text != "&nbsp;" && Grid_Account.Rows[i].Cells[2].Text != "")
                        {
                            Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);

                        }

                    }
                    txt_total.Text = string.Format("{0:0.00}", Total);


                    Total = 0;
                    for (int i = 0; i < Grid_Account.Rows.Count; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[3].Text != "&nbsp;")
                        {
                            Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                        }
                    }
                    txt_total1.Text = string.Format("{0:0.00}", Total);
                }

                if (rptype == "R")
                {
                    lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                    lbl_amountinword.Visible = true;
                    txt_refno.Visible = false;
                    txt_fvr.Visible = false;
                }
                else
                {
                    lbl_amountinword.Visible = false;
                    txt_refno.Visible = false;
                    txt_fvr.Visible = true;
                }

                if (rid != 0)
                {
                    RPtype = Convert.ToChar(rptype);
                    dtINV = recgenobj.GetRAInvoiceToShow4OS(rid, RPtype);
                    if (dtINV.Rows.Count > 0)
                    {
                        Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
                        Grid_detail.DataBind();
                        tempdt = new DataTable();
                        tempdt.Columns.Add("branchid", typeof(string));
                        tempdt.Columns.Add("branch", typeof(string));
                        tempdt.Columns.Add("invoiceno", typeof(string));
                        tempdt.Columns.Add("curr", typeof(string));
                        tempdt.Columns.Add("fcamt", typeof(string));
                        tempdt.Columns.Add("exrate", typeof(string));
                        tempdt.Columns.Add("vamount", typeof(string));
                        tempdt.Columns.Add("tamount", typeof(string));

                        tempdt.Columns.Add("recptfcamt", typeof(string));
                        tempdt.Columns.Add("voutype", typeof(string));
                        tempdt.Columns.Add("vouno", typeof(string));
                        tempdt.Columns.Add("tds", typeof(string));
                        tempdt.Columns.Add("ravouyear", typeof(string));
                        tempdt.Columns.Add("ltype", typeof(string));
                        tempdt.Columns.Add("customerid", typeof(string));

                        tempdt.Columns.Add("vendorrefno", typeof(string));
                        tempdt.Columns.Add("vendorrefdate", typeof(string));

                        for (int i = 0; i <= dtINV.Rows.Count - 1; i++)
                        {
                            dtrow = tempdt.NewRow();
                            dtrow["branchid"] = dtINV.Rows[i][0].ToString();
                            dtrow["branch"] = dtINV.Rows[i][1].ToString();
                            if (dtINV.Rows[i][2].ToString() != "0")
                            {
                                if (dtINV.Rows[i][8].ToString() == "I") // Vino [05-03-2024]
                                {
                                    dtrow["invoiceno"] = "SI - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "D")
                                {
                                    dtrow["invoiceno"] = "OSDN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "V")
                                {
                                    dtrow["invoiceno"] = "DN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "X")
                                {
                                    dtrow["invoiceno"] = "ADN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "P") // Vino [05-03-2024]
                                {
                                    dtrow["invoiceno"] = "PI - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "C")
                                {
                                    dtrow["invoiceno"] = "OSCN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "E")
                                {
                                    dtrow["invoiceno"] = "CN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "S")
                                {
                                    dtrow["invoiceno"] = "ACN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "U")
                                {
                                    dtrow["invoiceno"] = "AdjDCN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "T")
                                {
                                    dtrow["invoiceno"] = "AdjDCN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OI")
                                {
                                    dtrow["invoiceno"] = "OB SI - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OD")
                                {
                                    dtrow["invoiceno"] = "OB OSSI - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OV")
                                {
                                    dtrow["invoiceno"] = "OB DN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OX")
                                {
                                    dtrow["invoiceno"] = "OB ADN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OP")
                                {
                                    dtrow["invoiceno"] = "OB PI - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OC")
                                {
                                    dtrow["invoiceno"] = "OB OSPI - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OE")
                                {
                                    dtrow["invoiceno"] = "OB CN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OS")
                                {
                                    dtrow["invoiceno"] = "OB ACN - " + dtINV.Rows[i][2].ToString();
                                }

                                else if (dtINV.Rows[i][8].ToString() == "F") // Vino [05-03-2024]
                                {
                                    dtrow["invoiceno"] = "SI OC - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "G")
                                {
                                    dtrow["invoiceno"] = "PI OC - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "H")
                                {
                                    dtrow["invoiceno"] = "BS OC - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OF")
                                {
                                    dtrow["invoiceno"] = "OB SI OC - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OG")
                                {
                                    dtrow["invoiceno"] = "OB PI OC - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OH")
                                {
                                    dtrow["invoiceno"] = "OB BS OC - " + dtINV.Rows[i][2].ToString();
                                }
                            }
                            else
                            {
                                dtrow["invoiceno"] = "On Account";
                            }

                            dtrow["curr"] = dtINV.Rows[i][3].ToString();
                            dtrow["fcamt"] = dtINV.Rows[i]["receiptfamount"].ToString();
                            exrate = dtINV.Rows[i]["receiptexrate"].ToString();
                            dtrow["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");

                            dtrow["vamount"] = dtINV.Rows[i]["vamount"].ToString();
                            dtrow["tamount"] = dtINV.Rows[i]["tamount"].ToString();
                            dtrow["recptfcamt"] = dtINV.Rows[i]["recptfcamt"].ToString();

                            dtrow["voutype"] = dtINV.Rows[i]["voutype"].ToString();
                            dtrow["vouno"] = dtINV.Rows[i]["vouno"].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtINV.Rows[i]["ravouyear"].ToString();
                            dtrow["ltype"] = "";
                            dtrow["customerid"] = "";
                            dtrow["vendorrefno"] = dtINV.Rows[i]["vendorrefno"].ToString();
                            dtrow["vendorrefdate"] = dtINV.Rows[i]["vendorrefdate"].ToString();
                            tempdt.Rows.Add(dtrow);
                        }

                        Grid_detail.DataSource = tempdt;
                        Grid_detail.DataBind();
                        ViewState["dtINV"] = tempdt;
                    }
                }
                else if (rptype == "R")
                {
                    ScriptManager.RegisterStartupScript(ddl_mode, typeof(DropDownList), "Receipts", "alertify.alert('Invalid Receipt #');", true);

                }
                else if (rptype == "P")
                {
                    ScriptManager.RegisterStartupScript(ddl_mode, typeof(DropDownList), "Payments", "alertify.alert('Invalid Payment #');", true);

                }
            }
        }

        private void ddl_mode_change()
        {
            int n = 0;
            DataTable DtTemp = new DataTable();
            DataTable dttemp = new DataTable();
            DataTable dtINV = new DataTable();
            DataTable dtCuschrg = new DataTable();
            int bid;
            int did;
            int Vouyear;
            try
            {
                if (txt_recp.Text != "")
                {
                    bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                    did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                    Vouyear = Convert.ToInt32(txt_recpdate.Text);

                    rptype = ViewState["rptype"].ToString();
                    mode_set();
                    recno = Convert.ToInt32(txt_recp.Text);
                    //rptype = "R";
                    if (rptype == "R")
                    {
                        branchid = Convert.ToInt32(Session["LoginBranchid"]);
                        rid = recobj.GetOSRecrid(recno, branchid, mode, Vouyear);
                        hid_recpayid.Value = rid.ToString();
                        DtTemp = recobj.GetOSRecptHead(recno, bid, mode, Vouyear);
                    }
                    else
                    {
                        //branchid = hrempobj.GetBranchId(did, ddl_branch.SelectedItem.Text);
                        branchid = Convert.ToInt32(Session["LoginBranchid"]);
                        rid = pymtobj.GetOSPaymentid(recno, branchid, mode, Vouyear);
                        hid_recpayid.Value = rid.ToString();
                        DtTemp = pymtobj.GetOSPaymentHead(recno, branchid, mode, Vouyear);
                    }

                    GetDetails(DtTemp);

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    if (txt_recp.Text != "")
                    {
                        btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                        btn_save1.Visible = false;
                        btn_save.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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


        protected void txt_cheque_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_cheque = new DataTable();
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                //branchid = hrempobj.GetBranchId(did, ddl_branch.SelectedItem.Text);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                dt_cheque = objnoc.SelNotOverCheque4ChequeNo(txt_cheque.Text, did);

                if (dt_cheque.Rows.Count > 0)
                {

                    txt_bank.Text = dt_cheque.Rows[0]["BankName"].ToString();
                    txt_cheque.Text = dt_cheque.Rows[0]["chequeno"].ToString();
                    txt_cheqdate.Text = dt_cheque.Rows[0]["TT Ref Date"].ToString();
                    txt_branch1.Text = dt_cheque.Rows[0]["bbranch"].ToString();
                    txt_recieve.Text = dt_cheque.Rows[0]["Customername"].ToString();
                    hid_customerid.Value = dt_cheque.Rows[0]["customerid"].ToString();
                    txt_amtrs.Text = string.Format("{0:0.00}", dt_cheque.Rows[0]["amount"]);
                    hid_favour.Value = dt_cheque.Rows[0]["fvrname"].ToString();
                    hid_cheque.Value = dt_cheque.Rows[0]["nono"].ToString();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_cust_TextChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            if (hid_favour.Value == "0" && hid_favour.Value == "")
            {
                ScriptManager.RegisterClientScriptBlock(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Correct Ledger Name');", true);
                return;
            }

            // ViewState["dtINV"] = null;////03-08-2022

            if (ViewState["dtINV"] != null)
            {
                Dt = (DataTable)ViewState["dtINV"];

                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    DataRow dr = Dt.Rows[i];

                    string midify = dr["voutype"].ToString();
                    if (midify == "O")
                    {
                        dr.Delete();
                    }

                }
                Dt.AcceptChanges();
                ViewState["dtINV"] = Dt;
            }



            //for (int i = 0; i <= Grid_detail.Rows.Count - 1;i++ )
            //{
            //    if (Grid_detail.Rows[i].Cells[9].ToString()=="O")
            //    {
            //        Grid_detail.Rows[e]
            //       // Grid_detail_RowDeleting(sender, e);
            //    }
            //}

            int intcustid;
            if (txt_cust.Text == "")
            {
                txt_cust.Text = txt_recieve.Text;
            }

            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            string FADbname = Session["FADbname"].ToString();
            //     If intcustid = 0 Then
            //    intcustid = cusobj.Getcustidfromledger(ledgerid)
            //    rfCustid = intcustid
            //End If
            DataTable dtTemp = new DataTable();
            dtTemp = Ldrobj.GetLikeLedgernameLedger(txt_cust.Text, did, bid, FADbname);
            if (dtTemp.Rows.Count > 0)
            {
                ledgerid = Convert.ToInt32(dtTemp.Rows[0][1].ToString());
                hid_ledger.Value = ledgerid.ToString();
                ledgername = dtTemp.Rows[0][0].ToString();
                rfCustid = Convert.ToInt32(dtTemp.Rows[0]["opsid"].ToString());
                hid_cust.Value = Convert.ToString(rfCustid);


            }




            if (hid_cust.Value == "0" || hid_cust.Value == "")
            {
                custid = cusobj.Getcustidfromledger(ledgerid);
                rfCustid = custid;
            }


            try
            {
                DataTable dtINV = new DataTable();
                DataTable dtj = new DataTable();
                DataTable dt = new DataTable();
                int Custid = Convert.ToInt32(hid_cust.Value);
                int a = 0;
                bool custexist = false;
                rptype = ViewState["rptype"].ToString();
                did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                if (txt_cust.Text != "")
                {
                    rowCount = Grid_Account.Rows.Count;
                    if (hid_favour.Value != "")
                    {
                        if (Custid == 0)
                        {
                            Custid = cusobj.Getcustidfromledger(Convert.ToInt32(hid_favour.Value));
                        }
                    }

                    if (Grid_Account.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtj.Rows.Count; i++)
                        {
                            if (Custid == Convert.ToInt32(Grid_Account.Rows[i].Cells[4].Text))
                            {
                                custexist = true;
                                break;
                            }
                        }
                    }

                    if (rptype == "P")
                    {
                        DataTable dtindiacust = new DataTable();
                        dtindiacust = customerobj.SelledgeridinHead4RPLedger(Convert.ToInt32(hid_favour.Value), did, Session["FADbname"].ToString());

                        if (dtindiacust.Rows.Count > 0)
                        {
                            bolCust = true;
                            txt_refno.Visible = true;
                        }
                    }

                    DataTable dttemp3 = new DataTable();
                    DataRow dtrow;


                    if (custexist == false)
                    {

                        sumiamount = 0;
                        //  dtINV = recobj.GetOSInvRecptDtls(Convert.ToInt32(hid_favour.Value), did);
                        dtINV = recobj.GetOSlvRecptDtlsLedger(ledgerid, did);
                        a = 0;
                        if (ViewState["dtINV"] != null)
                        {
                            dttemp3 = (DataTable)ViewState["dtINV"];
                            a = dttemp3.Rows.Count;
                        }

                        //if (dttemp3.Rows.Count == 0 && dtINV.Rows.Count == 0)
                        //{
                        //    dttemp3.Columns.Clear();
                        //    dttemp3.Columns.Add("branchid", typeof(string));
                        //    dttemp3.Columns.Add("branch", typeof(string));
                        //    dttemp3.Columns.Add("invoiceno", typeof(string));
                        //    dttemp3.Columns.Add("curr", typeof(string));
                        //    dttemp3.Columns.Add("fcamt", typeof(string));
                        //    dttemp3.Columns.Add("exrate", typeof(string));
                        //    dttemp3.Columns.Add("vamount", typeof(string));
                        //    dttemp3.Columns.Add("tamount", typeof(string));

                        //    dttemp3.Columns.Add("recptfcamt", typeof(string));
                        //    dttemp3.Columns.Add("voutype", typeof(string));
                        //    dttemp3.Columns.Add("vouno", typeof(string));
                        //    dttemp3.Columns.Add("tds", typeof(string));
                        //    dttemp3.Columns.Add("ravouyear", typeof(string));
                        //    dttemp3.Columns.Add("ltype", typeof(string));
                        //    // dttemp3.Columns.Add("customerid", typeof(string));


                        //}

                        if (dttemp3.Rows.Count == 0 && dtINV.Rows.Count > 0)
                        {
                            dttemp3.Columns.Clear();
                            dttemp3.Columns.Add("branchid", typeof(string));
                            dttemp3.Columns.Add("branch", typeof(string));
                            dttemp3.Columns.Add("invoiceno", typeof(string));
                            dttemp3.Columns.Add("curr", typeof(string));
                            dttemp3.Columns.Add("fcamt", typeof(string));
                            dttemp3.Columns.Add("exrate", typeof(string));
                            dttemp3.Columns.Add("vamount", typeof(string));
                            dttemp3.Columns.Add("tamount", typeof(string));

                            dttemp3.Columns.Add("recptfcamt", typeof(string));
                            dttemp3.Columns.Add("voutype", typeof(string));
                            dttemp3.Columns.Add("vouno", typeof(string));
                            dttemp3.Columns.Add("tds", typeof(string));
                            dttemp3.Columns.Add("ravouyear", typeof(string));
                            dttemp3.Columns.Add("ltype", typeof(string));
                            dttemp3.Columns.Add("customerid", typeof(string));
                            dttemp3.Columns.Add("vendorrefno", typeof(string));
                            dttemp3.Columns.Add("vendorrefdate", typeof(string));
                        }

                        for (int i = 0; i <= dtINV.Rows.Count - 1; i++)
                        {
                            dtrow = dttemp3.NewRow();
                            dtrow["branchid"] = dtINV.Rows[i][0].ToString();
                            dtrow["branch"] = dtINV.Rows[i][1].ToString();
                            if (dtINV.Rows[i][2].ToString() != "0")
                            {
                                if (dtINV.Rows[i][8].ToString() == "I")
                                {
                                    dtrow["invoiceno"] = "SI - " + dtINV.Rows[i][2].ToString(); // Vino [05-03-2024]
                                }
                                else if (dtINV.Rows[i][8].ToString() == "D")
                                {
                                    dtrow["invoiceno"] = "OSSI - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "V")
                                {
                                    dtrow["invoiceno"] = "DN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "X")
                                {
                                    dtrow["invoiceno"] = "ADN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "P")
                                {
                                    dtrow["invoiceno"] = "PI - " + dtINV.Rows[i][2].ToString(); // Vino [05-03-2024]
                                }
                                else if (dtINV.Rows[i][8].ToString() == "C")
                                {
                                    dtrow["invoiceno"] = "OSPI - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "E")
                                {
                                    dtrow["invoiceno"] = "CN - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "S")
                                {
                                    dtrow["invoiceno"] = "ACN - " + dtINV.Rows[i][2].ToString();
                                }

                                else if (dtINV.Rows[i][8].ToString() == "F")  // Vino [05-03-2024]
                                {
                                    dtrow["invoiceno"] = "SI OC - " + dtINV.Rows[i][2].ToString(); 
                                }
                                else if (dtINV.Rows[i][8].ToString() == "G")
                                {
                                    dtrow["invoiceno"] = "PI OC - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "H")
                                {
                                    dtrow["invoiceno"] = "BS OC - " + dtINV.Rows[i][2].ToString();
                                }
                                else if(dtINV.Rows[i][8].ToString() == "OF")
                                {
                                    dtrow["invoiceno"] = "OB SI OC - " + dtINV.Rows[i][2].ToString(); 
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OG")
                                {
                                    dtrow["invoiceno"] = "OB PI OC - " + dtINV.Rows[i][2].ToString();
                                }
                                else if (dtINV.Rows[i][8].ToString() == "OH")
                                {
                                    dtrow["invoiceno"] = "OB BS OC - " + dtINV.Rows[i][2].ToString();
                                }

                            }
                            //else
                            //{
                            //    dtrow["invoiceno"] = "On Account";
                            //}

                            dtrow["curr"] = dtINV.Rows[i][3].ToString();
                            fcAmount = dtINV.Rows[i]["receiptfamount"].ToString();
                            dtrow["fcamt"] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                            exrate = dtINV.Rows[i]["receiptexrate"].ToString();
                            dtrow["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");

                            dtrow["vamount"] = dtINV.Rows[i]["vamount"].ToString();
                            dtrow["tamount"] = dtINV.Rows[i]["tamount"].ToString();
                            dtrow["recptfcamt"] = dtINV.Rows[i]["famount"].ToString();

                            dtrow["voutype"] = dtINV.Rows[i]["voutype"].ToString();
                            dtrow["vouno"] = dtINV.Rows[i]["vouno"].ToString();
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtINV.Rows[i]["ravouyear"].ToString();
                            dtrow["ltype"] = "";
                            dtrow["customerid"] = Convert.ToInt32(hid_cust.Value); //dtINV.Rows[i]["customerid"].ToString();
                            if (dtINV.Rows[i]["vendorrefno"] != DBNull.Value)
                            {
                                dtrow["vendorrefno"] = dtINV.Rows[i]["vendorrefno"].ToString();
                            }
                            else
                            {
                                dtrow["vendorrefno"] = "";
                            }
                            if (dtINV.Rows[i]["vendorrefdate"] != DBNull.Value)
                            {
                                dtrow["vendorrefdate"] = dtINV.Rows[i]["vendorrefdate"].ToString();
                            }
                            else
                            {
                                dtrow["vendorrefdate"] = "";
                            }
                            dttemp3.Rows.Add(dtrow);
                        }

                        Grid_detail.DataSource = dttemp3;
                        Grid_detail.DataBind();
                        ViewState["dtINV"] = dttemp3;////03-08-2022
                    }



                    ReAdjDN();
                    ReAdjCN();

                    //for OB Breakup
                    OBBreakUp();
                    OBBreakUp4rectpmt();



                    if (rptype == "R")
                    {
                        all();
                        //Invoices();
                       // DN();
                        //   AdminDN();
                       // OSDN();
                        // PA();
                       // CN();
                        // AdminCN();
                        //OSCN();

                        //DNAdmin();
                        //AdjDN();
                        //AdjCN();

                        Journal(); // For OS Journal Vino

                        //CNAdmin();  //From OB Breakup
                        //OBBreakUp();
                    }
                    else if (rptype == "P")
                    {
                        all();
                        // PA();
                        //CN();
                        // AdminCN();
                      //  OSCN();
                        //Invoices();
                       // DN();
                        // AdminDN();
                        ///OSDN();
                        ///AdjDN();
                        ///AdjCN();


                        Journal(); // For OS Journal Vino


                        ///DNAdmin();
                        ///CNAdmin();  //From OB Breakup
                        
                    }

                    int c;
                    if (ViewState["dtINV"] != null)
                    {
                        dttemp3 = ViewState["dtINV"] as DataTable;
                        c = dttemp3.Rows.Count;
                        Session["value"] = dttemp3;

                        if (c == 0)
                        {
                            dttemp3.Columns.Add("branchid", typeof(string));
                            dttemp3.Columns.Add("branch", typeof(string));
                            dttemp3.Columns.Add("invoiceno", typeof(string));
                            dttemp3.Columns.Add("curr", typeof(string));
                            dttemp3.Columns.Add("fcamt", typeof(string));

                            dttemp3.Columns.Add("exrate", typeof(string));
                            dttemp3.Columns.Add("vamount", typeof(string));
                            dttemp3.Columns.Add("tamount", typeof(string));
                            dttemp3.Columns.Add("recptfcamt", typeof(string));
                            dttemp3.Columns.Add("voutype", typeof(string));

                            dttemp3.Columns.Add("vouno", typeof(string));
                            dttemp3.Columns.Add("tds", typeof(string));
                            dttemp3.Columns.Add("ravouyear", typeof(string));
                            dttemp3.Columns.Add("ltype", typeof(string));
                            dttemp3.Columns.Add("customerid", typeof(string));

                            dttemp3.Columns.Add("vendorrefno", typeof(string));
                            dttemp3.Columns.Add("vendorrefdate", typeof(string));
                        }

                        if (rptype == "R" || rptype == "P")
                        {
                            dtrow = dttemp3.NewRow();

                            dtrow["branchid"] = Convert.ToInt32(Session["LoginBranchid"].ToString());
                            dtrow["branch"] = Session["LoginBranchName"].ToString();
                            dtrow["invoiceno"] = "On Account";
                            dtrow["recptfcamt"] = "0.00";
                            dtrow["voutype"] = "O";
                            dtrow["curr"] = txt_curr.Text;
                            dtrow["exrate"] = txt_exrate.Text;
                            dtrow["ravouyear"] = txt_recpdate.Text;
                            dtrow["tamount"] = "0.00";
                            dtrow["customerid"] = Convert.ToInt32(hid_cust.Value);
                            dtrow["vendorrefno"] = "";
                            dtrow["vendorrefdate"] = "";
                            dttemp3.Rows.Add(dtrow);
                        }
                        Grid_detail.DataSource = dttemp3;
                        Grid_detail.DataBind();


                    }
                    ViewState["dtexcel"] = dttemp3; //// 20-07-2022 hari
                    //if (rptype == "R")
                    //{
                    //    dtrow = dttemp3.NewRow();

                    //        dtrow["invoiceno"] = "On Account";
                    //        dtrow["recptfcamt"] = "0.00";
                    //        dtrow["voutype"] = "O";
                    //        dtrow["curr"] = "";
                    //        dttemp3.Rows.Add(dtrow);
                    //        Grid_detail.DataSource = dttemp3;
                    //  Grid_detail.DataBind();
                    //}

                    if (Grid_detail.Rows.Count > 0) ////03-08-2022 hari
                    {
                        foreach (GridViewRow row1 in Grid_detail.Rows)
                        {
                            CheckBox chk = ((CheckBox)Grid_detail.Rows[row1.RowIndex].FindControl("Chkrecpfc"));
                            TextBox txt = ((TextBox)Grid_detail.Rows[row1.RowIndex].FindControl("txt_receiptamount"));

                            if (chk.Checked == false && txt.Text != "0.00")
                            {
                                if (txt.Text != "0.000")           //NewOne //24/05/2022
                                {
                                    //Grid_detail.Rows[row1.RowIndex].Cells[18].Enabled = false;
                                    chk.Checked = true;
                                }

                            }
                            else if (chk.Checked == false)
                            {
                                //Grid_detail.Rows[row1.RowIndex].Cells[18].Enabled = true;
                                chk.Checked = false;
                            }
                        }
                    }

                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
            txt_cust_amt.Focus();
        }

        protected void DNAdmin()
        {
            DataTable dtINV11 = new DataTable();
            dtINV11 = recobj.GetDNAdmin4OSLedger(ledgerid, divisionid);
            GetYear();
            DataRow dtrow;
            DataTable dttemp1 = new DataTable();

            //      Dim b As Integer
            //Dim r As Integer = 0
            //b = grdINVRec.Rows.Count
            int b, r = 0;
            if (ViewState["dtINV"] != null)
            {
                dttemp1 = ViewState["dtINV"] as DataTable;
                r = dttemp1.Rows.Count;
            }
            //b = Grid_detail.Rows.Count;


            //dttemp1.Columns.Add("ledtype");
            if (dttemp1.Rows.Count == 0 && dtINV11.Rows.Count > 0)
            {
                dttemp1.Columns.Add("branchid");
                dttemp1.Columns.Add("branch");
                dttemp1.Columns.Add("invoiceno");
                dttemp1.Columns.Add("curr");
                dttemp1.Columns.Add("fcamt");

                dttemp1.Columns.Add("exrate");
                dttemp1.Columns.Add("vamount");
                dttemp1.Columns.Add("recptfcamt");
                dttemp1.Columns.Add("tamount");
                dttemp1.Columns.Add("voutype");

                dttemp1.Columns.Add("vouno");
                dttemp1.Columns.Add("tds");
                dttemp1.Columns.Add("ravouyear");
                dttemp1.Columns.Add("vendorrefno", typeof(string));
                dttemp1.Columns.Add("vendorrefdate", typeof(string));
                dttemp1.Columns.Add("ltype");
                dttemp1.Columns.Add("customerid");
            }
            for (int i = 0; i <= dtINV11.Rows.Count - 1; i++)
            {
                dtrow = dttemp1.NewRow();
                dttemp1.Rows.Add();
                dttemp1.Rows[r][0] = dtINV11.Rows[i][0].ToString();
                dttemp1.Rows[r][1] = dtINV11.Rows[i][1].ToString();
                dttemp1.Rows[r][2] = "ADN - " + dtINV11.Rows[i][2].ToString();
                dttemp1.Rows[r][3] = dtINV11.Rows[i][3].ToString();
                dttemp1.Rows[r][4] = dtINV11.Rows[i]["fcamt"].ToString();
                exrate = dtINV11.Rows[i][4].ToString();
                dttemp1.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dttemp1.Rows[r][6] = dtINV11.Rows[i][6].ToString();
                dttemp1.Rows[r][7] = dtINV11.Rows[i][10].ToString();
                dttemp1.Rows[r][8] = dtINV11.Rows[i][7].ToString();
                dttemp1.Rows[r][9] = dtINV11.Rows[i][8].ToString();
                dttemp1.Rows[r][10] = dtINV11.Rows[i][2].ToString();
                dttemp1.Rows[r][12] = dtINV11.Rows[i][9].ToString();
                dttemp1.Rows[r]["vendorrefno"] = "";
                dttemp1.Rows[r]["vendorrefdate"] = "";
                dttemp1.Rows[r][15] = "";
                dttemp1.Rows[r][16] = Convert.ToInt32(hid_cust.Value);
                r = r + 1;
            }
            Grid_detail.DataSource = dttemp1;
            Grid_detail.DataBind();
            ViewState["dtINV"] = dttemp1;
        }

        private void CNAdmin()
        {
            DataTable dtINV11 = new DataTable();
            dtINV11 = pymtobj.GetCNAdmin4OSLedger(ledgerid, divisionid);
            GetYear();
            DataTable dttemp1 = new DataTable();
            DataRow dtrow;
            //      Dim b As Integer
            //Dim r As Integer = 0
            //b = grdINVRec.Rows.Count
            int b, r = 0;
            // b = Grid_detail.Rows.Count;
            if (ViewState["dtINV"] != null)
            {
                dttemp1 = ViewState["dtINV"] as DataTable;
                r = dttemp1.Rows.Count;
            }

            //dttemp1.Columns.Add("ledtype");
            if (dttemp1.Rows.Count == 0 && dtINV11.Rows.Count > 0)
            {
                dttemp1.Columns.Add("branchid");
                dttemp1.Columns.Add("branch");
                dttemp1.Columns.Add("invoiceno");
                dttemp1.Columns.Add("curr");
                dttemp1.Columns.Add("fcamt");

                dttemp1.Columns.Add("exrate");
                dttemp1.Columns.Add("vamount");
                dttemp1.Columns.Add("recptfcamt");
                dttemp1.Columns.Add("tamount");
                dttemp1.Columns.Add("voutype");

                dttemp1.Columns.Add("vouno");
                dttemp1.Columns.Add("tds");
                dttemp1.Columns.Add("ravouyear");
                dttemp1.Columns.Add("vendorrefno", typeof(string));
                dttemp1.Columns.Add("vendorrefdate", typeof(string));
                dttemp1.Columns.Add("ltype");
                dttemp1.Columns.Add("customerid");
            }
            for (int i = 0; i <= dtINV11.Rows.Count - 1; i++)
            {
                dtrow = dttemp1.NewRow();
                dttemp1.Rows.Add();
                dttemp1.Rows[r][0] = dtINV11.Rows[i][0].ToString();
                dttemp1.Rows[r][1] = dtINV11.Rows[i][1].ToString();
                dttemp1.Rows[r][2] = "ACN - " + dtINV11.Rows[i][2].ToString();
                dttemp1.Rows[r][3] = dtINV11.Rows[i][3].ToString();
                dttemp1.Rows[r][4] = dtINV11.Rows[i]["fcamt"].ToString();
                exrate = dtINV11.Rows[i][4].ToString();
                dttemp1.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dttemp1.Rows[r][6] = dtINV11.Rows[i][6].ToString();
                dttemp1.Rows[r][7] = dtINV11.Rows[i][10].ToString();
                dttemp1.Rows[r][8] = dtINV11.Rows[i][7].ToString();
                dttemp1.Rows[r][9] = dtINV11.Rows[i][8].ToString();
                dttemp1.Rows[r][10] = dtINV11.Rows[i][2].ToString();
                dttemp1.Rows[r][12] = dtINV11.Rows[i][9].ToString();
                dttemp1.Rows[r]["vendorrefno"] = dtINV11.Rows[i]["vendorrefno"].ToString();
                dttemp1.Rows[r]["vendorrefdate"] = dtINV11.Rows[i]["vendorrefdate"].ToString();
                dttemp1.Rows[r][15] = "";
                dttemp1.Rows[r][14] = Convert.ToInt32(hid_cust.Value);
                r = r + 1;
            }

            Grid_detail.DataSource = dttemp1;
            Grid_detail.DataBind();
            ViewState["dtINV"] = dttemp1;
        }

        private void AdjDN()
        {
            DataTable dtINV3 = new DataTable();
            DataTable dttemp1 = new DataTable();
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            GetYear();
            int Custid;
            DataTable dttempOSDn = new DataTable();
            DataRow dtrow;
            int b = 0;
            int r = 0;
            if (hid_custid.Value != "")
            {
                Custid = Convert.ToInt32(hid_custid.Value);
                dtINV3 = recobj.GetAdjDCNRecptDtlsLedger(ledgerid, did, "U", Session["FADbname"].ToString());
                if (ViewState["dtINV"] != null)
                {
                    dttemp1 = ViewState["dtINV"] as DataTable;
                    r = dttemp1.Rows.Count;
                }

                if (dttemp1.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                {

                    dttemp1.Columns.Add("branchid", typeof(string));
                    dttemp1.Columns.Add("branch", typeof(string));
                    dttemp1.Columns.Add("invoiceno", typeof(string));
                    dttemp1.Columns.Add("curr", typeof(string));
                    dttemp1.Columns.Add("fcamt", typeof(string));
                    dttemp1.Columns.Add("exrate", typeof(string));
                    dttemp1.Columns.Add("vamount", typeof(string));
                    dttemp1.Columns.Add("tamount", typeof(string));

                    dttemp1.Columns.Add("recptfcamt", typeof(string));
                    dttemp1.Columns.Add("voutype", typeof(string));
                    dttemp1.Columns.Add("vouno", typeof(string));
                    dttemp1.Columns.Add("tds", typeof(string));
                    dttemp1.Columns.Add("ravouyear", typeof(string));
                    dttemp1.Columns.Add("ltype", typeof(string));
                }

                for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                {
                    dtrow = dttemp1.NewRow();
                    dttemp1.Rows.Add();
                    dttemp1.Rows[r]["branch"] = dtINV3.Rows[i]["branchid"].ToString();
                    dttemp1.Rows[r]["port"] = dtINV3.Rows[i]["shortname"].ToString();
                    dttemp1.Rows[r]["invoiceno"] = "AdjDCN - " + dtINV3.Rows[i]["vouno"].ToString();
                    dttemp1.Rows[r]["curr"] = dtINV3.Rows[i]["fcur"].ToString();
                    fcAmount = dtINV3.Rows[i]["famt"].ToString();
                    dttemp1.Rows[r]["fcamt"] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                    exrate = dtINV3.Rows[i][5].ToString();
                    dttemp1.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                    dttemp1.Rows[r]["vamount"] = dtINV3.Rows[i]["iamount"].ToString();
                    dttemp1.Rows[r]["recptfcamt"] = dtINV3.Rows[i]["famount"].ToString();
                    dttemp1.Rows[r]["tamount"] = dtINV3.Rows[i]["ramount"].ToString();
                    dttemp1.Rows[r]["voutype"] = dtINV3.Rows[i]["voutype"].ToString();
                    dttemp1.Rows[r]["vouno"] = dtINV3.Rows[i]["vouno"].ToString();
                    dttemp1.Rows[r]["ravouyear"] = dtINV3.Rows[i]["vouyear"].ToString();

                    if (dttemp1.Rows[r]["voutype"] == "U")
                    {
                        dttemp1.Rows[r]["ltype"] = dttemp1.Rows[i]["ledgertype"];
                    }
                    r = r + 1;
                }

                Grid_detail.DataSource = dttemp1;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttemp1;
            }

        }

        private void AdjCN()
        {
            DataTable dtINV3 = new DataTable();
            DataTable dttemp1 = new DataTable();
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            GetYear();

            int Custid;
            DataTable dttempOSDn = new DataTable();
            DataRow dtrow;
            int b = 0;
            int r = 0;
            if (hid_custid.Value != "")
            {
                Custid = Convert.ToInt32(hid_custid.Value);
                dtINV3 = recobj.GetAdjDCNRecptDtlsLedger(ledgerid, did, "T", Session["FADbname"].ToString());
                if (ViewState["dtINV"] != null)
                {
                    dttemp1 = ViewState["dtINV"] as DataTable;
                    r = dttemp1.Rows.Count;
                }

                if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                {

                    dttemp1.Columns.Add("branchid", typeof(string));
                    dttemp1.Columns.Add("branch", typeof(string));
                    dttemp1.Columns.Add("invoiceno", typeof(string));
                    dttemp1.Columns.Add("curr", typeof(string));
                    dttemp1.Columns.Add("fcamt", typeof(string));
                    dttemp1.Columns.Add("exrate", typeof(string));
                    dttemp1.Columns.Add("vamount", typeof(string));
                    dttemp1.Columns.Add("tamount", typeof(string));

                    dttemp1.Columns.Add("recptfcamt", typeof(string));
                    dttemp1.Columns.Add("voutype", typeof(string));
                    dttemp1.Columns.Add("vouno", typeof(string));
                    dttemp1.Columns.Add("tds", typeof(string));
                    dttemp1.Columns.Add("ravouyear", typeof(string));
                    dttemp1.Columns.Add("ltype", typeof(string));
                }

                for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                {
                    dtrow = dttemp1.NewRow();
                    dttemp1.Rows.Add();
                    dttemp1.Rows[r]["branch"] = dtINV3.Rows[i]["branchid"].ToString();
                    dttemp1.Rows[r]["port"] = dtINV3.Rows[i]["shortname"].ToString();
                    dttemp1.Rows[r]["invoiceno"] = "AdjDCN - " + dtINV3.Rows[i]["vouno"].ToString();
                    dttemp1.Rows[r]["curr"] = dtINV3.Rows[i]["fcur"].ToString();
                    fcAmount = dtINV3.Rows[i]["famt"].ToString();
                    dttemp1.Rows[r]["fcamt"] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                    exrate = dtINV3.Rows[i][5].ToString();
                    dttemp1.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                    dttemp1.Rows[r]["vamount"] = dtINV3.Rows[i]["iamount"].ToString();
                    dttemp1.Rows[r]["recptfcamt"] = dtINV3.Rows[i]["famount"].ToString();
                    dttemp1.Rows[r]["tamount"] = dtINV3.Rows[i]["ramount"].ToString();
                    dttemp1.Rows[r]["voutype"] = dtINV3.Rows[i]["voutype"].ToString();
                    dttemp1.Rows[r]["vouno"] = dtINV3.Rows[i]["vouno"].ToString();
                    dttemp1.Rows[r]["ravouyear"] = dtINV3.Rows[i]["vouyear"].ToString();

                    if (dttemp1.Rows[r]["voutype"] == "T")
                    {
                        dttemp1.Rows[r]["ltype"] = dttemp1.Rows[i]["ledgertype"];
                    }
                    r = r + 1;
                }

                Grid_detail.DataSource = dttempOSDn;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttempOSDn;
            }

        }

        private void ReAdjDN()
        {
            DataTable dtINV1 = new DataTable();
            DataTable dttemp1 = new DataTable();
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            GetYear();
            int r = 0;


            //DataRow dtrow = dttemp1.NewRow();
            //dttemp1 = ViewState["dtINV"] as DataTable;
            int b = 0;
            string getdecimal = "";
            dtINV1 = recobj.RecPaymCalcAdjDNLedger(ledgerid, did, "U", Session["FADbname"].ToString());
            DataRow dtrow;

            if (ViewState["dtINV"] != null)
            {
                dttemp1 = ViewState["dtINV"] as DataTable;
                r = dttemp1.Rows.Count;
            }

            if (dttemp1.Rows.Count == 0 && dtINV1.Rows.Count > 0)
            {
                dttemp1.Columns.Add("branchid");
                dttemp1.Columns.Add("branch");
                dttemp1.Columns.Add("invoiceno");
                dttemp1.Columns.Add("curr");
                dttemp1.Columns.Add("fcamt");

                dttemp1.Columns.Add("exrate");
                dttemp1.Columns.Add("vamount");
                dttemp1.Columns.Add("recptfcamt");
                dttemp1.Columns.Add("tamount");
                dttemp1.Columns.Add("voutype");
                dttemp1.Columns.Add("vouno");
                dttemp1.Columns.Add("ravouyear");
                dttemp1.Columns.Add("ltype");
                dttemp1.Columns.Add("customerid");
            }
            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {
                dtrow = dttemp1.NewRow();
                dttemp1.Rows.Add();
                dttemp1.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dttemp1.Rows[r]["branch"] = dtINV1.Rows[i]["shortname"].ToString();
                dttemp1.Rows[r]["invoiceno"] = "AdjDCN - " + dtINV1.Rows[i]["vouno"].ToString();
                dttemp1.Rows[r]["curr"] = dtINV1.Rows[i]["fcur"].ToString();
                getdecimal = dtINV1.Rows[i]["receiptfamount"].ToString();

                dttemp1.Rows[r]["fcamt"] = Convert.ToDecimal(getdecimal).ToString("#,0.00");

                getdecimal = dtINV1.Rows[i]["exrate"].ToString();
                dttemp1.Rows[r]["exrate"] = Convert.ToDecimal(getdecimal).ToString("#,0.00");
                dttemp1.Rows[r]["vamount"] = dtINV1.Rows[i]["vamount"].ToString();
                dttemp1.Rows[r]["recptfcamt"] = dtINV1.Rows[i]["famount"].ToString();
                dttemp1.Rows[r]["tamount"] = dtINV1.Rows[i]["ramount"].ToString();

                dttemp1.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dttemp1.Rows[r]["vouno"] = dtINV1.Rows[i]["vouno"].ToString();
                dttemp1.Rows[r]["ravouyear"] = dtINV1.Rows[i]["ravouyear"].ToString();
                dttemp1.Rows[r]["customerid"] = Convert.ToInt32(hid_cust.Value); //dtINV1.Rows[i]["customerid"].ToString();

                if (dtINV1.Rows[i]["voutype"].ToString() == "U")
                {
                    dttemp1.Rows[r]["ltype"] = dtINV1.Rows[i]["ledgertype"].ToString();
                }
                r = r + 1;

            }

            if (dttemp1.Rows.Count > 0)
            {
                Grid_detail.DataSource = dttemp1;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttemp1;
            }



        }

        private void ReAdjCN()
        {
            GetYear();
            DataTable dtINV1 = new DataTable();
            DataTable dttemp1 = new DataTable();
            did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());

            int r = 0;
            //DataRow dtrow = dttemp1.NewRow();
            //dttemp1 = ViewState["dtINV"] as DataTable;
            int b = 0;
            string getdecimal = "";
            dtINV1 = recobj.RecPaymCalcAdjDNLedger(ledgerid, did, "T", Session["FADbname"].ToString());
            DataRow dtrow;
            b = dttemp1.Rows.Count;
            if (ViewState["dtINV"] != null)
            {
                dttemp1 = ViewState["dtINV"] as DataTable;
                r = dttemp1.Rows.Count;
            }
            if (dttemp1.Rows.Count == 0 && dtINV1.Rows.Count > 0)
            {
                dttemp1.Columns.Add("branchid");
                dttemp1.Columns.Add("branch");
                dttemp1.Columns.Add("invoiceno");
                dttemp1.Columns.Add("curr");
                dttemp1.Columns.Add("fcamt");

                dttemp1.Columns.Add("exrate");
                dttemp1.Columns.Add("vamount");
                dttemp1.Columns.Add("recptfcamt");
                dttemp1.Columns.Add("tamount");
                dttemp1.Columns.Add("voutype");
                dttemp1.Columns.Add("vouno");
                dttemp1.Columns.Add("ravouyear");
                dttemp1.Columns.Add("ltype");
                dttemp1.Columns.Add("customerid");
            }
            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {
                dtrow = dttemp1.NewRow();
                dttemp1.Rows.Add();
                dttemp1.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dttemp1.Rows[r]["branch"] = dtINV1.Rows[i]["shortname"].ToString();
                dttemp1.Rows[r]["invoiceno"] = "AdjDCN - " + dtINV1.Rows[i]["vouno"].ToString();
                dttemp1.Rows[r]["curr"] = dtINV1.Rows[i]["fcur"].ToString();
                getdecimal = dtINV1.Rows[i]["receiptfamount"].ToString();
                dttemp1.Rows[i]["fcamt"] = Convert.ToDecimal(getdecimal).ToString("#,0.00");

                getdecimal = dtINV1.Rows[i]["exrate"].ToString();
                dttemp1.Rows[r]["exrate"] = Convert.ToDecimal(getdecimal).ToString("#,0.00");
                dttemp1.Rows[r]["vamount"] = dtINV1.Rows[i]["vamount"].ToString();
                dttemp1.Rows[r]["recptfcamt"] = dtINV1.Rows[i]["famount"].ToString();
                dttemp1.Rows[r]["tamount"] = dtINV1.Rows[i]["ramount"].ToString();

                dttemp1.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dttemp1.Rows[r]["vouno"] = dtINV1.Rows[i]["vouno"].ToString();
                dttemp1.Rows[r]["ravouyear"] = dtINV1.Rows[i]["ravouyear"].ToString();
                dttemp1.Rows[r]["customerid"] = Convert.ToInt32(hid_cust.Value); //dtINV1.Rows[i]["customerid"].ToString();

                if (dtINV1.Rows[i]["voutype"].ToString() == "U")
                {
                    dttemp1.Rows[r]["ltype"] = dtINV1.Rows[i]["ledgertype"].ToString();
                }
                r = r + 1;
            }

            if (dttemp1.Rows.Count > 0)
            {
                Grid_detail.DataSource = dttemp1;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttemp1;
            }



        }


        private void GetYear()
        {

            dispyear = HttpContext.Current.Session["Vouyear"].ToString();
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
                int Custid;
                DataTable dtINV1 = new DataTable();
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                if (hid_custid.Value != "")
                {
                    Custid = Convert.ToInt32(hid_favour.Value);
                    dtINV1 = recobj.GetInvRecptDtls1(Custid, did);
                    DataTable dttemp = new DataTable();

                    if (dtINV1.Rows.Count > 0)
                    {
                        dttemp.Columns.Add("branchid", typeof(string));
                        dttemp.Columns.Add("branch", typeof(string));
                        dttemp.Columns.Add("invoiceno", typeof(string));
                        dttemp.Columns.Add("vamount", typeof(string));
                        dttemp.Columns.Add("tamount", typeof(string));

                        dttemp.Columns.Add("voutype", typeof(string));
                        dttemp.Columns.Add("vouno", typeof(string));
                        dttemp.Columns.Add("tds", typeof(string));
                        dttemp.Columns.Add("ravouyear", typeof(string));
                        dttemp.Columns.Add("ltype", typeof(string));
                        dttemp.Columns.Add("vendorrefno", typeof(string));
                        dttemp.Columns.Add("vendorrefdate", typeof(string));

                        for (int i = 0; i < dtINV1.Rows.Count; i++)
                        {
                            DataRow dtrow = dttemp.NewRow();
                            dtrow["branchid"] = dtINV1.Rows[i][0].ToString();
                            dtrow["branch"] = dtINV1.Rows[i][1].ToString();
                            dtrow["invoiceno"] = "SI - " + dtINV1.Rows[i][2].ToString();
                            dtrow["vamount"] = dtINV1.Rows[i][3].ToString();
                            dtrow["tamount"] = dtINV1.Rows[i][4].ToString();

                            dtrow["voutype"] = dtINV1.Rows[i][5].ToString();
                            dtrow["vouno"] = "";
                            dtrow["tds"] = "";
                            dtrow["ravouyear"] = dtINV1.Rows[i][6].ToString();
                            dtrow["ltype"] = "";
                            dtrow["vendorrefno"] = "";
                            dtrow["vendorrefdate"] = "";
                            dttemp.Rows.Add(dtrow);
                        }

                        Grid_detail.DataSource = dttemp;
                        Grid_detail.DataBind();
                        ViewState["dtINV"] = dttemp;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void DN()
        {
            try
            {
                int Custid;
                DataTable dtINV3 = new DataTable();
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int b = 0;
                DataTable dttempOSDn = new DataTable();
                DataRow dtrow;
                int r = 0;
                if (hid_favour.Value != "")
                {
                    Custid = Convert.ToInt32(hid_favour.Value);
                    dtINV3 = recobj.GetDN4OSLedger(Custid, did);
                    if (ViewState["dtINV"] != null)
                    {
                        dttempOSDn = ViewState["dtINV"] as DataTable;
                        r = dttempOSDn.Rows.Count;
                    }

                    if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                    {

                        dttempOSDn.Columns.Add("branchid", typeof(string));
                        dttempOSDn.Columns.Add("branch", typeof(string));
                        dttempOSDn.Columns.Add("invoiceno", typeof(string));
                        dttempOSDn.Columns.Add("curr", typeof(string));
                        dttempOSDn.Columns.Add("fcamt", typeof(string));
                        dttempOSDn.Columns.Add("exrate", typeof(string));
                        dttempOSDn.Columns.Add("vamount", typeof(string));
                        dttempOSDn.Columns.Add("tamount", typeof(string));

                        dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                        dttempOSDn.Columns.Add("voutype", typeof(string));
                        dttempOSDn.Columns.Add("vouno", typeof(string));
                        dttempOSDn.Columns.Add("tds", typeof(string));
                        dttempOSDn.Columns.Add("ravouyear", typeof(string));
                        dttempOSDn.Columns.Add("ltype", typeof(string));
                        dttempOSDn.Columns.Add("customerid", typeof(string));
                        dttempOSDn.Columns.Add("vendorrefno", typeof(string));
                        dttempOSDn.Columns.Add("vendorrefdate", typeof(string));
                    }

                    for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                    {
                        dtrow = dttempOSDn.NewRow();
                        dttempOSDn.Rows.Add();
                        dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                        dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();
                        dttempOSDn.Rows[r][2] = "DN - " + dtINV3.Rows[i][2].ToString();
                        dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();
                        fcAmount = dtINV3.Rows[i]["fcamt"].ToString();
                        dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                        exrate = dtINV3.Rows[i]["exrate"].ToString();
                        dttempOSDn.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                        dttempOSDn.Rows[r][6] = dtINV3.Rows[i][6].ToString();
                        dttempOSDn.Rows[r][7] = dtINV3.Rows[i][10].ToString();
                        dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                        dttempOSDn.Rows[r][9] = dtINV3.Rows[i][8].ToString();
                        dttempOSDn.Rows[r][10] = dtINV3.Rows[i][2].ToString();
                        dttempOSDn.Rows[r][12] = dtINV3.Rows[i][9].ToString();
                        dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value);
                        dttempOSDn.Rows[r]["vendorrefno"] = "";
                        dttempOSDn.Rows[r]["vendorrefdate"] = "";  //dtINV3.Rows[i]["customerid"].ToString();
                        //dttempOSDn.Rows[i][0] = dtINV3.Rows[i][12].ToString();
                        //dttempOSDn.Rows[i][0] = dtINV3.Rows[i][13].ToString();
                        //dttempOSDn.Rows.Add(dtrow);
                        //dttempOSDn.Rows.Add();
                        r = r + 1;
                    }

                    Grid_detail.DataSource = dttempOSDn;
                    Grid_detail.DataBind();
                    ViewState["dtINV"] = dttempOSDn;
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void AdminDN()
        {
            try
            {
                int Custid;
                DataTable dtINV3 = new DataTable();
                DataTable dttempOSDn = new DataTable();
                int b = 0;
                int r = 0;
                DataRow dtrow;
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                if (hid_favour.Value != "")
                {
                    Custid = Convert.ToInt32(hid_favour.Value);
                    dtINV3 = recobj.GetAdminDN(Custid, did);
                    if (ViewState["dtINV"] != null)
                    {
                        dttempOSDn = ViewState["dtINV"] as DataTable;
                        r = dttempOSDn.Rows.Count;
                    }

                    if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                    {

                        dttempOSDn.Columns.Add("branchid", typeof(string));
                        dttempOSDn.Columns.Add("branch", typeof(string));
                        dttempOSDn.Columns.Add("invoiceno", typeof(string));
                        dttempOSDn.Columns.Add("curr", typeof(string));
                        dttempOSDn.Columns.Add("fcamt", typeof(string));
                        dttempOSDn.Columns.Add("exrate", typeof(string));
                        dttempOSDn.Columns.Add("vamount", typeof(string));
                        dttempOSDn.Columns.Add("tamount", typeof(string));

                        dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                        dttempOSDn.Columns.Add("voutype", typeof(string));
                        dttempOSDn.Columns.Add("vouno", typeof(string));
                        dttempOSDn.Columns.Add("tds", typeof(string));
                        dttempOSDn.Columns.Add("ravouyear", typeof(string));
                        dttempOSDn.Columns.Add("ltype", typeof(string));
                        dttempOSDn.Columns.Add("customerid", typeof(string));
                    }

                    for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                    {
                        dtrow = dttempOSDn.NewRow();
                        dttempOSDn.Rows.Add();
                        dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                        dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();
                        dttempOSDn.Rows[r][2] = "ADN - " + dtINV3.Rows[i][2].ToString();
                        dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();

                        dttempOSDn.Rows[r][5] = dtINV3.Rows[i][4].ToString();
                        fcAmount = dtINV3.Rows[i][5].ToString();
                        dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#0.00");
                        dttempOSDn.Rows[r][6] = dtINV3.Rows[i][2].ToString();
                        dttempOSDn.Rows[r][8] = dtINV3.Rows[i][6].ToString();
                        dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value); //dtINV3.Rows[i]["customerid"].ToString();
                        r = r + 1;

                    }

                    Grid_detail.DataSource = dttempOSDn;
                    Grid_detail.DataBind();
                    ViewState["dtINV"] = dttempOSDn;
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void all()
        {
            try
            {
                int Custid;
                DataTable dtINV3 = new DataTable();
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int b = 0;
                int r = 0;
                DataTable dttempOSDn = new DataTable();
                DataRow dtrow;
                if (hid_favour.Value != "")
                {
                    Custid = Convert.ToInt32(hid_favour.Value);
                    // dtINV3 = recobj.GetOSDN4OS(Custid, did);
                    dtINV3 = recobj.Getall4OSLedgerlv(Custid, did);
                    if (ViewState["dtINV"] != null)
                    {
                        dttempOSDn = ViewState["dtINV"] as DataTable;
                        r = dttempOSDn.Rows.Count;
                    }

                    if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                    {

                        dttempOSDn.Columns.Add("branchid", typeof(string));
                        dttempOSDn.Columns.Add("branch", typeof(string));
                        dttempOSDn.Columns.Add("invoiceno", typeof(string));
                        dttempOSDn.Columns.Add("curr", typeof(string));
                        dttempOSDn.Columns.Add("fcamt", typeof(string));
                        dttempOSDn.Columns.Add("exrate", typeof(string));
                        dttempOSDn.Columns.Add("vamount", typeof(string));
                        dttempOSDn.Columns.Add("tamount", typeof(string));

                        dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                        dttempOSDn.Columns.Add("voutype", typeof(string));
                        dttempOSDn.Columns.Add("vouno", typeof(string));
                        dttempOSDn.Columns.Add("tds", typeof(string));
                        dttempOSDn.Columns.Add("ravouyear", typeof(string));
                        dttempOSDn.Columns.Add("ltype", typeof(string));
                        dttempOSDn.Columns.Add("customerid", typeof(string));

                        dttempOSDn.Columns.Add("vendorrefno", typeof(string));
                        dttempOSDn.Columns.Add("vendorrefdate", typeof(string));
                    }

                    for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                    {
                        dtrow = dttempOSDn.NewRow();
                        dttempOSDn.Rows.Add();
                        dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                        dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();
                        //if (dtINV3.Rows[i]["voutype"].ToString() == "D")
                        //{
                        //    dttempOSDn.Rows[r][2] = "OSDN - " + dtINV3.Rows[i][2].ToString();
                        //}
                        //else if (dtINV3.Rows[i]["voutype"].ToString() == "C")
                        //{
                        //    dttempOSDn.Rows[r][2] = "OSCN - " + dtINV3.Rows[i][2].ToString();
                        //}


                        if (dtINV3.Rows[i][8].ToString() == "I")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "SI - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "P")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "PI - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "S")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "ADN - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "X")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "ACN - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "D")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "OSSI - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "C")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "OSPI - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "V")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "DN - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "E")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "CN - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "B")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "BOS - " + dtINV3.Rows[i][2].ToString();
                        }


                        if (dtINV3.Rows[i][8].ToString() == "F") // Vino [05-03-2024]
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "SI OC - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "G")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "PI OC - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "H")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "BS OC - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "OF") // Vino [05-03-2024]
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "OB SI OC - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "OG")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "OB PI OC - " + dtINV3.Rows[i][2].ToString();
                        }
                        else if (dtINV3.Rows[i][8].ToString() == "OH")
                        {
                            dttempOSDn.Rows[r]["invoiceno"] = "OB BS OC - " + dtINV3.Rows[i][2].ToString();
                        }


                        dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();
                        fcAmount = dtINV3.Rows[i]["fcamt"].ToString();
                        dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                        exrate = dtINV3.Rows[i]["exrate"].ToString();
                        dttempOSDn.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                        dttempOSDn.Rows[r][6] = dtINV3.Rows[i][6].ToString();
                        dttempOSDn.Rows[r][7] = dtINV3.Rows[i][10].ToString();
                        dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                        dttempOSDn.Rows[r][9] = dtINV3.Rows[i][8].ToString();
                        dttempOSDn.Rows[r][10] = dtINV3.Rows[i][2].ToString();
                        dttempOSDn.Rows[r][12] = dtINV3.Rows[i][9].ToString();
                        dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value);
                        dttempOSDn.Rows[r]["vendorrefno"] = "";
                        dttempOSDn.Rows[r]["vendorrefdate"] = "";// dtINV3.Rows[i]["customerid"].ToString();
                        r = r + 1;
                    }

                    Grid_detail.DataSource = dttempOSDn;
                    Grid_detail.DataBind();
                    ViewState["dtINV"] = dttempOSDn;
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void OSDN()
        {
            try
            {
                int Custid;
                DataTable dtINV3 = new DataTable();
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int b = 0;
                int r = 0;
                DataTable dttempOSDn = new DataTable();
                DataRow dtrow;
                if (hid_favour.Value != "")
                {
                    Custid = Convert.ToInt32(hid_favour.Value);
                    // dtINV3 = recobj.GetOSDN4OS(Custid, did);
                    dtINV3 = recobj.GetOSDN4OSLedger(Custid, did);
                    if (ViewState["dtINV"] != null)
                    {
                        dttempOSDn = ViewState["dtINV"] as DataTable;
                        r = dttempOSDn.Rows.Count;
                    }

                    if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                    {

                        dttempOSDn.Columns.Add("branchid", typeof(string));
                        dttempOSDn.Columns.Add("branch", typeof(string));
                        dttempOSDn.Columns.Add("invoiceno", typeof(string));
                        dttempOSDn.Columns.Add("curr", typeof(string));
                        dttempOSDn.Columns.Add("fcamt", typeof(string));
                        dttempOSDn.Columns.Add("exrate", typeof(string));
                        dttempOSDn.Columns.Add("vamount", typeof(string));
                        dttempOSDn.Columns.Add("tamount", typeof(string));

                        dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                        dttempOSDn.Columns.Add("voutype", typeof(string));
                        dttempOSDn.Columns.Add("vouno", typeof(string));
                        dttempOSDn.Columns.Add("tds", typeof(string));
                        dttempOSDn.Columns.Add("ravouyear", typeof(string));
                        dttempOSDn.Columns.Add("ltype", typeof(string));
                        dttempOSDn.Columns.Add("customerid", typeof(string));

                        dttempOSDn.Columns.Add("vendorrefno", typeof(string));
                        dttempOSDn.Columns.Add("vendorrefdate", typeof(string));
                    }

                    for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                    {
                        dtrow = dttempOSDn.NewRow();
                        dttempOSDn.Rows.Add();
                        dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                        dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();
                        dttempOSDn.Rows[r][2] = "OSSI - " + dtINV3.Rows[i][2].ToString();
                        dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();
                        fcAmount = dtINV3.Rows[i]["fcamt"].ToString();
                        dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                        exrate = dtINV3.Rows[i]["exrate"].ToString();
                        dttempOSDn.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                        dttempOSDn.Rows[r][6] = dtINV3.Rows[i][6].ToString();
                        dttempOSDn.Rows[r][7] = dtINV3.Rows[i][10].ToString();
                        dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                        dttempOSDn.Rows[r][9] = dtINV3.Rows[i][8].ToString();
                        dttempOSDn.Rows[r][10] = dtINV3.Rows[i][2].ToString();
                        dttempOSDn.Rows[r][12] = dtINV3.Rows[i][9].ToString();
                        dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value);
                        dttempOSDn.Rows[r]["vendorrefno"] = "";
                        dttempOSDn.Rows[r]["vendorrefdate"] = "";// dtINV3.Rows[i]["customerid"].ToString();
                        r = r + 1;
                    }

                    Grid_detail.DataSource = dttempOSDn;
                    Grid_detail.DataBind();
                    ViewState["dtINV"] = dttempOSDn;
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void CN()
        {
            int Custid;
            DataTable dtINV3 = new DataTable();
            int b = 0;
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataTable dttempOSDn = new DataTable();
            DataRow dtrow;
            int r = 0;
            if (hid_favour.Value != "")
            {
                Custid = Convert.ToInt32(hid_favour.Value);
                dtINV3 = pymtobj.GetCN4OSLedger(Custid, did);
                if (ViewState["dtINV"] != null)
                {
                    dttempOSDn = ViewState["dtINV"] as DataTable;
                    r = dttempOSDn.Rows.Count;
                }

                if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                {

                    dttempOSDn.Columns.Add("branchid", typeof(string));
                    dttempOSDn.Columns.Add("branch", typeof(string));
                    dttempOSDn.Columns.Add("invoiceno", typeof(string));
                    dttempOSDn.Columns.Add("curr", typeof(string));
                    dttempOSDn.Columns.Add("fcamt", typeof(string));
                    dttempOSDn.Columns.Add("exrate", typeof(string));
                    dttempOSDn.Columns.Add("vamount", typeof(string));
                    dttempOSDn.Columns.Add("tamount", typeof(string));

                    dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                    dttempOSDn.Columns.Add("voutype", typeof(string));
                    dttempOSDn.Columns.Add("vouno", typeof(string));
                    dttempOSDn.Columns.Add("tds", typeof(string));
                    dttempOSDn.Columns.Add("ravouyear", typeof(string));
                    dttempOSDn.Columns.Add("ltype", typeof(string));
                    dttempOSDn.Columns.Add("customerid", typeof(string));

                    dttempOSDn.Columns.Add("vendorrefno", typeof(string));
                    dttempOSDn.Columns.Add("vendorrefdate", typeof(string));
                }

                for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                {
                    dtrow = dttempOSDn.NewRow();
                    dttempOSDn.Rows.Add();
                    dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                    dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();
                    dttempOSDn.Rows[r][2] = "CN - " + dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();
                    fcAmount = dtINV3.Rows[i]["fcamt"].ToString();
                    dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                    exrate = dtINV3.Rows[i]["exrate"].ToString();
                    dttempOSDn.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                    dttempOSDn.Rows[r][6] = dtINV3.Rows[i][6].ToString();
                    dttempOSDn.Rows[r][7] = dtINV3.Rows[i][10].ToString();
                    dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                    dttempOSDn.Rows[r][9] = dtINV3.Rows[i][8].ToString();
                    dttempOSDn.Rows[r][10] = dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][12] = dtINV3.Rows[i][9].ToString();
                    dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value);
                    dttempOSDn.Rows[r]["vendorrefno"] = dtINV3.Rows[i]["vendorrefno"].ToString();
                    dttempOSDn.Rows[r]["vendorrefdate"] = dtINV3.Rows[i]["vendorrefdate"].ToString();//dtINV3.Rows[i]["customerid"].ToString();
                    r = r + 1;

                }

                Grid_detail.DataSource = dttempOSDn;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttempOSDn;
            }

        }

        private void PA()
        {
            int Custid;
            DataTable dtINV3 = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataTable dttempOSDn = new DataTable();
            DataRow dtrow;
            int b = 0;
            int r = 0;
            if (hid_favour.Value != "")
            {
                Custid = Convert.ToInt32(hid_favour.Value);
                dtINV3 = pymtobj.GetPAPaymentDtls1(Custid, did);
                if (ViewState["dtINV"] != null)
                {
                    dttempOSDn = ViewState["dtINV"] as DataTable;
                    r = dttempOSDn.Rows.Count;
                }

                if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                {

                    dttempOSDn.Columns.Add("branchid", typeof(string));
                    dttempOSDn.Columns.Add("branch", typeof(string));
                    dttempOSDn.Columns.Add("invoiceno", typeof(string));
                    dttempOSDn.Columns.Add("curr", typeof(string));
                    dttempOSDn.Columns.Add("fcamt", typeof(string));
                    dttempOSDn.Columns.Add("exrate", typeof(string));
                    dttempOSDn.Columns.Add("vamount", typeof(string));
                    dttempOSDn.Columns.Add("tamount", typeof(string));

                    dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                    dttempOSDn.Columns.Add("voutype", typeof(string));
                    dttempOSDn.Columns.Add("vouno", typeof(string));
                    dttempOSDn.Columns.Add("tds", typeof(string));
                    dttempOSDn.Columns.Add("ravouyear", typeof(string));
                    dttempOSDn.Columns.Add("ltype", typeof(string));
                    dttempOSDn.Columns.Add("customerid", typeof(string));

                    dttempOSDn.Columns.Add("vendorrefno", typeof(string));
                    dttempOSDn.Columns.Add("vendorrefdate", typeof(string));
                }

                for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                {
                    dtrow = dttempOSDn.NewRow();
                    dttempOSDn.Rows.Add();
                    dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                    dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();
                    dttempOSDn.Rows[r][2] = "PA - " + dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();

                    dttempOSDn.Rows[r][5] = dtINV3.Rows[i][4].ToString();
                    fcAmount = dtINV3.Rows[i][5].ToString();
                    dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                    dttempOSDn.Rows[r][6] = dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][7] = dtINV3.Rows[i][6].ToString();
                    dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                    dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value);
                    dttempOSDn.Rows[r]["vendorrefno"] = dtINV3.Rows[i]["vendorrefno"].ToString();
                    dttempOSDn.Rows[r]["vendorrefdate"] = dtINV3.Rows[i]["vendorrefdate"].ToString();//dtINV3.Rows[i]["customerid"].ToString();
                    r = r + 1;
                }

                Grid_detail.DataSource = dttempOSDn;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttempOSDn;
            }

        }

        private void AdminCN()
        {
            int Custid;
            DataTable dtINV3 = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataTable dttempOSDn = new DataTable();
            DataRow dtrow;
            int b = 0;
            int r = 0;
            if (hid_favour.Value != "")
            {
                Custid = Convert.ToInt32(hid_favour.Value);
                dtINV3 = pymtobj.GetAdminCN(Custid, did);
                if (ViewState["dtINV"] != null)
                {
                    dttempOSDn = ViewState["dtINV"] as DataTable;
                    //b = dttempOSDn.Rows.Count;
                }

                if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                {

                    dttempOSDn.Columns.Add("branchid", typeof(string));
                    dttempOSDn.Columns.Add("branch", typeof(string));
                    dttempOSDn.Columns.Add("invoiceno", typeof(string));
                    dttempOSDn.Columns.Add("curr", typeof(string));
                    dttempOSDn.Columns.Add("fcamt", typeof(string));
                    dttempOSDn.Columns.Add("exrate", typeof(string));
                    dttempOSDn.Columns.Add("vamount", typeof(string));
                    dttempOSDn.Columns.Add("tamount", typeof(string));

                    dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                    dttempOSDn.Columns.Add("voutype", typeof(string));
                    dttempOSDn.Columns.Add("vouno", typeof(string));
                    dttempOSDn.Columns.Add("tds", typeof(string));
                    dttempOSDn.Columns.Add("ravouyear", typeof(string));
                    dttempOSDn.Columns.Add("ltype", typeof(string));
                    dttempOSDn.Columns.Add("customerid", typeof(string));
                }

                for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                {
                    dtrow = dttempOSDn.NewRow();
                    dttempOSDn.Rows.Add();
                    dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                    dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();
                    dttempOSDn.Rows[r][2] = "ACN - " + dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();

                    dttempOSDn.Rows[r][5] = dtINV3.Rows[i][4].ToString();
                    fcAmount = dtINV3.Rows[i][5].ToString();
                    dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                    dttempOSDn.Rows[r][6] = dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][7] = dtINV3.Rows[i][6].ToString();
                    dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                    dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value); //dtINV3.Rows[i]["customerid"].ToString();

                    r = r + 1;
                }

                Grid_detail.DataSource = dttempOSDn;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttempOSDn;
            }

        }

        private void OSCN()
        {
            int Custid;
            DataTable dtINV3 = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataTable dttempOSDn = new DataTable();
            DataRow dtrow;
            int r = 0;
            if (hid_favour.Value != "")
            {
                Custid = Convert.ToInt32(hid_favour.Value);
                dtINV3 = pymtobj.GetOSCN4OSLedger(Custid, did);
                if (ViewState["dtINV"] != null)
                {
                    dttempOSDn = ViewState["dtINV"] as DataTable;
                    r = dttempOSDn.Rows.Count;
                }

                if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                {

                    dttempOSDn.Columns.Add("branchid", typeof(string));
                    dttempOSDn.Columns.Add("branch", typeof(string));
                    dttempOSDn.Columns.Add("invoiceno", typeof(string));
                    dttempOSDn.Columns.Add("curr", typeof(string));
                    dttempOSDn.Columns.Add("fcamt", typeof(string));
                    dttempOSDn.Columns.Add("exrate", typeof(string));
                    dttempOSDn.Columns.Add("vamount", typeof(string));
                    dttempOSDn.Columns.Add("tamount", typeof(string));

                    dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                    dttempOSDn.Columns.Add("voutype", typeof(string));
                    dttempOSDn.Columns.Add("vouno", typeof(string));
                    dttempOSDn.Columns.Add("tds", typeof(string));
                    dttempOSDn.Columns.Add("ravouyear", typeof(string));
                    dttempOSDn.Columns.Add("ltype", typeof(string));
                    dttempOSDn.Columns.Add("customerid", typeof(string));

                    dttempOSDn.Columns.Add("vendorrefno", typeof(string));
                    dttempOSDn.Columns.Add("vendorrefdate", typeof(string));
                }

                for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                {
                    dtrow = dttempOSDn.NewRow();
                    dttempOSDn.Rows.Add();
                    dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                    dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();
                    dttempOSDn.Rows[r][2] = "OSPI - " + dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();
                    fcAmount = dtINV3.Rows[i]["fcamt"].ToString();
                    dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                    exrate = dtINV3.Rows[i]["exrate"].ToString();
                    dttempOSDn.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                    dttempOSDn.Rows[r][6] = dtINV3.Rows[i][6].ToString();
                    dttempOSDn.Rows[r][7] = dtINV3.Rows[i][10].ToString();
                    dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                    dttempOSDn.Rows[r][9] = dtINV3.Rows[i][8].ToString();
                    dttempOSDn.Rows[r][10] = dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][12] = dtINV3.Rows[i][9].ToString();
                    dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value);
                    dttempOSDn.Rows[r]["vendorrefno"] = dtINV3.Rows[i]["vendorrefno"].ToString();
                    dttempOSDn.Rows[r]["vendorrefdate"] = dtINV3.Rows[i]["vendorrefdate"].ToString();//dtINV3.Rows[i]["customerid"].ToString();
                    r = r + 1;
                }

                Grid_detail.DataSource = dttempOSDn;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttempOSDn;
            }
        }

        private void Journal()
        {
            GetYear();
            int Custid;
            int r = 0;
            string iamount = "", tamount = "", fcamt = "", fexrate = "", recptfcamt = "";
            DataTable dtINV1 = new DataTable();
            DataTable dt = new DataTable();

            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            if (hid_favour.Value != "")
            {
                //Custid = Convert.ToInt32(hid_favour.Value);

                dt = customerobj.Getcustomeridfromledger(Convert.ToInt32(hid_favour.Value));
                Custid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());

                dtINV1 = recobj.GetOSjnrlRecptDtls(Custid, did, Session["FADbname"].ToString());
                //dtINV1 = recobj.GetjnrlRecptDtls(Custid, did, Session["FADbname"].ToString());


                DataTable dttempJ = new DataTable();
                if (dtINV1.Rows.Count > 0)
                {
                    if (ViewState["dtINV"] != null)
                    {
                        dttempJ = ViewState["dtINV"] as DataTable;
                        r = dttempJ.Rows.Count;
                    }

                    if (dttempJ.Rows.Count == 0 && dtINV1.Rows.Count > 0)
                    {
                        dttempJ.Columns.Add("branchid", typeof(string));
                        dttempJ.Columns.Add("branch", typeof(string));
                        dttempJ.Columns.Add("invoiceno", typeof(string));
                        dttempJ.Columns.Add("vamount", typeof(string));
                        dttempJ.Columns.Add("tamount", typeof(string));
                        dttempJ.Columns.Add("voutype", typeof(string));
                        dttempJ.Columns.Add("vouno", typeof(string));
                        dttempJ.Columns.Add("tds", typeof(string));
                        dttempJ.Columns.Add("ravouyear", typeof(string));
                        dttempJ.Columns.Add("ltype", typeof(string));
                        dttempJ.Columns.Add("curr", typeof(string));
                        dttempJ.Columns.Add("fcamt", typeof(string));
                        dttempJ.Columns.Add("exrate", typeof(string));
                        dttempJ.Columns.Add("recptfcamt", typeof(string));
                        dttempJ.Columns.Add("customerid", typeof(string));
                        dttempJ.Columns.Add("vendorrefno", typeof(string));
                        dttempJ.Columns.Add("vendorrefdate", typeof(string));
                    }

                    for (int i = 0; i < dtINV1.Rows.Count; i++)
                    {
                        DataRow dtrow = dttempJ.NewRow();
                        dttempJ.Rows.Add();
                        dttempJ.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                        dttempJ.Rows[r]["branch"] = dtINV1.Rows[i]["port"].ToString();
                        dttempJ.Rows[r]["invoiceno"] = "J - " + dtINV1.Rows[i]["refno"].ToString();
                        iamount = dtINV1.Rows[i]["iamount"].ToString();
                        dttempJ.Rows[r]["vamount"] = Convert.ToDecimal(iamount).ToString("#,0.00");
                        //dttempJ.Rows[r]["vamount"] = dtINV1.Rows[i]["iamount"].ToString();
                        tamount = dtINV1.Rows[i]["ramount"].ToString();
                        dttempJ.Rows[r]["tamount"] = Convert.ToDecimal(tamount).ToString("#,0.00");
                        //dttempJ.Rows[r]["tamount"] = dtINV1.Rows[i]["ramount"].ToString();
                        dttempJ.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                        dttempJ.Rows[r]["vouno"] = dtINV1.Rows[i]["refno"].ToString();
                        dttempJ.Rows[r]["tds"] = "";
                        dttempJ.Rows[r]["ravouyear"] = dtINV1.Rows[i]["vouyear"].ToString();
                        dttempJ.Rows[r]["ltype"] = dtINV1.Rows[i]["ltype"].ToString();

                        dttempJ.Rows[r]["curr"] = dtINV1.Rows[i]["curr"].ToString();
                        fcamt = dtINV1.Rows[i]["fcamt"].ToString();
                        dttempJ.Rows[r]["fcamt"] = Convert.ToDecimal(fcamt).ToString("#,0.00");
                        //dttempJ.Rows[r]["fcamt"] = dtINV1.Rows[i]["fcamt"].ToString();
                        fexrate = dtINV1.Rows[i]["exrate"].ToString();
                        dttempJ.Rows[r]["exrate"] = Convert.ToDecimal(fexrate).ToString("#,0.00");
                        //dttempJ.Rows[r]["exrate"] = dtINV1.Rows[i]["exrate"].ToString();
                        recptfcamt = dtINV1.Rows[i]["recptfcamt"].ToString();
                        dttempJ.Rows[r]["recptfcamt"] = Convert.ToDecimal(recptfcamt).ToString("#,0.00");
                        //dttempJ.Rows[r]["recptfcamt"] = dtINV1.Rows[i]["recptfcamt"].ToString();
                        dttempJ.Rows[r]["customerid"] = dtINV1.Rows[i]["customerid"].ToString();
                        dttempJ.Rows[r]["vendorrefno"] = "";
                        dttempJ.Rows[r]["vendorrefdate"] = "";
                        r = r + 1;
                    }
                    Grid_detail.DataSource = dttempJ;
                    Grid_detail.DataBind();
                }
            }
        }

        protected void btn_cust_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cust.Text != "" && txt_cust_amt.Text != "")
                {
                    if (Grid_detail.Rows.Count == 1 && Grid_detail.Rows[0].Cells[2].Text == "On Account" && (Grid_detail.Rows[0].Cells[8].Text == "0" || Grid_detail.Rows[0].Cells[8].Text == "0.00") && txt_cust_amt.Text != "")
                    {
                        string message = "Kindly Enter " + lbl_head.Text + " On Account Recpt-Fc Amount";
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert( '" + message + "');", true);
                        return;
                    }
                    try
                    {
                        double temp = Convert.ToDouble(txt_cust_amt.Text);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Invalid Amount');", true);
                        txt_cust_amt.Focus();
                        txt_cust_amt.Text = "";
                        return;
                    }

                    for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                    {
                        if (hid_cust.Value == Grid_detail.Rows[i].Cells[3].Text)
                        {
                            custexist = true;
                        }
                    }


                    if (custexist == false)
                    {
                        int Custid = cusobj.GetCustomerid(txt_cust.Text);
                        //if (Custid != 0)
                        if (hid_ledger.Value != "0")
                        {
                            DataRow Dr;
                            int c;
                            DataTable dt = new DataTable();
                            if (ViewState["CurrentData"] != null)
                            {
                                dt = (DataTable)ViewState["CurrentData"];
                                c = dt.Rows.Count;
                                //if (hid_tot1.Value == hid_tot1.Value)
                                //{
                                //    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                                //    {
                                //        if (hid_tot1.Value == hid_tot1.Value)
                                //        {


                                //            dt.Rows[i][2] = hid_total.Value;
                                //            dt.Rows[i][3] = txt_cust_amt.Text;

                                //        }

                                //    }


                                //}
                                //else
                                //{

                                if (c == 0)
                                {
                                    dt.Columns.Add("Type");
                                    dt.Columns.Add("Customerortax");//hid_total

                                    dt.Columns.Add("fc");
                                    dt.Columns.Add("Amount");
                                    dt.Columns.Add("cid");
                                }
                                Dr = dt.NewRow();
                                dt.Rows.Add(Dr);
                                Dr[0] = "Customer";
                                Dr[1] = txt_cust.Text;
                                Dr[3] = hid_total.Value;
                                Dr[2] = txt_cust_amt.Text;
                                Dr[4] = hid_customeridNew.Value.ToString();



                            }
                            else
                            {
                                dt.Columns.Add("Type");
                                dt.Columns.Add("Customerortax");//hid_total

                                dt.Columns.Add("fc");
                                dt.Columns.Add("Amount");
                                dt.Columns.Add("cid");
                                Dr = dt.NewRow();
                                dt.Rows.Add(Dr);
                                Dr[0] = "Customer";
                                Dr[1] = txt_cust.Text;

                                if (Session["rptype"] == "R" && bolCust == true)
                                {
                                    Dr[3] = Convert.ToDouble(txt_cust_amt.Text) * Convert.ToDouble(txt_exrate.Text);
                                }
                                else
                                {
                                    Dr[3] = hid_total.Value;
                                }
                                //  Dr[3] = "0";
                                Dr[2] = txt_cust_amt.Text;
                                Dr[4] = hid_customeridNew.Value.ToString();
                            }
                            if (ViewState["CurrentData"] != null)
                            {
                                Grid_Account.DataSource = dt;
                                Grid_Account.DataBind();
                                ViewState["CurrentData"] = dt;
                                //DataTable dt_cust = (DataTable)ViewState["CurrentData"];
                                //int count = dt.Rows.Count;
                                //BindGrid(count, txt_cust.ToolTip, txt_cust.Text.Trim().ToUpper(), txt_cust_amt.Text, Convert.ToInt32(Custid));
                                //BindGrid(count, txt_cust.ToolTip, txt_cust.Text.Trim().ToUpper(), txt_cust_amt.Text, Convert.ToInt32(hid_cust.Value));
                                txt_cust.Text = "";
                                txt_cust_amt.Text = "";


                            }
                            else
                            {
                                Grid_Account.DataSource = dt;
                                Grid_Account.DataBind();
                                ViewState["CurrentData"] = dt;
                                //BindGrid(1, txt_cust.ToolTip, txt_cust.Text, txt_cust_amt.Text, Convert.ToInt32(hid_cust.Value));
                                txt_cust.Text = "";
                                txt_cust_amt.Text = "";
                                //Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
                                //Grid_detail.DataBind();

                            }
                            double amt = 0;
                            double totamt = 0;
                            for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                            {
                                if (Grid_Account.Rows[i].Cells[3].Text != "&nbsp;" && Grid_Account.Rows[i].Cells[3].Text != "")
                                {
                                    Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                                    amt = amt + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);

                                }

                                //if (Grid_Account.Rows[i].Cells[3].Text != "&nbsp;")
                                //{
                                //    totamt = totamt + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                                //}
                            }
                            txt_total.Text = amt.ToString("#0.00");
                            txt_total1.Text = Total.ToString("#,0.00");
                            //txt_total1.Text = totamt.ToString("#,0.00");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Check Customer Name');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Customer Already Exist');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //protected void LoadCheque()
        //{
        //    try
        //    {

        //        if (ddl_branch.Text != "")
        //        {
        //            DataTable dt = new DataTable();
        //            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
        //            branchid = hrempobj.GetBranchId(did, ddl_branch.SelectedItem.Text);
        //            dt = recobj.Getnotovercheque4payment(branchid);
        //            Grid_Cheque.DataSource = dt;
        //            Grid_Cheque.DataBind();
        //            POPUP1.Visible = true;
        //            this.programmaticModalPopup.Show();

        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(lnk_cheque, typeof(LinkButton), "Payment", "alertify.alert('Please Select the Branch Name');", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void lnk_cheque_Click(object sender, EventArgs e)
        {
            // LoadCheque();
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
                    int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                    index = Grid_Cheque.SelectedRow.RowIndex;
                    int cheq_no = Convert.ToInt32(Grid_Cheque.Rows[index].Cells[4].Text);
                    //branchid = hrempobj.GetBranchId(did, ddl_branch.SelectedItem.Text);
                    branchid = Convert.ToInt32(Session["LoginBranchid"]);
                    dtcheque = objnoc.SelNotOverCheque(cheq_no, branchid);

                    if (dtcheque.Rows.Count > 0)
                    {
                        txt_cheque.Text = dtcheque.Rows[0]["chequeno"].ToString();
                        txt_bank.Text = dtcheque.Rows[0]["BankName"].ToString();
                        txt_branch1.Text = dtcheque.Rows[0]["bbranch"].ToString();
                        txt_cheqdate.Text = Utility.fn_ConvertDate(dtcheque.Rows[0]["chqdate"].ToString());
                        rfcustid = Convert.ToInt32(dtcheque.Rows[0]["customerid"]);
                        txt_recieve.Text = dtcheque.Rows[0]["Customername"].ToString();
                        txt_amtrs.Text = string.Format("{0:0.00}", dtcheque.Rows[0]["amount"]);

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        //protected void lnk_amount_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lbl_head.Text == "Remittance_Payment")
        //        {
        //            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
        //            if (ddl_branch.Text != "")
        //            {
        //                branchid = hrempobj.GetBranchId(did, ddl_branch.SelectedItem.Text);
        //                DataTable dtp = new DataTable();
        //                dtp = pymtobj.GetChqCOApprovedList(branchid);
        //                if (dtp.Rows.Count > 0)
        //                {
        //                    Grid_Amount.DataSource = dtp;
        //                    Grid_Amount.DataBind();
        //                    Panel2.Visible = true;
        //                    this.ModalPopup_amount.Show();
        //                    txt_cust.Enabled = false;
        //                    txt_cust_amt.Enabled = false;
        //                    btn_cust_add.Enabled = false;

        //                }

        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(lnk_amount, typeof(LinkButton), "Payment", "alertify.alert('No data found');", true);
        //            }
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(lnk_amount, typeof(LinkButton), "Payment", "alertify.alert('Please Select the Branch Name');", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

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

        }

        protected void btn_deduct_add_Click(object sender, EventArgs e)
        {
            try
            {
                // Vino New
                if (Grid_detail.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_deduct_add, typeof(Button), "Payment", "alertify.alert('Customer Details should not be Empty');", true);
                    txt_cust.Focus();
                    return;
                }

                if (txttdsAmt.Text.Trim().Length > 0 && txt_dedu_amt.Text.Trim().Length == 0 && txt_deduction.Text.Trim().Length > 0)
                {

                    int ccid = chrgobj.GetChargeid(txt_deduction.Text);
                    if (ccid != 0)
                    {
                        DataRow Dr;
                        DataTable dt_dedu = new DataTable();
                        if (ViewState["GridAccount"] != null)
                        {
                            dt_dedu = (DataTable)ViewState["GridAccount"];
                            Dr = dt_dedu.NewRow();
                            dt_dedu.Rows.Add(Dr);
                            Dr[0] = "Charges";
                            Dr[1] = txt_deduction.Text;
                            if (lbl_head.Text == "Payment")
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txttdsAmt.Text));
                                txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            else
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txttdsAmt.Text) * (-1));
                                txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            Dr[3] = hid_chargeid.Value.ToString();
                        }
                        else
                        {
                            dt_dedu.Columns.Add("Type");
                            dt_dedu.Columns.Add("Customerortax");
                            dt_dedu.Columns.Add("Amount");
                            dt_dedu.Columns.Add("cid");
                            Dr = dt_dedu.NewRow();
                            dt_dedu.Rows.Add(Dr);
                            Dr[0] = "Charges";
                            Dr[1] = txt_deduction.Text;

                            Dr[2] = "0";

                            //if (Session["rptype"] == "P")
                            //{
                            //    Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txttdsAmt.Text));
                            //    txt_dedu_amt.Text = Dr[2].ToString();
                            //}
                            //else
                            //{
                            //    Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txttdsAmt.Text) * (-1));
                            //    txt_dedu_amt.Text = Dr[2].ToString();
                            //}

                            if (Session["rptype"] == "P")
                            {
                                Dr[3] = string.Format("{0:0.00}", Convert.ToDouble(txttdsAmt.Text));
                            }
                            else
                            {
                                Dr[3] = string.Format("{0:0.00}", Convert.ToDouble(txttdsAmt.Text));
                            }
                        }

                        double ConAmount = Convert.ToDouble(txttdsAmt.Text);

                        if (ViewState["CurrentData"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["CurrentData"];
                            int count = dt.Rows.Count;
                            BindGridCharge(count, txt_deduction.ToolTip, txt_deduction.Text.Trim().ToUpper(), txttdsAmt.Text, Convert.ToInt32(ccid));
                        }
                        else
                        {
                            BindGridCharge(1, txt_deduction.ToolTip, txt_deduction.Text.Trim().ToUpper(), txttdsAmt.Text, Convert.ToInt32(ccid));
                        }

                        double Total = 0;
                        for (int i = 0; i < Grid_Account.Rows.Count; i++)
                        {
                            Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                        }
                        txt_total1.Text = string.Format("{0:0.00}", Total);

                        if (Session["rptype"] == "R")
                        {
                            lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                        }
                        //txt_total.Text = total.ToString("#,0.00");
                        //txt_total1.Text = Total.ToString("#,0.00");
                        txt_deduction.Text = "";
                        txt_dedu_amt.Text = "";
                        txttdsAmt.Text = "";

                        if (Session["rptype"] == "R")
                        {
                            lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Check Charge Name');", true);
                    }


                    //ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Amount');", true);
                    //txttdsAmt.Focus();
                    //txttdsAmt.Text = "";
                    //return;
                }


                if (txt_deduction.Text.Trim().Length > 0 && txt_dedu_amt.Text.Trim().Length > 0)
                {
                    try
                    {
                        double temp = Convert.ToDouble(txttdsAmt.Text);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Invalid Amount');", true);
                        txttdsAmt.Focus();
                        txttdsAmt.Text = "";
                        return;
                    }

                    int ccid = chrgobj.GetChargeid(txt_deduction.Text);
                    if (ccid != 0)
                    {
                        DataRow Dr;
                        DataTable dt_dedu = new DataTable();
                        if (ViewState["GridAccount"] != null)
                        {
                            dt_dedu = (DataTable)ViewState["GridAccount"];
                            Dr = dt_dedu.NewRow();
                            dt_dedu.Rows.Add(Dr);
                            Dr[0] = "Charges";
                            Dr[1] = txt_deduction.Text;
                            if (lbl_head.Text == "Payment")
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            else
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text) * (-1));
                                txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            Dr[3] = hid_chargeid.Value.ToString();
                        }
                        else
                        {
                            dt_dedu.Columns.Add("Type");
                            dt_dedu.Columns.Add("Customerortax");
                            dt_dedu.Columns.Add("Amount");
                            dt_dedu.Columns.Add("cid");
                            Dr = dt_dedu.NewRow();
                            dt_dedu.Rows.Add(Dr);
                            Dr[0] = "Charges";
                            Dr[1] = txt_deduction.Text;
                            if (Session["rptype"] == "P")
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            else
                            {
                                Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_dedu_amt.Text));
                                txt_dedu_amt.Text = Dr[2].ToString();
                            }

                            if (Session["rptype"] == "P")
                            {
                                Dr[3] = string.Format("{0:0.00}", Convert.ToDouble(txttdsAmt.Text));
                                // txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            else
                            {
                                Dr[3] = string.Format("{0:0.00}", Convert.ToDouble(txttdsAmt.Text));
                                //txt_dedu_amt.Text = Dr[2].ToString();
                            }
                            // Dr[3] = ccid;
                        }

                        double ConAmount = Convert.ToDouble(txttdsAmt.Text);

                        if (ViewState["CurrentData"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["CurrentData"];
                            int count = dt.Rows.Count;
                            BindGrid(count, txt_deduction.ToolTip, txt_deduction.Text.Trim().ToUpper(), txt_dedu_amt.Text, Convert.ToInt32(ccid));
                            // BindGrid(count, txt_deduction.ToolTip, txt_deduction.Text.Trim().ToUpper(), txt_dedu_amt.Text, Convert.ToInt32(ccid));
                        }
                        else
                        {
                            BindGrid(1, txt_deduction.ToolTip, txt_deduction.Text.Trim().ToUpper(), txt_dedu_amt.Text, Convert.ToInt32(ccid));
                            // BindGrid(1, txt_deduction.ToolTip, txt_deduction.Text.Trim().ToUpper(), txt_dedu_amt.Text, Convert.ToInt32(ccid));
                        }



                        double Total = 0;
                        double total = 0;
                        for (int i = 0; i < Grid_Account.Rows.Count; i++)
                        {
                            if (Grid_Account.Rows[i].Cells[2].Text != "&nbsp;")
                            {
                                total = total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                            }

                            if (Grid_Account.Rows[i].Cells[3].Text != "&nbsp;")
                            {
                                Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                            }
                        }
                        txt_total.Text = total.ToString("#,0.00");
                        txt_total1.Text = Total.ToString("#,0.00");
                        txt_deduction.Text = "";
                        txt_dedu_amt.Text = "";
                        txttdsAmt.Text = "";
                        //  txt_amtrs.Text = txt_total1.Text;
                        if (Session["rptype"] == "R")
                        {
                            lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Check Charge Name');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void BindGridCharge(int rowcount, string txttype, string cust, string amt, int cid)
        {
            double amount;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Customerortax", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("fc", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("cid", typeof(String)));

            if (ViewState["CurrentData"] != null && txt_deduction.Text != "")
            {
                dt = (DataTable)ViewState["CurrentData"];
                if (dt.Rows.Count > 0)
                {
                    dr = dt.NewRow();

                    dr[0] = "Charges";
                    dr[1] = cust;
                    dr[2] = "";

                    amount = Convert.ToDouble(amt.ToString());
                    dr[3] = amount.ToString("#0.00");

                    dr[4] = cid.ToString();
                    dt.Rows.Add(dr);
                }
            }

            if (ViewState["CurrentData"] != null && txt_deduction.Text != "")
            {
                Grid_Account.DataSource = (DataTable)ViewState["CurrentData"];
                Grid_Account.DataBind();
                ViewState["CurrentData"] = dt;
            }
            double excessamt = Convert.ToDouble(txt_excess_amt.Text);

            excessamt = excessamt - Convert.ToDouble(amt.ToString());

            txt_excess_amt.Text = excessamt.ToString("#,0.00");

        }

        protected void btn_short_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_excess_amt.Text.Trim().Length > 0)
                {

                    try
                    {
                        double temp = Convert.ToDouble(txt_excess_amt.Text);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(btn_cust_add, typeof(Button), "Payment", "alertify.alert('Invalid Amount');", true);
                        txt_excess_amt.Focus();
                        txt_excess_amt.Text = "";
                        return;
                    }


                    DataRow Dr;
                    DataTable dt_excess = new DataTable();
                    if (ViewState["GridAccount"] != null)
                    {
                        dt_excess = (DataTable)ViewState["GridAccount"];
                        Dr = dt_excess.NewRow();
                        dt_excess.Rows.Add(Dr);
                        double num = Convert.ToDouble(txt_excess_amt.Text);
                        int res = Convert.ToInt32(num);
                        if (res > 0)
                        {
                            Dr[0] = "Ex.Rate Gain";
                        }
                        else
                        {
                            Dr[0] = "Ex.Rate Loss";
                        }

                        Dr[1] = "";
                        Dr[2] = "";
                        Dr[3] = "";
                        //Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                        //Dr[3] = 0;

                        if (lbl_head.Text == "Payment")
                        {
                            Dr[3] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                        }
                        else
                        {
                            Dr[3] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                            txt_excess_amt.Text = Dr[3].ToString();
                        }
                        //Dr[3] = hid_chargeid.Value.ToString();
                    }
                    else
                    {
                        dt_excess.Columns.Add("Type");
                        dt_excess.Columns.Add("Customerortax");
                        dt_excess.Columns.Add("fc");
                        dt_excess.Columns.Add("Amount");
                        dt_excess.Columns.Add("cid");
                        Dr = dt_excess.NewRow();
                        dt_excess.Rows.Add(Dr);
                        double num = Convert.ToDouble(txt_excess_amt.Text);
                        int res = Convert.ToInt32(num);
                        if (res > 0)
                        {
                            Dr[0] = "Ex.Rate Gain";
                            hid.Value = Dr[0].ToString();
                        }
                        else
                        {
                            Dr[0] = "Ex.Rate Loss";
                            hid.Value = Dr[0].ToString();
                        }
                        Dr[1] = "";
                        Dr[2] = "";
                        Dr[3] = "";
                        //Dr[2] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                        //Dr[3] = 0;
                        if (lbl_head.Text == "Payment")
                        {
                            Dr[3] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                        }
                        else
                        {
                            Dr[3] = string.Format("{0:0.00}", Convert.ToDouble(txt_excess_amt.Text));
                            txt_excess_amt.Text = Dr[3].ToString();
                        }
                        //Dr[3] = ccid;

                    }


                    if (ViewState["CurrentData"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["CurrentData"];
                        int count = dt.Rows.Count;
                        BindGrid1(count, txt_excess_amt.Text.Trim().ToUpper(), txt_excess_amt.Text);
                    }
                    else
                    {
                        BindGrid1(1, txt_excess_amt.Text.Trim().ToUpper(), txt_excess_amt.Text);
                    }
                    //Grid_Account.DataSource = dt_excess;
                    //Grid_Account.DataBind();

                    //ViewState["CurrentData"] = dt_excess;
                    txt_excess_amt.Text = "";

                    double Total = 0;
                    for (int i = 0; i < Grid_Account.Rows.Count; i++)
                    {
                        Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                    }
                    txt_total1.Text = string.Format("{0:0.00}", Total);
                    //txt_amtrs.Text = txt_total.Text;
                    if (Session["rptype"] == "R")
                    {
                        lbl_amountinword.Text = "Rupees - " + Utility.Fn_AmountToWord(Total) + " Rupees Only";
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void BindGrid(int rowcount, string txttype, string cust, string amt, int cid)
        {
            double amount;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Customerortax", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("fc", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("cid", typeof(String)));

            if (ViewState["CurrentData"] != null && txt_deduction.Text != "")
            {
                dt = (DataTable)ViewState["CurrentData"];
                if (dt.Rows.Count > 0)
                {
                    //DataView dv = new DataView(dt);
                    //dv = "Type = '" + txttype.ToString().ToUpper().Trim() + "'";
                    dr = dt.NewRow();

                    dr[0] = "Charges";
                    dr[1] = cust;
                    amount = Convert.ToDouble(amt.ToString());
                    dr[2] = amount.ToString("#0.00");
                    if (txttdsAmt.Text != "")
                    {
                        dr[3] = txttdsAmt.Text;
                        // dr[3] = "-" + txttdsAmt.Text;
                    }
                    else
                    {
                        dr[3] = hid_total.Value;
                    }

                    dr[4] = cid.ToString();
                    dt.Rows.Add(dr);
                }
            }
            //else if (ViewState["CurrentData"] != null)
            //{
            //    dt = (DataTable)ViewState["CurrentData"];
            //    dr = dt.NewRow();
            //    dr[0] = "Customer";
            //    dr[1] = cust;
            //    amount = Convert.ToDouble(amt.ToString());
            //    dr[2] = amount.ToString("#0.00");
            //    dr[3] = hid_total.Value;
            //    dr[4] = cid.ToString();
            //    dt.Rows.Add(dr);
            //}
            //else
            //{

            //    dr = dt.NewRow();
            //    dr[0] = "Customer";
            //    dr[1] = cust;
            //    amount = Convert.ToDouble(amt.ToString());
            //    dr[2] = amount.ToString("#0.00");
            //    dr[3] = hid_total.Value;
            //    dr[4] = cid.ToString();
            //    dt.Rows.Add(dr);
            //}
            if (ViewState["CurrentData"] != null && txt_deduction.Text != "")
            {
                Grid_Account.DataSource = (DataTable)ViewState["CurrentData"];
                Grid_Account.DataBind();
                ViewState["CurrentData"] = dt;
            }
            //else  if (ViewState["CurrentData"] != null )
            //{
            //    Grid_Account.DataSource = (DataTable)ViewState["CurrentData"];
            //    Grid_Account.DataBind();
            //    ViewState["CurrentData"] = dt;
            //}
            //else
            //{
            //    Grid_Account.DataSource = dt;
            //    Grid_Account.DataBind();
            //    ViewState["CurrentData"] = dt;
            //}

            double excessamt = Convert.ToDouble(txt_excess_amt.Text);

            excessamt = excessamt - Convert.ToDouble(amt.ToString());

            txt_excess_amt.Text = excessamt.ToString("#,0.00");

        }

        private void BindGrid1(int rowcount, string txttype, string amt)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Customerortax", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("fc", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("cid", typeof(String)));

            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];

                    if (dt.Rows.Count > 0)
                    {
                        //DataView dv = new DataView(dt);
                        //dv = "Type = '" + txttype.ToString().ToUpper().Trim() + "'";
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                        dr[1] = dt.Rows[0][1].ToString();
                        dr[2] = dt.Rows[0][2].ToString();
                        dr[3] = dt.Rows[0][3].ToString();
                        dr[4] = dt.Rows[0][4].ToString();


                    }
                }


                dr = dt.NewRow();
                dr[0] = hid.Value;
                dr[1] = "";
                dr[2] = "";
                dr[3] = amt;
                dr[4] = hid_favour.Value;
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = hid.Value;
                dr[1] = "";
                dr[2] = "";
                dr[3] = amt;
                dr[4] = hid_favour.Value;
                dt.Rows.Add(dr);

            }

            Grid_Account.DataSource = dt;
            Grid_Account.DataBind();

            ViewState["CurrentData"] = dt;
            double excessamt = Convert.ToDouble(txt_excess_amt.Text);

            excessamt = excessamt - Convert.ToDouble(amt.ToString());

            txt_excess_amt.Text = excessamt.ToString("#,0.00");
        }

        protected void Grid_Account_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
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
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_Account, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void Grid_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Confirmdialog.Show();

            if (rptype == "P")
            {
                if (Grid_Account.Rows.Count > 0)
                {
                    int index;
                    index = Grid_Account.SelectedRow.RowIndex;
                    txt_cust_amt.Text = Grid_Account.Rows[index].Cells[2].Text;
                    txt_cust.Text = Grid_Account.Rows[index].Cells[1].Text;
                    btn_cust_add.Enabled = true;
                    txt_cust_amt.Enabled = true;
                }
            }

        }

        protected void imgdelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton lb = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                Session["Rowindex"] = rowID;
                if (hfWasConfirmed.Value == "true")
                {
                    if (ViewState["CurrentData"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["CurrentData"];
                        if (dt.Rows.Count > 0)
                        {
                            if (gvRow.RowIndex < dt.Rows.Count)
                            {

                                dt.Rows.Remove(dt.Rows[rowID]);
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted Successfully...');", true);
                                lbl_amountinword.Enabled = false;
                                Total = 0;
                                total = 0;
                                for (int i = 0; i < Grid_Account.Rows.Count - 1; i++)
                                {
                                    Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                                    total = total + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                                }

                                txt_total.Text = string.Format("{0:0.00}", Total);
                                txt_total1.Text = string.Format("{0:0.00}", total);
                                //txt_amt.Text = txt_total.Text;
                            }

                        }

                        ViewState["CurrentData"] = dt;
                        Grid_Account.DataSource = dt;
                        Grid_Account.DataBind();
                        if (Grid_Account.Rows.Count == 0)
                        {
                            Grid_Account.DataSource = Utility.Fn_GetEmptyDataTable();
                            Grid_Account.DataBind();
                            txt_total.Text = "";
                            //txt_amt.Text = "";
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

        protected void btn_back_Click(object sender, EventArgs e)
        {

            if (btn_back.ToolTip == "Cancel")
            {
                clear();
                txt_curr.Text = "";
                txt_rcvamt.Text = "";
                txt_exrate.Text = "";
                txt_amtrs.Text = "";
                txt_recp.Focus();
                ViewState["dtINV"] = null;
                ViewState["CurrentData"] = null;
                ViewState["GridData"] = null;
                btn_save1.Visible = true;
                btn_save.Visible = true;
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";

                if (Session["Loginyear"].ToString() == Session["Vouyear"].ToString())
                {

                }
                else
                {
                    btn_save1.Visible = false;
                    btn_save.Visible = false;
                }
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
        }

        private void clear()
        {
            txtsch.Text = "";
            cmbvoutype.SelectedIndex = 0;
            txt_dedu_amt.Text = "";
            ddl_branch.SelectedIndex = -1;
            txt_recp.Text = "";
            ddl_mode.Items.Clear();
            txt_recieve.Focus();
            txt_recieve.Text = "";
            txt_recieve.Text = "";
            //txt_amt.Text = "";
            txt_cheque.Text = "";
            txt_bank.Text = "";
            txt_branch1.Text = "";
            txt_narration.Text = "";
            txt_cust.Text = "";
            txt_cust_amt.Text = "";
            txt_deduction.Text = "";
            txt_dedu_amt.Text = "";
            txt_excess_amt.Text = "";
            // btn_cust_add.Enabled = false;
            // btn_deduct_add.Enabled = false;
            //btn_short_add.Enabled = false;
            if (Chk_accountpay.Checked == true) Chk_accountpay.Checked = false;
            txt_refno.Text = "";
            txt_total.Text = "";
            lbl_amountinword.Visible = false;
            Grid_Account.DataSource = Utility.Fn_GetEmptyDataTable();
            Grid_Account.DataBind();
            Grid_detail.DataSource = Utility.Fn_GetEmptyDataTable();
            Grid_detail.DataBind();
            btn_back.Text = "Back";
            btn_back.ToolTip = "Back";
            btn_back1.Attributes["class"] = "btn ico-back";
            //if (lbl_head.Text == "Remittance_Payment")
            //{
            btn_save.Enabled = true;
            ddl_mode.Items.Clear();
            //ddl_mode.Items.Add("MODE");
            // d//dl_mode.Items.Add("Cash");
            ddl_mode.Items.Add("Cheque/DD");
            //ddl_mode.Items.Add("Petty Cash");

            ddl_mode.SelectedValue = "Cheque/DD";

            txt_total1.Text = "";
            txt_cheqdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            if (chkrpt.Checked == true)
            {
                chkrpt.Checked = false;
            }

            //}
            //else
            //{
            //    ddl_mode.Items.Add("MODE");
            //    ddl_mode.Items.Add("Cash");
            //    rptype = "P";
            //    Grid_detail.Columns[4].HeaderText = "Pymt-Amt";
            //    //Grid_detail.Columns[4].HeaderText = "Account Details";
            //    branchpay = "B";  
            //}
        }

        //protected void txt_receiptamount_TextChanged(object sender, EventArgs e)
        //{
        //    rw = Grid_Account.SelectedRow.RowIndex;
        //    rowVouType = Grid_Account.Rows[rw].Cells[5].ToString();  
        //}

        protected void txt_recp_TextChanged(object sender, EventArgs e)
        {
            if (ddl_mode.SelectedItem.Text != "")
            {
                ddl_mode_change();
                btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
            }
        }

        protected void Grid_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_detail, "TxtClick$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txt_receiptamount_TextChanged(object sender, EventArgs e)
        {

            //GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            //TextBox txt1fcs = (TextBox)currentRow.FindControl("txt_receiptamount"); 

            GridViewRow myRow = ((Control)sender).Parent.Parent as GridViewRow;


            if (txt_exrate.Text == "")
            {
                txt_exrate.Text = "0.00";
            }

            if (txt_amtrs.Text == "")
            {
                txt_amtrs.Text = "0.00";
            }
            // TextBox txtbox = sender as TextBox;
            //if()
            //{

            //}
            // GridViewRow row1  = txtbox.NamingContainer as GridViewRow;

            // int index1 = row1.RowIndex;
            // hid_gridname.Value = index1.ToString();
            //  double amt = 0;
            if (Grid_detail.Rows.Count > 0)
            {


                for (int i = 0; i < Grid_detail.Rows.Count; i++)
                {


                    GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
                    TextBox txt = (TextBox)row.FindControl("txt_receiptamount");
                    if (txt.Text != "0.00")
                    {
                        int rowindex = 0;
                        rowindex = row.RowIndex;
                        hid_gridname.Value = rowindex.ToString();
                    }

                }

            }


            //    //Int32 count = Convert.ToInt32(txt.Text);
            //    //txt.Text = Convert.ToString(count);
            //    for (int i = 0; i < Grid_detail.Rows.Count; i++)
            //    {
            //        int rowindex = 0;
            //        rowindex = row.RowIndex;
            //        TextBox txt = (TextBox)Grid_detail.Rows[i].Cells[4].FindControl("txt_receiptamount");
            //        //Int32 count = Convert.ToInt32(txt.Text);
            //        //txt.Text = Convert.ToString(count);

            //        amt = amt + Convert.ToDouble(txt.Text);
            //        txt_cust_amt.Text = Convert.ToString(amt);
            //    }

            //    //TextBox txt = (TextBox)row.FindControl("txt_receiptamount");
            //    //TextBox myTextBox = (TextBox)Row[1].ce.FindControl("txt_receiptamount"));
            //}

            //Grid_detail_SelectedIndexChanged(sender, e);
            double grd_amt;
            int RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            hid_gridname.Value = RowIndex.ToString();
            int index = Convert.ToInt32(hid_gridname.Value);
            TextBox txt123 = ((TextBox)Grid_detail.Rows[index].FindControl("txt_receiptamount"));
            string value1 = txt123.Text.TrimStart().TrimEnd().Trim();
            if (value1 != "")
            {
                if (double.TryParse(value1, out grd_amt))
                {
                    string number = Grid_detail.Rows[index].Cells[4].Text;
                    if (Grid_detail.Rows[index].Cells[2].Text != "On Account")
                    {

                        if (Convert.ToDouble(number) < Convert.ToDouble(value1))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt/Payment Amount Must be Less Than or Equal to Voucher Amount');", true);
                            ((TextBox)Grid_detail.Rows[index].Cells[7].FindControl("txt_receiptamount")).Text = "0.00";
                        }
                    }
                }
            }

            for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
            {
                if (Grid_detail.Rows[i].Cells[2].Text == "On Account")
                {
                    Grid_detail.Rows[i].Cells[3].Text = txt_curr.Text;
                    Grid_detail.Rows[i].Cells[5].Text = txt_exrate.Text;

                }

                TextBox txtvale = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                if (txtvale.Text == "")
                {
                    txtvale.Text = "0.00";
                }


            }



            if (Session["rptype"] == "P")
            {
                //int index;
                //string rowVouType;

                //foreach (GridViewRow row in Grid_detail.Rows)
                //{

                //    rowVouType = Grid_detail.Rows[0].Cells[9].Text;
                //}
                //int count;
                //double inc = 0;
                //double exp = 0;
                //double exr = 0;
                //double Double = 0;
                //double fcamount = 0;
                //double incfcamount = 0;
                //double expfcamount = 0;
                //string IE = "";

                //foreach (GridViewRow row in Grid_detail.Rows)
                //{

                //    // TextBox txt = (TextBox)row.FindControl("txt_receiptamount"); ;
                //    // exr =Convert.ToDouble (txt);
                //    exr = Convert.ToDouble(row.Cells[5].Text);
                //    TextBox txt = ((TextBox)row.FindControl("txt_receiptamount"));
                //    fcamount = Convert.ToDouble(txt);
                //    IE = row.Cells[9].Text;
                //    grdinramt = exr * fcamount;
                //    row.Cells[9].Text = grdinramt.ToString();
                //    if (IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "O")
                //    {
                //        int val = Convert.ToInt32(row.Cells[8].Text);
                //        int value = Convert.ToInt32(txt);
                //        inc = Convert.ToDouble(inc) + Convert.ToDouble(val.ToString("#0.00"));
                //        incfcamount = incfcamount + Convert.ToDouble(value);
                //    }
                //    else if (IE == "P" || IE == "C" || IE == "E" || IE == "S")
                //    {
                //        int amt = Convert.ToInt32(Grid_detail.Rows[i].Cells[8].Text);
                //        int num = Convert.ToInt32(txt);
                //        exp = Convert.ToDouble(amt) + Convert.ToDouble(amt.ToString("#0.00"));
                //        expfcamount = expfcamount + Convert.ToDouble(num);
                //    }

                //}
                //int res = Convert.ToInt32(expfcamount);
                //int result = Convert.ToInt32(incfcamount);
                //int result1, result2;
                //int total = res - result;
                //txt_cust_amt.Text = total.ToString("#0.00");
                //result1 = Convert.ToInt32(exp);
                //result2 = Convert.ToInt32(inc);
                //int totalnum = result1 - result2;
                //totinramount = Convert.ToDouble(totalnum.ToString("#0.00"));
                //int finaltotal = Convert.ToInt32(totinramount);
                //hid_total.Value = finaltotal.ToString();
                index = Convert.ToInt32(hid_gridname.Value);
                hid_customeridNew.Value = Grid_detail.Rows[index].Cells[14].Text;
                string rowVouType;
                //TextBox recp_amt=(TextBox)Grid_detail
                //    foreach (GridViewRow row in Grid_detail.Rows)
                // {
                //    txt_receiptamount.Text = txt_receiptamount.Text;
                rowVouType = Grid_detail.Rows[index].Cells[9].Text;
                // }
                double numvale;
                int count;
                double inc = 0;
                double exp = 0;
                double exr = 0;
                double Double = 0;
                double fcamount = 0;
                double incfcamount = 0;
                double expfcamount = 0;
                string IE = "";
                RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
                //foreach (GridViewRow row in Grid_detail.Rows)
                //{
                //TextBox txt = ((TextBox)row.FindControl("txt_receiptamount"));


                exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                TextBox txt = ((TextBox)Grid_detail.Rows[index].FindControl("txt_receiptamount"));
                fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                grdinramt = exr * fcamount;
                Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");
                //  dataNewTable = (DataTable)ViewState["dtINV"];
                //Ruban
                if (ViewState["dtINV"] != null && !ViewState["dtINV"].Equals("-1"))
                {
                    dataNewTable = (DataTable)ViewState["dtINV"];
                    if (dataNewTable.Rows.Count > 0)
                    {
                        for (int j = 0; j <= dataNewTable.Rows.Count - 1; j++)
                        {
                            TextBox txtvale = ((TextBox)Grid_detail.Rows[j].FindControl("txt_receiptamount"));
                            if (txtvale.Text != "" && txtvale.Text != "0.00")
                            {
                                dataNewTable.Rows[j]["recptfcamt"] = txtvale.Text.TrimStart().TrimEnd().Trim();
                                dataNewTable.Rows[j]["tamount"] = Grid_detail.Rows[j].Cells[8].Text;
                                // dataNewTable.Rows[j]["tamount"] = grdinramt.ToString("#0.00");
                            }
                        }
                    }
                    ViewState["dtINV"] = dataNewTable;
                }
                for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                {
                    IE = Grid_detail.Rows[i].Cells[9].Text;
                    if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "F" || IE == "H" || IE == "OF" || IE == "OH") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                    {
                        double val = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                        //  int val1 = Convert.ToInt32(val);
                        TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                        double value = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                        // int value1 = Convert.ToInt32(value);
                        inc = inc + val;
                        incfcamount = incfcamount + value;
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "O" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS" || IE == "G" || IE == "OG") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                    {
                        double amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                        //  int amt1 = Convert.ToInt32(amt);
                        TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                        double num = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                        // int num1 = Convert.ToInt32(num);
                        //double num = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                        //int num1 = Convert.ToInt32(num);
                        exp = exp + amt;
                        expfcamount = expfcamount + num;
                    }

                    if (Session["rptype"] == "P")
                    {
                        if ((IE == "U" || IE == "T") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                        {
                            if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                            {
                                double val = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                //  int val1 = Convert.ToInt32(val);
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                double value = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                // int value1 = Convert.ToInt32(value);
                                inc = inc + val;
                                incfcamount = incfcamount + value;
                            }
                            else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                            {
                                double amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                //  int amt1 = Convert.ToInt32(amt);
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                double num = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                // int num1 = Convert.ToInt32(num);
                                //double num = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                                //int num1 = Convert.ToInt32(num);
                                exp = exp + amt;
                                expfcamount = expfcamount + num;
                            }
                        }
                    }

                    // For Journal
                    if (Session["rptype"].ToString() == "R")
                    {
                        if (IE == "J")
                        {
                            if ((Grid_detail.Rows[i].Cells[13].Text == "Dr") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                            {
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt1.Text == "")
                                {
                                    txt.Text = "0.00";
                                }
                                //inc = inc + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                double val = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                double value = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                inc = inc + val;
                                incfcamount = incfcamount + value;
                            }
                            if ((Grid_detail.Rows[i].Cells[13].Text == "Cr") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                            {
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt1.Text == "")
                                {
                                    txt1.Text = "0.00";
                                }
                                //exp = exp + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                double amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                double num = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                exp = exp + amt;
                                expfcamount = expfcamount + num;
                            }
                        }
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        if (IE == "J")
                        {
                            if ((Grid_detail.Rows[i].Cells[13].Text == "Dr") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                            {
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt1.Text == "")
                                {
                                    txt1.Text = "0.00";
                                }
                                //inc = inc + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                double val = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                double value = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                inc = inc + val;
                                incfcamount = incfcamount + value;
                            }
                            else if ((Grid_detail.Rows[i].Cells[13].Text == "Cr") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                            {
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                                if (txt1.Text == "")
                                {
                                    txt1.Text = "0.00";
                                }
                                //exp = exp + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                double amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                double num = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                exp = exp + amt;
                                expfcamount = expfcamount + num;
                            }
                        }
                    }

                }


                //}
                //int res = Convert.ToInt32(expfcamount);
                //int result = Convert.ToInt32(incfcamount);
                //int result1, result2;
                //int total = res - result;
                //for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)               //NEW
                //{
                //    if (Grid_detail.Rows[i].Cells[2].Text == "On Account")
                //    {
                txt_cust_amt.Text = (expfcamount - incfcamount).ToString("#0.00");
                //    }                   
                //}

                btn_cust_add.Focus();
                //result1 = Convert.ToInt32(exp);
                //result2 = Convert.ToInt32(inc);
                //int totalnum = result1 - result2;
                //  totinramount = Convert.ToDouble(totalnum.ToString());
                //int finaltotal = Convert.ToInt32(totinramount);
                hid_total.Value = (exp - inc).ToString("#0.00");
                btn_cust_add.Focus();


            }
            else if (Session["rptype"] == "R")
            {
                //hid_tot2.Value = Grid_Account.Rows[i].Cells[4].Text;
                //int index;
                //string rowVouType;
                index = Convert.ToInt32(hid_gridname.Value);
                string rowVouType;
                hid_customeridNew.Value = Grid_detail.Rows[index].Cells[14].Text;
                //TextBox recp_amt=(TextBox)Grid_detail
                //    foreach (GridViewRow row in Grid_detail.Rows)
                // {
                //    txt_receiptamount.Text = txt_receiptamount.Text;
                rowVouType = Grid_detail.Rows[index].Cells[9].Text;
                // }
                double numvale;
                int count;
                double inc = 0;
                double exp = 0;
                double exr = 0;
                double Double = 0;
                double fcamount = 0;
                double incfcamount = 0;
                double expfcamount = 0;
                string IE = "";
                RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
                //foreach (GridViewRow row in Grid_detail.Rows)
                //{
                //TextBox txt = ((TextBox)row.FindControl("txt_receiptamount"));
                hid_tot1.Value = Grid_detail.Rows[index].Cells[14].Text;
                //hid_total.Value = Grid_detail.Rows[index].Cells[8].Text;
                //hid_tot2.Value = Grid_Account.Rows[i].Cells[4].Text

                exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                TextBox txt = ((TextBox)Grid_detail.Rows[index].FindControl("txt_receiptamount"));
                fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                grdinramt = exr * fcamount;
                Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");
                dataNewTable = (DataTable)ViewState["dtINV"];
                if (dataNewTable.Rows.Count > 0)
                {
                    for (int j = 0; j <= dataNewTable.Rows.Count - 1; j++)
                    {
                        TextBox txtvale = ((TextBox)Grid_detail.Rows[j].FindControl("txt_receiptamount"));
                        if (txtvale.Text != "" && txtvale.Text != "0.00")
                        {
                            dataNewTable.Rows[j]["recptfcamt"] = txtvale.Text;
                            dataNewTable.Rows[j]["tamount"] = grdinramt.ToString("#0.00");
                        }
                    }
                }
                ViewState["dtINV"] = dataNewTable;
                for (i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                {
                    IE = Grid_detail.Rows[i].Cells[9].Text;
                    if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "O" || IE == "F" || IE == "H" || IE == "OF" || IE == "OH") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                    {
                        double val = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                        // int val1 = Convert.ToInt32(val);
                        TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                        double value = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                        //int value1 = Convert.ToInt32(value);
                        inc = inc + val;
                        incfcamount = incfcamount + value;
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "G" || IE == "OG") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                    {
                        double amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                        // int amt1 = Convert.ToInt32(amt);
                        TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));

                        double num = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                        //int num1 = Convert.ToInt32(num);
                        //double num = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                        //int num1 = Convert.ToInt32(num);
                        exp = exp + amt;
                        expfcamount = expfcamount + num;
                    }


                    if (Session["rptype"] == "R")
                    {
                        if ((IE == "U" || IE == "T") && (hid_customeridNew.Value == Grid_detail.Rows[i].Cells[14].Text))
                        {
                            if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                            {
                                double val = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                // int val1 = Convert.ToInt32(val);
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                double value = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                //int value1 = Convert.ToInt32(value);
                                inc = inc + val;
                                incfcamount = incfcamount + (value);
                            }
                            else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                            {
                                double amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                // int amt1 = Convert.ToInt32(amt);
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                double num = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                //int num1 = Convert.ToInt32(num);
                                //double num = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                                //int num1 = Convert.ToInt32(num);
                                exp = exp + amt;
                                expfcamount = expfcamount + num;
                            }
                        }
                    }
                }

                //}
                //int res = Convert.ToInt32(expfcamount);
                //int result = Convert.ToInt32(incfcamount);
                //int result1, result2;
                //int total = result - res;
                txt_cust_amt.Text = (incfcamount - expfcamount).ToString("#0.00");

                //result1 = Convert.ToInt32(exp);
                //result2 = Convert.ToInt32(inc);
                //int totalnum = result2 - result1;
                //totinramount = Convert.ToDouble(totalnum.ToString());
                //int finaltotal = Convert.ToInt32(totinramount);
                hid_total.Value = (inc - exp).ToString("#0.00");
                if (txt_cust.Text == "")
                {
                    if (ViewState["CurrentData"] != null)
                    {
                        double Fc = 0;
                        DataTable dt = (DataTable)ViewState["CurrentData"];
                        hid_tot1.Value = Grid_detail.Rows[index].Cells[14].Text;
                        for (i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                        {
                            hid_tot2.Value = Grid_Account.Rows[i].Cells[4].Text;
                            if (hid_tot1.Value == hid_tot2.Value)
                            {
                                hid_total.Value = Grid_detail.Rows[index].Cells[8].Text;
                                // txt_cust.Text = Grid_Account.Rows[index].Cells[1].Text;

                                dt.Rows[i][3] = hid_total.Value;
                                dt.Rows[i][2] = txt_cust_amt.Text;
                            }
                        }
                        Grid_Account.DataSource = dt;
                        Grid_Account.DataBind();
                        ViewState["CurrentData"] = dt;
                        txt_cust_amt.Text = "";
                    }

                }


                btn_cust_add.Focus();
            }

            gainlosscalc();

            if (Grid_Account.Rows.Count > 0)
            {
                Total = 0;
                for (int i = 0; i < Grid_Account.Rows.Count; i++)
                {
                    if (Grid_Account.Rows[i].Cells[2].Text != "&nbsp;" && Grid_Account.Rows[i].Cells[2].Text != "")
                    {
                        Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);

                    }

                }
                txt_total.Text = string.Format("{0:0.00}", Total);


                Total = 0;
                for (int i = 0; i < Grid_Account.Rows.Count; i++)
                {
                    if (Grid_Account.Rows[i].Cells[3].Text != "&nbsp;")
                    {
                        Total = Total + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                    }
                }
                txt_total1.Text = string.Format("{0:0.00}", Total);
            }

            //txt1fcs.Focus(); 
            myRow.FindControl("txt_receiptamount").Focus();

            int txt_rowindex = 0;
            //foreach (GridViewRow row in Grid_detail.Rows)
            //{
            //    TextBox txt = (TextBox)row.FindControl("txt_receiptamount");

            //    if (txt.Text != "")
            //    {
            //        txt_rowindex = row.RowIndex;
            //        calculation(txt_rowindex);
            //        Grid_detail.Rows[row.RowIndex].BackColor = System.Drawing.Color.Empty;
            //    }
            //}

        }



        protected void gainlosscalc()
        {
            if (Session["rptype"] == "P")
            {


                double incgl = 0;
                double expgl = 0;
                string IEgl = "";

                //for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                //{
                foreach (GridViewRow row in Grid_detail.Rows)
                {
                    CheckBox Chk = (CheckBox)Grid_detail.Rows[row.RowIndex].FindControl("Chkrecpfc");
                    TextBox txt = (TextBox)row.FindControl("txt_receiptamount");
                    if (Chk.Checked == true || txt.Text != "")
                    {
                        IEgl = Grid_detail.Rows[row.RowIndex].Cells[9].Text.Trim();
                        if (IEgl == "I" || IEgl == "D" || IEgl == "V" || IEgl == "X" || IEgl == "OD" || IEgl == "OI" || IEgl == "OD" || IEgl == "OV" || IEgl == "OX" || IEgl == "F" || IEgl == "H" || IEgl == "OF" || IEgl == "OH")
                        {
                            double val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                            //int val1 = Convert.ToInt32(val);
                            incgl = incgl + val;
                        }
                        else if (IEgl == "P" || IEgl == "C" || IEgl == "E" || IEgl == "S" || IEgl == "OP" || IEgl == "O" || IEgl == "OP" || IEgl == "OC" || IEgl == "OE" || IEgl == "OS" || IEgl == "G" || IEgl == "OG")
                        {
                            double valu = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                            // int valu1 = Convert.ToInt32(valu);
                            expgl = expgl + valu;
                        }

                        if (IEgl == "U" || IEgl == "T")
                        {
                            if (Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Dr")
                            {
                                double val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                // int val1 = Convert.ToInt32(val);
                                incgl = incgl + val;
                            }
                            else if (Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Cr")
                            {
                                double valu = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                // int valu1 = Convert.ToInt32(valu);
                                expgl = expgl + valu;
                            }
                        }
                    }
                }
                // }
                double finaltot = Convert.ToDouble(expgl) - Convert.ToDouble(incgl);
                glamt = Convert.ToDouble(finaltot.ToString("#0.00"));
            }
            else if (Session["rptype"] == "R")
            {
                double incgl = 0;
                double expgl = 0;
                string IEgl = "";

                //for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                //{
                foreach (GridViewRow row in Grid_detail.Rows)
                {
                    CheckBox Chk = (CheckBox)Grid_detail.Rows[row.RowIndex].FindControl("Chkrecpfc");
                    TextBox txt = (TextBox)row.FindControl("txt_receiptamount");
                    if (Chk.Checked == true || txt.Text != "")
                    {
                        IEgl = Grid_detail.Rows[row.RowIndex].Cells[9].Text.Trim();
                        if (IEgl == "I" || IEgl == "D" || IEgl == "V" || IEgl == "X" || IEgl == "O" || IEgl == "OD" || IEgl == "OI" || IEgl == "OD" || IEgl == "OV" || IEgl == "OX" || IEgl == "F" || IEgl == "H" || IEgl == "OF" || IEgl == "OH")
                        {
                            double val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                            // int val1 = Convert.ToInt32(val);
                            incgl = incgl + val;
                        }
                        else if (IEgl == "P" || IEgl == "C" || IEgl == "E" || IEgl == "S" || IEgl == "OP" || IEgl == "OP" || IEgl == "OC" || IEgl == "OE" || IEgl == "OS" || IEgl == "G" || IEgl == "OG")
                        {
                            double valu = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                            //  int valu1 = Convert.ToInt32(valu);
                            expgl = expgl + valu;
                        }

                        if (IEgl == "U" || IEgl == "T")
                        {
                            if (Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Dr")
                            {
                                double val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                // int val1 = Convert.ToInt32(val);
                                incgl = incgl + val;
                            }
                            else if (Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Cr")
                            {
                                double valu = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                // int valu1 = Convert.ToInt32(valu);
                                expgl = expgl + valu;
                            }
                        }
                    }
                }
                double finaltot = Convert.ToDouble(incgl) - Convert.ToDouble(expgl);
                glamt = Convert.ToDouble(finaltot.ToString("#0.00"));
                //hid_glaft.Value = glamt.ToString();
                btn_cust_add.Focus();
                //  dataNewTable = (DataTable) Grid_detail;
            }
            hid_glaft.Value = glamt.ToString();
            if (Convert.ToDouble(txt_amtrs.Text) > glamt)
            {
                Es = Convert.ToDouble(txt_amtrs.Text) - glamt;
                txt_excess_amt.Text = Es.ToString("#0.00");
            }
            else if (Convert.ToDouble(txt_amtrs.Text) < glamt)
            {
                Es = glamt - Convert.ToDouble(txt_amtrs.Text);
                txt_excess_amt.Text = (-Es).ToString("#0.00");
            }
            else if (Convert.ToDouble(txt_amtrs.Text) == glamt)
            {
                txt_excess_amt.Text = "0.00";
            }
        }





        protected void fun_save()
        {

            double grdTotamt = 0;
            double incTotamt = 0;
            double expTotamt = 0;
            double CustAmt = 0;
            try
            {
                DataTable dt_cust = new DataTable();
                DataTable dt_charge = new DataTable();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                string FADbname = Session["FADbname"].ToString();
                mode_set();
                CheckData();

                if (blner == true)
                {
                    return;
                }
                if (next == 0)
                {
                    return;
                }

                for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                {

                    TextBox txtvale = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                    if (txtvale.Text == "")
                    {
                        txtvale.Text = "0.00";
                    }
                }

                if (btn_save.ToolTip == "Save")
                {
                    txt_total1.Text = txt_total1.Text.Replace(",", "");
                    if (txt_amtrs.Text == txt_total1.Text)
                    {
                        GetYear();

                        for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                        {

                            if (Session["rptype"].ToString() == "R")
                            {
                                IE = Grid_detail.Rows[i].Cells[9].Text;

                                if (IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "O" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "F" || IE == "H" || IE == "OF" || IE == "OH")
                                {
                                    // incTotamt = Format(comamt(incTotamt) + grdINVRec.Rows(i).Cells(8).Value, "0..00")
                                    double temp = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                    string temp1 = temp.ToString("#0.00");
                                    incTotamt = (incTotamt) + Convert.ToDouble(temp1.ToString());
                                }
                                else if (IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS" || IE == "G" || IE == "OG")
                                {
                                    double temp2 = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                    string temp3 = temp2.ToString("#0.00");
                                    expTotamt = (expTotamt) + Convert.ToDouble(temp3.ToString());
                                }

                                else if (IE == "U" || IE == "T")
                                {
                                    string value = Grid_detail.Rows[i].Cells[13].Text;
                                    if (value == "Dr")
                                    {
                                        double temp = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                        string temp1 = temp.ToString("#0.00");
                                        incTotamt = (incTotamt) + Convert.ToDouble(temp1.ToString());
                                    }
                                    else if (value == "Cr")
                                    {
                                        double temp2 = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                        string temp3 = temp2.ToString("#0.00");
                                        expTotamt = (expTotamt) + Convert.ToDouble(temp3.ToString());
                                    }
                                }

                            }
                            else if (Session["rptype"].ToString() == "P")
                            {
                                IE = Grid_detail.Rows[i].Cells[9].Text;
                                if (IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "F" || IE == "H" || IE == "OF" || IE == "OH")
                                {
                                    // incTotamt = Format(comamt(incTotamt) + grdINVRec.Rows(i).Cells(8).Value, "0..00")
                                    double temp = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                    string temp1 = temp.ToString("#0.00");
                                    incTotamt = (incTotamt) + Convert.ToDouble(temp1.ToString());
                                }
                                else if (IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "O" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS" || IE == "G" || IE == "OG")
                                {
                                    double temp2 = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                    string temp3 = temp2.ToString("#0.00");
                                    expTotamt = (expTotamt) + Convert.ToDouble(temp3.ToString());
                                }

                                else if (IE == "U" || IE == "T")
                                {
                                    string value = Grid_detail.Rows[i].Cells[13].Text;
                                    if (value == "Dr")
                                    {
                                        double temp = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                        string temp1 = temp.ToString("#0.00");
                                        incTotamt = (incTotamt) + Convert.ToDouble(temp1.ToString());
                                    }
                                    else if (value == "Cr")
                                    {
                                        double temp2 = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                        string temp3 = temp2.ToString("#0.00");
                                        expTotamt = (expTotamt) + Convert.ToDouble(temp3.ToString());
                                    }
                                }

                            }


                            //for journal vino
                            if (Session["rptype"].ToString() == "R")
                            {
                                if (IE == "J")
                                {
                                    if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                                    {
                                        double temp = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                        string temp1 = temp.ToString("#0.00");
                                        incTotamt = (incTotamt) + Convert.ToDouble(temp1.ToString());
                                    }
                                    else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                                    {
                                        double temp2 = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                        string temp3 = temp2.ToString("#0.00");
                                        expTotamt = (expTotamt) + Convert.ToDouble(temp3.ToString());
                                    }
                                }
                            }
                            else if (Session["rptype"].ToString() == "P")
                            {
                                if (IE == "J")
                                {
                                    if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                                    {
                                        double temp = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                        string temp1 = temp.ToString("#0.00");
                                        incTotamt = (incTotamt) + Convert.ToDouble(temp1.ToString());
                                    }
                                    else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                                    {
                                        double temp2 = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                                        string temp3 = temp2.ToString("#0.00");
                                        expTotamt = (expTotamt) + Convert.ToDouble(temp3.ToString());
                                    }
                                }
                            }


                        }


                        if (Session["rptype"].ToString() == "R")
                        {
                            grdTotamt = incTotamt - expTotamt;
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            grdTotamt = expTotamt - incTotamt;
                        }


                        for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                        {
                            if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                            {
                                CustAmt = CustAmt + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                                CustAmt = Convert.ToDouble(CustAmt.ToString("#0.00"));
                                //double tempa = Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                                //string tempa1 = tempa.ToString();
                                //expTotamt = (expTotamt) + Convert.ToDouble(tempa1.ToString());
                            }
                        }

                        string res = grdTotamt.ToString("#0.00");
                        grdTotamt = Convert.ToDouble(res.ToString());
                        string outp = expTotamt.ToString("#0.00");
                        expTotamt = Convert.ToDouble(outp.ToString());

                        //if (expTotamt != grdTotamt)
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount...');", true);
                        //    return;
                        //}


                        // hide by nambi
                        //if (Session["rptype"] == "P")
                        //{
                        //    if (txt_refno.Text == "")
                        //    {
                        //        this.popup_ref.Show();

                        //        return;

                        //    }
                        //}

                        //if (Session["rptype"] == "R")
                        //{
                        if (Session["rptype"].ToString() == "P" && Grid_Account.Rows.Count == 0 && bolCust == true)
                        {

                        }
                        else
                        {
                            if (txt_refno.Text.Trim() == "")
                            {
                                if (CustAmt != grdTotamt)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                                    return;
                                }
                            }
                            else
                            {
                                if (grdTotamt > 0)
                                {
                                    if (CustAmt != grdTotamt)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                                        return;
                                    }
                                }
                            }
                        }

                        //FOr Multiple Currency///


                        int count = 0;


                        if (txt_curr.Text.Trim() != "" && Grid_detail.Rows.Count > 0)
                        {
                            for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                            {
                                TextBox Rec_Amount = (TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount");

                                if (txt_curr.Text == Grid_detail.Rows[i].Cells[3].Text && Rec_Amount.Text != "0.00" && Rec_Amount.Text != "")
                                {
                                    count = count + 1;
                                }

                            }
                        }

                        double Tot = 0;
                        Tot = Convert.ToDouble(txt_total.Text);
                        int num = Convert.ToInt32(Tot);
                        if (count == Grid_detail.Rows.Count)
                        {
                            if (Convert.ToDouble(txt_rcvamt.Text) != Tot)
                            {
                                if (Session["rptype"].ToString() == "R")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt Amount does not Match with Total Dollar  Amount...');", true);
                                    return;
                                }
                                else if (Session["rptype"].ToString() == "p")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Payment Amount does not Match with Total Dollar Amount...');", true);
                                    return;
                                }
                            }


                            string IEO;
                            ACPayee = Convert.ToChar("C");
                            double oincTotamt = 0;
                            double oexpTotamt = 0;
                            double ogrdTotamt = 0;
                            double fcurramt = 0;

                            for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                            {
                                TextBox Rec_Amount = (TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount");
                                if (Rec_Amount.Text == "")
                                {
                                    Rec_Amount.Text = "0.00";
                                }

                                if (Session["rptype"].ToString() == "R")
                                {
                                    IEO = Grid_detail.Rows[i].Cells[9].Text;
                                    if (IEO == "I" || IEO == "D" || IEO == "V" || IEO == "X" || IEO == "O" || IEO == "OI" || IEO == "OD" || IEO == "OV" || IEO == "OX" || IEO == "F" || IEO == "H" || IEO == "OF" || IEO == "OH")
                                    {
                                        TextBox txt1 = (TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount");
                                        double temparary = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        //double temparary = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                                        // string temparary1 = temparary.ToString("#0.00");
                                        oincTotamt = oincTotamt + temparary;
                                    }
                                    else if (IEO == "P" || IEO == "C" || IEO == "E" || IEO == "S" || IEO == "OP" || IEO == "OC" || IEO == "OE" || IEO == "OS" || IEO == "G" || IEO == "OG")
                                    {
                                        TextBox txt1 = (TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"); 
                                        double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        oexpTotamt = oexpTotamt + temparary1;
                                    }

                                    else if (IEO == "U" || IEO == "T")
                                    {
                                        if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                                        {
                                            TextBox txt1 = (TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount");
                                            double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            oincTotamt = oincTotamt + temparary1;
                                        }
                                        else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                                        {
                                            TextBox txt1 = (TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"); 
                                            double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            oexpTotamt = oexpTotamt + temparary1;
                                        }
                                    }
                                }
                                else if (Session["rptype"].ToString() == "P")
                                {
                                    IEO = Grid_detail.Rows[i].Cells[9].Text;
                                    if (IEO == "I" || IEO == "D" || IEO == "V" || IEO == "X" || IEO == "OI" || IEO == "OD" || IEO == "OV" || IEO == "OX")
                                    {
                                        TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                        double temparary = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        //double temparary = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                                        // string temparary1 = temparary.ToString("#0.00");
                                        oincTotamt = oincTotamt + temparary;
                                    }
                                    else if (IEO == "P" || IEO == "C" || IEO == "E" || IEO == "S" || IEO == "O" || IEO == "OP" || IEO == "OC" || IEO == "OE" || IEO == "OS")
                                    {
                                        TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                        double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        oexpTotamt = oexpTotamt + temparary1;
                                    }

                                    else if (IEO == "U" || IEO == "T")
                                    {
                                        if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                                        {
                                            TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                            double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            oincTotamt = oincTotamt + temparary1;
                                        }
                                        else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                                        {
                                            TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                            double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            oexpTotamt = oexpTotamt + temparary1;
                                        }
                                    }

                                }


                                //for journal vino
                                if (Session["rptype"].ToString() == "R")
                                {
                                    IEO = Grid_detail.Rows[i].Cells[9].Text;
                                    if (IEO == "J")
                                    {
                                        if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                                        {
                                            TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                            double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            oincTotamt = oincTotamt + temparary1;
                                        }
                                        else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                                        {
                                            TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                            double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            oexpTotamt = oexpTotamt + temparary1;
                                        }
                                        //if (Grid_detail.Rows[i].Cells[9].Text == "Dr")
                                        //{
                                        //    oincTotamt = Convert.ToDouble(oincTotamt + Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim()));
                                        //}
                                        //else if (Grid_detail.Rows[i].Cells[9].Text == "Cr")
                                        //{
                                        //    oexpTotamt = Convert.ToDouble(oexpTotamt + Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim()));
                                        //}
                                    }
                                }
                                else if (Session["rptype"].ToString() == "P")
                                {
                                    IEO = Grid_detail.Rows[i].Cells[9].Text;
                                    if (IEO == "J")
                                    {
                                        if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                                        {
                                            TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                            double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            oincTotamt = oincTotamt + temparary1;
                                        }
                                        else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                                        {
                                            TextBox txt1 = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount")); ;
                                            double temparary1 = Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            oexpTotamt = oexpTotamt + temparary1;
                                        }
                                        //if (Grid_detail.Rows[i].Cells[9].Text == "Dr")
                                        //{
                                        //    oincTotamt = Convert.ToDouble(oincTotamt + Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim()));
                                        //}
                                        //else if (Grid_detail.Rows[i].Cells[9].Text == "Cr")
                                        //{
                                        //    oexpTotamt = Convert.ToDouble(oexpTotamt + Convert.ToDouble(Rec_Amount.Text.TrimStart().TrimEnd().Trim()));
                                        //}
                                    }
                                }



                            }


                            if (Session["rptype"].ToString() == "R")
                            {
                                ogrdTotamt = oincTotamt - oexpTotamt;
                            }
                            else if (Session["rptype"].ToString() == "P")
                            {
                                ogrdTotamt = oexpTotamt - oincTotamt;
                            }

                            string resl = ogrdTotamt.ToString("#0.00");
                            ogrdTotamt = Convert.ToDouble(resl.ToString());
                            double outp1 = Convert.ToDouble(txt_rcvamt.Text);

                            fcurramt = outp1;
                            //ogrdTotamt = Convert.ToDouble(resl1.ToString());

                            for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                            {
                                if (Grid_Account.Rows[i].Cells[0].Text == "Charges")
                                {
                                    double dou;
                                    if (Grid_Account.Rows[i].Cells[2].Text == "")
                                    {
                                        dou = 0;
                                    }
                                    else
                                    {
                                        dou = Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                                    }
                                    // double dou = Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                                    // int dou1 = Convert.ToInt32(dou.ToString("#0.00"));
                                    chrgamt = chrgamt + dou;
                                }
                            }
                            if (chrgamt < 0)
                            {
                                ogrdTotamt = ogrdTotamt + chrgamt;
                            }
                            else
                            {
                                ogrdTotamt = ogrdTotamt + chrgamt;
                            }

                            string tchamt = ogrdTotamt.ToString("#0.00");
                            ogrdTotamt = Convert.ToDouble(tchamt.ToString());

                            if (ogrdTotamt != fcurramt)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Dollar Amount does not Match with Voucher Details Amount...');", true);
                                return;
                            }
                        }

                        if (Session["rptype"].ToString() == "P")
                        {

                            intBnkLedgID = FAObj.Selledgeridforops(Session["FADbname"].ToString(), txt_bank.Text.Trim().ToUpper(), Convert.ToChar("O"));

                            if (Session["rptype"].ToString() == "P")
                            {
                                Bln_ChkMinMaxAmt = pymtobj.CheckMedgerMaxMinAmt4Pmt(intBnkLedgID, did, Convert.ToDouble(txt_amtrs.Text), Session["FADbname"].ToString());
                                if (Bln_ChkMinMaxAmt == true)
                                {

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Closing Balance has Crossed the maximum limit. You can not able to Issue the Payment');", true);
                                    return;
                                }
                            }
                        }


                        if (Session["rptype"].ToString() == "R")
                        {
                            bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                            recno = recobj.GetOSRPNo(bid, Convert.ToChar(Session["rptype"].ToString()));
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            //branchid = hrempobj.GetBranchId(did, ddl_branch.Text);
                            branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                            recno = recobj.GetOSRPNo(branchid, Convert.ToChar(Session["rptype"].ToString()));
                        }

                        if (recno == 0)
                        {
                            return;
                        }

                        if (mode == Convert.ToChar("C"))
                        {
                            if (Session["rptype"].ToString() == "R")
                            {
                                //recobj.InsRecptHeadCash(recno, Convert.ToDateTime(txt_cheqdate.Text), Convert.ToChar(mode), bid, Convert.ToInt32(hid_year.Value), Convert.ToInt32(hid_favour.Value), Convert.ToDouble(txt_amtrs.Text), Convert.ToString(txt_narration.Text), empid);
                            }
                            else if (Session["rptype"].ToString() == "P")
                            {
                                //  pymtobj.InsPaymentHeadCash(recno, Convert.ToDateTime(txt_cheqdate.Text), Convert.ToChar(mode), bid, Convert.ToInt32(hid_year.Value), Convert.ToInt32(hid_favour.Value), Convert.ToDouble(txt_amtrs.Text), Convert.ToString(txt_narration.Text), empid);
                            }
                        }


                        else if (mode == Convert.ToChar("B"))
                        {
                            chqdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_cheqdate.Text));

                            if (Session["rptype"].ToString() == "R")
                            {
                                recobj.InsOSRecptHeadBank(recno, Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), Convert.ToChar(mode), bid, Convert.ToInt32(hid_year.Value), Convert.ToInt32(hid_cust.Value), Convert.ToDouble(txt_amtrs.Text), Convert.ToInt32(hid_bankid.Value), txt_branch1.Text.ToUpper(), txt_cheque.Text.ToUpper(), Convert.ToDateTime(chqdate.ToShortDateString()), Convert.ToString(txt_narration.Text.ToUpper()), empid, Convert.ToDouble(txt_rcvamt.Text), txt_curr.Text.ToUpper(), Convert.ToDouble(txt_exrate.Text));
                            }
                            else if (Session["rptype"].ToString() == "P")
                            {
                                if (txt_fvr.Text == "")
                                {
                                    txt_fvr.Text = txt_recieve.Text;
                                }
                                pymtobj.InsOSPaymentHeadBank(recno, Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), Convert.ToChar(mode), bid, Convert.ToInt32(hid_year.Value), Convert.ToInt32(hid_cust.Value), Convert.ToDouble(txt_amtrs.Text), Convert.ToInt32(hid_bankid.Value), txt_branch1.Text.ToUpper(), txt_cheque.Text.ToUpper(), Convert.ToDateTime(chqdate.ToShortDateString()), txt_narration.Text.ToUpper(), empid, Convert.ToChar(ACPayee), txt_fvr.Text.ToUpper(), Convert.ToDouble(txt_rcvamt.Text), txt_curr.Text.ToUpper(), Convert.ToDouble(txt_exrate.Text));
                                //pymtobj.InsOSPaymentHeadBank(recno, currdate, mode, branchid, vouyear, rfCustid, Val(txtAmt.Text), bankid, txtBBranch.Text, txtChequeno.Text, chqdate, txtNaration.Text, Login.logempid, ACPayee, Trim(txtfvr.Text), txtrecamount.Text, txtcurr.Text, txtexrate.Text);

                                if (txt_refno.Text.Trim() != "")
                                {
                                    pymtobj.InsOSPaymentHead4RefNo(recno, mode, bid, Convert.ToInt32(hid_year.Value), txt_refno.Text.Trim());
                                }
                            }
                        }

                        txt_recp.Text = recno.ToString();

                        SaveAllGrdDetails();


                        // Update for Trigger 
                        recobj.UpdOSRecptPymt4trigger(Convert.ToInt32(txt_recp.Text), bid, Convert.ToInt32(hid_year.Value), empid, Session["rptype"].ToString(), str_mode);



                        if (Session["rptype"].ToString() == "R")
                        {
                            //Logobj.InsLogDetail(empid, 1083, 1, bid, str_mode + " / " + txt_recp.Text);
                            Logobj.InsLogDetail(empid, 1188, 1, bid, str_mode + " / " + txt_recp.Text);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt Details Saved. Receipt # : " + txt_recp.Text + "');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' Receipt # : " + txt_recp.Text + " ');", true);
                            //arun
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Remittance-Receipt", recno, recno, "", "", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
                        }
                        else if (Session["rptype"].ToString() == "P")
                        {
                            //Logobj.InsLogDetail(empid, 1082, 1, bid, str_mode + " / " + txt_recp.Text);
                            Logobj.InsLogDetail(empid, 1189, 1, bid, str_mode + " / " + txt_recp.Text);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Payment Details Saved. Payment # : " + txt_recp.Text + "');", true);
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Remittance-Payment", recno, recno, "", "", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
                        }

                        //int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                        //int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                        //int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                        //string FADbname = Session["FADbname"].ToString();

                        //if (rptype == "P" && str_mode == "C" && Grid_detail.Rows.Count > 0)
                        //{

                        //}
                        //else if (rptype == "P" && str_mode == "B" && Grid_detail.Rows.Count > 0)
                        //{

                        //}
                        //else if (rptype == "R" && str_mode == "P") { }
                        //else if (txt_refno.Text == "")
                        //{
                        //    if (CustAmt != grdTotamt)
                        //    {
                        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                        //        return;
                        //    }
                        //}
                        //else if (grdTotamt > 0)
                        //{
                        //    if (CustAmt != grdTotamt)
                        //    {
                        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                        //        return;
                        //    }
                        //}
                        //if (rptype == "P")
                        //{


                        //    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                        //    {
                        //        if (Grid_Account.Rows[i].Cells[0].Text == "Charges" || Grid_Account.Rows[i].Cells[0].Text == "Charges")
                        //        {
                        //            GrdChrgid = chrgobj.GetChargeid(Grid_Account.Rows[i].Cells[1].ToString());
                        //            chkledgerid = lobj.ChkLedgeridfrmLedHead(GrdChrgid, "A", FADbname);
                        //            if (chkledgerid == 0)
                        //            {
                        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' LedgerName " + Grid_Account.Rows[i].Cells[2].ToString() + " Not Found in Financial. You are not able to raise Payment.Contact Your  Finanace Head');", true);
                        //            }
                        //        }
                        //    }
                        //}
                        //CheckData();
                        //if (next == 0)
                        //{
                        //    return;
                        //}
                        //int intBnkLedgID = FAObj.Selledgeridforops(FADbname, txt_bank.Text, 'O');
                        //if (rptype == "P")
                        //{
                        //    Boolean Bln_ChkMinMaxAmt = false;
                        //    Bln_ChkMinMaxAmt = pymtobj.CheckMedgerMaxMinAmt4Pmt(intBnkLedgID, did, Convert.ToDouble(txt_amtrs.Text), FADbname);
                        //    if (Bln_ChkMinMaxAmt == false)
                        //    {
                        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Closing Balance has been Crossed the maximum limit. You can't able to Issue the Payment');", true);
                        //        next = 0;
                        //        return;
                        //    }
                        //}
                        //int recno1;
                        //DateTime currdate = Convert.ToDateTime(txt_date.Text);
                        //cheqdate = Convert.ToInt32(Utility.fn_ConvertDate(txt_cheqdate.Text));
                        //int bankid = bankobj.GetBankid(txt_bank.Text);
                        //DateTime chqdate = Convert.ToDateTime(txt_cheqdate.Text);
                        //recno1 = recobj.GetCRBRNo(bid, str_mode);
                        //if (rptype == "R")
                        //{

                        //    if (str_mode == "C" || str_mode == "P")
                        //    {
                        //        recobj.InsRecptHeadCash(recno1, currdate, mode, bid, cheqdate, rfcustid, Convert.ToDouble(txt_amtrs.Text), txt_narration.Text, empid);
                        //    }
                        //    else if (str_mode == "B")
                        //    {
                        //        recobj.InsRecptHeadBank(recno1, currdate, mode, branchid, cheqdate, rfcustid, Convert.ToDouble(txt_amtrs.Text), bankid, txt_branch1.Text, txt_cheque.Text, chqdate, txt_narration.Text, empid);
                        //    }
                        //}
                        //else if (rptype == "P")
                        //{
                        //    recno1 = pymtobj.GetCPBPNo(bid, str_mode);
                        //    if (str_mode == "C" || str_mode == "P")
                        //    {
                        //        pymtobj.InsPaymentHeadCash(recno1, currdate, mode, bid, cheqdate, rfcustid, Convert.ToDouble(txt_amtrs.Text), txt_narration.Text, empid);
                        //        if (txt_refno.Text != "")
                        //        {
                        //            pymtobj.InsPaymentHeadcash4RefNo(recno1, mode, bid, cheqdate, txt_refno.Text);
                        //        }
                        //    }
                        //    else if (str_mode == "B")
                        //    {
                        //        if (txt_fvr.Text == "")
                        //        {
                        //            txt_fvr.Text = txt_recieve.Text;
                        //        }
                        //        pymtobj.InsPaymentHeadBank(recno1, currdate, mode, bid, cheqdate, rfcustid, Convert.ToDouble(txt_amtrs.Text), bankid, txt_branch1.Text, txt_cheque.Text, chqdate, txt_narration.Text, empid, ACPayee, txt_fvr.Text);

                        //    }
                        //}
                        //branchid = hrempobj.GetBranchId(did, ddl_branch.Text);
                        //objnoc.UpdateNotOverChequeAccounted(branchid, Convert.ToInt32(hid_cheque.Value));
                        //txt_recp.Text = recno1.ToString();
                        //if (rptype == "P" && str_mode == "C" && Grid_detail.Rows.Count == 0)
                        //{
                        //    SaveAllGrdDetails4PayCash();
                        //}
                        //else if (rptype == "R" && str_mode == "p")
                        //{
                        //    SaveAllGrdDetails4PayCash();
                        //}
                        //else
                        //{
                        //    SaveAllGrdDetails();
                        //}
                        //if (rptype == "R")
                        //{
                        //    Logobj.InsLogDetail(empid, 268, 1, bid, str_mode + " / " + txt_recp.Text);
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt Details Saved');", true);
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' Receipt # : " + txt_recp.Text + " ');", true);
                        //    recno = Convert.ToInt32(txt_recp.Text);
                        //    // hid_rid.Value=recno.ToString();
                        //    //raj
                        //    //if (str_mode == "C")
                        //    //{
                        //    //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Receipt", recno, recno, "", "");
                        //    //}
                        //    //else if (str_mode == "B")
                        //    //{
                        //    //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Receipt", recno, recno, "", "");
                        //    //}
                        //    //else if (str_mode == "P")
                        //    //{
                        //    //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Receipt - Petty Cash", recno, recno, "", "");
                        //    //}
                        //}
                        //else if (rptype == "P")
                        //{
                        //    if (branchpay == "B")
                        //    {
                        //        Logobj.InsLogDetail(empid, 544, 1, branchid, str_mode + " / " + txt_recp.Text);
                        //    }
                        //    else
                        //    {
                        //        Logobj.InsLogDetail(empid, 376, 1, branchid, str_mode + " / " + txt_recp.Text);
                        //    }
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Payment Details Saved');", true);
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' Payment # : " + txt_recp.Text + " ');", true);
                        //    if (str_mode == "C")
                        //    {//raj
                        //        //logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Payment", recno, recno, "", "");
                        //    }
                        //    else if (str_mode == "B")
                        //    {
                        //        //logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Payment", recno, recno, "", "");
                        //    }
                        //}
                        //btn_save.Enabled = false;
                        //CTEnable();

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Payment", "alertify.alert('" + lbl_head.Text + "Amount does not Match with Total Amount" + "');", true);
                    }

                }

            }



            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            fun_save();
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
            //try
            //{

            //    DataTable dt_cust = new DataTable();
            //    DataTable dt_charge = new DataTable();
            //    int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            //    int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            //    int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            //    string FADbname = Session["FADbname"].ToString();

            //    mode_set();
            //    if (next == 0)
            //    {
            //        return;
            //    }
            //    if (btn_save.Text == "Save")
            //    {
            //        if (txt_amtrs.Text == txt_total.Text)
            //        {
            //            cheqdate = Convert.ToInt32(HttpContext.Current.Session["Vouyear"].ToString());
            //            for (int i = 0; i < Grid_Account.Rows.Count - 1; i++)
            //            {
            //                if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
            //                {
            //                    int r = i;
            //                    custid = Convert.ToInt32(Grid_Account.Rows[r].Cells[3].Text);
            //                    custRcharname = Grid_Account.Rows[r].Cells[2].Text;
            //                    dt_cust = pymtobj.Getcustamt(custid, bid, str_mode, cheqdate);
            //                    // rptype == "P" && str_mode == "C"
            //                    if (str_mode == "B")
            //                    {
            //                        camt = Convert.ToDouble(Grid_Account.Rows[r].Cells[2].Text);
            //                        if (dt_cust.Rows.Count > 0)
            //                        {
            //                            for (int j = 0; j < dt_cust.Rows.Count - 1; j++)
            //                            {
            //                                camt = Convert.ToDouble(camt + dt_cust.Rows[j]["amount"].ToString());
            //                            }
            //                        }
            //                        if (camt >= 20000)
            //                        {
            //                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('You can not make more than 20,000 to " + custRcharname + " in a day');", true);

            //                        }
            //                    }
            //                }
            //                else if (Grid_Account.Rows[i].Cells[0].Text == "Deduction" || Grid_Account.Rows[i].Cells[0].Text == "Charges")
            //                {
            //                    custid = Convert.ToInt32(Grid_Account.Rows[i].Cells[4].ToString());
            //                    custRcharname = Grid_Account.Rows[i].Cells[2].ToString();
            //                    dt_cust = pymtobj.Getcustamt(custid, bid, str_mode, cheqdate);
            //                    //rptype == "P" && 
            //                    if (str_mode == "B")
            //                    {
            //                        camt = Convert.ToDouble(Grid_Account.Rows[i].Cells[2]);
            //                        if (dt_cust.Rows.Count > 0)
            //                        {
            //                            for (int j = 0; j < dt_cust.Rows.Count - 1; j++)
            //                            {
            //                                camt = Convert.ToDouble(camt + dt_cust.Rows[j]["amount"].ToString());
            //                            }
            //                        }
            //                        if (camt >= 20000)
            //                        {
            //                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('You can not make more than 20,000 to " + custRcharname + " in a day');", true);

            //                        }
            //                    }
            //                }

            //            }

            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Payment", "alertify.alert('" + lbl_head.Text + "Amount does not Match with Total Amount" + "');", true);

            //        }
            //        for (int i = 0; i < Grid_detail.Rows.Count; i++)
            //        {
            //            IE = Grid_detail.Rows[i].Cells[5].Text;
            //            if (IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "O")
            //            {
            //                incTotamt = incTotamt + Convert.ToDouble(incTotamt + Grid_detail.Rows[i].Cells[4].Text);
            //            }
            //            else if (IE == "P" || IE == "C" || IE == "E" || IE == "S")
            //            {
            //                expTotamt = expTotamt + Convert.ToDouble(incTotamt + Grid_detail.Rows[i].Cells[4].Text);
            //            }
            //            if (rptype == "R")
            //            {
            //                if (IE == "J")
            //                {
            //                    if (Grid_detail.Rows[i].Cells[9].Text == "Dr")
            //                    {
            //                        incTotamt = incTotamt + Convert.ToDouble(incTotamt + Grid_detail.Rows[i].Cells[4].Text);
            //                    }
            //                    else if (Grid_detail.Rows[i].Cells[9].Text == "Cr")
            //                    {
            //                        expTotamt = expTotamt + Convert.ToDouble(incTotamt + Grid_detail.Rows[i].Cells[4].Text);
            //                    }
            //                }
            //            }
            //            else if (rptype == "P")
            //            {
            //                if (IE == "J")
            //                {
            //                    if (Grid_detail.Rows[i].Cells[9].Text == "Dr")
            //                    {
            //                        incTotamt = incTotamt + Convert.ToDouble(incTotamt + Grid_detail.Rows[i].Cells[4].Text);
            //                    }
            //                    else if (Grid_detail.Rows[i].Cells[9].Text == "Cr")
            //                    {
            //                        expTotamt = expTotamt + Convert.ToDouble(incTotamt + Grid_detail.Rows[i].Cells[4].Text);
            //                    }
            //                }
            //            }
            //        }
            //        if (rptype == "R")
            //        {
            //            grdTotamt = incTotamt - expTotamt;
            //        }
            //        else if (rptype == "P")
            //        {
            //            grdTotamt = expTotamt - incTotamt;
            //        }
            //        for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
            //        {
            //            if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
            //            {
            //                CustAmt = CustAmt + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
            //            }
            //        }
            //        if (rptype == "P" && str_mode == "C")
            //        {
            //            if (txt_refno.Text == "")
            //            {
            //                this.popup_ref.Show();
            //                if (next == 0)
            //                {
            //                    return;
            //                }
            //            }
            //        }

            //    }
            //    btn_view.Focus();
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }

        private void SaveAllGrdDetails4PayCash()
        {
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int Vouyear = Convert.ToInt32(txt_recpdate.Text);
                mode_set();
                recno = Convert.ToInt32(txt_recp.Text);
                int rid = 0;
                int Grdcashcustid;
                if (rptype == "R")
                {
                    rid = recobj.GetOSRecrid(recno, bid, mode, Vouyear);
                }
                else if (rptype == "p")
                {
                    rid = pymtobj.GetOSPaymentid(recno, bid, mode, Vouyear);
                }


                for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                {
                    if (Grid_Account.Rows[i].Cells[0].Text == "Charges")
                    {
                        GrdChrgid = chrgobj.GetChargeid(Grid_Account.Rows[i].Cells[1].Text);
                        if (rptype == "R")
                        {
                            recobj.InsReciptChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        else if (rptype == "P")
                        {
                            pymtobj.InsPaymentChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                    }
                    else if (Grid_Account.Rows[i].Cells[0].Text == "Excess / Short")
                    {
                        if (rptype == "R")
                        {
                            recobj.InsReciptChargeDetail(rid, 0, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        else if (rptype == "P")
                        {
                            pymtobj.InsPaymentChargeDetail(rid, 0, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
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
                            if (rptype == "P")
                            {
                                pymtobj.InsPaymentCustomerDetail(rid, Grdcashcustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
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
                            if (rptype == "R")
                            {
                                recobj.InsReciptCustomerDetail(rid, Grdcashcustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                            }
                        }
                    }
                }
                else if (txt_refno.Text == "" && rptype == "P" && str_mode == "C" && Grid_detail.Rows.Count > 0)
                {
                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                        {
                            Grdcashcustid = Convert.ToInt32(Grid_Account.Rows[i].Cells[3].Text);
                            if (rptype == "P")
                            {
                                pymtobj.InsPaymentCustomerDetail(rid, Grdcashcustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                            }
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

        private void SaveAllGrdDetails()
        {
            try
            {
                // int RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
                int gbid = 0, cVal = 0, RAvouyear = 0, invno = 0, GrdCustid, GrdChrgid;
                double ramt = 0, vouamt = 0, grdexr = 0;
                string vtype = "", jltype = "", jrefno = "";
                char setteled;
                int intcustid;
                string grdcur;
                double grdfamt;
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                string vendorrefno = "";
                string vendordatetime = "";
                int Vouyear = Convert.ToInt32(txt_recpdate.Text);
                mode_set();
                recno = Convert.ToInt32(txt_recp.Text);
                if (Session["rptype"].ToString() == "R")
                {
                    rid = recobj.GetOSRecrid(recno, bid, mode, Vouyear);
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    rid = pymtobj.GetOSPaymentid(recno, bid, mode, Vouyear);
                }
                if (Session["rptype"].ToString() == "R")
                {
                    cVal = Convert.ToInt32(Grid_detail.Rows.Count - 2);
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    cVal = Convert.ToInt32(Grid_detail.Rows.Count - 1);
                }
                for (i = 0; i <= cVal; i++)
                {
                    if (Grid_detail.Rows[i].Cells[2].Text != "On Account")
                    {
                        ramt = Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text);
                        if (ramt > 0)
                        {
                            //gbid = Convert.ToInt32(Grid_detail.Rows[i].Cells[0].Text);
                            // vtype = Grid_detail.Rows[i].Cells[5].Text;

                            //else
                            //{
                            //   
                            //}
                            //invno = Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text);
                            //vtype = Grid_detail.Rows[i].Cells[5].Text;
                            grdcur = Grid_detail.Rows[i].Cells[3].Text;
                            //  RAvouyear = Convert.ToInt32(Grid_detail.Rows[i].Cells[8].Text);

                            gbid = Convert.ToInt32(Grid_detail.Rows[i].Cells[0].Text);
                            vtype = Grid_detail.Rows[i].Cells[9].Text;
                            vouamt = Convert.ToDouble(Grid_detail.Rows[i].Cells[6].Text);
                            RAvouyear = Convert.ToInt32(Grid_detail.Rows[i].Cells[12].Text);
                            //grdcur = grdINVRec.Rows(i).Cells(3).Value
                            grdexr = Convert.ToDouble(Grid_detail.Rows[i].Cells[5].Text);

                            grdfamt = Convert.ToDouble(Grid_detail.Rows[i].Cells[4].Text);
                            TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                            tfcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());

                            if (grdfamt > tfcamount)
                            {
                                setteled = 'N';
                            }
                            else
                            {
                                setteled = 'Y';
                            }

                            if (vtype == "J")
                            {
                                string refno = Grid_detail.Rows[i].Cells[2].Text;
                                string[] str = refno.Split('-');
                                jrefno = str[1].Remove(0, 1);
                                //jrefno = Grid_detail.Rows[i].Cells[2].Text;
                            }

                            if (vtype != "J")
                            {
                                invno = Convert.ToInt32(Grid_detail.Rows[i].Cells[10].Text);
                            }


                            //vendor refno and date
                            if (Grid_detail.Rows[i].Cells[15].Text != "")
                            {
                                if (Grid_detail.Rows[i].Cells[15].Text != "&nbsp;")
                                {
                                    vendorrefno = Grid_detail.Rows[i].Cells[15].Text.ToUpper().Replace("&amp;", "&").Replace("&amp;amp;", "&").Replace("&amp;&amp;", "&");
                                }
                                else
                                {
                                    if (Grid_detail.Rows[i].Cells[15].Text == "&nbsp;")
                                    {
                                        vendorrefno = "";
                                    }
                                }
                            }
                            else
                            {
                                vendorrefno = "";
                            }

                            if (Grid_detail.Rows[i].Cells[16].Text != "")
                            {
                                if (Grid_detail.Rows[i].Cells[16].Text != "&nbsp;")
                                {
                                    vendordatetime = Convert.ToDateTime(Grid_detail.Rows[i].Cells[16].Text).ToString("dd/MMM/yyyy");
                                }
                                else
                                {
                                    if (Grid_detail.Rows[i].Cells[16].Text == "&nbsp;")
                                    {
                                        vendordatetime = "";
                                    }
                                }
                            }
                            else
                            {
                                vendordatetime = "";
                            }
                            if (vendordatetime != "" && vtype != "J")
                            {
                                recobj.InsRecptAginstInv4OSwithvendor(rid, Convert.ToChar(Session["rptype"].ToString()), invno, Convert.ToChar(vtype), gbid, Convert.ToDouble(vouamt), Convert.ToDouble(ramt), Convert.ToChar(setteled), RAvouyear, grdcur.ToString(), Convert.ToDouble(grdfamt), Convert.ToDouble(grdexr), Convert.ToDouble(txt_rcvamt.Text), Convert.ToDouble(tfcamount), vendorrefno, Convert.ToDateTime(vendordatetime));
                            }
                            else if (vtype != "J")
                            {
                                recobj.InsRecptAginstInv4OS1(rid, Convert.ToChar(Session["rptype"].ToString()), invno, vtype, gbid, Convert.ToDouble(vouamt), Convert.ToDouble(ramt), Convert.ToChar(setteled), RAvouyear, grdcur.ToString(), Convert.ToDouble(grdfamt), Convert.ToDouble(grdexr), Convert.ToDouble(txt_rcvamt.Text), Convert.ToDouble(tfcamount));
                            }
                            // recobj.InsRecptAginstInv4OS(rid, Convert.ToChar(Session["rptype"].ToString()), invno, Convert.ToChar(vtype), gbid, Convert.ToDouble(vouamt), Convert.ToDouble(ramt), Convert.ToChar(setteled), RAvouyear, grdcur.ToString(), Convert.ToDouble(grdfamt), Convert.ToDouble(grdexr), Convert.ToDouble(txt_rcvamt.Text), Convert.ToDouble(tfcamount));
                            char rtype = char.Parse(Session["rptype"].ToString());
                            char vouchtype = char.Parse(vtype);

                            if (vtype == "J")
                            {
                                jltype = Grid_detail.Rows[i].Cells[13].Text;
                                //recobj.InsRecptAginstInvj();InsRecptAginstInv4OS
                                recobj.InsOSRecptAginstInvj(rid, rtype, 0, vouchtype, gbid, vouamt, ramt, setteled, RAvouyear, jrefno, jltype, Convert.ToInt32(hid_favour.Value), grdcur.ToString(), Convert.ToDouble(grdfamt), Convert.ToDouble(grdexr), Convert.ToDouble(txt_rcvamt.Text), Convert.ToDouble(tfcamount));// gbid, vouamt, ramt, setteled, RAvouyear, jrefno, jltype);
                            }

                            try
                            {
                                Approveobj.UpdLedgerOPBreakup(invno, vouchtype, RAvouyear, gbid, rid, rtype, Vouyear, ramt, "", 0.0, "", "");
                            }
                            catch (Exception ex)
                            {
                                // Utility.SendMail(Session["usermailid"].ToString(), "rajan.j@freyerinternational.com", "", "Nambi", "FA RECEIPT PMT TRAN DTLS - ERROR VOU # " + invno.ToString() + " TRANID " + rid, ex.ToString());
                            }
                            //if (rptype == "P")
                            //{
                            //    if (vtype == "P" || vtype == "E")
                            //    {
                            //        ChqObj.UpdChequeApproval4Rcpt(invno, vouchtype, Vouyear, gbid, Convert.ToInt32(Session["LoginEmpId"]));
                            //    }
                            //}
                        }
                    }

                }

                if (Session["rptype"].ToString() == "R" || Session["rptype"].ToString() == "P")
                {
                    for (int i = 0; i < Grid_detail.Rows.Count; i++)
                    {
                        if (Grid_detail.Rows[i].Cells[2].Text == "On Account")
                        {
                            //ramt = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                            TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                            ramt = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());

                            if (ramt > 0)
                            {
                                char rtype = char.Parse(Session["rptype"].ToString());
                                intcustid = cusobj.GetCustomerid(txt_recieve.Text);
                                //recobj.InsRecptAginstInv(rid, rtype, 0, 'O', bid, 0, ramt, 'Y', Convert.ToInt32(txt_recpdate.Text));
                                chkledgerid = Ldrobj.ChkLedgeridfrmLedHead(intcustid, "C", Session["FADbname"].ToString());
                                //Approveobj.InsLedgerOPBreakup4OAC(chkledgerid, RAvouyear, bid, rid, rtype, RAvouyear, ramt, intcustid);
                                if (Grid_detail.Rows[i].Cells[6].Text == "&nbsp;" || Grid_detail.Rows[i].Cells[6].Text == "")
                                {
                                    Grid_detail.Rows[i].Cells[6].Text = "0.00";
                                }
                                if (Grid_detail.Rows[i].Cells[8].Text == "&nbsp;" || Grid_detail.Rows[i].Cells[8].Text == "")
                                {
                                    Grid_detail.Rows[i].Cells[8].Text = "0.00";
                                }
                                if (Grid_detail.Rows[i].Cells[3].Text == "&nbsp;" || Grid_detail.Rows[i].Cells[3].Text == "")
                                {
                                    Grid_detail.Rows[i].Cells[3].Text = "0.00";
                                }
                                if (Grid_detail.Rows[i].Cells[4].Text == "&nbsp;" || Grid_detail.Rows[i].Cells[4].Text == "")
                                {
                                    Grid_detail.Rows[i].Cells[4].Text = "0.00";
                                }
                                if (Grid_detail.Rows[i].Cells[5].Text == "&nbsp;" || Grid_detail.Rows[i].Cells[5].Text == "")
                                {
                                    Grid_detail.Rows[i].Cells[5].Text = "0.00";
                                }

                                recobj.InsRecptAginstInv4OS(rid, Convert.ToChar(Session["rptype"].ToString()), 0, Convert.ToChar("O"), bid, Convert.ToDouble(Grid_detail.Rows[i].Cells[6].Text), Convert.ToDouble(Grid_detail.Rows[i].Cells[8].Text), Convert.ToChar("Y"), Convert.ToInt32(txt_recpdate.Text), Grid_detail.Rows[i].Cells[3].Text, Convert.ToDouble(Grid_detail.Rows[i].Cells[4].Text), Convert.ToDouble(Grid_detail.Rows[i].Cells[5].Text), Convert.ToDouble(txt_rcvamt.Text), ramt);

                                if (chkledgerid == 0)
                                {
                                    subgroupid = 40;
                                    groupid = 13;
                                    chkledgerid = Ldrobj.InsLedgerHeadfromTally(customerobj.GetCustomername(intcustid), subgroupid, groupid, Convert.ToChar("G"), intcustid, Convert.ToChar("C"), FADbname);
                                }

                                chkledgerid = Ldrobj.ChkLedgeridfrmLedHead(intcustid, "C", FADbname);
                                Approveobj.InsLedgerOPBreakup4OAC(chkledgerid, Convert.ToInt32(txt_recpdate.Text), bid, rid, rtype, Convert.ToInt32(txt_recpdate.Text), ramt, intcustid);
                            }
                        }

                    }
                }
                for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                {
                    if (Grid_Account.Rows[i].Cells[0].Text == "Customer")
                    {
                        GrdCustid = Convert.ToInt32(Grid_Account.Rows[i].Cells[4].Text);
                        if (Session["rptype"] == "R")
                        {
                            recobj.InsOSReciptCustomerDetail(rid, GrdCustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text), Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        else if (Session["rptype"] == "P")
                        {
                            pymtobj.InsOSPaymentCustomerDetail(rid, GrdCustid, Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text), Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                    }
                    else if (Grid_Account.Rows[i].Cells[0].Text == "Charges" && Grid_Account.Rows[i].Cells[2].Text != "")
                    {
                        GrdChrgid = chrgobj.GetChargeid(Grid_Account.Rows[i].Cells[1].Text);
                        if (Session["rptype"] == "R")
                        {
                            recobj.InsOSReciptChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text), Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        //   pymtobj.InsOSPaymentChargeDetail(rid, GrdChrgid, grddetails.Rows(i).Cells(3).Value, grddetails.Rows(i).Cells(2).Value)
                        else if (Session["rptype"] == "P")
                        {
                            pymtobj.InsOSPaymentChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text), Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        }
                        //else if (rptype == "P")
                        //{
                        //    pymtobj.InsPaymentCustomerDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text));
                        //}
                    }

                    else if (Grid_Account.Rows[i].Cells[0].Text == "Charges" && Grid_Account.Rows[i].Cells[2].Text == "")
                    {
                        GrdChrgid = chrgobj.GetChargeid(Grid_Account.Rows[i].Cells[1].Text);
                        if (Session["rptype"] == "R")
                        {
                            recobj.InsOSReciptChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text), 0);
                        }
                        else if (Session["rptype"] == "P")
                        {
                            pymtobj.InsOSPaymentChargeDetail(rid, GrdChrgid, Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text), 0);
                        }
                    }

                    else if (Grid_Account.Rows[i].Cells[0].Text == "Ex.Rate Gain" || Grid_Account.Rows[i].Cells[0].Text == "Ex.Rate Loss")
                    {
                        if (Session["rptype"] == "R")
                        {
                            recobj.InsOSReciptChargeDetail(rid, 0, Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text), 0);
                        }
                        else if (Session["rptype"] == "P")
                        {
                            pymtobj.InsOSPaymentChargeDetail(rid, 0, Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text), 0);
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

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                //ModalPopup_amount.Show();
                double Total = 0;
                DataTable dt_ok = new DataTable();
                dt_ok.Columns.Add("branchid");
                dt_ok.Columns.Add("branch");
                dt_ok.Columns.Add("invoiceno");
                dt_ok.Columns.Add("iamount");
                dt_ok.Columns.Add("ramount");
                dt_ok.Columns.Add("voutype");
                dt_ok.Columns.Add("vouno");
                dt_ok.Columns.Add("tds");
                dt_ok.Columns.Add("ravouyear");
                dt_ok.Columns.Add("ltype");
                DataRow dr;

                DataTable dt_oktemp = new DataTable();
                dt_oktemp.Columns.Add("type");
                dt_oktemp.Columns.Add("customerortax");
                dt_oktemp.Columns.Add("amount");
                dt_oktemp.Columns.Add("cid");
                DataRow dr_detail;
                if (ViewState["GridData"] == null)
                {
                    DataTable dt = (DataTable)ViewState["GridData"];

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
                            dr[5] = Grid_Amount.Rows[row.RowIndex].Cells[2].Text;
                            dr[6] = Grid_Amount.Rows[row.RowIndex].Cells[3].Text;
                            dr[7] = Grid_Amount.Rows[row.RowIndex].Cells[10].Text;
                            dr[8] = Grid_Amount.Rows[row.RowIndex].Cells[11].Text;
                            dr[9] = "";
                            dt_ok.Rows.Add(dr);
                            if (Grid_Amount.Rows[row.RowIndex].Cells[6].Text == "S")
                            {
                                txt_narration.Text = txt_narration.Text.Replace(System.Environment.NewLine, "") + Grid_Amount.Rows[row.RowIndex].Cells[15].Text.Replace(System.Environment.NewLine, "");
                            }

                            dr_detail[0] = "Customer";
                            dr_detail[1] = Grid_Amount.Rows[row.RowIndex].Cells[5].Text;
                            dr_detail[2] = Grid_Amount.Rows[row.RowIndex].Cells[7].Text;
                            dr_detail[3] = Grid_Amount.Rows[row.RowIndex].Cells[12].Text;
                            dt_oktemp.Rows.Add(dr_detail);

                            hid_customerid.Value = Grid_Amount.Rows[row.RowIndex].Cells[12].Text;
                            hid_favour.Value = Grid_Amount.Rows[row.RowIndex].Cells[7].Text;
                            txt_recieve.Text = Grid_Amount.Rows[row.RowIndex].Cells[5].Text;
                            Total = Total + Convert.ToDouble(Grid_Amount.Rows[row.RowIndex].Cells[7].Text);
                            Chk_accountpay.Checked = true;
                        }

                    }
                    ViewState["GridData"] = dt_ok;
                    Grid_detail.DataSource = dt_ok;
                    Grid_detail.DataBind();
                    ViewState["GridAccount"] = dt_oktemp;
                    Grid_Account.DataSource = dt_oktemp;
                    Grid_Account.DataBind();
                    ViewState["CurrentData"] = dt_oktemp;
                    //Session["GridAccount"] = dt_oktemp;
                    //txt_amt.Text = string.Format("{0:0.00}", Total);
                    //txt_total.Text = txt_amt.Text;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grid_Cheque_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_Cheque.PageIndex = e.NewPageIndex;
            //LoadCheque();
        }

        //protected void save_Fun()
        //{
        //    try
        //    {
        //        int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
        //        int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
        //        int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
        //        string FADbname = Session["FADbname"].ToString();

        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        protected void btn_Alert_Yes_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_Alert_No_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtrefno = new DataTable();
                int bankid = 0, intcustid = 0;
                int divisionID = Convert.ToInt32(Session["LoginDivisionId"]);
                if (rptype == "P")
                {
                    if (str_mode == "B")
                    {
                        if (Chk_accountpay.Checked == false)
                        {
                            ACPayee = 'U';
                        }
                        else
                        {
                            ACPayee = 'C';
                        }
                    }
                    else if (str_mode == "C")
                    {
                        branchid = hrempobj.GetBranchId(divisionID, ddl_branch.Text);
                        dtrefno = pymtobj.GetCashRefNO(txt_refno.Text, branchid);
                        if (dtrefno.Rows.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Reference No. Already Exists');", true);
                            txt_refno.Focus();
                            next = 0;
                            return;
                        }
                    }

                }

                if (str_mode == "B")
                {
                    if (txt_cheque.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Cheque # cannot be blank');", true);
                        txt_cheque.Focus();
                        next = 0;
                        return;
                    }
                    if (txt_bank.Text != "")
                    {
                        bankid = bankobj.GetBankid(txt_bank.Text);
                        if (bankid == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bank Name Not Available');", true);
                            txt_bank.Focus();
                            next = 0;
                            return;
                        }
                        else
                        {
                            Boolean Chqno = false;
                            Chqno = recobj.CheckChequeNo(txt_cheque.Text, bankid, RPtype);
                            if (Chqno == true)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Cheque # already Exist');", true);
                                txt_cheque.Focus();
                                next = 0;
                                return;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bank Name cannot be blank');", true);
                        txt_bank.Focus();
                        next = 0;
                        return;
                    }
                    if (txt_branch1.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bank Branch cannot be blank');", true);
                        txt_bank.Focus();
                        next = 0;
                        return;
                    }
                }
                if (txt_recieve.Text != "")
                {
                    intcustid = cusobj.GetCustomerid(txt_recieve.Text);
                    if (intcustid == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + txt_recieve.Text + "Customer Name Not Available');", true);
                        txt_recieve.Focus();
                        next = 0;
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + txt_recieve.Text + "Customer Name Not Available');", true);
                    txt_recieve.Focus();
                    next = 0;
                    return;
                }
                //if (txt_amt.Text == "")
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount cannot be blank');", true);
                //    txt_recieve.Focus();
                //    next = 0;
                //    return;
                //}
                //if (rptype == "P")
                //{
                //    if (str_mode == "C")
                //    {
                //        //double amt = Convert.ToDouble(txt_amt.Text);
                //        if (amt >= 20000)
                //        {
                //            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount Should Not Exceed Rs.19,999');", true);
                //            txt_recieve.Focus();
                //            next = 0;
                //            return;
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

        protected void btn_ref_yes_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Enter Cash Referance No.');", true);
                txt_refno.Focus();
                next = 0;
                return;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_ref_no_Click(object sender, EventArgs e)
        {
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                string FADbname = Session["FADbname"].ToString();
                if (Session["rptype"] == "P" && Grid_Account.Rows.Count == 0 && bolCust == true)
                {

                }
                else
                {
                    if (txt_refno.Text.Trim() == "")
                    {
                        if (expTotamt != grdTotamt)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                            return;
                        }
                    }
                    else
                    {
                        if (grdTotamt > 0)
                        {
                            if (expTotamt != grdTotamt)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                                return;
                            }
                        }
                    }
                }

                //FOr Multiple Currency///


                int count = 0;


                if (txt_curr.Text.Trim() != "" && Grid_detail.Rows.Count > 0)
                {
                    for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                    {
                        if (txt_curr.Text == Grid_detail.Rows[i].Cells[3].Text)
                        {
                            count = count + 1;
                        }
                    }
                }


                if (count == Grid_detail.Rows.Count)
                {
                    if (txt_rcvamt.Text != txt_total.Text)
                    {
                        if (Session["rptype"] == "R")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt Amount does not Match with Total Dollar  Amount...');", true);
                            return;
                        }
                        else if (Session["rptype"] == "R")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Payment Amount does not Match with Total Dollar Amount...');", true);
                            return;
                        }
                    }


                    string IEO;
                    ACPayee = Convert.ToChar("C");
                    double oincTotamt = 0;
                    double oexpTotamt = 0;
                    double ogrdTotamt = 0;
                    double fcurramt = 0;

                    for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                    {
                        IEO = Grid_detail.Rows[i].Cells[9].Text;
                        if (IEO == "I" || IEO == "D" || IEO == "V" || IEO == "X" || IEO == "O")
                        {
                            double temparary = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                            string temparary1 = temparary.ToString("#0.00");
                            oincTotamt = (oincTotamt) + Convert.ToDouble(temparary1.ToString());
                        }
                        else if (IEO == "P" || IEO == "C" || IEO == "E" || IEO == "S")
                        {
                            double tempararyf = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                            string temparary2 = tempararyf.ToString("#0.00");
                            oexpTotamt = (oexpTotamt) + Convert.ToDouble(temparary2.ToString());
                        }

                        else if (IEO == "U" || IEO == "T")
                        {
                            if (Grid_detail.Rows[i].Cells[13].Text == "Dr")
                            {
                                double temparary = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                                string temparary1 = temparary.ToString("#0.00");
                                oincTotamt = (oincTotamt) + Convert.ToDouble(temparary1.ToString());
                            }
                            else if (Grid_detail.Rows[i].Cells[13].Text == "Cr")
                            {
                                double tempararyf = Convert.ToDouble(Grid_detail.Rows[i].Cells[7].Text);
                                string temparary2 = tempararyf.ToString("#0.00");
                                oexpTotamt = (oexpTotamt) + Convert.ToDouble(temparary2.ToString());
                            }
                        }
                    }


                    if (Session["rptype"] == "R")
                    {
                        ogrdTotamt = oincTotamt - oexpTotamt;
                    }
                    else if (Session["rptype"] == "P")
                    {
                        ogrdTotamt = oexpTotamt - oincTotamt;
                    }

                    string resl = ogrdTotamt.ToString("#0.00");
                    ogrdTotamt = Convert.ToDouble(resl.ToString());
                    double outp1 = Convert.ToDouble(txt_rcvamt.Text);

                    string resl1 = outp1.ToString("#0.00");
                    ogrdTotamt = Convert.ToDouble(resl1.ToString());

                    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                    {
                        if (Grid_Account.Rows[i].Cells[0].Text == "Charges")
                        {
                            double dou = Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                            int dou1 = Convert.ToInt32(dou.ToString("#0.00"));
                            chrgamt = chrgamt + Convert.ToDouble(dou1);
                        }
                    }
                    if (chrgamt < 0)
                    {
                        ogrdTotamt = ogrdTotamt + chrgamt;
                    }
                    else
                    {
                        ogrdTotamt = ogrdTotamt + chrgamt;
                    }

                    if (ogrdTotamt != fcurramt)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Dollar Amount does not Match with Voucher Details Amount...');", true);
                        return;
                    }
                }

                if (Session["rptype"] == "P")
                {

                    intBnkLedgID = FAObj.Selledgeridforops(Session["FADbname"].ToString(), txt_bank.Text.Trim().ToUpper(), Convert.ToChar("O"));

                    if (Session["rptype"] == "P")
                    {
                        Bln_ChkMinMaxAmt = pymtobj.CheckMedgerMaxMinAmt4Pmt(intBnkLedgID, did, Convert.ToDouble(txt_amtrs.Text), Session["FADbname"].ToString());
                        if (Bln_ChkMinMaxAmt == true)
                        {

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Closing Balance has Crossed the maximum limit. You can not able to Issue the Payment');", true);
                            return;
                        }
                    }

                }

                if (Session["rptype"] == "R")
                {
                    bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                    recno = recobj.GetOSRPNo(bid, Convert.ToChar(Session["rptype"].ToString()));
                }
                else if (Session["rptype"] == "P")
                {
                    branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                    recno = recobj.GetOSRPNo(branchid, Convert.ToChar(Session["rptype"].ToString()));
                }

                if (recno == 0)
                {
                    return;
                }
                if (mode == Convert.ToChar("C"))
                {
                    if (Session["rptype"] == "R")
                    {
                        //recobj.InsRecptHeadCash(recno, Convert.ToDateTime(txt_cheqdate.Text), Convert.ToChar(mode), bid, Convert.ToInt32(hid_year.Value), Convert.ToInt32(hid_favour.Value), Convert.ToDouble(txt_amtrs.Text), Convert.ToString(txt_narration.Text), empid);
                    }
                    else if (Session["rptype"] == "P")
                    {
                        //  pymtobj.InsPaymentHeadCash(recno, Convert.ToDateTime(txt_cheqdate.Text), Convert.ToChar(mode), bid, Convert.ToInt32(hid_year.Value), Convert.ToInt32(hid_favour.Value), Convert.ToDouble(txt_amtrs.Text), Convert.ToString(txt_narration.Text), empid);
                    }
                }


                else if (mode == Convert.ToChar("B"))
                {
                    chqdate = Convert.ToDateTime(txt_cheqdate.Text);

                    if (Session["rptype"] == "R")
                    {
                        recobj.InsOSRecptHeadBank(recno, Convert.ToDateTime(txt_cheqdate.Text), Convert.ToChar(mode), bid, Convert.ToInt32(hid_year.Value), Convert.ToInt32(hid_favour.Value), Convert.ToDouble(txt_amtrs.Text), Convert.ToInt32(hid_bankid.Value), txt_branch1.Text, txt_cheque.Text, Convert.ToDateTime(chqdate), Convert.ToString(txt_narration.Text), empid, Convert.ToDouble(txt_rcvamt.Text), txt_curr.Text, Convert.ToDouble(txt_exrate.Text));
                    }
                    else if (Session["rptype"] == "P")
                    {
                        if (txt_fvr.Text == "")
                        {
                            txt_fvr.Text = txt_recieve.Text;
                        }
                        pymtobj.InsOSPaymentHeadBank(recno, Convert.ToDateTime(txt_cheqdate.Text), Convert.ToChar(mode), bid, Convert.ToInt32(hid_year.Value), Convert.ToInt32(hid_favour.Value), Convert.ToDouble(txt_amtrs.Text), Convert.ToInt32(hid_bankid.Value), txt_branch1.Text, txt_cheque.Text, Convert.ToDateTime(chqdate), Convert.ToString(txt_narration.Text), empid, ACPayee, txt_fvr.Text, Convert.ToDouble(txt_rcvamt.Text), txt_curr.Text, Convert.ToDouble(txt_exrate.Text));
                        //pymtobj.InsOSPaymentHeadBank(recno, currdate, mode, branchid, vouyear, rfCustid, Val(txtAmt.Text), bankid, txtBBranch.Text, txtChequeno.Text, chqdate, txtNaration.Text, Login.logempid, ACPayee, Trim(txtfvr.Text), txtrecamount.Text, txtcurr.Text, txtexrate.Text);

                        if (txt_refno.Text.Trim() != "")
                        {
                            pymtobj.InsOSPaymentHead4RefNo(recno, mode, bid, Convert.ToInt32(hid_year.Value), txt_refno.Text.Trim());
                        }
                    }
                }

                txt_recp.Text = recno.ToString();

                SaveAllGrdDetails();



                if (Session["rptype"] == "R")
                {
                    //Logobj.InsLogDetail(empid, 1083, 1, bid, str_mode + " / " + txt_recp.Text);
                    Logobj.InsLogDetail(empid, 1188, 1, bid, str_mode + " / " + txt_recp.Text);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt Details Saved. Receipt # : " + txt_recp.Text + "');", true);
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' Receipt # : " + txt_recp.Text + " ');", true);
                    //arun
                    //  logix.CommanClass.TallyEDIFA.Fn_FATransfer("Remittance-Receipt", recno, recno, "", "");
                }
                else if (Session["rptype"] == "P")
                {
                    //Logobj.InsLogDetail(empid, 1082, 1, bid, str_mode + " / " + txt_recp.Text);
                    Logobj.InsLogDetail(empid, 1189, 1, bid, str_mode + " / " + txt_recp.Text);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Payment Details Saved. Receipt # : " + txt_recp.Text + "');", true);
                    //logix.CommanClass.TallyEDIFA.Fn_FATransfer("Remittance-Payment", recno, recno, "", "");
                }

                //int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                //int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                //int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                //string FADbname = Session["FADbname"].ToString();

                //if (rptype == "P" && str_mode == "C" && Grid_detail.Rows.Count > 0)
                //{

                //}
                //else if (rptype == "P" && str_mode == "B" && Grid_detail.Rows.Count > 0)
                //{

                //}
                //else if (rptype == "R" && str_mode == "P") { }
                //else if (txt_refno.Text == "")
                //{
                //    if (CustAmt != grdTotamt)
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                //        return;
                //    }
                //}
                //else if (grdTotamt > 0)
                //{
                //    if (CustAmt != grdTotamt)
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                //        return;
                //    }
                //}
                //if (rptype == "P")
                //{


                //    for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                //    {
                //        if (Grid_Account.Rows[i].Cells[0].Text == "Charges" || Grid_Account.Rows[i].Cells[0].Text == "Charges")
                //        {
                //            GrdChrgid = chrgobj.GetChargeid(Grid_Account.Rows[i].Cells[1].ToString());
                //            chkledgerid = lobj.ChkLedgeridfrmLedHead(GrdChrgid, "A", FADbname);
                //            if (chkledgerid == 0)
                //            {
                //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' LedgerName " + Grid_Account.Rows[i].Cells[2].ToString() + " Not Found in Financial. You are not able to raise Payment.Contact Your  Finanace Head');", true);
                //            }
                //        }
                //    }
                //}
                //CheckData();
                //if (next == 0)
                //{
                //    return;
                //}
                //int intBnkLedgID = FAObj.Selledgeridforops(FADbname, txt_bank.Text, 'O');
                //if (rptype == "P")
                //{
                //    Boolean Bln_ChkMinMaxAmt = false;
                //    Bln_ChkMinMaxAmt = pymtobj.CheckMedgerMaxMinAmt4Pmt(intBnkLedgID, did, Convert.ToDouble(txt_amtrs.Text), FADbname);
                //    if (Bln_ChkMinMaxAmt == false)
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Closing Balance has been Crossed the maximum limit. You can't able to Issue the Payment');", true);
                //        next = 0;
                //        return;
                //    }
                //}
                //int recno1;
                //DateTime currdate = Convert.ToDateTime(txt_date.Text);
                //cheqdate = Convert.ToInt32(Utility.fn_ConvertDate(txt_cheqdate.Text));
                //int bankid = bankobj.GetBankid(txt_bank.Text);
                //DateTime chqdate = Convert.ToDateTime(txt_cheqdate.Text);
                //recno1 = recobj.GetCRBRNo(bid, str_mode);
                //if (rptype == "R")
                //{

                //    if (str_mode == "C" || str_mode == "P")
                //    {
                //        recobj.InsRecptHeadCash(recno1, currdate, mode, bid, cheqdate, rfcustid, Convert.ToDouble(txt_amtrs.Text), txt_narration.Text, empid);
                //    }
                //    else if (str_mode == "B")
                //    {
                //        recobj.InsRecptHeadBank(recno1, currdate, mode, branchid, cheqdate, rfcustid, Convert.ToDouble(txt_amtrs.Text), bankid, txt_branch1.Text, txt_cheque.Text, chqdate, txt_narration.Text, empid);
                //    }
                //}
                //else if (rptype == "P")
                //{
                //    recno1 = pymtobj.GetCPBPNo(bid, str_mode);
                //    if (str_mode == "C" || str_mode == "P")
                //    {
                //        pymtobj.InsPaymentHeadCash(recno1, currdate, mode, bid, cheqdate, rfcustid, Convert.ToDouble(txt_amtrs.Text), txt_narration.Text, empid);
                //        if (txt_refno.Text != "")
                //        {
                //            pymtobj.InsPaymentHeadcash4RefNo(recno1, mode, bid, cheqdate, txt_refno.Text);
                //        }
                //    }
                //    else if (str_mode == "B")
                //    {
                //        if (txt_fvr.Text == "")
                //        {
                //            txt_fvr.Text = txt_recieve.Text;
                //        }
                //        pymtobj.InsPaymentHeadBank(recno1, currdate, mode, bid, cheqdate, rfcustid, Convert.ToDouble(txt_amtrs.Text), bankid, txt_branch1.Text, txt_cheque.Text, chqdate, txt_narration.Text, empid, ACPayee, txt_fvr.Text);

                //    }
                //}
                //branchid = hrempobj.GetBranchId(did, ddl_branch.Text);
                //objnoc.UpdateNotOverChequeAccounted(branchid, Convert.ToInt32(hid_cheque.Value));
                //txt_recp.Text = recno1.ToString();
                //if (rptype == "P" && str_mode == "C" && Grid_detail.Rows.Count == 0)
                //{
                //    SaveAllGrdDetails4PayCash();
                //}
                //else if (rptype == "R" && str_mode == "p")
                //{
                //    SaveAllGrdDetails4PayCash();
                //}
                //else
                //{
                //    SaveAllGrdDetails();
                //}
                //if (rptype == "R")
                //{
                //    Logobj.InsLogDetail(empid, 268, 1, bid, str_mode + " / " + txt_recp.Text);
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt Details Saved');", true);
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' Receipt # : " + txt_recp.Text + " ');", true);
                //    recno = Convert.ToInt32(txt_recp.Text);
                //    // hid_rid.Value=recno.ToString();
                //    //raj
                //    //if (str_mode == "C")
                //    //{
                //    //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Receipt", recno, recno, "", "");
                //    //}
                //    //else if (str_mode == "B")
                //    //{
                //    //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Receipt", recno, recno, "", "");
                //    //}
                //    //else if (str_mode == "P")
                //    //{
                //    //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Receipt - Petty Cash", recno, recno, "", "");
                //    //}
                //}
                //else if (rptype == "P")
                //{
                //    if (branchpay == "B")
                //    {
                //        Logobj.InsLogDetail(empid, 544, 1, branchid, str_mode + " / " + txt_recp.Text);
                //    }
                //    else
                //    {
                //        Logobj.InsLogDetail(empid, 376, 1, branchid, str_mode + " / " + txt_recp.Text);
                //    }
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Payment Details Saved');", true);
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert(' Payment # : " + txt_recp.Text + " ');", true);
                //    if (str_mode == "C")
                //    {//raj
                //        //logix.CommanClass.TallyEDIFA.Fn_FATransfer("Cash Payment", recno, recno, "", "");
                //    }
                //    else if (str_mode == "B")
                //    {
                //        //logix.CommanClass.TallyEDIFA.Fn_FATransfer("Bank Payment", recno, recno, "", "");
                //    }
                //}
                //btn_save.Enabled = false;
                //CTEnable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
            Session["str_sfs"] = ""; Session["str_sp"] = "";
            int bid = Convert.ToInt32(Session["LoginBranchid"]);
            int did = Convert.ToInt32(Session["LoginDivisionid"]);
            int Vouyear = Convert.ToInt32(txt_recpdate.Text);
            recno = Convert.ToInt32(txt_recp.Text);

            mode_set();
            if (next == 0)
            {
                return;
            }
            if (Session["rptype"] == "R")
                //{
                //    rid = recobj.GetRecrid(recno, bid, mode, Vouyear);

                //}
                //else if (Session["rptype"] == "P")
                //{
                //    rid = pymtobj.GetPaymentid(recno, bid, mode, Vouyear);
                rid = recobj.GetOSRecrid(recno, bid, mode, Vouyear);

            //}
            if (Session["rptype"] == "R")
            {
                if (NewReceiptRpt.Value == "Y")
                {
                    if (txt_recp.Text != "")
                    {
                        if (txt_recp.Text.Trim() != "")
                        {
                            str_Script = "window.open('../Reportasp/RemittanceReceiptFA.aspx?ReceiptId=" + rid + "&vouyear=" + txt_recpdate.Text + "&Mode=" + mode + "&Type=" + Session["rptype"] + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Receipt", str_Script, true);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 268, 3, bid, str_mode + " / " + txt_recp.Text);
                    }
                }
                else
                {

                    if (txt_recp.Text != "")
                    {
                        if (str_mode == "C")
                        {
                            str_RptName = "ReceiptCash4OS.rpt";

                        }
                        else
                        {
                            str_RptName = "ReceiptBank4OS.rpt";


                        }
                        //else
                        //{
                        //    str_RptName = "ReceiptBank.rpt";
                        //    Session["str_sfs"] = "{ReceiptHead.receiptid}=" + rid + " and {ReceiptAgainstInvoice.rptype}='R'";
                        //} sf = "{ACOSReceiptHead.receiptid}=" & rid & " and {ACOSReceiptPayment.rptype}='R'"
                        Session["str_sfs"] = "{ACOSReceiptHead.receiptid}=" + rid + " and {ACOSReceiptPayment.rptype}='R'";

                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Reciepts", str_Script, true);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 268, 3, bid, str_mode + " / " + txt_recp.Text);
                        //Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }

                    else
                    {
                        if (ddl_mode.Text != "MODE")
                        {
                            if (str_mode == "C")
                            {

                                str_RptName = "ReceiptCashReg4OS.rpt";
                                Session["str_sfs"] = "{ACOSReceiptodeHead.m}='C' and {ACOSReceiptHead.branchid}=" + bid + " and {ACOSReceiptHead.vouyear}=" + txt_recpdate.Text;
                                str_sp = "title=Cash Receipts~branch=";
                            }
                            else
                            {

                                str_RptName = "ReceiptBankReg4OS.rpt";
                                Session["str_sfs"] = "{ACOSReceiptHead.mode}='B' and {ACOSReceiptHead.branchid}=" + bid + " and {ACOSReceiptHead.vouyear}=" + txt_recpdate.Text;
                                str_sp = "title=Remittance Receipts - Bank~branch=";

                            }

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Reciepts", str_Script, true);
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1187, 3, bid, str_mode + " / All ReceiptNo./V");
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Select Mode');", true);
                            return;

                        }
                    }

                }
            }
            else if (Session["rptype"] == "P")
            {
                rid = pymtobj.GetOSPaymentid(recno, bid, mode, Vouyear);
                if (NewPaymentRpt.Value == "Y")
                {
                    if (txt_recp.Text != "")
                    {
                        if (txt_recp.Text.Trim() != "")
                        {
                            str_Script = "window.open('../Reportasp/RemittanceReceiptFA.aspx?ReceiptId=" + rid + "&vouyear=" + txt_recpdate.Text + "&Mode=" + mode + "&Type=" + Session["rptype"] + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Receipt", str_Script, true);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1188, 3, bid, str_mode + " / " + txt_recp.Text + "/V");
                    }
                }
                else
                {
                    if (txt_recp.Text != "")
                    {
                        if (str_mode == "C")
                        {
                            str_RptName = "PaymentCash.rpt";

                        }
                        else
                        {
                            if (did == 1)
                            {
                                if (txt_refno.Text != "")
                                {
                                    str_RptName = "PaymentBank4OSref.rpt";
                                    str_sf = "{ACOSPaymentHead.paymentid}=" + rid;
                                    Session["str_sfs"] = str_sf;
                                }
                                else
                                {
                                    str_RptName = "PaymentBank4OS.rpt";
                                    Session["str_sfs"] = "{ACOSPaymentHead.paymentid}=" + rid + " and {ACOSReceiptPayment.rptype}='P'";
                                }
                                //str_RptName = "PaymentBank4OS.rpt";
                                //Session["str_sfs"] = "{ACOSPaymentHead.paymentid}=" + rid;
                            }
                            else
                            {
                                if (txt_refno.Text != "")
                                {
                                    str_RptName = "PaymentBank4OS2and4ref.rpt";
                                    str_sf = "{ACOSPaymentHead.paymentid}=" + rid;
                                    Session["str_sfs"] = str_sf;
                                }
                                else
                                {
                                    str_RptName = "PaymentBank4OS2and4.rpt";
                                    Session["str_sfs"] = "{ACOSPaymentHead.paymentid}=" + rid + " and {ACOSReceiptPayment.rptype}='P'";
                                }
                                //str_RptName = "PaymentBank4OS2and4.rpt";
                            }




                        }
                        //   Session["str_sfs"] = str_sf;
                        // Session["str_sfs"] = "{ACOSPaymentHead.paymentid}=" + rid + " and {ACOSReceiptPayment.rptype}='P'";

                        // str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //
                        Session["str_sp"] = str_sp;
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Reciepts", str_Script, true);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1188, 3, bid, str_mode + " / " + txt_recp.Text + "/V");
                    }
                    else
                    {
                        if (ddl_mode.Text != "MODE")
                        {
                            if (str_mode == "C")
                            {

                                str_RptName = "PaymentCashReg.rpt";
                                Session["str_sfs"] = "{PaymentHead.mode}='C' and {PaymentHead.branchid}=" + bid + " and {PaymentHead.vouyear}=" + txt_recpdate.Text;
                                str_sp = "title=Cash Payment";
                            }
                            else
                            {


                                str_RptName = "PaymentBankReg4OS.rpt";
                                Session["str_sfs"] = sf = "{ACOSPaymentHead.mode}='B' and {ACOSPaymentHead.branchid}=" + bid + " and {ACOSPaymentHead.vouyear}=" + txt_recpdate.Text;
                                str_sp = "title=Bank Payment";

                            }


                            // str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                            ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Reciepts", str_Script, true);
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1188, 3, bid, str_mode + " / All ReceiptNo./V");
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Select Mode');", true);
                            return;

                        }
                    }
                }
            }
        }


        protected void btn_delete_Click(object sender, EventArgs e)
        {

        }

        protected void Calc_recamount()
        {

            double total;
            double totalamt;
            if (txt_rcvamt.Text.Trim().Length > 0 || txt_amtrs.Text.Length > 0)
            {
                double amt = Convert.ToDouble(txt_exrate.Text);
                double amt1 = Convert.ToDouble(txt_rcvamt.Text);
                total = amt * amt1;
                totalamt = Convert.ToDouble(total);
                txt_amtrs.Text = totalamt.ToString("#0.00");
            }
        }

        protected void txt_curr_TextChanged(object sender, EventArgs e)
        {
            if (txt_curr.Text.ToUpper() == "INR")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Currency INR Not Accepted');", true);
                txt_curr.Text = "";
                txt_curr.Focus();
            }

            if (txt_curr.Text.Trim() == "")
            {
                txt_curr.Text = txt_curr.Text.ToUpper();
            }
            txt_exrate.Text = (INVOICEobj.GetOSExRate(txt_curr.Text.Trim(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_cheqdate.Text)), ViewState["extype"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]))).ToString("#0.00");

            if (txt_exrate.Text == "0.00")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Ex. Rate Not Available');", true);
                txt_curr.Text = "";
                txt_curr.Focus();
                txt_exrate.Text = "";
            }


            txt_rcvamt.Focus();
        }

        protected void txt_rcvamt_TextChanged(object sender, EventArgs e)
        {

            Calc_recamount();
            txt_cheque.Focus();
        }

        protected void txt_exrate_TextChanged(object sender, EventArgs e)
        {
            Calc_recamount();
        }

        protected void txt_recieve_TextChanged(object sender, EventArgs e)
        {

            //txt_cust_TextChanged(sender, e);
            //txt_curr.Focus();
            //int count1 = 0;
            //if (rptype == "P")
            //{
            //    count1 = pymtobj.Getosreceithead(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), "P");
            //}
            //else
            //{
            //    count1 = pymtobj.Getosreceithead(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), "R");
            //}
            //if (count1 != 0)
            //{
            //    txt_cheque.Text = "REMIT" + count1 + "/" + txt_recpdate.Text.Substring(2, 2);
            //}


        }

        protected void txt_dedu_amt_TextChanged(object sender, EventArgs e)
        {
            if (txt_deduction.Text != "" && txt_dedu_amt.Text != "")
            {
                // txtTdsAmt.Text = Val(txtdolaramt.Text) * Val(txtexrate.Text)
                double fist = Convert.ToDouble(txt_dedu_amt.Text);
                double second = Convert.ToDouble(txt_exrate.Text);
                //int fi = Convert.ToInt32(fist);
                //int se = Convert.ToInt32(second);
                //int toal = fi * se;
                double toal = fist * second;
                txttdsAmt.Text = toal.ToString("#0.00");
            }
            txttdsAmt_TextChanged(sender, e);
            // txttdsAmt.Focus();
        }

        protected void txttdsAmt_TextChanged(object sender, EventArgs e)
        {
            if (txt_dedu_amt.Text != "")
            {
                if (txt_amtrs.Text == "")
                {
                    txt_amtrs.Text = "0.00";
                }
                glamt = Convert.ToDouble(hid_glaft.Value);
                if (Session["rptype"].ToString() == "R")
                {

                    glamt = glamt - Convert.ToDouble(txttdsAmt.Text);
                }
                else if (Session["rptype"].ToString() == "P")
                {

                    glamt = glamt + Convert.ToDouble(txttdsAmt.Text);
                }
                if (Convert.ToDouble(txt_amtrs.Text) > glamt)
                {
                    Es = Convert.ToDouble(txt_amtrs.Text) - glamt;
                    txt_excess_amt.Text = Es.ToString("#0.00");
                }
                else if (Convert.ToDouble(txt_amtrs.Text) < glamt)
                {
                    Es = glamt - Convert.ToDouble(txt_amtrs.Text);
                    txt_excess_amt.Text = (-Es).ToString("#0.00");
                }
                else
                {
                    Es = 0;
                    txt_excess_amt.Text = (0).ToString("#0.00");
                }
            }
            btn_deduct_add.Focus();
        }

        protected void txt_bank_TextChanged(object sender, EventArgs e)
        {
            txt_branch1.Focus();
        }

        protected void txt_deduction_TextChanged(object sender, EventArgs e)
        {
            txt_dedu_amt.Focus();
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
                                        amt = Convert.ToDouble(Grid_detail.Rows[i].Cells[4].Text);
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

        protected void Grid_detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            //double grd_amt;
            //int index;
            //int ouput;
            //if (hid_gridname.Value != "")
            //{
            //    index = Convert.ToInt32(hid_gridname.Value);
            //    if (index + 1 == Grid_detail.Rows.Count)
            //    {
            //        return;
            //    }

            //    TextBox txt1 = ((TextBox)Grid_detail.Rows[index].FindControl("txt_receiptamount"));
            //    string value = txt1.Text;
            //    if (value != "")
            //    {
            //        if (double.TryParse(value, out grd_amt))
            //        {
            //            string number = Grid_detail.Rows[index].Cells[4].Text;
            //            if (Convert.ToDouble(number) < Convert.ToDouble(value))
            //            {
            //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt/Payment Amount Must be Less Than or Equal to Voucher Amount');", true);
            //                ((TextBox)Grid_detail.Rows[index].Cells[7].FindControl("txt_receiptamount")).Text = "0.00";
            //            }
            //        }
            //        else
            //        {

            //        }

            //    }
            //    else
            //    {

            //    }


            //    //if (hid_grid.Value == "" )
            //    //{
            //    //    index = Grid_detail.SelectedRow.RowIndex;
            //    //}else
            //    //{
            //    //    index = Convert.ToInt32(hid_grid.Value);
            //    //}



            //    //if(Grid_detail.Rows[index].Cells[4].Text=="&nbsp")
            //    //{
            //    //    Grid_detail.Rows[index].Cells[4].Text="";
            //    //}

            //}
        }



        protected void txt_narration_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_cust_amt_TextChanged(object sender, EventArgs e)
        {
            double ES;
            //     If txtTdsAmt.Text <> "" Then
            //    glamt = glamt - Val(txtTdsAmt.Text)
            //    If Val(txtAmt.Text) > glamt Then
            //        ES = Val(txtAmt.Text) - glamt
            //        txtES.Text = Format(ES, "0.00")
            //    ElseIf Val(txtAmt.Text) < glamt Then
            //        ES = glamt - Val(txtAmt.Text)
            //        txtES.Text = Format(-ES, "0.00")
            //    End If
            //End If

            //BtnAddTax.Focus()
            //if (txt_cust_amt.Text=="")
            //{
            //    txt_cust_amt.Text = "0.00";
            //}
            //if (txt_amtrs.Text == "")
            //{
            //    txt_amtrs.Text = "0.00";
            //}

            //if (txt_cust_amt.Text != "")
            //{
            //    glamt = glamt - Convert.ToDouble(txt_cust_amt.Text);
            //    if (Convert.ToDouble(txt_amtrs.Text) > glamt)
            //    {
            //        ES = Convert.ToDouble(txt_amtrs.Text) - glamt;
            //        txt_excess_amt.Text = ES.ToString("#.00");
            //    }
            //    else if (Convert.ToDouble(txt_amtrs.Text) < glamt)
            //    {
            //        ES = glamt - Convert.ToDouble(txt_amtrs.Text);
            //        txt_excess_amt.Text = (-ES).ToString("#.00");
            //    }
            //}
            //btn_deduct_add.Focus();

            for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
            {
                TextBox txt1 = ((TextBox)Grid_detail.Rows[index].FindControl("txt_receiptamount"));
                string value = txt1.Text.TrimStart().TrimEnd().Trim();
                if (Grid_detail.Rows[i].Cells[6].Text == "&nbsp;")
                {
                    Grid_detail.Rows[i].Cells[6].Text = "0";
                }
                if (Convert.ToDouble(value) > Convert.ToDouble(Grid_detail.Rows[i].Cells[6].Text))
                {
                    Es = Convert.ToDouble(value) - Convert.ToDouble(Grid_detail.Rows[i].Cells[6].Text);
                    txt_excess_amt.Text = (-Es).ToString("#0.00");
                }
                else
                {
                    Es = Convert.ToDouble(Grid_detail.Rows[i].Cells[6].Text) - Convert.ToDouble(value);
                    txt_excess_amt.Text = (Es).ToString("#0.00");
                }

            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {




        }

        protected void Grid_Account_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


        }

        protected void Grid_Account_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (hfWasConfirmed.Value == "true")
                {
                    if (e.CommandName == "Delete")
                    {
                        ImageButton Img_delete = (ImageButton)e.CommandSource;
                        GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;


                        string text;
                        int ccid;
                        int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                        int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                        int Vouyear = Convert.ToInt32(txt_recpdate.Text);
                        mode_set();
                        //int Index = Grid_Account.SelectedRow.RowIndex;
                        DataTable dt1 = new DataTable();
                        dt1 = (DataTable)ViewState["CurrentData"];
                        if (Grid_Account.Rows[grd.RowIndex].Cells[0].Text == "Customer")
                        {
                            //rid = pymtobj.GetPaymentid(Convert.ToInt32(txt_recp.Text), bid, Convert.ToChar(str_mode), Vouyear);
                            if (txt_recp.Text != "" && rid == 0)
                            {
                                ccid = Convert.ToInt32(Grid_Account.Rows[grd.RowIndex].Cells[0].Text);

                                if (Session["rptype"] == "R")
                                {
                                    recobj.DelOSCustChrgs(rid, ccid, "Cu");
                                }
                                else if (Session["rptype"] == "P")
                                {
                                    pymtobj.DelOSCustChrgsPymt(rid);
                                }
                            }
                            dt1.Rows[grd.RowIndex].Delete();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted Succesfully!!!');", true);

                        }

                        if (Grid_Account.Rows[grd.RowIndex].Cells[0].Text == "Charges")
                        {
                            // rid = pymtobj.GetPaymentid(Convert.ToInt32(txt_recp.Text), bid, Convert.ToChar(str_mode), Vouyear);
                            if (txt_recp.Text != "" && rid == 0)
                            {
                                ccid = Convert.ToInt32(Grid_Account.Rows[grd.RowIndex].Cells[0].Text);

                                if (Session["rptype"] == "R")
                                {
                                    recobj.DelOSCustChrgs(rid, ccid, "Ch");
                                }
                                else if (Session["rptype"] == "P")
                                {
                                    pymtobj.DelOSCustChrgsPymt(rid);
                                }
                            }
                            dt1.Rows[grd.RowIndex].Delete();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted Succesfully!!!');", true);

                        }



                        if ((Grid_Account.Rows[grd.RowIndex].Cells[0].Text == "Ex.Rate Gain") || (Grid_Account.Rows[grd.RowIndex].Cells[0].Text == "Ex.Rate Loss"))
                        {
                            //  rid = pymtobj.GetPaymentid(Convert.ToInt32(txt_recp.Text), bid, Convert.ToChar(str_mode), Vouyear);
                            if (txt_recp.Text != "" && rid == 0)
                            {
                                ccid = Convert.ToInt32(Grid_Account.Rows[grd.RowIndex].Cells[0].Text);

                                if (Session["rptype"] == "R")
                                {
                                    recobj.DelOSCustChrgs(rid, ccid, "Ch");
                                }
                                else if (Session["rptype"] == "P")
                                {
                                    pymtobj.DelOSCustChrgsPymt(rid);
                                }
                            }
                            dt1.Rows[grd.RowIndex].Delete();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted Succesfully!!!');", true);

                        }
                        Grid_Account.DataSource = dt1;
                        Grid_Account.DataBind();

                    }

                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grid_detail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dtTemp = new DataTable();
            dtTemp = (DataTable)Session["value"];

            if (dtTemp.Rows.Count > 0)
            {
                dtTemp.Rows[e.RowIndex].Delete();
                Grid_detail.DataSource = dtTemp;
                Grid_detail.DataBind();
            }
        }

        protected void txt_cheqdate_TextChanged(object sender, EventArgs e)
        {
            dTTime = Convert.ToDateTime(Logobj.GetDate());
            if (Convert.ToDateTime(Utility.fn_ConvertDate(txt_cheqdate.Text)) < dTTime.AddMonths(-6))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Cheque Date');", true);
                txt_cheqdate.Focus();
            }
            if (Convert.ToDateTime(Utility.fn_ConvertDate(txt_cheqdate.Text)) > dTTime)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Cheque Date');", true);
                txt_cheqdate.Focus();
            }
        }

        protected void Grid_detail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select") TxtClick
            //{
            //    rowIndex = Convert.ToInt32(e.CommandArgument);
            //    Grid_detail_SelectedIndexChanged(sender, e);
            //}

            if (e.CommandName == "TxtClick")
            {


                for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                {

                    TextBox txtvale = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                    if (txtvale.Text == "")
                    {
                        txtvale.Text = "0.00";
                    }
                }

                rowIndex = Convert.ToInt32(e.CommandArgument);
                TextBox txt1 = ((TextBox)Grid_detail.Rows[rowIndex].FindControl("txt_receiptamount"));
                //string value = txt1.Text;
                if (txt1.Text == "0.00")
                {
                    txt1.Text = "";
                    txt1.Focus();
                }
                else
                {
                    txt1.Focus();
                }


            }
        }


        protected void Chkrecpfc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double PA_Amount = 0, TDS_Amount = 0;
                CheckBox Chk1 = sender as CheckBox;
                GridViewRow row1 = (GridViewRow)Chk1.NamingContainer;
                List<string> ItemText = null;
                Boolean Check = false;


                if (row1.RowIndex != -1)
                {
                    int rowindex = 0;
                    double amt = 0.0;
                    Session["chkrpt"] = "false";
                    Check = false;
                    if (Session["chkrpt"].ToString() == "false")
                    {
                        foreach (GridViewRow row in Grid_detail.Rows)
                        {
                            CheckBox Chk = (CheckBox)Grid_detail.Rows[row.RowIndex].FindControl("Chkrecpfc");
                            if (Chk.Checked == true)
                            {
                                if (Grid_detail.Rows[row1.RowIndex].Cells[2].Text != "On Account")
                                {
                                    amt = Convert.ToDouble(Grid_detail.Rows[row1.RowIndex].Cells[4].Text);

                                    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row1.RowIndex].FindControl("txt_receiptamount"));
                                    TxtAmount.Text = amt.ToString();
                                    TxtAmount.Focus();
                                    rowindex = row1.RowIndex;
                                    calculation(rowindex);
                                    Grid_detail.Rows[row1.RowIndex].BackColor = System.Drawing.Color.Empty;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CheckBox OnAccount", "alertify.alert('Kindly Enter the On Account Amount in TextBox');", true);
                                    TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row1.RowIndex].FindControl("txt_receiptamount"));
                                    TxtAmount.Focus();
                                    return;
                                }
                            }
                        }
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
                                    if (Grid_detail.Rows[row.RowIndex].Cells[2].Text != "On Account")
                                    {
                                        amt = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[4].Text);
                                        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                        TxtAmount.Text = amt.ToString();
                                        rowindex = row.RowIndex;
                                        calculation(rowindex);
                                        TxtAmount.Focus();
                                        TxtAmount.Focus();
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CheckBox OnAccount", "alertify.alert('Kindly Enter the On Account Amount in TextBox');", true);
                                        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                        TxtAmount.Focus();
                                        return;
                                    }


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
                                    if (Grid_detail.Rows[row.RowIndex].Cells[2].Text != "On Account")
                                    {
                                        amt = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[4].Text);
                                        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                        TxtAmount.Text = amt.ToString();

                                        rowindex = row.RowIndex;
                                        calculation(rowindex);
                                        TxtAmount.Focus();
                                        TxtAmount.Focus();
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "CheckBox OnAccount", "alertify.alert('Kindly Enter the On Account Amount in TextBox');", true);
                                        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                        TxtAmount.Focus();
                                        return;
                                    }

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
                    //Hide by Jayashree Vadivelan bec check box empty when we check the data        //30/05/2022
                    //else
                    //{
                    //    double amt = 0.0;
                    //    Session["chkrpt"] = "false";
                    //    Check = false;

                    //    if (Session["chkrpt"].ToString() == "false" && Grid_detail.Rows[row.RowIndex].Cells[2].Text != "On Account")
                    //    {

                    //        TextBox TxtAmount = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                    //        TxtAmount.Text = amt.ToString();
                    //        TxtAmount.Focus();
                    //        calculation(row.RowIndex);
                    //        Grid_detail.Rows[row.RowIndex].BackColor = System.Drawing.Color.Empty;
                    //    }
                    //}

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        public void calculation(int rowindex)
        {
            try
            {
                if (txt_exrate.Text == "")
                {
                    txt_exrate.Text = "0.00";
                }

                if (txt_amtrs.Text == "")
                {
                    txt_amtrs.Text = "0.00";
                }


                string IE = "";
                double inc = 0, exp = 0, fcamount = 0.0, totalince = 0.0, totalexpce = 0.0, val = 0.0;
                double GrdAmnt;
                int GridCustID = 0;
                int RowIndex = rowindex;//((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
                TextBox TxtAmount = ((TextBox)Grid_detail.Rows[RowIndex].FindControl("txt_receiptamount"));
                if (Grid_detail.Rows[RowIndex].Cells[14].Text != "")
                {
                    GridCustID = Convert.ToInt32(Grid_detail.Rows[RowIndex].Cells[14].Text);
                }


                if (TxtAmount.Text == "")
                {
                    TxtAmount.Text = "0.00";
                }

                if (Grid_detail.Rows[RowIndex].Cells[4].Text.ToString() != null)
                {
                    if (double.TryParse(Grid_detail.Rows[RowIndex].Cells[4].Text.ToString(), out GrdAmnt))
                    {
                        if (Convert.ToDouble(Grid_detail.Rows[RowIndex].Cells[4].Text.ToString()) < Convert.ToDouble(TxtAmount.Text.TrimStart().TrimEnd().Trim()))
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


                if (ViewState["dtINV"] != null && !ViewState["dtINV"].Equals("-1")) ////03-08-2022
                {
                    DataTable dtNew = new DataTable();
                    dtNew = (DataTable)ViewState["dtINV"];

                    if (dtNew.Rows.Count > 0)
                    {
                        for (int j = 0; j <= dtNew.Rows.Count - 1; j++)
                        {
                            TextBox txt_Receipt = (TextBox)Grid_detail.Rows[j].FindControl("txt_receiptamount");
                            if (txt_Receipt.Text != "")
                            {
                                dtNew.Rows[j]["recptfcamt"] = txt_Receipt.Text.TrimStart().TrimEnd().Trim();

                            }
                        }
                    }
                    ViewState["dtINV"] = dtNew;
                }


                if (Session["rptype"].ToString() == "P")
                {
                    hid_customeridNew.Value = Grid_detail.Rows[rowindex].Cells[14].Text;
                    exr = Convert.ToDouble((Grid_detail.Rows[rowindex].Cells[5].Text));
                    TextBox txt = ((TextBox)Grid_detail.Rows[rowindex].FindControl("txt_receiptamount"));
                    fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    grdinramt = exr * fcamount;
                    Grid_detail.Rows[rowindex].Cells[8].Text = grdinramt.ToString("#0.00");
                    foreach (GridViewRow Row in Grid_detail.Rows)
                    {
                        RowVouType = Row.Cells[9].Text.Trim();
                    }

                    //for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                    //{
                    foreach (GridViewRow row in Grid_detail.Rows) ////30-07-2022 hari
                    {
                        CheckBox Chk = (CheckBox)Grid_detail.Rows[row.RowIndex].FindControl("Chkrecpfc");
                        if (Chk.Checked == true)
                        {
                            IE = Grid_detail.Rows[row.RowIndex].Cells[9].Text.Trim();

                            if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                            {

                                TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                if (txt1.Text == "")
                                {
                                    txt1.Text = "0.00";
                                }
                                inc = inc + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                totalince = totalince + val;
                            }
                            else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS" || IE == "O") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                            {

                                TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                if (txt1.Text == "")
                                {
                                    txt1.Text = "0.00";
                                }
                                exp = exp + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                totalexpce = totalexpce + val;
                            }

                            // For Journal
                            if (Session["rptype"].ToString() == "R")
                            {
                                if (IE == "J")
                                {
                                    if ((Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                                    {
                                        val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                        //// TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                        // exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                                        TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                        // fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                        // grdinramt = exr * fcamount;
                                        // Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");

                                        if (txt1.Text == "")
                                        {
                                            txt1.Text = "0.00";
                                        }
                                        inc = inc + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        totalince = totalince + val;
                                    }
                                    if ((Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                                    {
                                        val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                        // TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                        //exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                                        TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                        //fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                        //grdinramt = exr * fcamount;
                                        //Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");

                                        if (txt1.Text == "")
                                        {
                                            txt1.Text = "0.00";
                                        }
                                        exp = exp + Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                        totalexpce = totalexpce + val;
                                    }
                                }
                            }
                            else if (Session["rptype"].ToString() == "P")
                            {
                                if (IE == "J")
                                {
                                    if ((Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                                    {
                                        val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                        //  TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                        //exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                                        TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                        //fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                        //grdinramt = exr * fcamount;
                                        //Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");

                                        if (txt1.Text == "")
                                        {
                                            txt1.Text = "0.00";
                                        }
                                        inc = inc + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        totalince = totalince + val;
                                    }
                                    else if ((Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                                    {
                                        val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                        // TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                        //exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                                        TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                        //fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                        //grdinramt = exr * fcamount;
                                        //Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");

                                        if (txt1.Text == "")
                                        {
                                            txt1.Text = "0.00";
                                        }
                                        exp = exp + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        totalexpce = totalexpce + val;
                                    }
                                }
                            }
                        }
                    }
                    //}
                    txt_cust_amt.Text = (exp - inc).ToString("#0.00");
                    hid_total.Value = (totalexpce - totalince).ToString("#0.00");
                }
                else if (Session["rptype"].ToString() == "R")
                {
                    hid_customeridNew.Value = Grid_detail.Rows[rowindex].Cells[14].Text;
                    exr = Convert.ToDouble((Grid_detail.Rows[rowindex].Cells[5].Text));
                    TextBox txt = ((TextBox)Grid_detail.Rows[rowindex].FindControl("txt_receiptamount"));
                    fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                    grdinramt = exr * fcamount;
                    Grid_detail.Rows[rowindex].Cells[8].Text = grdinramt.ToString("#0.00");
                    foreach (GridViewRow Row in Grid_detail.Rows)
                    {
                        RowVouType = Row.Cells[9].Text.Trim();
                    }

                    foreach (GridViewRow row in Grid_detail.Rows)
                    {
                        CheckBox Chk = (CheckBox)Grid_detail.Rows[row.RowIndex].FindControl("Chkrecpfc");
                        if (Chk.Checked == true)
                        {
                            //for (int i = 0; i <= Grid_detail.Rows.Count - 1; i++)
                            //{
                            //foreach (GridViewRow row in Grid_detail.Rows)
                            //{
                            //    CheckBox Chk = (CheckBox)Grid_detail.Rows[row.RowIndex].FindControl("Chkrecpfc");
                            //    if (Chk.Checked == true)
                            //    {
                            IE = Grid_detail.Rows[row.RowIndex].Cells[9].Text.Trim();

                            if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "O" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                            {
                                val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                // TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                //exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                //fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                //grdinramt = exr * fcamount;
                                //Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");
                                if (txt1.Text == "")
                                {
                                    txt1.Text = "0.00";
                                }
                                inc = inc + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim()); totalince = totalince + val;
                            }
                            else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                            {
                                val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                //TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                //exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                                TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                //fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                //grdinramt = exr * fcamount;
                                //Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");
                                if (txt1.Text == "")
                                {
                                    txt1.Text = "0.00";
                                }
                                exp = Convert.ToDouble(exp) + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim()); totalexpce = totalexpce + val;
                            }

                            if (IE == "J")
                            {
                                if ((Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Dr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                                {
                                    val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                    // TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                    //exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                                    TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                    //fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                    //grdinramt = exr * fcamount;
                                    //Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");
                                    if (txt1.Text == "")
                                    {
                                        txt1.Text = "0.00";
                                    }
                                    inc = inc + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim()); totalince = totalince + val;
                                }
                                if ((Grid_detail.Rows[row.RowIndex].Cells[13].Text == "Cr") && (GridCustID == Convert.ToInt32(Grid_detail.Rows[row.RowIndex].Cells[14].Text)))
                                {
                                    val = Convert.ToDouble(Grid_detail.Rows[row.RowIndex].Cells[8].Text);
                                    //TextBox txt = ((TextBox)Grid_detail.Rows[i].FindControl("txt_receiptamount"));
                                    //exr = Convert.ToDouble((Grid_detail.Rows[index].Cells[5].Text));
                                    TextBox txt1 = ((TextBox)Grid_detail.Rows[row.RowIndex].FindControl("txt_receiptamount"));
                                    //fcamount = Convert.ToDouble(txt.Text.TrimStart().TrimEnd().Trim());
                                    //grdinramt = exr * fcamount;
                                    //Grid_detail.Rows[index].Cells[8].Text = grdinramt.ToString("#0.00");
                                    if (txt1.Text == "")
                                    {
                                        txt1.Text = "0.00";
                                    }
                                    exp = exp + Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim()); totalexpce = totalexpce + val;
                                }
                            }
                        }
                    }
                    //}
                    txt_cust_amt.Text = (inc - exp).ToString("#0.00");
                    hid_total.Value = (totalince - totalexpce).ToString("#0.00");
                }
                gainlosscalc();
                for (int j = 0; j <= Grid_Account.Rows.Count - 1; j++)
                {
                    if (Grid_Account.Rows[j].Cells[0].Text == "Customer")
                    {
                        if (Grid_Account.Rows[j].Cells[4].Text != "")
                        {
                            if (GridCustID == Convert.ToInt32(Grid_Account.Rows[j].Cells[4].Text))
                            {
                                if (GridCustID != Convert.ToInt32(Grid_Account.Rows[j].Cells[4].Text))
                                {
                                    //Grid_Account.Rows[j].Cells[2].Text = txt_cust_amt.Text.ToString();
                                }
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
                            if (Grid_Account.Rows[a].Cells[3].Text != "")
                            {
                                dt_GridAccount.Rows[a]["amount"] = Grid_Account.Rows[a].Cells[3].Text;
                            }
                        }
                        ViewState["CurrentData"] = dt_GridAccount;
                    }
                }

                double Total_Amount = 0.0, totalfcmat = 0.0;
                for (int i = 0; i <= Grid_Account.Rows.Count - 1; i++)
                {
                    totalfcmat = totalfcmat + Convert.ToDouble(Grid_Account.Rows[i].Cells[2].Text);
                    Total_Amount = Total_Amount + Convert.ToDouble(Grid_Account.Rows[i].Cells[3].Text);
                }
                txt_total.Text = string.Format("{0:0.00}", totalfcmat);
                txt_total1.Text = string.Format("{0:0.00}", Total_Amount);

            }
            catch (Exception EX)
            {
                string message = EX.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
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


        private void OBBreakUp4rectpmt()
        {
            //DataAccess.Accounts.Recipts Bank_Obj = new DataAccess.Accounts.Recipts();
            DataTable dtINV = new DataTable();
            int ledger_id, a = 0;
            DataTable dtINV3 = new DataTable();
            DataTable dttempOSDn = new DataTable();

            DataRow dtrow;
            int r = 0;
            if (hid_favour.Value != "")
            {

                ledger_id = Convert.ToInt32(hid_favour.Value);
                dtINV3 = Bank_Obj.RecPaymCalc4OBBreakupOS(ledger_id, did);
                DataTable dttemp3 = new DataTable();

                if (ViewState["dtINV"] != null)
                {
                    dttempOSDn = ViewState["dtINV"] as DataTable;
                    r = dttempOSDn.Rows.Count;
                }


                if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                {

                    dttempOSDn.Columns.Add("branchid", typeof(string));
                    dttempOSDn.Columns.Add("branch", typeof(string));
                    dttempOSDn.Columns.Add("invoiceno", typeof(string));
                    dttempOSDn.Columns.Add("curr", typeof(string));
                    dttempOSDn.Columns.Add("fcamt", typeof(string));
                    dttempOSDn.Columns.Add("exrate", typeof(string));
                    dttempOSDn.Columns.Add("vamount", typeof(string));
                    dttempOSDn.Columns.Add("tamount", typeof(string));

                    dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                    dttempOSDn.Columns.Add("voutype", typeof(string));
                    dttempOSDn.Columns.Add("vouno", typeof(string));
                    dttempOSDn.Columns.Add("tds", typeof(string));
                    dttempOSDn.Columns.Add("ravouyear", typeof(string));
                    dttempOSDn.Columns.Add("ltype", typeof(string));
                    dttempOSDn.Columns.Add("customerid", typeof(string));
                    dttempOSDn.Columns.Add("customername", typeof(string));
                }

                for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                {
                    dtrow = dttempOSDn.NewRow();
                    dttempOSDn.Rows.Add();
                    dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                    dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();

                    if (dtINV3.Rows[i][8].ToString().Trim() == "OI")
                    {
                        dttempOSDn.Rows[r][2] = "OB SI - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OD")
                    {
                        dttempOSDn.Rows[r][2] = "OB OSDN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OV")
                    {
                        dttempOSDn.Rows[r][2] = "OB DN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OX")
                    {
                        dttempOSDn.Rows[r][2] = "OB ADN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OP")
                    {
                        dttempOSDn.Rows[r][2] = "OB PI - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OC")
                    {
                        dttempOSDn.Rows[r][2] = "OB OSCN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OE")
                    {
                        dttempOSDn.Rows[r][2] = "OB CN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OS")
                    {
                        dttempOSDn.Rows[r][2] = "OB ACN - " + dtINV3.Rows[i][2].ToString();
                    }

                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OF") // Vino [05-03-2024]
                    {
                        dttempOSDn.Rows[r][2] = "OB SI OC - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OG")
                    {
                        dttempOSDn.Rows[r][2] = "OB PI OC - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OH")
                    {
                        dttempOSDn.Rows[r][2] = "OB BS OC - " + dtINV3.Rows[i][2].ToString();
                    }

                    //dttempOSDn.Rows[r][2] = "OSDN - " + dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();
                    fcAmount = dtINV3.Rows[i]["fcamt"].ToString();
                    dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                    exrate = dtINV3.Rows[i]["exrate"].ToString();
                    dttempOSDn.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                    dttempOSDn.Rows[r][6] = dtINV3.Rows[i][6].ToString();
                    dttempOSDn.Rows[r][7] = dtINV3.Rows[i][10].ToString();
                    dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                    dttempOSDn.Rows[r][9] = dtINV3.Rows[i][8].ToString();
                    dttempOSDn.Rows[r][10] = dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][12] = dtINV3.Rows[i][9].ToString();
                    dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value); // dtINV3.Rows[i]["customerid"].ToString();
                    dttempOSDn.Rows[r][15] = txt_cust.Text; // dtINV3.Rows[i]["customerid"].ToString();
                    r = r + 1;
                }

                Grid_detail.DataSource = dttempOSDn;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttempOSDn;

                //if (ViewState["dtPayment"] != null && !ViewState["dtPayment"].Equals("-1"))
                //{
                //    dttemp3 = (DataTable)ViewState["dtPayment"];
                //    a = dttemp3.Rows.Count;
                //}

                //if (dtINV.Rows.Count > 0)
                //{
                //    if (a == 0)
                //    {
                //        dttemp3.Columns.Add("branchHide", typeof(string));
                //        dttemp3.Columns.Add("branch", typeof(string));
                //        dttemp3.Columns.Add("invoiceno", typeof(string));
                //        dttemp3.Columns.Add("iamount", typeof(string));
                //        dttemp3.Columns.Add("ramount", typeof(string));
                //        dttemp3.Columns.Add("voutype", typeof(string));
                //        dttemp3.Columns.Add("vouno", typeof(string));
                //        dttemp3.Columns.Add("tds", typeof(string));
                //        dttemp3.Columns.Add("ravouyear", typeof(string));
                //        dttemp3.Columns.Add("ltype", typeof(string));
                //        dttemp3.Columns.Add("Cust_Id", typeof(string));
                //    }

                //    for (int i = 0; i < dtINV.Rows.Count; i++)
                //    {

                //        DataRow dtrow = dttemp3.NewRow();
                //        dtrow["branchHide"] = dtINV.Rows[i][0].ToString();
                //        dtrow["branch"] = dtINV.Rows[i][1].ToString();

                //        if (dtINV.Rows[i][5].ToString() == "OI")
                //        {
                //            dtrow["invoiceno"] = "OB SI - " + dtINV.Rows[i][2].ToString();
                //        }
                //        else if (dtINV.Rows[i][5].ToString() == "OD")
                //        {
                //            dtrow["invoiceno"] = "OB OSDN - " + dtINV.Rows[i][2].ToString();
                //        }
                //        else if (dtINV.Rows[i][5].ToString() == "OV")
                //        {
                //            dtrow["invoiceno"] = "OB DN - " + dtINV.Rows[i][2].ToString();
                //        }
                //        else if (dtINV.Rows[i][5].ToString() == "OX")
                //        {
                //            dtrow["invoiceno"] = "OB ADN - " + dtINV.Rows[i][2].ToString();
                //        }
                //        else if (dtINV.Rows[i][5].ToString() == "OP")
                //        {
                //            dtrow["invoiceno"] = "OB PI - " + dtINV.Rows[i][2].ToString();
                //        }
                //        else if (dtINV.Rows[i][5].ToString() == "OC")
                //        {
                //            dtrow["invoiceno"] = "OB OSCN - " + dtINV.Rows[i][2].ToString();
                //        }
                //        else if (dtINV.Rows[i][5].ToString() == "OE")
                //        {
                //            dtrow["invoiceno"] = "OB CN - " + dtINV.Rows[i][2].ToString();
                //        }
                //        else if (dtINV.Rows[i][5].ToString() == "OS")
                //        {
                //            dtrow["invoiceno"] = "OB ACN - " + dtINV.Rows[i][2].ToString();
                //        }
                //        dtrow["iamount"] = dtINV.Rows[i][3].ToString();
                //        dtrow["ramount"] = dtINV.Rows[i][4].ToString();
                //        dtrow["voutype"] = dtINV.Rows[i][5].ToString();
                //        dtrow["vouno"] = dtINV.Rows[i][2].ToString();
                //        dtrow["tds"] = "";
                //        dtrow["ravouyear"] = dtINV.Rows[i][6].ToString();
                //        dtrow["ltype"] = "";
                //        dtrow["Cust_Id"] = Customer_Id;
                //        dttemp3.Rows.Add(dtrow);
                //    }
                //    Grid_detail.DataSource = dttemp3;
                //    Grid_detail.DataBind();
                //    ViewState["dtPayment"] = dttemp3;
                //}
            }
        }
        private void OBBreakUp()
        {
            DataTable dtINV = new DataTable();
            DataTable dtINV3 = new DataTable();
            DataTable dttempOSDn = new DataTable();

            DataRow dtrow;
            int ledger_id, a = 0;
            if (hid_favour.Value != "")
            {

                ledger_id = Convert.ToInt32(hid_favour.Value);
                dtINV3 = recobj.GetOBRecptDtlsOS(ledger_id, did);
                DataTable dttemp3 = new DataTable();
                int r = 0;


                if (ViewState["dtINV"] != null)
                {
                    dttempOSDn = ViewState["dtINV"] as DataTable;
                    r = dttempOSDn.Rows.Count;
                }


                if (dttempOSDn.Rows.Count == 0 && dtINV3.Rows.Count > 0)
                {

                    dttempOSDn.Columns.Add("branchid", typeof(string));
                    dttempOSDn.Columns.Add("branch", typeof(string));
                    dttempOSDn.Columns.Add("invoiceno", typeof(string));
                    dttempOSDn.Columns.Add("curr", typeof(string));
                    dttempOSDn.Columns.Add("fcamt", typeof(string));
                    dttempOSDn.Columns.Add("exrate", typeof(string));
                    dttempOSDn.Columns.Add("vamount", typeof(string));
                    dttempOSDn.Columns.Add("tamount", typeof(string));

                    dttempOSDn.Columns.Add("recptfcamt", typeof(string));
                    dttempOSDn.Columns.Add("voutype", typeof(string));
                    dttempOSDn.Columns.Add("vouno", typeof(string));
                    dttempOSDn.Columns.Add("tds", typeof(string));
                    dttempOSDn.Columns.Add("ravouyear", typeof(string));
                    dttempOSDn.Columns.Add("ltype", typeof(string));
                    dttempOSDn.Columns.Add("customerid", typeof(string));
                    dttempOSDn.Columns.Add("customername", typeof(string));

                    dttempOSDn.Columns.Add("vendorrefno", typeof(string));
                    dttempOSDn.Columns.Add("vendorrefdate", typeof(string));
                }

                for (int i = 0; i <= dtINV3.Rows.Count - 1; i++)
                {
                    dtrow = dttempOSDn.NewRow();
                    dttempOSDn.Rows.Add();
                    dttempOSDn.Rows[r][0] = dtINV3.Rows[i][0].ToString();
                    dttempOSDn.Rows[r][1] = dtINV3.Rows[i][1].ToString();

                    if (dtINV3.Rows[i][8].ToString().Trim() == "OI")
                    {
                        dttempOSDn.Rows[r][2] = "OB SI - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OD")
                    {
                        dttempOSDn.Rows[r][2] = "OB OSDN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OV")
                    {
                        dttempOSDn.Rows[r][2] = "OB DN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OX")
                    {
                        dttempOSDn.Rows[r][2] = "OB ADN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OP")
                    {
                        dttempOSDn.Rows[r][2] = "OB PI - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OC")
                    {
                        dttempOSDn.Rows[r][2] = "OB OSCN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OE")
                    {
                        dttempOSDn.Rows[r][2] = "OB CN - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OS")
                    {
                        dttempOSDn.Rows[r][2] = "OB ACN - " + dtINV3.Rows[i][2].ToString();
                    }

                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OF") // Vino [05-03-2024] 
                    {
                        dttempOSDn.Rows[r][2] = "OB SI OC - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OG")
                    {
                        dttempOSDn.Rows[r][2] = "OB PI OC - " + dtINV3.Rows[i][2].ToString();
                    }
                    else if (dtINV3.Rows[i][8].ToString().Trim() == "OH")
                    {
                        dttempOSDn.Rows[r][2] = "OB BS OC - " + dtINV3.Rows[i][2].ToString();
                    }

                    //dttempOSDn.Rows[r][2] = "OSDN - " + dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][3] = dtINV3.Rows[i][3].ToString();
                    fcAmount = dtINV3.Rows[i]["fcamt"].ToString();
                    dttempOSDn.Rows[r][4] = Convert.ToDecimal(fcAmount).ToString("#,0.00");
                    if (dtINV3.Rows[i]["exrate"] != DBNull.Value)
                    {
                        exrate = dtINV3.Rows[i]["exrate"].ToString();
                        dttempOSDn.Rows[r][5] = Convert.ToDecimal(exrate).ToString("#,0.00");
                    }
                    else
                    {
                        dttempOSDn.Rows[r][5] = "";
                    }

                    dttempOSDn.Rows[r][6] = dtINV3.Rows[i][6].ToString();
                    dttempOSDn.Rows[r][7] = dtINV3.Rows[i][10].ToString();
                    dttempOSDn.Rows[r][8] = dtINV3.Rows[i][7].ToString();
                    dttempOSDn.Rows[r][9] = dtINV3.Rows[i][8].ToString();
                    dttempOSDn.Rows[r][10] = dtINV3.Rows[i][2].ToString();
                    dttempOSDn.Rows[r][12] = dtINV3.Rows[i][9].ToString();
                    dttempOSDn.Rows[r][14] = Convert.ToInt32(hid_cust.Value); // dtINV3.Rows[i]["customerid"].ToString();
                    dttempOSDn.Rows[r][15] = txt_cust.Text; // dtINV3.Rows[i]["customerid"].ToString();
                    dttempOSDn.Rows[r][16] = "";
                    //dttempOSDn.Rows[r][17] = "";
                    r = r + 1;
                }

                Grid_detail.DataSource = dttempOSDn;
                Grid_detail.DataBind();
                ViewState["dtINV"] = dttempOSDn;



            }
        }

        private void Fn_Calculate_Total()
        {

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
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            GridViewlog.Visible = true;
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            Label3.InnerText = lbl_head.Text;

            if (Session["rptype"].ToString() == "R")
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1188, "", txt_recp.Text, txt_recp.Text, Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1187, "", txt_recp.Text, txt_recp.Text, Session["StrTranType"].ToString());
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

        protected void btnpaymentcancel_Click(object sender, EventArgs e)
        {

            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            string FADbname1 = "";
            FADbname1 = Session["FADbname"].ToString();
            int Vouyear = Convert.ToInt32(txt_recpdate.Text);
            int rid = 0;
            rid = Convert.ToInt32(hid_recpayid.Value);
            if (txt_recp.Text != "")
            {
                if (rid != 0)
                {
                    if (Session["rptype"].ToString() == "R")
                    {
                        recobj.RemitncreciptPayCancl(Convert.ToInt32(txt_recp.Text), rid, Convert.ToChar(Session["rptype"].ToString()), Vouyear, bid, FADbname1);
                        // Logobj.InsLogDetail(Login.logempid, 1083, 4, Login.branchid, rid & "/" & rptype & "/" & txtAmt.Text);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Remittance Cancel", "alertify.alert('Receipt # " + txt_recp.Text + " has Cancelled.');", true);
                        Logobj.InsLogDetail(empid, 1188, 4, bid, rid + "/" + Session["rptype"].ToString() + " / " + txt_recp.Text + "/Del");
                    }
                    else if (Session["rptype"].ToString() == "P")
                    {
                        recobj.RemitncreciptPayCancl(Convert.ToInt32(txt_recp.Text), rid, Convert.ToChar(Session["rptype"].ToString()), Vouyear, bid, FADbname1);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Remittance Cancel", "alertify.alert('Payment # " + txt_recp.Text + " has Cancelled.');", true);
                        Logobj.InsLogDetail(empid, 1189, 4, bid, rid + "/" + Session["rptype"].ToString() + " / " + txt_recp.Text + "/Del");
                    }

                }

                clear();
                btn_back.ToolTip = "Cancel";
                btn_back_Click(sender, e);


            }
            else if (txt_recp.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Remittance Cancel", "alertify.alert('Select the Receipt / Payment #');", true);
                txt_recp.Focus();
                return;
            }



        }

        protected void btnexcel_Click(object sender, EventArgs e)//// 20-07-2022 hari
        {
            //try
            //{
            DataTable dtnew = ViewState["dtexcel"] as DataTable;
            GridView gdv = new GridView();

            if (dtnew.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=ProVouchers.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);


                    int index = 1;
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        index = index + 1;
                        string tamount = "=I" + (index) + "*F" + (index);
                        dtnew.Rows[j]["tamount"] = tamount;
                    }



                    DataTable dt = (DataTable)Grid_detail.DataSource;

                    gdv.DataSource = dtnew;
                    gdv.DataBind();

                    gdv.RenderControl(hw);

                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }




            }


            /*
              DataTable dtnew = ViewState["dtexcel"] as DataTable;
              GridView gdv1 = new GridView();

              int index = 1;
              for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
              {
                  index = index + 1;
                  string tamount = "=" + "(" + "I" + (index) + "*F" + (index) + ")";
                  dtnew.Rows[j]["tamount"] = tamount;
              }

              gdv1.DataSource = dtnew;
              gdv1.DataBind();


              if (gdv1.Rows.Count > 0)
              {
                  using (XLWorkbook wb = new XLWorkbook())
                  {
                      var worksheet = wb.Worksheets.Add(dtnew);

                      //wb.Cell("recptfcamt").Style.NumberFormat = "#,##0.00";
                      //worksheet.Column("recptfcamt").Style.NumberFormat = "[$$-409]#,##0.00";

                      worksheet.Column(8).Style.NumberFormat.SetFormat("[$$-409]#,##0.00");

                      Response.Clear();
                      Response.Buffer = true;
                      Response.Charset = "";
                      Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                      Response.AddHeader("content-disposition", "attachment;filename=ProRemittance.xls");
                      using (MemoryStream MyMemoryStream = new MemoryStream())
                      {
                          wb.SaveAs(MyMemoryStream);
                          MyMemoryStream.WriteTo(Response.OutputStream);
                          Response.Flush();
                          Response.End();
                      }
                  }
              }
             */
            // using (XLWorkbook wb = new XLWorkbook())
            //{

            //    DataTable empfilter = new DataTable();
            //    //DataTable dtnew = ViewState["dtexcel"] as DataTable;
            //    DataTable dtnew = new DataTable();

            //    //obj_dt = ViewState["DATA"];
            //    //GrdEmp.DataSource();

            //    if (ViewState["dtexcel"] as DataTable != null)
            //    {
            //        empfilter = ViewState["dtexcel"] as DataTable;


            //        wb.Worksheets.Add(empfilter, "Sheet1");
            //        Response.Clear();
            //        Response.Buffer = true;
            //        Response.Charset = "";

            //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //        Response.AddHeader("content-disposition", "attachment;filename=ProVouchers.xlsx");
            //        using (MemoryStream MyMemoryStream = new MemoryStream())
            //        {
            //            wb.SaveAs(MyMemoryStream);
            //            MyMemoryStream.WriteTo(Response.OutputStream);
            //            Response.Flush();
            //            Response.End();
            //        }
            //    }
            //    else
            //    {

            //    }
            //}

            //DataTable dtnew = ViewState["dtexcel"] as DataTable;
            //GridView gdv = new GridView();

            //if (dtnew.Rows.Count > 0)
            //{
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.AddHeader("content-disposition", "attachment;filename=ProVouchers.xlsx");
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.xlsx";
            //    using (StringWriter sw = new StringWriter())
            //    {
            //        HtmlTextWriter hw = new HtmlTextWriter(sw);
            //        int index = 1;
            //        for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
            //        {
            //            index = index + 1;
            //            string tamount = "=I" + (index) + "*F" + (index);
            //            dtnew.Rows[j]["tamount"] = tamount;
            //        }
            //        DataTable dt = (DataTable)Grid_detail.DataSource;

            //        gdv.DataSource = dtnew;
            //        gdv.DataBind();

            //        gdv.RenderControl(hw);

            //        string style = @"<style> .textmode { } </style>";
            //        Response.Write(style);
            //        Response.Output.Write(sw.ToString());
            //        Response.Flush();
            //        Response.End();
            //    }
            //DataTable dtnew = ViewState["dtexcel"] as DataTable;
            //GridView gdv = new GridView();

            //if (dtnew.Rows.Count > 0)
            //{
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.ClearContent();
            //    Response.ClearHeaders();
            //    Response.Charset = "";
            //    string FileName = "Recuriter" + DateTime.Now + ".xlsx";
            //    StringWriter strwritter = new StringWriter();
            //    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //    Response.ContentType = "application/vnd.ms-excel";
            //    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //    //gdv.GridLines = GridLines.Both;
            //    //gdv.HeaderStyle.Font.Bold = true;
            //    gdv.DataSource = dtnew;
            //    gdv.DataBind();
            //    gdv.RenderControl(htmltextwrtter);
            //    Response.Write(strwritter.ToString());
            //    Response.End();
            //}
            //gdv.DataSource = dtnew;
            //gdv.DataBind();

            //DataTable dt = new DataTable();
            //dt = dtnew;//your datatable
            //string attachment = "attachment; filename=hi.xls";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/vnd.ms-excel";
            //string tab = "";
            //foreach (DataColumn dc in dt.Columns)
            //{
            //    Response.Write(tab + dc.ColumnName);
            //    tab = "\t";
            //}
            //Response.Write("\n");
            //int i;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    tab = "";
            //    for (i = 0; i < dt.Columns.Count; i++)
            //    {
            //        Response.Write(tab + dr[i].ToString());
            //        tab = "\t";
            //    }
            //    Response.Write("\n");
            //}
            //Response.End();


            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=ProVouchers.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.xls";
            ////using (StringWriter sw = new StringWriter())
            ////{
            ////    HtmlTextWriter hw = new HtmlTextWriter(sw);
            ////    int index = 1;
            ////    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
            ////    {
            ////        index = index + 1;
            ////        string tamount = "=I" + (index) + "*F" + (index);
            ////        dtnew.Rows[j]["tamount"] = tamount;
            ////    }
            ////    DataTable dt = (DataTable)Grid_detail.DataSource;

            ////    

            ////    gdv.RenderControl(hw);

            ////    string style = @"<style> .textmode { } </style>";
            ////    Response.Write(style);
            ////    Response.Output.Write(sw.ToString());
            ////    Response.Flush();
            ////    Response.End();
            ////}
            //gdv.DataSource = dtnew;
            //gdv.DataBind();

            //StringBuilder SB = new StringBuilder();
            //StringWriter StringWriter = new System.IO.StringWriter(SB);
            //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            //gdv.GridLines = GridLines.Both;
            //gdv.HeaderStyle.Font.Bold = true;
            //gdv.RenderControl(HtmlTextWriter);

            //Response.Write(StringWriter.ToString());
            //Response.Flush();
            //Response.End();
            // }
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }

        protected void btn_upload1_Click(object sender, EventArgs e)
        {
            string path;
            string path1;

            string filename = System.IO.Path.GetFileName(fileexcel.FileName);

            string[] strTempArray;
            int intlen;
            strTempArray = filename.Split('.');
            intlen = strTempArray.Length - 1;
            string sheetname = strTempArray[0].ToString().Trim();

            ViewState["query"] = sheetname.ToString();
            //if (strTempArray[intlen] != "xls" || strTempArray[intlen] == "xlsm" || strTempArray[intlen] != "xlsx")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Excel File...');", true);
            //    //grdINVRec.DataSource = Utility.Fn_GetEmptyDataTable();
            //    //grdINVRec.DataBind();
            //    return;
            //}
            if (filename != "" && filename != null)
            {
                path = Server.MapPath("~/Excelsheet_details/" + filename);
                path1 = Server.MapPath("~/Excelsheet_details/");
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }

                File.Delete(path1 + filename);
                fileexcel.PostedFile.SaveAs(Server.MapPath("~/Excelsheet_details/" + filename.ToString()));
                path = Server.MapPath("~/Excelsheet_details/" + filename);
                ImportAttendence1(path);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly Select File');", true);
                return;
            }
        }

        public void ImportAttendence1(string PrmPathExcelFile)
        {
            try
            {

                System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection();
                DataSet DtSet = new DataSet();
                System.Data.OleDb.OleDbDataAdapter MyCommand = new System.Data.OleDb.OleDbDataAdapter();
                string[] strTempArray;
                string connectionstring = "";
                int intlen;
                double famount = 0, exrate = 0;

                strTempArray = PrmPathExcelFile.Split('.');
                intlen = strTempArray.Length - 1;
                if (strTempArray[intlen] == "xlsx")
                {
                    connectionstring = "provider=Microsoft.ACE.OLEDB.12.0; " + "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                //else if (strTempArray[intlen] == "xlsm")
                //{
                //    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=Excel 12.0;");
                //}
                else if (strTempArray[intlen] == "xls")
                {
                    // MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; " + "data source='" + PrmPathExcelFile + " '; " + "Extended Properties=Excel 8.0;");
                    //MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + PrmPathExcelFile + ";Extended Properties='Excel 12.0 Xml; HDR = YES; IMEX = 2'");
                    connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PrmPathExcelFile + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }

                string sheetname = ViewState["query"].ToString();

                string query = "SELECT * FROM [" + sheetname + "$]";
                OleDbConnection conn = new OleDbConnection(connectionstring);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                OleDbCommand cmd = new OleDbCommand(query, conn);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                DataSet ds = new DataSet();

                DataTable data = new DataTable();

                da.Fill(ds);

                data.Merge(ds.Tables[0]);

                ViewState["Data_New"] = data;

                conn.Close();

                Expo();

                //MyCommand = new System.Data.OleDb.OleDbDataAdapter(query, MyConnection);
                ////MyCommand.TableMappings.Add("Table", "Attendence");
                ////  MyCommand.TableMappings.Add("Table", "container no");
                //DtSet = new System.Data.DataSet();
                //DataTable newdt = new DataTable();
                //MyCommand.Fill(newdt);

                //for (int i = newdt.Rows.Count - 1; i >= 0; i--)
                //{
                //    if (newdt.Rows[i][1] == DBNull.Value)
                //        newdt.Rows[i].Delete();
                //}
                //newdt.AcceptChanges();

                //ViewState["Data_New"] = newdt;
                // ViewState["Data_New1"] = newdt.Rows[i]["Invoice #"].ToString();


                //for (int i = 0; i <= newdt.Rows.Count - 1; i++)
                //{
                //    hid_invoiceno.Value = "SI - " + newdt.Rows[i]["Invoice #"].ToString();
                //}
                //  grd_data.Visible = true;

                //grd_data.DataSource = newdt;
                //grd_data.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Kindly check the Excel Format');", true);
                return;
            }
        }

        ////////////////////////////////////////////////////
        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            mode_set();

            if (ddl_mode.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(btn_save, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Mode');", true);
                txt_date.Text = txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                ddl_mode.Focus();
                blner = true;
                return;
            }

            int Vouyear = Convert.ToInt32(txt_recpdate.Text);

            if (Session["rptype"] != null)
            {
                //if (Session["rptype"] == "P" && mode=="C")
                //{

                DateTime rdate;
                DateTime fdate;
                DateTime curdate;
                DateTime rdate1;
                fdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));

                curdate = Convert.ToDateTime((Logobj.GetDate().ToString()));
                rdate = bankobj.GetOSRPMaxDate(Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["rptype"].ToString(), mode.ToString(), Vouyear);

                /// rdate = Convert.ToDateTime(Utility.fn_ConvertDate(rdate.ToShortDateString()));
                int rdiff = rdate.Day;

                if (rdate <= fdate && fdate <= curdate)
                {
                    txt_date.Text = txt_date.Text;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Date must between From " + rdate.ToString("dd/MM/yyyy") + " To " + curdate.ToString("dd/MM/yyyy") + "');", true);
                    //txt_date.Text = "";
                    txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());

                }
                //}
            }




        }
        ///////////////////////////////////////////////////////////

        public void Expo()
        {
            bool nullcheck = false;
            bool valcheck = false;
            string strrptype = "";

            if (Session["rptype"].ToString() == "R")
            {
                strrptype = "Receipt";
            }
            else if (Session["rptype"].ToString() == "P")
            {
                strrptype = "Payment";
            }

            double PA_Amount = 0, TDS_Amount = 0;
            int rowindex = 0;
            double amt = 0.0;
            DataTable dt = new DataTable();                         //NEW12

            dt = (DataTable)ViewState["Data_New"];

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    object vtype = row["voutype"];

                    if (vtype.ToString() != "O")
                    {
                        object value = row["recptfcamt"];
                        object value1 = row["fcamt"];

                        if (value == DBNull.Value)
                        {
                            nullcheck = true;
                            value = 0;
                        }


                        if (Convert.ToDouble(value.ToString()) > Convert.ToDouble(value1.ToString()))
                        {
                            valcheck = true;
                        }

                    }
                }

                if (nullcheck == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "logix", "alertify.alert('Excel File has Empty Value');", true);
                    return;
                }
                else if (valcheck == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "logix", "alertify.alert('" + strrptype + " Amount does not Match with Total Dollar  Amount...');", true);
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('" + strrptype + " Amount does not Match with Total Dollar  Amount...');", true);
                    return;
                }
                else
                {

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= Grid_detail.Rows.Count - 1; j++)
                        {
                            if (Grid_detail.Rows[j].Cells[6].Text == "&nbsp;")
                            { continue; }
                            else
                            {
                                if (dt.Rows[i]["vouno"] is DBNull)
                                { continue; }
                                else
                                {
                                    CheckBox Chk = (CheckBox)Grid_detail.Rows[j].FindControl("Chkrecpfc");

                                    hid_invoiceno.Value = Grid_detail.Rows[j].Cells[10].Text;
                                    // if (Convert.ToInt32(dt.Rows[i]["Inv #"]) == Convert.ToInt32(hid_invoiceno.Value))
                                    if (Convert.ToInt32(dt.Rows[i]["vouno"]) == Convert.ToInt32(hid_invoiceno.Value))
                                    {
                                        amt = Convert.ToDouble(dt.Rows[i]["tamount"]);
                                        double amt1 = Convert.ToDouble(Grid_detail.Rows[j].Cells[6].Text);
                                        if (amt1 > amt)
                                        {
                                            TextBox TxtAmount = ((TextBox)Grid_detail.Rows[j].FindControl("txt_receiptamount"));
                                            TxtAmount.Text = amt.ToString();
                                            //rowindex = row.RowIndex;
                                            //calculation(rowindex);
                                            //TxtAmount.Focus();
                                            Chk.Checked = true;
                                        }
                                        else
                                        {
                                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invoice Amount should be low');", true);
                                            //return;
                                        }
                                    }
                                    else
                                    { continue; }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}





