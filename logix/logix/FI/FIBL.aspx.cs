using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace logix.FI
{
    public partial class FIBL : System.Web.UI.Page
    {
        DataAccess.ForwardingImports.BLDetails blobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingExports.BLDetails FEblobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterVessel vesselobj = new DataAccess.Masters.MasterVessel();
        DataAccess.Masters.MasterPackages pkgobj = new DataAccess.Masters.MasterPackages();
        DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
        DataAccess.Corporate Corpobj = new DataAccess.Corporate();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.ForwardingImports.JobInfo fijobobj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.Accounts.Invoice Invobj = new DataAccess.Accounts.Invoice();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
        DataAccess.Marketing.FIBookingwithBL FIBookingBL = new DataAccess.Marketing.FIBookingwithBL();
        DataAccess.Masters.MasterCharges ChargeObj = new DataAccess.Masters.MasterCharges();
        DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
        DataAccess.AirImportExports.AIEJobInfo objaej = new DataAccess.AirImportExports.AIEJobInfo();
        DataTable DtCargo = new DataTable();
        SqlDataAdapter adpbldetails = new SqlDataAdapter();
        System.Data.DataSet dsbldetails = new System.Data.DataSet();
        System.Data.DataSet dsshipper = new System.Data.DataSet();
        System.Data.DataSet dsconsignee = new System.Data.DataSet();
        System.Data.DataSet dsmlo = new System.Data.DataSet();
        System.Data.DataSet dsagent = new System.Data.DataSet();
        DataTable dtbl = new DataTable();
        DataTable dtbldetails = new DataTable();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        string blno;
        int j, i;
        int intjobno;
        string strbl;
        string strvessel;
        string strmbl;
        string streta;
        string stretb;
        string strpor;
        string strpol;
        string strpod;
        string strfd;
        string strshipper;
        string strconsignee;
        string stragent;
        string strSLocation;
        string strCLocation;
        string strNLocation, strcomments;
        string strALocation;
        string strmlo;
        string strnotify;
        string strSaddress;
        string strCaddress, strAgaddress, strNaddress;
        string strcustype;
        Boolean blnload;
        DateTime strbldate;
        string strNomination;
        string strcustname;
        string straddress;
        string strcontno;
        string strsizetype;
        Boolean invblr;
        string strsealno;
        int inttotal;
        int intweight;
        string BLSurrendered;
        string strisocode;
        string strscoflag;
        int intcustid;
        int intselindex;
        int intshipper;
        int intconsignee;
        int intnotify;
        int intagent;
        int intportid;
        int invoiceno;
        double amount;
        string strcharge;
        int jobAgentid;
        int jobPOLid;
        int jobPODid;
        double cbmAmt;
        double mtAmt;
        string FBase;
        int inttranshippedat;
        int IntCOMMODITY;
        int refno;
        string dgcargo;
        double unit = 0;
        int cont20;
        int cont40;
        int limit20, limit40, limit240;
        int cont;
        DataTable dtcont = new DataTable();
        double intcbm;
        string str_FornName, str_Uiid;
        int intpkgid;
        string strstatus;
        string strfreight;
        int intpor;
        int intpol;
        int intpod;
        int intfd;
        int intvessel;
        string strtranshipped;
        string strbltype;
        string intbooking;
        string strSBL;
        Boolean blnerr;
        int intCont20;
        int intCont40;

        string strtrantype;
        int divisionid;
        int branch;
        double volume;
        string voyage;
        string Status;
        DateTime jobdate;
        string strjobvessel;
        int intjobtype;
        double oldcbm;
        string submenuname;
        string quotcust;
        string sendqry;

        int intcustomerid;
        int salesPID;

        string FBooking;
        string FBLn;

        string str_booking, str_BL = "";

        Boolean blnerrUinno = false;
        Boolean blnerrGstin = false;
        Boolean blnerrUinnoGstin = false;

        Boolean bolcuststat1 = false;
        Boolean bolcuststat = false;
        string StrScript = "";

        DataTable dtinv = new DataTable();
        int Refno, Refno1;
        bool invgen, invgen1;
        string base1, strvolume, strntweight;
        double rate, exrate;
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();
        string famount;
        int refnodebitOs;
        string strTranType;
        string mblno;
        DataTable DtBLNO = new DataTable();
        int fd;
        Double douvolume, wt;
        int sizecount1;
        int refnocreditOs;
        bool DebitOS, CreditOS;
        string txt_booking = string.Empty;
        DataTable dtcust = new DataTable();
        DataAccess.ForwardingExports.BLDetails obj_da_BL = new DataAccess.ForwardingExports.BLDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);







            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            strtrantype = "FI";
            if (Request.QueryString.ToString().Contains("type"))
            {
                lbl_header.Text = Request.QueryString["type"].ToString();
            }

            if (Request.QueryString.ToString().Contains("fidirectbl"))
            {
                lbl_header.Text = Request.QueryString["fidirectbl"].ToString();
            }

            if (Request.QueryString.ToString().Contains("BLDetailsnew"))
            {
                lbl_header.Text = Request.QueryString["BLDetailsnew"].ToString();
            }
           if( Request.QueryString.ToString().Contains("1ty"))
            {
                lbl_header.Text = Request.QueryString["1ty"].ToString();
            }

             
            Session["type"] = lbl_header.Text;
            if (Session["blnofife"] != null)
            {
                txt_blno.Text = Session["blnofife"].ToString();
                lnkfrght.Visible = false;
                if (lbl_header.Text == "Split BL")
                {
                    strbltype = "S";
                    txtbookno.ReadOnly = true;
                    lbl_booking.Enabled = false;
                    txtbookno.Enabled = false;
                    chkBLSurr.Enabled = false;
                }
                else if (lbl_header.Text == "Forwarder BL")
                {
                    strbltype = "F";
                    chkBLSurr.Enabled = true;// yuvaraj 6/23
                }
                else if (lbl_header.Text == "Direct BL")
                {
                    strbltype = "D";
                    chkBLSurr.Enabled = true;
                }
                else if (lbl_header.Text == "Amendment BLDetails")
                {
                    strbltype = "A";
                    chkBLSurr.Enabled = false;

                }
                if (strbltype == "A")
                {
                    Label_2.Enabled = false;
                    Label_2.ForeColor = System.Drawing.Color.Blue;
                    lbl_booking.Enabled = false;
                    txtjobno.Enabled = false;
                    txtbookno.Enabled = false;
                }
                else
                {
                    Label_2.Enabled = true;
                    lbl_booking.Enabled = true;
                }
                txt_blno_TextChanged(sender, e);
                Session["blnofife"] = null;
                Session["type"] = null;
                return;
            }


            //txt_issuedon.Text = Utility.fn_ConvertDate(txt_issuedon.Text);
            txtbookno.Enabled = false;
            //chkNomination.Enabled = false;  ///hide on 10mar2022 as per instruction on nambi
            // lbl_booking.Enabled = false;

            if (lbl_header.Text == "Split BL")
            {
                strbltype = "S";
            }
            else if (lbl_header.Text == "Forwarder BL")
            {
                strbltype = "F";
            }
            else if (lbl_header.Text == "Direct BL")
            {
                strbltype = "D";
            }
            else if (lbl_header.Text == "Amendment BLDetails")
            {
                strbltype = "A";
            }
            if (!IsPostBack)
            {
                lblFwdBL.Text = "";
                txtIMOCode.Text = "ZZZZZ";
                txtUNOcode.Text = "ZZZ";
                hid_reuse.Value = "";
                DateTime issueon = Convert.ToDateTime(Logobj.GetDate().ToString());
                txt_issuedon.Text = issueon.ToString("dd/MM/yyyy");

                txtjobno.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txtcbm.Attributes.Add("OnKeypress", "return validateFloatKeyPress(this,event,'CBM')");
                txtgrossw.Attributes.Add("OnKeypress", "return validateFloatKeyPress(this,event,'Gross Weight')");
                txtnetw.Attributes.Add("OnKeypress", "return validateFloatKeyPress(this,event,'Net Weight')");
                txtpackage.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                lnkfrght.Visible = false;
                if (lbl_header.Text == "Split BL")
                {
                    strbltype = "S";
                    txtbookno.ReadOnly = true;
                    lbl_booking.Enabled = false;
                    txtbookno.Enabled = false;
                    chkBLSurr.Enabled = true;
                }
                else if (lbl_header.Text == "Forwarder BL")
                {
                    strbltype = "F";
                    chkBLSurr.Enabled = true;// yuvaraj 6/23
                }
                else if (lbl_header.Text == "Direct BL")
                {
                    strbltype = "D";
                    chkBLSurr.Enabled = true;
                }
                else if (lbl_header.Text == "Amendment BLDetails")
                {
                    strbltype = "A";
                    chkBLSurr.Enabled = false;
                }
                if (strbltype == "A")
                {
                    Label_2.Enabled = false;
                    Label_2.ForeColor = System.Drawing.Color.Blue;

                    lbl_booking.Enabled = false;
                    txtjobno.Enabled = false;
                    txtbookno.Enabled = false;
                }
                else
                {
                    Label_2.Enabled = true;
                    Label_2.ForeColor = System.Drawing.Color.Red;
                    lbl_booking.Enabled = true;
                }
                ddlfreight.Items.Add("PrePaid");
                ddlfreight.Items.Add("collect");
                ddlstatus.Items.Add("FCL/FCL");
                ddlstatus.Items.Add("FCL/LCL");
                ddlstatus.Items.Add("LCL/LCL");
                ddlstatus.Items.Add("LCL/FCL");
                //grdjob.Visible = false;
                grdMBLDetails.Visible = false;
                //grdBooking.Visible = False         

                PackageFill();

                txtnetw.Text = "";
                btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                salesPID = 0;
                if (Request.QueryString.ToString().Contains("blno"))
                {
                    txt_blno.Text = Request.QueryString["blno"].ToString();
                    // lbl_header.Text = "Amendment BLDetails";
                    txt_blno_TextChanged(sender, e);
                }
                if (Request.QueryString.ToString().Contains("BLDetailsnew"))
                {
                    if (Request.QueryString.ToString().Contains("jobno"))
                    {
                        txtjobno.Text = Request.QueryString["jobno"].ToString();
                        txtjobno_TextChanged(sender, e);
                    }

                    if (Request.QueryString.ToString().Contains("bookingno"))
                    {
                        txtbookno.Text = Request.QueryString["bookingno"].ToString();
                        if (txtbookno.Text != "0" || txtbookno.Text != "")
                        {
                            dtbldetails = blobj.GetBookingDtls(txtbookno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            if (dtbldetails.Rows.Count > 0)
                            {
                                intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                            }
                            if (intcustomerid != 0)
                            {
                                string consigneeid = intcustomerid.ToString();
                                Hiddenconsignee.Value = consigneeid;
                                dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(intcustomerid));
                            }
                            txt_booking = txtbookno.Text;
                            bookingdetails();


                            //if (dtcust.Rows.Count > 0) ///hide on 10mar2022 as per instruction on nambi
                            //{
                            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                            //    btn_save.Visible = false;
                            //    return;

                            //}
                        }

                        // chkNomination.Checked = true;  ///hide on 10mar2022 as per instruction on nambi
                    }



                }

                UserRights();
                //  chkNomination.Checked = true;  ///hide on 10mar2022 as per instruction on nambi
            }
            if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }
            headerlabel.InnerText = lbl_header.Text;

            string BL_No = Request.QueryString["BL_No"];

            if (BL_No != null)
            {
                //menu_itm.Visible = true;
                txt_blno.Text = BL_No;
                //lbl_header.Text = "Our BL";
                lbl_header.Text = "Direct BL";
                txt_blno_TextChanged(sender, e);

                btn_delete.Visible = false;
                btn_save.Visible = false;
                Btn_reuse.Visible = false;
                btn_blrelease.Visible = false;
                procrednote.Visible = false;
                Proinvoic.Visible = false;

            }
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

        [WebMethod]
        public static List<string> getlikeport(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            portobj.GetDataBase(Ccode);
            DataTable dtport = new DataTable();
            dtport = portobj.GetLikePort(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dtport, "portname", "portid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikeshipper(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string custype = "C";
            dt = customerobj.GetLikeCustomer(prefix.ToUpper(), custype);
            list_result = Utility.Fn_DatatableToList_CustomerAddress2(dt, "customer", "customername", "customerid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikeconsignee(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string custype = "C";
            dt = customerobj.GetLikeCustomer(prefix.ToUpper(), custype);
            list_result = Utility.Fn_DatatableToList_CustomerAddress2(dt, "customer", "customername", "customerid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikenotify(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string custype = "C";
            dt = customerobj.GetLikeCustomer(prefix.ToUpper(), custype);
            list_result = Utility.Fn_DatatableToList_CustomerAddress2(dt, "customer", "customername", "customerid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikeagent(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            string custype = "P";
            dt = customerobj.GetLikeCustomer(prefix.ToUpper(), custype);
            list_result = Utility.Fn_DatatableToList_CustomerAddress2(dt, "customer", "customername", "customerid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikereceipt(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            portobj.GetDataBase(Ccode);
            DataTable dtport = new DataTable();
            dtport = portobj.GetLikePort(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dtport, "portname", "portid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikeloading(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            portobj.GetDataBase(Ccode);
            DataTable dtport = new DataTable();
            dtport = portobj.GetLikePort(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dtport, "portname", "portid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikevessel(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterVessel vesselobj = new DataAccess.Masters.MasterVessel();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            vesselobj.GetDataBase(Ccode);
            DataTable dtport = new DataTable();
            dtport = vesselobj.GetLikeVessel(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dtport, "vesselname", "vesselid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikecharge(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            portobj.GetDataBase(Ccode);
            DataTable dtport = new DataTable();
            dtport = portobj.GetLikePort(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dtport, "portname", "portid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikecargo(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
            DataTable dt = new DataTable();
            dt = cargoobj.GetLikeCargo(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dt, "cargotype", "cargoid");
            return list_result;
        }

        [WebMethod]
        public static List<string> getlikefinal(string prefix)
        {
            List<string> list_result = new List<string>();
            DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            portobj.GetDataBase(Ccode);
            DataTable dtport = new DataTable();
            dtport = portobj.GetLikePort(prefix.ToUpper());
            list_result = Utility.Fn_TableToList(dtport, "portname", "portid");
            return list_result;
        }

        public void PackageFill()
        {
            dtbl = pkgobj.GetPackagenames();
            ddlunits.Items.Clear();
            ddlunits.Items.Add("");
            for (int i = 0; i < dtbl.Rows.Count - 1; i++)
            {
                ddlunits.Items.Add(dtbl.Rows[i].ItemArray[0].ToString());
            }

        }

        [WebMethod]
        public static List<string> getlikebl(string prefix)
        {
            string type = (string)HttpContext.Current.Session["type"];
            List<string> list_result = new List<string>();
            int branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]);
            int divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]);
            if (type == "Direct BL" || type == "Amendment BLDetails")
            {
                DataAccess.ForwardingImports.BLDetails blobj = new DataAccess.ForwardingImports.BLDetails();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                blobj.GetDataBase(Ccode);
                DataTable dt = new DataTable();
                //blobj.GetLikeBL(txtbl.Text, Login.branchid, Login.divisionid)
                dt = blobj.GetLikeBL(prefix.ToUpper(), branchid, divisionid);
                list_result = Utility.Fn_DatatableToList_Text(dt, "blno");
            }
            //else if (type == "Forwarder  BL")
            else if (type == "Forwarder BL")
            {
                DataAccess.ForwardingImports.BLDetails blobj = new DataAccess.ForwardingImports.BLDetails();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                blobj.GetDataBase(Ccode);
                DataTable dt1 = new DataTable();
                dt1 = blobj.GetLikeFBL(prefix.ToUpper(), branchid, divisionid);
                list_result = Utility.Fn_DatatableToList_Text(dt1, "blno");
            }
            else
            {
                DataAccess.ForwardingImports.BLDetails blobj = new DataAccess.ForwardingImports.BLDetails();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                blobj.GetDataBase(Ccode);
                DataTable dt1 = new DataTable();
                dt1 = blobj.GetLikeSBL(prefix.ToUpper(), branchid, divisionid);
                list_result = Utility.Fn_DatatableToList_Text(dt1, "blno");
            }
            return list_result;
        }

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    if (Request.QueryString.ToString().Contains("uiid"))
                    {
                        str_Uiid = Request.QueryString["uiid"].ToString();
                        Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, btn_delete);
                        DataTable obj_Dtuser = new DataTable();
                        obj_Dtuser = (DataTable)Session["dt_UserRights"];
                        DataView obj_dtview = new DataView(obj_Dtuser);
                        obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                        obj_Dtuser = obj_dtview.ToTable();
                    }
                    else
                    {
                        return;
                    }

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

        public void bookingdetails()
        {
            //DataAccess.ForwardingExports.BLDetails obj_da_BL = new //DataAccess.ForwardingExports.BLDetails();
            //DataAccess.LogDetails obj_da_Log = new //DataAccess.LogDetails();
            DataTable obj_dt = new DataTable();

            obj_dt = obj_da_BL.GetBookingDt(txt_booking, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));

            if (obj_dt.Rows.Count > 0)
            {
                txt_blno.ReadOnly = true;
                txt_blno.Text = obj_dt.Rows[0]["shiprefno"].ToString();
                txt_blno.Text = txt_blno.Text.ToUpper();

                hid_quto.Value = obj_dt.Rows[0]["quotno"].ToString();
                hid_buyingno.Value = obj_dt.Rows[0]["buyingno"].ToString();

                txtreceipt.Text = obj_dt.Rows[0]["por"].ToString();
                Hiddenrecipt.Value = obj_dt.Rows[0]["porid"].ToString();

                txtpol.Text = obj_dt.Rows[0]["pol"].ToString();
                Hiddenpol.Value = obj_dt.Rows[0]["polid"].ToString();

                txtpodis.Text = obj_dt.Rows[0]["pod"].ToString();
                hiddencharge.Value = obj_dt.Rows[0]["podid"].ToString();

                txtfinaldes.Text = obj_dt.Rows[0]["fd"].ToString();
                Hiddentxtfinaldes.Value = obj_dt.Rows[0]["fdid"].ToString();
                //hid_salesid.Value = obj_dt.Rows[0]["salesid"].ToString();
                //ddlfreight.SelectedItem.Text = obj_dt.Rows[0]["fstatus"].ToString();
                //string strfreight = obj_dt.Rows[0]["fstatus"].ToString();
                //if (strfreight == "P")
                //{
                //    ddlfreight.Text = "PrePaid";
                //}
                //else
                //{
                //    ddlfreight.Text = "collect";
                //} 
                Hiddenshipper.Value = obj_dt.Rows[0]["shipperid"].ToString();
                if (Hiddenshipper.Value != "")
                {
                    txtshipper.Text = obj_dt.Rows[0]["shippername"].ToString();
                    txtsaddress.Text = txtshipper.Text + System.Environment.NewLine + obj_dt.Rows[0]["shipperaddressnew"].ToString();
                    Hiddenshipper.Value = obj_dt.Rows[0]["shipperid"].ToString();
                    // hid_intcustomerid.Value = Hiddenshipper.Value;
                }
                else
                {
                    txtshipper.Text = "";
                    txtsaddress.Text = "";
                    Hiddenshipper.Value = "0";
                }

                txtcargo.Text = obj_dt.Rows[0]["cargotype"].ToString();
                hiddencargo.Value = obj_dt.Rows[0]["cargoid"].ToString();

                if (obj_dt.Rows[0]["agentcustomertype"].ToString() == "P")
                {
                    txtagent.Text = obj_dt.Rows[0]["agent"].ToString();
                    txtaaddress.Text = txtagent.Text + System.Environment.NewLine + obj_dt.Rows[0]["agentaddress"].ToString();
                    Hiddenagent.Value = obj_dt.Rows[0]["agentid"].ToString();
                }
                else
                {
                    txtagent.Text = "";
                    txtaaddress.Text = "";
                    Hiddenagent.Value = "0";
                }

                if (obj_dt.Rows[0]["consigneecustomertype"].ToString() == "C")
                {
                    txtconsignee.Text = obj_dt.Rows[0]["consignee"].ToString();
                    txtcaddress.Text = txtconsignee.Text + System.Environment.NewLine + obj_dt.Rows[0]["consigneeaddress"].ToString();
                    Hiddenconsignee.Value = obj_dt.Rows[0]["consigneeid"].ToString();
                }
                else
                {
                    txtconsignee.Text = "";
                    txtcaddress.Text = "";
                    Hiddenconsignee.Value = "0";
                }

                //txtdescn.Text = obj_dt.Rows[0]["descn"].ToString();              
            }
        }

        protected void fn_Getforwarderdetailsforsplit(string blnosplit)
        {
            if (blnosplit != "")
            {
                DataTable dtsp = new DataTable();

                dtsp = blobj.ShowFBLDetails(blnosplit, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtsp.Rows.Count > 0)
                {
                    double temp1 = 0.0, temp2 = 0.0;
                    chkListCont.Items.Clear();
                    txtjobno.Text = "";
                    intjobno = Convert.ToInt32(dtsp.Rows[0].ItemArray[0].ToString());
                    hd_jobno.Value = intjobno.ToString(); ;
                    txtCaption.Text = blobj.GetJobDetails(intjobno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    intportid = Convert.ToInt32(dtsp.Rows[0].ItemArray[1].ToString());
                    hiddenid_issue.Value = intportid.ToString();
                    strbldate = Convert.ToDateTime(dtsp.Rows[0].ItemArray[2].ToString());
                    strfreight = dtsp.Rows[0].ItemArray[3].ToString();
                    strstatus = dtsp.Rows[0].ItemArray[33].ToString();
                    //intshipper = Convert.ToInt32(dtsp.Rows[0].ItemArray[4].ToString());
                    //Hiddenshipper.Value = intshipper.ToString();
                    //strshipper = dtsp.Rows[0].ItemArray[5].ToString();
                    //strSaddress = dtsp.Rows[0].ItemArray[6].ToString();
                    //intconsignee = Convert.ToInt32(dtsp.Rows[0].ItemArray[7].ToString());
                    //Hiddenconsignee.Value = intconsignee.ToString();
                    //strconsignee = dtsp.Rows[0].ItemArray[8].ToString();
                    //strCaddress = dtsp.Rows[0].ItemArray[9].ToString();
                    //intnotify = Convert.ToInt32(dtsp.Rows[0].ItemArray[10].ToString());
                    //Hiddennotify.Value = intnotify.ToString();
                    //strnotify = dtsp.Rows[0].ItemArray[11].ToString();
                    //strNaddress = dtsp.Rows[0].ItemArray[12].ToString();
                    intagent = Convert.ToInt32(dtsp.Rows[0].ItemArray[13].ToString());
                    Hiddenagent.Value = intagent.ToString();
                    intpor = Convert.ToInt32(dtsp.Rows[0].ItemArray[14].ToString());
                    Hiddenrecipt.Value = intpor.ToString();
                    intpol = Convert.ToInt32(dtsp.Rows[0].ItemArray[15].ToString());
                    Hiddenpol.Value = intpol.ToString();
                    intpod = Convert.ToInt32(dtsp.Rows[0].ItemArray[16].ToString());
                    hiddencharge.Value = intpod.ToString();
                    intfd = Convert.ToInt32(dtsp.Rows[0].ItemArray[17].ToString());
                    Hiddentxtfinaldes.Value = intfd.ToString();
                    //Convert.ToInt32(Hiddentxtfinaldes.Value)
                    intpkgid = Convert.ToInt32(dtsp.Rows[0].ItemArray[29].ToString());
                    intvessel = Convert.ToInt32(dtsp.Rows[0].ItemArray[24].ToString());
                    Hiddenvessel.Value = intvessel.ToString();
                    inttranshippedat = Convert.ToInt32(dtsp.Rows[0].ItemArray[26].ToString());
                    hiddenidtrans.Value = inttranshippedat.ToString();
                    txt_issuedon.Text = strbldate.ToString("dd/MM/yyyy");
                    txtmarksnumbers.Text = dtsp.Rows[0].ItemArray[18].ToString();
                    txtdescn.Text = dtsp.Rows[0].ItemArray[19].ToString();
                    // txtcbm.Text = dtsp.Rows[0].ItemArray[20].ToString();
                    oldcbm = Convert.ToDouble(dtsp.Rows[0].ItemArray[20].ToString());
                    //temp1 =Convert.ToDouble(dtsp.Rows[0].ItemArray[21].ToString());
                    //txtgrossw.Text = temp1.ToString();                       
                    //temp2=Convert.ToDouble(dtsp.Rows[0].ItemArray[22].ToString());
                    //txtnetw.Text = temp2.ToString();
                    txtpackage.Text = dtsp.Rows[0].ItemArray[23].ToString();
                    txtUNOcode.Text = dtsp.Rows[0].ItemArray[27].ToString();
                    txtIMOCode.Text = dtsp.Rows[0].ItemArray[28].ToString();
                    // txtremarks.Text = dtsp.Rows[0]["remarks"].ToString();
                    txtMVoy.Text = dtsp.Rows[0].ItemArray[25].ToString();
                    string cargoidd = dtsp.Rows[0]["cargoid"].ToString();
                    if (cargoidd != "")
                    {
                        IntCOMMODITY = Convert.ToInt32(dtsp.Rows[0]["cargoid"].ToString());
                        //hiddencargo.Value = IntCOMMODITY.ToString();                           
                        hiddencargo.Value = IntCOMMODITY.ToString();
                        txtcargo.Text = cargoobj.GetCargoname(Convert.ToInt32(hiddencargo.Value));


                    }
                    //strSLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenshipper.Value));
                    //strCLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenconsignee.Value));
                    //strNLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddennotify.Value));

                    //if (lbl_header.Text == "Split BL" || lbl_header.Text == "Direct BL")
                    //{
                    //    strSBL = dtsp.Rows[0].ItemArray[34].ToString();
                    //    FBLn = strSBL;
                    //    lblFwdBL.Text = "Forwarder BL # :" + strSBL;
                    //    string blsurrendered = dtsp.Rows[0]["blsurrendered"].ToString();
                    //    if (blsurrendered == "Y")
                    //    {
                    //        chkBLSurr.Checked = true;
                    //    }
                    //    else
                    //    {
                    //        chkBLSurr.Checked = false;
                    //    }
                    //}

                    string nomination = dtsp.Rows[0].ItemArray[30].ToString();
                    if (nomination == "N")
                    {
                        chkNomination.Checked = true;
                    }
                    else
                    {
                        chkNomination.Checked = false;
                    }
                    if (!string.IsNullOrEmpty(blnosplit))
                    {
                        FBooking = blobj.GetBookinkNo(blnosplit, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                        txtbookno.Text = FBooking;
                        dtbldetails = blobj.GetBookingDtls(FBooking, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                        if (dtbldetails.Rows.Count > 0)
                        {
                            intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                            salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                            if (salesPID != 0)
                            {
                                Hiddensalespid.Value = salesPID.ToString();
                            }
                            else
                            {
                                Hiddensalespid.Value = "0";
                            }

                            chkNomination.Checked = true;
                        }
                    }
                }
                else
                {
                    if (txtbookno.Text == "")
                    {
                        txtbookno.Text = "";
                    }
                }
                if (strfreight == "P")
                {
                    ddlfreight.Text = "PrePaid";
                }
                else
                {
                    ddlfreight.Text = "collect";
                }
                txtjobno.Text = intjobno.ToString();
                //txtshipper.Text = strshipper;
                //txtsaddress.Text = strSaddress;
                //txtconsignee.Text = strconsignee;
                //txtcaddress.Text = strCaddress;
                //txtnotify.Text = strnotify;
                //txtnaddress.Text = strNaddress;
                stragent = customerobj.GetCustomername(Convert.ToInt32(Hiddenagent.Value));
                strALocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenagent.Value));
                strAgaddress = customerobj.GetCustomerAddress(stragent, "Agent / Principal", strALocation);
                txtagent.Text = stragent;
                txtaaddress.Text = strAgaddress;
                txtreceipt.Text = portobj.GetPortname(Convert.ToInt32(Hiddenrecipt.Value));
                txtpol.Text = portobj.GetPortname(Convert.ToInt32(Hiddenpol.Value));
                txtpodis.Text = portobj.GetPortname(intpod);
                txtfinaldes.Text = portobj.GetPortname(Convert.ToInt32(Hiddentxtfinaldes.Value));
                txt_blissuseat.Text = portobj.GetPortname(Convert.ToInt32(hiddenid_issue.Value));
                if (strstatus == "1")
                {
                    ddlstatus.Text = "FCL/FCL";
                }
                else if (strstatus == "2")
                {
                    ddlstatus.Text = "FCL/LCL";
                }
                else if (strstatus == "3")
                {
                    ddlstatus.Text = "LCL/LCL";
                }
                else if (strstatus == "4")
                {
                    ddlstatus.Text = "LCL/FCL";
                }

                ddlunits.SelectedValue = pkgobj.GetPackagename(intpkgid);
                txtMVessel.Text = vesselobj.GetVesselname(Convert.ToInt32(Hiddenvessel.Value));
                txtTranshipped.Text = portobj.GetPortname(Convert.ToInt32(hiddenidtrans.Value));
                dtsp = blobj.GetContainerDetail(intjobno, intjobno.ToString(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));

                if (dtsp.Rows.Count > 0)
                {
                    chkListCont.Items.Clear();
                    for (int i = 0; i <= dtsp.Rows.Count - 1; i++)
                    {
                        chkListCont.Items.Add(dtsp.Rows[i].ItemArray[0].ToString());
                    }
                }
                if (lbl_header.Text == "Amendment BLDetails")
                {
                    dtsp = blobj.GetAmendContainerName(intjobno, blnosplit, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                    if (dtsp.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        dtsp = blobj.GetContainerName(intjobno, blnosplit, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                    }
                }
                else
                {
                    dtsp = blobj.GetContainerName(intjobno, blnosplit, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                }

                if (dtsp.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtsp.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= chkListCont.Items.Count - 1; j++)
                        {
                            if (dtsp.Rows[i][0].ToString() == chkListCont.Items[j].ToString())
                            {
                                chkListCont.Items[j].Selected = true;
                            }

                        }
                    }
                }
                dtsp = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                if (dtsp.Rows.Count > 0)
                {
                    intjobtype = Convert.ToInt32(dtsp.Rows[0].ItemArray[0].ToString());
                    hid_jobtype.Value = intjobtype.ToString();
                    jobAgentid = Convert.ToInt32(dtsp.Rows[0]["agent"].ToString());
                    hiddenjobagentid.Value = jobAgentid.ToString();
                    jobPOLid = Convert.ToInt32(dtsp.Rows[0]["pol"].ToString());
                    hiddenjobpolid.Value = jobPOLid.ToString();
                    jobPODid = Convert.ToInt32(dtsp.Rows[0]["pod"].ToString());
                    hiddenjobpodid.Value = jobPODid.ToString();
                }


            }
        }
        protected void txt_blno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_blno.Text != "")
                {
                    /*string type = (string)HttpContext.Current.Session["type"];
                    int blno_id = 0;
                    if (type == "Direct BL" || type == "Amendment BLDetails")
                    {
                        //DataAccess.ForwardingImports.BLDetails blobj = new //DataAccess.ForwardingImports.BLDetails();
                        DataTable dt = new DataTable();
                        dt = blobj.GetLikeBL(txt_blno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (txt_blno.Text == dt.Rows[i][0].ToString())
                            {
                                blno_id = 1;
                            }
                        }
                        if (blno_id == 0)
                        {
                            txt_blno.Text = "";
                            txt_blno.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid BILL OF LADING');", true);
                            return;
                        }
                    }
                    else if (type == "Forwarder BL")
                    {
                        //DataAccess.ForwardingImports.BLDetails blobj = new //DataAccess.ForwardingImports.BLDetails();
                        DataTable dt = new DataTable();
                        dt = blobj.GetLikeFBL(txt_blno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (txt_blno.Text == dt.Rows[i][0].ToString())
                            {
                                blno_id = 1;
                            }
                        }
                        if (blno_id == 0)
                        {
                            txt_blno.Text = "";
                            txt_blno.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid BILL OF LADING');", true);
                            return;
                        }
                    }
                    else
                    {
                        //DataAccess.ForwardingImports.BLDetails blobj = new //DataAccess.ForwardingImports.BLDetails();
                        DataTable dt = new DataTable();
                        dt = blobj.GetLikeSBL(txt_blno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (txt_blno.Text == dt.Rows[i][0].ToString())
                            {
                                blno_id = 1;
                            }
                        }
                        if (blno_id == 0)
                        {
                            txt_blno.Text = "";
                            txt_blno.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid BILL OF LADING');", true);
                            return;
                        }
                    }*/

                    btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    if (lbl_header.Text != "Forwarder BL")
                    {
                        lnkfrght.Visible = true;
                    }
                    txt_blno.Text = txt_blno.Text.Trim();
                    DataTable dtbook = new DataTable();
                    dtbook = FIBookingBL.CheckAssociatedBLs(Convert.ToInt32(Session["LoginBranchId"].ToString()), txt_blno.Text, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtbook.Rows.Count > 0)
                    {
                        txtbookno.Text = dtbook.Rows[0]["bookingno"].ToString();
                        txtconsignee.Text = dtbook.Rows[0]["customername"].ToString();
                        txtcbm.Text = dtbook.Rows[0]["cbm"].ToString();
                        txtgrossw.Text = dtbook.Rows[0]["grweight"].ToString();
                        txtnetw.Text = dtbook.Rows[0]["netweight"].ToString();
                        string chars = dtbook.Rows[0]["blstatus"].ToString();
                        if (chars == "S")
                        {
                            chkBLSurr.Checked = true;
                        }
                        else
                        {
                            chkBLSurr.Checked = false;
                        }
                        chkNomination.Checked = true;
                    }
                    dtbl = fijobobj.GetLikeMBLNo(txt_blno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtbl.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                        {
                            string bltext = dtbl.Rows[i].ItemArray[0].ToString().ToUpper();
                            if (bltext.ToUpper() == txt_blno.Text.ToUpper())
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                                txt_blno.Focus();
                                return;
                            }
                        }
                    }
                    if (lbl_header.Text == "Split BL" || lbl_header.Text == "Direct BL")
                    {
                        dtbl = blobj.ShowBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }
                    else if (lbl_header.Text == "Forwarder BL")
                    {
                        dtbl = blobj.ShowFBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }
                    else if (lbl_header.Text == "Amendment BLDetails")
                    {
                        dtbl = blobj.ShowAmendBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            dtbl = blobj.ShowBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                    }

                    if (dtbl.Rows.Count > 0)
                    {
                        double temp1 = 0.0, temp2 = 0.0;
                        chkListCont.Items.Clear();
                        txtjobno.Text = "";
                        intjobno = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                        hd_jobno.Value = intjobno.ToString(); ;
                        txtCaption.Text = blobj.GetJobDetails(intjobno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        intportid = Convert.ToInt32(dtbl.Rows[0].ItemArray[1].ToString());
                        hiddenid_issue.Value = intportid.ToString();
                        strbldate = Convert.ToDateTime(dtbl.Rows[0].ItemArray[2].ToString());
                        strfreight = dtbl.Rows[0].ItemArray[3].ToString();
                        strstatus = dtbl.Rows[0].ItemArray[33].ToString();
                        intshipper = Convert.ToInt32(dtbl.Rows[0].ItemArray[4].ToString());
                        Hiddenshipper.Value = intshipper.ToString();
                        strshipper = dtbl.Rows[0].ItemArray[5].ToString();
                        strSaddress = dtbl.Rows[0].ItemArray[6].ToString();
                        intconsignee = Convert.ToInt32(dtbl.Rows[0].ItemArray[7].ToString());
                        Hiddenconsignee.Value = intconsignee.ToString();
                        strconsignee = dtbl.Rows[0].ItemArray[8].ToString();
                        strCaddress = dtbl.Rows[0].ItemArray[9].ToString();
                        intnotify = Convert.ToInt32(dtbl.Rows[0].ItemArray[10].ToString());
                        Hiddennotify.Value = intnotify.ToString();
                        strnotify = dtbl.Rows[0].ItemArray[11].ToString();
                        strNaddress = dtbl.Rows[0].ItemArray[12].ToString();
                        intagent = Convert.ToInt32(dtbl.Rows[0].ItemArray[13].ToString());
                        Hiddenagent.Value = intagent.ToString();
                        intpor = Convert.ToInt32(dtbl.Rows[0].ItemArray[14].ToString());
                        Hiddenrecipt.Value = intpor.ToString();
                        intpol = Convert.ToInt32(dtbl.Rows[0].ItemArray[15].ToString());
                        Hiddenpol.Value = intpol.ToString();
                        intpod = Convert.ToInt32(dtbl.Rows[0].ItemArray[16].ToString());
                        hiddencharge.Value = intpod.ToString();
                        intfd = Convert.ToInt32(dtbl.Rows[0].ItemArray[17].ToString());
                        Hiddentxtfinaldes.Value = intfd.ToString();
                        //Convert.ToInt32(Hiddentxtfinaldes.Value)
                        intpkgid = Convert.ToInt32(dtbl.Rows[0].ItemArray[29].ToString());
                        intvessel = Convert.ToInt32(dtbl.Rows[0].ItemArray[24].ToString());
                        Hiddenvessel.Value = intvessel.ToString();
                        inttranshippedat = Convert.ToInt32(dtbl.Rows[0].ItemArray[26].ToString());
                        hiddenidtrans.Value = inttranshippedat.ToString();
                        txt_issuedon.Text = strbldate.ToString("dd/MM/yyyy");
                        txtmarksnumbers.Text = dtbl.Rows[0].ItemArray[18].ToString();
                        txtdescn.Text = dtbl.Rows[0].ItemArray[19].ToString();
                        txtcbm.Text = dtbl.Rows[0].ItemArray[20].ToString();
                        oldcbm = Convert.ToDouble(dtbl.Rows[0].ItemArray[20].ToString());
                        temp1 = Convert.ToDouble(dtbl.Rows[0].ItemArray[21].ToString());
                        txtgrossw.Text = temp1.ToString();
                        temp2 = Convert.ToDouble(dtbl.Rows[0].ItemArray[22].ToString());
                        txtnetw.Text = temp2.ToString();
                        txtpackage.Text = dtbl.Rows[0].ItemArray[23].ToString();
                        txtUNOcode.Text = dtbl.Rows[0].ItemArray[27].ToString();
                        txtIMOCode.Text = dtbl.Rows[0].ItemArray[28].ToString();
                        txtremarks.Text = dtbl.Rows[0]["remarks"].ToString();
                        txtMVoy.Text = dtbl.Rows[0].ItemArray[25].ToString();
                        string cargoidd = dtbl.Rows[0]["cargoid"].ToString();
                        if (cargoidd != "")
                        {
                            IntCOMMODITY = Convert.ToInt32(dtbl.Rows[0]["cargoid"].ToString());
                            //hiddencargo.Value = IntCOMMODITY.ToString();                           
                            hiddencargo.Value = IntCOMMODITY.ToString();
                            txtcargo.Text = cargoobj.GetCargoname(Convert.ToInt32(hiddencargo.Value));


                        }
                        strSLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenshipper.Value));
                        strCLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenconsignee.Value));
                        strNLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddennotify.Value));

                        if (lbl_header.Text == "Split BL" || lbl_header.Text == "Direct BL")
                        {
                            strSBL = dtbl.Rows[0].ItemArray[34].ToString();
                            FBLn = strSBL;
                            //lblFwdBL.Text = "Forwarder BL # :" + strSBL; feb 22 23
                            string forwarder = dtbl.Rows[0].ItemArray[40].ToString();
                            if (strSBL != "")
                            {
                                string forwarderaddress = dtbl.Rows[0].ItemArray[41].ToString();
                                FBLn = strSBL;
                                lblFwdBL.Text = "<span>" + "<b>Forwarder BL # : </b>" + strSBL + " // " + "<b>Forwarder Details : </b>" + forwarder + "</span> <br/>" + "<span>" + "<b>Forwarder Address : </b>" + forwarderaddress + "</span>";
                            }

                            string blsurrendered = dtbl.Rows[0]["blsurrendered"].ToString();
                            if (blsurrendered == "Y")
                            {
                                chkBLSurr.Checked = true;
                            }
                            else
                            {
                                chkBLSurr.Checked = false;
                            }
                        }
                        if (lbl_header.Text == "Forwarder BL")
                        {
                            string blsurrendered = dtbl.Rows[0]["fblsurrendered"].ToString();
                            if (blsurrendered == "Y")
                            {
                                chkBLSurr.Checked = true;
                            }
                            else
                            {
                                chkBLSurr.Checked = false;
                            }
                        }

                        string nomination = dtbl.Rows[0].ItemArray[30].ToString();
                        if (nomination == "N")
                        {
                            chkNomination.Checked = true;
                        }
                        else
                        {
                            chkNomination.Checked = false;
                        }
                        if (!string.IsNullOrEmpty(FBLn))
                        {
                            FBooking = blobj.GetBookinkNo(FBLn, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            txtbookno.Text = FBooking;
                            dtbldetails = blobj.GetBookingDtls(FBooking, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            if (dtbldetails.Rows.Count > 0)
                            {
                                intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                                salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                                if (salesPID != 0)
                                {
                                    Hiddensalespid.Value = salesPID.ToString();
                                }
                                else
                                {
                                    Hiddensalespid.Value = "0";
                                }

                                chkNomination.Checked = true;
                            }
                        }
                        if (chkNomination.Checked == true)
                        {
                            if (lbl_header.Text == "Split BL")
                            {
                                FBooking = blobj.GetBookinkNo(FBLn, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                dtbldetails = blobj.GetBookingDtls(FBooking, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                if (dtbldetails.Rows.Count > 0)
                                {
                                    intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                                    salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                                    if (salesPID != 0)
                                    {
                                        Hiddensalespid.Value = salesPID.ToString();
                                    }
                                    else
                                    {
                                        Hiddensalespid.Value = "0";
                                    }

                                }
                            }
                            else
                            {
                                string booking = blobj.GetBookinkNo(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                if (booking == "")
                                {
                                    if (txtbookno.Text == "")
                                    {
                                        txtbookno.Text = "";
                                    }
                                }
                                else
                                {
                                    txtbookno.Text = blobj.GetBookinkNo(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                    dtbldetails = blobj.GetBookingDtls(txtbookno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                    if (dtbldetails.Rows.Count > 0)
                                    {
                                        intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                                        salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                                        if (salesPID != 0)
                                        {
                                            Hiddensalespid.Value = salesPID.ToString();
                                        }
                                        else
                                        {
                                            Hiddensalespid.Value = "0";
                                        }
                                        //Hiddensalespid.Value = salesPID.ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (txtbookno.Text == "")
                            {
                                txtbookno.Text = "";
                            }
                        }
                        if (strfreight == "P")
                        {
                            ddlfreight.Text = "PrePaid";
                        }
                        else
                        {
                            ddlfreight.Text = "collect";
                        }
                        txtjobno.Text = intjobno.ToString();
                        txtshipper.Text = strshipper;
                        txtsaddress.Text = strSaddress;
                        txtconsignee.Text = strconsignee;
                        txtcaddress.Text = strCaddress;
                        txtnotify.Text = strnotify;
                        txtnaddress.Text = strNaddress;
                        stragent = customerobj.GetCustomername(Convert.ToInt32(Hiddenagent.Value));
                        strALocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenagent.Value));
                        strAgaddress = customerobj.GetCustomerAddress(stragent, "Agent / Principal", strALocation);
                        txtagent.Text = stragent;
                        txtaaddress.Text = strAgaddress;
                        txtreceipt.Text = portobj.GetPortname(Convert.ToInt32(Hiddenrecipt.Value));
                        txtpol.Text = portobj.GetPortname(Convert.ToInt32(Hiddenpol.Value));
                        txtpodis.Text = portobj.GetPortname(intpod);
                        txtfinaldes.Text = portobj.GetPortname(Convert.ToInt32(Hiddentxtfinaldes.Value));
                        txt_blissuseat.Text = portobj.GetPortname(Convert.ToInt32(hiddenid_issue.Value));

                        DataTable dt;
                        //DataAccess.Masters.MasterPort obj_MasterPort = new //DataAccess.Masters.MasterPort();
                        dt = obj_MasterPort.SelPortName4typepadimg(txtfinaldes.Text.ToUpper(), Session["StrTranType"].ToString());
                        fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txtreceipt.Text.ToUpper(), Session["StrTranType"].ToString());
                        porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txtpodis.Text.ToUpper(), Session["StrTranType"].ToString());
                        podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txtpol.Text.ToUpper(), Session["StrTranType"].ToString());
                        flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";


                        if (strstatus == "1")
                        {
                            ddlstatus.Text = "FCL/FCL";
                        }
                        else if (strstatus == "2")
                        {
                            ddlstatus.Text = "FCL/LCL";
                        }
                        else if (strstatus == "3")
                        {
                            ddlstatus.Text = "LCL/LCL";
                        }
                        else if (strstatus == "4")
                        {
                            ddlstatus.Text = "LCL/FCL";
                        }

                        ddlunits.SelectedValue = pkgobj.GetPackagename(intpkgid);
                        txtMVessel.Text = vesselobj.GetVesselname(Convert.ToInt32(Hiddenvessel.Value));
                        txtTranshipped.Text = portobj.GetPortname(Convert.ToInt32(hiddenidtrans.Value));
                        dtbl = blobj.GetContainerDetail(intjobno, intjobno.ToString(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));

                        if (dtbl.Rows.Count > 0)
                        {
                            chkListCont.Items.Clear();
                            for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                            {
                                chkListCont.Items.Add(dtbl.Rows[i].ItemArray[0].ToString());
                            }
                        }
                        if (lbl_header.Text == "Amendment BLDetails")
                        {
                            dtbl = blobj.GetAmendContainerName(intjobno, txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            if (dtbl.Rows.Count > 0)
                            {

                            }
                            else
                            {
                                dtbl = blobj.GetContainerName(intjobno, txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            }
                        }
                        else
                        {
                            dtbl = blobj.GetContainerName(intjobno, txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                        }

                        if (dtbl.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= chkListCont.Items.Count - 1; j++)
                                {
                                    if (dtbl.Rows[i][0].ToString() == chkListCont.Items[j].ToString())
                                    {
                                        chkListCont.Items[j].Selected = true;
                                    }

                                }
                            }
                        }
                        dtbl = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {
                            intjobtype = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                            hid_jobtype.Value = intjobtype.ToString();
                            jobAgentid = Convert.ToInt32(dtbl.Rows[0]["agent"].ToString());
                            hiddenjobagentid.Value = jobAgentid.ToString();
                            jobPOLid = Convert.ToInt32(dtbl.Rows[0]["pol"].ToString());
                            hiddenjobpolid.Value = jobPOLid.ToString();
                            jobPODid = Convert.ToInt32(dtbl.Rows[0]["pod"].ToString());
                            hiddenjobpodid.Value = jobPODid.ToString();
                            txtMVoy.Text = dtbl.Rows[0]["voyage"].ToString();
                            txtMVessel.Text = dtbl.Rows[0]["vesname"].ToString();
                            Hiddenvessel.Value = dtbl.Rows[0]["vesselid"].ToString();
                            vessel.Text = dtbl.Rows[0]["vesname"].ToString();
                            eta.Text = dtbl.Rows[0]["eta"].ToString();
                            eta.Text = Convert.ToDateTime(eta.Text).ToString("dd/MM/yyyy");
                            etd.Text = dtbl.Rows[0]["etd"].ToString();
                            if (etd.Text != "")
                            {
                                etd.Text = Convert.ToDateTime(etd.Text).ToString("dd/MM/yyyy");
                            }
                            mlo.Text = dtbl.Rows[0]["mlo"].ToString();
                            mbl.Text = dtbl.Rows[0]["mblno"].ToString();
                            pol.Text = dtbl.Rows[0]["pol"].ToString();
                            pod.Text = dtbl.Rows[0]["pod"].ToString();
                            carrier.Text = dtbl.Rows[0]["carrier"].ToString();



                            if (dtbl.Rows[0]["jobtype"].ToString() == "1")
                            {
                                txt_jobtype.Text = "Consol";
                            }
                            else if (dtbl.Rows[0]["jobtype"].ToString() == "2")
                            {
                                txt_jobtype.Text = "LCL";
                            }
                            else if (dtbl.Rows[0]["jobtype"].ToString() == "3")
                            {
                                txt_jobtype.Text = "FCL";
                            }
                            else if (dtbl.Rows[0]["jobtype"].ToString() == "4")
                            {
                                txt_jobtype.Text = "MCC";
                            }
                            else if (dtbl.Rows[0]["jobtype"].ToString() == "5")
                            {
                                txt_jobtype.Text = "Buyer Consol";
                            }

                            //vessel.Text = dtbl.Rows[0]["vessel"].ToString();

                            //txtc.Text = dtbl.Rows[0]["con"].ToString();
                            //eta.Text = dtbl.Rows[0]["eta"].ToString();
                            //eta.Text = Convert.ToDateTime(eta.Text).ToString("dd/MM/yyyy");
                            //etd.Text = dtbl.Rows[0]["etd"].ToString();
                            //etd.Text = Convert.ToDateTime(etd.Text).ToString("dd/MM/yyyy");
                            //mlo.Text = dtbl.Rows[0]["mlo"].ToString();
                            //mbl.Text = dtbl.Rows[0]["mblno"].ToString();
                            //pol.Text = dtbl.Rows[0]["pol"].ToString();
                            //pod.Text = dtbl.Rows[0]["pod"].ToString();
                            //carrier.Text = dtbl.Rows[0]["carrier"].ToString();
                            //if (dtbl.Rows[0]["mblstatus"].ToString() == "R")
                            //{
                            //    mblstatus.Text = "Release";
                            //}
                            //else if (dtbl.Rows[0]["mblstatus"].ToString() == "B")
                            //{
                            //    mblstatus.Text = "SeaWayBill";
                            //}
                            //else if (dtbl.Rows[0]["mblstatus"].ToString() == "S")
                            //{
                            //    mblstatus.Text = "Surrendered";
                            //}


                            //if (dtbl.Rows[0]["jobtype"].ToString() == "1")
                            //{
                            //    txt_jobtype.Text = "Consol";
                            //}
                            //else if (dtbl.Rows[0]["jobtype"].ToString() == "2")
                            //{
                            //    txt_jobtype.Text = "LCL";
                            //}
                            //else if (dtbl.Rows[0]["jobtype"].ToString() == "3")
                            //{
                            //    txt_jobtype.Text = "FCL";
                            //}
                            //else if (dtbl.Rows[0]["jobtype"].ToString() == "4")
                            //{
                            //    txt_jobtype.Text = "MCC";
                            //}
                            //else if (dtbl.Rows[0]["jobtype"].ToString() == "5")
                            //{
                            //    txt_jobtype.Text = "Buyer Consol";
                            //}
                        }
                        if (lbl_header.Text == "Amendment BLDetails")
                        {
                            //btn_save.Text = "Save";

                            btn_save.ToolTip = "Save";
                            btn_save1.Attributes["class"] = "btn ico-save";

                        }
                        else
                        {
                            // btn_save.Text = "Update";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn btn-update1";
                            btn_save.Focus();
                        }
                        if (lbl_header.Text == "Amendment BLDetails")
                        {
                            txt_blno.Enabled = false;
                        }
                        else
                        {
                            txt_blno.Enabled = true;
                        }
                        btn_save.Enabled = true;
                        if (lbl_header.Text != "Amendment BLDetails")
                        {
                            for (int s = 1; s <= 6; s++)
                            {
                                // int vouy = 2015;
                                int vouy = Convert.ToInt32(Session["Vouyear"].ToString());
                                dtbl = Invobj.CheckIPDCWBL(txt_blno.Text, "FI", Convert.ToInt32(Session["LoginBranchId"].ToString()), vouy, s, "CBM");
                                if (dtbl.Rows.Count > 0)
                                {
                                    txtcbm.Enabled = false;
                                    break;
                                }
                                else
                                {
                                    txtcbm.Enabled = true;
                                }
                            }
                            for (int s = 1; s < 6; s++)
                            {
                                int vouy = 2015;
                                // int vouy = Convert.ToInt32(Session["Vouyear"].ToString());
                                dtbl = Invobj.CheckIPDCWBL(txt_blno.Text, "FI", Convert.ToInt32(Session["LoginBranchId"].ToString()), vouy, s, "MT");
                                if (dtbl.Rows.Count > 0)
                                {
                                    txtgrossw.Enabled = false;
                                    txtnetw.Enabled = false;
                                    break;
                                }
                                else
                                {
                                    txtgrossw.Enabled = true;
                                    txtnetw.Enabled = true;
                                }
                            }
                        }
                        dtbl = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {
                            intjobtype = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                            hid_jobtype.Value = intjobtype.ToString();
                            jobAgentid = Convert.ToInt32(dtbl.Rows[0]["agent"].ToString());
                            hiddenjobagentid.Value = jobAgentid.ToString();
                            jobPOLid = Convert.ToInt32(dtbl.Rows[0]["pol"].ToString());
                            hiddenjobpolid.Value = jobPOLid.ToString();
                            jobPODid = Convert.ToInt32(dtbl.Rows[0]["pod"].ToString());
                            hiddenjobpodid.Value = jobPODid.ToString();
                            txtMVoy.Text = dtbl.Rows[0]["voyage"].ToString();
                            txtMVessel.Text = dtbl.Rows[0]["vesname"].ToString();
                            Hiddenvessel.Value = dtbl.Rows[0]["vesselid"].ToString();
                            txt_blno.Focus();
                        }
                    }//end if
                    else
                    {
                        if (txtshipper.Text != "" && txtconsignee.Text != "" && txt_blissuseat.Text != "" && txtreceipt.Text != "" && txtpol.Text != "")
                        {
                            //txtclear();
                            txtcbm.Enabled = true;
                        }
                        // btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";

                        txt_blissuseat.Focus();
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



        public void reusedetails()
        {
            try
            {
                if (txt_blno.Text != "")
                {

                    btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    if (lbl_header.Text != "Forwarder BL")
                    {
                        lnkfrght.Visible = true;
                    }
                    txt_blno.Text = txt_blno.Text.Trim();
                    DataTable dtbook = new DataTable();
                    dtbook = FIBookingBL.CheckAssociatedBLs(Convert.ToInt32(Session["LoginBranchId"].ToString()), txt_blno.Text, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtbook.Rows.Count > 0)
                    {
                        txtbookno.Text = dtbook.Rows[0]["bookingno"].ToString();
                        txtconsignee.Text = dtbook.Rows[0]["customername"].ToString();
                        txtcbm.Text = dtbook.Rows[0]["cbm"].ToString();
                        txtgrossw.Text = dtbook.Rows[0]["grweight"].ToString();
                        txtnetw.Text = dtbook.Rows[0]["netweight"].ToString();
                        string chars = dtbook.Rows[0]["blstatus"].ToString();
                        if (chars == "S")
                        {
                            chkBLSurr.Checked = true;
                        }
                        else
                        {
                            chkBLSurr.Checked = false;
                        }
                        chkNomination.Checked = true;
                    }
                    dtbl = fijobobj.GetLikeMBLNo(txt_blno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtbl.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                        {
                            string bltext = dtbl.Rows[i].ItemArray[0].ToString().ToUpper();
                            if (bltext.ToUpper() == txt_blno.Text.ToUpper())
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                                txt_blno.Focus();
                                return;
                            }
                        }
                    }
                    if (lbl_header.Text == "Split BL" || lbl_header.Text == "Direct BL")
                    {
                        dtbl = blobj.ShowBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }
                    else if (lbl_header.Text == "Forwarder BL")
                    {
                        dtbl = blobj.ShowFBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }
                    else if (lbl_header.Text == "Amendment BLDetails")
                    {
                        dtbl = blobj.ShowAmendBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            dtbl = blobj.ShowBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                    }

                    if (dtbl.Rows.Count > 0)
                    {
                        double temp1 = 0.0, temp2 = 0.0;
                        chkListCont.Items.Clear();
                        txtjobno.Text = "";
                        intjobno = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                        hd_jobno.Value = intjobno.ToString(); ;
                        txtCaption.Text = blobj.GetJobDetails(intjobno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        intportid = Convert.ToInt32(dtbl.Rows[0].ItemArray[1].ToString());
                        hiddenid_issue.Value = intportid.ToString();
                        strbldate = Convert.ToDateTime(dtbl.Rows[0].ItemArray[2].ToString());
                        strfreight = dtbl.Rows[0].ItemArray[3].ToString();
                        strstatus = dtbl.Rows[0].ItemArray[33].ToString();
                        intshipper = Convert.ToInt32(dtbl.Rows[0].ItemArray[4].ToString());
                        Hiddenshipper.Value = intshipper.ToString();
                        strshipper = dtbl.Rows[0].ItemArray[5].ToString();
                        strSaddress = dtbl.Rows[0].ItemArray[6].ToString();
                        intconsignee = Convert.ToInt32(dtbl.Rows[0].ItemArray[7].ToString());
                        Hiddenconsignee.Value = intconsignee.ToString();
                        strconsignee = dtbl.Rows[0].ItemArray[8].ToString();
                        strCaddress = dtbl.Rows[0].ItemArray[9].ToString();
                        intnotify = Convert.ToInt32(dtbl.Rows[0].ItemArray[10].ToString());
                        Hiddennotify.Value = intnotify.ToString();
                        strnotify = dtbl.Rows[0].ItemArray[11].ToString();
                        strNaddress = dtbl.Rows[0].ItemArray[12].ToString();
                        intagent = Convert.ToInt32(dtbl.Rows[0].ItemArray[13].ToString());
                        Hiddenagent.Value = intagent.ToString();
                        intpor = Convert.ToInt32(dtbl.Rows[0].ItemArray[14].ToString());
                        Hiddenrecipt.Value = intpor.ToString();
                        intpol = Convert.ToInt32(dtbl.Rows[0].ItemArray[15].ToString());
                        Hiddenpol.Value = intpol.ToString();
                        intpod = Convert.ToInt32(dtbl.Rows[0].ItemArray[16].ToString());
                        hiddencharge.Value = intpod.ToString();
                        intfd = Convert.ToInt32(dtbl.Rows[0].ItemArray[17].ToString());
                        Hiddentxtfinaldes.Value = intfd.ToString();
                        //Convert.ToInt32(Hiddentxtfinaldes.Value)
                        intpkgid = Convert.ToInt32(dtbl.Rows[0].ItemArray[29].ToString());
                        intvessel = Convert.ToInt32(dtbl.Rows[0].ItemArray[24].ToString());
                        Hiddenvessel.Value = intvessel.ToString();
                        inttranshippedat = Convert.ToInt32(dtbl.Rows[0].ItemArray[26].ToString());
                        hiddenidtrans.Value = inttranshippedat.ToString();
                        txt_issuedon.Text = strbldate.ToString("dd/MM/yyyy");
                        txtmarksnumbers.Text = dtbl.Rows[0].ItemArray[18].ToString();
                        txtdescn.Text = dtbl.Rows[0].ItemArray[19].ToString();
                        txtcbm.Text = dtbl.Rows[0].ItemArray[20].ToString();
                        oldcbm = Convert.ToDouble(dtbl.Rows[0].ItemArray[20].ToString());
                        temp1 = Convert.ToDouble(dtbl.Rows[0].ItemArray[21].ToString());
                        txtgrossw.Text = temp1.ToString("#,0.00");
                        temp2 = Convert.ToDouble(dtbl.Rows[0].ItemArray[22].ToString());
                        txtnetw.Text = temp2.ToString("#,0.00");
                        txtpackage.Text = dtbl.Rows[0].ItemArray[23].ToString();
                        txtUNOcode.Text = dtbl.Rows[0].ItemArray[27].ToString();
                        txtIMOCode.Text = dtbl.Rows[0].ItemArray[28].ToString();
                        txtremarks.Text = dtbl.Rows[0]["remarks"].ToString();
                        txtMVoy.Text = dtbl.Rows[0].ItemArray[25].ToString();
                        string cargoidd = dtbl.Rows[0]["cargoid"].ToString();
                        if (cargoidd != "")
                        {
                            IntCOMMODITY = Convert.ToInt32(dtbl.Rows[0]["cargoid"].ToString());
                            //hiddencargo.Value = IntCOMMODITY.ToString();                           
                            hiddencargo.Value = IntCOMMODITY.ToString();
                            txtcargo.Text = cargoobj.GetCargoname(Convert.ToInt32(hiddencargo.Value));


                        }
                        strSLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenshipper.Value));
                        strCLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenconsignee.Value));
                        strNLocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddennotify.Value));

                        if (lbl_header.Text == "Split BL" || lbl_header.Text == "Direct BL")
                        {
                            strSBL = dtbl.Rows[0].ItemArray[34].ToString();
                            FBLn = strSBL;
                            lblFwdBL.Text = "Forwarder BL # :" + strSBL;
                            string blsurrendered = dtbl.Rows[0]["blsurrendered"].ToString();
                            if (blsurrendered == "Y")
                            {
                                chkBLSurr.Checked = true;
                            }
                            else
                            {
                                chkBLSurr.Checked = false;
                            }
                        }

                        string nomination = dtbl.Rows[0].ItemArray[30].ToString();
                        if (nomination == "N")
                        {
                            chkNomination.Checked = true;
                        }
                        else
                        {
                            chkNomination.Checked = false;
                        }
                        if (!string.IsNullOrEmpty(FBLn))
                        {
                            FBooking = blobj.GetBookinkNo(FBLn, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            txtbookno.Text = FBooking;
                            dtbldetails = blobj.GetBookingDtls(FBooking, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            if (dtbldetails.Rows.Count > 0)
                            {
                                intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                                salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                                if (salesPID != 0)
                                {
                                    Hiddensalespid.Value = salesPID.ToString();
                                }
                                else
                                {
                                    Hiddensalespid.Value = "0";
                                }

                                chkNomination.Checked = true;
                            }
                        }
                        if (chkNomination.Checked == true)
                        {
                            if (lbl_header.Text == "Split BL")
                            {
                                FBooking = blobj.GetBookinkNo(FBLn, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                dtbldetails = blobj.GetBookingDtls(FBooking, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                if (dtbldetails.Rows.Count > 0)
                                {
                                    intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                                    salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                                    if (salesPID != 0)
                                    {
                                        Hiddensalespid.Value = salesPID.ToString();
                                    }
                                    else
                                    {
                                        Hiddensalespid.Value = "0";
                                    }

                                }
                            }
                            else
                            {
                                string booking = blobj.GetBookinkNo(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                if (booking == "")
                                {
                                    if (txtbookno.Text == "")
                                    {
                                        txtbookno.Text = "";
                                    }
                                }
                                else
                                {
                                    txtbookno.Text = blobj.GetBookinkNo(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                    dtbldetails = blobj.GetBookingDtls(txtbookno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                                    if (dtbldetails.Rows.Count > 0)
                                    {
                                        intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                                        salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                                        if (salesPID != 0)
                                        {
                                            Hiddensalespid.Value = salesPID.ToString();
                                        }
                                        else
                                        {
                                            Hiddensalespid.Value = "0";
                                        }
                                        //Hiddensalespid.Value = salesPID.ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (txtbookno.Text == "")
                            {
                                txtbookno.Text = "";
                            }
                        }
                        if (strfreight == "P")
                        {
                            ddlfreight.Text = "PrePaid";
                        }
                        else
                        {
                            ddlfreight.Text = "collect";
                        }
                        txtjobno.Text = intjobno.ToString();
                        txtshipper.Text = strshipper;
                        txtsaddress.Text = strSaddress;
                        txtconsignee.Text = strconsignee;
                        txtcaddress.Text = strCaddress;
                        txtnotify.Text = strnotify;
                        txtnaddress.Text = strNaddress;
                        stragent = customerobj.GetCustomername(Convert.ToInt32(Hiddenagent.Value));
                        strALocation = customerobj.GetCustlocation(Convert.ToInt32(Hiddenagent.Value));
                        strAgaddress = customerobj.GetCustomerAddress(stragent, "Agent / Principal", strALocation);
                        txtagent.Text = stragent;
                        txtaaddress.Text = strAgaddress;
                        txtreceipt.Text = portobj.GetPortname(Convert.ToInt32(Hiddenrecipt.Value));
                        txtpol.Text = portobj.GetPortname(Convert.ToInt32(Hiddenpol.Value));
                        txtpodis.Text = portobj.GetPortname(intpod);
                        txtfinaldes.Text = portobj.GetPortname(Convert.ToInt32(Hiddentxtfinaldes.Value));
                        txt_blissuseat.Text = portobj.GetPortname(Convert.ToInt32(hiddenid_issue.Value));
                        if (strstatus == "1")
                        {
                            ddlstatus.Text = "FCL/FCL";
                        }
                        else if (strstatus == "2")
                        {
                            ddlstatus.Text = "FCL/LCL";
                        }
                        else if (strstatus == "3")
                        {
                            ddlstatus.Text = "LCL/LCL";
                        }
                        else if (strstatus == "4")
                        {
                            ddlstatus.Text = "LCL/FCL";
                        }

                        ddlunits.SelectedItem.Text = pkgobj.GetPackagename(intpkgid);
                        txtMVessel.Text = vesselobj.GetVesselname(Convert.ToInt32(Hiddenvessel.Value));
                        txtTranshipped.Text = portobj.GetPortname(Convert.ToInt32(hiddenidtrans.Value));
                        dtbl = blobj.GetContainerDetail(intjobno, intjobno.ToString(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));

                        if (dtbl.Rows.Count > 0)
                        {
                            chkListCont.Items.Clear();
                            for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                            {
                                chkListCont.Items.Add(dtbl.Rows[i].ItemArray[0].ToString());
                            }
                        }
                        if (lbl_header.Text == "Amendment BLDetails")
                        {
                            dtbl = blobj.GetAmendContainerName(intjobno, txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            if (dtbl.Rows.Count > 0)
                            {

                            }
                            else
                            {
                                dtbl = blobj.GetContainerName(intjobno, txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                            }
                        }
                        else
                        {
                            dtbl = blobj.GetContainerName(intjobno, txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                        }

                        if (dtbl.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j <= chkListCont.Items.Count - 1; j++)
                                {
                                    if (dtbl.Rows[i][0].ToString() == chkListCont.Items[j].ToString())
                                    {
                                        chkListCont.Items[j].Selected = true;
                                    }

                                }
                            }
                        }
                        dtbl = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionid"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {
                            intjobtype = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                            hid_jobtype.Value = intjobtype.ToString();
                            jobAgentid = Convert.ToInt32(dtbl.Rows[0]["agent"].ToString());
                            hiddenjobagentid.Value = jobAgentid.ToString();
                            jobPOLid = Convert.ToInt32(dtbl.Rows[0]["pol"].ToString());
                            hiddenjobpolid.Value = jobPOLid.ToString();
                            jobPODid = Convert.ToInt32(dtbl.Rows[0]["pod"].ToString());
                            hiddenjobpodid.Value = jobPODid.ToString();
                        }
                        if (lbl_header.Text == "Amendment BLDetails")
                        {
                            //  btn_save.Text = "Save";
                            btn_save.ToolTip = "Save";
                            btn_save1.Attributes["class"] = "btn ico-save";
                        }
                        else
                        {
                            // btn_save.Text = "Update";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn btn-update1";
                            btn_save.Focus();
                        }
                        if (lbl_header.Text == "Amendment BLDetails")
                        {
                            txt_blno.Enabled = false;
                        }
                        else
                        {
                            txt_blno.Enabled = true;
                        }
                        btn_save.Enabled = true;
                        if (lbl_header.Text != "Amendment BLDetails")
                        {
                            for (int s = 1; s <= 6; s++)
                            {
                                // int vouy = 2015;
                                int vouy = Convert.ToInt32(Session["Vouyear"].ToString());
                                dtbl = Invobj.CheckIPDCWBL(txt_blno.Text, "FI", Convert.ToInt32(Session["LoginBranchId"].ToString()), vouy, s, "CBM");
                                if (dtbl.Rows.Count > 0)
                                {
                                    txtcbm.Enabled = false;
                                }
                                else
                                {
                                    txtcbm.Enabled = true;
                                }
                            }
                            for (int s = 1; s < 6; s++)
                            {
                                int vouy = 2015;
                                // int vouy = Convert.ToInt32(Session["Vouyear"].ToString());
                                dtbl = Invobj.CheckIPDCWBL(txt_blno.Text, "FI", Convert.ToInt32(Session["LoginBranchId"].ToString()), vouy, s, "MT");
                                if (dtbl.Rows.Count > 0)
                                {
                                    txtgrossw.Enabled = false;
                                    txtnetw.Enabled = false;
                                }
                                else
                                {
                                    txtgrossw.Enabled = true;
                                    txtnetw.Enabled = true;
                                }
                            }


                            // txtbookno.Text = "";
                            txt_blno.Text = "";
                            // txtjobno.Text = "";
                            //  txtCaption.Text = "";
                            chkListCont.Items.Clear();

                        }

                    }//end if
                    else
                    {
                        if (txtshipper.Text != "" && txtconsignee.Text != "" && txt_blissuseat.Text != "" && txtreceipt.Text != "" && txtpol.Text != "")
                        {
                            //txtclear();
                            txtcbm.Enabled = true;
                        }
                        // btn_save.Text = "Save";
                        btn_save.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        txt_blissuseat.Focus();
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
        protected void Label_2_Click(object sender, EventArgs e)
        {
            try
            {
                LoadJob();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void LoadJob()
        {
            grdMBLDetails.Visible = false;
            Grd_Job.Visible = true;
            Grd_Booking.Visible = false;
            dtbl = blobj.JobInfo(Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtbl.Rows.Count <= 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Job Not Available');", true);
            }
            else
            {
                this.popup_Grd.Show();

                Grd_Job.DataSource = dtbl;
                Grd_Job.DataBind();
                ViewState["job"] = dtbl;
            }
        }

        protected void lbl_booking_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBooking();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void LoadBooking()
        {

            Grd_Job.Visible = false;
            Grd_Booking.Visible = true;
            ////DataAccess.ForwardingImports.BLDetails obj_da_BL = new //DataAccess.ForwardingImports.BLDetails();
            //if (txtjobno.Text != "")
            //{


            dtbl = blobj.BookingdetailsAEAI(strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), 0);
            if (dtbl.Rows.Count <= 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Booking Not Available');", true);
            }
            else
            {
                this.popup_Grd.Show();

                Grd_Booking.DataSource = dtbl;
                Grd_Booking.DataBind();
                ViewState["Booking"] = dtbl;
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('ENTER THE JOB#');", true);
            //}
        }

        protected void Getjob()
        {
            chkListCont.Items.Clear();
            if (txtjobno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('ENTER THE JOB#');", true);
                return;
            }
            if (hid_reuse.Value != "")
            {
                txtclear();
            }

            txtCaption.Text = blobj.GetJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

            dtbl = blobj.GetContainerDetail(Convert.ToInt32(txtjobno.Text), txtjobno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtbl.Rows.Count > 0)
            {
                chkListCont.Items.Clear();
                for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                {
                    chkListCont.Items.Add(dtbl.Rows[i].ItemArray[0].ToString());
                }
            }
            else
            {
                txtjobno.Focus();
            }
            dtbl = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtbl.Rows.Count > 0)
            {
                intjobtype = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                hid_jobtype.Value = intjobtype.ToString();
                jobAgentid = Convert.ToInt32(dtbl.Rows[0]["agent"].ToString());
                hiddenjobagentid.Value = jobAgentid.ToString();
                jobPOLid = Convert.ToInt32(dtbl.Rows[0]["pol"].ToString());
                hiddenjobpolid.Value = jobPOLid.ToString();
                jobPODid = Convert.ToInt32(dtbl.Rows[0]["pod"].ToString());
                hiddenjobpodid.Value = jobPODid.ToString();
                txtMVoy.Text = dtbl.Rows[0]["voyage"].ToString();
                txtMVessel.Text = dtbl.Rows[0]["vesname"].ToString();
                Hiddenvessel.Value = dtbl.Rows[0]["vesselid"].ToString();
                txt_blno.Focus();

                vessel.Text = dtbl.Rows[0]["vesname"].ToString();
                eta.Text = dtbl.Rows[0]["eta"].ToString();
                eta.Text = Convert.ToDateTime(eta.Text).ToString("dd/MM/yyyy");
                etd.Text = dtbl.Rows[0]["etd"].ToString();
                if (etd.Text != "")
                {
                    etd.Text = Convert.ToDateTime(etd.Text).ToString("dd/MM/yyyy");
                }
                mlo.Text = dtbl.Rows[0]["mlo"].ToString();
                mbl.Text = dtbl.Rows[0]["mblno"].ToString();
                pol.Text = dtbl.Rows[0]["pol"].ToString();
                pod.Text = dtbl.Rows[0]["pod"].ToString();
                carrier.Text = dtbl.Rows[0]["carrier"].ToString();



                if (dtbl.Rows[0]["jobtype"].ToString() == "1")
                {
                    txt_jobtype.Text = "Consol";
                }
                else if (dtbl.Rows[0]["jobtype"].ToString() == "2")
                {
                    txt_jobtype.Text = "LCL";
                }
                else if (dtbl.Rows[0]["jobtype"].ToString() == "3")
                {
                    txt_jobtype.Text = "FCL";
                }
                else if (dtbl.Rows[0]["jobtype"].ToString() == "4")
                {
                    txt_jobtype.Text = "MCC";
                }
                else if (dtbl.Rows[0]["jobtype"].ToString() == "5")
                {
                    txt_jobtype.Text = "Buyer Consol";
                }
            }
            //bookingdetails();

        }

        protected void Grd_Job_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.popup_Grd.Hide();
                //intjobno = Convert.ToInt32(hid_jobtype.Value);
                if (Grd_Job.Rows.Count > 0)
                {

                    //if (hid_reuse.Value != "Reuse")
                    //{
                    //    txtclear();
                    //}
                    txtjobno.Text = Grd_Job.SelectedRow.Cells[0].Text;
                    intjobno = Convert.ToInt32(txtjobno.Text);
                    Getjob();
                    if (strbltype == "S")
                    {

                        grdMBLDetails.Visible = true;
                        dtbl = blobj.BLdetails(intjobno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {
                            ModalPopupExtender1.Show();
                            grdMBLDetails.DataSource = dtbl;
                            grdMBLDetails.DataBind();
                        }

                        else
                        {
                            ModalPopupExtender1.Hide();
                            ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Split BL Not Available');", true);
                        }
                    }
                    Grd_Job.Visible = false;
                    btn_cancel.Text = "Cancel";
                    lbl_booking_Click(sender, e);
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void Grd_Booking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.popup_Grd.Hide();
                int intcustomerid;

                if (Grd_Booking.Rows.Count > 0)
                {
                    txtbookno.Text = Grd_Booking.SelectedRow.Cells[0].Text;
                    quotcust = Grd_Booking.SelectedRow.Cells[2].Text;
                    dtbldetails = blobj.GetBookingDtls(txtbookno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtbldetails.Rows.Count > 0)
                    {

                        if (dtbldetails.Rows[0]["approved"].ToString() == "N")
                        {
                            //ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "BLDetails", "alertify.alert('For Agentina Booking kindly get the Approval  from SONIA MAM');", true);
                            //return;
                        }
                        string customertype = dtbldetails.Rows[0]["customertype"].ToString();
                        if (customertype == "C")
                        {
                            txtconsignee.Text = dtbldetails.Rows[0].ItemArray[0].ToString();
                            txtcaddress.Text = txtconsignee.Text + "\n" + dtbldetails.Rows[0].ItemArray[1].ToString();
                        }
                        else
                        {
                            txtconsignee.Text = "";
                            txtcaddress.Text = "";
                        }
                        intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                        if (intcustomerid != 0)
                        {
                            string carrierid = intcustomerid.ToString();
                            Hiddenconsignee.Value = carrierid;
                            dtcust = obj_da_BL.GetCreditApprovalFromCustomer(Convert.ToInt32(intcustomerid));
                        }
                        //if (dtcust.Rows.Count > 0) ///hide on 10mar2022 as per instruction as nambi
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Credit Limit does not exist');", true);
                        //    btn_save.Visible = false;
                        //    return;

                        //}
                        txtjobno.Text = dtbldetails.Rows[0]["job"].ToString();
                        intpor = Convert.ToInt32(dtbldetails.Rows[0]["porid"].ToString());
                        Hiddenrecipt.Value = intpor.ToString();
                        intpol = Convert.ToInt32(dtbldetails.Rows[0]["polid"].ToString());
                        Hiddenpol.Value = intpol.ToString();
                        intpod = Convert.ToInt32(dtbldetails.Rows[0]["podid"].ToString());
                        hiddencharge.Value = intpod.ToString();
                        intfd = Convert.ToInt32(dtbldetails.Rows[0]["fdid"].ToString());
                        Hiddentxtfinaldes.Value = intfd.ToString();
                        salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                        if (salesPID != 0)
                        {
                            Hiddensalespid.Value = salesPID.ToString();
                        }
                        else
                        {
                            Hiddensalespid.Value = "0";
                        }

                        //Hiddensalespid.Value = salesPID.ToString();
                        txtreceipt.Text = dtbldetails.Rows[0].ItemArray[2].ToString();
                        txtpodis.Text = dtbldetails.Rows[0].ItemArray[4].ToString();
                        txtpol.Text = dtbldetails.Rows[0].ItemArray[3].ToString();
                        txtfinaldes.Text = dtbldetails.Rows[0].ItemArray[5].ToString();
                        strCLocation = dtbldetails.Rows[0].ItemArray[7].ToString();
                        txtdescn.Text = dtbldetails.Rows[0].ItemArray[8].ToString();
                        txtgrossw.Text = dtbldetails.Rows[0]["grwt"].ToString();
                        txtnetw.Text = dtbldetails.Rows[0]["grwt"].ToString();

                        DataTable dt;
                        //DataAccess.Masters.MasterPort obj_MasterPort = new //DataAccess.Masters.MasterPort();
                        dt = obj_MasterPort.SelPortName4typepadimg(txtfinaldes.Text.ToUpper(), Session["StrTranType"].ToString());
                        fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txtreceipt.Text.ToUpper(), Session["StrTranType"].ToString());
                        porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txtpodis.Text.ToUpper(), Session["StrTranType"].ToString());
                        podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txtpol.Text.ToUpper(), Session["StrTranType"].ToString());
                        flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        txtCaption.Text = blobj.GetJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        dtbl = blobj.GetContainerDetail(Convert.ToInt32(txtjobno.Text), txtjobno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {
                            chkListCont.Items.Clear();
                            for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                            {
                                chkListCont.Items.Add(dtbl.Rows[i].ItemArray[0].ToString());
                            }
                        }
                        else
                        {
                            txtjobno.Focus();
                        }
                        dtbl = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {
                            intjobtype = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                            hid_jobtype.Value = intjobtype.ToString();
                            jobAgentid = Convert.ToInt32(dtbl.Rows[0]["agent"].ToString());
                            hiddenjobagentid.Value = jobAgentid.ToString();
                            jobPOLid = Convert.ToInt32(dtbl.Rows[0]["pol"].ToString());
                            hiddenjobpolid.Value = jobPOLid.ToString();
                            jobPODid = Convert.ToInt32(dtbl.Rows[0]["pod"].ToString());
                            hiddenjobpodid.Value = jobPODid.ToString();
                            txtMVoy.Text = dtbl.Rows[0]["voyage"].ToString();
                            txtMVessel.Text = dtbl.Rows[0]["vesname"].ToString();
                            Hiddenvessel.Value = dtbl.Rows[0]["vesselid"].ToString();
                            txt_blno.Focus();
                            vessel.Text = dtbl.Rows[0]["vesname"].ToString();
                            eta.Text = dtbl.Rows[0]["eta"].ToString();
                            eta.Text = Convert.ToDateTime(eta.Text).ToString("dd/MM/yyyy");
                            etd.Text = dtbl.Rows[0]["etd"].ToString();
                            if (etd.Text != "")
                            {
                                etd.Text = Convert.ToDateTime(etd.Text).ToString("dd/MM/yyyy");
                            }

                            mlo.Text = dtbl.Rows[0]["mlo"].ToString();
                            mbl.Text = dtbl.Rows[0]["mblno"].ToString();
                            pol.Text = dtbl.Rows[0]["pol"].ToString();
                            pod.Text = dtbl.Rows[0]["pod"].ToString();
                            carrier.Text = dtbl.Rows[0]["carrier"].ToString();



                            if (dtbl.Rows[0]["jobtype"].ToString() == "1")
                            {
                                txt_jobtype.Text = "Consol";
                            }
                            else if (dtbl.Rows[0]["jobtype"].ToString() == "2")
                            {
                                txt_jobtype.Text = "LCL";
                            }
                            else if (dtbl.Rows[0]["jobtype"].ToString() == "3")
                            {
                                txt_jobtype.Text = "FCL";
                            }
                            else if (dtbl.Rows[0]["jobtype"].ToString() == "4")
                            {
                                txt_jobtype.Text = "MCC";
                            }
                            else if (dtbl.Rows[0]["jobtype"].ToString() == "5")
                            {
                                txt_jobtype.Text = "Buyer Consol";
                            }
                        }
                    }

                }

                txt_blno.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                txtclear();
                enable();
                txtCaption.Text = "";
                txtjobno.Text = "";
                //  btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                hid_reuse.Value = "";
                btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                txt_blno.Focus();
                txt_blno.Enabled = true;
                lnkfrght.Visible = false;
                lblFwdBL.Text = "";
                chkNomination.Checked = true;
                txtIMOCode.Text = "ZZZZZ";
                txtUNOcode.Text = "ZZZ";
                flagimg.ImageUrl = "";
                porflag.ImageUrl = "";
                podflag.ImageUrl = "";
                fdflag.ImageUrl = "";
                vessel.Text = "";
                txt_jobtype.Text = "";
                eta.Text = "";
                etd.Text = "";
                mlo.Text = "";
                mbl.Text = "";
                pol.Text = "";
                pod.Text = "";
                mblstatus.Text = "";
                carrier.Text = "";

                // btn_save.Enabled = false;
            }
            else
            {
                btn_save.Enabled = false;

                //this.Response.End();


                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");

                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
                    }
                    else
                    {
                        this.Response.End();
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
            UserRights();
        }

        public void enable()
        {
            txt_blno.Enabled = true;
            txt_blissuseat.Enabled = true;
            ddlfreight.Enabled = true;
            txtshipper.Enabled = true;
            txtsaddress.Enabled = true;
            txtconsignee.Enabled = true;
            txtcaddress.Enabled = true;
            txtnotify.Enabled = true;
            txtnaddress.Enabled = true;
            txtagent.Enabled = true;
            txtaaddress.Enabled = true;
            txtreceipt.Enabled = true;
            txtpol.Enabled = true;
            txtpodis.Enabled = true;
            txtfinaldes.Enabled = true;
            txtmarksnumbers.Enabled = true;
            txtdescn.Enabled = true;
            txtcbm.Enabled = true;
            txtgrossw.Enabled = true;
            txtnetw.Enabled = true;
            txtpackage.Enabled = true;
            ddlstatus.Enabled = true;
            ddlunits.Enabled = true;
            chkListCont.Items.Clear();
            txtMVessel.Enabled = true;
            txtMVoy.Enabled = true;
            txtTranshipped.Enabled = true;
            txtUNOcode.Enabled = true;
            txtIMOCode.Enabled = true;
        }
        public void txtclear()
        {

            chkListCont.Items.Clear();
            txtjobno.Text = "";
            txtCaption.Text = "";
            txtcargo.Text = "";
            IntCOMMODITY = 0;
            txtcbm.Enabled = true;
            txt_blno.Text = "";
            txt_blissuseat.Text = "";
            // ddlfreight.Text = "";
            txtshipper.Text = "";
            txtsaddress.Text = "";
            txtconsignee.Text = "";
            txtcaddress.Text = "";
            txtnotify.Text = "";
            txtnaddress.Text = "";
            txtagent.Text = "";
            txtaaddress.Text = "";
            txtreceipt.Text = "";
            txtpol.Text = "";
            txtpodis.Text = "";
            txtfinaldes.Text = "";
            txtmarksnumbers.Text = "";
            txtdescn.Text = "";
            txtcbm.Text = "";
            txtgrossw.Text = "";
            txtnetw.Text = "";
            txtpackage.Text = "";
            //   ddlunits.Text = "";
            // ddlstatus.Text = "";
            chkNomination.Checked = true;
            txtMVessel.Text = "";
            txtMVoy.Text = "";
            txtTranshipped.Text = "";
            //txtUNOcode.Text = "";
            //txtIMOCode.Text = "";

            txtbookno.Text = "";
            //  ddlunits.Items.Clear();
            ddlunits.SelectedIndex = 0;
            txtremarks.Text = "";
            DateTime issueon = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
            txt_issuedon.Text = issueon.ToString("dd/MM/yyyy");
            //txt_issuedon.Text = Utility.fn_ConvertDate(txt_issuedon.Text);
            PackageFill();
            chkBLSurr.Checked = false;
            Grd_Booking.Visible = false;
            intshipper = 0;
            intconsignee = 0;
            intnotify = 0;
            intagent = 0;
            intportid = 0;
            intpor = 0;
            intpol = 0;
            intpod = 0;
            intfd = 0;
            salesPID = 0;
            txtgrossw.Enabled = true;
            txtnetw.Enabled = true;
            txtcbm.Enabled = true;
            Hiddenconsignee.Value = "0";
            Hiddenshipper.Value = "0";
            vessel.Text = "";
            txt_jobtype.Text = "";
            eta.Text = "";
            etd.Text = "";
            mlo.Text = "";
            mbl.Text = "";
            pol.Text = "";
            pod.Text = "";
            mblstatus.Text = "";
            carrier.Text = "";

        }

        protected void txtgrossw_TextChanged(object sender, EventArgs e)
        {
            txtnetw.Text = txtgrossw.Text;
        }

        protected void txtshipper_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenshipper.Value != "0")
                {
                    txtconsignee.Focus();
                }
                else
                {
                    txtshipper.Text = "";
                    txtsaddress.Text = "";
                    blnerr = true;
                    txtshipper.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid SHIPPER');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtconsignee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenconsignee.Value != "" && Hiddenconsignee.Value != "0")
                {

                    txtnotify.Focus();

                }
                else
                {
                    txtconsignee.Text = "";
                    txtcaddress.Text = "";
                    txtconsignee.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid CONSIGNEE');", true);
                    blnerr = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtnotify_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddennotify.Value != "0")
                {
                    txtagent.Focus();
                }
                else
                {
                    txtnotify.Text = "";
                    txtnaddress.Text = "";
                    txtnotify.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid NOTIFY PARTY');", true);
                    blnerr = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtagent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenagent.Value != "0")
                {
                    txtreceipt.Focus();
                }
                else
                {
                    txtagent.Text = "";
                    txtaaddress.Text = "";
                    txtagent.Focus();
                    blnerr = true;
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid AGENT Name');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string supplyto = "";
                strSBL = hidstrSBL.Value;

                txtshipper_TextChanged(sender, e);
                txtconsignee_TextChanged(sender, e);
                txtnotify_TextChanged(sender, e);
                txtagent_TextChanged(sender, e);
                if (blnerr == true)
                {
                    return;
                }
                if (txtjobno.Text != "")
                {
                    intjobno = Convert.ToInt32(txtjobno.Text);
                }

                if (Hiddensalespid.Value == "" || Hiddensalespid.Value == "0")
                {
                    Hiddensalespid.Value = "0";
                }

                strbldate = Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_issuedon.Text));
                checkdata();
                if (blnerr == true)
                {
                    return;
                }
                if (txtbookno.Text == "0")
                {
                    txtbookno.Text = "";
                }
                txt_blno.Text = txt_blno.Text.ToUpper().Trim();
                if (txtpol.Text != "" && txtpodis.Text != "" && txtreceipt.Text != "" && txtfinaldes.Text != "")
                {
                    if (txtpol.Text == txtpodis.Text)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Both PoL And PoD Should not Same');", true);
                        txtpodis.Focus();
                        return;
                    }
                    if (txtreceipt.Text == txtpodis.Text)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Both PoR And PoD Should not Same');", true);
                        txtpodis.Focus();
                        return;
                    }
                    if (txtpol.Text == txtfinaldes.Text)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Both PoL And Place of Delivery Should not Same');", true);
                        txtfinaldes.Focus();
                        return;
                    }
                }
                if (txtnotify.Text != "" && txtagent.Text != "")
                {
                    if (txtnotify.Text == txtagent.Text)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Notify Party and Agent Should not Same');", true);
                        txtagent.Focus();
                        return;
                    }
                }
                if (ddlunits.SelectedValue == "0" || ddlunits.SelectedIndex == 0 || ddlunits.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "BL", "alertify.alert('Select Unit Type');", true);
                    return;
                }
                string fre;
                if (ddlfreight.Text == "PrePaid")
                {
                    fre = "P";
                }
                else
                {
                    fre = "C";
                }
                ///hide on 10mar2022 as per instruction on nambi
                //if (txtbookno.Text.Trim().Length == 0)
                //{
                //    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "BL", "alertify.alert('Select the correct Booking Number');", true);
                //    txtbookno.Focus();

                //    return;
                //}


                if (btn_save.ToolTip == "Save")
                {
                    dtbl = fijobobj.GetLikeMBLNo(txt_blno.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtbl.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtbl.Rows.Count - 1; i++)
                        {
                            string bltext = dtbl.Rows[i].ItemArray[0].ToString().ToUpper();
                            if (bltext.ToUpper() == txt_blno.Text.ToUpper())
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('BL # and MBL # should not Same,kindly change MBL # in Job screen');", true);
                                txt_blno.Focus();
                                return;
                            }
                        }
                    }


                    int cou = 0;
                    for (int i = 0; i < chkListCont.Items.Count; i++)
                    {
                        if (chkListCont.Items[i].Selected == true)
                        {
                            cou = 1;
                        }
                    }
                    if (cou == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Select Atleast One Container');", true);
                        return;
                    }
                    cou = 0;
                    CollectDetails();
                    strbl = txt_blno.Text;
                    divisionid = Convert.ToInt32(hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString()));
                    branch = hrempobj.GetBranchId(divisionid, Session["LoginBranchName"].ToString());

                    if (Convert.ToInt32(hid_jobtype.Value) != 3)
                    {
                        if (Convert.ToDouble(txtcbm.Text) == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('CBM must greater than Zero');", true);
                            txtcbm.Focus();
                            return;
                        }
                    }
                    if (txtjobno.Text != "")
                    {
                        int closedjobs = Invobj.CheckClosedJobs("FI", Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        if (closedjobs != 0)
                        {
                            string msg = "Job # " + txtjobno.Text + " has Closed Already. \\n  You Can not Update the BL Details";
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLDetails", "alertify.alert(' " + msg + "');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Job has been Closed Already" + "\n" + "You Can not Update the BL Details');", true);
                            return;
                        }

                    }
                    if (strbltype == "D")
                    {
                        if (chkNomination.Checked == true)
                        {
                            if (txtbookno.Text != "")
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('Booking # Cannot be Blank');", true);
                                txtbookno.Focus();
                                return;
                            }
                        }
                        InsertContainerDetails();
                        intcbm = Convert.ToDouble(txtcbm.Text);
                        ContSize(txt_blno.Text.Trim(), Convert.ToInt32(hid_jobtype.Value));
                        if (cont20 > 0 && cont40 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit20)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('CBM sholuld be lesser than or equal to " + limit20 + " ...Since " + cont20 + " X 20 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txtbookno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit40)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('CBM sholuld be lesser than or equal to " + limit40 + " ...Since " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txtbookno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 > 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit240)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(LinkButton), "BLDetails", "alertify.alert('CBM sholuld be lesser than or equal to " + limit240 + " ...Since " + cont20 + " X 20 Feet  and " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txtbookno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }


                        getvolume();
                        blobj.InsertBLDetails(intjobno, txt_blno.Text.Trim(), strbldate, Convert.ToInt32(hiddenid_issue.Value), Convert.ToInt32(Hiddenshipper.Value), txtshipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value), txtconsignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txtnotify.Text, txtnaddress.Text, Convert.ToInt32(Hiddenagent.Value), Convert.ToInt32(Hiddenrecipt.Value), Convert.ToInt32(Hiddenpol.Value), Convert.ToInt32(hiddencharge.Value), Convert.ToInt32(Hiddentxtfinaldes.Value), txtmarksnumbers.Text, txtdescn.Text, Convert.ToDouble(txtcbm.Text), Convert.ToDouble(txtgrossw.Text), Convert.ToDouble(txtnetw.Text), ddlstatus.Text, ddlfreight.Text, Convert.ToInt32(txtpackage.Text), ddlunits.SelectedItem.Text, Convert.ToChar(strNomination), txtMVessel.Text, txtMVoy.Text, Convert.ToInt32(hiddenidtrans.Value), txtUNOcode.Text, txtIMOCode.Text, Convert.ToInt32(hidintCont20.Value), Convert.ToInt32(hidintCont40.Value), branch, txtremarks.Text, BLSurrendered, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Hiddensalespid.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(hiddencargo.Value), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        blobj.UpdateBooking(txtbookno.Text, strbl, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        blobj.UpdateContsize(txt_blno.Text.Trim(), intCont20, intCont40, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 122, 1, Convert.ToInt32(Session["LoginBranchId"].ToString()), txt_blno.Text + "/S");
                        int branchidif = Convert.ToInt32(Session["LoginBranchId"].ToString());
                        getsupplytovalues();
                        AutoInvoice();
                        Autocnops4negativeQuotation();


                        Autocnops();

                        autodebitOS();
                        autocreditOS();



                        //if (branchidif == 2 || branchidif == 41 || branchidif == 5 || branchidif == 42 || branchidif == 57 || branchidif == 58)
                        //{
                        //    InsertAgentRebatetoProforma();

                        /* if (blnerr == true)
                         {
                             ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update  Gstin# & Uinno#  Master Customer');", true);
                         }
                         if (blnerrUinno == true)
                         {
                             ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer');", true);
                         }
                         if (blnerrGstin == true)
                         {
                             ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                         }
                         if (blnerrUinnoGstin == true)
                         {
                             ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('GST calculated');", true);
                         }*/

                        //}


                    }//strbl D
                    else if (strbltype == "A")
                    {
                        InsertAmendContainerDetails();
                        intcbm = Convert.ToDouble(txtcbm.Text);
                        ContSize(txt_blno.Text.Trim(), intjobtype);
                        if (cont20 > 0 && cont40 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit20)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit20 + " ...Since " + cont20 + " X 20 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit40)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit40 + " ...Since " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 > 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit240)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit240 + " ...Since " + cont20 + " X 20 Feet  and " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        getvolume();
                        blobj.InsertAmendBLDetails(intjobno, txt_blno.Text, strbldate, Convert.ToInt32(hiddenid_issue.Value), Convert.ToInt32(Hiddenshipper.Value), txtshipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value), txtconsignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txtnotify.Text, txtnaddress.Text, Convert.ToInt32(Hiddenagent.Value), Convert.ToInt32(Hiddenrecipt.Value), Convert.ToInt32(Hiddenpol.Value), Convert.ToInt32(hiddencharge.Value), Convert.ToInt32(Hiddentxtfinaldes.Value), txtmarksnumbers.Text, txtdescn.Text, Convert.ToDouble(txtcbm.Text), Convert.ToDouble(txtgrossw.Text), Convert.ToDouble(txtnetw.Text), ddlstatus.Text, ddlfreight.Text, Convert.ToInt32(txtpackage.Text), ddlunits.SelectedItem.Text, Convert.ToChar(strNomination), txtMVessel.Text, txtMVoy.Text, Convert.ToInt32(hiddenidtrans.Value), txtUNOcode.Text, txtIMOCode.Text, Convert.ToInt32(hidintCont20.Value), Convert.ToInt32(hidintCont40.Value), branch, txtremarks.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        blobj.UpdateAmendContsize(txt_blno.Text, Convert.ToInt32(hidintCont20.Value), Convert.ToInt32(hidintCont40.Value), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        getsupplytovalues();

                        //AutoInvoice();
                        //Autocnops();

                        //autodebitOS();
                        //autocreditOS();

                    }//strbl A
                    else if (strbltype == "F")
                    {
                        if (chkNomination.Checked == true)
                        {
                            if (txtbookno.Text != "")
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Booking # cannot be Blank');", true);
                                txtbookno.Focus();
                                return;
                            }
                        }
                        InsertContainerDetails();
                        intcbm = Convert.ToDouble(txtcbm.Text);
                        ContSize(txt_blno.Text.Trim(), intjobtype);
                        if (cont20 > 0 && cont40 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit20)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit20 + " ...Since " + cont20 + " X 20 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit40)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit40 + " ...Since " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 > 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit240)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit240 + " ...Since " + cont20 + " X 20 Feet  and " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        getvolume();
                        string BLSurrendereded;
                        if (chkBLSurr.Checked == true)
                        {
                            BLSurrendereded = "Y";
                        }
                        else
                        {
                            BLSurrendereded = "N";
                        }
                        blobj.InsertFBLDetails(intjobno, txt_blno.Text.Trim(), strbldate, Convert.ToInt32(hiddenid_issue.Value), Convert.ToInt32(Hiddenshipper.Value), txtshipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value), txtconsignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txtnotify.Text, txtnaddress.Text, Convert.ToInt32(Hiddenagent.Value), Convert.ToInt32(Hiddenrecipt.Value), Convert.ToInt32(Hiddenpol.Value), Convert.ToInt32(hiddencharge.Value), Convert.ToInt32(Hiddentxtfinaldes.Value), txtmarksnumbers.Text, txtdescn.Text, Convert.ToDouble(txtcbm.Text), Convert.ToDouble(txtgrossw.Text), Convert.ToDouble(txtnetw.Text), ddlstatus.Text, ddlfreight.Text, Convert.ToInt32(txtpackage.Text), ddlunits.SelectedItem.Text, Convert.ToChar(strNomination), txtMVessel.Text, txtMVoy.Text, Convert.ToInt32(hiddenidtrans.Value), txtUNOcode.Text, txtIMOCode.Text, txtremarks.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Hiddensalespid.Value), Convert.ToInt32(hiddencargo.Value), Convert.ToInt32(Session["LoginDivisionId"].ToString()), BLSurrendereded);
                        blobj.UpdateBooking(txtbookno.Text, strbl, Convert.ToInt32(Session["LoginBranchID"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        blobj.UpdateContsize(txt_blno.Text.Trim(), Convert.ToInt32(hidintCont20.Value), Convert.ToInt32(hidintCont40.Value), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 123, 1, Convert.ToInt32(Session["LoginBranchId"].ToString()), txt_blno.Text + "/S");
                        getsupplytovalues();
                        //AutoInvoice();
                        //Autocnops();

                        //autodebitOS();
                        //autocreditOS();
                    }
                    else if (strbltype == "S")
                    {
                        if (strSBL == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Forwarder BL Cannot be Blank');", true);
                            return;
                        }

                        InsertContainerDetails();
                        intcbm = Convert.ToDouble(txtcbm.Text);
                        ContSize(txt_blno.Text.Trim(), intjobtype);
                        if (cont20 > 0 && cont40 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit20)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit20 + " ...Since " + cont20 + " X 20 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;

                            }
                        }
                        else if (cont40 > 0 && cont20 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit40)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit40 + " ...Since " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 > 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit240)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit240 + " ...Since " + cont20 + " X 20 Feet  and " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        getvolume();
                        blobj.InsertSBLDetails(intjobno, txt_blno.Text.Trim(), strbldate, Convert.ToInt32(hiddenid_issue.Value), Convert.ToInt32(Hiddenshipper.Value), txtshipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value), txtconsignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txtnotify.Text, txtnaddress.Text, Convert.ToInt32(Hiddenagent.Value), Convert.ToInt32(Hiddenrecipt.Value), Convert.ToInt32(Hiddenpol.Value), Convert.ToInt32(hiddencharge.Value), Convert.ToInt32(Hiddentxtfinaldes.Value), txtmarksnumbers.Text, txtdescn.Text, Convert.ToDouble(txtcbm.Text), Convert.ToDouble(txtgrossw.Text), Convert.ToDouble(txtnetw.Text), ddlstatus.Text, ddlfreight.Text, Convert.ToInt32(txtpackage.Text), ddlunits.SelectedItem.Text, Convert.ToChar(strNomination), txtMVessel.Text, txtMVoy.Text, Convert.ToInt32(hiddenidtrans.Value), txtUNOcode.Text, txtIMOCode.Text, strSBL, Convert.ToInt32(hidintCont20.Value), Convert.ToInt32(hidintCont40.Value), txtremarks.Text, BLSurrendered, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Hiddensalespid.Value), Convert.ToInt32(hiddencargo.Value), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        blobj.UpdateContsize(txt_blno.Text.Trim(), intCont20, intCont40, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 124, 1, Convert.ToInt32(Session["LoginBranchId"].ToString()), txt_blno.Text + "/S");
                        int branchif = Convert.ToInt32(Session["LoginBranchId"].ToString());
                        getsupplytovalues();
                        AutoInvoice();
                        Autocnops4negativeQuotation();
                        Autocnops();

                        // Enable by yuvaraj 01/02/2023 3menthod  // added on 01Feb2023 4 splitbl OSDN OSCN
                        autodebitOS();
                        autocreditOS();

                        //if (branchif == 2 || branchif == 41 || branchif == 5 || branchif == 42 || branchif == 57 || branchif == 58)
                        //{
                        //    InsertAgentRebatetoProforma();
                        /*  if (blnerr == true)
                          {
                              ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update  Gstin# & Uinno#  Master Customer');", true);
                          }
                          if (blnerrUinno == true)
                          {
                              ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer');", true);
                          }
                          if (blnerrGstin == true)
                          {
                              ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                          }
                          if (blnerrUinnoGstin == true)
                          {
                              ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('GST calculated');", true);
                          }*/
                        //}



                    }//strbl S
                    Corpobj.UpdateShipmentStatus(txt_blno.Text.Trim(), "FI", Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), "Delivery Order not yet collected");
                    txt_blno.Enabled = true;

                    /*if (invblr == false)
                    {
                       // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Details Saved');", true);
                        StrScript += "Details Saved";
                        if (hid_SupplyTo.Value!="")
                        {
                            supplyto = customerobj.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                            ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), supplyto);
                        }
                         
                        if (bolcuststat == true)
                        {
                            StrScript += " State Name not Updated in Master,Kindly update Master Customer" + supplyto + ",GST NOT Calculated Propertly";
                        }
                        if (bolcuststat1 == true)
                        {
                            StrScript += " Kindly update SUPPLY TO Name " + supplyto + ",GST NOT Calculated Propertly";
                        }
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('" + StrScript + "');", true);
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Details Saved and System Automatic raise the Profoma Invoice # : " + refno + "');", true);
                        StrScript += "Details Saved and System Automatic raise the Profoma Invoice # : " + refno;
                        if (hid_SupplyTo.Value != "")
                        {
                            supplyto = customerobj.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                            ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), supplyto);
                        }
                        if (bolcuststat == true)
                        {
                            StrScript += " State Name not Updated in Master,Kindly update Master Customer" + supplyto + ",GST NOT Calculated Propertly";
                        }
                        if (bolcuststat1 == true)
                        {
                            StrScript += " Kindly update SUPPLY TO Name " + supplyto + ",GST NOT Calculated Propertly";
                        }
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('" + StrScript + "');", true);
                        return;
                    }

                   */
                    if (txt_blno.Text != "")
                    {
                        StrScript += " Details Saved for BL# " + txt_blno.Text;
                    }
                    if (Refno != 0)
                    {
                        StrScript += " . System Auto-generated Proforma Sales Invoice # is " + Refno;
                    }
                    if (Refno1 != 0 && Refno == 0)
                    {
                        StrScript += " . System Auto-generated Profoma Purchase Invoice # is " + Refno1;
                    }
                    if (Refno1 != 0 && Refno != 0)
                    {
                        StrScript += " and  Profoma Purchase Invoice # is " + Refno1;
                    }
                    if (refnodebitOs != 0)
                    {
                        StrScript += " and System Auto-generated Proforma OSDN# " + refnodebitOs;
                    }
                    if (refnocreditOs != 0)
                    {
                        StrScript += " and System Auto-generated Proforma OSCN# " + refnocreditOs;
                    }
                    if (bolcuststat == true)
                    {
                        StrScript += " State Name not Updated in Master,Kindly update Master Customer " + supplyto + ",GST NOT Calculated Propertly";
                    }
                    if (bolcuststat1 == true)
                    {
                        StrScript += " Kindly update SUPPLY TO Name " + supplyto + ",GST NOT Calculated Propertly";
                    }
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "BL", "alertify.alert('" + StrScript + "');", true);
                    //if (hidunit.Value == "0")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('For Proforma OS Vouchers ,Base Unit details not calculated properly,Kindly Update the charges once again in proforma screen..);", true);

                    //}
                    invblr = false;
                    txtclear();
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                }//save end
                else if (btn_save.ToolTip == "Update")
                {
                    int cou = 0;
                    for (int i = 0; i < chkListCont.Items.Count; i++)
                    {
                        if (chkListCont.Items[i].Selected == true)
                        {
                            cou = 1;
                        }
                    }
                    if (cou == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Select Atleast one Container');", true);
                        return;
                    }
                    cou = 0;
                    CollectDetails();
                    divisionid = Convert.ToInt32(hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString()));
                    branch = hrempobj.GetBranchId(divisionid, Session["LoginBranchName"].ToString());
                    Boolean blrbook = false;

                    if (Convert.ToInt32(hid_jobtype.Value) != 3)
                    {
                        if (Convert.ToDouble(txtcbm.Text) == 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM must be grater than zero');", true);
                            txtcbm.Focus();

                            return;
                        }
                    }
                    if (txtjobno.Text != "")
                    {
                        int closedjobs = Convert.ToInt32(Invobj.CheckClosedJobs("FI", Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString())));
                        if (closedjobs == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Job # " + txtjobno.Text + " has Closed Already " + "You Can not Update the BL Details.');", true);
                            return;
                        }
                    }
                    if (strbltype == "D")
                    {
                        if (chkNomination.Checked == true)
                        {
                            if (txtbookno.Text != "")
                            {
                                blrbook = true;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Booking # Cannot be Blank');", true);
                                txtbookno.Focus();
                                return;
                            }
                        }
                        InsertContainerDetails();

                        intcbm = Convert.ToDouble(txtcbm.Text);
                        ContSize(txt_blno.Text.Trim(), Convert.ToInt32(hid_jobtype.Value));
                        if (cont20 > 0 && cont40 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit20)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit20 + " ...Since " + cont20 + " X 20 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit40)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit40 + " ...Since " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 > 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit240)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit240 + " ...Since " + cont20 + " X 20 Feet  and " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }

                        getvolume();
                        blobj.UpdateBLDetails(intjobno, txt_blno.Text.Trim(), strbldate, Convert.ToInt32(hiddenid_issue.Value), Convert.ToInt32(Hiddenshipper.Value), txtshipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value), txtconsignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txtnotify.Text, txtnaddress.Text, Convert.ToInt32(Hiddenagent.Value), Convert.ToInt32(Hiddenrecipt.Value), Convert.ToInt32(Hiddenpol.Value), Convert.ToInt32(hiddencharge.Value), Convert.ToInt32(Hiddentxtfinaldes.Value), txtmarksnumbers.Text, txtdescn.Text, Convert.ToDouble(txtcbm.Text), Convert.ToDouble(txtgrossw.Text), Convert.ToDouble(txtnetw.Text), ddlstatus.Text, ddlfreight.Text, Convert.ToInt32(txtpackage.Text), ddlunits.SelectedItem.Text, Convert.ToChar(strNomination), txtMVessel.Text, txtMVoy.Text, Convert.ToInt32(hiddenidtrans.Value), txtUNOcode.Text, txtIMOCode.Text, Convert.ToDouble(oldcbm), Convert.ToInt32(hidintCont20.Value), Convert.ToInt32(hidintCont40.Value), txtremarks.Text, BLSurrendered, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Hiddensalespid.Value), Convert.ToInt32(hiddencargo.Value), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (blrbook == true)
                        {
                            blrbook = false;
                            blobj.UpdateBooking(txtbookno.Text, txt_blno.Text.Trim(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            ///added on 10mar2022 as per instruction on nambi sir
                            getsupplytovalues();
                            DataTable dtnew = new DataTable();

                            dtnew = ProINVobj.Getinvoicecount(txt_blno.Text.Trim(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtjobno.Text));
                            if (dtnew.Rows.Count == 0)
                            {
                                AutoInvoice();
                                Autocnops4negativeQuotation();
                            }
                            DataTable dtnew1 = new DataTable();
                            dtnew1 = ProINVobj.Getpacount(txt_blno.Text.Trim(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtjobno.Text));
                            if (dtnew.Rows.Count == 0)
                            {
                                Autocnops();
                            }
                        }

                        ///hide on 10mar2022 as per instruction on nambi sir
                        //  getsupplytovalues();
                        //DataTable dtnew = new DataTable();

                        //  dtnew = ProINVobj.Getinvoicecount(txt_blno.Text.Trim(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtjobno.Text));
                        //  if (dtnew.Rows.Count == 0)
                        //   {
                        //        AutoInvoice();
                        //   }
                        //  DataTable dtnew1 = new DataTable();
                        //  dtnew1 = ProINVobj.Getpacount(txt_blno.Text.Trim(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtjobno.Text));
                        //    if (dtnew.Rows.Count == 0)
                        //    {
                        //        Autocnops();
                        //    }




                        /* autodebitOS();
                         autocreditOS();*/

                        //getsupplytovalues();
                        //Autocnops();
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 122, 2, Convert.ToInt32(Session["LoginBranchId"].ToString()), txt_blno.Text + "/U");
                    }//strbl D
                    else if (strbltype == "F")
                    {
                        if (chkNomination.Checked == true)
                        {
                            if (txtbookno.Text != "")
                            {
                                blrbook = true;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Booking # Cannot be Blank');", true);
                                txtbookno.Focus();
                                return;
                            }
                        }
                        InsertContainerDetails();
                        intcbm = Convert.ToDouble(txtcbm.Text);
                        ContSize(txt_blno.Text.Trim(), Convert.ToInt32(hid_jobtype.Value));
                        if (cont20 > 0 && cont40 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit20)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit20 + " ...Since " + cont20 + " X 20 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit40)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit40 + " ...Since " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 > 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit240)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit240 + " ...Since " + cont20 + " X 20 Feet  and " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        string BLSurrendereded = "";
                        if (chkBLSurr.Checked == true)
                        {
                            BLSurrendereded = "Y";
                        }
                        else
                        {
                            BLSurrendereded = "N";
                        }

                        getvolume();
                        blobj.UpdateFBLDetails(intjobno, txt_blno.Text.Trim(), strbldate, Convert.ToInt32(hiddenid_issue.Value), Convert.ToInt32(Hiddenshipper.Value), txtshipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value), txtconsignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txtnotify.Text, txtnaddress.Text, Convert.ToInt32(Hiddenagent.Value), Convert.ToInt32(Hiddenrecipt.Value), Convert.ToInt32(Hiddenpol.Value), Convert.ToInt32(hiddencharge.Value), Convert.ToInt32(Hiddentxtfinaldes.Value), txtmarksnumbers.Text, txtdescn.Text, Convert.ToDouble(txtcbm.Text), Convert.ToDouble(txtgrossw.Text), Convert.ToDouble(txtnetw.Text), ddlstatus.Text, ddlfreight.Text, Convert.ToInt32(txtpackage.Text), ddlunits.SelectedItem.Text, Convert.ToChar(strNomination), txtMVessel.Text, txtMVoy.Text, Convert.ToInt32(hiddenidtrans.Value), txtUNOcode.Text, txtIMOCode.Text, txtremarks.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Hiddensalespid.Value), Convert.ToInt32(hiddencargo.Value), Convert.ToInt32(Session["LoginDivisionId"].ToString()), BLSurrendereded);
                        if (blrbook == true)
                        {
                            blrbook = false;
                            blobj.UpdateBooking(txtbookno.Text, txt_blno.Text.Trim(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        }
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 123, 2, Convert.ToInt32(Session["LoginBranchId"].ToString()), txt_blno.Text + "/U");
                    }//strbl f
                    else if (strbltype == "S")
                    {
                        if (chkNomination.Checked == true)
                        {
                            strNomination = "N";

                            // added on 29Mar2022
                            if (txtbookno.Text != "")
                            {
                                blrbook = true;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Booking # Cannot be Blank');", true);
                                txtbookno.Focus();
                                return;
                            }
                        }
                        else
                        {
                            strNomination = "F";
                        }
                        InsertContainerDetails();

                        intcbm = Convert.ToDouble(txtcbm.Text);
                        ContSize(txt_blno.Text.Trim(), Convert.ToInt32(hid_jobtype.Value));
                        if (cont20 > 0 && cont40 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit20)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit20 + " ...Since " + cont20 + " X 20 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 == 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit40)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit40 + " ...Since " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }
                        else if (cont40 > 0 && cont20 > 0)
                        {
                            if (Convert.ToDouble(txtcbm.Text) > limit240)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('CBM sholuld be lesser than or equal to " + limit240 + " ...Since " + cont20 + " X 20 Feet  and " + cont40 + " X 40 Feet Container(s) was selected');", true);
                                blobj.DelContainerDetails(Convert.ToInt32(txtjobno.Text), txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                txtcbm.Focus();
                                return;
                            }
                        }

                        getvolume();
                        blobj.UpdateSBLDetails(intjobno, txt_blno.Text.Trim(), strbldate, Convert.ToInt32(hiddenid_issue.Value), Convert.ToInt32(Hiddenshipper.Value), txtshipper.Text, txtsaddress.Text, Convert.ToInt32(Hiddenconsignee.Value), txtconsignee.Text, txtcaddress.Text, Convert.ToInt32(Hiddennotify.Value), txtnotify.Text, txtnaddress.Text, Convert.ToInt32(Hiddenagent.Value), Convert.ToInt32(Hiddenrecipt.Value), Convert.ToInt32(Hiddenpol.Value), Convert.ToInt32(hiddencharge.Value), Convert.ToInt32(Hiddentxtfinaldes.Value), txtmarksnumbers.Text, txtdescn.Text, Convert.ToDouble(txtcbm.Text), Convert.ToDouble(txtgrossw.Text), Convert.ToDouble(txtnetw.Text), ddlstatus.Text, ddlfreight.Text, Convert.ToInt32(txtpackage.Text), ddlunits.SelectedItem.Text, Convert.ToChar(strNomination), txtMVessel.Text, txtMVoy.Text, Convert.ToInt32(hiddenidtrans.Value), txtUNOcode.Text, txtIMOCode.Text, strSBL, Convert.ToInt32(branch), Convert.ToDouble(oldcbm), Convert.ToInt32(hidintCont20.Value), Convert.ToInt32(hidintCont40.Value), txtremarks.Text, BLSurrendered, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Hiddensalespid.Value), Convert.ToInt32(hiddencargo.Value), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                        //ADDED AS PER NAMBI SIR INSTRUCTION 29032022
                        if (blrbook == true)
                        {
                            blrbook = false;
                            blobj.UpdateBooking(txtbookno.Text, txt_blno.Text.Trim(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            ///added on 10mar2022 as per instruction on nambi sir
                            getsupplytovalues();
                            DataTable dtnew = new DataTable();

                            dtnew = ProINVobj.Getinvoicecount(txt_blno.Text.Trim(), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtjobno.Text));
                            if (dtnew.Rows.Count == 0)
                            {
                                AutoInvoice();
                                Autocnops4negativeQuotation();

                                //autodebitOS();
                                //autocreditOS();
                            }

                        }
                        //END

                        // blobj.UpdateBookingnew(txtbookno.Text, strbl, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));


                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 124, 2, Convert.ToInt32(Session["LoginBranchId"].ToString()), txt_blno.Text + "/U");
                    }//strbl s


                    // btn_save.Text = "Save";
                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Details Updated');", true);


                    if (txt_blno.Text != "")
                    {
                        StrScript += " Details Updated for BL# " + txt_blno.Text;
                    }
                    if (Refno != 0)
                    {
                        StrScript += "and System Auto-generated Proforma Invoice #" + Refno;
                    }
                    if (Refno1 != 0)
                    {
                        StrScript += "and System Auto-generated Profoma Credit Note - Operations #" + Refno1;
                    }
                    if (refnodebitOs != 0)
                    {
                        StrScript += "and System Auto-generated Proforma OSDN#" + refnodebitOs;
                    }
                    if (refnocreditOs != 0)
                    {
                        StrScript += "and System Auto-generated Proforma OSCN#" + refnocreditOs;
                    }
                    //if (bolcuststat == true)
                    //{
                    //    StrScript += " State Name not Updated in Master,Kindly update Master Customer " + supplyto + ",GST NOT Calculated Propertly";
                    //}
                    //if (bolcuststat1 == true)
                    //{
                    //    StrScript += " Kindly update SUPPLY TO Name " + supplyto + ",GST NOT Calculated Propertly";
                    //}
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "BL", "alertify.alert('" + StrScript + "');", true);

                    invblr = false;
                    txtclear();

                }//Update
                btn_cancel.Enabled = true;
                btn_cancel.ForeColor = System.Drawing.Color.White;
                txt_blno.Focus();
                UserRights();
                btn_save.Enabled = false;
                btn_save.ForeColor = System.Drawing.Color.Gray;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        public void ChkCustStateName(int custid, string custname)
        {
            if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
            {
                if (custname != "" && custid > 0)
                {

                    //int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    DataTable dt_list = new DataTable();
                    dt_list = customerobj.GetIndianCustomergstadd(custid);
                    if (dt_list.Rows.Count == 0)
                    {
                        // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                        bolcuststat = true;

                    }
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Kindly update SUPPLY TO Name " + custname + "');", true);
                    bolcuststat1 = true;

                }
            }
        }
        public void InsertAmendContainerDetails()
        {
            try
            {
                for (int i = 0; i < chkListCont.Items.Count; i++)
                {
                    if (chkListCont.Items[i].Selected == true)
                    {
                        strcontno = chkListCont.Items[i].ToString();
                        blobj.DelAmendContDetails(intjobno, txt_blno.Text, strcontno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        blobj.InsertAmendContDetails(intjobno, txt_blno.Text.Trim(), strcontno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }
                    else
                    {
                        strcontno = chkListCont.Items[i].ToString();
                        blobj.DelAmendContDetails(intjobno, txt_blno.Text, strcontno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        public void InsertAgentRebatetoProforma()
        {
            try
            {
                double exratedata = Invobj.GetExRate("INR", Logobj.GetDate(), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                if (exratedata != 0)
                {
                    DataTable DtCharge = new DataTable();
                    DataTable Dt = new DataTable();
                    invblr = false;
                    invoiceno = 0;
                    refno = 0;
                    string strShiprefno;
                    int intcongid = 0;


                    if (txtIMOCode.Text == "ZZZZZ" && txtUNOcode.Text == "ZZZ")
                    {
                        dgcargo = "N";
                    }
                    else
                    {
                        dgcargo = "D";
                    }
                    if (Convert.ToInt32(hid_jobtype.Value) != 3)
                    {
                        if (Convert.ToInt32(hid_jobtype.Value) != 2)
                        {
                            if (strbltype == "S")
                            {
                                intcongid = blobj.GetFBLConsFromSplit(txt_blno.Text, Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }
                            else
                            {
                                intcongid = Convert.ToInt32(Hiddenconsignee.Value);
                            }
                            hid_intcustomerid.Value = intcongid.ToString();
                            if (chkNomination.Checked == false)
                            {
                                if (strbltype == "D")
                                {
                                    DtCharge = Invobj.GetAgentRebateChargeDetails(Convert.ToInt32(hiddenjobagentid.Value), Convert.ToInt32(hiddenjobpolid.Value), Convert.ToInt32(hiddenjobpodid.Value), Convert.ToChar("D"), Convert.ToChar(dgcargo));
                                }
                                else if (strbltype == "S")
                                {
                                    DtCharge = Invobj.GetAgentRebateChargeDetails(Convert.ToInt32(hiddenjobagentid.Value), Convert.ToInt32(hiddenjobpolid.Value), Convert.ToInt32(hiddenjobpodid.Value), Convert.ToChar("F"), Convert.ToChar(dgcargo));
                                }
                                if (DtCharge.Rows.Count > 0)
                                {
                                    Dt = Invobj.CheckInvCustblno(txt_blno.Text, intcongid, "FI", "I", Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToChar("N"));
                                    if (Dt.Rows.Count > 0)
                                    {
                                        invoiceno = Convert.ToInt32(Dt.Rows[0].ItemArray[0].ToString());
                                        Invobj.DelIinvoiceDetailsFromInvNo(invoiceno, Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                        for (int i = 0; i < Dt.Rows.Count; i++)
                                        {
                                            strcharge = DtCharge.Rows[i]["chargename"].ToString();
                                            double exrate;
                                            exrate = Invobj.GetExRate(DtCharge.Rows[i]["curr"].ToString(), Logobj.GetDate(), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                                            amount = CheckBase(DtCharge.Rows[i]["base"].ToString(), Convert.ToDouble(DtCharge.Rows[i]["amount"].ToString()), exrate);
                                            Invobj.InsertInvoiceDetails(invoiceno, ChargeObj.GetChargeid(strcharge), DtCharge.Rows[i]["curr"].ToString(), Convert.ToDouble(DtCharge.Rows[i]["amount"].ToString()), exrate, FBase, amount, Convert.ToInt32(Session["LoginBranchId"].ToString()), "Invoice", Convert.ToInt32(Hiddenconsignee.Value), Convert.ToInt32(Session["Vouyear"].ToString()), "C", "FI");
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 23, 1, Convert.ToInt32(Session["LoginBranchId"].ToString()), strtrantype + invoiceno + "/" + strcharge + "/S");
                                            invblr = true;
                                        }
                                    }
                                    else
                                    {
                                        // refno = ProINVobj.InsertProInvoiceHead(Logobj.GetDate(), "FI", Convert.ToInt32(txtjobno.Text), intcongid, txt_blno.Text, txtremarks.Text, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), "Profoma Invoice", "", 0);
                                        getsupplytovalues();
                                        refno = ProINVobj.InsertProInvoiceHead(Logobj.GetDate(), "FI", Convert.ToInt32(txtjobno.Text), intcongid, txt_blno.Text, txtremarks.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), "Profoma Invoice", "", 0, Convert.ToInt32(hid_SupplyTo.Value));
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 779, 1, Convert.ToInt32(Session["LoginBranchId"].ToString()), "FI" + refno);
                                        for (int i = 0; i < DtCharge.Rows.Count; i++)
                                        {
                                            strcharge = DtCharge.Rows[i]["chargename"].ToString();
                                            double exrate;
                                            exrate = Invobj.GetExRate(DtCharge.Rows[i]["curr"].ToString(), Logobj.GetDate(), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                                            amount = CheckBase(DtCharge.Rows[i]["base"].ToString(), Convert.ToDouble(DtCharge.Rows[i]["amount"].ToString()), exrate);
                                            ProINVobj.InsertProInvoiceDetails(refno, ChargeObj.GetChargeid(strcharge), DtCharge.Rows[i]["curr"].ToString(), Convert.ToDouble(DtCharge.Rows[i]["amount"].ToString()), exrate, FBase, amount, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), "C", "FI", "Profoma Invoice", "Y", unit);
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 779, 1, Convert.ToInt32(Session["LoginBranchId"]), "FI" + refno + "/" + strcharge + "/S");
                                            invblr = true;
                                        }
                                    }
                                }
                                if (strbltype == "S")
                                {
                                    strShiprefno = FBooking;
                                    intcongid = blobj.GetFBLConsFromSplit(txt_blno.Text, Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                }
                                else
                                {
                                    strShiprefno = txtbookno.Text.Trim();
                                    intcongid = intconsignee;
                                }
                                hid_intcustomerid.Value = intcongid.ToString();
                                DtCharge = bookingobj.GetBookingDetailsFromShiprefNo(strShiprefno, "FI", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                if (DtCharge.Rows.Count > 0)
                                {
                                    Dt = Invobj.CheckInvCustblno(txt_blno.Text, intcongid, "FI", "I", Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToChar("N"));
                                    if (Dt.Rows.Count > 0)
                                    {
                                        invoiceno = Convert.ToInt32(Dt.Rows[0].ItemArray[0].ToString());
                                        Invobj.DelIinvoiceDetailsFromInvNo(invoiceno, Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                        for (int i = 0; i < DtCharge.Rows.Count; i++)
                                        {
                                            strcharge = DtCharge.Rows[i]["chargename"].ToString();
                                            double exrate;
                                            exrate = Invobj.GetExRate(DtCharge.Rows[i]["curr"].ToString(), Logobj.GetDate(), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                                            amount = CheckBase(DtCharge.Rows[i]["base"].ToString(), Convert.ToDouble(DtCharge.Rows[i]["amount"].ToString()), exrate);
                                            Invobj.InsertInvoiceDetails(invoiceno, Convert.ToInt32(ChargeObj.GetChargeid(strcharge)), DtCharge.Rows[i]["curr"].ToString(), Convert.ToDouble(DtCharge.Rows[i]["amount"].ToString()), exrate, FBase, amount, Convert.ToInt32(Session["LoginBranchId"].ToString()), "Invoice", intconsignee, Convert.ToInt32(Session["Vouyear"].ToString()), "C", "FI");
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 23, 1, Convert.ToInt32(Session["LoginBranchId"].ToString()), strtrantype + invoiceno + "/" + strcharge + "/S");
                                            invblr = true;
                                        }
                                    }
                                    else
                                    {
                                        getsupplytovalues();
                                        //  refno = ProINVobj.InsertProInvoiceHead(Logobj.GetDate(), "FI", Convert.ToInt32(txtjobno.Text), intcongid, txt_blno.Text, txtremarks.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), "Profoma Invoice", "", 0);
                                        refno = ProINVobj.InsertProInvoiceHead(Logobj.GetDate(), "FI", Convert.ToInt32(txtjobno.Text), intcongid, txt_blno.Text, txtremarks.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), "Profoma Invoice", "", 0, Convert.ToInt32(hid_SupplyTo.Value));
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 779, 1, Convert.ToInt32(Session["LoginBranchId"].ToString()), "FI" + refno);
                                        for (int i = 0; i < DtCharge.Rows.Count; i++)
                                        {
                                            strcharge = DtCharge.Rows[i]["chargename"].ToString();
                                            double exrate;
                                            exrate = Invobj.GetExRate(DtCharge.Rows[i]["curr"].ToString(), Logobj.GetDate(), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                                            amount = CheckBase(DtCharge.Rows[i]["base"].ToString(), Convert.ToDouble(DtCharge.Rows[i]["amount"].ToString()), exrate);
                                            ProINVobj.InsertProInvoiceDetails(refno, Convert.ToInt32(ChargeObj.GetChargeid(strcharge)), DtCharge.Rows[i]["curr"].ToString(), Convert.ToDouble(DtCharge.Rows[i]["amount"].ToString()), exrate, FBase, amount, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), "C", "FI", "Profoma Invoice", "Y", Convert.ToDouble(unit));
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 779, 1, Convert.ToInt32(Session["LoginBranchId"].ToString()), "FI" + refno + "/" + strcharge + "/S");
                                            invblr = true;
                                        }
                                    }
                                }
                            }//chk false
                        }
                    }
                }//exrate data
            }//InsertAgentRebatetoProforma
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        public double CheckBase(string strbase, double rate, double exrate)
        {
            double strvolume;
            double strntweight;
            double strchgweight;
            double strgrosswght;
            double sizecount;

            FBase = strbase;
            if (strbase.ToUpper() == "BL" || strbase.ToUpper() == "HWBL" || strbase.ToUpper() == "DOC")
            {
                amount = rate * exrate;
                unit = 1;
            }
            else if (strbase.ToUpper() == "CBM" || strbase.ToUpper() == "MT" || strbase.ToUpper() == "W/M")
            {
                if (strbase.ToUpper() == "CBM")
                {
                    if (strtrantype == "FE")
                    {
                        if (lbl_header.Text == "InvoiceWoJ")
                        {
                            strvolume = Convert.ToDouble(Invobj.GetVolume(txt_blno.Text, "Wo", Convert.ToInt32(Session["LoginBranchId"].ToString())));
                            amount = rate * exrate * strvolume;
                            unit = strvolume;
                        }
                        else
                        {
                            strvolume = Invobj.GetVolume(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            amount = rate * exrate * strvolume;
                            unit = strvolume;
                        }
                    }
                    else
                    {
                        strvolume = Invobj.GetVolume(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * strvolume;
                        unit = strvolume;
                    }
                }
                else if (strbase.ToUpper() == "W/M")
                {
                    if (strtrantype == "FE")
                    {
                        if (lbl_header.Text == "InvoiceWoJ")
                        {
                            strvolume = Convert.ToDouble(Invobj.GetVolume(txt_blno.Text, "Wo", Convert.ToInt32(Session["LoginBranchId"].ToString())));
                            amount = rate * exrate * strvolume;
                            unit = strvolume;
                        }
                        else
                        {
                            strvolume = Invobj.GetVolume(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            amount = rate * exrate * strvolume;
                            unit = strvolume;
                        }
                    }
                    else
                    {
                        strvolume = Invobj.GetVolume(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * strvolume;
                        unit = strvolume;
                    }
                }
                else
                {
                    if (strbase.ToUpper() == "MT")
                    {
                        if (strtrantype == "FE")
                        {
                            if (lbl_header.Text == "InvoiceWOJ")
                            {
                                //strntweight = Invobj.GetWeight(txt_blno.Text, "Wo", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                //amount = rate * exrate * (strntweight / 1000);
                                //unit = (strntweight / 1000);

                                strntweight = Invobj.GetWeightnew(txt_blno.Text, "Wo", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                amount = rate * exrate * (strntweight);
                                unit = (strntweight);
                            }
                            else
                            {
                                //strntweight = Invobj.GetWeight(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                //amount = rate * exrate * (strntweight / 1000);
                                //unit = (strntweight / 1000);

                                strntweight = Invobj.GetWeightnew(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                                amount = rate * exrate * (strntweight);
                                unit = (strntweight);
                            }
                        }
                        else
                        {
                            //strntweight = Invobj.GetWeight(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            //amount = rate * exrate * (strntweight / 1000);
                            //unit = (strntweight / 1000);

                            strntweight = Invobj.GetWeightnew(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                            amount = rate * exrate * (strntweight);
                            unit = (strntweight);
                        }
                    }
                }
                strvolume = Invobj.GetVolume(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                cbmAmt = rate * exrate * strvolume;
                //strntweight = Invobj.GetWeight(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                // mtAmt = rate * exrate * (strntweight / 1000);


                strntweight = Invobj.GetWeightnew(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                mtAmt = rate * exrate * (strntweight);

                if (cbmAmt < mtAmt)
                {
                    FBase = "MT";
                    amount = mtAmt;
                    unit = (strntweight);
                }
                else
                {
                    if (strbase.ToUpper() == "W/M")
                    {
                        FBase = "W/M";
                        amount = cbmAmt;
                        unit = strvolume;
                    }
                    else
                    {
                        FBase = "CBM";
                        amount = cbmAmt;
                        unit = strvolume;
                    }
                }
            }
            else
            {
                if (strbase.ToUpper() == "KGS" || strbase.ToUpper() == "Kgs") // strbase == "Kgs" || strbase == "KGS"
                {
                    if (strtrantype == "AE" || strtrantype == "AI")
                    {
                        strchgweight = Invobj.GetChargeWeight(txt_blno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * strchgweight;
                        unit = strchgweight;
                    }
                    else
                    {
                        strgrosswght = Invobj.GetGrossWeight(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * strgrosswght;
                        unit = strgrosswght;
                    }
                }
                else if (strbase.ToUpper() == "SB")
                {
                    if (strtrantype == "FE")
                    {
                        sizecount = Invobj.GetSBillCount(txt_blno.Text, Convert.ToInt32(txtjobno.Text), "BL", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * sizecount;
                        unit = sizecount;
                    }
                }
                else
                {
                    if (strtrantype == "FE")
                    {
                        sizecount = Invobj.GetBaseCount(txt_blno.Text, strbase, strtrantype, "BL", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * sizecount;
                        unit = sizecount;
                    }
                    else
                    {
                        sizecount = Invobj.GetBaseCount(txt_blno.Text, strbase, strtrantype, "BL", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                        amount = rate * exrate * sizecount;
                        unit = sizecount;
                    }
                }
            }
            //DataAccess.Accounts.DCAdvise DCAdviseObj = new //DataAccess.Accounts.DCAdvise();
            hid_fd.Value = DCAdviseObj.GetFDFromBLNO(txt_blno.Text, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), "H");
            hid_douvolume.Value = unit.ToString();
            return amount;
        }//checkbase

        public void getvolume()
        {
            dtbl = fijobobj.ShowJobDetails(intjobno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (dtbl.Rows.Count > 0)
            {
                strjobvessel = vesselobj.GetVesselname(Convert.ToInt32(dtbl.Rows[0].ItemArray[1].ToString()));
                intjobtype = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                voyage = dtbl.Rows[0].ItemArray[2].ToString();
                jobdate = Convert.ToDateTime(dtbl.Rows[0].ItemArray[25].ToString());
            }
            if (Convert.ToInt32(hid_jobtype.Value) == 3)
            {
                intCont20 = blobj.GetContainersizetype(txt_blno.Text, 20, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                hidintCont20.Value = intCont20.ToString();
                intCont40 = blobj.GetContainersizetype(txt_blno.Text, 40, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                hidintCont40.Value = intCont40.ToString();
                volume = Convert.ToDouble(txtcbm.Text);
                Status = "F";
            }
            else
            {
                intCont20 = blobj.GetContainersizetype(txt_blno.Text, 20, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                hidintCont20.Value = intCont20.ToString();
                intCont40 = blobj.GetContainersizetype(txt_blno.Text, 40, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                hidintCont40.Value = intCont40.ToString();
                volume = Convert.ToDouble(txtcbm.Text);
                Status = "L";
            }
        }

        public void ContSize(string blno, int shipmentype)
        {

            if (Convert.ToInt32(hid_jobtype.Value) == 3)
            {
                cont = blobj.GetCont2040(blno, 20, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                cont20 = cont;
                cont = blobj.GetCont2040(blno, 40, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                cont40 = cont;
                Status = "F";
                volume = intcbm;
            }
            else
            {
                cont = blobj.GetCont2040(blno, 20, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                cont20 = cont;
                cont = blobj.GetCont2040(blno, 40, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                cont40 = cont;
                Status = "L";
                volume = intcbm;
            }
            dtcont = blobj.GetCBMLimt4cont();
            if (dtcont.Rows.Count > 0)
            {
                if (cont20 > 0 && cont40 == 0)
                {
                    limit20 = Convert.ToInt32(dtcont.Rows[0].ItemArray[0].ToString()) * cont20;
                }
                if (cont40 > 0 && cont20 == 0)
                {
                    limit40 = Convert.ToInt32(dtcont.Rows[0].ItemArray[1].ToString()) * cont40;
                }
                if (cont20 > 0 && cont40 > 0)
                {
                    limit240 = (Convert.ToInt32(dtcont.Rows[0].ItemArray[0].ToString()) * cont20) + (Convert.ToInt32(dtcont.Rows[0].ItemArray[1].ToString()) * cont40);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Container Limit Not Exists...Pls Check with IT Dept');", true);
            }



        }
        public void InsertContainerDetails()
        {
            blobj.DelContainerDetails(intjobno, txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            for (int i = 0; i < chkListCont.Items.Count; i++)
            {
                if (chkListCont.Items[i].Selected == true)
                {
                    strcontno = chkListCont.Items[i].ToString();
                    blobj.InsertContDetails(intjobno, txt_blno.Text, strcontno, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                }
            }


        }

        public void CollectDetails()
        {
            if (chkNomination.Checked == true)
            {
                if (txtbookno.Text == "0")
                {
                    txtbookno.Text = "";
                }
                if (txtbookno.Text != "")
                {
                    strNomination = "N";
                }
                else
                {
                    strNomination = "F";
                }
            }
            else if (chkNomination.Checked == false)
            {
                if (txtbookno.Text != "")
                {
                    strNomination = "N";
                }
                else
                {
                    strNomination = "F";
                }
            }
            if (txtbookno.Text != "")
            {
                dtbl = bookingobj.GetBookingDetails(txtbookno.Text, "FI", Convert.ToInt32(Session["LoginBranchId"].ToString()));
                if (dtbl.Rows.Count > 0)
                {
                    intbooking = dtbl.Rows[0]["bookingno"].ToString();
                }
            }
            if (chkBLSurr.Checked == true)
            {
                BLSurrendered = "Y";
            }
            else
            {
                BLSurrendered = "N";
            }
            txtshipper.Text = customerobj.GetCustomername(Convert.ToInt32(Hiddenshipper.Value));
            txtconsignee.Text = customerobj.GetCustomername(Convert.ToInt32(Hiddenconsignee.Value));
            txtnotify.Text = customerobj.GetCustomername(Convert.ToInt32(Hiddennotify.Value));


        }

        public void checkdata()
        {

            if (txt_blno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('BL # cannot be Empty');", true);
                txt_blno.Focus();
                blnerr = true;
                return;
            }
            if (hiddenid_issue.Value == "" || hiddenid_issue.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Issued at cannot be Empty');", true);
                txt_blissuseat.Focus();
                blnerr = true;
                return;
            }
            if (ddlfreight.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Select Frieght');", true);
                blnerr = true;
                ddlfreight.Focus();
                return;
            }
            if (txtcargo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert(' Commodity cannot be empty');", true);
                blnerr = true;
                txtcargo.Focus();
                return;
            }
            else
            {
                if (hiddencargo.Value == "" || hiddencargo.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Cargo Name');", true);
                    txtcargo.Focus();
                    blnerr = true;
                    return;
                }
            }
            if (Hiddenshipper.Value == "" || Hiddenshipper.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Shipper cannot be Empty');", true);
                blnerr = true;
                txtshipper.Focus();
                return;
            }
            if (Hiddenconsignee.Value == "" || Hiddenconsignee.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Consignee cannot be Empty');", true);
                blnerr = true;
                txtconsignee.Focus();
                return;
            }
            if (txtnotify.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Notify cannot be Empty');", true);
                blnerr = true;
                txtnotify.Focus();
                return;
            }

            if (Hiddenagent.Value == "" || Hiddenagent.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Agent cannot be Empty');", true);
                blnerr = true;
                txtagent.Focus();
                return;
            }
            if (txtreceipt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Receipt Port Name cannot be Empty');", true);
                blnerr = true;
                txtreceipt.Focus();
                return;
            }
            else
            {
                if (Hiddenrecipt.Value == "" || Hiddenrecipt.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Receipt Port Name');", true);
                    blnerr = true;
                    txtreceipt.Focus();
                    return;
                }
            }
            if (txtpol.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Loading Port Name cannot be Empty');", true);
                blnerr = true;
                txtpol.Focus();
                return;
            }
            else
            {
                if (Hiddenpol.Value == "" || Hiddenpol.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Loading Port Name');", true);
                    blnerr = true;
                    txtpol.Focus();
                    return;
                }
            }
            if (txtpodis.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Port of discharge cannot be Empty');", true);
                blnerr = true;
                txtpodis.Focus();
                return;
            }
            else
            {
                if (hiddencharge.Value == "" || hiddencharge.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Destination discharge Name');", true);
                    blnerr = true;
                    txtpodis.Focus();
                    return;
                }
            }
            if (txtpodis.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Destination Port Name cannot be Empty');", true);
                blnerr = true;
                txtpodis.Focus();
                return;
            }
            else
            {
                if (hiddencharge.Value == "" || hiddencharge.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Destination Port Name');", true);
                    blnerr = true;
                    txtpodis.Focus();
                    return;
                }
            }

            if (txtfinaldes.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Place of Delivery Port Name cannot be Empty');", true);
                blnerr = true;
                txtfinaldes.Focus();
                return;
            }
            else
            {
                if (Hiddentxtfinaldes.Value == "" || Hiddentxtfinaldes.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Place of Delivery Port Name');", true);
                    blnerr = true;
                    txtfinaldes.Focus();
                    return;
                }
            }

            if (txtmarksnumbers.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Marks Number  cannot be empty');", true);
                txtmarksnumbers.Focus();
                blnerr = true;
                return;
            }
            if (txtdescn.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Description  cannot be empty');", true);
                txtdescn.Focus();
                blnerr = true;
                return;
            }
            if (txtcbm.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Cubic meter  cannot be empty');", true);
                txtcbm.Focus();
                blnerr = true;
                return;
            }
            if (txtgrossw.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Gross weight  cannot be empty');", true);
                txtgrossw.Focus();
                blnerr = true;
                return;
            }

            if (txtnetw.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Net weight  cannot be empty');", true);
                txtnetw.Focus();
                blnerr = true;
                return;
            }
            if (ddlstatus.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Select Shipment Status');", true);
                ddlstatus.Focus();
                blnerr = true;
                return;
            }
            if (txtpackage.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Packages  cannot be empty');", true);
                txtpackage.Focus();
                blnerr = true;
                return;
            }
            if (ddlunits.SelectedValue == "0" || ddlunits.Text == "Units")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Select Units Status');", true);
                ddlunits.Focus();
                blnerr = true;
                return;
            }

            //if (ddlunits.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Select Package Units');", true);
            //    blnerr = true;
            //    ddlunits.Focus();
            //    return;
            //}

            if (txtMVessel.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Mother Vessel cannot be empty');", true);
                blnerr = true;
                txtMVessel.Focus();
                return;
            }
            else
            {
                if (Hiddenvessel.Value == "" || Hiddenvessel.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Vessel Name');", true);
                    blnerr = true;
                    txtMVessel.Focus();
                    return;
                }
            }
            if (txtMVoy.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Mother Voyage cannot be empty');", true);
                blnerr = true;
                txtMVoy.Focus();
                return;
            }
            if (txtTranshipped.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Tranship port name cannot be empty');", true);
                blnerr = true;
                txtTranshipped.Focus();
                return;
            }
            else
            {
                if (hiddenidtrans.Value == "" || hiddenidtrans.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Invalid Tranship Port Name');", true);
                    blnerr = true;
                    txtTranshipped.Focus();
                    return;
                }
            }
            if (txtUNOcode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('UNO CODE cannot be empty');", true);
                blnerr = true;
                txtUNOcode.Focus();
                return;
            }
            if (txtIMOCode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('IMO code cannot be empty');", true);
                blnerr = true;
                txtIMOCode.Focus();
                return;
            }
            //if (txtremarks.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Remarks cannot be empty');", true);
            //    blnerr = true;
            //    txtremarks.Focus();
            //    return;
            //}

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            strcomments = FEblobj.DelBlDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), "FI", "");
            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 2, 4, Convert.ToInt32(Session["LoginBranchId"].ToString()), "FI-BLDel");
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert(' " + strcomments + "');", true);
            txtclear();
            txt_blno.Text = "";
            txtclear();
            btn_cancel.Enabled = true;
            btn_cancel.ForeColor = System.Drawing.Color.White;
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BL", "alertify.alert('Details Deleted');", true);
            UserRights();
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                string str_sf = "";
                string str_SP = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (lbl_header.Text == "Amendment BLDetails")
                {
                    if (string.IsNullOrEmpty(txt_blno.Text))
                    {
                        str_RptName = "Amendment.rpt";
                        str_sf = "{FIAmendmentBLdetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {FIAmendmentBLdetails.blno }=" + txt_blno.Text + " and {FIAmendmentBLdetails.jobno }=" + txtjobno.Text;
                        Session["str_sfs"] = "{FIAmendmentBLdetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {FIAmendmentBLdetails.blno }='" + txt_blno.Text + "' and {FIAmendmentBLdetails.jobno }=" + txtjobno.Text;
                        str_SP = "division=" + Session["LoginDivisionName"] + "~branch=" + Session["LoginBranchName"];
                        Session["str_sp"] = "division=" + Session["LoginDivisionName"] + "~branch=" + Session["LoginBranchName"];
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_SP + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "FIBLDetails", str_Script, true);
                    }
                }
                if (txtjobno.Text != "" && txt_blno.Text != "")
                {
                    if (txt_blno.Text != "")
                    {
                        str_RptName = "FIBLDetails.rpt";
                        str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {FIBLDetails.jobno}=" + txtjobno.Text;
                        Session["str_sfs"] = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {FIBLDetails.jobno}=" + txtjobno.Text;
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_SP + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "FIBLDetails", str_Script, true);
                    }
                    else
                    {
                        if (txt_blno.Text != "")
                        {
                            str_RptName = "FIBLDetails.rpt";
                            str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            Session["str_sfs"] = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_SP + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "FIBLDetails", str_Script, true);
                        }
                        else
                        {
                            str_RptName = "FIBL4PL.rpt";
                            str_sf = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {FIBLDetails.blno }=" + txt_blno.Text + "";
                            Session["str_sfs"] = "{FIBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + " and {FIBLDetails.blno }='" + txt_blno.Text + "'";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_SP + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "FIBLDetails", str_Script, true);
                        }
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

        protected void Grd_Job_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCustomer1 = (Label)e.Row.FindControl("JobType");
                string tooltip1 = lblCustomer1.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip1);
                Label lblCustomer2 = (Label)e.Row.FindControl("vessel");
                string tooltip2 = lblCustomer2.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip2);
                Label lblCustomer3 = (Label)e.Row.FindControl("agent");
                string tooltip3 = lblCustomer3.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip3);
                Label lblCustomer4 = (Label)e.Row.FindControl("pol");
                string tooltip4 = lblCustomer4.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip4);
                Label lblCustomer5 = (Label)e.Row.FindControl("pod");
                string tooltip5 = lblCustomer5.Text;
                e.Row.Cells[5].Attributes.Add("title", tooltip5);
                Label lblCustomer6 = (Label)e.Row.FindControl("mblno");
                string tooltip6 = lblCustomer6.Text;
                e.Row.Cells[6].Attributes.Add("title", tooltip6);
                Label lblCustomer7 = (Label)e.Row.FindControl("mlo");
                string tooltip7 = lblCustomer7.Text;
                e.Row.Cells[7].Attributes.Add("title", tooltip7);
                Label lblCustomer8 = (Label)e.Row.FindControl("etb");
                string tooltip8 = lblCustomer8.Text;
                e.Row.Cells[8].Attributes.Add("title", tooltip8);
                Label lblCustomer9 = (Label)e.Row.FindControl("eta");
                string tooltip9 = lblCustomer9.Text;
                e.Row.Cells[9].Attributes.Add("title", tooltip9);



                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Job, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Booking_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Booking, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txtjobno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtjobno.Text = Grd_Job.SelectedRow.Cells[0].Text;
                Getjob();
                //dtbl = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                //   if (dtbl.Rows.Count > 0)
                //   {
                //       intjobtype = Convert.ToInt32(dtbl.Rows[0].ItemArray[0].ToString());
                //       hid_jobtype.Value = intjobno.ToString();
                //       jobAgentid = Convert.ToInt32(dtbl.Rows[0]["agent"].ToString());
                //       hiddenjobagentid.Value = jobAgentid.ToString();
                //       jobPOLid = Convert.ToInt32(dtbl.Rows[0]["pol"].ToString());
                //       hiddenjobpolid.Value = jobPOLid.ToString();
                //       jobPODid = Convert.ToInt32(dtbl.Rows[0]["pod"].ToString());
                //       hiddenjobpodid.Value = jobPODid.ToString();
                //   }


            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Job_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                this.popup_Grd.Show();
                Grd_Job.PageIndex = e.NewPageIndex;
                DataTable dt = (DataTable)ViewState["job"];
                Grd_Job.DataSource = dt;
                Grd_Job.DataBind();


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Booking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.popup_Grd.Show();
                Grd_Booking.PageIndex = e.NewPageIndex;
                DataTable dt = (DataTable)ViewState["Booking"];
                Grd_Booking.DataSource = dt;
                Grd_Booking.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdMBLDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCustomer1 = (Label)e.Row.FindControl("bldate");
                string tooltip1 = lblCustomer1.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip1);
                Label lblCustomer2 = (Label)e.Row.FindControl("consignee");
                string tooltip2 = lblCustomer2.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip2);
                Label lblCustomer3 = (Label)e.Row.FindControl("freight");
                string tooltip3 = lblCustomer3.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip3);
                Label lblCustomer4 = (Label)e.Row.FindControl("portname");
                string tooltip4 = lblCustomer4.Text;
                e.Row.Cells[4].Attributes.Add("title", tooltip4);



                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdMBLDetails, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdMBLDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ModalPopupExtender1.Hide();
                popup_Grd.Hide();
                //if (Grd_Booking.Rows.Count > 0)
                //{
                //    txtbookno.Text = Grd_Booking.SelectedRow.Cells[0].Text;
                //    quotcust = Grd_Booking.SelectedRow.Cells[2].Text;
                //    dtbldetails = blobj.GetBookingDtls(txtbookno.Text, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                //    if (dtbldetails.Rows.Count > 0)
                //    {
                //        string customertype = dtbldetails.Rows[0]["customertype"].ToString();
                //        if (customertype == "C")
                //        {
                //            txtconsignee.Text = dtbldetails.Rows[0].ItemArray[0].ToString();
                //            txtcaddress.Text = txtconsignee.Text + "\n" + dtbldetails.Rows[0].ItemArray[1].ToString();
                //        }
                //        else
                //        {
                //            txtconsignee.Text = "";
                //            txtcaddress.Text = "";
                //        }
                //        intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                //        intpor = Convert.ToInt32(dtbldetails.Rows[0]["porid"].ToString());
                //        Hiddenrecipt.Value = intpor.ToString();
                //        intpol = Convert.ToInt32(dtbldetails.Rows[0]["polid"].ToString());
                //        Hiddenpol.Value = intpol.ToString();
                //        intpod = Convert.ToInt32(dtbldetails.Rows[0]["podid"].ToString());
                //        hiddencharge.Value = intpod.ToString();
                //        intfd = Convert.ToInt32(dtbldetails.Rows[0]["fdid"].ToString());
                //        Hiddentxtfinaldes.Value = intfd.ToString();
                //        salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                //        if (salesPID != 0)
                //        {
                //            Hiddensalespid.Value = salesPID.ToString();
                //        }
                //        else
                //        {
                //            Hiddensalespid.Value = "0";
                //        }

                //        //Hiddensalespid.Value = salesPID.ToString();
                //        txtreceipt.Text = dtbldetails.Rows[0].ItemArray[2].ToString();
                //        txtpodis.Text = dtbldetails.Rows[0].ItemArray[4].ToString();
                //        txtpol.Text = dtbldetails.Rows[0].ItemArray[3].ToString();
                //        txtfinaldes.Text = dtbldetails.Rows[0].ItemArray[5].ToString();
                //        strCLocation = dtbldetails.Rows[0].ItemArray[7].ToString();
                //        txtdescn.Text = dtbldetails.Rows[0].ItemArray[8].ToString();
                //    }
                //}
                //txt_blno.Focus();

                int intindex;
                if (grdMBLDetails.Rows.Count > 0)
                {
                    intindex = grdMBLDetails.SelectedRow.RowIndex;
                    strSBL = grdMBLDetails.Rows[intindex].Cells[0].Text;
                    FBLn = grdMBLDetails.Rows[intindex].Cells[0].Text;
                    FBooking = blobj.GetBookinkNo(FBLn, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    lblFwdBL.Text = "Forwarder BL # :" + strSBL;

                    hidstrSBL.Value = strSBL.ToString();
                    FBooking = blobj.GetBookinkNo(FBLn, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                    txtbookno.Text = FBooking;
                    dtbldetails = blobj.GetBookingDtls(FBooking, strtrantype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (dtbldetails.Rows.Count > 0)
                    {
                        intcustomerid = Convert.ToInt32(dtbldetails.Rows[0]["customerid"].ToString());
                        salesPID = Convert.ToInt32(dtbldetails.Rows[0]["salesid"].ToString());
                        chkNomination.Checked = true;
                    }
                    grdMBLDetails.Visible = false;
                    txt_blno.Focus();
                    fn_Getforwarderdetailsforsplit(FBLn);
                }
                grdMBLDetails.Visible = false;
                Grd_Job.Visible = false;
                lnkfrght.Visible = false;

                /*   Dim intindex As Integer

          If grdMBLDetails.Rows.Count > 0 Then
              intindex = Me.grdMBLDetails.CurrentRow.Index
              strSBL = Me.grdMBLDetails.Rows(intindex).Cells(0).Value()
              FBLn = Me.grdMBLDetails.Rows(intindex).Cells(0).Value()
              FBooking = blobj.GetBookinkNo(FBLn, Login.branchid, Login.divisionid)

              'KUMAR
              lblFwdBL.Text = "Forwarder BL # :" & strSBL
              FBooking = blobj.GetBookinkNo(FBLn, Login.branchid, Login.divisionid)

              'KUMAR
              txtbooking.Text = FBooking

              dtbldetails = blobj.GetBookingDtls(FBooking, strtrantype, Login.branchid, Login.divisionid)
              If dtbldetails.Rows.Count > 0 Then
                  intcustomerid = dtbldetails.Rows(0).Item("customerid").ToString
                  salesPID = dtbldetails.Rows(0).Item("salesid").ToString
                  chkNomination.Checked = True
              End If
              grdblcollapse()
              grdMBLDetails.Visible = False
              txtbl.Focus()
              'If gblformtype = "SPLIT" Then
              '    chkNomination.Enabled = False
              'Else
              '    chkNomination.Enabled = True
              'End If
          End If
          grdMBLDetails.Visible = False


                  */
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void lnkfrght_Click(object sender, EventArgs e)
        {
            try
            {

                Session["blnofi"] = txt_blno.Text;
                Session["StrTranType"] = strtrantype;
                if (Session["blnofi"] != null)
                {
                    //modal_view.Show();
                    //pnl_grd2.Visible = true;
                    //iframe_BLPrint.Attributes["src"] = "../ForwardExports/BL Print.aspx";
                    Response.Redirect("../ForwardExports/BL Print.aspx", false);
                    return;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_blissuseat_TextChanged(object sender, EventArgs e)
        {
            if (hiddenid_issue.Value == "0" || hiddenid_issue.Value == "")
            {
                txt_blissuseat.Text = "";
                txt_blissuseat.Focus();
                ScriptManager.RegisterStartupScript(this.Page, typeof(TextBox), "BL", "alertify.alert('Enter the Valid ISSUED AT');", true);
                //blnerr = true;
                return;
            }
            else if (hiddenid_issue.Value != "0" || hiddenid_issue.Value != "")
            {
                txtTranshipped.Text = txt_blissuseat.Text;
                hiddenidtrans.Value = hiddenid_issue.Value;
                txtTranshipped_TextChanged(sender, e);

            }
            else
            {
                txt_issuedon.Focus();
            }
            UserRights();
        }

        protected void txtreceipt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenrecipt.Value != "0")
                {
                    DataTable dt;
                    //DataAccess.Masters.MasterPort obj_MasterPort = new //DataAccess.Masters.MasterPort();

                    dt = obj_MasterPort.SelPortName4typepadimg(txtreceipt.Text.ToUpper(), Session["StrTranType"].ToString());

                    porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    txtpol.Focus();
                }
                else
                {
                    txtreceipt.Text = "";
                    txtreceipt.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid PLACE OF RECEIPT');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtpol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenpol.Value != "0")
                {
                    DataTable dt;
                    //DataAccess.Masters.MasterPort obj_MasterPort = new //DataAccess.Masters.MasterPort();

                    dt = obj_MasterPort.SelPortName4typepadimg(txtpol.Text.ToUpper(), Session["StrTranType"].ToString());

                    flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    txtpodis.Focus();
                }
                else
                {
                    txtpol.Text = "";
                    txtpol.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid PORT OF LOADING');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtpodis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hiddencharge.Value != "0")
                {
                    DataTable dt;
                    //DataAccess.Masters.MasterPort obj_MasterPort = new //DataAccess.Masters.MasterPort();

                    dt = obj_MasterPort.SelPortName4typepadimg(txtpodis.Text.ToUpper(), Session["StrTranType"].ToString());

                    podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    txtfinaldes.Focus();
                }
                else
                {
                    txtpodis.Text = "";
                    txtpodis.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid PORT OF DISCHARGE');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtfinaldes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddentxtfinaldes.Value != "0")
                {
                    DataTable dt;
                    //DataAccess.Masters.MasterPort obj_MasterPort = new //DataAccess.Masters.MasterPort();

                    dt = obj_MasterPort.SelPortName4typepadimg(txtfinaldes.Text.ToUpper(), Session["StrTranType"].ToString());
                    fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                    txtmarksnumbers.Focus();
                }
                else
                {
                    txtfinaldes.Text = "";
                    txtfinaldes.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid Place of Delivery');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Btnamendbl_Click(object sender, EventArgs e)
        {
            DataTable dtuser;
            if (Session["StrTranType"].ToString() == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(94, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txtjobno.Text != "")
                    {
                        iframecost.Attributes["src"] = "../ForwardExports/AmendBL.aspx?jobno=" + txtjobno.Text;
                        pop_up.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('BL # cannot be Empty!');", true);
                        txt_blno.Focus();
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void txtcargo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hiddencargo.Value != "0")
                {
                    txtshipper.Focus();
                }
                else
                {
                    txtcargo.Text = "";
                    txtcargo.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid COMMODITY');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtMVessel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Hiddenvessel.Value != "0")
                {
                    txtMVoy.Focus();
                }
                else
                {
                    txtMVessel.Text = "";
                    txtMVessel.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid MOTHER VESSEL');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_Customsdtl_Click(object sender, EventArgs e)
        {
            if (txt_blno.Text != "")
            {
                string trantype_process = Session["StrTranType"].ToString();
                DataTable dtuser = new DataTable();


                dtuser = obj_UP.GetFormwiseuserRights(1964, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    Response.Redirect("../Sales/Customerdetailsnew.aspx?back=yes" + "&BL=" + txt_blno.Text + "&1typ=" + Session["type"]);
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            else
            {
                 
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Bl # cannot be empty!!');", true);
                return;
            }

        }

        protected void txtTranshipped_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hiddenidtrans.Value != "0")
                {
                    txtUNOcode.Focus();
                }
                else
                {
                    txtTranshipped.Text = "";
                    txtTranshipped.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Enter Valid TRANSHIPPED AT');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Proinvoic_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1020, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_blno.Text != "")
                    {
                        string fiblno = txt_blno.Text;
                        string appfibl = "1";
                        string lblid = lbl_header.Text;
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?appfibl=" + appfibl + "&fiblno=" + fiblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the BL Number";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "FIBL", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void procrednote_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(1021, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //    string app2 = "Proforma Purchase Invoice";
                    //    Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);

                    //}

                    if (txt_blno.Text != "")
                    {
                        string fiblno = txt_blno.Text;
                        string appfibl = "2";
                        string lblid = lbl_header.Text;
                        //Response.Redirect("../Accounts/ProfomaInvoice.aspx?app1=" + app2);
                        Response.Redirect("../Accounts/ProformaLV.aspx?appfibl=" + appfibl + "&fiblno=" + fiblno + "&lblid=" + lblid);
                    }
                    else
                    {
                        string message = "Enter the BL Number";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);
                    }
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void Btn_reuse_Click(object sender, EventArgs e)
        {
            reusedetails();
        }

        //GST

        public void getsupplytovalues()
        {

            DataTable dtsupply = new DataTable();
            DataTable obj_dt = new DataTable();
            if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
            {

                if (Session["StrTranType"] != null)
                {

                    obj_dt = blobj.ShowBLDetails(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        str_BL = obj_dt.Rows[0]["splitbl"].ToString();

                    }
                    str_booking = blobj.GetBookinkNo(txt_blno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (str_booking == "0" && Session["StrTranType"].ToString() == "FI")
                    {
                        str_booking = blobj.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    }

                    if (str_booking != "0")
                    {
                        dtsupply = FEblobj.GetBookingDt(str_booking, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtsupply.Rows.Count > 0)
                        {
                            hid_SupplyTo.Value = dtsupply.Rows[0]["customerid"].ToString();

                        }
                    }
                    else
                    {
                        hid_SupplyTo.Value = hid_intcustomerid.Value;
                    }


                }

            }
            else
            {
                hid_SupplyTo.Value = hid_intcustomerid.Value;
            }


            /*if (hid_SupplyTo.Value != "0")
            {
                DataTable dt_list = new DataTable();
                int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                dt_list = customerobj.GetIndianCustomergst(int_custid);
                if (dt_list.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                        {

                            blnerrUinno = true;
                            // ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                        }
                        else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                        {

                            blnerrGstin = true;
                            //  ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                        }

                        blnerrUinnoGstin = true;
                        // ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                    }
                    else
                    {
                        blnerrUinnoGstin = true;
                        //txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                    }
                }
                else
                {
                    blnerr = true;
                    //ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                    //return;
                }


            }*/
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

            if (lbl_header.Text == "Direct BL")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 122, "BL", txt_blno.Text, txt_blno.Text, Session["StrTranType"].ToString());
            }
            else if (lbl_header.Text == "Split BL")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 123, "BL", txt_blno.Text, txt_blno.Text, Session["StrTranType"].ToString());

            }
            else if (lbl_header.Text == "Forwarder BL")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 124, "SplitBL", txt_blno.Text, txt_blno.Text, Session["StrTranType"].ToString());
            }

            if (txt_blno.Text != "")
            {
                JobInput.Text = txt_blno.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }



        protected void AutoInvoice()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                if (txtbookno.Text != "")
                {
                    obj_dt = FEblobj.GetBookingDt(txtbookno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_quto.Value = obj_dt.Rows[0]["quotno"].ToString();
                    }

                    dtinv = FEblobj.GetQuotchgs4InvFI(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txtbookno.Text);

                }
                if (dtinv.Rows.Count > 0)
                {
                    try
                    {
                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //    "Profoma Invoice", "", 0);


                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FI", Convert.ToInt32(txtjobno.Text),
                        //   Convert.ToInt32(Hiddenconsignee.Value), txt_blno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //   "Profoma Invoice", "", 0, Convert.ToInt32(hid_SupplyTo.Value)); hide by yuvaraj 1/02-2023

                        Refno = ProINVobj.InsProLVhead(Convert.ToDateTime(Logobj.GetDate()), "OI", Convert.ToInt32(txtjobno.Text),
                               Convert.ToInt32(hid_intcustomerid.Value), txt_blno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                              "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), 1, "",
                              0, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToDateTime(Logobj.GetDate()));

                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FI", Convert.ToInt32(txtjobno.Text),
                        //   Convert.ToInt32(hid_SupplyTo.Value), txt_blno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //   "Profoma Invoice", "", 0, Convert.ToInt32(hid_SupplyTo.Value));

                        invgen = true;
                        for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                        {
                            base1 = dtinv.Rows[i]["base"].ToString();
                            rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());

                            exrate = Invobj.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                            amount = CheckBase(base1, rate, exrate);
                            //ProINVobj.InsertProInvoiceDetails(Refno, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                            //    exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                            //    , "C", "FI", "Profoma Invoice", "Y", unit);

                            ProINVobj.InsertProLVDetails(Refno, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                               exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                               , "C", "OI", 1, "Y", unit);
                        }
                    }
                    catch (Exception ex)
                    {
                        //   Utility.SendMail(Session["usermailid"].ToString(), "", "bl pRO.iNV", ex.ToString(), "", Session["usermailpwd"].ToString(), "", "");
                    }
                }
                else
                {
                    invgen = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void Autocnops()
        {
            try
            {
                //dtinv = obj_da_BL.GetQuotchgs4Inv(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text);

                Double amt = 0.00;
                if (Session["StrTranType"] != null)
                {

                    //dtinv = obj_da_BL.GetBuyingchgs4debitcredit(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text, Session["StrTranType"].ToString());
                    // dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew1(txt_blno.Text, Convert.ToInt32(Session["Loginbranchid"]));


                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew(txt_blno.Text, Convert.ToInt32(Session["Loginbranchid"]));
                    }
                    else
                    {
                        dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew1(txt_blno.Text, Convert.ToInt32(Session["Loginbranchid"]));
                    }
                }

                if (dtinv.Rows.Count > 0)
                {
                    try
                    {

                        //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                        //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                        //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                        //    "Profoma Invoice", "", 0);

                        dtbl = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        if (dtbl.Rows.Count > 0)
                        {
                            Hiddenconsignee1.Value = dtbl.Rows[0]["mlo"].ToString();
                            hid_SupplyTo1.Value = dtbl.Rows[0]["mlo"].ToString();
                        }


                        Refno1 = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(Logobj.GetDate()), "FI", Convert.ToInt32(txtjobno.Text),
                           Convert.ToInt32(Hiddenconsignee1.Value), txt_blno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                           "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                           "Profoma Payment Advise", "", 0, Convert.ToInt32(hid_SupplyTo1.Value), Convert.ToDateTime(Logobj.GetDate()));

                        invgen1 = true;
                        for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                        {
                            base1 = dtinv.Rows[i]["base"].ToString();
                            rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                            exrate = Invobj.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                            amount = CheckBase(base1, rate, exrate);
                            ProINVobj.InsertProInvoiceDetails(Refno1, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                                exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                                , "C", "FI", "Profoma Payment Advise", "Y", unit);

                        }
                    }
                    catch (Exception ex)
                    {
                        //   Utility.SendMail(Session["usermailid"].ToString(), "", "bl pRO.iNV", ex.ToString(), "", Session["usermailpwd"].ToString(), "", "");
                    }
                }
                else
                {
                    invgen1 = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        // Add by yuvaraj negative value 

        protected void Autocnops4negativeQuotation()
        {
            try
            {
                //dtinv = obj_da_BL.GetQuotchgs4Inv(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text);
                if (txtbookno.Text != "")
                {
                    Double amt = 0.00;
                    if (Session["StrTranType"] != null)
                    {

                        //dtinv = obj_da_BL.GetBuyingchgs4debitcredit(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_booking.Text, Session["StrTranType"].ToString());
                        // dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew1(txt_blno.Text, Convert.ToInt32(Session["Loginbranchid"]));


                        //if (Session["StrTranType"].ToString() == "FE")
                        //{
                        //    dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew(txt_blno.Text, Convert.ToInt32(Session["Loginbranchid"]));
                        //}
                        //else
                        //{
                        //    dtinv = obj_da_Invoice.GetChargeFrombuyinginvoicenew1(txt_blno.Text, Convert.ToInt32(Session["Loginbranchid"]));
                        //}
                        string trantype = Session["StrTranType"].ToString();
                        dtinv = obj_da_Invoice.InvChargeFrombuyinginvoiceAllTrantype(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txtbookno.Text, trantype);

                    }

                    if (dtinv.Rows.Count > 0)
                    {
                        try
                        {

                            //Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Logobj.GetDate()), "FE", Convert.ToInt32(txt_job.Text),
                            //    Convert.ToInt32(hid_intcustomerid.Value), txt_bl.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                            //    "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                            //    "Profoma Invoice", "", 0);

                            //dtbl = fijobobj.ShowJobDetails(Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            //if (dtbl.Rows.Count > 0)
                            //{
                            //    Hiddenconsignee1.Value = dtbl.Rows[0]["mlo"].ToString();
                            //    hid_SupplyTo1.Value = dtbl.Rows[0]["mlo"].ToString();
                            //}

                            Refno1 = ProINVobj.InsProLVhead(Convert.ToDateTime(Logobj.GetDate()), "OE", Convert.ToInt32(txtjobno.Text),
                                   Convert.ToInt32(Hiddenconsignee.Value), txt_blno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                  "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()), 2, "",
                                  0, Convert.ToInt32(hid_SupplyTo1.Value), Convert.ToDateTime(Logobj.GetDate()));


                            invgen1 = true;
                            for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                            {
                                base1 = dtinv.Rows[i]["base"].ToString();
                                rate = Math.Abs(Convert.ToDouble(dtinv.Rows[i]["rate"].ToString()));
                                exrate = Invobj.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                                amount = CheckBase(base1, rate, exrate);
                                ProINVobj.InsertProLVDetails(Refno1, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                                    exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                                    , "C", "FE", 2, "Y", unit);


                                //Refno1 = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(Logobj.GetDate()), "FI", Convert.ToInt32(txtjobno.Text),
                                //   Convert.ToInt32(Hiddenconsignee.Value), txt_blno.Text.ToUpper(), "", Convert.ToInt32(Session["LoginBranchid"].ToString()),
                                //   "Cash/Cheque", Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString()),
                                //   "Profoma Payment Advise", "", 0, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToDateTime(Logobj.GetDate()));

                                //invgen1 = true;
                                //for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                                //{
                                //    base1 = dtinv.Rows[i]["base"].ToString();
                                //    rate = Math.Abs(Convert.ToDouble(dtinv.Rows[i]["rate"].ToString()));
                                //    exrate = Invobj.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                                //    amount = CheckBase(base1, rate, exrate);
                                //    ProINVobj.InsertProInvoiceDetails(Refno1, Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), rate,
                                //        exrate, base1, amount, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["Vouyear"].ToString())
                                //        , "C", "FI", "Profoma Payment Advise", "Y", unit);

                            }
                        }
                        catch (Exception ex)
                        {
                            //   Utility.SendMail(Session["usermailid"].ToString(), "", "bl pRO.iNV", ex.ToString(), "", Session["usermailpwd"].ToString(), "", "");
                        }
                    }
                    else
                    {
                        invgen1 = false;
                    }
                }
                else
                {
                    invgen1 = false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        // end 




        protected void autodebitOS()
        {
            int vouyear;
            DataTable obj_dt = new DataTable();
            if (hid_quto.Value == "")
            {
                hid_quto.Value = "0";

            }
            if (txtbookno.Text != "")
            {
                obj_dt = FEblobj.GetBookingDt(txtbookno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    hid_quto.Value = obj_dt.Rows[0]["quotno"].ToString();

                }
            }
            Double amt = 0.00;
            if (txtbookno.Text != "")
            {
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FI")
                    {
                        dtinv = FEblobj.GetQuotchgs4debitcreditFI(Convert.ToInt32(hid_quto.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txtbookno.Text);
                    }

                }
            }

            //DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new //DataAccess.Accounts.OSDNCN();
            //DataAccess.LogDetails da_obj_logobj = new //DataAccess.LogDetails();
            DateTime dtdate = da_obj_logobj.GetDate();
            DateTime txtVendorRefnodate = da_obj_logobj.GetDate();

            //  txtVendorRefnodate = Convert.ToDateTime(Utility.fn_ConvertDate(txtVendorRefnodate));
            double amt1 = 0, actual = 0.00;
            double fcamt1 = 0.00;
            if (dtinv.Rows.Count > 0)
            {
                if (da_obj_logobj.GetDate().Month < 4)
                {
                    vouyear = da_obj_logobj.GetDate().Year - 1;
                }
                else
                {
                    vouyear = da_obj_logobj.GetDate().Year;
                }
                hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                hid_SupplyTo.Value = hid_intagent.Value;
                DataTable dtd = new DataTable();
                //DataAccess.AirImportExports.AIEJobInfo objaej = new //DataAccess.AirImportExports.AIEJobInfo();
                dtd = objaej.GetAIagentid(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(txtjobno.Text));

                DebitOS = true;
                refnodebitOs = da_obj_OSDNCN.InsproOSvouchershead(Convert.ToDateTime(dtdate), "OI", Convert.ToDouble(amount),
                                    Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                                    Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 5, "", "");


                for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                {
                    if (dtinv.Rows[i]["agentid"].ToString() != "")
                    {
                        hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                        hid_SupplyTo.Value = hid_intagent.Value;
                    }
                    else
                    {
                        if (dtd.Rows[0]["agent"].ToString() != "")
                        {
                            hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                            hid_SupplyTo.Value = hid_intagent.Value;
                        }
                    }
                    if (dtd.Rows[0]["mawblno"].ToString() != "")
                    {
                        HIDMAWBLNO.Value = txt_blno.Text.ToUpper();
                    }



                    base1 = dtinv.Rows[i]["base"].ToString();
                    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                    exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "C", Convert.ToInt32(Session["LoginDivisionId"]));
                    famount = CheckBase(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                    string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                    actual = actual + Convert.ToDouble(osamount);
                    fd = Convert.ToInt32(hid_fd.Value);
                    unit = Convert.ToInt32(hid_douvolume.Value);

                    DAdvise.InsOSVdetails(Convert.ToInt32(txtjobno.Text), "OI", HIDMAWBLNO.Value.ToUpper(),
                      Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                       base1, Convert.ToDouble(osamount), 5, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                       "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", refnodebitOs, Convert.ToInt32(vouyear));
                    //if (unit == 0)
                    //{
                    //    hidunit.Value = "0";
                    //}

                    //DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txt_job.Text), "OE", HIDMAWBLNO.Value.ToUpper(),
                    //    Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                    //    base1, Convert.ToDouble(osamount), 6, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                    //    "Y", Convert.ToInt32(hid_intagent.Value));

                }

                /*  for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                  {
                      if (dtinv.Rows[i]["agentid"].ToString() != "")
                      {
                          hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                          hid_SupplyTo.Value = hid_intagent.Value;
                      }
                      else
                      {
                          if (dtd.Rows[0]["agent"].ToString() != "")
                          {
                              hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                              hid_SupplyTo.Value = hid_intagent.Value;
                          }
                      }
                      if (dtd.Rows[0]["mawblno"].ToString() != "")
                      {
                          //  HIDMAWBLNO.Value = dtd.Rows[0]["mawblno"].ToString();
                          HIDMAWBLNO.Value = txt_blno.Text.ToUpper();
                      }

                      base1 = dtinv.Rows[i]["base"].ToString();
                      rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                      exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "R", Convert.ToInt32(Session["LoginDivisionId"]));
                      famount = CheckBaseosdn(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                      string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                      actual = actual + Convert.ToDouble(osamount);
                      //DAdvise.InsDCAdviseForGst(Convert.ToInt32(txt_jobno.Text), "AE", HIDMAWBLNO.Value.ToUpper(), Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate), base1, Convert.ToDouble(osamount), "DebitAdvise", Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(hid_intagent.Value));

                   //   DAdvise.InsDCAdviseForGst(Convert.ToInt32(txtjobno.Text), Session["StrTranType"].ToString(), HIDMAWBLNO.Value.ToUpper(), Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate), base1, Convert.ToDouble(osamount), "DebitAdvise", Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(hid_intagent.Value));
                      DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txtjobno.Text), "OI", HIDMAWBLNO.Value.ToUpper(),
                        Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                        base1, Convert.ToDouble(osamount), 5, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                        "Y", Convert.ToInt32(hid_intagent.Value));

                      //int_djobno = da_obj_OSDNCN.GetOSDCNProJobCount(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                      //int_cjobno = da_obj_OSDNCN.GetOSDCNProJobCount(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                  }
                  //DataAccess.AirImportExports.AIEBLDetails objae = new //DataAccess.AirImportExports.AIEBLDetails();
                  //refnodebitOs = da_obj_OSDNCN.InsertOSDNProForGst(Convert.ToDateTime(dtdate), "AE", Convert.ToDouble(actual), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual, Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate);

                  //refnodebitOs = da_obj_OSDNCN.InsertOSDNProForGst(dtdate, Session["StrTranType"].ToString(), Convert.ToDouble(actual), Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual, Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate);

                  refnodebitOs = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), "OI", Convert.ToDouble(amount),
                                                    Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 5);*/


                DataTable dttn = new DataTable();
                dttn = da_obj_OSDNCN.Getupdacdebitfcamt(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txtjobno.Text));
                if (dttn.Rows.Count > 0)
                {
                    for (int i = 0; i <= dttn.Rows.Count - 1; i++)
                    {
                        if (dttn.Rows[i]["fcamt"].ToString() != "")
                        {
                            fcamt1 = fcamt1 + Convert.ToDouble(dttn.Rows[i]["fcamt"]);
                        }
                    }

                }
                // da_obj_OSDNCN.Getupdacosdnproupd(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txtjobno.Text), fcamt1);


                da_obj_OSDNCN.Getupdacosdnproupdnew(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]),
                    Convert.ToInt32(vouyear), Convert.ToInt32(txtjobno.Text), fcamt1, "DebitAdvise");
            }
            else
            {
                DebitOS = false;
            }

        }


        public double CheckBaseosdn(string strbase, double rate, double exrate)
        {

            strTranType = Session["StrTranType"].ToString();
            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtjobno.Text), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            if (DtBLNO.Rows.Count > 0)
            {
                mblno = DtBLNO.Rows[0][0].ToString();
            }
            if (strbase == "BL" || strbase == "HWBL" || strbase == "DOC")
            {
                if (txt_blno.Text == mblno)
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
                else
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }
                douvolume = 1;
                amount = rate * exrate;
                //---------------------------------------------

            }
            else if (strbase == "CBM" || strbase == "MT" || strbase == "W/M")
            {
                if (strbase == "CBM")
                {
                    if (strTranType == "FE")
                    {
                        if (txt_blno.Text == mblno)
                        {
                            volume = obj_da_Invoice.GetSumofVolume(txtjobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            douvolume = volume;
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            amount = rate * exrate * volume;
                        }
                        else
                        {
                            volume = obj_da_Invoice.GetVolume(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                            douvolume = volume;
                            amount = rate * exrate * volume;
                        }
                    }
                    else
                    {
                        if (txt_blno.Text == mblno)
                        {
                            volume = obj_da_Invoice.GetSumofVolume(txtjobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            if (volume < 1)
                            {
                                amount = rate * exrate * 1;
                                douvolume = 1;
                            }
                            else
                            {
                                amount = rate * exrate * volume;
                                douvolume = volume;
                            }
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        }
                        else
                        {
                            volume = obj_da_Invoice.GetVolume(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            if (volume < 1)
                            {
                                amount = rate * exrate * 1;
                                douvolume = 1;
                            }
                            else
                            {
                                amount = rate * exrate * volume;
                                douvolume = volume;
                            }
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                        }
                    }
                }
                else if (strbase == "W/M")// add yuvaraj by 25012023
                {
                    if (strTranType == "FE")
                    {
                        if (txt_blno.Text == mblno)
                        {
                            volume = obj_da_Invoice.GetSumofVolume(txtjobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            douvolume = volume;
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            amount = rate * exrate * volume;
                        }
                        else
                        {
                            volume = obj_da_Invoice.GetVolume(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                            douvolume = volume;
                            amount = rate * exrate * volume;
                        }
                    }
                    else
                    {
                        if (txt_blno.Text == mblno)
                        {
                            volume = obj_da_Invoice.GetSumofVolume(txtjobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            if (volume < 1)
                            {
                                amount = rate * exrate * 1;
                                douvolume = 1;
                            }
                            else
                            {
                                amount = rate * exrate * volume;
                                douvolume = volume;
                            }
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        }
                        else
                        {
                            volume = obj_da_Invoice.GetVolume(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            if (volume < 1)
                            {
                                amount = rate * exrate * 1;
                                douvolume = 1;
                            }
                            else
                            {
                                amount = rate * exrate * volume;
                                douvolume = volume;
                            }
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                        }
                    }
                }
                else
                {
                    if (strbase == "MT")
                    {
                        if (strTranType == "FE" || strTranType == "FI")
                        {
                            if (txt_blno.Text == mblno)
                            {
                                wt = obj_da_Invoice.GetSumofWeight(txtjobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                amount = rate * exrate * (wt / 1000);
                                douvolume = wt;
                                fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            }
                            else
                            {
                                wt = obj_da_Invoice.GetWeight(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                amount = rate * exrate * (wt / 1000);
                                douvolume = wt;
                                fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                            }
                        }

                    }
                }

            }
            //---------------------------------------------------------------------------------------------------------
            else if (strbase == "Kgs" || strbase == "KGS")
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (txt_blno.Text == mblno)
                    {
                        wt = obj_da_Invoice.GetSumofChargeWght(Convert.ToInt32(txtjobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                    }
                    else
                    {
                        wt = obj_da_Invoice.GetChargeWeight(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                    }

                }
                else
                {
                    wt = obj_da_Invoice.GetGrossWeight(txt_blno.Text, Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * wt;
                    douvolume = wt;
                }
            }

            else if (strbase == "PKG")
            {
                ////DataAccess.Accounts.Invoice objinv = new //DataAccess.Accounts.Invoice();
                //DataTable dtn = new DataTable();
                //dtn = objinv.CheckIPDCWBLShipperinvoiceget(cmbbl.SelectedItem.Text, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                //int shiperinv = dtn.Rows.Count;
                amount = rate * exrate * Convert.ToInt32(Session["noofpks"]);
                douvolume = Convert.ToInt32(Session["noofpks"]);
            }

            //---------------------------------------------------------------------------------------------------------

            else
            {
                DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtjobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                if (DtBLNO.Rows.Count > 0)
                {
                    mblno = DtBLNO.Rows[0][0].ToString();
                }
                if (txt_blno.Text != mblno)
                {
                    sizecount1 = obj_da_Invoice.GetBaseCount(txt_blno.Text, strbase, strTranType, "BL", Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * sizecount1;
                    douvolume = sizecount1;
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }

                else
                {
                    sizecount1 = obj_da_Invoice.GetBaseCount(txtjobno.Text, strbase, strTranType, "MBL", Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * sizecount1;
                    douvolume = sizecount1;
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(txt_blno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
            }

            hid_douvolume.Value = douvolume.ToString();
            hid_fd.Value = fd.ToString();
            return amount;
        }


        protected void autocreditOS()
        {
            int vouyear;
            DataTable obj_dt = new DataTable();
            if (hid_buyingno.Value == "")
            {
                hid_buyingno.Value = "0";

            }

            Double amt = 0.00;
            if (Session["StrTranType"] != null)
            {


                if (txtbookno.Text != "")
                {

                    obj_dt = FEblobj.GetBookingDt(txtbookno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    if (obj_dt.Rows.Count > 0)
                    {
                        hid_buyingno.Value = obj_dt.Rows[0]["buyingno"].ToString();

                    }

                    //dtinv = FEblobj.GetBuyingchgs4debitcredit(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txtbookno.Text, Session["StrTranType"].ToString());
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        dtinv = FEblobj.GetBuyingchgs4debitcredit(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txtbookno.Text, Session["StrTranType"].ToString());
                    }
                    else
                    {
                        dtinv = FEblobj.GetBuyingchgs4debitcredit1(Convert.ToInt32(hid_buyingno.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), txtbookno.Text, Session["StrTranType"].ToString());
                    }

                }
            }

            //DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new //DataAccess.Accounts.OSDNCN();
            //DataAccess.LogDetails da_obj_logobj = new //DataAccess.LogDetails();
            DateTime dtdate = da_obj_logobj.GetDate();// da_obj_logobj.GetDate();
            DateTime txtVendorRefnodate = da_obj_logobj.GetDate();
            double amt1 = 0, actual = 0.00;
            double fcamt1 = 0.00;
            if (dtinv.Rows.Count > 0)
            {
                if (da_obj_logobj.GetDate().Month < 4)
                {
                    vouyear = da_obj_logobj.GetDate().Year - 1;
                }
                else
                {
                    vouyear = da_obj_logobj.GetDate().Year;
                }
                hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                hid_SupplyTo.Value = hid_intagent.Value;
                DataTable dtd = new DataTable();
                //DataAccess.AirImportExports.AIEJobInfo objaej = new //DataAccess.AirImportExports.AIEJobInfo();
                dtd = objaej.GetAIagentid(Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(txtjobno.Text));

                CreditOS = true;

                refnodebitOs = da_obj_OSDNCN.InsproOSvouchershead(Convert.ToDateTime(dtdate), "OI", Convert.ToDouble(amount),
                                     Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                                     Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                                     Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 6, "", "");


                for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                {
                    if (dtinv.Rows[i]["agentid"].ToString() != "")
                    {
                        hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                        hid_SupplyTo.Value = hid_intagent.Value;
                    }
                    else
                    {
                        if (dtd.Rows[0]["agent"].ToString() != "")
                        {
                            hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                            hid_SupplyTo.Value = hid_intagent.Value;
                        }
                    }
                    if (dtd.Rows[0]["mawblno"].ToString() != "")
                    {
                        HIDMAWBLNO.Value = txt_blno.Text.ToUpper();
                    }



                    base1 = dtinv.Rows[i]["base"].ToString();
                    rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                    exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "C", Convert.ToInt32(Session["LoginDivisionId"]));
                    famount = CheckBase(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                    string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                    actual = actual + Convert.ToDouble(osamount);
                    fd = Convert.ToInt32(hid_fd.Value);
                    unit = Convert.ToInt32(hid_douvolume.Value);
                    DAdvise.InsOSVdetails(Convert.ToInt32(txtjobno.Text), "OI", HIDMAWBLNO.Value.ToUpper(),
                      Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                       base1, Convert.ToDouble(osamount), 6, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                       "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", refnodebitOs, Convert.ToInt32(vouyear));

                    //if (unit == 0)
                    //{
                    //    hidunit.Value = "0";
                    //}


                }


                /* for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                 {
                     if (dtinv.Rows[i]["agentid"].ToString() != "")
                     {
                         hid_intagent.Value = dtinv.Rows[0]["agentid"].ToString();
                         hid_SupplyTo.Value = hid_intagent.Value;
                     }
                     else
                     {
                         if (dtd.Rows[0]["agent"].ToString() != "")
                         {
                             hid_intagent.Value = dtd.Rows[0]["agent"].ToString();
                             hid_SupplyTo.Value = hid_intagent.Value;
                         }
                     }
                     if (dtd.Rows[0]["mawblno"].ToString() != "")
                     {
                         HIDMAWBLNO.Value = txt_blno.Text.ToUpper();
                     }

                     ////SMS AS Per Manoj instructions , bl charges and surrender charges base directly pass
                     //if (dtinv.Rows[i]["chargeid"].ToString() == "1" || dtinv.Rows[i]["chargeid"].ToString() == "92")
                     //{
                     //    base1 = "BL";
                     //}
                     //else
                     //{
                     //    base1 = dtinv.Rows[i]["base"].ToString();
                     //}
                     //rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                     ////if (dtinv.Rows[i]["curr"].ToString() == "INR")
                     ////{
                     ////    exrate = 1.0;
                     ////}
                     ////else
                     ////{
                     ////    string output = Convert.ToDouble(txtOutPut.Text).ToString("#0.00");
                     ////    exraTEBUY = Convert.ToDouble((output));
                     ////}
                     ////exrate = obj_da_Invoice.GetExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(Logobj.GetDate()), "R");
                     ////   exrate = Convert.ToDouble(txtOutPut.Text);

                     //if (dtinv.Rows[i]["curr"].ToString().ToUpper() == "INR")
                     //{
                     //    exrate = 1;
                     //}
                     //else
                     //{
                     //    exrate = Convert.ToDouble(txtOutPut.Text);
                     //}

                     base1 = dtinv.Rows[i]["base"].ToString();
                     rate = Convert.ToDouble(dtinv.Rows[i]["rate"].ToString());
                     exrate = obj_da_Invoice.GetOSExRate(dtinv.Rows[i]["curr"].ToString(), Convert.ToDateTime(da_obj_logobj.GetDate()), "C", Convert.ToInt32(Session["LoginDivisionId"]));
                     famount = CheckBase(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                     //famount = CheckBaseos(base1, Convert.ToDouble(rate), Convert.ToDouble(exrate)).ToString();
                     string osamount = Convert.ToDecimal(famount).ToString("#,0.00");
                     actual = actual + Convert.ToDouble(osamount);
                     //DAdvise.InsDCAdviseForGst(Convert.ToInt32(txt_jobno.Text), "AE", HIDMAWBLNO.Value.ToUpper(), Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate), base1, Convert.ToDouble(osamount), "DebitAdvise", Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(hid_intagent.Value));

                     //DAdvise.InsDCAdviseForGst(Convert.ToInt32(txtjobno.Text), Session["StrTranType"].ToString(), HIDMAWBLNO.Value.ToUpper(), Convert.ToInt32(dtinv.Rows[i]["chargeid"]),
                     //    dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate), base1, Convert.ToDouble(osamount), "CreditAdvise", 
                     //    Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(hid_intagent.Value));
                     DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txtjobno.Text), "OI", HIDMAWBLNO.Value.ToUpper(),
                        Convert.ToInt32(dtinv.Rows[i]["chargeid"]), dtinv.Rows[i]["curr"].ToString(), Convert.ToDouble(rate), Convert.ToDouble(exrate),
                        base1, Convert.ToDouble(osamount), 6, Convert.ToInt32(Session["LoginBranchid"]), "Remark", fd, unit, Convert.ToInt32(hid_SupplyTo.Value),
                        "Y", Convert.ToInt32(hid_intagent.Value));

                     //int_djobno = da_obj_OSDNCN.GetOSDCNProJobCount(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"].ToString()));
                     //int_cjobno = da_obj_OSDNCN.GetOSDCNProJobCount(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"].ToString()));

                 }*/

                ////DataAccess.AirImportExports.AIEBLDetails objae = new //DataAccess.AirImportExports.AIEBLDetails();
                //refnodebitOs = da_obj_OSDNCN.InsertOSDNProForGst(Convert.ToDateTime(dtdate), "AE", Convert.ToDouble(actual), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual, Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate);
                //refnocreditOs = da_obj_OSDNCN.InsertOSCNProGst(Convert.ToDateTime(dtdate), Session["StrTranType"].ToString(),
                //    Convert.ToDouble(actual), Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"]),
                //    Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear),
                //    "1", Convert.ToInt32(hid_SupplyTo.Value), Convert.ToDateTime(txtVendorRefnodate));
                //  refnocreditOs = da_obj_OSDNCN.InsertOSCNProGst(dtdate, Convert.ToString(Session["StrTranType"].ToString()), Convert.ToDouble(actual), Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate);

                //refnodebitOs = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), "OI", Convert.ToDouble(amount),
                //                                  Convert.ToInt32(txtjobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value),
                //                                  Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), "1", actual,
                //                                  Convert.ToInt32(hid_SupplyTo.Value), txtVendorRefnodate, 6);

                DataTable dttn = new DataTable();
                dttn = da_obj_OSDNCN.Getupdacdebitfcamt(refnodebitOs, Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txtjobno.Text));

                //   dttn = da_obj_OSDNCN.Getupdacdebitfcamtnew(Convert.ToInt32(refnocreditOs), Session["StrTranType"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txtjobno.Text), "CreditAdvise");
                if (dttn.Rows.Count > 0)
                {
                    for (int i = 0; i <= dttn.Rows.Count - 1; i++)
                    {
                        if (dttn.Rows[i]["fcamt"].ToString() != "")
                        {
                            fcamt1 = fcamt1 + Convert.ToDouble(dttn.Rows[i]["fcamt"]);
                        }
                    }

                }
                da_obj_OSDNCN.Getupdacosdnproupdnew(refnodebitOs, Session["StrTranType"].ToString(),
                    Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(txtjobno.Text), fcamt1, "CreditAdvise");
            }
            else
            {
                CreditOS = false;
            }
        }
        protected void btn_job_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();


            dtuser = obj_UP.GetFormwiseuserRights(3, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                Response.Redirect("../FI/jobInfo.aspx?back=yes"+"&job="+txtjobno.Text);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

            }


        }
        protected void btn_blrelease_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            
                dtuser = obj_UP.GetFormwiseuserRights(1014, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                    if (txt_blno.Text != "")
                    {
                        string feblno = txt_blno.Text;
                        Response.Redirect("../ForwardExports/BL Print.aspx?BLReleaseNO=" + feblno + "&blba=yes");
                    }
                    else
                    {
                        string message = "Enter the BL Number";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }

             
        }

    }
}