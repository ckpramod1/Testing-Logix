using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Web.UI.DataVisualization.Charting;
using ClosedXML.Excel;

namespace logix.Home
{
    public partial class OAHome : System.Web.UI.Page
    {
        DataTable dtCout = new DataTable();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
        DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.Recipts objreceipt = new DataAccess.Accounts.Recipts();
        DataAccess.Masters.MasterChequeReq_App objCheqReq = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Accounts.Recipts objReceipt = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.ProAdminDCNNo objAdminDnCn = new DataAccess.Accounts.ProAdminDCNNo();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataTable dt = new DataTable();
        DataTable dthbl = new DataTable();
        DataTable dtmbl = new DataTable();
        DataTable dttemp = new DataTable();
        DataTable dttempfa = new DataTable();
        DataTable dttemptds = new DataTable();
        long lngPQuot, lngInv, lngPA, lngDN, lngCN;
        public static int int_branchid = 0;
        string str_Uiid;
        string trantype, trantype1;
        string typ;
        int branchid, vouyear, logempid, cid;
        int empid = 0, int_Empid, div, bid, month, int_vouyear;
        string str_VType = "";
        DateTime year;
        string ModuleName;
        string hname;
        int sgroupid = 0;
        int customerid = 0;
        int chkledgerid;
        int saleid = 0;
        int time1;
        DateTime date;
        string sgname;
        int lid;
        DataTable dtvou;
        DataTable dtemptynew = new DataTable();
        DataSet ds1;
        DataTable dts = new DataTable();
        DataTable dt_sel = new DataTable();
        DataTable dt_funddata = new DataTable();
        int selectedRowIndex;
        int selectedColumnIndex;
        string Lst_DNno;

        DataAccess.FAVoucher obj_voucher = new DataAccess.FAVoucher();
        protected void Page_Load(object sender, EventArgs e)
        {

          

            div_OAold.Visible = false;
            if (!IsPostBack)
            {

                exp2excGrd_Deposite.Visible = false;
                CheueRequest_Count();
                Deposite_TotCount();
                Tds_Count();
                //UnclosedJobs1();
                Un_Closed_Job();
                Collection_Cheque();
                Over_All_Counts_CNDN();
                div_bar.Visible = true;
                bookline();
                div2_Bookchart.Visible = true;
                fn_GetOperatingProfitNew();
                //Panelexrate.Visible = true;
                //Gridexrate.Visible = true;
                //// GrdDisable1();

                ////GrdDisable1();

                //grdunclosejobs.Visible = true;
                //PanelUnclosedjob.Visible = true;
                //// GrdDisable1();
                ///*loadgrd();*/
                //Panelexrate.Visible = true;


                //// Grdincomnotbooked();
                ///*  PendingApprovalFE1();
                //  LoadPendingTDS1();
                //  LoadPendingFA1();
                // UnclosedJobs1();
                //  LoadPendingDep1();*/


                //Paneljobcostingframe.Visible = true;
                //Gridjobcost.Visible = true;
                //Paneljobcost.Visible = true;
                //lbl1.Enabled = true;
                //txt_job.Visible = true;
                //ddl_product.Visible = true;

                /*  BranchDSO();
                  totaloutstandingamount();
                  totaloverdueamount();*/

                /*   this.LoadPendingTDS();
                   this.LoadPendingFA();


                
             
                  this.LoadPendingDep();

                      this.PendingApprovalFE();*/

                /*  DepositDetailsnew();
                  ExpencesNotBooked();
              */

                // totaloutstandingamount();
                //totaloverdueamount();

                //fundflowbranches();      
                //this.UnclosedJobs1();
                /*  UnclosedJobs1();*/
            }



        }


