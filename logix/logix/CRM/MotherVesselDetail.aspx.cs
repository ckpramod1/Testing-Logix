using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace logix.CRM
{

    public partial class MotherVesselDetail : System.Web.UI.Page
    {
        DataAccess.Corporate CorpObj = new DataAccess.Corporate();
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingExports.StuffingConfirmation STufobj = new DataAccess.ForwardingExports.StuffingConfirmation();
        DataAccess.ForwardingExports.LoadingConfirmation LoadConfirm = new DataAccess.ForwardingExports.LoadingConfirmation();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.ForwardingExports.ShippingBill ShippingBillobj = new DataAccess.ForwardingExports.ShippingBill();
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
        DataAccess.Message4Booking msgbookingobj = new DataAccess.Message4Booking();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterVessel vesselobj = new DataAccess.Masters.MasterVessel();
        DataAccess.Masters.MasterPackages packageobj = new DataAccess.Masters.MasterPackages();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
       
        Boolean sbexist, sbvalid = false;
        string trantype, strname;
        string Sname;
        char invpl;
        string fd, pol, por, pod;
        string blno;
        string stuffInland, loadingInland, TCInland;
        int jobno, intjobopn, jobtype;
        int intcust;
        int bookno, intpkgs;
        int polid, podid, intagentid, intshipperid, custid, destid, intPkgID;
        DateTime dtstfon, dtsailcnfon, dtdocnfreqon, dtdocnfsenton, dtdssenton, dtjobopn;
        DateTime sbdate,dtDODdate;
        DateTime dtetd, dteta,dtFlwUpd;
        int noofpkgs, pkgid, exporter, agent, destination;
        int customerid;
        int intagent, intpkg;
        double grosswt;
        string Ctrl_List;
        string Msg_List;
        string Dtype_List;
        string str_Uiid = "", str_FornName;
        string strdiv;
        int vesselid, oldvesselid;
        DataTable dtchkfordat = new DataTable();
        DataTable dt = new DataTable();
        DataTable dtCont = new DataTable();
        string DivName;
        string shippermailadd;
        int int_empid;
        string internalmailid;
        string usermail;
        string blpod;  
        string strEmpName;
        string str_attach;
        int int_branchid;
        int int_divisionid,int_back=0;
        string sendqry;
        DateTime etddate, currdate;
        string Strvar;
        Boolean blrr;
        DataTable dtFromSession;
        int SelectIndex = 0;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "dropdownButton();SpanTagMoveInputBottom();MuiTextField();", true);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('http://logix.copperhawk.tech/','_top');", true);
            }
            
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_back);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_save);

            if (txt_job.Text != "" && txt_book.Text != "")
            {
                txt_sb.Enabled = true;
            }
            else
            { txt_sb.Enabled = false; }
         
            if (!IsPostBack)
            {
                try
                {

                    DateTime dtlog = Logobj.GetDate();
                    txt_sbdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    txt_dodate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    txt_dodate.Enabled = false;
                    txtetd.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    txteta.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    txt_next.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    Ctrl_List = txt_job.ID + "~" + txt_book.ID + "~" + txt_sb.ID + "~" + txt_pkgs.ID + "~" + txt_pkgtype.ID + "~" + txt_weight.ID + "~" + txt_volume.ID + "~" + txt_exporter.ID + "~" + txt_dest.ID + "~" + txt_agent.ID + "~" + txt_remarks.ID;//+ "~" + txt_next.Text
                    Msg_List = "JobNo~Booking NO~Shipping Bill~No of packages~Package Type~Weight~Volume~Exporter Name~Destination~Agent Name~Remarks";//~Next Follow Update
                    Dtype_List = "string~string";
                    btn_save.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    // btn_save.Attributes.Add("Onclick", "return IsDate('txt_sbdate');");
                    btn_add.Attributes.Add("Onclick", "return IsDate('txt_dodate~txtetd~txteta');");
                    txt_pkgs.Attributes.Add("onkeypress", "return IntegerCheck(event);");
                    txt_weight.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weight')");
                    txt_volume.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Volume')");
                    Ctrl_List = txt_book.ID + "~" + txt_mvessel.ID + "~" + txt_voy.ID + "~" + txt_pol.ID + "~" + txtpod.ID + "~" + txtremarks.ID;
                    Msg_List = "Booking No~Master Vessel~Voyage~POL~Port Of Destination~Remarks";
                    Dtype_List = "string~string";
                    btn_add.Attributes.Add("onclick", "return IsValid('" + Ctrl_List + "','" + Msg_List + "','" + Dtype_List + "')");
                    //string transtype = HttpContext.Current.Session["StrTranType"].ToString();
                    //int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                    //int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                    Session["jobno"] = "";
                    Session["head"] = "";
                    //lbl_head.Text = Request.QueryString["type"].ToString();

                    hid_jobno.Value = Request.QueryString["jobno"].ToString();



                    dtFromSession = Session["Bookingno"] as DataTable;
                    //ddl_Vessal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
                    if (dtFromSession.Rows.Count != 0)
                    {

                        for (int i = 0; i < dtFromSession.Rows.Count; i++) {
                            DataRow row = dtFromSession.Rows[i];

                            ddl_Vessal.Items.Add(row["Bookingno"].ToString());
                            //ddl_Vessal.Items.Insert(i, new System.Web.UI.WebControls.ListItem(row["Bookingno"].ToString()));

                        }
                    }
                        DataTable dt1 = new DataTable();
                        int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                        jobno = Convert.ToInt32(hid_jobno.Value.ToString());
                        dt1 = STufobj.GetMothervessaldts(jobno, bid);
                    if (dt1.Rows.Count != 0)
                    {

                        Grd_vessel.DataSource = dt1;
                        Grd_vessel.DataBind();
                        DataRow lastRow = dt1.Rows[dt1.Rows.Count - 1];

                        // Access the last value in the last row
                        object lastValue = lastRow["pod"];
                        object lastValue1 = lastRow["eta"];
                        // Replace "ColumnName" with the actual column name from which you want to get the value

                        // If the column contains a specific data type like string, you may cast the value accordingly
                        string lastStringValue = lastRow["pod"].ToString();
                        string lastStringValue1 = lastRow["eta"].ToString();
                        txtpol.Text = lastStringValue;
                        txtetd.Text = lastStringValue1;
                        txtpol.Enabled = false;
                    }
                    else
                    {

                        txtetd.Text = Request.QueryString["Eta"].ToString();
                        txtpol.Text = Request.QueryString["Pod"].ToString();
                        txtpol.Enabled = false;

                    }

                    txt_job.Text = Request.QueryString["jobno"].ToString();
                    txt_vessel.Text = Request.QueryString["Vessel"].ToString();
                    txt_pol.Text = Request.QueryString["Pol"].ToString();
                    txt_pod.Text = Request.QueryString["Finaldes"].ToString();
                    txt_eta.Text= Request.QueryString["Eta"].ToString();
                    txt_etd.Text = Request.QueryString["Etd"].ToString();


                    Session["head"] = lbl_head.Text;
                    //headerlabel.InnerText = lbl_head.Text;
                    //EmptyGridSB();
                    //EmptyGridVessel();
                    //EmptyGridmail();
                    //EmptyGridIntermail();
                    Session["str_sfs"] = "";
                    Session["str_sp"] = "";
                    UserRights();
                    if (Request.QueryString.ToString().Contains("bookno") && Request.QueryString.ToString().Contains("job"))
                    {
                        txt_book.Text = Request.QueryString["bookno"].ToString();
                  

                        if (Session["StrTranType"] == "FE")
                        {

                            txt_job_TextChanged1(sender, e);
                            txt_book_TextChanged(sender, e);
                        }

                    }

                    txt_job.Enabled=false;
                    txt_vessel.Enabled = false;
                    txt_pol.Enabled = false;
                    txt_pod.Enabled = false;
                    txt_eta.Enabled = false;
                    txt_etd.Enabled = false;
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../FormMain.aspx','_top');", true);
                }

            }
            else if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }

            //EmptyGridSB();
            //EmptyGridVessel();
            //EmptyGridmail();
            //EmptyGridIntermail();
            if (lbl_head.Text == "D O Confirmation")
            {
               
                btn_save.Enabled = false;
                btn_add.Enabled = false;
                Label1.Visible = false;
                //lbl_dodte.Enabled = true;
                txt_dodate.Enabled = true;
                btn_update.Enabled = true;
                btn_view.Enabled = true;
                btn_save.ForeColor = System.Drawing.Color.Gray;
                btn_add.ForeColor = System.Drawing.Color.Gray;
                btn_update.ForeColor = System.Drawing.Color.White;
                btn_view.ForeColor = System.Drawing.Color.White;
            }
            else
            {
             
                btn_view.Enabled = false;
                Label1.Visible = false;
                //lbl_dodte.Enabled = false;
                txt_dodate.Enabled = false;
                btn_update.Enabled = false;
                btn_update.ForeColor = System.Drawing.Color.Gray;
                btn_view.ForeColor = System.Drawing.Color.Gray;

            }

            //Grd_sb.DataSource = null;
            //Grd_sb.DataBind();
            //Grd_vessel.DataSource = null;
            //Grd_vessel.DataBind();
        }

        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;

        }


        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    //Boolean btn_delete;
                    //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        [WebMethod]
        public static List<string> CMailID(string prefix)
        {
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
            DataTable obj_Dt = new DataTable();
            List<string> Bookingno = new List<string>();
            obj_Dt = obj_da_sc.GetLikeCustExporMailID(prefix);
            Bookingno = Utility.Fn_DatatableToList_int32(obj_Dt, "expmailid", "customerid");
            return Bookingno;
        }


        [WebMethod]
        public static List<string> GETBookingNo(string prefix)
        {
            List<string> List_Result = new List<string>();
            string transtypewd = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            DataAccess.Marketing.Booking obj_bok = new DataAccess.Marketing.Booking();
            DataTable dtBok = new DataTable();
            dtBok = obj_bok.GetBookingPending(transtypewd, bid, prefix);
            List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dtBok, "bookingno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GETBookingstuff(string prefix)
        {
            List<string> List_Result = new List<string>();
            string transtype = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataAccess.ForwardingExports.StuffingConfirmation obj_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
            DataTable dtBok = new DataTable();
            dtBok = obj_stuff.GetLikeBooking(transtype, prefix, bid, did);
            List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dtBok, "shiprefno");
            return List_Result;
        }

        //[WebMethod]
        //public static List<string> GETBookingsail(string prefix)
        //{
        //    List<string> List_Result = new List<string>();
        //    string transtype = HttpContext.Current.Session["StrTranType"].ToString();
        //    int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
        //    int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
        //    int jobno= Convert.ToInt32(HttpContext.Current.Session["jobno"].ToString());
        //    DataAccess.ForwardingExports.StuffingConfirmation obj_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
        //    DataTable dtBok = new DataTable();
        //    dtBok = obj_stuff.GetLikeBookingWJobNo(transtype, prefix,jobno,bid, did);
        //    List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dtBok, "shiprefno");
        //    return List_Result;
        //}

        [WebMethod]
        public static List<string> GETBookingtrans(string prefix)
        {
            List<string> List_Result = new List<string>();
            string transtype = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataAccess.ForwardingExports.StuffingConfirmation obj_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
            DataTable dtBok = new DataTable();
            if (HttpContext.Current.Session["head"].ToString() == "Stuffing Details")
            {

                dtBok = obj_stuff.GetLikeBooking(transtype, prefix.ToUpper(), bid, did);
                List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dtBok, "shiprefno");
            }
            else if (HttpContext.Current.Session["head"].ToString() == "Sailing Confirmation Booking")
            {
                if (HttpContext.Current.Session["jobno"].ToString() != "")
                {
                    int jobno = Convert.ToInt32(HttpContext.Current.Session["jobno"].ToString());
                    dtBok = obj_stuff.GetLikeBookingWJobNo(transtype, prefix.ToUpper(), jobno, bid, did);
                    List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dtBok, "shiprefno");
                }

            }
            else if (HttpContext.Current.Session["head"].ToString() == "Transhipment Confirmation")
            {
                if (HttpContext.Current.Session["jobno"].ToString() != "")
                {
                    int jobno = Convert.ToInt32(HttpContext.Current.Session["jobno"].ToString());
                    dtBok = obj_stuff.GetLikeBookingWJobNo(transtype, prefix.ToUpper(), jobno, bid, did);
                    List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dtBok, "shiprefno");
                }


            }
            else
                if (HttpContext.Current.Session["jobno"].ToString() != "")
                {
                    int jobno = Convert.ToInt32(HttpContext.Current.Session["jobno"].ToString());
                    dtBok = obj_stuff.GetLikeBookingWJobNo(transtype, prefix.ToUpper(), jobno, bid, did);
                    List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dtBok, "shiprefno");
                }
            return List_Result;

        }

        [WebMethod]
        public static List<string> GETCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_MasterCustomer = new DataAccess.Masters.MasterCustomer();
            dt = obj_MasterCustomer.GetLikeCustomer(prefix, "P");
            List_Result = Utility.Fn_DatatableToList(dt, "customername", "customerid", "customer");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GETShipbill(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataAccess.ForwardingExports.ShippingBill obj_shipbill = new DataAccess.ForwardingExports.ShippingBill();
            dt = obj_shipbill.GetLikeShipBill(prefix, bid, did);
            //List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dt, "sbno");   
            List_Result = Utility.Fn_DatatableToList_Text(dt, "sbno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> Getpackage(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPackages obj_mpackage = new DataAccess.Masters.MasterPackages();
            dt = obj_mpackage.GetLikepackage(prefix);
            //List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dt, "descn");
            List_Result = Utility.Fn_TableToList(dt, "descn", "packageid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> Getexporter(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterCustomer obj_mcustomer = new DataAccess.Masters.MasterCustomer();
            dt = obj_mcustomer.GetLikeIndianCustomer(prefix);
            List_Result = Utility.Fn_TableToList(dt, "customer", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> Getportname(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_portname = new DataAccess.Masters.MasterPort();
            dt = obj_portname.GetLikePort(prefix);
            List_Result = Utility.Fn_TableToList(dt, "portname", "portid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> Getmastervessel(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterVessel obj_mastervessel = new DataAccess.Masters.MasterVessel();
            dt = obj_mastervessel.GetLikeVessel(prefix);
            List_Result = Utility.Fn_TableToList(dt, "vesselname", "vesselid");
            return List_Result;
        }

        //[WebMethod]
        //public static List<string> GetCustmail(string prefix)
        //{
        //    List<string> List_Result = new List<string>();
        //    DataTable dt = new DataTable();
        //    DataAccess.ForwardingExports.StuffingConfirmation obj_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
        //    dt = obj_stuff.GetLikeCustExporMailID(prefix);
        //    List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dt, "mailid");
        //    return List_Result;
        //}

        [WebMethod]
        public static List<string> Getintermail(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.ForwardingExports.StuffingConfirmation obj_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
            dt = obj_stuff.GetLikeEmpMailID(prefix);
            List_Result = Utility.Fn_TableToList(prefix.ToUpper(), dt, "offmailid");
            return List_Result;
        }


        public void loadgrid_job()
        {
            DataTable dt = new DataTable();
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                dt = FEJobobj.GetJobNoList(bid, did);

                if (dt.Rows.Count > 0)
                {
                    Grdjob.DataSource = dt;
                    Grdjob.DataBind();
                    //btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                    ViewState["Job"] = dt;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('job no is empty');", true);
                    //EmptyGridShow();
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }


        }
        private void EmptyGridShow()
        {
            DataTable dtempty = new DataTable();
            //DataRow dr;

            dtempty.Columns.Add("jobno");
            dtempty.Columns.Add("vessel");
            dtempty.Columns.Add("voyage");
            dtempty.Columns.Add("mblno");
            dtempty.Columns.Add("etd");
            dtempty.Columns.Add("sd");
            dtempty.Columns.Add("eta");
            dtempty.Columns.Add("mlo");
            dtempty.Rows.Add(dtempty.NewRow());
            dtempty.Rows.Add(dtempty.NewRow());
            dtempty.Rows.Add(dtempty.NewRow());
            dtempty.Rows.Add(dtempty.NewRow());
            dtempty.Rows.Add(dtempty.NewRow());
            Grdjob.RowStyle.Width = 20;
            Grdjob.DataSource = dtempty;
            Grdjob.DataBind();
            int totalcolums = Grdjob.Rows[0].Cells.Count;
            Grdjob.Rows[0].Cells.Clear();
            Grdjob.Rows[0].Cells.Add(new TableCell());
            Grdjob.Rows[0].Cells[0].ColumnSpan = totalcolums;
            Grdjob.Rows[0].Cells[0].Text = "No Data Found";
        }
        public void loadgrid_booking()
        {
            DataTable dt = new DataTable();
            try
            {
                trantype = Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());

                //if(jobno==0)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sailing Confirmation Booking", "alertify.alert('Booking is empty');", true);
                //}
                lbl_head.Text = Request.QueryString["type"].ToString();
                string Sname = lbl_head.Text;

                if (Sname == "Stuffing Confirmation")
                {
                    //jobno = Convert.ToInt32(txt_job.Text.ToString());
                   // dt = bookingobj.GetBookingPending(trantype, bid);
                    jobno = Convert.ToInt32(txt_job.Text.ToString());
                    dt = bookingobj.SPSelBookingPendingWjobdetails(bid, trantype, Convert.ToInt16(Session["LoginDivisionid"].ToString()), jobno);
                    //GrdBooking.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {

                        if (txt_job.Text != "")
                        {
                            this.programmaticModalPopup.Show();
                            GrdBooking.DataSource = dt;
                            GrdBooking.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Jobno is empty');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Booking is empty');", true);
                        return;
                    }
                }

                if (Sname == "Sailing Confirmation")
                {
                    if (txt_job.Text != "")
                    {
                        jobno = Convert.ToInt32(txt_job.Text.ToString());
                        dt = bookingobj.GetBookingPendingWJobNo(trantype, jobno, bid);
                        //GrdBooking.DataSource = dt;

                        if (dt.Rows.Count > 0)
                        {

                            this.programmaticModalPopup.Show();
                            GrdBooking.DataSource = dt;
                            GrdBooking.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sailing Confirmation Booking", "alertify.alert('Booking is empty');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sailing Confirmation Booking", "alertify.alert('Jobno is empty');", true);
                        return;
                    }


                }
                if (Sname == "Transhipment Confirmation")
                {
                    if (txt_job.Text != "")
                    {
                        jobno = Convert.ToInt32(txt_job.Text.ToString());
                        dt = bookingobj.GetBookingPendingWJobNo(trantype, jobno, bid);
                        //GrdBooking.DataSource = dt;
                        if (dt.Rows.Count > 0)
                        {

                            this.programmaticModalPopup.Show();
                            GrdBooking.DataSource = dt;
                            GrdBooking.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transhipment Confirmation", "alertify.alert('Booking is empty');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Transhipment Confirmation", "alertify.alert('Jobno is empty');", true);
                        return;
                    }


                }
                if (Sname != "Stuffing Confirmation" & Sname != "Sailing Confirmation" & Sname != "Transhipment Confirmation")
                {
                    if (txt_job.Text != "")
                    {
                        jobno = Convert.ToInt32(txt_job.Text.ToString());
                        dt = bookingobj.GetBookingPendingWJobNo(trantype, jobno, bid);
                        if (dt.Rows.Count > 0)
                        {

                            this.programmaticModalPopup.Show();
                            GrdBooking.DataSource = dt;
                            GrdBooking.DataBind();
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking is empty');", true);
                            return;
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Jobno is empty');", true);
                        return;
                    }
                }
                //btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                if(dt.Rows.Count > 0)
                {
                    ViewState["Booking"] = dt;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }
        protected void lnk_job_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                dt = FEJobobj.GetJobNoList(bid, did);

                if (dt.Rows.Count > 0)
                {
                    this.programmaticModalPopup1.Show();
                    loadgrid_job();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void Grdjob_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblVesselName = (Label)e.Row.FindControl("VesselName");
                string tooltip = lblVesselName.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblVoyage = (Label)e.Row.FindControl("Voyage");
                string tooltip1 = lblVoyage.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip1);

                Label lblMBL = (Label)e.Row.FindControl("MBL");
                string tooltip2 = lblMBL.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip2);

                Label lblDestination = (Label)e.Row.FindControl("Destination");
                string tooltip3 = lblDestination.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip3);

                Label lblMLO = (Label)e.Row.FindControl("MLO");
                string tooltip4 = lblMLO.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip4);
            }

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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grdjob, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grdjob_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index, i;
            intjobopn = 0;
            DataTable dtdetails = new DataTable();
            DataTable dtchkfordat = new DataTable();
            try
            {
                if (Grdjob.Rows.Count > 0)
                {
                    index = Grdjob.SelectedRow.RowIndex;
                    int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                    int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                    txt_job.Text = ((Label)Grdjob.Rows[index].Cells[0].FindControl("Job")).Text;
                    //Grdjob.Rows[index].Cells[0].Text;
                    Session["jobno"] = txt_job.Text;
                    intjobopn = Convert.ToInt32(txt_job.Text);
                    dtdetails = FEJobobj.GetFEJobInfo(intjobopn, bid, did);
                    dtchkfordat = FEJobobj.GetfeventDates(intjobopn, bid, did);
                    txt_agent.Text = "";

                    intagentid = Convert.ToInt32(Grdjob.Rows[index].Cells[8].Text);
                    
                    hd_customer.Value = intagentid.ToString();
                    txt_agent.Text = customerobj.GetCustomername(intagentid);
                    GetJobInfo();
                }
                //containeruncheck();
               // vesselclear();
                sbclear();
                EmptyGridSB();
                EmptyGridVessel();
                EmptyGridmail();
                EmptyGridIntermail();
                //txt_agent.Text = "";
                //btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }




        protected void lnkBooking_Click(object sender, EventArgs e)
        {
            loadgrid_booking();
            //btn_back.Text = "Cancel";
            btn_back.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";
            //this.programmaticModalPopup.Show();
        }

        protected void GrdBooking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCustomer = (Label)e.Row.FindControl("Customer");
                string tooltip = lblCustomer.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip);

                Label lblPOL = (Label)e.Row.FindControl("POL");
                string tooltip1 = lblPOL.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip1);

                Label lblPOD = (Label)e.Row.FindControl("POD");
                string tooltip2 = lblPOD.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip2);
            }
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdBooking, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            try
            {
                trantype = Session["StrTranType"].ToString();
                DataTable dtBooking = new DataTable();
                if (GrdBooking.Rows.Count > 0)
                {
                    index = GrdBooking.SelectedRow.RowIndex;
                    int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                    int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                    txt_book.Text = ((Label)GrdBooking.Rows[index].Cells[0].FindControl("Booking")).Text;
                    //GrdBooking.Rows[index].Cells[0].Text;
                   btn_send.Text = "Send";
                    btn_send.ToolTip = "Send";
                    btn_send1.Attributes["class"] = "btn ico-send-mail";
                    dtBooking = bookingobj.GetBookingDetails(txt_book.Text.ToString(), trantype, bid);
                    if (dtBooking.Rows.Count > 0)
                    {
                        fd = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["fd"]));
                    }
                    if (txt_job.Text != "")
                    {
                        dtBooking = bookingobj.GetBookingDetails(txt_book.Text.ToString(), trantype, bid);
                        if (dtBooking.Rows.Count > 0)
                        {
                            fd = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["fd"]));
                            hid_fd.Value = fd;
                            por = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["por"]));
                            hid_Por.Value = por;
                            pol = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["pol"]));
                            hid_pol.Value = pol;
                            pod = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["pod"]));
                            hid_pod.Value = pod;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(GrdBooking, typeof(GridView), "Valid", "alertify.alert('Please Enter the Valid Bookingno');", true);
                            txt_book.Focus();
                            return;
                        }
                        GetStuffDetails();
                    }
                }
                if (txt_book.Text != "")
                {
                    int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                    int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                    intcust = bookingobj.GetCustID4mBookingno(txt_book.Text.ToString(), trantype, bid, did);
                    hf_intcust.Value = intcust.ToString();
                    for (int i = 0; i <= Grd_mail.Rows.Count - 1; i++)
                    {
                        EmptyGridmail();
                        ViewState["CurrentData"] = null;
                    }
                    DataTable dtmail = customerobj.SelMCMailID(intcust);
                    if (dtmail.Rows.Count >0)
                    {
                        Grd_mail.DataSource = dtmail;
                        Grd_mail.DataBind();
                        ViewState["CurrentData"] = dtmail;
                    }
                }
                //btn_back.Text = "Cancel";
                btn_back.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";
                txt_book.Enabled = false;
                txt_sb.Enabled = true;
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        private void GetStuffDetails()
        {
            DataTable dt = new DataTable();
            DataTable dtdetails = new DataTable();
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                string strdodate;
                jobno = Convert.ToInt32(txt_job.Text);

                dt = STufobj.GetSBDetails(jobno, txt_book.Text, bid, did);
                if (dt.Rows.Count > 0)
                {
                    txt_book.Text = dt.Rows[0]["shiprefno"].ToString();

                    //BHUVANA


                    //if (dt.Rows[0]["agent"].ToString() != "")
                    //{
                    //    txt_agent.Text = dt.Rows[0]["agent"].ToString();
                    //}


                    // txt_agent.Text = dt.Rows[0]["agent"].ToString();
                    if (dt.Rows[0]["agentid"].ToString() != "")
                    {
                        intagentid = Convert.ToInt32(dt.Rows[0]["agentid"].ToString());
                        hd_exporter.Value = intagentid.ToString();
                    }

                    dt = STufobj.GetSBDetails(jobno, txt_book.Text, bid, did);
                    //dt.DefaultView.RowFilter = "sbno='" + txt_sb.Text.Trim() + "'";

                    Grd_sb.DataSource = dt;
                    Grd_sb.DataBind();
                    txt_book.Enabled = false;
                    //txt_sb.Enabled = false;
                }
                stuffInland = "";
                loadingInland = "";
                TCInland = "";
                dt = STufobj.GetFEInlandMovement(txt_book.Text, bid, did);
                if (dt.Rows.Count > 0)
                {
                    stuffInland = dt.Rows[0][0].ToString();
                    loadingInland = dt.Rows[0][1].ToString();
                    TCInland = dt.Rows[0][2].ToString();
                }
                lbl_head.Text = Request.QueryString["type"].ToString();
                Sname = lbl_head.Text;

                if (Sname == "Stuffing Confirmation")
                {
                    dt = STufobj.GetMVDetails(jobno, txt_book.Text, bid, did);
                    if (dt.Rows.Count > 0)
                    {
                        
                        Grd_vessel.DataSource = dt;
                        Grd_vessel.DataBind();
                    }
                    txt_podmove.Text = stuffInland;
                }
                else
                {
                    if (Sname == "Sailing Confirmation")
                    {
                        dt = STufobj.GetMVDetails4FELCBooking(jobno, txt_book.Text, bid, did);
                        if (dt.Rows.Count > 0)
                        {
                           
                            Grd_vessel.DataSource = dt;
                            Grd_vessel.DataBind();
                        }
                        txt_podmove.Text = loadingInland;
                    }

                    else
                    {
                        if (Sname == "D O Confirmation")
                        {
                            txt_podmove.Text = TCInland;
                            dt = STufobj.GetMVDetails4FETCBooking(jobno, txt_book.Text, bid, did);
                            if (dt.Rows.Count > 0)
                            {
                               
                                Grd_vessel.DataSource = dt;
                                Grd_vessel.DataBind();
                            }
                            else
                            {
                                txt_podmove.Text = loadingInland;
                                dt = STufobj.GetMVDetails4FETCBooking(jobno, txt_book.Text, bid, did);
                                if (dt.Rows.Count > 0)
                                {
                                    
                                    Grd_vessel.DataSource = dt;
                                    Grd_vessel.DataBind();
                                }
                                else
                                {
                                    txt_podmove.Text = "stuffInland";
                                    dt = STufobj.GetMVDetails4FETCBooking(jobno, txt_book.Text, bid, did);
                                    if (dt.Rows.Count > 0)
                                    {
                                     
                                        Grd_vessel.DataSource = dt;
                                        Grd_vessel.DataBind();
                                    }
                                }
                              
                                blno = STufobj.GetBLNofromBookNo(txt_book.Text, "FE", bid, did);
                                dtdetails = LoadConfirm.GetLoadingConfirmationDet(blno, "DO", bid, did);
                                if (dtdetails.Rows.Count != 0)
                                {
                                    if (dtdetails.Rows[0]["doissuedon"].ToString() != "")
                                    {
                                        DateTime dodate = Convert.ToDateTime(dtdetails.Rows[0]["doissuedon"].ToString());
                                        txt_dodate.Text = Utility.fn_ConvertDate(dodate.ToString());
                                        string agentnamemail = dtdetails.Rows[0]["agent"].ToString();
                                        txt_date.Text = Utility.fn_ConvertDate(dodate.ToString());
                                    }
                                    else
                                    {
                                        txt_dodate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                                    }
                                }
                                else
                                {
                                    txt_date.Enabled = false;
                                    strdodate = "";
                                    txt_date.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                                }
                            }

                        }
                        else
                        {

                            if (Sname == "Transhipment Confirmation")
                            {
                                dt = STufobj.GetMVDetails4FETCBooking(jobno, txt_book.Text, bid, did);
                                if (dt.Rows.Count > 0)
                                {

                                    Grd_vessel.DataSource = dt;
                                    Grd_vessel.DataBind();
                                }
                                txt_podmove.Text = TCInland;
                            }
                        }
                    }
                }

                DivName = Session["LoginDivisionName"].ToString();
                strdiv = "FIL";
                //if (DivName.Substring(0, 3) == "Syn")
                //{
                //    strdiv = "SCM";
                //}
                //else if (DivName.Substring(0, 3) == "M+R")
                //{
                //    strdiv = "M+R";
                //}
                //else
                //{
                //    strdiv = "IFS";
                //}
                //if()
                //{

                //}1
                txt_msub.Text = "";
                txt_pormove.Text = "";
                if (Sname == "Stuffing Confirmation")
                {
                    dt = STufobj.SelStuffStatus("S", txt_book.Text, bid, did);
                    if (dt.Rows.Count > 0)
                    {
                        txt_pormove.Text = dt.Rows[0][0].ToString();
                        txt_msub.Text = dt.Rows[0][1].ToString();
                    }
                }
                else
                {
                    if (Sname == "Sailing Confirmation")
                    {
                        dt = STufobj.SelStuffStatus("L", txt_book.Text, bid, did);
                        if (dt.Rows.Count > 0)
                        {
                            txt_pormove.Text = dt.Rows[0][0].ToString();
                            txt_msub.Text = dt.Rows[0][1].ToString();
                        }
                    }
                    else
                    {
                        if (Sname == "D O Confirmation")
                        {
                            dt = STufobj.SelStuffStatus("D", txt_book.Text, bid, did);
                            if (dt.Rows.Count > 0)
                            {
                                txt_pormove.Text = dt.Rows[0][0].ToString();
                                txt_msub.Text = dt.Rows[0][1].ToString();
                            }
                        }
                        else
                        {
                            if (Sname == "Transhipment Confirmation")
                            {
                                dt = STufobj.SelStuffStatus("T", txt_book.Text, bid, did);
                                if (dt.Rows.Count > 0)
                                {
                                    txt_pormove.Text = dt.Rows[0][0].ToString();
                                    txt_msub.Text = dt.Rows[0][1].ToString();
                                }
                            }
                        }
                    }
                }

                txt_next.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txtremark.Text = "";
                dt = FEJobobj.GetFEEventTracking(bid, txt_book.Text, "S", did);
                if (dt.Rows.Count > 0)
                {
                    txt_next.Text = dt.Rows[0]["nextfollowup"].ToString();
                    if (txt_next.Text != "")
                    {
                        txt_next.Text = Convert.ToDateTime(dt.Rows[0]["nextfollowup"].ToString()).ToString("dd/MM/yyyy");
                    }
                }
                else
                {
                    txt_next.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                    txtremark.Text = "";
                }
                DataSet Ds = new DataSet();
                Ds = STufobj.SelCRMMailids(jobno, txt_book.Text, bid, did);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    EmptyGridmail();
                    //for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
                    //{

                       
                    //}
                    DataTable dtnew = new DataTable();
                    dtnew = Ds.Tables[0];
                    Grd_mail.DataSource = dtnew;
                    Grd_mail.DataBind();
                    ViewState["CurrentData"] = dtnew;
                }
                else
                {
                    ViewState["CurrentData"] = null;
                }
                if (Ds.Tables[1].Rows.Count > 0)
                {
                    EmptyGridIntermail();
                    //for (int j = 0; j <= Ds.Tables[1].Rows.Count - 1; j++)
                    //{
                    //    Ds.Tables[0].Rows[j][0].ToString();
                        
                    //}
                    DataTable dtnew = new DataTable();
                    dtnew = Ds.Tables[1];
                    Grd_intermail.DataSource = dtnew;
                    Grd_intermail.DataBind();
                    ViewState["CurrentDataMail"] = dtnew;
                }
                else
                {
                    ViewState["CurrentDataMail"] = null;
                }
                if (txt_msub.Text == "")
                {
                    if (Sname == "Stuffing Confirmation")
                    {
                        txt_msub.Text = "Stuffing Confirmation Booking # : " + txt_book.Text + " / " + strdiv + " " + txt_job.Text + " / " + fd;
                    }

                    if (Sname == "Sailing Confirmation")
                    {
                        txt_msub.Text = "Sailing Confirmation Booking # : " + txt_book.Text + " / " + strdiv + " " + txt_job.Text + " / " + fd;
                    }

                    if (Sname == "D O Confirmation")
                    {
                        txt_msub.Text = "DO Confirmation # : " + txt_book.Text + " / " + strdiv + " " + txt_job.Text + " / " + fd;
                    }

                    if (Sname == "Transhipment Confirmation")
                    {
                        txt_msub.Text = "Transhipment Confirmation Booking # : " + txt_book.Text + " / " + strdiv + " " + txt_job.Text + " / " + fd;
                    }

                    txt_agent.Focus();
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            if (btn_back.ToolTip == "Cancel")
            {
                JobInput.Text = "";
                chklst.Items.Clear();
                jobclear();
                sbclear();
                vesselclear();
                //EmptyGridSB();
                //EmptyGridVessel();
                txt_next.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
                txt_news.Text = "";
                txt_date.Text = "";
                txt_customer.Text = "";
                EmptyGridSB();
                EmptyGridVessel();
                EmptyGridIntermail();
                EmptyGridmail();
                txt_intermail.Text = "";
                txt_pormove.Text = "";
                //txt_podmove.Text = "";
                txt_msub.Text = "";
                chklst.Items.Clear();
                Sname = lbl_head.Text;
                if (Sname == "D O Confirmation")
                {
                    btn_save.Enabled = false;
                    btn_add.Enabled = false;
                    btn_save.ForeColor = System.Drawing.Color.Gray;
                    btn_add.ForeColor = System.Drawing.Color.Gray;
                }
                btn_add.Text = "Add";
                btn_add.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn ico-add";
                //btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                //btn_back.Text = "Back";
                btn_back.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                txt_sb.Enabled = false;
                UserRights();
            }
            else
            {
             //   this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "CS")
                    {
                        Response.Redirect("../Home/OECSHome.aspx");
                    }
                    else if (Session["home"].ToString() == "OPS&DOC")
                    {
                        Response.Redirect("../Home/OECSHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }
        private void jobclear()
        {
            txt_job.Text = "";
            txt_vessel.Text = "";
            txt_pol.Text = "";
            txt_etd.Text = "";
            txt_pod.Text = "";
            txt_eta.Text = "";
            txt_book.Text = "";
            txt_agent.Text = "";
            txt_book.Enabled = true;
            txt_podmove.Text = "";
            txt_next.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txt_dodate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txtremark.Text = "";

        }
        private void sbclear()
        {            
            txt_sb.Text = "";
            txt_sbdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txt_dodate.Enabled = false;
            txt_dodate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());

            txt_pkgs.Text = "";
            txt_pkgtype.Text = "";
            txt_weight.Text = "";
            txt_volume.Text = "";
            txt_exporter.Text = "";
            txt_dest.Text = "";
            if (chk_invoice.Checked == true)
            {
                chk_invoice.Checked = false;
            }
            txt_remarks.Text = "";
            txt_msub.Text = "";
        }
        private void vesselclear()
        {
            txt_mvessel.Text = "";
            txt_voy.Text = "";
            txtpol.Text = "";
            txtpod.Text = "";
            txteta.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txtetd.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txt_dodate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            txtremarks.Text = "";
            //chklst.Items.Clear();
        }

        private void EmptyGridSB()
        {
            DataTable dtempty = new DataTable();
            dtempty.Columns.Add("sbno");
            dtempty.Columns.Add("sbdate");
            dtempty.Columns.Add("exporter");
            dtempty.Columns.Add("pld");
            dtempty.Columns.Add("noofpkg");
            dtempty.Columns.Add("descn");
            dtempty.Columns.Add("grosswt");
            dtempty.Columns.Add("volume");
            dtempty.Columns.Add("agent");
            dtempty.Columns.Add("remarks");
            dtempty.Columns.Add("invpl");
            dtempty.Columns.Add("shiprefno");
            dtempty.Columns.Add("agentid");
            dtempty.Rows.Add(dtempty.NewRow());
            //Grd_sb.RowStyle.Width = 20;
            Grd_sb.DataSource = dtempty;
            Grd_sb.DataBind();
            Grd_sb.Rows[0].Visible = false;
            //int totalcolums = Grd_sb.Rows[0].Cells.Count;
            //Grd_sb.Rows[0].Cells.Clear();
            //Grd_sb.Rows[0].Cells.Add(new TableCell());
            //Grd_sb.Rows[0].Cells[0].ColumnSpan = totalcolums;

        }
        private void EmptyGridVessel()
        {
            DataTable dtempty = new DataTable();
            dtempty.Columns.Add("vessel");
            dtempty.Columns.Add("pol");
            dtempty.Columns.Add("etd");
            dtempty.Columns.Add("pod");
            dtempty.Columns.Add("eta");
            dtempty.Columns.Add("remarks");
            dtempty.Columns.Add("vsl");
            dtempty.Columns.Add("voy");
            dtempty.Rows.Add(dtempty.NewRow());
            //Grd_vessel.RowStyle.Width = 15;
            Grd_vessel.DataSource = dtempty;
            Grd_vessel.DataBind();
            Grd_vessel.Rows[0].Visible = false;
        }

        private void EmptyGridmail()
        {
            DataTable dtempty = new DataTable();
            //dtempty.Columns.Add("mailid");
            //dtempty.Rows.Add(dtempty.NewRow());
            Grd_mail.DataSource = dtempty;
            Grd_mail.DataBind();
            //Grd_mail.Rows[0].Visible = false;
        }

        private void EmptyGridIntermail()
        {
            DataTable dtempty = new DataTable();
            //dtempty.Columns.Add("offmailid");
            //dtempty.Rows.Add(dtempty.NewRow());
            Grd_intermail.DataSource = dtempty;
            Grd_intermail.DataBind();
            //Grd_intermail.Rows[0].Visible = false;
        }

        private void chklst_clear()
        {
            if (chklst.Visible == true)
            {
                chklst.Visible = false;
            }
        }

        public void CheckVesselName()
        {
            hd_mastervessel.Value = vesselobj.GetVesselid(txt_mvessel.Text).ToString();
            if (hd_mastervessel.Value == "" || hd_mastervessel.Value=="0"|| txt_mvessel.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Select Correct Vessel Name');", true);
                blrr = true;
                return;
            }
            txt_mvessel.Focus();
        }

        public void CheckPortName()
        {
            hd_portname.Value = portobj.GetNPortid(txtpol.Text).ToString();
            if (hd_portname.Value == "" || hd_portname.Value=="0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Select Correct Port Of Loading');", true);
                blrr = true;
                return;
            }
            txt_pol.Focus();
        }

        public void CheckPortName1()
        {
            hd_port.Value = portobj.GetNPortid(txtpod.Text).ToString();
            if (hd_port.Value == "" || hd_port.Value=="0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Select Correct Port Of Delevery');", true);
                blrr = true;
                return;
            }
            txtpod.Focus();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            


            CheckVesselName();
            CheckPortName();
            CheckPortName1();
            if(blrr==true)
            {
                return;
            }
            DataTable dt = new DataTable();
            DataTable dtST = new DataTable();
            try
            {




                if (txtetd.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Must Be Enter ETD');", true);
                    txteta.Focus();
                    return;
                }

                if (txteta.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Must Be Enter ETA');", true);
                    txtetd.Focus();
                    return;
                }
                if (txt_voy.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Must Be Enter Voyage');", true);
                    txtetd.Focus();
                    return;
                }



                dtFromSession = Session["Bookingno"] as DataTable;
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                string Vid = hd_mastervessel.Value.ToString();
                vesselid = Convert.ToInt32(Vid);
                
                jobno = Convert.ToInt32(hid_jobno.Value.ToString());
                polid = Convert.ToInt32(hd_portname.Value.ToString());
                dtetd = Convert.ToDateTime(Utility.fn_ConvertDate(txtetd.Text));
                podid = Convert.ToInt32(hd_port.Value.ToString());
                dteta = Convert.ToDateTime(Utility.fn_ConvertDate(txteta.Text));
                //lbl_head.Text = Request.QueryString["type"].ToString();
                string Bookingno=ddl_Vessal.SelectedItem.Text;
                Sname = lbl_head.Text;
                DateTime etdDate = DateTime.ParseExact(txtetd.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime etaDate = DateTime.ParseExact(txteta.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime eta_Date = DateTime.ParseExact(txt_eta.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);



                if (etdDate > etaDate)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('ETA Date Must Be Greater Than ETD');", true);
                    txteta.Focus();
                    return;
                }

                if (eta_Date > etdDate)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('ETD Date Must Be Greater Than F.Vessel ETA');", true);
                    txtetd.Focus();
                    return;
                }


                if (btnadd.ToolTip == "Add")
                {




                    STufobj.InsFETCBooking(jobno, Bookingno, vesselid, txt_voy.Text, polid, dtetd, podid, dteta, " ", bid, empid, did);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Details Saved');", true);
                }
                else {


                    STufobj.updateMotherveessel(jobno, Bookingno, vesselid, txt_voy.Text, polid, dtetd, podid, dteta, " ", bid, empid, did,Convert.ToInt32(hid_veselid.Value));
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Details Update sucessfully');", true);

                    btnadd.ToolTip = "Add";
                    btnadd.Attributes["class"] = "right-btn btn ico-add MT15";



                }

                    DataTable dt1 = new DataTable();
                    dt1=STufobj.GetMothervessaldts(jobno ,bid);

                    if (dt1.Rows.Count > 0)
                    {
                        txtpol.Enabled = true;

                        DataRow lastRow = dt1.Rows[dt1.Rows.Count - 1];

                        // Access the last value in the last row
                        object lastValue = lastRow["pod"];
                        object lastValue1 = lastRow["eta"];
                        // Replace "ColumnName" with the actual column name from which you want to get the value

                        // If the column contains a specific data type like string, you may cast the value accordingly
                        string lastStringValue = lastRow["pod"].ToString();
                        string lastStringValue1 = lastRow["eta"].ToString();
                        txtpol.Text = lastStringValue;
                        txtetd.Text = lastStringValue1;
                        txtpol.Enabled = false;



                        Grd_vessel.DataSource = dt1;
                        Grd_vessel.DataBind();
                    }
                    txt_voy.Text = "";
                    txt_mvessel.Text = "";
                    txtpod.Text = "";
                    txteta.Text = "";

                 


                    //STufobj.GetVesselDetails(jobno,b)

                        
                 
                    
                
                }
               
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }




        private void InsContainer()
        {
            string chkname;
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                jobno = Convert.ToInt32(txt_job.Text);
                ShippingBillobj.DelContainerDetails(jobno, txt_sb.Text, bid, did);
                for (int i = 0; i <= chklst.Items.Count - 1; i++)
                {
                    if (chklst.Items[i].Selected)
                    {
                        chkname = chklst.Items[i].ToString();
                        STufobj.InsSBContainers(jobno, txt_sb.Text, chkname, bid, did);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }
        private void containeruncheck()
        {
            try
            {
                for (int i = 0; i <= chklst.Items.Count - 1; i++)
                {
                    chklst.Items[i].Selected = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void checkdata1()
        {
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                if (txt_agent.Text == "")
                {
                    intagentid = 0;
                }
                else
                {
                    intagentid = customerobj.GetCustomerid(txt_agent.Text);
                    if (intagentid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_agent, typeof(TextBox), "Valid", "alertify.alert('INVALID Agent NAME');", true);
                        txt_agent.Text = "";
                        txt_agent.Focus();
                        int_back = 1;
                        return;
                    }
                }

                if (txt_exporter.Text == "")
                {
                    intshipperid = 0;
                }
                else
                {
                    intshipperid = customerobj.GetCustomerid(txt_exporter.Text);
                    if (intshipperid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_exporter, typeof(TextBox), "Valid", "alertify.alert('INVALID Exporter NAME');", true);
                        txt_exporter.Text = "";
                        txt_exporter.Focus();
                        int_back = 1;
                        return;
                    }
                }
                if(txt_dest.Text != "")
                {
                    custid = portobj.GetNPortid(txt_dest.Text);
                    if (custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_dest, typeof(TextBox), "Valid", "alertify.alert('INVALID DESTINATION NAME');", true);
                        txt_dest.Text = "";
                        txt_dest.Focus();
                        int_back = 1;
                        return;
                    }
                }
                if (txt_pol.Text != "")
                {
                    custid = portobj.GetNPortid(txt_pol.Text);
                    if (custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_pol, typeof(TextBox), "Valid", "alertify.alert('INVALID PORT OF LOADING');", true);
                        txt_pol.Text = "";
                        txt_pol.Focus();
                        int_back = 1;
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }


        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            DataTable dtdetails = new DataTable();
            DataTable dt = new DataTable();
            try
            {
                checkdata1();
                if(int_back == 1)
                {
                    return;
                }
                if (chk_invoice.Checked == true)
                {
                    invpl = 'y';
                }
                else
                {
                    invpl = 'N';
                }
                DataAccess.Masters.MasterPackages packobj = new DataAccess.Masters.MasterPackages();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                dtdetails = ShippingBillobj.GetShippingBill(txt_sb.Text, bid, did);
               

              //  intshipperid = Convert.ToInt32(dtdetails.Rows[0]["shipper"].ToString());
                //if ((dtdetails.Rows[0]["agent"])!= "")
                //{ 
                //intagentid = Convert.ToInt32(dtdetails.Rows[0]["agent"].ToString());
                //}
                //else
                //{
                    
                //}
                intagentid = Convert.ToInt32(hd_customer.Value);
                sbdate = Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_sbdate.Text));
                noofpkgs = Convert.ToInt32(txt_pkgs.Text);
              //  intPkgID = packageobj.GetNPackageid(txt_pkgtype.Text);
                //intshipperid = Convert.ToInt32(hd_exporter.Value);
                intpkgs = packobj.GetNPackageid(txt_pkgtype.Text);
                destid = portobj.GetNPortid(txt_dest.Text);
                grosswt = Convert.ToDouble(txt_weight.Text.ToString());
                jobno = Convert.ToInt32(txt_job.Text);
                lbl_head.Text = Request.QueryString["type"].ToString();
                string Sname = lbl_head.Text;
                //intpkgs = packobj.GetNPackageid(txt_pkgtype.Text);
                if (intpkgs == 0)
                {
                    ScriptManager.RegisterStartupScript(txt_pkgtype, typeof(TextBox), "Valid", "alertify.alert('INVALID PACKAGE TYPE');", true);
                    txt_pkgtype.Text = "";
                    txt_pkgtype.Focus();
                    return;
                }
                if (Sname == "Stuffing Confirmation")
                {
                    checkdata1();
                    if (btn_save.ToolTip == "Save")
                    {
                        Boolean sbexist = STufobj.CheckSBExistance(txt_sb.Text, bid, did);
                        if (sbexist == true)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Shipping BillNo Already Exists');", true);
                            txt_sb.Focus();
                            txt_sb.Text = "";
                            //txt_agent.Text = "";
                            txt_pkgs.Text = "";
                            txt_pkgtype.Text = "";
                            txt_weight.Text = "";
                            txt_volume.Text = "";
                            txt_exporter.Text = "";
                            txt_dest.Text = "";
                            txt_remarks.Text = "";
                            chk_invoice.Checked = false;
                            return;
                        }
                    }
                    int count = 0;
                    for (int i = 0; i <= chklst.Items.Count - 1; i++)
                    {
                        if (chklst.Items[i].Selected)
                        {
                            count = 1;
                        }


                    }
                    if (count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Select Atleast One Container');", true);
                        return;
                    }

                    count = 0;
                    if (btn_save.ToolTip == "Save")
                    {
                        STufobj.InsShippingBill(txt_book.Text, txt_sb.Text.ToUpper(), sbdate, noofpkgs, intpkgs, grosswt, txt_volume.Text, intshipperid, intagentid, destid, txt_remarks.Text, invpl, jobno, bid, empid, did);
                        FEJobobj.UpdateFEEventjobno(jobno, txt_book.Text, bid, did);
                        InsContainer();
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Details Saved');", true);
                        Logobj.InsLogDetail(empid, 191, 1, bid, "FESD" + "" + txt_sb.Text);
                        containeruncheck();
                    }
                    else
                    {
                        STufobj.UpdShippingBill(txt_sb.Text.ToUpper(), sbdate, noofpkgs, intpkgs, grosswt, txt_volume.Text, intshipperid, intagentid, destid, txt_remarks.Text, invpl, jobno, bid, did);
                        txt_book.Enabled = true;
                        //btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        InsContainer();
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Details Updated');", true);
                        Logobj.InsLogDetail(empid, 191,2, bid, "FESD" + "" + txt_sb.Text);
                        containeruncheck();
                    }
                    dt = STufobj.GetSBDetails(jobno, txt_book.Text, bid, did);
                    if (dt.Rows.Count > 0)
                    {
                        txt_book.Text = dt.Rows[0]["shiprefno"].ToString();
                        txt_book.Enabled = true;
                        dt = STufobj.GetSBDetails(jobno, txt_book.Text, bid, did);
                        Grd_sb.DataSource = dt;
                        Grd_sb.DataBind();
                    }
                    sbclear();
                    txt_sb.Focus();
                }
                else
                {
                    if (Sname == "Sailing Confirmation")
                    {
                        //checkdata1();
                        if (btn_save.ToolTip == "Save")
                        {
                            Boolean sbexist = STufobj.CheckSBExistance(txt_sb.Text.ToUpper(), bid, did);
                            if (sbexist == true)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Shipping BillNo Already Exists');", true);
                                txt_sb.Focus();
                                txt_sb.Text = "";
                                txt_agent.Text = "";
                                txt_pkgs.Text = "";
                                txt_pkgtype.Text = "";
                                txt_weight.Text = "";
                                txt_volume.Text = "";
                                txt_exporter.Text = "";
                                txt_dest.Text = "";
                                txt_remarks.Text = "";
                                chk_invoice.Checked = false;
                                return;
                            }
                        }
                        int count = 0;
                        for (int i = 0; i <= chklst.Items.Count - 1; i++)
                        {
                            if (chklst.Items[i].Selected)
                            {
                                count = 1;
                            }
                        }
                        if (count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sailing Confirmation Booking", "alertify.alert('Select Atleast One Container');", true);
                            return;
                        }
                        count = 0;
                        if (btn_save.ToolTip == "Save")
                        {
                            STufobj.InsShippingBill(txt_book.Text, txt_sb.Text.ToUpper(), sbdate, noofpkgs, intpkgs, grosswt, txt_volume.Text, intshipperid, intagentid, destid, txt_remarks.Text, invpl, jobno, bid, empid, did);
                            InsContainer();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sailing Confirmation Booking", "alertify.alert('Details Saved');", true);
                            Logobj.InsLogDetail(empid, 192, 1, bid, "FESD" + "" + txt_sb.Text);
                            containeruncheck();
                        }
                        else
                        {
                            STufobj.UpdShippingBill(txt_sb.Text.ToUpper(), sbdate, noofpkgs, intpkgs, grosswt, txt_volume.Text, intshipperid, intagentid, destid, txt_remarks.Text, invpl, jobno, bid, did);
                            txt_sb.Enabled = true;
                            //btn_save.Text = "Save";
                            btn_save.ToolTip = "Save";
                            btn_save1.Attributes["class"] = "btn ico-save";
                            InsContainer();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sailing Confirmation Booking", "alertify.alert('Details Updated');", true);
                            Logobj.InsLogDetail(empid, 192, 2, bid, "FESD" + "" + txt_sb.Text);
                            containeruncheck();
                        }
                        dt = STufobj.GetSBDetails(jobno, txt_book.Text, bid, did);
                        if (dt.Rows.Count > 0)
                        {
                            txt_book.Text = dt.Rows[0]["shiprefno"].ToString();
                            txt_book.Enabled = true;
                            dt = STufobj.GetSBDetails(jobno, txt_book.Text, bid, did);
                            Grd_sb.DataSource = dt;
                            Grd_sb.DataBind();
                        }
                        sbclear();
                    }
                }
                UserRights();
            }
            catch (Exception ex)
            {
                //string message = ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('" + message + "');", true);


                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }
        //.....text changed
        protected void txt_book_TextChanged(object sender, EventArgs e)
        {
            DataTable dtBooking = new DataTable();
            DataTable dtmail = new DataTable();
            try
            {
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                if (txt_book.Text != "" && txt_job.Text != "")
                {
                    txt_book.Text = txt_book.Text.ToUpper();

                    dtBooking = bookingobj.GetBookingDetails(txt_book.Text, trantype, bid);
                    if (dtBooking.Rows.Count > 0)
                    {
                        fd = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["fd"]));
                        hid_fd.Value = fd;
                        por = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["por"]));
                        hid_Por.Value = por;
                        pol = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["pol"]));
                        hid_pol.Value = pol;
                        pod = portobj.GetPortname(Convert.ToInt32(dtBooking.Rows[0]["pod"]));
                        hid_pod.Value = pod;
                        GetStuffDetails();
                        txt_sb.Enabled = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Enter the Valid Bookingno');", true);
                        txt_book.Focus();
                        txt_book.Text = "";
                        return;
                    }
                }


               if (txt_book.Text != "")
                {
                    intcust = bookingobj.GetCustID4mBookingno(txt_book.Text.ToString(), trantype, bid, did);
                    hf_intcust.Value = intcust.ToString();
                    if (dtmail.Rows.Count > 0)
                    {
                        //Grd_mail.DataSource = null;
                        //Grd_mail.DataBind();
                        EmptyGridmail();
                        ViewState["CurrentData"] = null;
                    }
                    dtmail = customerobj.SelMCMailID(intcust);
                    if (dtmail.Rows.Count >0)
                    {
                        
                        Grd_mail.DataSource = dtmail;
                        Grd_mail.DataBind();
                        ViewState["CurrentData"] = dtmail;
                    }
                    else
                    {
                        ViewState["CurrentData"] = null;
                    }
                    
                }
                

                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void txt_agent_TextChanged(object sender, EventArgs e)
        {

            if (txt_agent.Text != "")
            {
                customerid = customerobj.GetCustomerid(txt_agent.Text);
                if (customerid == 0)
                {
                    //txt_agent.Text
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Select Correct Customer Name');", true);
                    txt_agent.Text = "";
                    txt_agent.Focus();
                    return;
                }
            }
            else
            {
                txt_sb.Focus();
            }

        }

        protected void btn_mail_Click(object sender, EventArgs e)
        {
            try
            {
                int count1 = 0;
                if (txt_customer.Text.Trim().ToUpper() != "")
                {

                    string[] strTemptobcc = txt_customer.Text.Split(';');

                    for (int i = 0; i < strTemptobcc.Length; i++)
                    {
                        if (IsValidEmailId(strTemptobcc.ToString().Trim().ToUpper()))
                        {
                            if (ViewState["CurrentData"] != null)
                            {
                                DataTable dt = (DataTable)ViewState["CurrentData"];
                                int count = dt.Rows.Count;
                                BindGrid(count, txt_customer.Text.Trim().ToUpper());
                            }
                            else
                            {
                                BindGrid(1, strTemptobcc.ToString().Trim().ToUpper());
                            }
                            
                            txt_customer.Focus();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('InValid Email Format');", true);
                            txt_customer.Text = "";
                            txt_customer.Focus();
                            return;


                        }
                    }
                    txt_customer.Text = "";
                    txt_customer.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
                    txt_customer.Text = "";
                    txt_customer.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }


        }

        private void BindGrid(int rowcount, string txtname)
        {
            int i=0;
            DataTable dt = new DataTable();
            DataRow dr;
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("mailid", typeof(String)));
                //dt.Columns.Add(new System.Data.DataColumn("customername", typeof(String)));

                if (ViewState["CurrentData"] != null)
                {

                    ImageButton btndelete = new ImageButton();
                    foreach (GridViewRow row in Grd_mail.Rows)
                    {

                        btndelete = (ImageButton)row.FindControl("ImageButton2");
                        btndelete.Visible = true;

                    }
                    for ( i = 0; i < rowcount + 1; i++)
                    {
                        dt = (DataTable)ViewState["CurrentData"];

                        if (dt.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dt);
                            dv.RowFilter = "mailid = '" + txtname.ToString().ToUpper().Trim() + "'";
                            if (dv.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail id Already Exist');", true);
                                return;
                            }
                            
                           // dr = dt.NewRow();
                           // dr[0] = dt.Rows[0][0].ToString();
                        }
                       
                    }

                    dt.Rows.Add();
                    dt.Rows[i-1]["mailid"] = txtname;
                  //  dr = dt.NewRow();
                    //dr[1] = txtname;
                    //dr[0] = hf_intcust.Value;
                   // dr[1] = txtname;
                   // dr[0] = txtname;

                   // dt.Rows.Add(dr);
                    STufobj.InsCustMailids(txtname, Convert.ToInt32(hf_intcust.Value));
                }
                else
                {
                    dr = dt.NewRow();
                    dt.Rows.Add(dr);
                //    dr[1] = txtname;
                    dt.Rows[0]["mailid"] = txtname;

              
                    STufobj.InsCustMailids(txtname, Convert.ToInt32(hf_intcust.Value));
                }


                if (ViewState["CurrentData"] != null)
                {
                    Grd_mail.DataSource = dt;
                    //Grd_mail.DataSource = dt;
                    Grd_mail.DataBind();
                }
                else
                {
                    Grd_mail.DataSource = dt;
                    Grd_mail.DataBind();
                    //EmptyGridmail();

                }

                ViewState["CurrentData"] = dt;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        private bool IsValidEmailId(string InputEmail)
        {
            //Regex To validate Email Address
            Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$");

            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }



        protected void Grd_mail_RowDataBound(object sender, GridViewRowEventArgs e)
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

                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ImageButton2");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_mail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }
        }


        protected void txt_intermail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_intermail.Text.Trim().ToUpper() != "")
                {
                    string[] strTemptobcc = txt_intermail.Text.Split(';', ',');

                   for (int i = 0; i < strTemptobcc.Length; i++)
                   {
                       if (IsValidEmailId(txt_intermail.Text.Trim().ToUpper()))
                       {
                           if (ViewState["CurrentDataMail"] != null)
                           {
                               DataTable dtINMail = (DataTable)ViewState["CurrentDataMail"];
                               int count = dtINMail.Rows.Count;
                               BindGrid1(count, strTemptobcc[i].ToString().Trim().ToUpper());
                           }
                           else
                           {
                               BindGrid1(1, strTemptobcc[i].ToString().Trim().ToUpper());
                           }

                         //  txt_intermail.Focus();
                       }
                       else
                       {
                           ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('InValid Email Format');", true);
                           txt_intermail.Focus();
                           txt_intermail.Text = "";
                           return;
                       }
                   }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);

                    return;
                }

                txt_intermail.Text = "";
                txt_intermail.Focus();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }
        private void BindGrid1(int rowcount, string txtname)
        {
            DataTable dtINR = new DataTable();
            DataRow dr1;
            int i=0;
            try
            {
                dtINR.Columns.Add(new System.Data.DataColumn("mailid", typeof(String)));
                //dt.Columns.Add(new System.Data.DataColumn("customername", typeof(String)));

                if (ViewState["CurrentDataMail"] != null)
                {

                    ImageButton btndelete = new ImageButton();
                    foreach (GridViewRow row in Grd_intermail.Rows)
                    {

                        btndelete = (ImageButton)row.FindControl("ImageButton");
                        btndelete.Visible = true;

                    }
                    for ( i = 0; i < rowcount + 1; i++)
                    {
                        dtINR = (DataTable)ViewState["CurrentDataMail"];

                        if (dtINR.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dtINR);
                            dv.RowFilter = "mailid = '" + txtname.ToString().ToUpper().Trim() + "'";
                            if (dv.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail id Already Exist');", true);
                                return;
                            }

                           // dr1 = dtINR.NewRow();
                            //dr1[0] = dtINR.Rows[0][0].ToString();
                        }
                    }

                    dtINR.Rows.Add();
                    dtINR.Rows[i - 1]["mailid"] = txtname;
                    //dr1 = dtINR.NewRow();
                    //dtINR.Rows.Add(dr1);
                    //dr1[0] = txtname;
                    //dr[1] = custtype;

                  

                }
                else
                {
                    //dr1 = dtINR.NewRow();
                    //dtINR.Rows.Add(dr1);
                    ////    dr[1] = txtname;
                    //dr1[0] = txtname;
                    dtINR.Rows.Add();
                    dtINR.Rows[0]["mailid"] = txtname;
                  //  dr1 = dtINR.NewRow();
                   // dr1[0] = txtname;
                    //dr[1] = custtype;

                  //  dtINR.Rows.Add(dr1);

                }


                if (ViewState["CurrentDataMail"] != null)
                {
                    Grd_intermail.DataSource = dtINR;
                    Grd_intermail.DataBind();
                }
                else
                {
                    Grd_intermail.DataSource = dtINR;
                    Grd_intermail.DataBind();
                    //EmptyGridIntermail();

                }

                ViewState["CurrentDataMail"] = dtINR;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                
                ImageButton lb = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                if (ViewState["CurrentDataMail"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentDataMail"];
                    if (dt.Rows.Count > 0)
                    {
                        if (gvRow.RowIndex < dt.Rows.Count)
                        {

                            dt.Rows.Remove(dt.Rows[rowID]);
                            //  STufobj.DelCRMMailids(Trim(txtjobno.Text), Trim(txtbookno.Text), "I", grdIMail.Rows(index).Cells(0).Value, Login.branchid, Login.divisionid)
                          //  STufobj.DelCRMMailids(Convert.ToInt32(txt_job.Text.Trim()), txt_book.Text, 'I', gvRow.Cells[0].Text, bid, did);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted...');", true);
                        }

                        ViewState["CurrentDataMail"] = dt;
                        Grd_intermail.DataSource = dt;
                        Grd_intermail.DataBind();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        EmptyGridIntermail();
                        ViewState["CurrentDataMail"] = null;
                    }


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }


        protected void Grd_intermail_RowDataBound(object sender, GridViewRowEventArgs e)
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

                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ImageButton");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_intermail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }





        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
               
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                dtDODdate = Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_dodate.Text.ToString()));//Convert.ToDateTime(txt_dodate.Text);
                hid_dtDODdate.Value = dtDODdate.ToString();
                blno = STufobj.GetBLNofromBookNo(txt_book.Text, trantype, bid, did);
                if (blno != "")
                {
                    LoadConfirm.UpdFEBLDODate(blno, dtDODdate, bid, empid, did);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtST = new DataTable();
            try
            {
                string transtype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                DateTime stuffsenton, lcsenton, dssenton;
                DateTime tssenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                lcsenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                stuffsenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                dssenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                if (txt_next.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Enter the Next Follow Update');", true);
                    txt_next.Focus();
                    return;
                }
                else
                {
                    dtFlwUpd = Convert.ToDateTime(Utility.fn_ConvertDate(txt_next.Text.ToString()));
                }
                lbl_head.Text = Request.QueryString["type"].ToString();
                string Sname = lbl_head.Text;

                if (txt_job.Text != "" && txt_book.Text != "")
                {

                    if (Sname == "Stuffing Confirmation")
                    {
                        if (stuffInland == "")
                        {
                            STufobj.InsFEInlandMovement(txt_book.Text, txt_podmove.Text, "Stuffing", txt_pormove.Text, txt_msub.Text, bid, did);
                        }
                        else
                        {
                            STufobj.UpdFEInlandMovement(txt_book.Text, txt_podmove.Text, "Stuffing", bid, txt_pormove.Text, txt_msub.Text, did);
                        }
                    }
                    if (Sname == "Sailing Confirmation")
                    {
                        if (loadingInland == "")
                        {
                            STufobj.InsFEInlandMovement(txt_book.Text, txt_podmove.Text, "Loading", txt_pormove.Text, txt_msub.Text, bid, did);
                        }
                        else
                        {
                            STufobj.UpdFEInlandMovement(txt_book.Text, txt_podmove.Text, "Loading", bid, txt_pormove.Text, txt_msub.Text, did);
                        }
                    }
                    if (Sname == "Transhipment Confirmation")
                    {
                        if (TCInland == "")
                        {
                            STufobj.InsFEInlandMovement(txt_book.Text, txt_podmove.Text, "Transhipment", txt_pormove.Text, txt_msub.Text, bid, did);

                        }
                        else
                        {
                            STufobj.UpdFEInlandMovement(txt_book.Text, txt_podmove.Text, "Transhipment", bid, txt_pormove.Text, txt_msub.Text, did);
                        }
                    }
                    dt = STufobj.GetFEInlandMovement(txt_book.Text, bid, did);
                    if (dt.Rows.Count > 0)
                    {
                        stuffInland = dt.Rows[0][0].ToString();
                        loadingInland = dt.Rows[0][1].ToString();
                        TCInland = dt.Rows[0][2].ToString();
                    }
                    for (int i = 0; i < Grd_mail.Rows.Count - 1; i++)
                    {
                        string mailid =Grd_mail.Rows[i].Cells[0].Text;
                        char mailtype = Convert.ToChar("E");
                        STufobj.InsCRMMailids(Convert.ToInt32(txt_job.Text), txt_book.Text, mailtype, mailid, bid, did);
                    }
                    for (int i = 0; i < Grd_intermail.Rows.Count - 1; i++)
                    {
                        string mailid = Grd_intermail.Rows[i].Cells[0].Text;
                        char mailtype = Convert.ToChar("I");
                        STufobj.InsCRMMailids(Convert.ToInt32(txt_job.Text), txt_book.Text, mailtype, mailid, bid, did);
                    }
                    if (Sname == "Stuffing Confirmation")
                    {
                        CorpObj.UpdShipmentStatus(txt_book.Text, transtype, bid, "Stuffed");
                        CorpObj.UpdateShipmentStatus(txt_book.Text, transtype, 0, bid, "Cargo has stuffed into container");
                        FEJobobj.UpdateFEEventStuff(txt_book.Text, stuffsenton, bid, empid, did);
                        Logobj.InsLogDetail(empid, 191, 1, bid, txt_job.Text + " - " + txt_book.Text + " MailSent");
                    }
                    if (Sname == "Sailing Confirmation")
                    {
                        CorpObj.UpdShipmentStatus(txt_book.Text, transtype, bid, "Loaded");
                        CorpObj.UpdateShipmentStatus(txt_book.Text, transtype, 0, bid, "Loading Confirmation" + " - " + txt_vessel.Text);
                        FEJobobj.UpdateFEEventlcsenton(txt_book.Text, lcsenton, bid, empid, did);
                        Logobj.InsLogDetail(empid, 192, 1, bid, txt_job.Text + " - " + txt_book.Text + " MailSent");
                    }
                    if (Sname == "D O Confirmation")
                    {
                        CorpObj.UpdShipmentStatus(txt_book.Text, transtype, bid, "DO Issued");
                        CorpObj.UpdateShipmentStatus(txt_book.Text, transtype, 0, bid, "DO Issued");
                        FEJobobj.UpdateFEEventdssenton(txt_book.Text, dssenton, bid, empid, did);
                        Logobj.InsLogDetail(empid, 80, 1, bid, txt_job.Text + " - " + txt_book.Text + " MailSent");
                    }
                    if (Sname == "Transhipment Confirmation")
                    {
                        CorpObj.UpdShipmentStatus(txt_book.Text, transtype, bid, "Transhiped");

                        if (Grd_vessel.Rows.Count > 0)
                        {
                            //string status= Grd_vessel.Rows[0].Cells[];
                            CorpObj.UpdateShipmentStatus(txt_book.Text, transtype, 0, bid, "Transhiped" + " at " + Grd_vessel.Rows[0].Cells[0]);
                        }
                        else
                        {
                            CorpObj.UpdateShipmentStatus(txt_book.Text, transtype, 0, bid, "Transhiped");
                        }
                        FEJobobj.UpdateFEEventtssenton(txt_book.Text, tssenton, bid, empid, did);
                        Logobj.InsLogDetail(empid, 83, 1, bid, txt_job.Text + " - " + txt_book.Text + " MailSent");

                    }
                    if (txt_next.Text != "")
                    {
                        char ack = Convert.ToChar("N");
                        FEJobobj.UpdEventdtls(bid, dtFlwUpd, "Next Follow up", ack, txtremark.Text, txt_book.Text, empid, did);
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), " ", "alertify.alert('Details Updated');", true);
                } UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }


        protected void txt_exporter_TextChanged(object sender, EventArgs e)
        {
            int shipperid = customerobj.GetCustomerid(txt_exporter.Text.Trim().ToUpper());
                    if (shipperid != 0)
                    {
                        
            
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(txt_exporter, typeof(TextBox), "Valid", "alertify.alert('INVALID Exporter NAME');", true);
                        txt_exporter.Text = "";
                        txt_exporter.Focus();
                        int_back = 1;
                    }
            
        }

        protected void txt_dest_TextChanged(object sender, EventArgs e)
        {    
            
                 int custid = portobj.GetNPortid(txt_dest.Text.Trim().ToUpper());
                    if (custid != 0)
                    {
                        
                        
                    }
                    else
                    {
                        
                        txt_dest.Text = "";
                        txt_dest.Focus();
                        ScriptManager.RegisterStartupScript(txt_dest, typeof(TextBox), "Valid", "alertify.alert('INVALID DESTINATION NAME');", true);
                    }
            //if (hd_dest.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Select Correct Port Name');", true);
            //    return;
            //}
            //txt_dest.Focus();
        }

        protected void txt_mvessel_TextChanged(object sender, EventArgs e)
        {
            if (hd_mastervessel.Value == "" || hd_mastervessel.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Select Correct Vessel Name');", true);
                return;
            }
            txt_mvessel.Focus();
        }

   

        protected void btndelete_Click(object sender, EventArgs e)
        {
            int indexval;
            try
            {
                //indexval = Grd_vessel.SelectedRow.RowIndex;
                if (Grd_vessel.Rows.Count > 0)
                {
                    int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                    jobno = Convert.ToInt32(hid_jobno.Value.ToString());
                   
                    indexval=  (int)Session["indexval"];
                    int vesselid = Convert.ToInt32( Grd_vessel.Rows[indexval].Cells[8].Text);
                    STufobj.DeletevessalDetail(jobno, bid,vesselid);



                    DataTable dt1 = new DataTable();
                    dt1 = STufobj.GetMothervessaldts(jobno, bid);

                    if (dt1.Rows.Count > 0)
                    {
                        txtpol.Enabled = true;

                        DataRow lastRow = dt1.Rows[dt1.Rows.Count - 1];

                        // Access the last value in the last row
                        object lastValue = lastRow["pod"];
                        object lastValue1 = lastRow["eta"];
                        // Replace "ColumnName" with the actual column name from which you want to get the value

                        // If the column contains a specific data type like string, you may cast the value accordingly
                        string lastStringValue = lastRow["pod"].ToString();
                        string lastStringValue1 = lastRow["eta"].ToString();
                        txtpol.Text = lastStringValue;
                        txtetd.Text = lastStringValue1;
                        txtpol.Enabled = false;



                        Grd_vessel.DataSource = dt1;
                        Grd_vessel.DataBind();
                    }
                    else
                    {

                        txtetd.Text = Request.QueryString["Eta"].ToString();
                        txtpol.Text = Request.QueryString["Pod"].ToString();
                        Grd_vessel.DataSource = dt1;
                        Grd_vessel.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

        }

        protected void txt_pol_TextChanged(object sender, EventArgs e)
        {
            int custid = portobj.GetNPortid(txt_pol.Text.ToUpper());
            if (custid!=0)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_pol,typeof(TextBox), "Valid", "alertify.alert('INVALID PORT OF LOADING');", true);
                txt_pol.Text = "";
                txt_pol.Focus();
                int_back = 1;
                return;

            }
          
            //if (hd_portname.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Select Correct Port of Loading');", true);
            //    return;
            //}
            //txt_pol.Focus();
        }

        protected void txt_pkgtype_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterPackages packobj = new DataAccess.Masters.MasterPackages();
                intpkgs = packobj.GetNPackageid(txt_pkgtype.Text);
                if (intpkgs!= 0)
                {
                   
                
                }
                else
                {
                    
                    txt_pkgtype.Text = "";
                    txt_pkgtype.Focus();
                    ScriptManager.RegisterStartupScript(txt_pkgtype, typeof(TextBox), "Valid", "alertify.alert('INVALID PACKAGE TYPE');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
            //if(hd_package.Value =="")

            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Select Correct Package Type');", true);
            //}
            //    txt_pkgtype.Focus();
        }

        protected void txtpod_TextChanged(object sender, EventArgs e)
        {

            custid = portobj.GetNPortid(txtpod.Text.Trim().ToUpper());
            if (custid != 0)
            {

            }
            else
            {
                txt_pod.Text = "";
                txt_pod.Focus();
                ScriptManager.RegisterStartupScript(txt_pol, typeof(TextBox), "Valid", "alertify.alert('SELECT VALID PORT NAME');", true);

            }
            //if (hd_port.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Select Correct Port of Destination');", true);
            //    return;
            //}
            //txtpod.Focus();
        }

        protected void txt_sb_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtdetails = new DataTable();
            try
            {
                string transtype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());

                if (txt_sb.Text != "")
                {
                    dtdetails = ShippingBillobj.GetShippingBill(txt_sb.Text, bid, did);
                    if (dtdetails.Rows.Count != 0)
                    {
                        txt_job.Text = dtdetails.Rows[0]["job"].ToString();
                        bookno = Convert.ToInt32(dtdetails.Rows[0]["bookingno"].ToString());
                        txt_book.Text = ShippingBillobj.GetShipRefNo(bookno, bid, did);
                        //btn_back.Text="Cancel";

                        intshipperid = Convert.ToInt32(dtdetails.Rows[0]["shipper"].ToString());
                        hd_exporter.Value = intshipperid.ToString();
                        txt_exporter.Text = customerobj.GetCustomername(intshipperid);

                        txt_weight.Text = dtdetails.Rows[0]["grosswt"].ToString();
                        intpkgs = Convert.ToInt32(dtdetails.Rows[0]["pkgid"].ToString());
                        txt_pkgtype.Text = packageobj.GetPackagename(intpkgs);
                        txt_pkgs.Text = dtdetails.Rows[0]["noofpkg"].ToString();
                        intpkgs = Convert.ToInt32(dtdetails.Rows[0]["pld"].ToString());
                        txt_dest.Text = portobj.GetPortname(intpkgs);
                        //intagent= Convert.ToInt32(dtdetails.Rows[0]["agent"]);

                        //if(hd_customer.Value !="")
                        if (dtdetails.Rows[0]["agent"].ToString() != "")
                        {
                            txt_agent.Text = "";
                            intagentid = Convert.ToInt32(dtdetails.Rows[0]["agent"].ToString());
                            txt_agent.Text = customerobj.GetCustomername(intpkg);
                        }

                        txt_volume.Text = dtdetails.Rows[0]["volume"].ToString();
                        txt_remarks.Text = dtdetails.Rows[0]["remarks"].ToString();

                        if (dtdetails.Rows[0]["invpl"].ToString() == "y")
                        {
                            chk_invoice.Checked = true;
                        }
                        else
                        {
                            chk_invoice.Checked = false;
                        }
                        GetJobInfo();
                        GetContExit();
                        GetStuffDetails();
                        //btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                        //Grd_sb.DataSource = dtdetails;
                        //Grd_sb.DataBind();

                    }
                    else
                    {

                        //btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        txt_pkgs.Text = "";
                        txt_pkgtype.Text = "";
                        txt_weight.Text = "";
                        txt_volume.Text = "";
                        txt_exporter.Text = "";
                        txt_dest.Text = "";
                        txt_sb.Focus();
                        txt_remarks.Text = "";
                        txt_sb.Enabled = true;
                        if (chk_invoice.Checked == true)
                        {
                            chk_invoice.Checked = false;
                        }

                    }
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                return;
            }

        }

        //private void GetJobInfo()
        //{
        //    DataTable dtdetails = new DataTable();
        //    int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
        //    int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
        //    jobno= Convert.ToInt32(txt_job.Text);
        //    dtdetails = FEJobobj.GetFEJobInfo(jobno, bid, did);
        //    dtchkfordat = FEJobobj.GetfeventDates(jobno, bid, did);
        //    if (dtchkfordat.Rows.Count > 0)
        //    {
        //        if (dtchkfordat.Rows[0]["stufon"].ToString() == "")
        //        {
        //            dtstfon = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
        //        }
        //        else
        //        {
        //            dtstfon = Convert.ToDateTime(dtchkfordat.Rows[0]["stufon"].ToString());
        //        }
        //        if (dtchkfordat.Rows[0]["sailcnfsenton"].ToString() == "")
        //        {
        //            dtsailcnfon = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
        //        }
        //        else
        //        {
        //            dtsailcnfon = Convert.ToDateTime(dtchkfordat.Rows[0]["sailcnfsenton"].ToString());
        //        }
        //        if (dtchkfordat.Rows[0]["tssenton"].ToString() == "")
        //        {
        //            dtdssenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
        //        }
        //        else
        //        {
        //            dtdssenton = Convert.ToDateTime(dtchkfordat.Rows[0]["tssenton"].ToString());
        //        }
        //        if (dtchkfordat.Rows[0]["docreqsenton"].ToString() == "")
        //        {
        //            dtdocnfreqon = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
        //        }
        //        else
        //        {
        //            dtdocnfreqon = Convert.ToDateTime(dtchkfordat.Rows[0]["docreqsenton"].ToString());
        //        }
        //        if (dtchkfordat.Rows[0]["docnfsnton"].ToString() == "")
        //        {
        //            dtdocnfsenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
        //        }
        //        else
        //        {
        //            dtdocnfsenton = Convert.ToDateTime(dtchkfordat.Rows[0]["docnfsnton"].ToString());
        //        }
        //        //if (dtchkfordat.Rows[0]["tssenton"].ToString() == "")
        //        //{
        //        //    dtdssenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
        //        //}
        //        //else
        //        //{
        //        //    dtdssenton = Convert.ToDateTime(dtchkfordat.Rows[0]["tssenton"].ToString());
        //        //}
        //    }
        //    if(dtdetails.Rows.Count > 0)
        //    {
        //        txt_vessel.Text = dtdetails.Rows[0]["vessel"].ToString() + " v " + dtdetails.Rows[0]["voyage"].ToString();
        //        txt_pol.Text = dtdetails.Rows[0]["pol"].ToString();
        //        txt_pod.Text = dtdetails.Rows[0]["pod"].ToString();
        //        txt_etd.Text = dtdetails.Rows[0]["etd"].ToString();
        //        txt_eta.Text = dtdetails.Rows[0]["eta"].ToString();
        //        jobtype = Convert.ToInt32(dtdetails.Rows[0]["jobtype"].ToString());
        //        jobno = Convert.ToInt32(txt_job.Text.ToString());
        //        chklst.Items.Clear();
        //        if(txt_job.Text !="")
        //        {
        //            jobno = Convert.ToInt32(txt_job.Text.ToString());
        //            dt = FEJobobj.GetContainerDetails(jobno, txt_job.Text, bid, did);
        //              for ( int i = 0; i <= dt.Rows.Count - 1; i++)
        //               {
        //                   chklst.Items.Clear();
        //                   chklst.Items.Add(dt.Rows[i]["containerno"].ToString());

        //                }
        //            }
        //            if (sbvalid == false)
        //            {
        //                txt_book.Enabled = true;
        //                //txt_book.Text = "";
        //            }

        //    }
        //    else
        //    {
        //        btn_save.Enabled = false;
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid JOB #');", true);
        //    }
        //}

        private void GetJobInfo()
        {
            DataTable dtdetails = new DataTable();
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                //txt_job.Text = Grdjob.Rows[index].Cells[0].Text;
                jobno = Convert.ToInt32(txt_job.Text);
                dtdetails = FEJobobj.GetFEJobInfo(jobno, bid, did);
                
                dtchkfordat = FEJobobj.GetfeventDates(jobno, bid, did);
                if (dtchkfordat.Rows.Count > 0)
                {
                    if (dtchkfordat.Rows[0]["stufon"].ToString() == "")
                    {
                        dtstfon = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                    }
                    else
                    {
                        dtstfon = Convert.ToDateTime(Utility.fn_ConvertDate(dtchkfordat.Rows[0]["stufon"].ToString()));
                        //dtstfon = Convert.ToDateTime(dtchkfordat.Rows[0]["stufon"].ToString());
                    }
                    if (dtchkfordat.Rows[0]["sailcnfsenton"].ToString() == "")
                    {
                        dtsailcnfon = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                    }
                    else
                    {
                        dtsailcnfon = Convert.ToDateTime(Utility.fn_ConvertDate(dtchkfordat.Rows[0]["sailcnfsenton"].ToString()));
                        //dtsailcnfon = Convert.ToDateTime(dtchkfordat.Rows[0]["sailcnfsenton"].ToString());
                    }
                    if (dtchkfordat.Rows[0]["tssenton"].ToString() == "")
                    {
                        dtdssenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                    }
                    else
                    {
                        dtdssenton = Convert.ToDateTime(Utility.fn_ConvertDate(dtchkfordat.Rows[0]["tssenton"].ToString()));
                        //dtdssenton = Convert.ToDateTime(dtchkfordat.Rows[0]["tssenton"].ToString());
                    }
                    if (dtchkfordat.Rows[0]["docreqsenton"].ToString() == "")
                    {
                        dtdocnfreqon = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                    }
                    else
                    {
                        dtdocnfreqon = Convert.ToDateTime(Utility.fn_ConvertDate(dtchkfordat.Rows[0]["docreqsenton"].ToString()));
                        //dtdocnfreqon = Convert.ToDateTime(dtchkfordat.Rows[0]["docreqsenton"].ToString());
                    }
                    if (dtchkfordat.Rows[0]["docnfsnton"].ToString() == "")
                    {
                        dtdocnfsenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                    }
                    else
                    {
                        dtdocnfsenton = Convert.ToDateTime(Utility.fn_ConvertDate(dtchkfordat.Rows[0]["docnfsnton"].ToString()));
                        //dtdocnfsenton = Convert.ToDateTime(dtchkfordat.Rows[0]["docnfsnton"].ToString());
                    }
                    //if (dtchkfordat.Rows[0]["tssenton"].ToString() == "")
                    //{
                    //    dtdssenton = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
                    //}
                    //else
                    //{
                    //    dtdssenton = Convert.ToDateTime(dtchkfordat.Rows[0]["tssenton"].ToString());
                    //}
                }
                if (dtdetails.Rows.Count > 0)
                {
                    hd_customer.Value = dtdetails.Rows[0]["agentid"].ToString();
                    txt_vessel.Text = dtdetails.Rows[0]["vessel"].ToString() + " v " + dtdetails.Rows[0]["voyage"].ToString();
                    txt_pol.Text = dtdetails.Rows[0]["pol"].ToString();
                    txt_pod.Text = dtdetails.Rows[0]["pod"].ToString();

                    DateTime etd = Convert.ToDateTime((dtdetails.Rows[0]["etd"].ToString()));
                    txt_etd.Text = etd.ToString("dd/MM/yyyy");

                   // txt_etd.Text = dtdetails.Rows[0]["etd"].ToString();    
              
                    txt_agent.Text = dtdetails.Rows[0]["agent"].ToString();
                  
                    DateTime eta = Convert.ToDateTime((dtdetails.Rows[0]["eta"].ToString()));
                    txt_eta.Text = eta.ToString("dd/MM/yyyy");

                    //txt_eta.Text = Utility.fn_ConvertDate(txt_eta.Text).ToString();
                    jobtype = Convert.ToInt32(dtdetails.Rows[0]["jobtype"].ToString());
                    hid_jobtype.Value = jobtype.ToString();
                    jobno = Convert.ToInt32(txt_job.Text.ToString());
                    Session["jobno"] = txt_job.Text;
                    chklst.Items.Clear();
                    if (txt_job.Text != "")
                    {
                        jobno = Convert.ToInt32(txt_job.Text.ToString());
                        dt = FEJobobj.GetContainerDetails(jobno, txt_job.Text, bid, did);
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            // chklst.Items.Clear();
                            chklst.Items.Add(dt.Rows[i]["containerno"].ToString());

                        }
                    }
                    if (sbvalid == false)
                    {
                        txt_book.Enabled = true;
                        //txt_book.Text = "";
                    }
                    //btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    btn_save.Enabled = false;
                    btn_save.ForeColor = System.Drawing.Color.Gray;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid JOB #');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        private void GetContExit()
        {
            DataTable dtCont = new DataTable();
            try
            {
                jobno = Convert.ToInt32(txt_job.Text);
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                dtCont = STufobj.GetStuffConfContainer(jobno, txt_sb.Text, bid, did);
                if (dtCont.Rows.Count > 0)
                {
                    for (int k = 0; k <= dtCont.Rows.Count - 1; k++)
                    {
                        for (int i = 0; i < chklst.Items.Count; i++)
                        {
                            if (chklst.Items[i].Text.ToString() == dtCont.Rows[k]["containerno"].ToString())
                            {
                                chklst.Items[i].Selected = true;
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

        //public void SetItemChecked(int index, bool value);

        //public void SetItemChecked(int index, bool value)
        //{
        //    chklst.set(index, value ? CheckState.Checked : CheckState.Unchecked);
        //}


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                
                ImageButton lb = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                if (ViewState["CurrentData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        if (gvRow.RowIndex < dt.Rows.Count)
                        {

                            dt.Rows.Remove(dt.Rows[rowID]);
                          //  STufobj.DelCRMMailids(Trim(txtjobno.Text), Trim(txtbookno.Text), "E", grdCMail.Rows(index).Cells(0).Value, Login.branchid, Login.divisionid);

                          //  STufobj.DelCRMMailids(Convert.ToInt32(txt_job.Text.Trim()), txt_book.Text, 'E', gvRow.Cells[0].Text, bid, did);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted...');", true);
                        }

                        ViewState["CurrentData"] = dt;
                        Grd_mail.DataSource = dt;
                        Grd_mail.DataBind();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        EmptyGridmail();
                        ViewState["CurrentData"] = null;
                    }


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_job_TextChanged1(object sender, EventArgs e)
        {
            GetJobInfo();
            if (Request.QueryString.ToString().Contains("bookno") && Request.QueryString.ToString().Contains("job"))
            {
            }
            else
            {
                txt_book.Text = "";
                txt_book.Focus();
            }
            UserRights();
        }

        protected void chklst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chklst.setitemchecked(int i,true);
        }

        protected void Imgsb_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                DataTable dtSB = new DataTable();
                ImageButton lb = (ImageButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                if (Grd_sb.Rows.Count > 0)
                {
                    int rowID = gvRow.RowIndex;
                    string sbnogrd = Grd_sb.Rows[rowID].Cells[0].Text;
                    STufobj.DelShippingBill(sbnogrd,Convert.ToInt32(txt_job.Text),bid, did);
                    dtSB = STufobj.GetSBDetails(Convert.ToInt32(txt_job.Text), txt_book.Text.Trim(), bid, did);

                    if (dtSB.Rows.Count > 0)
                    {
                        Grd_sb.DataSource = dtSB;
                        Grd_sb.DataBind();
                    }
                    if (dtSB.Rows.Count == 1)
                    {
                        txt_book.Text = Grd_sb.Rows[rowID].Cells[11].Text;
                        txt_sb.Text = Grd_sb.Rows[rowID].Cells[0].Text;

                        txt_sbdate.Text = Grd_sb.Rows[rowID].Cells[1].Text;
                        txt_pkgs.Text = Grd_sb.Rows[rowID].Cells[4].Text;
                        txt_pkgtype.Text = Grd_sb.Rows[rowID].Cells[5].Text;

                        txt_weight.Text = Grd_sb.Rows[rowID].Cells[6].Text;
                        txt_volume.Text = Grd_sb.Rows[rowID].Cells[7].Text;
                        txt_exporter.Text = Grd_sb.Rows[rowID].Cells[2].Text;
                        txt_dest.Text = Grd_sb.Rows[rowID].Cells[3].Text;

                        if (Grd_sb.Rows[rowID].Cells[8].Text == "")
                        {
                            txt_agent.Text = "";
                        }
                        else
                        {
                            txt_agent.Text = Grd_sb.Rows[rowID].Cells[8].Text;
                        }

                        if (Grd_sb.Rows[rowID].Cells[9].Text == "")
                        {
                            txtremark.Text = "";
                        }
                        else
                        {
                            txtremark.Text = Grd_sb.Rows[rowID].Cells[9].Text;
                        }

                        if (Grd_sb.Rows[rowID].Cells[10].Text == "")
                        {
                            chk_invoice.Checked = false;
                        }
                        else
                        {
                            if (Grd_sb.Rows[rowID].Cells[10].Text == "y")
                            {
                                chk_invoice.Checked = true;
                            }
                            else
                            {
                                chk_invoice.Checked = false;
                            }
                        }
                    }
                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    txt_sb.Enabled = false;
                    GetContExit();

                    if (dtSB.Rows.Count == 0)
                    {
                        EmptyGridSB();
                    }
                }

                shippermailadd = customerobj.GetCusMailaddrs(customerobj.GetCustomerid(txt_exporter.Text.ToString()));
                txt_customer.Text = shippermailadd;

                if (txt_sb.Text != "")
                {
                    //btn_back.Text = "Cancel";
                    btn_back.ToolTip = "Cancel";
                    btn_back1.Attributes["class"] = "btn ico-cancel";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }


        protected void Grd_sb_RowDataBound(object sender, GridViewRowEventArgs e)
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

                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Imgsb");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_sb, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_vessel_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_vessel, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_vessel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexval;
            try
            {
                //indexval = Grd_vessel.SelectedRow.RowIndex;
                if (Grd_vessel.Rows.Count > 0)
                {
                    // btn_add.Text = "Update";
                    //btn_add.ToolTip = "Update";
                    //btn_add1.Attributes["class"] = "btn btn-update";
                    indexval = Grd_vessel.SelectedRow.RowIndex;
                     SelectIndex=indexval;
                    hid_slectindex.Value=indexval.ToString();
                    Session["indexval"] = indexval;
                    txt_mvessel.Text = Grd_vessel.Rows[indexval].Cells[9].Text;
                    txt_voy.Text = Grd_vessel.Rows[indexval].Cells[7].Text;
                    //txtpol.Text = Grd_vessel.Rows[indexval].Cells[1].Text;
                    txtpod.Text = Grd_vessel.Rows[indexval].Cells[3].Text;
                    txteta.Text = Grd_vessel.Rows[indexval].Cells[4].Text;
                    txtetd.Text = Grd_vessel.Rows[indexval].Cells[2].Text;
                    ddl_Vessal.SelectedItem.Text = Grd_vessel.Rows[indexval].Cells[6].Text;
                    hid_veselid.Value = Grd_vessel.Rows[indexval].Cells[8].Text;
                    //txtremarks.Text = HttpUtility.HtmlDecode(Grd_vessel.Rows[indexval].Cells[5].Text);
                    oldvesselid = vesselobj.GetVesselid(txt_mvessel.Text.Trim());
                    hd_oldmvessel.Value = oldvesselid.ToString();
                    btnadd.ToolTip = "Update";
                  
                    btnadd.Attributes["class"] = "btn btn-update1";

                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void Grd_sb_SelectedIndexChanged(object sender, EventArgs e)
         {
            int indexvalue;
            try
            {
                if (Grd_sb.Rows.Count > 0)
                {
                    indexvalue = Grd_sb.SelectedRow.RowIndex;
                    txt_book.Text = Grd_sb.Rows[indexvalue].Cells[11].Text;
                    txt_sb.Text = Grd_sb.Rows[indexvalue].Cells[0].Text;
                    txt_sbdate.Text = Grd_sb.Rows[indexvalue].Cells[1].Text;
                    txt_pkgs.Text = Grd_sb.Rows[indexvalue].Cells[4].Text;
                    txt_pkgtype.Text = Grd_sb.Rows[indexvalue].Cells[5].Text;
                    txt_weight.Text = Grd_sb.Rows[indexvalue].Cells[6].Text;
                    txt_volume.Text = Grd_sb.Rows[indexvalue].Cells[7].Text;
                    //txt_exporter.Text = Grd_sb.Rows[indexvalue].Cells[2].Text;
                    txt_dest.Text = Grd_sb.Rows[indexvalue].Cells[3].Text;
                    txt_exporter.Text = HttpUtility.HtmlDecode(Grd_sb.Rows[indexvalue].Cells[2].Text);
                    //if (HttpUtility.HtmlDecode(Grd_sb.Rows[indexvalue].Cells[8].Text) == "") //.Replace("&nbsp","") == "")
                    //{
                    //    txt_agent.Text = "";
                    //    txt_agent.Focus();
                    //}
                    //else
                    //{

                    //    // txt_agent.Text = HttpUtility.HtmlDecode(Grd_sb.Rows[indexvalue].Cells[8].Text);
                    //    txt_agent.Text = Grd_sb.Rows[indexvalue].Cells[8].Text;
                    //}

                    if (HttpUtility.HtmlDecode(Grd_sb.Rows[indexvalue].Cells[9].Text) == "")
                    {
                        txt_remarks.Text = "";
                    }
                    else
                    {
                        txt_remarks.Text = Grd_sb.Rows[indexvalue].Cells[9].Text;
                    }
                    if (Grd_sb.Rows[indexvalue].Cells[10].Text == "")
                    {
                        chk_invoice.Checked = false;
                    }
                    else
                    {
                        if (Grd_sb.Rows[indexvalue].Cells[10].Text == "y")
                        {
                            chk_invoice.Checked = true;
                        }
                        else
                        {
                            chk_invoice.Checked = false;
                        }
                    }


                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    txt_sb.Enabled = false;
                    GetContExit();

                    shippermailadd = customerobj.GetCusMailaddrs(customerobj.GetCustomerid(txt_exporter.Text));
                    txt_customer.Text = shippermailadd;

                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }


        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            fn_btnsend_Click();
        }
        public void fn_btnsend_Click()
        {
            try
            {
                if(hid_jobtype.Value !="" || hid_jobtype.Value !="0")
                {
                   jobtype= Convert.ToInt32( hid_jobtype.Value);
                }

                fd=hid_fd.Value;
                por = hid_Por.Value;
                pol = hid_pol.Value;
                pod = hid_pod.Value;
                if (txt_book.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "alertify.alert('Kindly Enter Booking #');", true);
                    return;
                }

               strEmpName= empobj.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                string internalmailid = "";
                string usermail = "";
                
                DataTable obj_dt = new DataTable();
                DataAccess.Message4Booking obj_da_msgbkng = new DataAccess.Message4Booking();
                DataAccess.ForwardingExports.JobInfo obj_da_FEJob = new DataAccess.ForwardingExports.JobInfo();
                DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
                DataAccess.Corporate obj_da_Corp = new DataAccess.Corporate();
                DataAccess.HR.Employee obj_da_hremp = new DataAccess.HR.Employee();
                DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
                if (btn_send.ToolTip == "Cancel")
                {
                    GrdBooking.Visible = false;

                    Grdjob.Visible = false;
                    btn_send.Text = "Send";
                    btn_send.ToolTip = "Send";
                    btn_send1.Attributes["class"] = "btn ico-send-mail";
                    return;
                }
                else
                {
                    if (lbl_head.Text == "Stuffing Confirmation")
                    {
                        if (hf_stuffInland.Value == "")
                        {
                            obj_da_stuff.InsFEInlandMovement(txt_book.Text.ToString(), txt_podmove.Text.ToString(), "Stuffing", txt_pormove.Text.ToString(), txt_msub.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        }
                        else
                        {
                            obj_da_stuff.UpdFEInlandMovement(txt_book.Text.ToString(), txt_podmove.Text.ToString(), "Stuffing", Convert.ToInt32(Session["LoginBranchid"]), txt_pormove.Text.ToString(), txt_msub.Text.ToString(), Convert.ToInt32(Session["LoginDivisionid"]));
                        }
                    }
                    else if (lbl_head.Text == "Sailing Confirmation")
                    {
                        if (hf_loadingInland.Value == "")
                        {
                            obj_da_stuff.InsFEInlandMovement(txt_book.Text.ToString(), txt_pormove.Text.ToString(), "Loading", txt_pormove.Text.ToString(), txt_msub.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        }
                        else
                        {
                            obj_da_stuff.UpdFEInlandMovement(txt_book.Text.ToString(), txt_pormove.Text.ToString(), "Loading", Convert.ToInt32(Session["LoginBranchid"]), txt_pormove.Text.ToString(), txt_msub.Text.ToString(), Convert.ToInt32(Session["LoginDivisionid"]));
                        }
                    }
                    else if (lbl_head.Text == "Transhipment Confirmation")
                    {
                        if (hf_TCInland.Value == "")
                        {
                            obj_da_stuff.InsFEInlandMovement(txt_book.Text.ToString(), txt_pormove.Text.ToString(), "Transhipment", txt_pormove.Text.ToString(), txt_msub.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        }
                        else
                        {
                            obj_da_stuff.UpdFEInlandMovement(txt_book.Text.ToString(), txt_pormove.Text.ToString(), "Transhipment", Convert.ToInt32(Session["LoginBranchid"]), txt_pormove.Text.ToString(), txt_msub.Text.ToString(), Convert.ToInt32(Session["LoginDivisionid"]));
                        }
                    }
                    hf_shippermailadd.Value = "";
                    if (Grd_mail.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Grd_mail.Rows.Count - 1; i++)
                        {
                            hf_shippermailadd.Value = hf_shippermailadd.Value + Grd_mail.Rows[i].Cells[0].Text.ToString() + ";";
                        }
                    }
                    internalmailid = internalmailid + Session["usermailid"].ToString() + ";";
                    usermail = obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString()));
                    if (internalmailid != "")
                    {
                        internalmailid = internalmailid + usermail;
                    }
                    else
                    {
                        usermail = obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString()));
                        internalmailid = usermail;

                    }
                    //if (Grd_intermail.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i <= Grd_intermail.Rows.Count - 1; i++)
                    //    {
                    //        internalmailid = internalmailid + Grd_intermail.Rows[i].Cells[0].Text + ";";
                    //    }
                    //    usermail = obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString()));
                    //    if (internalmailid != "")
                    //    {
                    //        internalmailid = internalmailid + usermail;
                    //    }
                    //    else
                    //    {
                    //        usermail = obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString()));
                    //        internalmailid = usermail;

                    //    }

                    //}
                    if (hf_shippermailadd.Value != "")
                    {
                        hf_shippermailadd.Value = hf_shippermailadd.Value.Replace(",", ";");
                    }
                    if (hf_shippermailadd.Value != "")
                    {
                        hf_shippermailadd.Value = hf_shippermailadd.Value.Remove(hf_shippermailadd.Value.Length - 1, 1);
                    }
                    //if (hf_shippermailadd.Value == "")
                    //{
                    //    hf_shippermailadd.Value = internalmailid;
                    //}
                    obj_dt = obj_da_stuff.GetFEInlandMovement(txt_book.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));

                    if (obj_dt.Rows.Count > 0)
                    {
                        hf_stuffInland.Value = obj_dt.Rows[0]["stuffing"].ToString();
                        hf_loadingInland.Value = obj_dt.Rows[0]["loading"].ToString();
                        hf_TCInland.Value = obj_dt.Rows[0]["transhipment"].ToString();
                    }
                    if (Grd_intermail.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Grd_mail.Rows.Count - 1; i++)
                        {
                            obj_da_stuff.InsCRMMailids(Convert.ToInt32(txt_job.Text.ToString()), txt_book.Text.ToString(), 'E', Grd_mail.Rows[i].Cells[0].Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        }
                    }
                    if (Grd_intermail.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Grd_intermail.Rows.Count - 1; i++)
                        {
                            obj_da_stuff.InsCRMMailids(Convert.ToInt32(txt_job.Text.ToString()), txt_book.Text.ToString(), 'I', Grd_intermail.Rows[i].Cells[0].Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        }
                    }
                    
                    if (lbl_head.Text == "Stuffing Confirmation")
                    {
                        obj_da_Corp.UpdShipmentStatus(txt_book.Text.ToString(), "FE", Convert.ToInt32(Session["LoginBranchid"]), "Stuffed");
                        obj_da_Corp.UpdateShipmentStatus(txt_book.Text.ToString(), "FE", 0, Convert.ToInt32(Session["LoginBranchid"]), "Cargo has stuffed into container");
                        obj_da_FEJob.UpdateFEEventStuff(txt_book.Text.ToString(), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 191, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text.ToString() + " - " + txt_book.Text.ToString() + " MailSent");
                        sendStuffingMail();


                       // Utility.SendMail("dinesh@ltsolutions.co.in", "rajaguru@ltsolutions.co.in", txt_msub.Text.ToString(), sendqry, "", Session["usermailpwd"].ToString(), "", "");
                        if (internalmailid != "")
                        {
                          //  Utility.SendMail(usermail, hf_shippermailadd.Value, txt_msub.Text.ToString(), sendqry, "", Session["usermailpwd"].ToString(), "", internalmailid);

                           // Utility.SendMailnew("donotreply@aidni.com", "donotreply@aidni.com;donotreply@aidni.com", sendqry, "", "", "", internalmailid);
                            
                            msgbookingobj.InsMsg4Booking((txt_book.Text.Trim()), (txt_msub.Text.Trim()), "", internalmailid + ";" + usermail, Logobj.GetDate(), strEmpName, hf_shippermailadd.Value, "", "");
                        }

                    }
                    else if (lbl_head.Text == "Sailing Confirmation")
                    {
                        obj_da_Corp.UpdShipmentStatus(txt_book.Text.ToString(), "FE", Convert.ToInt32(Session["LoginBranchid"]), "Loaded");
                        obj_da_Corp.UpdateShipmentStatus(txt_book.Text.ToString(), "FE", 0, Convert.ToInt32(Session["LoginBranchid"]), "Loading Confirmation" + " - " + txt_vessel.Text.ToString());
                        obj_da_FEJob.UpdateFEEventlcsenton(txt_book.Text.ToString(), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 192, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text.ToString() + " - " + txt_book.Text.ToString() + " MailSent");
                        sendLCMail();
                       // Utility.SendMail("dinesh@ltsolutions.co.in", "rajaguru@ltsolutions.co.in", txt_msub.Text.ToString(), sendqry, "", Session["usermailpwd"].ToString(), "", "");
                        if (internalmailid != "")
                        {
                           // Utility.SendMail(usermail, hf_shippermailadd.Value, txt_msub.Text.ToString(), sendqry, "", Session["usermailpwd"].ToString(), "", internalmailid);
                           // Utility.SendMailnew("donotreply@aidni.com", "donotreply@aidni.com;donotreply@aidni.com", sendqry, "", "", "", internalmailid);
                            msgbookingobj.InsMsg4Booking((txt_book.Text.Trim()), (txt_msub.Text.Trim()), "", internalmailid + ";" + usermail, Logobj.GetDate(), strEmpName, hf_shippermailadd.Value, "", "");
                        }
                   }
                    else if (lbl_head.Text == "D O Confirmation")
                    {

                        obj_da_Corp.UpdShipmentStatus(txt_book.Text.ToString(), "FE", Convert.ToInt32(Session["LoginBranchid"]), "DO Issued");
                        obj_da_Corp.UpdateShipmentStatus(txt_book.Text.ToString(), "FE", 0, Convert.ToInt32(Session["LoginBranchid"]), "DO Issued");
                        obj_da_FEJob.UpdateFEEventdssenton(txt_book.Text.ToString(), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 80, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text.ToString() + " - " + txt_book.Text.ToString() + " MailSent");
                        SendDOConfirm();
                        //Utility.SendMail(usermail, "rajaguru@ltsolutions.co.in", txt_msub.Text.ToString(), sendqry, "", Session["usermailpwd"].ToString(), "", "");
                        if (internalmailid != "")
                        {
                           // Utility.SendMail(usermail, hf_shippermailadd.Value, txt_msub.Text.ToString(), sendqry, "", Session["usermailpwd"].ToString(), "", internalmailid);

                            //Utility.SendMailnew("donotreply@aidni.com", "donotreply@aidni.com;donotreply@aidni.com", sendqry, "", "", "", internalmailid);
                           
                            msgbookingobj.InsMsg4Booking((txt_book.Text.Trim()), (txt_msub.Text.Trim()), "", internalmailid + ";" + usermail, Logobj.GetDate(), strEmpName, hf_shippermailadd.Value, "", "");
                        }
                     }
                    else if (lbl_head.Text == "Transhipment Confirmation")
                    {

                        obj_da_Corp.UpdShipmentStatus(txt_book.Text.ToString(), "FE", Convert.ToInt32(Session["LoginBranchid"]), "Transhiped ");
                        if (Grd_vessel.Rows.Count > 0)
                        {
                            obj_da_Corp.UpdateShipmentStatus(txt_book.Text.ToString(), "FE", 0, Convert.ToInt32(Session["LoginBranchid"]), "Transhiped");
                        }
                        else
                        {
                            obj_da_Corp.UpdateShipmentStatus(txt_book.Text.ToString(), "FE", 0, Convert.ToInt32(Session["LoginBranchid"]), "Transhiped");
                        }

                        obj_da_FEJob.UpdateFEEventtssenton(txt_book.Text.ToString(), obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 83, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_job.Text.ToString() + " - " + txt_book.Text.ToString() + " MailSent");
                      sendTCMail();
                     
                     // Utility.SendMail("dinesh@ltsolutions.co.in", "rajaguru@ltsolutions.co.in", txt_msub.Text.ToString(), sendqry, "", Session["usermailpwd"].ToString(), "", "");
                      if (internalmailid != "")
                      {
                        //  Utility.SendMail(usermail, hf_shippermailadd.Value, txt_msub.Text.ToString(), sendqry, "", Session["usermailpwd"].ToString(), "", internalmailid);

                          //Utility.SendMailnew("donotreply@aidni.com", "donotreply@aidni.com;donotreply@aidni.com", sendqry, "", "", "", internalmailid);

                          obj_da_msgbkng.InsMsg4Booking(txt_book.Text.ToString(), txt_msub.Text.ToString(), "", internalmailid + ";" + usermail, obj_da_log.GetDate(), strEmpName, hf_shippermailadd.Value, "", "");
                      }
                    }

                    if (txt_next.Text != "")
                    {
                        obj_da_FEJob.UpdEventdtls(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToDateTime(Utility.fn_ConvertDate( txt_next.Text.ToString())), "Next Follow up", 'N', txt_remarks.Text.ToString(), txt_book.Text.ToString(), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));
                    }
                    if (internalmailid != "")
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_send, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Mail send');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_send, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Internal Mailid mandatory  For Mail Send');", true);
                    }

                } UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }



        }
        public void sendStuffingMail()
        {
                string cont = "";
                string remarks = "";
                //string sendqry = "";
                string strinvpl;
                DataTable obj_dt = new DataTable();
                DataTable obj_dt1 = new DataTable();
                DataTable obj_dt2 = new DataTable();
                DataAccess.ForwardingExports.ShippingBill obj_da_shpngbill = new DataAccess.ForwardingExports.ShippingBill();
                DataAccess.Masters.MasterPort obj_da_port = new DataAccess.Masters.MasterPort();
                DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();
                sendqry = sendqry + Session["Companyaddress"].ToString();
           

                //If Trim(txtStatus.Text) <> "" Then
                //    sendqry = sendqry & "<table width=100%><tr><td align=center><FONT FACE=sans-serif SIZE=3 COLOR=DarkBlue>" & Trim(txtStatus.Text) & "</FONT></td></tr></table>"
                //End If
                sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>STUFFING CONFIRMATION & TENTATIVE SAILING SCHEDULE</B></FONT></td></tr><br>";

                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thank you for your valuable shipment. This is to bring to your kind attention that your shipment has stuffed & the tentative sailing details are as follows</FONT></td></tr></table><br>";
                //        sendqry = sendqry & "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Note : Please forward Invoice and Packing List copies for this Shipment</FONT></td></tr><br><br>"
                //sendqry = sendqry & "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # : " & txt_job.Text & "</FONT></td><td></td><td></td><td></td><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " & txt_book.Text & "</FONT></td></tr></table>"
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # :" + txt_job.Text + "</FONT></td></tr>";
                sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " + txt_book.Text + "</FONT></td></tr></table>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POD : " + pod + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>FD : " + fd + "</FONT></td></tr></table><br>";
                //if (txtAgent.Text == "0")
                //{
                //    txtAgent.Text = "";
                //}
                if (!string.IsNullOrEmpty(txt_agent.Text))
                {
                    sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Agent Address</FONT></td></tr>";
                    sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_agent.Text + "</FONT></td></tr>";
                    string agentaddress = "";
                    string agentloc = "";
                    string agentzip = "";
                    string agentphone = "";
                    string agentfax = "";
                    string agentmail = "";
                    string agentptc = "";
                    intagentid = customerobj.GetCustomerid(txt_agent.Text);
                    obj_dt = obj_da_customer.RetrieveCustomerDetails(txt_agent.Text, "Agent / Principal", obj_da_customer.GetCustlocation(intagentid));
                    if (obj_dt.Rows.Count > 0)
                    {
                        agentaddress = obj_dt.Rows[0]["address"].ToString();
                        agentloc = obj_da_port.GetPortname(obj_dt.Rows[0]["city"].ToString());
                        agentzip = obj_dt.Rows[0]["zip"].ToString();
                        agentphone = obj_dt.Rows[0]["phone"].ToString();
                        agentfax = obj_dt.Rows[0]["fax"].ToString();
                        agentmail = obj_dt.Rows[0]["email"].ToString();
                        agentptc = obj_dt.Rows[0]["ptc"].ToString();
                    }
                    if (!string.IsNullOrEmpty(agentaddress))
                    {
                        sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + agentaddress + "</FONT></td></tr>";
                    }
                    if (!string.IsNullOrEmpty(agentloc))
                    {
                        sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + agentloc + " - " + agentzip + "</FONT></td></tr>";
                    }
                    if (!string.IsNullOrEmpty(agentphone))
                    {
                        sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Phone : " + agentphone + "</FONT></td></tr>";
                    }
                    if (!string.IsNullOrEmpty(agentfax))
                    {
                        sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Fax : " + agentfax + "</FONT></td></tr>";
                    }
                    if (!string.IsNullOrEmpty(agentmail))
                    {
                        sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>EMail : " + agentmail + "</FONT></td></tr>";
                    }
                    if (!string.IsNullOrEmpty(agentptc))
                    {
                        sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Ctc : " + agentptc + "</FONT></td></tr>";
                    }
                    sendqry = sendqry + "</table><br>";
                }

                int j = 0;
                if (Grd_sb.Rows.Count > 0)
                {
                    if (jobtype != 3)
                    {
                        sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Volume</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                        for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
                        {
                            cont = "";
                            obj_dt1 = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text.ToString()), Grd_sb.Rows[j].Cells[0].Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                            if (obj_dt1.Rows.Count > 0)
                            {
                                for (int i = 0; i <= obj_dt1.Rows.Count - 1; i++)
                                {
                                    cont = cont + obj_dt1.Rows[i][0].ToString() + " / " + obj_dt1.Rows[i][1].ToString() + " / " + obj_dt1.Rows[i][2] + "  , ";
                                }
                                if (!string.IsNullOrEmpty(cont))
                                {
                                    cont = cont.Remove(cont.Length - 2, 2);
                                }
                            }
                            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text.ToString() + " & " + Grd_sb.Rows[j].Cells[1].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text.ToString() + "  " + Grd_sb.Rows[j].Cells[5].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[7].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text.ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text.ToString() + "</FONT></td></tr>";

                        }
                    }
                    else
                    {
                        sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                        for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
                        {
                            cont = "";
                            obj_dt2 = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text.ToString()), Grd_sb.Rows[j].Cells[0].Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                            if (obj_dt2.Rows.Count > 0)
                            {
                                for (int i = 0; i <= obj_dt2.Rows.Count - 1; i++)
                                {
                                    cont = cont + obj_dt2.Rows[i][0].ToString() + " / " + obj_dt2.Rows[i][1].ToString() + " / " + obj_dt2.Rows[i][2].ToString() + "  , ";
                                }
                                if (!string.IsNullOrEmpty(cont))
                                {
                                    cont = cont.Remove(cont.Length - 2, 2);
                                }
                            }
                            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";
                        }
                    }

                    cont = "";
                    sendqry = sendqry + "</table>";
                }

                sendqry = sendqry + "<table border=1><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Feeder Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_vessel.Text + "</FONT></td></tr><br>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETD  " + txt_pol.Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_etd.Text + "</FONT></td></tr>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETA  " + txt_pod.Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_eta.Text + "</FONT></td></tr>";
                for (int i = 0; i <= Grd_vessel.Rows.Count - 1; i++)
                {
                    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connect On</FONT></td></tr><br>";
                    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Mother Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[0].Text + "</FONT></td></tr>";
                    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETD  " + Grd_vessel.Rows[i].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[2].Text + "</FONT></td></tr>";
                    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETA  " + Grd_vessel.Rows[i].Cells[3].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[4].Text + "</FONT></td></tr>";
                    sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Remarks </FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[5].Text + "</FONT></td></tr>";
                }
                sendqry = sendqry + "</table><br>";
                if (!string.IsNullOrEmpty(hf_stuffInland.Value))
                {
                    sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Inland Movement : " + hf_stuffInland.Value + "</FONT></td></tr></table><br>";
                }

                //if (chkinvpl.Checked == true)
                //{
                    strinvpl = "Please send the Invoice & PackingList copies for this Shipment.";
                    sendqry = sendqry + "<table border=1 width=100%><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000><B>Note : </FONT></B><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000> " + strinvpl + "</FONT></td></tr></table><br>";
                //}
                sendqry = sendqry + "<table border=1 width=100%><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000><B>Note : </FONT></B><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000>Please arrange to collect B/L within 7 days of vessel departure from " + txt_pol.Text + ". Failing which late B/L fee of USD 100/- per B/L will be charged.</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_news.Text + "</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Assuring you our best service at all times & kindly acknowledge the receipt.</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thanks & Best Regards,</FONT></td></tr><br>";
                
        }
        public void sendLCMail()
        {
              string cont= "";
             string remarks= "";
                 DataTable obj_dt=new DataTable();
                  DataTable obj_dt1=new DataTable();
                 DataTable obj_dt2=new DataTable();
                  DataTable obj_dt3=new DataTable();
                 DataTable obj_dtST=new DataTable();
                 DataTable obj_dtST2=new DataTable();
                 DataAccess.HR.Employee obj_da_hremp=new DataAccess.HR.Employee();
                 DataAccess.Masters.MasterEmployee obj_da_emp=new DataAccess.Masters.MasterEmployee();
                 DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
                 DataAccess.ForwardingExports.ShippingBill obj_da_shpngbill = new DataAccess.ForwardingExports.ShippingBill();
             sendqry = sendqry +Session["Companyaddress"].ToString();        
             sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>SAILING CONFIRMATION & TENTATIVE SAILING SCHEDULE</B></FONT></td></tr><br>";
             sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT></td></tr></table><br>";
             sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thank you for your valuable shipment, and below mentioned shipment loaded on "+txt_vessel.Text+ " Sailed On "+txt_etd.Text+ " ETA : " +txt_pod.Text+ " on " +txt_eta.Text+ "</FONT></td></tr></table><br>";
             string blno= "";      
             blno = obj_da_stuff.GetBLNofromBookNo(txt_book.Text, "FE", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
             sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # : " +txt_job.Text+ "</FONT></td></tr>";
             sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : "+txt_book.Text+ "</FONT></td></tr></table>";
             if( blno!="" && blno !="0")
             {
                 sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>BL No : </B></FONT></td><td align=center><FONT FACE=sans-serif SIZE=2>" + blno + "</FONT></td></tr></table>";
             }
             sendqry = sendqry+ "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POD : " + pod +"</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>FD : " +fd + "</FONT></td></tr></table><br>";

             if(Grd_sb.Rows.Count > 0)
             {
                 if(jobtype!=3)
                 {
                     sendqry = sendqry +"<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Volume</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                     for(int j = 0;j<=Grd_sb.Rows.Count - 1;j++)
                     {
                         cont = "";
                         obj_dt = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text), Grd_sb.Rows[j].Cells[0].Text,Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                         if(obj_dt.Rows.Count > 0)
                         {
                            for(int i = 0;i<=obj_dt.Rows.Count - 1;i++)
                            {
                                 cont = cont + obj_dt.Rows[i][0].ToString()+" / " + obj_dt.Rows[i][1].ToString() + " / " + obj_dt.Rows[i][2].ToString() + "  , ";
                            }
                             if(cont!= "")
                             {
                                 cont = cont.Remove(cont.Length - 2, 2);
                             }
                         }
                         sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text+" & " + Grd_sb.Rows[j].Cells[1].Text+ "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[7].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text+ "</FONT></td></tr>";
                        }
                 }
                 else
                 {
                     sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                     for(int j = 0;j<=Grd_sb.Rows.Count - 1;j++)
                     {
                         cont = "";
                         obj_dt1 = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text), Grd_sb.Rows[j].Cells[0].Text,Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                         if(obj_dt1.Rows.Count > 0 )
                         {
                             for(int i = 0;i<=obj_dt1.Rows.Count - 1;i++)
                             {
                                 cont = cont + obj_dt1.Rows[i][0].ToString()+" / "+obj_dt1.Rows[i][1].ToString()+ " / "+ obj_dt1.Rows[i][2].ToString() + "  , ";
                             }
                             if(cont !="")
                             {
                                 cont = cont.Remove(cont.Length - 2, 2);
                             }
                         }
                         sendqry = sendqry +"<tr><td align=left><FONT FACE=sans-serif SIZE=2>" +Grd_sb.Rows[j].Cells[0].Text+ " & " + Grd_sb.Rows[j].Cells[1].Text+ "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text+ "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +Grd_sb.Rows[j].Cells[9].Text+ "</FONT></td></tr>";

                     }           
                 cont = "";
                 sendqry = sendqry + "</table>";
                 }
             }
            if(Grd_vessel.Rows.Count > 0)
            {
                 sendqry = sendqry + "<table border=1>";
                 for(int i = 0;i<=Grd_vessel.Rows.Count - 1;i++)
                 {
                     if(i == 0)
                         {
                         sendqry = sendqry +"<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connected On</FONT></td></tr><br>";
                     }
                     else
                     {
                         sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connected On</FONT></td></tr><br>";
                     }
                     sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Mother Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[0].Text + "</FONT></td></tr>";
                     sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETD  " + Grd_vessel.Rows[i].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[2].Text + "</FONT></td></tr>";
                     sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETA  " + Grd_vessel.Rows[i].Cells[3].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[4].Text+ "</FONT></td></tr>";
                     sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Remarks </FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[5].Text + "</FONT></td></tr>";
                 }
                 sendqry = sendqry + "</table>";
            }
             sendqry = sendqry + "</table><br>";
             if(hf_loadingInland.Value!="")
             {
                 sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Inland Movement : " + hf_loadingInland.Value + "</FONT></td></tr></table><br>";
             }
             sendqry = sendqry + "<br><table border=1 width=100%><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=sans-serif SIZE=3 COLOR=#FF0000><B>Note : </FONT></B><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000>Please arrange to collect B/L within 7 days of vessel departure from " +txt_pol.Text+ ". Failing which late B/L fee of USD 100/- per B/L will be charged.</FONT></td></tr></table><br>";

             sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>" +txt_news.Text+ "</FONT></td></tr></table><br>";
             sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Assuring you our best service at all times & kindly acknowledge the receipt.</FONT></td></tr></table><br>";
             sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thanks & Best Regards,</FONT></td></tr><br>";
             sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_da_emp.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"])) + "</FONT></td></tr></table>";
             sendqry = sendqry + "<tr><td><FONT FACE=sans-serif SIZE=2>" + " Email : " + obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString())) + "</FONT></td></tr></table><HR width=100%>";

             obj_dtST = STufobj.GetMVDetails(Convert.ToInt32(txt_job.Text.ToString()), txt_book.Text.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
             if(obj_dtST.Rows.Count > 0)
             {
                 sendqry = sendqry +Session["Companyaddress"].ToString();
                 sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>STUFFING CONFIRMATION & TENTATIVE SAILING SCHEDULE</B></FONT></td></tr><br>";
                 sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT></td></tr></table><br>";
                 sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thank you for your valuable shipment. This is to bring to your kind attention that your shipment has stuffed & the tentative sailing details are as follows</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # : " + txt_job.Text + "</FONT></td></tr>";
                 sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " + txt_book.Text + "</FONT></td></tr></table>";
                 sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POD : " + pod + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>FD : " + fd + "</FONT></td></tr></table><br>";
                  if(jobtype!= 3)
                  {
                     sendqry = sendqry +"<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Volume</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                     for(int j = 0;j<=Grd_sb.Rows.Count - 1;j++)
                     {
                         cont = "";
                         obj_dt2 = ShippingBillobj.GetContainerDetails(Convert.ToInt32( txt_job.Text), Grd_sb.Rows[j].Cells[0].Text,Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                         if(obj_dt2.Rows.Count > 0)
                         {
                             for(int i = 0;i<=obj_dt2.Rows.Count - 1;i++)
                             {
                                 cont = cont + obj_dt2.Rows[i][0].ToString() + " / " + obj_dt2.Rows[i][1].ToString() + " / " + obj_dt2.Rows[i][2].ToString() + "  , ";
                             }
                             if(cont!="")
                             {
                                 cont = cont.Remove(cont.Length - 2, 2);
                             }
                         }
                         sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " +  Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +  Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +  Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +  Grd_sb.Rows[j].Cells[7].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +  Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +  Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";

                     }
                  }
                 else
             {
                     sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                     for(int j = 0;j<=Grd_sb.Rows.Count - 1;j++)
                     {
                         cont = "";
                         obj_dt3 = ShippingBillobj.GetContainerDetails(Convert.ToInt32(txt_job.Text), Grd_sb.Rows[j].Cells[0].Text,Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                         if(obj_dt3.Rows.Count > 0)
                         {
                          for(int i = 0;i<=obj_dt3.Rows.Count - 1;i++)
                          {
                                 cont = cont + obj_dt3.Rows[i][0].ToString() + " / " + obj_dt3.Rows[i][1].ToString() + " / " + obj_dt3.Rows[i][2].ToString() + "  , ";
                          }
                             if(cont !="")
                             {
                                 cont = cont.Remove(cont.Length - 2, 2);
                             }
                         }
                         sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text+ "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text+ "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text+ "</FONT></td></tr>";
                      }
             }
                 cont = "";
                 sendqry = sendqry + "</table><table border=1><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Feeder Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +txt_vessel.Text+"</FONT></td></tr><br>";
                 sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETD  " +txt_pol.Text+ "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +txt_etd.Text+ "</FONT></td></tr>";
                 sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETA  " +txt_pod.Text+"</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" +txt_eta.Text+"</FONT></td></tr>";
                 obj_dtST2 = obj_da_stuff.GetMVDetails(Convert.ToInt32(txt_job.Text), txt_book.Text,Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                 if(obj_dtST2.Rows.Count > 0)
                 {
                     for(int i = 0;i<=obj_dtST2.Rows.Count - 1;i++)
                     {
                         sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connect On</FONT></td></tr><br>";
                         sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Mother Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST2.Rows[i][0].ToString() + "</FONT></td></tr>";
                         sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETD  " + obj_dtST2.Rows[i][1].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST2.Rows[i][2].ToString()+ "</FONT></td></tr>";
                         sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETA  " + obj_dtST2.Rows[i][3].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST2.Rows[i][4].ToString()+ "</FONT></td></tr>";
                         sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Remarks </FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST2.Rows[i][5].ToString()+ "</FONT></td></tr>";
                     }
                 }
                 sendqry = sendqry + "</table>";
                 if(hf_stuffInland.Value!="")
                 {
                     sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Inland Movement : " + hf_stuffInland.Value + "</FONT></td></tr></table><br>";
                 }
                 sendqry = sendqry + "<br><table border=1 width=100%><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000><B>Note : </FONT></B><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000>Please arrange to collect B/L within 7 days of vessel departure from " +txt_pol.Text+ ". Failing which late B/L fee of USD 100/- per B/L will be charged.</FONT></td></tr></table><br>";
                 sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>" +txt_news.Text+ "</FONT></td></tr></table><br>";
                 sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Assuring you our best service at all times & kindly acknowledge the receipt.</FONT></td></tr></table><br>";
                 sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thanks & Best Regards,</FONT></td></tr><br>";
                 sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_da_emp.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"])) + "</FONT></td></tr></table>";
                 sendqry = sendqry + "<tr><td><FONT FACE=sans-serif SIZE=2>" + " Email : " + obj_da_hremp.GetMailAdd(hrempobj.GetEmpId(Session["LoginUserName"].ToString())) + "</FONT></td></tr></table>";
                  }
        }
        public void SendDOConfirm()
        {
            int BLshipperid=0;
            string BLShipper = "";
            string shipperadd;
            string sCity;
          
            DataTable obj_dt = new DataTable();

            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.ForwardingExports.LoadingConfirmation obj_da_LoadC = new DataAccess.ForwardingExports.LoadingConfirmation();
            DataAccess.Masters.MasterCustomer obj_da_customer = new DataAccess.Masters.MasterCustomer();
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
            blno = obj_da_stuff.GetBLNofromBookNo(txt_book.Text, "FE", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
            if (blno != "0")
            {
                obj_da_LoadC.UpdFEBLDODate(blno, Convert.ToDateTime(Utility.fn_ConvertDate( txt_dodate.Text)), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));

               // obj_da_LoadC.UpdFEBLDODate(blno, Convert.ToDateTime(hid_dtDODdate.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));
                obj_dt = obj_da_FEBL.GetBLDetails(blno, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                if (obj_dt.Rows.Count > 0)
                {
                   
                    BLshipperid = Convert.ToInt32(obj_dt.Rows[0]["shipperid"].ToString());
                    BLShipper = obj_dt.Rows[0]["sname"].ToString();
                }
                sCity = obj_da_customer.GetCustlocation(BLshipperid);
                shipperadd = obj_da_customer.GetCustomerAddress(BLShipper, "Shipper", sCity);
                sendqry = Session["Companyaddress"].ToString();
                sendqry = sendqry + "<body text=black><table width=100%><FONT FACE=tahoma ><tr><td align=left>To</td></tr><br>";
                sendqry = sendqry + "<tr><td align=left>" + BLShipper + "</td></tr>";
                sendqry = sendqry + "<tr><td align=left>" + shipperadd + "</td></tr>";
                sendqry = sendqry + "<tr><td align=left>" + sCity + "</td></tr></br></table><br>";
                sendqry = sendqry + "<table><tr><td align=left>K / A</td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left>Please find the delivary status of your below mentioned shipment</td></tr></table>";
                sendqry = sendqry + "<table><tr><td align=left>B/L # : " + blno + "</td></tr>";
                sendqry = sendqry + "<tr><td align=left>Final Destination : " + fd + "</td></tr>";
                 sendqry = sendqry + "<tr><td align=left>D.O.Issued On : " + txt_dodate.Text + "</td></tr></table><br><br><br><br>";  //hid_dtDODdate
                //sendqry = sendqry + "<tr><td align=left>D.O.Issued On : " + hid_dtDODdate.Value + "</td></tr></table><br><br><br><br>";
                sendTCMail();
            }
        }
        public void sendTCMail()
        {
            
            string cont = "";
            string remarks = "";
            DataTable obj_Dt = new DataTable();
            DataTable obj_Dt1 = new DataTable();
            DataTable obj_Dt2 = new DataTable();
            DataTable obj_Dt3 = new DataTable();
            DataTable obj_dtST = new DataTable();
            DataTable obj_dtST1 = new DataTable();
            DataTable obj_dtST2 = new DataTable();
            DataTable obj_dtST3 = new DataTable();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
            DataAccess.ForwardingExports.ShippingBill obj_da_shpngbill = new DataAccess.ForwardingExports.ShippingBill();
            DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            DataAccess.HR.Employee obj_da_hremp = new DataAccess.HR.Employee();
            DataAccess.Masters.MasterEmployee obj_da_emp = new DataAccess.Masters.MasterEmployee();
            if (lbl_head.Text != "D O Confirmation")
            {
                sendqry = "";
            }
            int j = 0;
           
            obj_dtST = obj_da_stuff.GetMVDetails4FETCBooking(Convert.ToInt32(txt_job.Text), txt_book.Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
            if (obj_dtST.Rows.Count > 0)
            {
                sendqry = sendqry + Session["Companyaddress"].ToString();
                sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>TRANSHIPMENT CONFIRMATION</B></FONT></td></tr><br>";

                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Please find Transhipment Details for your valuable shipment.</FONT></td></tr></table><br>";
                blno = obj_da_stuff.GetBLNofromBookNo(txt_book.Text, "FE", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # : " + txt_job.Text + "</FONT></td></tr>";
                sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " + txt_book.Text + "</FONT></td></tr></table>";
                if (!string.IsNullOrEmpty(blno) & blno != "0")
                {
                    sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>BL No : </B></FONT></td><td align=center><FONT FACE=sans-serif SIZE=2>" + blno + "</FONT></td></tr></table>";
                }
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POD : " + pod + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>FD : " + fd + "</FONT></td></tr></table><br>";

                if (Grd_sb.Rows.Count > 0)
                {
                    if (jobtype != 3)
                    {
                        sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Volume</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                        for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
                        {
                            cont = "";
                            obj_Dt = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text), Grd_sb.Rows[j].Cells[0].Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                            if (obj_Dt.Rows.Count > 0)
                            {
                                for (int i = 0; i <= obj_Dt.Rows.Count - 1; i++)
                                {
                                    cont = cont + obj_Dt.Rows[i][0].ToString() + " / " + obj_Dt.Rows[i][1].ToString() + " / " + obj_Dt.Rows[i][2].ToString() + "  , ";
                                }
                                if (!string.IsNullOrEmpty(cont))
                                {
                                    cont = cont.Remove(cont.Length - 2, 2);
                                }
                            }
                            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[7].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";

                        }
                    }
                    else
                    {
                        sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                        for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
                        {
                            cont = "";
                            obj_Dt1 = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text), Grd_sb.Rows[j].Cells[0].Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                            if (obj_Dt1.Rows.Count > 0)
                            {
                                for (int i = 0; i <= obj_Dt1.Rows.Count - 1; i++)
                                {
                                    cont = cont + obj_Dt1.Rows[i][0].ToString() + " / " + obj_Dt1.Rows[i][1].ToString() + " / " + obj_Dt1.Rows[i][2].ToString() + "  , ";
                                }
                                if (!string.IsNullOrEmpty(cont))
                                {
                                    cont = cont.Remove(cont.Length - 2, 2);
                                }
                            }
                            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";

                        }
                    }
                    cont = "";
                    sendqry = sendqry + "</table>";
                }
                sendqry = sendqry + "<table border=1><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Feeder Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_vessel.Text + "</FONT></td></tr><br>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Sailed On  " + txt_pol.Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_etd.Text + "</FONT></td></tr>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Arrd  " + txt_pod.Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_eta.Text + "</FONT></td></tr>";

                if (Grd_vessel.Rows.Count > 0)
                {
                    for (int i = 0; i <= Grd_vessel.Rows.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                            sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Connected On</FONT></td></tr><br>";
                        }
                        else
                        {
                            sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connected On</FONT></td></tr><br>";
                        }
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Mother Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[0].Text + "</FONT></td></tr>";
                        
                        currdate = obj_da_log.GetDate();
                        etddate = Convert.ToDateTime(Utility.fn_ConvertDate( Grd_vessel.Rows[i].Cells[2].Text));
                        if (etddate < currdate)
                        {
                            Strvar = "Sailed On";
                        }
                        else
                        {
                            Strvar = "ETD";

                        }
                        string StrEta = null;
                        etddate = Convert.ToDateTime(Utility.fn_ConvertDate(Grd_vessel.Rows[i].Cells[4].Text));
                        if (etddate < currdate)
                        {
                            StrEta = "Arrd";
                        }
                        else
                        {
                            StrEta = "ETA";

                        }
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>" + Strvar + "  " + Grd_vessel.Rows[i].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[2].Text + "</FONT></td></tr>";
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>" + StrEta + "  " + Grd_vessel.Rows[i].Cells[3].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[4].Text + "</FONT></td></tr>";
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Remarks </FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_vessel.Rows[i].Cells[5].Text + "</FONT></td></tr>";
                    }
                    sendqry = sendqry + "</table>";
                }
                sendqry = sendqry + "</table><br>";
                if (!string.IsNullOrEmpty(hf_TCInland.Value))
                {
                    sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Inland Movement : " + hf_TCInland.Value + "</FONT></td></tr></table><br>";
                }
                sendqry = sendqry + "<br><table border=1 width=100%><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=sans-serif SIZE=3 COLOR=#FF0000><B>Note : </FONT></B><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000>Please arrange to collect B/L within 7 days of vessel departure from " + txt_pol.Text + ". Failing which late B/L fee of USD 100/- per B/L will be charged.</FONT></td></tr></table><br>";

                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_news.Text + "</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Assuring you our best service at all times & kindly acknowledge the receipt.</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thanks & Best Regards,</FONT></td></tr><br>";
                sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_da_emp.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString())) + "</FONT></td></tr></table>";
                sendqry = sendqry + "<tr><td><FONT FACE=sans-serif SIZE=2>" + " Email : " + obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString())) + "</FONT></td></tr></table><HR width=100%>";

            }
            obj_dtST1 = obj_da_stuff.GetMVDetails4FELCBooking(Convert.ToInt32(txt_job.Text), txt_book.Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
            if (obj_dtST1.Rows.Count > 0)
            {
                sendqry = sendqry + Session["Companyaddress"].ToString();
                sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>SAILING CONFIRMATION & TENTATIVE SAILING SCHEDULE</B></FONT></td></tr><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thank you for your valuable shipment, and below mentioned shipment loaded on " + txt_vessel.Text + " Sailed On " + txt_etd.Text + " ETA : " + txt_eta.Text + "</FONT></td></tr></table><br>";
                blno = obj_da_stuff.GetBLNofromBookNo(txt_book.Text, "FE", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # : " + txt_job.Text + "</FONT></td></tr>";
                sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " + txt_book.Text + "</FONT></td></tr></table>";
                if (!string.IsNullOrEmpty(blno) && blno != "0")
                {
                    sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>BL No : </B></FONT></td><td align=center><FONT FACE=sans-serif SIZE=2>" + blno + "</FONT></td></tr></table>";
                }
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POD : " + pod + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>FD : " + fd + "</FONT></td></tr></table><br>";
                if (Grd_sb.Rows.Count > 0)
                {
                    if (jobtype != 3)
                    {
                        sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Volume</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                        for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
                        {
                            cont = "";
                            obj_Dt2 = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text), Grd_sb.Rows[j].Cells[0].Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                            if (obj_Dt2.Rows.Count > 0)
                            {
                                for (int i = 0; i <= obj_Dt2.Rows.Count - 1; i++)
                                {
                                    cont = cont + obj_Dt2.Rows[i][0].ToString() + " / " + obj_Dt2.Rows[i][1].ToString() + " / " + obj_Dt2.Rows[i][2].ToString() + "  , ";
                                }
                                if (!string.IsNullOrEmpty(cont))
                                {
                                    cont = cont.Remove(cont.Length - 2, 2);
                                }
                            }
                            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[7].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";

                        }
                    }
                    else
                    {
                        sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                        for ( j = 0; j <= Grd_sb.Rows.Count - 1; j++)
                        {
                            cont = "";
                            obj_Dt3 = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32( txt_job.Text), Grd_sb.Rows[j].Cells[0].Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                            if (obj_Dt3.Rows.Count > 0)
                            {
                                for (int i = 0; i <= obj_Dt3.Rows.Count - 1; i++)
                                {
                                    cont = cont + obj_Dt3.Rows[i][0].ToString() + " / " + obj_Dt3.Rows[i][1].ToString() + " / " + obj_Dt3.Rows[i][2].ToString() + "  , ";
                                }
                                if (!string.IsNullOrEmpty(cont))
                                {
                                    cont = cont.Remove(cont.Length - 2, 2);
                                }
                            }
                            sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";

                        }
                    }
                    cont = "";
                    sendqry = sendqry + "</table>";
                }
                obj_dtST2 = obj_da_stuff.GetMVDetails4FELCBooking(Convert.ToInt32(txt_job.Text), txt_book.Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));

                if (obj_dtST2.Rows.Count > 0)
                {
                    sendqry = sendqry + "<table border=1>";
                    for (int i = 0; i <= obj_dtST2.Rows.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                            sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connected On</FONT></td></tr><br>";
                        }
                        else
                        {
                            sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connected On</FONT></td></tr><br>";
                        }
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Mother Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST2.Rows[i][0].ToString() + "</FONT></td></tr>";
                        etddate = Convert.ToDateTime(Utility.fn_ConvertDate(obj_dtST2.Rows[i][2].ToString()));
                        if (etddate < currdate)
                        {
                            Strvar = "Sailed On";
                        }
                        else
                        {
                            Strvar = "ETD";

                        }
                        string StrEta = null;
                        etddate = Convert.ToDateTime(Utility.fn_ConvertDate(obj_dtST2.Rows[i][4].ToString()));
                        if (etddate < currdate)
                        {
                            StrEta = "Arrd";
                        }
                        else
                        {
                            StrEta = "ETA";

                        }
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>" + Strvar + "   " + obj_dtST2.Rows[i][1].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST2.Rows[i][2].ToString() + "</FONT></td></tr>";
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>" + StrEta + "   " + obj_dtST2.Rows[i][3].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST2.Rows[i][4].ToString() + "</FONT></td></tr>";
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Remarks </FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST2.Rows[i][5].ToString() + "</FONT></td></tr>";
                    }
                    // Next i
                    sendqry = sendqry + "</table>";
                }
                if (!string.IsNullOrEmpty(hf_loadingInland.Value))
                {
                    sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Inland Movement : " + hf_loadingInland.Value + "</FONT></td></tr></table><br>";
                }
                sendqry = sendqry + "<br><table border=1 width=100%><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=sans-serif SIZE=3 COLOR=#FF0000><B>Note : </FONT></B><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000>Please arrange to collect B/L within 7 days of vessel departure from " + txt_pol.Text + ". Failing which late B/L fee of USD 100/- per B/L will be charged.</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_news.Text + "</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Assuring you our best service at all times & kindly acknowledge the receipt.</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thanks & Best Regards,</FONT></td></tr><br>";
                sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_da_emp.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString())) + "</FONT></td></tr></table>";
                sendqry = sendqry + "<tr><td><FONT FACE=sans-serif SIZE=2>" + " Email : " + obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString())) + "</FONT></td></tr></table><HR width=100%>";
            }
            obj_dtST3 = obj_da_stuff.GetMVDetails(Convert.ToInt32(txt_job.Text), txt_book.Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
            if (obj_dtST3.Rows.Count > 0)
            {
                sendqry = sendqry + Session["Companyaddress"].ToString();
                sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>STUFFING CONFIRMATION & TENTATIVE SAILING SCHEDULE</B></FONT></td></tr><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thank you for your valuable shipment. This is to bring to your kind attention that your shipment has stuffed & the tentative sailing details are as follows</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Job # : " + txt_job.Text + "</FONT></td></tr>";
                sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>Booking # : " + txt_book.Text + "</FONT></td></tr></table>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>POR : " + por + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POL : " + pol + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>POD : " + pod + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>FD : " + fd + "</FONT></td></tr></table><br>";
                if (jobtype != 3)
                {
                    sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Volume</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                    for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
                    {
                        cont = "";
                        obj_dt = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text), Grd_sb.Rows[j].Cells[0].Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        if (obj_dt.Rows.Count > 0)
                        {
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                cont = cont + obj_dt.Rows[i][0].ToString() + " / " + obj_dt.Rows[i][1].ToString() + " / " + obj_dt.Rows[i][2].ToString() + "  , ";
                            }
                            if (!string.IsNullOrEmpty(cont))
                            {
                                cont = cont.Remove(cont.Length - 2, 2);
                            }
                        }
                        sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[7].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";

                    }
                }
                else
                {
                    sendqry = sendqry + "<table border=1><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>S/Bill # & Date</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Exporter</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Container / Size / Seal</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>No.Of Pkgs.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Gross Wt.</B></FONT></td><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black><B>Remarks</B></FONT></td></tr><br>";
                    for (j = 0; j <= Grd_sb.Rows.Count - 1; j++)
                    {
                        cont = "";
                        obj_dt = obj_da_shpngbill.GetContainerDetails(Convert.ToInt32(txt_job.Text), Grd_sb.Rows[j].Cells[0].Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        if (obj_dt.Rows.Count > 0)
                        {
                            for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                            {
                                cont = cont + obj_dt.Rows[i][0].ToString() + " / " + obj_dt.Rows[i][1].ToString() + " / " + obj_dt.Rows[i][2].ToString() + "  , ";
                            }
                            if (!string.IsNullOrEmpty(cont))
                            {
                                cont = cont.Remove(cont.Length - 2, 2);
                            }
                        }
                        sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[0].Text + " & " + Grd_sb.Rows[j].Cells[1].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[2].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + cont + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[4].Text + "  " + Grd_sb.Rows[j].Cells[5].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[6].Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + Grd_sb.Rows[j].Cells[9].Text + "</FONT></td></tr>";

                    }
                }
                cont = "";
                sendqry = sendqry + "</table><table border=1><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Feeder Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_vessel.Text + "</FONT></td></tr><br>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETD  " + txt_pol.Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_etd.Text + "</FONT></td></tr>";
                sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>ETA  " + txt_pod.Text + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_eta.Text + "</FONT></td></tr>";
                obj_dtST = obj_da_stuff.GetMVDetails(Convert.ToInt32(txt_job.Text), txt_book.Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                if (obj_dtST.Rows.Count > 0)
                {
                    for (int i = 0; i <= obj_dtST.Rows.Count - 1; i++)
                    {
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Intended to Connect On</FONT></td></tr><br>";
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Mother Vessel</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST.Rows[i][0].ToString() + "</FONT></td></tr>";
                        etddate = Convert.ToDateTime(Utility.fn_ConvertDate(Grd_vessel.Rows[i].Cells[2].Text));
                        if (etddate < currdate)
                        {
                            Strvar = "Sailed On";
                        }
                        else
                        {
                            Strvar = "ETD";

                        }
                        string StrEta = null;
                        etddate = Convert.ToDateTime(Utility.fn_ConvertDate(Grd_vessel.Rows[i].Cells[4].Text));
                        if (etddate < currdate)
                        {
                            StrEta = "Arrd";
                        }
                        else
                        {
                            StrEta = "ETA";

                        }
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black> " + Strvar + "   " + obj_dtST.Rows[i][1].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST.Rows[i][2].ToString() + "</FONT></td></tr>";
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black> " + StrEta + "   " + obj_dtST.Rows[i][3].ToString() + "</FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST.Rows[i][4].ToString() + "</FONT></td></tr>";
                        sendqry = sendqry + "<tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=2 COLOR=Black>Remarks </FONT></td><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_dtST.Rows[i][5].ToString() + "</FONT></td></tr>";
                    }
                }
                sendqry = sendqry + "</table><br>";
                if (!string.IsNullOrEmpty(hf_stuffInland.Value))
                {
                    sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Inland Movement : " + hf_stuffInland.Value + "</FONT></td></tr></table><br>";
                }
                sendqry = sendqry + "<br><table border=1 width=100%><tr><td align=left BGCOLOR=#CCCCCC><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000><B>Note : </FONT></B><FONT FACE=sans-serif SIZE=2 COLOR=#FF0000>Please arrange to collect B/L within 7 days of vessel departure from " + txt_pol.Text + ". Failing which late B/L fee of USD 100/- per B/L will be charged.</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>" + txt_news.Text + "</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Assuring you our best service at all times & kindly acknowledge the receipt.</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table><tr><td align=left><FONT FACE=sans-serif SIZE=2>Thanks & Best Regards,</FONT></td></tr><br>";
                sendqry = sendqry + "<tr><td align=left><FONT FACE=sans-serif SIZE=2>" + obj_da_emp.GetEmployeeName(Convert.ToInt32(Session["LoginEmpId"].ToString())) + "</FONT></td></tr></table>";
                sendqry = sendqry + "<tr><td><FONT FACE=sans-serif SIZE=2>" + " Email : " + obj_da_hremp.GetMailAdd(obj_da_hremp.GetEmpId(Session["LoginUserName"].ToString())) + "</FONT></td></tr></table>";
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {

            fn_btnview_Click();
        }
        public void fn_btnview_Click()
        {
            try
            {
                if (lbl_head.Text == "D O Confirmation")
                {
                    string str_RptName = "";
                    string str_sp = "";
                    string str_sf = "";
                    string str_Script = "";

                  
                    DataAccess.ForwardingExports.JobInfo obj_da_FEJob = new DataAccess.ForwardingExports.JobInfo();
                    DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
                    DataAccess.Corporate obj_da_Corp = new DataAccess.Corporate();
                    DataAccess.ForwardingExports.LoadingConfirmation obj_da_LoadC = new DataAccess.ForwardingExports.LoadingConfirmation();
                    DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuff = new DataAccess.ForwardingExports.StuffingConfirmation();
                    blno = obj_da_stuff.GetBLNofromBookNo(txt_book.Text.ToString(), "FE", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionid"]));
                    if (Grd_sb.Rows.Count > 0)
                    {
                        //    report.strfrmname = "DO_Confirmation";
                        //    report.strRptName = "Reports" + "\FEDOStatus.rpt" ' "REPORTS" + "\EmpDetails.rpt"';
                        //    sf = "{FIBLDetails.bid}=" + Session["LoginBranchid"].ToString() + " and {FEBLDetails.blno}='" + blno + "'";
                        //    rptclass.ShowReport(report.strRptName, sf, "", "Group", "Master", "22");

                        obj_da_LoadC.UpdFEBLDODate(blno, Convert.ToDateTime(Utility.fn_ConvertDate(txt_dodate.Text.ToString())), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        obj_da_Corp.UpdShipmentStatus(txt_book.Text.ToString(), "FE", Convert.ToInt32(Session["LoginBranchid"]), "D.O. Issued");
                        obj_da_FEJob.UpdateFEEventdssenton(blno, obj_da_log.GetDate(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionid"]));
                        //  //MDIParent1.LoadOceanEvent()
                        obj_da_Corp.UpdateShipmentStatus(blno, "FE", Convert.ToInt32(txt_job.Text.ToString()), Convert.ToInt32(Session["LoginBranchid"]), "DO Issued");
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 79, 3, Convert.ToInt32(Session["LoginBranchid"]), "FE-DOCrpt");

                        str_RptName = "FEDOStatus.rpt";
                        str_sf = "{FEBLDetails.bid}=" + Session["LoginBranchid"].ToString() + " and {FEBLDetails.blno}='" + blno + "'";
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void Grd_mail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            JobInput.Text = "";
            txt_sb.Text = "";
            txt_pkgs.Text = "";
            txt_pkgtype.Text = "";
            txt_weight.Text = "";
            txt_volume.Text = "";
            txt_exporter.Text = "";
            txt_dest.Text = "";
            txt_remarks.Text = "";
            chk_invoice.Checked = false;
            txt_sb.Enabled = true;
            txt_sbdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
            UserRights();
        }

        protected void txt_customer_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                if (txt_customer.Text.Trim().ToUpper() != "")
                {
                    string[] strTemptobcc = txt_customer.Text.Split(';',',');

                     for (int i = 0; i < strTemptobcc.Length; i++)
                     {

                         if (IsValidEmailId(strTemptobcc[i].ToString().Trim().ToUpper()))
                         {
                             if (ViewState["CurrentData"] != null)
                             {
                                 DataTable dt = (DataTable)ViewState["CurrentData"];
                                 int count = dt.Rows.Count;
                                 BindGrid(count, strTemptobcc[i].ToString().Trim().ToUpper());
                             }
                             else
                             {
                                 BindGrid(1, strTemptobcc[i].ToString().Trim().ToUpper());
                             }

                            // txt_customer.Focus();
                         }
                         else
                         {
                             ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('InValid Email Format');", true);
                             txt_customer.Text = "";
                             txt_customer.Focus();
                             return;


                         }
                     }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
                    txt_customer.Text = "";
                    txt_customer.Focus();
                    return;
                }
                txt_customer.Text = "";
                txt_customer.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void Grdjob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grdjob.PageIndex = e.NewPageIndex;
                this.programmaticModalPopup1.Show();
                Grdjob.DataSource = (DataTable)ViewState["Job"];
                Grdjob.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void GrdBooking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrdBooking.PageIndex = e.NewPageIndex;
                this.programmaticModalPopup.Show();
                GrdBooking.DataSource =(DataTable) ViewState["Booking"];
                GrdBooking.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void txtpol_TextChanged(object sender, EventArgs e)
        {
            custid = portobj.GetNPortid(txtpol.Text.Trim().ToUpper());
            if (custid != 0)
            {

            }
            else
            {
                txtpol.Text = "";
                txtpol.Focus();
                ScriptManager.RegisterStartupScript(txt_pol, typeof(TextBox), "Valid", "alertify.alert('SELECT VALID PORT NAME');", true);

            }
        }

        protected void logdetails_Click(object sender, EventArgs e)
        {
            try
            {
                loadgridlog();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            if (lbl_head.Text == "Stuffing Confirmation")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 191, "Stuffing", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
            }
            else if (lbl_head.Text == "Sailing Confirmation")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 192, "Stuffing", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
            }
            else if (lbl_head.Text == "Transhipment Confirmation")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 83, "Stuffing", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
            }
            else if (lbl_head.Text == " D O Confirmation")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 80, "Stuffing", txt_job.Text, txt_job.Text, Session["StrTranType"].ToString());
            }
           
            if (txt_job.Text != "")
            {
                JobInput.Text = txt_job.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void Grd_sb_PreRender(object sender, EventArgs e)
        {
            if (Grd_sb.Rows.Count > 0)
            {
                Grd_sb.UseAccessibleHeader = true;
                Grd_sb.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_vessel_PreRender(object sender, EventArgs e)
        {
            if (Grd_vessel.Rows.Count > 0)
            {
                Grd_vessel.UseAccessibleHeader = true;
                Grd_vessel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}