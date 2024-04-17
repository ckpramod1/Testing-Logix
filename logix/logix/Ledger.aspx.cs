using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
namespace logix
{
    public partial class Ledger : System.Web.UI.Page
    {

        Calendar CldrFrom, CldrTo;
        //DataTable Dt, dtCustIDs, DtCombined;
        Calendar CldrTemp = new Calendar();
        //ReportShow rptobj;
        CustomerDataAccess.RegCustomer CustObj = new CustomerDataAccess.RegCustomer();
        CustomerDataAccess.PODetails Logobj = new CustomerDataAccess.PODetails();
        public static int intCustID;
        public int intSelIndex = -1;
        public int intRecptid = 0;
        public string strMode, strRptFN, strSF;
        public GrdToExcel grd2exObj = new GrdToExcel();

        DataTable dt = new DataTable();
        DataTable dtv = new DataTable();
        DataTable dt_Tans = new DataTable();
        DataTable dtdet = new DataTable();

        DataRow dr_temp;
        double totopbalcr;
        double totopbaldb;
        double totopbalcrUSD;
        double totopbaldbUSD;
        double dblcum;
        double dblbalance;
        double totcramt;
        double totdramt;

        string dispname;
        string newVouNo;

        protected void Page_Load(object sender, EventArgs e)
        {

            ((ScriptManager)this.FindControl("ScriptManager1")).RegisterPostBackControl(btnToExcel);
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                //CldrFrom = new Calendar(this.Page, dtFrom, ImgFrom);
                //CldrTo = new Calendar(this.Page, dtTo, imgTo);
                //dtFrom.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                dtFrom.Text = Convert.ToDateTime(DateTime.Now.AddDays(-90).ToShortDateString()).ToString("dd/MM/yyyy");      
                dtTo.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                btn_outstd.Visible = false;

            }
            if (Request.QueryString["uid"] != null && Request.QueryString["uid"] != "")
                intCustID = int.Parse(Request.QueryString["uid"].ToString());
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            btn_outstd.Visible = true;
            intCustID = int.Parse(Session["webgroupid"].ToString());
            //CustObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsReceipts, DateTime.Now, dtFrom.Text + " to " + dtTo.Text);
            //Dt = CustObj.GetRecptforCust(intCustID, DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text)), DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text)));
            //grd.DataSource = Dt;
            //grd.DataBind();

            string find = "";
            DateTime FromDate;
            DateTime ToDate;

