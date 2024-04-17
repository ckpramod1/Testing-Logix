using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;

namespace logix.FAForm
{
    public partial class ChequeBounce : System.Web.UI.Page
    {
        char retype;
        DataTable dt;
        DataTable dtCuschrg;
        int recid, recno, branchid, bankid, custid, dcusid, dcrgid, i, vouyr, voucherid;
        int chkbranchid, voutypeid, Curr_VouYear;
        int logCorpID, intCoRJVno = 0, ALogYear, deptid = 0;
        int strReffno;
        string StrTrantype;
        int BDVouYear;
        string partyledger;
        Double cusamt, recamt;
        DateTime RecDate, chqdt, slipdate, dssldate, Curr_Date;
        string place, bbranch;
        double Amt, custAmt, TDSAmt, ESAmt, sumAmt;
        DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
        DataAccess.Masters.MasterDivision DivObj = new DataAccess.Masters.MasterDivision();
        DataAccess.FAMaster.MasterLedger Ldrobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.FAVoucher FAObj = new DataAccess.FAVoucher();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.Accounts.Payment pymtobj = new DataAccess.Accounts.Payment();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterBranch Obj_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.OSDNCN Obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Accounts.Recipts RcptObj = new DataAccess.Accounts.Recipts();
        DataAccess.FAVoucher Obj_FAVoucher = new DataAccess.FAVoucher();

        DataAccess.HR.Employee Obj_Emp = new DataAccess.HR.Employee();
        DataAccess.Accounts.Journal Obj_Journal = new DataAccess.Accounts.Journal();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable dts = new DataTable();
        DataTable obj_dt = new DataTable();
        bool BlnVouChk = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FAObj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                recobj.GetDataBase(Ccode);
                DivObj.GetDataBase(Ccode);
                Ldrobj.GetDataBase(Ccode);
                HREmpobj.GetDataBase(Ccode);
                pymtobj.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                chrgobj.GetDataBase(Ccode);


                Obj_Branch.GetDataBase(Ccode);
                Obj_OSDNCN.GetDataBase(Ccode);
                RcptObj.GetDataBase(Ccode);
                Obj_FAVoucher.GetDataBase(Ccode);
                Obj_Journal.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);




            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            try
            {
                if (Request.QueryString.ToString().Contains("FormName"))
                {
                    lbl_Header.Text = Request.QueryString["FormName"].ToString();
                }

                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());

                if (!Page.IsPostBack)
                {
                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                    div_grid.DataSource = dts;
                    div_grid.DataBind();
                }

                if (lbl_Header.Text == "Cheque Bounce")
                {
                    retype = 'R';
                    lbl_rec.Text = "Rec #";
                }
                else
                {
                    retype = 'P';
                    lbl_Recei.Text = "Payment #";
                    lbl_receive.Text = "Favouring";
                    lbl_receive.Text = "Branch";
                    btn_confirm.Text = "Delete";
                    btn_confirm.ToolTip = "Delete";
                    btn_confirm1.Attributes["class"] = "btn ico-delete";
                }
                Rptype.Value = retype.ToString();

                Curr_Date = logobj.GetDate();
                if ((Curr_Date).Month < 4)
                {
                    Curr_VouYear = (Curr_Date).Year - 1;
                }
                else
                {
                    Curr_VouYear = (Curr_Date).Year;
                }

                ALogYear = Convert.ToInt32(Session["Alogyear"].ToString());

