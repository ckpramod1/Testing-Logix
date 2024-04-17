using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
namespace logix.Accounts
{
    public partial class TallyXML : System.Web.UI.Page
    {
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.Accounts.Invoice Invobj = new DataAccess.Accounts.Invoice();
        DataAccess.Masters.MasterBranch BrObj = new DataAccess.Masters.MasterBranch();
        DataAccess.Masters.MasterDivision DivObj = new DataAccess.Masters.MasterDivision();
        DataAccess.Masters.MasterCustomer Custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.DCAdvise DCobj = new DataAccess.Accounts.DCAdvise();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.OSDNCN OSDCNObj = new DataAccess.Accounts.OSDNCN();
        DataAccess.Accounts.Recipts RcptObj = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Payment PymtObj = new DataAccess.Accounts.Payment();
        DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.BLDetails FIBLObj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Masters.MasterTDSType TDSObj = new DataAccess.Masters.MasterTDSType();
        DataAccess.Masters.MasterBranch MBObj = new DataAccess.Masters.MasterBranch();
        DataAccess.FAMaster.MasterLedger obj_da_ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Accounts.CostingDt costobj = new DataAccess.Accounts.CostingDt();
        DataAccess.Accounts.Invoice invoiceobj = new DataAccess.Accounts.Invoice();
        DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
        DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.CloseJobs jobcloseobj = new DataAccess.CloseJobs();
        DataAccess.ForwardingImports.JobInfo FIJobObj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.Masters.MasterVessel VesselObj = new DataAccess.Masters.MasterVessel();
        DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
        DataAccess.HR.Employee branch = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        double totamountWOST = 0, totalamount = 0, totamountST = 0, PAAmount = 0, dcamount = 0, EAmount = 0, Amount = 0, tamt = 0, dcexrate = 0, dcnamount = 0, RCAmt = 0, RRFAmt = 0, ESAmt = 0,
            RRef = 0, PATdsAmt = 0, recamt = 0, RCAmt1 = 0;
        string strtrantype = "", submenuname = "", voutype = "", voudate = "", narration = "", vounoyear = "", reference = "", partyledger = "", ledgernameexin = "",
            ledgername = "", ledgerexpinc = "", gategory = "", jobno = "", str_Voujobno = "", str_Voutrantype = "", str_VouTypeINCEXP, blno = "", filename = "", strpart = "", strpart1 = "", strpart2 = "", strpart3 = "",
            strpart4 = "", strpart5 = "", strpart6 = "", ddlref = "", dccustomername, dctrantype = "", dcdndate = "", dcvouno = "", dctranjobno = "", dctotalamount = "",
            dctotal = "", vouname = "", strRdate = "", Rbankname = "", RBranch = "", chequeno = "", strCHdate = "", naration = "", classname = "", partyname = "", RVouname = "",
            Rvouno = "", RCustomer = "", pcode = "", JVpcode = "", mode = "", Rvouyear = "", Rmonth = "", CustTdsType = "", strbrnchbnkname = "", StrbrnchbnkAccno = "",
            dsvouno = "", dschqno = "", dsbname = "", dssldate = "", dsledgname = "", vouno = "", custtype = "", tran = "", vendorrefno = "", Ctrl_List = "", Msg_List = "", Dtype_List = "", billtype = "", strCHdate1="";
        
        DateTime Dt_voudate;
        bool Check, blerr, blr;
        int empid = 0, branchid, divisionid, vouyear, dcjobno, dccustomerid, RBranchid, RBankid, RCustid, RID, countno, JVDNCustomerid, PACustID, portid, p, containernos, tranCharge;
        DataTable dtchk1 = new DataTable();
        DataTable Dt, Dt1, DtRe, DSDt, dtledger, DtRece;
        DateTime dcdate, Rdate, Chdate, slipdate;
        string str_NEFT = "";
        string Str_XML = "", strvtype = "";
        int int_From, int_To, j;
        bool blrTDS;
        DataSet DS = new DataSet();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        int countryid;
        string jobprefix, numformat, deductedchargename, vounum;
        double TdsAmount = 0;
        int BanchFA;

        DataTable dtledge;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                HREmpobj.GetDataBase(Ccode);
                Invobj.GetDataBase(Ccode);
                BrObj.GetDataBase(Ccode);
                DivObj.GetDataBase(Ccode);
                Custobj.GetDataBase(Ccode);
                DCobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                OSDCNObj.GetDataBase(Ccode);


                RcptObj.GetDataBase(Ccode);
                PymtObj.GetDataBase(Ccode);
                FEJobObj.GetDataBase(Ccode);
                FIBLObj.GetDataBase (Ccode);
                TDSObj.GetDataBase(Ccode);
                MBObj.GetDataBase(Ccode);
                obj_da_ledger.GetDataBase(Ccode);
                costobj.GetDataBase (Ccode);
                invoiceobj.GetDataBase(Ccode);
                obj_da_FA.GetDataBase(Ccode);
                obj_da_Division.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                jobcloseobj.GetDataBase(Ccode);
                VesselObj.GetDataBase (Ccode);
                obj_da_Receipt.GetDataBase(Ccode);
                branch.GetDataBase (Ccode);
                Logobj.GetDataBase (Ccode);
                obj_UP.GetDataBase (Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            countryid = obj_UP.Get_countrycode(Session["LoginBranchName"].ToString());
          //  countryid = 1102;
            try
            {
                pdf_id.Visible = false;
                btn_pdf.Visible = false;
                transfer_id.Visible = false;
                btn_UnTransfer.Visible = false;
                view_id.Visible = false;
                btn_View.Visible = false;
                if (Request.QueryString.ToString().Contains("type"))
                {
                    lbl_Header.Text = Request.QueryString["type"].ToString();
                }
                HeaderLabel.InnerText = lbl_Header.Text;
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_EDI);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnediall);
                strtrantype = Session["StrTranType"].ToString();
                empid = Convert.ToInt32(Session["LoginEmpId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
                if (!IsPostBack)
                {
                    //  btn_cancel.Text = "Cancel";
                    string trantype = Convert.ToString(Session["StrTranType"]);
                    if (trantype == "CO")
                    {
                        Session["StrTranType"] = "CA";
                    }
                    //ddl_voucher.Items.Add("");
                    if (Session["LoginBranchname"].ToString().ToUpper() == "CORPORATE")
                    {
                        ddl_voucher.Items.Add(new ListItem("Payment Advise - Admin", "Payment Advise - Admin"));
                        ddl_voucher.Items.Add(new ListItem("Admin Sales Invoice", "Admin Sales Invoice"));
                        ddl_voucher.Items.Add(new ListItem("Receipt - Bank", "Receipt - Bank"));
                        ddl_voucher.Items.Add(new ListItem("Receipt - Cash", "Receipt - Cash"));
                        //ddl_voucher.Items.Add(new ListItem("Receipt - Petty Cash", "Receipt - Petty Cash"));
                        ddl_voucher.Items.Add(new ListItem("Bank Payment", "Bank Payment"));  //- Transfer From CO
                        ddl_voucher.Items.Add(new ListItem("Cash Payment", "Cash Payment"));
                        ////ddl_voucher.Items.Add(new ListItem("Bank Payment - Transfer From CO", "Bank Payment - Transfer From CO"));  //- Transfer From CO
                        ////ddl_voucher.Items.Add(new ListItem("Cash Payment - Transfer To CO", "Cash Payment - Transfer From CO"));

                    }
                    else
                    {


                        ddl_voucher.Items.Add(new ListItem("Invoices", "Invoices"));
                        ddl_voucher.Items.Add(new ListItem("BOS", "BOS"));
                        ddl_voucher.Items.Add(new ListItem("Purchase Invoice", "Purchase Invoice"));
                        // ddl_voucher.Items.Add(new ListItem("PaymentAdvises", "PaymentAdvises")); //|| ddl_voucher.Text == "Credit Note - Operations"
                        ddl_voucher.Items.Add(new ListItem("OSSI", "OSSI"));
                        ddl_voucher.Items.Add(new ListItem("OSPI", "OSPI"));
                        ddl_voucher.Items.Add(new ListItem("Debit Note - Others", "Debit Note - Others"));
                        ddl_voucher.Items.Add(new ListItem("Credit Note - Others", "Credit Note - Others"));
                        ddl_voucher.Items.Add(new ListItem("Receipt - Bank", "Receipt - Bank"));
                        ddl_voucher.Items.Add(new ListItem("Receipt - Cash", "Receipt - Cash"));
                        //ddl_voucher.Items.Add(new ListItem("Receipt - Petty Cash", "Receipt - Petty Cash"));
                        ddl_voucher.Items.Add(new ListItem("Bank Payment - Transfer From CO", "Bank Payment - Transfer From CO"));  //- Transfer From CO
                        ddl_voucher.Items.Add(new ListItem("Cash Payment - Transfer To CO", "Cash Payment - Transfer From CO"));
                        ddl_voucher.Items.Add(new ListItem("Bank Deposit - Transfer To CO", "Bank Deposit - Transfer To CO")); //- Transfer To CO
                        ddl_voucher.Items.Add(new ListItem("Cash Deposit - Transfer To CO", "Cash Deposit - Transfer To CO"));
                        ddl_voucher.Items.Add(new ListItem("Admin Purchase Invoice", "Payment Advise - Admin"));
                        ddl_voucher.Items.Add(new ListItem("Remittance-Receipt", "Remittance-Receipt"));
                        ddl_voucher.Items.Add(new ListItem("Remittance-Payment", "Remittance-Payment"));
                        ddl_voucher.Items.Add(new ListItem("Admin Sales Invoice", "Admin Sales Invoice"));
                        ddl_voucher.Items.Add(new ListItem("Journal", "Journal"));
                        ddl_voucher.Items.Add(new ListItem("ALL", "ALL"));
                    }
                    //ddl_voucher.Items.Add(new ListItem("Admin Purchase Invoice", "Admin Purchase Invoice"));
                    //ddl_voucher.Items.Add(new ListItem("Admin Sales Invoice", "Admin Sales Invoice"));
                    //ddl_voucher.Items.Add(new ListItem("Journal", "Journal"));
                    //ddl_voucher.Items.Add(new ListItem("Cash  Payment", "Cash  Payment"));
                    /*    if (Session["StrTranType"].ToString() == "CA")
                        {
                            //ddl_voucher.Items.Add("");
                            ddl_voucher.Items.Add(new ListItem("Payment Advise - Admin", "Payment Advise - Admin"));
                            ddl_voucher.Items.Add(new ListItem("Admin Sales Invoice", "Admin Sales Invoice"));
                            //ddl_voucher.Items.Add(new ListItem("Receipt - Bank", "Receipt - Bank"));
                            //ddl_voucher.Items.Add(new ListItem("Receipt - Cash", "Receipt - Cash"));
                            //ddl_voucher.Items.Add(new ListItem("Receipt - Petty Cash", "Receipt - Petty Cash"));
                            //ddl_voucher.Items.Add(new ListItem("Cash  Payment", "Cash  Payment"));

                        }
                        else
                        {
                            //ddl_voucher.Items.Add("");
                            ddl_voucher.Items.Add(new ListItem("Invoices", "Invoices"));
                            ddl_voucher.Items.Add(new ListItem("BOS", "BOS"));
                            ddl_voucher.Items.Add(new ListItem("Credit Note - Operations", "Credit Note - Operations"));
                            // ddl_voucher.Items.Add(new ListItem("PaymentAdvises", "PaymentAdvises")); //|| ddl_voucher.Text == "Credit Note - Operations"
                            ddl_voucher.Items.Add(new ListItem("OSSI", "OSSI"));
                            ddl_voucher.Items.Add(new ListItem("OSPI", "OSPI"));
                            ddl_voucher.Items.Add(new ListItem("Debit Note - Others", "Debit Note - Others"));
                            ddl_voucher.Items.Add(new ListItem("Credit Note - Others", "Credit Note - Others"));
                            ddl_voucher.Items.Add(new ListItem("Receipt - Bank", "Receipt - Bank"));
                            ddl_voucher.Items.Add(new ListItem("Receipt - Cash", "Receipt - Cash"));
                            //ddl_voucher.Items.Add(new ListItem("Receipt - Petty Cash", "Receipt - Petty Cash"));
                            ddl_voucher.Items.Add(new ListItem("Bank Payment - Transfer From CO", "Bank Payment - Transfer From CO"));  //- Transfer From CO
                            ddl_voucher.Items.Add(new ListItem("Cash Payment - Transfer To CO", "Cash Payment - Transfer From CO"));
                            ddl_voucher.Items.Add(new ListItem("Bank Deposit - Transfer To CO", "Bank Deposit - Transfer To CO")); //- Transfer To CO
                            ddl_voucher.Items.Add(new ListItem("Cash Deposit - Transfer To CO", "Cash Deposit - Transfer To CO"));
                            ddl_voucher.Items.Add(new ListItem("Admin Purchase Invoice", "Payment Advise - Admin"));
                            ddl_voucher.Items.Add(new ListItem("Remittance-Receipt", "Remittance-Receipt"));
                            ddl_voucher.Items.Add(new ListItem("Remittance-Payment", "Remittance-Payment"));
                            ddl_voucher.Items.Add(new ListItem("Admin Sales Invoice", "Admin Sales Invoice"));
                            ddl_voucher.Items.Add(new ListItem("ALL", "ALL"));

                            //ddl_voucher.Items.Add(new ListItem("Admin Purchase Invoice", "Admin Purchase Invoice"));
                            //ddl_voucher.Items.Add(new ListItem("Admin Sales Invoice", "Admin Sales Invoice"));
                            //ddl_voucher.Items.Add(new ListItem("Journal", "Journal"));
                            //ddl_voucher.Items.Add(new ListItem("Cash  Payment", "Cash  Payment"));
                        }*/
                    if (lbl_Header.Text != "Payment Advise - Admin" || lbl_Header.Text != "Admin Sales Invoice")
                    {
                        ddl_narration.Items.Add("LedgerNames");
                        ddl_narration.Items.Add("Vessel/Voyage/Container");
                        ddl_narration.Items.Add("Remarks");
                        ddl_reference.Items.Add("Voucher No");
                        ddl_reference.Items.Add("BL No");
                        ddl_reference.Items.Add("Vendor Ref No");
                    }
                    else
                    {
                        ddl_reference.Items.Add("Ref No");
                        ddl_narration.Items.Add("Remarks");
                    }
                    //DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
                    hid_shortname.Value = obj_da_Division.GetShortName(int.Parse(Session["LoginDivisionId"].ToString()));
                
                    btn_UnTransfer.Enabled = false;
                }
                if (ddl_voucher.Text != "Bank Deposit - Transfer To CO" || ddl_voucher.Text != "Cash Deposit - Transfer To CO")
                {

                    txt_from.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_to.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    //txt_month.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                    Ctrl_List = txt_from.ID + "~" + txt_to.ID + "~" + txt_year.ID;
                    Msg_List = "From Vouno ~To Vouno ~ Year Cannot";
                    Dtype_List = "string~string~string";
                    btn_EDI.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");

                }
                else
                {
                    Ctrl_List = txt_from.ID;
                    Msg_List = "slip #";
                    Dtype_List = "string";
                    btn_EDI.Attributes.Add("OnClick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                }



            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        private void Fn_Clear()
        {
            txt_from.Text = "";
            //txt_month.Text = "";
            txt_to.Text = "";
            txt_year.Text = "";
            txt_JVmonth.Text = "";
            txt_JVmonth.Visible = false;
            lbl_toyear.Text = "";
            btn_cancel.ToolTip = "Back";
            ddl_voucher.SelectedIndex = 0;
            ddl_narration.SelectedIndex = 0;
            ddl_reference.SelectedIndex = 0;
        }

        protected void ddl_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bind();
                btn_cancel.ToolTip = "Cancel";
                //btn_UnTransfer.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void bind()
        {
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DateTime dtdate = obj_da_Log.GetDate();

            if (ddl_voucher.SelectedItem.Text.Trim().Length > 0)
            {
                string str_Voucher = ddl_voucher.SelectedValue.ToString();
                if (str_Voucher == "Payment Advise - Admin" || str_Voucher == "Admin Sales Invoice")
                {
                    //ddl_narration.SelectedItem.Text = "Remarks";
                    //ddl_reference.SelectedItem.Text = "Ref No";
                    ddl_narration.SelectedValue = "Remarks";
                    ddl_reference.SelectedValue = "Ref No";
                    ddl_narration.Enabled = false;
                    ddl_reference.Enabled = false;
                    lbl_JVmonth.Visible = false;
                    txt_JVmonth.Visible = false;
                    //txt_month.Enabled = false;
                }//|| str_Voucher == "Receipt - Petty Cash"
                else if (str_Voucher == "Receipt - Cash" || str_Voucher == "Receipt - Bank" || str_Voucher == "Cash  Payment" || str_Voucher == "Bank Payment" || str_Voucher == "Bank Payment - Transfer From CO" || str_Voucher == "Cash Payment - Transfer From CO")
                {
                    ddl_narration.Enabled = false;
                    ddl_reference.Enabled = false;
                    txt_to.Enabled = true;
                    //lbl_from.Text = "From";
                    txt_from.Attributes.Add("placeholder", "From");
                    txt_from.ToolTip = "From";
                    txt_year.Enabled = true;
                    lbl_JVmonth.Visible = false;
                    txt_JVmonth.Visible = false;
                    //txt_month.Enabled = false;
                }
                else if (str_Voucher == "Bank Deposit - Transfer To CO" || str_Voucher == "Cash Deposit - Transfer To CO")
                {
                    
                    btn_UnTransfer.Enabled = false;
                    btn_UnTransfer.ForeColor = System.Drawing.Color.Gray;

                    ddl_narration.Enabled = false;
                    ddl_reference.Enabled = false;
                    // txt_to.Enabled = false;
                    //lbl_from.Text = "Slip #";
                    txt_from.Attributes.Add("placeholder", "Slip");
                    txt_from.ToolTip = "Slip";
                    txt_year.Enabled = false;
                    //txt_month.Enabled = false;
                    txt_year.Text = dtdate.Year.ToString();
                    lbl_JVmonth.Visible = false;
                    txt_JVmonth.Visible = false;
                }
                //else if (str_Voucher == "PaymentAdvises" || str_Voucher == "Credit Note - Others")
                //{
                //    if (ddl_reference.Items.FindByText("Vendor Ref No") == null)
                //    {
                //        ddl_reference.Items.Add("Vendor Ref No");
                //    }
                //    txt_month.Enabled = false;
                //}
                //else if (str_Voucher == "Journal")
                //{
                //    txt_month.Enabled = true;
                //}
                else if (str_Voucher == "ALL")
                {
                    txt_from.Enabled = false;
                    txt_from.Text = "";
                    lbl_to.Enabled = false;
                    txt_to.Enabled = false;
                    txt_to.Text = "";
                    txt_year.Text = Convert.ToInt32(Session["LogYear"]).ToString();
                    if (txt_year.Text.Trim().Length > 0)
                    {
                        lbl_toyear.Text = "-" + (int.Parse(txt_year.Text) + 1).ToString();
                    }
                    ediall_id.Visible = true;
                    btnediall.Visible = true;
                    edi_id.Visible = false;
                    btn_EDI.Visible = false;
                    lbl_JVmonth.Visible = false;
                    txt_JVmonth.Visible = false;
                }
                else
                {
                    edi_id.Visible = true;
                    btn_EDI.Visible = true;
                    ediall_id.Visible = true;
                    btnediall.Visible = false;
                    ddl_narration.Enabled = true;
                    ddl_reference.Enabled = true;
                    txt_to.Enabled = true;
                    txt_from.Enabled = true;
                    txt_to.Text = "";
                    txt_from.Text = "";
                
                    btn_UnTransfer.Enabled = true;
                    btn_UnTransfer.ForeColor = System.Drawing.Color.DarkTurquoise;
                    //lbl_from.Text = "From";
                    txt_from.Attributes.Add("placeholder", "From");
                    txt_from.ToolTip = "From";
                    txt_year.Enabled = true;
                    txt_year.Text = "";
                }

                if (ddl_voucher.SelectedItem.Text == "Invoices")
                {
                    btn_pdf.Enabled = true;
                    btn_View.Enabled = true;
                    lbl_JVmonth.Visible = false;
                    txt_JVmonth.Visible = false;
                }
                else if (str_Voucher == "Journal")
                {
                    ddl_narration.Enabled = false;
                    ddl_reference.Enabled = false;
                    lbl_JVmonth.Visible = true;
                    txt_JVmonth.Visible = true;
                }
                else
                {
                    btn_pdf.Enabled = false;
                    btn_View.Enabled = false;
                }
            }
        }

        protected void txt_year_TextChanged(object sender, EventArgs e)
        {
            if (txt_year.Text.Trim().Length > 0)
            {
                lbl_toyear.Text = "-" + (int.Parse(txt_year.Text) + 1).ToString();
            }
            else
            {
                lbl_toyear.Visible = false;
            }
            //if(txt_from.Text==txt_to.Text)
            //{
            //    dtchk1 = Invobj.CheckTransfer(ddl_voucher.Text,Convert.ToInt32(txt_from.Text),branchid,Convert.ToInt32(txt_year.Text));
            //    if(dtchk1.Rows.Count>0)
            //    {
            //        if(string.IsNullOrEmpty(dtchk1.Rows[0][0].ToString()))
            //        {
            //            btn_UnTransfer.Enabled = false;
            //        }
            //        else
            //        {
            //            btn_UnTransfer.Enabled = true;
            //        }
            //    }
            //}
            transfer_id.Visible = false;
            btn_UnTransfer.Visible = false;
            btn_UnTransfer.ForeColor = System.Drawing.Color.Gray;

        }

        protected void btn_UnTransfer_Click(object sender, EventArgs e)
        {

        }

        protected void checkvalue()
        {
            if (ddl_voucher.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select Voucher');", true);
                blerr = true;
                return;
            }

            if (ddl_voucher.Text != "Receipt - Bank" && ddl_voucher.Text != "Receipt - Cash" && ddl_voucher.Text != "Cash Payment" && ddl_voucher.Text != "Bank Payment" && ddl_voucher.Text != "Bank Deposit - Transfer To CO" && ddl_voucher.Text != "Cash Deposit - Transfer To CO" && ddl_voucher.Text != "Cash  Payment - Transfer From CO" && ddl_voucher.Text != "Bank Payment - Transfer From CO")
            {
                if (ddl_narration.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select Narration');", true);
                    blerr = true;
                    return;
                }

                if (ddl_reference.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select Reference');", true);
                    blerr = true;
                    return;
                }
            }

            if (ddl_voucher.Text == "Bank Deposit - Transfer To CO")
            {
                DSDt = RcptObj.GetSlipDetails4tally(txt_from.Text, branchid, 'B');
                if (DSDt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Slip #');", true);
                    blerr = true;
                    return;
                }
            }
            if (ddl_voucher.Text == "Cash Deposit - Transfer To CO")
            {
                DSDt = RcptObj.GetSlipDetails4tally(txt_from.Text, branchid, 'C');
                if (DSDt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Slip #');", true);
                    blerr = true;
                    return;
                }
            }

        }

        protected string getdtlsxml()
        {
            string pcode;
            pcode = OSDCNObj.GetPortCode(branchid);
            strpart = ""; string ctype = "", str_trantype = "";
            DataTable ldt = new DataTable();
            if (ddl_voucher.SelectedItem.Text != "ALL")
            {
                if (ddl_voucher.Text == "Bank Deposit - Transfer To CO" || ddl_voucher.Text == "Cash Deposit - Transfer To CO")
                {
                    txt_from.Text = txt_from.Text;
                    txt_to.Text = txt_to.Text;
                }
                else
                {
                    int from = Convert.ToInt32(txt_from.Text);
                    int to = Convert.ToInt32(txt_to.Text);
                }
            }
            //int from = Convert.ToInt32( txt_from.Text);
            //int to = Convert.ToInt32(txt_to.Text);
            string voucher = ddl_voucher.Text;
            DataTable dt1 = new DataTable();
            DataTable dtcusto = new DataTable();
            int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int customerid = 0, debit = 0, credit = 0;
            string debotors = "";

            DataTable dt = new DataTable();
            //string fromdate = "27/11/2018";
            //DateTime dtdate = Convert.ToDateTime(Utility.fn_ConvertDate(fromdate));
            DateTime dtdate = logobj.GetDate();

            //   ldt = Invobj.GETTALLYLedgername(Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), ddl_voucher.Text, branchid, Convert.ToInt32(txt_year.Text));
            if (ddl_voucher.Text == "Bank Deposit - Transfer To CO" || ddl_voucher.Text == "Cash Deposit - Transfer To CO")
            {
            }
            else
            {
                if (ddl_voucher.SelectedItem.Text != "ALL")
                {
                    ldt = Invobj.GETTALLYLedgername(Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), ddl_voucher.Text, branchid, Convert.ToInt32(txt_year.Text));
                }
                else if (ddl_voucher.SelectedItem.Text == "ALL")
                {
                    ldt = obj_da_ledger.SPTallyAllVouchersOnlyApprovedbyZero(dtdate, Convert.ToInt32(txt_year.Text), branchid);
                }
            }


            //if (ddl_voucher.Text == "Invoices" || ddl_voucher.Text == "BOS" || ddl_voucher.Text == "Purchase Invoice" || ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "OSPI" || ddl_voucher.Text == "Debit Note - Others" || ddl_voucher.Text == "Credit Note - Others" || ddl_voucher.Text == "Admin Sales Invoice" || ddl_voucher.Text == "Admin Purchase Invoice" || ddl_voucher.Text == "ALL" || ddl_voucher.Text == "Payment Advise - Admin")
            //{
            if (ddl_voucher.Text == "Invoices" || ddl_voucher.Text == "BOS" || ddl_voucher.Text == "Purchase Invoice" || ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "OSPI" || ddl_voucher.Text == "Debit Note - Others" || ddl_voucher.Text == "Credit Note - Others" || ddl_voucher.Text == "Admin Sales Invoice" || ddl_voucher.Text == "Admin Purchase Invoice" || ddl_voucher.Text == "ALL" || ddl_voucher.Text == "Payment Advise - Admin" || ddl_voucher.Text == "Cash Payment" || ddl_voucher.Text == "Bank Payment" || ddl_voucher.Text == "Cash Payment - Transfer From CO" || ddl_voucher.Text == "Bank Payment - Transfer From CO" || ddl_voucher.Text == "Receipt - Cash" || ddl_voucher.Text == "Receipt - Bank")
            {
                if (ldt.Rows.Count > 0)
                {
                    for (int g = 0; g < ldt.Rows.Count; g++)
                    {
                        //if (ddl_voucher.Text != "Admin Sales Invoice" || ddl_voucher.Text != "Admin Purchase Invoice")
                        //{
                        //    str_trantype = ldt.Rows[g]["trantype"].ToString();
                        //}
                        str_trantype = ldt.Rows[g]["trantype"].ToString();
                        //"<LEDGER NAME='' "+ldt.Rows[g]["chargename"].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;")+"='" + FA + "' ACTION='CREATE'>"
                        string ChrgName;
                        ChrgName = (ldt.Rows[g]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                        // str_trantype = invoiceobj.getinvoicetrantype();
                        //if (ldt.Rows[g]["Ctype"].ToString() == "CHARGE")
                        //{

                        if (str_trantype == "NI" || str_trantype == "NE" || str_trantype == "NS" || str_trantype == "NT")
                        {
                            if (strtrantype == "NI")
                            {
                                ChrgName = ChrgName;
                            }
                            else
                            {
                                ChrgName = ChrgName;
                                //  ChrgName = "SOC Exports " + ChrgName + ctype;
                            }
                        }
                        else
                        {
                            if (str_trantype == "FI" || str_trantype == "OI")
                            {
                                ChrgName = ChrgName;
                                //ChrgName = "COC Imports " + ChrgName + ctype;
                            }
                            else if (str_trantype == "FE" || str_trantype == "OE")
                            {
                                ChrgName = ChrgName;
                            }
                            if (str_trantype == "AI")
                            {
                                ChrgName = ChrgName;
                                // ChrgName = "AIR Imports " + ChrgName + ctype;
                            }
                            else if (str_trantype == "AE")
                            {
                                ChrgName = ChrgName;
                                //ChrgName = "AIR Exports " + ChrgName + ctype;
                            }
                            if (str_trantype == "CH")
                            {
                                ChrgName = ChrgName;
                            }
                            if (str_trantype == "BT")
                            {
                                ChrgName = ChrgName;
                            }
                        }
                        //}

                        strpart = strpart + "<LEDGER NAME='" + ChrgName + "' ACTION='Create'>";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<NAME.LIST>";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<NAME>" + ChrgName + "</NAME> ";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "</NAME.LIST>";
                        strpart = strpart + System.Environment.NewLine;
                        if (!string.IsNullOrEmpty(ldt.Rows[g]["parent"].ToString()))
                        {
                            strpart = strpart + "<PARENT>" + ldt.Rows[g]["parent"].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</PARENT> ";

                            //NewOne
                            if (!string.IsNullOrEmpty(ldt.Rows[g]["ledgerid"].ToString()))
                            {
                                dtledge = Custobj.getspseltallyraj(Convert.ToInt32(ldt.Rows[g]["ledgerid"].ToString()), Convert.ToInt32(ldt.Rows[g]["customerid"].ToString()));
                                if (dtledge.Rows.Count > 0)
                                {
                                    customerid = Convert.ToInt32(dtledge.Rows[0]["customerid"].ToString());
                                    dt1 = Invobj.spcountinvoice4particularcustomer(customerid, branchid, Convert.ToInt32(txt_year.Text), empid);
                                    debit = Convert.ToInt32(dt1.Rows[0]["debit"].ToString());
                                    credit = Convert.ToInt32(dt1.Rows[0]["credit"].ToString());                          

                                    dtcusto = Custobj.Get_customerdetailsnew(customerid);

                                    strpart = strpart + System.Environment.NewLine;
                                    if (dtcusto.Rows[0]["address"].ToString() != "")
                                    {
                                        strpart = strpart + "<ADDRESS.LIST>";
                                        strpart = strpart + System.Environment.NewLine;
                                        strpart = strpart + "<address>" + dtcusto.Rows[0]["address"].ToString().Replace("&", " &amp; ").Replace("'", "&#39;") + "</address>";
                                        strpart = strpart + System.Environment.NewLine;
                                        strpart = strpart + "</ADDRESS.LIST>";
                                        strpart = strpart + System.Environment.NewLine;
                                    }
                                    if (dtcusto.Rows[0]["zip"].ToString() != "")
                                    {
                                        strpart = strpart + "<PINCODE>" + dtcusto.Rows[0]["zip"].ToString() + "</PINCODE>";
                                        strpart = strpart + System.Environment.NewLine;
                                    }
                                    if (dtcusto.Rows[0]["panno"].ToString() != "")
                                    {
                                        strpart = strpart + "<INCOMETAXNUMBER>" + dtcusto.Rows[0]["panno"].ToString() + "</INCOMETAXNUMBER>";
                                        strpart = strpart + System.Environment.NewLine;
                                    }

                                    if (dtcusto.Rows[0]["statename"].ToString() != "")
                                    {
                                        strpart = strpart + "<STATENAME>" + dtcusto.Rows[0]["statename"].ToString() + "</STATENAME>";
                                        strpart = strpart + System.Environment.NewLine;
                                    }
                                    if (dtcusto.Rows[0]["countryname"].ToString() != "")
                                    {
                                        strpart = strpart + "<COUNTRYOFRESIDENCE>" + dtcusto.Rows[0]["countryname"].ToString() + "</COUNTRYOFRESIDENCE>";
                                        strpart = strpart + System.Environment.NewLine;
                                    }
                                    if (dtcusto.Rows[0]["gstin1"].ToString() != "")
                                    {
                                        strpart = strpart + "<PARTYGSTIN>" + dtcusto.Rows[0]["gstin1"].ToString() + "</PARTYGSTIN>";
                                        strpart = strpart + System.Environment.NewLine;
                                    }

                                }

                            }


                        }
                        else
                        {
                            if (Convert.ToInt32(ldt.Rows[g]["customerid"].ToString()) > 0)
                            {
                                customerid = Convert.ToInt32(ldt.Rows[g]["customerid"].ToString());
                                dt1 = Invobj.spcountinvoice4particularcustomer(customerid, branchid, Convert.ToInt32(txt_year.Text), empid);
                                debit = Convert.ToInt32(dt1.Rows[0]["debit"].ToString());
                                credit = Convert.ToInt32(dt1.Rows[0]["credit"].ToString());
                                if (debit > credit)
                                {
                                    debotors = "Sundry Debtors";
                                }
                                else if (credit > debit)
                                {
                                    debotors = "Sundry Creditors";
                                }
                                strpart = strpart + "<PARENT>" + debotors.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</PARENT> ";
                                dtcusto = Custobj.Get_customerdetailsnew(customerid);

                                strpart = strpart + System.Environment.NewLine;
                                if (dtcusto.Rows[0]["address"].ToString() != "")
                                {
                                    strpart = strpart + "<ADDRESS.LIST>";
                                    strpart = strpart + System.Environment.NewLine;
                                    strpart = strpart + "<address>" + dtcusto.Rows[0]["address"].ToString().Replace("&", " &amp; ").Replace("'", "&#39;") +"</address>";
                                    strpart = strpart + System.Environment.NewLine;
                                    strpart = strpart + "</ADDRESS.LIST>";
                                    strpart = strpart + System.Environment.NewLine;
                                }
                                if (dtcusto.Rows[0]["statename"].ToString() != "")
                                {
                                    strpart = strpart + "<STATENAME>" + dtcusto.Rows[0]["statename"].ToString() + "</STATENAME>";
                                    strpart = strpart + System.Environment.NewLine;
                                }
                                if (dtcusto.Rows[0]["countryname"].ToString() != "")
                                {
                                    strpart = strpart + "<COUNTRYOFRESIDENCE>" + dtcusto.Rows[0]["countryname"].ToString() + "</COUNTRYOFRESIDENCE>";
                                    strpart = strpart + System.Environment.NewLine;
                                }
                                if (dtcusto.Rows[0]["gstin"].ToString() != "")
                                {
                                    strpart = strpart + "<PARTYGSTIN>" + dtcusto.Rows[0]["gstin"].ToString() + "</PARTYGSTIN>";
                                    strpart = strpart + System.Environment.NewLine;
                                }

                                //if (dtcusto.Rows[0]["gstin"].ToString() != "")
                                //{
                                //    strpart = strpart + "<PARTYGSTIN>" + dtcusto.Rows[0]["gstin"].ToString() + "</PARTYGSTIN>";
                                //    strpart = strpart + System.Environment.NewLine;
                                //}



                            }

                        }
                        //strpart = strpart + "<PARENT>" + ldt.Rows[g]["parent"].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;") + "</PARENT> ";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<ISBILLWISEON>" + ldt.Rows[g]["billwise"].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</ISBILLWISEON> ";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
                        strpart = strpart + System.Environment.NewLine;
                        if (ldt.Rows[g]["suffix"].ToString() != "")
                        {
                            strpart = strpart + " <ISCOSTCENTRESON>Yes</ISCOSTCENTRESON>";
                            strpart = strpart + System.Environment.NewLine;
                        }
                        strpart = strpart + "</LEDGER>";
                        strpart = strpart + System.Environment.NewLine;

                    }
                }
            }


            if (ddl_voucher.Text == "Bank Deposit - Transfer To CO" || ddl_voucher.Text == "Cash Deposit - Transfer To CO")
            {
            }
            else
            {
                //  ldt = Invobj.GETTALLYCostname(Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), ddl_voucher.Text, branchid, Convert.ToInt32(txt_year.Text));
                if (ddl_voucher.SelectedItem.Text != "ALL")
                {

                    ldt = Invobj.GETTALLYCostname(Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), ddl_voucher.Text, branchid, Convert.ToInt32(txt_year.Text));
                }
                else if (ddl_voucher.SelectedItem.Text == "ALL")
                {

                    ldt = Invobj.GETTALLYCostname(0, 0, ddl_voucher.Text, branchid, Convert.ToInt32(txt_year.Text), dtdate);
                }
            }

            if (ldt.Rows.Count > 0)
            {


                for (int g = 0; g < ldt.Rows.Count; g++)
                {
                    str_trantype = ldt.Rows[g]["trantype"].ToString();
                    jobprefix = ldt.Rows[g]["jobno"].ToString();
                    if (jobprefix.Length > 0 && jobprefix.Length < 2)
                    {
                        numformat = "00";
                    }
                    else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                    {
                        numformat = "0";
                    }
                    else
                    {
                        numformat = "";
                    }

                    strpart += "<COSTCENTRE NAME='" + pcode.Substring(4, 3) + "-" + ldt.Rows[g]["costname"].ToString() + "-" + ldt.Rows[g]["jobno"].ToString() + "'>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<PARENT/>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<CATEGORY>" + ldt.Rows[g]["cost"].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</CATEGORY> ";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<REVENUELEDFOROPBAL>No</REVENUELEDFOROPBAL>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<FORPAYROLL>No</FORPAYROLL>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<FORJOBCOSTING>No</FORJOBCOSTING>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<ISEMPLOYEEGROUP>No</ISEMPLOYEEGROUP>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<LANGUAGENAME.LIST>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<NAME.LIST TYPE='String'>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<NAME>" + pcode.Substring(4, 3) + "-" + ldt.Rows[g]["costname"].ToString() + "-" + ldt.Rows[g]["jobno"].ToString() + "</NAME>";
                    //  strpart += "<NAME>" + hid_portcode.Value + "E" + ldt.Rows[g]["costname"].ToString().Replace("FE", "FF").Replace("FI", "FI").Replace("NE", "EX").Replace("NI", "IM").Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;")  + ldt.Rows[g]["jobno"].ToString() + "</NAME>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "</NAME.LIST>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "<LANGUAGEID> 1033</LANGUAGEID>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "</LANGUAGENAME.LIST>";
                    strpart = strpart + System.Environment.NewLine;
                    strpart += "</COSTCENTRE>";
                    strpart = strpart + System.Environment.NewLine;
                }


            }

            DtRe = RcptObj.GetOSRecptChrg4Tally(RID);
            for (int i = 0; i < DtRe.Rows.Count; i++)
            {
                strpart += "<LEDGER NAME='" + DtRe.Rows[i][0].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"' ACTION='Create'>";
                strpart = strpart + System.Environment.NewLine;
                strpart += "<NAME.LIST>";
                strpart = strpart + System.Environment.NewLine;
                strpart += "<NAME>" + DtRe.Rows[i][0].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</NAME> ";
                strpart = strpart + System.Environment.NewLine;
                strpart += "</NAME.LIST>";
                strpart = strpart + System.Environment.NewLine;
                strpart += "<PARENT>Direct Incomes</PARENT> ";
                strpart = strpart + System.Environment.NewLine;
                strpart += "<ISBILLWISEON>No</ISBILLWISEON> ";
                strpart = strpart + System.Environment.NewLine;
                strpart += "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + System.Environment.NewLine;
                strpart += "</LEDGER>";
                strpart = strpart + System.Environment.NewLine;
            }

            strpart = strpart + "<LEDGER NAME='ExChange(-Loss / Profit)' ACTION='Create'>";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<NAME.LIST>";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<NAME>ExChange(-Loss / Profit)</NAME> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "</NAME.LIST>";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<PARENT>Direct Incomes</PARENT> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<ISBILLWISEON>No</ISBILLWISEON> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "</LEDGER>";
            strpart = strpart + System.Environment.NewLine;

            DataTable kser = new DataTable();
            if (ddl_voucher.Text == "Bank Deposit - Transfer To CO" || ddl_voucher.Text == "Cash Deposit - Transfer To CO")
            {

            }
            else
            {
                if (ddl_voucher.SelectedItem.Text != "ALL")
                {
                    kser = Invobj.GetVouchDtlswiseStaxcreate(Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), strvtype, vouyear, branchid);
                }

            }

            //kser = Invobj.GetVouchDtlswiseStaxcreate(Convert.ToInt32(txt_from.Text), Convert.ToInt32(txt_to.Text), strvtype, vouyear, branchid);
            for (int kk = 0; kk < kser.Rows.Count; kk++)
            {
                strpart = strpart + "<LEDGER NAME='" + kser.Rows[kk]["Charge"].ToString() + "' ACTION='Create'>";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<NAME.LIST>";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<NAME>" + kser.Rows[kk]["Charge"].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</NAME> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "</NAME.LIST>";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<PARENT>Direct Incomes</PARENT> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<ISBILLWISEON>No</ISBILLWISEON> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "</LEDGER>";
                strpart = strpart + System.Environment.NewLine;
            }

            //if (ddl_voucher.Text == "Credit Note - Operations" || ddl_voucher.Text == "Credit Note - Others" || ddl_voucher.Text == "Admin Purchase Invoice" || ddl_voucher.Text == "Payment Advise - Admin")
            //{
            //    if (ddl_voucher.Text == "Credit Note - Operations")
            //    {

            //        Dt = Invobj.ShowTallyDt(Convert.ToInt32(txt_from.Text), "PaymentAdvise", vouyear, branchid);
            //    }
            //    else if (ddl_voucher.Text == "Admin Purchase Invoice" || ddl_voucher.Text == "Payment Advise - Admin")
            //    {
            //        Dt = Invobj.ShowTallyDt(Convert.ToInt32(txt_from.Text), "PA-Admin", vouyear, branchid);
            //    }
            //    else if (ddl_voucher.Text == "Credit Note - Others")
            //    {
            //        Dt = Invobj.ShowTallyDt(Convert.ToInt32(txt_from.Text), "PA-CNHead", vouyear, branchid);
            //    }


            //    PACustID = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
            //    DtRece = TDSObj.GetTDSDtlsForCustomer(PACustID);
            //    CustTdsType = "";
            //    if (DtRece.Rows.Count > 0)
            //    {
            //        CustTdsType = DtRece.Rows[0]["tdsdesc"].ToString();
            //    }
            //    strpart = strpart + "<LEDGER NAME= 'Tds Payable " + CustTdsType + "' ACTION='Create'>";
            //}
            //else
            //{
            //    strpart = strpart + "<LEDGER NAME='Tds Payable CONTRACTORS' ACTION='Create'>";
            //}

            //strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "<NAME.LIST>";
            //strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "<NAME>Tds Payable CONTRACTORS</NAME> ";
            //strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "</NAME.LIST>";
            //strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "<PARENT>Direct Incomes</PARENT> ";
            //strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "<ISBILLWISEON>No</ISBILLWISEON> ";
            //strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
            //strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "</LEDGER>";
            //EDI
            /*if (ddl_voucher.Text == "Credit Note - Operations" || ddl_voucher.Text == "Credit Note - Others" || ddl_voucher.Text == "Admin Purchase Invoice" || ddl_voucher.Text == "Payment Advise - Admin")
            {
                if (ddl_voucher.Text == "Credit Note - Operations")
                {

                    Dt = Invobj.ShowTallyDtNEW(Convert.ToInt32(txt_from.Text), "PaymentAdvise", vouyear, branchid, Convert.ToInt32(txt_to.Text));
                }
                else if (ddl_voucher.Text == "Admin Purchase Invoice" || ddl_voucher.Text == "Payment Advise - Admin")
                {
                    Dt = Invobj.ShowTallyDtNEW(Convert.ToInt32(txt_from.Text), "PA-Admin", vouyear, branchid, Convert.ToInt32(txt_to.Text));
                }
                else if (ddl_voucher.Text == "Credit Note - Others")
                {
                    Dt = Invobj.ShowTallyDtNEW(Convert.ToInt32(txt_from.Text), "PA-CNHead", vouyear, branchid, Convert.ToInt32(txt_to.Text));
                }
                if (Dt.Rows.Count > 0)
                {
                    for (int jk = 0; jk < Dt.Rows.Count; jk++)
                    {
                        PACustID = Convert.ToInt32(Dt.Rows[jk]["customerid"].ToString());
                        DtRece = TDSObj.GetTDSDtlsForCustomer(PACustID);
                        CustTdsType = "";
                        if (DtRece.Rows.Count > 0)
                        {

                            CustTdsType = DtRece.Rows[0]["tdsdesc"].ToString();
                        }
                        else
                        {
                            CustTdsType = "Tds Payable CONTRACTORS";
                        }
                        strpart = strpart + "<LEDGER NAME= 'Tds Payable " + CustTdsType + "' ACTION='Create'>";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<NAME.LIST>";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<NAME>Tds Payable" + CustTdsType + "</NAME> ";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "</NAME.LIST>";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<PARENT>Direct Incomes</PARENT> ";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<ISBILLWISEON>No</ISBILLWISEON> ";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + System.Environment.NewLine;
                        strpart = strpart + "</LEDGER>";
                    }
                }



            }
            else
            {
                CustTdsType = "Tds Payable CONTRACTORS";
                strpart = strpart + "<LEDGER NAME='" + CustTdsType + "' ACTION='Create'>";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<NAME.LIST>";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<NAME>" + CustTdsType + "</NAME> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "</NAME.LIST>";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<PARENT>Direct Incomes</PARENT> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<ISBILLWISEON>No</ISBILLWISEON> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + System.Environment.NewLine;
                strpart = strpart + "</LEDGER>";
            }*/

            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<LEDGER NAME='Round Up' ACTION='Create'>";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<NAME.LIST>";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<NAME>Round Up</NAME> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "</NAME.LIST>";
            strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "<PARENT>Direct Incomes</PARENT> ";
            strpart = strpart + "<PARENT>Indirect Expenses</PARENT> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<ISBILLWISEON>No</ISBILLWISEON> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "</LEDGER>";

            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<LEDGER NAME='Round OFF' ACTION='Create'>";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<NAME.LIST>";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<NAME>Round OFF</NAME> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "</NAME.LIST>";
            strpart = strpart + System.Environment.NewLine;
            //strpart = strpart + "<PARENT>Direct Expenses</PARENT> ";
            strpart = strpart + "<PARENT>Indirect Expenses</PARENT> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<ISBILLWISEON>No</ISBILLWISEON> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "<AFFECTSSTOCK>No</AFFECTSSTOCK> ";
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + System.Environment.NewLine;
            strpart = strpart + "</LEDGER>";
            strpart = strpart + System.Environment.NewLine;
            return strpart;
        }

        protected void btn_EDI_Click(object sender, EventArgs e)
        {
            try
            {
                string portcode = "";

                btn_cancel.ToolTip = "Cancel";


                checkvalue();
                Fn_Check();

                if (Check == false)
                {
                    return;
                }
                portcode = OSDCNObj.GetPortCodeForTally(branchid);
                hid_portcode.Value = portcode.Substring(4, 3);
                //hid_portcode.Value = portcode.Substring(2, 3);

                vouyear = Convert.ToInt32(txt_year.Text);
                switch (ddl_voucher.Text)
                {
                    case "Journal":
                        filename = "Jou";

                        strvtype = "J";
                        break;
                    case "Invoices":
                        filename = "Inv";
                        ledgerexpinc = "Income";
                        strvtype = "I";
                        break;
                    case "BOS":
                        filename = "Bos";
                        ledgerexpinc = "Income";
                        strvtype = "B";
                        break;
                    case "Purchase Invoice":// "PaymentAdvises":
                        ledgerexpinc = "Expenses";
                        filename = "PI";
                        strvtype = "P";
                        break;
                    case "Payment Advise - Admin":
                        ledgerexpinc = "Expenses";
                        filename = "PAAdmin";
                        strvtype = "";
                        break;
                    case "Admin Sales Invoice":
                        ledgerexpinc = "Income";
                        filename = "DNAdmin";
                        strvtype = "";
                        break;
                    case "OSSI":
                        vouname = "Debit Note";
                        filename = "OSSI";
                        ledgerexpinc = "Income";
                        strvtype = "";
                        break;
                    case "OSPI":
                        vouname = "Credit Note";
                        filename = "OSPI";
                        ledgerexpinc = "Expenses";
                        strvtype = "";
                        break;
                    case "Debit Note - Others":
                        filename = "DN";
                        ledgerexpinc = "Income";
                        strvtype = "V";
                        break;
                    case "Credit Note - Others":
                        filename = "CN";
                        ledgerexpinc = "Expenses";
                        strvtype = "E";
                        break;
                    case "Receipt - Bank":
                        filename = "BR";
                        break;
                    case "Receipt - Cash":
                        filename = "CR";
                        break;
                    case "Bank Payment":
                        filename = "BP";
                        break;
                    case "Cash Payment":
                        filename = "CP";
                        break;
                    case "Bank Payment - Transfer From CO":
                        filename = "BP";
                        break;
                    case "Cash Payment - Transfer From CO":
                        filename = "CP";
                        break;
                    case "Bank Deposit - Transfer To CO":
                        filename = "BD";
                        vouname = "Bank Deposit";
                        dsledgname = "Cheque Collection Account";
                        break;
                    case "Cash Deposit - Transfer To CO":
                        filename = "CD";
                        vouname = "Cash Deposit";
                        dsledgname = "Cash Collection Account";
                        break;
                    case "Remittance-Receipt":
                        filename = "RR";
                        break;
                    case "Remittance-Payment":
                        filename = "RP";
                        break;
                }
                countno = 0;
                if (ddl_voucher.Text == "Receipt - Bank")
                {

                }

                voutype = ddl_voucher.Text;

                ddlref = ddl_reference.Text;
                strpart = "";
                Str_XML += "<TALLYMESSAGE xmlns:UDF='TallyUDF'>" + System.Environment.NewLine;
                Str_XML += getdtlsxml();
                blrTDS = false;
                if (ddl_voucher.Text == "Bank Deposit - Transfer To CO" || ddl_voucher.Text == "Cash Deposit - Transfer To CO")
                {
                    GetDepositdata();
                }
                else
                {
                    int_From = Convert.ToInt32(txt_from.Text);
                    int_To = Convert.ToInt32(txt_to.Text);
                    for (j = int_From; j <= int_To; j++)
                    {
                        blrTDS = false;
                        if (ddl_voucher.Text == "PaymentAdvises" || ddl_voucher.Text == "Purchase Invoice")
                        {
                            if (Invobj.CheckTDSApplyORNot("P", j, vouyear, branchid) != 0)
                            {
                                blrTDS = true;
                            }
                        }
                        else if (ddl_voucher.Text == "Payment Advise - Admin")
                        {
                            if (Invobj.CheckTDSApplyORNot("S", j, vouyear, branchid) != 0)
                            {
                                blrTDS = true;
                            }
                        }
                        else if (ddl_voucher.Text == "Credit Note - Others")
                        {
                            if (Invobj.CheckTDSApplyORNot("E", j, vouyear, branchid) != 0)
                            {
                                blrTDS = true;
                            }
                        }
                        blr = false;
                        if (ddl_voucher.Text == "PaymentAdvises" || ddl_voucher.Text == "Purchase Invoice" || ddl_voucher.Text == "Payment Advise - Admin" || ddl_voucher.Text == "Credit Note - Others")
                        {
                            if (blrTDS == true)
                            {
                                GetVoucherType(j);
                                if (blr == true)
                                {
                                    switch (voutype)
                                    {
                                        case "Invoices":
                                            Str_XML += Part1();
                                            Str_XML += Part2();
                                            Str_XML += Part4(j);
                                            Str_XML += Part3(j);
                                            Str_XML += Part5(j);
                                            break;
                                        case "BOS":
                                            Str_XML += Part1();
                                            Str_XML += Part2();
                                            Str_XML += Part4(j);
                                            Str_XML += Part3(j);
                                            Str_XML += Part5(j);
                                            break;
                                        case "Admin Sales Invoice":
                                            Str_XML += Part1();
                                            Str_XML += Part2();
                                            Str_XML += Part4(j);
                                            Str_XML += Part3(j);
                                            Str_XML += Part5(j);
                                            break;
                                        case "Purchase Invoice": //"PaymentAdvises":
                                            Str_XML += Part1();
                                            Str_XML += Part2();
                                            Str_XML += Part4(j);
                                            Str_XML += Part3(j);
                                            Str_XML += Part5(j);
                                            Str_XML += Part6();
                                            break;
                                        case "Payment Advise - Admin":
                                            Str_XML += Part1();
                                            Str_XML += Part2();
                                            Str_XML += Part3(j);
                                            Str_XML += Part4(j);
                                            Str_XML += Part5(j);
                                            Str_XML += Part6();
                                            break;
                                        case "Admin Purchase Invoice":
                                            Str_XML += Part1();
                                            Str_XML += Part2();
                                            Str_XML += Part3(j);
                                            Str_XML += Part4(j);
                                            Str_XML += Part5(j);
                                            Str_XML += Part6();
                                            break;
                                        case "OSSI":
                                            Str_XML += OSDCNPart1();
                                            Str_XML += Part2();
                                            Str_XML += OSDCNPart2();
                                            Str_XML += OSDCNPart3();
                                            Str_XML += Part5(j);
                                            Str_XML += OSDCNPart4();

                                            //  Str_XML += OSDNFAJV(j);
                                            break;
                                        case "OSPI":
                                            Str_XML += OSDCNPart1();
                                            Str_XML += Part2();
                                            Str_XML += OSDCNPart2();
                                            Str_XML += OSDCNPart3();
                                            Str_XML += Part5(j);
                                            Str_XML += OSDCNPart4();

                                            //  Str_XML +=OSCNFAJV(j);
                                            break;
                                        case "Debit Note - Others":
                                            Str_XML += Part1();
                                            Str_XML += Part2();
                                            Str_XML += Part4(j);
                                            Str_XML += Part3(j);
                                            Str_XML += Part5(j);
                                            //  Str_XML += DNFAJV(j);
                                            break;
                                        case "Credit Note - Others":
                                            Str_XML += Part1();
                                            Str_XML += Part2();
                                            Str_XML += Part3(j);
                                            Str_XML += Part4(j);
                                            Str_XML += Part5(j);
                                            Str_XML += Part6();
                                            // Str_XML += CNFAJV(j);
                                            break;

                                        case "Receipt - Bank":
                                            break;
                                        case "Remittance-Receipt":
                                            break;
                                        case "Remittance-Payment":
                                            break;
                                    }
                                    Invobj.UpdVouTally(j, branchid, vouyear, ddl_voucher.Text, empid);
                                    logobj.InsLogDetail(empid, 161, 1, branchid, j + ddl_voucher.Text);
                                }
                            }
                            else
                            {
                                if (ddl_voucher.Text == "PaymentAdvises" || ddl_voucher.Text == "Purchase Invoice")
                                {
                                    ScriptManager.RegisterStartupScript(btn_EDI, typeof(Button), "logix", "alertify.alert('TDS has not Applied in PA # :" + j + System.Environment.NewLine + "and the same has not been transfer into Tally XML');", true);
                                }
                                else if (ddl_voucher.Text == "Payment Advise - Admin")
                                {
                                    ScriptManager.RegisterStartupScript(btn_EDI, typeof(Button), "logix", "alertify.alert('TDS has not Applied in PA Admin # :" + j + System.Environment.NewLine + "and the same has not been transfer into Tally XML');", true);
                                }
                                else if (ddl_voucher.Text == "Credit Note - Others")
                                {
                                    ScriptManager.RegisterStartupScript(btn_EDI, typeof(Button), "logix", "alertify.alert('TDS has not Applied in CN # :" + j + System.Environment.NewLine + "and the same has not been transfer into Tally XML');", true);
                                }
                            }
                        }
                        else
                        {
                            GetVoucherType(j);
                            if (blr == true)
                            {
                                switch (voutype)
                                {
                                    case "Invoices":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(j);
                                        Str_XML += Part3(j);
                                        Str_XML += Part5(j);
                                        break;
                                    case "BOS":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(j);
                                        Str_XML += Part3(j);
                                        Str_XML += Part5(j);
                                        break;
                                    case "Admin Sales Invoice":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(j);
                                        Str_XML += Part3(j);
                                        Str_XML += Part5(j);
                                        break;
                                    case "Payment Advise - Admin":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part3(j);
                                        Str_XML += Part4(j);
                                        Str_XML += Part5(j);
                                        Str_XML += Part6();
                                        break;
                                    case "Admin Purchase Invoice":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part3(j);
                                        Str_XML += Part4(j);
                                        Str_XML += Part5(j);
                                        Str_XML += Part6();
                                        break;
                                    case "Purchase Invoice": // "PaymentAdvises":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part3(j);
                                        Str_XML += Part4(j);
                                        Str_XML += Part5(j);
                                        Str_XML += Part6();
                                        break;
                                    case "OSSI":
                                        DS = OSDCNObj.SelOSDebitCreditDetails(j, vouyear, branchid, "D");
                                        Str_XML += OSDCNPart1();
                                        Str_XML += Part2();
                                        Str_XML += OSDCNPart2();
                                        Str_XML += OSDCNPart3();
                                        Str_XML += Part5(j);
                                        Str_XML += OSDCNPart4();

                                        // Str_XML += OSDNFAJV(j);
                                        break;
                                    case "OSPI":
                                        DS = OSDCNObj.SelOSDebitCreditDetails(j, vouyear, branchid, "C");
                                        Str_XML += OSDCNPart1();
                                        Str_XML += Part2();
                                        Str_XML += OSDCNPart2();
                                        Str_XML += OSDCNPart3();
                                        Str_XML += Part5(j);
                                        Str_XML += OSDCNPart4();
                                        //  Str_XML += OSCNFAJV(j);
                                        break;
                                    case "Debit Note - Others":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(j);
                                        Str_XML += Part3(j);
                                        Str_XML += Part5(j);
                                        //  Str_XML += DNFAJV(j);
                                        break;
                                    case "Credit Note - Others":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part3(j);
                                        Str_XML += Part4(j);
                                        Str_XML += Part5(j);
                                        Str_XML += Part6();
                                        // Str_XML += CNFAJV(j);
                                        break;
                                    case "Receipt - Bank":
                                        break;

                                    case "Remittance-Receipt":
                                        break;

                                    case "Remittance-Payment":
                                        break;
                                }

                                Invobj.UpdVouTally(j, branchid, vouyear, ddl_voucher.Text, empid);
                               // logobj.InsLogDetail(empid, 161, 1, branchid, j + ddl_voucher.Text);
                                logobj.InsLogDetail(empid, 1959, 1, branchid, j + ddl_voucher.Text);
                            }
                        }
                    }
                }

                Str_XML += "</TALLYMESSAGE>";
                //Str_XML = Str_XML.Replace("FE", "OE").Replace("FI", "OI");

                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename=" + filename + txt_from.Text + "To" + txt_to.Text + ".XML");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "text/xml";
                Response.Write(Str_XML);
                if (ddl_voucher.Text == "PaymentAdvises" || ddl_voucher.Text == "Purchase Invoice" || ddl_voucher.Text == "Payment Advise - Admin" || ddl_voucher.Text == "Credit Note - Others")
                {
                    if (blrTDS == true)
                    {
                        ScriptManager.RegisterStartupScript(btn_EDI, typeof(Button), "logix", "alertify.alert('Tally EDI File has been Created');", true);
                    }
                    else
                    {
                        if (ddl_voucher.Text == "Bank Deposit - Transfer To CO" || ddl_voucher.Text == "Cash Deposit - Transfer To CO")
                        {
                            ScriptManager.RegisterStartupScript(btn_EDI, typeof(Button), "logix", "alertify.alert('Tally EDI File has been Created  " + filename + txt_from.Text + ".XML');", true);
                        }
                        else
                        {
                            if (Convert.ToInt32(txt_from.Text) != Convert.ToInt32(txt_to.Text))
                            {
                                ScriptManager.RegisterStartupScript(btn_EDI, typeof(Button), "logix", "alertify.alert('Tally EDI File has been Created  " + filename + txt_from.Text + "To" + (Convert.ToInt32((txt_to.Text)) - 1) + ".XML');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_EDI, typeof(Button), "logix", "alertify.alert('" + filename + txt_from.Text + "To" + txt_to.Text + ".XML');", true);
                            }
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_EDI, typeof(Button), "logix", "alertify.alert('Tally EDI File has been Created');", true);
                }
                Response.End();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected string OSDCNPart3(string parttype)
        {
            string isdeem = "";
            strpart5 = "";
            if (ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "Debit Note - Others")
            {
                isdeem = "No";
            }
            else
            {
                isdeem = "Yes";
            }
            return strpart5;
        }

        protected string DNFAJV(int vouno)
        {
            strpart1 = "";
            string jvcusttype = "";
            jvcusttype = Custobj.GetCustomerType(JVDNCustomerid);
            int jvvouno = 0; string strjvvou = "";
            jvvouno = Invobj.GetAlreadyJVNo("V", vouno, branchid, Convert.ToInt32(txt_year.Text));
            if (jvvouno == 0)
            {
                jvvouno = Invobj.GetJVNo(branchid);
                Invobj.InsDCNJV("V", j, jvvouno, branchid, Convert.ToInt32(txt_year.Text), divisionid);
            }
            strjvvou = strtrantype + "/" + JVpcode + "/" + jvvouno + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
            string FA = "FA-JV";
            strpart1 += "<VOUCHER REMOTEID='' VCHTYPE='" + FA + "' ACTION='CREATE'>" + System.Environment.NewLine;
            strpart1 += System.Environment.NewLine;
            strpart1 += "<DATE>" + voudate + "</DATE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<NARRATION>" + narration + "</NARRATION>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<VOUCHERTYPENAME>FA-JV</VOUCHERTYPENAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<VOUCHERNUMBER>" + strjvvou + "</VOUCHERNUMBER>";
            strpart1 += System.Environment.NewLine;

            if (ddl_reference.Text == "Voucher No")
            {
                strpart1 += "<REFERENCE>" + strtrantype + " " + jvvouno + "</REFERENCE>";
            }
            else
            {
                strpart1 += "<REFERENCE>" + reference + "</REFERENCE>";
            }
            strpart1 += System.Environment.NewLine;
            strpart1 += "<PARTYLEDGERNAME>" + partyledger + "</PARTYLEDGERNAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<AUDITED>No</AUDITED>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<FORJOBCOSTING>No</FORJOBCOSTING>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISOPTIONAL>No</ISOPTIONAL>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<EFFECTIVEDATE>" + voudate + "</EFFECTIVEDATE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USEFORINTEREST>No</USEFORINTEREST>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USEFORGAINLOSS>No</USEFORGAINLOSS>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USEFORCOMPOUND>No</USEFORCOMPOUND>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<EXCISEOPENING>No</EXCISEOPENING>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISCANCELLED>No</ISCANCELLED>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<HASCASHFLOW>No</HASCASHFLOW>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISPOSTDATED>No</ISPOSTDATED>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISINVOICE>No</ISINVOICE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<MFGJOURNAL>No</MFGJOURNAL>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<HASDISCOUNTS>No</HASDISCOUNTS>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ASPAYSLIP>No</ASPAYSLIP>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISDELETED>No</ISDELETED>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;

            strpart1 += "<ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;

            if (divisionid == 1)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else if (divisionid == 2)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else if (divisionid == 3)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }

            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<AMOUNT>" + dctotal + "</AMOUNT>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;

            strpart1 += "<ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERNAME>" + partyledger + "</LEDGERNAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<AMOUNT>" + dctotalamount + "</AMOUNT>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</VOUCHER>" + System.Environment.NewLine;

            return strpart1;
        }

        protected string CNFAJV(int vouno)
        {
            strpart1 = ""; int jvvouno = 0;
            string jvcusttype = "", strjvvou = "";
            jvcusttype = Custobj.GetCustomerType(JVDNCustomerid);
            if (jvcusttype == "P")
            {
                jvvouno = Invobj.GetAlreadyJVNo("E", j, branchid, Convert.ToInt32(txt_year.Text));
                if (jvvouno == 0)
                {
                    jvvouno = Invobj.GetJVNo(branchid);
                    Invobj.InsDCNJV("E", vouno, jvvouno, branchid, Convert.ToInt32(txt_year.Text), divisionid);
                }

                strjvvou = strtrantype + "/" + JVpcode + "/" + jvvouno + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                string FA = "FA-JV";
                strpart1 += "<VOUCHER REMOTEID='' VCHTYPE='" + FA + "' ACTION='CREATE'>" + System.Environment.NewLine;
                strpart1 += System.Environment.NewLine;
                strpart1 += "<DATE>" + voudate + "</DATE>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<NARRATION>" + narration + "</NARRATION>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<VOUCHERTYPENAME>FA-JV</VOUCHERTYPENAME>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<VOUCHERNUMBER>" + strjvvou + "</VOUCHERNUMBER>";
                strpart1 += System.Environment.NewLine;
                if (ddl_reference.Text == "Voucher No")
                {
                    strpart1 = strpart1 + "<REFERENCE>" + strtrantype + " " + jvvouno + "</REFERENCE>";
                }
                else
                {
                    strpart1 = strpart1 + "<REFERENCE>" + reference + "</REFERENCE>";
                }
                strpart1 += System.Environment.NewLine;
                strpart1 += "<PARTYLEDGERNAME>" + partyledger + "</PARTYLEDGERNAME>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<AUDITED>No</AUDITED>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<FORJOBCOSTING>No</FORJOBCOSTING>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISOPTIONAL>No</ISOPTIONAL>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<EFFECTIVEDATE>" + voudate + "</EFFECTIVEDATE>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<USEFORINTEREST>No</USEFORINTEREST>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<USEFORGAINLOSS>No</USEFORGAINLOSS>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<USEFORCOMPOUND>No</USEFORCOMPOUND>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<EXCISEOPENING>No</EXCISEOPENING>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISCANCELLED>No</ISCANCELLED>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<HASCASHFLOW>No</HASCASHFLOW>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISPOSTDATED>No</ISPOSTDATED>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISINVOICE>No</ISINVOICE>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<MFGJOURNAL>No</MFGJOURNAL>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<HASDISCOUNTS>No</HASDISCOUNTS>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ASPAYSLIP>No</ASPAYSLIP>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISDELETED>No</ISDELETED>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;


                strpart1 += "<ALLLEDGERENTRIES.LIST>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<LEDGERNAME>" + partyledger + "</LEDGERNAME>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<AMOUNT>" + dctotalamount + "</AMOUNT>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;

                strpart1 += "<ALLLEDGERENTRIES.LIST>";
                strpart1 += System.Environment.NewLine;
                if (divisionid == 1)
                {
                    strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
                }
                else if (divisionid == 2)
                {
                    strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
                }
                else if (divisionid == 3)
                {
                    strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
                }
                else
                {
                    strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
                }

                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "<AMOUNT>" + dctotal + "</AMOUNT>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "</ALLLEDGERENTRIES.LIST>";
                strpart1 += System.Environment.NewLine;
                strpart1 += "</VOUCHER>" + System.Environment.NewLine;
            }
            return strpart1;

        }

        protected string OSCNFAJV(int vouno)
        {
            strpart1 = ""; int jvvouno = 0;
            string strjvvou = "";
            jvvouno = Invobj.GetAlreadyJVNo("C", vouno, branchid, Convert.ToInt32(txt_year.Text));
            if (jvvouno == 0)
            {
                jvvouno = Invobj.GetJVNo(branchid);
                Invobj.InsDCNJV("C", vouno, jvvouno, branchid, Convert.ToInt32(txt_year.Text), divisionid);
            }
            strjvvou = dctrantype + "/" + JVpcode + "/" + jvvouno + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
            string FA = "FA-JV";
            strpart1 += "<VOUCHER REMOTEID='' VCHTYPE='" + FA + "' ACTION='CREATE'>" + System.Environment.NewLine;
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<DATE>" + dcdndate + "</DATE>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<NARRATION></NARRATION>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<VOUCHERTYPENAME>FA-JV</VOUCHERTYPENAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<VOUCHERNUMBER>" + strjvvou + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            strpart1 = strpart1 + "<REFERENCE></REFERENCE>" + System.Environment.NewLine;


            strpart1 += "<PARTYLEDGERNAME>" + partyledger + "</PARTYLEDGERNAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<AUDITED>No</AUDITED>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<FORJOBCOSTING>No</FORJOBCOSTING>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISOPTIONAL>No</ISOPTIONAL>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<EFFECTIVEDATE>" + dcdndate + "</EFFECTIVEDATE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USEFORINTEREST>No</USEFORINTEREST>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USEFORGAINLOSS>No</USEFORGAINLOSS>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USEFORCOMPOUND>No</USEFORCOMPOUND>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<EXCISEOPENING>No</EXCISEOPENING>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISCANCELLED>No</ISCANCELLED>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<HASCASHFLOW>No</HASCASHFLOW>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISPOSTDATED>No</ISPOSTDATED>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISINVOICE>No</ISINVOICE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<MFGJOURNAL>No</MFGJOURNAL>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<HASDISCOUNTS>No</HASDISCOUNTS>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ASPAYSLIP>No</ASPAYSLIP>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISDELETED>No</ISDELETED>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;

            strpart1 += "<ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERNAME>" + partyledger + "</LEDGERNAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<AMOUNT>" + dcnamount + "</AMOUNT>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;


            strpart1 += "<ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;
            if (divisionid == 1)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else if (divisionid == 2)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else if (divisionid == 3)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }

            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<AMOUNT>" + -dcnamount + "</AMOUNT>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</VOUCHER>" + System.Environment.NewLine;
            return strpart1;
        }

        protected string OSDNFAJV(int vouno)
        {
            strpart1 = "";
            int jvvouno = 0; string strjvvou = "";
            jvvouno = Invobj.GetAlreadyJVNo("D", vouno, branchid, Convert.ToInt32(txt_year.Text));
            if (jvvouno == 0)
            {
                jvvouno = Invobj.GetJVNo(branchid);
                Invobj.InsDCNJV("D", vouno, jvvouno, branchid, Convert.ToInt32(txt_year.Text), divisionid);
            }
            strjvvou = dctrantype + "/" + JVpcode + "/" + jvvouno + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
            strpart1 = "";
            string FA = "FA-JV";
            strpart1 += "<VOUCHER REMOTEID='' VCHTYPE='" + FA + "' ACTION='CREATE'>" + System.Environment.NewLine;
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<DATE>" + dcdndate + "</DATE>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<NARRATION></NARRATION>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<VOUCHERTYPENAME>FA-JV</VOUCHERTYPENAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<VOUCHERNUMBER>" + strjvvou + "</VOUCHERNUMBER>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<REFERENCE></REFERENCE>";
            strpart1 = strpart1 + "<PARTYLEDGERNAME>" + partyledger + "</PARTYLEDGERNAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<AUDITED>No</AUDITED>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<FORJOBCOSTING>No</FORJOBCOSTING>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<ISOPTIONAL>No</ISOPTIONAL>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<EFFECTIVEDATE>" + dcdndate + "</EFFECTIVEDATE>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<USEFORINTEREST>No</USEFORINTEREST>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<USEFORGAINLOSS>No</USEFORGAINLOSS>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<USEFORCOMPOUND>No</USEFORCOMPOUND>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<EXCISEOPENING>No</EXCISEOPENING>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<ISCANCELLED>No</ISCANCELLED>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<HASCASHFLOW>No</HASCASHFLOW>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<ISPOSTDATED>No</ISPOSTDATED>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<ISINVOICE>No</ISINVOICE>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<MFGJOURNAL>No</MFGJOURNAL>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<HASDISCOUNTS>No</HASDISCOUNTS>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<ASPAYSLIP>No</ASPAYSLIP>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<ISDELETED>No</ISDELETED>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<ASORIGINAL>No</ASORIGINAL>";
            strpart1 = strpart1 + "<ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;
            if (divisionid == 1)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else if (divisionid == 2)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else if (divisionid == 3)
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            else
            {
                strpart1 += "<LEDGERNAME>OVC Account-" + DivObj.GetShortName(divisionid) + "CO</LEDGERNAME>";
            }
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<AMOUNT>-" + dcnamount + "</AMOUNT>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</ALLLEDGERENTRIES.LIST>";

            strpart1 += "<ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERNAME>" + partyledger + "</LEDGERNAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "<AMOUNT>" + dcnamount + "</AMOUNT>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</ALLLEDGERENTRIES.LIST>";
            strpart1 += System.Environment.NewLine;
            strpart1 += "</VOUCHER>" + System.Environment.NewLine;


            return strpart1;
        }

        protected string OSDCNPart4()
        {
            strpart5 = "";
            strpart5 = strpart5 + "</VOUCHER>" + System.Environment.NewLine;
            return strpart5;
        }

        protected string OSDCNPart3()
        {
            strpart5 = "";
            string isdeem;
            if (ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "Debit Note - Others")
            {
                isdeem = "No";
            }
            else
            {
                isdeem = "Yes";
            }


            if (DS.Tables.Count > 0)
            {
                string BaseCurr = "";
                string ChrgName = "";
                //DataAccess.Masters.MasterExRate EXobj = new DataAccess.Masters.MasterExRate();
                BaseCurr = Session["Basecurr"].ToString();
                strpart5 = "";
                for (int v = 0; v < DS.Tables[1].Rows.Count; v++)
                {

                    strpart5 += "<ALLLEDGERENTRIES.LIST>";
                    strpart5 += System.Environment.NewLine;
                    //strpart5 = strpart5 + "<LEDGERNAME>" + DS.Tables[1].Rows[v][0].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;") + "</LEDGERNAME>";
                    ChrgName = (DS.Tables[1].Rows[v][0].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                    if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                    {
                        if (strtrantype == "NI")
                        {
                            // strpart5 += "<LEDGERNAME>SOC Imports " + ChrgName + " - Income</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        else
                        {
                            //strpart5 += "<LEDGERNAME>SOC Exports " + ChrgName + " - Income</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                    }
                    else
                    {
                        if (strtrantype == "FI" || strtrantype == "OI")
                        {
                            // strpart5 += "<LEDGERNAME>COC Imports " + ChrgName + " - Income</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        else if (strtrantype == "FE" || strtrantype == "OE")
                        {
                            //strpart5 += "<LEDGERNAME>COC Exports " + ChrgName + " - Income</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        if (strtrantype == "AI")
                        {
                            // strpart5 += "<LEDGERNAME>AIR Imports " + ChrgName + " - Income</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        else if (strtrantype == "AE")
                        {
                            // strpart5 += "<LEDGERNAME>AIR Exports " + ChrgName + " - Income</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        else if (strtrantype == "CH")
                        {
                            // strpart5 += "<LEDGERNAME>AIR Exports " + ChrgName + " - Income</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                    }
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "<ISDEEMEDPOSITIVE>" + isdeem + "</ISDEEMEDPOSITIVE>";
                    strpart5 += System.Environment.NewLine;
                    if (voutype == "OSSI")
                    {
                        strpart5 = strpart5 + "<AMOUNT>" + Convert.ToDouble(DS.Tables[1].Rows[v]["famt"]).ToString("#0.00") + "</AMOUNT>";
                    }
                    else if (voutype == "OSPI")
                    {
                        strpart5 = strpart5 + "<AMOUNT>" + Convert.ToDouble(DS.Tables[1].Rows[v]["famt"]).ToString("#0.00") + "</AMOUNT>";
                    }
                    //if (voutype == "OSSI")
                    //{
                    //    strpart5 = strpart5 + "<AMOUNT>" + DS.Tables[1].Rows[v]["curr"].ToString() + " " + DS.Tables[1].Rows[v]["fdamt"] + " @ " + BaseCurr + " " + DS.Tables[1].Rows[v]["exrate"] + "/" + DS.Tables[1].Rows[v]["curr"].ToString() + " = " + BaseCurr + " " + DS.Tables[1].Rows[v]["famt"] + "</AMOUNT>";
                    //}
                    //else if (voutype == "OSPI")
                    //{
                    //    strpart5 = strpart5 + "<AMOUNT>-" + DS.Tables[1].Rows[v]["curr"].ToString() + " " + (-(Convert.ToDouble(DS.Tables[1].Rows[v]["fdamt"]))).ToString() + " @ " + BaseCurr + " " + DS.Tables[1].Rows[v]["exrate"] + "/" + DS.Tables[1].Rows[v]["curr"].ToString() + " = " + BaseCurr + " " + DS.Tables[1].Rows[v]["famt"] + "</AMOUNT>";
                    //}
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "<CATEGORYALLOCATIONS.LIST>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "<CATEGORY>" + ledgernameexin + "</CATEGORY>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "<COSTCENTREALLOCATIONS.LIST>";
                    strpart5 += System.Environment.NewLine;
                    //strpart5 += "<NAME>" + DS.Tables[1].Rows[v][2].ToString() + " " + dcjobno + "</NAME>";
                    strpart5 += "<NAME>" + str_Voujobno + "</NAME>";
                    strpart5 += System.Environment.NewLine;

                    if (voutype == "OSSI")
                    {
                        strpart5 += "<AMOUNT>" + Convert.ToDouble(DS.Tables[1].Rows[v]["famt"]).ToString("#0.00") + "</AMOUNT>";
                    }
                    else if (voutype == "OSPI")
                    {
                        strpart5 += "<AMOUNT>" + Convert.ToDouble(DS.Tables[1].Rows[v]["famt"]).ToString("#0.00") + "</AMOUNT>";
                    }

                    strpart5 += System.Environment.NewLine;
                    strpart5 += "</COSTCENTREALLOCATIONS.LIST>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "</CATEGORYALLOCATIONS.LIST>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "</ALLLEDGERENTRIES.LIST>";
                }

                for (int v = 0; v < DS.Tables[3].Rows.Count; v++)
                {
                    //strpart5 = "";
                    strpart5 += "<ALLLEDGERENTRIES.LIST>";
                    strpart5 += System.Environment.NewLine;
                    //strpart5 = strpart5 + "<LEDGERNAME>" + DS.Tables[3].Rows[v][0].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;") + "</LEDGERNAME>";
                    ChrgName = (DS.Tables[3].Rows[v][0].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                    if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                    {
                        if (strtrantype == "NI")
                        {
                            //  strpart5 += "<LEDGERNAME>SOC Imports " + ChrgName + " - Expenses</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        else
                        {
                            // strpart5 += "<LEDGERNAME>SOC Exports " + ChrgName + " - Expenses</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                    }
                    else
                    {
                        if (strtrantype == "FI" || strtrantype == "OI")
                        {
                            //strpart5 += "<LEDGERNAME>COC Imports " + ChrgName + " - Expenses</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        else if (strtrantype == "FE" || strtrantype == "OE")
                        {
                            // strpart5 += "<LEDGERNAME>COC Exports " + ChrgName + " - Expenses</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        if (strtrantype == "AI")
                        {
                            //strpart5 += "<LEDGERNAME>AIR Imports " + ChrgName + " - Expenses</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        else if (strtrantype == "AE")
                        {
                            // strpart5 += "<LEDGERNAME>AIR Exports " + ChrgName + " - Expenses</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                        else if (strtrantype == "CH")
                        {
                            // strpart5 += "<LEDGERNAME>AIR Exports " + ChrgName + " - Expenses</LEDGERNAME>";
                            strpart5 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                        }
                    }
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "<ISDEEMEDPOSITIVE>" + isdeem + "</ISDEEMEDPOSITIVE>";
                    strpart5 += System.Environment.NewLine;

                    if (voutype == "OSSI")
                    {
                        strpart5 += "<AMOUNT>" + DS.Tables[3].Rows[v]["curr"].ToString() + " -" + Convert.ToDouble(DS.Tables[3].Rows[v]["fcamt"]).ToString("#0.00") + " @ " + BaseCurr + " " + Convert.ToDouble(DS.Tables[3].Rows[v]["exrate"]).ToString("#0.00") + "/" + DS.Tables[3].Rows[v]["curr"].ToString() + " = " + BaseCurr + " " + Convert.ToDouble(DS.Tables[3].Rows[v]["famt"]).ToString("#0.00") + "</AMOUNT>";
                    }
                    else if (voutype == "OSPI")
                    {
                        //strpart5 += "<AMOUNT>" + DS.Tables[3].Rows[v]["curr"].ToString() + " -" + Convert.ToDouble(DS.Tables[3].Rows[v]["fcamt"]).ToString("#0.00") + " @ " + BaseCurr + " " + Convert.ToDouble(DS.Tables[3].Rows[v]["exrate"]).ToString("#0.00") + "/" + DS.Tables[3].Rows[v]["curr"].ToString() + " = " + BaseCurr + " " + Convert.ToDouble(DS.Tables[3].Rows[v]["famt"]).ToString("#0.00") + "</AMOUNT>";
                        double amounttt = Convert.ToDouble(DS.Tables[3].Rows[v]["famt"]) * (-1);
                        double amt = Convert.ToDouble(DS.Tables[3].Rows[v]["fcamt"]) * (-1);
                        strpart5 += "<AMOUNT>-" + DS.Tables[3].Rows[v]["curr"].ToString() + " " + amt + " @ " + BaseCurr + " " + Convert.ToDouble(DS.Tables[3].Rows[v]["exrate"]).ToString("#0.00") + "/" + DS.Tables[3].Rows[v]["curr"].ToString() + " = -" + BaseCurr + " " + amounttt + "</AMOUNT>";

                    }

                    strpart5 += System.Environment.NewLine;
                    strpart5 += "<CATEGORYALLOCATIONS.LIST>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "<CATEGORY>" + ledgernameexin + "</CATEGORY>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "<COSTCENTREALLOCATIONS.LIST>";
                    strpart5 += System.Environment.NewLine;
                    //strpart5 += "<NAME>" + DS.Tables[3].Rows[v][2].ToString() + " " + dcjobno + "</NAME>";
                    strpart5 += "<NAME>" + str_Voujobno + "</NAME>";
                    strpart5 += System.Environment.NewLine;

                    if (voutype == "OSSI")
                    {
                        strpart5 += "<AMOUNT>" + Convert.ToDouble(DS.Tables[3].Rows[v]["famt"]).ToString("#0.00") + "</AMOUNT>";
                    }
                    else if (voutype == "OSPI")
                    {
                        strpart5 += "<AMOUNT>" + Convert.ToDouble(DS.Tables[3].Rows[v]["famt"]).ToString("#0.00") + "</AMOUNT>";
                    }

                    strpart5 += System.Environment.NewLine;
                    strpart5 += "</COSTCENTREALLOCATIONS.LIST>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "</CATEGORYALLOCATIONS.LIST>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 += "</ALLLEDGERENTRIES.LIST>";
                }
            }

            return strpart5;
            //strpart5 = strpart5 + "<ALLLEDGERENTRIES.LIST>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "<LEDGERNAME>" + ledgernameexin + "</LEDGERNAME>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>" + isdeem + "</ISDEEMEDPOSITIVE>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "<AMOUNT>" + dctotalamount + "</AMOUNT>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "<CATEGORYALLOCATIONS.LIST>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "<CATEGORY>" + ledgername + "</CATEGORY>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "<COSTCENTREALLOCATIONS.LIST>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "<NAME>" + strtrantype + "-" + dcjobno + "</NAME>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "<AMOUNT>" + dcnamount + "</AMOUNT>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "</COSTCENTREALLOCATIONS.LIST>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "</CATEGORYALLOCATIONS.LIST>";
            //strpart5 += System.Environment.NewLine;
            //strpart5 = strpart5 + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            //return strpart5;
        }

        protected string OSDCNPart2()
        {
            strpart4 = "";
            string isdeem;
            if (ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "Debit Note - Others")
            {
                isdeem = "Yes";
            }
            else
            {
                isdeem = "No";
            }
            string BaseCurr = "";
            BaseCurr = Session["Basecurr"].ToString();
            strpart4 = strpart4 + "<ALLLEDGERENTRIES.LIST>";
            strpart4 += System.Environment.NewLine;
            strpart4 = strpart4 + "<LEDGERNAME>" + partyledger + "</LEDGERNAME>";
            strpart4 += System.Environment.NewLine;
            strpart4 = strpart4 + "<ISDEEMEDPOSITIVE>" + isdeem + " </ISDEEMEDPOSITIVE>";
            strpart4 += System.Environment.NewLine;
            if (voutype == "OSSI")
            {
                double amounttt = Convert.ToDouble(DS.Tables[0].Rows[0]["famt"]) * (-1);
                double amt = Convert.ToDouble(DS.Tables[0].Rows[0]["fdamt"]) * (-1);
                strpart4 += "<AMOUNT>-" + DS.Tables[0].Rows[0]["curr"].ToString() + "  " + amt.ToString("#0.00") + " @ " + BaseCurr + " " + Convert.ToDouble(DS.Tables[0].Rows[0]["exrate"]).ToString("#0.00") + "/" + DS.Tables[0].Rows[0]["curr"].ToString() + " = -" + BaseCurr + " " + amounttt.ToString("#0.00") + "</AMOUNT>";
            }
            else if (voutype == "OSPI")
            {
                strpart4 += "<AMOUNT>" + DS.Tables[2].Rows[0]["curr"].ToString() + " " + Convert.ToDouble(DS.Tables[2].Rows[0]["fdamt"]).ToString("#0.00") + " @ " + BaseCurr + " " + Convert.ToDouble(DS.Tables[2].Rows[0]["exrate"]).ToString("#0.00") + "/" + DS.Tables[2].Rows[0]["curr"].ToString() + " = " + BaseCurr + " " + Convert.ToDouble(DS.Tables[2].Rows[0]["famt"]).ToString("#0.00") + "</AMOUNT>";
            }
            // strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
            strpart4 += System.Environment.NewLine;


            strpart4 = strpart4 + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
            //strpart4 = strpart4 + "<NAME>" + reference + cnt + "</NAME>" + System.Environment.NewLine;
            if (voutype == "OSPI")
            {
                strpart4 = strpart4 + "<NAME>" + dcvouno + "</NAME>" + System.Environment.NewLine;
                //strpart4 = strpart4 + "<NAME>" + DS.Tables[4].Rows[0]["vendorrefno"] + "</NAME>" + System.Environment.NewLine;

            }
            else
            {
                strpart4 = strpart4 + "<NAME>" + vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</NAME>" + System.Environment.NewLine;
            }
            //if (ddl_voucher.Text == "Invoices" || voutype == "Admin Sales Invoice" || voutype == "OSSI")
            //{
            strpart4 = strpart4 + "<BILLTYPE>New Ref</BILLTYPE>";
            //}
            //else
            //{
            //    strpart4 = strpart4 + "<BILLTYPE>Agst Ref</BILLTYPE>";
            //}
            strpart4 += System.Environment.NewLine;
            // strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
            if (voutype == "OSSI")
            {
                double amounttt = Convert.ToDouble(DS.Tables[0].Rows[0]["famt"]) * (-1);
                double amt = Convert.ToDouble(DS.Tables[0].Rows[0]["fdamt"]) * (-1);
                strpart4 += "<AMOUNT>-" + DS.Tables[0].Rows[0]["curr"].ToString() + "  " + amt.ToString("#0.00") + " @ " + BaseCurr + " " + Convert.ToDouble(DS.Tables[0].Rows[0]["exrate"]).ToString("#0.00") + "/" + DS.Tables[0].Rows[0]["curr"].ToString() + " = -" + BaseCurr + " " + amounttt.ToString("#0.00") + "</AMOUNT>";
            }
            else if (voutype == "OSPI")
            {
                strpart4 += "<AMOUNT>" + DS.Tables[2].Rows[0]["curr"].ToString() + " " + Convert.ToDouble(DS.Tables[2].Rows[0]["fdamt"]).ToString("#0.00") + " @ " + BaseCurr + " " + Convert.ToDouble(DS.Tables[2].Rows[0]["exrate"]).ToString("#0.00") + "/" + DS.Tables[2].Rows[0]["curr"].ToString() + " = " + BaseCurr + " " + Convert.ToDouble(DS.Tables[2].Rows[0]["famt"]).ToString("#0.00") + "</AMOUNT>";
            }
            //if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
            //{
            //    if (custtype == "P")
            //    {
            //        strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
            //    }
            //    else
            //    {
            //        strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
            //    }
            //}
            //else
            //{
            //    if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
            //    {
            //        strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
            //    }
            //    else
            //    {
            //        //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
            //        strpart4 = strpart4 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
            //    }
            //    //strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
            //}
            strpart4 += System.Environment.NewLine;
            strpart4 = strpart4 + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;

            strpart4 = strpart4 + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            return strpart4;
        }

        protected string OSDCNPart1()
        {
            strpart1 = "";
            strpart1 += "<VOUCHER REMOTEID='' VCHTYPE='" + vouname + "' ACTION='CREATE'>" + System.Environment.NewLine;
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<DATE>" + dcdndate + "</DATE>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<NARRATION>" + narration + "</NARRATION>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<VOUCHERTYPENAME>" + vouname + "</VOUCHERTYPENAME>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<VOUCHERNUMBER>" + dcvouno + "</VOUCHERNUMBER>";
            strpart1 += System.Environment.NewLine;
            strpart1 = strpart1 + "<REFERENCE>" + reference + "</REFERENCE>" + System.Environment.NewLine;
            return strpart1;
        }

        protected string Part6()
        {
            strpart5 = "";
            if (CustTdsType != "")
            {
                if (PATdsAmt != 0)
                {
                    strpart5 = strpart5 + "<ALLLEDGERENTRIES.LIST>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 = strpart5 + "<LEDGERNAME>Tds Payable " + CustTdsType + "</LEDGERNAME>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 = strpart5 + "<AMOUNT>" + PATdsAmt + "</AMOUNT>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 = strpart5 + "<REFERENCE>" + vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</REFERENCE>";
                    strpart5 += System.Environment.NewLine;
                    strpart5 = strpart5 + "</ALLLEDGERENTRIES.LIST>";
                    strpart5 += System.Environment.NewLine;
                }
            }
            strpart5 = strpart5 + "</VOUCHER>" + System.Environment.NewLine;
            return strpart5;
        }

        protected string Part5(int vouno)
        {
            strpart5 = "";
            string strsttype = "";
            DataTable DtST = new DataTable();
            double stamount = 0;
            switch (voutype)
            {
                case "Invoices":
                    DtST = Invobj.GetSTAmt4STType("I", vouno, branchid, vouyear);
                    break;
                case "BOS":
                    DtST = Invobj.GetSTAmt4STType("B", vouno, branchid, vouyear);
                    break;
                case "Admin Sales Invoice":
                    DtST = Invobj.GetSTAmt4STType("AD", vouno, branchid, vouyear);
                    break;
                case "Purchase Invoice":// "PaymentAdvises":
                    DtST = Invobj.GetSTAmt4STType("P", vouno, branchid, vouyear);
                    break;
                case "Payment Advise - Admin":
                    DtST = Invobj.GetSTAmt4STType("AC", vouno, branchid, vouyear);
                    break;
                case "Admin Purchase Invoice":
                    DtST = Invobj.GetSTAmt4STType("AC", vouno, branchid, vouyear);
                    break;
                case "Debit Note - Others":
                    DtST = Invobj.GetSTAmt4STType("V", vouno, branchid, vouyear);
                    break;
                case "Credit Note - Others":
                    DtST = Invobj.GetSTAmt4STType("E", vouno, branchid, vouyear);
                    break;
                case "OSSI":
                    DtST = Invobj.GetSTAmt4STType("D", vouno, branchid, vouyear);
                    break;
                case "OSPI":
                    DtST = Invobj.GetSTAmt4STType("C", vouno, branchid, vouyear);
                    break;
            }
            if (DtST.Rows.Count > 0)
            {
                for (int t = 0; t < DtST.Rows.Count; t++)
                {
                    strsttype = DtST.Rows[t][0].ToString();

                    switch (voutype)
                    {
                        case "Invoices":
                            stamount = Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "BOS":
                            stamount = Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "Admin Sales Invoice":
                            stamount = Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "Purchase Invoice": //"PaymentAdvises":
                            stamount = -Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "Payment Advise - Admin":
                            stamount = -Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "Admin Purchase Invoice":
                            stamount = -Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "Debit Note - Others":
                            if (billtype == "R")
                            {
                                stamount = -Convert.ToDouble(DtST.Rows[t][1]);
                            }
                            else
                            {
                                stamount = Convert.ToDouble(DtST.Rows[t][1]);
                            }
                            //stamount = Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "Credit Note - Others":
                            stamount = -Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "OSSI":
                            stamount = Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                        case "OSPI":
                            stamount = -Convert.ToDouble(DtST.Rows[t][1]);
                            break;
                    }
                    string ledinc, ledexp;
                    if (Dt_voudate >= Convert.ToDateTime("07/01/2017"))
                    {
                        ledinc = "";
                        ledexp = "";
                    }
                    else
                    {
                        ledinc = "Service Tax Payable ";
                        ledexp = "Service Tax Recovery ";
                    }
                    if (voutype == "Invoices" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice")
                    {
                        strsttype = ledinc + strsttype;
                    }
                    else
                    {
                        strsttype = ledexp + strsttype;
                    }


                    if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                    {
                        if (custtype == "P")
                        {
                            if (billtype == "R" && voutype == "Debit Note - Others")
                            {
                                strsttype = strsttype.Replace("PAYABLE", "INPUT CREDIT AVAILABLE");

                            }
                            else if (billtype == "R" && voutype == "Credit Note - Others")
                            {
                                strsttype = strsttype.Replace("INPUT CREDIT AVAILABLE", "PAYABLE");
                            }
                            strpart5 = strpart5 + "<ALLLEDGERENTRIES.LIST>";
                            strpart5 += System.Environment.NewLine;
                            if (voutype == "Invoices" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice")
                            {
                                strpart5 = strpart5 + "<LEDGERNAME>" + strsttype + "</LEDGERNAME>";
                                strpart5 += System.Environment.NewLine;
                                strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                            }
                            else
                            {
                                strpart5 = strpart5 + "<LEDGERNAME>" + strsttype + "</LEDGERNAME>";
                                strpart5 += System.Environment.NewLine;
                                strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                            }
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<AMOUNT>" + stamount + "</AMOUNT>";
                            strpart5 += System.Environment.NewLine;
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<BILLALLOCATIONS.LIST>";
                            strpart5 += System.Environment.NewLine;
                            if (voutype == "PaymentAdvises" || voutype == "Purchase Invoice" || voutype == "Credit Note - Others" || voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin" || voutype == "OSSI" || voutype == "OSPI")
                            {
                                strpart5 = strpart5 + "<NAME>" + vendorrefno.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") + "</NAME>" + System.Environment.NewLine;
                            }
                            else
                            {
                                strpart5 = strpart5 + "<NAME>" + vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</NAME>";
                            }
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<BILLTYPE>" + "New Ref" + "</BILLTYPE>";
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<TDSDEDUCTEEISSPECIALRATE>" + "No" + "</TDSDEDUCTEEISSPECIALRATE>";
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<AMOUNT>" + stamount + "</AMOUNT>";
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<INTERESTCOLLECTION.LIST>" + "" + "</INTERESTCOLLECTION.LIST>";
                            strpart5 = strpart5 + "</BILLALLOCATIONS.LIST>";
                            strpart5 = strpart5 + "</ALLLEDGERENTRIES.LIST>";
                        }
                        else
                        {

                            if (billtype == "R" && voutype == "Debit Note - Others")
                            {


                                //strsttype =  strsttype.Replace("GST PAYABLE", "INPUT CREDIT AVAILABLE");
                                strsttype = strsttype.Replace("PAYABLE", "INPUT CREDIT AVAILABLE");

                            }
                            else if (billtype == "R" && voutype == "Credit Note - Others")
                            {
                                strsttype = strsttype.Replace("INPUT CREDIT AVAILABLE", "PAYABLE");
                            }
                            strpart5 = strpart5 + "<ALLLEDGERENTRIES.LIST>";
                            strpart5 += System.Environment.NewLine;
                            // if (voutype == "Invoices" || (voutype == "Debit Note - Others" && Session["dnreverse"].ToString()!="R") || voutype == "Admin Sales Invoice")
                            if (voutype == "Invoices" || (voutype == "Debit Note - Others" ) || voutype == "Admin Sales Invoice")
                            {
                                strpart5 = strpart5 + "<LEDGERNAME>" + strsttype + "</LEDGERNAME>";
                                strpart5 += System.Environment.NewLine;
                                strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                            }
                            //else if (voutype == "Debit Note - Others" && Session["dnreverse"].ToString() == "R")
                            else if (voutype == "Debit Note - Others" )
                            {
                                strpart5 = strpart5 + "<LEDGERNAME>" + strsttype + "</LEDGERNAME>";
                                strpart5 += System.Environment.NewLine;
                                strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                           }
                            else
                            {
                                strpart5 = strpart5 + "<LEDGERNAME>" + strsttype + "</LEDGERNAME>";
                                strpart5 += System.Environment.NewLine;
                                strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                            }
                            strpart5 += System.Environment.NewLine;
                            if (voutype == "Invoices" || (voutype == "Debit Note - Others") || voutype == "Admin Sales Invoice")
                            {
                                strpart5 = strpart5 + "<AMOUNT>" +-stamount + "</AMOUNT>";
                            }
                            else
                            {
                                strpart5 = strpart5 + "<AMOUNT>" + stamount + "</AMOUNT>";
                            }
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<BILLALLOCATIONS.LIST>";
                            strpart5 += System.Environment.NewLine;
                            if (voutype == "PaymentAdvises" || voutype == "Purchase Invoice" || voutype == "Credit Note - Others" || voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin" || voutype == "OSSI" || voutype == "OSPI")
                            {
                                strpart5 = strpart5 + "<NAME>" + vendorrefno.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") + "</NAME>" + System.Environment.NewLine;
                            }
                            else
                            {
                                strpart5 = strpart5 + "<NAME>" + vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</NAME>";
                            }
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<BILLTYPE>" + "New Ref" + "</BILLTYPE>";
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<TDSDEDUCTEEISSPECIALRATE>" + "No" + "</TDSDEDUCTEEISSPECIALRATE>";
                            strpart5 += System.Environment.NewLine;

                            if (voutype == "Invoices" || (voutype == "Debit Note - Others") || voutype == "Admin Sales Invoice")
                            {
                                strpart5 = strpart5 + "<AMOUNT>" + -stamount + "</AMOUNT>";
                            }
                            else
                            {
                                strpart5 = strpart5 + "<AMOUNT>" + stamount + "</AMOUNT>";
                            }
                            //strpart5 = strpart5 + "<AMOUNT>" + stamount + "</AMOUNT>";
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<INTERESTCOLLECTION.LIST>" + "" + "</INTERESTCOLLECTION.LIST>";
                            strpart5 = strpart5 + "</BILLALLOCATIONS.LIST>";
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "</ALLLEDGERENTRIES.LIST>";
                        }
                    }
                    else
                    {
                        strpart5 = strpart5 + "<ALLLEDGERENTRIES.LIST>";
                        strpart5 += System.Environment.NewLine;
                        if (voutype == "Invoices" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice" || voutype == "BOS" || voutype == "OSSI" || voutype == "OSPI")
                        {
                            strpart5 = strpart5 + "<LEDGERNAME>" + strsttype + "</LEDGERNAME>";
                            strpart5 += System.Environment.NewLine;


                            if (voutype == "OSSI" || voutype == "OSPI")
                            {
                                if (stamount < 0)
                                {
                                    strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>";
                                }
                                else
                                {
                                    strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                                }
                               
                            }
                            else
                            {
                                strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                            }
                        }
                        else
                        {
                            strpart5 = strpart5 + "<LEDGERNAME>" + strsttype + "</LEDGERNAME>";
                            strpart5 += System.Environment.NewLine;
                            strpart5 = strpart5 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                        }
                        strpart5 += System.Environment.NewLine;
                        strpart5 = strpart5 + "<AMOUNT>" + stamount + "</AMOUNT>";

                        strpart5 += System.Environment.NewLine;
                        strpart5 = strpart5 + "<BILLALLOCATIONS.LIST>";
                        strpart5 += System.Environment.NewLine;
                        if (voutype == "PaymentAdvises" || voutype == "Purchase Invoice" || voutype == "Credit Note - Others" || voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin" || voutype == "OSSI" || voutype == "OSPI")
                        {
                            strpart5 = strpart5 + "<NAME>" + vendorrefno.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") + "</NAME>" + System.Environment.NewLine;
                        }
                        else
                        {
                            strpart5 = strpart5 + "<NAME>" + vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</NAME>";
                        }
                        strpart5 += System.Environment.NewLine;
                        strpart5 = strpart5 + "<BILLTYPE>" + "New Ref" + "</BILLTYPE>";
                        strpart5 += System.Environment.NewLine;
                        strpart5 = strpart5 + "<TDSDEDUCTEEISSPECIALRATE>" + "No" + "</TDSDEDUCTEEISSPECIALRATE>";
                        strpart5 += System.Environment.NewLine;
                        strpart5 = strpart5 + "<AMOUNT>" + stamount + "</AMOUNT>";
                        strpart5 += System.Environment.NewLine;
                        strpart5 = strpart5 + "<INTERESTCOLLECTION.LIST>" + "" + "</INTERESTCOLLECTION.LIST>";
                        strpart5 = strpart5 + "</BILLALLOCATIONS.LIST>";

                        //strpart5 += System.Environment.NewLine;
                        //strpart5 = strpart5 + "<REFERENCE>" + vounoyear + "</REFERENCE>";

                        strpart5 += System.Environment.NewLine;
                        strpart5 = strpart5 + "</ALLLEDGERENTRIES.LIST>";
                    }
                }
            }
            if (voutype != "PaymentAdvises" && voutype != "Purchase Invoice" && voutype != "Credit Note - Others" && voutype != "Payment Advise - Admin" && voutype != "Admin Purchase Invoice" && voutype != "OSSI" && voutype != "OSPI")
            {
                if (voutype != "Debit Note - Others")
                {
                    strpart5 += System.Environment.NewLine;
                }
                strpart5 = strpart5 + "</VOUCHER>" + System.Environment.NewLine;
            }

            return strpart5;
        }
        protected string Part3(int vouno)
        {

            DataTable DtCA = new DataTable();
            strpart3 = "";
            if (voutype == "Invoices")
            {
                //DtCA = Invobj.GetInvPAChargeamount(vouno, "I", branchid, vouyear);
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "I", branchid, vouyear);
            }
            else if (voutype == "BOS")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "B", branchid, vouyear);
            }
            else if (voutype == "PaymentAdvises" || voutype == "Purchase Invoice")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "P", branchid, vouyear);
            }
            else if (voutype == "Debit Note - Others")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "V", branchid, vouyear);
            }
            else if (voutype == "Credit Note - Others")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "E", branchid, vouyear);
            }
            else if (voutype == "OSSI")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "D", branchid, vouyear);
            }
            else if (voutype == "OSPI")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "C", branchid, vouyear);
            }
            else if (voutype == "Admin Sales Invoice")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "DA", branchid, vouyear);
            }
            else if (voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "CA", branchid, vouyear);
            }
            if (DtCA.Rows.Count > 0)
            {
                for (int x = 0; x < DtCA.Rows.Count; x++)
                {
                    string postive = "";
                    double CHARGEAMT = 0;
                    string ChrgName = "";
                    //  if (voutype == "Invoices" || (voutype == "Debit Note - Others" && Session["dnreverse"].ToString() != "R") || voutype == "OSSI" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                    if (voutype == "Invoices" || (voutype == "Debit Note - Others") || voutype == "OSSI" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                    {
                        CHARGEAMT = Convert.ToDouble(DtCA.Rows[x]["amount"]);
                    }
                    // else if (voutype == "Debit Note - Others" && Session["dnreverse"].ToString() == "R")
                    else if (voutype == "Debit Note - Others")
                    {
                        CHARGEAMT = -Convert.ToDouble(DtCA.Rows[x]["amount"]);
                        postive = "-";
                    }
                    else if (voutype == "PaymentAdvises" || voutype == "Purchase Invoice" || voutype == "Credit Note - Others" || voutype == "OSPI" || voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin")
                    {
                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                        //if (ChrgName == "ROUND OFF")  //12092020  other CN problem BLR
                        //{
                        //    CHARGEAMT = Convert.ToDouble(DtCA.Rows[x]["amount"]);

                        //}
                        //else
                        //{
                        //    CHARGEAMT = -Convert.ToDouble(DtCA.Rows[x]["amount"]);
                        //    postive = "-";
                        //}

                        // if (voutype == "Purchase Invoice" || (voutype == "Debit Note - Others" && Session["dnreverse"].ToString() == "R"))
                        if (voutype == "Purchase Invoice" || (voutype == "Debit Note - Others"))
                        {
                            if (ChrgName == "ROUND OFF")  //12092020  other CN problem BLR
                            {
                                CHARGEAMT = -(Convert.ToDouble(DtCA.Rows[x]["amount"]));

                            }
                            else
                            {
                                CHARGEAMT = -Convert.ToDouble(DtCA.Rows[x]["amount"]);
                                postive = "-";
                            }
                        }
                        else
                        {
                            if (ChrgName == "ROUND OFF")  //12092020  other CN problem BLR
                            {
                                CHARGEAMT = Convert.ToDouble(DtCA.Rows[x]["amount"]);

                            }
                            else
                            {
                                CHARGEAMT = -Convert.ToDouble(DtCA.Rows[x]["amount"]);
                                postive = "-";
                            }
                        }

                    }

                    double STAmtforST = 0;
                    if (DtCA.Rows[x]["chargename"].ToString().ToUpper() == "SERVICE TAX")
                    {
                        STAmtforST = Convert.ToDouble(CHARGEAMT.ToString("#0.00"));
                    }
                    else
                    {
                        strpart3 = strpart3 + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;

                        if (voutype == "Admin Sales Invoice" || voutype == "Payment Advise - Admin")
                        {
                            strpart3 = strpart3 + "<LEDGERNAME>" + DtCA.Rows[x][0].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</LEDGERNAME>";
                            strpart3 = strpart3 + System.Environment.NewLine;

                            if (voutype == "Payment Advise - Admin")
                            {
                                if (CHARGEAMT < 0)
                                {
                                    strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>";
                                }
                                else
                                {
                                    strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                                }
                                strpart3 += System.Environment.NewLine;
                                strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                            }
                            else
                            {
                                if (CHARGEAMT < 0)
                                {
                                    strpart3 += "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>";
                                }
                                else
                                {
                                    strpart3 += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                                }
                                strpart3 += System.Environment.NewLine;
                                // strpart3 += "<AMOUNT>" + (-(CHARGEAMT)).ToString("0.00") + "</AMOUNT>";
                                strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                            }

                            if (Dt.Rows.Count - 1 != 0)
                            {
                                strpart3 += System.Environment.NewLine;
                            }
                        }
                        else
                        {
                            if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                            {
                                if (voutype == "Invoices" || voutype == "Proforma Invoices" || voutype == "Extentions" || voutype == "FinalBills" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                                {
                                    if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                                    {
                                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +" " + "RECEIVED";
                                        strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                    }
                                    else if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "SERVICE TAX")
                                    {
                                        strpart5 = strpart5 + "<LEDGERNAME>Service Tax Payable</LEDGERNAME>";
                                    }
                                    else
                                    {
                                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;"); ;
                                        if (ChrgName == "ROUND UP" || ChrgName == "ROUND OFF")
                                        {
                                            //ChrgName = ChrgName;
                                            strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                        }
                                        else if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                                        {
                                            if (strtrantype == "NI")
                                            {
                                                if (ChrgName == "SOC Imports ROUND OFF -Income" || ChrgName == "SOC Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "SOC Imports ROUND UP -Income" || ChrgName == "SOC Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //strpart3 += "<LEDGERNAME>SOC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else
                                            {
                                                if (ChrgName == "SOC Exports ROUND OFF -Income" || ChrgName == "SOC Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "SOC Exports ROUND UP -Income" || ChrgName == "SOC Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 += "<LEDGERNAME>SOC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                        }
                                        else
                                        {
                                            if (strtrantype == "FI" || strtrantype == "OI")
                                            {
                                                if (ChrgName == "COC Imports ROUND OFF -Income" || ChrgName == "COC Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "COC Imports ROUND UP -Income" || ChrgName == "COC Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "FE" || strtrantype == "OE")
                                            {
                                                if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            if (strtrantype == "AI")
                                            {
                                                if (ChrgName == "AIR Imports ROUND OFF -Income" || ChrgName == "AIR Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "AIR Imports ROUND UP -Income" || ChrgName == "AIR Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 = strpart3 + "<LEDGERNAME>AIR Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                                            }
                                            else if (strtrantype == "AE")
                                            {
                                                if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //  strpart3 = strpart3 + "<LEDGERNAME>AIR Exports " +ChrgName+ " - Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }

                                            else if (strtrantype == "CH")
                                            {
                                                //if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                //{
                                                //    ChrgName = "ROUND OFF";
                                                //}
                                                //else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                //{
                                                //    ChrgName = "ROUND UP";
                                                //}
                                                //else
                                                //{

                                                ChrgName = ChrgName;
                                                //}
                                                //  strpart3 = strpart3 + "<LEDGERNAME>AIR Exports " +ChrgName+ " - Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }


                                        }
                                    }
                                }
                                else
                                {
                                    if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                                    {
                                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +" " + "PAID";
                                        strpart3 = strpart3 + "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                    }
                                    else if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "SERVICE TAX")
                                    {
                                        strpart5 = strpart5 + "<LEDGERNAME>Service Tax Recovery</LEDGERNAME>";
                                    }
                                    else
                                    {
                                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;"); 
                                        if (ChrgName == "ROUND UP" || ChrgName == "ROUND OFF")
                                        {
                                            //ChrgName = ChrgName;
                                            strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                        }
                                        else if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                                        {
                                            if (strtrantype == "NI")
                                            {
                                                if (ChrgName == "SOC Imports ROUND OFF -Income" || ChrgName == "SOC Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "SOC Imports ROUND UP -Income" || ChrgName == "SOC Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //  strpart3 = strpart3 + "<LEDGERNAME>SOC Imports "+ChrgName+" - Expenses</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                                            }
                                            else
                                            {
                                                if (ChrgName == "SOC Exports ROUND OFF -Income" || ChrgName == "SOC Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "SOC Exports ROUND UP -Income" || ChrgName == "SOC Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 = strpart3 + "<LEDGERNAME>SOC Exports "+ChrgName+" - Expenses</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                                            }
                                        }
                                        else
                                        {
                                            if (strtrantype == "FI" || strtrantype == "OI")
                                            {
                                                if (ChrgName == "COC Imports ROUND OFF -Income" || ChrgName == "COC Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "COC Imports ROUND UP -Income" || ChrgName == "COC Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 = strpart3 + "<LEDGERNAME>COC Imports "+ChrgName+" - Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                                            }
                                            else if (strtrantype == "FE" || strtrantype == "OE")
                                            {
                                                if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            if (strtrantype == "AI")
                                            {
                                                if (ChrgName == "AIR Imports ROUND OFF -Income" || ChrgName == "AIR Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "AIR Imports ROUND UP -Income" || ChrgName == "AIR Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //  strpart3 = strpart3 + "<LEDGERNAME>AIR Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "AE")
                                            {
                                                if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //strpart3 = strpart3 + "<LEDGERNAME>AIR Exports "+ChrgName+" - Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "CH")
                                            {
                                                //if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                //{
                                                //    ChrgName = "ROUND OFF";
                                                //}
                                                //else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                //{
                                                //    ChrgName = "ROUND UP";
                                                //}
                                                //else
                                                //{

                                                ChrgName = ChrgName;
                                                //}
                                                // strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }

                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (voutype == "Invoices" || voutype == "Proforma Invoices" || voutype == "Extentions" || voutype == "FinalBills" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                                {
                                    if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                                    {
                                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +" " + "RECEIVED";
                                        strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                    }
                                    else if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "SERVICE TAX")
                                    {
                                        strpart5 = strpart5 + "<LEDGERNAME>Service Tax Payable</LEDGERNAME>";
                                    }
                                    else
                                    {
                                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                                        if (ChrgName == "ROUND UP" || ChrgName == "ROUND OFF")
                                        {
                                            //ChrgName = ChrgName;
                                            strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                        }
                                        else if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                                        {
                                            if (strtrantype == "NI")
                                            {
                                                // strpart3 += "<LEDGERNAME>SOC Imports "+ChrgName+" - Income</LEDGERNAME>";
                                                if (ChrgName == "SOC Imports ROUND OFF -Income" || ChrgName == "SOC Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "SOC Imports ROUND UP -Income" || ChrgName == "SOC Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else
                                            {
                                                //strpart3 += "<LEDGERNAME>SOC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                if (ChrgName == "SOC Exports ROUND OFF -Income" || ChrgName == "SOC Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "SOC Exports ROUND UP -Income" || ChrgName == "SOC Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                        }
                                        else
                                        {
                                            if (strtrantype == "FI" || strtrantype == "OI")
                                            {
                                                // strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                if (ChrgName == "COC Imports ROUND OFF -Income" || ChrgName == "COC Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "COC Imports ROUND UP -Income" || ChrgName == "COC Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "FE" || strtrantype == "OE")
                                            {
                                                //strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            if (strtrantype == "AI")
                                            {
                                                //strpart3 = strpart3 + "<LEDGERNAME>AIR Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                if (ChrgName == "AIR Imports ROUND OFF -Income" || ChrgName == "AIR Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "AIR Imports ROUND UP -Income" || ChrgName == "AIR Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "AE")
                                            {
                                                //strpart3 = strpart3 + "<LEDGERNAME>AIR Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "CH")
                                            {
                                                //strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                //if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                //{
                                                //    ChrgName = "ROUND OFF";
                                                //}
                                                //else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                //{
                                                //    ChrgName = "ROUND UP";
                                                //}
                                                //else
                                                //{

                                                ChrgName = ChrgName;
                                                //}
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            //if(strtrantype == "FI" )
                                            //{
                                            //    strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                            //}else 
                                            //{
                                            //    strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                            //}
                                        }
                                    }
                                }
                                else
                                {
                                    if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                                    {
                                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +" " + "PAID";
                                        strpart3 = strpart3 + "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                    }
                                    else if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "SERVICE TAX")
                                    {
                                        strpart5 = strpart5 + "<LEDGERNAME>Service Tax Recovery</LEDGERNAME>";
                                    }
                                    else
                                    {
                                        ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                                        if (ChrgName == "ROUND UP" || ChrgName == "ROUND OFF")
                                        {
                                            //ChrgName = ChrgName;
                                            strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                        }
                                        else if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                                        {
                                            if (strtrantype == "NI")
                                            {
                                                //strpart3 = strpart3 + "<LEDGERNAME>SOC Imports"+ChrgName+"- Expenses</LEDGERNAME>";
                                                if (ChrgName == "SOC Imports ROUND OFF -Income" || ChrgName == "SOC Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "SOC Imports ROUND UP -Income" || ChrgName == "SOC Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else
                                            {
                                                if (ChrgName == "SOC Exports ROUND OFF -Income" || ChrgName == "SOC Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "SOC Exports ROUND UP -Income" || ChrgName == "SOC Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //  strpart3 = strpart3 + "<LEDGERNAME>SOC Exports"+ChrgName+"- Expenses</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                        }
                                        else
                                        {
                                            if (strtrantype == "FI"|| strtrantype == "OI")
                                            {
                                                if (ChrgName == "COC Imports ROUND OFF -Income" || ChrgName == "COC Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "COC Imports ROUND UP -Income" || ChrgName == "COC Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "FE"|| strtrantype == "OE")
                                            {
                                                if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                //strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";

                                            }
                                            if (strtrantype == "AI")
                                            {
                                                if (ChrgName == "AIR Imports ROUND OFF -Income" || ChrgName == "AIR Imports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "AIR Imports ROUND UP -Income" || ChrgName == "AIR Imports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 = strpart3 + "<LEDGERNAME>AIR Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "AE")
                                            {
                                                if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 = strpart3 + "<LEDGERNAME>AIR Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            else if (strtrantype == "CH")
                                            {
                                                if (ChrgName == "CH Exports ROUND OFF -Income" || ChrgName == "CH Exports ROUND OFF -Expenses")
                                                {
                                                    ChrgName = "ROUND OFF";
                                                }
                                                else if (ChrgName == "CH Exports ROUND UP -Income" || ChrgName == "CH Exports ROUND UP -Expenses")
                                                {
                                                    ChrgName = "ROUND UP";
                                                }
                                                else
                                                {

                                                    ChrgName = ChrgName;
                                                }
                                                // strpart3 = strpart3 + "<LEDGERNAME>AIR Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                            }
                                            //if(strtrantype == "FI" )
                                            //{
                                            //    strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Expenses</LEDGERNAME>";
                                            //}else 
                                            //{
                                            //    strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Expenses</LEDGERNAME>";
                                            //}
                                        }
                                    }
                                }


                            }

                            strpart3 += System.Environment.NewLine;
                            if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                            {
                                if (CHARGEAMT < 0)
                                {
                                    strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                                }
                                else
                                {
                                    strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>";
                                }

                                if (ChrgName == "ROUND OFF")  //12092020  other CN problem BLR
                                {
                                    //strpart3 = strpart3 + "<AMOUNT>"  + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                    if (voutype == "Purchase Invoice" || (voutype == "Debit Note - Others" ))
                                    {

                                        //double  rof=-
                                        strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(CHARGEAMT).ToString("#0.00") + "</AMOUNT>";
                                    }
                                    else
                                    {
                                        strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                    }
                                }
                                else
                                {


                                    strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                }
                                //if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                                //{
                                //    strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                                //else
                                //{
                                //    //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                //    strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                            }
                            else
                            {
                                if (voutype == "Admin Sales Invoice" || voutype == "Payment Advise - Admin")
                                {
                                    if (totamountWOST < 0)
                                    {
                                        strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                                    }
                                    else
                                    {
                                        strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>";
                                    }
                                    strpart3 += System.Environment.NewLine;
                                    if (voutype == "Payment Advise - Admin")
                                    {
                                        strpart3 = strpart3 + "<AMOUNT>" + totamountWOST + "</AMOUNT>";
                                    }
                                    else
                                    {
                                        strpart3 = strpart3 + "<AMOUNT>" + totamountWOST + "</AMOUNT>";
                                    }

                                }
                                else
                                {
                                    if (CHARGEAMT < 0)
                                    {
                                        strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                                    }
                                    else
                                    {
                                        strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>";
                                    }
                                    strpart3 += System.Environment.NewLine;
                                    //strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";

                                    if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                                    {
                                        //strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                       // if (voutype == "Purchase Invoice" || (voutype == "Debit Note - Others" && Session["dnreverse"].ToString() == "R"))
                                            if (voutype == "Purchase Invoice" || (voutype == "Debit Note - Others"))
                                            {
                                            if (ChrgName == "ROUND OFF")  //12092020  other CN problem BLR
                                            {

                                                //double  rof=-
                                                strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(CHARGEAMT).ToString("#0.00") + "</AMOUNT>";
                                            }
                                            else
                                            {
                                                strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                            }
                                        }
                                        else
                                        {
                                            strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                        }

                                    }
                                    else
                                    {
                                        //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                        strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                    }
                                }
                            }
                        }
                        strpart3 += System.Environment.NewLine;
                        if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                        {
                            strpart3 = strpart3 + "<BILLALLOCATIONS.LIST>";
                            strpart3 += System.Environment.NewLine;
                            strpart3 = strpart3 + "<NAME>" + reference.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</NAME>";
                            strpart3 += System.Environment.NewLine;
                            if (voutype == "Invoices" || voutype == "Proforma Invoices" || voutype == "Extentions" || voutype == "FinalBills" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                            {
                                strpart3 = strpart3 + "<BILLTYPE>New Ref</BILLTYPE>";
                            }
                            else
                            {
                                strpart3 = strpart3 + "<BILLTYPE>Agst Ref</BILLTYPE>";
                            }

                            strpart3 += System.Environment.NewLine;
                            //strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                            if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                            {
                                strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }
                            else
                            {
                                //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }
                            strpart3 += System.Environment.NewLine;
                            strpart3 = strpart3 + "</BILLALLOCATIONS.LIST>";
                            strpart3 += System.Environment.NewLine;

                        }
                        else
                        {
                            if (voutype != "Admin Sales Invoice" && voutype != "Payment Advise - Admin")
                            {
                                if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                                {
                                    strpart3 = strpart3 + "<CATEGORYALLOCATIONS.LIST>";
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "<CATEGORY>" + ledgername.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</CATEGORY>";
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "<COSTCENTREALLOCATIONS.LIST>";
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "<NAME>" + str_Voujobno + "</NAME>";
                                    strpart3 += System.Environment.NewLine;
                                    if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                                    {
                                        //if (custtype == "P")
                                        //{
                                        //    strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                        //}
                                        //else
                                        //{
                                        //    strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                        //}
                                        strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                    }
                                    else
                                    {
                                        strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                    }
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "</COSTCENTREALLOCATIONS.LIST>";
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "</CATEGORYALLOCATIONS.LIST>";
                                    strpart3 += System.Environment.NewLine;
                                }
                                else
                                {
                                    strpart3 = strpart3 + "<CATEGORYALLOCATIONS.LIST>";
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "<CATEGORY>" + ledgername.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</CATEGORY>";
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "<COSTCENTREALLOCATIONS.LIST>";
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "<NAME>" + str_Voujobno + "</NAME>";
                                    strpart3 += System.Environment.NewLine;

                                    //if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                                    //{
                                    //    strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                    //}
                                    //else
                                    //{
                                    //    strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                    //}


                                    if (voutype == "Purchase Invoice")
                                    {
                                        if (ChrgName == "ROUND OFF")  //12092020  other CN problem BLR
                                        {

                                            //double  rof=-
                                            strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(CHARGEAMT).ToString("#0.00") + "</AMOUNT>";
                                        }
                                        else
                                        {
                                            strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                        }
                                    }
                                    else
                                    {
                                        strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                    }

                                    //strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                    //if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                                    //{
                                    //    strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                    //}
                                    //else
                                    //{
                                    //    //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                    //    strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                    //}
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "</COSTCENTREALLOCATIONS.LIST>";
                                    strpart3 += System.Environment.NewLine;
                                    strpart3 = strpart3 + "</CATEGORYALLOCATIONS.LIST>";
                                    strpart3 += System.Environment.NewLine;
                                }


                            }
                        }



                        strpart3 = strpart3 + "</ALLLEDGERENTRIES.LIST>";
                        strpart3 = strpart3.Replace(Convert.ToChar(29).ToString(), "");
                        strpart3 += System.Environment.NewLine;
                    }


                }
            }
            strpart3 = strpart3.Replace("&", "&amp;");
            strpart3 = strpart3.Replace("&amp;amp;", "&amp;");
            return strpart3;


        }

        protected string Part4(int vouno)
        {
            DataTable DtCA = new DataTable();
            strpart4 = "";
            if (voutype == "Invoices")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "I", branchid, vouyear);
            }
            else if (voutype == "BOS")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "B", branchid, vouyear);
            }
            else if (voutype == "PaymentAdvises" || voutype == "Purchase Invoice")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "P", branchid, vouyear);
            }
            else if (voutype == "Debit Note - Others")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "V", branchid, vouyear);
            }
            else if (voutype == "Credit Note - Others")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "E", branchid, vouyear);
            }
            else if (voutype == "OSSI")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "D", branchid, vouyear);
            }
            else if (voutype == "OSPI")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "C", branchid, vouyear);
            }

            else if (voutype == "Admin Sales Invoice")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "DA", branchid, vouyear);
            }
            else if (voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin")
            {
                DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "CA", branchid, vouyear);
            }
            if (DtCA.Rows.Count > 0)
            {
                for (int x = 0; x < DtCA.Rows.Count; x++)
                {
                    //strpart4 = "";
                    string postive = "";
                    strpart4 = strpart4 + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                    if (voutype == "Debit Note - Others")
                    {
                        strpart4 = strpart4 + "<LEDGERNAME>" + DtCA.Rows[x]["ledgername"].ToString().Replace("&", "&amp;").Replace("'", "&#39;") +"</LEDGERNAME>" + System.Environment.NewLine;
                    }
                    else
                    {
                      //  strpart4 = strpart4 + "<LEDGERNAME>" + partyledger.Replace("&", "&amp;") + "</LEDGERNAME>" + System.Environment.NewLine;
                        //LAWRENCE - (ROBINSONS CARGO&amp;LOGISTICS PVT LTD BANGLORE)
                        strpart4 = strpart4 + "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
                    }
                    //if (voutype == "Invoices" || (voutype == "Debit Note - Others" && Session["dnreverse"].ToString() != "R") || voutype == "Admin Sales Invoice" || voutype == "BOS") // Vino [20-12-2023]
                    if (voutype == "Invoices" || (voutype == "Debit Note - Others") || voutype == "Admin Sales Invoice" || voutype == "BOS") // Vino [20-12-2023]
                    {
                        strpart4 = strpart4 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                        postive = "-";
                    }

                    else
                    {
                        strpart4 = strpart4 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                    }


                    strpart4 += System.Environment.NewLine;
                    if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                    {
                        if (custtype == "P")
                        {
                            if (voutype == "Debit Note - Others")
                            {
                                //if (Session["dnreverse"].ToString() != "R")
                                //{
                                //    strpart4 = strpart4 + "<AMOUNT>" + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = -" + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                                //else
                                //{
                                //strpart4 = strpart4 + "<AMOUNT>-" + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = -" + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                                strpart4 = strpart4 + "<AMOUNT>-" + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = -" + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }
                            else
                            {
                                strpart4 = strpart4 + "<AMOUNT>" + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }

                            //strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
                        }
                        else
                        {
                            if (voutype == "Debit Note - Others")
                            {
                                //if (Session["dnreverse"].ToString() != "R")
                                //{
                                //    strpart4 = strpart4 + "<AMOUNT>-" + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                                //else
                                //{
                                //    strpart4 = strpart4 + "<AMOUNT>" + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                               strpart4 = strpart4 + "<AMOUNT>-" + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }

                            else
                            {
                                strpart4 = strpart4 + "<AMOUNT>" + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }

                        }
                    }
                    else
                    {
                        if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                        {
                            strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                        }
                        else
                        {
                            //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                            ////  strpart4 = strpart4 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";


                            strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                        }

                        //strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
                    }
                    strpart4 += System.Environment.NewLine;
                    strpart4 = strpart4 + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    //string cnt = "";
                    //if (x == 1)
                    //{
                    //    cnt = "A";
                    //}

                    //strpart4 = strpart4 + "<NAME>" + reference + cnt + "</NAME>" + System.Environment.NewLine;
                    if (voutype == "PaymentAdvises" || voutype == "Purchase Invoice" || voutype == "Credit Note - Others" || voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin" || voutype == "OSSI" || voutype == "OSPI")
                    {
                        strpart4 = strpart4 + "<NAME>" + vendorrefno + "</NAME>" + System.Environment.NewLine;
                    }
                    else
                    {
                        strpart4 = strpart4 + "<NAME>" + vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</NAME>" + System.Environment.NewLine;
                    }
                    if (ddl_voucher.Text == "Invoices" || voutype == "Admin Sales Invoice")
                    {
                        strpart4 = strpart4 + "<BILLTYPE>New Ref</BILLTYPE>";
                    }
                    else
                    {
                        strpart4 = strpart4 + "<BILLTYPE>Agst Ref</BILLTYPE>";
                    }
                    strpart4 += System.Environment.NewLine;

                    if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                    {
                        if (custtype == "P")
                        {
                            if (voutype == "Debit Note - Others")
                            {
                                //if (Session["dnreverse"].ToString() != "R")
                                //{
                                //    strpart4 = strpart4 + "<AMOUNT>-" + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = -" + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                                //else
                                //{
                                //    strpart4 = strpart4 + "<AMOUNT>" + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = -" + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                                strpart4 = strpart4 + "<AMOUNT>-" + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = -" + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";

                            }
                            else
                            {
                                strpart4 = strpart4 + "<AMOUNT>" + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }

                            // strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
                        }
                        else
                        {
                            if (voutype == "Debit Note - Others")
                            {
                                //if (Session["dnreverse"].ToString() != "R")
                                //{
                                //    strpart4 = strpart4 + "<AMOUNT>-" + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}
                                //else
                                //{
                                //    strpart4 = strpart4 + "<AMOUNT>" + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                //}

                                strpart4 = strpart4 + "<AMOUNT>-" + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }

                            else
                            {
                                strpart4 = strpart4 + "<AMOUNT>" + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            }
                            //strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
                        }
                    }
                    else
                    {
                        if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                        {
                            strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                        }
                        else
                        {
                            //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                            ////  strpart4 = strpart4 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                            strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                        }
                        //strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
                    }
                    strpart4 += System.Environment.NewLine;
                    strpart4 = strpart4 + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    strpart4 = strpart4 + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                }
            }
            return strpart4;
        }
        /*   protected string Part3(int vouno)
           {

               DataTable DtCA = new DataTable();
               strpart3 = "";
               if (voutype == "Invoices")
               {
                   //DtCA = Invobj.GetInvPAChargeamount(vouno, "I", branchid, vouyear);
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "I", branchid, vouyear);
               }
               else if (voutype == "BOS")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "B", branchid, vouyear);
               }
               else if (voutype == "PaymentAdvises" || voutype == "Credit Note - Operations")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "P", branchid, vouyear);
               }
               else if (voutype == "Debit Note - Others")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "V", branchid, vouyear);
               }
               else if (voutype == "Credit Note - Others")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "E", branchid, vouyear);
               }
               else if (voutype == "OSSI")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "D", branchid, vouyear);
               }
               else if (voutype == "OSPI")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "C", branchid, vouyear);
               }
               else if (voutype == "Admin Sales Invoice")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "DA", branchid, vouyear);
               }
               else if (voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Charge(vouno, "CA", branchid, vouyear);
               }
               if (DtCA.Rows.Count > 0)
               {
                   for (int x = 0; x < DtCA.Rows.Count; x++)
                   {
                       string postive = "";
                       double CHARGEAMT = 0;
                       string ChrgName = "";
                       if (voutype == "Invoices" || voutype == "Debit Note - Others" || voutype == "OSSI" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                       {
                           CHARGEAMT = Convert.ToDouble(DtCA.Rows[x]["amount"]);
                       }
                       else if (voutype == "PaymentAdvises" || voutype == "Credit Note - Operations" || voutype == "Credit Note - Others" || voutype == "OSPI" || voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin")
                       {
                           CHARGEAMT = -Convert.ToDouble(DtCA.Rows[x]["amount"]);
                           postive = "-";
                       }

                       double STAmtforST = 0;
                       if (DtCA.Rows[x]["chargename"].ToString().ToUpper() == "SERVICE TAX")
                       {
                           STAmtforST = Convert.ToDouble(CHARGEAMT.ToString("#0.00"));
                       }
                       else
                       {
                           strpart3 = strpart3 + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;

                           if (voutype == "Admin Sales Invoice" || voutype == "Payment Advise - Admin")
                           {
                               strpart3 = strpart3 + "<LEDGERNAME>" + DtCA.Rows[x][0].ToString().Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;") + "</LEDGERNAME>";
                               strpart3 = strpart3 + System.Environment.NewLine;

                               if (voutype == "Payment Advise - Admin")
                               {
                                   if (CHARGEAMT < 0)
                                   {
                                       strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>";
                                   }
                                   else
                                   {
                                       strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                                   }
                                   strpart3 += System.Environment.NewLine;
                                   strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                               }
                               else
                               {
                                   if (CHARGEAMT < 0)
                                   {
                                       strpart3 += "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>";
                                   }
                                   else
                                   {
                                       strpart3 += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                                   }
                                   strpart3 += System.Environment.NewLine;
                                   // strpart3 += "<AMOUNT>" + (-(CHARGEAMT)).ToString("0.00") + "</AMOUNT>";
                                   strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                               }

                               if (Dt.Rows.Count - 1 != 0)
                               {
                                   strpart3 += System.Environment.NewLine;
                               }
                           }
                           else
                           {
                               if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                               {
                                   if (voutype == "Invoices" || voutype == "Proforma Invoices" || voutype == "Extentions" || voutype == "FinalBills" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                                   {
                                       if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                                       {
                                           ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;") + " " + "RECEIVED";
                                           strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                       }
                                       else if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "SERVICE TAX")
                                       {
                                           strpart5 = strpart5 + "<LEDGERNAME>Service Tax Payable</LEDGERNAME>";
                                       }
                                       else
                                       {
                                           ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;");
                                           if (ChrgName == "ROUND UP" || ChrgName == "ROUND OFF")
                                           {
                                               //ChrgName = ChrgName;
                                               strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                           }
                                           else if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                                           {
                                               if (strtrantype == "NI")
                                               {
                                                   if (ChrgName == "SOC Imports ROUND OFF -Income" || ChrgName == "SOC Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "SOC Imports ROUND UP -Income" || ChrgName == "SOC Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //strpart3 += "<LEDGERNAME>SOC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else
                                               {
                                                   if (ChrgName == "SOC Exports ROUND OFF -Income" || ChrgName == "SOC Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "SOC Exports ROUND UP -Income" || ChrgName == "SOC Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 += "<LEDGERNAME>SOC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                           }
                                           else
                                           {
                                               if (strtrantype == "FI"|| strtrantype == "OI")
                                               {
                                                   if (ChrgName == "COC Imports ROUND OFF -Income" || ChrgName == "COC Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "COC Imports ROUND UP -Income" || ChrgName == "COC Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "FE"|| strtrantype == "OE")
                                               {
                                                   if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               if (strtrantype == "AI")
                                               {
                                                   if (ChrgName == "AIR Imports ROUND OFF -Income" || ChrgName == "AIR Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "AIR Imports ROUND UP -Income" || ChrgName == "AIR Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 = strpart3 + "<LEDGERNAME>AIR Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                                               }
                                               else if (strtrantype == "AE")
                                               {
                                                   if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //  strpart3 = strpart3 + "<LEDGERNAME>AIR Exports " +ChrgName+ " - Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }

                                               else if (strtrantype == "CH")
                                               {
                                                   //if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                   //{
                                                   //    ChrgName = "ROUND OFF";
                                                   //}
                                                   //else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                   //{
                                                   //    ChrgName = "ROUND UP";
                                                   //}
                                                   //else
                                                   //{

                                                   ChrgName = ChrgName;
                                                   //}
                                                   //  strpart3 = strpart3 + "<LEDGERNAME>AIR Exports " +ChrgName+ " - Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }


                                           }
                                       }
                                   }
                                   else
                                   {
                                       if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                                       {
                                           ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;") + " " + "PAID";
                                           strpart3 = strpart3 + "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                       }
                                       else if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "SERVICE TAX")
                                       {
                                           strpart5 = strpart5 + "<LEDGERNAME>Service Tax Recovery</LEDGERNAME>";
                                       }
                                       else
                                       {
                                           ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;");
                                           if (ChrgName == "ROUND UP" || ChrgName == "ROUND OFF")
                                           {
                                               //ChrgName = ChrgName;
                                               strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                           }
                                           else if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                                           {
                                               if (strtrantype == "NI")
                                               {
                                                   if (ChrgName == "SOC Imports ROUND OFF -Income" || ChrgName == "SOC Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "SOC Imports ROUND UP -Income" || ChrgName == "SOC Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //  strpart3 = strpart3 + "<LEDGERNAME>SOC Imports "+ChrgName+" - Expenses</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                                               }
                                               else
                                               {
                                                   if (ChrgName == "SOC Exports ROUND OFF -Income" || ChrgName == "SOC Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "SOC Exports ROUND UP -Income" || ChrgName == "SOC Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 = strpart3 + "<LEDGERNAME>SOC Exports "+ChrgName+" - Expenses</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                                               }
                                           }
                                           else
                                           {
                                               if (strtrantype == "FI"|| strtrantype == "OI")
                                               {
                                                   if (ChrgName == "COC Imports ROUND OFF -Income" || ChrgName == "COC Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "COC Imports ROUND UP -Income" || ChrgName == "COC Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 = strpart3 + "<LEDGERNAME>COC Imports "+ChrgName+" - Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME> " + ChrgName + " </LEDGERNAME>";
                                               }
                                               else if (strtrantype == "FE"|| strtrantype == "OE")
                                               {
                                                   if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               if (strtrantype == "AI")
                                               {
                                                   if (ChrgName == "AIR Imports ROUND OFF -Income" || ChrgName == "AIR Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "AIR Imports ROUND UP -Income" || ChrgName == "AIR Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //  strpart3 = strpart3 + "<LEDGERNAME>AIR Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "AE")
                                               {
                                                   if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //strpart3 = strpart3 + "<LEDGERNAME>AIR Exports "+ChrgName+" - Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "CH")
                                               {
                                                   //if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                   //{
                                                   //    ChrgName = "ROUND OFF";
                                                   //}
                                                   //else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                   //{
                                                   //    ChrgName = "ROUND UP";
                                                   //}
                                                   //else
                                                   //{

                                                   ChrgName = ChrgName;
                                                   //}
                                                   // strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }

                                           }
                                       }
                                   }
                               }
                               else
                               {
                                   if (voutype == "Invoices" || voutype == "Proforma Invoices" || voutype == "Extentions" || voutype == "FinalBills" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                                   {
                                       if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                                       {
                                           ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;") + " " + "RECEIVED";
                                           strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                       }
                                       else if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "SERVICE TAX")
                                       {
                                           strpart5 = strpart5 + "<LEDGERNAME>Service Tax Payable</LEDGERNAME>";
                                       }
                                       else
                                       {
                                           ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;");
                                           if (ChrgName == "ROUND UP" || ChrgName == "ROUND OFF")
                                           {
                                               //ChrgName = ChrgName;
                                               strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                           }
                                           else if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                                           {
                                               if (strtrantype == "NI")
                                               {
                                                   // strpart3 += "<LEDGERNAME>SOC Imports "+ChrgName+" - Income</LEDGERNAME>";
                                                   if (ChrgName == "SOC Imports ROUND OFF -Income" || ChrgName == "SOC Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "SOC Imports ROUND UP -Income" || ChrgName == "SOC Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else
                                               {
                                                   //strpart3 += "<LEDGERNAME>SOC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   if (ChrgName == "SOC Exports ROUND OFF -Income" || ChrgName == "SOC Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "SOC Exports ROUND UP -Income" || ChrgName == "SOC Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                           }
                                           else
                                           {
                                               if (strtrantype == "FI"|| strtrantype == "OI")
                                               {
                                                   // strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                   if (ChrgName == "COC Imports ROUND OFF -Income" || ChrgName == "COC Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "COC Imports ROUND UP -Income" || ChrgName == "COC Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "FE"|| strtrantype == "OE")
                                               {
                                                   //strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               if (strtrantype == "AI")
                                               {
                                                   //strpart3 = strpart3 + "<LEDGERNAME>AIR Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                   if (ChrgName == "AIR Imports ROUND OFF -Income" || ChrgName == "AIR Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "AIR Imports ROUND UP -Income" || ChrgName == "AIR Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "AE")
                                               {
                                                   //strpart3 = strpart3 + "<LEDGERNAME>AIR Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "CH")
                                               {
                                                   //strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   //if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                   //{
                                                   //    ChrgName = "ROUND OFF";
                                                   //}
                                                   //else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                   //{
                                                   //    ChrgName = "ROUND UP";
                                                   //}
                                                   //else
                                                   //{

                                                   ChrgName = ChrgName;
                                                   //}
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               //if(strtrantype == "FI" )
                                               //{
                                               //    strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                               //}else 
                                               //{
                                               //    strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                               //}
                                           }
                                       }
                                   }
                                   else
                                   {
                                       if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                                       {
                                           ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;") + " " + "PAID";
                                           strpart3 = strpart3 + "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                       }
                                       else if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "SERVICE TAX")
                                       {
                                           strpart5 = strpart5 + "<LEDGERNAME>Service Tax Recovery</LEDGERNAME>";
                                       }
                                       else
                                       {
                                           ChrgName = (DtCA.Rows[x]["chargename"].ToString().Trim()).Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;");
                                           if (ChrgName == "ROUND UP" || ChrgName == "ROUND OFF")
                                           {
                                               //ChrgName = ChrgName;
                                               strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                           }
                                           else if (strtrantype == "NI" || strtrantype == "NE" || strtrantype == "NS" || strtrantype == "NT")
                                           {
                                               if (strtrantype == "NI")
                                               {
                                                   //strpart3 = strpart3 + "<LEDGERNAME>SOC Imports"+ChrgName+"- Expenses</LEDGERNAME>";
                                                   if (ChrgName == "SOC Imports ROUND OFF -Income" || ChrgName == "SOC Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "SOC Imports ROUND UP -Income" || ChrgName == "SOC Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else
                                               {
                                                   if (ChrgName == "SOC Exports ROUND OFF -Income" || ChrgName == "SOC Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "SOC Exports ROUND UP -Income" || ChrgName == "SOC Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //  strpart3 = strpart3 + "<LEDGERNAME>SOC Exports"+ChrgName+"- Expenses</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                           }
                                           else
                                           {
                                               if (strtrantype == "FI"|| strtrantype == "OI")
                                               {
                                                   if (ChrgName == "COC Imports ROUND OFF -Income" || ChrgName == "COC Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "COC Imports ROUND UP -Income" || ChrgName == "COC Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "FE"|| strtrantype == "OE")
                                               {
                                                   if (ChrgName == "COC Exports ROUND OFF -Income" || ChrgName == "COC Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "COC Exports ROUND UP -Income" || ChrgName == "COC Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   //strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";

                                               }
                                               if (strtrantype == "AI")
                                               {
                                                   if (ChrgName == "AIR Imports ROUND OFF -Income" || ChrgName == "AIR Imports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "AIR Imports ROUND UP -Income" || ChrgName == "AIR Imports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 = strpart3 + "<LEDGERNAME>AIR Imports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "AE")
                                               {
                                                   if (ChrgName == "AIR Exports ROUND OFF -Income" || ChrgName == "AIR Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "AIR Exports ROUND UP -Income" || ChrgName == "AIR Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 = strpart3 + "<LEDGERNAME>AIR Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               else if (strtrantype == "CH")
                                               {
                                                   if (ChrgName == "CH Exports ROUND OFF -Income" || ChrgName == "CH Exports ROUND OFF -Expenses")
                                                   {
                                                       ChrgName = "ROUND OFF";
                                                   }
                                                   else if (ChrgName == "CH Exports ROUND UP -Income" || ChrgName == "CH Exports ROUND UP -Expenses")
                                                   {
                                                       ChrgName = "ROUND UP";
                                                   }
                                                   else
                                                   {

                                                       ChrgName = ChrgName;
                                                   }
                                                   // strpart3 = strpart3 + "<LEDGERNAME>AIR Exports"+ChrgName+"- Income</LEDGERNAME>";
                                                   strpart3 += "<LEDGERNAME>" + ChrgName + "</LEDGERNAME>";
                                               }
                                               //if(strtrantype == "FI" )
                                               //{
                                               //    strpart3 = strpart3 + "<LEDGERNAME>COC Imports"+ChrgName+"- Expenses</LEDGERNAME>";
                                               //}else 
                                               //{
                                               //    strpart3 = strpart3 + "<LEDGERNAME>COC Exports"+ChrgName+"- Expenses</LEDGERNAME>";
                                               //}
                                           }
                                       }
                                   }


                               }

                               strpart3 += System.Environment.NewLine;
                               if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                               {
                                   if (CHARGEAMT < 0)
                                   {
                                       strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                                   }
                                   else
                                   {
                                       strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>";
                                   }
                               }
                               else
                               {
                                   if (voutype == "Admin Sales Invoice" || voutype == "Payment Advise - Admin")
                                   {
                                       if (totamountWOST < 0)
                                       {
                                           strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                                       }
                                       else
                                       {
                                           strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>";
                                       }
                                       strpart3 += System.Environment.NewLine;
                                       if (voutype == "Payment Advise - Admin")
                                       {
                                           strpart3 = strpart3 + "<AMOUNT>" + totamountWOST + "</AMOUNT>";
                                       }
                                       else
                                       {
                                           strpart3 = strpart3 + "<AMOUNT>" + totamountWOST + "</AMOUNT>";
                                       }

                                   }
                                   else
                                   {
                                       if (CHARGEAMT < 0)
                                       {
                                           strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                                       }
                                       else
                                       {
                                           strpart3 = strpart3 + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>";
                                       }
                                       strpart3 += System.Environment.NewLine;
                                       //strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";

                                       if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                                       {
                                           strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                       }
                                       else
                                       {
                                           //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                           strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                       }
                                   }
                               }
                           }
                           strpart3 += System.Environment.NewLine;
                           if (DtCA.Rows[x]["chargename"].ToString().Trim().ToUpper() == "DEPOSITS")
                           {
                               strpart3 = strpart3 + "<BILLALLOCATIONS.LIST>";
                               strpart3 += System.Environment.NewLine;
                               strpart3 = strpart3 + "<NAME>" + reference.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;") + "</NAME>";
                               strpart3 += System.Environment.NewLine;
                               if (voutype == "Invoices" || voutype == "Proforma Invoices" || voutype == "Extentions" || voutype == "FinalBills" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                               {
                                   strpart3 = strpart3 + "<BILLTYPE>New Ref</BILLTYPE>";
                               }
                               else
                               {
                                   strpart3 = strpart3 + "<BILLTYPE>Agst Ref</BILLTYPE>";
                               }

                               strpart3 += System.Environment.NewLine;
                               //strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                               if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                               {
                                   strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                               }
                               else
                               {
                                   //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                   strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                               }
                               strpart3 += System.Environment.NewLine;
                               strpart3 = strpart3 + "</BILLALLOCATIONS.LIST>";
                               strpart3 += System.Environment.NewLine;

                           }
                           else
                           {
                               if (voutype != "Admin Sales Invoice" && voutype != "Payment Advise - Admin")
                               {
                                   if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                                   {
                                       strpart3 = strpart3 + "<CATEGORYALLOCATIONS.LIST>";
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "<CATEGORY>" + ledgername.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;") + "</CATEGORY>";
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "<COSTCENTREALLOCATIONS.LIST>";
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "<NAME>" + str_Voujobno + "</NAME>";
                                       strpart3 += System.Environment.NewLine;
                                       if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                                       {
                                           if (custtype == "P")
                                           {
                                               strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                           }
                                           //strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                       }
                                       else
                                       {
                                           strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                       }
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "</COSTCENTREALLOCATIONS.LIST>";
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "</CATEGORYALLOCATIONS.LIST>";
                                       strpart3 += System.Environment.NewLine;
                                   }
                                   else
                                   {
                                       strpart3 = strpart3 + "<CATEGORYALLOCATIONS.LIST>";
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "<CATEGORY>" + ledgername.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;") + "</CATEGORY>";
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "<COSTCENTREALLOCATIONS.LIST>";
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "<NAME>" + str_Voujobno + "</NAME>";
                                       strpart3 += System.Environment.NewLine;

                                       //if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                                       //{
                                       //    strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                       //}
                                       //else
                                       //{
                                       //    strpart3 = strpart3 + "<AMOUNT>" + CHARGEAMT.ToString("0.00") + "</AMOUNT>";
                                       //}

                                       strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                       //if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                                       //{
                                       //    strpart3 = strpart3 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                       //}
                                       //else
                                       //{
                                       //    //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                       //    strpart3 = strpart3 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                                       //}
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "</COSTCENTREALLOCATIONS.LIST>";
                                       strpart3 += System.Environment.NewLine;
                                       strpart3 = strpart3 + "</CATEGORYALLOCATIONS.LIST>";
                                       strpart3 += System.Environment.NewLine;
                                   }


                               }
                           }



                           strpart3 = strpart3 + "</ALLLEDGERENTRIES.LIST>";
                           strpart3 = strpart3.Replace(Convert.ToChar(29).ToString(), "");
                           strpart3 += System.Environment.NewLine;
                       }


                   }
               }
               strpart3 = strpart3.Replace("&", "&amp;");
               strpart3 = strpart3.Replace("&amp;amp;", "&amp;");
               return strpart3;


           }

           protected string Part4(int vouno)
           {
               DataTable DtCA = new DataTable();
               strpart4 = "";
               if (voutype == "Invoices")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "I", branchid, vouyear);
               }
               else if (voutype == "BOS")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "B", branchid, vouyear);
               }
               else if (voutype == "PaymentAdvises" || voutype == "Credit Note - Operations")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "P", branchid, vouyear);
               }
               else if (voutype == "Debit Note - Others")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "V", branchid, vouyear);
               }
               else if (voutype == "Credit Note - Others")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "E", branchid, vouyear);
               }
               else if (voutype == "OSSI")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "D", branchid, vouyear);
               }
               else if (voutype == "OSPI")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "C", branchid, vouyear);
               }

               else if (voutype == "Admin Sales Invoice")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "DA", branchid, vouyear);
               }
               else if (voutype == "Admin Purchase Invoice" || voutype == "Payment Advise - Admin")
               {
                   DtCA = Invobj.GetInvPAChargeamountWithCur4Cust(vouno, "CA", branchid, vouyear);
               }
               if (DtCA.Rows.Count > 0)
               {
                   for (int x = 0; x < DtCA.Rows.Count; x++)
                   {
                       //strpart4 = "";
                       string postive = "";
                       strpart4 = strpart4 + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                       strpart4 = strpart4 + "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
                       if (voutype == "Invoices" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice" || voutype == "BOS")
                       {
                           strpart4 = strpart4 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                           postive = "-";
                       }
                       else
                       {
                           strpart4 = strpart4 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                       }
                       strpart4 += System.Environment.NewLine;
                       if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                       {
                           if (custtype == "P")
                           {
                               strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
                           }
                           else
                           {
                               strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
                           }
                       }
                       else
                       {
                           if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                           {
                               strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                           }
                           else
                           {
                               //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                               ////  strpart4 = strpart4 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";


                               strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                           }

                           //strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
                       }
                       strpart4 += System.Environment.NewLine;
                       strpart4 = strpart4 + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                       //string cnt = "";
                       //if (x == 1)
                       //{
                       //    cnt = "A";
                       //}

                       //strpart4 = strpart4 + "<NAME>" + reference + cnt + "</NAME>" + System.Environment.NewLine;
                       strpart4 = strpart4 + "<NAME>" + vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;") + "</NAME>" + System.Environment.NewLine;
                       if (ddl_voucher.Text == "Invoices" || voutype == "Admin Sales Invoice")
                       {
                           strpart4 = strpart4 + "<BILLTYPE>New Ref</BILLTYPE>";
                       }
                       else
                       {
                           strpart4 = strpart4 + "<BILLTYPE>Agst Ref</BILLTYPE>";
                       }
                       strpart4 += System.Environment.NewLine;

                       if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
                       {
                           if (custtype == "P")
                           {
                               strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
                           }
                           else
                           {
                               strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
                           }
                       }
                       else
                       {
                           if (DtCA.Rows[x]["curr"].ToString() == Session["Basecurr"].ToString())
                           {
                               strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                           }
                           else
                           {
                               //"" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                               ////  strpart4 = strpart4 + "<AMOUNT>" + postive + DtCA.Rows[x]["curr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["fcamt"]).ToString("#0.00") + " @ " + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["exrate"]).ToString("#0.00") + "/" + DtCA.Rows[x]["curr"].ToString() + " = " + postive + Session["Basecurr"].ToString() + " " + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                               strpart4 = strpart4 + "<AMOUNT>" + postive + Convert.ToDouble(DtCA.Rows[x]["amount"]).ToString("#0.00") + "</AMOUNT>";
                           }
                           //strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
                       }
                       strpart4 += System.Environment.NewLine;
                       strpart4 = strpart4 + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                       strpart4 = strpart4 + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                   }
               }
               return strpart4;
           }*/

        //protected string Part4()
        //{
        //    strpart4 = "";
        //    strpart4 = strpart4 + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
        //    strpart4 = strpart4 + "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
        //    if (voutype == "Invoices" || voutype == "Debit Note - Others" || voutype == "Admin Sales Invoice")
        //    {
        //        strpart4 = strpart4 + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
        //    }
        //    else
        //    {
        //        strpart4 = strpart4 + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
        //    }
        //    strpart4 += System.Environment.NewLine;
        //    if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
        //    {
        //        if (custtype == "P")
        //        {
        //            strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
        //        }
        //        else
        //        {
        //            strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
        //        }
        //    }
        //    else
        //    {
        //        strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
        //    }
        //    strpart4 += System.Environment.NewLine;
        //    strpart4 = strpart4 + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
        //    strpart4 = strpart4 + "<NAME>" + reference + "</NAME>" + System.Environment.NewLine;
        //    if (ddl_voucher.Text == "Invoices" || voutype == "Admin Sales Invoice")
        //    {
        //        strpart4 = strpart4 + "<BILLTYPE>New Ref</BILLTYPE>";
        //    }
        //    else
        //    {
        //        strpart4 = strpart4 + "<BILLTYPE>Agst Ref</BILLTYPE>";
        //    }
        //    strpart4 += System.Environment.NewLine;

        //    if (voutype == "Debit Note - Others" || voutype == "Credit Note - Others")
        //    {
        //        if (custtype == "P")
        //        {
        //            strpart4 = strpart4 + "<AMOUNT>" + dctotal + "</AMOUNT>";
        //        }
        //        else
        //        {
        //            strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
        //        }
        //    }
        //    else
        //    {
        //        strpart4 = strpart4 + "<AMOUNT>" + (totalamount - Math.Round(PATdsAmt, 2)) + "</AMOUNT>";
        //    }
        //    strpart4 += System.Environment.NewLine;
        //    strpart4 = strpart4 + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
        //    strpart4 = strpart4 + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;

        //    return strpart4;
        //}

        protected string Part2()
        {
            strpart2 = "";
            strpart2 = strpart2 + "<PARTYLEDGERNAME>" + partyledger + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<EFFECTIVEDATE>" + voudate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<HASCASHFLOW>No</HASCASHFLOW>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
            strpart2 = strpart2 + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
            return strpart2;
        }

        protected string Part1()
        {
            string voutype11 = "";
            string strpart1 = "";
            if (ddl_voucher.Text == "Purchase Invoice")
            {
                voutype11 = "Credit Note Operations";
                strpart1 += "<VOUCHER REMOTEID='' VCHTYPE='" + voutype11 + "' ACTION='CREATE'>" + System.Environment.NewLine;
            }
            else
            {
                strpart1 += "<VOUCHER REMOTEID='' VCHTYPE='" + voutype + "' ACTION='CREATE'>" + System.Environment.NewLine;
            }
            // strpart1 += "<VOUCHER REMOTEID='' VCHTYPE='" + voutype + "' ACTION='CREATE'>" + System.Environment.NewLine;
            strpart1 = strpart1 + "<DATE>" + voudate + "</DATE>" + System.Environment.NewLine;
            strpart1 = strpart1 + "<NARRATION>" + narration + "</NARRATION>" + System.Environment.NewLine;
            if (ddl_voucher.Text == "Purchase Invoice")
            {
                voutype11 = "Credit Note Operations";
                strpart1 = strpart1 + "<VOUCHERTYPENAME>" + voutype11 + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            }
            else
            {
                strpart1 = strpart1 + "<VOUCHERTYPENAME>" + voutype + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            }

            strpart1 = strpart1 + "<VOUCHERNUMBER>" + vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;") +"</VOUCHERNUMBER>" + System.Environment.NewLine;
            strpart1 = strpart1 + "<REFERENCE>" + reference + "</REFERENCE>" + System.Environment.NewLine;
            return strpart1;
        }

        protected void GetVoucherType(int vouno)
        {
            DateTime vdate;
            PATdsAmt = 0;
            totamountWOST = 0;
            totamountST = 0;
            totalamount = 0;
            reference = "";
            voutype = ddl_voucher.Text;
            string curr = "";
            //Deleted = "N";
            portid = HREmpobj.GetBranchId(Session["LoginBranchName"].ToString());
            Dt = MBObj.RetrieveMasterBranchDetails(divisionid, portid, branchid);
            if (Dt.Rows.Count > 0)
            {
                StrbrnchbnkAccno = Dt.Rows[0]["acnos"].ToString();
                strbrnchbnkname = "CO-Control AC";
            }

            string branchshort = "", branchshort1 = "";

            branchshort = BrObj.GetShortName(Convert.ToInt32(Session["LoginBranchid"])).ToUpper();
            branchshort1 = branchshort.Substring(4, 3);



            switch (ddl_voucher.Text)
            {
                case "Journal":
                    Str_XML += GetJournal(vouno, Convert.ToInt32(txt_JVmonth.Text));
                    break;
                case "Invoices":
                    filename = "Inv";
                    ledgerexpinc = "Income";
                    Dt = Invobj.ShowTallyDt(vouno, "Invoice", vouyear, branchid);
                    totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "Invoice", branchid, vouyear), 2);
                    totalamount = Math.Round((Invobj.GetIPDNAmount(vouno, "Invoice", branchid, vouyear)) * -1, 2);
                    totamountST = Math.Round(-(totalamount + totamountWOST), 2);
                    if (Dt.Rows.Count > 0)
                    {
                        blr = true;
                        strtrantype = Dt.Rows[0]["trantype"].ToString();
                        if (strtrantype == "FE"|| strtrantype == "OE")
                        {
                            ledgername = "Ocean Forwarding Exports";
                            //str_VouTypeINCEXP = "-SEA";
                        }
                        else if (strtrantype == "FI"|| strtrantype == "OI")
                        {
                            ledgername = "Ocean Forwarding Imports";
                            // str_VouTypeINCEXP = "-SEA";
                        }
                        else if (strtrantype == "AE")
                        {
                            ledgername = "Air Exports";
                            //  str_VouTypeINCEXP = "-AIR";
                        }
                        else if (strtrantype == "AI")
                        {
                            ledgername = "Air Imports";
                            //  str_VouTypeINCEXP = "-AIR";
                        }
                        else if (strtrantype == "CH")
                        {
                            ledgername = "CHA";
                        }
                        else if (strtrantype == "BT")
                        {
                            ledgername = "Bonded Trucking";
                        }

                        else if (strtrantype == "NI")
                        {
                            ledgername = "Agency Imports";
                            //  str_VouTypeINCEXP = "-SEA";
                        }
                        else if (strtrantype == "NE")
                        {
                            ledgername = "Agency Exports";
                            // str_VouTypeINCEXP = "-AIR";
                        }


                        vdate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                        Dt_voudate = vdate;
                        voudate = string.Format("{0:yyyyMMdd}", vdate);
                        string pcode;
                        pcode = OSDCNObj.GetPortCode(branchid);


                        //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                        ledgernameexin = ledgername;//+ " - " + ledgerexpinc;
                        jobprefix = Dt.Rows[0]["jobno"].ToString();



                        jobno = Dt.Rows[0]["jobno"].ToString();


                        blno = Dt.Rows[0]["blno"].ToString();

                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }

                        if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                        {
                            vounoyear = hid_portcode.Value + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            //string branchshort = BrObj.GetShortName(Convert.ToInt32(Session["LoginBranchid"])).ToUpper();
                            //string branchshort1 = branchshort.Substring(4, 3);
                            vounoyear = branchshort1 + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;
                                
                        }
                        else
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                vounoyear = hid_portcode.Value + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                
                                vounoyear = branchshort1 + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;
                                 
                            }
                            else
                            {
                                //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                vounoyear = hid_portcode.Value + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                
                                vounoyear = branchshort1 + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;
                                
                            }
                        }

                        GetNarration(vouno, blno, "I", vouyear);
                        GetReference(vouno, "Invoice", vouyear);


                    }
                    break;

                case "BOS":
                    filename = "Bos";
                    ledgerexpinc = "Income";
                    Dt = Invobj.ShowTallyDt(vouno, "BOS", vouyear, branchid);
                    totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "BOS", branchid, vouyear), 2);
                    totalamount = Math.Round((Invobj.GetIPDNAmount(vouno, "BOS", branchid, vouyear)) * -1, 2);
                    totamountST = Math.Round(-(totalamount + totamountWOST), 2);
                    if (Dt.Rows.Count > 0)
                    {
                        blr = true;
                        strtrantype = Dt.Rows[0]["trantype"].ToString();
                        if (strtrantype == "FE"|| strtrantype == "OE")
                        {
                            ledgername = "Ocean Forwarding Exports";
                            //str_VouTypeINCEXP = "-SEA";
                        }
                        else if (strtrantype == "FI"|| strtrantype == "OI")
                        {
                            ledgername = "Ocean Forwarding Imports";
                            // str_VouTypeINCEXP = "-SEA";
                        }
                        else if (strtrantype == "AE")
                        {
                            ledgername = "Air Exports";
                            //  str_VouTypeINCEXP = "-AIR";
                        }
                        else if (strtrantype == "AI")
                        {
                            ledgername = "Air Imports";
                            //  str_VouTypeINCEXP = "-AIR";
                        }
                        else if (strtrantype == "CH")
                        {
                            ledgername = "CHA";
                        }
                        else if (strtrantype == "BT")
                        {
                            ledgername = "Bonded Trucking";
                        }

                        else if (strtrantype == "NI")
                        {
                            ledgername = "Agency Imports";
                            //  str_VouTypeINCEXP = "-SEA";
                        }
                        else if (strtrantype == "NE")
                        {
                            ledgername = "Agency Exports";
                            // str_VouTypeINCEXP = "-AIR";
                        }


                        vdate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                        Dt_voudate = vdate;
                        voudate = string.Format("{0:yyyyMMdd}", vdate);
                        string pcode;
                        pcode = OSDCNObj.GetPortCode(branchid);


                        //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                        ledgernameexin = ledgername;//+ " - " + ledgerexpinc;
                        jobprefix = Dt.Rows[0]["jobno"].ToString();



                        jobno = Dt.Rows[0]["jobno"].ToString();


                        blno = Dt.Rows[0]["blno"].ToString();

                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }

                        if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                        {
                            //vounoyear = hid_portcode.Value + "BS" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            vounoyear = branchshort1 + "BS" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;
                        }
                        else
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                //vounoyear = hid_portcode.Value + "BS" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "BS" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;
                            }
                            else
                            {
                                //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                //vounoyear = hid_portcode.Value + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "BS" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;
                            }
                        }

                        GetNarration(vouno, blno, "B", vouyear);
                        GetReference(vouno, "BOS", vouyear);


                    }
                    break;

                case "Admin Sales Invoice":
                    filename = "DNAdmin";
                    ledgerexpinc = "Income";
                    Dt = Invobj.ShowTallyDt(vouno, "DN-Admin", vouyear, branchid);
                    totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "DN-Admin", branchid, vouyear), 2);
                    totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "DN-Admin", branchid, vouyear) * -1, 2);
                    totamountST = Math.Round(-(totalamount + totamountWOST), 2);
                    if (Dt.Rows.Count > 0)
                    {
                        blr = true;
                        strtrantype = "X";
                        ledgername = "Admin Sales Invoice";
                        vdate = Convert.ToDateTime(Dt.Rows[0]["dndate"].ToString());
                        Dt_voudate = vdate;
                        voudate = string.Format("{0:yyyyMMdd}", vdate);
                        string pcode;
                        pcode = OSDCNObj.GetPortCode(branchid);
                        //vounoyear = pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                        blno = Dt.Rows[0]["refno"].ToString();
                        jobno = Dt.Rows[0]["jobno"].ToString();
                        jobprefix = Dt.Rows[0]["jobno"].ToString();
                        //if (jobprefix.Length > 0 && jobprefix.Length < 2)
                        //{
                        //    numformat = "00";
                        //}
                        //else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                        //{
                        //    numformat = "0";
                        //}
                        //else
                        //{
                            numformat = "";
                        //}
                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }



                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }

                        if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102)) 
                        {
                            //vounoyear = hid_portcode.Value + "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            vounoyear = "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + branchshort1 + vouno;
                        }
                        else
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                //vounoyear = hid_portcode.Value + "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                //vounoyear = branchshort1 + "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;
                                
                                vounoyear = "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + branchshort1 + vouno;
                            }
                            else
                            {
                                //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                //vounoyear = hid_portcode.Value + "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                //vounoyear = branchshort1 + "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                                vounoyear = "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + branchshort1 + vouno;
                            }
                        }
                        GetNarration(vouno, blno, "DN-Admin", vouyear);
                        GetReference(vouno, "Admin Sales Invoice", vouyear);
                    }
                    break;
                case "Purchase Invoice": //"PaymentAdvises":
                    ledgerexpinc = "Expenses";
                    filename = "PI";
                    Dt = Invobj.ShowTallyDt(vouno, "PaymentAdvise", vouyear, branchid);
                    totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "PaymentAdvise", branchid, vouyear) * -1, 2);
                    totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "PaymentAdvise", branchid, vouyear), 2);
                    totamountST = Math.Round((totalamount + totamountWOST) * -1, 2);
                    if (Dt.Rows.Count > 0)
                    {
                        blr = true;
                        strtrantype = Dt.Rows[0]["trantype"].ToString();
                        if (strtrantype == "FE"|| strtrantype == "OE")
                        {
                            ledgername = "Ocean Forwarding Exports";
                        }
                        else if (strtrantype == "FI"|| strtrantype == "OI")
                        {
                            ledgername = "Ocean Forwarding Imports";
                        }
                        else if (strtrantype == "AE")
                        {
                            ledgername = "Air Exports";
                        }
                        else if (strtrantype == "AI")
                        {
                            ledgername = "Air Imports";
                        }
                        else if (strtrantype == "CH")
                        {
                            ledgername = "CHA";
                        }
                        else if (strtrantype == "BT")
                        {
                            ledgername = "Bonded Trucking";
                        }
                        else if (strtrantype == "NI")
                        {
                            ledgername = "Agency Imports";
                            //  str_VouTypeINCEXP = "-SEA";
                        }
                        else if (strtrantype == "NE")
                        {
                            ledgername = "Agency Exports";
                            // str_VouTypeINCEXP = "-AIR";
                        }

                        vdate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                        Dt_voudate = vdate;
                        voudate = string.Format("{0:yyyyMMdd}", vdate);
                        string pcode;
                        pcode = OSDCNObj.GetPortCode(branchid);
                        //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                        PACustID = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                        DtRece = TDSObj.GetTDSDtlsForCustomer(PACustID);
                        CustTdsType = "";
                        if (DtRece.Rows.Count > 0)
                        {
                            CustTdsType = DtRece.Rows[0]["tdsdesc"].ToString();
                        }
                        PATdsAmt = 0;
                        PATdsAmt = Math.Round(Invobj.GetPATDSAmt(vouno, "P", PACustID, branchid, Convert.ToInt32(txt_year.Text)), 2);
                        ledgernameexin = ledgername; // +" - " + ledgerexpinc;
                        jobno = Dt.Rows[0]["jobno"].ToString();
                        vendorrefno = Dt.Rows[0]["vendorrefno"].ToString();
                        blno = Dt.Rows[0]["blno"].ToString();
                        jobprefix = Dt.Rows[0]["jobno"].ToString();
                        if (jobprefix.Length > 0 && jobprefix.Length < 2)
                        {
                            numformat = "00";
                        }
                        else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                        {
                            numformat = "0";
                        }
                        else
                        {
                            numformat = "";
                        }
                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }

                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }

                        if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                        {
                            //vounoyear = hid_portcode.Value + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            vounoyear = branchshort1 + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                        }
                        else
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                vounoyear = hid_portcode.Value + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            }
                            else
                            {
                                //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                vounoyear = hid_portcode.Value + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            }
                        }
                        GetNarration(vouno, blno, "PaymentAdvise", vouyear);
                        GetReference(vouno, "PaymentAdvise", vouyear);


                    }
                    break;
                case "Payment Advise - Admin":
                    ledgerexpinc = "Expenses";
                    filename = "PAAdmin";
                    Dt = Invobj.ShowTallyDt(vouno, "PA-Admin", vouyear, branchid);
                    totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "PA-Admin", branchid, vouyear) * -1, 2);
                    totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "PA-Admin", branchid, vouyear), 2);
                    totamountST = Math.Round((totalamount + totamountWOST) * -1, 2);
                    if (Dt.Rows.Count > 0)
                    {
                        blr = true;
                        strtrantype = "S";
                        ledgername = "Payment Advise - Admin";
                        vdate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                        Dt_voudate = vdate;
                        voudate = string.Format("{0:yyyyMMdd}", vdate);
                        string pcode;
                        pcode = OSDCNObj.GetPortCode(branchid);
                        //vounoyear = pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                        PACustID = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                        vendorrefno = Dt.Rows[0]["vendorrefno"].ToString();
                        DtRece = TDSObj.GetTDSDtlsForCustomer(PACustID);
                        CustTdsType = "";
                        if (DtRece.Rows.Count > 0)
                        {
                            CustTdsType = DtRece.Rows[0]["tdsdesc"].ToString();
                        }
                        PATdsAmt = 0;
                        PATdsAmt = Math.Round(Invobj.GetPATDSAmt(vouno, "S", PACustID, branchid, Convert.ToInt32(txt_year.Text)), 2);
                        blno = Dt.Rows[0]["refno"].ToString();
                        jobno = Dt.Rows[0]["jobno"].ToString();


                        jobprefix = Dt.Rows[0]["jobno"].ToString();
                        if (jobprefix.Length > 0 && jobprefix.Length < 2)
                        {
                            numformat = "00";
                        }
                        else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                        {
                            numformat = "0";
                        }
                        else
                        {
                            numformat = "";
                        }

                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }

                        if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                        {
                            //vounoyear = hid_portcode.Value + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            //vounoyear = branchshort1 + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            vounoyear = "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + branchshort1 + vouno;
                        }
                        else
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                //vounoyear = hid_portcode.Value + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                //vounoyear = branchshort1 + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                                vounoyear = "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + branchshort1 + vouno;

                            }
                            else
                            {
                                //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                //vounoyear = hid_portcode.Value + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                //vounoyear = branchshort1 + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                                vounoyear = "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + branchshort1 + vouno;
                            }
                        }
                        GetNarration(vouno, blno, "PA-Admin", vouyear);
                        GetReference(vouno, "Payment Advise - Admin", vouyear);
                    }
                    break;

                case "OSSI":
                    vouname = "OSSI";
                    ledgerexpinc = "Income";
                    Dt = Invobj.ShowTallyDt(vouno, "OSSI", vouyear, branchid);
                    if (Dt.Rows.Count > 0)
                    {
                        blr = true;
                        dcjobno = Convert.ToInt32(Dt.Rows[0][3].ToString());
                        vendorrefno = Dt.Rows[0]["vendorrefno"].ToString();
                        jobprefix = Dt.Rows[0][3].ToString();
                        if (jobprefix.Length > 0 && jobprefix.Length < 2)
                        {
                            numformat = "00";
                        }
                        else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                        {
                            numformat = "0";
                        }
                        else
                        {
                            numformat = "";
                        }
                        jobno = dcjobno.ToString();
                        dcdate = Convert.ToDateTime(Dt.Rows[0][1].ToString());
                        Dt_voudate = dcdate;
                        dcdndate = string.Format("{0:yyyyMMdd}", dcdate);
                        voudate = dcdndate;
                        dctrantype = Dt.Rows[0][2].ToString();
                        //if(dctrantype =="FE")
                        //{
                        //    ledgername = "Ocean Exports";
                        //}
                        //else if (dctrantype == "FI"|| dctrantype == "OI")
                        //{
                        //    ledgername = "Ocean Imports";
                        //}
                        //else if (dctrantype == "AE")
                        //{
                        //    ledgername = "Air Exports";
                        //}
                        //else if (dctrantype == "AI")
                        //{
                        //    ledgername = "Air Imports";
                        //}
                        //else if (dctrantype == "CH")
                        //{
                        //    ledgername = "CHA";
                        //}
                        //else if (dctrantype == "BT")
                        //{
                        //    ledgername = "Bonded Trucking";
                        //}
                        ledgername = Fn_GetTrantype(dctrantype);
                        strtrantype = dctrantype;
                        dccustomerid = Convert.ToInt32(Dt.Rows[0][4].ToString());
                        dccustomername = (Custobj.GetLedgerName(dccustomerid)).Trim();
                        partyledger = dccustomername;
                        //Getvouchertype
                        //dcamount = Math.Round(Convert.ToDouble((Dt.Rows[0][6].ToString())), 2);//, TriState.True, TriState.True, TriState.True)
                        //dcexrate = Math.Round(Convert.ToDouble(Dt.Rows[0][7].ToString()), 2);//, TriState.True, TriState.True, TriState.True)
                        dcamount = Convert.ToDouble(Dt.Rows[0][6]);
                        dcexrate = Convert.ToDouble(Dt.Rows[0][7]);
                        curr = Dt.Rows[0][8].ToString();
                        string pcode;
                        pcode = OSDCNObj.GetPortCode(branchid);
                        JVpcode = pcode;
                        double am;
                        am = dcamount * dcexrate;
                        am = Math.Round(am, 2);
                        dcvouno = dctrantype + "/" + pcode + "/" + vouno + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        //if(curr == "USD")
                        //{
                        //    curr = "$";
                        //}
                        dctotal = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                        dctotalamount = "" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                        ledgernameexin = ledgername;// +" - " + ledgerexpinc;
                        dcnamount = am;
                        Dt = DCobj.GetDCAdviseWBranch(dcjobno, dctrantype, "DebitAdvise", branchid, vouno, vouyear);
                        if (Dt.Rows.Count > 0)
                        {
                            blno = Dt.Rows[0]["blno"].ToString();
                        }
                        GetNarration(vouno, blno, "D", vouyear);


                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }

                        if (dcdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))        
                        {
                            vounoyear = hid_portcode.Value + "OD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            vounoyear = branchshort1 + "OD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                        }
                        else
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                vounoyear = hid_portcode.Value + "OD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "OD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            }
                            else
                            {
                                //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                vounoyear = hid_portcode.Value + "OD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "DO" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            }
                        }
                        dcvouno = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                        if (ddl_reference.Text == "Voucher No")
                        {
                            GetReference(vouno, "OSSI", vouyear);
                        }
                        else
                        {
                            GetReference(dcjobno, "OSSI", vouyear);
                        }
                    }
                    break;
                case "OSPI":
                    vouname = "OSPI";
                    ledgerexpinc = "Expenses";
                    Dt = Invobj.ShowTallyDt(vouno, "OSPI", vouyear, branchid);
                    if (Dt.Rows.Count > 0)
                    {
                        blr = true;
                        dcjobno = Convert.ToInt32(Dt.Rows[0][3].ToString());
                        vendorrefno = Dt.Rows[0]["vendorrefno"].ToString();
                        jobprefix = Dt.Rows[0][3].ToString();
                        if (jobprefix.Length > 0 && jobprefix.Length < 2)
                        {
                            numformat = "00";
                        }
                        else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                        {
                            numformat = "0";
                        }
                        else
                        {
                            numformat = "";
                        }
                        jobno = dcjobno.ToString();
                        dcdate = Convert.ToDateTime(Dt.Rows[0][1].ToString());
                        Dt_voudate = dcdate;
                        dcdndate = string.Format("{0:yyyyMMdd}", dcdate);
                        voudate = dcdndate;
                        dctrantype = Dt.Rows[0][2].ToString();
                        ledgername = Fn_GetTrantype(dctrantype);
                        strtrantype = dctrantype;
                        dccustomerid = Convert.ToInt32(Dt.Rows[0][4].ToString());
                        dccustomername = (Custobj.GetLedgerName(dccustomerid)).Trim();
                        partyledger = dccustomername;
                        //Getvouchertype
                        //dcamount = Math.Round(Convert.ToDouble((Dt.Rows[0][6].ToString())), 2);//, TriState.True, TriState.True, TriState.True)
                        //dcexrate = Math.Round(Convert.ToDouble(Dt.Rows[0][7].ToString()), 2);//, TriState.True, TriState.True, TriState.True)
                        dcamount = Convert.ToDouble(Dt.Rows[0][6]);
                        dcexrate = Convert.ToDouble(Dt.Rows[0][7]);
                        curr = Dt.Rows[0][8].ToString();
                        string pcode;
                        pcode = OSDCNObj.GetPortCode(branchid);
                        JVpcode = pcode;
                        dcvouno = dctrantype + "/" + pcode + "/" + vouno + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        double am;
                        am = dcamount * dcexrate;
                        am = Math.Round(am, 2);
                        dctotal = curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                        dctotalamount = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                        ledgernameexin = ledgername;// +" - " + ledgerexpinc;
                        dcnamount = am * -1;
                        Dt = DCobj.GetDCAdviseWBranch(dcjobno, dctrantype, "", branchid, vouno, vouyear);
                        if (Dt.Rows.Count > 0)
                        {
                            blno = Dt.Rows[0]["blno"].ToString();
                        }
                        GetNarration(vouno, blno, "C", vouyear);

                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }
                        vounoyear = hid_portcode.Value + "OC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                        vounoyear = branchshort1 + "OC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;


                        dcvouno = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                        GetReference(dcjobno, "OSPI", vouyear);
                    }
                    break;
                case "Debit Note - Others":
                    vouname = voutype;
                    filename = "DN";
                    Dt = Invobj.ShowTallyDt(vouno, "DNHead", vouyear, branchid);
                    if (Dt.Rows.Count > 0)
                    {
                       Session["dnreverse"] = Dt.Rows[0]["billtype"].ToString(); // Vino [20-12-2023]

                    if (Dt.Rows[0]["billtype"].ToString() != "R")
                    {
                        totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "DNHead", branchid, vouyear), 2);
                        totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "DNHead", branchid, vouyear) * -1, 2);
                    }
                    else if (Dt.Rows[0]["billtype"].ToString() == "R")
                    {
                        totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "DNHead", branchid, vouyear) * -1, 2);
                        totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "DNHead", branchid, vouyear), 2);
                    }
                    //totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "DNHead", branchid, vouyear), 2);
                    //totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "DNHead", branchid, vouyear) * -1, 2);

                    if ((totalamount + totamountWOST) == 0)
                    {
                        totamountST = Math.Round(-(totalamount + totamountWOST), 0);
                    }
                    else
                    {
                        totamountST = Math.Round(-(totalamount + totamountWOST), 2);
                    }

                    
                        blr = true;
                        strtrantype = Dt.Rows[0]["trantype"].ToString();
                        ledgername = Fn_GetTrantype(strtrantype);
                        pcode = OSDCNObj.GetPortCode(branchid);
                        JVpcode = pcode;
                        vdate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                        billtype = Dt.Rows[0]["billtype"].ToString();
                        Dt_voudate = vdate;
                        voudate = string.Format("{0:yyyyMMdd}", vdate);
                        //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        JVDNCustomerid = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                        custtype = "";
                        custtype = Custobj.GetCustomerType(Convert.ToInt32(Dt.Rows[0]["customerid"]));
                        if (custtype == "P")
                        {
                            Dt1 = Invobj.GetOtherDCNAmount(vouno, "DNHead", branchid, vouyear);
                            if (Dt1.Rows.Count > 0)
                            {
                                dcamount = Math.Round(Convert.ToDouble(Dt1.Rows[0][2].ToString()), 2);//, TriState.True, TriState.True, TriState.True)
                                dcexrate = Math.Round(Convert.ToDouble(Dt1.Rows[0][1].ToString()), 2);//, TriState.True, TriState.True, TriState.True)
                                curr = Dt1.Rows[0][0].ToString();
                            }
                            double am;
                            am = dcamount * dcexrate;
                            am = Math.Round(am, 2);
                            dctotal = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                            dctotalamount = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                            dcnamount = am;

                        }
                        partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                        ledgernameexin = ledgername;// +" - " + ledgerexpinc;
                        jobno = Dt.Rows[0]["jobno"].ToString();//strtrantype + "-" + 
                        dcvouno = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                        dcjobno = Convert.ToInt32(Dt.Rows[0]["jobno"].ToString());
                        jobprefix = Dt.Rows[0]["jobno"].ToString();
                        if (jobprefix.Length > 0 && jobprefix.Length < 2)
                        {
                            numformat = "00";
                        }
                        else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                        {
                            numformat = "0";
                        }
                        else
                        {
                            numformat = "";
                        }
                        dctrantype = strtrantype;
                        blno = Dt.Rows[0]["blno"].ToString();


                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;


                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }

                        if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                        {
                            vounoyear = hid_portcode.Value + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            vounoyear = branchshort1 + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                        }
                        else
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                vounoyear = hid_portcode.Value + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            }
                            else
                            {
                                //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                vounoyear = hid_portcode.Value + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            }
                        }
                        GetNarration(vouno, blno, "V", vouyear);
                        GetReference(vouno, "DNHead", vouyear);
                    }
                    break;
                case "Credit Note - Others":
                    vouname = voutype;
                    filename = "CN";
                    Dt = Invobj.ShowTallyDt(vouno, "CNHead", vouyear, branchid);
                    totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "CNHead", branchid, vouyear) * -1, 2);
                    totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "CNHead", branchid, vouyear), 2);
                    if ((totalamount + totamountWOST) == 0)
                    {
                        totamountST = Math.Round((totalamount + totamountWOST) * -1, 2);
                    }
                    else if ((totalamount + totamountWOST) < 0)
                    {
                        totamountST = 0;
                    }
                    else
                    {
                        totamountST = Math.Round((totalamount + totamountWOST) * -1, 2);
                    }
                    if (Dt.Rows.Count > 0)
                    {
                        blr = true;
                        strtrantype = Dt.Rows[0]["trantype"].ToString();
                        ledgername = Fn_GetTrantype(strtrantype);
                        pcode = OSDCNObj.GetPortCode(branchid);
                        JVpcode = pcode;
                        billtype = Dt.Rows[0]["billtype"].ToString();
                        vdate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                        Dt_voudate = vdate;
                        voudate = string.Format("{0:yyyyMMdd}", vdate);
                        //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        JVDNCustomerid = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                        DtRece = TDSObj.GetTDSDtlsForCustomer(JVDNCustomerid);
                        CustTdsType = "";
                        if (DtRece.Rows.Count > 0)
                        {
                            CustTdsType = DtRece.Rows[0]["tdsdesc"].ToString();
                        }
                        PATdsAmt = 0;
                        PATdsAmt = Math.Round(Invobj.GetPATDSAmt(vouno, "E", JVDNCustomerid, branchid, Convert.ToInt32(txt_year.Text)), 2);
                        custtype = Custobj.GetCustomerType(Convert.ToInt32(Dt.Rows[0]["customerid"]));
                        vendorrefno = Dt.Rows[0]["vendorrefno"].ToString();
                        if (custtype == "P")
                        {
                            Dt1 = Invobj.GetOtherDCNAmount(vouno, "CNHead", branchid, vouyear);
                            if (Dt1.Rows.Count > 0)
                            {
                                dcamount = Math.Round(Convert.ToDouble(Dt1.Rows[0][2].ToString()), 2);
                                dcexrate = Math.Round(Convert.ToDouble(Dt1.Rows[0][1].ToString()), 2);
                                curr = Dt1.Rows[0][0].ToString();
                            }
                            double am;
                            am = dcamount * dcexrate;
                            am = Math.Round(am, 2);
                            dctotal = curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                            dctotalamount = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                            dcnamount = Math.Round(am * -1);

                        }
                        partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                        ledgernameexin = ledgername;// +" - " + ledgerexpinc;
                        jobno = Dt.Rows[0]["jobno"].ToString(); //strtrantype + "-" + 
                        dcvouno = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                        dcjobno = Convert.ToInt32(Dt.Rows[0]["jobno"].ToString());
                        dctrantype = strtrantype;
                        blno = Dt.Rows[0]["blno"].ToString();

                        jobprefix = Dt.Rows[0]["jobno"].ToString();
                        if (jobprefix.Length > 0 && jobprefix.Length < 2)
                        {
                            numformat = "00";
                        }
                        else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                        {
                            numformat = "0";
                        }
                        else
                        {
                            numformat = "";
                        }
                        str_Voutrantype = strtrantype.ToString();
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        else
                        {
                            str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                        }
                        //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                        if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                        {
                            vounum = "0000";
                        }
                        else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                        {
                            vounum = "000";
                        }
                        else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                        {
                            vounum = "00";
                        }
                        else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                        {
                            vounum = "0";
                        }
                        else
                        {
                            vounum = "";
                        }

                        if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                        {
                            vounoyear = hid_portcode.Value + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            vounoyear = branchshort1 + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                        }
                        else
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                vounoyear = hid_portcode.Value + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            }
                            else
                            {
                                //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                vounoyear = hid_portcode.Value + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                vounoyear = branchshort1 + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + str_Voutrantype.ToString().Replace("FE", "OE").Replace("FI", "OI") + vounum + vouno;

                            }
                        }
                        GetNarration(vouno, blno, "E", vouyear);
                        GetReference(vouno, "CNHead", vouyear);
                    }
                    break;
                case "Receipt - Bank":
                    classname = "Bank";
                    RVouname = "BANKRECEIPTS";
                    mode = "B";
                    //Dt = RcptObj.GetRecptSlipDtls(vouno, branchid, Convert.ToChar(mode), Convert.ToInt32(txt_year.Text));
                    //if (Dt.Rows.Count > 0)
                    //{
                    //    //StrbrnchbnkAccno = Dt.Rows[0]["acnos"].ToString();
                    //    strbrnchbnkname = Dt.Rows[0]["bankname"].ToString();
                    //}
                    //else
                    //{
                    //    return;
                    //}
                    GetBankReceipts(vouno);
                    break;
                case "Receipt - Cash":
                    classname = "Cash";
                    RVouname = "Cash Receipt";
                    mode = "C";
                    GetBankReceipts(vouno);
                    break;
                case "Bank Payment":
                    classname = "Bank"; ;
                    RVouname = "Bank Payment";
                    mode = "B";
                    GetBankPayments(vouno);
                    break;
                case "Cash Payment":
                    classname = "Cash";
                    RVouname = "Cash Payment";
                    mode = "C";
                    GetBankPayments(vouno);
                    break;
                case "Bank Payment - Transfer From CO":
                    classname = "Bank";
                    RVouname = "Bank Payment";
                    mode = "B";
                    GetBankPayments(vouno);
                    break;
                case "Cash Payment - Transfer From CO":
                    classname = "Cash";
                    RVouname = "Cash Payment";
                    mode = "C";
                    GetBankPayments(vouno);
                    break;

                case "Remittance-Payment":
                    classname = "RP"; ;
                    RVouname = "Remittance Payment";
                    mode = "B";
                    GetRemittancePayments(vouno);
                    break;
                case "Remittance-Receipt":
                    classname = "RP"; ;
                    RVouname = "Remittance Receipt";
                    mode = "B";
                    GetRemittanceReceipt(vouno);
                    break;
            }

            if (partyledger != "")
            {
                partyledger = partyledger.Replace("&", "&amp;");
            }
        }

        protected void GetBankPayments(int vouno)
        {
            Rvouyear = txt_year.Text;
            if ((logobj.GetDate()).Month < 10)
            {
                Rmonth = "0" + (logobj.GetDate()).Month;
            }
            else
            {
                Rmonth = ((logobj.GetDate()).Month).ToString();
            }

            Rvouyear = Rvouyear.Substring(2, 2);

            DtRece = PymtObj.GetPaymentHead(vouno, branchid, Convert.ToChar(mode), Convert.ToInt32(txt_year.Text));
            if (DtRece.Rows.Count > 0)
            {

                Rdate = Convert.ToDateTime(DtRece.Rows[0]["paymentdate"].ToString());
                strRdate = string.Format("{0:yyyyMMdd}", Rdate);
                partyname = DtRece.Rows[0]["customer"].ToString();
                RRFAmt = Convert.ToDouble(DtRece.Rows[0]["rfamount"].ToString());
                str_NEFT = DtRece.Rows[0]["NEFT"].ToString();

                Session["Enteredby"] = DtRece.Rows[0]["preparedby"].ToString(); // Vino renamed [05-03-2024]

                if (mode == "B")
                {
                    RBankid = Convert.ToInt32(DtRece.Rows[0]["bank"].ToString());
                    RBranch = DtRece.Rows[0]["bbranch"].ToString();
                    chequeno = DtRece.Rows[0]["chequeno"].ToString();
                    Chdate = Convert.ToDateTime(DtRece.Rows[0]["chequedate"].ToString());
                    strCHdate = string.Format("{0:dd-MM-yy}", Chdate);
                    strCHdate1 = string.Format("{0:yyyyMMdd}", Chdate);
                }


                narration = DtRece.Rows[0]["naration"].ToString();
                RBranchid = Convert.ToInt32(DtRece.Rows[0]["branchid"].ToString());
                Rbankname = RcptObj.GetBankName(RBankid);
                RID = Convert.ToInt32(DtRece.Rows[0]["paymentid"].ToString());

                if (RCustomer != "")
                {
                    RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (Rbankname != "")
                {
                    Rbankname = Rbankname.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (narration != "")
                {
                    narration = narration.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (partyname != "")
                {
                    partyname = partyname.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                string pcode;
                pcode = OSDCNObj.GetPortCode(RBranchid);
                if (Convert.ToInt32(txt_year.Text) == 2018)
                {
                    Rvouno = pcode.Replace("FIL", "AXL") + "/" + Rmonth + "/" + vouno + "/" + Rvouyear + "-" + lbl_toyear.Text.Substring(3, 2);
                }
                else
                {
                    Rvouno = pcode + "/" + Rmonth + "/" + vouno + "/" + Rvouyear + "-" + lbl_toyear.Text.Substring(3, 2);
                }
                //  Str_XML += CreatePRTally(vouno);
                if (Session["LoginBranchname"].ToString() == "CORPORATE")
                {
                    Str_XML += CreatePRTally(vouno);
                }
                else if (Session["LoginBranchname"].ToString() != "CORPORATE")
                {
                    Str_XML += CreatePRBVTally(vouno);
                }
            }



        }

        protected string CreatePRTally(int vouno)
        {
            string strtally = "";
            double RAMT = 0.00;

            strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + RVouname + "' ACTION='CREATE'>" + System.Environment.NewLine;


            strtally = strtally + "<DATE>" + strRdate + "</DATE>" + System.Environment.NewLine;
            strtally = strtally + "<NARRATION>Ch.No:" + chequeno + "/" + strCHdate + " " + Rbankname + " - " + narration + "  " + System.Environment.NewLine + " Paid To : " + partyname + " - " + vouno + "</NARRATION>" + System.Environment.NewLine;
            strtally = strtally + "<VOUCHERTYPENAME>" + RVouname + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            if (Convert.ToInt32(txt_year.Text) == 2018)
            {
                strtally = strtally + "<VOUCHERNUMBER>" + "BP-" + Rvouno + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            }
            else
            {
                strtally = strtally + "<VOUCHERNUMBER>" + "BP-" + Rvouno.Replace("AXL", "FIL") + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            }

            //partyledger = Rbankname;
            //  partyledger = "CTC ACCOUNT-" + DivObj.GetShortName(divisionid) + "CO";
            partyledger = Rbankname;
            if (mode == "B")
            {
                partyledger = Rbankname;
            }
            else if (mode == "C")
            {
                partyledger = "CASH";
                //partyledger = "PETTY CASH - " + BrObj.GetShortName(Convert.ToInt32(Session["LoginBranchid"])).ToUpper();
            }
            if (Convert.ToInt32(txt_year.Text) == 2018)
            {
                partyledger = partyledger.ToString().Replace("FIL", "AXL");
            }
            strtally = strtally + "<PARTYLEDGERNAME>" + Rbankname + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMISSUETYPE />" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMRECVTYPE />" + System.Environment.NewLine;
            strtally = strtally + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
            strtally = strtally + "<VCHGSTCLASS />" + System.Environment.NewLine;
            strtally = strtally + "<ENTEREDBY>" + Session["Enteredby"].ToString() + "</ENTEREDBY>" + System.Environment.NewLine; // Vino Renamed [05-03-2024]
            strtally = strtally + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
            strtally = strtally + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
            strtally = strtally + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
            strtally = strtally + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
            strtally = strtally + "<EFFECTIVEDATE>" + strRdate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
            strtally = strtally + "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
            strtally = strtally + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
            strtally = strtally + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
            strtally = strtally + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
            strtally = strtally + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
            strtally = strtally + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
            strtally = strtally + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
            strtally = strtally + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
            strtally = strtally + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
            strtally = strtally + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
            strtally = strtally + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;

            DataTable dt_FA = new DataTable();
           // Dt = obj_da_FA.GetPaymentCorpCust(Convert.ToInt32(vouno), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), 11, Convert.ToInt32(Session["LogYear"]), Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));


            Dt = PymtObj.GetPaymentCustnew(RID); 

            //Dt = PymtObj.GetPaymentCust(RID);
            for (int L = 0; L < Dt.Rows.Count; L++)
            {
                RCustomer = "";
                RCustomer = Dt.Rows[L][0].ToString();
                if (RCustomer != "")
                {
                    RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                RCAmt = Convert.ToDouble(Dt.Rows[L][1].ToString());
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>" + RCustomer + "</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>-" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;

                RAMT = RAMT + RCAmt;

                // --- 
               
                Dt1 = RcptObj.GetRAInvoiceToShow(RID, 'P');                
                for (int m = 0; m < Dt1.Rows.Count; m++)
                {
                    strtally = strtally + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    string RTRANTYPE = "";
                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) != 0)
                    {
                        DtRe = Invobj.ShowTallyDt(Convert.ToInt32(Dt1.Rows[m][2].ToString()), Dt1.Rows[m]["voutype"].ToString(), Convert.ToInt32(Dt1.Rows[m][7].ToString()), Convert.ToInt32(Dt1.Rows[m][0].ToString()));
                        //DtRe = Invobj.ShowTallyDt(Convert.ToInt32(Dt1.Rows[m][2].ToString()), "PA", Convert.ToInt32(Dt1.Rows[m][7].ToString()), branchid);

                        if (DtRe.Rows.Count > 0)
                        {
                            RTRANTYPE = DtRe.Rows[0]["trantype"].ToString();
                        }
                    }

                    RTRANTYPE = RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI");

                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) == 0)
                    {
                        strtally = strtally + "<NAME>On Account</NAME>" + System.Environment.NewLine;
                        strtally = strtally + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                    }
                    else
                    {
                        if (Dt1.Rows[m]["voutype"].ToString().Trim() == "B")
                        {
                            strtally = strtally + "<NAME>" + BrObj.GetShortName(Convert.ToInt32(Dt1.Rows[m]["branch"])).ToString().Substring(4, 3) + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("B", "BS") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                        }
                        else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "S")
                        {
                            strtally = strtally + "<NAME>" + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("S", "AC") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(Convert.ToInt32(Dt1.Rows[m]["branch"])).ToString().Substring(4, 3) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                        }
                        else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "X")
                        {
                            strtally = strtally + "<NAME>" + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("X", "AD") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(Convert.ToInt32(Dt1.Rows[m]["branch"])).ToString().Substring(4, 3) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                        }
                        else
                        {
                            strtally = strtally + "<NAME>" + BrObj.GetShortName(Convert.ToInt32(Dt1.Rows[m]["branch"])).ToString().Substring(4, 3) + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("I", "IN").Replace("P", "PA").Replace("V", "DN").Replace("E", "CN").Replace("S", "ACN").Replace("X", "ADN").Replace("OI", "OB IN").Replace("OP", "OB PA").Replace("OV", "OB DN").Replace("OE", "OB CN").Replace("OS", "OB ACN").Replace("OX", "OB ADN") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + RTRANTYPE + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                        }
                        strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                    }

                    strtally = strtally + "<AMOUNT>-" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                    strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    //else
                    //{
                    //    strtally = strtally + "<NAME>" + RTRANTYPE + " " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                    //    strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                    //}
                    //strtally = strtally + "<AMOUNT>-" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                    //strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                }
                
                // ---

                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            EAmount = 0; Amount = 0; tamt = 0;
            Dt = PymtObj.GetPaymentES(RID);
            if (Dt.Rows.Count > 0)
            {
                EAmount = Convert.ToDouble(Dt.Rows[0][0].ToString());
            }
            DtRe = PymtObj.GetPaymentChrg(RID);
            if (DtRe.Rows.Count > 0)
            {
                for (int k = 0; k < DtRe.Rows.Count; k++)
                {

                    Amount = Amount + Convert.ToDouble(DtRe.Rows[k][1].ToString());
                }
            }

            tamt = Amount + EAmount;
            for (int i = 0; i < DtRe.Rows.Count; i++)
            {
                Amount = Convert.ToDouble(DtRe.Rows[i][1].ToString());
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                if (DtRe.Rows[i][0].ToString() == "TAX DEDUCTED AT SOURCE PAYBALE")
                {
                    deductedchargename = "TDS Payables F/Y " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                }
                else
                {
                    deductedchargename = DtRe.Rows[i][0].ToString();
                }
                strtally = strtally + "<LEDGERNAME>" + deductedchargename.Replace("&", "&amp;").Replace("'", "&#39;") +"</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;

                if (mode == "B")
                {
                    if (Amount < 0)
                    {
                        strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                        strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                        strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                        strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                        strtally = strtally + "<AMOUNT>" + -Amount + "</AMOUNT>";
                    }
                    else
                    {
                        strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                        strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                        strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                        strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                        strtally = strtally + "<AMOUNT>" + -Amount + "</AMOUNT>";
                    }
                }
                else if (mode == "C")
                {
                    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                    strtally = strtally + "<AMOUNT>-" + Amount + "</AMOUNT>";
                }

                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;

            }

            strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            strtally = strtally + "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
            strtally = strtally + "<GSTCLASS/>" + System.Environment.NewLine;
            strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
            strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
            strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
            
            strtally = strtally + "<AMOUNT>" + (RAMT - (-tamt)) + "</AMOUNT>";
            //strtally = strtally + "<AMOUNT>" + (RCAmt - (-tamt)) + "</AMOUNT>";


            //Start Newly added for BANKALLOCATIONS
            strtally = strtally + "<BANKALLOCATIONS.LIST> " + System.Environment.NewLine;
            strtally = strtally + "<DATE>" + strRdate + "</DATE> " + System.Environment.NewLine;
            strtally = strtally + "<INSTRUMENTDATE>" + strCHdate1 + "</INSTRUMENTDATE> " + System.Environment.NewLine;
            strtally = strtally + "<NAME></NAME> " + System.Environment.NewLine;

            if (str_NEFT == "Y")
            {
                strtally = strtally + "<TRANSFERMODE>NEFT</TRANSFERMODE>" + System.Environment.NewLine;
            }
            else
            {
                strtally = strtally + "<TRANSACTIONTYPE>Cheque/DD</TRANSACTIONTYPE> " + System.Environment.NewLine;
            }
            strtally = strtally + "<PAYMENTFAVOURING></PAYMENTFAVOURING> " + System.Environment.NewLine;
            strtally = strtally + " <INSTRUMENTNUMBER>" + chequeno + "</INSTRUMENTNUMBER> " + System.Environment.NewLine;
            strtally = strtally + "<UNIQUEREFERENCENUMBER></UNIQUEREFERENCENUMBER> " + System.Environment.NewLine;
            strtally = strtally + "<PAYMENTMODE>Transacted</PAYMENTMODE>" + System.Environment.NewLine;
            strtally = strtally + "<AMOUNT>" + (RAMT - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;
            strtally = strtally + "</BANKALLOCATIONS.LIST>" + System.Environment.NewLine;

            //End Newly added for BANKALLOCATIONS


            
            strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            DtRe = PymtObj.GetPaymentES(RID);
            if (DtRe.Rows.Count > 0)
            {
               // Double amount1;
              //  amount1 = Convert.ToDouble(DtRe.Rows[0][0]);

                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>Round Up</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;

                strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                //if (amount1 < 0)
                //{
                //    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    
                //}
                //else
                //{
                 

                //    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                //}
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>" + -Convert.ToDouble(DtRe.Rows[0][0]) + "</AMOUNT>";

              //  strtally = strtally + "<AMOUNT>" + -Convert.ToDouble(DtRe.Rows[0][0]) + "</AMOUNT>";
                //if (amount1 < 0)
                //{
                    

                //    strtally = strtally + "<AMOUNT>" + -Convert.ToDouble(DtRe.Rows[0][0]) + "</AMOUNT>";
                //}
                //else
                //{
                //    strtally = strtally + "<AMOUNT>" + Convert.ToDouble(DtRe.Rows[0][0]) + "</AMOUNT>";
                //}

                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            strtally = strtally + "</VOUCHER>" + System.Environment.NewLine;
            Invobj.UpdVouTally(j, branchid, vouyear, ddl_voucher.Text, empid);
            logobj.InsLogDetail(empid, 161, 1, branchid, j + ddl_voucher.Text);
            EAmount = 0; Amount = 0; tamt = 0; RCAmt = 0; RAMT = 0;
            return strtally;
        }

        protected void GetBankReceipts(int vouno)
        {
            Rvouyear = txt_year.Text;
            if ((logobj.GetDate()).Month < 10)
            {
                Rmonth = "0" + (logobj.GetDate()).Month;
            }
            else
            {
                Rmonth = ((logobj.GetDate()).Month).ToString();
            }
            Rvouyear = Rvouyear.Substring(2, 2);
            DtRece = RcptObj.GetRecptHead(vouno, branchid, Convert.ToChar(mode), Convert.ToInt32(txt_year.Text));
            if (DtRece.Rows.Count > 0)
            {
                Rdate = Convert.ToDateTime(DtRece.Rows[0]["receiptdate"].ToString());
                strRdate = string.Format("{0:yyyyMMdd}", Rdate);
                partyname = DtRece.Rows[0]["customername"].ToString();
                RRFAmt = Convert.ToDouble(DtRece.Rows[0]["rfamount"].ToString());

                Session["Enteredby"] = DtRece.Rows[0]["preparedby"].ToString(); // Vino renamed [05-03-2024]

                str_NEFT = DtRece.Rows[0]["NEFT"].ToString();
                if (mode == "B")
                {
                    RBankid = Convert.ToInt32(DtRece.Rows[0]["bank"].ToString());
                    RBranch = DtRece.Rows[0]["bbranch"].ToString();
                    chequeno = DtRece.Rows[0]["chequeno"].ToString();
                    Chdate = Convert.ToDateTime(DtRece.Rows[0]["chequedate"].ToString());
                    strCHdate = string.Format("{0:dd-MM-yy}", Chdate);

                    strCHdate1 = string.Format("{0:yyyyMMdd}", Chdate);
                }
                narration = DtRece.Rows[0]["naration"].ToString();
                RBranchid = Convert.ToInt32(DtRece.Rows[0]["branchid"].ToString());
                Rbankname = obj_da_FA.GetBankfromReceiptandBank(vouno, "R", branchid, Convert.ToInt32(txt_year.Text), mode.ToString());
                //Rbankname = RcptObj.GetBankName(RBankid);
                RID = Convert.ToInt32(DtRece.Rows[0]["receiptid"].ToString());
                if (RCustomer != "")
                {
                    RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (Rbankname != "")
                {
                    Rbankname = Rbankname.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (narration != "")
                {
                    narration = narration.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (partyname != "")
                {
                    partyname = partyname.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                string pcode;
                pcode = OSDCNObj.GetPortCode(RBranchid);
                Rvouno = pcode + "/" + Rmonth + "/" + j + "/" + Rvouyear + "-" + lbl_toyear.Text.Substring(3, 2);
                Str_XML += CreateBRTally();
            }
        }

        protected string CreateBRTally()
        {
            string strtally = "", strsub;
            strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + RVouname + "' ACTION='CREATE'>" + System.Environment.NewLine;


           /* strtally = strtally + "<BANKERSDATE.LSIT>" + System.Environment.NewLine;
            strtally = strtally + "<BANKERSDATE></BANKERSDATE>" + System.Environment.NewLine;
            strtally = strtally + "</BANKERSDATE.LSIT>" + System.Environment.NewLine;
            */

            strtally = strtally + "<DATE>" + strRdate + "</DATE>" + System.Environment.NewLine;
            if (mode == "B")
            {
                strtally = strtally + "<NARRATION>Ch. No. :" + chequeno + "/" + strCHdate + " " + Rbankname + " - " + narration + "  " + System.Environment.NewLine + " Received From : " + partyname + "</NARRATION>";
            }
            else
            {
                strtally = strtally + "<NARRATION>Received From : " + partyname + "</NARRATION>" + System.Environment.NewLine;
            }
            strtally = strtally + "<VOUCHERTYPENAME>" + RVouname + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            strtally = strtally + "<VOUCHERNUMBER>" + "BR-" + Rvouno + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            RCustomer = "";
            Dt = RcptObj.GetRecptCust(RID);
            if (Dt.Rows.Count > 0)
            {
                RCustomer = Dt.Rows[0]["ledgername"].ToString();
                RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
            }
            strtally = strtally + "<PARTYLEDGERNAME>" + RCustomer + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMISSUETYPE />" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMRECVTYPE />" + System.Environment.NewLine;
            strtally = strtally + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
            strtally = strtally + "<VCHGSTCLASS />" + System.Environment.NewLine;
            strtally = strtally + "<ENTEREDBY>" + Session["Enteredby"].ToString() + "</ENTEREDBY>" + System.Environment.NewLine; // Vino renamed [05-03-2024]
            strtally = strtally + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
            strtally = strtally + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
            strtally = strtally + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
            strtally = strtally + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
            strtally = strtally + "<EFFECTIVEDATE>" + strRdate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
            strtally = strtally + "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
            strtally = strtally + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
            strtally = strtally + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
            strtally = strtally + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
            strtally = strtally + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
            strtally = strtally + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
            strtally = strtally + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
            strtally = strtally + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
            strtally = strtally + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
            strtally = strtally + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
            strtally = strtally + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
            //Dt = RcptObj.GetRecptCust(RID);
            Dt = PymtObj.GetPaymentCust4FANEW(RID, "R");
            for (int L = 0; L < Dt.Rows.Count; L++)
            {
                //strsub = "";
                RCustomer = "";
                BanchFA = Convert.ToInt32(Dt.Rows[L]["branchid"].ToString());
                if (Convert.ToInt32(Dt.Rows[L]["branchid"].ToString()) == BanchFA)
                {
                    RCustomer = Dt.Rows[L]["ledgername"].ToString();
                    if (RCustomer != "")
                    {
                        RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
                    }
                    RCAmt = Convert.ToDouble(Dt.Rows[L][1].ToString());
                    strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERNAME>" + RCustomer + "</LEDGERNAME>" + System.Environment.NewLine;
                    strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
                    strtally = strtally + "<AMOUNT>" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;

                    //Dt1 = RcptObj.GetRAInvoiceToShowWithCustomer(RID, 'R', Convert.ToInt32(Dt.Rows[L]["customer"]));
                    Dt1 = RcptObj.GetRAInvoiceToShowWithCustomerNEW(RID, 'R', 0, BanchFA);
                    for (int m = 0; m < Dt1.Rows.Count; m++)
                    {

                        strtally = strtally + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                        string RTRANTYPE = "";
                        if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) != 0)
                        {
                            DtRe = Invobj.ShowTallyDt(Convert.ToInt32(Dt1.Rows[m][2].ToString()), "Invoice", Convert.ToInt32(Dt1.Rows[m][7].ToString()), Convert.ToInt32(Dt1.Rows[m][0].ToString()));
                            if (DtRe.Rows.Count > 0)
                            {
                                RTRANTYPE = DtRe.Rows[0]["trantype"].ToString();
                            }
                        }

                        RTRANTYPE = RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI");

                        if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) == 0)
                        {
                            strtally = strtally + "<NAME>On Account</NAME>" + System.Environment.NewLine;
                            strtally = strtally + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                        }
                        else
                        {
                            if (Dt1.Rows[m]["voutype"].ToString().Trim() == "B")
                            {
                                strtally = strtally + "<NAME>" + BrObj.GetShortName(Convert.ToInt32(Dt1.Rows[m]["branch"])).ToString().Substring(4, 3) + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("B", "BS") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else
                            {
                                strtally = strtally + "<NAME>" + BrObj.GetShortName(Convert.ToInt32(Dt1.Rows[m]["branch"])).ToString().Substring(4, 3) + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("I", "IN").Replace("P", "PA").Replace("V", "DN").Replace("E", "CN").Replace("S", "ACN").Replace("X", "ADN").Replace("OI", "OB IN").Replace("OP", "OB PA").Replace("OV", "OB DN").Replace("OE", "OB CN").Replace("OS", "OB ACN").Replace("OX", "OB ADN") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + RTRANTYPE + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                        }

                        strtally = strtally + "<AMOUNT>" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                        strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                        //else
                        //{
                        //    strtally = strtally + "<NAME>" + RTRANTYPE + " " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                        //    strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                        //}

                        //strtally = strtally + "<AMOUNT>" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                        //strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;

                    }
                    strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                }
                else if (Convert.ToInt32(Dt.Rows[L]["branchid"].ToString()) != 5)
                {
                    if (Convert.ToInt32(txt_year.Text) == 2018)
                    {
                        RCustomer = "CTC ACCOUNT - " + BrObj.GetShortName(Convert.ToInt32(Dt.Rows[L]["branchid"].ToString())).ToUpper().Replace("FIL", "AXL");
                    }
                    else
                    {
                        RCustomer = "CTC ACCOUNT - " + BrObj.GetShortName(Convert.ToInt32(Dt.Rows[L]["branchid"].ToString())).ToUpper();
                    }

                    DtRe = RcptObj.GetRecptChrgNEW(RID, Convert.ToInt32(Dt.Rows[L]["branchid"].ToString()),0);

                    //for (int i = 0; i < DtRe.Rows.Count; i++)
                    //{
                    //    if ((DtRe.Rows[i][0].ToString()).Substring(0, 14) == "TDS RECEIVABLE")
                    //    {
                    //        TdsAmount = TdsAmount + Convert.ToDouble(DtRe.Rows[i]["chg"].ToString());
                    //    }
                    //}
                    RCustomer = RCustomer.Replace("&", "&amp;");
                    if (DtRe.Rows.Count > 0)
                    {
                        RCAmt = Convert.ToDouble(Dt.Rows[L][1].ToString()) - Convert.ToDouble(DtRe.Rows[0]["CustTDSamt"].ToString());
                    }
                    else
                    {
                        RCAmt = Convert.ToDouble(Dt.Rows[L][1].ToString());
                    }
                    strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERNAME>" + RCustomer + "</LEDGERNAME>" + System.Environment.NewLine;
                    strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
                    strtally = strtally + "<AMOUNT>" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;


                    strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;


                }
            }
            DtRe = RcptObj.GetRecptChrg(RID,-1);
            for (int i = 0; i < DtRe.Rows.Count; i++)
            {
                if (BanchFA != 5)
                {
                    //if (DtRe.Rows[i][0].ToString().Substring(0, 8) != "TDS RECE")
                    //{
                        strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                        if (DtRe.Rows[i][0].ToString() == "TAX DEDUCTED AT SOURCE RECEIVABLE")
                        {
                            deductedchargename = "TDS Receivables F/Y " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                        }
                        else
                        {
                            deductedchargename = DtRe.Rows[i][0].ToString();
                        }
                        strtally = strtally + "<LEDGERNAME>" + deductedchargename.Trim() + "</LEDGERNAME>" + System.Environment.NewLine;
                        strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                        strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                        strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                        strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                        strtally = strtally + "<AMOUNT>" + DtRe.Rows[i][1].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                        strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                    //}
                }
                else
                {
                    strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                    if (DtRe.Rows[i][0].ToString() == "TAX DEDUCTED AT SOURCE RECEIVABLE")
                    {
                        deductedchargename = "TDS Receivables F/Y " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                    }
                    else
                    {
                        deductedchargename = DtRe.Rows[i][0].ToString();
                    }
                    strtally = strtally + "<LEDGERNAME>" + deductedchargename.Trim() + "</LEDGERNAME>" + System.Environment.NewLine;
                    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                    strtally = strtally + "<AMOUNT>" + DtRe.Rows[i][1].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                    strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                }
            }

            DtRe = RcptObj.GetES(RID);
            if (DtRe.Rows.Count > 0)
            {
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>Round Up</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>" + DtRe.Rows[0][0].ToString() + "</AMOUNT>";
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            if (mode == "B")
            {
                strtally = strtally + "<LEDGERNAME>" + Rbankname + "</LEDGERNAME>" + System.Environment.NewLine;
            }
            else if (mode == "C")
            {
                Rbankname = "PETTY CASH - " + BrObj.GetShortName(Convert.ToInt32(Session["LoginBranchid"])).ToUpper();
                if (Convert.ToInt32(txt_year.Text) == 2018)
                {
                    Rbankname = Rbankname.Replace("FIL", "AXL");
                }
                strtally = strtally + "<LEDGERNAME>" + Rbankname + "</LEDGERNAME>" + System.Environment.NewLine;
            }
            strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
            strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
            strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
            strtally = strtally + "<AMOUNT>-" + RRFAmt + "</AMOUNT>" + System.Environment.NewLine;


            //Start Newly added for BANKALLOCATIONS
            strtally = strtally + "<BANKALLOCATIONS.LIST> " + System.Environment.NewLine;
            strtally = strtally + "<DATE>" + strRdate + "</DATE> " + System.Environment.NewLine;
            strtally = strtally + "<INSTRUMENTDATE>" + strCHdate1 + "</INSTRUMENTDATE> " + System.Environment.NewLine;
            strtally = strtally + "<NAME></NAME> " + System.Environment.NewLine;

            if (str_NEFT == "Y")
            {
                strtally = strtally + "<TRANSFERMODE>NEFT</TRANSFERMODE>" + System.Environment.NewLine;
            }
            else
            {
                strtally = strtally + "<TRANSACTIONTYPE>Cheque/DD</TRANSACTIONTYPE> " + System.Environment.NewLine;
            }
            strtally = strtally + "<PAYMENTFAVOURING></PAYMENTFAVOURING> " + System.Environment.NewLine;
            strtally = strtally + " <INSTRUMENTNUMBER>" + chequeno + "</INSTRUMENTNUMBER> " + System.Environment.NewLine;
            strtally = strtally + "<UNIQUEREFERENCENUMBER></UNIQUEREFERENCENUMBER> " + System.Environment.NewLine;
            strtally = strtally + "<PAYMENTMODE>Transacted</PAYMENTMODE>" + System.Environment.NewLine;
            strtally = strtally + "<AMOUNT>-" + RRFAmt + "</AMOUNT>" + System.Environment.NewLine;
            strtally = strtally + "</BANKALLOCATIONS.LIST>" + System.Environment.NewLine;

            //End Newly added for BANKALLOCATIONS




            strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            strtally = strtally + "</VOUCHER>" + System.Environment.NewLine;
            Invobj.UpdVouTally(j, branchid, vouyear, ddl_voucher.Text, empid);
            logobj.InsLogDetail(empid, 161, 3, branchid, j + ddl_voucher.Text);
            return strtally;
        }

        private string Fn_GetTrantype(string str_Trantype)
        {
            transfer_id.Visible = false;
            btn_UnTransfer.Visible = false;
            btn_UnTransfer.ForeColor = System.Drawing.Color.Gray;

            string Str_temp = "";
            switch (str_Trantype)
            {
                case "FE":
                    Str_temp = "Ocean Forwarding Exports";
                    break;
                case "FI":
                    Str_temp = "Ocean Forwarding Imports";
                    break;
                case "OE":
                    Str_temp = "Ocean Forwarding Exports";
                    break;
                case "OI":
                    Str_temp = "Ocean Forwarding Imports";
                    break;
                case "AE":
                    Str_temp = "Air Exports";
                    break;
                case "AI":
                    Str_temp = "Air Imports";
                    break;
                case "CH":
                    Str_temp = "CHA";
                    break;
                case "BT":
                    Str_temp = "Bonded Trucking";
                    break;
                case "NE":
                    Str_temp = "Agency Exports";
                    break;
                case "NI":
                    Str_temp = "Agency Imports";
                    break;
            }
            return Str_temp;
        }
        protected void GetNarration(int vouno, string blno, string ftype, int vouyear)
        {
            narration = "";

            // DataAccess.NVOCCExports.JobInfo NEJobObj = new DataAccess.NVOCCExports.JobInfo();
            switch (ddl_narration.Text)
            {
                case "LedgerNames":
                    switch (ddl_voucher.Text)
                    {
                        case "Invoices":
                            Dt = Invobj.GetInvoiceDetails(vouno, ftype, vouyear, branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                narration = Dt.Rows[i][0].ToString() + "," + narration;
                            }
                            if (narration != "")
                            {
                                narration = narration.Substring(0, narration.Length - 1);
                            }
                            break;
                        case "Purchase Invoice":// "PaymentAdvises":
                            Dt = Invobj.GetPADetails(vouno, vouyear, branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                narration = Dt.Rows[i][0].ToString() + "," + narration;
                            }
                            if (narration != "")
                            {
                                narration = narration.Substring(0, narration.Length - 1);
                            }
                            break;
                        case "OSSI":
                            filename = "OSSI";
                            Dt = DCobj.GetDCAdviseWBranch(dcjobno, dctrantype, "DebitAdvise", branchid, vouno, vouyear);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                blno = Dt.Rows[i]["blno"].ToString();
                                DtRe = DCobj.GetDCCharge(blno, dctrantype, "DebitAdvise", branchid);
                                for (int d = 0; d < DtRe.Rows.Count; d++)
                                {
                                    narration = DtRe.Rows[d][0].ToString() + "," + narration;
                                }
                            }
                            if (narration != "")
                            {
                                narration = narration.Substring(0, narration.Length - 1);
                            }
                            break;
                        case "OSPI":
                            filename = "OSPI";
                            Dt = DCobj.GetDCAdviseWBranch(dcjobno, dctrantype, "", branchid, vouno, vouyear);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                blno = Dt.Rows[i]["blno"].ToString();
                                DtRe = DCobj.GetDCCharge(blno, dctrantype, "CreditAdvise", branchid);
                                for (int d = 0; d < DtRe.Rows.Count; d++)
                                {
                                    narration = DtRe.Rows[d][0].ToString() + "," + narration;
                                }
                            }
                            if (narration != "")
                            {
                                narration = narration.Substring(0, narration.Length - 1);
                            }
                            break;
                        case "Debit Note - Others":
                            filename = "DN";
                            Dt = Invobj.GetInvoiceDetails(vouno, ftype, vouyear, branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                narration = Dt.Rows[i][0].ToString() + "," + narration;
                            }
                            if (narration != "")
                            {
                                narration = narration.Substring(0, narration.Length - 1);
                            }
                            break;
                        case "Credit Note - Others":
                            filename = "CN";
                            Dt = Invobj.GetPADetails(vouno, vouyear, branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                narration = Dt.Rows[i][0].ToString() + "," + narration;
                            }
                            if (narration != "")
                            {
                                narration = narration.Substring(0, narration.Length - 1);
                            }
                            break;
                        case "Admin Sales Invoice":
                            filename = "AD";
                            Dt = Invobj.ShowTallyDt(vouno, "DN-Admin", vouyear, branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                narration = Dt.Rows[i][10].ToString() + "," + narration;
                            }
                            if (narration != "")
                            {
                                narration = narration.Substring(0, narration.Length - 1);
                            }
                            break;
                        case "Admin Purchase Invoice":
                            filename = "AC";
                            Dt = Invobj.ShowTallyDt(vouno, "PA-Admin", vouyear, branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                narration = Dt.Rows[i][10].ToString() + "," + narration;
                            }
                            if (narration != "")
                            {
                                narration = narration.Substring(0, narration.Length - 1);
                            }
                            break;
                    }
                    break;
                case "Vessel/Voyage/Container":
                    if (ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "OSPI")
                    {
                        if (strtrantype == "FE" || strtrantype == "OI" ||strtrantype == "OE" || strtrantype == "FI"|| strtrantype == "AE" || strtrantype == "AI")
                        {
                            //DataAccess.CloseJobs jobcloseobj = new DataAccess.CloseJobs();
                            //DataAccess.ForwardingImports.JobInfo FIJobObj = new DataAccess.ForwardingImports.JobInfo();
                            if (strtrantype == "FE"|| strtrantype == "OE")
                            {
                                Dt = FEJobObj.GetFEJobInfonew(Convert.ToInt32(jobno), branchid, divisionid);
                                if (Dt.Rows.Count > 0)
                                {
                                    narration = Dt.Rows[0][3].ToString() + " / " + Dt.Rows[0][7].ToString() + " / POD : " + Dt.Rows[0]["pod"].ToString() + " / POL : " + Dt.Rows[0]["pol"].ToString() + " / SALES PERSON : " + Dt.Rows[0]["employeename"].ToString();

                                }
                            }
                            else if (strtrantype == "FE"|| strtrantype == "OE")
                            {
                                //DataAccess.Masters.MasterVessel VesselObj = new DataAccess.Masters.MasterVessel();
                                Dt = FIJobObj.ShowJobDetailsnew(Convert.ToInt32(jobno), branchid, divisionid);
                                if (Dt.Rows.Count > 0)
                                {
                                    narration = VesselObj.GetVesselname(Convert.ToInt32(Dt.Rows[0][1].ToString())) + " / " + Dt.Rows[0][2].ToString() + " / ";
                                }
                            }
                            else if (strtrantype == "AE" || strtrantype == "AI")
                            {
                                Dt = FEJobObj.AEAIJobInfo(Convert.ToInt32(jobno), branchid, divisionid, strtrantype);
                                if (Dt.Rows.Count > 0)
                                {
                                    narration = Dt.Rows[0]["flightno"].ToString();

                                }
                            }

                            /*    else if (strtrantype == "NE")
                            {
                                Dt = NEJobObj.GetNEJobInfonew(Convert.ToInt32(jobno), branchid, divisionid);
                                if (Dt.Rows.Count > 0)
                                {
                                    narration = Dt.Rows[0]["vslvoy"].ToString() + " / POD : " + Dt.Rows[0]["pod"].ToString() + " / POL : " + Dt.Rows[0]["pol"].ToString() + " / SALES PERSON : " + Dt.Rows[0]["employeename"].ToString();

                                }
                            }
                        else if (strtrantype == "NI")
                            {
                                Dt = NEJobObj.GetNIJobInfonew(Convert.ToInt32(jobno), branchid, divisionid);
                                if (Dt.Rows.Count > 0)
                                {
                                    narration = Dt.Rows[0]["vslvoy"].ToString() + " / POD : " + Dt.Rows[0]["pod"].ToString() + " / POL : " + Dt.Rows[0]["pol"].ToString() + " / SALES PERSON : " + Dt.Rows[0]["employeename"].ToString();

                                }
                            }*/

                            if (dctrantype == "FE"|| dctrantype == "OE")
                            {
                                Dt = FEJobObj.GetContainerDetails(Convert.ToInt32(jobno), blno, branchid, divisionid);
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    narration = Dt.Rows[i][0].ToString() + "," + narration;
                                }
                                if (narration != "")
                                {
                                    narration = narration.Substring(0, narration.Length - 1);
                                }
                            }
                            else if (dctrantype == "FI"|| dctrantype == "OI")
                            {
                                Dt = FIBLObj.GetContainerDetail(Convert.ToInt32(jobno), blno, branchid, divisionid);
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    narration += Dt.Rows[i][0].ToString();
                                }
                                if (narration != "")
                                {
                                    narration = narration.Substring(0, narration.Length - 1);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (strtrantype == "FE" || strtrantype == "FI" || strtrantype == "OE" || strtrantype == "OI")
                        {
                            Dt = Invobj.GetHblInvoiceHeadnew(blno, strtrantype, branchid);
                            if (Dt.Rows.Count > 0)
                            {
                                narration = Dt.Rows[0][3].ToString() + " / " + Dt.Rows[0][2].ToString() + " / POD : " + Dt.Rows[0]["pod"].ToString() + " / POL : " + Dt.Rows[0]["pol"].ToString() + " / SALES PERSON : " + Dt.Rows[0]["employeename"].ToString();
                            }

                        }
                        /* else if (strtrantype == "NE")
                         {
                             Dt = NEJobObj.GetNEJobInfonew(Convert.ToInt32(jobno), branchid, divisionid);
                             if (Dt.Rows.Count > 0)
                             {
                                 narration = Dt.Rows[0]["vslvoy"].ToString() + " / POD : " + Dt.Rows[0]["pod"].ToString() + " / POL : " + Dt.Rows[0]["pol"].ToString() + " / SALES PERSON : " + Dt.Rows[0]["employeename"].ToString();

                             }
                         }
                         else if (strtrantype == "NI")
                         {
                             Dt = NEJobObj.GetNIJobInfonew(Convert.ToInt32(jobno), branchid, divisionid);
                             if (Dt.Rows.Count > 0)
                             {
                                 narration = Dt.Rows[0]["vslvoy"].ToString() + " / POD : " + Dt.Rows[0]["pod"].ToString() + " / POL : " + Dt.Rows[0]["pol"].ToString() + " / SALES PERSON : " + Dt.Rows[0]["employeename"].ToString();

                             }
                         }*/
                        Dt = Invobj.GetHBLContainerDtls(blno, strtrantype, branchid);
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            narration = narration + " / " + Dt.Rows[i][0].ToString();
                        }

                    }

                    break;
                case "Remarks":
                    if (ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "OSPI")
                    {
                        narration = "";
                    }
                    else
                    {
                        Dt = Invobj.ShowTallyDt(vouno, ftype, vouyear, branchid);
                        if (Dt.Rows.Count > 0)
                        {
                            narration = Dt.Rows[0][10].ToString();
                        }
                    }
                    break;
            }
            if (ftype == "PaymentAdvise")
            {
                ftype = "P";

            }
            Dt = Invobj.GetPolPod(vouno, ftype, vouyear, branchid);
            if (Dt.Rows.Count > 0)
            {
                if (narration != "")
                {
                    narration = narration + "/" + Dt.Rows[0]["POL"].ToString();
                }
                else
                {
                    narration = Dt.Rows[0]["POL"].ToString();
                }

            }
            if (narration != "")
            {
                narration = narration.Replace("&", "&amp;").Replace("'", "&#39;");
            }
        }

        /*    protected void GetNarration(int vouno, string blno, string ftype, int vouyear)
            {
                narration = "";
                switch (ddl_narration.Text)
                {
                    case "LedgerNames":
                        switch (ddl_voucher.Text)
                        {
                            case "Invoices":
                                Dt = Invobj.GetInvoiceDetails(vouno, ftype, vouyear, branchid);
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    narration = Dt.Rows[i][0].ToString() + "," + narration;
                                }
                                if (narration != "")
                                {
                                    narration = narration.Substring(0, narration.Length - 1);
                                }
                                break;
                            case "Credit Note - Operations":// "PaymentAdvises":
                                Dt = Invobj.GetPADetails(vouno, vouyear, branchid);
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    narration = Dt.Rows[i][0].ToString() + "," + narration;
                                }
                                if (narration != "")
                                {
                                    narration = narration.Substring(0, narration.Length - 1);
                                }
                                break;
                            case "OSSI":
                                filename = "OSSI";
                                Dt = DCobj.GetDCAdviseWBranch(dcjobno, dctrantype, "DebitAdvise", branchid,vouno,vouyear);
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    blno = Dt.Rows[i]["blno"].ToString();
                                    DtRe = DCobj.GetDCCharge(blno, dctrantype, "DebitAdvise", branchid);
                                    for (int d = 0; d < DtRe.Rows.Count; d++)
                                    {
                                        narration = DtRe.Rows[d][0].ToString() + "," + narration;
                                    }
                                }
                                if (narration != "")
                                {
                                    narration = narration.Substring(0, narration.Length - 1);
                                }
                                break;
                            case "OSPI":
                                filename = "OSPI";
                                Dt = DCobj.GetDCAdviseWBranch(dcjobno, dctrantype, "", branchid,vouno,vouyear);
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    blno = Dt.Rows[i]["blno"].ToString();
                                    DtRe = DCobj.GetDCCharge(blno, dctrantype, "CreditAdvise", branchid);
                                    for (int d = 0; d < DtRe.Rows.Count; d++)
                                    {
                                        narration = DtRe.Rows[d][0].ToString() + "," + narration;
                                    }
                                }
                                if (narration != "")
                                {
                                    narration = narration.Substring(0, narration.Length - 1);
                                }
                                break;
                            case "Debit Note - Others":
                                filename = "DN";
                                Dt = Invobj.GetInvoiceDetails(vouno, ftype, vouyear, branchid);
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    narration = Dt.Rows[i][0].ToString() + "," + narration;
                                }
                                if (narration != "")
                                {
                                    narration = narration.Substring(0, narration.Length - 1);
                                }
                                break;
                            case "Credit Note - Others":
                                filename = "CN";
                                Dt = Invobj.GetPADetails(vouno, vouyear, branchid);
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    narration = Dt.Rows[i][0].ToString() + "," + narration;
                                }
                                if (narration != "")
                                {
                                    narration = narration.Substring(0, narration.Length - 1);
                                }
                                break;
                        }
                        break;
                    case "Vessel/Voyage/Container":
                        if (ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "OSPI")
                        {
                            if (strtrantype == "FE" || strtrantype == "FI")
                            {
                                DataAccess.CloseJobs jobcloseobj = new DataAccess.CloseJobs();
                                DataAccess.ForwardingImports.JobInfo FIJobObj = new DataAccess.ForwardingImports.JobInfo();
                                if (strtrantype == "FE"|| strtrantype == "OE")
                                {
                                    Dt = FEJobObj.GetFEJobInfo(dcjobno, branchid, divisionid);
                                    if (Dt.Rows.Count > 0)
                                    {
                                        narration = Dt.Rows[0][3].ToString() + " / " + Dt.Rows[0][7].ToString() + " / ";

                                    }
                                }
                                else
                                {
                                    DataAccess.Masters.MasterVessel VesselObj = new DataAccess.Masters.MasterVessel();
                                    Dt = FIJobObj.ShowJobDetails(dcjobno, branchid, divisionid);
                                    if (Dt.Rows.Count > 0)
                                    {
                                        narration = VesselObj.GetVesselname(Convert.ToInt32(Dt.Rows[0][1].ToString())) + " / " + Dt.Rows[0][2].ToString() + " / ";
                                    }
                                }

                                if (dctrantype == "FE"|| dctrantype == "OI")
                                {
                                    Dt = FEJobObj.GetContainerDetails(dcjobno, blno, branchid, divisionid);
                                    for (int i = 0; i < Dt.Rows.Count; i++)
                                    {
                                        narration = Dt.Rows[i][0].ToString() + "," + narration;
                                    }
                                    if (narration != "")
                                    {
                                        narration = narration.Substring(0, narration.Length - 1);
                                    }
                                }
                                else
                                {
                                    Dt = FIBLObj.GetContainerDetail(dcjobno, blno, branchid, divisionid);
                                    for (int i = 0; i < Dt.Rows.Count; i++)
                                    {
                                        narration += Dt.Rows[i][0].ToString();
                                    }
                                    if (narration != "")
                                    {
                                        narration = narration.Substring(0, narration.Length - 1);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Dt = Invobj.GetHblInvoiceHead(blno, strtrantype, branchid);
                            if (Dt.Rows.Count > 0)
                            {
                                narration = Dt.Rows[0][3].ToString() + " / " + Dt.Rows[0][2].ToString();
                            }
                            Dt = Invobj.GetHBLContainerDtls(blno, strtrantype, branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                narration = narration + " / " + Dt.Rows[i][0].ToString();
                            }
                        }

                        break;
                    case "Remarks":
                        if (ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "OSPI")
                        {
                            narration = "";
                        }
                        else
                        {
                            Dt = Invobj.ShowTallyDt(vouno, ftype, vouyear, branchid);
                            if (Dt.Rows.Count > 0)
                            {
                                narration = Dt.Rows[0][10].ToString();
                            }
                        }
                        break;
                }
                if (narration != "")
                {
                    narration = narration.Replace("&", "&amp;");
                }
            }*/

        protected void GetReference(int vouno, string ftype, int vouyear)
        {
            switch (ddlref)
            {
                case "Voucher No":
                    //reference = strtrantype + " " + vouno;
                    reference = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                    break;
                case "Ref No":
                    reference = vendorrefno;
                    break;
                case "Vendor Ref No":
                    reference = vendorrefno;
                    break;
                case "BL No":
                    if (ddl_voucher.Text == "OSSI" || ddl_voucher.Text == "OSPI")
                    {
                        if (ddl_voucher.Text == "OSSI")
                        {
                            Dt = DCobj.GetDCAdviseWBranch(vouno, dctrantype, "DebitAdvise", branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                reference = Dt.Rows[i]["blno"].ToString() + "," + reference;
                            }
                            if (reference != "")
                            {
                                reference = reference.Substring(0, reference.Length - 1);
                            }
                        }
                        else
                        {
                            Dt = DCobj.GetDCAdviseWBranch(vouno, dctrantype, "CreditAdvise", branchid);
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                reference = Dt.Rows[i]["blno"].ToString() + "," + reference;
                            }
                            if (reference != "")
                            {
                                reference = reference.Substring(0, reference.Length - 1);
                            }
                        }
                    }
                    else
                    {
                        Dt = Invobj.ShowTallyDt(vouno, ftype, vouyear, branchid);
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            reference = Dt.Rows[i]["blno"].ToString() + "," + reference;
                        }
                        if (reference != "")
                        {
                            reference = reference.Substring(0, reference.Length - 1);
                        }
                    }
                    break;
            }
            if (reference != "")
            {
                reference = reference.Replace("&", "&amp;").Replace("'", "&#39;");
            }

            //reference = reference.Replace("FE", "OE").Replace("FI", "OI");
        }

        protected void GetDepositdata()
        {
            DSDt = RcptObj.GetSlipDetails4tally(txt_from.Text, branchid, 'B');
            for (int i = 0; i < DSDt.Rows.Count; i++)
            {
                slipdate = Convert.ToDateTime(DSDt.Rows[i]["slipdate"].ToString());
                dssldate = string.Format("{0:yyyyMMdd}", slipdate);
                dsbname = DSDt.Rows[i]["bankname"].ToString();
                dsbname = dsbname.Replace("&", "&amp;").Replace("'", "&#39;");
                dschqno = DSDt.Rows[i]["chequeno"].ToString();
                vouno = DSDt.Rows[i]["vounum"].ToString();
                recamt = Convert.ToDouble(DSDt.Rows[i]["amount"].ToString());

                Session["Enteredby"] = DSDt.Rows[i]["preparedby"].ToString(); // Vino renamed [05-03-2024]

                partyledger = "CTC ACCOUNT-" + DivObj.GetShortName(divisionid) + "CO";
                CreateBankDepositTally();
                narration = "";
                dssldate = "";
                partyledger = "";
            }

            DSDt = RcptObj.GetSlipDetails4tally(txt_from.Text, branchid, 'C');
            for (int i = 0; i < DSDt.Rows.Count; i++)
            {
                slipdate = Convert.ToDateTime(DSDt.Rows[i]["slipdate"].ToString());
                dssldate = string.Format("{0:yyyyMMdd}", slipdate);
                vouno = DSDt.Rows[i]["vounum"].ToString();
                recamt = Convert.ToDouble(DSDt.Rows[i]["amount"].ToString());
                partyledger = "CTC ACCOUNT-" + DivObj.GetShortName(divisionid) + "CO";

                Session["Enteredby"] = DSDt.Rows[i]["preparedby"].ToString(); // Vino renamed [05-03-2024]

                CreateCashDepositTally();
                narration = "";
                dssldate = "";
                partyledger = "";
            }
        }

        protected void CreateBankDepositTally()
        {
            //strpart1 = "";
            Str_XML += "<VOUCHER REMOTEID='' VCHTYPE='" + vouname + "' ACTION='CREATE'>" + System.Environment.NewLine;

            Str_XML += "<DATE>" + dssldate + "</DATE>" + System.Environment.NewLine;
            Str_XML += "<NARRATION>CHQ. " + dschqno + " DEPOSITED INTO  " + dsbname + " VIDE DEPOSIT SLIP NO. " + txt_from.Text.Trim() + "</NARRATION>" + System.Environment.NewLine;
            Str_XML += "<VOUCHERTYPENAME>" + vouname + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            Str_XML += "<VOUCHERNUMBER>" + vouno + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            Str_XML += "<PARTYLEDGERNAME>" + dsbname + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
            Str_XML += "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
            Str_XML += "<ENTEREDBY>"+ Session["Enteredby"].ToString() + "</ENTEREDBY>" + System.Environment.NewLine; // Vino renamed [05-03-2024]
            Str_XML += "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
            Str_XML += "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
            Str_XML += "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
            Str_XML += "<EFFECTIVEDATE>" + dssldate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
            Str_XML += "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
            Str_XML += "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
            Str_XML += "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
            Str_XML += "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
            Str_XML += "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
            Str_XML += "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
            Str_XML += "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
            Str_XML += "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
            Str_XML += "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
            Str_XML += "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
            Str_XML += "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
            Str_XML += "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
            Str_XML += "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
            Str_XML += "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
            Str_XML += "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
            Str_XML += "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            Str_XML += "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
            Str_XML += "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            Str_XML += "<AMOUNT>-" + recamt + "</AMOUNT>" + System.Environment.NewLine;
            Str_XML += "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            Str_XML += "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            //if (branchid == 9)
            //{
            //    Str_XML += "<LEDGERNAME>KPCT BRANCH - SMS</LEDGERNAME>" + System.Environment.NewLine;
            //}
            //else
            //{
            Str_XML += "<LEDGERNAME>" + dsledgname + "</LEDGERNAME>" + System.Environment.NewLine;
            // }

            Str_XML += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            Str_XML += "<AMOUNT>" + recamt + "</AMOUNT>" + System.Environment.NewLine;
            Str_XML += "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            Str_XML += "</VOUCHER>" + System.Environment.NewLine;
        }

        protected void CreateCashDepositTally()
        {
            Str_XML += "<VOUCHER REMOTEID='' VCHTYPE='" + vouname + "' ACTION='CREATE'>" + System.Environment.NewLine;

            Str_XML += "<DATE>" + dssldate + "</DATE>" + System.Environment.NewLine;
            Str_XML += "<NARRATION>SLIP NO. " + txt_from.Text.Trim() + "</NARRATION>" + System.Environment.NewLine;
            Str_XML += "<VOUCHERTYPENAME>" + vouname + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            Str_XML += "<VOUCHERNUMBER>" + vouno + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            Str_XML += "<PARTYLEDGERNAME>" + partyledger + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
            Str_XML += "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
            Str_XML += "<ENTEREDBY>"+ Session["Enteredby"].ToString() + "</ENTEREDBY>" + System.Environment.NewLine;  // Vino renamed [05-03-2024]
            Str_XML += "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
            Str_XML += "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
            Str_XML += "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
            Str_XML += "<EFFECTIVEDATE>" + dssldate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
            Str_XML += "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
            Str_XML += "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
            Str_XML += "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
            Str_XML += "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
            Str_XML += "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
            Str_XML += "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
            Str_XML += "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
            Str_XML += "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
            Str_XML += "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
            Str_XML += "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
            Str_XML += "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
            Str_XML += "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
            Str_XML += "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
            Str_XML += "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
            Str_XML += "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
            Str_XML += "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            Str_XML += "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
            Str_XML += "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            Str_XML += "<AMOUNT>-" + recamt + "</AMOUNT>" + System.Environment.NewLine;
            Str_XML += "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            Str_XML += "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            Str_XML += "<LEDGERNAME>" + dsledgname + "</LEDGERNAME>" + System.Environment.NewLine;
            Str_XML += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            Str_XML += "<AMOUNT>" + recamt + "</AMOUNT>" + System.Environment.NewLine;
            Str_XML += "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            Str_XML += "</VOUCHER>" + System.Environment.NewLine;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
        
            btn_UnTransfer.Enabled = false;
            btn_UnTransfer.ForeColor = System.Drawing.Color.Gray;

            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {

        }

        protected void btn_pdf_Click(object sender, EventArgs e)
        {

        }

        //Remittance Receipt & Payment
        protected void GetRemittanceReceipt(int vouno)
        {
            Rvouyear = txt_year.Text;
            if ((logobj.GetDate()).Month < 10)
            {
                Rmonth = "0" + (logobj.GetDate()).Month;
            }
            else
            {
                Rmonth = ((logobj.GetDate()).Month).ToString();
            }
            Rvouyear = Rvouyear.Substring(2, 2);
            DtRece = RcptObj.GetOSRecptHead(vouno, branchid, Convert.ToChar(mode), Convert.ToInt32(txt_year.Text));
            if (DtRece.Rows.Count > 0)
            {
                Rdate = Convert.ToDateTime(DtRece.Rows[0]["receiptdate"].ToString());
                strRdate = string.Format("{0:yyyyMMdd}", Rdate);
                partyname = DtRece.Rows[0]["customername"].ToString();
                RRFAmt = Convert.ToDouble(DtRece.Rows[0]["rfamount"].ToString());
                if (mode == "B")
                {
                    RBankid = Convert.ToInt32(DtRece.Rows[0]["bank"].ToString());
                    RBranch = DtRece.Rows[0]["bbranch"].ToString();
                    chequeno = DtRece.Rows[0]["chequeno"].ToString();
                    Chdate = Convert.ToDateTime(DtRece.Rows[0]["chequedate"].ToString());
                    strCHdate = string.Format("{0:dd-MM-yy}", Chdate);
                }
                narration = DtRece.Rows[0]["naration"].ToString();
                RBranchid = Convert.ToInt32(DtRece.Rows[0]["branchid"].ToString());
                Rbankname = RcptObj.GetBankName(RBankid);
                RID = Convert.ToInt32(DtRece.Rows[0]["receiptid"].ToString());

                Session["Enteredby"] = DtRece.Rows[0]["preparedby"].ToString(); // Vino renamed [05-03-2024]

                if (RCustomer != "")
                {
                    RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (Rbankname != "")
                {
                    Rbankname = Rbankname.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (narration != "")
                {
                    narration = narration.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                if (partyname != "")
                {
                    partyname = partyname.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                string pcode;
                pcode = OSDCNObj.GetPortCode(RBranchid);
                Rvouno = pcode + "/" + Rmonth + "/" + j + "/" + Rvouyear + "-" + lbl_toyear.Text.Substring(3, 2);
                Str_XML += CreateBRTallyforremittance();
            }
        }


        protected string CreateBRTallyforremittance()
        {
            string strtally = "", strsub;
            strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + RVouname + "' ACTION='CREATE'>" + System.Environment.NewLine;


            strtally = strtally + "<DATE>" + strRdate + "</DATE>" + System.Environment.NewLine;
            if (mode == "B")
            {
                strtally = strtally + "<NARRATION>Ch. No. :" + chequeno + "/" + strCHdate + " " + Rbankname + " - " + narration + "  " + System.Environment.NewLine + " Received From : " + partyname + "</NARRATION>";
            }
            else
            {
                strtally = strtally + "<NARRATION>Received From : " + partyname + "</NARRATION>" + System.Environment.NewLine;
            }
            strtally = strtally + "<VOUCHERTYPENAME>" + RVouname + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            strtally = strtally + "<VOUCHERNUMBER>" + Rvouno + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            RCustomer = "";
            Dt = RcptObj.GetOSRecptCust(RID);
            if (Dt.Rows.Count > 0)
            {
                RCustomer = Dt.Rows[0]["ledgername"].ToString();
                RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
            }
            strtally = strtally + "<PARTYLEDGERNAME>" + RCustomer + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMISSUETYPE />" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMRECVTYPE />" + System.Environment.NewLine;
            strtally = strtally + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
            strtally = strtally + "<VCHGSTCLASS />" + System.Environment.NewLine;
            strtally = strtally + "<ENTEREDBY>"+ Session["Enteredby"].ToString() + "</ENTEREDBY>" + System.Environment.NewLine;  // Vino renamed [05-03-2024]
            strtally = strtally + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
            strtally = strtally + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
            strtally = strtally + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
            strtally = strtally + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
            strtally = strtally + "<EFFECTIVEDATE>" + strRdate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
            strtally = strtally + "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
            strtally = strtally + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
            strtally = strtally + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
            strtally = strtally + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
            strtally = strtally + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
            strtally = strtally + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
            strtally = strtally + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
            strtally = strtally + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
            strtally = strtally + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
            strtally = strtally + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
            strtally = strtally + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
            Dt = RcptObj.GetOSRecptCust(RID);
            for (int L = 0; L < Dt.Rows.Count; L++)
            {
                //strsub = "";
                RCustomer = "";
                RCustomer = Dt.Rows[0]["ledgername"].ToString();
                if (RCustomer != "")
                {
                    RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                RCAmt = Convert.ToDouble(Dt.Rows[L][1].ToString());
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>" + RCustomer + "</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;

                Dt1 = RcptObj.GetRAInvoiceToShowWithCustomerforremittance(RID, 'R', Convert.ToInt32(Dt.Rows[L]["customer"]));
                for (int m = 0; m < Dt1.Rows.Count; m++)
                {
                    strtally = strtally + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    string RTRANTYPE = "";
                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) != 0)
                    {
                        DtRe = Invobj.ShowTallyDt(Convert.ToInt32(Dt1.Rows[m][2].ToString()), "OSSI", Convert.ToInt32(Dt1.Rows[m][7].ToString()), branchid);
                        if (DtRe.Rows.Count > 0)
                        {
                            RTRANTYPE = DtRe.Rows[0]["trantype"].ToString();
                        }
                    }

                    RTRANTYPE = RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI");

                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) == 0)
                    {
                        strtally = strtally + "<NAME>On Account</NAME>" + System.Environment.NewLine;
                        strtally = strtally + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                    }
                    else
                    {
                        //strtally = strtally + "<NAME>" + RTRANTYPE + " " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            if (Dt1.Rows[m]["voutype"].ToString().Trim() == "I")
                            {
                                strtally = strtally + "<NAME>" + "IN" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "V")
                            {
                                strtally = strtally + "<NAME>" + "DN" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "P")
                            {
                                strtally = strtally + "<NAME>" + "PA" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "E")
                            {
                                strtally = strtally + "<NAME>" + "CN" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "D")
                            {
                                strtally = strtally + "<NAME>" + "OSSI" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "C")
                            {
                                strtally = strtally + "<NAME>" + "OSPI" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                        }
                        else
                        {
                            strtally = strtally + "<NAME>" + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + " / " + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + " / " + Dt1.Rows[m]["ravouyear"].ToString() + " / " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                        }

                        strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                    }

                    strtally = strtally + "<AMOUNT>" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                    strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    //else
                    //{
                    //    strtally = strtally + "<NAME>" + RTRANTYPE + " " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                    //    strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                    //}

                    //strtally = strtally + "<AMOUNT>" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                    //strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;

                }
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            DtRe = RcptObj.GetOSRecptChrg(RID);
            for (int i = 0; i < DtRe.Rows.Count; i++)
            {

                if (DtRe.Rows[i][0].ToString() == "TAX DEDUCTED AT SOURCE RECEIVABLE")
                {
                    deductedchargename = "TDS Receivables F/Y " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                }
                else
                {
                    deductedchargename = DtRe.Rows[i][0].ToString();
                }
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>" + (deductedchargename).Trim() + "</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>" + DtRe.Rows[i][1].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            DtRe = RcptObj.GetOSES(RID);
            if (DtRe.Rows.Count > 0)
            {
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>Round Up</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>" + DtRe.Rows[0][0].ToString() + "</AMOUNT>";
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            if (mode == "B")
            {
                strtally = strtally + "<LEDGERNAME>" + strbrnchbnkname + "</LEDGERNAME>" + System.Environment.NewLine;
            }
            else
            {
                strtally = strtally + "<LEDGERNAME>Cash</LEDGERNAME>" + System.Environment.NewLine;
            }
            strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
            strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
            strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
            strtally = strtally + "<AMOUNT>-" + RRFAmt + "</AMOUNT>" + System.Environment.NewLine;
            strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            strtally = strtally + "</VOUCHER>" + System.Environment.NewLine;
            Invobj.UpdVouTally(j, branchid, vouyear, ddl_voucher.Text, empid);
            logobj.InsLogDetail(empid, 161, 3, branchid, j + ddl_voucher.Text);
            return strtally;
        }

        protected void GetRemittancePayments(int vouno)
        {
            Rvouyear = txt_year.Text;
            if ((logobj.GetDate()).Month < 10)
            {
                Rmonth = "0" + (logobj.GetDate()).Month;
            }
            else
            {
                Rmonth = ((logobj.GetDate()).Month).ToString();
            }

            Rvouyear = Rvouyear.Substring(2, 2);

            DtRece = PymtObj.GetOSPaymentHead(vouno, branchid, Convert.ToChar(mode), Convert.ToInt32(txt_year.Text));
            if (DtRece.Rows.Count > 0)
            {

                Rdate = Convert.ToDateTime(DtRece.Rows[0]["paymentdate"].ToString());
                strRdate = string.Format("{0:yyyyMMdd}", Rdate);
                partyname = DtRece.Rows[0]["customer"].ToString();
                RRFAmt = Convert.ToDouble(DtRece.Rows[0]["rfamount"].ToString());
                if (mode == "B")
                {
                    RBankid = Convert.ToInt32(DtRece.Rows[0]["bank"].ToString());
                    RBranch = DtRece.Rows[0]["bbranch"].ToString();
                    chequeno = DtRece.Rows[0]["chequeno"].ToString();
                    Chdate = Convert.ToDateTime(DtRece.Rows[0]["chequedate"].ToString());
                    strCHdate = string.Format("{0:dd-MM-yy}", Chdate);
                }
            }

            narration = DtRece.Rows[0]["naration"].ToString();
            RBranchid = Convert.ToInt32(DtRece.Rows[0]["branchid"].ToString());
            Rbankname = RcptObj.GetBankName(RBankid);
            RID = Convert.ToInt32(DtRece.Rows[0]["paymentid"].ToString());

            Session["Enteredby"] = DtRece.Rows[0]["preparedby"].ToString(); // Vino renamed [05-03-2024]

            if (RCustomer != "")
            {
                RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
            }
            if (Rbankname != "")
            {
                Rbankname = Rbankname.Replace("&", "&amp;").Replace("'", "&#39;");
            }
            if (narration != "")
            {
                narration = narration.Replace("&", "&amp;").Replace("'", "&#39;");
            }
            if (partyname != "")
            {
                partyname = partyname.Replace("&", "&amp;").Replace("'", "&#39;");
            }
            string pcode;
            pcode = OSDCNObj.GetPortCode(RBranchid);
            Rvouno = pcode + "/" + Rmonth + "/" + vouno + "/" + Rvouyear + "-" + lbl_toyear.Text.Substring(3, 2);
            Str_XML += CreateRPTally(vouno);



        }

        protected string CreateRPTally(int vouno)
        {
            string strtally = "";
            strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + RVouname + "' ACTION='CREATE'>" + System.Environment.NewLine;

           /* strtally = strtally + "<BANKERSDATE.LSIT>" + System.Environment.NewLine;
            strtally = strtally + "<BANKERSDATE></BANKERSDATE>" + System.Environment.NewLine;
            strtally = strtally + "</BANKERSDATE.LSIT>" + System.Environment.NewLine;
            */

            strtally = strtally + "<DATE>" + strRdate + "</DATE>" + System.Environment.NewLine;
            strtally = strtally + "<NARRATION>Ch.No:" + chequeno + "/" + strCHdate + " " + Rbankname + " - " + narration + "  " + System.Environment.NewLine + " Paid To : " + partyname + " - " + vouno + "</NARRATION>" + System.Environment.NewLine;
            strtally = strtally + "<VOUCHERTYPENAME>" + RVouname + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            strtally = strtally + "<VOUCHERNUMBER>" + Rvouno + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            //partyledger = Rbankname;
            partyledger = "CTC ACCOUNT-" + DivObj.GetShortName(divisionid) + "CO";
            strtally = strtally + "<PARTYLEDGERNAME>" + partyledger + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMISSUETYPE />" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMRECVTYPE />" + System.Environment.NewLine;
            strtally = strtally + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
            strtally = strtally + "<VCHGSTCLASS />" + System.Environment.NewLine;
            strtally = strtally + "<ENTEREDBY>" + Session["Enteredby"].ToString() + "</ENTEREDBY>" + System.Environment.NewLine;  // Vino renamed [05-03-2024]
            strtally = strtally + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
            strtally = strtally + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
            strtally = strtally + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
            strtally = strtally + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
            strtally = strtally + "<EFFECTIVEDATE>" + strRdate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
            strtally = strtally + "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
            strtally = strtally + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
            strtally = strtally + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
            strtally = strtally + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
            strtally = strtally + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
            strtally = strtally + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
            strtally = strtally + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
            strtally = strtally + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
            strtally = strtally + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
            strtally = strtally + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
            strtally = strtally + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
            Dt = PymtObj.GetOSPaymentCust(RID);
            for (int L = 0; L < Dt.Rows.Count; L++)
            {
                RCustomer = "";
                RCustomer = Dt.Rows[L][0].ToString();
                if (RCustomer != "")
                {
                    RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                RCAmt = Convert.ToDouble(Dt.Rows[L][1].ToString());
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>" + RCustomer + "</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>-" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;
                Dt1 = RcptObj.GetRAInvoiceToShow4OS(RID, 'P');
                for (int m = 0; m < Dt1.Rows.Count; m++)
                {
                    strtally = strtally + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    string RTRANTYPE = "";
                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) != 0)
                    {
                        DtRe = Invobj.ShowTallyDt(Convert.ToInt32(Dt1.Rows[m][2].ToString()), "OSPI", Convert.ToInt32(Dt1.Rows[m][7].ToString()), branchid);
                        if (DtRe.Rows.Count > 0)
                        {
                            RTRANTYPE = DtRe.Rows[0]["trantype"].ToString();
                        }
                    }
                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) == 0)
                    {
                        strtally = strtally + "<NAME>On Account</NAME>" + System.Environment.NewLine;
                        strtally = strtally + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                    }
                    else
                    {
                        //strtally = strtally + "<NAME>" + RTRANTYPE + " " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            if (Dt1.Rows[m]["voutype"].ToString().Trim() == "I")
                            {
                                strtally = strtally + "<NAME>" + "IN" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "V")
                            {
                                strtally = strtally + "<NAME>" + "DN" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "P")
                            {

                                strtally = strtally + "<NAME>" + "PA" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "E")
                            {
                                strtally = strtally + "<NAME>" + "CN" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "D")
                            {
                                strtally = strtally + "<NAME>" + "OSSI" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                            else if (Dt1.Rows[m]["voutype"].ToString().Trim() == "C")
                            {
                                strtally = strtally + "<NAME>" + "OSPI" + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + Dt1.Rows[m]["vouno"].ToString().Trim() + "</NAME>" + System.Environment.NewLine;
                            }
                        }
                        else
                        {
                            strtally = strtally + "<NAME>" + RTRANTYPE.Replace("FE", "OE").Replace("FI", "OI") + " / " + BrObj.GetShortName(branchid).ToString().Substring(4, 3) + " / " + Dt1.Rows[m]["ravouyear"].ToString() + " / " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                        }

                        strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                    }

                    strtally = strtally + "<AMOUNT>" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                    strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    //else
                    //{
                    //    strtally = strtally + "<NAME>" + RTRANTYPE + " " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                    //    strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                    //}
                    //strtally = strtally + "<AMOUNT>-" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                    //strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                }
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            EAmount = 0; Amount = 0; tamt = 0;
            Dt = PymtObj.GetOSPaymentES(RID);
            if (Dt.Rows.Count > 0)
            {
                EAmount = Convert.ToDouble(Dt.Rows[0][0].ToString());
            }
            DtRe = PymtObj.GetOSPaymentChrg(RID);
            if (DtRe.Rows.Count > 0)
            {
                Amount = Convert.ToDouble(Dt.Rows[0][1].ToString());
            }
            tamt = Amount + EAmount;
            for (int i = 0; i < DtRe.Rows.Count; i++)
            {
                if (DtRe.Rows[i][0].ToString() == "TAX DEDUCTED AT SOURCE PAYBALE")
                {
                    deductedchargename = "TDS Paybales F/Y " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                }
                else
                {
                    deductedchargename = DtRe.Rows[i][0].ToString();
                }
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>" + deductedchargename.Replace("&", "&amp;").Replace("'", "&#39;") +"</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                if (Convert.ToInt32(DtRe.Rows[0][1].ToString()) < 0)
                {
                    strtally = strtally + "<AMOUNT>" + -Convert.ToDouble(DtRe.Rows[0][1]) + "</AMOUNT>";
                }
                else
                {
                    strtally = strtally + "<AMOUNT>" + Convert.ToDouble(DtRe.Rows[0][1]) + "</AMOUNT>";
                }
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                Amount = Convert.ToDouble(DtRe.Rows[0][1].ToString());
            }

            strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            strtally = strtally + "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
            strtally = strtally + "<GSTCLASS/>" + System.Environment.NewLine;
            strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
            strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
            strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
            strtally = strtally + "<AMOUNT>" + (RCAmt - (-tamt)) + "</AMOUNT>";


          



            strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            DtRe = PymtObj.GetOSPaymentES(RID);
            if (DtRe.Rows.Count > 0)
            {
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>Round Up</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>" + -Convert.ToDouble(DtRe.Rows[0][0]) + "</AMOUNT>";

                /*
                //Start Newly added for BANKALLOCATIONS
                strtally = strtally + "<BANKALLOCATIONS.LIST> " + System.Environment.NewLine;
                strtally = strtally + "<DATE>" + strRdate + "</DATE> " + System.Environment.NewLine;
                strtally = strtally + "<INSTRUMENTDATE>" + strCHdate + "</INSTRUMENTDATE> " + System.Environment.NewLine;
                strtally = strtally + "<NAME></NAME> " + System.Environment.NewLine;

                if (str_NEFT == "Y")
                {
                    strtally = strtally + "<TRANSACTIONTYPE>NEFT</TRANSACTIONTYPE> " + System.Environment.NewLine;
                }
                else
                {
                    strtally = strtally + "<TRANSACTIONTYPE>Cheque/DD</TRANSACTIONTYPE> " + System.Environment.NewLine;
                }
                strtally = strtally + "<PAYMENTFAVOURING></PAYMENTFAVOURING> " + System.Environment.NewLine;
                strtally = strtally + " <INSTRUMENTNUMBER>" + chequeno + "</INSTRUMENTNUMBER> " + System.Environment.NewLine;
                strtally = strtally + "<UNIQUEREFERENCENUMBER></UNIQUEREFERENCENUMBER> " + System.Environment.NewLine;
                strtally = strtally + "<PAYMENTMODE>Transacted</PAYMENTMODE>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>" + Convert.ToDouble(DtRe.Rows[0][0]) + "</AMOUNT>" + System.Environment.NewLine;
                strtally = strtally + "</BANKALLOCATIONS.LIST>" + System.Environment.NewLine;

                //End Newly added for BANKALLOCATIONS
                */
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            strtally = strtally + "</VOUCHER>" + System.Environment.NewLine;
            Invobj.UpdVouTally(j, branchid, vouyear, ddl_voucher.Text, empid);
            logobj.InsLogDetail(empid, 161, 1, branchid, j + ddl_voucher.Text);
            return strtally;
        }

        protected void btnediall_Click(object sender, EventArgs e)
        {
            try
            {
                string portcode = "";
                btn_cancel.ToolTip = "Cancel";

                checkvalue();
                if (blerr == true)
                {
                    return;
                }
                portcode = OSDCNObj.GetPortCodeForTally(branchid);
                hid_portcode.Value = portcode.Substring(2, 3);
                vouyear = Convert.ToInt32(txt_year.Text);
                switch (ddl_voucher.Text)
                {
                    case "Invoices":
                        filename = "Inv";
                        ledgerexpinc = "Income";
                        strvtype = "I";
                        break;
                    case "Purchase Invoice":// "PaymentAdvises":
                        ledgerexpinc = "Expenses";
                        filename = "PI";
                        strvtype = "P";
                        break;
                    case "Payment Advise - Admin":
                        ledgerexpinc = "Expenses";
                        filename = "PAAdmin";
                        strvtype = "";
                        break;
                    case "Admin Sales Invoice":
                        ledgerexpinc = "Income";
                        filename = "DNAdmin";
                        strvtype = "";
                        break;
                    case "OSSI":
                        vouname = "Debit Note";
                        filename = "OSSI";
                        ledgerexpinc = "Income";
                        strvtype = "";
                        break;
                    case "OSPI":
                        vouname = "Credit Note";
                        filename = "OSPI";
                        ledgerexpinc = "Expenses";
                        strvtype = "";
                        break;
                    case "Debit Note - Others":
                        filename = "DN";
                        ledgerexpinc = "Income";
                        strvtype = "V";
                        break;
                    case "Credit Note - Others":
                        filename = "CN";
                        ledgerexpinc = "Expenses";
                        strvtype = "E";
                        break;
                    case "Receipt - Bank":
                        filename = "BR";
                        break;
                    case "Receipt - Cash":
                        filename = "CR";
                        break;
                    case "Bank Payment":
                        filename = "BP";
                        break;
                    case "Cash Payment":
                        filename = "CP";
                        break;
                    case "Bank Payment - Transfer From CO":
                        filename = "BP";
                        break;
                    case "Cash  Payment - Transfer From CO":
                        filename = "CP";
                        break;
                    case "Bank Deposit - Transfer To CO":
                        filename = "BD";
                        vouname = "Bank Deposit";
                        dsledgname = "Cheque Collection Account";
                        break;
                    case "Cash Deposit - Transfer To CO":
                        filename = "CD";
                        vouname = "Cash Deposit";
                        dsledgname = "Cash Collection Account";
                        break;
                    case "Remittance-Receipt":
                        filename = "RR";
                        break;
                    case "Remittance-Payment":
                        filename = "RP";
                        break;
                    case "ALL":
                        filename = "All Vouchers";
                        strvtype = "AL";
                        break;
                }
                countno = 0;
                if (ddl_voucher.Text == "Receipt - Bank")
                {

                }

                voutype = ddl_voucher.Text;

                ddlref = ddl_reference.Text;
                strpart = "";
                Str_XML += "<TALLYMESSAGE xmlns:UDF='TallyUDF'>" + System.Environment.NewLine;
                Str_XML += getdtlsxml();
                blrTDS = false;


                DataTable dt = new DataTable();
                DateTime dtdate = logobj.GetDate();
                //string fromdate = "27/11/2018";
                //DateTime dtdate = Convert.ToDateTime(Utility.fn_ConvertDate(fromdate));

                dt = obj_da_ledger.GetAllVouchersCount(vouyear, branchid, dtdate, empid);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int vouno = Convert.ToInt32(dt.Rows[i][0].ToString());
                        string voutypessss = dt.Rows[i][2].ToString();
                        blrTDS = false;
                        if (voutypessss == "PaymentAdvises" || voutypessss == "Credit Note - Operations" || voutypessss == "Purchase Invoice")
                        {
                            if (Invobj.CheckTDSApplyORNot("P", vouno, vouyear, branchid) != 0)
                            {
                                blrTDS = true;
                            }
                        }
                        else if (voutypessss == "Payment Advise - Admin" || voutypessss == "Admin Purchase Invoice")
                        {
                            if (Invobj.CheckTDSApplyORNot("S", vouno, vouyear, branchid) != 0)
                            {
                                blrTDS = true;
                            }
                        }
                        else if (voutypessss == "Credit Note - Others")
                        {
                            if (Invobj.CheckTDSApplyORNot("E", vouno, vouyear, branchid) != 0)
                            {
                                blrTDS = true;
                            }
                        }
                        else if (voutypessss == "Invoices" || voutypessss == "OSSI" || voutypessss == "OSPI" || voutypessss == "Debit Note - Others" || voutypessss == "PaymentAdvises" || voutypessss == "Admin Sales Invoice")
                        {
                            blrTDS = true;
                        }
                        blr = false;
                        if (blrTDS == true)
                        {
                            getvoutypeall(vouno, voutypessss);
                            if (blr == true)
                            {
                                switch (voutype)
                                {
                                    case "Invoices":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(vouno);
                                        Str_XML += Part3(vouno);
                                        Str_XML += Part5(vouno);
                                        break;
                                    case "Admin Sales Invoice":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(vouno);
                                        Str_XML += Part3(vouno);
                                        Str_XML += Part5(vouno);
                                        break;
                                    case "Purchase Invoice": //"PaymentAdvises":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(vouno);
                                        Str_XML += Part3(vouno);
                                        Str_XML += Part5(vouno);
                                        Str_XML += Part6();
                                        break;
                                    case "Payment Advise - Admin":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(vouno);
                                        Str_XML += Part3(vouno);
                                        Str_XML += Part5(vouno);
                                        Str_XML += Part6();
                                        break;
                                    case "OSSI":
                                        Str_XML += OSDCNPart1();
                                        Str_XML += Part2();
                                        Str_XML += OSDCNPart2();
                                        Str_XML += OSDCNPart3();
                                        Str_XML += Part5(vouno);
                                        Str_XML += OSDCNPart4();

                                        //Str_XML += OSDNFAJV(vouno);
                                        break;
                                    case "OSPI":
                                        Str_XML += OSDCNPart1();
                                        Str_XML += Str_XML += Part2();
                                        Str_XML += OSDCNPart3();
                                        Str_XML += OSDCNPart2();
                                        Str_XML += Part5(vouno);
                                        Str_XML += OSDCNPart4();
                                        //Str_XML +=OSCNFAJV(vouno);
                                        break;
                                    case "Debit Note - Others":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(vouno);
                                        Str_XML += Part3(vouno);
                                        Str_XML += Part5(vouno);
                                        //Str_XML += DNFAJV(vouno);
                                        break;
                                    case "Credit Note - Others":
                                        Str_XML += Part1();
                                        Str_XML += Part2();
                                        Str_XML += Part4(vouno);
                                        Str_XML += Part3(vouno);
                                        Str_XML += Part5(vouno);
                                        Str_XML += Part6();
                                        //Str_XML +=CNFAJV(vouno);
                                        break;

                                    case "Receipt - Bank":
                                        break;
                                    case "Remittance-Receipt":
                                        break;
                                    case "Remittance-Payment":
                                        break;
                                }
                                Invobj.UpdVouTally(vouno, branchid, vouyear, voutypessss, empid);
                                logobj.InsLogDetail(empid, 161, 1, branchid, vouno + voutypessss);
                            }
                        }

                    }

                }


                Str_XML += "</TALLYMESSAGE>";


                Response.Clear();
                Response.AddHeader("Content-Disposition", "Attachment;Filename= AllVouchers.XML");
                Response.Buffer = true;
                Response.Charset = "UTF-8";
                Response.ContentType = "text/xml";
                Response.Write(Str_XML);


                Response.End();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void getvoutypeall(int vouno, string voutypesssss)
        {
            try
            {
                DateTime vdate;
                PATdsAmt = 0;
                totamountWOST = 0;
                totamountST = 0;
                totalamount = 0;
                reference = "";
                voutype = voutypesssss;
                string curr = "";
                //Deleted = "N";
                portid = HREmpobj.GetBranchId(Session["LoginBranchName"].ToString());
                Dt = MBObj.RetrieveMasterBranchDetails(divisionid, portid, branchid);
                if (Dt.Rows.Count > 0)
                {
                    StrbrnchbnkAccno = Dt.Rows[0]["acnos"].ToString();
                    strbrnchbnkname = "CO-Control AC";
                }



                switch (voutypesssss)
                {
                    case "Invoices":
                        filename = "Inv";
                        ledgerexpinc = "Income";
                        Dt = Invobj.ShowTallyDt(vouno, "Invoice", vouyear, branchid);
                        totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "Invoice", branchid, vouyear), 2);
                        totalamount = Math.Round((Invobj.GetIPDNAmount(vouno, "Invoice", branchid, vouyear)) * -1, 2);
                        totamountST = Math.Round(-(totalamount + totamountWOST), 2);
                        if (Dt.Rows.Count > 0)
                        {
                            blr = true;
                            strtrantype = Dt.Rows[0]["trantype"].ToString();
                            if (strtrantype == "FE"|| strtrantype == "OE")
                            {
                                ledgername = "Ocean Forwarding Exports";
                                //str_VouTypeINCEXP = "-SEA";
                            }
                            else if (strtrantype == "FI"|| strtrantype == "OI")
                            {
                                ledgername = "Ocean Forwarding Imports";
                                // str_VouTypeINCEXP = "-SEA";
                            }
                            else if (strtrantype == "AE")
                            {
                                ledgername = "Air Exports";
                                //  str_VouTypeINCEXP = "-AIR";
                            }
                            else if (strtrantype == "AI")
                            {
                                ledgername = "Air Imports";
                                //  str_VouTypeINCEXP = "-AIR";
                            }
                            else if (strtrantype == "CH")
                            {
                                ledgername = "CHA";
                            }
                            else if (strtrantype == "BT")
                            {
                                ledgername = "Bonded Trucking";
                            }

                            else if (strtrantype == "NI")
                            {
                                ledgername = "Agency Imports";
                                //  str_VouTypeINCEXP = "-SEA";
                            }
                            else if (strtrantype == "NE")
                            {
                                ledgername = "Agency Exports";
                                // str_VouTypeINCEXP = "-AIR";
                            }


                            vdate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                            Dt_voudate = vdate;
                            voudate = string.Format("{0:yyyyMMdd}", vdate);
                            string pcode;
                            pcode = OSDCNObj.GetPortCode(branchid);


                            //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                            partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                            ledgernameexin = ledgername;//+ " - " + ledgerexpinc;
                            jobprefix = Dt.Rows[0]["jobno"].ToString();
                            if (jobprefix.Length > 0 && jobprefix.Length < 2)
                            {
                                numformat = "00";
                            }
                            else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                            {
                                numformat = "0";
                            }
                            else
                            {
                                numformat = "";
                            }

                            jobno = Dt.Rows[0]["jobno"].ToString();


                            blno = Dt.Rows[0]["blno"].ToString();

                            str_Voutrantype = strtrantype.ToString();//.Replace("NE", "EX").Replace("NI", "IM")
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            else
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;


                            if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                            {
                                vounum = "0000";
                            }
                            else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                            {
                                vounum = "000";
                            }
                            else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                            {
                                vounum = "00";
                            }
                            else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                            {
                                vounum = "0";
                            }
                            else
                            {
                                vounum = "";
                            }

                            if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                            {
                                vounoyear = hid_portcode.Value + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            }
                            else
                            {
                                if( (countryid == 1102)||(countryid == 102))
                                {
                                    // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                                else
                                {
                                    //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "IN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                            }

                            GetNarration(vouno, blno, "I", vouyear);
                            GetReference(vouno, "Invoice", vouyear);


                        }
                        break;
                    case "Admin Sales Invoice":
                        filename = "DNAdmin";
                        ledgerexpinc = "Income";
                        Dt = Invobj.ShowTallyDt(vouno, "DN-Admin", vouyear, branchid);
                        totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "DN-Admin", branchid, vouyear), 2);
                        totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "DN-Admin", branchid, vouyear) * -1, 2);
                        totamountST = Math.Round(-(totalamount + totamountWOST), 2);
                        if (Dt.Rows.Count > 0)
                        {
                            blr = true;
                            strtrantype = "X";
                            ledgername = "Admin Sales Invoice";
                            vdate = Convert.ToDateTime(Dt.Rows[0]["dndate"].ToString());
                            Dt_voudate = vdate;
                            voudate = string.Format("{0:yyyyMMdd}", vdate);
                            string pcode;
                            pcode = OSDCNObj.GetPortCode(branchid);
                            //vounoyear = pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                            partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                            blno = Dt.Rows[0]["refno"].ToString();
                            jobno = Dt.Rows[0]["jobno"].ToString();
                            jobprefix = Dt.Rows[0]["jobno"].ToString();
                            if (jobprefix.Length > 0 && jobprefix.Length < 2)
                            {
                                numformat = "00";
                            }
                            else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                            {
                                numformat = "0";
                            }
                            else
                            {
                                numformat = "";
                            }
                            str_Voutrantype = strtrantype.ToString();
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            else
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;


                            if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                            {
                                vounum = "0000";
                            }
                            else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                            {
                                vounum = "000";
                            }
                            else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                            {
                                vounum = "00";
                            }
                            else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                            {
                                vounum = "0";
                            }
                            else
                            {
                                vounum = "";
                            }

                            if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                            {
                                vounoyear = hid_portcode.Value + "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            }
                            else
                            {
                                if( (countryid == 1102)||(countryid == 102))
                                {
                                    // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                                else
                                {
                                    //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "AD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                            }
                            GetNarration(vouno, blno, "DN-Admin", vouyear);
                            GetReference(vouno, "Admin Sales Invoice", vouyear);
                        }
                        break;
                    case "Purchase Invoice": //"PaymentAdvises":
                        ledgerexpinc = "Expenses";
                        filename = "PI";
                        Dt = Invobj.ShowTallyDt(vouno, "PaymentAdvise", vouyear, branchid);
                        totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "PaymentAdvise", branchid, vouyear) * -1, 2);
                        totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "PaymentAdvise", branchid, vouyear), 2);
                        totamountST = Math.Round((totalamount + totamountWOST) * -1, 2);
                        if (Dt.Rows.Count > 0)
                        {
                            blr = true;
                            strtrantype = Dt.Rows[0]["trantype"].ToString();
                            if (strtrantype == "FE"|| strtrantype == "OE")
                            {
                                ledgername = "Ocean Forwarding Exports";
                            }
                            else if (strtrantype == "FI"|| strtrantype == "OI")
                            {
                                ledgername = "Ocean Forwarding Imports";
                            }
                            else if (strtrantype == "AE")
                            {
                                ledgername = "Air Exports";
                            }
                            else if (strtrantype == "AI")
                            {
                                ledgername = "Air Imports";
                            }
                            else if (strtrantype == "CH")
                            {
                                ledgername = "CHA";
                            }
                            else if (strtrantype == "BT")
                            {
                                ledgername = "Bonded Trucking";
                            }
                            else if (strtrantype == "NI")
                            {
                                ledgername = "Agency Imports";
                                //  str_VouTypeINCEXP = "-SEA";
                            }
                            else if (strtrantype == "NE")
                            {
                                ledgername = "Agency Exports";
                                // str_VouTypeINCEXP = "-AIR";
                            }

                            vdate = Convert.ToDateTime(Dt.Rows[0]["padate"].ToString());
                            Dt_voudate = vdate;
                            voudate = string.Format("{0:yyyyMMdd}", vdate);
                            string pcode;
                            pcode = OSDCNObj.GetPortCode(branchid);
                            //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                            partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                            PACustID = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                            DtRece = TDSObj.GetTDSDtlsForCustomer(PACustID);
                            CustTdsType = "";
                            if (DtRece.Rows.Count > 0)
                            {
                                CustTdsType = DtRece.Rows[0]["tdsdesc"].ToString();
                            }
                            PATdsAmt = 0;
                            PATdsAmt = Math.Round(Invobj.GetPATDSAmt(vouno, "P", PACustID, branchid, Convert.ToInt32(txt_year.Text)), 2);
                            ledgernameexin = ledgername; // +" - " + ledgerexpinc;
                            jobno = Dt.Rows[0]["jobno"].ToString();
                            vendorrefno = Dt.Rows[0]["vendorrefno"].ToString();
                            blno = Dt.Rows[0]["blno"].ToString();
                            jobprefix = Dt.Rows[0]["jobno"].ToString();
                            if (jobprefix.Length > 0 && jobprefix.Length < 2)
                            {
                                numformat = "00";
                            }
                            else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                            {
                                numformat = "0";
                            }
                            else
                            {
                                numformat = "";
                            }
                            str_Voutrantype = strtrantype.ToString();
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            else
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;


                            if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                            {
                                vounum = "0000";
                            }
                            else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                            {
                                vounum = "000";
                            }
                            else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                            {
                                vounum = "00";
                            }
                            else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                            {
                                vounum = "0";
                            }
                            else
                            {
                                vounum = "";
                            }

                            if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                            {
                                vounoyear = hid_portcode.Value + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            }
                            else
                            {
                                if( (countryid == 1102)||(countryid == 102))
                                {
                                    // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                                else
                                {
                                    //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "PA" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                            }
                            GetNarration(vouno, blno, "PaymentAdvise", vouyear);
                            GetReference(vouno, "PaymentAdvise", vouyear);


                        }
                        break;
                    case "Payment Advise - Admin":
                        ledgerexpinc = "Expenses";
                        filename = "PAAdmin";
                        Dt = Invobj.ShowTallyDt(vouno, "PA-Admin", vouyear, branchid);
                        totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "PA-Admin", branchid, vouyear) * -1, 2);
                        totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "PA-Admin", branchid, vouyear), 2);
                        totamountST = Math.Round((totalamount + totamountWOST) * -1, 2);
                        if (Dt.Rows.Count > 0)
                        {
                            blr = true;
                            strtrantype = "S";
                            ledgername = "Payment Advise - Admin";
                            vdate = Convert.ToDateTime(Dt.Rows[0]["cndate"].ToString());
                            Dt_voudate = vdate;
                            voudate = string.Format("{0:yyyyMMdd}", vdate);
                            string pcode;
                            pcode = OSDCNObj.GetPortCode(branchid);
                            //vounoyear = pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                            partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                            PACustID = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                            DtRece = TDSObj.GetTDSDtlsForCustomer(PACustID);
                            CustTdsType = "";
                            if (DtRece.Rows.Count > 0)
                            {
                                CustTdsType = DtRece.Rows[0]["tdsdesc"].ToString();
                            }
                            PATdsAmt = 0;
                            PATdsAmt = Math.Round(Invobj.GetPATDSAmt(vouno, "S", PACustID, branchid, Convert.ToInt32(txt_year.Text)), 2);
                            blno = Dt.Rows[0]["refno"].ToString();
                            jobno = Dt.Rows[0]["jobno"].ToString();


                            jobprefix = Dt.Rows[0]["jobno"].ToString();
                            if (jobprefix.Length > 0 && jobprefix.Length < 2)
                            {
                                numformat = "00";
                            }
                            else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                            {
                                numformat = "0";
                            }
                            else
                            {
                                numformat = "";
                            }

                            str_Voutrantype = strtrantype.ToString();
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            else
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                            if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                            {
                                vounum = "0000";
                            }
                            else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                            {
                                vounum = "000";
                            }
                            else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                            {
                                vounum = "00";
                            }
                            else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                            {
                                vounum = "0";
                            }
                            else
                            {
                                vounum = "";
                            }

                            if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                            {
                                vounoyear = hid_portcode.Value + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            }
                            else
                            {
                                if( (countryid == 1102)||(countryid == 102))
                                {
                                    // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                                else
                                {
                                    //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "AC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                            }
                            GetNarration(vouno, blno, "PA-Admin", vouyear);
                            GetReference(vouno, "Payment Advise - Admin", vouyear);
                        }
                        break;

                    case "OSSI":
                        vouname = "Debit Note";
                        ledgerexpinc = "Income";
                        Dt = Invobj.ShowTallyDt(vouno, "OSSI", vouyear, branchid);
                        if (Dt.Rows.Count > 0)
                        {
                            blr = true;
                            dcjobno = Convert.ToInt32(Dt.Rows[0][3].ToString());
                            jobprefix = Dt.Rows[0][3].ToString();
                            if (jobprefix.Length > 0 && jobprefix.Length < 2)
                            {
                                numformat = "00";
                            }
                            else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                            {
                                numformat = "0";
                            }
                            else
                            {
                                numformat = "";
                            }
                            jobno = dcjobno.ToString();
                            dcdate = Convert.ToDateTime(Dt.Rows[0][1].ToString());
                            Dt_voudate = dcdate;
                            dcdndate = string.Format("{0:yyyyMMdd}", dcdate);
                            voudate = dcdndate;
                            dctrantype = Dt.Rows[0][2].ToString();
                            //if(dctrantype =="FE")
                            //{
                            //    ledgername = "Ocean Exports";
                            //}
                            //else if (dctrantype == "FI"|| dctrantype == "OI")
                            //{
                            //    ledgername = "Ocean Imports";
                            //}
                            //else if (dctrantype == "AE")
                            //{
                            //    ledgername = "Air Exports";
                            //}
                            //else if (dctrantype == "AI")
                            //{
                            //    ledgername = "Air Imports";
                            //}
                            //else if (dctrantype == "CH")
                            //{
                            //    ledgername = "CHA";
                            //}
                            //else if (dctrantype == "BT")
                            //{
                            //    ledgername = "Bonded Trucking";
                            //}
                            ledgername = Fn_GetTrantype(dctrantype);
                            strtrantype = dctrantype;
                            dccustomerid = Convert.ToInt32(Dt.Rows[0][4].ToString());
                            dccustomername = (Custobj.GetLedgerName(dccustomerid)).Trim();
                            partyledger = dccustomername;
                            dcamount = Math.Round(Convert.ToDouble((Dt.Rows[0][6].ToString())), 2);//, TriState.True, TriState.True, TriState.True)
                            dcexrate = Math.Round(Convert.ToDouble(Dt.Rows[0][7].ToString()), 2);//, TriState.True, TriState.True, TriState.True)
                            curr = Dt.Rows[0][8].ToString();
                            string pcode;
                            pcode = OSDCNObj.GetPortCode(branchid);
                            JVpcode = pcode;
                            double am;
                            am = dcamount * dcexrate;
                            am = Math.Round(am, 2);
                            dcvouno = dctrantype + "/" + pcode + "/" + vouno + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                            //if(curr == "USD")
                            //{
                            //    curr = "$";
                            //}
                            dctotal = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                            dctotalamount = "" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                            ledgernameexin = ledgername;// +" - " + ledgerexpinc;
                            dcnamount = am;
                            Dt = DCobj.GetDCAdviseWBranch(dcjobno, dctrantype, "DebitAdvise", branchid, vouno, vouyear);
                            if (Dt.Rows.Count > 0)
                            {
                                blno = Dt.Rows[0]["blno"].ToString();
                            }
                            GetNarration(vouno, blno, "D", vouyear);


                            str_Voutrantype = strtrantype.ToString();
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            else
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                            if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                            {
                                vounum = "0000";
                            }
                            else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                            {
                                vounum = "000";
                            }
                            else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                            {
                                vounum = "00";
                            }
                            else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                            {
                                vounum = "0";
                            }
                            else
                            {
                                vounum = "";
                            }

                            if (dcdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                            {
                                vounoyear = hid_portcode.Value + "OD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            }
                            else
                            {
                                if( (countryid == 1102)||(countryid == 102))
                                {
                                    // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "OD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                                else
                                {
                                    //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "OD" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                            }
                            dcvouno = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                            if (ddl_reference.Text == "Voucher No")
                            {
                                GetReference(vouno, "OSSI", vouyear);
                            }
                            else
                            {
                                GetReference(dcjobno, "OSSI", vouyear);
                            }
                        }
                        break;
                    case "OSPI":
                        vouname = "Credit Note";
                        ledgerexpinc = "Expenses";
                        Dt = Invobj.ShowTallyDt(vouno, "OSPI", vouyear, branchid);
                        if (Dt.Rows.Count > 0)
                        {
                            blr = true;
                            dcjobno = Convert.ToInt32(Dt.Rows[0][3].ToString());
                            jobprefix = Dt.Rows[0][3].ToString();
                            if (jobprefix.Length > 0 && jobprefix.Length < 2)
                            {
                                numformat = "00";
                            }
                            else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                            {
                                numformat = "0";
                            }
                            else
                            {
                                numformat = "";
                            }
                            jobno = dcjobno.ToString();
                            dcdate = Convert.ToDateTime(Dt.Rows[0][1].ToString());
                            Dt_voudate = dcdate;
                            dcdndate = string.Format("{0:yyyyMMdd}", dcdate);
                            voudate = dcdndate;
                            dctrantype = Dt.Rows[0][2].ToString();
                            ledgername = Fn_GetTrantype(dctrantype);
                            strtrantype = dctrantype;
                            dccustomerid = Convert.ToInt32(Dt.Rows[0][4].ToString());
                            dccustomername = (Custobj.GetLedgerName(dccustomerid)).Trim();
                            partyledger = dccustomername;
                            dcamount = Math.Round(Convert.ToDouble((Dt.Rows[0][6].ToString())), 2);//, TriState.True, TriState.True, TriState.True)
                            dcexrate = Math.Round(Convert.ToDouble(Dt.Rows[0][7].ToString()), 2);//, TriState.True, TriState.True, TriState.True)
                            curr = Dt.Rows[0][8].ToString();
                            string pcode;
                            pcode = OSDCNObj.GetPortCode(branchid);
                            JVpcode = pcode;
                            dcvouno = dctrantype + "/" + pcode + "/" + vouno + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                            double am;
                            am = dcamount * dcexrate;
                            am = Math.Round(am, 2);
                            dctotal = curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                            dctotalamount = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                            ledgernameexin = ledgername;// +" - " + ledgerexpinc;
                            dcnamount = am * -1;
                            Dt = DCobj.GetDCAdviseWBranch(dcjobno, dctrantype, "", branchid, vouno, vouyear);
                            if (Dt.Rows.Count > 0)
                            {
                                blno = Dt.Rows[0]["blno"].ToString();
                            }
                            GetNarration(vouno, blno, "C", vouyear);

                            str_Voutrantype = strtrantype.ToString();
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            else
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                            if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                            {
                                vounum = "0000";
                            }
                            else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                            {
                                vounum = "000";
                            }
                            else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                            {
                                vounum = "00";
                            }
                            else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                            {
                                vounum = "0";
                            }
                            else
                            {
                                vounum = "";
                            }

                            if (dcdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                            {
                                vounoyear = hid_portcode.Value + "OC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            }
                            else
                            {
                                if( (countryid == 1102)||(countryid == 102))
                                {
                                    // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "OC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                                else
                                {
                                    //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "OC" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                            }
                            dcvouno = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                            GetReference(dcjobno, "OSPI", vouyear);
                        }
                        break;
                    case "Debit Note - Others":
                        vouname = voutype;
                        filename = "DN";
                        Dt = Invobj.ShowTallyDt(vouno, "DNHead", vouyear, branchid);
                        totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "DNHead", branchid, vouyear), 2);
                        totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "DNHead", branchid, vouyear) * -1, 2);
                        if ((totalamount + totamountWOST) == 0)
                        {
                            totamountST = Math.Round(-(totalamount + totamountWOST), 0);
                        }
                        else
                        {
                            totamountST = Math.Round(-(totalamount + totamountWOST), 2);
                        }

                        if (Dt.Rows.Count > 0)
                        {
                            blr = true;
                            strtrantype = Dt.Rows[0]["trantype"].ToString();
                            ledgername = Fn_GetTrantype(strtrantype);
                            pcode = OSDCNObj.GetPortCode(branchid);
                            JVpcode = pcode;
                            vdate = Convert.ToDateTime(Dt.Rows[0]["dndate"].ToString());
                            Dt_voudate = vdate;
                            voudate = string.Format("{0:yyyyMMdd}", vdate);
                            //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                            JVDNCustomerid = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                            custtype = "";
                            custtype = Custobj.GetCustomerType(Convert.ToInt32(Dt.Rows[0]["customerid"]));
                            if (custtype == "P")
                            {
                                Dt1 = Invobj.GetOtherDCNAmount(vouno, "DNHead", branchid, vouyear);
                                if (Dt1.Rows.Count > 0)
                                {
                                    dcamount = Math.Round(Convert.ToDouble(Dt1.Rows[0][2].ToString()), 2);//, TriState.True, TriState.True, TriState.True)
                                    dcexrate = Math.Round(Convert.ToDouble(Dt1.Rows[0][1].ToString()), 2);//, TriState.True, TriState.True, TriState.True)
                                    curr = Dt1.Rows[0][0].ToString();
                                }
                                double am;
                                am = dcamount * dcexrate;
                                am = Math.Round(am, 2);
                                dctotal = curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                dctotalamount = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                                dcnamount = am;

                            }
                            partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                            ledgernameexin = ledgername;// +" - " + ledgerexpinc;
                            jobno = Dt.Rows[0]["jobno"].ToString();//strtrantype + "-" + 
                            dcvouno = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                            dcjobno = Convert.ToInt32(Dt.Rows[0]["jobno"].ToString());
                            jobprefix = Dt.Rows[0]["jobno"].ToString();
                            if (jobprefix.Length > 0 && jobprefix.Length < 2)
                            {
                                numformat = "00";
                            }
                            else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                            {
                                numformat = "0";
                            }
                            else
                            {
                                numformat = "";
                            }
                            dctrantype = strtrantype;
                            blno = Dt.Rows[0]["blno"].ToString();


                            str_Voutrantype = strtrantype.ToString();
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            else
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;


                            if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                            {
                                vounum = "0000";
                            }
                            else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                            {
                                vounum = "000";
                            }
                            else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                            {
                                vounum = "00";
                            }
                            else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                            {
                                vounum = "0";
                            }
                            else
                            {
                                vounum = "";
                            }

                            if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                            {
                                vounoyear = hid_portcode.Value + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            }
                            else
                            {
                                if( (countryid == 1102)||(countryid == 102))
                                {
                                    // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                                else
                                {
                                    //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "DN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                            }
                            GetNarration(vouno, blno, "V", vouyear);
                            GetReference(vouno, "DNHead", vouyear);
                        }
                        break;
                    case "Credit Note - Others":
                        vouname = voutype;
                        filename = "CN";
                        Dt = Invobj.ShowTallyDt(vouno, "CNHead", vouyear, branchid);
                        totamountWOST = Math.Round(Invobj.GetIPDNAmountWOST(vouno, "CNHead", branchid, vouyear) * -1, 2);
                        totalamount = Math.Round(Invobj.GetIPDNAmount(vouno, "CNHead", branchid, vouyear), 2);
                        if ((totalamount + totamountWOST) == 0)
                        {
                            totamountST = Math.Round((totalamount + totamountWOST) * -1, 2);
                        }
                        else if ((totalamount + totamountWOST) < 0)
                        {
                            totamountST = 0;
                        }
                        else
                        {
                            totamountST = Math.Round((totalamount + totamountWOST) * -1, 2);
                        }
                        if (Dt.Rows.Count > 0)
                        {
                            blr = true;
                            strtrantype = Dt.Rows[0]["trantype"].ToString();
                            ledgername = Fn_GetTrantype(strtrantype);
                            pcode = OSDCNObj.GetPortCode(branchid);
                            JVpcode = pcode;
                            vdate = Convert.ToDateTime(Dt.Rows[0]["cndate"].ToString());
                            Dt_voudate = vdate;
                            voudate = string.Format("{0:yyyyMMdd}", vdate);
                            //vounoyear = strtrantype + " / " + pcode + " / " + vouno + " / " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                            JVDNCustomerid = Convert.ToInt32(Dt.Rows[0]["customerid"].ToString());
                            DtRece = TDSObj.GetTDSDtlsForCustomer(JVDNCustomerid);
                            CustTdsType = "";
                            if (DtRece.Rows.Count > 0)
                            {
                                CustTdsType = DtRece.Rows[0]["tdsdesc"].ToString();
                            }
                            PATdsAmt = 0;
                            PATdsAmt = Math.Round(Invobj.GetPATDSAmt(vouno, "E", JVDNCustomerid, branchid, Convert.ToInt32(txt_year.Text)), 2);
                            custtype = Custobj.GetCustomerType(Convert.ToInt32(Dt.Rows[0]["customerid"]));
                            vendorrefno = Dt.Rows[0]["vendorrefno"].ToString();
                            if (custtype == "P")
                            {
                                Dt1 = Invobj.GetOtherDCNAmount(vouno, "CNHead", branchid, vouyear);
                                if (Dt1.Rows.Count > 0)
                                {
                                    dcamount = Math.Round(Convert.ToDouble(Dt1.Rows[0][2].ToString()), 2);
                                    dcexrate = Math.Round(Convert.ToDouble(Dt1.Rows[0][1].ToString()), 2);
                                    curr = Dt1.Rows[0][0].ToString();
                                }
                                double am;
                                am = dcamount * dcexrate;
                                am = Math.Round(am, 2);
                                dctotal = curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = " + Session["Basecurr"].ToString() + " " + am;
                                dctotalamount = "-" + curr + " " + dcamount + " @ " + Session["Basecurr"].ToString() + " " + dcexrate + "/" + curr + " = -" + Session["Basecurr"].ToString() + " " + am;
                                dcnamount = Math.Round(am * -1);
                            }
                            partyledger = (Custobj.GetLedgerName(Convert.ToInt32(Dt.Rows[0]["customerid"].ToString()))).Trim();
                            ledgernameexin = ledgername;// +" - " + ledgerexpinc;
                            jobno = Dt.Rows[0]["jobno"].ToString(); //strtrantype + "-" + 
                            dcvouno = vounoyear.Replace("&", " &amp; ").Replace("&amp; amp;", "&amp;").Replace("&amp; amp;", "&amp;").Replace("'", "&#39;");
                            dcjobno = Convert.ToInt32(Dt.Rows[0]["jobno"].ToString());
                            dctrantype = strtrantype;
                            blno = Dt.Rows[0]["blno"].ToString();

                            jobprefix = Dt.Rows[0]["jobno"].ToString();
                            if (jobprefix.Length > 0 && jobprefix.Length < 2)
                            {
                                numformat = "00";
                            }
                            else if (jobprefix.Length > 1 && jobprefix.Length < 3)
                            {
                                numformat = "0";
                            }
                            else
                            {
                                numformat = "";
                            }
                            str_Voutrantype = strtrantype.ToString();
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            else
                            {
                                str_Voujobno = pcode.Substring(4, 3) + "-" + str_Voutrantype + "-" + jobno;
                            }
                            //str_Voujobno = str_Voutrantype + "/" + pcode + "/" + jobno;

                            if (vouno.ToString().Length > 0 && vouno.ToString().Length < 2)
                            {
                                vounum = "0000";
                            }
                            else if (vouno.ToString().Length > 1 && vouno.ToString().Length < 3)
                            {
                                vounum = "000";
                            }
                            else if (vouno.ToString().Length > 2 && vouno.ToString().Length < 4)
                            {
                                vounum = "00";
                            }
                            else if (vouno.ToString().Length > 3 && vouno.ToString().Length < 5)
                            {
                                vounum = "0";
                            }
                            else
                            {
                                vounum = "";
                            }

                            if (vdate >= Convert.ToDateTime("07/01/2017") && (countryid == 1102 || countryid == 102))
                            {
                                vounoyear = hid_portcode.Value + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                            }
                            else
                            {
                                if( (countryid == 1102)||(countryid == 102))
                                {
                                    // vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2) + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                                else
                                {
                                    //  vounoyear = str_Voutrantype + "/" + pcode + "/" + txt_year.Text + "/" + vouno;
                                    vounoyear = hid_portcode.Value + "CN" + txt_year.Text.Substring(2, 2) + lbl_toyear.Text.Substring(3, 2) + vounum + vouno;
                                }
                            }
                            GetNarration(vouno, blno, "E", vouyear);
                            GetReference(vouno, "CNHead", vouyear);
                        }
                        break;
                    case "Receipt - Bank":
                        classname = "Bank";
                        RVouname = "BANKRECEIPTS";
                        mode = "B";
                        //Dt = RcptObj.GetRecptSlipDtls(vouno, branchid, Convert.ToChar(mode), Convert.ToInt32(txt_year.Text));
                        //if (Dt.Rows.Count > 0)
                        //{
                        //    //StrbrnchbnkAccno = Dt.Rows[0]["acnos"].ToString();
                        //    strbrnchbnkname = Dt.Rows[0]["bankname"].ToString();
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        GetBankReceipts(vouno);
                        break;
                    case "Receipt - Cash":
                        classname = "Cash";
                        RVouname = "Cash Receipt";
                        mode = "C";
                        GetBankReceipts(vouno);
                        break;
                    case "Bank Payment":
                        classname = "Bank"; ;
                        RVouname = "Bank Payment";
                        mode = "B";
                        GetBankPayments(vouno);
                        break;
                    case "Cash Payment":
                        classname = "Cash";
                        RVouname = "Cash Payment";
                        mode = "C";
                        GetBankPayments(vouno);
                        break;
                    case "Bank Payment - Transfer From CO":
                        classname = "Bank";
                        RVouname = "Bank Payment";
                        mode = "B";
                        GetBankPayments(vouno);
                        break;
                    case "Cash  Payment - Transfer From CO":
                        classname = "Cash";
                        RVouname = "Cash Payment";
                        mode = "C";
                        GetBankPayments(vouno);
                        break;

                    case "Remittance-Payment":
                        classname = "RP"; ;
                        RVouname = "Remittance Payment";
                        mode = "B";
                        GetRemittancePayments(vouno);
                        break;
                    case "Remittance-Receipt":
                        classname = "RP"; ;
                        RVouname = "Remittance Receipt";
                        mode = "B";
                        GetRemittanceReceipt(vouno);
                        break;
                }

                if (partyledger != "")
                {
                    partyledger = partyledger.Replace("&", "&amp;");
                }
            }
            catch (Exception ex)
            {
            }
        }
        private bool Fn_Check()
        {
            Check = true;
            if (ddl_voucher.SelectedItem.Text.Trim().Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('Voucher Cannot be Blank ');", true);
                return Check = false;
            }

            string str_Voucher = ddl_voucher.SelectedItem.Text.ToString();

            if ((str_Voucher == "Bank Deposit - Transfer To CO") || (str_Voucher == "Cash Deposit - Transfer To CO"))
            { }
            else
            {
                if (Convert.ToInt32(txt_from.Text) - Convert.ToInt32(txt_to.Text) >= 100)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Enter Less than 100 Vouchers');", true);
                    return Check = false;
                }
            }
            if (txt_from.Text.ToString().Trim().Length == 0)
            {
                if (str_Voucher == "Bank Deposit - Transfer To CO" || str_Voucher == "Cash Deposit - Transfer To CO")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('slip # cannot be Blank');", true);
                    return Check = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('From Vouno cannot be Blank');", true);
                    return Check = false;
                }
            }

            if (str_Voucher.CompareTo("Bank Deposit - Transfer To CO") == 1 || str_Voucher.CompareTo("Cash Deposit - Transfer To CO") == 1)
            {
                if (txt_to.Text.ToString().Trim().Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('To Vouno cannot be Blank');", true);
                    return Check = false;
                }
                if (txt_year.Text.ToString().Trim().Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('Year Cannot be Blank ');", true);
                    return Check = false;
                }
                int int_From = int.Parse(txt_from.Text);
                int int_To = txt_to.Enabled == false ? 0 : int.Parse(txt_to.Text);
                if ((int_To - int_From) >= 100)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('Enter Less than 100 Vouchers ');", true);
                    return Check = false;
                }
            }

            DataTable obj_dt = new DataTable();
            //DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            if (str_Voucher == "Bank Deposit - Transfer To CO")
            {
                obj_dt = obj_da_Receipt.GetSlipDetails4tally(txt_from.Text, branchid, 'B');
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('Invalid Slip # ');", true);
                    return Check = false;
                }
            }

            if (str_Voucher == "Cash Deposit - Transfer To CO")
            {
                obj_dt = obj_da_Receipt.GetSlipDetails4tally(txt_from.Text, branchid, 'C');
                if (obj_dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('Invalid Slip # ');", true);
                    return Check = false;
                }
            }


            if (int.Parse(txt_year.Text) <= 2010)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TallyEDI", "alertify.alert('You have no Rights to Import Last Financial Year Vochers into Tally');", true);
                return Check = false;
            }
            return Check;
        }

        protected string CreatePRBVTally(int vouno)
        {
            //103 Entry
            string strtally = "";
            if (mode == "B")
            {
                strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + "BPJV" + "' ACTION='CREATE'>" + System.Environment.NewLine;
            }

            else
            {
                strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + RVouname + "' ACTION='CREATE'>" + System.Environment.NewLine;
            }
            //strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + "BPJV" + "' ACTION='CREATE'>" + System.Evironment.NewLine;

            /*strtally = strtally + "<BANKERSDATE.LSIT>" + System.Environment.NewLine;
            strtally = strtally + "<BANKERSDATE></BANKERSDATE>" + System.Environment.NewLine;
            strtally = strtally + "</BANKERSDATE.LSIT>" + System.Environment.NewLine;
            */

            strtally = strtally + "<DATE>" + strRdate + "</DATE>" + System.Environment.NewLine;
            strtally = strtally + "<NARRATION>Ch.No:" + chequeno + "/" + strCHdate + " " + Rbankname + " - " + narration + "  " + System.Environment.NewLine + " Paid To : " + partyname + " - " + vouno + "</NARRATION>" + System.Environment.NewLine;
            if (mode == "B")
            {
                strtally = strtally + "<VOUCHERTYPENAME>" + "BPJV" + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            }
            else
            {
                strtally = strtally + "<VOUCHERTYPENAME>" + RVouname + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
            }
            strtally = strtally + "<VOUCHERNUMBER>" + "BP-" + Rvouno + "</VOUCHERNUMBER>" + System.Environment.NewLine;
            //partyledger = Rbankname;
            //DataAccess.HR.Employee branch = new DataAccess.HR.Employee();
            string Branchname = "CORPORATE";
            int branchid = branch.GetBranchIdNEW(Branchname.ToString().ToUpper());
            if (mode == "B")
            {
                partyledger = "CTC ACCOUNT-" + BrObj.GetShortName(Convert.ToInt32(branchid)).ToUpper();
            }
            else if (mode == "C")
            {
                partyledger = "CASH";
                //partyledger = "PETTY CASH - " + BrObj.GetShortName(Convert.ToInt32(Session["LoginBranchid"])).ToUpper();
            }



            if (Convert.ToInt32(txt_year.Text) == 2018)
            {
                partyledger = partyledger.ToString().Replace("FIL", "AXL");
            }
            strtally = strtally + "<PARTYLEDGERNAME>" + Rbankname + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMISSUETYPE />" + System.Environment.NewLine;
            strtally = strtally + "<CSTFORMRECVTYPE />" + System.Environment.NewLine;
            strtally = strtally + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
            strtally = strtally + "<VCHGSTCLASS />" + System.Environment.NewLine;
            strtally = strtally + "<ENTEREDBY>" + Session["Enteredby"].ToString() + "</ENTEREDBY>" + System.Environment.NewLine;// Vino renamed [05-03-2024]
            strtally = strtally + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
            strtally = strtally + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
            strtally = strtally + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
            strtally = strtally + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
            strtally = strtally + "<EFFECTIVEDATE>" + strRdate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
            strtally = strtally + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
            strtally = strtally + "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
            strtally = strtally + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
            strtally = strtally + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
            strtally = strtally + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
            strtally = strtally + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
            strtally = strtally + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
            strtally = strtally + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
            strtally = strtally + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
            strtally = strtally + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
            strtally = strtally + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
            strtally = strtally + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
            Dt = PymtObj.GetPaymentCust(RID);
            RCAmt1 = 0;
            for (int L = 0; L < Dt.Rows.Count; L++)
            {
                RCustomer = "";
                RCustomer = Dt.Rows[L][0].ToString();
                if (RCustomer != "")
                {
                    RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
                }
                RCAmt = Convert.ToDouble(Dt.Rows[L][1].ToString());
                RCAmt1 = RCAmt1 + Convert.ToDouble(Dt.Rows[L][1].ToString());
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>" + RCustomer + "</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                //if (mode == "B")
                //{
                //    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                //}
                //else if (mode == "C")
                //{
                //    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;

                //}
                if (RCAmt > 0)
                {
                    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                }
                else
                {
                    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                }
                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                strtally = strtally + "<AMOUNT>" + -RCAmt + "</AMOUNT>" + System.Environment.NewLine;
                //if (mode == "B")
                //{
                //    strtally = strtally + "<AMOUNT>" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;
                //}
                //else if (mode == "C")
                //{
                //    strtally = strtally + "<AMOUNT>-" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;
                //}

                Dt1 = RcptObj.GetRecpAgnsInvForTally(RID, 'P', Convert.ToInt32(Dt.Rows[L]["Customer"].ToString()));
                //Dt1 = RcptObj.GetRAInvoiceToShow(RID, 'P');
                for (int m = 0; m < Dt1.Rows.Count; m++)
                {
                    strtally = strtally + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    string RTRANTYPE = "";
                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) != 0)
                    {
                        DtRe = Invobj.ShowTallyDt(Convert.ToInt32(Dt1.Rows[m][2].ToString()), "PA", Convert.ToInt32(Dt1.Rows[m][7].ToString()), branchid);
                        if (DtRe.Rows.Count > 0)
                        {
                            RTRANTYPE = DtRe.Rows[0]["trantype"].ToString();
                        }
                    }
                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) == 0)
                    {
                        strtally = strtally + "<NAME>On Account</NAME>" + System.Environment.NewLine;
                        strtally = strtally + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                    }
                    else
                    {
                        //strtally = strtally + "<NAME>" + hid_portcode.Value + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("I", "IN").Replace("P", "PA").Replace("V", "DN").Replace("E", "CN").Replace("S", "ACN").Replace("X", "ADN").Replace("OI", "OB IN").Replace("OP", "OB PA").Replace("OV", "OB DN").Replace("OE", "OB CN").Replace("OS", "OB ACN").Replace("OX", "OB ADN") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                      //  strtally = strtally + "<NAME>" + Dt1.Rows[m]["vounos"].ToString() + "</NAME>" + System.Environment.NewLine;    -- 03052021 Raj sir inform to changes
                        if (Dt1.Rows[m]["voutype"].ToString() == "P" || Dt1.Rows[m]["voutype"].ToString() == "E" || Dt1.Rows[m]["voutype"].ToString() == "S")
                        {
                            strtally = strtally + "<NAME>" + Dt1.Rows[m]["vendorrefno"].ToString() + "</NAME>" + System.Environment.NewLine;
                        }
                        else
                        {
                            strtally = strtally + "<NAME>" + Dt1.Rows[m]["vounos"].ToString() + "</NAME>" + System.Environment.NewLine;
                        }
                        //strtally = strtally + "<NAME>" + BrObj.GetShortName(Convert.ToInt32(Dt1.Rows[m]["branch"])).ToString().Substring(4, 3) + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("I", "IN").Replace("P", "PA").Replace("V", "DN").Replace("E", "CN").Replace("S", "ACN").Replace("X", "ADN").Replace("OI", "OB IN").Replace("OP", "OB PA").Replace("OV", "OB DN").Replace("OE", "OB CN").Replace("OS", "OB ACN").Replace("OX", "OB ADN") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;

                        strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                    }
                    
                   // strtally = strtally + "<AMOUNT>-" + Convert.ToDouble(Dt1.Rows[m][4]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;


                    if (Dt1.Rows[m][5].ToString().Trim() == "I" || Dt1.Rows[m][5].ToString().Trim() == "B" || Dt1.Rows[m][5].ToString().Trim() == "V" || Dt1.Rows[m][5].ToString().Trim() == "X")
                    {
                        strtally = strtally + "<AMOUNT>" + Convert.ToDouble(Dt1.Rows[m][4]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;
                    }
                    else
                    {
                        strtally = strtally + "<AMOUNT>-" + Convert.ToDouble(Dt1.Rows[m][4]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;
                    }



                    //if (mode == "b")
                    //{
                    //    strtally = strtally + "<amount>-" + convert.todouble(dt1.rows[m][4]).tostring("#0.00") + "</amount>" + system.environment.newline;
                    //}
                    //else if (mode == "c")
                    //{
                    //    strtally = strtally + "<amount>-" + convert.todouble(dt1.rows[m][4]).tostring("#0.00") + "</amount>" + system.environment.newline;
                    //}

                    strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                    //else
                    //{
                    //    strtally = strtally + "<NAME>" + RTRANTYPE + " " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
                    //    strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                    //}
                    //strtally = strtally + "<AMOUNT>-" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                    //strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                }
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            EAmount = 0; Amount = 0; tamt = 0;
            Dt = PymtObj.GetPaymentES(RID);
            if (Dt.Rows.Count > 0)
            {
                EAmount = Convert.ToDouble(Dt.Rows[0][0].ToString());
            }
            DtRe = PymtObj.GetPaymentChrg(RID);
            if (DtRe.Rows.Count > 0)
            {
                Amount = Convert.ToDouble(DtRe.Rows[0][1].ToString());
            }
            tamt = Amount + EAmount;
            for (int i = 0; i < DtRe.Rows.Count; i++)
            {
                Amount = Convert.ToDouble(DtRe.Rows[i][1].ToString());
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                if (DtRe.Rows[i][0].ToString() == "TAX DEDUCTED AT SOURCE PAYBALE")
                {
                    deductedchargename = "TDS Payables F/Y " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                }
                else
                {
                    deductedchargename = DtRe.Rows[i][0].ToString();
                }
                strtally = strtally + "<LEDGERNAME>" + deductedchargename.Replace("&", "&amp;").Replace("'", "&#39;") + "</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;

                if (mode == "B")
                {
                    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                    strtally = strtally + "<AMOUNT>" + -Amount + "</AMOUNT>";
                    /* if (Amount < 0)
                     {
                         strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                         strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                         strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                         strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                         strtally = strtally + "<AMOUNT>" + Amount + "</AMOUNT>";
                     }
                     else
                     {
                         strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                         strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                         strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                         strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                         strtally = strtally + "<AMOUNT>-" + Amount + "</AMOUNT>";
                     }*/
                }
                else if (mode == "C")
                {
                    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                    strtally = strtally + "<AMOUNT>-" + Amount + "</AMOUNT>";

                    //if (Amount > 0)
                    //{
                    //    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    //    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    //    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    //    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                    //    strtally = strtally + "<AMOUNT>" + Amount + "</AMOUNT>";
                    //}
                    //else
                    //{
                    //    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    //    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    //    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    //    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                    //    strtally = strtally + "<AMOUNT>-" + Amount + "</AMOUNT>";
                    //}

                }

                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                //Amount = Convert.ToDouble(DtRe.Rows[0][1].ToString());
            }
            strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            strtally = strtally + "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
            strtally = strtally + "<GSTCLASS/>" + System.Environment.NewLine;
            //if (mode == "B")
            //{
            //    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            //}
            //else if (mode == "C")
            //{
            //    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            //}
            strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
            strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
            strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
            strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
            if (mode == "C")
            {
                if (RCAmt == 0 || tamt == 0)
                {
                    strtally = strtally + "<AMOUNT>" + RRFAmt + "</AMOUNT>";
                }
                else
                {
                    if ((RCAmt - (-tamt)) < 0)
                    {
                        strtally = strtally + "<AMOUNT>-" + (RCAmt - (-tamt)) + "</AMOUNT>";
                    }
                    else
                    {
                        strtally = strtally + "<AMOUNT>" + (RCAmt - (-tamt)) + "</AMOUNT>";
                    }
                }
            }
            else if (mode == "B")
            {
                if (RCAmt == 0 || tamt == 0)
                {
                    strtally = strtally + "<AMOUNT>" + RRFAmt + "</AMOUNT>";
                }
                else
                {
                    strtally = strtally + "<AMOUNT>" + (RCAmt1 - (-tamt)) + "</AMOUNT>";
                }
            }

            //Start Newly added for BANKALLOCATIONS
            strtally = strtally + "<BANKALLOCATIONS.LIST> " + System.Environment.NewLine;
            strtally = strtally + "<DATE>" + strRdate + "</DATE> " + System.Environment.NewLine;
            strtally = strtally + "<INSTRUMENTDATE>" + strCHdate1 + "</INSTRUMENTDATE> " + System.Environment.NewLine;
            strtally = strtally + "<NAME></NAME> " + System.Environment.NewLine;

            if (str_NEFT == "Y")
            {
                strtally = strtally + "<TRANSFERMODE>NEFT</TRANSFERMODE>" + System.Environment.NewLine;
            }
            else
            {
                strtally = strtally + "<TRANSACTIONTYPE>Cheque/DD</TRANSACTIONTYPE> " + System.Environment.NewLine;
            }
            strtally = strtally + "<PAYMENTFAVOURING></PAYMENTFAVOURING> " + System.Environment.NewLine;
            strtally = strtally + " <INSTRUMENTNUMBER>" + chequeno + "</INSTRUMENTNUMBER> " + System.Environment.NewLine;
            strtally = strtally + "<UNIQUEREFERENCENUMBER></UNIQUEREFERENCENUMBER> " + System.Environment.NewLine;
            strtally = strtally + "<PAYMENTMODE>Transacted</PAYMENTMODE>" + System.Environment.NewLine;
            //strtally = strtally + "<AMOUNT>" + (RCAmt - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;

            if (mode == "C")
            {
                if (RCAmt == 0 || tamt == 0)
                {
                    strtally = strtally + "<AMOUNT>" + RRFAmt + "</AMOUNT>" + System.Environment.NewLine;
                }
                else
                {
                    if ((RCAmt - (-tamt)) < 0)
                    {
                        strtally = strtally + "<AMOUNT>-" + (RCAmt - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;
                    }
                    else
                    {
                        strtally = strtally + "<AMOUNT>" + (RCAmt - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;
                    }
                }
            }
            else if (mode == "B")
            {
                if (RCAmt == 0 || tamt == 0)
                {
                    strtally = strtally + "<AMOUNT>" + RRFAmt + "</AMOUNT>" + System.Environment.NewLine;
                }
                else
                {
                    strtally = strtally + "<AMOUNT>" + (RCAmt1 - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;
                }
            }

            strtally = strtally + "</BANKALLOCATIONS.LIST>" + System.Environment.NewLine;

            //End Newly added for BANKALLOCATIONS



            strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;


            DtRe = PymtObj.GetPaymentES(RID);
            if (DtRe.Rows.Count > 0)
            {
                strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                strtally = strtally + "<LEDGERNAME>Round Up</LEDGERNAME>" + System.Environment.NewLine;
                strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                if (Convert.ToDouble(DtRe.Rows[0][0]) > 0)
                {
                    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                }
                else
                {
                    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                }

                strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;

                strtally = strtally + "<AMOUNT>" + -(Convert.ToDouble(DtRe.Rows[0][0])) + "</AMOUNT>";
                strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
            }
            strtally = strtally + "</VOUCHER>" + System.Environment.NewLine;
            Invobj.UpdVouTally(j, branchid, vouyear, ddl_voucher.Text, empid);
            logobj.InsLogDetail(empid, 161, 1, branchid, j + ddl_voucher.Text);
            RCAmt = 0;
            return strtally;

        }


        //protected string CreatePRBVTally(int vouno)
        //{
        //    //103 Entry
        //    string strtally = "";
        //    if (mode == "B")
        //    {
        //        strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + "BPJV" + "' ACTION='CREATE'>" + System.Environment.NewLine;
        //    }

        //    else
        //    {
        //        strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + RVouname + "' ACTION='CREATE'>" + System.Environment.NewLine;
        //    }
        //    //strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + "BPJV" + "' ACTION='CREATE'>" + System.Evironment.NewLine;

        //    /*strtally = strtally + "<BANKERSDATE.LSIT>" + System.Environment.NewLine;
        //    strtally = strtally + "<BANKERSDATE></BANKERSDATE>" + System.Environment.NewLine;
        //    strtally = strtally + "</BANKERSDATE.LSIT>" + System.Environment.NewLine;
        //    */

        //    strtally = strtally + "<DATE>" + strRdate + "</DATE>" + System.Environment.NewLine;
        //    strtally = strtally + "<NARRATION>Ch.No:" + chequeno + "/" + strCHdate + " " + Rbankname + " - " + narration + "  " + System.Environment.NewLine + " Paid To : " + partyname + " - " + vouno + "</NARRATION>" + System.Environment.NewLine;
        //    if (mode == "B")
        //    {
        //        strtally = strtally + "<VOUCHERTYPENAME>" + "BPJV" + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
        //    }
        //    else
        //    {
        //        strtally = strtally + "<VOUCHERTYPENAME>" + RVouname + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
        //    }
        //    strtally = strtally + "<VOUCHERNUMBER>" + Rvouno + "</VOUCHERNUMBER>" + System.Environment.NewLine;
        //    //partyledger = Rbankname;
        //    DataAccess.HR.Employee branch = new DataAccess.HR.Employee();
        //    string Branchname = "CORPORATE";
        //    int branchid = branch.GetBranchIdNEW(Branchname.ToString().ToUpper());
        //    if (mode == "B")
        //    {
        //        partyledger = "CTC ACCOUNT-" + BrObj.GetShortName(Convert.ToInt32(branchid)).ToUpper();
        //    }
        //    else if (mode == "C")
        //    {
        //        partyledger = "PETTY CASH - " + BrObj.GetShortName(Convert.ToInt32(Session["LoginBranchid"])).ToUpper();
        //    }



        //    if (Convert.ToInt32(txt_year.Text) == 2018)
        //    {
        //        partyledger = partyledger.ToString().Replace("FIL", "AXL");
        //    }
        //    strtally = strtally + "<PARTYLEDGERNAME>" + Rbankname + "</PARTYLEDGERNAME>" + System.Environment.NewLine;
        //    strtally = strtally + "<CSTFORMISSUETYPE />" + System.Environment.NewLine;
        //    strtally = strtally + "<CSTFORMRECVTYPE />" + System.Environment.NewLine;
        //    strtally = strtally + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
        //    strtally = strtally + "<VCHGSTCLASS />" + System.Environment.NewLine;
        //    strtally = strtally + "<ENTEREDBY>FA</ENTEREDBY>" + System.Environment.NewLine;
        //    strtally = strtally + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
        //    strtally = strtally + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
        //    strtally = strtally + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
        //    strtally = strtally + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
        //    strtally = strtally + "<EFFECTIVEDATE>" + strRdate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
        //    strtally = strtally + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
        //    strtally = strtally + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
        //    strtally = strtally + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
        //    strtally = strtally + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
        //    strtally = strtally + "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
        //    strtally = strtally + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
        //    strtally = strtally + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
        //    strtally = strtally + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
        //    strtally = strtally + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
        //    strtally = strtally + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
        //    strtally = strtally + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
        //    strtally = strtally + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
        //    strtally = strtally + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
        //    strtally = strtally + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
        //    strtally = strtally + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
        //    Dt = PymtObj.GetPaymentCust(RID);
        //    RCAmt1 = 0;
        //    for (int L = 0; L < Dt.Rows.Count; L++)
        //    {
        //        RCustomer = "";
        //        RCustomer = Dt.Rows[L][0].ToString();
        //        if (RCustomer != "")
        //        {
        //            RCustomer = RCustomer.Replace("&", "&amp;").Replace("'", "&#39;");
        //        }
        //        RCAmt = Convert.ToDouble(Dt.Rows[L][1].ToString());
        //        RCAmt1 = RCAmt1 + Convert.ToDouble(Dt.Rows[L][1].ToString());
        //        strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
        //        strtally = strtally + "<LEDGERNAME>" + RCustomer + "</LEDGERNAME>" + System.Environment.NewLine;
        //        strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
        //        //if (mode == "B")
        //        //{
        //        //    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //        //}
        //        //else if (mode == "C")
        //        //{
        //        //    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;

        //        //}
        //        if (RCAmt > 0)                   // 20032021 changes voucher amount BPJV #719
        //        {
        //            strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //        }
        //        else
        //        {
        //            strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //        }
        //        strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //        strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //        strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
        //        if (RCAmt > 0)
        //        {
        //            strtally = strtally + "<AMOUNT>-" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;   // 20032021 changes voucher amount BPJV #719
        //        }
        //        else
        //        {
        //            strtally = strtally + "<AMOUNT>" + -RCAmt + "</AMOUNT>" + System.Environment.NewLine;
        //        }
        //        //if (mode == "B")
        //        //{
        //        //    strtally = strtally + "<AMOUNT>" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;
        //        //}
        //        //else if (mode == "C")
        //        //{
        //        //    strtally = strtally + "<AMOUNT>-" + RCAmt + "</AMOUNT>" + System.Environment.NewLine;
        //        //}

        //        Dt1 = RcptObj.GetRecpAgnsInvForTally(RID, 'P', Convert.ToInt32(Dt.Rows[L]["Customer"].ToString()));
        //        //Dt1 = RcptObj.GetRAInvoiceToShow(RID, 'P');
        //        for (int m = 0; m < Dt1.Rows.Count; m++)
        //        {
        //            strtally = strtally + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
        //            string RTRANTYPE = "";
        //            if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) != 0)
        //            {
        //                DtRe = Invobj.ShowTallyDt(Convert.ToInt32(Dt1.Rows[m][2].ToString()), "PA", Convert.ToInt32(Dt1.Rows[m][7].ToString()), branchid);
        //                if (DtRe.Rows.Count > 0)
        //                {
        //                    RTRANTYPE = DtRe.Rows[0]["trantype"].ToString();
        //                }
        //            }
        //            if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) == 0)
        //            {
        //                strtally = strtally + "<NAME>On Account</NAME>" + System.Environment.NewLine;
        //                strtally = strtally + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
        //            }
        //            else
        //            {
        //                //strtally = strtally + "<NAME>" + hid_portcode.Value + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("I", "IN").Replace("P", "PA").Replace("V", "DN").Replace("E", "CN").Replace("S", "ACN").Replace("X", "ADN").Replace("OI", "OB IN").Replace("OP", "OB PA").Replace("OV", "OB DN").Replace("OE", "OB CN").Replace("OS", "OB ACN").Replace("OX", "OB ADN") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
        //                strtally = strtally + "<NAME>" + Dt1.Rows[m]["vounos"].ToString() + "</NAME>" + System.Environment.NewLine;

        //                //strtally = strtally + "<NAME>" + BrObj.GetShortName(Convert.ToInt32(Dt1.Rows[m]["branch"])).ToString().Substring(4, 3) + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("I", "IN").Replace("P", "PA").Replace("V", "DN").Replace("E", "CN").Replace("S", "ACN").Replace("X", "ADN").Replace("OI", "OB IN").Replace("OP", "OB PA").Replace("OV", "OB DN").Replace("OE", "OB CN").Replace("OS", "OB ACN").Replace("OX", "OB ADN") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;

        //                strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
        //            }
        //            if (Dt1.Rows[m][5].ToString().Trim() == "I" || Dt1.Rows[m][5].ToString().Trim() == "B" || Dt1.Rows[m][5].ToString().Trim() == "V")
        //            {
        //                strtally = strtally + "<AMOUNT>" + Convert.ToDouble(Dt1.Rows[m][4]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;
        //            }
        //            else
        //            {
        //                strtally = strtally + "<AMOUNT>-" + Convert.ToDouble(Dt1.Rows[m][4]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;
        //            }

        //            //if (mode == "b")
        //            //{
        //            //    strtally = strtally + "<amount>-" + convert.todouble(dt1.rows[m][4]).tostring("#0.00") + "</amount>" + system.environment.newline;
        //            //}
        //            //else if (mode == "c")
        //            //{
        //            //    strtally = strtally + "<amount>-" + convert.todouble(dt1.rows[m][4]).tostring("#0.00") + "</amount>" + system.environment.newline;
        //            //}

        //            strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
        //            //else
        //            //{
        //            //    strtally = strtally + "<NAME>" + RTRANTYPE + " " + Dt1.Rows[m][2].ToString() + "</NAME>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
        //            //}
        //            //strtally = strtally + "<AMOUNT>-" + Dt1.Rows[m][4].ToString() + "</AMOUNT>" + System.Environment.NewLine;
        //            //strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
        //        }
        //        strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
        //    }
        //    EAmount = 0; Amount = 0; tamt = 0;
        //    Dt = PymtObj.GetPaymentES(RID);
        //    if (Dt.Rows.Count > 0)
        //    {
        //        EAmount = Convert.ToDouble(Dt.Rows[0][0].ToString());
        //    }
        //    DtRe = PymtObj.GetPaymentChrg(RID);
        //    if (DtRe.Rows.Count > 0)
        //    {
        //        Amount = Convert.ToDouble(DtRe.Rows[0][1].ToString());
        //    }
        //    tamt = Amount + EAmount;
        //    for (int i = 0; i < DtRe.Rows.Count; i++)
        //    {
        //        Amount = Convert.ToDouble(DtRe.Rows[i][1].ToString());
        //        strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
        //        if (DtRe.Rows[i][0].ToString() == "TAX DEDUCTED AT SOURCE PAYBALE")
        //        {
        //            deductedchargename = "TDS Payables F/Y " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
        //        }
        //        else
        //        {
        //            deductedchargename = DtRe.Rows[i][0].ToString();
        //        }
        //        strtally = strtally + "<LEDGERNAME>" + deductedchargename.Replace("&", "&amp;").Replace("'", "&#39;") + "</LEDGERNAME>" + System.Environment.NewLine;
        //        strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;

        //        if (mode == "B")
        //        {
        //            strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //            strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //            strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //            strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
        //            strtally = strtally + "<AMOUNT>" + -Amount + "</AMOUNT>";
        //            /* if (Amount < 0)
        //             {
        //                 strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //                 strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //                 strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //                 strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
        //                 strtally = strtally + "<AMOUNT>" + Amount + "</AMOUNT>";
        //             }
        //             else
        //             {
        //                 strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //                 strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //                 strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //                 strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
        //                 strtally = strtally + "<AMOUNT>-" + Amount + "</AMOUNT>";
        //             }*/
        //        }
        //        else if (mode == "C")
        //        {
        //            strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //            strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //            strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //            strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
        //            strtally = strtally + "<AMOUNT>-" + Amount + "</AMOUNT>";

        //            //if (Amount > 0)
        //            //{
        //            //    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<AMOUNT>" + Amount + "</AMOUNT>";
        //            //}
        //            //else
        //            //{
        //            //    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
        //            //    strtally = strtally + "<AMOUNT>-" + Amount + "</AMOUNT>";
        //            //}

        //        }

        //        strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
        //        //Amount = Convert.ToDouble(DtRe.Rows[0][1].ToString());
        //    }
        //    strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
        //    strtally = strtally + "<LEDGERNAME>" + partyledger + "</LEDGERNAME>" + System.Environment.NewLine;
        //    strtally = strtally + "<GSTCLASS/>" + System.Environment.NewLine;
        //    //if (mode == "B")
        //    //{
        //    //    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //    //}
        //    //else if (mode == "C")
        //    //{
        //    //    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //    //}
        //    strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //    strtally = strtally + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
        //    if (mode == "C")
        //    {
        //        if (RCAmt == 0 || tamt == 0)
        //        {
        //            strtally = strtally + "<AMOUNT>" + RRFAmt + "</AMOUNT>";
        //        }
        //        else
        //        {
        //            if ((RCAmt - (-tamt)) < 0)
        //            {
        //                strtally = strtally + "<AMOUNT>-" + (RCAmt - (-tamt)) + "</AMOUNT>";
        //            }
        //            else
        //            {
        //                strtally = strtally + "<AMOUNT>" + (RCAmt - (-tamt)) + "</AMOUNT>";
        //            }
        //        }
        //    }
        //    else if (mode == "B")
        //    {
        //        if (RCAmt == 0 || tamt == 0)
        //        {
        //            strtally = strtally + "<AMOUNT>" + RRFAmt + "</AMOUNT>";
        //        }
        //        else
        //        {
        //            strtally = strtally + "<AMOUNT>" + (RCAmt1 - (-tamt)) + "</AMOUNT>";
        //        }
        //    }

        //    //Start Newly added for BANKALLOCATIONS
        //    strtally = strtally + "<BANKALLOCATIONS.LIST> " + System.Environment.NewLine;
        //    strtally = strtally + "<DATE>" + strRdate + "</DATE> " + System.Environment.NewLine;
        //    strtally = strtally + "<INSTRUMENTDATE>" + strCHdate1 + "</INSTRUMENTDATE> " + System.Environment.NewLine;
        //    strtally = strtally + "<NAME></NAME> " + System.Environment.NewLine;

        //    if (str_NEFT == "Y")
        //    {
        //        strtally = strtally + "<TRANSFERMODE>NEFT</TRANSFERMODE>" + System.Environment.NewLine;
        //    }
        //    else
        //    {
        //        strtally = strtally + "<TRANSACTIONTYPE>Cheque/DD</TRANSACTIONTYPE> " + System.Environment.NewLine;
        //    }
        //    strtally = strtally + "<PAYMENTFAVOURING></PAYMENTFAVOURING> " + System.Environment.NewLine;
        //    strtally = strtally + " <INSTRUMENTNUMBER>" + chequeno + "</INSTRUMENTNUMBER> " + System.Environment.NewLine;
        //    strtally = strtally + "<UNIQUEREFERENCENUMBER></UNIQUEREFERENCENUMBER> " + System.Environment.NewLine;
        //    strtally = strtally + "<PAYMENTMODE>Transacted</PAYMENTMODE>" + System.Environment.NewLine;
        //    //strtally = strtally + "<AMOUNT>" + (RCAmt - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;

        //    if (mode == "C")
        //    {
        //        if (RCAmt == 0 || tamt == 0)
        //        {
        //            strtally = strtally + "<AMOUNT>" + RRFAmt + "</AMOUNT>" + System.Environment.NewLine;
        //        }
        //        else
        //        {
        //            if ((RCAmt - (-tamt)) < 0)
        //            {
        //                strtally = strtally + "<AMOUNT>-" + (RCAmt - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;
        //            }
        //            else
        //            {
        //                strtally = strtally + "<AMOUNT>" + (RCAmt - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;
        //            }
        //        }
        //    }
        //    else if (mode == "B")
        //    {
        //        if (RCAmt == 0 || tamt == 0)
        //        {
        //            strtally = strtally + "<AMOUNT>" + RRFAmt + "</AMOUNT>" + System.Environment.NewLine;
        //        }
        //        else
        //        {
        //            strtally = strtally + "<AMOUNT>" + (RCAmt1 - (-tamt)) + "</AMOUNT>" + System.Environment.NewLine;
        //        }
        //    }

        //    strtally = strtally + "</BANKALLOCATIONS.LIST>" + System.Environment.NewLine;

        //    //End Newly added for BANKALLOCATIONS



        //    strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;


        //    DtRe = PymtObj.GetPaymentES(RID);
        //    if (DtRe.Rows.Count > 0)
        //    {
        //        strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
        //        strtally = strtally + "<LEDGERNAME>Round Up</LEDGERNAME>" + System.Environment.NewLine;
        //        strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
        //        if (Convert.ToDouble(DtRe.Rows[0][0]) > 0)
        //        {
        //            strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //        }
        //        else
        //        {
        //            strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
        //        }

        //        strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
        //        strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
        //        strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;

        //        strtally = strtally + "<AMOUNT>" + -(Convert.ToDouble(DtRe.Rows[0][0])) + "</AMOUNT>";
        //        strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
        //    }
        //    strtally = strtally + "</VOUCHER>" + System.Environment.NewLine;
        //    Invobj.UpdVouTally(j, branchid, vouyear, ddl_voucher.Text, empid);
        //    logobj.InsLogDetail(empid, 161, 1, branchid, j + ddl_voucher.Text);
        //    RCAmt = 0;
        //    return strtally;

        //}
       
        
        
        protected string GetJournal(int vouno, int month)
        {
            string strtally = "", rptype = "", shortname = "", dbname = "";
            DateTime vouda;
            int receiptno, recepbranch, customerid = 0;
            string receptbranch = "", voubranh = "";
            dbname = "FA" + Convert.ToInt32(txt_year.Text).ToString().Substring(2, 2) + Convert.ToInt32(lbl_toyear.Text).ToString().Replace("-", "").Substring(2, 2);
            DataTable dt = new DataTable();
            dt = PymtObj.SPTallyJournal(vouno, branchid, month, dbname);
            if (dt.Rows.Count > 0)
            {
                receiptno = Convert.ToInt32(dt.Rows[0]["receipt"].ToString());
                recepbranch = Convert.ToInt32(dt.Rows[0]["receiptbranch"].ToString());
                narration = dt.Rows[0]["narration"].ToString();
                vouda = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["voudate"].ToString()));
                //vouda = Convert.ToDateTime(dt.Rows[0]["voudate"].ToString());
                voudate = string.Format("{0:yyyyMMdd}", vouda);
                receptbranch = dt.Rows[0]["branch"].ToString();
                voubranh = dt.Rows[0]["voubranch"].ToString();

                Session["Enteredby"] = dt.Rows[0]["preparedby"].ToString();  // Vino renamed [05-03-2024]

                strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + "Jnl" + "' ACTION='CREATE'>" + System.Environment.NewLine;

                strtally = strtally + "<DATE>" + voudate + "</DATE>" + System.Environment.NewLine;
                strtally = strtally + "<NARRATION>" + narration + " - " + vouno + "</NARRATION>" + System.Environment.NewLine;
                strtally = strtally + "<VOUCHERTYPENAME>" + "Jnl" + "</VOUCHERTYPENAME>" + System.Environment.NewLine;

                //strtally = "<VOUCHER REMOTEID='' VCHTYPE='" + "Jrnl" + "' ACTION='CREATE'>" + System.Environment.NewLine;

                //strtally = strtally + "<DATE>" + voudate + "</DATE>" + System.Environment.NewLine;
                //strtally = strtally + "<NARRATION>" + narration + " - " + vouno + "</NARRATION>" + System.Environment.NewLine;
                //strtally = strtally + "<VOUCHERTYPENAME>" + "Journal" + "</VOUCHERTYPENAME>" + System.Environment.NewLine;
                if (Convert.ToInt32(txt_year.Text) == 2018)
                {
                    shortname = dt.Rows[0]["voubranch"].ToString().Replace("FIL", "AXL");
                }
                else
                {
                    shortname = dt.Rows[0]["voubranch"].ToString();
                }
                strtally = strtally + "<VOUCHERNUMBER>" + shortname + " / " + "J / " + Convert.ToInt32(txt_JVmonth.Text).ToString() + " / " + vouno.ToString("00000") + "</VOUCHERNUMBER>" + System.Environment.NewLine;


                if (dt.Rows[0]["ledgertype"].ToString() == "Cr")
                {
                    strtally = strtally + "<PARTYLEDGERNAME>" + dt.Rows[0]["ledgername"].ToString().Replace("&", "&amp;").Replace("'", "&#39;") +"</PARTYLEDGERNAME>" + System.Environment.NewLine;
                }


                strtally = strtally + "<CSTFORMISSUETYPE />" + System.Environment.NewLine;
                strtally = strtally + "<CSTFORMRECVTYPE />" + System.Environment.NewLine;
                strtally = strtally + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
                strtally = strtally + "<VCHGSTCLASS />" + System.Environment.NewLine;
                strtally = strtally + "<ENTEREDBY>" + Session["Enteredby"].ToString() + "</ENTEREDBY>" + System.Environment.NewLine; // Vino renamed [05-03-2024]
                strtally = strtally + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
                strtally = strtally + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
                strtally = strtally + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
                strtally = strtally + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
                strtally = strtally + "<EFFECTIVEDATE>" + strRdate + "</EFFECTIVEDATE>" + System.Environment.NewLine;
                strtally = strtally + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
                strtally = strtally + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
                strtally = strtally + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
                strtally = strtally + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
                strtally = strtally + "<EXCISEOPENING>No</EXCISEOPENING>" + System.Environment.NewLine;
                strtally = strtally + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
                strtally = strtally + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
                strtally = strtally + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
                strtally = strtally + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
                strtally = strtally + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
                strtally = strtally + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
                strtally = strtally + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
                strtally = strtally + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
                strtally = strtally + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
                strtally = strtally + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    customerid = Convert.ToInt32(dt.Rows[i]["customerid"].ToString());

                    strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                    strtally = strtally + "<LEDGERNAME>" + dt.Rows[i]["ledgername"].ToString().Replace("&", "&amp;").Replace("'", "&#39;") +"</LEDGERNAME>" + System.Environment.NewLine;
                    strtally = strtally + "<GSTCLASS />" + System.Environment.NewLine;
                    if (dt.Rows[i]["ledgertype"].ToString() == "Cr")
                    {
                        strtally = strtally + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    }
                    else if (dt.Rows[i]["ledgertype"].ToString() == "Dr")
                    {
                        strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                    }
                    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                    if (dt.Rows[i]["ledgertype"].ToString() == "Cr")
                    {
                        strtally = strtally + "<AMOUNT>" + Convert.ToDouble(dt.Rows[i]["ledgeramount"]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;

                        if (dt.Rows[i]["recorpay"].ToString() == "R")
                        {
                            DtRece = RcptObj.GetRecptHead(Convert.ToInt32(dt.Rows[i]["receipt"].ToString()), Convert.ToInt32(dt.Rows[i]["receiptbranch"].ToString()), Convert.ToChar('B'), Convert.ToInt32(dt.Rows[i]["vouyear"].ToString()));
                            if (DtRece.Rows.Count > 0)
                            {
                                RID = Convert.ToInt32(DtRece.Rows[0]["receiptid"].ToString());
                                rptype = "R";
                            }

                        }
                        else if (dt.Rows[i]["recorpay"].ToString() == "P")
                        {
                            DtRece = PymtObj.GetPaymentHeadXML(Convert.ToInt32(dt.Rows[i]["receipt"].ToString()), Convert.ToInt32(dt.Rows[i]["receiptbranch"].ToString()), Convert.ToChar('B'), Convert.ToInt32(dt.Rows[i]["vouyear"].ToString()));
                            if (DtRece.Rows.Count > 0)
                            {
                                RID = Convert.ToInt32(DtRece.Rows[0]["paymentid"].ToString());
                                rptype = "P";
                            }
                        }

                        if (rptype == "R")
                        {
                            if (customerid != 0)
                            {
                                Dt1 = RcptObj.GetRAInvoiceToShowWithCustomerNEW(RID, Convert.ToChar(rptype), customerid, branchid);
                            }
                            else
                            {
                                Dt1 = RcptObj.GetRAInvoiceToShow(RID, Convert.ToChar(rptype));
                            }

                            //Dt1 = RcptObj.GetRAInvoiceToShow(RID, Convert.ToChar(rptype));
                            if (Dt1.Rows.Count > 0)
                            {
                                for (int m = 0; m < Dt1.Rows.Count; m++)
                                {
                                    strtally = strtally + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) == 0)
                                    {
                                        strtally = strtally + "<NAME>On Account</NAME>" + System.Environment.NewLine;
                                        strtally = strtally + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                                    }
                                    else
                                    {
                                        if (Dt1.Rows[m]["voutype"].ToString().Trim() == "B" || Dt1.Rows[m]["voutype"].ToString().Trim() == "I")
                                        {
                                            strtally = strtally + "<NAME>" + hid_portcode.Value + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("B", "BS").Replace("I", "SI") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                                        }
                                        else if ((Dt1.Rows[m]["voutype"].ToString().Trim() == "P") || (Dt1.Rows[m]["voutype"].ToString().Trim() == "E") || (Dt1.Rows[m]["voutype"].ToString().Trim() == "S"))
                                        {
                                            strtally = strtally + "<NAME>" + Dt1.Rows[m]["vendorrefno"].ToString() + "</NAME>" + System.Environment.NewLine;
                                        }
                                        else
                                        {
                                            strtally = strtally + "<NAME>" + Dt1.Rows[m]["vendorrefno"].ToString() + "</NAME>" + System.Environment.NewLine; 
                                            //strtally = strtally + "<NAME>" + hid_portcode.Value + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("I", "SI").Replace("P", "PI").Replace("V", "DN").Replace("E", "CN").Replace("S", "ACN").Replace("X", "ADN").Replace("OI", "OB SI").Replace("OP", "OB PI").Replace("OV", "OB DN").Replace("OE", "OB CN").Replace("OS", "OB ACN").Replace("OX", "OB ADN") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                                        }
                                        strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                                    }
                                    strtally = strtally + "<AMOUNT>" + Convert.ToDouble(Dt1.Rows[m][4]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;
                                    strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                                }
                            }

                        }

                        if (customerid != 0)
                        {
                            DtRe = RcptObj.GetRecptChrgNEW(RID, branchid, customerid);
                            {
                                if (DtRe.Rows.Count > 0)
                                {
                                    strtally = strtally + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                                    if (DtRe.Rows[0][0].ToString() == "TAX DEDUCTED AT SOURCE RECEIVABLE")
                                    {
                                        deductedchargename = "TDS Receivables F/Y " + txt_year.Text.Substring(2, 2) + "-" + lbl_toyear.Text.Substring(3, 2);
                                    }
                                    else
                                    {
                                        deductedchargename = DtRe.Rows[0][0].ToString();
                                    }
                                    strtally = strtally + "<LEDGERNAME>" + deductedchargename.Trim() + "</LEDGERNAME>" + System.Environment.NewLine;
                                    strtally = strtally + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                                    strtally = strtally + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                                    strtally = strtally + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                                    strtally = strtally + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + System.Environment.NewLine;
                                    strtally = strtally + "<AMOUNT>-" + DtRe.Rows[0][1].ToString() + "</AMOUNT>" + System.Environment.NewLine;
                                    strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                                }
                            }
                        }

                    }
                    else if (dt.Rows[i]["ledgertype"].ToString() == "Dr")
                    {
                        if (DtRe.Rows.Count > 0)
                        {
                            strtally = strtally + "<AMOUNT>-" + (Convert.ToDouble(dt.Rows[i]["ledgeramount"]) - Convert.ToDouble(DtRe.Rows[0][1])).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;
                        }
                        else
                        {
                            strtally = strtally + "<AMOUNT>-" + Convert.ToDouble(dt.Rows[i]["ledgeramount"]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;
                        }

                        if (dt.Rows[i]["recorpay"].ToString() == "R")
                        {
                            DtRece = RcptObj.GetRecptHead(Convert.ToInt32(dt.Rows[i]["receipt"].ToString()), Convert.ToInt32(dt.Rows[i]["receiptbranch"].ToString()), Convert.ToChar('B'), Convert.ToInt32(dt.Rows[i]["vouyear"].ToString()));
                            if (DtRece.Rows.Count > 0)
                            {
                                RID = Convert.ToInt32(DtRece.Rows[0]["receiptid"].ToString());
                                rptype = "R";
                            }

                        }
                        else if (dt.Rows[i]["recorpay"].ToString() == "P")
                        {
                            DtRece = PymtObj.GetPaymentHead(Convert.ToInt32(dt.Rows[i]["receipt"].ToString()), Convert.ToInt32(dt.Rows[i]["receiptbranch"].ToString()), Convert.ToChar('B'), Convert.ToInt32(dt.Rows[i]["vouyear"].ToString()));
                            if (DtRece.Rows.Count > 0)
                            {
                                RID = Convert.ToInt32(DtRece.Rows[0]["paymentid"].ToString());
                                rptype = "P";
                            }
                        }

                        if (rptype == "P")
                        {
                            if (customerid != 0)
                            {
                                Dt1 = RcptObj.GetRAInvoiceToShowWithCustomerNEW(RID, Convert.ToChar(rptype), customerid, branchid);
                            }
                            else
                            {
                                Dt1 = RcptObj.GetRAInvoiceToShow(RID, Convert.ToChar(rptype));
                            }

                            //Dt1 = RcptObj.GetRAInvoiceToShow(RID, Convert.ToChar(rptype));
                            if (Dt1.Rows.Count > 0)
                            {
                                for (int m = 0; m < Dt1.Rows.Count; m++)
                                {
                                    strtally = strtally + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                                    if (Convert.ToInt32(Dt1.Rows[m][2].ToString()) == 0)
                                    {
                                        strtally = strtally + "<NAME>On Account</NAME>" + System.Environment.NewLine;
                                        strtally = strtally + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                                    }
                                    else
                                    {
                                        if (Dt1.Rows[m]["voutype"].ToString().Trim() == "B")
                                        {
                                            strtally = strtally + "<NAME>" + hid_portcode.Value + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("B", "BS") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                                        }
                                        else if ((Dt1.Rows[m]["voutype"].ToString().Trim() == "P") || (Dt1.Rows[m]["voutype"].ToString().Trim() == "E") || (Dt1.Rows[m]["voutype"].ToString().Trim() == "S"))
                                        {
                                            strtally = strtally + "<NAME>" + Dt1.Rows[m]["vendorrefno"].ToString() + "</NAME>" + System.Environment.NewLine;
                                        }
                                        else
                                        {
                                            strtally = strtally + "<NAME>" + hid_portcode.Value + Dt1.Rows[m]["voutype"].ToString().Trim().Replace("I", "IN").Replace("P", "PA").Replace("V", "DN").Replace("E", "CN").Replace("S", "ACN").Replace("X", "ADN").Replace("OI", "OB IN").Replace("OP", "OB PA").Replace("OV", "OB DN").Replace("OE", "OB CN").Replace("OS", "OB ACN").Replace("OX", "OB ADN") + Dt1.Rows[m]["ravouyear"].ToString().Substring(2, 2) + (Convert.ToInt32(Dt1.Rows[m]["ravouyear"].ToString()) + 1).ToString().Substring(2, 2) + Convert.ToInt32(Dt1.Rows[m]["vouno"]).ToString("00000").Trim() + "</NAME>" + System.Environment.NewLine;
                                        }
                                        strtally = strtally + "<BILLTYPE>Agst Ref</BILLTYPE>" + System.Environment.NewLine;
                                    }
                                    strtally = strtally + "<AMOUNT>" + Convert.ToDouble(Dt1.Rows[m][4]).ToString("#0.00") + "</AMOUNT>" + System.Environment.NewLine;
                                    strtally = strtally + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                                }
                            }
                        }
                    }
                    strtally = strtally + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                }
                strtally = strtally + "</VOUCHER>" + System.Environment.NewLine;
            }
           

            return strtally;
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
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1959, "", "", "", Session["StrTranType"].ToString());



            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

    }
}