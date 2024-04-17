using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


namespace logix.MainPage
{
    public partial class OceanImportsDocked : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        DataTable dt = new DataTable();
        DataTable dthbl = new DataTable();
        DataTable dtmbl = new DataTable();
        DataTable dttemp = new DataTable();
        long lngPQuot, lngInv, lngPA, lngDN, lngCN;
        int branchid, vouyear, logempid;
        string ModuleName;
        string hname;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), str_ModuleName, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                string str_menuhead = "";
                StringBuilder str_MenuDesign = new StringBuilder();
                StringBuilder str_MenuDesign1 = new StringBuilder();
                StringBuilder str_MenuDesign2 = new StringBuilder();
                StringBuilder str_MenuDesign3 = new StringBuilder();

                StringBuilder str_MenuDesign4 = new StringBuilder();
                StringBuilder str_MenuDesign5 = new StringBuilder();
                StringBuilder str_MenuDesign6 = new StringBuilder();
                StringBuilder str_MenuDesign7 = new StringBuilder();
                StringBuilder str_MenuDesign8 = new StringBuilder();

                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Sales")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Liner Rates (Buying)" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Quotation (Selling)" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Booking" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Performance Revenue" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OutStanding" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Sales DO Status" ||

                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Unclosed Job" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Work In Progress" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Request" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Exemption Request" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Approval" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Agent Rebate / Local Charges" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Buying Rate-Query" ||                                
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Master RDS"||                               
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Budget")
                            {
                                setup.Visible = true;
                                str_MenuDesign.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign.Append("</li>");

                                divsales.InnerHtml = str_MenuDesign.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "CRM")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Update Booking Status" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Update Booking Status" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Pre - Alert" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "C A N" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Covering Letter" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Freight Certificate" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Reminder Letter" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Final Notice" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Delivery Status" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customs EDI" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customs Report" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Queries" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Forwarders Customers" ||
                               // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "T/s Confimredon by Line" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "PA2Accs Send On" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Cheque Received On" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Line DO Received On" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Devanning Received On" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Refund Received On" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "EventTracking" ||

                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event Tracking-Operations" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Master Customer MailID" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Pending DO For Agent" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Forwarders HBL" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Events" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Cargo Pick Up")
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Inv Pa Details-CustomerWise")
                            {
                                links.Visible = true;
                                str_MenuDesign1.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign1.Append("</li>");

                                divcustomer.InnerHtml = str_MenuDesign1.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Shipment Details")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Job Info" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Direct BL" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Forwarder BL" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Split BL" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Line #" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "D.O. Issue" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "DeStuff" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amendment BLDetails" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Upload Document" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Download Document" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Transfer To ICD" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Transfer From PoL"||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Transfer To BT")
                            {
                                files.Visible = true;
                                str_MenuDesign2.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign2.Append("</li>");

                                DivShip.InnerHtml = str_MenuDesign2.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Accounts")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma Invoice" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Profoma Credit Note - Operations" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "DebitAdvise" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CreditAdvise" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Proforma OS DN/CN" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Credit Note - Operations" ||
                              //  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Credit Note" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OS DN/CN" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Franking DN/CN" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Cheque Request"||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Charge DC Advise")
                            {
                                Accounts.Visible = true;
                                str_MenuDesign3.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign3.Append("</li>");

                                DivAccounts.InnerHtml = str_MenuDesign3.ToString();
                            }
                        }


                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Approval")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Costing" ||
                               // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Costing Details" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN-Ops Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSDN Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSCN Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Credit Note - Operations" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSSI" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Credit Note"||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent Debit Note" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "OSPI" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Quotation Approval")
                                   
                             {
                                Approval.Visible = true;
                                str_MenuDesign4.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign4.Append("</li>");
                                DivApproval.InnerHtml = str_MenuDesign4.ToString();
                            }
                        }

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Trend Analysis")
                        //{
                        //    if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Sales Person" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Product" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer With Volume"||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Volumewise")
                        //    {
                        //        TrendAnalysis.Visible = true;
                        //        str_MenuDesign5.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                        //        str_MenuDesign5.Append("</li>");

                        //        DivTrend.InnerHtml = str_MenuDesign5.ToString();
                        //    }
                        //}

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "MIS")
                        {
                            MIS.Visible = true;
                            str_MenuDesign6.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                            str_MenuDesign6.Append("</li>");

                            DivMIS.InnerHtml = str_MenuDesign6.ToString();

                        }
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Utility")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend BL #" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Amend Forwarder BL#" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Daily Status Report" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Job Closing" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Change Job #" ||
                                  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ExRate Change" ||
                                   dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ChangePassword" ||

                                    dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CFS Job Details" ||
                                     dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "News" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "News Status" ||
                                     // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Questionnaire" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer Details" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Complaint Handling" ||
                                     // dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Agent XML" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Booking Register" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer"||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Statistics"||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer Profile")
                            {
                                Utility.Visible = true;
                                str_MenuDesign7.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign7.Append("</li>");

                                DivUtility.InnerHtml = str_MenuDesign7.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Operation MIS")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customerwise BL" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Event Tracking Operation" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Pending DO - Jobwise" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Teus Report" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Query" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Volume Report" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Lost / New Customer")
                            {
                                operationmis.Visible = true;
                                str_MenuDesign8.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["submenuname"].ToString() + " </a></li>");
                                str_MenuDesign8.Append("</li>");

                                Divoperationmis.InnerHtml = str_MenuDesign8.ToString();
                            }
                        }
                    }

                }
            }

            GrdDisable1();
            string Strtrantype = Session["StrTranType"].ToString();
              if (Strtrantype == "FI")
                {
                    lnk_exrate.Visible = true;
                    Gridexrate.Visible = false;
                    grdpendingcan.Visible = true;
                    lnk_Pendingcan.Enabled = true;
                    grdpendingline.Visible = true;
                    lnk_Pendingline.Enabled = true;
                    grdpendingstuff.Visible = true;
                    lnk_Pendingstuff.Enabled = true;

                  
                    //lnk_PendingTDS.Visible = false;
                    //lnk_PendingFA.Visible = false;
                    //lnk_PendingDep.Visible = false;
                    //lnk_IncomeNotBooked.Visible = false;
                    //lnk_Jobcost.Visible = false;
                    //lnk_Pendingcrdappr.Visible = false;
                    //lnk_userlogged.Visible = false;
                    //Panelexrate.Visible = false;

                   
                    //lnk_userlogged.Enabled = false;
                    //lnk_userlogged.ForeColor = System.Drawing.Color.Gray;
                    //GrdPendingTDS.Visible = false;
                    //lnk_PendingTDS.Enabled = false;
                    //lnk_PendingTDS.ForeColor = System.Drawing.Color.Gray;
                    //GrdPendingFA.Visible = false;
                    //lnk_PendingFA.Enabled = false;
                    //lnk_PendingFA.ForeColor = System.Drawing.Color.Gray;
                    //GrdPendingDep.Visible = false;
                    //lnk_PendingDep.Enabled = false;
                    //lnk_PendingDep.ForeColor = System.Drawing.Color.Gray;
                    //GrdPendingcrdapp.Visible = false;
                    //lnk_Pendingcrdappr.Enabled = false;
                    //lnk_Pendingcrdappr.ForeColor = System.Drawing.Color.Gray;
                    //lnk_IncomeNotBooked.Enabled = false;
                    //lnk_IncomeNotBooked.ForeColor = System.Drawing.Color.Gray;
                    //Paneljobcostingframe.Visible = false;
                    //Gridjobcost.Visible = false;
                    //lnk_Jobcost.Enabled = false;
                    //lnk_Jobcost.ForeColor = System.Drawing.Color.Gray;
                    //panel_tool.Visible = false;
                }
            else
            {
              
               //if (Strtrantype == "AC")
               // {
               //     GrdPendingTDS.Visible = true;
               //     lnk_PendingTDS.Enabled = true;
               //     GrdPendingFA.Visible = true;
               //     lnk_PendingFA.Enabled = true;
               //     GrdPendingDep.Visible = true;
               //     lnk_PendingDep.Enabled = true;
               //     GrdPendingcrdapp.Visible = true;
               //     lnk_Pendingcrdappr.Enabled = true;
               //     lnk_IncomeNotBooked.Enabled = true;



               //     lnk_Jobcost.Enabled = true;


               //     lnk_PendingHBL.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingmbl.Visible = false;
               //     lnk_PendingMBL.Enabled = false;
               //     lnk_PendingMBL.ForeColor = System.Drawing.Color.Gray;
               //     grduserlogged.Visible = false;
               //     lnk_userlogged.Enabled = false;
               //     lnk_userlogged.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingline.Visible = false;
               //     lnk_Pendingline.Enabled = false;
               //     lnk_Pendingline.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingstuff.Visible = false;
               //     lnk_Pendingstuff.Enabled = false;
               //     lnk_Pendingstuff.ForeColor = System.Drawing.Color.Gray;
               //     GrdOceanExp1.Visible = false;
               //     lnk_PendingEvent.Enabled = false;
               //     lnk_PendingEvent.ForeColor = System.Drawing.Color.Gray;

               //     panel_tool.Visible = false;
               //     lnk_Tools.Enabled = false;
               //     lnk_Tools.ForeColor = System.Drawing.Color.Gray;

               // }


               // else if (Strtrantype == "AI" || Strtrantype == "AE")
               // {
               //     grduserlogged.Visible = true;
               //     lnk_userlogged.Enabled = true;
               //     grdpendinghbl.Visible = false;
               //     lnk_PendingHBL.Enabled = false;
               //     lnk_PendingHBL.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingmbl.Visible = false;
               //     lnk_PendingMBL.Enabled = false;
               //     lnk_PendingMBL.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingcan.Visible = false;
               //     lnk_Pendingcan.Enabled = false;
               //     lnk_Pendingcan.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingline.Visible = false;
               //     lnk_Pendingline.Enabled = false;
               //     lnk_Pendingline.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingstuff.Visible = false;
               //     lnk_Pendingstuff.Enabled = false;
               //     lnk_Pendingstuff.ForeColor = System.Drawing.Color.Gray;
               //     GrdOceanExp1.Visible = false;
               //     lnk_PendingEvent.Enabled = false;
               //     lnk_PendingEvent.ForeColor = System.Drawing.Color.Gray;
               //     GrdPendingTDS.Visible = false;
               //     lnk_PendingTDS.Enabled = false;
               //     lnk_PendingTDS.ForeColor = System.Drawing.Color.Gray;
               //     GrdPendingFA.Visible = false;
               //     lnk_PendingFA.Enabled = false;
               //     lnk_PendingFA.ForeColor = System.Drawing.Color.Gray;
               //     GrdPendingDep.Visible = false;
               //     lnk_PendingDep.Enabled = false;
               //     lnk_PendingDep.ForeColor = System.Drawing.Color.Gray;
               //     GrdPendingcrdapp.Visible = false;
               //     lnk_Pendingcrdappr.Enabled = false;
               //     lnk_Pendingcrdappr.ForeColor = System.Drawing.Color.Gray;
               //     lnk_IncomeNotBooked.Enabled = false;
               //     lnk_IncomeNotBooked.ForeColor = System.Drawing.Color.Gray;
               //     Paneljobcostingframe.Visible = false;
               //     Gridjobcost.Visible = false;
               //     lnk_Jobcost.Enabled = false;
               //     lnk_Jobcost.ForeColor = System.Drawing.Color.Gray;
               //     panel_tool.Visible = false;
               //     panel_tool.Visible = false;
               // }

               // else
               // {
               //     grdpendinghbl.Visible = false;
               //     lnk_PendingHBL.Enabled = false;
               //     lnk_PendingHBL.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingmbl.Visible = false;
               //     lnk_PendingMBL.Enabled = false;
               //     lnk_PendingMBL.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingcan.Visible = false;
               //     lnk_Pendingcan.Enabled = false;
               //     lnk_Pendingcan.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingline.Visible = false;
               //     lnk_Pendingline.Enabled = false;
               //     lnk_Pendingline.ForeColor = System.Drawing.Color.Gray;
               //     grdpendingstuff.Visible = false;
               //     lnk_Pendingstuff.Enabled = false;
               //     lnk_Pendingstuff.ForeColor = System.Drawing.Color.Gray;
               //     grduserlogged.Visible = false;
               //     lnk_userlogged.Enabled = false;
               //     lnk_userlogged.ForeColor = System.Drawing.Color.Gray;
               //     GrdPendingTDS.Visible = false;
               //     lnk_PendingTDS.Enabled = false;
               //     lnk_PendingTDS.ForeColor = System.Drawing.Color.Gray;
               //     GrdPendingFA.Visible = false;
               //     lnk_PendingFA.Enabled = false;
               //     lnk_PendingFA.ForeColor = System.Drawing.Color.Gray;
               //     GrdPendingDep.Visible = false;
               //     lnk_PendingDep.Enabled = false;
               //     lnk_PendingDep.ForeColor = System.Drawing.Color.Gray;
               //     GrdPendingcrdapp.Visible = false;
               //     lnk_Pendingcrdappr.Enabled = false;
               //     lnk_Pendingcrdappr.ForeColor = System.Drawing.Color.Gray;
               //     lnk_IncomeNotBooked.Enabled = false;
               //     lnk_IncomeNotBooked.ForeColor = System.Drawing.Color.Gray;
               //     Paneljobcostingframe.Visible = false;
               //     Gridjobcost.Visible = false;
               //     lnk_Jobcost.Enabled = false;
               //     lnk_Jobcost.ForeColor = System.Drawing.Color.Gray;
               //     lnk_Tools.Enabled = false;
               //     lnk_Tools.ForeColor = System.Drawing.Color.Gray;
               //     panel_tool.Visible = false;
               // }

            }
            if (IsPostBack)
            {
                if (Session["Loggedname"] != null)
                {
                    hname = Session["Loggedname"].ToString();

                    if (hname == "userlog")
                    {
                        ifrmaster.Attributes["src"] = "../ForwardExports/Emptyform.aspx";
                        Session["Loggedname"] = null;
                    }
                }
            }
        }

        protected void lnk_PendingBooking_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            if (lnk_PendingBooking.Text == "Pending FA-Transfer")
            {
                PendingApproval1();
                GrdApproved11.Visible = true;
                PanelApproved11.Visible = true;
            }
            else
            {
                LoadPendingBooking1();
                grdpendingbook1.Visible = true;
                Panelbooking.Visible = true;
            }
        }

        protected void lnk_PendingApproval_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            PendingApprovalFE();
            GrdPending1.Visible = true;
            PanelApproval.Visible = true;
        }

        public void PendingApproval1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int intcount;
            vouyear = 2015;
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending Booking") });
            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[1] { new DataColumn("Approved") });
            PanelApproved11.Visible = true;
            GrdApproved11.Visible = true;

            if (Strtrantype != "BT")
            {
                if (Strtrantype != "CH")
                {
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
                    lngInv = dt.Rows.Count;

                    //grdpendapp.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    intcount = Appobj.GetPenFATrans("InvoiceApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved.Rows(0).Cells(0).Value = "Invoices" + "(" + intcount + ")"
                    dt2.Rows.Add("Invoices" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
                    lngPA = dt.Rows.Count;

                    //grdpendapp.Rows(1).Cells(0).Value = "Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    intcount = Appobj.GetPenFATrans("PAApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved.Rows(1).Cells(0).Value = "CN - Operations" + "(" + intcount + ")"
                    dt2.Rows.Add("CN - Operations" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "ProOSDNApproval");
                    lngDN = dt.Rows.Count;

                    //grdpendapp.Rows(2).Cells(0).Value = "Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    intcount = Appobj.GetPenFATrans("OSDNApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved.Rows(2).Cells(0).Value = "O/S Debit Notes" + "(" + intcount + ")"
                    dt2.Rows.Add("O/S Debit Notes" + "(" + intcount + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "ProOSCNApproval");
                    lngCN = dt.Rows.Count;

                    //grdpendapp.Rows(3).Cells(0).Value = "Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial DN");
                    lngCN = dt.Rows.Count;

                    //grdpendapp.Rows(4).Cells(0).Value = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial CN");
                    lngCN = dt.Rows.Count;

                    //grdpendapp.Rows(5).Cells(0).Value = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    intcount = Appobj.GetPenFATrans("OSCNApproval", Strtrantype, branchid, vouyear);

                    //GrdApproved.Rows(3).Cells(0).Value = "O/S Credit Notes" + "(" + intcount + ")"
                    dt2.Rows.Add("O/S Credit Notes" + "(" + intcount + ")");
                    intcount = Appobj.GetPenFATrans("Debit Note", Strtrantype, branchid, vouyear);

                    //GrdApproved.Rows(4).Cells(0).Value = "Other Debit Notes" + "(" + intcount + ")"
                    dt2.Rows.Add("Other Debit Notes" + "(" + intcount + ")");
                    intcount = Appobj.GetPenFATrans("Credit Note", Strtrantype, branchid, vouyear);

                    //GrdApproved.Rows(5).Cells(0).Value = "Other Credit Notes" + "(" + intcount + ")"
                    dt2.Rows.Add("Other Credit Notes" + "(" + intcount + ")");

                    GrdApproved11.DataSource = dt1;
                    GrdApproved11.DataBind();
                }
                else
                {
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
                    lngInv = dt.Rows.Count;

                    //grdpendapp.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
                    lngPA = dt.Rows.Count;

                    //grdpendapp.Rows(1).Cells(0).Value = "Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"                
                    dt1.Rows.Add("Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial DN");
                    lngCN = dt.Rows.Count;

                    //grdpendapp.Rows(2).Cells(0).Value = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial CN");
                    lngCN = dt.Rows.Count;

                    //grdpendapp.Rows(3).Cells(0).Value = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                    dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

                    GrdApproved11.DataSource = dt1;
                    GrdApproved11.DataBind();
                }
            }
            else
            {
                dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
                lngInv = dt.Rows.Count;

                //grdpendapp.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
                dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
                lngPA = dt.Rows.Count;

                //grdpendapp.Rows(1).Cells(0).Value = "Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
                dt1.Rows.Add("Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

                GrdApproved11.DataSource = dt1;
                GrdApproved11.DataBind();
            }
        }

        protected void lnk_PendingCountry_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            txtPort1.Visible = true;
            txtPort1.Text = "";
            //GrdPort1.Visible = true;
            //GrdPort1.DataSource = new DataTable();
            //GrdPort1.DataBind();
            //pnlPortCountry1.Visible = true;
        }

        protected void lnk_unclosedjobs_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            UnclosedJobs();
            grdunclosejobs.Visible = true;
            PanelUnclosedjob.Visible = true;
        }

        protected void lnk_PendingEvent_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            if (Session["StrTranType"] == "FE")
            {
                LoadOceanEvent1();
                GrdOceanExp1.Visible = true;
                PanelPendingEvent.Visible = true;
            }
            else
            {
                LoadOceanEventIMP();
                GrdOceanExp1.Visible = true;
                PanelPendingEvent.Visible = true;
            }
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

        public void LoadPendingBooking1()
        {
            dt = leftObj.GetBooking(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            if (dt.Rows.Count > 0)
            {
                grdpendingbook1.DataSource = dt;
                grdpendingbook1.DataBind();
            }
            else
            {
                grdpendingbook1.DataSource = new DataTable();
                grdpendingbook1.DataBind();
            }
        }

        public void GrdDisable1()
        {
            // Grid View //
          

            // Panels //
            Panelbooking.Visible = false;
            PanelApproval.Visible = false;
            pnlPortCountry1.Visible = false;
            PanelUnclosedjob.Visible = false;
            PanelApproved11.Visible = false;
            PanelPendingEvent.Visible = false;
           
            Panelcan.Visible = false;
            Panelline.Visible = false;
            Panelstuff.Visible = false;
         

            // Text Box//            
            txtPort1.Visible = false;
          
            if (IsPostBack)
            {
                if (Session["Loggedname"] != null)
                {
                    hname = Session["Loggedname"].ToString();

                    if (hname == "userlog")
                    {
                        ifrmaster.Attributes["src"] = "../ForwardExports/Emptyform.aspx";
                        Session["Loggedname"] = null;
                    }
                }
            }

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

        public void UnclosedJobs()
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
                    //grdunclosejobs.Rows(0).Cells(0).Value = "AE Jobs" + "(" + necount + ")";
                    dt1.Rows.Add("AE Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "AI")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    //grdunclosejobs.Rows(0).Cells(0).Value = "AI Jobs" + "(" + necount + ")"
                    dt1.Rows.Add("AI Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "FE")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    //grdunclosejobs.Rows(0).Cells(0).Value = "FE Jobs" + "(" + necount + ")"
                    dt1.Rows.Add("FE Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "FI")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    //grdunclosejobs.Rows(0).Cells(0).Value = "FI Jobs" + "(" + necount + ")"
                    dt1.Rows.Add("FI Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "CH")
                {
                    dt = Approveobj.GetPenUnClose(Strtrantype, branchid, 0, logempid);
                    necount = Convert.ToInt16(dt.Rows.Count);
                    //grdunclosejobs.Rows(0).Cells(0).Value = "CH Jobs" + "(" + necount + ")"
                    dt1.Rows.Add("CH Jobs" + "(" + necount + ")");
                    grdunclosejobs.DataSource = dt1;
                    grdunclosejobs.DataBind();
                }
                else if (Strtrantype == "FA")
                {
                    int necount1 = 0, nicount1 = 0, fecount1 = 0, ficount1 = 0, chcount1 = 0;
                    dt = Approveobj.GetPenUnClose("AC", branchid, 0, logempid);
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
            }
        }

        protected void txtPort1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Port") });
            if (txtPort1.Text != "")
            {
                dt = rightObj.GetCountryList(txtPort1.Text);
                if (dt.Rows.Count > 0)
                { }
                else
                {
                    dt = rightObj.GetPortList(txtPort1.Text);
                }
                if (dt.Rows.Count > 0)
                {
                    //GrdPort1.Rows(i).Cells(0).Value() = UCase(dt.Rows(i).Item(0).ToString())
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt1.Rows.Add(dt.Rows[i][0].ToString().ToUpper());
                    }
                    txtPort1.Visible = true;
                    GrdPort1.Visible = true;
                    pnlPortCountry1.Visible = true;
                    GrdPort1.DataSource = dt1;
                    GrdPort1.DataBind();
                }
            }
            else
            {
                GrdPort1.DataSource = new DataTable();
                GrdPort1.DataBind();
            }
        }

        protected void grdpendingbook1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string bookno;
            if (grdpendingbook1.Rows.Count > 0)
            {
                index = grdpendingbook1.SelectedRow.RowIndex;
                bookno = grdpendingbook1.Rows[index].Cells[0].Text;
                string Strtrantype = Session["StrTranType"].ToString();
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                str_RptName = "Booking.rpt";
                Session["str_sfs"] = "{COMBooking.shiprefno}='" + bookno + "'";
                str_sf = "{COMBooking.shiprefno}=" + bookno + "";
                str_sp = "buying=true";
                Session["str_sp"] = str_sp;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                ScriptManager.RegisterStartupScript(grdpendingbook1, typeof(Button), "JobInfo", str_Script, true);
            }
        }

        protected void grdpendingbook1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdpendingbook1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
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
                            str_sf = "{QuotationHead.trantype}=" + Strtrantype + " and {QuotationHead.validtill}>=CurrentDateTime and {QuotationHead.approvedby}=0 and {QuotationHead.bid}=" + branchid;
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
                            str_sf = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and {ACProInvoiceHead.trantype}=" + Strtrantype + " and {ACProInvoiceHead.deleted}=N";
                            str_sp = "Title=Profoma Invoice Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Invoice", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro CN Operations")
                        {
                            str_RptName = "Pro PA PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and {ACProPAHead.trantype}='" + Strtrantype + "' and {ACProPAHead.deleted}='N'";
                            str_sf = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and {ACProPAHead.trantype}=" + Strtrantype + " and {ACProPAHead.deleted}=N";
                            str_sp = "Title=Profoma Credit Note - Operations Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Payment Advise", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Debit Notes")
                        {
                            str_RptName = "Pro OSDN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and {AcOSDNPro.trantype}='" + Strtrantype + "' and {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}='N'";
                            str_sf = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and {AcOSDNPro.trantype}=" + Strtrantype + " and {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}=N";
                            str_sp = "Title=Profoma OSDN Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "OSSI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro O/S Credit Notes")
                        {
                            str_RptName = "Pro OSCN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.trantype}='" + Strtrantype + "' and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}='N'";
                            str_sf = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.trantype}=" + Strtrantype + " and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}=N";
                            str_sp = "Title=Profoma OSCN Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "OSPI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other DN")
                        {
                            str_RptName = "Pro OtherDN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0  and {ACProDNHead.trantype}='" + Strtrantype + "' and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}='N'";
                            str_sf = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0  and {ACProDNHead.trantype}=" + Strtrantype + " and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}=N";
                            str_sp = "Title=Profoma Debit Notes Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Debit Notes", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other CN")
                        {
                            str_RptName = "Pro OtherCN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and {ACPRoCNHead.trantype}='" + Strtrantype + "' and {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}='N'";
                            str_sf = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and {ACPRoCNHead.trantype}=" + Strtrantype + " and {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}=N";
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
                            str_sf = "{QuotationHead.approvedby}=0 and {QuotationHead.validtill}>=date(" + logobj.GetDate() + ")";
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
                            str_sf = "isnull({ACProInvoiceHead.invoiceno}) and {ACProInvoiceHead.approvedby}=0 and {ACProInvoiceHead.branchid}=" + branchid + " and  {ACProInvoiceHead.deleted}=N";
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
                            str_sf = "isnull({ACProPAHead.pano}) and {ACProPAHead.approvedby}=0 and {ACProPAHead.branchid}=" + branchid + " and  {ACProPAHead.deleted}=N";
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
                            str_sf = "isnull({AcOSDNPro.dnno}) and {AcOSDNPro.approvedby}=0  and  {AcOSDNPro.branchid}=" + branchid + " and {AcOSDNPro.deleted}=N";
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
                            str_sf = "isnull({ACOSCNPro.cnno}) and {ACOSCNPro.approvedby}=0  and {ACOSCNPro.branchid}=" + branchid + " and {ACOSCNPro.deleted}=N";
                            str_sp = "Title=Profoma OSCN Pending Approval";
                            Session["str_sp"] = str_sp;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                            ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "OSPI", str_Script, true);
                        }
                        else if (vouname.Substring(0, vouname.IndexOf(" (") - 1) == "Pro Other DN")
                        {
                            str_RptName = "Pro OtherDN PendRegister.rpt";
                            Session["str_sfs"] = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0   and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}='N'";
                            str_sf = "isnull({ACProDNHead.dnno}) and {ACProDNHead.approvedby}=0   and {ACProDNHead.branchid}=" + branchid + " and {ACProDNHead.deleted}=N";
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
                            str_sf = "isnull({ACPRoCNHead.cnno}) and {ACPRoCNHead.approvedby}=0  and  {ACPRoCNHead.branchid}=" + branchid + " and {ACPRoCNHead.deleted}=N";
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

                str_RptName = "FEEvents.rpt";

                if (name == "Stuffing Confirm")
                {
                    Session["str_sfs"] = "isnull({FEEvent.stuffsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.stuffsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Loading Confirm")
                {
                    Session["str_sfs"] = "isnull({FEEvent.lcsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.lcsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Invoice/PL RecOn")
                {
                    Session["str_sfs"] = "isnull({FEEvent.invplrecon}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.invplrecon}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "PreAlert SentOn")
                {
                    Session["str_sfs"] = "isnull({FEEvent.prealertsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.prealertsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Docs SentOn")
                {
                    Session["str_sfs"] = "isnull({FEEvent.docssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.docssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "TranShipment")
                {
                    Session["str_sfs"] = "isnull({FEEvent.tssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.tssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Delivery Request")
                {
                    Session["str_sfs"] = "isnull({FEEvent.drsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.drsenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Pending Event Details", str_Script, true);
                }
                else if (name == "Delivery Status")
                {
                    Session["str_sfs"] = "isnull({FEEvent.dssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sf = "isnull({FEEvent.dssenton}) and {FEEvent.bid}=" + branchid + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "Pending Event Details", str_Script, true);
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

        protected void grdunclosejobs_SelectedIndexChanged(object sender, EventArgs e)
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
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (grdunclosejobs.Rows.Count > 0)
            {
                index = grdunclosejobs.SelectedRow.RowIndex;
                name = grdunclosejobs.Rows[index].Cells[0].Text;
                if (Strtrantype == "FA")
                {
                    Session["str_sfs"] = "{tmpunclsjob.empid}=" + logempid + " and {tmpunclsjob.branchid}=" + branchid + " and {tmpunclsjob.trantype}= '" + name.Substring(0, 2) + "'";
                    str_sf = "{tmpunclsjob.empid}=" + logempid + " and {tmpunclsjob.branchid}=" + branchid + " and {tmpunclsjob.trantype}= " + name.Substring(0, 2) + "";
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                }
                else
                {
                    Session["str_sfs"] = "{tmpunclsjob.empid}=" + logempid + " and {tmpunclsjob.branchid}=" + branchid;
                    str_sf = "{tmpunclsjob.empid}=" + logempid + " and {tmpunclsjob.branchid}=" + branchid;
                    str_sp = "";
                    Session["str_sp"] = str_sp;
                }
                str_RptName = "UnClosedBranch.rpt";
                if (name.Substring(0, 2) == "AE")
                {
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "UnClosedJob", str_Script, true);
                }
                else if (name.Substring(0, 2) == "AI")
                {
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "UnClosedJob", str_Script, true);
                }
                else if (name.Substring(0, 2) == "FE")
                {
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "UnClosedJob", str_Script, true);
                }
                else if (name.Substring(0, 2) == "FI")
                {
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(GrdPending1, typeof(Button), "UnClosedJob", str_Script, true);
                }
            }
        }

        protected void grdunclosejobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdunclosejobs, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }



        protected void lnk_Pendingcan_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            pendingcan();
            grdpendingcan.Visible = true;
            Panelcan.Visible = true;
        }
        public void pendingcan()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendCAN(branchid);
            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                dttemp.Columns.Add("jobno", typeof(string));
                dttemp.Columns.Add("vessel&voyage", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp.NewRow();
                    dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["vessel&voyage"] = dt.Rows[i][1].ToString() + " " + "V." + dt.Rows[i][2].ToString();
                    dttemp.Rows.Add(dtrow);
                }

                grdpendingcan.DataSource = dttemp;
                grdpendingcan.DataBind();
            }

            else
            {
                grdpendingcan.DataSource = new DataTable();
                grdpendingcan.DataBind();
            }
        }

        protected void grdpendingcan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdpendingcan, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdpendingcan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int index;
                string canjobno;
                if (grdpendingcan.Rows.Count > 0)
                {
                    index = grdpendingcan.SelectedRow.RowIndex;
                    canjobno = grdpendingcan.Rows[index].Cells[0].Text;
                    string Strtrantype = Session["StrTranType"].ToString();
                    string str_sp = "";
                    string str_sf = "";
                    string str_RptName = "";
                    string str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    str_RptName = "FIExportsDetails.rpt";

                    // Session["str_sfs"] = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + canjobno + "'";
                    //  str_sf = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + canjobno + "'";

                    Session["str_sfs"] = "{FIJobInfo.jobno}='" + canjobno + "'";
                    str_sf = "{FIJobInfo.jobno}=" + canjobno + "";

                    str_sp = "buying=true";
                    Session["str_sp"] = str_sp;


                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(grdpendingcan, typeof(Button), "JobInfo", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        protected void lnk_Pendingline_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            pendingline();
            grdpendingline.Visible = true;
            Panelline.Visible = true;
        }
        public void pendingline()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendLineno(branchid);

            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                dttemp.Columns.Add("jobno", typeof(string));
                dttemp.Columns.Add("vessel&voyage", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp.NewRow();
                    dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["vessel&voyage"] = dt.Rows[i][1].ToString() + " " + "V." + dt.Rows[i][2].ToString();
                    dttemp.Rows.Add(dtrow);
                }

                grdpendingline.DataSource = dttemp;
                grdpendingline.DataBind();
            }

            else
            {
                grdpendingline.DataSource = new DataTable();
                grdpendingline.DataBind();
            }
        }
        protected void grdpendingline_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdpendingline, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdpendingline_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int index;
                string linejobno;
                if (grdpendingline.Rows.Count > 0)
                {
                    index = grdpendingline.SelectedRow.RowIndex;
                    linejobno = grdpendingline.Rows[index].Cells[0].Text;
                    string Strtrantype = Session["StrTranType"].ToString();
                    string str_sp = "";
                    string str_sf = "";
                    string str_RptName = "";
                    string str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    str_RptName = "FIExportsDetails.rpt";

                    // Session["str_sfs"] = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + canjobno + "'";
                    //  str_sf = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + canjobno + "'";

                    Session["str_sfs"] = "{FIJobInfo.jobno}='" + linejobno + "'";
                    str_sf = "{FIJobInfo.jobno}=" + linejobno + "";

                    str_sp = "buying=true";
                    Session["str_sp"] = str_sp;


                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(grdpendingline, typeof(Button), "JobInfo", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void lnk_Pendingstuff_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            LoadPendingStuff();
            grdpendingstuff.Visible = true;
            Panelstuff.Visible = true;
        }
        public void LoadPendingStuff()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendStuff(branchid);

            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                dttemp.Columns.Add("jobno", typeof(string));
                dttemp.Columns.Add("vessel&voyage", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp.NewRow();
                    dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["vessel&voyage"] = dt.Rows[i][1].ToString() + " " + "V." + dt.Rows[i][2].ToString();
                    dttemp.Rows.Add(dtrow);
                }

                grdpendingstuff.DataSource = dttemp;
                grdpendingstuff.DataBind();
            }

            else
            {
                grdpendingstuff.DataSource = new DataTable();
                grdpendingstuff.DataBind();
            }
        }
        protected void grdpendingstuff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdpendingstuff, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdpendingstuff_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int index;
                string stuffjobno;
                if (grdpendingstuff.Rows.Count > 0)
                {
                    index = grdpendingstuff.SelectedRow.RowIndex;
                    stuffjobno = grdpendingstuff.Rows[index].Cells[0].Text;
                    string Strtrantype = Session["StrTranType"].ToString();
                    string str_sp = "";
                    string str_sf = "";
                    string str_RptName = "";
                    string str_Script = "";
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    str_RptName = "FIExportsDetails.rpt";

                    // Session["str_sfs"] = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + canjobno + "'";
                    //  str_sf = "{FIJobInfo.bid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {FIJobInfo.jobno}=" + canjobno + "'";

                    Session["str_sfs"] = "{FIJobInfo.jobno}='" + stuffjobno + "'";
                    str_sf = "{FIJobInfo.jobno}=" + stuffjobno + "";

                    str_sp = "buying=true";
                    Session["str_sp"] = str_sp;


                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
                    ScriptManager.RegisterStartupScript(grdpendingline, typeof(Button), "JobInfo", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



    
        protected void lnk_Tools_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            panel_tool.Visible = true;
        }

        protected void lnk_curr_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../ForwardExports/CountryCurrency.aspx";
        }

        protected void lnl_inco_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../ForwardExports/IncoTerm.aspx";
        }

        protected void lnk_length_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../ForwardExports/LengthConversion.aspx";
        }

        protected void lnk_weight_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../ForwardExports/WeightConversion.aspx";
        }

        protected void lnk_volume_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../ForwardExports/VolumeConversion.aspx";
        }


        protected void lnk_exrate_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            loadgrd();
            Panelexrate.Visible = true;
            Gridexrate.Visible = true;

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

    }
}