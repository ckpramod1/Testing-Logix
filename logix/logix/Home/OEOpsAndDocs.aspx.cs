using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Services;
using System.Text;
using ClosedXML.Excel;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Remoting;

namespace logix.Home
{
    public partial class OEOpsAndDocs : System.Web.UI.Page
    {
        DataAccess.Documents Dobj = new DataAccess.Documents();
        DataAccess.Masters.MasterExRate exrateshow = new DataAccess.Masters.MasterExRate();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.CloseJobs objClosedJob = new DataAccess.CloseJobs();
        DataAccess.ForwardingExports.JobInfo objJobInfo = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
        DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Accounts.OSDNCN obj_da_invoice2 = new DataAccess.Accounts.OSDNCN();
        DataAccess.Documents objnew = new DataAccess.Documents();
        DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
       
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
       
        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
        DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataSet DtSet = new DataSet();
        DataTable dt = new DataTable();
        DataTable dthbl = new DataTable();
        int vouyear, branchid, intcount;
        long lngPQuot, lngInv, lngPA, lngDN, lngCN, lngInvFC, lngPAFC;
        DataTable Dtckeck = new DataTable();
        int row = 0, cell = 0;
        int invoinumberfright;
        protected void Page_Load(object sender, EventArgs e)
        {


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Dobj.GetDataBase(Ccode);
                exrateshow.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_da_Log1.GetDataBase(Ccode);
                leftObj.GetDataBase(Ccode);
                Appobj.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                exrobj.GetDataBase(Ccode);
                objbu.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);

                objClosedJob.GetDataBase(Ccode);
                objJobInfo.GetDataBase(Ccode);
                obj_da_FA.GetDataBase(Ccode);
                obj_da_jobinfo.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                obj_da_Logobj.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                obj_da_invoice.GetDataBase(Ccode);
                obj_da_invoice2.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_invoice2.GetDataBase(Ccode);
                objnew.GetDataBase(Ccode);
                obj_da_OSDNCN.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                employeeobj.GetDataBase(Ccode);
                obj_da_FAVoucher.GetDataBase(Ccode);
                obj_da_Ledger.GetDataBase(Ccode);
                obj_da_BL.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                obj_da_Cheque.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                //STufobj.GetDataBase(Ccode);
                //quotobj.GetDataBase(Ccode);

            }


            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();dropdownButton();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GetEmpolyeeJson();SpanTagMoveInputBottom();MuiTextField();dropdownButton();", true);

            //if (Session["Val"] != null)
            //{
            //    Session["Val"] = null;
            //    AePopUpNewDate.Visible = false;
            //    // iframecost.Visible = false;
            //    // this.aePopUpshow.Hide();
            //}

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(link_cust);

            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Grd_Approval);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_cut1);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(linkunclose);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lbl_blrelease);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(link_pending);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(link_unclosed);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton12);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton14);

            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(GridView3);

            if (!IsPostBack)
            {
                string taskId = Request.QueryString["taskid"];

                if (taskId == "12")
                {
                    hid_TaskId.Value = "1";
                    hid_TaskValue.Value = "Sales Invoice";


                    ddl_voutype.SelectedItem.Text = "Sales Invoice";

                    ddl_voutype.SelectedItem.Enabled = false;

                    lnk_proInvoice_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }

                if (taskId == "28")
                {
                    hid_TaskId.Value = "1";
                    hid_TaskValue.Value = "Sales Invoice OC";

                    ddl_voutype.SelectedItem.Text = "Sales Invoice OC";

                    ddl_voutype.SelectedItem.Enabled = false;

                    lnk_proInvoice_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }

                if (taskId == "26")
                {
                    hid_TaskId.Value = "1";
                    hid_TaskValue.Value = "OSSI";

                    ddl_voutype.SelectedItem.Text = "OSSI";

                    ddl_voutype.SelectedItem.Enabled = false;

                    lnk_proInvoice_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }
                if (taskId == "13")
                {
                    hid_TaskId.Value = "1";
                    hid_TaskValue.Value = "Purchase Invoice";

                    ddl_voutype.SelectedItem.Text = "Purchase Invoice";

                    ddl_voutype.SelectedItem.Enabled = false;

                    lnk_Prooncps_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }
                if (taskId == "29")
                {
                    hid_TaskId.Value = "1";
                    hid_TaskValue.Value = "Purchase Invoice OC";

                    ddl_voutype.SelectedItem.Text = "Purchase Invoice OC";

                    ddl_voutype.SelectedItem.Enabled = false;

                    lnk_Prooncps_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }
                if (taskId == "27")
                {
                    hid_TaskId.Value = "1";
                    hid_TaskValue.Value = "OSPI";

                    ddl_voutype.SelectedItem.Text = "OSPI";

                    ddl_voutype.SelectedItem.Enabled = false;

                    lnk_proInvoice_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }
                if (taskId == "14" || taskId == "25")
                {
                    lnk_Blrelase_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }
                if (taskId == "16")
                {
                    lnk_Unclosed_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }
                if (taskId == "1" || taskId == "6" || taskId == "24")
                {
                    if (taskId == "24") { Hdn_taskid.Value = "Job Updation"; }

                    lnk_blnum_Click(sender, e);
                    card_parent.Visible = false;
                    return;
                }
                rightbookingno.Visible = false;
                if (Session["StrTranType"] != null)
                {
                    hidlbl.Value = Session["StrTranType"].ToString();
                }
                vis_div();
                lbl_blrelease.Visible = false;
                lnk_cut1.Visible = false;

                if (Session["StrTranType"].ToString() == "FE")
                {
                    OptionDoc.InnerText = "Documentation - Ocean Exports ";
                    BL1name.InnerText = "BL";
                }
                if (Session["StrTranType"].ToString() == "FI")
                {
                    OptionDoc.InnerText = "Documentation - Ocean Imports ";
                    LinkButtonsb.Visible = false;
                    BL1name.InnerText = "BL";
                }
                if (Session["StrTranType"].ToString() == "AE")
                {
                    OptionDoc.InnerText = "Documentation - Air Exports ";
                    LinkButtonsb.Visible = false;
                    BL1name.InnerText = "AWB";
                }
                if (Session["StrTranType"].ToString() == "AI")
                {
                    OptionDoc.InnerText = "Documentation - Air Imports ";
                    LinkButtonsb.Visible = false;
                    BL1name.InnerText = "AWB";
                }

                //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();             
                DataTable dtevent;
                dtevent = objRpt.Eventpendingcount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                if (dtevent.Rows.Count > 0)
                {
                    GridView6.DataSource = dtevent;
                    GridView6.DataBind();
                }

                if (Session["StrTranType"].ToString() == "FE")
                {
                    BL1name.InnerText = "BL";
                    //getdata();
                    div_floatleft.Visible = false;
                    div6.Visible = true;
                    div_line.Visible = true;
                    //lnr_chart.Visible = true;
                    PendingApprovalFE();
                    // Line_cahrt();
                    salelinechart();
                    Get_BLCounts();
                    Counts_Blrelase();
                    Unclose_Count();
                    //pendingHBLFE();
                    divexrate.Visible = true;
                    loadgrd();
                    Lnk_eventslbl.Visible = true;

                    //LoadOceanEvent1();
                    // GrdOceanExp1.Visible = true;
                    // PanelPendingEvent.Visible = true;
                    //  div2.Visible = true;
                    //PieChart1.Visible = true;
                    // loadcustwise();
                    // custid.Visible = true;
                    //pnlGrdCuswise.Visible = true;
                    // GrdCuswise.Visible = true;
                    //Label1.Text = "Customer Wise";
                    //LinkButton3.Visible = true;
                    //LinkButton4.Visible = true;

                    //LinkButton5.Visible = true;

                    //LinkButton6.Visible = true;
                    //LinkButtonfbl.Visible = false;
                    //LinkButton8.Visible = true;
                    //LinkButton9.Visible = true;
                    // LinkButton10.Visible = true;
                    LinkButtonfbl.Visible = false;
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    BL1name.InnerText = "BL";
                    //LoadOceanEventIMP();
                    //GrdOceanExp1.Visible = true;
                    //PanelPendingEvent.Visible = true;
                    //getdata();
                    //PendingApprovalFE();
                    //pendingHBLFE();
                    //loadgrd();
                    //custid.Visible = true;
                    //headlbl.InnerText = "consignee Wise";
                    //headlbl1.InnerText = "consignee Wise BL#";
                    //div2.Visible = true;
                    //PieChart1.Visible = true;
                    //loadcosigneewise();
                    //pnlGrdCuswise.Visible = true;
                    //GrdCuswise.Visible = true;
                    //Label1.Text = "Consignee Wise";
                    //LinkButton3.Visible = true;
                    //LinkButton4.Visible = true;

                    //LinkButton5.Visible = false;

                    //LinkButtonsb.Visible = false;
                    //LinkButton6.Visible = true;
                    //LinkButtonfbl.Visible = true;
                    //LinkButton8.Visible = true;
                    //LinkButton9.Visible = true;
                    //LinkButton10.Visible = true;

                    div6.Visible = true;
                    div_line.Visible = true;
                    divexrate.Visible = true;
                    Lnk_eventslbl.Visible = true;
                    loadgrd();
                    //lnr_chart.Visible = true;
                    PendingApprovalFE();
                    // Line_cahrt();
                    salelinechart();
                    Get_BLCounts();
                    Counts_Blrelase();
                    Unclose_Count();
                    LinkButtonfbl.Visible = true;
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    BL1name.InnerText = "AWB";

                    //hid_pending.Visible = false;
                    //Panel1.Visible = false;
                    //GrdOceanExp1.Visible = false;
                    //getdata();

                    /////panelservice.Visible = true;

                    //PendingApprovalFE();
                    //// pendingHBLFE();
                    //// loadgrd();
                    //custid.Visible = false;
                    //headlbl.Visible = false;
                    //pnlGrdCuswise.Visible = false;
                    //GrdCuswise.Visible = false;
                    //LinkButton3.Visible = true;
                    //LinkButton4.Visible = true;

                    //LinkButton5.Visible = false;
                    //LinkButton6.Visible = true;
                    //LinkButtonsb.Visible = false;
                    //LinkButtonfbl.Visible = false;
                    //LinkButton8.Visible = true;
                    //LinkButton9.Visible = true;
                    //LinkButton10.Visible = true;

                    div6.Visible = true;
                    div_line.Visible = true;
                    divexrate.Visible = true;
                    Lnk_eventslbl.Visible = false;
                    loadgrd();
                    //lnr_chart.Visible = true;
                    PendingApprovalFE();
                    // Line_cahrt();
                    salelinechart();
                    Get_BLCounts();
                    Counts_Blrelase();
                    Unclose_Count();
                    LinkButtonfbl.Visible = false;
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    BL1name.InnerText = "AWB";

                    //hid_pending.Visible = false;
                    //Panel1.Visible = false;
                    //GrdOceanExp1.Visible = false;
                    //getdata();
                    ////panelservice.Visible = true;
                    //PendingApprovalFE();
                    ////pendingHBLFE();
                    ////loadgrd();
                    //custid.Visible = false;
                    //headlbl.Visible = false;
                    //pnlGrdCuswise.Visible = false;
                    //GrdCuswise.Visible = false;
                    //LinkButton3.Visible = true;
                    //LinkButton4.Visible = true;

                    //LinkButton5.Visible = false;
                    //LinkButton6.Visible = true;
                    //LinkButtonsb.Visible = false;
                    //LinkButtonfbl.Visible = false;
                    //LinkButton8.Visible = true;
                    //LinkButton9.Visible = true;
                    //LinkButton10.Visible = true;

                    div6.Visible = true;
                    div_line.Visible = true;
                    divexrate.Visible = true;
                    Lnk_eventslbl.Visible = false;
                    loadgrd();
                    //lnr_chart.Visible = true;
                    PendingApprovalFE();
                    // Line_cahrt();
                    salelinechart();
                    Get_BLCounts();
                    Counts_Blrelase();
                    Unclose_Count();
                    LinkButtonfbl.Visible = false;
                }

            }

        }

        public void salelinechart()
        {

            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            dt0 = objJobInfo.GetOPsDocHomeCount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Month');
            data.addColumn('number', 'Job');
             data.addColumn('number', 'BL');
            data.addColumn('number', 'INV');
             data.addColumn('number', 'CNOPS');
            data.addRows(" + dt0.Rows.Count + ");");

            for (int i = 0; i <= dt0.Rows.Count - 1; i++)
            {

                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt0.Rows[i]["Month"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt0.Rows[i]["Job"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt0.Rows[i]["BL"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 3 + "," + dt0.Rows[i]["INV"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 4 + "," + dt0.Rows[i]["CNOPS"].ToString() + ") ;");

            }

            str.Append("   var chart = new google.visualization.LineChart(document.getElementById('Liner_chart_div'));");
            str.Append(" chart.draw(data, {width: '100%', height: 320, title: '',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}},colors: ['#4ebcd5','#bce3c8','#408fdc','#5765b2'],");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().Replace('*', '"');

        }

        //public void Line_cahrt()
        //{
        //    DataTable dt0 = new DataTable();
        //    DataTable dt1 = new DataTable();
        //    DataTable dt2 = new DataTable();
        //    DataTable dt3 = new DataTable();
        //    DtSet = objJobInfo.GetOPsDocHomeCount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //    dt0 = DtSet.Tables[0];
        //    DataTable dt_new = new DataTable();
        //    //dt = (DataTable)Session["AgentWise"];
        //    DataView dv = dt0.DefaultView;
        //    dv.Sort = "retention desc";
        //    DataTable sortedDT = dv.ToTable();
        //    dt_new = SelectTopDataRow(sortedDT,5);
        //    div_op_char.Visible = true;
        //    chartoperProfit.Visible = true;
        //    int[] x = new int[dt_new.Rows.Count];
        //    string[] y = new string[dt_new.Rows.Count];
        //    for (int count = 0; count < dt_new.Rows.Count; count++)
        //    {
        //        x[count] = Convert.ToInt32( dt_new.Rows[count]["Agent"].ToString());
        //        y[count] = dt_new.Rows[count]["retention"].ToString();
        //    }
        //    chartoperProfit.ChartAreas[0].AxisX.Title = "Jobs";
        //    chartoperProfit.ChartAreas[0].AxisY.Title = "month";

        //    chartoperProfit.Series[0].Points.DataBindXY(x, y);
        //    chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        //    chartoperProfit.Series[0].LegendText = "Profit";
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
        //   // grd_Consignee.Visible = false;
        //    //piechart.Visible = false;
        //    return;

        //}

        private DataTable SelectTopDataRow(DataTable sortedDT, int p)
        {
            throw new NotImplementedException();
        }

        public void vis_div()
        {
            divexrate.Visible = false;
            penBlRelase.Visible = false;
            rightbookingno.Visible = false;
            div2_Bookchart.Visible = false;
            div_ComApproval.Visible = false;
            div6.Visible = false;
            div_line.Visible = false;
            div6.Visible = false;
            div_blrelase.Visible = false;
            div_floatleft.Visible = false;
            Div_Unclosed.Visible = false;
            div_iframe.Visible = true;
            Div1.Visible = false;
        }

        public void Unclose_Count()
        {
            dthbl = objClosedJob.GetJobDetailsOpenForNew(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            if (dthbl.Rows.Count > 0)
            {
                Unclose_Job.InnerText = dthbl.Rows[0][0].ToString();
            }
            else
            {
                Unclose_Job.InnerText = "0";
            }
        }

        public void Counts_Blrelase()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            //bl_Rel
            if (Strtrantype == "FE")
            {
                bl_Rel.InnerText = "BL Release";
            }
            else if (Strtrantype == "FI")
            {
                bl_Rel.InnerText = "DO Issue";
            }
            else if (Strtrantype == "AE")
            {
                bl_Rel.InnerText = "AWB";
            }
            else if (Strtrantype == "AI")
            {
                bl_Rel.InnerText = "AWB";
            }
            dthbl = leftObj.GetFEHBLDetailsForNew(Strtrantype, branchid);
            if (dthbl.Rows.Count > 0)
            {
                bl_relase.InnerText = dthbl.Rows[0][0].ToString();
            }
            else
            {
                bl_relase.InnerText = "0";
            }
        }

        public void Get_BLCounts()
        {
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            DtSet = objbu.selpendingBookcutomerwisecountForNew(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            dt0 = DtSet.Tables[0];
            dt1 = DtSet.Tables[1];
            if (dt0.Rows.Count > 0)
            {
                spn_jobs.InnerText = dt0.Rows[0][0].ToString();
            }
            else
            {
                spn_jobs.InnerText = "0";
            }
            if (dt1.Rows.Count > 0)
            {
                spn_bl.InnerText = dt1.Rows[0][0].ToString();
            }
            else
            {
                spn_bl.InnerText = "0";
            }
            //if (dt.Rows.Count > 0)
            //{

            //    if (dt.Rows[0][0].ToString() != "0")
            //    {
            //        spn_jobs.InnerText = dt.Rows[0][0].ToString();
            //    }
            //    else
            //    {
            //        spn_jobs.InnerText = "0";
            //    }

            //    if (dt.Rows[1][0].ToString() != "0")
            //    {
            //        spn_bl.InnerText = dt.Rows[1][0].ToString();
            //    }
            //    else
            //    {
            //        spn_bl.InnerText = "0";
            //    }

            //}
            //else
            //{
            //    spn_jobs.InnerText = "0";
            //    spn_bl.InnerText = "0";
            //}
        }

        public void LoadOceanEvent1()
        {
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending-OceanExp") });

            dt1.Rows.Add("Stuffing Confirm (" + leftObj.GetEventPendingOceanEXP("SC", branchid) + ")");
            dt1.Rows.Add("Loading Confirm (" + leftObj.GetEventPendingOceanEXP("LC", branchid) + ")");
            dt1.Rows.Add("Invoice/PL RecOn (" + leftObj.GetEventPendingOceanEXP("IR", branchid) + ")");
            dt1.Rows.Add("PreAlert SentOn (" + leftObj.GetEventPendingOceanEXP("PS", branchid) + ")");
            dt1.Rows.Add("Docs SentOn (" + leftObj.GetEventPendingOceanEXP("DO", branchid) + ")");
            dt1.Rows.Add("TranShipment (" + leftObj.GetEventPendingOceanEXP("TS", branchid) + ")");
            dt1.Rows.Add("Delivery Request (" + leftObj.GetEventPendingOceanEXP("DR", branchid) + ")");
            dt1.Rows.Add("Delivery Status (" + leftObj.GetEventPendingOceanEXP("DS", branchid) + ")");
            GrdOceanExp1.DataSource = dt1;
            GrdOceanExp1.DataBind();

        }
        public void LoadOceanEventIMP()
        {
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending-OceanImp") });

            dt1.Rows.Add("Covering Letter (" + leftObj.GetEventPendingOceanIMP("CS", branchid) + ")");
            dt1.Rows.Add("PreAlert SentOn (" + leftObj.GetEventPendingOceanIMP("PS", branchid) + ")");
            dt1.Rows.Add("Can/Inv SentOn (" + leftObj.GetEventPendingOceanIMP("CI", branchid) + ")");
            dt1.Rows.Add("PA2Accs SentOn (" + leftObj.GetEventPendingOceanIMP("PA", branchid) + ")");
            dt1.Rows.Add("Cheque RecOn (" + leftObj.GetEventPendingOceanIMP("CH", branchid) + ")");
            dt1.Rows.Add("Line DO RecOn (" + leftObj.GetEventPendingOceanIMP("LD", branchid) + ")");
            dt1.Rows.Add("Destuffed On (" + leftObj.GetEventPendingOceanIMP("DS", branchid) + ")");
            dt1.Rows.Add("DeVanning RecOn (" + leftObj.GetEventPendingOceanIMP("DR", branchid) + ")");
            dt1.Rows.Add("Refund RecOn (" + leftObj.GetEventPendingOceanIMP("RR", branchid) + ")");
            GrdOceanExp1.DataSource = dt1;
            GrdOceanExp1.DataBind();
        }
        public void getdata()
        {
            dt = objbu.selpandbooking(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            if (dt.Rows.Count > 0)
            {
                //pent_view.DataSource = dt;
                // pent_view.DataBind();
                ViewState["data"] = dt;
            }
            else
            {
                //  pent_view.DataSource = Utility.Fn_GetEmptyDataTable();
                //  pent_view.DataBind();
            }

        }

        [WebMethod]
        public static List<countrydetails> GetChartData()
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Appobj.GetDataBase(Ccode);
            if (HttpContext.Current.Session["StrTranType"].ToString() != null)
            {
                dt = Appobj.FillDt4ProLV(HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), "Transfer To Commercial Invoice");
            }
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending Approval") });
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Counts") });
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Pending Approval"] = "Pro Invoices";
            dt1.Rows[dt1.Rows.Count - 1]["Counts"] = dt.Rows.Count;
            //dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            if (HttpContext.Current.Session["StrTranType"].ToString() != null)
            {
                dt = Appobj.FillDt4ProLV(HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), "Transfer To Commercial PA");
            }
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Pending Approval"] = "Pro CN Operations";
            dt1.Rows[dt1.Rows.Count - 1]["Counts"] = dt.Rows.Count;
            //dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            if (HttpContext.Current.Session["StrTranType"].ToString() != null)
            {
                dt = Appobj.FillDt4ProLV(HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), "ProOSDNApproval");
            }
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Pending Approval"] = "Pro O/S Debit Notes";
            dt1.Rows[dt1.Rows.Count - 1]["Counts"] = dt.Rows.Count;

            // dt1.Rows.Add("Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

            if (HttpContext.Current.Session["StrTranType"].ToString() != null)
            {
                dt = Appobj.FillDt4ProLV(HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), "ProOSCNApproval");
            }
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Pending Approval"] = "Pro O/S Credit Notes";
            dt1.Rows[dt1.Rows.Count - 1]["Counts"] = dt.Rows.Count;
            // dt1.Rows.Add("Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            List<countrydetails> dataList = new List<countrydetails>();
            foreach (DataRow dtrow in dt1.Rows)
            {
                countrydetails details = new countrydetails();
                details.Countryname = dtrow[0].ToString();
                details.Total = Convert.ToInt32(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }
        [WebMethod]
        public static List<taskdetails> GetEmpolyeeJson()
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);
            int Emp_id = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            DataTable dt = new DataTable();
            dt = objbu.GetEmpolyeeDetails4card(Emp_id, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
            List<taskdetails> dataList = new List<taskdetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                taskdetails details = new taskdetails();
                details.Taskid = Convert.ToInt32(dtrow[0]);
                details.Tasks = dtrow[1].ToString();
                details.counts = Convert.ToInt32(dtrow[2]);
                details.Icon = dtrow[3].ToString();
                details.TaskDetailId = Convert.ToInt32(dtrow[4]);
                dataList.Add(details);
            }
            return dataList;

        }

        public class taskdetails
        {
            public int Taskid { get; set; }
            public string Tasks { get; set; }
            public int counts { get; set; }

            public string Icon { get; set; }
            public int TaskDetailId { get; set; }
        }


        [WebMethod]
        public static List<countrydetails> GetChartDataBooking()
        {
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);
            DataTable dtemptyfree = new DataTable();
            if (HttpContext.Current.Session["StrTranType"].ToString() != null)
            {
                dtemptyfree = objbu.selpendingBookcutomerwisecount_Chartempwise(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()));
            }
            List<countrydetails> dataList = new List<countrydetails>();
            foreach (DataRow dtrow in dtemptyfree.Rows)
            {
                countrydetails details = new countrydetails();
                details.Countryname = dtrow[0].ToString();
                details.Total = Convert.ToInt32(dtrow[2]);
                dataList.Add(details);
            }
            return dataList;
            //dtemptyfree.Columns.Add("S#");
            //dtemptyfree.Columns.Add("Customer Name");
            //dtemptyfree.Columns.Add("Numbers");
            //dtemptyfree.Columns.Add("cusid");
            //DataRow dr = dtemptyfree.NewRow();
            //if (dt.Rows.Count > 0)
            //{
            //    for (int j = 0; j <= dt.Rows.Count - 1; j++)
            //    {

            //        dtemptyfree.Rows.Add();
            //        dr = dtemptyfree.NewRow();
            //        dtemptyfree.Rows[j]["S#"] = dt.Rows[j]["SI"].ToString();
            //        dtemptyfree.Rows[j]["Customer Name"] = dt.Rows[j]["customername"].ToString();
            //        dtemptyfree.Rows[j]["Numbers"] = dt.Rows[j]["Counts"].ToString();
        }

        public void PendingApprovalFE()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int intcount;
            vouyear = 2015;

            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending Approval") });
            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[1] { new DataColumn("Approved") });
            // Pop_GrdApproval.Show();
            //PanelApproval.Visible = true;
            //GrdPending.Visible = true;

            if (Strtrantype != "BT")
            {
                if (Strtrantype != "CH")
                {
                    lngPQuot = leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()));
                    hid_lngPQuot.Value = lngPQuot.ToString();
                    dt1.Rows.Add("Quotation" + "  (" + System.Convert.ToString(leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()))) + ")");
                    //GrdPending1.Rows[0].Cells[0].Text = "Quotation" + "  (" + System.Convert.ToString(leftObj.GetQuotPendingApproval(Strtrantype, int.Parse(Session["LoginBranchid"].ToString()))) + ")";
                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial Invoice");
                    lngInv = dt.Rows.Count;
                    ProforInv.InnerText = lngInv.ToString();
                    hid_Proinv.Text = lngInv.ToString();
                    //GrdPending1.Rows[1].Cells[0].Text = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    //intcount = Appobj.GetPenFATrans("InvoiceApproval", Strtrantype, branchid, vouyear);
                    //GrdApproved11.Rows[0].Cells[0].Text = "Invoices" + "(" + intcount + ")";
                    // dt2.Rows.Add("Invoices" + "(" + intcount + ")");
                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial PA");
                    lngPA = dt.Rows.Count;
                    ProCNOps.InnerText = lngPA.ToString();
                    hid_Cn.Text = lngPA.ToString();
                    //GrdPending1.Rows[2].Cells[0].Text = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    //intcount = Appobj.GetPenFATrans("PAApproval", Strtrantype, branchid, vouyear);
                    //GrdApproved11.Rows[1].Cells[0].Text = "CN Operations" + "(" + intcount + ")";
                    // dt2.Rows.Add("CN Operations" + "(" + intcount + ")");
                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "ProOSDNApproval");
                    lngDN = dt.Rows.Count;
                    ProfOsDN.InnerText = lngDN.ToString();
                    hid_OsdN.Text = lngDN.ToString();
                    //GrdPending1.Rows[3].Cells[0].Text = "Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    //intcount = Appobj.GetPenFATrans("OSDNApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved11.Rows[2].Cells[0].Text = "O/S Debit Notes" + "(" + intcount + ")";
                    // dt2.Rows.Add("O/S Debit Notes" + "(" + intcount + ")");
                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "ProOSCNApproval");
                    lngCN = dt.Rows.Count;
                    ProfOscn.InnerText = lngCN.ToString();
                    hid_oscn.Text = lngCN.ToString();
                    //GrdPending1.Rows[4].Cells[0].Text = "Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    // dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial DN");
                    //lngCN = dt.Rows.Count;

                   

                   dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial Invoice FC");
                    lngInvFC = dt.Rows.Count;
                   ProforInvfc.InnerText = lngInvFC.ToString();
                    hid_ProinvFC.Text = lngInvFC.ToString();
                    hid_invfc.Value = "Transfer To Commercial Invoice FC";
                    //GrdPending1.Rows[1].Cells[0].Text = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Invoices FC" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial PA FC");
                    lngPAFC = dt.Rows.Count;
                   ProCNOpsfc.InnerText = lngPAFC.ToString();
                    hid_CnFC.Text = lngPAFC.ToString();
                    hid_paFC.Value = "Transfer To Commercial PA FC";
                    //GrdPending1.Rows[2].Cells[0].Text = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro CN Operations FC" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");


                }
                else
                {
                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial Invoice");
                    lngInv = dt.Rows.Count;
                    //GrdPending1.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial PA");
                    lngPA = dt.Rows.Count;
                    //GrdPending1.Rows(1).Cells(0).Value = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial DN");
                    lngCN = dt.Rows.Count;
                    //GrdPending1.Rows(2).Cells(0).Value = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt("Transfer To Commercial CN", Strtrantype, branchid);
                    lngCN = dt.Rows.Count;
                    //GrdPending1.Rows(3).Cells(0).Value = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial Invoice FC");
                    lngInvFC = dt.Rows.Count;
                    //GrdPending1.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")";
                    dt1.Rows.Add("Pro Invoices FC" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    //  GrdPending.DataSource = dt1;
                    //GrdPending.DataBind();

                      dt = Appobj.FillDt4ProLV(Strtrantype, branchid, "Transfer To Commercial PA FC");
                    lngPAFC = dt.Rows.Count;
                    //GrdPending1.Rows(1).Cells(0).Value = "Pro CN Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro CN Operations FC" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    //
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

                // GrdPending.DataSource = dt1;
                // GrdPending.DataBind();
            }
            ViewState["approval"] = dt1;
        }

        protected void GrdOceanExp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string name;
            string Strtrantype = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (GrdOceanExp1.Rows.Count > 0)
            {
                index = GrdOceanExp1.SelectedRow.RowIndex;
                name = GrdOceanExp1.Rows[index].Cells[0].Text;
                name = name.Substring(0, name.IndexOf(" ("));

                if (Strtrantype == "FI")
                {
                    str_RptName = "FIEvents.rpt";
                    if (name == "Covering Letter")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.coveringsenton}) and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.coveringsenton}) and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=Covering Letter";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "PreAlert SentOn")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.prealertsenton})and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.prealertsenton})and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=PreAlert SentOn";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Can/Inv SentOn")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.caninvsenton})and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.caninvsenton})and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=CAN/Invoice SentOn";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }

                    else if (name == "Destuffed On")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.pa2accsenton})and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.pa2accsenton})and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=Destuffed On";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "PA2Accs SentOn")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.chqrecon})and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.chqrecon})and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=PA2Accounts SentOn";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Cheque RecOn")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.linedorecon})and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.linedorecon})and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=Cheque ReceivedOn";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Line DO RecOn")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.destuffedon})and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.destuffedon})and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=Line DO ReceivedOn";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "DeVanning RecOn")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.devanningrecon})and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.devanningrecon})and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=DeVanning ReceivedOn";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Refund RecOn")
                    {
                        Session["str_sfs"] = "isnull({FIEvent.refundrecon})and {FIEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FIEvent.refundrecon})and {FIEvent.bid}=" + branchid + "";
                        str_sp = "title=Refund ReceivedOn";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                }

                else if (Strtrantype == "FE")
                {
                    str_RptName = "FEEvents.rpt";

                    if (name == "Stuffing Confirm")
                    {
                        Session["str_sfs"] = "isnull({FEEvent.stuffsenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FEEvent.stuffsenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sp = "";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Loading Confirm")
                    {
                        Session["str_sfs"] = "isnull({FEEvent.lcsenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FEEvent.lcsenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sp = "";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Invoice/PL RecOn")
                    {
                        Session["str_sfs"] = "isnull({FEEvent.invplrecon}) and {FEEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FEEvent.invplrecon}) and {FEEvent.bid}=" + branchid + "";
                        str_sp = "";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "PreAlert SentOn")
                    {
                        Session["str_sfs"] = "isnull({FEEvent.prealertsenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FEEvent.prealertsenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sp = "";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Docs SentOn")
                    {
                        Session["str_sfs"] = "isnull({FEEvent.docssenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FEEvent.docssenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sp = "";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "TranShipment")
                    {
                        Session["str_sfs"] = "isnull({FEEvent.tssenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FEEvent.tssenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sp = "";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Delivery Request")
                    {
                        Session["str_sfs"] = "isnull({FEEvent.drsenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FEEvent.drsenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sp = "";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                    else if (name == "Delivery Status")
                    {
                        Session["str_sfs"] = "isnull({FEEvent.dssenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sf = "isnull({FEEvent.dssenton}) and {FEEvent.bid}=" + branchid + "";
                        str_sp = "";
                        Session["str_sp"] = str_sp;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                        ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                    }
                }
            }
        }

        //protected void GrdPending_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int index;
        //    string vouname, vouname1;
        //    string trantype_process = Session["StrTranType"].ToString();
        //    string str_sp = "";
        //    string str_sf = "";
        //    string str_RptName = "";
        //    string str_Script = "";
        //    Session["str_sfs"] = "";
        //    Session["str_sp"] = "";
        //    branchid = int.Parse(Session["LoginBranchid"].ToString());
        //    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        //    if (GrdPending.Rows.Count > 0)
        //    {

        //        DataTable dtuser = new DataTable();
        //        index = GrdPending.SelectedRow.RowIndex;
        //        vouname = GrdPending.Rows[index].Cells[0].Text;
        //        if (vouname != "")
        //        {
        //            if (trantype_process != "FA" && trantype_process != "CRM")
        //            {
        //                if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Quotation")
        //                {
        //                    //str_RptName = "PendingQuotation.rpt";
        //                    //Session["str_sfs"] = "{QuotationHead.trantype}='" + Strtrantype + "' and {QuotationHead.validtill}>=CurrentDateTime and {QuotationHead.approvedby}=0 and {QuotationHead.bid}=" + branchid;
        //                    //str_sf = "{QuotationHead.trantype}=" + Strtrantype + " and {QuotationHead.validtill}>=CurrentDateTime and {QuotationHead.approvedby}=0 and {QuotationHead.bid}=" + branchid;
        //                    //str_sp = "";//"Head=Invoice Pending Approval";
        //                    //Session["str_sp"] = str_sp;
        //                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                    //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Invoice", str_Script, true);
        //                    if (trantype_process == "FE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {
        //                          //  vouname1 = vouname.Substring(11,13);
        //                            if (hid_lngPQuot.Value != "0")
        //                            {
        //                                dtuser = obj_UP.GetFormwiseuserRights(181, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                                if (dtuser.Rows.Count > 0)
        //                                {

        //                                    //string Quotapp = "Quotapp";
        //                                    //Response.Redirect("../Sales/Quatapp.aspx?Quotapp=" + Quotapp);
        //                                    string type = "Quotation Approval";
        //                                    string uiid = "181";
        //                                    Response.Redirect("../Sales/Quotation.aspx?type=" + type + "&uiid=" + uiid);

        //                                    // Response.Redirect("../Sales/Quatapp.aspx");
        //                                }
        //                                else
        //                                {
        //                                    string message = "No Rights";
        //                                    ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                string message = "Quotation Approval is empty";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }

        //                    if (trantype_process == "FI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {
        //                            if (hid_lngPQuot.Value != "0")
        //                            {
        //                                dtuser = obj_UP.GetFormwiseuserRights(180, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                                if (dtuser.Rows.Count > 0)
        //                                {

        //                                    //    string Quotapp = "Quotapp";
        //                                    // Response.Redirect("../Sales/Quatapp.aspx?Quotapp=" + Quotapp);

        //                                    string type = "Quotation Approval";
        //                                    string uiid = "180";
        //                                    Response.Redirect("../Sales/Quotation.aspx?type=" + type + "&uiid=" + uiid);

        //                                }
        //                                else
        //                                {
        //                                    string message = "No Rights";
        //                                    ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                string message = "Quotation Approval is empty";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }

        //                    if (trantype_process == "AE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {
        //                            if (hid_lngPQuot.Value != "0")
        //                            {
        //                                dtuser = obj_UP.GetFormwiseuserRights(217, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                                if (dtuser.Rows.Count > 0)
        //                                {

        //                                    // string Quotapp = "Quotapp";
        //                                    // Response.Redirect("../Sales/Quatapp.aspx?Quotapp=" + Quotapp);

        //                                    string type = "Quotation Approval";
        //                                    string uiid = "217";
        //                                    Response.Redirect("../Sales/Quotation.aspx?type=" + type + "&uiid=" + uiid);
        //                                }
        //                                else
        //                                {
        //                                    string message = "No Rights";
        //                                    ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                string message = "Quotation Approval is empty";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }
        //                        }

        //                    }

        //                    if (trantype_process == "AI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {
        //                            if (hid_lngPQuot.Value != "0")
        //                            {
        //                                dtuser = obj_UP.GetFormwiseuserRights(215, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                                if (dtuser.Rows.Count > 0)
        //                                {

        //                                    //  string Quotapp = "Quotapp";
        //                                    // Response.Redirect("../Sales/Quatapp.aspx?Quotapp=" + Quotapp);
        //                                    string type = "Quotation Approval";
        //                                    string uiid = "215";
        //                                    Response.Redirect("../Sales/Quotation.aspx?type=" + type + "&uiid=" + uiid);
        //                                }
        //                                else
        //                                {
        //                                    string message = "No Rights";
        //                                    ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                string message = "Quotation Approval is empty";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }

        //                }
        //                else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Invoices")
        //                {
        //                    //str_RptName = "ProInvPendRegister.rpt";
        //                    //Session["str_sfs"] = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and {ACProInvoiceHead.trantype}='" + Strtrantype + "' and {ACProInvoiceHead.deleted}='N'";
        //                    //str_sf = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and {ACProInvoiceHead.trantype}=" + Strtrantype + " and {ACProInvoiceHead.deleted}=N";
        //                    //str_sp = "Title=Profoma Invoice Pending Approval";
        //                    //Session["str_sp"] = str_sp;
        //                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                    //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Invoice", str_Script, true);
        //                    if (trantype_process == "FE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1016, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "Invoice Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }

        //                    if (trantype_process == "FI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1023, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "Invoice Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }

        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }
        //                        }

        //                    }

        //                    if (trantype_process == "AE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1030, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "Invoice Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }

        //                    if (trantype_process == "AI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1037, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "Invoice Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }
        //                        }

        //                    }

        //                }
        //                else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro CN Operations")
        //                {
        //                    //str_RptName = "Pro PA PendRegister.rpt";
        //                    //Session["str_sfs"] = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and {ACProPAHead.trantype}='" + Strtrantype + "' and {ACProPAHead.deleted}='N'";
        //                    //str_sf = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and {ACProPAHead.trantype}=" + Strtrantype + " and {ACProPAHead.deleted}=N";
        //                    //str_sp = "Title=Profoma Credit Note - Operations Pending Approval";
        //                    //Session["str_sp"] = str_sp;
        //                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                    //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Payment Advise", str_Script, true);
        //                    if (trantype_process == "FE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1017, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "CN-Ops Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }
        //                    if (trantype_process == "FI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1024, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "CN-Ops Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }
        //                    if (trantype_process == "AE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1031, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "CN-Ops Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }
        //                    if (trantype_process == "AI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1038, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "CN-Ops Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }

        //                }
        //                else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Debit Notes")
        //                {
        //                    //str_RptName = "Pro OSDN PendRegister.rpt";
        //                    //Session["str_sfs"] = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and {AcOSDNPro.trantype}='" + Strtrantype + "' and {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}='N'";
        //                    //str_sf = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and {AcOSDNPro.trantype}=" + Strtrantype + " and {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}=N";
        //                    //str_sp = "Title=Profoma OSDN Pending Approval";
        //                    //Session["str_sp"] = str_sp;
        //                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                    //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "OSSI", str_Script, true);
        //                    if (trantype_process == "FE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1018, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "OSDN Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }
        //                    if (trantype_process == "FI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1025, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "OSDN Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }
        //                    if (trantype_process == "AE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1032, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "OSDN Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }
        //                    if (trantype_process == "AI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1039, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "OSDN Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }

        //                }
        //                else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Credit Notes")
        //                {
        //                    //str_RptName = "Pro OSCN PendRegister.rpt";
        //                    //Session["str_sfs"] = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.trantype}='" + Strtrantype + "' and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}='N'";
        //                    //str_sf = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.trantype}=" + Strtrantype + " and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}=N";
        //                    //str_sp = "Title=Profoma OSCN Pending Approval";
        //                    //Session["str_sp"] = str_sp;
        //                    //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                    ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                    //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "OSPI", str_Script, true);
        //                    if (trantype_process == "FE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1019, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "OSCN Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }
        //                    if (trantype_process == "FI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1026, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "OSCN Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }
        //                    if (trantype_process == "AE")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1033, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "OSCN Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }

        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }
        //                        }

        //                    }
        //                    if (trantype_process == "AI")
        //                    {
        //                        if (GrdPending.Rows.Count > 0)
        //                        {

        //                            dtuser = obj_UP.GetFormwiseuserRights(1040, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                            if (dtuser.Rows.Count > 0)
        //                            {
        //                                string app1 = "OSCN Proforma to Commercial";
        //                                Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                            }
        //                            else
        //                            {
        //                                string message = "No Rights";
        //                                ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                            }

        //                        }

        //                    }

        //                }
        /*  else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other DN")
          {
              //str_RptName = "Pro OtherDN PendRegister.rpt";
              //Session["str_sfs"] = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0  and {ACProDNHead.trantype}='" + Strtrantype + "' and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}='N'";
              //str_sf = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0  and {ACProDNHead.trantype}=" + Strtrantype + " and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}=N";
              //str_sp = "Title=Profoma Debit Notes Pending Approval";
              //Session["str_sp"] = str_sp;
              //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
              ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
              //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Debit Notes", str_Script, true);
                           
              //Nambi inform to Operating Accounts form 
               if (trantype_process == "FE")
              {
                  if (GrdPending.Rows.Count > 0)
                  {

                      dtuser = obj_UP.GetFormwiseuserRights(523, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                      if (dtuser.Rows.Count > 0)
                      {
                          //string app1 = "OSDN Approval";
                          string app1 = "Transfer To Commercial DN";
                          Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                      }
                      else
                      {
                          string message = "No Rights";
                          ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                      }

                  }
                               
              }
              if (trantype_process == "FI")
              {
                  if (GrdPending.Rows.Count > 0)
                  {

                      dtuser = obj_UP.GetFormwiseuserRights(529, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                      if (dtuser.Rows.Count > 0)
                      {
                          //string app1 = "OSDN Approval";
                          string app1 = "Transfer To Commercial DN";
                          Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                      }
                      else
                      {
                          string message = "No Rights";
                          ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                      }

                  }
                               
              }
              if (trantype_process == "AE")
              {
                  if (GrdPending.Rows.Count > 0)
                  {

                      dtuser = obj_UP.GetFormwiseuserRights(525, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                      if (dtuser.Rows.Count > 0)
                      {
                          //string app1 = "OSDN Approval";
                          string app1 = "Transfer To Commercial DN";
                          Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                      }
                      else
                      {
                          string message = "No Rights";
                          ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                      }

                  }
                              
              }
              if (trantype_process == "AI")
              {
                  if (GrdPending.Rows.Count > 0)
                  {

                      dtuser = obj_UP.GetFormwiseuserRights(526, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                      if (dtuser.Rows.Count > 0)
                      {
                          //string app1 = "OSDN Approval";
                          string app1 = "Transfer To Commercial DN";
                          Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                      }
                      else
                      {
                          string message = "No Rights";
                          ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                      }

                  }
                               
              }

          }*/
        /*else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other CN")
        {
            //str_RptName = "Pro OtherCN PendRegister.rpt";
            //Session["str_sfs"] = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and {ACPRoCNHead.trantype}='" + Strtrantype + "' and {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}='N'";
            //str_sf = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and {ACPRoCNHead.trantype}=" + Strtrantype + " and {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}=N";
            //str_sp = "Title=Profoma Credit Notes Pending Approval";
            //Session["str_sp"] = str_sp;
            //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
            //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Credit Notes", str_Script, true);
                            
            //Nambi inform to Operating Accounts form 
                           
            if (trantype_process == "FE")
            {
                if (GrdPending.Rows.Count > 0)
                {

                    dtuser = obj_UP.GetFormwiseuserRights(528, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        //string app1 = "OSCNApproval";
                        //Response.Redirect("../ForwardExports/Approval.aspx?app1=" + app1);
                        string app1 = "Transfer To Commercial CN";
                        Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    }

                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                               
            }
            if (trantype_process == "FI")
            {
                if (GrdPending.Rows.Count > 0)
                {

                    dtuser = obj_UP.GetFormwiseuserRights(529, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        //string app1 = "OSCNApproval";
                        //Response.Redirect("../ForwardExports/Approval.aspx?app1=" + app1);
                        string app1 = "Transfer To Commercial CN";
                        Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }

                }
                                
            }
            if (trantype_process == "AE")
            {
                if (GrdPending.Rows.Count > 0)
                {

                    dtuser = obj_UP.GetFormwiseuserRights(530, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        //string app1 = "OSCNApproval";
                        //Response.Redirect("../ForwardExports/Approval.aspx?app1=" + app1);
                        string app1 = "Transfer To Commercial CN";
                        Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }

                }
                                
            }
            if (trantype_process == "AI")
            {
                if (GrdPending.Rows.Count > 0)
                {

                    dtuser = obj_UP.GetFormwiseuserRights(531, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        //string app1 = "OSCNApproval";
                        //Response.Redirect("../ForwardExports/Approval.aspx?app1=" + app1);
                        string app1 = "Transfer To Commercial CN";
                        Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }

                }
                                
            }
                          
        }*/
        //}
        // else
        //{
        //            if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Quotation")
        //            {
        //                //str_RptName = "PendingQuotation.rpt";
        //                //Session["str_sfs"] = "{QuotationHead.approvedby}=0 and {QuotationHead.validtill}>=date('" + logobj.GetDate() + "')";
        //                //str_sf = "{QuotationHead.approvedby}=0 and {QuotationHead.validtill}>=date(" + logobj.GetDate() + ")";
        //                //str_sp = "";//"Head^Invoice Pending Approval";
        //                //Session["str_sp"] = str_sp;
        //                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Invoice", str_Script, true);
        //                if (trantype_process == "FE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(181, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {

        //                            Response.Redirect("../Sales/Quatapp.aspx");
        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //                if (trantype_process == "FI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(180, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {

        //                            Response.Redirect("../Sales/Quatapp.aspx");
        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //                if (trantype_process == "AE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(217, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {

        //                            Response.Redirect("../Sales/Quatapp.aspx");
        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //                if (trantype_process == "AI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(215, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {

        //                            Response.Redirect("../Sales/Quatapp.aspx");
        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //            }
        //            else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Invoices")
        //            {
        //                //str_RptName = "ProInvPendRegister.rpt";
        //                //Session["str_sfs"] = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and  {ACProInvoiceHead.deleted}='N'";
        //                //str_sf = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and  {ACProInvoiceHead.deleted}=N";
        //                //str_sp = "Title=Profoma Invoice Pending Approval";
        //                //Session["str_sp"] = str_sp;
        //                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Invoice", str_Script, true);
        //                if (trantype_process == "FE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1016, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "Invoice Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //                if (trantype_process == "FI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1023, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "Invoice Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //                if (trantype_process == "AE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1030, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "Invoice Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //                if (trantype_process == "AI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1037, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "Invoice Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //            }
        //            else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro CN Operations")
        //            {
        //                //str_RptName = "Pro PA PendRegister.rpt";
        //                //Session["str_sfs"] = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and  {ACProPAHead.deleted}='N'";
        //                //str_sf = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and  {ACProPAHead.deleted}=N";
        //                //str_sp = "Title=Profoma Credit Note - Operations Pending Approval";
        //                //Session["str_sp"] = str_sp;
        //                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Payment Advise", str_Script, true);
        //                if (trantype_process == "FE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1017, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "CN-Ops Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "FI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1024, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "CN-Ops Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1031, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "CN-Ops Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1038, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "CN-Ops Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //            }
        //            else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Debit Notes")
        //            {
        //                //str_RptName = "Pro OSDN PendRegister.rpt";
        //                //Session["str_sfs"] = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and  {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}='N'";
        //                //str_sf = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and  {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}=N";
        //                //str_sp = "Title=Profoma OSDN Pending Approval";
        //                //Session["str_sp"] = str_sp;
        //                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "OSSI", str_Script, true);

        //                if (trantype_process == "FE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1018, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "OSDN Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "FI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1025, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "OSDN Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1032, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "OSDN Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1039, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "OSDN Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //            }
        //            else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Credit Notes")
        //            {
        //                //str_RptName = "Pro OSCN PendRegister.rpt";
        //                //Session["str_sfs"] = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}='N'";
        //                //str_sf = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}=N";
        //                //str_sp = "Title=Profoma OSCN Pending Approval";
        //                //Session["str_sp"] = str_sp;
        //                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "OSPI", str_Script, true);
        //                if (trantype_process == "FE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1019, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "OSCN Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "FI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1026, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "OSCN Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1033, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "OSCN Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(1040, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            string app1 = "OSCN Proforma to Commercial";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //            }
        //           /* else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other DN")
        //            {
        //                //str_RptName = "Pro OtherDN PendRegister.rpt";
        //                //Session["str_sfs"] = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0   and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}='N'";
        //                //str_sf = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0   and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}=N";
        //                //str_sp = "Title=Profoma Debit Notes Pending Approval";
        //                //Session["str_sp"] = str_sp;
        //                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Debit Notes", str_Script, true);
        //                if (trantype_process == "FE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(58, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            //string app1 = "OSDN Approval";
        //                            string app1 = "Transfer To Commercial DN";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "FI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(59, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {

        //                            //string app1 = "OSDN Approval";
        //                            string app1 = "Transfer To Commercial DN";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(60, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {

        //                            //string app1 = "OSDN Approval";
        //                            string app1 = "Transfer To Commercial DN";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(61, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {

        //                            //string app1 = "OSDN Approval";
        //                            string app1 = "Transfer To Commercial DN";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //            }*/
        //          /* else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other CN")
        //            {
        //                //str_RptName = "Pro OtherCN PendRegister.rpt";
        //                //Session["str_sfs"] = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and  {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}='N'";
        //                //str_sf = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and  {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}=N";
        //                //str_sp = "Title=Profoma Credit Notes Pending Approval";
        //                //Session["str_sp"] = str_sp;
        //                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //                ////obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //                //ScriptManager.RegisterStartupScript(GrdPending, typeof(Button), "Credit Notes", str_Script, true);
        //                if (trantype_process == "FE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(62, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            //string app1 = "OSCNApproval";
        //                            //Response.Redirect("../ForwardExports/Approval.aspx?app1=" + app1);
        //                            string app1 = "Transfer To Commercial CN";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
        //                        }

        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }
        //                    }

        //                }
        //                if (trantype_process == "FI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(63, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            //string app1 = "OSCNApproval";
        //                            //Response.Redirect("../ForwardExports/Approval.aspx?app1=" + app1);
        //                            string app1 = "Transfer To Commercial CN";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AE")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(64, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            //string app1 = "OSCNApproval";
        //                            //Response.Redirect("../ForwardExports/Approval.aspx?app1=" + app1);
        //                            string app1 = "Transfer To Commercial CN";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }
        //                if (trantype_process == "AI")
        //                {
        //                    if (GrdPending.Rows.Count > 0)
        //                    {

        //                        dtuser = obj_UP.GetFormwiseuserRights(65, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        //                        if (dtuser.Rows.Count > 0)
        //                        {
        //                            //string app1 = "OSCNApproval";
        //                            //Response.Redirect("../ForwardExports/Approval.aspx?app1=" + app1);
        //                            string app1 = "Transfer To Commercial CN";
        //                            Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
        //                        }
        //                        else
        //                        {
        //                            string message = "No Rights";
        //                            ScriptManager.RegisterStartupScript(GrdPending, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
        //                        }

        //                    }

        //                }

        //            }*/
        //        }
        //    }
        //}
        //}

        public void pendingHBLFE()
        {
            if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
            {
                lbl_blPen.InnerText = "Pending BLs";
            }
            else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
            {
                lbl_blPen.InnerText = "Pending AWB";
            }
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            dthbl = leftObj.GetFEHBLDetailsForNewOpsDocTask(Strtrantype, branchid,empid);
            // hidhbl.Text = Convert.ToInt32(dthbl.Rows.Count).ToString();
            DataTable dtTemp = new DataTable();
            DataRow dr = dtTemp.NewRow();
            dtTemp.Columns.Add("SI");
            //dtTemp.Columns.Add("blno");
            dtTemp.Columns.Add("shipper");
            dtTemp.Columns.Add("counts");
            dtTemp.Columns.Add("shipperid");
            if (dthbl.Rows.Count > 0)
            {

                for (int i = 0; i <= dthbl.Rows.Count - 1; i++)
                {
                    dtTemp.Rows.Add();
                    dtTemp.Rows[i]["SI"] = dthbl.Rows[i]["SI"].ToString();
                    // dtTemp.Rows[i]["blno"] = dthbl.Rows[i]["blno"].ToString();
                    dtTemp.Rows[i]["shipper"] = dthbl.Rows[i]["shipper"].ToString();
                    dtTemp.Rows[i]["counts"] = dthbl.Rows[i]["counts"].ToString();
                    dtTemp.Rows[i]["shipperid"] = dthbl.Rows[i]["shipperid"].ToString();
                }
                dtTemp.Rows.Add(dr);
                var sum_Income = dthbl.Compute("sum(counts)", "");
                dtTemp.Rows[dthbl.Rows.Count]["shipper"] = "Total";
                dtTemp.Rows[dthbl.Rows.Count]["counts"] = sum_Income.ToString();

                // popup_Grd.Hide();
                //Panelhbl.Visible = true;
                GrdPort1.Visible = true;
                GrdPort1.DataSource = dtTemp;
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                {
                    GrdPort1.Columns[2].HeaderText = "BLs";
                }
                else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                {
                    GrdPort1.Columns[2].HeaderText = "AWB";
                }

                GrdPort1.DataBind();
                ViewState["GrdPort1"] = dtTemp;
                //  pop_hblgrd.Show();
                ViewState["hbl"] = dthbl;
            }
            else
            {
                GrdPort1.Visible = true;
                DataTable DtTemp = new DataTable();
                //DtTemp.Columns.Add("Bl #");
                GrdPort1.DataSource = DtTemp;
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                {
                    GrdCuswise.Columns[2].HeaderText = "BLs";
                }
                else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                {
                    GrdCuswise.Columns[2].HeaderText = "AWB";
                }
                GrdPort1.DataBind();
                //  pop_hblgrd.Hide();
            }
        }

        protected void pent_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // pent_view.PageIndex = e.NewPageIndex;
            //pent_view.DataSource = (DataTable)ViewState["data"];
            // pent_view.DataBind();

        }

        protected void pent_view_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }
        public void loadgrd()
        {
            //DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            string dtexdate = obj_da_Logobj.GetDate().ToString();
            //dt = exrobj.GetExRateDetails(dtexdate);
            //dt = exrobj.GetExRateDetails(Convert.ToDateTime(dtexdate));
            dt = exrateshow.ShowExRate_LocalOS(DateTime.Parse(Utility.fn_ConvertDate(DateTime.Now.ToString("dd/MM/yyyy")).ToString()), Convert.ToInt32(Session["LoginDivisionId"]));
            if (dt.Rows.Count > 0)
            {
                GridExrate.DataSource = dt;
                GridExrate.DataBind();
            }
            else
            {
                GridExrate.DataSource = dt;
                GridExrate.DataBind();
            }
        }

        //protected void GrdPending_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        for (int i = 0; i < e.Row.Cells.Count; i++)
        //        {
        //            if (e.Row.Cells[i].Text == "&nbsp;")
        //            {
        //                e.Row.Cells[i].Text = "";
        //            }
        //            e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
        //        }
        //        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
        //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPending, "Select$" + e.Row.RowIndex);
        //        e.Row.Attributes["style"] = "cursor:pointer";
        //    }
        //}

        protected void GrdOceanExp1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdOceanExp1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdPort1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    Label lbltxt = (Label)e.Row.Cells[i].FindControl("shipperName");
                    if (lbltxt.Text != "Total")
                    {
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPort1, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }
                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //if (Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "AE")
                //{
                //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPort1, "Select$" + e.Row.RowIndex);
                //    e.Row.Attributes["style"] = "cursor:pointer";
                //}

            }
        }

        protected void GrdPort1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int shipper = 0;
            penBlRelase.Visible = true;
            int index = GrdPort1.SelectedRow.RowIndex;
            Label lal = (Label)GrdPort1.Rows[index].FindControl("shipperName");
            lbl_Bl.Text = lal.Text;
            //lbl_Bl.Text = GrdPort1.Rows[index].Cells[1].Text.ToString();
            shipper = Convert.ToInt32(GrdPort1.Rows[index].Cells[3].Text.ToString());
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginBranchid"].ToString());
            dthbl = leftObj.GetFEHBLDetailsForNewOpsDocNew(Strtrantype, branchid, shipper);
            if (dthbl.Rows.Count > 0)
            {
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                {
                    Panel3.Visible = true;
                    Panel7.Visible = false;
                    GridView2.DataSource = dthbl;
                    GridView2.DataBind();
                    ViewState["GridView2"] = dthbl;
                    link_pending.Visible = true;
                }
                else
                {
                    Panel3.Visible = false;
                    Panel7.Visible = true;
                    GridView5.DataSource = dthbl;
                    GridView5.DataBind();
                    ViewState["GridView2"] = dthbl;
                    link_pending.Visible = true;
                }

            }
            else
            {
                if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                {
                    Panel3.Visible = true;
                    Panel7.Visible = false;
                    GridView2.DataSource = new DataTable();
                    GridView2.DataBind();
                }
                else
                {
                    Panel3.Visible = false;
                    Panel7.Visible = true;
                    GridView5.DataSource = new DataTable();
                    GridView5.DataBind();
                }
            }

        }

        public void loadcustwise()
        {
            pnlGrdCuswise.Visible = true;
            penBlRelase.Visible = false;
            GrdCuswise.Visible = true;
            if (Hdn_taskid.Value == "Job Updation")
            {
                dt = objbu.selpendingBookcutomerwisecountforjob(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"]));
            }
            else
            {
                dt = objbu.selpendingBookcutomerwisecount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"]));
            }
            DataTable dtemptyfree = new DataTable();
            dtemptyfree.Columns.Add("S#");

            dtemptyfree.Columns.Add("Customer");
            dtemptyfree.Columns.Add("Numbers");
            dtemptyfree.Columns.Add("cusid");
            DataRow dr = dtemptyfree.NewRow();
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j <= dt.Rows.Count - 1; j++)
                {

                    dtemptyfree.Rows.Add();
                    dr = dtemptyfree.NewRow();
                    dtemptyfree.Rows[j]["S#"] = dt.Rows[j]["SI"].ToString();
                    dtemptyfree.Rows[j]["Customer"] = dt.Rows[j]["customername"].ToString();
                    dtemptyfree.Rows[j]["Numbers"] = dt.Rows[j]["Counts"].ToString();
                    dtemptyfree.Rows[j]["cusid"] = dt.Rows[j]["cusid"].ToString();
                }
                dtemptyfree.Rows.Add(dr);
                var sum_Income = dt.Compute("sum(counts)", "");
                dtemptyfree.Rows[dt.Rows.Count]["Customer"] = "Total";
                dtemptyfree.Rows[dt.Rows.Count]["Numbers"] = sum_Income.ToString();

                //string[] x = new string[dtemptyfree.Rows.Count];
                //decimal[] y = new decimal[dtemptyfree.Rows.Count];
                //for (int count = 0; count < dtemptyfree.Rows.Count; count++)
                //{
                //    x[count] = dtemptyfree.Rows[count]["Customer Name"].ToString();
                //    y[count] = Convert.ToDecimal(dtemptyfree.Rows[count]["Numbers"].ToString());
                //}

                /*  piechart.Legends.Clear();
                  piechart.Visible = true;
                  piechart.Series[0].Points.DataBindXY(x, y);
                  piechart.Series[0].ChartType = SeriesChartType.Pie;
                  piechart.Series[0].Label = "#VALX (#PERCENT)";
                  //piechart.Titles.Clear();
                  //piechart.Titles.Add("M+R CHENNAI");
                  piechart.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                  piechart.Series[0]["PieLabelStyle"] = "Disabled";
                  */

                GrdCuswise.DataSource = dtemptyfree;

                if (Session["StrTranType"] == "FE" || Session["StrTranType"] == "AE")
                {
                    GrdCuswise.Columns[1].HeaderText = "Customer";
                }
                else if (Session["StrTranType"] == "FI" || Session["StrTranType"] == "AI")
                {
                    GrdCuswise.Columns[1].HeaderText = "Consignee";
                }
                GrdCuswise.DataBind();
                ViewState["GrdCuswise"] = dtemptyfree;
                dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                //foreach (DataRow row in dtemptyfree.Rows)
                //{
                //    PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                //    {
                //        Category = row["Customer Name"].ToString(),
                //        Data = Convert.ToDecimal(row["Numbers"])
                //    });
                //}
            }
            else
            {
                GrdCuswise.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdCuswise.DataBind();
            }
        }
        public void loadcosigneewise()
        {
            pnlGrdCuswise.Visible = true;
            GrdCuswise.Visible = true;

            dt = objbu.selpendingBookcosigneecountfibl(Convert.ToInt32(Session["LoginBranchid"]));
            DataTable dtemptyfree = new DataTable();

            dtemptyfree.Columns.Add("Consignee Name");
            dtemptyfree.Columns.Add("Numbers");
            dtemptyfree.Columns.Add("cusid");
            DataRow dr = dtemptyfree.NewRow();

            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j <= dt.Rows.Count - 1; j++)
                {

                    dtemptyfree.Rows.Add();
                    dr = dtemptyfree.NewRow();
                    dtemptyfree.Rows[j]["Consignee Name"] = dt.Rows[j]["consignee"].ToString();
                    dtemptyfree.Rows[j]["Numbers"] = dt.Rows[j]["Counts"].ToString();
                    dtemptyfree.Rows[j]["cusid"] = dt.Rows[j]["cusid"].ToString();
                }
                dtemptyfree.Rows.Add(dr);
                var sum_Income = dt.Compute("sum(counts)", "");
                dtemptyfree.Rows[dt.Rows.Count]["Consignee Name"] = "Total";
                dtemptyfree.Rows[dt.Rows.Count]["Numbers"] = sum_Income.ToString();

                //string[] x = new string[dtemptyfree.Rows.Count];
                //decimal[] y = new decimal[dtemptyfree.Rows.Count];
                //for (int count = 0; count < dtemptyfree.Rows.Count; count++)
                //{
                //    x[count] = dtemptyfree.Rows[count]["Consignee Name"].ToString();
                //    y[count] = Convert.ToDecimal(dtemptyfree.Rows[count]["Counts"].ToString());
                //}

                /* piechart.Legends.Clear();
                 piechart.Visible = true;
                 piechart.Series[0].Points.DataBindXY(x, y);
                 piechart.Series[0].ChartType = SeriesChartType.Pie;
                 piechart.Series[0].Label = "#VALX (#PERCENT)";
                 //piechart.Titles.Clear();
                 //piechart.Titles.Add("M+R CHENNAI");
                 piechart.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                 piechart.Series[0]["PieLabelStyle"] = "Disabled";

                 */
                GrdCuswise.DataSource = dtemptyfree;
                GrdCuswise.DataBind();

                dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                //foreach (DataRow row in dtemptyfree.Rows)
                //{
                //    PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                //    {
                //        Category = row["Consignee Name"].ToString(),
                //        Data = Convert.ToDecimal(row["Numbers"])
                //    });
                //}

            }
            else
            {
                GrdCuswise.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdCuswise.DataBind();
            }
        }
        protected void GrdCuswise_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    Label lbl = (Label)e.Row.Cells[i].FindControl("CustomerName1");
                    if (lbl.Text != "Total")
                    {
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdCuswise, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }
                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

            }
        }

        protected void GrdCuswise_SelectedIndexChanged(object sender, EventArgs e)
        {
            div2_Bookchart.Visible = false;
            Panel2.Visible = true;
            GridView1.Visible = true;
            rightbookingno.Visible = true;

            if (Session["StrTranType"] != null)
            {
                int index = GrdCuswise.SelectedRow.RowIndex;
                Label lbl = (Label)GrdCuswise.Rows[index].FindControl("CustomerName1");
                //lbl_cut.Text = GrdCuswise.SelectedRow.Cells[1].Text;
                lbl_cut.Text = lbl.Text;
                int custid = Convert.ToInt32(GrdCuswise.SelectedRow.Cells[3].Text);
                hid_custid.Value = custid.ToString();
                if (Hdn_taskid.Value == "Job Updation")
                {
                    dt = objbu.selpendingBookcustomeridwise(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), custid);
                }
                else
                {
                    dt = objbu.selpendingBookcustomeridwiseForJob(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), custid);
                }
                DataTable dtemptyfree = new DataTable();

                dtemptyfree.Columns.Add("S#");
                dtemptyfree.Columns.Add("Booking#");

                dtemptyfree.Columns.Add("Booking Date");
                dtemptyfree.Columns.Add("PoR");
                dtemptyfree.Columns.Add("PoL");
                dtemptyfree.Columns.Add("PoD");
                dtemptyfree.Columns.Add("PlD");
                dtemptyfree.Columns.Add("Job#");

                DataRow dr = dtemptyfree.NewRow();
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {

                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["S#"] = dt.Rows[j]["SI"].ToString();
                        dtemptyfree.Rows[j]["Booking#"] = dt.Rows[j]["shiprefno"].ToString();
                        dtemptyfree.Rows[j]["Booking Date"] = dt.Rows[j]["bookingdate"].ToString();
                        dtemptyfree.Rows[j]["PoR"] = dt.Rows[j]["por"].ToString();
                        dtemptyfree.Rows[j]["PoL"] = dt.Rows[j]["pol"].ToString();
                        dtemptyfree.Rows[j]["PoD"] = dt.Rows[j]["pod"].ToString();
                        dtemptyfree.Rows[j]["PlD"] = dt.Rows[j]["fd"].ToString();
                        dtemptyfree.Rows[j]["Job#"] = dt.Rows[j]["job"].ToString();

                    }

                    GridView1.DataSource = dtemptyfree;
                    GridView1.DataBind();
                    ViewState["GridView1"] = dtemptyfree;
                    lnk_cut1.Visible = true;

                }
                else
                {
                    GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
                    GridView1.DataBind();
                }
            }
            //else if (Session["StrTranType"] == "FI")
            //{
            //    int custid = Convert.ToInt32(GrdCuswise.SelectedRow.Cells[3].Text);
            //    dt = objbu.selpendingBookcustomeridwisebl(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), custid);
            //    DataTable dtemptyfree = new DataTable();
            //    dtemptyfree.Columns.Add("S#");
            //    dtemptyfree.Columns.Add("Booking#");
            //    dtemptyfree.Columns.Add("Booking Date");
            //    dtemptyfree.Columns.Add("PoR");
            //    dtemptyfree.Columns.Add("PoL");
            //    dtemptyfree.Columns.Add("PoD");
            //    dtemptyfree.Columns.Add("FD");
            //    dtemptyfree.Columns.Add("Job#");

            //    DataRow dr = dtemptyfree.NewRow();
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int j = 0; j <= dt.Rows.Count - 1; j++)
            //        {

            //            dtemptyfree.Rows.Add();
            //            dr = dtemptyfree.NewRow();
            //            dtemptyfree.Rows[j]["BL#"] = dt.Rows[j]["blno"].ToString();

            //        }

            //        GridView1.DataSource = dtemptyfree;
            //        GridView1.DataBind();

            //    }
            //    else
            //    {
            //        GridView1.DataSource = Utility.Fn_GetEmptyDataTable();
            //        GridView1.DataBind();
            //    }
            //}
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
                    //if (Session["StrTranType"].ToString() == "FE")
                    //{
                    //    e.Row.Cells[1].Attributes.CssStyle["text-align"] = "right";
                    //}

                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //if (Session["StrTranType"].ToString() == "FE")
                //{
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                //}

            }
        }

        [WebMethod]
        public static List<countrydetails> GetChartData1()
        {
            DataTable dtab = new DataTable();
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
             string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);
            List<countrydetails> dataList = new List<countrydetails>();
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                if (HttpContext.Current.Session["StrTranType"].ToString() == "FE")
                {
                    dtab = objbu.selpendingBookcutomerwisecount(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString(), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]));

                    DataTable dtemptyfree = new DataTable();

                    dtemptyfree.Columns.Add("Customer Name");
                    dtemptyfree.Columns.Add("Numbers");
                    dtemptyfree.Columns.Add("cusid");
                    DataRow dr = dtemptyfree.NewRow();
                    if (dtab.Rows.Count > 0)
                    {
                        for (int j = 0; j <= dtab.Rows.Count - 1; j++)
                        {
                            dtemptyfree.Rows.Add();
                            dr = dtemptyfree.NewRow();
                            dtemptyfree.Rows[j]["Customer Name"] = dtab.Rows[j]["customername"].ToString();
                            dtemptyfree.Rows[j]["Numbers"] = dtab.Rows[j]["Counts"].ToString();
                            dtemptyfree.Rows[j]["cusid"] = dtab.Rows[j]["cusid"].ToString();
                        }
                        dtemptyfree.Rows.Add(dr);
                        var sum_Income = dtab.Compute("sum(counts)", "");
                        dtemptyfree.Rows[dtab.Rows.Count]["Customer Name"] = "Total";
                        dtemptyfree.Rows[dtab.Rows.Count]["Numbers"] = sum_Income.ToString();

                        dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                        foreach (DataRow dtrow in dtemptyfree.Rows)
                        {
                            countrydetails details = new countrydetails();
                            details.Countryname = dtrow["Customer Name"].ToString();
                            details.Total = Convert.ToInt32(dtrow["Numbers"]);
                            dataList.Add(details);
                        }
                    }
                }
                else
                {
                    dtab = objbu.selpendingBookcosigneecountfibl(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]));

                    DataTable dtemptyfree = new DataTable();

                    dtemptyfree.Columns.Add("Consignee Name");
                    dtemptyfree.Columns.Add("Numbers");
                    dtemptyfree.Columns.Add("cusid");
                    DataRow dr = dtemptyfree.NewRow();

                    if (dtab.Rows.Count > 0)
                    {
                        for (int j = 0; j <= dtab.Rows.Count - 1; j++)
                        {

                            dtemptyfree.Rows.Add();
                            dr = dtemptyfree.NewRow();
                            dtemptyfree.Rows[j]["Consignee Name"] = dtab.Rows[j]["consignee"].ToString();
                            dtemptyfree.Rows[j]["Numbers"] = dtab.Rows[j]["Counts"].ToString();
                            dtemptyfree.Rows[j]["cusid"] = dtab.Rows[j]["cusid"].ToString();
                        }
                        dtemptyfree.Rows.Add(dr);
                        var sum_Income = dtab.Compute("sum(counts)", "");
                        dtemptyfree.Rows[dtab.Rows.Count]["Consignee Name"] = "Total";
                        dtemptyfree.Rows[dtab.Rows.Count]["Numbers"] = sum_Income.ToString();

                        dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                        foreach (DataRow dtrow in dtemptyfree.Rows)
                        {
                            countrydetails details = new countrydetails();
                            details.Countryname = dtrow["Consignee Name"].ToString();
                            details.Total = Convert.ToInt32(dtrow["Numbers"]);
                            dataList.Add(details);
                        }
                    }
                }
            }
            return dataList;
        }
        public class countrydetails
        {
            public string Countryname { get; set; }
            public int Total { get; set; }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();

            if (Session["StrTranType"].ToString() == "FE")
            {
                if (!string.IsNullOrEmpty(GridView1.SelectedRow.Cells[1].Text))
                {
                    int jobno = Convert.ToInt32(GridView1.SelectedRow.Cells[7].Text);
                    string bookingno = GridView1.SelectedRow.Cells[1].Text;
                    if (jobno == 0)
                    {
                        dtuser = obj_UP.GetFormwiseuserRights(1, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    }
                    else
                    {
                        dtuser = obj_UP.GetFormwiseuserRights(2, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    }

                    if (dtuser.Rows.Count > 0)
                    {
                        if (jobno != 0)
                        {
                            string bLDetails = "Our BL";
                            Response.Redirect("../ShipmentDetails/FEBLdetails.aspx?BLDetails=" + bLDetails + "&bookingno=" + bookingno + "&jobno=" + jobno);
                        }
                        else if (jobno == 0)
                        {
                            string JobDetails = "JobDetails";
                            Response.Redirect("../ForwardExports/JobInfo.aspx?JobDetails=" + JobDetails + "&bookingno=" + bookingno + "&Cusid=" + hid_custid.Value);
                        }

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(GridView1, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                    }
                }
                else
                {
                    string message = "Job is Empty";
                    ScriptManager.RegisterStartupScript(GridView1, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
            else if (Session["StrTranType"].ToString() == "FI")
            {
                int jobno = Convert.ToInt32(GridView1.SelectedRow.Cells[7].Text);
                string bookingno = GridView1.SelectedRow.Cells[1].Text;
                if (jobno == 0)
                {
                    dtuser = obj_UP.GetFormwiseuserRights(3, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(122, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                }
                if (dtuser.Rows.Count > 0)
                {
                    if (jobno != 0)
                    {
                        Session["JobValue"] = "Out";
                        string doissue = "Direct BL";
                        Response.Redirect("../FI/FIBL.aspx?BLDetailsnew=" + doissue + "&bookingno=" + bookingno + "&jobno=" + jobno);

                    }
                    else if (jobno == 0)
                    {
                        Session["JobValue"] = "Out";
                        string JobDetails = "JobDetails";
                        Response.Redirect("../FI/jobinfo.aspx?JobDetails=" + JobDetails + "&bookingno=" + bookingno + "&Cusid=" + hid_custid.Value);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(GridView1, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            else if (Session["StrTranType"].ToString() == "AE")
            {
                int jobno = Convert.ToInt32(GridView1.SelectedRow.Cells[7].Text);
                string bookingno = GridView1.SelectedRow.Cells[1].Text;

                if (jobno == 0)
                {
                    dtuser = obj_UP.GetFormwiseuserRights(5, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(6, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                }

                if (dtuser.Rows.Count > 0)
                {
                    if (jobno != 0)
                    {
                        Session["JobValue"] = "Out";
                        string doissue = "Direct BL";
                        Response.Redirect("../AE/AEAWBDetails.aspx?BLDetails=" + doissue + "&bookingno=" + bookingno + "&jobno=" + jobno);

                    }
                    else if (jobno == 0)
                    {
                        Session["JobValue"] = "Out";
                        string JobDetails = "JobDetails";
                        Response.Redirect("../AE/AEJobInfo.aspx?JobDetails=" + JobDetails + "&bookingno=" + bookingno + "&Cusid=" + hid_custid.Value);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(GridView1, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            else if (Session["StrTranType"].ToString() == "AI")
            {
                int jobno = Convert.ToInt32(GridView1.SelectedRow.Cells[7].Text);
                string bookingno = GridView1.SelectedRow.Cells[1].Text;
                if (jobno == 0)
                {
                    dtuser = obj_UP.GetFormwiseuserRights(7, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(8, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                }
                if (dtuser.Rows.Count > 0)
                {
                    if (jobno != 0)
                    {
                        Session["JobValue"] = "Out";
                        string doissue = "Direct BL";
                        Response.Redirect("../AE/AEAWBDetails.aspx?BLDetails=" + doissue + "&bookingno=" + bookingno + "&jobno=" + jobno);

                    }
                    else if (jobno == 0)
                    {
                        Session["JobValue"] = "Out";
                        string JobDetails = "JobDetails";
                        Response.Redirect("../AE/AEJobInfo.aspx?JobDetails=" + JobDetails + "&bookingno=" + bookingno + "&Cusid=" + hid_custid.Value);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(GridView1, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void link_button1_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(953, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");

                }
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(954, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");

                }
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(955, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");

                }
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(956, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");

                }
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1787, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/CustomerProfile.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1788, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/CustomerProfile.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1789, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/CustomerProfile.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1790, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/CustomerProfile.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(101, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOME=" + name);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(102, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOME=" + name);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(103, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOME=" + name);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(104, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOME=" + name);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(88, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/ChangeJob.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(89, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/ChangeJob.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(90, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/ChangeJob.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(91, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/ChangeJob.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(93, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/AmendBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(94, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/AmendBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(95, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/AmendBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(96, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/AmendBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1239, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../FI/AmendForwarderBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1271, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/AmendSBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {

            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(371, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/AmendExRate.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(372, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/AmendExRate.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(373, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../AE/ExRateChange.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(374, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../AE/ExRateChange.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(66, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(67, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(68, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(69, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(516, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ShipmentDetails/UploadDocument.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(517, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ShipmentDetails/UploadDocument.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(518, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ShipmentDetails/UploadDocument.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(519, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ShipmentDetails/UploadDocument.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(533, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // Response.Redirect("../ForwardExports/Query.aspx");
                    string OEOPSDOCHomeFEQuery = "OEOPSDOCHomeFEQuery";
                    Response.Redirect("../ForwardExports/Query.aspx?OEOPSDOCHomeFEQuery=" + OEOPSDOCHomeFEQuery);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(LinkButton10, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    return;
                }

            }

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(534, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // Response.Redirect("../ForwardExports/Query.aspx");
                    string OEOPSDOCHomeFIQuery = "OEOPSDOCHomeFIQuery";
                    Response.Redirect("../ForwardExports/Query.aspx?OEOPSDOCHomeFIQuery=" + OEOPSDOCHomeFIQuery);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(LinkButton10, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    return;
                }

            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1641, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // Response.Redirect("../ForwardExports/Query.aspx");

                    string OEOPSDOCHomeAEQuery = "OEOPSDOCHomeAEQuery";
                    Response.Redirect("../ForwardExports/Query.aspx?OEOPSDOCHomeAEQuery=" + OEOPSDOCHomeAEQuery);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(LinkButton10, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }

            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1642, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //Response.Redirect("../ForwardExports/Query.aspx");
                    string OEOPSDOCHomeAIQuery = "OEOPSDOCHomeAIQuery";
                    Response.Redirect("../ForwardExports/Query.aspx?OEOPSDOCHomeAIQuery=" + OEOPSDOCHomeAIQuery);

                }

                else
                {

                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(LinkButton10, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }

        }

        private void Fn_Getdetail()
        {
            try
            {
                DataTable dcon = Appobj.Checkcountry(int.Parse(Session["LoginBranchid"].ToString()));
                int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                if(con == 1102 || con == 102)
                {
                    if (hid_type.Value.ToString() != "Transfer To Commercial PA")
                    {
                        Grd_Approval.Columns[8].Visible = false;
                        Grd_Approval.Columns[9].Visible = false;
                        Grd_Approval.Columns[10].Visible = false;                      
                        Grd_Approval.Columns[11].Visible = false;       //NewOne    //21/07/2022
                        Grd_Approval.Columns[12].Visible = false;
                        Grd_Approval.Columns[13].Visible = false;
                        Grd_Approval.Columns[14].Visible = false;
                        Grd_Approval.Columns[15].Visible = false;
                        Grd_Approval.Columns[16].Visible = false;
                    }
                    else
                    {
                        Grd_Approval.Columns[8].Visible = false;
                        Grd_Approval.Columns[9].Visible = true;
                        Grd_Approval.Columns[10].Visible = true;
                        Grd_Approval.Columns[11].Visible = true;       //NewOne    //21/07/2022
                        Grd_Approval.Columns[12].Visible = true;
                        Grd_Approval.Columns[13].Visible = true;
                        Grd_Approval.Columns[14].Visible = true;
                        Grd_Approval.Columns[15].Visible = true;
                        Grd_Approval.Columns[16].Visible = true;
                    }
                }
                else
                {
                    Grd_Approval.Columns[8].Visible = false;
                    Grd_Approval.Columns[9].Visible = false;
                    Grd_Approval.Columns[10].Visible = false;
                    Grd_Approval.Columns[11].Visible = false;       //NewOne    //21/07/2022
                    Grd_Approval.Columns[12].Visible = false;
                    Grd_Approval.Columns[13].Visible = false;
                    Grd_Approval.Columns[14].Visible = false;
                    Grd_Approval.Columns[15].Visible = false;
                    Grd_Approval.Columns[16].Visible = false;
                }
                

                DataTable obj_dt = new DataTable();
                //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                //obj_dt = obj_da_Approval.FillDt4ProLV(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), hid_type.Value.ToString());
                //obj_dt = obj_da_Approval.FillDt4ProTDS(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), hid_type.Value.ToString());

                obj_dt = obj_da_Approval.GetProApprovependingLVTask(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), hid_type.Value.ToString(), Convert.ToInt32(Session["LoginEmpId"]));    //NewOne
                Grd_Approval.DataSource = obj_dt;
                Grd_Approval.DataBind();

                if (hid_TaskId.Value == "1")
                {
                    DataView obj_dtview = new DataView(obj_dt);
                    obj_dtview.RowFilter = "voutype='" + hid_TaskValue.Value + "' ";
                    obj_dt = obj_dtview.ToTable();
                    Grd_Approval.DataSource = obj_dt;
                    Grd_Approval.DataBind();
                    hid_TaskId.Value = "0";
                    ddl_voutype.SelectedItem.Text = hid_TaskValue.Value.ToString();

                    ddl_voutype.SelectedItem.Enabled = false;

                }



                if (ddl_voutype.SelectedValue != "0" && ddl_voutype.SelectedValue != " ")
                {
                    if (obj_dt.Rows.Count > 0)
                    {

                        DataView obj_dtview = new DataView(obj_dt);
                        obj_dtview.RowFilter = "voutype='" + ddl_voutype.SelectedItem.Text + "' ";
                        obj_dt = obj_dtview.ToTable();
                        Grd_Approval.DataSource = obj_dt;
                        Grd_Approval.DataBind();
                        if (obj_dt.Rows.Count > 0)
                        {
                            hid_voutypeid.Value = obj_dt.Rows[0]["voutypeid"].ToString();
                        }
                    }
                }

                //NewOne    //21/07/2022
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable dlp = new DataTable();
                dlp = obj_da_Invoice.sp_ddlsectionnew1();

                for (int j = 0; j < Grd_Approval.Rows.Count; j++)
                {
                    var ddl1 = (DropDownList)Grd_Approval.Rows[j].FindControl("ddl_section");

                    ddl1.DataSource = dlp;
                    ddl1.DataTextField = "tdssection";

                    ddl1.DataBind();

                }


                TextBox lnkbtn;
                int i = 0;
                if (Grd_Approval.Rows.Count > 0)
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {

                                lnkbtn = (TextBox)(Grd_Approval.Rows[i].FindControl("txtpercentage"));       //NewOne       //22/07/2022
                                lnkbtn.Visible = true;

                            }
                            else
                            {
                                lnkbtn = (TextBox)(Grd_Approval.Rows[i].FindControl("txtpercentage"));       //NewOne       //22/07/2022
                                lnkbtn.Visible = false;
                            }

                        }
                    }
                }

                 

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        /* private void Fn_Getdetail()
         {
             try
             {
                 DataTable obj_dt = new DataTable();
                 DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                 obj_dt = obj_da_Approval.FillDt4ProLV(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), hid_type.Value.ToString());
                 Grd_Approval.DataSource = obj_dt;
                 Grd_Approval.DataBind();
             }
             catch (Exception ex)
             {
                 string message = ex.Message.ToString();
                 ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
             }

         }
       
         */

        protected void lnk_proInvoice_Click(object sender, EventArgs e)
        {
            btn_transfer.Visible = true;
            if (hid_invbkdated.Value == "Y")
            {
                btn_backdated.Visible = true;btn_backdated_id.Visible = true;
            }

            vis_div();
            linkunclose.Visible = false;
            lbl_blrelease.Visible = false;
            // lnk_Unclosed.Visible = false;
            lnk_cut1.Visible = false;
            link_cust.Visible = false;
            string vouname, vouname1;
            string trantype_process = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DataTable dtuser = new DataTable();
            ddl_voutype.Items.Clear();
            ddl_voutype.Items.Add(" ");
            ddl_voutype.Items.Add("SALES INVOICE");
            ddl_voutype.Items.Add("SALES INVOICE OC");
            ddl_voutype.Items.Add("OSSI");
            ddl_voutype.Items.Add("OSPI");

            if (trantype_process == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1016, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // this.aePopUpshow.Show();
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSSI Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSSI Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSPI Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSPI Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";

                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {

                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                     btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }

            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1023, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                      btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }

            if (trantype_process == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1030, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                       btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }

            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1037, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
        }

        protected void lnk_Prooncps_Click(object sender, EventArgs e)
        {

            btn_transfer.Visible = true;
            //btn_backdated.Visible = true;btn_backdated_id.Visible = true;
            if (hid_cnopsbkdated.Value == "Y")
            {
                btn_backdated.Visible = true;btn_backdated_id.Visible = true;
            }

            vis_div();
            linkunclose.Visible = false;
            lbl_blrelease.Visible = false;
            link_cust.Visible = false;
            lnk_cut1.Visible = false;
            // lnk_Unclosed.Visible = false;
            string vouname, vouname1;
            string trantype_process = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DataTable dtuser = new DataTable();
            ddl_voutype.Items.Clear();
            ddl_voutype.Items.Add(" ");
            ddl_voutype.Items.Add("PURCHASE INVOICE");
            ddl_voutype.Items.Add("PURCHASE INVOICE OC");
            if (trantype_process == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1017, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {

                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {

                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {

                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        btn_backdated.Visible = false;btn_backdated_id.Visible = false;
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                     btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1024, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    string app1 = "CN-Ops Proforma to Commercial";
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    //string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                   btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1031, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    div_ComApproval.Visible = true;
                    // this.aePopUpshow.Show();
                    string app1 = "CN-Ops Proforma to Commercial";
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    // string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                      btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    //  Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1038, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    //  string app1 = "CN-Ops Proforma to Commercial";
                    string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                      btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
        }

        protected void lnk_ProOsdn_Click(object sender, EventArgs e)
        {

            btn_transfer.Visible = true;
            btn_backdated.Visible = false;btn_backdated_id.Visible = false;
            vis_div();
            linkunclose.Visible = false;
            lbl_blrelease.Visible = false;
            //  lnk_Unclosed.Visible = false;
            lnk_cut1.Visible = false;
            link_cust.Visible = false;
            string vouname, vouname1;
            string trantype_process = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1018, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    // string app1 = "Invoice Proforma to Commercial";
                    string app1 = "OSDN Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOsdn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1025, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    string app1 = "OSDN Proforma to Commercial";
                    // Session["Value"] = 1;
                    // string app1 = "Invoice Proforma to Commercial";
                    //string app1 = "OSDN Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                      btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOsdn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1032, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //  Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    // string app1 = "Invoice Proforma to Commercial";
                    string app1 = "OSDN Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                       btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOsdn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1039, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    div_ComApproval.Visible = true;
                    string app1 = "OSDN Proforma to Commercial";
                    // Session["Value"] = 1;
                    //string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                      btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOsdn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
        }

        protected void lnk_ProOscn_Click(object sender, EventArgs e)
        {
            btn_transfer.Visible = true;
            btn_backdated.Visible = false;btn_backdated_id.Visible = false;
            vis_div();
            linkunclose.Visible = false;
            lbl_blrelease.Visible = false;
            // lnk_Unclosed.Visible = false;
            link_cust.Visible = false;
            string vouname, vouname1;
            string trantype_process = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1019, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    // string app1 = "Invoice Proforma to Commercial";
                    string app1 = "OSCN Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;

                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                       btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1026, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    // string app1 = "Invoice Proforma to Commercial";
                    string app1 = "OSCN Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;

                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        btn_backdated.Visible = false;btn_backdated_id.Visible = false;
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                      btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1033, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //  Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    // string app1 = "Invoice Proforma to Commercial";
                    string app1 = "OSCN Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;

                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        btn_backdated.Visible = false;btn_backdated_id.Visible = false;
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                        btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1040, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //  Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    // string app1 = "Invoice Proforma to Commercial";
                    string app1 = "OSCN Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;

                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        btn_backdated.Visible = false;btn_backdated_id.Visible = false;
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                       btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
        }

        protected void lnk_blnum_Click(object sender, EventArgs e)
        {
            vis_div();
            linkunclose.Visible = false;
            lbl_blrelease.Visible = false;
            link_pending.Visible = false;

            lnk_cut1.Visible = false;
            // lnk_Unclosed.Visible = false;

            rightbookingno.Visible = false;
            DataTable dtuser = new DataTable();
            string trantype_process = Session["StrTranType"].ToString();
            if (trantype_process == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1908, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    link_cust.Visible = true;
                    div_floatleft.Visible = true;
                    loadcustwise();
                  //  div2_Bookchart.Visible = true;
                    custid.Visible = true;
                    pnlGrdCuswise.Visible = true;
                    GrdCuswise.Visible = true;
                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }
            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1909, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    link_cust.Visible = true;
                    div_floatleft.Visible = true;
                    loadcustwise();
                  //  div2_Bookchart.Visible = true;
                    custid.Visible = true;
                    pnlGrdCuswise.Visible = true;
                    GrdCuswise.Visible = true;
                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            if (trantype_process == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1910, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    link_cust.Visible = true;
                    div_floatleft.Visible = true;
                    loadcustwise();
                   // div2_Bookchart.Visible = true;
                    custid.Visible = true;
                    pnlGrdCuswise.Visible = true;
                    GrdCuswise.Visible = true;
                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1911, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    link_cust.Visible = true;
                    div_floatleft.Visible = true;
                    loadcustwise();
                  //  div2_Bookchart.Visible = true;
                    custid.Visible = true;
                    pnlGrdCuswise.Visible = true;
                    GrdCuswise.Visible = true;
                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

        }

        protected void lnk_Blrelase_Click(object sender, EventArgs e)
        {

            vis_div();
            linkunclose.Visible = false;
            lbl_blrelease.Visible = true;
            link_pending.Visible = false;
            lnk_cut1.Visible = false;
            link_cust.Visible = false;
            // lnk_Unclosed.Visible = false;

            DataTable dtuser = new DataTable();
            string trantype_process = Session["StrTranType"].ToString();
            if (trantype_process == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1912, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    div_blrelase.Visible = true;
                    pendingHBLFE();
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1913, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    div_blrelase.Visible = true;
                    pendingHBLFE();
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            if (trantype_process == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1914, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    div_blrelase.Visible = true;
                    pendingHBLFE();
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1915, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    div_blrelase.Visible = true;
                    pendingHBLFE();
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ProOscn, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

        }

        //public void Visibe_false()
        //{
        //    div_floatleft.Visible = false;
        //}

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
                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string name = "";
            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "FI")
            {
                if (GridView2.Rows.Count > 0)
                {
                    dtuser = obj_UP.GetFormwiseuserRights(227, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        index = GridView2.SelectedRow.RowIndex;
                        name = GridView2.Rows[index].Cells[1].Text;
                        //Response.Redirect("../ForwardExports/BL Print.aspx?BLNumber=" + name);
                        //name = GrdPort1.Rows[index].Cells[0].Text;
                        //Response.Redirect("../ForwardExports/BL Print.aspx?BLNumber=" + name);
                        string doissue = "DODetails";
                        Response.Redirect("../ForwardExports/BL Print.aspx?DOissue=" + doissue + "&bookingno=" + name);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(GridView1, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                    }
                }
            }

            else if (Session["StrTranType"].ToString() == "FE")
            {
                if (GridView2.Rows.Count > 0)
                {

                    dtuser = obj_UP.GetFormwiseuserRights(463, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        index = GridView2.SelectedRow.RowIndex;
                        name = GridView2.Rows[index].Cells[1].Text;
                        // name = GridView2.Rows[index].Cells[1].Text;

                        //  Response.Redirect("../ForwardExports/BL Print.aspx?BLNumber=" + name);
                        Response.Redirect("../ShipmentDetails/BLRelease.aspx?BLReleaseNO=" + name);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(GridView1, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                    }
                }
            }

        }

        protected void lnk_Unclosed_Click(object sender, EventArgs e)
        {
            vis_div();
            linkunclose.Visible = true;
            lbl_blrelease.Visible = false;

            // lnk_Unclosed.Visible = true;
            link_cust.Visible = false;
            lnk_cut1.Visible = false;

            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            int logcorid, job;
            string value, product;
            string[] sp_job;

            DataTable dttemp = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1916, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        Div_Unclosed.Visible = true;
                        Div1.Visible = false;

                        //dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));

                        // dthbl = objClosedJob.Getunclosedjobnew(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]),0); //hideon130921 nivedha

                        dthbl = objClosedJob.GetunclosedjobnewWITHRET(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()), 0);

                        dttemp.Columns.Add("shortname");
                        dttemp.Columns.Add("Product");
                        dttemp.Columns.Add("jobno");
                        dttemp.Columns.Add("etd");
                        dttemp.Columns.Add("income");
                        dttemp.Columns.Add("expense");
                        dttemp.Columns.Add("retention");
                        dttemp.Columns.Add("Branchid");
                        dttemp.Columns.Add("MBL");
                        dttemp.Columns.Add("BL");
                        dttemp.Columns.Add("Shipper");
                        dttemp.Columns.Add("Consignee");
                        dttemp.Columns.Add("POL");
                        dttemp.Columns.Add("POD");
                        dttemp.Columns.Add("CustomerName");
                        dttemp.Columns.Add("Salesperson");
                        dttemp.Columns.Add("PreparedBy");
                        dttemp.Columns.Add("vessel");
                        dttemp.Columns.Add("ETA");
                        dttemp.Columns.Add("ETD1");

                        DataRow dr;

                        for (int i = 0; i <= dthbl.Rows.Count - 1; i++)
                        {

                            if (dthbl.Rows[i]["trantype"].ToString() == Session["StrTranType"].ToString() && Convert.ToInt32(dthbl.Rows[i]["bid"].ToString()) == Convert.ToInt32(Session["LoginBranchid"].ToString()))
                            {
                                dr = dttemp.NewRow();
                                value = dthbl.Rows[i]["jobno"].ToString();
                                sp_job = value.Split('-');
                                product = sp_job[1];

                                if (product == "FE")
                                {
                                    product = "OE";
                                }
                                else if (product == "FI")
                                {
                                    product = "OI";
                                }

                                job = Convert.ToInt32(sp_job[2]);
                                dr["shortname"] = dthbl.Rows[i]["shortname"].ToString();
                                dr["Product"] = product;
                                dr["jobno"] = value;
                                dr["etd"] = dthbl.Rows[i]["jobdate"].ToString();
                                dr["income"] = dthbl.Rows[i]["income"].ToString();
                                dr["expense"] = dthbl.Rows[i]["expense"].ToString();
                                dr["retention"] = dthbl.Rows[i]["retention"].ToString();
                                dr["Branchid"] = dthbl.Rows[i]["bid"].ToString();
                                dr["MBL"] = dthbl.Rows[i]["MBL"].ToString();
                                dr["BL"] = dthbl.Rows[i]["BL"].ToString();
                                dr["Shipper"] = dthbl.Rows[i]["Shipper"].ToString();
                                dr["Consignee"] = dthbl.Rows[i]["Consignee"].ToString();
                                dr["POL"] = dthbl.Rows[i]["POL"].ToString();
                                dr["POD"] = dthbl.Rows[i]["POD"].ToString();
                                dr["CustomerName"] = dthbl.Rows[i]["customername"].ToString();
                                dr["Salesperson"] = dthbl.Rows[i]["Salesperson"].ToString();
                                dr["vessel"] = dthbl.Rows[i]["vessel"].ToString();
                                dr["ETA"] = dthbl.Rows[i]["ETA"].ToString();
                                dr["ETD1"] = dthbl.Rows[i]["ETD1"].ToString();
                                dr["PreparedBy"] = dthbl.Rows[i]["PreparedBy"].ToString();
                                dttemp.Rows.Add(dr);
                            }

                        }

                        if (dttemp.Rows.Count > 0)
                        {
                            GridView3.DataSource = dttemp;
                            GridView3.DataBind();
                            ViewState["GridView3"] = dttemp;

                            //lbl_unclose.Text = Unclose_Job.InnerText + " BL Wise Unclosed Jobs -" + dttemp.Rows.Count;//hideon051021
                            //lbl_unclose.Text = Unclose_Job.InnerText + " No of BL(S) " + dttemp.Rows.Count;

                            lbl_unclose.Text = Unclose_Job.InnerText + " No of Job(S) " + objClosedJob.getopenjobcount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"])).ToString() + " / No of BL(S) " + dttemp.Rows.Count;


                        }
                        else
                        {
                            GridView3.DataSource = new DataTable();
                            GridView3.DataBind();
                        }
                    }

                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        Div_Unclosed.Visible = true;
                        Div1.Visible = false;
                        //dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                        //if (dthbl.Rows.Count > 0)
                        //{
                        //    GridView3.DataSource = dthbl;
                        //    GridView3.DataBind();
                        //    ViewState["GridView3"] = dthbl;
                        //}
                        //else
                        //{
                        //    GridView3.DataSource = new DataTable();
                        //    GridView3.DataBind();
                        //}

                        // dthbl = objClosedJob.Getunclosedjobnew(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), 0); //nivedha

                        dthbl = objClosedJob.GetunclosedjobnewWITHRET(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()), 0);

                        dttemp.Columns.Add("shortname");
                        dttemp.Columns.Add("Product");
                        dttemp.Columns.Add("jobno");
                        dttemp.Columns.Add("etd");
                        dttemp.Columns.Add("income");
                        dttemp.Columns.Add("expense");
                        dttemp.Columns.Add("retention");
                        dttemp.Columns.Add("Branchid");
                        dttemp.Columns.Add("MBL");
                        dttemp.Columns.Add("BL");
                        dttemp.Columns.Add("Shipper");
                        dttemp.Columns.Add("Consignee");
                        dttemp.Columns.Add("POL");
                        dttemp.Columns.Add("POD");
                        dttemp.Columns.Add("CustomerName");
                        dttemp.Columns.Add("Salesperson");
                        dttemp.Columns.Add("PreparedBy");
                        dttemp.Columns.Add("vessel");
                        dttemp.Columns.Add("ETA");
                        dttemp.Columns.Add("ETD1");

                        DataRow dr;

                        for (int i = 0; i <= dthbl.Rows.Count - 1; i++)
                        {

                            if (dthbl.Rows[i]["trantype"].ToString() == Session["StrTranType"].ToString() && Convert.ToInt32(dthbl.Rows[i]["bid"].ToString()) == Convert.ToInt32(Session["LoginBranchid"].ToString()))
                            {
                                dr = dttemp.NewRow();
                                value = dthbl.Rows[i]["jobno"].ToString();
                                sp_job = value.Split('-');
                                product = sp_job[1];

                                if (product == "FE")
                                {
                                    product = "OE";
                                }
                                else if (product == "FI")
                                {
                                    product = "OI";
                                }

                                job = Convert.ToInt32(sp_job[2]);
                                dr["shortname"] = dthbl.Rows[i]["shortname"].ToString();
                                dr["Product"] = product;
                                dr["jobno"] = value;
                                dr["etd"] = dthbl.Rows[i]["jobdate"].ToString();
                                dr["income"] = dthbl.Rows[i]["income"].ToString();
                                dr["expense"] = dthbl.Rows[i]["expense"].ToString();
                                dr["retention"] = dthbl.Rows[i]["retention"].ToString();
                                dr["Branchid"] = dthbl.Rows[i]["bid"].ToString();
                                dr["MBL"] = dthbl.Rows[i]["MBL"].ToString();
                                dr["BL"] = dthbl.Rows[i]["BL"].ToString();
                                dr["Shipper"] = dthbl.Rows[i]["Shipper"].ToString();
                                dr["Consignee"] = dthbl.Rows[i]["Consignee"].ToString();
                                dr["POL"] = dthbl.Rows[i]["POL"].ToString();
                                dr["POD"] = dthbl.Rows[i]["POD"].ToString();
                                dr["CustomerName"] = dthbl.Rows[i]["customername"].ToString();
                                dr["Salesperson"] = dthbl.Rows[i]["Salesperson"].ToString();
                                dr["vessel"] = dthbl.Rows[i]["vessel"].ToString();
                                dr["ETA"] = dthbl.Rows[i]["ETA"].ToString();
                                dr["ETD1"] = dthbl.Rows[i]["ETD1"].ToString();
                                dr["PreparedBy"] = dthbl.Rows[i]["PreparedBy"].ToString();
                                dttemp.Rows.Add(dr);
                            }

                        }

                        if (dttemp.Rows.Count > 0)
                        {
                            GridView3.DataSource = dttemp;
                            GridView3.DataBind();
                            ViewState["GridView3"] = dttemp;
                            //lbl_unclose.Text = Unclose_Job.InnerText + " BL Wise Unclosed Jobs -" + dttemp.Rows.Count; //Hideon2021

                            //lbl_unclose.Text = Unclose_Job.InnerText + " No of BL(S) " + dttemp.Rows.Count;
                            lbl_unclose.Text = Unclose_Job.InnerText + " No of Job(S) " + objClosedJob.getopenjobcount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"])).ToString() + " / No of BL(S) " + dttemp.Rows.Count;

                        }
                        else
                        {
                            GridView3.DataSource = new DataTable();
                            GridView3.DataBind();
                        }

                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        //Div_Unclosed.Visible = false;

                        //Div1.Visible = true;

                        // dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));

                        //if (dthbl.Rows.Count > 0)
                        //{
                        //    GridView4.DataSource = dthbl;
                        //    GridView4.DataBind();
                        //    ViewState["GridView3"] = dthbl;
                        //}
                        //else
                        //{
                        //    GridView4.DataSource = new DataTable();
                        //    GridView4.DataBind();
                        //}

                        Div_Unclosed.Visible = true;
                        Div1.Visible = false;
                        // dthbl = objClosedJob.Getunclosedjobnew(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), 0); nivedha

                        dthbl = objClosedJob.GetunclosedjobnewWITHRET(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()), 0);

                        dttemp.Columns.Add("shortname");
                        dttemp.Columns.Add("Product");
                        dttemp.Columns.Add("jobno");
                        dttemp.Columns.Add("etd");
                        dttemp.Columns.Add("income");
                        dttemp.Columns.Add("expense");
                        dttemp.Columns.Add("retention");
                        dttemp.Columns.Add("Branchid");
                        dttemp.Columns.Add("MBL");
                        dttemp.Columns.Add("BL");
                        dttemp.Columns.Add("Shipper");
                        dttemp.Columns.Add("Consignee");
                        dttemp.Columns.Add("POL");
                        dttemp.Columns.Add("POD");
                        dttemp.Columns.Add("CustomerName");
                        dttemp.Columns.Add("Salesperson");
                        dttemp.Columns.Add("PreparedBy");
                        dttemp.Columns.Add("vessel");
                        dttemp.Columns.Add("ETA");
                        dttemp.Columns.Add("ETD1");

                        DataRow dr;

                        for (int i = 0; i <= dthbl.Rows.Count - 1; i++)
                        {

                            if (dthbl.Rows[i]["trantype"].ToString() == Session["StrTranType"].ToString() && Convert.ToInt32(dthbl.Rows[i]["bid"].ToString()) == Convert.ToInt32(Session["LoginBranchid"].ToString()))
                            {
                                dr = dttemp.NewRow();
                                value = dthbl.Rows[i]["jobno"].ToString();
                                sp_job = value.Split('-');
                                product = sp_job[1];

                                if (product == "FE")
                                {
                                    product = "OE";
                                }
                                else if (product == "FI")
                                {
                                    product = "OI";
                                }

                                job = Convert.ToInt32(sp_job[2]);
                                dr["shortname"] = dthbl.Rows[i]["shortname"].ToString();
                                dr["Product"] = product;
                                dr["jobno"] = value;
                                dr["etd"] = dthbl.Rows[i]["jobdate"].ToString();
                                dr["income"] = dthbl.Rows[i]["income"].ToString();
                                dr["expense"] = dthbl.Rows[i]["expense"].ToString();
                                dr["retention"] = dthbl.Rows[i]["retention"].ToString();
                                dr["Branchid"] = dthbl.Rows[i]["bid"].ToString();
                                dr["MBL"] = dthbl.Rows[i]["MBL"].ToString();
                                dr["BL"] = dthbl.Rows[i]["BL"].ToString();
                                dr["Shipper"] = dthbl.Rows[i]["Shipper"].ToString();
                                dr["Consignee"] = dthbl.Rows[i]["Consignee"].ToString();
                                dr["POL"] = dthbl.Rows[i]["POL"].ToString();
                                dr["POD"] = dthbl.Rows[i]["POD"].ToString();
                                dr["CustomerName"] = dthbl.Rows[i]["customername"].ToString();
                                dr["Salesperson"] = dthbl.Rows[i]["Salesperson"].ToString();
                                dr["vessel"] = dthbl.Rows[i]["vessel"].ToString();
                                dr["ETA"] = dthbl.Rows[i]["ETA"].ToString();
                                dr["ETD1"] = dthbl.Rows[i]["ETD1"].ToString();
                                dr["PreparedBy"] = dthbl.Rows[i]["PreparedBy"].ToString();
                                dttemp.Rows.Add(dr);
                            }

                        }

                        if (dttemp.Rows.Count > 0)
                        {
                            GridView3.DataSource = dttemp;
                            GridView3.DataBind();
                            ViewState["GridView3"] = dttemp;

                            //lbl_unclose.Text = Unclose_Job.InnerText + " BL Wise Unclosed Jobs -" + dttemp.Rows.Count;// No of BL(S)
                            // lbl_unclose.Text = Unclose_Job.InnerText + " No of BL(S) " + dttemp.Rows.Count;
                            lbl_unclose.Text = Unclose_Job.InnerText + " No of Job(S) " + objClosedJob.getopenjobcount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"])).ToString() + " / No of BL(S) " + dttemp.Rows.Count;

                        }
                        else
                        {
                            GridView3.DataSource = new DataTable();
                            GridView3.DataBind();
                        }

                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        //Div_Unclosed.Visible = false;
                        //Div1.Visible = true;

                        //dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                        //if (dthbl.Rows.Count > 0)
                        //{
                        //    GridView4.DataSource = dthbl;
                        //    GridView4.DataBind();
                        //    ViewState["GridView3"] = dthbl;
                        //}
                        //else
                        //{
                        //    GridView4.DataSource = new DataTable();
                        //    GridView4.DataBind();
                        //}

                        // dthbl = objClosedJob.Getunclosedjobnew(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), 0);nivedha
                        dthbl = objClosedJob.GetunclosedjobnewWITHRET(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()), 0);

                        Div_Unclosed.Visible = true;
                        Div1.Visible = false;

                        dttemp.Columns.Add("shortname");
                        dttemp.Columns.Add("Product");
                        dttemp.Columns.Add("jobno");
                        dttemp.Columns.Add("etd");
                        dttemp.Columns.Add("income");
                        dttemp.Columns.Add("expense");
                        dttemp.Columns.Add("retention");
                        dttemp.Columns.Add("Branchid");
                        dttemp.Columns.Add("MBL");
                        dttemp.Columns.Add("BL");
                        dttemp.Columns.Add("Shipper");
                        dttemp.Columns.Add("Consignee");
                        dttemp.Columns.Add("POL");
                        dttemp.Columns.Add("POD");
                        dttemp.Columns.Add("CustomerName");
                        dttemp.Columns.Add("Salesperson");
                        dttemp.Columns.Add("PreparedBy");
                        dttemp.Columns.Add("vessel");
                        dttemp.Columns.Add("ETA");
                        dttemp.Columns.Add("ETD1");

                        DataRow dr;

                        for (int i = 0; i <= dthbl.Rows.Count - 1; i++)
                        {

                            if (dthbl.Rows[i]["trantype"].ToString() == Session["StrTranType"].ToString() && Convert.ToInt32(dthbl.Rows[i]["bid"].ToString()) == Convert.ToInt32(Session["LoginBranchid"].ToString()))
                            {
                                dr = dttemp.NewRow();
                                value = dthbl.Rows[i]["jobno"].ToString();
                                sp_job = value.Split('-');
                                product = sp_job[1];

                                if (product == "FE")
                                {
                                    product = "OE";
                                }
                                else if (product == "FI")
                                {
                                    product = "OI";
                                }

                                job = Convert.ToInt32(sp_job[2]);
                                dr["shortname"] = dthbl.Rows[i]["shortname"].ToString();
                                dr["Product"] = product;
                                dr["jobno"] = value;
                                dr["etd"] = dthbl.Rows[i]["jobdate"].ToString();
                                dr["income"] = dthbl.Rows[i]["income"].ToString();
                                dr["expense"] = dthbl.Rows[i]["expense"].ToString();
                                dr["retention"] = dthbl.Rows[i]["retention"].ToString();
                                dr["Branchid"] = dthbl.Rows[i]["bid"].ToString();
                                dr["MBL"] = dthbl.Rows[i]["MBL"].ToString();
                                dr["BL"] = dthbl.Rows[i]["BL"].ToString();
                                dr["Shipper"] = dthbl.Rows[i]["Shipper"].ToString();
                                dr["Consignee"] = dthbl.Rows[i]["Consignee"].ToString();
                                dr["POL"] = dthbl.Rows[i]["POL"].ToString();
                                dr["POD"] = dthbl.Rows[i]["POD"].ToString();
                                dr["CustomerName"] = dthbl.Rows[i]["customername"].ToString();
                                dr["Salesperson"] = dthbl.Rows[i]["Salesperson"].ToString();
                                dr["vessel"] = dthbl.Rows[i]["vessel"].ToString();
                                dr["ETA"] = dthbl.Rows[i]["ETA"].ToString();
                                dr["ETD1"] = dthbl.Rows[i]["ETD1"].ToString();
                                dr["PreparedBy"] = dthbl.Rows[i]["PreparedBy"].ToString();
                                dttemp.Rows.Add(dr);
                            }

                        }

                        if (dttemp.Rows.Count > 0)
                        {
                            GridView3.DataSource = dttemp;
                            GridView3.DataBind();
                            ViewState["GridView3"] = dttemp;
                            //lbl_unclose.Text = Unclose_Job.InnerText + " BL Wise Unclosed Jobs -" + dttemp.Rows.Count;
                            // lbl_unclose.Text = Unclose_Job.InnerText + " No of BL(S) " + dttemp.Rows.Count;
                            lbl_unclose.Text = Unclose_Job.InnerText + " No of Job(S) " + objClosedJob.getopenjobcount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"])).ToString() + " / No of BL(S) " + dttemp.Rows.Count;

                        }
                        else
                        {
                            GridView3.DataSource = new DataTable();
                            GridView3.DataBind();
                        }
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1917, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //if (Session["StrTranType"].ToString() == "FE")
                    //{
                    //    Div_Unclosed.Visible = true;
                    //    Div1.Visible = false;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    DataTable dtemptyfree = new DataTable();

                    //    //dtemptyfree.Columns.Add("SI");
                    //    //dtemptyfree.Columns.Add("JobNo");
                    //    //dtemptyfree.Columns.Add("jobDate");
                    //    //dtemptyfree.Columns.Add("Voyage");
                    //    //dtemptyfree.Columns.Add("Agent");
                    //    //dtemptyfree.Columns.Add("pol");
                    //    //dtemptyfree.Columns.Add("eta");
                    //    //dtemptyfree.Columns.Add("pod");
                    //    //dtemptyfree.Columns.Add("etd");
                    //    //dtemptyfree.Columns.Add("custid");
                    //    //DataRow dr = dtemptyfree.NewRow();
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView3.DataSource = dthbl;
                    //        GridView3.DataBind();
                    //        ViewState["GridView3"] = dthbl;

                    //        //for (int i = 0; i <= dthbl.Rows.Count - 1;i++ )
                    //        //{
                    //        //    dtemptyfree.Rows.Add();
                    //        //    dr = dtemptyfree.NewRow();
                    //        //    dtemptyfree.Rows[i]["SI"] = dthbl.Rows[i]["SI"].ToString();
                    //        //    dtemptyfree.Rows[i]["JobNo"] = dthbl.Rows[i]["JobNo"].ToString();
                    //        //    dtemptyfree.Rows[i]["jobDate"] = dthbl.Rows[i]["jobDate"].ToString();
                    //        //    dtemptyfree.Rows[i]["Voyage"] = dthbl.Rows[i]["Voyage"].ToString();
                    //        //    dtemptyfree.Rows[i]["pol"] = dthbl.Rows[i]["pol"].ToString();
                    //        //    dtemptyfree.Rows[i]["eta"] = dthbl.Rows[i]["eta"].ToString();
                    //        //    dtemptyfree.Rows[i]["pod"] = dthbl.Rows[i]["pod"].ToString();
                    //        //    dtemptyfree.Rows[i]["etd"] = dthbl.Rows[i]["etd"].ToString();
                    //        //    dtemptyfree.Rows[i]["custid"] = dthbl.Rows[i]["custid"].ToString();
                    //        //}
                    //        //dtemptyfree.Rows.Add(dr);
                    //        //var sum_Income = dthbl.Compute("sum(counts)", "");
                    //        //dtemptyfree.Rows[dthbl.Rows.Count]["Customer Name"] = "Total";
                    //        //dtemptyfree.Rows[dthbl.Rows.Count]["Numbers"] = sum_Income.ToString();
                    //    }
                    //    else
                    //    {
                    //        GridView3.DataSource = new DataTable();
                    //        GridView3.DataBind();
                    //    }

                    //}

                    //else if (Session["StrTranType"].ToString() == "FI")
                    //{
                    //    Div_Unclosed.Visible = true;
                    //    Div1.Visible = false;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView3.DataSource = dthbl;
                    //        GridView3.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView3.DataSource = new DataTable();
                    //        GridView3.DataBind();
                    //    }
                    //}
                    //else if (Session["StrTranType"].ToString() == "AE")
                    //{
                    //    Div_Unclosed.Visible = false;

                    //    Div1.Visible = true;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView4.DataSource = dthbl;
                    //        GridView4.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView4.DataSource = new DataTable();
                    //        GridView4.DataBind();
                    //    }
                    //}
                    //else if (Session["StrTranType"].ToString() == "AI")
                    //{
                    //    Div_Unclosed.Visible = false;
                    //    Div1.Visible = true;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView4.DataSource = dthbl;
                    //        GridView4.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView4.DataSource = new DataTable();
                    //        GridView4.DataBind();
                    //    }
                    //}

                    // dthbl = objClosedJob.Getunclosedjobnew(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), 0);nivedha 
                    dthbl = objClosedJob.GetunclosedjobnewWITHRET(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()), 0);

                    Div_Unclosed.Visible = true;
                    Div1.Visible = false;

                    dttemp.Columns.Add("shortname");
                    dttemp.Columns.Add("Product");
                    dttemp.Columns.Add("jobno");
                    dttemp.Columns.Add("etd");
                    dttemp.Columns.Add("income");
                    dttemp.Columns.Add("expense");
                    dttemp.Columns.Add("retention");
                    dttemp.Columns.Add("Branchid");
                    dttemp.Columns.Add("MBL");
                    dttemp.Columns.Add("BL");
                    dttemp.Columns.Add("Shipper");
                    dttemp.Columns.Add("Consignee");
                    dttemp.Columns.Add("POL");
                    dttemp.Columns.Add("POD");
                    dttemp.Columns.Add("CustomerName");
                    dttemp.Columns.Add("Salesperson");
                    dttemp.Columns.Add("PreparedBy");
                    dttemp.Columns.Add("vessel");
                    dttemp.Columns.Add("ETA");
                    dttemp.Columns.Add("ETD1");

                    DataRow dr;

                    for (int i = 0; i <= dthbl.Rows.Count - 1; i++)
                    {

                        if (dthbl.Rows[i]["trantype"].ToString() == Session["StrTranType"].ToString() && Convert.ToInt32(dthbl.Rows[i]["bid"].ToString()) == Convert.ToInt32(Session["LoginBranchid"].ToString()))
                        {
                            dr = dttemp.NewRow();
                            value = dthbl.Rows[i]["jobno"].ToString();
                            sp_job = value.Split('-');
                            product = sp_job[1];

                            if (product == "FE")
                            {
                                product = "OE";
                            }
                            else if (product == "FI")
                            {
                                product = "OI";
                            }

                            job = Convert.ToInt32(sp_job[2]);
                            dr["shortname"] = dthbl.Rows[i]["shortname"].ToString();
                            dr["Product"] = product;
                            dr["jobno"] = value;
                            dr["etd"] = dthbl.Rows[i]["jobdate"].ToString();
                            dr["income"] = dthbl.Rows[i]["income"].ToString();
                            dr["expense"] = dthbl.Rows[i]["expense"].ToString();
                            dr["retention"] = dthbl.Rows[i]["retention"].ToString();
                            dr["Branchid"] = dthbl.Rows[i]["bid"].ToString();
                            dr["MBL"] = dthbl.Rows[i]["MBL"].ToString();
                            dr["BL"] = dthbl.Rows[i]["BL"].ToString();
                            dr["Shipper"] = dthbl.Rows[i]["Shipper"].ToString();
                            dr["Consignee"] = dthbl.Rows[i]["Consignee"].ToString();
                            dr["POL"] = dthbl.Rows[i]["POL"].ToString();
                            dr["POD"] = dthbl.Rows[i]["POD"].ToString();
                            dr["CustomerName"] = dthbl.Rows[i]["customername"].ToString();
                            dr["Salesperson"] = dthbl.Rows[i]["Salesperson"].ToString();
                            dr["vessel"] = dthbl.Rows[i]["vessel"].ToString();
                            dr["ETA"] = dthbl.Rows[i]["ETA"].ToString();
                            dr["ETD1"] = dthbl.Rows[i]["ETD1"].ToString();
                            dr["PreparedBy"] = dthbl.Rows[i]["PreparedBy"].ToString();
                            dttemp.Rows.Add(dr);
                        }

                    }

                    if (dttemp.Rows.Count > 0)
                    {
                        GridView3.DataSource = dttemp;
                        GridView3.DataBind();
                        ViewState["GridView3"] = dttemp;

                        //lbl_unclose.Text = Unclose_Job.InnerText + " BL Wise Unclosed Jobs -" + dttemp.Rows.Count;

                        // lbl_unclose.Text = Unclose_Job.InnerText + " No of BL(S) " + dttemp.Rows.Count;
                        lbl_unclose.Text = Unclose_Job.InnerText + " No of Job(S) " + objClosedJob.getopenjobcount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"])).ToString() + " / No of BL(S) " + dttemp.Rows.Count;

                    }
                    else
                    {
                        GridView3.DataSource = new DataTable();
                        GridView3.DataBind();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1918, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //if (Session["StrTranType"].ToString() == "FE")
                    //{
                    //    Div_Unclosed.Visible = true;
                    //    Div1.Visible = false;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    DataTable dtemptyfree = new DataTable();

                    //    //dtemptyfree.Columns.Add("SI");
                    //    //dtemptyfree.Columns.Add("JobNo");
                    //    //dtemptyfree.Columns.Add("jobDate");
                    //    //dtemptyfree.Columns.Add("Voyage");
                    //    //dtemptyfree.Columns.Add("Agent");
                    //    //dtemptyfree.Columns.Add("pol");
                    //    //dtemptyfree.Columns.Add("eta");
                    //    //dtemptyfree.Columns.Add("pod");
                    //    //dtemptyfree.Columns.Add("etd");
                    //    //dtemptyfree.Columns.Add("custid");
                    //    //DataRow dr = dtemptyfree.NewRow();
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView3.DataSource = dthbl;
                    //        GridView3.DataBind();
                    //        ViewState["GridView3"] = dthbl;

                    //        //for (int i = 0; i <= dthbl.Rows.Count - 1;i++ )
                    //        //{
                    //        //    dtemptyfree.Rows.Add();
                    //        //    dr = dtemptyfree.NewRow();
                    //        //    dtemptyfree.Rows[i]["SI"] = dthbl.Rows[i]["SI"].ToString();
                    //        //    dtemptyfree.Rows[i]["JobNo"] = dthbl.Rows[i]["JobNo"].ToString();
                    //        //    dtemptyfree.Rows[i]["jobDate"] = dthbl.Rows[i]["jobDate"].ToString();
                    //        //    dtemptyfree.Rows[i]["Voyage"] = dthbl.Rows[i]["Voyage"].ToString();
                    //        //    dtemptyfree.Rows[i]["pol"] = dthbl.Rows[i]["pol"].ToString();
                    //        //    dtemptyfree.Rows[i]["eta"] = dthbl.Rows[i]["eta"].ToString();
                    //        //    dtemptyfree.Rows[i]["pod"] = dthbl.Rows[i]["pod"].ToString();
                    //        //    dtemptyfree.Rows[i]["etd"] = dthbl.Rows[i]["etd"].ToString();
                    //        //    dtemptyfree.Rows[i]["custid"] = dthbl.Rows[i]["custid"].ToString();
                    //        //}
                    //        //dtemptyfree.Rows.Add(dr);
                    //        //var sum_Income = dthbl.Compute("sum(counts)", "");
                    //        //dtemptyfree.Rows[dthbl.Rows.Count]["Customer Name"] = "Total";
                    //        //dtemptyfree.Rows[dthbl.Rows.Count]["Numbers"] = sum_Income.ToString();
                    //    }
                    //    else
                    //    {
                    //        GridView3.DataSource = new DataTable();
                    //        GridView3.DataBind();
                    //    }
                    //}

                    //else if (Session["StrTranType"].ToString() == "FI")
                    //{
                    //    Div_Unclosed.Visible = true;
                    //    Div1.Visible = false;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView3.DataSource = dthbl;
                    //        GridView3.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView3.DataSource = new DataTable();
                    //        GridView3.DataBind();
                    //    }
                    //}
                    //else if (Session["StrTranType"].ToString() == "AE")
                    //{
                    //    Div_Unclosed.Visible = false;

                    //    Div1.Visible = true;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView4.DataSource = dthbl;
                    //        GridView4.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView4.DataSource = new DataTable();
                    //        GridView4.DataBind();
                    //    }
                    //}
                    //else if (Session["StrTranType"].ToString() == "AI")
                    //{
                    //    Div_Unclosed.Visible = false;
                    //    Div1.Visible = true;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView4.DataSource = dthbl;
                    //        GridView4.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView4.DataSource = new DataTable();
                    //        GridView4.DataBind();
                    //    }
                    //}

                    //  dthbl = objClosedJob.Getunclosedjobnew(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), 0); nivedha
                    dthbl = objClosedJob.GetunclosedjobnewWITHRET(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()), 0);

                    Div_Unclosed.Visible = true;
                    Div1.Visible = false;

                    dttemp.Columns.Add("shortname");
                    dttemp.Columns.Add("Product");
                    dttemp.Columns.Add("jobno");
                    dttemp.Columns.Add("etd");
                    dttemp.Columns.Add("income");
                    dttemp.Columns.Add("expense");
                    dttemp.Columns.Add("retention");
                    dttemp.Columns.Add("Branchid");
                    dttemp.Columns.Add("MBL");
                    dttemp.Columns.Add("BL");
                    dttemp.Columns.Add("Shipper");
                    dttemp.Columns.Add("Consignee");
                    dttemp.Columns.Add("POL");
                    dttemp.Columns.Add("POD");
                    dttemp.Columns.Add("CustomerName");
                    dttemp.Columns.Add("Salesperson");
                    dttemp.Columns.Add("PreparedBy");
                    dttemp.Columns.Add("vessel");
                    dttemp.Columns.Add("ETA");
                    dttemp.Columns.Add("ETD1");

                    DataRow dr;

                    for (int i = 0; i <= dthbl.Rows.Count - 1; i++)
                    {

                        if (dthbl.Rows[i]["trantype"].ToString() == Session["StrTranType"].ToString() && Convert.ToInt32(dthbl.Rows[i]["bid"].ToString()) == Convert.ToInt32(Session["LoginBranchid"].ToString()))
                        {
                            dr = dttemp.NewRow();
                            value = dthbl.Rows[i]["jobno"].ToString();
                            sp_job = value.Split('-');
                            product = sp_job[1];

                            if (product == "FE")
                            {
                                product = "OE";
                            }
                            else if (product == "FI")
                            {
                                product = "OI";
                            }

                            job = Convert.ToInt32(sp_job[2]);
                            dr["shortname"] = dthbl.Rows[i]["shortname"].ToString();
                            dr["Product"] = product;
                            dr["jobno"] = value;
                            dr["etd"] = dthbl.Rows[i]["jobdate"].ToString();
                            dr["income"] = dthbl.Rows[i]["income"].ToString();
                            dr["expense"] = dthbl.Rows[i]["expense"].ToString();
                            dr["retention"] = dthbl.Rows[i]["retention"].ToString();
                            dr["Branchid"] = dthbl.Rows[i]["bid"].ToString();
                            dr["MBL"] = dthbl.Rows[i]["MBL"].ToString();
                            dr["BL"] = dthbl.Rows[i]["BL"].ToString();
                            dr["Shipper"] = dthbl.Rows[i]["Shipper"].ToString();
                            dr["Consignee"] = dthbl.Rows[i]["Consignee"].ToString();
                            dr["POL"] = dthbl.Rows[i]["POL"].ToString();
                            dr["POD"] = dthbl.Rows[i]["POD"].ToString();
                            dr["CustomerName"] = dthbl.Rows[i]["customername"].ToString();
                            dr["Salesperson"] = dthbl.Rows[i]["Salesperson"].ToString();
                            dr["vessel"] = dthbl.Rows[i]["vessel"].ToString();
                            dr["ETA"] = dthbl.Rows[i]["ETA"].ToString();
                            dr["ETD1"] = dthbl.Rows[i]["ETD1"].ToString();
                            dr["PreparedBy"] = dthbl.Rows[i]["PreparedBy"].ToString();
                            dttemp.Rows.Add(dr);
                        }

                    }

                    if (dttemp.Rows.Count > 0)
                    {
                        GridView3.DataSource = dttemp;
                        GridView3.DataBind();
                        ViewState["GridView3"] = dttemp;
                        //lbl_unclose.Text = Unclose_Job.InnerText + " BL Wise Unclosed Jobs -" + dttemp.Rows.Count; " No of BL(S) "
                        //   lbl_unclose.Text = Unclose_Job.InnerText + " No of BL(S) " + dttemp.Rows.Count;
                        lbl_unclose.Text = Unclose_Job.InnerText + " No of Job(S) " + objClosedJob.getopenjobcount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"])).ToString() + " / No of BL(S) " + dttemp.Rows.Count;

                    }
                    else
                    {
                        GridView3.DataSource = new DataTable();
                        GridView3.DataBind();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1919, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //if (Session["StrTranType"].ToString() == "FE")
                    //{
                    //    Div_Unclosed.Visible = true;
                    //    Div1.Visible = false;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    DataTable dtemptyfree = new DataTable();

                    //    //dtemptyfree.Columns.Add("SI");
                    //    //dtemptyfree.Columns.Add("JobNo");
                    //    //dtemptyfree.Columns.Add("jobDate");
                    //    //dtemptyfree.Columns.Add("Voyage");
                    //    //dtemptyfree.Columns.Add("Agent");
                    //    //dtemptyfree.Columns.Add("pol");
                    //    //dtemptyfree.Columns.Add("eta");
                    //    //dtemptyfree.Columns.Add("pod");
                    //    //dtemptyfree.Columns.Add("etd");
                    //    //dtemptyfree.Columns.Add("custid");
                    //    //DataRow dr = dtemptyfree.NewRow();
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView3.DataSource = dthbl;
                    //        GridView3.DataBind();
                    //        ViewState["GridView3"] = dthbl;

                    //        //for (int i = 0; i <= dthbl.Rows.Count - 1;i++ )
                    //        //{
                    //        //    dtemptyfree.Rows.Add();
                    //        //    dr = dtemptyfree.NewRow();
                    //        //    dtemptyfree.Rows[i]["SI"] = dthbl.Rows[i]["SI"].ToString();
                    //        //    dtemptyfree.Rows[i]["JobNo"] = dthbl.Rows[i]["JobNo"].ToString();
                    //        //    dtemptyfree.Rows[i]["jobDate"] = dthbl.Rows[i]["jobDate"].ToString();
                    //        //    dtemptyfree.Rows[i]["Voyage"] = dthbl.Rows[i]["Voyage"].ToString();
                    //        //    dtemptyfree.Rows[i]["pol"] = dthbl.Rows[i]["pol"].ToString();
                    //        //    dtemptyfree.Rows[i]["eta"] = dthbl.Rows[i]["eta"].ToString();
                    //        //    dtemptyfree.Rows[i]["pod"] = dthbl.Rows[i]["pod"].ToString();
                    //        //    dtemptyfree.Rows[i]["etd"] = dthbl.Rows[i]["etd"].ToString();
                    //        //    dtemptyfree.Rows[i]["custid"] = dthbl.Rows[i]["custid"].ToString();
                    //        //}
                    //        //dtemptyfree.Rows.Add(dr);
                    //        //var sum_Income = dthbl.Compute("sum(counts)", "");
                    //        //dtemptyfree.Rows[dthbl.Rows.Count]["Customer Name"] = "Total";
                    //        //dtemptyfree.Rows[dthbl.Rows.Count]["Numbers"] = sum_Income.ToString();
                    //    }
                    //    else
                    //    {
                    //        GridView3.DataSource = new DataTable();
                    //        GridView3.DataBind();
                    //    }
                    //}

                    //else if (Session["StrTranType"].ToString() == "FI")
                    //{
                    //    Div_Unclosed.Visible = true;
                    //    Div1.Visible = false;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView3.DataSource = dthbl;
                    //        GridView3.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView3.DataSource = new DataTable();
                    //        GridView3.DataBind();
                    //    }
                    //}
                    //else if (Session["StrTranType"].ToString() == "AE")
                    //{
                    //    Div_Unclosed.Visible = false;

                    //    Div1.Visible = true;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView4.DataSource = dthbl;
                    //        GridView4.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView4.DataSource = new DataTable();
                    //        GridView4.DataBind();
                    //    }
                    //}
                    //else if (Session["StrTranType"].ToString() == "AI")
                    //{
                    //    Div_Unclosed.Visible = false;
                    //    Div1.Visible = true;
                    //    dthbl = objClosedJob.GetJobDetailsOpenForNewFE(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    //    if (dthbl.Rows.Count > 0)
                    //    {
                    //        GridView4.DataSource = dthbl;
                    //        GridView4.DataBind();
                    //        ViewState["GridView3"] = dthbl;
                    //    }
                    //    else
                    //    {
                    //        GridView4.DataSource = new DataTable();
                    //        GridView4.DataBind();
                    //    }
                    //}

                    // dthbl = objClosedJob.Getunclosedjobnew(Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), 0);nivedha

                    dthbl = objClosedJob.GetunclosedjobnewWITHRET(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()), 0);

                    Div_Unclosed.Visible = true;
                    Div1.Visible = false;

                    dttemp.Columns.Add("shortname");
                    dttemp.Columns.Add("Product");
                    dttemp.Columns.Add("jobno");
                    dttemp.Columns.Add("etd");
                    dttemp.Columns.Add("income");
                    dttemp.Columns.Add("expense");
                    dttemp.Columns.Add("retention");
                    dttemp.Columns.Add("Branchid");
                    dttemp.Columns.Add("MBL");
                    dttemp.Columns.Add("BL");
                    dttemp.Columns.Add("Shipper");
                    dttemp.Columns.Add("Consignee");
                    dttemp.Columns.Add("POL");
                    dttemp.Columns.Add("POD");
                    dttemp.Columns.Add("CustomerName");
                    dttemp.Columns.Add("Salesperson");
                    dttemp.Columns.Add("PreparedBy");
                    dttemp.Columns.Add("vessel");
                    dttemp.Columns.Add("ETA");
                    dttemp.Columns.Add("ETD1");

                    DataRow dr;

                    for (int i = 0; i <= dthbl.Rows.Count - 1; i++)
                    {

                        if (dthbl.Rows[i]["trantype"].ToString() == Session["StrTranType"].ToString() && Convert.ToInt32(dthbl.Rows[i]["bid"].ToString()) == Convert.ToInt32(Session["LoginBranchid"].ToString()))
                        {
                            dr = dttemp.NewRow();
                            value = dthbl.Rows[i]["jobno"].ToString();
                            sp_job = value.Split('-');
                            product = sp_job[1];

                            if (product == "FE")
                            {
                                product = "OE";
                            }
                            else if (product == "FI")
                            {
                                product = "OI";
                            }

                            job = Convert.ToInt32(sp_job[2]);
                            dr["shortname"] = dthbl.Rows[i]["shortname"].ToString();
                            dr["Product"] = product;
                            dr["jobno"] = value;
                            dr["etd"] = dthbl.Rows[i]["jobdate"].ToString();
                            dr["income"] = dthbl.Rows[i]["income"].ToString();
                            dr["expense"] = dthbl.Rows[i]["expense"].ToString();
                            dr["retention"] = dthbl.Rows[i]["retention"].ToString();
                            dr["Branchid"] = dthbl.Rows[i]["bid"].ToString();
                            dr["MBL"] = dthbl.Rows[i]["MBL"].ToString();
                            dr["BL"] = dthbl.Rows[i]["BL"].ToString();
                            dr["Shipper"] = dthbl.Rows[i]["Shipper"].ToString();
                            dr["Consignee"] = dthbl.Rows[i]["Consignee"].ToString();
                            dr["POL"] = dthbl.Rows[i]["POL"].ToString();
                            dr["POD"] = dthbl.Rows[i]["POD"].ToString();
                            dr["CustomerName"] = dthbl.Rows[i]["customername"].ToString();
                            dr["Salesperson"] = dthbl.Rows[i]["Salesperson"].ToString();
                            dr["vessel"] = dthbl.Rows[i]["vessel"].ToString();
                            dr["ETA"] = dthbl.Rows[i]["ETA"].ToString();
                            dr["ETD1"] = dthbl.Rows[i]["ETD1"].ToString();
                            dr["PreparedBy"] = dthbl.Rows[i]["PreparedBy"].ToString();
                            dttemp.Rows.Add(dr);
                        }

                    }

                    if (dttemp.Rows.Count > 0)
                    {
                        GridView3.DataSource = dttemp;
                        GridView3.DataBind();
                        ViewState["GridView3"] = dttemp;
                        //lbl_unclose.Text = Unclose_Job.InnerText + " BL Wise Unclosed Jobs -" + dttemp.Rows.Count;
                        // lbl_unclose.Text = Unclose_Job.InnerText + " No of BL(S) " + dttemp.Rows.Count;
                        lbl_unclose.Text = Unclose_Job.InnerText + " No of Job(S) " + objClosedJob.getopenjobcount(Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginEmpId"])).ToString() + " / No of BL(S) " + dttemp.Rows.Count;

                    }
                    else
                    {
                        GridView3.DataSource = new DataTable();
                        GridView3.DataBind();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView3, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            int index = GridView3.SelectedRow.RowIndex;
            string value = "", jobno;
            string[] sp_job;
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(101, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name1 = GridView3.Rows[index].Cells[2].Text;
                    value = name1;
                    sp_job = value.Split('-');
                    jobno = sp_job[2];

                    // Session["Unclosed"] = "value";
                    //Session["trantype"] = Session["StrTranType"].ToString();
                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                    Session["JobNumber"] = jobno;
                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOMECSP=" + name + "&jobno1=" + jobno);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            else if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(102, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name1 = GridView3.Rows[index].Cells[2].Text;
                    value = name1;
                    sp_job = value.Split('-');
                    jobno = sp_job[2];
                    // Session["Unclosed"] = "value";
                    //Session["trantype"] = Session["StrTranType"].ToString();
                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                    Session["JobNumber"] = jobno;
                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOMECSP=" + name + "&jobno1=" + jobno);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            else if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(103, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name1 = GridView3.Rows[index].Cells[2].Text;
                    value = name1;
                    sp_job = value.Split('-');
                    jobno = sp_job[2];
                    // Session["Unclosed"] = "value";
                    //Session["trantype"] = Session["StrTranType"].ToString();
                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                    Session["JobNumber"] = jobno;
                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOMECSP=" + name + "&jobno1=" + jobno);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            else if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(104, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name1 = GridView3.Rows[index].Cells[2].Text;
                    value = name1;
                    sp_job = value.Split('-');
                    jobno = sp_job[2];
                    // Session["Unclosed"] = "value";
                    //Session["trantype"] = Session["StrTranType"].ToString();
                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                    Session["JobNumber"] = jobno;
                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOMECSP=" + name + "&jobno1=" + jobno);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        //protected override void Render(HtmlTextWriter writer)
        //{
        //    foreach (GridViewRow r in Grd_Approval.Rows)
        //    {
        //        if (r.RowType == DataControlRowType.DataRow)
        //        {
        //            for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
        //            {
        //                Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00", columnIndex.ToString());
        //            }
        //        }
        //    }
        //    base.Render(writer);
        //}

        protected void Grd_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            approval();

        }

        /*public void approval()
        {

            DateTime get_date, GST_date;
            // get_date = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
            get_date = Convert.ToDateTime(Grd_Approval.SelectedRow.Cells[12].Text.ToString());
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());

            string header = "";
            double amount = Convert.ToDouble(Grd_Approval.SelectedRow.Cells[3].Text.ToString());
            if (hid_credit.Value == "")
            {
                hid_credit.Value = "0";
            }

            if (hid_debit.Value == "")
            {
                hid_debit.Value = "0";
            }
            string str_Voucher = "", Str_StrTrantype = "";
            int int_Vouno = 0, int_vouyear = 0;
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";
            string Str_SP1 = "", Str_SF1 = "", Str_SF2 = "", Str_SP2 = "", str_RptName1 = "", str_RptName2 = "", BL = "";
            Str_StrTrantype = Session["StrTranType"].ToString();
            // if (Grd_Approval.SelectedRow.Cells[5].Text == "Transfer")

            if (Str_StrTrantype == "CH")
            {
                return;
            }
            DataTable obj_dt = new DataTable();
            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
            {
                header = "Invoice";
                str_Voucher = "Invoice";
            }
            else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
            {
                header = "PA";
                str_Voucher = "PA";
            }
            else if (hid_type.Value.ToString() == "ProOSDNApproval")
            {
                str_Voucher = "OSSI";
            }
            else
            {
                str_Voucher = "OSPI";
            }

            DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            if (!DBNull.Value.Equals(Grd_Approval.SelectedRow.Cells[0].Text))
            {
                int_Vouno = int.Parse(Grd_Approval.SelectedRow.Cells[0].Text.ToString());
            }
            else
            {
                return;
            }
            int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
            BL = HttpUtility.HtmlDecode(Grd_Approval.SelectedRow.Cells[1].Text.ToString());
            obj_dt = obj_da_invoice.CheckHblno(BL, Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            Fn_Getcontainer(obj_dt, Grd_Approval.SelectedRow.RowIndex);
            if (str_Voucher == "OSSI" || str_Voucher == "OSPI")
            {
                Fn_GetCredit(row);
            }
            string Str_RptName = "", Str_SF = "", Str_SP = "", Str_Script = "";
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            if (obj_dt.Rows.Count > 0)
            {
                if (str_Voucher == "Invoice")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProInvoice.rpt";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProInvoice.rpt";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProInvoice.rpt";
                        Str_SP = "Lcurr=INR ";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }
                    //Session["str_sfs"] = "{InvoiceHead.trantype}='" + Str_StrTrantype + "' and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}=" + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;                   
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    if (get_date >= GST_date)
                    {
                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&trantype=" + Str_StrTrantype + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);

                    Session["str_sp"] = Str_SP;
                }
                if (str_Voucher == "PA")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}='" + Str_StrTrantype + "' and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}='" + Str_StrTrantype + "' and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}='" + Str_StrTrantype + "' and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}='" + Str_StrTrantype + "' and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}='" + Str_StrTrantype + "' and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }

                    Str_SP = "Lcurr=INR";
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                    Session["str_sp"] = Str_SP;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                }
            }
            else
            {

                if (str_Voucher == "Invoice")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}='" + Str_StrTrantype + "' and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}='" + Str_StrTrantype + "' and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}='" + Str_StrTrantype + "' and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR ";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}='" + Str_StrTrantype + "' and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}='" + Str_StrTrantype + "' and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}='" + Str_StrTrantype + "' and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1054, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                }
                if (str_Voucher == "PA")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    Session["str_sfs"] = "{PAHead.trantype}='" + Str_StrTrantype + "' and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    Str_SP = "Lcurr=INR";
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1055, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                }

                string str_curr = "";
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                if (str_Voucher == "OSSI")
                {
                    int int_jobno = int.Parse(Grd_Approval.SelectedRow.Cells[1].Text.ToString());

                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;                      
                       
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                      
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                      
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                        //Session["str_sp"] = Str_SP;
                      
                    }

                    /*if (Str_StrTrantype == "FE")
                    {
                        str_RptName1 = "FEProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;

                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                       
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 40, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        str_RptName1 = "FIProOSDN.rpt";
                        //  Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 41, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        str_RptName1 = "AEProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";

                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 42, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else
                    {
                        str_RptName1 = "AIProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                     
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 43, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }

                }
                if (str_Voucher == "OSPI")
                {
                    int int_jobno = int.Parse(Grd_Approval.SelectedRow.Cells[1].Text.ToString());

                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); 
                     
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                       
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                      
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                       
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }

                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                      
                    }

                    /*if (Str_StrTrantype == "FE")
                    {

                        str_RptName1 = "FEProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                    
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 40, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        str_RptName1 = "FIProOSCN.rpt";
                        //  Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();

                        //Session["str_sfs2"] = Str_SF2;
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');

                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 41, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        str_RptName1 = "AEProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 42, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else
                    {
                        str_RptName1 = "AIProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();

                        //Session["str_sfs2"] = Str_SF2;                    
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 43, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    btn_delete.Visible = false;btn_delete_id.Visible = false;
                    return;
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                btn_delete.Visible = false;btn_delete_id.Visible = false;
            }
            // UserRights();
        }
        */

        public void approval()
        {

            DateTime get_date, GST_date;
            // get_date = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
            get_date = Convert.ToDateTime(Grd_Approval.SelectedRow.Cells[21].Text.ToString());       //NewOne       //22/07/2022
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            DataTable dcon = Appobj.Checkcountry(int.Parse(Session["LoginBranchid"].ToString()));
            int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
            string header = "";
            double amount = Convert.ToDouble(Grd_Approval.SelectedRow.Cells[7].Text.ToString());
            if (hid_credit.Value == "")
            {
                hid_credit.Value = "0";
            }

            if (hid_debit.Value == "")
            {
                hid_debit.Value = "0";
            }
            string str_Voucher = "", Str_StrTrantype = "";
            int int_Vouno = 0, int_vouyear = 0;
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";
            string Str_SP1 = "", Str_SF1 = "", Str_SF2 = "", Str_SP2 = "", str_RptName1 = "", str_RptName2 = "", BL = "";
            Str_StrTrantype = Session["StrTranType"].ToString();
            // if (Grd_Approval.SelectedRow.Cells[5].Text == "Transfer")

            if (Str_StrTrantype == "CH")
            {
                return;
            }
            DataTable obj_dt = new DataTable();
            hid_voutype.Value = Grd_Approval.SelectedRow.Cells[1].Text.ToString();
            if (hid_voutype.Value.ToString() == "SALES INVOICE")
            {
                header = "Invoice";
                str_Voucher = "Invoice";
            }
            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
            {
                header = "PA";
                str_Voucher = "PA";
            }
            else if (hid_voutype.Value.ToString() == "OSSI")
            {
                str_Voucher = "OSSI";
            }
            else if (hid_voutype.Value.ToString() == "SALES INVOICE OC")
            {
                header = "Invoice FC";
                str_Voucher = "Invoice FC";
            }

            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
            {
                header = "PA FC";
                str_Voucher = "PA FC";
            }
            else
            {
                str_Voucher = "OSPI";
            }

            //DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            if (!DBNull.Value.Equals(Grd_Approval.SelectedRow.Cells[2].Text))
            {
                int_Vouno = int.Parse(Grd_Approval.SelectedRow.Cells[2].Text.ToString());
            }
            else
            {
                return;
            }
            int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
            BL = HttpUtility.HtmlDecode(Grd_Approval.SelectedRow.Cells[4].Text.ToString());
            obj_dt = obj_da_invoice.CheckHblno(BL, Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            Fn_Getcontainer(obj_dt, Grd_Approval.SelectedRow.RowIndex);
            if (str_Voucher == "OSSI" || str_Voucher == "OSPI")
            {
                Fn_GetCredit(Grd_Approval.SelectedRow.RowIndex);
            }
            string Str_RptName = "", Str_SF = "", Str_SP = "", Str_Script = "";
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            if (obj_dt.Rows.Count > 0)
            {
                if (str_Voucher == "Invoice")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProInvoice.rpt";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProInvoice.rpt";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProInvoice.rpt";
                        Str_SP = "Lcurr=INR ";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }

                    Str_SF = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\"  and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}=" + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    if (get_date >= GST_date)
                    {
                        if(con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1"+ "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }

                        // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&trantype=" + Str_StrTrantype + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);

                    Session["str_sp"] = Str_SP;
                }
                else   if (str_Voucher == "Invoice FC")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProInvoice.rpt";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProInvoice.rpt";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProInvoice.rpt";
                        Str_SP = "Lcurr=INR ";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }

                    Str_SF = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\"  and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}=" + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    if (get_date >= GST_date)
                    {
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }

                        // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&trantype=" + Str_StrTrantype + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);

                    Session["str_sp"] = Str_SP;
                }
                if (str_Voucher == "PA")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }

                    Str_SP = "Lcurr=INR";
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                        // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                    Session["str_sp"] = Str_SP;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                }

                if (str_Voucher == "PA FC")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }

                    Str_SP = "Lcurr=INR";
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                        // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                    Session["str_sp"] = Str_SP;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                }
            }
            else
            {

                if (str_Voucher == "Invoice")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //   Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR ";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                    }
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1054, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                }

                //

                if (str_Voucher == "Invoice FC")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //   Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR ";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        if (con == 1102 || con == 102)
                        {
                            Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                        else
                        {
                            Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                        }
                    }
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1054, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                }
                //
                if (str_Voucher == "PA FC")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }

                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    Str_SP = "Lcurr=INR";
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1055, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                }
                if (str_Voucher == "PA")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            // Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }

                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            if (con == 1102 || con == 102)
                            {
                                Str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            else
                            {
                                Str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                            }
                            //  Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    Str_SP = "Lcurr=INR";
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1055, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                }

                string str_curr = "";
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                if (str_Voucher == "OSSI")
                {
                    int int_jobno = int.Parse(Grd_Approval.SelectedRow.Cells[4].Text.ToString());

                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;

                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {

                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                        //Session["str_sp"] = Str_SP;

                    }

                    /*if (Str_StrTrantype == "FE")
                    {
                        str_RptName1 = "FEProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;

                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                       
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 40, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        str_RptName1 = "FIProOSDN.rpt";
                        //  Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 41, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        str_RptName1 = "AEProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";

                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 42, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else
                    {
                        str_RptName1 = "AIProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                     
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 43, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }*/

                }
                if (str_Voucher == "OSPI")
                {
                    int int_jobno = int.Parse(Grd_Approval.SelectedRow.Cells[4].Text.ToString());

                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());

                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }

                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }

                    /*if (Str_StrTrantype == "FE")
                    {

                        str_RptName1 = "FEProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                    
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 40, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        str_RptName1 = "FIProOSCN.rpt";
                        //  Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();

                        //Session["str_sfs2"] = Str_SF2;
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');

                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 41, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        str_RptName1 = "AEProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 42, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else
                    {
                        str_RptName1 = "AIProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();

                        //Session["str_sfs2"] = Str_SF2;                    
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 43, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    */

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    btn_delete.Visible = false;btn_delete_id.Visible = false;
                    return;
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                btn_delete.Visible = false;btn_delete_id.Visible = false;
            }
            dt = Dobj.cnops_reportview(Grd_Approval.SelectedRow.Cells[2].Text.ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString());

            string Download = "";
            string refno = "";
            string Str_Script1 = "";
            if (dt.Rows.Count > 0)
            {
                Download = dt.Rows[0]["fileloc"].ToString();
                refno = dt.Rows[0]["refno"].ToString();
            }
            if (Grd_Approval.SelectedRow.Cells[2].Text.ToString() == refno)
            {
                if (Download != "")
                {
                    ScriptManager.RegisterStartupScript(Grd_Approval, typeof(GridView), "Download", "window.open('../Download.aspx?Document=" + Download + "');", true);
                    //   Str_Script1 = "window.open('../Download.aspx?Document=" + Download + "&" + this.Page.ClientQueryString + "','','');";
                    // Str_Script = Str_Script + ";" + Str_Script1;

                    //  ScriptManager.RegisterStartupScript(Grd_Doc, typeof(GridView), "Download", "window.open('../Download.aspx?Reference=" + Download + "');", true);
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
            btn_delete.Visible = false; btn_delete_id.Visible = false;
            // UserRights();
        }

        private void Fn_Getcontainer(DataTable dt, int int_Rowindex)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string Str_sblno = "";
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                    {
                        Str_sblno = dt.Rows[0]["blno"].ToString();
                    }
                    else
                    {
                        Str_sblno = dt.Rows[0]["hawblno"].ToString();
                    }
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                    {
                        if (Grd_Approval.Rows[int_Rowindex].Cells[4].Text.ToString().Trim().Length > 0)
                        {
                            if (Grd_Approval.Rows[int_Rowindex].Cells[4].Text.ToString() == Str_sblno)
                            {
                                //DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
                                DataTable obj_dt = new DataTable();

                                obj_dt = obj_da_invoice.GetHBLContainerDtls(Str_sblno, Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
                                if (obj_dt.Rows.Count > 0)
                                {
                                    var obj_Container = (from r in obj_dt.AsEnumerable()
                                                         select r.Field<string>("containerno"));
                                    hid_container.Value = string.Join("-", obj_Container);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        private void Fn_GetCredit(int int_Rowindex)
        {
            try
            {
                //DataAccess.Accounts.OSDNCN obj_da_invoice = new DataAccess.Accounts.OSDNCN();
                DataSet obj_ds = new DataSet();

                obj_ds = obj_da_invoice2.RptOSDNCNProFromJobNo(Session["StrTranType"].ToString(), int.Parse(Grd_Approval.Rows[int_Rowindex].Cells[4].Text.ToString()), int.Parse(Session["LoginBranchid"].ToString()));

                if (obj_ds.Tables.Count > 1)
                {
                    hid_debit.Value = (obj_ds.Tables[1].Rows.Count > 0 ? obj_ds.Tables[2].Rows.Count : 0).ToString();
                    hid_credit.Value = (obj_ds.Tables[2].Rows.Count > 0 ? obj_ds.Tables[2].Rows.Count : 0).ToString();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        /*protected void btn_transfer_Click(object sender, EventArgs e)
        {
            try
            {
                int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
                string Str_Trantype = Session["StrTranType"].ToString(), Str_invoiceno = "";
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                string StrScript = "";
                int countinv = 0;
                DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
                if (hid_type.Value.ToString() == "Transfer To Commercial Invoice" || hid_type.Value.ToString() == "Transfer To Commercial PA")
                {

                    foreach (GridViewRow row in Grd_Approval.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                        if (Chk.Checked == true)
                        {
                            countinv = 1;
                            int_Invoiceno = obj_da_Approval.GetNoforAcForApproval(int_bid, hid_type.Value.ToString());
                            int_Refno = Convert.ToInt32(row.Cells[0].Text.ToString());
                            int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
                            hid_stamt.Value = row.Cells[7].Text.ToString();
                            hid_supplyto.Value = row.Cells[8].Text.ToString();
                            string emp = row.Cells[4].Text.ToString();
                            int empp = employeeobj.GetNEmpid(emp);
                            if (empp == int_Empid)
                            {
                                StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                continue;
                            }

                            Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmt(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                            if (Dtckeck.Rows.Count > 0)
                            {
                                StrScript += "Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                continue;

                            }

                            if (Session["hid_gstdate"] != null)
                            {
                                if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
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
                                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                                                {

                                                }

                                            }
                                            else
                                            {
                                                StrScript += "State Name not Updated in Master Kindly update Master Customer";

                                                continue;
                                            }

                                        }

                                    }
                                    else
                                    {
                                        StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;

                                        continue;
                                    }
                                }
                            }

                            obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());
                            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {//raj
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", "");
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());
                                        DateTime date_Voudate = DateTime.Parse(obj_dt.Rows[0].ItemArray[1].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Invoices", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'I', int_Vouyear, int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                      }
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1016, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1023, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1030, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1037, 1, int_bid, int_Refno.ToString());
                                        break;
                                    case "CH":
                                        obj_da_Log.InsLogDetail(int_Empid, 1043, 1, int_bid, int_Refno.ToString());
                                        break;

                                }
                            }
                            else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, int_Refno.ToString());
                                        break;
                                    case "CH":
                                        obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, int_Refno.ToString());
                                        break;

                                }
                            }
                            /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                             {//raj
                                 // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                 try
                                 {
                                     obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                     if (obj_dt.Rows.Count > 0)
                                     {
                                         int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                         DateTime date_Voudate = DateTime.Parse((obj_dt.Rows[0]["dndate"].ToString()));
                                         string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                         double amount = double.Parse(row.Cells[3].Text.ToString());
                                         double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                         int int_Ledgerid = 0;
                                         int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                         int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Session["FADbname"].ToString());
                                         if (int_Ledgerid == 0)
                                         {
                                             int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                         }
                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                 }
                                 switch (Session["StrTranType"].ToString())
                                 {
                                     case "FE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "FI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "AE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "AI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString());
                                         break;

                                 }
                             }
                             else if (hid_type.Value.ToString() == "ProOSCNApproval")
                             {//raj
                                 // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                 try
                                 {
                                     obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                     if (obj_dt.Rows.Count > 0)
                                     {
                                         int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                         DateTime date_Voudate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[0]["cndate"].ToString()));
                                         string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                         double amount = double.Parse(row.Cells[3].Text.ToString());
                                         double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                         int int_Ledgerid = 0;
                                         int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                         int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Session["FADbname"].ToString());
                                         if (int_Ledgerid == 0)
                                         {
                                             int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                         }
                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                 }
                                 switch (Session["StrTranType"].ToString())
                                 {
                                     case "FE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "FI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "AE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "AI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString());
                                         break;

                                 }
                             }
                            Str_invoiceno = Str_invoiceno + int_Invoiceno.ToString() + ",";

                        }
                        //else if (countinv != 1)
                        //{

                        //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        //    return;
                        //}
                    }
                    if (countinv != 1)
                    {

                        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        return;
                    }
                    if (Str_invoiceno.Length > 0)
                    {
                        Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                        if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                        {

                            StrScript += "Invoice # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                        {
                            StrScript += "CN-Ops # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial CN")
                        {
                            StrScript += "CN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial DN")
                        {
                            StrScript += "DN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                         {
                             StrScript = "OSDN # " + Str_invoiceno + " Generated and Transfered";
                         }
                         else if (hid_type.Value.ToString() == "ProOSCNApproval")
                         {
                             StrScript = "OSCN # " + Str_invoiceno + " Generated and Transfered";
                         }

                    }
                    // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert(" + StrScript + ");", true);
                }
                else if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                {
                    foreach (GridViewRow row in Grd_Approval.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                        if (Chk.Checked == true)
                        {
                            countinv = 1;
                            int_Refno = int.Parse(row.Cells[0].Text.ToString());
                            int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
                            // dcno = Approveobj.UpdProApprovalOSDCN(refno, strblno, Login.logempid, strTranType, vouyear, branchid, strFType)
                            hid_stamt.Value = row.Cells[7].Text.ToString();
                            hid_supplyto.Value = row.Cells[8].Text.ToString();
                            string emp = row.Cells[4].Text.ToString();
                            int empp = employeeobj.GetNEmpid(emp);
                            if (empp == int_Empid)
                            {
                                StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                continue;
                            }

                            if (Session["hid_gstdate"] != null)
                            {
                                if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
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
                                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                                                {

                                                }
                                                else
                                                {
                                                    StrScript += "State Name not Updated in Master Kindly update Master Customer ";

                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                StrScript += "State Name not Updated in Master Kindly update Master Customer";

                                                continue;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;

                                        continue;
                                    }
                                }
                            }

                            int_intdcno = obj_da_Approval.UpdProApprovalOSDCN(int_Refno, int.Parse(row.Cells[1].Text.ToString()), int_Empid, Str_Trantype, int_Vouyear, int_bid, hid_type.Value.ToString());
                            if (hid_type.Value.ToString() == "ProOSDNApproval")
                            {//raj
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                        DateTime date_Voudate = DateTime.Parse((obj_dt.Rows[0]["dndate"].ToString()));
                                        string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                        double amount = double.Parse(row.Cells[3].Text.ToString());
                                        double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                      }
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString());
                                        break;

                                }
                            }
                            else if (hid_type.Value.ToString() == "ProOSCNApproval")
                            {//raj
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                        DateTime date_Voudate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[0]["cndate"].ToString()));
                                        string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                        double amount = double.Parse(row.Cells[3].Text.ToString());
                                        double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                     }
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString());
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString());
                                        break;

                                }
                            }
                            if (int_intdcno != 0)
                            {
                                Str_invoiceno = Str_invoiceno + int_intdcno.ToString() + ",";
                            }
                            else
                            {
                                StrScript += "OSDN # or OSCN # Not Generated and Transfered";

                            }

                        }

                    }
                    if (countinv != 1)
                    {

                        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        return;
                    }
                    if (Str_invoiceno.Length > 0)
                    {
                        Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                        // string StrScript = "";
                        if (hid_type.Value.ToString() == "ProOSDNApproval")
                        {
                            StrScript += "OSDN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "ProOSCNApproval")
                        {
                            StrScript += "OSCN # " + Str_invoiceno + " Generated and Transfered";
                        }

                    }
                }
                Fn_Getdetail();
                //if (Str_invoiceno.Length > 0)
                //{
                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                //}
                // UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_delete.Visible = false;btn_delete_id.Visible = false;

        }*/
        /* protected void btn_transfer_Click(object sender, EventArgs e)
         {
             try
             {
                 string type = "";
                 int invoinumber = 0;
                 string str_favourname = "";
                 DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
                 int int_osdncn = 0;
                 DataTable dtosdn = new DataTable();
                 DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                 string cutname = "";
                 // DataSet dsosdn=new DataSet();
                 int jobnoosdn = 0;
                 int gsttype = 0, statename = 0, supplyto = 0, int_osdncn1 = 0, int_TDS=0;
                 string gsttype_ = "", statename_ = "", supplyto_ = "", str_osdncn1 = "", str_TDS="";
                 int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
                 string Str_Trantype = Session["StrTranType"].ToString(), Str_invoiceno = "", Str_invoicenonew = ""; 
                 int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                 int_bid = int.Parse(Session["LoginBranchid"].ToString());
                 int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                 DataTable obj_dt = new DataTable();
                 string StrScript = "";
                 int countinv = 0;
                 double st_amt = 0.0;
                 double Amount = 0, TDS = 0, TDSAmount = 0, CSTAmount = 0, gstamt=0;
                 DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                 DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                 DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                 DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                 DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                 DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
                 DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                 int int_Custid=0;
                 TextBox Txt=new TextBox();

                 string tdstype="", tdsdesc="";
                 string str_tdstype = "",str_tdsdesc="";
                 int int_tdstype = 0, int_tdsdesc=0;
                 if (hid_type.Value.ToString() == "Transfer To Commercial Invoice" || hid_type.Value.ToString() == "Transfer To Commercial PA")
                 {

                     foreach (GridViewRow row in Grd_Approval.Rows)
                     {

                         type = Grd_Approval.Rows[row.RowIndex].Cells[13].Text;
                         string str_Voutype = type;
                         bool ChkLedger = true;
                         CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                      
                         if (Chk.Checked == true)
                         {
                             int_Refno = Convert.ToInt32(row.Cells[0].Text.ToString());
                             countinv = 1;
                             if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                             {
                                 Txt = (TextBox)Grd_Approval.Rows[row.RowIndex].FindControl("TDSPERS");
                                 if (Txt.Text.Trim().Length == 0)
                                 {
                                     //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "TDS", "alertify.alert('Enter TDS%');", true);
                                     if (int_TDS == 0)
                                     {
                                         str_TDS = "Enter TDS% for Ref number is " + int_Refno;
                                        
                                     }
                                     else
                                     {
                                         str_TDS  = str_TDS+ ","  + int_Refno;
                                     }
                                     Txt.Focus();
                                     int_TDS = 1;
                                     continue;

                                 }
                                 else
                                 {
                                     tdstype = row.Cells[5].Text.ToString();
                                     tdsdesc = row.Cells[6].Text.ToString();
                                     if (tdstype == "" && tdstype == "")
                                     {
                                         if (int_tdstype == 0)
                                         {
                                             str_tdstype  = "TDS Type is Empty && TDS DESC is Empty for Ref number is " + int_Refno;
                                           
                                         }
                                         else
                                         {
                                             str_tdstype =  str_tdstype + ","+ int_Refno;
                                         }
                                         Txt.Focus();
                                         int_tdstype = 1;
                                         continue;
                                     }
                                     else if (tdstype == "")
                                     {
                                         if (int_tdstype == 0)
                                         {
                                             str_tdstype = "TDS Type is Empty for Ref number is " + int_Refno;
                                            
                                         }
                                         else
                                         {
                                             str_tdstype  = str_tdstype +","+ int_Refno;
                                         }
                                         Txt.Focus();
                                         int_tdstype = 1;
                                         continue;
                                     }

                                     else if (tdsdesc=="")
                                     {
                                         if (int_tdsdesc == 0)
                                         {
                                             str_tdsdesc = "TDS DESC is Empty for Ref number is " + int_Refno;
                                            
                                         }
                                         else
                                         {
                                             str_tdsdesc  = str_tdsdesc + ","+ int_Refno;
                                         }
                                         Txt.Focus();
                                         int_tdsdesc = 1;
                                         continue;
                                     }
                                    
                                 }
                             }

                             int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
                             //hid_stamt.Value = row.Cells[7].Text.ToString();
                             //hid_supplyto.Value = row.Cells[8].Text.ToString();
                             hid_stamt.Value = row.Cells[10].Text.ToString();
                             hid_supplyto.Value = row.Cells[11].Text.ToString();
                             if (hid_supplyto.Value != "0")
                             {
                                 cutname = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                             }
                             string emp = row.Cells[4].Text.ToString();
                             int empp = employeeobj.GetNEmpid(emp);
                             //if (empp == int_Empid)
                             //{
                             //    StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                             //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                             //    continue;
                             //}

                             Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmt(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                             if (Dtckeck.Rows.Count > 0)
                             {
                                 StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice";
                                 //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                 continue;

                             }
                             if (Session["hid_gstdate"] != null)
                             {
                                 if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                                 {

                                     if (hid_supplyto.Value != "0")
                                     {

                                         if (Convert.ToDouble(hid_stamt.Value) > 0)
                                         {

                                             int int_custidnew;
                                             DataTable dt_list = new DataTable();
                                             DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                             //int int_custid = Convert.ToInt32(hdncustid.Value);
                                             if (!string.IsNullOrEmpty(row.Cells[11].Text.ToString()))
                                             {
                                                 int_custidnew = Convert.ToInt32(row.Cells[11].Text.ToString());
                                                 dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                             }

                                             if (dt_list.Rows.Count > 0)
                                             {
                                                 if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                                 {
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
                                                 //StrScript += "State Name not Updated in Master Kindly update Master Customer for" + row.Cells[2].Text.ToString();
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
                                         //StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;
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

                             string inapproved = obj_da_Approval.CHKVoucherbos(int_Refno);
                             if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                             {
                                 if (inapproved.ToString() == "TRUE")
                                 {
                                     invoinumber = obj_da_Approval.UpdProApprovalnewbos(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);

                                     if (invoinumber != 0)
                                     {
                                         Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                                     }
                                     else
                                     {
                                         Str_invoicenonew = "Invoice not Approved";
                                     }
                                 }
                             }
                             int_Invoiceno = obj_da_Approval.GetNoforAcForApproval(int_bid, hid_type.Value.ToString());                           
                            
                             obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());
                             if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                             {

                                 int_Custid = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[1].ToString());
                                Amount = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[3].Text.ToString()));
                                 gstamt = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[10].Text.ToString()));
                                 Amount = Amount - gstamt;
                                 TDS = double.Parse(Txt.Text.ToString());

                                 TDSAmount = Amount * (TDS / 100); 
                                 CSTAmount = Amount - TDSAmount;                              

                                 if (str_Voutype == "S")
                                 {
                                     obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Invoiceno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear);
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
                                 string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";
                                 if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                 {
                                     str_Voutype = "P";              //CN-OPS  -->P  //Admin-CN-->S//  Other-CN-->E
                                     type = "P";
                                 }

                                 CheckBox Chkrcm = (CheckBox)row.FindControl("Chk_rcm"); // For RCM
                                 if (Chkrcm.Checked == true)
                                 {
                                    
                                     if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                     {
                                         obj_da_Invoice.inspaheadgsttype("R", int_Invoiceno, int_bid, int_Vouyear, "P");
                                         switch (Session["StrTranType"].ToString())
                                         {
                                             case "FE":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                                 break;
                                             case "FI":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                                 break;
                                             case "AE":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                                 break;
                                             case "AI":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                                 break;
                                             case "CH":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                                 break;
                                             case "BT":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1053, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                                 break;
                                         }
                                     }
                                 }
                                 else if (Chkrcm.Checked == false)
                                 {
                                     if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                     {
                                         switch (Session["StrTranType"].ToString())
                                         {
                                             case "FE":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                                 break;
                                             case "FI":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                                 break;
                                             case "AE":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                                 break;
                                             case "AI":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                                 break;
                                             case "CH":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                                 break;
                                             case "BT":
                                                 obj_da_Log.InsLogDetail(int_Empid, 1053, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                                 break;
                                         }
                                     }
                                 }

                                 if (ChkLedger == true)
                                 {
                                     obj_da_Invoice.InsertPATDS(int_Invoiceno, str_Voutype, int.Parse(Session["LoginBranchid"].ToString()), int_Custid, int_Vouyear, CSTAmount, TDSAmount);

                                     //if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                     // {
                                     //     str_Voutype="P";
                                     //     type = "P";
                                     // }

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

                                     logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Invoiceno, int_Invoiceno, Str_ddlNarration, Str_ddlReference);

                                     int int_Ledgerid = 0;
                                     int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Session["FADbname"].ToString());
                                     int_Voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_ddlVoucherType, Session["FADbname"].ToString());
                                     if (int_Ledgerid == 0)
                                     {
                                         int_Ledgerid = Fn_Getcustomergroupid(int_Custid, Str_ddlVoucherType);
                                     }
                                     //DateTime dtdate = DateTime.Parse(Utility.fn_ConvertDate(Grd_Approval.Rows[row.RowIndex].Cells[12].Text));
                                     DateTime dtdate = DateTime.Parse((Grd_Approval.Rows[row.RowIndex].Cells[12].Text));
                                     string Str_CustType = obj_da_Customer.GetCustomerType(int_Custid);
                                     if (Str_CustType == "P" || Str_CustType == "E")
                                     {
                                         DataTable dt = new DataTable();
                                         dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "CNHead", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()));
                                         string Str_Curr = "";
                                         double F_Curr = 0;
                                         if (dt.Rows.Count > 0)
                                         {
                                             Str_Curr = dt.Rows[0]["curr"].ToString();
                                             F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                         }
                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, Str_Curr, F_Curr, int_Custid);
                                     }
                                     else
                                     {

                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, "", 0, int_Custid);
                                     }
                                 }

                                 str_favourname=row.Cells[2].Text.ToString();
                                 obj_da_Cheque.UpdChequeRequest(int_Invoiceno, int.Parse(Session["Vouyear"].ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int_Empid, "PA", char.Parse("C"), "", str_favourname);

                             }

                             if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                             {//raj
                                 logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", "");

                                 if (inapproved.ToString() == "TRUE")
                                 {
                                     /*if (Str_invoicenonew != "")
                                     {
                                         string[] d2 = Str_invoicenonew.Split(',');
                                     
                                         int n1=0;
                                         if (invoinumber != 0)
                                         {                                                                                 
                                            for(n1=0;n1<d2.Count();n1++)
                                            {
                                              logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", Convert.ToInt32(d2[n1].ToString()), Convert.ToInt32(d2[n1].ToString()), "Vessel/Voyage/Container", "BL No", "");
                                            }
                                         }
                                      
                                         else
                                         {
                                             Str_invoicenonew = "Invoice not Approved";
                                         }
                                     }

                                     if (invoinumber != 0)
                                     {
                                         logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "");
                                     }
                                 }
                                 string retransfer = "N";
                                 if (Session["vouid"] != null)
                                 {

                                     retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Session["FADbname"].ToString());

                                     if (retransfer == "Y")
                                     {
                                         logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", "");

                                     }
                                     Session["vouid"] = null;

                                 }
                                 try
                                 {
                                     obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                     if (obj_dt.Rows.Count > 0)
                                     {
                                         int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());
                                         DateTime date_Voudate = DateTime.Parse(obj_dt.Rows[0].ItemArray[1].ToString());
                                         int int_Ledgerid = 0;
                                         int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                         int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Invoices", Session["FADbname"].ToString());
                                         if (int_Ledgerid == 0)
                                         {
                                             int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                         }
                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'I', int_Vouyear, int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0, int_custid);
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                      }
                                 switch (Session["StrTranType"].ToString())
                                 {
                                     case "FE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1016, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;

                                     case "FI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1023, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;

                                     case "AE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1030, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;

                                     case "AI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1037, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;
                                     case "CH":
                                         obj_da_Log.InsLogDetail(int_Empid, 1043, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;

                                 }
                             }
                             else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                             {
                                 switch (Session["StrTranType"].ToString())
                                 {
                                     case "FE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;

                                     case "FI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;

                                     case "AE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;

                                     case "AI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;
                                     case "CH":
                                         obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                         break;

                                 }
                             }
                             /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                              {//raj
                                  // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                  try
                                  {
                                      obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                      if (obj_dt.Rows.Count > 0)
                                      {
                                          int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                          DateTime date_Voudate = DateTime.Parse((obj_dt.Rows[0]["dndate"].ToString()));
                                          string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                          double amount = double.Parse(row.Cells[3].Text.ToString());
                                          double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                          int int_Ledgerid = 0;
                                          int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                          int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Session["FADbname"].ToString());
                                          if (int_Ledgerid == 0)
                                          {
                                              int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                          }
                                          obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                      }
                                  }
                                  catch (Exception ex)
                                  {
                                  }
                                  switch (Session["StrTranType"].ToString())
                                  {
                                      case "FE":
                                          obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString());
                                          break;

                                      case "FI":
                                          obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString());
                                          break;

                                      case "AE":
                                          obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString());
                                          break;

                                      case "AI":
                                          obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString());
                                          break;

                                  }
                              }
                              else if (hid_type.Value.ToString() == "ProOSCNApproval")
                              {//raj
                                  // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                  try
                                  {
                                      obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                      if (obj_dt.Rows.Count > 0)
                                      {
                                          int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                          DateTime date_Voudate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[0]["cndate"].ToString()));
                                          string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                          double amount = double.Parse(row.Cells[3].Text.ToString());
                                          double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                          int int_Ledgerid = 0;
                                          int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                          int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Session["FADbname"].ToString());
                                          if (int_Ledgerid == 0)
                                          {
                                              int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                          }
                                          obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                      }
                                  }
                                  catch (Exception ex)
                                  {
\                                  }
                                  switch (Session["StrTranType"].ToString())
                                  {
                                      case "FE":
                                          obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString());
                                          break;

                                      case "FI":
                                          obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString());
                                          break;

                                      case "AE":
                                          obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString());
                                          break;

                                      case "AI":
                                          obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString());
                                          break;

                                  }
                              }
                             Str_invoiceno = Str_invoiceno + int_Invoiceno.ToString() + ",";

                         }
                         //else if (countinv != 1)
                         //{

                         //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                         //    return;
                         //}
                     }
                    
                     if (Str_invoiceno.Length > 0)
                     {
                         Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                         if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                         {

                             StrScript += "Invoice # " + Str_invoiceno + " Generated and Transfered";
                         }
                         else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                         {
                             StrScript += "CN-Ops # " + Str_invoiceno + " Generated and Transfered";
                         }
                         else if (hid_type.Value.ToString() == "Transfer To Commercial CN")
                         {
                             StrScript += "CN # " + Str_invoiceno + " Generated and Transfered";
                         }
                         else if (hid_type.Value.ToString() == "Transfer To Commercial DN")
                         {
                             StrScript += "DN # " + Str_invoiceno + " Generated and Transfered";
                         }

                         /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                          {
                              StrScript = "OSDN # " + Str_invoiceno + " Generated and Transfered";
                          }
                          else if (hid_type.Value.ToString() == "ProOSCNApproval")
                          {
                              StrScript = "OSCN # " + Str_invoiceno + " Generated and Transfered";
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

                     if (int_TDS==1)
                     {
                         StrScript += " " + str_TDS;
                     }

                     if (int_tdstype == 1)
                     {
                         StrScript += " " + str_tdstype;
                     }

                     if (int_tdsdesc == 1)
                     {
                         StrScript += " " + str_tdsdesc;
                     }
                     if (countinv != 1)
                     {

                         StrScript += "Check Atleast One Ref#";
                         //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                         //return;
                     }

                     if (invoinumber != 0)
                     {
                        // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                         StrScript += " " + Str_invoicenonew;
                     }

                     // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert(" + StrScript + ");", true);
                 }
                 else if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                 {
                     foreach (GridViewRow row in Grd_Approval.Rows)
                     {
                         CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                         if (Chk.Checked == true)
                         {
                             countinv = 1;
                             int_Refno = int.Parse(row.Cells[0].Text.ToString());
                             jobnoosdn = int.Parse(row.Cells[1].Text.ToString());
                             int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
                             // dcno = Approveobj.UpdProApprovalOSDCN(refno, strblno, Login.logempid, strTranType, vouyear, branchid, strFType)
                             //hid_stamt.Value = row.Cells[7].Text.ToString();
                             //hid_supplyto.Value = row.Cells[8].Text.ToString();
                             hid_stamt.Value = row.Cells[10].Text.ToString();
                             hid_supplyto.Value = row.Cells[11].Text.ToString();
                             string emp = row.Cells[4].Text.ToString();
                             int empp = employeeobj.GetNEmpid(emp);
                             //if (empp == int_Empid)
                             //{
                             //    StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                             //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                             //    continue;
                             //}

                             /* if (Session["hid_gstdate"] != null)
                              {
                                  if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
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

                                              /*if (dt_list.Rows.Count > 0)
                                              {
                                                  if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                                                  {

                                                  }
                                                  else
                                                  {
                                                      StrScript += "State Name not Updated in Master Kindly update Master Customer ";

                                                      continue;
                                                  }
                                              }
                                              else
                                              {
                                                  StrScript += "State Name not Updated in Master Kindly update Master Customer";

                                                  continue;
                                              }

                                              if (dt_list.Rows.Count > 0)
                                              {
                                                  if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                                  {
                                                      if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                      {
                                                          if (gsttype == 0)
                                                          {
                                                              gsttype_ = row.Cells[2].Text;
                                                          }
                                                          else
                                                          {
                                                              gsttype_ = " ," + row.Cells[2].Text;
                                                          }
                                                          gsttype = 1;
                                                          //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                          continue;
                                                      }
                                                  }

                                              }
                                              else
                                              {
                                                  //StrScript += "State Name not Updated in Master Kindly update Master Customer for" + row.Cells[2].Text.ToString();
                                                  if (statename == 0)
                                                  {
                                                      statename_ = row.Cells[2].Text;
                                                  }
                                                  else
                                                  {
                                                      statename_ = " ," + row.Cells[2].Text;
                                                  }
                                                  statename = 1;
                                                  continue;
                                              }

                                          }
                                      }
                                      else
                                      {

                                          //StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;

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

                             dtosdn = obj_da_OSDNCN.GetCheckosdncnnew(Str_Trantype, jobnoosdn, int_bid);
                             int cnt = 0;
                             cnt = dtosdn.Rows.Count;
                             if (cnt == 1)
                             {
                                 if (int_osdncn1 == 0)
                                 {
                                     str_osdncn1 = int_Refno.ToString();
                                 }
                                 else
                                 {
                                     str_osdncn1 = " ," + int_Refno.ToString();
                                 }
                                 int_osdncn1 = 1;
                                 continue;

                             }

                             else
                             {

                                 int_intdcno = obj_da_Approval.UpdProApprovalOSDCN(int_Refno, Convert.ToInt32(row.Cells[1].Text.ToString()), int_Empid, Str_Trantype, int_Vouyear, int_bid, hid_type.Value.ToString());
                                 obj_da_Approval.insForOSDNCNDNCNNumber(int_intdcno, hid_type.Value.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(row.Cells[1].Text.ToString()), Str_Trantype, int_Refno);
                             }

                             if (hid_type.Value.ToString() == "ProOSDNApproval")
                             {//raj
                                 logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                 try
                                 {
                                     obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                     if (obj_dt.Rows.Count > 0)
                                     {
                                         int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                         DateTime date_Voudate = DateTime.Parse((obj_dt.Rows[0]["dndate"].ToString()));
                                         string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                         double amount = double.Parse(row.Cells[3].Text.ToString());
                                         double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                         int int_Ledgerid = 0;
                                         int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                         int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Session["FADbname"].ToString());
                                         if (int_Ledgerid == 0)
                                         {
                                             int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                         }
                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                        }
                                 switch (Session["StrTranType"].ToString())
                                 {
                                     case "FE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                         break;

                                     case "FI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                         break;

                                     case "AE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                         break;

                                     case "AI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                         break;

                                 }
                             }
                             else if (hid_type.Value.ToString() == "ProOSCNApproval")
                             {//raj
                                 logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                 try
                                 {
                                     obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                     if (obj_dt.Rows.Count > 0)
                                     {
                                         int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                         DateTime date_Voudate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[0]["cndate"].ToString()));
                                         string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                         double amount = double.Parse(row.Cells[3].Text.ToString());
                                         double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                         int int_Ledgerid = 0;
                                         int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                         int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Session["FADbname"].ToString());
                                         if (int_Ledgerid == 0)
                                         {
                                             int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                         }
                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                     }
                                 switch (Session["StrTranType"].ToString())
                                 {
                                     case "FE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                         break;

                                     case "FI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                         break;

                                     case "AE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                         break;

                                     case "AI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                         break;

                                 }
                             }
                             if (int_intdcno != 0)
                             {
                                 Str_invoiceno = Str_invoiceno + int_intdcno.ToString() + ",";
                             }
                             else
                             {
                                 StrScript += "OSDN # or OSCN # Not Generated and Transfered";

                             }

                         }

                     }
                     if (countinv != 1)
                     {

                         ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                         return;
                     }
                     if (Str_invoiceno.Length > 0)
                     {
                         Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                         // string StrScript = "";
                         if (hid_type.Value.ToString() == "ProOSDNApproval")
                         {
                             StrScript += "OSDN # " + Str_invoiceno + " Generated and Transfered";
                         }
                         else if (hid_type.Value.ToString() == "ProOSCNApproval")
                         {
                             StrScript += "OSCN # " + Str_invoiceno + " Generated and Transfered";
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
                     if (int_osdncn1 == 1)
                     {
                         StrScript += "Kindly Save the Proforma Voucher Again and Approve for" + str_osdncn1;
                     }

                 }
                 Fn_Getdetail();
                 //if (Str_invoiceno.Length > 0)
                 //{
                 ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                 //}
                 //  UserRights();
             }
             catch (Exception ex)
             {
                 string message = ex.Message.ToString();
                 ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
             }
             btn_delete.Visible = false;btn_delete_id.Visible = false;

         }

         */

        protected void btn_transfer_Click(object sender, EventArgs e)
        {
            try
            {

                log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(OEOpsAndDocs));
                log4net.Config.BasicConfigurator.Configure();
                log1.Info("********************************************************************************************************************************************************");
                log1.Info("Voucher Transfer has been Called");

                // Einvoice newly added start//
                //DataAccess.Documents objnew = new DataAccess.Documents();

                string div_id = "", gstirn_ = "", gstirnerr_ = "";
                int gstirn = 0, gstirnerr = 0;
                // Einvoice newly added end//
                int int_Vouyear1 = 0;

                string type = "";
                string str_favourname = "";
                int invoinumber = 0;
                //DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
                int int_osdncn = 0;
                DataTable dtosdn = new DataTable();
                //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                string cutname = "";
                // DataSet dsosdn=new DataSet();
                int jobnoosdn = 0;
                //int gsttype = 0, statename = 0, supplyto = 0, int_osdncn1 = 0;
                //string gsttype_ = "", statename_ = "", supplyto_ = "", str_osdncn1 = "";
                int gsttype = 0, statename = 0, supplyto = 0, int_osdncn1 = 0, int_TDS = 0;
                string gsttype_ = "", statename_ = "", supplyto_ = "", str_osdncn1 = "", str_TDS = "";

                int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
                string Str_Trantype = Session["StrTranType"].ToString(), Str_invoiceno = "", Str_invoicenonew = "";
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                string StrScript = "";
                int countinv = 0;
                double st_amt = 0.0;
                double Amount = 0, TDS = 0, TDSAmount = 0, CSTAmount = 0, gstamt = 0;
                //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                //DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
                //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                int int_Custid = 0;
                TextBox Txt = new TextBox();

                string tdstype = "", tdsdesc = "";
                string str_tdstype = "", str_tdsdesc = "";
                int int_tdstype = 0, int_tdsdesc = 0;
                DataTable dtcheck = new DataTable();

                DataTable dtnew1 = new DataTable();

                DataTable obj_dt1 = new DataTable();

                int countryid = 0;
                //DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                DataTable dtcust = new DataTable();
                DataTable dtcust1 = new DataTable();
                DataTable dcon = Appobj.Checkcountry(int_bid);
                int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                /******************* For Auto mail *********************/
                bool bos = false;
                /*******************************************************/

                //dtcheck = obj_da_Invoice.SPCheckApprovaldate(int.Parse(Session["LoginDivisionId"].ToString()));
                //dtnew1 = obj_da_Invoice.getuserrightsforjobclose();
                //if (dtnew1.Rows.Count > 0)
                //{
                //    if (Session["LoginEmpId"].ToString() == dtnew1.Rows[0]["employeeid"].ToString())
                //    {

                //    }
                //    else
                //    {
                //        if (dtcheck.Rows.Count > 0)
                //        {
                //            ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Every Month First Five Days ,You cannot Approve Any Vouchers');", true);
                //            return;
                //        }
                //    }
                //}
                //else
                //{
                //    if (dtcheck.Rows.Count > 0)
                //    {
                //        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Every Month First Five Days ,You cannot Approve Any Vouchers');", true);
                //        return;
                //    }
                //}
                int Row_ID;
                Boolean ch = false;
                foreach (GridViewRow row in Grd_Approval.Rows)
                {
                    CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                    if (Chk.Checked == true)
                    {
                        ch = true;
                          Row_ID = row.RowIndex;
                        hid_voutype.Value = Grd_Approval.Rows[Row_ID].Cells[1].Text;
                        hid_voutypeid.Value = Grd_Approval.DataKeys[Row_ID].Values[2].ToString();
                        if (hid_voutype.Value.ToString() == "SALES INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "SALES INVOICE OC" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                        {

                            //foreach (GridViewRow row in Grd_Approval.Rows)
                            //{
                            type = Grd_Approval.Rows[Row_ID].Cells[22].Text;       //NewOne       //21/07/2022
                            string str_Voutype = type;
                            bool ChkLedger = true;
                            //   CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                            //if (Chk.Checked == true)
                            //{
                            countinv = 1;
                            int_Custid = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[1].ToString());
                            countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));
                            int_Refno = Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text);
                            int_Vouyear = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[0].ToString());

                            /******************* For Auto mail *********************/
                            hid_refno.Value = Grd_Approval.Rows[Row_ID].Cells[2].Text;
                            //hid_vouyear.Value = Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString();
                            hid_vouyear.Value = obj_da_FAVoucher.Getvouyearforautotransfer(int_bid).ToString();
                            /****************************************/

                            //hid_stamt.Value = row.Cells[7].Text.ToString();
                            //hid_supplyto.Value = row.Cells[8].Text.ToString();
                            hid_stamt.Value = Grd_Approval.Rows[Row_ID].Cells[19].Text;
                            hid_supplyto.Value = Grd_Approval.Rows[Row_ID].Cells[20].Text;


                            if (hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                            {
                                //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                                //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                                if (con == 1102 || con == 102)
                                {
                                    if (countryid == 1102 || countryid == 102)
                                    {
                                        Txt = (TextBox)Grd_Approval.Rows[Row_ID].FindControl("txtpercentage");         //NewOne       //21/07/2022
                                        if (Txt.Text.Trim().Length == 0)
                                        {
                                            //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "TDS", "alertify.alert('Enter TDS%');", true);
                                            if (int_TDS == 0)
                                            {
                                                str_TDS = "Enter TDS% for Ref number " + int_Refno;
                                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + str_TDS + "');", true);
                                                return;
                                            }
                                            else
                                            {
                                                str_TDS = str_TDS + "," + int_Refno;
                                            }
                                            Txt.Focus();
                                            int_TDS = 1;
                                            //continue;

                                        }
                                        else
                                        {
                                            tdstype = Grd_Approval.Rows[Row_ID].Cells[9].Text;
                                            tdsdesc = Grd_Approval.Rows[Row_ID].Cells[10].Text;// row.Cells[7].Text.ToString();
                                            if (tdstype == "" && tdstype == "")
                                            {
                                                if (int_tdstype == 0)
                                                {
                                                    str_tdstype = "TDS Type and TDS Description is Empty for Ref #  " + int_Refno;
                                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + str_tdstype + "');", true);
                                                    return;
                                                }
                                                else
                                                {
                                                    str_tdstype = str_tdstype + "," + int_Refno;
                                                }
                                                Txt.Focus();
                                                int_tdstype = 1;
                                                //continue;
                                            }
                                            else if (tdstype == "")
                                            {
                                                if (int_tdstype == 0)
                                                {
                                                    str_tdstype = "TDS Type is Empty for Ref # " + int_Refno;
                                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + str_tdstype + "');", true);
                                                    return;
                                                }
                                                else
                                                {
                                                    str_tdstype = str_tdstype + "," + int_Refno;
                                                }
                                                Txt.Focus();
                                                int_tdstype = 1;
                                                //continue;
                                            }

                                            else if (tdsdesc == "")
                                            {
                                                if (int_tdsdesc == 0)
                                                {
                                                    str_tdsdesc = "TDS DESC is Empty for Ref # " + int_Refno;
                                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + str_tdstype + "');", true);
                                                    return;
                                                }
                                                else
                                                {
                                                    str_tdsdesc = str_tdsdesc + "," + int_Refno;
                                                }
                                                Txt.Focus();
                                                int_tdsdesc = 1;
                                                //continue;
                                            }

                                        }
                                    }
                                }
                            }

                            if (hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                            {
                                //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                                //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                                if (con == 1102 || con == 102)
                                {
                                    if (countryid == 1102 || countryid == 102)
                                    {

                                        if (hid_supplyto.Value != "")
                                        {
                                            dtcust1 = obj_da_BL.Gettdsforcustomer(Convert.ToInt32(hid_supplyto.Value));
                                        }
                                        if (dtcust1.Rows.Count > 0)
                                        {
                                            // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                                            StrScript += "TDS does not exist for SupplyTo customer .Kindly check Proforma PI " + int_Refno;
                                            //continue;

                                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                            return;
                                        }

                                        dtcust1 = obj_da_BL.Gettdsforcustomer(int_Custid);

                                        if (dtcust1.Rows.Count > 0)
                                        {
                                            // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                                            StrScript += "TDS does not exist for BillTo customer .Kindly check Proforma PA" + int_Refno;
                                            //continue;
                                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                            return;

                                        }
                                    }
                                }

                            }

                            if (hid_supplyto.Value != "0")
                            {
                                cutname = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                            }
                            string emp = Grd_Approval.Rows[Row_ID].Cells[8].Text;
                            int empp = employeeobj.GetNEmpid(emp);
                            //if (empp == int_Empid)
                            //{
                            //    StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                            //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //    continue;
                            //}
                            DataTable dtnewexrate = obj_da_Invoice.GET_exratecheckLV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));
                            if (dtnewexrate.Rows.Count > 0)
                            {
                                StrScript += "Ex.Rate Different in Voucher Details " + int_Refno + ".Kindly check Proforma Invoice";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                //continue;
                            }

                            DataTable dtnewgst = obj_da_Invoice.Get_checkwithSGSTPIGSTLV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));

                            if (dtnewgst.Rows.Count > 0)
                            {
                                StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice/PI";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                //continue;
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }

                            DataTable dtnewgst1 = obj_da_Invoice.Get_checkwithSGSTPIGST1LV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));

                            if (dtnewgst1.Rows.Count > 0)
                            {
                                StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice/PI";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                //continue;
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }
                            if ((hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)))
                            {
                                Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmtLV(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                                if (Dtckeck.Rows.Count > 0)
                                {
                                    StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice";
                                    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                    //continue;
                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                    return;
                                }
                            }

                            if ((hid_voutype.Value.ToString() == "PURCHASE INVOICE" && (countryid == 1102 || countryid == 102)) || (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC" && (countryid == 1102 || countryid == 102)))
                            {
                                Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmtLV(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                                if (Dtckeck.Rows.Count > 0)
                                {
                                    StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Credit Note Operation";
                                    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                    //continue;
                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                    return;
                                }
                            }

                            // Einvoice newly added start//
                            if ((hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)) || (hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)))
                            {
                                DataTable dthsncode = obj_da_Approval.GetchksaccodeforvoucherLV(Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Refno, int_Vouyear, "I");
                                if (dthsncode.Rows.Count > 0)
                                {
                                    StrScript += "Kindly update the SACCode in master " + int_Refno + ".check Proforma Invoice";
                                    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                    //continue;
                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                    return;
                                }
                            }

                            if (hid_voutype.Value.ToString() == "SALES INVOICE OC" || hid_voutype.Value.ToString() == "SALES INVOICE")
                            {
                                string custid1 = objnew.getloctdetails(Convert.ToInt32(hid_supplyto.Value));

                                if (custid1 == "1")
                                {
                                    //StrScript += "kindly update the Location or State name for customer " + int_Refno + ".check Proforma Invoice";
                                    StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Please Update Location / State / Pincode of " + cutname + ",";
                                    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                    //continue;
                                }

                                string custid2 = objnew.getloctdetails(Convert.ToInt32(int_Custid));

                                if (custid2 == "1")
                                {
                                    StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Please Update Location / State / Pincode of " + cutname + ",";
                                    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                    //continue;
                                }
                            }

                            string custid11 = objnew.getholdcutdetails(Convert.ToInt32(hid_supplyto.Value));

                            if (custid11 == "1")
                            {
                                //StrScript += "kindly update the Location or State name for customer " + int_Refno + ".check Proforma Invoice";
                                StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Customer " + cutname + " status is Hold please discuss with Finance team" + ",";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                //continue;
                            }

                            string custid21 = objnew.getholdcutdetails(Convert.ToInt32(int_Custid));

                            if (custid21 == "1")
                            {
                                StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Customer " + cutname + " status is Hold please discuss with Finance team" + ",";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                //continue;
                            }


                            if (Session["hid_gstdate"] != null)
                            {
                                if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                                {

                                    if (hid_supplyto.Value != "0")
                                    {

                                        if (Convert.ToDouble(hid_stamt.Value) > 0)
                                        {

                                            int int_custidnew;
                                            DataTable dt_list = new DataTable();
                                            //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                            //int int_custid = Convert.ToInt32(hdncustid.Value);
                                            if (!string.IsNullOrEmpty(Grd_Approval.Rows[Row_ID].Cells[20].Text))   //NewOne       //21/07/2022
                                            {
                                                int_custidnew = Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[20].Text);  //NewOne       //21/07/2022
                                                dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                            }

                                            if (dt_list.Rows.Count > 0)
                                            {
                                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                                {
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
                                                        //continue;
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                //StrScript += "State Name not Updated in Master Kindly update Master Customer for" + row.Cells[2].Text.ToString();
                                                if (statename == 0)
                                                {
                                                    statename_ = cutname;
                                                }
                                                else
                                                {
                                                    statename_ = " ," + cutname;
                                                }
                                                statename = 1;
                                                //continue;
                                            }

                                        }

                                    }
                                    else
                                    {
                                        //StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;
                                        if (supplyto == 0)
                                        {
                                            supplyto_ = int_Refno.ToString();
                                        }
                                        else
                                        {
                                            supplyto_ = " ," + int_Refno.ToString();
                                        }
                                        supplyto = 1;
                                        //continue;
                                    }
                                }
                            }

                            string inapproved = obj_da_Approval.CHKVoucherbosLV(int_Refno);

                            if ((inapproved.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (inapproved.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)))
                            {
                                invoinumber = obj_da_Approval.UpdProApprovalnewBOSLV(0, int_bid, int_Refno, int_Vouyear, Grd_Approval.Rows[Row_ID].Cells[4].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                                bos = true;

                                //  logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");

                                if (invoinumber != 0)
                                {
                                    Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                                }
                                else
                                {
                                    Str_invoicenonew = "Invoice not Approved";
                                }
                            }

                            ////hari /// 09_09_2022 //std
                            string invapprovegst = obj_da_Approval.SPCHECkfrightLV(int_Refno);

                            if ((invapprovegst.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (invapprovegst.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)))
                            {

                                invoinumberfright = obj_da_Approval.UpdProApprovalnewLV(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, Grd_Approval.Rows[Row_ID].Cells[4].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "");

                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", int_bid, "", 0, 0, "", 1);

                                //hide on 14Jun2022 -- nambi
                                ////4 invoice
                                //invoinumber = obj_da_Approval.UpdProApprovalnew(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "");

                                if (invoinumberfright != 0)
                                {
                                    Str_invoicenonew = Str_invoicenonew + invoinumberfright.ToString() + ",";
                                }
                                else
                                {
                                    Str_invoicenonew = "Invoice not Approved";
                                }

                                div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                                string custid1ung = objnew.getunregcustvouchers(invoinumberfright, int_Vouyear, int_bid, "I");

                                if (div_id == "1" && custid1ung == "0" && (countryid == 1102 || countryid == 102))
                                {

                                    try
                                    {

                                        //int vouno = 1018;  // 793 ,826
                                        //int bid = 13;
                                        //int vouyear = 2020;
                                        //int cid = 1;
                                        string json1 = objnew.getgstdetails(invoinumberfright, int_bid, int_Vouyear, "I");
                                        //   DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", "{\r\n    \"Version\": \"1.1\",\r\n    \"TranDtls\": {\r\n        \"TaxSch\": \"GST\",\r\n        \"SupTyp\": \"B2B\",\r\n        \"RegRev\": \"N\"\r\n    },\r\n    \"DocDtls\": {\r\n        \"Typ\": \"INV\",\r\n        \"No\": \"IN2021CHEOE100\",\r\n        \"Dt\": \"13\\/05\\/2020\"\r\n    },\r\n    \"SellerDtls\": {\r\n        \"Gstin\": \"29AAFCC9980MZZT\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"29\"\r\n    },\r\n    \"BuyerDtls\": {\r\n        \"Gstin\": \"07AAACA4691C2ZY\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Pos\": \"07\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"07\"\r\n    },\r\n    \"ItemList\": [{\r\n        \"SlNo\": \"1\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5.00,\r\n        \"TotAmt\": 388.25,\r\n        \"AssAmt\": 388.25,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 69.89,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 458.14\r\n    }, {\r\n        \"SlNo\": \"2\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 4050.00,\r\n        \"TotAmt\": 4050.00,\r\n        \"AssAmt\": 4050.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 729.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 4779.00\r\n    }, {\r\n        \"SlNo\": \"3\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5500.00,\r\n        \"TotAmt\": 5500.00,\r\n        \"AssAmt\": 5500.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 990.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 6490.00\r\n    }],\r\n    \"ValDtls\": {\r\n        \"AssVal\": 9938.25,\r\n        \"CgstVal\": 0.00,\r\n        \"SgstVal\": 0.00,\r\n        \"IgstVal\": 1788.89,\r\n        \"RndOffAmt\": 0.00,\r\n        \"TotInvVal\": 11727.00\r\n    }\r\n}\r\n\r\n");

                                        string datajson = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json1);

                                        //DataTable dtjson = ConvertJsonToDatatable(datajson);
                                        // string l0 = dtjson.Rows[0][0].ToString().Trim();
                                        DataTable dtjson = new DataTable();
                                        string status = "";
                                        if (datajson != null)
                                        {
                                            dtjson = ConvertJsonToDatatable(datajson);
                                            status = dtjson.Rows[0][0].ToString().Trim();
                                        }
                                        else
                                        {
                                            status = "0";
                                        }

                                        string message1 = "";
                                        string IRN1 = "";
                                        string Ackdt = "";
                                        string Ackno = "";
                                        string status1 = "";
                                        string SignedQRCode = "";
                                        string SignedInvoice = "";

                                        string uuid = "";
                                        string SignedQrCodeImgUrl = "";
                                        string IrnStatus = "";
                                        string EwbStatus = "";
                                        string Irp = "";
                                        string EwbDt = "";
                                        string EwbNo = "";
                                        string EwbValidTill = "";
                                        string Remarks = "";

                                        if (status == "1")
                                        {
                                            //message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                            //IRN1 = dtjson.Rows[0][2].ToString().Replace('"', ' ').Trim();
                                            //Ackdt = dtjson.Rows[0][3].ToString().Replace('"', ' ').Trim();
                                            //Ackno = dtjson.Rows[0][4].ToString().Replace('"', ' ').Trim();
                                            //status1 = dtjson.Rows[0][5].ToString().Replace('"', ' ').Trim();
                                            //SignedQRCode = dtjson.Rows[0][6].ToString().Replace('"', ' ').Trim();

                                            //SignedInvoice = dtjson.Rows[0][7].ToString().Replace('"', ' ').Trim();

                                            //uuid = dtjson.Rows[0][8].ToString().Replace('"', ' ').Trim();
                                            //SignedQrCodeImgUrl = dtjson.Rows[0][9].ToString().Replace('"', ' ').Trim();
                                            //IrnStatus = dtjson.Rows[0][10].ToString().Replace('"', ' ').Trim();
                                            //EwbStatus = dtjson.Rows[0][11].ToString().Replace('"', ' ').Trim();
                                            //Irp = dtjson.Rows[0][12].ToString().Replace('"', ' ').Trim();

                                            message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();    		//	1                       
                                            IRN1 = dtjson.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2
                                            Ackdt = dtjson.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                            Ackno = dtjson.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                            status1 = dtjson.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                            SignedQRCode = dtjson.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                            SignedInvoice = dtjson.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11

                                            uuid = dtjson.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                            SignedQrCodeImgUrl = dtjson.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                            IrnStatus = dtjson.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                            EwbStatus = dtjson.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                            Irp = dtjson.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                            EwbDt = dtjson.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                            EwbNo = dtjson.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                            EwbValidTill = dtjson.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                            Remarks = dtjson.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8

                                            objnew.insmastergstdetails(invoinumberfright, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "I", EwbDt, EwbNo, EwbValidTill, Remarks);

                                        }
                                        else
                                        {
                                            //  l1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                            if (datajson != null)
                                            {
                                                message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                            }
                                            else
                                            {
                                                message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                            }
                                            objnew.insmastergstdetails(invoinumberfright, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "I", "", "", "", "");

                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        string message = ex.Message.ToString();
                                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                                    }
                                }
                            }

                            ////hari /// 09_09_2022 //END

                            string inapproved1 = obj_da_Approval.CHKVoucherinvgenLV(int_Refno);

                            if ((inapproved1.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (inapproved1.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)))
                            {
                                int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                                if (hid_voutype.Value.ToString() == "SALES INVOICE")
                                {
                                    obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                    objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Sales Invoice",
                         Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), hid_voutype.Value.ToString(), 12);


                                }
                                else
                                {
                                    obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice FC");
                                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                    objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Sales Invoice",
                         Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), "Invoice FC", 28);

                                }

                                // obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());

                                // Einvoice newly added satrt//

                                div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                                string custid1ung = objnew.getunregcustvouchers(int_Invoiceno, int_Vouyear, int_bid, "I");

                                if (div_id == "1" && custid1ung == "0" && (countryid == 1102 || countryid == 102))
                                {

                                    try
                                    {

                                        string json2 = objnew.getgstdetails(int_Invoiceno, int_bid, int_Vouyear, "I");

                                        string datajson1 = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json2);
                                        DataTable dtjson1 = new DataTable();
                                        string status = "";
                                        if (datajson1 != null)
                                        {
                                            dtjson1 = ConvertJsonToDatatable(datajson1);
                                            status = dtjson1.Rows[0][0].ToString().Trim();
                                        }
                                        else
                                        {
                                            status = "0";
                                        }

                                        string message1 = "";
                                        string IRN1 = "";
                                        string Ackdt = "";
                                        string Ackno = "";
                                        string status1 = "";
                                        string SignedQRCode = "";
                                        string SignedInvoice = "";

                                        string uuid = "";
                                        string SignedQrCodeImgUrl = "";
                                        string IrnStatus = "";
                                        string EwbStatus = "";
                                        string Irp = "";

                                        string EwbDt = "";
                                        string EwbNo = "";
                                        string EwbValidTill = "";
                                        string Remarks = "";

                                        if (status == "1")
                                        {

                                            message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();    		//	1   

                                            IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2

                                            gstirn_ = gstirn_ + "," + message1 + " " + IRN1 + " ,";
                                            gstirn = 0;

                                            Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                            Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                            status1 = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                            SignedQRCode = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                            SignedInvoice = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11

                                            uuid = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                            SignedQrCodeImgUrl = dtjson1.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                            IrnStatus = dtjson1.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                            EwbStatus = dtjson1.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                            Irp = dtjson1.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                            EwbDt = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                            EwbNo = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                            EwbValidTill = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                            Remarks = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8

                                            objnew.insmastergstdetails(int_Invoiceno, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "I", EwbDt, EwbNo, EwbValidTill, Remarks);

                                        }
                                        else
                                        {
                                            if (datajson1 != null)
                                            {
                                                message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();

                                                gstirnerr_ = gstirnerr_ + "," + message1;
                                                gstirnerr = 1;

                                            }
                                            else
                                            {
                                                message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                            }
                                            objnew.insmastergstdetails(int_Invoiceno, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "I", "", "", "", "");
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        string message = ex.Message.ToString();
                                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                                    }

                                }

                                // Einvoice newly added end//
                            }
                            else if ((hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (hid_voutype.Value.ToString() == "SALES INVOICE OC " && (countryid == 1102 || countryid == 102)))
                            {
                                int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                                if (hid_voutype.Value.ToString() == "SALES INVOICE")
                                {
                                    obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                    objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Sales Invoice",
                                                  Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), hid_voutype.Value.ToString(), 12);

                                }
                                else
                                {
                                    obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice FC");
                                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                    objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Sales Invoice",
                        Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), "Invoice FC", 28);

                                }
                                //  obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                            }
                            else
                            {
                                if (hid_voutype.Value.ToString() != "SALES INVOICE" && hid_voutype.Value.ToString() != "SALES INVOICE OC")
                                {
                                    int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                                    // obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno,  hid_voutype.Value.ToString());
                                    if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                                    {
                                        obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA");
                                        hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                        objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Purchase Invoice",
                       Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), hid_voutype.Value.ToString(), 13);

                                    }
                                    else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                                    {
                                        obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA FC");
                                        hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                        objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Purchase Invoice",
                        Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), hid_voutype.Value.ToString(), 29);

                                    }
                                    //  obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA");

                                }

                            }

                            log1.Info("********************************************************************************************************************************************************");
                            log1.Info("Transfer To Commercial PA After Approval");

                            if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                            {

                                log1.Info("Before TDS- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                                int_Custid = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[1].ToString());

                                countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));
                                //Amount = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[4].Text.ToString()));
                                //gstamt = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[12].Text.ToString()));
                                // Amount = Amount - gstamt;
                                DataTable Dt_LimitCheck = new DataTable();
                                int_Vouyear1 = Convert.ToInt32(obj_da_FA.Getvouyearforautotransfer(int_bid).ToString());
                                Dt_LimitCheck = obj_da_Approval.GetCustAmtLimt(int_Custid, int_bid);
                                Amount = obj_da_Approval.GetVoucherAmount4TDS(int_Invoiceno, int_bid, int_Vouyear1, "P");
                                log1.Info("Before TDS Procedure1- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");
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
                                            log1.Info("Before TDS Amount > 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

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
                                                log1.Info("Before TDS Amount < 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                            }
                                            else
                                            {
                                                TDS = Convert.ToDouble(Dt_LimitCheck.Rows[0]["tdsemp"].ToString());
                                                TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                                log1.Info("Before TDS Amount = 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

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
                                            //  TDSAmount = Amount * (TDS / 100);
                                            TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                        }
                                    }

                                }
                                else
                                {
                                    //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                                    //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                                    if (con == 1102 || con == 102)
                                    {
                                        ///////////haribalaji ////////2924---------------
                                        if (Txt.Text.ToString() == "")
                                        {
                                            Txt.Text = "0";
                                        }
                                        ///////////haribalaji ////////2924---------------
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

                                log1.Info("Before TDS insert  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                CSTAmount = Amount - TDSAmount;

                                if (str_Voutype == "S")
                                {
                                    obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Invoiceno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear1);
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
                                string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";
                                if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                                {
                                    str_Voutype = "P";              //CN-OPS  -->P  //Admin-CN-->S//  Other-CN-->E
                                    type = "P";
                                }


                                log1.Info("Before TDS insert-1  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                if (ChkLedger == true)
                                {
                                    if ((countryid == 1102) || (countryid == 102))
                                    {
                                        log1.Info("Before TDS insert-2  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                        obj_da_Invoice.InsertPATDS(int_Invoiceno, str_Voutype, int.Parse(Session["LoginBranchid"].ToString()), int_Custid, int_Vouyear1, CSTAmount, TDSAmount, "", Convert.ToDouble(Txt.Text.ToString()));
                                        log1.Info("Before TDS insert-3  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                    }
                                    //if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                    // {
                                    //     str_Voutype="P";
                                    //     type = "P";
                                    // }

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

                                    logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Invoiceno, int_Invoiceno, Str_ddlNarration, Str_ddlReference, Convert.ToInt32(Session["LoginBranchid"]));

                                    int int_Ledgerid = 0;
                                    int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Session["FADbname"].ToString());
                                    int_Voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_ddlVoucherType, Session["FADbname"].ToString());
                                    if (int_Ledgerid == 0)
                                    {
                                        int_Ledgerid = Fn_Getcustomergroupid(int_Custid, Str_ddlVoucherType);
                                    }
                                    //DateTime dtdate = DateTime.Parse(Utility.fn_ConvertDate(Grd_Approval.Rows[row.RowIndex].Cells[12].Text));
                                    DateTime dtdate = DateTime.Parse((Grd_Approval.Rows[Row_ID].Cells[21].Text));     //NewOne       //21/07/2022
                                    string Str_CustType = obj_da_Customer.GetCustomerType(int_Custid);
                                    if (Str_CustType == "P" || Str_CustType == "E")
                                    {
                                        DataTable dt = new DataTable();
                                        dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "CNHead", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()));
                                        string Str_Curr = "";
                                        double F_Curr = 0;
                                        if (dt.Rows.Count > 0)
                                        {
                                            Str_Curr = dt.Rows[0]["curr"].ToString();
                                            F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, Str_Curr, F_Curr, int_Custid);
                                    }
                                    else
                                    {

                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, "", 0, int_Custid);
                                    }
                                }

                                //str_favourname = row.Cells[2].Text.ToString();
                                //obj_da_Cheque.UpdChequeRequest(int_Invoiceno, int.Parse(Session["Vouyear"].ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int_Empid, "PA", char.Parse("C"), "", str_favourname);

                            }

                            if (hid_voutype.Value.ToString() == "SALES INVOICE")
                            {//raj

                                //logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");
                                //if (inapproved.ToString() == "TRUE")
                                //{

                                //    if (invoinumber != 0)
                                //    {
                                //        // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");
                                //        logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");
                                //    }
                                //}

                                //string retransfer = "N";
                                //if (Session["vouid"] != null)
                                //{

                                //    retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Session["FADbname"].ToString());

                                //    if (retransfer == "Y")
                                //    {
                                //        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");

                                //    }
                                //    Session["vouid"] = null;

                                //}
                                //try
                                //{
                                //    obj_dt1 = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                //    if (obj_dt1.Rows.Count > 0)
                                //    {
                                //        int int_custid = int.Parse(obj_dt1.Rows[0].ItemArray[4].ToString());
                                //        DateTime date_Voudate = DateTime.Parse(obj_dt1.Rows[0].ItemArray[1].ToString());
                                //        int int_Ledgerid = 0;
                                //        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                //        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Invoices", Session["FADbname"].ToString());
                                //        if (int_Ledgerid == 0)
                                //        {
                                //            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                //        }
                                //        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'I', int_Vouyear, int_bid, double.Parse( Grd_Approval.Rows[Row_ID].Cells[7].Text.ToString()), "", 0, int_custid);
                                //    }
                                //}

                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1016, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1023, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1030, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1037, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "CH":
                                        obj_da_Log.InsLogDetail(int_Empid, 1043, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                }
                            }
                            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                            {
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "CH":
                                        obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                }
                            }

                            Str_invoiceno = Str_invoiceno + int_Invoiceno.ToString() + ",";

                            /******************* For Auto mail *********************/
                            if (hid_voutype.Value.ToString() == "SALES INVOICE")
                            {
                                if (bos == false)
                                {
                                    // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-Invoices", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                                }
                                else if (bos == true)
                                {
                                    // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "BOS", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                                }
                            }
                            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-CNOPS", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                            }

                            /******************************************************/

                            //}
                            //else if (countinv != 1)
                            //{

                            //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                            //    return;
                            //}
                            //}
                            if (countinv != 1)
                            {

                                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                                return;
                            }
                            if (Str_invoiceno.Length > 0)
                            {
                                Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                                if (hid_voutype.Value.ToString() == "SALES INVOICE")
                                {

                                    StrScript += "Invoice # " + Str_invoiceno + " Generated and Transfered";

                                    //if (invoinumber != 0)
                                    //{
                                    //    StrScript += "BOS # " + invoinumber + " Generated and Transfered";
                                    //}
                                    //if (int_Invoiceno != 0)
                                    //{
                                    //    StrScript += "Invoice # " + int_Invoiceno + " Generated and Transfered";
                                    //}
                                }
                                else if (hid_voutype.Value.ToString() == "SALES INVOICE OC")
                                {

                                    StrScript += "Invoice OC # " + Str_invoiceno + " Generated and Transfered";

                                }
                                else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                                {
                                    StrScript += "PI # " + Str_invoiceno + " Generated and Transfered";
                                }

                                else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                                {
                                    StrScript += "PI OC # " + Str_invoiceno + " Generated and Transfered";
                                }



                                else if (hid_voutype.Value.ToString() == "Transfer To Commercial CN")
                                {
                                    StrScript += "CN # " + Str_invoiceno + " Generated and Transfered";
                                }
                                else if (hid_voutype.Value.ToString() == "Transfer To Commercial DN")
                                {
                                    StrScript += "DN # " + Str_invoiceno + " Generated and Transfered";
                                }

                                /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                                 {
                                     StrScript = "OSDN # " + Str_invoiceno + " Generated and Transfered";
                                 }
                                 else if (hid_type.Value.ToString() == "ProOSCNApproval")
                                 {
                                     StrScript = "OSCN # " + Str_invoiceno + " Generated and Transfered";
                                 }*/

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

                            if (int_TDS == 1)
                            {
                                StrScript += " " + str_TDS;
                            }

                            if (int_tdstype == 1)
                            {
                                StrScript += " " + str_tdstype;
                            }

                            if (int_tdsdesc == 1)
                            {
                                StrScript += " " + str_tdsdesc;
                            }
                            if (countinv != 1)
                            {

                                StrScript += "Check Atleast One Ref#";
                                //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                                //return;
                            }
                            if (invoinumber != 0)
                            {
                                // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                                StrScript += "BOS # " + Str_invoicenonew;
                            }

                            if (Str_invoicenonew != "")
                            {
                                // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                                StrScript += "Freight Inv # " + Str_invoicenonew;
                            }

                            // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert(" + StrScript + ");", true);
                        }


                        //////////////////////////////////////////////////////////////////////////////////////////////////





                        else if (hid_voutype.Value.ToString() == "OSSI" || hid_voutype.Value.ToString() == "OSPI")
                        {
                            //foreach (GridViewRow row in Grd_Approval.Rows)
                            //{
                            //  CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                            //if (Chk.Checked == true)
                            //{
                            countinv = 1;
                            int_Refno = int.Parse(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString());
                            jobnoosdn = int.Parse(Grd_Approval.Rows[Row_ID].Cells[4].Text.ToString());
                            int_Vouyear = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[0].ToString());
                            if (hid_voutypeid.Value == "5")
                            {
                                hid_type.Value = "ProOSDNApproval";
                            }
                            else
                            {
                                hid_type.Value = "ProOSCNApproval";
                            }
                            /******************* For Auto mail *********************/
                            hid_refno.Value = Grd_Approval.Rows[Row_ID].Cells[2].Text;
                            hid_vouyear.Value = Grd_Approval.DataKeys[Row_ID].Values[0].ToString();
                            /****************************************/

                            // dcno = Approveobj.UpdProApprovalOSDCN(refno, strblno, Login.logempid, strTranType, vouyear, branchid, strFType)
                            hid_stamt.Value = Grd_Approval.Rows[Row_ID].Cells[19].Text;
                            hid_supplyto.Value = Grd_Approval.Rows[Row_ID].Cells[20].Text;

                            //hid_stamt.Value = row.Cells[16].Text.ToString();         //NewOne       //21/07/2022
                            //        hid_supplyto.Value = row.Cells[17].Text.ToString();      //NewOne       //21/07/2022
                            string emp = Grd_Approval.Rows[Row_ID].Cells[8].Text;
                            int empp = employeeobj.GetNEmpid(emp);

                            dtosdn = obj_da_OSDNCN.GetCheckosdncnnewLV(Str_Trantype, jobnoosdn, int_bid);
                            int cnt = 0;
                            cnt = dtosdn.Rows.Count;
                            if (cnt == 1)
                            {
                                if (int_osdncn1 == 0)
                                {
                                    str_osdncn1 = int_Refno.ToString();
                                }
                                else
                                {
                                    str_osdncn1 = " ," + int_Refno.ToString();
                                }
                                int_osdncn1 = 1;
                                //continue;

                            }

                            else
                            {
                                DataTable dtt = new DataTable();

                                DataTable dtnewexrate1 = obj_da_Invoice.GET_exratechecknewLV(int_Refno, int_bid, int_Vouyear, jobnoosdn, Str_Trantype, 0);
                                if (dtnewexrate1.Rows.Count > 0)
                                {
                                    StrScript += "Ex.Rate Different in Voucher Details " + int_Refno + ".Kindly check Proforma Invoice";
                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                    return;
                                }

                                dtt = obj_da_Approval.getdebitadviseactamtcheckLV(int_Vouyear, int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), jobnoosdn, Str_Trantype, hid_voutype.Value.ToString());
                                if (dtt.Rows.Count > 0)
                                {
                                    StrScript += "Taxable amount is mismatch for the Ref # : " + int_Refno + ",.Kindly update the ProOSDN/CN charge again and Save it";
                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                    return;
                                }

                                int amount1 = obj_da_Approval.getacosdncnamoutcheckLV(Str_Trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Refno, hid_voutype.Value.ToString());
                                if (amount1 == 1)
                                {
                                    StrScript += "Taxable amount is mismatch for the Ref # : " + int_Refno + ",.Kindly update the ProOSDN/CN charge again and Save it";
                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                    return;
                                }
                                else
                                {

                                }

                                int check = obj_da_Approval.CheckCBMzero4osv(int_Refno, int_bid, Convert.ToInt32(hid_voutypeid.Value));
                                if (check == 1)
                                {
                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Unit details not calculated properly,Kindly update the charge details again for Ref # " + int_Refno + "');", true);
                                    return;
                                }


                                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());

                                if (hid_voutypeid.Value == "5")
                                {
                                    int_intdcno = obj_da_Approval.UpdproappOSDNCN(int_Refno, int_Empid, int_bid, int_Invoiceno, "ProOSDNApproval");

                                    string x = Grd_Approval.Rows[Row_ID].Cells[1].Text.ToString();
                                    objRpt.InsOEeventdetailsTask(0, "", "", "OSDN Generation",
                         Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), "ProOSDNApproval", 26);

                                    // hid_type.Value = "ProOSDNApproval";
                                }
                                else
                                {
                                    int_intdcno = obj_da_Approval.UpdproappOSDNCN(int_Refno, int_Empid, int_bid, int_Invoiceno, "ProOSCNApproval");
                                    objRpt.InsOEeventdetailsTask(0, "", "", "OSCN Generation",
                          Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), "ProOSCNApproval", 27);

                                    //  hid_type.Value = "ProOSCNApproval";
                                }




                                // int_intdcno = obj_da_Approval.UpdproappOSDNCNOSV(int_Refno, Grd_Approval.Rows[Row_ID].Cells[4].Text.ToString(), int_Empid, Str_Trantype, int_Vouyear, int_bid, int.Parse(Grd_Approval.DataKeys[Row_ID].Values[2].ToString()));

                                //int_intdcno = obj_da_Approval.UpdProApprovalOSDCN(int_Refno, Convert.ToInt32(row.Cells[1].Text.ToString()), int_Empid, Str_Trantype, int_Vouyear, int_bid, hid_type.Value.ToString());
                                //    obj_da_Approval.insForOSDNCNDNCNNumberLV(int_intdcno,  hid_voutype.Value.ToString(), Convert.ToInt32(Session["LoginBranchid"]),  Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[4].Text), Str_Trantype, int_Refno);
                                //einvoice start 28 may 22
                                if (hid_voutype.Value.ToString() == "OSSI" && int_intdcno > 0)
                                {

                                    //newly GST added

                                    // Einvoice newly added satrt//

                                    div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                    //  div_id = "0";

                                    string custid1ung = objnew.getunregcustvouchers(int_intdcno, int_Vouyear, int_bid, "D");


                                    if (div_id == "1" && custid1ung == "0")
                                    {

                                        try
                                        {

                                            //int vouno = 1018;  // 793 ,826
                                            //int bid = 13;
                                            //int vouyear = 2020;
                                            //int cid = 1;

                                            //invoinumber = 700;
                                            //int_bid = 1;
                                            //int_Vouyear = 2020;
                                            //int_divisionid = 1;
                                            string json2 = objnew.getgstdetails(int_intdcno, int_bid, int_Vouyear, "D");
                                            //   DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", "{\r\n    \"Version\": \"1.1\",\r\n    \"TranDtls\": {\r\n        \"TaxSch\": \"GST\",\r\n        \"SupTyp\": \"B2B\",\r\n        \"RegRev\": \"N\"\r\n    },\r\n    \"DocDtls\": {\r\n        \"Typ\": \"INV\",\r\n        \"No\": \"IN2021CHEOE100\",\r\n        \"Dt\": \"13\\/05\\/2020\"\r\n    },\r\n    \"SellerDtls\": {\r\n        \"Gstin\": \"29AAFCC9980MZZT\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"29\"\r\n    },\r\n    \"BuyerDtls\": {\r\n        \"Gstin\": \"07AAACA4691C2ZY\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Pos\": \"07\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"07\"\r\n    },\r\n    \"ItemList\": [{\r\n        \"SlNo\": \"1\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5.00,\r\n        \"TotAmt\": 388.25,\r\n        \"AssAmt\": 388.25,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 69.89,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 458.14\r\n    }, {\r\n        \"SlNo\": \"2\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 4050.00,\r\n        \"TotAmt\": 4050.00,\r\n        \"AssAmt\": 4050.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 729.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 4779.00\r\n    }, {\r\n        \"SlNo\": \"3\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5500.00,\r\n        \"TotAmt\": 5500.00,\r\n        \"AssAmt\": 5500.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 990.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 6490.00\r\n    }],\r\n    \"ValDtls\": {\r\n        \"AssVal\": 9938.25,\r\n        \"CgstVal\": 0.00,\r\n        \"SgstVal\": 0.00,\r\n        \"IgstVal\": 1788.89,\r\n        \"RndOffAmt\": 0.00,\r\n        \"TotInvVal\": 11727.00\r\n    }\r\n}\r\n\r\n");

                                            string datajson1 = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json2);
                                            DataTable dtjson1 = new DataTable();
                                            string status = "";
                                            if (datajson1 != null)
                                            {
                                                dtjson1 = ConvertJsonToDatatable(datajson1);
                                                status = dtjson1.Rows[0][0].ToString().Trim();
                                            }
                                            else
                                            {
                                                status = "0";
                                            }

                                            string message1 = "";
                                            string IRN1 = "";
                                            string Ackdt = "";
                                            string Ackno = "";
                                            string status1 = "";
                                            string SignedQRCode = "";
                                            string SignedInvoice = "";

                                            string uuid = "";
                                            string SignedQrCodeImgUrl = "";
                                            string IrnStatus = "";
                                            string EwbStatus = "";
                                            string Irp = "";

                                            string EwbDt = "";
                                            string EwbNo = "";
                                            string EwbValidTill = "";
                                            string Remarks = "";

                                            if (status == "1")
                                            {
                                                //message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                                //IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();
                                                //Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();
                                                //Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();
                                                //status1 = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim();
                                                //SignedQRCode = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim();

                                                //SignedInvoice = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();



                                                //uuid = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();
                                                //SignedQrCodeImgUrl = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim();
                                                //IrnStatus = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim();
                                                //EwbStatus = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim();
                                                //Irp = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();


                                                //message1 = dtjson1.Rows[0]["message"].ToString().Replace('"', ' ').Trim();
                                                //IRN1 = dtjson1.Rows[0]["Irn"].ToString().Replace('"', ' ').Trim();
                                                //Ackdt = dtjson1.Rows[0]["AckDt"].ToString().Replace('"', ' ').Trim();
                                                //Ackno = dtjson1.Rows[0]["AckNo"].ToString().Replace('"', ' ').Trim();
                                                //status1 = dtjson1.Rows[0]["Status"].ToString().Replace('"', ' ').Trim();
                                                //SignedQRCode = dtjson1.Rows[0]["SignedQRCode"].ToString().Replace('"', ' ').Trim();

                                                //SignedInvoice = dtjson1.Rows[0]["SignedInvoice"].ToString().Replace('"', ' ').Trim();



                                                //uuid = dtjson1.Rows[0]["uuid"].ToString().Replace('"', ' ').Trim();
                                                //SignedQrCodeImgUrl = dtjson1.Rows[0]["SignedQrCodeImgUrl"].ToString().Replace('"', ' ').Trim();
                                                //IrnStatus = dtjson1.Rows[0]["IrnStatus"].ToString().Replace('"', ' ').Trim();
                                                //EwbStatus = dtjson1.Rows[0]["EwbStatus"].ToString().Replace('"', ' ').Trim();
                                                //Irp = dtjson1.Rows[0]["Irp"].ToString().Replace('"', ' ').Trim();

                                                //EwbDt = dtjson1.Rows[0]["EwbDt"].ToString().Replace('"', ' ').Trim();
                                                //EwbNo = dtjson1.Rows[0]["EwbNo"].ToString().Replace('"', ' ').Trim();
                                                //EwbValidTill = dtjson1.Rows[0]["EwbValidTill"].ToString().Replace('"', ' ').Trim();
                                                //Remarks = dtjson1.Rows[0]["Remarks"].ToString().Replace('"', ' ').Trim();



                                                message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();    		//	1   



                                                IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2

                                                gstirn_ = gstirn_ + "," + message1 + " " + IRN1 + " ,";
                                                gstirn = 0;

                                                Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                                Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                                status1 = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                                SignedQRCode = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                                SignedInvoice = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11



                                                uuid = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                                SignedQrCodeImgUrl = dtjson1.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                                IrnStatus = dtjson1.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                                EwbStatus = dtjson1.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                                Irp = dtjson1.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                                EwbDt = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                                EwbNo = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                                EwbValidTill = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                                Remarks = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8



                                                objnew.insmastergstdetails(int_intdcno, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "D", EwbDt, EwbNo, EwbValidTill, Remarks);


                                            }
                                            else
                                            {
                                                if (datajson1 != null)
                                                {
                                                    message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();

                                                    gstirnerr_ = gstirnerr_ + "," + message1;
                                                    gstirnerr = 1;

                                                }
                                                else
                                                {
                                                    message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                                }
                                                objnew.insmastergstdetails(int_intdcno, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "D", "", "", "", "");
                                            }


                                        }
                                        catch (Exception ex)
                                        {
                                            string message = ex.Message.ToString();
                                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                                        }


                                    }

                                    // Einvoice newly added end//
                                }


                                //end


                            }

                            //log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            if (hid_voutype.Value.ToString() == "OSSI")
                            {//raj
                             //log1.Info("Before Call the Procedure apposdn - (Voutype- " + "OSSI" + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                                //logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");

                                //log1.Info("After Call the Procedure apposdn - (Voutype- " + "OSSI" + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                                //try
                                //{
                                //    obj_dt1 = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                //    if (obj_dt1.Rows.Count > 0)
                                //    {
                                //        int int_custid = int.Parse(obj_dt1.Rows[0]["customer"].ToString());
                                //        DateTime date_Voudate = DateTime.Parse((obj_dt1.Rows[0]["dndate"].ToString()));
                                //        string str_curr = obj_dt1.Rows[0]["curr"].ToString();
                                //        double amount = double.Parse( Grd_Approval.Rows[Row_ID].Cells[7].Text.ToString());
                                //        double vamount = amount * double.Parse(obj_dt1.Rows[0]["exrate"].ToString());
                                //        int int_Ledgerid = 0;
                                //        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                //        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Session["FADbname"].ToString());
                                //        if (int_Ledgerid == 0)
                                //        {
                                //            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                //        }
                                //        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                //    }
                                //}

                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                }
                            }
                            else if (hid_voutype.Value.ToString() == "OSPI")
                            {//raj

                                //log1.Info("Before Call the Procedure apposcn - (Voutype- " + "OSPI" + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                                //logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");

                                //log1.Info("Before Call the Procedure apposcn - (Voutype- " + "OSPI" + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                                //try
                                //{
                                //    obj_dt1 = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                //    if (obj_dt1.Rows.Count > 0)
                                //    {
                                //        int int_custid = int.Parse(obj_dt1.Rows[0]["customer"].ToString());
                                //        DateTime date_Voudate = DateTime.Parse((obj_dt1.Rows[0]["cndate"].ToString()));
                                //        string str_curr = obj_dt1.Rows[0]["curr"].ToString();
                                //        double amount = double.Parse( Grd_Approval.Rows[Row_ID].Cells[7].Text.ToString());
                                //        double vamount = amount * double.Parse(obj_dt1.Rows[0]["exrate"].ToString());
                                //        int int_Ledgerid = 0;
                                //        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                //        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Session["FADbname"].ToString());
                                //        if (int_Ledgerid == 0)
                                //        {
                                //            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                //        }
                                //        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                //    }
                                //}

                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                }
                            }
                            if (int_intdcno != 0)
                            {
                                Str_invoiceno = Str_invoiceno + int_intdcno.ToString() + ",";
                            }
                            else
                            {
                                StrScript += "OSDN # or OSCN # Not Generated and Transfered";

                            }

                            /******************* For Auto mail *********************/
                            if (hid_voutype.Value.ToString() == "ProOSDNApproval")
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-OSDN", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                            }
                            else if (hid_type.Value.ToString() == "ProOSCNApproval")
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-OSCN", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                            }
                            /******************************************************/

                            //}

                            //}
                            if (countinv != 1)
                            {

                                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                                return;
                            }
                            if (Str_invoiceno.Length > 0)
                            {
                                Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                                // string StrScript = "";
                                if (hid_voutype.Value.ToString() == "OSSI")
                                {
                                    StrScript += "OSDN # " + Str_invoiceno + " Generated and Transfered";
                                }
                                else if (hid_voutype.Value.ToString() == "OSPI")
                                {
                                    StrScript += "OSCN # " + Str_invoiceno + " Generated and Transfered";
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
                            if (int_osdncn1 == 1)
                            {
                                StrScript += "Kindly Save the Proforma Voucher Again and Approve for" + str_osdncn1;
                            }

                        }

                    }
                }

                if (ch == false)
                {
                    Button lb = (Button)sender;
                    GridViewRow GvRow = (GridViewRow)lb.NamingContainer;
                    Row_ID = GvRow.RowIndex;
                    hid_voutype.Value = Grd_Approval.Rows[Row_ID].Cells[1].Text;
                    hid_voutypeid.Value = Grd_Approval.DataKeys[Row_ID].Values[2].ToString();
                    if (hid_voutype.Value.ToString() == "SALES INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "SALES INVOICE OC" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                    {

                        //foreach (GridViewRow row in Grd_Approval.Rows)
                        //{
                        type = Grd_Approval.Rows[Row_ID].Cells[22].Text;       //NewOne       //21/07/2022
                        string str_Voutype = type;
                        bool ChkLedger = true;
                        //   CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                        //if (Chk.Checked == true)
                        //{
                        countinv = 1;
                        int_Custid = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[1].ToString());
                        countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));
                        int_Refno = Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text);
                        int_Vouyear = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[0].ToString());

                        /******************* For Auto mail *********************/
                        hid_refno.Value = Grd_Approval.Rows[Row_ID].Cells[2].Text;
                        //hid_vouyear.Value = Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString();
                        hid_vouyear.Value = obj_da_FAVoucher.Getvouyearforautotransfer(int_bid).ToString();
                        /****************************************/

                        //hid_stamt.Value = row.Cells[7].Text.ToString();
                        //hid_supplyto.Value = row.Cells[8].Text.ToString();
                        hid_stamt.Value = Grd_Approval.Rows[Row_ID].Cells[19].Text;
                        hid_supplyto.Value = Grd_Approval.Rows[Row_ID].Cells[20].Text;


                        if (hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                        {
                            //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                            //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                            if (con == 1102 || con == 102)
                            {
                                if (countryid == 1102 || countryid == 102)
                                {
                                    Txt = (TextBox)Grd_Approval.Rows[Row_ID].FindControl("txtpercentage");         //NewOne       //21/07/2022
                                    if (Txt.Text.Trim().Length == 0)
                                    {
                                        //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "TDS", "alertify.alert('Enter TDS%');", true);
                                        if (int_TDS == 0)
                                        {
                                            str_TDS = "Enter TDS% for Ref number " + int_Refno;
                                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + str_TDS + "');", true);
                                            return;
                                        }
                                        else
                                        {
                                            str_TDS = str_TDS + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_TDS = 1;
                                        //continue;

                                    }
                                    else
                                    {
                                        tdstype = Grd_Approval.Rows[Row_ID].Cells[9].Text;
                                        tdsdesc = Grd_Approval.Rows[Row_ID].Cells[10].Text;// row.Cells[7].Text.ToString();
                                        if (tdstype == "" && tdstype == "")
                                        {
                                            if (int_tdstype == 0)
                                            {
                                                str_tdstype = "TDS Type and TDS Description is Empty for Ref #  " + int_Refno;
                                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + str_tdstype + "');", true);
                                                return;
                                            }
                                            else
                                            {
                                                str_tdstype = str_tdstype + "," + int_Refno;
                                            }
                                            Txt.Focus();
                                            int_tdstype = 1;
                                            //continue;
                                        }
                                        else if (tdstype == "")
                                        {
                                            if (int_tdstype == 0)
                                            {
                                                str_tdstype = "TDS Type is Empty for Ref # " + int_Refno;
                                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + str_tdstype + "');", true);
                                                return;
                                            }
                                            else
                                            {
                                                str_tdstype = str_tdstype + "," + int_Refno;
                                            }
                                            Txt.Focus();
                                            int_tdstype = 1;
                                            //continue;
                                        }

                                        else if (tdsdesc == "")
                                        {
                                            if (int_tdsdesc == 0)
                                            {
                                                str_tdsdesc = "TDS DESC is Empty for Ref # " + int_Refno;
                                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + str_tdstype + "');", true);
                                                return;
                                            }
                                            else
                                            {
                                                str_tdsdesc = str_tdsdesc + "," + int_Refno;
                                            }
                                            Txt.Focus();
                                            int_tdsdesc = 1;
                                            //continue;
                                        }

                                    }
                                }
                            }
                        }

                        if (hid_voutype.Value.ToString() == "PURCHASE INVOICE" || hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                        {
                            //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                            //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                            if (con == 1102 || con == 102)
                            {
                                if (countryid == 1102 || countryid == 102)
                                {

                                    if (hid_supplyto.Value != "")
                                    {
                                        dtcust1 = obj_da_BL.Gettdsforcustomer(Convert.ToInt32(hid_supplyto.Value));
                                    }
                                    if (dtcust1.Rows.Count > 0)
                                    {
                                        // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                                        StrScript += "TDS does not exist for SupplyTo customer .Kindly check Proforma PI " + int_Refno;
                                        //continue;

                                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                        return;
                                    }

                                    dtcust1 = obj_da_BL.Gettdsforcustomer(int_Custid);

                                    if (dtcust1.Rows.Count > 0)
                                    {
                                        // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                                        StrScript += "TDS does not exist for BillTo customer .Kindly check Proforma PA" + int_Refno;
                                        //continue;
                                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                        return;

                                    }
                                }
                            }

                        }

                        if (hid_supplyto.Value != "0")
                        {
                            cutname = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                        }
                        string emp = Grd_Approval.Rows[Row_ID].Cells[8].Text;
                        int empp = employeeobj.GetNEmpid(emp);
                        //if (empp == int_Empid)
                        //{
                        //    StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                        //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                        //    continue;
                        //}
                        DataTable dtnewexrate = obj_da_Invoice.GET_exratecheckLV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));
                        if (dtnewexrate.Rows.Count > 0)
                        {
                            StrScript += "Ex.Rate Different in Voucher Details " + int_Refno + ".Kindly check Proforma Invoice";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //continue;
                        }

                        DataTable dtnewgst = obj_da_Invoice.Get_checkwithSGSTPIGSTLV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));

                        if (dtnewgst.Rows.Count > 0)
                        {
                            StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice/PI";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //continue;
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                            return;
                        }

                        DataTable dtnewgst1 = obj_da_Invoice.Get_checkwithSGSTPIGST1LV(int_Refno, int_bid, int_Vouyear, Convert.ToInt32(hid_voutypeid.Value));

                        if (dtnewgst1.Rows.Count > 0)
                        {
                            StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice/PI";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //continue;
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                            return;
                        }
                        if ((hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)))
                        {
                            Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmtLV(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                            if (Dtckeck.Rows.Count > 0)
                            {
                                StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                //continue;
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }
                        }

                        if ((hid_voutype.Value.ToString() == "PURCHASE INVOICE" && (countryid == 1102 || countryid == 102)) || (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC" && (countryid == 1102 || countryid == 102)))
                        {
                            Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmtLV(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                            if (Dtckeck.Rows.Count > 0)
                            {
                                StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Credit Note Operation";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                //continue;
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }
                        }

                        // Einvoice newly added start//
                        if ((hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)) || (hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)))
                        {
                            DataTable dthsncode = obj_da_Approval.GetchksaccodeforvoucherLV(Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Refno, int_Vouyear, "I");
                            if (dthsncode.Rows.Count > 0)
                            {
                                StrScript += "Kindly update the SACCode in master " + int_Refno + ".check Proforma Invoice";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                //continue;
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }
                        }

                        if (hid_voutype.Value.ToString() == "SALES INVOICE OC" || hid_voutype.Value.ToString() == "SALES INVOICE")
                        {
                            string custid1 = objnew.getloctdetails(Convert.ToInt32(hid_supplyto.Value));

                            if (custid1 == "1")
                            {
                                //StrScript += "kindly update the Location or State name for customer " + int_Refno + ".check Proforma Invoice";
                                StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Please Update Location / State / Pincode of " + cutname + ",";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                //continue;
                            }

                            string custid2 = objnew.getloctdetails(Convert.ToInt32(int_Custid));

                            if (custid2 == "1")
                            {
                                StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Please Update Location / State / Pincode of " + cutname + ",";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                //continue;
                            }
                        }

                        string custid11 = objnew.getholdcutdetails(Convert.ToInt32(hid_supplyto.Value));

                        if (custid11 == "1")
                        {
                            //StrScript += "kindly update the Location or State name for customer " + int_Refno + ".check Proforma Invoice";
                            StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Customer " + cutname + " status is Hold please discuss with Finance team" + ",";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                            //continue;
                        }

                        string custid21 = objnew.getholdcutdetails(Convert.ToInt32(int_Custid));

                        if (custid21 == "1")
                        {
                            StrScript += "Proforma Invoice #" + int_Refno.ToString() + "- Customer " + cutname + " status is Hold please discuss with Finance team" + ",";
                            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                            //continue;
                        }


                        if (Session["hid_gstdate"] != null)
                        {
                            if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                            {

                                if (hid_supplyto.Value != "0")
                                {

                                    if (Convert.ToDouble(hid_stamt.Value) > 0)
                                    {

                                        int int_custidnew;
                                        DataTable dt_list = new DataTable();
                                       // DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                        //int int_custid = Convert.ToInt32(hdncustid.Value);
                                        if (!string.IsNullOrEmpty(Grd_Approval.Rows[Row_ID].Cells[20].Text))   //NewOne       //21/07/2022
                                        {
                                            int_custidnew = Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[20].Text);  //NewOne       //21/07/2022
                                            dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                        }

                                        if (dt_list.Rows.Count > 0)
                                        {
                                            if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                            {
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
                                                    //continue;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            //StrScript += "State Name not Updated in Master Kindly update Master Customer for" + row.Cells[2].Text.ToString();
                                            if (statename == 0)
                                            {
                                                statename_ = cutname;
                                            }
                                            else
                                            {
                                                statename_ = " ," + cutname;
                                            }
                                            statename = 1;
                                            //continue;
                                        }

                                    }

                                }
                                else
                                {
                                    //StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;
                                    if (supplyto == 0)
                                    {
                                        supplyto_ = int_Refno.ToString();
                                    }
                                    else
                                    {
                                        supplyto_ = " ," + int_Refno.ToString();
                                    }
                                    supplyto = 1;
                                    //continue;
                                }
                            }
                        }

                        string inapproved = obj_da_Approval.CHKVoucherbosLV(int_Refno);

                        if ((inapproved.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (inapproved.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)))
                        {
                            invoinumber = obj_da_Approval.UpdProApprovalnewBOSLV(0, int_bid, int_Refno, int_Vouyear, Grd_Approval.Rows[Row_ID].Cells[4].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                            bos = true;

                            //  logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");

                            if (invoinumber != 0)
                            {
                                Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                            }
                            else
                            {
                                Str_invoicenonew = "Invoice not Approved";
                            }
                        }

                        ////hari /// 09_09_2022 //std
                        string invapprovegst = obj_da_Approval.SPCHECkfrightLV(int_Refno);

                        if ((invapprovegst.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (invapprovegst.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)))
                        {

                            invoinumberfright = obj_da_Approval.UpdProApprovalnewLV(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, Grd_Approval.Rows[Row_ID].Cells[4].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                            // logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "");

                            // logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", int_bid, "", 0, 0, "", 1);

                            //hide on 14Jun2022 -- nambi
                            ////4 invoice
                            //invoinumber = obj_da_Approval.UpdProApprovalnew(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                            // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "");

                            if (invoinumberfright != 0)
                            {
                                Str_invoicenonew = Str_invoicenonew + invoinumberfright.ToString() + ",";
                            }
                            else
                            {
                                Str_invoicenonew = "Invoice not Approved";
                            }

                            div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                            string custid1ung = objnew.getunregcustvouchers(invoinumberfright, int_Vouyear, int_bid, "I");

                            if (div_id == "1" && custid1ung == "0" && (countryid == 1102 || countryid == 102))
                            {

                                try
                                {

                                    //int vouno = 1018;  // 793 ,826
                                    //int bid = 13;
                                    //int vouyear = 2020;
                                    //int cid = 1;
                                    string json1 = objnew.getgstdetails(invoinumberfright, int_bid, int_Vouyear, "I");
                                    //   DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", "{\r\n    \"Version\": \"1.1\",\r\n    \"TranDtls\": {\r\n        \"TaxSch\": \"GST\",\r\n        \"SupTyp\": \"B2B\",\r\n        \"RegRev\": \"N\"\r\n    },\r\n    \"DocDtls\": {\r\n        \"Typ\": \"INV\",\r\n        \"No\": \"IN2021CHEOE100\",\r\n        \"Dt\": \"13\\/05\\/2020\"\r\n    },\r\n    \"SellerDtls\": {\r\n        \"Gstin\": \"29AAFCC9980MZZT\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"29\"\r\n    },\r\n    \"BuyerDtls\": {\r\n        \"Gstin\": \"07AAACA4691C2ZY\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Pos\": \"07\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"07\"\r\n    },\r\n    \"ItemList\": [{\r\n        \"SlNo\": \"1\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5.00,\r\n        \"TotAmt\": 388.25,\r\n        \"AssAmt\": 388.25,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 69.89,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 458.14\r\n    }, {\r\n        \"SlNo\": \"2\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 4050.00,\r\n        \"TotAmt\": 4050.00,\r\n        \"AssAmt\": 4050.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 729.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 4779.00\r\n    }, {\r\n        \"SlNo\": \"3\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5500.00,\r\n        \"TotAmt\": 5500.00,\r\n        \"AssAmt\": 5500.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 990.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 6490.00\r\n    }],\r\n    \"ValDtls\": {\r\n        \"AssVal\": 9938.25,\r\n        \"CgstVal\": 0.00,\r\n        \"SgstVal\": 0.00,\r\n        \"IgstVal\": 1788.89,\r\n        \"RndOffAmt\": 0.00,\r\n        \"TotInvVal\": 11727.00\r\n    }\r\n}\r\n\r\n");

                                    string datajson = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json1);

                                    //DataTable dtjson = ConvertJsonToDatatable(datajson);
                                    // string l0 = dtjson.Rows[0][0].ToString().Trim();
                                    DataTable dtjson = new DataTable();
                                    string status = "";
                                    if (datajson != null)
                                    {
                                        dtjson = ConvertJsonToDatatable(datajson);
                                        status = dtjson.Rows[0][0].ToString().Trim();
                                    }
                                    else
                                    {
                                        status = "0";
                                    }

                                    string message1 = "";
                                    string IRN1 = "";
                                    string Ackdt = "";
                                    string Ackno = "";
                                    string status1 = "";
                                    string SignedQRCode = "";
                                    string SignedInvoice = "";

                                    string uuid = "";
                                    string SignedQrCodeImgUrl = "";
                                    string IrnStatus = "";
                                    string EwbStatus = "";
                                    string Irp = "";
                                    string EwbDt = "";
                                    string EwbNo = "";
                                    string EwbValidTill = "";
                                    string Remarks = "";

                                    if (status == "1")
                                    {
                                        //message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                        //IRN1 = dtjson.Rows[0][2].ToString().Replace('"', ' ').Trim();
                                        //Ackdt = dtjson.Rows[0][3].ToString().Replace('"', ' ').Trim();
                                        //Ackno = dtjson.Rows[0][4].ToString().Replace('"', ' ').Trim();
                                        //status1 = dtjson.Rows[0][5].ToString().Replace('"', ' ').Trim();
                                        //SignedQRCode = dtjson.Rows[0][6].ToString().Replace('"', ' ').Trim();

                                        //SignedInvoice = dtjson.Rows[0][7].ToString().Replace('"', ' ').Trim();

                                        //uuid = dtjson.Rows[0][8].ToString().Replace('"', ' ').Trim();
                                        //SignedQrCodeImgUrl = dtjson.Rows[0][9].ToString().Replace('"', ' ').Trim();
                                        //IrnStatus = dtjson.Rows[0][10].ToString().Replace('"', ' ').Trim();
                                        //EwbStatus = dtjson.Rows[0][11].ToString().Replace('"', ' ').Trim();
                                        //Irp = dtjson.Rows[0][12].ToString().Replace('"', ' ').Trim();

                                        message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();           //	1                       
                                        IRN1 = dtjson.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2
                                        Ackdt = dtjson.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                        Ackno = dtjson.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                        status1 = dtjson.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                        SignedQRCode = dtjson.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                        SignedInvoice = dtjson.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11

                                        uuid = dtjson.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                        SignedQrCodeImgUrl = dtjson.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                        IrnStatus = dtjson.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                        EwbStatus = dtjson.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                        Irp = dtjson.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                        EwbDt = dtjson.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                        EwbNo = dtjson.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                        EwbValidTill = dtjson.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                        Remarks = dtjson.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8

                                        objnew.insmastergstdetails(invoinumberfright, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "I", EwbDt, EwbNo, EwbValidTill, Remarks);

                                    }
                                    else
                                    {
                                        //  l1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                        if (datajson != null)
                                        {
                                            message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                        }
                                        else
                                        {
                                            message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                        }
                                        objnew.insmastergstdetails(invoinumberfright, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "I", "", "", "", "");

                                    }

                                }
                                catch (Exception ex)
                                {
                                    string message = ex.Message.ToString();
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                                }
                            }
                        }

                        ////hari /// 09_09_2022 //END

                        string inapproved1 = obj_da_Approval.CHKVoucherinvgenLV(int_Refno);

                        if ((inapproved1.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (inapproved1.ToString() == "TRUE" && hid_voutype.Value.ToString() == "SALES INVOICE OC" && (countryid == 1102 || countryid == 102)))
                        {
                            int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                            if (hid_voutype.Value.ToString() == "SALES INVOICE")
                            {
                                obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Sales Invoice",
                     Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), hid_voutype.Value.ToString(), 12);


                            }
                            else
                            {
                                obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice FC");
                                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Sales Invoice",
                     Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), "Invoice FC", 28);

                            }

                            // obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());

                            // Einvoice newly added satrt//

                            div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                            string custid1ung = objnew.getunregcustvouchers(int_Invoiceno, int_Vouyear, int_bid, "I");

                            if (div_id == "1" && custid1ung == "0" && (countryid == 1102 || countryid == 102))
                            {

                                try
                                {

                                    string json2 = objnew.getgstdetails(int_Invoiceno, int_bid, int_Vouyear, "I");

                                    string datajson1 = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json2);
                                    DataTable dtjson1 = new DataTable();
                                    string status = "";
                                    if (datajson1 != null)
                                    {
                                        dtjson1 = ConvertJsonToDatatable(datajson1);
                                        status = dtjson1.Rows[0][0].ToString().Trim();
                                    }
                                    else
                                    {
                                        status = "0";
                                    }

                                    string message1 = "";
                                    string IRN1 = "";
                                    string Ackdt = "";
                                    string Ackno = "";
                                    string status1 = "";
                                    string SignedQRCode = "";
                                    string SignedInvoice = "";

                                    string uuid = "";
                                    string SignedQrCodeImgUrl = "";
                                    string IrnStatus = "";
                                    string EwbStatus = "";
                                    string Irp = "";

                                    string EwbDt = "";
                                    string EwbNo = "";
                                    string EwbValidTill = "";
                                    string Remarks = "";

                                    if (status == "1")
                                    {

                                        message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();          //	1   

                                        IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2

                                        gstirn_ = gstirn_ + "," + message1 + " " + IRN1 + " ,";
                                        gstirn = 0;

                                        Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                        Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                        status1 = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                        SignedQRCode = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                        SignedInvoice = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11

                                        uuid = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                        SignedQrCodeImgUrl = dtjson1.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                        IrnStatus = dtjson1.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                        EwbStatus = dtjson1.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                        Irp = dtjson1.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                        EwbDt = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                        EwbNo = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                        EwbValidTill = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                        Remarks = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8

                                        objnew.insmastergstdetails(int_Invoiceno, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "I", EwbDt, EwbNo, EwbValidTill, Remarks);

                                    }
                                    else
                                    {
                                        if (datajson1 != null)
                                        {
                                            message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();

                                            gstirnerr_ = gstirnerr_ + "," + message1;
                                            gstirnerr = 1;

                                        }
                                        else
                                        {
                                            message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                        }
                                        objnew.insmastergstdetails(int_Invoiceno, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "I", "", "", "", "");
                                    }

                                }
                                catch (Exception ex)
                                {
                                    string message = ex.Message.ToString();
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                                }

                            }

                            // Einvoice newly added end//
                        }
                        else if ((hid_voutype.Value.ToString() == "SALES INVOICE" && (countryid == 1102 || countryid == 102)) || (hid_voutype.Value.ToString() == "SALES INVOICE OC " && (countryid == 1102 || countryid == 102)))
                        {
                            int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                            if (hid_voutype.Value.ToString() == "SALES INVOICE")
                            {
                                obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Sales Invoice",
                                              Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), hid_voutype.Value.ToString(), 12);

                            }
                            else
                            {
                                obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice FC");
                                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Sales Invoice",
                    Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), "Invoice FC", 28);

                            }
                            //  obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "Invoice");
                        }
                        else
                        {
                            if (hid_voutype.Value.ToString() != "SALES INVOICE" && hid_voutype.Value.ToString() != "SALES INVOICE OC")
                            {
                                int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalLV(int_bid, hid_voutype.Value.ToString());
                                // obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno,  hid_voutype.Value.ToString());
                                if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                                {
                                    obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA");
                                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                    objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Purchase Invoice",
                   Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), hid_voutype.Value.ToString(), 13);

                                }
                                else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                                {
                                    obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA FC");
                                    hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                                    objRpt.InsOEeventdetailsTask(Convert.ToInt32("0"), "", "", "Purchase Invoice",
                    Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), hid_voutype.Value.ToString(), 29);

                                }
                                //  obj_da_Approval.Updproapp(int_Refno, int_Empid, int_bid, int_Invoiceno, "PA");

                            }

                        }

                        log1.Info("********************************************************************************************************************************************************");
                        log1.Info("Transfer To Commercial PA After Approval");

                        if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                        {

                            log1.Info("Before TDS- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                            int_Custid = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[1].ToString());

                            countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));
                            //Amount = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[4].Text.ToString()));
                            //gstamt = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[12].Text.ToString()));
                            // Amount = Amount - gstamt;
                            DataTable Dt_LimitCheck = new DataTable();
                            int_Vouyear1 = Convert.ToInt32(obj_da_FA.Getvouyearforautotransfer(int_bid).ToString());
                            Dt_LimitCheck = obj_da_Approval.GetCustAmtLimt(int_Custid, int_bid);
                            Amount = obj_da_Approval.GetVoucherAmount4TDS(int_Invoiceno, int_bid, int_Vouyear1, "P");
                            log1.Info("Before TDS Procedure1- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");
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
                                        log1.Info("Before TDS Amount > 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

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
                                            log1.Info("Before TDS Amount < 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                        }
                                        else
                                        {
                                            TDS = Convert.ToDouble(Dt_LimitCheck.Rows[0]["tdsemp"].ToString());
                                            TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                            log1.Info("Before TDS Amount = 0- (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

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
                                        //  TDSAmount = Amount * (TDS / 100);
                                        TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));
                                    }
                                }

                            }
                            else
                            {
                                //DataTable dcon = Appobj.Checkcountry(Convert.ToInt32(row.Cells[0].Text.ToString()));
                                //int con = Convert.ToInt32(dcon.Rows[0]["countryid"]);
                                if (con == 1102 || con == 102)
                                {
                                    ///////////haribalaji ////////2924---------------
                                    if (Txt.Text.ToString() == "")
                                    {
                                        Txt.Text = "0";
                                    }
                                    ///////////haribalaji ////////2924---------------
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

                            log1.Info("Before TDS insert  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                            CSTAmount = Amount - TDSAmount;

                            if (str_Voutype == "S")
                            {
                                obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Invoiceno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear1);
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
                            string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";
                            if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                            {
                                str_Voutype = "P";              //CN-OPS  -->P  //Admin-CN-->S//  Other-CN-->E
                                type = "P";
                            }


                            log1.Info("Before TDS insert-1  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                            if (ChkLedger == true)
                            {
                                if ((countryid == 1102) || (countryid == 102))
                                {
                                    log1.Info("Before TDS insert-2  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                    obj_da_Invoice.InsertPATDS(int_Invoiceno, str_Voutype, int.Parse(Session["LoginBranchid"].ToString()), int_Custid, int_Vouyear1, CSTAmount, TDSAmount, "", Convert.ToDouble(Txt.Text.ToString()));
                                    log1.Info("Before TDS insert-3  - (PANO- " + int_Invoiceno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear1 + ")");

                                }
                                //if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                // {
                                //     str_Voutype="P";
                                //     type = "P";
                                // }

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

                                logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Invoiceno, int_Invoiceno, Str_ddlNarration, Str_ddlReference, Convert.ToInt32(Session["LoginBranchid"]));

                                int int_Ledgerid = 0;
                                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Session["FADbname"].ToString());
                                int_Voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_ddlVoucherType, Session["FADbname"].ToString());
                                if (int_Ledgerid == 0)
                                {
                                    int_Ledgerid = Fn_Getcustomergroupid(int_Custid, Str_ddlVoucherType);
                                }
                                //DateTime dtdate = DateTime.Parse(Utility.fn_ConvertDate(Grd_Approval.Rows[row.RowIndex].Cells[12].Text));
                                DateTime dtdate = DateTime.Parse((Grd_Approval.Rows[Row_ID].Cells[21].Text));     //NewOne       //21/07/2022
                                string Str_CustType = obj_da_Customer.GetCustomerType(int_Custid);
                                if (Str_CustType == "P" || Str_CustType == "E")
                                {
                                    DataTable dt = new DataTable();
                                    dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "CNHead", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()));
                                    string Str_Curr = "";
                                    double F_Curr = 0;
                                    if (dt.Rows.Count > 0)
                                    {
                                        Str_Curr = dt.Rows[0]["curr"].ToString();
                                        F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                    }
                                    obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, Str_Curr, F_Curr, int_Custid);
                                }
                                else
                                {

                                    obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, "", 0, int_Custid);
                                }
                            }

                            //str_favourname = row.Cells[2].Text.ToString();
                            //obj_da_Cheque.UpdChequeRequest(int_Invoiceno, int.Parse(Session["Vouyear"].ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int_Empid, "PA", char.Parse("C"), "", str_favourname);

                        }

                        if (hid_voutype.Value.ToString() == "SALES INVOICE")
                        {//raj

                            //logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");
                            //if (inapproved.ToString() == "TRUE")
                            //{

                            //    if (invoinumber != 0)
                            //    {
                            //        // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");
                            //        logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");
                            //    }
                            //}

                            //string retransfer = "N";
                            //if (Session["vouid"] != null)
                            //{

                            //    retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Session["FADbname"].ToString());

                            //    if (retransfer == "Y")
                            //    {
                            //        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");

                            //    }
                            //    Session["vouid"] = null;

                            //}
                            //try
                            //{
                            //    obj_dt1 = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                            //    if (obj_dt1.Rows.Count > 0)
                            //    {
                            //        int int_custid = int.Parse(obj_dt1.Rows[0].ItemArray[4].ToString());
                            //        DateTime date_Voudate = DateTime.Parse(obj_dt1.Rows[0].ItemArray[1].ToString());
                            //        int int_Ledgerid = 0;
                            //        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                            //        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Invoices", Session["FADbname"].ToString());
                            //        if (int_Ledgerid == 0)
                            //        {
                            //            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                            //        }
                            //        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'I', int_Vouyear, int_bid, double.Parse( Grd_Approval.Rows[Row_ID].Cells[7].Text.ToString()), "", 0, int_custid);
                            //    }
                            //}

                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    obj_da_Log.InsLogDetail(int_Empid, 1016, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;

                                case "FI":
                                    obj_da_Log.InsLogDetail(int_Empid, 1023, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;

                                case "AE":
                                    obj_da_Log.InsLogDetail(int_Empid, 1030, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;

                                case "AI":
                                    obj_da_Log.InsLogDetail(int_Empid, 1037, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;
                                case "CH":
                                    obj_da_Log.InsLogDetail(int_Empid, 1043, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;

                            }
                        }
                        else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                        {
                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;

                                case "FI":
                                    obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;

                                case "AE":
                                    obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;

                                case "AI":
                                    obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;
                                case "CH":
                                    obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                    break;

                            }
                        }

                        Str_invoiceno = Str_invoiceno + int_Invoiceno.ToString() + ",";

                        /******************* For Auto mail *********************/
                        if (hid_voutype.Value.ToString() == "SALES INVOICE")
                        {
                            if (bos == false)
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-Invoices", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                            }
                            else if (bos == true)
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "BOS", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                            }
                        }
                        else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                        {
                            // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-CNOPS", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                        }

                        /******************************************************/

                        //}
                        //else if (countinv != 1)
                        //{

                        //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        //    return;
                        //}
                        //}
                        if (countinv != 1)
                        {

                            ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                            return;
                        }
                        if (Str_invoiceno.Length > 0)
                        {
                            Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                            if (hid_voutype.Value.ToString() == "SALES INVOICE")
                            {

                                StrScript += "Invoice # " + Str_invoiceno + " Generated and Transfered";

                                //if (invoinumber != 0)
                                //{
                                //    StrScript += "BOS # " + invoinumber + " Generated and Transfered";
                                //}
                                //if (int_Invoiceno != 0)
                                //{
                                //    StrScript += "Invoice # " + int_Invoiceno + " Generated and Transfered";
                                //}
                            }
                            else if (hid_voutype.Value.ToString() == "SALES INVOICE OC")
                            {

                                StrScript += "Invoice OC # " + Str_invoiceno + " Generated and Transfered";

                            }
                            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE")
                            {
                                StrScript += "PI # " + Str_invoiceno + " Generated and Transfered";
                            }

                            else if (hid_voutype.Value.ToString() == "PURCHASE INVOICE OC")
                            {
                                StrScript += "PI OC # " + Str_invoiceno + " Generated and Transfered";
                            }



                            else if (hid_voutype.Value.ToString() == "Transfer To Commercial CN")
                            {
                                StrScript += "CN # " + Str_invoiceno + " Generated and Transfered";
                            }
                            else if (hid_voutype.Value.ToString() == "Transfer To Commercial DN")
                            {
                                StrScript += "DN # " + Str_invoiceno + " Generated and Transfered";
                            }

                            /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                             {
                                 StrScript = "OSDN # " + Str_invoiceno + " Generated and Transfered";
                             }
                             else if (hid_type.Value.ToString() == "ProOSCNApproval")
                             {
                                 StrScript = "OSCN # " + Str_invoiceno + " Generated and Transfered";
                             }*/

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

                        if (int_TDS == 1)
                        {
                            StrScript += " " + str_TDS;
                        }

                        if (int_tdstype == 1)
                        {
                            StrScript += " " + str_tdstype;
                        }

                        if (int_tdsdesc == 1)
                        {
                            StrScript += " " + str_tdsdesc;
                        }
                        if (countinv != 1)
                        {

                            StrScript += "Check Atleast One Ref#";
                            //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                            //return;
                        }
                        if (invoinumber != 0)
                        {
                            // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                            StrScript += "BOS # " + Str_invoicenonew;
                        }

                        if (Str_invoicenonew != "")
                        {
                            // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                            StrScript += "Freight Inv # " + Str_invoicenonew;
                        }

                        // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert(" + StrScript + ");", true);
                    }


                    //////////////////////////////////////////////////////////////////////////////////////////////////





                    else if (hid_voutype.Value.ToString() == "OSSI" || hid_voutype.Value.ToString() == "OSPI")
                    {
                        //foreach (GridViewRow row in Grd_Approval.Rows)
                        //{
                        //  CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                        //if (Chk.Checked == true)
                        //{
                        countinv = 1;
                        int_Refno = int.Parse(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString());
                        jobnoosdn = int.Parse(Grd_Approval.Rows[Row_ID].Cells[4].Text.ToString());
                        int_Vouyear = int.Parse(Grd_Approval.DataKeys[Row_ID].Values[0].ToString());
                        if (hid_voutypeid.Value == "5")
                        {
                            hid_type.Value = "ProOSDNApproval";
                        }
                        else
                        {
                            hid_type.Value = "ProOSCNApproval";
                        }
                        /******************* For Auto mail *********************/
                        hid_refno.Value = Grd_Approval.Rows[Row_ID].Cells[2].Text;
                        hid_vouyear.Value = Grd_Approval.DataKeys[Row_ID].Values[0].ToString();
                        /****************************************/

                        // dcno = Approveobj.UpdProApprovalOSDCN(refno, strblno, Login.logempid, strTranType, vouyear, branchid, strFType)
                        hid_stamt.Value = Grd_Approval.Rows[Row_ID].Cells[19].Text;
                        hid_supplyto.Value = Grd_Approval.Rows[Row_ID].Cells[20].Text;

                        //hid_stamt.Value = row.Cells[16].Text.ToString();         //NewOne       //21/07/2022
                        //        hid_supplyto.Value = row.Cells[17].Text.ToString();      //NewOne       //21/07/2022
                        string emp = Grd_Approval.Rows[Row_ID].Cells[8].Text;
                        int empp = employeeobj.GetNEmpid(emp);

                        dtosdn = obj_da_OSDNCN.GetCheckosdncnnewLV(Str_Trantype, jobnoosdn, int_bid);
                        int cnt = 0;
                        cnt = dtosdn.Rows.Count;
                        if (cnt == 1)
                        {
                            if (int_osdncn1 == 0)
                            {
                                str_osdncn1 = int_Refno.ToString();
                            }
                            else
                            {
                                str_osdncn1 = " ," + int_Refno.ToString();
                            }
                            int_osdncn1 = 1;
                            //continue;

                        }

                        else
                        {
                            DataTable dtt = new DataTable();

                            DataTable dtnewexrate1 = obj_da_Invoice.GET_exratechecknewLV(int_Refno, int_bid, int_Vouyear, jobnoosdn, Str_Trantype, 0);
                            if (dtnewexrate1.Rows.Count > 0)
                            {
                                StrScript += "Ex.Rate Different in Voucher Details " + int_Refno + ".Kindly check Proforma Invoice";
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }

                            dtt = obj_da_Approval.getdebitadviseactamtcheckLV(int_Vouyear, int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), jobnoosdn, Str_Trantype, hid_voutype.Value.ToString());
                            if (dtt.Rows.Count > 0)
                            {
                                StrScript += "Taxable amount is mismatch for the Ref # : " + int_Refno + ",.Kindly update the ProOSDN/CN charge again and Save it";
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }

                            int amount1 = obj_da_Approval.getacosdncnamoutcheckLV(Str_Trantype, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Refno, hid_voutype.Value.ToString());
                            if (amount1 == 1)
                            {
                                StrScript += "Taxable amount is mismatch for the Ref # : " + int_Refno + ",.Kindly update the ProOSDN/CN charge again and Save it";
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }
                            else
                            {

                            }

                            int check = obj_da_Approval.CheckCBMzero4osv(int_Refno, int_bid, Convert.ToInt32(hid_voutypeid.Value));
                            if (check == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Unit details not calculated properly,Kindly update the charge details again for Ref # " + int_Refno + "');", true);
                                return;
                            }


                            hid_date.Value = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());

                            if (hid_voutypeid.Value == "5")
                            {
                                int_intdcno = obj_da_Approval.UpdproappOSDNCN(int_Refno, int_Empid, int_bid, int_Invoiceno, "ProOSDNApproval");

                                string x = Grd_Approval.Rows[Row_ID].Cells[1].Text.ToString();
                                objRpt.InsOEeventdetailsTask(0, "", "", "OSDN Generation",
                     Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), "ProOSDNApproval", 26);

                                // hid_type.Value = "ProOSDNApproval";
                            }
                            else
                            {
                                int_intdcno = obj_da_Approval.UpdproappOSDNCN(int_Refno, int_Empid, int_bid, int_Invoiceno, "ProOSCNApproval");
                                objRpt.InsOEeventdetailsTask(0, "", "", "OSCN Generation",
                      Convert.ToDateTime(Utility.fn_ConvertDate(hid_date.Value.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[2].Text.ToString()), "ProOSCNApproval", 27);

                                //  hid_type.Value = "ProOSCNApproval";
                            }




                            // int_intdcno = obj_da_Approval.UpdproappOSDNCNOSV(int_Refno, Grd_Approval.Rows[Row_ID].Cells[4].Text.ToString(), int_Empid, Str_Trantype, int_Vouyear, int_bid, int.Parse(Grd_Approval.DataKeys[Row_ID].Values[2].ToString()));

                            //int_intdcno = obj_da_Approval.UpdProApprovalOSDCN(int_Refno, Convert.ToInt32(row.Cells[1].Text.ToString()), int_Empid, Str_Trantype, int_Vouyear, int_bid, hid_type.Value.ToString());
                            //    obj_da_Approval.insForOSDNCNDNCNNumberLV(int_intdcno,  hid_voutype.Value.ToString(), Convert.ToInt32(Session["LoginBranchid"]),  Convert.ToInt32(Grd_Approval.Rows[Row_ID].Cells[4].Text), Str_Trantype, int_Refno);
                            //einvoice start 28 may 22
                            if (hid_voutype.Value.ToString() == "OSSI" && int_intdcno > 0)
                            {

                                //newly GST added

                                // Einvoice newly added satrt//

                                div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                //  div_id = "0";

                                string custid1ung = objnew.getunregcustvouchers(int_intdcno, int_Vouyear, int_bid, "D");


                                if (div_id == "1" && custid1ung == "0")
                                {

                                    try
                                    {

                                        //int vouno = 1018;  // 793 ,826
                                        //int bid = 13;
                                        //int vouyear = 2020;
                                        //int cid = 1;

                                        //invoinumber = 700;
                                        //int_bid = 1;
                                        //int_Vouyear = 2020;
                                        //int_divisionid = 1;
                                        string json2 = objnew.getgstdetails(int_intdcno, int_bid, int_Vouyear, "D");
                                        //   DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", "{\r\n    \"Version\": \"1.1\",\r\n    \"TranDtls\": {\r\n        \"TaxSch\": \"GST\",\r\n        \"SupTyp\": \"B2B\",\r\n        \"RegRev\": \"N\"\r\n    },\r\n    \"DocDtls\": {\r\n        \"Typ\": \"INV\",\r\n        \"No\": \"IN2021CHEOE100\",\r\n        \"Dt\": \"13\\/05\\/2020\"\r\n    },\r\n    \"SellerDtls\": {\r\n        \"Gstin\": \"29AAFCC9980MZZT\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"29\"\r\n    },\r\n    \"BuyerDtls\": {\r\n        \"Gstin\": \"07AAACA4691C2ZY\",\r\n        \"LglNm\": \"DEMO CUSTOMER21577\",\r\n        \"Pos\": \"07\",\r\n        \"Addr1\": \"CUSTOMER ADDRESS\",\r\n        \"Loc\": \"Supreme Court\",\r\n        \"Pin\": 110001,\r\n        \"Stcd\": \"07\"\r\n    },\r\n    \"ItemList\": [{\r\n        \"SlNo\": \"1\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5.00,\r\n        \"TotAmt\": 388.25,\r\n        \"AssAmt\": 388.25,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 69.89,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 458.14\r\n    }, {\r\n        \"SlNo\": \"2\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 4050.00,\r\n        \"TotAmt\": 4050.00,\r\n        \"AssAmt\": 4050.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 729.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 4779.00\r\n    }, {\r\n        \"SlNo\": \"3\",\r\n        \"IsServc\": \"Y\",\r\n        \"HsnCd\": \"996759\",\r\n        \"UnitPrice\": 5500.00,\r\n        \"TotAmt\": 5500.00,\r\n        \"AssAmt\": 5500.00,\r\n        \"SgstAmt\": 0.00,\r\n        \"CgstAmt\": 0.00,\r\n        \"IgstAmt\": 990.00,\r\n        \"GstRt\": 18.00,\r\n        \"TotItemVal\": 6490.00\r\n    }],\r\n    \"ValDtls\": {\r\n        \"AssVal\": 9938.25,\r\n        \"CgstVal\": 0.00,\r\n        \"SgstVal\": 0.00,\r\n        \"IgstVal\": 1788.89,\r\n        \"RndOffAmt\": 0.00,\r\n        \"TotInvVal\": 11727.00\r\n    }\r\n}\r\n\r\n");

                                        string datajson1 = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json2);
                                        DataTable dtjson1 = new DataTable();
                                        string status = "";
                                        if (datajson1 != null)
                                        {
                                            dtjson1 = ConvertJsonToDatatable(datajson1);
                                            status = dtjson1.Rows[0][0].ToString().Trim();
                                        }
                                        else
                                        {
                                            status = "0";
                                        }

                                        string message1 = "";
                                        string IRN1 = "";
                                        string Ackdt = "";
                                        string Ackno = "";
                                        string status1 = "";
                                        string SignedQRCode = "";
                                        string SignedInvoice = "";

                                        string uuid = "";
                                        string SignedQrCodeImgUrl = "";
                                        string IrnStatus = "";
                                        string EwbStatus = "";
                                        string Irp = "";

                                        string EwbDt = "";
                                        string EwbNo = "";
                                        string EwbValidTill = "";
                                        string Remarks = "";

                                        if (status == "1")
                                        {
                                            //message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();
                                            //IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();
                                            //Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();
                                            //Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();
                                            //status1 = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim();
                                            //SignedQRCode = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim();

                                            //SignedInvoice = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();



                                            //uuid = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();
                                            //SignedQrCodeImgUrl = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim();
                                            //IrnStatus = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim();
                                            //EwbStatus = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim();
                                            //Irp = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();


                                            //message1 = dtjson1.Rows[0]["message"].ToString().Replace('"', ' ').Trim();
                                            //IRN1 = dtjson1.Rows[0]["Irn"].ToString().Replace('"', ' ').Trim();
                                            //Ackdt = dtjson1.Rows[0]["AckDt"].ToString().Replace('"', ' ').Trim();
                                            //Ackno = dtjson1.Rows[0]["AckNo"].ToString().Replace('"', ' ').Trim();
                                            //status1 = dtjson1.Rows[0]["Status"].ToString().Replace('"', ' ').Trim();
                                            //SignedQRCode = dtjson1.Rows[0]["SignedQRCode"].ToString().Replace('"', ' ').Trim();

                                            //SignedInvoice = dtjson1.Rows[0]["SignedInvoice"].ToString().Replace('"', ' ').Trim();



                                            //uuid = dtjson1.Rows[0]["uuid"].ToString().Replace('"', ' ').Trim();
                                            //SignedQrCodeImgUrl = dtjson1.Rows[0]["SignedQrCodeImgUrl"].ToString().Replace('"', ' ').Trim();
                                            //IrnStatus = dtjson1.Rows[0]["IrnStatus"].ToString().Replace('"', ' ').Trim();
                                            //EwbStatus = dtjson1.Rows[0]["EwbStatus"].ToString().Replace('"', ' ').Trim();
                                            //Irp = dtjson1.Rows[0]["Irp"].ToString().Replace('"', ' ').Trim();

                                            //EwbDt = dtjson1.Rows[0]["EwbDt"].ToString().Replace('"', ' ').Trim();
                                            //EwbNo = dtjson1.Rows[0]["EwbNo"].ToString().Replace('"', ' ').Trim();
                                            //EwbValidTill = dtjson1.Rows[0]["EwbValidTill"].ToString().Replace('"', ' ').Trim();
                                            //Remarks = dtjson1.Rows[0]["Remarks"].ToString().Replace('"', ' ').Trim();



                                            message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();          //	1   



                                            IRN1 = dtjson1.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2

                                            gstirn_ = gstirn_ + "," + message1 + " " + IRN1 + " ,";
                                            gstirn = 0;

                                            Ackdt = dtjson1.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                                            Ackno = dtjson1.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                                            status1 = dtjson1.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                                            SignedQRCode = dtjson1.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                                            SignedInvoice = dtjson1.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11



                                            uuid = dtjson1.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                                            SignedQrCodeImgUrl = dtjson1.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                                            IrnStatus = dtjson1.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                                            EwbStatus = dtjson1.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                                            Irp = dtjson1.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                                            EwbDt = dtjson1.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                                            EwbNo = dtjson1.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                                            EwbValidTill = dtjson1.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                                            Remarks = dtjson1.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8



                                            objnew.insmastergstdetails(int_intdcno, int_Vouyear, int_bid, int_divisionid, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "D", EwbDt, EwbNo, EwbValidTill, Remarks);


                                        }
                                        else
                                        {
                                            if (datajson1 != null)
                                            {
                                                message1 = dtjson1.Rows[0][1].ToString().Replace('"', ' ').Trim();

                                                gstirnerr_ = gstirnerr_ + "," + message1;
                                                gstirnerr = 1;

                                            }
                                            else
                                            {
                                                message1 = "The GSTZen user credentials provided in the request are invalid-.";
                                            }
                                            objnew.insmastergstdetails(int_intdcno, int_Vouyear, int_bid, int_divisionid, status, message1, "", "", "", "", "", "", "", "", "", "", "", "D", "", "", "", "");
                                        }


                                    }
                                    catch (Exception ex)
                                    {
                                        string message = ex.Message.ToString();
                                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                                    }


                                }

                                // Einvoice newly added end//
                            }


                            //end


                        }

                        //log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                        if (hid_voutype.Value.ToString() == "OSSI")
                        {//raj
                         //log1.Info("Before Call the Procedure apposdn - (Voutype- " + "OSSI" + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                            //logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");

                            //log1.Info("After Call the Procedure apposdn - (Voutype- " + "OSSI" + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                            //try
                            //{
                            //    obj_dt1 = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                            //    if (obj_dt1.Rows.Count > 0)
                            //    {
                            //        int int_custid = int.Parse(obj_dt1.Rows[0]["customer"].ToString());
                            //        DateTime date_Voudate = DateTime.Parse((obj_dt1.Rows[0]["dndate"].ToString()));
                            //        string str_curr = obj_dt1.Rows[0]["curr"].ToString();
                            //        double amount = double.Parse( Grd_Approval.Rows[Row_ID].Cells[7].Text.ToString());
                            //        double vamount = amount * double.Parse(obj_dt1.Rows[0]["exrate"].ToString());
                            //        int int_Ledgerid = 0;
                            //        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                            //        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Session["FADbname"].ToString());
                            //        if (int_Ledgerid == 0)
                            //        {
                            //            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                            //        }
                            //        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                            //    }
                            //}

                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                    break;

                                case "FI":
                                    obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                    break;

                                case "AE":
                                    obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                    break;

                                case "AI":
                                    obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                    break;

                            }
                        }
                        else if (hid_voutype.Value.ToString() == "OSPI")
                        {//raj

                            //log1.Info("Before Call the Procedure apposcn - (Voutype- " + "OSPI" + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                            //logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");

                            //log1.Info("Before Call the Procedure apposcn - (Voutype- " + "OSPI" + " | Vouno-" + int_intdcno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            //try
                            //{
                            //    obj_dt1 = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                            //    if (obj_dt1.Rows.Count > 0)
                            //    {
                            //        int int_custid = int.Parse(obj_dt1.Rows[0]["customer"].ToString());
                            //        DateTime date_Voudate = DateTime.Parse((obj_dt1.Rows[0]["cndate"].ToString()));
                            //        string str_curr = obj_dt1.Rows[0]["curr"].ToString();
                            //        double amount = double.Parse( Grd_Approval.Rows[Row_ID].Cells[7].Text.ToString());
                            //        double vamount = amount * double.Parse(obj_dt1.Rows[0]["exrate"].ToString());
                            //        int int_Ledgerid = 0;
                            //        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                            //        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Session["FADbname"].ToString());
                            //        if (int_Ledgerid == 0)
                            //        {
                            //            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                            //        }
                            //        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                            //    }
                            //}

                            switch (Session["StrTranType"].ToString())
                            {
                                case "FE":
                                    obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                    break;

                                case "FI":
                                    obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                    break;

                                case "AE":
                                    obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                    break;

                                case "AI":
                                    obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                    break;

                            }
                        }
                        if (int_intdcno != 0)
                        {
                            Str_invoiceno = Str_invoiceno + int_intdcno.ToString() + ",";
                        }
                        else
                        {
                            StrScript += "OSDN # or OSCN # Not Generated and Transfered";

                        }

                        /******************* For Auto mail *********************/
                        if (hid_voutype.Value.ToString() == "ProOSDNApproval")
                        {
                            // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-OSDN", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                        }
                        else if (hid_type.Value.ToString() == "ProOSCNApproval")
                        {
                            // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-OSCN", int_bid, Convert.ToInt32(hid_vouyear.Value), Session["FADbname"].ToString(), obj_da_Log.GetDate());
                        }
                        /******************************************************/

                        //}

                        //}
                        if (countinv != 1)
                        {

                            ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                            return;
                        }
                        if (Str_invoiceno.Length > 0)
                        {
                            Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                            // string StrScript = "";
                            if (hid_voutype.Value.ToString() == "OSSI")
                            {
                                StrScript += "OSDN # " + Str_invoiceno + " Generated and Transfered";
                            }
                            else if (hid_voutype.Value.ToString() == "OSPI")
                            {
                                StrScript += "OSCN # " + Str_invoiceno + " Generated and Transfered";
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
                        if (int_osdncn1 == 1)
                        {
                            StrScript += "Kindly Save the Proforma Voucher Again and Approve for" + str_osdncn1;
                        }

                    }
                }
                Fn_Getdetail();
                
                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                //}
                //  UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_delete.Visible = false;btn_delete_id.Visible = false;

        }

        private int Fn_Getcustomergroupid(int int_Custid)
        {
            //int int_Subgroupid = 0, int_Groupid = 0;
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            //if ( hid_voutype.Value.ToString() == "SALES INVOICE")
            //{
            //    int_Subgroupid = 40;
            //    int_Groupid = 13;
            //}
            //else if ( hid_voutype.Value.ToString() == "OSPI")
            //{
            //    int_Subgroupid = 44;
            //    int_Groupid = 12;
            //}
            //else if (hid_type.Value.ToString() == "OSSI")
            //{
            //    int_Subgroupid = 65;
            //    int_Groupid = 13;
            //}
            int int_Ledgerid = 0;
            //int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid), int_Subgroupid, int_Groupid, 'G', int_Custid, 'C', Session["FADbname"].ToString());

            return int_Ledgerid;
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
                    //if (i == 9)
                    //{
                    //    TextBox txt = (TextBox)e.Row.FindControl("TDSAmount");
                    //    double TDSAmount = Convert.ToDouble(e.Row.Cells[9].Text);
                    //    txt.Text = TDSAmount.ToString("#0.00");
                    //}
                }

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Approval, "" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";

                //LinkButton _singleClickButton1 = (LinkButton)e.Row.Cells[6].Controls[0];
                //string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton1, "");
                //// Add events to each editable cell

                //    for (int columnIndex = 0; columnIndex < e.Row.Cells.Count-2; columnIndex++)
                //    {
                //        // Add the column index as the event argument parameter
                //        string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                //        // Add this javascript to the onclick Attribute of the cell
                //        e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                //        // Add a cursor style to the cells
                //        e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";

                //    }

            }

            //if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    if (hid_type.Value.ToString() != "Transfer To Commercial PA")
            //    {
            //        e.Row.Cells[5].Visible = false;
            //        e.Row.Cells[6].Visible = false;
            //        e.Row.Cells[7].Visible = false;

            //    }
            //    else
            //    {
            //        e.Row.Cells[5].Visible = true;
            //        e.Row.Cells[6].Visible = true;
            //        e.Row.Cells[7].Visible = true;

            //    }
            //}
            //btn_delete.Visible = false;btn_delete_id.Visible = false;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Grd_Approval.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Approval.DataBind();
                  btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                btn_delete.Visible = false;btn_delete_id.Visible = false;
            }
            else
            {
                div_iframe.Visible = false;
                //this.aePopUpshow.Hide();
                ////this.Response.End();
                //if (Session["home"].ToString() == "CS")
                //{
                //    if (Session["StrTranType"].ToString() == "FE")
                //    {
                //        // headerlable1.InnerText = "OceanExports";
                //        Response.Redirect("../Home/OECSHome.aspx");

                //    }
                //    else if (Session["StrTranType"].ToString() == "FI")
                //    {
                //        // headerlable1.InnerText = "OceanImports";
                //        Response.Redirect("../Home/OICSHome.aspx");
                //    }
                //    else if (Session["StrTranType"].ToString() == "AE")
                //    {
                //        // headerlable1.InnerText = "AirExports";
                //        Response.Redirect("../Home/AECSHome.aspx");
                //    }
                //    else if (Session["StrTranType"].ToString() == "AI")
                //    {
                //        //  headerlable1.InnerText = "AirImports";
                //        Response.Redirect("../Home/AICSHome.aspx");
                //    }
                //}
                //else if (Session["home"].ToString() == "OPS&DOC")
                //{
                //    if (Session["StrTranType"].ToString() == "FE")
                //    {
                //        // headerlable1.InnerText = "OceanExports";
                //        Response.Redirect("../Home/OEOpsAndDocs.aspx");

                //    }
                //    else if (Session["StrTranType"].ToString() == "FI")
                //    {
                //        // headerlable1.InnerText = "OceanImports";
                //        Response.Redirect("../Home/OEOpsAndDocs.aspx");
                //    }
                //    else if (Session["StrTranType"].ToString() == "AE")
                //    {
                //        // headerlable1.InnerText = "AirExports";
                //        Response.Redirect("../Home/OEOpsAndDocs.aspx");
                //    }
                //    else if (Session["StrTranType"].ToString() == "AI")
                //    {
                //        //  headerlable1.InnerText = "AirImports";
                //        Response.Redirect("../Home/OEOpsAndDocs.aspx");
                //    }
                //}
                ////else if (Session["Value"] != null)
                ////{
                ////    Session["Val"] = 1;
                ////    Session["Value"] = null;
                ////    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                ////}
                //else
                //{

                //    this.Response.End();
                //}
            }

            // UserRights();
        }

        protected void Grd_Approval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index, cindex, selectedColumnIndex = 0, selectedRowIndex = 0;
                string st = "";
                if (e.CommandName.ToString() == "ColumnClickNew")
                {
                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                    Session["column"] = selectedColumnIndex;
                    Session["row"] = selectedRowIndex;
                }
                if (selectedColumnIndex != 5)
                {
                    //Grd_Approval_SelectedIndexChanged(sender, e);
                    //approval();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Approval_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            List<TableCell> columns = new List<TableCell>();
            foreach (DataControlField column in Grd_Approval.Columns)
            {
                TableCell cell = row.Cells[0];
                row.Cells.Remove(cell);
                columns.Add(cell);
            }
            row.Cells.AddRange(columns.ToArray());
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView4, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            int index = GridView4.SelectedRow.RowIndex;
            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(103, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name1 = GridView4.Rows[index].Cells[1].Text;

                    // Session["Unclosed"] = "value";
                    //Session["trantype"] = Session["StrTranType"].ToString();
                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                    Session["JobNumber"] = name1;
                    string name = Session["StrTranType"].ToString();
                    //  Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOME=" + name);                  
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOMECSP=" + name + "&jobno1=" + name1);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            else if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(104, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name1 = GridView4.Rows[index].Cells[1].Text;

                    // Session["Unclosed"] = "value";
                    //Session["trantype"] = Session["StrTranType"].ToString();
                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                    Session["JobNumber"] = name1;
                    string name = Session["StrTranType"].ToString();
                    //  Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOME=" + name);
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOMECSP=" + name + "&jobno1=" + name1);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView5, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            DataTable dtuser = new DataTable();
            string name = "";
              index = GridView5.SelectedRow.RowIndex;

            if (Session["StrTranType"].ToString() == "AE")
            {
                if (GridView5.Rows.Count > 0)
                {

                    dtuser = obj_UP.GetFormwiseuserRights(1258, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        index = GridView5.SelectedRow.RowIndex;
                        name = GridView5.Rows[index].Cells[1].Text;
                        //Response.Redirect("../AE/AWBRelease.aspx?BLReleaseNO=" + name);
                        Response.Redirect("../AE/AWBRelease.aspx?BLReleaseNO=" + name + "&blno=" + GridView5.Rows[index].Cells[1].Text);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(GridView5, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                    }
                }
            }
            else if (Session["StrTranType"].ToString() == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1427, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    index = GridView5.SelectedRow.RowIndex;
                    name = GridView5.Rows[index].Cells[1].Text;
                    // Session["blno"] = name;
                    Response.Redirect("../AI/BLPrintingAir.aspx?BLReleaseAi=" + name+"&blno=" + GridView5.Rows[index].Cells[1].Text);
                }
            }
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(176, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name = Session["StrTranType"].ToString();
                    string type = "BL Register";
                    Response.Redirect("../ForwardExports/BLRegister.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            else if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(177, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name = Session["StrTranType"].ToString();
                    string type = "BL Register";
                    Response.Redirect("../ForwardExports/BLRegister.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            else if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(203, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name = Session["StrTranType"].ToString();
                    string type = "BL Register";
                    Response.Redirect("../ForwardExports/BLRegister.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            else if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(203, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    string name = Session["StrTranType"].ToString();
                    string type = "BL Register";
                    Response.Redirect("../ForwardExports/BLRegister.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void link_cust_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GrdCuswise"] as DataTable;

            if (GrdCuswise.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Customer Wise.xls");
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

        protected void lnk_cut1_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["GridView1"] as DataTable;

            if (GridView1.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Customer Wise.xls");
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

        protected void lbl_blrelease_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["GrdPort1"] as DataTable;

            if (GrdPort1.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Pending BLs.xls");
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

        protected void link_pending_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GridView2"] as DataTable;

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
                    Response.AddHeader("content-disposition", "attachment;filename=Pending BLs.xls");
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

        protected void link_unclosed_Click(object sender, EventArgs e)
        {

            //if (GridView3.Rows.Count > 0)
            //{
            //    DataTable dt_check = ViewState["GridView3"] as DataTable;
            //    dt_check.Columns.Remove("custid");
            //    using (XLWorkbook wb = new XLWorkbook())
            //    {
            //        //wb.Worksheets.Add("test");

            //        wb.Worksheets.Add(dt_check);

            //        Response.Clear();
            //        Response.Buffer = true;
            //        Response.Charset = "";
            //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //        Response.AddHeader("content-disposition", "attachment;filename=Pending BLs.xls");
            //        using (MemoryStream MyMemoryStream = new MemoryStream())
            //        {
            //            wb.SaveAs(MyMemoryStream);
            //            MyMemoryStream.WriteTo(Response.OutputStream);
            //            Response.Flush();
            //            Response.End();
            //        }
            //    }
            //}

            if (GridView3.Rows.Count > 0)
            {

                //{
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Unclosed Job Details" + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (GridView3.Visible == true)
                {
                    GridView3.GridLines = GridLines.Both;
                    GridView3.HeaderStyle.Font.Bold = true;
                    GridView3.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void linkunclose_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["GridView3"] as DataTable;

            if (GridView3.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Pending BLs.xls");
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
        protected void Lnk_events_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1749, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    // Response.Redirect("../ForwardExports/Events.aspx");

                    Response.Redirect("../ForwardExports/FEEvents.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            else if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1750, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    //  Response.Redirect("../FI/FIEvents.aspx");

                    Response.Redirect("../FI/FIEventsnew.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

        }

        //protected void btn_backdated_Click(object sender, EventArgs e)
        //{
        //   /* try
        //    {
        //        int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
        //        string Str_Trantype = Session["StrTranType"].ToString(), Str_invoiceno = "";
        //        int_Empid = int.Parse(Session["LoginEmpId"].ToString());
        //        int_bid = int.Parse(Session["LoginBranchid"].ToString());
        //        int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
        //        DataTable obj_dt = new DataTable();
        //        string StrScript = "";
        //        int countinv = 0;
        //        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        //        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        //        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        //        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        //        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
        //        DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
        //        if (hid_type.Value.ToString() == "Transfer To Commercial PA")
        //        {

        //            foreach (GridViewRow row in Grd_Approval.Rows)
        //            {
        //                CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
        //                if (Chk.Checked == true)
        //                {
        //                    countinv = 1;
        //                    int_Invoiceno = obj_da_Approval.GetNoforAcForApproval4cnops(int_bid, hid_type.Value.ToString());
        //                    int_Refno = Convert.ToInt32(row.Cells[0].Text.ToString());
        //                    int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
        //                    hid_stamt.Value = row.Cells[8].Text.ToString();
        //                    hid_supplyto.Value = row.Cells[9].Text.ToString();
        //                    string emp = row.Cells[5].Text.ToString();
        //                    int empp = employeeobj.GetNEmpid(emp);
        //                    //if (empp == int_Empid)
        //                    //{
        //                    //    StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
        //                    //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
        //                    //    continue;
        //                    //}

        //                    Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmt(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
        //                    if (Dtckeck.Rows.Count > 0)
        //                    {
        //                        StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice";
        //                        //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
        //                        continue;

        //                    }
        //                    obj_da_Approval.UpdProApproval4Cnops(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());
        //                    if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
        //                    {//raj
        //                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", Convert.ToInt32(Session["LoginBranchid"]), "");
        //                        try
        //                        {
        //                            obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
        //                            if (obj_dt.Rows.Count > 0)
        //                            {
        //                                int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());
        //                                DateTime date_Voudate = DateTime.Parse(obj_dt.Rows[0].ItemArray[1].ToString());
        //                                int int_Ledgerid = 0;
        //                                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
        //                                int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Invoices", Session["FADbname"].ToString());
        //                                if (int_Ledgerid == 0)
        //                                {
        //                                    int_Ledgerid = Fn_Getcustomergroupid(int_custid);
        //                                }
        //                                obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'I', int_Vouyear, int_bid, double.Parse(row.Cells[4].Text.ToString()), "", 0, int_custid);
        //                            }
        //                        }
        //                        
        //                        switch (Session["StrTranType"].ToString())
        //                        {
        //                            case "FE":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1016, 1, int_bid, int_Refno.ToString());
        //                                break;

        //                            case "FI":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1023, 1, int_bid, int_Refno.ToString());
        //                                break;

        //                            case "AE":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1030, 1, int_bid, int_Refno.ToString());
        //                                break;

        //                            case "AI":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1037, 1, int_bid, int_Refno.ToString());
        //                                break;
        //                            case "CH":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1043, 1, int_bid, int_Refno.ToString());
        //                                break;

        //                        }
        //                    }
        //                    else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
        //                    {
        //                        switch (Session["StrTranType"].ToString())
        //                        {
        //                            case "FE":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, int_Refno.ToString());
        //                                break;

        //                            case "FI":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, int_Refno.ToString());
        //                                break;

        //                            case "AE":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, int_Refno.ToString());
        //                                break;

        //                            case "AI":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, int_Refno.ToString());
        //                                break;
        //                            case "CH":
        //                                obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, int_Refno.ToString());
        //                                break;

        //                        }
        //                    }
        //                    Str_invoiceno = Str_invoiceno + int_Invoiceno.ToString() + ",";

        //                }
        //            }
        //            if (countinv != 1)
        //            {

        //                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
        //                return;
        //            }
        //            if (Str_invoiceno.Length > 0)
        //            {
        //                Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);
        //                if (hid_type.Value.ToString() == "Transfer To Commercial PA")
        //                {
        //                    StrScript += "CN-Ops # " + Str_invoiceno + " Generated and Transfered";
        //                }
        //                else if (hid_type.Value.ToString() == "Transfer To Commercial CN")
        //                {
        //                    StrScript += "CN # " + Str_invoiceno + " Generated and Transfered";
        //                }
        //                else if (hid_type.Value.ToString() == "Transfer To Commercial DN")
        //                {
        //                    StrScript += "DN # " + Str_invoiceno + " Generated and Transfered";
        //                }

        //            }
        //        }
        //        Fn_Getdetail();
        //        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }*/
        //}

        protected void btn_backdated_Click(object sender, EventArgs e)
        {

            try
            {

                int Vyraer = Convert.ToInt32(HttpContext.Current.Session["Vouyear"]);

                string FAYear1;
                int vyear1;
                vyear1 = Vyraer;
                FAYear1 = vyear1.ToString();
                FAYear1 = FAYear1.Substring(2, 2);
                vyear1 = vyear1 + 1;
                FAYear1 = Convert.ToInt32(FAYear1) - 1 + Convert.ToString(vyear1 - 1).Substring(2, 2);
                string Str_DBname = "FA" + FAYear1;

                Session["Back"] = "Back";
                string type = "";
                int invoinumber = 0;
                string str_favourname = "";
               // DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
                int int_osdncn = 0;
                DataTable dtosdn = new DataTable();
              //  DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                string cutname = "";
                // DataSet dsosdn=new DataSet();
                int jobnoosdn = 0;
                int gsttype = 0, statename = 0, supplyto = 0, int_osdncn1 = 0;
                string gsttype_ = "", statename_ = "", supplyto_ = "", str_osdncn1 = "";
                int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
                string Str_Trantype = Session["StrTranType"].ToString(), Str_invoiceno = "", Str_invoicenonew = "";
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                string StrScript = "";
                int countinv = 0;
                double st_amt = 0.0;
                double Amount = 0, TDS = 0, TDSAmount = 0, CSTAmount = 0, gstamt = 0;
                //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                //DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();

                //Ruban
              //  DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();

                int int_Custid = 0;
                int countryid = 0;
                TextBox Txt = new TextBox();

                string tdstype = "", tdsdesc = "";
                string str_tdstype = "", str_tdsdesc = "", str_TDS = "";
                int int_tdstype = 0, int_tdsdesc = 0, int_TDS = 0;
                string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";
              //  DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
                DataTable dtcust = new DataTable();
                DataTable dtcust1 = new DataTable();

                int custsupply = 0;
                string custsupply_ = "";
                if (hid_type.Value.ToString() == "Transfer To Commercial Invoice" || hid_type.Value.ToString() == "Transfer To Commercial PA")
                {
                    foreach (GridViewRow row in Grd_Approval.Rows)
                    {
                        type = Grd_Approval.Rows[row.RowIndex].Cells[18].Text;       //NewOne       //22/07/2022
                        string str_Voutype = type;
                        bool ChkLedger = true;
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                        if (Chk.Checked == true)
                        {
                            int_Refno = Convert.ToInt32(row.Cells[0].Text.ToString());
                            countinv = 1;
                            if (hid_type.Value.ToString() == "Transfer To Commercial PA") //&& Session["countryid"].ToString() == "1102"
                            {
                                Txt = (TextBox)Grd_Approval.Rows[row.RowIndex].FindControl("txtpercentage");     //NewOne       //22/07/2022
                                if (Txt.Text.Trim().Length == 0)
                                {
                                    //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "TDS", "alertify.alert('Enter TDS%');", true);
                                    if (int_TDS == 0)
                                    {
                                        str_TDS = "Enter TDS% for Ref number is " + int_Refno;

                                    }
                                    else
                                    {
                                        str_TDS = str_TDS + "," + int_Refno;
                                    }
                                    Txt.Focus();
                                    int_TDS = 1;
                                    continue;

                                }
                                else
                                {
                                    tdstype = row.Cells[5].Text.ToString();
                                    tdsdesc = row.Cells[6].Text.ToString();
                                    if (tdstype == "" && tdstype == "")
                                    {
                                        if (int_tdstype == 0)
                                        {
                                            str_tdstype = "TDS Type is Empty && TDS DESC is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdstype = str_tdstype + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdstype = 1;
                                        continue;
                                    }
                                    else if (tdstype == "")
                                    {
                                        if (int_tdstype == 0)
                                        {
                                            str_tdstype = "TDS Type is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdstype = str_tdstype + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdstype = 1;
                                        continue;
                                    }

                                    else if (tdsdesc == "")
                                    {
                                        if (int_tdsdesc == 0)
                                        {
                                            str_tdsdesc = "TDS DESC is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdsdesc = str_tdsdesc + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdsdesc = 1;
                                        continue;
                                    }

                                }
                            }

                            /******************* For Auto mail *********************/
                            hid_refno.Value = row.Cells[0].Text.ToString();
                            hid_vouyear.Value = obj_da_FAVoucher.Getvouyearforautotransfer(int_bid).ToString();
                            /****************************************/

                            int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
                            //hid_stamt.Value = row.Cells[7].Text.ToString();
                            //hid_supplyto.Value = row.Cells[8].Text.ToString();
                            hid_stamt.Value = row.Cells[10].Text.ToString();
                            hid_supplyto.Value = row.Cells[11].Text.ToString();
                            if (hid_supplyto.Value != "0")
                            {
                                cutname = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                            }
                            string emp = row.Cells[4].Text.ToString();
                            int empp = employeeobj.GetNEmpid(emp);
                            //if (empp == int_Empid)
                            //{
                            //    StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                            //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //    continue;
                            //}
                            int_Custid = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[1].ToString());
                            countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));
                            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice" && (countryid == 1102 || countryid == 102))
                            {
                                Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmt(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                                if (Dtckeck.Rows.Count > 0)
                                {
                                    StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice";
                                    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                    continue;
                                }
                            }

                            if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {

                                int_Custid = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[1].ToString());
                                countryid = obj_da_Invoice.getcustomercountry(Convert.ToInt32(int_Custid));

                                if( countryid == 1102 || countryid == 102)
                                {
                                    if (hid_supplyto.Value != "")
                                    {
                                        dtcust1 = obj_da_BL.Gettdsforcustomer(Convert.ToInt32(hid_supplyto.Value));
                                    }
                                    if (dtcust1.Rows.Count > 0)
                                    {
                                        // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                                        StrScript += "TDS does not exist for Supply to customer" + int_Refno + ".Kindly check Proforma PA";
                                        continue;
                                    }

                                    dtcust1 = obj_da_BL.Gettdsforcustomer(int_Custid);
                                    if (dtcust1.Rows.Count > 0)
                                    {
                                        // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                                        StrScript += "TDS does not exist for Bill to customer" + int_Refno + ".Kindly check Proforma PA";
                                        continue;

                                    }
                                }
                            }

                            if (Session["hid_gstdate"].ToString() != null) //&& Session["countryid"].ToString() == "1102"
                            {
                                if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                                {
                                    if (hid_supplyto.Value != "0")
                                    {
                                        if (Convert.ToDouble(hid_stamt.Value) > 0)
                                        {
                                            int int_custidnew;
                                            DataTable dt_list = new DataTable();
                                          //  DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
                                            //int int_custid = Convert.ToInt32(hdncustid.Value);
                                            if (!string.IsNullOrEmpty(row.Cells[11].Text.ToString()))
                                            {
                                                int_custidnew = Convert.ToInt32(row.Cells[11].Text.ToString());
                                                dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                            }
                                            if (dt_list.Rows.Count > 0)
                                            {
                                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                                {
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
                                                //StrScript += "State Name not Updated in Master Kindly update Master Customer for" + row.Cells[2].Text.ToString();
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
                                        //StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;
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
                            string inapproved = obj_da_Approval.CHKVoucher(int_Refno);
                            if (inapproved.ToString() == "TRUE" && hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {
                                invoinumber = obj_da_Approval.UpdProApprovalnewback(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);
                                Session["Back"] = "Back";
                                //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "", 0, 0, "", 0, 1);
                                string retransfer = "N";
                                if (Session["vouid"] != null)
                                {
                                    retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Str_DBname);
                                    if (retransfer == "Y")
                                    {
                                        Session["Back"] = "Back";
                                        //           logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "", 0, 0, "", 0, 1);
                                    }
                                    Session["vouid"] = null;
                                }
                                if (invoinumber != 0)
                                {
                                    Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                                }
                                else
                                {
                                    Str_invoicenonew = "Invoice not Approved";
                                }
                            }
                            string inapproved1 = obj_da_Approval.CHKVoucherexists(int_Refno);

                            string voutype = "";
                            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {
                                voutype = "Invoice";
                            }
                            else
                            {
                                voutype = "PA";
                            }

                            if (inapproved1 == "TRUE" && hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {
                                int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalbacknew(int_bid, hid_type.Value.ToString());
                                //obj_da_Approval.UpdProApprovalBack(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString(), System.DateTime.Now);
                                obj_da_Approval.UpdproappBD(int_Refno, int_Empid, int_bid, int_Invoiceno, voutype, Convert.ToChar("Y"), int_Vouyear);
                            }
                            else
                            {
                                int_Invoiceno = obj_da_Approval.GetNoforAcForApprovalbacknew(int_bid, hid_type.Value.ToString());
                                //obj_da_Approval.UpdProApprovalBack(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString(), System.DateTime.Now);
                                obj_da_Approval.UpdproappBD(int_Refno, int_Empid, int_bid, int_Invoiceno, voutype, Convert.ToChar("Y"), int_Vouyear);
                            }

                            //Ruban for PA
                            if (hid_type.Value.ToString() == "Transfer To Commercial PA") //&& Session["countryid"].ToString() == "1102")
                            {

                                Txt = (TextBox)Grd_Approval.Rows[row.RowIndex].FindControl("txtpercentage");

                                int_Custid = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[1].ToString());
                                Amount = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[3].Text.ToString()));
                                gstamt = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[15].Text.ToString()));     //NewOne       //22/07/2022
                                Amount = Amount - gstamt;
                                if (Txt.Text == "")
                                {
                                    TDS = 0;
                                }
                                else
                                {
                                    TDS = double.Parse(Txt.Text.ToString());
                                }

                                //  TDSAmount = Amount * (TDS / 100);
                                TDSAmount = Convert.ToDouble((Amount * (TDS / 100)).ToString("#0.00"));

                                CSTAmount = Amount - TDSAmount;

                                if (str_Voutype == "S")
                                {
                                    obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Invoiceno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear);
                                }
                                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                {
                                    int int_Ledgerid = 0;
                                    int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), "A", Str_DBname);
                                    if (int_Ledgerid == 0)
                                    {
                                        ChkLedger = false;
                                    }
                                }

                                if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                {
                                    str_Voutype = "P";              //CN-OPS  -->P  //Admin-CN-->S// Other-CN-->E
                                    type = "P";
                                }

                                CheckBox Chkrcm = (CheckBox)row.FindControl("Chk_rcm"); // For RCM
                                if (Chkrcm.Checked == true)
                                {

                                    if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                    {
                                        obj_da_Invoice.inspaheadgsttype("R", int_Invoiceno, int_bid, int_Vouyear - 1, "P");
                                        switch (Session["StrTranType"].ToString())
                                        {
                                            case "FE":
                                                obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM-Bckdated");
                                                break;
                                            case "FI":
                                                obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM-Bckdated");
                                                break;
                                            case "AE":
                                                obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM-Bckdated");
                                                break;
                                            case "AI":
                                                obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM-Bckdated");
                                                break;
                                            case "CH":
                                                obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM-Bckdated");
                                                break;
                                            case "BT":
                                                obj_da_Log.InsLogDetail(int_Empid, 1053, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM-Bckdated");
                                                break;
                                            case "NE":
                                                obj_da_Log.InsLogDetail(int_Empid, 1898, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM-Bckdated");
                                                break;
                                            case "NI":
                                                obj_da_Log.InsLogDetail(int_Empid, 1899, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM-Bckdated");
                                                break;

                                        }
                                    }
                                }
                                else if (Chkrcm.Checked == false)
                                {
                                    if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                    {
                                        switch (Session["StrTranType"].ToString())
                                        {
                                            case "FE":
                                                obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                                break;
                                            case "FI":
                                                obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM-Bckdated");
                                                break;
                                            case "AE":
                                                obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM-Bckdated");
                                                break;
                                            case "AI":
                                                obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM-Bckdated");
                                                break;
                                            case "CH":
                                                obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM-Bckdated");
                                                break;
                                            case "BT":
                                                obj_da_Log.InsLogDetail(int_Empid, 1053, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM-Bckdated");
                                                break;
                                            case "NE":
                                                obj_da_Log.InsLogDetail(int_Empid, 1898, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM-Bckdated");
                                                break;
                                            case "NI":
                                                obj_da_Log.InsLogDetail(int_Empid, 1899, 1, int_bid, "Refno:" + int_Refno + "/CNOps:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM-Bckdated");
                                                break;

                                        }
                                    }
                                }

                                if (ChkLedger == true)
                                {
                                    obj_da_Invoice.InsertPATDS(int_Invoiceno, str_Voutype, int.Parse(Session["LoginBranchid"].ToString()), int_Custid, Vyraer - 1, CSTAmount, TDSAmount);

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
                                    Session["Back"] = "Back";
                                    // logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Invoiceno, int_Invoiceno, Str_ddlNarration, Str_ddlReference, "", 0, 0, "", 0, 1,);

                                    int int_Ledgerid = 0;
                                    int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Str_DBname);
                                    int_Voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_ddlVoucherType, Str_DBname);
                                    if (int_Ledgerid == 0)
                                    {
                                        int_Ledgerid = Fn_Getcustomergroupid(int_Custid, Str_ddlVoucherType);
                                    }
                                    //DateTime dtdate = DateTime.Parse(Utility.fn_ConvertDate(Grd_Approval.Rows[row.RowIndex].Cells[12].Text));
                                    DateTime dtdate = DateTime.Parse((Grd_Approval.Rows[row.RowIndex].Cells[17].Text));      //NewOne       //22/07/2022
                                    string Str_CustType = obj_da_Customer.GetCustomerType(int_Custid);
                                    if (Str_CustType == "P" || Str_CustType == "E")
                                    {
                                        DataTable dt = new DataTable();
                                        dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "CNHead", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()));
                                        string Str_Curr = "";
                                        double F_Curr = 0;
                                        if (dt.Rows.Count > 0)
                                        {
                                            Str_Curr = dt.Rows[0]["curr"].ToString();
                                            F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, Str_Curr, F_Curr, int_Custid);
                                    }
                                    else
                                    {

                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, "", 0, int_Custid);
                                    }
                                }

                                str_favourname = row.Cells[2].Text.ToString();
                                obj_da_Cheque.UpdChequeRequest(int_Invoiceno, int.Parse(Session["Vouyear"].ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int_Empid, "PA", char.Parse("C"), "", str_favourname);

                            }

                            if (str_Voutype == "S")
                            {
                                obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Invoiceno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear);
                            }
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                int int_Ledgerid = 0;
                                int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), "A", Str_DBname);
                                if (int_Ledgerid == 0)
                                {
                                    ChkLedger = false;
                                }
                            }
                            // string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";
                            if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {
                                str_Voutype = "P"; //CN-OPS  -->P  //Admin-CN-->S//  Other-CN-->E
                                type = "P";
                            }

                            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {//raj
                                Session["Back"] = "Back";
                                //     logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", "", 0, 0, "", 0, 1);
                                string retransfer = "N";
                                if (Session["vouid"] != null)
                                {
                                    retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Str_DBname);
                                    if (retransfer == "Y")
                                    {
                                        Session["Back"] = "Back";
                                        //           logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", "", 0, 0, "", 0, 1);
                                    }
                                    Session["vouid"] = null;
                                }
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());
                                        DateTime date_Voudate = DateTime.Parse(obj_dt.Rows[0].ItemArray[1].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Str_DBname);
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Invoices", Str_DBname);
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'I', int_Vouyear, int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1016, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1023, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1030, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1037, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "CH":
                                        obj_da_Log.InsLogDetail(int_Empid, 1043, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "NE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1892, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "NI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1893, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                }
                            }
                            else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "CH":
                                        obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "NE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1898, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "NI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1899, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                }
                            }

                            Str_invoiceno = Str_invoiceno + int_Invoiceno.ToString() + ",";

                            /******************* For Auto mail *********************/
                            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-Invoices", int_bid, Vyraer, Str_DBname, obj_da_Log.GetDate());
                            }
                            else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-CNOPS", int_bid, Vyraer, Str_DBname, obj_da_Log.GetDate());
                            }
                            /******************************************************/

                        }
                        //else if (countinv != 1)
                        //{
                        // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        //    return;
                        //}
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

                    if (int_TDS == 1)
                    {
                        StrScript += " " + str_TDS;
                    }

                    if (int_tdstype == 1)
                    {
                        StrScript += " " + str_tdstype;
                    }

                    if (int_tdsdesc == 1)
                    {
                        StrScript += " " + str_tdsdesc;
                    }
                    if (countinv != 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        return;
                    }
                    if (Str_invoiceno.Length > 0)
                    {
                        Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);
                        if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                        {
                            StrScript += "Invoice # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                        {
                            StrScript += "PI # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial CN")
                        {
                            StrScript += "CN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial DN")
                        {
                            StrScript += "DN # " + Str_invoiceno + " Generated and Transfered";
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
                    if (invoinumber != 0)
                    {
                        // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                        StrScript += " " + Str_invoicenonew;
                    }

                }
                else if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                {
                    DataTable dtne1 = new DataTable();
                    foreach (GridViewRow row in Grd_Approval.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                        if (Chk.Checked == true)
                        {
                            countinv = 1;
                            int_Refno = int.Parse(row.Cells[0].Text.ToString());
                            jobnoosdn = int.Parse(row.Cells[1].Text.ToString());
                            int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());

                            /******************* For Auto mail *********************/
                            hid_refno.Value = row.Cells[0].Text.ToString();
                            hid_vouyear.Value = obj_da_FAVoucher.Getvouyearforautotransfer(int_bid).ToString();
                            /****************************************/

                            // dcno = Approveobj.UpdProApprovalOSDCN(refno, strblno, Login.logempid, strTranType, vouyear, branchid, strFType)
                            hid_stamt.Value = row.Cells[7].Text.ToString();
                            hid_supplyto.Value = row.Cells[8].Text.ToString();
                            string emp = row.Cells[4].Text.ToString();
                            int empp = employeeobj.GetNEmpid(emp);
                            //if (empp == int_Empid)
                            //{
                            //    StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                            //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                            //    continue;
                            //}

                            if (hid_type.Value.ToString() == "ProOSDNApproval")
                            {
                                dtne1 = obj_da_Approval.getosdncncussup(int_Refno, int_bid, int_Vouyear, Str_Trantype, "OSSI", jobnoosdn);
                            }
                            else
                            {
                                dtne1 = obj_da_Approval.getosdncncussup(int_Refno, int_bid, int_Vouyear, Str_Trantype, "OSPI", jobnoosdn);
                            }
                            if (dtne1.Rows.Count > 0)
                            {
                                if (custsupply == 0)
                                {
                                    custsupply_ = int_Refno.ToString();
                                }
                                else
                                {
                                    custsupply_ = " ," + int_Refno.ToString();
                                }
                                custsupply = 1;

                                continue;
                            }

                            dtosdn = obj_da_OSDNCN.GetCheckosdncnnew(Str_Trantype, jobnoosdn, int_bid);
                            int cnt = 0;
                            cnt = dtosdn.Rows.Count;
                            if (cnt == 1)
                            {
                                if (int_osdncn1 == 0)
                                {
                                    str_osdncn1 = int_Refno.ToString();
                                }
                                else
                                {
                                    str_osdncn1 = " ," + int_Refno.ToString();
                                }
                                int_osdncn1 = 1;
                                continue;
                            }
                            else
                            {
                                int_intdcno = obj_da_Approval.UpdproappOSDNCNBD(int_Refno, int_Empid, int_bid, int_Invoiceno, hid_type.Value.ToString(), Convert.ToChar("Y"), int_Vouyear);
                                //int_intdcno = obj_da_Approval.UpdProApprovalOSDCNback(int_Refno, Convert.ToInt32(row.Cells[1].Text.ToString()), int_Empid, Str_Trantype, int_Vouyear, int_bid, hid_type.Value.ToString());
                                obj_da_Approval.insForOSDNCNDNCNNumber(int_intdcno, hid_type.Value.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(row.Cells[1].Text.ToString()), Str_Trantype, int_Refno);
                            }

                            //if (hid_type.Value.ToString() == "ProOSDNApproval")
                            //{
                            //    fn_Sendmail(int_intdcno, int_bid, int_Vouyear, Str_Trantype, "OSSI");
                            //}
                            //else
                            //{
                            //    fn_Sendmail(int_intdcno, int_bid, int_Vouyear, Str_Trantype, "OSPI");
                            //}

                            if (hid_type.Value.ToString() == "ProOSDNApproval")
                            {//raj
                                Session["Back"] = "Back";
                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "", 0, 0, "", 0, 1);
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                        DateTime date_Voudate = DateTime.Parse((obj_dt.Rows[0]["dndate"].ToString()));
                                        string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                        double amount = double.Parse(row.Cells[3].Text.ToString());
                                        double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Str_DBname);
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Str_DBname);
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;
                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;
                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;
                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;
                                }
                            }
                            else if (hid_type.Value.ToString() == "ProOSCNApproval")
                            {//raj
                                Session["Back"] = "Back";
                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "", 0, 0, "", 0, 1);
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                        DateTime date_Voudate = DateTime.Parse(obj_dt.Rows[0]["cndate"].ToString());
                                        string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                        double amount = double.Parse(row.Cells[3].Text.ToString());
                                        double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Str_DBname);
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Str_DBname);
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;
                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;
                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;
                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;
                                }
                            }
                            if (int_intdcno != 0)
                            {
                                Str_invoiceno = Str_invoiceno + int_intdcno.ToString() + ",";
                            }
                            else
                            {
                                StrScript += "OSDN # or OSCN # Not Generated and Transfered";
                            }

                            /******************* For Auto mail *********************/
                            if (hid_type.Value.ToString() == "ProOSDNApproval")
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-OSDN", int_bid, Vyraer, Str_DBname, obj_da_Log.GetDate());
                            }
                            else if (hid_type.Value.ToString() == "ProOSCNApproval")
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_AutoMailVouchers(Convert.ToInt32(hid_refno.Value), "Pro-OSCN", int_bid, Vyraer, Str_DBname, obj_da_Log.GetDate());
                            }
                            /******************************************************/

                        }
                    }
                    if (countinv != 1)
                    {
                        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        return;
                    }
                    if (Str_invoiceno.Length > 0)
                    {
                        Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);
                        // string StrScript = "";
                        if (hid_type.Value.ToString() == "ProOSDNApproval")
                        {
                            StrScript += "OSDN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "ProOSCNApproval")
                        {
                            StrScript += "OSCN # " + Str_invoiceno + " Generated and Transfered";
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
                    if (int_osdncn1 == 1)
                    {
                        StrScript += "Kindly Save the Proforma Voucher Again and Approve for" + str_osdncn1;
                    }

                    if (custsupply == 1)
                    {
                        StrScript += " Bill To  and Supply To Agent Name not match ,kindly check and update the correct name in proforma Ref #" + custsupply_;
                    }
                }
                Fn_Getdetail();
                //if (Str_invoiceno.Length > 0)
                //{
                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);
                //}
                //  UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_delete.Visible = false;btn_delete_id.Visible = false;

        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            if (GridView4.Rows.Count > 0)
            {
                DataTable dt_check = ViewState["GridView3"] as DataTable;
                dt_check.Columns.Remove("custid");
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Pending BLs.xls");
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

        protected void Sales_Person_Click(object sender, EventArgs e)
        {

            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1854, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //string name = Session["StrTranType"].ToString();
                    //string type1 = "Salesperson";
                    Response.Redirect("../Sales/Salespersonchanged.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1855, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //string name = Session["StrTranType"].ToString();
                    //string type1 = "Salesperson";
                    Response.Redirect("../Sales/Salespersonchanged.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1856, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //string name = Session["StrTranType"].ToString();
                    //string type1 = "Salesperson";
                    Response.Redirect("../Sales/Salespersonchanged.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1857, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //string name = Session["StrTranType"].ToString();
                    //string type1 = "Salesperson";
                    Response.Redirect("../Sales/Salespersonchanged.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void lnkNewCustomerRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ForwardExports/InterbranchEDI.aspx");
        }

        protected void lnk_Incomenotbook_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1850, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Sales/IncomeNotbooked.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1851, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Sales/IncomeNotbooked.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1852, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Sales/IncomeNotbooked.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1853, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Sales/IncomeNotbooked.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {

            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1920, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../AI/AmendMBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1921, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../AI/AmendMBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1922, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../AI/AmendMBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1923, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../AI/AmendMBL.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
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

        protected void TDSPERS_TextChanged(object sender, EventArgs e)
        {
            int index = 0;
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            index = row.RowIndex;
            TextBox Txt = (TextBox)Grd_Approval.Rows[row.RowIndex].FindControl("TDSPERS");
            Txt.Focus();
        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(621, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../Corporate/DownloadDoc.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(625, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../Corporate/DownloadDoc.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

            if (trantype_process == "AE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(622, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../Corporate/DownloadDoc.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }
            if (trantype_process == "AI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(623, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../Corporate/DownloadDoc.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        // Einvoice newly added satrt//

        public static string DineshhttpPostWebRequets(string url, string postData)
        {
            string strResponse = null;
            string dataval = null;
            string tokenvalue = null;
            DataAccess.Documents objnew = new DataAccess.Documents();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objnew.GetDataBase(Ccode);

            if (System.Net.ServicePointManager.MaxServicePointIdleTime > 10000)
            {
                System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;
            }

            if (System.Net.ServicePointManager.MaxServicePoints != 0) //unlimit
                System.Net.ServicePointManager.MaxServicePoints = 0;
            // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 |
(SecurityProtocolType)768 | (SecurityProtocolType)3072;
            //System.Net.ServicePointManager.SecurityProtocol =  SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |  SecurityProtocolType.Tls;
            try
            {

                var webRequest = System.Net.WebRequest.Create(url);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 120000;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    webRequest.ContentType = "application/json";
                    //   webRequest.Headers.Add("Token", "ceadc473-7dc7-42f9-a99b-63ae924a8adb"); // M+R Einvoice Token
                    tokenvalue = objnew.geteinvoicetoken(Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));

                    webRequest.Headers.Add("Token", tokenvalue);  //"ceadc473-7dc7-42f9-a99b-63ae924a8adb"

                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        using (Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s))
                            {
                                strResponse = sr.ReadToEnd();
                            }
                        }

                    }
                }
                webRequest = null;

            }
            catch (Exception ex)
            {

            }
            return strResponse;
        }

        protected DataTable ConvertJsonToDatatable(string jsonString)
        {
            DataTable dt = new DataTable();
            //strip out bad characters
            string[] jsonParts = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");

            //hold column names
            List<string> dtColumns = new List<string>();

            //get columns
            foreach (string jp in jsonParts)
            {
                //only loop thru once to get column names
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1);
                        string v = rowData.Substring(idx + 1);
                        if (!dtColumns.Contains(n))
                        {
                            dtColumns.Add(n.Replace("'", ""));//'
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", rowData));
                    }

                }
                break; // TODO: might not be correct. Was : Exit For
            }

            //build dt
            foreach (string c in dtColumns)
            {
                dt.Columns.Add(c);
            }
            //get table data
            foreach (string jp in jsonParts)
            {
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1).Replace("'", "");
                        string v = rowData.Substring(idx + 1).Replace("'", "");
                        nr[n] = v;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                dt.Rows.Add(nr);
            }
            return dt;
        }

        protected void Gridexrate_PreRender(object sender, EventArgs e)
        {
            if (GridExrate.Rows.Count > 0)
            {
                GridExrate.UseAccessibleHeader = true;
                GridExrate.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdCuswise_PreRender(object sender, EventArgs e)
        {
            if (GrdCuswise.Rows.Count > 0)
            {
                GrdCuswise.UseAccessibleHeader = true;
                GrdCuswise.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GrdPort1_PreRender(object sender, EventArgs e)
        {
            if (GrdPort1.Rows.Count > 0)
            {
                GrdPort1.UseAccessibleHeader = true;
                GrdPort1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridView3_PreRender(object sender, EventArgs e)
        {
            if (GridView3.Rows.Count > 0)
            {
                GridView3.UseAccessibleHeader = true;
                GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        // Einvoice newly added end//

        //NewOne    //21/07/2022
        protected void ddl_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              //  DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable DT_per = new DataTable();
                DataTable dt = new DataTable();
                int RowIndex = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
                DropDownList drp_section = ((DropDownList)Grd_Approval.Rows[RowIndex].FindControl("ddl_section"));
                DropDownList drp_section1 = ((DropDownList)Grd_Approval.Rows[RowIndex].FindControl("ddl_section1"));
                TextBox Txt_per = ((TextBox)Grd_Approval.Rows[RowIndex].FindControl("txtpercentage"));
                TextBox TDSdescnew = ((TextBox)Grd_Approval.Rows[RowIndex].FindControl("TDSdescnew"));

                DataTable dlp = new DataTable();
                dlp = obj_da_Invoice.sp_ddltds(drp_section.SelectedItem.Text);

                var ddl2 = (DropDownList)Grd_Approval.Rows[RowIndex].FindControl("ddl_section1");
                ddl2.Items.Clear();
                ddl2.Items.Add("");
                for (int i = 0; i < dlp.Rows.Count; i++)
                {
                    ddl2.Items.Add(dlp.Rows[i]["tdspercentage"].ToString());
                }
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
            try
            {
               // DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable DT_per = new DataTable();
                DataTable dt = new DataTable();
                int RowIndex = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;
                DropDownList drp_section = ((DropDownList)Grd_Approval.Rows[RowIndex].FindControl("ddl_section1"));
                TextBox Txt_per = ((TextBox)Grd_Approval.Rows[RowIndex].FindControl("txtpercentage"));
                TextBox TDSdescnew = ((TextBox)Grd_Approval.Rows[RowIndex].FindControl("TDSdescnew"));

                Txt_per.Text = drp_section.SelectedValue;

            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private void Grd_TDS_CellContentClick(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > 0)
            {
                int rowindex = e.Row.RowIndex;
                GridViewRow row = this.Grd_Approval.Rows[rowindex];
            }

        }
        protected void GridExrate_PreRender(object sender, EventArgs e)
        {
            GridExrate.UseAccessibleHeader = true;
            GridExrate.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void lnkexpexrate_Click(object sender, EventArgs e)
        {

           // DataAccess.Masters.MasterExRate exrateshow = new DataAccess.Masters.MasterExRate();
            // DataTable dt_check1 = ViewState["grdexrate"] as DataTable;
            DataTable dt_check1 = exrateshow.ShowExRate_LocalOS(DateTime.Parse(Utility.fn_ConvertDate(DateTime.Now.ToString("dd/MM/yyyy")).ToString()), Convert.ToInt32(Session["LoginDivisionId"]));

            ViewState["grdexrate"] = dt_check1;
            if (GridExrate.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check1);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=ExRate.xls");
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

        protected void lnk_proinfc_Click(object sender, EventArgs e)
        {
    
            btn_transfer.Visible = true;
            if (hid_invbkdated.Value == "Y")
            {
                btn_backdated.Visible = true;btn_backdated_id.Visible = true;
            }

            vis_div();
            linkunclose.Visible = false;
            lbl_blrelease.Visible = false;
            // lnk_Unclosed.Visible = false;
            lnk_cut1.Visible = false;
            link_cust.Visible = false;
            string vouname, vouname1;
            string trantype_process = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1016, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // this.aePopUpshow.Show();
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "";
                    if (hid_invfc.Value == "Transfer To Commercial Invoice FC")
                    {
                        app1 = "FC Invoice Proforma to Commercial";
                    }
                    else if (hid_inv.Value == "Transfer To Commercial Invoice")
                    {
                        app1 = "Invoice Proforma to Commercial";
                    }
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";


                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";

                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice";

                        }
                        else if (hid_type.Value.ToString() == "FC Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "FC Invoice Proforma to Commercial";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice OC";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {

                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }

            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1023, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "";
                    if (hid_invfc.Value == "Transfer To Commercial Invoice FC")
                    {
                        app1 = "FC Invoice Proforma to Commercial";
                    }
                    else if (hid_inv.Value == "Transfer To Commercial Invoice")
                    {
                        app1 = "Invoice Proforma to Commercial";
                    }
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice";
                        }
                        else if (hid_type.Value.ToString() == "FC Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "FC Invoice Proforma to Commercial";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice OC";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                       btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }

            if (trantype_process == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1030, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "";
                    if (hid_invfc.Value == "Transfer To Commercial Invoice FC")
                    {
                        app1 = "FC Invoice Proforma to Commercial";
                    }
                    else if (hid_inv.Value == "Transfer To Commercial Invoice")
                    {
                        app1 = "Invoice Proforma to Commercial";
                    }
                    hid_type.Value = app1;
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice";
                        }
                        else if (hid_type.Value.ToString() == "FC Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "FC Invoice Proforma to Commercial";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice OC";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                       btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }

            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1037, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "";
                    if (hid_invfc.Value == "Transfer To Commercial Invoice FC")
                    {
                        app1 = "FC Invoice Proforma to Commercial";
                    }
                    else if (hid_inv.Value == "Transfer To Commercial Invoice")
                    {
                        app1 = "Invoice Proforma to Commercial";
                    }
                    hid_type.Value = app1;
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice";
                        }
                        else if (hid_type.Value.ToString() == "FC Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "FC Invoice Proforma to Commercial";
                            lbl_Header.Text = "Transfer To Commercial Sales Invoice OC";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                     btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
        }
       

        protected void lnk_procnopsfc_Click(object sender, EventArgs e)
        {

            btn_transfer.Visible = true;
            //btn_backdated.Visible = true;btn_backdated_id.Visible = true;
            if (hid_cnopsbkdated.Value == "Y")
            {
                btn_backdated.Visible = true;
                btn_backdated_id.Visible = true;
            }

            vis_div();
            linkunclose.Visible = false;
            lbl_blrelease.Visible = false;
            link_cust.Visible = false;
            lnk_cut1.Visible = false;
            // lnk_Unclosed.Visible = false;
            string vouname, vouname1;
            string trantype_process = Session["StrTranType"].ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DataTable dtuser = new DataTable();
           
            if (trantype_process == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1017, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    string app1 = "";
                    if (hid_paFC.Value == "Transfer To Commercial PA FC")
                    {
                        app1 = "FC CN-Ops Proforma to Commercial";
                    }
                    else if (hid_pa.Value == "Transfer To Commercial PA")
                    {
                        app1 = "CN-Ops Proforma to Commercial";
                    }
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {

                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {

                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString()=="FC CN-Ops Proforma to Commercial")
                        {
                            lbl_Header.Text = "Transfer To Commercial Purchase Invoice OC";
                            hid_type.Value = "FC CN-Ops Proforma to Commercial";
                        }

                        else
                        {

                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        btn_backdated.Visible = false;btn_backdated_id.Visible = false;
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                      btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1024, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    string app1 = "";
                    if (hid_paFC.Value == "Transfer To Commercial PA FC")
                    {
                        app1 = "FC CN-Ops Proforma to Commercial";
                    }
                    else if (hid_pa.Value == "Transfer To Commercial PA")
                    {
                        app1 = "CN-Ops Proforma to Commercial";
                    }
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    //string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "FC CN-Ops Proforma to Commercial")
                        {
                            lbl_Header.Text = "Transfer To Commercial Purchase Invoice OC";
                            hid_type.Value = "FC CN-Ops Proforma to Commercial";
                        }

                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                     btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "AE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1031, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    div_ComApproval.Visible = true;
                    // this.aePopUpshow.Show();
                    string app1 = "";
                    if (hid_paFC.Value == "Transfer To Commercial PA FC")
                    {
                        app1 = "FC CN-Ops Proforma to Commercial";
                    }
                    else if (hid_pa.Value == "Transfer To Commercial PA")
                    {
                        app1 = "CN-Ops Proforma to Commercial";
                    }
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    // string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "FC CN-Ops Proforma to Commercial")
                        {
                            lbl_Header.Text = "Transfer To Commercial Purchase Invoice OC";
                            hid_type.Value = "FC CN-Ops Proforma to Commercial";
                        }

                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                      btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    //  Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1038, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    //  string app1 = "CN-Ops Proforma to Commercial";
                    string app1 = "";
                    if (hid_paFC.Value == "Transfer To Commercial PA FC")
                    {
                        app1 = "FC CN-Ops Proforma to Commercial";
                    }
                    else if (hid_pa.Value == "Transfer To Commercial PA")
                    {
                        app1 = "CN-Ops Proforma to Commercial";
                    }
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial Purchase Invoice";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "FC CN-Ops Proforma to Commercial")
                        {
                            lbl_Header.Text = "Transfer To Commercial Purchase Invoice OC";
                            hid_type.Value = "FC CN-Ops Proforma to Commercial";
                        }

                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }

            }
        }

        protected void ddl_voutype_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
           // DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
            //obj_dt = obj_da_Approval.GetProApprovependingLV(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), hid_type.Value.ToString());
            obj_dt = obj_da_Approval.GetProApprovependingLVTask(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), hid_type.Value.ToString(), Convert.ToInt32(Session["LoginEmpId"]));    //NewOne

            if (ddl_voutype.SelectedValue != "0")
            {
                if (obj_dt.Rows.Count > 0)
                {

                    DataView obj_dtview = new DataView(obj_dt);
                    obj_dtview.RowFilter = "voutype='" + ddl_voutype.SelectedItem.Text + "' ";
                    obj_dt = obj_dtview.ToTable();
                    Grd_Approval.DataSource = obj_dt;
                    Grd_Approval.DataBind();
                }
            }
        }

        protected void lnkedit_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            GridViewRow GvRow = (GridViewRow)lb.NamingContainer;
            int Row_ID = GvRow.RowIndex;
            if (Grd_Approval.Rows[Row_ID].Cells[1].Text == "SALES INVOICE" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "PURCHASE INVOICE" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "SALES INVOICE OC" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "PURCHASE INVOICE OC")
            {
                Response.Redirect("../Accounts/ProformaLV.aspx?1voutype=" + Grd_Approval.DataKeys[Row_ID].Values[2].ToString() + "&refno=" + Grd_Approval.Rows[Row_ID].Cells[2].Text + "&1vouyear=" + Grd_Approval.DataKeys[Row_ID].Values[0].ToString());
            }
            else
            {
                Response.Redirect("../Accounts/ProOSV.aspx?voutype=" + Grd_Approval.DataKeys[Row_ID].Values[2].ToString() + "&1refno=" + Grd_Approval.Rows[Row_ID].Cells[2].Text + "&1vouyear=" + Grd_Approval.DataKeys[Row_ID].Values[0].ToString());

            }
        }
        protected void lnkdownload_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            GridViewRow GvRow = (GridViewRow)lb.NamingContainer;
            int Row_ID = GvRow.RowIndex;
            if (Grd_Approval.Rows[Row_ID].Cells[1].Text == "SALES INVOICE" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "PURCHASE INVOICE" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "SALES INVOICE OC" || Grd_Approval.Rows[Row_ID].Cells[1].Text == "PURCHASE INVOICE OC")
            {
                Response.Redirect("../Accounts/ProformaLV.aspx?rptvoutype=" + Grd_Approval.DataKeys[Row_ID].Values[2].ToString() + "&rptrefno=" + Grd_Approval.Rows[Row_ID].Cells[2].Text + "&rptvouyear=" + Grd_Approval.DataKeys[Row_ID].Values[0].ToString());
            }
            else
            {
                Response.Redirect("../Accounts/ProOSV.aspx?rptvtype=" + Grd_Approval.DataKeys[Row_ID].Values[2].ToString() + "&rptrefno=" + Grd_Approval.Rows[Row_ID].Cells[2].Text + "&rptvouyear=" + Grd_Approval.DataKeys[Row_ID].Values[0].ToString());

            }
        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = GridView6.SelectedRow.RowIndex;

            Response.Redirect("../CRM/Customersupport4All-Task.aspx?event=" + GridView6.SelectedRow.Cells[1].Text);
        }



        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView6, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



    }
}