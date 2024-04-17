using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net.Mail;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.IO;
using logix.Sales;
using DataAccess.HR;
using logix.CRMNew;
using System.ComponentModel;
using System.Web.Services.Description;

namespace logix.Sales
{
    public partial class Booking : System.Web.UI.Page
    {
        DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
        DataAccess.Marketing.Quotation quotobj = new DataAccess.Marketing.Quotation();
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterCargo cargoobj = new DataAccess.Masters.MasterCargo();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.BuyingRate buyingobj = new DataAccess.BuyingRate();
        DataAccess.Corporate CorpObj = new DataAccess.Corporate();
        DataAccess.ForwardingExports.ShippingBill objship = new DataAccess.ForwardingExports.ShippingBill();
        DataAccess.ForwardingExports.JobInfo fejobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.UserPermission userperobj = new DataAccess.UserPermission();
        //DataAccess.CRM.CRMBooking crmbkngobj = new DataAccess.CRM.CRMBooking();
        DataAccess.ForwardingExports.ShippingBill ShippingBillobj = new DataAccess.ForwardingExports.ShippingBill();
        DataAccess.Masters.MasterPackages packageobj = new DataAccess.Masters.MasterPackages();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort objpot = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
        DataAccess.Documents Objdoc = new DataAccess.Documents();
        DataAccess.ForwardingExports.PODetails obj_da_Podetails = new DataAccess.ForwardingExports.PODetails();

        DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();
        DataAccess.Marketing.Quotation quotation = new DataAccess.Marketing.Quotation();
        DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Marketing.Booking book = new DataAccess.Marketing.Booking();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterVessel da_obj_Vessel = new DataAccess.Masters.MasterVessel();
        DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
        DataAccess.CreditException Crexobj = new DataAccess.CreditException();
        DataAccess.Masters.MasterPackages packobj = new DataAccess.Masters.MasterPackages();
        DataAccess.ForwardingExports.StuffingConfirmation STufobj = new DataAccess.ForwardingExports.StuffingConfirmation();



        DataTable dtTable = new DataTable();
        DataTable dtBooking = new DataTable();
        DataTable dtrateid = new DataTable();
        DataTable dtBuying = new DataTable();
        DataTable dt = new DataTable();
        DataTable dtvalid = new DataTable();
        DataTable dts = new DataTable();
        DataTable dt_MenuRights = new DataTable();
        DataTable DT_bind = new DataTable();

        Boolean blnerr;
        int i, rateid;
        int index;
        string sendqry;
        string business, intShipment, strfstatus, intsales, intpor, intpol, intpod, intfd, intcustid, bfreight, bookno;
        string strbooking;
        int bid, did;
        string StrTranType = "", pdt;
        string str_Uiid = "", str_FornName;
        string str_CtrlLists, str_MsgLists, str_DataType;
        string strcust = "";
        protected void Page_Load(object sender, EventArgs e)
        