                if (txt_vou.Text != "")
                {
                    if (Session["obj_dt"] != null)
                    {
                        obj_dt = Session["obj_dt"] as DataTable;

                        if (hid_year.Value != "")
                        {
                            if (hid_year.Value == Session["Vouyear"].ToString())
                            {
                                btn_confirm.Attributes.Add("OnClick", "if(confirm('Do You Want To Bounce the Cheque ?')){ document.getElementById('logix_CPH_hid_AlertMsg').value = 'Y';}else{ document.getElementById('logix_CPH_hid_AlertMsg').value = 'N';}");
                            }
                            else
                            {
                                btn_confirm.Attributes.Add("OnClick", "if(confirm('Do You Want To Bounce the Previous Financial Year Cheque ?')){ document.getElementById('logix_CPH_hid_AlertMsg').value = 'Y';}else{ document.getElementById('logix_CPH_hid_AlertMsg').value = 'N';}");
                            }
                        }

                        if (txt_remark.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Remarks should not be Empty')", true);
                            txt_remark.Focus();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void getdetail()
        {
            if (Rptype.Value.ToString() == "R")
            {
                if (txt_Check.Text != "" && txt_rec.Text != "")
                {
                    if (txt_vou.Text != "")
                    {
                        dt = recobj.SelRecHeadChqRecno(txt_Check.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txt_rec.Text), Convert.ToInt32(txt_vou.Text));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Please Enter Vouyear');", true);
                        return;
                    }
                }

                if (txt_Check.Text != "" && txt_rec.Text == "" && txt_vou.Text == "")
                {
                    dt = recobj.SelRecHeadByChq(txt_Check.Text, Convert.ToInt32(Session["LoginBranchid"]));
                    if (dt.Rows.Count > 0)
                    {
                        txt_rec.Text = dt.Rows[0]["receiptno"].ToString().Trim();
                        txt_vou.Text = dt.Rows[0]["vouyear"].ToString();
                        if(txt_Check.Text=="")
                        {
                            txt_Check.Text = dt.Rows[0]["chequeno"].ToString();
                        }
                    }
                }else if (txt_Check.Text != "")
                {
                    dt = recobj.SelRecHeadByChq(txt_Check.Text, Convert.ToInt32(Session["LoginBranchid"]));
                    if (dt.Rows.Count > 0)
                    {
                        txt_rec.Text = dt.Rows[0]["receiptno"].ToString().Trim();
                        txt_vou.Text = dt.Rows[0]["vouyear"].ToString();
                        if (txt_Check.Text == "")
                        {
                            txt_Check.Text = dt.Rows[0]["chequeno"].ToString();
                        }
                    }
                }

                if (txt_Check.Text == "" && txt_rec.Text != "")
                {
                    if (txt_vou.Text != "")
                    {
                        dt = recobj.SelRecHeadRecno(branchid, Convert.ToInt32(txt_rec.Text), Convert.ToInt32(txt_vou.Text));

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Please Enter Vouyear');", true);
                        return;
                    }
                }
            }
            else
            {
                int bid = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), txt_receip.Text);

                if (txt_Check.Text != "" && txt_rec.Text != "")
                {
                    if (txt_vou.Text != "")
                    {
                        dt = pymtobj.SelPymtHeadChqPymtno(txt_Check.Text, "PymtCancel", Convert.ToInt32(txt_rec.Text), Convert.ToInt32(txt_vou.Text), bid);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter Vouyear')", true);
                        return;
                    }
                }

                if (txt_Check.Text != "" && txt_rec.Text == "" && txt_vou.Text == "")
                {
                    dt = pymtobj.SelPymtHeadByChq(txt_Check.Text, "PymtCancel");
                    if (dt.Rows.Count > 0)
                    {
                        txt_rec.Text = dt.Rows[0]["paymentno"].ToString().Trim();
                        txt_vou.Text = dt.Rows[0]["vouyear"].ToString();
                    }
                }
            }

            hid_year.Value = txt_vou.Text;

            if (dt.Rows.Count > 0)
            {
                txt_bank.Text = dt.Rows[0]["bankname"].ToString();
                if (txt_Check.Text == "")
                {
                    txt_Check.Text = dt.Rows[0]["chequeno"].ToString().Trim();
                }
                recid = Convert.ToInt32(dt.Rows[0]["receiptid"].ToString());
                recno = Convert.ToInt32(dt.Rows[0]["receiptno"].ToString());
                RecDate = Convert.ToDateTime(dt.Rows[0][2].ToString());
                place = dt.Rows[0][3].ToString();
                txt_receip.Text = place.Substring(0, 3) + "/" + recno.ToString();
                vouyr = Convert.ToInt32(dt.Rows[0]["vouyear"].ToString());
                hid_receiptid.Value = recid.ToString();
                hid_receiptno.Value = recno.ToString();
                hid_recdate.Value = RecDate.ToString();

                if (Rptype.Value.ToString() == "R")
                {
                    custid = Convert.ToInt32(dt.Rows[0][5].ToString());
                    txt_receiv.Text = custobj.GetCustomername(custid);
                    hid_custid.Value = custid.ToString();
                }
                else
                {
                    txt_remark.Text = dt.Rows[0][3].ToString();
                    txt_receiv.Text = dt.Rows[0][5].ToString();
                    chkbranchid = Convert.ToInt32(dt.Rows[0]["branchid"].ToString());
                }

                Amt = Convert.ToDouble(dt.Rows[0][6]);
                hid_Amt.Value = Amt.ToString();
                txt_amount.Text = string.Format("{0:#,##0.00}", Amt);
                bankid = Convert.ToInt32(dt.Rows[0][7].ToString());
                hid_bankid.Value = bankid.ToString();
                bbranch = dt.Rows[0][8].ToString();
                hid_bbranch.Value = bbranch.ToString();
                chqdt = Convert.ToDateTime(dt.Rows[0][9].ToString());
                hid_chqdt.Value = chqdt.ToString();

                dt = recobj.GetRAInvoiceToShow(recid, Convert.ToChar(Rptype.Value));

                if (dt.Rows.Count > 0)
                {
                    DataTable dts = new DataTable();
                    dts.Columns.Add("branch");
                    dts.Columns.Add("port");
                    dts.Columns.Add("vouno");
                    dts.Columns.Add("vamount");
                    dts.Columns.Add("tamount");
                    dts.Columns.Add("voutype");
                    dts.Columns.Add("vouyear");
                    dts.Columns.Add("ravouyear");
                    dts.Columns.Add("jrefno");
                    dts.Columns.Add("jltype");
                    DataRow row;

                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        row = dts.NewRow();
                        dts.Rows.Add();

                        dts.Rows[i]["branch"] = dt.Rows[i][0].ToString();
                        dts.Rows[i]["port"] = dt.Rows[i][1].ToString();

                        if (dt.Rows[i][2].ToString() != "0")
                        {
                            if (dt.Rows[i][5].ToString() == "I")
                            {
                                dts.Rows[i]["vouno"] = "Inv - " + dt.Rows[i][2].ToString();
                            }
                            if (dt.Rows[i][5].ToString() == "D")
                            {
                                dts.Rows[i]["vouno"] = "OSDN - " + dt.Rows[i][2].ToString();
                            }
                            if (dt.Rows[i][5].ToString() == "V")
                            {
                                dts.Rows[i]["vouno"] = "DN - " + dt.Rows[i][2].ToString();
                            }
                            if (dt.Rows[i][5].ToString() == "P")
                            {
                                dts.Rows[i]["vouno"] = "CNOps - " + dt.Rows[i][2].ToString();
                            }
                            if (dt.Rows[i][5].ToString() == "C")
                            {
                                dts.Rows[i]["vouno"] = "OSCN - " + dt.Rows[i][2].ToString();
                            }
                            if (dt.Rows[i][5].ToString() == "E")
                            {
                                dts.Rows[i]["vouno"] = "CN - " + dt.Rows[i][2].ToString();
                            }
                        }
                        else
                        {
                            dts.Rows[i]["vouno"] = "On Account";
                        }

                        dts.Rows[i]["vamount"] = dt.Rows[i][3].ToString();
                        dts.Rows[i]["tamount"] = dt.Rows[i][4].ToString();
                    }

                    div_grid.DataSource = dts;
                    div_grid.DataBind();
                    Session["obj_dt"] = dts;
                    btn_confirm.Enabled = true;
                }
                else
                {
                    if (Rptype.Value.ToString() == "P")
                    {
                        btn_confirm.Enabled = true;
                    }
                    else
                    {
                        btn_confirm.Enabled = false;
                    }
                }

                if (Rptype.Value.ToString() == "R")
                {
                    dt = recobj.GetRecptCust(recid);
                }
                else
                {
                    dt = pymtobj.GetPaymentCust(recid);
                }
                if (dt.Rows.Count > 0)
                {
                    txt_customer.Text = dt.Rows[0][0].ToString();
                    txt_amoun.Text = dt.Rows[0][1].ToString();
                    custAmt = Convert.ToDouble(txt_amoun.Text);
                }

                if (Rptype.Value == "R")
                {
                    dt = recobj.GetRecptChrg(recid);
                }
                else
                {
                    dt = pymtobj.GetPaymentChrg(recid);
                }
                if (dt.Rows.Count > 0)
                {
                    txt_dection.Text = dt.Rows[0][0].ToString();
                    txt_amou.Text = dt.Rows[0][1].ToString();
                    TDSAmt = Convert.ToDouble(txt_amou.Text);
                }
                if (Rptype.Value.ToString() == "R")
                {
                    dt = recobj.GetES(recid);
                }
                else
                {
                    dt = pymtobj.GetPaymentES(recid);
                }

                if (dt.Rows.Count > 0)
                {
                    txt_amo.Text = dt.Rows[0][0].ToString();
                    ESAmt = Convert.ToDouble(txt_amo.Text);
                }

                sumAmt = custAmt + TDSAmt + ESAmt;
                txt_total.Text = string.Format("{0:#,##0.00}", sumAmt);


            }
            else
            {
                reset();
                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Invalid Cheque #');", true);
            }
        }

        protected void txt_vou_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Rptype.Value.ToString() == "R")
                {
                    if (txt_rec.Text != "" && txt_vou.Text != "")
                    {
                        getdetail();
                    }
                }
                else
                {
                    if (txt_rec.Text != "" && txt_vou.Text != "" && txt_receip.Text != "-1")
                    {
                        getdetail();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_rec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Rptype.Value.ToString() == "R")
                {
                    if (txt_rec.Text != "" && txt_vou.Text != "")
                    {
                        getdetail();
                    }
                }
                else
                {
                    if (txt_rec.Text != "" && txt_vou.Text != "" && txt_receip.Text != "-1")
                    {
                        getdetail();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void txt_Check_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Check.Text != "")
                {
                    getdetail();
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void GetDepositdata4BDBR()
        {
            //DataAccess.Accounts.OSDNCN Obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            int rcount, intBrRJVno, ledgerid;
            double recamt;
            int BDVouYear;
            Boolean ptype = false;
            char opstype = 'O', acctype;
            int spgroupid, groupid, opsid;

            string dsledgname = "", strvouno = "", dsbname = "", dschqno = "", Mode = "", strReffno = "";
            string narration, strrecledger, strCustName4Rcpt;
            string strlergername = "", strBrRJVno;
            voutypeid = FAObj.Selvoutypeid("BRRJV", Session["FADbname"].ToString());
            dt = recobj.GetSlipDetails4ReversalBr(recid);

            if (dt.Rows.Count == 1)
            {
                i = 0;
                rcount = dt.Rows.Count;
                slipdate = Convert.ToDateTime(dt.Rows[i]["slipdate"]);
                //dssldate = (Convert.ToDateTime(string.Format("{yyyy:MM:dd}", slipdate)));
                if (dt.Rows[0]["mode"].ToString() == "C")
                {
                    dsledgname = "CASH COLLECTION ACCOUNT";
                    strvouno = dt.Rows[i]["LTtCd"].ToString();
                    hid_strvouno.Value = strvouno;
                }
                else
                {
                    dsledgname = "CHEQUE COLLECTION ACCOUNT";
                    dsbname = dt.Rows[i]["bankname"].ToString();
                    //dsbname = dsbname.Replace("&", "&amp;")  check
                    dschqno = dt.Rows[i]["chequeno"].ToString();
                    strvouno = dt.Rows[i]["LTtbd"].ToString();
                    hid_strvouno.Value = strvouno;
                }

                strReffno = Mode + "R-" + dt.Rows[i]["receiptno"].ToString();
                recamt = Convert.ToDouble(dt.Rows[i]["amount"]);
                BDVouYear = Convert.ToInt32(dt.Rows[i]["vouyear"]);
                if (ptype)
                {
                    narration = "DEPOSIT SLIP NO. " + dt.Rows[0]["slipno"];
                }
                else
                {
                    narration = " CHQ." + dschqno + "/DEPOSIT SLIP NO. " + dt.Rows[0]["slipno"];
                }

                intBrRJVno = FAObj.GetBPRRJVNO(Convert.ToInt32(Session["LoginBranchid"]), "R");
                if (intBrRJVno==0)
                {
                    return;
                }
                strBrRJVno = intBrRJVno.ToString();
                voucherid = FAObj.InsFAVouHead(Session["FADbname"].ToString(), voutypeid, strBrRJVno, logobj.GetDate(), narration + "/" + txt_remark.Text + " - Reversal for " + strReffno, "AC", deptid, 0, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), logobj.GetDate(), 'N', BDVouYear);
                FAObj.UpdateFAVouHeadDetails(Session["FADbname"].ToString(), "REFNO", voucherid, strReffno, 0, "");
                FAObj.UpdateFAVouHeadDetails(Session["FADbname"].ToString(), "Cheque", Convert.ToInt32(voucherid), dschqno, 0, "");
                strrecledger = "CTC ACCOUNT-" + DivObj.GetShortName(Convert.ToInt32(Session["LoginDivisionId"])) + "-CO";
                ledgerid = FAObj.Selledgeridforops(Session["FADbname"].ToString(), strrecledger, opstype);

                if (ledgerid == 0)
                {
                    ledgerid = Ldrobj.InsLedgerHeadfromTally(strrecledger.ToString(), 26, 1, 'B', 0, 'O', Session["FADbname"].ToString());
                }

                FAObj.InsFAVouDetails(Session["FADbname"].ToString(), voucherid, ledgerid, "Cr", Amt, vouyr, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                dtCuschrg = recobj.GetRecptCust4FA(recid);

                if (dtCuschrg.Rows.Count > 0)
                {
                    double cusamt;
                    for (i = 0; i <= dtCuschrg.Rows.Count - 1; i++)
                    {
                        cusamt = 0;
                        cusamt = Convert.ToDouble(dtCuschrg.Rows[i]["amount"]);
                        if (dtCuschrg.Rows[i]["branchid"].ToString() == Session["LoginBranchid"].ToString())
                        {
                            strCustName4Rcpt = dtCuschrg.Rows[i]["Customer"].ToString();
                            ledgerid = Ldrobj.ChkLedgeridfrmLedHead(Convert.ToInt32(strCustName4Rcpt), "C", Session["FADbname"].ToString());

                            if (ledgerid == 0)
                            {
                                ledgerid = Ldrobj.InsLedgerHeadfromTally(dtCuschrg.Rows[i]["cc"].ToString(), 1, 1, 'G', Convert.ToInt32(dtCuschrg.Rows[i]["Customer"]), 'C', Session["FADbname"].ToString());
                            }
                        }
                        else
                        {
                            strCustName4Rcpt = Obj_OSDNCN.GetPortCode(Convert.ToInt32(dtCuschrg.Rows[i]["branchid"].ToString()));
                            JVFA4ML(Convert.ToInt32(dt.Rows[0]["receiptno"].ToString()), i);

                            ledgerid = FAObj.Sellegerid4IntrBr(strCustName4Rcpt, 'O', Convert.ToInt32(dtCuschrg.Rows[i]["branchid"]), Session["FADbname"].ToString());
                            if (ledgerid == 0)
                            {
                                ledgerid = Ldrobj.InsLedgerHeadfromTally(strCustName4Rcpt, 1, 1, 'G', 0, 'O', Session["FADbname"].ToString());
                            }
                        }


                        if (cusamt > 0)
                        {
                            FAObj.InsFAVouDetails(Session["FADbname"].ToString(), Convert.ToInt32(voucherid), Convert.ToInt32(ledgerid), "Dr", Convert.ToDouble(cusamt), vouyr, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }
                        else if (cusamt < 0)
                        {
                            if (rcount == 1)
                            {
                                FAObj.InsFAVouDetails(Session["FADbname"].ToString(), Convert.ToInt32(voucherid), Convert.ToInt32(ledgerid), "Cr",Convert.ToDouble(cusamt), vouyr, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                            }
                        }
                    }
                }

                dt = recobj.GetRecptChrg(recid);
                if (dt.Rows.Count > 0)
                {
                    for (int y = 0; y <= dt.Rows.Count - 1; y++)
                    {
                        double ctamt;
                        ctamt = 0;
                        ctamt = Convert.ToDouble(dt.Rows[y]["amount"]);
                        ledgerid = FAObj.Selledgeridforops(Session["FADbname"].ToString(), "TAX DEDUCTED AT SOURCE RECEIVABLE", opstype);  //strlergername
                        if (ctamt < 0)
                        {
                            FAObj.InsFAVouDetails(Session["FADbname"].ToString(), Convert.ToInt32(voucherid), Convert.ToInt32(ledgerid), "Cr", Math.Abs(ctamt), vouyr, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }
                        else
                        {
                            FAObj.InsFAVouDetails(Session["FADbname"].ToString(), Convert.ToInt32(voucherid), Convert.ToInt32(ledgerid), "Dr", Math.Abs(ctamt), vouyr, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }
                    }
                }

                if (rcount > 1)
                {
                    dt = FAObj.GetFAES(recid);
                }
                else
                {
                    dt = recobj.GetES(recid);
                }

                if (dt.Rows.Count > 0)
                {
                    for (int y = 0; y <= dt.Rows.Count - 1; y++)
                    {
                        double ctamt;
                        ctamt = 0;
                        ctamt = Convert.ToDouble(dt.Rows[y]["amount"]);
                        ledgerid = FAObj.Selledgeridforops(Session["FADbname"].ToString(), "EXCESS / SHORT", opstype);
                        if (ctamt < 0)
                        {
                            FAObj.InsFAVouDetails(Session["FADbname"].ToString(), Convert.ToInt32(voucherid), Convert.ToInt32(ledgerid), "Cr", Math.Abs(ctamt), vouyr, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }else
                        {
                            FAObj.InsFAVouDetails(Session["FADbname"].ToString(), Convert.ToInt32(voucherid), Convert.ToInt32(ledgerid), "Dr", Math.Abs(ctamt), vouyr, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        }
                        break;
                    }
                }

                GetDepositdata4BDCo();
            }
        }

            
        public void GetDepositdata4BDCo()
        {
            //DataAccess.Accounts.Recipts RcptObj = new DataAccess.Accounts.Recipts();
            //DataAccess.FAVoucher Obj_FAVoucher = new DataAccess.FAVoucher();
            DataTable DSDt = new DataTable();
            Boolean ptype = false;
            string dsbname = "", dschqno = "";
            int deptid = 0, ledgerid;
            int intrslt;
            DateTime chequedate;
            string recbank, chqdate;
            string narration;
            logCorpID = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), "CORPORATE");
            DSDt = RcptObj.GetSlipDetails4ReversalCo(recid);
            voutypeid = FAObj.Selvoutypeid("BRRJV", Session["FADbname"].ToString());

            if (DSDt.Rows.Count == 1)
            {
                string strReffno = "";
                int i = 0;
                slipdate = Convert.ToDateTime(DSDt.Rows[i]["slipdate"]);
                //dssldate = (Convert.ToDateTime(string.Format("{yyyy:MM:dd}", slipdate)));
                if (DSDt.Rows[0]["mode"].ToString() == "C")
                {
                    dsbname = DSDt.Rows[i]["bankname"].ToString();
                    //dsbname = dsbname.Replace("&", "&amp;") check
                }
                else
                {
                    dsbname = DSDt.Rows[i]["bankname"].ToString();
                    //dsbname = dsbname.Replace("&", "&amp;") check
                    dschqno = DSDt.Rows[i]["chequeno"].ToString();
                    chequedate = Convert.ToDateTime(DSDt.Rows[i]["chequedate"].ToString());
                    //chqdate = (Convert.ToDateTime(string.Format("{yyyy:MM:dd}", chequedate)).ToString());
                    recbank = DSDt.Rows[i]["recbankname"].ToString();
                    //recbank = recbank.Replace("&", "&amp;") check
                }

                strReffno = Obj_Branch.GetShortName(Convert.ToInt32(Session["LoginBranchid"])) + "/BR-" + DSDt.Rows[i]["receiptno"] + "/" + DSDt.Rows[i]["vouyear"];
                recamt = Convert.ToDouble(DSDt.Rows[i]["amount"].ToString());
                BDVouYear = Convert.ToInt32(DSDt.Rows[i]["vouyear"]);
                partyledger = "CTC ACCOUNT-" + Obj_Branch.GetShortName(Convert.ToInt32(Session["LoginBranchid"]));
                if (ptype)
                {
                    narration = "DEPOSIT SLIP NO. " + txt_receiv.Text;
                }
                else
                {
                    narration = " CHQ." + dschqno + "/DEPOSIT SLIP NO. " + DSDt.Rows[0]["slipno"];
                }
                intCoRJVno = FAObj.GetBPRRJVNO(logCorpID, "R");

                if (intCoRJVno == 0)
                {
                    return;
                }

                if (Obj_FAVoucher.CheckFAExists4Voucher4CorpJV(intCoRJVno, Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), voutypeid, logCorpID, Session["FADbname"].ToString()) != 0)
                {
                    BlnVouChk = false;
                    return;
                }
                else
                {
                    BlnVouChk = true;
                }
                //Raj
                //voucherid = FAObj.InsFAVouHead(Session["FADbname"].ToString(), voutypeid, intCoRJVno.ToString(), logobj.GetDate(), narration + "/" + txt_remark.Text + " - Reversal for " + strReffno, "AC", deptid, 0, logCorpID, Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), logobj.GetDate(), 'N', BDVouYear);
                voucherid = FAObj.InsFAVouHead(Session["FADbname"].ToString(), voutypeid, intCoRJVno.ToString(), logobj.GetDate(), narration + "/Reversal For BR-" + DSDt.Rows[i]["receiptno"].ToString(), "AC", deptid, 0, logCorpID, Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), logobj.GetDate(), 'N', BDVouYear);
                //Update PBid
                FAObj.UpdPBid4VouHead(Session["FADbname"].ToString(), voucherid, Convert.ToInt32(Session["LoginBranchid"]));
                //Update Ref No for Co-Accounts
                FAObj.UpdateFAVouHeadDetails(Session["FADbname"].ToString(), "REFNO", voucherid, strReffno, 0, "");
                //Update Cheque No for Co-Accounts
                FAObj.UpdateFAVouHeadDetails(Session["FADbname"].ToString(), "Cheque", voucherid, dschqno, 0, "");
                ledgerid = FAObj.Selledgeridforops(Session["FADbname"].ToString(), dsbname, 'O');

                if (ledgerid == 0)
                {
                    ledgerid = Ldrobj.InsLedgerHeadfromTally(dsbname, 26, 1, 'G', 0, 'O', Session["FADbname"].ToString());
                }

                if (ledgerid != 0)
                {
                    FAObj.InsFAVouDetails(Session["FADbname"].ToString(), voucherid, ledgerid, "Cr", recamt, BDVouYear, logCorpID, Convert.ToInt32(Session["LoginDivisionId"]));
                }

                ledgerid = FAObj.Selledgeridforops(Session["FADbname"].ToString(), partyledger, 'O');
                if (ledgerid == 0)
                {
                    ledgerid = Ldrobj.InsLedgerHeadfromTally(partyledger, 32, 13, 'G', 0, 'O', Session["FADbname"].ToString());
                }

                if (ledgerid != 0)
                {
                    FAObj.InsFAVouDetails(Session["FADbname"].ToString(), voucherid, ledgerid, "Dr", recamt, BDVouYear, logCorpID, Convert.ToInt32(Session["LoginDivisionId"]));
                }
            }
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_vou.Text=="")
                {
                    return;
                }
                vouyr = Convert.ToInt32(txt_vou.Text);

                if (hid_AlertMsg.Value == "N")
                {
                    ScriptManager.RegisterStartupScript(btn_confirm, typeof(Button), "ChequeBonus", "alertify.alert('Not Bounced');", true);
                    return;
                }

                recid = Convert.ToInt32(hid_receiptid.Value);
                recno = Convert.ToInt32(hid_receiptno.Value);
                RecDate = Convert.ToDateTime(hid_recdate.Value);
                custid = Convert.ToInt32(hid_custid.Value);
                Amt = Convert.ToDouble(hid_Amt.Value);
                bankid = Convert.ToInt32(hid_bankid.Value);
                bbranch = hid_bbranch.Value;
                chqdt = Convert.ToDateTime(hid_chqdt.Value);
                int intBnkLedgID = FAObj.Selledgeridforops(Session["FADbname"].ToString(), txt_bank.Text, 'O');
                if (intBnkLedgID !=0)
                {
                    Boolean Bln_ChkMinMaxAmt = false;
                    Bln_ChkMinMaxAmt = pymtobj.CheckMedgerMaxMinAmt4Pmt(intBnkLedgID, Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToDouble(txt_amount.Text), Session["FADbname"].ToString());
                    if (Bln_ChkMinMaxAmt == false)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Closing Balance has Crossed the maximum limit. You can not able to Issue the Payment')", true);
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closingamount();", true);
                      
                        return;
                    }
                }
                if (Rptype.Value.ToString() == "R")
                {
                    if (txt_remark.Text != "")
                    {
                        dt = recobj.GetSlipDetails4ReversalBr(recid);

                        if (dt.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Cannot Cancel the Receipt before put Deposit Slip')", true);
                            return;
                        }

                        logCorpID = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), "CORPORATE");

                        if (logCorpID == branchid)
                        {
                            if (vouyr == ALogYear)
                            {
                                //FAObj.SPReversalRcptCorpinFA(branchid, recno, 9, logCorpID, txt_remark.Text.Trim(), Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString());
                            }
                            else
                            {
                                //FAObj.SPReversalRcptCorpinFA4OldChq(branchid, recno, 9, logCorpID, txt_remark.Text.Trim(), Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString(), vouyr);
                            }
                        }
                        else
                        {
                           // GetDepositdata4BDBR();
                        }

                        Amt = -(Convert.ToDouble(Amt));
                        recobj.InsRecptHeadBank(recno, RecDate, 'B', branchid, vouyr, custid, Amt, bankid, bbranch, txt_Check.Text, chqdt, txt_remark.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()));
                        recobj.updSlipIDforBounce(recno, "B", branchid, vouyr);
                        recobj.InsChqBounce(recid, 'R');
                        recobj.DelRecAgInv(recid, 'R');
                        recobj.DelRectPmt(recid, 'R');

                        if (txt_customer.Text != "" && txt_amoun.Text != "")
                        {
                            custAmt = custAmt * -1;
                            dcusid = custobj.GetCustomerid(txt_customer.Text);
                            recobj.InsReciptCustomerDetail(recid, dcusid, custAmt);
                        }

                        if (txt_dection.Text != "" && txt_amou.Text != "")
                        {
                            TDSAmt = TDSAmt * -1;
                            dcrgid = chrgobj.GetChargeid(txt_dection.Text);
                            recobj.InsReciptChargeDetail(recid, dcrgid, TDSAmt);
                        }

                        if (txt_amo.Text != "")
                        {
                            ESAmt = ESAmt * -1;
                            recobj.InsReciptChargeDetail(recid, 0, ESAmt);
                        }

                        btn_confirm.Enabled = true;

                        if (Session["str_ModuleName"].ToString() == "FA")
                        {
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1166, 2, Convert.ToInt32(Session["LoginBranchid"]), "RecID-" + recid + "/Amt" + recamt);
                        }
                        else
                        {
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1270, 2, Convert.ToInt32(Session["LoginBranchid"]), "RecID-" + recid + "/Amt" + recamt);
                        }
                        reset();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Cheque Return Confirmed')", true);
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Remarks should not be Empty')", true);
                        //txt_remark.Focus();
                    }
                }
                else
                {
                    logCorpID = HREmpobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), "CORPORATE");
                    if (logCorpID == branchid)
                    {
                        voutypeid = 11;
                        if (vouyr == ALogYear)
                        {

                            if (FAObj.CheckFAExists4Voucher4Corp(recno, vouyr, chkbranchid, voutypeid, Session["FADbname"].ToString()) != 0)
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Voucher Not Found in FA. Cannot cancel the Payment');", true);
                                return;
                            }
                            //FAObj.ReversalPmtinFA(Convert.ToInt32(Session["LoginBranchid"]), recno, 11, 0, txt_remark.Text + "/Reversal for Payment #" + recno, Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString());
                        }
                        else
                        {
                            if (FAObj.CheckFAExists4Voucher4Corp(recno, vouyr, chkbranchid, voutypeid, Session["FADbname"].ToString()) != 0)
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Voucher Not Found in Previous Financial Year. Cannot cancel the Payment');", true);
                                return;
                            }
                            //FAObj.ReversalPmtinFA4OldChq(Convert.ToInt32(Session["LoginBranchid"]), recno, 11, 0, txt_remark.Text + "/Reversal for Payment #" + recno, Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString(), vouyr);
                        }
                    }
                    else
                    {
                        voutypeid = 103;
                        if (vouyr == ALogYear)
                        {
                            if (FAObj.CheckFAExists4Voucher(recno, vouyr, chkbranchid, voutypeid, Session["FADbname"].ToString()) != 0)
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Voucher Not Found in FA. Cannot cancel the Payment');", true);
                                return;
                            }
                            //FAObj.ReversalPmtinFA(chkbranchid, recno, 11, logCorpID, txt_remark.Text + "/Reversal for Payment #" + recno, Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString());
                        }
                        else
                        {
                            if (FAObj.CheckFAExists4Voucher(recno, vouyr, chkbranchid, voutypeid, Session["FADbname"].ToString()) != 0)
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Voucher Not Found in Previous Financial Year. Cannot cancel the Payment');", true);
                                return;
                            }
                            //FAObj.ReversalPmtinFA4OldChq(chkbranchid, recno, 11, logCorpID, txt_remark.Text + "/Reversal for Payment #" + recno, Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString(), vouyr);
                        }
                    }

                    recobj.InsChqBounce(recid, 'P');
                    recobj.DelRecAgInv(recid, 'P');

                    recobj.DelRectPmt(recid, 'P');
                    pymtobj.DelCustChrgsPymt(recid);
                    pymtobj.UpdPaymentDeleted(recid);

                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1179, 2, Convert.ToInt32(Session["LoginBranchid"]), "PayID-" + recid + "/Amt" + recamt);
                    reset();
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Payment Deleted');", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "FA", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                reset();
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

        public void reset()
        {
            txt_bank.Text = "";
            txt_Check.Text = "";
            txt_rec.Text = "";
            txt_customer.Text = "";
            txt_amo.Text = "";
            txt_amou.Text = "";
            txt_amoun.Text = "";
            txt_amount.Text = "";
            txt_Check.Text = "";
            txt_dection.Text = "";
            txt_receip.Text = "";
            txt_receiv.Text = "";
            txt_remark.Text = "";
            txt_total.Text = "";
            txt_vou.Text = "";
            div_grid.DataSource = dts;
            div_grid.DataBind();
            btn_confirm.Enabled = false;
            Amt = 0;
            custAmt = 0;
            TDSAmt = 0;
            ESAmt = 0;
            sumAmt = 0;
            Session["obj_dt"] = null;
            btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void div_grid_RowDataBound(object sender, GridViewRowEventArgs e)
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

                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        public void JVFA4ML(int j, int x)
        {
            //DataAccess.HR.Employee Obj_Emp = new DataAccess.HR.Employee();
            //DataAccess.Accounts.OSDNCN Obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            //DataAccess.Accounts.Journal Obj_Journal = new DataAccess.Accounts.Journal();
            //DataAccess.FAVoucher FAObj = new DataAccess.FAVoucher();

            int jvvouno = 0, jvoucherid, jledgerid, jvoutypeid, intBrID, intDivID = 0;
            DataTable Dt_Divid = new DataTable();
            string strjvvou = "", logBrName = "";
            DateTime joudate;
            double cust_amt = 0.00;


            logBrName = Obj_OSDNCN.GetPortCode(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            intBrID = Convert.ToInt32(dtCuschrg.Rows[i]["branchid"].ToString());
            Dt_Divid = Obj_Emp.GetBranchandDivision(intBrID);
            if (Dt_Divid.Rows.Count > 0)
            {
                intDivID = Convert.ToInt32(Dt_Divid.Rows[0]["divisionid"].ToString());
            }

            jvvouno = Obj_Journal.GetJournalNoMONTH(intBrID, logobj.GetDate());
            jvoucherid = Obj_Journal.Selvoutypeid("Journal", Session["FADbname"].ToString());
            joudate = Convert.ToDateTime(logobj.GetDate());
            cust_amt = Convert.ToDouble(dtCuschrg.Rows[i]["amount"].ToString());

            jvoucherid = FAObj.InsFAVouHead(Session["FADbname"].ToString(), jvoucherid, jvvouno.ToString(), joudate, Obj_Branch.GetShortName(intBrID) + " - Receipt #: " + j + " Reversal Amount collected at " + logBrName + ".", "AC", 0, 0, intBrID, intDivID, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToDateTime(logobj.GetDate()), 'N', Convert.ToInt32(hid_year.Value));
            FAObj.UpdateFAVouHeadDetails(Session["FADbname"].ToString(), "REFNO", jvoucherid, hid_strvouno.Value, 0, "");

            jledgerid = FAObj.Sellegerid4IntrBr(logBrName, 'O', Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["FADbname"].ToString());

            if (jledgerid == 0)
            {
                jledgerid = Ldrobj.InsLedgerHeadfromTally(logBrName, 1, 1, 'G', 0, 'O', Session["FADbname"].ToString());
            }

            if (cust_amt < 0)
            {
                FAObj.InsFAVouDetails(Session["FADbname"].ToString(), jvoucherid, jledgerid, "Dr", Convert.ToDouble(dtCuschrg.Rows[i]["amount"]), vouyr, intBrID, intDivID);
            }
            else
            {
                FAObj.InsFAVouDetails(Session["FADbname"].ToString(), jvoucherid, jledgerid, "Cr", Convert.ToDouble(dtCuschrg.Rows[i]["amount"]), vouyr, intBrID, intDivID);
            }

            jledgerid = FAObj.Selledgerid(Session["FADbname"].ToString(), Convert.ToInt32(dtCuschrg.Rows[i]["Customer"]), 'C');
            if (jledgerid == 0)
            {
                jledgerid = Ldrobj.InsLedgerHeadfromTally(custobj.GetCustomername(Convert.ToInt32(dtCuschrg.Rows[i]["Customer"])), 1, 1, 'G', custid, 'C', Session["FADbname"].ToString());
            }


            if (cust_amt < 0)
            {
                FAObj.InsFAVouDetails(Session["FADbname"].ToString(), jvoucherid, jledgerid, "Cr", Convert.ToDouble(dtCuschrg.Rows[i]["amount"].ToString()), vouyr, intBrID, intDivID);
            }
            else
            {

                FAObj.InsFAVouDetails(Session["FADbname"].ToString(), jvoucherid, jledgerid, "Dr", Convert.ToDouble(dtCuschrg.Rows[i]["amount"].ToString()), vouyr, intBrID, intDivID);
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
            Panel3.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1166, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1270, "", "", "", Session["StrTranType"].ToString());
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
      

       

