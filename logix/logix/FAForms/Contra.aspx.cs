using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Runtime.Remoting;

namespace logix.FAForm
{
    public partial class Contra : System.Web.UI.Page
    {
        int vouno;
        string strantype;
        bool blnErr;
        bool blnErr1;
        double totdbAmnt;
        double totcramnt;
        int ledgerid;
        double vouamnt;
        int intBnkLedgID;
        bool Bln_ChkMinMaxAmt;
        int contrano;
        int voutypeid;
        int vouyear;
        bool BlnVouChk;
        string strcheck;
        DateTime condate;
        DateTime joudate;
        int voucherid;
        string ledgername;
        string strto;
        string ledgeropstype;
        string strtype;
        string fcur;
        double famt;
        double exrate;
        string cledgerid;

        string Ctrl_List;
        string Data_List;
        string Msg_List;
        int Vou_ID;
        string Ctrl_List1;
        string Data_List1;
        string Msg_List1;
        bool flag;
        int bid;
        int lbranchid;
        DataAccess.LogDetails da_obj_lD = new DataAccess.LogDetails();
        DataAccess.Masters.MasterBranch Master_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.Journal Jnlobj = new DataAccess.Accounts.Journal();
        DataAccess.FAMaster.ReportView da_obj_rv = new DataAccess.FAMaster.ReportView();
        DataAccess.FAVoucher da_obj_vou = new DataAccess.FAVoucher();
        DataAccess.LogDetails obj_Log = new DataAccess.LogDetails();

        DataAccess.FAMaster.MasterLedger obj_ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Accounts.Payment obj_pymt = new DataAccess.Accounts.Payment();
        DataAccess.FAVoucher obj_fa = new DataAccess.FAVoucher();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_lD.GetDataBase(Ccode);
                Master_Branch.GetDataBase(Ccode);
                Jnlobj.GetDataBase(Ccode);
                da_obj_rv.GetDataBase(Ccode);
                da_obj_vou.GetDataBase(Ccode);
                obj_Log.GetDataBase(Ccode);
                obj_ledger.GetDataBase(Ccode);
                obj_pymt.GetDataBase(Ccode);
                obj_fa.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                
            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_header.Text = Request.QueryString["FormName"].ToString();
            }
            if (IsPostBack != true)
            {

                lbnl_logyear.Text = Session["LYEAR"].ToString();
                hid_BaseCurr.Value = Session["Basecurr"].ToString();
                ddl_crdr.Enabled = false;
                txt_amount.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txt_amt.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                txt_exrate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'EX-Rate')");
                txt_contra.Attributes.Add("Onkeypress", "return IntegerCheck(event);");
                txt_total1.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                txt_total2.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Amount')");
                btn_chqprint.Visible = false;
                idprint.Visible = false;
                //DataAccess.LogDetails da_obj_lD = new DataAccess.LogDetails();
               
                
              /*  joudate = da_obj_lD.GetDate();

                hf_Date.Value = joudate.ToString();
                txt_date.Text = Utility.fn_ConvertDate(joudate.ToShortDateString());            
                condate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                txt_date.ReadOnly = true;

                */


                int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime Date = da_obj_rv.MaxVouGetDate(Session["FADbname"].ToString());

                if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                {
                    joudate = da_obj_lD.GetDate();

                    hf_Date.Value = joudate.ToString();
                    txt_date.Text = Utility.fn_ConvertDate(joudate.ToShortDateString());
                    condate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                    txt_date.ReadOnly = true;
                    // lbl_header.Text = "Contra";
                }
                else
                {
                    txt_date.Text = "31/03/" + (Vouyear + 1);
                    condate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                    hf_Date.Value = condate.ToString();
                    txt_date.ReadOnly = true;
                    // lbl_header.Text = "ContraBackDated";

                }



               // txt_exrate.Visible = false;
                grd_Contra.DataSource = new DataTable();
                grd_Contra.DataBind();

                if (Request.QueryString.ToString().Contains("Vno"))
                {
                    vouno = Convert.ToInt32(Request.QueryString["Vno"]);
                    txt_contra.Text = vouno.ToString();
                    txt_date.Text = Request.QueryString["Vdate"];
                    lbranchid = Convert.ToInt32(Request.QueryString["PBranch_ID"]);
                    hid_BranchID.Value = lbranchid.ToString();
                     btn_cancel.Text = "Back";
                    btn_cancel.ToolTip = "Back";
                    btn_cancel1.Attributes["class"] = "btn ico-back";
                    if (Request.QueryString.ToString().Contains("flag"))
                    {
                        hf_flag.Value = (Request.QueryString["flag"].ToString());
                        hf_vid.Value = (Request.QueryString["vid"].ToString());
                        hidfdate.Value = (Request.QueryString["fdate"].ToString());
                        hidtdate.Value = (Request.QueryString["tdate"].ToString());
                        hidvoutype.Value = (Request.QueryString["type"].ToString());
                    }

                    fn_LoadContraDetails();
                }

