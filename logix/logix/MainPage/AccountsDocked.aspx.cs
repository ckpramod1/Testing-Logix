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
    public partial class AccountsDocked : System.Web.UI.Page
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
                Session["trantype_process"] = null;
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
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Voucher" || dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Vouchers")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note - Operations" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "DebitAdvise" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "CreditAdvise" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSSI" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OSPI" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Debit Note" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma Credit Note" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Debit Note" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Credit Note" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Payments" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma CN-Admin" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Proforma DN-Admin" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Purchase Invoice" ||

                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Admin Sales Invoice" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Receipts" ||
                                 dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque Request" ||
                                  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Cheque Bounce" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "OnAccount To Against Voucher" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Invoice/CNOps - CN/DN Adjustment" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Service Tax Amount Amendment" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "DN/CN Reversal"||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Bill of Supply" 
                              //  dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Journal"
                                )
                            {
                                voucher.Visible = true;
                                str_MenuDesign.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign.Append("</li>");

                                divvoucher.InnerHtml = str_MenuDesign.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Approval")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Cheque Request Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Debit Note Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Credit Note Proforma to Commercial" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "DN Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN Proforma to Commercial-Admin" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "DN Proforma to Commercial-Admin" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Debit Note Approval - Admin" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Credit Note Approval - Admin")
                            {
                                Approval.Visible = true;
                                str_MenuDesign1.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'   target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign1.Append("</li>");
                                divApproval.InnerHtml = str_MenuDesign1.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Register")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Voucher Register" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Pending Approval" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Pending Transfer" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Voucher Summary" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "GSTXL" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Credit Approval Status")
                            {
                                Register.Visible = true;
                                if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Voucher Register")
                                {
                                    str_MenuDesign2.Append("<li class='liststylenone' style='border-bottom:0px solid #f00;'><a class='drawer-dropdown-menu-item' href='../FAForms/VoucherRegister.aspx?FormName=Registers&uiid=1783' target='MainFrame' onclick ='ifrmaster'>Registers</a>");
                                }
                                else
                                {
                                    str_MenuDesign2.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'   target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                    str_MenuDesign2.Append("</li>");
                                }
                                divRegister.InnerHtml = str_MenuDesign2.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Outstanding New")
                        {
                            Outstanding.Visible = true;
                            str_MenuDesign3.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'   target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign3.Append("</li>");

                            divOutstanding.InnerHtml = str_MenuDesign3.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "MIS")
                        {
                                MIS.Visible = true;
                                str_MenuDesign4.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'   target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign4.Append("</li>");

                                divMIS.InnerHtml = str_MenuDesign4.ToString();
                        }


                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "X M L")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Corporate XML" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "TallyXML" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN-Ops TDS" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Other CN TDS" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "CN - Admin TDS")
                            {
                                XML.Visible = true;
                                str_MenuDesign5.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign5.Append("</li>");
                                divXML.InnerHtml = str_MenuDesign5.ToString();
                            }
                        }

                        //if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Trend Analysis")
                        //{
                        //    if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Sales Person" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer with Product" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Product" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer With Volume" ||
                        //        dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customerwise")
                        //    {
                        //        trend.Visible = true;
                        //        str_MenuDesign6.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                        //        str_MenuDesign6.Append("</li>");

                        //        divtrend.InnerHtml = str_MenuDesign6.ToString();
                        //    }
                        //}

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Utility")
                        {
                            if (//dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "ChangePassword" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Change LedgerName" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer TDS" ||
                                 dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Cheque Clearance" ||
                                  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Cheque Query" ||
                                   dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Charges Classification" ||

                                    dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Cost Sheet" ||
                                    dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Charge Details - Ledgerwise" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Air Exports" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "HAWBL #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipper / Consignee" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Flight #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "MAWBL #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Register" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Inv/CNOps CustomerWise" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Air Imports" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "HAWBL #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipper / Consignee" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Flight #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "MAWBL #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Register" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Inv/CNOps CustomerWise" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Ocean Exports" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Number" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Register" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipper / consignee" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "MBL #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Container #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Queries" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Inv/CNOps CustomerWise" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Ocean Imports" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "BL Number" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Shipper / consignee" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "MBL #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Container #" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Queries" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Inv/CNOps CustomerWise" ||

                                     dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "News" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "News Status" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Questionnaire" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer Retention" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Statistics" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Retention Per Unit" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "User Rights" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer Payment Pattern" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Credit Request Details" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Original Bills - Vendors" ||
                                      dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "MIS Reconciliation" ||

                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Exemption List" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Billing Report" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Accountant Mailid" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Since Audit" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Import Audit"||
                                  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer Profile"
                                //|| dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Approval - Ticket" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Ticket Recommendation" ||
                                //dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Ticket Requirement"
                                )
                            {
                                Utility.Visible = true;
                                str_MenuDesign7.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'   target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign7.Append("</li>");

                                divUtility.InnerHtml = str_MenuDesign7.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Budget Vs Actual")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Budget Data" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Budget Vs Actual" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Performance Analysis - N vs F" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Performance Comparision" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Revenue Projections" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Volume projections"||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Budget - Volume")
                            {
                                //budget.Visible = true;
                                str_MenuDesign8.Append("<li class='liststylenone'><a class='waves-effect' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'   target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign8.Append("</li>");

                                divbudget.InnerHtml = str_MenuDesign8.ToString();
                            }
                        }

                    }
                }
            }

            GrdDisable1();
            string Strtrantype = Session["StrTranType"].ToString();
            if (Strtrantype == "AC")
                {
                    lnk_exrate.Visible = true;
                    Panelexrate.Visible = true;
                    Gridexrate.Visible = true;
                    loadgrd();

                    GrdPendingTDS.Visible = true;
                    lnk_PendingTDS.Enabled = true;
                    GrdPendingFA.Visible = true;
                    lnk_PendingFA.Enabled = true;
                    GrdPendingDep.Visible = true;
                    lnk_PendingDep.Enabled = true;
                    GrdPendingcrdapp.Visible = true;
                    lnk_Pendingcrdappr.Enabled = true;
                    lnk_IncomeNotBooked.Enabled = true;
                    Paneljobcostingframe.Visible = false;


                    lnk_Jobcost.Enabled = true;

                 //   lnk_PendingBooking.Visible = false;
                   
                   
                    lnk_userlogged.Visible = false;

                  
                    grduserlogged.Visible = false;
                    lnk_userlogged.Enabled = false;
                    lnk_userlogged.ForeColor = System.Drawing.Color.Gray;
                  

                    

                }
            else
            {
               
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

        //protected void lnk_PendingBooking_Click(object sender, EventArgs e)
        //{
        //    GrdDisable1();
        //    if (lnk_PendingBooking.Text == "Pending FA-Transfer")
        //    {
        //        PendingApproval1();
        //        GrdApproved11.Visible = true;
        //        PanelApproved11.Visible = true;
        //    }
        //    else
        //    {
        //        LoadPendingBooking1();
        //        grdpendingbook1.Visible = true;
        //        Panelbooking.Visible = true;
        //    }
        //}

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

        //public void LoadPendingBooking1()
        //{
        //    dt = leftObj.GetBooking(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
        //    if (dt.Rows.Count > 0)
        //    {
        //        grdpendingbook1.DataSource = dt;
        //        grdpendingbook1.DataBind();
        //    }
        //    else
        //    {
        //        grdpendingbook1.DataSource = new DataTable();
        //        grdpendingbook1.DataBind();
        //    }
        //}

        public void GrdDisable1()
        {
            // Grid View //
          
            // Panels //
          //  Panelbooking.Visible = false;

            PanelApproval.Visible = false;
            pnlPortCountry1.Visible = false;
            PanelUnclosedjob.Visible = false;
            PanelApproved11.Visible = false;
          
            Paneluserlogged.Visible = false;
            PanelTDS.Visible = false;
            PanelFA.Visible = false;
            PanelDep.Visible = false;
            Panelcrdappr.Visible = false;

            Paneljobcost.Visible = false;
            Paneljobcostingframe.Visible = false;
            Panelexrate.Visible = false;
            // Text Box//            
            txtPort1.Visible = false;
            txt_job.Visible = false;
            ddl_product.Visible = false;
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
            Strtrantype = "FA";
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

        //protected void grdpendingbook1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int index;
        //    string bookno;
        //    if (grdpendingbook1.Rows.Count > 0)
        //    {
        //        index = grdpendingbook1.SelectedRow.RowIndex;
        //        bookno = grdpendingbook1.Rows[index].Cells[0].Text;
        //        string Strtrantype = Session["StrTranType"].ToString();
        //        string str_sp = "";
        //        string str_sf = "";
        //        string str_RptName = "";
        //        string str_Script = "";
        //        Session["str_sfs"] = "";
        //        Session["str_sp"] = "";
        //        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        //        str_RptName = "Booking.rpt";
        //        Session["str_sfs"] = "{COMBooking.shiprefno}='" + bookno + "'";
        //        str_sf = "{COMBooking.shiprefno}=" + bookno + "";
        //        str_sp = "buying=true";
        //        Session["str_sp"] = str_sp;
        //        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
        //        //obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 10, 3, int.Parse(Session["LoginBranchid"].ToString()), Strtrantype + " BookView");
        //        ScriptManager.RegisterStartupScript(grdpendingbook1, typeof(Button), "JobInfo", str_Script, true);
        //    }
        //}

        //protected void grdpendingbook1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
        //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

        //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdpendingbook1, "Select$" + e.Row.RowIndex);
        //        e.Row.Attributes["style"] = "cursor:pointer";
        //    }
        //}

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




        protected void lnk_userlogged_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            LoadLiveUser();
            grduserlogged.Visible = true;
            Paneluserlogged.Visible = true;
        }
        protected void grduserlogged_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].CssClass = "hide";
                //e.Row.Cells[0].

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grduserlogged, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        public void LoadLiveUser()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = hrempobj.GetLiveUser();

            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                dttemp.Columns.Add("Userid", typeof(string));
                dttemp.Columns.Add("LOGGED", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp.NewRow();
                    dtrow["Userid"] = dt.Rows[i][0].ToString();
                    dtrow["LOGGED"] = dt.Rows[i][1].ToString().Substring(0, 3) + " " + "_" + dt.Rows[i][2].ToString();
                    dttemp.Rows.Add(dtrow);
                }

                grduserlogged.DataSource = dttemp;
                grduserlogged.DataBind();
                if (grduserlogged.Rows.Count > 0)
                {
                    for (int i = 0; i < dttemp.Rows.Count; i++)
                    {
                        //    if (dttemp.Rows[i][0].ToString() == grduserlogged.Rows[i].Cells[0].Text)
                        //    {
                        //grduserlogged.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
                        grduserlogged.HeaderRow.Cells[0].CssClass = "hide";

                        grduserlogged.Rows[i].Cells[0].CssClass = "hide";
                    }
                    //}
                }
            }

            else
            {
                grduserlogged.DataSource = new DataTable();
                grduserlogged.DataBind();
            }
        }

        protected void grduserlogged_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int index;
                string loggedno;
                if (grduserlogged.Rows.Count > 0)
                {
                    index = grduserlogged.SelectedRow.RowIndex;
                    //  loggedno = grduserlogged.Rows[index].Cells[0].Text;
                    int log = hrempobj.GetEmpId(grduserlogged.Rows[index].Cells[0].Text);

                    Session["Loggedid"] = log;
                    Session["Loggedname"] = "userlog";
                    Session["Budget"] = "userlog";
                    ifrmaster.Attributes["src"] = "../ForwardExports/Mail.aspx";

                    //Response.Redirect("../FormMain.aspx");
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_PendingTDS_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            LoadPendingTDS();
            GrdPendingTDS.Visible = true;
            PanelTDS.Visible = true;
        }
        public void LoadPendingTDS()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetTDS4dash(branchid);

            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                // dttemp.Columns.Add("jobno", typeof(string));
                dttemp.Columns.Add("TDS", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp.NewRow();
                    // dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["TDS"] = dt.Rows[i][1].ToString() + " " + "(" + dt.Rows[i][0].ToString() + ")";
                    dttemp.Rows.Add(dtrow);
                }

                GrdPendingTDS.DataSource = dttemp;
                GrdPendingTDS.DataBind();
            }

            else
            {
                GrdPendingTDS.DataSource = new DataTable();
                GrdPendingTDS.DataBind();
            }
        }

        //protected void GrdPendingTDS_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
        //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

        //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPendingTDS, "Select$" + e.Row.RowIndex);
        //        e.Row.Attributes["style"] = "cursor:pointer";
        //    }
        //}

        protected void lnk_PendingFA_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            LoadPendingFA();
            GrdPendingFA.Visible = true;
            PanelFA.Visible = true;
        }
        public void LoadPendingFA()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetCount4Fa(branchid);

            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                //   dttemp.Columns.Add("FA", typeof(string));
                dttemp.Columns.Add("FA Transfer", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp.NewRow();
                    // dtrow["FA"] = dt.Rows[i][1].ToString();
                    dtrow["FA Transfer"] = dt.Rows[i][1].ToString() + "" + "  (" + dt.Rows[i][0].ToString() + ")";
                    dttemp.Rows.Add(dtrow);
                }

                GrdPendingFA.DataSource = dttemp;
                GrdPendingFA.DataBind();
            }

            else
            {
                GrdPendingFA.DataSource = new DataTable();
                GrdPendingFA.DataBind();
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
                            str_sf = "{PAHead.branchid}=" + branchid + " and isNull({PAHead.fatransfer}) and {PAHead.approvedby} <> 0 and {PAHead.deleted} = 'N'";
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
                            str_sf = "{Osdn.branchid}=" + branchid + " and isNull({Osdn.fatransfer}) and {Osdn.approvedby} <> 0 and {Osdn.deleted} = 'N'";
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
                            str_sf = "{oscn.branchid}=" + branchid + " and isNull({oscn.fatransfer}) and {Oscn.approvedby} <> 0 and {Oscn.deleted} = 'N'";
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
                            str_sf = "{Dnhead.branchid}=" + branchid + " and isNull({Dnhead.fatransfer}) and {DnHead.approvedby} <> 0 and {DnHead.deleted} = 'N'";
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
                            str_sf = "{CNhead.branchid}=" + branchid + " and isNull({CNhead.fatransfer}) and {CNHead.approvedby} <> 0 and {CNHead.deleted} = 'N'";
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
                            str_sf = "{AdmDNHead.branchid}=" + branchid + " and isNull({AdmDNHead.fatransfer}) and {AdmDNHead.approvedby} <> 0 and {AdmDNHead.deleted} = 'N'";
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
                            str_sf = "{AdmCNHead.branchid}=" + branchid + " and isNull({AdmCNHead.fatransfer}) and {AdmCNHead.approvedby} <> 0 and {AdmCNHead.deleted} = 'N'";
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
                            str_sf = "{receipthead.mode}= 'C'  and {receipthead.branchid}=" + branchid + " and isNull({receipthead.fatransfer}) and {ReceiptHead.approvedby} <> 0 and {ReceiptHead.deleted} = 0";
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
                            str_sf = "{receipthead.mode}= 'B'  and {receipthead.branchid}=" + branchid + " and isNull({receipthead.fatransfer}) and {ReceiptHead.approvedby} <> 0 and {ReceiptHead.deleted} = 0";
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
                            str_sf = "{Paymenthead.mode}= 'C'  and {Paymenthead.branchid}=" + branchid + " and isNull({Paymenthead.fatransfer}) and {PaymentHead.approvedby} <> 0 and {PaymentHead.deleted} = 0";
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
                            str_sf = "{Paymenthead.mode}= 'B'  and {Paymenthead.branchid}=" + branchid + " and isNull({Paymenthead.fatransfer}) and {PaymentHead.approvedby} <> 0 and {PaymentHead.deleted} = 0";
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
            GrdDisable1();
            LoadPendingDep();
            GrdPendingDep.Visible = true;
            PanelDep.Visible = true;
        }
        public void LoadPendingDep()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetDeposit4dash(branchid);

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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPendingDep, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void lnk_Pendingcrdappr_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            LoadPendingcrdappr();
            GrdPendingcrdapp.Visible = true;
            Panelcrdappr.Visible = true;
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
                dttemp.Columns.Add("Credit Approval Status", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttemp.NewRow();
                    // dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["Credit Approval Status"] = dt.Rows[i][1].ToString() + " " + " (" + dt.Rows[i][0].ToString() + ")";
                    dttemp.Rows.Add(dtrow);
                }

                GrdPendingcrdapp.DataSource = dttemp;
                GrdPendingcrdapp.DataBind();
            }

            else
            {
                GrdPendingcrdapp.DataSource = new DataTable();
                GrdPendingcrdapp.DataBind();
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

        protected void lnk_IncomeNotBooked_Click(object sender, EventArgs e)
        {


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



        protected void lnk_Jobcost_Click(object sender, EventArgs e)
        {
            GrdDisable1();

            Paneljobcostingframe.Visible = true;
            Gridjobcost.Visible = true;
            Paneljobcost.Visible = true;
            lbl1.Enabled = true;
            txt_job.Visible = true;
            ddl_product.Visible = true;


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
                        case "Forwarding Exports":
                            {
                                trantype = "FE";
                                break;
                            }
                        case "Forwarding Imports":
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
                        dttemp.Columns.Add("Vou#");
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
                            dtrow["Vou#"] = vou + " " + " -" + invo;

                        }
                        else
                        {
                            if (dt.Rows[i][2].ToString() == "Income Total")
                            {
                                dtrow["Vou#"] = "Income";
                            }
                            else if (dt.Rows[i][2].ToString() == "Expenses Total")
                            {
                                dtrow["Vou#"] = "Expense";
                            }
                            else
                            {
                                dtrow["Vou#"] = dt.Rows[i][2].ToString();
                            }

                        }
                        amount = Convert.ToDouble(dt.Rows[i][3].ToString());
                        dtrow["Amount"] = Convert.ToString(amount);
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