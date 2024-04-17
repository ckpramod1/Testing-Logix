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
    public partial class CorpDocked : System.Web.UI.Page
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
        string trantype = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable dt_MenuRights = new DataTable();
                string str_ModuleName = Session["StrTranType"].ToString();
                trantype = Session["RightsTranType"].ToString();
                DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                dt_MenuRights = obj_UP.GetMenus(Convert.ToInt16(Session["LoginEmpId"].ToString()), trantype, Convert.ToInt16(Session["LoginBranchid"].ToString()));
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
                StringBuilder str_MenuDesign9 = new StringBuilder();
                if (dt_MenuRights.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_MenuRights.Rows.Count; i++)
                    {
                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Voucher")
                        {
                            voucher.Visible = true;
                            str_MenuDesign.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign.Append("</li>");

                            divvoucher.InnerHtml = str_MenuDesign.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Register")
                        {
                            Register.Visible = true;
                            str_MenuDesign1.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign1.Append("</li>");

                            divRegister.InnerHtml = str_MenuDesign1.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Approval")
                        {
                            Approval.Visible = true;
                            str_MenuDesign2.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign2.Append("</li>");

                            divApproval.InnerHtml = str_MenuDesign2.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Credit")
                        {
                            Outstanding.Visible = true;
                            str_MenuDesign3.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign3.Append("</li>");

                            divOutstanding.InnerHtml = str_MenuDesign3.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "X M L")
                        {
                            XML.Visible = true;
                            str_MenuDesign4.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign4.Append("</li>");

                            divXML.InnerHtml = str_MenuDesign4.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Budget")
                        {
                            trend.Visible = true;
                            str_MenuDesign5.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign5.Append("</li>");

                            divtrend .InnerHtml = str_MenuDesign5.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Analysis")
                        {
                            Analysis.Visible = true;
                            str_MenuDesign6.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign6.Append("</li>");

                            divAnalysis.InnerHtml = str_MenuDesign6.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "M I S")
                        {
                            MIS.Visible = true;
                            str_MenuDesign7.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign7.Append("</li>");

                            divMIS.InnerHtml = str_MenuDesign7.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Query")
                        {
                            operationmis.Visible = true;
                            str_MenuDesign8.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                            str_MenuDesign8.Append("</li>");

                            divoperationmis.InnerHtml = str_MenuDesign8.ToString();
                        }

                        if (dt_MenuRights.Rows[i]["menuname"].ToString().Trim() == "Utility")
                        {
                            if (dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Customer TDS" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Change LedgerName" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Download Document" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Statistics" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "News" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "News Status" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Query" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Complaint Registration" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Outstanding Sales PersonWise" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "MIS Reconciliation" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "UnClosedJobs" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "Since Audit" ||
                                dt_MenuRights.Rows[i]["uicaption"].ToString().Trim() == "User Rights")
                            {
                                Utility.Visible = true;
                                str_MenuDesign9.Append("<li><a class='Text' href='" + dt_MenuRights.Rows[i]["touchaspx"].ToString() + "?type=" + dt_MenuRights.Rows[i]["submenuname"].ToString() + "&uiid=" + dt_MenuRights.Rows[i]["uiid"].ToString() + "'  target='MainFrame' onclick ='ifrmaster'>" + dt_MenuRights.Rows[i]["uicaption"].ToString() + "</a></li>");
                                str_MenuDesign9.Append("</li>");

                                divUtility.InnerHtml = str_MenuDesign9.ToString();
                            }
                        }

                    }
                }

            }

            GrdDisable1();
            string Strtrantype = Session["StrTranType"].ToString();
            if (Strtrantype == "CO")
            {
                //lnk_exrate.Visible = true;
                //Panelexrate.Visible = true;
                //Gridexrate.Visible = true;
                //loadgrd();

                //lnk_IncomeNotBooked.Enabled = true;
                //grduserlogged.Visible = true;
                //lnk_userlogged.Enabled = true;
                //lnk_customerprofile.Enabled = true;
                //lnk_PendingApprovalCorp.Enabled = true;

               
                //Panelexrate.Visible = false;          
                //grduserlogged.Visible = false;            

              

                
                //PanelPendingApprovalCorp.Visible = false;
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
       
        
        public void PendingApproval1()
        {
            //string Strtrantype = Session["StrTranType"].ToString();
            //int intcount;
            //vouyear = 2015;
            //branchid = int.Parse(Session["LoginBranchid"].ToString());
            //DataTable dt1 = new DataTable();
            //dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Pending Booking") });
            //DataTable dt2 = new DataTable();
            //dt2.Columns.AddRange(new DataColumn[1] { new DataColumn("Approved") });
            //PanelApproved11.Visible = true;
            //GrdApproved11.Visible = true;

            //if (Strtrantype != "BT")
            //{
            //    if (Strtrantype != "CH")
            //    {
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
            //        lngInv = dt.Rows.Count;

            //        //grdpendapp.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        intcount = Appobj.GetPenFATrans("InvoiceApproval", Strtrantype, branchid, vouyear);

            //        //GrdApproved.Rows(0).Cells(0).Value = "Invoices" + "(" + intcount + ")"
            //        dt2.Rows.Add("Invoices" + "(" + intcount + ")");
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
            //        lngPA = dt.Rows.Count;

            //        //grdpendapp.Rows(1).Cells(0).Value = "Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        intcount = Appobj.GetPenFATrans("PAApproval", Strtrantype, branchid, vouyear);

            //        //GrdApproved.Rows(1).Cells(0).Value = "CN - Operations" + "(" + intcount + ")"
            //        dt2.Rows.Add("CN - Operations" + "(" + intcount + ")");
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "ProOSDNApproval");
            //        lngDN = dt.Rows.Count;

            //        //grdpendapp.Rows(2).Cells(0).Value = "Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro O/S Debit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        intcount = Appobj.GetPenFATrans("OSDNApproval", Strtrantype, branchid, vouyear);

            //        //GrdApproved.Rows(2).Cells(0).Value = "O/S Debit Notes" + "(" + intcount + ")"
            //        dt2.Rows.Add("O/S Debit Notes" + "(" + intcount + ")");
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "ProOSCNApproval");
            //        lngCN = dt.Rows.Count;

            //        //grdpendapp.Rows(3).Cells(0).Value = "Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro O/S Credit Notes" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial DN");
            //        lngCN = dt.Rows.Count;

            //        //grdpendapp.Rows(4).Cells(0).Value = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial CN");
            //        lngCN = dt.Rows.Count;

            //        //grdpendapp.Rows(5).Cells(0).Value = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        intcount = Appobj.GetPenFATrans("OSCNApproval", Strtrantype, branchid, vouyear);

            //        //GrdApproved.Rows(3).Cells(0).Value = "O/S Credit Notes" + "(" + intcount + ")"
            //        dt2.Rows.Add("O/S Credit Notes" + "(" + intcount + ")");
            //        intcount = Appobj.GetPenFATrans("Debit Note", Strtrantype, branchid, vouyear);

            //        //GrdApproved.Rows(4).Cells(0).Value = "Other Debit Notes" + "(" + intcount + ")"
            //        dt2.Rows.Add("Other Debit Notes" + "(" + intcount + ")");
            //        intcount = Appobj.GetPenFATrans("Credit Note", Strtrantype, branchid, vouyear);

            //        //GrdApproved.Rows(5).Cells(0).Value = "Other Credit Notes" + "(" + intcount + ")"
            //        dt2.Rows.Add("Other Credit Notes" + "(" + intcount + ")");

            //        GrdApproved11.DataSource = dt1;
            //        GrdApproved11.DataBind();
            //    }
            //    else
            //    {
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
            //        lngInv = dt.Rows.Count;

            //        //grdpendapp.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
            //        lngPA = dt.Rows.Count;

            //        //grdpendapp.Rows(1).Cells(0).Value = "Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"                
            //        dt1.Rows.Add("Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial DN");
            //        lngCN = dt.Rows.Count;

            //        //grdpendapp.Rows(2).Cells(0).Value = "Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro Other DN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //        dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial CN");
            //        lngCN = dt.Rows.Count;

            //        //grdpendapp.Rows(3).Cells(0).Value = "Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //        dt1.Rows.Add("Pro Other CN" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

            //        GrdApproved11.DataSource = dt1;
            //        GrdApproved11.DataBind();
            //    }
            //}
            //else
            //{
            //    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial Invoice");
            //    lngInv = dt.Rows.Count;

            //    //grdpendapp.Rows(0).Cells(0).Value = "Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //    dt1.Rows.Add("Pro Invoices" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");
            //    dt = Appobj.FillDt4Pro(Strtrantype, branchid, "Transfer To Commercial PA");
            //    lngPA = dt.Rows.Count;

            //    //grdpendapp.Rows(1).Cells(0).Value = "Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")"
            //    dt1.Rows.Add("Pro CN - Operations" + "  (" + System.Convert.ToString(dt.Rows.Count) + ")");

            //    GrdApproved11.DataSource = dt1;
            //    GrdApproved11.DataBind();
            //}
        }

        protected void lnk_PendingCountry_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            //txtPort1.Visible = true;
            //txtPort1.Text = "";
            
        }

       

     
     

        
        public void GrdDisable1()
        {
            // Grid View //
           
            // Panels //
           
           // pnlPortCountry1.Visible = false;
            
           // PanelApproved11.Visible = false;
          
           // Paneluserlogged.Visible = false;
          
           //// PanelDep.Visible = false;
          
           // PanelPendingApprovalCorp.Visible = false;
           // Panelexrate.Visible = false;
           // // Text Box//            
           // txtPort1.Visible = false;
            
           // if (IsPostBack)
           // {
           //     if (Session["Loggedname"] != null)
           //     {
           //         hname = Session["Loggedname"].ToString();

           //         if (hname == "userlog")
           //         {
           //             ifrmaster.Attributes["src"] = "../ForwardExports/Emptyform.aspx";
           //             Session["Loggedname"] = null;
           //         }
           //     }
           // }

        }

      

      
        protected void txtPort1_TextChanged(object sender, EventArgs e)
        {
            //DataTable dt1 = new DataTable();
            //dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Port") });
            //if (txtPort1.Text != "")
            //{
            //    dt = rightObj.GetCountryList(txtPort1.Text);
            //    if (dt.Rows.Count > 0)
            //    { }
            //    else
            //    {
            //        dt = rightObj.GetPortList(txtPort1.Text);
            //    }
            //    if (dt.Rows.Count > 0)
            //    {
            //        //GrdPort1.Rows(i).Cells(0).Value() = UCase(dt.Rows(i).Item(0).ToString())
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            dt1.Rows.Add(dt.Rows[i][0].ToString().ToUpper());
            //        }
            //        txtPort1.Visible = true;
            //        GrdPort1.Visible = true;
            //        pnlPortCountry1.Visible = true;
            //        GrdPort1.DataSource = dt1;
            //        GrdPort1.DataBind();
            //    }
            //}
            //else
            //{
            //    GrdPort1.DataSource = new DataTable();
            //    GrdPort1.DataBind();
            //}
        }

      

        

       

        protected void lnk_userlogged_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            LoadLiveUser();
            //grduserlogged.Visible = true;
            //Paneluserlogged.Visible = true;
        }
        protected void grduserlogged_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
             

                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grduserlogged, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        public void LoadLiveUser()
        {
            //string Strtrantype = Session["StrTranType"].ToString();
            //int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            //dt = hrempobj.GetLiveUser();

            //if (dt.Rows.Count > 0)
            //{
            //    //grdpendingcan.DataSource = dt;
            //    //grdpendingcan.DataBind();
            //    dttemp.Columns.Add("Userid", typeof(string));
            //    dttemp.Columns.Add("LOGGED", typeof(string));

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow dtrow = dttemp.NewRow();
            //        dtrow["Userid"] = dt.Rows[i][0].ToString();
            //        dtrow["LOGGED"] = dt.Rows[i][1].ToString().Substring(0, 3) + " " + "_" + dt.Rows[i][2].ToString();
            //        dttemp.Rows.Add(dtrow);
            //    }

            //    grduserlogged.DataSource = dttemp;
            //    grduserlogged.DataBind();
            //    if (grduserlogged.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dttemp.Rows.Count; i++)
            //        {
            //            //    if (dttemp.Rows[i][0].ToString() == grduserlogged.Rows[i].Cells[0].Text)
            //            //    {
            //            //grduserlogged.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
            //            grduserlogged.HeaderRow.Cells[0].CssClass = "hide";

            //            grduserlogged.Rows[i].Cells[0].CssClass = "hide";
            //        }
            //        //}
            //    }
            //}

            //else
            //{
            //    grduserlogged.DataSource = new DataTable();
            //    grduserlogged.DataBind();
            //}
        }

        protected void grduserlogged_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //int index;
                //string loggedno;
                //if (grduserlogged.Rows.Count > 0)
                //{
                //    index = grduserlogged.SelectedRow.RowIndex;
                //    //  loggedno = grduserlogged.Rows[index].Cells[0].Text;
                //    int log = hrempobj.GetEmpId(grduserlogged.Rows[index].Cells[0].Text);

                //    Session["Loggedid"] = log;
                //    Session["Loggedname"] = "userlog";
                //    Session["Budget"] = "userlog";
                //    ifrmaster.Attributes["src"] = "../ForwardExports/Mail.aspx";

                //    //Response.Redirect("../FormMain.aspx");
                //}

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

        protected void lnk_customerprofile_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Corporate/Customerprofile.aspx";
        }

        protected void lnk_PendingApprovalCorp_Click(object sender, EventArgs e)
        {
            GrdDisable1();
           // PanelPendingApprovalCorp.Visible = true;
            Session["Credit"] = "Credit";
        }

        protected void lbl_Credit_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Sales/CreditApproval.aspx";
        }

        protected void lbl_Web_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Corporate/CustomerApproval.aspx";
        }

    

        protected void lbl_Exception_Click(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Sales/ExemptionRequest.aspx";
        }

        protected void lnk_exrate_Click(object sender, EventArgs e)
        {
            GrdDisable1();
            loadgrd();
            //Panelexrate.Visible = true;
            //Gridexrate.Visible = true;

        }
        public void loadgrd()
        {
            //DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            //string dtexdate = obj_da_Logobj.GetDate().ToString();
            ////dt = exrobj.GetExRateDetails(dtexdate);
            //dt = exrobj.GetExRateDetails(Convert.ToDateTime(dtexdate));
            //if (dt.Rows.Count > 0)
            //{
            //    Gridexrate.DataSource = dt;
            //    Gridexrate.DataBind();
            //}
            //else
            //{
            //    Gridexrate.DataSource = dt;
            //    Gridexrate.DataBind();
            //}
        }

        protected void lnk_PendingDep_Click1(object sender, EventArgs e)
        {
            ifrmaster.Attributes["src"] = "../Corporate/Depositdetails.aspx";
        }




    }
}