        public void fn_GetOperatingProfitNew()
        {

            DataTable dt_OprProfit = new DataTable();
            DataTable dt = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //string transtype = Session["StrTranType"].ToString();
            DateTime Todate = Convert.ToDateTime(obj_da_Log.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            int count;

            dt_OprProfit = da_obj_misgrd.GetOperatingProfit(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), "AC", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            if (dt_OprProfit.Rows.Count > 0)
            {

                dt_OprProfit.Columns.Add(new DataColumn("Total"));
                double dbl_Total = 0, dbl_Full_Total = 0;
                for (int k = 0; k < dt_OprProfit.Rows.Count; k++)
                {
                    dbl_Total = 0;
                    for (int R = 1; R < dt_OprProfit.Columns.Count; R++)
                    {
                        if (dt_OprProfit.Rows[k][R].ToString().Length > 0)
                            dbl_Total = dbl_Total + Convert.ToDouble(dt_OprProfit.Rows[k][R].ToString());
                    }
                    dt_OprProfit.Rows[k]["Total"] = dbl_Total;
                    dbl_Full_Total = dbl_Full_Total + dbl_Total;
                }


                DataRow dr_temp = dt_OprProfit.NewRow();
                dr_temp[0] = "Total";


                for (int R = 1; R < dt_OprProfit.Columns.Count - 1; R++)
                {
                    dr_temp[R] = dt_OprProfit.Compute("sum(" + dt_OprProfit.Columns[R].Caption.ToString() + ")", "");
                }

                dr_temp["Total"] = dbl_Full_Total;
                dt_OprProfit.Rows.Add(dr_temp);

                if (dt_OprProfit.Columns.Contains("AE"))
                {
                    SPoutstAE.InnerText = Math.Round(Convert.ToDouble(dt_OprProfit.Rows[0]["AE"].ToString())).ToString("#,0");
                }
                else
                {
                    SPoutstAE.InnerText = "0";
                }
                if (dt_OprProfit.Columns.Contains("AI"))
                {
                    SPoutstAI.InnerText = Math.Round(Convert.ToDouble(dt_OprProfit.Rows[0]["AI"].ToString())).ToString("#,0");
                }
                else
                {
                    SPoutstAI.InnerText = "0";
                }

                if (dt_OprProfit.Columns.Contains("BT"))
                {
                    SPoutstBT.InnerText = Math.Round(Convert.ToDouble(dt_OprProfit.Rows[0]["BT"].ToString())).ToString("#,0");
                }
                else
                {
                    SPoutstBT.InnerText = "0";
                }
                if (dt_OprProfit.Columns.Contains("CH"))
                {

                    SPoutstCH.InnerText = Math.Round(Convert.ToDouble(dt_OprProfit.Rows[0]["CH"].ToString())).ToString("#,0");
                }
                else
                {
                    SPoutstCH.InnerText = "0";
                }
                if (dt_OprProfit.Columns.Contains("OE"))
                {

                    SPoutstOE.InnerText = Math.Round(Convert.ToDouble(dt_OprProfit.Rows[0]["OE"].ToString())).ToString("#,0");
                }
                else
                {
                    SPoutstOE.InnerText = "0";
                }
                if (dt_OprProfit.Columns.Contains("OI"))
                {

                    SPoutstOI.InnerText = Math.Round(Convert.ToDouble(dt_OprProfit.Rows[0]["OI"].ToString())).ToString("#,0");
                }
                else
                {
                    SPoutstOI.InnerText = "0";
                }
                SPoutsttot.InnerText = Math.Round(Convert.ToDouble(dbl_Full_Total.ToString())).ToString("#,0"); //dbl_Full_Total.ToString();

            }
            else
            {
                SPoutstAE.InnerText = "0";
                SPoutstAI.InnerText = "0";
                SPoutstBT.InnerText = "0";
                SPoutstCH.InnerText = "0";
                SPoutstOE.InnerText = "0";
                SPoutstOI.InnerText = "0";
                SPoutsttot.InnerText = "0"; //dbl_Full_Total.ToString();
            }



        }

        public void bookline()
        {
            DataTable dt0 = new DataTable();
            dt0 = objReceipt.GetOverallAmtForBarChart(Convert.ToInt32(Session["LoginBranchid"]));
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Month');
            data.addColumn('number', 'Payments');
             data.addColumn('number', 'Collections');
           
            data.addRows(" + dt0.Rows.Count + ");");



            for (int i = 0; i <= dt0.Rows.Count - 1; i++)
            {


                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt0.Rows[i]["Month"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt0.Rows[i]["Payments"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt0.Rows[i]["Collections"].ToString() + ") ;");

            }

            str.Append("   var chart = new google.visualization.ColumnChart(document.getElementById('chart_divbar'));");
            str.Append(" chart.draw(data, {width: 735, height: 300, title: 'Payments Vs Collections',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}} ,colors: ['#4ebcd5','#bce3c8']");
            str.Append("}); }");
            str.Append("</script>");
            lts.Text = str.ToString().Replace('*', '"');



        }

        [WebMethod]
        public static List<countrydetails> GetChartDataBooking()
        {
            DataTable dt1 = new DataTable();
            List<countrydetails> dataList = new List<countrydetails>();
            //DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            //DataTable dtemptyfree = new DataTable();
            //dtemptyfree = objbu.selpendingBookcutomerwisecount_Chart(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
            DataTable dt = new DataTable();
            DataAccess.LogDetails logobj = new DataAccess.LogDetails();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            //int month = 04;
            int year = Todate.Year;
             double amt=0 ;
             double amt1=0;
             double amt2 = 0;
             double amt3 = 0;
             double amt4 = 0;
             double amt5 = 0;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Operation Profit") });
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Amount") });

            dt = da_obj_misgrd.GetOperatingProfit(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), "AC", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));

            if (dt.Rows.Count > 0)
            {
                dt1.Rows.Add();
                dt1.Rows[dt1.Rows.Count - 1]["Operation Profit"] = "AE";
                if (dt.Columns.Contains("AE"))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["AE"].ToString()))
                    {
                        amt = (Convert.ToDouble(dt.Rows[0]["AE"].ToString()));
                    }
                }
                if (amt>=0)
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = amt.ToString("#0.00");
                }
                else
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = "0.00";
                }
                
                dt1.Rows.Add();
                dt1.Rows[dt1.Rows.Count - 1]["Operation Profit"] = "AI";
                if (dt.Columns.Contains("AI"))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["AI"].ToString()))
                    {
                        amt1 = (Convert.ToDouble(dt.Rows[0]["AI"].ToString()));
                    }
                }
                if (amt1 >= 0)
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = amt1.ToString("#0.00");
                }
                else
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = "0.00";
                }

                dt1.Rows.Add();
                dt1.Rows[dt1.Rows.Count - 1]["Operation Profit"] = "BT";
                if (dt.Columns.Contains("BT"))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["BT"].ToString()))
                    {
                        amt2 = (Convert.ToDouble(dt.Rows[0]["BT"].ToString()));
                    }
                }
                if (amt2 >= 0)
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = amt2.ToString("#0.00");
                }
                else
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = "0.00";
                }
                dt1.Rows.Add();
                dt1.Rows[dt1.Rows.Count - 1]["Operation Profit"] = "CH";
                if (dt.Columns.Contains("CH"))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CH"].ToString()))
                    {
                        amt3 = (Convert.ToDouble(dt.Rows[0]["CH"].ToString()));
                    }
                }
                if (amt3 >= 0)
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = amt3.ToString("#0.00");
                }
                else
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = "0.00";
                }
                dt1.Rows.Add();
                dt1.Rows[dt1.Rows.Count - 1]["Operation Profit"] = "OE";
                if (dt.Columns.Contains("OE"))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["OE"].ToString()))
                    {
                        amt4 = (Convert.ToDouble(dt.Rows[0]["OE"].ToString()));
                    }
                }
                if (amt4 >= 0)
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = amt4.ToString("#0.00");
                }
                else
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = "0.00";
                }
                dt1.Rows.Add();
                dt1.Rows[dt1.Rows.Count - 1]["Operation Profit"] = "OI";
                if (dt.Columns.Contains("OI"))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["OI"].ToString()))
                    {
                        amt5 = (Convert.ToDouble(dt.Rows[0]["OI"].ToString()));
                    }
                }
                if (amt5 >= 0)
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = amt5.ToString("#0.00");
                }
                else
                {
                    dt1.Rows[dt1.Rows.Count - 1]["Amount"] = "0.00";
                }
                foreach (DataRow dtrow in dt1.Rows)
                {
                    countrydetails details = new countrydetails();
                    details.Countryname = dtrow[0].ToString();
                    details.Total = Convert.ToDouble(dtrow[1]);
                    dataList.Add(details);
                  
                }
                

            }
            return dataList;

        }

        public class countrydetails
        {
            public string Countryname { get; set; }
            public Double Total { get; set; }
        }


        public void Over_All_Counts_CNDN()
        {
            DataSet DtSetDnCn = new DataSet();
            DataTable dtDn = new DataTable();
            DataTable dtCn = new DataTable();
            DataTable dtAdDn = new DataTable();
            DataTable dtAdCn = new DataTable();
            DtSetDnCn = objAdminDnCn.GetCoutForAdminOtherCnDn(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            dtDn = DtSetDnCn.Tables[0];
            dtCn = DtSetDnCn.Tables[1];
            dtAdDn = DtSetDnCn.Tables[2];
            dtAdCn = DtSetDnCn.Tables[3];
            if (dtDn.Rows.Count > 0)
            {
                lnk_other_Dn.Text = dtDn.Rows[0][0].ToString();
            }
            else
            {
                lnk_other_Dn.Text = "0";
            }
            if (dtCn.Rows.Count > 0)
            {
                lnk_other_Cn.Text = dtCn.Rows[0][0].ToString();
            }
            else
            {
                lnk_other_Cn.Text = "0";
            }
            if (dtAdDn.Rows.Count > 0)
            {
                lnk_adminDN.Text = dtAdDn.Rows[0][0].ToString();
            }
            else
            {
                lnk_adminDN.Text = "0";
            }
            if (dtAdCn.Rows.Count > 0)
            {
                lnk_AdminCn.Text = dtAdCn.Rows[0][0].ToString();
            }
            else
            {
                lnk_AdminCn.Text = "0";
            }

        }

        public void Collection_Cheque()
        {
            double Amt = 0;
            DataAccess.LogDetails logobj = new DataAccess.LogDetails();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            //int month = Todate.Month;
            //int year = Todate.Year;
            //DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            DataTable DtobjReceipt = new DataTable();
            //DateTime.Now.AddDays(-1)
            DtobjReceipt = objReceipt.GetOverallRecAmt(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), DateTime.Now.AddDays(-1));
            if (DtobjReceipt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(DtobjReceipt.Rows[0][0].ToString()) == true)
                {
                    Amt = Convert.ToDouble(DtobjReceipt.Rows[0][0].ToString());
                    Amt = Math.Round(Amt);
                    spanCH.InnerText = Amt.ToString("#,0");
                }
                else
                {
                    spanCH.InnerText = "0";
                }

            }
            else
            {
                spanCH.InnerText = "0";
            }
        }

        public void Un_Closed_Job()
        {
            DataTable DtApp = new DataTable();
            DtApp = Approveobj.GetPendingUnclose_Job(int.Parse(Session["LoginBranchid"].ToString()));
            if (DtApp.Rows.Count > 0)
            {
                unclosed.InnerText = DtApp.Rows[0][0].ToString();
            }
            else
            {
                unclosed.InnerText = "0";
            }
        }

        public void Tds_Count()
        {

            dtCout = leftObj.GetTDsCountForNew(Convert.ToInt16(Session["LoginDivisionId"].ToString()));
            if (dtCout.Rows.Count > 0)
            {
                tds.InnerText = dtCout.Rows[0][0].ToString();
            }
            else
            {
                tds.InnerText = "0";
            }
        }

        public void Deposite_TotCount()
        {
            double tot;
            dtCout = leftObj.GetDepositAmtTotal(Convert.ToInt16(Session["LoginBranchid"].ToString()));
            if (dtCout.Rows.Count > 0)
            {
                tot = Convert.ToDouble(dtCout.Rows[0][0].ToString());
                tot = Math.Round(tot);
                deposite.InnerText = tot.ToString("#,0");
            }
            else
            {
                deposite.InnerText = "0";
            }
        }


        public void CheueRequest_Count()
        {
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            DataSet Dtset = new DataSet();
            Dtset = objCheqReq.GetCoutForRequest(Session["StrTranType"].ToString(), Convert.ToInt16(Session["LoginDivisionId"].ToString()), Convert.ToInt16(Session["LoginBranchid"].ToString()));
            dt0 = Dtset.Tables[0];
            dt1 = Dtset.Tables[1];
            if (dt0.Rows.Count > 0)
            {
                lnl_CkCnopsRq.Text = dt0.Rows[0][0].ToString();
            }
            else
            {
                lnl_CkCnopsRq.Text = "0";
            }

            if (dt1.Rows.Count > 0)
            {
                lnk_ChCnRq.Text = dt1.Rows[0][0].ToString();
            }
            else
            {
                lnk_ChCnRq.Text = "0";
            }
        }

        public void LoadPendingFA1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetCount4Fa(branchid);
            //hidfa.Text = Convert.ToInt32(dt.Rows.Count).ToString();
            hidfa.Text = dt.Compute("sum(count)", "").ToString();
        }
        public void LoadPendingTDS1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetTDS4dash(branchid);
            //hidTDS.Text = Convert.ToInt32(dt.Rows.Count).ToString();
            hidTDS.Text = dt.Compute("sum(count)", "").ToString();
        }
        public void LoadPendingDep1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetDeposit4dash(branchid);
            hidDeposits.Text = Convert.ToInt32(dt.Rows.Count).ToString();
            // hidDeposits.Text = dt.Compute("sum(Amount)", "").ToString();
        }

        public void PendingApprovalFE1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int intcount;
            vouyear = 2015;
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending Approval") });
            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[1] { new DataColumn("Approved") });
            PanelApproval.Visible = false;
            GrdPending1.Visible = false;
            //  Pop_GrdApproval.Hide();
            if (Strtrantype != "BT")
            {
                if (Strtrantype != "CH")
                {
                    lngPQuot = leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()));
                    dt1.Rows.Add("Quotation" + "  (" + System.Convert.ToString(leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()))) + ")");
                    //GrdPending1.Rows[0].Cells[0].Text = "Quotation" + "  (" + System.Convert.ToString(leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()))) + ")";
                    hidapprovalquo.Text = System.Convert.ToString(leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString())));
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
                    lngInv = dt.Rows.Count;

                    //GrdPending1.Rows[1].Cells[0].Text = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    hidapprovalInvoices.Text = System.Convert.ToString(dt.Rows.Count);
                    intcount = Appobj.GetPenFATrans("InvoiceApproval", Strtrantype, branchid, vouyear);
                    //GrdApproved11.Rows[0].Cells[0].Text = "Invoices" + "(" + intcount + ")";

                    dt2.Rows.Add("Invoices" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
                    lngPA = dt.Rows.Count;

                    //GrdPending1.Rows[2].Cells[0].Text = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    hidapprovalCNOp.Text = System.Convert.ToString(dt.Rows.Count);
                    intcount = Appobj.GetPenFATrans("PAApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[1].Cells[0].Text = "CN Operations" + "(" + intcount + ")";
                    dt2.Rows.Add("CN Operations" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "ProOSDNApproval");
                    lngDN = dt.Rows.Count;

                    //GrdPending1.Rows[3].Cells[0].Text = "Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    hidapprovalOSDebit.Text = System.Convert.ToString(dt.Rows.Count);
                    intcount = Appobj.GetPenFATrans("OSDNApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[2].Cells[0].Text = "O/S Debit Notes" + "(" + intcount + ")";
                    dt2.Rows.Add("O/S Debit Notes" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "ProOSCNApproval");
                    lngCN = dt.Rows.Count;

                    //GrdPending1.Rows[4].Cells[0].Text = "Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    hidapprovalOSCredit.Text = System.Convert.ToString(dt.Rows.Count);
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial DN");
                    lngCN = dt.Rows.Count;

                    //GrdPending1.Rows[5].Cells[0].Text = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    hidapprovalOtherDebitNotes.Text = System.Convert.ToString(dt.Rows.Count);
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial CN");
                    lngCN = dt.Rows.Count;

                    //GrdPending1.Rows[6].Cells[0].Text = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    hidapprovalOtherCreditNotes.Text = System.Convert.ToString(dt.Rows.Count);
                    intcount = Appobj.GetPenFATrans("OSCNApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[3].Cells[0].Text = "O/S Credit Notes" + "(" + intcount + ")";
                    dt2.Rows.Add("O/S Credit Notes" + "(" + intcount + ")");
                    intcount = Appobj.GetPenFATrans("Debit Note", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[4].Cells[0].Text = "Other Debit Notes" + "(" + intcount + ")";
                    dt2.Rows.Add("Other Debit Notes" + "(" + intcount + ")");
                    intcount = Appobj.GetPenFATrans("Credit Note", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[5].Cells[0].Text = "Other Credit Notes" + "(" + intcount + ")";
                    dt2.Rows.Add("Other Credit Notes" + "(" + intcount + ")");

                    GrdPending1.DataSource = dt1;
                    GrdPending1.DataBind();
                }
                else
                {
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
                    lngInv = dt.Rows.Count;
                    //GrdPending1.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
                    lngPA = dt.Rows.Count;

                    //GrdPending1.Rows(1).Cells(0).Value = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial DN");
                    lngCN = dt.Rows.Count;

                    //GrdPending1.Rows(2).Cells(0).Value = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt("Transfer To Commercial CN", Strtrantype, branchid);
                    lngCN = dt.Rows.Count;

                    //GrdPending1.Rows(3).Cells(0).Value = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

                    GrdPending1.DataSource = dt1;
                    GrdPending1.DataBind();
                }
            }
            else
            {
                dt = Appobj.FillDt("Transfer To Commercial Invoice", Strtrantype, branchid);
                lngInv = dt.Rows.Count;
                //GrdPending1.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                dt = Appobj.FillDt("Transfer To Commercial PA", Strtrantype, branchid);
                lngPA = dt.Rows.Count;
                //GrdPending1.Rows(1).Cells(0).Value = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

                GrdPending1.DataSource = dt1;
                GrdPending1.DataBind();
            }
        }

        public void UnclosedJobs1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int intcount = 0;
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("UnClosed Jobs") });

            if (Strtrantype != "CH")
            {
                int necount = 0;
                if (Strtrantype == "AE")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
                    //grdunclosejobs.Rows(0).Cells(0).Value = "AE Jobs" + "(" + necount + ")";
                    dt1.Rows.Add("AE Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "AI")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
                    //grdunclosejobs.Rows(0).Cells(0).Value = "AI Jobs" + "(" + necount + ")"
                    dt1.Rows.Add("AI Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "FE")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
                    //grdunclosejobs.Rows(0).Cells(0).Value = "FE Jobs" + "(" + necount + ")"
                    dt1.Rows.Add("OE Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "FI")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
                    //grdunclosejobs.Rows(0).Cells(0).Value = "FI Jobs" + "(" + necount + ")"
                    dt1.Rows.Add("OI Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "CH")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
                    //grdunclosejobs.Rows(0).Cells(0).Value = "CH Jobs" + "(" + necount + ")"
                    dt1.Rows.Add("CH Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "FA")
                {
                    int necount1 = 0, nicount1 = 0, fecount1 = 0, ficount1 = 0, chcount1 = 0;
                    dt = Approveobj.GetPenUnClose("AC", branchid, 0, logempid);
                    hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i]["trantype"].ToString() == "AE") { necount1 = necount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "AI") { nicount1 = nicount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "FE") { fecount1 = fecount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "FI") { ficount1 = ficount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "CH") { chcount1 = chcount1 + 1; }
                    }
                    //grdunclosejobs.Rows(0).Cells(0).Value = "AE Jobs" + "(" + necount1 + ")"
                    dt1.Rows.Add("AE Jobs" + "(" + necount1 + ")");
                    //grdunclosejobs.Rows(1).Cells(0).Value = "AI Jobs" + "(" + nicount1 + ")"
                    dt1.Rows.Add("AI Jobs" + "(" + nicount1 + ")");
                    //grdunclosejobs.Rows(2).Cells(0).Value = "FE Jobs" + "(" + fecount1 + ")"
                    dt1.Rows.Add("FE Jobs" + "(" + fecount1 + ")");
                    //grdunclosejobs.Rows(3).Cells(0).Value = "FI Jobs" + "(" + ficount1 + ")"
                    dt1.Rows.Add("FI Jobs" + "(" + ficount1 + ")");
                    //grdunclosejobs.Rows(4).Cells(0).Value = "CH Jobs" + "(" + chcount1 + ")"
                    dt1.Rows.Add("CH Jobs" + "(" + chcount1 + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }

                else if (Strtrantype == "AC")
                {
                    int necount1 = 0, nicount1 = 0, fecount1 = 0, ficount1 = 0, chcount1 = 0;
                    dt = Approveobj.GetPenUnClose("AC", branchid, 0, logempid);
                    hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (dt.Rows[i]["trantype"].ToString() == "AE") { necount1 = necount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "AI") { nicount1 = nicount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "FE") { fecount1 = fecount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "FI") { ficount1 = ficount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "CH") { chcount1 = chcount1 + 1; }
                        if (dt.Rows[i]["trantype"].ToString() == "AC") { chcount1 = chcount1 + 1; }
                    }
                    //grdunclosejobs.Rows(0).Cells(0).Value = "AE Jobs" + "(" + necount1 + ")"
                    dt1.Rows.Add("AE Jobs" + "(" + necount1 + ")");
                    //grdunclosejobs.Rows(1).Cells(0).Value = "AI Jobs" + "(" + nicount1 + ")"
                    dt1.Rows.Add("AI Jobs" + "(" + nicount1 + ")");
                    //grdunclosejobs.Rows(2).Cells(0).Value = "FE Jobs" + "(" + fecount1 + ")"
                    dt1.Rows.Add("FE Jobs" + "(" + fecount1 + ")");
                    //grdunclosejobs.Rows(3).Cells(0).Value = "FI Jobs" + "(" + ficount1 + ")"
                    dt1.Rows.Add("FI Jobs" + "(" + ficount1 + ")");
                    //grdunclosejobs.Rows(4).Cells(0).Value = "CH Jobs" + "(" + chcount1 + ")"
                    dt1.Rows.Add("CH Jobs" + "(" + chcount1 + ")");
                    dt1.Rows.Add("AC Jobs" + "(" + chcount1 + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
            }
        }
        public void PendingApprovalFE()
        {
            GrdPending1.Visible = true;
            PanelApproval.Visible = true;

            // Pop_GrdApproval.Show();
            string Strtrantype = Session["StrTranType"].ToString();
            int intcount;
            vouyear = 2015;
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending Approval") });
            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[1] { new DataColumn("Approved") });
            PanelApproval.Visible = true;
            GrdPending1.Visible = true;

            if (Strtrantype != "BT")
            {
                if (Strtrantype != "CH")
                {
                    lngPQuot = leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()));
                    dt1.Rows.Add("Quotation" + "  (" + System.Convert.ToString(leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()))) + ")");
                    //GrdPending1.Rows[0].Cells[0].Text = "Quotation" + "  (" + System.Convert.ToString(leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()))) + ")";
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
                    lngInv = dt.Rows.Count;
                    //GrdPending1.Rows[1].Cells[0].Text = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    intcount = Appobj.GetPenFATrans("InvoiceApproval", Strtrantype, branchid, vouyear);
                    //GrdApproved11.Rows[0].Cells[0].Text = "Invoices" + "(" + intcount + ")";
                    dt2.Rows.Add("Invoices" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
                    lngPA = dt.Rows.Count;
                    //GrdPending1.Rows[2].Cells[0].Text = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    intcount = Appobj.GetPenFATrans("PAApproval", Strtrantype, branchid, vouyear);
                    //GrdApproved11.Rows[1].Cells[0].Text = "CN Operations" + "(" + intcount + ")";
                    dt2.Rows.Add("CN Operations" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "ProOSDNApproval");
                    lngDN = dt.Rows.Count;

                    //GrdPending1.Rows[3].Cells[0].Text = "Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    intcount = Appobj.GetPenFATrans("OSDNApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[2].Cells[0].Text = "O/S Debit Notes" + "(" + intcount + ")";
                    dt2.Rows.Add("O/S Debit Notes" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "ProOSCNApproval");
                    lngCN = dt.Rows.Count;

                    //GrdPending1.Rows[4].Cells[0].Text = "Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial DN");
                    lngCN = dt.Rows.Count;

                    //GrdPending1.Rows[5].Cells[0].Text = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial CN");
                    lngCN = dt.Rows.Count;

                    //GrdPending1.Rows[6].Cells[0].Text = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    intcount = Appobj.GetPenFATrans("OSCNApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[3].Cells[0].Text = "O/S Credit Notes" + "(" + intcount + ")";
                    dt2.Rows.Add("O/S Credit Notes" + "(" + intcount + ")");
                    intcount = Appobj.GetPenFATrans("Debit Note", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[4].Cells[0].Text = "Other Debit Notes" + "(" + intcount + ")";
                    dt2.Rows.Add("Other Debit Notes" + "(" + intcount + ")");
                    intcount = Appobj.GetPenFATrans("Credit Note", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[5].Cells[0].Text = "Other Credit Notes" + "(" + intcount + ")";
                    dt2.Rows.Add("Other Credit Notes" + "(" + intcount + ")");

                    GrdPending1.DataSource = dt1;
                    GrdPending1.DataBind();
                }
                else
                {
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
                    lngInv = dt.Rows.Count;
                    //GrdPending1.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
                    lngPA = dt.Rows.Count;
                    //GrdPending1.Rows(1).Cells(0).Value = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial DN");
                    lngCN = dt.Rows.Count;
                    //GrdPending1.Rows(2).Cells(0).Value = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt("Transfer To Commercial CN", Strtrantype, branchid);
                    lngCN = dt.Rows.Count;
                    //GrdPending1.Rows(3).Cells(0).Value = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

                    GrdPending1.DataSource = dt1;
                    GrdPending1.DataBind();
                }
            }
            else
            {
                dt = Appobj.FillDt("Transfer To Commercial Invoice", Strtrantype, branchid);
                lngInv = dt.Rows.Count;
                //GrdPending1.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                dt = Appobj.FillDt("Transfer To Commercial PA", Strtrantype, branchid);
                lngPA = dt.Rows.Count;
                //GrdPending1.Rows(1).Cells(0).Value = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

                GrdPending1.DataSource = dt1;
                GrdPending1.DataBind();
            }
        }


        public void LoadPendingTDS()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            dt = leftObj.GetTDS4dash(branchid);
            GrdPendingTDS.Visible = true;
            PanelTDS.Visible = true;
            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                // dttemp.Columns.Add("jobno", typeof(string));
                dttemptds.Columns.Add("TDS", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemptds.NewRow();
                    // dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["TDS"] = dt.Rows[i][1].ToString() + " " + "(" + dt.Rows[i][0].ToString() + ")";
                    dttemptds.Rows.Add(dtrow);
                }
                //  popup_Grd.Show();
                GrdPendingTDS.DataSource = dttemptds;
                GrdPendingTDS.DataBind();
            }

            else
            {
                // popup_Grd.Hide();
                //GrdPendingTDS.DataSource = new DataTable();
                //GrdPendingTDS.DataBind();
                GrdPendingTDS.Visible = false;
            }
        }

        public void LoadPendingcrdappr()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            int branchid = int.Parse(Session["LoginBranchid"].ToString());
            dt = leftObj.Getcreditapp4dash(divisionid, branchid);


            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                // dttemp.Columns.Add("jobno", typeof(string));
                dttemp.Columns.Add("credit Approval Status", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp.NewRow();
                    // dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["Credit Approval Status"] = dt.Rows[i][1].ToString() + " " + " (" + dt.Rows[i][0].ToString() + ")";
                    dttemp.Rows.Add(dtrow);
                }
                GrdPendingcrdapp.Visible = true;
                Panelcrdappr.Visible = true;
                GrdPendingcrdapp.DataSource = dttemp;
                GrdPendingcrdapp.DataBind();
            }

            else
            {
                GrdPendingcrdapp.Visible = false;

                Panelcrdappr.Visible = false;
                GrdPendingcrdapp.DataSource = new DataTable();
                GrdPendingcrdapp.DataBind();
            }

        }


        public void ExpencesNotBooked()
        {


            int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            int logempid = Convert.ToInt16(Session["LoginEmpId"].ToString());
            Panel2.Visible = true;
            GrdExpense.Visible = true;
            DataTable dtexpnotbkd = new DataTable();
            dtexpnotbkd = MISObj.SelExpenceNotBkdnew();
            GrdExpense.DataSource = dtexpnotbkd;
            GrdExpense.DataBind();

        }
        public void DepositDetailsnew()
        {
            GridDepwise.Visible = true;
            Panel3.Visible = true;
            cid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dtDeposit = new DataTable();
            dtDeposit = objreceipt.Getdetails4branchfromDeposit4Newdash(branchid, obj_da_Log1.GetDate(), cid);
            GridDepwise.DataSource = dtDeposit;
            GridDepwise.DataBind();
        }







        public void loadgrd()
        {
            DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            string dtexdate = obj_da_Logobj.GetDate().ToString();
            //dt = exrobj.GetExRateDetails(dtexdate);
            dt = exrobj.GetExRateDetails(Convert.ToDateTime(dtexdate));
            if (dt.Rows.Count > 0)
            {
                Gridexrate.DataSource = dt;
                Gridexrate.DataBind();
            }
            else
            {
                Gridexrate.DataSource = dt;
                Gridexrate.DataBind();
            }
        }





        protected void grdpendinghbl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCustomer = (Label)e.Row.FindControl("cnt");
                string tooltip = lblCustomer.Text;
                e.Row.Cells[0].Attributes.Add("title", tooltip);

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }



        //public void UnclosedJobs()
        //{
        //    string Strtrantype = Session["StrTranType"].ToString();
        //    int intcount = 0;
        //    branchid = int.Parse(Session["LoginBranchid"].ToString());
        //    logempid = int.Parse(Session["LoginEmpId"].ToString());
        //    DataTable dt1 = new DataTable();
        //    dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("UnClosed Jobs") });
        //    Strtrantype = "FA";
        //    if (Strtrantype != "CH")
        //    {
        //        int necount = 0;
        //        if (Strtrantype == "AE")
        //        {
        //            dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
        //            necount = Convert.ToInt16(dt.Rows.Count);
        //            //grdunclosejobs.Rows(0).Cells(0).Value = "AE Jobs" + "(" + necount + ")";
        //            dt1.Rows.Add("AE Jobs" + "(" + necount + ")");
        //            grdunclosejobs.DataSource = dt1;
        //            grdunclosejobs.DataBind();
        //        }
        //        else if (Strtrantype == "AI")
        //        {
        //            dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
        //            necount = Convert.ToInt16(dt.Rows.Count);
        //            //grdunclosejobs.Rows(0).Cells(0).Value = "AI Jobs" + "(" + necount + ")"
        //            dt1.Rows.Add("AI Jobs" + "(" + necount + ")");
        //            grdunclosejobs.DataSource = dt1;
        //            grdunclosejobs.DataBind();
        //        }
        //        else if (Strtrantype == "FE")
        //        {
        //            dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
        //            necount = Convert.ToInt16(dt.Rows.Count);
        //            //grdunclosejobs.Rows(0).Cells(0).Value = "FE Jobs" + "(" + necount + ")"
        //            dt1.Rows.Add("OE Jobs" + "(" + necount + ")");
        //            grdunclosejobs.DataSource = dt1;
        //            grdunclosejobs.DataBind();
        //        }
        //        else if (Strtrantype == "FI")
        //        {
        //            dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
        //            necount = Convert.ToInt16(dt.Rows.Count);
        //            //grdunclosejobs.Rows(0).Cells(0).Value = "FI Jobs" + "(" + necount + ")"
        //            dt1.Rows.Add("OI Jobs" + "(" + necount + ")");
        //            grdunclosejobs.DataSource = dt1;
        //            grdunclosejobs.DataBind();
        //        }
        //        else if (Strtrantype == "CH")
        //        {
        //            dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
        //            necount = Convert.ToInt16(dt.Rows.Count);
        //            //grdunclosejobs.Rows(0).Cells(0).Value = "CH Jobs" + "(" + necount + ")"
        //            dt1.Rows.Add("CH Jobs" + "(" + necount + ")");
        //            grdunclosejobs.DataSource = dt1;
        //            grdunclosejobs.DataBind();
        //        }
        //        else if (Strtrantype == "FA")
        //        {
        //            int necount1 = 0, nicount1 = 0, fecount1 = 0, ficount1 = 0, chcount1 = 0;
        //            dt = Approveobj.GetPenUnClose("AC", branchid, 0, logempid);
        //            for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //            {
        //                if (dt.Rows[i]["trantype"].ToString() == "AE") { necount1 = necount1 + 1; }
        //                if (dt.Rows[i]["trantype"].ToString() == "AI") { nicount1 = nicount1 + 1; }
        //                if (dt.Rows[i]["trantype"].ToString() == "FE") { fecount1 = fecount1 + 1; }
        //                if (dt.Rows[i]["trantype"].ToString() == "FI") { ficount1 = ficount1 + 1; }
        //                if (dt.Rows[i]["trantype"].ToString() == "CH") { chcount1 = chcount1 + 1; }
        //            }
        //            //grdunclosejobs.Rows(0).Cells(0).Value = "AE Jobs" + "(" + necount1 + ")"
        //            dt1.Rows.Add("AE Jobs" + "(" + necount1 + ")");
        //            //grdunclosejobs.Rows(1).Cells(0).Value = "AI Jobs" + "(" + nicount1 + ")"
        //            dt1.Rows.Add("AI Jobs" + "(" + nicount1 + ")");
        //            //grdunclosejobs.Rows(2).Cells(0).Value = "FE Jobs" + "(" + fecount1 + ")"
        //            dt1.Rows.Add("FE Jobs" + "(" + fecount1 + ")");
        //            //grdunclosejobs.Rows(3).Cells(0).Value = "FI Jobs" + "(" + ficount1 + ")"
        //            dt1.Rows.Add("FI Jobs" + "(" + ficount1 + ")");
        //            //grdunclosejobs.Rows(4).Cells(0).Value = "CH Jobs" + "(" + chcount1 + ")"
        //            dt1.Rows.Add("CH Jobs" + "(" + chcount1 + ")");
        //            grdunclosejobs.DataSource = dt1;
        //            grdunclosejobs.DataBind();
        //        }
        //        else if (Strtrantype == "AC")
        //        {
        //            int necount1 = 0, nicount1 = 0, fecount1 = 0, ficount1 = 0, chcount1 = 0;
        //            dt = Approveobj.GetPenUnClose("AC", branchid, 0, logempid);
        //            hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
        //            for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //            {
        //                if (dt.Rows[i]["trantype"].ToString() == "AE") { necount1 = necount1 + 1; }
        //                if (dt.Rows[i]["trantype"].ToString() == "AI") { nicount1 = nicount1 + 1; }
        //                if (dt.Rows[i]["trantype"].ToString() == "FE") { fecount1 = fecount1 + 1; }
        //                if (dt.Rows[i]["trantype"].ToString() == "FI") { ficount1 = ficount1 + 1; }
        //                if (dt.Rows[i]["trantype"].ToString() == "CH") { chcount1 = chcount1 + 1; }
        //            }
        //            //grdunclosejobs.Rows(0).Cells(0).Value = "AE Jobs" + "(" + necount1 + ")"
        //            dt1.Rows.Add("AE Jobs" + "(" + necount1 + ")");
        //            //grdunclosejobs.Rows(1).Cells(0).Value = "AI Jobs" + "(" + nicount1 + ")"
        //            dt1.Rows.Add("AI Jobs" + "(" + nicount1 + ")");
        //            //grdunclosejobs.Rows(2).Cells(0).Value = "FE Jobs" + "(" + fecount1 + ")"
        //            dt1.Rows.Add("FE Jobs" + "(" + fecount1 + ")");
        //            //grdunclosejobs.Rows(3).Cells(0).Value = "FI Jobs" + "(" + ficount1 + ")"
        //            dt1.Rows.Add("FI Jobs" + "(" + ficount1 + ")");
        //            //grdunclosejobs.Rows(4).Cells(0).Value = "CH Jobs" + "(" + chcount1 + ")"
        //            dt1.Rows.Add("CH Jobs" + "(" + chcount1 + ")");
        //            grdunclosejobs.DataSource = dt1;
        //            grdunclosejobs.DataBind();
        //        }
        //    }
        //}

        protected void grdunclosejobs_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Right";
                }

                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
              
                if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdunclosejobs, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }


        protected void grdunclosejobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string name = "";
            visible_false();
            _Pend_UN.Visible = true;
            div_UnClos.Visible = true;
            Panel13.Visible = true;
            Panel_unc.Visible = true;
            grd_UNC.Visible = true;
            index = grdunclosejobs.SelectedRow.RowIndex;
            name = grdunclosejobs.Rows[index].Cells[0].Text;
            if (name == "OE")
            {
                name = "FE";
            }
            else if (name == "OI")
            {
                name = "FI";
            }
            string Strtrantype = Session["StrTranType"].ToString();
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            DataTable dt1 = new DataTable();
            dt = Approveobj.GetPenUnCloseForNew(name, branchid, int.Parse(Session["LoginDivisionId"].ToString()), logempid);
            if (name == "FE")
            {
                div_unClos_new.InnerText = "Ocean Exports";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                dtemptyfree.Columns.Add("Vessel & Voyage");

                dtemptyfree.Columns.Add("ETD");
                dtemptyfree.Columns.Add("MBL #");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["Vessel & Voyage"] = dt.Rows[j]["vslvoy"].ToString();
                        dtemptyfree.Rows[j]["ETD"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["etd"].ToString()).ToShortDateString()).ToString();

                        dtemptyfree.Rows[j]["MBL #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                    
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }
            else if (name == "FI")
            {
                div_unClos_new.InnerText = "Ocean Imports";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                dtemptyfree.Columns.Add("Vessel & Voyage");
                dtemptyfree.Columns.Add("ETA");
                dtemptyfree.Columns.Add("MBL #");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["Vessel & Voyage"] = dt.Rows[j]["vslvoy"].ToString();
                        dtemptyfree.Rows[j]["ETA"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["eta"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["MBL #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }

            else if (name == "AE")
            {
                div_unClos_new.InnerText = "Air Exports";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                //dtemptyfree.Columns.Add("Vsl&Voy");
                dtemptyfree.Columns.Add("Flight Date");
                dtemptyfree.Columns.Add("MAWB #");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();
                        // dtemptyfree.Rows[j]["Vsl&Voy"] = dt.Rows[j]["vslvoy"].ToString();
                        dtemptyfree.Rows[j]["Flight Date"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["eta"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["MAWB #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }
            else if (name == "AI")
            {
                div_unClos_new.InnerText = "Air Imports";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                //dtemptyfree.Columns.Add("Vsl&Voy");
                dtemptyfree.Columns.Add("Flight Date");
                dtemptyfree.Columns.Add("MAWB #");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();
                        // dtemptyfree.Rows[j]["Vsl&Voy"] = dt.Rows[j]["vslvoy"].ToString();
                        dtemptyfree.Rows[j]["Flight Date"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["eta"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["MAWB #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }
            else if (name == "CH")
            {
                div_unClos_new.InnerText = "CHA";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                //dtemptyfree.Columns.Add("Vsl&Voy");               
                dtemptyfree.Columns.Add("Doc #");
                dtemptyfree.Columns.Add("Doc Date");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();
                        // dtemptyfree.Rows[j]["Vsl&Voy"] = dt.Rows[j]["vslvoy"].ToString();                       
                        dtemptyfree.Rows[j]["Doc #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Doc Date"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["eta"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }
          
            //int index;
            //string name;
            //string Strtrantype = Session["StrTranType"].ToString();
            //string str_sp = "";
            //string str_sf = "";
            //string str_RptName = "";
            //string str_Script = "";
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";
            //branchid = int.Parse(Session["LoginBranchid"].ToString());
            //logempid = int.Parse(Session["LoginEmpId"].ToString());
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            //if (grdunclosejobs.Rows.Count > 0)
            //{
            //    index = grdunclosejobs.SelectedRow.RowIndex;
            //    name = grdunclosejobs.Rows[index].Cells[0].Text;
            //    if (name == "OE")
            //    {
            //        name = "FE";
            //    }
            //    else if (name == "OI")
            //    {
            //        name = "FI";
            //    }
            //    if (Strtrantype == "FA")
            //    {
            //        Session["str_sfs"] = "{tmpunclsjob.empid}=" + logempid + " and {tmpunclsjob.branchid}=" + branchid + " and {tmpunclsjob.trantype}= '" + name.Substring(0, 2) + "'";
            //        //   str_sf = "{tmpunclsjob.empid}=" + logempid + " and {tmpunclsjob.branchid}=" + branchid + " and {tmpunclsjob.trantype}= " + name.Substring(0, 2) + "";
            //        str_sp = "";
            //        Session["str_sp"] = str_sp;
            //    }
            //    else
            //    {
            //        Session["str_sfs"] = "{tmpunclsjob.empid}=" + logempid + " and {tmpunclsjob.branchid}=" + branchid;
            //        //    str_sf = "{tmpunclsjob.empid}=" + logempid + " and {tmpunclsjob.branchid}=" + branchid;
            //        str_sp = "";
            //        Session["str_sp"] = str_sp;
            //    }
            //    str_RptName = "UnClosedBranch.rpt";
            //    if (name.Substring(0, 2) == "AE")
            //    {
            //        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //        ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
            //    }
            //    else if (name.Substring(0, 2) == "AI")
            //    {
            //        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //        ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
            //    }
            //    else if (name.Substring(0, 2) == "FE")
            //    {
            //        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //        ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
            //    }
            //    else if (name.Substring(0, 2) == "FI")
            //    {
            //        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //        ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
            //    }
            //    else if (name.Substring(0, 2) == "CH")
            //    {
            //        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            //        ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
            //    }

            //}
        }
        protected void lnk_unclosedjobs_Click(object sender, EventArgs e)
        {

            UnclosedJobs1();
            grdunclosejobs.Visible = true;
            PanelUnclosedjob.Visible = true;
            ModalPopupExtender4.Show();
        }
        protected void lnk_PendingApproval_Click(object sender, EventArgs e)
        {
            //GrdDisable1();
            PendingApprovalFE();
            ModalPopupExtender5.Show();

        }

        protected void GrdPending1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPending1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void GrdPending1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string vouname;
            string Strtrantype = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (GrdPending1.Rows.Count > 0)
            {
                index = GrdPending1.SelectedRow.RowIndex;
                vouname = GrdPending1.Rows[index].Cells[0].Text;
                if (vouname != "")
                {
                    if (Strtrantype != "FA" && Strtrantype != "CRM")
                    {
                        if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Quotation")
                        {
                            str_RptName = "PendingQuotation.rpt";
                            Session["str_sfs"] = "{QuotationHead.trantype}='" + Strtrantype + "' and {QuotationHead.validtill}>=CurrentDateTime and {QuotationHead.approvedby}=0 and {QuotationHead.bid}=" + branchid;
                            //str_sf = "{QuotationHead.trantype}=" + Strtrantype + " and {QuotationHead.validtill}>=CurrentDateTime and {QuotationHead.approvedby}=0 and {QuotationHead.bid}=" + branchid;
                            str_sp = "";//"Head=Invoice Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Invoice", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Invoices")
                        {
                            str_RptName = "ProInvPendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and {ACProInvoiceHead.trantype}='" + Strtrantype + "' and {ACProInvoiceHead.deleted}='N'";
                            //str_sf = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and {ACProInvoiceHead.trantype}=" + Strtrantype + " and {ACProInvoiceHead.deleted}=N";
                            str_sp = "Title=Profoma Invoice Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Invoice", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro CN Operations")
                        {
                            str_RptName = "Pro PA PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + "and {ACProPAHead.deleted}='N'";
                            // str_sf = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and {ACProPAHead.trantype}=" + Strtrantype + " and {ACProPAHead.deleted}=N";
                            str_sp = "Title=Profoma Credit Note - Operations Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Payment Advise", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Debit Notes")
                        {
                            str_RptName = "Pro OSDN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0 and {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}='N'";
                            //  str_sf = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and {AcOSDNPro.trantype}=" + Strtrantype + " and {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}=N";
                            str_sp = "Title=Profoma OSDN Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "OSSI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Credit Notes")
                        {
                            str_RptName = "Pro OSCN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0 and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}='N'";
                            // str_sf = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.trantype}=" + Strtrantype + " and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}=N";
                            str_sp = "Title=Profoma OSCN Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "OSPI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other DN")
                        {
                            str_RptName = "Pro OtherDN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0 and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}='N'";
                            //  str_sf = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0  and {ACProDNHead.trantype}=" + Strtrantype + " and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}=N";
                            str_sp = "Title=Profoma Debit Notes Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Debit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other CN")
                        {
                            str_RptName = "Pro OtherCN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0 and {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}='N'";
                            // str_sf = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and {ACPRoCNHead.trantype}=" + Strtrantype + " and {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}=N";
                            str_sp = "Title=Profoma Credit Notes Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Credit Notes", str_Script, true);
                        }
                    }
                    else
                    {
                        if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Quotation")
                        {
                            str_RptName = "PendingQuotation.rpt";
                            Session["str_sfs"] = "{QuotationHead.approvedby}=0 and {QuotationHead.validtill}>=date('" + logobj.GetDate() + "')";
                            // str_sf = "{QuotationHead.approvedby}=0 and {QuotationHead.validtill}>=date(" + logobj.GetDate() + ")";
                            str_sp = "";//"Head^Invoice Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Invoice", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Invoices")
                        {
                            str_RptName = "ProInvPendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and  {ACProInvoiceHead.deleted}='N'";
                            //   str_sf = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and  {ACProInvoiceHead.deleted}=N";
                            str_sp = "Title=Profoma Invoice Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Invoice", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro CN Operations")
                        {
                            str_RptName = "Pro PA PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and  {ACProPAHead.deleted}='N'";
                            //str_sf = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and  {ACProPAHead.deleted}=N";
                            str_sp = "Title=Profoma Credit Note - Operations Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Payment Advise", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Debit Notes")
                        {
                            str_RptName = "Pro OSDN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and  {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}='N'";
                            // str_sf = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and  {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}=N";
                            str_sp = "Title=Profoma OSDN Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "OSSI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Credit Notes")
                        {
                            str_RptName = "Pro OSCN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}='N'";
                            //str_sf = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}=N";
                            str_sp = "Title=Profoma OSCN Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "OSPI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other DN")
                        {
                            str_RptName = "Pro OtherDN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0  and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}='N'";
                            // str_sf = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0   and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}=N";
                            str_sp = "Title=Profoma Debit Notes Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Debit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other CN")
                        {
                            str_RptName = "Pro OtherCN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and  {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}='N'";
                            //  str_sf = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and  {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}=N";
                            str_sp = "Title=Profoma Credit Notes Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Credit Notes", str_Script, true);
                        }
                    }
                }
            }
        }



        protected void lnk_PendingTDS_Click(object sender, EventArgs e)
        {

            LoadPendingTDS();
            PanelTDS.Visible = true;
            GrdPendingTDS.Visible = true;
            ModalPopupExtender1.Show();

        }


        protected void lnk_PendingFA_Click(object sender, EventArgs e)
        {
            LoadPendingFA();
            GrdPendingFA.Visible = true;
            PanelFA.Visible = true;
            ModalPopupExtender2.Show();

        }
        public void LoadPendingFA()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            dt = leftObj.GetCount4Fa(branchid);
            //   pop_cangrd.Show();
            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                //   dttemp.Columns.Add("FA", typeof(string));
                dttempfa.Columns.Add("FA Transfer", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttempfa.NewRow();
                    // dtrow["FA"] = dt.Rows[i][1].ToString();
                    dtrow["FA Transfer"] = dt.Rows[i][1].ToString() + "" + "  (" + dt.Rows[i][0].ToString() + ")";
                    dttempfa.Rows.Add(dtrow);
                }

                GrdPendingFA.Visible = true;
                PanelFA.Visible = true;
                GrdPendingFA.DataSource = dttempfa;
                GrdPendingFA.DataBind();
            }

            else
            {
                GrdPendingFA.Visible = false;
                //GrdPendingFA.DataSource = new DataTable();
                //GrdPendingFA.DataBind();
            }
        }

        protected void GrdPendingFA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPendingFA, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void GrdPendingFA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string vouname;
            string Strtrantype = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (GrdPendingFA.Rows.Count > 0)
            {
                index = GrdPendingFA.SelectedRow.RowIndex;
                vouname = GrdPendingFA.Rows[index].Cells[0].Text;
                if (vouname != "")
                {
                    if (Strtrantype != "FA" && Strtrantype != "CRM")
                    {
                        string vonnmae1 = vouname.Substring(0, vouname.IndexOf(" (") - 1);
                        if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Invoice")
                        {
                            str_RptName = "PendingInv.rpt";
                            Session["str_sfs"] = "{InvoiceHead.branchid}=" + branchid + " and isNULL({InvoiceHead.fatransfer}) and {InvoiceHead.approvedby} <> 0 and {InvoiceHead.deleted} = 'N' ";
                            //str_sf = "{InvoiceHead.branchid}=" + branchid + " and isNULL({InvoiceHead.fatransfer}) and {InvoiceHead.approvedby} <> 0 and {InvoiceHead.deleted} = 'N' ";
                            //Session["str_sfs"]="isNULL({InvoiceHead.fatransfer}) and {InvoiceHead.approvedby} <> 0 and {InvoiceHead.deleted} = 'N' ";
                            //str_sf = "isNULL({InvoiceHead.fatransfer}) and {InvoiceHead.approvedby} <> 0 and {InvoiceHead.deleted} = 'N' ";
                            str_sp = "Head=Invoice Pending Fatransfer";//"Head=Invoice Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPendingFA, typeof(GridView), "Invoice", str_Script, true);
                            //Session["str_sfs"] = str_sf;
                            //Session["str_sp"] = str_sp;

                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "CN Operations")
                        {
                            str_RptName = "PendingPA.rpt";
                            Session["str_sfs"] = "{PAHead.branchid}=" + branchid + " and isNull({PAHead.fatransfer}) and {PAHead.approvedby} <> 0 and {PAHead.deleted} = 'N'";
                            // str_sf = "{PAHead.branchid}=" + branchid + " and isNull({PAHead.fatransfer}) and {PAHead.approvedby} <> 0 and {PAHead.deleted} = 'N'";
                            str_sp = "Head=Pending Credit Note Operations Fatransfer";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPendingFA, typeof(GridView), "Invoice", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;

                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "OSSI")
                        {
                            str_RptName = "PendingOSDN.rpt";
                            Session["str_sfs"] = "{Osdn.branchid}=" + branchid + " and isNull({Osdn.fatransfer}) and {Osdn.approvedby} <> 0 and {Osdn.deleted} = 'N'";
                            // str_sf = "{Osdn.branchid}=" + branchid + " and isNull({Osdn.fatransfer}) and {Osdn.approvedby} <> 0 and {Osdn.deleted} = 'N'";
                            str_sp = "Head=Pending OSDN Fatransfer";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPendingFA, typeof(GridView), "Payment Advise", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "OSPI")
                        {
                            str_RptName = "PendingOSCN.rpt";
                            Session["str_sfs"] = "{oscn.branchid}=" + branchid + " and isNull({oscn.fatransfer}) and {Oscn.approvedby} <> 0 and {Oscn.deleted} = 'N'";
                            //  str_sf = "{oscn.branchid}=" + branchid + " and isNull({oscn.fatransfer}) and {Oscn.approvedby} <> 0 and {Oscn.deleted} = 'N'";
                            str_sp = "Head=Pending OSCN Fatransfer";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "OSSI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "DN")
                        {
                            str_RptName = "OthDNRegister.rpt";
                            Session["str_sfs"] = "{Dnhead.branchid}=" + branchid + " and isNull({Dnhead.fatransfer}) and {DnHead.approvedby} <> 0 and {DnHead.deleted} = 'N'";
                            //  str_sf = "{Dnhead.branchid}=" + branchid + " and isNull({Dnhead.fatransfer}) and {DnHead.approvedby} <> 0 and {DnHead.deleted} = 'N'";
                            str_sp = "Title=Pending Other DN Fatransfer";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "OSPI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "CN")
                        {
                            str_RptName = "OthCNRegister.rpt";
                            Session["str_sfs"] = "{CNhead.branchid}=" + branchid + " and isNull({CNhead.fatransfer}) and {CNHead.approvedby} <> 0 and {CNHead.deleted} = 'N'";
                            //    str_sf = "{CNhead.branchid}=" + branchid + " and isNull({CNhead.fatransfer}) and {CNHead.approvedby} <> 0 and {CNHead.deleted} = 'N'";
                            str_sp = "Title=Pending Other CN Fatransfer";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "Debit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Admin DN")
                        {
                            str_RptName = "AdmDebitRegister.rpt";
                            Session["str_sfs"] = "{AdmDNHead.branchid}=" + branchid + " and isNull({AdmDNHead.fatransfer}) and {AdmDNHead.approvedby} <> 0 and {AdmDNHead.deleted} = 'N'";
                            // str_sf = "{AdmDNHead.branchid}=" + branchid + " and isNull({AdmDNHead.fatransfer}) and {AdmDNHead.approvedby} <> 0 and {AdmDNHead.deleted} = 'N'";
                            str_sp = "Title=Pending DN - Admin  Fatransfer";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "Credit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Admin CN")
                        {
                            str_RptName = "AdmCreditRegister.rpt";
                            Session["str_sfs"] = "{AdmCNHead.branchid}=" + branchid + " and isNull({AdmCNHead.fatransfer}) and {AdmCNHead.approvedby} <> 0 and {AdmCNHead.deleted} = 'N'";
                            // str_sf = "{AdmCNHead.branchid}=" + branchid + " and isNull({AdmCNHead.fatransfer}) and {AdmCNHead.approvedby} <> 0 and {AdmCNHead.deleted} = 'N'";
                            str_sp = "Title=Pending  CN - Admin Fatransfer";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "Credit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Receipt Cash")
                        {
                            str_RptName = "ReceiptCashReg.rpt";
                            Session["str_sfs"] = "{receipthead.mode}= 'C'  and {receipthead.branchid}=" + branchid + " and isNull({receipthead.fatransfer}) and {ReceiptHead.approvedby} <> 0 and {ReceiptHead.deleted} = 0";
                            //  str_sf = "{receipthead.mode}= 'C'  and {receipthead.branchid}=" + branchid + " and isNull({receipthead.fatransfer}) and {ReceiptHead.approvedby} <> 0 and {ReceiptHead.deleted} = 0";
                            str_sp = "";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "Credit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Receipt Bank")
                        {
                            str_RptName = "ReceiptBankReg.rpt";
                            Session["str_sfs"] = "{receipthead.mode}= 'B'  and {receipthead.branchid}=" + branchid + " and isNull({receipthead.fatransfer}) and {ReceiptHead.approvedby} <> 0 and {ReceiptHead.deleted} = 0";
                            //  str_sf = "{receipthead.mode}= 'B'  and {receipthead.branchid}=" + branchid + " and isNull({receipthead.fatransfer}) and {ReceiptHead.approvedby} <> 0 and {ReceiptHead.deleted} = 0";
                            str_sp = "";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "Credit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Payment Cash")
                        {
                            str_RptName = "PaymentCashReg.rpt";
                            Session["str_sfs"] = "{Paymenthead.mode}= 'C'  and {Paymenthead.branchid}=" + branchid + " and isNull({Paymenthead.fatransfer}) and {PaymentHead.approvedby} <> 0 and {PaymentHead.deleted} = 0";
                            // str_sf = "{Paymenthead.mode}= 'C'  and {Paymenthead.branchid}=" + branchid + " and isNull({Paymenthead.fatransfer}) and {PaymentHead.approvedby} <> 0 and {PaymentHead.deleted} = 0";
                            str_sp = "Title=Pending Payment Cash Fatransfer";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "Credit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Payment Bank")
                        {
                            str_RptName = "PaymentBankReg.rpt";
                            Session["str_sfs"] = "{Paymenthead.mode}= 'B'  and {Paymenthead.branchid}=" + branchid + " and isNull({Paymenthead.fatransfer}) and {PaymentHead.approvedby} <> 0 and {PaymentHead.deleted} = 0";
                            //  str_sf = "{Paymenthead.mode}= 'B'  and {Paymenthead.branchid}=" + branchid + " and isNull({Paymenthead.fatransfer}) and {PaymentHead.approvedby} <> 0 and {PaymentHead.deleted} = 0";
                            str_sp = "";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(GridView), "Credit Notes", str_Script, true);
                        }
                    }

                }
            }
        }

        protected void lnk_PendingDep_Click(object sender, EventArgs e)
        {

            LoadPendingDep();
            GrdPendingDep.Visible = true;
            PanelDep.Visible = true;
            ModalPopupExtender3.Show();
        }
        public void LoadPendingDep()
        {
            GrdPendingDep.Visible = true;
            PanelDep.Visible = true;
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            dt = leftObj.GetDeposit4dash(branchid);
            //pop_lineGrd.Show();
            if (dt.Rows.Count > 0)
            {
                GrdPendingDep.DataSource = dt;
                GrdPendingDep.DataBind();
            }
            else
            {
                GrdPendingDep.DataSource = new DataTable();
                GrdPendingDep.DataBind();
            }
        }
        protected void GrdPendingDep_RowDataBound(object sender, GridViewRowEventArgs e)
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




                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPendingDep, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";





            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double dbl_temp = 0;
                for (int h = 0; h < e.Row.Cells.Count; h++)
                {
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;
                        if (h == 2)
                        {
                            e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                        }

                    }
                }

            }



        }


        public void Grdincomnotbooked()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            int logempid = Convert.ToInt16(Session["LoginEmpId"].ToString());
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            MISObj.SelIncomeNotBkd(branchid, divisionid, logempid);
            Panel1.Visible = true;
            DataTable dtnotbkd = new DataTable();
            dtnotbkd = MISObj.SelIncomeNotBkdnew();
            GridView1.DataSource = dtnotbkd;
            GridView1.DataBind();

        }

        protected void Excelfunforserver_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        protected void pdffunforserver_Click(object sender, EventArgs e)
        {
            ExportToPdf();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        private void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringWriter StringWriter = new System.IO.StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            GridView1.AllowPaging = false;
            Grdincomnotbooked();


            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(HtmlTextWriter);
            Response.Write(StringWriter.ToString());
            Response.End();
        }
        private void ExportToPdf()
        {

            DataTable dt = new DataTable();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            Grdincomnotbooked();
            signup.Visible = true;



            GridView1.RenderControl(hw);
            GridView1.HeaderRow.Style.Add("width", "5%");
            GridView1.HeaderRow.Style.Add("font-size", "10px");
            GridView1.Style.Add("text-decoration", "none");
            GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            GridView1.Style.Add("font-size", "8pt");
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }


        protected void btn_Get_Click(object sender, EventArgs e)
        {
            string vou;
            string trantype = "";
            double amount;
            Paneljobcostingframe.Visible = true;
            Gridjobcost.Visible = true;
            Paneljobcost.Visible = true;
            lbl1.Enabled = true;
            txt_job.Visible = true;
            ddl_product.Visible = true;

            DataAccess.CostingDetails costObj = new DataAccess.CostingDetails();
            int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            int logempid = Convert.ToInt16(Session["LoginEmpId"].ToString());
            string product = ddl_product.SelectedItem.Text.ToString();
            int vouyear = int.Parse(Session["Vouyear"].ToString());
            if (ddl_product.Text != "")
            {
                if (txt_job.Text != "")
                {
                    switch (product)
                    {
                        case "Ocean Exports":
                            {
                                trantype = "FE";
                                break;
                            }
                        case "Ocean Imports":
                            {
                                trantype = "FE";
                                break;
                            }
                        case "Air Exports":
                            {
                                trantype = "AE";
                                break;
                            }
                        case "Air Imports":
                            {
                                trantype = "AI";
                                break;
                            }
                        case "Custom House Agent":
                            {
                                trantype = "CH";
                                break;
                            }
                    }

                    dt = costObj.CostingDetail(Convert.ToInt32(txt_job.Text), trantype, branchid, vouyear);
                    if (dt.Rows.Count > 0)
                    {
                        dttemp.Columns.Add("Vou #");
                        dttemp.Columns.Add("vouyear");
                        dttemp.Columns.Add("Amount");
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dtrow = dttemp.NewRow();
                        dttemp.Rows.Add(dtrow);
                        if (dt.Rows[i][5].ToString() == "Invoice")
                        {
                            vou = "IN";
                        }
                        else if (dt.Rows[i][5].ToString() == "PA")
                        {
                            vou = "PA";
                        }
                        else if (dt.Rows[i][5].ToString() == "OSSI")
                        {
                            vou = "OD";
                        }
                        else if (dt.Rows[i][5].ToString() == "OSPI")
                        {
                            vou = "OC";
                        }
                        else if (dt.Rows[i][5].ToString() == "DN")
                        {
                            vou = "DN";
                        }
                        else if (dt.Rows[i][5].ToString() == "CN")
                        {
                            vou = "CN";
                        }
                        else
                        {
                            vou = "Income";
                        }

                        if (vou != "Income")
                        {
                            int invo = Convert.ToInt16(dt.Rows[i][0].ToString());
                            dtrow["Vou #"] = vou + " " + " -" + invo;

                        }
                        else
                        {
                            if (dt.Rows[i][2].ToString() == "Income Total")
                            {
                                dtrow["Vou #"] = "Income";
                            }
                            else if (dt.Rows[i][2].ToString() == "Expenses Total")
                            {
                                dtrow["Vou #"] = "Expense";
                            }
                            else
                            {
                                dtrow["Vou #"] = dt.Rows[i][2].ToString();
                            }

                        }
                        amount = Convert.ToDouble(dt.Rows[i][3].ToString());
                        dtrow["Amount"] = Convert.ToString(amount);
                        dtrow["vouyear"] = vouyear;
                    }


                    Paneljobcost.Visible = true;
                    Gridjobcost.DataSource = dttemp;
                    Gridjobcost.DataBind();
                    if (Gridjobcost.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttemp.Rows.Count; i++)
                        {
                            if (dttemp.Rows[i][0].ToString() == "Income")
                            {

                                Gridjobcost.Rows[i].Cells[0].ForeColor = System.Drawing.Color.Red;
                                Gridjobcost.Rows[i].Cells[1].ForeColor = System.Drawing.Color.Red;

                            }
                            else if (dttemp.Rows[i][0].ToString() == "Expense")
                            {
                                Gridjobcost.Rows[i].Cells[0].ForeColor = System.Drawing.Color.Red;
                                Gridjobcost.Rows[i].Cells[1].ForeColor = System.Drawing.Color.Red;

                            }
                            else if (dttemp.Rows[i][0].ToString() == "Loss")
                            {
                                Gridjobcost.Rows[i].Cells[0].ForeColor = System.Drawing.Color.Maroon;
                                Gridjobcost.Rows[i].Cells[1].ForeColor = System.Drawing.Color.Maroon;

                            }
                            else if (dttemp.Rows[i][0].ToString() == "Profit")
                            {
                                Gridjobcost.Rows[i].Cells[0].ForeColor = System.Drawing.Color.Maroon;
                                Gridjobcost.Rows[i].Cells[1].ForeColor = System.Drawing.Color.Maroon;

                            }
                        }

                    }

                }
            }



        }



        protected void GrdPendingcrdapp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPendingcrdapp, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdPendingcrdapp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string vouname;
            string Strtrantype = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (GrdPendingcrdapp.Rows.Count > 0)
            {
                index = GrdPendingcrdapp.SelectedRow.RowIndex;
                vouname = GrdPendingcrdapp.Rows[index].Cells[0].Text;
                if (vouname != "")
                {
                    if (Strtrantype != "FA" && Strtrantype != "CRM")
                    {
                        string vonnmae1 = vouname.Substring(0, vouname.IndexOf(" (") - 1);
                        if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Approved")
                        {
                            str_RptName = "MasterCreditApproval.rpt";
                            Session["str_sfs"] = "{MasterCreditApproval.owner}=" + branchid + " and Not isNull({Mastercreditapproval.appby})";
                            str_sf = "{MasterCreditApproval.owner}=" + branchid + " and Not isNull({Mastercreditapproval.appby})";
                            //Session["str_sfs"]="isNULL({InvoiceHead.fatransfer}) and {InvoiceHead.approvedby} <> 0 and {InvoiceHead.deleted} = 'N' ";
                            //str_sf = "isNULL({InvoiceHead.fatransfer}) and {InvoiceHead.approvedby} <> 0 and {InvoiceHead.deleted} = 'N' ";
                            str_sp = "title=APPROVED CREDIT CUSTOMER LIST";//"Head=Invoice Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPendingcrdapp, typeof(GridView), "Approved", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Unapproved")
                        {
                            str_RptName = "MasterCreditApproval.rpt";
                            Session["str_sfs"] = "{Mastercreditapproval.owner}=" + branchid + " and isNull({Mastercreditapproval.appby})";
                            str_sf = "{Mastercreditapproval.owner}=" + branchid + " and isNull({Mastercreditapproval.appby})";
                            //Session["str_sfs"]="isNULL({InvoiceHead.fatransfer}) and {InvoiceHead.approvedby} <> 0 and {InvoiceHead.deleted} = 'N' ";
                            //str_sf = "isNULL({InvoiceHead.fatransfer}) and {InvoiceHead.approvedby} <> 0 and {InvoiceHead.deleted} = 'N' ";
                            str_sp = "title=UNAPPROVAL CREDIT CUSTOMER LIST";//"Head=Invoice Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPendingcrdapp, typeof(GridView), "Unapproved", str_Script, true);
                        }
                    }

                }
            }
        }

        public void GrdExpensenotbooked()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            int logempid = Convert.ToInt16(Session["LoginEmpId"].ToString());
            if (Session["LoginUserName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            DataTable dtexpnotbkd = new DataTable();
            dtexpnotbkd = MISObj.SelExpenceNotBkdnew();
            GrdExpense.DataSource = dtexpnotbkd;
            GrdExpense.DataBind();

        }

        protected void Linkexpense_Click(object sender, EventArgs e)
        {

            ExpencesNotBooked();
            Panel2.Visible = true;
            GrdExpense.Visible = true;
            ModalPopupExtender6.Show();

        }

        public void BranchDSO()
        {

            int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            int logempid = Convert.ToInt16(Session["LoginEmpId"].ToString());

            int dtbranchdso;
            dtbranchdso = branchobj.BranchDSO(branchid, divisionid);
            lbldso.Text = dtbranchdso.ToString();


        }



        public void totaloutstandingamount()
        {
            int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
            DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
            DataTable dtable = new DataTable();
            time1 = da_obj_Log.GetDate().Hour;

            if (time1 < 13)
            {
                dtable = outsobj.OutStdingGET(99999, Convert.ToInt16(Session["LoginDivisionId"].ToString()), 40);
                Session["Data"] = dtable;
                totalbranchoutsatanding();
            }
            else if (time1 >= 13 && time1 < 16)
            {
                dtable = outsobj.OutStdingGET12N(99999, Convert.ToInt16(Session["LoginDivisionId"].ToString()), 40);
                Session["Data"] = dtable;
                totalbranchoutsatanding();
            }
            else if (time1 >= 16 && time1 < 23)
            {
                dtable = outsobj.OutStdingGET3PM(99999, Convert.ToInt16(Session["LoginDivisionId"].ToString()), 40);
                Session["Data"] = dtable;
                totalbranchoutsatanding();
            }
        }

        public void totalbranchoutsatanding()
        {
            DataTable dtab = new DataTable();
            DataView dv;
            DataTable dtt;
            string str_SelFormula = "", ddlbranch = "";
            dtab = (DataTable)Session["Data"];
            dv = new DataView(dtab);
            dtt = new DataTable();
            string[] a = new string[2];
            a[0] = "shortname";
            a[1] = "bid";
            dtt = dv.ToTable("name", true, a);
            for (int i = 0; i < dtt.Rows.Count - 1; i++)
            {
                if (Convert.ToInt16(Session["LoginBranchid"].ToString()) == Convert.ToInt16(dtt.Rows[i]["bid"].ToString()))
                {
                    DataView dt_ldg = new DataView(dtab);
                    ddlbranch = dtt.Rows[i]["shortname"].ToString();
                    str_SelFormula = "shortname =  '" + ddlbranch + "'";
                    if (str_SelFormula != "")
                    {
                        dt_ldg.RowFilter = str_SelFormula;
                    }
                    else
                    {

                    }
                    DataTable dt2 = new DataTable();
                    dt2 = dt_ldg.ToTable();
                    lbltotalos.Text = dt2.Compute("sum(amount)", "").ToString();
                }
            }
        }





        public void totaloverdueamount()
        {
            int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
            DataAccess.LogDetails da_obj_Log = new DataAccess.LogDetails();
            DataTable dtable = new DataTable();
            time1 = da_obj_Log.GetDate().Hour;

            if (time1 < 13)
            {
                dtable = outsobj.OutStdingGET(99999, Convert.ToInt16(Session["LoginDivisionId"].ToString()), 40);
                Session["Data"] = dtable;
                totalbranchoverdue();

            }
            else if (time1 >= 13 && time1 < 16)
            {
                dtable = outsobj.OutStdingGET12N(99999, Convert.ToInt16(Session["LoginDivisionId"].ToString()), 40);
                Session["Data"] = dtable;
                totalbranchoverdue();
            }
            else if (time1 >= 16 && time1 < 23)
            {
                dtable = outsobj.OutStdingGET3PM(99999, Convert.ToInt16(Session["LoginDivisionId"].ToString()), 40);
                Session["Data"] = dtable;
                totalbranchoverdue();
            }
        }



        public void totalbranchoverdue()
        {
            DataTable dtab = new DataTable();
            DataView dv;
            DataTable dtt;
            string str_SelFormula = "", ddlbranch = "";
            dtab = (DataTable)Session["Data"];
            dv = new DataView(dtab);
            dtt = new DataTable();
            string[] a = new string[2];
            a[0] = "shortname";
            a[1] = "bid";
            dtt = dv.ToTable("name", true, a);
            for (int i = 0; i < dtt.Rows.Count - 1; i++)
            {
                if (Convert.ToInt16(Session["LoginBranchid"].ToString()) == Convert.ToInt16(dtt.Rows[i]["bid"].ToString()))
                {
                    DataView dt_ldg = new DataView(dtab);
                    ddlbranch = dtt.Rows[i]["shortname"].ToString();
                    str_SelFormula = "shortname =  '" + ddlbranch + "'";
                    if (str_SelFormula != "")
                    {
                        dt_ldg.RowFilter = str_SelFormula;
                    }
                    else
                    {

                    }
                    DataTable dt2 = new DataTable();
                    dt2 = dt_ldg.ToTable();
                    lbloverdue.Text = dt2.Compute("sum(overdue)", "").ToString();
                }
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            DepositDetailsnew();
            ModalPopupExtender7.Show();
        }

        public void fundflowbranches()
        {
            Panel4.Visible = true;
            grd.Visible = true;

            DataAccess.Accounts.FundFlow objfund = new DataAccess.Accounts.FundFlow();
            int cid = Convert.ToInt16(Session["LoginDivisionId"].ToString());

            string strall;
            string str;

            string branchname, str1;
            str1 = "";

            string[] strbranch;
            string[] strArray;


            strall = "";
            str = "Total Collections from Branch deposited to CO Bank (A)~Total payments received from CO (B)~Net CTC Account(cashflow between CO to Branch) (C)~Overseas Debit Note Total Billing (D)~Overseas Credit Note Total Billing (E)~Net OVC Account(receviable/(-) payable with CO) (F)~Interbranch Balance as per the Branch books (G)~Net funding from CO to Branch for the given Period (H)~Net profit Contribution from Branch for given Period (I)~Total funding for the Branch Bussiness (J)";


            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            DateTime FromDate = Convert.ToDateTime(startDate);
            DateTime ToDate = Convert.ToDateTime(endDate);


            branchid = Convert.ToInt16(Session["LoginBranchid"].ToString()); ;
            if (str1 == "")
            {
                str1 = branchid.ToString();
            }
            else
            {
                str1 += "," + branchid.ToString();
            }

            DataRow[] fRows;

            dt = (DataTable)ViewState["Branch"];
            grd.DataSource = dt;
            grd.DataBind();
            strbranch = str1.Split(',');
            str = strall + str;
            strArray = str.Split('~');

            ds1 = objfund.fundsflowforAllBranches(FromDate, ToDate, Session["FADbname"].ToString(), cid);
            dts = ds1.Tables[0];
            dt_sel = ds1.Tables[1];

            grd.DataSource = ds1;
            grd.DataBind();
            fRows = dt_sel.Select("branchid in(" + str1 + ")");

            dt_funddata.Columns.Add("Fund Flow");

            for (int j = 0; j <= fRows.Length - 1; j++)
            {
                dt_funddata.Columns.Add(fRows[j][2].ToString());
            }
            dt_funddata.Columns.Add("Total");

            for (int i = 0; i <= 10 - 1; i++)
            {
                dt_funddata.Rows.Add();
                dt_funddata.Rows[i][0] = strArray[i];
            }

            DataRow[] foundRows;
            int int_CNO = 0, int_RNO = 0, sbid = 0;
            double A, B, C, D, Ee, F, G, H, Ii, Jj, Debit, Credit;

            for (int j = 0; j <= fRows.Length - 1; j++)
            {
                if (sbid != Convert.ToInt16(fRows[j][0].ToString()))
                {
                    sbid = Convert.ToInt16(fRows[j][0].ToString());
                    int_RNO = 0;
                    int_CNO = int_CNO + 1;
                    foundRows = dts.Select("branchid=" + fRows[j][0].ToString());
                    A = 0.0;
                    B = 0.0;
                    C = 0.0;
                    D = 0.0;
                    Ee = 0.0;
                    F = 0.0;
                    G = 0.0;
                    H = 0.0;
                    Ii = 0.0;
                    Jj = 0.0;
                    Debit = 0.0;
                    Credit = 0.0;

                    for (int k = 0; k <= foundRows.Length - 1; k++)
                    {
                        if (foundRows[k][1].ToString() == "A")
                        {
                            A = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        if (foundRows[k][1].ToString() == "B")
                        {
                            B = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        C = A - B;

                        if (foundRows[k][1].ToString() == "D")
                        {
                            D = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        if (foundRows[k][1].ToString() == "E")
                        {
                            Ee = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        if (Convert.ToInt16(foundRows[k][0].ToString()) == 40 || Convert.ToInt16(foundRows[k][0].ToString()) == 51 || Convert.ToInt16(foundRows[k][0].ToString()) == 62)
                        {
                            F = Ee - D;
                        }
                        else
                        {
                            F = D - Ee;
                        }

                        if (foundRows[k][1].ToString() == "G")
                        {
                            if (foundRows[k][2].ToString() == "Cr")
                            {
                                Credit = Convert.ToDouble(foundRows[k][3].ToString());
                            }
                            else
                            {
                                Debit = Convert.ToDouble(foundRows[k][3].ToString());
                            }
                            G = Debit - Credit;
                        }

                        H = C + F + G;

                        if (foundRows[k][1].ToString() == "I")
                        {
                            Ii = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        Jj = H - Ii;
                    }

                    dt_funddata.Rows[int_RNO][int_CNO] = A.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = B.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = C.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = D.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = Ee.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = F.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = G.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = H.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = Ii.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = Jj.ToString("#,0.00");
                }
            }

            int ccount, rcount;
            double tot;
            ccount = dt_funddata.Columns.Count - 1;
            rcount = dt_funddata.Rows.Count - 1;

            for (int j = 0; j <= rcount; j++)
            {
                tot = 0;
                for (int k = 1; k <= ccount - 1; k++)
                {
                    tot = tot + Convert.ToDouble(dt_funddata.Rows[j][k].ToString());
                }
                dt_funddata.Rows[j][ccount] = tot.ToString("#,0.00");
            }

            for (int i = dt_funddata.Rows.Count - 2; i >= 0; i--)
            {
                dt_funddata.Rows.RemoveAt(i);
            }
            grd.DataSource = dt_funddata;
            grd.DataBind();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            fundflowbranches();
            Panel4.Visible = true;
            grd.Visible = true;
            ModalPopupExtender8.Show();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Grdincomnotbooked();
           
        }

        protected void Gridjobcost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int h = 2; h <= e.Row.Cells.Count - 1; h++)
            {
                double dbl_temp = 0;
                if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                {
                    //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                    e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                }
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            this.LoadPendingcrdappr();
            Panelcrdappr.Visible = true;
            GrdPendingcrdapp.Visible = true;
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            loadgrd();
            Panelexrate.Visible = true;
            Gridexrate.Visible = true;
            ModalPopupExtender9.Show();
        }

        public void visible_false()
        {
            div_bar.Visible = false;
            div2_Bookchart.Visible = false;
            div_Deposite.Visible = false;
            pnl_penDepo.Visible = false;
            div_DnCnApp.Visible = false;
            div_ChRquApp.Visible = false;
            div_UnClos.Visible = false;
            Panel13.Visible = false;
            div_CollRecpt.Visible = false;
            pnl_RecCol.Visible = false;
            grd_AirImports.Visible = false;
            div_Tds.Visible = false;
            Deposits.Visible = false;
            penBlRelase.Visible = false;
            headlbl1.Visible = false;
            _Pend_UN.Visible = false;
            Panel_unc.Visible = false;
            excportexc.Visible = false;
            exp2excGrd_Deposite.Visible = false;
        }
        protected void Lnk_deposit_Click(object sender, EventArgs e)
        {
            LoadPendingDeposite();
        }
        public void LoadPendingDeposite()
        {
            visible_false();
            double amt = 0;
            div_Deposite.Visible = true;
            pnl_penDepo.Visible = true;
            Deposits.Visible = true;
            exp2excGrd_Deposite.Visible = true;
            DataTable dtTemp = new DataTable();
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            dt = leftObj.GetDeposit4dash(branchid);
            dtTemp.Columns.Add("Cheque#");
            DataRow dr = dtTemp.NewRow();
            dtTemp.Columns.Add("Date");
            dtTemp.Columns.Add("Bank");
            dtTemp.Columns.Add("Amount");
            //pop_lineGrd.Show();
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j <= dt.Rows.Count - 1; j++)
                {

                    dtTemp.Rows.Add();
                    dr = dtTemp.NewRow();
                    dtTemp.Rows[j]["Cheque#"] = dt.Rows[j]["Cheque#"].ToString();
                    dtTemp.Rows[j]["Date"] = dt.Rows[j]["Date"].ToString();
                    dtTemp.Rows[j]["Bank"] = dt.Rows[j]["bankname"].ToString();
                    dtTemp.Rows[j]["Amount"] = (Convert.ToDouble(dt.Rows[j]["Amount"].ToString())).ToString("#,0.00");
                    amt = amt + Convert.ToDouble(dt.Rows[j]["Amount"].ToString());
                }
                dtTemp.Rows.Add(dr);
                dtTemp.Rows[dt.Rows.Count]["Cheque#"] = "Total";
                dtTemp.Rows[dt.Rows.Count]["Amount"] = amt.ToString("#,0.00");
                Grd_Deposite.DataSource = dtTemp;
                Grd_Deposite.DataBind();
            }
            else
            {
                Grd_Deposite.DataSource = new DataTable();
                Grd_Deposite.DataBind();
            }

            ViewState["Grd_Deposite"] = dtTemp;
        }

        protected void lnl_CkCnopsRq_Click(object sender, EventArgs e)
        {
            exp2excGrd_Deposite.Visible = false;
            DataTable dtuser = new DataTable();
            dtuser = obj_UP.GetFormwiseuserRights(1065, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "CnOps";
                Response.Redirect("../Accounts/ChequeRequestApproval.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void lnk_ChCnRq_Click(object sender, EventArgs e)
        {
            exp2excGrd_Deposite.Visible = false;
         
            DataTable dtuser = new DataTable();
            dtuser = obj_UP.GetFormwiseuserRights(1065, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "CN";
                Response.Redirect("../Accounts/ChequeRequestApproval.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void lnk_other_Dn_Click(object sender, EventArgs e)
        {
            exp2excGrd_Deposite.Visible = false;
            visible_false();
            div_ChRquApp.Visible = true;
            Grd_Approval.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Approval.DataBind();
            ddl_module.SelectedValue = "0";
            hid_type.Value = "Debit Note";
            lbl_Header.Text = "Transfer to Commercial Debit Note";
            year = logobj.GetDate();
            month = year.Month;
            if (month < 4)
            {
                int_vouyear = (year.Year) - 1;
            }
            else
            {
                int_vouyear = year.Year;
            }
        }
        protected void ddl_module_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_LoadDetail();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //private void Fn_DNCNBL(int jobno, string trantype, string type, DateTime CDate, int vouno, string voutype)
        //{
        //    int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
        //    double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
        //    int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
        //    DateTime dtdate = CDate;
        //    DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();

        //    DataTable obj_dt = new DataTable();
        //    DataTable obj_dttemp = new DataTable();
        //    if (type == "Closed")
        //    {
        //        obj_dt = obj_da_Cost.GetDNCN4MISFromJobNo(jobno, int_bid, trantype);

        //    }
        //    else if (type == "Approve")
        //    {
        //        obj_dt = obj_da_Cost.GetDNCN4MISFromVouno(jobno, int_bid, trantype, vouno, voutype);
        //    }
        //    int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
        //    char Nomination;
        //    string blno;
        //    double volume = 0;
        //    if (obj_dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
        //        {
        //            blno = obj_dt.Rows[i]["blno"].ToString();
        //            int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
        //            if (trantype != "CH")
        //            {
        //                MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
        //            }
        //            else
        //            {
        //                MLO = 0;
        //            }
        //            if (type == "Closed")
        //            {
        //                dtdate = CDate;
        //            }
        //            else if (type == "Approve")
        //            {
        //                dtdate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["voudate"].ToString()));
        //            }
        //            obj_dttemp = obj_da_Cost.GetBLRowBL(blno, trantype, int_bid);
        //            if (obj_dttemp.Rows.Count > 0)
        //            {
        //                if (i < obj_dt.Rows.Count - 1)
        //                {
        //                    if (obj_dt.Rows[i]["blno"].ToString() != obj_dt.Rows[i + 1]["blno"].ToString())
        //                    {
        //                        if (obj_dt.Rows[i]["voutype"].ToString() == "V")
        //                        {
        //                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                            {
        //                                BL_Amount = double.Parse(obj_dt.Rows[i]["amount"].ToString());
        //                            }
        //                        }
        //                        else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
        //                        {
        //                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                            {
        //                                BL_Expense = double.Parse(obj_dt.Rows[i]["amount"].ToString());
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (obj_dt.Rows[i]["voutype"].ToString() == "V")
        //                        {
        //                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                            {
        //                                BL_Amount = double.Parse(obj_dt.Rows[i]["amount"].ToString());
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                            {
        //                                BL_Expense = double.Parse(obj_dt.Rows[i]["amount"].ToString());
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (obj_dt.Rows[i]["voutype"].ToString() == "V")
        //                    {
        //                        if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                        {
        //                            BL_Amount = double.Parse(obj_dt.Rows[i]["amount"].ToString());
        //                        }
        //                    }
        //                    else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
        //                    {
        //                        if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                        {
        //                            BL_Expense = double.Parse(obj_dt.Rows[i]["amount"].ToString());
        //                        }
        //                    }
        //                }
        //                int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
        //                blno = obj_dttemp.Rows[0][1].ToString();
        //                int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
        //                int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
        //                int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
        //                int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
        //                int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
        //                int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());
        //                if (trantype != "CH")
        //                {
        //                    int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
        //                }
        //                Nomination = char.Parse(obj_dttemp.Rows[0][4].ToString());
        //                volume = double.Parse(obj_dttemp.Rows[0][5].ToString());

        //                if (trantype == "FE" || trantype == "FI")
        //                {
        //                    if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
        //                    {
        //                        int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
        //                        int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
        //                        JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
        //                    }
        //                }
        //                else if (trantype == "AE" || trantype == "AI" || trantype == "CH")
        //                {
        //                    int_Cont20 = 0;
        //                    int_Cont40 = 0;
        //                    JobType = 0;
        //                }
        //                BL_Amount = BL_Amount + BL_debit;
        //                BL_Expense = BL_Expense + BL_credit;

        //                //obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, 0, char.Parse(string.Empty));
        //                obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, 0, Convert.ToChar(voutype));
        //            }
        //            else
        //            {
        //                Fn_DNCNMBL(jobno, trantype, vouno, voutype, i, obj_dt, int_bid, dtdate);
        //            }
        //        }
        //    }

        //}
        //private void Fn_DNCNMBL(int jobno, string trantype, int vouno, string voutype, int count, DataTable dt, int int_bid, DateTime Close_date)
        //{
        //    double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
        //    int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
        //    DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
        //    obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "V", int_bid, 0, "");
        //    DataTable obj_dt = new DataTable();
        //    DataTable obj_dttemp = new DataTable();
        //    obj_dt = obj_da_Cost.GetBLRow(jobno, trantype, int_bid);
        //    if (obj_dt.Rows.Count > 0)
        //    {
        //        if (count < dt.Rows.Count - 1)
        //        {
        //            if (dt.Rows[count]["blno"].ToString() != dt.Rows[count + 1]["blno"].ToString())
        //            {
        //                if (dt.Rows[count]["voutype"].ToString() == "V")
        //                {
        //                    if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
        //                    {
        //                        MBL_Amount = double.Parse(dt.Rows[count]["amount"].ToString());
        //                    }
        //                }
        //                else if (dt.Rows[count]["voutype"].ToString() == "E")
        //                {
        //                    if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
        //                    {
        //                        MBL_Expense = double.Parse(dt.Rows[count]["amount"].ToString());
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (dt.Rows[count]["voutype"].ToString() == "V")
        //                {
        //                    if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
        //                    {
        //                        BL_Amount = double.Parse(dt.Rows[count]["amount"].ToString());
        //                    }
        //                }
        //                else if (dt.Rows[count]["voutype"].ToString() == "E")
        //                {
        //                    if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
        //                    {
        //                        BL_Expense = double.Parse(dt.Rows[count]["amount"].ToString());
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (dt.Rows[count]["voutype"].ToString() == "V")
        //            {
        //                if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
        //                {
        //                    MBL_Amount = double.Parse(dt.Rows[count]["amount"].ToString());
        //                }
        //            }
        //            else if (dt.Rows[count]["voutype"].ToString() == "E")
        //            {
        //                if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
        //                {
        //                    MBL_Expense = double.Parse(dt.Rows[count]["amount"].ToString());
        //                }
        //            }
        //        }
        //        if (trantype == "FE" || trantype == "FI")
        //        {
        //            JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
        //            obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
        //            if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
        //            {
        //                Total_CBM = double.Parse(obj_dttemp.Rows[0]["cbmtotal"].ToString());
        //                Total_Tues = double.Parse(obj_dttemp.Rows[0]["Tuestotal"].ToString());
        //            }
        //        }
        //        else if (trantype == "AE" || trantype == "AI")
        //        {
        //            JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
        //            obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
        //            if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
        //            {
        //                JobChargeWT = double.Parse(obj_dttemp.Rows[0][0].ToString());

        //            }
        //        }
        //        for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
        //        {
        //            if (trantype == "FE" || trantype == "FI")
        //            {
        //                BL_Tues = Convert.ToInt32(obj_dt.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dt.Rows[j]["cont20"].ToString()) * 2);
        //                BL_CBM = Convert.ToDouble(obj_dt.Rows[j]["cbm"].ToString());
        //                if (MBL_Amount != 0)
        //                {
        //                    if (JobType == 3)
        //                    {
        //                        BL_Amount = ((MBL_Amount / Total_Tues) * BL_Tues);
        //                    }
        //                    else
        //                    {
        //                        MBL_Amount = ((MBL_Amount / Total_CBM) * BL_CBM);
        //                    }
        //                }

        //                if (MBL_Expense != 0)
        //                {
        //                    if (JobType == 3)
        //                    {
        //                        BL_Expense = ((MBL_Expense / Total_Tues) * BL_Tues);
        //                    }
        //                    else
        //                    {
        //                        if (BL_CBM == 0)
        //                        {
        //                            BL_Expense = 0;
        //                        }
        //                        else if (Total_CBM == 0)
        //                        {
        //                            BL_Expense = 0;
        //                        }
        //                        else
        //                        {
        //                            BL_Expense = ((MBL_Expense / Total_CBM) * BL_CBM);
        //                        }
        //                    }
        //                }
        //            }
        //            else if (trantype == "AE" || trantype == "AI")
        //            {
        //                BL_ChargeWT = double.Parse(obj_dt.Rows[j]["chargewt"].ToString());

        //                if (MBL_Amount != 0)
        //                {
        //                    BL_Amount = ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
        //                }
        //                if (MBL_Expense != 0)
        //                {
        //                    BL_Expense = ((MBL_Expense / JobChargeWT) * BL_ChargeWT);
        //                }
        //            }

        //            if (trantype == "FE" || trantype == "FI")
        //            {
        //                if (obj_dt.Rows[j][2].ToString().Length > 0 && obj_dt.Rows[j][3].ToString().Length > 0)
        //                {
        //                    int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
        //                    int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
        //                }
        //            }
        //            else if (trantype == "AE" || trantype == "AI")
        //            {
        //                int_Cont20 = 0;
        //                int_Cont40 = 0;
        //            }
        //            int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
        //            char Nomination;
        //            string blno;
        //            double volume = 0;
        //            int_job = Convert.ToInt32(obj_dt.Rows[j][0].ToString());
        //            blno = obj_dt.Rows[j][1].ToString();
        //            int_shipper = Convert.ToInt32(obj_dt.Rows[j][6].ToString());
        //            int_consignee = Convert.ToInt32(obj_dt.Rows[j][7].ToString());
        //            int_notify = Convert.ToInt32(obj_dt.Rows[j][8].ToString());
        //            int_agent = Convert.ToInt32(obj_dt.Rows[j][9].ToString());
        //            int_pol = Convert.ToInt32(obj_dt.Rows[j][10].ToString());
        //            int_pod = Convert.ToInt32(obj_dt.Rows[j][11].ToString());
        //            int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
        //            Nomination = char.Parse(obj_dt.Rows[j][4].ToString());
        //            volume = double.Parse(obj_dt.Rows[j][5].ToString());
        //            if (trantype == "FE" || trantype == "FI")
        //            {
        //                if (JobType == 3)
        //                {
        //                    volume = 0;
        //                    int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
        //                    int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
        //                }
        //                else
        //                {
        //                    int_Cont20 = 0;
        //                    int_Cont40 = 0;
        //                }
        //            }
        //            obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, vouno, char.Parse(voutype));

        //        }
        //    }
        //}

        private void Fn_DNCNBL(int jobno, string trantype, string type, DateTime CDate, int vouno, string voutype)
        {
            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            DateTime dtdate = CDate;
            DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
            obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "O", int_bid, vouno, voutype);
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            if (type == "Closed")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromJobNo(jobno, int_bid, trantype);

            }
            else if (type == "Approve")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromVouno(jobno, int_bid, trantype, vouno, voutype);
            }
            int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
            char Nomination=' ';
            string blno;
            double volume = 0;
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    blno = obj_dt.Rows[i]["blno"].ToString();
                    int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                    if (trantype != "CH")
                    {
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
                    }
                    else
                    {
                        MLO = 0;
                    }
                    if (type == "Closed")
                    {
                        dtdate = CDate;
                    }
                    else if (type == "Approve")
                    {
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                    }
                    obj_dttemp = obj_da_Cost.GetBLRowBL(blno, trantype, int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        if (i < obj_dt.Rows.Count - 1)
                        {
                            if (obj_dt.Rows[i]["blno"].ToString() != obj_dt.Rows[i + 1]["blno"].ToString())
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = double.Parse(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = double.Parse(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Amount = double.Parse(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else
                                {
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    {
                                        BL_Expense = double.Parse(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Amount = double.Parse(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                            {
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                {
                                    BL_Expense = double.Parse(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                        }
                        int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
                        blno = obj_dttemp.Rows[0][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());
                        if (trantype != "CH")
                        {
                            int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        }
                        if(!string.IsNullOrEmpty(obj_dttemp.Rows[0][4].ToString()))
                        {
                        Nomination = char.Parse(obj_dttemp.Rows[0][4].ToString());
                        }
                        volume = double.Parse(obj_dttemp.Rows[0][5].ToString());

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
                                JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI" || trantype == "CH")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                            JobType = 0;
                        }
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;

                        //obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, 0, char.Parse(string.Empty));
                        obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, vouno, Convert.ToChar(voutype));
                    }
                    else
                    {
                        Fn_DNCNMBL(jobno, trantype, vouno, voutype, i, obj_dt, int_bid, dtdate);
                    }
                }
            }

        }
        private void Fn_DNCNMBL(int jobno, string trantype, int vouno, string voutype, int count, DataTable dt, int int_bid, DateTime Close_date)
        {
            double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
           // obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "O", int_bid, 0, "");
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            obj_dt = obj_da_Cost.GetBLRow(jobno, trantype, int_bid);
            if (obj_dt.Rows.Count > 0)
            {
                if (count < dt.Rows.Count - 1)
                {
                    if (dt.Rows[count]["blno"].ToString() != dt.Rows[count + 1]["blno"].ToString())
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = double.Parse(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = double.Parse(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Amount = double.Parse(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Expense = double.Parse(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    if (dt.Rows[count]["voutype"].ToString() == "V")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Amount = double.Parse(dt.Rows[count]["amount"].ToString());
                        }
                    }
                    else if (dt.Rows[count]["voutype"].ToString() == "E")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Expense = double.Parse(dt.Rows[count]["amount"].ToString());
                        }
                    }
                }
                if (trantype == "FE" || trantype == "FI")
                {
                    JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                    obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                    if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
                    {
                        Total_CBM = double.Parse(obj_dttemp.Rows[0]["cbmtotal"].ToString());
                        Total_Tues = double.Parse(obj_dttemp.Rows[0]["Tuestotal"].ToString());
                    }
                }
                else if (trantype == "AE" || trantype == "AI")
                {
                   // JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                    JobType = 0;
                    obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                    if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
                    {
                        JobChargeWT = double.Parse(obj_dttemp.Rows[0][0].ToString());

                    }
                }
                for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                {
                    BL_Amount = 0;
                    BL_Expense = 0;
                    if (trantype == "FE" || trantype == "FI")
                    {
                        BL_Tues = Convert.ToInt32(obj_dt.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dt.Rows[j]["cont40"].ToString()) * 2);
                        BL_CBM = Convert.ToDouble(obj_dt.Rows[j]["cbm"].ToString());
                        if (MBL_Amount != 0)
                        {
                            if (JobType == 3)
                            {
                                BL_Amount = ((MBL_Amount / Total_Tues) * BL_Tues);
                            }
                            else
                            {
                                BL_Amount = ((MBL_Amount / Total_CBM) * BL_CBM);
                            }
                        }

                        if (MBL_Expense != 0)
                        {
                            if (JobType == 3)
                            {
                                BL_Expense = ((MBL_Expense / Total_Tues) * BL_Tues);
                            }
                            else
                            {
                                if (BL_CBM == 0)
                                {
                                    BL_Expense = 0;
                                }
                                else if (Total_CBM == 0)
                                {
                                    BL_Expense = 0;
                                }
                                else
                                {
                                    BL_Expense = ((MBL_Expense / Total_CBM) * BL_CBM);
                                }
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        BL_ChargeWT = double.Parse(obj_dt.Rows[j]["chargewt"].ToString());

                        if (MBL_Amount != 0)
                        {
                            BL_Amount = ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
                        }
                        if (MBL_Expense != 0)
                        {
                            BL_Expense = ((MBL_Expense / JobChargeWT) * BL_ChargeWT);
                        }
                    }

                    if (trantype == "FE" || trantype == "FI")
                    {
                        if (obj_dt.Rows[j][2].ToString().Length > 0 && obj_dt.Rows[j][3].ToString().Length > 0)
                        {
                            int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                            int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        int_Cont20 = 0;
                        int_Cont40 = 0;
                    }
                    int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                    char Nomination=' ';
                    string blno;
                    double volume = 0;
                    int_job = Convert.ToInt32(obj_dt.Rows[j][0].ToString());
                    blno = obj_dt.Rows[j][1].ToString();
                    int_shipper = Convert.ToInt32(obj_dt.Rows[j][6].ToString());
                    int_consignee = Convert.ToInt32(obj_dt.Rows[j][7].ToString());
                    int_notify = Convert.ToInt32(obj_dt.Rows[j][8].ToString());
                    int_agent = Convert.ToInt32(obj_dt.Rows[j][9].ToString());
                    int_pol = Convert.ToInt32(obj_dt.Rows[j][10].ToString());
                    int_pod = Convert.ToInt32(obj_dt.Rows[j][11].ToString());
                    int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                    if (!string.IsNullOrEmpty(obj_dt.Rows[j][4].ToString()))
                    {
                        Nomination = char.Parse(obj_dt.Rows[j][4].ToString());
                    }
                    else
                    {
                        Nomination = ' ';
                    }
                    volume = double.Parse(obj_dt.Rows[j][5].ToString());
                    if (trantype == "FE" || trantype == "FI")
                    {
                        if (JobType == 3)
                        {
                            volume = 0;
                            //int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                            //int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                        }
                        else
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                        }
                    }
                    obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, vouno, char.Parse(voutype));

                }
            }
        }
        /*protected void btn_transfer_Click(object sender, EventArgs e)
        {
            try
            {
                int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
                string Str_Trantype = ddl_module.SelectedValue.ToString(), Str_invoiceno = "", str_BLno = "", billtype = "";

                int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                div = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                bid = hrempobj.GetBranchId(div, Session["LoginBranchName"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                DataTable dtacc = new DataTable();
                DataTable Dtckeck = new DataTable();


                if (lbl_Header.Text == "Debit Note" || lbl_Header.Text == "Credit Note")
                {
                    foreach (GridViewRow row in Grid_DNCN.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_DNCN");
                        if (Chk.Checked == true)
                        {
                            empid = employeeobj.GetNEmpid(row.Cells[5].Text);
                            int_Refno = Convert.ToInt32(row.Cells[1].Text.ToString());
                            int_Invoiceno = obj_da_Approval.GetNoforAcForApproval(bid, hid_type.Value);
                            str_BLno = row.Cells[1].Text.ToString();
                            int_Vouyear = Convert.ToInt32(Grid_DNCN.DataKeys[row.RowIndex].Values[0].ToString());
                            //if (int_Empid == empid)
                            //{
                            //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //    continue;
                            //}
                            //dtacc = obj_da_Invoice.SelEmpDtls4Acc(int_Empid, 0, int_bid, Str_Trantype, str_BLno);
                            //if (dtacc.Rows.Count > 0)
                            //{
                            //    if (dtacc.Rows[0]["closedjob"].ToString() == "1")
                            //    {
                            //        if (dtacc.Rows[0]["deptid"].ToString() == "1" && dtacc.Rows[0]["branch"].ToString() == "CORPORATE")
                            //        {

                            //        }
                            //        else
                            //        {
                            //            ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + " has been closed. Corporate accountant only can approve the Pro DN/CN');", true);
                            //            continue;
                            //        }


                            //    }
                            //}
                            //Dtckeck = obj_da_Approval.GetDebitSTCheckAmt(int_Refno, int_bid, int_Vouyear);
                            //if (Dtckeck.Rows.Count > 0)
                            //{
                            //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Debit Note');", true);
                            //    continue;
                            //}
                            obj_da_Approval.UpdApproval(int_Refno, str_BLno, int_Empid, Str_Trantype, hid_type.Value, int_Vouyear, int_bid);
                            if (lbl_Header.Text == "Debit Note")
                            {
                                //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('DN # :" + int_Invoiceno + "transferred');", true);
                                obj_dt = obj_da_Invoice.ShowIPHead(int_Invoiceno, "AC", "DNHead", int_Vouyear, bid);
                                str_VType = "V";
                            }
                            else if (lbl_Header.Text == "Credit Note")
                            {
                                //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('CN # :" + int_Invoiceno + "transferred');", true);
                                obj_dt = obj_da_Invoice.ShowIPHead(int_Invoiceno, "AC", "CNHead", int_Vouyear, bid);
                                str_VType = "E";
                            }
                            if (obj_dt.Rows.Count > 0)
                            {
                                Fn_DNCNBL(Convert.ToInt32(obj_dt.Rows[0][3].ToString()), obj_dt.Rows[0][2].ToString(), "Approve", obj_da_Log.GetDate(), int_Invoiceno, str_VType);
                            }

                            if (lbl_Header.Text == "Debit Note")
                            {//raj-need to remove comment
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No");
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "DNHead", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = Convert.ToInt32(obj_dt.Rows[0].ItemArray[4].ToString());
                                        DateTime date_Voudate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[0].ItemArray[1].ToString()));
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Debit Note - Others", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                                        string Str_CustType = obj_da_Customer.GetCustomerType(int_custid);
                                        if (Str_CustType == "C")
                                        {
                                            obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0, int_custid);
                                        }
                                        else if (Str_CustType == "P")
                                        {
                                            DataTable dt = new DataTable();
                                            dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "DNHead", int_bid, int_Vouyear);
                                            string Str_Curr = "";
                                            double F_Curr = 0;
                                            if (dt.Rows.Count > 0)
                                            {
                                                Str_Curr = dt.Rows[0]["curr"].ToString();
                                                F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                            }
                                            obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, double.Parse(row.Cells[3].Text.ToString()), Str_Curr, F_Curr, int_custid);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //  Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In ProOtherDCNApproval DN# " + int_Invoiceno + " \\VYear - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                                obj_da_Log.InsLogDetail(int_Empid, 264, 1, int_bid, Str_Trantype + "/" + int_Invoiceno + "/A");
                            }
                            else if (lbl_Header.Text == "Credit Note")
                            {
                                obj_dt = obj_da_Approval.GetAgentCustomerOrNot(int_Invoiceno, int_Vouyear, int_bid, "CN");
                                if (obj_dt.Rows.Count > 0)
                                {//raj-need to remove comment
                                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No");

                                    obj_da_Log.InsLogDetail(int_Empid, 265, 1, int_bid, Str_Trantype + "/" + int_Invoiceno + "/A");
                                }
                            }
                        }
                    }
                }
                else if (hid_type.Value == "Debit Note" || hid_type.Value == "Credit Note")
                {
                    foreach (GridViewRow row in Grd_Approval.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_Approval");
                        if (Chk.Checked == true)
                        {
                            empid = employeeobj.GetNEmpid(row.Cells[5].Text);
                            int_Refno = Convert.ToInt32(row.Cells[1].Text.ToString());
                            int_Invoiceno = obj_da_Approval.GetNoforAcForApproval(bid, hid_type.Value.ToString());
                            str_BLno = row.Cells[1].Text.ToString();
                            int_Vouyear = Convert.ToInt32(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
                            if (int_Empid == empid)
                            {
                                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                continue;
                            }
                            dtacc = obj_da_Invoice.SelEmpDtls4Acc(int_Empid, 0, int_bid, Str_Trantype, str_BLno);
                            if (dtacc.Rows.Count > 0)
                            {
                                if (dtacc.Rows[0]["closedjob"].ToString() == "1")
                                {
                                    if (dtacc.Rows[0]["deptid"].ToString() == "1" && dtacc.Rows[0]["branch"].ToString() == "CORPORATE")
                                    {

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + " has been closed. Corporate accountant only can approve the Pro DN/CN');", true);
                                        continue;
                                    }


                                }
                            }
                            Dtckeck = obj_da_Approval.GetDebitSTCheckAmt(int_Refno, int_bid, int_Vouyear);
                            if (Dtckeck.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Debit Note');", true);
                                continue;
                            }
                            obj_da_Approval.UpdProApproval(int_Refno, str_BLno, int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());
                            if (hid_type.Value.ToString() == "Debit Note")
                            {
                                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('DN # :" + int_Invoiceno + "transferred');", true);
                                obj_dt = obj_da_Invoice.ShowIPHead(int_Invoiceno, "AC", "DNHead", int_Vouyear, bid);
                                str_VType = "V";
                            }
                            else if (hid_type.Value.ToString() == "Credit Note")
                            {
                                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('CN # :" + int_Invoiceno + "transferred');", true);
                                obj_dt = obj_da_Invoice.ShowIPHead(int_Invoiceno, "AC", "CNHead", int_Vouyear, bid);
                                str_VType = "E";
                            }
                            billtype = row.Cells[6].Text;
                            if (billtype == "P")
                            {
                                obj_da_Approval.insprosharevou(int_bid, str_VType, int_Invoiceno, int_Vouyear);
                            }
                            if (obj_dt.Rows.Count > 0)
                            {
                                Fn_DNCNBL(Convert.ToInt32(obj_dt.Rows[0][3].ToString()), obj_dt.Rows[0][2].ToString(), "Approve", obj_da_Log.GetDate(), int_Invoiceno, str_VType);
                            }

                            if (hid_type.Value.ToString() == "Debit Note")
                            {//raj-need to remove comment
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No");
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "DNHead", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = Convert.ToInt32(obj_dt.Rows[0].ItemArray[4].ToString());
                                        DateTime date_Voudate = Convert.ToDateTime(Utility.fn_ConvertDate(obj_dt.Rows[0].ItemArray[1].ToString()));
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Debit Note - Others", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                                        string Str_CustType = obj_da_Customer.GetCustomerType(int_custid);
                                        if (Str_CustType == "C")
                                        {
                                            obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0, int_custid);
                                        }
                                        else if (Str_CustType == "P")
                                        {
                                            DataTable dt = new DataTable();
                                            dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "DNHead", int_bid, int_Vouyear);
                                            string Str_Curr = "";
                                            double F_Curr = 0;
                                            if (dt.Rows.Count > 0)
                                            {
                                                Str_Curr = dt.Rows[0]["curr"].ToString();
                                                F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                            }
                                            obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'V', int_Vouyear, int_bid, double.Parse(row.Cells[3].Text.ToString()), Str_Curr, F_Curr, int_custid);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //  Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In ProOtherDCNApproval DN# " + int_Invoiceno + " \\VYear - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                                obj_da_Log.InsLogDetail(int_Empid, 264, 1, int_bid, Str_Trantype + "/" + int_Invoiceno + "/A");
                            }
                            else if (hid_type.Value.ToString() == "Credit Note")
                            {
                                obj_dt = obj_da_Approval.GetAgentCustomerOrNot(int_Invoiceno, int_Vouyear, int_bid, "CN");
                                if (obj_dt.Rows.Count > 0)
                                {//raj-need to remove comment
                                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No");

                                    obj_da_Log.InsLogDetail(int_Empid, 265, 1, int_bid, Str_Trantype + "/" + int_Invoiceno + "/A");
                                }
                            }
                        }
                    }
                }


                Fn_LoadDetail();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }*/

        //GST

        protected void btn_transfer_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                int gsttype = 0, statename = 0, supplyto = 0, empname1 = 0;
                string gsttype_ = "", statename_ = "", supplyto_ = "", empname1_="";
                int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
                string Str_Trantype = ddl_module.SelectedValue.ToString(), Str_invoiceno = "", str_BLno = "", billtype = "";
                int int_Empid = 0;
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                div = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                bid = hrempobj.GetBranchId(div, Session["LoginBranchName"].ToString());
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                DataTable dtacc = new DataTable();
                DataTable Dtckeck = new DataTable();
                string StrScript = "";
                string cutname = "";

                if (lbl_Header.Text == "Debit Note" || lbl_Header.Text == "Credit Note")
                {
                    foreach (GridViewRow row in Grid_DNCN.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_DNCN");
                        if (Chk.Checked == true)
                        {
                            empid = employeeobj.GetNEmpid(row.Cells[5].Text);
                            int_Refno = Convert.ToInt32(row.Cells[1].Text.ToString());
                            int_Invoiceno = obj_da_Approval.GetNoforAcForApproval(bid, hid_type.Value);
                            str_BLno = row.Cells[2].Text.ToString();
                            int_Vouyear = Convert.ToInt32(Grid_DNCN.DataKeys[row.RowIndex].Values[0].ToString());


                            hid_stamt.Value = row.Cells[8].Text.ToString();
                            hid_supplyto.Value = row.Cells[9].Text.ToString();
                            hid_custtype.Value = row.Cells[10].Text.ToString();

                            if (hid_supplyto.Value != "0")
                            {
                                cutname = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                            }
                            //if (int_Empid == empid)
                            //{
                            //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //    continue;
                            //}
                            //dtacc = obj_da_Invoice.SelEmpDtls4Acc(int_Empid, 0, int_bid, Str_Trantype, str_BLno);
                            //if (dtacc.Rows.Count > 0)
                            //{
                            //    if (dtacc.Rows[0]["closedjob"].ToString() == "1")
                            //    {
                            //        if (dtacc.Rows[0]["deptid"].ToString() == "1" && dtacc.Rows[0]["branch"].ToString() == "CORPORATE")
                            //        {

                            //        }
                            //        else
                            //        {
                            //            ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + " has been closed. Corporate accountant only can approve the Pro DN/CN');", true);
                            //            continue;
                            //        }


                            //    }
                            //}
                            //Dtckeck = obj_da_Approval.GetDebitSTCheckAmt(int_Refno, int_bid, int_Vouyear);
                            //if (Dtckeck.Rows.Count > 0)
                            //{
                            //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Debit Note');", true);
                            //    continue;
                            //}

                            if (Session["hid_gstdate"] != null)
                            {
                                if (hid_custtype.Value == "C")
                                {
                                    if (Convert.ToDateTime(obj_da_Log.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                                    {
                                        //if (hid_supplyto.Value != null && hid_supplyto.Value != "0" && hid_supplyto.Value != "")
                                        if (hid_supplyto.Value != "0")
                                        {
                                            if (Convert.ToDouble(hid_stamt.Value) > 0)
                                            {

                                                int int_custidnew;
                                                DataTable dt_list = new DataTable();
                                                DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                                //int int_custid = Convert.ToInt32(hdncustid.Value);
                                                if (!string.IsNullOrEmpty(row.Cells[9].Text.ToString()))
                                                {
                                                    int_custidnew = Convert.ToInt32(row.Cells[9].Text.ToString());
                                                    dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                                }


                                                //if (dt_list.Rows.Count > 0)
                                                //{
                                                //    if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                                                //    {

                                                //    }
                                                //    else
                                                //    {
                                                //        StrScript = "State Name not Updated in Master Kindly update Master Customer ";
                                                //        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);
                                                //        continue;
                                                //    }
                                                //}
                                                //else
                                                //{
                                                //    StrScript = "State Name not Updated in Master Kindly update Master Customer";
                                                //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                                //    continue;
                                                //}

                                                if (dt_list.Rows.Count > 0)
                                                {
                                                    if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                                    {
                                                        if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                        {
                                                            //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                            //continue;
                                                            if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                            {
                                                                if (gsttype == 0)
                                                                {
                                                                    gsttype_ = cutname;
                                                                }
                                                                else
                                                                {
                                                                    gsttype_ = " ," + cutname;
                                                                }
                                                                gsttype = 1;
                                                                //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                                continue;
                                                            }
                                                        }
                                                    }

                                                    else
                                                    {
                                                        //StrScript = "State Name not Updated in Master Kindly update Master Customer ";
                                                        //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);
                                                        //continue;
                                                        if (statename == 0)
                                                        {
                                                            statename_ = cutname;
                                                        }
                                                        else
                                                        {
                                                            statename_ = " ," + cutname;
                                                        }
                                                        statename = 1;
                                                        continue;
                                                    }
                                                }
                                                else
                                                {
                                                    //StrScript = "State Name not Updated in Master Kindly update Master Customer";
                                                    //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                                    //continue;
                                                    if (statename == 0)
                                                    {
                                                        statename_ = cutname;
                                                    }
                                                    else
                                                    {
                                                        statename_ = " ," + cutname;
                                                    }
                                                    statename = 1;
                                                    continue;
                                                }


                                            }
                                        }
                                        else
                                        {
                                            //StrScript = "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;
                                            //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                            //continue;

                                            if (supplyto == 0)
                                            {
                                                supplyto_ = int_Refno.ToString();
                                            }
                                            else
                                            {
                                                supplyto_ = " ," + int_Refno.ToString();
                                            }
                                            supplyto = 1;
                                            continue;
                                        }
                                    }
                                }
                            }


                            obj_da_Approval.UpdApproval(int_Refno, str_BLno, int_Empid, Str_Trantype, hid_type.Value, int_Vouyear, int_bid);
                            if (lbl_Header.Text == "Debit Note")
                            {
                                //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('DN # :" + int_Invoiceno + "transferred');", true);
                                obj_dt = obj_da_Invoice.ShowIPHead(int_Invoiceno, "AC", "DNHead", int_Vouyear, bid);
                                str_VType = "V";
                            }
                            else if (lbl_Header.Text == "Credit Note")
                            {
                                //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('CN # :" + int_Invoiceno + "transferred');", true);
                                obj_dt = obj_da_Invoice.ShowIPHead(int_Invoiceno, "AC", "CNHead", int_Vouyear, bid);
                                str_VType = "E";
                            }
                            if (obj_dt.Rows.Count > 0)
                            {
                                Fn_DNCNBL(Convert.ToInt32(obj_dt.Rows[0][3].ToString()), obj_dt.Rows[0][2].ToString(), "Approve", obj_da_Log.GetDate(), int_Invoiceno, str_VType);
                            }

                            if (lbl_Header.Text == "Debit Note")
                            {//raj-need to remove comment
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                string retransfer = "N";
                                if (Session["vouid"] != null && hid_custtype.Value == "C")
                                {

                                    retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Session["FADbname"].ToString());

                                    if (retransfer == "Y")
                                    {
                                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    }
                                    Session["vouid"] = null;

                                }
                                
                                
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "DNHead", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = Convert.ToInt32(obj_dt.Rows[0].ItemArray[4].ToString());
                                        DateTime date_Voudate = DateTime.Parse((obj_dt.Rows[0].ItemArray[1].ToString()));
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Debit Note - Others", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                       
                                        string Str_CustType = obj_da_Customer.GetCustomerType(int_custid);
                                        if (Str_CustType == "C")
                                        {
                                            obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, double.Parse(row.Cells[4].Text.ToString()), "", 0, int_custid);
                                        }
                                        else if (Str_CustType == "P")
                                        {
                                            DataTable dt = new DataTable();
                                            dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "DNHead", int_bid, int_Vouyear);
                                            string Str_Curr = "";
                                            double F_Curr = 0;
                                            if (dt.Rows.Count > 0)
                                            {
                                                Str_Curr = dt.Rows[0]["curr"].ToString();
                                                F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                            }
                                            obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, double.Parse(row.Cells[4].Text.ToString()), Str_Curr, F_Curr, int_custid);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //  Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In ProOtherDCNApproval DN# " + int_Invoiceno + " \\VYear - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                                obj_da_Log.InsLogDetail(int_Empid, 264, 1, int_bid, Str_Trantype + "/" + int_Invoiceno + "/A");
                            }
                            else if (lbl_Header.Text == "Credit Note")
                            {
                                obj_dt = obj_da_Approval.GetAgentCustomerOrNot(int_Invoiceno, int_Vouyear, int_bid, "CN");
                                if (obj_dt.Rows.Count > 0)
                                {//raj-need to remove comment
                                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    obj_da_Log.InsLogDetail(int_Empid, 265, 1, int_bid, Str_Trantype + "/" + int_Invoiceno + "/A");
                                }
                            }
                        }
                    }
                }
                else if (hid_type.Value == "Debit Note" || hid_type.Value == "Credit Note")
                {
                    foreach (GridViewRow row in Grd_Approval.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_Approval");
                        if (Chk.Checked == true)
                        {
                            empid = employeeobj.GetNEmpid(row.Cells[5].Text);
                            int_Refno = Convert.ToInt32(row.Cells[1].Text.ToString());
                            int_Invoiceno = obj_da_Approval.GetNoforAcForApproval(bid, hid_type.Value.ToString());

                            str_BLno = HttpUtility.HtmlDecode(row.Cells[2].Text.ToString());
                            int_Vouyear = Convert.ToInt32(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());

                            hid_stamt.Value = row.Cells[9].Text.ToString();
                            hid_supplyto.Value = row.Cells[10].Text.ToString();
                            hid_custtype.Value = row.Cells[11].Text.ToString();
                            if (int_Empid == empid)
                            {
                               // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                               // StrScript +="You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                               // continue;

                                if (empname1 == 0)
                                {
                                    empname1_ = int_Refno.ToString();
                                }
                                else
                                {
                                    empname1_ = " ," + int_Refno.ToString();
                                }
                                empname1 = 1;
                                continue;
                            }



                            if (Session["hid_gstdate"] != null)
                            {
                                if (hid_custtype.Value == "C")
                                {
                                    if (Convert.ToDateTime(obj_da_Log.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                                    {
                                        // if (hid_supplyto.Value != null || hid_supplyto.Value != "0" || hid_supplyto.Value != "")
                                        if (hid_supplyto.Value != "0")
                                        {
                                            if (Convert.ToDouble(hid_stamt.Value) > 0)
                                            {

                                                int int_custidnew;
                                                DataTable dt_list = new DataTable();
                                                DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                                //int int_custid = Convert.ToInt32(hdncustid.Value);
                                                if (!string.IsNullOrEmpty(row.Cells[10].Text.ToString()))
                                                {
                                                    int_custidnew = Convert.ToInt32(row.Cells[10].Text.ToString());
                                                    dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                                }


                                                //if (dt_list.Rows.Count > 0)
                                                //{
                                                //    if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                                                //    {

                                                //    }
                                                //    else
                                                //    {
                                                //        StrScript = "State Name not Updated in Master Kindly update Master Customer ";
                                                //        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);
                                                //        continue;
                                                //    }
                                                //}
                                                //else
                                                //{
                                                //    StrScript = "State Name not Updated in Master Kindly update Master Customer";
                                                //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                                //    continue;
                                                //}



                                                if (dt_list.Rows.Count > 0)
                                                {
                                                    if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                                    {
                                                        if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                        {
                                                            //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                            //continue;
                                                            if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                            {
                                                                if (gsttype == 0)
                                                                {
                                                                    gsttype_ = cutname;
                                                                }
                                                                else
                                                                {
                                                                    gsttype_ = " ," + cutname;
                                                                }
                                                                gsttype = 1;
                                                                //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                                continue;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //StrScript = "State Name not Updated in Master Kindly update Master Customer ";
                                                        //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);
                                                        //continue;
                                                        if (statename == 0)
                                                        {
                                                            statename_ = cutname;
                                                        }
                                                        else
                                                        {
                                                            statename_ = " ," + cutname;
                                                        }
                                                        statename = 1;
                                                        continue;
                                                    }
                                                }
                                                else
                                                {
                                                    //StrScript = "State Name not Updated in Master Kindly update Master Customer";
                                                    //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                                    //continue;
                                                    if (statename == 0)
                                                    {
                                                        statename_ = cutname;
                                                    }
                                                    else
                                                    {
                                                        statename_ = " ," + cutname;
                                                    }
                                                    statename = 1;
                                                    continue;
                                                }



                                            }
                                        }
                                        else
                                        {
                                            //StrScript = "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;
                                            //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                            //continue;

                                            if (supplyto == 0)
                                            {
                                                supplyto_ = int_Refno.ToString();
                                            }
                                            else
                                            {
                                                supplyto_ = " ," + int_Refno.ToString();
                                            }
                                            supplyto = 1;
                                            continue;
                                        }
                                    }
                                }
                            }


                           


                            dtacc = obj_da_Invoice.SelEmpDtls4Acc(int_Empid, 0, int_bid, Str_Trantype, str_BLno);
                            if (dtacc.Rows.Count > 0)
                            {
                                if (dtacc.Rows[0]["closedjob"].ToString() == "1")
                                {
                                    if (dtacc.Rows[0]["deptid"].ToString() == "1" && dtacc.Rows[0]["branch"].ToString() == "CORPORATE")
                                    {

                                    }
                                    else
                                    {
                                       // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + " has been closed. Corporate accountant only can approve the Pro DN/CN');", true);
                                        StrScript += "Job # " + dtacc.Rows[0]["jobno"].ToString() + " has closed. Corporate accountant only can approve the Pro DN/CN";
                                        continue;
                                    }


                                }
                            }
                            Dtckeck = obj_da_Approval.GetDebitSTCheckAmt(int_Refno, int_bid, int_Vouyear);
                            if (Dtckeck.Rows.Count > 0)
                            {
                               // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "ChequeRequestApproval", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Debit Note');", true);
                                StrScript += "Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Debit Note";
                                continue;
                            }
                            obj_da_Approval.UpdProApproval(int_Refno, str_BLno, int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());
                            if (hid_type.Value.ToString() == "Debit Note")
                            {
                                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('DN # :" + int_Invoiceno + "transferred');", true);
                                obj_dt = obj_da_Invoice.ShowIPHead(int_Invoiceno, "AC", "DNHead", int_Vouyear, bid);
                                str_VType = "V";
                            }
                            else if (hid_type.Value.ToString() == "Credit Note")
                            {
                                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "DNCNApproval", "alertify.alert('CN # :" + int_Invoiceno + "transferred');", true);
                                obj_dt = obj_da_Invoice.ShowIPHead(int_Invoiceno, "AC", "CNHead", int_Vouyear, bid);
                                str_VType = "E";
                            }
                            billtype = row.Cells[7].Text;
                            if (billtype == "P")
                            {
                                obj_da_Approval.insprosharevou(int_bid, str_VType, int_Invoiceno, int_Vouyear);
                            }
                            if (obj_dt.Rows.Count > 0)
                            {
                                Fn_DNCNBL(Convert.ToInt32(obj_dt.Rows[0][3].ToString()), obj_dt.Rows[0][2].ToString(), "Approve", obj_da_Log.GetDate(), int_Invoiceno, str_VType);
                            }

                            if (hid_type.Value.ToString() == "Debit Note")
                            {//raj-need to remove comment
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                string retransfer = "N";
                                if (Session["vouid"] != null && hid_custtype.Value == "C")
                                {

                                    retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Session["FADbname"].ToString());

                                    if (retransfer == "Y")
                                    {
                                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    }
                                    Session["vouid"] = null;

                                }
                                
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "DNHead", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = Convert.ToInt32(obj_dt.Rows[0].ItemArray[4].ToString());
                                        DateTime date_Voudate = Convert.ToDateTime((obj_dt.Rows[0].ItemArray[1].ToString()));
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Debit Note - Others", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        
                                        string Str_CustType = obj_da_Customer.GetCustomerType(int_custid);
                                        if (Str_CustType == "C")
                                        {
                                            obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, double.Parse(row.Cells[4].Text.ToString()), "", 0, int_custid);
                                        }
                                        else if (Str_CustType == "P")
                                        {
                                            DataTable dt = new DataTable();
                                            dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "DNHead", int_bid, int_Vouyear);
                                            string Str_Curr = "";
                                            double F_Curr = 0;
                                            if (dt.Rows.Count > 0)
                                            {
                                                Str_Curr = dt.Rows[0]["curr"].ToString();
                                                F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                            }
                                            obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'V', int_Vouyear, int_bid, double.Parse(row.Cells[4].Text.ToString()), Str_Curr, F_Curr, int_custid);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //  Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In ProOtherDCNApproval DN# " + int_Invoiceno + " \\VYear - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                                obj_da_Log.InsLogDetail(int_Empid, 264, 1, int_bid, Str_Trantype + "/" + int_Invoiceno + "/A");
                            }
                            else if (hid_type.Value.ToString() == "Credit Note")
                            {
                                obj_dt = obj_da_Approval.GetAgentCustomerOrNot(int_Invoiceno, int_Vouyear, int_bid, "CN");
                                if (obj_dt.Rows.Count > 0)
                                {//raj-need to remove comment
                                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    obj_da_Log.InsLogDetail(int_Empid, 265, 1, int_bid, Str_Trantype + "/" + int_Invoiceno + "/A");
                                }
                            }
                        }
                    }
                }

                if (gsttype == 1)
                {
                    StrScript += "GST TYPE not Updated for the Customer Name :" + gsttype_;
                }
                if (statename == 1)
                {
                    StrScript += "State Name not Updated in Master Kindly update Master Customer for" + statename_;
                }
                if (supplyto == 1)
                {
                    StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + supplyto_;
                }
                if (empname1 == 1)
                {
                    StrScript += "You have no rights to approve Voucher # " + empname1_ + " prepared by you";
                }
                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);
                Fn_LoadDetail();
                if (Session["usermailid"].ToString() != "" || Session["usermailpwd"].ToString() != "")
                {
                    Utility.SendMail(Session["usermailid"].ToString(), Session["usermailid"].ToString(), "Approve " + StrScript + " \\Year - " + Session["Vouyear"].ToString() + " \\Branch - " + Session["LoginBranchName"].ToString(), "Approve " + StrScript + " \\Year - " + Session["Vouyear"].ToString() + " \\Branch - " + Session["LoginBranchName"].ToString(), "", Session["usermailpwd"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private int Fn_Getcustomergroupid(int int_Custid)
        {
            int int_Subgroupid = 0, int_Groupid = 0;
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            if (hid_type.Value.ToString() == "Debit Note")
            {
                if (obj_da_Customer.GetCustomerType(int_Custid) == "P")
                {
                    int_Subgroupid = 65;
                    int_Groupid = 13;
                }
                else
                {
                    int_Subgroupid = 40;
                    int_Groupid = 13;
                }
            }

            int int_Ledgerid = 0;
            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid), int_Subgroupid, int_Groupid, 'G', int_Custid, 'C', Session["FADbname"].ToString());
            return int_Ledgerid;
        }
        private void Fn_LoadDetail()
        {
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
            if (lbl_Header.Text == "Debit Note" || lbl_Header.Text == "Credit Note")
            {
                obj_dt = obj_da_Approval.FillDt(hid_type.Value, ddl_module.SelectedValue, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                Grid_DNCN.DataSource = obj_dt;
                Grid_DNCN.DataBind();
                Grd_Approval.Visible = false;
                Grid_DNCN.Visible = true;
            }
            else
                if (hid_type.Value == "Debit Note" || hid_type.Value == "Credit Note")
                {
                    obj_dt = obj_da_Approval.FillDtforProDCNApprove(hid_type.Value, ddl_module.SelectedValue, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    Grd_Approval.DataSource = obj_dt;
                    Grd_Approval.DataBind();
                    Grd_Approval.Visible = true;
                    Grid_DNCN.Visible = false;
                }


        }
        protected void Grd_Approval_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Approval, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        /*protected void Grd_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string header = Grd_Approval.HeaderRow.Cells[5].Text;
                //if (header == "Approve")
                //{
                //    return;
                //}
                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                string Str_voucher = "", strblno = "", trantype = "", str_Bl = "", Str_Container = "";
                int int_vouno;
                div = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                bid = hrempobj.GetBranchId(div, Session["LoginBranchName"].ToString());
                trantype = ddl_module.SelectedValue.ToString();
                int_vouno = Convert.ToInt32(Grd_Approval.SelectedRow.Cells[1].Text.ToString());
                //int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
                str_Bl = Grd_Approval.SelectedRow.Cells[2].Text;
                if (hid_type.Value.ToString() == "Debit Note")
                {
                    Str_voucher = "DN";
                }
                else if (hid_type.Value.ToString() == "Credit Note")
                {
                    Str_voucher = "CN";
                }
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                string Str_RptName, Str_SF, Str_SP, Str_Script;
                Str_RptName = "";
                Str_SF = "";
                Str_SP = "";
                Str_Script = "";

                obj_dttemp = obj_da_Invoice.CheckHblno(str_Bl, trantype, int_bid);
                if (obj_dttemp.Rows.Count > 0)
                {
                    if (trantype == "FE" || trantype == "FI")
                    {
                        strblno = obj_dttemp.Rows[0]["blno"].ToString();
                    }
                    else
                    {
                        strblno = obj_dttemp.Rows[0]["hawblno"].ToString();
                    }
                }
                if (trantype == "FE" || trantype == "FI")
                {
                    if (str_Bl == strblno)
                    {
                        obj_dt = obj_da_Invoice.GetHBLContainerDtls(strblno, trantype, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            var Container = obj_dt.AsEnumerable().Select(row => row.Field<string>("containerno"));
                            Str_Container = string.Join("-", Container);
                        }
                    }
                }
                if (obj_dttemp.Rows.Count > 0)
                {

                    if (Str_voucher == "DN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear;
                            //Session["str_sfs"]
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            //Session["str_sfs"] = "{DNHead.trantype}='" + trantype + "'  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                            // Session["str_sp"] = Str_SP;

                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHAProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }

                    else if (Str_voucher == "CN")
                    {
                        int int_custid = 0;
                        DataTable obj_dtcn = new DataTable();
                        obj_dtcn = obj_da_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouno, bid);
                        if (obj_dtcn.Rows.Count > 0)
                        {
                            int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
                        }
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;

                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AICN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }


                }
                else
                {
                    if (Str_voucher == "DN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEMProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIMProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEMProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIMProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHAProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }

                    else if (Str_voucher == "CN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEMProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIMProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEMProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIMProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHAProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {PAHead.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }
                }
                if (Str_voucher == "DN")
                {
                    obj_da_Log.InsLogDetail(empid, 264, 3, bid, trantype + "/" + int_vouno + "/Report");
                }
                else
                {
                    obj_da_Log.InsLogDetail(empid, 265, 3, bid, trantype + "/" + int_vouno + "/Report");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }*/



        ////GST
        //protected void Grd_Approval_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //string header = Grd_Approval.HeaderRow.Cells[5].Text;
        //        //if (header == "Approve")
        //        //{
        //        //    return;
        //        //}
        //        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        //        DateTime gst_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
        //        DateTime getdate;// = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
        //        getdate = Convert.ToDateTime(Grd_Approval.SelectedRow.Cells[11].Text.ToString());
        //        int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
        //        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        //        string Str_voucher = "", strblno = "", trantype = "", str_Bl = "", Str_Container = "", header = "", bltype = "";
        //        int int_vouno;
        //        div = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
        //        bid = hrempobj.GetBranchId(div, Session["LoginBranchName"].ToString());
        //        trantype = ddl_module.SelectedValue.ToString();
        //        int_vouno = Convert.ToInt32(Grd_Approval.SelectedRow.Cells[0].Text.ToString());
        //        double amount = Convert.ToDouble(Grd_Approval.SelectedRow.Cells[3].Text.ToString());
        //        //int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
        //        str_Bl = Grd_Approval.SelectedRow.Cells[1].Text;
        //        if (hid_type.Value.ToString() == "Debit Note")
        //        {
        //            header = "DN";
        //            Str_voucher = "DN";
        //        }
        //        else if (hid_type.Value.ToString() == "Credit Note")
        //        {
        //            header = "CN";
        //            Str_voucher = "CN";
        //        }
        //        DataTable obj_dt = new DataTable();
        //        DataTable obj_dttemp = new DataTable();
        //        string Str_RptName, Str_SF, Str_SP, Str_Script;
        //        Str_RptName = "";
        //        Str_SF = "";
        //        Str_SP = "";
        //        Str_Script = "";

        //        obj_dttemp = obj_da_Invoice.CheckHblno(str_Bl, trantype, int_bid);
        //        if (obj_dttemp.Rows.Count > 0)
        //        {
        //            if (trantype == "FE" || trantype == "FI")
        //            {
        //                strblno = obj_dttemp.Rows[0]["blno"].ToString();
        //            }
        //            else
        //            {
        //                strblno = obj_dttemp.Rows[0]["hawblno"].ToString();
        //            }
        //        }
        //        if (trantype == "FE" || trantype == "FI")
        //        {
        //            if (str_Bl == strblno)
        //            {
        //                obj_dt = obj_da_Invoice.GetHBLContainerDtls(strblno, trantype, int_bid);
        //                if (obj_dt.Rows.Count > 0)
        //                {
        //                    var Container = obj_dt.AsEnumerable().Select(row => row.Field<string>("containerno"));
        //                    Str_Container = string.Join("-", Container);
        //                }
        //            }
        //        }
        //        if (obj_dttemp.Rows.Count > 0)
        //        {
        //            bltype = "H";
        //            if (Str_voucher == "DN")
        //            {
        //                if (trantype == "FE")
        //                {
        //                    Str_RptName = "FEProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear;
        //                    //Session["str_sfs"]
        //                    Str_SP = "Lcurr=INR~container=" + Str_Container;
        //                }
        //                else if (trantype == "FI")
        //                {
        //                    Str_RptName = "FIProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
        //                    //Session["str_sfs"] = "{DNHead.trantype}='" + trantype + "'  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
        //                    Str_SP = "Lcurr=INR~container=" + Str_Container;
        //                    // Session["str_sp"] = Str_SP;

        //                }
        //                else if (trantype == "AE")
        //                {
        //                    Str_RptName = "AEProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR ";
        //                }
        //                else if (trantype == "AI")
        //                {
        //                    Str_RptName = "AIProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                }
        //                else if (trantype == "CH")
        //                {
        //                    Str_RptName = "CHAProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR~container=" + Str_Container;
        //                }
        //                if (getdate >= gst_date)
        //                {
        //                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                }
        //                else
        //                {
        //                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                }
        //                ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
        //            }

        //            else if (Str_voucher == "CN")
        //            {
        //                int int_custid = 0;
        //                DataTable obj_dtcn = new DataTable();
        //                obj_dtcn = obj_da_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouno, bid);
        //                if (obj_dtcn.Rows.Count > 0)
        //                {
        //                    int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
        //                }
        //                if (trantype == "FE")
        //                {
        //                    Str_RptName = "FEProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
        //                    Str_SP = "Lcurr=INR~container=" + Str_Container;
        //                }
        //                else if (trantype == "FI")
        //                {
        //                    Str_RptName = "FIProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "container=" + Str_Container;
        //                }
        //                else if (trantype == "AE")
        //                {
        //                    Str_RptName = "AEProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                }
        //                else if (trantype == "AI")
        //                {
        //                    Str_RptName = "AIProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR~Loccode=" + "";
        //                }
        //                else if (trantype == "CH")
        //                {
        //                    Str_RptName = "CHAProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                }
        //                if (getdate >= gst_date)
        //                {
        //                    Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                }
        //                else
        //                {
        //                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                }
        //                ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
        //            }


        //        }
        //        else
        //        {
        //            bltype = "M";
        //            if (Str_voucher == "DN")
        //            {
        //                if (trantype == "FE")
        //                {
        //                    Str_RptName = "FEMProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR~container=" + Str_Container;
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                else if (trantype == "FI")
        //                {
        //                    Str_RptName = "FIMProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR~container=" + Str_Container;
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                else if (trantype == "AE")
        //                {
        //                    Str_RptName = "AEMProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
        //                    Str_SP = "Lcurr=INR";
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                else if (trantype == "AI")
        //                {
        //                    Str_RptName = "AIMProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                else if (trantype == "CH")
        //                {
        //                    Str_RptName = "CHAProDN.rpt";
        //                    Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + "H" + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                if (getdate >= gst_date)
        //                {
        //                }
        //                else
        //                {
        //                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                }
        //                ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
        //            }

        //            else if (Str_voucher == "CN")
        //            {
        //                if (trantype == "FE")
        //                {
        //                    Str_RptName = "FEMProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                else if (trantype == "FI")
        //                {
        //                    Str_RptName = "FIMProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                else if (trantype == "AE")
        //                {
        //                    Str_RptName = "AEMProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR ";
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                else if (trantype == "AI")
        //                {
        //                    Str_RptName = "AIMProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                else if (trantype == "CH")
        //                {
        //                    Str_RptName = "CHAProCN.rpt";
        //                    Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {PAHead.vouyear}=" + int_vouyear;
        //                    Str_SP = "Lcurr=INR";
        //                    if (getdate >= gst_date)
        //                    {
        //                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + "H" + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
        //                    }
        //                }
        //                if (getdate >= gst_date)
        //                {

        //                }
        //                else
        //                {
        //                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                }
        //                ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
        //            }
        //        }
        //        if (Str_voucher == "DN")
        //        {
        //            obj_da_Log.InsLogDetail(empid, 264, 3, bid, trantype + "/" + int_vouno + "/Report");
        //        }
        //        else
        //        {
        //            obj_da_Log.InsLogDetail(empid, 265, 3, bid, trantype + "/" + int_vouno + "/Report");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}




        //GST
        protected void Grd_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*  try
              {
                  //string header = Grd_Approval.HeaderRow.Cells[5].Text;
                  //if (header == "Approve")
                  //{
                  //    return;
                  //}
                  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                  DateTime gst_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                  DateTime getdate;// = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                  getdate = Convert.ToDateTime(Grd_Approval.SelectedRow.Cells[12].Text.ToString());
                  int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                  DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                  string Str_voucher = "", strblno = "", trantype = "", str_Bl = "", Str_Container = "", header = "", bltype = "";
                  int int_vouno;
                  div = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                  bid = hrempobj.GetBranchId(div, Session["LoginBranchName"].ToString());
                  trantype = ddl_module.SelectedValue.ToString();
                  int_vouno = Convert.ToInt32(Grd_Approval.SelectedRow.Cells[1].Text.ToString());
                  double amount = Convert.ToDouble(Grd_Approval.SelectedRow.Cells[4].Text.ToString());
                  //int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
                  str_Bl = Grd_Approval.SelectedRow.Cells[2].Text;
                  if (hid_type.Value.ToString() == "Debit Note")
                  {
                      header = "DN";
                      Str_voucher = "DN";
                  }
                  else if (hid_type.Value.ToString() == "Credit Note")
                  {
                      header = "CN";
                      Str_voucher = "CN";
                  }
                  DataTable obj_dt = new DataTable();
                  DataTable obj_dttemp = new DataTable();
                  string Str_RptName, Str_SF, Str_SP, Str_Script;
                  Str_RptName = "";
                  Str_SF = "";
                  Str_SP = "";
                  Str_Script = "";

                  obj_dttemp = obj_da_Invoice.CheckHblno(str_Bl, trantype, int_bid);
                  if (obj_dttemp.Rows.Count > 0)
                  {
                      if (trantype == "FE" || trantype == "FI")
                      {
                          strblno = obj_dttemp.Rows[0]["blno"].ToString();
                      }
                      else
                      {
                          strblno = obj_dttemp.Rows[0]["hawblno"].ToString();
                      }
                  }
                  if (trantype == "FE" || trantype == "FI")
                  {
                      if (str_Bl == strblno)
                      {
                          obj_dt = obj_da_Invoice.GetHBLContainerDtls(strblno, trantype, int_bid);
                          if (obj_dt.Rows.Count > 0)
                          {
                              var Container = obj_dt.AsEnumerable().Select(row => row.Field<string>("containerno"));
                              Str_Container = string.Join("-", Container);
                          }
                      }
                  }
                  if (obj_dttemp.Rows.Count > 0)
                  {
                      bltype = "H";
                      if (Str_voucher == "DN")
                      {
                          if (trantype == "FE")
                          {
                              Str_RptName = "FEProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear;
                              //Session["str_sfs"]
                              Str_SP = "Lcurr=INR~container=" + Str_Container;
                          }
                          else if (trantype == "FI")
                          {
                              Str_RptName = "FIProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                              //Session["str_sfs"] = "{DNHead.trantype}='" + trantype + "'  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                              Str_SP = "Lcurr=INR~container=" + Str_Container;
                              // Session["str_sp"] = Str_SP;

                          }
                          else if (trantype == "AE")
                          {
                              Str_RptName = "AEProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR ";
                          }
                          else if (trantype == "AI")
                          {
                              Str_RptName = "AIProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                          }
                          else if (trantype == "CH")
                          {
                              Str_RptName = "CHAProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR~container=" + Str_Container;
                          }
                          if (getdate >= gst_date)
                          {
                              Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                          }
                          else
                          {
                              Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                          }
                          ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                      }

                      else if (Str_voucher == "CN")
                      {
                          int int_custid = 0;
                          DataTable obj_dtcn = new DataTable();
                          obj_dtcn = obj_da_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouno, bid);
                          if (obj_dtcn.Rows.Count > 0)
                          {
                              int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
                          }
                          if (trantype == "FE")
                          {
                              Str_RptName = "FEProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                              Str_SP = "Lcurr=INR~container=" + Str_Container;
                          }
                          else if (trantype == "FI")
                          {
                              Str_RptName = "FIProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "container=" + Str_Container;
                          }
                          else if (trantype == "AE")
                          {
                              Str_RptName = "AEProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                          }
                          else if (trantype == "AI")
                          {
                              Str_RptName = "AIProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR~Loccode=" + "";
                          }
                          else if (trantype == "CH")
                          {
                              Str_RptName = "CHAProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                          }
                          if (getdate >= gst_date)
                          {
                              Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                          }
                          else
                          {
                              Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                          }
                          ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                      }


                  }
                  else
                  {
                      bltype = "M";
                      if (Str_voucher == "DN")
                      {
                          if (trantype == "FE")
                          {
                              Str_RptName = "FEMProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR~container=" + Str_Container;
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          else if (trantype == "FI")
                          {
                              Str_RptName = "FIMProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR~container=" + Str_Container;
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          else if (trantype == "AE")
                          {
                              Str_RptName = "AEMProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                              Str_SP = "Lcurr=INR";
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          else if (trantype == "AI")
                          {
                              Str_RptName = "AIMProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          else if (trantype == "CH")
                          {
                              Str_RptName = "CHAProDN.rpt";
                              Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + "H" + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          if (getdate >= gst_date)
                          {
                          }
                          else
                          {
                              Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                          }
                          ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                      }

                      else if (Str_voucher == "CN")
                      {
                          if (trantype == "FE")
                          {
                              Str_RptName = "FEMProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          else if (trantype == "FI")
                          {
                              Str_RptName = "FIMProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          else if (trantype == "AE")
                          {
                              Str_RptName = "AEMProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR ";
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          else if (trantype == "AI")
                          {
                              Str_RptName = "AIMProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          else if (trantype == "CH")
                          {
                              Str_RptName = "CHAProCN.rpt";
                              Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {PAHead.vouyear}=" + int_vouyear;
                              Str_SP = "Lcurr=INR";
                              if (getdate >= gst_date)
                              {
                                  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + "H" + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                              }
                          }
                          if (getdate >= gst_date)
                          {

                          }
                          else
                          {
                              Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                          }
                          ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                      }
                  }
                  if (Str_voucher == "DN")
                  {
                      obj_da_Log.InsLogDetail(empid, 264, 3, bid, trantype + "/" + int_vouno + "/Report");
                  }
                  else
                  {
                      obj_da_Log.InsLogDetail(empid, 265, 3, bid, trantype + "/" + int_vouno + "/Report");
                  }
              }
              catch (Exception ex)
              {
                  string message = ex.Message.ToString();
                  ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
              }
             */


            try
            {
                //string header = Grd_Approval.HeaderRow.Cells[5].Text;
                //if (header == "Approve")
                //{
                //    return;
                //}
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DateTime gst_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
                DateTime getdate;// = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
                getdate = Convert.ToDateTime(Grd_Approval.SelectedRow.Cells[12].Text.ToString());
                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                string Str_voucher = "", strblno = "", trantype = "", str_Bl = "", Str_Container = "", header = "", bltype = "";
                int int_vouno;
                div = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                bid = hrempobj.GetBranchId(div, Session["LoginBranchName"].ToString());
                trantype = ddl_module.SelectedValue.ToString();
                int_vouno = Convert.ToInt32(Grd_Approval.SelectedRow.Cells[1].Text.ToString());
                double amount = Convert.ToDouble(Grd_Approval.SelectedRow.Cells[4].Text.ToString());
                int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
                str_Bl = Grd_Approval.SelectedRow.Cells[2].Text;
                if (hid_type.Value.ToString() == "Debit Note")
                {
                    header = "DN";
                    Str_voucher = "DN";
                }
                else if (hid_type.Value.ToString() == "Credit Note")
                {
                    header = "CN";
                    Str_voucher = "CN";
                }
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                string Str_RptName, Str_SF, Str_SP, Str_Script;
                Str_RptName = "";
                Str_SF = "";
                Str_SP = "";
                Str_Script = "";

                obj_dttemp = obj_da_Invoice.CheckHblno(str_Bl, trantype, int_bid);
                if (obj_dttemp.Rows.Count > 0)
                {
                    if (trantype == "FE" || trantype == "FI")
                    {
                        strblno = obj_dttemp.Rows[0]["blno"].ToString();
                    }
                    else
                    {
                        strblno = obj_dttemp.Rows[0]["hawblno"].ToString();
                    }
                }
                if (trantype == "FE" || trantype == "FI")
                {
                    if (str_Bl == strblno)
                    {
                        obj_dt = obj_da_Invoice.GetHBLContainerDtls(strblno, trantype, int_bid);
                        if (obj_dt.Rows.Count > 0)
                        {
                            var Container = obj_dt.AsEnumerable().Select(row => row.Field<string>("containerno"));
                            Str_Container = string.Join("-", Container);
                        }
                    }
                }
                if (obj_dttemp.Rows.Count > 0)
                {
                    bltype = "H";
                    if (Str_voucher == "DN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + int_bid + " and {DNHead.vouyear}=" + int_vouyear;
                            //Session["str_sfs"]
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            //Session["str_sfs"] = "{DNHead.trantype}='" + trantype + "'  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                            // Session["str_sp"] = Str_SP;

                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHAProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                        }
                        if (getdate >= gst_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }

                    else if (Str_voucher == "CN")
                    {
                        int int_custid = 0;
                        DataTable obj_dtcn = new DataTable();
                        obj_dtcn = obj_da_Invoice.ShowIPHead(int_vouno, "AC", "Pro CN", int_vouyear, bid);
                        if (obj_dtcn.Rows.Count > 0)
                        {
                            int_custid = Convert.ToInt32(obj_dtcn.Rows[0].ItemArray[4].ToString());
                        }
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "container=" + Str_Container;
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR~Loccode=" + "";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHAProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        if (getdate >= gst_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }


                }
                else
                {
                    bltype = "M";
                    if (Str_voucher == "DN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEMProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIMProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR~container=" + Str_Container;
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEMProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                            Str_SP = "Lcurr=INR";
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIMProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHAProDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + "H" + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        if (getdate >= gst_date)
                        {
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }

                    else if (Str_voucher == "CN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEMProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIMProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEMProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIMProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + bltype + "&trantype=" + trantype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHAProCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {PAHead.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                            if (getdate >= gst_date)
                            {
                                Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + str_Bl + "&bltype=" + "H" + "&header=" + header + "&trantype=" + trantype + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                            }
                        }
                        if (getdate >= gst_date)
                        {

                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }
                }
                if (Str_voucher == "DN")
                {
                    obj_da_Log.InsLogDetail(empid, 264, 3, bid, trantype + "/" + int_vouno + "/Report");
                }
                else
                {
                    obj_da_Log.InsLogDetail(empid, 265, 3, bid, trantype + "/" + int_vouno + "/Report");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }



        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {

                Grid_DNCN.DataSource = Utility.Fn_GetEmptyDataTable();
                Grid_DNCN.DataBind();
               // btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancelid1.Attributes["class"] = "btn ico-back";
                ddl_module.SelectedIndex = 0;
            }
            else
            {
                this.Response.End();
            }
        }

      /*  protected void Grid_DNCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                string Str_voucher = "", strblno = "", trantype = "", str_Bl = "", Str_Container = "", voucher = "";
                int int_vouno, int_vouyear = 0;
                div = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                bid = hrempobj.GetBranchId(div, Session["LoginBranchName"].ToString());
                trantype = ddl_module.SelectedValue.ToString();
                int_vouno = Convert.ToInt32(Grid_DNCN.SelectedRow.Cells[1].Text.ToString());
                //int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
                str_Bl = Grid_DNCN.SelectedRow.Cells[2].Text;
                if (hid_type.Value.ToString() == "Debit Note")
                {
                    Str_voucher = "DN";
                    voucher = "DNHead";
                }
                else if (hid_type.Value.ToString() == "Credit Note")
                {
                    Str_voucher = "CN";
                    voucher = "CNHead";
                }
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                string Str_RptName, Str_SF, Str_SP, Str_Script;
                Str_RptName = "";
                Str_SF = "";
                Str_SP = "";
                Str_Script = "";
                DataTable obj_dtcn = new DataTable();
                obj_dtcn = obj_da_Invoice.ShowIPHead(int_vouno, trantype, voucher, int_vouno, bid);
                if (obj_dtcn.Rows.Count > 0)
                {
                    strblno = obj_dttemp.Rows[0]["blno"].ToString();
                }
                obj_dttemp = obj_da_Invoice.CheckHblno(strblno, trantype, int_bid);


                if (obj_dttemp.Rows.Count > 0)
                {

                    if (Str_voucher == "DN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            //Session["str_sfs"]
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHADN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grid_DNCN, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }

                    else if (Str_voucher == "CN")
                    {
                        int int_custid = 0;
                        DataTable obj_dt1 = new DataTable();
                        obj_dt1 = obj_da_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouno, bid);
                        if (obj_dt1.Rows.Count > 0)
                        {
                            int_custid = Convert.ToInt32(obj_dt1.Rows[0].ItemArray[4].ToString());
                        }

                        if (trantype == "FE")
                        {
                            Str_RptName = "FECN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FICN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;

                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AECN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AICN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grid_DNCN, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }


                }
                else
                {
                    if (Str_voucher == "DN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEMDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIMDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEMDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIMDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grid_DNCN, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }

                    else if (Str_voucher == "CN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEMCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIMCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEMCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIMCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {PAHead.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grid_DNCN, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }
                }
                if (Str_voucher == "DN")
                {
                    obj_da_Log.InsLogDetail(empid, 264, 3, bid, trantype + "/" + int_vouno + "/Report");
                }
                else
                {
                    obj_da_Log.InsLogDetail(empid, 265, 3, bid, trantype + "/" + int_vouno + "/Report");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }*/

        //GST
        protected void Grid_DNCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                string Str_voucher = "", strblno = "", trantype = "", str_Bl = "", Str_Container = "", voucher = "";
                int int_vouno, int_vouyear = 0;
                div = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                bid = hrempobj.GetBranchId(div, Session["LoginBranchName"].ToString());
                trantype = ddl_module.SelectedValue.ToString();
                int_vouno = Convert.ToInt32(Grid_DNCN.SelectedRow.Cells[0].Text.ToString());
                //int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
                str_Bl = Grid_DNCN.SelectedRow.Cells[1].Text;
                if (hid_type.Value.ToString() == "Debit Note")
                {
                    Str_voucher = "DN";
                    voucher = "DNHead";
                }
                else if (hid_type.Value.ToString() == "Credit Note")
                {
                    Str_voucher = "CN";
                    voucher = "CNHead";
                }
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                string Str_RptName, Str_SF, Str_SP, Str_Script;
                Str_RptName = "";
                Str_SF = "";
                Str_SP = "";
                Str_Script = "";
                DataTable obj_dtcn = new DataTable();
                obj_dtcn = obj_da_Invoice.ShowIPHead(int_vouno, trantype, voucher, int_vouno, bid);
                if (obj_dtcn.Rows.Count > 0)
                {
                    strblno = obj_dttemp.Rows[0]["blno"].ToString();
                }
                obj_dttemp = obj_da_Invoice.CheckHblno(strblno, trantype, int_bid);


                if (obj_dttemp.Rows.Count > 0)
                {

                    if (Str_voucher == "DN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            //Session["str_sfs"]
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHADN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear + "";
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grid_DNCN, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }

                    else if (Str_voucher == "CN")
                    {
                        int int_custid = 0;
                        DataTable obj_dt1 = new DataTable();
                        obj_dt1 = obj_da_Invoice.ShowIPHead(int_vouno, "AC", "CNHead", int_vouno, bid);
                        if (obj_dt1.Rows.Count > 0)
                        {
                            int_custid = Convert.ToInt32(obj_dt1.Rows[0].ItemArray[4].ToString());
                        }

                        if (trantype == "FE")
                        {
                            Str_RptName = "FECN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear + " and {MasterCustomer.customerid}=" + int_custid;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FICN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;

                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AECN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AICN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grid_DNCN, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }


                }
                else
                {
                    if (Str_voucher == "DN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEMDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIMDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEMDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear; ;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIMDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouno + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHDN.rpt";
                            Str_SF = "{DNHead.trantype}=\"" + trantype + "\"  and {DNHead.refno}=" + int_vouno + " and {DNHead.branchid}=" + bid + " and {DNHead.vouyear}=" + int_vouyear + " and {DNDetails.branchid}=" + bid + " and {DNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grid_DNCN, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }

                    else if (Str_voucher == "CN")
                    {
                        if (trantype == "FE")
                        {
                            Str_RptName = "FEMCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "FI")
                        {
                            Str_RptName = "FIMCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "AE")
                        {
                            Str_RptName = "AEMCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR ";
                        }
                        else if (trantype == "AI")
                        {
                            Str_RptName = "AIMCN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {CNHead.vouyear}=" + int_vouyear + " and {CNDetails.branchid}=" + bid + " and {CNDetails.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        else if (trantype == "CH")
                        {
                            Str_RptName = "CHACN.rpt";
                            Str_SF = "{CNHead.trantype}=\"" + trantype + "\"  and {CNHead.refno}=" + int_vouno + " and {CNHead.branchid}=" + bid + " and {PAHead.vouyear}=" + int_vouyear;
                            Str_SP = "Lcurr=INR";
                        }
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(Grid_DNCN, typeof(GridView), "DNCNApproval", Str_Script, true);
                    }
                }
                if (Str_voucher == "DN")
                {
                    obj_da_Log.InsLogDetail(empid, 264, 3, bid, trantype + "/" + int_vouno + "/Report");
                }
                else
                {
                    obj_da_Log.InsLogDetail(empid, 265, 3, bid, trantype + "/" + int_vouno + "/Report");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        protected void Grid_DNCN_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_DNCN, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void lnk_other_Cn_Click(object sender, EventArgs e)
        {
            visible_false();
            div_ChRquApp.Visible = true;
            Grd_Approval.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Approval.DataBind();
            ddl_module.SelectedValue = "0";
            hid_type.Value = "Credit Note";
            lbl_Header.Text = "Transfer to Commercial Credit Note";
            year = logobj.GetDate();
            month = year.Month;
            if (month < 4)
            {
                int_vouyear = (year.Year) - 1;
            }
            else
            {
                int_vouyear = year.Year;
            }

        }

        protected void lnk_adminDN_Click(object sender, EventArgs e)
        {
            visible_false();
            div_DnCnApp.Visible = true;
            lblHead.Text = "Profoma DNApproval - Admin";
            hid_type.Value = "DN";
            Fn_LoadDetail1();
        }

        protected void lnk_AdminCn_Click(object sender, EventArgs e)
        {
            visible_false();
            div_DnCnApp.Visible = true;
            lblHead.Text = "Profoma CNApproval - Admin";
            hid_type.Value = "PA";
            Fn_LoadDetail1();
        }
        private void Fn_LoadDetail1()
        {
            DataAccess.Accounts.AdminDCNNo obj_da_AdminDNCN = new DataAccess.Accounts.AdminDCNNo();
            DataAccess.Accounts.ProAdminDCNNo ProDCNObj = new DataAccess.Accounts.ProAdminDCNNo();
            DataTable obj_dt = new DataTable();
            obj_dt = ProDCNObj.GetApproveProAdminDCN(hid_type.Value.ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            Grd_Admin.DataSource = obj_dt;
            Grd_Admin.DataBind();
        }
     /*   protected void btn_Approve_Click(object sender, EventArgs e)
        {
            try
            {

                int int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Vouyear = 0, int_DCno = 0, int_Voutypeid = 0;
                string Str_Trantype = Session["StrTranType"].ToString();
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                DataAccess.Accounts.ProAdminDCNNo ProDCNObj = new DataAccess.Accounts.ProAdminDCNNo();
                bool flag = true;
                List<string> Lst_DNno = new List<string>();
                foreach (GridViewRow row in Grd_Admin.Rows)
                {
                    CheckBox Chk = (CheckBox)row.FindControl("Chk_Approval");
                    if (Chk.Checked == true)
                    {
                        // int_intdcno = obj_da_Approval.GetNoforAcForApproval(int_bid, hid_type.Value.ToString());

                        int_Vouyear = int.Parse(Grd_Admin.DataKeys[row.RowIndex].Values[0].ToString());
                        int_intdcno = int.Parse(Grd_Admin.DataKeys[row.RowIndex].Values[1].ToString());
                        if (hid_type.Value.ToString() == "DN")
                        {
                            //obj_dt = obj_da_Invoice.GetPartyLedger4proPAAdmin(int_intdcno, "D", int_bid, int_Vouyear);
                            obj_dt = obj_da_Invoice.GetPartyLedger4PAPROAdminwithCust(int_intdcno, "D", int_bid, int_Vouyear);
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                chkledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), obj_dt.Rows[i]["opstype"].ToString(), Session["FADbname"].ToString());
                                if (chkledgerid == 0)
                                {
                                    flag = false;
                                }
                            }
                        }
                        if (flag == false)
                        {
                            ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "AdminDNCNApproval", "alertify.alert('LedgerName Not Found in Financial. You are not able to Approve DN " + int_intdcno + " Contact Your  Finanace Head');", true);
                        }
                        DataAccess.Accounts.AdminDCNNo obj_da_AdminDNCN = new DataAccess.Accounts.AdminDCNNo();
                        DataAccess.Accounts.ProAdminDCNNo obj_da_ProAdminDNCN = new DataAccess.Accounts.ProAdminDCNNo();
                        if (flag == true)
                        {
                            if (hid_type.Value.ToString() == "DN")
                            {
                                int_DCno = obj_da_AdminDNCN.GetAdmDNno(int_bid);
                            }
                            else
                            {
                                int_DCno = obj_da_AdminDNCN.GetAdmCNno(int_bid);
                            }


                            obj_da_ProAdminDNCN.UpdApprovalProAdminDCN(int_DCno, int_Empid, hid_type.Value.ToString(), int_Vouyear, int_bid, int_intdcno);
                            if (Session["LoginBranchName"].ToString() == "CO - ACCOUNTS")
                            {
                                if (hid_type.Value.ToString() == "PA")
                                {
                                    obj_da_Log.InsLogDetail(int_Empid, 1063, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno);
                                }
                                else
                                {
                                    obj_da_Log.InsLogDetail(int_Empid, 1062, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno);
                                }

                            }
                            else
                            {
                                if (hid_type.Value.ToString() == "PA")
                                {
                                    obj_da_Log.InsLogDetail(int_Empid, 1049, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno);
                                }
                                else
                                {
                                    obj_da_Log.InsLogDetail(int_Empid, 1050, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno);
                                }
                            }
                            Lst_DNno.Insert(row.RowIndex, int_DCno.ToString());
                        }
                    }
                    if (flag == true)
                    {
                        if (hid_type.Value.ToString() == "DN")
                        {//raj
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", int_DCno, int_DCno, "Remarks", "Ref No");
                            try
                            {
                                obj_dt = obj_da_Invoice.FAShowTallyDt(int_DCno, "DN-Admin", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                if (obj_dt.Rows.Count > 0)
                                {
                                    int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());

                                    DateTime date_Voudate = Convert.ToDateTime(obj_dt.Rows[0].ItemArray[1].ToString());
                                    int int_Ledgerid = 0;
                                    int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                    int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Admin Sales Invoice", Session["FADbname"].ToString());
                                    if (int_Ledgerid == 0)
                                    {
                                        int_Ledgerid = Fn_Getcustomergroupid1(int_custid);
                                    }
                                    obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_DCno, Convert.ToDateTime(date_Voudate.ToShortDateString()), 'X', int_Vouyear, int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0.0, int_custid);
                                }
                            }
                            catch (Exception ex)
                            {
                                // Utility.SendMail("", "", "FA RECEIPT PMT - ERROR In ProAdminDCNApproval DNAdmin # " + int_DCno + " \\Year - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                            }
                        }
                    }
                }
                if (int_DCno != 0)
                {
                    string Str_DNNO = string.Join(",", Lst_DNno);
                    if (hid_type.Value.ToString() == "DN")
                    {
                        ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "AdminDNCNApproval", "alertify.alert('DN # " + Str_DNNO + " Generated and Transfered');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "AdminDNCNApproval", "alertify.alert('CN # " + Str_DNNO + " Generated and Transfered');", true);
                    }
                    Fn_LoadDetail1();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }*/



        protected void btn_Approve_Click(object sender, EventArgs e)
        {
           /* try
            {

                int int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Vouyear = 0, int_DCno = 0, int_Voutypeid = 0, preparedby = 0;
                string Str_Trantype = Session["StrTranType"].ToString();
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                DataAccess.Accounts.ProAdminDCNNo ProDCNObj = new DataAccess.Accounts.ProAdminDCNNo();
                DataAccess.Masters.MasterEmployee Obj_Emp = new DataAccess.Masters.MasterEmployee();
                bool flag = true;
                string StrScript = "";
               

                foreach (GridViewRow row in Grd_Approval.Rows)
                {
                    CheckBox Chk = (CheckBox)row.FindControl("Chk_Approval");
                    if (Chk.Checked == true)
                    {
                        int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
                        int_intdcno = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[1].ToString());

                        preparedby = Obj_Emp.GetNEmpid(Grd_Approval.Rows[row.RowIndex].Cells[4].Text);


                        hid_stamt.Value = Grd_Approval.Rows[row.RowIndex].Cells[6].Text;
                        hid_supplyto.Value = Grd_Approval.Rows[row.RowIndex].Cells[7].Text;


                        if (preparedby == int_Empid)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You have no rights to approve Voucher # " + int_intdcno + " prepared by you')", true);
                            continue;
                        }

                        if (Session["hid_gstdate"] != null)
                        {
                            //if (hid_custtype.Value == "C")
                            //{
                            if (Convert.ToDateTime(obj_da_Log.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                            {

                                if (hid_supplyto.Value != "0")
                                {
                                    if (Convert.ToDouble(hid_stamt.Value) > 0)
                                    {

                                        int int_custidnew;
                                        DataTable dt_list = new DataTable();
                                        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                        //int int_custid = Convert.ToInt32(hdncustid.Value);
                                        if (!string.IsNullOrEmpty(row.Cells[7].Text.ToString()))
                                        {
                                            int_custidnew = Convert.ToInt32(row.Cells[7].Text.ToString());
                                            dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                        }


                                        if (dt_list.Rows.Count > 0)
                                        {
                                            if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                                            {

                                            }
                                            else
                                            {
                                                StrScript = "State Name not Updated in Master Kindly update Master Customer ";
                                                ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            StrScript = "State Name not Updated in Master Kindly update Master Customer";
                                            ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                            continue;
                                        }


                                    }
                                }
                                else
                                {
                                    StrScript = "Kindly Update SupplyTo Customer for the Voucher # " + int_intdcno;
                                    ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                    continue;
                                }
                            }
                            //}
                        }



                        if (hid_type.Value.ToString() == "DN")
                        {
                            obj_dt = obj_da_Invoice.GetPartyLedger4PAPROAdminwithCust(int_intdcno, "D", int_bid, int_Vouyear);
                        }

                        if (obj_dt.Rows.Count > 0)
                        {
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                chkledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), obj_dt.Rows[i]["opstype"].ToString(), Session["FADbname"].ToString());
                                if (chkledgerid == 0)
                                {
                                    flag = false;
                                }
                            }
                        }

                        DataAccess.Accounts.AdminDCNNo obj_da_AdminDNCN = new DataAccess.Accounts.AdminDCNNo();
                        DataAccess.Accounts.ProAdminDCNNo obj_da_ProAdminDNCN = new DataAccess.Accounts.ProAdminDCNNo();
                        if (flag == true)
                        {
                            if (hid_type.Value.ToString() == "DN")
                            {
                                int_DCno = obj_da_AdminDNCN.GetAdmDNno(int_bid);
                            }
                            else
                            {
                                int_DCno = obj_da_AdminDNCN.GetAdmCNno(int_bid);
                            }

                            obj_da_ProAdminDNCN.UpdApprovalProAdminDCN(int_DCno, int_Empid, hid_type.Value.ToString(), int_Vouyear, int_bid, int_intdcno);


                            if (hid_type.Value.ToString() == "PA")
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1049, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno + "/Approve");
                            }
                            else
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1050, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno + "/Approve");
                            }


                            Lst_DNno += int_DCno + ",";
                        }

                        if (flag == true)
                        {
                            if (hid_type.Value.ToString() == "DN")
                            {
                                //raj
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", int_DCno, int_DCno, "Remarks", "Ref No");

                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_DCno, "DN-Admin", int.Parse(Session["Vouyear"].ToString()), int_bid);

                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());

                                        DateTime date_Voudate = Convert.ToDateTime(obj_dt.Rows[0].ItemArray[1].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());

                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Admin Sales Invoice", Session["FADbname"].ToString());
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_DCno, Convert.ToDateTime(date_Voudate.ToShortDateString()), 'X', int_Vouyear, int_bid, double.Parse(row.Cells[4].Text.ToString()), "", 0.0, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //Utility.SendMail("", "", "FA RECEIPT PMT - ERROR In ProAdminDCNApproval DNAdmin # " + int_DCno + " \\Year - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                            }
                            else if (hid_type.Value.ToString() == "PA")
                            {
                                DataTable dt_Credit = new DataTable();
                                dt_Credit = obj_da_Approval.GetAgentCustomerOrNot(int_DCno, int_Vouyear, int_bid, "AC");

                                if (dt_Credit.Rows.Count > 0)
                                {
                                    customerid = Convert.ToInt32(dt_Credit.Rows[0]["customerid"].ToString());
                                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Purchase Invoice", int_DCno, int_DCno, "Remarks", "Ref No");

                                    try
                                    {
                                        DateTime padat, Vou_Date;
                                        DataTable DtSHead = new DataTable();
                                        DataTable dcndt = new DataTable();
                                        int custid = 0;
                                        DtSHead = obj_da_Invoice.FAShowTallyDt(int_DCno, "PA-Admin", int_Vouyear, int_bid);
                                        if (DtSHead.Rows.Count > 0)
                                        {
                                            custid = Convert.ToInt32(DtSHead.Rows[0]["customerid"].ToString());
                                        }
                                        int chkledgerid = 0;

                                        chkledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(customerid, "C", Session["FADbname"].ToString());
                                        if (chkledgerid == 0)
                                        {
                                            chkledgerid = Fn_Getcustomergroupid(custid);
                                        }
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Admin Purchase Invoice", Session["FADbname"].ToString());

                                        string custtype = "", fcur = "";
                                        double famt = 0.00, exrate;

                                        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                                        custtype = obj_da_Customer.GetCustomerType(customerid);

                                        if (custtype == "P")
                                        {
                                            dcndt = obj_da_Invoice.GetOtherDCNAmount(int_DCno, "ACNHead", int_bid, int_Vouyear);

                                            fcur = "";
                                            famt = 0.0;
                                            exrate = 0.0;
                                            if (dcndt.Rows.Count > 0)
                                            {
                                                fcur = dcndt.Rows[0]["curr"].ToString();
                                                famt = Convert.ToDouble(dcndt.Rows[0]["amt"].ToString());
                                                exrate = Convert.ToDouble(dcndt.Rows[0]["exrate"].ToString());
                                            }
                                            obj_da_Approval.InsLedgerOPBreakup(chkledgerid, int_DCno, Convert.ToDateTime(DtSHead.Rows[0]["cndate"].ToString()), 'S', int_Vouyear, int_bid, Convert.ToDouble(row.Cells[4].Text.ToString()), fcur, famt, customerid);
                                        }
                                        else
                                        {
                                            obj_da_Approval.InsLedgerOPBreakup(chkledgerid, int_DCno, Convert.ToDateTime(DtSHead.Rows[0]["cndate"].ToString()), 'S', int_Vouyear, int_bid, Convert.ToDouble(row.Cells[4].Text.ToString()), "", 0.0, customerid);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //Utility.SendMail("", "", "FA RECEIPT PMT - ERROR In ProAdminDCNApproval DNAdmin # " + int_DCno + " \\Year - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }

                if (int_DCno != 0)
                {
                    string Str_DNNO = Lst_DNno;

                    if (Str_DNNO != "")
                    {
                        string last = Str_DNNO.Substring(Str_DNNO.Length - 1, 1);

                        if (last == ",")
                        {
                            Str_DNNO = Str_DNNO.Substring(0, Str_DNNO.Length - 1);
                        }
                    }

                    if (hid_type.Value.ToString() == "DN")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AdminDNCNApproval", "alertify.alert('DN # " + Str_DNNO + " Generated and Transfered');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AdminDNCNApproval", "alertify.alert('CN # " + Str_DNNO + " Generated and Transfered');", true);
                    }
                    Fn_LoadDetail();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }*/

            try
            {

                string chargename = "";
                int gsttype = 0, statename = 0, supplyto = 0;
                string gsttype_ = "", statename_ = "", supplyto_ = "";
                int int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Vouyear = 0, int_DCno = 0, int_Voutypeid = 0, preparedby = 0;
                string Str_Trantype = Session["StrTranType"].ToString();
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                DataAccess.Accounts.ProAdminDCNNo ProDCNObj = new DataAccess.Accounts.ProAdminDCNNo();
                DataAccess.Masters.MasterEmployee Obj_Emp = new DataAccess.Masters.MasterEmployee();
                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                bool flag = true;
                string StrScript = "";
                string cutname = "";

                foreach (GridViewRow row in Grd_Admin.Rows)
                {
                    CheckBox Chk = (CheckBox)row.FindControl("Chk_Approval");
                    if (Chk.Checked == true)
                    {
                        int_Vouyear = int.Parse(Grd_Admin.DataKeys[row.RowIndex].Values[0].ToString());
                        int_intdcno = int.Parse(Grd_Admin.DataKeys[row.RowIndex].Values[1].ToString());

                        preparedby = Obj_Emp.GetNEmpid(Grd_Admin.Rows[row.RowIndex].Cells[5].Text);


                        hid_stamt.Value = Grd_Admin.Rows[row.RowIndex].Cells[7].Text;
                        hid_supplyto.Value = Grd_Admin.Rows[row.RowIndex].Cells[8].Text;
                        if (hid_supplyto.Value != "0")
                        {
                            cutname = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                        }
                        if (preparedby == int_Empid)
                        {
                           // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('You have no rights to approve Voucher # " + int_intdcno + " prepared by you')", true);
                            StrScript +="You have no rights to approve Voucher # " + int_intdcno + " prepared by you";
                            continue;
                        }

                        if (Session["hid_gstdate"] != null)
                        {
                            //if (hid_custtype.Value == "C")
                            //{
                            if (Convert.ToDateTime(obj_da_Log.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                            {

                                if (hid_supplyto.Value != "0")
                                {
                                    if (Convert.ToDouble(hid_stamt.Value) > 0)
                                    {

                                        int int_custidnew;
                                        DataTable dt_list = new DataTable();
                                        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                        //int int_custid = Convert.ToInt32(hdncustid.Value);
                                        if (!string.IsNullOrEmpty(row.Cells[8].Text.ToString()))
                                        {
                                            int_custidnew = Convert.ToInt32(row.Cells[8].Text.ToString());
                                            dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                        }


                                        if (dt_list.Rows.Count > 0)
                                        {
                                            if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                            {
                                                if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                {
                                                    //StrScript = "GST TYPE not Updated for the Customer Name :" + Grd_Approval.Rows[row.RowIndex].Cells[2].Text + " in the Voucher #" + int_intdcno;
                                                    //continue;
                                                    if (gsttype == 0)
                                                    {
                                                        gsttype_ = cutname;
                                                    }
                                                    else
                                                    {
                                                        gsttype_ = " ," + cutname;
                                                    }
                                                    gsttype = 1;
                                                    //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                //StrScript = "State Name not Updated in Master Kindly update Master Customer ";
                                                ////ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);
                                                //continue;
                                                if (statename == 0)
                                                {
                                                    statename_ = cutname;
                                                }
                                                else
                                                {
                                                    statename_ = " ," + cutname;
                                                }
                                                statename = 1;
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            //StrScript = "State Name not Updated in Master Kindly update Master Customer";
                                            ////ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                            //continue;

                                            if (statename == 0)
                                            {
                                                statename_ = cutname;
                                            }
                                            else
                                            {
                                                statename_ = " ," + cutname;
                                            }
                                            statename = 1;
                                            continue;
                                        }


                                    }
                                }
                                else
                                {
                                    //StrScript = "Kindly Update SupplyTo Customer for the Voucher # " + int_intdcno;
                                    ////ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                                    //continue;
                                    if (supplyto == 0)
                                    {
                                        supplyto_ = int_intdcno.ToString();
                                    }
                                    else
                                    {
                                        supplyto_ = " ," + int_intdcno.ToString();
                                    }
                                    supplyto = 1;
                                    continue;
                                }
                            }
                            //}
                        }



                        if (hid_type.Value.ToString() == "DN")
                        {
                            obj_dt = obj_da_Invoice.GetPartyLedger4PAPROAdminwithCust(int_intdcno, "D", int_bid, int_Vouyear);
                        }

                        if (obj_dt.Rows.Count > 0)
                        {
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                chkledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), obj_dt.Rows[i]["opstype"].ToString(), Session["FADbname"].ToString());
                                if (chkledgerid == 0)
                                {
                                    if (chargename == "")
                                    {
                                        chargename = obj_dt.Rows[i]["chargename"].ToString();
                                    }
                                    else
                                    {
                                        if (chargename.Contains(obj_dt.Rows[i]["chargename"].ToString()))
                                        {

                                        }
                                        else
                                        {
                                            chargename += " ," + obj_dt.Rows[i]["chargename"].ToString();
                                        }

                                    }
                                    flag = false;
                                }
                            }
                        }

                        DataAccess.Accounts.AdminDCNNo obj_da_AdminDNCN = new DataAccess.Accounts.AdminDCNNo();
                        DataAccess.Accounts.ProAdminDCNNo obj_da_ProAdminDNCN = new DataAccess.Accounts.ProAdminDCNNo();
                        if (flag == true)
                        {
                            if (hid_type.Value.ToString() == "DN")
                            {
                                int_DCno = obj_da_AdminDNCN.GetAdmDNno(int_bid);
                            }
                            else
                            {
                                int_DCno = obj_da_AdminDNCN.GetAdmCNno(int_bid);
                            }

                            obj_da_ProAdminDNCN.UpdApprovalProAdminDCN(int_DCno, int_Empid, hid_type.Value.ToString(), int_Vouyear, int_bid, int_intdcno);


                            if (hid_type.Value.ToString() == "PA")
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1049, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno + "/Approve");
                            }
                            else
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1050, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno + "/Approve");
                            }


                            Lst_DNno += int_DCno + ",";
                        }

                        if (flag == true)
                        {
                            if (hid_type.Value.ToString() == "DN")
                            {
                                //raj
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", int_DCno, int_DCno, "Remarks", "Ref No", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_DCno, "DN-Admin", int.Parse(Session["Vouyear"].ToString()), int_bid);

                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());

                                        DateTime date_Voudate = Convert.ToDateTime(obj_dt.Rows[0].ItemArray[1].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());

                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Admin Sales Invoice", Session["FADbname"].ToString());
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_DCno, Convert.ToDateTime(date_Voudate.ToShortDateString()), 'X', int_Vouyear, int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0.0, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //Utility.SendMail("", "", "FA RECEIPT PMT - ERROR In ProAdminDCNApproval DNAdmin # " + int_DCno + " \\Year - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                            }
                            else if (hid_type.Value.ToString() == "PA")
                            {
                                DataTable dt_Credit = new DataTable();
                                dt_Credit = obj_da_Approval.GetAgentCustomerOrNot(int_DCno, int_Vouyear, int_bid, "AC");

                                if (dt_Credit.Rows.Count > 0)
                                {
                                    customerid = Convert.ToInt32(dt_Credit.Rows[0]["customerid"].ToString());
                                    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Purchase Invoice", int_DCno, int_DCno, "Remarks", "Ref No", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    try
                                    {
                                        DateTime padat, Vou_Date;
                                        DataTable DtSHead = new DataTable();
                                        DataTable dcndt = new DataTable();
                                        int custid = 0;
                                        DtSHead = obj_da_Invoice.FAShowTallyDt(int_DCno, "PA-Admin", int_Vouyear, int_bid);
                                        if (DtSHead.Rows.Count > 0)
                                        {
                                            custid = Convert.ToInt32(DtSHead.Rows[0]["customerid"].ToString());
                                        }
                                        int chkledgerid = 0;

                                        chkledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(customerid, "C", Session["FADbname"].ToString());
                                        if (chkledgerid == 0)
                                        {
                                            chkledgerid = Fn_Getcustomergroupid(custid);
                                        }
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Admin Purchase Invoice", Session["FADbname"].ToString());

                                        string custtype = "", fcur = "";
                                        double famt = 0.00, exrate;


                                        custtype = obj_da_Customer.GetCustomerType(customerid);

                                        if (custtype == "P")
                                        {
                                            dcndt = obj_da_Invoice.GetOtherDCNAmount(int_DCno, "ACNHead", int_bid, int_Vouyear);

                                            fcur = "";
                                            famt = 0.0;
                                            exrate = 0.0;
                                            if (dcndt.Rows.Count > 0)
                                            {
                                                fcur = dcndt.Rows[0]["curr"].ToString();
                                                famt = Convert.ToDouble(dcndt.Rows[0]["amt"].ToString());
                                                exrate = Convert.ToDouble(dcndt.Rows[0]["exrate"].ToString());
                                            }
                                            obj_da_Approval.InsLedgerOPBreakup(chkledgerid, int_DCno, Convert.ToDateTime(DtSHead.Rows[0]["cndate"].ToString()), 'S', int_Vouyear, int_bid, Convert.ToDouble(row.Cells[4].Text.ToString()), fcur, famt, customerid);
                                        }
                                        else
                                        {
                                            obj_da_Approval.InsLedgerOPBreakup(chkledgerid, int_DCno, Convert.ToDateTime(DtSHead.Rows[0]["cndate"].ToString()), 'S', int_Vouyear, int_bid, Convert.ToDouble(row.Cells[4].Text.ToString()), "", 0.0, customerid);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //Utility.SendMail("", "", "FA RECEIPT PMT - ERROR In ProAdminDCNApproval DNAdmin # " + int_DCno + " \\Year - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                    }
                                }

                            }
                        }
                    }
                }

                if (int_DCno != 0)
                {
                    string Str_DNNO = Lst_DNno;


                    if (chargename.Length > 0)
                    {
                        StrScript += "LedgerName Not Found in Financial for charge " + chargename;
                    }
                    if (Str_DNNO != "")
                    {
                        string last = Str_DNNO.Substring(Str_DNNO.Length - 1, 1);

                        if (last == ",")
                        {
                            Str_DNNO = Str_DNNO.Substring(0, Str_DNNO.Length - 1);
                        }
                    }

                    if (gsttype == 1)
                    {
                        StrScript += "GST TYPE not Updated for the Customer Name :" + gsttype_;
                    }
                    if (supplyto == 1)
                    {
                        StrScript += "State Name not Updated in Master Kindly update Master Customer for" + supplyto_;
                    }
                    if (statename == 1)
                    {
                        StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + statename_;
                    }

                    StrScript += "DN # " + Str_DNNO + " Generated and Transfered";

                    if (hid_type.Value.ToString() == "DN")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AdminDNCNApproval", "alertify.alert('" + StrScript + "');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AdminDNCNApproval", "alertify.alert('" + StrScript + "');", true);
                    }
                    Fn_LoadDetail1();
                }
                else
                {


                    if (chargename.Length > 0)
                    {
                        StrScript += "LedgerName Not Found in Financial for charge " + chargename;
                    }
                    if (gsttype == 1)
                    {
                        StrScript += "GST TYPE not Updated for the Customer Name :" + gsttype_;
                    }
                    if (statename == 1)
                    {
                        StrScript += "State Name not Updated in Master Kindly update Master Customer for" + statename_;
                    }
                    if (supplyto == 1)
                    {
                        StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + supplyto_;
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "AdminDNCNApproval", "alertify.alert('" + StrScript + "');", true);


                    Fn_LoadDetail1();
                }

                if (Session["usermailid"].ToString() != "" || Session["usermailpwd"].ToString() != "")
                {
                    Utility.SendMail(Session["usermailid"].ToString(), Session["usermailid"].ToString(), "Approve " + StrScript + " \\Year - " + Session["Vouyear"].ToString() + " \\Branch - " + Session["LoginBranchName"].ToString(), "Approve " + StrScript + " \\Year - " + Session["Vouyear"].ToString() + " \\Branch - " + Session["LoginBranchName"].ToString(), "", Session["usermailpwd"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }





        }

        private int Fn_Getcustomergroupid1(int int_Custid)
        {
            int int_Subgroupid = 0, int_Groupid = 0, int_Ledgerid = 0;
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            if (hid_type.Value.ToString() == "DN")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;

                int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid), int_Subgroupid, int_Groupid, 'G', int_Custid, 'C', Session["FADbname"].ToString());
            }
            return int_Ledgerid;
        }

        protected void btn_cancel1_Click(object sender, EventArgs e)
        {
            if (btn_cancel1.ToolTip == "Cancel")
            {
                Grd_Admin.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Admin.DataBind();
                //btn_cancel1.Text = "Back";
                btn_cancel1.ToolTip = "Back";
                btn_cancel11.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }



        protected void Grd_Admin_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }

        protected void Lnk_unclosed_Click(object sender, EventArgs e)
        {
            exp2excGrd_Deposite.Visible = false;
            visible_false();
            div_UnClos.Visible = true;
            Panel13.Visible = true;
            int necount1 = 0, nicount1 = 0, fecount1 = 0, ficount1 = 0, chcount1 = 0;
            string Strtrantype = Session["StrTranType"].ToString();
            int intcount = 0;
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Product") });
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("UnClosed Jobs") });
            //dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Operation Profit") });
            //dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Amount") });

            //dt = da_obj_misgrd.GetOperatingProfit(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), "AC", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            //dt1.Rows.Add();
            //dt1.Rows[dt1.Rows.Count - 1]["Operation Profit"] = "AE";
            //double amt = (Convert.ToDouble(dt.Rows[0]["AE"].ToString()));
            dt = Approveobj.GetPenUnClose("AC", branchid, 0, logempid);
            hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (dt.Rows[i]["trantype"].ToString() == "AE") { necount1 = necount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "AI") { nicount1 = nicount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "FE") { fecount1 = fecount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "FI") { ficount1 = ficount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "CH") { chcount1 = chcount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "AC") { chcount1 = chcount1 + 1; }
            }
            //grdunclosejobs.Rows(0).Cells(0).Value = "AE Jobs" + "(" + necount1 + ")"
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "AE";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = necount1;
            //double amt = (Convert.ToDouble(dt.Rows[0]["AE"].ToString()));
            // dt1.Rows.Add("AE Jobs" + "(" + necount1 + ")");
            //grdunclosejobs.Rows(1).Cells(0).Value = "AI Jobs" + "(" + nicount1 + ")"
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "AI";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = nicount1;
            // dt1.Rows.Add("AI Jobs" + "(" + nicount1 + ")");
            //grdunclosejobs.Rows(2).Cells(0).Value = "FE Jobs" + "(" + fecount1 + ")"
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "OE";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = fecount1;
            // dt1.Rows.Add("FE Jobs" + "(" + fecount1 + ")");
            //grdunclosejobs.Rows(3).Cells(0).Value = "FI Jobs" + "(" + ficount1 + ")"
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "OI";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = ficount1;
            // dt1.Rows.Add("FI Jobs" + "(" + ficount1 + ")");
            //grdunclosejobs.Rows(4).Cells(0).Value = "CH Jobs" + "(" + chcount1 + ")"
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "CH";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = chcount1;
            //dt1.Rows.Add("CH Jobs" + "(" + chcount1 + ")");
            // dt1.Rows.Add("AC Jobs" + "(" + chcount1 + ")");
            int total = necount1 + nicount1 + fecount1 + ficount1 + chcount1;
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "Total";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = total.ToString();
            grdunclosejobs.DataSource = dt1;
            grdunclosejobs.DataBind();
        }

        protected void Lnk_coll_Click(object sender, EventArgs e)
        {
            double amt = 0;
            visible_false();
            pnl_RecCol.Visible = true;
            div_CollRecpt.Visible = true;
            DataAccess.LogDetails logobj = new DataAccess.LogDetails();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            //int month = Todate.Month;
            //int year = Todate.Year;
            //DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            DataTable DtobjReceipt = new DataTable();
            //DateTime.Now.AddDays(-1)
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("Si");
            dtemptyfree.Columns.Add("recptno");
            dtemptyfree.Columns.Add("mode");
            dtemptyfree.Columns.Add("customer");
            dtemptyfree.Columns.Add("chequeno");
            dtemptyfree.Columns.Add("amount");
            DataRow dr = dtemptyfree.NewRow();
            string mode = "";
            DtobjReceipt = objReceipt.GetPartiCulRecpt(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), DateTime.Now.AddDays(-1));
            if (DtobjReceipt.Rows.Count > 0)
            {
                for (int j = 0; j <= DtobjReceipt.Rows.Count - 1; j++)
                {


                    dtemptyfree.Rows.Add();
                    dr = dtemptyfree.NewRow();
                    dtemptyfree.Rows[j]["Si"] = DtobjReceipt.Rows[j]["Si"].ToString();
                    dtemptyfree.Rows[j]["recptno"] = DtobjReceipt.Rows[j]["recptno"].ToString();
                    if (DtobjReceipt.Rows[j]["mode"].ToString() == "B")
                    {
                        mode = "Bank";
                    }
                    else if (DtobjReceipt.Rows[j]["mode"].ToString() == "C")
                    {
                        mode = "Cash";
                    }
                    else
                    {
                        mode = "Petty cash";
                    }

                    dtemptyfree.Rows[j]["mode"] = mode;
                    dtemptyfree.Rows[j]["customer"] = DtobjReceipt.Rows[j]["customer"].ToString();
                    dtemptyfree.Rows[j]["chequeno"] = DtobjReceipt.Rows[j]["chequeno"].ToString();
                    dtemptyfree.Rows[j]["amount"] = (Convert.ToDouble(DtobjReceipt.Rows[j]["amount"].ToString())).ToString("#,0.00");
                    amt = amt + Convert.ToDouble(DtobjReceipt.Rows[j]["amount"].ToString());


                }
                dtemptyfree.Rows.Add(dr);
                dtemptyfree.Rows[DtobjReceipt.Rows.Count]["recptno"] = "Total";
                dtemptyfree.Rows[DtobjReceipt.Rows.Count]["Amount"] = amt.ToString("#,0.00");
                grd_RecOll.DataSource = dtemptyfree;
                grd_RecOll.DataBind();
            }
            else
            {
                grd_RecOll.DataSource = new DataTable();
                grd_RecOll.DataBind();
            }

            ViewState["GrdCollections"] = dtemptyfree;
        }

        protected void lnkoutstAE_Click(object sender, EventArgs e)
        {
            visible_false();
            excportexc.Visible = true;
            grd_AirImports.Visible = true;
            penBlRelase.Visible = true;
            headlbl1.Visible = true;
            lbl_cut.Text = "Air Exports";
            lbl_cut.Attributes.Add("style", "color:#16365c");
            DataTable dt_OprProfit = new DataTable();
            DataTable dt = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //string transtype = Session["StrTranType"].ToString();
            DateTime Todate = Convert.ToDateTime(obj_da_Log.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
           // int month = 03;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            int count;
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("S#");
            dtemptyfree.Columns.Add("Branch");
            dtemptyfree.Columns.Add("Product");
            dtemptyfree.Columns.Add("Job #");
            dtemptyfree.Columns.Add("Opend On");
            dtemptyfree.Columns.Add("VSL/Voy");
            // dtemptyfree.Columns.Add("ETA");
            //dtemptyfree.Columns.Add("ETD");
            dtemptyfree.Columns.Add("Closed On");
            dtemptyfree.Columns.Add("Income");
            dtemptyfree.Columns.Add("Expenses");
            dtemptyfree.Columns.Add("Retention");
            //   dt_OprProfit = da_obj_misgrd.Getshipmentnewhome(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), "AE", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            dt_OprProfit = da_obj_misgrd.Getshipmentnewhome("AE", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
            if (dt_OprProfit.Rows.Count > 0)
            {
                //GridView1.DataSource = dt_OprProfit;
                //GridView1.DataBind();

                DataRow dr = dtemptyfree.NewRow();
                if (dt_OprProfit.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt_OprProfit.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt_OprProfit.Rows[j]["S#"].ToString();
                        dtemptyfree.Rows[j]["Branch"] = dt_OprProfit.Rows[j]["Branch"].ToString();
                        dtemptyfree.Rows[j]["Product"] = dt_OprProfit.Rows[j]["Product"].ToString();
                        dtemptyfree.Rows[j]["Job #"] = dt_OprProfit.Rows[j]["JOBNO"].ToString();
                        dtemptyfree.Rows[j]["Opend On"] = dt_OprProfit.Rows[j]["OpenedON"].ToString();
                        //dtemptyfree.Rows[j]["VSL/Voy"] = dt_OprProfit.Rows[j]["VLSorVOY"].ToString();
                        dtemptyfree.Rows[j]["VSL/Voy"] = dt_OprProfit.Rows[j]["VSLorVOY"].ToString();
                        // dtemptyfree.Rows[j]["ETA"] = dt_OprProfit.Rows[j]["ETA"].ToString();
                        // dtemptyfree.Rows[j]["ETD"] = dt_OprProfit.Rows[j]["ETD"].ToString();
                        dtemptyfree.Rows[j]["Closed On"] = dt_OprProfit.Rows[j]["ClosedON"].ToString();
                        dtemptyfree.Rows[j]["Income"] = dt_OprProfit.Rows[j]["Income"].ToString();
                        dtemptyfree.Rows[j]["Expenses"] = dt_OprProfit.Rows[j]["Expense"].ToString();
                        dtemptyfree.Rows[j]["Retention"] = dt_OprProfit.Rows[j]["Retention"].ToString();

                    }

                    GridView2.DataSource = dtemptyfree;
                    GridView2.DataBind();
                }
            }
            else
            {
                GridView2.DataSource = dtemptyfree;
                GridView2.DataBind();
            }

            ViewState["GrdExp2exc"] = dtemptyfree;

        }

        protected void lnkoutstAI_Click(object sender, EventArgs e)
        {
            visible_false();
            excportexc.Visible = true;
            grd_AirImports.Visible = true;
            penBlRelase.Visible = true;
            headlbl1.Visible = true;
            lbl_cut.Text = "Air Imports";
            lbl_cut.Attributes.Add("style", "color:#963634");
            DataTable dt_OprProfit = new DataTable();
            DataTable dt = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //string transtype = Session["StrTranType"].ToString();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            int count;
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("S#");
            dtemptyfree.Columns.Add("Branch");
            dtemptyfree.Columns.Add("Product");
            dtemptyfree.Columns.Add("Job #");
            dtemptyfree.Columns.Add("Opend On");
            dtemptyfree.Columns.Add("VSL/Voy");
            // dtemptyfree.Columns.Add("ETA");
            // dtemptyfree.Columns.Add("ETD");
            dtemptyfree.Columns.Add("Closed On");
            dtemptyfree.Columns.Add("Income");
            dtemptyfree.Columns.Add("Expenses");
            dtemptyfree.Columns.Add("Retention");
            //   dt_OprProfit = da_obj_misgrd.Getshipmentnewhome(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), "AE", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            dt_OprProfit = da_obj_misgrd.Getshipmentnewhome("AI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
            if (dt_OprProfit.Rows.Count > 0)
            {
                //GridView1.DataSource = dt_OprProfit;
                //GridView1.DataBind();

                DataRow dr = dtemptyfree.NewRow();
                if (dt_OprProfit.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt_OprProfit.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt_OprProfit.Rows[j]["S#"].ToString();
                        dtemptyfree.Rows[j]["Branch"] = dt_OprProfit.Rows[j]["Branch"].ToString();
                        dtemptyfree.Rows[j]["Product"] = dt_OprProfit.Rows[j]["Product"].ToString();
                        dtemptyfree.Rows[j]["Job #"] = dt_OprProfit.Rows[j]["JOBNO"].ToString();
                        dtemptyfree.Rows[j]["Opend On"] = dt_OprProfit.Rows[j]["OpenedON"].ToString();
                        dtemptyfree.Rows[j]["VSL/Voy"] = dt_OprProfit.Rows[j]["VSLorVOY"].ToString();
                        //dtemptyfree.Rows[j]["ETA"] = dt_OprProfit.Rows[j]["ETA"].ToString();
                        //dtemptyfree.Rows[j]["ETD"] = dt_OprProfit.Rows[j]["ETD"].ToString();
                        dtemptyfree.Rows[j]["Closed On"] = dt_OprProfit.Rows[j]["ClosedON"].ToString();
                        dtemptyfree.Rows[j]["Income"] = dt_OprProfit.Rows[j]["Income"].ToString();
                        dtemptyfree.Rows[j]["Expenses"] = dt_OprProfit.Rows[j]["Expense"].ToString();
                        dtemptyfree.Rows[j]["Retention"] = dt_OprProfit.Rows[j]["Retention"].ToString();

                    }

                    GridView2.DataSource = dtemptyfree;
                    GridView2.DataBind();
                }
            }
            else
            {
                GridView2.DataSource = dtemptyfree;
                GridView2.DataBind();
            }

            ViewState["GrdExp2exc"] = dtemptyfree;
        }

        protected void lnkoutstBT_Click(object sender, EventArgs e)
        {
            visible_false();
            excportexc.Visible = true;
            grd_AirImports.Visible = true;
            penBlRelase.Visible = true;
            headlbl1.Visible = true;
            lbl_cut.Text = "Bounded Trucking";
            lbl_cut.Attributes.Add("style", "color:#8a933c");
            DataTable dt_OprProfit = new DataTable();
            DataTable dt = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //string transtype = Session["StrTranType"].ToString();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            int count;
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("S#");
            dtemptyfree.Columns.Add("Branch");
            dtemptyfree.Columns.Add("Product");
            dtemptyfree.Columns.Add("Job #");
            dtemptyfree.Columns.Add("Opend On");
            dtemptyfree.Columns.Add("VSL/Voy");
            // dtemptyfree.Columns.Add("ETA");
            //dtemptyfree.Columns.Add("ETD");
            dtemptyfree.Columns.Add("Closed On");
            dtemptyfree.Columns.Add("Income");
            dtemptyfree.Columns.Add("Expenses");
            dtemptyfree.Columns.Add("Retention");
            //   dt_OprProfit = da_obj_misgrd.Getshipmentnewhome(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), "AE", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            dt_OprProfit = da_obj_misgrd.Getshipmentnewhome("BT", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
            if (dt_OprProfit.Rows.Count > 0)
            {
                //GridView1.DataSource = dt_OprProfit;
                //GridView1.DataBind();
                DataRow dr = dtemptyfree.NewRow();
                if (dt_OprProfit.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt_OprProfit.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt_OprProfit.Rows[j]["S#"].ToString();
                        dtemptyfree.Rows[j]["Branch"] = dt_OprProfit.Rows[j]["Branch"].ToString();
                        dtemptyfree.Rows[j]["Product"] = dt_OprProfit.Rows[j]["Product"].ToString();
                        dtemptyfree.Rows[j]["Job #"] = dt_OprProfit.Rows[j]["JOBNO"].ToString();
                        dtemptyfree.Rows[j]["Opend On"] = dt_OprProfit.Rows[j]["OpenedON"].ToString();
                        dtemptyfree.Rows[j]["VSL/Voy"] = dt_OprProfit.Rows[j]["VSLorVOY"].ToString();
                        // dtemptyfree.Rows[j]["ETA"] = dt_OprProfit.Rows[j]["ETA"].ToString();
                        //dtemptyfree.Rows[j]["ETD"] = dt_OprProfit.Rows[j]["ETD"].ToString();
                        dtemptyfree.Rows[j]["Closed On"] = dt_OprProfit.Rows[j]["ClosedON"].ToString();
                        dtemptyfree.Rows[j]["Income"] = dt_OprProfit.Rows[j]["Income"].ToString();
                        dtemptyfree.Rows[j]["Expenses"] = dt_OprProfit.Rows[j]["Expense"].ToString();
                        dtemptyfree.Rows[j]["Retention"] = dt_OprProfit.Rows[j]["Retention"].ToString();

                    }

                    GridView2.DataSource = dtemptyfree;
                    GridView2.DataBind();
                }
            }
            else
            {
                GridView2.DataSource = dtemptyfree;
                GridView2.DataBind();


            }
            ViewState["GrdExp2exc"] = dtemptyfree;
        }

        protected void lnkoutstCH_Click(object sender, EventArgs e)
        {
            visible_false();
            excportexc.Visible = true;
            grd_AirImports.Visible = true;
            penBlRelase.Visible = true;
            headlbl1.Visible = true;
            lbl_cut.Text = "CHA";
            lbl_cut.Attributes.Add("style", "color:#60497a");
            DataTable dt_OprProfit = new DataTable();
            DataTable dt = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //string transtype = Session["StrTranType"].ToString();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            int count;
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("S#");
            dtemptyfree.Columns.Add("Branch");
            dtemptyfree.Columns.Add("Product");
            dtemptyfree.Columns.Add("Job #");
            dtemptyfree.Columns.Add("Opend On");
            dtemptyfree.Columns.Add("VSL/Voy");
            // dtemptyfree.Columns.Add("ETA");
            //dtemptyfree.Columns.Add("ETD");
            dtemptyfree.Columns.Add("Closed On");
            dtemptyfree.Columns.Add("Income");
            dtemptyfree.Columns.Add("Expenses");
            dtemptyfree.Columns.Add("Retention");
            //   dt_OprProfit = da_obj_misgrd.Getshipmentnewhome(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), "AE", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            dt_OprProfit = da_obj_misgrd.Getshipmentnewhome("CH", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
            if (dt_OprProfit.Rows.Count > 0)
            {
                //GridView1.DataSource = dt_OprProfit;
                //GridView1.DataBind();

                DataRow dr = dtemptyfree.NewRow();
                if (dt_OprProfit.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt_OprProfit.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt_OprProfit.Rows[j]["S#"].ToString();
                        dtemptyfree.Rows[j]["Branch"] = dt_OprProfit.Rows[j]["Branch"].ToString();
                        dtemptyfree.Rows[j]["Product"] = dt_OprProfit.Rows[j]["Product"].ToString();
                        dtemptyfree.Rows[j]["Job #"] = dt_OprProfit.Rows[j]["JOBNO"].ToString();
                        dtemptyfree.Rows[j]["Opend On"] = dt_OprProfit.Rows[j]["OpenedON"].ToString();
                        dtemptyfree.Rows[j]["VSL/Voy"] = dt_OprProfit.Rows[j]["VSLorVOY"].ToString();
                        // dtemptyfree.Rows[j]["ETA"] = dt_OprProfit.Rows[j]["ETA"].ToString();
                        //dtemptyfree.Rows[j]["ETD"] = dt_OprProfit.Rows[j]["ETD"].ToString();
                        dtemptyfree.Rows[j]["Closed On"] = dt_OprProfit.Rows[j]["ClosedON"].ToString();
                        dtemptyfree.Rows[j]["Income"] = dt_OprProfit.Rows[j]["Income"].ToString();
                        dtemptyfree.Rows[j]["Expenses"] = dt_OprProfit.Rows[j]["Expense"].ToString();
                        dtemptyfree.Rows[j]["Retention"] = dt_OprProfit.Rows[j]["Retention"].ToString();

                    }

                    GridView2.DataSource = dtemptyfree;
                    GridView2.DataBind();
                }
            }
            else
            {
                GridView2.DataSource = dtemptyfree;
                GridView2.DataBind();
            }

            ViewState["GrdExp2exc"] = dtemptyfree;
        }

        protected void lnkoutstOE_Click(object sender, EventArgs e)
        {
            visible_false();
            excportexc.Visible = true;
            grd_AirImports.Visible = true;
            penBlRelase.Visible = true;
            headlbl1.Visible = true;
            lbl_cut.Text = "Ocean Exports";
            lbl_cut.Attributes.Add("style", "color:#974706");
            DataTable dt_OprProfit = new DataTable();
            DataTable dt = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //string transtype = Session["StrTranType"].ToString();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            int count;
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("S#");
            dtemptyfree.Columns.Add("Branch");
            dtemptyfree.Columns.Add("Product");
            dtemptyfree.Columns.Add("Job #");
            dtemptyfree.Columns.Add("Opend On");
            dtemptyfree.Columns.Add("VSL/Voy");
            dtemptyfree.Columns.Add("ETA");
            dtemptyfree.Columns.Add("ETD");
            dtemptyfree.Columns.Add("Closed On");
            dtemptyfree.Columns.Add("Income");
            dtemptyfree.Columns.Add("Expenses");
            dtemptyfree.Columns.Add("Retention");
            //   dt_OprProfit = da_obj_misgrd.Getshipmentnewhome(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), "AE", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            dt_OprProfit = da_obj_misgrd.Getshipmentnewhome("FE", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
            if (dt_OprProfit.Rows.Count > 0)
            {
                //GridView1.DataSource = dt_OprProfit;
                //GridView1.DataBind();

                DataRow dr = dtemptyfree.NewRow();
                if (dt_OprProfit.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt_OprProfit.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt_OprProfit.Rows[j]["S#"].ToString();
                        dtemptyfree.Rows[j]["Branch"] = dt_OprProfit.Rows[j]["Branch"].ToString();
                        dtemptyfree.Rows[j]["Product"] = dt_OprProfit.Rows[j]["Product"].ToString();
                        dtemptyfree.Rows[j]["Job #"] = dt_OprProfit.Rows[j]["JOBNO"].ToString();
                        dtemptyfree.Rows[j]["Opend On"] = dt_OprProfit.Rows[j]["OpenedON"].ToString();
                        dtemptyfree.Rows[j]["VSL/Voy"] = dt_OprProfit.Rows[j]["VSLorVOY"].ToString();
                        dtemptyfree.Rows[j]["ETA"] = dt_OprProfit.Rows[j]["ETA"].ToString();
                        dtemptyfree.Rows[j]["ETD"] = dt_OprProfit.Rows[j]["ETD"].ToString();
                        dtemptyfree.Rows[j]["Closed On"] = dt_OprProfit.Rows[j]["ClosedON"].ToString();
                        dtemptyfree.Rows[j]["Income"] = dt_OprProfit.Rows[j]["Income"].ToString();
                        dtemptyfree.Rows[j]["Expenses"] = dt_OprProfit.Rows[j]["Expense"].ToString();
                        dtemptyfree.Rows[j]["Retention"] = dt_OprProfit.Rows[j]["Retention"].ToString();

                    }

                    GridView2.DataSource = dtemptyfree;
                    GridView2.DataBind();
                }
            }
            else
            {
                GridView2.DataSource = dtemptyfree;
                GridView2.DataBind();
            }

            ViewState["GrdExp2exc"] = dtemptyfree;
        }

        protected void lnkoutstOI_Click(object sender, EventArgs e)
        {
            visible_false();
            excportexc.Visible = true;
            grd_AirImports.Visible = true;
            penBlRelase.Visible = true;
            headlbl1.Visible = true;
            lbl_cut.Text = "Ocean Imports";
            lbl_cut.Attributes.Add("style", "color:#215967");
            DataTable dt_OprProfit = new DataTable();
            DataTable dt = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //string transtype = Session["StrTranType"].ToString();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            int count;
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("S#");
            dtemptyfree.Columns.Add("Branch");
            dtemptyfree.Columns.Add("Product");
            dtemptyfree.Columns.Add("Job #");
            dtemptyfree.Columns.Add("Opend On");
            dtemptyfree.Columns.Add("VSL/Voy");
            dtemptyfree.Columns.Add("ETA");
            dtemptyfree.Columns.Add("ETD");
            dtemptyfree.Columns.Add("Closed On");
            dtemptyfree.Columns.Add("Income");
            dtemptyfree.Columns.Add("Expenses");
            dtemptyfree.Columns.Add("Retention");
            //   dt_OprProfit = da_obj_misgrd.Getshipmentnewhome(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), "AE", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            dt_OprProfit = da_obj_misgrd.Getshipmentnewhome("FI", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
            if (dt_OprProfit.Rows.Count > 0)
            {
                //GridView1.DataSource = dt_OprProfit;
                //GridView1.DataBind();

                DataRow dr = dtemptyfree.NewRow();
                if (dt_OprProfit.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt_OprProfit.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt_OprProfit.Rows[j]["S#"].ToString();
                        dtemptyfree.Rows[j]["Branch"] = dt_OprProfit.Rows[j]["Branch"].ToString();
                        dtemptyfree.Rows[j]["Product"] = dt_OprProfit.Rows[j]["Product"].ToString();
                        dtemptyfree.Rows[j]["Job #"] = dt_OprProfit.Rows[j]["JOBNO"].ToString();
                        dtemptyfree.Rows[j]["Opend On"] = dt_OprProfit.Rows[j]["OpenedON"].ToString();
                        dtemptyfree.Rows[j]["VSL/Voy"] = dt_OprProfit.Rows[j]["VSLorVOY"].ToString();
                        dtemptyfree.Rows[j]["ETA"] = dt_OprProfit.Rows[j]["ETA"].ToString();
                        dtemptyfree.Rows[j]["ETD"] = dt_OprProfit.Rows[j]["ETD"].ToString();
                        dtemptyfree.Rows[j]["Closed On"] = dt_OprProfit.Rows[j]["ClosedON"].ToString();
                        dtemptyfree.Rows[j]["Income"] = dt_OprProfit.Rows[j]["Income"].ToString();
                        dtemptyfree.Rows[j]["Expenses"] = dt_OprProfit.Rows[j]["Expense"].ToString();
                        dtemptyfree.Rows[j]["Retention"] = dt_OprProfit.Rows[j]["Retention"].ToString();

                    }

                    GridView2.DataSource = dtemptyfree;
                    GridView2.DataBind();
                }
            }
            else
            {
                GridView2.DataSource = dtemptyfree;
                GridView2.DataBind();
            }

            ViewState["GrdExp2exc"] = dtemptyfree;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    double dbl_temp = 0;
                    if (lbl_cut.Text == "Ocean Imports" || lbl_cut.Text == "Ocean Exports" || lbl_cut.Text == "Total Retention")
                    {
                        if (e.Row.Cells[1].Text == "Total")
                        {
                            e.Row.ForeColor = System.Drawing.Color.Brown;
                            e.Row.Cells[0].Text = "";
                            e.Row.Cells[3].Text = "";
                            e.Row.Cells[4].Text = "";
                            e.Row.Cells[8].Text = "";
                        }
                        if (double.TryParse(e.Row.Cells[9].Text.ToString(), out dbl_temp))
                        {
                            //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                            e.Row.Cells[9].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[9].Attributes.CssStyle["text-align"] = "Right";
                        }
                        if (double.TryParse(e.Row.Cells[10].Text.ToString(), out dbl_temp))
                        {
                            //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                            e.Row.Cells[10].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[10].Attributes.CssStyle["text-align"] = "Right";
                        }
                        if (double.TryParse(e.Row.Cells[11].Text.ToString(), out dbl_temp))
                        {
                            //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                            e.Row.Cells[11].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[11].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }
                    else
                    {
                        if (e.Row.Cells[1].Text == "Total")
                        {
                            e.Row.ForeColor = System.Drawing.Color.Brown;
                            e.Row.Cells[0].Text = "";
                            e.Row.Cells[3].Text = "";
                            e.Row.Cells[4].Text = "";
                            e.Row.Cells[6].Text = "";
                            // e.Row.Cells[8].Text = "";
                        }
                        if (double.TryParse(e.Row.Cells[7].Text.ToString(), out dbl_temp))
                        {
                            //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                            e.Row.Cells[7].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[7].Attributes.CssStyle["text-align"] = "Right";
                        }
                        if (double.TryParse(e.Row.Cells[8].Text.ToString(), out dbl_temp))
                        {
                            //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                            e.Row.Cells[8].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[8].Attributes.CssStyle["text-align"] = "Right";
                        }
                        if (double.TryParse(e.Row.Cells[9].Text.ToString(), out dbl_temp))
                        {
                            //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                            e.Row.Cells[9].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[9].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }
                }




            }
        }

        protected void lnk_Tds_Click(object sender, EventArgs e)
        {
            /*visible_false();
            div_Tds.Visible = true;
            exp2excGrd_Deposite.Visible = false;
            trantype = Session["StrTranType"].ToString();
            Fn_LodaBranch();
            if (trantype1 == "CA")
            {
                btn_update.Visible = false;

                ddl_branch.Visible = true;
                DataAccess.HR.Employee obj_da_HR = new DataAccess.HR.Employee();
                int_branchid = obj_da_HR.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), ddl_branch.SelectedItem.Text);
                //div_branch.Attributes.CssStyle.Add("width", "8%");
            }
            else
            {
                btn_update.Visible = true;
                lbl_branch.Text = lbl_Header.Text;
                ddl_branch.Visible = false;
                ddl_branch.Items.Add(Session["LoginBranchName"].ToString());
                int_branchid = int.Parse(Session["LoginBranchid"].ToString());
                //div_branch.Attributes.CssStyle.Add("width", "30%");
            }
            Fn_GetDetail(int_branchid);

            */
           

            string Strtrantype, formname, Modulename;
            Modulename = "FA";
            int branchid, divisionid, logempid, Vouyear, UiiD1=0;
            DataTable dtuser = new DataTable();
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            Strtrantype = Session["StrTranType"].ToString();
            try
            {
                formname = "CN-Ops TDS";
                //UiiD1 = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));

                

                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD1 = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD1 == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD1, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../FAForms/PATDS.aspx?FormName=" + formname + "&UIID=" + UiiD1 + "&Home=Yes");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_Tds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        private void Fn_LodaBranch()
        {
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            obj_dt = obj_da_Port.GetAllBranchNameforPortName();
            ddl_branch.DataSource = obj_dt;
            ddl_branch.DataTextField = "portname";
            ddl_branch.DataBind();
        }
        private void Fn_GetDetail(int int_bid)
        {
            DataTable obj_dt = new DataTable();
            //DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
            obj_dt = leftObj.GetValueForTds(int_bid);
            Grd_TDS.DataSource = obj_dt;
            Grd_TDS.DataBind();
        }
        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_branch.SelectedItem.Text.Trim().Length > 0)
            {
                DataAccess.HR.Employee obj_da_HR = new DataAccess.HR.Employee();
                int_branchid = obj_da_HR.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), ddl_branch.SelectedItem.Text);
                Fn_GetDetail(int_branchid);
            }
           // btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancelid1.Attributes["class"] = "btn ico-cancel";
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            string type = "";
            //btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancelid1.Attributes["class"] = "btn ico-cancel";
            try
            {
                Boolean Check = false;
                DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                foreach (GridViewRow row in Grd_TDS.Rows)
                {
                    int int_Vouno = 0, int_Vouyear = 0, int_Custid = 0;
                    double Amount = 0, TDS = 0, TDSAmount = 0, CSTAmount = 0;
                    type = Grd_TDS.Rows[row.RowIndex].Cells[7].Text;
                    string str_Voutype = type;
                    bool ChkLedger = true;
                    CheckBox Chk = (CheckBox)Grd_TDS.Rows[row.RowIndex].FindControl("Chk_Select");
                    TextBox Txt = (TextBox)Grd_TDS.Rows[row.RowIndex].FindControl("txt_TDS");
                    if (Txt.Text.Trim().Length == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "TDS", "alertify.alert('Enter TDS%');", true);
                        Txt.Focus();
                        return;
                    }
                    if (Chk.Checked == true)
                    {
                        Check = true;
                        int_Vouno = int.Parse(Grd_TDS.Rows[row.RowIndex].Cells[2].Text.ToString());
                        int_Vouyear = int.Parse(Grd_TDS.DataKeys[row.RowIndex].Values[0].ToString());
                        int_Custid = int.Parse(Grd_TDS.DataKeys[row.RowIndex].Values[2].ToString());
                        Amount = double.Parse(Grd_TDS.DataKeys[row.RowIndex].Values[1].ToString());
                        TDS = double.Parse(Txt.Text.ToString());

                        TDSAmount = Amount * (TDS / 100);
                        CSTAmount = Amount - TDSAmount;
                        DataTable obj_dt = new DataTable();
                        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                        if (str_Voutype == "S")
                        {
                            obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Vouno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear);
                        }
                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            int int_Ledgerid = 0;
                            int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), "A", Session["FADbname"].ToString());
                            if (int_Ledgerid == 0)
                            {
                                ChkLedger = false;
                            }
                        }
                        if (ChkLedger == true)
                        {
                            obj_da_Invoice.InsertPATDS(int_Vouno, str_Voutype, int_branchid, int_Custid, int_Vouyear, CSTAmount, TDSAmount, "", Convert.ToDouble(Txt.Text.ToString()));
                            string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";
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
                            }//raj
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Vouno, int_Vouno, Str_ddlNarration, Str_ddlReference, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                            try
                            {
                                int int_Ledgerid = 0;
                                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Session["FADbname"].ToString());
                                int int_Voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_ddlVoucherType, Session["FADbname"].ToString());
                                if (int_Ledgerid == 0)
                                {
                                    int_Ledgerid = Fn_Getcustomergroupid(int_Custid, Str_ddlVoucherType);
                                }
                                DateTime dtdate = DateTime.Parse(Grd_TDS.Rows[row.RowIndex].Cells[3].Text);
                                DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
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
                                    obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Vouno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int_branchid, CSTAmount, Str_Curr, F_Curr, int_Custid);
                                }
                                else
                                {

                                    obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Vouno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int_branchid, CSTAmount, "", 0, int_Custid);
                                }
                            }
                            catch (Exception ex)
                            {
                                //  Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In PATDS - " + Str_ddlVoucherType + " #" + int_Vouno + "\\VType-" + hid_type.Value.ToString() + " \\VYear - " + Session["Vouyear"].ToString() + " \\BID - " + int_branchid, ex.ToString(), "", Session["usermailpwd"].ToString());
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "TDS", "alertify.alert('LedgerName Not Found in Financial. You are not able to Approve TDS FOR CN " + int_Vouno + " Contact Your  Finanace Head');", true);
                        }
                    }
                }
                if (Check == true)
                {
                    ScriptManager.RegisterStartupScript(btn_update, typeof(Button), "TDS", "alertify.alert('Detail Updated');", true);
                }
                Fn_GetDetail(int_branchid);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private int Fn_Getcustomergroupid(int int_Custid, string Str_VType)
        {
            int int_Subgroupid = 0, int_Groupid = 0;
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
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


        //protected void Grd_TDS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        Grd_TDS.PageIndex = e.NewPageIndex;
        //        Fn_GetDetail(int_branchid);
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

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

        protected void btn_Can_Cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Grd_TDS.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_TDS.DataBind();
               // btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancelid1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }

        protected void Grd_Deposite_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    //e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    if (e.Row.Cells[i].Text == "Total")
                    {
                        e.Row.Cells[0].Text = "";
                    }
                }


                //se.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;



            }
        }

        protected void grd_RecOll_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    //e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Right";
                }

                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;



            }
        }

        protected void grd_UNC_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    //e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Right";
                }

                // e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;



            }

        }

        protected void lnk_tot_Click(object sender, EventArgs e)
        {
            
            visible_false();
            excportexc.Visible = true;
            grd_AirImports.Visible = true;
            penBlRelase.Visible = true;
            headlbl1.Visible = true;
            lbl_cut.Text = "Total Retention";
            lbl_cut.Attributes.Add("style", "color:#7b8d8e");
            DataTable dt_OprProfit = new DataTable();
            DataTable dt = new DataTable();
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            //string transtype = Session["StrTranType"].ToString();
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            int count;
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("S#");
            dtemptyfree.Columns.Add("Branch");
            dtemptyfree.Columns.Add("Product");
            dtemptyfree.Columns.Add("Job #");
            dtemptyfree.Columns.Add("Opend On");
            dtemptyfree.Columns.Add("VSL/Voy/FrightDetails");
            dtemptyfree.Columns.Add("ETA");
            dtemptyfree.Columns.Add("ETD");
            dtemptyfree.Columns.Add("Closed On");
            dtemptyfree.Columns.Add("Income");
            dtemptyfree.Columns.Add("Expenses");
            dtemptyfree.Columns.Add("Retention");
            //   dt_OprProfit = da_obj_misgrd.Getshipmentnewhome(Convert.ToInt32(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()), "AE", Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())));
            dt_OprProfit = da_obj_misgrd.Getshipmentnewhome("AC", Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToDateTime((fromdate.ToString())), Convert.ToDateTime((Todate.ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
            if (dt_OprProfit.Rows.Count > 0)
            {
                //GridView1.DataSource = dt_OprProfit;
                //GridView1.DataBind();

                DataRow dr = dtemptyfree.NewRow();
                if (dt_OprProfit.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt_OprProfit.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt_OprProfit.Rows[j]["S#"].ToString();
                        dtemptyfree.Rows[j]["Branch"] = dt_OprProfit.Rows[j]["Branch"].ToString();
                        dtemptyfree.Rows[j]["Product"] = dt_OprProfit.Rows[j]["Product"].ToString();
                        dtemptyfree.Rows[j]["Job #"] = dt_OprProfit.Rows[j]["JOBNO"].ToString();
                        dtemptyfree.Rows[j]["Opend On"] = dt_OprProfit.Rows[j]["OpenedON"].ToString();
                        dtemptyfree.Rows[j]["VSL/Voy/FrightDetails"] = dt_OprProfit.Rows[j]["VSLorVOY"].ToString();
                        dtemptyfree.Rows[j]["ETA"] = dt_OprProfit.Rows[j]["ETA"].ToString();
                        dtemptyfree.Rows[j]["ETD"] = dt_OprProfit.Rows[j]["ETD"].ToString();
                        dtemptyfree.Rows[j]["Closed On"] = dt_OprProfit.Rows[j]["ClosedON"].ToString();
                        dtemptyfree.Rows[j]["Income"] = dt_OprProfit.Rows[j]["Income"].ToString();
                        dtemptyfree.Rows[j]["Expenses"] = dt_OprProfit.Rows[j]["Expense"].ToString();
                        dtemptyfree.Rows[j]["Retention"] = dt_OprProfit.Rows[j]["Retention"].ToString();

                    }

                    GridView2.DataSource = dtemptyfree;
                    GridView2.DataBind();
                }
            }
            else
            {
                GridView2.DataSource = dtemptyfree;
                GridView2.DataBind();
            }
        }

        protected void excportexc_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GrdExp2exc"] as DataTable;

            if (GridView2.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Operating Profits.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }

        protected void exp2excGrd_Deposite_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["Grd_Deposite"] as DataTable;

            if (Grd_Deposite.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Deposits.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }

        protected void exp2excgrdrecoll_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GrdCollections"] as DataTable;

            if (grd_RecOll.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Collections.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }

        protected void exp2excgrdunc_Click(object sender, EventArgs e)
        {
           

                 DataTable dt_check = ViewState["grd_UNCexp2exc"] as DataTable;

                 if (grd_UNC.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Unclosedjobs.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }


        }

        protected void lnk_changeJob_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "AC")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1924, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string str_sp = "";
                    string str_sf = "";
                    string str_RptName = "";
                    string str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    string Strtrantype = Session["StrTranType"].ToString();
                    int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
                    int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
                    int logempid = Convert.ToInt16(Session["LoginEmpId"].ToString());
                    if (Session["LoginUserName"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                    }

                    MISObj.SelIncomeNotBkd(branchid, divisionid, logempid);
                    str_RptName = "RptIncomeNotBkd.rpt";
                    Session["str_sfs"] = "{TempIncomeNotBkd.Empid}=" + logempid;
                    str_sf = "{TempIncomeNotBkd.Empid}=" + logempid;
                    str_sp = "";//"Head=Invoice Pending Approval";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Button), "Income Not Booked", str_Script, true);


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

           

        }

        protected void lnk_expense_Click(object sender, EventArgs e)
        {

            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "AC")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1925, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string str_sp = "";
                    string str_sf = "";
                    string str_RptName = "";
                    string str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    string Strtrantype = Session["StrTranType"].ToString();
                    int divisionid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
                    int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
                    int logempid = Convert.ToInt16(Session["LoginEmpId"].ToString());
                    if (Session["LoginUserName"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                    }

                    MISObj.SelExpenseNotBkd(branchid, divisionid, logempid);
                    str_RptName = "RptExpensesNotBkd.rpt";
                    Session["str_sfs"] = "{TempIncomeNotBkd.Empid}=" + logempid;
                    str_sf = "{TempIncomeNotBkd.Empid}=" + logempid;
                    str_sp = "";//"Head=Invoice Pending Approval";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Button), "Income Not Booked", str_Script, true);



                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }


           
        }

        protected void grdunclosejobs_PreRender(object sender, EventArgs e)
        {
            if (grdunclosejobs.Rows.Count > 0)
            {
                grdunclosejobs.UseAccessibleHeader = true;
                grdunclosejobs.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_UNC_PreRender(object sender, EventArgs e)
        {
            if (grd_UNC.Rows.Count > 0)
            {
                grd_UNC.UseAccessibleHeader = true;
                grd_UNC.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_Deposite_PreRender(object sender, EventArgs e)
        {
            if (Grd_Deposite.Rows.Count > 0)
            {
                Grd_Deposite.UseAccessibleHeader = true;
                Grd_Deposite.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void grd_RecOll_PreRender(object sender, EventArgs e)
        {
            if (grd_RecOll.Rows.Count > 0)
            {
                grd_RecOll.UseAccessibleHeader = true;
                grd_RecOll.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridView2_PreRender(object sender, EventArgs e)
        {
            if (GridView2.Rows.Count > 0)
            {
                GridView2.UseAccessibleHeader = true;
                GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_Admin_PreRender(object sender, EventArgs e)
        {
            if (Grd_Admin.Rows.Count > 0)
            {
                Grd_Admin.UseAccessibleHeader = true;
                Grd_Admin.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_Approval_PreRender(object sender, EventArgs e)
        {
            if (Grd_Approval.Rows.Count > 0)
            {
                Grd_Approval.UseAccessibleHeader = true;
                Grd_Approval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_DNCN_PreRender(object sender, EventArgs e)
        {
            if (Grid_DNCN.Rows.Count > 0)
            {
                Grid_DNCN.UseAccessibleHeader = true;
                Grid_DNCN.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GrdPendingTDS_PreRender(object sender, EventArgs e)
        {
            if (GrdPendingTDS.Rows.Count > 0)
            {
                GrdPendingTDS.UseAccessibleHeader = true;
                GrdPendingTDS.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdPendingFA_PreRender(object sender, EventArgs e)
        {
            if (GrdPendingFA.Rows.Count > 0)
            {
                GrdPendingFA.UseAccessibleHeader = true;
                GrdPendingFA.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdPendingDep_PreRender(object sender, EventArgs e)
        {
            if (GrdPendingDep.Rows.Count > 0)
            {
                GrdPendingDep.UseAccessibleHeader = true;
                GrdPendingDep.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdunclosejobs1_PreRender(object sender, EventArgs e)
        {
            if (grdunclosejobs1.Rows.Count > 0)
            {
                grdunclosejobs1.UseAccessibleHeader = true;
                grdunclosejobs1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdPending1_PreRender(object sender, EventArgs e)
        {
            if (GrdPending1.Rows.Count > 0)
            {
                GrdPending1.UseAccessibleHeader = true;
                GrdPending1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdExpense_PreRender(object sender, EventArgs e)
        {
            if (GrdExpense.Rows.Count > 0)
            {
                GrdExpense.UseAccessibleHeader = true;
                GrdExpense.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridDepwise_PreRender(object sender, EventArgs e)
        {
            if (GridDepwise.Rows.Count > 0)
            {
                GridDepwise.UseAccessibleHeader = true;
                GridDepwise.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Gridjobcost_PreRender(object sender, EventArgs e)
        {
            if (Gridjobcost.Rows.Count > 0)
            {
                Gridjobcost.UseAccessibleHeader = true;
                Gridjobcost.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdPendingcrdapp_PreRender(object sender, EventArgs e)
        {
            if (GrdPendingcrdapp.Rows.Count > 0)
            {
                GrdPendingcrdapp.UseAccessibleHeader = true;
                GrdPendingcrdapp.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void Gridexrate_PreRender(object sender, EventArgs e)
        {
            if (Gridexrate.Rows.Count > 0)
            {
                Gridexrate.UseAccessibleHeader = true;
                Gridexrate.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


    }
}





