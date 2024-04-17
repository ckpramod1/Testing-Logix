using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Home
{
    public partial class OECSHome : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Outstanding outobj = new DataAccess.Outstanding();
        DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataTable dt = new DataTable();
        DataTable dtable = new DataTable();
        int branchid, divisionid, vouyear, logempid;
        string ModuleName, trantype;
        string hname;
        long lngPQuot, lngInv, lngPA, lngDN, lngCN;
        string product;
        protected void Page_Load(object sender, EventArgs e)
        {
               ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_confirmationex2ex);
               ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_QuoTitle);
               ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_Div5);


             if (Session["StrTranType"].ToString() != null)
             {
                   trantype = Session["StrTranType"].ToString();
               }
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            if (!this.IsPostBack)
            {
                if (Session["StrTranType"] == "FE")
                {

                    LoadOceanEvent1();
                    Grd_Events.Visible = true;
                    PanelPendingEvent.Visible = true;
                    // LinkButton8.Visible = true;
                }
                stuffcount();
                //sailcount();
                //transcount();
                //DOcount();
                //DORequestcount();
                Booking_CountNew();
                App();
                Un_App();

                QuoTitle.Visible = false;
                StuffConfir.Visible = false;
                Div1.Visible = false;
                Div2.Visible = false;
                Div3.Visible = false;
                Div4.Visible = false;
                Div5.Visible = false;
                Panel1.Visible = false;
                dropdown.Visible = false;
                btngraph.Visible = false;
                Panel3.Visible = false;
                panelser.Visible = false;
                Grd_Status.Visible = false;
                lnk_QuoTitle.Visible = false;
                lnk_Div5.Visible = false;
                lnk_confirmationex2ex.Visible = false;
                // ddlEvents_SelectedIndexChanged(sender,e);
            }
        }

        public void LoadOceanEvent1()
        {
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Event Name (No.of Events)") });

            dt1.Rows.Add("Stuffing Confirm (" + leftObj.GetEventPendingOceanEXP("SC", branchid) + ")");
            hidStuffing.Text = System.Convert.ToString(leftObj.GetEventPendingOceanEXP("SC", branchid));

            dt1.Rows.Add("Loading Confirm (" + leftObj.GetEventPendingOceanEXP("LC", branchid) + ")");
            hidloading.Text = System.Convert.ToString(leftObj.GetEventPendingOceanEXP("LC", branchid));

            dt1.Rows.Add("Invoice/PL RecOn (" + leftObj.GetEventPendingOceanEXP("IR", branchid) + ")");
            hidInvoice.Text = System.Convert.ToString(leftObj.GetEventPendingOceanEXP("IR", branchid));

            dt1.Rows.Add("PreAlert SentOn (" + leftObj.GetEventPendingOceanEXP("PS", branchid) + ")");
            hidPreAlert.Text = System.Convert.ToString(leftObj.GetEventPendingOceanEXP("PS", branchid));

            dt1.Rows.Add("Docs SentOn (" + leftObj.GetEventPendingOceanEXP("DO", branchid) + ")");
            hidDocsSentOn.Text = System.Convert.ToString(leftObj.GetEventPendingOceanEXP("DO", branchid));

            dt1.Rows.Add("TranShipment (" + leftObj.GetEventPendingOceanEXP("TS", branchid) + ")");
            hidTranShipment.Text = System.Convert.ToString(leftObj.GetEventPendingOceanEXP("TS", branchid));

            dt1.Rows.Add("Delivery Request (" + leftObj.GetEventPendingOceanEXP("DR", branchid) + ")");
            hidDeliveryRequest.Text = System.Convert.ToString(leftObj.GetEventPendingOceanEXP("DR", branchid));

            dt1.Rows.Add("Delivery Status (" + leftObj.GetEventPendingOceanEXP("DS", branchid) + ")");
            hidDeliveryStatus.Text = System.Convert.ToString(leftObj.GetEventPendingOceanEXP("DS", branchid));

            Grd_Events.DataSource = dt1;
            Grd_Events.DataBind();
        }

        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Panel1.Visible = true;
            Grd_Status.Visible = true;
            LoadOceanEventStatus();
        }
        public void App()
        {
            dt = objJob.GetSalesBookingCount_new(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Session["StrTranType"].ToString());
            if (dt.Rows.Count > 0)
            {
                span_quotapp.InnerText = dt.Rows[0][0].ToString();
            }
            else
            {
                span_quotapp.InnerText = "0";
            }
        }
        public void Un_App()
        {
            dt = objJob.GetSalesBookingCount_new(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Session["StrTranType"].ToString());
            if (dt.Rows.Count > 0)
            {
                span_quotunapp.InnerText = dt.Rows[0][1].ToString();
            }
            else
            {
                span_quotunapp.InnerText = "0";
            }
        }
        public void Booking_CountNew()
        {
            dt = outobj.getbookinghomecount(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (dt.Rows.Count > 0)
            {
                lbl_outstanding.InnerText = dt.Rows[0]["Booking"].ToString();
            }
            else
            {
                lbl_outstanding.InnerText = "0";
            }

        }
        public void stuffcount()
        {
            DataAccess.BuyingRate objbuying = new DataAccess.BuyingRate();
            dt = objbuying.stuffingcount(trantype.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            span_stuff.InnerText = dt.Rows[0]["count"].ToString();
            span_sailcount.InnerText = dt.Rows[1]["count"].ToString();
            Span_DO.InnerText = dt.Rows[4]["count"].ToString();
            span_transcount.InnerText = dt.Rows[5]["count"].ToString();
            span_DOReq.InnerText = dt.Rows[6]["count"].ToString();

        }
        public void sailcount()
        {
            DataAccess.BuyingRate objbuying = new DataAccess.BuyingRate();
            dt = objbuying.stuffingcount(trantype.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

        }
        public void transcount()
        {
            DataAccess.BuyingRate objbuying = new DataAccess.BuyingRate();
            dt = objbuying.stuffingcount(trantype.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

        }
        public void DORequestcount()
        {
            DataAccess.BuyingRate objbuying = new DataAccess.BuyingRate();
            dt = objbuying.stuffingcount(trantype.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

        }
        //public void DOcount()
        //{
        //    DataAccess.BuyingRate objbuying = new DataAccess.BuyingRate();
        //    dt = objbuying.stuffingcount(trantype.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
        //    Span_DO.InnerText = dt.Rows[0]["Booking"].ToString();
        //}


        public void LoadOceanEventStatus()
        {
            DateTime dat, dat1;
            DataTable dtab = new DataTable();


            //if (sailingConfirmation.Text=="Sailing Confirmation")
            //{
            //     product = "Sailing Confirmation";
            //}
            //if (DoConfirmation.Text == "DO Confirmation")
            //{
            //    product = "DO Confirmation";
            //}
            //if (Transhipment.Text == "Transhipment Confirmation")
            //{
            //    product = "Transhipment Confirmation";
            //}
            //if (DORequest.Text == "DO Confirmation Request")
            //{
            //    product = "DO Confirmation Request";
            //}
            dtab.Columns.Add("Slno");
            dtab.Columns.Add("Booking");
            dtab.Columns.Add("bookingdate");
            dtab.Columns.Add("Job");
            dtab.Columns.Add("BL");
            dtab.Columns.Add("bldate");
            dtab.Columns.Add("Customer");
            dtab.Columns.Add("POR");
            dtab.Columns.Add("POL");
            dtab.Columns.Add("POD");
            dtab.Columns.Add("PlD");

            dtable = exrobj.GetEventPendingOECS(trantype, hid_stuffing.Value, branchid, divisionid);

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                dtab.Rows.Add();
                dtab.Rows[i]["Slno"] = dtable.Rows[i]["Slno"].ToString();
                dtab.Rows[i]["Booking"] = dtable.Rows[i]["Booking"].ToString();
                dat = Convert.ToDateTime(dtable.Rows[i]["bookingdate"]);
                dtab.Rows[i]["bookingdate"] = dat.ToShortDateString();
                dtab.Rows[i]["Job"] = dtable.Rows[i]["Job"].ToString();
                dtab.Rows[i]["BL"] = dtable.Rows[i]["BL"].ToString();
                dat1 = Convert.ToDateTime(dtable.Rows[i]["bldate"]);
                dtab.Rows[i]["bldate"] = dat1.ToShortDateString();
                dtab.Rows[i]["Customer"] = dtable.Rows[i]["Customer"].ToString();
                dtab.Rows[i]["POR"] = dtable.Rows[i]["POR"].ToString();
                dtab.Rows[i]["POL"] = dtable.Rows[i]["POL"].ToString();
                dtab.Rows[i]["POD"] = dtable.Rows[i]["POD"].ToString();
                dtab.Rows[i]["PlD"] = dtable.Rows[i]["PlD"].ToString();
            }

            ViewState["dtab"] = dtab;
            Grd_Status.DataSource = dtab;
            Grd_Status.DataBind();
            Grd_Status.Visible = true;
        }

        protected void lnk_preform_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();


            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1455, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    string OECSHome = "OECSHome";
                    Response.Redirect("../CRM/PerformanceTracking.aspx?OECSHome=" + OECSHome);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_preform, typeof(System.Web.UI.WebControls.LinkButton), "OECSHome", "alertify.alert('" + message + "');", true);
                }
            }



        }

        protected void lnk_event_track_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();


            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(573, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //Response.Redirect("../CRM/EventTracking.aspx");

                    string OECSHomeEventtracking = "OECSHomeEventtracking";
                    Response.Redirect("../CRM/EventTracking.aspx?OECSHomeEventtracking=" + OECSHomeEventtracking);
                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_event_track, typeof(System.Web.UI.WebControls.LinkButton), "OECSHome", "alertify.alert('" + message + "');", true);
                }
            }



        }

        protected void lnk_ship_query_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();


            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(533, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // Response.Redirect("../ForwardExports/Query.aspx");
                    string OECSHomeFEQuery = "OECSHomeFEQuery";
                    Response.Redirect("../ForwardExports/Query.aspx?OECSHomeFEQuery=" + OECSHomeFEQuery);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ship_query, typeof(System.Web.UI.WebControls.LinkButton), "OECSHome", "alertify.alert('" + message + "');", true);
                    return;
                }

            }



        }

        protected void lnk_vessel_sch_Click(object sender, EventArgs e)
        {


            DataTable dtuser = new DataTable();


            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(289, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // Response.Redirect("../CRM/SailingSchedule.aspx");

                    string OECSHomeFESailingSchedule = "OECSHomeFESailingSchedule";
                    Response.Redirect("../CRM/SailingSchedule.aspx?OECSHomeFESailingSchedule=" + OECSHomeFESailingSchedule);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ship_query, typeof(System.Web.UI.WebControls.LinkButton), "OECSHome", "alertify.alert('" + message + "');", true);
                    return;
                }

            }




        }

        protected void Grd_Status_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Status.PageIndex = e.NewPageIndex;
            Grd_Status.DataSource = (DataTable)ViewState["dtab"];
            Grd_Status.DataBind();
        }

        protected void Grd_Events_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Events, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Events_SelectedIndexChanged(object sender, EventArgs e)
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
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (Grd_Events.Rows.Count > 0)
            {
                index = Grd_Events.SelectedRow.RowIndex;
                name = Grd_Events.Rows[index].Cells[0].Text;
                name = name.Substring(0, name.IndexOf(" ("));

                str_RptName = "FEEvents.rpt";

                if (name == "Stuffing Confirm")
                {
                    Session["str_sfs"] = "isnull({FEEvent.stuffsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.stuffsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(Grd_Events, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Loading Confirm")
                {
                    Session["str_sfs"] = "isnull({FEEvent.lcsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.lcsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(Grd_Events, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Invoice/PL RecOn")
                {
                    Session["str_sfs"] = "isnull({FEEvent.invplrecon}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.invplrecon}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(Grd_Events, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "PreAlert SentOn")
                {
                    Session["str_sfs"] = "isnull({FEEvent.prealertsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.prealertsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(Grd_Events, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Docs SentOn")
                {
                    Session["str_sfs"] = "isnull({FEEvent.docssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.docssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(Grd_Events, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "TranShipment")
                {
                    Session["str_sfs"] = "isnull({FEEvent.tssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.tssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(Grd_Events, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Delivery Request")
                {
                    Session["str_sfs"] = "isnull({FEEvent.drsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.drsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(Grd_Events, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Delivery Status")
                {
                    Session["str_sfs"] = "isnull({FEEvent.dssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.dssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(Grd_Events, typeof(Button), "Pending Event Details", str_Script, true);
                }
            }
        }

        protected void btn_data_Click(object sender, EventArgs e)
        {
            Grd_Status.Visible = true;

            LoadOceanEventStatus();
        }

        protected void btn_graph_Click(object sender, EventArgs e)
        {
            ddlEvents.SelectedIndex = 0;
            // Panel1.Visible = false;
            Grd_Status.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "PieChart()", true);
        }

        protected void link_button1_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //954  955  956
            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(953, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                   // Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");
                    Response.Redirect("../Maintenance/MasterCustomerRequest.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

        
        }

        protected void lbl_jobclosing_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "FE")
            {

                dtuser = obj_UP.GetFormwiseuserRights(101, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    string name = Session["StrTranType"].ToString();
                    Response.Redirect("../ForwardExports/CostingDetails.aspx?OECSHOME=" + name);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lbl_jobclosing, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }


        }

        protected void lbl_customerprofile_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1785, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../ForwardExports/CustomerProfile.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(link_button1, typeof(System.Web.UI.WebControls.LinkButton), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
            }

            //Response.Redirect("../ForwardExports/CustomerProfile.aspx");
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

        protected void Stuffingconfirmation_Click(object sender, EventArgs e)
        {
            lnk_QuoTitle.Visible = false;
            lnk_Div5.Visible = false;
            lnk_confirmationex2ex.Visible = true;
            if (Stuffingconfirmation.Text == "")
            {
                hid_stuffing.Value = "SC";
            }
            QuoTitle.Visible = false;
            StuffConfir.Visible = true;
            span_stuff.Visible = true;
            Div1.Visible = false;
            Div2.Visible = false;
            Div3.Visible = false;
            Div4.Visible = false;
            Div5.Visible = false;
            panelser.Visible = true;
            Panel3.Visible = false;
            Panel1.Visible = false;
            LoadOceanEventStatus();
        }

        protected void sailingConfirmation_Click(object sender, EventArgs e)
        {
            lnk_QuoTitle.Visible = false;
            lnk_Div5.Visible = false;
            lnk_confirmationex2ex.Visible = true;
            if (sailingConfirmation.Text == "")
            {
                hid_stuffing.Value = "LC";
            }
            sailcount();
            QuoTitle.Visible = false;
            StuffConfir.Visible = false;
            Div1.Visible = true;
            Div2.Visible = false;
            Div3.Visible = false;
            Div4.Visible = false;
            Div5.Visible = false;
            panelser.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            LoadOceanEventStatus();
        }


        protected void Transhipment_Click(object sender, EventArgs e)
        {
            lnk_QuoTitle.Visible = false;
            lnk_Div5.Visible = false;
            lnk_confirmationex2ex.Visible = true;
            if (Transhipment.Text == "")
            {
                hid_stuffing.Value = "TS";
            }
            transcount();
            QuoTitle.Visible = false;
            StuffConfir.Visible = false;
            Div1.Visible = false;
            Div2.Visible = false;
            Div3.Visible = true;
            Div4.Visible = false;
            Div5.Visible = false;
            panelser.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            LoadOceanEventStatus();
        }

        protected void DORequest_Click(object sender, EventArgs e)
        {
            lnk_QuoTitle.Visible = false;
            lnk_Div5.Visible = false;
            lnk_confirmationex2ex.Visible = true;
            if (DORequest.Text == "")
            {
                hid_stuffing.Value = "DR";
            }
            DORequestcount();
            StuffConfir.Visible = false;
            Div1.Visible = false;
            Div2.Visible = false;
            Div3.Visible = false;
            Div4.Visible = true;
            Div5.Visible = false;
            QuoTitle.Visible = false;
            panelser.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            LoadOceanEventStatus();
        }

        protected void DoConfirmation_Click(object sender, EventArgs e)
        {
            lnk_QuoTitle.Visible = false;
            lnk_Div5.Visible = false;
            lnk_confirmationex2ex.Visible = true;
            if (DoConfirmation.Text == "")
            {
                hid_stuffing.Value = "DO";
            }
            QuoTitle.Visible = false;
            StuffConfir.Visible = false;
            Div1.Visible = false;
            Div2.Visible = true;
            Div3.Visible = false;
            Div4.Visible = false;
            Div5.Visible = false;
            panelser.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            LoadOceanEventStatus();
        }

        protected void Quotation_Click(object sender, EventArgs e)
        {
            lnk_QuoTitle.Visible = true;
            lnk_Div5.Visible = false;
            lnk_confirmationex2ex.Visible = false;
            DataAccess.Marketing.Quotation objQuat = new DataAccess.Marketing.Quotation();
            DataTable dataQuat = new DataTable();
            dataQuat = objQuat.GetQuation4salesnew(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            if (dataQuat.Rows.Count > 0)
            {
                grdQuatotion.DataSource = dataQuat;
                grdQuatotion.DataBind();
                if (grdQuatotion.Rows.Count > 0)
                {
                    for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                    {
                        if (grdQuatotion.Rows[i].Cells[8].Text == "UnApproved")
                        {
                            grdQuatotion.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                        }
                    }

                }
                ViewState["Quotation"] = dataQuat;
                //Panel1.Visible = false;
                panelser.Visible = false;
                grdQuatotion.Visible = true;
                Grd_Status.Visible = false;
                //for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                //{
                //    if (string.IsNullOrEmpty(dataQuat.Rows[i]["approvedon"].ToString()))
                //    {
                //        System.Web.UI.WebControls.Image ImageUnApp = grdQuatotion.Rows[i].FindControl("UnAppImage") as System.Web.UI.WebControls.Image;
                //        ImageUnApp.Visible = true;
                //    }
                //    else
                //    {
                //        System.Web.UI.WebControls.Image ImageApp = grdQuatotion.Rows[i].FindControl("AppImage") as System.Web.UI.WebControls.Image;
                //        ImageApp.Visible = true;
                //    }                    
                //}
            }
            else
            {
                grdQuatotion.DataSource = new DataTable();
                grdQuatotion.DataBind();
            }

        }

        protected void Quotation_Click1(object sender, EventArgs e)
        {
            lnk_QuoTitle.Visible = true;
            lnk_Div5.Visible = false;
            lnk_confirmationex2ex.Visible = false;
            DataAccess.Marketing.Quotation objQuat = new DataAccess.Marketing.Quotation();
            DataTable dataQuat = new DataTable();
            dataQuat = objQuat.SPGetQuaotationDetails4NewOECSnew(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Session["StrTranType"].ToString());
            Panel3.Visible = true;
            Panel1.Visible = false;
            QuoTitle.Visible = true;
            StuffConfir.Visible = false;
            Div1.Visible = false;
            Div2.Visible = false;
            Div3.Visible = false;
            Div4.Visible = false;
            if (dataQuat.Rows.Count > 0)
            {
                grdQuatotion.DataSource = dataQuat;
                grdQuatotion.DataBind();
                if (grdQuatotion.Rows.Count > 0)
                {
                    for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                    {
                        if (grdQuatotion.Rows[i].Cells[8].Text == "UnApproved")
                        {
                            grdQuatotion.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                        }
                    }

                }
                ViewState["Quotation"] = dataQuat;
                panelser.Visible = false;
                grdQuatotion.Visible = true;
                Grd_Status.Visible = false;
                //for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                //{
                //    if (string.IsNullOrEmpty(dataQuat.Rows[i]["approvedon"].ToString()))
                //    {
                //        System.Web.UI.WebControls.Image ImageUnApp = grdQuatotion.Rows[i].FindControl("UnAppImage") as System.Web.UI.WebControls.Image;
                //        ImageUnApp.Visible = true;
                //    }
                //    else
                //    {
                //        System.Web.UI.WebControls.Image ImageApp = grdQuatotion.Rows[i].FindControl("AppImage") as System.Web.UI.WebControls.Image;
                //        ImageApp.Visible = true;
                //    }                    
                //}
            }
            else
            {
                grdQuatotion.DataSource = new DataTable();
                grdQuatotion.DataBind();
            }

        }

        protected void grdQuatotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();

            string uiid = "";
            int Row_Index = grdQuatotion.SelectedRow.RowIndex;
            if (grdQuatotion.Rows[Row_Index].Cells[8].Text == "Approved")
            {
                if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "OE")
                {
                    uiid = "10";
                    dtuser = obj_UP.GetFormwiseuserRights(10, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Booking.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "OI")
                {
                    uiid = "11";
                    dtuser = obj_UP.GetFormwiseuserRights(11, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Booking.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "AE")
                {
                    uiid = "12";
                    dtuser = obj_UP.GetFormwiseuserRights(12, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Booking.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "AI")
                {
                    uiid = "13";
                    dtuser = obj_UP.GetFormwiseuserRights(13, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Booking.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            else if (grdQuatotion.Rows[Row_Index].Cells[8].Text == "UnApproved")
            {

                string app = "Quotation Approval";
                if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "OE")
                {
                    uiid = "181";
                    dtuser = obj_UP.GetFormwiseuserRights(181, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Quotation.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&type=" + app + "&uiid=" + uiid);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "OI")
                {
                    uiid = "181";
                    dtuser = obj_UP.GetFormwiseuserRights(180, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Quotation.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&type=" + app + "&uiid=" + uiid);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "AE")
                {
                    uiid = "217";
                    dtuser = obj_UP.GetFormwiseuserRights(217, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Quotation.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&type=" + app + "&uiid=" + uiid);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "AI")
                {
                    uiid = "215";
                    dtuser = obj_UP.GetFormwiseuserRights(215, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Quotation.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&type=" + app + "&uiid=" + uiid);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }
        }

        protected void grdQuatotion_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b2d9f7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdQuatotion, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            string uiid = "";
            if (hid_stuffing.Value == "SC")
            {
                if (Grd_Status.Rows.Count > 0)
                {
                    int index = Grd_Status.SelectedRow.RowIndex;
                    Label Bookingno = Grd_Status.Rows[index].FindControl("lbl_Booking") as Label;
                    string bookno = Bookingno.Text;
                    Label jobno = Grd_Status.Rows[index].FindControl("lbl_Job") as Label;
                    int job = Convert.ToInt32(jobno.Text);
                    string title = "Stuffing Confirmation";
                    uiid = "191";
                    dtuser = obj_UP.GetFormwiseuserRights(191, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");

                    if (dtuser.Rows.Count > 0)
                    {

                        Response.Redirect("../CRM/StuffingConfirmation.aspx?bookno=" + bookno + "&type=" + title + "&uiid=" + uiid + "&job=" + job);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(Grd_Status, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            if (hid_stuffing.Value == "LC")
            {
                if (Grd_Status.Rows.Count > 0)
                {
                    int index = Grd_Status.SelectedRow.RowIndex;
                    Label Bookingno = Grd_Status.Rows[index].FindControl("lbl_Booking") as Label;
                    string bookno = Bookingno.Text;
                    Label jobno = Grd_Status.Rows[index].FindControl("lbl_Job") as Label;
                    int job = Convert.ToInt32(jobno.Text);
                    string title = "Sailing Confirmation";
                    uiid = "191";
                    dtuser = obj_UP.GetFormwiseuserRights(191, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");

                    if (dtuser.Rows.Count > 0)
                    {

                        Response.Redirect("../CRM/StuffingConfirmation.aspx?bookno=" + bookno + "&type=" + title + "&uiid=" + uiid + "&job=" + job);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(Grd_Status, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            if (hid_stuffing.Value == "DO")
            {
                if (Grd_Status.Rows.Count > 0)
                {
                    int index = Grd_Status.SelectedRow.RowIndex;
                    Label Bookingno = Grd_Status.Rows[index].FindControl("lbl_Booking") as Label;
                    string bookno = Bookingno.Text;
                    Label jobno = Grd_Status.Rows[index].FindControl("lbl_Job") as Label;
                    int job = Convert.ToInt32(jobno.Text);
                    string title = "D O Confirmation";
                    uiid = "191";
                    dtuser = obj_UP.GetFormwiseuserRights(191, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");

                    if (dtuser.Rows.Count > 0)
                    {

                        Response.Redirect("../CRM/StuffingConfirmation.aspx?bookno=" + bookno + "&type=" + title + "&uiid=" + uiid + "&job=" + job);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(Grd_Status, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            if (hid_stuffing.Value == "TS")
            {
                if (Grd_Status.Rows.Count > 0)
                {
                    int index = Grd_Status.SelectedRow.RowIndex;
                    Label Bookingno = Grd_Status.Rows[index].FindControl("lbl_Booking") as Label;
                    string bookno = Bookingno.Text;
                    Label jobno = Grd_Status.Rows[index].FindControl("lbl_Job") as Label;
                    int job = Convert.ToInt32(jobno.Text);
                    string title = "Transhipment Confirmation";
                    uiid = "191";
                    dtuser = obj_UP.GetFormwiseuserRights(191, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");

                    if (dtuser.Rows.Count > 0)
                    {

                        Response.Redirect("../CRM/StuffingConfirmation.aspx?bookno=" + bookno + "&type=" + title + "&uiid=" + uiid + "&job=" + job);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(Grd_Status, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            if (hid_stuffing.Value == "DR")
            {
                if (Grd_Status.Rows.Count > 0)
                {
                    int index = Grd_Status.SelectedRow.RowIndex;
                    Label Blno = Grd_Status.Rows[index].FindControl("lbl_BL") as Label;
                    string blno = Blno.Text;
                    string title = "D O Confirmation - Request";
                    uiid = "79";
                    dtuser = obj_UP.GetFormwiseuserRights(79, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");

                    if (dtuser.Rows.Count > 0)
                    {

                        Response.Redirect("../CRM/LoadingConfirmation.aspx?blno=" + blno + "&type=" + title + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(Grd_Status, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }


        }

        protected void Grd_Status_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b2d9f7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Status, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void linkoust_Click(object sender, EventArgs e)
        {
            lnk_QuoTitle.Visible = false;
            lnk_Div5.Visible = true;
            lnk_confirmationex2ex.Visible = false;
            DataTable dt = new DataTable();

            Panel1.Visible = true;
            panelser.Visible = false;
            Grd_Status.Visible = false;
            QuoTitle.Visible = false;
            StuffConfir.Visible = false;
            Div5.Visible = true;
            Div1.Visible = false;
            Div2.Visible = false;
            Div3.Visible = false;
            Div4.Visible = false;
            Panel3.Visible = false;
            dt = outobj.getbookinghome(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (dt.Rows.Count > 0)
            {
                Gridbook.DataSource = dt;
                Gridbook.DataBind();

            }
            else
            {
                Gridbook.DataSource = new DataTable();
                Gridbook.DataBind();
            }
            ViewState["Gridbookexpexc"] = dt;
        }

        protected void lnk_QuoTitle_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["Quotation"] as DataTable;
            if (grdQuatotion.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Quotation.xls");
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



        protected void lnk_Div5_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["Gridbookexpexc"] as DataTable;
            if (Gridbook.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Booking.xls");
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

        protected void lnk_confirmationex2ex_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["dtab"] as DataTable;
            string title = "";
            if (Grd_Status.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");
                    if (hid_stuffing.Value == "SC")
                    {
                        title = "Stuffing Confirmation";
                    }
                    else if (hid_stuffing.Value == "LC")
                    {
                        title = "Sailing Confirmation";
                    }
                    else if (hid_stuffing.Value == "DO")
                    {
                        title = "D O Confirmation";
                    }
                    else if (hid_stuffing.Value == "TS")
                    {
                        title = "Transhipment Confirmation";
                    }
                    else if (hid_stuffing.Value == "DR")
                    {
                        title = "D O Confirmation - Request";
                    }
                    wb.Worksheets.Add(dt_check);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + title + ".xls");
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

                    Response.Redirect("../ForwardExports/FEEvents.aspx");


                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }
            }

        }

        protected void grdQuatotion_PreRender(object sender, EventArgs e)
        {
            if (grdQuatotion.Rows.Count > 0)
            {
                grdQuatotion.UseAccessibleHeader = true;
                grdQuatotion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Gridbook_PreRender(object sender, EventArgs e)
        {
            if (Gridbook.Rows.Count > 0)
            {
                Gridbook.UseAccessibleHeader = true;
                Gridbook.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_Status_PreRender(object sender, EventArgs e)
        {
            if (Grd_Status.Rows.Count > 0)
            {
                Grd_Status.UseAccessibleHeader = true;
                Grd_Status.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}