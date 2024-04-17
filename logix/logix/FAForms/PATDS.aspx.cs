using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.FAForm
{
    public partial class PATDS : System.Web.UI.Page
    {
        int int_branchid = 0;
        string str_Uiid;
        string trantype;
        string StrTranType;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.HR.Employee obj_da_HR = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();


        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();

        DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.LogDetails Obj_LogDet = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_Customer.GetDataBase(Ccode);
                obj_da_HR.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                obj_da_Port.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);


                obj_da_Ledger.GetDataBase(Ccode);
                obj_da_FAVoucher.GetDataBase(Ccode);
                obj_da_Cheque.GetDataBase(Ccode);
                Obj_LogDet.GetDataBase(Ccode);



            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            try
            {
                if (!IsPostBack)
                {
                    Session["AgainstVouYear"] = null;

                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        if (Request.QueryString.ToString().Contains("FormName"))
                        {
                            lbl_Header.Text = Request.QueryString["FormName"].ToString();
                        }

                        StrTranType = Session["StrTranType"].ToString();
                        str_Uiid = Request.QueryString["UIID"].ToString();

                        if (StrTranType == "CO")
                        {
                            trantype = "CA";
                        }
                        else
                        {
                            trantype = "AC";
                        }

                        if (lbl_Header.Text == "Credit Note - Operations TDS" || lbl_Header.Text == "CN-Ops TDS" || lbl_Header.Text == "PI TDS")
                        {
                            hid_type.Value = "P";
                        }
                        else if (lbl_Header.Text == "Other Credit Note TDS" || lbl_Header.Text == "Other CN TDS")
                        {
                            hid_type.Value = "E";
                        }
                        else
                        {
                            hid_type.Value = "S";
                        }
                    }

                    Fn_LodaBranch();
                    btn_update.Visible = true;
                    lbl_branch.Text = lbl_Header.Text;
                    ddl_branch.Visible = false;
                    ddl_branch.Items.Add(Session["LoginBranchName"].ToString());
                    int_branchid = int.Parse(Session["LoginBranchid"].ToString());
                    hid_branchid.Value = int_branchid.ToString();
                    //if (trantype == "CA")
                    //{
                    //    btn_update.Visible = true;
                    //    ddl_branch.Visible = true;
                    //    DataAccess.HR.Employee obj_da_HR = new DataAccess.HR.Employee();
                    //    int_branchid = obj_da_HR.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), ddl_branch.SelectedItem.Text);
                    //    hid_branchid.Value = int_branchid.ToString();
                    //}
                    //else
                    //{
                    //    btn_update.Visible = true;
                    //    lbl_branch.Text = lbl_Header.Text;
                    //    ddl_branch.Visible = false;
                    //    ddl_branch.Items.Add(Session["LoginBranchName"].ToString());
                    //    int_branchid = int.Parse(Session["LoginBranchid"].ToString());
                    //    hid_branchid.Value = int_branchid.ToString();
                    //}

                    Fn_GetDetail(hid_type.Value.ToString(), int_branchid);
                  //  ddl_section_SelectedIndexChanged1(sender, e);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_LodaBranch()
        {
            DataTable obj_dt = new DataTable();
            //DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            obj_dt = obj_da_Port.GetAllBranchNameforPortName();
            ddl_branch.DataSource = obj_dt;
            ddl_branch.DataTextField = "portname";
            ddl_branch.DataBind();
        }

        private void Fn_GetDetail(string Str_Type, int int_bid)
        {
            try
            {
              
                DataTable DT_per = new DataTable();

                DataTable obj_dt = new DataTable();
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                obj_dt = obj_da_Invoice.GetPATDSDetails(int_bid, Str_Type);
                Grd_TDS.DataSource = obj_dt;
                Grd_TDS.DataBind();
                int value = 0;
                ViewState["obj_dt"] = obj_dt;

                DataTable dlp = new DataTable();
                dlp = obj_da_Invoice.sp_ddlsectionnew1();


                for (int i = 0; i < Grd_TDS.Rows.Count; i++)
                {
                    var ddl1 = (DropDownList)Grd_TDS.Rows[i].FindControl("ddl_section");
                    //dlp = obj_da_Invoice.GetPATDSDetails(Convert.ToInt32(Session["int_bid"]),Session["Str_Type"].ToString());

                    //ddl1.Items.Add(dlp.Rows[i]["tdssection"].ToString());
                    //ddl1.Items.Add(dlp.Rows[i]["tdssection"].ToString());

                    //  ddl1.Items.Add(new ListItem(dlp.Rows[i]["tdssection"].ToString()));


                    ddl1.DataSource = dlp;
                    ddl1.DataTextField = "tdssection";
                    //ddl1.DataValueField = "tdssection";
                    ddl1.DataBind();
                   // ddl1.Items.Insert(0, new ListItem("Select", "-1"));

                }


                for (int i = 0; i < obj_dt.Rows.Count; i++)
                {
                    DropDownList ddl_tdssection = (DropDownList)Grd_TDS.Rows[i].FindControl("ddl_section");
                    ddl_tdssection.SelectedValue = obj_dt.Rows[i]["tdssection"].ToString();


                    TextBox Txt_per = ((TextBox)Grd_TDS.Rows[i].FindControl("txtpercentage"));

                    TextBox TDSdescnew = ((TextBox)Grd_TDS.Rows[i].FindControl("TDSdescnew"));
                    Txt_per.Text = obj_dt.Rows[i]["tdsper"].ToString();
                    TDSdescnew.Text = obj_dt.Rows[i]["tdsdesc"].ToString();
                    //DT_per = obj_da_Invoice.Get_TDSPercentage(ddl_tdssection.SelectedValue);
                    //if (DT_per.Rows.Count > 0)
                    //{
                    //    //Txt_per.Text = obj_dt.Rows[0]["tdsper"].ToString();
                    //    TDSdescnew.Text = DT_per.Rows[0]["tdsdesc"].ToString();
                    //    //Txt_per.Enabled = true;
                    //}

                }

                //DataTable dlp1 = new DataTable();
                //dlp1 = obj_da_Invoice.sp_ddlsection();


                //for (int i = 0; i < Grd_TDS.Rows.Count; i++)
                //{
                //    var ddl2 = (DropDownList)Grd_TDS.Rows[i].FindControl("ddl_section1");
                //    //dlp = obj_da_Invoice.GetPATDSDetails(Convert.ToInt32(Session["int_bid"]),Session["Str_Type"].ToString());

                //    //ddl1.Items.Add(dlp.Rows[i]["tdssection"].ToString());
                //    //ddl1.Items.Add(dlp.Rows[i]["tdssection"].ToString());

                //    //  ddl1.Items.Add(new ListItem(dlp.Rows[i]["tdssection"].ToString()));


                //    ddl2.DataSource = dlp1;
                //    ddl2.DataTextField = "tdspercentage";
                //    //ddl2.DataValueField = "tdssection";
                //    ddl2.DataBind();
                //    // ddl1.Items.Insert(0, new ListItem("Select", "-1"));

                //}



                //for (int i = 0; i < obj_dt.Rows.Count; i++)
                //{
                //    DropDownList ddl_tdssection = (DropDownList)Grd_TDS.Rows[i].FindControl("ddl_section");
                //    ddl_tdssection.SelectedValue = obj_dt.Rows[i]["tdssection"].ToString();


                //    TextBox Txt_per = ((TextBox)Grd_TDS.Rows[i].FindControl("txtpercentage"));

                //    TextBox TDSdescnew = ((TextBox)Grd_TDS.Rows[i].FindControl("TDSdescnew"));
                //    Txt_per.Text = obj_dt.Rows[i]["tdsper"].ToString();
                //    TDSdescnew.Text = obj_dt.Rows[i]["tdsdesc"].ToString();
                //    //DT_per = obj_da_Invoice.Get_TDSPercentage(ddl_tdssection.SelectedValue);
                //    //if (DT_per.Rows.Count > 0)
                //    //{
                //    //    //Txt_per.Text = obj_dt.Rows[0]["tdsper"].ToString();
                //    //    TDSdescnew.Text = DT_per.Rows[0]["tdsdesc"].ToString();
                //    //    //Txt_per.Enabled = true;
                //    //}
                    
                //}
               
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
           
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_branch.SelectedItem.Text.Trim().Length > 0)
            {
                //DataAccess.HR.Employee obj_da_HR = new DataAccess.HR.Employee();
                int_branchid = obj_da_HR.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), ddl_branch.SelectedItem.Text);
                Fn_GetDetail(hid_type.Value.ToString(), int_branchid);
                hid_branchid.Value = int_branchid.ToString();
            }
            btn_cancel.Text = "Cancel";
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            int Emp_ID = Convert.ToInt32(Session["LoginEmpId"].ToString());
            btn_cancel.Text = "Cancel";
            int_branchid= Convert.ToInt32(hid_branchid.Value);
            string cutname = "", StrScript="";
            string Ledger = "";
            int countryid = 0;
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            try
            {
                Boolean Check = false;
                //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                //DataAccess.LogDetails Obj_LogDet = new DataAccess.LogDetails();

                foreach (GridViewRow row in Grd_TDS.Rows)
                {
                    int int_Vouno = 0, int_Vouyear = 0, int_Custid = 0;
                    double Amount = 0, TDS = 0, TDSAmount = 0, CSTAmount = 0;
                    string str_Voutype = hid_type.Value.ToString();
                    bool ChkLedger = true;
                    CheckBox Chk = (CheckBox)Grd_TDS.Rows[row.RowIndex].FindControl("Chk_Select");
                    TextBox Txt = (TextBox)Grd_TDS.Rows[row.RowIndex].FindControl("txtpercentage");
                    DropDownList drp_section = ((DropDownList)Grd_TDS.Rows[row.RowIndex].FindControl("ddl_section"));
                    
                    if (Chk.Checked == true)
                    {
                        Check = true;
                        


                        int_Vouno = int.Parse(Grd_TDS.Rows[row.RowIndex].Cells[0].Text.ToString());
                        int_Vouyear = int.Parse(Grd_TDS.DataKeys[row.RowIndex].Values[0].ToString());
                        int_Custid = int.Parse(Grd_TDS.DataKeys[row.RowIndex].Values[2].ToString());
                        countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));
                        if (int_Custid != 0)
                        {
                            cutname = obj_da_Customer.GetCustomername(int_Custid);
                        }
                        if( (countryid == 1102)||(countryid == 102))
                        {
                            if (Txt.Text == " " || Txt.Text == "")
                            {
                                // ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "TDS", "alertify.alert('Enter TDS%' "+cutname.ToString()+");", true);
                                StrScript += "Enter TDS% For" + cutname.ToString() + " IN Vou # : " + int_Vouno + ",";

                                Check = false;
                                Chk.Focus();
                                continue;
                                //return;
                            }
                            else
                            {
                                StrScript += cutname.ToString() + " IN Vou # : " + int_Vouno + ",";
                            }
                        }

                        DataTable Dt_LimitCheck = new DataTable();

                        Dt_LimitCheck = obj_da_Approval.GetCustAmtLimt(int_Custid, int_branchid);
                        Amount = obj_da_Approval.GetVoucherAmount4TDS(int_Vouno, int_branchid, int_Vouyear, str_Voutype);

                        if (Dt_LimitCheck.Rows.Count > 0)
                        {
                            if (Amount > 0)
                            {
                                double cstamount = Convert.ToDouble(Dt_LimitCheck.Rows[0]["cstamount"].ToString()) - Amount;
                                double AmtWidExem, AmtWidTds, AmtwitoutTds;
                                double tdsemp, tdsper;
                                if (Convert.ToDouble(cstamount) >= Convert.ToDouble(Dt_LimitCheck.Rows[0]["limit"].ToString()))
                                {
                                    TDS = Convert.ToDouble(Txt.Text.ToString());
                                    TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                }
                                else //if(Convert.ToInt32(Dt_LimitCheck.Rows[0]["cstamount"].ToString()) < Convert.ToInt32(Dt_LimitCheck.Rows[0]["limit"].ToString()))
                                {
                                    double diff = Convert.ToDouble(cstamount) + Amount;
                                    if (diff > Convert.ToDouble(Dt_LimitCheck.Rows[0]["limit"].ToString()))
                                    {
                                        tdsper = Convert.ToDouble(Txt.Text.ToString());
                                        AmtWidExem = diff - Convert.ToDouble(Dt_LimitCheck.Rows[0]["limit"].ToString());
                                        AmtwitoutTds = Convert.ToDouble((AmtWidExem * (tdsper / 100)).ToString("#0.00"));
                                        tdsemp = Convert.ToDouble(Dt_LimitCheck.Rows[0]["tdsemp"].ToString());
                                        AmtWidTds = Convert.ToDouble(((Amount - AmtWidExem) * (tdsemp / 100)).ToString("#0.00"));
                                        TDSAmount = AmtwitoutTds + AmtWidTds;
                                    }
                                    else
                                    {
                                        TDS = Convert.ToDouble(Dt_LimitCheck.Rows[0]["tdsemp"].ToString());
                                        TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToDouble(Txt.Text.ToString()) == 0.0)
                                {
                                    TDSAmount = 0;
                                }
                                else
                                {
                                    TDS = Convert.ToDouble(Txt.Text.ToString());
                                   // TDSAmount = Amount * (TDS / 100);
                                    TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                }
                            }

                        }
                        else
                        {
                            if (Convert.ToDouble(Txt.Text.ToString()) == 0.0)
                            {
                                TDSAmount = 0;
                            }
                            else
                            {
                                TDS = Convert.ToDouble(Txt.Text.ToString());
                                //TDSAmount = Amount * (TDS / 100);
                                TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                            }
                        }


                        //Amount = double.Parse(Grd_TDS.DataKeys[row.RowIndex].Values[1].ToString());
                        //TDS = double.Parse(Txt.Text.ToString());
                        ////TDSAmount = Amount * (TDS / 100);
                        //TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00")); 
                        CSTAmount = Amount - TDSAmount;
                        DataTable obj_dt = new DataTable();
                    
                      
                        //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                        //DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                        if (str_Voutype == "S")
                        {
                            //obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Vouno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear);
                            obj_dt = obj_da_Invoice.GetPartyLedger4PAAdminwithCust(int_Vouno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear);
                        }

                        if (Session["Vouyear"].ToString() == int_Vouyear.ToString())
                        {
                            Session["AgainstVou"] = null;
                        }
                        else
                        {
                            GetFADBvou(int_Vouyear);
                        }

                        if (obj_dt.Rows.Count > 0)
                        {
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                int int_Ledgerid = 0;
                                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), obj_dt.Rows[i]["opstype"].ToString(), Session["FADbname"].ToString());
                                if (int_Ledgerid == 0)
                                {
                                    Ledger += " " + obj_dt.Rows[i]["chargename"].ToString();
                                    ChkLedger = false;
                                }
                            }
                        }

                        if (ChkLedger == true)
                        {
                            if( (countryid == 1102)||(countryid == 102))
                            {
                                obj_da_Invoice.InsertPATDS(int_Vouno, str_Voutype, int_branchid, int_Custid, int_Vouyear, CSTAmount, TDSAmount, drp_section.Text, Convert.ToDouble(Txt.Text.ToString()));
                            }
                            string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";

                            if (str_Voutype == "P")
                            {
                                Obj_LogDet.InsLogDetail(Emp_ID, 1163, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "CN-Ops" + int_Vouno + "/FA/U");
                            }
                            else if (str_Voutype == "E")
                            {
                                Obj_LogDet.InsLogDetail(Emp_ID, 1164, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "CN-Others" + int_Vouno + "/FA/U");
                            }
                            else if (str_Voutype == "S")
                            {
                                if (StrTranType == "AC")
                                {
                                    Obj_LogDet.InsLogDetail(Emp_ID, 1165, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "CN-Admin" + int_Vouno + "/FA/U");
                                }
                                else
                                {
                                    Obj_LogDet.InsLogDetail(Emp_ID, 1220, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "CN-Admin" + int_Vouno + "/FA/U");
                                }
                            }

                            if (str_Voutype == "P")
                            {
                                Str_ddlVoucherType = "Credit Note - Operations";
                                Str_ddlNarration = "Vessel/Voyage/Container";
                                Str_ddlReference = "BL No";
                            }
                            else if (str_Voutype == "E")
                            {
                                Str_ddlVoucherType = "Credit Note - Others";
                                Str_ddlNarration = "Vessel/Voyage/Container";
                                Str_ddlReference = "BL No";
                            }
                            else if (str_Voutype == "S")
                            {
                                Str_ddlVoucherType = "Admin Purchase Invoice";
                                Str_ddlNarration = "Remarks";
                                Str_ddlReference = "Ref No";
                            }

                         //   logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Vouno, int_Vouno, Str_ddlNarration, Str_ddlReference, int_branchid, "", 0, 0, "", 0, int_Vouyear);
                            string retransfer = "N";
                            if (Session["vouid"] != null)
                            {

                                retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Session["FADbname"].ToString());

                                if (retransfer == "Y")
                                {
                                    // logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Vouno, int_Vouno, Str_ddlNarration, Str_ddlReference);
                                    if (Session["LoginBranchid"].ToString() == "86")
                                    {
                                        logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Vouno, int_Vouno, "Remarks", Str_ddlReference, int_branchid,"",0,0,"",0,int_Vouyear);

                                    }
                                    else
                                    {
                                        logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Vouno, int_Vouno, Str_ddlNarration, Str_ddlReference, int_branchid,"",0,0,"",0,int_Vouyear);
                                    }

                                }
                                Session["vouid"] = null;

                            }
                            try
                            {
                                int int_Ledgerid = 0;
                                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Session["FADbname"].ToString());
                                int int_Voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_ddlVoucherType, Session["FADbname"].ToString());
                                if (int_Ledgerid == 0)
                                {
                                    int_Ledgerid = Fn_Getcustomergroupid(int_Custid, Str_ddlVoucherType);
                                }

                                DateTime dtdate = DateTime.Parse(Utility.fn_ConvertDate(Grd_TDS.Rows[row.RowIndex].Cells[1].Text));
                               
                                string Str_CustType = obj_da_Customer.GetCustomerType(int_Custid);
                                if (Str_CustType == "P" || Str_CustType == "E")
                                {
                                    DataTable dt = new DataTable();
                                    dt = obj_da_Invoice.GetOtherDCNAmount(int_Vouno, "CNHead", int_branchid, int.Parse(Session["Vouyear"].ToString()));
                                    string Str_Curr = "";
                                    double F_Curr = 0;
                                    if (dt.Rows.Count > 0)
                                    {
                                        Str_Curr = dt.Rows[0]["curr"].ToString();
                                        F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                    }
                                    obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Vouno, dtdate, char.Parse(hid_type.Value.ToString()), int.Parse(Session["Vouyear"].ToString()), int_branchid, CSTAmount, Str_Curr, F_Curr, int_Custid);
                                }
                                else
                                {

                                    obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Vouno, dtdate, char.Parse(hid_type.Value.ToString()), int.Parse(Session["Vouyear"].ToString()), int_branchid, CSTAmount, "", 0, int_Custid);
                                }
                            }
                            catch (Exception ex)
                            {
                                //  Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In PATDS - " + Str_ddlVoucherType + " #" + int_Vouno + "\\VType-" + hid_type.Value.ToString() + " \\VYear - " + Session["Vouyear"].ToString() + " \\BID - " + int_branchid, ex.ToString(), "", Session["usermailpwd"].ToString());
                            }

                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "TDS", "alertify.alert('LedgerName Not Found in Financial. You are not able to Approve TDS FOR CN " + int_Vouno + " Contact Your  Finanace Head');", true);

                            StrScript +="Ledgername "+Ledger+" not found in Finance Side. You are not able to Approve TDS FOR CN " + int_Vouno + " Contact Your  Finanace Head";
                        }
                    }
                }
                if (Check == true)
                {
                   // ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "TDS", "alertify.alert('Detail Updated');", true);
                    
                    StrScript += "Detail Updated";
                }
                else
                {
                    StrScript  = " "+StrScript ;
                }
                ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "TDS", "alertify.alert('" + StrScript + "');", true);
                Fn_GetDetail(hid_type.Value.ToString(), int_branchid);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void GetFADBvou(int vyearp)
        {
            string FAYear1, FADbname;
            int vyear1;
            vyear1 = vyearp;
            FAYear1 = vyear1.ToString();
            FAYear1 = FAYear1.Substring(2, 2);
            vyear1 = vyear1 + 1;
            FAYear1 = FAYear1 + Convert.ToString(vyear1).Substring(2, 2);
            FADbname = "FA" + FAYear1;
            Session["FADbname"] = FADbname;
            Session["AgainstVouYear"] = vyearp;
            Session["AgainstVou"] = "True";
        }

        private int Fn_Getcustomergroupid(int int_Custid, string Str_VType)
        {
            int int_Subgroupid = 0, int_Groupid = 0;
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            if (Str_VType == "Credit Note - Others")
            {
                if (obj_da_Customer.GetCustomerType(int_Custid) == "P")
                {
                    int_Subgroupid = 44;
                    int_Groupid = 12;
                }
                else
                {
                    int_Subgroupid = 67;
                    int_Groupid = 12;
                }
            }
            else if (Str_VType == "Credit Note - Operations")
            {
                int_Subgroupid = 67;
                int_Groupid = 12;
            }
            else if (Str_VType == "Admin Purchase Invoice")
            {
                int_Subgroupid = 41;
                int_Groupid = 12;
            }
            int int_Ledgerid = 0;
            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid), int_Subgroupid, int_Groupid, 'G', int_Custid, 'C', Session["FADbname"].ToString());

            return int_Ledgerid;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.Text == "Cancel")
            {
                Grd_TDS.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_TDS.DataBind();
                btn_cancel.Text = "Back";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void Grd_TDS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                int pageindex = e.NewPageIndex;
                //CHeck with Grid Page_size
                int count = (pageindex * 16);
                int count_length = count + 16;

                Grd_TDS.PageIndex = e.NewPageIndex;
                Grd_TDS.DataSource = ViewState["obj_dt"] as DataTable;
                Grd_TDS.DataBind();
                DataTable obj_dt = ViewState["obj_dt"] as DataTable;
                if (obj_dt.Rows.Count >= count_length)
                {

                }
                else
                {

                }
                int j = 0;
                for (int i = count; i < obj_dt.Rows.Count; i++)
                {
                    DropDownList ddl_tdssection = (DropDownList)Grd_TDS.Rows[j].FindControl("ddl_section");
                    ddl_tdssection.SelectedValue = obj_dt.Rows[i]["tdssection"].ToString();
                    j++;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        protected void Grd_TDS_RowDataBound(object sender, GridViewRowEventArgs e)
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
                // e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_TDS, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        private void Grd_TDS_CellContentClick(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > 0)
            {
                int rowindex = e.Row.RowIndex;
                GridViewRow row = this.Grd_TDS.Rows[rowindex];
            }

        }
        protected void ddl_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               // DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable DT_per = new DataTable();
                DataTable dt = new DataTable();
                int RowIndex = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
                DropDownList drp_section = ((DropDownList)Grd_TDS.Rows[RowIndex].FindControl("ddl_section"));
                DropDownList drp_section1 = ((DropDownList)Grd_TDS.Rows[RowIndex].FindControl("ddl_section1"));
                TextBox Txt_per = ((TextBox)Grd_TDS.Rows[RowIndex].FindControl("txtpercentage"));
                TextBox TDSdescnew = ((TextBox)Grd_TDS.Rows[RowIndex].FindControl("TDSdescnew"));
              
                //dt = (DataTable)ViewState["obj_dt"];
                ////DT_per = obj_da_Invoice.Get_TDSPercentagenew(drp_section.SelectedValue, Convert.ToInt32(dt.Rows[RowIndex]["tdsid"].ToString()));
                //DT_per = obj_da_Invoice.Get_TDSPercentage(drp_section.SelectedValue);
                //if(DT_per.Rows.Count>0)
                //{
                //    //Txt_per.Text = DT_per.Rows[0]["tdspercentage"].ToString();
                //   //TDSdescnew.Text = DT_per.Rows[0]["tdsdesc"].ToString();
                //    //Txt_per.Enabled = true;
                //}


                DataTable dlp = new DataTable();
                dlp = obj_da_Invoice.sp_ddltds(drp_section.SelectedItem.Text);

                var ddl2 = (DropDownList)Grd_TDS.Rows[RowIndex].FindControl("ddl_section1");
                ddl2.Items.Clear();
                ddl2.Items.Add("");
                for (int i = 0; i < dlp.Rows.Count; i++)
                {
                    ddl2.Items.Add(dlp.Rows[i]["tdspercentage"].ToString());
                }
                //ddl2.DataSource = dlp;
                //ddl2.DataTextField = "tdspercentage";
                //ddl2.DataBind();
               /* for (int i = 0; i < Grd_TDS.Rows.Count; i++)
                {
                 
                    //dlp = obj_da_Invoice.GetPATDSDetails(Convert.ToInt32(Session["int_bid"]),Session["Str_Type"].ToString());

                    //ddl1.Items.Add(dlp.Rows[i]["tdssection"].ToString());
                    //ddl1.Items.Add(dlp.Rows[i]["tdssection"].ToString());

                    //  ddl1.Items.Add(new ListItem(dlp.Rows[i]["tdssection"].ToString()));



                  
                    //ddl2.DataSource = dlp;
                    //ddl2.DataTextField = "tdspercentage";
                    ////ddl1.DataValueField = "tdssection";
                    //ddl2.DataBind();
                    // ddl1.Items.Insert(0, new ListItem("Select", "-1"));

                }*/
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }




        protected void ddl_section_SelectedIndexChanged1(object sender, EventArgs e)
        {
            /*try
            {
                /*DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable DT_per = new DataTable();
                int RowIndex = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
                DropDownList drp_section = ((DropDownList)Grd_TDS.Rows[RowIndex].FindControl("ddl_section"));
                TextBox Txt_per = ((TextBox)Grd_TDS.Rows[RowIndex].FindControl("txtpercentage"));
                DT_per = obj_da_Invoice.Get_TDSPercentage(drp_section.SelectedValue);
                if (DT_per.Rows.Count > 0)
                {
                    Txt_per.Text = DT_per.Rows[0]["tdspercentage"].ToString();
                    //Txt_per.Enabled = true;
                }
                //foreach (GridViewRow row in Grd_TDS.Rows)
                //{

                //    int value = 0;
                //    int index = row.RowIndex;
                //    if (index != Grd_TDS.Rows.Count)
                //    {
                //        DropDownList ddl = (DropDownList)Grd_TDS.Rows[index].Cells[6].FindControl("ddlsection");

                //        value = Convert.ToInt32(ddl.SelectedValue);
                //        TextBox Txt = (TextBox)Grd_TDS.Rows[index].Cells[7].FindControl("txt_Percentage");
                //        Txt.Text = value.ToString();

                //    }
                //}


            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            */


            try
            {
              //  DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable DT_per = new DataTable();
                DataTable dt = new DataTable();
                int RowIndex = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
                DropDownList drp_section = ((DropDownList)Grd_TDS.Rows[RowIndex].FindControl("ddl_section1"));
                TextBox Txt_per = ((TextBox)Grd_TDS.Rows[RowIndex].FindControl("txtpercentage"));
                TextBox TDSdescnew = ((TextBox)Grd_TDS.Rows[RowIndex].FindControl("TDSdescnew"));

                //dt = (DataTable)ViewState["obj_dt"];
                ////DT_per = obj_da_Invoice.Get_TDSPercentagenew(drp_section.SelectedValue, Convert.ToInt32(dt.Rows[RowIndex]["tdsid"].ToString()));
                //DT_per = obj_da_Invoice.Get_TDSPercentage(drp_section.SelectedValue);
                //if (DT_per.Rows.Count > 0)
                //{
                   // Txt_per.Text = DT_per.Rows[0]["tdspercentage"].ToString();

                Txt_per.Text = drp_section.SelectedValue;
                    //TDSdescnew.Text = DT_per.Rows[0]["tdsdesc"].ToString();
                    //Txt_per.Enabled = true;
                //}
            }
            catch (Exception ex)
            {

            }
            finally
            {

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
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1163, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1214, "", "", "", Session["StrTranType"].ToString());
            }



            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void Grd_TDS_PreRender(object sender, EventArgs e)
        {
            if (Grd_TDS.Rows.Count > 0)
            {
                Grd_TDS.UseAccessibleHeader = true;
                Grd_TDS.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}