            FromDate = DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));


            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                return;
            }

            find = CustObj.SPGetDBName4Jsonnew(FromDate, ToDate);

            if (find != "2")
            {
                //FillGrid(find);
                //Changes
                lblError.Text = "";
                FillGridNew(find);
            }
            else if (find == "2")
            {
                //Changes
                lblError.Text = "Date Should be Same Financial Year...";
                dtFrom.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                dtTo.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
                DataTable dtt = new DataTable();
                grd.DataSource = dtt;
                grd.DataBind();
                return;
            }

            //if (Dt.Rows.Count != 0)
            //{
            //    btnToExcel.Enabled = true;
            //    lblError.Text = "";          
            //}
            //else
            //{
            //    lblError.Text = "No data available";         
            //}
        }

        [WebMethod]
        public static List<string> GetLikeLedgerName(string prefix)
        {
            List<string> LedgerName = new List<string>();
            DataTable obj_dt = new DataTable();
            CustomerDataAccess.RegCustomer CustObj = new CustomerDataAccess.RegCustomer();

            obj_dt = CustObj.getlikeledgername4web(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["webgroupid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            HttpContext.Current.Session["LV_Ledger"] = obj_dt;
            LedgerName = Fn_TableToList(obj_dt, "LedgerName", "Ledgerid", "opsid");
            return LedgerName;
        }

        public static List<string> Fn_TableToList(DataTable dt, string str_Textfield, string str_Valuefield, string str_Value)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r[str_Textfield].ToString() + "~" + r[str_Valuefield].ToString() + "~" + r[str_Value].ToString()).ToList();

            return lst_details;
        }

        protected void FillGridNew(string dbname)
        {
            double amt;
            int index = 0;
            DataSet ds = new DataSet();

            DateTime dt_tmpFrom;
            DateTime dt_tmpTo;

            //If txtLedgerName.Text <> "" Then
            dt_tmpFrom = DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
            dt_tmpTo = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));

            //If chkConsolidate.Checked Then
            ds = CustObj.FASelopbal4AllBranchPrabha(Convert.ToInt32(Session["webgroupid"].ToString()), dt_tmpFrom, dt_tmpTo, dbname, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            //Else
            //    ds = FARepobj.FASelopbal(Login.branchid, ledgerid, Format(dt_tmpFrom, "short date"), Format(dt_tmpTo, "short date"), Login.FADbname)
            //End If
            totopbalcr = 0;
            totopbaldb = 0;
            totopbalcrUSD = 0;
            totopbaldbUSD = 0;

            string str_curtype = "";
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    totopbaldb = Convert.ToDouble(dt.Rows[0][0].ToString());
                    totopbalcr = Convert.ToDouble(dt.Rows[0][1].ToString());
                    totopbaldbUSD = Convert.ToDouble(dt.Rows[0][2].ToString());
                    totopbalcrUSD = Convert.ToDouble(dt.Rows[0][3].ToString());
                    str_curtype = dt.Rows[0]["opbalcurr"].ToString();
                }

                dtv = ds.Tables[1];
                if (dtv.Rows.Count > 0)
                {
                    for (int i = 0; i < dtv.Rows.Count; i++)
                    {
                        if (dtv.Rows[i]["ledgertype"].ToString() == "Cr")
                        {
                            totopbalcr = totopbalcr + Convert.ToDouble(dtv.Rows[i]["amount"].ToString());
                            totopbalcrUSD = totopbalcrUSD + Convert.ToDouble(dtv.Rows[i]["amountUSD"].ToString());
                        }
                        else if (dtv.Rows[i]["ledgertype"].ToString() == "Dr")
                        {
                            totopbaldb = totopbaldb + Convert.ToDouble(dtv.Rows[i]["amount"].ToString());
                            totopbaldbUSD = totopbaldbUSD + Convert.ToDouble(dtv.Rows[i]["amountUSD"].ToString());
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

                if (totopbalcrUSD > totopbaldbUSD)
                {
                    totopbalcrUSD = totopbalcrUSD - totopbaldbUSD;
                    totopbaldbUSD = 0;
                }
                else if (totopbalcrUSD < totopbaldbUSD)
                {
                    totopbaldbUSD = totopbaldbUSD - totopbalcrUSD;
                    totopbalcrUSD = 0;
                }
                else
                {
                    totopbaldbUSD = 0;
                    totopbalcrUSD = 0;
                }

                //if(grd.Rows.Count > 0)
                //{
                //      for(int i = 0;i<grd.Rows.Count;i++)
                //      {
                //          grd.Rows.Remove(grd.Rows(0));
                //      }
                //}
                dt_Tans.Columns.Add("voudate");
                dt_Tans.Columns.Add("VNDet");
                dt_Tans.Columns.Add("voutype");
                dt_Tans.Columns.Add("vouno");
                dt_Tans.Columns.Add("prti");
                dt_Tans.Columns.Add("Debit", typeof(double));
                dt_Tans.Columns.Add("Credit", typeof(double));
                dt_Tans.Columns.Add("Balance");
                dt_Tans.Columns.Add("narration");
                dt_Tans.Columns.Add("containerno");
                dt_Tans.Columns.Add("ltype");

                dr_temp = dt_Tans.NewRow();
                //dr_temp["voudate"] = dtFrom.Text;
                //dr_temp["Vouno"] = -1;
                //dr_temp["ltype"] = "Cr";
                //dr_temp["prti"] = "Opening Balance";
                //dr_temp["amount"] = 0;


                dr_temp["voudate"] = dtFrom.Text;
                dr_temp["VNDet"] = -1;
                dr_temp["voutype"] = "";
                dr_temp["vouno"] = -1;
                dr_temp["prti"] = "Opening Balance";

                //grd.Rows.Add()

                //grd.Rows(0).Cells("VDate").Value = Format(dtfrom.Value, "dd/MMM/yyyy")
                //grd.Rows(0).Cells("Particulars").Value = "Opening Balance"
                string str;
                str = "";
                amt = 0.00;
                if (totopbaldb == 0)
                {
                    dr_temp["Debit"] = amt;
                }
                else
                {
                    dr_temp["Debit"] = totopbaldb;
                    dr_temp["Balance"] = -totopbaldb;
                }
                if (totopbalcr == 0)
                {
                    dr_temp["Credit"] = amt;
                }
                else
                {
                    dr_temp["Credit"] = totopbalcr;
                    dr_temp["Balance"] = totopbalcr;
                }
            }

            dr_temp["narration"] = "";
            dr_temp["containerno"] = "";
            dr_temp["ltype"] = "";

            dt_Tans.Rows.Add(dr_temp);
            //Dim newVouNo As String
            //Dim dispname As String

            dispname = "ledgername";

            dtdet = CustObj.FAselLedgergrd4AllBranchPrabha(Convert.ToInt32(Session["webgroupid"].ToString()), dt_tmpFrom, dt_tmpTo, dbname, Convert.ToInt32(Session["LoginDivisionId"].ToString()));

            //Dim fbid As Integer
            //fbid = Login.divisionid
            double db;
            double cr;

            if (dtdet.Rows.Count > 0)
            {
                for (int i = 0; i < dtdet.Rows.Count; i++)
                {
                    dr_temp = dt_Tans.NewRow();

                    dr_temp["voudate"] = dtdet.Rows[i]["voudate"].ToString();
                    newVouNo = dtdet.Rows[i]["VNDet"].ToString();
                    newVouNo = newVouNo.Replace("AC-", "");
                    dr_temp["VNDet"] = newVouNo;
                    dr_temp["vouno"] = dtdet.Rows[i]["vouno"].ToString();
                    dr_temp["voutype"] = dtdet.Rows[i]["voutype"].ToString();
                    dr_temp["prti"] = dtdet.Rows[i]["prti"].ToString();

                    if (dtdet.Rows[i]["ltype"].ToString() == "Dr")
                    {
                        amt = Convert.ToDouble(dtdet.Rows[i]["amount"].ToString());
                        dr_temp["Debit"] = amt;
                        dr_temp["Credit"] = 0.00;
                    }
                    else if (dtdet.Rows[i]["ltype"].ToString() == "Cr")
                    {
                        amt = Convert.ToDouble(dtdet.Rows[i]["amount"].ToString());
                        dr_temp["Credit"] = amt;
                        dr_temp["Debit"] = 0.00;
                    }

                    dblcum = Convert.ToDouble(dr_temp["Credit"]) - Convert.ToDouble(dr_temp["Debit"]);
                    dblbalance = dblbalance + dblcum;

                    if (dblbalance >= 0)
                    {
                        dr_temp["Balance"] = dblbalance.ToString() + "(Cr)";
                    }
                    else
                    {
                        dr_temp["Balance"] = dblbalance.ToString().Replace("-", "") + "(Dr)";
                    }

                    //if(dr_temp["Debit"].ToString().Length>0)
                    //{
                    //    db = Convert.ToDouble(dr_temp["Debit"]);
                    //}
                    //else
                    //{
                    //    db = 0.00;
                    //}

                    //if (dr_temp["Credit"].ToString().Length > 0)
                    //{
                    //    cr = Convert.ToDouble(dr_temp["Credit"]);
                    //}
                    //else
                    //{
                    //    cr = 0.00;
                    //}

                    // dblcum = db - cr;
                    // //dblcum = Convert.ToDouble(grd.Rows(count + i - 1).Cells("Amount").Value) + dblcum;
                    // dr_temp["Balance"] = dblcum;

                    dr_temp["narration"] = dtdet.Rows[i]["Narration"].ToString();
                    dr_temp["containerno"] = dtdet.Rows[i]["containerno"].ToString();
                    dr_temp["ltype"] = dtdet.Rows[i]["ltype"].ToString();
                    dt_Tans.Rows.Add(dr_temp);
                }
            }

            double dbl_Closing_dbamt = 0;
            double dbl_Closing_cramt = 0;
            double dbl_dbamt = 0;
            double dbl_cramt = 0;

            dr_temp = dt_Tans.NewRow();
            dr_temp["voudate"] = "";
            dr_temp["Vouno"] = 0;
            dr_temp["voutype"] = "";
            dr_temp["prti"] = "Transaction Total";

            dr_temp["Debit"] = dt_Tans.Compute("sum(Debit)", "ltype='Dr' and vouno>0");
            dr_temp["Credit"] = dt_Tans.Compute("sum(Credit)", "ltype='Cr' and vouno>0");
            if (dr_temp["Debit"].ToString().Length == 0)
            {
                dr_temp["Debit"] = "0.00";
            }
            if (dr_temp["Credit"].ToString().Length == 0)
            {
                dr_temp["Credit"] = "0.00";
            }
            dr_temp["Balance"] = 0;
            dr_temp["narration"] = "";
            dr_temp["containerno"] = "";
            dr_temp["ltype"] = "";

            dt_Tans.Rows.Add(dr_temp);

            //start
            dr_temp = dt_Tans.NewRow();
            dr_temp["voudate"] = "";
            dr_temp["Vouno"] = 0;
            dr_temp["voutype"] = "";
            dr_temp["prti"] = "Total";

            dr_temp["Debit"] = Convert.ToDouble(dt_Tans.Compute("sum(Debit)", "prti not like '%Transaction Total%'").ToString());
            dr_temp["Credit"] = dt_Tans.Compute("sum(Credit)", "prti not like '%Transaction Total%'");
            if (dr_temp["Debit"].ToString().Length == 0)
            {
                dr_temp["Debit"] = "0.00";
            }
            if (dr_temp["Credit"].ToString().Length == 0)
            {
                dr_temp["Credit"] = "0.00";
            }
            dr_temp["Balance"] = 0;
            dr_temp["narration"] = "";
            dr_temp["containerno"] = "";
            dr_temp["ltype"] = "";

            dt_Tans.Rows.Add(dr_temp);

            //end

            dbl_Closing_dbamt = Convert.ToDouble(dr_temp["Debit"].ToString()) - Convert.ToDouble(dr_temp["Credit"].ToString());
            dbl_Closing_cramt = dbl_Closing_dbamt;
            dbl_dbamt = Convert.ToDouble(dr_temp["Debit"].ToString());
            dbl_cramt = Convert.ToDouble(dr_temp["Credit"].ToString());

            dr_temp = dt_Tans.NewRow();
            dr_temp["voudate"] = "";
            dr_temp["Vouno"] = 0;
            dr_temp["voutype"] = "";
            dr_temp["prti"] = "Closing Balance";
            if (dbl_Closing_dbamt < 0)
            {
                dr_temp["Debit"] = dbl_Closing_dbamt.ToString().Replace("-", "");
                dbl_Closing_cramt = 0;
            }
            else
            {
                dr_temp["Credit"] = dbl_Closing_dbamt.ToString().Replace("-", "");
                dbl_Closing_dbamt = 0;
            }

            dr_temp["Balance"] = 0;
            dr_temp["narration"] = "";
            dr_temp["containerno"] = "";
            dr_temp["ltype"] = "";
            dt_Tans.Rows.Add(dr_temp);

            dr_temp = dt_Tans.NewRow(); ;
            dr_temp["voudate"] = "";
            dr_temp["Vouno"] = 0;
            dr_temp["voutype"] = "";
            dr_temp["prti"] = "Grand Total";
            dr_temp["Debit"] = (dbl_Closing_dbamt + dbl_dbamt).ToString().Replace("-", "");
            dr_temp["Credit"] = (dbl_Closing_cramt + dbl_cramt).ToString().Replace("-", "");
            dr_temp["Balance"] = 0;
            dr_temp["narration"] = "";
            dr_temp["containerno"] = "";
            dr_temp["ltype"] = "";
            dt_Tans.Rows.Add(dr_temp);

            grd.DataSource = dt_Tans;
            grd.DataBind();

            //dr_temp = dt_Tans.NewRow();
            //  totcramt = 0;
            //  totdramt = 0;

            //Dim totfdramt As Double = 0
            //Dim totfcramt As Double = 0

            //for(int i = 0;i<dt_Tans.Rows.Count;i++)
            //{
            //    if(dt_Tans.Rows[i]["Credit"].ToString() == "")
            //    {
            //         totcramt = totcramt + 0;
            //    }
            //    else
            //    {
            //         totcramt = totcramt + Convert.ToDouble(dt_Tans.Rows[i]["Credit"].ToString());
            //    }

            //    if(dt_Tans.Rows[i]["Debit"].ToString() == "")
            //    {
            //         totdramt = totdramt + 0;
            //    }
            //    else
            //    {
            //         totdramt = totdramt + Convert.ToDouble(dt_Tans.Rows[i]["Debit"].ToString());
            //    }

            //    dblamttmp =


            //}
            //   For k = 0 To grd.Rows.Count - 1


            //       dblamttmp = Convert.ToDouble(grd.Rows(k).Cells("Amount").Value)
            //       If dblamttmp >= 0 Then
            //           grd.Rows(k).Cells("Amount").Value = Format(dblamttmp, "0.00").ToString() + "(Cr)"
            //       Else
            //           grd.Rows(k).Cells("Amount").Value = Format(dblamttmp, "0.00").ToString().Replace("-", "") + "(Dr)"
            //       End If


            //       If CStr(grd.Rows(k).Cells("fdrAmt").Value) = "" Then
            //           totfdramt = totfdramt + 0
            //       Else
            //           totfdramt = totfdramt + grd.Rows(k).Cells("fdrAmt").Value
            //       End If
            //       If CStr(grd.Rows(k).Cells("fcrAmt").Value) = "" Then
            //           totfcramt = totfcramt + 0
            //       Else
            //           totfcramt = totfcramt + grd.Rows(k).Cells("fcrAmt").Value
            //       End If
            //   Next k

            //        Dim transtotdramt As Double
            //        Dim transtotcramt As Double
            //        Dim transftotdramt As Double
            //        Dim transftotcramt As Double
            //        cncl = grd.Rows.Count
            //        grd.Rows.Add()
            //        grd.Rows(cncl).DefaultCellStyle.ForeColor = Color.Black
            //        grd.Rows(cncl).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            //        grd.Rows(cncl).Cells("Particulars").Value = "Transaction Total"
            //        If CStr(grd.Rows(0).Cells("Credit").Value) = "" Then
            //            transtotcramt = totcramt - 0
            //            transftotcramt = totfcramt - 0
            //        Else
            //            transtotcramt = totcramt - grd.Rows(0).Cells("Credit").Value
            //            transftotcramt = totfcramt - grd.Rows(0).Cells("fcramt").Value
            //        End If
            //        If CStr(grd.Rows(0).Cells("Debit").Value) = "" Then
            //            transtotdramt = totdramt - 0
            //            transftotdramt = totfdramt - 0
            //        Else
            //            transtotdramt = totdramt - grd.Rows(0).Cells("Debit").Value
            //            transftotdramt = totfdramt - grd.Rows(0).Cells("fdramt").Value
            //        End If
            //        grd.Rows(cncl).Cells("Debit").Value = transtotdramt
            //        grd.Rows(cncl).Cells("Credit").Value = transtotcramt
            //        grd.Rows(cncl).Cells("fdramt").Value = Format(transftotdramt, "0.00")
            //        grd.Rows(cncl).Cells("fcramt").Value = Format(transftotcramt, "0.00")




            //        cncl = grd.Rows.Count
            //        grd.Rows.Add()
            //        grd.Rows(cncl).DefaultCellStyle.ForeColor = Color.Black
            //        grd.Rows(cncl).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            //        grd.Rows(cncl).Cells("Particulars").Value = "Total"
            //        grd.Rows(cncl).Cells("Debit").Value = totdramt
            //        grd.Rows(cncl).Cells("Credit").Value = totcramt
            //        grd.Rows(cncl).Cells("fdrAmt").Value = Format(totfdramt, "0.00")
            //        grd.Rows(cncl).Cells("fcrAmt").Value = Format(totfcramt, "0.00")
            //        If totcramt > totdramt Then
            //            totclosbal = totcramt - totdramt
            //            cncl = grd.Rows.Count
            //            grd.Rows.Add()
            //            grd.Rows(cncl).DefaultCellStyle.ForeColor = Color.Black
            //            grd.Rows(cncl).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            //            grd.Rows(cncl).Cells("Particulars").Value = "Closing Balance"
            //            grd.Rows(cncl).Cells("Debit").Value = totclosbal
            //        ElseIf totcramt < totdramt Then
            //            totclosbal = totdramt - totcramt
            //            cncl = grd.Rows.Count
            //            grd.Rows.Add()
            //            grd.Rows(cncl).DefaultCellStyle.ForeColor = Color.Black
            //            grd.Rows(cncl).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            //            grd.Rows(cncl).Cells("Particulars").Value = "Closing Balance"
            //            grd.Rows(cncl).Cells("Credit").Value = totclosbal
            //        ElseIf totcramt = totdramt Then
            //            totclosbal = 0
            //            cncl = grd.Rows.Count
            //            grd.Rows.Add()
            //            grd.Rows(cncl).DefaultCellStyle.ForeColor = Color.Black
            //            grd.Rows(cncl).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            //            grd.Rows(cncl).Cells("Particulars").Value = "Closing Balance"
            //            grd.Rows(cncl).Cells("Debit").Value = totclosbal
            //            grd.Rows(cncl).Cells("Credit").Value = totclosbal
            //        End If


            //        If totfcramt > totfdramt Then
            //            totclosbal = totfcramt - totfdramt
            //            grd.Rows(cncl).Cells("fdramt").Value = Format(totclosbal, "0.00")
            //        ElseIf totfcramt < totfdramt Then
            //            totclosbal = totfdramt - totfcramt
            //            grd.Rows(cncl).Cells("fcramt").Value = Format(totclosbal, "0.00")
            //        ElseIf totcramt = totdramt Then
            //            totclosbal = 0
            //            grd.Rows(cncl).Cells("fdramt").Value = totclosbal
            //            grd.Rows(cncl).Cells("fcramt").Value = totclosbal
            //        End If

            //        cncl = grd.Rows.Count
            //        grd.Rows.Add()
            //        grd.Rows(cncl).DefaultCellStyle.ForeColor = Color.Black
            //        grd.Rows(cncl).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            //        grd.Rows(cncl).Cells("Particulars").Value = "Grand Total"
            //        'if grd.Rows(cncl - 2).Cells(4).Value="" then
            //        grd.Rows(cncl).Cells("Debit").Value = grd.Rows(cncl - 2).Cells("Debit").Value + grd.Rows(cncl - 1).Cells("Debit").Value
            //        grd.Rows(cncl).Cells("Credit").Value = grd.Rows(cncl - 2).Cells("Credit").Value + grd.Rows(cncl - 1).Cells("Credit").Value


            //        grd.Rows(cncl).Cells("fdramt").Value = Convert.ToDouble(grd.Rows(cncl - 2).Cells("fdramt").Value) + Convert.ToDouble(grd.Rows(cncl - 1).Cells("fdramt").Value)
            //        grd.Rows(cncl).Cells("fcramt").Value = Convert.ToDouble(grd.Rows(cncl - 2).Cells("fcramt").Value) + Convert.ToDouble(grd.Rows(cncl - 1).Cells("fcramt").Value)

            //        'btnview.Enabled = False
            //        btncancel.Text = "&Cancel"
            //    End If
            //End Sub
        }
        private void FillGrid(string dbname)
        {
            //grd_DayWise.Visible = false;
            grd.Visible = true;
            //grd_Monthwise.Visible = false;

            DataSet ds_OpBal = new DataSet();
            DataTable dt_Tans = new DataTable();
            //grd_Monthwise.Visible = false;
            grd.Visible = true;
            DateTime FromDate;
            DateTime ToDate;

            DataAccess.FAMaster.ReportView da_obj_rv = new DataAccess.FAMaster.ReportView();
            DataAccess.LogDetails da_obj_log = new DataAccess.LogDetails();
            string ctrlList;
            string msgList;
            string dtypeList;
            double dbl_temp = 0;
            int int_ledgerid = 0;

            FromDate = DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));

            //if (chkConsolidate.Checked)
            //{
            //ds_OpBal = CustObj.FASelopbal4AllBranch(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, dbname, Convert.ToInt32(Session["LoginDivisionId"]));
            //dt_Tans = CustObj.FAselLedgergrd4AllBranch(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, dbname, Convert.ToInt32(Session["LoginDivisionId"]));
            //}
            //else
            //{
            ds_OpBal = CustObj.FASelopbal4webcs(Convert.ToInt32(Session["webgroupid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString());
            dt_Tans = CustObj.FAselLedgergrdcs(Convert.ToInt32(Session["webgroupid"].ToString()), FromDate, ToDate, Session["FADbname"].ToString());
            //}

            DataRow dr_temp;
            dr_temp = dt_Tans.NewRow();
            dr_temp["voudate"] = dtFrom.Text;
            dr_temp["Vouno"] = -1;
            dr_temp["ltype"] = "Cr";
            dr_temp["prti"] = "Opening Balance";
            dr_temp["amount"] = 0;
            if (ds_OpBal.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToDouble(ds_OpBal.Tables[0].Rows[0]["NewTransDebit"].ToString()) > 0)
                {
                    dr_temp["ltype"] = "Dr";
                    dr_temp["amount"] = Convert.ToDouble(ds_OpBal.Tables[0].Rows[0]["NewTransDebit"].ToString());
                    dr_temp["amountcr"] = 0;
                }
                else
                {
                    dr_temp["ltype"] = "Cr";
                    dr_temp["amountcr"] = Convert.ToDouble(ds_OpBal.Tables[0].Rows[0]["NewTransCredit"].ToString());
                    dr_temp["amount"] = 0;
                }
            }

            dt_Tans.Rows.InsertAt(dr_temp, 0);

            dr_temp = dt_Tans.NewRow();
            dr_temp["Vouno"] = 0;
            dr_temp["ltype"] = "";
            dr_temp["prti"] = "Transaction Total";
            dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' and vouno>0");
            dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr' and vouno>0");
            dt_Tans.Rows.Add(dr_temp);

            double dbl_Closing_dbamt = 0;
            double dbl_Closing_cramt = 0;
            double dbl_dbamt = 0;
            double dbl_cramt = 0;
            dr_temp = dt_Tans.NewRow();
            dr_temp["Vouno"] = 0;
            dr_temp["ltype"] = "";
            dr_temp["prti"] = "Total";
            dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' and vouno>0 ");
            dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr' and vouno>0");
            if (dr_temp["amount"].ToString().Length == 0)
            {
                dr_temp["amount"] = "0.00";
            }
            if (dr_temp["amountcr"].ToString().Length == 0)
            {
                dr_temp["amountcr"] = "0.00";
            }
            dt_Tans.Rows.Add(dr_temp);

            dbl_Closing_dbamt = Convert.ToDouble(dr_temp["amount"].ToString()) - Convert.ToDouble(dr_temp["amountCr"].ToString());
            dbl_Closing_cramt = dbl_Closing_dbamt;
            dbl_dbamt = Convert.ToDouble(dr_temp["amount"].ToString());
            dbl_cramt = Convert.ToDouble(dr_temp["amountCr"].ToString());

            dr_temp = dt_Tans.NewRow();
            dr_temp["Vouno"] = 0;
            dr_temp["ltype"] = "";
            dr_temp["prti"] = "Closing Balance";
            if (dbl_Closing_dbamt < 0)
            {
                dr_temp["amount"] = dbl_Closing_dbamt.ToString().Replace("-", "");
                dbl_Closing_cramt = 0;
            }
            else
            {
                dr_temp["amountcr"] = dbl_Closing_dbamt.ToString().Replace("-", "");
                dbl_Closing_dbamt = 0;
            }

            dt_Tans.Rows.Add(dr_temp);

            dr_temp = dt_Tans.NewRow();
            dr_temp["Vouno"] = 0;
            dr_temp["ltype"] = "";
            dr_temp["prti"] = "Grand Total";
            dr_temp["amount"] = (dbl_Closing_dbamt + dbl_dbamt).ToString().Replace("-", "");
            dr_temp["amountcr"] = (dbl_Closing_cramt + dbl_cramt).ToString().Replace("-", "");
            dt_Tans.Rows.Add(dr_temp);

            grd.DataSource = dt_Tans;
            grd.DataBind();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (BtnCancel.Text == "Cancel")
            {
                //Changes
                DataTable dtt = new DataTable();
                grd.DataSource = dtt;
                grd.DataBind();
                btnToExcel.Enabled = false;
                BtnCancel.Text = "Back";
                lblError.Text = "";
                btn_outstd.Visible = false;
            }
            else
            {
                //Response.Redirect("Default.aspx");
            }

        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            intSelIndex = grd.SelectedIndex;
            intRecptid = int.Parse(grd.SelectedRow.Cells[7].Text.Trim());
            strMode = grd.SelectedRow.Cells[3].Text.Trim();

            //if (strMode == "Bank")
            //    strRptFN = "ReceiptCash.rpt";
            //else if (strMode == "Cash")
            //    strRptFN = "ReceiptBank.rpt";
            //intRecptid = 18;
            //strSF = "ReceiptHead.receiptid~" + intRecptid + "~Num~=";
            //rptobj = new ReportShow(strRptFN, strSF, "", "", BtnPrint, this.Page);

        }

        //protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (e.Row.Cells[8].Text.Length > 25)
        //            e.Row.Cells[8].Text = e.Row.Cells[8].Text.Substring(0, 25) + " ...";
        //        if (e.Row.Cells[9].Text.Length > 25)
        //            e.Row.Cells[9].Text = e.Row.Cells[9].Text.Substring(0, 25) + " ...";
        //        e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString().Replace("AC-", "");
        //        if (e.Row.RowIndex == 0)
        //        {
        //            if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
        //            {
        //                e.Row.Cells[7].Text = e.Row.Cells[5].Text;
        //            }
        //            else
        //            {
        //                e.Row.Cells[7].Text = "-" + e.Row.Cells[6].Text;
        //            }

        //        }
        //        if (Convert.ToInt64(grd.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()) <= 0 && e.Row.RowIndex > 0)
        //        {
        //            if (double.TryParse(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text.ToString(), out dbl_temp))
        //            {
        //                if (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) < 0)
        //                {
        //                    grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (grd.Rows[e.Row.RowIndex - 1].Cells[7].Text + "  (Cr)").ToString().Replace("-", "");
        //                }
        //                else
        //                {
        //                    grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (grd.Rows[e.Row.RowIndex - 1].Cells[7].Text + "  (Dr)").ToString();
        //                }
        //            }
        //            e.Row.Cells[7].Text = "";
        //        }
        //        else
        //        {
        //            if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
        //            {
        //                e.Row.Cells[6].Text = "";
        //                e.Row.Cells[15].Text = "";
        //            }
        //            else
        //            {
        //                e.Row.Cells[5].Text = "";
        //                e.Row.Cells[14].Text = "";
        //            }

        //            if (e.Row.RowIndex >= 1)
        //            {
        //                if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
        //                {
        //                    e.Row.Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) + Convert.ToDouble(e.Row.Cells[5].Text)).ToString();
        //                }
        //                else
        //                {
        //                    e.Row.Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) - Convert.ToDouble(e.Row.Cells[6].Text)).ToString();
        //                }
        //                if (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) < 0)
        //                {
        //                    grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (grd.Rows[e.Row.RowIndex - 1].Cells[7].Text + "  (Cr)").ToString().Replace("-", "");
        //                }
        //                else
        //                {
        //                    grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (grd.Rows[e.Row.RowIndex - 1].Cells[7].Text + "  (Dr)").ToString();
        //                }
        //            }

        //        }

        //    }
        //}

        protected void btnToExcel_Click(object sender, EventArgs e)
        {
            btn_outstd.Visible = true;
            //DataTable dtTarget;
            //int[] intTempArray = { 1, 2, 3, 4, 5, 6 };
            //dtTarget = ConvertToExCel.ConvertGridToDtbl(grd, intTempArray);
            //CustObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsReceipts, DateTime.Now, dtFrom.Text + " to " + dtTo.Text + "/Excel");
            //ConvertToExCel.SetData(dtTarget, "Receipts.csv", ConvertToExCel.ConversionType.Excel);
            //btnToExcel.Enabled = false;
            //Response.Redirect("ToExcel.aspx?pmtr=Table");
            DateTime FromDate;
            DateTime ToDate;

            FromDate = DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));


            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btnToExcel, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                return;
            }
            if (grd.Rows.Count > 0)
            {

                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Ledger" + dtFrom.Text + " To " + dtTo.Text + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                if (grd.Visible == true)
                {
                    grd.GridLines = GridLines.Both;
                    grd.HeaderStyle.Font.Bold = true;
                    grd.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public DataTable CombineData(DataTable DtSource, DataTable dtNew)
        {
            DataTable dtTemp;
            dtTemp = new DataTable();
            dtTemp = DtSource;

            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                DataRow dtrow = dtTemp.NewRow();

                for (int j = 0; j < dtTemp.Columns.Count; j++)
                {
                    dtrow[j] = dtNew.Rows[i][j];
                }
                dtTemp.Rows.Add(dtrow);
            }
            return dtTemp;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void btn_outstd_Click(object sender, EventArgs e)
        {
            Session["Vouyear"] = (Logobj.GetDate().Year - 1).ToString();
            Session["LogYear"] = (Logobj.GetDate().Year - 1).ToString();
            Session["LYEAR"] = (Logobj.GetDate().Year - 1).ToString();
            Session["LoginBranchName"] = "CORPORATE";
            Session["LoginDivisionId"] = "1";
            Session["LoginEmpId"] = "1";
            string legername = "";
            int ledgerid=0;
            int custid = 0;
            DataTable dtnew = new DataTable();
            dtnew = CustObj.spgetledgername(int.Parse(Session["webgroupid"].ToString()));
            legername = dtnew.Rows[0][0].ToString();
            ledgerid = Convert.ToInt32(dtnew.Rows[0][1].ToString());
            custid = Convert.ToInt32(dtnew.Rows[0][2].ToString());
            iframe_outstd.Attributes["src"] = "../FAForms/OutstandingNewOnline.aspx?Ledgername=" + legername + "&LedgerID=" + ledgerid.ToString() + "&hf_custid=" + ledgerid.ToString() + "&Todate=" + dtTo.Text + "&bidcus=" + "5";

            //iframe_outstd.Attributes["src"] = "../FAForms/OutstandingNewOnline.aspx?Ledgername=" + legername + "&LedgerID=" + ledgerid.ToString() + "&hf_custid=" + ledgerid.ToString() + "&Todate=" + dtTo.Text + "&bidcus=" + "5";
            
          
            this.MOdal_popup_outstd.Show();
        }
    }
}