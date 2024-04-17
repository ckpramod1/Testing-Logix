using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace logix.Home
{
    public partial class OIHome : System.Web.UI.Page
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
        DataTable dttempline = new DataTable();
        DataTable dttempdestuff = new DataTable();
        long lngPQuot, lngInv, lngPA, lngDN, lngCN;
        int branchid, vouyear, logempid;
        string ModuleName;
        string hname;

        double inches, Millimeter, yards, centimeter, feet, Meter;
        double ounce, gram, Pound, Kilogram, Ton, Tonnes;
        double mililiter, Quart, liter, gallon, kiloliter;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GrdDisable1();
            
           if (!this.IsPostBack)
            
            {
            Panelexrate.Visible = true;
            Gridexrate.Visible = true;
           // GrdDisable1();
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
            //GrdDisable1();
             UnclosedJobs1();
            grdunclosejobs.Visible = false;
            PanelUnclosedjob.Visible = false;
           // GrdDisable1();
            loadgrd();
            Panelexrate.Visible = true;
            Gridexrate.Visible = true;
            LoadPendingBooking12();
            pendingcan1();
            pendingline1();
            PendingApprovalFE1();
            LoadPendingStuff1();
            this.LoadPendingBooking1();
            this.pendingcan();
            this.pendingline();
            this.PendingApprovalFE();
            this.LoadPendingStuff();
            this.UnclosedJobs();
            }
        }

        public void LoadPendingStuff1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendStuff(branchid);
            hiddestuff.Text = Convert.ToInt32(dt.Rows.Count).ToString();
          
        }
        public void pendingline1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendLineno(branchid);
            hidline.Text = Convert.ToInt32(dt.Rows.Count).ToString();
        
        }
        public void pendingcan1()
        {
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendCAN(branchid);
            hidcan.Text = Convert.ToInt32(dt.Rows.Count).ToString();
          
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
            //Pop_GrdApproval.Hide();
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
            }
        }
        public void LoadPendingBooking12()
        {
            dt = leftObj.GetBooking(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            hidbooking.Text = Convert.ToInt32(dt.Rows.Count).ToString();
            //if (dt.Rows.Count > 0)
            //{               
            //    grdpendingbook1.Visible = true;
            //    grdpendingbook1.DataSource = dt;
            //    grdpendingbook1.DataBind();
            //}
            //else
            //{              
            //    grdpendingbook1.Visible = false;
            //    grdpendingbook1.DataSource = new DataTable();
            //    grdpendingbook1.DataBind();
            //}
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
        protected void lnk_PendingBooking_Click(object sender, EventArgs e)
        {
            ////GrdDisable1();
            //if (lnk_PendingBooking.Text == "Pending FA-Transfer")
            //{
            //    //PendingApproval1();
            //    //GrdApproved11.Visible = true;
            //    //PanelApproved11.Visible = true;
            //}
            //else
            //{
            //    LoadPendingBooking1(); 
            //}


            if (lnk_PendingBooking.Text == "Pending FA-Transfer")
            {
            
            }
            else
            {
                LoadPendingBooking1();
                grdpendingbook1.Visible = true;
                Panelbooking.Visible = true;
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
      /*  public void PendingApproval1()
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
        */
        public void LoadPendingBooking1()
        {
            dt = leftObj.GetBooking(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            //hidbooking.Text = Convert.ToInt32(dt.Rows.Count).ToString();
            if (dt.Rows.Count > 0)
            {
                //pop_lineGrd.Hide();
                Panelbooking.Visible = true;
                grdpendingbook1.Visible = true;
                grdpendingbook1.DataSource = dt;
                grdpendingbook1.DataBind();
               // popup_Grd.Show();
            }
            else
            {
                //popup_Grd.Hide();
                grdpendingbook1.Visible = false;
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
        public void UnclosedJobs()
        {
            grdunclosejobs.Visible = true;
            PanelUnclosedjob.Visible = true;
            string Strtrantype = Session["StrTranType"].ToString();
            int intcount = 0;
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("UnClosed Jobs") });

            if (Strtrantype != "CH")
            {
                //pop_Grdunclosed.Show();
                grdunclosejobs.Visible = true;
                PanelUnclosedjob.Visible = true;
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
            }
            else
            {
                //pop_Grdunclosed.Hide();
                grdunclosejobs.Visible = false;
                PanelUnclosedjob.Visible = false;
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
                    ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
                }
                else if (name.Substring(0, 2) == "AI")
                {
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
                }
                else if (name.Substring(0, 2) == "FE")
                {
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
                }
                else if (name.Substring(0, 2) == "FI")
                {
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(grdunclosejobs, typeof(Button), "UnClosedJob", str_Script, true);
                }
            }
        }
        protected void lnk_unclosedjobs_Click(object sender, EventArgs e)
        {
            //GrdDisable1();
            UnclosedJobs();
            
        }
        protected void lnk_PendingApproval_Click(object sender, EventArgs e)
        {
            //GrdDisable1();
            PendingApprovalFE();
           
        }
        public void PendingApprovalFE()
        {

            //Pop_GrdApproval.Show();
         
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
        protected void lnk_Pendingcan_Click(object sender, EventArgs e)
        {
           // GrdDisable1();
            pendingcan();
           
        }
        public void pendingcan()
        {
            grdpendingcan.Visible = true;
            Panelcan.Visible = true;
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendCAN(branchid);
            //pop_cangrd.Show();
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
                Panelcan.Visible = true;
                grdpendingcan.Visible = true;
                grdpendingcan.DataSource = dttemp;
                grdpendingcan.DataBind();
            }

            else
            {
               // Panelcan.Visible = true;
              //  grdpendingcan.Visible = false;
               
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
           // GrdDisable1();
            pendingline();
           
        }
        public void pendingline()
        {
            grdpendingline.Visible = true;
            Panelline.Visible = true;
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendLineno(branchid);

            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                dttempline.Columns.Add("Jobno", typeof(string));
                dttempline.Columns.Add("Vessel&voyage", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttempline.NewRow();
                    dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["vessel&voyage"] = dt.Rows[i][1].ToString() + " " + "V." + dt.Rows[i][2].ToString();
                    dttempline.Rows.Add(dtrow);
                }
                //pop_lineGrd.Show();
                Panelline.Visible = true;
                grdpendingline.Visible = true;
                grdpendingline.DataSource = dttempline;
                grdpendingline.DataBind();
            }

            else
            {
               // pop_lineGrd.Show();
                Panelline.Visible = true;
                grdpendingline.Visible = true;
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
           // GrdDisable1();
            LoadPendingStuff();
           
        }
        public void LoadPendingStuff()
        {
            grdpendingstuff.Visible = true;
            Panelstuff.Visible = true;
            string Strtrantype = Session["StrTranType"].ToString();
            int branchid = Convert.ToInt16(Session["LoginDivisionId"].ToString());
            dt = leftObj.GetPendStuff(branchid);

            if (dt.Rows.Count > 0)
            {
                //grdpendingcan.DataSource = dt;
                //grdpendingcan.DataBind();
                dttempdestuff.Columns.Add("JobNo", typeof(string));
                dttempdestuff.Columns.Add("Vessel&Voyage", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtrow = dttempdestuff.NewRow();
                    dtrow["jobno"] = dt.Rows[i][0].ToString();
                    dtrow["vessel&voyage"] = dt.Rows[i][1].ToString() + " " + "V." + dt.Rows[i][2].ToString();
                    dttempdestuff.Rows.Add(dtrow);
                }
                //pop_destuffgrd.Show();
                grdpendingstuff.DataSource = dttempdestuff;
                grdpendingstuff.DataBind();
            }

            else
            {
              //  pop_destuffgrd.Show();
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

 
       /* protected void lnl_inco_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ForwardExports/IncoTerm.aspx");
        }

        protected void lnk_length_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ForwardExports/LengthConversion.aspx");
        }

        protected void lnk_weight_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ForwardExports/WeightConversion.aspx");
        }

        protected void lnk_volume_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ForwardExports/VolumeConversion.aspx");
        }*/




        protected void lnk_curr_Click(object sender, EventArgs e)
        {

            DataAccess.Masters.MasterCountry countryobj = new DataAccess.Masters.MasterCountry();
            DataTable dt = new DataTable();
            dt = countryobj.GetAllCurrency();
            if (dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();

            }
            pln_KPI.Visible = true;
            popup_KPI.Show();

            // Response.Redirect("../ForwardExports/CountryCurrency.aspx");
        }

        protected void lnl_inco_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ForwardExports/IncoTerm.aspx");
        }

        protected void lnk_length_Click(object sender, EventArgs e)
        {

            clear();
            Panel1.Visible = true;
            ModalPopupExtender1.Show();
            // Response.Redirect("../ForwardExports/LengthConversion.aspx");
        }

        protected void lnk_weight_Click(object sender, EventArgs e)
        {
            txtClear();
            Panel3.Visible = true;
            ModalPopupExtender2.Show();

            //Response.Redirect("../ForwardExports/WeightConversion.aspx");
        }

        protected void lnk_volume_Click(object sender, EventArgs e)
        {
            txtClearvol();
            Panel5.Visible = true;
            ModalPopupExtender3.Show();

            // Response.Redirect("../ForwardExports/VolumeConversion.aspx");
        }



        public void InchesTo()
        {
            Millimeter = Convert.ToInt32(txtInches.Text) * 25.4;

            feet = Convert.ToInt32(txtInches.Text) * 0.0833;

            yards = Convert.ToInt32(txtInches.Text) * 0.0277778;

            centimeter = Convert.ToInt32(txtInches.Text) * 2.54;

            Meter = Convert.ToInt32(txtInches.Text) * 0.0254;

            txtMilliMeter.Text = Millimeter.ToString();

            txtYards.Text = yards.ToString();

            txtCentimeter.Text = centimeter.ToString();

            txtFeet.Text = feet.ToString();


            txtMeter.Text = Meter.ToString();

        }

        public void Yardsto()
        {
            inches = Convert.ToInt32(txtYards.Text) * 36;
            feet = Convert.ToInt32(txtYards.Text) * 3;
            Millimeter = Convert.ToInt32(txtYards.Text) * 914.4;
            centimeter = Convert.ToInt32(txtYards.Text) * 91.44;
            Meter = Convert.ToInt32(txtYards.Text) * 0.9144;

            txtInches.Text = inches.ToString();

            txtMilliMeter.Text = Millimeter.ToString();

            txtCentimeter.Text = centimeter.ToString();

            txtFeet.Text = feet.ToString();

            txtMeter.Text = Meter.ToString();
        }

        public void FeetTo()
        {
            Millimeter = Convert.ToInt32(txtFeet.Text) * 25.4;
            inches = Convert.ToInt32(txtFeet.Text) * 12;
            yards = Convert.ToInt32(txtFeet.Text) * 0.0277778;
            centimeter = Convert.ToInt32(txtFeet.Text) * 2.54;
            Meter = Convert.ToInt32(txtFeet.Text) * 0.0254;

            txtInches.Text = inches.ToString();

            txtMilliMeter.Text = Millimeter.ToString();

            txtCentimeter.Text = centimeter.ToString();

            txtYards.Text = yards.ToString();

            txtMeter.Text = Meter.ToString();
        }

        public void MilimeterTo()
        {
            inches = Convert.ToInt32(txtMilliMeter.Text) * 0.0393701;
            feet = Convert.ToInt32(txtMilliMeter.Text) * 0.0032808;
            yards = Convert.ToInt32(txtMilliMeter.Text) * 0.0010936;
            centimeter = Convert.ToInt32(txtMilliMeter.Text) * 0.1;
            Meter = Convert.ToInt32(txtMilliMeter.Text) * 0.001;
            txtInches.Text = inches.ToString();

            txtFeet.Text = feet.ToString();

            txtCentimeter.Text = centimeter.ToString();

            txtYards.Text = yards.ToString();

            txtMeter.Text = Meter.ToString();
        }

        public void Centmeter()
        {
            Millimeter = Convert.ToInt32(txtCentimeter.Text) * 10;
            feet = Convert.ToInt32(txtCentimeter.Text) * 0.0328084;
            yards = Convert.ToInt32(txtCentimeter.Text) * 0.0109361;
            inches = Convert.ToInt32(txtCentimeter.Text) * 0.3937008;
            Meter = Convert.ToInt32(txtCentimeter.Text) * 0.01;

            txtInches.Text = inches.ToString();

            txtFeet.Text = feet.ToString();

            txtMilliMeter.Text = Millimeter.ToString();

            txtYards.Text = yards.ToString();

            txtMeter.Text = Meter.ToString();
        }

        public void MeterTo()
        {
            Millimeter = Convert.ToInt32(txtMeter.Text) * 1000;
            feet = Convert.ToInt32(txtMeter.Text) * 3.2808399;
            yards = Convert.ToInt32(txtMeter.Text) * 1.0936133;
            centimeter = Convert.ToInt32(txtMeter.Text) * 100;
            inches = Convert.ToInt32(txtMeter.Text) * 39.3700787;

            txtInches.Text = inches.ToString();

            txtFeet.Text = feet.ToString();

            txtMilliMeter.Text = Millimeter.ToString();

            txtYards.Text = yards.ToString();

            txtCentimeter.Text = centimeter.ToString();
        }

        public void clear()
        {
            txtInches.Text = "";

            txtFeet.Text = "";

            txtMeter.Text = "";

            txtYards.Text = "";

            txtMeter.Text = "";

            txtMilliMeter.Text = "";

            txtCentimeter.Text = "";
        }

        public void GetResult()
        {
            if (txtInches.Text != "0" && txtInches.Text != "")
            {
                InchesTo();
            }

            else if (txtFeet.Text != "0" && txtFeet.Text != "")
            {
                FeetTo();
            }

            else if (txtYards.Text != "0" && txtYards.Text != "")
            {
                Yardsto();
            }

            else if (txtMilliMeter.Text != "0" && txtMilliMeter.Text != "")
            {
                MilimeterTo();
            }

            else if (txtCentimeter.Text != "0" && txtCentimeter.Text != "")
            {
                Centmeter();
            }

            else if (txtMeter.Text != "0" && txtMeter.Text != "")
            {
                MeterTo();
            }
        }

        protected void txtInches_TextChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            ModalPopupExtender1.Show();
            if (txtInches.Text == "")
            {
                clear();
            }
            else
            {
                GetResult();
            }
        }

        protected void txtMilliMeter_TextChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            ModalPopupExtender1.Show();
            if (txtMilliMeter.Text == "")
            {
                clear();
            }
            else
            {
                GetResult();
            }
        }

        protected void txtYards_TextChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            ModalPopupExtender1.Show();
            if (txtYards.Text == "")
            {
                clear();
            }
            else
            {
                GetResult();
            }
        }

        protected void txtCentimeter_TextChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            ModalPopupExtender1.Show();
            if (txtCentimeter.Text == "")
            {
                clear();
            }
            else
            {
                GetResult();
            }
        }

        protected void txtFeet_TextChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            ModalPopupExtender1.Show();
            if (txtFeet.Text == "")
            {
                clear();
            }
            else
            {
                GetResult();
            }
        }

        protected void txtMeter_TextChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            ModalPopupExtender1.Show();
            if (txtMeter.Text == "")
            {
                clear();
            }
            else
            {
                GetResult();
            }
        }


        public void OunceTo()
        {
            gram = Convert.ToInt32(txtOunce.Text) * 28.3495231;
            Pound = Convert.ToInt32(txtOunce.Text) * 0.0625;
            Ton = Convert.ToInt32(txtOunce.Text) * 0.0000283;
            Kilogram = Convert.ToInt32(txtOunce.Text) * 0.0283495;
            Tonnes = Convert.ToInt32(txtOunce.Text) * 0.0000283;

            txtGram.Text = gram.ToString();

            txtPound.Text = Pound.ToString();

            txtTon.Text = Ton.ToString();

            txtKilometer.Text = Kilogram.ToString();

            txtMeterwe.Text = Tonnes.ToString();



        }

        public void GramTo()
        {
            ounce = Convert.ToInt32(txtGram.Text) * 0.035274;
            Pound = Convert.ToInt32(txtGram.Text) * 0.0022046;
            Kilogram = Convert.ToInt32(txtGram.Text) * 0.001;
            Ton = Convert.ToInt32(txtGram.Text) * 0.000001;
            Tonnes = Convert.ToInt32(txtGram.Text) * 0.000001;

            txtOunce.Text = ounce.ToString();

            txtPound.Text = Pound.ToString();

            txtTon.Text = Ton.ToString();

            txtKilometer.Text = Kilogram.ToString();

            txtMeterwe.Text = Tonnes.ToString();

        }

        public void PoundTo()
        {
            ounce = Convert.ToInt32(txtPound.Text) * 16;
            gram = Convert.ToInt32(txtPound.Text) * 453.59237;
            Kilogram = Convert.ToInt32(txtPound.Text) * 0.4535924;
            Ton = Convert.ToInt32(txtPound.Text) * 0.0004536;
            Tonnes = Convert.ToInt32(txtPound.Text) * 0.0004536;

            txtOunce.Text = ounce.ToString();

            txtGram.Text = gram.ToString();

            txtTon.Text = Ton.ToString();

            txtKilometer.Text = Kilogram.ToString();

            txtMeterwe.Text = Tonnes.ToString();
        }

        public void KiloMeterTo()
        {
            ounce = Convert.ToInt32(txtKilometer.Text) * 35.2739619;
            gram = Convert.ToInt32(txtKilometer.Text) * 1000;
            Pound = Convert.ToInt32(txtKilometer.Text) * 2.2046226;
            Ton = Convert.ToInt32(txtKilometer.Text) * 0.001;
            Tonnes = Convert.ToInt32(txtKilometer.Text) * 0.001;

            txtOunce.Text = ounce.ToString();

            txtGram.Text = gram.ToString();

            txtTon.Text = Ton.ToString();

            txtPound.Text = Pound.ToString();


            txtMeterwe.Text = Tonnes.ToString();
        }
        public void TonTo()
        {
            ounce = Convert.ToInt32(txtTon.Text) * 35273.9619496;
            gram = Convert.ToInt32(txtTon.Text) * 1000000;
            Pound = Convert.ToInt32(txtTon.Text) * 2204.6226218;
            Kilogram = Convert.ToInt32(txtTon.Text) * 1000;
            Tonnes = Convert.ToInt32(txtTon.Text) * 1;

            txtOunce.Text = ounce.ToString();

            txtGram.Text = gram.ToString();

            txtKilometer.Text = Kilogram.ToString();

            txtPound.Text = Pound.ToString();

            txtMeterwe.Text = Tonnes.ToString();
        }

        public void Toneeto()
        {
            ounce = Convert.ToInt32(txtMeter.Text) * 35273.9619496;
            gram = Convert.ToInt32(txtMeter.Text) * 1000000;
            Pound = Convert.ToInt32(txtMeter.Text) * 2204.6226218;
            Kilogram = Convert.ToInt32(txtMeter.Text) * 1000;
            Ton = Convert.ToInt32(txtMeter.Text) * 1;
            txtOunce.Text = ounce.ToString();

            txtGram.Text = gram.ToString();

            txtKilometer.Text = Kilogram.ToString();

            txtPound.Text = Pound.ToString();

            txtTon.Text = Ton.ToString();
        }

        public void txtClear()
        {
            txtOunce.Text = "";

            txtMeterwe.Text = "";

            txtKilometer.Text = "";

            txtGram.Text = "";

            txtPound.Text = "";

            txtTon.Text = "";
        }


        protected void txtOunce_TextChanged(object sender, EventArgs e)
        {
            // clear();
            Panel3.Visible = true;
            ModalPopupExtender2.Show();
            if (txtOunce.Text == "")
            {
                txtClear();
            }
            else
            {
                OunceTo();
            }
        }

        protected void txtGram_TextChanged(object sender, EventArgs e)
        {
            // clear();
            Panel3.Visible = true;
            ModalPopupExtender2.Show();
            if (txtGram.Text == "")
            {
                txtClear();
            }
            else
            {
                GramTo();
            }
        }

        protected void txtPound_TextChanged(object sender, EventArgs e)
        {
            // clear();
            Panel3.Visible = true;
            ModalPopupExtender2.Show();
            if (txtPound.Text == "")
            {
                txtClear();
            }
            else
            {
                PoundTo();
            }
        }

        protected void txtKilometer_TextChanged(object sender, EventArgs e)
        {
            clear();
            Panel3.Visible = true;
            ModalPopupExtender2.Show();
            if (txtKilometer.Text == "")
            {
                txtClear();
            }
            else
            {
                KiloMeterTo();
            }
        }

        protected void txtTon_TextChanged(object sender, EventArgs e)
        {
            // clear();
            Panel3.Visible = true;
            ModalPopupExtender2.Show();
            if (txtTon.Text == "")
            {
                txtClear();
            }
            else
            {
                TonTo();
            }
        }



        protected void txtMeterwe_TextChanged(object sender, EventArgs e)
        {
            // clear();
            Panel3.Visible = true;
            ModalPopupExtender2.Show();

            if (txtMeter.Text == "")
            {
                txtClear();
            }
            else
            {
                Toneeto();
            }
        }





        public void OunceTovolu()
        {
            Quart = Convert.ToDouble(txtOuncevoul.Text) * 0.03125;
            gallon = Convert.ToDouble(txtOuncevoul.Text) * 0.0078125;
            mililiter = Convert.ToDouble(txtOuncevoul.Text) * 29.5735297;
            liter = Convert.ToDouble(txtOuncevoul.Text) * 0.0295735;
            kiloliter = Convert.ToDouble(txtOuncevoul.Text) * 0.0000296;

            txtMiliLiter.Text = mililiter.ToString();
            txtLiter.Text = liter.ToString();
            txtQuart.Text = Quart.ToString();
            txtKiloLiter.Text = kiloliter.ToString();
            txtGallon.Text = gallon.ToString();
        }

        public void QuartTo()
        {
            ounce = Convert.ToDouble(txtQuart.Text) * 32;
            gallon = Convert.ToDouble(txtQuart.Text) * 0.25;
            mililiter = Convert.ToDouble(txtQuart.Text) * 946.35295;
            liter = Convert.ToDouble(txtQuart.Text) * 0.946353;
            kiloliter = Convert.ToDouble(txtQuart.Text) * 0.0009464;

            txtMiliLiter.Text = mililiter.ToString();
            txtLiter.Text = liter.ToString();
            txtOuncevoul.Text = ounce.ToString();
            txtKiloLiter.Text = kiloliter.ToString();
            txtGallon.Text = gallon.ToString();
        }

        public void GallonTo()
        {
            ounce = Convert.ToDouble(txtGallon.Text) * 25.4;
            Quart = Convert.ToDouble(txtGallon.Text) * 0.25;
            mililiter = Convert.ToDouble(txtGallon.Text) * 946.35295;
            liter = Convert.ToDouble(txtGallon.Text) * 0.946353;
            kiloliter = Convert.ToDouble(txtGallon.Text) * 0.0009464;

            txtMiliLiter.Text = mililiter.ToString();
            txtLiter.Text = liter.ToString();
            txtOuncevoul.Text = ounce.ToString();
            txtKiloLiter.Text = kiloliter.ToString();
            txtQuart.Text = Quart.ToString();

        }

        public void MiliLiterTo()
        {
            ounce = Convert.ToDouble(txtMiliLiter.Text) * 29.5735297;
            Quart = Convert.ToDouble(txtMiliLiter.Text) * 0.03125;
            gallon = Convert.ToDouble(txtMiliLiter.Text) * 0.0078125;
            liter = Convert.ToDouble(txtMiliLiter.Text) * 0.001;
            kiloliter = Convert.ToDouble(txtMiliLiter.Text) * 0.000001;

            txtGallon.Text = gallon.ToString();
            txtLiter.Text = liter.ToString();
            txtOuncevoul.Text = ounce.ToString();
            txtKiloLiter.Text = kiloliter.ToString();
            txtQuart.Text = Quart.ToString();
        }

        public void LiterTo()
        {
            ounce = Convert.ToDouble(txtLiter.Text) * 33.8140226;
            Quart = Convert.ToDouble(txtLiter.Text) * 1.0566882;
            gallon = Convert.ToDouble(txtLiter.Text) * 0.2641721;
            mililiter = Convert.ToDouble(txtLiter.Text) * 1000;
            kiloliter = Convert.ToDouble(txtLiter.Text) * 0.001;
            txtGallon.Text = gallon.ToString();
            txtMiliLiter.Text = mililiter.ToString();
            txtOuncevoul.Text = ounce.ToString();
            txtKiloLiter.Text = kiloliter.ToString();
            txtQuart.Text = Quart.ToString();
        }

        public void KiloLiterTo()
        {
            ounce = Convert.ToDouble(txtKiloLiter.Text) * 33814.0225589;
            Quart = Convert.ToDouble(txtKiloLiter.Text) * 1056.688205;
            gallon = Convert.ToDouble(txtKiloLiter.Text) * 264.1720512;
            mililiter = Convert.ToDouble(txtKiloLiter.Text) * 1000000;
            liter = Convert.ToInt32(txtKiloLiter.Text) * 1000;

            txtGallon.Text = gallon.ToString();
            txtMiliLiter.Text = mililiter.ToString();
            txtOuncevoul.Text = ounce.ToString();
            txtLiter.Text = liter.ToString();
            txtQuart.Text = Quart.ToString();
        }

        public void txtClearvol()
        {
            txtOuncevoul.Text = "";

            txtMiliLiter.Text = "";

            txtLiter.Text = "";

            txtGallon.Text = "";

            txtKiloLiter.Text = "";

            txtQuart.Text = "";
        }

        public void resultdetails()
        {
            if (txtOuncevoul.Text != "0" && txtOuncevoul.Text != "")
            {
                OunceTovolu();
            }
            else if (txtMiliLiter.Text != "0" && txtMiliLiter.Text != "")
            {
                MiliLiterTo();
            }

            else if (txtLiter.Text != "0" && txtLiter.Text != "")
            {
                LiterTo();
            }

            else if (txtGallon.Text != "0" && txtGallon.Text != "")
            {
                GallonTo();
            }

            else if (txtKiloLiter.Text != "0" && txtKiloLiter.Text != "")
            {
                KiloLiterTo();
            }

            else if (txtQuart.Text != "0" && txtQuart.Text != "")
            {
                QuartTo();
            }
        }

        /* protected void txtOunce_TextChanged(object sender, EventArgs e)
         {
           
         }*/

        protected void txtMiliLiter_TextChanged(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            ModalPopupExtender3.Show();
            if (txtMiliLiter.Text == "")
            {
                txtClearvol();
            }
            else
            {
                MiliLiterTo();
            }
        }

        protected void txtQuart_TextChanged(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            ModalPopupExtender3.Show();
            if (txtQuart.Text == "")
            {
                txtClear();
            }
            else
            {
                QuartTo();
            }
        }

        protected void txtLiter_TextChanged(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            ModalPopupExtender3.Show();
            if (txtLiter.Text == "")
            {
                txtClear();
            }
            else
            {
                LiterTo();
            }
        }

        protected void txtGallon_TextChanged(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            ModalPopupExtender3.Show();
            if (txtGallon.Text == "")
            {
                txtClear();
            }
            else
            {
                GallonTo();
            }
        }

        protected void txtKiloLiter_TextChanged(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            ModalPopupExtender3.Show();
            if (txtKiloLiter.Text == "")
            {
                txtClear();
            }
            else
            {
                KiloLiterTo();
            }
        }

        protected void txtOuncevoul_TextChanged(object sender, EventArgs e)
        {
            Panel5.Visible = true;
            ModalPopupExtender3.Show();

            if (txtOuncevoul.Text == "")
            {
                txtClearvol();
            }
            else
            {
                OunceTovolu();
            }
        }

    }
}