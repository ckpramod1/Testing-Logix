using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services.Description;

namespace logix.FAForm
{
    public partial class Journal : System.Web.UI.Page
    {
        DateTime joudate;
        DateTime vdate;
        int vtypeid;
        int voutypeid;
        int vouno;
        int vouid;
        int lbranchid;
        bool recedit;
        bool blnErr;
        double totdbAmnt;
        double totcramnt;
        DataTable dt;
        DataTable dt2;
        DataTable DtRef;
        DataRow row;
        int vousubid, Vou_ID;
        DataTable Dt = new DataTable();
        DataTable Dt2 = new DataTable();
        bool flag;
        int bid, VouID;
        string Type;
        string Trantype, Str_CurrrentDate;

        DataAccess.FAVoucher Obj_Voucher = new DataAccess.FAVoucher();
        DataAccess.Accounts.Journal Jnlobj = new DataAccess.Accounts.Journal();
        DataAccess.LogDetails Obj_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterBranch Master_Branch = new DataAccess.Masters.MasterBranch();
        DataAccess.FAVoucher Obj_FA = new DataAccess.FAVoucher();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            // string Ccode = Convert.ToString(Session["Ccode"]);
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Obj_Voucher.GetDataBase(Ccode);
                Jnlobj.GetDataBase(Ccode);
                Obj_Log.GetDataBase(Ccode);
                Master_Branch.GetDataBase(Ccode);
                Obj_FA.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               

            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lblheader.Text = Request.QueryString["FormName"].ToString();
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (IsPostBack != true)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                txtjnlno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                string vtypes;
                //txtdate.Text = Utility.fn_ConvertDate(Obj_Log.GetDate().ToString());
                txtvouyear.Text = Session["LogYear"].ToString();
                txtmonth.Text = Obj_Log.GetDate().Month.ToString();
                grd_journal.DataSource = new DataTable();
                grd_journal.DataBind();

                Str_CurrrentDate = Obj_Log.GetDate().ToShortDateString();
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                //string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());


                if (Obj_Log.GetDate().Month < 4)
                {
                    stryear = stryear - 1;
                }
                else
                {
                    //stryear = stryear;
                }


                if (stryear == vouyeartext)
                {
                    //txt_from.Text = "01/04/" + vouyeartext;
                    txtdate.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());

                }
                else
                {
                    //txt_from.Text = "01/04/" + vouyeartext;
                    txtdate.Text = "31/03/" + (vouyeartext + 1);
                }
                if (Request.QueryString.ToString().Contains("Vno"))
                {
                    vouno = Convert.ToInt32(Request.QueryString["Vno"]);
                    txtjnlno.Text = vouno.ToString();
                    vdate = Convert.ToDateTime(Utility.fn_ConvertDate(Request.QueryString["Vdate"].ToString()));
                    vtypes = Request.QueryString["VType"];
                    txtdate.Text = Request.QueryString["Vdate"];
                    lbranchid = Convert.ToInt32(Request.QueryString["PBranch_ID"]);
                    hid_BranchID.Value = lbranchid.ToString();
                     btncancel.Text = "Back";


                    btncancel.ToolTip = "Back";
                    btncancel1.Attributes["class"] = "btn ico-back";

                    if (Request.QueryString.ToString().Contains("flag"))
                    {
                        hf_flag.Value = (Request.QueryString["flag"].ToString());
                        hf_vid.Value = (Request.QueryString["vid"].ToString());
                        hidfdate.Value = (Request.QueryString["fdate"].ToString());
                        hidtdate.Value = (Request.QueryString["tdate"].ToString());
                        hidvoutype.Value = (Request.QueryString["type"].ToString());
                    }
                    GetJournalDet();
                    txtdate.Enabled = false;
                }
                else
                {
                    hid_BranchID.Value = Session["LoginBranchid"].ToString();
                }

