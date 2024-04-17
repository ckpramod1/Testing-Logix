using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Drawing;

namespace logix.FAForm
{
    public partial class TrialBalanceWEB : System.Web.UI.Page
    {
        DataAccess.FAMaster.ReportView FARepobj = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
        DataSet ds1 = new DataSet();
        int i;
        string Str_CurrrentDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FARepobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
         



            }

            DateTime date;
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_header.Text = Request.QueryString["FormName"].ToString();
            }

            if (!IsPostBack)
            {
              
                 
                if (Session["FADbname"]!=null)
                {
                    date = FARepobj.MaxVouGetDate(Session["FADbname"].ToString());
                }
               
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                Str_CurrrentDate = logobj.GetDate().ToShortDateString();
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                //string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                {
                    if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                    {
                        txt_from.Text = "01/04/" + vouyeartext;
                        txt_to.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());

                    }
                    else
                    {
                        txt_from.Text = "01/04/" + vouyeartext;
                        txt_to.Text = "31/03/" + (vouyeartext + 1);
                    }
                }
                else
                {
                    if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                    {
                        txt_from.Text = "01/01/" + vouyeartext;
                        txt_to.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());

                    }
                    else
                    {
                        txt_from.Text = "01/01/" + vouyeartext;
                        txt_to.Text = "31/12/" + (vouyeartext + 1);
                    }
                }
                //txt_from.Text = "01/04/" + Session["LogYear"].ToString();
                //txt_to.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());
                div_Grdheader.Visible = false;

                string str_CtrlLists = "txt_from~txt_to";
                btn_get.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");

                if (Session["StrTranType"].ToString() == "CO")
                {
                    div_Grdheader.Visible = true;
                    chk_Consolidate.Visible = true;
                    branch_id.Visible = true;
                    btn_branchwise.Visible = true;
                }
                else
                {
                    chk_Consolidate.Visible = false;
                    branch_id.Visible = false;
                    btn_branchwise.Visible = false;
                }
                //btnget_Click(sender, e);
            }

            //grd_trial.DataSource = new DataTable();
            //grd_trial.DataBind();
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string Str_RptName, Str_SF, Str_SP, Str_Script;
            Str_RptName = "";
            Str_SF = "";
            Str_SP = "";
            Str_Script = "";

            if (grd_trial.Rows.Count > 0)
            {
                FARepobj.DelTempFATrailBalance(int.Parse(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());

                for (int i = 0; i < grd_trial.Rows.Count - 2; i++)
                {
                    String str = grd_trial.DataKeys[i].Values[1].ToString();
                    if (grd_trial.Rows[i].Visible == true)
                    {
                        FARepobj.InsTempFATrailBalance(int.Parse(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString(), grd_trial.Rows[i].Cells[1].Text.Replace("&amp;", "&"), Convert.ToDouble(grd_trial.Rows[i].Cells[2].Text),
                        Convert.ToDouble(grd_trial.Rows[i].Cells[3].Text), Convert.ToDouble(grd_trial.Rows[i].Cells[4].Text),
                        Convert.ToDouble(grd_trial.Rows[i].Cells[5].Text), Convert.ToDouble(grd_trial.Rows[i].Cells[6].Text),
                        Convert.ToDouble(grd_trial.Rows[i].Cells[7].Text), grd_trial.DataKeys[i].Values[1].ToString(), i, Convert.ToInt32(Session["LoginBranchid"]));
                    }
                }
            }

            if (hid_tot.Value == "")
            {
                hid_tot.Value = "0";
            }

            Str_RptName = "RptTrailBal4Ledger.rpt";
            Session["str_sfs"] = "{TempTrailBalance.empid}=" + int.Parse(Session["LoginEmpId"].ToString());
            Session["str_sp"] = "Title= Trail Balance  ~fdate=" + Utility.fn_ConvertDate(txt_from.Text) + "~tdate=" + Utility.fn_ConvertDate(txt_to.Text) + "~total=" + hid_tot.Value;

            Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "TrailBalance", Str_Script, true);
            //logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1173, 4, int.Parse(Session["LoginBranchid"].ToString()), txt_from.Text + "  to " + txt_to.Text + "/Vw");            
            if (Session["str_ModuleName"].ToString() == "FA")
            {
                logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1116, 3, int.Parse(Session["LoginBranchid"].ToString()), txt_from.Text + "  to " + txt_to.Text + "/Vw");
            }
            else
            {
                logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1205, 3, int.Parse(Session["LoginBranchid"].ToString()), txt_from.Text + "  to " + txt_to.Text + "/Vw");
            }
        }

        protected void btnget_Click(object sender, EventArgs e)
        {

            string Ccode = Convert.ToString(Session["Ccode"]);




            div_Grdheader.Visible = true;
            string from = Utility.fn_ConvertDate(txt_from.Text);
            string to = Utility.fn_ConvertDate(txt_to.Text);
            head.Visible=true;  
            DateTime FromDate = Convert.ToDateTime(from);
            DateTime ToDate = Convert.ToDateTime(to);

            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btn_get, typeof(Button), "alert", "alertify.alert('From Date Should be Less than To Date');", true);
                txt_from.Focus();
                return;
            }
            GridView2.Visible = false;
            string dispname = "";
            if (chk_alias.Checked == true)
            {
                dispname = "alias";
            }
            else
            {
                dispname = "ledgername";
            }

            //if (chk_Consolidate.Checked == true)
            //{
            //    //ds1 = FARepobj.FAselAllLedgerFTdate4AllBranch(FromDate, ToDate, Session["FADbname"].ToString(), int.Parse(Session["LoginDivisionId"].ToString()));
            //    ds1 = FARepobj.FAselAllLedgerFTdate4AllBranch(FromDate, ToDate, Session["FADbname"].ToString(), int.Parse(Session["LoginDivisionId"].ToString()), dispname);
            //}
            //else
            //{
            //    //ds1 = FARepobj.FAselAllLedgerFTdate_web(int.Parse(Session["LoginBranchid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString());
            //    ds1 = FARepobj.FAselAllLedgerFTdate(int.Parse(Session["LoginBranchid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString(), dispname);
            //}


            if (chk_Consolidate.Checked == true)
            {
               // ds1 = FARepobj.FAselAllLedgerFTdate4AllBranch(FromDate, ToDate, Session["FADbname"].ToString(), int.Parse(Session["LoginDivisionId"].ToString()));
               
               

                    FARepobj.GetDataBase(Ccode);
                    ds1 = FARepobj.FAselTrailBalance4AllBranch(FromDate, ToDate, Session["FADbname"].ToString(), int.Parse(Session["LoginDivisionId"].ToString()), dispname, Convert.ToInt32(Session["LoginEmpId"].ToString()));
            }
            else
            {
                //ds1 = FARepobj.FAselAllLedgerFTdate_web(int.Parse(Session["LoginBranchid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString());
                //ds1 = FARepobj.FAselAllLedgerFTdate(int.Parse(Session["LoginBranchid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString(), dispname);
                 Ccode = Convert.ToString(Session["Ccode"]);

                FARepobj.GetDataBase(Ccode);
                    ds1 = FARepobj.FAselAllLedgerFTdate(int.Parse(Session["LoginBranchid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString(), dispname, Convert.ToInt32(Session["LoginEmpId"].ToString()));
            }

            // grd_trial.Visible = true;amt = 0,
            lblledger.Text = "Trial Balance From " + txt_from.Text + " To " + txt_to.Text;
            if (ds1.Tables.Count > 0)
            {
                dt = ds1.Tables[0];
                int k = 0;
                if (dt.Rows.Count > 0)
                {
                    double dbamt = 0, cramt = 0, dbl_GTotal_db = 0, dbl_GTotal_cr = 0, dbl_sub_GTotal_cr = 0, dbl_sub_GTotal_db = 0,
                totcramt = 0, totdramt = 0, obdramt = 0, obcramt = 0, totobdramt = 0, totobcramt = 0, netdramt = 0,
                netcramt = 0, totnetdramt = 0, totnetcramt = 0, dbl_G_Tot_OB_Dr = 0, dbl_S_Tot_OB_Dr = 0, dbl_G_Tot_OB_Cr = 0,
                dbl_S_Tot_OB_Cr = 0, dbl_G_Tot_Net_Dr = 0, dbl_G_Tot_Net_Cr = 0, dbl_S_Tot_Net_Cr = 0, dbl_S_Tot_Net_Dr = 0;
                    int dbl_previous_GNO = 0, int_RNO = 0, dbl_previous_SNO = 0, count = 0;
                    DataTable obj_dt = new DataTable();
                    obj_dt.Columns.Add("LedgerName", typeof(string));
                    obj_dt.Columns.Add("NewObDebit", typeof(string));
                    obj_dt.Columns.Add("NewObCredit", typeof(string));
                    obj_dt.Columns.Add("NewTransDebit", typeof(string));
                    obj_dt.Columns.Add("NewTransCredit", typeof(string));
                    obj_dt.Columns.Add("Debit", typeof(string));
                    obj_dt.Columns.Add("Credit", typeof(string));
                    obj_dt.Columns.Add("Groupid", typeof(string));
                    obj_dt.Columns.Add("LedgerType", typeof(string));
                    obj_dt.Columns.Add("Ledgerid", typeof(string));
                    string str_sub_groupname = "", str_groupname = "";
                    DataRow dr = obj_dt.NewRow();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {                     
                        if (str_groupname != dt.Rows[i]["groupname"].ToString())
                        {
                            dr = obj_dt.NewRow();
                            obj_dt.Rows.Add();
                            
                            str_groupname = dt.Rows[i]["groupname"].ToString();
                            //dr["Debit"] = "";
                            //dr[i]["LedgerName"] = dt.Rows[i]["groupname"].ToString();
                            obj_dt.Rows[int_RNO]["LedgerName"] = dt.Rows[i]["groupname"].ToString();
                            obj_dt.Rows[dbl_previous_GNO]["NewObDebit"] = dbl_G_Tot_OB_Dr;
                            obj_dt.Rows[dbl_previous_GNO]["NewObCredit"] = dbl_G_Tot_OB_Cr;
                            obj_dt.Rows[dbl_previous_GNO]["NewTransDebit"] = dbl_GTotal_db;
                            obj_dt.Rows[dbl_previous_GNO]["NewTransCredit"] = dbl_GTotal_cr;
                            obj_dt.Rows[dbl_previous_GNO]["Debit"] = dbl_G_Tot_Net_Dr;
                            obj_dt.Rows[dbl_previous_GNO]["Credit"] = dbl_G_Tot_Net_Cr;
                            obj_dt.Rows[int_RNO]["Groupid"] = dt.Rows[i]["Groupid"].ToString();
                            obj_dt.Rows[int_RNO]["LedgerType"] = "G";
                            obj_dt.Rows[int_RNO]["Ledgerid"] = dt.Rows[i]["Ledgerid"].ToString();
                            if (dbl_GTotal_db == 0 && dbl_GTotal_cr == 0 && dbl_G_Tot_OB_Dr == 0 && dbl_G_Tot_OB_Cr==0)
                            {
                                //obj_dt.Rows[dbl_previous_GNO].Delete();
                            }
                            dbl_previous_GNO = int_RNO;
                            int_RNO = int_RNO + 1;
                            dbl_GTotal_cr = 0;
                            dbl_GTotal_db = 0;
                            dbl_G_Tot_OB_Dr = 0;
                            dbl_G_Tot_OB_Cr = 0;
                            dbl_G_Tot_Net_Dr = 0;
                            dbl_G_Tot_Net_Cr = 0;
                        }
                        if (str_sub_groupname != dt.Rows[i]["SubgroupName"].ToString())
                        {
                            dr = obj_dt.NewRow();
                            obj_dt.Rows.Add();
                            //dr["Debit"] = "";
                            str_sub_groupname = dt.Rows[i]["SubgroupName"].ToString();
                            obj_dt.Rows[int_RNO]["LedgerName"] = "     " + dt.Rows[i]["SubgroupName"].ToString();
                            obj_dt.Rows[dbl_previous_SNO]["NewObDebit"] = dbl_S_Tot_OB_Dr;
                            obj_dt.Rows[dbl_previous_SNO]["NewObCredit"] = dbl_S_Tot_OB_Cr;
                            obj_dt.Rows[dbl_previous_SNO]["NewTransDebit"] = dbl_sub_GTotal_db;
                            obj_dt.Rows[dbl_previous_SNO]["NewTransCredit"] = dbl_sub_GTotal_cr;
                            obj_dt.Rows[dbl_previous_SNO]["Debit"] = dbl_S_Tot_Net_Dr;
                            obj_dt.Rows[dbl_previous_SNO]["Credit"] = dbl_S_Tot_Net_Cr;
                            obj_dt.Rows[int_RNO]["Groupid"] = dt.Rows[i]["subgroupid"].ToString();
                            obj_dt.Rows[int_RNO]["LedgerType"] = "S";
                            obj_dt.Rows[int_RNO]["Ledgerid"] = dt.Rows[i]["Ledgerid"].ToString();
                            if (dbl_sub_GTotal_db == 0 && dbl_sub_GTotal_cr == 0 && dbl_S_Tot_OB_Dr == 0 && dbl_S_Tot_OB_Cr==0)
                            {
                                //obj_dt.Rows[dbl_previous_GNO].Delete();
                            }
                            dbl_previous_SNO = int_RNO;
                            int_RNO = int_RNO + 1;
                            dbl_sub_GTotal_db = 0;
                            dbl_sub_GTotal_cr = 0;
                            dbl_S_Tot_OB_Dr = 0;
                            dbl_S_Tot_OB_Cr = 0;
                            dbl_S_Tot_Net_Dr = 0;
                            dbl_S_Tot_Net_Cr = 0;
                        }

                        obdramt = (Convert.ToDouble(dt.Rows[i]["OB_Debit"]));
                        obcramt = Convert.ToDouble(dt.Rows[i]["OB_Credit"]);
                        dbamt = Convert.ToDouble(dt.Rows[i]["Debit"]);
                        cramt = Convert.ToDouble(dt.Rows[i]["Credit"]);
                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add();
                        obj_dt.Rows[int_RNO]["LedgerName"] = "          " + dt.Rows[i]["LedgerName"].ToString();
                        if (obdramt >= obcramt)
                        {
                            obdramt = obdramt - obcramt;
                            obcramt = 0;
                        }
                        else if (obdramt < obcramt)
                        {
                            obcramt = obcramt - obdramt;
                            obdramt = 0;
                        }
                        obj_dt.Rows[int_RNO]["NewObDebit"] = obdramt;
                        obj_dt.Rows[int_RNO]["NewObCredit"] = obcramt;
                        obj_dt.Rows[int_RNO]["LedgerType"] = "L";
                        obj_dt.Rows[int_RNO]["Ledgerid"] = dt.Rows[i]["Ledgerid"].ToString();

                        dbl_G_Tot_OB_Dr = dbl_G_Tot_OB_Dr + obdramt;
                        dbl_S_Tot_OB_Dr = dbl_S_Tot_OB_Dr + obdramt;
                        totobdramt = totobdramt + obdramt;

                        dbl_G_Tot_OB_Cr = dbl_G_Tot_OB_Cr + obcramt;
                        dbl_S_Tot_OB_Cr = dbl_S_Tot_OB_Cr + obcramt;
                        totobcramt = totobcramt + obcramt;

                        dbl_GTotal_db = dbl_GTotal_db + dbamt;
                        dbl_GTotal_cr = dbl_GTotal_cr + cramt;
                        dbl_sub_GTotal_db = dbl_sub_GTotal_db + dbamt;
                        dbl_sub_GTotal_cr = dbl_sub_GTotal_cr + cramt;
                        totdramt = totdramt + dbamt;
                        totcramt = totcramt + cramt;
                        obj_dt.Rows[int_RNO]["NewTransDebit"] = dbamt;
                        obj_dt.Rows[int_RNO]["NewTransCredit"] = cramt;
                        dbamt = Convert.ToDouble(dt.Rows[i]["Debit"]);
                        dbamt = dbamt + Convert.ToDouble(dt.Rows[i]["OB_Debit"]);
                        cramt = Convert.ToDouble(dt.Rows[i]["Credit"]);
                        cramt = cramt + Convert.ToDouble(dt.Rows[i]["OB_Credit"]);
                        if (chk_Amount.Checked == true)
                        {
                            netdramt = dbamt;
                            netcramt = cramt;
                        }
                        else
                        {
                            if (dbamt >= cramt)
                            {
                                netdramt = dbamt - cramt;
                                netcramt = 0;
                            }
                            else if (dbamt < cramt)
                            {
                                netcramt = cramt - dbamt;
                                netdramt = 0;
                            }
                        }
                        obj_dt.Rows[int_RNO]["Debit"] = netdramt;
                        obj_dt.Rows[int_RNO]["Credit"] = netcramt;

                        dbl_G_Tot_Net_Dr = dbl_G_Tot_Net_Dr + netdramt;
                        dbl_S_Tot_Net_Dr = dbl_S_Tot_Net_Dr + netdramt;
                        totnetdramt = totnetdramt + netdramt;

                        dbl_G_Tot_Net_Cr = dbl_G_Tot_Net_Cr + netcramt;
                        dbl_S_Tot_Net_Cr = dbl_S_Tot_Net_Cr + netcramt;
                        totnetcramt = totnetcramt + netcramt;

                        if (!chk_Ledger.Checked)
                        {
                            // obj_dt.Rows[int_RNO].v = dbl_G_Tot_OB_Dr;
                        }
                        //    If Not chkLedgerView.Checked Then
                        //    DataGridView1.Rows(int_RNO).Visible = False
                        //End If

                        //If dbamt + cramt = 0 And obdramt + obdramt = 0 Then
                        //    DataGridView1.Rows(int_RNO).Visible = False
                        //End If

                        //if ((dbamt + cramt) == 0.00 && (obdramt + obdramt == 0.00))
                        //{
                        //    obj_dt.Rows[i].Delete();
                        //}
                                               
                        int_RNO = int_RNO + 1;
                    }

                    obj_dt.Rows[dbl_previous_GNO]["NewObDebit"] = dbl_G_Tot_OB_Dr;
                    obj_dt.Rows[dbl_previous_GNO]["NewObCredit"] = dbl_G_Tot_OB_Cr;
                    obj_dt.Rows[dbl_previous_GNO]["NewTransDebit"] = dbl_GTotal_db;
                    obj_dt.Rows[dbl_previous_GNO]["NewTransCredit"] = dbl_GTotal_cr;
                    obj_dt.Rows[dbl_previous_GNO]["Debit"] = dbl_G_Tot_Net_Dr;
                    obj_dt.Rows[dbl_previous_GNO]["Credit"] = dbl_G_Tot_Net_Cr;

                    obj_dt.Rows[dbl_previous_SNO]["NewObDebit"] = dbl_S_Tot_OB_Dr;
                    obj_dt.Rows[dbl_previous_SNO]["NewObCredit"] = dbl_S_Tot_OB_Cr;
                    obj_dt.Rows[dbl_previous_SNO]["NewTransDebit"] = dbl_sub_GTotal_db;
                    obj_dt.Rows[dbl_previous_SNO]["NewTransCredit"] = dbl_sub_GTotal_cr;
                    obj_dt.Rows[dbl_previous_SNO]["Debit"] = dbl_S_Tot_Net_Dr;
                    obj_dt.Rows[dbl_previous_SNO]["Credit"] = dbl_S_Tot_Net_Cr;

                    count = obj_dt.Rows.Count;
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add();
                    obj_dt.Rows[count]["LedgerName"] = "Total";
                    obj_dt.Rows[count]["NewObDebit"] = totobdramt;
                    obj_dt.Rows[count]["NewObCredit"] = totobcramt;
                    obj_dt.Rows[count]["NewTransDebit"] = totdramt;
                    obj_dt.Rows[count]["NewTransCredit"] = totcramt;
                    obj_dt.Rows[count]["Debit"] = totnetdramt;
                    obj_dt.Rows[count]["Credit"] = totnetcramt;
                    obj_dt.Rows[count]["LedgerType"] = "T";
                    count = obj_dt.Rows.Count;
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add();
                    double temp = 0;
                    obj_dt.Rows[count]["LedgerName"] = "Diff";
                    if (totobdramt > totobcramt)
                    {
                        temp = totobdramt - totobcramt;
                        obj_dt.Rows[count]["NewObDebit"] = temp.ToString("#,0.00");
                        obj_dt.Rows[count]["NewObCredit"] = "0.00";
                    }
                    else
                    {
                        obj_dt.Rows[count]["NewObDebit"] = "0.00";
                        obj_dt.Rows[count]["NewObCredit"] = (totobcramt - totobdramt).ToString("#,0.00");
                    }

                    if (totdramt > totcramt)
                    {
                        obj_dt.Rows[count]["NewTransDebit"] = (totdramt - totcramt).ToString("#,0.00");
                        obj_dt.Rows[count]["NewTransCredit"] = "0.00";
                    }
                    else
                    {
                        obj_dt.Rows[count]["NewTransDebit"] = "0.00";
                        obj_dt.Rows[count]["NewTransCredit"] = (totcramt - totdramt).ToString("#,0.00");
                    }
                    if (totnetdramt > totnetcramt)
                    {
                        obj_dt.Rows[count]["Debit"] = (totnetdramt - totnetcramt).ToString("#,0.00");
                        obj_dt.Rows[count]["Credit"] = "0.00";
                    }
                    else
                    {
                        obj_dt.Rows[count]["Debit"] = "0.00";
                        obj_dt.Rows[count]["Credit"] = (totnetcramt - totnetdramt).ToString("#,0.00");
                    }
                    obj_dt.Rows[count]["LedgerType"] = "T";
                   btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    //lnk_mis.Visible = false;
                    if (Math.Abs(totnetdramt - totnetcramt) > 0.01)
                    {
                        if(Math.Abs(totdramt - totcramt) > 0.01)
                        {
                            lnk_mis.Visible = true;
                        }else
                        {
                            lnk_mis.Visible = false;
                        }
                    }
                    Session["trial"] = obj_dt;
                    if (Session["str_ModuleName"].ToString() == "FA")
                    {
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1116, 3, Convert.ToInt32(Session["LoginBranchid"]), "TrialBalance" + txt_from.Text + "~" + txt_to.Text + "FA/Get");
                    }
                    else
                    {
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1205, 3, Convert.ToInt32(Session["LoginBranchid"]), "TrialBalance" + txt_from.Text + "~" + txt_to.Text + "FC/Get");
                    }
                    foreach (DataRow row in obj_dt.Select())
                    {
                        if (Convert.ToDouble(row["NewObDebit"]) < 0.009 && Convert.ToDouble(row["NewObCredit"]) < 0.009 && Convert.ToDouble(row["NewTransDebit"]) < 0.009 && Convert.ToDouble(row["NewTransCredit"]) < 0.009)
                        {
                            row.Delete();
                        }                        
                    }
                    obj_dt.AcceptChanges();
                    grd_trial.Visible = true;
                    grd_trial.DataSource = obj_dt;
                    grd_trial.DataBind();
                    ViewState["obj_dt"] = obj_dt;
                }
            }
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void grd_trial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    //e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0" )
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                //if(e.Row.Cells[1].Text=="Diff")
                //{

                //}
                for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (e.Row.Cells[h].Text=="")
                    {
                        e.Row.Cells[h].Text = "0.00";
                    }
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                LinkButton link_select = (LinkButton)e.Row.FindControl("link_select");
                LinkButton link_ledgerselect = (LinkButton)e.Row.FindControl("link_ledgerselect");

                if (grd_trial.DataKeys[e.Row.RowIndex].Values[1].ToString() == "L")
                {
                    if (chk_Ledger.Checked == true)
                    {
                        e.Row.Visible = true;
                        //e.Row.ForeColor = System.Drawing.Color.White;
                        //e.Row.BackColor = System.Drawing.Color.Black;
                        link_select.Visible = false;
                    }
                    else
                    {
                        e.Row.Visible = false;
                        //e.Row.ForeColor = System.Drawing.Color.White;
                        //e.Row.BackColor = System.Drawing.Color.Black;
                        link_select.Visible = false;
                    }
                }
                else if (grd_trial.DataKeys[e.Row.RowIndex].Values[1].ToString() == "G")
                {
                    e.Row.ForeColor = System.Drawing.Color.White;
                    e.Row.BackColor = System.Drawing.Color.LightYellow; 
                    link_select.Visible = false;
                    link_ledgerselect.Visible = false;
                    e.Row.Font.Italic = true;
                    e.Row.Font.Bold = true;                    
                }
                else if (grd_trial.DataKeys[e.Row.RowIndex].Values[1].ToString() == "S")
                {
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    //e.Row.BackColor = System.Drawing.Color.Blue;
                    link_ledgerselect.Visible = false;
                }
                else
                {
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    //e.Row.BackColor = System.Drawing.Color.Black;
                    link_select.Visible = false;
                    link_ledgerselect.Visible = false;

                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[2].Text == "")
                    {
                        e.Row.Cells[2].Text = "0.00";
                    }
                    if (e.Row.Cells[3].Text == "")
                    {
                        e.Row.Cells[3].Text = "0.00";
                    }
                    if (e.Row.Cells[4].Text == "")
                    {
                        e.Row.Cells[4].Text = "0.00";
                    }
                    if (e.Row.Cells[5].Text == "")
                    {
                        e.Row.Cells[5].Text = "0.00";
                    }

                    if ((Convert.ToDouble(e.Row.Cells[2].Text) + Convert.ToDouble(e.Row.Cells[3].Text) == 0.0) && (Convert.ToDouble(e.Row.Cells[4].Text) + Convert.ToDouble(e.Row.Cells[5].Text) == 0.00))
                    {
                        e.Row.Cells[i].Visible = false;
                    }
                }
            }
        }

        protected void grd_trial_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RowIndex = grd_trial.SelectedRow.RowIndex; 
            if (grd_trial.SelectedDataKey.Values[1].ToString() == "S")
            {
                int index = grd_trial.SelectedRow.RowIndex;
                index++;

                if (grd_trial.Rows[index].Visible == false)
                {
                    do
                    {
                        grd_trial.Rows[index].Visible = true;
                        index++;
                    }

                    while (grd_trial.DataKeys[index].Values[1].ToString() == "L");
                }
                else
                {
                    do
                    {
                        grd_trial.Rows[index].Visible = false;
                        index++;
                    }
                    while (grd_trial.DataKeys[index].Values[1].ToString() == "L");

                }

                LinkButton lnk = ((LinkButton)grd_trial.Rows[RowIndex].FindControl("link_select"));
                lnk.Focus(); 
            }
            else
            {
                bool Consolidate = false;
                if (chk_Consolidate.Checked == true)
                {
                    Consolidate = true;
                }

                iframecost.Attributes["src"] = "../FAForms/FALedgerView.aspx?LedgerID=" + grd_trial.SelectedDataKey.Values["Ledgerid"].ToString() + "&Customer=" + grd_trial.SelectedRow.Cells[1].Text.ToString().Trim() + "&FromDate=" + txt_from.Text + "&ToDate=" + txt_to.Text + "&Consolidate=" + Consolidate;
                ModalPopupExtender1.Show();
                LinkButton lnk = ((LinkButton)grd_trial.Rows[RowIndex].FindControl("link_ledgerselect"));
                lnk.Focus();


                //Response.Redirect("../FAForms/FALedgerView.aspx?LedgerID=" + grd_trial.SelectedDataKey.Values["Ledgerid"].ToString() + "&Customer=" + grd_trial.SelectedRow.Cells[1].Text.ToString().Trim() + "&FromDate=" + txt_from.Text + "&ToDate=" + txt_to.Text + "&Consolidate=" + Consolidate);
                //ModalPopupExtender1.Show();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime date = FARepobj.MaxVouGetDate(Session["FADbname"].ToString());
                Str_CurrrentDate = logobj.GetDate().ToShortDateString();
                //txt_from.Text = "01/04/" + Session["LogYear"].ToString();
                //txt_to.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());
                Str_CurrrentDate = logobj.GetDate().ToShortDateString();
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                //string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <=3) || Vouyear == (DateTime.Now).Year)
                {
                    txt_from.Text = "01/01/" + vouyeartext;
                    txt_to.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());

                }
                else
                {
                    txt_from.Text = "01/01/" + vouyeartext;
                    txt_to.Text = "31/12/" + (vouyeartext + 1);
                }
                div_Grdheader.Visible = false;
                grd_trial.DataSource = null;
                grd_trial.DataBind();
                chk_Amount.Checked = false;
                chk_Consolidate.Checked = false;
                chk_Ledger.Checked = false;
                ViewState["obj_dt"] = null;
                lnk_mis.Visible = false;
                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
              //  this.Response.End();

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

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            if (grd_trial.Rows.Count > 0)
            {

                //Response.Clear();
                //Response.AddHeader("content-disposition", "Attachment;filename=GST_XL_Chargewise.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.xls";
                //StringBuilder SB = new StringBuilder();
                //StringWriter StringWriter = new System.IO.StringWriter(SB);
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                //if (grd_trial.Visible == true)
                //{
                //    grd_trial.Columns[0].Visible = false;
                    
                //    grd_trial.GridLines = GridLines.Both;
                //    grd_trial.HeaderStyle.Font.Bold = true;
                //    grd_trial.RenderControl(HtmlTextWriter);
                //}
                //Response.Write(StringWriter.ToString());
                //Response.Flush();
                //Response.End();

                int did = Convert.ToInt32(Session["LoginDivisionid"].ToString());
                DataTable dt_check = new DataTable("Excel");
                if (ViewState["obj_dt"] != null)
                {
                    dt_check = ViewState["obj_dt"] as DataTable;
                }
                if (dt_check.Rows.Count > 0 && chk_Ledger.Checked == false)
                {
                    DataTable dt_filter = new DataTable();
                    DataView data1 = dt_check.DefaultView;
                    data1.RowFilter = "ledgertype <> 'L' ";
                    dt_filter = data1.ToTable();
                    GridView1.DataSource = dt_filter;
                    GridView1.DataBind();


                }
                else if (chk_Ledger.Checked == true)
                {
                    GridView1.DataSource = dt_check;
                    GridView1.DataBind();
                }

                //RAJ
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    int cnt = 7;
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";

                    StringBuilder SB = new StringBuilder();
                    StringWriter StringWriter = new System.IO.StringWriter(SB);
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                    string Head = "Trail Balance - From " + txt_from.Text + " To " + txt_to.Text;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Head + "</B></font></td></tr><br />");
                    SB.Append("<tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</B></font></td></tr><br />");
                    SB.Append("</table><br />");

                    if (GridView1.Visible == true)
                    {
                        GridView1.GridLines = GridLines.Both;
                        GridView1.HeaderStyle.Font.Bold = true;
                        GridView1.RenderControl(HtmlTextWriter);
                    }
                    GridView1.Visible = false;
                    Response.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }

            }
            else if (GridView2.Rows.Count>0)
            {

                GridView2.Visible = true;
                int cnt = 7;
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";

                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                string Head = "Trail Balance - From " + txt_from.Text + " To " + txt_to.Text;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Head + "</B></font></td></tr><br />");
                SB.Append("<tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + " - " + Session["LoginBranchName"].ToString() + "</B></font></td></tr><br />");
                SB.Append("</table><br />");

                if (GridView2.Visible == true)
                {
                    GridView2.GridLines = GridLines.Both;
                    GridView2.HeaderStyle.Font.Bold = true;
                    GridView2.RenderControl(HtmlTextWriter);
                }
                //GridView2.Visible = false;
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void btn_branchwise_Click(object sender, EventArgs e)
        {
            string amount = "", Ledger = "";
            string trailbalance = "trailbalance";

            if (chk_Amount.Checked == true)
            {
                amount = "chk_Amount";
            }
            if (chk_Ledger.Checked == true)
            {
                Ledger = "chk_Ledger";
            }

            iframecost.Attributes["src"] = "../FAForms/Trailbalance4allbranch.aspx?FromDate=" + txt_from.Text + "&ToDate=" + txt_to.Text + "&amount=" + amount + "&Ledger=" + Ledger + "&trailbalance=" + trailbalance;
            ModalPopupExtender1.Show();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1116, 3, Convert.ToInt32(Session["LoginBranchid"]), "TrialBalance" + txt_from.Text + "~" + txt_to.Text + "FA/Branchwise");
            }
            else
            {
                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1205, 3, Convert.ToInt32(Session["LoginBranchid"]), "TrialBalance" + txt_from.Text + "~" + txt_to.Text + "FC/Branchwise");
            }

            //iframecost.Attributes["src"] = "../FAForms/Trailbalance4allbranch.aspx";
            //ModalPopupExtender1.Show();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString() == "S")
                {
                    e.Row.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.LightYellow;
                    e.Row.Font.Italic = true;
                    e.Row.Font.Bold = true;
                }
                if (GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString() == "G")
                {
                    e.Row.ForeColor = System.Drawing.Color.Black;
                    e.Row.BackColor = System.Drawing.Color.Aqua;
                    e.Row.Font.Italic = true;
                    e.Row.Font.Bold = true;
                }

                for (int h = 1; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (e.Row.Cells[h].Text == "")
                    {
                        e.Row.Cells[h].Text = "0.00";
                    }
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

            }
        }

        protected void lnkMisMatch_Click(object sender, EventArgs e)
        {
            iframecost.Attributes["src"] = "../FAForms/ChkDrCrMismatch.aspx?mismatchchk=mismatchchk";
            ModalPopupExtender1.Show();
        }

        //protected void grd_trial_DataBound(object sender, EventArgs e)
        //{
        //    GridViewRow Grid_Row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);           
        //    TableHeaderCell cell = new TableHeaderCell();

        //    cell = new TableHeaderCell();
        //    cell.Text = "";
        //    cell.ColumnSpan = 1;
        //    Grid_Row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.Text = "Ledger Name";
        //    cell.ColumnSpan = 1;
        //    Grid_Row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.Text = "Opening Balance";
        //    cell.ColumnSpan = 2;
        //    Grid_Row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.ColumnSpan = 2;
        //    cell.Text = "Transaction Balance";
        //    Grid_Row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.ColumnSpan = 2;
        //    cell.Text = "Closing Balance";
        //    Grid_Row.Controls.Add(cell);
                      
        //    grd_trial.HeaderRow.Parent.Controls.AddAt(0, Grid_Row);
        //}

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

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1116, "PA", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1205, "PA", "", "", Session["StrTranType"].ToString());
            }

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grd_trial_PreRender(object sender, EventArgs e)
        {
            if (grd_trial.Rows.Count > 0)
            {
                grd_trial.UseAccessibleHeader = true;
                grd_trial.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void btn_lgdall_Click(object sender, EventArgs e)
        {
            string from = Utility.fn_ConvertDate(txt_from.Text);
            string to = Utility.fn_ConvertDate(txt_to.Text);

            DateTime FromDate = Convert.ToDateTime(from);
            DateTime ToDate = Convert.ToDateTime(to);
            head.Visible=false;
            ds1 = FARepobj.sptbpiv_allset2(int.Parse(Session["LoginBranchid"].ToString()), FromDate, ToDate,2024);
            ds1.Tables[0].Columns.Remove("id");
            grd_trial.Visible=false;
            GridView2.Visible=true;    
            GridView2.DataSource = ds1;
            GridView2.DataBind();
            ViewState["obj_dt"] = ds1;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                    //e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                //for (int i = 0; i < e.Row.Cells.Count; i++)
                //{
                //    if (e.Row.Cells[i].Text == "0" || e.Row.Cells[i].Text == "0.00")
                //    {
                //        e.Row.Cells[i].Text = "";
                //    }
                //    //e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                //}
                for (int h = 1; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    //if (e.Row.Cells[h].Text == "")
                    //{
                    //    e.Row.Cells[h].Text = "0.00";
                    //}
                    double cellValue;
                    if (double.TryParse(e.Row.Cells[h].Text, out cellValue))
                    {
                        // Apply Math.Abs() only if the cell's text is numeric
                        e.Row.Cells[h].Text = Math.Abs(cellValue).ToString();
                    }
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                         //e.Row.Cells[h].Text = Math.Abs(e.Row.Cells[h].Text);
                    }
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        //if (e.Row.Cells[i].Text == "0" || e.Row.Cells[i].Text == "0.00")
                        //{
                        //    e.Row.Cells[i].Text = "";
                        //}
                        //e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }
                    //Math.Abs(
                }
            }
        }
    }
}