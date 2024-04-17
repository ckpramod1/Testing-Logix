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
    public partial class BondedTruckingDocked : System.Web.UI.Page
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
            string Strtrantype = Session["StrTranType"].ToString();

            if (!IsPostBack)
            {              
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), str_ModuleName, Convert.ToInt16(Session["LoginBranchid"].ToString()));
                Session["dt_UserRights"] = dt_MenuRights;
                string str_menuhead = "";
                Session["trantype_process"] = null;
                StringBuilder str_MenuDesign = new StringBuilder();
                StringBuilder str_MenuDesign1 = new StringBuilder();
                StringBuilder str_MenuDesign2 = new StringBuilder();
                StringBuilder str_MenuDesign3 = new StringBuilder();

                StringBuilder str_MenuDesign4 = new StringBuilder();
                StringBuilder str_MenuDesign5 = new StringBuilder();
                StringBuilder str_MenuDesign6 = new StringBuilder();
                StringBuilder str_MenuDesign7 = new StringBuilder();

                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Job Details")
                        {
                            files.Visible = true;
                            str_MenuDesign.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                            str_MenuDesign.Append("</li>");

                            DivJob.InnerHtml = str_MenuDesign.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Accounts" || dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "&Vouchers")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Profoma Invoice" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Profoma Credit Note - Operations" ||
                                     dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Profoma Credit Note - Operations GST Amendment" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Invoice" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Credit Note - Operations" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Bill of Supply"
                              
                                )
                            Accounts.Visible = true;
                            str_MenuDesign1.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign1.Append("</li>");

                            DivAccounts.InnerHtml = str_MenuDesign1.ToString();
                        }


                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Approval")
                        {
                            Approval.Visible = true;
                            str_MenuDesign2.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                            str_MenuDesign2.Append("</li>");

                            DivApproval.InnerHtml = str_MenuDesign2.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "M I S")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "M I S")
                            {
                                 MIS.Visible = true;
                                 str_MenuDesign3.Append("<li class='drawer-dropdown-menu-item'><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                                str_MenuDesign3.Append("</li>");

                                divMIS.InnerHtml = str_MenuDesign3.ToString();
                            }
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Utility")
                        {
                            if (dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Change Password" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Job Closing" ||
                                dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "User Rights"||
                                  dt_MenuRights.Rows[i]["submenuname"].ToString().Trim() == "Customer Profile"
                               )
                            Utility.Visible = true;
                            str_MenuDesign4.Append("<li  class='liststylenone'><a class='drawer-dropdown-menu-item' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + " </a></li>");
                            str_MenuDesign4.Append("</li>");

                            divUtility.InnerHtml = str_MenuDesign4.ToString();
                        }


                    }
                }

            }

            GrdDisable1();
           
            if(Strtrantype=="BT")
            {
                lnk_exrate.Visible = true;
                Panelexrate.Visible = true;
                Gridexrate.Visible = true;
                loadgrd();
               
                lnk_userlogged.Enabled = true;
                lnk_Tools.Enabled = true;
                  grduserlogged.Visible = false;
                // lnk_userlogged.Enabled = false;
                // lnk_userlogged.ForeColor = System.Drawing.Color.Gray;
              
                // lnk_Tools.Enabled = false;
                //   lnk_Tools.ForeColor = System.Drawing.Color.Gray;
                    panel_tool.Visible = false;
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
                //LoadOceanEvent1();
            }
            else
            {
                //LoadOceanEventIMP();
            }
        }


       
        public void GrdDisable1()
        {
            // Grid View //
           
           

            // Panels //
            
            PanelApproval.Visible = false;
            pnlPortCountry1.Visible = false;
            PanelUnclosedjob.Visible = false;
            PanelApproved11.Visible = false;
          
            Paneluserlogged.Visible = false;
          

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