using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace logix.FAForm
{

    public partial class BalanceSheet : System.Web.UI.Page
    {
        string StrTrantype;
        double debit;
        double credit;
        double dbdebit = 0;
        double dbcredit = 0;
        double totaldbamnt = 0;
        double totalcramnt = 0;
        double bsamount = 0;
        double diffamount = 0;
        double totIdbamnt = 0;
        double totIcramnt = 0;
        double Amtcrtotal = 0;
        double Amtdbtotal = 0;
        double NL = 0,a2=0,a1=0;
        double NP = 0;
        double totalabs = 0;
        double totallbs = 0;
        double IIncAmount = 0;
        double IExpAmount = 0;
        double GP = 0;
        double GL = 0;
        double grossloss = 0;
        double grossprofit = 0;
        double ExpAmount = 0;
        double IncAmount = 0;
        string grouptype;
        DateTime fromdate;
        DateTime todate;
        double dbltotAsset;
        double dbltotliability;
        string strNetProfitorLoss;
        double dblNetProfitorLossAmt;
        string PrevGroupname;
        string PrevSubGroupname;
        int PrevGroupno;
        int prevsubgroupno;
        double PrevSubGroupTot;
        //int rowcount;
        double totAmt, rptexpamnt, rptincamnt;
        string rptpartexp, rptpartinc;
        double dbamt;
        double totA;
        double totL;
        int ledgerid;
        double totopbalcr;
        double totopbaldb;
        DataSet Ds = new DataSet();
        DataAccess.FAMaster.ReportView FAObj = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.FAMaster.ReportView FARepobj = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable dtDIE = new DataTable();
        DataTable dtIIE = new DataTable();
        DataTable dt = new DataTable();
        string groupname; int groupid;
        DateTime date;
        string Str_CurrrentDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                FAObj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                FARepobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);




            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd_blncsheet);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_exlxport);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (IsPostBack != true)
            {
                try
                {

                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                    date = FAObj.MaxVouGetDate(Session["FADbname"].ToString());
                    int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                    int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                  //  string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                    //if (stryear == vouyeartext)
                    //{
                    //    txt_from.Text = "01/04/" + vouyeartext;
                    //    txt_to.Text = Str_CurrrentDate.ToString();

                    //}
                    //else
                    //{
                    //    txt_from.Text = "01/04/" + vouyeartext;
                    //    txt_to.Text = "31/03/" + (vouyeartext + 1);
                    //}



                    int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                    string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());

                    if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                    {
                        if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                        {
                            txt_from.Text = "01/04/" + vouyeartext;
                            txt_to.Text = Str_CurrrentDate.ToString();

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
                            //dtfrom.Text = Str_CurrrentDate;
                            //dtto.Text = Str_CurrrentDate;
                            txt_from.Text = "01/01/" + Vouyear;
                            txt_to.Text = Str_CurrrentDate;
                        }
                        else
                        {
                            txt_from.Text = "01/01/" + Vouyear;
                            txt_to.Text = "31/12/" + (Vouyear + 1);
                        }
                    }
                    //Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                    //txt_to.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());
                    //txt_from.Text = "01/04/" + Session["LogYear"].ToString();

                    string str_CtrlLists = "txt_from~txt_to";
                    btn_gwise.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");
                    btn_lwise.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");

                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        chk_consol.Visible = true;
                        branchwise_id.Visible = true;
                        btn_branchwise.Visible = true;
                    }
                    else
                    {
                        chk_consol.Visible = false;
                        branchwise_id.Visible = false;
                        btn_branchwise.Visible = false;
                    }

                    grd_blncsheet.Visible = true;
                    grd_blncsheet.DataSource = new DataTable();
                    grd_blncsheet.DataBind();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
                }
            }
        }

        protected void btngwise_Click(object sender, EventArgs e)
        {
            try
            {
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
                todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));
                if (fromdate > todate)
                {
                    ScriptManager.RegisterStartupScript(btn_gwise, typeof(Button), "alert", "alertify.alert('From Date Should be Less than To Date');", true);
                    txt_from.Focus();
                    return;
                }

                grd_all.Visible = false;

                grd_blncsheet.DataSource = null;
                grd_blncsheet.DataBind();
                Getdata();

                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1118, 3, int.Parse(Session["LoginBranchid"].ToString()), "BalanceSheet-Group" + txt_from.Text + "~" + txt_to.Text + "/FA/GroupWise/V");
                }
                else
                {
                    logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1207, 3, int.Parse(Session["LoginBranchid"].ToString()), "BalanceSheet-Group" + txt_from.Text + "~" + txt_to.Text + "/FC/GroupWise/V");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void CalcProfitandLoss()
        {
            Amtdbtotal = 0; Amtcrtotal = 0; totIdbamnt = 0; totIcramnt = 0; totaldbamnt = 0; totalcramnt = 0;

            if (chk_consol.Checked == true)
            {
                Ds = FAObj.SelProfitLosswithdate4AllBranch(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginDivisionId"]));
            }
            else
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Ds = FAObj.SelProfitLosswithdate(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), fromdate, todate);
                }
                else
                {
                    Ds = FAObj.SelProfitLosswithdate(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), fromdate, todate);
                }
            }

            dtDIE = Ds.Tables[0];
            dtIIE = Ds.Tables[1];
            int IRNo = 0, ERNo = 0;
            totaldbamnt = 0; totalcramnt = 0; GP = 0; GL = 0;
            if (dtDIE.Rows.Count > 0)
            {
                for (int i = 0; i < dtDIE.Rows.Count; i++)
                {
                    grouptype = dtDIE.Rows[i]["grouptype"].ToString();
                    dbdebit = Convert.ToDouble(dtDIE.Rows[i]["Debit"].ToString()) + Convert.ToDouble(dtDIE.Rows[i]["OB_Debit"].ToString());
                    dbcredit = Convert.ToDouble(dtDIE.Rows[i]["Credit"].ToString()) + Convert.ToDouble(dtDIE.Rows[i]["OB_Credit"].ToString());
                    if (grouptype == "E")
                    {
                        if (dbdebit >= dbcredit)
                        {
                            diffamount = dbdebit - dbcredit;
                        }
                        else if (dbcredit > dbdebit)
                        {
                            diffamount = dbcredit - dbdebit;
                            diffamount = -diffamount;
                        }
                        ERNo = ERNo + 1;
                        totaldbamnt = totaldbamnt + diffamount;
                    }
                    else
                    {
                        if (dbdebit > dbcredit)
                        {
                            diffamount = dbdebit - dbcredit;
                            diffamount = -diffamount;
                        }
                        else if (dbcredit >= dbdebit)
                        {
                            diffamount = dbcredit - dbdebit;
                        }
                        IRNo = IRNo + 1;
                        totalcramnt = totalcramnt + diffamount;
                    }
                }

                if (totaldbamnt > totalcramnt)
                {
                    GL = totaldbamnt - totalcramnt;
                    grossloss = GL;
                    grossprofit = 0;
                }
                else if (totalcramnt > totaldbamnt)
                {
                    GP = totalcramnt - totaldbamnt;
                    grossloss = 0;
                    grossprofit = GP;
                }

                if (totaldbamnt > totalcramnt)
                {
                    GL = totaldbamnt - totalcramnt;
                    grossloss = GL;
                    grossprofit = 0;
                }
                else if (totalcramnt > totaldbamnt)
                {
                    GP = totalcramnt - totaldbamnt;
                    grossloss = 0;
                    grossprofit = GP;
                }
            }

            totaldbamnt = 0; totalcramnt = 0;
            if (dtIIE.Rows.Count > 0)
            {
                for (int i = 0; i < dtIIE.Rows.Count; i++)
                {
                    grouptype = dtIIE.Rows[i]["grouptype"].ToString();
                    dbdebit = Convert.ToDouble(dtIIE.Rows[i]["Debit"].ToString()) + Convert.ToDouble(dtIIE.Rows[i]["OB_Debit"].ToString());
                    dbcredit = Convert.ToDouble(dtIIE.Rows[i]["Credit"].ToString()) + Convert.ToDouble(dtIIE.Rows[i]["OB_Credit"].ToString());
                    if (grouptype == "E")
                    {
                        if (dbdebit >= dbcredit)
                        {
                            diffamount = dbdebit - dbcredit;
                        }
                        else if (dbcredit > dbdebit)
                        {
                            diffamount = dbcredit - dbdebit;
                            diffamount = -diffamount;
                        }
                        ERNo = ERNo + 1;
                        totaldbamnt = totaldbamnt + diffamount;
                    }
                    else
                    {
                        if (dbdebit > dbcredit)
                        {
                            diffamount = dbdebit - dbcredit;
                            diffamount = -diffamount;
                        }
                        else if (dbcredit >= dbdebit)
                        {
                            diffamount = dbcredit - dbdebit;
                        }
                        IRNo = IRNo + 1;
                        totalcramnt = totalcramnt + diffamount;
                    }
                }

                totalcramnt = grossprofit + totalcramnt;
                totaldbamnt = grossloss + totaldbamnt;
                Amtdbtotal = totaldbamnt;
                Amtcrtotal = totalcramnt;
            }
        }

        public void Getdata()
        {
            int count = 0;
            DataSet Dsbs = new DataSet();
            DataTable DStbl1 = new DataTable();
            DataTable DStbl2 = new DataTable();
            fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
            todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));

            if (chk_consol.Checked)
            {
                Dsbs = FAObj.SelBalanceSheet4AllBranch(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]), fromdate, todate);
            }
            else
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    //Dsbs = FAObj.SelBalanceSheetforcorporate(Login.FADbname, Login.divisionid, dtfrom.Value, dtto.Value)
                    Dsbs = FAObj.SelBalanceSheet(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), fromdate, todate);
                }
                else
                {
                    Dsbs = FAObj.SelBalanceSheet(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), fromdate, todate);
                }
            }

            DStbl1 = Dsbs.Tables[0];
            DStbl2 = Dsbs.Tables[1];
            DataTable dt_temptbl1 = new DataTable();
            DataRow dr;
            if (DStbl2.Rows.Count > 0 || DStbl1.Rows.Count > 0)
            {
                DataColumn dc_col1 = new DataColumn("Asset", typeof(string));
                DataColumn dc_col2 = new DataColumn("AssetAmt", typeof(double));
                DataColumn dc_col3 = new DataColumn("Liabilities", typeof(string));
                DataColumn dc_col4 = new DataColumn("LiabilitiesAmt", typeof(double));

                dt_temptbl1.Columns.Add(dc_col1);
                dt_temptbl1.Columns.Add(dc_col2);
                dt_temptbl1.Columns.Add(dc_col3);
                dt_temptbl1.Columns.Add(dc_col4);
            }

            if (DStbl2.Rows.Count > 0)
            {
                for (int j = 0; j <= DStbl2.Rows.Count - 1; j++)
                {
                    dr = dt_temptbl1.NewRow();
                    debit = Convert.ToDouble(DStbl2.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Debit"].ToString());
                    credit = Convert.ToDouble(DStbl2.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Credit"].ToString());
                    grouptype = DStbl2.Rows[j]["grouptype"].ToString();

                    if (grouptype == "L")
                    {
                        if (debit != 0 && credit != 0)
                        {
                            if (debit > credit)
                            {
                                bsamount = debit - credit;
                                dr["Liabilities"] = DStbl2.Rows[j]["groupname"].ToString();
                                dr["LiabilitiesAmt"] = -bsamount;
                            }
                            else
                            {
                                bsamount = credit - debit;
                                dr["Liabilities"] = DStbl2.Rows[j]["groupname"].ToString();
                                dr["LiabilitiesAmt"] = bsamount;
                            }
                        }
                        else if (debit != 0 && credit == 0)
                        {
                            dr["Liabilities"] = DStbl2.Rows[j]["groupname"].ToString();
                            dr["LiabilitiesAmt"] = -debit;
                        }
                        else if (debit == 0 && credit != 0)
                        {
                            dr["Liabilities"] = DStbl2.Rows[j]["groupname"].ToString();
                            dr["LiabilitiesAmt"] = credit;
                        }
                    }

                    dt_temptbl1.Rows.Add(dr);
                    count += 1;
                }
            }

            if (DStbl1.Rows.Count > 0)
            {
                for (int i = 0; i <= DStbl1.Rows.Count - 1; i++)
                {
                    if (DStbl1.Rows.Count > count)
                    {
                        dr = dt_temptbl1.NewRow();
                        dt_temptbl1.Rows.Add();
                    }

                    debit = Convert.ToDouble(DStbl1.Rows[i]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Debit"].ToString());
                    credit = Convert.ToDouble(DStbl1.Rows[i]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Credit"].ToString());

                    grouptype = DStbl1.Rows[i]["grouptype"].ToString();
                    if (grouptype == "A")
                    {
                        if (debit > credit)
                        {
                            bsamount = debit - credit;
                            dt_temptbl1.Rows[i]["Asset"] = DStbl1.Rows[i]["groupname"].ToString();
                            dt_temptbl1.Rows[i]["AssetAmt"] = bsamount;
                        }
                        else if (credit > debit)
                        {
                            bsamount = credit - debit;
                            dt_temptbl1.Rows[i]["Asset"] = DStbl1.Rows[i]["groupname"].ToString();
                            dt_temptbl1.Rows[i]["AssetAmt"] = -bsamount;
                        }
                        else if (debit != 0 && credit == 0)
                        {
                            dt_temptbl1.Rows[i]["Asset"] = DStbl1.Rows[i]["groupname"].ToString();
                            dt_temptbl1.Rows[i]["AssetAmt"] = debit;
                        }
                        else if (debit == 0 && credit != 0)
                        {
                            dt_temptbl1.Rows[i]["Asset"] = DStbl1.Rows[i]["groupname"].ToString();
                            dt_temptbl1.Rows[i]["AssetAmt"] = credit;
                        }
                    }
                }
            }

            CalcProfitandLoss();
            dr = dt_temptbl1.NewRow();
            if (Amtdbtotal > Amtcrtotal)
            {
                NL = Amtdbtotal - Amtcrtotal;
                dr["Asset"] = "Net Loss";
                dr["AssetAmt"] = NL;
            }
            else if (Amtcrtotal > Amtdbtotal)
            {
                NP = Amtcrtotal - Amtdbtotal;
                dr["Liabilities"] = "Net Profit";
                dr["LiabilitiesAmt"] = NP;
            }

            dt_temptbl1.Rows.Add(dr);
            dr = dt_temptbl1.NewRow();

            dr["Asset"] = "Total";
            dr["AssetAmt"] = dt_temptbl1.Compute("sum(AssetAmt)", "");
            dr["Liabilities"] = "Total";
            dr["LiabilitiesAmt"] = dt_temptbl1.Compute("sum(LiabilitiesAmt)", "");
            dt_temptbl1.Rows.Add(dr);

            grd_blncsheet.Visible = true;
            grd_blncsheet.DataSource = dt_temptbl1;
            grd_blncsheet.DataBind();
            int grdcount = grd_blncsheet.Rows.Count;
            grd_blncsheet.Rows[grdcount - 2].ForeColor = System.Drawing.Color.DarkGreen;
            grd_blncsheet.Rows[grdcount - 1].ForeColor = System.Drawing.Color.DarkGreen;
        }


        public void Getdata1()
        {
            int count = 0;
            double  t2;
            DataSet Dsbs = new DataSet();
            DataTable DStbl1 = new DataTable();
            DataTable DStbl2 = new DataTable();
            fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
            todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));

            if (chk_consol.Checked)
            {
                Dsbs = FAObj.SelBalanceSheet4AllBranch(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]), fromdate, todate);
            }
            else
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    //Dsbs = FAObj.SelBalanceSheetforcorporate(Login.FADbname, Login.divisionid, dtfrom.Value, dtto.Value)
                    Dsbs = FAObj.SelBalanceSheet(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), fromdate, todate);
                }
                else
                {
                    Dsbs = FAObj.SelBalanceSheet(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), fromdate, todate);
                }
            }

            DStbl1 = Dsbs.Tables[0];
            DStbl2 = Dsbs.Tables[1];
            DataTable dt_temptbl1 = new DataTable();
            DataRow dr;
            if (DStbl2.Rows.Count > 0 || DStbl1.Rows.Count > 0)
            {
                //DataColumn dc_col1 = new DataColumn("Asset", typeof(string));
                //DataColumn dc_col2 = new DataColumn("AssetAmt", typeof(double));
                DataColumn dc_col1 = new DataColumn("Liabilities", typeof(string));
                DataColumn dc_col2 = new DataColumn("Debit", typeof(string));
                DataColumn dc_col3 = new DataColumn("Credit", typeof(string));
                DataColumn dc_col4 = new DataColumn("Net", typeof(string));
                DataColumn dc_col5 = new DataColumn("LiabilitiesAmt", typeof(double));

                dt_temptbl1.Columns.Add(dc_col1);
                dt_temptbl1.Columns.Add(dc_col2);
                dt_temptbl1.Columns.Add(dc_col3);
                dt_temptbl1.Columns.Add(dc_col4);
                dt_temptbl1.Columns.Add(dc_col5);
            }


            if (DStbl1.Rows.Count > 0)
            {
                a1 = 0;
                t2 = 0;
                for (int j = 0; j <= DStbl1.Rows.Count - 1; j++)
                {
                    debit = Convert.ToDouble(DStbl1.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[j]["OB_Debit"].ToString());
                    credit = Convert.ToDouble(DStbl1.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[j]["OB_Credit"].ToString());
                    t2 = (debit - credit);
                    a1 += t2;
                }
                dr = dt_temptbl1.NewRow();
                dt_temptbl1.Rows.Add(dr);
                dr[0] = "Assects";
                dr[1] = 0;
                dr[2] = 0;
                dr[3] = 0;
                dr[4] = Convert.ToDouble(a1);
                dr = dt_temptbl1.NewRow();

                for (int i = 0; i <= DStbl1.Rows.Count - 1; i++)
                {
                    
                    dr = dt_temptbl1.NewRow();
                    debit = Convert.ToDouble(DStbl1.Rows[i]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Debit"].ToString());
                    credit = Convert.ToDouble(DStbl1.Rows[i]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Credit"].ToString());
                    t2 = (debit - credit);
                    a2 += t2;
                    grouptype = DStbl1.Rows[i]["grouptype"].ToString();
                    if (grouptype == "A")
                    {
                        if (debit > credit)
                        {
                            bsamount = debit - credit;
                            dr["Liabilities"] = DStbl1.Rows[i]["groupname"].ToString();
                            dr[1] = Convert.ToDouble(DStbl1.Rows[i]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Debit"].ToString());
                            dr[2] = Convert.ToDouble(DStbl1.Rows[i]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Credit"].ToString());
                            dr[3] = bsamount;
                            dr["LiabilitiesAmt"] = 0;
                        }
                        else if (credit > debit)
                        {
                            bsamount = credit - debit;
                            dr["Liabilities"] = DStbl1.Rows[i]["groupname"].ToString();
                            dr[1] = Convert.ToDouble(DStbl1.Rows[i]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Debit"].ToString());
                            dr[2] = Convert.ToDouble(DStbl1.Rows[i]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Credit"].ToString());
                            dr[3] = -bsamount;
                            dr["LiabilitiesAmt"] = 0;
                        }
                        else if (debit != 0 && credit == 0)
                        {
                            dr["Liabilities"] = DStbl1.Rows[i]["groupname"].ToString();
                            dr[1] = Convert.ToDouble(DStbl1.Rows[i]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Debit"].ToString());
                            dr[2] = Convert.ToDouble(DStbl1.Rows[i]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Credit"].ToString());
                            dr[3] = debit;
                            dr["LiabilitiesAmt"] = 0;
                        }
                        else if (debit == 0 && credit != 0)
                        {
                            dr["Liabilities"] = DStbl1.Rows[i]["groupname"].ToString();
                            dr[1] = Convert.ToDouble(DStbl1.Rows[i]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Debit"].ToString());
                            dr[2] = Convert.ToDouble(DStbl1.Rows[i]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[i]["OB_Credit"].ToString());
                            dr[3] = credit;
                            dr["LiabilitiesAmt"] = 0;
                        }
                    }
                    dt_temptbl1.Rows.Add(dr);
                }
            }

            if (DStbl2.Rows.Count > 0)
            {
                //a2 = 0;
                //t2 = 0;
                //for (int j = 0; j <= DStbl2.Rows.Count - 1; j++)
                //{
                //    debit = Convert.ToDouble(DStbl1.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[j]["OB_Debit"].ToString());
                //    credit = Convert.ToDouble(DStbl1.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[j]["OB_Credit"].ToString());
                //    t2 = (debit - credit);
                //    a2 += t2;
                //}
                a2 = 0;
                t2 = 0;
                for (int j = 0; j <= DStbl2.Rows.Count - 1; j++)
                {
                    debit = Convert.ToDouble(DStbl2.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Debit"].ToString());
                    credit = Convert.ToDouble(DStbl2.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Credit"].ToString());
                    t2 = (debit - credit);
                    a2 += t2;

                }
                t2 = a1 - Math.Abs(a2);
                a2 = Math.Abs(a2) + t2;
                dr = dt_temptbl1.NewRow();
                dt_temptbl1.Rows.Add(dr);
                dr[0] = "Liabilities";
                dr[1] = 0;
                dr[2] = 0;
                dr[3] = 0;
                dr[4] = Convert.ToDouble(a2);
                dr = dt_temptbl1.NewRow();

                for (int j = 0; j <= DStbl2.Rows.Count - 1; j++)
                {
                    dr = dt_temptbl1.NewRow();
                    debit = Convert.ToDouble(DStbl2.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Debit"].ToString());
                    credit = Convert.ToDouble(DStbl2.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Credit"].ToString());
                    grouptype = DStbl2.Rows[j]["grouptype"].ToString();

                    if (grouptype == "L")
                    {
                        if (debit != 0 && credit != 0)
                        {
                            if (debit > credit)
                            {
                                bsamount = debit - credit;
                                dr["Liabilities"] = DStbl2.Rows[j]["groupname"].ToString();
                                dr[1] = Convert.ToDouble(DStbl2.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Debit"].ToString());
                                dr[2] = Convert.ToDouble(DStbl2.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Credit"].ToString());
                                dr[3] = -bsamount;
                                dr["LiabilitiesAmt"] = 0;
                            }
                            else
                            {
                                bsamount = credit - debit;
                                dr["Liabilities"] = DStbl2.Rows[j]["groupname"].ToString();
                                dr[1] = Convert.ToDouble(DStbl2.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Debit"].ToString());
                                dr[2] = Convert.ToDouble(DStbl2.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Credit"].ToString());
                                dr[3] = bsamount;
                                dr["LiabilitiesAmt"] = 0;
                            }
                        }
                        else if (debit != 0 && credit == 0)
                        {
                            dr["Liabilities"] = DStbl2.Rows[j]["groupname"].ToString();
                            dr[1] = Convert.ToDouble(DStbl2.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Debit"].ToString());
                            dr[2] = Convert.ToDouble(DStbl2.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Credit"].ToString());
                            dr[3] = -debit;
                            dr["LiabilitiesAmt"] = 0;
                        }
                        else if (debit == 0 && credit != 0)
                        {
                            dr["Liabilities"] = DStbl2.Rows[j]["groupname"].ToString();
                            dr[1] = Convert.ToDouble(DStbl2.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Debit"].ToString());
                            dr[2] = Convert.ToDouble(DStbl2.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl2.Rows[j]["OB_Credit"].ToString());
                            dr[3] = credit;
                            dr["LiabilitiesAmt"] = 0;
                        }
                    }

                    dt_temptbl1.Rows.Add(dr);
                    count += 1;
                }
                //dr = dt_temptbl1.NewRow();
                //dt_temptbl1.Rows.Add(dr);
                //dr["Liabilities"] = "Total";
                a1 = Convert.ToDouble(dt_temptbl1.Compute("sum(LiabilitiesAmt)", ""));
                //count += 1;
                ////dt_temptbl1.Rows.Add(dr);
            }




            

            CalcProfitandLoss();
            dr = dt_temptbl1.NewRow();
            if (Amtdbtotal > Amtcrtotal)
            {
                NL = Amtdbtotal - Amtcrtotal;
                dr["Liabilities"] = "Net Loss";
                dr[1] = 0;
                dr[2] = 0;
                dr[3] = NL;
                dr["LiabilitiesAmt"] = 0;
            }
            else if (Amtcrtotal > Amtdbtotal)
            {
                NP = Amtcrtotal - Amtdbtotal;
                dr["Liabilities"] = "Net Profit";
                dr[1] = 0;
                dr[2] = 0;
                dr[3] = NP;
                dr["LiabilitiesAmt"] = 0;
            }
            dt_temptbl1.Rows.Add(dr);
            dr = dt_temptbl1.NewRow();

            //if (DStbl1.Rows.Count > 0)
            //{
            //    a1 = 0;
            //    t2 = 0;
            //    for (int j = 0; j <= DStbl2.Rows.Count - 1; j++)
            //    {
            //        debit = Convert.ToDouble(DStbl1.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[j]["OB_Debit"].ToString());
            //        credit = Convert.ToDouble(DStbl1.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[j]["OB_Credit"].ToString());
            //        t2 = (debit - credit);
            //        a1 += t2;
            //    }
            //    dr["Liabilities"] = "Total";
            //    dr[1] = 0;
            //    dr[2] = 0;
            //    dr[3] = "";
            //    dr["LiabilitiesAmt"] = Convert.ToDouble(a1);
            //    dt_temptbl1.Rows.Add(dr);
            //    dr = dt_temptbl1.NewRow();
            //}
            //if (DStbl2.Rows.Count > 0)
            //{
            //    a2 = 0;
            //    t2 = 0;
            //    for (int j = 0; j <= DStbl2.Rows.Count - 1; j++)
            //    {
            //        debit = Convert.ToDouble(DStbl1.Rows[j]["Debit"].ToString()) + Convert.ToDouble(DStbl1.Rows[j]["OB_Debit"].ToString());
            //        credit = Convert.ToDouble(DStbl1.Rows[j]["Credit"].ToString()) + Convert.ToDouble(DStbl1.Rows[j]["OB_Credit"].ToString());
            //        t2 = (debit - credit);
            //        a2 += t2;
            //    }
            //    dr["Liabilities"] = "Total";
            //    dr[1] = 0;
            //    dr[2] = 0;
            //    dr[3] = "";
            //    dr["LiabilitiesAmt"] = Convert.ToDouble(a2);
            //    dt_temptbl1.Rows.Add(dr);
            //    dr = dt_temptbl1.NewRow();
            //}
            grd_blncsheet.Visible = false;
            grd_all.Visible = true;
            grd_all.DataSource = dt_temptbl1;
            grd_all.DataBind();
            int grdcount = grd_all.Rows.Count;
            grd_all.Rows[grdcount - 2].ForeColor = System.Drawing.Color.DarkGreen;
            grd_all.Rows[grdcount - 1].ForeColor = System.Drawing.Color.DarkGreen;
        }

        protected void btnlwise_Click(object sender, EventArgs e)
        {
            Ledger_wise();
        }

        public void Ledger_wise()
        {
            int rowcount = 0;
            double dbamt;
            DataSet Ds = new DataSet();
            //DataAccess.FAMaster.ReportView FAObj = new DataAccess.FAMaster.ReportView();


            fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
            todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));
            if (fromdate > todate)
            {
                ScriptManager.RegisterStartupScript(btn_lwise, typeof(Button), "alert", "alertify.alert('From Date Should be Less than To Date');", true);
                txt_from.Focus();
                return;
            }

            if (grd_blncsheet.Rows.Count > 0)
            {
                grd_blncsheet.DataSource = null;
                grd_blncsheet.DataBind();
            }

            if (Session["StrTranType"].ToString() == "CO")
            {
                //ds=FAObj.SelProfitLosswithdate(Session["FADbname"].ToString(),Convert.ToInt32(Session["LoginBranchid"].ToString()),fromdate,todate);
                Ds = FAObj.SelBalanceSheetLedgerwise4AllBranch(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"].ToString()), fromdate, todate);
            }
            else
            {
                Ds = FAObj.SelBalanceSheetLedgerwise(Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), fromdate, todate);
            }

            totA = 0; totL = 0; totAmt = 0; rowcount = 0; PrevGroupno = 0; prevsubgroupno = 0; PrevGroupname = ""; PrevSubGroupname = ""; PrevSubGroupTot = 0;
            if (Ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt_temptb2 = new DataTable();
                DataRow dr;
                DataColumn dc_col1 = new DataColumn("Asset", typeof(string));
                DataColumn dc_col2 = new DataColumn("AssetAmt", typeof(double));
                DataColumn dt_col7 = new DataColumn("LiabilitiesAmt", typeof(double));
                DataColumn dt_col8 = new DataColumn("Liabilities", typeof(string));
                //DataColumn dc_col4 = new DataColumn("portnumber", typeof(Int32));
                //DataColumn dc_col5 = new DataColumn("loctype", typeof(string));
                DataColumn dt_col6 = new DataColumn("AGType", typeof(string));
                DataColumn dt_col9 = new DataColumn("LGType", typeof(string));

                dt_temptb2.Columns.Add(dc_col1);
                dt_temptb2.Columns.Add(dc_col2);
                //dt_temptb2.Columns.Add(dc_col4);
                //dt_temptb2.Columns.Add(dc_col5);
                dt_temptb2.Columns.Add(dt_col6);
                dt_temptb2.Columns.Add(dt_col7);
                dt_temptb2.Columns.Add(dt_col8);
                dt_temptb2.Columns.Add(dt_col9);

                for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (Ds.Tables[0].Rows[i]["grouptype"].ToString() == "A")
                    {
                        dr = dt_temptb2.NewRow();
                        dt_temptb2.Rows.Add(dr);

                        if (PrevGroupname != Ds.Tables[0].Rows[i]["groupname"].ToString())
                        {
                            PrevGroupname = Ds.Tables[0].Rows[i]["groupname"].ToString();
                            dt_temptb2.Rows[PrevGroupno]["AssetAmt"] = totAmt;
                            PrevGroupno = rowcount;
                            dt_temptb2.Rows[rowcount]["Asset"] = Ds.Tables[0].Rows[i]["groupname"].ToString();
                            dt_temptb2.Rows[rowcount]["AGType"] = "G";
                            totA = totA + totAmt;
                            dr = dt_temptb2.NewRow();
                            dt_temptb2.Rows.Add(dr);
                            rowcount = rowcount + 1;
                            totAmt = 0;
                        }

                        if (PrevSubGroupname != Ds.Tables[0].Rows[i]["subgroupname"].ToString())
                        {
                            PrevSubGroupname = Ds.Tables[0].Rows[i]["subgroupname"].ToString();
                            dt_temptb2.Rows[prevsubgroupno]["AssetAmt"] = PrevSubGroupTot;
                            prevsubgroupno = rowcount;
                            dt_temptb2.Rows[rowcount]["Asset"] = "   " + Ds.Tables[0].Rows[i]["Subgroupname"].ToString();
                            dt_temptb2.Rows[rowcount]["AGType"] = "S";
                            dr = dt_temptb2.NewRow();
                            dt_temptb2.Rows.Add(dr);
                            rowcount = rowcount + 1;
                            PrevSubGroupTot = 0;
                        }

                        dt_temptb2.Rows[rowcount]["Asset"] = "       " + Ds.Tables[0].Rows[i]["LedgerName"].ToString();
                        ledgerid = int.Parse(Ds.Tables[0].Rows[i]["ledgerid"].ToString());
                        totopbalcr = (Convert.ToDouble(Ds.Tables[0].Rows[i]["Credit"].ToString()) + Convert.ToDouble(Ds.Tables[0].Rows[i]["OB_Credit"].ToString()));
                        totopbaldb = (Convert.ToDouble(Ds.Tables[0].Rows[i]["Debit"].ToString()) + Convert.ToDouble(Ds.Tables[0].Rows[i]["OB_Debit"].ToString()));

                        if (totopbaldb > totopbalcr)
                        {
                            dbamt = totopbaldb - totopbalcr;
                        }
                        else if (totopbalcr > totopbaldb)
                        {
                            dbamt = totopbalcr - totopbaldb;
                            dbamt = -dbamt;

                        }
                        else
                        {
                            dbamt = 0;
                        }
                        dt_temptb2.Rows[rowcount]["AssetAmt"] = dbamt;
                        dt_temptb2.Rows[rowcount]["AGType"] = "L";
                        rowcount += 1;
                        totAmt = totAmt + dbamt;
                        PrevSubGroupTot = PrevSubGroupTot + dbamt;
                    }
                }

                dt_temptb2.Rows[PrevGroupno]["AssetAmt"] = totAmt;
                dt_temptb2.Rows[prevsubgroupno]["AssetAmt"] = PrevSubGroupTot;
                totA = totA + totAmt;
                dr = dt_temptb2.NewRow();
                dt_temptb2.Rows.Add(dr);
                rowcount = 0;
                totAmt = 0;
                PrevSubGroupTot = 0;
                for (int i = 0; i <= Ds.Tables[1].Rows.Count - 1; i++)
                {
                    if (rowcount >= dt_temptb2.Rows.Count)
                    {
                        dr = dt_temptb2.NewRow();
                        dt_temptb2.Rows.Add();
                    }

                    if (Ds.Tables[1].Rows[i]["grouptype"].ToString() == "L")
                    {
                        if (PrevGroupname != Ds.Tables[1].Rows[i]["groupname"].ToString())
                        {
                            PrevGroupname = Ds.Tables[1].Rows[i]["groupname"].ToString();
                            dt_temptb2.Rows[PrevGroupno]["LiabilitiesAmt"] = totAmt;
                            PrevGroupno = rowcount;
                            dt_temptb2.Rows[rowcount]["Liabilities"] = Ds.Tables[1].Rows[i]["groupname"].ToString();
                            dt_temptb2.Rows[rowcount]["LGType"] = "G";
                            totL = totL + totAmt;
                            rowcount = rowcount + 1;
                            totAmt = 0;
                        }

                        if (PrevSubGroupname != Ds.Tables[1].Rows[i]["subgroupname"].ToString())
                        {
                            PrevSubGroupname = Ds.Tables[1].Rows[i]["subgroupname"].ToString();
                            if (rowcount >= dt_temptb2.Rows.Count)
                            {
                                dr = dt_temptb2.NewRow();
                                dt_temptb2.Rows.Add();
                            }
                            dt_temptb2.Rows[prevsubgroupno]["LiabilitiesAmt"] = PrevSubGroupTot;
                            prevsubgroupno = rowcount;
                            if (rowcount >= dt_temptb2.Rows.Count)
                            {
                                dr = dt_temptb2.NewRow();
                                dt_temptb2.Rows.Add();
                            }
                            dt_temptb2.Rows[rowcount]["Liabilities"] = "   " + Ds.Tables[1].Rows[i]["subgroupname"].ToString();
                            dt_temptb2.Rows[rowcount]["LGType"] = "S";
                            rowcount = rowcount + 1;
                            PrevSubGroupTot = 0;

                        }

                        if (rowcount >= dt_temptb2.Rows.Count)
                        {
                            dr = dt_temptb2.NewRow();
                            dt_temptb2.Rows.Add();
                        }
                        dt_temptb2.Rows[rowcount]["Liabilities"] = "       " + Ds.Tables[1].Rows[i]["LedgerName"].ToString();
                        ledgerid = int.Parse(Ds.Tables[1].Rows[i]["ledgerid"].ToString());
                        GetOpeningBalance();
                        totopbalcr = (Convert.ToDouble(Ds.Tables[1].Rows[i]["Credit"].ToString()) + Convert.ToDouble(Ds.Tables[1].Rows[i]["OB_Credit"].ToString()));
                        totopbaldb = (Convert.ToDouble(Ds.Tables[1].Rows[i]["Debit"].ToString()) + Convert.ToDouble(Ds.Tables[1].Rows[i]["OB_Debit"].ToString()));

                        if (totopbaldb > totopbalcr)
                        {
                            dbamt = totopbaldb - totopbalcr;
                            dbamt = -dbamt;
                        }
                        else
                        {
                            dbamt = totopbalcr - totopbaldb;
                        }
                        dt_temptb2.Rows[rowcount]["LiabilitiesAmt"] = dbamt;
                        dt_temptb2.Rows[rowcount]["LGType"] = "L";
                        rowcount = rowcount + 1;
                        totAmt = totAmt + dbamt;
                        PrevSubGroupTot = PrevSubGroupTot + dbamt;
                    }
                }

                totL = totL + totAmt;
                dt_temptb2.Rows[PrevGroupno]["LiabilitiesAmt"] = totAmt;
                dt_temptb2.Rows[PrevGroupno]["LiabilitiesAmt"] = PrevSubGroupTot;
                rowcount = dt_temptb2.Rows.Count - 1;

                dr = dt_temptb2.NewRow();
                dt_temptb2.Rows.Add(dr);
                CalcProfitandLoss();

                if (Amtdbtotal > Amtcrtotal)
                {
                    NL = Amtdbtotal - Amtcrtotal;
                    dt_temptb2.Rows[dt_temptb2.Rows.Count - 1]["Asset"] = "Net Loss";
                    dt_temptb2.Rows[dt_temptb2.Rows.Count - 1]["AssetAmt"] = NL;
                    strNetProfitorLoss = "Net Loss";
                    dblNetProfitorLossAmt = NL;
                }
                else if (Amtcrtotal > Amtdbtotal)
                {
                    NP = Amtcrtotal - Amtdbtotal;
                    dt_temptb2.Rows[dt_temptb2.Rows.Count - 1]["Liabilities"] = "Net Profit";
                    dt_temptb2.Rows[dt_temptb2.Rows.Count - 1]["LiabilitiesAmt"] = NP;
                    strNetProfitorLoss = "Net Profit";
                    dblNetProfitorLossAmt = NP;
                }
                dr = dt_temptb2.NewRow();
                dt_temptb2.Rows.Add(dr);
                dt_temptb2.Rows[dt_temptb2.Rows.Count - 1]["Asset"] = "Total";
                dt_temptb2.Rows[dt_temptb2.Rows.Count - 1]["Liabilities"] = "Total";
                dt_temptb2.Rows[dt_temptb2.Rows.Count - 1]["AssetAmt"] = totA + NL;
                dt_temptb2.Rows[dt_temptb2.Rows.Count - 1]["LiabilitiesAmt"] = totL + NP;
                grd_blncsheet.Visible = true;
                grd_blncsheet.DataSource = dt_temptb2;
                grd_blncsheet.DataBind();
                GridSubgroup.Visible = false;
                GrdGledger.Visible = false;

                ViewState["dt_temptb2"] = dt_temptb2;
            }
        }

        public void GetOpeningBalance()
        {
            double amt;
            int index = 0;
            //int JJ=0;
            DataSet ds_OB = new DataSet();
            DataTable dt_OB = new DataTable();
            DataTable dtv = new DataTable();
            //DataAccess.FAMaster.ReportView FARepobj = new DataAccess.FAMaster.ReportView();

            ds_OB = FARepobj.FASelopbal(Convert.ToInt32(Session["LoginBranchid"].ToString()), ledgerid, fromdate, todate, Session["FADbname"].ToString());
            if (ds_OB.Tables.Count > 0)
            {
                dt_OB = ds_OB.Tables[0];
                if (dt_OB.Rows.Count > 0)
                {
                    totopbaldb = Convert.ToDouble(dt_OB.Rows[0]["opbaldb"]);
                    //write item 0 th colmn name
                    totopbalcr = Convert.ToDouble(dt_OB.Rows[0]["opbalcr"]);
                    //write item 1 th colmn name 

                }
                dtv = ds_OB.Tables[1];
                if (dtv.Rows.Count > 0)
                {
                    for (int JJ = 0; JJ <= dtv.Rows.Count - 1; JJ++)
                    {
                        if (dtv.Rows[JJ]["ledgertype"].ToString() == "Cr")
                        {
                            totopbalcr = Convert.ToDouble(totopbalcr) + Convert.ToDouble(dtv.Rows[JJ]["amount"]);
                        }
                        else if (dtv.Rows[JJ]["ledgertype"].ToString() == "Dr")
                        {
                            totopbaldb = Convert.ToDouble(totopbaldb) + Convert.ToDouble(dtv.Rows[JJ]["amount"]);
                        }
                    }
                }

                if (totopbalcr > totopbaldb)
                {
                    totopbalcr = totopbalcr - totopbaldb;
                    totopbaldb = 0;
                }
                else if (totopbalcr < totopbaldb)
                {
                    totopbaldb = totopbaldb - totopbalcr;
                    totopbalcr = 0;
                }
                else
                {
                    totopbaldb = 0;
                    totopbalcr = 0;
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                if (GrdGledger.Visible == true)
                {
                    GrdGledger.Visible = false;
                    if (GridSubgroup.Rows.Count > 0)
                    {
                        GridSubgroup.Visible = true;
                    }
                }
                else if (grd_lg_all.Visible == true)
                {
                    grd_lg_all.Visible = false;
                    if (grd_sb_all.Rows.Count > 0)
                    {
                        grd_sb_all.Visible = true;
                    }
                }
                else if (grd_sb_all.Visible == true)
                {
                    grd_sb_all.Visible = false;
                    if (grd_all.Rows.Count > 0)
                    {
                        grd_all.Visible = true;
                    }
                }
                else if (GridSubgroup.Visible == true)
                {
                    GridSubgroup.Visible = false;
                    if (grd_blncsheet.Rows.Count > 0)
                    {
                        grd_blncsheet.Visible = true;
                    }
                    else
                    {
                        grd_all.Visible = true;
                    }
                }

                else
                {
                    chk_consol.Checked = false;
                    Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                    txt_to.Text = Str_CurrrentDate.ToString();
                    txt_from.Text = "01/01/" + Session["LogYear"].ToString();
                    if (grd_blncsheet.Rows.Count > 0)
                    {

                        grd_blncsheet.DataSource = new DataTable();
                        grd_blncsheet.DataBind();
                    }
                    else
                    {
                        grd_all.DataSource = new DataTable();
                        grd_all.DataBind();
                    }
                    btn_cancel.Text = "Back";
                    btn_cancel.ToolTip = "Back";
                    btn_cancel1.Attributes["class"] = "btn ico-back";

                }
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

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
                todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));

                if (fromdate > todate)
                {
                    ScriptManager.RegisterStartupScript(btn_gwise, typeof(Button), "alert", "alertify.alert('From Date Should be Less than To Date');", true);
                    txt_from.Focus();
                    return;
                }

                string Str_RptName, Str_SF, Str_SP, Str_Script;
                Str_RptName = "";
                Str_SF = "";
                Str_SP = "";
                Str_Script = "";

                FAObj.DelPLReports(Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString());

                for (int i = 0; i <= grd_blncsheet.Rows.Count - 1; i++)
                {
                    if (grd_blncsheet.Rows[i].Cells[1].Text != "" || grd_blncsheet.Rows[i].Cells[2].Text != "" || grd_blncsheet.Rows[i].Cells[3].Text != "" || grd_blncsheet.Rows[i].Cells[4].Text != "")
                    {
                        if (grd_blncsheet.Rows[i].Cells[1].Text == "")
                        {
                            rptpartinc = "noparti";
                        }
                        else
                        {
                            rptpartinc = grd_blncsheet.Rows[i].Cells[1].Text.Replace("&amp;", "&");
                        }

                        if (grd_blncsheet.Rows[i].Cells[2].Text == "")
                        {
                            rptincamnt = 0;
                        }
                        else
                        {
                            rptincamnt = Convert.ToDouble(grd_blncsheet.Rows[i].Cells[2].Text);
                        }

                        if (grd_blncsheet.Rows[i].Cells[3].Text == "")
                        {
                            rptpartexp = "noparti";
                        }
                        else
                        {
                            rptpartexp = grd_blncsheet.Rows[i].Cells[3].Text.Replace("&amp;", "&");
                        }

                        if (grd_blncsheet.Rows[i].Cells[4].Text == "")
                        {
                            rptexpamnt = 0;
                        }
                        else
                        {
                            rptexpamnt = Convert.ToDouble(grd_blncsheet.Rows[i].Cells[4].Text);
                        }


                        string str_AGType = "", str_LGType = "";

                        if (str_AGType == "")
                        {
                            str_AGType = "L";
                        }

                        if (str_LGType == "")
                        {
                            str_LGType = "L";
                        }

                        if (ViewState["dt_temptb2"] != null)
                        {
                            DataTable dtBS = new DataTable();
                            dtBS = ViewState["dt_temptb2"] as DataTable;
                            str_AGType = dtBS.Rows[i]["AGType"].ToString();
                            str_LGType = dtBS.Rows[i]["LGType"].ToString();
                        }

                        FAObj.GetInsPLReports(Convert.ToInt32(Session["LoginEmpId"].ToString()), rptpartinc, rptincamnt, rptpartexp, rptexpamnt, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), str_AGType, str_LGType, i);
                    }
                }

                Str_RptName = "rptFABS.rpt";
                Session["str_sfs"] = "{temppl.empid}=" + Session["LoginEmpId"].ToString();
                Session["str_sp"] = "Title= Balance Sheet ~fdate=" + fromdate + "~tdate=" + todate;

                Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "JobInfo", Str_Script, true);

                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1118, 3, int.Parse(Session["LoginBranchid"].ToString()), "BalanceSheet" + txt_from.Text + "~" + txt_to.Text + "/FA/V");
                }
                else
                {
                    logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1207, 3, int.Parse(Session["LoginBranchid"].ToString()), "BalanceSheet" + txt_from.Text + "~" + txt_to.Text + "/FC/V");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_exlxport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "Attachment;filename=BalanceSheetXL.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            if (grd_blncsheet.Rows.Count > 0 && grd_blncsheet.Visible == true)
            {
                grd_blncsheet.Columns[0].Visible = false;
                grd_blncsheet.GridLines = GridLines.Both;
                grd_blncsheet.HeaderStyle.Font.Bold = true;
                grd_blncsheet.RenderControl(HtmlTextWriter);

                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();

            }
            else if (GridSubgroup.Rows.Count > 0 && GridSubgroup.Visible == true)
            {
                GridSubgroup.Columns[3].Visible = false;
                GridSubgroup.GridLines = GridLines.Both;
                GridSubgroup.HeaderStyle.Font.Bold = true;
                GridSubgroup.RenderControl(HtmlTextWriter);

                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            else
                if (GrdGledger.Rows.Count > 0 && GrdGledger.Visible == true)
                {
                    GrdGledger.Columns[3].Visible = false;
                    GrdGledger.GridLines = GridLines.Both;
                    GrdGledger.HeaderStyle.Font.Bold = true;
                    GrdGledger.RenderControl(HtmlTextWriter);

                    Response.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_exlxport, typeof(Button), "Valid text", "alertify.alert('Data not Avaliable');", true);
                }
        }

        protected void chk_consol_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void grd_blncsheet_RowDataBound(object sender, GridViewRowEventArgs e)
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

                LinkButton _singleClickButton1 = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton1, "");
                // Add events to each editable cell
                if (e.Row.Cells[0].Text != "Total")
                {
                    for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                    {
                        // Add the column index as the event argument parameter
                        string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                        // Add this javascript to the onclick Attribute of the cell
                        e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                        // Add a cursor style to the cells
                        e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                        //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_operProfit_AC, "" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }

                    for (int h = 2; h < e.Row.Cells.Count; h++)
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
        }

        protected void btn_branchwise_Click(object sender, EventArgs e)
        {
            try
            {
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
                todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));
                if (fromdate > todate)
                {
                    ScriptManager.RegisterStartupScript(btn_gwise, typeof(Button), "alert", "alertify.alert('From Date Should be Less than To Date');", true);
                    txt_from.Focus();
                    return;
                }

                iframecost.Attributes["src"] = "../FAForms/BalanceSheet4branchwise.aspx?FromDate=" + txt_from.Text + "&ToDate=" + txt_to.Text;
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grd_blncsheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grd_blncsheet_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //GridViewRow row = e.Row;
            //List<TableCell> columns = new List<TableCell>();
            //foreach (DataControlField column in grd_blncsheet.Columns)
            //{
            //    TableCell cell = row.Cells[0];
            //    row.Cells.Remove(cell);
            //    columns.Add(cell);
            //}
            //row.Cells.AddRange(columns.ToArray());
        }

        protected void grd_blncsheet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedRowIndex1, selectedColumnIndex1;
                if (e.CommandName.ToString() == "ColumnClickNew")
                {
                    fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
                    todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));
                    selectedRowIndex1 = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex1 = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    Session["cellindexOP"] = selectedColumnIndex1;
                    string text = grd_blncsheet.Columns[selectedColumnIndex1].HeaderText;
                    Session["HeadOP"] = text;
                    if (selectedRowIndex1 == grd_blncsheet.Rows.Count - 2 || selectedRowIndex1 == grd_blncsheet.Rows.Count - 1 || text == "Amount")
                    {
                        return;
                    }
                    if (selectedColumnIndex1 == 1)
                    {
                        if (grd_blncsheet.Rows[selectedRowIndex1].Cells[1].Text != "")
                        {
                            groupname = grd_blncsheet.Rows[selectedRowIndex1].Cells[1].Text.Replace("&amp;", "&");
                            groupid = FAObj.FASelGroupid(groupname, Session["FADbname"].ToString());
                            if (groupid != 0)
                            {
                                if (chk_consol.Checked == true)
                                {
                                    dt = FAObj.GetSubGroupSummary4BS4AllBranch(Session["FADbname"].ToString(), fromdate, todate, groupid, Convert.ToInt32(Session["LoginDivisionId"]));

                                }
                                else
                                {
                                    if (Session["StrTranType"].ToString() == "CO")
                                    {
                                        dt = FAObj.GetSubGroupSummary4BS(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), groupid);
                                    }
                                    else
                                    {
                                        dt = FAObj.GetSubGroupSummary4BS(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), groupid);
                                    }
                                }

                                if (dt.Rows.Count > 0)
                                {
                                    GridSubgroup.DataSource = dt;
                                    GridSubgroup.DataBind();
                                    GridSubgroup.Visible = true;
                                    grd_blncsheet.Visible = false;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(grd_blncsheet, typeof(GridView), "Balance Sheet", "alertify.alert('No Entry Exists');", true);
                                }
                            }
                        }
                    }
                    else if (selectedColumnIndex1 == 3)
                    {
                        if (grd_blncsheet.Rows[selectedRowIndex1].Cells[3].Text != "")
                        {
                            groupname = grd_blncsheet.Rows[selectedRowIndex1].Cells[3].Text.Replace("&amp;", "&");
                            groupid = FAObj.FASelGroupid(groupname, Session["FADbname"].ToString());
                            if (groupid != 0)
                            {
                                if (chk_consol.Checked == true)
                                {
                                    dt = FAObj.GetSubGroupSummary4AllBranch(Session["FADbname"].ToString(), fromdate, todate, groupid, Convert.ToInt32(Session["LoginDivisionId"]));

                                }
                                else
                                {
                                    if (Session["StrTranType"].ToString() == "CO")
                                    {
                                        dt = FAObj.GetSubGroupSummary4BS(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), groupid);
                                    }
                                    else
                                    {
                                        dt = FAObj.GetSubGroupSummary4BS(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), groupid);
                                    }
                                }

                                if (dt.Rows.Count > 0)
                                {
                                    GridSubgroup.DataSource = dt;
                                    GridSubgroup.DataBind();
                                    GridSubgroup.Visible = true;
                                    grd_blncsheet.Visible = false;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(GridView), "Balance Sheet", "alertify.alert('No Entry Exists');", true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void GridSubgroup_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridSubgroup, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int h = 2; h < e.Row.Cells.Count; h++)
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

        protected void GridSubgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int subgroupid;
                int index = GridSubgroup.SelectedRow.RowIndex;
                //subgroupid = Convert.ToInt32(GridSubgroup.Rows[index].Cells[3].Text.Replace("&amp;", "&")); subgroupid
                subgroupid = Convert.ToInt32(GridSubgroup.DataKeys[index].Values[0].ToString().Replace("&amp;", "&"));
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
                todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));

                if (chk_consol.Checked == true)
                {
                    dt = FAObj.GetLedgerGroupSummary4BS4AllBranch(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginDivisionId"]), subgroupid);
                }
                else
                {
                    dt = FAObj.GetLedgerGroupSummary4BS(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), subgroupid);
                }

                if (dt.Rows.Count > 0)
                {
                    GrdGledger.Visible = true;
                    GrdGledger.DataSource = dt;
                    GrdGledger.DataBind();
                    GridSubgroup.Visible = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void GrdGledger_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdGledger, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int h = 2; h < e.Row.Cells.Count; h++)
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

        protected void GrdGledger_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GrdGledger.SelectedRow.RowIndex;

                iframecost.Attributes["src"] = "../FAForms/FALedgerView.aspx?LedgerID=" + GrdGledger.DataKeys[index].Values[0].ToString() + "&Customer=" + GrdGledger.SelectedRow.Cells[0].Text + "&FromDate=" + txt_from.Text + "&ToDate=" + txt_to.Text + "&Consolidate=" + chk_consol.Checked.ToString();
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
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
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1118, "PA", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1207, "PA", "", "", Session["StrTranType"].ToString());
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

        protected void grd_blncsheet_PreRender(object sender, EventArgs e)
        {
            if (grd_blncsheet.Rows.Count > 0)
            {
                grd_blncsheet.UseAccessibleHeader = true;
                grd_blncsheet.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_all_RowDataBound(object sender, GridViewRowEventArgs e)
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

                LinkButton _singleClickButton1 = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton1, "");
                // Add events to each editable cell
                if (e.Row.Cells[0].Text != "Total")
                {
                    for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                    {
                        // Add the column index as the event argument parameter
                        string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                        // Add this javascript to the onclick Attribute of the cell
                        e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                        // Add a cursor style to the cells
                        e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                        //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_operProfit_AC, "" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }

                    for (int h = 1; h < e.Row.Cells.Count; h++)
                    {
                        double dbl_temp = 0;
                        if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }

                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        if (e.Row.Cells[i].Text == "0" || e.Row.Cells[i].Text == "0.00")
                        {
                            e.Row.Cells[i].Text = "";
                        }
                        e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    }

                }
            }
        }

        protected void grd_all_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grd_all_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grd_all_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedRowIndex1, selectedColumnIndex1;
                if (e.CommandName.ToString() == "ColumnClickNew")
                {
                    fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
                    todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));
                    selectedRowIndex1 = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex1 = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    Session["cellindexOP"] = selectedColumnIndex1;
                    string text = grd_all.Columns[selectedColumnIndex1].HeaderText;
                    Session["HeadOP"] = text;
                    if (selectedRowIndex1 == grd_all.Rows.Count - 2 || selectedRowIndex1 == grd_all.Rows.Count - 1 || text == "Amount")
                    {
                        return;
                    }
                    if (selectedColumnIndex1 == 1)
                    {
                        if (grd_all.Rows[selectedRowIndex1].Cells[1].Text != "")
                        {
                            groupname = grd_all.Rows[selectedRowIndex1].Cells[1].Text.Replace("&amp;", "&");
                            groupid = FAObj.FASelGroupid(groupname, Session["FADbname"].ToString());
                            if (groupid != 0)
                            {
                                if (chk_consol.Checked == true)
                                {
                                    dt = FAObj.GetSubGroupSummary4BS4AllBranch_all_new(Session["FADbname"].ToString(), fromdate, todate, groupid, Convert.ToInt32(Session["LoginDivisionId"]));

                                }
                                else
                                {
                                    if (Session["StrTranType"].ToString() == "CO")
                                    {
                                        dt = FAObj.GetSubGroupSummary4BS_new(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), groupid);
                                    }
                                    else
                                    {
                                        dt = FAObj.GetSubGroupSummary4BS_new(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), groupid);
                                    }
                                }

                                if (dt.Rows.Count > 0)
                                {
                                    grd_sb_all.DataSource = dt;
                                    grd_sb_all.DataBind();
                                    grd_sb_all.Visible = true;
                                    grd_all.Visible = false;
                                    grd_blncsheet.Visible = false;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(grd_blncsheet, typeof(GridView), "Balance Sheet", "alertify.alert('No Entry Exists');", true);
                                }
                            }
                        }
                    }
                    else if (selectedColumnIndex1 == 3)
                    {
                        if (grd_all.Rows[selectedRowIndex1].Cells[3].Text != "")
                        {
                            groupname = grd_all.Rows[selectedRowIndex1].Cells[3].Text.Replace("&amp;", "&");
                            groupid = FAObj.FASelGroupid(groupname, Session["FADbname"].ToString());
                            if (groupid != 0)
                            {
                                if (chk_consol.Checked == true)
                                {
                                    dt = FAObj.GetSubGroupSummary4BS4AllBranch_all_new(Session["FADbname"].ToString(), fromdate, todate, groupid, Convert.ToInt32(Session["LoginDivisionId"]));

                                }
                                else
                                {
                                    if (Session["StrTranType"].ToString() == "CO")
                                    {
                                        dt = FAObj.GetSubGroupSummary4BS_new(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), groupid);
                                    }
                                    else
                                    {
                                        dt = FAObj.GetSubGroupSummary4BS_new(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), groupid);
                                    }
                                }

                                if (dt.Rows.Count > 0)
                                {
                                    grd_sb_all.DataSource = dt;
                                    grd_sb_all.DataBind();
                                    grd_sb_all.Visible = true;
                                    grd_all.Visible = false;
                                    grd_blncsheet.Visible = false;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(GridView), "Balance Sheet", "alertify.alert('No Entry Exists');", true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grd_sb_all_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_sb_all, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int h = 2; h < e.Row.Cells.Count; h++)
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

        protected void grd_sb_all_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int subgroupid;
                int index = grd_sb_all.SelectedRow.RowIndex;
                //subgroupid = Convert.ToInt32(GridSubgroup.Rows[index].Cells[3].Text.Replace("&amp;", "&")); subgroupid
                subgroupid = Convert.ToInt32(grd_sb_all.DataKeys[index].Values[0].ToString().Replace("&amp;", "&"));
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
                todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));

                if (chk_consol.Checked == true)
                {
                    dt = FAObj.GetLedgerGroupSummary4BS4AllBranch_new(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginDivisionId"]), subgroupid);
                }
                else
                {
                    dt = FAObj.GetLedgerGroupSummary4BS_new(Session["FADbname"].ToString(), fromdate, todate, Convert.ToInt32(Session["LoginBranchid"]), subgroupid);
                }

                if (dt.Rows.Count > 0)
                {
                    grd_lg_all.Visible = true;
                    grd_lg_all.DataSource = dt;
                    grd_lg_all.DataBind();
                    grd_sb_all.Visible = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        //protected void GridSubgroup_PreRender1(object sender, EventArgs e)
        //{

        //}

        protected void grd_sb_all_PreRender(object sender, EventArgs e)
        {
            if (grd_sb_all.Rows.Count > 0)
            {
                grd_sb_all.UseAccessibleHeader = true;
                grd_sb_all.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_lg_all_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_lg_all, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                for (int h = 2; h < e.Row.Cells.Count; h++)
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

        protected void grd_lg_all_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = grd_lg_all.SelectedRow.RowIndex;

                iframecost.Attributes["src"] = "../FAForms/FALedgerView.aspx?LedgerID=" + grd_lg_all.DataKeys[index].Values[0].ToString() + "&Customer=" + grd_lg_all.SelectedRow.Cells[0].Text + "&FromDate=" + txt_from.Text + "&ToDate=" + txt_to.Text + "&Consolidate=" + chk_consol.Checked.ToString();
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grd_lg_all_PreRender(object sender, EventArgs e)
        {
            if (grd_lg_all.Rows.Count > 0)
            {
                grd_lg_all.UseAccessibleHeader = true;
                grd_lg_all.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_all_PreRender(object sender, EventArgs e)
        {
            if (grd_all.Rows.Count > 0)
            {
                grd_all.UseAccessibleHeader = true;
                grd_all.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btn_all_Click(object sender, EventArgs e)
        {
            try
            {
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text.ToString()));
                todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text.ToString()));
                if (fromdate > todate)
                {
                    ScriptManager.RegisterStartupScript(btn_gwise, typeof(Button), "alert", "alertify.alert('From Date Should be Less than To Date');", true);
                    txt_from.Focus();
                    return;
                }

                grd_blncsheet.DataSource = null;
                grd_blncsheet.DataBind();
                Getdata1();

                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1118, 3, int.Parse(Session["LoginBranchid"].ToString()), "BalanceSheet-Group" + txt_from.Text + "~" + txt_to.Text + "/FA/GroupWise/V");
                }
                else
                {
                    logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1207, 3, int.Parse(Session["LoginBranchid"].ToString()), "BalanceSheet-Group" + txt_from.Text + "~" + txt_to.Text + "/FC/GroupWise/V");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void GridSubgroup_PreRender(object sender, EventArgs e)
        {
            if (GridSubgroup.Rows.Count > 0)
            {
                GridSubgroup.UseAccessibleHeader = true;
                GridSubgroup.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdGledger_PreRender(object sender, EventArgs e)
        {
            if (GrdGledger.Rows.Count > 0)
            {
                GrdGledger.UseAccessibleHeader = true;
                GrdGledger.HeaderRow.TableSection = TableRowSection.TableHeader;
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

    }
}