                if (Request.QueryString.ToString().Contains("QueryVoucherName"))
                {
                    txt_contra.Text = Request.QueryString["QueryVoucherNo"].ToString();
                    fn_LoadContraDetails();
                }
            }

            strantype = Session["str_ModuleName"].ToString();
        }

        protected void txt_contra_TextChanged(object sender, EventArgs e)
        {
            if (txt_contra.Text.ToString().Trim().Length > 0)
            {
                fn_LoadContraDetails();
            }
        }

        private void fn_LoadContraDetails()
        {
            int Branch_ID;
            int int_voutypeid = 0;
            DataTable obj_dt_contra = new DataTable();
            if (hid_BranchID.Value != "" && hid_BranchID.Value != "0")
            {
                Branch_ID = Convert.ToInt32(hid_BranchID.Value);
            }
            else
            {
                Branch_ID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }

            //DataAccess.FAVoucher da_obj_vou = new DataAccess.FAVoucher();
            int_voutypeid = da_obj_vou.Selvoutypeid("Contra", Session["FADbname"].ToString());
            Vou_ID = da_obj_vou.GetVouId(Convert.ToInt32(txt_contra.Text), Branch_ID, int_voutypeid, Session["FADbname"].ToString());
            Hid_VouID.Value = Vou_ID.ToString();

            obj_dt_contra = da_obj_vou.SelFAvoucherHeadWOMonth(Branch_ID, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToInt32(txt_contra.Text.ToString()), int_voutypeid, Session["FADbname"].ToString());

            if (obj_dt_contra.Rows.Count > 0)
            {
                txt_date.Text = Utility.fn_ConvertDate(obj_dt_contra.Rows[0]["voudate"].ToString());
                txt_naration.Text = obj_dt_contra.Rows[0]["Narration"].ToString();
                txt_chqno.Text = obj_dt_contra.Rows[0]["Chequeno"].ToString();
                txt_favour.Text = obj_dt_contra.Rows[0]["fvrname"].ToString();
                DataTable obj_dt_cdet = new DataTable();
                obj_dt_cdet = da_obj_vou.SelFAvoucherDetailsWOMonth(Branch_ID, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToInt32(txt_contra.Text.ToString()), int_voutypeid, Session["FADbname"].ToString());

                if (obj_dt_cdet.Rows.Count > 0)
                {
                    grd_Contra.DataSource = obj_dt_cdet;
                    grd_Contra.DataBind();
                    double dbl_totdbamt = 0;
                    double dbl_totcramt = 0;

                    for (int i = 0; i <= grd_Contra.Rows.Count - 1; i++)
                    {
                        if (grd_Contra.Rows[i].Cells[2].Text != "")
                        {
                            dbl_totdbamt = dbl_totdbamt + Convert.ToDouble(grd_Contra.Rows[i].Cells[2].Text);
                        }

                        if (grd_Contra.Rows[i].Cells[3].Text != "")
                        {
                            dbl_totcramt = dbl_totcramt + Convert.ToDouble(grd_Contra.Rows[i].Cells[3].Text);
                        }

                    }
                    txt_total1.Text = dbl_totdbamt.ToString();
                    txt_total2.Text = dbl_totcramt.ToString();

                    btn_save.Enabled = false;
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Enter the valid Contra #')", true);
                txt_contra.Focus();
                return;
            }
        }

        protected void grd_Contra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "Dr")
                {
                    e.Row.Cells[3].Text = "";
                    if (e.Row.Cells[2].Text == "CASH")
                    {
                        btn_chqprint.Enabled = false;
                    }
                }
                if (e.Row.Cells[0].Text == "Cr")
                {
                    e.Row.Cells[2].Text = "";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp" || e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_Contra, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btn_chqprint_Click(object sender, EventArgs e)
        {
            if (txt_contra.Text == "")
            {
                return;
            }
            //DataAccess.LogDetails obj_Log = new DataAccess.LogDetails();

            string sp = "";
            string sf;

            sf = "{MasterVoucherHead.vouno}=" + txt_contra.Text + "and {VoucherDetails.LedgerType}='Cr' and {MasterVoucherHead.voutype}=14 and {MasterVoucherHead.branchid}=" + Session["LoginBranchid"] + "and {MasterVoucherHead.divisionid}=" + Session["LoginDivisionId"];
            sp = "PeriodFrom^" + "Apr11" + "~PeriodTo^" + "Mar12";
            sp = "";

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                //obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1106, 4, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text.ToString() + "/" + txt_date.Text.ToString() + "/V");
                obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1106, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text.ToString() + "/" + txt_date.Text.ToString() + "/V");
            }
            else
            {
               // obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1190, 4, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text.ToString() + "/" + txt_date.Text.ToString() + "/V");
                obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1190, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text.ToString() + "/" + txt_date.Text.ToString() + "/V");
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.FAMaster.MasterLedger obj_ledger = new DataAccess.FAMaster.MasterLedger();
                //DataAccess.Accounts.Payment obj_pymt = new DataAccess.Accounts.Payment();
                //DataAccess.FAVoucher obj_fa = new DataAccess.FAVoucher();
                //DataAccess.LogDetails obj_Log = new DataAccess.LogDetails();
                vouyear = da_obj_lD.GetDate().Year - 1;
             
                if (btn_save.ToolTip == "Save")
                {
                    Checkdata();
                    if (blnErr == true)
                    {
                        blnErr = false;
                        return;
                    }
                    totdbAmnt = Convert.ToDouble(txt_total1.Text.ToString());
                    totcramnt = Convert.ToDouble(txt_total2.Text.ToString());
                    DataTable Dt_Bnk = new DataTable();
                    for (int k = 0; k <= grd_Contra.Rows.Count - 1; k++)
                    {
                        ledgerid = Convert.ToInt32(grd_Contra.DataKeys[k].Values["ledgerid"].ToString());
                        if (grd_Contra.Rows[k].Cells[2].Text != "")
                        {
                            vouamnt = Convert.ToDouble(grd_Contra.Rows[k].Cells[2].Text);
                            strtype = "Dr";
                        }
                        if (grd_Contra.Rows[k].Cells[3].Text != "")
                        {
                            strtype = "Cr";
                            vouamnt = Convert.ToDouble(grd_Contra.Rows[k].Cells[3].Text);
                        }
                        Dt_Bnk = obj_ledger.GetBank4Contra(ledgerid, Session["FADbname"].ToString());
                        string result1 = "";
                        if (Dt_Bnk.Rows.Count > 0)
                        {
                            intBnkLedgID = Convert.ToInt32(Dt_Bnk.Rows[0]["ledgerid"]);
                            result1 = obj_pymt.CheckMedgerMaxMinAmtchk4Conta(intBnkLedgID, Convert.ToInt32(Session["LoginDivisionId"]), vouamnt, Session["FADbname"].ToString());
                            Bln_ChkMinMaxAmt = obj_pymt.CheckMedgerMaxMinAmtchk4Contastep2(intBnkLedgID, Convert.ToInt32(Session["LoginDivisionId"]), vouamnt, Session["FADbname"].ToString(), strtype,result1);
                            if (Bln_ChkMinMaxAmt == true)
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Valid", "alertify.alert('Closing Balance has Crossed the maximum limit. You can not able to Transfer the Amount')", true);
                                return;
                            }
                        }else
                        {
                            if (grd_Contra.Rows[k].Cells[1].Text.Contains("PETTYCASH-"))
                            {
                                intBnkLedgID = ledgerid;
                                result1 = obj_pymt.CheckMedgerMaxMinAmtchk4Conta(intBnkLedgID, Convert.ToInt32(Session["LoginDivisionId"]), vouamnt, Session["FADbname"].ToString());
                                Bln_ChkMinMaxAmt = obj_pymt.CheckMedgerMaxMinAmtchk4Contastep2(intBnkLedgID, Convert.ToInt32(Session["LoginDivisionId"]), vouamnt, Session["FADbname"].ToString(), strtype, result1);
                                if (Bln_ChkMinMaxAmt == true)
                                {

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Valid", "alertify.alert('Closing Balance has Crossed the maximum limit. You can not able to Transfer the Amount')", true);
                                    return;
                                }
                            }
                        }
                    }

                    if (totdbAmnt == totcramnt && totdbAmnt != 0 && totcramnt != 0)
                    {
                       // contrano = obj_fa.GetJournalNo(Convert.ToInt32(Session["LoginBranchid"]));
                        if (lbl_header.Text == "ContraBackDated")
                        {
                            contrano = obj_fa.GetContraNo4BackDated(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LogYear"].ToString()));
                        }
                        else
                        {
                            contrano = obj_fa.GetJournalNo(Convert.ToInt32(Session["LoginBranchid"]));
                        }
                        txt_contra.Text = contrano.ToString();
                        voutypeid = obj_fa.Selvoutypeid("Contra", Session["FADbname"].ToString());
                        if (obj_fa.CheckFAExists4Voucher(contrano, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), voutypeid, Session["FADbname"].ToString()) == 0)
                        {
                            BlnVouChk = false;
                        }
                        else
                        {
                            if (strcheck != "0")
                            {
                                strcheck = strcheck + "," + contrano;
                            }
                            else
                            {
                                strcheck = Convert.ToString(contrano);
                            }
                            BlnVouChk = true;

                        }
                        if (BlnVouChk == false)
                        {
                            voucherid = obj_fa.InsFAVouHead(Session["FADbname"].ToString(), voutypeid, contrano.ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), txt_naration.Text.ToString(), "FA", 0, 0, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), obj_Log.GetDate(), 'N', Convert.ToInt32(Session["LogYear"].ToString()));
                            if (voucherid != 0)
                            {
                                obj_fa.UpdateFAVouHeadDetails(Session["FADbname"].ToString(), "Contra", voucherid, txt_chqno.Text.ToString(), 0, txt_favour.Text.ToString());
                                for (int i = 0; i <= grd_Contra.Rows.Count - 1; i++)
                                {
                                    strto = grd_Contra.Rows[i].Cells[0].Text;
                                    //GrdToby opstype
                                    ledgername = grd_Contra.Rows[i].Cells[1].Text;
                                    ledgeropstype = grd_Contra.DataKeys[i].Values["opstype"].ToString();
                                    ledgerid = Convert.ToInt32(grd_Contra.DataKeys[i].Values["ledgerid"].ToString());
                                    if (grd_Contra.Rows[i].Cells[2].Text != "")
                                    {
                                        strtype = "Dr";
                                        vouamnt = Convert.ToDouble(grd_Contra.Rows[i].Cells[2].Text);
                                    }
                                    if (grd_Contra.Rows[i].Cells[3].Text != "")
                                    {
                                        strtype = "Cr";
                                        vouamnt = Convert.ToDouble(grd_Contra.Rows[i].Cells[3].Text);
                                    }
                                    obj_fa.InsFAVouDetails(Session["FADbname"].ToString(), voucherid, ledgerid, strtype, vouamnt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                    fcur = grd_Contra.Rows[i].Cells[4].Text;
                                    famt = Convert.ToDouble(grd_Contra.Rows[i].Cells[5].Text);
                                    exrate = Convert.ToDouble(grd_Contra.Rows[i].Cells[6].Text);
                                    obj_fa.SPFAUpdFAVouDtls4Fcur(Session["FADbname"].ToString(), voucherid, fcur, famt, exrate, ledgerid, strtype, Convert.ToInt32(Session["LogYear"].ToString()));
                                }

                            }

                            if (Session["str_ModuleName"].ToString() == "FA")
                            {
                                obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1932, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text.ToString() + "/" + txt_date.Text.ToString() + "/ S");
                            }
                            else if (Session["str_ModuleName"].ToString() == "FC")
                            {
                                obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1957, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text.ToString() + "/" + txt_date.Text.ToString() + "/ S");
                            }

                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Valid", "alertify.alert('Contra Details Saved. Contra # : " + txt_contra.Text + "');", true);
                            txt_contra.Text = contrano.ToString();
                            btn_save.Text = "Update";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn ico-update";
                            btn_cancel.Text = "Cancel";
                            btn_cancel.ToolTip = "Cancel";
                            btn_cancel1.Attributes["class"] = "btn ico-cancel";
                            ClearAll();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Valid", "alertify.alert('Both Credit and Debit Amount Should Match')", true);
                        return;
                    }

                }
                //else
                //{
                //    totdbAmnt = Convert.ToDouble(txt_total1.Text.ToString());
                //    totcramnt = Convert.ToDouble(txt_total2.Text.ToString());
                //    if (totdbAmnt == totcramnt)
                //    {
                //        voutypeid = obj_fa.Selvoutypeid("Contra", Session["FADbname"].ToString());
                //        voucherid = obj_fa.SelJouVouid(Convert.ToInt32(txt_contra.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), voutypeid, Convert.ToInt32(Session["LogYear"].ToString()), Session["FADbname"].ToString());
                       
                      
                //        //obj_fa.UpdJournalHead(txt_naration.Text.ToString(), Convert.ToInt32(txt_contra.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), voutypeid, Convert.ToInt32(Session["LogYear"].ToString()), Session["FADbname"].ToString());
                      
                //        //voucherid = obj_fa.SelJouVouid(Convert.ToInt32(txt_contra.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), voutypeid, Convert.ToInt32(Session["LogYear"].ToString()), Session["FADbname"].ToString());
                //        //obj_fa.UpdJouledgerdetails(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), voucherid);
                //        //voutypeid = obj_fa.Selvoutypeid("Contra", Session["FADbname"].ToString());
                //        //Jnlobj.DelVouDetails(voutypeid, Session["FADbname"].ToString());
                //        if (voucherid != 0)
                //        {
                //            for (int i = 0; i < grd_Contra.Rows.Count; i++)
                //            {
                //                int index = grd_Contra.SelectedRow.RowIndex;
                //                strto = grd_Contra.Rows[i].Cells[0].Text;
                //                ledgername = grd_Contra.Rows[i].Cells[1].Text;
                //                ledgeropstype = grd_Contra.DataKeys[i].Values["opstype"].ToString();
                //                ledgerid = Convert.ToInt32(grd_Contra.DataKeys[i].Values["ledgerid"].ToString());
                //                if (grd_Contra.Rows[i].Cells[2].Text !="")
                //                {
                //                    strtype = "Dr";
                //                    vouamnt = Convert.ToDouble(grd_Contra.Rows[i].Cells[2].Text);
                //                }
                //                if (grd_Contra.Rows[i].Cells[3].Text != "")
                //                {
                //                    strtype = "Cr";
                //                    vouamnt = Convert.ToDouble(grd_Contra.Rows[i].Cells[3].Text);
                //                }
                //                //VoucherHead Updated
                //                obj_fa.UpdateFAVouHeadDetails(Session["FADbname"].ToString(), "Contra", voucherid, txt_chqno.Text.ToString().Trim(), 0, txt_favour.Text.ToString().Trim());
                //              // obj_fa.UpdJouledgerdetails(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), voucherid);
                //               // obj_fa.InsFAVouDetails(Session["FADbname"].ToString(), voucherid, ledgerid, strtype, vouamnt, Convert.ToInt32(Session["LogYear"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                //                fcur = grd_Contra.Rows[i].Cells[4].Text;
                //                famt = Convert.ToDouble(grd_Contra.Rows[i].Cells[5].Text);
                //                exrate = Convert.ToDouble(grd_Contra.Rows[i].Cells[6].Text);
                //                obj_fa.SPFAUpdVouDtls4Fcur(Session["FADbname"].ToString(), voucherid, fcur, famt, exrate, ledgerid, strtype, Convert.ToInt32(Session["LogYear"].ToString()));

                //            }

                //        }
                //        if (Session["str_ModuleName"].ToString() == "FA")
                //        {
                //            obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1106, 2, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text.ToString() + "/" + txt_date.Text.ToString() + "/ U");
                //        }
                //        else if (Session["str_ModuleName"].ToString() == "FC")
                //        {
                //            obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1190, 2, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text.ToString() + "/" + txt_date.Text.ToString() + "/ U");

                //        }
                //        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Valid", "alertify.alert('Entry Updated')", true);
                //        ClearAll();

                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Valid", "alertify.alert(' Both Credit and Debit Amount Should Match')", true);
                //        return;
                //    }
                //}

                if (strcheck != "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Valid", "alertify.alert(' Voucher Number " + strcheck + " Already exists')", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void ClearAll()
        {           
            txt_lgrname.Text = "";
            txt_amount.Text = "";
            txt_contra.Text = "";
            txt_exrate.Text = "";
            txt_naration.Text = "";
            txt_total1.Text = "";
            txt_total2.Text = "";
            txt_chqno.Text = "";
            txt_favour.Text = "";
            grd_Contra.DataSource = new DataTable();
            grd_Contra.DataBind();
            txt_lgrname.Enabled = true;
            dd_ltype.SelectedIndex = -1;
            ddl_crdr.SelectedIndex = -1;          
            txt_contra.Focus();           
            ViewState["Contra_Ledger"] = null;
            btn_add.Text = "Add";
            btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
       btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
           btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
           // txt_date.Text = Utility.fn_ConvertDate(da_obj_lD.GetDate().ToShortDateString()); 

            int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
            string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime Date = da_obj_rv.MaxVouGetDate(Session["FADbname"].ToString());

            if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
            {
                joudate = da_obj_lD.GetDate();

                hf_Date.Value = joudate.ToString();
                txt_date.Text = Utility.fn_ConvertDate(joudate.ToShortDateString());
                condate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                txt_date.ReadOnly = true;
                lbl_header.Text = "Contra";
            }
            else
            {
                txt_date.Text = "31/03/" + (Vouyear + 1);
                condate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
                hf_Date.Value = condate.ToString();
                txt_date.ReadOnly = true;
                lbl_header.Text = "ContraBackDated";

            }
        }


        public void Checkdata()
        {
            if (txt_total1.Text.Trim().Length == 0 || txt_total2.Text.Trim().Length == 0)
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "Valid", "alertify.alert('Without Particulars, Contra Cannot be Saved')", true);
                blnErr = true;
                return;
            }

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Back")
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
            else
            {
                ClearAll();
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
                if (Request.QueryString["Str_Name"] == "DayBook_Contra")
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

        protected void btn_view_Click(object sender, EventArgs e)
        {
            if (Hid_VouID.Value == "" || Hid_VouID.Value == "0")
            {
                return;
            }
            string sp = "";
            string sf;
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            string BranchName = Master_Branch.Getbranchname(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            //DataAccess.FAVoucher da_obj_vou = new DataAccess.FAVoucher();

            da_obj_vou.SelFAAllVoucher(Convert.ToInt32(Hid_VouID.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());

            Str_RptName = "rptContra1.rpt";
            //Session["str_sfs"] = "{MasterVoucherHead.vouno}=" + txt_contra.Text + " and {MasterVoucherHead.voutype}=14 and {MasterVoucherHead.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {MasterVoucherHead.divisionid}= " + Convert.ToInt32(Session["LoginDivisionId"]);
            Session["str_sfs"] = " {Tempvoucher.vouid}=" + Hid_VouID.Value + "And {Tempvoucher.empid} = " + Session["LoginEmpId"].ToString();
            Session["str_sp"] = "PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2);
            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);

            //if (BranchName == "CORPORATE")
            //{
            //    da_obj_lD.InsLogDetail((Convert.ToInt32(Session["LoginEmpId"])), 1106, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text + "/" + txt_date.Text + "/ V");
            //}

            //if (BranchName != "CORPORATE")
            //{
            //    da_obj_lD.InsLogDetail((Convert.ToInt32(Session["LoginEmpId"])), 1106, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text + "/" + txt_date.Text + "/ V");
            //}

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                da_obj_lD.InsLogDetail((Convert.ToInt32(Session["LoginEmpId"])), 1106, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text + "/" + txt_date.Text + "/ V");
            }
            else
            {
                da_obj_lD.InsLogDetail((Convert.ToInt32(Session["LoginEmpId"])), 1190, 3, Convert.ToInt32(Session["LoginBranchid"]), txt_contra.Text + "/" + txt_date.Text + "/ V");
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                bool ledbool = false;
                fcur = "";
                famt = 0;
                exrate = 0;

                CheckData_Add();

                if (blnErr == true)
                {
                    blnErr = false;
                    return;
                }

                fcur = txt_currency.Text;

                if (txt_amt.Text != "")
                {
                    famt = Convert.ToDouble(txt_amt.Text);
                }

                if (txt_exrate.Text != "")
                {
                    exrate = Convert.ToDouble(txt_exrate.Text);
                }

                DataTable dt_contra = new DataTable();
                dt_contra = (DataTable)ViewState["Contra_Ledger"];

                if (ViewState["Contra_Ledger"] == null)
                {
                    dt_contra = new DataTable();
                    DataColumn dc_col1 = new DataColumn("LedgerType", typeof(string));
                    DataColumn dc_col2 = new DataColumn("ledgername", typeof(string));
                    DataColumn dc_col3 = new DataColumn("LedgerAmount", typeof(double));
                    DataColumn dc_col4 = new DataColumn("fcur", typeof(string));
                    DataColumn dc_col5 = new DataColumn("famt", typeof(double));
                    DataColumn dc_col6 = new DataColumn("exrate", typeof(double));
                    DataColumn dc_col7 = new DataColumn("opstype", typeof(string));
                    DataColumn dc_col8 = new DataColumn("ledgerid", typeof(Int32));
                    DataColumn dc_col9 = new DataColumn("vousubid", typeof(Int32));

                    dt_contra.Columns.Add(dc_col1);
                    dt_contra.Columns.Add(dc_col2);
                    dt_contra.Columns.Add(dc_col3);
                    dt_contra.Columns.Add(dc_col4);
                    dt_contra.Columns.Add(dc_col5);
                    dt_contra.Columns.Add(dc_col6);
                    dt_contra.Columns.Add(dc_col7);
                    dt_contra.Columns.Add(dc_col8);
                    dt_contra.Columns.Add(dc_col9);
                }

                DataRow dr;
                if (btn_add.ToolTip == "Add")
                {
                    // Check Ledger already Exists

                    if (ddl_crdr.SelectedItem.Text != "" && txt_lgrname.Text != "" && dd_ltype.SelectedItem.Text != "" && txt_amount.Text != "")
                    {
                        ledbool = false;

                        if (grd_Contra.Rows.Count > 0)
                        {
                            for (int i = 0; i <= grd_Contra.Rows.Count - 1; i++)
                            {
                                if (grd_Contra.DataKeys[i].Values[2].ToString() == hf_ldgrid.Value)
                                {
                                    ledbool = true;
                                }
                            }
                        }

                        if (ledbool == true)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Ledger Already Exists');", true);
                            txt_lgrname.Focus();
                            return;
                        }
                    }

                    dr = dt_contra.NewRow();
                    if (ddl_crdr.SelectedItem.Text != "")
                    {
                        dr["LedgerType"] = ddl_crdr.SelectedItem.Text;
                        dr["ledgername"] = txt_lgrname.Text.ToString();

                        if (dd_ltype.SelectedItem.Text == "Debit")
                        {
                            dr["LedgerAmount"] = Convert.ToDouble(txt_amount.Text);
                        }
                        else
                        {
                            dr["LedgerAmount"] = Convert.ToDouble(txt_amount.Text);
                        }

                        dr["opstype"] = "C";
                        dr["fcur"] = fcur;
                        dr["famt"] = famt;
                        dr["exrate"] = exrate;
                        dr["vousubid"] = 0;
                        dr["ledgerid"] = Convert.ToInt32(hf_ldgrid.Value);
                        dt_contra.Rows.Add(dr);

                        grd_Contra.DataSource = dt_contra;
                        grd_Contra.DataBind();
                        ViewState["Contra_Ledger"] = dt_contra;
                    }
                }
                else
                {
                    if (ddl_crdr.SelectedItem.Text != "" && txt_lgrname.Text != "" && dd_ltype.SelectedItem.Text != "" && txt_amount.Text != "")
                    {
                        for (int i = 0; i <= grd_Contra.Rows.Count - 1; i++)
                        {
                            cledgerid = grd_Contra.SelectedDataKey["ledgerid"].ToString();
                            if (cledgerid.ToString() != "")
                            {
                                int index = grd_Contra.SelectedRow.RowIndex;
                                grd_Contra.Rows[index].Cells[0].Text = ddl_crdr.SelectedItem.Text;
                                grd_Contra.Rows[index].Cells[1].Text = txt_lgrname.Text;
                                if (dd_ltype.SelectedItem.Text == "Credit")
                                {
                                     grd_Contra.Rows[index].Cells[3].Text  = Convert.ToDouble(txt_amount.Text).ToString();
                                     grd_Contra.Rows[index].Cells[2].Text = "";
                                }
                                else
                                {
                                    grd_Contra.Rows[index].Cells[3].Text = "";
                                     grd_Contra.Rows[index].Cells[2].Text  = Convert.ToDouble(txt_amount.Text).ToString();
                                }
                                grd_Contra.Rows[index].Cells[4].Text = txt_currency.Text;
                                grd_Contra.Rows[index].Cells[6].Text = Convert.ToDouble(txt_exrate.Text).ToString() ;
                                grd_Contra.Rows[index].Cells[5].Text = Convert.ToDouble(txt_amt.Text).ToString();

                            }
                        }
                    }
                }

                if (grd_Contra.Rows.Count > 0)
                {
                    totdbAmnt = 0;
                    totcramnt = 0;

                    for (int i = 0; i <= grd_Contra.Rows.Count - 1; i++)
                    {
                        if (grd_Contra.Rows[i].Cells[2].Text != "")
                        {
                            totdbAmnt = totdbAmnt + Convert.ToDouble(grd_Contra.Rows[i].Cells[2].Text);
                        }

                        if (grd_Contra.Rows[i].Cells[3].Text != "")
                        {
                            totcramnt = totcramnt + Convert.ToDouble(grd_Contra.Rows[i].Cells[3].Text);
                        }
                    }

                    txt_total1.Text = string.Format("{0:0.00}", totdbAmnt);
                    txt_total2.Text = string.Format("{0:0.00}", totcramnt);
                }

                ddl_crdr.SelectedIndex = -1;
                txt_lgrname.Text = "";
                dd_ltype.SelectedIndex = -1;
                txt_amount.Text = "";
                ddl_crdr.Enabled = false;
                txt_lgrname.Enabled = true;
                txt_currency.Text = "";
                txt_amt.Text = "";
                txt_exrate.Text = "";
                //btn_add.Text = "Add";
                btn_add.ToolTip = "Add";

                
                btn_add1.Attributes["class"] = "btn ico-add";
                if (txt_contra.Text != "")
                {
                  btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void dd_ltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dd_ltype.SelectedItem.Text == "Debit")
            {
                ddl_crdr.SelectedValue = "1";                  
            }
            else
            {
                ddl_crdr.SelectedValue = "2";
            }
        }

        protected void txt_amt_TextChanged(object sender, EventArgs e)
        {
            if (txt_amt.Text.Length > 0 && txt_exrate.Text.Length > 0)
            {
                txt_amount.Text = (Convert.ToInt32(txt_amt.Text) * Convert.ToDouble(txt_exrate.Text)).ToString();
            }
            else
            {
                txt_amount.Text = "";
            }
        }

        protected void txt_exrate_TextChanged(object sender, EventArgs e)
        {
            txt_amt.Focus();
            if (txt_amt.Text.Length > 0 && txt_exrate.Text.Length > 0)
            {
                
                txt_amount.Text = (Convert.ToInt32(txt_amt.Text) * Convert.ToDouble(txt_exrate.Text)).ToString();

            }
            else
            {
                txt_amount.Text = "";
            }
        }

        protected void grd_Contra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grd_Contra.Rows.Count > 0)
                {
                    int index = grd_Contra.SelectedRow.RowIndex;
                    ddl_crdr.SelectedItem.Text = grd_Contra.Rows[index].Cells[0].Text.ToString();
                    txt_lgrname.Text = grd_Contra.Rows[index].Cells[1].Text.ToString();

                    if (ddl_crdr.SelectedItem.Text == "Dr")
                    {
                        dd_ltype.SelectedItem.Text = "Debit";
                        txt_amount.Text = string.Format("{0:0.00}", grd_Contra.Rows[index].Cells[2].Text.ToUpper());
                    }
                    else
                    {
                        dd_ltype.SelectedItem.Text = "Credit";
                        txt_amount.Text = string.Format("{0:0.00}", grd_Contra.Rows[index].Cells[3].Text.ToUpper());
                    }

                    txt_currency.Text = grd_Contra.Rows[index].Cells[4].Text.ToUpper();
                    txt_exrate.Text = string.Format("{0:0.00}", grd_Contra.Rows[index].Cells[6].Text);
                    //txt_amt.Text = string.Format("{0:0.00}", grd_Contra.Rows[index].Cells[5].Text);
                    ddl_crdr.Enabled = false;
                    txt_lgrname.Enabled = false;
                    btn_add.Text = "Update";
                    btn_add.ToolTip = "Update";
                    
                    btn_add1.Attributes["class"] = "btn ico-update";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void CheckData_Add()
        {
            if (txt_lgrname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter the Ledger Name')", true);
                txt_lgrname.Text = "";
                txt_lgrname.Focus();
                blnErr = true;
                return;
            }

            if (txt_amount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Amount cannot be Blank')", true);
                txt_amount.Text = "";
                txt_amount.Focus();
                blnErr = true;
                return;
            }

            if (btn_add.ToolTip == "Add")
            {
                if (dd_ltype.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Type')", true);
                    dd_ltype.Focus();
                    blnErr = true;
                    return;
                }
            }
        }

        protected void txt_currency_TextChanged(object sender, EventArgs e)
        {
            if(txt_currency.Text.ToUpper()==hid_BaseCurr.Value)
            {
                txt_exrate.Enabled = false;
                txt_exrate.Text = "1";
                txt_amt.Focus();
            }
            else
            {
                txt_exrate.Enabled = true;
                txt_exrate.Focus();
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
           // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (lbl_header.Text == "ContraBackDated")
            {


                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1932, "", "", "", Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1957, "", "", "", Session["StrTranType"].ToString());
                }
            }

            else
            {
                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1106, "", "", "", Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1190, "", "", "", Session["StrTranType"].ToString());
                }
            }
       

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_Contra_PreRender(object sender, EventArgs e)
        {
            if (grd_Contra.Rows.Count > 0)
            {
                grd_Contra.UseAccessibleHeader = true;
                grd_Contra.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


    }
}