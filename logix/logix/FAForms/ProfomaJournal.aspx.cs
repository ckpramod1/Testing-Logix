using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Data;

namespace logix.FAForm
{
    public partial class ProfomaJournal : System.Web.UI.Page
    {
        int year, Int_NoOfDays, month, vtypeid, vouno, vouid, Vouyear, voucherid, index, ledgerid, strresult, vousubid, bid;
        string strtype, strantype, strcheck, ledgername, Trantype, status;
        double totdbAmnt, totcramnt, vouamnt;
        DateTime vdate, joudate;
        string fcur;        //NewOne        //07/07/2022
        double famt;
        double exrate;
        bool recedit, blnErr;
        DataTable Dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dtt = new DataTable();
        DataTable dtcom = new DataTable();

        DataAccess.Accounts.Journal Jnlobj = new DataAccess.Accounts.Journal();
        DataAccess.Accounts.ProJournal ProJnlobj = new DataAccess.Accounts.ProJournal();
        DataAccess.FAMaster.MasterLedger ledgerobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Masters.MasterBranch Master_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.ComTVBackDateRights Obj_BckDateRights = new DataAccess.ComTVBackDateRights();
        DataAccess.FAVoucher faobj = new DataAccess.FAVoucher();
        DataAccess.FAVoucher obj_fa = new DataAccess.FAVoucher();         //NewOne    //07/07/2022
        DataAccess.Accounts.Recipts Bank_Obj = new DataAccess.Accounts.Recipts();


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Jnlobj.GetDataBase(Ccode);
                ProJnlobj.GetDataBase(Ccode);
                ledgerobj.GetDataBase(Ccode);
                Master_Branch.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                Obj_BckDateRights.GetDataBase(Ccode);
                faobj.GetDataBase(Ccode);
                obj_fa.GetDataBase(Ccode);


                Bank_Obj.GetDataBase(Ccode);
               

            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lblheader.Text = Request.QueryString["FormName"].ToString();
            }
            hid_BaseCurr.Value = Session["BaseCurr"].ToString();

            if (IsPostBack != true)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                string vtypes;
                txtdate.Enabled = true;
                ddl_CrrDb.Enabled = false;
                joudate = Logobj.GetDate();
                hf_Date.Value = joudate.ToString();
                txtdate.Text = Utility.fn_ConvertDate(joudate.ToString());

                if (joudate.Month < 4)
                {
                    txtvouyear.Text = (joudate.Year - 1).ToString();
                }
                else
                {
                    txtvouyear.Text = joudate.Year.ToString();
                }
                txtmonth.Text = joudate.Month.ToString();


                if (Request.QueryString.ToString().Contains("Vno"))
                {
                    vouno = Convert.ToInt32(Request.QueryString["Vno"]);
                    txtjnlno.Text = vouno.ToString();
                    vdate = Convert.ToDateTime(Utility.fn_ConvertDate(Request.QueryString["Vdate"]));
                    vtypes = Request.QueryString["VType"];
                    txtdate.Text = Request.QueryString["Vdate"];
                    btncancel.Text = "Back";
                    btncancel.ToolTip = "Back";
                    btn_cancel1.Attributes["class"] = "btn ico-back";
                    GetJournalDet();
                    txtdate.Enabled = false;
                }

                if (Request.QueryString.ToString().Contains("QueryVoucherName"))
                {
                    txtjnlno.Text = Request.QueryString["QueryVoucherNo"].ToString();
                    GetJournalDet();
                }

