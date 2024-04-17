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
using DataAccess.HR;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;

namespace logix.Home
{
    public partial class CorporateHome : System.Web.UI.Page
    {
        DataTable dtCout = new DataTable();
        DataTable dt = new DataTable();
        DataAccess.Accounts.Payment paymentobj = new DataAccess.Accounts.Payment();
        DataAccess.Accounts.Recipts Obj_rec = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Payment objpay = new DataAccess.Accounts.Payment();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.LogDetails lobobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
        int branchid = 0, did = 0, Vouyear = 0, logempid = 0;
        string FADbname = "", Strtrantype = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            Strtrantype = Session["StrTranType"].ToString();
            Vouyear = Convert.ToInt32(Session["LogYear"]);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                paymentobj.GetDataBase(Ccode);
                Obj_rec.GetDataBase(Ccode);
                objpay.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                lobobj.GetDataBase(Ccode);
                obj_da_Receipt.GetDataBase(Ccode);
              
            }


            if (!IsPostBack)
            {
                //if (Session["FA_Year"] != null)
                //{
                //    lblLoginYear.Visible = true;
                //    lblLoginYear.Text = " " + Session["FA_Year"].ToString();
                //}
                //count1();
                //count2();
                //Bankbalancetitle.Visible = false;
                // Get_PaymentsCounts();

                // BindCollectionTot();
                // BindDepositTot();
                //// Div_chart.Visible = true;

                // BRSUnclearedTot();
                //div_bar.Visible = true;
                //div2_Bookchart.Visible = true;
                //bookline();

                //fn_Getnewoutstanding4MISHomeOutStndTotal();
                //if (Request.QueryString.ToString().Contains("type"))
                //{
                //    string product = Request.QueryString["type"].ToString();
                //    if (product == "Branch")
                //    {
                //        //ddl_branch.SelectedIndex = -1;
                //        return;
                //    }
                //}
            }


        }
        public class countrydetails
        {
            public string Countryname { get; set; }
            public Double Total { get; set; }
        }

        /*
        public void bookline()
        {
            DataTable dt0 = new DataTable();
            dt0 = Obj_rec.GetOverallAmtForBarChart(Convert.ToInt32(Session["LoginBranchid"]));
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
            str.Append(" chart.draw(data, {width: 550, height: 300, title: 'Payments Vs Collections',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}} ,colors: ['#4ebcd5','#bce3c8']");
            str.Append("}); }");
            str.Append("</script>");
            lts.Text = str.ToString().Replace('*', '"');



        }

        */

        [WebMethod]
        public static List<countrydetails> GetChartDataBooking()
        {

            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_misgrd.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            int subgrpid = 40;
            if (HttpContext.Current.Session["LoginBranchid"] != null || HttpContext.Current.Session["LoginDivisionId"] != null)
            {
                dt = da_obj_misgrd.Getnewoutstanding4MISHomeOutStndTotal(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), subgrpid);
            }

            List<countrydetails> dataList = new List<countrydetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                countrydetails details = new countrydetails();
                details.Countryname = dtrow[0].ToString();
                details.Total = Convert.ToDouble(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }
        /*
        protected void fn_Getnewoutstanding4MISHomeOutStndTotal()
        {
            DataTable dt = new DataTable();

            DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

            int subgrpid = 40, count_row = 0;
            int time = 0;
            double temp_TOTAL = 0, temp_out = 0, temp_overdue;

            time = lobobj.GetDate().Hour;

           //dt = outsobj.OutStdingGETtildateCorhome(199999, did, subgrpid);



            if (time < 13)
            {
                dt = outsobj.OutStdingGET(99999, did, subgrpid);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outsobj.OutStdingGET12N(99999, did, subgrpid);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outsobj.OutStdingGET3PM(99999, did, subgrpid);
            }
            if (dt.Rows.Count > 0)
            {
                //  DataView dataView = dt.DefaultView;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["amount"].ToString()))
                    {
                        temp_TOTAL += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                    }
                }
            }
            //SPoutsttot.InnerText = Convert.ToDouble(temp_TOTAL).ToString("#,0.00");


            DataTable DT_Temp = new DataTable();
            DataTable DT_Tempnew = new DataTable();
            DataTable DT_bind = new DataTable();
            DataTable DT_sales = new DataTable();
            DataTable Dt_Out = new DataTable();
      
            if (dt.Rows.Count > 0)
            {
                DataView dv_co = new DataView(dt);
                DT_Temp = dv_co.ToTable(true, "salesname", "salesid");
                dv_co = new DataView(DT_Temp);
                dv_co.Sort = "salesid";
                DT_Temp = dv_co.ToTable();
                dv_co = DT_Temp.DefaultView;
                dv_co.RowFilter = "salesid<>0 and  salesid is not null";
                DT_Temp = dv_co.ToTable();
                DataView dv_co1 = new DataView();
                if (did == 6)
                {
                    dv_co1 = new DataView(dt);
                    DT_Tempnew = dv_co1.ToTable(true, "salesname", "salesid");
                    dv_co = new DataView(DT_Tempnew);
                    dv_co1.Sort = "salesid";
                    DT_Tempnew = dv_co1.ToTable();
                    dv_co = DT_Tempnew.DefaultView;
                    dv_co1.RowFilter = "salesid<>0 and  salesid is not null";
                    DT_Tempnew = dv_co1.ToTable();
                    dv_co = DT_Tempnew.DefaultView;
                    dv_co1.RowFilter = "salesid=0 or  salesid is  null";
                    DT_Tempnew = dv_co1.ToTable();
                }
                


                DT_bind.Columns.Add("salesname", typeof(string));
                DT_bind.Columns.Add("amount", typeof(double));
                DT_bind.Columns.Add("overdue", typeof(double));
                DT_bind.Columns.Add("salesid", typeof(string));
                DataRow Drow = DT_bind.NewRow();
                //count_row = DT_Temp.Rows.Count ;
                for (int i = 0; i < DT_Temp.Rows.Count; i++)
                {
                    DataView data1 = dt.DefaultView;
                    data1.RowFilter = "salesname = '" + DT_Temp.Rows[i]["salesname"] + "' ";
                    DT_sales = data1.ToTable();

                    Drow = DT_bind.NewRow();
                    DT_bind.Rows.Add(Drow);
                    DT_bind.Rows[count_row][0] = DT_sales.Rows[0]["salesname"].ToString();
                    temp_out = 0; temp_overdue = 0;
                    for (int j = 0; j < DT_sales.Rows.Count; j++)
                    {
                        temp_out += Convert.ToDouble(DT_sales.Rows[j]["amount"].ToString());
                        temp_overdue += Convert.ToDouble(DT_sales.Rows[j]["overdue"].ToString());
                    }
                    DT_bind.Rows[count_row][1] = temp_out;
                    DT_bind.Rows[count_row][2] = temp_overdue;
                    DT_bind.Rows[count_row][3] = DT_sales.Rows[0]["salesid"].ToString();
                    count_row += 1;
                }

                if (did == 6)
                {
                    if (DT_Tempnew.Rows.Count > 0)
                    {
                        DataView data1 = dt.DefaultView;
                        data1.RowFilter = "salesid = 0 or  salesid is null";
                        DT_sales = data1.ToTable();
                        Drow = DT_bind.NewRow();
                        DT_bind.Rows.Add(Drow);
                        DT_bind.Rows[count_row][0] = "Others";
                        temp_out = 0; temp_overdue = 0;
                        for (int j = 0; j < DT_sales.Rows.Count; j++)
                        {
                            temp_out += Convert.ToDouble(DT_sales.Rows[j]["amount"].ToString());
                            temp_overdue += Convert.ToDouble(DT_sales.Rows[j]["overdue"].ToString());
                        }
                        DT_bind.Rows[count_row][1] = temp_out;
                        DT_bind.Rows[count_row][2] = temp_overdue;
                        DT_bind.Rows[count_row][3] = "0";
                        count_row += 1;
                    }
                }
                var sum_Outstanding = DT_bind.Compute("sum(amount)", "");
                var sum_Over = DT_bind.Compute("sum(overdue)", "");
                Drow = DT_bind.NewRow();
                DT_bind.Rows.Add(Drow);
                DT_bind.Rows[count_row][0] = "Total";
                if (!string.IsNullOrEmpty(sum_Outstanding.ToString()))
                {
                    DT_bind.Rows[count_row][1] = Convert.ToDouble(sum_Outstanding);
                }
                else
                {
                    DT_bind.Rows[count_row][1] = "0.00";
                }
                if (!string.IsNullOrEmpty(sum_Over.ToString()))
                {
                    DT_bind.Rows[count_row][2] = Convert.ToDouble(sum_Over);
                }
                else
                {
                    DT_bind.Rows[count_row][2] = "0.00";
                } 
                //DT_bind.Rows[count_row][1] = Convert.ToDouble(sum_Outstanding);
                //DT_bind.Rows[count_row][2] = Convert.ToDouble(sum_Over);
                Grid_salesout.DataSource = DT_bind;
                Grid_salesout.DataBind();
                ViewState["GridSalesOutPerson"] = DT_bind;
                if (!string.IsNullOrEmpty(sum_Outstanding.ToString()))
                {
                    SPoutsttot.InnerText = Convert.ToDouble(sum_Outstanding).ToString("#,0.00");
                }
                else
                {
                    SPoutsttot.InnerText = "0.00";
                }
            }
            else
            {
                SPoutsttot.InnerText = "0.00";
            }
           
        }
        */
        protected void BRSUnclearedTot()
        {
            DataTable dtnew = new DataTable();
            dtnew = Obj_rec.BRSUncleared(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtnew.Rows.Count > 0)
            {
                //lnk_receipt.Text = dtnew.Rows[0]["rcount"].ToString();
                //lnk_payment1.Text = dtnew.Rows[0]["pcount"].ToString();
            }


        }

        protected void lnk_receipt_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "FC";
                }
                else
                {
                    Session["RightsTranType"] = Session["StrTranType"].ToString();
                }
            }
            DataTable dtuser = new DataTable();
            dtuser = obj_UP.GetFormwiseuserRights(1223, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string FormName = "Cheque Clearance";
                string type = "Receipts";
                Response.Redirect("../FAForms/DepositSlip.aspx?FormName=" + FormName + "&type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }

        }

        protected void lnk_payment1_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();


            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "FC";
                }
                else
                {
                    Session["RightsTranType"] = Session["StrTranType"].ToString();
                }
            }
            dtuser = obj_UP.GetFormwiseuserRights(1223, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string FormName = "Cheque Clearance";
                string type = "Payments";
                Response.Redirect("../FAForms/DepositSlip.aspx?FormName=" + FormName + "&type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }

        }
        /*
        public void BANKBALANCE()
        {
            Double debit = 0;
            Double credit = 0;
            DataTable dts = new DataTable();
            double closebal = 0, closebal1 = 0;
            FADbname = Session["FADbname"].ToString();
            dt = objpay.GetBankBalancefordashboard(FADbname.ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            dts.Columns.Add("S#");
            dts.Columns.Add("Bank");
            dts.Columns.Add("Debit");
            dts.Columns.Add("Credit");
            DataRow dr;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr = dts.NewRow();
                    dts.Rows.Add();
                    dts.Rows[i]["S#"] = dt.Rows[i]["sno"];
                    dts.Rows[i]["Bank"] = dt.Rows[i]["bank"];
                    if (dt.Rows[i]["type"].ToString() == "D")
                    {
                        dts.Rows[i]["Debit"] = dt.Rows[i]["closingbal"];
                        if (string.IsNullOrEmpty(dt.Rows[i]["closingbal"].ToString()) != true)
                        {
                            closebal = closebal + Convert.ToDouble(dt.Rows[i]["closingbal"].ToString());
                        }
                        else
                        {
                            closebal = closebal + 0;
                        }
                    }

                    if (dt.Rows[i]["type"].ToString() == "C")
                    {
                        dts.Rows[i]["Credit"] = dt.Rows[i]["closingbal"];
                        if (string.IsNullOrEmpty(dt.Rows[i]["closingbal"].ToString()) != true)
                        {
                            closebal1 = closebal1 + Convert.ToDouble(dt.Rows[i]["closingbal"].ToString());
                        }
                        else
                        {
                            closebal1 = closebal1 + 0;
                        }
                    }

                }


                dts.Rows.Add();
                dts.Rows[dts.Rows.Count - 1]["Bank"] = "Total";
                dts.Rows[dts.Rows.Count - 1]["Debit"] = closebal.ToString("#,0.00") + "";
                dts.Rows[dts.Rows.Count - 1]["Credit"] = closebal1.ToString("#,0.00") + "";
                Grid_bankbalance.DataSource = dts;
                Grid_bankbalance.DataBind();
                lnk_Grid_bankbalance.Visible = true;
                ViewState["Grid_bankbalanceexp2ex"] = dts;
            }
            else
            {

            }

        }
        protected void Lnk_BankBal_Click(object sender, EventArgs e)
        {
            outstanding.Visible = false;
            BranchTitle1.Visible = false;
           // lbl_branch.Visible = false;
            GridView2.Visible = false;
            Bankbalancetitle.Visible = true;
            ddl_branch.Visible = false;
            Grid_bankbalance.Visible = true;
            GridbankBNL.Visible = true;
            Div_chart.Visible = false;
            BANKBALANCE();
        }
        protected void lnk_Grid_bankbalance_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["Grid_bankbalanceexp2ex"] as DataTable;

            if (Grid_bankbalance.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt_check);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Bank Balance.xls");
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
        */
        public void Get_PaymentsCounts()
        {
            Double bankbalance = 0;
            FADbname = Session["FADbname"].ToString();
            int Vyraer = Convert.ToInt32(Session["Vouyear"]);
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            dt = paymentobj.getbankbalance(FADbname, branchid);
            if (!string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                bankbalance = Convert.ToDouble(dt.Rows[0][0]);
            }
            else
            {
                bankbalance = 0.0;
            }


            if (bankbalance.ToString().Substring(0, 1) == "-")
            {
                //id_bnk.InnerHtml = "Cr";
            }
            else
            {
                //id_bnk.InnerHtml = "Dr";
            }
            if (dt.Rows.Count > 0)
            {
                //Lnk_BankBal.Text = bankbalance.ToString("#,0.00") + "";
            }
            else
            {
                //Lnk_BankBal.Text = "0";
            }

        }
        /*
        protected void Grid_bankbalance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_bankbalance, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }


                double dbl_temp = 0;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[2].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[2].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[2].Attributes.CssStyle["text-align"] = "Right";

                }

                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[3].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[3].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";

                }
            }
        }
        */
        protected void BindCollectionTot()
        {
            DataTable dt = new DataTable();
            double total = 0;
            dt = Obj_rec.CollectionPending(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["Amount"].ToString().ToString()))
                {
                    total = Convert.ToDouble(dt.Rows[0]["Amount"].ToString());
                }
                else
                {
                    total = 0;
                }
                //lbl_collection.Text = string.Format("{0:#,##0.00}", total);
            }
        }

        protected void BindDepositTot()
        {

            DateTime Str_CurrrentDate = DateTime.Now.AddDays(-1);

            //txt_date.Text = Str_CurrrentDate.ToString("dd/MM/yyyy");

            //DateTime dte = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
            //if (dte.DayOfWeek == DayOfWeek.Sunday)
            //{
            //    //txt_date.Text = dte.AddDays(-1).ToString("dd/MM/yyyy");
            //}
            //else
            //{
            //    //txt_date.Text = Str_CurrrentDate.ToString("dd/MM/yyyy");
            //}
            //Session["DateTime"] = txt_date.Text;

            //loaddate();


        }

        protected void loaddate()
        {
            DataTable obj_dt = new DataTable();
          //  DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            obj_dt = obj_da_Receipt.Getdeposit4branch(Convert.ToDateTime(Utility.fn_ConvertDate(Session["DateTime"].ToString())), int.Parse(Session["LoginDivisionId"].ToString()));

            if (obj_dt.Rows.Count > 0)
            {
                var total = obj_dt.Compute("sum(amount)", "");
                //lnk_deposit.Text = string.Format("{0:#,##0.00}", total);
                //lnk_deposit.Enabled = true;
            }
            else
            {
                //lnk_deposit.Text = "0.00";
                //lnk_deposit.Enabled = false;
            }
        }
        /*
        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            ddl_branch.Visible = false;
            GridbankBNL.Visible = false;

            Bankbalancetitle.Visible = false;

            Session["DateTime"] = txt_date.Text;
            loaddate();
        }

        protected void lnk_deposit_Click(object sender, EventArgs e)
        {
            ddl_branch.Visible = false;
            GridbankBNL.Visible = false;
           
            Div_chart.Visible = false;
            Bankbalancetitle.Visible = false;
            DataTable dtuser = new DataTable();
            //if (Session["StrTranType"].ToString() == "CO")
            //{
            //    Session["RightsTranType"] = "FC";
            //}
            dtuser = obj_UP.GetFormwiseuserRights(1803, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FC");
            if (dtuser.Rows.Count > 0)
            {
                string type = "Deposit Details";
                Response.Redirect("../FAForms/DepositDetails.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
            //string type = "DepositDetails";
            //Response.Redirect("../FAForms/DepositDetails.aspx?type=" + type);
        }
        */
        protected void Link_CNOPS_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "CO")
            {

            }
            dtuser = obj_UP.GetFormwiseuserRights(1197, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FC");
            if (dtuser.Rows.Count > 0)
            {
                string type = "CnOps";
                Response.Redirect("../FAForms/ChequeRequestApproval.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void Link_CN_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();
            //if (Session["StrTranType"] != null)
            //{
            //    if (Session["StrTranType"].ToString() == "CO")
            //    {
            //        Session["RightsTranType"] = "FC";
            //    }
            //    //else
            //    //{
            //    //    Session["RightsTranType"] = Session["StrTranType"].ToString();
            //    //}
            //}

            dtuser = obj_UP.GetFormwiseuserRights(1197, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FC");
            if (dtuser.Rows.Count > 0)
            {
                string type = "CN";
                Response.Redirect("../FAForms/ChequeRequestApproval.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        //protected void link_CNADmin_Click(object sender, EventArgs e)
        //{

        //    DataTable dtuser = new DataTable();
        //    //if (Session["StrTranType"] != null)
        //    //{
        //    //    if (Session["StrTranType"].ToString() == "CO")
        //    //    {
        //    //        Session["RightsTranType"] = "FC";
        //    //    }
        //    //    else
        //    //    {
        //    //        Session["RightsTranType"] = Session["StrTranType"].ToString();
        //    //    }
        //    //}

        //    dtuser = obj_UP.GetFormwiseuserRights(1197, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FC");
        //    if (dtuser.Rows.Count > 0)
        //    {
        //        string type = "CN Admin";
        //        Response.Redirect("../FAForms/ChequeRequestApproval.aspx?type=" + type);
        //    }
        //    else
        //    {
        //        string message = "No Rights";
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

        //    }
        //}



        //public void count1()
        //{
        //    dtCout = objpay.getpaymentrquest(Convert.ToInt32(Session["LoginBranchid"].ToString()));
        //    if (dtCout.Rows.Count > 0)
        //    {

        //        if (dtCout.Rows[0]["voutype"].ToString() == "P")
        //        {

        //            //link_CNOP.Text = dtCout.Rows[0]["counts"].ToString();
        //        }
        //        else
        //        {
        //            //link_CNOP.Text = "0";
        //        }
        //        if (dtCout.Rows[1]["voutype"].ToString() == "E")
        //        {
        //            //link_cnn.Text = dtCout.Rows[1]["counts"].ToString();
        //        }
        //        else
        //        {
        //            //link_cnn.Text = "0";
        //        }
        //        if (dtCout.Rows[2]["voutype"].ToString() == "S")
        //        {
        //            //link_cnadmins.Text = dtCout.Rows[2]["counts"].ToString();
        //        }
        //        else
        //        {
        //            //link_cnadmins.Text = "0";
        //        }

        //    }

        //}
        /*
        protected void link_CNOP_Click(object sender, EventArgs e)
        {

            ddl_branch.Items.Clear();
            BranchTitle1.Visible = true;
            lbl_branch.Text = "CN Ops";
            ddl_branch.Visible = true;
            GridbankBNL.Visible = false;
            outstanding.Visible = false;
            GridView2.Visible = false;
            Bankbalancetitle.Visible = false;
            Div_chart.Visible = false;
            LoadBranch();
            
        }

        protected void link_cnn_Click(object sender, EventArgs e)
        {

            BranchTitle1.Visible = true;
            lbl_branch.Text = "CN";
            ddl_branch.Items.Clear();
            ddl_branch.Visible = true;
            GridbankBNL.Visible = false;
            outstanding.Visible = false;
            GridView2.Visible = false;
            Bankbalancetitle.Visible = false;
            Div_chart.Visible = false;
            LoadBranch();

        }

        protected void link_cnadmins_Click(object sender, EventArgs e)
        {
            ddl_branch.Items.Clear();

            BranchTitle1.Visible = true;
            lbl_branch.Text = "CN Admin";
            ddl_branch.Visible = true;
            GridbankBNL.Visible = false;
            Bankbalancetitle.Visible = false;
            Div_chart.Visible = false;
            outstanding.Visible = false;
            GridView2.Visible = false;
            DataTable dtuser = new DataTable();

            LoadBranch();

        }

        protected void LoadBranch()
        {
            DataTable dtTable = new DataTable();
            DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
            dtTable = Emp_Obj.selBranchList(Session["LoginDivisionName"].ToString());
            if (dtTable.Rows.Count > 0)
            {
                ddl_branch.Items.Add("Branch");
                for (int i = 0; i <= dtTable.Rows.Count - 1; i++)
                {
                    ddl_branch.Items.Add(dtTable.Rows[i]["branchname"].ToString());
                }
            }
            ddl_branch.Enabled = true;
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedBranch"] = ddl_branch.SelectedItem.Text;
            DataTable dtuser = new DataTable();
            dtuser = obj_UP.GetFormwiseuserRights(1178, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FC");
            if (dtuser.Rows.Count > 0)
            {
                string type = "Payments";
                Response.Redirect("../FAForms/PaymentFA_Receipt.aspx?type=" + type);
                //string type = "Payments";
                //Response.Redirect("../Accounts/PaymentFA.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }


        }

        protected void link_outstanding_Click(object sender, EventArgs e)
        {
            ddl_branch.Items.Clear();
            ddl_branch.Visible = false;
            BranchTitle1.Visible = false;
            Div_chart.Visible = false;
            outstanding.Visible = true;
            GridView2.Visible = true;
            Bankbalancetitle.Visible = false;
            GridbankBNL.Visible = false;
            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            DataTable dt_outstanting = new DataTable();
            int subgrpid = 40;
            DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

           
            int time = 0;
            time = lobobj.GetDate().Hour;
            //if (time < 13)
            //{
            //    dt = outsobj.OutStdingGETFACor(99999, did, subgrpid);
            //}
            //else if (time >= 13 && time < 16)
            //{
            //    dt = outsobj.getOutstdschedule12NFACor(99999, did, subgrpid);
            //}
            //else if (time >= 16 && time < 23)
            //{
            //    dt = outsobj.OutStdingGET3PMFACor(99999, did, subgrpid);
            //}

            if (time < 13)
            {
                dt = outsobj.OutStdingGET(99999, did, subgrpid);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outsobj.OutStdingGET12N(99999, did, subgrpid);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outsobj.OutStdingGET3PM(99999, did, subgrpid);
            }


           
            //dt_outstanting = da_obj_misgrd.Getnewoutstanding4MIS(Convert.ToInt32(Session["LoginEmpId"].ToString()), 0, Convert.ToInt32(Session["LoginDivisionId"].ToString()), subgrpid, "CO");
            if (dt.Rows.Count > 0)
            {
               DataRow dr = dt.NewRow();
                dr["customer"] = "Total";
                dr["amount"] = dt.Compute("sum(amount)", "");
                dr["overdue"] = dt.Compute("sum(overdue)", "");
                dt.Rows.Add(dr);
                GridView2.DataSource = dt;
                GridView2.DataBind();
                ViewState["dt_outstanting"] = dt;
            }
            else
            {
                ViewState["dt_outstanting"] = null;
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                        Label lblshortname = (Label)e.Row.FindControl("shortname");
                        Label lblvouno = (Label)e.Row.FindControl("vouno");

                        if (lblshortname.Text == "Total")
                        {
                            e.Row.ForeColor = System.Drawing.Color.Brown;
                            lblvouno.Text = "";
                            e.Row.Cells[9].Text = "";
                            e.Row.Cells[10].Text = "";
                            e.Row.Cells[11].Text = "";
                            e.Row.Cells[12].Text = "";
                            e.Row.Cells[13].Text = "";
                        }
                    }
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[8].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[8].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[8].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[10].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[10].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[10].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[12].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[12].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[12].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }
        */

        //public void count2()
        //{
        //    dtCout = objpay.getcreditnote_operation("PA", "CA", 0, Convert.ToInt32(Session["LoginDivisionId"]));
        //    if (dtCout.Rows.Count > 0)
        //    {

        //        if (dtCout.Rows[0]["voutype"].ToString() == "P")
        //        {

        //            Link_CNOPS.Text = dtCout.Rows[0]["counts"].ToString();
        //        }
        //        else
        //        {
        //            Link_CNOPS.Text = "0";
        //        }
        //    }
        //    dtCout = objpay.getcreditnote_operation("CN", "CA", 0, Convert.ToInt32(Session["LoginDivisionId"]));

        //    if (dtCout.Rows.Count > 0)
        //    {

        //        if (dtCout.Rows[0]["voutype"].ToString() == "E")
        //        {

        //            Link_CN.Text = dtCout.Rows[0]["counts"].ToString();
        //        }
        //        else
        //        {
        //            Link_CN.Text = "0";
        //        }
        //    }
        //    dtCout = objpay.getcreditnote_operation("AP", "CA", 0, Convert.ToInt32(Session["LoginDivisionId"]));

        //    if (dtCout.Rows.Count > 0)
        //    {

        //        if (dtCout.Rows[0]["voutype"].ToString() == "S")
        //        {

        //            link_CNADmin.Text = dtCout.Rows[0]["counts"].ToString();
        //        }
        //        else
        //        {
        //            link_CNADmin.Text = "0";
        //        }
        //    }

        //}
        /*
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = ViewState["dt_outstanting"] as DataTable;
            GridView2.DataBind();
        }

        protected void Grid_bankbalance_SelectIndexChanged(object sender, EventArgs e)
        {
            int rowindex;
            string ledger = "";

            rowindex = Grid_bankbalance.SelectedRow.RowIndex;


            FADbname = Session["FADbname"].ToString();
            dt = objpay.GetBankBalancefordashboard(FADbname.ToString(), Convert.ToInt32(Session["LoginBranchid"]));

            if (dt.Rows.Count > 0)
            {
                ledger = dt.Rows[rowindex]["bank"].ToString();
                Response.Redirect("../FAForms/FALedgerView.aspx?ledgerid=" + dt.Rows[rowindex]["ledgerid"].ToString() + "&ledger=" + ledger);
            }



        }
        */
        /*
        protected void link_button_Click(object sender, EventArgs e)
        {
            // lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        //  Session["RightsTranType"] = "MI";
                        dtuser = obj_UP.GetFormwiseuserRights(643, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MI");
                    }
                    //else
                    //{
                    //    Session["RightsTranType"] = Session["StrTranType"].ToString();
                    //}
                }

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ChequeBounce_PC.aspx?type=" + "Payment Cancel");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }

        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            // lbl_Header.Visible = false;

            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        //Session["RightsTranType"] = "MI";
                        dtuser = obj_UP.GetFormwiseuserRights(1056, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MI");
                    }
                    //else
                    //{
                    //    Session["RightsTranType"] = Session["StrTranType"].ToString();
                    //}
                }

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ACNotOverCheque.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            //lbl_Header.Visible = false;

            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        //Session["RightsTranType"] = "MI";
                        dtuser = obj_UP.GetFormwiseuserRights(545, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MI");

                    }

                }

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/VoucherRegister.aspx?type=Voucher Register");

                }
                //else if (dtuser.Rows.Count==0)
                //{
                //    Response.Redirect("../FAForms/VoucherRegister.aspx?type=VoucherRegister");
                //}

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            // lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        // Session["RightsTranType"] = "MI";
                        dtuser = obj_UP.GetFormwiseuserRights(1342, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MI");
                    }
                    //else
                    //{
                    //    Session["RightsTranType"] = Session["StrTranType"].ToString();
                    //}
                }

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/Sinsaudit.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            //lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        // Session["RightsTranType"] = "MI";
                        dtuser = obj_UP.GetFormwiseuserRights(562, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MI");
                    }
                    //else
                    //{
                    //    Session["RightsTranType"] = Session["StrTranType"].ToString();
                    //}
                }

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/TDSidForCustomer.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            // lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        //Session["RightsTranType"] = "MI";

                        dtuser = obj_UP.GetFormwiseuserRights(560, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "MI");
                    }
                    //else
                    //{
                    //    Session["RightsTranType"] = Session["StrTranType"].ToString();
                    //}
                }

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/JobSee.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            // lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        //Session["RightsTranType"] = "FC";
                        dtuser = obj_UP.GetFormwiseuserRights(1242, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FC");
                    }
                    //else
                    //{
                    //    Session["RightsTranType"] = Session["StrTranType"].ToString();
                    //}
                }

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../FAForms/RptOSDN_CN.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }

        }
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            // lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        //  Session["RightsTranType"] = "FC";
                        dtuser = obj_UP.GetFormwiseuserRights(1243, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FC");
                    }
                    //else
                    //{
                    //    Session["RightsTranType"] = Session["StrTranType"].ToString();
                    //}
                }

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../FAForms/RptOSDN_CN.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }

        }
        */
        /*
        protected void link_collection_Click(object sender, EventArgs e)
        {
            BranchTitle1.Visible = false;
            outstanding.Visible = false;
            ddl_branch.Visible = false;
            Bankbalancetitle.Visible = false;
            GridbankBNL.Visible = false;
            Div_chart.Visible = false;

        }
        protected void exp2excgrdunc_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["dt_outstanting"] as DataTable;
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
                    Response.AddHeader("content-disposition", "attachment;filename=OutStanding.xls");
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
        protected void Grid_salesout_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                    e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                for (int h = 1; h <= e.Row.Cells.Count - 1; h++)
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
        protected void excportexc_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GridSalesOutPerson"] as DataTable;
                 dt_check.Columns.Remove("salesid");

            if (Grid_salesout.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Outstanding.xls");
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
        */

        // Calendar Form  Start

        [WebMethod]
        public static List<EventViewModel> GetCalendarData()
        {

            DataAccess.Outstanding outobj = new DataAccess.Outstanding();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            outobj.GetDataBase(Ccode);
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            ds = outobj.GetCalenderDetails4HomeNew(Convert.ToInt32(HttpContext.Current.Session["Vouyear"].ToString()));

            dt1 = ds.Tables[0];
            dt2 = ds.Tables[1];
            var dataTable1 = GetDataTable1(dt1); // Replace with your data retrieval logic
            var dataTable2 = GetDataTable2(dt2); // Replace with your data retrieval logic

            var events = new List<EventViewModel>();

            events.AddRange(GetEventsFromDataTable(dataTable1));
            events.AddRange(GetEventsFromDataTable(dataTable2));

            return events;
        }
        private static List<EventViewModel> GetEventsFromDataTable(DataTable dataTable)
        {
            var events = new List<EventViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                var eventStartDate = Convert.ToDateTime(row["StartDate"]);
                var eventEndDate = Convert.ToDateTime(row["EndDate"]);
                var eventTitle = row["EventTitle"].ToString();
                var eventColor = row["Color"].ToString();
                var eventUrl = row["Url"].ToString();

                var eventModel = new EventViewModel
                {
                    Start = eventStartDate,
                    End = eventEndDate,
                    Title = eventTitle,
                    Color = eventColor,
                    Url = eventUrl
                };

                events.Add(eventModel);
            }

            return events;
        }
        // Replace with your actual data retrieval logic for DataTable1
        private static DataTable GetDataTable1(DataTable dt1)
        {
            // Example: Mock data for testing
            var dataTable = new DataTable();
            dataTable.Columns.Add("StartDate", typeof(DateTime));
            dataTable.Columns.Add("EndDate", typeof(DateTime));
            dataTable.Columns.Add("EventTitle", typeof(string));
            dataTable.Columns.Add("Color", typeof(string));
            dataTable.Columns.Add("Url", typeof(string));

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string sdate = dt1.Rows[i]["voudate"].ToString();
                string edate = dt1.Rows[i]["voudate"].ToString();
                string rpname1 = dt1.Rows[i]["customer"].ToString();

                //string rpname1 = "Receivable";

                dataTable.Rows.Add(Convert.ToDateTime(sdate), Convert.ToDateTime(edate), rpname1 + " : " + dt1.Rows[i]["amount"].ToString(), "green", "../FAForms/OutstandingDetailsCal.aspx?todatecal=" + edate + "-R");


            }
            //dataTable.Rows.Add(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(1), "Event 1", "green", "https://example.com/event1");

            return dataTable;
        }
        protected void calender_Click(object sender, EventArgs e)
        {
            div_calender.Visible = true;
            div_card.Visible = false;

        }
        protected void card_Click(object sender, EventArgs e)
        {
            div_calender.Visible = false;
            div_card.Visible = true;

        }


        // Replace with your actual data retrieval logic for DataTable2
        private static DataTable GetDataTable2(DataTable dt2)
        {
            // Example: Mock data for testing
            var dataTable = new DataTable();
            dataTable.Columns.Add("StartDate", typeof(DateTime));
            dataTable.Columns.Add("EndDate", typeof(DateTime));
            dataTable.Columns.Add("EventTitle", typeof(string));
            dataTable.Columns.Add("Color", typeof(string));
            dataTable.Columns.Add("Url", typeof(string));


            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string sdate = dt2.Rows[i]["voudate"].ToString();
                string edate = dt2.Rows[i]["voudate"].ToString();
                string rpname2 = dt2.Rows[i]["customer"].ToString();

                //string rpname2 = "Payable";

                dataTable.Rows.Add(Convert.ToDateTime(sdate), Convert.ToDateTime(edate), rpname2 + " : " + dt2.Rows[i]["amount"].ToString(), "blue", "../FAForms/OutstandingDetailsCal.aspx?todatecal=" + edate + "-P");


            }

            //dataTable.Rows.Add(DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(2), "Event 2", "blue", "https://example.com/event2");

            return dataTable;
        }


        /*
        [WebMethod]
        public static List<CalendarEvents> GetCalendarData1()
        {
            //-- this is the webmethod that you will require to create to fetch data from database
            return GetCalendarDataFromDatabase();
        }

        [WebMethod]
        public static string SaveEvent(CalendarEvents newEvent)
        {
            try
            {
                // Validate and save the event in the database 
                // Example: DbContext.Events.Add(newEvent);  DbContext.SaveChanges(); 
                string constring = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert into SlotMaster(SlotStatus,SlotStartTime,SlotEndTime,SlotDate)VALUES(@SlotStatus,@SlotStartTime,@SlotEndTime,@SlotDate)", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.Parameters.AddWithValue("@SlotStatus", "Active");
                        cmd.Parameters.AddWithValue("@SlotStartTime", newEvent.slotStartTime);
                        cmd.Parameters.AddWithValue("@SlotEndTime", newEvent.slotEndTime);
                        cmd.Parameters.AddWithValue("@SlotDate", newEvent.slotDate);
                        cmd.ExecuteNonQuery(); con.Close();
                    }
                }
                return "success";
            }
            catch (Exception ex)
            {
                return "failure";
            }
        }


        
        private static List<CalendarEvents> GetCalendarDataFromDatabase()
        {
            List<CalendarEvents> CalendarList = new List<CalendarEvents>();
            List<CalendarEvents1> CalendarList1 = new List<CalendarEvents1>();

            DataAccess.Outstanding outobj = new DataAccess.Outstanding();

            DataSet ds = new DataSet();

            //DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            //ds = outobj.OutStandingNewLedgerNew(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), 40);

            //ds = outobj.GetCalenderDetails4Home();
            ds = outobj.GetCalenderDetails4HomeNew(Convert.ToInt32(HttpContext.Current.Session["Vouyear"].ToString()));

            dt1 = ds.Tables[0];
            dt2 = ds.Tables[1];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string sdate = dt1.Rows[i]["voudate"].ToString();
                string edate = dt1.Rows[i]["voudate"].ToString();

                CalendarEvents Calendar = new CalendarEvents();

                Calendar.slotID = i + 1;
                Calendar.slotDate = Convert.ToDateTime(dt1.Rows[i]["voudate"].ToString());
                Calendar.slotStatus = "Active";
                Calendar.slotStartTime = Convert.ToDateTime(sdate);
                Calendar.slotEndTime = Convert.ToDateTime(edate);

                Calendar.EventTitle = "Receivable : " + dt1.Rows[i]["amount"].ToString();
                Calendar.Title = dt1.Rows[i]["amount"].ToString();

                if (Calendar.slotStatus == "ACTIVE")
                {
                    Calendar.color = "green";
                }
                else
                {
                    // Calendar.color = "white"; 
                }

                Calendar.url = "../FAForms/OutstandingDetailsCal.aspx?todatecal=" + Convert.ToDateTime(edate);

                CalendarList.Add(Calendar);
            }
            /*
            for (int j = 0; j < dt2.Rows.Count; j++)
            {
                string sdate = dt2.Rows[j]["voudate"].ToString();
                string edate = dt2.Rows[j]["voudate"].ToString();

                Calendar.slotID = j + 1;
                Calendar.slotDate = Convert.ToDateTime(dt2.Rows[j]["voudate"].ToString());
                Calendar.slotStatus = "Active";
                Calendar.slotStartTime = Convert.ToDateTime(sdate);
                Calendar.slotEndTime = Convert.ToDateTime(edate);

                Calendar.EventTitle = "Payable : " + dt2.Rows[j]["amount"].ToString();
                Calendar.Title = dt2.Rows[j]["amount"].ToString();

                if (Calendar.slotStatus == "ACTIVE")
                {
                    Calendar.color = "blue";
                }
                else
                {
                    // Calendar.color = "white"; 
                }

                Calendar.url = "../FAForms/OutstandingDetailsCal.aspx?todatecal=" + Convert.ToDateTime(edate);

            }
            */

        //for (int j = 0; j < dt2.Rows.Count; j++)
        //{
        //    string sdate = dt2.Rows[j]["voudate"].ToString();
        //    string edate = dt2.Rows[j]["voudate"].ToString();


        //    CalendarEvents1 Calendar1 = new CalendarEvents1();
        //    Calendar1.slotID1 = j + 1;
        //    Calendar1.slotDate1 = Convert.ToDateTime(dt2.Rows[j]["voudate"].ToString());
        //    Calendar1.slotStatus1 = "Active";
        //    Calendar1.slotStartTime1 = Convert.ToDateTime(sdate);
        //    Calendar1.slotEndTime1 = Convert.ToDateTime(edate);

        //    Calendar1.EventTitle1 = dt2.Rows[j]["amount"].ToString();
        //    Calendar1.Title1 = dt2.Rows[j]["amount"].ToString();

        //    if (Calendar1.slotStatus1 == "ACTIVE")
        //    {
        //        Calendar1.color1 = "green";
        //    }
        //    else
        //    {
        //        // Calendar.color = "white"; 
        //    }
        //    CalendarList1.Add(Calendar1);
        //}


        /*
        string constring = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString; 
        using (SqlConnection con = new SqlConnection(constring)) 
        { 
            string strQuery = "Select * FROM SlotMaster where slotStatus='ACTIVE' "; 
            using (SqlCommand cmd = new SqlCommand(strQuery, con)) 
            { 
                cmd.CommandType = CommandType.Text; 
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd)) 
                { 
                    DataSet ds1 = new DataSet(); 
                    // ds = ClsDAL.QueryEngine(strQuery, "SlotMaster"); 
                    DataTable dt = new DataTable(); 
                    sda.Fill(dt); 
                    //dt = ds.Tables[0]; 
                    for (int i = 0; i < dt.Rows.Count; i++) 
                    { 
                        CalendarEvents Calendar = new CalendarEvents(); 
                        Calendar.slotID = Convert.ToInt32(dt.Rows[i]["slotID"]); 
                        Calendar.slotDate = Convert.ToDateTime(dt.Rows[i]["slotDate"]); 
                        Calendar.slotStatus = dt.Rows[i]["slotStatus"].ToString(); 
                        Calendar.slotStartTime = Convert.ToDateTime(dt.Rows[i]["slotStartTime"]);                             
                        Calendar.slotEndTime = Convert.ToDateTime(dt.Rows[i]["slotEndTime"]); 

                        if (Calendar.slotStatus == "ACTIVE") 
                        { 
                            Calendar.color = "green"; 
                        } 
                        else 
                        { 
                            // Calendar.color = "white"; 
                        } 
                        CalendarList.Add(Calendar); 
                    } 
                } 
            } 
        } 

        return CalendarList;
    }




    //public class CalendarEvents
    //{
    //    public int slotID { get; set; }
    //    public DateTime slotStartTime { get; set; }
    //    public DateTime slotEndTime { get; set; }
    //    public DateTime slotDate { get; set; }
    //    public string EventDescription { get; set; }
    //    public string Title { get; set; }
    //    public string slotStatus { get; set; }
    //    public int bookingID { get; set; }
    //    public bool AllDayEvent { get; set; }
    //    public string color { get; set; }

    //    public string EventTitle { get; set; }

    //    public string url { get; set; }

    //}

    //public class CalendarEvents1
    //{
    //    public int slotID1 { get; set; }
    //    public DateTime slotStartTime1 { get; set; }
    //    public DateTime slotEndTime1 { get; set; }
    //    public DateTime slotDate1 { get; set; }
    //    public string EventDescription1 { get; set; }
    //    public string Title1 { get; set; }
    //    public string slotStatus1 { get; set; }
    //    public int bookingID1 { get; set; }
    //    public bool AllDayEvent1 { get; set; }
    //    public string color1 { get; set; }

    //    public string EventTitle1 { get; set; }

    //}

    */


        //[WebMethod]
        //public static List<string> GetOutstanding1()
        //{
        //    List<string> List_Result = new List<string>();
        //    DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        //    DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
        //    DataAccess.Accounts.Recipts recobj = new DataAccess.Accounts.Recipts();
        //    DataTable dt = new DataTable();
        //    string rtypeval = HttpContext.Current.Session["Rtype"].ToString();
        //    string BranchName = Convert.ToString(HttpContext.Current.Session["LoginBranchName"].ToString());
        //    int Div_Id = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
        //    int BranchId = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
        //    int logcorid = Emp_Obj.GetBranchId(Div_Id, "CORPORATE");

        //    dt.Columns.Add("ID");
        //    dt.Columns.Add("Title");
        //    dt.Columns.Add("StartDateString");
        //    dt.Columns.Add("EndDateString");
        //    dt.Columns.Add("StatusColor");
        //    dt.Columns.Add("ClassName");
        //    dt.Columns.Add("SomeImportantKeyID");

        //    dt.Rows[0]["ID"]="40";
        //    dt.Rows[0]["Title"]="";
        //    dt.Rows[0]["StartDateString"]="2022-04-01";
        //    dt.Rows[0]["EndDateString"]="2024-03-31";
        //    dt.Rows[0]["StatusColor"]="";
        //    dt.Rows[0]["ClassName"]="";
        //    dt.Rows[0]["SomeImportantKeyID"]="";

        //    //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("ID")});
        //    //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Title")});
        //    //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("StartDateString")});
        //    //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("EndDateString")});
        //    //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("StatusColor")});
        //    //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("ClassName")});
        //    //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("SomeImportantKeyID")});


        //    //dt.Columns.AddRange(new DataColumn("ID"),new DataColumn("Title"),new DataColumn("StartDateString"),new DataColumn("EndDateString"),new DataColumn("StatusColor"),new DataColumn("ClassName"),new DataColumn("SomeImportantKeyID"));

        //    //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("ID") },new DataColumn[1] { new DataColumn("Title") },new DataColumn[1] { new DataColumn("StartDateString") }
        //    //    ,new DataColumn[1] { new DataColumn("EndDateString") },new DataColumn[1] { new DataColumn("StatusColor") },new DataColumn[1] { new DataColumn("ClassName") }
        //    //    ,new DataColumn[1] { new DataColumn("SomeImportantKeyID") });



        //    List_Result = Utility.Fn_DatatableToList_int16Display(dt, "customer", "customerid", "customername");
        //    return List_Result;
        //}


        //[WebMethod]
        //public static string GetOutstanding1()
        //{
        //    List<GetOutstandingDetails> List_Result = new List<GetOutstandingDetails>();
        //    var ApptListForDate = GetOutstandingDetails.LoadAllAppointmentsInDateRange();//(start, end);
        //    var eventList = from e in ApptListForDate
        //                    select new
        //                    {
        //                        id = e.ID,
        //                        title = e.Title,
        //                        start = e.StartDateString,
        //                        end = e.EndDateString,
        //                        color = e.StatusColor,
        //                        className = e.ClassName,
        //                        someKey = e.SomeImportantKeyID,
        //                        allDay = false
        //                    };
        //    var rows = eventList.ToArray();
        //    List_Result = GetOutstandingDetails.LoadAllAppointmentsInDateRange();
        //    //return List_Result;

        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    string output = jss.Serialize(rows);
        //    return output;
        //}

        //public static List<GetOutstandingDetails> LoadAllAppointmentsInDateRange()
        //{

        //    List<GetOutstandingDetails> result1 = new List<GetOutstandingDetails>();

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("ID");
        //    dt.Columns.Add("Title");
        //    dt.Columns.Add("StartDateString");
        //    dt.Columns.Add("EndDateString");
        //    dt.Columns.Add("StatusColor");
        //    dt.Columns.Add("ClassName");
        //    dt.Columns.Add("SomeImportantKeyID");

        //    dt.Rows[0]["ID"] = "40";
        //    dt.Rows[0]["Title"] = "";
        //    dt.Rows[0]["StartDateString"] = "2022-04-01";
        //    dt.Rows[0]["EndDateString"] = "2024-03-31";
        //    dt.Rows[0]["StatusColor"] = "";
        //    dt.Rows[0]["ClassName"] = "";
        //    dt.Rows[0]["SomeImportantKeyID"] = "";


        //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //    {
        //        GetOutstandingDetails rec = new GetOutstandingDetails();
        //        rec.ID = Convert.ToInt32(dt.Rows[i]["CRMSalesPersonApoinmentDetailsid"].ToString());


        //        rec.StartDateString = dt.Rows[i]["StartDateString"].ToString();
        //        rec.EndDateString = dt.Rows[i]["EndDateString"].ToString();

        //        rec.Title = dt.Rows[i]["ID"].ToString();
        //        rec.StatusString = Enums.GetName<AppointmentStatus>((AppointmentStatus)0);//dt.Rows[i]["StatusENUM"]);
        //        rec.StatusColor = Enums.GetEnumDescription<AppointmentStatus>(rec.StatusString);
        //        string ColorCode = rec.StatusColor.Substring(0, rec.StatusColor.IndexOf(":"));
        //        rec.ClassName = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":") + 1, rec.StatusColor.Length - ColorCode.Length - 1);
        //        rec.StatusColor = ColorCode;
        //        result1.Add(rec);
        //    }

        //}


        //public class GetOutstandingDetails
        //{
        //    public int crmid;
        //    public string adate;
        //    public string ftime;
        //    public int CRMSalesPersonApoinmentDetailsid;

        //    public int ID;
        //    public string Title;
        //    public int SomeImportantKey;
        //    public string StartDateString;
        //    public string EndDateString;
        //    public string StatusString;
        //    public string StatusColor;
        //    public string ClassName;
        //    public int SomeImportantKeyID;
        //    public DateTime OutstdScheduled;

        //    public static List<GetOutstandingDetails> LoadAllAppointmentsInDateRange1()
        //    {

        //        List<GetOutstandingDetails> List_Result1 = new List<GetOutstandingDetails>();
        //        DataAccess.Outstanding outstdobj = new DataAccess.Outstanding();
        //        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        //        DataTable dtapo = new DataTable();

        //        int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
        //        dtapo = outstdobj.OutStandingNewLedger(empid, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), 40, logobj.GetDate(), 0);

        //        List<GetOutstandingDetails> result1 = new List<GetOutstandingDetails>();
        //        if (dtapo.Rows.Count > 0)
        //        {

        //            for (int i = 0; i <= dtapo.Rows.Count - 1; i++)
        //            {
        //                GetOutstandingDetails rec = new GetOutstandingDetails();
        //                rec.ID = Convert.ToInt32(dtapo.Rows[i]["CRMSalesPersonApoinmentDetailsid"].ToString());


        //                rec.StartDateString = dtapo.Rows[i]["adate"].ToString();
        //                rec.EndDateString = dtapo.Rows[i]["edate"].ToString();

        //                rec.Title = dtapo.Rows[i]["crmid"].ToString();
        //                rec.StatusString = Enums.GetName<AppointmentStatus>((AppointmentStatus)0);//dt.Rows[i]["StatusENUM"]);
        //                rec.StatusColor = Enums.GetEnumDescription<AppointmentStatus>(rec.StatusString);
        //                string ColorCode = rec.StatusColor.Substring(0, rec.StatusColor.IndexOf(":"));
        //                rec.ClassName = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":") + 1, rec.StatusColor.Length - ColorCode.Length - 1);
        //                rec.StatusColor = ColorCode;
        //                result1.Add(rec);
        //            }
        //        }
        //        return result1;
        //    }
        //}

        //public static class Enums
        //{
        //    /// Get all values
        //    public static IEnumerable<T> GetValues<T>()
        //    {
        //        return Enum.GetValues(typeof(T)).Cast<T>();
        //    }

        //    /// Get all the names
        //    public static IEnumerable<T> GetNames<T>()
        //    {
        //        return Enum.GetNames(typeof(T)).Cast<T>();
        //    }

        //    /// Get the name for the enum value
        //    public static string GetName<T>(T enumValue)
        //    {
        //        return Enum.GetName(typeof(T), enumValue);
        //    }

        //    /// Get the underlying value for the Enum string
        //    public static int GetValue<T>(string enumString)
        //    {
        //        return (int)Enum.Parse(typeof(T), enumString.Trim());
        //    }

        //    public static string GetEnumDescription<T>(string value)
        //    {
        //        Type type = typeof(T);
        //        var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

        //        if (name == null)
        //        {
        //            return string.Empty;
        //        }
        //        var field = type.GetField(name);
        //        var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
        //        return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
        //    }
        //}
        //public enum AppointmentStatus
        //{
        //    [Description("#3a87ad:ENQUIRY")] // green
        //    Enquiry = 0,
        //    [Description("#3a87ad:BOOKED")] // orange
        //    Booked,
        //    [Description("#3a87ad:CONFIRMED")] // red
        //    Confirmed

        //}

        // Calendar End 


    }

    public class EventViewModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Url { get; set; }
    }

}