        {


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                cargoobj.GetDataBase(Ccode);
                buyingobj.GetDataBase(Ccode);
                userperobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                bookingobj.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                CorpObj.GetDataBase(Ccode);
                objship.GetDataBase(Ccode);

                fejobobj.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                userperobj.GetDataBase(Ccode);
                ShippingBillobj.GetDataBase(Ccode);
                packageobj.GetDataBase(Ccode);
                bookingobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                objpot.GetDataBase(Ccode);
                obj_MasterPort.GetDataBase(Ccode);
                Objdoc.GetDataBase(Ccode);
                obj_da_Podetails.GetDataBase(Ccode);
                cus.GetDataBase(Ccode);
                quotation.GetDataBase(Ccode);
                Cusobj.GetDataBase(Ccode);
                book.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                da_obj_Vessel.GetDataBase(Ccode);
                da_obj_Port.GetDataBase(Ccode);
                outsobj.GetDataBase(Ccode);
                Crexobj.GetDataBase(Ccode);
                packobj.GetDataBase(Ccode);
                STufobj.GetDataBase(Ccode);
                quotobj.GetDataBase(Ccode);

            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);

            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCadd );
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lblQuot);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lblBooking);
            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_LinkButton1);
            // =================//

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranType"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}
            try
            {
                if (ddl_product.Text == "Ocean Exports")
                {
                    Session["StrTranType"] = "FE";
                    StrTranType = Session["StrTranType"].ToString();

                }
                else if (ddl_product.Text == "Ocean Imports")
                {
                    Session["StrTranType"] = "FI";
                    StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Air Exports")
                {
                    Session["StrTranType"] = "AE";
                    StrTranType = Session["StrTranType"].ToString();
                }
                else if (ddl_product.Text == "Air Imports")
                {
                    Session["StrTranType"] = "AI";
                    StrTranType = Session["StrTranType"].ToString();
                }

                else
                {
                    //if (Session["trantype_process"] != null)
                    //{
                    //    Session["StrTranType"] = null;
                    //}
                }



                txtQRemarks.Enabled = false;

                bid = Convert.ToInt32(Session["LoginBranchid"]);
                did = Convert.ToInt32(Session["LoginDivisionId"]);
                if (!this.IsPostBack)
                {

                    if (Session["trantype_process"] != null)
                    {
                        Session["StrTranType"] = null;
                    }




                    str_CtrlLists = "txt_vessel~txt_voyage~txt_vsl_pol~txt_vsl_pod~txt_etd~txt_eta";
                    str_MsgLists = "Vessel~Voyage~POL~POD~ETD~ETA";
                    str_DataType = "String~String~String~String~String~String";
                    btn_add.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");

                    txt_vol.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Volume')");

                      btnCancel.Text = "Cancel";

                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    if (Session["sess"] != null)
                    {

                        chkBox.Enabled = false;
                        lbtnSop.Visible = false;
                        txt_booking.Text = Session["booking"].ToString();
                        getvalue();
                        //btn_delete.Visible = false;
                        btnSave.Visible = false;
                        Button1.Visible = false;
                        // LinkButton1.Visible = false;

                        btn_LinkButton1.Visible = false;
                        btnCancel.Visible = false;
                        lnk_back.Visible = true;
                        lblQuot.Enabled = false;
                        lblBooking.Enabled = false;
                        LinkButton3.Enabled = false;
                        btnCancel.Visible = false;
                        Session["booking"] = null;
                        //UserRights();
                    }

                    else
                    {



                        grd_vessel.DataSource = null;
                        dtDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                        dtExpiredOn.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                        dtquotdate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                        txt_eta.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                        txt_etd.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                        txt_cutoff.Text = txt_etd.Text;
                        //lbl.Visible = true;
                        enabletxt();

                        grd.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd.DataBind();
                        GrdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                        GrdBuying.DataBind();
                        grdCMail.DataSource = Utility.Fn_GetEmptyDataTable();
                        grdCMail.DataBind();

                        txtBRemarks.Attributes.Add("onKeyPress", "return CheckTextLength(this,100,'Buying Remarks')");
                        txt_quatation.Attributes.Add("onKeyPress", "return IntegerCheck(event,'Quotation #')");
                        txt_booking.Attributes.Add("onKeyPress", "return CheckTextLength(this,30,'Booking #')");
                        txtBuying.Attributes.Add("onKeyPress", "return IntegerCheck(event,'Buying #')");
                        //string str_Ctrl = "txt_etd~txt_eta";
                        //btn_add.Attributes.Add("OnClick", "return IsDate('" + str_Ctrl + "')");
                        //ddlpdt.Items.Add("--Product--");
                        //ddlpdt.Items.Add("Forwarding Exports FCL");
                        //ddlpdt.Items.Add("Forwarding Exports LCL");
                        //ddlpdt.Items.Add("Forwarding Imports FCL");
                        //ddlpdt.Items.Add("Forwarding Imports LCL");
                        //ddlpdt.Items.Add("Air Exports");
                        //ddlpdt.Items.Add("Air Imports");
                        Button1.Enabled = false;
                        //btn_delete.Visible = true;
                        btnSave.Visible = true;
                        Button1.Visible = true;
                        //  LinkButton1.Visible = true;

                        btn_LinkButton1.Visible = true;
                        btnCancel.Visible = true;
                        lnk_back.Visible = false;
                        lblQuot.Enabled = true;
                        lblBooking.Enabled = true;
                        LinkButton3.Enabled = true;
                        btnCancel.Visible = true;

                        if (ddl_product.Text == "Ocean Exports")
                        {
                            Session["StrTranType"] = "FE";
                            StrTranType = Session["StrTranType"].ToString();

                        }
                        else if (ddl_product.Text == "Ocean Imports")
                        {
                            Session["StrTranType"] = "FI";
                            StrTranType = Session["StrTranType"].ToString();
                        }
                        else if (ddl_product.Text == "Air Exports")
                        {
                            Session["StrTranType"] = "AE";
                            StrTranType = Session["StrTranType"].ToString();
                        }
                        else if (ddl_product.Text == "Air Imports")
                        {
                            Session["StrTranType"] = "AI";
                            StrTranType = Session["StrTranType"].ToString();
                        }
                        else if (Request.QueryString.ToString().Contains("ebookingno"))
                        {
                            hidbookingno.Value = Request.QueryString["ebookingno"].ToString();
                            hid_bookingstatus.Value = Request.QueryString["confirmed"].ToString();
                            hidbookno.Value = Request.QueryString["bookno"].ToString();
                            Ebooking.Text = hidbookingno.Value;
                        }
                        else if (Request.QueryString.ToString().Contains("quotno"))
                        {
                            txt_quatation.Text = Request.QueryString["quotno"].ToString();
                            string product = Request.QueryString["product"].ToString();
                            StrTranType = Request.QueryString["product"].ToString();
                            if (product == "OE")
                            {
                                StrTranType = "FE";
                            }
                            else if (product == "OI")
                            {
                                StrTranType = "FI";
                            }
                            if (product == "OE")
                            {
                                ddl_product.Text = "OCEAN EXPORTS";
                            }
                            else if (product == "OI")
                            {
                                ddl_product.Text = "OCEAN IMPORTS";
                            }
                            else if (product == "AI")
                            {
                                ddl_product.Text = "AIR IMPORTS";
                            }
                            else if (product == "AE")
                            {
                                ddl_product.Text = "AIR EXPORTS";
                            }

                            txt_quatation_TextChanged(sender, e);
                        }
                    }
                    lbtnSop.Enabled = false;
                    chkBox.Enabled = false;
                    lbtnSop1.Attributes["class"] = "lbtnSop1";

                    txt_booking.Focus();
                    //viewcheckgrd();

                    test.Text = "Credit Days:" + "," + "Credit Amount:" + "," + "Over Due Days:" + "," + "Over Due Amount:" + "," + "Total OS Amt:";
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
                else
                {

                }
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        div_vessel_grid.Visible = true;
                     //   div_vessel_add.Visible = true;
                        // txtFactory.Enabled = true;
                    }
                    else
                    {
                        txtFactory.Enabled = false;
                    }
                }
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                Session["booking"] = null;
                Session["sess"] = null;
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
        public static List<string> GETShipbill(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dt = new DataTable();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataAccess.ForwardingExports.ShippingBill obj_shipbill = new DataAccess.ForwardingExports.ShippingBill();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_shipbill.GetDataBase(Ccode);
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
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_mpackage.GetDataBase(Ccode);
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
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_mcustomer.GetDataBase(Ccode);
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
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_portname.GetDataBase(Ccode);
            dt = obj_portname.GetLikePort(prefix);
            List_Result = Utility.Fn_TableToList(dt, "portname", "portid");
            return List_Result;
        }
        protected void UserRights()
        {
            try
            {
                if (StrTranType != "")
                {
                    str_Uiid = userperobj.Getuiid(StrTranType, 2, lblheader.Text.Trim());
                    if (str_Uiid != "")
                    {
                        //str_Uiid = Request.QueryString["uiid"].ToString();
                        Utility.Fn_CheckUserRights(str_Uiid, btnSave, btn_view, null);
                    }
                }

                //if (Request.QueryString.ToString().Contains("type"))
                //{
                //    Boolean btn_delete;
                //    //str_FornName = Request.QueryString["type"].ToString();
                //    str_Uiid = Request.QueryString["uiid"].ToString();
                //    Utility.Fn_CheckUserRights(str_Uiid, btnSave, btn_view, null);
                //    //DataTable obj_Dtuser = new DataTable();
                //    //obj_Dtuser = (DataTable)Session["dt_UserRights"];
                //    //DataView obj_dtview = new DataView(obj_Dtuser);
                //    //obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                //    //obj_Dtuser = obj_dtview.ToTable();
                //    //btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


                //}
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        /*public static void Fn_CheckUserRights(string Str_UIID, Button Btn_Save, Button Btn_View, Button Btn_Delete)
        {
            DataTable dt_okuser = new DataTable();
            dt_okuser = (DataTable)HttpContext.Current.Session["dt_UserRights"];
            if (dt_okuser != null)
            {
                var UserRights = dt_okuser.AsEnumerable().Where(row => row["uiid"].ToString() == Str_UIID).ToList();
                if (UserRights.Count > 0)
                {
                    if (Btn_Save != null)
                    {
                        Btn_Save.Enabled = Boolean.Parse(UserRights[0]["btnsave"].ToString());
                        if (Btn_Save.Text == "Update")
                        {
                            Btn_Save.Enabled = Boolean.Parse(UserRights[0]["btnupdate"].ToString());
                        }
                    }
                    if (Btn_View != null)
                    {
                        Btn_View.Enabled = Boolean.Parse(UserRights[0]["btnview"].ToString());

                    }
                    if (Btn_Delete != null)
                    {
                        Btn_Delete.Enabled = Boolean.Parse(UserRights[0]["btndelete"].ToString());
                       
                         
                       
                    }

                }
            }
        }

        */


        [WebMethod]
        public static List<string> Get_Factory(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Cusobj.GetDataBase(Ccode);
            DataTable dtCarrier = new DataTable();
            dtCarrier = Cusobj.GetLikeCustomer(prefix.ToUpper(), "C");
            List_Result = Utility.Fn_TableToList(dtCarrier, "customer", "customerid", "customername", "address");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLikeCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Cusobj.GetDataBase(Ccode);
            DataTable dtCarrier = new DataTable();
            dtCarrier = Cusobj.GetLikeCustomer(prefix.ToUpper(), "C");

            List_Result = Utility.Fn_TableToList(dtCarrier, "customer", "customerid", "customername", "address");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLikeCustomerShip()
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Cusobj.GetDataBase(Ccode);
            DataTable dtCarrier = new DataTable();
            dtCarrier = Cusobj.GetLikeCustomerShipCons(Convert.ToInt32(HttpContext.Current.Session["hdn_shipperid"]), "C");
            List_Result = Utility.Fn_TableToList(dtCarrier, "email", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLikeCustomerCons()
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Cusobj.GetDataBase(Ccode);
            DataTable dtCarrier = new DataTable();
            dtCarrier = Cusobj.GetLikeCustomerShipCons(Convert.ToInt32(HttpContext.Current.Session["hdn_Consigneeid"]), "C");
            List_Result = Utility.Fn_TableToList(dtCarrier, "email", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLikeAgent(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            Cusobj.GetDataBase(Ccode);
            DataTable dtCarrier = new DataTable();
            dtCarrier = Cusobj.GetLikeCustomer(prefix.ToUpper(), "P");
            List_Result = Utility.Fn_TableToList(dtCarrier, "customer", "customerid", "customername", "address");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetBookingPending(string prefix)
        {
            List<string> List_Result = new List<string>();
            string StrTranType = "";
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                StrTranType = HttpContext.Current.Session["StrTranType"].ToString();
            }

            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            bookingobj.GetDataBase(Ccode);
            DataTable dtbooking = new DataTable();
            dtbooking = bookingobj.GetBookingPending(StrTranType, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(dtbooking, "bookingno", "bookno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLikeCustMailID(string prefix)
        {
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_stuf = new DataAccess.ForwardingExports.StuffingConfirmation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_stuf.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Shipermail = new List<string>();
            obj_Dt = obj_da_stuf.GetLikeCustMailID(prefix.ToUpper());
            Shipermail = Utility.Fn_DatatableToList_int32(obj_Dt, "email", "customerid");
            return Shipermail;
        }


        [WebMethod]
        public static List<string> GetLikeIncocode(string prefix)
        {
            DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            bookingobj.GetDataBase(Ccode);
            DataTable obj_Dt = new DataTable();
            List<string> Incocode = new List<string>();
            obj_Dt = bookingobj.GetLikeIncocode(prefix.ToUpper());
            Incocode = Utility.Fn_DatatableToList_int32(obj_Dt, "incocode", "incoid");
            return Incocode;
        }
        [WebMethod]
        public static List<string> FEShippingbill_GetShipNo(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.ShippingBill da_obj_ship = new DataAccess.ForwardingExports.ShippingBill();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_ship.GetDataBase(Ccode);
            obj_dt = da_obj_ship.GetLikeShipBill(prefix, int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "sbno");
            return List_Result;
        }


        protected void LoadQuotation()
        {

            try
            {
                // StrTranType = Session["StrTranType"].ToString();

                if (txt_booking.Text.Trim() == "")
                {
                    grdQuotation.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdQuotation.DataBind();

                    if (txt_qcustomer.Text != "" && hdn_QuotCustomer.Value != "")
                    {
                        dtBooking = bookingobj.QuotGrdDetailsCust("", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hdn_QuotCustomer.Value));
                    }
                    else
                    {
                        dtBooking = bookingobj.QuotGrdDetails("", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    }
                    if (dtBooking.Rows.Count > 0)
                    {
                        grdCancel.Visible = false;
                        grdBooking.Visible = false;
                        grdQuotation.Visible = true;
                        grdQuotation.DataSource = dtBooking;
                        grdQuotation.DataBind();
                        ViewState["quotation"] = dtBooking;
                        this.popupBuying.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Quotation Unavailable');", true);
                    }
                }
                else
                {
                    dtBooking = bookingobj.QuotGrdDetails4booking(StrTranType, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text);
                    if (dtBooking.Rows.Count > 0)
                    {
                        grdCancel.Visible = false;
                        grdBooking.Visible = false;
                        grdQuotation.Visible = true;
                        grdQuotation.DataSource = dtBooking;
                        grdQuotation.DataBind();
                        this.popupBuying.Show();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Quotation Unavailable');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lblQuot_Click(object sender, EventArgs e)
        {


            LoadQuotation();
            UserRights();
            if (ddl_product.Text == "OCEAN EXPORTS")
            {
                dts = objship.Getsbno();
                checkview.DataSource = dts;
                checkview.DataBind();
            }

        }

        protected void grdQuotation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdQuotation, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void GetAllMailIds(int Custid)
        {
            try
            {
                dt = new DataTable();

                dt = bookingobj.GETMAilis4BookigCRM(Custid);
                if (dt.Rows.Count > 0)
                {
                    DataTable dttemp = new DataTable();
                    dttemp.Columns.Add("Cname");
                    dttemp.Columns.Add("email");
                    DataRow dr;
                    string Comptc = dt.Rows[0]["comptc"].ToString();
                    string Expptc = dt.Rows[0]["expptc"].ToString();
                    string Mgtptc = dt.Rows[0]["managptc"].ToString();
                    string Imptc = dt.Rows[0]["impptc"].ToString();
                    string Finptc = dt.Rows[0]["finptc"].ToString();

                    string ComMail = dt.Rows[0]["commailid"].ToString();
                    string ExpMail = dt.Rows[0]["expmailid"].ToString();
                    string MgtMail = dt.Rows[0]["managmail"].ToString();
                    string ImpMail = dt.Rows[0]["impmailid"].ToString();
                    string FinMail = dt.Rows[0]["finmailid"].ToString();

                    dr = dttemp.NewRow();
                    dr["Cname"] = Comptc;
                    dr["email"] = ComMail;
                    dttemp.Rows.Add(dr);

                    dr = dttemp.NewRow();
                    dr["Cname"] = Expptc;
                    dr["email"] = ExpMail;
                    dttemp.Rows.Add(dr);

                    dr = dttemp.NewRow();
                    dr["Cname"] = Mgtptc;
                    dr["email"] = MgtMail;
                    dttemp.Rows.Add(dr);

                    dr = dttemp.NewRow();
                    dr["Cname"] = Imptc;
                    dr["email"] = ImpMail;
                    dttemp.Rows.Add(dr);

                    dr = dttemp.NewRow();
                    dr["Cname"] = Finptc;
                    dr["email"] = FinMail;
                    dttemp.Rows.Add(dr);

                    if (txt_mailid.Text != "" && txt_agent.Text != "")
                    {
                        int COUNT = dttemp.Rows.Count + 1;
                        dttemp.Rows.Add();
                        dttemp.Rows[COUNT]["Cname"] = txt_agent.Text;
                        dttemp.Rows[COUNT]["email"] = txt_mailid.Text;
                    }

                    DataTable dt1 = dttemp.Clone(); //copy the structure 
                    for (int i = 0; i <= dttemp.Rows.Count - 1; i++) //iterate through the rows of the source
                    {
                        DataRow currentRow = dttemp.Rows[i];  //copy the current row 
                        foreach (var colValue in currentRow.ItemArray)//move along the columns 
                        {
                            if (currentRow[0] != "" && currentRow[1] != "")
                            {
                                if (!string.IsNullOrEmpty(colValue.ToString())) // if there is a value in a column, copy the row and finish
                                {
                                    dt1.ImportRow(currentRow);
                                    break; //break and get a new row                        
                                }
                            }
                        }
                    }

                    if (dt1.Rows.Count > 0)
                    {
                        grdCMail.DataSource = dt1;
                        grdCMail.DataBind();
                        ViewState["CurrentData"] = dt1;
                    }
                    else
                    {
                        grdCMail.DataSource = Utility.Fn_GetEmptyDataTable();
                        grdCMail.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        protected void grdQuotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdQuotation.Rows.Count > 0)
                {
                    Session["StrTranType"] = null;
                    ddl_product.Text = "";
                    int index = grdQuotation.SelectedRow.RowIndex;
                    txt_quatation.Text = grdQuotation.SelectedRow.Cells[0].Text;
                    hdn_quotid.Value = grdQuotation.SelectedRow.Cells[0].Text;
                    txt_qcustomer.Text = grdQuotation.SelectedRow.Cells[1].Text;
                    dtBooking = quotobj.GetQuotationDetails(Convert.ToInt32(txt_quatation.Text), "", Convert.ToInt32(Session["LoginBranchid"]));

                    if (dtBooking.Rows.Count > 0)
                    {
                        string product = dtBooking.Rows[0]["trantype"].ToString();
                        if (product == "OE")
                        {
                            Session["StrTranType"] = "FE";
                            StrTranType = Session["StrTranType"].ToString();
                            ddl_product.Text = "OCEAN EXPORTS";
                        }
                        else if (product == "OI")
                        {
                            Session["StrTranType"] = "FI";
                            StrTranType = Session["StrTranType"].ToString();
                            ddl_product.Text = "OCEAN IMPORTS";
                        }
                        else if (product == "AE")
                        {
                            Session["StrTranType"] = "AE";
                            StrTranType = Session["StrTranType"].ToString();
                            ddl_product.Text = "AIR EXPORTS";
                        }
                        else if (product == "AI")
                        {
                            Session["StrTranType"] = "AI";
                            StrTranType = Session["StrTranType"].ToString();
                            ddl_product.Text = "AIR IMPORTS";
                        }
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                HeaderLabel1.InnerText = "OceanExports";
                                dts = objship.Getsbno();
                                checkview.DataSource = dts;
                                checkview.DataBind();
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                HeaderLabel1.InnerText = "OceanImports";
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                HeaderLabel1.InnerText = "AirExports";
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                HeaderLabel1.InnerText = "AirImports";
                            }
                        }
                        hdn_Business.Value = dtBooking.Rows[0]["business"].ToString();
                        dtquotdate.Text = DateTime.Parse(dtBooking.Rows[0]["quotdate"].ToString()).ToString("dd-MMM-yyyy");
                        //dtquotdate.Text = Utility.fn_ConvertDate(dtBooking.Rows[0]["quotdate"].ToString());
                        dtExpiredOn.Enabled = false;
                        dtExpiredOn.Text = DateTime.Parse(dtBooking.Rows[0]["validtill"].ToString()).ToString("dd-MMM-yyyy");
                        //dtExpiredOn .Text = Utility.fn_ConvertDate(dtBooking.Rows[0]["validtill"].ToString());
                        int cargoid = Convert.ToInt32(dtBooking.Rows[0]["cargoid"].ToString());
                        intShipment = dtBooking.Rows[0]["stype"].ToString();
                        strfstatus = dtBooking.Rows[0]["fstatus"].ToString();
                        intsales = dtBooking.Rows[0]["marketedby"].ToString();
                        hd_cusid.Value = dtBooking.Rows[0]["customerid"].ToString();
                        hd_controll.Value = dtBooking.Rows[0]["business"].ToString();

                        if (hd_controll.Value == "O")
                        {
                            txt_controll.Text = "Controlled By Us";
                        }
                        else
                        {
                            txt_controll.Text = "Agent Controlled";
                        }

                        txtMarketby.Text = "";
                        //lbl.Visible = true;
                        txtMarketby.Text = empobj.GetEmployeeName(Convert.ToInt32(intsales));
                        intpor = dtBooking.Rows[0]["por"].ToString();
                        intpol = dtBooking.Rows[0]["pol"].ToString();
                        intpod = dtBooking.Rows[0]["pod"].ToString();
                        intfd = dtBooking.Rows[0]["fd"].ToString();
                        intcustid = dtBooking.Rows[0]["customerid"].ToString();

                        if (StrTranType == "FI" || StrTranType == "AI")
                        {
                           
                            if (dtBooking.Rows[0]["shipperid"].ToString() != "")
                            {
                                hdn_shipperid.Value = dtBooking.Rows[0]["shipperid"].ToString();
                                txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(dtBooking.Rows[0]["shipperid"].ToString()));
                                txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtBooking.Rows[0]["shipperid"].ToString()));
                                DataTable dtmail = new DataTable();
                                string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBooking.Rows[0]["shipperid"].ToString()));

                                if (Shipmail != "")
                                {
                                    dtmail = new DataTable();
                                    dtmail.Columns.Add("email");
                                    dtmail.Columns.Add("Cname");
                                    dtmail.Rows.Add(Shipmail, "Shipper");
                                    grdCMail.DataSource = dtmail;
                                    grdCMail.DataBind();
                                    ViewState["CurrentData"] = dtmail;
                                }


                            }
                        }
                        else
                        {
                            DataTable dtmail = new DataTable();
                            string Shipmail = "";
                            
                            if (dtBooking.Rows[0]["consigneeid"].ToString() != "")
                            {
                                hdn_Consigneeid.Value = dtBooking.Rows[0]["consigneeid"].ToString();
                                txt_consignee.Text = custobj.GetCustomername(Convert.ToInt32(dtBooking.Rows[0]["consigneeid"].ToString()));
                                txt_consigneemulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtBooking.Rows[0]["consigneeid"].ToString()));
                                 Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBooking.Rows[0]["consigneeid"].ToString()));
                                if (Shipmail != "")
                                {
                                    dtmail = new DataTable();
                                    dtmail.Columns.Add("email");
                                    dtmail.Columns.Add("Cname");
                                    dtmail.Rows.Add(Shipmail, "Shipper");
                                    grdCMail.DataSource = dtmail;
                                    grdCMail.DataBind();
                                    ViewState["CurrentData"] = dtmail;
                                }


                            }

                        }




                        string datainco = dtBooking.Rows[0]["inco"].ToString();
                        if (datainco != "")
                        {
                            hdn_Incoid.Value = dtBooking.Rows[0]["inco"].ToString();

                            DataTable dtinco = new DataTable();
                            dtinco = bookingobj.SelMasterInco(Convert.ToInt32(hdn_Incoid.Value));
                            if (dtinco.Rows.Count > 0)
                            {
                                txtInco.Text = dtinco.Rows[0]["incocode"].ToString();
                            }
                        }

                        //DataAccess.Masters.MasterPort objpot = new DataAccess.Masters.MasterPort();
                        int countryid = objpot.sp_countryidprt(Convert.ToInt32(intpor));
                        if (countryid.ToString() != "10")
                        {
                            countryid = objpot.sp_countryidprt(Convert.ToInt32(intpol));
                            if (countryid.ToString() != "10")
                            {
                                countryid = objpot.sp_countryidprt(Convert.ToInt32(intpod));
                                if (countryid.ToString() != "10")
                                {
                                    countryid = objpot.sp_countryidprt(Convert.ToInt32(intpod));
                                    if (countryid.ToString() == "10")
                                    {
                                        Session["approved"] = "N";
                                    }
                                    else
                                    {
                                        Session["approved"] = "Y";
                                    }
                                }
                                else
                                {
                                    Session["approved"] = "N";
                                }
                            }
                            else
                            {
                                Session["approved"] = "N";
                            }


                        }
                        else
                        {
                            Session["approved"] = "N";
                        }
                        txt_qcustomer.Text = custobj.GetCustomername(Convert.ToInt32(intcustid));
                    
                       // txtQRemarks.Text = dtBooking.Rows[0]["remarks"].ToString();
                        //txtQRemarks.Enabled = false;
                        txtBRemarks.Text = dtBooking.Rows[0]["remarks"].ToString();
                        txt_custpono.Text = dtBooking.Rows[0]["cuspono"].ToString();
                        //    txtBRemarks.Enabled = false;
                        //  txtBRemarks.Text = dtBooking.Rows[0]["remarks"].ToString();
                        txt_cargo.Text = cargoobj.GetCargoname(Convert.ToInt32(cargoid));
                        txt_por.Text = portobj.GetPortname(Convert.ToInt32(intpor));
                        /* string portcode;
                         portcode = portobj.GetPortCodefrmPort(Convert.ToInt32(intpor));

                         if (portcode.Length == 3)
                         {
                             hid_PoRportcode.Value = portcode;
                         }
                         else if (portcode.Length >= 5)
                         {
                             hid_PoRportcode.Value = portcode.Substring(2, 3);
                         }
                         else
                         {
                             hid_PoRportcode.Value = "";
                         }*/
                        txt_pol.Text = portobj.GetPortname(Convert.ToInt32(intpol));
                        txt_pod.Text = portobj.GetPortname(Convert.ToInt32(intpod));
                        txt_fd.Text = portobj.GetPortname(Convert.ToInt32(intfd));
                        //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                        dt = obj_MasterPort.SelPortName4typepadimg(txt_fd.Text.ToUpper(), Session["StrTranType"].ToString());
                        fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txt_por.Text.ToUpper(), Session["StrTranType"].ToString());
                        porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txt_pod.Text.ToUpper(), Session["StrTranType"].ToString());
                        podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                        dt = obj_MasterPort.SelPortName4typepadimg(txt_pol.Text.ToUpper(), Session["StrTranType"].ToString());
                        flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";
                        if (intShipment == "L")
                        {
                            txtshipment.Text = "LCL";
                            lbl_voll.Text = "CBM";
                        }
                        else if (intShipment == "F")
                        {
                            txtshipment.Text = "FCL";
                            lbl_voll.Text = "Teus";
                        }
                        if (strfstatus == "P")
                        {
                            txtfreight.Text = "Prepaid";
                        }

                        if (strfstatus == "C")
                        {
                            if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                            {
                                txtfreight.Text = "collect";
                            }
                            else
                            {
                                txtfreight.Text = "collect";
                            }

                        }

                        int cusid = Convert.ToInt32(dtBooking.Rows[0]["customerid"].ToString());
                        GetAllMailIds(cusid);

                        txt_vol.Text = "";
                        txt_booking.Text = "";

                         btnSave.Text = "Save";
                         btnCancel.Text = "Cancel";

                        btnSave.ToolTip = "Save";
                        btn_save1.Attributes["class"] = "btn ico-save";
                        btnCancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        txtunable();
                        grdfill();

                        if (blnerr == true)
                        {
                            return;
                        }

                        dtTable = custobj.Getsop(Convert.ToInt32(intcustid));

                        if (dtTable.Rows.Count > 0)
                        {
                            lbtnSop.Enabled = true;
                            chkBox.Enabled = true;
                            lbtnSop1.Attributes["class"] = "SOP";

                        }
                        else
                        {
                            lbtnSop.Enabled = false;
                            chkBox.Enabled = false;
                            lbtnSop1.Attributes["class"] = "lbtnSop1";

                        }

                        ViewState["dtTable"] = dtTable;
                        dtBuying = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txt_quatation.Text), StrTranType, Convert.ToInt32(Session["LoginBranchid"]), "QB");
                        if (dtBuying.Rows.Count > 0)
                        {
                            txtBuying.Text = dtBuying.Rows[0]["buyingno"].ToString();
                            dtrateid = buyingobj.SelectBuyingHeadAll(Convert.ToInt32(txtBuying.Text));
                            if (dtrateid.Rows.Count > 0)
                            {
                                bfreight = dtrateid.Rows[0]["freight"].ToString();
                                txt_validtill.Text = Utility.fn_ConvertDate(dtrateid.Rows[0]["validtill"].ToString());
                                // txtBRemarks.Text = dtrateid.Rows[0]["remarks"].ToString();
                            }
                            grdBuyingfill();
                        }

                        if (StrTranType == "FI" || StrTranType == "AI")
                        {
                            if (dtBuying.Rows[0]["customerid"].ToString() != "")
                            {
                                intcustid = dtBuying.Rows[0]["customerid"].ToString();
                                hdn_Consigneeid.Value = dtBuying.Rows[0]["customerid"].ToString();
                                txt_consignee.Text = custobj.GetCustomername(Convert.ToInt32(intcustid));
                                txt_consigneemulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(intcustid));

                                //  txtBRemarks.Text = dtBooking.Rows[0]["remarks"].ToString();
                                DataTable dtmail = new DataTable();
                                string consmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));
                                if (consmail != "")
                                {
                                    dtmail = new DataTable();
                                    dtmail.Columns.Add("email");
                                    dtmail.Columns.Add("Cname");
                                    dtmail.Rows.Add(consmail, "Consignee");
                                    grdCMail.DataSource = dtmail;
                                    grdCMail.DataBind();
                                    ViewState["CurrentData"] = dtmail;

                                }
                            }
                            else
                            {
                                txt_consignee.Text = "";
                                txt_consigneemulti.Text = "";
                            }
                            


                           
                        }
                        else
                        {
                            hdn_shipperid.Value = dtBuying.Rows[0]["customerid"].ToString();
                            txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));
                            txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));
                            DataTable dtmail = new DataTable();
                            string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                            if (Shipmail != "")
                            {
                                dtmail = new DataTable();
                                dtmail.Columns.Add("email");
                                dtmail.Columns.Add("Cname");
                                dtmail.Rows.Add(Shipmail, "Shipper");
                                grdCMail.DataSource = dtmail;
                                grdCMail.DataBind();
                                ViewState["CurrentData"] = dtmail;
                            }
                           

                           

                        }
                        if (StrTranType == "AE" || StrTranType == "AI")
                        {
                            txtshipment.Text = "";
                            lbl_voll.Text = "Kgs";
                        }

                        txt_shiper.Focus();


                    }
                   

                }
                // add by yuvaraj 27/12/2022
                DataTable dtcbm = new DataTable();
                dtcbm = quotobj.GETTUESCBMVALUE(Convert.ToInt32(txt_quatation.Text), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), intShipment);
                if (dtcbm.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(dtcbm.Rows[0]["Tues"].ToString()))
                    {
                        txt_vol.Text = dtcbm.Rows[0]["Tues"].ToString();

                    }
                }
                
                txtInco.ReadOnly = false;
                txt_vol.Enabled = true;
                txt_quatation.Enabled = true;
                txt_vessel.Text = ""; txt_voyage.Text = ""; txt_vsl_pod.Text = ""; txt_vsl_pol.Text = ""; btn_add.ToolTip = "Add";

                btn_add1.Attributes["class"] = "btn ico-add";
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void grdfill()
        {
            try
            {
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
                dtBooking = quotobj.ChargeDetails(Convert.ToInt32(txt_quatation.Text), Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text.Trim());
                //dtBooking = crmbkngobj .CRMChargeDetails(Convert.ToInt32 (txt_quatation.Text), Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text.Trim());
                if (dtBooking.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtBooking.Rows.Count - 1; i++)
                    {
                        BoundField priceField = grd.Columns[2] as BoundField;
                        grd.DataSource = dtBooking;
                        grd.DataBind();
                        grd.Rows[i].Cells[0].Text = dtBooking.Rows[i][0].ToString();
                        grd.Rows[i].Cells[1].Text = dtBooking.Rows[i][1].ToString();
                        grd.Rows[i].Cells[3].Text = dtBooking.Rows[i][3].ToString();
                    }
                    for (int i = 0; i <= dtBooking.Rows.Count - 1; i++)
                    {

                        if (txt_booking.Text != "")
                        {

                            string precol = bookingobj.GetBookingCharges(txt_booking.Text, dtBooking.Rows[i][0].ToString(), dtBooking.Rows[i][3].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                            DropDownList ddlRoleList = new DropDownList();
                            foreach (GridViewRow row in grd.Rows)
                            {

                                ddlRoleList = (DropDownList)row.FindControl("ddl_item_prepaid_grd");
                                ddlRoleList.Visible = true;

                            }
                            if (precol == "C")
                            {
                                if (StrTranType == "AE" || StrTranType == "AI")
                                {

                                    ((DropDownList)grd.Rows[i].FindControl("ddl_item_prepaid_grd")).SelectedValue = "1";// yuvaraj 27/12/2022 
                                }
                                else
                                {
                                    ((DropDownList)grd.Rows[i].FindControl("ddl_item_prepaid_grd")).SelectedValue = "1";
                                }

                            }
                            else if (precol == "P")
                            {
                                ((DropDownList)grd.Rows[i].FindControl("ddl_item_prepaid_grd")).SelectedValue = "0";
                            }
                        }
                        else
                        {
                            if (strfstatus == "C")
                            {
                                if (StrTranType == "AE" || StrTranType == "AI")
                                {

                                    ((DropDownList)grd.Rows[i].FindControl("ddl_item_prepaid_grd")).SelectedValue = "1"; // yuvaraj 27/12/2022
                                }
                                else
                                {
                                    ((DropDownList)grd.Rows[i].FindControl("ddl_item_prepaid_grd")).SelectedValue = "1";
                                }
                            }
                            else if (strfstatus == "P")
                            {

                                ((DropDownList)grd.Rows[i].FindControl("ddl_item_prepaid_grd")).SelectedValue = "0";

                            }
                        }

                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('The Quotation Charges details are  empty for " + txt_quatation.Text + "# ,Kindly Update the Quotation charges ');", true);
                    txt_quatation.Text = "";
                    txt_quatation.Focus();
                    blnerr = true;
                    return;
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void grdBuyingfill()
         {
            try
            {
                if (txtBuying.Text != "")
                {
                    GrdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdBuying.DataBind();
                    dtBooking = quotobj.ChargeBuyingDetails(Convert.ToInt32(txtBuying.Text), Convert.ToInt32(Session["LoginBranchid"]));

                    if (dtBooking.Rows.Count > 0)
                    {
                        for (i = 0; i <= GrdBuying.Rows.Count - 1; i++)
                        {
                            GrdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                            GrdBuying.DataBind();

                        }

                        for (i = 0; i <= dtBooking.Rows.Count - 1; i++)
                        {

                            GrdBuying.DataSource = dtBooking;
                            GrdBuying.DataBind();
                        }
                        for (i = 0; i <= dtBooking.Rows.Count - 1; i++)
                        {

                            if (txt_booking.Text != "")
                            {
                                DropDownList ddlRoleList = new DropDownList();
                                foreach (GridViewRow row in GrdBuying.Rows)
                                {

                                    ddlRoleList = (DropDownList)row.FindControl("ddl_item_prepaid");
                                    ddlRoleList.Visible = true;

                                }

                                string precol = bookingobj.GetBookingBuyingCharges(txt_booking.Text, dtBooking.Rows[i][0].ToString(), dtBooking.Rows[i][3].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                                if (precol == "C")
                                {

                                    // ((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue = "1";
                                    if (StrTranType == "AE" || StrTranType == "AI")
                                    {

                                        ((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue = "1";// add yuvaraj yuvaraj 27/12/2022
                                    }
                                    else
                                    {
                                        ((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue = "1";
                                    }
                                }
                                else if (precol == "P")
                                {

                                    ((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue = "0";
                                }
                            }
                            else
                            {
                                //string precol = bookingobj.GetBookingBuyingCharges(txt_booking.Text, dtBooking.Rows[i][0].ToString(), dtBooking.Rows[i][3].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                                if (bfreight == "C")
                                {
                                    // ((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue = "1";

                                    if (StrTranType == "AE" || StrTranType == "AI")
                                    {

                                        ((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue = "1";// add by yuvaraj 27/12/2022
                                    }
                                    else
                                    {
                                        ((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue = "1";
                                    }
                                }
                                else if (bfreight == "P")
                                {
                                    ((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue = "0";

                                }
                            }

                        }

                    }
                    else
                    {
                        GrdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
                        GrdBuying.DataBind();
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

        public void InsBookingDetails(string bookno)
        {
            try
            {
                bookingobj.DelBookingCharges(bookno, Convert.ToInt32(Session["LoginBranchid"]));

                for (i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    if (grd.Rows.Count > 0)
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                            {
                                if (((DropDownList)grd.Rows[i].FindControl("ddl_item_prepaid_grd")).SelectedValue == "1")
                                {
                                    bookingobj.InsertChargeDetails(Convert.ToInt32(txt_quatation.Text), HttpUtility.HtmlDecode(grd.Rows[i].Cells[0].Text), grd.Rows[i].Cells[1].Text, Convert.ToSingle(grd.Rows[i].Cells[2].Text), grd.Rows[i].Cells[3].Text, bookno, "C", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));


                                }
                                else
                                {
                                    bookingobj.InsertChargeDetails(Convert.ToInt32(txt_quatation.Text), HttpUtility.HtmlDecode(grd.Rows[i].Cells[0].Text), grd.Rows[i].Cells[1].Text, Convert.ToSingle(grd.Rows[i].Cells[2].Text), grd.Rows[i].Cells[3].Text, bookno, "P", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                    //crmbkngobj.InsertChargeDetailsCRM(Convert.ToInt32(txt_quatation.Text), grd.Rows[i].Cells[0].Text, grd.Rows[i].Cells[1].Text, Convert.ToSingle(grd.Rows[i].Cells[2].Text), grd.Rows[i].Cells[3].Text, bookno, "P", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                }

                            }
                            else
                            {
                                if (((DropDownList)grd.Rows[i].FindControl("ddl_item_prepaid_grd")).SelectedValue == "0")
                                {
                                    bookingobj.InsertChargeDetails(Convert.ToInt32(txt_quatation.Text), HttpUtility.HtmlDecode(grd.Rows[i].Cells[0].Text), grd.Rows[i].Cells[1].Text, Convert.ToSingle(grd.Rows[i].Cells[2].Text), grd.Rows[i].Cells[3].Text, bookno, "P", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));


                                }
                                else
                                {
                                    bookingobj.InsertChargeDetails(Convert.ToInt32(txt_quatation.Text), HttpUtility.HtmlDecode(grd.Rows[i].Cells[0].Text), grd.Rows[i].Cells[1].Text, Convert.ToSingle(grd.Rows[i].Cells[2].Text), grd.Rows[i].Cells[3].Text, bookno, "C", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                    //crmbkngobj.InsertChargeDetailsCRM(Convert.ToInt32(txt_quatation.Text), grd.Rows[i].Cells[0].Text, grd.Rows[i].Cells[1].Text, Convert.ToSingle(grd.Rows[i].Cells[2].Text), grd.Rows[i].Cells[3].Text, bookno, "P", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
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
        public void InsBuyingBookingDetails(string bookno)
        {
            try
            {
                bookingobj.DelBookingBuyingCharges(bookno, Convert.ToInt32(Session["LoginBranchid"]));
                //crmbkngobj.DelBookingBuyingCharges4CRM(bookno, Convert.ToInt32(Session["LoginBranchid"]));
                for (i = 0; i <= GrdBuying.Rows.Count - 1; i++)
                {
                    if (GrdBuying.Rows.Count > 0)
                    {

                        if (StrTranType == "AE" || StrTranType == "AI")
                        {
                            if (((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue == "1")
                            {
                                bookingobj.InsertbuyingChargeDetails(Convert.ToInt32(txtBuying.Text), HttpUtility.HtmlDecode(GrdBuying.Rows[i].Cells[0].Text), GrdBuying.Rows[i].Cells[1].Text, Convert.ToSingle(GrdBuying.Rows[i].Cells[2].Text), GrdBuying.Rows[i].Cells[3].Text, bookno, "C", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                // crmbkngobj.InsertbuyingChargeDetails4CRM(Convert.ToInt32(txtBuying.Text), GrdBuying.Rows[i].Cells[0].Text, GrdBuying.Rows[i].Cells[1].Text, Convert.ToSingle(GrdBuying.Rows[i].Cells[2].Text), GrdBuying.Rows[i].Cells[3].Text, bookno, "C", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                            }
                            else
                            {
                                bookingobj.InsertbuyingChargeDetails(Convert.ToInt32(txtBuying.Text), HttpUtility.HtmlDecode(GrdBuying.Rows[i].Cells[0].Text), GrdBuying.Rows[i].Cells[1].Text, Convert.ToSingle(GrdBuying.Rows[i].Cells[2].Text), GrdBuying.Rows[i].Cells[3].Text, bookno, "P", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                //crmbkngobj.InsertbuyingChargeDetails4CRM(Convert.ToInt32(txtBuying.Text), GrdBuying.Rows[i].Cells[0].Text, GrdBuying.Rows[i].Cells[1].Text, Convert.ToSingle(GrdBuying.Rows[i].Cells[2].Text), GrdBuying.Rows[i].Cells[3].Text, bookno, "P", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                            }
                        }
                        else
                        {
                            if (((DropDownList)GrdBuying.Rows[i].FindControl("ddl_item_prepaid")).SelectedValue == "0")
                            {
                                bookingobj.InsertbuyingChargeDetails(Convert.ToInt32(txtBuying.Text), HttpUtility.HtmlDecode(GrdBuying.Rows[i].Cells[0].Text), GrdBuying.Rows[i].Cells[1].Text, Convert.ToSingle(GrdBuying.Rows[i].Cells[2].Text), GrdBuying.Rows[i].Cells[3].Text, bookno, "P", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                // crmbkngobj.InsertbuyingChargeDetails4CRM(Convert.ToInt32(txtBuying.Text), GrdBuying.Rows[i].Cells[0].Text, GrdBuying.Rows[i].Cells[1].Text, Convert.ToSingle(GrdBuying.Rows[i].Cells[2].Text), GrdBuying.Rows[i].Cells[3].Text, bookno, "C", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

                            }
                            else
                            {
                                bookingobj.InsertbuyingChargeDetails(Convert.ToInt32(txtBuying.Text), HttpUtility.HtmlDecode(GrdBuying.Rows[i].Cells[0].Text), GrdBuying.Rows[i].Cells[1].Text, Convert.ToSingle(GrdBuying.Rows[i].Cells[2].Text), GrdBuying.Rows[i].Cells[3].Text, bookno, "C", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                //crmbkngobj.InsertbuyingChargeDetails4CRM(Convert.ToInt32(txtBuying.Text), GrdBuying.Rows[i].Cells[0].Text, GrdBuying.Rows[i].Cells[1].Text, Convert.ToSingle(GrdBuying.Rows[i].Cells[2].Text), GrdBuying.Rows[i].Cells[3].Text, bookno, "P", Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
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

        public void checkdata()
        {
            try
            {

                if (txt_vol.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Volume cannot be BLANK');", true);
                    blnerr = true;
                    txt_vol.Focus();
                    return;

                }
                if (txtInco.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('IncoTerm cannot be BLANK');", true);
                    blnerr = true;
                    txtInco.Focus();
                    return;
                }
                else
                {
                    if (hdn_Incoid.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Inco Term');", true);
                        blnerr = true;
                        txtInco.Focus();

                        return;
                    }
                }

                if (StrTranType == "FI")
                {
                    if (txt_agent.Text.Trim() != "")
                    {
                        if (hdn_agentid.Value == "" || hdn_agentid.Value == "0")
                        {
                            //hdn_agentid.Value = custobj.GetCustomerid(txt_agent.Text.Trim()).ToString();
                            DataTable dt = new DataTable();
                            dt = custobj.GetexactCustomer(txt_agent.Text.Trim().ToUpper(), "P");
                            if (dt.Rows.Count == 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Agent');", true);
                                blnerr = true;
                                txt_agent.Focus();

                                return;

                            }

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Agent Should not Be Empty');", true);
                        blnerr = true;
                        txt_agent.Focus();

                        return;
                    }
                }

                if (StrTranType == "FE")
                {
                    if (txt_agent.Text.Trim() != "" && hdn_Business.Value == "A")
                    {
                        if ((hdn_agentid.Value == "" || hdn_agentid.Value == "0"))
                        {
                            //hdn_agentid.Value = custobj.GetCustomerid(txt_agent.Text.Trim()).ToString();
                            // if (hdn_agentid.Value == "" && hdn_Business.Value == "A")
                            DataTable dt = new DataTable();
                            dt = custobj.GetexactCustomer(txt_agent.Text.Trim().ToUpper(), "P");
                            if (dt.Rows.Count == 0 && hdn_Business.Value == "A")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Agent Shouldnt Be Empty or Enter Valid Agent');", true);
                                blnerr = true;
                                txt_agent.Focus();

                                return;
                            }
                            if (hdn_agentid.Value == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Agent');", true);
                                blnerr = true;
                                txt_agent.Focus();

                                return;

                            }

                        }
                    }
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Agent Should not Be Empty');", true);
                    //    blnerr = true;
                    //    txt_agent.Focus();

                    //    return;
                    //}


                    DataTable dtfact = new DataTable();
                    if (hdn_agentid.Value != "")
                    {
                        dtfact = bookingobj.SPGETCustid4factory(Convert.ToInt32(hdn_agentid.Value));//for check DAVIES TURNER Agent
                    }
                    if (dtfact.Rows.Count > 0)
                    {
                        if (dtfact.Rows[0][0].ToString() != "0")
                        {
                            if (txtFactory.Text.Trim() != "")
                            {


                                if (hid_factory.Value == "0")
                                {
                                    //hid_factory.Value = (custobj.GetCustomerid(txtFactory.Text)).ToString();
                                    //if (hid_factory.Value == "0")
                                    DataTable dt = new DataTable();
                                    dt = custobj.GetexactCustomer(txtFactory.Text.Trim().ToUpper(), "C");
                                    if (dt.Rows.Count == 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Enter The Valid Factory');", true);
                                        blnerr = true;
                                        return;
                                    }
                                }
                                //else
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Factory should not be Empty');", true);
                                //    blnerr = true;
                                //    txtFactory.Focus();
                                //    return;
                                //}

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Factory should not be Empty');", true);
                                blnerr = true;
                                txtFactory.Focus();
                                return;
                            }


                        }
                    }


                }

                if (btnSave.ToolTip == "Save")
                {
                    if (chkBox.Checked == true)
                    {
                        if (dtTable.Rows.Count > 0)
                        {
                            this.PopUpCBox.Show();
                        }
                    }
                }


                if (StrTranType == "FE")
                {
                    if (hdn_agentid.Value == "" && hdn_Business.Value == "A")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Agent Shouldnt Be Empty or Enter Valid Agent');", true);
                        blnerr = true;
                        txt_agent.Focus();

                        return;
                    }
                }
                if (hdn_shipperid.Value == "")
                {
                    hdn_shipperid.Value = "0";
                }
                else if (hdn_Consigneeid.Value == "")
                {
                    hdn_Consigneeid.Value = "0";
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void BindGrid(int rowcount, string txtname, string custtype)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add(new System.Data.DataColumn("email", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("Cname", typeof(String)));

                if (ViewState["CurrentData"] != null)
                {

                    //ImageButton btndelete = new ImageButton();
                    //foreach (GridViewRow row in grdCMail.Rows)
                    //{

                    //    btndelete = (ImageButton)row.FindControl("ImageButton2");
                    //    btndelete.Visible = true;

                    //}
                    for (int i = 0; i < rowcount + 1; i++)
                    {
                        dt = (DataTable)ViewState["CurrentData"];

                        if (dt.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dt);
                            dv.RowFilter = "email = '" + txtname.ToString().ToUpper().Trim() + "'";
                            if (dv.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail id Already Exist');", true);
                                return;
                            }

                            dr = dt.NewRow();
                            dr[0] = dt.Rows[0][0].ToString();
                        }
                    }


                    dr = dt.NewRow();
                    dr[0] = txtname;
                    dr[1] = custtype;

                    dt.Rows.Add(dr);

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = txtname;
                    dr[1] = custtype;

                    dt.Rows.Add(dr);

                }


                if (ViewState["CurrentData"] != null)
                {
                    grdCMail.DataSource = (DataTable)ViewState["CurrentData"];
                    grdCMail.DataBind();
                }
                else
                {
                    grdCMail.DataSource = dt;
                    grdCMail.DataBind();

                }

                ViewState["CurrentData"] = dt;

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnSAdd_Click(object sender, EventArgs e)
        {
            //if (txt_shippermail.Text != "")
            //{              
            //    if ((IsValidEmailId(txt_shippermail.Text)))
            //    {
            //        if (ViewState["CurrentData"] != null)
            //        {
            //            DataTable dt = (DataTable)ViewState["CurrentData"];
            //            int count = dt.Rows.Count;
            //            BindGrid(count, txt_shippermail.Text.ToUpper(), "SHIPPER");
            //        }
            //        else
            //        {
            //            BindGrid(1, txt_shippermail.Text.ToUpper(), "SHIPPER");
            //        }

            //        txt_shippermail.Text = "";
            //        txt_shippermail.Focus();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Email Format');", true);
            //        return;
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
            //    return;
            //}

        }

        protected void btnCadd_Click(object sender, EventArgs e)
        {
            //if (txt_Consigneemail.Text != "")
            //{                
            //    if (IsValidEmailId(txt_Consigneemail.Text))
            //    {
            //        if (ViewState["CurrentData"] != null)
            //        {
            //            DataTable dt = (DataTable)ViewState["CurrentData"];
            //            int count = dt.Rows.Count;
            //            BindGrid(count, txt_Consigneemail.Text.ToUpper(), "CONSIGNEE");
            //        }
            //        else
            //        {
            //            BindGrid(1, txt_Consigneemail.Text.ToUpper(), "CONSIGNEE");
            //        }
            //        txt_Consigneemail.Text = "";
            //        txt_Consigneemail.Focus();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Email Format');", true);
            //        return;
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
            //    return;
            //}

        }

        protected void btnOadd_Click(object sender, EventArgs e)
        {
            //if (txt_othersMail.Text != "")
            //{
            //    if (IsValidEmailId(txt_othersMail.Text))
            //    {
            //        if (ViewState["CurrentData"] != null)
            //        {
            //            DataTable dt = (DataTable)ViewState["CurrentData"];
            //            int count = dt.Rows.Count;
            //            BindGrid(count, txt_othersMail.Text.ToUpper(), "OTHERS");
            //        }
            //        else
            //        {
            //            BindGrid(1, txt_othersMail.Text.ToUpper(), "OTHERS");
            //        }
            //        txt_othersMail.Text = "";
            //        txt_othersMail.Focus();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Email Format');", true);
            //        return;
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
            //    return;
            //}
        }

        protected void txt_quatation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //StrTranType = Session["StrTranType"].ToString();
                int intquotid = Convert.ToInt32(txt_quatation.Text);
                DataTable Dt = new DataTable();
                if (txt_quatation.Text != "")
                {

                    ///grdfill();

                    Dt = bookingobj.QuotGrdDetails(StrTranType, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    int icount = 0;

                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        int b = Convert.ToInt32(Dt.Rows[i][0].ToString());
                        if (b == intquotid)
                        {
                            icount = 1;
                            i = Dt.Rows.Count + 1;
                        }
                        else { icount = 0; }
                    }
                    if (icount == 1)
                    {
                        icount = 0;

                        dtBooking = quotobj.GetQuotationDetails(Convert.ToInt32(txt_quatation.Text), "", Convert.ToInt32(Session["LoginBranchid"]));

                        if (dtBooking.Rows.Count > 0)
                        {
                            string product = dtBooking.Rows[0]["trantype"].ToString();
                            if (product == "OE")
                            {
                                Session["StrTranType"] = "FE";
                                StrTranType = Session["StrTranType"].ToString();
                                ddl_product.Text = "OCEAN EXPORTS";
                            }
                            else if (product == "OI")
                            {
                                Session["StrTranType"] = "FI";
                                StrTranType = Session["StrTranType"].ToString();
                                ddl_product.Text = "OCEAN IMPORTS";
                            }
                            else if (product == "AE")
                            {
                                Session["StrTranType"] = "AE";
                                StrTranType = Session["StrTranType"].ToString();
                                ddl_product.Text = "AIR EXPORTS";
                            }
                            else if (product == "AI")
                            {
                                Session["StrTranType"] = "AI";
                                StrTranType = Session["StrTranType"].ToString();
                                ddl_product.Text = "AIR IMPORTS";
                            }
                            if (Session["StrTranType"] != null)
                            {
                                if (Session["StrTranType"].ToString() == "FE")
                                {
                                    HeaderLabel1.InnerText = "OceanExports";
                                    dts = objship.Getsbno();
                                    checkview.DataSource = dts;
                                    checkview.DataBind();
                                }
                                else if (Session["StrTranType"].ToString() == "FI")
                                {
                                    HeaderLabel1.InnerText = "OceanImports";
                                }
                                else if (Session["StrTranType"].ToString() == "AE")
                                {
                                    HeaderLabel1.InnerText = "AirExports";
                                }
                                else if (Session["StrTranType"].ToString() == "AI")
                                {
                                    HeaderLabel1.InnerText = "AirImports";
                                }
                            }
                            hdn_quotid.Value = txt_quatation.Text;
                            hdn_Business.Value = dtBooking.Rows[0]["business"].ToString();
                            //dtquotdate.Text = dtBooking.Rows[0]["quotdate"].ToString();
                            //dtquotdate.Text = Utility.fn_ConvertDate(dtBooking.Rows[0]["quotdate"].ToString());
                            dtquotdate.Text = DateTime.Parse(dtBooking.Rows[0]["quotdate"].ToString()).ToString("dd-MMM-yyyy");
                            dtExpiredOn.Enabled = false;
                            dtExpiredOn.Text = DateTime.Parse(dtBooking.Rows[0]["validtill"].ToString()).ToString("dd-MMM-yyyy");
                            //dtExpiredOn.Text = Utility.fn_ConvertDate(dtBooking.Rows[0]["validtill"].ToString());
                            // dtExpiredOn.Text = dtBooking.Rows[0]["validtill"].ToString();
                            hd_cusid.Value = dtBooking.Rows[0]["customerid"].ToString();
                            hd_controll.Value= dtBooking.Rows[0]["business"].ToString();
                            if (hd_controll.Value == "O")
                            {
                                txt_controll.Text = "Controlled By Us";
                            }
                            else
                            {
                                txt_controll.Text = "Agent Controlled";
                            }
                            int cargoid = Convert.ToInt32(dtBooking.Rows[0]["cargoid"].ToString());
                            intShipment = dtBooking.Rows[0]["stype"].ToString();
                            // add by yuvaraj 27/12/2022
                            if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI")
                            {
                                if (intShipment == "L")
                                {
                                    txt_vol.Attributes.Add("placeholder", "CBM");
                                }
                                else if (intShipment == "F")
                                {
                                    txt_vol.Attributes.Add("placeholder", "TUES");
                                }
                            }
                            else if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                            {
                                txt_vol.Attributes.Add("placeholder", "KGS");
                            }
                            strfstatus = dtBooking.Rows[0]["fstatus"].ToString();
                            intsales = dtBooking.Rows[0]["marketedby"].ToString();
                            //lbl.Visible = true;
                            txtMarketby.Text = "";
                            txtMarketby.Text = empobj.GetEmployeeName(Convert.ToInt32(intsales));
                            intpor = dtBooking.Rows[0]["por"].ToString();
                            intpol = dtBooking.Rows[0]["pol"].ToString();
                            intpod = dtBooking.Rows[0]["pod"].ToString();
                            intfd = dtBooking.Rows[0]["fd"].ToString();
                            intcustid = dtBooking.Rows[0]["customerid"].ToString();
                            string data = dtBooking.Rows[0]["shipperid"].ToString();
                            if (data != "")
                            {
                                hdn_shipperid.Value = dtBooking.Rows[0]["shipperid"].ToString();
                                txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(dtBooking.Rows[0]["shipperid"].ToString()));
                                txt_qcustomer.Text = txt_shiper.Text;
                                txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtBooking.Rows[0]["shipperid"].ToString()));

                            }

                            string datainco = dtBooking.Rows[0]["inco"].ToString();
                            if (datainco != "")
                            {
                                hdn_Incoid.Value = dtBooking.Rows[0]["inco"].ToString();

                                DataTable dtinco = new DataTable();
                                dtinco = bookingobj.SelMasterInco(Convert.ToInt32(hdn_Incoid.Value));
                                if (dtinco.Rows.Count > 0)
                                {
                                    txtInco.Text = dtinco.Rows[0]["incocode"].ToString();
                                }
                            }


                            //DataAccess.Masters.MasterPort objpot = new DataAccess.Masters.MasterPort();
                            int countryid = objpot.sp_countryidprt(Convert.ToInt32(intpor));
                            if (countryid.ToString() != "10")
                            {
                                countryid = objpot.sp_countryidprt(Convert.ToInt32(intpol));
                                if (countryid.ToString() != "10")
                                {
                                    countryid = objpot.sp_countryidprt(Convert.ToInt32(intpod));
                                    if (countryid.ToString() != "10")
                                    {
                                        countryid = objpot.sp_countryidprt(Convert.ToInt32(intpod));
                                        if (countryid.ToString() == "10")
                                        {
                                            Session["approved"] = "N";
                                        }
                                        else
                                        {
                                            Session["approved"] = "Y";
                                        }
                                    }
                                    else
                                    {
                                        Session["approved"] = "N";
                                    }
                                }
                                else
                                {
                                    Session["approved"] = "N";
                                }


                            }
                            else
                            {
                                Session["approved"] = "N";
                            }

                            txtQRemarks.Text = dtBooking.Rows[0]["remarks"].ToString();
                            txt_custpono.Text = dtBooking.Rows[0]["cuspono"].ToString();
                            // txtBRemarks.Text = dtBooking.Rows[0]["remarks"].ToString();
                            txt_cargo.Text = cargoobj.GetCargoname(Convert.ToInt32(cargoid));
                            txt_por.Text = portobj.GetPortname(Convert.ToInt32(intpor));

                            /*string portcode;
                            portcode = portobj.GetPortCodefrmPort(Convert.ToInt32(intpor));

                            if (portcode.Length == 3)
                            {
                                hid_PoRportcode.Value = portcode;
                            }
                            else if (portcode.Length >= 5)
                            {
                                hid_PoRportcode.Value = portcode.Substring(2, 3);
                            }
                            else
                            {
                                hid_PoRportcode.Value = "";
                            }*/


                            txt_pol.Text = portobj.GetPortname(Convert.ToInt32(intpol));
                            txt_pod.Text = portobj.GetPortname(Convert.ToInt32(intpod));
                            txt_fd.Text = portobj.GetPortname(Convert.ToInt32(intfd));
                            txt_qcustomer.Text = custobj.GetCustomername(Convert.ToInt32(intcustid));
                            if (intShipment == "L")
                            {
                                txtshipment.Text = "LCL";
                                lbl_voll.Text = "CBM";
                            }
                            else if (intShipment == "F")
                            {
                                txtshipment.Text = "FCL";
                                lbl_voll.Text = "Teus";
                            }
                            if (strfstatus == "P")
                            {
                                txtfreight.Text = "Prepaid";
                            }
                            //else if (strfstatus == "C")
                            //{
                            //    txtfreight.Text = "Tocollect";
                            //}

                            if (strfstatus == "C")
                            {
                                if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                                {
                                    txtfreight.Text = "collect";
                                }
                                else
                                {
                                    txtfreight.Text = "collect";
                                }

                            }
                            //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
                            dt = obj_MasterPort.SelPortName4typepadimg(txt_fd.Text.ToUpper(), Session["StrTranType"].ToString());
                            fdflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                            dt = obj_MasterPort.SelPortName4typepadimg(txt_por.Text.ToUpper(), Session["StrTranType"].ToString());
                            porflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                            dt = obj_MasterPort.SelPortName4typepadimg(txt_pod.Text.ToUpper(), Session["StrTranType"].ToString());
                            podflag.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                            dt = obj_MasterPort.SelPortName4typepadimg(txt_pol.Text.ToUpper(), Session["StrTranType"].ToString());
                            flagimg.ImageUrl = "../LOGO/" + dt.Rows[0]["countrycode"] + ".svg";

                            if (txt_vol.Text == "")
                            {
                                txt_vol.Text = "";
                            }
                            txt_booking.Text = "";

                             btnSave.Text = "Save";
                            btnSave.ToolTip = "Save";
                            btn_save1.Attributes["class"] = "btn ico-save";
                             btnCancel.Text = "Cancel";

                            btnCancel.ToolTip = "Cancel";
                            btn_cancel1.Attributes["class"] = "btn ico-cancel";
                            //txtunable();
                            grdfill();
                            if (blnerr == true)
                            {
                                return;
                            }

                            dtTable = custobj.Getsop(Convert.ToInt32(intcustid));

                            if (dtTable.Rows.Count > 0)
                            {
                                chkBox.Enabled = true;
                                lbtnSop.Enabled = true;
                                lbtnSop1.Attributes["class"] = "SOP";
                            }
                            else
                            {
                                chkBox.Enabled = false;
                                lbtnSop.Enabled = false;
                                lbtnSop1.Attributes["class"] = "lbtnSop1";
                            }
                            ViewState["dtTable"] = dtTable;
                            dtBuying = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txt_quatation.Text), StrTranType, Convert.ToInt32(Session["LoginBranchid"]), "QB");
                            if (dtBuying.Rows.Count > 0)
                            {
                                //rateid = Convert.ToInt32(dtBuying.Rows[0]["buyingno"].ToString());
                                //dtvalid = bookingobj.SELECTRateValidTill(rateid);
                                //txt_validtill.Text = Utility.fn_ConvertDate(dtvalid.Rows[0]["validtill"].ToString());
                                txtBuying.Text = dtBuying.Rows[0]["buyingno"].ToString();
                                dtrateid = buyingobj.SelectBuyingHeadAll(Convert.ToInt32(txtBuying.Text));
                                if (dtrateid.Rows.Count > 0)
                                {
                                    bfreight = dtrateid.Rows[0]["freight"].ToString();
                                    txt_validtill.Text = Utility.fn_ConvertDate(dtrateid.Rows[0]["validtill"].ToString());
                                    //txtBRemarks.Text = dtrateid.Rows[0]["remarks"].ToString();
                                }
                                grdBuyingfill();
                            }

                            if (StrTranType == "FI" || StrTranType == "AI")
                            {
                                intcustid = dtBuying.Rows[0]["customerid"].ToString();
                                hdn_Consigneeid.Value = dtBuying.Rows[0]["customerid"].ToString();

                                txt_consignee.Text = custobj.GetCustomername(Convert.ToInt32(intcustid));

                                txt_consigneemulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(intcustid));

                                DataTable dtmail = new DataTable();
                                string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                                if (Shipmail != "")
                                {
                                    dtmail = new DataTable();
                                    dtmail.Columns.Add("email");
                                    dtmail.Columns.Add("Cname");
                                    dtmail.Rows.Add(Shipmail, "Consignee");
                                    grdCMail.DataSource = dtmail;
                                    grdCMail.DataBind();
                                    ViewState["CurrentData"] = dtmail;
                                }
                            }
                            else
                            {
                                hdn_shipperid.Value = dtBuying.Rows[0]["customerid"].ToString();
                                txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));
                                txt_qcustomer.Text = txt_shiper.Text;
                                txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));
                                DataTable dtmail = new DataTable();
                                string Shipmail = custobj.GetCusMailaddrs(Convert.ToInt32(dtBuying.Rows[0]["customerid"].ToString()));

                                if (Shipmail != "")
                                {
                                    dtmail = new DataTable();
                                    dtmail.Columns.Add("email");
                                    dtmail.Columns.Add("Cname");
                                    dtmail.Rows.Add(Shipmail, "Shipper");
                                    grdCMail.DataSource = dtmail;
                                    grdCMail.DataBind();
                                    ViewState["CurrentData"] = dtmail;
                                }

                            }
                            if (StrTranType == "AE" || StrTranType == "AI")
                            {
                                txtshipment.Text = "";
                                lbl_voll.Text = "Kgs";
                            }

                            txt_shiper.Focus();

                        }
                        // add by yuvaraj 27/12/2022
                        DataTable dtcbm = new DataTable();
                        dtcbm = quotobj.GETTUESCBMVALUE(Convert.ToInt32(txt_quatation.Text), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), intShipment);
                        if (dtcbm.Rows.Count > 0)
                        {
                            if (!String.IsNullOrEmpty(dtcbm.Rows[0]["Tues"].ToString()))
                            {
                                txt_vol.Text = dtcbm.Rows[0]["Tues"].ToString();

                            }
                        }

                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This Quotation number is not Yet Approved!');", true);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Quotation Unavailable');", true);
                        txt_quatation.Text = "";
                        txt_quatation.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txt_quatation.Text = "";
                txt_quatation.Focus();

            }
        }
        private bool IsValidEmailId(string InputEmail)
        {
            //Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            //Match match = regex.Match(InputEmail);
            //if (match.Success)
            //    return true;
            //else
            //    return false;
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
        protected void btnSave_Click1(object sender, EventArgs e)
        {

            try
            {
                string portcode = "";
                //DataAccess.Documents Objdoc = new DataAccess.Documents();

                //DataAccess.ForwardingExports.PODetails obj_da_Podetails = new DataAccess.ForwardingExports.PODetails();

                DataTable dtnew = new DataTable();
                //DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();
                //DataAccess.Marketing.Quotation quotation = new DataAccess.Marketing.Quotation();



                DataTable dt = new DataTable();
                


                string shortname = "";
                shortname = Objdoc.GetShortname(Convert.ToInt32(Session["LoginBranchid"]));

                string sbno = "";
                string usermail = "", empmailadd = "", custmail = "";
                if (ddl_product.Text == "OCEAN EXPORTS")
                {
                    Session["StrTranType"] = "FE";
                    StrTranType = "FE";
                }
                else if (ddl_product.Text == "OCEAN IMPORTS")
                {
                    Session["StrTranType"] = "FI";
                    StrTranType = "FI";
                }
                else if (ddl_product.Text == "AIR EXPORTS")
                {
                    Session["StrTranType"] = "AE";
                    StrTranType = "AE";
                }
                else if (ddl_product.Text == "AIR IMPORTS")
                {
                    Session["StrTranType"] = "AI";
                    StrTranType = "AI";
                }
                else
                {
                    Session["StrTranType"] = null;
                    StrTranType = "";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Product');", true);
                    blnerr = true;
                    ddl_product.Focus();
                    return;
                }

                /*  if (hid_PoRportcode.Value == "")
                  {
                      ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('PoR - Port code not updated in Master.');", true);
                      blnerr = true;
                      return;
                  }*/
                checkdata();
                //  txt_shiper_TextChanged(sender, e);
                //  if (StrTranType == "FE")
                //  {
                //  txt_consignee_TextChanged(sender, e);
                //  }
                txt_agent_TextChanged(sender, e);
                //  txtInco_TextChanged(sender, e);
                if (blnerr == true)
                {
                    blnerr = false;
                    return;
                }
                if (hid_factory.Value == "")
                {
                    hid_factory.Value = "0";
                }

                //------------------------------------------------------------------------------------------------------------------------------------
                dt = quotation.GetCustomerDetailFromTask(Convert.ToInt32(hd_cusid.Value), Session["StrTranType"].ToString());
                if (hd_controll.Value == "O")
                {
                    if (dt.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnSave, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Task Details Not Update for the quotation customer kindly update in master')", true);
                        return;
                    }
                }
                //    ----------------------------------------------------------------------------------------------------------------------------------








                dtnew = cus.getcustomerblk(Convert.ToInt32(hdn_shipperid.Value));
                if (dtnew.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txt_shiper.Text + " status is Hold please discuss with Finance team ');", true);
                    txt_shiper.Text = "";
                    txt_shiper.Focus();

                    return;
                }
                dtnew = cus.getcustomerblk(Convert.ToInt32(hdn_Consigneeid.Value));
                if (dtnew.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txt_consignee.Text + " status is Hold please discuss with Finance team ');", true);
                    txt_consignee.Text = "";
                    txt_consignee.Focus();

                    return;
                }



                if (btnSave.ToolTip == "Save")
                {

                    if (txt_booking.Text != "")
                    {
                        return;
                    }
                    if (StrTranType == "FE" || StrTranType == "FI")
                    {
                        if (txtshipment.Text == "FCL")
                        {
                            if (GrdBuying.Rows.Count < 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Buying Rate Should be Mandatory');", true);
                                return;
                            }
                        }
                    }




                    //hid_PoRportcode.Value = portcode.Substring(2, 3);
                    if (Session["LoginBranchid"] != null)
                    {
                        portcode = portobj.GetPortCodeportid(Convert.ToInt32(Session["LoginBranchid"]));
                        portcode = portcode.Substring(2, 3);
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Master Branch not updated');", true);
                        return;
                    }


                    if (txt_vol.Text.Trim() != "" && txt_por.Text.Trim() != "" && txt_pod.Text.Trim() != "" && txt_booking.Text.Trim() == "")
                    {
                        string srefno = "";

                        if (txt_agent.Text.Trim() != "" && hdn_agentid.Value != "")
                        {
                            // InsertFIBookingDetailsNew
                            // srefno = bookingobj.InsertFIBookingDetailsNewBook(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, shortname.ToUpper(),hid_PoRportcode.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value));
                            //srefno = bookingobj.InsertFIBookingDetailsNewBook(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), Session["LoginBranchName"].ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value));

                            if (hid_bookingstatus.Value == "N")
                            {
                                if (hidbookingno.Value != "")
                                {

                                    srefno = bookingobj.InsertFIBookingDetailsNewBookebbookingno(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), portcode.ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value), hidbookingno.Value, Convert.ToInt32(hidbookno.Value));
                                    obj_da_Podetails.spupdatebookingstatus(hidbookingno.Value, "N", Convert.ToInt32(Session["LoginBranchid"]));

                                    hidbookingno.Value = "";
                                }
                            }
                            else
                            {
                                srefno = bookingobj.InsertFIBookingDetailsNewBook(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), portcode.ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value));
                            }
                            //bookingobj.Instaskbooking(Convert.ToInt32(Session["LoginBranchid"]), hidbookingno.Value, StrTranType);

                        }
                        else
                        {
                            if (StrTranType != "FI")
                            {
                                // srefno = bookingobj.InsertBookingDetailsNew(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, shortname.ToUpper(), hid_PoRportcode.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper());

                                //srefno = bookingobj.InsertBookingDetailsNew(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), Session["LoginBranchName"].ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper());

                                if (hid_bookingstatus.Value == "N")
                                {
                                    if (hidbookingno.Value != "")
                                    {
                                        srefno = bookingobj.InsertBookingDetailsNewebooking(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), portcode.ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), hidbookingno.Value, Convert.ToInt32(hidbookno.Value));
                                        obj_da_Podetails.spupdatebookingstatus(hidbookingno.Value, "N", Convert.ToInt32(Session["LoginBranchid"]));

                                        hidbookingno.Value = "";
                                        hidbookno.Value = "";
                                    }

                                }
                                {
                                    srefno = bookingobj.InsertBookingDetailsNew(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), portcode.ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper());
                                }
                                //bookingobj.Instaskbooking(Convert.ToInt32(Session["LoginBranchid"]), srefno, StrTranType);
                            }
                            else
                            {
                                // srefno = bookingobj.InsertFIBookingDetailsNewBook(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, shortname.ToUpper(), hid_PoRportcode.Value.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value));
                                //srefno = bookingobj.InsertFIBookingDetailsNewBook(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), Session["LoginBranchName"].ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value));


                                if (hid_bookingstatus.Value == "N")
                                {
                                    if (hidbookingno.Value != "")
                                    {

                                        srefno = bookingobj.InsertFIBookingDetailsNewBookebbookingno(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), portcode.ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value), hidbookingno.Value, Convert.ToInt32(hidbookno.Value));
                                        obj_da_Podetails.spupdatebookingstatus(hidbookingno.Value, "N", Convert.ToInt32(Session["LoginBranchid"]));

                                        hidbookingno.Value = "";
                                        hidbookno.Value = "";
                                    }
                                }

                                else
                                {
                                    srefno = bookingobj.InsertFIBookingDetailsNewBook(Convert.ToInt32(hdn_quotid.Value), Convert.ToSingle(txt_vol.Text), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), StrTranType, Session["LoginDivisionName"].ToString().ToUpper(), portcode.ToString().ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim().ToUpper(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value));
                                }
                                //bookingobj.Instaskbooking(Convert.ToInt32(Session["LoginBranchid"]), hidbookingno.Value, StrTranType);
                            }
                        }
                        bookingobj.Instaskbooking(Convert.ToInt32(Session["LoginBranchid"]), srefno, StrTranType);
                        CorpObj.InsShipmentStatus(srefno.ToUpper(), StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        CorpObj.UpdShipmentStatus(srefno.ToUpper(), StrTranType, Convert.ToInt32(Session["LoginBranchid"]), "Booked");
                        portobj.Updapprovedport(srefno.ToUpper(), Session["approved"].ToString());
                        txt_booking.Text = srefno;

                        if (txtBuying.Text != "" && GrdBuying.Rows.Count > 0)
                        {
                            bookingobj.InsertBuyingNo(srefno.ToUpper(), Convert.ToInt32(txtBuying.Text), Convert.ToInt32(Session["LoginBranchid"]));

                        }
                        InsBookingDetails(srefno.ToUpper());
                        InsBuyingBookingDetails(srefno.ToUpper());
                        // yuvaraj 
                        bookingobj.InsBookingBack(srefno.ToUpper(), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), Convert.ToSingle(txt_vol.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        dtBooking = bookingobj.GetBookingdtlsNew(txt_booking.Text, StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        if (StrTranType == "FE")
                        {
                            if (dtBooking.Rows.Count > 0)
                            {
                                hd_book.Value = dtBooking.Rows[0][12].ToString();
                                if (hd_book.Value == "0" || hd_book.Value == "")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Something went wrong while Shipping Bill Update');", true);
                                }
                            }
                            for (int i = 0; i <= checkview.Rows.Count - 1; i++)
                            {
                                CheckBox chkRow = (checkview.Rows[i].Cells[1].FindControl("checksbno") as CheckBox);
                                if (chkRow.Checked == true)
                                {
                                    sbno = checkview.Rows[i].Cells[0].Text;
                                    objship.GetUpdShipRefNo(Convert.ToInt32(hd_book.Value), sbno);
                                }
                                else
                                {
                                    sbno = checkview.Rows[i].Cells[0].Text;
                                    objship.GetUpdShipRefNo(0, sbno);
                                }
                            }
                        }

                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                //fejobobj.UpdateFEEventShiprefno(srefno, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/S");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 11, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/S");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 12, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/S");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 13, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/S");
                                break;
                        }
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Details Saved.\\n\\ New Booking # is  : " + txt_booking.Text + "');", true);


                     //   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Details Saved.\\n\\ New Booking  " + srefno + "'Generated);", true);
                          btnSave.Text = "Update";

                        btnSave.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                    }
                    GetCompanyName();
                    usermail = hrempobj.GetMailAdd(hrempobj.GetEmpId(Session["LoginUserName"].ToString()));
                    dtBooking = userperobj.GetMLEmpid(userperobj.GetMLUiid(Session["StrTranType"].ToString(), "Booking"), Convert.ToInt32(Session["LoginBranchid"]));

                    //if (Session["usermailid"].ToString() == "" || Session["mailpwd"].ToString() == "")
                    //  {
                    //      ScriptManager.RegisterStartupScript(this, typeof(Button), "UserName", "alertify.alert('Update Email ID and Password');", true);
                    //      return;
                    //  }


                    for (i = 0; i <= dtBooking.Rows.Count - 1; i++)
                    {
                        empmailadd = empmailadd + hrempobj.GetMailAdd(Convert.ToInt32(dtBooking.Rows[i][0].ToString())) + ";";
                        // hrempobj.GetMailAdd(dtBooking.Rows[i][0].ToString()) + ";";
                    }
                    if (empmailadd != "")
                    {

                        empmailadd = empmailadd.Substring(0, empmailadd.Length - 1);
                        Utility.SendMail(usermail, empmailadd, "Booking # : " + txt_booking.Text, sendqry, "", Session["usermailpwd"].ToString(), "", "");
                    }
                    GetCompanyNameWCoustomer();

                    custmail = custobj.GetCusMailaddrs(Convert.ToInt32(hdn_shipperid.Value));
                    if (custmail != "")
                    {
                        custmail = custmail.Substring(0, custmail.Length - 1);
                        if (custmail != "")
                        {
                            Utility.SendMail(usermail, custmail, "Booking # : " + txt_booking.Text, sendqry, "", Session["usermailpwd"].ToString(), "", "");
                        }
                    }

                    viewcheckgrd();
                }
                else if (btnSave.ToolTip == "Update")
                {
                    if (txt_vol.Text != "")
                    {
                        if (txt_agent.Text.Trim() != "" && hdn_agentid.Value != "")
                        {
                            bookingobj.UpdateFIBookingDetailsNewBook(Convert.ToSingle(txt_vol.Text), txt_booking.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value));

                        }
                        else
                        {
                            if (StrTranType == "FI")
                            {
                                bookingobj.UpdateFIBookingDetailsNewBook(Convert.ToSingle(txt_vol.Text), txt_booking.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim(), Convert.ToInt32(hdn_agentid.Value), Convert.ToInt32(hid_factory.Value));
                            }
                            else
                            {
                                bookingobj.UpdateBookingDetailsNew(Convert.ToSingle(txt_vol.Text), txt_booking.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hdn_Incoid.Value), Convert.ToInt32(hdn_shipperid.Value), Convert.ToInt32(hdn_Consigneeid.Value), txtBRemarks.Text.Trim());
                            }

                        }
                        InsBookingDetails(txt_booking.Text);
                        InsBuyingBookingDetails(txt_booking.Text);
                        bookingobj.UPDBookingBack(txt_booking.Text.Trim().ToUpper(), Convert.ToDateTime(dtDate.Text + " " + DateTime.Now.ToLongTimeString()), Convert.ToSingle(txt_vol.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                        if (StrTranType == "FE")
                        {
                            dtBooking = bookingobj.GetBookingdtlsNew(txt_booking.Text, StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            if (dtBooking.Rows.Count > 0)
                            {
                                hd_book.Value = dtBooking.Rows[0][12].ToString();
                                if (hd_book.Value == "0" || hd_book.Value == "")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Something went wrong while Shipping Bill Update');", true);
                                }
                            }
                            for (int i = 0; i <= checkview.Rows.Count - 1; i++)
                            {
                                CheckBox chkRow = (checkview.Rows[i].Cells[1].FindControl("checksbno") as CheckBox);
                                if (chkRow.Checked == true)
                                {
                                    sbno = checkview.Rows[i].Cells[0].Text;
                                    objship.GetUpdShipRefNo(Convert.ToInt32(hd_book.Value), sbno);
                                }
                                else
                                {
                                    sbno = checkview.Rows[i].Cells[0].Text;
                                    objship.GetUpdShipRefNo(0, sbno);
                                }
                            }
                        }

                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/U");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 11, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/U");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 12, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/U");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 13, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/U");
                                break;
                        }
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Details Updated.\\n\\ Booking # is  : " + txt_booking.Text + "');", true);

                    }
                    viewcheckgrd();

                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void GetCompanyName()
        {
            try
            {
                string custtype, straddress;
                string strcity;
                double rate;
                DataTable dt = new DataTable();
                //DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
                string zipcode;
                dtBooking = Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"]));
                if (dtBooking.Rows.Count > 0)
                {
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "AE")
                    {
                        custtype = "C";
                    }
                    else
                    {
                        custtype = "C";

                    }
                    strcust = Cusobj.GetCustomername(Convert.ToInt32(hdn_shipperid.Value));
                    strcity = Cusobj.GetCustlocation(Convert.ToInt32(hdn_shipperid.Value));
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "AE")
                    {
                        custtype = "Shipper";
                    }
                    else
                    {
                        custtype = "Consignee";

                    }

                    dt = new DataTable();
                    dt = Cusobj.RetrieveCustomerDetails(strcust, custtype, strcity);
                    if (dt.Rows.Count > 0)
                    {
                        straddress = dt.Rows[0]["address"].ToString();
                        zipcode = dt.Rows[0]["zip"].ToString();
                    }
                    sendqry = Utility.Fn_GetCompanyAddress();
                    sendqry = sendqry + "</br>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Dear Sir / Madam ,</td></tr></font></table><br>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>New Booking #  " + txt_booking.Text + " Dt. " + dtDate.Text + " has generated for the below quotation. </td></tr></font></table>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Customer : " + txt_qcustomer.Text + "</td></tr><br>";
                    sendqry = sendqry + "<tr><td align=left>Quotation # : " + txt_quatation.Text + " Dt : " + dtquotdate.Text + "</td></tr>";
                    sendqry = sendqry + "<tr><td align=left>Cargo Type  : " + txt_cargo.Text + "</td></tr>";

                    sendqry = sendqry + "<tr><td align=left>Shipment : " + txtshipment.Text + "</td></tr>";
                    sendqry = sendqry + "<tr><td align=left>Freight : " + txtfreight.Text + "</td></tr></font></table>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>PoR : " + txt_por.Text + "</td><td align=left>PoL : " + txt_pol.Text + "</td><td align=left>PoD : " + txt_pod.Text + "</td><td align=left>FD : " + txt_fd.Text + "</td></tr></FONT></table><br>";
                    sendqry = sendqry + "<table><tr><td align=left>Sell Rate Details :</td></tr></font></table>";
                    sendqry = sendqry + "<table BORDER=1 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Charge Name</td><td align=center>Curr</td><td align=center>Rate</td><td align=center>Base</td><td align=center>Status</td></tr>";
                    string precol;
                    DataTable Dt = new DataTable();
                    Dt = quotobj.ChargeDetails(Convert.ToInt32(txt_quatation.Text), Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text.Trim());

                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        precol = bookingobj.GetBookingCharges(txt_booking.Text, Dt.Rows[i][0].ToString(), Dt.Rows[i][3].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                        if (precol == "C")
                        {
                            precol = "Collect";
                        }
                        else if (precol == "P")
                        {
                            precol = "PrePaid";
                        }

                        rate = Convert.ToDouble(Dt.Rows[i][2].ToString());
                        string rate1 = rate.ToString("#0.00");
                        sendqry = sendqry + "<tr><td align=left>" + Dt.Rows[i][0].ToString() + "</td><td align=left>" + Dt.Rows[i][1].ToString() + "</td><td align=right>" + rate1 + "</td><td align=left>" + Dt.Rows[i][3].ToString() + "</td><td align=left>" + precol + "</td></tr>";
                    }
                    sendqry = sendqry + "</table><br>";
                    if (txtBuying.Text != "")
                    {
                        string carrier = "";
                        dt = buyingobj.SelectBuyingHeadAll(Convert.ToInt32(txtBuying.Text));
                        if (dt.Rows.Count > 0)
                        {
                            carrier = dt.Rows[0]["customername"].ToString();
                        }
                        sendqry = sendqry + "<table><tr><td align=left>Buy Rate Details</td></tr><br>";
                        sendqry = sendqry + "<tr><td align=left>Carrier : " + carrier + "</td></tr></table><br>";
                        sendqry = sendqry + "<table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Charge Name</td><td align=center>Curr</td><td align=center>Rate</td><td align=center>Base</td><td align=center>Status</td></tr>";
                        dt = quotobj.ChargeBuyingDetails(Convert.ToInt32(txtBuying.Text), Convert.ToInt32(Session["LoginBranchid"]));
                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            if (Convert.ToDouble(dt.Rows[0][2].ToString()) > 0)
                            {
                                precol = bookingobj.GetBookingBuyingCharges(txt_booking.Text, dt.Rows[i][0].ToString(), dt.Rows[i][3].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                                if (precol == "C")
                                {
                                    precol = "Collect";
                                }
                                else if (precol == "P")
                                {
                                    precol = "PrePaid";
                                }
                                rate = Convert.ToDouble(dt.Rows[i][2].ToString());
                                string rate1 = rate.ToString("#0.00");
                                sendqry = sendqry + "<tr><td align=left>" + dt.Rows[i][0].ToString() + "</td><td align=left>" + dt.Rows[i][1].ToString() + "</td><td align=right>" + rate1 + "</td><td align=left>" + dt.Rows[i][3].ToString() + "</td><td align=left>" + precol + "</td></tr>";
                            }
                        }
                        sendqry = sendqry + "</table><br>";
                        dts = Cusobj.Getsop(Convert.ToInt32(hdn_shipperid.Value));
                        if (dts.Rows.Count > 0)
                        {
                            sendqry = sendqry + "<table><tr><td  align=left>Standard Operating Procedure Details</td></tr></table><br>";
                            sendqry = sendqry + "<table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0  WIDTH=100% text=black><tr><td align=center width=90%>Standard Operating Procedure</td><td align=center width=10%>Status</td></tr>";
                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                sendqry = sendqry + "<tr><td align=left width=90%>" + dts.Rows[i][0].ToString() + "</td><td align=left width=10% >" + dts.Rows[i][1].ToString() + "</td></tr>";
                            }
                            sendqry = sendqry + "</table><br>";
                        }

                    }
                    sendqry = sendqry + "</table><br>";
                    sendqry = sendqry + "<table width=100% text=black><tr><td align=left>Best Regards </td></tr></table><br><br>";
                    sendqry = sendqry + "<table width=100% text=black><tr><td align=left>" + empobj.GetEmployeeName(empobj.GetEmpid(HttpContext.Current.Session["LoginUserName"].ToString())) + " </td></tr></table></body></html>";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        public void GetCompanyNameWCoustomer()
        {
            try
            {
                string custtype, straddress;
                string strcity;
                double rate;
                DataTable dt = new DataTable();
                //DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
                string zipcode;
                dtBooking = Logobj.GetCompanyNameAdd(Convert.ToInt32(Session["LoginBranchid"]));
                if (dtBooking.Rows.Count > 0)
                {
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "AE")
                    {
                        custtype = "C";
                    }
                    else
                    {
                        custtype = "C";

                    }
                    strcust = Cusobj.GetCustomername(Convert.ToInt32(hdn_shipperid.Value));
                    strcity = Cusobj.GetCustlocation(Convert.ToInt32(hdn_shipperid.Value));
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "AE")
                    {
                        custtype = "Shipper";
                    }
                    else
                    {
                        custtype = "Consignee";

                    }

                    dt = new DataTable();
                    dt = Cusobj.RetrieveCustomerDetails(strcust, custtype, strcity);
                    if (dt.Rows.Count > 0)
                    {
                        straddress = dt.Rows[0]["address"].ToString();
                        zipcode = dt.Rows[0]["zip"].ToString();
                    }
                    sendqry = Utility.Fn_GetCompanyAddress();
                    sendqry = sendqry + "</br>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Dear Sir / Madam ,</td></tr></font></table><br>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>New Booking #  " + txt_booking.Text + " Dt. " + dtDate.Text + " has generated for the below quotation. </td></tr></font></table>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Customer : " + txt_qcustomer.Text + "</td></tr><br>";
                    sendqry = sendqry + "<tr><td align=left>Quotation # : " + txt_quatation.Text + " Dt : " + dtquotdate.Text + "</td></tr>";
                    sendqry = sendqry + "<tr><td align=left>Cargo Type  : " + txt_cargo.Text + "</td></tr>";

                    sendqry = sendqry + "<tr><td align=left>Shipment : " + txtshipment.Text + "</td></tr>";
                    sendqry = sendqry + "<tr><td align=left>Freight : " + txtfreight.Text + "</td></tr></font></table>";

                    DataTable Dt = new DataTable();
                    string ss = "Ex Works";
                    if (txtInco.Text.ToUpper() != ss.ToUpper())
                    {
                        sendqry = sendqry + "<table><tr><td align=left>Sell Rate Details :</td></tr></font></table>";
                        sendqry = sendqry + "<table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Charge Name</td><td align=center>Curr</td><td align=center>Rate</td><td align=center>Base</td><td align=center>Status</td></tr>";
                        string precol;
                        Dt = quotobj.ChargeDetailsGT0(Convert.ToInt32(txt_quatation.Text), Convert.ToInt32(Session["LoginBranchid"]));
                        for (i = 0; i <= Dt.Rows.Count - 1; i++)
                        {
                            if (Convert.ToDouble(Dt.Rows[0][2].ToString()) > 0)
                            {
                                precol = bookingobj.GetBookingBuyingCharges(txt_booking.Text, Dt.Rows[i][0].ToString(), Dt.Rows[i][3].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                                if (precol == "C")
                                {
                                    precol = "Collect";
                                }
                                else if (precol == "P")
                                {
                                    precol = "PrePaid";
                                }
                                rate = Convert.ToDouble(Dt.Rows[i][2].ToString());
                                string rate1 = rate.ToString("#0.00");
                                sendqry = sendqry + "<tr><td align=left>" + Dt.Rows[i][0].ToString() + "</td><td align=left>" + Dt.Rows[i][1].ToString() + "</td><td align=right>" + rate1 + "</td><td align=left>" + Dt.Rows[i][3].ToString() + "</td><td align=left>" + precol + "</td></tr>";
                            }
                        }
                        sendqry = sendqry + "</table><br>";
                    }



                    sendqry = sendqry + "<table width=100% text=black><tr><td align=left>Thanks for the above booking, we will come back to you shortly with Vessel Details </td></tr></table><br>";
                    sendqry = sendqry + "<table width=100% text=black><tr><td align=left>Best Regards </td></tr></table><br><br>";
                    sendqry = sendqry + "<table width=100% text=black><tr><td align=left>" + empobj.GetEmployeeName(empobj.GetEmpid(HttpContext.Current.Session["LoginUserName"].ToString())) + " </td></tr></table></body></html>";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        /*
    Public Sub GetCompanyNameWCoustomer()
        Dim custtype As String

        Dim strcity As String
        Dim straddress As String = ""
        Dim customerobj As New DataAccess.Masters.MasterCustomer
        Dim employeeobj As New DataAccess.Masters.MasterEmployee
        Dim dt As New DataTable
        Dim zipcode As String = ""
        dtBooking = Logobj.GetCompanyNameAdd(Login.branchid)
        If dtBooking.Rows.Count > 0 Then
            'txtcompanyname.Text = dtBooking.Rows(0).Item(0).ToString() & vbCrLf
            'txtcompanyadd.Text = dtBooking.Rows(0).Item(1).ToString() & vbCrLf
            'txtcompanyadd.Text = txtcompanyadd.Text & "Phone : " & dtBooking.Rows(0).Item(2).ToString() & "  Fax : " & dtBooking.Rows(0).Item(3).ToString() & vbCrLf
            'txtcompanyadd.Text = txtcompanyadd.Text & "Email : " & dtBooking.Rows(0).Item(4).ToString()
            If strtrantype = "FE" Or strtrantype = "AE" Then
                custtype = "C"
            Else
                custtype = "C"
            End If
            strcust = custobj.GetCustomername(intcustid)
            'intcustid = customerobj.GetCustomeridwcusttype(strcust, custtype)
            strcity = customerobj.GetCustlocation(intcustid)
            If strtrantype = "FE" Or strtrantype = "AE" Then
                custtype = "Shipper"
            Else
                custtype = "Consignee"
            End If
            dt = New DataTable
            dt = customerobj.RetrieveCustomerDetails(strcust, custtype, strcity)
            If dt.Rows.Count > 0 Then
                straddress = dt.Rows(0).Item("address").ToString()
                zipcode = dt.Rows(0).Item("zip").ToString()
            End If
            sendqry = Login.strcompanyaddress
            sendqry = sendqry & "<body text=black><table width=100%><FONT FACE=tahoma ><tr><td align=left>To</td></tr></br>"
            sendqry = sendqry & "<tr><td align=left>" & strcust & "</td></tr></br>"
            sendqry = sendqry & "<tr><td align=left>" & straddress & "</td></tr></br>"
            sendqry = sendqry & "<tr><td align=left>" & strcity & " - " & zipcode & "</td></tr></font></table><br>"
            sendqry = sendqry & "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Dear Sir / Madam ,</td></tr></font></table><br>"
            sendqry = sendqry & "<table width=100%><FONT FACE=tahoma ><tr><td align=left>New Booking #  " & txtbookno.Text & " Dt. " & dtbookdate.Text & " has generated for the below quotation. </td></tr></font></table><br>"

            sendqry = sendqry & "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Quotation # : " & txtquotno.Text & " Dt : " & dtquotdate.Text & "</td></tr>"
            sendqry = sendqry & "<tr><td align=left>Cargo Type  : " & txtCargo.Text & "</td></tr>"
            sendqry = sendqry & "<tr><td align=left>Cargo Description : " & cargo & "</td></tr>"
            sendqry = sendqry & "<tr><td align=left>Shipment : " & txtshipment.Text & "</td></tr>"
            sendqry = sendqry & "<tr><td align=left>Freight : " & txtfreight.Text & "</td></tr></font></table><br>"

            If UCase(txtInco.Text) <> UCase("Ex Works") Then
                sendqry = sendqry & "<table><tr><td align=left>Sell Rate Details :</td></tr></font></table>"
                sendqry = sendqry & "<table BORDER=2 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Charge Name</td><td align=center>Curr</td><td align=center>Rate</td><td align=center>Base</td><td align=center>Status</td></tr>"
                Dim precol As String
                dt = New DataTable
                dt = quotobj.ChargeDetailsGT0(txtquotno.Text, Login.branchid)
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(0).Item(2).ToString() > 0 Then
                        precol = bookingobj.GetBookingCharges(txtbookno.Text, dt.Rows(i).Item(0).ToString(), dt.Rows(i).Item(3).ToString(), Login.branchid)
                        If precol = "C" Then
                            precol = "ToCollect"
                        ElseIf precol = "P" Then
                            precol = "PrePaid"
                        End If
                        sendqry = sendqry & "<tr><td align=left>" & dt.Rows(i).Item(0).ToString() & "</td><td align=left>" & dt.Rows(i).Item(1).ToString() & "</td><td align=left>" & FormatNumber(dt.Rows(i).Item(2).ToString(), 0, TriState.True, TriState.False, TriState.False) & "</td><td align=left>" & dt.Rows(i).Item(3).ToString() & "</td><td align=left>" & precol & "</td></tr>"
                    End If
                Next i
                sendqry = sendqry & "</table><br>"
            End If
            
            sendqry = sendqry & "<table width=100% text=black><tr><td align=left>Thanks for the above booking, we will come back to you shortly with Vessel Details </td></tr></table><br>"
            sendqry = sendqry & "<table width=100% text=black><tr><td align=left>Best Regards </td></tr></table><br><br>"
            sendqry = sendqry & "<table width=100% text=black><tr><td align=left>" & employeeobj.GetEmployeeName(employeeobj.GetEmpid(Login.txtUser.Text)) & " </td></tr></table></body></html>"
        End If
    End Sub
         */
        public void txtunable()
        {
            txt_quatation.Enabled = false;
            txt_booking.Enabled = false;
            dtquotdate.Enabled = false;
            dtExpiredOn.Enabled = false;
            txtshipment.Enabled = false;
            txtfreight.Enabled = false;
            txt_por.Enabled = false;
            txt_pol.Enabled = false;
            txt_pod.Enabled = false;
            txt_fd.Enabled = false;
            txt_cargo.Enabled = false;
            // txt_vol.Enabled = false;
            txt_qcustomer.Enabled = false;
        }

        protected void txt_booking_TextChanged(object sender, EventArgs e)
        {
            if (txt_booking.Text != "")
            {
                Button1.Enabled = true;
            }

            if (txt_booking.Text != "")
            {
                // clear();
                enabletxt();
                Button1.Enabled = true;
                getvalue();
                vslclear();
            }



            UserRights();
        }

        public void getvalue()
        {
            try
            {
                Session["StrTranType"] = null;
                if (ddl_product.Text == "OCEAN EXPORTS")
                {
                    Session["StrTranType"] = "FE";
                    StrTranType = "FE";
                }
                else if (ddl_product.Text == "OCEAN IMPORTS")
                {
                    Session["StrTranType"] = "FI";
                    StrTranType = "FI";
                }
                else if (ddl_product.Text == "OCEAN IMPORTS")
                {
                    Session["StrTranType"] = "AE";
                    StrTranType = "AE";
                }
                else if (ddl_product.Text == "AIR IMPORTS")
                {
                    Session["StrTranType"] = "AI";
                    StrTranType = "AI";
                }
                else
                {
                    Session["StrTranType"] = null;
                    StrTranType = "";
                }
                string intbooking = txt_booking.Text.Trim().ToUpper();
                dtBooking = bookingobj.GetBookingdtlsNew(intbooking, StrTranType, Convert.ToInt32(Session["LoginBranchid"]));

                DataTable dt1 = new DataTable();
                DataRow dr1;

                if (dtBooking.Rows.Count > 0)
                {
                    string product = dtBooking.Rows[0]["trantype"].ToString();
                    if (product == "OE")
                    {
                        Session["StrTranType"] = "FE";
                        StrTranType = Session["StrTranType"].ToString();
                        ddl_product.Text = "OCEAN EXPORTS";
                    }
                    else if (product == "OI")
                    {
                        Session["StrTranType"] = "FI";
                        StrTranType = Session["StrTranType"].ToString();
                        ddl_product.Text = "OCEAN IMPORTS";
                    }
                    else if (product == "AE")
                    {
                        Session["StrTranType"] = "AE";
                        StrTranType = Session["StrTranType"].ToString();
                        ddl_product.Text = "AIR EXPORTS";
                    }
                    else if (product == "AI")
                    {
                        Session["StrTranType"] = "AI";
                        StrTranType = Session["StrTranType"].ToString();
                        ddl_product.Text = "AIR IMPORTS";
                    }

                    hd_cusid.Value = dtBooking.Rows[0]["customer"].ToString();
                    hd_book.Value = dtBooking.Rows[0][12].ToString();
                    txt_quatation.Text = dtBooking.Rows[0][0].ToString();
                    txtBuying.Text = dtBooking.Rows[0]["buyingno"].ToString();
                    txt_vol.Text = dtBooking.Rows[0][1].ToString();
                    //dtpValidity.Text = Utility.fn_ConvertDate(dtrateid.Rows[0]["validtill"].ToString());
                    // dtquotdate.Text = Utility.fn_ConvertDate(dtBooking.Rows[0][2].ToString());
                    dtquotdate.Text = DateTime.Parse(dtBooking.Rows[0][2].ToString()).ToString("dd-MMM-yyyy");
                    txt_qcustomer.Text = custobj.GetCustomername(Convert.ToInt32(dtBooking.Rows[0]["customer"].ToString()));
                    intShipment = dtBooking.Rows[0][3].ToString();
                    intpor = dtBooking.Rows[0][4].ToString();
                    intpol = dtBooking.Rows[0][5].ToString();
                    intpod = dtBooking.Rows[0][6].ToString();
                    intfd = dtBooking.Rows[0][7].ToString();
                    strfstatus = dtBooking.Rows[0][8].ToString();


                   
                    hd_controll.Value = dtBooking.Rows[0]["business"].ToString();
                    if (hd_controll.Value == "O")
                    {
                        txt_controll.Text = "Controlled By Us";
                    }
                    else
                    {
                        txt_controll.Text = "Agent Controlled";
                    }





                    //txtfromDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd/MMM/yyyy");
                    //dtExpiredOn.Text = Utility.fn_ConvertDate(dtBooking.Rows[0][9].ToString());

                    dtExpiredOn.Text = DateTime.Parse(dtBooking.Rows[0][9].ToString()).ToString("dd-MMM-yyyy");
                    int cargoid = Convert.ToInt32(dtBooking.Rows[0][10].ToString());
                    hid_cargo.Value = dtBooking.Rows[0][13].ToString();
                    dtDate.Text = DateTime.Parse(dtBooking.Rows[0][11].ToString()).ToString("dd-MMM-yyyy");
                    //dtDate.Text = Utility.fn_ConvertDate(dtBooking.Rows[0][11].ToString());
                    hdn_agentid.Value = dtBooking.Rows[0]["agentid"].ToString();

                    if (hdn_agentid.Value != "")
                    {
                        txt_agent.Text = custobj.GetCustomername(Convert.ToInt32(hdn_agentid.Value)).ToString();
                        txt_agent_multi.Text = custobj.GetCustomerAddress(Convert.ToInt32(hdn_agentid.Value)).ToString();
                        txt_mailid.Text = custobj.GetCusMailaddrs(Convert.ToInt32(hdn_agentid.Value));
                    }
                    if (string.IsNullOrEmpty(dtBooking.Rows[0]["factory"].ToString()) == false && dtBooking.Rows[0]["factory"].ToString() != "")
                    {
                        hid_factory.Value = dtBooking.Rows[0]["factory"].ToString();
                    }
                    else
                    {
                        hid_factory.Value = "0";
                    }
                    txtFactory.Text = dtBooking.Rows[0]["factoryname"].ToString();

                    txtQRemarks.Text = dtBooking.Rows[0]["remarks"].ToString();
                    if (dtBooking.Rows[0]["bremarks"].ToString() != "")
                    {
                        txtBRemarks.Text = dtBooking.Rows[0]["bremarks"].ToString();
                    }
                    //else
                    //{
                    //    txtBRemarks.Text = dtBooking.Rows[0]["remarks"].ToString();
                    //}
                    /* txt_cargo.Text = cargoobj.GetCargoname(Convert.ToInt32(cargoid));
                     txt_por.Text = portobj.GetPortname(Convert.ToInt32(intpor));
                     string portcode;
                     portcode = portobj.GetPortCodefrmPort(Convert.ToInt32(intpor));

                     if (portcode.Length == 3)
                     {
                         hid_PoRportcode.Value = portcode;
                     }
                     else if (portcode.Length >= 5)
                     {
                         hid_PoRportcode.Value = portcode.Substring(2, 3);
                     }
                     else
                     {
                         hid_PoRportcode.Value = "";
                     }
                     txt_pol.Text = portobj.GetPortname(Convert.ToInt32(intpol));
                     txt_pod.Text = portobj.GetPortname(Convert.ToInt32(intpod));
                     txt_fd.Text = portobj.GetPortname(Convert.ToInt32(intfd));
                     hdn_Incoid.Value = dtBooking.Rows[0]["inco"].ToString();
                     hdn_shipperid.Value = dtBooking.Rows[0]["shipperid"].ToString();
                     hdn_Consigneeid.Value = dtBooking.Rows[0]["consigneeid"].ToString();
                     DataTable dtinco = new DataTable();
                     dtinco = bookingobj.SelMasterInco(Convert.ToInt32(hdn_Incoid.Value));
                     if (dtinco.Rows.Count > 0)
                     {
                         txtInco.Text = dtinco.Rows[0]["incocode"].ToString();
                     }

                     txtMarketby.Text = "";*/

                    txt_cargo.Text = cargoobj.GetCargoname(Convert.ToInt32(cargoid));
                    txt_por.Text = portobj.GetPortname(Convert.ToInt32(intpor));
                    txt_pol.Text = portobj.GetPortname(Convert.ToInt32(intpol));
                    txt_pod.Text = portobj.GetPortname(Convert.ToInt32(intpod));
                    txt_fd.Text = portobj.GetPortname(Convert.ToInt32(intfd));
                    hdn_Incoid.Value = dtBooking.Rows[0]["inco"].ToString();
                    //DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();

                    DataTable dtflag;
                    dtflag = obj_MasterPort.SelPortName4typepadimg(txt_fd.Text.ToUpper(), Session["StrTranType"].ToString());
                    fdflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";

                    dtflag = obj_MasterPort.SelPortName4typepadimg(txt_por.Text.ToUpper(), Session["StrTranType"].ToString());
                    porflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";

                    dtflag = obj_MasterPort.SelPortName4typepadimg(txt_pod.Text.ToUpper(), Session["StrTranType"].ToString());
                    podflag.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";

                    dtflag = obj_MasterPort.SelPortName4typepadimg(txt_pol.Text.ToUpper(), Session["StrTranType"].ToString());
                    flagimg.ImageUrl = "../LOGO/" + dtflag.Rows[0]["countrycode"] + ".svg";

                    hdn_shipperid.Value = dtBooking.Rows[0]["shipperid"].ToString();
                    Session["hdn_shipperid"] = hdn_shipperid.Value;
                    hdn_Consigneeid.Value = dtBooking.Rows[0]["consigneeid"].ToString();
                    txt_custpono.Text = dtBooking.Rows[0]["cuspono"].ToString();
                    Session["hdn_Consigneeid"] = hdn_Consigneeid.Value;
                    DataTable dtinco = new DataTable();
                    dtinco = bookingobj.SelMasterInco(Convert.ToInt32(hdn_Incoid.Value));
                    if (dtinco.Rows.Count > 0)
                    {
                        txtInco.Text = dtinco.Rows[0]["incocode"].ToString();
                    }

                    txtMarketby.Text = "";
                    DataTable dt = new DataTable();

                    //string Ccode = Request.QueryString["Ccode"].ToString();

                    //if (Ccode != "")
                    //{

                    //    quotobj.GetDataBase(Ccode);
                    //}
                        dt = quotobj.GetQuotationDetails(Convert.ToInt32(txt_quatation.Text), StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                    if (dt.Rows.Count > 0)
                    {
                        string intcustid = dt.Rows[0][2].ToString();
                        hdf_customerid.Value = intcustid;
                        intsales = dt.Rows[0][10].ToString();
                        //lbl.Visible = true;
                        txtMarketby.Text = empobj.GetEmployeeName(Convert.ToInt32(intsales));
                    }
                    if (intShipment == "L")
                    {
                        txtshipment.Text = "LCL";
                        lbl_voll.Text = "CBM";
                    }
                    else if (intShipment == "F")
                    {
                        txtshipment.Text = "FCL";
                        lbl_voll.Text = "Teus";
                    }
                    if (strfstatus == "P")
                    {
                        txtfreight.Text = "Prepaid";
                    }
                    //else if (strfstatus == "C")
                    //{
                    //    txtfreight.Text = "Tocollect";
                    //}

                    if (strfstatus == "C")
                    {
                        if (Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
                        {
                            txtfreight.Text = "collect";
                        }
                        else
                        {
                            txtfreight.Text = "collect";
                        }

                    }
                    if (StrTranType == "AE" || StrTranType == "AI")
                    {
                        txtshipment.Text = "";
                        lbl_voll.Text = "Kgs";
                    }
                      btnSave.Text = "Update";
                    btnSave.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";

                     btnCancel.Text = "Cancel";
                    btnCancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                    txt_vol.Enabled = true;
                    btnSave.Enabled = true;
                    txtunable();
                    grdfill();
                    if (blnerr == true)
                    {
                        return;
                    }

                    viewcheckgrd();

                    dtBuying = quotobj.CheckQuotForBookingFromQno(Convert.ToInt32(txt_quatation.Text), StrTranType, Convert.ToInt32(Session["LoginBranchid"]), "QB");
                    if (dtBuying.Rows.Count > 0)
                    {
                        //rateid = Convert.ToInt32(dtBuying.Rows[0]["buyingno"].ToString());
                        //dtvalid = bookingobj.SELECTRateValidTill(rateid);
                        //txt_validtill.Text = Utility.fn_ConvertDate( dtvalid.Rows[0]["validtill"].ToString());
                        txtBuying.Text = dtBuying.Rows[0]["buyingno"].ToString();
                        if (txtBuying.Text != "")
                        {
                            dtrateid = buyingobj.SelectBuyingHeadAll(Convert.ToInt32(txtBuying.Text));
                        }

                        if (dtrateid.Rows.Count > 0)
                        {
                            bfreight = dtrateid.Rows[0]["freight"].ToString();
                            txt_validtill.Text = Utility.fn_ConvertDate(dtrateid.Rows[0]["validtill"].ToString());
                            //txtBRemarks.Text = dtrateid.Rows[0]["remarks"].ToString();

                        }
                        grdBuyingfill();
                    }


                    int shipid = Convert.ToInt32(hdn_shipperid.Value);

                    if (shipid == 0)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (StrTranType == "FE")
                            {
                                hdn_shipperid.Value = dt.Rows[0]["customerid"].ToString();
                                txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(hdn_shipperid.Value));
                                txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(hdn_shipperid.Value));

                            }
                        }
                    }
                    else
                    {
                        txt_shiper.Text = custobj.GetCustomername(Convert.ToInt32(hdn_shipperid.Value));
                        txt_shipermulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(hdn_shipperid.Value));
                    }
                    int consid = Convert.ToInt32(hdn_Consigneeid.Value);

                    if (consid == 0)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (StrTranType == "FI" || StrTranType == "AI")
                            {
                                hdn_Consigneeid.Value = dt.Rows[0]["customerid"].ToString();
                                txt_consignee.Text = custobj.GetCustomername(Convert.ToInt32(hdn_Consigneeid.Value));
                                txt_consigneemulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(hdn_Consigneeid.Value));


                            }
                        }
                    }
                    else
                    {
                        txt_consignee.Text = custobj.GetCustomername(Convert.ToInt32(hdn_Consigneeid.Value));
                        txt_consigneemulti.Text = custobj.GetCustomerAddress(Convert.ToInt32(hdn_Consigneeid.Value));
                    }



                    if (hdn_agentid.Value != "")
                    {
                        if (dtBooking.Rows.Count > 0)
                        {
                            txt_agent.Text = custobj.GetCustomername(Convert.ToInt32(hdn_agentid.Value));
                            txt_agent_multi.Text = custobj.GetCustomerAddress(Convert.ToInt32(hdn_agentid.Value));
                        }
                    }


                    DataTable dtmailid = new DataTable();
                    dtmailid = bookingobj.SelCOMBookingMailid(txt_booking.Text.Trim(), Convert.ToInt32(Session["LoginBranchid"]));
                    if (dtmailid.Rows.Count > 0)
                    {
                        for (i = 0; i < dtmailid.Rows.Count - 1; i++)
                        {
                            //grdCMail.DataSource = dtmailid;
                            //grdCMail.DataBind();
                            //grdCMail.Rows[i].Cells[0].Text = dtmailid.Rows[i]["mailid"].ToString();
                            //grdCMail.Rows[i].Cells[1].Text = dtmailid.Rows[i]["type"].ToString();
                        }
                    }
                    if (grdCMail.Rows.Count > 0)
                    {

                        dt1.Columns.Add(new System.Data.DataColumn("email", typeof(String)));
                        dt1.Columns.Add(new System.Data.DataColumn("Cname", typeof(String)));
                        string srtmailid = custobj.GetCusMailaddrs(Convert.ToInt32(hdn_Consigneeid.Value));
                        if (srtmailid != "")
                        {
                            dr1 = dt1.NewRow();
                            dr1[0] = srtmailid;
                            dr1[1] = "Consignee";
                            dt1.Rows.Add(dr1);
                            //grdCMail.DataSource = dt1;
                            //grdCMail.DataBind();
                        }
                        srtmailid = custobj.GetCusMailaddrs(Convert.ToInt32(hdn_shipperid.Value));
                        if (srtmailid != "")
                        {
                            dr1 = dt1.NewRow();
                            dr1[0] = srtmailid;
                            dr1[1] = "Shipper";
                            dt1.Rows.Add(dr1);
                            //grdCMail.DataSource = dt1;
                            //grdCMail.DataBind();
                        }
                    }
                    if (hdn_Consigneeid.Value == "0")
                    {
                        txt_consignee.Text = "";
                        txt_consigneemulti.Text = "";
                    }
                    if (hdn_shipperid.Value == "0")
                    {
                        txt_shiper.Text = "";
                        txt_shipermulti.Text = "";
                    }
                    if (hdn_agentid.Value == "0")
                    {
                        txt_agent.Text = "";
                        txt_agent_multi.Text = "";

                    }
                    txt_shiper.Focus();
                    DataTable dt2 = new DataTable();
                    //DataAccess.Marketing.Booking book = new DataAccess.Marketing.Booking();
                    int bookingno = Convert.ToInt32(hd_book.Value);
                    dt2 = book.GetBookingVesselDetails(bookingno, bid);
                    if (dt2.Rows.Count > 0)
                    {
                        panel_vessel.Visible = true;
                        grd_vessel.Visible = true;
                        Session["book"] = dt2;
                        grd_vessel.DataSource = dt2;
                        grd_vessel.DataBind();
                        //btn_add.Text = "Update";
                    }
                    else
                    {
                        panel_vessel.Visible = true;
                        grd_vessel.Visible = true;
                        Session["book"] = new DataTable();
                        grd_vessel.DataSource = new DataTable();
                        grd_vessel.DataBind();
                    }

                }
                else
                {
                    //StrTranType = HttpContext.Current.Session["StrTranType"].ToString();
                    DataTable dtbooking = new DataTable();
                    dtbooking = bookingobj.GetBookingPending(StrTranType, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), txt_booking.Text.ToUpper());
                    if (dtbooking.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        txt_booking.Text = "";
                        txt_booking.Focus();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Booking number');", true);
                    }
                }

                Bind_outstandingdetails();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            // strtrantype = Session["StrTranType"].ToString();
            try
            {
                string str_sp = "";
                string str_sf = "";
                string str_RptName = "";
                string str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                string mailid = "";
                double rate = 0;
                if (txt_booking.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Button1, typeof(Button), "DataFound", "alertify.alert('Booking UnAvailable');", true);
                    return;
                }

                if (grdCMail.Rows.Count > 0)
                {
                    for (int i = 0; i <= grdCMail.Rows.Count - 1; i++)
                    {
                        Label lbl = (grdCMail.Rows[i].Cells[1].FindControl("email") as Label);
                        mailid = lbl.Text + ";" + mailid;

                    }
                }
                str_RptName = "Booking.rpt";
                str_sp = "buying=false";
                Session["str_sfs"] = "{COMBooking.bid}=" + Session["LoginBranchid"].ToString() + " and {COMBooking.shiprefno}='" + txt_booking.Text + "' and {COMBooking.trantype}='" + StrTranType + "'";
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Booking", str_Script, true);

                Session["str_sp"] = str_sp;


                sendqry = Utility.Fn_GetCompanyAddress();
                sendqry = sendqry + "</br>";
                sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Dear Sir / Madam ,</td></tr></font></table><br>";
                sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>New Booking #  " + txt_booking.Text + " Dt. " + dtDate.Text + " has generated for the below quotation. Please find the attachment for more details </td></tr></font></table>";
                sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Customer : " + txt_qcustomer.Text + "</td></tr><br>";
                sendqry = sendqry + "<tr><td align=left>Quotation # : " + txt_quatation.Text + " Dt : " + dtquotdate.Text + "</td></tr>";
                sendqry = sendqry + "<tr><td align=left>Cargo Type  : " + txt_cargo.Text + "</td></tr>";

                sendqry = sendqry + "<tr><td align=left>Shipment : " + txtshipment.Text + "</td></tr>";
                sendqry = sendqry + "<tr><td align=left>Freight : " + txtfreight.Text + "</td></tr></font></table>";
                sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>PoR : " + txt_por.Text + "</td><td align=left>PoL : " + txt_pol.Text + "</td><td align=left>PoD : " + txt_pod.Text + "</td><td align=left>FD : " + txt_fd.Text + "</td></tr></FONT></table><br>";
                sendqry = sendqry + "<table><tr><td align=left>Sell Rate Details :</td></tr></font></table>";
                sendqry = sendqry + "<table BORDER=1 BORDERCOLOR=#336699 CELLPADDING=2 CELLSPACING=0 WIDTH=100% text=black><tr><td align=center>Charge Name</td><td align=center>Curr</td><td align=center>Rate</td><td align=center>Base</td><td align=center>Status</td></tr>";

                string precol;
                DataTable Dt = new DataTable();
                Dt = quotobj.ChargeDetails(Convert.ToInt32(txt_quatation.Text), Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text.Trim());

                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    precol = bookingobj.GetBookingCharges(txt_booking.Text, Dt.Rows[i][0].ToString(), Dt.Rows[i][3].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    if (precol == "C")
                    {
                        precol = "Collect";
                    }
                    else if (precol == "P")
                    {
                        precol = "PrePaid";
                    }

                    rate = Convert.ToDouble(Dt.Rows[i][2].ToString());
                    string rate1 = rate.ToString("#0.00");
                    sendqry = sendqry + "<tr><td align=left>" + Dt.Rows[i][0].ToString() + "</td><td align=left>" + Dt.Rows[i][1].ToString() + "</td><td align=right>" + rate1 + "</td><td align=left>" + Dt.Rows[i][3].ToString() + "</td><td align=left>" + precol + "</td></tr>";
                }



                if (Session["usermailid"].ToString() == "" || Session["usermailpwd"].ToString() == "" || Session["usermailid"] == null || Session["usermailpwd"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "UserName", "alertify.alert('Update Email ID and Password');", true);
                    return;
                }

                string branchmgrid = quotobj.GetBranchmgrmailid(Convert.ToInt32(Session["LoginBranchid"].ToString()));


                sendqry = sendqry + "</table>";

                sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>Remarks : " + txtQRemarks.Text + "</td></tr><br>";
                sendqry = sendqry + "<tr><td align=left>Thanks for the above booking, we will come back to you shortly with Vessel Details</td></tr></font><br>";

                sendqry = sendqry + "<table width=100% text=black><tr><td align=left>Best Regards </td></tr></table>";
                sendqry = sendqry + "<table width=100% text=black><tr><td align=left>" + empobj.GetEmployeeName(empobj.GetEmpid(HttpContext.Current.Session["LoginUserName"].ToString())) + " </td></tr></table></body></html>";


                Utility.SendMail(HttpContext.Current.Session["usermailid"].ToString(), Session["usermailid"].ToString(), " Booking # -" + txt_booking.Text + " PoL : " + txt_pol.Text + " PoD : " + txt_pod.Text, sendqry.ToString(), "", HttpContext.Current.Session["usermailpwd"].ToString(), "", "");
                //ScriptManager.RegisterStartupScript(Button1, typeof(Button), "DataFound", "alertify.alert('Mail Send');", true);
                // GetAllMailIds(Convert.ToInt32(hdn_agentid.Value));

                if (txt_booking.Text == "")
                {
                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10, 3, Convert.ToInt32(Session["LoginBranchid"]), "Send");
                            break;
                        case "FI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 11, 3, Convert.ToInt32(Session["LoginBranchid"]), "Send");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 12, 3, Convert.ToInt32(Session["LoginBranchid"]), "Send");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 13, 3, Convert.ToInt32(Session["LoginBranchid"]), "Send");
                            break;
                    }
                }
                else
                {
                    switch (Session["StrTranType"].ToString())
                    {
                        case "FE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10, 3, Convert.ToInt32(Session["LoginBranchid"]), "/Send");
                            break;
                        case "FI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 11, 3, Convert.ToInt32(Session["LoginBranchid"]), "/Send");
                            break;
                        case "AE":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 12, 3, Convert.ToInt32(Session["LoginBranchid"]), "/Send");
                            break;
                        case "AI":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 13, 3, Convert.ToInt32(Session["LoginBranchid"]), "/Send");
                            break;
                    }
                }
                if (grdCMail.Rows.Count > 0)
                {
                    for (int i = 0; i <= grdCMail.Rows.Count - 1; i++)
                    {
                        Label lbl = (grdCMail.Rows[i].Cells[1].FindControl("email") as Label);
                        bookingobj.InsBookingMailID(txt_booking.Text, grdCMail.Rows[i].Cells[1].Text, lbl.Text, bid);
                    }
                }
                FImail();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        private string SendPDFEmail(string sb)
        {
            StringReader sr = new StringReader(sb.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            // Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                //File.WriteAllBytes(@"D:\test.pdf", bytes);
                //MemoryStream ms = new MemoryStream((bytes));

                if (File.Exists(Server.MapPath("test.pdf")))
                {
                    File.Delete(Server.MapPath("test.pdf"));
                }

                string sFile = Server.MapPath("test.pdf"); //Path
                FileStream fs = File.Create(sFile);
                fs.Close();
                //BinaryWriter bw = new BinaryWriter(fs);
                File.WriteAllBytes(Server.MapPath("test.pdf"), bytes);
                //Application.StartupPath & "\" & "OutStandingReceivableAgent.pdf")
                string strattach = Server.MapPath("test.pdf");
                return strattach;
            }

        }

        public void FImail()
        {

            if (hdn_agentid.Value != "0")
            {
                if (txt_mailid.Text.Replace(";", "").Replace(" ", "") != "")
                {
                    sendqry = "";
                    sendqry = sendqry + "<table width=100%><FONT FONT  SIZE=2 FACE=tahoma><tr><td align=left>Dear Sir / Madam,</td></tr></font></table><br>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma   SIZE=2><tr><td align=left>New Booking # : " + txt_booking.Text + " has generated and find the details below</td></tr></font></table><br>";
                    sendqry = sendqry + "<table width=100%  CELLSPACING=0   ><FONT FACE=tahoma >";

                    if (hdn_shipperid.Value != "0" || hdn_shipperid.Value != "")
                    {
                        sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Shipper</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + txt_shiper.Text + "</font></td></tr>";
                        DataTable dtadd = new DataTable();
                        dtadd = custobj.GetCustDetails(Convert.ToInt32(hdn_shipperid.Value));
                        if (dtadd.Rows[0]["address"].ToString() != "")
                        {
                            sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2></font></td><td></td><td colspan=1><FONT FACE=tahoma size=2>" + dtadd.Rows[0]["address"].ToString().Trim() + "</font></td></tr>";
                        }
                        if (dtadd.Rows[0]["portname"].ToString() != "")
                        {
                            sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2></font></td><td></td><td colspan=1><FONT FACE=tahoma size=2>" + dtadd.Rows[0]["portname"].ToString().Trim();
                        }
                        if (dtadd.Rows[0]["zip"].ToString() != "")
                        {
                            sendqry = sendqry + " - " + dtadd.Rows[0]["zip"].ToString().Trim() + "</font></td></tr>";
                        }
                        else
                        {
                            sendqry = sendqry + "</td></tr>";
                        }
                        if (dtadd.Rows[0]["Phone"].ToString() != "")
                        {
                            sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2></font></td><td></td><td colspan=1><FONT FACE=tahoma size=2>Ph. : " + dtadd.Rows[0]["Phone"].ToString().Trim() + "</font></td></tr>";
                        }
                        if (dtadd.Rows[0]["fax"].ToString() != "")
                        {
                            sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2></font></td><td></td><td colspan=1><FONT FACE=tahoma size=2>Fax : " + dtadd.Rows[0]["fax"].ToString().Trim() + "</font></td></tr>";
                        }
                        if (dtadd.Rows[0]["email"].ToString() != "")
                        {
                            sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2></font></td><td></td><td align=center colspan=1><FONT FACE=tahoma size=2>Email : " + dtadd.Rows[0]["email"].ToString().Trim() + "</font></td></tr>";
                        }

                    }
                    if (hdn_Consigneeid.Value != "0" || hdn_Consigneeid.Value != "")
                    {
                        sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Consignee</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + txt_consignee.Text.Trim() + "</font></td></tr>";
                        DataTable dtadd = new DataTable();
                        dtadd = custobj.GetCustDetails(Convert.ToInt32(hdn_Consigneeid.Value));
                        if (dtadd.Rows.Count > 0)
                        {
                            if (dtadd.Rows[0]["address"].ToString() != "")
                            {
                                sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2></font></td><td></td><td colspan=1><FONT FACE=tahoma size=2>" + dtadd.Rows[0]["address"].ToString().Trim() + "</font></td></tr>";
                            }
                            if (dtadd.Rows[0]["portname"].ToString() != "")
                            {
                                sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2></font></td><td></td><td colspan=1><FONT FACE=tahoma size=2>" + dtadd.Rows[0]["portname"].ToString().Trim();
                            }

                            if (dtadd.Rows[0]["zip"].ToString() != "")
                            {
                                sendqry = sendqry + " - " + dtadd.Rows[0]["zip"].ToString().Trim() + "</font></td></tr>";
                            }
                            else
                            {
                                sendqry = sendqry + "</td></tr>";
                            }
                        }
                    }


                    sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Place of Receipt</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + txt_por.Text + "</font></td></tr>";
                    sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Port of Loading</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + txt_pol.Text + "</font></td></tr>";
                    sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Port of Discharge</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + txt_pod.Text + "</font></td></tr>";
                    sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Place of Delivery</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + txt_fd.Text + "</font></td></tr>";
                    sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Commodity</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + txt_cargo.Text.Trim().ToUpper() + "</font></td></tr>";
                    if (hid_cargo.Value != "")
                    {
                        sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Cargo Description</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + hid_cargo.Value + "</font></td></tr>";
                    }
                    sendqry = sendqry + "<tr><td width=20% colspan=1><FONT FACE=tahoma size=2><b>Freight Terms</b></font></td><td><b>:</b></td><td colspan=1><FONT FACE=tahoma size=2>" + txtfreight.Text + "</font></td></tr>";
                    sendqry = sendqry + "</table><br>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma   SIZE=2><tr><td align=left>We Request you to provide the Vessel Schedule , Cargo Readiness Date , Expected Date to come to Warehouse for the same.</font></table><br>";
                    sendqry = sendqry + "<table width=100%><FONT FACE=tahoma ><tr><td align=left>System generated mail,Signature is not required</td></tr></font></table>";
                    Utility.SendMail(Session["usermailid"].ToString(), txt_mailid.Text, "Booking # - " + txt_booking.Text, sendqry, "", Session["usermailpwd"].ToString(), "", "");
                }

            }

        }

        protected void LoadBooking()
        {

            try
            {
                Session["StrTranType"] = null;
                StrTranType = "";
                /*   if (ddl_product.Text == "OCEAN EXPORTS")
                   {
                       Session["StrTranType"] = "FE";
                       StrTranType = "FE";
                   }
                   else if (ddl_product.Text == "OCEAN IMPORTS")
                   {
                       Session["StrTranType"] = "FI";
                       StrTranType = "FI";
                   }
                   else if (ddl_product.Text == "OCEAN IMPORTS")
                   {
                       Session["StrTranType"] = "AE";
                       StrTranType = "AE";
                   }
                   else if (ddl_product.Text == "AIR IMPORTS")
                   {
                       Session["StrTranType"] = "AI";
                       StrTranType = "AI";
                   }
                   else
                   {
                       Session["StrTranType"] = null;
                       StrTranType = "";
                   }*/
                dtBooking = bookingobj.GetBookingPending(StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                grdBooking.DataSource = dtBooking;
                if (dtBooking.Rows.Count > 0)
                {
                    grdBooking.Visible = true;
                    grdBooking.DataSource = dtBooking;
                    grdBooking.DataBind();
                    ViewState["dtbook"] = dtBooking;
                    this.popupBooking.Show();

                }

                else
                {
                    //dtBooking.Rows.Add(dtBooking.NewRow());
                    //grdBooking.DataSource = dtBooking;
                    //grdBooking.DataBind();
                    //int totalcolums = grdBooking.Rows[0].Cells.Count;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Unavailable');", true);
                }


                 btnCancel.Text = "Cancel";
                btnCancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lblBooking_Click(object sender, EventArgs e)
        {
            //if (ddl_product.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
            //    blnerr = true;
            //    ddl_product.Focus();
            //    return;
            //}
            LoadBooking();
            UserRights();
            if (ddl_product.Text == "OCEAN EXPORTS")
            {
                dts = objship.Getsbno();
                checkview.DataSource = dts;
                checkview.DataBind();

            }

            if (dts.Rows.Count > 0)
            {
                for (int i = 0; i < checkview.Rows.Count - 1; i++)
                {
                    CheckBox chkRow = (checkview.Rows[i].Cells[1].FindControl("checksbno") as CheckBox);

                    if (chkRow.Checked == true)
                    {


                    }


                }
            }
            else
            {

            }
        }

        public void viewcheckgrd()
        {
            if (txt_booking.Text != "")
            {
                if (StrTranType == "FE" || ddl_product.Text == "OCEAN EXPORTS")
                {
                    DataTable Dt = new DataTable();
                    Dt = objship.GetviewShipRefNo(txt_booking.Text);
                    checkview.DataSource = Dt;
                    checkview.DataBind();
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= checkview.Rows.Count - 1; i++)
                        {
                            CheckBox chkRow = (checkview.Rows[i].Cells[1].FindControl("checksbno") as CheckBox);

                            if (checkview.Rows[i].Cells[2].Text != "0")
                            {
                                chkRow.Checked = true;
                                chkRow.Enabled = false;
                            }
                            else if (checkview.Rows[i].Cells[3].Text != "0")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                        }
                    }
                    else
                    {
                        checkview.DataSource = Dt;
                        checkview.DataBind();
                    }
                }


            }

        }
        protected void grdBooking_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBooking, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

            }

        }

        protected void grdBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (grdBooking.Rows.Count > 0)
                {
                    txt_agent.Text = "";

                    index = grdBooking.SelectedRow.RowIndex;
                    txt_booking.Text = grdBooking.SelectedRow.Cells[0].Text;
                  //  string type = grdBooking.SelectedRow.Cells[5].ToString();
                    if (txt_booking.Text != "")
                    {
                        getvalue();
                        Button1.Enabled = true;
                        vslclear();
                    }
                }

                //Bind_outstandingdetails();

                UserRights();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            LoadCancel();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Back")
            {
                // this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "SA")
                    {
                        Response.Redirect("../Home/SalesHome.aspx");
                    }
                    if (Session["home"].ToString() == "CS")
                    {
                        if (Session["StrTranType"] == "FI")
                        {
                            Response.Redirect("../Home/OICSHome.aspx");
                        }
                        else
                        {
                            Response.Redirect("../Home/OECSHome.aspx");
                        }

                    }
                }
                else
                {
                    this.Response.End();
                }
            }
            else
            {
                Ebooking.Text = "";
                hidbookingno.Value = "";
                hid_bookingstatus.Value = "";
                hidbookno.Value = "";


                test.Text = "";
                JobInput.Text = "";
                // Session["StrTranType"] = null;
                //if (Session["StrTranType"].ToString() == "FE")
                //{
                //    dts = objship.Getsbno();
                //    checkview.DataSource = dts;
                //    checkview.DataBind();
                //}
                lbtnSop.Enabled = false;
                chkBox.Enabled = false;
                lbtnSop1.Attributes["class"] = "lbtnSop1";
                //   lbtnSop.Visible = false;
                chkBox.Checked = false;
                txtFactory.Text = "";
                hdn_agentid.Value = "";
                hdn_Consigneeid.Value = "";
                hdn_Incoid.Value = "";
                hdn_Business.Value = "";
                hdn_consigneemailid.Value = "";
                hdn_Othersemailid.Value = "";
                hdn_QuotCustomer.Value = "";
                hdn_quotid.Value = "";
                hdn_shipermailid.Value = "";
                hdn_shipperid.Value = "";
                hd_controll.Value = "";
                hd_cusid.Value = "";
                txt_controll.Text = "";
                hdn_bookno.Value = "";
                grdBooking.Visible = false;
                grdQuotation.Visible = false;
                grdCancel.Visible = false;
                clear();
                enabletxt();

                  btnSave.Text = "Save";
                btnSave.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";
                //btn_add.Text = "Add";
                btn_add.ToolTip = "Add";
                btn_add1.Attributes["class"] = "btn ico-add";
                Button1.Enabled = false;
                panel_vessel.Visible = false;
                grd_vessel.DataSource = new DataTable();
                grd_vessel.DataBind();
                //ddlpdt.SelectedValue = "--Product--";
                grdCMail.DataSource = new DataTable();
                grdCMail.DataBind();
                dtDate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                dtExpiredOn.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                dtquotdate.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                txt_eta.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                txt_etd.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                vslclear();
                ddl_product.Text = "";
                  btnCancel.Text = "Back";
                btnCancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                div_vessel_add.Visible = false;

                checkview.DataSource = new DataTable();
                checkview.DataBind();


            }
            UserRights();
        }

        public void clear()
        {
            txt_quatation.Text = "";
            txt_booking.Text = "";
            txtshipment.Text = "";
            txtfreight.Text = "";
            txt_pod.Text = "";
            txt_pol.Text = "";
            txt_por.Text = "";
            txt_fd.Text = "";
            txt_agent.Text = "";
            txt_agent_multi.Text = "";
            txt_qcustomer.Text = "";
            txt_cargo.Text = "";
            txt_vol.Text = "";
            txtInco.Text = "";
            txt_shiper.Text = "";
            txt_shipermulti.Text = "";
            txt_consignee.Text = "";
            //txt_othersMail.Text = "";
            //txt_shippermail.Text = "";
            //txt_Consigneemail.Text = "";
            txt_consigneemulti.Text = "";
            txt_mailid.Text = "";
            grd.DataSource = Utility.Fn_GetEmptyDataTable();
            grd.DataBind();
            grd.EmptyDataText = "No Records Found";
            grd.ShowHeaderWhenEmpty = true;
            GrdBuying.DataSource = Utility.Fn_GetEmptyDataTable();
            GrdBuying.DataBind();
            GrdBuying.EmptyDataText = "No Records Found";
            GrdBuying.ShowHeaderWhenEmpty = true;
            txtBuying.Text = "";
            txtQRemarks.Text = "";
            txtBRemarks.Text = "";
            dtDate.Text = Logobj.GetDate().ToShortDateString();
            dtDate.Text = Utility.fn_ConvertDate(dtDate.Text);
            dtExpiredOn.Text = Logobj.GetDate().ToShortDateString();
            dtExpiredOn.Text = Utility.fn_ConvertDate(dtExpiredOn.Text);
            dtquotdate.Text = Logobj.GetDate().ToShortDateString();
            dtquotdate.Text = Utility.fn_ConvertDate(dtquotdate.Text);
            //lbl.Visible = false;
            txtMarketby.Text = "";
            grdCMail.DataSource = Utility.Fn_GetEmptyDataTable();
            grdCMail.DataBind();
            grdCMail.EmptyDataText = "No Records Found";
            grdCMail.ShowHeaderWhenEmpty = true;
            //lbl.Visible = false;
            //ShowNoResultFound(dtBooking, grd);
            //ShowNoResultFound(dtBuying, GrdBuying);
            //MailGrid(dt, grdCMail);
            ddl_product.Text = "";
        }
        public void enabletxt()
        {
            txt_vol.Enabled = true;
            txtQRemarks.Enabled = true;
            txt_booking.Enabled = true;
            dtExpiredOn.Enabled = true;
            txt_quatation.Enabled = true;
            txtshipment.Enabled = true;
            txtfreight.Enabled = true;
            txt_por.Enabled = true;
            txt_pol.Enabled = true;
            txt_pod.Enabled = true;
            txt_fd.Enabled = true;
            txt_cargo.Enabled = true;
            txt_qcustomer.Enabled = true;
            dtquotdate.Enabled = false;
        }


        protected void ImageButton2_Click(object sender, EventArgs e)
        {
            try
            {

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
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking Details Deleted...');", true);
                        }
                    }

                    ViewState["CurrentData"] = dt;
                    grdCMail.DataSource = dt;
                    grdCMail.DataBind();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdCMail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdCMail.Rows.Count > 0)
            {
                this.PopUpService.Show();
            }
        }

        protected void grdCMail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label email = (Label)e.Row.FindControl("email");
                string tooltip1 = email.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip1);
                //ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ImageButton2");
                //lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCMail, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdCancel_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = grdCancel.SelectedRow.RowIndex;
            Session["bookingno"] = grdCancel.SelectedRow.Cells[0].Text;
        }

        protected void grdCancel_RowDataBound(object sender, GridViewRowEventArgs e)
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

                ImageButton lnkbtn = (ImageButton)e.Row.FindControl("ImageButton3");
                lnkbtn.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCancel, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        /* protected void ImageButton3_Click(object sender, EventArgs e)
         {
             try
             {

                 if (Session["bookingno"].ToString() != null)
                 {
                     bookingobj.Bookingcancel(Session["bookingno"].ToString(), StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                     ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking # " + Session["bookingno"].ToString() + " Cancelled.');", true);
                     dtBooking = bookingobj.GetBookingPending4Cancel(StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                     if (dtBooking.Rows.Count > 0)
                     {
                         grdCancel.DataSource = dtBooking;
                         grdCancel.DataBind();
                     }
                     else
                     {
                         grdCancel.EmptyDataText = "No Records Found";
                     }

                 }
             }
             catch (Exception ex)
             {
                 string message = ex.Message.ToString();
                 ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
             }
         }*/

        //protected void ddlpdt_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (ddlpdt.Text == "--Product--")
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Select the Product');", true);
        //        ddlpdt.Focus();


        //        return;
        //    }

        //    if (ddlpdt.SelectedValue == "Forwarding Exports FCL")
        //    {
        //        StrTranType = "FE";
        //        pdt = "FCL";

        //    }
        //    else if (ddlpdt.SelectedValue == "Forwarding Exports LCL")
        //    {
        //        StrTranType = "FE";

        //        pdt = "LCL";
        //    }
        //    else if (ddlpdt.SelectedValue == "Forwarding Imports FCL")
        //    {
        //        StrTranType = "FI";

        //        pdt = "FCL";
        //    }
        //    else if (ddlpdt.SelectedValue == "Forwarding Imports LCL")
        //    {
        //        StrTranType = "FI";

        //        pdt = "LCL";
        //    }
        //    else if (ddlpdt.SelectedValue == "Air Exports")
        //    {
        //        StrTranType = "AE";
        //        pdt = "emp";

        //    }
        //    else if (ddlpdt.SelectedValue == "Air Imports")
        //    {
        //        StrTranType = "AI";

        //        pdt = "emp";
        //    }

        //}

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //if (ddlpdt.Text == "--Product--")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Please Select the Product');", true);
            //    ddlpdt.Focus();
            //    return;
            //}
        }

        protected void grdBooking_PreRender(object sender, EventArgs e)
        {
            if (grdBooking.Rows.Count > 0)
            {
                grdBooking.UseAccessibleHeader = true;
                grdBooking.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void txt_agent_TextChanged(object sender, EventArgs e)
        {
            //if (hdn_agentid.Value != "0")
            //{
            //    //txt_agent.Text = custobj.GetLikeCustomer(hdn_agentid.Value).ToString();

            //}

            if (txt_agent.Text.Trim() == "")
            {
                txt_agent_multi.Text = "";
                txt_mailid.Text = "";
            }

            try
            {
                //DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
                DataTable dtCarrier = new DataTable();
                //  dtCarrier = Cusobj.GetLikeCustomer(txt_agent.Text.ToUpper(), "P");
                //int getcustometid = custobj.GetCustomerid(txt_agent.Text.ToUpper());
                //if (getcustometid!=0)
                DataTable dt = new DataTable();
                dt = custobj.GetexactCustomer(txt_agent.Text.Trim().ToUpper(), "P");
                if (dt.Rows.Count > 0 && hdn_agentid.Value != "0")
                {
                    txt_mailid.Text = custobj.GetCusMailaddrs(Convert.ToInt32(hdn_agentid.Value));
                    txt_mailid.Focus();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Agent');", true);
                    txt_agent.Text = "";
                    txt_agent_multi.Text = "";
                    txt_agent.Focus();
                    blnerr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_shiper_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
                DataTable dtCarrier = new DataTable();
                DataTable dtnew = new DataTable();
                //DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();
                // dtCarrier = Cusobj.GetLikeCustomer(txt_shiper.Text.ToUpper(), "C");
                // int customerid = custobj.GetCustomerid(txt_shiper.Text.Trim().ToUpper());
                DataTable dt = new DataTable();
                dt = custobj.GetexactCustomer(txt_shiper.Text.Trim().ToUpper(), "C");
                Session["hdn_shipperid"] = hdn_shipperid.Value;




                if (dt.Rows.Count > 0 && hdn_shipperid.Value != "0")
                {

                    dtnew = cus.getcustomerblk(Convert.ToInt32(hdn_shipperid.Value));
                    if (dtnew.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txt_shiper.Text + " status is Hold please discuss with Finance team ');", true);
                        txt_shiper.Text = "";
                        txt_shiper.Focus();

                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Shipper');", true);
                    txt_shiper.Text = "";
                    txt_shipermulti.Text = "";
                    txt_shiper.Focus();
                    blnerr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";

            if (txt_booking.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Booking # cannot be empty!!');", true);
                txt_booking.Focus();
                return;
            }
            StrTranType = Session["StrTranType"].ToString();
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

            if (NewBookRpt.Value == "Y")
            {
                if (txt_booking.Text.Trim() != "")
                {
                    string Ccode = Convert.ToString(Session["Ccode"]);
                    string intbooking = txt_booking.Text.Trim().ToUpper();
                    dtBooking = bookingobj.GetBookingdtlsNew(intbooking, StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                    if (dtBooking.Rows.Count>0)
                    {
                        hd_book.Value = dtBooking.Rows[0][12].ToString();
                    }
                    if (hd_book.Value != "0" && hd_book.Value != "")
                    {
                        str_Script = "window.open('../Reportasp/BookingRpt.aspx?Bookingno=" + hd_book.Value + "&Bid=" + Session["LoginBranchid"] + "&Cid=" + Session["LoginDivisionid"]  +"&Ccode=" + Ccode + "&TranType=" + Session["StrTranType"] + "','','');";
                        ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Booking", str_Script, true);
                    }              
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the BOOKING NO');", true);
                    return;
                }
            }
            else
            {
                if (txt_booking.Text.Trim().Length > 0)
                {

                    str_RptName = "Booking.rpt";
                    str_sp = "buying=true";
                    Session["str_sfs"] = "{COMBooking.bid}=" + Session["LoginBranchid"].ToString() + " and {COMBooking.shiprefno}= '" + txt_booking.Text + "' and {COMBooking.trantype}='" + StrTranType + "'";
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    //  str_Script = "window.open('../Reportasp/BookingSlip.aspx?Booking=" + txt_booking.Text + "&StrTranType=" + StrTranType + "&LoginBranchid=" + Session["LoginBranchid"].ToString() + "&Buying=" + txtBuying.Text + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 4, int.Parse(Session["LoginBranchid"].ToString()), txt_booking.Text + " FERegVew");
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Booking", str_Script, true);

                    Session["str_sp"] = str_sp;
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + " BookView");
                }
                else
                {
                    str_RptName = "BookingRegister.rpt";
                    str_sf = "{COMBooking.bid}=" + Session["LoginBranchid"].ToString();
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1, 4, int.Parse(Session["LoginBranchid"].ToString()), " FERegVew");
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "Booking", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
            }
            if (txt_booking.Text == "")
            {
                switch (Session["StrTranType"].ToString())
                {
                    case "FE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10, 1, Convert.ToInt32(Session["LoginBranchid"]), "FERegVew");
                        break;
                    case "FI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 11, 1, Convert.ToInt32(Session["LoginBranchid"]), "FIRegVew");
                        break;
                    case "AE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 12, 1, Convert.ToInt32(Session["LoginBranchid"]), "AERegVew");
                        break;
                    case "AI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 13, 1, Convert.ToInt32(Session["LoginBranchid"]), "AIRegVew");
                        break;
                }
            }
            else
            {
                switch (Session["StrTranType"].ToString())
                {
                    case "FE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/FEVew");
                        break;
                    case "FI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 11, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/FIVew");
                        break;
                    case "AE":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 12, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/AEVew");
                        break;
                    case "AI":
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 13, 1, Convert.ToInt32(Session["LoginBranchid"]), txt_booking.Text + "/AIVew");
                        break;
                }
            }

        }


        protected void lnk_back_Click(object sender, EventArgs e)
        {

            if (Session["blno"] != null)
            {
                Session["booking"] = null;
                Response.Redirect("../ForwardExports/BL Print.aspx");
                return;
            }
            else
            {
                Session["booking"] = null;
                Response.Redirect("../ForwardExports/BL Print.aspx");
            }
        }

        protected void txt_vessel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                //DataAccess.Masters.MasterVessel da_obj_Vessel = new DataAccess.Masters.MasterVessel();
                //  obj_dt = da_obj_Vessel.GetLikeVessel(txt_vessel.Text.ToUpper());
                int getvesselid = da_obj_Vessel.GetVesselid(txt_vessel.Text.Trim().ToUpper());
                if (getvesselid != 0 && hid_Vesselid.Value != "0")
                {
                    txt_voyage.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid Vessel Name');", true);
                    txt_vessel.Text = "";
                    txt_vessel.Focus();
                    blnerr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        [WebMethod]
        public static List<string> FE_Bookking(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterVessel da_obj_Vessel = new DataAccess.Masters.MasterVessel();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Vessel.GetDataBase(Ccode);
            obj_dt = da_obj_Vessel.GetLikeVessel(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList(obj_dt, "vesselname", "vesselid");
            return List_Result;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date_etd, date_eta, date_cutoff;
                date_etd = Convert.ToDateTime(txt_etd.Text + " " + DateTime.Now.ToLongTimeString());
                date_eta = Convert.ToDateTime(txt_eta.Text + " " + DateTime.Now.ToLongTimeString());
                date_cutoff = Convert.ToDateTime(txt_cutoff.Text + " " + DateTime.Now.ToLongTimeString());
                if (date_eta < date_etd)
                {
                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('ETD must not be Greater than ETA');", true);
                    return;
                }
                if (vsltype.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Select Vessel Type');", true);
                    return;
                }
                else if (hid_Vesselid.Value == "" || hid_Vesselid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Select correct Vessel');", true);
                    return;
                }
                else if (hid_Loadportid.Value == "" || hid_Loadportid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Select correct PLACE OF LOADING');", true);
                    return;
                }
                else if (hid_Destportid.Value == "" || hid_Destportid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Select correct PORT OF DISCHARGE');", true);
                    return;
                }
                //DataAccess.Marketing.Booking book = new DataAccess.Marketing.Booking();
                int bookingno;
                txt_vessel_TextChanged(sender, e);
                txt_vsl_pol_TextChanged(sender, e);
                txt_vsl_pod_TextChanged(sender, e);
                if (blnerr == true)
                {
                    return;
                }
                if (btnSave.ToolTip == "Update")
                {
                    bookingno = Convert.ToInt32(hd_book.Value);
                    DataTable dt = new DataTable();
                    if (btn_add.ToolTip == "Add")
                    {
                        if (grd_vessel.Rows.Count > 0)
                        {
                            for (int i = 0; i <= grd_vessel.Rows.Count - 1; i++)
                            {
                                string vsl = grd_vessel.Rows[i].Cells[1].Text;
                                if (txt_vessel.Text == vsl)
                                {
                                    ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Vessel Already Exist');", true);
                                    txt_vessel.Text = "";
                                    txt_vessel.Focus();
                                    return;
                                }
                            }
                        }
                        book.InsBookingVesselDetails(bookingno, vsltype.SelectedValue, Convert.ToInt32(hid_Vesselid.Value), txt_voyage.Text.ToUpper(), date_eta, Convert.ToInt32(hid_Loadportid.Value), date_etd, Convert.ToInt32(hid_Destportid.Value), date_cutoff, bid);
                        // book.InsBookingVesselDetails(bookingno, vsltype.SelectedValue, txt_vessel.Text, txt_voyage.Text.ToUpper(), txt_vsl_pol.Text, txt_vsl_pod.Text, Convert.ToDateTime(txt_etd.Text), Convert.ToDateTime(txt_eta.Text));
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Vessel Details added');", true);
                    }
                    else
                    {
                        book.UpdBookingVesselDetails(bookingno, vsltype.SelectedValue, Convert.ToInt32(hid_Vesselid.Value), txt_voyage.Text.ToUpper(), date_eta, Convert.ToInt32(hid_Loadportid.Value), date_etd, Convert.ToInt32(hid_Destportid.Value), date_cutoff, bid);
                        ScriptManager.RegisterStartupScript(btn_add, typeof(Button), "JobInfo", "alertify.alert('Vessel Details Updated');", true);

                    }
                    dt = book.GetBookingVesselDetails(bookingno, bid);
                    if (dt.Rows.Count > 0)
                    {
                        panel_vessel.Visible = true;
                        grd_vessel.Visible = true;
                        Session["book"] = dt;
                        grd_vessel.DataSource = dt;
                        grd_vessel.DataBind();
                        //btn_add.Text = "Update";

                        vslclear();

                    }
                    UserRights();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "logix", "alertify.alert('Please Save Booking');", true);
                }
                vsltype.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void vslclear()
        {
            txt_etd.Text = DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
            txt_vessel.Text = ""; txt_voyage.Text = ""; txt_vsl_pod.Text = ""; txt_vsl_pol.Text = ""; btn_add.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn ico-add";
            txt_cutoff.Text = txt_etd.Text; vsltype.SelectedIndex = 0; txt_eta.Text = txt_etd.Text; txt_vessel.Enabled = true;
        }

        protected void grd_vessel_RowDataBound(object sender, GridViewRowEventArgs e)
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

                ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("Img_Delete");
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox()");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_vessel, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grd_vessel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date1, date2, date3;
                string vesseltype;
                vesseltype = grd_vessel.SelectedRow.Cells[0].Text;
                if (vesseltype == "Feeder")
                {
                    vsltype.SelectedValue = "F";
                }
                else if (vesseltype == "Mother")
                {
                    vsltype.SelectedValue = "M";
                }
                txt_vessel.Text = grd_vessel.SelectedRow.Cells[1].Text;
                txt_vessel.Enabled = false;
                txt_voyage.Text = grd_vessel.SelectedRow.Cells[2].Text;
                txt_vsl_pol.Text = grd_vessel.SelectedRow.Cells[3].Text; //DateTime.Parse(Logobj.GetDate().ToShortDateString()).ToString("dd-MMM-yyyy");
                date1 = Convert.ToDateTime(Utility.fn_ConvertDate(grd_vessel.SelectedRow.Cells[4].Text));
                txt_etd.Text = date1.ToString("dd-MMM-yyyy");
                txt_vsl_pod.Text = grd_vessel.SelectedRow.Cells[5].Text;
                date2 = Convert.ToDateTime(Utility.fn_ConvertDate(grd_vessel.SelectedRow.Cells[6].Text));
                txt_eta.Text = date2.ToString("dd-MMM-yyyy");
                date3 = Convert.ToDateTime(Utility.fn_ConvertDate(grd_vessel.SelectedRow.Cells[7].Text));
                txt_cutoff.Text = date3.ToString("dd-MMM-yyyy");
                hid_Vesselid.Value = grd_vessel.SelectedRow.Cells[8].Text;
                hid_Loadportid.Value = grd_vessel.SelectedRow.Cells[9].Text;
                hid_Destportid.Value = grd_vessel.SelectedRow.Cells[10].Text;
                // btn_add.Text = "Update";
                btn_add.ToolTip = "Update";
                btn_add1.Attributes["class"] = "btn ico-Update";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Img_Delete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //DataAccess.Marketing.Booking book = new DataAccess.Marketing.Booking();
                ImageButton Img_delete = (ImageButton)sender;
                GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                DataTable obj_dt = new DataTable();
                obj_dt = (DataTable)Session["book"];
                //int intbook;
                int rowID = grd.RowIndex;

                hid_Vesselid.Value = obj_dt.Rows[rowID][8].ToString();
                txt_voyage.Text = obj_dt.Rows[rowID][2].ToString();
                book.DelBookingVesselDetails(Convert.ToInt32(hd_book.Value), Convert.ToInt32(hid_Vesselid.Value), txt_voyage.Text, bid);
                //book.DeleteBookvessel(Convert.ToInt32( hid_Vesselid.Value));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Vessel Details Deleted...');", true);

                int bookingno = Convert.ToInt32(hd_book.Value);
                //obj_dt = book.SelectBookvsl(bookingno);
                //obj_dt = book.GetBookingVesselDetails(txt_booking.Text, bid, did);
                obj_dt = book.GetBookingVesselDetails(bookingno, bid);
                if (obj_dt.Rows.Count > 0)
                {
                    panel_vessel.Visible = true;
                    grd_vessel.Visible = true;
                    Session["book"] = obj_dt;
                    grd_vessel.DataSource = obj_dt;
                    grd_vessel.DataBind();
                    //btn_add.Text = "Update";
                    vslclear();
                }
                else
                {
                    panel_vessel.Visible = true;
                    grd_vessel.Visible = true;
                    Session["book"] = new DataTable();
                    grd_vessel.DataSource = new DataTable();
                    grd_vessel.DataBind();
                    vslclear();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        protected void grd_vessel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //DataAccess.Marketing.Booking book = new DataAccess.Marketing.Booking();
                if (e.CommandName == "Delete")
                {
                    //ImageButton Img_delete = (ImageButton)e.CommandSource;
                    //GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    //DataTable obj_dt = new DataTable();
                    //obj_dt = (DataTable)Session["book"];



                    //book.DeleteBookvessel(obj_dt.Rows[grd.RowIndex]["vessel"].ToString());
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Vessel Details Deleted...');", true);
                    //obj_dt.Rows[grd.RowIndex].Delete();
                    //obj_dt.AcceptChanges();
                    //grd_vessel.DataSource = obj_dt;
                    //grd_vessel.DataBind();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }



        protected void btn_shipmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_shipmail.Text != "")
                {
                    if ((IsValidEmailId(txt_shipmail.Text)))
                    {
                        if (ViewState["CurrentData"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["CurrentData"];
                            int count = dt.Rows.Count;
                            BindGrid(count, txt_shipmail.Text.ToUpper(), "SHIPPER");
                        }
                        else
                        {
                            BindGrid(1, txt_shipmail.Text.ToUpper(), "SHIPPER");
                        }

                        txt_shipmail.Text = "";
                        txt_shipmail.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Email Format');", true);
                        txt_shipmail.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void btn_cons_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_consmail.Text != "")
                {
                    if (IsValidEmailId(txt_consmail.Text))
                    {
                        if (ViewState["CurrentData"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["CurrentData"];
                            int count = dt.Rows.Count;
                            BindGrid(count, txt_consmail.Text.ToUpper(), "CONSIGNEE");
                        }
                        else
                        {
                            BindGrid(1, txt_consmail.Text.ToUpper(), "CONSIGNEE");
                        }
                        txt_consmail.Text = "";
                        txt_consmail.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Email Format');", true);
                        //txt_consmail.Text = "";
                        txt_consmail.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void btn_othermail_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_othermail.Text != "")
                {
                    if (IsValidEmailId(txt_othermail.Text))
                    {
                        if (ViewState["CurrentData"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["CurrentData"];
                            int count = dt.Rows.Count;
                            BindGrid(count, txt_othermail.Text.ToUpper(), "OTHERS");
                        }
                        else
                        {
                            BindGrid(1, txt_othermail.Text.ToUpper(), "OTHERS");
                        }
                        txt_othermail.Text = "";
                        txt_othermail.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Email Format');", true);
                        txt_othermail.Focus();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Mail ID Cant Be Balnk');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            try
            {

                if (ViewState["CurrentData"] != null)
                {
                    index = grdCMail.SelectedRow.RowIndex;
                    DataTable dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        dt.Rows.Remove(dt.Rows[index]);
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Details Deleted...');", true);
                    }

                    ViewState["CurrentData"] = dt;
                    grdCMail.DataSource = dt;
                    grdCMail.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void grdCancel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCancel.PageIndex = e.NewPageIndex;
                DataTable dt = (DataTable)ViewState["book"];
                grdCancel.DataSource = dt;
                grdCancel.DataBind();
                this.popcancel.Show();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void LoadCancel()
        {
            try
            {
                grdCancel.Visible = true;
                dtBooking = bookingobj.GetBookingPending(StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                if (dtBooking.Rows.Count > 0)
                {
                    grdCancel.DataSource = dtBooking;
                    grdCancel.DataBind();
                    ViewState["book"] = dtBooking;
                    this.popcancel.Show();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('No More Booking is Avilable to cancel');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }

        protected void grdBooking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBooking.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["dtbook"];
            grdBooking.DataSource = dt;
            grdBooking.DataBind();
            this.popupBooking.Show();
        }

        protected void txtInco_TextChanged(object sender, EventArgs e)
        {
            //DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
            // DataTable obj_Dt = new DataTable();
            // List<string> Incocode = new List<string>();
            // obj_Dt = bookingobj.GetLikeIncocode(prefix.ToUpper());
            int incodeid = bookingobj.Getinconame(txtInco.Text.Trim().ToUpper());
            if (incodeid != 0 && hdn_Incoid.Value != "0")
            {
                txt_vol.Focus();
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('Invalid INCO');", true);
                txtInco.Text = "";
                txtInco.Focus();
                blnerr = true;
                return;

            }

        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please select the I Read the SOP  For this Customer');", true);
            blnerr = true;
            return;
        }

        protected void btnno_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Click the SOP Link to Read the SOP  of this Customer');", true);
            blnerr = true;
            return;
        }

        protected void lbtnSop_Click(object sender, EventArgs e)
        {
            dtTable = (DataTable)ViewState["dtTable"];
            if (dtTable.Rows.Count > 0)
            {
                this.ModalPopupsop.Show();
                GridView1.Visible = true;
                txtsop.Text = "Standard Operating Procedure for  " + txt_shiper.Text;
                txtsop.Visible = true;
                DataTable dt = new DataTable();
                dt.Columns.Add("sop");
                dt.Columns.Add("status");
                for (int i = 0; i <= dtTable.Rows.Count - 1; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["sop"] = dtTable.Rows[i]["sop"];
                    if (dtTable.Rows[i]["status"] == "Mandatory")
                    {
                        dt.Rows[dt.Rows.Count - 1]["status"] = dtTable.Rows[i]["status"];
                    }
                    else
                    {
                        dt.Rows[dt.Rows.Count - 1]["status"] = dtTable.Rows[i]["status"];
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('No Sop Available');", true);
                return;
            }
        }

        protected void grdCancel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    //if (ddl_product.SelectedIndex == 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    //    blnerr = true;
                    //    ddl_product.Focus();
                    //    return;
                    //}
                    ImageButton Img_delete = (ImageButton)e.CommandSource;
                    GridViewRow grd = (GridViewRow)Img_delete.NamingContainer;
                    DataTable obj_dt = new DataTable();
                    obj_dt = (DataTable)ViewState["book"];

                    if (Session["bookingno"].ToString() != null)
                    {
                        StrTranType = grd.Cells[7].Text;
                        if (StrTranType == "OE")
                        {
                            StrTranType = "FE";
                        }
                        else if (StrTranType == "OI")
                        {
                            StrTranType = "FI";
                        }
                        bookingobj.Bookingcancel(Session["bookingno"].ToString(), StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Booking # " + Session["bookingno"].ToString() + " Cancelled.');", true);
                        dtBooking = bookingobj.GetBookingPending4Cancel(StrTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        if (dtBooking.Rows.Count > 0)
                        {
                            this.popcancel.Hide();
                            grdCancel.DataSource = new DataTable();
                            grdCancel.DataBind();
                        }
                        else
                        {
                            grdCancel.EmptyDataText = "No Records Found";
                        }

                    }
                    obj_dt.Rows[grd.RowIndex].Delete();
                    obj_dt.AcceptChanges();
                    ViewState["book"] = obj_dt;
                    this.popcancel.Show();
                    grdCancel.DataSource = (DataTable)ViewState["book"];
                    grdCancel.DataBind();

                    ScriptManager.RegisterStartupScript(Img_delete, typeof(ImageButton), "logix", "alertify.alert('Booking Cancel Deleted');", true);

                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdQuotation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdQuotation.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["quotation"];
            grdQuotation.DataSource = dt;
            grdQuotation.DataBind();
            this.popupBuying.Show();
        }

        protected void backsop_Click(object sender, EventArgs e)
        {
            plnsop.Visible = false;
            this.ModalPopupsop.Hide();
        }

        protected void txt_consignee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
                DataTable dtCarrier = new DataTable();
                DataTable dtnew = new DataTable();
                //DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();
                // dtCarrier = Cusobj.GetLikeCustomer(txt_consignee.Text.ToUpper(), "C");
                // int customerid = Cusobj.GetCustomerid(txt_consignee.Text.Trim().ToUpper());


                //if (customerid!=0)
                DataTable dt = new DataTable();
                dt = custobj.GetexactCustomer(txt_consignee.Text.Trim().ToUpper(), "C");
                Session["hdn_Consigneeid"] = hdn_Consigneeid.Value;



                if (dt.Rows.Count > 0 && hdn_Consigneeid.Value != "0")
                {

                    dtnew = cus.getcustomerblk(Convert.ToInt32(hdn_Consigneeid.Value));
                    if (dtnew.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txt_consignee.Text + " status is Hold please discuss with Finance team ');", true);
                        txt_consignee.Text = "";
                        txt_consignee.Focus();

                        return;
                    }

                    txt_agent.Focus();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Consignee');", true);
                    txt_consignee.Text = "";
                    txt_consigneemulti.Text = "";
                    txt_consignee.Focus();
                    blnerr = true;
                    return;


                }




            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_vsl_pol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                //DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                //obj_dt = da_obj_Port.GetLikePort(txt_vsl_pol.Text.ToUpper());
                int getportid = da_obj_Port.GetNPortid(txt_vsl_pol.Text.Trim().ToUpper());
                if (getportid != 0 && hid_Loadportid.Value != "0")
                {
                    txt_vsl_pol.Focus();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid PORT OF LOADING');", true);
                    txt_vsl_pol.Text = "";
                    txt_vsl_pol.Focus();
                    blnerr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_vsl_pod_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                da_obj_Port.GetDataBase(Ccode);

                int getportid = da_obj_Port.GetNPortid(txt_vsl_pod.Text.Trim().ToUpper());
                if (getportid != 0 && hid_Destportid.Value != "0")
                {
                    txt_vsl_pod.Focus();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid PORT OF DISCHARGE');", true);
                    txt_vsl_pod.Text = "";
                    txt_vsl_pod.Focus();
                    blnerr = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txtFactory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCustomer Cusobj = new DataAccess.Masters.MasterCustomer();
                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                Cusobj.GetDataBase(Ccode);
                DataTable dtCarrier = new DataTable();
                // dtCarrier = Cusobj.GetLikeCustomer(txtFactory.Text.ToUpper(), "C");
                //int getcustomerid = custobj.GetCustomerid(txtFactory.Text.Trim().ToUpper());
                //if (getcustomerid!=0)
                DataTable dt = new DataTable();
                dt = custobj.GetexactCustomer(txtFactory.Text.Trim().ToUpper(), "C");
                if (dt.Rows.Count > 0)
                {
                    //txtBRemarks.Focus();

                }
                else
                {
                    txtFactory.Text = "";
                    txtFactory.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Factory Name');", true);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdCancel_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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

        protected void Amendsalesperson_Click(object sender, EventArgs e)
        {
            if (txt_booking.Text != "")
            {
                iframe1.Attributes["src"] = "../Sales/Salespersonchanged.aspx?bookno=" + txt_booking.Text+"&tran="+ Session["StrTranType"].ToString()+"&bid="+ Session["LoginBranchid"];
                pop_up.Show();

            }
            else
            {
                
                
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alert('Booking # cannot be Empty!');", true);
                txt_booking.Focus();
                 


            }
        }

        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10, "Book", txt_booking.Text, txt_booking.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 11, "Book", txt_booking.Text, txt_booking.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 12, "Book", txt_booking.Text, txt_booking.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 13, "Book", txt_booking.Text, txt_booking.Text, Session["StrTranType"].ToString());
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 13, "Book", txt_booking.Text, txt_booking.Text, "");
                }
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10, "Book", txt_booking.Text, txt_booking.Text, "");
            }


            if (txt_booking.Text != "")
            {
                JobInput.Text = txt_booking.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void approvedbooking_Click(object sender, EventArgs e)
        {
            portobj.Updapprovedagentinabooking(txt_booking.Text, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
        }

        /*protected void Bind_outstandingdetails()
        {
            DataTable dt = new DataTable();
            DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

            int divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int subgrpid = 40;
            int time = 0;
            int Credit_Amount = 0, outstdamt = 0, overdueamt = 0;

            time = Logobj.GetDate().Hour;
            if (time < 13)
            {
                dt = outsobj.OutStdingGET(99999, divisionid, subgrpid);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outsobj.OutStdingGET12N(99999, divisionid, subgrpid);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outsobj.OutStdingGET3PM(99999, divisionid, subgrpid);
            }

            if (dt.Rows.Count > 0)
            {
                DataTable DT_branch = new DataTable();
                DataView data_view = dt.DefaultView;

                data_view.RowFilter = "bid = " + branchid + "and " + "trantype = '" + ddl_product.Text + "' " + " and " + " custid = " + hdf_customerid.Value + " ";
                DT_branch = data_view.ToTable();

                if (DT_branch.Rows.Count > 0)
                {
                    DT_bind.Columns.Add("Customer", typeof(string));
                    DT_bind.Columns.Add("Details", typeof(string));
                    DataRow Drow = DT_bind.NewRow();

                    var sum_Outstanding = DT_branch.Compute("sum(amount)", "");
                    var sum_Over = DT_branch.Compute("sum(overdue)", "");
                    outstdamt = Convert.ToInt32(DT_branch.Compute("sum(amount)", ""));
                    overdueamt = Convert.ToInt32(DT_branch.Compute("sum(overdue)", ""));
                    sum_Outstanding = string.Format("{0:#,##0.00}", sum_Outstanding);
                    sum_Over = string.Format("{0:#,##0.00}", sum_Over);

                    int Credit_Days = Convert.ToInt32(DT_branch.Rows[0]["appdays"]);
                    Credit_Amount = Convert.ToInt32(DT_branch.Rows[0]["appamt"]);
                    int Over_Due_Days = Convert.ToInt32(DT_branch.Rows[0]["overduedays"]);

                    if (overdueamt > 0)
                    {
                        test.Text = "Credit Days:" + Credit_Days + "," + "Credit Amount:" + Credit_Amount + "," + "Over Due Days:" + Over_Due_Days + "," + "Over Due Amount:" + sum_Over + "," + "Total OS Amt:" + sum_Outstanding;
                        test.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        test.Text = "Credit Days:" + Credit_Days + "," + "Credit Amount:" + Credit_Amount + "," + "Over Due Days:" + Over_Due_Days + "," + "Over Due Amount:" + sum_Over + "," + "Total OS Amt:" + sum_Outstanding;
                        test.ForeColor = System.Drawing.Color.Green;
                    }
                    //ViewState["GridSalesOutPerson"] = DT_bind;
                    if (outstdamt > Credit_Amount)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Quotation", "alertify.alert('You have fully utilized Credit Exemption Limit for this Month');", true);
                    }
                }
                else
                {
                    test.Text = "Credit Days:" + "," + "Credit Amount:" + "," + "Over Due Days:" + "," + "Over Due Amount:" + "," + "Total OS Amt:";
                    test.ForeColor = System.Drawing.Color.Black;
                }
            }
        } 
      */





        protected void Bind_outstandingdetails()
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable DtCE = new DataTable();
            DataTable dtinv = new DataTable();

            //DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
            //DataAccess.CreditException Crexobj = new DataAccess.CreditException();

            int divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int subgrpid = 40;
            int time = 0;
            int Credit_Amount = 0, outstdamt = 0, overdueamt = 0;



            DtCE = Crexobj.GetBookingCust4CEbooking(Session["StrTranType"].ToString(), txt_booking.Text, branchid);
            int intcustidn = 0; string salesperson = "";
            if (DtCE.Rows.Count > 0)
            {

                intcustidn = Convert.ToInt32(DtCE.Rows[0]["customerid"].ToString());

            }
            else
            {
                intcustidn = 0;
            }

            double totalamt = 0, overdueamount = 0;
            int overduedays = 0;
            int extradays = 0;
            dtinv = Crexobj.GetCustInvOut(intcustidn, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));

            if (dtinv.Rows.Count > 0)
            {

                for (int i = 0; i <= dtinv.Rows.Count - 1; i++)
                {
                    overduedays = Convert.ToInt32(dtinv.Rows[i]["noofdays"].ToString());
                    totalamt += Convert.ToDouble(dtinv.Rows[i]["osamount"].ToString());
                    if (Convert.ToInt32(dtinv.Rows[i]["noofdays"].ToString()) > 30)
                    {
                        overdueamount += Convert.ToDouble(dtinv.Rows[i]["osamount"].ToString());
                    }

                }

                extradays = Convert.ToInt32(dtinv.Compute("max(noofdays)", ""));


                dt2 = Crexobj.GetCustCreditAmtcust(intcustidn, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (dt2.Rows.Count > 0)
                {

                    //Convert.ToInt32(dtinv.Compute("max(osamount)", "");

                    //txt_cdays.Text = dt2.Rows[0]["creditdays"].ToString();
                    //camt = Convert.ToDouble(dt2.Rows[0]["creditamt"].ToString());
                    //txt_credit.Text = Math.Round(camt, 2).ToString("#0.00");
                    overduedays = extradays - Convert.ToInt32(dt2.Rows[0]["creditdays"]);

                    if (overduedays <= 0)
                    {
                        if (overdueamount > 0)
                        {
                            test.Text = "Credit Days:" + dt2.Rows[0]["creditdays"].ToString() + "," + "Credit Amount:" + dt2.Rows[0]["creditamt"].ToString() + "," + "Over Due Days:" + "0," + "Over Due Amount:" + overdueamount + "," + "Total OS Amt:" + totalamt;
                            test.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            test.Text = "Credit Days:" + dt2.Rows[0]["creditdays"].ToString() + "," + "Credit Amount:" + dt2.Rows[0]["creditamt"].ToString() + "," + "Over Due Days:" + "0," + "Over Due Amount:" + overdueamount + "," + "Total OS Amt:" + totalamt;
                            test.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    else
                    {
                        if (overdueamount > 0)
                        {
                            test.Text = "Credit Days:" + dt2.Rows[0]["creditdays"].ToString() + "," + "Credit Amount:" + dt2.Rows[0]["creditamt"].ToString() + "," + "Over Due Days:" + overduedays + "," + "Over Due Amount:" + overdueamount + "," + "Total OS Amt:" + totalamt;
                            test.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            test.Text = "Credit Days:" + dt2.Rows[0]["creditdays"].ToString() + "," + "Credit Amount:" + dt2.Rows[0]["creditamt"].ToString() + "," + "Over Due Days:" + overduedays + "," + "Over Due Amount:" + overdueamount + "," + "Total OS Amt:" + totalamt;
                            test.ForeColor = System.Drawing.Color.Green;
                        }
                    }

                }
            }
            else
            {


                dt2 = Crexobj.GetCustCreditAmtcust(intcustidn, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                if (dt2.Rows.Count > 0)
                {

                    //Convert.ToInt32(dtinv.Compute("max(osamount)", "");

                    //txt_cdays.Text = dt2.Rows[0]["creditdays"].ToString();
                    //camt = Convert.ToDouble(dt2.Rows[0]["creditamt"].ToString());
                    //txt_credit.Text = Math.Round(camt, 2).ToString("#0.00");
                    overduedays = extradays - Convert.ToInt32(dt2.Rows[0]["creditdays"]);

                    if (overdueamount > 0)
                    {
                        test.Text = "Credit Days:" + dt2.Rows[0]["creditdays"].ToString() + "," + "Credit Amount:" + dt2.Rows[0]["creditamt"].ToString();
                        test.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        test.Text = "Credit Days:" + dt2.Rows[0]["creditdays"].ToString() + "," + "Credit Amount:" + dt2.Rows[0]["creditamt"].ToString();
                        test.ForeColor = System.Drawing.Color.Green;
                    }

                }
                else
                {
                    test.Text = "Cash and Carry Customer";// "Credit Days:" + "," + "Credit Amount:" + "," + "Over Due Days:" + "," + "Over Due Amount:" + "," + "Total OS Amt:";
                    test.ForeColor = System.Drawing.Color.Black;
                }

            }
        }

        protected void GridViewlog_PreRender(object sender, EventArgs e)
        {
            if (GridViewlog.Rows.Count > 0)
            {
                GridViewlog.UseAccessibleHeader = true;
                GridViewlog.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdCMail_PreRender(object sender, EventArgs e)
        {
            if (grdCMail.Rows.Count > 0)
            {
                grdCMail.UseAccessibleHeader = true;
                grdCMail.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdBuying_PreRender(object sender, EventArgs e)
        {
            if (GrdBuying.Rows.Count > 0)
            {
                GrdBuying.UseAccessibleHeader = true;
                GrdBuying.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void txt_custpono_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_sb_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtdetails = new DataTable();
            try
            {
                int intpkgs, intshipperid, intagentid, intpkg;
                string transtype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                int empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
                ModalPopupExtender1.Show();
                if (txt_sb.Text != "")
                {
                    dtdetails = ShippingBillobj.GetShippingBill(txt_sb.Text, bid, did);
                    if (dtdetails.Rows.Count != 0)
                    {
                       
                        bookno = txt_booking.Text;
                        
                        intshipperid = Convert.ToInt32(dtdetails.Rows[0]["shipper"].ToString());
                        hd_exporter.Value = intshipperid.ToString();
                        txt_exporter.Text = customerobj.GetCustomername(intshipperid);

                        txt_weight.Text = dtdetails.Rows[0]["grosswt"].ToString();
                        intpkgs = Convert.ToInt32(dtdetails.Rows[0]["pkgid"].ToString());
                        txt_pkgtype.Text = packageobj.GetPackagename(intpkgs);
                        txt_pkgs.Text = dtdetails.Rows[0]["noofpkg"].ToString();
                        intpkgs = Convert.ToInt32(dtdetails.Rows[0]["pld"].ToString());
                        txt_dest.Text = portobj.GetPortname(intpkgs);
                        int intagent= Convert.ToInt32(dtdetails.Rows[0]["agent"]);

                        //if(hd_customer.Value !="")
                        //if (dtdetails.Rows[0]["agent"].ToString() != "")
                        //{
                        //    txt_agent.Text = "";
                        //    intagentid = Convert.ToInt32(dtdetails.Rows[0]["agent"].ToString());
                        //    txt_agent.Text = customerobj.GetCustomername(intagentid);
                        //}

                        txt_volume.Text = dtdetails.Rows[0]["volume"].ToString();
                        txt_remarks.Text = dtdetails.Rows[0]["remarks"].ToString();

                        //if (dtdetails.Rows[0]["invpl"].ToString() == "y")
                        //{
                        //    chk_invoice.Checked = true;
                        //}
                        //else
                        //{
                        //    chk_invoice.Checked = false;
                        //}
                        //GetJobInfo();
                        //GetContExit();
                        //GetStuffDetails();
                         btn_save.Text = "Update";
                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                        //Grd_sb.DataSource = dtdetails;
                        //Grd_sb.DataBind();

                    }
                    else
                    {

                         btn_save.Text = "Save";
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

        protected void txt_pkgtype_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterPackages packobj = new DataAccess.Masters.MasterPackages();
               int intpkgs = packobj.GetNPackageid(txt_pkgtype.Text);
               ModalPopupExtender1.Show();
                if (intpkgs != 0)
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

        }

        protected void txt_dest_TextChanged(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
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
        protected void txt_exporter_TextChanged(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            int shipperid = customerobj.GetCustomerid(txt_exporter.Text.Trim().ToUpper());
            if (shipperid != 0)
            {


            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_exporter, typeof(TextBox), "Valid", "alertify.alert('INVALID Exporter');", true);
                txt_exporter.Text = "";
                txt_exporter.Focus();
               
            }

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //DataAccess.ForwardingExports.StuffingConfirmation STufobj = new DataAccess.ForwardingExports.StuffingConfirmation();
            DataTable dtdetails = new DataTable();
            DataTable dt = new DataTable();
            int intshipperid;
            //DataAccess.Masters.MasterPackages packobj = new DataAccess.Masters.MasterPackages();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            try
            {

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

                        return;
                    }
                }
                if (txt_dest.Text != "")
                {
                  int  cusdesttid = portobj.GetNPortid(txt_dest.Text);
                  if (cusdesttid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_dest, typeof(TextBox), "Valid", "alertify.alert('INVALID DESTINATION NAME');", true);
                        txt_dest.Text = "";
                        txt_dest.Focus();
                         
                        return;
                    }
                }
                if (txt_pol.Text != "")
                {
                   int pol = portobj.GetNPortid(txt_pol.Text);
                    if (pol == 0)
                    {
                        ScriptManager.RegisterStartupScript(txt_pol, typeof(TextBox), "Valid", "alertify.alert('INVALID PORT OF LOADING');", true);
                        txt_pol.Text = "";
                        txt_pol.Focus();
                        
                        return;
                    }
                }
                int intpkgs = packobj.GetNPackageid(txt_pkgtype.Text);
                int destid = portobj.GetNPortid(txt_dest.Text);
                if (btn_save.ToolTip == "Save")
                {
                    STufobj.InsertOEShipBillinbooking(txt_booking.Text, txt_sb.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_sbdate.Text)), Convert.ToInt32(txt_pkgs.Text), intpkgs,
                        Convert.ToDouble(txt_weight.Text.ToString()),
                        txt_volume.Text, intshipperid, Convert.ToInt32(hdn_agentid.Value), destid, txt_remarks.Text, 'N', 0, bid, empid, did);
                 
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved!!');", true);
                    sbclear();
                }
                else
                {
                    STufobj.UpdateShipBillinbooking(txt_sb.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDatetime(txt_sbdate.Text)), Convert.ToInt32(txt_pkgs.Text), intpkgs,
                         Convert.ToDouble(txt_weight.Text.ToString()),
                        txt_volume.Text, intshipperid, Convert.ToInt32(hdn_agentid.Value), destid, txt_remarks.Text, 'N', 0, bid, did);

                    btn_save.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "StuffingDetails", "alertify.alert('Details Updated');", true);
                    sbclear();
                }
                ModalPopupExtender1.Show();
            }

            catch (Exception ex)
            {


                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }
        private void sbclear()
        {
            txt_sb.Text = "";
            txt_sbdate.Text = Utility.fn_ConvertDate(Logobj.GetDate().ToShortDateString());
             
            txt_pkgs.Text = "";
            txt_pkgtype.Text = "";
            txt_weight.Text = "";
            txt_volume.Text = "";
            txt_exporter.Text = "";
            txt_dest.Text = "";
            
            txt_remarks.Text = "";
            
        }
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            sbclear();
            ModalPopupExtender1.Show();
        }

        protected void btn_shippingbill_Click(object sender, EventArgs e)
        {
            if (txt_booking.Text != "")
            {
                iframecost.Attributes["src"] = "../Sales/SBinBooking.aspx?book=" + txt_booking.Text + "&agent=" + hdn_agentid.Value;
                ModalPopupExtender1.Show();
            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_booking, typeof(TextBox), "BL", "alertify.alert('Kindly select Booking #');", true);
                txt_booking.Focus();
                
            }
        }


    }
}