                grd_journal.DataSource = new DataTable();
                grd_journal.DataBind();
            }

            Int_NoOfDays = 0;
            dtcom = Obj_BckDateRights.SelCtBDtRights(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()));

            if (dtcom.Rows.Count > 0)
            {
                Int_NoOfDays = Convert.ToInt32(dtcom.Rows[0]["noofdays"].ToString());
            }
            else
            {
                Int_NoOfDays = 0;
            }
            status = faobj.getfinalize(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());

            if (status == "Y")
            {
                btnsave.Enabled = false;
                //btnadd.Enabled = false;
                btndel.Enabled = false;
            }

            hid_Vouyear.Value = txtdate.Text;
            strantype = Session["str_ModuleName"].ToString();
        }


        [WebMethod]
        public static List<string> GetLedgerName_Journal(string prefix)
        {
            List<string> LedgerName = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Journal da_obj_Journal = new DataAccess.Accounts.Journal();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Journal.GetDataBase(Ccode);
            obj_dt = da_obj_Journal.GetLikeLedgernameforjournal(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            //LedgerName = Utility.Fn_TableToList(obj_dt, "ledgername", "ledgerid");
            LedgerName = Utility.Fn_TableToList(obj_dt, "LNandPort", "Ledgerid", "opstype");
            return LedgerName;
        }

        public void GetJournalDet()
        {
            recedit = false;
            int voumonth = vdate.Month;
            DataTable Dt2 = new DataTable();
            vtypeid = Jnlobj.Selvoutypeid("Journal", Session["FADbname"].ToString());
            if (txtjnlno.Text != "")
            {
                Dt = ProJnlobj.SelFAvoucherHeadProVou(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), vtypeid, Session["FADbname"].ToString(), voumonth);
                if (Dt.Rows.Count > 0)
                {
                    recedit = true;
                    txtnarration.Text = Dt.Rows[0]["narration"].ToString();
                    txtjobno.Text = Dt.Rows[0]["JobNo"].ToString();
                    txtref.Text = Dt.Rows[0]["RefNo"].ToString();
                    Dt2 = ProJnlobj.SelFAvoucherDetailsProVou(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), vtypeid, Session["FADbname"].ToString(), voumonth);
                    Session["dt_grdbind"] = Dt2;
                    grd_journal.DataSource = Dt2;
                    grd_journal.DataBind();
                }

                if (Dt2.Rows.Count > 0)
                {

                    for (int i = 0; i <= Dt2.Rows.Count - 1; i++)
                    {

                        if (Dt2.Rows[i]["Debit"].ToString() != "")
                        {
                            totdbAmnt = totdbAmnt + Convert.ToDouble(Dt2.Rows[i]["Debit"]);
                        }

                        if (Dt2.Rows[i]["Credit"].ToString() != "")
                        {
                            totcramnt = totcramnt + Convert.ToDouble(Dt2.Rows[i]["Credit"]);
                        }

                    }
                    txtDbtAmnt.Text = string.Format("{0:0.00}", totdbAmnt);
                    txtCrAmnt.Text = string.Format("{0:0.00}", totcramnt);
                }
                btnsave.Text = "Update";
                btnsave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";
                btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Invalid voucher');", true);
                ClearAll();
            }

        }

        protected void grd_journal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "Dr")
                {
                    e.Row.Cells[6].Text = "";
                }
                if (e.Row.Cells[0].Text == "Cr")
                {
                    e.Row.Cells[5].Text = "";
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_journal, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        public void ClearAll()
        {
            //btnsave.Text = "Save";
            //btncancel.Text = "Back";
            txtldgrname.Text = "";
            txtamount.Text = "";
            txtjnlno.Text = "";
            txtnarration.Text = "";
            txtDbtAmnt.Text = "";
            txtCrAmnt.Text = "";
            txtjobno.Text = "";
            txtref.Text = "";
            txtldgrname.Enabled = true;
            txt_currency.Text = "";             //NewOne        //07/07/2022
            txt_exrate.Text = "";
            txt_amt.Text = "";
            //btnadd.Text = "Add";            
            recedit = false;
            txtdate.Enabled = true;
            grd_journal.DataSource = new DataTable();
            grd_journal.DataBind();
            ViewState["ledgerid"] = null;
            hf_ldgrid.Value = "";
            btnsave.Enabled = true;
            ddl_CrrDb.SelectedValue = "0";
            ddl_type.SelectedValue = "0";
            txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
            lbl_name.Text = "Name";
            btnadd.Enabled = true;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                ClearAll();
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            int journalno;
            int jobno;
            string strto;
            string ledgername;
            string ledgeropstype;

            Checkdata();
            if (blnErr == true)
            {
                blnErr = false;
                return;
            }

            if (btnsave.ToolTip == "Save")
            {
                vtypeid = Jnlobj.Selvoutypeid("Journal", Session["FADbname"].ToString());

                if (txtref.Text != "")
                {
                    //if (ProJnlobj.ChkRefnoExists4JournalProvou(txtref.Text.ToString(), vtypeid, Convert.ToInt32(Session["LoginBranchid"]), Session["FADbname"].ToString()) > 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Reference # Already Exists');", true);
                    //    txtref.Text = "";
                    //    txtref.Focus();
                    //    return;
                    //}
                    //bhuvi hide for branchid to division
                    if (ProJnlobj.ChkRefnoExists4JournalProvou(txtref.Text.ToString(), vtypeid, Convert.ToInt32(Session["LoginDivisionId"]), Session["FADbname"].ToString()) > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Reference # Already Exists');", true);
                        txtref.Text = "";
                        txtref.Focus();
                        return;
                    }
                }

                //DateTime dt_logDate = new DateTime();

                //dt_logDate = Convert.ToDateTime(Utility.fn_ConvertDate(hid_Vouyear.Value));

                //if (dt_logDate.Month == Logobj.GetDate().Month && dt_logDate.Year == Logobj.GetDate().Year)
                //{
                //    txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                //}
                //else
                //{
                //    dt_logDate = new DateTime(dt_logDate.Year, (dt_logDate.Month + 1), 1).AddDays(-1);
                //    txtdate.Text = Utility.fn_ConvertDate(dt_logDate.ToString());
                //}

                //if (dt_logDate.Month < 4 && dt_logDate.Year <= Convert.ToInt32(Session["LogYear"].ToString()))
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Finanical Year')", true);
                //    txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
                //}

                DateTime Dt_JouDate;
                Dt_JouDate = Convert.ToDateTime(Utility.fn_ConvertDate(hid_Vouyear.Value));
                joudate = Logobj.GetDate();

                if (Dt_JouDate.Month == joudate.Month && Dt_JouDate.Year == joudate.Year)
                {

                }
                else if (Int_NoOfDays == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You Dont have rights to do Backdated entry in Journal')", true);
                    return;
                }
                else if (Int_NoOfDays != 0)
                {
                    if ((Dt_JouDate < joudate.AddDays(-Int_NoOfDays)))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You are allowed to do only " + Int_NoOfDays + " Day(s) Backdated entry in Journal')", true);
                        return;
                    }
                }

                //else if (Int_NoOfDays != 0)
                //{
                //    if ((joudate).Year == joudate.AddDays(-Int_NoOfDays - 1).Year)
                //    {
                //        if (Dt_JouDate <= Convert.ToDateTime(joudate.Year + "," + (joudate.AddDays(-Int_NoOfDays - 1).Month + 1) + "," + 1).AddDays(-1))
                //        {
                //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You are allowed to do only " + Int_NoOfDays + " Month(s) Backdated entry in Journal')", true);
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        if (Dt_JouDate <= joudate.AddDays(-Int_NoOfDays))
                //        {
                //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You are allowed to do only " + Int_NoOfDays + " Month(s) Backdated entry in Journal')", true);
                //            return;
                //        }
                //    }
                //}

                totdbAmnt = Convert.ToDouble(txtDbtAmnt.Text.ToString());
                totcramnt = Convert.ToDouble(txtCrAmnt.Text.ToString());

                if (totdbAmnt == totcramnt && totdbAmnt != 0 & totcramnt != 0)
                {
                    //joudate = Convert.ToDateTime(txtdate.Text);//

                    joudate = Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text));
                    if (!string.IsNullOrEmpty(Obj_BckDateRights.Getdate_4JV(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), Convert.ToInt32(txtvouyear.Text))) && Obj_BckDateRights.Getdate_4JV(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), Convert.ToInt32(txtvouyear.Text)) != "0")
                    {
                        joudate = Convert.ToDateTime(Obj_BckDateRights.Getdate_4JV(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)), Convert.ToInt32(txtvouyear.Text)));
                    }

                    journalno = ProJnlobj.GetJournalNoMONTHProVou(Convert.ToInt32(Session["LoginBranchid"]), joudate);
                    txtjnlno.Text = journalno.ToString();
                    vtypeid = Jnlobj.Selvoutypeid("Journal", Session["FADbname"].ToString());
                    if (txtjnlno.Text.Length == 0)
                    {
                        jobno = 0;
                    }
                    else
                    {
                        jobno = int.Parse(txtjnlno.Text.ToString());
                    }
                    DataTable vc = new DataTable();
                    voucherid = ProJnlobj.InsFAVouHeadProVou(Session["FADbname"].ToString(), vtypeid, Convert.ToString(journalno), joudate, txtnarration.Text.ToString(), "FA", 0, 0, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToDateTime(Logobj.GetDate()), 'N', Convert.ToInt32(txtvouyear.Text));
                    if (voucherid != 0)
                    {
                        faobj.UpdateFAVouHeadDetailsProVou(Session["FADbname"].ToString(), "Journal", voucherid, txtref.Text.ToString(), jobno, "");

                        for (int i = 0; i <= grd_journal.Rows.Count - 1; i++)
                        {
                            strto = grd_journal.Rows[i].Cells[0].Text;
                            ledgername = grd_journal.Rows[i].Cells[1].Text;
                            ledgeropstype = grd_journal.DataKeys[i].Values["opstype"].ToString();
                            ledgerid = Convert.ToInt32(grd_journal.DataKeys[i].Values["ledgerid"].ToString());
                            if (grd_journal.Rows[i].Cells[5].Text != "" || grd_journal.Rows[i].Cells[5].Text != "")
                            {
                                strtype = "Dr";
                                vouamnt = Convert.ToDouble(grd_journal.Rows[i].Cells[5].Text);
                            }
                            if (grd_journal.Rows[i].Cells[6].Text != "" || grd_journal.Rows[i].Cells[6].Text != "")
                            {
                                strtype = "Cr";
                                vouamnt = Convert.ToDouble(grd_journal.Rows[i].Cells[6].Text);
                            }

                            ProJnlobj.InsFAVouDetailsProVou(Session["FADbname"].ToString(), voucherid, ledgerid, strtype, vouamnt, Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                            fcur = grd_journal.Rows[i].Cells[2].Text;
                            famt = Convert.ToDouble(grd_journal.Rows[i].Cells[3].Text);
                            exrate = Convert.ToDouble(grd_journal.Rows[i].Cells[4].Text);
                            obj_fa.SPFAUpdFAVouDtls4Fcurprovou(Session["FADbname"].ToString(), voucherid, fcur, famt, exrate, ledgerid, strtype, Convert.ToInt32(Session["LogYear"].ToString()), txtref.Text);

                            //ProJnlobj.InsFAVouDetailsProVou(Session["FADbname"].ToString(), voucherid, ledgerid, strtype, vouamnt, Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }
                        Approveobj.InsJnlDtls2FARPProVou(voucherid, Session["FADbname"].ToString());
                    }

                    if (strantype == "FA")
                    {
                        // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1105, 1, Convert.ToInt32(Session["LoginBranchid"]), (Convert.ToInt32(txtjnlno.Text)) + "/" + ttdate.Text + "/ S");
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1352, 1, Convert.ToInt32(Session["LoginBranchid"]), (Convert.ToInt32(txtjnlno.Text)) + "/" + ttdate.Text + "/ S");
                    }
                    else if (strantype == "FC")
                    {
                        // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1191, 1, Convert.ToInt32(Session["LoginBranchid"]), txtjnlno.Text + "/" + ttdate.Text + "/ S");
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1353, 1, Convert.ToInt32(Session["LoginBranchid"]), txtjnlno.Text + "/" + ttdate.Text + "/ S");
                    }

                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Journal Details Saved. Journal # : " + txtjnlno.Text + "');", true);
                    txtjnlno.Text = journalno.ToString();
                    btnsave.Enabled = false;
                    btncancel.Text = "Cancel";
                    btncancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    ClearAll();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Both Credit and Debit Amount Should Match');", true);
                    return;
                }
            }
            else
            {

            }
        }

        protected void AddDetails()
        {
            if (txtldgrname.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Enter the Ledger Name');", true);
                txtldgrname.Focus();
                blnErr = true;
                return;
            }

            if (btnadd.ToolTip == "Add")
            {
                if (ddl_type.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Select Type');", true);
                    ddl_type.Focus();
                    blnErr = true;
                    return;
                }
            }

            if (txtamount.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Enter the Amount');", true);
                txtamount.Focus();
                blnErr = true;
                return;
            }
        }


        public void Checkdata()
        {
            if (txtDbtAmnt.Text == "" || txtCrAmnt.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Without Particulars, Journal Cannot be Saved.');", true);
                txtDbtAmnt.Focus();
                blnErr = true;
                return;
            }
            else if (txtref.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Reference # Cannot be Blank');", true);
                txtref.Text = "";
                txtref.Focus();
                blnErr = true;
                return;
            }
        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {

            DateTime dt_logDate = new DateTime();
            DateTime Fbegin, Fend;
            string[] FAYEAR;
            string ffm, ffd;
            string ftm, ftd;

            //FAYEAR = Session["LYEAR"].ToString().Split('-');
            //Fbegin = Convert.ToDateTime("04/01/20" + FAYEAR[0]);
            //Fend = Convert.ToDateTime("03/31/20" + FAYEAR[1]);

            DataTable fay = new DataTable();
            fay = Bank_Obj.FAYEAR(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            FAYEAR = Session["LYEAR"].ToString().Split('-');

            Fbegin = Convert.ToDateTime(fay.Rows[0]["fyfrom"]);
            Fend = Convert.ToDateTime(fay.Rows[0]["fyto"]);

            ffm = Fbegin.Month.ToString();
            ffd = Fbegin.Day.ToString();
            ftm = Fend.Month.ToString();
            ftd = Fend.Day.ToString();

            Fbegin = Convert.ToDateTime(ffm + "/" + ffd + "/" + FAYEAR[0]);
            Fend = Convert.ToDateTime(ftm + "/" + ftd + "/" + FAYEAR[1]);

            //txtvouyear.Text =  FAYEAR[0]; 
            txtvouyear.Text = Session["LogYEAR"].ToString();

            dt_logDate = Convert.ToDateTime(Utility.fn_ConvertDate(hid_Vouyear.Value));

            if (dt_logDate.Month == Logobj.GetDate().Month && dt_logDate.Year == Logobj.GetDate().Year)
            {
                txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
            }
            else
            {
                if (dt_logDate.Month == 12)
                {
                    dt_logDate = new DateTime(dt_logDate.Year, (dt_logDate.Month), 31);//.AddDays(-1)
                    txtdate.Text = Utility.fn_ConvertDate(dt_logDate.ToString());
                }
                else
                {
                    dt_logDate = new DateTime(dt_logDate.Year, (dt_logDate.Month + 1), 1).AddDays(-1);
                    txtdate.Text = Utility.fn_ConvertDate(dt_logDate.ToString());
                }

            }
            if (dt_logDate >= Fbegin && dt_logDate <= Fend)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Finanical Year')", true);
                txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
            }
            //if (dt_logDate.Month < 4 && dt_logDate.Year <= Convert.ToInt32(Session["LogYear"].ToString()))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Finanical Year')", true);
            //    txtdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToString());
            //}
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Boolean ledbool = false;
            AddDetails();

            if (blnErr == true)
            {
                blnErr = false;
                return;
            }

            string cledgerid;
            if (hf_ldgrid.Value != "")
            {
                totdbAmnt = 0;
                totcramnt = 0;
                Dt = (DataTable)ViewState["ledgerid"];
                if (ViewState["ledgerid"] == null)
                {
                    Dt = new DataTable();
                    DataColumn dc_col1 = new DataColumn("LedgerType", typeof(string));
                    DataColumn dc_col2 = new DataColumn("ledgername", typeof(string));
                    DataColumn dc_col3 = new DataColumn("fcur", typeof(string));            //NewOne        //07/07/2022
                    DataColumn dc_col4 = new DataColumn("famt", typeof(double));
                    DataColumn dc_col5 = new DataColumn("exrate", typeof(double));
                    DataColumn dc_col6 = new DataColumn("LedgerAmount", typeof(double));
                    DataColumn dc_col7 = new DataColumn("opstype", typeof(string));
                    DataColumn dc_col8 = new DataColumn("ledgerid", typeof(Int32));
                    DataColumn dc_col9 = new DataColumn("vousubid", typeof(Int32));
                    Dt.Columns.Add(dc_col1);
                    Dt.Columns.Add(dc_col2);
                    Dt.Columns.Add(dc_col3);
                    Dt.Columns.Add(dc_col4);
                    Dt.Columns.Add(dc_col5);
                    Dt.Columns.Add(dc_col6);
                    Dt.Columns.Add(dc_col7);    //NewOne        //07/07/2022
                    Dt.Columns.Add(dc_col8);
                    Dt.Columns.Add(dc_col9);
                }

                DataRow dr;
                if (btnadd.ToolTip == "Add")
                {
                    if (ddl_CrrDb.SelectedItem.Text != "" && txtldgrname.Text != "" && ddl_type.SelectedItem.Text != "" && txtamount.Text != "")
                    {
                        ledbool = false;

                        if (grd_journal.Rows.Count > 0)
                        {
                            for (int i = 0; i <= grd_journal.Rows.Count - 1; i++)
                            {
                                if (grd_journal.DataKeys[i].Values[2].ToString() == hf_ldgrid.Value)
                                {
                                    ledbool = true;
                                }
                            }
                        }

                        if (ledbool == true)
                        {
                            ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "Valid text", "alertify.alert('Ledger Already Exists');", true);
                            txtldgrname.Focus();
                            return;
                        }
                    }

                    dr = Dt.NewRow();
                    if (ddl_CrrDb.SelectedItem.Text != "")
                    {
                        dr["LedgerType"] = ddl_CrrDb.SelectedItem.Text;
                        dr["ledgername"] = txtldgrname.Text.ToString();

                        //NewOne        //07/07/2022
                        if (ddl_type.SelectedItem.Text == "Credit")
                        {
                            dr["ledgerAmount"] = Convert.ToDouble(txtamount.Text.Trim());
                        }
                        else if (ddl_type.SelectedItem.Text == "Debit")
                        {
                            dr["ledgerAmount"] = Convert.ToDouble(txtamount.Text.Trim());
                        }
                    }

                    //NewOne        //07/07/2022
                    if (txt_currency.Text == "")
                    {
                        dr["fcur"] = "INR";
                    }
                    else
                    {
                        dr["fcur"] = txt_currency.Text;
                    }

                    if (txt_amt.Text == "")
                    {
                        dr["famt"] = "1";
                    }
                    else
                    {
                        dr["famt"] = Convert.ToDouble(txt_amt.Text).ToString("#,0.00");
                    }
                    if (txt_exrate.Text == "")
                    {
                        dr["exrate"] = "1";
                    }
                    else
                    {
                        dr["exrate"] = Convert.ToDouble(txt_exrate.Text).ToString("#,0.00");
                    }

                    dr["opstype"] = "C";
                    dr["vousubid"] = 0;
                    dr["ledgerid"] = hf_ldgrid.Value;
                    Dt.Rows.Add(dr);
                    ViewState["ledgerid"] = Dt;
                    grd_journal.DataSource = Dt;
                    grd_journal.DataBind();
                }
                else
                {
                    if (ddl_CrrDb.SelectedItem.Text != "" && txtldgrname.Text != "" && ddl_type.SelectedItem.Text != "" && txtamount.Text != "")
                    {
                        DataTable dt_Jouranl = new DataTable();
                        //dt_Jouranl = ViewState["ledgerid"] as DataTable;

                        for (int i = 0; i < grd_journal.Rows.Count; i++)
                        {
                            cledgerid = hf_ldgrid.Value;
                            if (cledgerid.ToString() != "")
                            {
                                int index = grd_journal.SelectedRow.RowIndex;
                                //grd_journal.Rows[index].Cells[2].Text = ddl_type.SelectedItem.Text;
                                grd_journal.Rows[index].Cells[1].Text = txtldgrname.Text;


                                //NewOne        //07/07/2022

                                if (txt_currency.Text == "")
                                {
                                    grd_journal.Rows[index].Cells[2].Text = "INR";
                                }
                                else
                                {
                                    grd_journal.Rows[index].Cells[2].Text = txt_currency.Text;
                                }

                                if (txt_amt.Text == "")
                                {
                                    grd_journal.Rows[index].Cells[3].Text = "1";
                                }
                                else
                                {
                                    grd_journal.Rows[index].Cells[3].Text = Convert.ToDouble(txt_amt.Text).ToString("#,0.00");
                                }
                                if (txt_exrate.Text == "")
                                {
                                    grd_journal.Rows[index].Cells[4].Text = "1";
                                }
                                else
                                {
                                    grd_journal.Rows[index].Cells[4].Text = Convert.ToDouble(txt_exrate.Text).ToString("#,0.00");
                                }

                                //NewOne    //07/07/2022
                                if (ddl_type.SelectedItem.Text == "Debit")
                                {
                                    grd_journal.Rows[index].Cells[0].Text = "Dr";

                                    grd_journal.Rows[index].Cells[6].Text = "";
                                    grd_journal.Rows[index].Cells[5].Text = Convert.ToDouble(txtamount.Text.Trim()).ToString("#,0.00");
                                }
                                else if (ddl_type.SelectedItem.Text == "Credit")
                                {
                                    grd_journal.Rows[index].Cells[0].Text = "Cr";
                                    grd_journal.Rows[index].Cells[5].Text = "";
                                    grd_journal.Rows[index].Cells[6].Text = Convert.ToDouble(txtamount.Text.Trim()).ToString("#,0.00");
                                }

                                //dt_Jouranl.Rows[index]["opstype"] = "C";
                                //dt_Jouranl.Rows[index]["vousubid"] = 0;
                                //dt_Jouranl.Rows[index]["ledgerid"] = hf_ldgrid.Value;
                            }
                        }


                        ViewState["ledgerid"] = null;
                        DataTable dt = (DataTable)grd_journal.DataSource;

                        ViewState["ledgerid"] = Dt;

                        //ViewState["ledgerid"] = Dt;
                        //grd_journal.DataSource = Dt;
                        //grd_journal.DataBind();
                    }
                }

                if (grd_journal.Rows.Count > 0)
                {

                    totdbAmnt = 0;
                    totcramnt = 0;
                    for (int i = 0; i <= grd_journal.Rows.Count - 1; i++)
                    {
                        //NewOne    //07/07/2022
                        if (grd_journal.Rows[i].Cells[5].Text != "")
                        {
                            totdbAmnt = totdbAmnt + Convert.ToDouble(grd_journal.Rows[i].Cells[5].Text);
                        }

                        if (grd_journal.Rows[i].Cells[6].Text != "")
                        {
                            totcramnt = totcramnt + Convert.ToDouble(grd_journal.Rows[i].Cells[6].Text);
                        }
                    }

                    txtDbtAmnt.Text = string.Format("{0:0.00}", totdbAmnt);
                    txtCrAmnt.Text = string.Format("{0:0.00}", totcramnt);
                }

                ddl_CrrDb.SelectedIndex = -1;
                txtldgrname.Text = "";
                ddl_type.SelectedIndex = -1;
                txtamount.Text = "";
                txt_amt.Text = "";      //NewOne        //07/07/2022
                txt_currency.Text = "";
                txt_exrate.Text = "";
                ddl_CrrDb.Enabled = false;
                txtldgrname.Enabled = true;
                btnadd.Text = "Add";
                btnadd.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn ico-add";

                if (txtjnlno.Text != "")
                {
                    btnadd.Text = "Update";
                    btnadd.ToolTip = "Update";
                    btn_add1.Attributes["class"] = "btn ico-update";
                }
            }
        }

        protected void txtldgrname_TextChanged(object sender, EventArgs e)
        {
            if (txtldgrname.Text != "")
            {
                string str_ledgername;
                string[] str_temp = txtldgrname.Text.Split(',');
                if (str_temp.Length > 0)
                {
                    str_ledgername = str_temp[0].ToString();
                }
                else
                {
                    str_ledgername = txtldgrname.Text;
                }

                //Dt = Jnlobj.GetLikeLedgernameforjournal(str_ledgername.TrimEnd(), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["FADbname"].ToString());

                //Dt = ledgerobj.GetLikeLedgername(str_ledgername.TrimEnd(), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["FADbname"].ToString());

                //if (Dt.Rows.Count == 1)
                //{
                //    ledgerid = Convert.ToInt32(Dt.Rows[0]["ledgerid"].ToString());
                //    hf_ldgrid.Value = ledgerid.ToString();
                //    ledgername = Dt.Rows[0]["ledgername"].ToString();
                //    txtldgrname.Text = ledgername;                   
                //}

                if (hf_ldgrid.Value == "" || hf_ldgrid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Enter valid Ledger Name');", true);
                    txtldgrname.Text = "";
                    txtldgrname.Focus();
                    return;
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Enter valid Ledger Name');", true);
                txtldgrname.Text = "";
                txtldgrname.Focus();
                return;
            }
        }


        public void GetJournalDett()
        {
            recedit = false;
            txtmont.Value = Convert.ToInt32(vdate.Month).ToString();
            int branchid = Convert.ToInt32(Session["LoginBranchid"]);

            if (txtmont.Value == "")
            {
                txtmont.Value = "0";
            }

            DataTable Dt = new DataTable();
            DataTable Dt2 = new DataTable();
            vtypeid = Jnlobj.Selvoutypeid("Journal", Session["FADbname"].ToString());

            if (txtjnlno.Text != "")
            {
                Dt = ProJnlobj.SelFAvoucherHeadProVou(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), vtypeid, Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month);//Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text))
                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0]["jouno"].ToString() != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Already Transferred. Journal # " + Dt.Rows[0]["jouno"].ToString() + " Date : " + Dt.Rows[0]["voudate"].ToString() + "');", true);
                    }
                    else
                    {
                        recedit = true;
                        txtnarration.Text = Dt.Rows[0]["narration"].ToString();
                        vouid = Convert.ToInt32(Dt.Rows[0]["vouid"]);
                        hid_Vouid.Value = vouid.ToString();
                        txtjobno.Text = Dt.Rows[0]["JobNo"].ToString();
                        txtref.Text = Dt.Rows[0]["RefNo"].ToString();
                        lbl_name.Text = Dt.Rows[0]["empname"].ToString();

                        DateTime journaldate = new DateTime();
                        journaldate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                        txtdate.Text = Utility.fn_ConvertDate(journaldate.ToString());

                        Dt2 = ProJnlobj.SelFAvoucherDetailsProVou(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), vtypeid, Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month);
                        Session["dt_grdbind"] = Dt2;
                        grd_journal.DataSource = Dt2;
                        grd_journal.DataBind();
                    }
                    btnsave.Visible = false;
                    btnadd.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Invalid voucher');", true);
                    ClearAll();
                }

                if (grd_journal.Rows.Count > 0)
                {

                    for (int i = 0; i <= grd_journal.Rows.Count - 1; i++)
                    {

                        if (grd_journal.Rows[i].Cells[2].Text != "")
                        {
                            totdbAmnt = totdbAmnt + Convert.ToDouble(grd_journal.Rows[i].Cells[2].Text);
                        }

                        if (grd_journal.Rows[i].Cells[3].Text != "")
                        {
                            totcramnt = totcramnt + Convert.ToDouble(grd_journal.Rows[i].Cells[3].Text);
                        }

                    }
                    txtDbtAmnt.Text = string.Format("{0:0.00}", totdbAmnt);
                    txtCrAmnt.Text = string.Format("{0:0.00}", totcramnt);
                }

                btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }


        }
        protected void txtjnlno_TextChanged(object sender, EventArgs e)
        {
            if (txtjnlno.Text != "")
            {
                GetJournalDett();
            }
        }

        protected void grd_journal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grd_journal.SelectedRow.RowIndex;

            if (grd_journal.Rows.Count > 0)
            {
                ddl_CrrDb.SelectedItem.Text = grd_journal.SelectedRow.Cells[0].Text.ToString();
                hf_ldgrid.Value = grd_journal.DataKeys[index].Values[2].ToString();

                if (ddl_CrrDb.SelectedItem.Text == "Dr")
                {
                    //ddl_type.SelectedItem.Text = "Debit";
                    ddl_type.SelectedValue = "1";
                    txtamount.Text = string.Format("{0:0.00}", grd_journal.Rows[index].Cells[5].Text);
                }
                else
                {
                    //ddl_type.SelectedItem.Text = "Credit";
                    ddl_type.SelectedValue = "2";
                    txtamount.Text = string.Format("{0:0.00}", grd_journal.Rows[index].Cells[6].Text);
                }
                txt_amt.Text = string.Format("{0:0.00}", grd_journal.Rows[index].Cells[3].Text);
                txt_currency.Text = grd_journal.Rows[index].Cells[2].Text;
                txt_exrate.Text = string.Format("{0:0.00}", grd_journal.Rows[index].Cells[4].Text);

                txtldgrname.Text = grd_journal.SelectedRow.Cells[1].Text.Replace("&amp;", "&");
                //ddl_CrrDb.SelectedValue = "0";
                ddl_CrrDb.Enabled = false;
                txtldgrname.Enabled = false;
                btnadd.Text = "Update";
                btnadd.ToolTip = "Update";
                btn_add1.Attributes["class"] = "btn ico-update";

            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            if (hid_Vouid.Value != "0" && txtjnlno.Text != "")
            {
                Dt = Jnlobj.SPFAJouRefChkng(Session["FADbname"].ToString(), txtref.Text, Convert.ToInt32(hid_Vouid.Value));
                if (Dt.Rows.Count == 0)
                {
                    ProJnlobj.InsFAVouHeadDeletedProVou(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hid_Vouid.Value));
                    ProJnlobj.UpdJouHeadProVou(Session["FADbname"].ToString(), Convert.ToInt32(hid_Vouid.Value));
                    ProJnlobj.InsFAVouDtlsDeletedProVou(Session["FADbname"].ToString(), Convert.ToInt32(hid_Vouid.Value));
                    ProJnlobj.DelVouDetailsProVou(Convert.ToInt32(hid_Vouid.Value), Session["FADbname"].ToString());
                    ScriptManager.RegisterStartupScript(btndel, typeof(Button), "Valid text", "alertify.alert('Entry Deleted');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btndel, typeof(Button), "Valid text", "alertify.alert('Journal Values Already Found in Receipt/Payment');", true);
                }

                if (strantype == "FA")
                {
                    // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1352, 1, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtjnlno.Text) + "/" + hf_Date.Value + "/" + Convert.ToInt32(hid_Vouid.Value));
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1352, 4, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtjnlno.Text) + "/" + hf_Date.Value + "/" + Convert.ToInt32(hid_Vouid.Value));
                }
                if (strantype == "FC")
                {
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1353, 4, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtjnlno.Text) + "/" + hf_Date.Value + "/" + Convert.ToInt32(hid_Vouid.Value));
                }

                ClearAll();
            }
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            if (txtjnlno.Text == "")
            {
                return;
            }
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            string BranchName = Master_Branch.Getbranchname(bid);

            Str_RptName = "rptJVpro.rpt";
            Session["str_sfs"] = "{FAMasterVoucherHead4ProVou.vouno}=" + txtjnlno.Text + " and {FAMasterVoucherHead4ProVou.voutype}=13 and {FAMasterVoucherHead4ProVou.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FAMasterVoucherHead4ProVou.divisionid}= " + Convert.ToInt32(Session["LoginDivisionId"].ToString()) + " and month({FAMasterVoucherHead4ProVou.voudate})=" + Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month;
            Session["str_sp"] = "Title=PROFORMA JOURNAL~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2);

            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), Str_Script, true);

            if (strantype == "FA")
            {
                // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1352, 4, Convert.ToInt32(Session["LoginBranchid"]), txtjnlno.Text + "/" + txtdate.Text + "/ V");
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1352, 3, Convert.ToInt32(Session["LoginBranchid"]), txtjnlno.Text + "/" + txtdate.Text + "/ V");
            }
            else if (strantype == "FC")
            {
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1353, 3, Convert.ToInt32(Session["LoginBranchid"]), txtjnlno.Text + "/" + txtdate.Text + "/ V");
            }
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_type.SelectedItem.Text == "Debit")
            {
                ddl_CrrDb.SelectedValue = "1";
            }
            else
            {
                ddl_CrrDb.SelectedValue = "2";
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
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1352, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1353, "", "", "", Session["StrTranType"].ToString());
            }


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_journal_PreRender(object sender, EventArgs e)
        {
            if (grd_journal.Rows.Count > 0)
            {
                grd_journal.UseAccessibleHeader = true;
                grd_journal.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        //NewOne        //07/07/2022
        protected void txt_currency_TextChanged(object sender, EventArgs e)
        {
            if (txt_currency.Text.ToUpper() == hid_BaseCurr.Value)
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

        protected void txt_amt_TextChanged(object sender, EventArgs e)
        {
            if (txt_amt.Text.Length > 0 && txt_exrate.Text.Length > 0)
            {
                txtamount.Text = (Convert.ToDouble(txt_amt.Text) * Convert.ToDouble(txt_exrate.Text)).ToString();
            }
            else
            {
                txtamount.Text = "";
            }
        }

        protected void txt_exrate_TextChanged(object sender, EventArgs e)
        {
            txt_amt.Focus();
            if (txt_amt.Text.Length > 0 && txt_exrate.Text.Length > 0)
            {

                txtamount.Text = (Convert.ToDouble(txt_amt.Text) * Convert.ToDouble(txt_exrate.Text)).ToString();

            }
            else
            {
                txtamount.Text = "";
            }
        }




    }
}