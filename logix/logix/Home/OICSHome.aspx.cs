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
    public partial class OICSHome : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Outstanding outobj = new DataAccess.Outstanding();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataAccess.BuyingRate objbuy = new DataAccess.BuyingRate();
        DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.CargoPickup objcar = new DataAccess.ForwardingImports.CargoPickup();
        DataTable dt = new DataTable();
        DataTable dtable = new DataTable();
        int branchid, divisionid, vouyear, logempid;
        string ModuleName, trantype;
        string hname;
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();

        DataAccess.ForwardingImports.CargoPickup obj_CorPicup = new DataAccess.ForwardingImports.CargoPickup();
        DataTable dtPick = new DataTable();
        string str_FornName, str_Uiid;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(pendingDO);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(finalnotice);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(reminder);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd_job);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Gridfinal);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_Quotationsexp2exc);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(link_pendingdo);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_CustomerLbl);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton2);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Link_prealert);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(link_canexp2exc);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(link_cargo);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton3);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_print); 
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_forwarder);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cnsg);

            trantype = Session["StrTranType"].ToString();
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());

            if (!this.IsPostBack)
            {
                if (Session["StrTranType"] == "FI")
                {
                    LoadOceanEventIMP();
                    GrdOceanExp1.Visible = true;
                    PanelPendingEvent.Visible = true;
                    GrdPendingCargo.Visible = false;
                    ddlEvents.Visible = false;
                    Panel1.Visible = false;
                    btn_data.Visible = false;
                    btn_graph.Visible = false;
                    pendingbookcount();
                    quatcountApp();
                    quatcountunapp();
                    // bookcount();
                    finalcount();
                    cargocount();
                    remindercount();
                    Counts_Blrelase();
                    pnlPortCountry1.Visible = false;
                    Panel5.Visible = false;
                    Widhead.Visible = false;
                    FinalNotice1.Visible = false;
                    FinalNotice2.Visible = false;
                    Quotations.Visible = false;

                    formgroup.Visible = false;
                    BookingUpdates.Visible = false;
                    PreAlert1.Visible = false;
                    CAN.Visible = false;
                    CargoPickedUp.Visible = false;
                    Customer1.Visible = false;
                    CustomerLbl.Visible = false;
                    pnl_rnotice.Visible = false;
                    lnk_Quotationsexp2exc.Visible = false;
                    link_pendingdo.Visible = false;
                    LinkButton2.Visible = false;
                    link_pendingdo.Visible = false;
                    lnk_CustomerLbl.Visible = false;
                    link_canexp2exc.Visible = false;
                    link_cargo.Visible = false;
                }

                // ddlEvents_SelectedIndexChanged(sender, e);
            }
        }

        public void LoadOceanEventIMP()
        {
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending-OceanImp") });

            dt1.Rows.Add("Covering Letter (" + leftObj.GetEventPendingOceanIMP("CS", branchid) + ")");
            hid_Cover.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("CS", branchid));

            dt1.Rows.Add("PreAlert SentOn (" + leftObj.GetEventPendingOceanIMP("PS", branchid) + ")");
            hid_Pre.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("PS", branchid));

            dt1.Rows.Add("Can/Inv SentOn (" + leftObj.GetEventPendingOceanIMP("CI", branchid) + ")");
            hid_Can.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("CI", branchid));

            dt1.Rows.Add("PA2Accs SentOn (" + leftObj.GetEventPendingOceanIMP("PA", branchid) + ")");
            hid_PA2Accs.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("PA", branchid));

            dt1.Rows.Add("Cheque RecOn (" + leftObj.GetEventPendingOceanIMP("CH", branchid) + ")");
            hid_Cheque.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("CH", branchid));

            dt1.Rows.Add("Line DO RecOn (" + leftObj.GetEventPendingOceanIMP("LD", branchid) + ")");
            hid_Line.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("LD", branchid));

            dt1.Rows.Add("Destuffed On (" + leftObj.GetEventPendingOceanIMP("DS", branchid) + ")");
            hid_Destuffed.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("DS", branchid));

            dt1.Rows.Add("DeVanning RecOn (" + leftObj.GetEventPendingOceanIMP("DR", branchid) + ")");
            hid_DeVanning.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("DR", branchid));

            dt1.Rows.Add("Refund RecOn (" + leftObj.GetEventPendingOceanIMP("RR", branchid) + ")");
            hid_Refund.Text = System.Convert.ToString(leftObj.GetEventPendingOceanIMP("RR", branchid));

            dtPick = obj_CorPicup.GetDetailsForCargoPickUp(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (dtPick.Rows.Count > 0)
            {
                hid_cargiPickup.Text = dtPick.Rows.Count.ToString();
            }
            else
            {
                hid_cargiPickup.Text = "0";
            }


            GrdOceanExp1.DataSource = dt1;
            GrdOceanExp1.DataBind();
        }

        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Panel1.Visible = true;
             Grd_Status1.Visible = true;
             Grd_Status.Visible = true;

             if (ddlEvents.SelectedValue == "PA")
             {
                 LoadOceanEventStatus1();
             }
             else
             {
                 LoadOceanEventStatus();
             }*/

            if (ddlEvents.SelectedValue == "PA")
            {

                GrdPendingCargo.Visible = false;
                Panel1.Visible = true;
                Grd_Status1.Visible = true;
                Grd_Status.Visible = true;
                LoadOceanEventStatus1();
            }
            else if (ddlEvents.SelectedValue == "PC")
            {
                Panel1.Visible = true;
                Grd_Status1.Visible = false;
                Grd_Status.Visible = false;
                GrdPendingCargo.Visible = true;
                Get_CargoPickup();
            }
            else
            {

                GrdPendingCargo.Visible = false;
                Panel1.Visible = true;
                Grd_Status1.Visible = true;
                Grd_Status.Visible = true;
                LoadOceanEventStatus();
            }
        }
        public void pendingbookcount()
        {
            dt = objbuy.pendingcountOICS(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            span_bookstatus.InnerText = dt.Rows[0]["count"].ToString();
            span_prealert.InnerText = dt.Rows[2]["count"].ToString();
            span_pendcan.InnerText = dt.Rows[1]["count"].ToString();

        }
        public void quatcountApp()
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
        public void quatcountunapp()
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

        //public void  bookcount()
        //{
        //    dt = outobj.getbookinghomecount(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
        //    if (dt.Rows.Count > 0)
        //    {
        //        book_count.InnerText = dt.Rows[0]["Booking"].ToString();
        //    }
        //    else
        //    {
        //        book_count.InnerText = "0";
        //    }
        //}
        public void cargocount()
        {
            dt = objcar.GetDetailsForCargoPickUpOICS(Convert.ToInt32(Session["LoginBranchid"]));
            span_cargo.InnerText = dt.Rows[0]["counts"].ToString();
        }

        public void LoadOceanEventStatus()
        {
            DateTime dat, dat1;
            DataTable dtab = new DataTable();
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

            dtable = exrobj.GetEventPendingOICS(trantype, ddlEvents.SelectedValue, branchid, divisionid);

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
            Grd_Status.Visible = true;
            Grd_Status1.Visible = false;
            ViewState["dtab"] = dtab;
            Grd_Status.DataSource = dtab;
            Grd_Status.DataBind();
        }

        public void Get_CargoPickup()
        {
            dtPick = obj_CorPicup.GetDetailsForCargoPickUp(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (dtPick.Rows.Count > 0)
            {
                GrdPendingCargo.DataSource = dtPick;
                GrdPendingCargo.DataBind();
                ViewState["dtPick"] = dtPick;
            }
            else
            {
                GrdPendingCargo.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdPendingCargo.DataBind();
            }
            ViewState["GrdPendingCargoExpr2exp"] = dtPick;
        }


        public void LoadOceanEventStatus1()
        {
            DateTime dat;
            DataTable dtab = new DataTable();
            dtab.Columns.Add("Slno");
            dtab.Columns.Add("Booking");
            dtab.Columns.Add("bookingdate");
            dtab.Columns.Add("Customer");
            dtab.Columns.Add("POR");
            dtab.Columns.Add("POL");
            dtab.Columns.Add("POD");
            dtab.Columns.Add("PlD");

            dtable = exrobj.GetEventPendingOICS(trantype, hid_value.Value, branchid, divisionid);

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                dtab.Rows.Add();
                dtab.Rows[i]["Slno"] = dtable.Rows[i]["Slno"].ToString();
                dtab.Rows[i]["Booking"] = dtable.Rows[i]["Booking"].ToString();
                dat = Convert.ToDateTime(dtable.Rows[i]["bookingdate"]);
                dtab.Rows[i]["bookingdate"] = dat.ToShortDateString();
                dtab.Rows[i]["Customer"] = dtable.Rows[i]["Customer"].ToString();
                dtab.Rows[i]["POR"] = dtable.Rows[i]["POR"].ToString();
                dtab.Rows[i]["POL"] = dtable.Rows[i]["POL"].ToString();
                dtab.Rows[i]["POD"] = dtable.Rows[i]["POD"].ToString();
                dtab.Rows[i]["PlD"] = dtable.Rows[i]["PlD"].ToString();
            }
            Grd_Status.Visible = false;
            Grd_Status1.Visible = true;
            ViewState["dtab1"] = dtab;
            Grd_Status1.DataSource = dtab;
            Grd_Status1.DataBind();

            ViewState["Grd_Status1exp2exc"] = dtab;
        }
        public void LoadOceanEventStatusprealert()
        {
            DateTime dat;
            DateTime datt;
            DataTable dtab = new DataTable();
            dtab.Columns.Add("Slno");
            dtab.Columns.Add("Booking");
            dtab.Columns.Add("bookingdate");
            dtab.Columns.Add("Job");
            dtab.Columns.Add("BL");
            dtab.Columns.Add("Date");
            dtab.Columns.Add("Customer");
            dtab.Columns.Add("POR");
            dtab.Columns.Add("POL");
            dtab.Columns.Add("POD");
            dtab.Columns.Add("PlD");

            dtable = exrobj.GetEventPendingOICS(trantype, hid_value.Value, branchid, divisionid);

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                dtab.Rows.Add();
                dtab.Rows[i]["Slno"] = dtable.Rows[i]["Slno"].ToString();
                dtab.Rows[i]["Booking"] = dtable.Rows[i]["Booking"].ToString();
                dat = Convert.ToDateTime(dtable.Rows[i]["bookingdate"]);
                dtab.Rows[i]["bookingdate"] = dat.ToShortDateString();
                dtab.Rows[i]["Job"] = dtable.Rows[i]["Job"].ToString();
                dtab.Rows[i]["BL"] = dtable.Rows[i]["BL"].ToString();
                datt = Convert.ToDateTime(dtable.Rows[i]["bldate"]);
                dtab.Rows[i]["Date"] = datt.ToShortDateString();
                dtab.Rows[i]["Customer"] = dtable.Rows[i]["Customer"].ToString();
                dtab.Rows[i]["POR"] = dtable.Rows[i]["POR"].ToString();
                dtab.Rows[i]["POL"] = dtable.Rows[i]["POL"].ToString();
                dtab.Rows[i]["POD"] = dtable.Rows[i]["POD"].ToString();
                dtab.Rows[i]["PlD"] = dtable.Rows[i]["PlD"].ToString();
            }
            Grd_Status.Visible = true;
            Grd_Status1.Visible = false;
            ViewState["dtab1"] = dtab;
            Grd_Status.DataSource = dtab;
            Grd_Status.DataBind();
            ViewState["Grd_Statusexport"] = dtab;
        }

        protected void Grd_Status1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Status1.PageIndex = e.NewPageIndex;
            Grd_Status1.DataSource = (DataTable)ViewState["dtab1"];
            Grd_Status1.DataBind();
        }

        protected void Grd_Status_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Status.PageIndex = e.NewPageIndex;
            Grd_Status.DataSource = (DataTable)ViewState["dtab"];
            Grd_Status.DataBind();
        }

        protected void lnk_preform_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(334, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    //  Response.Redirect("../FI/FIEvenTrucking.aspx");

                    string OICSHomeFIEvenTrucking = "OICSHomeFIEvenTrucking";
                    Response.Redirect("../FI/FIEvenTrucking.aspx?OICSHomeFIEvenTrucking=" + OICSHomeFIEvenTrucking);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_preform, typeof(System.Web.UI.WebControls.LinkButton), "OICSHome", "alertify.alert('" + message + "');", true);

                }
            }




        }

        protected void lnk_ship_query_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();

            if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(534, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    // Response.Redirect("../ForwardExports/Query.aspx");
                    string OECSHomeFIQuery = "OECSHomeFIQuery";
                    Response.Redirect("../ForwardExports/Query.aspx?OECSHomeFIQuery=" + OECSHomeFIQuery);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_ship_query, typeof(System.Web.UI.WebControls.LinkButton), "OECSHome", "alertify.alert('" + message + "');", true);
                    return;
                }

            }




        }

        protected void lnk_preform_track_Click(object sender, EventArgs e)
        {


            DataTable dtuser = new DataTable();


            if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(679, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    string OICSHOMEEventTrackingOper = "OICSHOMEEventTrackingOper";
                    Response.Redirect("../CRM/EventTrackingOper.aspx?OICSHOMEEventTrackingOper=" + OICSHOMEEventTrackingOper);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_preform, typeof(System.Web.UI.WebControls.LinkButton), "OECSHome", "alertify.alert('" + message + "');", true);
                }
            }


        }

        protected void GrdOceanExp1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdOceanExp1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
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
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (GrdOceanExp1.Rows.Count > 0)
            {
                index = GrdOceanExp1.SelectedRow.RowIndex;
                name = GrdOceanExp1.Rows[index].Cells[0].Text;
                name = name.Substring(0, name.IndexOf(" ("));

                str_RptName = "FIEvents.rpt";

                if (name == "Covering Letter")
                {
                    Session["str_sfs"] = "isnull({FIEvent.coveringsenton}) and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.coveringsenton}) and {FIEvent.bid}=" + branchid;
                    str_sp = "title=Covering Letter";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "PreAlert SentOn")
                {
                    Session["str_sfs"] = "isnull({FIEvent.prealertsenton})and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.prealertsenton})and {FIEvent.bid}=" + branchid;
                    str_sp = "title=PreAlert SentOn";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Can/Inv SentOn")
                {
                    Session["str_sfs"] = "isnull({FIEvent.caninvsenton})and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.caninvsenton})and {FIEvent.bid}=" + branchid;
                    str_sp = "title=CAN/Invoice SentOn";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Destuffed On")
                {
                    Session["str_sfs"] = "isnull({FIEvent.destuffedon})and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.destuffedon})and {FIEvent.bid}=" + branchid;
                    str_sp = "title=Destuffed On";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "PA2Accs SentOn")
                {
                    Session["str_sfs"] = "isnull({FIEvent.pa2accsenton})and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.pa2accsenton})and {FIEvent.bid}=" + branchid;
                    str_sp = "title=PA2Accounts SentOn";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Cheque RecOn")
                {
                    Session["str_sfs"] = "isnull({FIEvent.chqrecon})and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.chqrecon})and {FIEvent.bid}=" + branchid;
                    str_sp = "title=Cheque ReceivedOn";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Line DO RecOn")
                {
                    Session["str_sfs"] = "isnull({FIEvent.linedorecon})and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.linedorecon})and {FIEvent.bid}=" + branchid;
                    str_sp = "title=Line DO ReceivedOn";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "DeVanning RecOn")
                {
                    Session["str_sfs"] = "isnull({FIEvent.devanningrecon})and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.devanningrecon})and {FIEvent.bid}=" + branchid;
                    str_sp = "title=DeVanning ReceivedOn";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Refund RecOn")
                {
                    Session["str_sfs"] = "isnull({FIEvent.refundrecon}) and {FIEvent.bid}=" + branchid;
                    str_sf = "isnull({FIEvent.refundrecon}) and {FIEvent.bid}=" + branchid;
                    str_sp = "title=Refund ReceivedOn";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdOceanExp1, typeof(Button), "Pending Event Details", str_Script, true);
                }
            }
        }

        protected void btn_data_Click(object sender, EventArgs e)
        {
            /*   if (ddlEvents.SelectedValue == "PA")
               {
                   LoadOceanEventStatus1();
               }
               else
               {
                   LoadOceanEventStatus();
               }*/

            if (ddlEvents.SelectedValue == "PA")
            {
                Panel1.Visible = true;
                Grd_Status1.Visible = true;
                Grd_Status.Visible = true;
                GrdPendingCargo.Visible = false;
                LoadOceanEventStatus1();
            }
            else if (ddlEvents.SelectedValue == "PC")
            {
                Panel1.Visible = true;
                Grd_Status1.Visible = false;
                Grd_Status.Visible = false;
                GrdPendingCargo.Visible = true;
                Get_CargoPickup();
            }
            else
            {
                Panel1.Visible = true;
                Grd_Status1.Visible = true;
                Grd_Status.Visible = true;
                GrdPendingCargo.Visible = false;
                LoadOceanEventStatus();
            }
        }

        protected void btn_graph_Click(object sender, EventArgs e)
        {
            ddlEvents.SelectedIndex = 0;
            Panel1.Visible = false;
            Grd_Status1.Visible = false;
            GrdPendingCargo.Visible = false;
            Grd_Status.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "PieChart()", true);
        }

        protected void link_button1_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();   //954  955  956
            if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(954, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
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

        protected void lbl_customerprofile_Click(object sender, EventArgs e)
        {

            DataTable dtuser = new DataTable();   //1786  1787  1788
            if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1786, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
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

        protected void lbl_jobclosing_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(102, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
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
        protected void GrdPendingCargo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GrdPendingCargo.PageIndex = e.NewPageIndex;
            GrdPendingCargo.DataSource = (DataTable)ViewState["dtPick"];
            GrdPendingCargo.DataBind();
        }

        protected void GrdPendingCargo_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPendingCargo, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(117, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../FI/FIDeliveryStatus.aspx");

                }
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

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

        protected void pendingupdatebookingstatus_Click(object sender, EventArgs e)
        {
            link_cargo.Visible = false;
            link_canexp2exc.Visible = false;
            lnk_CustomerLbl.Visible = false;
            LinkButton2.Visible = true;
            if (pendingupdatebookingstatus.Text == "")
            {
                hid_value.Value = "PA";
            }
            Panel1.Visible = true;
            Grd_Status1.Visible = true;
            Grd_Status.Visible = true;
            GrdPendingCargo.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            pnlPortCountry1.Visible = false;
            Widhead.Visible = false;
            Panel5.Visible = false;
            FinalNotice1.Visible = false;
            FinalNotice2.Visible = false;
            Quotations.Visible = false;
            formgroup.Visible = false;
            BookingUpdates.Visible = true;
            PreAlert1.Visible = false;
            CAN.Visible = false;
            CargoPickedUp.Visible = false;
            Customer1.Visible = false;
            CustomerLbl.Visible = false;
            pnl_rnotice.Visible = false;
            lnk_Quotationsexp2exc.Visible = false;
            link_pendingdo.Visible = false;
            Link_prealert.Visible = false;
            LoadOceanEventStatus1();

        }

        protected void prealert_Click(object sender, EventArgs e)
        {
            if (prealert.Text == "")
            {
                hid_value.Value = "PS";
            }
            GrdPendingCargo.Visible = false;
            Panel1.Visible = true;
            Grd_Status1.Visible = true;
            Grd_Status.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            pnlPortCountry1.Visible = false;
            Widhead.Visible = false;
            Panel5.Visible = false;
            FinalNotice1.Visible = false;
            FinalNotice2.Visible = false;
            Quotations.Visible = false;
            formgroup.Visible = false;
            BookingUpdates.Visible = false;
            CargoPickedUp.Visible = false;
            PreAlert1.Visible = true;
            CAN.Visible = false;
            Customer1.Visible = false;
            CustomerLbl.Visible = false;
            pnl_rnotice.Visible = false;
            LoadOceanEventStatusprealert();
            lnk_Quotationsexp2exc.Visible = false;
            link_pendingdo.Visible = false;
            Link_prealert.Visible = true;
            LinkButton2.Visible = false;
            lnk_CustomerLbl.Visible = false;
            link_canexp2exc.Visible = false;
        }

        protected void pendingCAN_Click(object sender, EventArgs e)
        {
            if (pendingCAN.Text == "")
            {
                hid_value.Value = "CI";
            }
            GrdPendingCargo.Visible = false;
            paneremin.Visible = false;
            Panel1.Visible = true;
            Grd_Status1.Visible = true;
            Grd_Status.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            pnlPortCountry1.Visible = false;
            Panel5.Visible = false;
            Widhead.Visible = false;
            FinalNotice1.Visible = false;
            FinalNotice2.Visible = false;
            Quotations.Visible = false;

            formgroup.Visible = false;
            BookingUpdates.Visible = false;
            PreAlert1.Visible = false;
            CargoPickedUp.Visible = false;
            Customer1.Visible = false;
            CustomerLbl.Visible = false;
            pnl_rnotice.Visible = false;
            CAN.Visible = true;
            lnk_Quotationsexp2exc.Visible = false;
            link_pendingdo.Visible = false;
            Link_prealert.Visible = false;
            LinkButton2.Visible = false;
            lnk_CustomerLbl.Visible = false;

            link_canexp2exc.Visible = true;

            LoadOceanEventStatusprealert();
        }

        protected void pendingcargo_Click(object sender, EventArgs e)
        {

            if (pendingcargo.Text == "")
            {
                hid_value.Value = "PC";
            }
            Panel1.Visible = true;
            paneremin.Visible = false;
            Grd_Status1.Visible = false;
            Grd_Status.Visible = false;
            GrdPendingCargo.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            pnlPortCountry1.Visible = false;
            Panel5.Visible = false;
            FinalNotice1.Visible = false;
            FinalNotice2.Visible = false;
            Widhead.Visible = false;
            Quotations.Visible = false;
            formgroup.Visible = false;
            BookingUpdates.Visible = false;
            PreAlert1.Visible = false;
            CAN.Visible = false;
            Customer1.Visible = false;
            CustomerLbl.Visible = false;
            pnl_rnotice.Visible = false;
            CargoPickedUp.Visible = true;
            lnk_Quotationsexp2exc.Visible = false;
            link_pendingdo.Visible = false;
            Link_prealert.Visible = false;
            LinkButton2.Visible = false;
            lnk_CustomerLbl.Visible = false;
            link_canexp2exc.Visible = false;
            link_cargo.Visible = true;
            Get_CargoPickup();

        }

        protected void booking_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
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
        }

        protected void Quotation_Click(object sender, EventArgs e)
        {
            link_cargo.Visible = false;
            link_canexp2exc.Visible = false;
            lnk_CustomerLbl.Visible = false;
            LinkButton2.Visible = false;
            lnk_Quotationsexp2exc.Visible = true;
            DataAccess.Marketing.Quotation objQuat = new DataAccess.Marketing.Quotation();
            DataTable dataQuat = new DataTable();
            dataQuat = objQuat.SPGetQuaotationDetails4NewOECSnew(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Session["StrTranType"].ToString());
            Panel4.Visible = true;
            Panel1.Visible = false;
            pnlPortCountry1.Visible = false;
            Panel5.Visible = false;
            Widhead.Visible = false;
            FinalNotice1.Visible = false;
            FinalNotice2.Visible = false;
            formgroup.Visible = false;
            Quotations.Visible = true;
            BookingUpdates.Visible = false;
            PreAlert1.Visible = false;
            CAN.Visible = false;
            CargoPickedUp.Visible = false;
            link_pendingdo.Visible = false;
            Customer1.Visible = false;
            pnl_rnotice.Visible = false;
            Link_prealert.Visible = false;
            if (dataQuat.Rows.Count > 0)
            {
                grdQuatotion.DataSource = dataQuat;
                grdQuatotion.DataBind();
                ViewState["grdQuatotionexport"] = dataQuat;
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
            }
        }

        protected void Grd_Status1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            string uiid = "";
            if (hid_value.Value == "PA")
            {
                if (Grd_Status1.Rows.Count > 0)
                {
                    int index = Grd_Status1.SelectedRow.RowIndex;
                    Label Bookingno = Grd_Status1.Rows[index].FindControl("lbl_Booking") as Label;
                    string bookno = Bookingno.Text;
                    string title = "Update Booking Status";
                    uiid = "762";
                    dtuser = obj_UP.GetFormwiseuserRights(762, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");

                    if (dtuser.Rows.Count > 0)
                    {

                        Response.Redirect("../FI/FIBookingBL.aspx?bookno=" + bookno + "&type=" + title + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(Grd_Status1, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }



        }

        protected void Grd_Status1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Status1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            string uiid = "";
            if (hid_value.Value == "PS")
            {
                if (Grd_Status.Rows.Count > 0)
                {
                    int index = Grd_Status.SelectedRow.RowIndex;
                    Label Bookingno = Grd_Status.Rows[index].FindControl("lbl_Job") as Label;
                    string jobno = Bookingno.Text;
                    string title = "Pre Alert";
                    uiid = "112";
                    dtuser = obj_UP.GetFormwiseuserRights(112, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");

                    if (dtuser.Rows.Count > 0)
                    {

                        Response.Redirect("../FI/FIPreAlertNew.aspx?jobno=" + jobno + "&type=" + title + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(Grd_Status, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }

            if (hid_value.Value == "CI")
            {
                if (Grd_Status.Rows.Count > 0)
                {
                    int index = Grd_Status.SelectedRow.RowIndex;
                    Label Bookingno = Grd_Status.Rows[index].FindControl("lbl_Job") as Label;
                    string jobno = Bookingno.Text;
                    string title = " Cargo Arrival Notice";
                    uiid = "113";
                    dtuser = obj_UP.GetFormwiseuserRights(113, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");

                    if (dtuser.Rows.Count > 0)
                    {

                        Response.Redirect("../FI/FICAN.aspx?jobno=" + jobno + "&type=" + title + "&uiid=" + uiid);
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

        protected void GrdPendingCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            string uiid = "";
            if (GrdPendingCargo.Rows.Count > 0)
            {
                //Response.Redirect("../FI/CargoPickedUp.aspx");
                int index = GrdPendingCargo.SelectedRow.RowIndex;
                Label consignee1 = GrdPendingCargo.Rows[index].FindControl("lbl_consignee") as Label;
                int conginid = Convert.ToInt32(GrdPendingCargo.Rows[index].Cells[7].Text);
                string consigneename = consignee1.Text;
                //string title = "Cargo Picked Up";
                uiid = "1076";
                dtuser = obj_UP.GetFormwiseuserRights(1076, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");

                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../FI/CargoPickedUp.aspx?consigneename=" + consigneename + "&conginid=" + conginid);
                    //Response.Redirect("../FI/CargoPickedUp.aspx");
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(GrdPendingCargo, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }
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
                    uiid = "14";
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
                    uiid = "15";
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
                    uiid = "16";
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
                    uiid = "17";
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

        protected void reminder_Click(object sender, EventArgs e)
        {
            pnlPortCountry1.Visible = false;
            Panel5.Visible = false;
            GridView2.Visible = false;
            Grd_Status1.Visible = false;
            Grd_Status.Visible = false;
            Panel1.Visible = false;
            GrdPendingCargo.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            FinalNotice1.Visible = false;
            FinalNotice2.Visible = false;
            Quotations.Visible = false;
            BookingUpdates.Visible = false;
            PreAlert1.Visible = false;
            CAN.Visible = false;
            CargoPickedUp.Visible = false;
            Customer1.Visible = false;
            CustomerLbl.Visible = false;
            pnl_rnotice.Visible = false;
            bind();
            paneremin.Visible = true;
            Widhead.Visible = true;
            formgroup.Visible = true;
            lnk_Quotationsexp2exc.Visible = false;
            link_pendingdo.Visible = false;
            Link_prealert.Visible = false;
            LinkButton2.Visible = false;
            lnk_CustomerLbl.Visible = false;
            link_canexp2exc.Visible = false;
            link_cargo.Visible = false;
        }

        public void remindercount()
        {
            DataTable obj_dtreminder = new DataTable();
            DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            obj_dtreminder = obj_da_can.GetDetailsremindernoticecount(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            spanreminder.InnerText = obj_dtreminder.Rows[0]["counts"].ToString();
        }
        public void finalcount()
        {
            DataTable obj_dtreminder = new DataTable();
            DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            obj_dtreminder = obj_da_can.GetDetailsfinalnoticecount(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            spanfinal.InnerText = obj_dtreminder.Rows[0]["counts"].ToString();
        }

        protected void pendingDO_Click(object sender, EventArgs e)
        {
            link_cargo.Visible = false;
            link_canexp2exc.Visible = false;

            lnk_CustomerLbl.Visible = false;
            link_pendingdo.Visible = true;
            LinkButton2.Visible = false;
            paneremin.Visible = false;
            pnlPortCountry1.Visible = false;
            Panel5.Visible = false;
            GridView2.Visible = false;
            Grd_Status1.Visible = false;
            Grd_Status.Visible = false;
            Panel1.Visible = false;
            GrdPendingCargo.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            formgroup.Visible = false;
            Panel4.Visible = false;
            Widhead.Visible = false;
            FinalNotice1.Visible = false;
            FinalNotice2.Visible = false;
            Quotations.Visible = false;
            BookingUpdates.Visible = false;
            PreAlert1.Visible = false;
            CargoPickedUp.Visible = false;
            CAN.Visible = false;
            CustomerLbl.Visible = false;
            Customer1.Visible = true;
            pendingHBLFE();
            link_pendingdo.Visible = true;
            lnk_Quotationsexp2exc.Visible = false;
            Link_prealert.Visible = false;
        }
        public void pendingHBLFE()
        {
            //if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
            //{
            //    lbl_blPen.InnerText = "Pending BLs";
            //}
            //else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
            //{
            //    lbl_blPen.InnerText = "Pending AWB";
            //}
            DataTable dthbl = new DataTable();
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dthbl = leftObj.GetFEHBLDetailsForNewOpsDoc(Strtrantype, branchid);
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
                //if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                //{
                //    GrdPort1.Columns[2].HeaderText = "BLs";
                //}
                //else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                //{
                //    GrdPort1.Columns[2].HeaderText = "AWB";
                //}

                GrdPort1.DataBind();
                ViewState["GrdPort1export"] = dtTemp;
                //  pop_hblgrd.Show();
                ViewState["hbl"] = dthbl;
                pnlPortCountry1.Visible = true;
                Panel5.Visible = false;
                GridView2.Visible = false;
            }
            else
            {
                GrdPort1.Visible = true;
                DataTable DtTemp = new DataTable();
                //DtTemp.Columns.Add("Bl #");
                GrdPort1.DataSource = DtTemp;
                //if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                //{
                //    GrdCuswise.Columns[2].HeaderText = "BLs";
                //}
                //else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                //{
                //    GrdCuswise.Columns[2].HeaderText = "AWB";
                //}
                GrdPort1.DataBind();
                Panel5.Visible = false;
                GridView2.Visible = false;
            }
        }
        public void Counts_Blrelase()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            DataTable dthbl = new DataTable();

            dthbl = leftObj.GetFEHBLDetailsForNew(Strtrantype, branchid);
            if (dthbl.Rows.Count > 0)
            {
                span_pendingdo.InnerText = dthbl.Rows[0][0].ToString();
            }
            else
            {
                span_pendingdo.InnerText = "0";
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
                    Label lbl = (Label)e.Row.Cells[i].FindControl("shipperName");
                    if (lbl.Text != "Total")
                    {
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPort1, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }

                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b2d9f7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

            }

        }

        protected void GrdPort1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int shipper = 0;
            DataTable dthbl = new DataTable();
            int index = GrdPort1.SelectedRow.RowIndex;
            Label lal = (Label)GrdPort1.Rows[index].FindControl("shipperName");
            CustomerLbl.InnerText = lal.Text;
            //lbl_Bl.Text = GrdPort1.Rows[index].Cells[1].Text.ToString();
            shipper = Convert.ToInt32(GrdPort1.Rows[index].Cells[3].Text.ToString());
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dthbl = leftObj.GetFEHBLDetailsForNewOpsDocNew(Strtrantype, branchid, shipper);
            if (dthbl.Rows.Count > 0)
            {
                if (Session["StrTranType"].ToString() == "FI")
                {
                    //Panel3.Visible = true;
                    //Panel7.Visible = false;
                    GridView2.DataSource = dthbl;
                    GridView2.DataBind();
                    CustomerLbl.Visible = true;
                }


            }
            else
            {
                if (Session["StrTranType"].ToString() == "FI")
                {
                    // Panel3.Visible = true;
                    //Panel7.Visible = false;
                    GridView2.DataSource = new DataTable();
                    GridView2.DataBind();
                }

            }
            lnk_CustomerLbl.Visible = true;
            ViewState["GridView2exp2exc"] = dthbl;
            Panel5.Visible = true;
            GridView2.Visible = true;
        }
        public void bind()
        {
            DataTable obj_dtreminder = new DataTable();
            DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
            obj_dtreminder = obj_da_can.GetDetailsremindernotice(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            grd_job.DataSource = obj_dtreminder;
            grd_job.DataBind();
            // btn_cancel.Text = "Cancel";
        }




        protected void grd_job_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_job.PageIndex = e.NewPageIndex;
            bind();


        }

        protected void finalnotice_Click(object sender, EventArgs e)
        {
            Grd_Status1.Visible = false;
            Grd_Status.Visible = false;
            GrdPendingCargo.Visible = false;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            formgroup.Visible = false;
            Panel4.Visible = false;
            Widhead.Visible = false;
            paneremin.Visible = false;
            Quotations.Visible = false;
            BookingUpdates.Visible = false;
            PreAlert1.Visible = false;
            CAN.Visible = false;
            CargoPickedUp.Visible = false;
            Customer1.Visible = false;
            CustomerLbl.Visible = false;
            Panel6.Visible = false;
            pnl_rnotice.Visible = false;
            bindfinal();
            FinalNotice2.Visible = true;
            FinalNotice1.Visible = true;
            Label1.Visible = true;
            lnk_Quotationsexp2exc.Visible = false;
            link_pendingdo.Visible = false;
            Link_prealert.Visible = false;
            LinkButton2.Visible = false;

            link_pendingdo.Visible = false;

            lnk_CustomerLbl.Visible = false;
            link_canexp2exc.Visible = false;
            link_cargo.Visible = false;
        }

        public void bindfinal()
        {
            try
            {
                DataTable obj_dtfinal = new DataTable();
                DataAccess.ForwardingImports.CAN obj_da_can = new DataAccess.ForwardingImports.CAN();
                obj_dtfinal = obj_da_can.GetDetailsfinalnotice(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                Gridfinal.DataSource = obj_dtfinal;
                Gridfinal.DataBind();
                // btn_cancel.Text = "Cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Gridfinal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridfinal.PageIndex = e.NewPageIndex;
            bindfinal();
        }

        protected void Gridfinal_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Gridfinal, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Gridfinal_SelectedIndexChanged(object sender, EventArgs e)
        {

            hf_grdjob_index.Value = Gridfinal.SelectedRow.RowIndex.ToString();
            hf_jobno.Value = ((Label)Gridfinal.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].FindControl("Job")).Text;
            //grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].Text.ToString();
            fn_grdjob_Select1();
            UserRights1();
        }
        public void fn_grdjob_Select1()
        {
            try
            {
                DataTable obj_dtFnotice = new DataTable();
                DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
                int index = Convert.ToInt32(hf_grdjob_index.Value);
                //txt_vslvoy.Text = grd_job.Rows[index].Cells[1].Text.ToString();
                //txt_agent.Text = grd_job.Rows[index].Cells[2].Text.ToString();
                //txt_line.Text = grd_job.Rows[index].Cells[3].Text.ToString();
                //txt_eta.Text = grd_job.Rows[index].Cells[4].Text.ToString(); ;
                //txt_etb.Text = grd_job.Rows[index].Cells[5].Text.ToString();

                txt_vessel.Text = ((Label)Gridfinal.Rows[index].Cells[1].FindControl("Vessel")).Text;
                txtagent.Text = ((Label)Gridfinal.Rows[index].Cells[2].FindControl("Agent")).Text;
                txtline.Text = ((Label)Gridfinal.Rows[index].Cells[3].FindControl("MLO")).Text;
                txteta.Text = ((Label)Gridfinal.Rows[index].Cells[4].FindControl("ETA")).Text;
                txtetb.Text = ((Label)Gridfinal.Rows[index].Cells[5].FindControl("ETB")).Text;
                obj_dtFnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtFnotice.Rows.Count > 0)
                {
                    Panel6.Visible = true;
                    ddl_hblno.DataSource = obj_dtFnotice;
                    //ddl_hblno.DataValueField="blno";
                    txthbl.DataTextField = "blno";
                    txthbl.DataBind();
                }
                Mbl_popup.Show();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void UserRights1()
        {
            string str_FornName;
            string str_Uiid;
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    Boolean btn_delete;
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_print, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    //obj_Dtuser = obj_dtview.ToTable();
                    //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grd_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            hf_grdjob_index.Value = grd_job.SelectedRow.RowIndex.ToString();
            hf_jobno.Value = ((Label)grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].FindControl("Job")).Text;
            //grd_job.Rows[Convert.ToInt32(hf_grdjob_index.Value)].Cells[0].Text.ToString();
            fn_grdjob_Select();
            UserRights1();
        }
        public void fn_grdjob_Select()
        {
            //Mdl_rnotice.Hide();
            DataTable obj_dtRnotice = new DataTable();
            DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            int index = Convert.ToInt32(hf_grdjob_index.Value);
            //txt_vslvoy.Text = grd_job.Rows[index].Cells[1].Text.ToString();
            //txt_agent.Text = grd_job.Rows[index].Cells[2].Text.ToString();
            //txt_line.Text = grd_job.Rows[index].Cells[3].Text.ToString();
            //txt_eta.Text = grd_job.Rows[index].Cells[4].Text.ToString();
            //txt_etb.Text = grd_job.Rows[index].Cells[5].Text.ToString();

            txt_vslvoy.Text = ((Label)grd_job.Rows[index].Cells[1].FindControl("Vessel")).Text;
            txt_agent.Text = ((Label)grd_job.Rows[index].Cells[2].FindControl("Agent")).Text;
            txt_line.Text = ((Label)grd_job.Rows[index].Cells[3].FindControl("MLO")).Text;
            txt_eta.Text = ((Label)grd_job.Rows[index].Cells[4].FindControl("ETA")).Text;
            txt_etb.Text = ((Label)grd_job.Rows[index].Cells[5].FindControl("ETB")).Text;
            obj_dtRnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (obj_dtRnotice.Rows.Count > 0)
            {
                pnl_rnotice.Visible = true;
                ddl_hblno.DataSource = obj_dtRnotice;
                //ddl_hblno.DataValueField="blno";
                ddl_hblno.DataTextField = "blno";
                ddl_hblno.DataBind();
            }

            Mdl_rnotice.Show();

        }
        protected void UserRights()
        {
            string str_FornName;
            string str_Uiid;
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    Boolean btn_delete;
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, null, btn_cnsg, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_Quotationsexp2exc_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["grdQuatotionexport"] as DataTable;

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
                    Response.AddHeader("content-disposition", "attachment;filename=Quotations Approval and UnApproval.xls");
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

        protected void link_pendingdo_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["GrdPort1export"] as DataTable;

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
                    Response.AddHeader("content-disposition", "attachment;filename=Pending Do.xls");
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

        protected void Link_prealert_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["Grd_Statusexport"] as DataTable;

            if (Grd_Status.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Pre-Alert.xls");
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

        protected void lnk_CustomerLbl_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["GridView2exp2exc"] as DataTable;

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
                    Response.AddHeader("content-disposition", "attachment;filename=PendingDo.xls");
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

        protected void link_canexp2exc_Click(object sender, EventArgs e)
        {


            DataTable dt_check = ViewState["dtPick"] as DataTable;

            if (GrdPendingCargo.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=CAN.xls");
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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {


            DataTable dt_check = ViewState["Grd_Status1exp2exc"] as DataTable;

            if (Grd_Status1.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Booking Updates.xls");
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

        protected void link_cargo_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["GrdPendingCargoExpr2exp"] as DataTable;
            dt_check.Columns.Remove("consigneeid");
            if (GrdPendingCargo.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=CargoPickedup.xls");
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

            if (trantype_process == "FI")
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


        public void fn_btnprint_Click()
        {
            string str_frmname = "";
            string str_RptName = "";
            string str_BL = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";

            DataTable obj_dtfnotice = new DataTable();
            DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();

            str_BL = ddl_hblno.SelectedValue.ToString();
            if (str_BL == "")
            {

                obj_dtfnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtfnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtfnotice.Rows[0][3].ToString();
                }
            }
            else
            {
                obj_dtfnotice = obj_da_reminder.GetBLNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtfnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtfnotice.Rows[0][3].ToString();
                }
            }

            if (str_BL != "")
            {
                str_frmname = "FinalNotice";
                str_RptName = "FIFinalNotice.rpt";
                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + str_BL + "\"";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "FinalNotice", str_Script, true);
                
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 116, 3, Convert.ToInt32(Session["LoginBranchid"]), str_BL);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            fn_btnprint_Click();
         
        }

        protected void btn_forwarder_Click(object sender, EventArgs e)
        {
            fn_btnforwarder_Click();
           
        }

        protected void btn_cnsg_Click(object sender, EventArgs e)
        {
            fn_btncnsg_Click();
           
        }

        public void fn_btnforwarder_Click()
        {
            report("FIFWDRemainderNotice.rpt");
        }
        public void fn_btncnsg_Click()
        {
            report("FIRemainderNotice.rpt");
        }

        public void report(string Rptname)
        {
            string str_frmname = "";
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            string bookingno;
            DataAccess.ForwardingImports.ReminderNotice obj_da_reminder = new DataAccess.ForwardingImports.ReminderNotice();
            DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            DataAccess.Corporate obj_da_corp = new DataAccess.Corporate();
            DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
            DataTable obj_dtrnotice = new DataTable();
            string str_BL;
            str_BL = ddl_hblno.SelectedValue;

            if (str_BL == "")
            {
                obj_dtrnotice = obj_da_reminder.GetBLJobNo(Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtrnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtrnotice.Rows[0][3].ToString();
                }
            }
            else
            {
                obj_dtrnotice = obj_da_reminder.GetBLNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (obj_dtrnotice.Rows.Count > 0)
                {
                    str_BL = obj_dtrnotice.Rows[0][3].ToString();
                }
            }

            if (str_BL != "")
            {
                str_frmname = "RemainderNotice";
                str_RptName = Rptname;
                str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIBLDetails.blno}=\"" + str_BL + "\"";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_forwarder, typeof(Button), "Freight Certificate", str_Script, true);
                          
                bookingno = obj_da_BL.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                obj_da_corp.UpdShipmentStatus(bookingno, "FI", Convert.ToInt32(Session["LoginBranchid"]), "Remainder Notice");
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 115, 3, Convert.ToInt32(Session["LoginBranchid"]), str_BL);
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (grd_job.Visible == true)
            {
                string filename = "";
                filename = "Reminder Notice";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                grd_job.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                grd_job.GridLines = GridLines.Both;
                grd_job.HeaderStyle.Font.Bold = true;
                grd_job.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void GrdOceanExp1_PreRender(object sender, EventArgs e)
        {
            if (GrdOceanExp1.Rows.Count > 0)
            {
                GrdOceanExp1.UseAccessibleHeader = true;
                GrdOceanExp1.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void Grd_Status1_PreRender(object sender, EventArgs e)
        {
            if (Grd_Status1.Rows.Count > 0)
            {
                Grd_Status1.UseAccessibleHeader = true;
                Grd_Status1.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void GrdPort1_PreRender(object sender, EventArgs e)
        {
            if (GrdPort1.Rows.Count > 0)
            {
                GrdPort1.UseAccessibleHeader = true;
                GrdPort1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdPendingCargo_PreRender(object sender, EventArgs e)
        {
            if (GrdPendingCargo.Rows.Count > 0)
            {
                GrdPendingCargo.UseAccessibleHeader = true;
                GrdPendingCargo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_job_PreRender(object sender, EventArgs e)
        {
            if (grd_job.Rows.Count > 0)
            {
                grd_job.UseAccessibleHeader = true;
                grd_job.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}