                if (Request.QueryString.ToString().Contains("QueryVoucherName"))
                {
                    txtjnlno.Text = Request.QueryString["QueryVoucherNo"].ToString();
                    GetJournalDet();
                }


            }

            hid_Vouyear.Value = txtdate.Text;
            Trantype = Session["str_ModuleName"].ToString();
        }

        public void GetJournalDet()
        {
            recedit = false;
            int voumonth = vdate.Month;
            //DataAccess.Accounts.Journal Jnlobj = new DataAccess.Accounts.Journal();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            DataTable Dt = new DataTable();
            DataTable Dt2 = new DataTable();
            DataTable dtVouc = new DataTable();
            int Branch_ID;

            vtypeid = Jnlobj.Selvoutypeid("Journal", Session["FADbname"].ToString());

            if (hid_BranchID.Value != "" && hid_BranchID.Value != "0")
            {
                Branch_ID = Convert.ToInt32(hid_BranchID.Value);
            }
            else
            {
                Branch_ID = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }

            if (txtjnlno.Text != "")
            {
                Dt = Jnlobj.SelFAvoucherHead(Branch_ID, Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), vtypeid, Session["FADbname"].ToString(), voumonth);
                if (Dt.Rows.Count > 0)
                {
                    recedit = true;
                    txtnarration.Text = Dt.Rows[0]["narration"].ToString();
                    txtjobno.Text = Dt.Rows[0]["JobNo"].ToString();
                    txtref.Text = Dt.Rows[0]["RefNo"].ToString();
                    lbl_name.Text = Dt.Rows[0]["empname"].ToString();

                    Dt2 = Jnlobj.SelFAvoucherDetails(Branch_ID, Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), vtypeid, Session["FADbname"].ToString(), voumonth);

                    if (Dt2.Rows.Count > 0)
                    {
                        dtVouc.Columns.Add("ledgertype");
                        dtVouc.Columns.Add("ledgername");
                        dtVouc.Columns.Add("Debit");
                        dtVouc.Columns.Add("Credit");
                        dtVouc.Columns.Add("vousubid");
                        dtVouc.Columns.Add("opstype");
                        dtVouc.Columns.Add("ledgerid");

                        for (int i = 0; i <= Dt2.Rows.Count - 1; i++)
                        {
                            Type = Dt2.Rows[i]["ledgertype"].ToString();
                            if (Type == "Dr")
                            {
                                row = dtVouc.NewRow();
                                dtVouc.Rows.Add();
                                dtVouc.Rows[i]["ledgertype"] = Dt2.Rows[i]["ledgertype"].ToString();
                                dtVouc.Rows[i]["ledgername"] = Dt2.Rows[i]["ledgername"].ToString();
                                dtVouc.Rows[i]["Debit"] = Convert.ToDouble(Dt2.Rows[i]["ledgeramount"]).ToString();
                                dtVouc.Rows[i]["vousubid"] = Dt2.Rows[i]["vousubid"].ToString();
                                dtVouc.Rows[i]["opstype"] = Dt2.Rows[i]["opstype"].ToString();
                                dtVouc.Rows[i]["ledgerid"] = Dt2.Rows[i]["ledgerid"].ToString();
                                grd_journal.DataSource = dtVouc;
                                grd_journal.DataBind();
                            }
                        }

                        for (int i = 0; i <= Dt2.Rows.Count - 1; i++)
                        {
                            Type = Dt2.Rows[i]["ledgertype"].ToString();
                            if (Type == "Cr")
                            {
                                row = dtVouc.NewRow();
                                dtVouc.Rows.Add();
                                dtVouc.Rows[i]["ledgertype"] = Dt2.Rows[i]["ledgertype"];
                                dtVouc.Rows[i]["ledgername"] = Dt2.Rows[i]["ledgername"];
                                dtVouc.Rows[i]["Credit"] = Convert.ToDouble(Dt2.Rows[i]["ledgeramount"]);
                                dtVouc.Rows[i]["vousubid"] = Dt2.Rows[i]["vousubid"].ToString();
                                dtVouc.Rows[i]["opstype"] = Dt2.Rows[i]["opstype"].ToString();
                                dtVouc.Rows[i]["ledgerid"] = Dt2.Rows[i]["ledgerid"].ToString();
                                grd_journal.DataSource = dtVouc;
                                grd_journal.DataBind();
                            }
                        }
                    }
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

                 btndelete.Text = "Delete";

                btndelete.ToolTip = "Delete";
                btndelete1.Attributes["class"] = "btn ico-delete";
                  btncancel.Text = "Cancel";

                btncancel.ToolTip = "Cancel";
                btncancel1.Attributes["class"] = "btn ico-cancel";

                Vou_ID = Obj_Voucher.GetVouIdJou(Convert.ToInt32(txtjnlno.Text), Convert.ToInt32(hid_BranchID.Value), vtypeid, Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month);
                hid_VouID.Value = Vou_ID.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(btndelete, typeof(Button), "Valid text", "alertify.alert('Invalid voucher');", true);
                ClearAll();
            }
        }

        public void getjourvalue()
        {
            recedit = false;
            txtmont.Value = Convert.ToInt32(vdate.Month).ToString();
          //  DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            DataTable dts = new DataTable();

            if (txtmont.Value == "")
            {
                txtmont.Value = "0";
            }

            voutypeid = Jnlobj.Selvoutypeid("Journal", Session["FADbname"].ToString());
            Vou_ID = Obj_Voucher.GetVouIdJou(Convert.ToInt32(txtjnlno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), voutypeid, Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month);
            hid_VouID.Value = Vou_ID.ToString();

            if (txtjnlno.Text != "")
            {
                Dt = Jnlobj.SelFAvoucherHead(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), voutypeid, Session["FADbname"].ToString(), (Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text))).Month);
                if (Dt.Rows.Count > 0)
                {
                    recedit = true;
                    txtnarration.Text = Dt.Rows[0]["narration"].ToString();
                    vouid = Convert.ToInt32(Dt.Rows[0]["vouid"]);
                    Session["vouid"] = vouid;
                    txtjobno.Text = Dt.Rows[0]["JobNo"].ToString();
                    txtref.Text = Dt.Rows[0]["RefNo"].ToString();

                    DateTime journaldate = new DateTime();
                    journaldate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                    txtdate.Text = Utility.fn_ConvertDate(journaldate.ToString());

                    lbl_name.Text = Dt.Rows[0]["empname"].ToString();
                    Dt2 = Jnlobj.SelFAvoucherDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), voutypeid, Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month);
                }

                if (Dt2.Rows.Count > 0)
                {
                    dts.Columns.Add("ledgertype");
                    dts.Columns.Add("ledgername");
                    dts.Columns.Add("Debit");
                    dts.Columns.Add("Credit");
                    dts.Columns.Add("vousubid");
                    dts.Columns.Add("opstype");
                    dts.Columns.Add("ledgerid");

                    for (int i = 0; i <= Dt2.Rows.Count - 1; i++)
                    {
                        Type = Dt2.Rows[i]["ledgertype"].ToString();
                        if (Type == "Dr")
                        {
                            row = dts.NewRow();
                            dts.Rows.Add();
                            dts.Rows[i]["ledgertype"] = Dt2.Rows[i]["ledgertype"].ToString();
                            dts.Rows[i]["ledgername"] = Dt2.Rows[i]["ledgername"].ToString();
                            dts.Rows[i]["Debit"] = Convert.ToDouble(Dt2.Rows[i]["ledgeramount"]).ToString();
                            dts.Rows[i]["vousubid"] = Dt2.Rows[i]["vousubid"].ToString();
                            dts.Rows[i]["opstype"] = Dt2.Rows[i]["opstype"].ToString();
                            dts.Rows[i]["ledgerid"] = Dt2.Rows[i]["ledgerid"].ToString();
                            grd_journal.DataSource = dts;
                            grd_journal.DataBind();
                        }
                    }

                    for (int i = 0; i <= Dt2.Rows.Count - 1; i++)
                    {
                        Type = Dt2.Rows[i]["ledgertype"].ToString();

                        if (Type == "Cr")
                        {
                            row = dts.NewRow();
                            dts.Rows.Add();
                            dts.Rows[i]["ledgertype"] = Dt2.Rows[i]["ledgertype"];
                            dts.Rows[i]["ledgername"] = Dt2.Rows[i]["ledgername"];
                            dts.Rows[i]["Credit"] = Convert.ToDouble(Dt2.Rows[i]["ledgeramount"]);
                            dts.Rows[i]["vousubid"] = Dt2.Rows[i]["vousubid"].ToString();
                            dts.Rows[i]["opstype"] = Dt2.Rows[i]["opstype"].ToString();
                            dts.Rows[i]["ledgerid"] = Dt2.Rows[i]["ledgerid"].ToString();
                            grd_journal.DataSource = dts;
                            grd_journal.DataBind();
                        }
                    }
                }

                if (dts.Rows.Count > 0)
                {
                    totdbAmnt = 0;
                    totcramnt = 0;
                    for (int i = 0; i <= dts.Rows.Count - 1; i++)
                    {
                        if (dts.Rows[i]["Debit"].ToString() != "")
                        {
                            totdbAmnt = totdbAmnt + Convert.ToDouble(dts.Rows[i]["Debit"].ToString());
                        }
                        if (dts.Rows[i]["Credit"].ToString() != "")
                        {
                            totcramnt = totcramnt + Convert.ToDouble(dts.Rows[i]["Credit"].ToString());
                        }
                    }
                    txtDbtAmnt.Text = string.Format("{0:0.00}", totdbAmnt);
                    txtCrAmnt.Text = string.Format("{0:0.00}", totcramnt);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Invalid voucher');", true);
                    ClearAll();
                }
               btncancel.Text = "Cancel";


                btncancel.ToolTip = "Cancel";
                btncancel1.Attributes["class"] = "btn ico-cancel";

            }
        }

        public void ClearAll()
        {
             btncancel.Text = "Back";


            btncancel.ToolTip = "Back";
            btncancel1.Attributes["class"] = "btn ico-back";
            txtvouyear.Text = Session["LogYear"].ToString();
            txtmonth.Text = "";
            txtjnlno.Text = "";
            txtnarration.Text = "";
            txtDbtAmnt.Text = "";
            txtCrAmnt.Text = "";
            txtjobno.Text = "";
            txtref.Text = "";
            recedit = false;
            txtdate.Enabled = true;
            grd_journal.DataSource = new DataTable();
            grd_journal.DataBind();
            txtdate.Text = Utility.fn_ConvertDate(Obj_Log.GetDate().ToString());
            lbl_name.Text = "Name";
        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {

            DateTime dt_logDate = new DateTime();
            DateTime Fbegin, Fend;
            string[] FAYEAR;


            FAYEAR = Session["LYEAR"].ToString().Split('-');
            Fbegin = Convert.ToDateTime("04/01/20" + FAYEAR[0]);
            Fend = Convert.ToDateTime("03/31/20" + FAYEAR[1]);
            txtvouyear.Text = Fbegin.Year.ToString();


            dt_logDate = Convert.ToDateTime(Utility.fn_ConvertDate(hid_Vouyear.Value));

            if (dt_logDate.Month == Obj_Log.GetDate().Month && dt_logDate.Year == Obj_Log.GetDate().Year)
            {
                txtdate.Text = Utility.fn_ConvertDate(Obj_Log.GetDate().ToString());
                //txtdate.Text = Obj_Log.GetDate().ToString();
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
                //dt_logDate = new DateTime(dt_logDate.Year, (dt_logDate.Month + 1), 1).AddDays(-1);
                //txtdate.Text = Utility.fn_ConvertDate(dt_logDate.ToString());
            }

            if (dt_logDate.Month < 4 && dt_logDate.Year <= Convert.ToInt32(Session["LogYear"].ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Finanical Year')", true);
                txtdate.Text = Utility.fn_ConvertDate(Obj_Log.GetDate().ToString());
            }
        }

        protected void txtjnlno_TextChanged(object sender, EventArgs e)
        {
            if (txtjnlno.Text != "")
            {
                getjourvalue();
            }
        }

        protected void grd_journal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_journal.Rows.Count > 0)
            {
                if (txtjnlno.Text != "")
                {
                    Jnlobj.DelJouDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtvouyear.Text), vtypeid, Convert.ToInt32(txtjnlno.Text), vousubid, Session["FADbname"].ToString());
                    dt2 = Jnlobj.SelFAvoucherDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(txtjnlno.Text), vtypeid, Session["FADbname"].ToString(), Convert.ToInt32(txtmonth.Text));
                }

                if (dt2.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        grd_journal.DataSource = dt2;
                        grd_journal.DataBind();
                    }
                }
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            string dbname = Session["FADbname"].ToString();
            int Emp_ID = Convert.ToInt32(Session["LoginEmpId"]);
            int Vou_ID = Convert.ToInt32(Session["vouid"]);

            if (Session["vouid"] != "0" && txtjnlno.Text != "")
            {
                DtRef = Jnlobj.SPFAJouRefChkng(dbname, txtref.Text, Vou_ID);
                if (DtRef.Rows.Count == 0)
                {
                    Jnlobj.InsFAVouHeadDeleted(dbname, Emp_ID, Vou_ID);
                    Jnlobj.UpdJouHead(dbname, Vou_ID);
                    Jnlobj.InsFAVouDtlsDeleted(dbname, Vou_ID);
                    Jnlobj.DelVouDetails(Convert.ToInt32(Session["vouid"]), dbname);
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Entry Deleted');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Journal Values Already Found in Receipt/Payment');", true);
                }
                if (Trantype == "FA")
                {
                    Obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1105, 4, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtjnlno.Text) + "/" + txtdate.Text + "/" + Convert.ToInt32(Session["vouid"]));
                }
                else if (Trantype == "FC")
                {
                    Obj_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1191, 4, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtjnlno.Text) + "/" + txtdate.Text + "/" + Convert.ToInt32(Session["vouid"]));
                }

                ClearAll();
            }
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            int Branch_Id = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int DivisionID = Convert.ToInt32(Session["LoginDivisionid"]);
            int LogYear = Convert.ToInt32(Session["LogYear"]);
            int Emp_Id = Convert.ToInt32(Session["LoginEmpId"]);
         //   DataAccess.FAVoucher Obj_FA = new DataAccess.FAVoucher();

            if (txtjnlno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter the Journal #')", true);
                return;
            }
            if (hid_VouID.Value == "")
            {
                return;
            }
            string BranchName = Master_Branch.Getbranchname(Branch_Id);

            Obj_FA.SelFAAllVoucher(Convert.ToInt32(hid_VouID.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());

            Session["str_sfs"] = ""; Session["str_sp"] = ""; Session["str_sfs1"] = ""; Session["str_sp1"] = "";
            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
            str_RptName = "rptJV.rpt";

            //Session["str_sfs"] = "{MasterVoucherHead.vouno}=" + txtjnlno.Text + " and {MasterVoucherHead.voutype}=13 and {MasterVoucherHead.branchid}=" + Branch_Id + "and {MasterVoucherHead.divisionid}= " + DivisionID + "and month({MasterVoucherHead.voudate})=" + Obj_Log.GetDate().Month + "";
            Session["str_sfs"] = " {Tempvoucher.vouid}=" + hid_VouID.Value + " And {Tempvoucher.empid} = " + Emp_Id;
            Session["str_sp"] = "Title=JOURNAL~PeriodFrom=" + "Apr" + Session["FA_Year"].ToString().Substring(0, 2) + "~PeriodTo=" + "Mar" + Session["FA_Year"].ToString().Substring(3, 2) + "~appby=" + Jnlobj.GetJouApprovedBy(Convert.ToInt32(hid_VouID.Value), Session["FADbname"].ToString());

            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                //Obj_Log.InsLogDetail(Emp_Id, 1105, 4, Branch_Id, txtjnlno.Text + "/" + txtdate.Text + "/ V");
                Obj_Log.InsLogDetail(Emp_Id, 1105, 3, Branch_Id, txtjnlno.Text + "/" + txtdate.Text + "/ V");
            }
            else
            {
                //Obj_Log.InsLogDetail(Emp_Id, 1191, 4, Branch_Id, txtjnlno.Text + "/" + txtdate.Text + "/ V");
                Obj_Log.InsLogDetail(Emp_Id, 1191, 3, Branch_Id, txtjnlno.Text + "/" + txtdate.Text + "/ V");
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                ClearAll();
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
                if (Request.QueryString["Str_Name"] == "DayBook_Journal")
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

        protected void grd_journal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "Dr")
                {
                    e.Row.Cells[3].Text = "";
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

                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_journal, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";                                
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
          //  DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1105, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1191, "", "", "", Session["StrTranType"].ToString());
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
    }
}